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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace QuanLyCuaHangHoaQua
{
    public partial class FormDangNhap : Form
    {
    // Thuộc tính này sẽ chứa thông tin người dùng nếu đăng nhập thành công
    // và sẽ là null nếu thất bại.
    public NguoiDung NguoiDungDaXacThuc { get; private set; }

        // Constructor của FormDangNhap
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
            // Kiểm tra định dạng tên đăng nhập
            try
            {
                NguoiDung user = null;
                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    // Lấy tất cả các cột cần thiết
                    string query = "SELECT Id, TenDangNhap, MatKhauHash, HoTen, IsAdmin FROM NguoiDung WHERE TenDangNhap = @tenDN";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@tenDN", tenDangNhap);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Tạo đối tượng NguoiDung với đầy đủ thông tin
                                user = new NguoiDung
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    TenDangNhap = reader["TenDangNhap"].ToString(),
                                    MatKhauHash = reader["MatKhauHash"].ToString(),
                                    HoTen = reader["HoTen"].ToString(),
                                    IsAdmin = Convert.ToBoolean(reader["IsAdmin"])
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
                else if (PasswordHasher.VerifyPassword(matKhau, user.MatKhauHash))
                {
                    // Gán đối tượng user vào thuộc tính công khai
                    this.NguoiDungDaXacThuc = user;
                    this.Close(); // Đóng form đăng nhập
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
