using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using QLCF.Data;
using QLCF.Helpers;
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
            UITheme.ApplyStyleToForm(this);
            if (btnXacNhanThanhToan != null) UITheme.ApplyStyleToButton(btnXacNhanThanhToan, isSuccess: true);
            if (btnHuyThanhToan != null) UITheme.ApplyStyleToButton(btnHuyThanhToan, isDanger: false);

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
            decimal tienKhachDua = phuongThuc == "Tiền mặt" ? nudTienKhachDua.Value : tongCanThanhToan;
            decimal tienTraLai = phuongThuc == "Tiền mặt" ? Math.Max(0, tienKhachDua - tongCanThanhToan) : 0m;

            // Kiểm tra số tiền khách đưa nếu thanh toán tiền mặt
            if (phuongThuc == "Tiền mặt" && tienKhachDua < tongCanThanhToan)
            {
                MessageBox.Show(
                    "Số tiền khách đưa chưa đủ để thanh toán.",
                    "Số tiền không đủ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            // Lấy danh sách chi tiết món ăn từ CSDL
            List<ChiTietHoaDonModel> chiTietList = LayDanhSachChiTietHoaDon(_maHD);

            // Mở Form Xem trước Hóa đơn (Bill Preview) thay thế hoàn toàn MessageBox xác nhận
            using (FrmXemTruocBill frmBill = new FrmXemTruocBill(
                _maHD,
                _maBan,
                _tenBan,
                _tongTienGoc,
                giamGia,
                soTienGiam,
                tongCanThanhToan,
                phuongThuc,
                tienKhachDua,
                tienTraLai,
                UserSession.HoTen,
                chiTietList))
            {
                if (frmBill.ShowDialog(this) == DialogResult.OK)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private List<ChiTietHoaDonModel> LayDanhSachChiTietHoaDon(int maHD)
        {
            List<ChiTietHoaDonModel> list = new List<ChiTietHoaDonModel>();
            try
            {
                using (SqlConnection conn = Db.CreateConnection())
                {
                    string sql = @"
                        SELECT ct.MaCTHD, ct.MaHD, ct.MaMon, m.TenMon, ct.SoLuong, ct.DonGia, ct.ThanhTien, ct.GhiChu
                        FROM dbo.ChiTietHoaDon ct
                        JOIN dbo.MonAn m ON ct.MaMon = m.MaMon
                        WHERE ct.MaHD = @MaHD
                        ORDER BY ct.MaCTHD";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.Add("@MaHD", SqlDbType.Int).Value = maHD;
                        conn.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                list.Add(new ChiTietHoaDonModel
                                {
                                    MaCTHD = Convert.ToInt32(reader["MaCTHD"]),
                                    MaHD = Convert.ToInt32(reader["MaHD"]),
                                    MaMon = Convert.ToInt32(reader["MaMon"]),
                                    TenMon = reader["TenMon"].ToString(),
                                    SoLuong = Convert.ToInt32(reader["SoLuong"]),
                                    DonGia = Convert.ToDecimal(reader["DonGia"]),
                                    ThanhTien = Convert.ToDecimal(reader["ThanhTien"]),
                                    GhiChu = reader["GhiChu"] != DBNull.Value ? reader["GhiChu"].ToString() : ""
                                });
                            }
                        }
                    }
                }
            }
            catch { }
            return list;
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
