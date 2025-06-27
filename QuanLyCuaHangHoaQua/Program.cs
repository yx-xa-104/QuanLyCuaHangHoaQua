namespace QuanLyCuaHangHoaQua
{
    internal static class Program
    {
        /// <summary>
        /// Điểm vào chính của ứng dụng.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Tạo và hiển thị form đăng nhập
            FormDangNhap formLogin = new FormDangNhap();
            formLogin.ShowDialog(); // Hiển thị dưới dạng Dialog để chặn form chính

            // Sau khi form đăng nhập đóng lại, kiểm tra kết quả
            if (formLogin.LoginSuccessful)
            {
                // Nếu đăng nhập thành công, chạy form quản lý
                Application.Run(new FormQuanLy());
            }
            else
            {
                // Nếu không thành công (người dùng đóng hoặc nhấn Thoát),
                // thì không làm gì cả, ứng dụng sẽ tự kết thúc.
            }
        }
    }
}