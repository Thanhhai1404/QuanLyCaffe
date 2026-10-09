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
    public partial class FrmChiTietHoaDonModal : Form
    {
        private readonly int _maHD;
        private List<ChiTietHoaDonModel> _chiTietList = new List<ChiTietHoaDonModel>();

        private int _maBan = 0;
        private string _tenBan = "";
        private decimal _tongTienGoc = 0m;
        private int _giamGia = 0;
        private decimal _soTienGiam = 0m;
        private decimal _tongTienThanhToan = 0m;
        private string _phuongThuc = "Tiền mặt";
        private string _nguoiThanhToan = "";

        public FrmChiTietHoaDonModal(int maHD)
        {
            InitializeComponent();
            _maHD = maHD;

            this.Load += FrmChiTietHoaDonModal_Load;
            this.btnDong.Click += (s, e) => this.Close();
            this.btnInLaiBill.Click += BtnInLaiBill_Click;
        }

        private void FrmChiTietHoaDonModal_Load(object sender, EventArgs e)
        {
            UITheme.ApplyStyleToForm(this);
            if (btnInLaiBill != null) UITheme.ApplyStyleToButton(btnInLaiBill, isPrimary: true);
            if (btnDong != null) UITheme.ApplyStyleToButton(btnDong);

            TaiThongTinHoaDon();
        }

        private void TaiThongTinHoaDon()
        {
            try
            {
                using (SqlConnection conn = Db.CreateConnection())
                {
                    conn.Open();

                    // 1. Tải thông tin chung từ view vw_LichSuHoaDon
                    bool hasMaBan = false;
                    try
                    {
                        using (SqlCommand cmdCheck = new SqlCommand("SELECT COUNT(*) FROM sys.columns WHERE object_id = OBJECT_ID('dbo.vw_LichSuHoaDon') AND name = 'MaBan'", conn))
                        {
                            object res = cmdCheck.ExecuteScalar();
                            hasMaBan = res != null && Convert.ToInt32(res) > 0;
                        }
                    }
                    catch { }

                    string colMaBan = hasMaBan ? "v.MaBan" : "(SELECT h.MaBan FROM dbo.HoaDon h WHERE h.MaHD = v.MaHD) AS MaBan";

                    string sqlHeader = $@"
                        SELECT v.MaHD, {colMaBan}, v.TenBan, v.TenKhuVuc, v.GioVao, v.GioRa, v.NguoiMo, v.NguoiThanhToan,
                               v.TongTienGoc, v.GiamGia, v.TongTien, v.PhuongThucThanhToan, v.TrangThai, v.LyDoHuy
                        FROM dbo.vw_LichSuHoaDon v
                        WHERE v.MaHD = @MaHD";

                    using (SqlCommand cmdHeader = new SqlCommand(sqlHeader, conn))
                    {
                        cmdHeader.Parameters.Add("@MaHD", SqlDbType.Int).Value = _maHD;
                        using (SqlDataReader reader = cmdHeader.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                _tenBan = reader["TenBan"] != DBNull.Value ? reader["TenBan"].ToString() : "";
                                string tenKhuVuc = reader["TenKhuVuc"] != DBNull.Value ? reader["TenKhuVuc"].ToString() : "";
                                if (reader["MaBan"] != DBNull.Value) _maBan = Convert.ToInt32(reader["MaBan"]);

                                lblMaHDTitle.Text = $"CHI TIẾT HÓA ĐƠN #HD{_maHD:D5}";
                                lblBanKhuVucValue.Text = $"Bàn: {_tenBan} - Khu vực: {tenKhuVuc}";

                                string nguoiMo = reader["NguoiMo"] != DBNull.Value ? reader["NguoiMo"].ToString() : "--";
                                _nguoiThanhToan = reader["NguoiThanhToan"] != DBNull.Value ? reader["NguoiThanhToan"].ToString() : "--";
                                lblThuNganValue.Text = $"Mở bàn: {nguoiMo} | Thanh toán: {_nguoiThanhToan}";

                                string gioVaoStr = reader["GioVao"] != DBNull.Value ? Convert.ToDateTime(reader["GioVao"]).ToString("dd/MM/yyyy HH:mm") : "--";
                                string gioRaStr = reader["GioRa"] != DBNull.Value ? Convert.ToDateTime(reader["GioRa"]).ToString("dd/MM/yyyy HH:mm") : "--";
                                lblThoiGianValue.Text = $"Giờ vào: {gioVaoStr}  -  Giờ ra: {gioRaStr}";

                                _phuongThuc = reader["PhuongThucThanhToan"] != DBNull.Value ? reader["PhuongThucThanhToan"].ToString() : "Tiền mặt";
                                int trangThai = reader["TrangThai"] != DBNull.Value ? Convert.ToInt32(reader["TrangThai"]) : 0;

                                string trangThaiText = "Chưa thanh toán";
                                if (trangThai == 1) trangThaiText = "Đã thanh toán";
                                else if (trangThai == 2) trangThaiText = "Đã hủy";

                                lblTrangThaiValue.Text = $"Trạng thái: {trangThaiText} | PTTT: {_phuongThuc}";

                                string lyDoHuy = reader["LyDoHuy"] != DBNull.Value ? reader["LyDoHuy"].ToString() : "";
                                if (!string.IsNullOrWhiteSpace(lyDoHuy))
                                {
                                    lblLyDoHuy.Text = "Lý do hủy: " + lyDoHuy;
                                    lblLyDoHuy.Visible = true;
                                }

                                _tongTienGoc = reader["TongTienGoc"] != DBNull.Value ? Convert.ToDecimal(reader["TongTienGoc"]) : 0m;
                                _giamGia = reader["GiamGia"] != DBNull.Value ? Convert.ToInt32(reader["GiamGia"]) : 0;
                                _soTienGiam = _tongTienGoc * _giamGia / 100m;
                                _tongTienThanhToan = reader["TongTien"] != DBNull.Value ? Convert.ToDecimal(reader["TongTien"]) : (_tongTienGoc - _soTienGiam);

                                lblTongTienGocVal.Text = _tongTienGoc.ToString("N0") + " đ";
                                lblGiamGiaVal.Text = $"{_giamGia}% (-{_soTienGiam:N0} đ)";
                                lblTongThanhToanVal.Text = _tongTienThanhToan.ToString("N0") + " đ";
                            }
                        }
                    }

                    // 2. Tải danh sách chi tiết món từ dbo.ChiTietHoaDon
                    bool hasTenSize = false;
                    bool hasThanhTien = false;
                    try
                    {
                        using (SqlCommand cmdCheck = new SqlCommand("SELECT COUNT(*) FROM sys.columns WHERE object_id = OBJECT_ID('dbo.ChiTietHoaDon') AND name = 'TenSize'", conn))
                        {
                            object res = cmdCheck.ExecuteScalar();
                            hasTenSize = res != null && Convert.ToInt32(res) > 0;
                        }
                        using (SqlCommand cmdCheck = new SqlCommand("SELECT COUNT(*) FROM sys.columns WHERE object_id = OBJECT_ID('dbo.ChiTietHoaDon') AND name = 'ThanhTien'", conn))
                        {
                            object res = cmdCheck.ExecuteScalar();
                            hasThanhTien = res != null && Convert.ToInt32(res) > 0;
                        }
                    }
                    catch { }

                    string colTenSize = hasTenSize ? "ISNULL(ct.TenSize, '') AS TenSize" : "'' AS TenSize";
                    string colThanhTien = hasThanhTien ? "ISNULL(ct.ThanhTien, ct.SoLuong * ct.DonGia) AS ThanhTien" : "(ct.SoLuong * ct.DonGia) AS ThanhTien";

                    string sqlItems = $@"
                        SELECT ct.MaCTHD, ct.MaHD, ct.MaMon, m.TenMon, 
                               {colTenSize},
                               ct.SoLuong, ct.DonGia, {colThanhTien}, ct.GhiChu
                        FROM dbo.ChiTietHoaDon ct
                        JOIN dbo.MonAn m ON ct.MaMon = m.MaMon
                        WHERE ct.MaHD = @MaHD
                        ORDER BY ct.MaCTHD";

                    _chiTietList.Clear();
                    using (SqlCommand cmdItems = new SqlCommand(sqlItems, conn))
                    {
                        cmdItems.Parameters.Add("@MaHD", SqlDbType.Int).Value = _maHD;
                        using (SqlDataReader reader = cmdItems.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                _chiTietList.Add(new ChiTietHoaDonModel
                                {
                                    MaCTHD = Convert.ToInt32(reader["MaCTHD"]),
                                    MaHD = Convert.ToInt32(reader["MaHD"]),
                                    MaMon = Convert.ToInt32(reader["MaMon"]),
                                    TenMon = reader["TenMon"].ToString(),
                                    TenSize = reader["TenSize"] != DBNull.Value ? reader["TenSize"].ToString() : "",
                                    SoLuong = Convert.ToInt32(reader["SoLuong"]),
                                    DonGia = Convert.ToDecimal(reader["DonGia"]),
                                    ThanhTien = Convert.ToDecimal(reader["ThanhTien"]),
                                    GhiChu = reader["GhiChu"] != DBNull.Value ? reader["GhiChu"].ToString() : ""
                                });
                            }
                        }
                    }

                    // 3. Bind dữ liệu vào DataGridView
                    dgvChiTiet.AutoGenerateColumns = false;
                    dgvChiTiet.DataSource = _chiTietList;

                    if (dgvChiTiet.Columns["colDonGia"] != null)
                    {
                        dgvChiTiet.Columns["colDonGia"].DefaultCellStyle.Format = "#,##0";
                        dgvChiTiet.Columns["colDonGia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    }
                    if (dgvChiTiet.Columns["colThanhTien"] != null)
                    {
                        dgvChiTiet.Columns["colThanhTien"].DefaultCellStyle.Format = "#,##0";
                        dgvChiTiet.Columns["colThanhTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    }

                    // Điền cột STT
                    for (int i = 0; i < dgvChiTiet.Rows.Count; i++)
                    {
                        dgvChiTiet.Rows[i].Cells["colStt"].Value = (i + 1).ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải chi tiết hóa đơn.\n\nChi tiết: " + ex.Message,
                    "Lỗi cơ sở dữ liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void BtnInLaiBill_Click(object sender, EventArgs e)
        {
            if (_chiTietList == null || _chiTietList.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu chi tiết món ăn để in bill.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (FrmXemTruocBill frmBill = new FrmXemTruocBill(
                _maHD,
                _maBan,
                _tenBan,
                _tongTienGoc,
                _giamGia,
                _soTienGiam,
                _tongTienThanhToan,
                _phuongThuc,
                _tongTienThanhToan,
                0m,
                _nguoiThanhToan,
                "", // maKhuyenMai
                _chiTietList))
            {
                frmBill.ShowDialog(this);
            }
        }
    }
}
