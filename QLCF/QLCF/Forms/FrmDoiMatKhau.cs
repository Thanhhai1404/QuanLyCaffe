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
    public partial class FrmDoiMatKhau : Form
    {
        public FrmDoiMatKhau()
        {
            InitializeComponent();

            this.Load += FrmDoiMatKhau_Load;
            this.chkHienMatKhau.CheckedChanged += chkHienMatKhau_CheckedChanged;
            this.btnLuuMatKhau.Click += btnLuuMatKhau_Click;
            this.btnHuy.Click += btnHuy_Click;
        }

        private void FrmDoiMatKhau_Load(object sender, EventArgs e)
        {
            UITheme.ApplyStyleToForm(this);
            if (btnLuuMatKhau != null) UITheme.ApplyStyleToButton(btnLuuMatKhau, isPrimary: true);
            if (btnHuy != null) UITheme.ApplyStyleToButton(btnHuy, isDanger: false);
        }

        private void chkHienMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            bool hienMatKhau = chkHienMatKhau.Checked;
            txtMatKhauCu.UseSystemPasswordChar = !hienMatKhau;
            txtMatKhauMoi.UseSystemPasswordChar = !hienMatKhau;
            txtXacNhanMatKhauMoi.UseSystemPasswordChar = !hienMatKhau;
        }

        private void btnLuuMatKhau_Click(object sender, EventArgs e)
        {
            string matKhauCu = txtMatKhauCu.Text;
            string matKhauMoi = txtMatKhauMoi.Text;
            string xacNhanMoi = txtXacNhanMatKhauMoi.Text;

            // 1. Validate không được để trống
            if (string.IsNullOrWhiteSpace(matKhauCu) ||
                string.IsNullOrWhiteSpace(matKhauMoi) ||
                string.IsNullOrWhiteSpace(xacNhanMoi))
            {
                MessageBox.Show(
                    "Vui lòng nhập đầy đủ các trường mật khẩu.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            // 2. Validate độ dài mật khẩu mới
            if (matKhauMoi.Length < 6)
            {
                MessageBox.Show(
                    "Mật khẩu mới phải có tối thiểu 6 ký tự.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                txtMatKhauMoi.Focus();
                return;
            }

            // 3. Validate mật khẩu mới và xác nhận mật khẩu mới
            if (matKhauMoi != xacNhanMoi)
            {
                MessageBox.Show(
                    "Mật khẩu mới và xác nhận mật khẩu mới không trùng khớp.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                txtXacNhanMatKhauMoi.Focus();
                return;
            }

            // 4. Validate mật khẩu mới không trùng mật khẩu cũ
            if (matKhauMoi == matKhauCu)
            {
                MessageBox.Show(
                    "Mật khẩu mới không được trùng với mật khẩu cũ.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                txtMatKhauMoi.Focus();
                return;
            }

            try
            {
                // 5. Đọc chuỗi MatKhauHash hiện tại từ database
                string currentHash = GetCurrentPasswordHash(UserSession.MaNV);

                if (string.IsNullOrEmpty(currentHash))
                {
                    MessageBox.Show(
                        "Không tìm thấy thông tin tài khoản người dùng.",
                        "Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    return;
                }

                // 6. Kiểm tra mật khẩu cũ
                bool isOldPasswordValid = PasswordHelper.VerifyPassword(matKhauCu, currentHash);
                if (!isOldPasswordValid)
                {
                    MessageBox.Show(
                        "Mật khẩu cũ không chính xác.",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    txtMatKhauCu.Focus();
                    return;
                }

                // 7. Tạo chuỗi hash mới và gọi Stored Procedure dbo.sp_CapNhatMatKhau
                string newHash = PasswordHelper.HashPassword(matKhauMoi);
                CapNhatMatKhau(UserSession.MaNV, newHash);

                // 8. Thông báo thành công & Đăng xuất tài khoản
                MessageBox.Show(
                    "Đổi mật khẩu thành công. Vui lòng đăng nhập lại.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                UserSession.Clear();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Đã xảy ra lỗi trong quá trình đổi mật khẩu.\n\nChi tiết: " + ex.Message,
                    "Lỗi hệ thống",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private string GetCurrentPasswordHash(int maNV)
        {
            using (SqlConnection conn = Db.CreateConnection())
            {
                string sql = "SELECT MatKhauHash FROM dbo.NhanVien WHERE MaNV = @MaNV";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("@MaNV", SqlDbType.Int).Value = maNV;
                    conn.Open();
                    object result = cmd.ExecuteScalar();
                    return result != null ? result.ToString() : null;
                }
            }
        }

        private void CapNhatMatKhau(int maNV, string newHash)
        {
            using (SqlConnection conn = Db.CreateConnection())
            {
                using (SqlCommand cmd = new SqlCommand("dbo.sp_CapNhatMatKhau", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@MaNV", SqlDbType.Int).Value = maNV;
                    cmd.Parameters.Add("@MatKhauHashMoi", SqlDbType.VarChar, 255).Value = newHash;

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
