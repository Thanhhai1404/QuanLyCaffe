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

        // Shift Tracking
        private DateTime shiftStartTime;

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
            this.dgvChiTietHoaDon.CellContentClick += dgvChiTietHoaDon_CellContentClick;
            this.dgvChiTietHoaDon.CellEndEdit += dgvChiTietHoaDon_CellEndEdit;
            this.btnCapNhatSoLuong.Click += btnCapNhatSoLuong_Click;
            this.btnXoaMonKhoiHoaDon.Click += btnXoaMonKhoiHoaDon_Click;
            this.btnThanhToan.Click += btnThanhToan_Click;
            this.btnChuyenBan.Click += btnChuyenBan_Click;
            this.btnGopBan.Click += btnGopBan_Click;

            // Đăng ký sự kiện Kết Ca
            this.btnKetCaTopBar.Click += btnKetCaTopBar_Click;
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

            // Khởi tạo Shift Timer
            InitShiftTimer();
            
            // Tải danh sách khuyến mãi
            LoadKhuyenMai();
            this.chkApDungKhuyenMai.CheckedChanged += chkApDungKhuyenMai_CheckedChanged;
            this.cboKhuyenMai.SelectedIndexChanged += cboKhuyenMai_SelectedIndexChanged;
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
                Width = 112,
                Height = 84,
                Margin = new Padding(4),
                Cursor = Cursors.Hand,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point),
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
                bool isHasInvoice = (ban.MaHoaDonMo.HasValue && ban.MaHoaDonMo.Value > 0) || (ban.TamTinh.HasValue && ban.TamTinh.Value > 0);
                string trangThaiStr = ban.TrangThai != null ? ban.TrangThai.Trim() : "";

                if (isHasInvoice || trangThaiStr.Equals("Có khách", StringComparison.OrdinalIgnoreCase) || trangThaiStr.Equals("Có người", StringComparison.OrdinalIgnoreCase) || trangThaiStr.Equals("Đang dùng", StringComparison.OrdinalIgnoreCase))
                {
                    btn.BackColor = UITheme.TableCoKhachBg;
                    btn.ForeColor = UITheme.TableCoKhachText;
                    btn.FlatAppearance.BorderColor = isSelected ? UITheme.PrimaryAccent : UITheme.TableCoKhachBorder;
                    trangThaiStr = "Có khách";
                }
                else if (trangThaiStr.Equals("Đặt trước", StringComparison.OrdinalIgnoreCase))
                {
                    btn.BackColor = UITheme.TableDatTruocBg;
                    btn.ForeColor = UITheme.TableDatTruocText;
                    btn.FlatAppearance.BorderColor = isSelected ? UITheme.PrimaryAccent : UITheme.TableDatTruocBorder;
                }
                else
                {
                    btn.BackColor = UITheme.TableTrongBg;
                    btn.ForeColor = UITheme.TableTrongText;
                    btn.FlatAppearance.BorderColor = isSelected ? UITheme.PrimaryAccent : UITheme.TableTrongBorder;
                    trangThaiStr = "Trống";
                }

                if (isSelected)
                {
                    btn.FlatAppearance.BorderColor = UITheme.PrimaryAccent;
                }

                btn.Text = $"{ban.TenBan}\n{trangThaiStr}\n{tamTinhText}";
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
                        btn.FlatAppearance.BorderColor = UITheme.PrimaryAccent;
                    }
                    else
                    {
                        btn.FlatAppearance.BorderSize = 1;
                        bool isHasInvoice = (ban.MaHoaDonMo.HasValue && ban.MaHoaDonMo.Value > 0) || (ban.TamTinh.HasValue && ban.TamTinh.Value > 0);
                        string trangThaiStr = ban.TrangThai != null ? ban.TrangThai.Trim() : "";
                        if (isHasInvoice || trangThaiStr.Equals("Có khách", StringComparison.OrdinalIgnoreCase) || trangThaiStr.Equals("Có người", StringComparison.OrdinalIgnoreCase))
                            btn.FlatAppearance.BorderColor = UITheme.TableCoKhachBorder;
                        else if (trangThaiStr.Equals("Đặt trước", StringComparison.OrdinalIgnoreCase))
                            btn.FlatAppearance.BorderColor = UITheme.TableDatTruocBorder;
                        else
                            btn.FlatAppearance.BorderColor = UITheme.TableTrongBorder;
                    }
                }
            }
        }

        private void HienThiThongTinBan(BanModel ban)
        {
            lblHuongDan.Visible = false;

            bool isHasInvoice = (ban.MaHoaDonMo.HasValue && ban.MaHoaDonMo.Value > 0) || (ban.TamTinh.HasValue && ban.TamTinh.Value > 0);
            string displayTrangThai = isHasInvoice ? "Có khách" : (string.IsNullOrWhiteSpace(ban.TrangThai) ? "Trống" : ban.TrangThai);

            lblTenBanDangChon.Text = "Tên bàn: " + ban.TenBan;
            lblKhuVucDangChon.Text = "Khu vực: " + ban.TenKhuVuc;
            lblTrangThaiBan.Text = "Trạng thái: " + displayTrangThai;

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

                // Nút "Tất cả" (Pill Button Active mặc định)
                Button btnAll = new Button
                {
                    Text = "Tất cả",
                    Height = 36,
                    AutoSize = true,
                    Margin = new Padding(3),
                    Cursor = Cursors.Hand,
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point),
                    BackColor = Color.FromArgb(217, 119, 6), // Amber-600
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
                                    Height = 36,
                                    AutoSize = true,
                                    Margin = new Padding(3),
                                    Cursor = Cursors.Hand,
                                    FlatStyle = FlatStyle.Flat,
                                    Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point),
                                    BackColor = Color.FromArgb(241, 245, 249), // Slate-100
                                    ForeColor = Color.FromArgb(71, 85, 105), // Slate-600
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
                        b.BackColor = Color.FromArgb(241, 245, 249);
                        b.ForeColor = Color.FromArgb(71, 85, 105);
                        b.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
                    }
                }

                btn.BackColor = Color.FromArgb(217, 119, 6);
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
                        SELECT m.MaMon, m.TenMon, m.MaDM, dm.TenDanhMuc, m.DonGia, m.HinhAnh
                        FROM dbo.MonAn m
                        LEFT JOIN dbo.DanhMuc dm ON m.MaDM = dm.MaDM
                        WHERE m.TrangThai = 1
                          AND (@MaDM IS NULL OR m.MaDM = @MaDM)
                          AND (@TuKhoa IS NULL OR m.TenMon LIKE '%' + @TuKhoa + '%')
                        ORDER BY m.TenMon";

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
                                    TenDanhMuc = reader["TenDanhMuc"] != DBNull.Value ? reader["TenDanhMuc"].ToString() : "",
                                    DonGia = Convert.ToDecimal(reader["DonGia"]),
                                    HinhAnh = reader["HinhAnh"] != DBNull.Value ? reader["HinhAnh"].ToString() : null
                                };

                                Panel pnlCard = TaoCardMonAn(mon);
                                flpMonAn.Controls.Add(pnlCard);
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

        private Panel TaoCardMonAn(MonAnModel mon)
        {
            Panel pnlCard = new Panel
            {
                Width = 145,
                Height = 175,
                Margin = new Padding(6),
                Cursor = Cursors.Hand,
                BackColor = Color.White,
                Tag = mon
            };

            bool isHovered = false;

            // Custom Paint for rounded border and hover highlight
            pnlCard.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                int radius = 10;
                using (System.Drawing.Drawing2D.GraphicsPath path = UITheme.GetRoundedPath(pnlCard.ClientRectangle, radius))
                {
                    Color borderCol = isHovered ? UITheme.PrimaryAccent : UITheme.BorderColor;
                    int penWidth = isHovered ? 2 : 1;
                    using (Pen pen = new Pen(borderCol, penWidth))
                    {
                        e.Graphics.DrawPath(pen, path);
                    }
                }
            };

            PictureBox picThumb = new PictureBox
            {
                Width = 135,
                Height = 95,
                Location = new Point(5, 5),
                SizeMode = PictureBoxSizeMode.Zoom,
                BackColor = Color.FromArgb(248, 250, 252),
                Tag = mon,
                Image = ImageHelper.LoadImageSafely(mon.HinhAnh, 135, 95, mon.TenMon)
            };

            Label lblTen = new Label
            {
                Text = mon.TenMon,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point),
                ForeColor = Color.FromArgb(15, 23, 42),
                Location = new Point(5, 103),
                Size = new Size(135, 42),
                TextAlign = ContentAlignment.TopLeft,
                AutoEllipsis = true,
                Tag = mon
            };

            Label lblGia = new Label
            {
                Text = DinhDangTien(mon.DonGia),
                Font = new Font("Segoe UI", 10.5F, FontStyle.Bold, GraphicsUnit.Point),
                ForeColor = UITheme.PrimaryAccent, // Amber Accent
                Location = new Point(5, 145),
                Size = new Size(135, 25),
                TextAlign = ContentAlignment.MiddleRight,
                Tag = mon
            };

            pnlCard.Controls.Add(picThumb);
            pnlCard.Controls.Add(lblTen);
            pnlCard.Controls.Add(lblGia);

            // Gán hiệu ứng Hover và sự kiện Click Fast Order cho Card và tất cả các control con
            Control[] cardControls = new Control[] { pnlCard, picThumb, lblTen, lblGia };
            foreach (Control ctrl in cardControls)
            {
                ctrl.MouseEnter += (s, e) =>
                {
                    isHovered = true;
                    pnlCard.BackColor = Color.FromArgb(255, 251, 235); // Soft Amber-50
                    pnlCard.Invalidate();
                };
                ctrl.MouseLeave += (s, e) =>
                {
                    isHovered = false;
                    pnlCard.BackColor = Color.White;
                    pnlCard.Invalidate();
                };
                ctrl.Click += (s, e) =>
                {
                    MonAn_FastOrderClick(mon);
                };
            }

            return pnlCard;
        }

        private void ThucHienThemMon(MonAnModel mon, string sizeName, decimal giaPhuThu, int soLuong, string ghiChu)
        {
            try
            {
                using (SqlConnection conn = Db.CreateConnection())
                {
                    conn.Open();
                    try
                    {
                        using (SqlCommand cmd = new SqlCommand("sp_ThemMonVaoHoaDon", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@MaBan", SqlDbType.Int).Value = currentBan.MaBan;
                            cmd.Parameters.Add("@MaNV", SqlDbType.Int).Value = UserSession.MaNV;
                            cmd.Parameters.Add("@MaMon", SqlDbType.Int).Value = mon.MaMon;
                            cmd.Parameters.Add("@SoLuong", SqlDbType.Int).Value = soLuong;
                            cmd.Parameters.Add("@TenSize", SqlDbType.NVarChar, 20).Value = (object)sizeName ?? DBNull.Value;
                            cmd.Parameters.Add("@GiaPhuThu", SqlDbType.Decimal).Value = giaPhuThu;
                            cmd.Parameters.Add("@GhiChu", SqlDbType.NVarChar, 300).Value = !string.IsNullOrWhiteSpace(ghiChu) ? (object)ghiChu : DBNull.Value;

                            cmd.ExecuteNonQuery();
                        }
                    }
                    catch (SqlException ex)
                    {
                        System.Diagnostics.Debug.WriteLine("SP call failed, using inline SQL fallback: " + ex.Message);
                        ThemMonVaoHoaDonTrucTiep(conn, currentBan.MaBan, UserSession.MaNV, mon.MaMon, sizeName, giaPhuThu, soLuong, ghiChu, mon.DonGia);
                    }
                }

                LamMoiDuLieuBanDangChon();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm món vào hóa đơn.\n\nChi tiết: " + ex.Message, "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MonAn_FastOrderClick(MonAnModel mon)
        {
            if (currentBan == null)
            {
                lblHuongDan.Text = "⚠️ Vui lòng chọn một bàn bên trái trước khi chọn món!";
                lblHuongDan.ForeColor = Color.Red;
                lblHuongDan.Visible = true;
                return;
            }

            // Mở modal chọn Size cho tất cả món ăn
            using (FrmChonSize frmSize = new FrmChonSize(mon))
            {
                if (frmSize.ShowDialog() != DialogResult.OK)
                {
                    return; // Người dùng hủy chọn
                }

                string sizeName = frmSize.SelectedSize;
                decimal giaPhuThu = frmSize.SelectedGiaPhuThu;
                int soLuong = frmSize.SelectedSoLuong;
                string ghiChu = frmSize.SelectedGhiChu;

                ThucHienThemMon(mon, sizeName, giaPhuThu, soLuong, ghiChu);
            }
        }

        private void ThemMonVaoHoaDonTrucTiep(SqlConnection conn, int maBan, int maNV, int maMon, string tenSize, decimal giaPhuThu, int soLuong, string ghiChu, decimal donGiaGoc)
        {
            decimal donGiaThucTe = donGiaGoc + giaPhuThu;
            int? maHD = null;

            string sqlFindHD = "SELECT TOP 1 MaHD FROM dbo.HoaDon WHERE MaBan = @MaBan AND TrangThai = 0";
            using (SqlCommand cmdFind = new SqlCommand(sqlFindHD, conn))
            {
                cmdFind.Parameters.Add("@MaBan", SqlDbType.Int).Value = maBan;
                object res = cmdFind.ExecuteScalar();
                if (res != null && res != DBNull.Value)
                    maHD = Convert.ToInt32(res);
            }

            if (!maHD.HasValue)
            {
                bool hasMaNVMo = CheckColumnExists(conn, "HoaDon", "MaNVMo");
                bool hasMaNVTao = CheckColumnExists(conn, "HoaDon", "MaNVTao");
                bool hasMaNV = CheckColumnExists(conn, "HoaDon", "MaNV");
                bool hasNgayTao = CheckColumnExists(conn, "HoaDon", "NgayTao");
                bool hasGioVao = CheckColumnExists(conn, "HoaDon", "GioVao");
                bool hasNgayMo = CheckColumnExists(conn, "HoaDon", "NgayMo");
                bool hasTongTienGoc = CheckColumnExists(conn, "HoaDon", "TongTienGoc");
                bool hasTongTienTT = CheckColumnExists(conn, "HoaDon", "TongTienThanhToan");
                bool hasTongTien = CheckColumnExists(conn, "HoaDon", "TongTien");

                List<string> cols = new List<string> { "MaBan", "TrangThai" };
                List<string> vals = new List<string> { "@MaBan", "0" };

                bool needMaNVParam = false;
                if (hasMaNVMo) { cols.Add("MaNVMo"); vals.Add("@MaNV"); needMaNVParam = true; }
                if (hasMaNVTao) { cols.Add("MaNVTao"); vals.Add("@MaNV"); needMaNVParam = true; }
                if (hasMaNV && !hasMaNVMo && !hasMaNVTao) { cols.Add("MaNV"); vals.Add("@MaNV"); needMaNVParam = true; }

                if (hasNgayTao) { cols.Add("NgayTao"); vals.Add("GETDATE()"); }
                if (hasGioVao) { cols.Add("GioVao"); vals.Add("GETDATE()"); }
                if (hasNgayMo) { cols.Add("NgayMo"); vals.Add("GETDATE()"); }

                if (hasTongTienGoc) { cols.Add("TongTienGoc"); vals.Add("0"); }
                if (hasTongTienTT) { cols.Add("TongTienThanhToan"); vals.Add("0"); }
                if (hasTongTien) { cols.Add("TongTien"); vals.Add("0"); }

                string sqlCreateHD = $"INSERT INTO dbo.HoaDon ({string.Join(", ", cols)}) VALUES ({string.Join(", ", vals)}); SELECT SCOPE_IDENTITY();";
                using (SqlCommand cmdCreate = new SqlCommand(sqlCreateHD, conn))
                {
                    cmdCreate.Parameters.Add("@MaBan", SqlDbType.Int).Value = maBan;
                    if (needMaNVParam) cmdCreate.Parameters.Add("@MaNV", SqlDbType.Int).Value = maNV;
                    maHD = Convert.ToInt32(cmdCreate.ExecuteScalar());
                }

                string sqlUpdBan = "UPDATE dbo.Ban SET DangSuDung = 1, TrangThai = N'Có người' WHERE MaBan = @MaBan";
                using (SqlCommand cmdBan = new SqlCommand(sqlUpdBan, conn))
                {
                    cmdBan.Parameters.Add("@MaBan", SqlDbType.Int).Value = maBan;
                    cmdBan.ExecuteNonQuery();
                }
            }

            string sqlCheckCT = "SELECT COUNT(*) FROM dbo.ChiTietHoaDon WHERE MaHD = @MaHD AND MaMon = @MaMon AND ISNULL(TenSize, '') = ISNULL(@TenSize, '')";
            int count = 0;
            using (SqlCommand cmdCheck = new SqlCommand(sqlCheckCT, conn))
            {
                cmdCheck.Parameters.Add("@MaHD", SqlDbType.Int).Value = maHD.Value;
                cmdCheck.Parameters.Add("@MaMon", SqlDbType.Int).Value = maMon;
                cmdCheck.Parameters.Add("@TenSize", SqlDbType.NVarChar, 20).Value = (object)tenSize ?? DBNull.Value;
                count = Convert.ToInt32(cmdCheck.ExecuteScalar());
            }

            bool isThanhTienComputed = false;
            using (SqlCommand cmdChk = new SqlCommand("SELECT is_computed FROM sys.columns WHERE object_id = OBJECT_ID('dbo.ChiTietHoaDon') AND name = 'ThanhTien'", conn))
            {
                object resChk = cmdChk.ExecuteScalar();
                if (resChk != null && resChk != DBNull.Value) isThanhTienComputed = Convert.ToBoolean(resChk);
            }

            if (count > 0)
            {
                string sqlUpdateCT = $@"UPDATE dbo.ChiTietHoaDon 
                    SET SoLuong = SoLuong + @SoLuong, 
                        DonGia = @DonGia, 
                        {(isThanhTienComputed ? "" : "ThanhTien = (SoLuong + @SoLuong) * @DonGia,")}
                        GhiChu = CASE WHEN @GhiChu IS NOT NULL AND @GhiChu <> '' THEN @GhiChu ELSE GhiChu END 
                    WHERE MaHD = @MaHD AND MaMon = @MaMon AND ISNULL(TenSize, '') = ISNULL(@TenSize, '')";
                using (SqlCommand cmdUpd = new SqlCommand(sqlUpdateCT, conn))
                {
                    cmdUpd.Parameters.Add("@SoLuong", SqlDbType.Int).Value = soLuong;
                    cmdUpd.Parameters.Add("@DonGia", SqlDbType.Decimal).Value = donGiaThucTe;
                    cmdUpd.Parameters.Add("@GhiChu", SqlDbType.NVarChar, 300).Value = !string.IsNullOrWhiteSpace(ghiChu) ? (object)ghiChu : DBNull.Value;
                    cmdUpd.Parameters.Add("@MaHD", SqlDbType.Int).Value = maHD.Value;
                    cmdUpd.Parameters.Add("@MaMon", SqlDbType.Int).Value = maMon;
                    cmdUpd.Parameters.Add("@TenSize", SqlDbType.NVarChar, 20).Value = (object)tenSize ?? DBNull.Value;
                    cmdUpd.ExecuteNonQuery();
                }
            }
            else
            {
                string sqlInsertCT = isThanhTienComputed 
                    ? @"INSERT INTO dbo.ChiTietHoaDon (MaHD, MaMon, TenSize, SoLuong, DonGia, GhiChu) 
                        VALUES (@MaHD, @MaMon, @TenSize, @SoLuong, @DonGia, @GhiChu)"
                    : @"INSERT INTO dbo.ChiTietHoaDon (MaHD, MaMon, TenSize, SoLuong, DonGia, ThanhTien, GhiChu) 
                        VALUES (@MaHD, @MaMon, @TenSize, @SoLuong, @DonGia, @SoLuong * @DonGia, @GhiChu)";
                
                using (SqlCommand cmdIns = new SqlCommand(sqlInsertCT, conn))
                {
                    cmdIns.Parameters.Add("@MaHD", SqlDbType.Int).Value = maHD.Value;
                    cmdIns.Parameters.Add("@MaMon", SqlDbType.Int).Value = maMon;
                    cmdIns.Parameters.Add("@TenSize", SqlDbType.NVarChar, 20).Value = (object)tenSize ?? DBNull.Value;
                    cmdIns.Parameters.Add("@SoLuong", SqlDbType.Int).Value = soLuong;
                    cmdIns.Parameters.Add("@DonGia", SqlDbType.Decimal).Value = donGiaThucTe;
                    cmdIns.Parameters.Add("@GhiChu", SqlDbType.NVarChar, 300).Value = !string.IsNullOrWhiteSpace(ghiChu) ? (object)ghiChu : DBNull.Value;
                    cmdIns.ExecuteNonQuery();
                }
            }

            bool hasTongTienThanhToan = CheckColumnExists(conn, "HoaDon", "TongTienThanhToan");
            bool hasTongTienCol = CheckColumnExists(conn, "HoaDon", "TongTien");
            string updateSql = "UPDATE dbo.HoaDon SET TongTienGoc = (SELECT ISNULL(SUM(ThanhTien), 0) FROM dbo.ChiTietHoaDon WHERE MaHD = @MaHD)";
            if (hasTongTienThanhToan) updateSql += ", TongTienThanhToan = (SELECT ISNULL(SUM(ThanhTien), 0) FROM dbo.ChiTietHoaDon WHERE MaHD = @MaHD)";
            else if (hasTongTienCol) updateSql += ", TongTien = (SELECT ISNULL(SUM(ThanhTien), 0) FROM dbo.ChiTietHoaDon WHERE MaHD = @MaHD)";
            updateSql += " WHERE MaHD = @MaHD";

            using (SqlCommand cmdTot = new SqlCommand(updateSql, conn))
            {
                cmdTot.Parameters.Add("@MaHD", SqlDbType.Int).Value = maHD.Value;
                cmdTot.ExecuteNonQuery();
            }
        }

        private bool CheckColumnExists(SqlConnection conn, string tableName, string columnName)
        {
            try
            {
                string sql = "SELECT COUNT(*) FROM sys.columns WHERE object_id = OBJECT_ID(@TableName) AND name = @ColumnName";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@TableName", "dbo." + tableName);
                    cmd.Parameters.AddWithValue("@ColumnName", columnName);
                    object res = cmd.ExecuteScalar();
                    return res != null && Convert.ToInt32(res) > 0;
                }
            }
            catch
            {
                return false;
            }
        }

        private void ResetSelectedMonAn()
        {
            if (currentMonAnButton != null)
            {
                currentMonAnButton.FlatAppearance.BorderSize = 1;
                currentMonAnButton.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
                currentMonAnButton.BackColor = Color.FromArgb(248, 250, 252);
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
                    lblTongTamTinh.Text = "Tổng: 0 đ";
                    DatLaiMonDangChon();
                    return;
                }

                List<ChiTietHoaDonModel> listChiTiet = new List<ChiTietHoaDonModel>();

                using (SqlConnection conn = Db.CreateConnection())
                {
                    string sql = @"
                        SELECT ct.MaCTHD, ct.MaHD, ct.MaMon, m.TenMon, 
                               ISNULL(ct.TenSize, '') AS TenSize, 
                               ct.SoLuong, ct.DonGia, ct.ThanhTien, ct.GhiChu
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
                                    TenSize = reader["TenSize"] != DBNull.Value ? reader["TenSize"].ToString() : "",
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

                dgvChiTietHoaDon.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dgvChiTietHoaDon.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;

                if (dgvChiTietHoaDon.Columns["colTenMon"] != null)
                {
                    dgvChiTietHoaDon.Columns["colTenMon"].DataPropertyName = "TenMonHienThi";
                    dgvChiTietHoaDon.Columns["colTenMon"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                }
                else if (dgvChiTietHoaDon.Columns["TenMon"] != null)
                {
                    dgvChiTietHoaDon.Columns["TenMon"].DataPropertyName = "TenMonHienThi";
                    dgvChiTietHoaDon.Columns["TenMon"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                }

                // Format hiển thị và lề cho các cột trong DataGridView Hóa đơn
                if (dgvChiTietHoaDon.Columns["colDonGia"] != null)
                {
                    dgvChiTietHoaDon.Columns["colDonGia"].DefaultCellStyle.Format = "#,##0";
                    dgvChiTietHoaDon.Columns["colDonGia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
                if (dgvChiTietHoaDon.Columns["colThanhTien"] != null)
                {
                    dgvChiTietHoaDon.Columns["colThanhTien"].DefaultCellStyle.Format = "#,##0";
                    dgvChiTietHoaDon.Columns["colThanhTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
                if (dgvChiTietHoaDon.Columns["colSoLuong"] != null)
                {
                    dgvChiTietHoaDon.Columns["colSoLuong"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                if (dgvChiTietHoaDon.Columns["colGiamSL"] != null)
                {
                    dgvChiTietHoaDon.Columns["colGiamSL"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                if (dgvChiTietHoaDon.Columns["colTangSL"] != null)
                {
                    dgvChiTietHoaDon.Columns["colTangSL"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                if (dgvChiTietHoaDon.Columns["colXoa"] != null)
                {
                    dgvChiTietHoaDon.Columns["colXoa"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

                decimal tongTamTinh = listChiTiet.Sum(x => x.ThanhTien);
                lblTongTamTinh.Text = "Tổng: " + DinhDangTien(tongTamTinh);

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

            // Mở modal chọn Size cho tất cả món ăn
            using (FrmChonSize frmSize = new FrmChonSize(currentMonAn))
            {
                if (frmSize.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                string sizeName = frmSize.SelectedSize;
                decimal giaPhuThu = frmSize.SelectedGiaPhuThu;
                int soLuong = frmSize.SelectedSoLuong;
                string ghiChu = frmSize.SelectedGhiChu;

                ThucHienThemMon(currentMonAn, sizeName, giaPhuThu, soLuong, ghiChu);

                using (var toast = new FrmSuccessToast("Đã thêm món", $"Đã thêm {currentMonAn.TenMon} ({sizeName})"))
                {
                    toast.ShowDialog();
                }

                // Reset thông tin thêm món
                ResetSelectedMonAn();
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

        private void dgvChiTietHoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            string colName = dgvChiTietHoaDon.Columns[e.ColumnIndex].Name;
            if (dgvChiTietHoaDon.Rows[e.RowIndex].DataBoundItem is ChiTietHoaDonModel item)
            {
                if (colName == "colGiamSL")
                {
                    int newSL = item.SoLuong - 1;
                    CapNhatSoLuongCTHDDirect(item.MaCTHD, newSL);
                }
                else if (colName == "colTangSL")
                {
                    int newSL = item.SoLuong + 1;
                    CapNhatSoLuongCTHDDirect(item.MaCTHD, newSL);
                }
                else if (colName == "colXoa")
                {
                    CapNhatSoLuongCTHDDirect(item.MaCTHD, 0);
                }
            }
        }

        private void CapNhatSoLuongCTHDDirect(int maCTHD, int soLuongMoi)
        {
            try
            {
                using (SqlConnection conn = Db.CreateConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("sp_CapNhatSoLuongMon", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@MaNV", SqlDbType.Int).Value = UserSession.MaNV;
                        cmd.Parameters.Add("@MaCTHD", SqlDbType.Int).Value = maCTHD;
                        cmd.Parameters.Add("@SoLuongMoi", SqlDbType.Int).Value = Math.Max(0, soLuongMoi);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                LamMoiDuLieuBanDangChon();
                DatLaiMonDangChon();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật số lượng món.\n\nChi tiết: " + ex.Message, "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvChiTietHoaDon_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            string colName = dgvChiTietHoaDon.Columns[e.ColumnIndex].Name;
            if (colName == "colGhiChu" && dgvChiTietHoaDon.Rows[e.RowIndex].DataBoundItem is ChiTietHoaDonModel item)
            {
                string ghiChuMoi = Convert.ToString(dgvChiTietHoaDon.Rows[e.RowIndex].Cells["colGhiChu"].Value);
                CapNhatGhiChuCTHDDirect(item.MaCTHD, ghiChuMoi);
            }
        }

        private void CapNhatGhiChuCTHDDirect(int maCTHD, string ghiChu)
        {
            try
            {
                using (SqlConnection conn = Db.CreateConnection())
                {
                    string sql = "UPDATE dbo.ChiTietHoaDon SET GhiChu = @GhiChu WHERE MaCTHD = @MaCTHD";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.Add("@MaCTHD", SqlDbType.Int).Value = maCTHD;
                        cmd.Parameters.Add("@GhiChu", SqlDbType.NVarChar, 300).Value = string.IsNullOrWhiteSpace(ghiChu) ? (object)DBNull.Value : ghiChu.Trim();

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu ghi chú món.\n\nChi tiết: " + ex.Message, "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

                using (var toast = new FrmSuccessToast("Cập nhật số lượng", "Thành công"))
                {
                    toast.ShowDialog();
                }

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

                using (var toast = new FrmSuccessToast("Đã xóa món", "Cập nhật dữ liệu thành công"))
                {
                    toast.ShowDialog();
                }

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

        private void LoadKhuyenMai()
        {
            try
            {
                cboKhuyenMai.Items.Clear();
                
                using (SqlConnection conn = Db.CreateConnection())
                {
                    string sql = "SELECT * FROM dbo.KhuyenMai WHERE TrangThai = 1 AND NgayBatDau <= GETDATE() AND (NgayKetThuc >= CAST(GETDATE() AS DATE) OR NgayKetThuc IS NULL) AND (SoLuotConLai IS NULL OR SoLuotConLai > 0)";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                KhuyenMaiModel km = new KhuyenMaiModel
                                {
                                    MaKM = Convert.ToInt32(reader["MaKM"]),
                                    TenKM = reader["TenKM"].ToString(),
                                    MaKhuyenMai = reader["MaKhuyenMai"].ToString(),
                                    LoaiGiamGia = Convert.ToInt32(reader["LoaiGiamGia"]),
                                    GiaTriGiam = Convert.ToDecimal(reader["GiaTriGiam"]),
                                    GiamToiDa = reader["GiamToiDa"] != DBNull.Value ? (decimal?)Convert.ToDecimal(reader["GiamToiDa"]) : null,
                                    DieuKienToiThieu = Convert.ToDecimal(reader["DieuKienToiThieu"]),
                                    NgayBatDau = Convert.ToDateTime(reader["NgayBatDau"]),
                                    NgayKetThuc = Convert.ToDateTime(reader["NgayKetThuc"]),
                                    SoLuotConLai = reader["SoLuotConLai"] != DBNull.Value ? (int?)Convert.ToInt32(reader["SoLuotConLai"]) : null,
                                    TrangThai = Convert.ToBoolean(reader["TrangThai"])
                                };
                                cboKhuyenMai.Items.Add(km);
                            }
                        }
                    }
                }

                cboKhuyenMai.DisplayMember = "TenKM";
                cboKhuyenMai.ValueMember = "MaKhuyenMai";
                
                if (cboKhuyenMai.Items.Count > 0)
                {
                    cboKhuyenMai.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                // Ignored or log
            }
        }

        private void cboKhuyenMai_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chkApDungKhuyenMai.Checked)
            {
                // Re-evaluate if valid
                chkApDungKhuyenMai_CheckedChanged(null, null);
            }
        }

        private void chkApDungKhuyenMai_CheckedChanged(object sender, EventArgs e)
        {
            if (chkApDungKhuyenMai.Checked)
            {
                decimal tongTamTinh = currentBan?.TamTinh ?? 0;
                if (cboKhuyenMai.SelectedItem is KhuyenMaiModel km)
                {
                    if (tongTamTinh < km.DieuKienToiThieu)
                    {
                        MessageBox.Show($"Chưa đủ điều kiện! Đơn hàng cần tối thiểu {km.DieuKienToiThieu:N0}đ để áp dụng mã này.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        chkApDungKhuyenMai.Checked = false;
                        return;
                    }
                }
                else
                {
                    chkApDungKhuyenMai.Checked = false;
                }
            }
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

            // Calculate KM
            decimal soTienKhuyenMai = 0;
            string maKMApDung = "";
            if (chkApDungKhuyenMai.Checked && cboKhuyenMai.SelectedItem is KhuyenMaiModel km)
            {
                soTienKhuyenMai = km.TinhSoTienGiam(tongTamTinh);
                maKMApDung = km.MaKhuyenMai;
            }

            // Mở Form thanh toán dạng Dialog
            using (FrmThanhToan frm = new FrmThanhToan(currentBan.MaHoaDonMo.Value, currentBan.MaBan, currentBan.TenBan, tongTamTinh, soTienKhuyenMai, maKMApDung))
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

        #region 6. SHIFT CHECKOUT LOGIC

        private void InitShiftTimer()
        {
            if (UserSession.CurrentShiftId > 0)
            {
                var checkInTime = ShiftService.GetShiftCheckInTime(UserSession.CurrentShiftId);
                if (checkInTime.HasValue)
                {
                    shiftStartTime = checkInTime.Value;
                    shiftTimer.Interval = 1000;
                    shiftTimer.Tick += ShiftTimer_Tick;
                    shiftTimer.Start();
                    
                    // Trigger once immediately
                    ShiftTimer_Tick(null, EventArgs.Empty);
                }
                else
                {
                    lblShiftInfo.Text = "Thời gian vào ca: Không xác định";
                }
            }
            else
            {
                lblShiftInfo.Text = "Không có ca làm việc";
                lblActiveShiftBadge.Text = "⚪ Không trong ca";
                lblActiveShiftBadge.ForeColor = Color.Gray;
                btnKetCaTopBar.Enabled = false;
            }
        }

        private void ShiftTimer_Tick(object sender, EventArgs e)
        {
            TimeSpan duration = DateTime.Now - shiftStartTime;
            lblShiftInfo.Text = $"Vào ca: {shiftStartTime:HH:mm} | Thời gian ca: {duration.Hours:D2}h {duration.Minutes:D2}m {duration.Seconds:D2}s";
        }

        private void btnKetCaTopBar_Click(object sender, EventArgs e)
        {
            TimeSpan duration = DateTime.Now - shiftStartTime;
            string msg = $"Xác nhận KẾT CA LÀM VIỆC?\n- Thời gian vào ca: {shiftStartTime:HH:mm dd/MM/yyyy}\n- Thời gian kết ca: {DateTime.Now:HH:mm dd/MM/yyyy}\n- Thời lượng ca này: {(int)duration.TotalHours} giờ {duration.Minutes} phút";

            if (MessageBox.Show(msg, "Xác nhận kết ca", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (ShiftService.DirectCheckOut(UserSession.CurrentShiftId))
                {
                    shiftTimer.Stop();
                    MessageBox.Show("Kết ca thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    FrmMain main = this.FindForm() as FrmMain;
                    if (main != null)
                    {
                        main.Logout();
                    }
                    else
                    {
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra khi cập nhật ca làm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion
    }
}
