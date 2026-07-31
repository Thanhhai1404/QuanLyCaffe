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
    public partial class FrmQuanLyKhuyenMai : Form
    {
        private int? _selectedMaKM = null;

        public FrmQuanLyKhuyenMai()
        {
            InitializeComponent();
            this.Load += FrmQuanLyKhuyenMai_Load;
            this.dgvKhuyenMai.CellClick += dgvKhuyenMai_CellClick;
            this.btnThem.Click += btnThem_Click;
            this.btnCapNhat.Click += btnCapNhat_Click;
            this.btnXoa.Click += btnXoa_Click;
            this.btnLamMoi.Click += btnLamMoi_Click;
            this.chkKhongGioiHan.CheckedChanged += (s, e) => nudSoLuot.Enabled = !chkKhongGioiHan.Checked;
            this.cboLoaiGiam.SelectedIndexChanged += (s, e) =>
            {
                bool isPercent = cboLoaiGiam.SelectedIndex == 0;
                nudGiamToiDa.Enabled = isPercent;
                lblGiamToiDa.Enabled = isPercent;
                if (isPercent) nudGiaTriGiam.Maximum = 100;
                else nudGiaTriGiam.Maximum = 10000000;
            };
        }

        private void FrmQuanLyKhuyenMai_Load(object sender, EventArgs e)
        {
            UITheme.ApplyStyleToForm(this);
            UITheme.ApplyStyleToButton(btnThem, isSuccess: true);
            UITheme.ApplyStyleToButton(btnCapNhat, isPrimary: true);
            UITheme.ApplyStyleToButton(btnXoa, isDanger: true);

            cboLoaiGiam.Items.Clear();
            cboLoaiGiam.Items.Add("Giảm theo %");
            cboLoaiGiam.Items.Add("Giảm trực tiếp (VNĐ)");
            cboLoaiGiam.SelectedIndex = 0;

            dtpNgayBD.Value = DateTime.Today;
            dtpNgayKT.Value = DateTime.Today.AddMonths(1);

            LamMoiForm();
            LoadDanhSachKhuyenMai();
        }

        #region LOAD DATA

        private void LoadDanhSachKhuyenMai()
        {
            try
            {
                dgvKhuyenMai.AutoGenerateColumns = true;
                List<KhuyenMaiModel> list = new List<KhuyenMaiModel>();

                using (SqlConnection conn = Db.CreateConnection())
                {
                    string sql = @"SELECT MaKM, TenKM, MaKhuyenMai, LoaiGiamGia, GiaTriGiam, GiamToiDa,
                                          DieuKienToiThieu, NgayBatDau, NgayKetThuc, SoLuotConLai, TrangThai, MoTa
                                   FROM dbo.KhuyenMai ORDER BY NgayTao DESC";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                list.Add(new KhuyenMaiModel
                                {
                                    MaKM = Convert.ToInt32(reader["MaKM"]),
                                    TenKM = reader["TenKM"].ToString(),
                                    MaKhuyenMai = reader["MaKhuyenMai"].ToString(),
                                    LoaiGiamGia = Convert.ToInt32(reader["LoaiGiamGia"]),
                                    GiaTriGiam = Convert.ToDecimal(reader["GiaTriGiam"]),
                                    GiamToiDa = reader["GiamToiDa"] != DBNull.Value ? (decimal?)Convert.ToDecimal(reader["GiamToiDa"]) : null,
                                    DieuKienToiThieu = Convert.ToDecimal(reader["DieuKienToiThieu"]),
                                    NgayBatDau = Convert.ToDateTime(reader["NgayBatDau"]),
                                    NgayKetThuc = Convert.ToDateTime(reader["NgayKetThuc"]),
                                    SoLuotConLai = reader["SoLuotConLai"] != DBNull.Value ? (int?)Convert.ToInt32(reader["SoLuotConLai"]) : null,
                                    TrangThai = Convert.ToBoolean(reader["TrangThai"]),
                                    MoTa = reader["MoTa"] != DBNull.Value ? reader["MoTa"].ToString() : ""
                                });
                            }
                        }
                    }
                }

                // Build DataTable for display
                DataTable dt = new DataTable();
                dt.Columns.Add("MaKM", typeof(int));
                dt.Columns.Add("Mã code", typeof(string));
                dt.Columns.Add("Tên KM", typeof(string));
                dt.Columns.Add("Giảm", typeof(string));
                dt.Columns.Add("Đơn tối thiểu", typeof(string));
                dt.Columns.Add("Thời hạn", typeof(string));
                dt.Columns.Add("Còn lượt", typeof(string));
                dt.Columns.Add("Trạng thái", typeof(string));

                foreach (var km in list)
                {
                    string giam = km.LoaiGiamGia == 0
                        ? $"{km.GiaTriGiam:N0}%" + (km.GiamToiDa.HasValue ? $" (max {km.GiamToiDa.Value:N0}đ)" : "")
                        : $"{km.GiaTriGiam:N0}đ";
                    string dieuKien = km.DieuKienToiThieu > 0 ? $"{km.DieuKienToiThieu:N0}đ" : "Không";
                    string thoiHan = $"{km.NgayBatDau:dd/MM} - {km.NgayKetThuc:dd/MM/yyyy}";
                    string luot = km.SoLuotConLai.HasValue ? km.SoLuotConLai.Value.ToString() : "∞";
                    string trangThai;
                    if (!km.TrangThai) trangThai = "Đã tắt";
                    else if (km.NgayKetThuc < DateTime.Now) trangThai = "Hết hạn";
                    else if (km.SoLuotConLai.HasValue && km.SoLuotConLai.Value <= 0) trangThai = "Hết lượt";
                    else trangThai = "Đang hoạt động";

                    dt.Rows.Add(km.MaKM, km.MaKhuyenMai, km.TenKM, giam, dieuKien, thoiHan, luot, trangThai);
                }

                dgvKhuyenMai.DataSource = dt;
                if (dgvKhuyenMai.Columns["MaKM"] != null) dgvKhuyenMai.Columns["MaKM"].Visible = false;

                // Color rows by status
                foreach (DataGridViewRow row in dgvKhuyenMai.Rows)
                {
                    string tt = row.Cells["Trạng thái"].Value?.ToString() ?? "";
                    if (tt == "Đang hoạt động")
                        row.DefaultCellStyle.ForeColor = Color.FromArgb(5, 150, 105);
                    else if (tt == "Hết hạn" || tt == "Hết lượt")
                        row.DefaultCellStyle.ForeColor = Color.FromArgb(220, 38, 38);
                    else
                        row.DefaultCellStyle.ForeColor = Color.Gray;
                }

                UITheme.ApplyStyleToDataGridView(dgvKhuyenMai);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách khuyến mãi.\n\nChi tiết: " + ex.Message, "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region FORM EVENTS

        private void dgvKhuyenMai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            int maKM = Convert.ToInt32(dgvKhuyenMai.Rows[e.RowIndex].Cells["MaKM"].Value);
            LoadChiTietKhuyenMai(maKM);
        }

        private void LoadChiTietKhuyenMai(int maKM)
        {
            try
            {
                using (SqlConnection conn = Db.CreateConnection())
                {
                    string sql = "SELECT * FROM dbo.KhuyenMai WHERE MaKM = @MaKM";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.Add("@MaKM", SqlDbType.Int).Value = maKM;
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                _selectedMaKM = maKM;
                                txtTenKM.Text = reader["TenKM"].ToString();
                                txtMaCode.Text = reader["MaKhuyenMai"].ToString();
                                cboLoaiGiam.SelectedIndex = Convert.ToInt32(reader["LoaiGiamGia"]);
                                nudGiaTriGiam.Value = Convert.ToDecimal(reader["GiaTriGiam"]);
                                nudGiamToiDa.Value = reader["GiamToiDa"] != DBNull.Value ? Convert.ToDecimal(reader["GiamToiDa"]) : 0;
                                nudDieuKien.Value = Convert.ToDecimal(reader["DieuKienToiThieu"]);
                                dtpNgayBD.Value = Convert.ToDateTime(reader["NgayBatDau"]);
                                dtpNgayKT.Value = Convert.ToDateTime(reader["NgayKetThuc"]);

                                if (reader["SoLuotConLai"] != DBNull.Value)
                                {
                                    chkKhongGioiHan.Checked = false;
                                    nudSoLuot.Value = Convert.ToInt32(reader["SoLuotConLai"]);
                                }
                                else
                                {
                                    chkKhongGioiHan.Checked = true;
                                    nudSoLuot.Value = 0;
                                }

                                txtMoTa.Text = reader["MoTa"] != DBNull.Value ? reader["MoTa"].ToString() : "";
                                lblFormTitle.Text = $"CHỈNH SỬA: {reader["MaKhuyenMai"]}";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            try
            {
                using (SqlConnection conn = Db.CreateConnection())
                {
                    string sql = @"INSERT INTO dbo.KhuyenMai (TenKM, MaKhuyenMai, LoaiGiamGia, GiaTriGiam, GiamToiDa,
                                   DieuKienToiThieu, NgayBatDau, NgayKetThuc, SoLuotConLai, TrangThai, MoTa)
                                   VALUES (@TenKM, @MaCode, @LoaiGiam, @GiaTri, @GiamMax, @DieuKien, @NgayBD, @NgayKT, @SoLuot, 1, @MoTa)";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        GanThamSo(cmd);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Thêm chương trình khuyến mãi thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LamMoiForm();
                LoadDanhSachKhuyenMai();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (!_selectedMaKM.HasValue)
            {
                MessageBox.Show("Vui lòng chọn chương trình KM cần cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!ValidateInput()) return;

            try
            {
                using (SqlConnection conn = Db.CreateConnection())
                {
                    string sql = @"UPDATE dbo.KhuyenMai SET TenKM=@TenKM, MaKhuyenMai=@MaCode, LoaiGiamGia=@LoaiGiam,
                                   GiaTriGiam=@GiaTri, GiamToiDa=@GiamMax, DieuKienToiThieu=@DieuKien,
                                   NgayBatDau=@NgayBD, NgayKetThuc=@NgayKT, SoLuotConLai=@SoLuot, MoTa=@MoTa
                                   WHERE MaKM=@MaKM";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        GanThamSo(cmd);
                        cmd.Parameters.Add("@MaKM", SqlDbType.Int).Value = _selectedMaKM.Value;
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Cập nhật thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LamMoiForm();
                LoadDanhSachKhuyenMai();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (!_selectedMaKM.HasValue)
            {
                MessageBox.Show("Vui lòng chọn chương trình KM cần xóa/tắt.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn muốn TẮT chương trình này?\n(Chương trình sẽ không hiển thị cho nhân viên nữa)", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            try
            {
                using (SqlConnection conn = Db.CreateConnection())
                {
                    string sql = "UPDATE dbo.KhuyenMai SET TrangThai = 0 WHERE MaKM = @MaKM";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.Add("@MaKM", SqlDbType.Int).Value = _selectedMaKM.Value;
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Đã tắt chương trình khuyến mãi.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LamMoiForm();
                LoadDanhSachKhuyenMai();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoiForm();
            LoadDanhSachKhuyenMai();
        }

        #endregion

        #region HELPERS

        private void GanThamSo(SqlCommand cmd)
        {
            cmd.Parameters.Add("@TenKM", SqlDbType.NVarChar, 200).Value = txtTenKM.Text.Trim();
            cmd.Parameters.Add("@MaCode", SqlDbType.VarChar, 30).Value = txtMaCode.Text.Trim().ToUpper();
            cmd.Parameters.Add("@LoaiGiam", SqlDbType.Int).Value = cboLoaiGiam.SelectedIndex;
            cmd.Parameters.Add("@GiaTri", SqlDbType.Decimal).Value = nudGiaTriGiam.Value;
            cmd.Parameters.Add("@GiamMax", SqlDbType.Decimal).Value = nudGiamToiDa.Value > 0 ? (object)nudGiamToiDa.Value : DBNull.Value;
            cmd.Parameters.Add("@DieuKien", SqlDbType.Decimal).Value = nudDieuKien.Value;
            cmd.Parameters.Add("@NgayBD", SqlDbType.DateTime).Value = dtpNgayBD.Value.Date;
            cmd.Parameters.Add("@NgayKT", SqlDbType.DateTime).Value = dtpNgayKT.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
            cmd.Parameters.Add("@SoLuot", SqlDbType.Int).Value = chkKhongGioiHan.Checked ? (object)DBNull.Value : (int)nudSoLuot.Value;
            cmd.Parameters.Add("@MoTa", SqlDbType.NVarChar, 500).Value = string.IsNullOrWhiteSpace(txtMoTa.Text) ? (object)DBNull.Value : txtMoTa.Text.Trim();
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtTenKM.Text))
            {
                MessageBox.Show("Vui lòng nhập tên chương trình.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenKM.Focus(); return false;
            }
            if (string.IsNullOrWhiteSpace(txtMaCode.Text))
            {
                MessageBox.Show("Vui lòng nhập mã khuyến mãi.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaCode.Focus(); return false;
            }
            if (nudGiaTriGiam.Value <= 0)
            {
                MessageBox.Show("Giá trị giảm phải lớn hơn 0.", "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (dtpNgayKT.Value < dtpNgayBD.Value)
            {
                MessageBox.Show("Ngày kết thúc không được nhỏ hơn ngày bắt đầu.", "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void LamMoiForm()
        {
            _selectedMaKM = null;
            txtTenKM.Clear();
            txtMaCode.Clear();
            cboLoaiGiam.SelectedIndex = 0;
            nudGiaTriGiam.Value = 0;
            nudGiamToiDa.Value = 0;
            nudDieuKien.Value = 0;
            dtpNgayBD.Value = DateTime.Today;
            dtpNgayKT.Value = DateTime.Today.AddMonths(1);
            nudSoLuot.Value = 0;
            chkKhongGioiHan.Checked = false;
            txtMoTa.Clear();
            lblFormTitle.Text = "THÔNG TIN KHUYẾN MÃI";
        }

        #endregion
    }
}
