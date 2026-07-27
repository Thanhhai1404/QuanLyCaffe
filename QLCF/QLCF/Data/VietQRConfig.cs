using System;

namespace QLCF.Data
{
    /// <summary>
    /// Cấu hình VietQR Quick Link và SePay API cho thanh toán chuyển khoản.
    /// Thay đổi các giá trị BankId, AccountNo, AccountName theo thông tin ngân hàng thực tế.
    /// </summary>
    public static class VietQRConfig
    {
        // ========== THÔNG TIN NGÂN HÀNG NHẬN TIỀN ==========
        // Mã ngân hàng (BIN hoặc tên viết tắt). Ví dụ: "mbbank", "vietcombank", "techcombank", "970422"
        public static string BankId = "vietinbank";

        // Số tài khoản ngân hàng nhận tiền
        public static string AccountNo = "1052443754";

        // Tên chủ tài khoản (KHÔNG DẤU, viết hoa)
        public static string AccountName = "DO THANH HAI";

        // Mẫu QR: compact (540x540), compact2 (540x640 có thông tin), qr_only (480x480), print (600x776)
        public static string Template = "compact2";

        // ========== SEPAY API (AUTO-CHECK THANH TOÁN) ==========
        // URL endpoint SePay API v2
        public static string SePayApiUrl = "https://userapi.sepay.vn/v2/transactions";

        // Bearer Token lấy từ dashboard SePay (my.sepay.vn > Tích hợp > API Key)
        // Để trống nếu chưa có → hệ thống chỉ hỗ trợ xác nhận thủ công
        public static string SePayBearerToken = "";

        // Khoảng thời gian polling (ms) - mặc định 3 giây
        public static int PollingIntervalMs = 3000;

        // ========== HÀM TIỆN ÍCH ==========

        /// <summary>
        /// Sinh URL ảnh VietQR động theo chuẩn Napas Quick Link.
        /// </summary>
        public static string BuildQRUrl(decimal amount, int maHD)
        {
            string addInfo = Uri.EscapeDataString($"QLCF HD{maHD:D5}");
            string accName = Uri.EscapeDataString(AccountName);
            return $"https://img.vietqr.io/image/{BankId}-{AccountNo}-{Template}.png"
                 + $"?amount={(long)amount}&addInfo={addInfo}&accountName={accName}";
        }

        /// <summary>
        /// Sinh nội dung chuyển khoản chuẩn (dùng để so khớp giao dịch).
        /// </summary>
        public static string BuildTransferContent(int maHD)
        {
            return $"QLCF HD{maHD:D5}";
        }

        /// <summary>
        /// Tên ngân hàng hiển thị thân thiện (từ BankId).
        /// </summary>
        public static string GetBankDisplayName()
        {
            switch (BankId.ToLower())
            {
                case "mbbank":
                case "970422": return "MB Bank";
                case "vietcombank":
                case "970436": return "Vietcombank";
                case "techcombank":
                case "970407": return "Techcombank";
                case "vietinbank":
                case "970415": return "VietinBank";
                case "acb":
                case "970416": return "ACB";
                case "tpbank":
                case "970423": return "TPBank";
                case "bidv":
                case "970418": return "BIDV";
                case "agribank":
                case "970405": return "Agribank";
                case "sacombank":
                case "970403": return "Sacombank";
                case "vpbank":
                case "970432": return "VPBank";
                default: return BankId.ToUpper();
            }
        }

        /// <summary>
        /// Kiểm tra xem Auto-Check có khả dụng không (có SePay Token).
        /// </summary>
        public static bool IsAutoCheckEnabled => !string.IsNullOrWhiteSpace(SePayBearerToken);
    }
}
