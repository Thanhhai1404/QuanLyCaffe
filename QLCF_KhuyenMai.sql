-- =====================================================================
-- QLCF - Tạo bảng Khuyến Mãi
-- =====================================================================
USE QLCF;
GO

-- Tạo bảng KhuyenMai
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'KhuyenMai')
BEGIN
    CREATE TABLE dbo.KhuyenMai
    (
        MaKM                INT IDENTITY(1,1) PRIMARY KEY,
        TenKM               NVARCHAR(200)   NOT NULL,
        MaKhuyenMai         VARCHAR(30)     NOT NULL UNIQUE,    -- Mã code hiển thị (VD: KM20NGLE)
        LoaiGiamGia         INT             NOT NULL DEFAULT 0, -- 0 = Giảm theo %, 1 = Giảm trực tiếp VNĐ
        GiaTriGiam          DECIMAL(18,0)   NOT NULL,           -- Giá trị giảm (% hoặc VNĐ)
        GiamToiDa           DECIMAL(18,0)   NULL,               -- Giảm tối đa (áp dụng khi giảm %)
        DieuKienToiThieu    DECIMAL(18,0)   NOT NULL DEFAULT 0, -- Giá trị hóa đơn tối thiểu
        NgayBatDau          DATETIME        NOT NULL,
        NgayKetThuc         DATETIME        NOT NULL,
        SoLuotConLai        INT             NULL,               -- NULL = không giới hạn
        TrangThai           BIT             NOT NULL DEFAULT 1, -- 1 = Hoạt động, 0 = Tắt
        MoTa                NVARCHAR(500)   NULL,
        NgayTao             DATETIME        NOT NULL DEFAULT GETDATE()
    );
    PRINT N'Đã tạo bảng KhuyenMai thành công!';
END
ELSE
BEGIN
    PRINT N'Bảng KhuyenMai đã tồn tại.';
END
GO

-- Thêm dữ liệu mẫu
IF NOT EXISTS (SELECT 1 FROM dbo.KhuyenMai WHERE MaKhuyenMai = 'GIAM10')
BEGIN
    INSERT INTO dbo.KhuyenMai (TenKM, MaKhuyenMai, LoaiGiamGia, GiaTriGiam, GiamToiDa, DieuKienToiThieu, NgayBatDau, NgayKetThuc, SoLuotConLai, TrangThai, MoTa)
    VALUES
    (N'Giảm 10% đơn từ 100K', 'GIAM10', 0, 10, 50000, 100000, '2026-07-01', '2026-12-31', 100, 1, N'Giảm 10% cho hóa đơn từ 100.000đ, tối đa giảm 50.000đ'),
    (N'Giảm 20% đơn từ 200K', 'GIAM20', 0, 20, 100000, 200000, '2026-07-01', '2026-12-31', 50, 1, N'Giảm 20% cho hóa đơn từ 200.000đ, tối đa giảm 100.000đ'),
    (N'Giảm 30K đơn từ 150K', 'GIAM30K', 1, 30000, NULL, 150000, '2026-07-01', '2026-12-31', NULL, 1, N'Giảm trực tiếp 30.000đ cho hóa đơn từ 150.000đ, không giới hạn lượt'),
    (N'Happy Hour - Giảm 15%', 'HAPPYHOUR', 0, 15, 80000, 80000, '2026-07-01', '2026-08-31', 200, 1, N'Happy Hour giảm 15% cho đơn từ 80.000đ, tối đa 80.000đ');
    PRINT N'Đã thêm dữ liệu mẫu vào bảng KhuyenMai!';
END
GO

PRINT N'=== Script QLCF_KhuyenMai.sql hoàn tất! ===';
GO
