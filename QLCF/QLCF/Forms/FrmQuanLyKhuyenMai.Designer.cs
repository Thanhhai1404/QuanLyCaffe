namespace QLCF.Forms
{
    partial class FrmQuanLyKhuyenMai
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.splitMain = new System.Windows.Forms.SplitContainer();
            this.dgvKhuyenMai = new System.Windows.Forms.DataGridView();
            this.pnlForm = new System.Windows.Forms.Panel();
            this.lblFormTitle = new System.Windows.Forms.Label();
            this.lblTenKM = new System.Windows.Forms.Label();
            this.txtTenKM = new System.Windows.Forms.TextBox();
            this.lblMaCode = new System.Windows.Forms.Label();
            this.txtMaCode = new System.Windows.Forms.TextBox();
            this.lblLoaiGiam = new System.Windows.Forms.Label();
            this.cboLoaiGiam = new System.Windows.Forms.ComboBox();
            this.lblGiaTriGiam = new System.Windows.Forms.Label();
            this.nudGiaTriGiam = new System.Windows.Forms.NumericUpDown();
            this.lblGiamToiDa = new System.Windows.Forms.Label();
            this.nudGiamToiDa = new System.Windows.Forms.NumericUpDown();
            this.lblDieuKien = new System.Windows.Forms.Label();
            this.nudDieuKien = new System.Windows.Forms.NumericUpDown();
            this.lblNgayBD = new System.Windows.Forms.Label();
            this.dtpNgayBD = new System.Windows.Forms.DateTimePicker();
            this.lblNgayKT = new System.Windows.Forms.Label();
            this.dtpNgayKT = new System.Windows.Forms.DateTimePicker();
            this.lblSoLuot = new System.Windows.Forms.Label();
            this.nudSoLuot = new System.Windows.Forms.NumericUpDown();
            this.chkKhongGioiHan = new System.Windows.Forms.CheckBox();
            this.lblMoTa = new System.Windows.Forms.Label();
            this.txtMoTa = new System.Windows.Forms.TextBox();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnCapNhat = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
            this.splitMain.Panel1.SuspendLayout();
            this.splitMain.Panel2.SuspendLayout();
            this.splitMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhuyenMai)).BeginInit();
            this.pnlForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudGiaTriGiam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGiamToiDa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDieuKien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuot)).BeginInit();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // pnlHeader
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.pnlHeader.Controls.Add(this.lblTieuDe);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1100, 55);
            // lblTieuDe
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTieuDe.ForeColor = System.Drawing.Color.White;
            this.lblTieuDe.Location = new System.Drawing.Point(20, 12);
            this.lblTieuDe.Text = "🎁 QUẢN LÝ CHƯƠNG TRÌNH KHUYẾN MÃI";
            // splitMain
            this.splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMain.Location = new System.Drawing.Point(0, 55);
            this.splitMain.SplitterDistance = 580;
            this.splitMain.Panel1.Controls.Add(this.dgvKhuyenMai);
            this.splitMain.Panel2.Controls.Add(this.pnlForm);
            // dgvKhuyenMai
            this.dgvKhuyenMai.AllowUserToAddRows = false;
            this.dgvKhuyenMai.AllowUserToDeleteRows = false;
            this.dgvKhuyenMai.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKhuyenMai.BackgroundColor = System.Drawing.Color.White;
            this.dgvKhuyenMai.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvKhuyenMai.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvKhuyenMai.MultiSelect = false;
            this.dgvKhuyenMai.ReadOnly = true;
            this.dgvKhuyenMai.RowHeadersVisible = false;
            this.dgvKhuyenMai.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKhuyenMai.RowTemplate.Height = 36;
            // pnlForm
            this.pnlForm.AutoScroll = true;
            this.pnlForm.BackColor = System.Drawing.Color.White;
            this.pnlForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlForm.Padding = new System.Windows.Forms.Padding(15);
            this.pnlForm.Controls.Add(this.pnlButtons);
            this.pnlForm.Controls.Add(this.txtMoTa);
            this.pnlForm.Controls.Add(this.lblMoTa);
            this.pnlForm.Controls.Add(this.chkKhongGioiHan);
            this.pnlForm.Controls.Add(this.nudSoLuot);
            this.pnlForm.Controls.Add(this.lblSoLuot);
            this.pnlForm.Controls.Add(this.dtpNgayKT);
            this.pnlForm.Controls.Add(this.lblNgayKT);
            this.pnlForm.Controls.Add(this.dtpNgayBD);
            this.pnlForm.Controls.Add(this.lblNgayBD);
            this.pnlForm.Controls.Add(this.nudDieuKien);
            this.pnlForm.Controls.Add(this.lblDieuKien);
            this.pnlForm.Controls.Add(this.nudGiamToiDa);
            this.pnlForm.Controls.Add(this.lblGiamToiDa);
            this.pnlForm.Controls.Add(this.nudGiaTriGiam);
            this.pnlForm.Controls.Add(this.lblGiaTriGiam);
            this.pnlForm.Controls.Add(this.cboLoaiGiam);
            this.pnlForm.Controls.Add(this.lblLoaiGiam);
            this.pnlForm.Controls.Add(this.txtMaCode);
            this.pnlForm.Controls.Add(this.lblMaCode);
            this.pnlForm.Controls.Add(this.txtTenKM);
            this.pnlForm.Controls.Add(this.lblTenKM);
            this.pnlForm.Controls.Add(this.lblFormTitle);
            // lblFormTitle
            this.lblFormTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblFormTitle.ForeColor = System.Drawing.Color.FromArgb(217, 119, 6);
            this.lblFormTitle.Location = new System.Drawing.Point(15, 10);
            this.lblFormTitle.Size = new System.Drawing.Size(450, 25);
            this.lblFormTitle.Text = "THÔNG TIN KHUYẾN MÃI";
            // Row 1: Tên KM
            this.lblTenKM.AutoSize = true;
            this.lblTenKM.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblTenKM.Location = new System.Drawing.Point(15, 45);
            this.lblTenKM.Text = "Tên chương trình:";
            this.txtTenKM.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtTenKM.Location = new System.Drawing.Point(15, 68);
            this.txtTenKM.Size = new System.Drawing.Size(450, 27);
            // Row 2: Mã code
            this.lblMaCode.AutoSize = true;
            this.lblMaCode.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblMaCode.Location = new System.Drawing.Point(15, 100);
            this.lblMaCode.Text = "Mã khuyến mãi (code):";
            this.txtMaCode.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtMaCode.Location = new System.Drawing.Point(15, 123);
            this.txtMaCode.Size = new System.Drawing.Size(200, 27);
            this.txtMaCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            // Row 3: Loại giảm giá
            this.lblLoaiGiam.AutoSize = true;
            this.lblLoaiGiam.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblLoaiGiam.Location = new System.Drawing.Point(15, 158);
            this.lblLoaiGiam.Text = "Loại giảm giá:";
            this.cboLoaiGiam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiGiam.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboLoaiGiam.Location = new System.Drawing.Point(15, 181);
            this.cboLoaiGiam.Size = new System.Drawing.Size(200, 27);
            // Row 4: Giá trị + Giảm tối đa
            this.lblGiaTriGiam.AutoSize = true;
            this.lblGiaTriGiam.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblGiaTriGiam.Location = new System.Drawing.Point(15, 216);
            this.lblGiaTriGiam.Text = "Giá trị giảm:";
            this.nudGiaTriGiam.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.nudGiaTriGiam.Location = new System.Drawing.Point(15, 239);
            this.nudGiaTriGiam.Size = new System.Drawing.Size(150, 27);
            this.nudGiaTriGiam.Maximum = 10000000;
            this.nudGiaTriGiam.ThousandsSeparator = true;
            this.lblGiamToiDa.AutoSize = true;
            this.lblGiamToiDa.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblGiamToiDa.Location = new System.Drawing.Point(230, 216);
            this.lblGiamToiDa.Text = "Giảm tối đa (VNĐ):";
            this.nudGiamToiDa.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.nudGiamToiDa.Location = new System.Drawing.Point(230, 239);
            this.nudGiamToiDa.Size = new System.Drawing.Size(150, 27);
            this.nudGiamToiDa.Maximum = 10000000;
            this.nudGiamToiDa.ThousandsSeparator = true;
            // Row 5: Điều kiện tối thiểu
            this.lblDieuKien.AutoSize = true;
            this.lblDieuKien.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblDieuKien.Location = new System.Drawing.Point(15, 274);
            this.lblDieuKien.Text = "Đơn tối thiểu (VNĐ):";
            this.nudDieuKien.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.nudDieuKien.Location = new System.Drawing.Point(15, 297);
            this.nudDieuKien.Size = new System.Drawing.Size(200, 27);
            this.nudDieuKien.Maximum = 100000000;
            this.nudDieuKien.ThousandsSeparator = true;
            // Row 6: Ngày BD / KT
            this.lblNgayBD.AutoSize = true;
            this.lblNgayBD.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblNgayBD.Location = new System.Drawing.Point(15, 332);
            this.lblNgayBD.Text = "Ngày bắt đầu:";
            this.dtpNgayBD.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpNgayBD.Location = new System.Drawing.Point(15, 355);
            this.dtpNgayBD.Size = new System.Drawing.Size(200, 27);
            this.dtpNgayBD.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.lblNgayKT.AutoSize = true;
            this.lblNgayKT.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblNgayKT.Location = new System.Drawing.Point(230, 332);
            this.lblNgayKT.Text = "Ngày kết thúc:";
            this.dtpNgayKT.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpNgayKT.Location = new System.Drawing.Point(230, 355);
            this.dtpNgayKT.Size = new System.Drawing.Size(200, 27);
            this.dtpNgayKT.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            // Row 7: Số lượt
            this.lblSoLuot.AutoSize = true;
            this.lblSoLuot.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblSoLuot.Location = new System.Drawing.Point(15, 390);
            this.lblSoLuot.Text = "Số lượt sử dụng:";
            this.nudSoLuot.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.nudSoLuot.Location = new System.Drawing.Point(15, 413);
            this.nudSoLuot.Size = new System.Drawing.Size(120, 27);
            this.nudSoLuot.Maximum = 100000;
            this.chkKhongGioiHan.AutoSize = true;
            this.chkKhongGioiHan.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.chkKhongGioiHan.Location = new System.Drawing.Point(150, 415);
            this.chkKhongGioiHan.Text = "Không giới hạn";
            // Row 8: Mô tả
            this.lblMoTa.AutoSize = true;
            this.lblMoTa.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblMoTa.Location = new System.Drawing.Point(15, 448);
            this.lblMoTa.Text = "Mô tả:";
            this.txtMoTa.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtMoTa.Location = new System.Drawing.Point(15, 471);
            this.txtMoTa.Size = new System.Drawing.Size(450, 60);
            this.txtMoTa.Multiline = true;
            // pnlButtons
            this.pnlButtons.Location = new System.Drawing.Point(15, 540);
            this.pnlButtons.Size = new System.Drawing.Size(450, 45);
            this.pnlButtons.Controls.Add(this.btnLamMoi);
            this.pnlButtons.Controls.Add(this.btnXoa);
            this.pnlButtons.Controls.Add(this.btnCapNhat);
            this.pnlButtons.Controls.Add(this.btnThem);
            // btnThem
            this.btnThem.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.FlatAppearance.BorderSize = 0;
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(0, 5);
            this.btnThem.Size = new System.Drawing.Size(100, 35);
            this.btnThem.Text = "➕ Thêm mới";
            this.btnThem.Cursor = System.Windows.Forms.Cursors.Hand;
            // btnCapNhat
            this.btnCapNhat.BackColor = System.Drawing.Color.FromArgb(245, 158, 11);
            this.btnCapNhat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCapNhat.FlatAppearance.BorderSize = 0;
            this.btnCapNhat.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCapNhat.ForeColor = System.Drawing.Color.White;
            this.btnCapNhat.Location = new System.Drawing.Point(110, 5);
            this.btnCapNhat.Size = new System.Drawing.Size(100, 35);
            this.btnCapNhat.Text = "✏️ Cập nhật";
            this.btnCapNhat.Cursor = System.Windows.Forms.Cursors.Hand;
            // btnXoa
            this.btnXoa.BackColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.FlatAppearance.BorderSize = 0;
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(220, 5);
            this.btnXoa.Size = new System.Drawing.Size(100, 35);
            this.btnXoa.Text = "🗑️ Xóa";
            this.btnXoa.Cursor = System.Windows.Forms.Cursors.Hand;
            // btnLamMoi
            this.btnLamMoi.BackColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoi.FlatAppearance.BorderSize = 0;
            this.btnLamMoi.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnLamMoi.ForeColor = System.Drawing.Color.White;
            this.btnLamMoi.Location = new System.Drawing.Point(330, 5);
            this.btnLamMoi.Size = new System.Drawing.Size(100, 35);
            this.btnLamMoi.Text = "🔄 Làm mới";
            this.btnLamMoi.Cursor = System.Windows.Forms.Cursors.Hand;
            // FrmQuanLyKhuyenMai
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 650);
            this.Controls.Add(this.splitMain);
            this.Controls.Add(this.pnlHeader);
            this.Name = "FrmQuanLyKhuyenMai";
            this.Text = "Quản lý khuyến mãi";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.splitMain.Panel1.ResumeLayout(false);
            this.splitMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
            this.splitMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhuyenMai)).EndInit();
            this.pnlForm.ResumeLayout(false);
            this.pnlForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudGiaTriGiam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGiamToiDa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDieuKien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuot)).EndInit();
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.SplitContainer splitMain;
        private System.Windows.Forms.DataGridView dgvKhuyenMai;
        private System.Windows.Forms.Panel pnlForm;
        private System.Windows.Forms.Label lblFormTitle;
        private System.Windows.Forms.Label lblTenKM;
        private System.Windows.Forms.TextBox txtTenKM;
        private System.Windows.Forms.Label lblMaCode;
        private System.Windows.Forms.TextBox txtMaCode;
        private System.Windows.Forms.Label lblLoaiGiam;
        private System.Windows.Forms.ComboBox cboLoaiGiam;
        private System.Windows.Forms.Label lblGiaTriGiam;
        private System.Windows.Forms.NumericUpDown nudGiaTriGiam;
        private System.Windows.Forms.Label lblGiamToiDa;
        private System.Windows.Forms.NumericUpDown nudGiamToiDa;
        private System.Windows.Forms.Label lblDieuKien;
        private System.Windows.Forms.NumericUpDown nudDieuKien;
        private System.Windows.Forms.Label lblNgayBD;
        private System.Windows.Forms.DateTimePicker dtpNgayBD;
        private System.Windows.Forms.Label lblNgayKT;
        private System.Windows.Forms.DateTimePicker dtpNgayKT;
        private System.Windows.Forms.Label lblSoLuot;
        private System.Windows.Forms.NumericUpDown nudSoLuot;
        private System.Windows.Forms.CheckBox chkKhongGioiHan;
        private System.Windows.Forms.Label lblMoTa;
        private System.Windows.Forms.TextBox txtMoTa;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnCapNhat;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
    }
}
