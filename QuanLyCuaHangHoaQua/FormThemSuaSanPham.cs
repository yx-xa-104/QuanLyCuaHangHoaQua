using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Markup;

namespace QuanLyCuaHangHoaQua
{
    public partial class FormThemSuaSanPham : Form
    {
        // Danh sách này được truyền từ FormQuanLy, chứa toàn bộ sản phẩm để điều hướng
        private List<HoaQua> _toanBoDanhSachSP;

        // Biến này lưu vị trí (index) của sản phẩm đang được hiển thị trong danh sách trên
        // Nó là "bộ não" quyết định form đang ở chế độ Thêm hay Sửa.
        // -1: Chế độ Thêm mới
        // >=0: Chế độ Sửa, và là vị trí của sản phẩm trong _toanBoDanhSachSP
        private int _viTriHienTai = -1;

        // Lưu đường dẫn của file ảnh mới được người dùng chọn
        private string _duongDanAnhDuocChon = null;

        // LỐI VÀO 1: Dành cho chức năng THÊM MỚI SẢN PHẨM.
        // Không cần tham số. _viTriHienTai sẽ giữ nguyên giá trị -1.
        public FormThemSuaSanPham()
        {
            InitializeComponent();
        }

        // LỐI VÀO 2: Dành cho chức năng SỬA SẢN PHẨM.
        // Yêu cầu danh sách sản phẩm và vị trí bắt đầu để điều hướng.
        public FormThemSuaSanPham(List<HoaQua> danhSach, int viTriBatDau)
        {
            InitializeComponent();
            _toanBoDanhSachSP = danhSach;
            _viTriHienTai = viTriBatDau;
        }

        // Sự kiện được kích hoạt ngay khi form được tải lên.
        // Sẽ kiểm tra xem đang ở chế độ Thêm hay Sửa để cấu hình giao diện phù hợp.
        private void FormThemSuaSanPham_Load(object sender, EventArgs e)
        {
            if (_viTriHienTai != -1) // Chế độ SỬA
            {
                this.Text = "Chỉnh sửa thông tin sản phẩm";
                btnLuu.Text = "Cập nhật";

                // Hiển thị và cấu hình cho các control của chế độ Sửa
                dgvDanhSachDieuHuong.DataSource = _toanBoDanhSachSP;
                // Tùy chỉnh các cột cho danh sách điều hướng trông gọn gàng
                dgvDanhSachDieuHuong.Columns["TenSP"].HeaderText = "Tên Sản Phẩm";
                dgvDanhSachDieuHuong.Columns["Id"].Width = 50;
                dgvDanhSachDieuHuong.Columns["DonGia"].Visible = false;
                dgvDanhSachDieuHuong.Columns["DonViTinh"].Visible = false;
                dgvDanhSachDieuHuong.Columns["XuatXu"].Visible = false;
                dgvDanhSachDieuHuong.Columns["HinhAnh"].Visible = false;
                dgvDanhSachDieuHuong.Columns["MoTa"].Visible = false;
                dgvDanhSachDieuHuong.Columns["SoLuongTon"].Visible = false;

                // Hiển thị sản phẩm ban đầu
                HienThiSanPham(_viTriHienTai);
            }
            else // Chế độ THÊM MỚI
            {
                this.Text = "Thêm sản phẩm mới";
                btnLuu.Text = "Lưu lại";

                // Ẩn các control không cần thiết cho việc Thêm mới
                dgvDanhSachDieuHuong.Visible = false;
                // Thay đổi kích thước SplitContainer để panel chi tiết chiếm toàn bộ form
                splitContainer1.Panel1Collapsed = true;
            }
        }

        // Phương thức trung tâm, hiển thị thông tin của một sản phẩm
        // tại một vị trí (index) cụ thể lên các control.
        private void HienThiSanPham(int index)
        {
            // Lấy sản phẩm từ danh sách
            HoaQua sp = _toanBoDanhSachSP[index];

            // Điền thông tin vào các control
            txtTenHoaQua.Text = sp.TenSP;
            cbDonViTinh.Text = sp.DonViTinh;
            numDonGia.Value = sp.DonGia;
            numSoLuongTon.Value = Math.Max(0, sp.SoLuongTon); // Dùng Math.Max để phòng trường hợp dữ liệu âm
            txtXuatXu.Text = sp.XuatXu;
            txtMoTa.Text = sp.MoTa;
            _duongDanAnhDuocChon = sp.HinhAnh; // Cập nhật đường dẫn ảnh hiện tại

            // Hiển thị ảnh (nếu có và file tồn tại)
            if (!string.IsNullOrEmpty(sp.HinhAnh) && File.Exists(sp.HinhAnh))
            {
                picHinhAnh.Image = Image.FromFile(sp.HinhAnh);
            }
            else
            {
                picHinhAnh.Image = null;
            }

            // Đồng bộ lựa chọn trên DataGridView điều hướng
            dgvDanhSachDieuHuong.ClearSelection();
            dgvDanhSachDieuHuong.Rows[index].Selected = true;
            dgvDanhSachDieuHuong.FirstDisplayedScrollingRowIndex = index;
        }

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Image Files (*.jpg; *.jpeg; *.png; *.gif; *.bmp)|*.jpg; *.jpeg; *.png; *.gif; *.bmp";

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                _duongDanAnhDuocChon = openFile.FileName;
                picHinhAnh.Image = Image.FromFile(_duongDanAnhDuocChon);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // Validation
            if (string.IsNullOrWhiteSpace(txtTenHoaQua.Text))
            {
                MessageBox.Show("Tên hoa quả không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenHoaQua.Focus();
                return;
            }
            if (cbDonViTinh.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn chưa chọn đơn vị tính!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbDonViTinh.Focus();
                return;
            }

            if (_viTriHienTai != -1) // Chế độ SỬA
            {
                HoaQua spCanSua = _toanBoDanhSachSP[_viTriHienTai];
                try
                {
                    using (SqlConnection conn = Database.GetConnection())
                    {
                        conn.Open();
                        string query = "UPDATE SanPham SET TenSP = @tenSP, DonViTinh = @donViTinh, DonGia = @donGia, XuatXu = @xuatXu, HinhAnh = @hinhAnh, MoTa = @moTa, SoLuongTon = @soLuongTon WHERE Id = @id";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@tenSP", txtTenHoaQua.Text);
                            cmd.Parameters.AddWithValue("@donViTinh", cbDonViTinh.Text);
                            cmd.Parameters.AddWithValue("@donGia", numDonGia.Value);
                            cmd.Parameters.AddWithValue("@xuatXu", txtXuatXu.Text);
                            cmd.Parameters.AddWithValue("@moTa", txtMoTa.Text);
                            cmd.Parameters.AddWithValue("@soLuongTon", Convert.ToInt32(numSoLuongTon.Value));
                            cmd.Parameters.AddWithValue("@hinhAnh", _duongDanAnhDuocChon);
                            cmd.Parameters.AddWithValue("@id", spCanSua.Id);

                            if (cmd.ExecuteNonQuery() > 0)
                            {
                                // Cập nhật lại đối tượng trong List để giao diện được đồng bộ ngay lập tức
                                spCanSua.TenSP = txtTenHoaQua.Text;
                                spCanSua.DonViTinh = cbDonViTinh.Text;
                                spCanSua.DonGia = numDonGia.Value;
                                spCanSua.SoLuongTon = (int)numSoLuongTon.Value;
                                spCanSua.XuatXu = txtXuatXu.Text;
                                spCanSua.MoTa = txtMoTa.Text;
                                spCanSua.HinhAnh = _duongDanAnhDuocChon;

                                MessageBox.Show("Cập nhật thành công!");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật sản phẩm: " + ex.Message);
                }
            }
            else // Chế độ THÊM MỚI
            {
                try
                {
                    using (SqlConnection conn = Database.GetConnection())
                    {
                        conn.Open();
                        string query = "INSERT INTO SanPham (TenSP, DonViTinh, DonGia, XuatXu, HinhAnh, MoTa, SoLuongTon) VALUES (@tenSP, @donViTinh, @donGia, @xuatXu, @hinhAnh, @moTa, @soLuongTon)";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@tenSP", txtTenHoaQua.Text);
                            cmd.Parameters.AddWithValue("@donViTinh", cbDonViTinh.Text);
                            cmd.Parameters.AddWithValue("@donGia", numDonGia.Value);
                            cmd.Parameters.AddWithValue("@xuatXu", txtXuatXu.Text);
                            cmd.Parameters.AddWithValue("@moTa", txtMoTa.Text);
                            cmd.Parameters.AddWithValue("@soLuongTon", Convert.ToInt32(numSoLuongTon.Value));
                            cmd.Parameters.AddWithValue("@hinhAnh", _duongDanAnhDuocChon);

                            if (cmd.ExecuteNonQuery() > 0)
                            {
                                MessageBox.Show("Thêm sản phẩm mới thành công!");
                                this.Close(); // Đóng form Thêm mới sau khi thành công
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm sản phẩm: " + ex.Message);
                }
            }
        }

        private void btnTruoc_Click(object sender, EventArgs e)
        {
            if (_viTriHienTai > 0)
            {
                _viTriHienTai--;
                HienThiSanPham(_viTriHienTai);
            }
        }

        private void btnSau_Click(object sender, EventArgs e)
        {
            if (_viTriHienTai < _toanBoDanhSachSP.Count - 1)
            {
                _viTriHienTai++;
                HienThiSanPham(_viTriHienTai);
            }
        }

        private void dgvDanhSachDieuHuong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                _viTriHienTai = e.RowIndex;
                HienThiSanPham(_viTriHienTai);
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

    

