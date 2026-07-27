using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using QLCF.Data;
using QLCF.Helpers;
using QLCF.Models;

namespace QLCF.Forms
{
    public partial class FrmBanHang : Form
    {
        private bool isLoadingKhuVuc = false;

        // Lưu trữ thông tin bàn đang chọn và món đang chọn để thêm
        private BanModel currentBan = null;
        private MonAnModel currentMonAn = null;
        private Button currentMonAnButton = null;
        private int? currentMaDMFilter = null;

        // Lưu trữ thông tin món đang chọn trong DataGridView hóa đơn để sửa/xóa
        private int? selectedMaCTHD = null;
        private string selectedMonTen = string.Empty;
        private int selectedSoLuongCu = 0;

        public FrmBanHang()
        {
            InitializeComponent();

            this.Load += FrmBanHang_Load;
            this.cboKhuVuc.SelectedIndexChanged += cboKhuVuc_SelectedIndexChanged;
            this.btnLamMoi.Click += btnLamMoi_Click;
            this.btnDong.Click += btnDong_Click;

            // Đăng ký sự kiện tìm kiếm và thêm món
            this.btnTimMon.Click += btnTimMon_Click;
            this.txtTimMon.KeyDown += txtTimMon_KeyDown;
            this.btnThemMon.Click += btnThemMon_Click;

            // Đăng ký sự kiện chọn dòng, cập nhật số lượng và xóa món trong hóa đơn
            this.dgvChiTietHoaDon.CellClick += dgvChiTietHoaDon_CellClick;
            this.dgvChiTietHoaDon.SelectionChanged += dgvChiTietHoaDon_SelectionChanged;
            this.btnCapNhatSoLuong.Click += btnCapNhatSoLuong_Click;
            this.btnXoaMonKhoiHoaDon.Click += btnXoaMonKhoiHoaDon_Click;
            this.btnThanhToan.Click += btnThanhToan_Click;
            this.btnChuyenBan.Click += btnChuyenBan_Click;
            this.btnGopBan.Click += btnGopBan_Click;
        }

        private void FrmBanHang_Load(object sender, EventArgs e)
        {
            UITheme.ApplyStyleToForm(this);

            // Style nút bấm nổi bật
            if (btnThanhToan != null) UITheme.ApplyStyleToButton(btnThanhToan, isSuccess: true);
            if (btnThemMon != null) UITheme.ApplyStyleToButton(btnThemMon, isPrimary: true);
            if (btnXoaMonKhoiHoaDon != null) UITheme.ApplyStyleToButton(btnXoaMonKhoiHoaDon, isDanger: true);
            if (btnCapNhatSoLuong != null) UITheme.ApplyStyleToButton(btnCapNhatSoLuong);
            if (btnChuyenBan != null) UITheme.ApplyStyleToButton(btnChuyenBan);
            if (btnGopBan != null) UITheme.ApplyStyleToButton(btnGopBan);
            if (btnLamMoi != null) UITheme.ApplyStyleToButton(btnLamMoi);
            if (btnDong != null) UITheme.ApplyStyleToButton(btnDong);

            // Định dạng DataGridView
            dgvChiTietHoaDon.AutoGenerateColumns = false;

            // Đặt về trạng thái mặc định
            XoaThongTinBan();
            ResetSelectedMonAn();
            DatLaiMonDangChon();

            // Load dữ liệu
            LoadKhuVuc();
            LoadDanhMuc();
            LoadMonAn();
        }

        #region 1. DỮ LIỆU KHU VỰC VÀ SƠ ĐỒ BÀN

        private void LoadKhuVuc()
        {
            try
            {
                isLoadingKhuVuc = true;
                cboKhuVuc.Items.Clear();

                cboKhuVuc.Items.Add(new KhuVucItem { MaKV = 0, TenKhuVuc = "Tất cả khu vực" });

                using (SqlConnection conn = Db.CreateConnection())
                {
                    string sql = "SELECT MaKV, TenKhuVuc FROM dbo.KhuVuc WHERE TrangThai = 1 ORDER BY TenKhuVuc";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                cboKhuVuc.Items.Add(new KhuVucItem
                                {
                                    MaKV = Convert.ToInt32(reader["MaKV"]),
                                    TenKhuVuc = reader["TenKhuVuc"].ToString()
                                });
                            }
                        }
                    }
                }

                isLoadingKhuVuc = false;

                if (cboKhuVuc.Items.Count > 0)
                {
                    cboKhuVuc.SelectedIndex = 0;
                }

                LoadSoDoBan();
            }
            catch (Exception ex)
            {
                isLoadingKhuVuc = false;
                MessageBox.Show(
                    "Không thể tải danh sách khu vực từ CSDL.\n\nChi tiết: " + ex.Message,
                    "Lỗi kết nối",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void LoadSoDoBan()
        {
            try
            {
                flpSoDoBan.SuspendLayout();
                flpSoDoBan.Controls.Clear();

                int selectedMaKV = 0;
                if (cboKhuVuc.SelectedItem is KhuVucItem item)
                {
                    selectedMaKV = item.MaKV;
                }

                using (SqlConnection conn = Db.CreateConnection())
                {
                    string sql = @"
                        SELECT MaBan, TenBan, MaKV, TenKhuVuc, TrangThai, DangSuDung, MaHoaDonMo, GioVao, TamTinh
                        FROM dbo.vw_SoDoBan
                        WHERE (@MaKV = 0 OR MaKV = @MaKV)
                        ORDER BY TenKhuVuc, TenBan";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.Add("@MaKV", SqlDbType.Int).Value = selectedMaKV;

                        conn.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                BanModel ban = new BanModel
                                {
                                    MaBan = Convert.ToInt32(reader["MaBan"]),
                                    TenBan = reader["TenBan"].ToString(),
                                    MaKV = Convert.ToInt32(reader["MaKV"]),
                                    TenKhuVuc = reader["TenKhuVuc"].ToString(),
                                    TrangThai = reader["TrangThai"].ToString(),
                                    DangSuDung = Convert.ToBoolean(reader["DangSuDung"]),
                                    MaHoaDonMo = reader["MaHoaDonMo"] != DBNull.Value ? (int?)Convert.ToInt32(reader["MaHoaDonMo"]) : null,
                                    GioVao = reader["GioVao"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(reader["GioVao"]) : null,
                                    TamTinh = reader["TamTinh"] != DBNull.Value ? (decimal?)Convert.ToDecimal(reader["TamTinh"]) : null
                                };

                                Button btnBan = TaoButtonBan(ban);
                                flpSoDoBan.Controls.Add(btnBan);
                            }
                        }
                    }
                }

                flpSoDoBan.ResumeLayout();
            }
            catch (Exception ex)
            {
                flpSoDoBan.ResumeLayout();
                MessageBox.Show(
                    "Không thể tải dữ liệu sơ đồ bàn từ CSDL.\n\nChi tiết: " + ex.Message,
                    "Lỗi cơ sở dữ liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private Button TaoButtonBan(BanModel ban)
        {
            Button btn = new Button
            {
                Width = 145,
                Height = 115,
                Margin = new Padding(8),
                Cursor = Cursors.Hand,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point),
                Tag = ban
            };

            bool isSelected = (currentBan != null && currentBan.MaBan == ban.MaBan);
            btn.FlatAppearance.BorderSize = isSelected ? 3 : 1;

            string tamTinhText = DinhDangTien(ban.TamTinh);

            if (!ban.DangSuDung)
            {
                btn.BackColor = Color.FromArgb(241, 245, 249);
                btn.ForeColor = Color.FromArgb(148, 163, 184);
                btn.FlatAppearance.BorderColor = Color.FromArgb(226, 232, 240);
                btn.Enabled = false;
                btn.Text = $"{ban.TenBan}\n({ban.TenKhuVuc})\n[Ngưng dùng]";
            }
            else
            {
                btn.Enabled = true;
                string trangThaiStr = ban.TrangThai != null ? ban.TrangThai.Trim() : "";

                if (trangThaiStr.Equals("Trống", StringComparison.OrdinalIgnoreCase))
                {
                    btn.BackColor = UITheme.TableTrongBg;
                    btn.ForeColor = UITheme.TableTrongText;
                    btn.FlatAppearance.BorderColor = isSelected ? UITheme.PrimaryAccent : UITheme.TableTrongBorder;
                }
                else if (trangThaiStr.Equals("Có khách", StringComparison.OrdinalIgnoreCase))
                {
                    btn.BackColor = UITheme.TableCoKhachBg;
                    btn.ForeColor = UITheme.TableCoKhachText;
                    btn.FlatAppearance.BorderColor = isSelected ? UITheme.PrimaryAccent : UITheme.TableCoKhachBorder;
                }
                else if (trangThaiStr.Equals("Đặt trước", StringComparison.OrdinalIgnoreCase))
                {
                    btn.BackColor = UITheme.TableDatTruocBg;
                    btn.ForeColor = UITheme.TableDatTruocText;
                    btn.FlatAppearance.BorderColor = isSelected ? UITheme.PrimaryAccent : UITheme.TableDatTruocBorder;
                }
                else
                {
                    btn.BackColor = Color.FromArgb(241, 245, 249);
                    btn.ForeColor = UITheme.TextPrimary;
                    btn.FlatAppearance.BorderColor = isSelected ? UITheme.PrimaryAccent : UITheme.BorderColor;
                }

                if (isSelected)
                {
                    btn.FlatAppearance.BorderColor = UITheme.PrimaryAccent;
                }

                btn.Text = $"{ban.TenBan}\n({ban.TenKhuVuc})\n{ban.TrangThai}\n{tamTinhText}";
            }

            btn.Click += Ban_Click;

            return btn;
        }

        private void Ban_Click(object sender, EventArgs e)
        {
            if (sender is Button btn && btn.Tag is BanModel ban)
            {
                currentBan = ban;
                HienThiThongTinBan(ban);
                LoadChiTietHoaDon(ban.MaHoaDonMo);
                HighlightSelectedBan();
                DatLaiMonDangChon();
            }
        }

        private void HighlightSelectedBan()
        {
            foreach (Control ctrl in flpSoDoBan.Controls)
            {
                if (ctrl is Button btn && btn.Tag is BanModel ban)
                {
                    if (currentBan != null && ban.MaBan == currentBan.MaBan)
                    {
                        btn.FlatAppearance.BorderSize = 3;
                        btn.FlatAppearance.BorderColor = Color.Blue;
                    }
                    else
                    {
                        btn.FlatAppearance.BorderSize = 1;
                        btn.FlatAppearance.BorderColor = Color.FromArgb(189, 195, 199);
                    }
                }
            }
        }

        private void HienThiThongTinBan(BanModel ban)
        {
            lblHuongDan.Visible = false;

            lblTenBanDangChon.Text = "Tên bàn: " + ban.TenBan;
            lblKhuVucDangChon.Text = "Khu vực: " + ban.TenKhuVuc;
            lblTrangThaiBan.Text = "Trạng thái: " + ban.TrangThai;

            if (ban.MaHoaDonMo.HasValue && ban.MaHoaDonMo.Value > 0)
            {
                lblMaHoaDonMo.Text = "Mã hóa đơn: HD" + ban.MaHoaDonMo.Value.ToString("D5");
            }
            else
            {
                lblMaHoaDonMo.Text = "Mã hóa đơn: Chưa có hóa đơn";
            }

            if (ban.GioVao.HasValue)
            {
                lblGioVao.Text = "Giờ vào: " + ban.GioVao.Value.ToString("HH:mm - dd/MM/yyyy");
            }
            else
            {
                lblGioVao.Text = "Giờ vào: --";
            }
        }

        private void XoaThongTinBan()
        {
            currentBan = null;
            lblHuongDan.Visible = true;
            lblTenBanDangChon.Text = "Tên bàn: --";
            lblKhuVucDangChon.Text = "Khu vực: --";
            lblTrangThaiBan.Text = "Trạng thái: --";
            lblMaHoaDonMo.Text = "Mã hóa đơn: Chưa có hóa đơn";
            lblGioVao.Text = "Giờ vào: --";
            dgvChiTietHoaDon.DataSource = null;
            lblTongTamTinh.Text = "Tổng tạm tính: 0 đ";
            DatLaiMonDangChon();
        }

        #endregion

        #region 2. DỮ LIỆU DANH MỤC VÀ MÓN ĂN

        private void LoadDanhMuc()
        {
            try
            {
                flpDanhMuc.SuspendLayout();
                flpDanhMuc.Controls.Clear();

                // Nút "Tất cả"
                Button btnAll = new Button
                {
                    Text = "Tất cả",
                    Height = 40,
                    AutoSize = true,
                    Margin = new Padding(3),
                    Cursor = Cursors.Hand,
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point),
                    BackColor = Color.FromArgb(52, 152, 219),
                    ForeColor = Color.White,
                    Tag = null
                };
                btnAll.FlatAppearance.BorderSize = 0;
                btnAll.Click += DanhMuc_Click;
                flpDanhMuc.Controls.Add(btnAll);

                using (SqlConnection conn = Db.CreateConnection())
                {
                    string sql = "SELECT MaDM, TenDanhMuc FROM dbo.DanhMuc WHERE TrangThai = 1 ORDER BY TenDanhMuc";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                DanhMucModel dm = new DanhMucModel
                                {
                                    MaDM = Convert.ToInt32(reader["MaDM"]),
                                    TenDanhMuc = reader["TenDanhMuc"].ToString()
                                };

                                Button btnDM = new Button
                                {
                                    Text = dm.TenDanhMuc,
                                    Height = 40,
                                    AutoSize = true,
                                    Margin = new Padding(3),
                                    Cursor = Cursors.Hand,
                                    FlatStyle = FlatStyle.Flat,
                                    Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point),
                                    BackColor = Color.FromArgb(236, 240, 241),
                                    ForeColor = Color.Black,
                                    Tag = dm
                                };
                                btnDM.FlatAppearance.BorderSize = 0;
                                btnDM.Click += DanhMuc_Click;
                                flpDanhMuc.Controls.Add(btnDM);
                            }
                        }
                    }
                }

                flpDanhMuc.ResumeLayout();
            }
            catch (Exception ex)
            {
                flpDanhMuc.ResumeLayout();
                MessageBox.Show("Không thể tải danh mục món.\n\nChi tiết: " + ex.Message, "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DanhMuc_Click(object sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                foreach (Control ctrl in flpDanhMuc.Controls)
                {
                    if (ctrl is Button b)
                    {
                        b.BackColor = Color.FromArgb(236, 240, 241);
                        b.ForeColor = Color.Black;
                        b.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
                    }
                }

                btn.BackColor = Color.FromArgb(52, 152, 219);
                btn.ForeColor = Color.White;
                btn.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point);

                if (btn.Tag is DanhMucModel dm)
                {
                    currentMaDMFilter = dm.MaDM;
                }
                else
                {
                    currentMaDMFilter = null;
                }

                LoadMonAn(currentMaDMFilter, txtTimMon.Text.Trim());
            }
        }

        private void LoadMonAn(int? maDM = null, string tuKhoa = null)
        {
            try
            {
                flpMonAn.SuspendLayout();
                flpMonAn.Controls.Clear();

                using (SqlConnection conn = Db.CreateConnection())
                {
                    string sql = @"
                        SELECT MaMon, TenMon, MaDM, DonGia, HinhAnh
                        FROM dbo.MonAn
                        WHERE TrangThai = 1
                          AND (@MaDM IS NULL OR MaDM = @MaDM)
                          AND (@TuKhoa IS NULL OR TenMon LIKE '%' + @TuKhoa + '%')
                        ORDER BY TenMon";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.Add("@MaDM", SqlDbType.Int).Value = (maDM.HasValue && maDM.Value > 0) ? (object)maDM.Value : DBNull.Value;
                        cmd.Parameters.Add("@TuKhoa", SqlDbType.NVarChar, 100).Value = !string.IsNullOrWhiteSpace(tuKhoa) ? (object)tuKhoa.Trim() : DBNull.Value;

                        conn.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                MonAnModel mon = new MonAnModel
                                {
                                    MaMon = Convert.ToInt32(reader["MaMon"]),
                                    TenMon = reader["TenMon"].ToString(),
                                    MaDM = Convert.ToInt32(reader["MaDM"]),
                                    DonGia = Convert.ToDecimal(reader["DonGia"]),
                                    HinhAnh = reader["HinhAnh"] != DBNull.Value ? reader["HinhAnh"].ToString() : null
                                };

                                Button btnMon = TaoButtonMonAn(mon);
                                flpMonAn.Controls.Add(btnMon);
                            }
                        }
                    }
                }

                flpMonAn.ResumeLayout();
            }
            catch (Exception ex)
            {
                flpMonAn.ResumeLayout();
                MessageBox.Show("Không thể tải danh sách món ăn.\n\nChi tiết: " + ex.Message, "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Button TaoButtonMonAn(MonAnModel mon)
        {
            Button btn = new Button
            {
                Width = 125,
                Height = 90,
                Margin = new Padding(6),
                Cursor = Cursors.Hand,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point),
                BackColor = Color.FromArgb(250, 250, 250),
                ForeColor = Color.FromArgb(44, 62, 80),
                Text = $"{mon.TenMon}\n\n{DinhDangTien(mon.DonGia)}",
                Tag = mon
            };

            btn.FlatAppearance.BorderSize = 1;
            btn.FlatAppearance.BorderColor = Color.FromArgb(189, 195, 199);

            // Kiểm tra và hiển thị ảnh nếu đường dẫn hợp lệ
            if (!string.IsNullOrWhiteSpace(mon.HinhAnh) && File.Exists(mon.HinhAnh))
            {
                try
                {
                    btn.Image = Image.FromFile(mon.HinhAnh);
                    btn.ImageAlign = ContentAlignment.TopCenter;
                    btn.TextAlign = ContentAlignment.BottomCenter;
                }
                catch
                {
                    // Nếu lỗi khi đọc file ảnh thì không làm sập ứng dụng
                }
            }

            btn.Click += MonAn_Click;

            return btn;
        }

        private void MonAn_Click(object sender, EventArgs e)
        {
            if (sender is Button btn && btn.Tag is MonAnModel mon)
            {
                // Đổi màu viền card món được chọn
                if (currentMonAnButton != null)
                {
                    currentMonAnButton.FlatAppearance.BorderSize = 1;
                    currentMonAnButton.FlatAppearance.BorderColor = Color.FromArgb(189, 195, 199);
                    currentMonAnButton.BackColor = Color.FromArgb(250, 250, 250);
                }

                currentMonAn = mon;
                currentMonAnButton = btn;

                btn.FlatAppearance.BorderSize = 3;
                btn.FlatAppearance.BorderColor = Color.FromArgb(41, 128, 185);
                btn.BackColor = Color.FromArgb(235, 245, 251);

                lblMonDangChon.Text = "Món đang chọn: " + mon.TenMon;
            }
        }

        private void ResetSelectedMonAn()
        {
            if (currentMonAnButton != null)
            {
                currentMonAnButton.FlatAppearance.BorderSize = 1;
                currentMonAnButton.FlatAppearance.BorderColor = Color.FromArgb(189, 195, 199);
                currentMonAnButton.BackColor = Color.FromArgb(250, 250, 250);
            }

            currentMonAn = null;
            currentMonAnButton = null;
            lblMonDangChon.Text = "Món đang chọn: Chưa chọn món";
            nudSoLuong.Value = 1;
            txtGhiChuMon.Clear();
        }

        private void btnTimMon_Click(object sender, EventArgs e)
        {
            LoadMonAn(currentMaDMFilter, txtTimMon.Text.Trim());
        }

        private void txtTimMon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadMonAn(currentMaDMFilter, txtTimMon.Text.Trim());
                e.SuppressKeyPress = true;
            }
        }

        #endregion

        #region 3. HÓA ĐƠN VÀ THÊM MÓN VÀO HÓA ĐƠN

        private void LoadChiTietHoaDon(int? maHD)
        {
            try
            {
                if (!maHD.HasValue || maHD.Value <= 0)
                {
                    dgvChiTietHoaDon.DataSource = null;
                    lblTongTamTinh.Text = "Tổng tạm tính: 0 đ";
                    DatLaiMonDangChon();
                    return;
                }

                List<ChiTietHoaDonModel> listChiTiet = new List<ChiTietHoaDonModel>();

                using (SqlConnection conn = Db.CreateConnection())
                {
                    string sql = @"
                        SELECT ct.MaCTHD, ct.MaHD, ct.MaMon, m.TenMon, ct.SoLuong, ct.DonGia, ct.ThanhTien, ct.GhiChu
                        FROM dbo.ChiTietHoaDon ct
                        JOIN dbo.MonAn m ON ct.MaMon = m.MaMon
                        JOIN dbo.HoaDon hd ON ct.MaHD = hd.MaHD
                        WHERE ct.MaHD = @MaHD AND hd.TrangThai = 0
                        ORDER BY ct.MaCTHD";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.Add("@MaHD", SqlDbType.Int).Value = maHD.Value;

                        conn.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                listChiTiet.Add(new ChiTietHoaDonModel
                                {
                                    MaCTHD = Convert.ToInt32(reader["MaCTHD"]),
                                    MaHD = Convert.ToInt32(reader["MaHD"]),
                                    MaMon = Convert.ToInt32(reader["MaMon"]),
                                    TenMon = reader["TenMon"].ToString(),
                                    SoLuong = Convert.ToInt32(reader["SoLuong"]),
                                    DonGia = Convert.ToDecimal(reader["DonGia"]),
                                    ThanhTien = Convert.ToDecimal(reader["ThanhTien"]),
                                    GhiChu = reader["GhiChu"] != DBNull.Value ? reader["GhiChu"].ToString() : ""
                                });
                            }
                        }
                    }
                }

                dgvChiTietHoaDon.DataSource = listChiTiet;

                // Format hiển thị cho DonGia và ThanhTien trong DataGridView
                if (dgvChiTietHoaDon.Columns["colDonGia"] != null)
                {
                    dgvChiTietHoaDon.Columns["colDonGia"].DefaultCellStyle.Format = "N0";
                }
                if (dgvChiTietHoaDon.Columns["colThanhTien"] != null)
                {
                    dgvChiTietHoaDon.Columns["colThanhTien"].DefaultCellStyle.Format = "N0";
                }

                decimal tongTamTinh = listChiTiet.Sum(x => x.ThanhTien);
                lblTongTamTinh.Text = "Tổng tạm tính: " + DinhDangTien(tongTamTinh);

                DatLaiMonDangChon();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải chi tiết hóa đơn.\n\nChi tiết: " + ex.Message, "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThemMon_Click(object sender, EventArgs e)
        {
            ThemMonVaoHoaDon();
        }

        private void ThemMonVaoHoaDon()
        {
            // Validate 1: Chưa chọn bàn
            if (currentBan == null)
            {
                MessageBox.Show("Vui lòng chọn bàn trước.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate 2: Chưa chọn món
            if (currentMonAn == null)
            {
                MessageBox.Show("Vui lòng chọn món cần thêm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate 3: Số lượng phải lớn hơn 0
            int soLuong = (int)nudSoLuong.Value;
            if (soLuong <= 0)
            {
                MessageBox.Show("Số lượng phải lớn hơn 0.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string ghiChu = txtGhiChuMon.Text.Trim();

            try
            {
                using (SqlConnection conn = Db.CreateConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("sp_ThemMonVaoHoaDon", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@MaBan", SqlDbType.Int).Value = currentBan.MaBan;
                        cmd.Parameters.Add("@MaNV", SqlDbType.Int).Value = UserSession.MaNV;
                        cmd.Parameters.Add("@MaMon", SqlDbType.Int).Value = currentMonAn.MaMon;
                        cmd.Parameters.Add("@SoLuong", SqlDbType.Int).Value = soLuong;
                        cmd.Parameters.Add("@GhiChu", SqlDbType.NVarChar, 300).Value = string.IsNullOrEmpty(ghiChu) ? (object)DBNull.Value : ghiChu;

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Đã thêm món vào hóa đơn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Reset thông tin thêm món
                nudSoLuong.Value = 1;
                txtGhiChuMon.Clear();

                // Cập nhật lại dữ liệu bàn đang chọn
                LamMoiDuLieuBanDangChon();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm món vào hóa đơn.\n\nChi tiết: " + ex.Message, "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LamMoiDuLieuBanDangChon()
        {
            if (currentBan == null) return;

            try
            {
                int maBan = currentBan.MaBan;

                using (SqlConnection conn = Db.CreateConnection())
                {
                    string sql = @"
                        SELECT MaBan, TenBan, MaKV, TenKhuVuc, TrangThai, DangSuDung, MaHoaDonMo, GioVao, TamTinh
                        FROM dbo.vw_SoDoBan
                        WHERE MaBan = @MaBan";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.Add("@MaBan", SqlDbType.Int).Value = maBan;

                        conn.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                currentBan = new BanModel
                                {
                                    MaBan = Convert.ToInt32(reader["MaBan"]),
                                    TenBan = reader["TenBan"].ToString(),
                                    MaKV = Convert.ToInt32(reader["MaKV"]),
                                    TenKhuVuc = reader["TenKhuVuc"].ToString(),
                                    TrangThai = reader["TrangThai"].ToString(),
                                    DangSuDung = Convert.ToBoolean(reader["DangSuDung"]),
                                    MaHoaDonMo = reader["MaHoaDonMo"] != DBNull.Value ? (int?)Convert.ToInt32(reader["MaHoaDonMo"]) : null,
                                    GioVao = reader["GioVao"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(reader["GioVao"]) : null,
                                    TamTinh = reader["TamTinh"] != DBNull.Value ? (decimal?)Convert.ToDecimal(reader["TamTinh"]) : null
                                };
                            }
                        }
                    }
                }

                // Tải lại giao diện bàn và hóa đơn
                HienThiThongTinBan(currentBan);
                LoadChiTietHoaDon(currentBan.MaHoaDonMo);

                // Load lại sơ đồ bàn để đổi màu bàn (Trống -> Có khách)
                LoadSoDoBan();
                HighlightSelectedBan();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật dữ liệu bàn.\n\nChi tiết: " + ex.Message, "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region 4. XỬ LÝ SỬA SỐ LƯỢNG VÀ XÓA MÓN TRONG HÓA ĐƠN

        private void dgvChiTietHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ChonDongChiTietHoaDon();
        }

        private void dgvChiTietHoaDon_SelectionChanged(object sender, EventArgs e)
        {
            ChonDongChiTietHoaDon();
        }

        private void ChonDongChiTietHoaDon()
        {
            if (dgvChiTietHoaDon.CurrentRow != null && dgvChiTietHoaDon.CurrentRow.DataBoundItem is ChiTietHoaDonModel item)
            {
                selectedMaCTHD = item.MaCTHD;
                selectedMonTen = item.TenMon;
                selectedSoLuongCu = item.SoLuong;

                lblMonTrongHoaDonDangChon.Text = "Đang chọn trong HD: " + item.TenMon;
                nudSoLuongCapNhat.Value = Math.Min(Math.Max(item.SoLuong, 0), 100);
            }
            else
            {
                DatLaiMonDangChon();
            }
        }

        private void DatLaiMonDangChon()
        {
            selectedMaCTHD = null;
            selectedMonTen = string.Empty;
            selectedSoLuongCu = 0;

            lblMonTrongHoaDonDangChon.Text = "Đang chọn trong HD: Chưa chọn món";
            nudSoLuongCapNhat.Value = 1;
        }

        private void btnCapNhatSoLuong_Click(object sender, EventArgs e)
        {
            CapNhatSoLuongMon();
        }

        private void CapNhatSoLuongMon()
        {
            if (!selectedMaCTHD.HasValue)
            {
                MessageBox.Show("Vui lòng chọn món trong hóa đơn cần cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int soLuongMoi = (int)nudSoLuongCapNhat.Value;

            if (soLuongMoi == selectedSoLuongCu)
            {
                MessageBox.Show("Số lượng không thay đổi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (soLuongMoi == 0)
            {
                DialogResult confirm = MessageBox.Show(
                    "Số lượng bằng 0. Bạn có muốn xóa món này khỏi hóa đơn không?",
                    "Xác nhận xóa món",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (confirm != DialogResult.Yes)
                {
                    return;
                }
            }

            try
            {
                using (SqlConnection conn = Db.CreateConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("sp_CapNhatSoLuongMon", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@MaNV", SqlDbType.Int).Value = UserSession.MaNV;
                        cmd.Parameters.Add("@MaCTHD", SqlDbType.Int).Value = selectedMaCTHD.Value;
                        cmd.Parameters.Add("@SoLuongMoi", SqlDbType.Int).Value = soLuongMoi;

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Cập nhật số lượng thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LamMoiDuLieuBanDangChon();
                DatLaiMonDangChon();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật số lượng món.\n\nChi tiết: " + ex.Message, "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoaMonKhoiHoaDon_Click(object sender, EventArgs e)
        {
            XoaMonKhoiHoaDon();
        }

        private void XoaMonKhoiHoaDon()
        {
            if (!selectedMaCTHD.HasValue)
            {
                MessageBox.Show("Vui lòng chọn món cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                $"Bạn có chắc muốn xóa món [{selectedMonTen}] khỏi hóa đơn không?",
                "Xác nhận xóa món",
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
                    using (SqlCommand cmd = new SqlCommand("sp_CapNhatSoLuongMon", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@MaNV", SqlDbType.Int).Value = UserSession.MaNV;
                        cmd.Parameters.Add("@MaCTHD", SqlDbType.Int).Value = selectedMaCTHD.Value;
                        cmd.Parameters.Add("@SoLuongMoi", SqlDbType.Int).Value = 0;

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Đã xóa món khỏi hóa đơn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LamMoiDuLieuBanDangChon();
                DatLaiMonDangChon();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa món khỏi hóa đơn.\n\nChi tiết: " + ex.Message, "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region 5. XỬ LÝ THANH TOÁN HÓA ĐƠN

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            MoFormThanhToan();
        }

        private void MoFormThanhToan()
        {
            // Validate 1: Chưa chọn bàn
            if (currentBan == null)
            {
                MessageBox.Show("Vui lòng chọn bàn cần thanh toán.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate 2: Bàn chưa có hóa đơn mở
            if (!currentBan.MaHoaDonMo.HasValue || currentBan.MaHoaDonMo.Value <= 0)
            {
                MessageBox.Show("Bàn này chưa có hóa đơn để thanh toán.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate 3: Hóa đơn chưa có món (tạm tính <= 0)
            decimal tongTamTinh = currentBan.TamTinh ?? 0;
            if (tongTamTinh <= 0)
            {
                MessageBox.Show("Hóa đơn chưa có món, không thể thanh toán.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Mở Form thanh toán dạng Dialog
            using (FrmThanhToan frm = new FrmThanhToan(currentBan.MaHoaDonMo.Value, currentBan.MaBan, currentBan.TenBan, tongTamTinh))
            {
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    // Sau khi thanh toán thành công:
                    XoaThongTinBan();
                    ResetSelectedMonAn();
                    DatLaiMonDangChon();
                    LoadSoDoBan();
                }
            }
        }

        #endregion

        #region 6. XỬ LÝ CHUYỂN BÀN

        private void btnChuyenBan_Click(object sender, EventArgs e)
        {
            MoFormChuyenBan();
        }

        private void MoFormChuyenBan()
        {
            // Validate 1: Chưa chọn bàn nguồn
            if (currentBan == null)
            {
                MessageBox.Show("Vui lòng chọn bàn nguồn cần chuyển.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate 2: Bàn nguồn đang chọn không có hóa đơn mở
            if (!currentBan.MaHoaDonMo.HasValue || currentBan.MaHoaDonMo.Value <= 0)
            {
                MessageBox.Show("Bàn này đang trống, không có hóa đơn để chuyển.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maBanNguon = currentBan.MaBan;
            string tenBanNguon = currentBan.TenBan;
            int maHD = currentBan.MaHoaDonMo.Value;
            decimal tamTinh = currentBan.TamTinh ?? 0;

            using (FrmChuyenBan frm = new FrmChuyenBan(maBanNguon, tenBanNguon, maHD, tamTinh))
            {
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    int maBanDich = frm.SelectedMaBanDich;

                    // Reload sơ đồ bàn để bàn nguồn về Trống, bàn đích thành Có khách
                    LoadSoDoBan();

                    // Xóa thông tin/chi tiết của bàn nguồn đang chọn
                    XoaThongTinBan();
                    ResetSelectedMonAn();
                    DatLaiMonDangChon();

                    // Tự động tìm và chọn bàn đích để hiển thị order tại bàn đích vừa chuyển tới
                    TuDongChonBan(maBanDich);
                }
            }
        }

        private void TuDongChonBan(int maBan)
        {
            foreach (Control ctrl in flpSoDoBan.Controls)
            {
                if (ctrl is Button btn && btn.Tag is BanModel ban && ban.MaBan == maBan)
                {
                    Ban_Click(btn, EventArgs.Empty);
                    break;
                }
            }
        }

        #endregion

        #region 7. XỬ LÝ GỘP BÀN

        private void btnGopBan_Click(object sender, EventArgs e)
        {
            MoFormGopBan();
        }

        private void MoFormGopBan()
        {
            // Validate 1: Chưa chọn bàn chính
            if (currentBan == null)
            {
                MessageBox.Show("Vui lòng chọn bàn chính cần gộp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate 2: Bàn chính đang chọn không có hóa đơn mở
            if (!currentBan.MaHoaDonMo.HasValue || currentBan.MaHoaDonMo.Value <= 0)
            {
                MessageBox.Show("Bàn chính phải có hóa đơn đang mở để gộp bàn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maBanChinh = currentBan.MaBan;
            string tenBanChinh = currentBan.TenBan;
            int maHDChinh = currentBan.MaHoaDonMo.Value;
            decimal tamTinhChinh = currentBan.TamTinh ?? 0;

            using (FrmGopBan frm = new FrmGopBan(maBanChinh, tenBanChinh, maHDChinh, tamTinhChinh))
            {
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    // Reload sơ đồ bàn để bàn phụ về Trống
                    LoadSoDoBan();

                    // Giữ bàn chính là bàn đang được chọn: Tự động chọn lại bàn chính để reload chi tiết hóa đơn và tổng tạm tính mới
                    TuDongChonBan(maBanChinh);
                }
            }
        }

        #endregion

        #region HÀM TIỆN ÍCH HOẶC NÚT ĐỒNG / LÀM MỚI

        private string DinhDangTien(decimal? soTien)
        {
            decimal val = soTien ?? 0;
            return val.ToString("N0") + " đ";
        }

        private void cboKhuVuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isLoadingKhuVuc)
            {
                LoadSoDoBan();
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            XoaThongTinBan();
            ResetSelectedMonAn();
            DatLaiMonDangChon();
            LoadKhuVuc();
            LoadDanhMuc();
            LoadMonAn();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion
    }
}
