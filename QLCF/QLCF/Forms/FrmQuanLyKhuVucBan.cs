using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using QLCF.Data;
using QLCF.Models;

namespace QLCF.Forms
{
    public partial class FrmQuanLyKhuVucBan : Form
    {
        public FrmQuanLyKhuVucBan()
        {
            InitializeComponent();

            // Gán sự kiện Form
            this.Load += FrmQuanLyKhuVucBan_Load;
            this.btnDong.Click += (s, e) => this.Close();

            // Event Tab 1: Khu vực
            this.dgvKhuVuc.SelectionChanged += dgvKhuVuc_SelectionChanged;
            this.btnThemKhuVuc.Click += btnThemKhuVuc_Click;
            this.btnSuaKhuVuc.Click += btnSuaKhuVuc_Click;
            this.btnLuuKhuVuc.Click += btnLuuKhuVuc_Click;
            this.btnLamMoiKhuVuc.Click += btnLamMoiKhuVuc_Click;

            // Event Tab 2: Bàn
            this.dgvBan.SelectionChanged += dgvBan_SelectionChanged;
            this.btnThemBan.Click += btnThemBan_Click;
            this.btnSuaBan.Click += btnSuaBan_Click;
            this.btnLuuBan.Click += btnLuuBan_Click;
            this.btnLamMoiBan.Click += btnLamMoiBan_Click;
            this.btnTimKiemBan.Click += btnTimKiemBan_Click;
            this.txtTimKiemBan.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) btnTimKiemBan_Click(s, e); };
        }

        private void FrmQuanLyKhuVucBan_Load(object sender, EventArgs e)
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

            // Mặc định chọn Trống cho combobox trạng thái đặt bàn
            if (cboTrangThaiDatBan.Items.Count > 0)
            {
                cboTrangThaiDatBan.SelectedIndex = 0;
            }

            TaiDuLieu();
        }

        private void TaiDuLieu()
        {
            LoadKhuVuc();
            LoadKhuVucVaoComboBox();
            LoadBan();
        }

        #region --- TAB 1: QUẢN LÝ KHU VỰC ---

        public void LoadKhuVuc()
        {
            try
            {
                using (SqlConnection conn = Db.CreateConnection())
                {
                    string sql = "SELECT MaKV, TenKhuVuc, TrangThai FROM dbo.KhuVuc ORDER BY TenKhuVuc";
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
                            nr["MaKV"] = r["MaKV"];
                            nr["TenKhuVuc"] = r["TenKhuVuc"];
                            nr["TrangThai"] = r["TrangThai"];

                            int trangThai = Convert.ToInt32(r["TrangThai"]);
                            nr["TrangThaiText"] = trangThai == 1 ? "Đang sử dụng" : "Ngừng sử dụng";
                            dtDisplay.Rows.Add(nr);
                        }

                        dgvKhuVuc.AutoGenerateColumns = false;
                        dgvKhuVuc.DataSource = dtDisplay;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải danh sách khu vực.\nChi tiết lỗi: " + ex.Message,
                    "Lỗi cơ sở dữ liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void dgvKhuVuc_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvKhuVuc.CurrentRow != null && dgvKhuVuc.CurrentRow.Index >= 0)
            {
                DataGridViewRow row = dgvKhuVuc.CurrentRow;
                txtMaKV.Text = row.Cells["colMaKV"].Value != null ? row.Cells["colMaKV"].Value.ToString() : "";
                txtTenKhuVuc.Text = row.Cells["colTenKhuVuc"].Value != null ? row.Cells["colTenKhuVuc"].Value.ToString() : "";

                object trangThaiVal = row.Cells["colTrangThaiKhuVucText"].Value;
                chkTrangThaiKhuVuc.Checked = trangThaiVal != null && trangThaiVal.ToString() == "Đang sử dụng";
            }
        }

        private void btnLamMoiKhuVuc_Click(object sender, EventArgs e)
        {
            LamMoiKhuVuc();
            LoadKhuVuc();
        }

        private void LamMoiKhuVuc()
        {
            txtMaKV.Text = string.Empty;
            txtTenKhuVuc.Text = string.Empty;
            chkTrangThaiKhuVuc.Checked = true;
            txtTenKhuVuc.Focus();
        }

        private void btnThemKhuVuc_Click(object sender, EventArgs e)
        {
            LamMoiKhuVuc();
        }

        private void btnSuaKhuVuc_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaKV.Text))
            {
                MessageBox.Show(
                    "Vui lòng chọn khu vực cần sửa từ danh sách bên phải.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }

        private void btnLuuKhuVuc_Click(object sender, EventArgs e)
        {
            string tenKV = txtTenKhuVuc.Text.Trim();
            if (string.IsNullOrEmpty(tenKV))
            {
                MessageBox.Show(
                    "Tên khu vực không được để trống.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                txtTenKhuVuc.Focus();
                return;
            }

            int trangThaiMoi = chkTrangThaiKhuVuc.Checked ? 1 : 0;
            bool isUpdate = int.TryParse(txtMaKV.Text, out int maKV);

            try
            {
                using (SqlConnection conn = Db.CreateConnection())
                {
                    conn.Open();

                    // Kiểm tra trùng tên khu vực
                    string sqlCheck = isUpdate
                        ? "SELECT COUNT(*) FROM dbo.KhuVuc WHERE TenKhuVuc = @TenKhuVuc AND MaKV <> @MaKV"
                        : "SELECT COUNT(*) FROM dbo.KhuVuc WHERE TenKhuVuc = @TenKhuVuc";

                    using (SqlCommand cmdCheck = new SqlCommand(sqlCheck, conn))
                    {
                        cmdCheck.Parameters.Add("@TenKhuVuc", SqlDbType.NVarChar, 50).Value = tenKV;
                        if (isUpdate)
                        {
                            cmdCheck.Parameters.Add("@MaKV", SqlDbType.Int).Value = maKV;
                        }

                        int count = Convert.ToInt32(cmdCheck.ExecuteScalar());
                        if (count > 0)
                        {
                            MessageBox.Show(
                                "Tên khu vực này đã tồn tại!",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning
                            );
                            txtTenKhuVuc.Focus();
                            return;
                        }
                    }

                    // Nếu là cập nhật và muốn ngừng sử dụng (trangThaiMoi = 0):
                    // Phải kiểm tra xem khu vực đó có còn bàn DangSuDung = 1 không.
                    if (isUpdate && trangThaiMoi == 0)
                    {
                        string sqlCheckBan = "SELECT COUNT(*) FROM dbo.Ban WHERE MaKV = @MaKV AND DangSuDung = 1";
                        using (SqlCommand cmdCheckBan = new SqlCommand(sqlCheckBan, conn))
                        {
                            cmdCheckBan.Parameters.Add("@MaKV", SqlDbType.Int).Value = maKV;
                            int countBan = Convert.ToInt32(cmdCheckBan.ExecuteScalar());
                            if (countBan > 0)
                            {
                                MessageBox.Show(
                                    "Không thể ngừng sử dụng khu vực khi vẫn còn bàn đang sử dụng.",
                                    "Cảnh báo",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning
                                );
                                chkTrangThaiKhuVuc.Checked = true;
                                return;
                            }
                        }
                    }

                    // Thực thi Insert / Update
                    string sqlSave = isUpdate
                        ? "UPDATE dbo.KhuVuc SET TenKhuVuc = @TenKhuVuc, TrangThai = @TrangThai WHERE MaKV = @MaKV"
                        : "INSERT INTO dbo.KhuVuc (TenKhuVuc, TrangThai) VALUES (@TenKhuVuc, @TrangThai)";

                    using (SqlCommand cmdSave = new SqlCommand(sqlSave, conn))
                    {
                        cmdSave.Parameters.Add("@TenKhuVuc", SqlDbType.NVarChar, 50).Value = tenKV;
                        cmdSave.Parameters.Add("@TrangThai", SqlDbType.Bit).Value = trangThaiMoi;
                        if (isUpdate)
                        {
                            cmdSave.Parameters.Add("@MaKV", SqlDbType.Int).Value = maKV;
                        }

                        cmdSave.ExecuteNonQuery();
                    }
                }

                MessageBox.Show(
                    isUpdate ? "Cập nhật khu vực thành công!" : "Thêm mới khu vực thành công!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                LoadKhuVuc();
                LoadKhuVucVaoComboBox();
                LoadBan();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi khi lưu khu vực: " + ex.Message,
                    "Lỗi cơ sở dữ liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        #endregion

        #region --- TAB 2: QUẢN LÝ BÀN ---

        public void LoadKhuVucVaoComboBox()
        {
            try
            {
                using (SqlConnection conn = Db.CreateConnection())
                {
                    string sql = "SELECT MaKV, TenKhuVuc FROM dbo.KhuVuc WHERE TrangThai = 1 ORDER BY TenKhuVuc";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        conn.Open();
                        DataTable dt = new DataTable();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }

                        cboKhuVucBan.DisplayMember = "TenKhuVuc";
                        cboKhuVucBan.ValueMember = "MaKV";
                        cboKhuVucBan.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải danh sách khu vực vào ComboBox.\nChi tiết: " + ex.Message,
                    "Lỗi cơ sở dữ liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        public void LoadBan(string tuKhoa = null)
        {
            try
            {
                using (SqlConnection conn = Db.CreateConnection())
                {
                    string sql = @"
                        SELECT b.MaBan, b.TenBan, b.MaKV, k.TenKhuVuc, b.TrangThai, b.DangSuDung
                        FROM dbo.Ban b
                        INNER JOIN dbo.KhuVuc k ON b.MaKV = k.MaKV
                        WHERE (@TuKhoa IS NULL OR b.TenBan LIKE '%' + @TuKhoa + '%')
                        ORDER BY k.TenKhuVuc, b.TenBan";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        if (string.IsNullOrWhiteSpace(tuKhoa))
                        {
                            cmd.Parameters.Add("@TuKhoa", SqlDbType.NVarChar, 50).Value = DBNull.Value;
                        }
                        else
                        {
                            cmd.Parameters.Add("@TuKhoa", SqlDbType.NVarChar, 50).Value = tuKhoa.Trim();
                        }

                        conn.Open();
                        DataTable dtRaw = new DataTable();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dtRaw);
                        }

                        DataTable dtDisplay = dtRaw.Clone();
                        dtDisplay.Columns.Add("DangSuDungText", typeof(string));

                        foreach (DataRow r in dtRaw.Rows)
                        {
                            DataRow nr = dtDisplay.NewRow();
                            nr["MaBan"] = r["MaBan"];
                            nr["TenBan"] = r["TenBan"];
                            nr["MaKV"] = r["MaKV"];
                            nr["TenKhuVuc"] = r["TenKhuVuc"];
                            nr["TrangThai"] = r["TrangThai"];
                            nr["DangSuDung"] = r["DangSuDung"];

                            int dangSuDung = Convert.ToInt32(r["DangSuDung"]);
                            nr["DangSuDungText"] = dangSuDung == 1 ? "Đang sử dụng" : "Ngừng sử dụng";

                            dtDisplay.Rows.Add(nr);
                        }

                        dgvBan.AutoGenerateColumns = false;
                        dgvBan.DataSource = dtDisplay;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải danh sách bàn.\nChi tiết lỗi: " + ex.Message,
                    "Lỗi cơ sở dữ liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void dgvBan_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvBan.CurrentRow != null && dgvBan.CurrentRow.Index >= 0)
            {
                DataGridViewRow row = dgvBan.CurrentRow;
                txtMaBan.Text = row.Cells["colMaBan"].Value != null ? row.Cells["colMaBan"].Value.ToString() : "";
                txtTenBan.Text = row.Cells["colTenBan"].Value != null ? row.Cells["colTenBan"].Value.ToString() : "";

                if (row.Cells["colTenKhuVucBan"].Value != null)
                {
                    string tenKV = row.Cells["colTenKhuVucBan"].Value.ToString();
                    cboKhuVucBan.Text = tenKV;
                }

                object dangSuDungVal = row.Cells["colDangSuDungText"].Value;
                chkDangSuDungBan.Checked = dangSuDungVal != null && dangSuDungVal.ToString() == "Đang sử dụng";

                string trangThai = row.Cells["colTrangThaiBan"].Value != null ? row.Cells["colTrangThaiBan"].Value.ToString() : "Trống";

                if (trangThai == "Có khách")
                {
                    lblTrangThaiBanWarning.Visible = true;
                    cboTrangThaiDatBan.Enabled = false;
                    chkDangSuDungBan.Enabled = false;
                    if (cboTrangThaiDatBan.Items.Contains("Trống"))
                    {
                        cboTrangThaiDatBan.SelectedItem = "Trống";
                    }
                }
                else
                {
                    lblTrangThaiBanWarning.Visible = false;
                    cboTrangThaiDatBan.Enabled = true;
                    chkDangSuDungBan.Enabled = true;

                    if (trangThai == "Đặt trước" && cboTrangThaiDatBan.Items.Contains("Đặt trước"))
                    {
                        cboTrangThaiDatBan.SelectedItem = "Đặt trước";
                    }
                    else if (cboTrangThaiDatBan.Items.Contains("Trống"))
                    {
                        cboTrangThaiDatBan.SelectedItem = "Trống";
                    }
                }
            }
        }

        private void btnLamMoiBan_Click(object sender, EventArgs e)
        {
            LamMoiBan();
            LoadBan();
        }

        private void LamMoiBan()
        {
            txtMaBan.Text = string.Empty;
            txtTenBan.Text = string.Empty;
            if (cboKhuVucBan.Items.Count > 0)
            {
                cboKhuVucBan.SelectedIndex = 0;
            }
            if (cboTrangThaiDatBan.Items.Count > 0)
            {
                cboTrangThaiDatBan.SelectedIndex = 0;
            }
            cboTrangThaiDatBan.Enabled = true;
            chkDangSuDungBan.Enabled = true;
            chkDangSuDungBan.Checked = true;
            lblTrangThaiBanWarning.Visible = false;
            txtTimKiemBan.Text = string.Empty;
            txtTenBan.Focus();
        }

        private void btnThemBan_Click(object sender, EventArgs e)
        {
            LamMoiBan();
        }

        private void btnSuaBan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaBan.Text))
            {
                MessageBox.Show(
                    "Vui lòng chọn bàn cần sửa từ danh sách.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }

        private void btnLuuBan_Click(object sender, EventArgs e)
        {
            string tenBan = txtTenBan.Text.Trim();
            if (string.IsNullOrEmpty(tenBan))
            {
                MessageBox.Show(
                    "Tên bàn không được để trống.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                txtTenBan.Focus();
                return;
            }

            if (cboKhuVucBan.SelectedValue == null)
            {
                MessageBox.Show(
                    "Vui lòng chọn khu vực cho bàn.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                cboKhuVucBan.Focus();
                return;
            }

            int maKV = Convert.ToInt32(cboKhuVucBan.SelectedValue);
            int dangSuDungMoi = chkDangSuDungBan.Checked ? 1 : 0;
            bool isUpdate = int.TryParse(txtMaBan.Text, out int maBan);
            string trangThaiMoi = cboTrangThaiDatBan.SelectedItem != null ? cboTrangThaiDatBan.SelectedItem.ToString() : "Trống";

            try
            {
                using (SqlConnection conn = Db.CreateConnection())
                {
                    conn.Open();

                    if (isUpdate)
                    {
                        // Kiểm tra xem bàn có hóa đơn mở không (TrangThai = 0 trong HoaDon)
                        string sqlCheckHD = "SELECT COUNT(*) FROM dbo.HoaDon WHERE MaBan = @MaBan AND TrangThai = 0";
                        using (SqlCommand cmdCheckHD = new SqlCommand(sqlCheckHD, conn))
                        {
                            cmdCheckHD.Parameters.Add("@MaBan", SqlDbType.Int).Value = maBan;
                            int countHD = Convert.ToInt32(cmdCheckHD.ExecuteScalar());

                            if (countHD > 0)
                            {
                                // Lấy trạng thái & DangSuDung hiện tại trong DB
                                string sqlGetCurrent = "SELECT TrangThai, DangSuDung FROM dbo.Ban WHERE MaBan = @MaBan";
                                using (SqlCommand cmdGet = new SqlCommand(sqlGetCurrent, conn))
                                {
                                    cmdGet.Parameters.Add("@MaBan", SqlDbType.Int).Value = maBan;
                                    using (SqlDataReader dr = cmdGet.ExecuteReader())
                                    {
                                        if (dr.Read())
                                        {
                                            string trangThaiDB = dr["TrangThai"].ToString();
                                            int dangSuDungDB = Convert.ToInt32(dr["DangSuDung"]);

                                            // Nếu người dùng muốn đổi trạng thái hoặc ngừng sử dụng
                                            if (dangSuDungMoi != dangSuDungDB || (trangThaiMoi != trangThaiDB && trangThaiDB != "Có khách"))
                                            {
                                                MessageBox.Show(
                                                    "Không thể thay đổi trạng thái hoặc ngừng sử dụng bàn đang có hóa đơn mở.",
                                                    "Cảnh báo",
                                                    MessageBoxButtons.OK,
                                                    MessageBoxIcon.Warning
                                                );
                                                return;
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        // Nếu bàn đang "Có khách", giữ nguyên trạng thái "Có khách" trong DB
                        string sqlGetStatus = "SELECT TrangThai FROM dbo.Ban WHERE MaBan = @MaBan";
                        using (SqlCommand cmdStatus = new SqlCommand(sqlGetStatus, conn))
                        {
                            cmdStatus.Parameters.Add("@MaBan", SqlDbType.Int).Value = maBan;
                            object st = cmdStatus.ExecuteScalar();
                            if (st != null && st.ToString() == "Có khách")
                            {
                                trangThaiMoi = "Có khách";
                            }
                        }

                        // Kiểm tra trùng tên bàn trong cùng khu vực
                        string sqlCheckName = "SELECT COUNT(*) FROM dbo.Ban WHERE TenBan = @TenBan AND MaKV = @MaKV AND MaBan <> @MaBan";
                        using (SqlCommand cmdCheckName = new SqlCommand(sqlCheckName, conn))
                        {
                            cmdCheckName.Parameters.Add("@TenBan", SqlDbType.NVarChar, 50).Value = tenBan;
                            cmdCheckName.Parameters.Add("@MaKV", SqlDbType.Int).Value = maKV;
                            cmdCheckName.Parameters.Add("@MaBan", SqlDbType.Int).Value = maBan;

                            int countName = Convert.ToInt32(cmdCheckName.ExecuteScalar());
                            if (countName > 0)
                            {
                                MessageBox.Show(
                                    "Tên bàn này đã tồn tại trong khu vực được chọn!",
                                    "Thông báo",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning
                                );
                                txtTenBan.Focus();
                                return;
                            }
                        }

                        // thực hiện UPDATE
                        string sqlUpdate = @"UPDATE dbo.Ban 
                                             SET TenBan = @TenBan, MaKV = @MaKV, TrangThai = @TrangThai, DangSuDung = @DangSuDung 
                                             WHERE MaBan = @MaBan";
                        using (SqlCommand cmdUpdate = new SqlCommand(sqlUpdate, conn))
                        {
                            cmdUpdate.Parameters.Add("@TenBan", SqlDbType.NVarChar, 50).Value = tenBan;
                            cmdUpdate.Parameters.Add("@MaKV", SqlDbType.Int).Value = maKV;
                            cmdUpdate.Parameters.Add("@TrangThai", SqlDbType.NVarChar, 20).Value = trangThaiMoi;
                            cmdUpdate.Parameters.Add("@DangSuDung", SqlDbType.Bit).Value = dangSuDungMoi;
                            cmdUpdate.Parameters.Add("@MaBan", SqlDbType.Int).Value = maBan;

                            cmdUpdate.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        // Thêm bàn mới
                        string sqlCheckName = "SELECT COUNT(*) FROM dbo.Ban WHERE TenBan = @TenBan AND MaKV = @MaKV";
                        using (SqlCommand cmdCheckName = new SqlCommand(sqlCheckName, conn))
                        {
                            cmdCheckName.Parameters.Add("@TenBan", SqlDbType.NVarChar, 50).Value = tenBan;
                            cmdCheckName.Parameters.Add("@MaKV", SqlDbType.Int).Value = maKV;

                            int countName = Convert.ToInt32(cmdCheckName.ExecuteScalar());
                            if (countName > 0)
                            {
                                MessageBox.Show(
                                    "Tên bàn này đã tồn tại trong khu vực được chọn!",
                                    "Thông báo",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning
                                );
                                txtTenBan.Focus();
                                return;
                            }
                        }

                        string sqlInsert = @"INSERT INTO dbo.Ban (TenBan, MaKV, TrangThai, DangSuDung) 
                                             VALUES (@TenBan, @MaKV, N'Trống', 1)";
                        using (SqlCommand cmdInsert = new SqlCommand(sqlInsert, conn))
                        {
                            cmdInsert.Parameters.Add("@TenBan", SqlDbType.NVarChar, 50).Value = tenBan;
                            cmdInsert.Parameters.Add("@MaKV", SqlDbType.Int).Value = maKV;

                            cmdInsert.ExecuteNonQuery();
                        }
                    }
                }

                MessageBox.Show(
                    isUpdate ? "Cập nhật bàn thành công!" : "Thêm mới bàn thành công!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                LoadBan();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi khi lưu thông tin bàn: " + ex.Message,
                    "Lỗi cơ sở dữ liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnTimKiemBan_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiemBan.Text.Trim();
            LoadBan(tuKhoa);
        }

        #endregion
    }
}
