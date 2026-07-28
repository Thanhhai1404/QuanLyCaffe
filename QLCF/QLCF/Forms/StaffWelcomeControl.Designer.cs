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
            this.components = new System.ComponentModel.Container();
            this.pnlCenterCard = new System.Windows.Forms.Panel();
            this.btnMoBanHang = new System.Windows.Forms.Button();
            this.btnKetCa = new System.Windows.Forms.Button();
            this.btnVaoCa = new System.Windows.Forms.Button();
            this.pnlShiftStatus = new System.Windows.Forms.Panel();
            this.lblShiftStatus = new System.Windows.Forms.Label();
            this.lblRealtimeClock = new System.Windows.Forms.Label();
            this.lblWelcomeTitle = new System.Windows.Forms.Label();
            this.lblHeaderBadge = new System.Windows.Forms.Label();
            this.timerClock = new System.Windows.Forms.Timer(this.components);
            this.pnlCenterCard.SuspendLayout();
            this.pnlShiftStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlCenterCard
            // 
            this.pnlCenterCard.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlCenterCard.BackColor = System.Drawing.Color.White;
            this.pnlCenterCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCenterCard.Controls.Add(this.btnMoBanHang);
            this.pnlCenterCard.Controls.Add(this.btnKetCa);
            this.pnlCenterCard.Controls.Add(this.btnVaoCa);
            this.pnlCenterCard.Controls.Add(this.pnlShiftStatus);
            this.pnlCenterCard.Controls.Add(this.lblRealtimeClock);
            this.pnlCenterCard.Controls.Add(this.lblWelcomeTitle);
            this.pnlCenterCard.Controls.Add(this.lblHeaderBadge);
            this.pnlCenterCard.Location = new System.Drawing.Point(175, 50);
            this.pnlCenterCard.Name = "pnlCenterCard";
            this.pnlCenterCard.Padding = new System.Windows.Forms.Padding(30);
            this.pnlCenterCard.Size = new System.Drawing.Size(600, 460);
            this.pnlCenterCard.TabIndex = 0;
            // 
            // btnMoBanHang
            // 
            this.btnMoBanHang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(119)))), ((int)(((byte)(6)))));
            this.btnMoBanHang.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMoBanHang.FlatAppearance.BorderSize = 0;
            this.btnMoBanHang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMoBanHang.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnMoBanHang.ForeColor = System.Drawing.Color.White;
            this.btnMoBanHang.Location = new System.Drawing.Point(40, 360);
            this.btnMoBanHang.Name = "btnMoBanHang";
            this.btnMoBanHang.Size = new System.Drawing.Size(520, 50);
            this.btnMoBanHang.TabIndex = 6;
            this.btnMoBanHang.Text = "🛒 Mở Màn Hình Bán Hàng";
            this.btnMoBanHang.UseVisualStyleBackColor = false;
            // 
            // btnKetCa
            // 
            this.btnKetCa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.btnKetCa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKetCa.FlatAppearance.BorderSize = 0;
            this.btnKetCa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKetCa.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnKetCa.ForeColor = System.Drawing.Color.White;
            this.btnKetCa.Location = new System.Drawing.Point(310, 290);
            this.btnKetCa.Name = "btnKetCa";
            this.btnKetCa.Size = new System.Drawing.Size(250, 45);
            this.btnKetCa.TabIndex = 5;
            this.btnKetCa.Text = "🔴 Kết Ca / Đăng Xuất Ca";
            this.btnKetCa.UseVisualStyleBackColor = false;
            // 
            // btnVaoCa
            // 
            this.btnVaoCa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.btnVaoCa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVaoCa.FlatAppearance.BorderSize = 0;
            this.btnVaoCa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVaoCa.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnVaoCa.ForeColor = System.Drawing.Color.White;
            this.btnVaoCa.Location = new System.Drawing.Point(40, 290);
            this.btnVaoCa.Name = "btnVaoCa";
            this.btnVaoCa.Size = new System.Drawing.Size(250, 45);
            this.btnVaoCa.TabIndex = 4;
            this.btnVaoCa.Text = "🟢 Vào Ca / Điểm Danh";
            this.btnVaoCa.UseVisualStyleBackColor = false;
            // 
            // pnlShiftStatus
            // 
            this.pnlShiftStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.pnlShiftStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlShiftStatus.Controls.Add(this.lblShiftStatus);
            this.pnlShiftStatus.Location = new System.Drawing.Point(40, 200);
            this.pnlShiftStatus.Name = "pnlShiftStatus";
            this.pnlShiftStatus.Size = new System.Drawing.Size(520, 60);
            this.pnlShiftStatus.TabIndex = 3;
            // 
            // lblShiftStatus
            // 
            this.lblShiftStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblShiftStatus.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblShiftStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.lblShiftStatus.Location = new System.Drawing.Point(0, 0);
            this.lblShiftStatus.Name = "lblShiftStatus";
            this.lblShiftStatus.Size = new System.Drawing.Size(518, 58);
            this.lblShiftStatus.TabIndex = 0;
            this.lblShiftStatus.Text = "Chưa điểm danh vào ca";
            this.lblShiftStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRealtimeClock
            // 
            this.lblRealtimeClock.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic);
            this.lblRealtimeClock.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblRealtimeClock.Location = new System.Drawing.Point(30, 150);
            this.lblRealtimeClock.Name = "lblRealtimeClock";
            this.lblRealtimeClock.Size = new System.Drawing.Size(540, 25);
            this.lblRealtimeClock.TabIndex = 2;
            this.lblRealtimeClock.Text = "00:00:00 - 01/01/2000";
            this.lblRealtimeClock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWelcomeTitle
            // 
            this.lblWelcomeTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold);
            this.lblWelcomeTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblWelcomeTitle.Location = new System.Drawing.Point(30, 95);
            this.lblWelcomeTitle.Name = "lblWelcomeTitle";
            this.lblWelcomeTitle.Size = new System.Drawing.Size(540, 45);
            this.lblWelcomeTitle.TabIndex = 1;
            this.lblWelcomeTitle.Text = "Chào, Nhân viên!";
            this.lblWelcomeTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHeaderBadge
            // 
            this.lblHeaderBadge.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblHeaderBadge.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(119)))), ((int)(((byte)(6)))));
            this.lblHeaderBadge.Location = new System.Drawing.Point(30, 45);
            this.lblHeaderBadge.Name = "lblHeaderBadge";
            this.lblHeaderBadge.Size = new System.Drawing.Size(540, 40);
            this.lblHeaderBadge.TabIndex = 0;
            this.lblHeaderBadge.Text = "• QLCF WORKSPACE && POS •";
            this.lblHeaderBadge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timerClock
            // 
            this.timerClock.Interval = 1000;
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
            this.pnlShiftStatus.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlCenterCard;
        private System.Windows.Forms.Label lblHeaderBadge;
        private System.Windows.Forms.Label lblWelcomeTitle;
        private System.Windows.Forms.Label lblRealtimeClock;
        private System.Windows.Forms.Panel pnlShiftStatus;
        private System.Windows.Forms.Label lblShiftStatus;
        private System.Windows.Forms.Button btnVaoCa;
        private System.Windows.Forms.Button btnKetCa;
        private System.Windows.Forms.Button btnMoBanHang;
        private System.Windows.Forms.Timer timerClock;
    }
}
