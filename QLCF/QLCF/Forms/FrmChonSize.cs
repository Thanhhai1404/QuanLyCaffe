using System;
using System.Drawing;
using System.Windows.Forms;
using QLCF.Helpers;
using QLCF.Models;

namespace QLCF.Forms
{
    public partial class FrmChonSize : Form
    {
        private readonly MonAnModel _monAn;

        public string SelectedSize { get; private set; } = "Size S";
        public decimal SelectedGiaPhuThu { get; private set; } = 0;
        public decimal SelectedDonGiaCuoi => (_monAn != null ? _monAn.DonGia : 0) + SelectedGiaPhuThu;
        public int SelectedSoLuong => (int)nudSoLuong.Value;
        public string SelectedGhiChu => txtGhiChu.Text.Trim();

        public FrmChonSize(MonAnModel mon)
        {
            InitializeComponent();
            _monAn = mon;

            this.Load += FrmChonSize_Load;
            this.btnSizeS.Click += (s, e) => ChonSize("Size S", 0);
            this.btnSizeM.Click += (s, e) => ChonSize("Size M", 5000);
            this.btnSizeL.Click += (s, e) => ChonSize("Size L", 10000);
            this.nudSoLuong.ValueChanged += (s, e) => CapNhatTongTienHienThi();
            this.btnXacNhan.Click += BtnXacNhan_Click;
            this.btnHuy.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };
        }

        private void FrmChonSize_Load(object sender, EventArgs e)
        {
            UITheme.ApplyStyleToForm(this);
            if (btnXacNhan != null) UITheme.ApplyStyleToButton(btnXacNhan, isPrimary: true);

            if (_monAn != null)
            {
                lblTenMon.Text = _monAn.TenMon;
                lblGiaGoc.Text = $"Giá gốc (Size S): {_monAn.DonGia:#,##0} đ";
            }

            // Mặc định chọn Size S
            ChonSize("Size S", 0);
        }

        private void ChonSize(string sizeName, decimal giaPhuThu)
        {
            SelectedSize = sizeName;
            SelectedGiaPhuThu = giaPhuThu;

            // Reset style nút bấm
            ResetButtonStyle(btnSizeS);
            ResetButtonStyle(btnSizeM);
            ResetButtonStyle(btnSizeL);

            // Active style cho nút được chọn
            if (sizeName == "Size S") ActiveButtonStyle(btnSizeS);
            else if (sizeName == "Size M") ActiveButtonStyle(btnSizeM);
            else if (sizeName == "Size L") ActiveButtonStyle(btnSizeL);

            CapNhatTongTienHienThi();
        }

        private void ResetButtonStyle(Button btn)
        {
            btn.BackColor = Color.FromArgb(248, 250, 252); // Slate-50
            btn.ForeColor = Color.FromArgb(71, 85, 105); // Slate-600
            btn.FlatAppearance.BorderColor = Color.FromArgb(226, 232, 240);
            btn.FlatAppearance.BorderSize = 1;
        }

        private void ActiveButtonStyle(Button btn)
        {
            btn.BackColor = Color.FromArgb(254, 243, 199); // Amber-50
            btn.ForeColor = Color.FromArgb(180, 83, 9); // Amber-700
            btn.FlatAppearance.BorderColor = Color.FromArgb(217, 119, 6); // Amber-600
            btn.FlatAppearance.BorderSize = 2;
        }

        private void CapNhatTongTienHienThi()
        {
            decimal thanhTien = SelectedDonGiaCuoi * SelectedSoLuong;
            btnXacNhan.Text = $"Xác nhận thêm món ({thanhTien:#,##0} đ)";
        }

        private void BtnXacNhan_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
