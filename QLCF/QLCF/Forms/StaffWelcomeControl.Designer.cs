namespace QLCF.Forms
{
    partial class StaffWelcomeControl
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

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.pnlCenterCard = new System.Windows.Forms.Panel();
            this.btnMoBanHang = new System.Windows.Forms.Button();
            this.lblWelcomeSub = new System.Windows.Forms.Label();
            this.lblWelcomeTitle = new System.Windows.Forms.Label();
            this.lblHeaderBadge = new System.Windows.Forms.Label();
            this.pnlCenterCard.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlCenterCard
            // 
            this.pnlCenterCard.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlCenterCard.BackColor = System.Drawing.Color.White;
            this.pnlCenterCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCenterCard.Controls.Add(this.btnMoBanHang);
            this.pnlCenterCard.Controls.Add(this.lblWelcomeSub);
            this.pnlCenterCard.Controls.Add(this.lblWelcomeTitle);
            this.pnlCenterCard.Controls.Add(this.lblHeaderBadge);
            this.pnlCenterCard.Location = new System.Drawing.Point(175, 80);
            this.pnlCenterCard.Name = "pnlCenterCard";
            this.pnlCenterCard.Padding = new System.Windows.Forms.Padding(30);
            this.pnlCenterCard.Size = new System.Drawing.Size(600, 360);
            this.pnlCenterCard.TabIndex = 0;
            // 
            // btnMoBanHang
            // 
            this.btnMoBanHang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(98)))), ((int)(((byte)(14)))));
            this.btnMoBanHang.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMoBanHang.FlatAppearance.BorderSize = 0;
            this.btnMoBanHang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMoBanHang.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Bold);
            this.btnMoBanHang.ForeColor = System.Drawing.Color.White;
            this.btnMoBanHang.Location = new System.Drawing.Point(150, 240);
            this.btnMoBanHang.Name = "btnMoBanHang";
            this.btnMoBanHang.Size = new System.Drawing.Size(300, 55);
            this.btnMoBanHang.TabIndex = 3;
            this.btnMoBanHang.Text = "Mở màn hình bán hàng";
            this.btnMoBanHang.UseVisualStyleBackColor = false;
            // 
            // lblWelcomeSub
            // 
            this.lblWelcomeSub.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.lblWelcomeSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblWelcomeSub.Location = new System.Drawing.Point(30, 175);
            this.lblWelcomeSub.Name = "lblWelcomeSub";
            this.lblWelcomeSub.Size = new System.Drawing.Size(540, 30);
            this.lblWelcomeSub.TabIndex = 2;
            this.lblWelcomeSub.Text = "Chọn \"Mở màn hình bán hàng\" để bắt đầu phục vụ khách hàng.";
            this.lblWelcomeSub.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWelcomeTitle
            // 
            this.lblWelcomeTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblWelcomeTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblWelcomeTitle.Location = new System.Drawing.Point(30, 120);
            this.lblWelcomeTitle.Name = "lblWelcomeTitle";
            this.lblWelcomeTitle.Size = new System.Drawing.Size(540, 45);
            this.lblWelcomeTitle.TabIndex = 1;
            this.lblWelcomeTitle.Text = "CHÀO MỪNG NHÂN VIÊN!";
            this.lblWelcomeTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHeaderBadge
            // 
            this.lblHeaderBadge.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblHeaderBadge.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(98)))), ((int)(((byte)(14)))));
            this.lblHeaderBadge.Location = new System.Drawing.Point(30, 45);
            this.lblHeaderBadge.Name = "lblHeaderBadge";
            this.lblHeaderBadge.Size = new System.Drawing.Size(540, 40);
            this.lblHeaderBadge.TabIndex = 0;
            this.lblHeaderBadge.Text = "• QLCF POS SYSTEM •";
            this.lblHeaderBadge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // StaffWelcomeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.Controls.Add(this.pnlCenterCard);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "StaffWelcomeControl";
            this.Size = new System.Drawing.Size(950, 560);
            this.pnlCenterCard.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlCenterCard;
        private System.Windows.Forms.Label lblHeaderBadge;
        private System.Windows.Forms.Label lblWelcomeTitle;
        private System.Windows.Forms.Label lblWelcomeSub;
        private System.Windows.Forms.Button btnMoBanHang;
    }
}
