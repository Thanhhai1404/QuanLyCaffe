using System;

namespace QLCF.Models
{
    public class BanModel
    {
        public int MaBan { get; set; }
        public string TenBan { get; set; }
        public int MaKV { get; set; }
        public string TenKhuVuc { get; set; }
        public string TrangThai { get; set; }
        public bool DangSuDung { get; set; }
        public int? MaHoaDonMo { get; set; }
        public DateTime? GioVao { get; set; }
        public decimal? TamTinh { get; set; }
    }

    public class KhuVucItem
    {
        public int MaKV { get; set; }
        public string TenKhuVuc { get; set; }

        public override string ToString()
        {
            return TenKhuVuc;
        }
    }

    public class DanhMucModel
    {
        public int MaDM { get; set; }
        public string TenDanhMuc { get; set; }
    }

    public class MonAnModel
    {
        public int MaMon { get; set; }
        public string TenMon { get; set; }
        public int MaDM { get; set; }
        public string TenDanhMuc { get; set; }
        public decimal DonGia { get; set; }
        public string HinhAnh { get; set; }

        public bool IsDoUong
        {
            get
            {
                if (string.IsNullOrWhiteSpace(TenDanhMuc)) return true;
                string name = TenDanhMuc.Trim().ToLower();
                if (name.Contains("bánh") || name.Contains("cake") || name.Contains("đồ ăn") || name.Contains("khô") || name.Contains("snack") || name.Contains("thức ăn") || name.Contains("thức ăn vặt"))
                {
                    return false;
                }
                return true;
            }
        }
    }

    public class SizeOptionModel
    {
        public string TenSize { get; set; } // "S", "M", "L"
        public decimal GiaPhuThu { get; set; } // 0, 5000, 10000
    }

    public class ChiTietHoaDonModel
    {
        public int MaCTHD { get; set; }
        public int MaHD { get; set; }
        public int MaMon { get; set; }
        public string TenMon { get; set; }
        public string TenSize { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public decimal ThanhTien { get; set; }
        public string GhiChu { get; set; }

        // Tên hiển thị đầy đủ bao gồm Size (ví dụ: Bạc Xỉu (Size L)) và Ghi chú
        public string TenMonHienThi
        {
            get
            {
                string title = TenMon;
                if (!string.IsNullOrWhiteSpace(TenSize))
                {
                    string s = TenSize.Trim();
                    if (!s.StartsWith("Size", StringComparison.OrdinalIgnoreCase))
                    {
                        s = "Size " + s;
                    }
                    if (!title.EndsWith($"({s})", StringComparison.OrdinalIgnoreCase))
                    {
                        title = $"{title} ({s})";
                    }
                }
                if (!string.IsNullOrWhiteSpace(GhiChu))
                {
                    title += $"\n  • {GhiChu.Trim()}";
                }
                return title;
            }
        }
    }
}
