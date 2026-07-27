using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using QLCF.Data;
using QLCF.Models;

namespace QLCF.Forms
{
    public partial class FrmGopBan : Form
    {
        private readonly int _maBanChinh;
        private readonly string _tenBanChinh;
        private readonly int _maHDChinh;
        private readonly decimal _tamTinhChinh;

        public int SelectedMaBanPhu { get; private set; }
        public string SelectedTenBanPhu { get; private set; }

        public class BanPhuItem
        {
            public int MaBan { get; set; }
            public string TenBan { get; set; }
            public string TenKhuVuc { get; set; }
            public decimal TamTinh { get; set; }
            public string DisplayText => $"[{TenKhuVuc}] - {TenBan} | Tạm tính: {TamTinh.ToString("N0")} đ";

            public override string ToString()
            {
                return DisplayText;
            }
        }

        public FrmGopBan(int maBanChinh, string tenBanChinh, int maHDChinh, decimal tamTinhChinh)
        {
            InitializeComponent();

            _maBanChinh = maBanChinh;
            _tenBanChinh = tenBanChinh;
            _maHDChinh = maHDChinh;
            _tamTinhChinh = tamTinhChinh;

            this.Load += FrmGopBan_Load;
            this.btnXacNhanGop.Click += btnXacNhanGop_Click;
            this.btnHuy.Click += btnHuy_Click;
        }

        private void FrmGopBan_Load(object sender, EventArgs e)
        {
            lblTenBanChinhVal.Text = _tenBanChinh;
            lblMaHDChinhVal.Text = "HD" + _maHDChinh.ToString("D5");
            lblTamTinhChinhVal.Text = _tamTinhChinh.ToString("N0") + " đ";

            LoadDanhSachBanPhu();
        }

        private void LoadDanhSachBanPhu()
        {
            try
            {
                cboBanPhu.Items.Clear();

                using (SqlConnection conn = Db.CreateConnection())
                {
                    string sql = @"
                        SELECT MaBan, TenBan, TenKhuVuc, TamTinh
                        FROM dbo.vw_SoDoBan
                        WHERE DangSuDung = 1
                          AND MaHoaDonMo IS NOT NULL
                          AND LTRIM(RTRIM(TrangThai)) = N'Có khách'
                          AND MaBan <> @MaBanChinh
                        ORDER BY TenKhuVuc, TenBan";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.Add("@MaBanChinh", SqlDbType.Int).Value = _maBanChinh;

                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                cboBanPhu.Items.Add(new BanPhuItem
                                {
                                    MaBan = Convert.ToInt32(reader["MaBan"]),
                                    TenBan = reader["TenBan"].ToString(),
                                    TenKhuVuc = reader["TenKhuVuc"].ToString(),
                                    TamTinh = reader["TamTinh"] != DBNull.Value ? Convert.ToDecimal(reader["TamTinh"]) : 0m
                                });
                            }
                        }
                    }
                }

                if (cboBanPhu.Items.Count > 0)
                {
                    cboBanPhu.SelectedIndex = 0;
                    btnXacNhanGop.Enabled = true;
                }
                else
                {
                    btnXacNhanGop.Enabled = false;
                    MessageBox.Show(
                        "Hiện tại không có bàn phụ nào (đang có khách) khả dụng để gộp.",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải danh sách bàn phụ.\n\nChi tiết lỗi: " + ex.Message,
                    "Lỗi cơ sở dữ liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnXacNhanGop_Click(object sender, EventArgs e)
        {
            if (!(cboBanPhu.SelectedItem is BanPhuItem banPhu))
            {
                MessageBox.Show("Vui lòng chọn bàn phụ cần gộp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                $"Bạn có chắc muốn gộp [{banPhu.TenBan}] vào [{_tenBanChinh}] không?\nHóa đơn bàn phụ sẽ được gộp vào bàn chính.",
                "Xác nhận gộp bàn",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm != DialogResult.Yes)
            {
                return;
            }

            try
            {
                using (SqlConnection conn = Db.CreateConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("sp_GopBan", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@MaBanChinh", SqlDbType.Int).Value = _maBanChinh;
                        cmd.Parameters.Add("@MaBanPhu", SqlDbType.Int).Value = banPhu.MaBan;
                        cmd.Parameters.Add("@MaNV", SqlDbType.Int).Value = UserSession.MaNV;

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                SelectedMaBanPhu = banPhu.MaBan;
                SelectedTenBanPhu = banPhu.TenBan;

                MessageBox.Show("Gộp bàn thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Gộp bàn thất bại.\n\nChi tiết lỗi: " + ex.Message,
                    "Lỗi cơ sở dữ liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
