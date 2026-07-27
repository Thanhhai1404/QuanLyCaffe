using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using QLCF.Data;
using QLCF.Models;

namespace QLCF.Forms
{
    public partial class FrmChuyenBan : Form
    {
        private readonly int _maBanNguon;
        private readonly string _tenBanNguon;
        private readonly int _maHD;
        private readonly decimal _tamTinh;

        public int SelectedMaBanDich { get; private set; }
        public string SelectedTenBanDich { get; private set; }

        public class BanDichItem
        {
            public int MaBan { get; set; }
            public string TenBan { get; set; }
            public string TenKhuVuc { get; set; }
            public string DisplayText => $"[{TenKhuVuc}] - {TenBan}";

            public override string ToString()
            {
                return DisplayText;
            }
        }

        public FrmChuyenBan(int maBanNguon, string tenBanNguon, int maHD, decimal tamTinh)
        {
            InitializeComponent();

            _maBanNguon = maBanNguon;
            _tenBanNguon = tenBanNguon;
            _maHD = maHD;
            _tamTinh = tamTinh;

            this.Load += FrmChuyenBan_Load;
            this.btnXacNhanChuyen.Click += btnXacNhanChuyen_Click;
            this.btnHuy.Click += btnHuy_Click;
        }

        private void FrmChuyenBan_Load(object sender, EventArgs e)
        {
            lblTenBanNguonVal.Text = _tenBanNguon;
            lblMaHDVal.Text = "HD" + _maHD.ToString("D5");
            lblTamTinhVal.Text = _tamTinh.ToString("N0") + " đ";

            LoadDanhSachBanDich();
        }

        private void LoadDanhSachBanDich()
        {
            try
            {
                cboBanDich.Items.Clear();

                using (SqlConnection conn = Db.CreateConnection())
                {
                    string sql = @"
                        SELECT MaBan, TenBan, TenKhuVuc
                        FROM dbo.vw_SoDoBan
                        WHERE DangSuDung = 1
                          AND LTRIM(RTRIM(TrangThai)) = N'Trống'
                          AND MaBan <> @MaBanNguon
                        ORDER BY TenKhuVuc, TenBan";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.Add("@MaBanNguon", SqlDbType.Int).Value = _maBanNguon;

                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                cboBanDich.Items.Add(new BanDichItem
                                {
                                    MaBan = Convert.ToInt32(reader["MaBan"]),
                                    TenBan = reader["TenBan"].ToString(),
                                    TenKhuVuc = reader["TenKhuVuc"].ToString()
                                });
                            }
                        }
                    }
                }

                if (cboBanDich.Items.Count > 0)
                {
                    cboBanDich.SelectedIndex = 0;
                    btnXacNhanChuyen.Enabled = true;
                }
                else
                {
                    btnXacNhanChuyen.Enabled = false;
                    MessageBox.Show(
                        "Hiện tại không có bàn trống nào khả dụng để chuyển tới.",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải danh sách bàn trống.\n\nChi tiết lỗi: " + ex.Message,
                    "Lỗi cơ sở dữ liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnXacNhanChuyen_Click(object sender, EventArgs e)
        {
            if (!(cboBanDich.SelectedItem is BanDichItem banDich))
            {
                MessageBox.Show("Vui lòng chọn bàn đích cần chuyển tới.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                $"Bạn có chắc muốn chuyển hóa đơn từ [{_tenBanNguon}] sang [{banDich.TenBan}] không?",
                "Xác nhận chuyển bàn",
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
                    using (SqlCommand cmd = new SqlCommand("sp_ChuyenBan", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@MaBanNguon", SqlDbType.Int).Value = _maBanNguon;
                        cmd.Parameters.Add("@MaBanDich", SqlDbType.Int).Value = banDich.MaBan;
                        cmd.Parameters.Add("@MaNV", SqlDbType.Int).Value = UserSession.MaNV;

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                SelectedMaBanDich = banDich.MaBan;
                SelectedTenBanDich = banDich.TenBan;

                MessageBox.Show("Chuyển bàn thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Chuyển bàn thất bại.\n\nChi tiết lỗi: " + ex.Message,
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
