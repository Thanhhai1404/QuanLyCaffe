namespace QLCF.Forms
{
    partial class FrmThanhToan
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.lblMaHDInfo = new System.Windows.Forms.Label();
            this.lblTenBanInfo = new System.Windows.Forms.Label();
            this.lblTongTienGocLabel = new System.Windows.Forms.Label();
            this.lblTongTienGocVal = new System.Windows.Forms.Label();
            this.lblGiamGiaLabel = new System.Windows.Forms.Label();
            this.nudGiamGia = new System.Windows.Forms.NumericUpDown();
            this.lblPercentSign = new System.Windows.Forms.Label();
            this.lblSoTienGiamLabel = new System.Windows.Forms.Label();
            this.lblSoTienGiamVal = new System.Windows.Forms.Label();
            this.lblTongCanThanhToanLabel = new System.Windows.Forms.Label();
            this.lblTongCanThanhToanVal = new System.Windows.Forms.Label();
            this.lblPhuongThucLabel = new System.Windows.Forms.Label();
            this.cboPhuongThucThanhToan = new System.Windows.Forms.ComboBox();
            this.lblTienKhachDuaLabel = new System.Windows.Forms.Label();
            this.nudTienKhachDua = new System.Windows.Forms.NumericUpDown();
            this.lblTienThuaLabel = new System.Windows.Forms.Label();
            this.lblTienThuaVal = new System.Windows.Forms.Label();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnXacNhanThanhToan = new System.Windows.Forms.Button();
            this.btnHuyThanhToan = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudGiamGia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTienKhachDua)).BeginInit();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.pnlHeader.Controls.Add(this.lblTieuDe);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(482, 55);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTieuDe.ForeColor = System.Drawing.Color.White;
            this.lblTieuDe.Location = new System.Drawing.Point(0, 0);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(482, 55);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "THANH TOÁN HÓA ĐƠN";
            this.lblTieuDe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.White;
            this.pnlMain.Controls.Add(this.lblMaHDInfo);
            this.pnlMain.Controls.Add(this.lblTenBanInfo);
            this.pnlMain.Controls.Add(this.lblTongTienGocLabel);
            this.pnlMain.Controls.Add(this.lblTongTienGocVal);
            this.pnlMain.Controls.Add(this.lblGiamGiaLabel);
            this.pnlMain.Controls.Add(this.nudGiamGia);
            this.pnlMain.Controls.Add(this.lblPercentSign);
            this.pnlMain.Controls.Add(this.lblSoTienGiamLabel);
            this.pnlMain.Controls.Add(this.lblSoTienGiamVal);
            this.pnlMain.Controls.Add(this.lblTongCanThanhToanLabel);
            this.pnlMain.Controls.Add(this.lblTongCanThanhToanVal);
            this.pnlMain.Controls.Add(this.lblPhuongThucLabel);
            this.pnlMain.Controls.Add(this.cboPhuongThucThanhToan);
            this.pnlMain.Controls.Add(this.lblTienKhachDuaLabel);
            this.pnlMain.Controls.Add(this.nudTienKhachDua);
            this.pnlMain.Controls.Add(this.lblTienThuaLabel);
            this.pnlMain.Controls.Add(this.lblTienThuaVal);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 55);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(25, 15, 25, 15);
            this.pnlMain.Size = new System.Drawing.Size(482, 385);
            this.pnlMain.TabIndex = 1;
            // 
            // lblMaHDInfo
            // 
            this.lblMaHDInfo.AutoSize = true;
            this.lblMaHDInfo.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaHDInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblMaHDInfo.Location = new System.Drawing.Point(25, 20);
            this.lblMaHDInfo.Name = "lblMaHDInfo";
            this.lblMaHDInfo.Size = new System.Drawing.Size(185, 25);
            this.lblMaHDInfo.TabIndex = 0;
            this.lblMaHDInfo.Text = "Mã hóa đơn: HD0000";
            // 
            // lblTenBanInfo
            // 
            this.lblTenBanInfo.AutoSize = true;
            this.lblTenBanInfo.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenBanInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblTenBanInfo.Location = new System.Drawing.Point(260, 20);
            this.lblTenBanInfo.Name = "lblTenBanInfo";
            this.lblTenBanInfo.Size = new System.Drawing.Size(89, 25);
            this.lblTenBanInfo.TabIndex = 1;
            this.lblTenBanInfo.Text = "Bàn: --";
            // 
            // lblTongTienGocLabel
            // 
            this.lblTongTienGocLabel.AutoSize = true;
            this.lblTongTienGocLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongTienGocLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblTongTienGocLabel.Location = new System.Drawing.Point(25, 65);
            this.lblTongTienGocLabel.Name = "lblTongTienGocLabel";
            this.lblTongTienGocLabel.Size = new System.Drawing.Size(117, 23);
            this.lblTongTienGocLabel.TabIndex = 2;
            this.lblTongTienGocLabel.Text = "Tổng tiền gốc:";
            // 
            // lblTongTienGocVal
            // 
            this.lblTongTienGocVal.AutoSize = true;
            this.lblTongTienGocVal.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongTienGocVal.ForeColor = System.Drawing.Color.Black;
            this.lblTongTienGocVal.Location = new System.Drawing.Point(220, 65);
            this.lblTongTienGocVal.Name = "lblTongTienGocVal";
            this.lblTongTienGocVal.Size = new System.Drawing.Size(42, 25);
            this.lblTongTienGocVal.TabIndex = 3;
            this.lblTongTienGocVal.Text = "0 đ";
            // 
            // lblGiamGiaLabel
            // 
            this.lblGiamGiaLabel.AutoSize = true;
            this.lblGiamGiaLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGiamGiaLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblGiamGiaLabel.Location = new System.Drawing.Point(25, 105);
            this.lblGiamGiaLabel.Name = "lblGiamGiaLabel";
            this.lblGiamGiaLabel.Size = new System.Drawing.Size(111, 23);
            this.lblGiamGiaLabel.TabIndex = 4;
            this.lblGiamGiaLabel.Text = "Giảm giá (%):";
            // 
            // nudGiamGia
            // 
            this.nudGiamGia.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudGiamGia.Location = new System.Drawing.Point(225, 102);
            this.nudGiamGia.Name = "nudGiamGia";
            this.nudGiamGia.Size = new System.Drawing.Size(85, 30);
            this.nudGiamGia.TabIndex = 5;
            // 
            // lblPercentSign
            // 
            this.lblPercentSign.AutoSize = true;
            this.lblPercentSign.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPercentSign.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblPercentSign.Location = new System.Drawing.Point(315, 105);
            this.lblPercentSign.Name = "lblPercentSign";
            this.lblPercentSign.Size = new System.Drawing.Size(25, 23);
            this.lblPercentSign.TabIndex = 6;
            this.lblPercentSign.Text = "%";
            // 
            // lblSoTienGiamLabel
            // 
            this.lblSoTienGiamLabel.AutoSize = true;
            this.lblSoTienGiamLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoTienGiamLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblSoTienGiamLabel.Location = new System.Drawing.Point(25, 145);
            this.lblSoTienGiamLabel.Name = "lblSoTienGiamLabel";
            this.lblSoTienGiamLabel.Size = new System.Drawing.Size(109, 23);
            this.lblSoTienGiamLabel.TabIndex = 7;
            this.lblSoTienGiamLabel.Text = "Số tiền giảm:";
            // 
            // lblSoTienGiamVal
            // 
            this.lblSoTienGiamVal.AutoSize = true;
            this.lblSoTienGiamVal.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoTienGiamVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.lblSoTienGiamVal.Location = new System.Drawing.Point(220, 145);
            this.lblSoTienGiamVal.Name = "lblSoTienGiamVal";
            this.lblSoTienGiamVal.Size = new System.Drawing.Size(42, 25);
            this.lblSoTienGiamVal.TabIndex = 8;
            this.lblSoTienGiamVal.Text = "0 đ";
            // 
            // lblTongCanThanhToanLabel
            // 
            this.lblTongCanThanhToanLabel.AutoSize = true;
            this.lblTongCanThanhToanLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongCanThanhToanLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblTongCanThanhToanLabel.Location = new System.Drawing.Point(25, 185);
            this.lblTongCanThanhToanLabel.Name = "lblTongCanThanhToanLabel";
            this.lblTongCanThanhToanLabel.Size = new System.Drawing.Size(183, 25);
            this.lblTongCanThanhToanLabel.TabIndex = 9;
            this.lblTongCanThanhToanLabel.Text = "Tổng cần thanh toán:";
            // 
            // lblTongCanThanhToanVal
            // 
            this.lblTongCanThanhToanVal.AutoSize = true;
            this.lblTongCanThanhToanVal.Font = new System.Drawing.Font("Segoe UI", 12.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongCanThanhToanVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.lblTongCanThanhToanVal.Location = new System.Drawing.Point(220, 182);
            this.lblTongCanThanhToanVal.Name = "lblTongCanThanhToanVal";
            this.lblTongCanThanhToanVal.Size = new System.Drawing.Size(50, 30);
            this.lblTongCanThanhToanVal.TabIndex = 10;
            this.lblTongCanThanhToanVal.Text = "0 đ";
            // 
            // lblPhuongThucLabel
            // 
            this.lblPhuongThucLabel.AutoSize = true;
            this.lblPhuongThucLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhuongThucLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblPhuongThucLabel.Location = new System.Drawing.Point(25, 235);
            this.lblPhuongThucLabel.Name = "lblPhuongThucLabel";
            this.lblPhuongThucLabel.Size = new System.Drawing.Size(142, 23);
            this.lblPhuongThucLabel.TabIndex = 11;
            this.lblPhuongThucLabel.Text = "Phương thức TT:";
            // 
            // cboPhuongThucThanhToan
            // 
            this.cboPhuongThucThanhToan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPhuongThucThanhToan.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPhuongThucThanhToan.FormattingEnabled = true;
            this.cboPhuongThucThanhToan.Location = new System.Drawing.Point(225, 232);
            this.cboPhuongThucThanhToan.Name = "cboPhuongThucThanhToan";
            this.cboPhuongThucThanhToan.Size = new System.Drawing.Size(225, 31);
            this.cboPhuongThucThanhToan.TabIndex = 12;
            // 
            // lblTienKhachDuaLabel
            // 
            this.lblTienKhachDuaLabel.AutoSize = true;
            this.lblTienKhachDuaLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTienKhachDuaLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblTienKhachDuaLabel.Location = new System.Drawing.Point(25, 280);
            this.lblTienKhachDuaLabel.Name = "lblTienKhachDuaLabel";
            this.lblTienKhachDuaLabel.Size = new System.Drawing.Size(130, 23);
            this.lblTienKhachDuaLabel.TabIndex = 13;
            this.lblTienKhachDuaLabel.Text = "Tiền khách đưa:";
            // 
            // nudTienKhachDua
            // 
            this.nudTienKhachDua.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudTienKhachDua.Increment = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudTienKhachDua.Location = new System.Drawing.Point(225, 277);
            this.nudTienKhachDua.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.nudTienKhachDua.Name = "nudTienKhachDua";
            this.nudTienKhachDua.Size = new System.Drawing.Size(225, 31);
            this.nudTienKhachDua.TabIndex = 14;
            this.nudTienKhachDua.ThousandsSeparator = true;
            // 
            // lblTienThuaLabel
            // 
            this.lblTienThuaLabel.AutoSize = true;
            this.lblTienThuaLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTienThuaLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblTienThuaLabel.Location = new System.Drawing.Point(25, 325);
            this.lblTienThuaLabel.Name = "lblTienThuaLabel";
            this.lblTienThuaLabel.Size = new System.Drawing.Size(97, 23);
            this.lblTienThuaLabel.TabIndex = 15;
            this.lblTienThuaLabel.Text = "Tiền trả lại:";
            // 
            // lblTienThuaVal
            // 
            this.lblTienThuaVal.AutoSize = true;
            this.lblTienThuaVal.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTienThuaVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.lblTienThuaVal.Location = new System.Drawing.Point(220, 325);
            this.lblTienThuaVal.Name = "lblTienThuaVal";
            this.lblTienThuaVal.Size = new System.Drawing.Size(42, 25);
            this.lblTienThuaVal.TabIndex = 16;
            this.lblTienThuaVal.Text = "0 đ";
            // 
            // pnlButtons
            // 
            this.pnlButtons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.pnlButtons.Controls.Add(this.btnHuyThanhToan);
            this.pnlButtons.Controls.Add(this.btnXacNhanThanhToan);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Location = new System.Drawing.Point(0, 440);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(482, 65);
            this.pnlButtons.TabIndex = 2;
            // 
            // btnXacNhanThanhToan
            // 
            this.btnXacNhanThanhToan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnXacNhanThanhToan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXacNhanThanhToan.FlatAppearance.BorderSize = 0;
            this.btnXacNhanThanhToan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXacNhanThanhToan.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXacNhanThanhToan.ForeColor = System.Drawing.Color.White;
            this.btnXacNhanThanhToan.Location = new System.Drawing.Point(25, 12);
            this.btnXacNhanThanhToan.Name = "btnXacNhanThanhToan";
            this.btnXacNhanThanhToan.Size = new System.Drawing.Size(270, 40);
            this.btnXacNhanThanhToan.TabIndex = 0;
            this.btnXacNhanThanhToan.Text = "✔ Xác nhận thanh toán";
            this.btnXacNhanThanhToan.UseVisualStyleBackColor = false;
            // 
            // btnHuyThanhToan
            // 
            this.btnHuyThanhToan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnHuyThanhToan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHuyThanhToan.FlatAppearance.BorderSize = 0;
            this.btnHuyThanhToan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuyThanhToan.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuyThanhToan.ForeColor = System.Drawing.Color.White;
            this.btnHuyThanhToan.Location = new System.Drawing.Point(320, 12);
            this.btnHuyThanhToan.Name = "btnHuyThanhToan";
            this.btnHuyThanhToan.Size = new System.Drawing.Size(130, 40);
            this.btnHuyThanhToan.TabIndex = 1;
            this.btnHuyThanhToan.Text = "❌ Hủy";
            this.btnHuyThanhToan.UseVisualStyleBackColor = false;
            // 
            // FrmThanhToan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 505);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmThanhToan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thanh toán hóa đơn";
            this.pnlHeader.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudGiamGia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTienKhachDua)).EndInit();
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Label lblMaHDInfo;
        private System.Windows.Forms.Label lblTenBanInfo;
        private System.Windows.Forms.Label lblTongTienGocLabel;
        private System.Windows.Forms.Label lblTongTienGocVal;
        private System.Windows.Forms.Label lblGiamGiaLabel;
        private System.Windows.Forms.NumericUpDown nudGiamGia;
        private System.Windows.Forms.Label lblPercentSign;
        private System.Windows.Forms.Label lblSoTienGiamLabel;
        private System.Windows.Forms.Label lblSoTienGiamVal;
        private System.Windows.Forms.Label lblTongCanThanhToanLabel;
        private System.Windows.Forms.Label lblTongCanThanhToanVal;
        private System.Windows.Forms.Label lblPhuongThucLabel;
        private System.Windows.Forms.ComboBox cboPhuongThucThanhToan;
        private System.Windows.Forms.Label lblTienKhachDuaLabel;
        private System.Windows.Forms.NumericUpDown nudTienKhachDua;
        private System.Windows.Forms.Label lblTienThuaLabel;
        private System.Windows.Forms.Label lblTienThuaVal;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnXacNhanThanhToan;
        private System.Windows.Forms.Button btnHuyThanhToan;
    }
}
