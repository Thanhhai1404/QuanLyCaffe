using System;
using System.Data;
using System.Data.SqlClient;
using QLCF.Data;
using QLCF.Models;

namespace QLCF.Helpers
{
    public static class ShiftService
    {
        /// <summary>
        /// Đảm bảo bảng BangDiemDanh tồn tại trong CSDL
        /// </summary>
        public static void EnsureTableExists()
        {
            try
            {
                using (var conn = Db.CreateConnection())
                {
                    conn.Open();
                    string checkSql = @"
                        IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'BangDiemDanh')
                        BEGIN
                            CREATE TABLE BangDiemDanh (
                                MaDiemDanh INT IDENTITY(1,1) PRIMARY KEY,
                                MaNhanVien INT NOT NULL,
                                ThoiGianVaoCa DATETIME NOT NULL DEFAULT GETDATE(),
                                ThoiGianKetCa DATETIME NULL,
                                TongGioLam DECIMAL(5,2) NULL,
                                GhiChu NVARCHAR(255) NULL,
                                FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNV)
                            );
                        END

                        IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('BangDiemDanh') AND name = 'TongDoanhThu')
                        BEGIN
                            ALTER TABLE BangDiemDanh ADD
                                TienDauCa DECIMAL(18,2) DEFAULT 0,
                                DoanhThuTienMat DECIMAL(18,2) DEFAULT 0,
                                DoanhThuChuyenKhoan DECIMAL(18,2) DEFAULT 0,
                                TongDoanhThu DECIMAL(18,2) DEFAULT 0,
                                TienThucTeKiet DECIMAL(18,2) DEFAULT 0,
                                ChenhLech DECIMAL(18,2) DEFAULT 0;
                        END
                    ";
                    using (var cmd = new SqlCommand(checkSql, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("EnsureTableExists Error: " + ex.Message);
            }
        }

        /// <summary>
        /// Kiểm tra xem nhân viên có ca làm việc nào đang active (chưa kết ca) không
        /// </summary>
        public static bool CheckActiveShift(int maNV, out int shiftId, out DateTime checkInTime)
        {
            shiftId = 0;
            checkInTime = DateTime.MinValue;

            try
            {
                using (var conn = Db.CreateConnection())
                {
                    conn.Open();
                    string sql = @"
                        SELECT TOP 1 MaDiemDanh, ThoiGianVaoCa 
                        FROM BangDiemDanh 
                        WHERE MaNhanVien = @MaNV AND ThoiGianKetCa IS NULL 
                        ORDER BY ThoiGianVaoCa DESC";

                    using (var cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaNV", maNV);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                shiftId = Convert.ToInt32(reader["MaDiemDanh"]);
                                checkInTime = Convert.ToDateTime(reader["ThoiGianVaoCa"]);
                                return true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("CheckActiveShift Error: " + ex.Message);
            }

            return false;
        }

        /// <summary>
        /// Điểm danh vào ca
        /// </summary>
        public static bool CheckInShift(int maNV)
        {
            try
            {
                using (var conn = Db.CreateConnection())
                {
                    conn.Open();
                    string sql = @"
                        INSERT INTO BangDiemDanh (MaNhanVien, ThoiGianVaoCa) 
                        OUTPUT INSERTED.MaDiemDanh 
                        VALUES (@MaNV, GETDATE())";

                    using (var cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaNV", maNV);
                        var result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            UserSession.CurrentShiftId = Convert.ToInt32(result);
                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("CheckInShift Error: " + ex.Message);
            }
            return false;
        }

        public static bool DirectCheckOut(int shiftId)
        {
            string query = @"
                UPDATE BangDiemDanh 
                SET ThoiGianKetCa = GETDATE(),
                    TongGioLam = ROUND(DATEDIFF(MINUTE, ThoiGianVaoCa, GETDATE()) / 60.0, 2)
                WHERE MaDiemDanh = @ShiftId AND ThoiGianKetCa IS NULL";

            try
            {
                using (SqlConnection conn = Db.CreateConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ShiftId", shiftId);
                        conn.Open();
                        bool success = cmd.ExecuteNonQuery() > 0;
                        if (success)
                        {
                            UserSession.CurrentShiftId = 0; // Xóa active shift
                        }
                        return success;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("DirectCheckOut Error: " + ex.Message);
            }
            return false;
        }

        /// <summary>
        /// Chốt sổ ca, cập nhật thời gian ra và các chỉ số tài chính
        /// </summary>
        public static bool FinalizeShiftReconciliation(int shiftId, decimal tienDauCa, decimal tienMat, decimal chuyenKhoan, decimal tongDoanhThu, decimal tienThucTe, decimal chenhLech, out decimal tongGioLam)
        {
            tongGioLam = 0;
            try
            {
                using (var conn = Db.CreateConnection())
                {
                    conn.Open();
                    string sql = @"
                        UPDATE BangDiemDanh 
                        SET ThoiGianKetCa = GETDATE(),
                            TongGioLam = CAST(DATEDIFF(MINUTE, ThoiGianVaoCa, GETDATE()) / 60.0 AS DECIMAL(5,2)),
                            TienDauCa = @TienDauCa,
                            DoanhThuTienMat = @DoanhThuTienMat,
                            DoanhThuChuyenKhoan = @DoanhThuChuyenKhoan,
                            TongDoanhThu = @TongDoanhThu,
                            TienThucTeKiet = @TienThucTeKiet,
                            ChenhLech = @ChenhLech
                        OUTPUT INSERTED.TongGioLam
                        WHERE MaDiemDanh = @ShiftId";

                    using (var cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@ShiftId", shiftId);
                        cmd.Parameters.AddWithValue("@TienDauCa", tienDauCa);
                        cmd.Parameters.AddWithValue("@DoanhThuTienMat", tienMat);
                        cmd.Parameters.AddWithValue("@DoanhThuChuyenKhoan", chuyenKhoan);
                        cmd.Parameters.AddWithValue("@TongDoanhThu", tongDoanhThu);
                        cmd.Parameters.AddWithValue("@TienThucTeKiet", tienThucTe);
                        cmd.Parameters.AddWithValue("@ChenhLech", chenhLech);
                        
                        var result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            tongGioLam = Convert.ToDecimal(result);
                            UserSession.CurrentShiftId = 0;
                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("FinalizeShiftReconciliation Error: " + ex.Message);
            }
            return false;
        }

        /// <summary>
        /// Lấy thời gian bắt đầu của một ca làm việc
        /// </summary>
        public static DateTime? GetShiftCheckInTime(int shiftId)
        {
            try
            {
                using (var conn = Db.CreateConnection())
                {
                    conn.Open();
                    string sql = "SELECT ThoiGianVaoCa FROM BangDiemDanh WHERE MaDiemDanh = @ShiftId";
                    using (var cmd = new System.Data.SqlClient.SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@ShiftId", shiftId);
                        var result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            return Convert.ToDateTime(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("GetShiftCheckInTime Error: " + ex.Message);
            }
            return null;
        }

        /// <summary>
        /// Dummy method để tránh lỗi biên dịch từ FrmChotSoCa cũ
        /// </summary>
        public static (decimal TongDoanhThu, decimal TienMat, decimal ChuyenKhoan, int TongHoaDon) GetShiftFinancialSummary(int maNhanVien, DateTime thoiGianVaoCa)
        {
            return (0, 0, 0, 0);
        }
    }
}
