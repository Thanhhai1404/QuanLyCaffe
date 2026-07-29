-- =========================================================
-- SCRIPT CẬP NHẬT TÍNH NĂNG CHỌN SIZE ĐỒ UỐNG (SIZE S, M, L)
-- Dự án: QLCF - Quản Lý Quán Cà Phê
-- =========================================================

USE [QLCF];
GO

-- 1. Bổ sung cột TenSize vào bảng ChiTietHoaDon (nếu chưa có)
IF NOT EXISTS (
    SELECT 1 
    FROM sys.columns 
    WHERE object_id = OBJECT_ID(N'[dbo].[ChiTietHoaDon]') 
      AND name = N'TenSize'
)
BEGIN
    ALTER TABLE [dbo].[ChiTietHoaDon]
    ADD [TenSize] NVARCHAR(20) NULL;
    PRINT N'Đã thêm cột TenSize vào bảng ChiTietHoaDon.';
END
GO

-- 2. Tạo bảng SizeMonAn để lưu cấu hình các Size của món (nếu cần quản lý động)
IF OBJECT_ID(N'[dbo].[SizeMonAn]', N'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[SizeMonAn] (
        [MaSize] INT IDENTITY(1,1) PRIMARY KEY,
        [MaMon] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[MonAn]([MaMon]) ON DELETE CASCADE,
        [TenSize] NVARCHAR(20) NOT NULL, -- 'S', 'M', 'L'
        [GiaPhuThu] DECIMAL(18,0) NOT NULL DEFAULT 0 -- 0, 5000, 10000...
    );
    PRINT N'Đã tạo bảng SizeMonAn.';
END
GO

-- 3. Cập nhật / Tạo mới Stored Procedure sp_ThemMonVaoHoaDon hỗ trợ chọn Size
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

    -- Lấy đơn giá gốc từ bảng MonAn
    SELECT @DonGiaGoc = DonGia FROM [dbo].[MonAn] WHERE MaMon = @MaMon;
    IF @DonGiaGoc IS NULL SET @DonGiaGoc = 0;
    
    -- Đơn giá thực tế = Giá gốc + Phụ thu Size
    SET @DonGiaThucTe = @DonGiaGoc + ISNULL(@GiaPhuThu, 0);

    -- Tìm hóa đơn chưa thanh toán của bàn (TrangThai = 0)
    SELECT TOP 1 @MaHD = MaHD FROM [dbo].[HoaDon] WHERE MaBan = @MaBan AND TrangThai = 0;

    -- Nếu chưa có hóa đơn mở, tạo hóa đơn mới
    IF @MaHD IS NULL
    BEGIN
        DECLARE @Cols NVARCHAR(MAX) = N'MaBan, TrangThai';
        DECLARE @Vals NVARCHAR(MAX) = N'@MaBan, 0';
        DECLARE @Params NVARCHAR(MAX) = N'@MaBan INT, @MaNV INT';

        -- Kiểm tra các cột nhân viên có thể có trong bảng HoaDon (MaNVMo, MaNVTao, MaNV)
        IF EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID(N'[dbo].[HoaDon]') AND name = N'MaNVMo')
        BEGIN
            SET @Cols = @Cols + N', MaNVMo';
            SET @Vals = @Vals + N', @MaNV';
        END
        IF EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID(N'[dbo].[HoaDon]') AND name = N'MaNVTao')
        BEGIN
            SET @Cols = @Cols + N', MaNVTao';
            SET @Vals = @Vals + N', @MaNV';
        END
        IF EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID(N'[dbo].[HoaDon]') AND name = N'MaNV') AND NOT EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID(N'[dbo].[HoaDon]') AND name IN (N'MaNVMo', N'MaNVTao'))
        BEGIN
            SET @Cols = @Cols + N', MaNV';
            SET @Vals = @Vals + N', @MaNV';
        END

        -- Kiểm tra các cột ngày giờ (NgayTao, GioVao, NgayMo)
        IF EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID(N'[dbo].[HoaDon]') AND name = N'NgayTao')
        BEGIN
            SET @Cols = @Cols + N', NgayTao';
            SET @Vals = @Vals + N', GETDATE()';
        END
        IF EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID(N'[dbo].[HoaDon]') AND name = N'GioVao')
        BEGIN
            SET @Cols = @Cols + N', GioVao';
            SET @Vals = @Vals + N', GETDATE()';
        END
        IF EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID(N'[dbo].[HoaDon]') AND name = N'NgayMo')
        BEGIN
            SET @Cols = @Cols + N', NgayMo';
            SET @Vals = @Vals + N', GETDATE()';
        END

        -- Kiểm tra các cột tổng tiền
        IF EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID(N'[dbo].[HoaDon]') AND name = N'TongTienGoc')
        BEGIN
            SET @Cols = @Cols + N', TongTienGoc';
            SET @Vals = @Vals + N', 0';
        END
        IF EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID(N'[dbo].[HoaDon]') AND name = N'TongTienThanhToan')
        BEGIN
            SET @Cols = @Cols + N', TongTienThanhToan';
            SET @Vals = @Vals + N', 0';
        END
        IF EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID(N'[dbo].[HoaDon]') AND name = N'TongTien')
        BEGIN
            SET @Cols = @Cols + N', TongTien';
            SET @Vals = @Vals + N', 0';
        END

        DECLARE @SqlHD NVARCHAR(MAX) = N'INSERT INTO [dbo].[HoaDon] (' + @Cols + N') VALUES (' + @Vals + N'); SELECT SCOPE_IDENTITY();';
        
        CREATE TABLE #TmpHD (MaHD INT);
        INSERT INTO #TmpHD EXEC sp_executesql @SqlHD, @Params, @MaBan, @MaNV;
        SELECT TOP 1 @MaHD = MaHD FROM #TmpHD;
        DROP TABLE #TmpHD;

        -- Cập nhật bàn sang Đang Sử Dụng
        UPDATE [dbo].[Ban] SET DangSuDung = 1, TrangThai = N'Có người' WHERE MaBan = @MaBan;
    END

    -- Kiểm tra xem trong hóa đơn đã có món này CÙNG SIZE chưa
    IF EXISTS (
        SELECT 1 FROM [dbo].[ChiTietHoaDon] 
        WHERE MaHD = @MaHD 
          AND MaMon = @MaMon 
          AND ISNULL(TenSize, N'') = ISNULL(@TenSize, N'')
    )
    BEGIN
        UPDATE [dbo].[ChiTietHoaDon]
        SET SoLuong = SoLuong + @SoLuong,
            DonGia = @DonGiaThucTe,
            GhiChu = CASE WHEN @GhiChu IS NOT NULL AND @GhiChu <> '' THEN @GhiChu ELSE GhiChu END
        WHERE MaHD = @MaHD 
          AND MaMon = @MaMon 
          AND ISNULL(TenSize, N'') = ISNULL(@TenSize, N'');
    END
    ELSE
    BEGIN
        INSERT INTO [dbo].[ChiTietHoaDon] (MaHD, MaMon, TenSize, SoLuong, DonGia, GhiChu)
        VALUES (@MaHD, @MaMon, @TenSize, @SoLuong, @DonGiaThucTe, @GhiChu);
    END

    -- Cập nhật tổng tiền cho Hóa Đơn
    DECLARE @Tong DECIMAL(18,0);
    SELECT @Tong = ISNULL(SUM(ThanhTien), 0) FROM [dbo].[ChiTietHoaDon] WHERE MaHD = @MaHD;

    IF EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID(N'[dbo].[HoaDon]') AND name = N'TongTienThanhToan')
    BEGIN
        EXEC sp_executesql N'UPDATE [dbo].[HoaDon] SET TongTienGoc = @Tong, TongTienThanhToan = @Tong WHERE MaHD = @MaHD', N'@Tong DECIMAL(18,0), @MaHD INT', @Tong, @MaHD;
    END
    ELSE IF EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID(N'[dbo].[HoaDon]') AND name = N'TongTien')
    BEGIN
        EXEC sp_executesql N'UPDATE [dbo].[HoaDon] SET TongTienGoc = @Tong, TongTien = @Tong WHERE MaHD = @MaHD', N'@Tong DECIMAL(18,0), @MaHD INT', @Tong, @MaHD;
    END
    ELSE
    BEGIN
        EXEC sp_executesql N'UPDATE [dbo].[HoaDon] SET TongTienGoc = @Tong WHERE MaHD = @MaHD', N'@Tong DECIMAL(18,0), @MaHD INT', @Tong, @MaHD;
    END
END
GO

PRINT N'Cập nhật SQL cho tính năng Size Đồ Uống thành công!';
GO
