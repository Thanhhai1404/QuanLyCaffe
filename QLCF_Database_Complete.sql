-- =========================================================================
-- SCRIPT DATABASE HOÀN CHỈNH: PHẦN MỀM QUẢN LÝ QUÁN CAFE (QLCF)
-- Ngày tổng hợp: 07/08/2026
-- =========================================================================

CREATE DATABASE QLCF;
GO
USE QLCF;
GO

-- =========================================================================
-- PHẦN 1: TẠO BẢNG DỮ LIỆU (TABLES)
-- =========================================================================

CREATE TABLE [dbo].[KhuVuc](
    [MaKV] INT IDENTITY(1,1) PRIMARY KEY,
    [TenKhuVuc] NVARCHAR(100) NOT NULL
);
GO

CREATE TABLE [dbo].[Ban](
    [MaBan] INT IDENTITY(1,1) PRIMARY KEY,
    [TenBan] NVARCHAR(100) NOT NULL,
    [MaKV] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[KhuVuc]([MaKV]),
    [TrangThai] NVARCHAR(50) DEFAULT N'Trống',
    [DangSuDung] BIT DEFAULT 0
);
GO

CREATE TABLE [dbo].[DanhMuc](
    [MaDM] INT IDENTITY(1,1) PRIMARY KEY,
    [TenDM] NVARCHAR(100) NOT NULL
);
GO

CREATE TABLE [dbo].[MonAn](
    [MaMon] INT IDENTITY(1,1) PRIMARY KEY,
    [TenMon] NVARCHAR(200) NOT NULL,
    [MaDM] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[DanhMuc]([MaDM]),
    [DonGia] DECIMAL(18,0) NOT NULL DEFAULT 0,
    [HinhAnh] NVARCHAR(MAX) NULL,
    [TrangThai] BIT DEFAULT 1
);
GO

CREATE TABLE [dbo].[SizeMonAn] (
    [MaSize] INT IDENTITY(1,1) PRIMARY KEY,
    [MaMon] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[MonAn]([MaMon]) ON DELETE CASCADE,
    [TenSize] NVARCHAR(20) NOT NULL,
    [GiaPhuThu] DECIMAL(18,0) NOT NULL DEFAULT 0 
);
GO

CREATE TABLE [dbo].[NhanVien](
    [MaNV] INT IDENTITY(1,1) PRIMARY KEY,
    [TenDangNhap] VARCHAR(50) NOT NULL UNIQUE,
    [MatKhauHash] VARCHAR(255) NOT NULL,
    [HoTen] NVARCHAR(100) NOT NULL,
    [SoDienThoai] VARCHAR(15) NULL,
    [ChucVu] NVARCHAR(50) NOT NULL DEFAULT N'NhanVien',
    [TrangThai] BIT NOT NULL DEFAULT 1,
    [NgayTao] DATETIME NOT NULL DEFAULT GETDATE()
);
GO

CREATE TABLE [dbo].[NhatKyHeThong] (
    [MaLog] INT IDENTITY(1,1) PRIMARY KEY,
    [MaNV] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[NhanVien]([MaNV]),
    [HanhDong] NVARCHAR(100) NOT NULL,
    [DoiTuong] NVARCHAR(50) NULL,
    [MaDoiTuong] INT NULL,
    [NoiDung] NVARCHAR(MAX) NULL,
    [ThoiGian] DATETIME NOT NULL DEFAULT GETDATE()
);
GO

CREATE TABLE [dbo].[KhuyenMai] (
    [MaKM] INT IDENTITY(1,1) PRIMARY KEY,
    [TenKM] NVARCHAR(200) NOT NULL,
    [MaKhuyenMai] NVARCHAR(50) NOT NULL UNIQUE,
    [LoaiGiamGia] INT NOT NULL DEFAULT 0,
    [GiaTriGiam] DECIMAL(18,2) NOT NULL,
    [GiamToiDa] DECIMAL(18,2) NULL,
    [DieuKienToiThieu] DECIMAL(18,2) NOT NULL DEFAULT 0,
    [NgayBatDau] DATETIME NOT NULL,
    [NgayKetThuc] DATETIME NOT NULL,
    [SoLuotConLai] INT NULL,
    [TrangThai] BIT NOT NULL DEFAULT 1,
    [MoTa] NVARCHAR(MAX) NULL,
    [NgayTao] DATETIME NOT NULL DEFAULT GETDATE()
);
GO

CREATE TABLE [dbo].[HoaDon](
    [MaHD] INT IDENTITY(1,1) PRIMARY KEY,
    [MaBan] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[Ban]([MaBan]),
    [MaNV] INT NULL FOREIGN KEY REFERENCES [dbo].[NhanVien]([MaNV]),
    [MaNVThanhToan] INT NULL FOREIGN KEY REFERENCES [dbo].[NhanVien]([MaNV]),
    [GioVao] DATETIME NOT NULL DEFAULT GETDATE(),
    [GioRa] DATETIME NULL,
    [TongTienGoc] DECIMAL(18,0) NOT NULL DEFAULT 0,
    [PhanTramGiamGia] INT DEFAULT 0,
    [SoTienGiam] DECIMAL(18,0) DEFAULT 0,
    [TongTien] DECIMAL(18,0) NOT NULL DEFAULT 0,
    [MaKhuyenMai] NVARCHAR(50) NULL,
    [TienKhachDua] DECIMAL(18,0) NULL,
    [PhuongThucThanhToan] NVARCHAR(50) NULL,
    [LyDoHuy] NVARCHAR(MAX) NULL,
    [TrangThai] INT NOT NULL DEFAULT 0
);
GO

CREATE TABLE [dbo].[ChiTietHoaDon](
    [MaCTHD] INT IDENTITY(1,1) PRIMARY KEY,
    [MaHD] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[HoaDon]([MaHD]) ON DELETE CASCADE,
    [MaMon] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[MonAn]([MaMon]),
    [TenSize] NVARCHAR(20) NULL,
    [SoLuong] INT NOT NULL DEFAULT 1,
    [DonGia] DECIMAL(18,0) NOT NULL,
    [ThanhTien] AS (SoLuong * DonGia),
    [GhiChu] NVARCHAR(300) NULL
);
GO

CREATE TABLE [dbo].[NguyenVatLieu](
    [MaNVL] INT IDENTITY(1,1) PRIMARY KEY,
    [TenNVL] NVARCHAR(100) NOT NULL,
    [DonViTinh] NVARCHAR(20) NOT NULL,
    [SoLuongTon] FLOAT NOT NULL DEFAULT 0,
    [MucCanhBao] FLOAT NOT NULL DEFAULT 10,
    [TrangThai] BIT NOT NULL DEFAULT 1
);
GO

CREATE TABLE [dbo].[PhieuNhapKho](
    [MaPN] INT IDENTITY(1,1) PRIMARY KEY,
    [NgayNhap] DATETIME NOT NULL DEFAULT GETDATE(),
    [MaNV] NVARCHAR(50) NULL,
    [TongTien] DECIMAL(18,0) NOT NULL DEFAULT 0,
    [GhiChu] NVARCHAR(500) NULL
);
GO

CREATE TABLE [dbo].[ChiTietPhieuNhap](
    [MaCTPN] INT IDENTITY(1,1) PRIMARY KEY,
    [MaPN] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[PhieuNhapKho]([MaPN]) ON DELETE CASCADE,
    [MaNVL] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[NguyenVatLieu]([MaNVL]),
    [SoLuongNhap] FLOAT NOT NULL,
    [DonGiaNhap] DECIMAL(18,0) NOT NULL,
    [ThanhTien] DECIMAL(18,0) NOT NULL
);
GO

-- =========================================================================
-- PHẦN 2: VIEWS
-- =========================================================================

CREATE OR ALTER VIEW [dbo].[vw_LichSuHoaDon] AS
SELECT h.MaHD, h.MaBan, b.TenBan, k.TenKhuVuc, h.GioVao, h.GioRa, 
       ISNULL(nv1.HoTen, '--') AS NguoiMo, 
       ISNULL(nv2.HoTen, '--') AS NguoiThanhToan,
       ISNULL(h.TongTienGoc, 0) AS TongTienGoc, 
       ISNULL(h.SoTienGiam, 0) AS GiamGia, 
       ISNULL(h.TongTien, 0) AS TongTien, 
       h.PhuongThucThanhToan, h.TrangThai, h.LyDoHuy
FROM dbo.HoaDon h
LEFT JOIN dbo.Ban b ON h.MaBan = b.MaBan
LEFT JOIN dbo.KhuVuc k ON b.MaKV = k.MaKV
LEFT JOIN dbo.NhanVien nv1 ON h.MaNV = nv1.MaNV
LEFT JOIN dbo.NhanVien nv2 ON h.MaNVThanhToan = nv2.MaNV;
GO

-- =========================================================================
-- PHẦN 3: TRIGGERS
-- =========================================================================

CREATE OR ALTER TRIGGER TRG_CapNhatTonKho_Nhap
ON [dbo].[ChiTietPhieuNhap]
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE nvl SET nvl.SoLuongTon = nvl.SoLuongTon - d.SoLuongNhap
    FROM [dbo].[NguyenVatLieu] nvl INNER JOIN deleted d ON nvl.MaNVL = d.MaNVL;

    UPDATE nvl SET nvl.SoLuongTon = nvl.SoLuongTon + i.SoLuongNhap
    FROM [dbo].[NguyenVatLieu] nvl INNER JOIN inserted i ON nvl.MaNVL = i.MaNVL;
END
GO

-- =========================================================================
-- PHẦN 4: STORED PROCEDURES
-- =========================================================================

CREATE OR ALTER PROCEDURE [dbo].[sp_ThemMonVaoHoaDon]
    @MaBan INT, @MaNV INT, @MaMon INT, @SoLuong INT = 1,
    @TenSize NVARCHAR(20) = N'S', @GiaPhuThu DECIMAL(18,0) = 0, @GhiChu NVARCHAR(300) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @MaHD INT, @DonGiaGoc DECIMAL(18,0), @DonGiaThucTe DECIMAL(18,0);
    SELECT @DonGiaGoc = ISNULL(DonGia, 0) FROM [dbo].[MonAn] WHERE MaMon = @MaMon;
    SET @DonGiaThucTe = @DonGiaGoc + ISNULL(@GiaPhuThu, 0);

    SELECT TOP 1 @MaHD = MaHD FROM [dbo].[HoaDon] WHERE MaBan = @MaBan AND TrangThai = 0;

    IF @MaHD IS NULL
    BEGIN
        INSERT INTO [dbo].[HoaDon] (MaBan, MaNV, TrangThai, GioVao) VALUES (@MaBan, @MaNV, 0, GETDATE());
        SET @MaHD = SCOPE_IDENTITY();
        UPDATE [dbo].[Ban] SET DangSuDung = 1, TrangThai = N'Có người' WHERE MaBan = @MaBan;
    END

    IF EXISTS (SELECT 1 FROM [dbo].[ChiTietHoaDon] WHERE MaHD = @MaHD AND MaMon = @MaMon AND ISNULL(TenSize, N'') = ISNULL(@TenSize, N''))
    BEGIN
        UPDATE [dbo].[ChiTietHoaDon]
        SET SoLuong = SoLuong + @SoLuong, DonGia = @DonGiaThucTe,
            GhiChu = CASE WHEN @GhiChu IS NOT NULL AND LTRIM(RTRIM(@GhiChu)) <> '' THEN @GhiChu ELSE GhiChu END
        WHERE MaHD = @MaHD AND MaMon = @MaMon AND ISNULL(TenSize, N'') = ISNULL(@TenSize, N'');
    END
    ELSE
    BEGIN
        INSERT INTO [dbo].[ChiTietHoaDon] (MaHD, MaMon, TenSize, SoLuong, DonGia, GhiChu)
        VALUES (@MaHD, @MaMon, @TenSize, @SoLuong, @DonGiaThucTe, @GhiChu);
    END

    DECLARE @Tong DECIMAL(18,0);
    SELECT @Tong = ISNULL(SUM(ThanhTien), 0) FROM [dbo].[ChiTietHoaDon] WHERE MaHD = @MaHD;
    UPDATE [dbo].[HoaDon] SET TongTienGoc = @Tong, TongTien = @Tong WHERE MaHD = @MaHD;
END
GO

CREATE OR ALTER PROCEDURE [dbo].[sp_ThanhToan]
    @MaHD INT, @MaNVThanhToan INT, @GiamGia INT, @PhuongThucThanhToan NVARCHAR(50),
    @TienKhachDua DECIMAL(18,0) = NULL, @MaKhuyenMai NVARCHAR(50) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @TongTienGoc DECIMAL(18,0), @SoTienGiam DECIMAL(18,0) = 0;
    SELECT @TongTienGoc = ISNULL(TongTienGoc, 0) FROM [dbo].[HoaDon] WHERE MaHD = @MaHD;
    
    IF @MaKhuyenMai IS NOT NULL
    BEGIN
        DECLARE @LoaiGiamGia INT, @GiaTriGiam DECIMAL(18,2), @GiamToiDa DECIMAL(18,2);
        SELECT @LoaiGiamGia = LoaiGiamGia, @GiaTriGiam = GiaTriGiam, @GiamToiDa = GiamToiDa 
        FROM [dbo].[KhuyenMai] WHERE MaKhuyenMai = @MaKhuyenMai AND TrangThai = 1;
        
        IF @LoaiGiamGia = 0
        BEGIN
            SET @SoTienGiam = @TongTienGoc * (@GiaTriGiam / 100);
            IF @GiamToiDa IS NOT NULL AND @GiamToiDa > 0 AND @SoTienGiam > @GiamToiDa
                SET @SoTienGiam = @GiamToiDa;
        END
        ELSE IF @LoaiGiamGia = 1
        BEGIN
            SET @SoTienGiam = @GiaTriGiam;
        END
    END
    
    DECLARE @TongThanhToan DECIMAL(18,0) = @TongTienGoc - @SoTienGiam;
    IF @TongThanhToan < 0 SET @TongThanhToan = 0;
    
    UPDATE [dbo].[HoaDon]
    SET TrangThai = 1, GioRa = GETDATE(), MaNVThanhToan = @MaNVThanhToan,
        PhuongThucThanhToan = @PhuongThucThanhToan, PhanTramGiamGia = @GiamGia, 
        SoTienGiam = @SoTienGiam, TongTien = @TongThanhToan, MaKhuyenMai = @MaKhuyenMai, 
        TienKhachDua = @TienKhachDua
    WHERE MaHD = @MaHD;
    
    DECLARE @MaBan INT;
    SELECT @MaBan = MaBan FROM [dbo].[HoaDon] WHERE MaHD = @MaHD;
    UPDATE [dbo].[Ban] SET DangSuDung = 0, TrangThai = N'Trống' WHERE MaBan = @MaBan;
END
GO

-- =========================================================================
-- PHẦN 5: DỮ LIỆU MẪU (DÙNG ĐỂ DEMO)
-- =========================================================================

-- 1. Khu Vực
INSERT INTO [dbo].[KhuVuc] (TenKhuVuc) VALUES (N'Tầng 1'), (N'Tầng 2'), (N'Sân Vườn');
GO

-- 2. Bàn
INSERT INTO [dbo].[Ban] (TenBan, MaKV, TrangThai, DangSuDung) VALUES 
(N'Bàn 1', 1, N'Trống', 0), (N'Bàn 2', 1, N'Trống', 0), (N'Bàn 3', 1, N'Trống', 0),
(N'Bàn 4', 2, N'Trống', 0), (N'Bàn 5', 2, N'Trống', 0),
(N'Bàn VIP 1', 3, N'Trống', 0), (N'Bàn VIP 2', 3, N'Trống', 0);
GO

-- 3. Danh Mục Món Ăn
INSERT INTO [dbo].[DanhMuc] (TenDM) VALUES (N'Cà Phê'), (N'Trà Sữa'), (N'Sinh Tố'), (N'Đồ Ăn Vặt');
GO

-- 4. Món Ăn
INSERT INTO [dbo].[MonAn] (TenMon, MaDM, DonGia, HinhAnh, TrangThai) VALUES 
(N'Cà Phê Đen Đá', 1, 20000, NULL, 1),
(N'Cà Phê Sữa Đá', 1, 25000, NULL, 1),
(N'Bạc Xỉu', 1, 28000, NULL, 1),
(N'Trà Sữa Trân Châu', 2, 35000, NULL, 1),
(N'Trà Đào Cam Sả', 2, 40000, NULL, 1),
(N'Sinh Tố Bơ', 3, 45000, NULL, 1),
(N'Hướng Dương', 4, 15000, NULL, 1);
GO

-- 5. Nguyên Vật Liệu
INSERT INTO [dbo].[NguyenVatLieu] (TenNVL, DonViTinh, SoLuongTon, MucCanhBao) VALUES 
(N'Cà phê hạt Robusta', N'Kg', 50, 5),
(N'Sữa đặc Ngôi Sao', N'Hộp', 100, 10),
(N'Đường trắng', N'Kg', 20, 5),
(N'Ly nhựa 500ml', N'Cái', 500, 100),
(N'Ống hút', N'Bịch', 10, 2);
GO

-- 6. Tài khoản Nhân Viên (Mật khẩu mặc định: 123456)
-- Hash BCrypt hợp lệ cho chuỗi "123456"
INSERT INTO [dbo].[NhanVien] (TenDangNhap, MatKhauHash, HoTen, SoDienThoai, ChucVu, TrangThai) 
VALUES 
('admin', '$2a$10$dXJ3SW6G7P50lGmMkkmwe.20cQQubK3.HZWzG3YB1tlRy.fqvM/BG', N'Quản Trị Viên', '0901234567', N'Admin', 1),
('nhanvien1', '$2a$10$dXJ3SW6G7P50lGmMkkmwe.20cQQubK3.HZWzG3YB1tlRy.fqvM/BG', N'Nhân Viên Bán Hàng 1', '0909876543', N'NhanVien', 1);
GO
