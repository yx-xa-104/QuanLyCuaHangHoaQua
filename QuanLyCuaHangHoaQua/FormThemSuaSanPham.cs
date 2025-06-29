using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Markup;

namespace QuanLyCuaHangHoaQua
{
    public partial class FormThemSuaSanPham : Form
    {
        // Giải thích
        // Value Changed event của NumericUpDown
        // SelectedIndexChanged event của ComboBox
        // Form Closing event của Form

        /* Xác thực dữ liệu vào (Validation - Xác thực dữ liệu đầu vào)
           Các loại điều kiện phổ biến:
        - textBox không được để trống
        - NumericUpDown phải lớn hơn 0
        - ComboBox phải có giá trị được chọn
        - PictureBox phải có hình ảnh được chọn (nếu có)
        - Các điều kiện khác tùy theo yêu cầu của ứng dụng
        */

        // List<T> là một kiểu dữ liệu trong C# dùng để lưu trữ danh sách các đối tượng cùng loại - 1 mảng động

        // Data grid view là một Control dùng để hiển thị dữ liệu dạng bảng trong ứng dụng Windows Forms
        // Data grid view có thể hiển thị dữ liệu từ các nguồn khác nhau như List<T>, DataTable, Database, v.v.
        // Data binding là quá trình kết nối dữ liệu từ nguồn dữ liệu với Data grid view để hiển thị

        // Danh sách lưu trữ các đối tượng HoaQua
        List<HoaQua> danhSachHoaQua = new List<HoaQua>();
        // Biến lưu trữ sản phẩm đang được sửa (nếu có)
        private HoaQua _sanPhamDangSua = null;

        private List<HoaQua> _danhSachSP;

        // Constructor này sẽ được gọi từ FormQuanLy
        public FormThemSuaSanPham(List<HoaQua> danhSach, HoaQua spCanSua = null)
        {
            InitializeComponent();
            _danhSachSP = danhSach; // Lưu lại tham chiếu đến danh sách gốc
            _sanPhamDangSua = spCanSua; // Lưu lại sản phẩm đang sửa (nếu có)
        }

        private void FormThemSuaSanPham_Load(object sender, EventArgs e)
        {
            if (_sanPhamDangSua != null) // Kiểm tra xem có sản phẩm nào đang được sửa không
            {
                this.Text = "Chỉnh sửa thông tin sản phẩm";
                btnLuu.Text = "Cập nhật";

                txtTenHoaQua.Text = _sanPhamDangSua.TenSP; // Hiển thị tên sản phẩm
                cbDonViTinh.Text = _sanPhamDangSua.DonViTinh; // Hiển thị đơn vị tính
                numDonGia.Value = _sanPhamDangSua.DonGia; // Hiển thị đơn giá
                txtXuatXu.Text = _sanPhamDangSua.XuatXu; // Hiển thị xuất xứ
                txtMoTa.Text = _sanPhamDangSua.MoTa; // Hiển thị mô tả sản phẩm
                numSoLuongTon.Value = _sanPhamDangSua.SoLuongTon; // Hiển thị số lượng tồn kho


                // Chuyển đổi mảng byte HinhAnh thành hình ảnh và hiển thị trong PictureBox
                if (_sanPhamDangSua.HinhAnh != null)
                {
                    // Chỉ khi HinhAnh có dữ liệu, chúng ta mới thực hiện chuyển đổi
                    using (MemoryStream ms = new MemoryStream(_sanPhamDangSua.HinhAnh))
                    {
                        picHinhAnh.Image = Image.FromStream(ms);
                    }
                }
                else
                    this.Text = "Thêm sản phẩm mới"; // Nếu không có sản phẩm đang sửa, đặt tiêu đề là "Thêm sản phẩm mới"
            }
        }

        private void ClearForm()
        {
            // Xóa dữ liệu trên các Control trong form
            txtTenHoaQua.Clear(); // Xóa TextBox tên hoa quả
            cbDonViTinh.SelectedIndex = -1; // Đặt ComboBox về trạng thái chưa chọn
            numDonGia.Value = 0; // Đặt giá trị NumericUpDown về 0
            txtXuatXu.Clear(); // Xóa TextBox xuất xứ
            picHinhAnh.Image = null; // Xóa hình ảnh trong PictureBox
            lbCharCount.Text = "0 ký tự"; // Đặt lại số lượng ký tự về 0
            txtTenHoaQua.Focus(); // Đặt con trỏ vào TextBox tên hoa quả
        }

        private void picHinhAnh_Click(object sender, EventArgs e)
        {

        }

        private void cbDonViTinh_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FormThemSuaSanPham_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                // Nếu người dùng chọn No, hủy bỏ việc đóng form
                e.Cancel = true;
            }
            else
            {
                // Nếu người dùng chọn Yes, cho phép đóng form
                MessageBox.Show("Cảm ơn bạn đã sử dụng ứng dụng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // Kiểm tra các điều kiện xác thực dữ liệu đầu vào
            // 1. Kiểm tra tên hoa quả không được để trống
            if (string.IsNullOrWhiteSpace(txtTenHoaQua.Text))
            {
                MessageBox.Show("Tên hoa quả không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenHoaQua.Focus(); // Đặt con trỏ vào TextBox
                return; // Dừng thực hiện nếu có lỗi
            }

            // 2. Kiểm tra đơn vị tính đã được chọn
            if (cbDonViTinh.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn đơn vị tính!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbDonViTinh.Focus(); // Đặt con trỏ vào ComboBox
                return; // Dừng thực hiện nếu có lỗi
            }

            // 3. Kiểm tra đơn giá phải lớn hơn 0
            if (numDonGia.Value <= 0)
            {
                MessageBox.Show("Đơn giá phải lớn hơn 0!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                numDonGia.Focus(); // Đặt con trỏ vào NumericUpDown
                return; // Dừng thực hiện nếu có lỗi
            }

            if (_sanPhamDangSua != null) // Chế độ sửa sản phẩm
            {
                try
                {
                    using (SqlConnection conn = Database.GetConnection())
                    {
                        conn.Open();

                        // Chuẩn bị câu lệnh SQL để cập nhật sản phẩm
                        string query = "UPDATE SanPham " + "SET TenSP = @tenSP, DonViTinh = @donViTinh, DonGia = @donGia, XuatXu = @xuatXu, HinhAnh = @hinhAnh, MoTa = @moTa, SoLuongTon = @soLuongTon WHERE Id = @id";

                        // Tạo đối tượng SqlCommand với câu lệnh SQL và kết nối
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            //  Gắn giá trị vào các tham số
                            cmd.Parameters.AddWithValue("@tenSP", txtTenHoaQua.Text);
                            cmd.Parameters.AddWithValue("@donViTinh", cbDonViTinh.Text);
                            cmd.Parameters.AddWithValue("@donGia", numDonGia.Value);
                            cmd.Parameters.AddWithValue("@xuatXu", txtXuatXu.Text);
                            cmd.Parameters.AddWithValue("@hinhAnh", ImageToByteArray(picHinhAnh.Image));
                            cmd.Parameters.AddWithValue("@moTa", txtMoTa.Text);
                            cmd.Parameters.AddWithValue("@soLuongTon", Convert.ToInt32(numSoLuongTon.Value));

                            // Tham số cho mệnh đề WHERE, lấy từ đối tượng đang sửa
                            cmd.Parameters.AddWithValue("@id", _sanPhamDangSua.Id);

                            // Thực thi câu lệnh
                            int result = cmd.ExecuteNonQuery();

                            // Kiểm tra kết quả và thông báo
                            if (result > 0)
                            {
                                MessageBox.Show("Cập nhật sản phẩm thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                // Trường hợp này hiếm khi xảy ra nếu logic đúng
                                MessageBox.Show("Cập nhật thất bại. Không có sản phẩm nào được tìm thấy với ID này.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi trong quá trình cập nhật: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else // Chế độ thêm sản phẩm mới
            {
                try
                {
                    // Kiểm tra kết nối đến cơ sở dữ liệu và thực hiện thêm sản phẩm mới
                    using (SqlConnection conn = Database.GetConnection())
                    {
                        // Mở kết nối đến cơ sở dữ liệu
                        conn.Open();
                        string query = "INSERT INTO SanPham (TenSP, DonViTinh, DonGia, XuatXu, HinhAnh, MoTa, SoLuongTon) VALUES (@tenSP, @donViTinh, @donGia, @xuatXu, @hinhAnh, @moTa, @soLuongTon)";
                        // Chuẩn bị câu lệnh SQL để thêm sản phẩm mới
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            // Gắn giá trị vào các tham số
                            cmd.Parameters.AddWithValue("@tenSP", txtTenHoaQua.Text);
                            cmd.Parameters.AddWithValue("@donVitinh", cbDonViTinh.Text);
                            cmd.Parameters.AddWithValue("@donGia", numDonGia.Value);
                            cmd.Parameters.AddWithValue("@xuatXu", txtXuatXu.Text);
                            cmd.Parameters.AddWithValue("@hinhAnh", ImageToByteArray(picHinhAnh.Image));
                            cmd.Parameters.AddWithValue("@moTa", txtMoTa.Text);
                            cmd.Parameters.AddWithValue("@soLuongTon", Convert.ToInt32(numSoLuongTon.Value));
                            int result = cmd.ExecuteNonQuery(); // Thực thi câu lệnh SQL

                            // Kiểm tra kết quả trả về từ câu lệnh SQL
                            if (result > 0)
                            {

                                MessageBox.Show("Thêm sản phẩm mới thành công!", " Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                
                            }
                            else
                            {
                                MessageBox.Show("Thêm sản phẩm mới thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm sản phẩm mới: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Dừng thực hiện nếu có lỗi
                }
            }
            this.Close(); // Đóng form sau khi lưu thành công

            // Lấy thông tin từ các Control trên form
            string tenQua = txtTenHoaQua.Text.Trim();
            string donViTinh = cbDonViTinh.Text.Trim();

            // Lấy giá trị từ NumericUpDown, đảm bảo không null
            decimal donGia = numDonGia.Value;
            donGia = donGia - 10000; // Giảm giá 10.000 VNĐ
            numDonGia.Value = donGia; // Cập nhật lại giá trị trong NumericUpDown

            string xuatXu = txtXuatXu.Text.Trim();

            ClearForm();

            // Dựng chuỗi thông tin để hiển thị
            string thongTin = "Thông tin sản phẩm đã thu thập: \n" +
                "____________________________________________________\n" +
                "Tên: " + tenQua + "\n" +
                "Đơn vị tính: " + donViTinh + "\n" +
                "Đơn giá: " + donGia.ToString("N0") + " VNĐ\n" + // "N0" định dạng số với dấu phân cách hàng nghìn
                "Xuất xứ: " + xuatXu;
        }

        private void txtTenHoaQua_TextChanged(object sender, EventArgs e)
        {
            // Cập nhật số lượng ký tự trong TextBox
            int count = txtTenHoaQua.Text.Length;

            // Hiển thị số lượng ký tự trong Label
            lbCharCount.Text = count.ToString() + " ký tự";
        }

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            {
                openFile.Filter = "Image Files (*.jpg; *.jpeg; *.png; *.gif; *.bmp)|*.jpg; *.jpeg; *.png; *.gif; *.bmp";
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    // Đặt hình ảnh đã chọn vào PictureBox
                    picHinhAnh.Image = new Bitmap(openFile.FileName);
                }
            }
            ;
        }

        private byte[] ImageToByteArray(Image image)
        {
            if (image == null)
            {
                return null; // Trả về null nếu hình ảnh không hợp lệ
            }
            using (MemoryStream ms = new MemoryStream())
            {
                // Lưu hình ảnh vào MemoryStream và chuyển đổi thành mảng byte
                image.Save(ms, image.RawFormat);
                return ms.ToArray();
            }
        }

        private void cbDonViTinh_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}

    

