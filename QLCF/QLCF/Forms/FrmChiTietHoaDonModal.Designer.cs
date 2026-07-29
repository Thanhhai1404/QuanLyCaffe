namespace QLCF.Forms
{
    partial class FrmChiTietHoaDonModal
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlTopHeader = new System.Windows.Forms.Panel();
            this.lblTrangThaiValue = new System.Windows.Forms.Label();
            this.lblThoiGianValue = new System.Windows.Forms.Label();
            this.lblThuNganValue = new System.Windows.Forms.Label();
            this.lblBanKhuVucValue = new System.Windows.Forms.Label();
            this.lblMaHDTitle = new System.Windows.Forms.Label();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.lblLyDoHuy = new System.Windows.Forms.Label();
            this.lblTongThanhToanVal = new System.Windows.Forms.Label();
            this.lblTongThanhToanTitle = new System.Windows.Forms.Label();
            this.lblGiamGiaVal = new System.Windows.Forms.Label();
            this.lblTongTienGocVal = new System.Windows.Forms.Label();
            this.lblGiamGiaTitle = new System.Windows.Forms.Label();
            this.lblTongTienGocTitle = new System.Windows.Forms.Label();
            this.btnInLaiBill = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.pnlGridContainer = new System.Windows.Forms.Panel();
            this.dgvChiTiet = new System.Windows.Forms.DataGridView();
            this.colStt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenMon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDonGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThanhTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlTopHeader.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlGridContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTopHeader
            // 
            this.pnlTopHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.pnlTopHeader.Controls.Add(this.lblTrangThaiValue);
            this.pnlTopHeader.Controls.Add(this.lblThoiGianValue);
            this.pnlTopHeader.Controls.Add(this.lblThuNganValue);
            this.pnlTopHeader.Controls.Add(this.lblBanKhuVucValue);
            this.pnlTopHeader.Controls.Add(this.lblMaHDTitle);
            this.pnlTopHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlTopHeader.Name = "pnlTopHeader";
            this.pnlTopHeader.Size = new System.Drawing.Size(684, 125);
            this.pnlTopHeader.TabIndex = 0;
            // 
            // lblTrangThaiValue
            // 
            this.lblTrangThaiValue.AutoSize = true;
            this.lblTrangThaiValue.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrangThaiValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.lblTrangThaiValue.Location = new System.Drawing.Point(18, 96);
            this.lblTrangThaiValue.Name = "lblTrangThaiValue";
            this.lblTrangThaiValue.Size = new System.Drawing.Size(262, 17);
            this.lblTrangThaiValue.TabIndex = 4;
            this.lblTrangThaiValue.Text = "Trạng thái: Đã thanh toán | PTTT: Tiền mặt";
            // 
            // lblThoiGianValue
            // 
            this.lblThoiGianValue.AutoSize = true;
            this.lblThoiGianValue.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThoiGianValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.lblThoiGianValue.Location = new System.Drawing.Point(18, 73);
            this.lblThoiGianValue.Name = "lblThoiGianValue";
            this.lblThoiGianValue.Size = new System.Drawing.Size(325, 17);
            this.lblThoiGianValue.TabIndex = 3;
            this.lblThoiGianValue.Text = "Giờ vào: 15/07/2026 14:00 - Giờ ra: 15/07/2026 14:35";
            // 
            // lblThuNganValue
            // 
            this.lblThuNganValue.AutoSize = true;
            this.lblThuNganValue.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThuNganValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.lblThuNganValue.Location = new System.Drawing.Point(18, 50);
            this.lblThuNganValue.Name = "lblThuNganValue";
            this.lblThuNganValue.Size = new System.Drawing.Size(367, 17);
            this.lblThuNganValue.TabIndex = 2;
            this.lblThuNganValue.Text = "Mở bàn: Nguyễn Văn A | Thanh toán: Nguyễn Văn A";
            // 
            // lblBanKhuVucValue
            // 
            this.lblBanKhuVucValue.AutoSize = true;
            this.lblBanKhuVucValue.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBanKhuVucValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(191)))), ((int)(((byte)(36)))));
            this.lblBanKhuVucValue.Location = new System.Drawing.Point(400, 16);
            this.lblBanKhuVucValue.Name = "lblBanKhuVucValue";
            this.lblBanKhuVucValue.Size = new System.Drawing.Size(260, 20);
            this.lblBanKhuVucValue.TabIndex = 1;
            this.lblBanKhuVucValue.Text = "Bàn: Bàn 01 - Khu vực: Tầng 1";
            this.lblBanKhuVucValue.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblMaHDTitle
            // 
            this.lblMaHDTitle.AutoSize = true;
            this.lblMaHDTitle.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaHDTitle.ForeColor = System.Drawing.Color.White;
            this.lblMaHDTitle.Location = new System.Drawing.Point(16, 12);
            this.lblMaHDTitle.Name = "lblMaHDTitle";
            this.lblMaHDTitle.Size = new System.Drawing.Size(305, 30);
            this.lblMaHDTitle.TabIndex = 0;
            this.lblMaHDTitle.Text = "CHI TIẾT HÓA ĐƠN #HD00001";
            // 
            // pnlBottom
            // 
            this.pnlBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.pnlBottom.Controls.Add(this.lblLyDoHuy);
            this.pnlBottom.Controls.Add(this.lblTongThanhToanVal);
            this.pnlBottom.Controls.Add(this.lblTongThanhToanTitle);
            this.pnlBottom.Controls.Add(this.lblGiamGiaVal);
            this.pnlBottom.Controls.Add(this.lblTongTienGocVal);
            this.pnlBottom.Controls.Add(this.lblGiamGiaTitle);
            this.pnlBottom.Controls.Add(this.lblTongTienGocTitle);
            this.pnlBottom.Controls.Add(this.btnInLaiBill);
            this.pnlBottom.Controls.Add(this.btnDong);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 481);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(684, 130);
            this.pnlBottom.TabIndex = 1;
            // 
            // lblLyDoHuy
            // 
            this.lblLyDoHuy.AutoSize = true;
            this.lblLyDoHuy.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLyDoHuy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.lblLyDoHuy.Location = new System.Drawing.Point(21, 95);
            this.lblLyDoHuy.Name = "lblLyDoHuy";
            this.lblLyDoHuy.Size = new System.Drawing.Size(76, 17);
            this.lblLyDoHuy.TabIndex = 8;
            this.lblLyDoHuy.Text = "Lý do hủy: --";
            this.lblLyDoHuy.Visible = false;
            // 
            // lblTongThanhToanVal
            // 
            this.lblTongThanhToanVal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongThanhToanVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(119)))), ((int)(((byte)(6)))));
            this.lblTongThanhToanVal.Location = new System.Drawing.Point(480, 58);
            this.lblTongThanhToanVal.Name = "lblTongThanhToanVal";
            this.lblTongThanhToanVal.Size = new System.Drawing.Size(180, 23);
            this.lblTongThanhToanVal.TabIndex = 7;
            this.lblTongThanhToanVal.Text = "0 đ";
            this.lblTongThanhToanVal.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblTongThanhToanTitle
            // 
            this.lblTongThanhToanTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongThanhToanTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblTongThanhToanTitle.Location = new System.Drawing.Point(250, 58);
            this.lblTongThanhToanTitle.Name = "lblTongThanhToanTitle";
            this.lblTongThanhToanTitle.Size = new System.Drawing.Size(220, 23);
            this.lblTongThanhToanTitle.TabIndex = 6;
            this.lblTongThanhToanTitle.Text = "TỔNG THÀNH TIỀN:";
            this.lblTongThanhToanTitle.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblGiamGiaVal
            // 
            this.lblGiamGiaVal.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGiamGiaVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblGiamGiaVal.Location = new System.Drawing.Point(480, 35);
            this.lblGiamGiaVal.Name = "lblGiamGiaVal";
            this.lblGiamGiaVal.Size = new System.Drawing.Size(180, 20);
            this.lblGiamGiaVal.TabIndex = 5;
            this.lblGiamGiaVal.Text = "0% (0 đ)";
            this.lblGiamGiaVal.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblTongTienGocVal
            // 
            this.lblTongTienGocVal.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongTienGocVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblTongTienGocVal.Location = new System.Drawing.Point(480, 12);
            this.lblTongTienGocVal.Name = "lblTongTienGocVal";
            this.lblTongTienGocVal.Size = new System.Drawing.Size(180, 20);
            this.lblTongTienGocVal.TabIndex = 4;
            this.lblTongTienGocVal.Text = "0 đ";
            this.lblTongTienGocVal.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblGiamGiaTitle
            // 
            this.lblGiamGiaTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGiamGiaTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblGiamGiaTitle.Location = new System.Drawing.Point(250, 35);
            this.lblGiamGiaTitle.Name = "lblGiamGiaTitle";
            this.lblGiamGiaTitle.Size = new System.Drawing.Size(220, 20);
            this.lblGiamGiaTitle.TabIndex = 3;
            this.lblGiamGiaTitle.Text = "Giảm giá:";
            this.lblGiamGiaTitle.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblTongTienGocTitle
            // 
            this.lblTongTienGocTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongTienGocTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblTongTienGocTitle.Location = new System.Drawing.Point(250, 12);
            this.lblTongTienGocTitle.Name = "lblTongTienGocTitle";
            this.lblTongTienGocTitle.Size = new System.Drawing.Size(220, 20);
            this.lblTongTienGocTitle.TabIndex = 2;
            this.lblTongTienGocTitle.Text = "Tổng tiền gốc:";
            this.lblTongTienGocTitle.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnInLaiBill
            // 
            this.btnInLaiBill.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInLaiBill.Location = new System.Drawing.Point(21, 15);
            this.btnInLaiBill.Name = "btnInLaiBill";
            this.btnInLaiBill.Size = new System.Drawing.Size(150, 36);
            this.btnInLaiBill.TabIndex = 1;
            this.btnInLaiBill.Text = "🖨️ In lại Hóa đơn";
            this.btnInLaiBill.UseVisualStyleBackColor = true;
            // 
            // btnDong
            // 
            this.btnDong.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDong.Location = new System.Drawing.Point(21, 55);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(150, 36);
            this.btnDong.TabIndex = 0;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            // 
            // pnlGridContainer
            // 
            this.pnlGridContainer.Controls.Add(this.dgvChiTiet);
            this.pnlGridContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGridContainer.Location = new System.Drawing.Point(0, 125);
            this.pnlGridContainer.Name = "pnlGridContainer";
            this.pnlGridContainer.Padding = new System.Windows.Forms.Padding(12);
            this.pnlGridContainer.Size = new System.Drawing.Size(684, 356);
            this.pnlGridContainer.TabIndex = 2;
            // 
            // dgvChiTiet
            // 
            this.dgvChiTiet.AllowUserToAddRows = false;
            this.dgvChiTiet.AllowUserToDeleteRows = false;
            this.dgvChiTiet.AllowUserToResizeRows = false;
            this.dgvChiTiet.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChiTiet.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dgvChiTiet.BackgroundColor = System.Drawing.Color.White;
            this.dgvChiTiet.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvChiTiet.ColumnHeadersHeight = 32;
            this.dgvChiTiet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvChiTiet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colStt,
            this.colTenMon,
            this.colSoLuong,
            this.colDonGia,
            this.colThanhTien});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvChiTiet.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvChiTiet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvChiTiet.Location = new System.Drawing.Point(12, 12);
            this.dgvChiTiet.MultiSelect = false;
            this.dgvChiTiet.Name = "dgvChiTiet";
            this.dgvChiTiet.ReadOnly = true;
            this.dgvChiTiet.RowHeadersVisible = false;
            this.dgvChiTiet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChiTiet.Size = new System.Drawing.Size(660, 332);
            this.dgvChiTiet.TabIndex = 0;
            // 
            // colStt
            // 
            this.colStt.FillWeight = 25F;
            this.colStt.HeaderText = "STT";
            this.colStt.Name = "colStt";
            this.colStt.ReadOnly = true;
            // 
            // colTenMon
            // 
            this.colTenMon.DataPropertyName = "TenMonHienThi";
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.colTenMon.DefaultCellStyle = dataGridViewCellStyle1;
            this.colTenMon.FillWeight = 130F;
            this.colTenMon.HeaderText = "Món ăn (Kèm Size & Ghi chú)";
            this.colTenMon.Name = "colTenMon";
            this.colTenMon.ReadOnly = true;
            // 
            // colSoLuong
            // 
            this.colSoLuong.DataPropertyName = "SoLuong";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colSoLuong.DefaultCellStyle = dataGridViewCellStyle2;
            this.colSoLuong.FillWeight = 35F;
            this.colSoLuong.HeaderText = "SL";
            this.colSoLuong.Name = "colSoLuong";
            this.colSoLuong.ReadOnly = true;
            // 
            // colDonGia
            // 
            this.colDonGia.DataPropertyName = "DonGia";
            this.colDonGia.FillWeight = 60F;
            this.colDonGia.HeaderText = "Đơn giá";
            this.colDonGia.Name = "colDonGia";
            this.colDonGia.ReadOnly = true;
            // 
            // colThanhTien
            // 
            this.colThanhTien.DataPropertyName = "ThanhTien";
            this.colThanhTien.FillWeight = 65F;
            this.colThanhTien.HeaderText = "Thành tiền";
            this.colThanhTien.Name = "colThanhTien";
            this.colThanhTien.ReadOnly = true;
            // 
            // FrmChiTietHoaDonModal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(684, 611);
            this.Controls.Add(this.pnlGridContainer);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTopHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmChiTietHoaDonModal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chi tiết Hóa đơn";
            this.pnlTopHeader.ResumeLayout(false);
            this.pnlTopHeader.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.pnlGridContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTopHeader;
        private System.Windows.Forms.Label lblMaHDTitle;
        private System.Windows.Forms.Label lblBanKhuVucValue;
        private System.Windows.Forms.Label lblThuNganValue;
        private System.Windows.Forms.Label lblThoiGianValue;
        private System.Windows.Forms.Label lblTrangThaiValue;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Button btnInLaiBill;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Label lblTongTienGocTitle;
        private System.Windows.Forms.Label lblGiamGiaTitle;
        private System.Windows.Forms.Label lblTongTienGocVal;
        private System.Windows.Forms.Label lblGiamGiaVal;
        private System.Windows.Forms.Label lblTongThanhToanTitle;
        private System.Windows.Forms.Label lblTongThanhToanVal;
        private System.Windows.Forms.Label lblLyDoHuy;
        private System.Windows.Forms.Panel pnlGridContainer;
        private System.Windows.Forms.DataGridView dgvChiTiet;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStt;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenMon;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDonGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThanhTien;
    }
}
