# TỔNG HỢP TÀI LIỆU BÁO CÁO: PHẦN MỀM QUẢN LÝ QUÁN CAFE (QLCF)

## 1. Giới thiệu tổng quan
- **Tên dự án:** Phần mềm Quản lý Quán Cafe (Coffee Shop Management System).
- **Nền tảng công nghệ:** C# Windows Forms (.NET).
- **Cơ sở dữ liệu:** Microsoft SQL Server.
- **Mục tiêu:** Tự động hóa các nghiệp vụ bán hàng, thanh toán, quản lý kho, và báo cáo doanh thu, giúp tối ưu hóa quy trình vận hành quán cafe.
- **Điểm nổi bật:** Áp dụng hệ thống Design System UI/UX hiện đại (Bo góc, bảng màu ProMax, Dark/Light mode linh hoạt) mang lại trải nghiệm người dùng chuyên nghiệp.

---

## 2. Kiến trúc Cơ sở dữ liệu (Database Schema)
Hệ thống được thiết kế với chuẩn hóa dữ liệu cao, bao gồm các bảng chính và Trigger xử lý tự động:

### 2.1. Nhóm Dữ liệu Hệ thống & Phân quyền
- **Bảng `NhanVien`**: Lưu trữ thông tin tài khoản đăng nhập, họ tên, số điện thoại, và **Vai trò** (Admin / Staff).
- **Bảng `CaLamViec`** (nếu có) / **Chốt ca**: Lưu trữ lịch sử đăng nhập và chốt doanh thu cuối ca của nhân viên thu ngân.

### 2.2. Nhóm Dữ liệu Bán hàng & Thực đơn
- **Bảng `KhuVuc`**: Phân chia không gian quán (Tầng 1, Tầng 2, Sân vườn, Máy lạnh).
- **Bảng `Ban`**: Chứa thông tin bàn, khóa ngoại liên kết tới KhuVuc, và trạng thái hiện tại (Trống, Đang phục vụ, Đặt trước).
- **Bảng `DanhMuc`**: Phân loại thực đơn (Cà phê, Trà sữa, Nước ép, Đồ ăn vặt).
- **Bảng `MonAn`**: Danh sách sản phẩm, hình ảnh, giá gốc.
- **Bảng `KichThuoc_MonAn` (Size)**: Liên kết món ăn với các size (S, M, L) và mức giá cộng thêm (Phụ thu).
- **Bảng `KhuyenMai`**: Chứa các mã Voucher, điều kiện áp dụng (hóa đơn tối thiểu), phần trăm giảm, số tiền giảm tối đa, ngày bắt đầu/kết thúc.

### 2.3. Nhóm Dữ liệu Giao dịch (Hóa đơn)
- **Bảng `HoaDon`**: Lưu trữ thông tin giao dịch tổng quát (Mã bàn, Mã nhân viên, Giờ vào, Giờ ra, Tổng tiền gốc, Giảm giá, Tổng tiền thanh toán, Trạng thái thanh toán).
- **Bảng `ChiTietHoaDon`**: Lưu chi tiết từng món được gọi trong hóa đơn (Mã món, Size, Số lượng, Đơn giá, Thành tiền).

### 2.4. Nhóm Dữ liệu Kho & Nguyên vật liệu (Inventory)
- **Bảng `NguyenVatLieu`**: Lưu danh mục vật tư (Cà phê hạt, Đường, Sữa...), Đơn vị tính, Mức cảnh báo, và Số lượng tồn hiện tại.
- **Bảng `PhieuNhapKho`**: Lưu thông tin phiếu nhập hàng (Mã nhân viên tạo, Tổng tiền nhập, Ngày nhập, Ghi chú).
- **Bảng `ChiTietPhieuNhap`**: Lưu chi tiết từng nguyên liệu được nhập (Số lượng nhập, Đơn giá nhập, Thành tiền).

### 2.5. Các Trigger Tự động (Database Automation)
- **Trigger Cập nhật trạng thái Bàn**: Tự động chuyển bàn sang "Đang phục vụ" khi có hóa đơn mới, và trả về "Trống" khi hóa đơn được thanh toán xong.
- **Trigger Nhập Kho (`TRG_CapNhatTonKho_Nhap`)**: Tự động cộng dồn số lượng vào bảng `NguyenVatLieu` ngay khi có dòng dữ liệu được thêm vào `ChiTietPhieuNhap`.

---

## 3. Chi tiết Các Phân Hệ Chức Năng (Functional Modules)

### 3.1. Phân hệ Bán hàng (Point of Sale - POS)
Là màn hình trung tâm của thu ngân, tối ưu hóa thao tác chạm/click:
- **Quản lý sơ đồ bàn trực quan:** Hiển thị danh sách bàn theo từng Khu vực. Bàn thay đổi màu sắc dựa trên trạng thái thực tế.
- **Thao tác Order (Gọi món):** Hiển thị thực đơn dạng lưới hình ảnh. Khách hàng có thể chọn **Size** món (S, M, L) làm thay đổi giá tiền linh hoạt.
- **Nghiệp vụ Bàn:**
  - **Chuyển bàn:** Hỗ trợ chuyển toàn bộ hóa đơn từ bàn này sang bàn khác.
  - **Gộp bàn:** Gộp nhiều hóa đơn của các bàn khác nhau vào một bàn khi khách đi nhóm đông.

### 3.2. Phân hệ Thanh toán & Khuyến mãi (Billing)
- **Thanh toán Hóa đơn:** Tự động tính toán tổng tiền, VAT (nếu có).
- **Áp dụng Mã giảm giá (Voucher):** Hệ thống sẽ kiểm tra tính hợp lệ của mã (còn hạn không, hóa đơn có đạt yêu cầu tối thiểu không) và trừ tiền trực tiếp trên màn hình.
- **Tính tiền thừa:** Hỗ trợ nhập số tiền khách đưa và tính tự động số tiền cần thối lại. Hỗ trợ phương thức thanh toán Tiền mặt / Chuyển khoản.
- **Xem trước & Xuất Bill (`FrmXemTruocBill`):** Hiển thị bản in hóa đơn chuyên nghiệp trước khi xác nhận.

### 3.3. Phân hệ Quản lý Kho (Inventory Management)
- **Quản lý Nguyên vật liệu:** Danh mục vật tư dùng cho quán, thiết lập mức cảnh báo khi sắp hết hàng.
- **Lập Phiếu Nhập Kho:** Giao diện cho phép chọn nhiều nguyên liệu, nhập số lượng và giá nhập. Phiếu sau khi "Lưu" sẽ tự động lưu vào Lịch sử và **cộng dồn tồn kho**.
- **Lịch sử nhập kho:** Xem lại các phiếu nhập hàng theo thời gian, theo dõi dòng tiền nhập hàng.

### 3.4. Phân hệ Quản trị & Báo cáo (Admin Dashboard)
- **Dashboard Thống kê:** Bảng điều khiển trung tâm hiển thị Biểu đồ doanh thu (Chart), số lượng đơn hàng, món bán chạy nhất theo thời gian thực.
- **Quản lý Thực đơn & Sơ đồ:** Admin có quyền thêm/sửa/xóa Món ăn, Cập nhật giá, Thêm Bàn và Khu vực mới.
- **Quản lý Khuyến mãi:** Quản trị viên tự do tạo các chương trình khuyến mãi mới để kích cầu.

### 3.5. Phân hệ Nhân sự & Bảo mật (HR & Security)
- **Đăng nhập & Phân quyền:** Hệ thống hiển thị giao diện khác biệt dựa theo quyền (Admin thấy toàn bộ thống kê, Thu ngân chỉ thấy POS và Lịch sử hóa đơn).
- **Quản lý Nhân viên:** Thêm mới nhân viên, khóa tài khoản, **Reset mật khẩu** (chỉ Admin mới có quyền).
- **Bảo mật cá nhân:** Nhân viên tự đổi mật khẩu cá nhân.
- **Chốt sổ ca làm việc:** Báo cáo doanh thu trong ca của riêng thu ngân đó trước khi giao ca.

---

## 4. Điểm sáng của dự án (Nên nhấn mạnh trong lúc bảo vệ đồ án)
1. **Giao diện (UI/UX) đột phá:** Không sử dụng các control Windows Forms truyền thống cứng nhắc. Dự án áp dụng bộ engine tự custom (Vẽ bằng `GraphicsPath`) để tạo ra các panel bo góc, nút bấm có hiệu ứng hover mượt mà, bảng màu chuẩn thiết kế hiện đại (Design System).
2. **Tính trọn vẹn nghiệp vụ (Business Logic completeness):** Xử lý được các trường hợp khó như: Gộp/Chuyển bàn, Size món ăn, Khuyến mãi có điều kiện, Tự động hóa qua DB Triggers.
3. **Cấu trúc code (Clean Architecture):** Tổ chức rõ ràng giữa `Forms` (Giao diện), `Data` (Tầng dữ liệu / SQL), và `Helpers` (Tiện ích hỗ trợ).

---
*Tài liệu này được tạo tự động làm sườn cho bài Báo Cáo. Bạn có thể sao chép, chèn thêm hình ảnh chụp màn hình phần mềm và dán vào file Word báo cáo chính thức của mình.*
