using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCF.Data
{
    class Db
    {
        public static readonly string ConnectionString =
            @"Data Source=DOHAI\SQLEXPRESS;Initial Catalog=QLCF;Integrated Security=True;TrustServerCertificate=True";

        public static SqlConnection CreateConnection()
        {
            return new SqlConnection(ConnectionString);
        }

        public static void EnsureDatabaseSchema()
        {
            using (SqlConnection conn = CreateConnection())
            {
                conn.Open();
                
                // Ensure KhuyenMai table exists
                string initSchemaSql = @"
                IF EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID('dbo.KhuyenMai') AND name = 'DonToiThieu')
                BEGIN
                    DROP TABLE dbo.KhuyenMai;
                END

                IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'KhuyenMai')
                BEGIN
                    CREATE TABLE dbo.KhuyenMai (
                        MaKM INT IDENTITY(1,1) PRIMARY KEY,
                        TenKM NVARCHAR(200) NOT NULL,
                        MaKhuyenMai NVARCHAR(50) NOT NULL,
                        LoaiGiamGia INT NOT NULL DEFAULT 0,
                        GiaTriGiam DECIMAL(18,2) NOT NULL,
                        GiamToiDa DECIMAL(18,2) NULL,
                        DieuKienToiThieu DECIMAL(18,2) NOT NULL DEFAULT 0,
                        NgayBatDau DATETIME NOT NULL,
                        NgayKetThuc DATETIME NOT NULL,
                        SoLuotConLai INT NULL,
                        TrangThai BIT NOT NULL DEFAULT 1,
                        MoTa NVARCHAR(MAX) NULL,
                        NgayTao DATETIME NOT NULL DEFAULT GETDATE()
                    )
                END

                IF NOT EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID('dbo.HoaDon') AND name = 'MaKhuyenMai')
                BEGIN
                    ALTER TABLE dbo.HoaDon ADD MaKhuyenMai NVARCHAR(50) NULL;
                END
                ";
                using (SqlCommand cmdInit = new SqlCommand(initSchemaSql, conn))
                {
                    cmdInit.ExecuteNonQuery();
                }

                // Check columns to avoid Invalid Column Name errors
                string colNguoiMo = "MaNV"; // default
                bool hasMaNVThanhToan = false;
                
                using (SqlCommand cmdCol = new SqlCommand("SELECT name FROM sys.columns WHERE object_id = OBJECT_ID('dbo.HoaDon') AND name IN ('MaNVMo', 'MaNVTao', 'MaNV', 'MaNVThanhToan')", conn))
                {
                    using (SqlDataReader dr = cmdCol.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            string colName = dr.GetString(0);
                            if (colName == "MaNVMo") colNguoiMo = "MaNVMo";
                            else if (colName == "MaNVTao" && colNguoiMo != "MaNVMo") colNguoiMo = "MaNVTao";
                            else if (colName == "MaNVThanhToan") hasMaNVThanhToan = true;
                        }
                    }
                }

                string joinThanhToan = hasMaNVThanhToan ? "LEFT JOIN dbo.NhanVien nv2 ON h.MaNVThanhToan = nv2.MaNV" : "";
                string selThanhToan = hasMaNVThanhToan ? "ISNULL(nv2.HoTen, ''--'')" : "''--''";

                // Ensure vw_LichSuHoaDon exists
                string viewSql = $@"
                EXEC('
                CREATE OR ALTER VIEW [dbo].[vw_LichSuHoaDon] AS
                SELECT h.MaHD, h.MaBan, b.TenBan, k.TenKhuVuc, h.GioVao, h.GioRa, 
                       ISNULL(nv1.HoTen, ''--'') AS NguoiMo, 
                       {selThanhToan} AS NguoiThanhToan,
                       ISNULL(h.TongTienGoc, 0) AS TongTienGoc, ISNULL(h.GiamGia, 0) AS GiamGia, ISNULL(h.TongTien, 0) AS TongTien, 
                       h.PhuongThucThanhToan, h.TrangThai, h.LyDoHuy
                FROM dbo.HoaDon h
                LEFT JOIN dbo.Ban b ON h.MaBan = b.MaBan
                LEFT JOIN dbo.KhuVuc k ON b.MaKV = k.MaKV
                LEFT JOIN dbo.NhanVien nv1 ON h.{colNguoiMo} = nv1.MaNV
                {joinThanhToan}
                ')
                ";
                using (SqlCommand cmd = new SqlCommand(viewSql, conn))
                {
                    cmd.ExecuteNonQuery();
                }

                // Ensure TenSize in ChiTietHoaDon
                string addTenSize = @"
                IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('dbo.ChiTietHoaDon') AND name = 'TenSize')
                BEGIN
                    ALTER TABLE dbo.ChiTietHoaDon ADD TenSize NVARCHAR(50) NULL;
                END
                ";
                using (SqlCommand cmd = new SqlCommand(addTenSize, conn))
                {
                    cmd.ExecuteNonQuery();
                }
                
                // Ensure ThanhTien in ChiTietHoaDon
                string addThanhTien = @"
                IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('dbo.ChiTietHoaDon') AND name = 'ThanhTien')
                BEGIN
                    ALTER TABLE dbo.ChiTietHoaDon ADD ThanhTien DECIMAL(18, 2) NULL;
                END
                ";
                using (SqlCommand cmd = new SqlCommand(addThanhTien, conn))
                {
                    cmd.ExecuteNonQuery();
                }

                // Ensure missing columns in dbo.HoaDon
                string addHoaDonCols = @"
                IF NOT EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID('dbo.HoaDon') AND name = 'NgayThanhToan')
                    ALTER TABLE dbo.HoaDon ADD NgayThanhToan DATETIME NULL;

                IF NOT EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID('dbo.HoaDon') AND name = 'PhanTramGiamGia')
                    ALTER TABLE dbo.HoaDon ADD PhanTramGiamGia INT NULL DEFAULT 0;

                IF NOT EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID('dbo.HoaDon') AND name = 'SoTienGiam')
                    ALTER TABLE dbo.HoaDon ADD SoTienGiam DECIMAL(18,2) NULL DEFAULT 0;

                IF NOT EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID('dbo.HoaDon') AND name = 'TongTienThanhToan')
                    ALTER TABLE dbo.HoaDon ADD TongTienThanhToan DECIMAL(18,2) NULL DEFAULT 0;

                IF NOT EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID('dbo.HoaDon') AND name = 'TienKhachDua')
                    ALTER TABLE dbo.HoaDon ADD TienKhachDua DECIMAL(18,2) NULL DEFAULT 0;

                IF NOT EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID('dbo.HoaDon') AND name = 'TienTraLai')
                    ALTER TABLE dbo.HoaDon ADD TienTraLai DECIMAL(18,2) NULL DEFAULT 0;

                IF NOT EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID('dbo.HoaDon') AND name = 'MaNVThanhToan')
                    ALTER TABLE dbo.HoaDon ADD MaNVThanhToan INT NULL;

                IF NOT EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID('dbo.HoaDon') AND name = 'PhuongThucThanhToan')
                    ALTER TABLE dbo.HoaDon ADD PhuongThucThanhToan NVARCHAR(50) NULL;

                IF NOT EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID('dbo.HoaDon') AND name = 'MaKhuyenMai')
                    ALTER TABLE dbo.HoaDon ADD MaKhuyenMai NVARCHAR(50) NULL;

                IF NOT EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID('dbo.HoaDon') AND name = 'TongTienGoc')
                    ALTER TABLE dbo.HoaDon ADD TongTienGoc DECIMAL(18,2) NULL DEFAULT 0;
                ";
                using (SqlCommand cmd = new SqlCommand(addHoaDonCols, conn))
                {
                    cmd.ExecuteNonQuery();
                }

                // Ensure vw_SoDoBan exists with correct status logic
                string colNgayMo = "NgayTao";
                using (SqlCommand cmdCol = new SqlCommand("SELECT name FROM sys.columns WHERE object_id = OBJECT_ID('dbo.HoaDon') AND name IN ('GioVao', 'NgayMo', 'NgayTao')", conn))
                {
                    using (SqlDataReader dr = cmdCol.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            string cName = dr.GetString(0);
                            if (cName == "GioVao") { colNgayMo = "GioVao"; break; }
                            if (cName == "NgayMo") colNgayMo = "NgayMo";
                        }
                    }
                }

                string viewSoDoBan = $@"
                EXEC('
                CREATE OR ALTER VIEW [dbo].[vw_SoDoBan] AS
                SELECT 
                    b.MaBan, 
                    b.TenBan, 
                    b.MaKV, 
                    k.TenKhuVuc,
                    CASE 
                        WHEN b.DangSuDung = 0 THEN N''Ngưng dùng''
                        WHEN h.MaHD IS NOT NULL THEN N''Có khách''
                        ELSE ISNULL(b.TrangThai, N''Trống'')
                    END AS TrangThai,
                    b.DangSuDung,
                    h.MaHD AS MaHoaDonMo,
                    h.{colNgayMo} AS GioVao,
                    ISNULL(ct.TamTinh, 0) AS TamTinh
                FROM dbo.Ban b
                LEFT JOIN dbo.KhuVuc k ON b.MaKV = k.MaKV
                LEFT JOIN dbo.HoaDon h ON b.MaBan = h.MaBan AND h.TrangThai = 0
                LEFT JOIN (
                    SELECT MaHD, SUM(ISNULL(ThanhTien, SoLuong * DonGia)) AS TamTinh
                    FROM dbo.ChiTietHoaDon
                    GROUP BY MaHD
                ) ct ON h.MaHD = ct.MaHD
                ')
                ";
                using (SqlCommand cmd = new SqlCommand(viewSoDoBan, conn))
                {
                    cmd.ExecuteNonQuery();
                }

                // Auto-heal any tables incorrectly marked as DangSuDung = 0 after payment
                string fixBanStatus = "UPDATE dbo.Ban SET DangSuDung = 1 WHERE DangSuDung = 0 AND (TrangThai IS NULL OR TrangThai = N'Trống' OR TrangThai = N'');";
                using (SqlCommand cmdFixBan = new SqlCommand(fixBanStatus, conn))
                {
                    cmdFixBan.ExecuteNonQuery();
                }
            }
        }
    }
}
