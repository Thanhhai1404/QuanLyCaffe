namespace QLCF.Forms
{
    partial class FrmChotSoCa
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            
            this.pnlCards = new System.Windows.Forms.TableLayoutPanel();
            this.pnlCard1 = new System.Windows.Forms.Panel();
            this.lblCard1Title = new System.Windows.Forms.Label();
            this.lblTongDoanhThu = new System.Windows.Forms.Label();
            
            this.pnlCard2 = new System.Windows.Forms.Panel();
            this.lblCard2Title = new System.Windows.Forms.Label();
            this.lblDoanhThuTienMat = new System.Windows.Forms.Label();
            
            this.pnlCard3 = new System.Windows.Forms.Panel();
            this.lblCard3Title = new System.Windows.Forms.Label();
            this.lblDoanhThuChuyenKhoan = new System.Windows.Forms.Label();

            this.pnlForm = new System.Windows.Forms.Panel();
            this.lblTienDauCa = new System.Windows.Forms.Label();
            this.txtTienDauCa = new System.Windows.Forms.TextBox();
            this.lblDoanhThuMat2 = new System.Windows.Forms.Label();
            this.txtDoanhThuMat2 = new System.Windows.Forms.TextBox();
            this.lblTienLyThuyet = new System.Windows.Forms.Label();
            this.txtTienLyThuyet = new System.Windows.Forms.TextBox();
            
            this.lblTienThucTe = new System.Windows.Forms.Label();
            this.txtTienThucTe = new System.Windows.Forms.TextBox();
            this.lblChenhLech = new System.Windows.Forms.Label();
            this.txtChenhLech = new System.Windows.Forms.TextBox();
            
            this.btnInBaoCao = new System.Windows.Forms.Button();
            this.btnXuatExcel = new System.Windows.Forms.Button();
            this.btnXacNhan = new System.Windows.Forms.Button();

            this.pnlHeader.SuspendLayout();
            this.pnlCards.SuspendLayout();
            this.pnlCard1.SuspendLayout();
            this.pnlCard2.SuspendLayout();
            this.pnlCard3.SuspendLayout();
            this.pnlForm.SuspendLayout();
            this.SuspendLayout();
            
            // pnlHeader
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblInfo);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(650, 100);
            
            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(350, 30);
            this.lblTitle.Text = "☕ CHỐT SỔ CA LÀM VIỆC";
            
            // lblInfo
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblInfo.ForeColor = System.Drawing.Color.LightGray;
            this.lblInfo.Location = new System.Drawing.Point(22, 60);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(300, 19);
            this.lblInfo.Text = "Nhân viên: ... | Thời gian: ...";
            
            // pnlCards
            this.pnlCards.ColumnCount = 3;
            this.pnlCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.pnlCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.pnlCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.pnlCards.Controls.Add(this.pnlCard1, 0, 0);
            this.pnlCards.Controls.Add(this.pnlCard2, 1, 0);
            this.pnlCards.Controls.Add(this.pnlCard3, 2, 0);
            this.pnlCards.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCards.Location = new System.Drawing.Point(0, 100);
            this.pnlCards.Name = "pnlCards";
            this.pnlCards.Size = new System.Drawing.Size(650, 120);
            
            // pnlCard1
            this.pnlCard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.pnlCard1.Controls.Add(this.lblCard1Title);
            this.pnlCard1.Controls.Add(this.lblTongDoanhThu);
            this.pnlCard1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCard1.Margin = new System.Windows.Forms.Padding(10);
            this.pnlCard1.Name = "pnlCard1";
            
            // lblCard1Title
            this.lblCard1Title.AutoSize = true;
            this.lblCard1Title.ForeColor = System.Drawing.Color.LightGray;
            this.lblCard1Title.Location = new System.Drawing.Point(10, 15);
            this.lblCard1Title.Text = "Tổng doanh thu";
            this.lblCard1Title.Font = new System.Drawing.Font("Segoe UI", 10F);
            
            // lblTongDoanhThu
            this.lblTongDoanhThu.AutoSize = true;
            this.lblTongDoanhThu.ForeColor = System.Drawing.Color.Gold;
            this.lblTongDoanhThu.Location = new System.Drawing.Point(10, 45);
            this.lblTongDoanhThu.Text = "0 đ";
            this.lblTongDoanhThu.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            
            // pnlCard2
            this.pnlCard2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.pnlCard2.Controls.Add(this.lblCard2Title);
            this.pnlCard2.Controls.Add(this.lblDoanhThuTienMat);
            this.pnlCard2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCard2.Margin = new System.Windows.Forms.Padding(10);
            this.pnlCard2.Name = "pnlCard2";
            
            // lblCard2Title
            this.lblCard2Title.AutoSize = true;
            this.lblCard2Title.ForeColor = System.Drawing.Color.White;
            this.lblCard2Title.Location = new System.Drawing.Point(10, 15);
            this.lblCard2Title.Text = "Doanh thu tiền mặt";
            this.lblCard2Title.Font = new System.Drawing.Font("Segoe UI", 10F);
            
            // lblDoanhThuTienMat
            this.lblDoanhThuTienMat.AutoSize = true;
            this.lblDoanhThuTienMat.ForeColor = System.Drawing.Color.White;
            this.lblDoanhThuTienMat.Location = new System.Drawing.Point(10, 45);
            this.lblDoanhThuTienMat.Text = "0 đ";
            this.lblDoanhThuTienMat.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            
            // pnlCard3
            this.pnlCard3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(132)))), ((int)(((byte)(199)))));
            this.pnlCard3.Controls.Add(this.lblCard3Title);
            this.pnlCard3.Controls.Add(this.lblDoanhThuChuyenKhoan);
            this.pnlCard3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCard3.Margin = new System.Windows.Forms.Padding(10);
            this.pnlCard3.Name = "pnlCard3";
            
            // lblCard3Title
            this.lblCard3Title.AutoSize = true;
            this.lblCard3Title.ForeColor = System.Drawing.Color.White;
            this.lblCard3Title.Location = new System.Drawing.Point(10, 15);
            this.lblCard3Title.Text = "Chuyển khoản / QR";
            this.lblCard3Title.Font = new System.Drawing.Font("Segoe UI", 10F);
            
            // lblDoanhThuChuyenKhoan
            this.lblDoanhThuChuyenKhoan.AutoSize = true;
            this.lblDoanhThuChuyenKhoan.ForeColor = System.Drawing.Color.White;
            this.lblDoanhThuChuyenKhoan.Location = new System.Drawing.Point(10, 45);
            this.lblDoanhThuChuyenKhoan.Text = "0 đ";
            this.lblDoanhThuChuyenKhoan.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            
            // pnlForm
            this.pnlForm.BackColor = System.Drawing.Color.White;
            this.pnlForm.Controls.Add(this.lblTienDauCa);
            this.pnlForm.Controls.Add(this.txtTienDauCa);
            this.pnlForm.Controls.Add(this.lblDoanhThuMat2);
            this.pnlForm.Controls.Add(this.txtDoanhThuMat2);
            this.pnlForm.Controls.Add(this.lblTienLyThuyet);
            this.pnlForm.Controls.Add(this.txtTienLyThuyet);
            this.pnlForm.Controls.Add(this.lblTienThucTe);
            this.pnlForm.Controls.Add(this.txtTienThucTe);
            this.pnlForm.Controls.Add(this.lblChenhLech);
            this.pnlForm.Controls.Add(this.txtChenhLech);
            this.pnlForm.Location = new System.Drawing.Point(20, 230);
            this.pnlForm.Name = "pnlForm";
            this.pnlForm.Size = new System.Drawing.Size(610, 270);
            
            // lblTienDauCa
            this.lblTienDauCa.AutoSize = true;
            this.lblTienDauCa.Location = new System.Drawing.Point(20, 20);
            this.lblTienDauCa.Text = "[+] Tiền thối đầu ca:";
            this.lblTienDauCa.Font = new System.Drawing.Font("Segoe UI", 10F);
            
            this.txtTienDauCa.Location = new System.Drawing.Point(200, 17);
            this.txtTienDauCa.Size = new System.Drawing.Size(380, 25);
            this.txtTienDauCa.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtTienDauCa.Text = "0";
            
            // lblDoanhThuMat2
            this.lblDoanhThuMat2.AutoSize = true;
            this.lblDoanhThuMat2.Location = new System.Drawing.Point(20, 70);
            this.lblDoanhThuMat2.Text = "[+] Doanh thu tiền mặt:";
            this.lblDoanhThuMat2.Font = new System.Drawing.Font("Segoe UI", 10F);
            
            this.txtDoanhThuMat2.Location = new System.Drawing.Point(200, 67);
            this.txtDoanhThuMat2.Size = new System.Drawing.Size(380, 25);
            this.txtDoanhThuMat2.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtDoanhThuMat2.ReadOnly = true;
            this.txtDoanhThuMat2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtDoanhThuMat2.Text = "0";
            
            // lblTienLyThuyet
            this.lblTienLyThuyet.AutoSize = true;
            this.lblTienLyThuyet.Location = new System.Drawing.Point(20, 120);
            this.lblTienLyThuyet.Text = "[=] Tiền két lý thuyết:";
            this.lblTienLyThuyet.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            
            this.txtTienLyThuyet.Location = new System.Drawing.Point(200, 117);
            this.txtTienLyThuyet.Size = new System.Drawing.Size(380, 25);
            this.txtTienLyThuyet.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.txtTienLyThuyet.ReadOnly = true;
            this.txtTienLyThuyet.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtTienLyThuyet.Text = "0";
            
            // lblTienThucTe
            this.lblTienThucTe.AutoSize = true;
            this.lblTienThucTe.Location = new System.Drawing.Point(20, 170);
            this.lblTienThucTe.Text = "Tiền két thực tế đếm:";
            this.lblTienThucTe.Font = new System.Drawing.Font("Segoe UI", 10F);
            
            this.txtTienThucTe.Location = new System.Drawing.Point(200, 167);
            this.txtTienThucTe.Size = new System.Drawing.Size(380, 25);
            this.txtTienThucTe.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtTienThucTe.Text = "0";
            
            // lblChenhLech
            this.lblChenhLech.AutoSize = true;
            this.lblChenhLech.Location = new System.Drawing.Point(20, 220);
            this.lblChenhLech.Text = "[=] Chênh lệch:";
            this.lblChenhLech.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            
            this.txtChenhLech.Location = new System.Drawing.Point(200, 217);
            this.txtChenhLech.Size = new System.Drawing.Size(380, 25);
            this.txtChenhLech.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.txtChenhLech.ReadOnly = true;
            this.txtChenhLech.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtChenhLech.Text = "0";
            
            // Buttons
            this.btnInBaoCao.Location = new System.Drawing.Point(20, 520);
            this.btnInBaoCao.Size = new System.Drawing.Size(120, 40);
            this.btnInBaoCao.Text = "🖨️ In Báo Cáo";
            this.btnInBaoCao.BackColor = System.Drawing.Color.White;
            this.btnInBaoCao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInBaoCao.Font = new System.Drawing.Font("Segoe UI", 10F);
            
            this.btnXuatExcel.Location = new System.Drawing.Point(150, 520);
            this.btnXuatExcel.Size = new System.Drawing.Size(120, 40);
            this.btnXuatExcel.Text = "📊 Xuất Excel";
            this.btnXuatExcel.BackColor = System.Drawing.Color.White;
            this.btnXuatExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXuatExcel.Font = new System.Drawing.Font("Segoe UI", 10F);
            
            this.btnXacNhan.Location = new System.Drawing.Point(380, 520);
            this.btnXacNhan.Size = new System.Drawing.Size(250, 40);
            this.btnXacNhan.Text = "✅ Xác Nhận Kết Ca & Đăng Xuất";
            this.btnXacNhan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.btnXacNhan.ForeColor = System.Drawing.Color.White;
            this.btnXacNhan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXacNhan.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            
            // FrmChotSoCa
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(650, 590);
            this.Controls.Add(this.btnXacNhan);
            this.Controls.Add(this.btnXuatExcel);
            this.Controls.Add(this.btnInBaoCao);
            this.Controls.Add(this.pnlForm);
            this.Controls.Add(this.pnlCards);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chốt Sổ Ca Làm Việc";

            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlCards.ResumeLayout(false);
            this.pnlCard1.ResumeLayout(false);
            this.pnlCard1.PerformLayout();
            this.pnlCard2.ResumeLayout(false);
            this.pnlCard2.PerformLayout();
            this.pnlCard3.ResumeLayout(false);
            this.pnlCard3.PerformLayout();
            this.pnlForm.ResumeLayout(false);
            this.pnlForm.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.TableLayoutPanel pnlCards;
        private System.Windows.Forms.Panel pnlCard1;
        private System.Windows.Forms.Label lblCard1Title;
        private System.Windows.Forms.Label lblTongDoanhThu;
        private System.Windows.Forms.Panel pnlCard2;
        private System.Windows.Forms.Label lblCard2Title;
        private System.Windows.Forms.Label lblDoanhThuTienMat;
        private System.Windows.Forms.Panel pnlCard3;
        private System.Windows.Forms.Label lblCard3Title;
        private System.Windows.Forms.Label lblDoanhThuChuyenKhoan;
        
        private System.Windows.Forms.Panel pnlForm;
        private System.Windows.Forms.Label lblTienDauCa;
        private System.Windows.Forms.TextBox txtTienDauCa;
        private System.Windows.Forms.Label lblDoanhThuMat2;
        private System.Windows.Forms.TextBox txtDoanhThuMat2;
        private System.Windows.Forms.Label lblTienLyThuyet;
        private System.Windows.Forms.TextBox txtTienLyThuyet;
        private System.Windows.Forms.Label lblTienThucTe;
        private System.Windows.Forms.TextBox txtTienThucTe;
        private System.Windows.Forms.Label lblChenhLech;
        private System.Windows.Forms.TextBox txtChenhLech;
        
        private System.Windows.Forms.Button btnInBaoCao;
        private System.Windows.Forms.Button btnXuatExcel;
        private System.Windows.Forms.Button btnXacNhan;
    }
}
