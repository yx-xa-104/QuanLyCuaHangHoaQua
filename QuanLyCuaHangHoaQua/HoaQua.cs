﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangHoaQua
{
    public class HoaQua
    {
        // Thuộc tính của lớp HoaQua
        // get - đọc và set - sửa các giá trị của thuộc tính
        public string TenSP { get; set; }
        public decimal DonGia { get; set; }
        public string XuatXu { get; set; }
        public string DonViTinh { get; set; }
        public int Id { get; set; }
        public string HinhAnh { get; set; }
        public string MoTa { get; set; }
        public int SoLuongTon { get; set; }
        public bool TrangThai { get; set; }
    }
}
