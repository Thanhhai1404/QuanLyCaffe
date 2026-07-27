using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using QLCF.Data;
using QLCF.Models;

namespace QLCF.Forms
{
    public partial class FrmXemTruocBill : Form
    {
        private readonly int _maHD;
        private readonly int _maBan;
        private readonly string _tenBan;
        private readonly decimal _tongTienGoc;
        private readonly int _giamGiaPercent;
        private readonly decimal _soTienGiam;
        private readonly decimal _tongCanThanhToan;
        private readonly string _phuongThuc;
        private readonly decimal _tienKhachDua;
        private readonly decimal _tienTraLai;
        private readonly string _tenThuNgan;
        private readonly List<ChiTietHoaDonModel> _chiTietList;

        public FrmXemTruocBill(
            int maHD,
            int maBan,
            string tenBan,
            decimal tongTienGoc,
            int giamGiaPercent,
            decimal soTienGiam,
            decimal tongCanThanhToan,
            string phuongThuc,
            decimal tienKhachDua,
            decimal tienTraLai,
            string tenThuNgan,
            List<ChiTietHoaDonModel> chiTietList)
        {
            InitializeComponent();

            _maHD = maHD;
            _maBan = maBan;
            _tenBan = tenBan;
            _tongTienGoc = tongTienGoc;
            _giamGiaPercent = giamGiaPercent;
            _soTienGiam = soTienGiam;
            _tongCanThanhToan = tongCanThanhToan;
            _phuongThuc = phuongThuc;
            _tienKhachDua = tienKhachDua;
            _tienTraLai = tienTraLai;
            _tenThuNgan = string.IsNullOrWhiteSpace(tenThuNgan) ? "Thu ngân" : tenThuNgan;
            _chiTietList = chiTietList ?? new List<ChiTietHoaDonModel>();

            this.Load += FrmXemTruocBill_Load;
            this.btnXuatBillHoanTat.Click += BtnXuatBillHoanTat_Click;
            this.btnQuayLai.Click += BtnQuayLai_Click;
        }

        private void FrmXemTruocBill_Load(object sender, EventArgs e)
        {
            // Tinh chỉnh chiều cao Form (Tối đa 650px hoặc 85% chiều cao làm việc của màn hình)
            int maxHeight = Math.Min(650, (int)(Screen.PrimaryScreen.WorkingArea.Height * 0.85));
            this.Height = maxHeight;
            this.StartPosition = FormStartPosition.CenterParent;

            lblMaHD.Text = $"Mã HD: #HD{_maHD:D5}";
            lblNgayGio.Text = $"Ngày: {DateTime.Now:dd/MM/yyyy HH:mm:ss}";
            lblTenBan.Text = $"Bàn: {(!string.IsNullOrEmpty(_tenBan) ? _tenBan : "Mang về")}";
            lblThuNgan.Text = $"Thu ngân: {_tenThuNgan}";

            // Bind danh sách món ăn
            dgvMonAn.AutoGenerateColumns = false;
            dgvMonAn.DataSource = _chiTietList;

            // Tính chiều cao động cho Grid danh sách món ăn
            int rowHeight = dgvMonAn.RowTemplate.Height > 0 ? dgvMonAn.RowTemplate.Height : 24;
            int totalGridHeight = dgvMonAn.ColumnHeadersHeight + (_chiTietList.Count * rowHeight) + 6;
            dgvMonAn.Height = Math.Max(60, totalGridHeight);

            // Bind tổng kết tiền
            lblTongTienGocVal.Text = DinhDangTien(_tongTienGoc);
            lblSoTienGiamVal.Text = $"-{DinhDangTien(_soTienGiam)} ({_giamGiaPercent}%)";
            lblTongCanThanhToanVal.Text = DinhDangTien(_tongCanThanhToan);
            lblPhuongThucVal.Text = _phuongThuc;
            lblTienKhachDuaVal.Text = DinhDangTien(_tienKhachDua);
            lblTienTraLaiVal.Text = DinhDangTien(_tienTraLai);

            // Kích hoạt tính năng cuộn chuột mượt mà và căn giữa tờ bill
            CenterPaperCard();
            pnlMainScroll.Resize += (s, ev) => CenterPaperCard();
            pnlMainScroll.Focus();
            AttachMouseWheelScroll(pnlPaper);
        }

        private void CenterPaperCard()
        {
            if (pnlPaper != null && pnlMainScroll != null)
            {
                int leftMargin = Math.Max(10, (pnlMainScroll.ClientSize.Width - pnlPaper.Width) / 2);
                pnlPaper.Left = leftMargin;
            }
        }

        private void AttachMouseWheelScroll(Control container)
        {
            if (container == null) return;

            foreach (Control c in container.Controls)
            {
                c.MouseWheel += (s, e) =>
                {
                    if (pnlMainScroll.VerticalScroll.Visible)
                    {
                        int step = e.Delta > 0 ? -50 : 50;
                        int newPos = pnlMainScroll.VerticalScroll.Value + step;
                        newPos = Math.Max(pnlMainScroll.VerticalScroll.Minimum, Math.Min(pnlMainScroll.VerticalScroll.Maximum, newPos));
                        pnlMainScroll.VerticalScroll.Value = newPos;
                    }
                };

                if (c.HasChildren)
                {
                    AttachMouseWheelScroll(c);
                }
            }
        }

        private void BtnXuatBillHoanTat_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = Db.CreateConnection())
                {
                    conn.Open();
                    try
                    {
                        using (SqlCommand cmd = new SqlCommand("sp_ThanhToan", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.Add("@MaHD", SqlDbType.Int).Value = _maHD;
                            cmd.Parameters.Add("@MaNVThanhToan", SqlDbType.Int).Value = UserSession.MaNV;
                            cmd.Parameters.Add("@GiamGia", SqlDbType.Int).Value = _giamGiaPercent;
                            cmd.Parameters.Add("@PhuongThucThanhToan", SqlDbType.NVarChar, 50).Value = _phuongThuc;
                            cmd.Parameters.Add("@TienKhachDua", SqlDbType.Decimal).Value = (object)_tienKhachDua ?? DBNull.Value;

                            cmd.ExecuteNonQuery();
                        }
                    }
                    catch (SqlException ex) when (ex.Number == 2812) // Fallback nếu DB chưa cài Stored Procedure
                    {
                        using (SqlTransaction tran = conn.BeginTransaction())
                        {
                            string sqlHoaDon = @"UPDATE dbo.HoaDon 
                                SET TrangThai = 1, 
                                    NgayThanhToan = GETDATE(), 
                                    TongTienGoc = @TongTienGoc, 
                                    PhanTramGiamGia = @GiamGia, 
                                    SoTienGiam = @SoTienGiam, 
                                    TongTienThanhToan = @TongTienThanhToan, 
                                    PhuongThucThanhToan = @PhuongThucThanhToan, 
                                    TienKhachDua = @TienKhachDua, 
                                    TienTraLai = @TienTraLai,
                                    MaNVThanhToan = @MaNV 
                                WHERE MaHD = @MaHD";

                            using (SqlCommand cmdHD = new SqlCommand(sqlHoaDon, conn, tran))
                            {
                                cmdHD.Parameters.Add("@TongTienGoc", SqlDbType.Decimal).Value = _tongTienGoc;
                                cmdHD.Parameters.Add("@GiamGia", SqlDbType.Int).Value = _giamGiaPercent;
                                cmdHD.Parameters.Add("@SoTienGiam", SqlDbType.Decimal).Value = _soTienGiam;
                                cmdHD.Parameters.Add("@TongTienThanhToan", SqlDbType.Decimal).Value = _tongCanThanhToan;
                                cmdHD.Parameters.Add("@PhuongThucThanhToan", SqlDbType.NVarChar, 50).Value = _phuongThuc;
                                cmdHD.Parameters.Add("@TienKhachDua", SqlDbType.Decimal).Value = _tienKhachDua;
                                cmdHD.Parameters.Add("@TienTraLai", SqlDbType.Decimal).Value = _tienTraLai;
                                cmdHD.Parameters.Add("@MaNV", SqlDbType.Int).Value = UserSession.MaNV;
                                cmdHD.Parameters.Add("@MaHD", SqlDbType.Int).Value = _maHD;
                                cmdHD.ExecuteNonQuery();
                            }

                            string sqlBan = @"UPDATE dbo.Ban 
                                SET DangSuDung = 0, 
                                    TrangThai = N'Trống' 
                                WHERE MaBan = @MaBan";

                            using (SqlCommand cmdBan = new SqlCommand(sqlBan, conn, tran))
                            {
                                cmdBan.Parameters.Add("@MaBan", SqlDbType.Int).Value = _maBan;
                                cmdBan.ExecuteNonQuery();
                            }

                            tran.Commit();
                        }
                    }
                }

                MessageBox.Show(
                    "Thanh toán thành công và đã lưu hóa đơn vào hệ thống!",
                    "Thông báo thanh toán",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

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

        private void BtnQuayLai_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private string DinhDangTien(decimal amount)
        {
            return string.Format("{0:#,##0} đ", amount);
        }
    }
}
