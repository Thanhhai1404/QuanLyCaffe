using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using QLCF.Data;
using QLCF.Helpers;

namespace QLCF.Forms
{
    public partial class DashboardAdminControl : UserControl
    {
        public FrmMain MainForm { get; set; }

        public DashboardAdminControl()
        {
            InitializeComponent();

            this.Load += DashboardAdminControl_Load;
            this.btnTaiLaiDashboard.Click += btnTaiLaiDashboard_Click;

            this.btnQuickBanHang.Click += btnQuickBanHang_Click;
            this.btnQuickLichSu.Click += btnQuickLichSu_Click;
            this.btnQuickQuanLyMon.Click += btnQuickQuanLyMon_Click;
        }

        private void DashboardAdminControl_Load(object sender, EventArgs e)
        {
            // Apply UI styling
            UITheme.ApplyStyleToButton(btnTaiLaiDashboard, isPrimary: true);
            UITheme.ApplyStyleToButton(btnQuickBanHang, isPrimary: true);
            UITheme.ApplyStyleToButton(btnQuickLichSu);
            UITheme.ApplyStyleToButton(btnQuickQuanLyMon);
            UITheme.ApplyStyleToDataGridView(dgvTopMon);

            // Set default date range: From first day of current month to today
            DateTime now = DateTime.Now;
            dtpTuNgay.Value = new DateTime(now.Year, now.Month, 1);
            dtpDenNgay.Value = now;

            // Initial load
            LoadDashboard();
        }

        public void LoadDashboard()
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

            LoadThongKeTongQuan(tuNgay, denNgay);
            LoadTopMonBanChay(tuNgay, denNgay);
            LoadTinhTrangBan();
            TaiBieuDoDoanhThu(tuNgay, denNgay);
        }

        private void btnTaiLaiDashboard_Click(object sender, EventArgs e)
        {
            LoadDashboard();
        }

        private void LoadThongKeTongQuan(DateTime tuNgay, DateTime denNgay)
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

                                lblDoanhThuVal.Text = DinhDangTien(doanhThu);
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
                    "Không thể tải dữ liệu tổng quan thống kê.\nChi tiết lỗi: " + ex.Message,
                    "Lỗi cơ sở dữ liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void LoadTopMonBanChay(DateTime tuNgay, DateTime denNgay)
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

                        VeBieuDoTopMon(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải danh sách Top món bán chạy.\nChi tiết lỗi: " + ex.Message,
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
            if (chartDoanhThu == null) return;

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
            if (chartTopMon == null) return;

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

            Color[] sliceColors = new Color[]
            {
                Color.FromArgb(16, 185, 129),
                Color.FromArgb(59, 130, 246),
                Color.FromArgb(245, 158, 11),
                Color.FromArgb(236, 72, 153),
                Color.FromArgb(139, 92, 246)
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

        private void LoadTinhTrangBan()
        {
            try
            {
                using (SqlConnection conn = Db.CreateConnection())
                {
                    string sql = @"
                        SELECT 
                            SUM(CASE WHEN TrangThai = N'Có khách' AND DangSuDung = 1 THEN 1 ELSE 0 END) AS CoKhach,
                            SUM(CASE WHEN TrangThai = N'Trống' AND DangSuDung = 1 THEN 1 ELSE 0 END) AS Trong,
                            SUM(CASE WHEN TrangThai = N'Đặt trước' AND DangSuDung = 1 THEN 1 ELSE 0 END) AS DatTruoc,
                            SUM(CASE WHEN DangSuDung = 0 THEN 1 ELSE 0 END) AS NgungSuDung,
                            COUNT(*) AS TongSoBan
                        FROM dbo.vw_SoDoBan";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int coKhach = reader["CoKhach"] != DBNull.Value ? Convert.ToInt32(reader["CoKhach"]) : 0;
                                int trong = reader["Trong"] != DBNull.Value ? Convert.ToInt32(reader["Trong"]) : 0;
                                int datTruoc = reader["DatTruoc"] != DBNull.Value ? Convert.ToInt32(reader["DatTruoc"]) : 0;
                                int ngungDung = reader["NgungSuDung"] != DBNull.Value ? Convert.ToInt32(reader["NgungSuDung"]) : 0;
                                int tongBan = reader["TongSoBan"] != DBNull.Value ? Convert.ToInt32(reader["TongSoBan"]) : 0;

                                lblBanCoKhachVal.Text = $"{coKhach} / {tongBan} bàn";
                                lblBadgeCoKhachVal.Text = $"{coKhach} bàn";
                                lblBadgeTrongVal.Text = $"{trong} bàn";
                                lblBadgeDatTruocVal.Text = $"{datTruoc} bàn";
                                lblBadgeNgungDungVal.Text = $"{ngungDung} bàn";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải thông tin tình trạng bàn.\nChi tiết lỗi: " + ex.Message,
                    "Lỗi cơ sở dữ liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private string DinhDangTien(decimal soTien)
        {
            return soTien.ToString("#,##0") + " đ";
        }

        private void btnQuickBanHang_Click(object sender, EventArgs e)
        {
            if (MainForm != null)
            {
                MainForm.MoBanHang();
            }
        }

        private void btnQuickLichSu_Click(object sender, EventArgs e)
        {
            if (MainForm != null)
            {
                MainForm.MoLichSuHoaDon();
            }
        }

        private void btnQuickQuanLyMon_Click(object sender, EventArgs e)
        {
            if (MainForm != null)
            {
                MainForm.MoQuanLyMonAn();
            }
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

                btnXuatExcel.Enabled = false;
                string originalText = btnXuatExcel.Text;
                btnXuatExcel.Text = "⏳ Đang tạo...";
                this.Cursor = Cursors.WaitCursor;

                try
                {
                    bool success = await System.Threading.Tasks.Task.Run(() => ExcelExportService.ExportReport(filePath, tuNgay, denNgay));

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
                catch (System.IO.IOException)
                {
                    MessageBox.Show(
                        "Không thể ghi đè file do file đang mở trong một ứng dụng khác.\nVui lòng đóng file và thử lại.",
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
    }
}
