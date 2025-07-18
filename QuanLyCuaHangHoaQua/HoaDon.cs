using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangHoaQua
{
    public class HoaDon
    {
        public int Id { get; set; }
        public DateTime NgayTao { get; set; }
        public int GiamGiaPhanTram { get; set; }
        public decimal TongTien { get; set; }
        // Thuộc tính này để hiển thị thuận tiện, không có trong CSDL
        // public List<ChiTietHoaDon> ChiTiet { get; set; } = new List<ChiTietHoaDon>();
    }
}
