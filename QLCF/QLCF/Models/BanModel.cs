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

    public class KhuyenMaiModel
    {
        public int MaKM { get; set; }
        public string TenKM { get; set; }
        public string MaKhuyenMai { get; set; }
        public int LoaiGiamGia { get; set; }        // 0 = %, 1 = VNĐ
        public decimal GiaTriGiam { get; set; }
        public decimal? GiamToiDa { get; set; }
        public decimal DieuKienToiThieu { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public int? SoLuotConLai { get; set; }
        public bool TrangThai { get; set; }
        public string MoTa { get; set; }

        /// <summary>
        /// Tính số tiền giảm thực tế cho một hóa đơn
        /// </summary>
        public decimal TinhSoTienGiam(decimal tongTienGoc)
        {
            if (tongTienGoc < DieuKienToiThieu) return 0;

            decimal soTienGiam;
            if (LoaiGiamGia == 0)
            {
                // Giảm theo %
                soTienGiam = tongTienGoc * GiaTriGiam / 100m;
                if (GiamToiDa.HasValue && soTienGiam > GiamToiDa.Value)
                    soTienGiam = GiamToiDa.Value;
            }
            else
            {
                // Giảm trực tiếp VNĐ
                soTienGiam = GiaTriGiam;
            }

            // Không giảm nhiều hơn tổng tiền
            if (soTienGiam > tongTienGoc)
                soTienGiam = tongTienGoc;

            return soTienGiam;
        }

        /// <summary>
        /// Hiển thị mô tả ngắn gọn cho mã KM
        /// </summary>
        public string MoTaNgan
        {
            get
            {
                string loai = LoaiGiamGia == 0
                    ? $"Giảm {GiaTriGiam:N0}%" + (GiamToiDa.HasValue ? $" (tối đa {GiamToiDa.Value:N0}đ)" : "")
                    : $"Giảm {GiaTriGiam:N0}đ";
                string dkien = DieuKienToiThieu > 0 ? $" | Đơn tối thiểu {DieuKienToiThieu:N0}đ" : "";
                string luot = SoLuotConLai.HasValue ? $" | Còn {SoLuotConLai} lượt" : " | Không giới hạn";
                return $"{loai}{dkien}{luot}";
            }
        }
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
