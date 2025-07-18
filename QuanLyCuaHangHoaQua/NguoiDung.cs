using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangHoaQua
{
    public class NguoiDung
    {
        // Thuộc tính này sẽ ánh xạ với bảng NguoiDung trong CSDL
        public int Id { get; set; }
        public string TenDangNhap { get; set; }
        public string MatKhauHash { get; set; }
        public string HoTen { get; set; }
        public bool IsAdmin { get; set; }
    }
}
