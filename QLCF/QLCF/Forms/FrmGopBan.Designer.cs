namespace QLCF.Forms
{
    partial class FrmGopBan
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.grpBanChinh = new System.Windows.Forms.GroupBox();
            this.lblTamTinhChinhVal = new System.Windows.Forms.Label();
            this.lblTamTinhChinhLabel = new System.Windows.Forms.Label();
            this.lblMaHDChinhVal = new System.Windows.Forms.Label();
            this.lblMaHDChinhLabel = new System.Windows.Forms.Label();
            this.lblTenBanChinhVal = new System.Windows.Forms.Label();
            this.lblTenBanChinhLabel = new System.Windows.Forms.Label();
            this.grpBanPhu = new System.Windows.Forms.GroupBox();
            this.cboBanPhu = new System.Windows.Forms.ComboBox();
            this.lblBanPhuLabel = new System.Windows.Forms.Label();
            this.lblCanhBao = new System.Windows.Forms.Label();
            this.btnXacNhanGop = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.grpBanChinh.SuspendLayout();
            this.grpBanPhu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(68)))), ((int)(((byte)(173)))));
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(460, 50);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(460, 50);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "🔀 GỘP BÀN";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grpBanChinh
            // 
            this.grpBanChinh.Controls.Add(this.lblTamTinhChinhVal);
            this.grpBanChinh.Controls.Add(this.lblTamTinhChinhLabel);
            this.grpBanChinh.Controls.Add(this.lblMaHDChinhVal);
            this.grpBanChinh.Controls.Add(this.lblMaHDChinhLabel);
            this.grpBanChinh.Controls.Add(this.lblTenBanChinhVal);
            this.grpBanChinh.Controls.Add(this.lblTenBanChinhLabel);
            this.grpBanChinh.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpBanChinh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.grpBanChinh.Location = new System.Drawing.Point(20, 65);
            this.grpBanChinh.Name = "grpBanChinh";
            this.grpBanChinh.Size = new System.Drawing.Size(420, 125);
            this.grpBanChinh.TabIndex = 1;
            this.grpBanChinh.TabStop = false;
            this.grpBanChinh.Text = "Thông tin bàn chính (Bàn giữ hóa đơn)";
            // 
            // lblTamTinhChinhVal
            // 
            this.lblTamTinhChinhVal.AutoSize = true;
            this.lblTamTinhChinhVal.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTamTinhChinhVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.lblTamTinhChinhVal.Location = new System.Drawing.Point(140, 90);
            this.lblTamTinhChinhVal.Name = "lblTamTinhChinhVal";
            this.lblTamTinhChinhVal.Size = new System.Drawing.Size(35, 21);
            this.lblTamTinhChinhVal.TabIndex = 5;
            this.lblTamTinhChinhVal.Text = "0 đ";
            // 
            // lblTamTinhChinhLabel
            // 
            this.lblTamTinhChinhLabel.AutoSize = true;
            this.lblTamTinhChinhLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTamTinhChinhLabel.Location = new System.Drawing.Point(15, 90);
            this.lblTamTinhChinhLabel.Name = "lblTamTinhChinhLabel";
            this.lblTamTinhChinhLabel.Size = new System.Drawing.Size(70, 20);
            this.lblTamTinhChinhLabel.TabIndex = 4;
            this.lblTamTinhChinhLabel.Text = "Tạm tính:";
            // 
            // lblMaHDChinhVal
            // 
            this.lblMaHDChinhVal.AutoSize = true;
            this.lblMaHDChinhVal.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaHDChinhVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(68)))), ((int)(((byte)(173)))));
            this.lblMaHDChinhVal.Location = new System.Drawing.Point(140, 60);
            this.lblMaHDChinhVal.Name = "lblMaHDChinhVal";
            this.lblMaHDChinhVal.Size = new System.Drawing.Size(81, 21);
            this.lblMaHDChinhVal.TabIndex = 3;
            this.lblMaHDChinhVal.Text = "HD00000";
            // 
            // lblMaHDChinhLabel
            // 
            this.lblMaHDChinhLabel.AutoSize = true;
            this.lblMaHDChinhLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaHDChinhLabel.Location = new System.Drawing.Point(15, 60);
            this.lblMaHDChinhLabel.Name = "lblMaHDChinhLabel";
            this.lblMaHDChinhLabel.Size = new System.Drawing.Size(92, 20);
            this.lblMaHDChinhLabel.TabIndex = 2;
            this.lblMaHDChinhLabel.Text = "Mã hóa đơn:";
            // 
            // lblTenBanChinhVal
            // 
            this.lblTenBanChinhVal.AutoSize = true;
            this.lblTenBanChinhVal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenBanChinhVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblTenBanChinhVal.Location = new System.Drawing.Point(140, 30);
            this.lblTenBanChinhVal.Name = "lblTenBanChinhVal";
            this.lblTenBanChinhVal.Size = new System.Drawing.Size(71, 23);
            this.lblTenBanChinhVal.TabIndex = 1;
            this.lblTenBanChinhVal.Text = "Bàn --";
            // 
            // lblTenBanChinhLabel
            // 
            this.lblTenBanChinhLabel.AutoSize = true;
            this.lblTenBanChinhLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenBanChinhLabel.Location = new System.Drawing.Point(15, 30);
            this.lblTenBanChinhLabel.Name = "lblTenBanChinhLabel";
            this.lblTenBanChinhLabel.Size = new System.Drawing.Size(102, 20);
            this.lblTenBanChinhLabel.TabIndex = 0;
            this.lblTenBanChinhLabel.Text = "Tên bàn chính:";
            // 
            // grpBanPhu
            // 
            this.grpBanPhu.Controls.Add(this.cboBanPhu);
            this.grpBanPhu.Controls.Add(this.lblBanPhuLabel);
            this.grpBanPhu.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpBanPhu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.grpBanPhu.Location = new System.Drawing.Point(20, 200);
            this.grpBanPhu.Name = "grpBanPhu";
            this.grpBanPhu.Size = new System.Drawing.Size(420, 85);
            this.grpBanPhu.TabIndex = 2;
            this.grpBanPhu.TabStop = false;
            this.grpBanPhu.Text = "Chọn bàn phụ (Bàn sẽ gộp vào)";
            // 
            // cboBanPhu
            // 
            this.cboBanPhu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBanPhu.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboBanPhu.FormattingEnabled = true;
            this.cboBanPhu.Location = new System.Drawing.Point(110, 33);
            this.cboBanPhu.Name = "cboBanPhu";
            this.cboBanPhu.Size = new System.Drawing.Size(295, 29);
            this.cboBanPhu.TabIndex = 1;
            // 
            // lblBanPhuLabel
            // 
            this.lblBanPhuLabel.AutoSize = true;
            this.lblBanPhuLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBanPhuLabel.Location = new System.Drawing.Point(15, 37);
            this.lblBanPhuLabel.Name = "lblBanPhuLabel";
            this.lblBanPhuLabel.Size = new System.Drawing.Size(66, 20);
            this.lblBanPhuLabel.TabIndex = 0;
            this.lblBanPhuLabel.Text = "Bàn phụ:";
            // 
            // lblCanhBao
            // 
            this.lblCanhBao.AutoSize = true;
            this.lblCanhBao.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCanhBao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.lblCanhBao.Location = new System.Drawing.Point(20, 292);
            this.lblCanhBao.Name = "lblCanhBao";
            this.lblCanhBao.Size = new System.Drawing.Size(341, 20);
            this.lblCanhBao.TabIndex = 3;
            this.lblCanhBao.Text = "⚠️ Toàn bộ món của bàn phụ sẽ được chuyển vào bàn chính.";
            // 
            // btnXacNhanGop
            // 
            this.btnXacNhanGop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(68)))), ((int)(((byte)(173)))));
            this.btnXacNhanGop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXacNhanGop.FlatAppearance.BorderSize = 0;
            this.btnXacNhanGop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXacNhanGop.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXacNhanGop.ForeColor = System.Drawing.Color.White;
            this.btnXacNhanGop.Location = new System.Drawing.Point(135, 325);
            this.btnXacNhanGop.Name = "btnXacNhanGop";
            this.btnXacNhanGop.Size = new System.Drawing.Size(150, 40);
            this.btnXacNhanGop.TabIndex = 4;
            this.btnXacNhanGop.Text = "🔀 Xác nhận gộp";
            this.btnXacNhanGop.UseVisualStyleBackColor = false;
            // 
            // btnHuy
            // 
            this.btnHuy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnHuy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHuy.FlatAppearance.BorderSize = 0;
            this.btnHuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuy.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuy.ForeColor = System.Drawing.Color.White;
            this.btnHuy.Location = new System.Drawing.Point(300, 325);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(110, 40);
            this.btnHuy.TabIndex = 5;
            this.btnHuy.Text = "❌ Hủy";
            this.btnHuy.UseVisualStyleBackColor = false;
            // 
            // FrmGopBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(460, 385);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnXacNhanGop);
            this.Controls.Add(this.lblCanhBao);
            this.Controls.Add(this.grpBanPhu);
            this.Controls.Add(this.grpBanChinh);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmGopBan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Gộp bàn";
            this.pnlHeader.ResumeLayout(false);
            this.grpBanChinh.ResumeLayout(false);
            this.grpBanChinh.PerformLayout();
            this.grpBanPhu.ResumeLayout(false);
            this.grpBanPhu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox grpBanChinh;
        private System.Windows.Forms.Label lblTenBanChinhLabel;
        private System.Windows.Forms.Label lblTenBanChinhVal;
        private System.Windows.Forms.Label lblMaHDChinhLabel;
        private System.Windows.Forms.Label lblMaHDChinhVal;
        private System.Windows.Forms.Label lblTamTinhChinhLabel;
        private System.Windows.Forms.Label lblTamTinhChinhVal;
        private System.Windows.Forms.GroupBox grpBanPhu;
        private System.Windows.Forms.Label lblBanPhuLabel;
        private System.Windows.Forms.ComboBox cboBanPhu;
        private System.Windows.Forms.Label lblCanhBao;
        private System.Windows.Forms.Button btnXacNhanGop;
        private System.Windows.Forms.Button btnHuy;
    }
}
