-- =========================================================================
-- SCRIPT TẠO CÁC BẢNG QUẢN LÝ KHO (INVENTORY & RECIPE)
-- Database: QLCF
-- =========================================================================
USE QLCF;
GO

-- 1. Bảng NguyenVatLieu (Lưu trữ danh sách hàng hóa trong kho)
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NguyenVatLieu]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[NguyenVatLieu](
        [MaNVL] [int] IDENTITY(1,1) NOT NULL,
        [TenNVL] [nvarchar](100) NOT NULL,
        [DonViTinh] [nvarchar](20) NOT NULL,
        [SoLuongTon] [float] NOT NULL DEFAULT ((0)),
        [MucCanhBao] [float] NOT NULL DEFAULT ((10)),
        [TrangThai] [bit] NOT NULL DEFAULT ((1)), -- 1: Đang sử dụng, 0: Ngừng sử dụng
        CONSTRAINT [PK_NguyenVatLieu] PRIMARY KEY CLUSTERED ([MaNVL] ASC)
    );
END
GO

-- 2. Bảng PhieuNhapKho (Lịch sử nhập hàng)
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PhieuNhapKho]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[PhieuNhapKho](
        [MaPN] [int] IDENTITY(1,1) NOT NULL,
        [NgayNhap] [datetime] NOT NULL DEFAULT (getdate()),
        [MaNV] [nvarchar](50) NULL, -- Khóa ngoại liên kết tới NhanVien (nếu có)
        [TongTien] [decimal](18, 0) NOT NULL DEFAULT ((0)),
        [GhiChu] [nvarchar](500) NULL,
        CONSTRAINT [PK_PhieuNhapKho] PRIMARY KEY CLUSTERED ([MaPN] ASC)
    );
END
GO

-- 3. Bảng ChiTietPhieuNhap (Chi tiết từng món nhập trong 1 phiếu)
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ChiTietPhieuNhap]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[ChiTietPhieuNhap](
        [MaCTPN] [int] IDENTITY(1,1) NOT NULL,
        [MaPN] [int] NOT NULL,
        [MaNVL] [int] NOT NULL,
        [SoLuongNhap] [float] NOT NULL,
        [DonGiaNhap] [decimal](18, 0) NOT NULL,
        [ThanhTien] [decimal](18, 0) NOT NULL,
        CONSTRAINT [PK_ChiTietPhieuNhap] PRIMARY KEY CLUSTERED ([MaCTPN] ASC),
        CONSTRAINT [FK_CTPN_PhieuNhap] FOREIGN KEY([MaPN]) REFERENCES [dbo].[PhieuNhapKho] ([MaPN]) ON DELETE CASCADE,
        CONSTRAINT [FK_CTPN_NguyenVatLieu] FOREIGN KEY([MaNVL]) REFERENCES [dbo].[NguyenVatLieu] ([MaNVL])
    );
END
GO


GO

-- 5. TRIGGER Tự động cập nhật số lượng tồn khi Thêm/Sửa/Xóa ChiTietPhieuNhap
IF OBJECT_ID ('TRG_CapNhatTonKho_Nhap', 'TR') IS NOT NULL
   DROP TRIGGER TRG_CapNhatTonKho_Nhap;
GO

CREATE TRIGGER TRG_CapNhatTonKho_Nhap
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

-- Thêm một vài dữ liệu mẫu cơ bản cho Nguyên vật liệu
INSERT INTO [dbo].[NguyenVatLieu] (TenNVL, DonViTinh, SoLuongTon, MucCanhBao)
VALUES 
(N'Cà phê hạt Robusta', N'Kg', 0, 5),
(N'Sữa đặc Ngôi Sao', N'Hộp', 0, 10),
(N'Đường trắng', N'Kg', 0, 5),
(N'Ly nhựa 500ml', N'Cái', 0, 100),
(N'Ống hút', N'Bịch', 0, 20);
GO
