using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace QLCF.Helpers
{
    public static class UITheme
    {
        // ProMax Palettes - Dark Slate & Warm Amber Theme
        public static readonly Color PrimaryDark = Color.FromArgb(15, 23, 42);          // Deep Slate Navy #0F172A (Sidebar)
        public static readonly Color HeaderDark = Color.FromArgb(30, 41, 59);           // Secondary Dark #1E293B (Header)
        public static readonly Color PrimaryAccent = Color.FromArgb(217, 119, 6);       // Warm Amber #D97706
        public static readonly Color PrimaryAccentHover = Color.FromArgb(180, 83, 9);   // Amber Hover #B45309
        public static readonly Color PrimaryAccentLight = Color.FromArgb(254, 243, 199); // Soft Amber #FEF3C7
        public static readonly Color SuccessGreen = Color.FromArgb(16, 185, 129);        // Emerald #10B981
        public static readonly Color SuccessGreenHover = Color.FromArgb(5, 150, 105);    // Emerald Hover #059669
        public static readonly Color DangerRed = Color.FromArgb(239, 68, 68);           // Crimson #EF4444
        public static readonly Color DangerRedHover = Color.FromArgb(220, 38, 38);      // Crimson Hover #DC2626
        public static readonly Color InfoBlue = Color.FromArgb(59, 130, 246);           // Royal Blue #3B82F6

        public static readonly Color BackgroundOffWhite = Color.FromArgb(248, 250, 252); // Canvas #F8FAFC
        public static readonly Color SurfaceWhite = Color.FromArgb(255, 255, 255);          // Surface Cards #FFFFFF
        public static readonly Color BorderColor = Color.FromArgb(226, 232, 240);       // Border #E2E8F0
        public static readonly Color BorderColorFocus = Color.FromArgb(217, 119, 6);    // Amber Focus #D97706

        public static readonly Color TextPrimary = Color.FromArgb(15, 23, 42);          // Slate 900 #0F172A
        public static readonly Color TextSecondary = Color.FromArgb(51, 65, 85);        // Slate 700 #334155
        public static readonly Color TextMuted = Color.FromArgb(148, 163, 184);        // Slate 400 #94A3B8

        // Status Badges & Table State Colors
        public static readonly Color TableTrongBg = Color.FromArgb(240, 253, 244);       // Emerald 50 #F0FDF4
        public static readonly Color TableTrongText = Color.FromArgb(22, 101, 52);        // Emerald 800 #166534
        public static readonly Color TableTrongBorder = Color.FromArgb(187, 247, 208);    // Emerald 200 #BBF7D0

        public static readonly Color TableCoKhachBg = Color.FromArgb(254, 242, 242);      // Rose 50 #FEF2F2
        public static readonly Color TableCoKhachText = Color.FromArgb(153, 27, 27);     // Rose 800 #991B1B
        public static readonly Color TableCoKhachBorder = Color.FromArgb(254, 202, 202);  // Rose 200 #FECACA

        public static readonly Color TableDatTruocBg = Color.FromArgb(255, 251, 235);     // Amber 50 #FFFBEB
        public static readonly Color TableDatTruocText = Color.FromArgb(146, 64, 14);    // Amber 800 #92400E
        public static readonly Color TableDatTruocBorder = Color.FromArgb(253, 230, 138);  // Amber 200 #FDE68A

        // Fonts
        public static readonly Font FontMainTitle = new Font("Segoe UI", 18F, FontStyle.Bold);
        public static readonly Font FontSubTitle = new Font("Segoe UI", 14F, FontStyle.Bold);
        public static readonly Font FontHeader = new Font("Segoe UI", 10F, FontStyle.Bold);
        public static readonly Font FontRegular = new Font("Segoe UI", 10F, FontStyle.Regular);
        public static readonly Font FontBold = new Font("Segoe UI", 10F, FontStyle.Bold);
        public static readonly Font FontSmall = new Font("Segoe UI", 9F, FontStyle.Regular);

        public static void ApplyStyleToForm(Form form)
        {
            if (form == null) return;

            form.Font = FontRegular;
            form.BackColor = BackgroundOffWhite;
            form.ForeColor = TextPrimary;

            ApplyStyleToControls(form.Controls);
        }

        private static void ApplyStyleToControls(Control.ControlCollection controls)
        {
            if (controls == null) return;

            foreach (Control ctrl in controls)
            {
                if (ctrl is DataGridView dgv)
                {
                    ApplyStyleToDataGridView(dgv);
                }
                else if (ctrl is Button btn)
                {
                    ApplyStyleToButton(btn);
                }
                else if (ctrl is TextBox txt)
                {
                    txt.Font = FontRegular;
                    ApplyStyleToInput(txt);
                }
                else if (ctrl is ComboBox cbo)
                {
                    cbo.Font = FontRegular;
                }
                else if (ctrl is Panel || ctrl is GroupBox || ctrl is TabControl || ctrl is TabPage)
                {
                    ApplyStyleToControls(ctrl.Controls);
                }
            }
        }

        public static void ApplyStyleToInput(TextBox txt)
        {
            if (txt == null) return;
            txt.BorderStyle = BorderStyle.FixedSingle;
            txt.Font = FontRegular;
        }

        public static void ApplyStyleToDataGridView(DataGridView dgv)
        {
            if (dgv == null) return;

            dgv.EnableHeadersVisualStyles = false;
            dgv.BorderStyle = BorderStyle.None;
            dgv.BackgroundColor = SurfaceWhite;
            dgv.GridColor = Color.FromArgb(241, 245, 249); // #F1F5F9

            // Column Header
            dgv.ColumnHeadersDefaultCellStyle.BackColor = HeaderDark; // #1E293B
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = FontBold;
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.ColumnHeadersDefaultCellStyle.Padding = new Padding(8, 6, 8, 6);
            dgv.ColumnHeadersHeight = 42; // Header Height: 42px
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            // Default Row Style
            dgv.DefaultCellStyle.BackColor = SurfaceWhite;
            dgv.DefaultCellStyle.ForeColor = TextSecondary;
            dgv.DefaultCellStyle.Font = FontRegular;
            dgv.DefaultCellStyle.SelectionBackColor = PrimaryAccentLight; // #FEF3C7
            dgv.DefaultCellStyle.SelectionForeColor = Color.FromArgb(146, 64, 14); // #92400E
            dgv.DefaultCellStyle.Padding = new Padding(6);

            // Alternating Row Style
            dgv.AlternatingRowsDefaultCellStyle.BackColor = BackgroundOffWhite; // #F8FAFC
            dgv.AlternatingRowsDefaultCellStyle.ForeColor = TextSecondary;
            dgv.AlternatingRowsDefaultCellStyle.SelectionBackColor = PrimaryAccentLight;
            dgv.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.FromArgb(146, 64, 14);

            dgv.RowTemplate.Height = 38; // Row Height: 38px
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
        }

        public static void ApplyStyleToButton(Button btn, bool isPrimary = false, bool isSuccess = false, bool isDanger = false, bool isInfo = false)
        {
            if (btn == null) return;

            btn.FlatStyle = FlatStyle.Flat;
            btn.Cursor = Cursors.Hand;
            btn.Font = FontBold;

            Color normalBg;
            Color hoverBg;
            Color normalText = Color.White;

            if (isPrimary)
            {
                normalBg = PrimaryAccent;
                hoverBg = PrimaryAccentHover;
            }
            else if (isSuccess)
            {
                normalBg = SuccessGreen;
                hoverBg = SuccessGreenHover;
            }
            else if (isDanger)
            {
                normalBg = DangerRed;
                hoverBg = DangerRedHover;
            }
            else if (isInfo)
            {
                normalBg = InfoBlue;
                hoverBg = Color.FromArgb(37, 99, 235);
            }
            else
            {
                normalBg = SurfaceWhite;
                hoverBg = Color.FromArgb(241, 245, 249);
                normalText = TextPrimary;
                btn.FlatAppearance.BorderColor = BorderColor;
                btn.FlatAppearance.BorderSize = 1;
            }

            btn.BackColor = normalBg;
            btn.ForeColor = normalText;

            if (isPrimary || isSuccess || isDanger || isInfo)
            {
                btn.FlatAppearance.BorderSize = 0;
            }

            btn.MouseEnter -= Btn_MouseEnter;
            btn.MouseLeave -= Btn_MouseLeave;

            btn.Tag = new ButtonColors { Normal = normalBg, Hover = hoverBg, IsOutlined = !isPrimary && !isSuccess && !isDanger && !isInfo };
            btn.FlatAppearance.MouseOverBackColor = hoverBg;

            btn.MouseEnter += Btn_MouseEnter;
            btn.MouseLeave += Btn_MouseLeave;
        }

        private class ButtonColors
        {
            public Color Normal { get; set; }
            public Color Hover { get; set; }
            public bool IsOutlined { get; set; }
        }

        private static void Btn_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Button btn && btn.Tag is ButtonColors colors)
            {
                btn.BackColor = colors.Hover;
            }
        }

        private static void Btn_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Button btn && btn.Tag is ButtonColors colors)
            {
                btn.BackColor = colors.Normal;
            }
        }

        public static void ApplyCardStyle(Panel pnl, int cornerRadius = 10, Color? borderColor = null)
        {
            if (pnl == null) return;
            pnl.BackColor = SurfaceWhite;
            Color border = borderColor ?? BorderColor;

            pnl.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (GraphicsPath path = GetRoundedPath(pnl.ClientRectangle, cornerRadius))
                {
                    using (Pen pen = new Pen(border, 1))
                    {
                        e.Graphics.DrawPath(pen, path);
                    }
                }
            };
        }

        public static GraphicsPath GetRoundedPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int diameter = radius * 2;
            Rectangle arc = new Rectangle(rect.X, rect.Y, diameter, diameter);

            path.AddArc(arc, 180, 90);
            arc.X = rect.Right - diameter - 1;
            path.AddArc(arc, 270, 90);
            arc.Y = rect.Bottom - diameter - 1;
            path.AddArc(arc, 0, 90);
            arc.X = rect.Left;
            path.AddArc(arc, 90, 90);
            path.CloseFigure();

            return path;
        }
    }
}

