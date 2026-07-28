using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using QLCF.Data;
using QLCF.Helpers;
using QLCF.Models;

namespace QLCF.Forms
{
    public partial class FrmQuanLyNhanVien : Form
    {
        private DataTable _dtNhanVien;

        public FrmQuanLyNhanVien()
        {
            InitializeComponent();

            this.Load += FrmQuanLyNhanVien_Load;

            // Filter & Search events
            this.btnTimKiemNhanVien.Click += (s, e) => TimKiemNhanVien();
            this.btnLamMoiNhanVien.Click += (s, e) => { txtTimKiemNhanVien.Text = ""; cboLocVaiTro.SelectedIndex = 0; cboLocTrangThai.SelectedIndex = 0; LoadNhanVien(); };
            this.txtTimKiemNhanVien.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) TimKiemNhanVien(); };
            this.cboLocVaiTro.SelectedIndexChanged += (s, e) => TimKiemNhanVien();
            this.cboLocTrangThai.SelectedIndexChanged += (s, e) => TimKiemNhanVien();

            // DataGridView events
            this.dgvNhanVien.SelectionChanged += DgvNhanVien_SelectionChanged;
            this.dgvNhanVien.CellFormatting += DgvNhanVien_CellFormatting;

            // Form action events
            this.btnThemNhanVien.Click += (s, e) => ThemNhanVien();
            this.btnSuaNhanVien.Click += (s, e) => CapNhatNhanVien();
            this.btnKhoaMoTaiKhoan.Click += (s, e) => KhoaMoTaiKhoan();
            this.btnResetMatKhau.Click += (s, e) => ResetMatKhau();
            this.btnLamMoiFormNhanVien.Click += (s, e) => LamMoiForm();
            this.chkHienMatKhauKhoiTao.CheckedChanged += (s, e) => txtMatKhauKhoiTao.UseSystemPasswordChar = !chkHienMatKhauKhoiTao.Checked;
        }

        private void FrmQuanLyNhanVien_Load(object sender, EventArgs e)
        {
            if (!KiemTraQuyenAdmin()) return;

            InitComboBoxes();
            LamMoiForm();
            LoadNhanVien();
        }

        public bool KiemTraQuyenAdmin()
        {
            if (!UserSession.IsAdmin)
            {
                MessageBox.Show(
                    "Bạn không có quyền truy cập chức năng này.",
                    "Truy cập bị từ chối",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                this.Close();
                return false;
            }
            return true;
        }

        private void InitComboBoxes()
        {
            // Combobox Lọc Vai trò
            cboLocVaiTro.Items.Clear();
            cboLocVaiTro.Items.Add("Tất cả vai trò");
            cboLocVaiTro.Items.Add("Admin");
            cboLocVaiTro.Items.Add("NhanVien");
            cboLocVaiTro.SelectedIndex = 0;

            // Combobox Lọc Trạng thái
            cboLocTrangThai.Items.Clear();
            cboLocTrangThai.Items.Add("Tất cả trạng thái");
            cboLocTrangThai.Items.Add("Hoạt động");
            cboLocTrangThai.Items.Add("Đã khóa");
            cboLocTrangThai.SelectedIndex = 0;

            // Combobox Chức vụ bên panel Detail
            cboChucVuNhanVien.Items.Clear();
            cboChucVuNhanVien.Items.Add("NhanVien");
            cboChucVuNhanVien.Items.Add("Admin");
            cboChucVuNhanVien.SelectedIndex = 0;
        }

        // ====================================================================
        // LOAD VÀ TÌM KIẾM DỮ LIỆU NHÂN VIÊN
        // ====================================================================

        public void LoadNhanVien()
        {
            TimKiemNhanVien();
        }

        public void TimKiemNhanVien()
        {
            if (!UserSession.IsAdmin) return;

            try
            {
                string sql = @"
                    SELECT 
                        MaNV,
                        TenDangNhap,
                        HoTen,
                        ChucVu,
                        SoDienThoai,
                        TrangThai,
                        CASE WHEN TrangThai = 1 THEN N'Hoạt động' ELSE N'Đã khóa' END AS TrangThaiText,
                        NgayTao,
                        FORMAT(NgayTao, 'dd/MM/yyyy HH:mm') AS NgayTaoText
                    FROM dbo.NhanVien
                    WHERE 1=1";

                string tuKhoa = txtTimKiemNhanVien.Text.Trim();
                string locVaiTro = cboLocVaiTro.SelectedItem != null ? cboLocVaiTro.SelectedItem.ToString() : "Tất cả vai trò";
                string locTrangThai = cboLocTrangThai.SelectedItem != null ? cboLocTrangThai.SelectedItem.ToString() : "Tất cả trạng thái";

                if (!string.IsNullOrEmpty(tuKhoa))
                {
                    sql += " AND (TenDangNhap LIKE @TuKhoa OR HoTen LIKE @TuKhoa OR SoDienThoai LIKE @TuKhoa)";
                }

                if (locVaiTro == "Admin" || locVaiTro == "NhanVien")
                {
                    sql += " AND ChucVu = @ChucVu";
                }

                if (locTrangThai == "Hoạt động")
                {
                    sql += " AND TrangThai = 1";
                }
                else if (locTrangThai == "Đã khóa")
                {
                    sql += " AND TrangThai = 0";
                }

                sql += " ORDER BY MaNV DESC";

                using (SqlConnection conn = Db.CreateConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        if (!string.IsNullOrEmpty(tuKhoa))
                        {
                            cmd.Parameters.Add("@TuKhoa", SqlDbType.NVarChar, 100).Value = "%" + tuKhoa + "%";
                        }
                        if (locVaiTro == "Admin" || locVaiTro == "NhanVien")
                        {
                            cmd.Parameters.Add("@ChucVu", SqlDbType.NVarChar, 20).Value = locVaiTro;
                        }

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        _dtNhanVien = new DataTable();
                        adapter.Fill(_dtNhanVien);

                        dgvNhanVien.DataSource = _dtNhanVien;
                    }
                }

                if (dgvNhanVien.Rows.Count > 0)
                {
                    dgvNhanVien.ClearSelection();
                }
                LamMoiForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Lỗi khi tải danh sách nhân viên:\n{ex.Message}",
                    "Lỗi CSDL",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void DgvNhanVien_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvNhanVien.Rows.Count)
            {
                DataGridViewRow row = dgvNhanVien.Rows[e.RowIndex];
                if (row.DataBoundItem is DataRowView drv)
                {
                    bool trangThai = Convert.ToBoolean(drv["TrangThai"]);
                    if (!trangThai)
                    {
                        row.DefaultCellStyle.BackColor = Color.FromArgb(241, 245, 249); // Xám nhạt cho TK bị khóa
                        row.DefaultCellStyle.ForeColor = Color.FromArgb(148, 163, 184); // Chữ mờ
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = Color.White;
                        row.DefaultCellStyle.ForeColor = Color.Black;
                    }
                }
            }
        }

        private void DgvNhanVien_SelectionChanged(object sender, EventArgs e)
        {
            ChonNhanVien();
        }

        public void ChonNhanVien()
        {
            if (dgvNhanVien.SelectedRows.Count == 0) return;

            DataGridViewRow row = dgvNhanVien.SelectedRows[0];
            if (row.DataBoundItem is DataRowView drv)
            {
                txtMaNV.Text = drv["MaNV"].ToString();
                txtTenDangNhap.Text = drv["TenDangNhap"].ToString();
                txtTenDangNhap.ReadOnly = true;
                txtTenDangNhap.Enabled = false;

                txtHoTenNhanVien.Text = drv["HoTen"].ToString();
                txtSoDienThoaiNhanVien.Text = drv["SoDienThoai"] != DBNull.Value ? drv["SoDienThoai"].ToString() : "";

                string chucVu = drv["ChucVu"].ToString();
                cboChucVuNhanVien.SelectedItem = chucVu;

                bool trangThai = Convert.ToBoolean(drv["TrangThai"]);
                chkTrangThaiNhanVien.Checked = trangThai;
                chkTrangThaiNhanVien.Enabled = false;

                // Ẩn trường mật khẩu khi xem/sửa thông tin
                lblMatKhauKhoiTao.Visible = false;
                txtMatKhauKhoiTao.Visible = false;
                txtMatKhauKhoiTao.Text = "";
                chkHienMatKhauKhoiTao.Visible = false;

                // Chuyển nút bấm sang chế độ Sửa / Khóa / Reset
                btnThemNhanVien.Visible = false;
                btnSuaNhanVien.Visible = true;
                btnKhoaMoTaiKhoan.Visible = true;
                btnResetMatKhau.Visible = true;

                if (trangThai)
                {
                    btnKhoaMoTaiKhoan.Text = "🔒 Khóa tài khoản";
                    btnKhoaMoTaiKhoan.BackColor = Color.FromArgb(225, 29, 72); // Đỏ Rose
                }
                else
                {
                    btnKhoaMoTaiKhoan.Text = "🔓 Mở khóa tài khoản";
                    btnKhoaMoTaiKhoan.BackColor = Color.FromArgb(15, 118, 110); // Xanh Teal
                }
            }
        }

        public void LamMoiForm()
        {
            txtMaNV.Text = "";
            txtTenDangNhap.Text = "";
            txtTenDangNhap.ReadOnly = false;
            txtTenDangNhap.Enabled = true;

            txtHoTenNhanVien.Text = "";
            txtSoDienThoaiNhanVien.Text = "";
            cboChucVuNhanVien.SelectedItem = "NhanVien";

            chkTrangThaiNhanVien.Checked = true;
            chkTrangThaiNhanVien.Enabled = false;

            lblMatKhauKhoiTao.Visible = true;
            txtMatKhauKhoiTao.Visible = true;
            txtMatKhauKhoiTao.Enabled = true;
            txtMatKhauKhoiTao.Text = "";
            chkHienMatKhauKhoiTao.Visible = true;

            btnThemNhanVien.Visible = true;
            btnSuaNhanVien.Visible = false;
            btnKhoaMoTaiKhoan.Visible = false;
            btnResetMatKhau.Visible = false;

            if (dgvNhanVien.SelectedRows.Count > 0)
            {
                dgvNhanVien.ClearSelection();
            }
        }

        // ====================================================================
        // THAO TÁC THÊM / SỬA / KHÓA MỞ / RESET MẬT KHẨU
        // ====================================================================

        public void ThemNhanVien()
        {
            if (!KiemTraQuyenAdmin()) return;

            string tenDangNhap = txtTenDangNhap.Text.Trim();
            string hoTen = txtHoTenNhanVien.Text.Trim();
            string sdt = txtSoDienThoaiNhanVien.Text.Trim();
            string chucVu = cboChucVuNhanVien.SelectedItem != null ? cboChucVuNhanVien.SelectedItem.ToString() : "NhanVien";
            string matKhau = txtMatKhauKhoiTao.Text;

            // Validate
            if (string.IsNullOrWhiteSpace(tenDangNhap))
            {
                MessageBox.Show("Tên đăng nhập không được để trống.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenDangNhap.Focus();
                return;
            }

            if (tenDangNhap.Length < 3 || tenDangNhap.Length > 50)
            {
                MessageBox.Show("Tên đăng nhập phải dài từ 3 đến 50 ký tự.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenDangNhap.Focus();
                return;
            }

            if (tenDangNhap.Contains(" "))
            {
                MessageBox.Show("Tên đăng nhập không được chứa khoảng trắng.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenDangNhap.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(hoTen))
            {
                MessageBox.Show("Họ và tên nhân viên không được để trống.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTenNhanVien.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(matKhau))
            {
                MessageBox.Show("Mật khẩu khởi tạo không được để trống.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhauKhoiTao.Focus();
                return;
            }

            if (matKhau.Length < 6)
            {
                MessageBox.Show("Mật khẩu khởi tạo phải có tối thiểu 6 ký tự.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhauKhoiTao.Focus();
                return;
            }

            if (!string.IsNullOrEmpty(sdt) && !Regex.IsMatch(sdt, @"^\d{9,11}$"))
            {
                MessageBox.Show("Số điện thoại không hợp lệ (chỉ gồm 9-11 chữ số).", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoDienThoaiNhanVien.Focus();
                return;
            }

            try
            {
                string matKhauHash = PasswordHelper.HashPassword(matKhau);

                using (SqlConnection conn = Db.CreateConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("dbo.sp_TaoNhanVien", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@MaNVThucHien", SqlDbType.Int).Value = UserSession.MaNV;
                        cmd.Parameters.Add("@TenDangNhap", SqlDbType.VarChar, 50).Value = tenDangNhap;
                        cmd.Parameters.Add("@MatKhauHash", SqlDbType.VarChar, 255).Value = matKhauHash;
                        cmd.Parameters.Add("@HoTen", SqlDbType.NVarChar, 100).Value = hoTen;
                        cmd.Parameters.Add("@ChucVu", SqlDbType.NVarChar, 20).Value = chucVu;
                        cmd.Parameters.Add("@SoDienThoai", SqlDbType.VarChar, 15).Value = string.IsNullOrEmpty(sdt) ? (object)DBNull.Value : sdt;

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show(
                    $"Tạo tài khoản nhân viên [{tenDangNhap}] thành công!",
                    "Thành công",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                LoadNhanVien();
                LamMoiForm();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    $"Lỗi CSDL khi tạo nhân viên:\n{ex.Message}",
                    "Lỗi CSDL",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Đã xảy ra lỗi:\n{ex.Message}",
                    "Lỗi hệ thống",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        public void CapNhatNhanVien()
        {
            if (!KiemTraQuyenAdmin()) return;

            if (string.IsNullOrEmpty(txtMaNV.Text) || !int.TryParse(txtMaNV.Text, out int maNVCanSua))
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần sửa thông tin từ danh sách.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string hoTen = txtHoTenNhanVien.Text.Trim();
            string sdt = txtSoDienThoaiNhanVien.Text.Trim();
            string chucVu = cboChucVuNhanVien.SelectedItem != null ? cboChucVuNhanVien.SelectedItem.ToString() : "NhanVien";

            if (string.IsNullOrWhiteSpace(hoTen))
            {
                MessageBox.Show("Họ và tên nhân viên không được để trống.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTenNhanVien.Focus();
                return;
            }

            if (!string.IsNullOrEmpty(sdt) && !Regex.IsMatch(sdt, @"^\d{9,11}$"))
            {
                MessageBox.Show("Số điện thoại không hợp lệ (chỉ gồm 9-11 chữ số).", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoDienThoaiNhanVien.Focus();
                return;
            }

            DialogResult confirm = MessageBox.Show(
                $"Bạn có chắc muốn cập nhật thông tin cho nhân viên [{txtTenDangNhap.Text}] không?",
                "Xác nhận cập nhật",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm != DialogResult.Yes) return;

            try
            {
                using (SqlConnection conn = Db.CreateConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("dbo.sp_CapNhatThongTinNhanVien", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@MaNVThucHien", SqlDbType.Int).Value = UserSession.MaNV;
                        cmd.Parameters.Add("@MaNVCanSua", SqlDbType.Int).Value = maNVCanSua;
                        cmd.Parameters.Add("@HoTen", SqlDbType.NVarChar, 100).Value = hoTen;
                        cmd.Parameters.Add("@SoDienThoai", SqlDbType.VarChar, 15).Value = string.IsNullOrEmpty(sdt) ? (object)DBNull.Value : sdt;
                        cmd.Parameters.Add("@ChucVu", SqlDbType.NVarChar, 20).Value = chucVu;

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show(
                    "Cập nhật thông tin nhân viên thành công!",
                    "Thành công",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                // Nếu vừa sửa chính tài khoản đang đăng nhập
                if (maNVCanSua == UserSession.MaNV)
                {
                    UserSession.HoTen = hoTen;
                    UserSession.ChucVu = chucVu;
                }

                LoadNhanVien();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    $"Lỗi CSDL khi cập nhật nhân viên:\n{ex.Message}",
                    "Lỗi CSDL",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Đã xảy ra lỗi:\n{ex.Message}",
                    "Lỗi hệ thống",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        public void KhoaMoTaiKhoan()
        {
            if (!KiemTraQuyenAdmin()) return;

            if (string.IsNullOrEmpty(txtMaNV.Text) || !int.TryParse(txtMaNV.Text, out int maNVCanDoi))
            {
                MessageBox.Show("Vui lòng chọn nhân viên từ danh sách.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool trangThaiHienTai = chkTrangThaiNhanVien.Checked;
            bool trangThaiMoi = !trangThaiHienTai;
            string tenDangNhap = txtTenDangNhap.Text;

            string hoiMess = trangThaiHienTai
                ? $"Bạn có chắc muốn KHÓA tài khoản [{tenDangNhap}] không?"
                : $"Bạn có muốn MỞ KHÓA tài khoản [{tenDangNhap}] không?";

            DialogResult confirm = MessageBox.Show(
                hoiMess,
                "Xác nhận thay đổi trạng thái",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm != DialogResult.Yes) return;

            try
            {
                using (SqlConnection conn = Db.CreateConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("dbo.sp_DoiTrangThaiNhanVien", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@MaNVThucHien", SqlDbType.Int).Value = UserSession.MaNV;
                        cmd.Parameters.Add("@MaNVCanDoi", SqlDbType.Int).Value = maNVCanDoi;
                        cmd.Parameters.Add("@TrangThai", SqlDbType.Bit).Value = trangThaiMoi;

                        cmd.ExecuteNonQuery();
                    }
                }

                string thongBao = trangThaiMoi
                    ? $"Đã mở khóa tài khoản [{tenDangNhap}] thành công."
                    : $"Đã khóa tài khoản [{tenDangNhap}] thành công.";

                MessageBox.Show(thongBao, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadNhanVien();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    $"Lỗi CSDL khi thay đổi trạng thái tài khoản:\n{ex.Message}",
                    "Lỗi CSDL",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Đã xảy ra lỗi:\n{ex.Message}",
                    "Lỗi hệ thống",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        public void ResetMatKhau()
        {
            if (!KiemTraQuyenAdmin()) return;

            if (string.IsNullOrEmpty(txtMaNV.Text) || !int.TryParse(txtMaNV.Text, out int maNVCanReset))
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần reset mật khẩu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string tenDangNhap = txtTenDangNhap.Text;
            string hoTen = txtHoTenNhanVien.Text;

            using (FrmResetMatKhauNhanVien frmReset = new FrmResetMatKhauNhanVien(maNVCanReset, tenDangNhap, hoTen))
            {
                if (frmReset.ShowDialog(this) == DialogResult.OK)
                {
                    LoadNhanVien();
                }
            }
        }
    }
}
