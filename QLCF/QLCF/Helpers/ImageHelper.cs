using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace QLCF.Helpers
{
    public static class ImageHelper
    {
        public static string AssetsImagesFolder => Path.Combine(Application.StartupPath, "Assets", "Images");

        public static void EnsureAssetsFolderExists()
        {
            try
            {
                if (!Directory.Exists(AssetsImagesFolder))
                {
                    Directory.CreateDirectory(AssetsImagesFolder);
                }
            }
            catch
            {
                // Fallback an toàn nếu không thể tạo thư mục
            }
        }

        public static string GetImagePath(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
                return null;

            EnsureAssetsFolderExists();

            string cleanFileName = Path.GetFileName(fileName);

            // 1. Kiểm tra file trong Assets/Images/<cleanFileName>
            string pathInAssets = Path.Combine(AssetsImagesFolder, cleanFileName);
            if (File.Exists(pathInAssets))
                return pathInAssets;

            // 2. Kiểm tra nếu fileName chứa đường dẫn tương đối (Assets/Images/mon.png hoặc Images/mon.png)
            string relativePath = Path.Combine(Application.StartupPath, fileName);
            if (File.Exists(relativePath))
                return relativePath;

            // 3. Kiểm tra nếu fileName là đường dẫn tuyệt đối trực tiếp
            if (Path.IsPathRooted(fileName) && File.Exists(fileName))
                return fileName;

            // 4. Kiểm tra trong thư mục Images/ cũ
            string oldImagesPath = Path.Combine(Application.StartupPath, "Images", cleanFileName);
            if (File.Exists(oldImagesPath))
                return oldImagesPath;

            return null;
        }

        public static string SaveImageToAssets(string sourceFilePath, int maMon = 0)
        {
            if (string.IsNullOrWhiteSpace(sourceFilePath) || !File.Exists(sourceFilePath))
                return null;

            EnsureAssetsFolderExists();

            string ext = Path.GetExtension(sourceFilePath);
            if (string.IsNullOrEmpty(ext)) ext = ".png";

            string timestamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            string newFileName = maMon > 0 ? $"mon_{maMon}_{timestamp}{ext}" : $"mon_{timestamp}{ext}";
            string destPath = Path.Combine(AssetsImagesFolder, newFileName);

            File.Copy(sourceFilePath, destPath, true);

            // Lưu tên file/đường dẫn tương đối vào database
            return Path.Combine("Assets", "Images", newFileName);
        }

        public static Image LoadImageSafely(string fileName, int width = 135, int height = 95, string title = null)
        {
            string fullPath = GetImagePath(fileName);
            if (!string.IsNullOrEmpty(fullPath) && File.Exists(fullPath))
            {
                try
                {
                    using (FileStream fs = new FileStream(fullPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
                        using (Image tempImg = Image.FromStream(fs))
                        {
                            return new Bitmap(tempImg);
                        }
                    }
                }
                catch
                {
                    // Tránh crash khi file lỗi -> Trả về Placeholder
                }
            }

            return GetPlaceholderImage(width, height, title);
        }

        public static Image GetPlaceholderImage(int width, int height, string title = null)
        {
            Bitmap bmp = new Bitmap(Math.Max(width, 10), Math.Max(height, 10));
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.Clear(Color.FromArgb(241, 245, 249)); // Slate-100

                // Viền mảnh Slate-200
                using (Pen borderPen = new Pen(Color.FromArgb(226, 232, 240), 1))
                {
                    g.DrawRectangle(borderPen, 0, 0, bmp.Width - 1, bmp.Height - 1);
                }

                // Hiển thị icon ☕ hoặc ký tự đầu tên món
                string displayText = "☕";
                if (!string.IsNullOrWhiteSpace(title))
                {
                    string trimmed = title.Trim();
                    if (trimmed.Length > 0)
                    {
                        displayText = trimmed.Substring(0, 1).ToUpper();
                    }
                }

                using (Font font = new Font("Segoe UI Emoji", Math.Max(12, height / 3), FontStyle.Bold))
                using (Brush brush = new SolidBrush(Color.FromArgb(148, 163, 184))) // Slate-400
                {
                    SizeF textSize = g.MeasureString(displayText, font);
                    float x = (bmp.Width - textSize.Width) / 2;
                    float y = (bmp.Height - textSize.Height) / 2;
                    g.DrawString(displayText, font, brush, x, y);
                }
            }
            return bmp;
        }
    }
}
