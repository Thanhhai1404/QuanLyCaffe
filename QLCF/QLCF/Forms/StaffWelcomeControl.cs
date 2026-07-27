using System;
using System.Windows.Forms;
using QLCF.Helpers;
using QLCF.Models;

namespace QLCF.Forms
{
    public partial class StaffWelcomeControl : UserControl
    {
        public FrmMain MainForm { get; set; }

        public StaffWelcomeControl()
        {
            InitializeComponent();

            this.Load += StaffWelcomeControl_Load;
            this.btnMoBanHang.Click += btnMoBanHang_Click;
        }

        private void StaffWelcomeControl_Load(object sender, EventArgs e)
        {
            UITheme.ApplyStyleToButton(btnMoBanHang, isPrimary: true);

            string hoTen = !string.IsNullOrEmpty(UserSession.HoTen) ? UserSession.HoTen : "Nhân viên";
            lblWelcomeTitle.Text = $"Chào {hoTen}!";
            lblWelcomeSub.Text = "Hãy chọn Bán hàng để bắt đầu phục vụ.";
        }

        private void btnMoBanHang_Click(object sender, EventArgs e)
        {
            if (MainForm != null)
            {
                MainForm.MoBanHang();
            }
        }
    }
}
