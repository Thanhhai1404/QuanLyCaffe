using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using QLCF.Data;
using QLCF.Helpers;
using QLCF.Models;

namespace QLCF.Forms
{
    public partial class FrmQuanLyMonAn : Form
    {
        private string selectedSourceImagePath = string.Empty;
        private string currentImageFileName = string.Empty;

        public FrmQuanLyMonAn(int defaultTab = 0)
        {
            InitializeComponent();

            if (defaultTab >= 0 && defaultTab < tabMain.TabCount)
            {
                tabMain.SelectedIndex = defaultTab;
            }

            // Gán sự kiện
            this.Load += FrmQuanLyMonAn_Load;
            this.btnDong.Click += (s, e) => this.Close();

            // Event Tab 1: Danh mục
            this.dgvDanhMuc.SelectionChanged += dgvDanhMuc_SelectionChanged;
            this.btnThemDanhMuc.Click += btnThemDanhMuc_Click;
            this.btnSuaDanhMuc.Click += btnSuaDanhMuc_Click;
            this.btnLuuDanhMuc.Click += btnLuuDanhMuc_Click;
            this.btnLamMoiDanhMuc.Click += btnLamMoiDanhMuc_Click;

            // Event Tab 2: Món ăn
            this.dgvMonAn.SelectionChanged += dgvMonAn_SelectionChanged;
            this.btnThemMon.Click += btnThemMon_Click;
            this.btnSuaMon.Click += btnSuaMon_Click;
            this.btnLuuMon.Click += btnLuuMon_Click;
            this.btnLamMoiMon.Click += btnLamMoiMon_Click;
            this.btnChonHinhAnh.Click += btnChonHinhAnh_Click;
            this.btnTimKiemMonQuanLy.Click += btnTimKiemMonQuanLy_Click;
            this.txtTimKiemMon.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) btnTimKiemMonQuanLy_Click(s, e); };
        }

        private void FrmQuanLyMonAn_Load(object sender, EventArgs e)
        {
            UITheme.ApplyStyleToForm(this);

            if (btnLuuDanhMuc != null) UITheme.ApplyStyleToButton(btnLuuDanhMuc, isPrimary: true);
            if (btnLuuMon != null) UITheme.ApplyStyleToButton(btnLuuMon, isPrimary: true);
            if (btnChonHinhAnh != null) UITheme.ApplyStyleToButton(btnChonHinhAnh);
            if (btnThemDanhMuc != null) UITheme.ApplyStyleToButton(btnThemDanhMuc);
            if (btnSuaDanhMuc != null) UITheme.ApplyStyleToButton(btnSuaDanhMuc);
            if (btnLamMoiDanhMuc != null) UITheme.ApplyStyleToButton(btnLamMoiDanhMuc);
            if (btnThemMon != null) UITheme.ApplyStyleToButton(btnThemMon);
            if (btnSuaMon != null) UITheme.ApplyStyleToButton(btnSuaMon);
            if (btnLamMoiMon != null) UITheme.ApplyStyleToButton(btnLamMoiMon);
            if (btnTimKiemMonQuanLy != null) UITheme.ApplyStyleToButton(btnTimKiemMonQuanLy);
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

            TaiDuLieu();
        }

        private void TaiDuLieu()
        {
            LoadDanhMuc();
            LoadDanhMucVaoComboBox();
            LoadMonAn();
        }

        #region --- TAB 1: QUẢN LÝ DANH MỤC ---

        public void LoadDanhMuc()
        {
            try
            {
                using (SqlConnection conn = Db.CreateConnection())
                {
                    string sql = "SELECT MaDM, TenDanhMuc, TrangThai FROM dbo.DanhMuc ORDER BY TenDanhMuc";
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
                            nr["MaDM"] = r["MaDM"];
                            nr["TenDanhMuc"] = r["TenDanhMuc"];
                            nr["TrangThai"] = r["TrangThai"];

                            int trangThai = Convert.ToInt32(r["TrangThai"]);
                            nr["TrangThaiText"] = trangThai == 1 ? "Đang sử dụng" : "Ngừng sử dụng";
                            dtDisplay.Rows.Add(nr);
                        }

                        dgvDanhMuc.AutoGenerateColumns = false;
                        dgvDanhMuc.DataSource = dtDisplay;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải danh sách danh mục.\nChi tiết lỗi: " + ex.Message,
                    "Lỗi cơ sở dữ liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void dgvDanhMuc_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDanhMuc.CurrentRow != null && dgvDanhMuc.CurrentRow.Index >= 0)
            {
                DataGridViewRow row = dgvDanhMuc.CurrentRow;
                txtMaDM.Text = row.Cells["colMaDM"].Value != null ? row.Cells["colMaDM"].Value.ToString() : "";
                txtTenDanhMuc.Text = row.Cells["colTenDanhMuc"].Value != null ? row.Cells["colTenDanhMuc"].Value.ToString() : "";

                object trangThaiVal = row.Cells["colTrangThaiDanhMucText"].Value;
                chkTrangThaiDanhMuc.Checked = trangThaiVal != null && trangThaiVal.ToString() == "Đang sử dụng";
            }
        }

        private void btnLamMoiDanhMuc_Click(object sender, EventArgs e)
        {
            LamMoiDanhMuc();
            LoadDanhMuc();
        }

        private void LamMoiDanhMuc()
        {
            txtMaDM.Text = string.Empty;
            txtTenDanhMuc.Text = string.Empty;
            chkTrangThaiDanhMuc.Checked = true;
            txtTenDanhMuc.Focus();
        }

        private void btnThemDanhMuc_Click(object sender, EventArgs e)
        {
            LamMoiDanhMuc();
        }

        private void btnSuaDanhMuc_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaDM.Text))
            {
                MessageBox.Show(
                    "Vui lòng chọn danh mục cần sửa từ danh sách bên phải.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }

        private void btnLuuDanhMuc_Click(object sender, EventArgs e)
        {
            string tenDM = txtTenDanhMuc.Text.Trim();
            if (string.IsNullOrEmpty(tenDM))
            {
                MessageBox.Show(
                    "Tên danh mục không được để trống.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                txtTenDanhMuc.Focus();
                return;
            }

            int trangThai = chkTrangThaiDanhMuc.Checked ? 1 : 0;
            bool isUpdate = int.TryParse(txtMaDM.Text, out int maDM);

            try
            {
                using (SqlConnection conn = Db.CreateConnection())
                {
                    conn.Open();

                    // Kiểm tra trùng tên danh mục
                    string sqlCheck = isUpdate
                        ? "SELECT COUNT(*) FROM dbo.DanhMuc WHERE TenDanhMuc = @TenDanhMuc AND MaDM <> @MaDM"
                        : "SELECT COUNT(*) FROM dbo.DanhMuc WHERE TenDanhMuc = @TenDanhMuc";

                    using (SqlCommand cmdCheck = new SqlCommand(sqlCheck, conn))
                    {
                        cmdCheck.Parameters.Add("@TenDanhMuc", SqlDbType.NVarChar, 100).Value = tenDM;
                        if (isUpdate)
                        {
                            cmdCheck.Parameters.Add("@MaDM", SqlDbType.Int).Value = maDM;
                        }

                        int count = Convert.ToInt32(cmdCheck.ExecuteScalar());
                        if (count > 0)
                        {
                            MessageBox.Show(
                                "Tên danh mục này đã tồn tại!",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning
                            );
                            txtTenDanhMuc.Focus();
                            return;
                        }
                    }

                    // Thực thi Insert hoặc Update
                    string sqlSave = isUpdate
                        ? "UPDATE dbo.DanhMuc SET TenDanhMuc = @TenDanhMuc, TrangThai = @TrangThai WHERE MaDM = @MaDM"
                        : "INSERT INTO dbo.DanhMuc (TenDanhMuc, TrangThai) VALUES (@TenDanhMuc, @TrangThai)";

                    using (SqlCommand cmdSave = new SqlCommand(sqlSave, conn))
                    {
                        cmdSave.Parameters.Add("@TenDanhMuc", SqlDbType.NVarChar, 100).Value = tenDM;
                        cmdSave.Parameters.Add("@TrangThai", SqlDbType.Bit).Value = trangThai;
                        if (isUpdate)
                        {
                            cmdSave.Parameters.Add("@MaDM", SqlDbType.Int).Value = maDM;
                        }

                        cmdSave.ExecuteNonQuery();
                    }
                }

                MessageBox.Show(
                    isUpdate ? "Cập nhật danh mục thành công!" : "Thêm mới danh mục thành công!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                LoadDanhMuc();
                LoadDanhMucVaoComboBox();
                LoadMonAn();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi khi lưu danh mục: " + ex.Message,
                    "Lỗi cơ sở dữ liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        #endregion

        #region --- TAB 2: QUẢN LÝ MÓN ĂN ---

        public void LoadDanhMucVaoComboBox()
        {
            try
            {
                using (SqlConnection conn = Db.CreateConnection())
                {
                    string sql = "SELECT MaDM, TenDanhMuc FROM dbo.DanhMuc WHERE TrangThai = 1 ORDER BY TenDanhMuc";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        conn.Open();
                        DataTable dt = new DataTable();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }

                        cboDanhMucMon.DisplayMember = "TenDanhMuc";
                        cboDanhMucMon.ValueMember = "MaDM";
                        cboDanhMucMon.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải danh sách danh mục vào ComboBox.\nChi tiết: " + ex.Message,
                    "Lỗi cơ sở dữ liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        public void LoadMonAn(string tuKhoa = null)
        {
            try
            {
                using (SqlConnection conn = Db.CreateConnection())
                {
                    string sql = @"
                        SELECT m.MaMon, m.TenMon, m.MaDM, d.TenDanhMuc, m.DonGia, m.HinhAnh, m.TrangThai
                        FROM dbo.MonAn m
                        INNER JOIN dbo.DanhMuc d ON m.MaDM = d.MaDM
                        WHERE (@TuKhoa IS NULL OR m.TenMon LIKE '%' + @TuKhoa + '%')
                        ORDER BY m.TenMon";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        if (string.IsNullOrWhiteSpace(tuKhoa))
                        {
                            cmd.Parameters.Add("@TuKhoa", SqlDbType.NVarChar, 100).Value = DBNull.Value;
                        }
                        else
                        {
                            cmd.Parameters.Add("@TuKhoa", SqlDbType.NVarChar, 100).Value = tuKhoa.Trim();
                        }

                        conn.Open();
                        DataTable dtRaw = new DataTable();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dtRaw);
                        }

                        DataTable dtDisplay = dtRaw.Clone();
                        dtDisplay.Columns.Add("DonGiaFormatted", typeof(string));
                        dtDisplay.Columns.Add("TrangThaiText", typeof(string));
                        dtDisplay.Columns.Add("HinhAnhImage", typeof(Image));

                        foreach (DataRow r in dtRaw.Rows)
                        {
                            DataRow nr = dtDisplay.NewRow();
                            nr["MaMon"] = r["MaMon"];
                            nr["TenMon"] = r["TenMon"];
                            nr["MaDM"] = r["MaDM"];
                            nr["TenDanhMuc"] = r["TenDanhMuc"];
                            nr["DonGia"] = r["DonGia"];
                            nr["HinhAnh"] = r["HinhAnh"];
                            nr["TrangThai"] = r["TrangThai"];

                            decimal donGia = r["DonGia"] != DBNull.Value ? Convert.ToDecimal(r["DonGia"]) : 0m;
                            nr["DonGiaFormatted"] = donGia.ToString("N0") + " đ";

                            int trangThai = Convert.ToInt32(r["TrangThai"]);
                            nr["TrangThaiText"] = trangThai == 1 ? "Đang kinh doanh" : "Ngừng bán";

                            string hinhAnhFile = r["HinhAnh"] != DBNull.Value ? r["HinhAnh"].ToString() : "";
                            nr["HinhAnhImage"] = LoadThumbnailImage(hinhAnhFile);

                            dtDisplay.Rows.Add(nr);
                        }

                        dgvMonAn.AutoGenerateColumns = false;
                        dgvMonAn.DataSource = dtDisplay;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải danh sách món ăn.\nChi tiết lỗi: " + ex.Message,
                    "Lỗi cơ sở dữ liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private Image LoadThumbnailImage(string fileName)
        {
            return ImageHelper.LoadImageSafely(fileName, 44, 44);
        }

        private void HienThiAnhPreview(string imagePathOrFileName)
        {
            if (picHinhAnhMon.Image != null)
            {
                picHinhAnhMon.Image.Dispose();
                picHinhAnhMon.Image = null;
            }

            picHinhAnhMon.Image = ImageHelper.LoadImageSafely(imagePathOrFileName, picHinhAnhMon.Width, picHinhAnhMon.Height);
        }

        private void btnChonHinhAnh_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Tệp hình ảnh (*.jpg; *.jpeg; *.png; *.bmp; *.webp)|*.jpg;*.jpeg;*.png;*.bmp;*.webp";
                ofd.Title = "Chọn hình ảnh thực tế cho món ăn";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    selectedSourceImagePath = ofd.FileName;
                    HienThiAnhPreview(selectedSourceImagePath);
                }
            }
        }

        private void dgvMonAn_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMonAn.CurrentRow != null && dgvMonAn.CurrentRow.Index >= 0)
            {
                DataGridViewRow row = dgvMonAn.CurrentRow;
                txtMaMon.Text = row.Cells["colMaMon"].Value != null ? row.Cells["colMaMon"].Value.ToString() : "";
                txtTenMon.Text = row.Cells["colTenMon"].Value != null ? row.Cells["colTenMon"].Value.ToString() : "";

                if (row.Cells["colTenDM"].Value != null)
                {
                    string tenDM = row.Cells["colTenDM"].Value.ToString();
                    cboDanhMucMon.Text = tenDM;
                }

                // Parse Đơn giá
                string donGiaStr = row.Cells["colDonGia"].Value != null ? row.Cells["colDonGia"].Value.ToString() : "0";
                donGiaStr = donGiaStr.Replace(" đ", "").Replace(".", "").Replace(",", "").Trim();
                if (decimal.TryParse(donGiaStr, out decimal donGiaVal))
                {
                    nudDonGia.Value = donGiaVal;
                }

                DataRowView drv = row.DataBoundItem as DataRowView;
                if (drv != null)
                {
                    currentImageFileName = drv["HinhAnh"] != DBNull.Value ? drv["HinhAnh"].ToString() : "";
                }
                else
                {
                    currentImageFileName = "";
                }

                selectedSourceImagePath = string.Empty;
                HienThiAnhPreview(currentImageFileName);

                object trangThaiVal = row.Cells["colTrangThaiMonText"].Value;
                chkTrangThaiMon.Checked = trangThaiVal != null && trangThaiVal.ToString() == "Đang kinh doanh";
            }
        }

        private void btnLamMoiMon_Click(object sender, EventArgs e)
        {
            LamMoiMonAn();
            LoadMonAn();
        }

        private void LamMoiMonAn()
        {
            txtMaMon.Text = string.Empty;
            txtTenMon.Text = string.Empty;
            if (cboDanhMucMon.Items.Count > 0)
            {
                cboDanhMucMon.SelectedIndex = 0;
            }
            nudDonGia.Value = 0;
            currentImageFileName = string.Empty;
            selectedSourceImagePath = string.Empty;
            if (picHinhAnhMon.Image != null)
            {
                picHinhAnhMon.Image.Dispose();
                picHinhAnhMon.Image = null;
            }
            chkTrangThaiMon.Checked = true;
            txtTimKiemMon.Text = string.Empty;
            txtTenMon.Focus();
        }

        private void btnThemMon_Click(object sender, EventArgs e)
        {
            LamMoiMonAn();
        }

        private void btnSuaMon_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaMon.Text))
            {
                MessageBox.Show(
                    "Vui lòng chọn món ăn cần sửa từ danh sách.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }

        private void btnLuuMon_Click(object sender, EventArgs e)
        {
            string tenMon = txtTenMon.Text.Trim();
            if (string.IsNullOrEmpty(tenMon))
            {
                MessageBox.Show(
                    "Tên món ăn không được để trống.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                txtTenMon.Focus();
                return;
            }

            if (cboDanhMucMon.SelectedValue == null)
            {
                MessageBox.Show(
                    "Vui lòng chọn danh mục cho món ăn.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                cboDanhMucMon.Focus();
                return;
            }

            int maDM = Convert.ToInt32(cboDanhMucMon.SelectedValue);
            decimal donGia = nudDonGia.Value;
            if (donGia < 0)
            {
                MessageBox.Show(
                    "Đơn giá món ăn không được nhỏ hơn 0.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                nudDonGia.Focus();
                return;
            }

            int trangThai = chkTrangThaiMon.Checked ? 1 : 0;
            bool isUpdate = int.TryParse(txtMaMon.Text, out int maMon);

            string hinhAnhToSave = currentImageFileName;
            if (!string.IsNullOrEmpty(selectedSourceImagePath) && File.Exists(selectedSourceImagePath))
            {
                try
                {
                    string savedPath = ImageHelper.SaveImageToAssets(selectedSourceImagePath, isUpdate ? maMon : 0);
                    if (!string.IsNullOrEmpty(savedPath))
                    {
                        hinhAnhToSave = savedPath;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Không thể lưu tệp hình ảnh vào thư mục Assets/Images.\nChi tiết: " + ex.Message,
                        "Lỗi lưu hình ảnh",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                }
            }

            try
            {
                using (SqlConnection conn = Db.CreateConnection())
                {
                    string sqlSave = isUpdate
                        ? @"UPDATE dbo.MonAn 
                            SET TenMon = @TenMon, MaDM = @MaDM, DonGia = @DonGia, HinhAnh = @HinhAnh, TrangThai = @TrangThai 
                            WHERE MaMon = @MaMon"
                        : @"INSERT INTO dbo.MonAn (TenMon, MaDM, DonGia, HinhAnh, TrangThai) 
                            VALUES (@TenMon, @MaDM, @DonGia, @HinhAnh, @TrangThai)";

                    using (SqlCommand cmdSave = new SqlCommand(sqlSave, conn))
                    {
                        cmdSave.Parameters.Add("@TenMon", SqlDbType.NVarChar, 100).Value = tenMon;
                        cmdSave.Parameters.Add("@MaDM", SqlDbType.Int).Value = maDM;
                        cmdSave.Parameters.Add("@DonGia", SqlDbType.Decimal).Value = donGia;
                        cmdSave.Parameters.Add("@HinhAnh", SqlDbType.NVarChar, 255).Value = string.IsNullOrEmpty(hinhAnhToSave) ? (object)DBNull.Value : hinhAnhToSave;
                        cmdSave.Parameters.Add("@TrangThai", SqlDbType.Bit).Value = trangThai;

                        if (isUpdate)
                        {
                            cmdSave.Parameters.Add("@MaMon", SqlDbType.Int).Value = maMon;
                        }

                        conn.Open();
                        cmdSave.ExecuteNonQuery();
                    }
                }

                MessageBox.Show(
                    isUpdate ? "Cập nhật món ăn thành công!" : "Thêm mới món ăn thành công!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                selectedSourceImagePath = string.Empty;
                LoadMonAn();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi khi lưu thông tin món ăn: " + ex.Message,
                    "Lỗi cơ sở dữ liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnTimKiemMonQuanLy_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiemMon.Text.Trim();
            LoadMonAn(tuKhoa);
        }

        #endregion
    }
}
