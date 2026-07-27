using System;
using BCrypt.Net;

namespace QLCF.Helpers
{
    public static class PasswordHelper
    {
        /// <summary>
        /// Tạo chuỗi BCrypt hash từ mật khẩu thô.
        /// </summary>
        /// <param name="password">Mật khẩu chưa mã hóa</param>
        /// <returns>Chuỗi BCrypt hash</returns>
        public static string HashPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("Mật khẩu không được để trống.", nameof(password));
            }

            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        /// <summary>
        /// Kiểm tra mật khẩu thô có khớp với chuỗi BCrypt hash không.
        /// </summary>
        /// <param name="password">Mật khẩu nhập từ giao diện</param>
        /// <param name="hash">Chuỗi hash trong CSDL</param>
        /// <returns>True nếu khớp, ngược lại False</returns>
        public static bool VerifyPassword(string password, string hash)
        {
            if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(hash))
            {
                return false;
            }

            try
            {
                return BCrypt.Net.BCrypt.Verify(password, hash);
            }
            catch
            {
                return false;
            }
        }
    }
}
