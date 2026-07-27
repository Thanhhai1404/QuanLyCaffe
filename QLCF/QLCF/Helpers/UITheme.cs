using System;
using System.Drawing;
using System.Windows.Forms;

namespace QLCF.Helpers
{
    public static class UITheme
    {
        // Palettes - Warm Espresso & Slate Palette
        public static readonly Color PrimaryDark = Color.FromArgb(30, 41, 59);       // Slate 800
        public static readonly Color HeaderDark = Color.FromArgb(15, 23, 42);        // Slate 900
        public static readonly Color PrimaryAccent = Color.FromArgb(194, 98, 14);    // Warm Amber 600
        public static readonly Color PrimaryAccentHover = Color.FromArgb(180, 83, 9); // Amber 700
        public static readonly Color SuccessGreen = Color.FromArgb(16, 185, 129);     // Emerald 500
        public static readonly Color SuccessGreenHover = Color.FromArgb(5, 150, 105); // Emerald 600
        public static readonly Color DangerRed = Color.FromArgb(225, 29, 72);        // Rose 600
        public static readonly Color DangerRedHover = Color.FromArgb(190, 18, 60);   // Rose 700

        public static readonly Color BackgroundOffWhite = Color.FromArgb(248, 250, 252); // Slate 50
        public static readonly Color SurfaceWhite = Color.FromArgb(255, 255, 255);
        public static readonly Color BorderColor = Color.FromArgb(226, 232, 240);    // Slate 200

        public static readonly Color TextPrimary = Color.FromArgb(15, 23, 42);       // Slate 900
        public static readonly Color TextSecondary = Color.FromArgb(100, 116, 139);   // Slate 500
        public static readonly Color TextMuted = Color.FromArgb(148, 163, 184);       // Slate 400

        // Status Colors for Tables / Badges
        public static readonly Color TableTrongBg = Color.FromArgb(220, 252, 231);      // Emerald 100
        public static readonly Color TableTrongText = Color.FromArgb(22, 101, 52);       // Emerald 800
        public static readonly Color TableTrongBorder = Color.FromArgb(134, 239, 172);   // Emerald 300

        public static readonly Color TableCoKhachBg = Color.FromArgb(254, 226, 226);     // Rose 100
        public static readonly Color TableCoKhachText = Color.FromArgb(153, 27, 27);    // Rose 800
        public static readonly Color TableCoKhachBorder = Color.FromArgb(252, 165, 165); // Rose 300

        public static readonly Color TableDatTruocBg = Color.FromArgb(254, 243, 199);    // Amber 100
        public static readonly Color TableDatTruocText = Color.FromArgb(146, 64, 14);   // Amber 800
        public static readonly Color TableDatTruocBorder = Color.FromArgb(253, 230, 138); // Amber 300

        // Fonts
        public static readonly Font FontMainTitle = new Font("Segoe UI", 14F, FontStyle.Bold);
        public static readonly Font FontSubTitle = new Font("Segoe UI", 11.5F, FontStyle.Bold);
        public static readonly Font FontHeader = new Font("Segoe UI", 10F, FontStyle.Bold);
        public static readonly Font FontRegular = new Font("Segoe UI", 9.75F, FontStyle.Regular);
        public static readonly Font FontBold = new Font("Segoe UI", 9.75F, FontStyle.Bold);
        public static readonly Font FontSmall = new Font("Segoe UI", 9F, FontStyle.Regular);

        public static void ApplyStyleToForm(Form form)
        {
            if (form == null) return;

            form.Font = FontRegular;
            form.BackColor = BackgroundOffWhite;
            form.ForeColor = TextPrimary;

            // Định dạng lại tất cả các DataGridView và Button trong Form
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

        public static void ApplyStyleToDataGridView(DataGridView dgv)
        {
            if (dgv == null) return;

            dgv.EnableHeadersVisualStyles = false;
            dgv.BorderStyle = BorderStyle.FixedSingle;
            dgv.BackgroundColor = SurfaceWhite;
            dgv.GridColor = BorderColor;

            // Column Header
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(241, 245, 249);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = TextPrimary;
            dgv.ColumnHeadersDefaultCellStyle.Font = FontBold;
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.ColumnHeadersDefaultCellStyle.Padding = new Padding(6, 4, 6, 4);
            dgv.ColumnHeadersHeight = 36;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            // Default Row Style
            dgv.DefaultCellStyle.BackColor = SurfaceWhite;
            dgv.DefaultCellStyle.ForeColor = TextPrimary;
            dgv.DefaultCellStyle.Font = FontRegular;
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 231, 255); // Soft blue selection
            dgv.DefaultCellStyle.SelectionForeColor = TextPrimary;
            dgv.DefaultCellStyle.Padding = new Padding(4);

            // Alternating Row Style
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
            dgv.AlternatingRowsDefaultCellStyle.ForeColor = TextPrimary;
            dgv.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 231, 255);
            dgv.AlternatingRowsDefaultCellStyle.SelectionForeColor = TextPrimary;

            dgv.RowTemplate.Height = 34;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
        }

        public static void ApplyStyleToButton(Button btn, bool isPrimary = false, bool isSuccess = false, bool isDanger = false)
        {
            if (btn == null) return;

            btn.FlatStyle = FlatStyle.Flat;
            btn.Cursor = Cursors.Hand;
            btn.Font = FontBold;

            if (isPrimary)
            {
                btn.BackColor = PrimaryAccent;
                btn.ForeColor = Color.White;
                btn.FlatAppearance.BorderColor = PrimaryAccent;
                btn.FlatAppearance.BorderSize = 0;
            }
            else if (isSuccess)
            {
                btn.BackColor = SuccessGreen;
                btn.ForeColor = Color.White;
                btn.FlatAppearance.BorderColor = SuccessGreen;
                btn.FlatAppearance.BorderSize = 0;
            }
            else if (isDanger)
            {
                btn.BackColor = DangerRed;
                btn.ForeColor = Color.White;
                btn.FlatAppearance.BorderColor = DangerRed;
                btn.FlatAppearance.BorderSize = 0;
            }
            else
            {
                // Default button style (Secondary)
                btn.BackColor = SurfaceWhite;
                btn.ForeColor = TextPrimary;
                btn.FlatAppearance.BorderColor = BorderColor;
                btn.FlatAppearance.BorderSize = 1;
            }
        }
    }
}
