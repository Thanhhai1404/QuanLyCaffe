namespace QLCF.Forms
{
    partial class FrmChuyenBan
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
            this.grpBanNguon = new System.Windows.Forms.GroupBox();
            this.lblTamTinhVal = new System.Windows.Forms.Label();
            this.lblTamTinhLabel = new System.Windows.Forms.Label();
            this.lblMaHDVal = new System.Windows.Forms.Label();
            this.lblMaHDLabel = new System.Windows.Forms.Label();
            this.lblTenBanNguonVal = new System.Windows.Forms.Label();
            this.lblTenBanNguonLabel = new System.Windows.Forms.Label();
            this.grpBanDich = new System.Windows.Forms.GroupBox();
            this.cboBanDich = new System.Windows.Forms.ComboBox();
            this.lblBanDichLabel = new System.Windows.Forms.Label();
            this.btnXacNhanChuyen = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.grpBanNguon.SuspendLayout();
            this.grpBanDich.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(430, 50);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(430, 50);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "🔄 CHUYỂN BÀN";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grpBanNguon
            // 
            this.grpBanNguon.Controls.Add(this.lblTamTinhVal);
            this.grpBanNguon.Controls.Add(this.lblTamTinhLabel);
            this.grpBanNguon.Controls.Add(this.lblMaHDVal);
            this.grpBanNguon.Controls.Add(this.lblMaHDLabel);
            this.grpBanNguon.Controls.Add(this.lblTenBanNguonVal);
            this.grpBanNguon.Controls.Add(this.lblTenBanNguonLabel);
            this.grpBanNguon.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpBanNguon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.grpBanNguon.Location = new System.Drawing.Point(20, 65);
            this.grpBanNguon.Name = "grpBanNguon";
            this.grpBanNguon.Size = new System.Drawing.Size(390, 125);
            this.grpBanNguon.TabIndex = 1;
            this.grpBanNguon.TabStop = false;
            this.grpBanNguon.Text = "Thông tin bàn nguồn (Đang chuyển)";
            // 
            // lblTamTinhVal
            // 
            this.lblTamTinhVal.AutoSize = true;
            this.lblTamTinhVal.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTamTinhVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.lblTamTinhVal.Location = new System.Drawing.Point(140, 90);
            this.lblTamTinhVal.Name = "lblTamTinhVal";
            this.lblTamTinhVal.Size = new System.Drawing.Size(35, 21);
            this.lblTamTinhVal.TabIndex = 5;
            this.lblTamTinhVal.Text = "0 đ";
            // 
            // lblTamTinhLabel
            // 
            this.lblTamTinhLabel.AutoSize = true;
            this.lblTamTinhLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTamTinhLabel.Location = new System.Drawing.Point(15, 90);
            this.lblTamTinhLabel.Name = "lblTamTinhLabel";
            this.lblTamTinhLabel.Size = new System.Drawing.Size(70, 20);
            this.lblTamTinhLabel.TabIndex = 4;
            this.lblTamTinhLabel.Text = "Tạm tính:";
            // 
            // lblMaHDVal
            // 
            this.lblMaHDVal.AutoSize = true;
            this.lblMaHDVal.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaHDVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.lblMaHDVal.Location = new System.Drawing.Point(140, 60);
            this.lblMaHDVal.Name = "lblMaHDVal";
            this.lblMaHDVal.Size = new System.Drawing.Size(81, 21);
            this.lblMaHDVal.TabIndex = 3;
            this.lblMaHDVal.Text = "HD00000";
            // 
            // lblMaHDLabel
            // 
            this.lblMaHDLabel.AutoSize = true;
            this.lblMaHDLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaHDLabel.Location = new System.Drawing.Point(15, 60);
            this.lblMaHDLabel.Name = "lblMaHDLabel";
            this.lblMaHDLabel.Size = new System.Drawing.Size(92, 20);
            this.lblMaHDLabel.TabIndex = 2;
            this.lblMaHDLabel.Text = "Mã hóa đơn:";
            // 
            // lblTenBanNguonVal
            // 
            this.lblTenBanNguonVal.AutoSize = true;
            this.lblTenBanNguonVal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenBanNguonVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblTenBanNguonVal.Location = new System.Drawing.Point(140, 30);
            this.lblTenBanNguonVal.Name = "lblTenBanNguonVal";
            this.lblTenBanNguonVal.Size = new System.Drawing.Size(71, 23);
            this.lblTenBanNguonVal.TabIndex = 1;
            this.lblTenBanNguonVal.Text = "Bàn --";
            // 
            // lblTenBanNguonLabel
            // 
            this.lblTenBanNguonLabel.AutoSize = true;
            this.lblTenBanNguonLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenBanNguonLabel.Location = new System.Drawing.Point(15, 30);
            this.lblTenBanNguonLabel.Name = "lblTenBanNguonLabel";
            this.lblTenBanNguonLabel.Size = new System.Drawing.Size(107, 20);
            this.lblTenBanNguonLabel.TabIndex = 0;
            this.lblTenBanNguonLabel.Text = "Tên bàn nguồn:";
            // 
            // grpBanDich
            // 
            this.grpBanDich.Controls.Add(this.cboBanDich);
            this.grpBanDich.Controls.Add(this.lblBanDichLabel);
            this.grpBanDich.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpBanDich.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.grpBanDich.Location = new System.Drawing.Point(20, 200);
            this.grpBanDich.Name = "grpBanDich";
            this.grpBanDich.Size = new System.Drawing.Size(390, 85);
            this.grpBanDich.TabIndex = 2;
            this.grpBanDich.TabStop = false;
            this.grpBanDich.Text = "Chọn bàn đích (Bàn đến)";
            // 
            // cboBanDich
            // 
            this.cboBanDich.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBanDich.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboBanDich.FormattingEnabled = true;
            this.cboBanDich.Location = new System.Drawing.Point(140, 33);
            this.cboBanDich.Name = "cboBanDich";
            this.cboBanDich.Size = new System.Drawing.Size(235, 31);
            this.cboBanDich.TabIndex = 1;
            // 
            // lblBanDichLabel
            // 
            this.lblBanDichLabel.AutoSize = true;
            this.lblBanDichLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBanDichLabel.Location = new System.Drawing.Point(15, 38);
            this.lblBanDichLabel.Name = "lblBanDichLabel";
            this.lblBanDichLabel.Size = new System.Drawing.Size(110, 20);
            this.lblBanDichLabel.TabIndex = 0;
            this.lblBanDichLabel.Text = "Bàn trống đích:";
            // 
            // btnXacNhanChuyen
            // 
            this.btnXacNhanChuyen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnXacNhanChuyen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXacNhanChuyen.FlatAppearance.BorderSize = 0;
            this.btnXacNhanChuyen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXacNhanChuyen.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXacNhanChuyen.ForeColor = System.Drawing.Color.White;
            this.btnXacNhanChuyen.Location = new System.Drawing.Point(95, 305);
            this.btnXacNhanChuyen.Name = "btnXacNhanChuyen";
            this.btnXacNhanChuyen.Size = new System.Drawing.Size(150, 40);
            this.btnXacNhanChuyen.TabIndex = 3;
            this.btnXacNhanChuyen.Text = "🔄 Xác nhận chuyển";
            this.btnXacNhanChuyen.UseVisualStyleBackColor = false;
            // 
            // btnHuy
            // 
            this.btnHuy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnHuy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHuy.FlatAppearance.BorderSize = 0;
            this.btnHuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuy.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuy.ForeColor = System.Drawing.Color.White;
            this.btnHuy.Location = new System.Drawing.Point(260, 305);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(110, 40);
            this.btnHuy.TabIndex = 4;
            this.btnHuy.Text = "❌ Hủy";
            this.btnHuy.UseVisualStyleBackColor = false;
            // 
            // FrmChuyenBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(430, 365);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnXacNhanChuyen);
            this.Controls.Add(this.grpBanDich);
            this.Controls.Add(this.grpBanNguon);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmChuyenBan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chuyển bàn";
            this.pnlHeader.ResumeLayout(false);
            this.grpBanNguon.ResumeLayout(false);
            this.grpBanNguon.PerformLayout();
            this.grpBanDich.ResumeLayout(false);
            this.grpBanDich.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox grpBanNguon;
        private System.Windows.Forms.Label lblTenBanNguonLabel;
        private System.Windows.Forms.Label lblTenBanNguonVal;
        private System.Windows.Forms.Label lblMaHDLabel;
        private System.Windows.Forms.Label lblMaHDVal;
        private System.Windows.Forms.Label lblTamTinhLabel;
        private System.Windows.Forms.Label lblTamTinhVal;
        private System.Windows.Forms.GroupBox grpBanDich;
        private System.Windows.Forms.Label lblBanDichLabel;
        private System.Windows.Forms.ComboBox cboBanDich;
        private System.Windows.Forms.Button btnXacNhanChuyen;
        private System.Windows.Forms.Button btnHuy;
    }
}
