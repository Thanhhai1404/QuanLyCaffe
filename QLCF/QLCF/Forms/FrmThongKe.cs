using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using QLCF.Data;
using QLCF.Helpers;
using QLCF.Models;

namespace QLCF.Forms
{
    public partial class FrmThongKe : Form
    {
        public FrmThongKe()
        {
            InitializeComponent();

            this.Load += FrmThongKe_Load;
            this.btnXemThongKe.Click += btnXemThongKe_Click;
            this.btnDong.Click += btnDong_Click;
        }

        private void FrmThongKe_Load(object sender, EventArgs e)
        {
            UITheme.ApplyStyleToForm(this);
            if (btnXemThongKe != null) UITheme.ApplyStyleToButton(btnXemThongKe, isPrimary: true);
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

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
