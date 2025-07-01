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
    public partial class FormBanHang : Form
    {
        // Danh sách này đóng vai trò là "giỏ hàng" hiện tại
        List<ChiTietHoaDon> gioHang = new List<ChiTietHoaDon>();
        public FormBanHang()
        {
            InitializeComponent();
        }

        private void btnThemVaoGio_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem người dùng đã chọn sản phẩm nào chưa
            HoaQua spChon = (HoaQua)dgvChonSP.SelectedRows[0].DataBoundItem;
            // Kiểm tra xem người dùng đã chọn sản phẩm nào chưa
            if (dgvChonSP.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm để thêm vào giỏ!");
                return;
            }
            int soLuongMua = (int)numSoLuongMua.Value;
            if (soLuongMua > spChon.SoLuongTon)
            {
                MessageBox.Show("Số lượng tồn kho không đủ để bán!");
                return; // Dừng lại, không cho thêm vào giỏ
            }
            if (soLuongMua > spChon.SoLuongTon)
            {
                MessageBox.Show("Số lượng tồn kho không đủ!");
                return;
            }

            // Kiểm tra xem sản phẩm này đã có trong giỏ chưa
            ChiTietHoaDon itemInCart = gioHang.FirstOrDefault(item => item.IdSanPham == spChon.Id);

            if (itemInCart != null)
            {
                // Nếu đã có, chỉ cần cập nhật lại số lượng
                itemInCart.SoLuong += soLuongMua;
            }
            else
            {
                // Nếu chưa có, tạo một ChiTietHoaDon mới
                ChiTietHoaDon chiTietMoi = new ChiTietHoaDon
                {
                    IdSanPham = spChon.Id,
                    TenSP = spChon.TenSP,
                    DonViTinh = spChon.DonViTinh,
                    SoLuong = soLuongMua,
                    DonGiaTaiThoiDiemBan = spChon.DonGia
                };
                gioHang.Add(chiTietMoi);
            }

            // Cập nhật lại giao diện
            LoadGioHang();
            UpdateTongTien();
        }

        private void FormBanHang_Load(object sender, EventArgs e)
        {
            // Thiết lập tiêu đề cho Form
            var tatCaSanPham = Database.GetAllProducts();
            var sanPhamDangKinhDoanh = tatCaSanPham.Where(sp => sp.TrangThai == true).ToList();
            dgvChonSP.DataSource = sanPhamDangKinhDoanh;
            dgvChonSP.SelectionChanged += dgvChonSP_SelectionChanged;
            dgvChonSP.CellClick += dgvChonSP_CellClick;
            this.dgvGioHang.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvGioHang_CellFormatting);


            // Tải danh sách sản phẩm vào DataGridView bên trái
            dgvChonSP.DataSource = Database.GetAllProducts();
            // Ẩn các cột không cần thiết
            if (dgvChonSP.Columns["HinhAnh"] != null) dgvChonSP.Columns["HinhAnh"].Visible = false;
            if (dgvChonSP.Columns["MoTa"] != null) dgvChonSP.Columns["MoTa"].Visible = false;
            if (dgvChonSP.Columns["Id"] != null) dgvChonSP.Columns["Id"].Visible = false;

            // Cài đặt cho ComboBox Giảm giá
            cbGiamGia.Items.Add(0);
            cbGiamGia.Items.Add(5);
            cbGiamGia.Items.Add(10);
            cbGiamGia.Items.Add(15);
            cbGiamGia.SelectedItem = 0; // Mặc định không giảm giá
        }
        private void LoadGioHang()
        {
            dgvGioHang.DataSource = null;
            dgvGioHang.DataSource = gioHang;

            // Tự động điều chỉnh độ rộng cột để lấp đầy DataGridView
            dgvGioHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Ẩn các cột không cần thiết
            if (dgvGioHang.Columns["Id"] != null) dgvGioHang.Columns["Id"].Visible = false;
            if (dgvGioHang.Columns["IdHoaDon"] != null) dgvGioHang.Columns["IdHoaDon"].Visible = false;
            if (dgvGioHang.Columns["IdSanPham"] != null) dgvGioHang.Columns["IdSanPham"].Visible = false;

            if (dgvGioHang.Columns["TenSP"] != null) dgvGioHang.Columns["TenSP"].HeaderText = "Tên Sản Phẩm";
            if (dgvGioHang.Columns["DonViTinh"] != null) dgvGioHang.Columns["DonViTinh"].HeaderText = "ĐVT";
            if (dgvGioHang.Columns["SoLuong"] != null) dgvGioHang.Columns["SoLuong"].HeaderText = "Số Lượng";
            if (dgvGioHang.Columns["DonGiaTaiThoiDiemBan"] != null) dgvGioHang.Columns["DonGiaTaiThoiDiemBan"].HeaderText = "Đơn Giá";
            if (dgvGioHang.Columns["ThanhTien"] != null) dgvGioHang.Columns["ThanhTien"].HeaderText = "Thành Tiền";

            // Định dạng cho cột tiền tệ
            if (dgvGioHang.Columns["DonGiaTaiThoiDiemBan"] != null)
                dgvGioHang.Columns["DonGiaTaiThoiDiemBan"].DefaultCellStyle.Format = "N0";
        }
        private void UpdateTongTien()
        {
            decimal tongTienHang = gioHang.Sum(item => item.ThanhTien);
            int phanTramGiam = Convert.ToInt32(cbGiamGia.SelectedItem);
            decimal soTienGiam = tongTienHang * phanTramGiam / 100;
            decimal tongThanhToan = tongTienHang - soTienGiam;

            lbTongTien.Text = tongThanhToan.ToString("N0") + " VNĐ";
        }

        private void btnXoaKhoiGio_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có sản phẩm nào được chọn để xóa không
            if (dgvGioHang.SelectedRows.Count > 0)
            {
                // Lấy ID sản phẩm từ dòng được chọn
                int idSanPhamXoa = ((ChiTietHoaDon)dgvGioHang.SelectedRows[0].DataBoundItem).IdSanPham;
                ChiTietHoaDon itemToRemove = gioHang.FirstOrDefault(item => item.IdSanPham == idSanPhamXoa);
                // Nếu tìm thấy sản phẩm trong giỏ hàng, xóa nó
                if (itemToRemove != null)
                {
                    gioHang.Remove(itemToRemove);
                    LoadGioHang();
                    UpdateTongTien();
                }
            }
        }
        private void dgvChonSP_SelectionChanged(object sender, EventArgs e)
        {
            // Kiểm tra xem có hàng nào đang được chọn không
            if (dgvChonSP.SelectedRows.Count > 0)
            {
                // Lấy đối tượng HoaQua từ hàng được chọn
                HoaQua spChon = (HoaQua)dgvChonSP.SelectedRows[0].DataBoundItem;

                // Kiểm tra và hiển thị ảnh
                if (spChon != null && !string.IsNullOrEmpty(spChon.HinhAnh) && File.Exists(spChon.HinhAnh))
                {
                    picPreview.Image = Image.FromFile(spChon.HinhAnh);
                }
                else
                {
                    // Nếu không có ảnh hoặc đường dẫn không hợp lệ, xóa ảnh đang hiển thị
                    picPreview.Image = null;
                }
            }
            else
            {
                picPreview.Image = null;
            }
        }
        private void cbGiamGia_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTongTien(); // Gọi hàm cập nhật tổng tiền mỗi khi thay đổi giảm giá
            dgvGioHang.Refresh(); // Cập nhật lại DataGridView để hiển thị giá trị mới
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem giỏ hàng có sản phẩm nào không
            if (gioHang.Count == 0)
            {
                MessageBox.Show("Giỏ hàng đang trống, không thể thanh toán!");
                return;
            }

            // Mở kết nối đến cơ sở dữ liệu và bắt đầu một transaction
            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // Tạo hóa đơn mới
                    int phanTramGiam = Convert.ToInt32(cbGiamGia.SelectedItem);
                    decimal tongTien = gioHang.Sum(item => item.ThanhTien) * (100 - phanTramGiam) / 100;

                    string queryHoaDon = "INSERT INTO HoaDon (GiamGiaPhanTram, TongTien) VALUES (@giamGia, @tongTien); SELECT SCOPE_IDENTITY();";
                    int idHoaDonMoi;
                    using (SqlCommand cmd = new SqlCommand(queryHoaDon, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@giamGia", phanTramGiam);
                        cmd.Parameters.AddWithValue("@tongTien", tongTien);
                        idHoaDonMoi = Convert.ToInt32(cmd.ExecuteScalar()); // Lấy về ID của hóa đơn vừa tạo
                    }

                    // Lặp qua từng sản phẩm trong giỏ hàng và thực hiện các thao tác
                    foreach (ChiTietHoaDon item in gioHang)
                    {
                        // Thêm chi tiết hóa đơn vào ChiTietHoaDon
                        string queryChiTiet = "INSERT INTO ChiTietHoaDon (IdHoaDon, IdSanPham, SoLuong, DonGiaTaiThoiDiemBan) VALUES (@idHD, @idSP, @soLuong, @donGia)";
                        using (SqlCommand cmd = new SqlCommand(queryChiTiet, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@idHD", idHoaDonMoi);
                            cmd.Parameters.AddWithValue("@idSP", item.IdSanPham);
                            cmd.Parameters.AddWithValue("@soLuong", item.SoLuong);
                            cmd.Parameters.AddWithValue("@donGia", item.DonGiaTaiThoiDiemBan);
                            cmd.ExecuteNonQuery();
                            var danhSachSP_HienThi = (List<HoaQua>)dgvChonSP.DataSource;
                            // Tìm sản phẩm tương ứng trong danh sách đó
                            HoaQua sanPhamDaBan = danhSachSP_HienThi.FirstOrDefault(sp => sp.Id == item.IdSanPham);
                            if (sanPhamDaBan != null)
                            {
                                // Trừ đi số lượng đã bán
                                sanPhamDaBan.SoLuongTon -= item.SoLuong;
                            }
                        }

                        // Cập nhật số lượng tồn kho của sản phẩm
                        string queryUpdateSP = "UPDATE SanPham SET SoLuongTon = SoLuongTon - @soLuongBan WHERE Id = @idSP";
                        using (SqlCommand cmd = new SqlCommand(queryUpdateSP, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@soLuongBan", item.SoLuong);
                            cmd.Parameters.AddWithValue("@idSP", item.IdSanPham);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    // Nếu tất cả thành công, commit transaction
                    transaction.Commit();
                    MessageBox.Show("Thanh toán thành công! Hóa đơn đã được lưu.");

                    // Reset lại cho hóa đơn tiếp theo
                    gioHang.Clear();
                    LoadGioHang();
                    UpdateTongTien();
                    dgvChonSP.Refresh();
                }
                catch (Exception ex)
                {
                    // Nếu có lỗi, rollback tất cả thay đổi
                    transaction.Rollback();
                    MessageBox.Show("Đã xảy ra lỗi trong quá trình thanh toán: " + ex.Message);
                }
            }
        }

        private void dgvChonSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // e.RowIndex >= 0 để đảm bảo người dùng không nhấp vào phần tiêu đề
            if (e.RowIndex >= 0)
            {
                // Tự động chọn toàn bộ hàng mà người dùng vừa nhấp vào.
                this.dgvChonSP.Rows[e.RowIndex].Selected = true;
            }
        }

        private void dgvGioHang_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Kiểm tra xem có phải là cột "ThanhTien" và là hàng dữ liệu không
            if (this.dgvGioHang.Columns[e.ColumnIndex].Name == "ThanhTien" && e.RowIndex >= 0)
            {
                // Lấy chi tiết đơn hàng từ hàng hiện tại
                ChiTietHoaDon item = this.dgvGioHang.Rows[e.RowIndex].DataBoundItem as ChiTietHoaDon;
                if (item != null)
                {
                    // Lấy thành tiền gốc
                    decimal originalThanhTien = item.ThanhTien;

                    // Lấy phần trăm giảm giá từ ComboBox
                    int phanTramGiam = 0;
                    if (cbGiamGia.SelectedItem != null)
                    {
                        phanTramGiam = Convert.ToInt32(cbGiamGia.SelectedItem);
                    }

                    // Tính toán giá trị mới sau khi đã giảm giá
                    decimal soTienGiam = originalThanhTien * phanTramGiam / 100;
                    decimal thanhTienDaGiam = originalThanhTien - soTienGiam;

                    // Cập nhật lại giá trị hiển thị cho ô này
                    e.Value = thanhTienDaGiam.ToString("N0");

                    // Đảm bảo định dạng tiền tệ (N0) vẫn được áp dụng
                    e.FormattingApplied = true;
                }
            }
        }
    }
}
