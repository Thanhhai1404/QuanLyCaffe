using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using QLCF.Helpers;

namespace QLCF.Forms
{
    public partial class FrmSuccessToast : Form
    {
        private Timer autoCloseTimer;
        private Timer animationTimer;
        private int animationStep = 0;
        private float scale = 0.5f;
        private float opacity = 0f;

        public FrmSuccessToast(string message = "Thanh toán thành công!", string subMessage = "Đã lưu hóa đơn vào CSDL")
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(320, 240);
            this.BackColor = UITheme.SurfaceWhite;
            this.Opacity = 0; // Start invisible
            this.DoubleBuffered = true;

            // Apply rounded corners
            GraphicsPath path = new GraphicsPath();
            int radius = 16;
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(this.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(this.Width - radius, this.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, this.Height - radius, radius, radius, 90, 90);
            path.CloseFigure();
            this.Region = new Region(path);

            lblMessage.Text = message;
            lblSubMessage.Text = subMessage;

            lblMessage.ForeColor = UITheme.SuccessGreenHover; // #065F46 roughly
            lblSubMessage.ForeColor = UITheme.TextSecondary;

            // Auto Close Timer (2000ms)
            autoCloseTimer = new Timer();
            autoCloseTimer.Interval = 2000;
            autoCloseTimer.Tick += (s, e) => {
                autoCloseTimer.Stop();
                this.Close();
            };

            // Animation Timer
            animationTimer = new Timer();
            animationTimer.Interval = 16; // ~60 FPS
            animationTimer.Tick += AnimationTimer_Tick;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            animationTimer.Start();
            autoCloseTimer.Start();
        }

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            animationStep++;
            if (opacity < 1f) opacity += 0.1f;
            if (opacity > 1f) opacity = 1f;
            this.Opacity = opacity;

            if (scale < 1f)
            {
                scale += 0.05f;
                if (scale > 1f) scale = 1f;
                this.Invalidate(); // Redraw icon
            }
            
            if (opacity == 1f && scale == 1f)
            {
                animationTimer.Stop();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Draw subtle border
            int radius = 16;
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(this.Width - radius - 1, 0, radius, radius, 270, 90);
            path.AddArc(this.Width - radius - 1, this.Height - radius - 1, radius, radius, 0, 90);
            path.AddArc(0, this.Height - radius - 1, radius, radius, 90, 90);
            path.CloseFigure();
            using (Pen pen = new Pen(UITheme.BorderColor, 1))
            {
                e.Graphics.DrawPath(pen, path);
            }

            // Draw animated green circle
            int circleSize = (int)(64 * scale);
            int cx = this.Width / 2;
            int cy = 60; // Center Y of the icon area
            int rectX = cx - circleSize / 2;
            int rectY = cy - circleSize / 2;
            
            Rectangle circleRect = new Rectangle(rectX, rectY, circleSize, circleSize);

            // Draw shadow/glow
            if (scale == 1f)
            {
                using (SolidBrush glowBrush = new SolidBrush(Color.FromArgb(50, UITheme.SuccessGreen)))
                {
                    e.Graphics.FillEllipse(glowBrush, new Rectangle(rectX - 4, rectY - 4, circleSize + 8, circleSize + 8));
                }
            }

            using (SolidBrush brush = new SolidBrush(UITheme.SuccessGreen))
            {
                e.Graphics.FillEllipse(brush, circleRect);
            }

            // Draw Checkmark
            if (scale > 0.8f)
            {
                using (Pen pen = new Pen(Color.White, 4f))
                {
                    pen.StartCap = LineCap.Round;
                    pen.EndCap = LineCap.Round;
                    pen.LineJoin = LineJoin.Round;
                    
                    float progress = (scale - 0.8f) * 5f; // 0 to 1
                    
                    int checkX = cx - 10;
                    int checkY = cy + 2;
                    
                    Point pt1 = new Point(checkX - 8, checkY - 8);
                    Point pt2 = new Point(checkX, checkY);
                    Point pt3 = new Point(checkX + 16, checkY - 16);

                    if (progress > 0.5f)
                    {
                        e.Graphics.DrawLine(pen, pt1, pt2);
                        // Interpolate second line
                        float p2 = (progress - 0.5f) * 2f;
                        Point currentPt3 = new Point(
                            (int)(pt2.X + (pt3.X - pt2.X) * p2),
                            (int)(pt2.Y + (pt3.Y - pt2.Y) * p2)
                        );
                        e.Graphics.DrawLine(pen, pt2, currentPt3);
                    }
                    else
                    {
                        float p1 = progress * 2f;
                        Point currentPt2 = new Point(
                            (int)(pt1.X + (pt2.X - pt1.X) * p1),
                            (int)(pt1.Y + (pt2.Y - pt1.Y) * p1)
                        );
                        e.Graphics.DrawLine(pen, pt1, currentPt2);
                    }
                }
            }
        }
    }
}
