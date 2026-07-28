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

        /// <summary>
        /// Điểm danh kết ca
        /// </summary>
        public static bool CheckOutShift(int shiftId, out decimal tongGioLam)
        {
            tongGioLam = 0;
            try
            {
                using (var conn = Db.CreateConnection())
                {
                    conn.Open();
                    // Tính bằng DATEDIFF(MINUTE) chia 60.0 để ra số thập phân
                    string sql = @"
                        UPDATE BangDiemDanh 
                        SET ThoiGianKetCa = GETDATE(),
                            TongGioLam = CAST(DATEDIFF(MINUTE, ThoiGianVaoCa, GETDATE()) / 60.0 AS DECIMAL(5,2))
                        OUTPUT INSERTED.TongGioLam
                        WHERE MaDiemDanh = @ShiftId";

                    using (var cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@ShiftId", shiftId);
                        var result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            tongGioLam = Convert.ToDecimal(result);
                            UserSession.CurrentShiftId = 0; // Xóa active shift
                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("CheckOutShift Error: " + ex.Message);
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
                    using (var cmd = new SqlCommand(sql, conn))
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
    }
}
