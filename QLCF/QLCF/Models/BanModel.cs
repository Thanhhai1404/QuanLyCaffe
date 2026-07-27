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
        public decimal DonGia { get; set; }
        public string HinhAnh { get; set; }
    }

    public class ChiTietHoaDonModel
    {
        public int MaCTHD { get; set; }
        public int MaHD { get; set; }
        public int MaMon { get; set; }
        public string TenMon { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public decimal ThanhTien { get; set; }
        public string GhiChu { get; set; }
    }
}
