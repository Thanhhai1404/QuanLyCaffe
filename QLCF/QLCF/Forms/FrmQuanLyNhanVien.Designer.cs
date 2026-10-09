namespace QLCF.Forms
{
    partial class FrmQuanLyNhanVien
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
            this.pnlHeaderTitle = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.btnLamMoiNhanVien = new System.Windows.Forms.Button();
            this.btnTimKiemNhanVien = new System.Windows.Forms.Button();
            this.cboLocTrangThai = new System.Windows.Forms.ComboBox();
            this.lblLocTrangThai = new System.Windows.Forms.Label();
            this.cboLocVaiTro = new System.Windows.Forms.ComboBox();
            this.lblLocVaiTro = new System.Windows.Forms.Label();
            this.txtTimKiemNhanVien = new System.Windows.Forms.TextBox();
            this.lblTimKiem = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.dgvNhanVien = new System.Windows.Forms.DataGridView();
            this.colMaNV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenDangNhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colChucVu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSoDienThoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTrangThaiText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNgayTao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlDetail = new System.Windows.Forms.Panel();
            this.chkHienMatKhauKhoiTao = new System.Windows.Forms.CheckBox();
            this.txtMatKhauKhoiTao = new System.Windows.Forms.TextBox();
            this.lblMatKhauKhoiTao = new System.Windows.Forms.Label();
            this.chkTrangThaiNhanVien = new System.Windows.Forms.CheckBox();
            this.cboChucVuNhanVien = new System.Windows.Forms.ComboBox();
            this.lblChucVuNhanVien = new System.Windows.Forms.Label();
            this.txtSoDienThoaiNhanVien = new System.Windows.Forms.TextBox();
            this.lblSoDienThoaiNhanVien = new System.Windows.Forms.Label();
            this.txtHoTenNhanVien = new System.Windows.Forms.TextBox();
            this.lblHoTenNhanVien = new System.Windows.Forms.Label();
            this.txtTenDangNhap = new System.Windows.Forms.TextBox();
            this.lblTenDangNhapDetail = new System.Windows.Forms.Label();
            this.txtMaNV = new System.Windows.Forms.TextBox();
            this.lblMaNV = new System.Windows.Forms.Label();
            this.lblDetailTitle = new System.Windows.Forms.Label();
            this.pnlActionButtons = new System.Windows.Forms.Panel();
            this.btnLamMoiFormNhanVien = new System.Windows.Forms.Button();
            this.btnResetMatKhau = new System.Windows.Forms.Button();
            this.btnKhoaMoTaiKhoan = new System.Windows.Forms.Button();
            this.btnSuaNhanVien = new System.Windows.Forms.Button();
            this.btnThemNhanVien = new System.Windows.Forms.Button();

            // Khởi tạo các Control cho Tab Quản lý giờ làm
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabDanhSachNhanVien = new System.Windows.Forms.TabPage();
            this.tabGioLamBaoCao = new System.Windows.Forms.TabPage();
            this.pnlFilterGioLam = new System.Windows.Forms.Panel();
            this.lblTuNgay = new System.Windows.Forms.Label();
            this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
            this.lblDenNgay = new System.Windows.Forms.Label();
            this.dtpDenNgay = new System.Windows.Forms.DateTimePicker();
            this.txtTimKiemGioLam = new System.Windows.Forms.TextBox();
            this.btnLocGioLam = new System.Windows.Forms.Button();
            this.btnXuatExcelGioLam = new System.Windows.Forms.Button();
            this.dgvGioLam = new System.Windows.Forms.DataGridView();
            this.colGioLamMaNV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGioLamTenNV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGioLamTongSoCa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGioLamTongGioLam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGioLamCaDauTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGioLamCaCuoiCung = new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.pnlHeaderTitle.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhanVien)).BeginInit();
            this.pnlDetail.SuspendLayout();
            this.pnlActionButtons.SuspendLayout();
            this.tabControlMain.SuspendLayout();
            this.tabDanhSachNhanVien.SuspendLayout();
            this.tabGioLamBaoCao.SuspendLayout();
            this.pnlFilterGioLam.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGioLam)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeaderTitle
            // 
            this.pnlHeaderTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.pnlHeaderTitle.Controls.Add(this.lblTitle);
            this.pnlHeaderTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeaderTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlHeaderTitle.Name = "pnlHeaderTitle";
            this.pnlHeaderTitle.Size = new System.Drawing.Size(1100, 48);
            this.pnlHeaderTitle.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(16, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(224, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "📋 QUẢN LÝ NHÂN VIÊN";
            // 
            // pnlFilter
            // 
            this.pnlFilter.BackColor = System.Drawing.Color.White;
            this.pnlFilter.Controls.Add(this.btnLamMoiNhanVien);
            this.pnlFilter.Controls.Add(this.btnTimKiemNhanVien);
            this.pnlFilter.Controls.Add(this.cboLocTrangThai);
            this.pnlFilter.Controls.Add(this.lblLocTrangThai);
            this.pnlFilter.Controls.Add(this.cboLocVaiTro);
            this.pnlFilter.Controls.Add(this.lblLocVaiTro);
            this.pnlFilter.Controls.Add(this.txtTimKiemNhanVien);
            this.pnlFilter.Controls.Add(this.lblTimKiem);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 48);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Padding = new System.Windows.Forms.Padding(12);
            this.pnlFilter.Size = new System.Drawing.Size(1100, 56);
            this.pnlFilter.TabIndex = 1;
            // 
            // btnLamMoiNhanVien
            // 
            this.btnLamMoiNhanVien.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.btnLamMoiNhanVien.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLamMoiNhanVien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoiNhanVien.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLamMoiNhanVien.ForeColor = System.Drawing.Color.White;
            this.btnLamMoiNhanVien.Location = new System.Drawing.Point(950, 14);
            this.btnLamMoiNhanVien.Name = "btnLamMoiNhanVien";
            this.btnLamMoiNhanVien.Size = new System.Drawing.Size(110, 28);
            this.btnLamMoiNhanVien.TabIndex = 7;
            this.btnLamMoiNhanVien.Text = "🔄 Tải lại";
            this.btnLamMoiNhanVien.UseVisualStyleBackColor = false;
            // 
            // btnTimKiemNhanVien
            // 
            this.btnTimKiemNhanVien.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(118)))), ((int)(((byte)(110)))));
            this.btnTimKiemNhanVien.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTimKiemNhanVien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiemNhanVien.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiemNhanVien.ForeColor = System.Drawing.Color.White;
            this.btnTimKiemNhanVien.Location = new System.Drawing.Point(834, 14);
            this.btnTimKiemNhanVien.Name = "btnTimKiemNhanVien";
            this.btnTimKiemNhanVien.Size = new System.Drawing.Size(110, 28);
            this.btnTimKiemNhanVien.TabIndex = 6;
            this.btnTimKiemNhanVien.Text = "🔍 Tìm kiếm";
            this.btnTimKiemNhanVien.UseVisualStyleBackColor = false;
            // 
            // cboLocTrangThai
            // 
            this.cboLocTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocTrangThai.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboLocTrangThai.FormattingEnabled = true;
            this.cboLocTrangThai.Location = new System.Drawing.Point(670, 16);
            this.cboLocTrangThai.Name = "cboLocTrangThai";
            this.cboLocTrangThai.Size = new System.Drawing.Size(145, 25);
            this.cboLocTrangThai.TabIndex = 5;
            // 
            // lblLocTrangThai
            // 
            this.lblLocTrangThai.AutoSize = true;
            this.lblLocTrangThai.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblLocTrangThai.Location = new System.Drawing.Point(595, 19);
            this.lblLocTrangThai.Name = "lblLocTrangThai";
            this.lblLocTrangThai.Size = new System.Drawing.Size(69, 17);
            this.lblLocTrangThai.TabIndex = 4;
            this.lblLocTrangThai.Text = "Trạng thái:";
            // 
            // cboLocVaiTro
            // 
            this.cboLocVaiTro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocVaiTro.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboLocVaiTro.FormattingEnabled = true;
            this.cboLocVaiTro.Location = new System.Drawing.Point(435, 16);
            this.cboLocVaiTro.Name = "cboLocVaiTro";
            this.cboLocVaiTro.Size = new System.Drawing.Size(145, 25);
            this.cboLocVaiTro.TabIndex = 3;
            // 
            // lblLocVaiTro
            // 
            this.lblLocVaiTro.AutoSize = true;
            this.lblLocVaiTro.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblLocVaiTro.Location = new System.Drawing.Point(380, 19);
            this.lblLocVaiTro.Name = "lblLocVaiTro";
            this.lblLocVaiTro.Size = new System.Drawing.Size(49, 17);
            this.lblLocVaiTro.TabIndex = 2;
            this.lblLocVaiTro.Text = "Vai trò:";
            // 
            // txtTimKiemNhanVien
            // 
            this.txtTimKiemNhanVien.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtTimKiemNhanVien.Location = new System.Drawing.Point(85, 16);
            this.txtTimKiemNhanVien.Name = "txtTimKiemNhanVien";
            this.txtTimKiemNhanVien.Size = new System.Drawing.Size(275, 25);
            this.txtTimKiemNhanVien.TabIndex = 1;
            // 
            // lblTimKiem
            // 
            this.lblTimKiem.AutoSize = true;
            this.lblTimKiem.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblTimKiem.Location = new System.Drawing.Point(16, 19);
            this.lblTimKiem.Name = "lblTimKiem";
            this.lblTimKiem.Size = new System.Drawing.Size(63, 17);
            this.lblTimKiem.TabIndex = 0;
            this.lblTimKiem.Text = "Tìm kiếm:";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.pnlGrid);
            this.pnlMain.Controls.Add(this.pnlDetail);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 104);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1100, 546);
            this.pnlMain.TabIndex = 2;
            // 
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.dgvNhanVien);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(0, 0);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Padding = new System.Windows.Forms.Padding(12);
            this.pnlGrid.Size = new System.Drawing.Size(730, 546);
            this.pnlGrid.TabIndex = 0;
            // 
            // dgvNhanVien
            // 
            this.dgvNhanVien.AllowUserToAddRows = false;
            this.dgvNhanVien.AllowUserToDeleteRows = false;
            this.dgvNhanVien.AllowUserToResizeRows = false;
            this.dgvNhanVien.BackgroundColor = System.Drawing.Color.White;
            this.dgvNhanVien.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvNhanVien.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvNhanVien.ColumnHeadersHeight = 32;
            this.dgvNhanVien.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaNV,
            this.colTenDangNhap,
            this.colHoTen,
            this.colChucVu,
            this.colSoDienThoai,
            this.colTrangThaiText,
            this.colNgayTao});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(242)))), ((int)(((byte)(254)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvNhanVien.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvNhanVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvNhanVien.EnableHeadersVisualStyles = false;
            this.dgvNhanVien.Location = new System.Drawing.Point(12, 12);
            this.dgvNhanVien.MultiSelect = false;
            this.dgvNhanVien.Name = "dgvNhanVien";
            this.dgvNhanVien.ReadOnly = true;
            this.dgvNhanVien.RowHeadersVisible = false;
            this.dgvNhanVien.RowTemplate.Height = 28;
            this.dgvNhanVien.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNhanVien.Size = new System.Drawing.Size(706, 522);
            this.dgvNhanVien.TabIndex = 0;
            // 
            // colMaNV
            // 
            this.colMaNV.DataPropertyName = "MaNV";
            this.colMaNV.HeaderText = "Mã NV";
            this.colMaNV.Name = "colMaNV";
            this.colMaNV.ReadOnly = true;
            this.colMaNV.Width = 65;
            // 
            // colTenDangNhap
            // 
            this.colTenDangNhap.DataPropertyName = "TenDangNhap";
            this.colTenDangNhap.HeaderText = "Tên đăng nhập";
            this.colTenDangNhap.Name = "colTenDangNhap";
            this.colTenDangNhap.ReadOnly = true;
            this.colTenDangNhap.Width = 120;
            // 
            // colHoTen
            // 
            this.colHoTen.DataPropertyName = "HoTen";
            this.colHoTen.HeaderText = "Họ và tên";
            this.colHoTen.Name = "colHoTen";
            this.colHoTen.ReadOnly = true;
            this.colHoTen.Width = 145;
            // 
            // colChucVu
            // 
            this.colChucVu.DataPropertyName = "ChucVu";
            this.colChucVu.HeaderText = "Chức vụ";
            this.colChucVu.Name = "colChucVu";
            this.colChucVu.ReadOnly = true;
            this.colChucVu.Width = 85;
            // 
            // colSoDienThoai
            // 
            this.colSoDienThoai.DataPropertyName = "SoDienThoai";
            this.colSoDienThoai.HeaderText = "Số điện thoại";
            this.colSoDienThoai.Name = "colSoDienThoai";
            this.colSoDienThoai.ReadOnly = true;
            this.colSoDienThoai.Width = 100;
            // 
            // colTrangThaiText
            // 
            this.colTrangThaiText.DataPropertyName = "TrangThaiText";
            this.colTrangThaiText.HeaderText = "Trạng thái";
            this.colTrangThaiText.Name = "colTrangThaiText";
            this.colTrangThaiText.ReadOnly = true;
            this.colTrangThaiText.Width = 90;
            // 
            // colNgayTao
            // 
            this.colNgayTao.DataPropertyName = "NgayTaoText";
            this.colNgayTao.HeaderText = "Ngày tạo";
            this.colNgayTao.Name = "colNgayTao";
            this.colNgayTao.ReadOnly = true;
            this.colNgayTao.Width = 110;
            // 
            // pnlDetail
            // 
            this.pnlDetail.BackColor = System.Drawing.Color.White;
            this.pnlDetail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDetail.Controls.Add(this.pnlActionButtons);
            this.pnlDetail.Controls.Add(this.chkHienMatKhauKhoiTao);
            this.pnlDetail.Controls.Add(this.txtMatKhauKhoiTao);
            this.pnlDetail.Controls.Add(this.lblMatKhauKhoiTao);
            this.pnlDetail.Controls.Add(this.chkTrangThaiNhanVien);
            this.pnlDetail.Controls.Add(this.cboChucVuNhanVien);
            this.pnlDetail.Controls.Add(this.lblChucVuNhanVien);
            this.pnlDetail.Controls.Add(this.txtSoDienThoaiNhanVien);
            this.pnlDetail.Controls.Add(this.lblSoDienThoaiNhanVien);
            this.pnlDetail.Controls.Add(this.txtHoTenNhanVien);
            this.pnlDetail.Controls.Add(this.lblHoTenNhanVien);
            this.pnlDetail.Controls.Add(this.txtTenDangNhap);
            this.pnlDetail.Controls.Add(this.lblTenDangNhapDetail);
            this.pnlDetail.Controls.Add(this.txtMaNV);
            this.pnlDetail.Controls.Add(this.lblMaNV);
            this.pnlDetail.Controls.Add(this.lblDetailTitle);
            this.pnlDetail.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlDetail.Location = new System.Drawing.Point(730, 0);
            this.pnlDetail.Name = "pnlDetail";
            this.pnlDetail.Padding = new System.Windows.Forms.Padding(16);
            this.pnlDetail.Size = new System.Drawing.Size(370, 546);
            this.pnlDetail.TabIndex = 1;
            // 
            // chkHienMatKhauKhoiTao
            // 
            this.chkHienMatKhauKhoiTao.AutoSize = true;
            this.chkHienMatKhauKhoiTao.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.chkHienMatKhauKhoiTao.Location = new System.Drawing.Point(232, 345);
            this.chkHienMatKhauKhoiTao.Name = "chkHienMatKhauKhoiTao";
            this.chkHienMatKhauKhoiTao.Size = new System.Drawing.Size(107, 19);
            this.chkHienMatKhauKhoiTao.TabIndex = 13;
            this.chkHienMatKhauKhoiTao.Text = "Hiện mật khẩu";
            this.chkHienMatKhauKhoiTao.UseVisualStyleBackColor = true;
            // 
            // txtMatKhauKhoiTao
            // 
            this.txtMatKhauKhoiTao.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtMatKhauKhoiTao.Location = new System.Drawing.Point(19, 342);
            this.txtMatKhauKhoiTao.Name = "txtMatKhauKhoiTao";
            this.txtMatKhauKhoiTao.Size = new System.Drawing.Size(200, 25);
            this.txtMatKhauKhoiTao.TabIndex = 12;
            this.txtMatKhauKhoiTao.UseSystemPasswordChar = true;
            // 
            // lblMatKhauKhoiTao
            // 
            this.lblMatKhauKhoiTao.AutoSize = true;
            this.lblMatKhauKhoiTao.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMatKhauKhoiTao.Location = new System.Drawing.Point(16, 322);
            this.lblMatKhauKhoiTao.Name = "lblMatKhauKhoiTao";
            this.lblMatKhauKhoiTao.Size = new System.Drawing.Size(120, 17);
            this.lblMatKhauKhoiTao.TabIndex = 11;
            this.lblMatKhauKhoiTao.Text = "Mật khẩu khởi tạo:";
            // 
            // chkTrangThaiNhanVien
            // 
            this.chkTrangThaiNhanVien.AutoSize = true;
            this.chkTrangThaiNhanVien.Checked = true;
            this.chkTrangThaiNhanVien.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTrangThaiNhanVien.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.chkTrangThaiNhanVien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(118)))), ((int)(((byte)(110)))));
            this.chkTrangThaiNhanVien.Location = new System.Drawing.Point(19, 292);
            this.chkTrangThaiNhanVien.Name = "chkTrangThaiNhanVien";
            this.chkTrangThaiNhanVien.Size = new System.Drawing.Size(193, 21);
            this.chkTrangThaiNhanVien.TabIndex = 10;
            this.chkTrangThaiNhanVien.Text = "Tài khoản đang hoạt động";
            this.chkTrangThaiNhanVien.UseVisualStyleBackColor = true;
            // 
            // cboChucVuNhanVien
            // 
            this.cboChucVuNhanVien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboChucVuNhanVien.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboChucVuNhanVien.FormattingEnabled = true;
            this.cboChucVuNhanVien.Location = new System.Drawing.Point(19, 254);
            this.cboChucVuNhanVien.Name = "cboChucVuNhanVien";
            this.cboChucVuNhanVien.Size = new System.Drawing.Size(330, 25);
            this.cboChucVuNhanVien.TabIndex = 9;
            // 
            // lblChucVuNhanVien
            // 
            this.lblChucVuNhanVien.AutoSize = true;
            this.lblChucVuNhanVien.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChucVuNhanVien.Location = new System.Drawing.Point(16, 234);
            this.lblChucVuNhanVien.Name = "lblChucVuNhanVien";
            this.lblChucVuNhanVien.Size = new System.Drawing.Size(58, 17);
            this.lblChucVuNhanVien.TabIndex = 8;
            this.lblChucVuNhanVien.Text = "Chức vụ:";
            // 
            // txtSoDienThoaiNhanVien
            // 
            this.txtSoDienThoaiNhanVien.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtSoDienThoaiNhanVien.Location = new System.Drawing.Point(19, 201);
            this.txtSoDienThoaiNhanVien.Name = "txtSoDienThoaiNhanVien";
            this.txtSoDienThoaiNhanVien.Size = new System.Drawing.Size(330, 25);
            this.txtSoDienThoaiNhanVien.TabIndex = 7;
            // 
            // lblSoDienThoaiNhanVien
            // 
            this.lblSoDienThoaiNhanVien.AutoSize = true;
            this.lblSoDienThoaiNhanVien.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoDienThoaiNhanVien.Location = new System.Drawing.Point(16, 181);
            this.lblSoDienThoaiNhanVien.Name = "lblSoDienThoaiNhanVien";
            this.lblSoDienThoaiNhanVien.Size = new System.Drawing.Size(88, 17);
            this.lblSoDienThoaiNhanVien.TabIndex = 6;
            this.lblSoDienThoaiNhanVien.Text = "Số điện thoại:";
            // 
            // txtHoTenNhanVien
            // 
            this.txtHoTenNhanVien.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtHoTenNhanVien.Location = new System.Drawing.Point(19, 148);
            this.txtHoTenNhanVien.Name = "txtHoTenNhanVien";
            this.txtHoTenNhanVien.Size = new System.Drawing.Size(330, 25);
            this.txtHoTenNhanVien.TabIndex = 5;
            // 
            // lblHoTenNhanVien
            // 
            this.lblHoTenNhanVien.AutoSize = true;
            this.lblHoTenNhanVien.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHoTenNhanVien.Location = new System.Drawing.Point(16, 128);
            this.lblHoTenNhanVien.Name = "lblHoTenNhanVien";
            this.lblHoTenNhanVien.Size = new System.Drawing.Size(66, 17);
            this.lblHoTenNhanVien.TabIndex = 4;
            this.lblHoTenNhanVien.Text = "Họ và tên:";
            // 
            // txtTenDangNhap
            // 
            this.txtTenDangNhap.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtTenDangNhap.Location = new System.Drawing.Point(19, 95);
            this.txtTenDangNhap.Name = "txtTenDangNhap";
            this.txtTenDangNhap.Size = new System.Drawing.Size(330, 25);
            this.txtTenDangNhap.TabIndex = 3;
            // 
            // lblTenDangNhapDetail
            // 
            this.lblTenDangNhapDetail.AutoSize = true;
            this.lblTenDangNhapDetail.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenDangNhapDetail.Location = new System.Drawing.Point(16, 75);
            this.lblTenDangNhapDetail.Name = "lblTenDangNhapDetail";
            this.lblTenDangNhapDetail.Size = new System.Drawing.Size(98, 17);
            this.lblTenDangNhapDetail.TabIndex = 2;
            this.lblTenDangNhapDetail.Text = "Tên đăng nhập:";
            // 
            // txtMaNV
            // 
            this.txtMaNV.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtMaNV.Location = new System.Drawing.Point(80, 42);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.ReadOnly = true;
            this.txtMaNV.Size = new System.Drawing.Size(100, 25);
            this.txtMaNV.TabIndex = 1;
            // 
            // lblMaNV
            // 
            this.lblMaNV.AutoSize = true;
            this.lblMaNV.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaNV.Location = new System.Drawing.Point(16, 45);
            this.lblMaNV.Name = "lblMaNV";
            this.lblMaNV.Size = new System.Drawing.Size(51, 17);
            this.lblMaNV.TabIndex = 0;
            this.lblMaNV.Text = "Mã NV:";
            // 
            // lblDetailTitle
            // 
            this.lblDetailTitle.AutoSize = true;
            this.lblDetailTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblDetailTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblDetailTitle.Location = new System.Drawing.Point(15, 12);
            this.lblDetailTitle.Name = "lblDetailTitle";
            this.lblDetailTitle.Size = new System.Drawing.Size(183, 20);
            this.lblDetailTitle.TabIndex = 0;
            this.lblDetailTitle.Text = "THÔNG TIN NHÂN VIÊN";
            // 
            // pnlActionButtons
            // 
            this.pnlActionButtons.Controls.Add(this.btnLamMoiFormNhanVien);
            this.pnlActionButtons.Controls.Add(this.btnResetMatKhau);
            this.pnlActionButtons.Controls.Add(this.btnKhoaMoTaiKhoan);
            this.pnlActionButtons.Controls.Add(this.btnSuaNhanVien);
            this.pnlActionButtons.Controls.Add(this.btnThemNhanVien);
            this.pnlActionButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlActionButtons.Location = new System.Drawing.Point(16, 380);
            this.pnlActionButtons.Name = "pnlActionButtons";
            this.pnlActionButtons.Size = new System.Drawing.Size(336, 148);
            this.pnlActionButtons.TabIndex = 14;
            // 
            // btnLamMoiFormNhanVien
            // 
            this.btnLamMoiFormNhanVien.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.btnLamMoiFormNhanVien.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLamMoiFormNhanVien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoiFormNhanVien.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLamMoiFormNhanVien.ForeColor = System.Drawing.Color.White;
            this.btnLamMoiFormNhanVien.Location = new System.Drawing.Point(172, 98);
            this.btnLamMoiFormNhanVien.Name = "btnLamMoiFormNhanVien";
            this.btnLamMoiFormNhanVien.Size = new System.Drawing.Size(161, 36);
            this.btnLamMoiFormNhanVien.TabIndex = 4;
            this.btnLamMoiFormNhanVien.Text = "✨ Làm mới Form";
            this.btnLamMoiFormNhanVien.UseVisualStyleBackColor = false;
            // 
            // btnResetMatKhau
            // 
            this.btnResetMatKhau.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(119)))), ((int)(((byte)(6)))));
            this.btnResetMatKhau.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnResetMatKhau.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetMatKhau.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetMatKhau.ForeColor = System.Drawing.Color.White;
            this.btnResetMatKhau.Location = new System.Drawing.Point(3, 98);
            this.btnResetMatKhau.Name = "btnResetMatKhau";
            this.btnResetMatKhau.Size = new System.Drawing.Size(161, 36);
            this.btnResetMatKhau.TabIndex = 3;
            this.btnResetMatKhau.Text = "🔑 Reset mật khẩu";
            this.btnResetMatKhau.UseVisualStyleBackColor = false;
            // 
            // btnKhoaMoTaiKhoan
            // 
            this.btnKhoaMoTaiKhoan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(29)))), ((int)(((byte)(72)))));
            this.btnKhoaMoTaiKhoan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKhoaMoTaiKhoan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKhoaMoTaiKhoan.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKhoaMoTaiKhoan.ForeColor = System.Drawing.Color.White;
            this.btnKhoaMoTaiKhoan.Location = new System.Drawing.Point(3, 52);
            this.btnKhoaMoTaiKhoan.Name = "btnKhoaMoTaiKhoan";
            this.btnKhoaMoTaiKhoan.Size = new System.Drawing.Size(330, 36);
            this.btnKhoaMoTaiKhoan.TabIndex = 2;
            this.btnKhoaMoTaiKhoan.Text = "🔒 Khóa tài khoản";
            this.btnKhoaMoTaiKhoan.UseVisualStyleBackColor = false;
            // 
            // btnSuaNhanVien
            // 
            this.btnSuaNhanVien.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnSuaNhanVien.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSuaNhanVien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuaNhanVien.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSuaNhanVien.ForeColor = System.Drawing.Color.White;
            this.btnSuaNhanVien.Location = new System.Drawing.Point(3, 6);
            this.btnSuaNhanVien.Name = "btnSuaNhanVien";
            this.btnSuaNhanVien.Size = new System.Drawing.Size(330, 36);
            this.btnSuaNhanVien.TabIndex = 1;
            this.btnSuaNhanVien.Text = "💾 Lưu thông tin sửa";
            this.btnSuaNhanVien.UseVisualStyleBackColor = false;
            // 
            // btnThemNhanVien
            // 
            this.btnThemNhanVien.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(118)))), ((int)(((byte)(110)))));
            this.btnThemNhanVien.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThemNhanVien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemNhanVien.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemNhanVien.ForeColor = System.Drawing.Color.White;
            this.btnThemNhanVien.Location = new System.Drawing.Point(3, 6);
            this.btnThemNhanVien.Name = "btnThemNhanVien";
            this.btnThemNhanVien.Size = new System.Drawing.Size(330, 36);
            this.btnThemNhanVien.TabIndex = 0;
            this.btnThemNhanVien.Text = "➕ Thêm nhân viên mới";
            this.btnThemNhanVien.UseVisualStyleBackColor = false;
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabDanhSachNhanVien);
            this.tabControlMain.Controls.Add(this.tabGioLamBaoCao);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tabControlMain.Location = new System.Drawing.Point(0, 48);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(1100, 602);
            this.tabControlMain.TabIndex = 1;
            // 
            // tabDanhSachNhanVien
            // 
            this.tabDanhSachNhanVien.Controls.Add(this.pnlMain);
            this.tabDanhSachNhanVien.Controls.Add(this.pnlFilter);
            this.tabDanhSachNhanVien.Location = new System.Drawing.Point(4, 26);
            this.tabDanhSachNhanVien.Name = "tabDanhSachNhanVien";
            this.tabDanhSachNhanVien.Padding = new System.Windows.Forms.Padding(3);
            this.tabDanhSachNhanVien.Size = new System.Drawing.Size(1092, 572);
            this.tabDanhSachNhanVien.TabIndex = 0;
            this.tabDanhSachNhanVien.Text = "👥 Danh sách Nhân viên";
            this.tabDanhSachNhanVien.UseVisualStyleBackColor = true;
            // 
            // tabGioLamBaoCao
            // 
            this.tabGioLamBaoCao.Controls.Add(this.dgvGioLam);
            this.tabGioLamBaoCao.Controls.Add(this.pnlFilterGioLam);
            this.tabGioLamBaoCao.Location = new System.Drawing.Point(4, 26);
            this.tabGioLamBaoCao.Name = "tabGioLamBaoCao";
            this.tabGioLamBaoCao.Padding = new System.Windows.Forms.Padding(12);
            this.tabGioLamBaoCao.Size = new System.Drawing.Size(1092, 572);
            this.tabGioLamBaoCao.TabIndex = 1;
            this.tabGioLamBaoCao.Text = "📊 Quản lý Giờ làm & Báo cáo Lương";
            this.tabGioLamBaoCao.UseVisualStyleBackColor = true;
            // 
            // pnlFilterGioLam
            // 
            this.pnlFilterGioLam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.pnlFilterGioLam.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFilterGioLam.Controls.Add(this.lblTuNgay);
            this.pnlFilterGioLam.Controls.Add(this.dtpTuNgay);
            this.pnlFilterGioLam.Controls.Add(this.lblDenNgay);
            this.pnlFilterGioLam.Controls.Add(this.dtpDenNgay);
            this.pnlFilterGioLam.Controls.Add(this.txtTimKiemGioLam);
            this.pnlFilterGioLam.Controls.Add(this.btnLocGioLam);
            this.pnlFilterGioLam.Controls.Add(this.btnXuatExcelGioLam);
            this.pnlFilterGioLam.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilterGioLam.Location = new System.Drawing.Point(12, 12);
            this.pnlFilterGioLam.Name = "pnlFilterGioLam";
            this.pnlFilterGioLam.Size = new System.Drawing.Size(1068, 56);
            this.pnlFilterGioLam.TabIndex = 0;
            // 
            // lblTuNgay
            // 
            this.lblTuNgay.AutoSize = true;
            this.lblTuNgay.Location = new System.Drawing.Point(15, 18);
            this.lblTuNgay.Name = "lblTuNgay";
            this.lblTuNgay.Size = new System.Drawing.Size(58, 17);
            this.lblTuNgay.TabIndex = 0;
            this.lblTuNgay.Text = "Từ ngày:";
            // 
            // dtpTuNgay
            // 
            this.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTuNgay.Location = new System.Drawing.Point(75, 15);
            this.dtpTuNgay.Name = "dtpTuNgay";
            this.dtpTuNgay.Size = new System.Drawing.Size(110, 24);
            this.dtpTuNgay.TabIndex = 1;
            // 
            // lblDenNgay
            // 
            this.lblDenNgay.AutoSize = true;
            this.lblDenNgay.Location = new System.Drawing.Point(195, 18);
            this.lblDenNgay.Name = "lblDenNgay";
            this.lblDenNgay.Size = new System.Drawing.Size(65, 17);
            this.lblDenNgay.TabIndex = 2;
            this.lblDenNgay.Text = "Đến ngày:";
            // 
            // dtpDenNgay
            // 
            this.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDenNgay.Location = new System.Drawing.Point(265, 15);
            this.dtpDenNgay.Name = "dtpDenNgay";
            this.dtpDenNgay.Size = new System.Drawing.Size(110, 24);
            this.dtpDenNgay.TabIndex = 3;
            // 
            // txtTimKiemGioLam
            // 
            this.txtTimKiemGioLam.Location = new System.Drawing.Point(395, 15);
            this.txtTimKiemGioLam.Name = "txtTimKiemGioLam";
            this.txtTimKiemGioLam.Size = new System.Drawing.Size(200, 24);
            this.txtTimKiemGioLam.TabIndex = 4;
            // 
            // btnLocGioLam
            // 
            this.btnLocGioLam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(165)))), ((int)(((byte)(233)))));
            this.btnLocGioLam.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLocGioLam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLocGioLam.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnLocGioLam.ForeColor = System.Drawing.Color.White;
            this.btnLocGioLam.Location = new System.Drawing.Point(610, 13);
            this.btnLocGioLam.Name = "btnLocGioLam";
            this.btnLocGioLam.Size = new System.Drawing.Size(100, 28);
            this.btnLocGioLam.TabIndex = 5;
            this.btnLocGioLam.Text = "🔍 Lọc dữ liệu";
            this.btnLocGioLam.UseVisualStyleBackColor = false;
            // 
            // btnXuatExcelGioLam
            // 
            this.btnXuatExcelGioLam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.btnXuatExcelGioLam.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXuatExcelGioLam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXuatExcelGioLam.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnXuatExcelGioLam.ForeColor = System.Drawing.Color.White;
            this.btnXuatExcelGioLam.Location = new System.Drawing.Point(725, 13);
            this.btnXuatExcelGioLam.Name = "btnXuatExcelGioLam";
            this.btnXuatExcelGioLam.Size = new System.Drawing.Size(220, 28);
            this.btnXuatExcelGioLam.TabIndex = 6;
            this.btnXuatExcelGioLam.Text = "📊 Xuất Excel Báo Cáo Lương";
            this.btnXuatExcelGioLam.UseVisualStyleBackColor = false;
            // 
            // dgvGioLam
            // 
            this.dgvGioLam.AllowUserToAddRows = false;
            this.dgvGioLam.AllowUserToDeleteRows = false;
            this.dgvGioLam.BackgroundColor = System.Drawing.Color.White;
            this.dgvGioLam.ColumnHeadersHeight = 35;
            this.dgvGioLam.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colGioLamMaNV,
            this.colGioLamTenNV,
            this.colGioLamTongSoCa,
            this.colGioLamTongGioLam,
            this.colGioLamCaDauTien,
            this.colGioLamCaCuoiCung});
            this.dgvGioLam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGioLam.EnableHeadersVisualStyles = false;
            this.dgvGioLam.Location = new System.Drawing.Point(12, 68);
            this.dgvGioLam.Name = "dgvGioLam";
            this.dgvGioLam.ReadOnly = true;
            this.dgvGioLam.RowHeadersVisible = false;
            this.dgvGioLam.RowTemplate.Height = 30;
            this.dgvGioLam.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGioLam.Size = new System.Drawing.Size(1068, 492);
            this.dgvGioLam.TabIndex = 1;
            this.dgvGioLam.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            // 
            // colGioLamMaNV
            // 
            this.colGioLamMaNV.DataPropertyName = "MaNhanVien";
            this.colGioLamMaNV.HeaderText = "Mã NV";
            this.colGioLamMaNV.Name = "colGioLamMaNV";
            this.colGioLamMaNV.ReadOnly = true;
            this.colGioLamMaNV.Width = 80;
            // 
            // colGioLamTenNV
            // 
            this.colGioLamTenNV.DataPropertyName = "TenNhanVien";
            this.colGioLamTenNV.HeaderText = "Tên Nhân Viên";
            this.colGioLamTenNV.Name = "colGioLamTenNV";
            this.colGioLamTenNV.ReadOnly = true;
            this.colGioLamTenNV.Width = 200;
            // 
            // colGioLamTongSoCa
            // 
            this.colGioLamTongSoCa.DataPropertyName = "TongSoCa";
            this.colGioLamTongSoCa.HeaderText = "Tổng Số Ca";
            this.colGioLamTongSoCa.Name = "colGioLamTongSoCa";
            this.colGioLamTongSoCa.ReadOnly = true;
            this.colGioLamTongSoCa.Width = 120;
            this.colGioLamTongSoCa.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            // 
            // colGioLamTongGioLam
            // 
            this.colGioLamTongGioLam.DataPropertyName = "TongGioLam";
            this.colGioLamTongGioLam.HeaderText = "Tổng Giờ Làm";
            this.colGioLamTongGioLam.Name = "colGioLamTongGioLam";
            this.colGioLamTongGioLam.ReadOnly = true;
            this.colGioLamTongGioLam.Width = 140;
            this.colGioLamTongGioLam.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colGioLamTongGioLam.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(132)))), ((int)(((byte)(199)))));
            this.colGioLamTongGioLam.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.colGioLamTongGioLam.DefaultCellStyle.Format = "N2";
            // 
            // colGioLamCaDauTien
            // 
            this.colGioLamCaDauTien.DataPropertyName = "CaDauTien";
            this.colGioLamCaDauTien.HeaderText = "Ca Đầu Tiên";
            this.colGioLamCaDauTien.Name = "colGioLamCaDauTien";
            this.colGioLamCaDauTien.ReadOnly = true;
            this.colGioLamCaDauTien.Width = 180;
            this.colGioLamCaDauTien.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            // 
            // colGioLamCaCuoiCung
            // 
            this.colGioLamCaCuoiCung.DataPropertyName = "CaCuoiCung";
            this.colGioLamCaCuoiCung.HeaderText = "Ca Cuối Cùng";
            this.colGioLamCaCuoiCung.Name = "colGioLamCaCuoiCung";
            this.colGioLamCaCuoiCung.ReadOnly = true;
            this.colGioLamCaCuoiCung.Width = 180;
            this.colGioLamCaCuoiCung.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            // 
            // FrmQuanLyNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(1100, 650);
            this.Controls.Add(this.tabControlMain);
            this.Controls.Add(this.pnlHeaderTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmQuanLyNhanVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Quản Lý Nhân Viên";
            this.pnlHeaderTitle.ResumeLayout(false);
            this.pnlHeaderTitle.PerformLayout();
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhanVien)).EndInit();
            this.pnlDetail.ResumeLayout(false);
            this.pnlDetail.PerformLayout();
            this.pnlActionButtons.ResumeLayout(false);
            this.tabControlMain.ResumeLayout(false);
            this.tabDanhSachNhanVien.ResumeLayout(false);
            this.tabGioLamBaoCao.ResumeLayout(false);
            this.pnlFilterGioLam.ResumeLayout(false);
            this.pnlFilterGioLam.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGioLam)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeaderTitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.Label lblTimKiem;
        private System.Windows.Forms.TextBox txtTimKiemNhanVien;
        private System.Windows.Forms.Label lblLocVaiTro;
        private System.Windows.Forms.ComboBox cboLocVaiTro;
        private System.Windows.Forms.Label lblLocTrangThai;
        private System.Windows.Forms.ComboBox cboLocTrangThai;
        private System.Windows.Forms.Button btnTimKiemNhanVien;
        private System.Windows.Forms.Button btnLamMoiNhanVien;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.DataGridView dgvNhanVien;
        private System.Windows.Forms.Panel pnlDetail;
        private System.Windows.Forms.Label lblDetailTitle;
        private System.Windows.Forms.Label lblMaNV;
        private System.Windows.Forms.TextBox txtMaNV;
        private System.Windows.Forms.Label lblTenDangNhapDetail;
        private System.Windows.Forms.TextBox txtTenDangNhap;
        private System.Windows.Forms.Label lblHoTenNhanVien;
        private System.Windows.Forms.TextBox txtHoTenNhanVien;
        private System.Windows.Forms.Label lblSoDienThoaiNhanVien;
        private System.Windows.Forms.TextBox txtSoDienThoaiNhanVien;
        private System.Windows.Forms.Label lblChucVuNhanVien;
        private System.Windows.Forms.ComboBox cboChucVuNhanVien;
        private System.Windows.Forms.CheckBox chkTrangThaiNhanVien;
        private System.Windows.Forms.Label lblMatKhauKhoiTao;
        private System.Windows.Forms.TextBox txtMatKhauKhoiTao;
        private System.Windows.Forms.CheckBox chkHienMatKhauKhoiTao;
        private System.Windows.Forms.Panel pnlActionButtons;
        private System.Windows.Forms.Button btnThemNhanVien;
        private System.Windows.Forms.Button btnSuaNhanVien;
        private System.Windows.Forms.Button btnKhoaMoTaiKhoan;
        private System.Windows.Forms.Button btnResetMatKhau;
        private System.Windows.Forms.Button btnLamMoiFormNhanVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaNV;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenDangNhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChucVu;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoDienThoai;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTrangThaiText;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNgayTao;

        // Bổ sung TabControl và chức năng Quản lý giờ làm
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabDanhSachNhanVien;
        private System.Windows.Forms.TabPage tabGioLamBaoCao;
        private System.Windows.Forms.Panel pnlFilterGioLam;
        private System.Windows.Forms.DateTimePicker dtpTuNgay;
        private System.Windows.Forms.Label lblTuNgay;
        private System.Windows.Forms.DateTimePicker dtpDenNgay;
        private System.Windows.Forms.Label lblDenNgay;
        private System.Windows.Forms.TextBox txtTimKiemGioLam;
        private System.Windows.Forms.Button btnLocGioLam;
        private System.Windows.Forms.Button btnXuatExcelGioLam;
        private System.Windows.Forms.DataGridView dgvGioLam;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGioLamMaNV;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGioLamTenNV;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGioLamTongSoCa;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGioLamTongGioLam;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGioLamCaDauTien;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGioLamCaCuoiCung;
    }
}
