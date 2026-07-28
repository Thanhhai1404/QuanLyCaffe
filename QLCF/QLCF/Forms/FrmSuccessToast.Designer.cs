namespace QLCF.Forms
{
    partial class FrmSuccessToast
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

        private void InitializeComponent()
        {
            this.lblMessage = new System.Windows.Forms.Label();
            this.lblSubMessage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            
            // 
            // lblMessage
            // 
            this.lblMessage.BackColor = System.Drawing.Color.Transparent;
            this.lblMessage.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.Location = new System.Drawing.Point(0, 120);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(320, 30);
            this.lblMessage.TabIndex = 1;
            this.lblMessage.Text = "Thanh toán thành công!";
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSubMessage
            // 
            this.lblSubMessage.BackColor = System.Drawing.Color.Transparent;
            this.lblSubMessage.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubMessage.Location = new System.Drawing.Point(0, 160);
            this.lblSubMessage.Name = "lblSubMessage";
            this.lblSubMessage.Size = new System.Drawing.Size(320, 30);
            this.lblSubMessage.TabIndex = 2;
            this.lblSubMessage.Text = "Đã lưu hóa đơn vào CSDL";
            this.lblSubMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmSuccessToast
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 240);
            this.Controls.Add(this.lblSubMessage);
            this.Controls.Add(this.lblMessage);
            this.Name = "FrmSuccessToast";
            this.Text = "Thanh toán thành công";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Label lblSubMessage;
    }
}
