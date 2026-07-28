namespace QLCF.Forms
{
    partial class FrmBanHang
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.lblKhuVuc = new System.Windows.Forms.Label();
            this.cboKhuVuc = new System.Windows.Forms.ComboBox();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.pnlShiftHeader = new System.Windows.Forms.Panel();
            this.lblActiveShiftBadge = new System.Windows.Forms.Label();
            this.lblShiftInfo = new System.Windows.Forms.Label();
            this.btnKetCaTopBar = new System.Windows.Forms.Button();
            this.shiftTimer = new System.Windows.Forms.Timer();
            this.flpSoDoBan = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlMiddle = new System.Windows.Forms.Panel();
            this.flpMonAn = new System.Windows.Forms.FlowLayoutPanel();
            this.flpDanhMuc = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlTimKiem = new System.Windows.Forms.Panel();
            this.btnTimMon = new System.Windows.Forms.Button();
            this.txtTimMon = new System.Windows.Forms.TextBox();
            this.lblTimMonTitle = new System.Windows.Forms.Label();
            this.pnlRightContainer = new System.Windows.Forms.Panel();
            this.dgvChiTietHoaDon = new System.Windows.Forms.DataGridView();
            this.colMaCTHD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenMon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDonGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThanhTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGhiChu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlThemMonAction = new System.Windows.Forms.Panel();
            this.lblTongTamTinh = new System.Windows.Forms.Label();
            this.btnThemMon = new System.Windows.Forms.Button();
            this.txtGhiChuMon = new System.Windows.Forms.TextBox();
            this.lblGhiChuLabel = new System.Windows.Forms.Label();
            this.nudSoLuong = new System.Windows.Forms.NumericUpDown();
            this.lblSoLuongLabel = new System.Windows.Forms.Label();
            this.lblMonDangChon = new System.Windows.Forms.Label();
            this.lblMonTrongHoaDonDangChon = new System.Windows.Forms.Label();
            this.lblSoLuongCapNhatLabel = new System.Windows.Forms.Label();
            this.nudSoLuongCapNhat = new System.Windows.Forms.NumericUpDown();
            this.btnCapNhatSoLuong = new System.Windows.Forms.Button();
            this.btnXoaMonKhoiHoaDon = new System.Windows.Forms.Button();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.pnlThongTinBanHeader = new System.Windows.Forms.Panel();
            this.btnGopBan = new System.Windows.Forms.Button();
            this.btnChuyenBan = new System.Windows.Forms.Button();
            this.lblHuongDan = new System.Windows.Forms.Label();
            this.lblMaHoaDonMo = new System.Windows.Forms.Label();
            this.lblGioVao = new System.Windows.Forms.Label();
            this.lblTrangThaiBan = new System.Windows.Forms.Label();
            this.lblKhuVucDangChon = new System.Windows.Forms.Label();
            this.lblTenBanDangChon = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.pnlShiftHeader.SuspendLayout();
            this.pnlMiddle.SuspendLayout();
            this.pnlTimKiem.SuspendLayout();
            this.pnlRightContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietHoaDon)).BeginInit();
            this.pnlThemMonAction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuongCapNhat)).BeginInit();
            this.pnlThongTinBanHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.pnlHeader.Controls.Add(this.lblTieuDe);
            this.pnlHeader.Controls.Add(this.lblKhuVuc);
            this.pnlHeader.Controls.Add(this.cboKhuVuc);
            this.pnlHeader.Controls.Add(this.btnLamMoi);
            this.pnlHeader.Controls.Add(this.btnDong);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1300, 58);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 12.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTieuDe.ForeColor = System.Drawing.Color.White;
            this.lblTieuDe.Location = new System.Drawing.Point(18, 14);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(320, 28);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "SƠ ĐỒ BÀN - BÁN HÀNG QLCF";
            // 
            // lblKhuVuc
            // 
            this.lblKhuVuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblKhuVuc.AutoSize = true;
            this.lblKhuVuc.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKhuVuc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.lblKhuVuc.Location = new System.Drawing.Point(710, 18);
            this.lblKhuVuc.Name = "lblKhuVuc";
            this.lblKhuVuc.Size = new System.Drawing.Size(76, 21);
            this.lblKhuVuc.TabIndex = 1;
            this.lblKhuVuc.Text = "Khu vực:";
            // 
            // cboKhuVuc
            // 
            this.cboKhuVuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboKhuVuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKhuVuc.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboKhuVuc.FormattingEnabled = true;
            this.cboKhuVuc.Location = new System.Drawing.Point(792, 14);
            this.cboKhuVuc.Name = "cboKhuVuc";
            this.cboKhuVuc.Size = new System.Drawing.Size(200, 29);
            this.cboKhuVuc.TabIndex = 2;
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLamMoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnLamMoi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLamMoi.FlatAppearance.BorderSize = 0;
            this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoi.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLamMoi.ForeColor = System.Drawing.Color.White;
            this.btnLamMoi.Location = new System.Drawing.Point(1004, 12);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(110, 34);
            this.btnLamMoi.TabIndex = 3;
            this.btnLamMoi.Text = "🔄 Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = false;
            // 
            // btnDong
            // 
            this.btnDong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(29)))), ((int)(((byte)(72)))));
            this.btnDong.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDong.FlatAppearance.BorderSize = 0;
            this.btnDong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDong.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDong.ForeColor = System.Drawing.Color.White;
            this.btnDong.Location = new System.Drawing.Point(1180, 12);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(100, 34);
            this.btnDong.TabIndex = 4;
            this.btnDong.Text = "❌ Đóng";
            this.btnDong.UseVisualStyleBackColor = false;
            // 
            // pnlShiftHeader
            // 
            this.pnlShiftHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.pnlShiftHeader.Controls.Add(this.btnKetCaTopBar);
            this.pnlShiftHeader.Controls.Add(this.lblShiftInfo);
            this.pnlShiftHeader.Controls.Add(this.lblActiveShiftBadge);
            this.pnlShiftHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlShiftHeader.Location = new System.Drawing.Point(0, 58);
            this.pnlShiftHeader.Name = "pnlShiftHeader";
            this.pnlShiftHeader.Size = new System.Drawing.Size(1300, 45);
            this.pnlShiftHeader.TabIndex = 4;
            // 
            // lblActiveShiftBadge
            // 
            this.lblActiveShiftBadge.AutoSize = true;
            this.lblActiveShiftBadge.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActiveShiftBadge.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.lblActiveShiftBadge.Location = new System.Drawing.Point(18, 12);
            this.lblActiveShiftBadge.Name = "lblActiveShiftBadge";
            this.lblActiveShiftBadge.Size = new System.Drawing.Size(155, 21);
            this.lblActiveShiftBadge.TabIndex = 0;
            this.lblActiveShiftBadge.Text = "🟢 Đang trong ca làm";
            // 
            // lblShiftInfo
            // 
            this.lblShiftInfo.AutoSize = true;
            this.lblShiftInfo.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShiftInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.lblShiftInfo.Location = new System.Drawing.Point(200, 12);
            this.lblShiftInfo.Name = "lblShiftInfo";
            this.lblShiftInfo.Size = new System.Drawing.Size(262, 21);
            this.lblShiftInfo.TabIndex = 1;
            this.lblShiftInfo.Text = "Thời gian vào ca: -- | Đã làm: --";
            // 
            // btnKetCaTopBar
            // 
            this.btnKetCaTopBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKetCaTopBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.btnKetCaTopBar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKetCaTopBar.FlatAppearance.BorderSize = 0;
            this.btnKetCaTopBar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKetCaTopBar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKetCaTopBar.ForeColor = System.Drawing.Color.White;
            this.btnKetCaTopBar.Location = new System.Drawing.Point(1110, 6);
            this.btnKetCaTopBar.Name = "btnKetCaTopBar";
            this.btnKetCaTopBar.Size = new System.Drawing.Size(170, 33);
            this.btnKetCaTopBar.TabIndex = 2;
            this.btnKetCaTopBar.Text = "🔴 Kết Ca && Chốt Sổ";
            this.btnKetCaTopBar.UseVisualStyleBackColor = false;
            // 
            // flpSoDoBan
            // 
            this.flpSoDoBan.AutoScroll = true;
            this.flpSoDoBan.BackColor = System.Drawing.Color.White;
            this.flpSoDoBan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpSoDoBan.Dock = System.Windows.Forms.DockStyle.Left;
            this.flpSoDoBan.Location = new System.Drawing.Point(0, 103);
            this.flpSoDoBan.Name = "flpSoDoBan";
            this.flpSoDoBan.Padding = new System.Windows.Forms.Padding(6);
            this.flpSoDoBan.Size = new System.Drawing.Size(275, 647);
            this.flpSoDoBan.TabIndex = 1;
            // 
            // pnlRightContainer
            // 
            this.pnlRightContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.pnlRightContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRightContainer.Controls.Add(this.dgvChiTietHoaDon);
            this.pnlRightContainer.Controls.Add(this.pnlThemMonAction);
            this.pnlRightContainer.Controls.Add(this.pnlThongTinBanHeader);
            this.pnlRightContainer.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlRightContainer.Location = new System.Drawing.Point(820, 103);
            this.pnlRightContainer.Name = "pnlRightContainer";
            this.pnlRightContainer.Padding = new System.Windows.Forms.Padding(8);
            this.pnlRightContainer.Size = new System.Drawing.Size(480, 647);
            this.pnlRightContainer.TabIndex = 3;
            // 
            // dgvChiTietHoaDon
            // 
            this.dgvChiTietHoaDon.AllowUserToAddRows = false;
            this.dgvChiTietHoaDon.AllowUserToDeleteRows = false;
            this.dgvChiTietHoaDon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChiTietHoaDon.BackgroundColor = System.Drawing.Color.White;
            this.dgvChiTietHoaDon.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvChiTietHoaDon.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvChiTietHoaDon.ColumnHeadersHeight = 36;
            this.colGiamSL = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colTangSL = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colXoa = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dgvChiTietHoaDon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaCTHD,
            this.colTenMon,
            this.colGiamSL,
            this.colSoLuong,
            this.colTangSL,
            this.colDonGia,
            this.colThanhTien,
            this.colGhiChu,
            this.colXoa});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvChiTietHoaDon.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvChiTietHoaDon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvChiTietHoaDon.EnableHeadersVisualStyles = false;
            this.dgvChiTietHoaDon.Location = new System.Drawing.Point(8, 123);
            this.dgvChiTietHoaDon.MultiSelect = false;
            this.dgvChiTietHoaDon.Name = "dgvChiTietHoaDon";
            this.dgvChiTietHoaDon.ReadOnly = false;
            this.dgvChiTietHoaDon.RowHeadersVisible = false;
            this.dgvChiTietHoaDon.RowHeadersWidth = 51;
            this.dgvChiTietHoaDon.RowTemplate.Height = 38;
            this.dgvChiTietHoaDon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChiTietHoaDon.Size = new System.Drawing.Size(462, 321);
            this.dgvChiTietHoaDon.TabIndex = 1;
            // 
            // colMaCTHD
            // 
            this.colMaCTHD.DataPropertyName = "MaCTHD";
            this.colMaCTHD.HeaderText = "Mã CTHD";
            this.colMaCTHD.MinimumWidth = 6;
            this.colMaCTHD.Name = "colMaCTHD";
            this.colMaCTHD.ReadOnly = true;
            this.colMaCTHD.Visible = false;
            // 
            // colTenMon
            // 
            this.colTenMon.DataPropertyName = "TenMon";
            this.colTenMon.FillWeight = 140F;
            this.colTenMon.HeaderText = "Tên món";
            this.colTenMon.MinimumWidth = 130;
            this.colTenMon.Name = "colTenMon";
            this.colTenMon.ReadOnly = true;
            // 
            // colGiamSL
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colGiamSL.DefaultCellStyle = dataGridViewCellStyle3;
            this.colGiamSL.HeaderText = "-";
            this.colGiamSL.MinimumWidth = 26;
            this.colGiamSL.Name = "colGiamSL";
            this.colGiamSL.Text = "➖";
            this.colGiamSL.UseColumnTextForButtonValue = true;
            this.colGiamSL.FillWeight = 22F;
            // 
            // colSoLuong
            // 
            this.colSoLuong.DataPropertyName = "SoLuong";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colSoLuong.DefaultCellStyle = dataGridViewCellStyle4;
            this.colSoLuong.FillWeight = 28F;
            this.colSoLuong.HeaderText = "SL";
            this.colSoLuong.MinimumWidth = 28;
            this.colSoLuong.Name = "colSoLuong";
            this.colSoLuong.ReadOnly = true;
            // 
            // colTangSL
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colTangSL.DefaultCellStyle = dataGridViewCellStyle5;
            this.colTangSL.HeaderText = "+";
            this.colTangSL.MinimumWidth = 26;
            this.colTangSL.Name = "colTangSL";
            this.colTangSL.Text = "➕";
            this.colTangSL.UseColumnTextForButtonValue = true;
            this.colTangSL.FillWeight = 22F;
            // 
            // colDonGia
            // 
            this.colDonGia.DataPropertyName = "DonGia";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "#,##0";
            this.colDonGia.DefaultCellStyle = dataGridViewCellStyle6;
            this.colDonGia.FillWeight = 55F;
            this.colDonGia.HeaderText = "Đơn giá";
            this.colDonGia.MinimumWidth = 65;
            this.colDonGia.Name = "colDonGia";
            this.colDonGia.ReadOnly = true;
            // 
            // colThanhTien
            // 
            this.colThanhTien.DataPropertyName = "ThanhTien";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "#,##0";
            this.colThanhTien.DefaultCellStyle = dataGridViewCellStyle7;
            this.colThanhTien.FillWeight = 65F;
            this.colThanhTien.HeaderText = "Thành tiền";
            this.colThanhTien.MinimumWidth = 75;
            this.colThanhTien.Name = "colThanhTien";
            this.colThanhTien.ReadOnly = true;
            // 
            // colGhiChu
            // 
            this.colGhiChu.DataPropertyName = "GhiChu";
            this.colGhiChu.FillWeight = 45F;
            this.colGhiChu.HeaderText = "Ghi chú";
            this.colGhiChu.MinimumWidth = 50;
            this.colGhiChu.Name = "colGhiChu";
            this.colGhiChu.ReadOnly = false;
            // 
            // colXoa
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colXoa.DefaultCellStyle = dataGridViewCellStyle8;
            this.colXoa.HeaderText = "Xóa";
            this.colXoa.MinimumWidth = 26;
            this.colXoa.Name = "colXoa";
            this.colXoa.Text = "❌";
            this.colXoa.UseColumnTextForButtonValue = true;
            this.colXoa.FillWeight = 22F;
            // 
            // pnlThemMonAction
            // 
            this.pnlThemMonAction.BackColor = System.Drawing.Color.White;
            this.pnlThemMonAction.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlThemMonAction.Controls.Add(this.lblTongTamTinh);
            this.pnlThemMonAction.Controls.Add(this.btnThemMon);
            this.pnlThemMonAction.Controls.Add(this.txtGhiChuMon);
            this.pnlThemMonAction.Controls.Add(this.lblGhiChuLabel);
            this.pnlThemMonAction.Controls.Add(this.nudSoLuong);
            this.pnlThemMonAction.Controls.Add(this.lblSoLuongLabel);
            this.pnlThemMonAction.Controls.Add(this.lblMonDangChon);
            this.pnlThemMonAction.Controls.Add(this.lblMonTrongHoaDonDangChon);
            this.pnlThemMonAction.Controls.Add(this.lblSoLuongCapNhatLabel);
            this.pnlThemMonAction.Controls.Add(this.nudSoLuongCapNhat);
            this.pnlThemMonAction.Controls.Add(this.btnCapNhatSoLuong);
            this.pnlThemMonAction.Controls.Add(this.btnThanhToan);
            this.pnlThemMonAction.Controls.Add(this.btnXoaMonKhoiHoaDon);
            this.pnlThemMonAction.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlThemMonAction.Location = new System.Drawing.Point(8, 444);
            this.pnlThemMonAction.Name = "pnlThemMonAction";
            this.pnlThemMonAction.Size = new System.Drawing.Size(442, 238);
            this.pnlThemMonAction.TabIndex = 2;
            // 
            // lblMonDangChon
            // 
            this.lblMonDangChon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMonDangChon.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonDangChon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(132)))), ((int)(((byte)(199)))));
            this.lblMonDangChon.Location = new System.Drawing.Point(10, 8);
            this.lblMonDangChon.Name = "lblMonDangChon";
            this.lblMonDangChon.Size = new System.Drawing.Size(420, 20);
            this.lblMonDangChon.TabIndex = 0;
            this.lblMonDangChon.Text = "Món đang chọn: Chưa chọn món";
            // 
            // lblSoLuongLabel
            // 
            this.lblSoLuongLabel.AutoSize = true;
            this.lblSoLuongLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoLuongLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblSoLuongLabel.Location = new System.Drawing.Point(10, 35);
            this.lblSoLuongLabel.Name = "lblSoLuongLabel";
            this.lblSoLuongLabel.Size = new System.Drawing.Size(31, 20);
            this.lblSoLuongLabel.TabIndex = 1;
            this.lblSoLuongLabel.Text = "SL:";
            // 
            // nudSoLuong
            // 
            this.nudSoLuong.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudSoLuong.Location = new System.Drawing.Point(45, 32);
            this.nudSoLuong.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSoLuong.Name = "nudSoLuong";
            this.nudSoLuong.Size = new System.Drawing.Size(55, 29);
            this.nudSoLuong.TabIndex = 2;
            this.nudSoLuong.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblGhiChuLabel
            // 
            this.lblGhiChuLabel.AutoSize = true;
            this.lblGhiChuLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGhiChuLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblGhiChuLabel.Location = new System.Drawing.Point(110, 35);
            this.lblGhiChuLabel.Name = "lblGhiChuLabel";
            this.lblGhiChuLabel.Size = new System.Drawing.Size(66, 20);
            this.lblGhiChuLabel.TabIndex = 3;
            this.lblGhiChuLabel.Text = "Ghi chú:";
            // 
            // txtGhiChuMon
            // 
            this.txtGhiChuMon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGhiChuMon.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGhiChuMon.Location = new System.Drawing.Point(180, 32);
            this.txtGhiChuMon.Name = "txtGhiChuMon";
            this.txtGhiChuMon.Size = new System.Drawing.Size(140, 27);
            this.txtGhiChuMon.TabIndex = 4;
            // 
            // btnThemMon
            // 
            this.btnThemMon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThemMon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.btnThemMon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThemMon.FlatAppearance.BorderSize = 0;
            this.btnThemMon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemMon.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemMon.ForeColor = System.Drawing.Color.White;
            this.btnThemMon.Location = new System.Drawing.Point(328, 30);
            this.btnThemMon.Name = "btnThemMon";
            this.btnThemMon.Size = new System.Drawing.Size(102, 31);
            this.btnThemMon.TabIndex = 5;
            this.btnThemMon.Text = "➕ Thêm món";
            this.btnThemMon.UseVisualStyleBackColor = false;
            // 
            // lblMonTrongHoaDonDangChon
            // 
            this.lblMonTrongHoaDonDangChon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMonTrongHoaDonDangChon.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonTrongHoaDonDangChon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(119)))), ((int)(((byte)(6)))));
            this.lblMonTrongHoaDonDangChon.Location = new System.Drawing.Point(10, 72);
            this.lblMonTrongHoaDonDangChon.Name = "lblMonTrongHoaDonDangChon";
            this.lblMonTrongHoaDonDangChon.Size = new System.Drawing.Size(420, 20);
            this.lblMonTrongHoaDonDangChon.TabIndex = 6;
            this.lblMonTrongHoaDonDangChon.Text = "Đang chọn trong HD: Chưa chọn món";
            // 
            // lblSoLuongCapNhatLabel
            // 
            this.lblSoLuongCapNhatLabel.AutoSize = true;
            this.lblSoLuongCapNhatLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoLuongCapNhatLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblSoLuongCapNhatLabel.Location = new System.Drawing.Point(10, 100);
            this.lblSoLuongCapNhatLabel.Name = "lblSoLuongCapNhatLabel";
            this.lblSoLuongCapNhatLabel.Size = new System.Drawing.Size(95, 20);
            this.lblSoLuongCapNhatLabel.TabIndex = 7;
            this.lblSoLuongCapNhatLabel.Text = "Số lượng mới:";
            // 
            // nudSoLuongCapNhat
            // 
            this.nudSoLuongCapNhat.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudSoLuongCapNhat.Location = new System.Drawing.Point(110, 97);
            this.nudSoLuongCapNhat.Name = "nudSoLuongCapNhat";
            this.nudSoLuongCapNhat.Size = new System.Drawing.Size(55, 29);
            this.nudSoLuongCapNhat.TabIndex = 8;
            this.nudSoLuongCapNhat.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnCapNhatSoLuong
            // 
            this.btnCapNhatSoLuong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(158)))), ((int)(((byte)(11)))));
            this.btnCapNhatSoLuong.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCapNhatSoLuong.FlatAppearance.BorderSize = 0;
            this.btnCapNhatSoLuong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCapNhatSoLuong.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCapNhatSoLuong.ForeColor = System.Drawing.Color.White;
            this.btnCapNhatSoLuong.Location = new System.Drawing.Point(175, 96);
            this.btnCapNhatSoLuong.Name = "btnCapNhatSoLuong";
            this.btnCapNhatSoLuong.Size = new System.Drawing.Size(125, 31);
            this.btnCapNhatSoLuong.TabIndex = 9;
            this.btnCapNhatSoLuong.Text = "✏️ Cập nhật SL";
            this.btnCapNhatSoLuong.UseVisualStyleBackColor = false;
            // 
            // btnXoaMonKhoiHoaDon
            // 
            this.btnXoaMonKhoiHoaDon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXoaMonKhoiHoaDon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btnXoaMonKhoiHoaDon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoaMonKhoiHoaDon.FlatAppearance.BorderSize = 0;
            this.btnXoaMonKhoiHoaDon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaMonKhoiHoaDon.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaMonKhoiHoaDon.ForeColor = System.Drawing.Color.White;
            this.btnXoaMonKhoiHoaDon.Location = new System.Drawing.Point(310, 96);
            this.btnXoaMonKhoiHoaDon.Name = "btnXoaMonKhoiHoaDon";
            this.btnXoaMonKhoiHoaDon.Size = new System.Drawing.Size(120, 31);
            this.btnXoaMonKhoiHoaDon.TabIndex = 10;
            this.btnXoaMonKhoiHoaDon.Text = "🗑️ Xóa món";
            this.btnXoaMonKhoiHoaDon.UseVisualStyleBackColor = false;
            // 
            // lblTongTamTinh
            // 
            this.lblTongTamTinh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTongTamTinh.Font = new System.Drawing.Font("Segoe UI", 12.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongTamTinh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.lblTongTamTinh.Location = new System.Drawing.Point(10, 142);
            this.lblTongTamTinh.Name = "lblTongTamTinh";
            this.lblTongTamTinh.Size = new System.Drawing.Size(420, 30);
            this.lblTongTamTinh.TabIndex = 11;
            this.lblTongTamTinh.Text = "Tổng tạm tính: 0 đ";
            this.lblTongTamTinh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThanhToan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(150)))), ((int)(((byte)(105)))));
            this.btnThanhToan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThanhToan.FlatAppearance.BorderSize = 0;
            this.btnThanhToan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThanhToan.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThanhToan.ForeColor = System.Drawing.Color.White;
            this.btnThanhToan.Location = new System.Drawing.Point(10, 180);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(420, 44);
            this.btnThanhToan.TabIndex = 12;
            this.btnThanhToan.Text = "🧾 XUẤT BILL & THANH TOÁN";
            this.btnThanhToan.UseVisualStyleBackColor = false;
            // 
            // pnlThongTinBanHeader
            // 
            this.pnlThongTinBanHeader.BackColor = System.Drawing.Color.White;
            this.pnlThongTinBanHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlThongTinBanHeader.Controls.Add(this.btnGopBan);
            this.pnlThongTinBanHeader.Controls.Add(this.btnChuyenBan);
            this.pnlThongTinBanHeader.Controls.Add(this.lblHuongDan);
            this.pnlThongTinBanHeader.Controls.Add(this.lblMaHoaDonMo);
            this.pnlThongTinBanHeader.Controls.Add(this.lblGioVao);
            this.pnlThongTinBanHeader.Controls.Add(this.lblTrangThaiBan);
            this.pnlThongTinBanHeader.Controls.Add(this.lblKhuVucDangChon);
            this.pnlThongTinBanHeader.Controls.Add(this.lblTenBanDangChon);
            this.pnlThongTinBanHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlThongTinBanHeader.Location = new System.Drawing.Point(8, 8);
            this.pnlThongTinBanHeader.Name = "pnlThongTinBanHeader";
            this.pnlThongTinBanHeader.Size = new System.Drawing.Size(442, 115);
            this.pnlThongTinBanHeader.TabIndex = 0;
            // 
            // lblHuongDan
            // 
            this.lblHuongDan.AutoSize = true;
            this.lblHuongDan.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHuongDan.ForeColor = System.Drawing.Color.Gray;
            this.lblHuongDan.Location = new System.Drawing.Point(12, 85);
            this.lblHuongDan.Name = "lblHuongDan";
            this.lblHuongDan.Size = new System.Drawing.Size(235, 21);
            this.lblHuongDan.TabIndex = 5;
            this.lblHuongDan.Text = "Vui lòng chọn một bàn để bắt đầu.";
            // 
            // lblMaHoaDonMo
            // 
            this.lblMaHoaDonMo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMaHoaDonMo.AutoSize = true;
            this.lblMaHoaDonMo.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaHoaDonMo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblMaHoaDonMo.Location = new System.Drawing.Point(215, 12);
            this.lblMaHoaDonMo.Name = "lblMaHoaDonMo";
            this.lblMaHoaDonMo.Size = new System.Drawing.Size(217, 21);
            this.lblMaHoaDonMo.TabIndex = 3;
            this.lblMaHoaDonMo.Text = "Mã hóa đơn: Chưa có hóa đơn";
            // 
            // lblGioVao
            // 
            this.lblGioVao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGioVao.AutoSize = true;
            this.lblGioVao.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGioVao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblGioVao.Location = new System.Drawing.Point(215, 42);
            this.lblGioVao.Name = "lblGioVao";
            this.lblGioVao.Size = new System.Drawing.Size(99, 21);
            this.lblGioVao.TabIndex = 4;
            this.lblGioVao.Text = "Giờ vào: --";
            // 
            // lblTrangThaiBan
            // 
            this.lblTrangThaiBan.AutoSize = true;
            this.lblTrangThaiBan.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrangThaiBan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.lblTrangThaiBan.Location = new System.Drawing.Point(12, 82);
            this.lblTrangThaiBan.Name = "lblTrangThaiBan";
            this.lblTrangThaiBan.Size = new System.Drawing.Size(117, 21);
            this.lblTrangThaiBan.TabIndex = 2;
            this.lblTrangThaiBan.Text = "Trạng thái: --";
            // 
            // btnChuyenBan
            // 
            this.btnChuyenBan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChuyenBan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(158)))), ((int)(((byte)(11)))));
            this.btnChuyenBan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChuyenBan.FlatAppearance.BorderSize = 0;
            this.btnChuyenBan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChuyenBan.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChuyenBan.ForeColor = System.Drawing.Color.White;
            this.btnChuyenBan.Location = new System.Drawing.Point(215, 72);
            this.btnChuyenBan.Name = "btnChuyenBan";
            this.btnChuyenBan.Size = new System.Drawing.Size(105, 33);
            this.btnChuyenBan.TabIndex = 6;
            this.btnChuyenBan.Text = "🔄 Chuyển bàn";
            this.btnChuyenBan.UseVisualStyleBackColor = false;
            // 
            // btnGopBan
            // 
            this.btnGopBan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGopBan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(92)))), ((int)(((byte)(246)))));
            this.btnGopBan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGopBan.FlatAppearance.BorderSize = 0;
            this.btnGopBan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGopBan.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGopBan.ForeColor = System.Drawing.Color.White;
            this.btnGopBan.Location = new System.Drawing.Point(326, 72);
            this.btnGopBan.Name = "btnGopBan";
            this.btnGopBan.Size = new System.Drawing.Size(105, 33);
            this.btnGopBan.TabIndex = 7;
            this.btnGopBan.Text = "🔀 Gộp bàn";
            this.btnGopBan.UseVisualStyleBackColor = false;
            // 
            // lblKhuVucDangChon
            // 
            this.lblKhuVucDangChon.AutoSize = true;
            this.lblKhuVucDangChon.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKhuVucDangChon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblKhuVucDangChon.Location = new System.Drawing.Point(12, 45);
            this.lblKhuVucDangChon.Name = "lblKhuVucDangChon";
            this.lblKhuVucDangChon.Size = new System.Drawing.Size(95, 21);
            this.lblKhuVucDangChon.TabIndex = 1;
            this.lblKhuVucDangChon.Text = "Khu vực: --";
            // 
            // lblTenBanDangChon
            // 
            this.lblTenBanDangChon.AutoSize = true;
            this.lblTenBanDangChon.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenBanDangChon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblTenBanDangChon.Location = new System.Drawing.Point(12, 12);
            this.lblTenBanDangChon.Name = "lblTenBanDangChon";
            this.lblTenBanDangChon.Size = new System.Drawing.Size(115, 25);
            this.lblTenBanDangChon.TabIndex = 0;
            this.lblTenBanDangChon.Text = "Tên bàn: --";
            // 
            // pnlMiddle
            // 
            this.pnlMiddle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.pnlMiddle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMiddle.Controls.Add(this.flpMonAn);
            this.pnlMiddle.Controls.Add(this.flpDanhMuc);
            this.pnlMiddle.Controls.Add(this.pnlTimKiem);
            this.pnlMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMiddle.Location = new System.Drawing.Point(255, 103);
            this.pnlMiddle.Name = "pnlMiddle";
            this.pnlMiddle.Size = new System.Drawing.Size(585, 647);
            this.pnlMiddle.TabIndex = 2;
            // 
            // flpMonAn
            // 
            this.flpMonAn.AutoScroll = true;
            this.flpMonAn.BackColor = System.Drawing.Color.White;
            this.flpMonAn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpMonAn.Location = new System.Drawing.Point(0, 100);
            this.flpMonAn.Name = "flpMonAn";
            this.flpMonAn.Padding = new System.Windows.Forms.Padding(10);
            this.flpMonAn.Size = new System.Drawing.Size(583, 590);
            this.flpMonAn.TabIndex = 2;
            // 
            // flpDanhMuc
            // 
            this.flpDanhMuc.AutoScroll = true;
            this.flpDanhMuc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.flpDanhMuc.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpDanhMuc.Location = new System.Drawing.Point(0, 48);
            this.flpDanhMuc.Name = "flpDanhMuc";
            this.flpDanhMuc.Padding = new System.Windows.Forms.Padding(6);
            this.flpDanhMuc.Size = new System.Drawing.Size(583, 52);
            this.flpDanhMuc.TabIndex = 1;
            this.flpDanhMuc.WrapContents = false;
            // 
            // pnlTimKiem
            // 
            this.pnlTimKiem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.pnlTimKiem.Controls.Add(this.btnTimMon);
            this.pnlTimKiem.Controls.Add(this.txtTimMon);
            this.pnlTimKiem.Controls.Add(this.lblTimMonTitle);
            this.pnlTimKiem.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTimKiem.Location = new System.Drawing.Point(0, 0);
            this.pnlTimKiem.Name = "pnlTimKiem";
            this.pnlTimKiem.Size = new System.Drawing.Size(583, 48);
            this.pnlTimKiem.TabIndex = 0;
            // 
            // btnTimMon
            // 
            this.btnTimMon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTimMon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(158)))), ((int)(((byte)(11)))));
            this.btnTimMon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTimMon.FlatAppearance.BorderSize = 0;
            this.btnTimMon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimMon.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimMon.ForeColor = System.Drawing.Color.White;
            this.btnTimMon.Location = new System.Drawing.Point(495, 9);
            this.btnTimMon.Name = "btnTimMon";
            this.btnTimMon.Size = new System.Drawing.Size(75, 30);
            this.btnTimMon.TabIndex = 2;
            this.btnTimMon.Text = "🔍 Tìm";
            this.btnTimMon.UseVisualStyleBackColor = false;
            // 
            // txtTimMon
            // 
            this.txtTimMon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTimMon.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimMon.Location = new System.Drawing.Point(125, 10);
            this.txtTimMon.Name = "txtTimMon";
            this.txtTimMon.Size = new System.Drawing.Size(360, 29);
            this.txtTimMon.TabIndex = 1;
            // 
            // lblTimMonTitle
            // 
            this.lblTimMonTitle.AutoSize = true;
            this.lblTimMonTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimMonTitle.ForeColor = System.Drawing.Color.White;
            this.lblTimMonTitle.Location = new System.Drawing.Point(12, 12);
            this.lblTimMonTitle.Name = "lblTimMonTitle";
            this.lblTimMonTitle.Size = new System.Drawing.Size(100, 23);
            this.lblTimMonTitle.TabIndex = 0;
            this.lblTimMonTitle.Text = "DANH MỤC";
            // 
            // FrmBanHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 750);
            this.Controls.Add(this.pnlMiddle);
            this.Controls.Add(this.pnlRightContainer);
            this.Controls.Add(this.flpSoDoBan);
            this.Controls.Add(this.pnlShiftHeader);
            this.Controls.Add(this.pnlHeader);
            this.Name = "FrmBanHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bán hàng - Quản lý quán café";
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlShiftHeader.ResumeLayout(false);
            this.pnlShiftHeader.PerformLayout();
            this.pnlMiddle.ResumeLayout(false);
            this.pnlTimKiem.ResumeLayout(false);
            this.pnlTimKiem.PerformLayout();
            this.pnlRightContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietHoaDon)).EndInit();
            this.pnlThemMonAction.ResumeLayout(false);
            this.pnlThemMonAction.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuongCapNhat)).EndInit();
            this.pnlThongTinBanHeader.ResumeLayout(false);
            this.pnlThongTinBanHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lblKhuVuc;
        private System.Windows.Forms.ComboBox cboKhuVuc;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.FlowLayoutPanel flpSoDoBan;
        private System.Windows.Forms.Panel pnlMiddle;
        private System.Windows.Forms.Panel pnlTimKiem;
        private System.Windows.Forms.Label lblTimMonTitle;
        private System.Windows.Forms.TextBox txtTimMon;
        private System.Windows.Forms.Button btnTimMon;
        private System.Windows.Forms.FlowLayoutPanel flpDanhMuc;
        private System.Windows.Forms.FlowLayoutPanel flpMonAn;
        private System.Windows.Forms.Panel pnlRightContainer;
        private System.Windows.Forms.Panel pnlThongTinBanHeader;
        private System.Windows.Forms.Label lblTenBanDangChon;
        private System.Windows.Forms.Label lblKhuVucDangChon;
        private System.Windows.Forms.Label lblTrangThaiBan;
        private System.Windows.Forms.Label lblGioVao;
        private System.Windows.Forms.Label lblMaHoaDonMo;
        private System.Windows.Forms.Label lblHuongDan;
        private System.Windows.Forms.Panel pnlShiftHeader;
        private System.Windows.Forms.Label lblActiveShiftBadge;
        private System.Windows.Forms.Label lblShiftInfo;
        private System.Windows.Forms.Button btnKetCaTopBar;
        private System.Windows.Forms.Timer shiftTimer;
        private System.Windows.Forms.DataGridView dgvChiTietHoaDon;
        private System.Windows.Forms.Panel pnlThemMonAction;
        private System.Windows.Forms.Label lblMonDangChon;
        private System.Windows.Forms.Label lblSoLuongLabel;
        private System.Windows.Forms.NumericUpDown nudSoLuong;
        private System.Windows.Forms.Label lblGhiChuLabel;
        private System.Windows.Forms.TextBox txtGhiChuMon;
        private System.Windows.Forms.Button btnThemMon;
        private System.Windows.Forms.Label lblTongTamTinh;
        private System.Windows.Forms.Label lblMonTrongHoaDonDangChon;
        private System.Windows.Forms.Label lblSoLuongCapNhatLabel;
        private System.Windows.Forms.NumericUpDown nudSoLuongCapNhat;
        private System.Windows.Forms.Button btnCapNhatSoLuong;
        private System.Windows.Forms.Button btnXoaMonKhoiHoaDon;
        private System.Windows.Forms.Button btnThanhToan;
        private System.Windows.Forms.Button btnChuyenBan;
        private System.Windows.Forms.Button btnGopBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaCTHD;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenMon;
        private System.Windows.Forms.DataGridViewButtonColumn colGiamSL;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoLuong;
        private System.Windows.Forms.DataGridViewButtonColumn colTangSL;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDonGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThanhTien;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGhiChu;
        private System.Windows.Forms.DataGridViewButtonColumn colXoa;
    }
}
