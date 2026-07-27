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

        // VietQR Auto-Check fields
        private Timer _timerCheckPaid;
        private long _lastSePayTxId = 0;
        private bool _isPaymentConfirmed = false;

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

            // Load danh sách phương thức thanh toán
            cboPhuongThucThanhToan.Items.Clear();
            cboPhuongThucThanhToan.Items.Add("Tiền mặt");
            cboPhuongThucThanhToan.Items.Add("Chuyển khoản");
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

        // ========== VIETQR ĐỘNG ==========

        private void HienThiVietQR(decimal amount)
        {
            if (amount <= 0) return;

            pnlVietQR.Visible = true;
            _isPaymentConfirmed = false;

            // Tải ảnh QR không đồng bộ từ VietQR Quick Link
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

        // ========== AUTO-CHECK THANH TOÁN (TIMER POLLING) ==========

        private void BatDauKiemTraThanhToan(decimal amount)
        {
            if (!VietQRConfig.IsAutoCheckEnabled)
                return; // Không có API key → chỉ xác nhận thủ công

            if (_timerCheckPaid == null)
            {
                _timerCheckPaid = new Timer();
                _timerCheckPaid.Interval = VietQRConfig.PollingIntervalMs;
            }

            decimal expectedAmount = amount;
            _timerCheckPaid.Tick -= TimerCheckPaid_Tick;
            _timerCheckPaid.Tag = expectedAmount; // Lưu số tiền cần kiểm tra
            _timerCheckPaid.Tick += TimerCheckPaid_Tick;
            _timerCheckPaid.Start();
        }

        private async void TimerCheckPaid_Tick(object sender, EventArgs e)
        {
            if (_isPaymentConfirmed) return;
            decimal expectedAmount = _timerCheckPaid.Tag is decimal d ? d : 0m;
            await KiemTraGiaoDichAsync(expectedAmount);
        }

        private async Task KiemTraGiaoDichAsync(decimal expectedAmount)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromSeconds(5);
                    client.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Bearer", VietQRConfig.SePayBearerToken);

                    string url = $"{VietQRConfig.SePayApiUrl}?since_id={_lastSePayTxId}&limit=20";
                    var response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        string expectedContent = VietQRConfig.BuildTransferContent(_maHD).ToUpper();

                        // Parse JSON đơn giản (tìm giao dịch khớp nội dung + số tiền)
                        if (json.Contains(expectedContent) || json.Contains($"QLCF HD{_maHD:D5}"))
                        {
                            // Kiểm tra số tiền (tìm "transferAmount" hoặc "amount_in" gần đúng)
                            long expectedAmountLong = (long)expectedAmount;
                            if (json.Contains(expectedAmountLong.ToString()))
                            {
                                XacNhanThanhToanTuDong();
                            }
                        }
                    }
                }
            }
            catch
            {
                // Mất mạng → bỏ qua, chờ lần poll tiếp theo
            }
        }

        private void XacNhanThanhToanTuDong()
        {
            if (_isPaymentConfirmed) return;
            _isPaymentConfirmed = true;

            DungTimerCheckPaid();

            // Phát tiếng báo hiệu
            SystemSounds.Beep.Play();

            // Cập nhật trạng thái trên UI
            lblQRStatus.Text = "✅ Đã nhận tiền thành công!";
            lblQRStatus.ForeColor = Color.FromArgb(5, 150, 105); // Emerald

            // Tự động kích hoạt xuất bill sau 1 giây
            Timer delayTimer = new Timer();
            delayTimer.Interval = 1000;
            delayTimer.Tick += (s, e) =>
            {
                delayTimer.Stop();
                delayTimer.Dispose();
                ThucHienXuatBill("Chuyển khoản (VietQR)");
            };
            delayTimer.Start();
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

            DialogResult result = MessageBox.Show(
                "Bạn xác nhận đã nhận được tiền chuyển khoản từ khách hàng?",
                "Xác nhận chuyển khoản",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                _isPaymentConfirmed = true;
                lblQRStatus.Text = "✅ Đã xác nhận thủ công!";
                lblQRStatus.ForeColor = Color.FromArgb(5, 150, 105);
                ThucHienXuatBill("Chuyển khoản (VietQR)");
            }
            else
            {
                // Bật lại Timer nếu có
                if (VietQRConfig.IsAutoCheckEnabled && _timerCheckPaid != null)
                    _timerCheckPaid.Start();
            }
        }

        // ========== XUẤT BILL ==========

        private void btnXacNhanThanhToan_Click(object sender, EventArgs e)
        {
            string phuongThuc = cboPhuongThucThanhToan.SelectedItem != null ? cboPhuongThucThanhToan.SelectedItem.ToString() : "Tiền mặt";

            if (phuongThuc == "Tiền mặt")
            {
                int giamGia = (int)nudGiamGia.Value;
                decimal soTienGiam = _tongTienGoc * giamGia / 100m;
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
                ThucHienXuatBill("Chuyển khoản (VietQR)");
            }
        }

        private void ThucHienXuatBill(string phuongThuc)
        {
            DungTimerCheckPaid();

            int giamGia = (int)nudGiamGia.Value;
            decimal soTienGiam = _tongTienGoc * giamGia / 100m;
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
