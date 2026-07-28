using System;
using System.Drawing;
using System.Windows.Forms;
using QLCF.Helpers;

namespace QLCF.Forms
{
    public partial class FrmConfirm : Form
    {
        public bool Result { get; private set; } = false;

        public FrmConfirm(string title, string message)
        {
            InitializeComponent();
            lblTitle.Text = title;
            lblMessage.Text = message;
        }

        private void FrmConfirm_Load(object sender, EventArgs e)
        {
            UITheme.ApplyStyleToButton(btnYes, isPrimary: true);
            UITheme.ApplyStyleToButton(btnNo, isDanger: true);
            
            // Adjust danger colors to a softer gray for the cancel button
            btnNo.BackColor = Color.FromArgb(226, 232, 240);
            btnNo.ForeColor = Color.FromArgb(30, 41, 59);
            btnNo.MouseEnter += (s, ev) => { btnNo.BackColor = Color.FromArgb(203, 213, 225); };
            btnNo.MouseLeave += (s, ev) => { btnNo.BackColor = Color.FromArgb(226, 232, 240); };

            this.BackColor = Color.White;
            lblTitle.ForeColor = UITheme.PrimaryDark;
            lblMessage.ForeColor = UITheme.TextSecondary;
            
            // Apply slight shadow/border
            this.Paint += (s, ev) =>
            {
                ControlPaint.DrawBorder(ev.Graphics, this.ClientRectangle, Color.FromArgb(203, 213, 225), ButtonBorderStyle.Solid);
            };
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            Result = true;
            this.Close();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            Result = false;
            this.Close();
        }
    }
}
