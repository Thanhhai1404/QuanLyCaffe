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
    public partial class FrmNhapKho : Form
    {
        private DataTable dtChiTiet;

        public FrmNhapKho()
        {
            InitializeComponent();
            
            this.Load += FrmNhapKho_Load;
            this.btnDong.Click += (s, e) => this.Close();
            this.btnThemVaoPhieu.Click += BtnThemVaoPhieu_Click;
            this.btnHoanTat.Click += BtnHoanTat_Click;
            this.dgvChiTiet.CellContentClick += DgvChiTiet_CellContentClick;
            
            // Allow only numbers in txtSoLuong and txtDonGia
            this.txtSoLuong.KeyPress += NumberOnly_KeyPress;
            this.txtDonGia.KeyPress += NumberOnly_KeyPress;
        }

        private void FrmNhapKho_Load(object sender, EventArgs e)
        {
            UITheme.ApplyStyleToForm(this);
            pnlHeader.BackColor = UITheme.HeaderDark;
            UITheme.ApplyStyleToButton(btnThemVaoPhieu, isPrimary: true);
            
            // Format btnHoanTat specifically
            btnHoanTat.BackColor = UITheme.PrimaryAccent;
            btnHoanTat.ForeColor = Color.White;
            btnHoanTat.FlatStyle = FlatStyle.Flat;
            btnHoanTat.FlatAppearance.BorderSize = 0;

            UITheme.ApplyStyleToDataGridView(dgvChiTiet);

            InitDataTable();
            LoadNguyenVatLieu();
        }

        private void InitDataTable()
        {
            dtChiTiet = new DataTable();
            dtChiTiet.Columns.Add("MaNVL", typeof(int));
            dtChiTiet.Columns.Add("TenNVL", typeof(string));
            dtChiTiet.Columns.Add("SoLuong", typeof(decimal));
            dtChiTiet.Columns.Add("DonGia", typeof(decimal));
            dtChiTiet.Columns.Add("ThanhTien", typeof(decimal));
            
            // For display formatting
            dtChiTiet.Columns.Add("DonGiaText", typeof(string));
            dtChiTiet.Columns.Add("ThanhTienText", typeof(string));

            dgvChiTiet.AutoGenerateColumns = false;
            dgvChiTiet.DataSource = dtChiTiet;
        }

        private void LoadNguyenVatLieu()
        {
            try
            {
                using (SqlConnection conn = Db.CreateConnection())
                {
                    string sql = "SELECT MaNVL, TenNVL + ' (' + DonViTinh + ')' AS TenHienThi FROM NguyenVatLieu";
                    using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        cboNguyenVatLieu.DisplayMember = "TenHienThi";
                        cboNguyenVatLieu.ValueMember = "MaNVL";
                        cboNguyenVatLieu.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách NVL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void NumberOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            // Allow only one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void BtnThemVaoPhieu_Click(object sender, EventArgs e)
        {
            if (cboNguyenVatLieu.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn nguyên vật liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtSoLuong.Text, out decimal soLuong) || soLuong <= 0)
            {
                MessageBox.Show("Số lượng không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtDonGia.Text, out decimal donGia) || donGia < 0)
            {
                MessageBox.Show("Đơn giá không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maNVL = (int)cboNguyenVatLieu.SelectedValue;
            string tenNVL = cboNguyenVatLieu.Text;
            decimal thanhTien = soLuong * donGia;

            // Check if already in list
            bool found = false;
            foreach (DataRow row in dtChiTiet.Rows)
            {
                if ((int)row["MaNVL"] == maNVL)
                {
                    decimal oldSl = (decimal)row["SoLuong"];
                    decimal newSl = oldSl + soLuong;
                    row["SoLuong"] = newSl;
                    // Update price if changed? We can just keep the latest or average. Here keep latest.
                    row["DonGia"] = donGia;
                    
                    decimal newThanhTien = newSl * donGia;
                    row["ThanhTien"] = newThanhTien;
                    row["DonGiaText"] = donGia.ToString("N0") + " đ";
                    row["ThanhTienText"] = newThanhTien.ToString("N0") + " đ";
                    
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                DataRow newRow = dtChiTiet.NewRow();
                newRow["MaNVL"] = maNVL;
                newRow["TenNVL"] = tenNVL;
                newRow["SoLuong"] = soLuong;
                newRow["DonGia"] = donGia;
                newRow["ThanhTien"] = thanhTien;
                newRow["DonGiaText"] = donGia.ToString("N0") + " đ";
                newRow["ThanhTienText"] = thanhTien.ToString("N0") + " đ";
                dtChiTiet.Rows.Add(newRow);
            }

            CalculateTotal();
            
            // Clear inputs
            txtSoLuong.Text = "";
            txtDonGia.Text = "";
            txtSoLuong.Focus();
        }

        private void DgvChiTiet_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvChiTiet.Columns[e.ColumnIndex].Name == "colXoa")
            {
                dtChiTiet.Rows.RemoveAt(e.RowIndex);
                CalculateTotal();
            }
        }

        private void CalculateTotal()
        {
            decimal total = 0;
            foreach (DataRow row in dtChiTiet.Rows)
            {
                total += (decimal)row["ThanhTien"];
            }
            lblTongTienVal.Text = total.ToString("N0") + " đ";
        }

        private void BtnHoanTat_Click(object sender, EventArgs e)
        {
            if (dtChiTiet.Rows.Count == 0)
            {
                MessageBox.Show("Chưa có nguyên vật liệu nào trong phiếu nhập.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dr = MessageBox.Show("Xác nhận hoàn tất phiếu nhập này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.No) return;

            decimal tongTien = 0;
            foreach (DataRow row in dtChiTiet.Rows) tongTien += (decimal)row["ThanhTien"];

            using (SqlConnection conn = Db.CreateConnection())
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. Insert PhieuNhapKho
                        string sqlPhieu = "INSERT INTO PhieuNhapKho (NguoiNhap, TongTien, GhiChu) OUTPUT INSERTED.MaPhieuNhap VALUES (@NguoiNhap, @TongTien, @GhiChu)";
                        int maPhieuNhap = 0;
                        using (SqlCommand cmdPhieu = new SqlCommand(sqlPhieu, conn, trans))
                        {
                            cmdPhieu.Parameters.AddWithValue("@NguoiNhap", UserSession.HoTen);
                            cmdPhieu.Parameters.AddWithValue("@TongTien", tongTien);
                            cmdPhieu.Parameters.AddWithValue("@GhiChu", txtGhiChu.Text.Trim());
                            maPhieuNhap = (int)cmdPhieu.ExecuteScalar();
                        }

                        // 2. Insert ChiTietPhieuNhap (Trigger TRG_CapNhatTonKho_Nhap will run and update NguyenVatLieu)
                        string sqlChiTiet = "INSERT INTO ChiTietPhieuNhap (MaPhieuNhap, MaNVL, SoLuong, DonGia, ThanhTien) VALUES (@MaPhieuNhap, @MaNVL, @SoLuong, @DonGia, @ThanhTien)";
                        foreach (DataRow row in dtChiTiet.Rows)
                        {
                            using (SqlCommand cmdCT = new SqlCommand(sqlChiTiet, conn, trans))
                            {
                                cmdCT.Parameters.AddWithValue("@MaPhieuNhap", maPhieuNhap);
                                cmdCT.Parameters.AddWithValue("@MaNVL", row["MaNVL"]);
                                cmdCT.Parameters.AddWithValue("@SoLuong", row["SoLuong"]);
                                cmdCT.Parameters.AddWithValue("@DonGia", row["DonGia"]);
                                cmdCT.Parameters.AddWithValue("@ThanhTien", row["ThanhTien"]);
                                cmdCT.ExecuteNonQuery();
                            }
                        }

                        trans.Commit();
                        MessageBox.Show("Nhập kho thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        MessageBox.Show("Lỗi khi lưu phiếu nhập: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
