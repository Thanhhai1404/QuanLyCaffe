using System.Drawing;
using System.Windows.Forms;

namespace QLCF.Forms
{
    partial class FrmXemTruocBill
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitleBar = new System.Windows.Forms.Label();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnQuayLai = new System.Windows.Forms.Button();
            this.btnXuatBillHoanTat = new System.Windows.Forms.Button();
            this.pnlMainScroll = new System.Windows.Forms.Panel();
            this.pnlPaper = new System.Windows.Forms.Panel();
            this.lblFooterMsg = new System.Windows.Forms.Label();
            this.lblDivider3 = new System.Windows.Forms.Label();
            this.pnlSummary = new System.Windows.Forms.Panel();
            this.lblTienTraLaiVal = new System.Windows.Forms.Label();
            this.lblTienTraLaiLabel = new System.Windows.Forms.Label();
            this.lblTienKhachDuaVal = new System.Windows.Forms.Label();
            this.lblTienKhachDuaLabel = new System.Windows.Forms.Label();
            this.lblPhuongThucVal = new System.Windows.Forms.Label();
            this.lblPhuongThucLabel = new System.Windows.Forms.Label();
            this.lblTongCanThanhToanVal = new System.Windows.Forms.Label();
            this.lblTongCanThanhToanLabel = new System.Windows.Forms.Label();
            this.lblSoTienGiamVal = new System.Windows.Forms.Label();
            this.lblSoTienGiamLabel = new System.Windows.Forms.Label();
            this.lblTongTienGocVal = new System.Windows.Forms.Label();
            this.lblTongTienGocLabel = new System.Windows.Forms.Label();
            this.lblDivider2 = new System.Windows.Forms.Label();
            this.dgvMonAn = new System.Windows.Forms.DataGridView();
            this.colTenMon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDonGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThanhTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblDivider1 = new System.Windows.Forms.Label();
            this.lblThuNgan = new System.Windows.Forms.Label();
            this.lblTenBan = new System.Windows.Forms.Label();
            this.lblNgayGio = new System.Windows.Forms.Label();
            this.lblMaHD = new System.Windows.Forms.Label();
            this.lblTieuDeBill = new System.Windows.Forms.Label();
            this.lblStorePhone = new System.Windows.Forms.Label();
            this.lblStoreAddress = new System.Windows.Forms.Label();
            this.lblStoreName = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlMainScroll.SuspendLayout();
            this.pnlPaper.SuspendLayout();
            this.pnlSummary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonAn)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.pnlHeader.Controls.Add(this.lblTitleBar);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(430, 50);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitleBar
            // 
            this.lblTitleBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitleBar.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleBar.ForeColor = System.Drawing.Color.White;
            this.lblTitleBar.Location = new System.Drawing.Point(0, 0);
            this.lblTitleBar.Name = "lblTitleBar";
            this.lblTitleBar.Size = new System.Drawing.Size(430, 50);
            this.lblTitleBar.TabIndex = 0;
            this.lblTitleBar.Text = "🧾 XEM TRƯỚC HÓA ĐƠN (BILL PREVIEW)";
            this.lblTitleBar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlBottom
            // 
            this.pnlBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.pnlBottom.Controls.Add(this.btnQuayLai);
            this.pnlBottom.Controls.Add(this.btnXuatBillHoanTat);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 640);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Padding = new System.Windows.Forms.Padding(12, 10, 12, 10);
            this.pnlBottom.Size = new System.Drawing.Size(430, 65);
            this.pnlBottom.TabIndex = 1;
            // 
            // btnQuayLai
            // 
            this.btnQuayLai.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.btnQuayLai.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuayLai.FlatAppearance.BorderSize = 0;
            this.btnQuayLai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuayLai.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuayLai.ForeColor = System.Drawing.Color.White;
            this.btnQuayLai.Location = new System.Drawing.Point(12, 11);
            this.btnQuayLai.Name = "btnQuayLai";
            this.btnQuayLai.Size = new System.Drawing.Size(115, 43);
            this.btnQuayLai.TabIndex = 1;
            this.btnQuayLai.Text = "⬅ Quay lại";
            this.btnQuayLai.UseVisualStyleBackColor = false;
            // 
            // btnXuatBillHoanTat
            // 
            this.btnXuatBillHoanTat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(150)))), ((int)(((byte)(105)))));
            this.btnXuatBillHoanTat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXuatBillHoanTat.FlatAppearance.BorderSize = 0;
            this.btnXuatBillHoanTat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXuatBillHoanTat.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXuatBillHoanTat.ForeColor = System.Drawing.Color.White;
            this.btnXuatBillHoanTat.Location = new System.Drawing.Point(135, 11);
            this.btnXuatBillHoanTat.Name = "btnXuatBillHoanTat";
            this.btnXuatBillHoanTat.Size = new System.Drawing.Size(283, 43);
            this.btnXuatBillHoanTat.TabIndex = 0;
            this.btnXuatBillHoanTat.Text = "🧾 XUẤT BILL & HOÀN TẤT";
            this.btnXuatBillHoanTat.UseVisualStyleBackColor = false;
            // 
            // pnlMainScroll
            // 
            this.pnlMainScroll.AutoScroll = true;
            this.pnlMainScroll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.pnlMainScroll.Controls.Add(this.pnlPaper);
            this.pnlMainScroll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainScroll.Location = new System.Drawing.Point(0, 50);
            this.pnlMainScroll.Name = "pnlMainScroll";
            this.pnlMainScroll.Padding = new System.Windows.Forms.Padding(15);
            this.pnlMainScroll.Size = new System.Drawing.Size(430, 590);
            this.pnlMainScroll.TabIndex = 2;
            // 
            // pnlPaper
            // 
            this.pnlPaper.AutoSize = true;
            this.pnlPaper.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlPaper.BackColor = System.Drawing.Color.White;
            this.pnlPaper.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPaper.Controls.Add(this.lblFooterMsg);
            this.pnlPaper.Controls.Add(this.lblDivider3);
            this.pnlPaper.Controls.Add(this.pnlSummary);
            this.pnlPaper.Controls.Add(this.lblDivider2);
            this.pnlPaper.Controls.Add(this.dgvMonAn);
            this.pnlPaper.Controls.Add(this.lblDivider1);
            this.pnlPaper.Controls.Add(this.lblThuNgan);
            this.pnlPaper.Controls.Add(this.lblTenBan);
            this.pnlPaper.Controls.Add(this.lblNgayGio);
            this.pnlPaper.Controls.Add(this.lblMaHD);
            this.pnlPaper.Controls.Add(this.lblTieuDeBill);
            this.pnlPaper.Controls.Add(this.lblStorePhone);
            this.pnlPaper.Controls.Add(this.lblStoreAddress);
            this.pnlPaper.Controls.Add(this.lblStoreName);
            this.pnlPaper.Location = new System.Drawing.Point(15, 12);
            this.pnlPaper.MaximumSize = new System.Drawing.Size(380, 0);
            this.pnlPaper.MinimumSize = new System.Drawing.Size(380, 500);
            this.pnlPaper.Name = "pnlPaper";
            this.pnlPaper.Padding = new System.Windows.Forms.Padding(14, 14, 14, 40);
            this.pnlPaper.Size = new System.Drawing.Size(380, 550);
            this.pnlPaper.TabIndex = 0;
            // 
            // lblFooterMsg
            // 
            this.lblFooterMsg.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblFooterMsg.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFooterMsg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblFooterMsg.Location = new System.Drawing.Point(14, 495);
            this.lblFooterMsg.Name = "lblFooterMsg";
            this.lblFooterMsg.Size = new System.Drawing.Size(350, 55);
            this.lblFooterMsg.TabIndex = 13;
            this.lblFooterMsg.Text = "Cảm ơn quý khách & Hẹn gặp lại!";
            this.lblFooterMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDivider3
            // 
            this.lblDivider3.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDivider3.Font = new System.Drawing.Font("Consolas", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDivider3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblDivider3.Location = new System.Drawing.Point(14, 477);
            this.lblDivider3.Name = "lblDivider3";
            this.lblDivider3.Size = new System.Drawing.Size(350, 18);
            this.lblDivider3.TabIndex = 12;
            this.lblDivider3.Text = "--------------------------------------------------";
            this.lblDivider3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlSummary
            // 
            this.pnlSummary.Controls.Add(this.lblTienTraLaiVal);
            this.pnlSummary.Controls.Add(this.lblTienTraLaiLabel);
            this.pnlSummary.Controls.Add(this.lblTienKhachDuaVal);
            this.pnlSummary.Controls.Add(this.lblTienKhachDuaLabel);
            this.pnlSummary.Controls.Add(this.lblPhuongThucVal);
            this.pnlSummary.Controls.Add(this.lblPhuongThucLabel);
            this.pnlSummary.Controls.Add(this.lblTongCanThanhToanVal);
            this.pnlSummary.Controls.Add(this.lblTongCanThanhToanLabel);
            this.pnlSummary.Controls.Add(this.lblSoTienGiamVal);
            this.pnlSummary.Controls.Add(this.lblSoTienGiamLabel);
            this.pnlSummary.Controls.Add(this.lblTongTienGocVal);
            this.pnlSummary.Controls.Add(this.lblTongTienGocLabel);
            this.pnlSummary.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSummary.Location = new System.Drawing.Point(14, 327);
            this.pnlSummary.Name = "pnlSummary";
            this.pnlSummary.Size = new System.Drawing.Size(350, 150);
            this.pnlSummary.TabIndex = 11;
            // 
            // lblTienTraLaiVal
            // 
            this.lblTienTraLaiVal.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTienTraLaiVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.lblTienTraLaiVal.Location = new System.Drawing.Point(175, 122);
            this.lblTienTraLaiVal.Name = "lblTienTraLaiVal";
            this.lblTienTraLaiVal.Size = new System.Drawing.Size(170, 22);
            this.lblTienTraLaiVal.TabIndex = 11;
            this.lblTienTraLaiVal.Text = "0 đ";
            this.lblTienTraLaiVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTienTraLaiLabel
            // 
            this.lblTienTraLaiLabel.AutoSize = true;
            this.lblTienTraLaiLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTienTraLaiLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblTienTraLaiLabel.Location = new System.Drawing.Point(5, 122);
            this.lblTienTraLaiLabel.Name = "lblTienTraLaiLabel";
            this.lblTienTraLaiLabel.Size = new System.Drawing.Size(83, 20);
            this.lblTienTraLaiLabel.TabIndex = 10;
            this.lblTienTraLaiLabel.Text = "Tiền trả lại:";
            // 
            // lblTienKhachDuaVal
            // 
            this.lblTienKhachDuaVal.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTienKhachDuaVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblTienKhachDuaVal.Location = new System.Drawing.Point(175, 98);
            this.lblTienKhachDuaVal.Name = "lblTienKhachDuaVal";
            this.lblTienKhachDuaVal.Size = new System.Drawing.Size(170, 22);
            this.lblTienKhachDuaVal.TabIndex = 9;
            this.lblTienKhachDuaVal.Text = "0 đ";
            this.lblTienKhachDuaVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTienKhachDuaLabel
            // 
            this.lblTienKhachDuaLabel.AutoSize = true;
            this.lblTienKhachDuaLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTienKhachDuaLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblTienKhachDuaLabel.Location = new System.Drawing.Point(5, 98);
            this.lblTienKhachDuaLabel.Name = "lblTienKhachDuaLabel";
            this.lblTienKhachDuaLabel.Size = new System.Drawing.Size(112, 20);
            this.lblTienKhachDuaLabel.TabIndex = 8;
            this.lblTienKhachDuaLabel.Text = "Tiền khách đưa:";
            // 
            // lblPhuongThucVal
            // 
            this.lblPhuongThucVal.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhuongThucVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblPhuongThucVal.Location = new System.Drawing.Point(175, 74);
            this.lblPhuongThucVal.Name = "lblPhuongThucVal";
            this.lblPhuongThucVal.Size = new System.Drawing.Size(170, 22);
            this.lblPhuongThucVal.TabIndex = 7;
            this.lblPhuongThucVal.Text = "Tiền mặt";
            this.lblPhuongThucVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPhuongThucLabel
            // 
            this.lblPhuongThucLabel.AutoSize = true;
            this.lblPhuongThucLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhuongThucLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblPhuongThucLabel.Location = new System.Drawing.Point(5, 74);
            this.lblPhuongThucLabel.Name = "lblPhuongThucLabel";
            this.lblPhuongThucLabel.Size = new System.Drawing.Size(121, 20);
            this.lblPhuongThucLabel.TabIndex = 6;
            this.lblPhuongThucLabel.Text = "Phương thức TT:";
            // 
            // lblTongCanThanhToanVal
            // 
            this.lblTongCanThanhToanVal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongCanThanhToanVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(150)))), ((int)(((byte)(105)))));
            this.lblTongCanThanhToanVal.Location = new System.Drawing.Point(165, 45);
            this.lblTongCanThanhToanVal.Name = "lblTongCanThanhToanVal";
            this.lblTongCanThanhToanVal.Size = new System.Drawing.Size(180, 26);
            this.lblTongCanThanhToanVal.TabIndex = 5;
            this.lblTongCanThanhToanVal.Text = "0 đ";
            this.lblTongCanThanhToanVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTongCanThanhToanLabel
            // 
            this.lblTongCanThanhToanLabel.AutoSize = true;
            this.lblTongCanThanhToanLabel.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongCanThanhToanLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblTongCanThanhToanLabel.Location = new System.Drawing.Point(5, 47);
            this.lblTongCanThanhToanLabel.Name = "lblTongCanThanhToanLabel";
            this.lblTongCanThanhToanLabel.Size = new System.Drawing.Size(127, 25);
            this.lblTongCanThanhToanLabel.TabIndex = 4;
            this.lblTongCanThanhToanLabel.Text = "TỔNG CỘNG:";
            // 
            // lblSoTienGiamVal
            // 
            this.lblSoTienGiamVal.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoTienGiamVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(29)))), ((int)(((byte)(72)))));
            this.lblSoTienGiamVal.Location = new System.Drawing.Point(175, 24);
            this.lblSoTienGiamVal.Name = "lblSoTienGiamVal";
            this.lblSoTienGiamVal.Size = new System.Drawing.Size(170, 20);
            this.lblSoTienGiamVal.TabIndex = 3;
            this.lblSoTienGiamVal.Text = "-0 đ (0%)";
            this.lblSoTienGiamVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSoTienGiamLabel
            // 
            this.lblSoTienGiamLabel.AutoSize = true;
            this.lblSoTienGiamLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoTienGiamLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblSoTienGiamLabel.Location = new System.Drawing.Point(5, 24);
            this.lblSoTienGiamLabel.Name = "lblSoTienGiamLabel";
            this.lblSoTienGiamLabel.Size = new System.Drawing.Size(72, 20);
            this.lblSoTienGiamLabel.TabIndex = 2;
            this.lblSoTienGiamLabel.Text = "Giảm giá:";
            // 
            // lblTongTienGocVal
            // 
            this.lblTongTienGocVal.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongTienGocVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblTongTienGocVal.Location = new System.Drawing.Point(175, 2);
            this.lblTongTienGocVal.Name = "lblTongTienGocVal";
            this.lblTongTienGocVal.Size = new System.Drawing.Size(170, 20);
            this.lblTongTienGocVal.TabIndex = 1;
            this.lblTongTienGocVal.Text = "0 đ";
            this.lblTongTienGocVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTongTienGocLabel
            // 
            this.lblTongTienGocLabel.AutoSize = true;
            this.lblTongTienGocLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongTienGocLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblTongTienGocLabel.Location = new System.Drawing.Point(5, 2);
            this.lblTongTienGocLabel.Name = "lblTongTienGocLabel";
            this.lblTongTienGocLabel.Size = new System.Drawing.Size(103, 20);
            this.lblTongTienGocLabel.TabIndex = 0;
            this.lblTongTienGocLabel.Text = "Tổng tiền gốc:";
            // 
            // lblDivider2
            // 
            this.lblDivider2.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDivider2.Font = new System.Drawing.Font("Consolas", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDivider2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblDivider2.Location = new System.Drawing.Point(14, 309);
            this.lblDivider2.Name = "lblDivider2";
            this.lblDivider2.Size = new System.Drawing.Size(350, 18);
            this.lblDivider2.TabIndex = 10;
            this.lblDivider2.Text = "--------------------------------------------------";
            this.lblDivider2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvMonAn
            // 
            this.dgvMonAn.AllowUserToAddRows = false;
            this.dgvMonAn.AllowUserToDeleteRows = false;
            this.dgvMonAn.AllowUserToResizeRows = false;
            this.dgvMonAn.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMonAn.BackgroundColor = System.Drawing.Color.White;
            this.dgvMonAn.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMonAn.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvMonAn.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMonAn.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMonAn.ColumnHeadersHeight = 26;
            this.dgvMonAn.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTenMon,
            this.colSoLuong,
            this.colDonGia,
            this.colThanhTien});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMonAn.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvMonAn.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dgvMonAn.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvMonAn.EnableHeadersVisualStyles = false;
            this.dgvMonAn.GridColor = System.Drawing.Color.White;
            this.dgvMonAn.Location = new System.Drawing.Point(14, 219);
            this.dgvMonAn.MultiSelect = false;
            this.dgvMonAn.Name = "dgvMonAn";
            this.dgvMonAn.ReadOnly = true;
            this.dgvMonAn.RowHeadersVisible = false;
            this.dgvMonAn.RowHeadersWidth = 51;
            this.dgvMonAn.RowTemplate.Height = 24;
            this.dgvMonAn.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMonAn.Size = new System.Drawing.Size(350, 90);
            this.dgvMonAn.TabIndex = 9;
            // 
            // colTenMon
            // 
            this.colTenMon.DataPropertyName = "TenMonHienThi";
            this.colTenMon.FillWeight = 140F;
            this.colTenMon.HeaderText = "Món";
            this.colTenMon.MinimumWidth = 100;
            this.colTenMon.Name = "colTenMon";
            this.colTenMon.ReadOnly = true;
            // 
            // colSoLuong
            // 
            this.colSoLuong.DataPropertyName = "SoLuong";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colSoLuong.DefaultCellStyle = dataGridViewCellStyle3;
            this.colSoLuong.FillWeight = 35F;
            this.colSoLuong.HeaderText = "SL";
            this.colSoLuong.MinimumWidth = 28;
            this.colSoLuong.Name = "colSoLuong";
            this.colSoLuong.ReadOnly = true;
            // 
            // colDonGia
            // 
            this.colDonGia.DataPropertyName = "DonGia";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "#,##0";
            this.colDonGia.DefaultCellStyle = dataGridViewCellStyle4;
            this.colDonGia.FillWeight = 60F;
            this.colDonGia.HeaderText = "Đơn giá";
            this.colDonGia.MinimumWidth = 55;
            this.colDonGia.Name = "colDonGia";
            this.colDonGia.ReadOnly = true;
            // 
            // colThanhTien
            // 
            this.colThanhTien.DataPropertyName = "ThanhTien";
            this.colThanhTien.FillWeight = 65F;
            this.colThanhTien.HeaderText = "T.Tiền";
            this.colThanhTien.MinimumWidth = 60;
            this.colThanhTien.Name = "colThanhTien";
            this.colThanhTien.ReadOnly = true;
            // 
            // lblDivider1
            // 
            this.lblDivider1.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDivider1.Font = new System.Drawing.Font("Consolas", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDivider1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblDivider1.Location = new System.Drawing.Point(14, 201);
            this.lblDivider1.Name = "lblDivider1";
            this.lblDivider1.Size = new System.Drawing.Size(350, 18);
            this.lblDivider1.TabIndex = 8;
            this.lblDivider1.Text = "--------------------------------------------------";
            this.lblDivider1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblThuNgan
            // 
            this.lblThuNgan.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblThuNgan.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThuNgan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblThuNgan.Location = new System.Drawing.Point(14, 180);
            this.lblThuNgan.Name = "lblThuNgan";
            this.lblThuNgan.Size = new System.Drawing.Size(350, 21);
            this.lblThuNgan.TabIndex = 7;
            this.lblThuNgan.Text = "Thu ngân: Admin";
            // 
            // lblTenBan
            // 
            this.lblTenBan.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTenBan.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenBan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblTenBan.Location = new System.Drawing.Point(14, 159);
            this.lblTenBan.Name = "lblTenBan";
            this.lblTenBan.Size = new System.Drawing.Size(350, 21);
            this.lblTenBan.TabIndex = 6;
            this.lblTenBan.Text = "Bàn: Bàn 01";
            // 
            // lblNgayGio
            // 
            this.lblNgayGio.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblNgayGio.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgayGio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblNgayGio.Location = new System.Drawing.Point(14, 138);
            this.lblNgayGio.Name = "lblNgayGio";
            this.lblNgayGio.Size = new System.Drawing.Size(350, 21);
            this.lblNgayGio.TabIndex = 5;
            this.lblNgayGio.Text = "Ngày: 28/07/2026 00:00";
            // 
            // lblMaHD
            // 
            this.lblMaHD.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMaHD.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaHD.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblMaHD.Location = new System.Drawing.Point(14, 117);
            this.lblMaHD.Name = "lblMaHD";
            this.lblMaHD.Size = new System.Drawing.Size(350, 21);
            this.lblMaHD.TabIndex = 4;
            this.lblMaHD.Text = "Số HD: HD00001";
            // 
            // lblTieuDeBill
            // 
            this.lblTieuDeBill.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTieuDeBill.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTieuDeBill.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblTieuDeBill.Location = new System.Drawing.Point(14, 77);
            this.lblTieuDeBill.Name = "lblTieuDeBill";
            this.lblTieuDeBill.Size = new System.Drawing.Size(350, 40);
            this.lblTieuDeBill.TabIndex = 3;
            this.lblTieuDeBill.Text = "HÓA ĐƠN THANH TOÁN";
            this.lblTieuDeBill.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStorePhone
            // 
            this.lblStorePhone.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblStorePhone.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStorePhone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblStorePhone.Location = new System.Drawing.Point(14, 57);
            this.lblStorePhone.Name = "lblStorePhone";
            this.lblStorePhone.Size = new System.Drawing.Size(350, 20);
            this.lblStorePhone.TabIndex = 2;
            this.lblStorePhone.Text = "Hotline: 0901.234.567";
            this.lblStorePhone.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStoreAddress
            // 
            this.lblStoreAddress.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblStoreAddress.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStoreAddress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblStoreAddress.Location = new System.Drawing.Point(14, 37);
            this.lblStoreAddress.Name = "lblStoreAddress";
            this.lblStoreAddress.Size = new System.Drawing.Size(350, 20);
            this.lblStoreAddress.TabIndex = 1;
            this.lblStoreAddress.Text = "Đ/C: 123 Đường Nguyễn Huệ, Q.1, TP.HCM";
            this.lblStoreAddress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStoreName
            // 
            this.lblStoreName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblStoreName.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStoreName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblStoreName.Location = new System.Drawing.Point(14, 14);
            this.lblStoreName.Name = "lblStoreName";
            this.lblStoreName.Size = new System.Drawing.Size(350, 23);
            this.lblStoreName.TabIndex = 0;
            this.lblStoreName.Text = "HỆ THỐNG QUẢN LÝ QUÁN CAFÉ";
            this.lblStoreName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmXemTruocBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 705);
            this.Controls.Add(this.pnlMainScroll);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmXemTruocBill";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Xem trước Hóa đơn in nhiệt";
            this.pnlHeader.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlMainScroll.ResumeLayout(false);
            this.pnlMainScroll.PerformLayout();
            this.pnlPaper.ResumeLayout(false);
            this.pnlSummary.ResumeLayout(false);
            this.pnlSummary.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonAn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitleBar;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Button btnQuayLai;
        private System.Windows.Forms.Button btnXuatBillHoanTat;
        private System.Windows.Forms.Panel pnlMainScroll;
        private System.Windows.Forms.Panel pnlPaper;
        private System.Windows.Forms.Label lblStoreName;
        private System.Windows.Forms.Label lblStoreAddress;
        private System.Windows.Forms.Label lblStorePhone;
        private System.Windows.Forms.Label lblTieuDeBill;
        private System.Windows.Forms.Label lblMaHD;
        private System.Windows.Forms.Label lblNgayGio;
        private System.Windows.Forms.Label lblTenBan;
        private System.Windows.Forms.Label lblThuNgan;
        private System.Windows.Forms.Label lblDivider1;
        private System.Windows.Forms.DataGridView dgvMonAn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenMon;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDonGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThanhTien;
        private System.Windows.Forms.Label lblDivider2;
        private System.Windows.Forms.Panel pnlSummary;
        private System.Windows.Forms.Label lblTongTienGocLabel;
        private System.Windows.Forms.Label lblTongTienGocVal;
        private System.Windows.Forms.Label lblSoTienGiamLabel;
        private System.Windows.Forms.Label lblSoTienGiamVal;
        private System.Windows.Forms.Label lblTongCanThanhToanLabel;
        private System.Windows.Forms.Label lblTongCanThanhToanVal;
        private System.Windows.Forms.Label lblPhuongThucLabel;
        private System.Windows.Forms.Label lblPhuongThucVal;
        private System.Windows.Forms.Label lblTienKhachDuaLabel;
        private System.Windows.Forms.Label lblTienKhachDuaVal;
        private System.Windows.Forms.Label lblTienTraLaiLabel;
        private System.Windows.Forms.Label lblTienTraLaiVal;
        private System.Windows.Forms.Label lblDivider3;
        private System.Windows.Forms.Label lblFooterMsg;
    }
}
