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
    public partial class FormThemSuaSanPham : Form
    {
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
            if (_sanPhamDangSua != null)
            {
                this.Text = "Chỉnh sửa thông tin sản phẩm";
                btnLuu.Text = "Cập nhật";

                txtTenHoaQua.Text = _sanPhamDangSua.TenSP; // Hiển thị tên sản phẩm
                cbDonViTinh.Text = _sanPhamDangSua.DonViTinh; // Hiển thị đơn vị tính
                numDonGia.Value = _sanPhamDangSua.DonGia; // Hiển thị đơn giá
                txtXuatXu.Text = _sanPhamDangSua.XuatXu; // Hiển thị xuất xứ
            }
            else 
                this.Text = "Thêm sản phẩm mới"; // Nếu không có sản phẩm đang sửa, đặt tiêu đề là "Thêm sản phẩm mới"
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

            if (_sanPhamDangSua != null)
            {
                _sanPhamDangSua.TenSP = txtTenHoaQua.Text; // Cập nhật tên sản phẩm
                _sanPhamDangSua.DonViTinh = cbDonViTinh.Text; // Cập nhật đơn vị tính
                _sanPhamDangSua.DonGia = numDonGia.Value; // Cập nhật đơn giá
                _sanPhamDangSua.XuatXu = txtXuatXu.Text; // Cập nhật xuất xứ
                MessageBox.Show("Đã cập nhật sản phẩm ' " + _sanPhamDangSua.TenSP + " ' thành công!", "Cập nhật thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                HoaQua sanPhamMoi = new HoaQua(); // Tạo mới đối tượng HoaQua
                {
                    sanPhamMoi.TenSP = txtTenHoaQua.Text; // Gán tên sản phẩm
                    sanPhamMoi.DonViTinh = cbDonViTinh.Text; // Gán đơn vị tính
                    sanPhamMoi.DonGia = numDonGia.Value; // Gán đơn giá
                    sanPhamMoi.XuatXu = txtXuatXu.Text; // Gán xuất xứ
                }
                _danhSachSP.Add(sanPhamMoi); // Thêm sản phẩm mới vào danh sách
                MessageBox.Show("Thêm sản phẩm mới thành công!"); // Hiển thị thông báo thành công
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

            /* Tạo đối tượng sanPhamMoi
            HoaQua sanPhamMoi = new HoaQua();

            // Gán các giá trị từ form vào đối tượng HoaQua
            sanPhamMoi.TenSP = txtTenHoaQua.Text; // Gán tên sản phẩm
            sanPhamMoi.DonViTinh = cbDonViTinh.Text; // Gán đơn vị tính
            sanPhamMoi.DonGia = numDonGia.Value; // Gán đơn giá
            sanPhamMoi.XuatXu = txtXuatXu.Text; // Gán xuất xứ

            _danhSachSP.Add(sanPhamMoi); // Thêm sản phẩm mới vào danh sách

            MessageBox.Show("Đã thêm sản phẩm ' " + sanPhamMoi.TenSP + " '!\n\n" + "Tổng số sản phẩm trong cửa hàng: " + danhSachHoaQua.Count, "Thành công");
            */

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
    }
}
    

