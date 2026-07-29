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
    public partial class FrmQuanLyKho : Form
    {
        public FrmQuanLyKho()
        {
            InitializeComponent();

            this.Load += FrmQuanLyKho_Load;
            this.btnDong.Click += (s, e) => this.Close();

            // Event Tab 1: Nguyên Vật Liệu
            this.dgvNguyenVatLieu.SelectionChanged += dgvNguyenVatLieu_SelectionChanged;
            this.btnThemNVL.Click += btnThemNVL_Click;
            this.btnSuaNVL.Click += btnSuaNVL_Click;
            this.btnLuuNVL.Click += btnLuuNVL_Click;
            this.btnLamMoiNVL.Click += btnLamMoiNVL_Click;
            this.btnNhapKho.Click += btnNhapKho_Click;
        }

        private void FrmQuanLyKho_Load(object sender, EventArgs e)
        {
            UITheme.ApplyStyleToForm(this);
            UITheme.ApplyStyleToButton(btnDong);
            UITheme.ApplyStyleToButton(btnThemNVL);
            UITheme.ApplyStyleToButton(btnSuaNVL);
            UITheme.ApplyStyleToButton(btnLamMoiNVL);
            UITheme.ApplyStyleToButton(btnLuuNVL, isPrimary: true);

            // Kiểm tra quyền (Chỉ Admin hoặc Quản lý được vào)
            if (!UserSession.IsAdmin)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }

            TaiDuLieu();
        }

        private void TaiDuLieu()
        {
            LoadNguyenVatLieu();
            LoadPhieuNhapKho();
        }

        #region --- TAB 1: NGUYÊN VẬT LIỆU ---

        private void LoadNguyenVatLieu()
        {
            try
            {
                using (SqlConnection conn = Db.CreateConnection())
                {
                    string sql = "SELECT MaNVL, TenNVL, DonViTinh, SoLuongTon, MucCanhBao, TrangThai FROM dbo.NguyenVatLieu ORDER BY TenNVL";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        conn.Open();
                        DataTable dtRaw = new DataTable();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dtRaw);
                        }

                        DataTable dtDisplay = dtRaw.Clone();
                        dtDisplay.Columns.Add("TrangThaiText", typeof(string));

                        foreach (DataRow r in dtRaw.Rows)
                        {
                            DataRow nr = dtDisplay.NewRow();
                            nr["MaNVL"] = r["MaNVL"];
                            nr["TenNVL"] = r["TenNVL"];
                            nr["DonViTinh"] = r["DonViTinh"];
                            nr["SoLuongTon"] = r["SoLuongTon"];
                            nr["MucCanhBao"] = r["MucCanhBao"];
                            nr["TrangThai"] = r["TrangThai"];

                            int trangThai = Convert.ToInt32(r["TrangThai"]);
                            nr["TrangThaiText"] = trangThai == 1 ? "Đang sử dụng" : "Ngừng sử dụng";
                            dtDisplay.Rows.Add(nr);
                        }

                        dgvNguyenVatLieu.AutoGenerateColumns = false;
                        dgvNguyenVatLieu.DataSource = dtDisplay;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách nguyên vật liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvNguyenVatLieu_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvNguyenVatLieu.CurrentRow != null && dgvNguyenVatLieu.CurrentRow.Index >= 0)
            {
                DataGridViewRow row = dgvNguyenVatLieu.CurrentRow;
                txtMaNVL.Text = row.Cells["colMaNVL"].Value != null ? row.Cells["colMaNVL"].Value.ToString() : "";
                txtTenNVL.Text = row.Cells["colTenNVL"].Value != null ? row.Cells["colTenNVL"].Value.ToString() : "";
                txtDVT.Text = row.Cells["colDVT"].Value != null ? row.Cells["colDVT"].Value.ToString() : "";
                txtMucCanhBao.Text = row.Cells["colMucCanhBao"].Value != null ? row.Cells["colMucCanhBao"].Value.ToString() : "";

                object trangThaiVal = row.Cells["colTrangThaiNVLText"].Value;
                chkTrangThaiNVL.Checked = trangThaiVal != null && trangThaiVal.ToString() == "Đang sử dụng";
            }
        }

        private void btnLamMoiNVL_Click(object sender, EventArgs e)
        {
            txtMaNVL.Text = "";
            txtTenNVL.Text = "";
            txtDVT.Text = "";
            txtMucCanhBao.Text = "10";
            chkTrangThaiNVL.Checked = true;
            txtTenNVL.Focus();
        }

        private void btnThemNVL_Click(object sender, EventArgs e)
        {
            btnLamMoiNVL_Click(sender, e);
        }

        private void btnSuaNVL_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaNVL.Text))
            {
                MessageBox.Show("Vui lòng chọn nguyên vật liệu cần sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnLuuNVL_Click(object sender, EventArgs e)
        {
            string ten = txtTenNVL.Text.Trim();
            string dvt = txtDVT.Text.Trim();
            if (string.IsNullOrEmpty(ten) || string.IsNullOrEmpty(dvt))
            {
                MessageBox.Show("Tên và Đơn vị tính không được để trống.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!float.TryParse(txtMucCanhBao.Text, out float mucCanhBao))
            {
                mucCanhBao = 10;
            }

            int trangThai = chkTrangThaiNVL.Checked ? 1 : 0;
            bool isUpdate = int.TryParse(txtMaNVL.Text, out int maNVL);

            try
            {
                using (SqlConnection conn = Db.CreateConnection())
                {
                    conn.Open();
                    string sqlSave = isUpdate
                        ? "UPDATE dbo.NguyenVatLieu SET TenNVL = @TenNVL, DonViTinh = @DVT, MucCanhBao = @MucCanhBao, TrangThai = @TrangThai WHERE MaNVL = @MaNVL"
                        : "INSERT INTO dbo.NguyenVatLieu (TenNVL, DonViTinh, MucCanhBao, TrangThai) VALUES (@TenNVL, @DVT, @MucCanhBao, @TrangThai)";

                    using (SqlCommand cmdSave = new SqlCommand(sqlSave, conn))
                    {
                        cmdSave.Parameters.AddWithValue("@TenNVL", ten);
                        cmdSave.Parameters.AddWithValue("@DVT", dvt);
                        cmdSave.Parameters.AddWithValue("@MucCanhBao", mucCanhBao);
                        cmdSave.Parameters.AddWithValue("@TrangThai", trangThai);
                        if (isUpdate) cmdSave.Parameters.AddWithValue("@MaNVL", maNVL);

                        cmdSave.ExecuteNonQuery();
                    }
                }
                MessageBox.Show(isUpdate ? "Cập nhật thành công!" : "Thêm mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadNguyenVatLieu();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region --- TAB 2: LỊCH SỬ NHẬP KHO ---

        private void LoadPhieuNhapKho()
        {
            try
            {
                using (SqlConnection conn = Db.CreateConnection())
                {
                    string sql = @"SELECT p.MaPN, p.NgayNhap, p.MaNV, p.TongTien, p.GhiChu 
                                   FROM dbo.PhieuNhapKho p ORDER BY p.NgayNhap DESC";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        conn.Open();
                        DataTable dtRaw = new DataTable();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dtRaw);
                        }

                        DataTable dtDisplay = dtRaw.Clone();
                        dtDisplay.Columns.Add("TongTienFormatted", typeof(string));

                        foreach (DataRow r in dtRaw.Rows)
                        {
                            DataRow nr = dtDisplay.NewRow();
                            nr["MaPN"] = r["MaPN"];
                            nr["NgayNhap"] = r["NgayNhap"];
                            nr["MaNV"] = r["MaNV"];
                            nr["TongTien"] = r["TongTien"];
                            nr["GhiChu"] = r["GhiChu"];

                            decimal t = r["TongTien"] != DBNull.Value ? Convert.ToDecimal(r["TongTien"]) : 0;
                            nr["TongTienFormatted"] = t.ToString("N0") + " đ";
                            dtDisplay.Rows.Add(nr);
                        }

                        dgvPhieuNhap.AutoGenerateColumns = false;
                        dgvPhieuNhap.DataSource = dtDisplay;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải phiếu nhập: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private void btnNhapKho_Click(object sender, EventArgs e)
        {
            FrmNhapKho frm = new FrmNhapKho();
            if (frm.ShowDialog() == DialogResult.OK) 
            { 
                TaiDuLieu(); 
            }
        }
    }
}
