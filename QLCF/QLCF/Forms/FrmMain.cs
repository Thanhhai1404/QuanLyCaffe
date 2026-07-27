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
            this.btnNhanVien.Click += btnMenu_Click;
            this.btnHoaDon.Click += btnHoaDon_Click;
            this.btnThongKe.Click += btnThongKe_Click;
            this.btnDoiMatKhau.Click += btnDoiMatKhau_Click;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            UITheme.ApplyStyleToForm(this);

            if (pnlHeader != null) pnlHeader.BackColor = UITheme.HeaderDark;
            if (pnlMenu != null) pnlMenu.BackColor = UITheme.PrimaryDark;
            if (pnlLogo != null) pnlLogo.BackColor = Color.FromArgb(15, 23, 42);
            if (btnDangXuat != null) UITheme.ApplyStyleToButton(btnDangXuat, isDanger: true);

            // Style menu buttons
            Button[] menuButtons = new Button[] { btnBanHang, btnMonAn, btnDanhMuc, btnKhuVucBan, btnNhanVien, btnHoaDon, btnThongKe, btnDoiMatKhau };
            foreach (Button b in menuButtons)
            {
                if (b == null) continue;
                b.FlatStyle = FlatStyle.Flat;
                b.FlatAppearance.BorderSize = 0;
                b.BackColor = UITheme.PrimaryDark;
                b.ForeColor = Color.FromArgb(226, 232, 240);
                b.Font = UITheme.FontHeader;
                b.Cursor = Cursors.Hand;
            }

            // Set user header info
            lblXinChao.Text = $"Xin chào, {UserSession.HoTen}";
            lblVaiTro.Text = $"Vai trò: {UserSession.ChucVu}";

            // Role-based visibility and default view
            if (UserSession.IsAdmin)
            {
                btnBanHang.Visible = true;
                btnMonAn.Visible = true;
                btnDanhMuc.Visible = true;
                btnKhuVucBan.Visible = true;
                btnNhanVien.Visible = true;
                btnHoaDon.Visible = true;
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
                btnDanhMuc.Visible = false;
                btnKhuVucBan.Visible = false;
                btnNhanVien.Visible = false;
                btnHoaDon.Visible = false;
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

            if (control is Form frm)
            {
                frm.TopLevel = false;
                frm.FormBorderStyle = FormBorderStyle.None;
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

            Button[] menuButtons = new Button[] { btnBanHang, btnMonAn, btnDanhMuc, btnKhuVucBan, btnNhanVien, btnHoaDon, btnThongKe, btnDoiMatKhau };
            foreach (Button b in menuButtons)
            {
                if (b == null) continue;
                b.BackColor = UITheme.PrimaryDark;
                b.ForeColor = Color.FromArgb(226, 232, 240);
            }

            // Highlight active button
            selectedButton.BackColor = Color.FromArgb(15, 23, 42); // Darker Slate focus
            selectedButton.ForeColor = Color.FromArgb(245, 158, 11); // Amber / Gold text

            activeMenuButton = selectedButton;

            if (pnlActiveIndicator != null)
            {
                pnlActiveIndicator.Top = selectedButton.Top;
                pnlActiveIndicator.Height = selectedButton.Height;
                pnlActiveIndicator.Visible = true;
                pnlActiveIndicator.BringToFront();
            }
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
                isLoggingOut = true;
                UserSession.Clear();
                this.Close();
            }
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

        private void btnMenu_Click(object sender, EventArgs e)
        {
            if (!KiemTraQuyenAdmin()) return;

            CapNhatMenuDangChon(btnNhanVien);

            MessageBox.Show(
                "Chức năng này sẽ được xây dựng ở bước tiếp theo.",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }
    }
}
