using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using QLCF.Helpers;
using QLCF.Models;

namespace QLCF.Forms
{
    public partial class FrmChotSoCa : Form
    {
        private int _shiftId;
        private DateTime _checkInTime;
        private decimal _doanhThuTienMat = 0;
        private decimal _doanhThuChuyenKhoan = 0;
        private decimal _tongDoanhThu = 0;

        public bool IsReconciliationSuccess { get; private set; } = false;

        public FrmChotSoCa(int shiftId, DateTime checkInTime)
        {
            InitializeComponent();
            _shiftId = shiftId;
            _checkInTime = checkInTime;

            this.Load += FrmChotSoCa_Load;
            
            // Text change events
            this.txtTienDauCa.TextChanged += CalculateDifference;
            this.txtTienThucTe.TextChanged += CalculateDifference;

            // Prevent non-numeric input
            this.txtTienDauCa.KeyPress += PreventNonNumeric;
            this.txtTienThucTe.KeyPress += PreventNonNumeric;

            // Buttons
            this.btnXacNhan.Click += BtnXacNhan_Click;
            this.btnXuatExcel.Click += BtnXuatExcel_Click;
            this.btnInBaoCao.Click += BtnInBaoCao_Click;
        }

        private void FrmChotSoCa_Load(object sender, EventArgs e)
        {
            LoadShiftData();
        }

        private void LoadShiftData()
        {
            try
            {
                // Set Info Label
                TimeSpan duration = DateTime.Now - _checkInTime;
                string durationText = $"{(int)duration.TotalHours} giờ {duration.Minutes} phút";
                lblInfo.Text = $"Nhân viên: {UserSession.HoTen} | Mã Ca: {_shiftId}\n" +
                               $"Vào ca: {_checkInTime:HH:mm dd/MM} ➔ Kết ca: {DateTime.Now:HH:mm dd/MM} ({durationText})";

                // Fetch Financial Summary
                var summary = ShiftService.GetShiftFinancialSummary(UserSession.MaNV, _checkInTime);
                _tongDoanhThu = summary.TongDoanhThu;
                _doanhThuTienMat = summary.TienMat;
                _doanhThuChuyenKhoan = summary.ChuyenKhoan;

                // Update Labels
                lblTongDoanhThu.Text = _tongDoanhThu.ToString("N0") + " đ";
                lblDoanhThuTienMat.Text = _doanhThuTienMat.ToString("N0") + " đ";
                lblDoanhThuChuyenKhoan.Text = _doanhThuChuyenKhoan.ToString("N0") + " đ";

                // Update Form
                txtDoanhThuMat2.Text = _doanhThuTienMat.ToString("N0");
                
                CalculateDifference(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu ca làm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalculateDifference(object sender, EventArgs e)
        {
            decimal tienDauCa = decimal.TryParse(txtTienDauCa.Text, out decimal d) ? d : 0;
            decimal doanhThuTienMat = _doanhThuTienMat;
            decimal tienThucTe = decimal.TryParse(txtTienThucTe.Text, out decimal t) ? t : 0;

            decimal tienLyThuyet = tienDauCa + doanhThuTienMat;
            decimal chenhLech = tienThucTe - tienLyThuyet;

            txtTienLyThuyet.Text = tienLyThuyet.ToString("N0");
            txtChenhLech.Text = chenhLech.ToString("N0");

            if (chenhLech < 0)
            {
                txtChenhLech.ForeColor = Color.Red;
            }
            else if (chenhLech > 0)
            {
                txtChenhLech.ForeColor = Color.Green;
            }
            else
            {
                txtChenhLech.ForeColor = Color.Black;
            }
        }

        private void PreventNonNumeric(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void BtnXacNhan_Click(object sender, EventArgs e)
        {
            decimal tienDauCa = 0;
            decimal tienThucTe = 0;

            decimal.TryParse(txtTienDauCa.Text, out tienDauCa);
            decimal.TryParse(txtTienThucTe.Text, out tienThucTe);

            decimal tienLyThuyet = tienDauCa + _doanhThuTienMat;
            decimal chenhLech = tienThucTe - tienLyThuyet;

            if (MessageBox.Show("Bạn có chắc chắn muốn chốt ca và đăng xuất?", "Xác nhận kết ca", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                bool success = ShiftService.FinalizeShiftReconciliation(
                    _shiftId, 
                    tienDauCa, 
                    _doanhThuTienMat, 
                    _doanhThuChuyenKhoan, 
                    _tongDoanhThu, 
                    tienThucTe, 
                    chenhLech, 
                    out _);

                if (success)
                {
                    IsReconciliationSuccess = true;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra khi cập nhật ca làm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnXuatExcel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tính năng Xuất Excel ca làm sẽ được cập nhật trong phiên bản sau.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnInBaoCao_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tính năng In Báo Cáo ca làm sẽ được cập nhật trong phiên bản sau.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
