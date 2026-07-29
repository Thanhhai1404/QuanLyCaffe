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
            
            // Chuẩn hóa phương thức thanh toán hợp lệ với CSDL (Chỉ chấp nhận 'Tiền mặt' hoặc 'Chuyển khoản')
            if (!string.IsNullOrWhiteSpace(phuongThuc) && phuongThuc.IndexOf("Chuyển khoản", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                _phuongThuc = "Chuyển khoản";
            }
            else
            {
                _phuongThuc = "Tiền mặt";
            }

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
            this.StartPosition = FormStartPosition.CenterParent;

            if (pnlPaper != null) pnlPaper.Padding = new Padding(14, 14, 14, 40);
            if (pnlMainScroll != null) pnlMainScroll.Padding = new Padding(15, 15, 15, 40);

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

            // Tắt AutoSize để tự quản lý chiều cao
            pnlPaper.AutoSize = false;

            // Bind tổng kết tiền
            lblTongTienGocVal.Text = DinhDangTien(_tongTienGoc);
            lblSoTienGiamVal.Text = $"-{DinhDangTien(_soTienGiam)} ({_giamGiaPercent}%)";
            lblTongCanThanhToanVal.Text = DinhDangTien(_tongCanThanhToan);
            lblPhuongThucVal.Text = _phuongThuc;
            lblTienKhachDuaVal.Text = DinhDangTien(_tienKhachDua);
            lblTienTraLaiVal.Text = DinhDangTien(_tienTraLai);

            // Dùng sự kiện Shown để tính chiều cao SAU KHI WinForms layout xong
            this.Shown += FrmXemTruocBill_Shown;

            // Gắn cuộn chuột vào Form và pnlMainScroll
            this.MouseWheel += OnFormMouseWheel;
            pnlMainScroll.MouseWheel += OnFormMouseWheel;
        }

        private void FrmXemTruocBill_Shown(object sender, EventArgs e)
        {
            // Tính chiều cao thực tế của pnlPaper sau khi WinForms đã layout xong
            // Cách đúng: lấy Bottom của control thấp nhất trong pnlPaper
            int maxBottom = 0;
            foreach (Control c in pnlPaper.Controls)
            {
                if (c.Visible && c.Bottom > maxBottom)
                    maxBottom = c.Bottom;
            }
            int paperHeight = maxBottom + pnlPaper.Padding.Bottom;
            pnlPaper.Height = Math.Max(paperHeight, 500);

            // Tính chiều cao lý tưởng của Form (tối đa 85% màn hình)
            int ideal = pnlHeader.Height + pnlMainScroll.Padding.Top + pnlPaper.Height + pnlMainScroll.Padding.Bottom + pnlBottom.Height;
            int maxH = (int)(Screen.PrimaryScreen.WorkingArea.Height * 0.85);
            this.ClientSize = new System.Drawing.Size(this.ClientSize.Width, Math.Min(ideal, maxH));

            CenterPaperCard();
            pnlMainScroll.Resize += (s, ev) => CenterPaperCard();
            pnlMainScroll.Focus();
        }

        private void OnFormMouseWheel(object sender, MouseEventArgs e)
        {
            if (pnlMainScroll == null) return;
            int step = e.Delta > 0 ? -80 : 80;
            int newPos = Math.Abs(pnlMainScroll.AutoScrollPosition.Y) + step;
            if (newPos < 0) newPos = 0;
            int max = pnlMainScroll.VerticalScroll.Maximum - pnlMainScroll.ClientSize.Height + pnlMainScroll.Padding.Bottom;
            if (max < 0) max = 0;
            if (newPos > max) newPos = max;
            pnlMainScroll.AutoScrollPosition = new System.Drawing.Point(0, newPos);
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
                        // Cách cuộn chuột chuẩn nhất trong WinForms (không dùng VerticalScroll.Value)
                        int step = e.Delta > 0 ? -50 : 50;
                        int currentPos = Math.Abs(pnlMainScroll.AutoScrollPosition.Y);
                        int newPos = currentPos + step;
                        
                        // Đảm bảo không cuộn quá giới hạn trên và dưới
                        if (newPos < 0) newPos = 0;
                        
                        // Tính toán giới hạn cuộn dưới
                        int maxScroll = pnlMainScroll.VerticalScroll.Maximum - pnlMainScroll.ClientSize.Height;
                        if (maxScroll < 0) maxScroll = 0;
                        if (newPos > maxScroll) newPos = maxScroll;

                        pnlMainScroll.AutoScrollPosition = new System.Drawing.Point(0, newPos);
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
                string phuongThucChuan = (_phuongThuc != null && _phuongThuc.IndexOf("Chuyển khoản", StringComparison.OrdinalIgnoreCase) >= 0)
                    ? "Chuyển khoản"
                    : "Tiền mặt";

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
                            cmd.Parameters.Add("@PhuongThucThanhToan", SqlDbType.NVarChar, 50).Value = phuongThucChuan;
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
                                cmdHD.Parameters.Add("@PhuongThucThanhToan", SqlDbType.NVarChar, 50).Value = phuongThucChuan;
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

                using (var toast = new FrmSuccessToast("Thanh toán thành công!", "Đã lưu hóa đơn vào hệ thống"))
                {
                    toast.ShowDialog();
                }

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
