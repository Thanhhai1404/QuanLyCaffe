using System;
using System.Windows.Forms;
using QLCF.Forms;
using QLCF.Models;

namespace QLCF.Forms
{
    public partial class FrmMain : Form
    {
        private bool isLoggingOut = false;

        public FrmMain()
        {
            InitializeComponent();

            this.Load += FrmMain_Load;
            this.FormClosing += FrmMain_FormClosing;

            // Gán sự kiện click cho nút Đăng xuất
            this.btnDangXuat.Click += btnDangXuat_Click;

            // Gán sự kiện click riêng cho nút Bán hàng
            this.btnBanHang.Click += btnBanHang_Click;

            // Gán sự kiện click cho các nút Menu còn lại
            this.btnMonAn.Click += btnMonAn_Click;
            this.btnDanhMuc.Click += btnDanhMuc_Click;
            this.btnKhuVucBan.Click += btnKhuVucBan_Click;
            this.btnNhanVien.Click += btnMenu_Click;
            this.btnHoaDon.Click += btnHoaDon_Click;
            this.btnThongKe.Click += btnThongKe_Click;
            this.btnDoiMatKhau.Click += btnDoiMatKhau_Click;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            // Hiển thị thông tin người dùng trên Header
            lblXinChao.Text = $"Xin chào, {UserSession.HoTen}";
            lblVaiTro.Text = $"Vai trò: {UserSession.ChucVu}";

            // Phân quyền hiển thị Menu theo UserSession.IsAdmin
            if (UserSession.IsAdmin)
            {
                // Admin: Hiển thị tất cả menu
                btnBanHang.Visible = true;
                btnMonAn.Visible = true;
                btnDanhMuc.Visible = true;
                btnKhuVucBan.Visible = true;
                btnNhanVien.Visible = true;
                btnHoaDon.Visible = true;
                btnThongKe.Visible = true;
                btnDoiMatKhau.Visible = true;
            }
            else
            {
                // Nhân viên: Chỉ hiển thị Bán hàng và Đổi mật khẩu
                btnBanHang.Visible = true;
                btnDoiMatKhau.Visible = true;

                btnMonAn.Visible = false;
                btnDanhMuc.Visible = false;
                btnKhuVucBan.Visible = false;
                btnNhanVien.Visible = false;
                btnHoaDon.Visible = false;
                btnThongKe.Visible = false;
            }
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(
                "Bạn có muốn đăng xuất không?",
                "Xác nhận đăng xuất",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (dr == DialogResult.Yes)
            {
                isLoggingOut = true;
                UserSession.Clear();
                this.Close();
            }
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isLoggingOut)
            {
                // Người dùng đóng bằng nút X -> Đóng/Thoát ứng dụng
                UserSession.Clear();
                Application.Exit();
            }
        }

        /// <summary>
        /// Mở Form Bán hàng khi bấm nút btnBanHang
        /// </summary>
        private void btnBanHang_Click(object sender, EventArgs e)
        {
            using (FrmBanHang frmBanHang = new FrmBanHang())
            {
                frmBanHang.ShowDialog();
            }
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            if (!UserSession.IsAdmin)
            {
                MessageBox.Show(
                    "Bạn không có quyền truy cập chức năng này.",
                    "Cảnh báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            using (FrmThongKe frmThongKe = new FrmThongKe())
            {
                frmThongKe.ShowDialog(this);
            }
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            if (!UserSession.IsAdmin)
            {
                MessageBox.Show(
                    "Bạn không có quyền truy cập chức năng này.",
                    "Cảnh báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            using (FrmLichSuHoaDon frmLichSu = new FrmLichSuHoaDon())
            {
                frmLichSu.ShowDialog(this);
            }
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            using (FrmDoiMatKhau frmDoiMatKhau = new FrmDoiMatKhau())
            {
                if (frmDoiMatKhau.ShowDialog(this) == DialogResult.OK)
                {
                    // Người dùng đã đổi mật khẩu thành công và UserSession đã xóa.
                    // Đóng FrmMain để quay về màn hình đăng nhập
                    isLoggingOut = true;
                    this.Close();
                }
            }
        }

        private void btnDanhMuc_Click(object sender, EventArgs e)
        {
            if (!UserSession.IsAdmin)
            {
                MessageBox.Show(
                    "Bạn không có quyền truy cập chức năng này.",
                    "Cảnh báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            using (FrmQuanLyMonAn frm = new FrmQuanLyMonAn(0))
            {
                frm.ShowDialog(this);
            }
        }

        private void btnMonAn_Click(object sender, EventArgs e)
        {
            if (!UserSession.IsAdmin)
            {
                MessageBox.Show(
                    "Bạn không có quyền truy cập chức năng này.",
                    "Cảnh báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            using (FrmQuanLyMonAn frm = new FrmQuanLyMonAn(1))
            {
                frm.ShowDialog(this);
            }
        }

        private void btnKhuVucBan_Click(object sender, EventArgs e)
        {
            if (!UserSession.IsAdmin)
            {
                MessageBox.Show(
                    "Bạn không có quyền truy cập chức năng này.",
                    "Cảnh báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            using (FrmQuanLyKhuVucBan frm = new FrmQuanLyKhuVucBan())
            {
                frm.ShowDialog(this);
            }
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Chức năng này sẽ được xây dựng ở bước tiếp theo.",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }
    }
}
