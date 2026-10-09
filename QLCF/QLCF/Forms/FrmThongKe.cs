using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using QLCF.Data;
using QLCF.Helpers;
using QLCF.Models;

namespace QLCF.Forms
{
    public partial class FrmThongKe : Form
    {
        private System.Windows.Forms.Button btnCapNhat => this.btnXemThongKe;

        public FrmThongKe()
        {
            InitializeComponent();

            this.Load += FrmThongKe_Load;
            this.btnXemThongKe.Click += btnXemThongKe_Click;
            this.btnXuatExcel.Click += btnXuatExcel_Click;
            this.btnDong.Click += btnDong_Click;
        }

        private void FrmThongKe_Load(object sender, EventArgs e)
        {
            UITheme.ApplyStyleToForm(this);
            if (btnXemThongKe != null) UITheme.ApplyStyleToButton(btnXemThongKe, isPrimary: true);
            if (btnXuatExcel != null) UITheme.ApplyStyleToButton(btnXuatExcel, isSuccess: true);
            if (btnDong != null) UITheme.ApplyStyleToButton(btnDong);

            // Kiểm tra quyền Admin
            if (!UserSession.IsAdmin)
            {
                MessageBox.Show(
                    "Bạn không có quyền truy cập chức năng này.",
                    "Cảnh báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                this.Close();
                return;
            }

            // Đặt ngày mặc định: Từ ngày đầu tháng tới ngày hiện tại
            DateTime now = DateTime.Now;
            dtpTuNgay.Value = new DateTime(now.Year, now.Month, 1);
            dtpDenNgay.Value = now;

            // Load dữ liệu ban đầu
            TaiDuLieuThongKe();
        }

        private void btnXemThongKe_Click(object sender, EventArgs e)
        {
            TaiDuLieuThongKe();
        }

        private void TaiDuLieuThongKe()
        {
            DateTime tuNgay = dtpTuNgay.Value.Date;
            DateTime denNgay = dtpDenNgay.Value.Date;

            if (tuNgay > denNgay)
            {
                MessageBox.Show(
                    "Từ ngày không được lớn hơn Đến ngày.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            TaiDashboardSummary(tuNgay, denNgay);
            TaiTopMonBanChay(tuNgay, denNgay);
            TaiBieuDoDoanhThu(tuNgay, denNgay);
        }

        private void TaiDashboardSummary(DateTime tuNgay, DateTime denNgay)
        {
            try
            {
                using (SqlConnection conn = Db.CreateConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("sp_GetDashboardSummary", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@TuNgay", SqlDbType.Date).Value = tuNgay;
                        cmd.Parameters.Add("@DenNgay", SqlDbType.Date).Value = denNgay;

                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                decimal doanhThu = reader["DoanhThu"] != DBNull.Value ? Convert.ToDecimal(reader["DoanhThu"]) : 0m;
                                int soHoaDon = reader["SoHoaDon"] != DBNull.Value ? Convert.ToInt32(reader["SoHoaDon"]) : 0;
                                int tongMon = reader["TongMonDaBan"] != DBNull.Value ? Convert.ToInt32(reader["TongMonDaBan"]) : 0;

                                lblDoanhThuVal.Text = doanhThu.ToString("N0") + " đ";
                                lblSoHoaDonVal.Text = soHoaDon.ToString("N0");
                                lblTongMonVal.Text = tongMon.ToString("N0");
                            }
                            else
                            {
                                lblDoanhThuVal.Text = "0 đ";
                                lblSoHoaDonVal.Text = "0";
                                lblTongMonVal.Text = "0";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải dữ liệu tổng quan thống kê.\n\nChi tiết lỗi: " + ex.Message,
                    "Lỗi cơ sở dữ liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void TaiTopMonBanChay(DateTime tuNgay, DateTime denNgay)
        {
            try
            {
                using (SqlConnection conn = Db.CreateConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("sp_TopMonBanChay", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@TuNgay", SqlDbType.Date).Value = tuNgay;
                        cmd.Parameters.Add("@DenNgay", SqlDbType.Date).Value = denNgay;
                        cmd.Parameters.Add("@Top", SqlDbType.Int).Value = 5;

                        conn.Open();
                        DataTable dt = new DataTable();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }

                        dgvTopMon.AutoGenerateColumns = false;
                        dgvTopMon.DataSource = dt;

                        // Nạp dữ liệu vào Biểu đồ Tròn (Pie/Doughnut Chart)
                        VeBieuDoTopMon(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải danh sách Top món bán chạy.\n\nChi tiết lỗi: " + ex.Message,
                    "Lỗi cơ sở dữ liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void TaiBieuDoDoanhThu(DateTime tuNgay, DateTime denNgay)
        {
            try
            {
                using (SqlConnection conn = Db.CreateConnection())
                {
                    string sql = @"
                        SELECT CAST(GioVao AS DATE) AS Ngay, SUM(TongTien) AS DoanhThu
                        FROM dbo.vw_LichSuHoaDon
                        WHERE CAST(GioVao AS DATE) >= @TuNgay 
                          AND CAST(GioVao AS DATE) <= @DenNgay 
                          AND TrangThai = 1
                        GROUP BY CAST(GioVao AS DATE)
                        ORDER BY Ngay ASC";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.Add("@TuNgay", SqlDbType.Date).Value = tuNgay;
                        cmd.Parameters.Add("@DenNgay", SqlDbType.Date).Value = denNgay;

                        conn.Open();
                        DataTable dt = new DataTable();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }

                        VeBieuDoCotDoanhThu(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Lỗi vẽ biểu đồ doanh thu: " + ex.Message);
            }
        }

        private void VeBieuDoCotDoanhThu(DataTable dt)
        {
            chartDoanhThu.Series.Clear();
            chartDoanhThu.ChartAreas.Clear();

            ChartArea area = new ChartArea("AreaDoanhThu");
            area.AxisX.MajorGrid.LineColor = Color.FromArgb(241, 245, 249);
            area.AxisY.MajorGrid.LineColor = Color.FromArgb(241, 245, 249);
            area.AxisX.LabelStyle.Font = new Font("Segoe UI", 8.5f);
            area.AxisY.LabelStyle.Font = new Font("Segoe UI", 8.5f);
            area.AxisY.LabelStyle.Format = "#,##0 đ";
            chartDoanhThu.ChartAreas.Add(area);

            Series series = new Series("DoanhThuSeries")
            {
                ChartType = SeriesChartType.Column,
                Color = Color.FromArgb(37, 99, 235),
                IsValueShownAsLabel = true,
                Font = new Font("Segoe UI", 8.5f, FontStyle.Bold),
                BackGradientStyle = GradientStyle.TopBottom,
                BackSecondaryColor = Color.FromArgb(96, 165, 250)
            };

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    DateTime ngay = Convert.ToDateTime(row["Ngay"]);
                    decimal doanhThu = Convert.ToDecimal(row["DoanhThu"]);

                    int ptIndex = series.Points.AddXY(ngay.ToString("dd/MM"), doanhThu);
                    DataPoint pt = series.Points[ptIndex];
                    pt.Label = doanhThu >= 1000000 ? (doanhThu / 1000000m).ToString("0.#") + "M" : (doanhThu / 1000m).ToString("0") + "k";
                    pt.ToolTip = $"{ngay:dd/MM/yyyy}: {doanhThu:N0} VNĐ";
                }
            }

            chartDoanhThu.Series.Add(series);
        }

        private void VeBieuDoTopMon(DataTable dt)
        {
            chartTopMon.Series.Clear();
            chartTopMon.ChartAreas.Clear();
            chartTopMon.Legends.Clear();

            ChartArea area = new ChartArea("AreaTopMon");
            chartTopMon.ChartAreas.Add(area);

            Legend legend = new Legend("LegendTopMon")
            {
                Docking = Docking.Right,
                Font = new Font("Segoe UI", 8.5f),
                BackColor = Color.Transparent
            };
            chartTopMon.Legends.Add(legend);

            Series series = new Series("TopMonSeries")
            {
                ChartType = SeriesChartType.Doughnut,
                Font = new Font("Segoe UI", 9f, FontStyle.Bold),
                IsValueShownAsLabel = true,
                Label = "#PERCENT{P0}"
            };

            // Modern color palette for Pie chart
            Color[] sliceColors = new Color[]
            {
                Color.FromArgb(16, 185, 129),  // Emerald Green
                Color.FromArgb(59, 130, 246),  // Royal Blue
                Color.FromArgb(245, 158, 11),  // Amber
                Color.FromArgb(236, 72, 153),  // Pink
                Color.FromArgb(139, 92, 246)   // Purple
            };

            if (dt != null && dt.Rows.Count > 0)
            {
                int colorIndex = 0;
                foreach (DataRow row in dt.Rows)
                {
                    string tenMon = row["TenMon"].ToString();
                    int soLuong = Convert.ToInt32(row["TongSoLuong"]);

                    int ptIndex = series.Points.AddXY(tenMon, soLuong);
                    DataPoint pt = series.Points[ptIndex];
                    pt.Color = sliceColors[colorIndex % sliceColors.Length];
                    pt.LegendText = $"{tenMon} ({soLuong})";
                    pt.ToolTip = $"{tenMon}: {soLuong} ly/món";
                    colorIndex++;
                }
            }

            chartTopMon.Series.Add(series);
        }

        private async void btnXuatExcel_Click(object sender, EventArgs e)
        {
            DateTime tuNgay = dtpTuNgay.Value.Date;
            DateTime denNgay = dtpDenNgay.Value.Date;

            if (tuNgay > denNgay)
            {
                MessageBox.Show(
                    "Từ ngày không được lớn hơn Đến ngày.",
                    "Cảnh báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            DataTable dtTopMon = dgvTopMon.DataSource as DataTable;

            // Lấy thông tin tổng quan KPI
            decimal totalRevenue = 0m;
            int totalOrders = 0;
            int totalItems = 0;

            try
            {
                using (SqlConnection conn = Db.CreateConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("sp_GetDashboardSummary", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@TuNgay", SqlDbType.Date).Value = tuNgay;
                        cmd.Parameters.Add("@DenNgay", SqlDbType.Date).Value = denNgay;

                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                totalRevenue = reader["DoanhThu"] != DBNull.Value ? Convert.ToDecimal(reader["DoanhThu"]) : 0m;
                                totalOrders = reader["SoHoaDon"] != DBNull.Value ? Convert.ToInt32(reader["SoHoaDon"]) : 0;
                                totalItems = reader["TongMonDaBan"] != DBNull.Value ? Convert.ToInt32(reader["TongMonDaBan"]) : 0;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error reading summary: " + ex.Message);
            }

            // Kiểm tra tính khả dụng của dữ liệu
            if (totalOrders == 0 && (dtTopMon == null || dtTopMon.Rows.Count == 0))
            {
                MessageBox.Show(
                    "Không có dữ liệu để xuất trong khoảng thời gian đã chọn.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            // Lấy chi tiết lịch sử hóa đơn trong khoảng thời gian
            DataTable dtInvoices = GetInvoiceHistoryForReport(tuNgay, denNgay);

            // Mở SaveFileDialog
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.FileName = $"BaoCaoThongKe_{DateTime.Now:yyyyMMdd}_{DateTime.Now:HHmm}.xlsx";
                sfd.Filter = "Excel Workbook (*.xlsx)|*.xlsx";
                sfd.Title = "Chọn vị trí lưu file Báo Cáo Excel";

                if (sfd.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                string filePath = sfd.FileName;

                // Trạng thái Loading UI
                btnXuatExcel.Enabled = false;
                string originalText = btnXuatExcel.Text;
                btnXuatExcel.Text = "⏳ Đang tạo file...";
                this.Cursor = Cursors.WaitCursor;

                try
                {
                    bool success = await ExcelExportService.ExportStatisticsToExcelAsync(
                        filePath,
                        dtTopMon,
                        dtInvoices,
                        tuNgay,
                        denNgay,
                        "BÁO CÁO THỐNG KÊ DOANH THU & BÁN HÀNG",
                        totalRevenue,
                        totalOrders,
                        totalItems
                    );

                    if (success)
                    {
                        DialogResult confirm = MessageBox.Show(
                            "Xuất file Excel thành công! Bạn có muốn mở file ngay không?",
                            "Thành công",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Information
                        );

                        if (confirm == DialogResult.Yes)
                        {
                            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                            {
                                FileName = filePath,
                                UseShellExecute = true
                            });
                        }
                    }
                }
                catch (IOException)
                {
                    MessageBox.Show(
                        "Không thể ghi đè file do file đang mở trong một ứng dụng khác (ví dụ: Microsoft Excel).\nVui lòng đóng file và thử lại.",
                        "Lỗi thao tác File",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Đã xảy ra lỗi khi xuất file Excel:\n" + ex.Message,
                        "Lỗi hệ thống",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
                finally
                {
                    btnXuatExcel.Text = originalText;
                    btnXuatExcel.Enabled = true;
                    this.Cursor = Cursors.Default;
                }
            }
        }

        private DataTable GetInvoiceHistoryForReport(DateTime tuNgay, DateTime denNgay)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = Db.CreateConnection())
                {
                    string sql = @"
                        SELECT MaHD, TenBan, TenKhuVuc, GioVao, GioRa, NguoiThanhToan, TongTien, PhuongThucThanhToan
                        FROM dbo.vw_LichSuHoaDon
                        WHERE CAST(GioVao AS DATE) >= @TuNgay
                          AND CAST(GioVao AS DATE) <= @DenNgay
                          AND TrangThai = 1
                        ORDER BY GioVao DESC, MaHD DESC";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.Add("@TuNgay", SqlDbType.Date).Value = tuNgay;
                        cmd.Parameters.Add("@DenNgay", SqlDbType.Date).Value = denNgay;

                        conn.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error getting invoice history for excel: " + ex.Message);
            }
            return dt;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
