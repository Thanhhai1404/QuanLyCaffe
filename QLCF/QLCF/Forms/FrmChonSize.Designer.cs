namespace QLCF.Forms
{
    partial class FrmChonSize
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lblTenMon;
        private System.Windows.Forms.Label lblGiaGoc;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Label lblChooseSizeHeader;
        private System.Windows.Forms.Button btnSizeS;
        private System.Windows.Forms.Button btnSizeM;
        private System.Windows.Forms.Button btnSizeL;
        private System.Windows.Forms.Label lblSoLuongHeader;
        private System.Windows.Forms.NumericUpDown nudSoLuong;
        private System.Windows.Forms.Label lblGhiChuHeader;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Button btnXacNhan;
        private System.Windows.Forms.Button btnHuy;

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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblGiaGoc = new System.Windows.Forms.Label();
            this.lblTenMon = new System.Windows.Forms.Label();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.lblGhiChuHeader = new System.Windows.Forms.Label();
            this.nudSoLuong = new System.Windows.Forms.NumericUpDown();
            this.lblSoLuongHeader = new System.Windows.Forms.Label();
            this.btnSizeL = new System.Windows.Forms.Button();
            this.btnSizeM = new System.Windows.Forms.Button();
            this.btnSizeS = new System.Windows.Forms.Button();
            this.lblChooseSizeHeader = new System.Windows.Forms.Label();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnXacNhan = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuong)).BeginInit();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.pnlHeader.Controls.Add(this.lblGiaGoc);
            this.pnlHeader.Controls.Add(this.lblTenMon);
            this.pnlHeader.Controls.Add(this.lblTieuDe);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(420, 85);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblGiaGoc
            // 
            this.lblGiaGoc.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGiaGoc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(191)))), ((int)(((byte)(36)))));
            this.lblGiaGoc.Location = new System.Drawing.Point(16, 56);
            this.lblGiaGoc.Name = "lblGiaGoc";
            this.lblGiaGoc.Size = new System.Drawing.Size(388, 20);
            this.lblGiaGoc.TabIndex = 2;
            this.lblGiaGoc.Text = "Giá gốc: 0 đ";
            // 
            // lblTenMon
            // 
            this.lblTenMon.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenMon.ForeColor = System.Drawing.Color.White;
            this.lblTenMon.Location = new System.Drawing.Point(15, 28);
            this.lblTenMon.Name = "lblTenMon";
            this.lblTenMon.Size = new System.Drawing.Size(389, 28);
            this.lblTenMon.TabIndex = 1;
            this.lblTenMon.Text = "Tên món ăn";
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTieuDe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblTieuDe.Location = new System.Drawing.Point(16, 8);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(133, 20);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "TÙY CHỌN SIZE MÓN";
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.White;
            this.pnlContent.Controls.Add(this.txtGhiChu);
            this.pnlContent.Controls.Add(this.lblGhiChuHeader);
            this.pnlContent.Controls.Add(this.nudSoLuong);
            this.pnlContent.Controls.Add(this.lblSoLuongHeader);
            this.pnlContent.Controls.Add(this.btnSizeL);
            this.pnlContent.Controls.Add(this.btnSizeM);
            this.pnlContent.Controls.Add(this.btnSizeS);
            this.pnlContent.Controls.Add(this.lblChooseSizeHeader);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 85);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Padding = new System.Windows.Forms.Padding(16);
            this.pnlContent.Size = new System.Drawing.Size(420, 290);
            this.pnlContent.TabIndex = 1;
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtGhiChu.Location = new System.Drawing.Point(16, 218);
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(388, 55);
            this.txtGhiChu.TabIndex = 7;
            // 
            // lblGhiChuHeader
            // 
            this.lblGhiChuHeader.AutoSize = true;
            this.lblGhiChuHeader.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblGhiChuHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblGhiChuHeader.Location = new System.Drawing.Point(16, 192);
            this.lblGhiChuHeader.Name = "lblGhiChuHeader";
            this.lblGhiChuHeader.Size = new System.Drawing.Size(72, 21);
            this.lblGhiChuHeader.TabIndex = 6;
            this.lblGhiChuHeader.Text = "Ghi chú:";
            // 
            // nudSoLuong
            // 
            this.nudSoLuong.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.nudSoLuong.Location = new System.Drawing.Point(100, 142);
            this.nudSoLuong.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSoLuong.Name = "nudSoLuong";
            this.nudSoLuong.Size = new System.Drawing.Size(85, 32);
            this.nudSoLuong.TabIndex = 5;
            this.nudSoLuong.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudSoLuong.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblSoLuongHeader
            // 
            this.lblSoLuongHeader.AutoSize = true;
            this.lblSoLuongHeader.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblSoLuongHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblSoLuongHeader.Location = new System.Drawing.Point(16, 147);
            this.lblSoLuongHeader.Name = "lblSoLuongHeader";
            this.lblSoLuongHeader.Size = new System.Drawing.Size(82, 21);
            this.lblSoLuongHeader.TabIndex = 4;
            this.lblSoLuongHeader.Text = "Số lượng:";
            // 
            // btnSizeL
            // 
            this.btnSizeL.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSizeL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSizeL.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnSizeL.Location = new System.Drawing.Point(278, 48);
            this.btnSizeL.Name = "btnSizeL";
            this.btnSizeL.Size = new System.Drawing.Size(126, 70);
            this.btnSizeL.TabIndex = 3;
            this.btnSizeL.Text = "Size L\r\n(+10,000 đ)";
            this.btnSizeL.UseVisualStyleBackColor = true;
            // 
            // btnSizeM
            // 
            this.btnSizeM.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSizeM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSizeM.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnSizeM.Location = new System.Drawing.Point(147, 48);
            this.btnSizeM.Name = "btnSizeM";
            this.btnSizeM.Size = new System.Drawing.Size(125, 70);
            this.btnSizeM.TabIndex = 2;
            this.btnSizeM.Text = "Size M\r\n(+5,000 đ)";
            this.btnSizeM.UseVisualStyleBackColor = true;
            // 
            // btnSizeS
            // 
            this.btnSizeS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSizeS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSizeS.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnSizeS.Location = new System.Drawing.Point(16, 48);
            this.btnSizeS.Name = "btnSizeS";
            this.btnSizeS.Size = new System.Drawing.Size(125, 70);
            this.btnSizeS.TabIndex = 1;
            this.btnSizeS.Text = "Size S\r\n(+0 đ)";
            this.btnSizeS.UseVisualStyleBackColor = true;
            // 
            // lblChooseSizeHeader
            // 
            this.lblChooseSizeHeader.AutoSize = true;
            this.lblChooseSizeHeader.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblChooseSizeHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblChooseSizeHeader.Location = new System.Drawing.Point(16, 18);
            this.lblChooseSizeHeader.Name = "lblChooseSizeHeader";
            this.lblChooseSizeHeader.Size = new System.Drawing.Size(174, 21);
            this.lblChooseSizeHeader.TabIndex = 0;
            this.lblChooseSizeHeader.Text = "Chọn Kích Thước (Size):";
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.pnlFooter.Controls.Add(this.btnHuy);
            this.pnlFooter.Controls.Add(this.btnXacNhan);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 375);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(420, 65);
            this.pnlFooter.TabIndex = 2;
            // 
            // btnHuy
            // 
            this.btnHuy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHuy.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnHuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuy.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnHuy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.btnHuy.Location = new System.Drawing.Point(16, 12);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(110, 42);
            this.btnHuy.TabIndex = 1;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(119)))), ((int)(((byte)(6)))));
            this.btnXacNhan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXacNhan.FlatAppearance.BorderSize = 0;
            this.btnXacNhan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXacNhan.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnXacNhan.ForeColor = System.Drawing.Color.White;
            this.btnXacNhan.Location = new System.Drawing.Point(135, 12);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(269, 42);
            this.btnXacNhan.TabIndex = 0;
            this.btnXacNhan.Text = "Xác nhận thêm món";
            this.btnXacNhan.UseVisualStyleBackColor = false;
            // 
            // FrmChonSize
            // 
            this.AcceptButton = this.btnXacNhan;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnHuy;
            this.ClientSize = new System.Drawing.Size(420, 440);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmChonSize";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chọn Size Đồ Uống";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuong)).EndInit();
            this.pnlFooter.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}
