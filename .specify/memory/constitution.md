# QLCF Project Constitution - Quy Định Dự Án Quản Lý Quán Cà Phê

## Core Principles (Nguyên Tắc Cốt Lõi)

### I. Kiến Trúc Chia Tầng Rõ Ràng (Layered Architecture)
- Dự án tuân thủ kiến trúc chia tầng chặt chẽ (`Forms/UI Layer`, `Data/Helper Layer`, `Models Layer`).
- Lớp Giao diện (Forms/UserControls) chỉ đảm nhận việc tương tác người dùng; logic xử lý dữ liệu được tách biệt qua các Helper/Data service.
- Đảm bảo tính mô-đun hóa, dễ bảo trì, mở rộng và kiểm thử độc lập.

### II. Quản Lý Dữ Liệu & Kết Nối SQL Server (Database Integrity & Security)
- Sử dụng SQL Server với ADO.NET / Entity Framework Core theo chuẩn kết nối an toàn.
- Tất cả truy vấn dữ liệu phải thông qua Stored Procedures hoặc Tham số hóa (Parameterized Queries) để ngăn chặn nguy cơ SQL Injection.
- Giải phóng tài nguyên kết nối triệt để bằng các khối `using` hoặc cơ chế quản lý lifecycle chuẩn.

### III. Giao Diện Thân Thiện, Đồng Nhất & Responsive (Modern UI/UX Standards)
- Áp dụng bảng màu "Warm Espresso & Slate" hiện đại, nhất quán từ `UITheme.cs`.
- Trải nghiệm Single-Window Dashboard: Nhúng trực tiếp tất cả các màn hình con vào vùng nội dung chính (`pnlNoiDung`), tránh tạo cửa sổ popup rời rạc không cần thiết.
- Tự động co giãn (Responsive Layout) bằng `TableLayoutPanel`, `FlowLayoutPanel`, và thiết lập `Anchor`/`Dock` chuẩn để không bị vỡ bố cục trên mọi độ phân giải.

### IV. Xử Lý Ngoại Lệ Đầy Đủ & An Toàn (Robust Exception Handling)
- **Kiểm soát dữ liệu đầu vào (Input Validation)**: Validate kỹ càng mọi trường dữ liệu trước khi gửi xuống cơ sở dữ liệu (kiểm tra rỗng, kiểu dữ liệu, độ dài, mật khẩu).
- **Xử lý sự cố mạng/DB (Connection Failure Handling)**: Bọc tất cả thao tác kết nối DB trong khối `try-catch`, đưa ra thông báo tiếng Việt ngắn gọn, dễ hiểu (`MessageBoxIcon.Error` / `Warning`) và giữ cho ứng dụng không bị crash đột ngột.
- Quản lý phiên làm việc (`UserSession`) chặt chẽ, hỗ trợ phân quyền Admin/Nhân viên chính xác.

### V. Ghi Chú Code Tiếng Việt & Chuẩn Sạch (Vietnamese Comments & Clean Code)
- **Comment bằng tiếng Việt**: Toàn bộ ghi chú hàm, lớp, thuộc tính và xử lý logic phức tạp phải được viết bằng tiếng Việt rõ ràng, dễ đọc.
- Đặt tên Control và Biến theo quy ước chuẩn C# Form (ví dụ: `btnThanhToan`, `txtTenMon`, `LoadThongKeTongQuan`).
- Loại bỏ các ký tự Unicode/Emoji dễ bị lỗi font hệ thống trên Windows Forms.

---

## Development & Quality Standards (Tiêu Chuẩn Phát Triển)

### Quality Gates (Tiêu Chí Đánh Giá Chất Lượng Code)
1. **Biên dịch**: Mã nguồn phải biên dịch 100% không có lỗi (Build Succeeded).
2. **Thẩm mỹ UI**: Mọi Form/Control mới đều phải sử dụng màu sắc, typography và phẳng hóa nút bấm qua `UITheme.cs`.
3. **Phân quyền**: Mọi tính năng quản trị đều phải gọi hàm kiểm tra quyền Admin (`KiemTraQuyenAdmin()`).

---

## Governance (Quản Trị Dự Án)
- Quy định Constitution này là chuẩn mực bắt buộc áp dụng cho toàn bộ thành phần thuộc hệ thống QLCF.
- Tất cả chức năng mới được phát triển độc lập trên các nhánh `feature/*` và lưu commit rõ ràng trước khi merge vào nhánh `main`.

**Version**: 1.0.0 | **Ratified**: 2026-07-27 | **Last Amended**: 2026-07-27
