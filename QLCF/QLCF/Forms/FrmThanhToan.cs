using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using QLCF.Data;
using QLCF.Models;

namespace QLCF.Forms
{
    public partial class FrmThanhToan : Form
    {
        private readonly int _maHD;
        private readonly int _maBan;
        private readonly string _tenBan;
        private readonly decimal _tongTienGoc;

        public FrmThanhToan(int maHD, int maBan, string tenBan, decimal tongTienGoc)
        {
            InitializeComponent();

            _maHD = maHD;
            _maBan = maBan;
            _tenBan = tenBan;
            _tongTienGoc = tongTienGoc;

            this.Load += FrmThanhToan_Load;
            this.nudGiamGia.ValueChanged += (s, e) => TinhToanThanhToan();
            this.cboPhuongThucThanhToan.SelectedIndexChanged += (s, e) => TinhToanThanhToan();
            this.nudTienKhachDua.ValueChanged += (s, e) => TinhToanThanhToan();

            this.btnXacNhanThanhToan.Click += btnXacNhanThanhToan_Click;
            this.btnHuyThanhToan.Click += btnHuyThanhToan_Click;
        }

        private void FrmThanhToan_Load(object sender, EventArgs e)
        {
            // Hiển thị thông tin cơ bản
            lblMaHDInfo.Text = "Mã hóa đơn: HD" + _maHD.ToString("D5");
            lblTenBanInfo.Text = "Bàn: " + _tenBan;
            lblTongTienGocVal.Text = DinhDangTien(_tongTienGoc);

            // Cấu hình giảm giá tối đa theo phân quyền
            if (UserSession.IsAdmin)
            {
                nudGiamGia.Maximum = 100;
            }
            else
            {
                nudGiamGia.Maximum = 10;
            }
            nudGiamGia.Value = 0;

            // Load danh sách phương thức thanh toán
            cboPhuongThucThanhToan.Items.Clear();
            cboPhuongThucThanhToan.Items.Add("Tiền mặt");
            cboPhuongThucThanhToan.Items.Add("Chuyển khoản");
            cboPhuongThucThanhToan.Items.Add("QR");
            cboPhuongThucThanhToan.Items.Add("Thẻ");
            cboPhuongThucThanhToan.SelectedIndex = 0; // Mặc định là Tiền mặt

            // Mặc định tiền khách đưa bằng tổng tiền gốc
            nudTienKhachDua.Value = Math.Max(0, _tongTienGoc);

            TinhToanThanhToan();
        }

        private void TinhToanThanhToan()
        {
            int giamGia = (int)nudGiamGia.Value;
            decimal soTienGiam = _tongTienGoc * giamGia / 100m;
            decimal tongCanThanhToan = Math.Max(0, _tongTienGoc - soTienGiam);

            lblSoTienGiamVal.Text = DinhDangTien(soTienGiam);
            lblTongCanThanhToanVal.Text = DinhDangTien(tongCanThanhToan);

            string phuongThuc = cboPhuongThucThanhToan.SelectedItem != null ? cboPhuongThucThanhToan.SelectedItem.ToString() : "Tiền mặt";

            if (phuongThuc == "Tiền mặt")
            {
                nudTienKhachDua.Enabled = true;
                decimal tienKhachDua = nudTienKhachDua.Value;
                decimal tienThua = tienKhachDua - tongCanThanhToan;

                if (tienThua >= 0)
                {
                    lblTienThuaLabel.Text = "Tiền trả lại:";
                    lblTienThuaVal.Text = DinhDangTien(tienThua);
                    lblTienThuaVal.ForeColor = Color.FromArgb(39, 174, 96);
                }
                else
                {
                    lblTienThuaLabel.Text = "Còn thiếu:";
                    lblTienThuaVal.Text = DinhDangTien(-tienThua);
                    lblTienThuaVal.ForeColor = Color.FromArgb(231, 76, 60);
                }
            }
            else
            {
                // Chuyển khoản, QR, Thẻ -> Không nhập tiền khách đưa
                nudTienKhachDua.Enabled = false;
                nudTienKhachDua.Value = tongCanThanhToan;
                lblTienThuaLabel.Text = "Tiền trả lại:";
                lblTienThuaVal.Text = "0 đ";
                lblTienThuaVal.ForeColor = Color.FromArgb(44, 62, 80);
            }
        }

        private void btnXacNhanThanhToan_Click(object sender, EventArgs e)
        {
            int giamGia = (int)nudGiamGia.Value;
            decimal soTienGiam = _tongTienGoc * giamGia / 100m;
            decimal tongCanThanhToan = Math.Max(0, _tongTienGoc - soTienGiam);

            string phuongThuc = cboPhuongThucThanhToan.SelectedItem != null ? cboPhuongThucThanhToan.SelectedItem.ToString() : "Tiền mặt";

            // Kiểm tra số tiền khách đưa nếu thanh toán tiền mặt
            if (phuongThuc == "Tiền mặt")
            {
                if (nudTienKhachDua.Value < tongCanThanhToan)
                {
                    MessageBox.Show(
                        "Số tiền khách đưa chưa đủ để thanh toán.",
                        "Số tiền không đủ",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }
            }

            // Hộp thoại xác nhận
            DialogResult confirm = MessageBox.Show(
                $"Xác nhận thanh toán hóa đơn #{_maHD} với tổng tiền {DinhDangTien(tongCanThanhToan)}?",
                "Xác nhận thanh toán",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm != DialogResult.Yes)
            {
                return;
            }

            try
            {
                using (SqlConnection conn = Db.CreateConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("sp_ThanhToan", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@MaHD", SqlDbType.Int).Value = _maHD;
                        cmd.Parameters.Add("@MaNVThanhToan", SqlDbType.Int).Value = UserSession.MaNV;
                        cmd.Parameters.Add("@GiamGia", SqlDbType.Int).Value = giamGia;
                        cmd.Parameters.Add("@PhuongThucThanhToan", SqlDbType.NVarChar, 20).Value = phuongThuc;

                        if (phuongThuc == "Tiền mặt")
                        {
                            cmd.Parameters.Add("@TienKhachDua", SqlDbType.Decimal).Value = nudTienKhachDua.Value;
                        }
                        else
                        {
                            cmd.Parameters.Add("@TienKhachDua", SqlDbType.Decimal).Value = DBNull.Value;
                        }

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Thanh toán thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Thanh toán thất bại.\n\nChi tiết lỗi: " + ex.Message,
                    "Lỗi cơ sở dữ liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnHuyThanhToan_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private string DinhDangTien(decimal soTien)
        {
            return soTien.ToString("N0") + " đ";
        }
    }
}
