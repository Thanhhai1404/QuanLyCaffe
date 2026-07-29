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
        // Mã ngân hàng (BIN hoặc tên viết tắt). Ví dụ: "MBBank", "VCB", "vietcombank", "970422"
        public static string BankId = "MBBank";

        // Số tài khoản ngân hàng nhận tiền
        public static string AccountNo = "0394907991";

        // Tên chủ tài khoản (KHÔNG DẤU, viết hoa)
        public static string AccountName = "DO THANH HAI";

        // Mẫu QR: compact, compact2, qr_only, print
        public static string Template = "compact";

        // ========== SEPAY API (AUTO-CHECK THANH TOÁN) ==========
        // URL endpoint SePay API (danh sách giao dịch)
        public static string SePayApiUrl = "https://my.sepay.vn/userapi/transactions/list";

        // Bearer Token lấy từ dashboard SePay (my.sepay.vn > Tích hợp > API Key)
        // ⚠️ ĐIỀN API KEY THẬT CỦA BẠN VÀO ĐÂY (Hoặc lưu trong cấu hình cục bộ)
        public static string SePayBearerToken = "YOUR_SEPAY_BEARER_TOKEN_HERE";

        // Khoảng thời gian polling (ms) - mặc định 3 giây
        public static int PollingIntervalMs = 3000;

        // ========== HÀM TIỆN ÍCH ==========

        /// <summary>
        /// Sinh URL ảnh QR động SePay chuẩn.
        /// </summary>
        public static string BuildQRUrl(decimal amount, int maHD)
        {
            string des = Uri.EscapeDataString($"QLCF HD{maHD:D5}");
            return $"https://qr.sepay.vn/img?bank={BankId}&acc={AccountNo}&template={Template}&amount={(long)amount}&des={des}";
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
                case "mb":
                case "mbbank":
                case "970422": return "MBBank";
                case "vcb":
                case "vietcombank":
                case "970436": return "Vietcombank (VCB)";
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
