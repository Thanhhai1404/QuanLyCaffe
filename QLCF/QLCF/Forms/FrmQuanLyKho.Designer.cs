namespace QLCF.Forms
{
    partial class FrmQuanLyKho
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.btnDong = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabPageNVL = new System.Windows.Forms.TabPage();
            this.pnlListNVL = new System.Windows.Forms.Panel();
            this.dgvNguyenVatLieu = new System.Windows.Forms.DataGridView();
            this.colMaNVL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenNVL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDVT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSoLuongTon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMucCanhBao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTrangThaiNVLText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlEditNVL = new System.Windows.Forms.Panel();
            this.btnNhapKho = new System.Windows.Forms.Button();
            this.chkTrangThaiNVL = new System.Windows.Forms.CheckBox();
            this.lblTrangThaiNVL = new System.Windows.Forms.Label();
            this.btnLamMoiNVL = new System.Windows.Forms.Button();
            this.btnLuuNVL = new System.Windows.Forms.Button();
            this.btnSuaNVL = new System.Windows.Forms.Button();
            this.btnThemNVL = new System.Windows.Forms.Button();
            this.txtMucCanhBao = new System.Windows.Forms.TextBox();
            this.lblMucCanhBao = new System.Windows.Forms.Label();
            this.txtDVT = new System.Windows.Forms.TextBox();
            this.lblDVT = new System.Windows.Forms.Label();
            this.txtTenNVL = new System.Windows.Forms.TextBox();
            this.lblTenNVL = new System.Windows.Forms.Label();
            this.txtMaNVL = new System.Windows.Forms.TextBox();
            this.lblMaNVL = new System.Windows.Forms.Label();
            this.tabPagePhieuNhap = new System.Windows.Forms.TabPage();
            this.dgvPhieuNhap = new System.Windows.Forms.DataGridView();
            this.colMaPN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNgayNhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaNV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTongTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGhiChu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlHeader.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabPageNVL.SuspendLayout();
            this.pnlListNVL.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNguyenVatLieu)).BeginInit();
            this.pnlEditNVL.SuspendLayout();
            this.tabPagePhieuNhap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuNhap)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.pnlHeader.Controls.Add(this.btnDong);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1000, 50);
            this.pnlHeader.TabIndex = 0;
            // 
            // btnDong
            // 
            this.btnDong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDong.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDong.FlatAppearance.BorderSize = 0;
            this.btnDong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDong.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDong.ForeColor = System.Drawing.Color.White;
            this.btnDong.Location = new System.Drawing.Point(950, 0);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(50, 50);
            this.btnDong.TabIndex = 1;
            this.btnDong.Text = "X";
            this.btnDong.UseVisualStyleBackColor = true;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 13);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(262, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "QUẢN LÝ KHO (INVENTORY)";
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabPageNVL);
            this.tabMain.Controls.Add(this.tabPagePhieuNhap);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tabMain.Location = new System.Drawing.Point(0, 50);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(1000, 650);
            this.tabMain.TabIndex = 1;
            // 
            // tabPageNVL
            // 
            this.tabPageNVL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.tabPageNVL.Controls.Add(this.pnlListNVL);
            this.tabPageNVL.Controls.Add(this.pnlEditNVL);
            this.tabPageNVL.Location = new System.Drawing.Point(4, 26);
            this.tabPageNVL.Name = "tabPageNVL";
            this.tabPageNVL.Padding = new System.Windows.Forms.Padding(15);
            this.tabPageNVL.Size = new System.Drawing.Size(992, 620);
            this.tabPageNVL.TabIndex = 0;
            this.tabPageNVL.Text = "Nguyên Vật Liệu";
            // 
            // pnlListNVL
            // 
            this.pnlListNVL.BackColor = System.Drawing.Color.White;
            this.pnlListNVL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlListNVL.Controls.Add(this.dgvNguyenVatLieu);
            this.pnlListNVL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlListNVL.Location = new System.Drawing.Point(15, 15);
            this.pnlListNVL.Name = "pnlListNVL";
            this.pnlListNVL.Padding = new System.Windows.Forms.Padding(1);
            this.pnlListNVL.Size = new System.Drawing.Size(562, 590);
            this.pnlListNVL.TabIndex = 1;
            // 
            // dgvNguyenVatLieu
            // 
            this.dgvNguyenVatLieu.AllowUserToAddRows = false;
            this.dgvNguyenVatLieu.AllowUserToDeleteRows = false;
            this.dgvNguyenVatLieu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNguyenVatLieu.BackgroundColor = System.Drawing.Color.White;
            this.dgvNguyenVatLieu.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvNguyenVatLieu.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvNguyenVatLieu.ColumnHeadersHeight = 35;
            this.dgvNguyenVatLieu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaNVL,
            this.colTenNVL,
            this.colDVT,
            this.colSoLuongTon,
            this.colMucCanhBao,
            this.colTrangThaiNVLText});
            this.dgvNguyenVatLieu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvNguyenVatLieu.EnableHeadersVisualStyles = false;
            this.dgvNguyenVatLieu.Location = new System.Drawing.Point(1, 1);
            this.dgvNguyenVatLieu.Name = "dgvNguyenVatLieu";
            this.dgvNguyenVatLieu.ReadOnly = true;
            this.dgvNguyenVatLieu.RowHeadersVisible = false;
            this.dgvNguyenVatLieu.RowTemplate.Height = 35;
            this.dgvNguyenVatLieu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNguyenVatLieu.Size = new System.Drawing.Size(558, 586);
            this.dgvNguyenVatLieu.TabIndex = 0;
            // 
            // colMaNVL
            // 
            this.colMaNVL.DataPropertyName = "MaNVL";
            this.colMaNVL.FillWeight = 50F;
            this.colMaNVL.HeaderText = "Mã";
            this.colMaNVL.Name = "colMaNVL";
            this.colMaNVL.ReadOnly = true;
            // 
            // colTenNVL
            // 
            this.colTenNVL.DataPropertyName = "TenNVL";
            this.colTenNVL.FillWeight = 150F;
            this.colTenNVL.HeaderText = "Tên Nguyên Liệu";
            this.colTenNVL.Name = "colTenNVL";
            this.colTenNVL.ReadOnly = true;
            // 
            // colDVT
            // 
            this.colDVT.DataPropertyName = "DonViTinh";
            this.colDVT.FillWeight = 60F;
            this.colDVT.HeaderText = "ĐVT";
            this.colDVT.Name = "colDVT";
            this.colDVT.ReadOnly = true;
            // 
            // colSoLuongTon
            // 
            this.colSoLuongTon.DataPropertyName = "SoLuongTon";
            this.colSoLuongTon.FillWeight = 80F;
            this.colSoLuongTon.HeaderText = "SL Tồn";
            this.colSoLuongTon.Name = "colSoLuongTon";
            this.colSoLuongTon.ReadOnly = true;
            // 
            // colMucCanhBao
            // 
            this.colMucCanhBao.DataPropertyName = "MucCanhBao";
            this.colMucCanhBao.FillWeight = 80F;
            this.colMucCanhBao.HeaderText = "Cảnh Báo";
            this.colMucCanhBao.Name = "colMucCanhBao";
            this.colMucCanhBao.ReadOnly = true;
            // 
            // colTrangThaiNVLText
            // 
            this.colTrangThaiNVLText.DataPropertyName = "TrangThaiText";
            this.colTrangThaiNVLText.HeaderText = "Trạng Thái";
            this.colTrangThaiNVLText.Name = "colTrangThaiNVLText";
            this.colTrangThaiNVLText.ReadOnly = true;
            // 
            // pnlEditNVL
            // 
            this.pnlEditNVL.BackColor = System.Drawing.Color.White;
            this.pnlEditNVL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlEditNVL.Controls.Add(this.btnNhapKho);
            this.pnlEditNVL.Controls.Add(this.chkTrangThaiNVL);
            this.pnlEditNVL.Controls.Add(this.lblTrangThaiNVL);
            this.pnlEditNVL.Controls.Add(this.btnLamMoiNVL);
            this.pnlEditNVL.Controls.Add(this.btnLuuNVL);
            this.pnlEditNVL.Controls.Add(this.btnSuaNVL);
            this.pnlEditNVL.Controls.Add(this.btnThemNVL);
            this.pnlEditNVL.Controls.Add(this.txtMucCanhBao);
            this.pnlEditNVL.Controls.Add(this.lblMucCanhBao);
            this.pnlEditNVL.Controls.Add(this.txtDVT);
            this.pnlEditNVL.Controls.Add(this.lblDVT);
            this.pnlEditNVL.Controls.Add(this.txtTenNVL);
            this.pnlEditNVL.Controls.Add(this.lblTenNVL);
            this.pnlEditNVL.Controls.Add(this.txtMaNVL);
            this.pnlEditNVL.Controls.Add(this.lblMaNVL);
            this.pnlEditNVL.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlEditNVL.Location = new System.Drawing.Point(577, 15);
            this.pnlEditNVL.Name = "pnlEditNVL";
            this.pnlEditNVL.Size = new System.Drawing.Size(400, 590);
            this.pnlEditNVL.TabIndex = 0;
            // 
            // btnNhapKho
            // 
            this.btnNhapKho.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(119)))), ((int)(((byte)(6)))));
            this.btnNhapKho.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNhapKho.FlatAppearance.BorderSize = 0;
            this.btnNhapKho.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNhapKho.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnNhapKho.ForeColor = System.Drawing.Color.White;
            this.btnNhapKho.Location = new System.Drawing.Point(20, 20);
            this.btnNhapKho.Name = "btnNhapKho";
            this.btnNhapKho.Size = new System.Drawing.Size(358, 45);
            this.btnNhapKho.TabIndex = 14;
            this.btnNhapKho.Text = "📦 NHẬP KHO";
            this.btnNhapKho.UseVisualStyleBackColor = false;
            // 
            // chkTrangThaiNVL
            // 
            this.chkTrangThaiNVL.AutoSize = true;
            this.chkTrangThaiNVL.Checked = true;
            this.chkTrangThaiNVL.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTrangThaiNVL.Location = new System.Drawing.Point(120, 310);
            this.chkTrangThaiNVL.Name = "chkTrangThaiNVL";
            this.chkTrangThaiNVL.Size = new System.Drawing.Size(117, 23);
            this.chkTrangThaiNVL.TabIndex = 13;
            this.chkTrangThaiNVL.Text = "Đang sử dụng";
            this.chkTrangThaiNVL.UseVisualStyleBackColor = true;
            // 
            // lblTrangThaiNVL
            // 
            this.lblTrangThaiNVL.AutoSize = true;
            this.lblTrangThaiNVL.Location = new System.Drawing.Point(20, 311);
            this.lblTrangThaiNVL.Name = "lblTrangThaiNVL";
            this.lblTrangThaiNVL.Size = new System.Drawing.Size(76, 19);
            this.lblTrangThaiNVL.TabIndex = 12;
            this.lblTrangThaiNVL.Text = "Trạng thái:";
            // 
            // btnLamMoiNVL
            // 
            this.btnLamMoiNVL.Location = new System.Drawing.Point(200, 410);
            this.btnLamMoiNVL.Name = "btnLamMoiNVL";
            this.btnLamMoiNVL.Size = new System.Drawing.Size(178, 35);
            this.btnLamMoiNVL.TabIndex = 11;
            this.btnLamMoiNVL.Text = "Làm mới";
            this.btnLamMoiNVL.UseVisualStyleBackColor = true;
            // 
            // btnLuuNVL
            // 
            this.btnLuuNVL.Location = new System.Drawing.Point(20, 410);
            this.btnLuuNVL.Name = "btnLuuNVL";
            this.btnLuuNVL.Size = new System.Drawing.Size(170, 35);
            this.btnLuuNVL.TabIndex = 10;
            this.btnLuuNVL.Text = "Lưu (Thêm/Sửa)";
            this.btnLuuNVL.UseVisualStyleBackColor = true;
            // 
            // btnSuaNVL
            // 
            this.btnSuaNVL.Location = new System.Drawing.Point(200, 360);
            this.btnSuaNVL.Name = "btnSuaNVL";
            this.btnSuaNVL.Size = new System.Drawing.Size(178, 35);
            this.btnSuaNVL.TabIndex = 9;
            this.btnSuaNVL.Text = "Chuẩn bị Sửa";
            this.btnSuaNVL.UseVisualStyleBackColor = true;
            // 
            // btnThemNVL
            // 
            this.btnThemNVL.Location = new System.Drawing.Point(20, 360);
            this.btnThemNVL.Name = "btnThemNVL";
            this.btnThemNVL.Size = new System.Drawing.Size(170, 35);
            this.btnThemNVL.TabIndex = 8;
            this.btnThemNVL.Text = "Chuẩn bị Thêm";
            this.btnThemNVL.UseVisualStyleBackColor = true;
            // 
            // txtMucCanhBao
            // 
            this.txtMucCanhBao.Location = new System.Drawing.Point(120, 260);
            this.txtMucCanhBao.Name = "txtMucCanhBao";
            this.txtMucCanhBao.Size = new System.Drawing.Size(258, 25);
            this.txtMucCanhBao.TabIndex = 7;
            this.txtMucCanhBao.Text = "10";
            // 
            // lblMucCanhBao
            // 
            this.lblMucCanhBao.AutoSize = true;
            this.lblMucCanhBao.Location = new System.Drawing.Point(20, 263);
            this.lblMucCanhBao.Name = "lblMucCanhBao";
            this.lblMucCanhBao.Size = new System.Drawing.Size(98, 19);
            this.lblMucCanhBao.TabIndex = 6;
            this.lblMucCanhBao.Text = "Mức cảnh báo:";
            // 
            // txtDVT
            // 
            this.txtDVT.Location = new System.Drawing.Point(120, 210);
            this.txtDVT.Name = "txtDVT";
            this.txtDVT.Size = new System.Drawing.Size(258, 25);
            this.txtDVT.TabIndex = 5;
            // 
            // lblDVT
            // 
            this.lblDVT.AutoSize = true;
            this.lblDVT.Location = new System.Drawing.Point(20, 213);
            this.lblDVT.Name = "lblDVT";
            this.lblDVT.Size = new System.Drawing.Size(37, 19);
            this.lblDVT.TabIndex = 4;
            this.lblDVT.Text = "ĐVT:";
            // 
            // txtTenNVL
            // 
            this.txtTenNVL.Location = new System.Drawing.Point(120, 160);
            this.txtTenNVL.Name = "txtTenNVL";
            this.txtTenNVL.Size = new System.Drawing.Size(258, 25);
            this.txtTenNVL.TabIndex = 3;
            // 
            // lblTenNVL
            // 
            this.lblTenNVL.AutoSize = true;
            this.lblTenNVL.Location = new System.Drawing.Point(20, 163);
            this.lblTenNVL.Name = "lblTenNVL";
            this.lblTenNVL.Size = new System.Drawing.Size(65, 19);
            this.lblTenNVL.TabIndex = 2;
            this.lblTenNVL.Text = "Tên NVL:";
            // 
            // txtMaNVL
            // 
            this.txtMaNVL.Location = new System.Drawing.Point(120, 110);
            this.txtMaNVL.Name = "txtMaNVL";
            this.txtMaNVL.ReadOnly = true;
            this.txtMaNVL.Size = new System.Drawing.Size(258, 25);
            this.txtMaNVL.TabIndex = 1;
            // 
            // lblMaNVL
            // 
            this.lblMaNVL.AutoSize = true;
            this.lblMaNVL.Location = new System.Drawing.Point(20, 113);
            this.lblMaNVL.Name = "lblMaNVL";
            this.lblMaNVL.Size = new System.Drawing.Size(64, 19);
            this.lblMaNVL.TabIndex = 0;
            this.lblMaNVL.Text = "Mã NVL:";
            // 
            // tabPagePhieuNhap
            // 
            this.tabPagePhieuNhap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.tabPagePhieuNhap.Controls.Add(this.dgvPhieuNhap);
            this.tabPagePhieuNhap.Location = new System.Drawing.Point(4, 26);
            this.tabPagePhieuNhap.Name = "tabPagePhieuNhap";
            this.tabPagePhieuNhap.Padding = new System.Windows.Forms.Padding(15);
            this.tabPagePhieuNhap.Size = new System.Drawing.Size(992, 620);
            this.tabPagePhieuNhap.TabIndex = 1;
            this.tabPagePhieuNhap.Text = "Lịch sử Nhập kho";
            // 
            // dgvPhieuNhap
            // 
            this.dgvPhieuNhap.AllowUserToAddRows = false;
            this.dgvPhieuNhap.AllowUserToDeleteRows = false;
            this.dgvPhieuNhap.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPhieuNhap.BackgroundColor = System.Drawing.Color.White;
            this.dgvPhieuNhap.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPhieuNhap.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPhieuNhap.ColumnHeadersHeight = 35;
            this.dgvPhieuNhap.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaPN,
            this.colNgayNhap,
            this.colMaNV,
            this.colTongTien,
            this.colGhiChu});
            this.dgvPhieuNhap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPhieuNhap.EnableHeadersVisualStyles = false;
            this.dgvPhieuNhap.Location = new System.Drawing.Point(15, 15);
            this.dgvPhieuNhap.Name = "dgvPhieuNhap";
            this.dgvPhieuNhap.ReadOnly = true;
            this.dgvPhieuNhap.RowHeadersVisible = false;
            this.dgvPhieuNhap.RowTemplate.Height = 35;
            this.dgvPhieuNhap.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPhieuNhap.Size = new System.Drawing.Size(962, 590);
            this.dgvPhieuNhap.TabIndex = 1;
            // 
            // colMaPN
            // 
            this.colMaPN.DataPropertyName = "MaPN";
            this.colMaPN.FillWeight = 50F;
            this.colMaPN.HeaderText = "Mã Phiếu";
            this.colMaPN.Name = "colMaPN";
            this.colMaPN.ReadOnly = true;
            // 
            // colNgayNhap
            // 
            this.colNgayNhap.DataPropertyName = "NgayNhap";
            this.colNgayNhap.FillWeight = 100F;
            this.colNgayNhap.HeaderText = "Ngày Nhập";
            this.colNgayNhap.Name = "colNgayNhap";
            this.colNgayNhap.ReadOnly = true;
            // 
            // colMaNV
            // 
            this.colMaNV.DataPropertyName = "MaNV";
            this.colMaNV.FillWeight = 80F;
            this.colMaNV.HeaderText = "Mã NV";
            this.colMaNV.Name = "colMaNV";
            this.colMaNV.ReadOnly = true;
            // 
            // colTongTien
            // 
            this.colTongTien.DataPropertyName = "TongTienFormatted";
            this.colTongTien.FillWeight = 100F;
            this.colTongTien.HeaderText = "Tổng Tiền";
            this.colTongTien.Name = "colTongTien";
            this.colTongTien.ReadOnly = true;
            // 
            // colGhiChu
            // 
            this.colGhiChu.DataPropertyName = "GhiChu";
            this.colGhiChu.FillWeight = 150F;
            this.colGhiChu.HeaderText = "Ghi Chú";
            this.colGhiChu.Name = "colGhiChu";
            this.colGhiChu.ReadOnly = true;
            // 
            // FrmQuanLyKho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 700);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmQuanLyKho";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Kho";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.tabMain.ResumeLayout(false);
            this.tabPageNVL.ResumeLayout(false);
            this.pnlListNVL.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNguyenVatLieu)).EndInit();
            this.pnlEditNVL.ResumeLayout(false);
            this.pnlEditNVL.PerformLayout();
            this.tabPagePhieuNhap.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuNhap)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabPageNVL;
        private System.Windows.Forms.TabPage tabPagePhieuNhap;
        private System.Windows.Forms.Panel pnlListNVL;
        private System.Windows.Forms.Panel pnlEditNVL;
        private System.Windows.Forms.DataGridView dgvNguyenVatLieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaNVL;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenNVL;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDVT;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoLuongTon;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMucCanhBao;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTrangThaiNVLText;
        private System.Windows.Forms.TextBox txtTenNVL;
        private System.Windows.Forms.Label lblTenNVL;
        private System.Windows.Forms.TextBox txtMaNVL;
        private System.Windows.Forms.Label lblMaNVL;
        private System.Windows.Forms.TextBox txtDVT;
        private System.Windows.Forms.Label lblDVT;
        private System.Windows.Forms.TextBox txtMucCanhBao;
        private System.Windows.Forms.Label lblMucCanhBao;
        private System.Windows.Forms.Button btnLamMoiNVL;
        private System.Windows.Forms.Button btnLuuNVL;
        private System.Windows.Forms.Button btnSuaNVL;
        private System.Windows.Forms.Button btnThemNVL;
        private System.Windows.Forms.CheckBox chkTrangThaiNVL;
        private System.Windows.Forms.Label lblTrangThaiNVL;
        private System.Windows.Forms.Button btnNhapKho;
        private System.Windows.Forms.DataGridView dgvPhieuNhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaPN;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNgayNhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaNV;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTongTien;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGhiChu;
    }
}
