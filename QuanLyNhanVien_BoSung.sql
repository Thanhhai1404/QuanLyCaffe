-- ============================================================================
-- SCRIPT BỔ SUNG QUẢN LÝ NHÂN VIÊN (QLCF)
-- Ngày tạo: 28/07/2026
-- An toàn: Sử dụng CREATE OR ALTER PROCEDURE, không làm mất dữ liệu.
-- ============================================================================

USE QLCF;
GO

-- 1. STORED PROCEDURE: Tạo nhân viên mới (sp_TaoNhanVien)
CREATE OR ALTER PROCEDURE dbo.sp_TaoNhanVien
    @MaNVThucHien INT,
    @TenDangNhap VARCHAR(50),
    @MatKhauHash VARCHAR(255),
    @HoTen NVARCHAR(100),
    @ChucVu NVARCHAR(20),
    @SoDienThoai VARCHAR(15) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        -- 1. Kiểm tra Admin thực hiện
        IF NOT EXISTS (
            SELECT 1 FROM dbo.NhanVien 
            WHERE MaNV = @MaNVThucHien AND ChucVu = N'Admin' AND TrangThai = 1
        )
        BEGIN
            RAISERROR(N'Bạn không có quyền Admin hoặc tài khoản của bạn đã bị khóa.', 16, 1);
            RETURN;
        END

        -- 2. Validate dữ liệu
        IF @TenDangNhap IS NULL OR LTRIM(RTRIM(@TenDangNhap)) = ''
        BEGIN
            RAISERROR(N'Tên đăng nhập không được để trống.', 16, 1);
            RETURN;
        END

        IF EXISTS (SELECT 1 FROM dbo.NhanVien WHERE LOWER(TenDangNhap) = LOWER(LTRIM(RTRIM(@TenDangNhap))))
        BEGIN
            RAISERROR(N'Tên đăng nhập đã tồn tại trong hệ thống.', 16, 1);
            RETURN;
        END

        IF @MatKhauHash IS NULL OR @MatKhauHash NOT LIKE '$2%'
        BEGIN
            RAISERROR(N'Mật khẩu mã hóa BCrypt không hợp lệ.', 16, 1);
            RETURN;
        END

        IF @HoTen IS NULL OR LTRIM(RTRIM(@HoTen)) = N''
        BEGIN
            RAISERROR(N'Họ tên nhân viên không được để trống.', 16, 1);
            RETURN;
        END

        IF @ChucVu NOT IN (N'Admin', N'NhanVien')
        BEGIN
            RAISERROR(N'Chức vụ không hợp lệ. Chỉ chấp nhận Admin hoặc NhanVien.', 16, 1);
            RETURN;
        END

        -- 3. INSERT nhân viên mới (mặc định TrangThai = 1)
        INSERT INTO dbo.NhanVien (TenDangNhap, MatKhauHash, HoTen, ChucVu, SoDienThoai, TrangThai, NgayTao)
        VALUES (LTRIM(RTRIM(@TenDangNhap)), @MatKhauHash, LTRIM(RTRIM(@HoTen)), @ChucVu, @SoDienThoai, 1, SYSDATETIME());

        DECLARE @NewMaNV INT = SCOPE_IDENTITY();

        -- 4. Ghi nhật ký hệ thống
        INSERT INTO dbo.NhatKyHeThong (MaNV, HanhDong, DoiTuong, MaDoiTuong, NoiDung, ThoiGian)
        VALUES (
            @MaNVThucHien,
            N'Tạo nhân viên mới',
            N'NhanVien',
            @NewMaNV,
            N'Tạo nhân viên mới: ' + @TenDangNhap + N' (' + @HoTen + N'), Chức vụ: ' + @ChucVu,
            SYSDATETIME()
        );

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        DECLARE @ErrMsg1 NVARCHAR(4000) = ERROR_MESSAGE();
        RAISERROR(@ErrMsg1, 16, 1);
    END CATCH
END;
GO

-- 2. STORED PROCEDURE: Cập nhật thông tin nhân viên (sp_CapNhatThongTinNhanVien)
CREATE OR ALTER PROCEDURE dbo.sp_CapNhatThongTinNhanVien
    @MaNVThucHien INT,
    @MaNVCanSua INT,
    @HoTen NVARCHAR(100),
    @SoDienThoai VARCHAR(15) = NULL,
    @ChucVu NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        -- 1. Kiểm tra Admin thực hiện
        IF NOT EXISTS (
            SELECT 1 FROM dbo.NhanVien 
            WHERE MaNV = @MaNVThucHien AND ChucVu = N'Admin' AND TrangThai = 1
        )
        BEGIN
            RAISERROR(N'Bạn không có quyền Admin hoặc tài khoản của bạn đã bị khóa.', 16, 1);
            RETURN;
        END

        -- 2. Kiểm tra nhân viên cần sửa có tồn tại
        IF NOT EXISTS (SELECT 1 FROM dbo.NhanVien WHERE MaNV = @MaNVCanSua)
        BEGIN
            RAISERROR(N'Nhân viên cần cập nhật không tồn tại trong hệ thống.', 16, 1);
            RETURN;
        END

        -- 3. Kiểm tra Họ tên không rỗng
        IF @HoTen IS NULL OR LTRIM(RTRIM(@HoTen)) = N''
        BEGIN
            RAISERROR(N'Họ tên nhân viên không được để trống.', 16, 1);
            RETURN;
        END

        -- 4. Kiểm tra Chức vụ hợp lệ
        IF @ChucVu NOT IN (N'Admin', N'NhanVien')
        BEGIN
            RAISERROR(N'Chức vụ không hợp lệ. Chỉ chấp nhận Admin hoặc NhanVien.', 16, 1);
            RETURN;
        END

        -- Lấy chức vụ hiện tại của nhân viên được sửa
        DECLARE @ChucVuHienTai NVARCHAR(20);
        SELECT @ChucVuHienTai = ChucVu FROM dbo.NhanVien WHERE MaNV = @MaNVCanSua;

        -- 5. Không cho Admin đang đăng nhập tự đổi vai trò của chính mình
        IF @MaNVThucHien = @MaNVCanSua AND @ChucVu <> @ChucVuHienTai
        BEGIN
            RAISERROR(N'Bạn không thể tự thay đổi vai trò của chính mình.', 16, 1);
            RETURN;
        END

        -- 6. Không cho hạ quyền Admin cuối cùng đang hoạt động
        IF @ChucVuHienTai = N'Admin' AND @ChucVu = N'NhanVien'
        BEGIN
            DECLARE @SoAdminHoatDong INT;
            SELECT @SoAdminHoatDong = COUNT(*) 
            FROM dbo.NhanVien 
            WHERE ChucVu = N'Admin' AND TrangThai = 1;

            IF @SoAdminHoatDong <= 1
            BEGIN
                RAISERROR(N'Không thể hạ quyền Admin cuối cùng đang hoạt động trên hệ thống.', 16, 1);
                RETURN;
            END
        END

        -- 7. UPDATE thông tin
        UPDATE dbo.NhanVien
        SET HoTen = LTRIM(RTRIM(@HoTen)),
            SoDienThoai = @SoDienThoai,
            ChucVu = @ChucVu
        WHERE MaNV = @MaNVCanSua;

        -- 8. Ghi NhatKyHeThong
        INSERT INTO dbo.NhatKyHeThong (MaNV, HanhDong, DoiTuong, MaDoiTuong, NoiDung, ThoiGian)
        VALUES (
            @MaNVThucHien,
            N'Cập nhật nhân viên',
            N'NhanVien',
            @MaNVCanSua,
            N'Cập nhật thông tin nhân viên MaNV=' + CAST(@MaNVCanSua AS NVARCHAR(10)) + N', Họ tên: ' + @HoTen + N', Chức vụ: ' + @ChucVu,
            SYSDATETIME()
        );

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        DECLARE @ErrMsg2 NVARCHAR(4000) = ERROR_MESSAGE();
        RAISERROR(@ErrMsg2, 16, 1);
    END CATCH
END;
GO

-- 3. STORED PROCEDURE: Reset mật khẩu nhân viên (sp_ResetMatKhauNhanVien)
CREATE OR ALTER PROCEDURE dbo.sp_ResetMatKhauNhanVien
    @MaNVThucHien INT,
    @MaNVCanReset INT,
    @MatKhauHashMoi VARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        -- 1. Kiểm tra Admin thực hiện
        IF NOT EXISTS (
            SELECT 1 FROM dbo.NhanVien 
            WHERE MaNV = @MaNVThucHien AND ChucVu = N'Admin' AND TrangThai = 1
        )
        BEGIN
            RAISERROR(N'Bạn không có quyền Admin hoặc tài khoản của bạn đã bị khóa.', 16, 1);
            RETURN;
        END

        -- 2. Kiểm tra nhân viên cần reset có tồn tại
        IF NOT EXISTS (SELECT 1 FROM dbo.NhanVien WHERE MaNV = @MaNVCanReset)
        BEGIN
            RAISERROR(N'Nhân viên cần reset mật khẩu không tồn tại.', 16, 1);
            RETURN;
        END

        -- 3. Kiểm tra MatKhauHashMoi hợp lệ BCrypt (bắt đầu bằng $2)
        IF @MatKhauHashMoi IS NULL OR @MatKhauHashMoi NOT LIKE '$2%'
        BEGIN
            RAISERROR(N'Mã hash mật khẩu BCrypt không hợp lệ.', 16, 1);
            RETURN;
        END

        -- 4. UPDATE mật khẩu mới
        UPDATE dbo.NhanVien
        SET MatKhauHash = @MatKhauHashMoi
        WHERE MaNV = @MaNVCanReset;

        -- 5. Ghi NhatKyHeThong (Không ghi mật khẩu hoặc hash vào nội dung log)
        INSERT INTO dbo.NhatKyHeThong (MaNV, HanhDong, DoiTuong, MaDoiTuong, NoiDung, ThoiGian)
        VALUES (
            @MaNVThucHien,
            N'Reset mật khẩu nhân viên',
            N'NhanVien',
            @MaNVCanReset,
            N'Reset mật khẩu cho nhân viên MaNV=' + CAST(@MaNVCanReset AS NVARCHAR(10)),
            SYSDATETIME()
        );

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        DECLARE @ErrMsg3 NVARCHAR(4000) = ERROR_MESSAGE();
        RAISERROR(@ErrMsg3, 16, 1);
    END CATCH
END;
GO

-- 4. STORED PROCEDURE: Đổi trạng thái khóa/mở nhân viên (sp_DoiTrangThaiNhanVien)
CREATE OR ALTER PROCEDURE dbo.sp_DoiTrangThaiNhanVien
    @MaNVThucHien INT,
    @MaNVCanDoi INT,
    @TrangThai BIT
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        -- 1. Kiểm tra Admin thực hiện
        IF NOT EXISTS (
            SELECT 1 FROM dbo.NhanVien 
            WHERE MaNV = @MaNVThucHien AND ChucVu = N'Admin' AND TrangThai = 1
        )
        BEGIN
            RAISERROR(N'Bạn không có quyền Admin hoặc tài khoản của bạn đã bị khóa.', 16, 1);
            RETURN;
        END

        -- 2. Kiểm tra nhân viên cần đổi có tồn tại
        IF NOT EXISTS (SELECT 1 FROM dbo.NhanVien WHERE MaNV = @MaNVCanDoi)
        BEGIN
            RAISERROR(N'Nhân viên cần thay đổi trạng thái không tồn tại.', 16, 1);
            RETURN;
        END

        -- 3. Không cho Admin tự khóa tài khoản của chính mình
        IF @MaNVThucHien = @MaNVCanDoi AND @TrangThai = 0
        BEGIN
            RAISERROR(N'Bạn không thể tự khóa tài khoản của chính mình.', 16, 1);
            RETURN;
        END

        -- 4. Không cho khóa Admin cuối cùng đang hoạt động
        DECLARE @ChucVuCanDoi NVARCHAR(20);
        SELECT @ChucVuCanDoi = ChucVu FROM dbo.NhanVien WHERE MaNV = @MaNVCanDoi;

        IF @ChucVuCanDoi = N'Admin' AND @TrangThai = 0
        BEGIN
            DECLARE @SoAdminHoatDong INT;
            SELECT @SoAdminHoatDong = COUNT(*) 
            FROM dbo.NhanVien 
            WHERE ChucVu = N'Admin' AND TrangThai = 1;

            IF @SoAdminHoatDong <= 1
            BEGIN
                RAISERROR(N'Không thể khóa tài khoản Admin cuối cùng đang hoạt động trên hệ thống.', 16, 1);
                RETURN;
            END
        END

        -- 5. UPDATE trạng thái
        UPDATE dbo.NhanVien
        SET TrangThai = @TrangThai
        WHERE MaNV = @MaNVCanDoi;

        -- 6. Ghi NhatKyHeThong
        DECLARE @HanhDongText NVARCHAR(50) = CASE WHEN @TrangThai = 1 THEN N'Mở khóa tài khoản nhân viên' ELSE N'Khóa tài khoản nhân viên' END;
        INSERT INTO dbo.NhatKyHeThong (MaNV, HanhDong, DoiTuong, MaDoiTuong, NoiDung, ThoiGian)
        VALUES (
            @MaNVThucHien,
            @HanhDongText,
            N'NhanVien',
            @MaNVCanDoi,
            @HanhDongText + N' MaNV=' + CAST(@MaNVCanDoi AS NVARCHAR(10)),
            SYSDATETIME()
        );

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        DECLARE @ErrMsg4 NVARCHAR(4000) = ERROR_MESSAGE();
        RAISERROR(@ErrMsg4, 16, 1);
    END CATCH
END;
GO
