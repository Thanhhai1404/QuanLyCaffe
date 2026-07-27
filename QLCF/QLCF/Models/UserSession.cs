namespace QLCF.Models
{
    public static class UserSession
    {
        // ma nhan vien
        public static int MaNV { get; set; }

        // Họ tên nhân viên đang đăng nhập
        public static string HoTen { get; set; }

        // Vai trò: Admin hoặc NhanVien
        public static string ChucVu { get; set; }

        // Kiểm tra nhanh có phải Admin không
        public static bool IsAdmin
        {
            get { return ChucVu == "Admin"; }
        }

        // Xóa thông tin khi người dùng đăng xuất
        public static void Clear()
        {
            MaNV = 0;
            HoTen = "";
            ChucVu = "";
        }
    }
}