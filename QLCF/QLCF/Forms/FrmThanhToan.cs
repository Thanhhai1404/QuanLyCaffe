using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Media;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
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
        private readonly decimal _soTienKhuyenMai;
        private readonly string _maKhuyenMaiApDung;

        // VietQR Auto-Check fields
        private Timer _timerCheckPaid;
        private bool _isPaymentConfirmed = false;
        private DateTime _openFormTime;
        private readonly HashSet<long> _initialTxIds = new HashSet<long>();
        private bool _isSnapshotLoaded = false;

        public FrmThanhToan(int maHD, int maBan, string tenBan, decimal tongTienGoc, decimal soTienKhuyenMai = 0, string maKhuyenMaiApDung = "")
        {
            InitializeComponent();

            _maHD = maHD;
            _maBan = maBan;
            _tenBan = tenBan;
            _tongTienGoc = tongTienGoc;
            _soTienKhuyenMai = soTienKhuyenMai;
            _maKhuyenMaiApDung = maKhuyenMaiApDung;
            _openFormTime = DateTime.Now;

            this.Load += FrmThanhToan_Load;
            this.nudGiamGia.ValueChanged += (s, e) => TinhToanThanhToan();
            this.cboPhuongThucThanhToan.SelectedIndexChanged += (s, e) => TinhToanThanhToan();
            this.nudTienKhachDua.ValueChanged += (s, e) => TinhToanThanhToan();

            this.btnXacNhanThanhToan.Click += btnXacNhanThanhToan_Click;
            this.btnHuyThanhToan.Click += btnHuyThanhToan_Click;
            this.btnXacNhanCKThuCong.Click += btnXacNhanCKThuCong_Click;
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
            
            if (_soTienKhuyenMai > 0)
            {
                lblMaHDInfo.Text += $" | KM: {_maKhuyenMaiApDung}";
            }

            // Load danh sách phương thức thanh toán
            cboPhuongThucThanhToan.Items.Clear();
            cboPhuongThucThanhToan.Items.Add("Tiền mặt");
            cboPhuongThucThanhToan.Items.Add("Chuyển khoản");
            cboPhuongThucThanhToan.SelectedIndex = 0; // Mặc định là Tiền mặt

            // Mặc định tiền khách đưa bằng tổng cần thanh toán (sau khi đã trừ khuyến mãi)
            decimal initialSoTienGiam = Math.Min(_tongTienGoc, _soTienKhuyenMai);
            nudTienKhachDua.Value = Math.Max(0, _tongTienGoc - initialSoTienGiam);

            TinhToanThanhToan();
        }

        private void TinhToanThanhToan()
        {
            int giamGia = (int)nudGiamGia.Value;
            decimal soTienGiam = (_tongTienGoc * giamGia / 100m) + _soTienKhuyenMai;
            
            // Đảm bảo không giảm quá tổng tiền
            if (soTienGiam > _tongTienGoc) soTienGiam = _tongTienGoc;
            
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

                // Ẩn vùng QR khi chọn Tiền mặt
                pnlVietQR.Visible = false;
                DungTimerCheckPaid();
            }
            else
            {
                // Chuyển khoản → disable tiền khách đưa, hiện QR
                nudTienKhachDua.Enabled = false;
                nudTienKhachDua.Value = tongCanThanhToan;
                lblTienThuaLabel.Text = "Tiền trả lại:";
                lblTienThuaVal.Text = "0 đ";
                lblTienThuaVal.ForeColor = Color.FromArgb(44, 62, 80);

                // Hiển thị VietQR động
                HienThiVietQR(tongCanThanhToan);
            }
        }

        // ========== VIETQR ĐỘNG & SEPAY AUTO-CHECK ==========

        private void HienThiVietQR(decimal amount)
        {
            if (amount <= 0) return;

            pnlVietQR.Visible = true;
            _isPaymentConfirmed = false;
            _openFormTime = DateTime.Now;

            // Chụp snapshot danh sách ID giao dịch hiện có trên SePay
            _initialTxIds.Clear();
            _isSnapshotLoaded = false;
            _ = SnapshotExistingTxIdsAsync();

            // Tải ảnh QR động từ SePay QR Service
            string qrUrl = VietQRConfig.BuildQRUrl(amount, _maHD);
            try
            {
                picQRCode.LoadAsync(qrUrl);
            }
            catch
            {
                picQRCode.Image = null;
            }

            // Hiển thị thông tin chuyển khoản
            lblQRBankName.Text = $"Ngân hàng: {VietQRConfig.GetBankDisplayName()}";
            lblQRAccountNo.Text = $"STK: {VietQRConfig.AccountNo}";
            lblQRAccountName.Text = $"Chủ TK: {VietQRConfig.AccountName}";
            lblQRAmount.Text = $"Số tiền: {DinhDangTien(amount)}";
            lblQRContent.Text = $"Nội dung CK: {VietQRConfig.BuildTransferContent(_maHD)}";
            lblQRStatus.Text = "⏳ Đang chờ thanh toán...";
            lblQRStatus.ForeColor = Color.FromArgb(234, 179, 8); // Amber

            // Bắt đầu Auto-Check nếu có SePay Token
            BatDauKiemTraThanhToan(amount);
        }

        private async Task SnapshotExistingTxIdsAsync()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromSeconds(5);
                    client.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Bearer", VietQRConfig.SePayBearerToken);

                    string url = $"{VietQRConfig.SePayApiUrl}?limit=10";
                    var response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        string[] transactions = json.Split(new[] { "{\"id\"" }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (string tx in transactions)
                        {
                            long id = ExtractTxId(tx);
                            if (id > 0)
                            {
                                _initialTxIds.Add(id);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[SnapshotTxIds Error]: {ex.Message}");
            }
            finally
            {
                _isSnapshotLoaded = true;
            }
        }

        private long ExtractTxId(string txBlock)
        {
            try
            {
                int colonIdx = txBlock.IndexOf(':');
                if (colonIdx >= 0)
                {
                    int commaIdx = txBlock.IndexOf(',', colonIdx);
                    if (commaIdx > colonIdx)
                    {
                        string idStr = txBlock.Substring(colonIdx + 1, commaIdx - colonIdx - 1).Trim().Trim('"');
                        if (long.TryParse(idStr, out long txId))
                            return txId;
                    }
                }
            }
            catch { }
            return 0;
        }

        // ========== AUTO-CHECK THANH TOÁN (TIMER POLLING 2S) ==========

        private void BatDauKiemTraThanhToan(decimal amount)
        {
            if (!VietQRConfig.IsAutoCheckEnabled)
                return; // Không có API key → chỉ xác nhận thủ công

            if (_timerCheckPaid == null)
            {
                _timerCheckPaid = new Timer();
            }

            _timerCheckPaid.Interval = 2000; // Polling mỗi 2 giây
            decimal expectedAmount = amount;
            _timerCheckPaid.Tick -= TimerCheckPaid_Tick;
            _timerCheckPaid.Tag = expectedAmount;
            _timerCheckPaid.Tick += TimerCheckPaid_Tick;
            _timerCheckPaid.Start();
        }

        private async void TimerCheckPaid_Tick(object sender, EventArgs e)
        {
            try
            {
                if (_isPaymentConfirmed) return;
                decimal expectedAmount = _timerCheckPaid.Tag is decimal d ? d : 0m;
                await KiemTraGiaoDichAsync(expectedAmount);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[TimerCheckPaid Error]: {ex.Message}");
            }
        }

        private async Task KiemTraGiaoDichAsync(decimal expectedAmount)
        {
            if (_isPaymentConfirmed) return;

            try
            {
                using (var client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromSeconds(5);
                    client.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Bearer", VietQRConfig.SePayBearerToken);

                    // Endpoint lấy 5 giao dịch gần nhất
                    string url = $"{VietQRConfig.SePayApiUrl}?limit=5";
                    var response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        long expectedAmountLong = (long)expectedAmount;

                        string[] transactions = json.Split(new[] { "{\"id\"" }, StringSplitOptions.RemoveEmptyEntries);

                        foreach (string tx in transactions)
                        {
                            if (!tx.Contains("transaction_content")) continue;

                            long txId = ExtractTxId(tx);

                            // 1. Kiểm tra số tiền cộng vào (amount_in) khớp chính xác số tiền cần thanh toán
                            bool isAmountMatched = tx.Contains($"\"amount_in\":{expectedAmountLong}")
                                                || tx.Contains($"\"amount_in\": {expectedAmountLong}")
                                                || tx.Contains($"\"amount_in\":\"{expectedAmountLong}\"")
                                                || tx.Contains($"\"amount_in\": \"{expectedAmountLong}\"");
                            if (!isAmountMatched) continue;

                            // 2. Kiểm tra nếu giao dịch ID này ĐÃ TỒN TẠI từ trước khi mở form -> bỏ qua (tránh lệch timezone)
                            if (txId > 0 && _initialTxIds.Contains(txId))
                            {
                                continue;
                            }

                            // ĐỐI SOÁT THÀNH CÔNG: Giao dịch mới phát sinh khớp đúng số tiền!
                            XacNhanThanhToanTuDong();
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[KiemTraGiaoDich Error]: {ex.Message}");
            }
        }

        private void XacNhanThanhToanTuDong()
        {
            if (_isPaymentConfirmed) return;
            _isPaymentConfirmed = true;

            DungTimerCheckPaid();

            // Âm thanh thông báo thành công
            try { SystemSounds.Beep.Play(); } catch { }

            // Cập nhật trạng thái UI
            lblQRStatus.Text = "✅ Đã nhận tiền thành công!";
            lblQRStatus.ForeColor = Color.FromArgb(5, 150, 105); // Emerald

            // Tự động chuyển ngay sang FrmXemTruocBill để xuất bill & lưu CSDL
            ThucHienXuatBill("Chuyển khoản");
        }

        private void DungTimerCheckPaid()
        {
            if (_timerCheckPaid != null)
            {
                _timerCheckPaid.Stop();
            }
        }

        // ========== XÁC NHẬN THỦ CÔNG ==========

        private void btnXacNhanCKThuCong_Click(object sender, EventArgs e)
        {
            DungTimerCheckPaid();
            _isPaymentConfirmed = true;
            lblQRStatus.Text = "✅ Đã xác nhận thủ công!";
            lblQRStatus.ForeColor = Color.FromArgb(5, 150, 105);
            ThucHienXuatBill("Chuyển khoản");
        }

        // ========== XUẤT BILL ==========

        private void btnXacNhanThanhToan_Click(object sender, EventArgs e)
        {
            string phuongThuc = cboPhuongThucThanhToan.SelectedItem != null ? cboPhuongThucThanhToan.SelectedItem.ToString() : "Tiền mặt";

            if (phuongThuc == "Tiền mặt")
            {
                int giamGia = (int)nudGiamGia.Value;
                decimal soTienGiam = (_tongTienGoc * giamGia / 100m) + _soTienKhuyenMai;
                if (soTienGiam > _tongTienGoc) soTienGiam = _tongTienGoc;
                decimal tongCanThanhToan = Math.Max(0, _tongTienGoc - soTienGiam);
                decimal tienKhachDua = nudTienKhachDua.Value;

                if (tienKhachDua < tongCanThanhToan)
                {
                    MessageBox.Show(
                        "Số tiền khách đưa chưa đủ để thanh toán.",
                        "Số tiền không đủ",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                ThucHienXuatBill("Tiền mặt");
            }
            else
            {
                // Chuyển khoản → kiểm tra đã xác nhận chưa
                if (!_isPaymentConfirmed)
                {
                    MessageBox.Show(
                        "Vui lòng chờ hệ thống xác nhận giao dịch chuyển khoản,\nhoặc bấm nút \"Xác nhận đã CK (thủ công)\".",
                        "Chưa xác nhận chuyển khoản",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                    return;
                }
                ThucHienXuatBill("Chuyển khoản");
            }
        }

        private void ThucHienXuatBill(string phuongThuc)
        {
            DungTimerCheckPaid();

            int giamGia = (int)nudGiamGia.Value;
            decimal soTienGiam = (_tongTienGoc * giamGia / 100m) + _soTienKhuyenMai;
            if (soTienGiam > _tongTienGoc) soTienGiam = _tongTienGoc;
            
            decimal tongCanThanhToan = Math.Max(0, _tongTienGoc - soTienGiam);
            decimal tienKhachDua = phuongThuc == "Tiền mặt" ? nudTienKhachDua.Value : tongCanThanhToan;
            decimal tienTraLai = phuongThuc == "Tiền mặt" ? Math.Max(0, tienKhachDua - tongCanThanhToan) : 0m;

            // Lấy danh sách chi tiết món ăn từ CSDL
            List<ChiTietHoaDonModel> chiTietList = LayDanhSachChiTietHoaDon(_maHD);

            // Mở Form Xem trước Hóa đơn (Bill Preview)
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
                _maKhuyenMaiApDung,
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
                    conn.Open();

                    bool hasTenSize = false;
                    try
                    {
                        using (SqlCommand cmdCheck = new SqlCommand("SELECT COUNT(*) FROM sys.columns WHERE object_id = OBJECT_ID('dbo.ChiTietHoaDon') AND name = 'TenSize'", conn))
                        {
                            object res = cmdCheck.ExecuteScalar();
                            hasTenSize = res != null && Convert.ToInt32(res) > 0;
                        }
                    }
                    catch { }

                    string colTenSize = hasTenSize ? "ISNULL(ct.TenSize, '') AS TenSize" : "'' AS TenSize";

                    string sql = $@"
                        SELECT ct.MaCTHD, ct.MaHD, ct.MaMon, m.TenMon, 
                               {colTenSize},
                               ct.SoLuong, ct.DonGia, ISNULL(ct.ThanhTien, ct.SoLuong * ct.DonGia) AS ThanhTien, ct.GhiChu
                        FROM dbo.ChiTietHoaDon ct
                        JOIN dbo.MonAn m ON ct.MaMon = m.MaMon
                        WHERE ct.MaHD = @MaHD
                        ORDER BY ct.MaCTHD";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.Add("@MaHD", SqlDbType.Int).Value = maHD;

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
                                    TenSize = reader["TenSize"] != DBNull.Value ? reader["TenSize"].ToString() : "",
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
            DungTimerCheckPaid();
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                DungTimerCheckPaid();
                if (_timerCheckPaid != null)
                {
                    _timerCheckPaid.Dispose();
                    _timerCheckPaid = null;
                }
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        private string DinhDangTien(decimal soTien)
        {
            return soTien.ToString("N0") + " đ";
        }
    }
}
