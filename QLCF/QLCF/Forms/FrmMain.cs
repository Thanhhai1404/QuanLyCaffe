using System;
using System.Drawing;
using System.Windows.Forms;
using QLCF.Forms;
using QLCF.Helpers;
using QLCF.Models;

namespace QLCF.Forms
{
    public partial class FrmMain : Form
    {
        private bool isLoggingOut = false;
        private DashboardAdminControl dashboardAdminControl;
        private StaffWelcomeControl staffWelcomeControl;
        private Button activeMenuButton = null;

        public FrmMain()
        {
            InitializeComponent();

            this.Load += FrmMain_Load;
            this.FormClosing += FrmMain_FormClosing;

            // Event handlers
            this.btnDangXuat.Click += btnDangXuat_Click;
            this.btnBanHang.Click += btnBanHang_Click;
            this.btnMonAn.Click += btnMonAn_Click;
            this.btnDanhMuc.Click += btnDanhMuc_Click;
            this.btnKhuVucBan.Click += btnKhuVucBan_Click;
            this.btnNhanVien.Click += btnNhanVien_Click;
            this.btnHoaDon.Click += btnHoaDon_Click;
            this.btnKhuyenMai.Click += btnKhuyenMai_Click;
            this.btnThongKe.Click += btnThongKe_Click;
            this.btnDoiMatKhau.Click += btnDoiMatKhau_Click;
            this.btnKho.Click += btnKho_Click;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            UITheme.ApplyStyleToForm(this);

            if (pnlHeader != null) pnlHeader.BackColor = UITheme.HeaderDark;
            if (pnlMenu != null) pnlMenu.BackColor = UITheme.PrimaryDark;
            if (pnlLogo != null) pnlLogo.BackColor = Color.FromArgb(15, 23, 42);
            if (btnDangXuat != null) 
            {
                UITheme.ApplyStyleToButton(btnDangXuat, isDanger: true);
                btnDangXuat.Text = "🚪 Đăng xuất";
            }

            // Style menu buttons
            btnBanHang.Text = "🛒 Bán hàng";
            btnMonAn.Text = "🍔 Quản lý món";
            btnKhuVucBan.Text = "🪑 Khu vực bàn";
            btnNhanVien.Text = "👥 Nhân viên";
            btnHoaDon.Text = "🧾 Hóa đơn";
            btnKhuyenMai.Text = "🎁 Khuyến mãi";
            btnThongKe.Text = "📊 Thống kê";
            btnDoiMatKhau.Text = "🔑 Đổi mật khẩu";

            Button[] menuButtons = new Button[] { btnBanHang, btnMonAn, btnKhuVucBan, btnKho, btnNhanVien, btnHoaDon, btnKhuyenMai, btnThongKe, btnDoiMatKhau };
            foreach (Button b in menuButtons)
            {
                if (b == null) continue;
                b.FlatStyle = FlatStyle.Flat;
                b.FlatAppearance.BorderSize = 0;
                b.BackColor = UITheme.PrimaryDark;
                b.ForeColor = Color.FromArgb(226, 232, 240);
                b.Font = UITheme.FontHeader;
                b.Cursor = Cursors.Hand;
                b.TextAlign = ContentAlignment.MiddleLeft;
                b.Padding = new Padding(10, 0, 0, 0);

                // Hover effects
                b.MouseEnter += (s, ev) => {
                    if (activeMenuButton != b)
                    {
                        b.BackColor = Color.White;
                        b.ForeColor = UITheme.PrimaryAccent;
                    }
                };
                b.MouseLeave += (s, ev) => {
                    if (activeMenuButton != b)
                    {
                        b.BackColor = UITheme.PrimaryDark;
                        b.ForeColor = Color.FromArgb(226, 232, 240);
                    }
                };
            }

            if (btnDanhMuc != null) btnDanhMuc.Visible = false;

            // Set user header info
            lblXinChao.Text = $"Xin chào, {UserSession.HoTen}";
            lblVaiTro.Text = $"Vai trò: {UserSession.ChucVu}";

            // Role-based visibility and default view
            if (UserSession.IsAdmin)
            {
                btnBanHang.Visible = true;
                btnMonAn.Visible = true;
                btnKhuVucBan.Visible = true;
                btnKho.Visible = true;
                btnNhanVien.Visible = true;
                btnHoaDon.Visible = true;
                btnKhuyenMai.Visible = true;
                btnThongKe.Visible = true;
                btnDoiMatKhau.Visible = true;

                // Load Dashboard into pnlNoiDung for Admin on startup
                MoDashboardAdmin();
            }
            else
            {
                btnBanHang.Visible = true;
                btnDoiMatKhau.Visible = true;

                btnMonAn.Visible = false;
                btnKhuVucBan.Visible = false;
                btnKho.Visible = false;
                btnNhanVien.Visible = false;
                btnHoaDon.Visible = false;
                btnKhuyenMai.Visible = false;
                btnThongKe.Visible = false;

                // Load Welcome screen for Staff
                MoManHinhChaoNhanVien();
            }
        }

        public void HienThiNoiDung(Control control)
        {
            // Clear and dispose any previously embedded forms or temporary controls in pnlNoiDung
            while (pnlNoiDung.Controls.Count > 0)
            {
                Control oldCtrl = pnlNoiDung.Controls[0];
                pnlNoiDung.Controls.RemoveAt(0);

                if (oldCtrl is Form oldForm)
                {
                    oldForm.FormClosed -= OnEmbeddedFormClosed;
                    oldForm.Close();
                    oldForm.Dispose();
                }
                else if (oldCtrl != dashboardAdminControl && oldCtrl != staffWelcomeControl)
                {
                    oldCtrl.Dispose();
                }
            }

            // Bỏ Padding của pnlNoiDung để màn hình con tràn 100% diện tích chiều rộng & chiều cao
            pnlNoiDung.Padding = new Padding(0);

            if (control is Form frm)
            {
                frm.TopLevel = false;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.WindowState = FormWindowState.Normal;
                frm.Dock = DockStyle.Fill;
                frm.FormClosed += OnEmbeddedFormClosed;
                pnlNoiDung.Controls.Add(frm);
                pnlNoiDung.Tag = frm;
                frm.Show();
            }
            else
            {
                control.Dock = DockStyle.Fill;
                pnlNoiDung.Controls.Add(control);
                control.Show();
            }
        }

        private void SetActiveMenu(Button btn)
        {
            if (activeMenuButton != null)
            {
                // Reset previous active button
                activeMenuButton.BackColor = UITheme.PrimaryDark;
                activeMenuButton.Paint -= ActiveButton_Paint;
                activeMenuButton.Invalidate();
            }

            activeMenuButton = btn;
            if (activeMenuButton != null)
            {
                activeMenuButton.BackColor = Color.White;
                activeMenuButton.Paint += ActiveButton_Paint;
                activeMenuButton.Invalidate();
            }
        }

        private void ActiveButton_Paint(object sender, PaintEventArgs e)
        {
            if (sender is Button btn)
            {
                // Draw 4px Amber left accent bar
                using (SolidBrush brush = new SolidBrush(UITheme.PrimaryAccent))
                {
                    e.Graphics.FillRectangle(brush, 0, 0, 4, btn.Height);
                }
            }
        }

        private void OnEmbeddedFormClosed(object sender, FormClosedEventArgs e)
        {
            // If pnlNoiDung becomes empty after closing an embedded form, return to default view
            if (pnlNoiDung.Controls.Count == 0)
            {
                if (UserSession.IsAdmin)
                {
                    MoDashboardAdmin();
                }
                else
                {
                    MoManHinhChaoNhanVien();
                }
            }
        }

        public void CapNhatMenuDangChon(Button selectedButton)
        {
            if (selectedButton == null) return;

            Button[] menuButtons = new Button[] { btnBanHang, btnMonAn, btnKhuVucBan, btnKho, btnNhanVien, btnHoaDon, btnThongKe, btnDoiMatKhau };
            foreach (Button b in menuButtons)
            {
                if (b == null) continue;
                b.ForeColor = Color.FromArgb(226, 232, 240);
            }

            SetActiveMenu(selectedButton);
            
            // Highlight active text
            selectedButton.ForeColor = UITheme.PrimaryAccent; // Amber / Gold text
        }

        public void MoDashboardAdmin()
        {
            if (!UserSession.IsAdmin) return;

            CapNhatMenuDangChon(btnThongKe);

            if (dashboardAdminControl == null)
            {
                dashboardAdminControl = new DashboardAdminControl();
                dashboardAdminControl.MainForm = this;
            }

            HienThiNoiDung(dashboardAdminControl);
            dashboardAdminControl.LoadDashboard();
        }

        public void MoManHinhChaoNhanVien()
        {
            CapNhatMenuDangChon(btnBanHang);

            if (staffWelcomeControl == null)
            {
                staffWelcomeControl = new StaffWelcomeControl();
                staffWelcomeControl.MainForm = this;
            }

            HienThiNoiDung(staffWelcomeControl);
        }

        public void MoBanHang()
        {
            CapNhatMenuDangChon(btnBanHang);

            FrmBanHang frmBanHang = new FrmBanHang();
            HienThiNoiDung(frmBanHang);
        }

        public void MoLichSuHoaDon()
        {
            if (!KiemTraQuyenAdmin()) return;

            CapNhatMenuDangChon(btnHoaDon);

            FrmLichSuHoaDon frmLichSu = new FrmLichSuHoaDon();
            HienThiNoiDung(frmLichSu);
        }

        public void MoQuanLyMonAn()
        {
            if (!KiemTraQuyenAdmin()) return;

            CapNhatMenuDangChon(btnMonAn);

            FrmQuanLyMonAn frmMon = new FrmQuanLyMonAn(1);
            HienThiNoiDung(frmMon);
        }

        private bool KiemTraQuyenAdmin()
        {
            if (!UserSession.IsAdmin)
            {
                MessageBox.Show(
                    "Bạn không có quyền truy cập chức năng này.",
                    "Cảnh báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return false;
            }
            return true;
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
                Logout();
            }
        }

        public void Logout()
        {
            isLoggingOut = true;
            UserSession.Clear();
            this.Close();
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isLoggingOut)
            {
                UserSession.Clear();
                Application.Exit();
            }
        }

        private void btnBanHang_Click(object sender, EventArgs e)
        {
            MoBanHang();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            MoDashboardAdmin();
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            MoLichSuHoaDon();
        }

        private void btnKhuyenMai_Click(object sender, EventArgs e)
        {
            if (!KiemTraQuyenAdmin()) return;
            CapNhatMenuDangChon(btnKhuyenMai);
            lblTieuDeApp.Text = "QUẢN LÝ CHƯƠNG TRÌNH KHUYẾN MÃI";
            FrmQuanLyKhuyenMai frm = new FrmQuanLyKhuyenMai();
            HienThiNoiDung(frm);
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            CapNhatMenuDangChon(btnDoiMatKhau);

            FrmDoiMatKhau frmDoiMatKhau = new FrmDoiMatKhau();
            frmDoiMatKhau.FormClosed += (s, ev) =>
            {
                if (frmDoiMatKhau.DialogResult == DialogResult.OK)
                {
                    isLoggingOut = true;
                    this.Close();
                }
            };
            HienThiNoiDung(frmDoiMatKhau);
        }

        private void btnDanhMuc_Click(object sender, EventArgs e)
        {
            if (!KiemTraQuyenAdmin()) return;

            CapNhatMenuDangChon(btnDanhMuc);

            FrmQuanLyMonAn frmDanhMuc = new FrmQuanLyMonAn(0);
            HienThiNoiDung(frmDanhMuc);
        }

        private void btnMonAn_Click(object sender, EventArgs e)
        {
            MoQuanLyMonAn();
        }

        private void btnKhuVucBan_Click(object sender, EventArgs e)
        {
            if (!KiemTraQuyenAdmin()) return;

            CapNhatMenuDangChon(btnKhuVucBan);

            FrmQuanLyKhuVucBan frmKhuVuc = new FrmQuanLyKhuVucBan();
            HienThiNoiDung(frmKhuVuc);
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            MoQuanLyNhanVien();
        }

        public void MoQuanLyNhanVien()
        {
            if (!KiemTraQuyenAdmin()) return;

            CapNhatMenuDangChon(btnNhanVien);

            FrmQuanLyNhanVien frmNhanVien = new FrmQuanLyNhanVien();
            HienThiNoiDung(frmNhanVien);
        }

        private void btnKho_Click(object sender, EventArgs e)
        {
            if (!KiemTraQuyenAdmin()) return;

            CapNhatMenuDangChon(btnKho);
            FrmQuanLyKho frmKho = new FrmQuanLyKho();
            HienThiNoiDung(frmKho);
        }
    }
}
