namespace QLCF.Forms
{
    partial class FrmQuanLyMonAn
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabDanhMuc = new System.Windows.Forms.TabPage();
            this.pnlDanhMucContent = new System.Windows.Forms.Panel();
            this.dgvDanhMuc = new System.Windows.Forms.DataGridView();
            this.colMaDM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenDanhMuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTrangThaiDanhMucText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlDanhMucInput = new System.Windows.Forms.Panel();
            this.grpChiTietDanhMuc = new System.Windows.Forms.GroupBox();
            this.btnLamMoiDanhMuc = new System.Windows.Forms.Button();
            this.btnLuuDanhMuc = new System.Windows.Forms.Button();
            this.btnSuaDanhMuc = new System.Windows.Forms.Button();
            this.btnThemDanhMuc = new System.Windows.Forms.Button();
            this.chkTrangThaiDanhMuc = new System.Windows.Forms.CheckBox();
            this.txtTenDanhMuc = new System.Windows.Forms.TextBox();
            this.lblTenDanhMuc = new System.Windows.Forms.Label();
            this.txtMaDM = new System.Windows.Forms.TextBox();
            this.lblMaDM = new System.Windows.Forms.Label();
            this.tabMonAn = new System.Windows.Forms.TabPage();
            this.pnlMonAnContent = new System.Windows.Forms.Panel();
            this.dgvMonAn = new System.Windows.Forms.DataGridView();
            this.colMaMon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenMon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenDM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDonGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHinhAnh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTrangThaiMonText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlMonAnSearch = new System.Windows.Forms.Panel();
            this.btnTimKiemMonQuanLy = new System.Windows.Forms.Button();
            this.txtTimKiemMon = new System.Windows.Forms.TextBox();
            this.lblTimKiemMon = new System.Windows.Forms.Label();
            this.pnlMonAnInput = new System.Windows.Forms.Panel();
            this.grpChiTietMonAn = new System.Windows.Forms.GroupBox();
            this.btnLamMoiMon = new System.Windows.Forms.Button();
            this.btnLuuMon = new System.Windows.Forms.Button();
            this.btnSuaMon = new System.Windows.Forms.Button();
            this.btnThemMon = new System.Windows.Forms.Button();
            this.chkTrangThaiMon = new System.Windows.Forms.CheckBox();
            this.txtHinhAnh = new System.Windows.Forms.TextBox();
            this.lblHinhAnh = new System.Windows.Forms.Label();
            this.nudDonGia = new System.Windows.Forms.NumericUpDown();
            this.lblDonGia = new System.Windows.Forms.Label();
            this.cboDanhMucMon = new System.Windows.Forms.ComboBox();
            this.lblDanhMucMon = new System.Windows.Forms.Label();
            this.txtTenMon = new System.Windows.Forms.TextBox();
            this.lblTenMon = new System.Windows.Forms.Label();
            this.txtMaMon = new System.Windows.Forms.TextBox();
            this.lblMaMon = new System.Windows.Forms.Label();
            this.btnDong = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabDanhMuc.SuspendLayout();
            this.pnlDanhMucContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhMuc)).BeginInit();
            this.pnlDanhMucInput.SuspendLayout();
            this.grpChiTietDanhMuc.SuspendLayout();
            this.tabMonAn.SuspendLayout();
            this.pnlMonAnContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonAn)).BeginInit();
            this.pnlMonAnSearch.SuspendLayout();
            this.pnlMonAnInput.SuspendLayout();
            this.grpChiTietMonAn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDonGia)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.pnlHeader.Controls.Add(this.btnDong);
            this.pnlHeader.Controls.Add(this.lblTieuDe);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1100, 60);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTieuDe.ForeColor = System.Drawing.Color.White;
            this.lblTieuDe.Location = new System.Drawing.Point(20, 15);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(380, 30);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "QUẢN LÝ MÓN ĂN & DANH MỤC";
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabDanhMuc);
            this.tabMain.Controls.Add(this.tabMonAn);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabMain.ItemSize = new System.Drawing.Size(180, 42);
            this.tabMain.Location = new System.Drawing.Point(0, 60);
            this.tabMain.Name = "tabMain";
            this.tabMain.Padding = new System.Drawing.Point(24, 10);
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(1100, 590);
            this.tabMain.SizeMode = System.Windows.Forms.TabSizeMode.Normal;
            this.tabMain.TabIndex = 1;
            // 
            // tabDanhMuc
            // 
            this.tabDanhMuc.Controls.Add(this.pnlDanhMucContent);
            this.tabDanhMuc.Controls.Add(this.pnlDanhMucInput);
            this.tabDanhMuc.Location = new System.Drawing.Point(4, 46);
            this.tabDanhMuc.Name = "tabDanhMuc";
            this.tabDanhMuc.Padding = new System.Windows.Forms.Padding(10);
            this.tabDanhMuc.Size = new System.Drawing.Size(1092, 540);
            this.tabDanhMuc.TabIndex = 0;
            this.tabDanhMuc.Text = " 📂   Danh Mục Món  ";
            this.tabDanhMuc.UseVisualStyleBackColor = true;
            // 
            // pnlDanhMucContent
            // 
            this.pnlDanhMucContent.Controls.Add(this.dgvDanhMuc);
            this.pnlDanhMucContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDanhMucContent.Location = new System.Drawing.Point(380, 10);
            this.pnlDanhMucContent.Name = "pnlDanhMucContent";
            this.pnlDanhMucContent.Size = new System.Drawing.Size(702, 527);
            this.pnlDanhMucContent.TabIndex = 1;
            // 
            // dgvDanhMuc
            // 
            this.dgvDanhMuc.AllowUserToAddRows = false;
            this.dgvDanhMuc.AllowUserToDeleteRows = false;
            this.dgvDanhMuc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDanhMuc.BackgroundColor = System.Drawing.Color.White;
            this.dgvDanhMuc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDanhMuc.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDanhMuc.ColumnHeadersHeight = 35;
            this.dgvDanhMuc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaDM,
            this.colTenDanhMuc,
            this.colTrangThaiDanhMucText});
            this.dgvDanhMuc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDanhMuc.EnableHeadersVisualStyles = false;
            this.dgvDanhMuc.Location = new System.Drawing.Point(0, 0);
            this.dgvDanhMuc.MultiSelect = false;
            this.dgvDanhMuc.Name = "dgvDanhMuc";
            this.dgvDanhMuc.ReadOnly = true;
            this.dgvDanhMuc.RowHeadersVisible = false;
            this.dgvDanhMuc.RowHeadersWidth = 51;
            this.dgvDanhMuc.RowTemplate.Height = 30;
            this.dgvDanhMuc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDanhMuc.Size = new System.Drawing.Size(702, 527);
            this.dgvDanhMuc.TabIndex = 0;
            // 
            // colMaDM
            // 
            this.colMaDM.DataPropertyName = "MaDM";
            this.colMaDM.HeaderText = "Mã DM";
            this.colMaDM.FillWeight = 30F;
            this.colMaDM.Name = "colMaDM";
            this.colMaDM.ReadOnly = true;
            // 
            // colTenDanhMuc
            // 
            this.colTenDanhMuc.DataPropertyName = "TenDanhMuc";
            this.colTenDanhMuc.HeaderText = "Tên danh mục";
            this.colTenDanhMuc.FillWeight = 120F;
            this.colTenDanhMuc.Name = "colTenDanhMuc";
            this.colTenDanhMuc.ReadOnly = true;
            // 
            // colTrangThaiDanhMucText
            // 
            this.colTrangThaiDanhMucText.DataPropertyName = "TrangThaiText";
            this.colTrangThaiDanhMucText.HeaderText = "Trạng thái";
            this.colTrangThaiDanhMucText.FillWeight = 50F;
            this.colTrangThaiDanhMucText.Name = "colTrangThaiDanhMucText";
            this.colTrangThaiDanhMucText.ReadOnly = true;
            // 
            // pnlDanhMucInput
            // 
            this.pnlDanhMucInput.Controls.Add(this.grpChiTietDanhMuc);
            this.pnlDanhMucInput.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlDanhMucInput.Location = new System.Drawing.Point(10, 10);
            this.pnlDanhMucInput.Name = "pnlDanhMucInput";
            this.pnlDanhMucInput.Size = new System.Drawing.Size(370, 527);
            this.pnlDanhMucInput.TabIndex = 0;
            // 
            // grpChiTietDanhMuc
            // 
            this.grpChiTietDanhMuc.Controls.Add(this.btnLamMoiDanhMuc);
            this.grpChiTietDanhMuc.Controls.Add(this.btnLuuDanhMuc);
            this.grpChiTietDanhMuc.Controls.Add(this.btnSuaDanhMuc);
            this.grpChiTietDanhMuc.Controls.Add(this.btnThemDanhMuc);
            this.grpChiTietDanhMuc.Controls.Add(this.chkTrangThaiDanhMuc);
            this.grpChiTietDanhMuc.Controls.Add(this.txtTenDanhMuc);
            this.grpChiTietDanhMuc.Controls.Add(this.lblTenDanhMuc);
            this.grpChiTietDanhMuc.Controls.Add(this.txtMaDM);
            this.grpChiTietDanhMuc.Controls.Add(this.lblMaDM);
            this.grpChiTietDanhMuc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpChiTietDanhMuc.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpChiTietDanhMuc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.grpChiTietDanhMuc.Location = new System.Drawing.Point(0, 0);
            this.grpChiTietDanhMuc.Name = "grpChiTietDanhMuc";
            this.grpChiTietDanhMuc.Size = new System.Drawing.Size(370, 527);
            this.grpChiTietDanhMuc.TabIndex = 0;
            this.grpChiTietDanhMuc.TabStop = false;
            this.grpChiTietDanhMuc.Text = "Thông tin danh mục";
            // 
            // btnLamMoiDanhMuc
            // 
            this.btnLamMoiDanhMuc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnLamMoiDanhMuc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLamMoiDanhMuc.FlatAppearance.BorderSize = 0;
            this.btnLamMoiDanhMuc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoiDanhMuc.ForeColor = System.Drawing.Color.White;
            this.btnLamMoiDanhMuc.Location = new System.Drawing.Point(185, 290);
            this.btnLamMoiDanhMuc.Name = "btnLamMoiDanhMuc";
            this.btnLamMoiDanhMuc.Size = new System.Drawing.Size(155, 40);
            this.btnLamMoiDanhMuc.TabIndex = 8;
            this.btnLamMoiDanhMuc.Text = "🔄 Làm mới";
            this.btnLamMoiDanhMuc.UseVisualStyleBackColor = false;
            // 
            // btnLuuDanhMuc
            // 
            this.btnLuuDanhMuc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnLuuDanhMuc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLuuDanhMuc.FlatAppearance.BorderSize = 0;
            this.btnLuuDanhMuc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuuDanhMuc.ForeColor = System.Drawing.Color.White;
            this.btnLuuDanhMuc.Location = new System.Drawing.Point(20, 290);
            this.btnLuuDanhMuc.Name = "btnLuuDanhMuc";
            this.btnLuuDanhMuc.Size = new System.Drawing.Size(155, 40);
            this.btnLuuDanhMuc.TabIndex = 7;
            this.btnLuuDanhMuc.Text = "💾 Lưu";
            this.btnLuuDanhMuc.UseVisualStyleBackColor = false;
            // 
            // btnSuaDanhMuc
            // 
            this.btnSuaDanhMuc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(196)))), ((int)(((byte)(15)))));
            this.btnSuaDanhMuc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSuaDanhMuc.FlatAppearance.BorderSize = 0;
            this.btnSuaDanhMuc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuaDanhMuc.ForeColor = System.Drawing.Color.White;
            this.btnSuaDanhMuc.Location = new System.Drawing.Point(185, 235);
            this.btnSuaDanhMuc.Name = "btnSuaDanhMuc";
            this.btnSuaDanhMuc.Size = new System.Drawing.Size(155, 40);
            this.btnSuaDanhMuc.TabIndex = 6;
            this.btnSuaDanhMuc.Text = "✏️ Sửa";
            this.btnSuaDanhMuc.UseVisualStyleBackColor = false;
            // 
            // btnThemDanhMuc
            // 
            this.btnThemDanhMuc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnThemDanhMuc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThemDanhMuc.FlatAppearance.BorderSize = 0;
            this.btnThemDanhMuc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemDanhMuc.ForeColor = System.Drawing.Color.White;
            this.btnThemDanhMuc.Location = new System.Drawing.Point(20, 235);
            this.btnThemDanhMuc.Name = "btnThemDanhMuc";
            this.btnThemDanhMuc.Size = new System.Drawing.Size(155, 40);
            this.btnThemDanhMuc.TabIndex = 5;
            this.btnThemDanhMuc.Text = "➕ Thêm mới";
            this.btnThemDanhMuc.UseVisualStyleBackColor = false;
            // 
            // chkTrangThaiDanhMuc
            // 
            this.chkTrangThaiDanhMuc.AutoSize = true;
            this.chkTrangThaiDanhMuc.Checked = true;
            this.chkTrangThaiDanhMuc.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTrangThaiDanhMuc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkTrangThaiDanhMuc.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTrangThaiDanhMuc.Location = new System.Drawing.Point(20, 180);
            this.chkTrangThaiDanhMuc.Name = "chkTrangThaiDanhMuc";
            this.chkTrangThaiDanhMuc.Size = new System.Drawing.Size(139, 25);
            this.chkTrangThaiDanhMuc.TabIndex = 4;
            this.chkTrangThaiDanhMuc.Text = "Đang sử dụng";
            this.chkTrangThaiDanhMuc.UseVisualStyleBackColor = true;
            // 
            // txtTenDanhMuc
            // 
            this.txtTenDanhMuc.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenDanhMuc.Location = new System.Drawing.Point(20, 135);
            this.txtTenDanhMuc.Name = "txtTenDanhMuc";
            this.txtTenDanhMuc.Size = new System.Drawing.Size(320, 30);
            this.txtTenDanhMuc.TabIndex = 3;
            // 
            // lblTenDanhMuc
            // 
            this.lblTenDanhMuc.AutoSize = true;
            this.lblTenDanhMuc.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenDanhMuc.Location = new System.Drawing.Point(20, 110);
            this.lblTenDanhMuc.Name = "lblTenDanhMuc";
            this.lblTenDanhMuc.Size = new System.Drawing.Size(122, 21);
            this.lblTenDanhMuc.TabIndex = 2;
            this.lblTenDanhMuc.Text = "Tên danh mục:";
            // 
            // txtMaDM
            // 
            this.txtMaDM.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaDM.Location = new System.Drawing.Point(20, 65);
            this.txtMaDM.Name = "txtMaDM";
            this.txtMaDM.ReadOnly = true;
            this.txtMaDM.Size = new System.Drawing.Size(320, 30);
            this.txtMaDM.TabIndex = 1;
            // 
            // lblMaDM
            // 
            this.lblMaDM.AutoSize = true;
            this.lblMaDM.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaDM.Location = new System.Drawing.Point(20, 40);
            this.lblMaDM.Name = "lblMaDM";
            this.lblMaDM.Size = new System.Drawing.Size(119, 21);
            this.lblMaDM.TabIndex = 0;
            this.lblMaDM.Text = "Mã danh mục:";
            // 
            // tabMonAn
            // 
            this.tabMonAn.Controls.Add(this.pnlMonAnContent);
            this.tabMonAn.Controls.Add(this.pnlMonAnSearch);
            this.tabMonAn.Controls.Add(this.pnlMonAnInput);
            this.tabMonAn.Location = new System.Drawing.Point(4, 39);
            this.tabMonAn.Name = "tabMonAn";
            this.tabMonAn.Padding = new System.Windows.Forms.Padding(10);
            this.tabMonAn.Size = new System.Drawing.Size(1092, 547);
            this.tabMonAn.TabIndex = 1;
            this.tabMonAn.Text = " ☕   Danh Sách Món Ăn  ";
            this.tabMonAn.UseVisualStyleBackColor = true;
            // 
            // pnlMonAnContent
            // 
            this.pnlMonAnContent.Controls.Add(this.dgvMonAn);
            this.pnlMonAnContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMonAnContent.Location = new System.Drawing.Point(400, 65);
            this.pnlMonAnContent.Name = "pnlMonAnContent";
            this.pnlMonAnContent.Size = new System.Drawing.Size(682, 472);
            this.pnlMonAnContent.TabIndex = 2;
            // 
            // dgvMonAn
            // 
            this.dgvMonAn.AllowUserToAddRows = false;
            this.dgvMonAn.AllowUserToDeleteRows = false;
            this.dgvMonAn.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMonAn.BackgroundColor = System.Drawing.Color.White;
            this.dgvMonAn.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMonAn.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvMonAn.ColumnHeadersHeight = 35;
            this.dgvMonAn.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaMon,
            this.colTenMon,
            this.colTenDM,
            this.colDonGia,
            this.colHinhAnh,
            this.colTrangThaiMonText});
            this.dgvMonAn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMonAn.EnableHeadersVisualStyles = false;
            this.dgvMonAn.Location = new System.Drawing.Point(0, 0);
            this.dgvMonAn.MultiSelect = false;
            this.dgvMonAn.Name = "dgvMonAn";
            this.dgvMonAn.ReadOnly = true;
            this.dgvMonAn.RowHeadersVisible = false;
            this.dgvMonAn.RowHeadersWidth = 51;
            this.dgvMonAn.RowTemplate.Height = 48;
            this.dgvMonAn.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMonAn.Size = new System.Drawing.Size(682, 472);
            this.dgvMonAn.TabIndex = 0;
            // 
            // colMaMon
            // 
            this.colMaMon.DataPropertyName = "MaMon";
            this.colMaMon.HeaderText = "Mã món";
            this.colMaMon.FillWeight = 30F;
            this.colMaMon.Name = "colMaMon";
            this.colMaMon.ReadOnly = true;
            // 
            // colTenMon
            // 
            this.colTenMon.DataPropertyName = "TenMon";
            this.colTenMon.HeaderText = "Tên món ăn";
            this.colTenMon.FillWeight = 100F;
            this.colTenMon.Name = "colTenMon";
            this.colTenMon.ReadOnly = true;
            // 
            // colTenDM
            // 
            this.colTenDM.DataPropertyName = "TenDanhMuc";
            this.colTenDM.HeaderText = "Danh mục";
            this.colTenDM.FillWeight = 70F;
            this.colTenDM.Name = "colTenDM";
            this.colTenDM.ReadOnly = true;
            // 
            // colDonGia
            // 
            this.colDonGia.DataPropertyName = "DonGiaFormatted";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colDonGia.DefaultCellStyle = dataGridViewCellStyle3;
            this.colDonGia.HeaderText = "Đơn giá";
            this.colDonGia.FillWeight = 60F;
            this.colDonGia.Name = "colDonGia";
            this.colDonGia.ReadOnly = true;
            // 
            // colHinhAnh
            // 
            this.colHinhAnh.DataPropertyName = "HinhAnhImage";
            this.colHinhAnh.HeaderText = "Hình ảnh";
            this.colHinhAnh.FillWeight = 50F;
            this.colHinhAnh.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.colHinhAnh.Name = "colHinhAnh";
            this.colHinhAnh.ReadOnly = true;
            // 
            // colTrangThaiMonText
            // 
            this.colTrangThaiMonText.DataPropertyName = "TrangThaiText";
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colTrangThaiMonText.DefaultCellStyle = dataGridViewCellStyle4;
            this.colTrangThaiMonText.HeaderText = "Trạng thái";
            this.colTrangThaiMonText.FillWeight = 50F;
            this.colTrangThaiMonText.Name = "colTrangThaiMonText";
            this.colTrangThaiMonText.ReadOnly = true;
            // 
            // pnlMonAnSearch
            // 
            this.pnlMonAnSearch.Controls.Add(this.btnTimKiemMonQuanLy);
            this.pnlMonAnSearch.Controls.Add(this.txtTimKiemMon);
            this.pnlMonAnSearch.Controls.Add(this.lblTimKiemMon);
            this.pnlMonAnSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMonAnSearch.Location = new System.Drawing.Point(400, 10);
            this.pnlMonAnSearch.Name = "pnlMonAnSearch";
            this.pnlMonAnSearch.Size = new System.Drawing.Size(682, 55);
            this.pnlMonAnSearch.TabIndex = 1;
            // 
            // btnTimKiemMonQuanLy
            // 
            this.btnTimKiemMonQuanLy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnTimKiemMonQuanLy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTimKiemMonQuanLy.FlatAppearance.BorderSize = 0;
            this.btnTimKiemMonQuanLy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiemMonQuanLy.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiemMonQuanLy.ForeColor = System.Drawing.Color.White;
            this.btnTimKiemMonQuanLy.Location = new System.Drawing.Point(435, 10);
            this.btnTimKiemMonQuanLy.Name = "btnTimKiemMonQuanLy";
            this.btnTimKiemMonQuanLy.Size = new System.Drawing.Size(120, 32);
            this.btnTimKiemMonQuanLy.TabIndex = 2;
            this.btnTimKiemMonQuanLy.Text = "🔍 Tìm kiếm";
            this.btnTimKiemMonQuanLy.UseVisualStyleBackColor = false;
            // 
            // txtTimKiemMon
            // 
            this.txtTimKiemMon.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimKiemMon.Location = new System.Drawing.Point(125, 12);
            this.txtTimKiemMon.Name = "txtTimKiemMon";
            this.txtTimKiemMon.Size = new System.Drawing.Size(300, 29);
            this.txtTimKiemMon.TabIndex = 1;
            // 
            // lblTimKiemMon
            // 
            this.lblTimKiemMon.AutoSize = true;
            this.lblTimKiemMon.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimKiemMon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblTimKiemMon.Location = new System.Drawing.Point(10, 15);
            this.lblTimKiemMon.Name = "lblTimKiemMon";
            this.lblTimKiemMon.Size = new System.Drawing.Size(111, 21);
            this.lblTimKiemMon.TabIndex = 0;
            this.lblTimKiemMon.Text = "Tìm tên món:";
            // 
            // pnlMonAnInput
            // 
            this.pnlMonAnInput.Controls.Add(this.grpChiTietMonAn);
            this.pnlMonAnInput.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMonAnInput.Location = new System.Drawing.Point(10, 10);
            this.pnlMonAnInput.Name = "pnlMonAnInput";
            this.pnlMonAnInput.Size = new System.Drawing.Size(390, 527);
            this.pnlMonAnInput.TabIndex = 0;
            // 
            // grpChiTietMonAn
            // 
            this.grpChiTietMonAn.Controls.Add(this.btnLamMoiMon);
            this.grpChiTietMonAn.Controls.Add(this.btnLuuMon);
            this.grpChiTietMonAn.Controls.Add(this.btnSuaMon);
            this.grpChiTietMonAn.Controls.Add(this.btnThemMon);
            this.grpChiTietMonAn.Controls.Add(this.chkTrangThaiMon);
            this.grpChiTietMonAn.Controls.Add(this.btnChonHinhAnh);
            this.grpChiTietMonAn.Controls.Add(this.picHinhAnhMon);
            this.grpChiTietMonAn.Controls.Add(this.lblXemTruocHinhAnh);
            this.grpChiTietMonAn.Controls.Add(this.nudDonGia);
            this.grpChiTietMonAn.Controls.Add(this.lblDonGia);
            this.grpChiTietMonAn.Controls.Add(this.cboDanhMucMon);
            this.grpChiTietMonAn.Controls.Add(this.lblDanhMucMon);
            this.grpChiTietMonAn.Controls.Add(this.txtTenMon);
            this.grpChiTietMonAn.Controls.Add(this.lblTenMon);
            this.grpChiTietMonAn.Controls.Add(this.txtMaMon);
            this.grpChiTietMonAn.Controls.Add(this.lblMaMon);
            this.grpChiTietMonAn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpChiTietMonAn.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpChiTietMonAn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.grpChiTietMonAn.Location = new System.Drawing.Point(0, 0);
            this.grpChiTietMonAn.Name = "grpChiTietMonAn";
            this.grpChiTietMonAn.Size = new System.Drawing.Size(390, 527);
            this.grpChiTietMonAn.TabIndex = 0;
            this.grpChiTietMonAn.TabStop = false;
            this.grpChiTietMonAn.Text = "Thông tin món ăn";
            // 
            // btnLamMoiMon
            // 
            this.btnLamMoiMon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnLamMoiMon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLamMoiMon.FlatAppearance.BorderSize = 0;
            this.btnLamMoiMon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoiMon.ForeColor = System.Drawing.Color.White;
            this.btnLamMoiMon.Location = new System.Drawing.Point(195, 465);
            this.btnLamMoiMon.Name = "btnLamMoiMon";
            this.btnLamMoiMon.Size = new System.Drawing.Size(165, 40);
            this.btnLamMoiMon.TabIndex = 14;
            this.btnLamMoiMon.Text = "🔄 Làm mới";
            this.btnLamMoiMon.UseVisualStyleBackColor = false;
            // 
            // btnLuuMon
            // 
            this.btnLuuMon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnLuuMon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLuuMon.FlatAppearance.BorderSize = 0;
            this.btnLuuMon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuuMon.ForeColor = System.Drawing.Color.White;
            this.btnLuuMon.Location = new System.Drawing.Point(20, 465);
            this.btnLuuMon.Name = "btnLuuMon";
            this.btnLuuMon.Size = new System.Drawing.Size(165, 40);
            this.btnLuuMon.TabIndex = 13;
            this.btnLuuMon.Text = "💾 Lưu";
            this.btnLuuMon.UseVisualStyleBackColor = false;
            // 
            // btnSuaMon
            // 
            this.btnSuaMon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(196)))), ((int)(((byte)(15)))));
            this.btnSuaMon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSuaMon.FlatAppearance.BorderSize = 0;
            this.btnSuaMon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuaMon.ForeColor = System.Drawing.Color.White;
            this.btnSuaMon.Location = new System.Drawing.Point(195, 415);
            this.btnSuaMon.Name = "btnSuaMon";
            this.btnSuaMon.Size = new System.Drawing.Size(165, 40);
            this.btnSuaMon.TabIndex = 12;
            this.btnSuaMon.Text = "✏️ Sửa";
            this.btnSuaMon.UseVisualStyleBackColor = false;
            // 
            // btnThemMon
            // 
            this.btnThemMon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnThemMon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThemMon.FlatAppearance.BorderSize = 0;
            this.btnThemMon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemMon.ForeColor = System.Drawing.Color.White;
            this.btnThemMon.Location = new System.Drawing.Point(20, 415);
            this.btnThemMon.Name = "btnThemMon";
            this.btnThemMon.Size = new System.Drawing.Size(165, 40);
            this.btnThemMon.TabIndex = 11;
            this.btnThemMon.Text = "➕ Thêm mới";
            this.btnThemMon.UseVisualStyleBackColor = false;
            // 
            // chkTrangThaiMon
            // 
            this.chkTrangThaiMon.AutoSize = true;
            this.chkTrangThaiMon.Checked = true;
            this.chkTrangThaiMon.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTrangThaiMon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkTrangThaiMon.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTrangThaiMon.Location = new System.Drawing.Point(135, 365);
            this.chkTrangThaiMon.Name = "chkTrangThaiMon";
            this.chkTrangThaiMon.Size = new System.Drawing.Size(155, 25);
            this.chkTrangThaiMon.TabIndex = 10;
            this.chkTrangThaiMon.Text = "Đang kinh doanh";
            this.chkTrangThaiMon.UseVisualStyleBackColor = true;
            // 
            // btnChonHinhAnh
            // 
            this.btnChonHinhAnh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(98)))), ((int)(((byte)(14)))));
            this.btnChonHinhAnh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChonHinhAnh.FlatAppearance.BorderSize = 0;
            this.btnChonHinhAnh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChonHinhAnh.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChonHinhAnh.ForeColor = System.Drawing.Color.White;
            this.btnChonHinhAnh.Location = new System.Drawing.Point(135, 320);
            this.btnChonHinhAnh.Name = "btnChonHinhAnh";
            this.btnChonHinhAnh.Size = new System.Drawing.Size(150, 35);
            this.btnChonHinhAnh.TabIndex = 9;
            this.btnChonHinhAnh.Text = "📷 Chọn hình ảnh";
            this.btnChonHinhAnh.UseVisualStyleBackColor = false;
            // 
            // picHinhAnhMon
            // 
            this.picHinhAnhMon.BackColor = System.Drawing.Color.White;
            this.picHinhAnhMon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picHinhAnhMon.Location = new System.Drawing.Point(20, 320);
            this.picHinhAnhMon.Name = "picHinhAnhMon";
            this.picHinhAnhMon.Size = new System.Drawing.Size(100, 80);
            this.picHinhAnhMon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picHinhAnhMon.TabIndex = 8;
            this.picHinhAnhMon.TabStop = false;
            // 
            // lblXemTruocHinhAnh
            // 
            this.lblXemTruocHinhAnh.AutoSize = true;
            this.lblXemTruocHinhAnh.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblXemTruocHinhAnh.Location = new System.Drawing.Point(20, 296);
            this.lblXemTruocHinhAnh.Name = "lblXemTruocHinhAnh";
            this.lblXemTruocHinhAnh.Size = new System.Drawing.Size(147, 21);
            this.lblXemTruocHinhAnh.TabIndex = 7;
            this.lblXemTruocHinhAnh.Text = "Hình ảnh món ăn:";
            // 
            // nudDonGia
            // 
            this.nudDonGia.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudDonGia.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudDonGia.Location = new System.Drawing.Point(20, 260);
            this.nudDonGia.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.nudDonGia.Name = "nudDonGia";
            this.nudDonGia.Size = new System.Drawing.Size(340, 30);
            this.nudDonGia.TabIndex = 7;
            this.nudDonGia.ThousandsSeparator = true;
            // 
            // lblDonGia
            // 
            this.lblDonGia.AutoSize = true;
            this.lblDonGia.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDonGia.Location = new System.Drawing.Point(20, 235);
            this.lblDonGia.Name = "lblDonGia";
            this.lblDonGia.Size = new System.Drawing.Size(117, 21);
            this.lblDonGia.TabIndex = 6;
            this.lblDonGia.Text = "Đơn giá (VNĐ):";
            // 
            // cboDanhMucMon
            // 
            this.cboDanhMucMon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDanhMucMon.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDanhMucMon.FormattingEnabled = true;
            this.cboDanhMucMon.Location = new System.Drawing.Point(20, 195);
            this.cboDanhMucMon.Name = "cboDanhMucMon";
            this.cboDanhMucMon.Size = new System.Drawing.Size(340, 31);
            this.cboDanhMucMon.TabIndex = 5;
            // 
            // lblDanhMucMon
            // 
            this.lblDanhMucMon.AutoSize = true;
            this.lblDanhMucMon.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDanhMucMon.Location = new System.Drawing.Point(20, 170);
            this.lblDanhMucMon.Name = "lblDanhMucMon";
            this.lblDanhMucMon.Size = new System.Drawing.Size(91, 21);
            this.lblDanhMucMon.TabIndex = 4;
            this.lblDanhMucMon.Text = "Danh mục:";
            // 
            // txtTenMon
            // 
            this.txtTenMon.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenMon.Location = new System.Drawing.Point(20, 130);
            this.txtTenMon.Name = "txtTenMon";
            this.txtTenMon.Size = new System.Drawing.Size(340, 30);
            this.txtTenMon.TabIndex = 3;
            // 
            // lblTenMon
            // 
            this.lblTenMon.AutoSize = true;
            this.lblTenMon.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenMon.Location = new System.Drawing.Point(20, 105);
            this.lblTenMon.Name = "lblTenMon";
            this.lblTenMon.Size = new System.Drawing.Size(105, 21);
            this.lblTenMon.TabIndex = 2;
            this.lblTenMon.Text = "Tên món ăn:";
            // 
            // txtMaMon
            // 
            this.txtMaMon.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaMon.Location = new System.Drawing.Point(20, 65);
            this.txtMaMon.Name = "txtMaMon";
            this.txtMaMon.ReadOnly = true;
            this.txtMaMon.Size = new System.Drawing.Size(340, 30);
            this.txtMaMon.TabIndex = 1;
            // 
            // lblMaMon
            // 
            this.lblMaMon.AutoSize = true;
            this.lblMaMon.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaMon.Location = new System.Drawing.Point(20, 40);
            this.lblMaMon.Name = "lblMaMon";
            this.lblMaMon.Size = new System.Drawing.Size(78, 21);
            this.lblMaMon.TabIndex = 0;
            this.lblMaMon.Text = "Mã món:";
            // 
            // btnDong
            // 
            this.btnDong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnDong.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDong.FlatAppearance.BorderSize = 0;
            this.btnDong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDong.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDong.ForeColor = System.Drawing.Color.White;
            this.btnDong.Location = new System.Drawing.Point(975, 12);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(110, 35);
            this.btnDong.TabIndex = 1;
            this.btnDong.Text = "❌ Đóng";
            this.btnDong.UseVisualStyleBackColor = false;
            // 
            // FrmQuanLyMonAn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1100, 650);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.pnlHeader);
            this.Name = "FrmQuanLyMonAn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý món ăn và danh mục - Quản lý quán café";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.tabMain.ResumeLayout(false);
            this.tabDanhMuc.ResumeLayout(false);
            this.pnlDanhMucContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhMuc)).EndInit();
            this.pnlDanhMucInput.ResumeLayout(false);
            this.grpChiTietDanhMuc.ResumeLayout(false);
            this.grpChiTietDanhMuc.PerformLayout();
            this.tabMonAn.ResumeLayout(false);
            this.pnlMonAnContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonAn)).EndInit();
            this.pnlMonAnSearch.ResumeLayout(false);
            this.pnlMonAnSearch.PerformLayout();
            this.pnlMonAnInput.ResumeLayout(false);
            this.grpChiTietMonAn.ResumeLayout(false);
            this.grpChiTietMonAn.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDonGia)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabDanhMuc;
        private System.Windows.Forms.Panel pnlDanhMucContent;
        private System.Windows.Forms.DataGridView dgvDanhMuc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaDM;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenDanhMuc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTrangThaiDanhMucText;
        private System.Windows.Forms.Panel pnlDanhMucInput;
        private System.Windows.Forms.GroupBox grpChiTietDanhMuc;
        private System.Windows.Forms.Label lblMaDM;
        private System.Windows.Forms.TextBox txtMaDM;
        private System.Windows.Forms.Label lblTenDanhMuc;
        private System.Windows.Forms.TextBox txtTenDanhMuc;
        private System.Windows.Forms.CheckBox chkTrangThaiDanhMuc;
        private System.Windows.Forms.Button btnThemDanhMuc;
        private System.Windows.Forms.Button btnSuaDanhMuc;
        private System.Windows.Forms.Button btnLuuDanhMuc;
        private System.Windows.Forms.Button btnLamMoiDanhMuc;
        private System.Windows.Forms.TabPage tabMonAn;
        private System.Windows.Forms.Panel pnlMonAnContent;
        private System.Windows.Forms.DataGridView dgvMonAn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaMon;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenMon;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenDM;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDonGia;
        private System.Windows.Forms.DataGridViewImageColumn colHinhAnh;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTrangThaiMonText;
        private System.Windows.Forms.Panel pnlMonAnSearch;
        private System.Windows.Forms.Label lblTimKiemMon;
        private System.Windows.Forms.TextBox txtTimKiemMon;
        private System.Windows.Forms.Button btnTimKiemMonQuanLy;
        private System.Windows.Forms.Panel pnlMonAnInput;
        private System.Windows.Forms.GroupBox grpChiTietMonAn;
        private System.Windows.Forms.Label lblMaMon;
        private System.Windows.Forms.TextBox txtMaMon;
        private System.Windows.Forms.Label lblTenMon;
        private System.Windows.Forms.TextBox txtTenMon;
        private System.Windows.Forms.Label lblDanhMucMon;
        private System.Windows.Forms.ComboBox cboDanhMucMon;
        private System.Windows.Forms.Label lblDonGia;
        private System.Windows.Forms.NumericUpDown nudDonGia;
        private System.Windows.Forms.Label lblXemTruocHinhAnh;
        private System.Windows.Forms.PictureBox picHinhAnhMon;
        private System.Windows.Forms.Button btnChonHinhAnh;
        private System.Windows.Forms.CheckBox chkTrangThaiMon;
        private System.Windows.Forms.Button btnThemMon;
        private System.Windows.Forms.Button btnSuaMon;
        private System.Windows.Forms.Button btnLuuMon;
        private System.Windows.Forms.Button btnLamMoiMon;
    }
}
