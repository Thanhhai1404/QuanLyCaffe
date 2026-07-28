namespace QLCF.Forms
{
    partial class FrmThongKe
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
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.btnXemThongKe = new System.Windows.Forms.Button();
            this.dtpDenNgay = new System.Windows.Forms.DateTimePicker();
            this.lblDenNgay = new System.Windows.Forms.Label();
            this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
            this.lblTuNgay = new System.Windows.Forms.Label();
            this.pnlCards = new System.Windows.Forms.Panel();
            this.pnlCardDoanhThu = new System.Windows.Forms.Panel();
            this.lblDoanhThuVal = new System.Windows.Forms.Label();
            this.lblDoanhThuTitle = new System.Windows.Forms.Label();
            this.pnlCardSoHoaDon = new System.Windows.Forms.Panel();
            this.lblSoHoaDonVal = new System.Windows.Forms.Label();
            this.lblSoHoaDonTitle = new System.Windows.Forms.Label();
            this.pnlCardTongMon = new System.Windows.Forms.Panel();
            this.lblTongMonVal = new System.Windows.Forms.Label();
            this.lblTongMonTitle = new System.Windows.Forms.Label();
            this.grpTopMon = new System.Windows.Forms.GroupBox();
            this.dgvTopMon = new System.Windows.Forms.DataGridView();
            this.colTenMon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTongSoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDoanhThu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDong = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.pnlCards.SuspendLayout();
            this.pnlCardDoanhThu.SuspendLayout();
            this.pnlCardSoHoaDon.SuspendLayout();
            this.pnlCardTongMon.SuspendLayout();
            this.grpTopMon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopMon)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.pnlHeader.Controls.Add(this.lblTieuDe);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(950, 60);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTieuDe.ForeColor = System.Drawing.Color.White;
            this.lblTieuDe.Location = new System.Drawing.Point(20, 15);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(375, 32);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "📊 THỐNG KÊ & DASHBOARD ADMIN";
            // 
            // pnlFilter
            // 
            this.pnlFilter.BackColor = System.Drawing.Color.White;
            this.pnlFilter.Controls.Add(this.btnDong);
            this.pnlFilter.Controls.Add(this.btnXuatExcel);
            this.pnlFilter.Controls.Add(this.btnXemThongKe);
            this.pnlFilter.Controls.Add(this.dtpDenNgay);
            this.pnlFilter.Controls.Add(this.lblDenNgay);
            this.pnlFilter.Controls.Add(this.dtpTuNgay);
            this.pnlFilter.Controls.Add(this.lblTuNgay);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 60);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(950, 65);
            this.pnlFilter.TabIndex = 1;
            // 
            // btnXemThongKe
            // 
            this.btnXemThongKe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnXemThongKe.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXemThongKe.FlatAppearance.BorderSize = 0;
            this.btnXemThongKe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXemThongKe.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXemThongKe.ForeColor = System.Drawing.Color.White;
            this.btnXemThongKe.Location = new System.Drawing.Point(525, 15);
            this.btnXemThongKe.Name = "btnXemThongKe";
            this.btnXemThongKe.Size = new System.Drawing.Size(135, 35);
            this.btnXemThongKe.TabIndex = 4;
            this.btnXemThongKe.Text = "🔍 Xem thống kê";
            this.btnXemThongKe.UseVisualStyleBackColor = false;
            // 
            // btnXuatExcel
            // 
            this.btnXuatExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.btnXuatExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXuatExcel.FlatAppearance.BorderSize = 0;
            this.btnXuatExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXuatExcel.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXuatExcel.ForeColor = System.Drawing.Color.White;
            this.btnXuatExcel.Location = new System.Drawing.Point(670, 15);
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(140, 35);
            this.btnXuatExcel.TabIndex = 6;
            this.btnXuatExcel.Text = "📊 Xuất Excel";
            this.btnXuatExcel.UseVisualStyleBackColor = false;
            this.btnXuatExcel.Click += new System.EventHandler(this.btnXuatExcel_Click);
            // 
            // dtpDenNgay
            // 
            this.dtpDenNgay.CustomFormat = "dd/MM/yyyy";
            this.dtpDenNgay.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDenNgay.Location = new System.Drawing.Point(365, 18);
            this.dtpDenNgay.Name = "dtpDenNgay";
            this.dtpDenNgay.Size = new System.Drawing.Size(150, 29);
            this.dtpDenNgay.TabIndex = 3;
            // 
            // lblDenNgay
            // 
            this.lblDenNgay.AutoSize = true;
            this.lblDenNgay.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDenNgay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblDenNgay.Location = new System.Drawing.Point(275, 22);
            this.lblDenNgay.Name = "lblDenNgay";
            this.lblDenNgay.Size = new System.Drawing.Size(86, 21);
            this.lblDenNgay.TabIndex = 2;
            this.lblDenNgay.Text = "Đến ngày:";
            // 
            // dtpTuNgay
            // 
            this.dtpTuNgay.CustomFormat = "dd/MM/yyyy";
            this.dtpTuNgay.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTuNgay.Location = new System.Drawing.Point(100, 18);
            this.dtpTuNgay.Name = "dtpTuNgay";
            this.dtpTuNgay.Size = new System.Drawing.Size(150, 29);
            this.dtpTuNgay.TabIndex = 1;
            // 
            // lblTuNgay
            // 
            this.lblTuNgay.AutoSize = true;
            this.lblTuNgay.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTuNgay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblTuNgay.Location = new System.Drawing.Point(20, 22);
            this.lblTuNgay.Name = "lblTuNgay";
            this.lblTuNgay.Size = new System.Drawing.Size(76, 21);
            this.lblTuNgay.TabIndex = 0;
            this.lblTuNgay.Text = "Từ ngày:";
            // 
            // pnlCards
            // 
            this.pnlCards.Controls.Add(this.pnlCardTongMon);
            this.pnlCards.Controls.Add(this.pnlCardSoHoaDon);
            this.pnlCards.Controls.Add(this.pnlCardDoanhThu);
            this.pnlCards.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCards.Location = new System.Drawing.Point(0, 125);
            this.pnlCards.Name = "pnlCards";
            this.pnlCards.Padding = new System.Windows.Forms.Padding(20, 15, 20, 15);
            this.pnlCards.Size = new System.Drawing.Size(950, 120);
            this.pnlCards.TabIndex = 2;
            // 
            // pnlCardDoanhThu
            // 
            this.pnlCardDoanhThu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.pnlCardDoanhThu.Controls.Add(this.lblDoanhThuVal);
            this.pnlCardDoanhThu.Controls.Add(this.lblDoanhThuTitle);
            this.pnlCardDoanhThu.Location = new System.Drawing.Point(20, 15);
            this.pnlCardDoanhThu.Name = "pnlCardDoanhThu";
            this.pnlCardDoanhThu.Size = new System.Drawing.Size(280, 90);
            this.pnlCardDoanhThu.TabIndex = 0;
            // 
            // lblDoanhThuVal
            // 
            this.lblDoanhThuVal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDoanhThuVal.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDoanhThuVal.ForeColor = System.Drawing.Color.White;
            this.lblDoanhThuVal.Location = new System.Drawing.Point(0, 35);
            this.lblDoanhThuVal.Name = "lblDoanhThuVal";
            this.lblDoanhThuVal.Size = new System.Drawing.Size(280, 55);
            this.lblDoanhThuVal.TabIndex = 1;
            this.lblDoanhThuVal.Text = "0 đ";
            this.lblDoanhThuVal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDoanhThuTitle
            // 
            this.lblDoanhThuTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDoanhThuTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDoanhThuTitle.ForeColor = System.Drawing.Color.White;
            this.lblDoanhThuTitle.Location = new System.Drawing.Point(0, 0);
            this.lblDoanhThuTitle.Name = "lblDoanhThuTitle";
            this.lblDoanhThuTitle.Size = new System.Drawing.Size(280, 35);
            this.lblDoanhThuTitle.TabIndex = 0;
            this.lblDoanhThuTitle.Text = "💵 TỔNG DOANH THU";
            this.lblDoanhThuTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlCardSoHoaDon
            // 
            this.pnlCardSoHoaDon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.pnlCardSoHoaDon.Controls.Add(this.lblSoHoaDonVal);
            this.pnlCardSoHoaDon.Controls.Add(this.lblSoHoaDonTitle);
            this.pnlCardSoHoaDon.Location = new System.Drawing.Point(335, 15);
            this.pnlCardSoHoaDon.Name = "pnlCardSoHoaDon";
            this.pnlCardSoHoaDon.Size = new System.Drawing.Size(280, 90);
            this.pnlCardSoHoaDon.TabIndex = 1;
            // 
            // lblSoHoaDonVal
            // 
            this.lblSoHoaDonVal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSoHoaDonVal.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoHoaDonVal.ForeColor = System.Drawing.Color.White;
            this.lblSoHoaDonVal.Location = new System.Drawing.Point(0, 35);
            this.lblSoHoaDonVal.Name = "lblSoHoaDonVal";
            this.lblSoHoaDonVal.Size = new System.Drawing.Size(280, 55);
            this.lblSoHoaDonVal.TabIndex = 1;
            this.lblSoHoaDonVal.Text = "0";
            this.lblSoHoaDonVal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSoHoaDonTitle
            // 
            this.lblSoHoaDonTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSoHoaDonTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoHoaDonTitle.ForeColor = System.Drawing.Color.White;
            this.lblSoHoaDonTitle.Location = new System.Drawing.Point(0, 0);
            this.lblSoHoaDonTitle.Name = "lblSoHoaDonTitle";
            this.lblSoHoaDonTitle.Size = new System.Drawing.Size(280, 35);
            this.lblSoHoaDonTitle.TabIndex = 0;
            this.lblSoHoaDonTitle.Text = "🧾 SỐ HÓA ĐƠN";
            this.lblSoHoaDonTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlCardTongMon
            // 
            this.pnlCardTongMon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.pnlCardTongMon.Controls.Add(this.lblTongMonVal);
            this.pnlCardTongMon.Controls.Add(this.lblTongMonTitle);
            this.pnlCardTongMon.Location = new System.Drawing.Point(650, 15);
            this.pnlCardTongMon.Name = "pnlCardTongMon";
            this.pnlCardTongMon.Size = new System.Drawing.Size(280, 90);
            this.pnlCardTongMon.TabIndex = 2;
            // 
            // lblTongMonVal
            // 
            this.lblTongMonVal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTongMonVal.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongMonVal.ForeColor = System.Drawing.Color.White;
            this.lblTongMonVal.Location = new System.Drawing.Point(0, 35);
            this.lblTongMonVal.Name = "lblTongMonVal";
            this.lblTongMonVal.Size = new System.Drawing.Size(280, 55);
            this.lblTongMonVal.TabIndex = 1;
            this.lblTongMonVal.Text = "0";
            this.lblTongMonVal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTongMonTitle
            // 
            this.lblTongMonTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTongMonTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongMonTitle.ForeColor = System.Drawing.Color.White;
            this.lblTongMonTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTongMonTitle.Name = "lblTongMonTitle";
            this.lblTongMonTitle.Size = new System.Drawing.Size(280, 35);
            this.lblTongMonTitle.TabIndex = 0;
            this.lblTongMonTitle.Text = "☕ TỔNG MÓN ĐÃ BÁN";
            this.lblTongMonTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grpTopMon
            // 
            this.grpTopMon.Controls.Add(this.dgvTopMon);
            this.grpTopMon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpTopMon.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpTopMon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.grpTopMon.Location = new System.Drawing.Point(0, 245);
            this.grpTopMon.Name = "grpTopMon";
            this.grpTopMon.Padding = new System.Windows.Forms.Padding(15);
            this.grpTopMon.Size = new System.Drawing.Size(950, 355);
            this.grpTopMon.TabIndex = 3;
            this.grpTopMon.TabStop = false;
            this.grpTopMon.Text = "🏆 TOP 5 MÓN BÁN CHẠY NHẤT";
            // 
            // dgvTopMon
            // 
            this.dgvTopMon.AllowUserToAddRows = false;
            this.dgvTopMon.AllowUserToDeleteRows = false;
            this.dgvTopMon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTopMon.BackgroundColor = System.Drawing.Color.White;
            this.dgvTopMon.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTopMon.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTopMon.ColumnHeadersHeight = 35;
            this.dgvTopMon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTenMon,
            this.colTongSoLuong,
            this.colDoanhThu});
            this.dgvTopMon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTopMon.EnableHeadersVisualStyles = false;
            this.dgvTopMon.Location = new System.Drawing.Point(15, 38);
            this.dgvTopMon.MultiSelect = false;
            this.dgvTopMon.Name = "dgvTopMon";
            this.dgvTopMon.ReadOnly = true;
            this.dgvTopMon.RowHeadersVisible = false;
            this.dgvTopMon.RowHeadersWidth = 51;
            this.dgvTopMon.RowTemplate.Height = 30;
            this.dgvTopMon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTopMon.Size = new System.Drawing.Size(920, 302);
            this.dgvTopMon.TabIndex = 0;
            // 
            // colTenMon
            // 
            this.colTenMon.DataPropertyName = "TenMon";
            this.colTenMon.HeaderText = "Tên món ăn / Đồ uống";
            this.colTenMon.MinimumWidth = 6;
            this.colTenMon.Name = "colTenMon";
            this.colTenMon.ReadOnly = true;
            // 
            // colTongSoLuong
            // 
            this.colTongSoLuong.DataPropertyName = "TongSoLuong";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N0";
            this.colTongSoLuong.DefaultCellStyle = dataGridViewCellStyle2;
            this.colTongSoLuong.HeaderText = "Tổng số lượng đã bán";
            this.colTongSoLuong.MinimumWidth = 6;
            this.colTongSoLuong.Name = "colTongSoLuong";
            this.colTongSoLuong.ReadOnly = true;
            // 
            // colDoanhThu
            // 
            this.colDoanhThu.DataPropertyName = "DoanhThu";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N0";
            this.colDoanhThu.DefaultCellStyle = dataGridViewCellStyle3;
            this.colDoanhThu.HeaderText = "Doanh thu (VNĐ)";
            this.colDoanhThu.MinimumWidth = 6;
            this.colDoanhThu.Name = "colDoanhThu";
            this.colDoanhThu.ReadOnly = true;
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
            this.btnDong.Location = new System.Drawing.Point(830, 15);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(100, 35);
            this.btnDong.TabIndex = 5;
            this.btnDong.Text = "❌ Đóng";
            this.btnDong.UseVisualStyleBackColor = false;
            // 
            // FrmThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(950, 600);
            this.Controls.Add(this.grpTopMon);
            this.Controls.Add(this.pnlCards);
            this.Controls.Add(this.pnlFilter);
            this.Controls.Add(this.pnlHeader);
            this.Name = "FrmThongKe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo cáo thống kê - Quản lý quán café";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.pnlCards.ResumeLayout(false);
            this.pnlCardDoanhThu.ResumeLayout(false);
            this.pnlCardSoHoaDon.ResumeLayout(false);
            this.pnlCardTongMon.ResumeLayout(false);
            this.grpTopMon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopMon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.Label lblTuNgay;
        private System.Windows.Forms.DateTimePicker dtpTuNgay;
        private System.Windows.Forms.Label lblDenNgay;
        private System.Windows.Forms.DateTimePicker dtpDenNgay;
        private System.Windows.Forms.Button btnXemThongKe;
        private System.Windows.Forms.Button btnXuatExcel;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Panel pnlCards;
        private System.Windows.Forms.Panel pnlCardDoanhThu;
        private System.Windows.Forms.Label lblDoanhThuTitle;
        private System.Windows.Forms.Label lblDoanhThuVal;
        private System.Windows.Forms.Panel pnlCardSoHoaDon;
        private System.Windows.Forms.Label lblSoHoaDonTitle;
        private System.Windows.Forms.Label lblSoHoaDonVal;
        private System.Windows.Forms.Panel pnlCardTongMon;
        private System.Windows.Forms.Label lblTongMonTitle;
        private System.Windows.Forms.Label lblTongMonVal;
        private System.Windows.Forms.GroupBox grpTopMon;
        private System.Windows.Forms.DataGridView dgvTopMon;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenMon;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTongSoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDoanhThu;
    }
}
