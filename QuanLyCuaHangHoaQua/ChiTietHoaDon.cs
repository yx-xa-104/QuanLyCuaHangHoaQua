using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangHoaQua
{
    public class ChiTietHoaDon
    {
        public int Id { get; set; }
        public int IdHoaDon { get; set; }
        public int IdSanPham { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGiaTaiThoiDiemBan { get; set; }
        // Các thuộc tính dưới đây để hiển thị thuận tiện, không có trong CSDL
        public string TenSP { get; set; }
        public string DonViTinh { get; set; }
        public decimal ThanhTien { get { return SoLuong * DonGiaTaiThoiDiemBan; } }
    }
}
