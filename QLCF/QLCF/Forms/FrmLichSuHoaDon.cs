using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using QLCF.Data;
using QLCF.Models;

namespace QLCF.Forms
{
    public partial class FrmLichSuHoaDon : Form
    {
        public FrmLichSuHoaDon()
        {
            InitializeComponent();

            this.Load += FrmLichSuHoaDon_Load;
            this.btnLoc.Click += btnLoc_Click;
            this.btnLamMoi.Click += btnLamMoi_Click;
            this.btnDong.Click += btnDong_Click;
        }

        private void FrmLichSuHoaDon_Load(object sender, EventArgs e)
        {
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

            // Cấu hình giá trị mặc định cho bộ lọc
            DateTime now = DateTime.Now;
            dtpTuNgay.Value = new DateTime(now.Year, now.Month, 1);
            dtpDenNgay.Value = now;
            cboTrangThai.SelectedIndex = 0;
            txtTimMaHD.Text = string.Empty;

            // Load dữ liệu hóa đơn
            TaiLichSuHoaDon();
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            TaiLichSuHoaDon();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            dtpTuNgay.Value = new DateTime(now.Year, now.Month, 1);
            dtpDenNgay.Value = now;
            cboTrangThai.SelectedIndex = 0;
            txtTimMaHD.Text = string.Empty;

            TaiLichSuHoaDon();
        }

        private void TaiLichSuHoaDon()
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

            try
            {
                using (SqlConnection conn = Db.CreateConnection())
                {
                    string sql = @"
                        SELECT MaHD, TenBan, TenKhuVuc, GioVao, GioRa, NguoiMo, NguoiThanhToan,
                               TongTienGoc, GiamGia, TongTien, PhuongThucThanhToan, TrangThai, LyDoHuy
                        FROM dbo.vw_LichSuHoaDon
                        WHERE CAST(GioVao AS DATE) >= @TuNgay
                          AND CAST(GioVao AS DATE) <= @DenNgay";

                    // Bộ lọc trạng thái: 0 = Chưa thanh toán, 1 = Đã thanh toán, 2 = Đã hủy
                    int selectedIndex = cboTrangThai.SelectedIndex;
                    if (selectedIndex == 1)
                    {
                        sql += " AND TrangThai = 0";
                    }
                    else if (selectedIndex == 2)
                    {
                        sql += " AND TrangThai = 1";
                    }
                    else if (selectedIndex == 3)
                    {
                        sql += " AND TrangThai = 2";
                    }

                    // Bộ lọc mã hóa đơn
                    string timKiemMaHD = txtTimMaHD.Text.Trim();
                    if (!string.IsNullOrEmpty(timKiemMaHD))
                    {
                        // Tháo bỏ tiền tố HD nếu người dùng nhập HD00005
                        string cleanInput = timKiemMaHD.ToUpper().Replace("HD", "").Trim();
                        if (int.TryParse(cleanInput, out int maHDSearch))
                        {
                            sql += " AND MaHD = @MaHDSearch";
                        }
                        else
                        {
                            sql += " AND CAST(MaHD AS NVARCHAR) LIKE @SearchLike";
                        }
                    }

                    sql += " ORDER BY GioVao DESC, MaHD DESC";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.Add("@TuNgay", SqlDbType.Date).Value = tuNgay;
                        cmd.Parameters.Add("@DenNgay", SqlDbType.Date).Value = denNgay;

                        if (!string.IsNullOrEmpty(timKiemMaHD))
                        {
                            string cleanInput = timKiemMaHD.ToUpper().Replace("HD", "").Trim();
                            if (int.TryParse(cleanInput, out int maHDSearch))
                            {
                                cmd.Parameters.Add("@MaHDSearch", SqlDbType.Int).Value = maHDSearch;
                            }
                            else
                            {
                                cmd.Parameters.Add("@SearchLike", SqlDbType.NVarChar, 50).Value = "%" + timKiemMaHD + "%";
                            }
                        }

                        conn.Open();
                        DataTable dtRaw = new DataTable();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dtRaw);
                        }

                        // Thêm các cột đã được format cho DataGridView
                        DataTable dtDisplay = ConvertToDisplayTable(dtRaw);

                        dgvLichSuHoaDon.AutoGenerateColumns = false;
                        dgvLichSuHoaDon.DataSource = dtDisplay;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải lịch sử hóa đơn.\n\nChi tiết lỗi: " + ex.Message,
                    "Lỗi cơ sở dữ liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private DataTable ConvertToDisplayTable(DataTable dtRaw)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("MaHDText", typeof(string));
            dt.Columns.Add("TenBan", typeof(string));
            dt.Columns.Add("TenKhuVuc", typeof(string));
            dt.Columns.Add("GioVaoFormatted", typeof(string));
            dt.Columns.Add("GioRaFormatted", typeof(string));
            dt.Columns.Add("NguoiMo", typeof(string));
            dt.Columns.Add("NguoiThanhToan", typeof(string));
            dt.Columns.Add("TongTienGocFormatted", typeof(string));
            dt.Columns.Add("GiamGiaFormatted", typeof(string));
            dt.Columns.Add("TongTienFormatted", typeof(string));
            dt.Columns.Add("PhuongThucThanhToan", typeof(string));
            dt.Columns.Add("TrangThaiText", typeof(string));
            dt.Columns.Add("LyDoHuy", typeof(string));

            foreach (DataRow row in dtRaw.Rows)
            {
                DataRow newRow = dt.NewRow();

                int maHD = Convert.ToInt32(row["MaHD"]);
                newRow["MaHDText"] = "HD" + maHD.ToString("D5");
                newRow["TenBan"] = row["TenBan"] != DBNull.Value ? row["TenBan"].ToString() : "";
                newRow["TenKhuVuc"] = row["TenKhuVuc"] != DBNull.Value ? row["TenKhuVuc"].ToString() : "";

                if (row["GioVao"] != DBNull.Value)
                {
                    newRow["GioVaoFormatted"] = Convert.ToDateTime(row["GioVao"]).ToString("dd/MM/yyyy HH:mm");
                }
                else
                {
                    newRow["GioVaoFormatted"] = "--";
                }

                if (row["GioRa"] != DBNull.Value)
                {
                    newRow["GioRaFormatted"] = Convert.ToDateTime(row["GioRa"]).ToString("dd/MM/yyyy HH:mm");
                }
                else
                {
                    newRow["GioRaFormatted"] = "--";
                }

                newRow["NguoiMo"] = row["NguoiMo"] != DBNull.Value ? row["NguoiMo"].ToString() : "--";
                newRow["NguoiThanhToan"] = row["NguoiThanhToan"] != DBNull.Value ? row["NguoiThanhToan"].ToString() : "--";

                decimal tongTienGoc = row["TongTienGoc"] != DBNull.Value ? Convert.ToDecimal(row["TongTienGoc"]) : 0m;
                newRow["TongTienGocFormatted"] = tongTienGoc.ToString("N0") + " đ";

                int giamGia = row["GiamGia"] != DBNull.Value ? Convert.ToInt32(row["GiamGia"]) : 0;
                newRow["GiamGiaFormatted"] = giamGia + "%";

                decimal tongTien = row["TongTien"] != DBNull.Value ? Convert.ToDecimal(row["TongTien"]) : 0m;
                newRow["TongTienFormatted"] = tongTien.ToString("N0") + " đ";

                newRow["PhuongThucThanhToan"] = row["PhuongThucThanhToan"] != DBNull.Value ? row["PhuongThucThanhToan"].ToString() : "--";

                int trangThai = row["TrangThai"] != DBNull.Value ? Convert.ToInt32(row["TrangThai"]) : 0;
                switch (trangThai)
                {
                    case 0:
                        newRow["TrangThaiText"] = "Chưa thanh toán";
                        break;
                    case 1:
                        newRow["TrangThaiText"] = "Đã thanh toán";
                        break;
                    case 2:
                        newRow["TrangThaiText"] = "Đã hủy";
                        break;
                    default:
                        newRow["TrangThaiText"] = "Khác";
                        break;
                }

                newRow["LyDoHuy"] = row["LyDoHuy"] != DBNull.Value ? row["LyDoHuy"].ToString() : "";

                dt.Rows.Add(newRow);
            }

            return dt;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
