using System;
using System.Drawing;
using System.Windows.Forms;
using QLCF.Helpers;
using QLCF.Models;

namespace QLCF.Forms
{
    public partial class StaffWelcomeControl : UserControl
    {
        public FrmMain MainForm { get; set; }
        private DateTime checkInTime;

        public StaffWelcomeControl()
        {
            InitializeComponent();

            this.Load += StaffWelcomeControl_Load;
            this.btnMoBanHang.Click += btnMoBanHang_Click;
            this.btnVaoCa.Click += btnVaoCa_Click;
            this.btnKetCa.Click += btnKetCa_Click;
            
            this.timerClock.Tick += TimerClock_Tick;
        }

        private void StaffWelcomeControl_Load(object sender, EventArgs e)
        {
            // Ensure DB table exists
            ShiftService.EnsureTableExists();

            // Set greeting
            string hoTen = !string.IsNullOrEmpty(UserSession.HoTen) ? UserSession.HoTen : "Nhân viên";
            lblWelcomeTitle.Text = $"Chào, {hoTen}!";

            // Start clock
            timerClock.Start();
            UpdateClock();

            // Check current shift status
            LoadShiftStatus();
        }

        private void TimerClock_Tick(object sender, EventArgs e)
        {
            UpdateClock();
        }

        private void UpdateClock()
        {
            lblRealtimeClock.Text = DateTime.Now.ToString("HH:mm:ss - dd/MM/yyyy");
        }

        private void LoadShiftStatus()
        {
            if (UserSession.MaNV <= 0) return;

            bool hasActiveShift = ShiftService.CheckActiveShift(UserSession.MaNV, out int shiftId, out checkInTime);

            if (hasActiveShift)
            {
                UserSession.CurrentShiftId = shiftId;
                SetShiftUI(true);
            }
            else
            {
                UserSession.CurrentShiftId = 0;
                SetShiftUI(false);
            }
        }

        private void SetShiftUI(bool isCheckedIn)
        {
            if (isCheckedIn)
            {
                // Đã vào ca
                lblShiftStatus.Text = $"Đang trong ca làm việc | Vào ca lúc: {checkInTime.ToString("HH:mm dd/MM")}";
                lblShiftStatus.ForeColor = Color.FromArgb(16, 185, 129); // Emerald Green #10B981

                btnVaoCa.Enabled = false;
                btnVaoCa.BackColor = Color.FromArgb(203, 213, 225); // Disabled Slate
                
                btnKetCa.Enabled = true;
                btnKetCa.BackColor = Color.FromArgb(220, 38, 38); // Crimson Red #DC2626

                btnMoBanHang.Enabled = true;
                btnMoBanHang.BackColor = Color.FromArgb(217, 119, 6); // Dark Amber Gold #D97706
            }
            else
            {
                // Chưa vào ca
                lblShiftStatus.Text = "Chưa điểm danh vào ca";
                lblShiftStatus.ForeColor = Color.FromArgb(239, 68, 68); // Red #EF4444

                btnVaoCa.Enabled = true;
                btnVaoCa.BackColor = Color.FromArgb(22, 163, 74); // Green #16A34A

                btnKetCa.Enabled = false;
                btnKetCa.BackColor = Color.FromArgb(203, 213, 225); // Disabled Slate

                btnMoBanHang.Enabled = false;
                btnMoBanHang.BackColor = Color.FromArgb(203, 213, 225); // Disabled Slate
            }
        }

        private void btnVaoCa_Click(object sender, EventArgs e)
        {
            if (UserSession.MaNV <= 0) return;

            bool success = ShiftService.CheckInShift(UserSession.MaNV);
            if (success)
            {
                checkInTime = DateTime.Now;
                SetShiftUI(true);

                using (var toast = new FrmSuccessToast("Vào ca thành công", $"Điểm danh lúc {checkInTime.ToString("HH:mm")}"))
                {
                    toast.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra khi điểm danh vào ca.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnKetCa_Click(object sender, EventArgs e)
        {
            if (UserSession.CurrentShiftId <= 0) return;

            TimeSpan duration = DateTime.Now - checkInTime;
            string msg = $"Xác nhận KẾT CA LÀM VIỆC?\n- Thời gian vào ca: {checkInTime:HH:mm dd/MM/yyyy}\n- Thời gian kết ca: {DateTime.Now:HH:mm dd/MM/yyyy}\n- Thời lượng ca này: {(int)duration.TotalHours} giờ {duration.Minutes} phút";

            using (var confirmDialog = new FrmConfirm("Xác nhận kết ca", msg))
            {
                confirmDialog.ShowDialog();

                if (confirmDialog.Result)
                {
                    if (ShiftService.DirectCheckOut(UserSession.CurrentShiftId))
                    {
                        SetShiftUI(false);
                        using (var toast = new FrmSuccessToast("Kết ca thành công", "Hệ thống đã ghi nhận."))
                        {
                            toast.ShowDialog();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi xảy ra khi cập nhật ca làm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        private void btnMoBanHang_Click(object sender, EventArgs e)
        {
            if (UserSession.CurrentShiftId <= 0)
            {
                MessageBox.Show("Vui lòng điểm danh Vào Ca trước khi mở màn hình bán hàng.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MainForm != null)
            {
                MainForm.MoBanHang();
            }
        }
    }
}
