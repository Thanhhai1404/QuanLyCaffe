namespace QLCF.Forms
{
    partial class FrmQuanLyKhuVucBan
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.btnDong = new System.Windows.Forms.Button();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabKhuVuc = new System.Windows.Forms.TabPage();
            this.pnlKhuVucContent = new System.Windows.Forms.Panel();
            this.dgvKhuVuc = new System.Windows.Forms.DataGridView();
            this.colMaKV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenKhuVuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTrangThaiKhuVucText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlKhuVucInput = new System.Windows.Forms.Panel();
            this.grpChiTietKhuVuc = new System.Windows.Forms.GroupBox();
            this.btnLamMoiKhuVuc = new System.Windows.Forms.Button();
            this.btnLuuKhuVuc = new System.Windows.Forms.Button();
            this.btnSuaKhuVuc = new System.Windows.Forms.Button();
            this.btnThemKhuVuc = new System.Windows.Forms.Button();
            this.chkTrangThaiKhuVuc = new System.Windows.Forms.CheckBox();
            this.txtTenKhuVuc = new System.Windows.Forms.TextBox();
            this.lblTenKhuVuc = new System.Windows.Forms.Label();
            this.txtMaKV = new System.Windows.Forms.TextBox();
            this.lblMaKV = new System.Windows.Forms.Label();
            this.tabBan = new System.Windows.Forms.TabPage();
            this.pnlBanContent = new System.Windows.Forms.Panel();
            this.dgvBan = new System.Windows.Forms.DataGridView();
            this.colMaBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenKhuVucBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTrangThaiBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDangSuDungText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlBanSearch = new System.Windows.Forms.Panel();
            this.btnTimKiemBan = new System.Windows.Forms.Button();
            this.txtTimKiemBan = new System.Windows.Forms.TextBox();
            this.lblTimKiemBan = new System.Windows.Forms.Label();
            this.pnlBanInput = new System.Windows.Forms.Panel();
            this.grpChiTietBan = new System.Windows.Forms.GroupBox();
            this.lblTrangThaiBanWarning = new System.Windows.Forms.Label();
            this.btnLamMoiBan = new System.Windows.Forms.Button();
            this.btnLuuBan = new System.Windows.Forms.Button();
            this.btnSuaBan = new System.Windows.Forms.Button();
            this.btnThemBan = new System.Windows.Forms.Button();
            this.chkDangSuDungBan = new System.Windows.Forms.CheckBox();
            this.cboTrangThaiDatBan = new System.Windows.Forms.ComboBox();
            this.lblTrangThaiDatBan = new System.Windows.Forms.Label();
            this.cboKhuVucBan = new System.Windows.Forms.ComboBox();
            this.lblKhuVucBan = new System.Windows.Forms.Label();
            this.txtTenBan = new System.Windows.Forms.TextBox();
            this.lblTenBan = new System.Windows.Forms.Label();
            this.txtMaBan = new System.Windows.Forms.TextBox();
            this.lblMaBan = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabKhuVuc.SuspendLayout();
            this.pnlKhuVucContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhuVuc)).BeginInit();
            this.pnlKhuVucInput.SuspendLayout();
            this.grpChiTietKhuVuc.SuspendLayout();
            this.tabBan.SuspendLayout();
            this.pnlBanContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBan)).BeginInit();
            this.pnlBanSearch.SuspendLayout();
            this.pnlBanInput.SuspendLayout();
            this.grpChiTietBan.SuspendLayout();
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
            // lblTieuDe
            // 
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTieuDe.ForeColor = System.Drawing.Color.White;
            this.lblTieuDe.Location = new System.Drawing.Point(20, 15);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(378, 32);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "🏢 QUẢN LÝ KHU VỰC VÀ BÀN";
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabKhuVuc);
            this.tabMain.Controls.Add(this.tabBan);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabMain.ItemSize = new System.Drawing.Size(150, 35);
            this.tabMain.Location = new System.Drawing.Point(0, 60);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(1100, 590);
            this.tabMain.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabMain.TabIndex = 1;
            // 
            // tabKhuVuc
            // 
            this.tabKhuVuc.Controls.Add(this.pnlKhuVucContent);
            this.tabKhuVuc.Controls.Add(this.pnlKhuVucInput);
            this.tabKhuVuc.Location = new System.Drawing.Point(4, 39);
            this.tabKhuVuc.Name = "tabKhuVuc";
            this.tabKhuVuc.Padding = new System.Windows.Forms.Padding(10);
            this.tabKhuVuc.Size = new System.Drawing.Size(1092, 547);
            this.tabKhuVuc.TabIndex = 0;
            this.tabKhuVuc.Text = "🗺️ Khu vực";
            this.tabKhuVuc.UseVisualStyleBackColor = true;
            // 
            // pnlKhuVucContent
            // 
            this.pnlKhuVucContent.Controls.Add(this.dgvKhuVuc);
            this.pnlKhuVucContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlKhuVucContent.Location = new System.Drawing.Point(380, 10);
            this.pnlKhuVucContent.Name = "pnlKhuVucContent";
            this.pnlKhuVucContent.Size = new System.Drawing.Size(702, 527);
            this.pnlKhuVucContent.TabIndex = 1;
            // 
            // dgvKhuVuc
            // 
            this.dgvKhuVuc.AllowUserToAddRows = false;
            this.dgvKhuVuc.AllowUserToDeleteRows = false;
            this.dgvKhuVuc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKhuVuc.BackgroundColor = System.Drawing.Color.White;
            this.dgvKhuVuc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvKhuVuc.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvKhuVuc.ColumnHeadersHeight = 35;
            this.dgvKhuVuc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaKV,
            this.colTenKhuVuc,
            this.colTrangThaiKhuVucText});
            this.dgvKhuVuc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvKhuVuc.EnableHeadersVisualStyles = false;
            this.dgvKhuVuc.Location = new System.Drawing.Point(0, 0);
            this.dgvKhuVuc.MultiSelect = false;
            this.dgvKhuVuc.Name = "dgvKhuVuc";
            this.dgvKhuVuc.ReadOnly = true;
            this.dgvKhuVuc.RowHeadersVisible = false;
            this.dgvKhuVuc.RowHeadersWidth = 51;
            this.dgvKhuVuc.RowTemplate.Height = 30;
            this.dgvKhuVuc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKhuVuc.Size = new System.Drawing.Size(702, 527);
            this.dgvKhuVuc.TabIndex = 0;
            // 
            // colMaKV
            // 
            this.colMaKV.DataPropertyName = "MaKV";
            this.colMaKV.HeaderText = "Mã KV";
            this.colMaKV.FillWeight = 30F;
            this.colMaKV.Name = "colMaKV";
            this.colMaKV.ReadOnly = true;
            // 
            // colTenKhuVuc
            // 
            this.colTenKhuVuc.DataPropertyName = "TenKhuVuc";
            this.colTenKhuVuc.HeaderText = "Tên khu vực";
            this.colTenKhuVuc.FillWeight = 120F;
            this.colTenKhuVuc.Name = "colTenKhuVuc";
            this.colTenKhuVuc.ReadOnly = true;
            // 
            // colTrangThaiKhuVucText
            // 
            this.colTrangThaiKhuVucText.DataPropertyName = "TrangThaiText";
            this.colTrangThaiKhuVucText.HeaderText = "Trạng thái";
            this.colTrangThaiKhuVucText.FillWeight = 50F;
            this.colTrangThaiKhuVucText.Name = "colTrangThaiKhuVucText";
            this.colTrangThaiKhuVucText.ReadOnly = true;
            // 
            // pnlKhuVucInput
            // 
            this.pnlKhuVucInput.Controls.Add(this.grpChiTietKhuVuc);
            this.pnlKhuVucInput.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlKhuVucInput.Location = new System.Drawing.Point(10, 10);
            this.pnlKhuVucInput.Name = "pnlKhuVucInput";
            this.pnlKhuVucInput.Size = new System.Drawing.Size(370, 527);
            this.pnlKhuVucInput.TabIndex = 0;
            // 
            // grpChiTietKhuVuc
            // 
            this.grpChiTietKhuVuc.Controls.Add(this.btnLamMoiKhuVuc);
            this.grpChiTietKhuVuc.Controls.Add(this.btnLuuKhuVuc);
            this.grpChiTietKhuVuc.Controls.Add(this.btnSuaKhuVuc);
            this.grpChiTietKhuVuc.Controls.Add(this.btnThemKhuVuc);
            this.grpChiTietKhuVuc.Controls.Add(this.chkTrangThaiKhuVuc);
            this.grpChiTietKhuVuc.Controls.Add(this.txtTenKhuVuc);
            this.grpChiTietKhuVuc.Controls.Add(this.lblTenKhuVuc);
            this.grpChiTietKhuVuc.Controls.Add(this.txtMaKV);
            this.grpChiTietKhuVuc.Controls.Add(this.lblMaKV);
            this.grpChiTietKhuVuc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpChiTietKhuVuc.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpChiTietKhuVuc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.grpChiTietKhuVuc.Location = new System.Drawing.Point(0, 0);
            this.grpChiTietKhuVuc.Name = "grpChiTietKhuVuc";
            this.grpChiTietKhuVuc.Size = new System.Drawing.Size(370, 527);
            this.grpChiTietKhuVuc.TabIndex = 0;
            this.grpChiTietKhuVuc.TabStop = false;
            this.grpChiTietKhuVuc.Text = "Thông tin khu vực";
            // 
            // btnLamMoiKhuVuc
            // 
            this.btnLamMoiKhuVuc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnLamMoiKhuVuc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLamMoiKhuVuc.FlatAppearance.BorderSize = 0;
            this.btnLamMoiKhuVuc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoiKhuVuc.ForeColor = System.Drawing.Color.White;
            this.btnLamMoiKhuVuc.Location = new System.Drawing.Point(185, 290);
            this.btnLamMoiKhuVuc.Name = "btnLamMoiKhuVuc";
            this.btnLamMoiKhuVuc.Size = new System.Drawing.Size(155, 40);
            this.btnLamMoiKhuVuc.TabIndex = 8;
            this.btnLamMoiKhuVuc.Text = "🔄 Làm mới";
            this.btnLamMoiKhuVuc.UseVisualStyleBackColor = false;
            // 
            // btnLuuKhuVuc
            // 
            this.btnLuuKhuVuc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnLuuKhuVuc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLuuKhuVuc.FlatAppearance.BorderSize = 0;
            this.btnLuuKhuVuc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuuKhuVuc.ForeColor = System.Drawing.Color.White;
            this.btnLuuKhuVuc.Location = new System.Drawing.Point(20, 290);
            this.btnLuuKhuVuc.Name = "btnLuuKhuVuc";
            this.btnLuuKhuVuc.Size = new System.Drawing.Size(155, 40);
            this.btnLuuKhuVuc.TabIndex = 7;
            this.btnLuuKhuVuc.Text = "💾 Lưu";
            this.btnLuuKhuVuc.UseVisualStyleBackColor = false;
            // 
            // btnSuaKhuVuc
            // 
            this.btnSuaKhuVuc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(196)))), ((int)(((byte)(15)))));
            this.btnSuaKhuVuc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSuaKhuVuc.FlatAppearance.BorderSize = 0;
            this.btnSuaKhuVuc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuaKhuVuc.ForeColor = System.Drawing.Color.White;
            this.btnSuaKhuVuc.Location = new System.Drawing.Point(185, 235);
            this.btnSuaKhuVuc.Name = "btnSuaKhuVuc";
            this.btnSuaKhuVuc.Size = new System.Drawing.Size(155, 40);
            this.btnSuaKhuVuc.TabIndex = 6;
            this.btnSuaKhuVuc.Text = "✏️ Sửa";
            this.btnSuaKhuVuc.UseVisualStyleBackColor = false;
            // 
            // btnThemKhuVuc
            // 
            this.btnThemKhuVuc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnThemKhuVuc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThemKhuVuc.FlatAppearance.BorderSize = 0;
            this.btnThemKhuVuc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemKhuVuc.ForeColor = System.Drawing.Color.White;
            this.btnThemKhuVuc.Location = new System.Drawing.Point(20, 235);
            this.btnThemKhuVuc.Name = "btnThemKhuVuc";
            this.btnThemKhuVuc.Size = new System.Drawing.Size(155, 40);
            this.btnThemKhuVuc.TabIndex = 5;
            this.btnThemKhuVuc.Text = "➕ Thêm mới";
            this.btnThemKhuVuc.UseVisualStyleBackColor = false;
            // 
            // chkTrangThaiKhuVuc
            // 
            this.chkTrangThaiKhuVuc.AutoSize = true;
            this.chkTrangThaiKhuVuc.Checked = true;
            this.chkTrangThaiKhuVuc.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTrangThaiKhuVuc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkTrangThaiKhuVuc.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTrangThaiKhuVuc.Location = new System.Drawing.Point(20, 180);
            this.chkTrangThaiKhuVuc.Name = "chkTrangThaiKhuVuc";
            this.chkTrangThaiKhuVuc.Size = new System.Drawing.Size(139, 25);
            this.chkTrangThaiKhuVuc.TabIndex = 4;
            this.chkTrangThaiKhuVuc.Text = "Đang sử dụng";
            this.chkTrangThaiKhuVuc.UseVisualStyleBackColor = true;
            // 
            // txtTenKhuVuc
            // 
            this.txtTenKhuVuc.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenKhuVuc.Location = new System.Drawing.Point(20, 135);
            this.txtTenKhuVuc.Name = "txtTenKhuVuc";
            this.txtTenKhuVuc.Size = new System.Drawing.Size(320, 30);
            this.txtTenKhuVuc.TabIndex = 3;
            // 
            // lblTenKhuVuc
            // 
            this.lblTenKhuVuc.AutoSize = true;
            this.lblTenKhuVuc.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenKhuVuc.Location = new System.Drawing.Point(20, 110);
            this.lblTenKhuVuc.Name = "lblTenKhuVuc";
            this.lblTenKhuVuc.Size = new System.Drawing.Size(107, 21);
            this.lblTenKhuVuc.TabIndex = 2;
            this.lblTenKhuVuc.Text = "Tên khu vực:";
            // 
            // txtMaKV
            // 
            this.txtMaKV.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaKV.Location = new System.Drawing.Point(20, 65);
            this.txtMaKV.Name = "txtMaKV";
            this.txtMaKV.ReadOnly = true;
            this.txtMaKV.Size = new System.Drawing.Size(320, 30);
            this.txtMaKV.TabIndex = 1;
            // 
            // lblMaKV
            // 
            this.lblMaKV.AutoSize = true;
            this.lblMaKV.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaKV.Location = new System.Drawing.Point(20, 40);
            this.lblMaKV.Name = "lblMaKV";
            this.lblMaKV.Size = new System.Drawing.Size(104, 21);
            this.lblMaKV.TabIndex = 0;
            this.lblMaKV.Text = "Mã khu vực:";
            // 
            // tabBan
            // 
            this.tabBan.Controls.Add(this.pnlBanContent);
            this.tabBan.Controls.Add(this.pnlBanSearch);
            this.tabBan.Controls.Add(this.pnlBanInput);
            this.tabBan.Location = new System.Drawing.Point(4, 39);
            this.tabBan.Name = "tabBan";
            this.tabBan.Padding = new System.Windows.Forms.Padding(10);
            this.tabBan.Size = new System.Drawing.Size(1092, 547);
            this.tabBan.TabIndex = 1;
            this.tabBan.Text = "🪑 Bàn";
            this.tabBan.UseVisualStyleBackColor = true;
            // 
            // pnlBanContent
            // 
            this.pnlBanContent.Controls.Add(this.dgvBan);
            this.pnlBanContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBanContent.Location = new System.Drawing.Point(400, 65);
            this.pnlBanContent.Name = "pnlBanContent";
            this.pnlBanContent.Size = new System.Drawing.Size(682, 472);
            this.pnlBanContent.TabIndex = 2;
            // 
            // dgvBan
            // 
            this.dgvBan.AllowUserToAddRows = false;
            this.dgvBan.AllowUserToDeleteRows = false;
            this.dgvBan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBan.BackgroundColor = System.Drawing.Color.White;
            this.dgvBan.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvBan.ColumnHeadersHeight = 35;
            this.dgvBan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaBan,
            this.colTenBan,
            this.colTenKhuVucBan,
            this.colTrangThaiBan,
            this.colDangSuDungText});
            this.dgvBan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBan.EnableHeadersVisualStyles = false;
            this.dgvBan.Location = new System.Drawing.Point(0, 0);
            this.dgvBan.MultiSelect = false;
            this.dgvBan.Name = "dgvBan";
            this.dgvBan.ReadOnly = true;
            this.dgvBan.RowHeadersVisible = false;
            this.dgvBan.RowHeadersWidth = 51;
            this.dgvBan.RowTemplate.Height = 30;
            this.dgvBan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBan.Size = new System.Drawing.Size(682, 472);
            this.dgvBan.TabIndex = 0;
            // 
            // colMaBan
            // 
            this.colMaBan.DataPropertyName = "MaBan";
            this.colMaBan.HeaderText = "Mã bàn";
            this.colMaBan.FillWeight = 30F;
            this.colMaBan.Name = "colMaBan";
            this.colMaBan.ReadOnly = true;
            // 
            // colTenBan
            // 
            this.colTenBan.DataPropertyName = "TenBan";
            this.colTenBan.HeaderText = "Tên bàn";
            this.colTenBan.FillWeight = 100F;
            this.colTenBan.Name = "colTenBan";
            this.colTenBan.ReadOnly = true;
            // 
            // colTenKhuVucBan
            // 
            this.colTenKhuVucBan.DataPropertyName = "TenKhuVuc";
            this.colTenKhuVucBan.HeaderText = "Khu vực";
            this.colTenKhuVucBan.FillWeight = 80F;
            this.colTenKhuVucBan.Name = "colTenKhuVucBan";
            this.colTenKhuVucBan.ReadOnly = true;
            // 
            // colTrangThaiBan
            // 
            this.colTrangThaiBan.DataPropertyName = "TrangThai";
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colTrangThaiBan.DefaultCellStyle = dataGridViewCellStyle3;
            this.colTrangThaiBan.HeaderText = "Trạng thái";
            this.colTrangThaiBan.FillWeight = 60F;
            this.colTrangThaiBan.Name = "colTrangThaiBan";
            this.colTrangThaiBan.ReadOnly = true;
            // 
            // colDangSuDungText
            // 
            this.colDangSuDungText.DataPropertyName = "DangSuDungText";
            this.colDangSuDungText.HeaderText = "Sử dụng";
            this.colDangSuDungText.FillWeight = 50F;
            this.colDangSuDungText.Name = "colDangSuDungText";
            this.colDangSuDungText.ReadOnly = true;
            // 
            // pnlBanSearch
            // 
            this.pnlBanSearch.Controls.Add(this.btnTimKiemBan);
            this.pnlBanSearch.Controls.Add(this.txtTimKiemBan);
            this.pnlBanSearch.Controls.Add(this.lblTimKiemBan);
            this.pnlBanSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBanSearch.Location = new System.Drawing.Point(400, 10);
            this.pnlBanSearch.Name = "pnlBanSearch";
            this.pnlBanSearch.Size = new System.Drawing.Size(682, 55);
            this.pnlBanSearch.TabIndex = 1;
            // 
            // btnTimKiemBan
            // 
            this.btnTimKiemBan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnTimKiemBan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTimKiemBan.FlatAppearance.BorderSize = 0;
            this.btnTimKiemBan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiemBan.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiemBan.ForeColor = System.Drawing.Color.White;
            this.btnTimKiemBan.Location = new System.Drawing.Point(435, 10);
            this.btnTimKiemBan.Name = "btnTimKiemBan";
            this.btnTimKiemBan.Size = new System.Drawing.Size(120, 32);
            this.btnTimKiemBan.TabIndex = 2;
            this.btnTimKiemBan.Text = "🔍 Tìm kiếm";
            this.btnTimKiemBan.UseVisualStyleBackColor = false;
            // 
            // txtTimKiemBan
            // 
            this.txtTimKiemBan.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimKiemBan.Location = new System.Drawing.Point(125, 12);
            this.txtTimKiemBan.Name = "txtTimKiemBan";
            this.txtTimKiemBan.Size = new System.Drawing.Size(300, 29);
            this.txtTimKiemBan.TabIndex = 1;
            // 
            // lblTimKiemBan
            // 
            this.lblTimKiemBan.AutoSize = true;
            this.lblTimKiemBan.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimKiemBan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblTimKiemBan.Location = new System.Drawing.Point(10, 15);
            this.lblTimKiemBan.Name = "lblTimKiemBan";
            this.lblTimKiemBan.Size = new System.Drawing.Size(107, 21);
            this.lblTimKiemBan.TabIndex = 0;
            this.lblTimKiemBan.Text = "Tìm tên bàn:";
            // 
            // pnlBanInput
            // 
            this.pnlBanInput.Controls.Add(this.grpChiTietBan);
            this.pnlBanInput.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlBanInput.Location = new System.Drawing.Point(10, 10);
            this.pnlBanInput.Name = "pnlBanInput";
            this.pnlBanInput.Size = new System.Drawing.Size(390, 527);
            this.pnlBanInput.TabIndex = 0;
            // 
            // grpChiTietBan
            // 
            this.grpChiTietBan.Controls.Add(this.lblTrangThaiBanWarning);
            this.grpChiTietBan.Controls.Add(this.btnLamMoiBan);
            this.grpChiTietBan.Controls.Add(this.btnLuuBan);
            this.grpChiTietBan.Controls.Add(this.btnSuaBan);
            this.grpChiTietBan.Controls.Add(this.btnThemBan);
            this.grpChiTietBan.Controls.Add(this.chkDangSuDungBan);
            this.grpChiTietBan.Controls.Add(this.cboTrangThaiDatBan);
            this.grpChiTietBan.Controls.Add(this.lblTrangThaiDatBan);
            this.grpChiTietBan.Controls.Add(this.cboKhuVucBan);
            this.grpChiTietBan.Controls.Add(this.lblKhuVucBan);
            this.grpChiTietBan.Controls.Add(this.txtTenBan);
            this.grpChiTietBan.Controls.Add(this.lblTenBan);
            this.grpChiTietBan.Controls.Add(this.txtMaBan);
            this.grpChiTietBan.Controls.Add(this.lblMaBan);
            this.grpChiTietBan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpChiTietBan.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpChiTietBan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.grpChiTietBan.Location = new System.Drawing.Point(0, 0);
            this.grpChiTietBan.Name = "grpChiTietBan";
            this.grpChiTietBan.Size = new System.Drawing.Size(390, 527);
            this.grpChiTietBan.TabIndex = 0;
            this.grpChiTietBan.TabStop = false;
            this.grpChiTietBan.Text = "Thông tin bàn";
            // 
            // lblTrangThaiBanWarning
            // 
            this.lblTrangThaiBanWarning.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrangThaiBanWarning.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.lblTrangThaiBanWarning.Location = new System.Drawing.Point(20, 345);
            this.lblTrangThaiBanWarning.Name = "lblTrangThaiBanWarning";
            this.lblTrangThaiBanWarning.Size = new System.Drawing.Size(340, 50);
            this.lblTrangThaiBanWarning.TabIndex = 13;
            this.lblTrangThaiBanWarning.Text = "⚠️ Bàn đang có khách! Không thể đổi trạng thái hoặc khóa bàn.";
            this.lblTrangThaiBanWarning.Visible = false;
            // 
            // btnLamMoiBan
            // 
            this.btnLamMoiBan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnLamMoiBan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLamMoiBan.FlatAppearance.BorderSize = 0;
            this.btnLamMoiBan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoiBan.ForeColor = System.Drawing.Color.White;
            this.btnLamMoiBan.Location = new System.Drawing.Point(195, 465);
            this.btnLamMoiBan.Name = "btnLamMoiBan";
            this.btnLamMoiBan.Size = new System.Drawing.Size(165, 40);
            this.btnLamMoiBan.TabIndex = 12;
            this.btnLamMoiBan.Text = "🔄 Làm mới";
            this.btnLamMoiBan.UseVisualStyleBackColor = false;
            // 
            // btnLuuBan
            // 
            this.btnLuuBan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnLuuBan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLuuBan.FlatAppearance.BorderSize = 0;
            this.btnLuuBan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuuBan.ForeColor = System.Drawing.Color.White;
            this.btnLuuBan.Location = new System.Drawing.Point(20, 465);
            this.btnLuuBan.Name = "btnLuuBan";
            this.btnLuuBan.Size = new System.Drawing.Size(165, 40);
            this.btnLuuBan.TabIndex = 11;
            this.btnLuuBan.Text = "💾 Lưu";
            this.btnLuuBan.UseVisualStyleBackColor = false;
            // 
            // btnSuaBan
            // 
            this.btnSuaBan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(196)))), ((int)(((byte)(15)))));
            this.btnSuaBan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSuaBan.FlatAppearance.BorderSize = 0;
            this.btnSuaBan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuaBan.ForeColor = System.Drawing.Color.White;
            this.btnSuaBan.Location = new System.Drawing.Point(195, 415);
            this.btnSuaBan.Name = "btnSuaBan";
            this.btnSuaBan.Size = new System.Drawing.Size(165, 40);
            this.btnSuaBan.TabIndex = 10;
            this.btnSuaBan.Text = "✏️ Sửa";
            this.btnSuaBan.UseVisualStyleBackColor = false;
            // 
            // btnThemBan
            // 
            this.btnThemBan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnThemBan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThemBan.FlatAppearance.BorderSize = 0;
            this.btnThemBan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemBan.ForeColor = System.Drawing.Color.White;
            this.btnThemBan.Location = new System.Drawing.Point(20, 415);
            this.btnThemBan.Name = "btnThemBan";
            this.btnThemBan.Size = new System.Drawing.Size(165, 40);
            this.btnThemBan.TabIndex = 9;
            this.btnThemBan.Text = "➕ Thêm mới";
            this.btnThemBan.UseVisualStyleBackColor = false;
            // 
            // chkDangSuDungBan
            // 
            this.chkDangSuDungBan.AutoSize = true;
            this.chkDangSuDungBan.Checked = true;
            this.chkDangSuDungBan.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDangSuDungBan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkDangSuDungBan.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDangSuDungBan.Location = new System.Drawing.Point(20, 310);
            this.chkDangSuDungBan.Name = "chkDangSuDungBan";
            this.chkDangSuDungBan.Size = new System.Drawing.Size(139, 25);
            this.chkDangSuDungBan.TabIndex = 8;
            this.chkDangSuDungBan.Text = "Đang sử dụng";
            this.chkDangSuDungBan.UseVisualStyleBackColor = true;
            // 
            // cboTrangThaiDatBan
            // 
            this.cboTrangThaiDatBan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTrangThaiDatBan.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTrangThaiDatBan.FormattingEnabled = true;
            this.cboTrangThaiDatBan.Items.AddRange(new object[] {
            "Trống",
            "Đặt trước"});
            this.cboTrangThaiDatBan.Location = new System.Drawing.Point(20, 260);
            this.cboTrangThaiDatBan.Name = "cboTrangThaiDatBan";
            this.cboTrangThaiDatBan.Size = new System.Drawing.Size(340, 31);
            this.cboTrangThaiDatBan.TabIndex = 7;
            // 
            // lblTrangThaiDatBan
            // 
            this.lblTrangThaiDatBan.AutoSize = true;
            this.lblTrangThaiDatBan.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrangThaiDatBan.Location = new System.Drawing.Point(20, 235);
            this.lblTrangThaiDatBan.Name = "lblTrangThaiDatBan";
            this.lblTrangThaiDatBan.Size = new System.Drawing.Size(92, 21);
            this.lblTrangThaiDatBan.TabIndex = 6;
            this.lblTrangThaiDatBan.Text = "Trạng thái:";
            // 
            // cboKhuVucBan
            // 
            this.cboKhuVucBan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKhuVucBan.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboKhuVucBan.FormattingEnabled = true;
            this.cboKhuVucBan.Location = new System.Drawing.Point(20, 195);
            this.cboKhuVucBan.Name = "cboKhuVucBan";
            this.cboKhuVucBan.Size = new System.Drawing.Size(340, 31);
            this.cboKhuVucBan.TabIndex = 5;
            // 
            // lblKhuVucBan
            // 
            this.lblKhuVucBan.AutoSize = true;
            this.lblKhuVucBan.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKhuVucBan.Location = new System.Drawing.Point(20, 170);
            this.lblKhuVucBan.Name = "lblKhuVucBan";
            this.lblKhuVucBan.Size = new System.Drawing.Size(76, 21);
            this.lblKhuVucBan.TabIndex = 4;
            this.lblKhuVucBan.Text = "Khu vực:";
            // 
            // txtTenBan
            // 
            this.txtTenBan.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenBan.Location = new System.Drawing.Point(20, 130);
            this.txtTenBan.Name = "txtTenBan";
            this.txtTenBan.Size = new System.Drawing.Size(340, 30);
            this.txtTenBan.TabIndex = 3;
            // 
            // lblTenBan
            // 
            this.lblTenBan.AutoSize = true;
            this.lblTenBan.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenBan.Location = new System.Drawing.Point(20, 105);
            this.lblTenBan.Name = "lblTenBan";
            this.lblTenBan.Size = new System.Drawing.Size(75, 21);
            this.lblTenBan.TabIndex = 2;
            this.lblTenBan.Text = "Tên bàn:";
            // 
            // txtMaBan
            // 
            this.txtMaBan.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaBan.Location = new System.Drawing.Point(20, 65);
            this.txtMaBan.Name = "txtMaBan";
            this.txtMaBan.ReadOnly = true;
            this.txtMaBan.Size = new System.Drawing.Size(340, 30);
            this.txtMaBan.TabIndex = 1;
            // 
            // lblMaBan
            // 
            this.lblMaBan.AutoSize = true;
            this.lblMaBan.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaBan.Location = new System.Drawing.Point(20, 40);
            this.lblMaBan.Name = "lblMaBan";
            this.lblMaBan.Size = new System.Drawing.Size(72, 21);
            this.lblMaBan.TabIndex = 0;
            this.lblMaBan.Text = "Mã bàn:";
            // 
            // FrmQuanLyKhuVucBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1100, 650);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.pnlHeader);
            this.Name = "FrmQuanLyKhuVucBan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý Khu vực và Bàn - Quản lý quán café";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.tabMain.ResumeLayout(false);
            this.tabKhuVuc.ResumeLayout(false);
            this.pnlKhuVucContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhuVuc)).EndInit();
            this.pnlKhuVucInput.ResumeLayout(false);
            this.grpChiTietKhuVuc.ResumeLayout(false);
            this.grpChiTietKhuVuc.PerformLayout();
            this.tabBan.ResumeLayout(false);
            this.pnlBanContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBan)).EndInit();
            this.pnlBanSearch.ResumeLayout(false);
            this.pnlBanSearch.PerformLayout();
            this.pnlBanInput.ResumeLayout(false);
            this.grpChiTietBan.ResumeLayout(false);
            this.grpChiTietBan.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabKhuVuc;
        private System.Windows.Forms.Panel pnlKhuVucContent;
        private System.Windows.Forms.DataGridView dgvKhuVuc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaKV;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenKhuVuc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTrangThaiKhuVucText;
        private System.Windows.Forms.Panel pnlKhuVucInput;
        private System.Windows.Forms.GroupBox grpChiTietKhuVuc;
        private System.Windows.Forms.Label lblMaKV;
        private System.Windows.Forms.TextBox txtMaKV;
        private System.Windows.Forms.Label lblTenKhuVuc;
        private System.Windows.Forms.TextBox txtTenKhuVuc;
        private System.Windows.Forms.CheckBox chkTrangThaiKhuVuc;
        private System.Windows.Forms.Button btnThemKhuVuc;
        private System.Windows.Forms.Button btnSuaKhuVuc;
        private System.Windows.Forms.Button btnLuuKhuVuc;
        private System.Windows.Forms.Button btnLamMoiKhuVuc;
        private System.Windows.Forms.TabPage tabBan;
        private System.Windows.Forms.Panel pnlBanContent;
        private System.Windows.Forms.DataGridView dgvBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenKhuVucBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTrangThaiBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDangSuDungText;
        private System.Windows.Forms.Panel pnlBanSearch;
        private System.Windows.Forms.Label lblTimKiemBan;
        private System.Windows.Forms.TextBox txtTimKiemBan;
        private System.Windows.Forms.Button btnTimKiemBan;
        private System.Windows.Forms.Panel pnlBanInput;
        private System.Windows.Forms.GroupBox grpChiTietBan;
        private System.Windows.Forms.Label lblMaBan;
        private System.Windows.Forms.TextBox txtMaBan;
        private System.Windows.Forms.Label lblTenBan;
        private System.Windows.Forms.TextBox txtTenBan;
        private System.Windows.Forms.Label lblKhuVucBan;
        private System.Windows.Forms.ComboBox cboKhuVucBan;
        private System.Windows.Forms.Label lblTrangThaiDatBan;
        private System.Windows.Forms.ComboBox cboTrangThaiDatBan;
        private System.Windows.Forms.CheckBox chkDangSuDungBan;
        private System.Windows.Forms.Label lblTrangThaiBanWarning;
        private System.Windows.Forms.Button btnThemBan;
        private System.Windows.Forms.Button btnSuaBan;
        private System.Windows.Forms.Button btnLuuBan;
        private System.Windows.Forms.Button btnLamMoiBan;
    }
}
