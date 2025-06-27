using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHangHoaQua
{
    public partial class FormDangNhap : Form
    {
        public FormDangNhap()
        {
            InitializeComponent();
        }
        // / Sự kiện khi người dùng nhấn nút Đăng nhập
        public bool LoginSuccessful { get; private set; } = false;

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Thoát toàn bộ ứng dụng
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            // Lấy tên đăng nhập và mật khẩu từ các TextBox
            string tenDangNhap = txtTenDangNhap.Text.Trim();
            string matKhau = txtMatKhau.Text;

            // Kiểm tra xem người dùng đã nhập đầy đủ tên đăng nhập và mật khẩu chưa
            if (string.IsNullOrEmpty(tenDangNhap) || string.IsNullOrEmpty(matKhau))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu.");
                return;
            }

            // Kết nối đến CSDL và kiểm tra thông tin đăng nhập
            try
            {
                NguoiDung user = null;
                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    // Truy vấn để lấy thông tin người dùng dựa trên tên đăng nhập
                    string query = "SELECT * FROM NguoiDung WHERE TenDangNhap = @tenDN";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Thêm tham số để tránh SQL Injection
                        cmd.Parameters.AddWithValue("@tenDN", tenDangNhap);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read()) // Nếu tìm thấy người dùng
                            {
                                user = new NguoiDung
                                {
                                    TenDangNhap = reader["TenDangNhap"].ToString(),
                                    MatKhauHash = reader["MatKhauHash"].ToString()
                                };
                            }
                        }
                    }
                }

                // Kiểm tra xem người dùng có tồn tại không
                if (user == null)
                {
                    MessageBox.Show("Tên đăng nhập không tồn tại.");
                }
                // Dùng PasswordHasher để so sánh mật khẩu người dùng nhập với hash trong CSDL
                else if (PasswordHasher.VerifyPassword(matKhau, user.MatKhauHash))
                {
                    MessageBox.Show("Đăng nhập thành công!");
                    LoginSuccessful = true; // Đánh dấu đăng nhập thành công
                    this.Close(); // Đóng form đăng nhập lại
                }
                else
                {
                    MessageBox.Show("Mật khẩu không chính xác.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối CSDL: " + ex.Message);
            }
        }
    }

}
