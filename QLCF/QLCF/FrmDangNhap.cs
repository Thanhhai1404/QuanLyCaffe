using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using QLCF.Data;
using QLCF.Helpers;
using QLCF.Models;

namespace QLCF
{
    public partial class FrmDangNhap : Form
    {
        public FrmDangNhap()
        {
            InitializeComponent();

            // Gán sự kiện cho các control bằng code sau InitializeComponent()
            this.Load += FrmDangNhap_Load;
            this.chkHienMatKhau.CheckedChanged += chkHienMatKhau_CheckedChanged;
            this.btnDangNhap.Click += btnDangNhap_Click;
            this.btnThoat.Click += btnThoat_Click;

            // Đặt nút Enter là Đăng nhập, nút Esc là Thoát
            this.AcceptButton = btnDangNhap;
            this.CancelButton = btnThoat;
        }

        private void FrmDangNhap_Load(object sender, EventArgs e)
        {
            UITheme.ApplyStyleToForm(this);
            UITheme.ApplyStyleToButton(btnDangNhap, isPrimary: true);
            UITheme.ApplyStyleToButton(btnThoat, isDanger: false);

            // Ký tự mật khẩu ẩn mặc định
            txtMatKhau.UseSystemPasswordChar = true;

            // Tự động focus vào txtTenDangNhap
            txtTenDangNhap.Focus();
        }

        private void chkHienMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            // Tick hiện mật khẩu, bỏ tick ẩn mật khẩu
            txtMatKhau.UseSystemPasswordChar = !chkHienMatKhau.Checked;
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string tenDangNhap = txtTenDangNhap.Text.Trim();
            string matKhau = txtMatKhau.Text;

            // 1. Kiểm tra rỗng tên đăng nhập
            if (string.IsNullOrEmpty(tenDangNhap))
            {
                MessageBox.Show(
                    "Vui lòng nhập tên đăng nhập.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                txtTenDangNhap.Focus();
                return;
            }

            // 1. Kiểm tra rỗng mật khẩu
            if (string.IsNullOrEmpty(matKhau))
            {
                MessageBox.Show(
                    "Vui lòng nhập mật khẩu.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                txtMatKhau.Focus();
                return;
            }

            // 2 & 3. Truy vấn SQL qua Stored Procedure sp_DangNhapLayThongTin
            try
            {
                int maNV = 0;
                string hoTen = "";
                string chucVu = "";
                string matKhauHash = "";
                bool timThayTaiKhoan = false;

                using (SqlConnection conn = Db.CreateConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("sp_DangNhapLayThongTin", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);

                        conn.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                timThayTaiKhoan = true;
                                maNV = Convert.ToInt32(reader["MaNV"]);
                                hoTen = reader["HoTen"].ToString();
                                chucVu = reader["ChucVu"].ToString();
                                matKhauHash = reader["MatKhauHash"].ToString().Trim();
                            }
                        }
                    }
                }

                // 4. Nếu không tìm thấy tài khoản (hoặc tài khoản đã bị khóa)
                if (!timThayTaiKhoan)
                {
                    MessageBox.Show(
                        "Tên đăng nhập không tồn tại hoặc tài khoản đã bị khóa.",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    txtTenDangNhap.Focus();
                    return;
                }

                // 5. Dùng PasswordHelper.VerifyPassword để kiểm tra mật khẩu
                bool isPasswordValid = PasswordHelper.VerifyPassword(matKhau, matKhauHash);

                if (!isPasswordValid)
                {
                    MessageBox.Show(
                        "Mật khẩu không chính xác.",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    txtMatKhau.Clear();
                    txtMatKhau.Focus();
                    return;
                }

                // 6. Đăng nhập thành công -> Lưu vào UserSession
                UserSession.MaNV = maNV;
                UserSession.HoTen = hoTen;
                UserSession.ChucVu = chucVu;

                // Ẩn FrmDangNhap và Mở FrmMain
                this.Hide();
                txtMatKhau.Clear();

                using (Forms.FrmMain frmMain = new Forms.FrmMain())
                {
                    frmMain.ShowDialog();
                }

                // Khi FrmMain đóng lại:
                // Nếu UserSession bị xóa (do đăng xuất) -> Hiện lại FrmDangNhap
                if (string.IsNullOrEmpty(UserSession.HoTen))
                {
                    txtTenDangNhap.Clear();
                    txtMatKhau.Clear();
                    txtTenDangNhap.Focus();
                    this.Show();
                }
                else
                {
                    // Đóng bằng nút X -> Đóng toàn bộ ứng dụng
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể kết nối hoặc truy vấn cơ sở dữ liệu.\n\nChi tiết: " + ex.Message,
                    "Lỗi cơ sở dữ liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            ThoatUngDung();
        }

        private void ThoatUngDung()
        {
            DialogResult dr = MessageBox.Show(
                "Bạn có muốn thoát ứng dụng không?",
                "Xác nhận thoát",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (dr == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}