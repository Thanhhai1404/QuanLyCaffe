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
        private readonly string _maKhuyenMai;
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
            string maKhuyenMai,
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
        _maKhuyenMai = maKhuyenMai;
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
            dgvMonAn.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvMonAn.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            dgvMonAn.DataSource = _chiTietList;

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
            // Tính chiều cao động cho Grid danh sách món ăn sau khi layout đã có width chuẩn
            dgvMonAn.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders);
            int totalRowHeights = 0;
            foreach (DataGridViewRow row in dgvMonAn.Rows)
            {
                totalRowHeights += row.Height;
            }
            int totalGridHeight = dgvMonAn.ColumnHeadersHeight + totalRowHeights + 8;
            dgvMonAn.Height = Math.Max(60, totalGridHeight);

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
                            cmd.Parameters.Add("@MaKhuyenMai", SqlDbType.NVarChar, 50).Value = (object)_maKhuyenMai ?? DBNull.Value;

                            cmd.ExecuteNonQuery();
                        }
                    }
                    catch (SqlException ex) when (ex.Number == 2812 || ex.Number == 8144 || ex.Number == 8146 || ex.Message.Contains("too many arguments")) // Fallback nếu DB chưa cài hoặc chưa cập nhật Stored Procedure
                    {
                        using (SqlTransaction tran = conn.BeginTransaction())
                        {
                            HashSet<string> hdCols = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
                            using (SqlCommand cmdCheck = new SqlCommand("SELECT name FROM sys.columns WHERE object_id = OBJECT_ID('dbo.HoaDon')", conn, tran))
                            {
                                using (SqlDataReader dr = cmdCheck.ExecuteReader())
                                {
                                    while (dr.Read()) hdCols.Add(dr.GetString(0));
                                }
                            }

                            List<string> setClauses = new List<string> { "TrangThai = 1" };
                            using (SqlCommand cmdHD = new SqlCommand("", conn, tran))
                            {
                                if (hdCols.Contains("NgayThanhToan")) setClauses.Add("NgayThanhToan = GETDATE()");
                                if (hdCols.Contains("GioRa")) setClauses.Add("GioRa = GETDATE()");

                                if (hdCols.Contains("TongTienGoc")) { setClauses.Add("TongTienGoc = @TongTienGoc"); cmdHD.Parameters.Add("@TongTienGoc", SqlDbType.Decimal).Value = _tongTienGoc; }

                                if (hdCols.Contains("PhanTramGiamGia")) { setClauses.Add("PhanTramGiamGia = @GiamGia"); cmdHD.Parameters.Add("@GiamGia", SqlDbType.Int).Value = _giamGiaPercent; }
                                if (hdCols.Contains("GiamGia")) { setClauses.Add("GiamGia = @GiamGia"); if (!cmdHD.Parameters.Contains("@GiamGia")) cmdHD.Parameters.Add("@GiamGia", SqlDbType.Int).Value = _giamGiaPercent; }

                                if (hdCols.Contains("SoTienGiam")) { setClauses.Add("SoTienGiam = @SoTienGiam"); cmdHD.Parameters.Add("@SoTienGiam", SqlDbType.Decimal).Value = _soTienGiam; }

                                if (hdCols.Contains("TongTienThanhToan")) { setClauses.Add("TongTienThanhToan = @TongTienThanhToan"); cmdHD.Parameters.Add("@TongTienThanhToan", SqlDbType.Decimal).Value = _tongCanThanhToan; }
                                if (hdCols.Contains("TongTien")) { setClauses.Add("TongTien = @TongTienThanhToan"); if (!cmdHD.Parameters.Contains("@TongTienThanhToan")) cmdHD.Parameters.Add("@TongTienThanhToan", SqlDbType.Decimal).Value = _tongCanThanhToan; }

                                if (hdCols.Contains("PhuongThucThanhToan")) { setClauses.Add("PhuongThucThanhToan = @PhuongThucThanhToan"); cmdHD.Parameters.Add("@PhuongThucThanhToan", SqlDbType.NVarChar, 50).Value = phuongThucChuan; }
                                if (hdCols.Contains("TienKhachDua")) { setClauses.Add("TienKhachDua = @TienKhachDua"); cmdHD.Parameters.Add("@TienKhachDua", SqlDbType.Decimal).Value = _tienKhachDua; }
                                if (hdCols.Contains("TienTraLai")) { setClauses.Add("TienTraLai = @TienTraLai"); cmdHD.Parameters.Add("@TienTraLai", SqlDbType.Decimal).Value = _tienTraLai; }

                                if (hdCols.Contains("MaNVThanhToan")) { setClauses.Add("MaNVThanhToan = @MaNV"); cmdHD.Parameters.Add("@MaNV", SqlDbType.Int).Value = UserSession.MaNV; }
                                else if (hdCols.Contains("MaNV")) { setClauses.Add("MaNV = @MaNV"); cmdHD.Parameters.Add("@MaNV", SqlDbType.Int).Value = UserSession.MaNV; }

                                if (hdCols.Contains("MaKhuyenMai")) { setClauses.Add("MaKhuyenMai = @MaKhuyenMai"); cmdHD.Parameters.Add("@MaKhuyenMai", SqlDbType.NVarChar, 50).Value = (object)_maKhuyenMai ?? DBNull.Value; }

                                cmdHD.CommandText = $"UPDATE dbo.HoaDon SET {string.Join(", ", setClauses)} WHERE MaHD = @MaHD";
                                cmdHD.Parameters.Add("@MaHD", SqlDbType.Int).Value = _maHD;
                                cmdHD.ExecuteNonQuery();
                            }

                            string sqlBan = @"UPDATE dbo.Ban 
                                SET DangSuDung = 1, 
                                    TrangThai = N'Trống' 
                                WHERE MaBan = @MaBan";

                            using (SqlCommand cmdBan = new SqlCommand(sqlBan, conn, tran))
                            {
                                cmdBan.Parameters.Add("@MaBan", SqlDbType.Int).Value = _maBan;
                                cmdBan.ExecuteNonQuery();
                            }

                            if (!string.IsNullOrEmpty(_maKhuyenMai))
                            {
                                string sqlKM = @"UPDATE dbo.KhuyenMai 
                                                 SET SoLuotConLai = SoLuotConLai - 1 
                                                 WHERE MaKhuyenMai = @MaKhuyenMai AND SoLuotConLai IS NOT NULL AND SoLuotConLai > 0";
                                using (SqlCommand cmdKM = new SqlCommand(sqlKM, conn, tran))
                                {
                                    cmdKM.Parameters.Add("@MaKhuyenMai", SqlDbType.NVarChar, 50).Value = _maKhuyenMai;
                                    cmdKM.ExecuteNonQuery();
                                }
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
