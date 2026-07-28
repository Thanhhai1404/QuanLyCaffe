using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using QLCF.Data;
using QLCF.Helpers;
using QLCF.Models;

namespace QLCF.Forms
{
    public partial class FrmResetMatKhauNhanVien : Form
    {
        private readonly int _maNVCanReset;
        private readonly string _tenDangNhap;
        private readonly string _hoTen;

        public FrmResetMatKhauNhanVien(int maNVCanReset, string tenDangNhap, string hoTen)
        {
            InitializeComponent();

            _maNVCanReset = maNVCanReset;
            _tenDangNhap = tenDangNhap;
            _hoTen = hoTen;

            this.Load += FrmResetMatKhauNhanVien_Load;
            this.chkHienMatKhau.CheckedChanged += chkHienMatKhau_CheckedChanged;
            this.btnXacNhanReset.Click += btnXacNhanReset_Click;
            this.btnHuy.Click += (s, e) => this.Close();
        }

        private void FrmResetMatKhauNhanVien_Load(object sender, EventArgs e)
        {
            if (!UserSession.IsAdmin)
            {
                MessageBox.Show(
                    "Bạn không có quyền truy cập chức năng này.",
                    "Truy cập bị từ chối",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                this.DialogResult = DialogResult.Cancel;
                this.Close();
                return;
            }

            lblThongTinNhanVien.Text = $"Reset mật khẩu cho tài khoản:\n👉 {_tenDangNhap} ({_hoTen})";
        }

        private void chkHienMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            txtMatKhauMoi.UseSystemPasswordChar = !chkHienMatKhau.Checked;
            txtXacNhanMatKhauMoi.UseSystemPasswordChar = !chkHienMatKhau.Checked;
        }

        private void btnXacNhanReset_Click(object sender, EventArgs e)
        {
            if (!UserSession.IsAdmin)
            {
                MessageBox.Show("Bạn không có quyền Admin.", "Lỗi phân quyền", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string matKhauMoi = txtMatKhauMoi.Text;
            string xacNhan = txtXacNhanMatKhauMoi.Text;

            if (string.IsNullOrWhiteSpace(matKhauMoi))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu mới.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhauMoi.Focus();
                return;
            }

            if (matKhauMoi.Length < 6)
            {
                MessageBox.Show("Mật khẩu mới phải có tối thiểu 6 ký tự.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhauMoi.Focus();
                return;
            }

            if (matKhauMoi != xacNhan)
            {
                MessageBox.Show("Xác nhận mật khẩu mới không khớp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtXacNhanMatKhauMoi.Focus();
                return;
            }

            try
            {
                string hashMoi = PasswordHelper.HashPassword(matKhauMoi);

                using (SqlConnection conn = Db.CreateConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("dbo.sp_ResetMatKhauNhanVien", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@MaNVThucHien", SqlDbType.Int).Value = UserSession.MaNV;
                        cmd.Parameters.Add("@MaNVCanReset", SqlDbType.Int).Value = _maNVCanReset;
                        cmd.Parameters.Add("@MatKhauHashMoi", SqlDbType.VarChar, 255).Value = hashMoi;

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show(
                    "Reset mật khẩu thành công.",
                    "Thành công",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    $"Lỗi CSDL khi reset mật khẩu:\n{ex.Message}",
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
    }
}
