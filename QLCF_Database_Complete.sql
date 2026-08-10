-- =========================================================================
-- SCRIPT DATABASE HOÀN CHỈNH: PHẦN MỀM QUẢN LÝ QUÁN CAFE (QLCF)
-- Ngày tổng hợp: 07/08/2026
-- Mô tả: File bao gồm toàn bộ Cấu trúc Bảng (Tables), Trigger, và 
--        Stored Procedure đang được sử dụng trong mã nguồn C#.
--        Đã loại bỏ các bảng/chức năng thừa không đụng tới.
-- =========================================================================

CREATE DATABASE QLCF;
GO
USE QLCF;
GO

-- =========================================================================
-- PHẦN 1: TẠO BẢNG DỮ LIỆU (TABLES)
-- =========================================================================

-- 1. Bảng Khu Vực (Tầng 1, Tầng 2, Sân vườn...)
CREATE TABLE [dbo].[KhuVuc](
    [MaKV] INT IDENTITY(1,1) PRIMARY KEY,
    [TenKhuVuc] NVARCHAR(100) NOT NULL
);
GO

-- 2. Bảng Bàn (Liên kết với Khu Vực)
CREATE TABLE [dbo].[Ban](
    [MaBan] INT IDENTITY(1,1) PRIMARY KEY,
    [TenBan] NVARCHAR(100) NOT NULL,
    [MaKV] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[KhuVuc]([MaKV]),
    [TrangThai] NVARCHAR(50) DEFAULT N'Trống',
    [DangSuDung] BIT DEFAULT 0
);
GO

-- 3. Bảng Danh Mục Món Ăn
CREATE TABLE [dbo].[DanhMuc](
    [MaDM] INT IDENTITY(1,1) PRIMARY KEY,
    [TenDM] NVARCHAR(100) NOT NULL
);
GO

-- 4. Bảng Món Ăn
CREATE TABLE [dbo].[MonAn](
    [MaMon] INT IDENTITY(1,1) PRIMARY KEY,
    [TenMon] NVARCHAR(200) NOT NULL,
    [MaDM] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[DanhMuc]([MaDM]),
    [DonGia] DECIMAL(18,0) NOT NULL DEFAULT 0,
    [HinhAnh] NVARCHAR(MAX) NULL,
    [TrangThai] BIT DEFAULT 1
);
GO

-- 5. Bảng Size Món Ăn (Quản lý các size S, M, L cho từng món)
CREATE TABLE [dbo].[SizeMonAn] (
    [MaSize] INT IDENTITY(1,1) PRIMARY KEY,
    [MaMon] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[MonAn]([MaMon]) ON DELETE CASCADE,
    [TenSize] NVARCHAR(20) NOT NULL,
    [GiaPhuThu] DECIMAL(18,0) NOT NULL DEFAULT 0 
);
GO

-- 6. Bảng Nhân Viên (Tài khoản đăng nhập)
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

-- 7. Bảng Nhật Ký Hệ Thống (Lưu vết thao tác nhân sự)
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

-- 8. Bảng Khuyến Mãi (Voucher)
CREATE TABLE [dbo].[KhuyenMai] (
    [MaKM] INT IDENTITY(1,1) PRIMARY KEY,
    [TenKM] NVARCHAR(200) NOT NULL,
    [MaKhuyenMai] NVARCHAR(50) NOT NULL UNIQUE,
    [LoaiGiamGia] INT NOT NULL DEFAULT 0, -- 0: % | 1: Trừ tiền
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

-- 9. Bảng Hóa Đơn
CREATE TABLE [dbo].[HoaDon](
    [MaHD] INT IDENTITY(1,1) PRIMARY KEY,
    [MaBan] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[Ban]([MaBan]),
    [MaNV] INT NULL FOREIGN KEY REFERENCES [dbo].[NhanVien]([MaNV]), -- Nhân viên mở bàn
    [MaNVThanhToan] INT NULL FOREIGN KEY REFERENCES [dbo].[NhanVien]([MaNV]), -- Nhân viên tính tiền
    [GioVao] DATETIME NOT NULL DEFAULT GETDATE(),
    [GioRa] DATETIME NULL,
    [TongTienGoc] DECIMAL(18,0) NOT NULL DEFAULT 0,
    [PhanTramGiamGia] INT DEFAULT 0,
    [SoTienGiam] DECIMAL(18,0) DEFAULT 0,
    [TongTien] DECIMAL(18,0) NOT NULL DEFAULT 0, -- Cột tương đương TongTienThanhToan
    [MaKhuyenMai] NVARCHAR(50) NULL,
    [TienKhachDua] DECIMAL(18,0) NULL,
    [PhuongThucThanhToan] NVARCHAR(50) NULL,
    [LyDoHuy] NVARCHAR(MAX) NULL,
    [TrangThai] INT NOT NULL DEFAULT 0 -- 0: Chưa thanh toán, 1: Đã thanh toán, -1: Hủy
);
GO

-- 10. Bảng Chi Tiết Hóa Đơn
CREATE TABLE [dbo].[ChiTietHoaDon](
    [MaCTHD] INT IDENTITY(1,1) PRIMARY KEY,
    [MaHD] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[HoaDon]([MaHD]) ON DELETE CASCADE,
    [MaMon] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[MonAn]([MaMon]),
    [TenSize] NVARCHAR(20) NULL, -- S, M, L
    [SoLuong] INT NOT NULL DEFAULT 1,
    [DonGia] DECIMAL(18,0) NOT NULL,
    [ThanhTien] AS (SoLuong * DonGia), -- Cột tự tính toán
    [GhiChu] NVARCHAR(300) NULL
);
GO

-- 11. Bảng Nguyên Vật Liệu (Quản lý kho)
CREATE TABLE [dbo].[NguyenVatLieu](
    [MaNVL] INT IDENTITY(1,1) PRIMARY KEY,
    [TenNVL] NVARCHAR(100) NOT NULL,
    [DonViTinh] NVARCHAR(20) NOT NULL,
    [SoLuongTon] FLOAT NOT NULL DEFAULT 0,
    [MucCanhBao] FLOAT NOT NULL DEFAULT 10,
    [TrangThai] BIT NOT NULL DEFAULT 1
);
GO

-- 12. Bảng Phiếu Nhập Kho
CREATE TABLE [dbo].[PhieuNhapKho](
    [MaPN] INT IDENTITY(1,1) PRIMARY KEY,
    [NgayNhap] DATETIME NOT NULL DEFAULT GETDATE(),
    [MaNV] NVARCHAR(50) NULL, -- Khóa ngoại lỏng
    [TongTien] DECIMAL(18,0) NOT NULL DEFAULT 0,
    [GhiChu] NVARCHAR(500) NULL
);
GO

-- 13. Bảng Chi Tiết Phiếu Nhập Kho
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

-- View Lịch Sử Hóa Đơn (Hỗ trợ Dashboard)
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
-- PHẦN 3: TRIGGERS (Tự động hóa)
-- =========================================================================

-- Trigger cập nhật tồn kho khi nhập hàng
CREATE OR ALTER TRIGGER TRG_CapNhatTonKho_Nhap
ON [dbo].[ChiTietPhieuNhap]
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;
    
    -- Trừ số lượng cũ (khi Delete hoặc Update)
    UPDATE nvl
    SET nvl.SoLuongTon = nvl.SoLuongTon - d.SoLuongNhap
    FROM [dbo].[NguyenVatLieu] nvl
    INNER JOIN deleted d ON nvl.MaNVL = d.MaNVL;

    -- Cộng số lượng mới (khi Insert hoặc Update)
    UPDATE nvl
    SET nvl.SoLuongTon = nvl.SoLuongTon + i.SoLuongNhap
    FROM [dbo].[NguyenVatLieu] nvl
    INNER JOIN inserted i ON nvl.MaNVL = i.MaNVL;
END
GO

-- =========================================================================
-- PHẦN 4: STORED PROCEDURES (Quy trình nghiệp vụ)
-- =========================================================================

-- SP Thêm món vào hóa đơn (Hỗ trợ Size và Tự động mở bàn)
CREATE OR ALTER PROCEDURE [dbo].[sp_ThemMonVaoHoaDon]
    @MaBan INT,
    @MaNV INT,
    @MaMon INT,
    @SoLuong INT = 1,
    @TenSize NVARCHAR(20) = N'S',
    @GiaPhuThu DECIMAL(18,0) = 0,
    @GhiChu NVARCHAR(300) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    
    DECLARE @MaHD INT;
    DECLARE @DonGiaGoc DECIMAL(18,0);
    DECLARE @DonGiaThucTe DECIMAL(18,0);

    -- Lấy đơn giá gốc
    SELECT @DonGiaGoc = ISNULL(DonGia, 0) FROM [dbo].[MonAn] WHERE MaMon = @MaMon;
    
    -- Đơn giá thực tế = Giá gốc + Phụ thu Size
    SET @DonGiaThucTe = @DonGiaGoc + ISNULL(@GiaPhuThu, 0);

    -- Tìm hóa đơn chưa thanh toán của bàn (TrangThai = 0)
    SELECT TOP 1 @MaHD = MaHD FROM [dbo].[HoaDon] WHERE MaBan = @MaBan AND TrangThai = 0;

    -- Nếu chưa có, tạo hóa đơn mới
    IF @MaHD IS NULL
    BEGIN
        INSERT INTO [dbo].[HoaDon] (MaBan, MaNV, TrangThai, GioVao)
        VALUES (@MaBan, @MaNV, 0, GETDATE());
        
        SET @MaHD = SCOPE_IDENTITY();

        -- Cập nhật trạng thái bàn
        UPDATE [dbo].[Ban] SET DangSuDung = 1, TrangThai = N'Có người' WHERE MaBan = @MaBan;
    END

    -- Cập nhật chi tiết hóa đơn (Nếu cùng món và size thì cộng số lượng, ngược lại thêm mới)
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

    -- Cập nhật tổng tiền Hóa Đơn
    DECLARE @Tong DECIMAL(18,0);
    SELECT @Tong = ISNULL(SUM(ThanhTien), 0) FROM [dbo].[ChiTietHoaDon] WHERE MaHD = @MaHD;
    UPDATE [dbo].[HoaDon] SET TongTienGoc = @Tong, TongTien = @Tong WHERE MaHD = @MaHD;
END
GO

-- SP Thanh toán Hóa đơn
CREATE OR ALTER PROCEDURE [dbo].[sp_ThanhToan]
    @MaHD INT,
    @MaNVThanhToan INT,
    @GiamGia INT, -- Lưu phần trăm giảm giá (hoặc giá trị tùy logic)
    @PhuongThucThanhToan NVARCHAR(50),
    @TienKhachDua DECIMAL(18,0) = NULL,
    @MaKhuyenMai NVARCHAR(50) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    
    DECLARE @TongTienGoc DECIMAL(18,0);
    DECLARE @SoTienGiam DECIMAL(18,0) = 0;
    
    SELECT @TongTienGoc = ISNULL(TongTienGoc, 0) FROM [dbo].[HoaDon] WHERE MaHD = @MaHD;
    
    -- Xử lý giảm giá nếu có MaKhuyenMai hợp lệ
    IF @MaKhuyenMai IS NOT NULL
    BEGIN
        DECLARE @LoaiGiamGia INT, @GiaTriGiam DECIMAL(18,2), @GiamToiDa DECIMAL(18,2);
        SELECT @LoaiGiamGia = LoaiGiamGia, @GiaTriGiam = GiaTriGiam, @GiamToiDa = GiamToiDa 
        FROM [dbo].[KhuyenMai] WHERE MaKhuyenMai = @MaKhuyenMai AND TrangThai = 1;
        
        IF @LoaiGiamGia = 0 -- Giảm theo phần trăm
        BEGIN
            SET @SoTienGiam = @TongTienGoc * (@GiaTriGiam / 100);
            IF @GiamToiDa IS NOT NULL AND @GiamToiDa > 0 AND @SoTienGiam > @GiamToiDa
                SET @SoTienGiam = @GiamToiDa;
        END
        ELSE IF @LoaiGiamGia = 1 -- Giảm trực tiếp
        BEGIN
            SET @SoTienGiam = @GiaTriGiam;
        END
    END
    
    DECLARE @TongThanhToan DECIMAL(18,0) = @TongTienGoc - @SoTienGiam;
    IF @TongThanhToan < 0 SET @TongThanhToan = 0;
    
    -- Cập nhật Hóa Đơn
    UPDATE [dbo].[HoaDon]
    SET TrangThai = 1, GioRa = GETDATE(), MaNVThanhToan = @MaNVThanhToan,
        PhuongThucThanhToan = @PhuongThucThanhToan,
        PhanTramGiamGia = @GiamGia, SoTienGiam = @SoTienGiam, 
        TongTien = @TongThanhToan, MaKhuyenMai = @MaKhuyenMai, TienKhachDua = @TienKhachDua
    WHERE MaHD = @MaHD;
    
    -- Trả bàn về trạng thái Trống
    DECLARE @MaBan INT;
    SELECT @MaBan = MaBan FROM [dbo].[HoaDon] WHERE MaHD = @MaHD;
    UPDATE [dbo].[Ban] SET DangSuDung = 0, TrangThai = N'Trống' WHERE MaBan = @MaBan;
END
GO
