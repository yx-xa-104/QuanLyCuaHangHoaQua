namespace QuanLyCuaHangHoaQua
{
    static class Program
    {
        // Biến tĩnh để lưu thông tin người dùng hiện tại
        public static NguoiDung NguoiDungHienTai { get; set; }

        // Điểm vào chính của ứng dụng.
        [STAThread]
        static void Main()
        {
            // Thiết lập các thuộc tính của ứng dụng
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Tạo và hiển thị form đăng nhập trước
            FormDangNhap formLogin = new FormDangNhap();
            formLogin.ShowDialog(); // Dùng ShowDialog để chương trình phải chờ form này đóng

            // Sau khi form đăng nhập đóng, kiểm tra xem đã có người dùng được xác thực chưa
            if (formLogin.NguoiDungDaXacThuc != null)
            {
                // Lưu thông tin người dùng vào biến static toàn cục
                Program.NguoiDungHienTai = formLogin.NguoiDungDaXacThuc;

                // Bắt đầu phân quyền
                if (Program.NguoiDungHienTai.IsAdmin) // Nếu là Admin
                {
                    // Chạy Form Quản lý
                    Application.Run(new FormQuanLy());
                }
                else // Nếu là người dùng thường
                {
                    // Chạy Form Bán hàng
                    Application.Run(new FormBanHang());
                }
            }
         }
    }
}