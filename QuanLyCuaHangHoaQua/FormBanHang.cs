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
            // Tắt tính năng tự động tạo cột
            dgvChonSP.AutoGenerateColumns = false;
            // Xóa các cột cũ để tránh bị trùng lặp khi chạy lại
            dgvChonSP.Columns.Clear();

            // Thêm các cột cần thiết và liên kết chúng với thuộc tính của lớp HoaQua
            dgvChonSP.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TenSP",
                HeaderText = "Tên Sản Phẩm",
                DataPropertyName = "TenSP", // Liên kết với thuộc tính "TenSP"
                FillWeight = 40 // Tỷ lệ chiều rộng
            });

            dgvChonSP.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DonViTinh",
                HeaderText = "ĐVT",
                DataPropertyName = "DonViTinh", // Liên kết với thuộc tính "DonViTinh"
                FillWeight = 15
            });

            dgvChonSP.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DonGia",
                HeaderText = "Đơn Giá",
                DataPropertyName = "DonGia", // Liên kết với thuộc tính "DonGia"
                DefaultCellStyle = { Format = "N0" }, // Định dạng tiền tệ
                FillWeight = 20
            });

            dgvChonSP.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "XuatXu",
                HeaderText = "Xuất Xứ",
                DataPropertyName = "XuatXu", // Liên kết với thuộc tính "XuatXu"
                FillWeight = 25
            });

            dgvChonSP.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "SoLuongTon",
                HeaderText = "Tồn Kho",
                DataPropertyName = "SoLuongTon", // Liên kết với thuộc tính "SoLuongTon"
                FillWeight = 15
            });

            // Thiết lập chế độ tự động dãn cột cho vừa vặn
            dgvChonSP.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Tải và lọc dữ liệu như cũ
            var tatCaSanPham = Database.GetAllProducts();
            var sanPhamDangKinhDoanh = tatCaSanPham.Where(sp => sp.TrangThai == true).ToList();
            dgvChonSP.DataSource = sanPhamDangKinhDoanh;

            // Cấu hình các cột của DataGridView
            dgvChonSP.SelectionChanged += dgvChonSP_SelectionChanged;
            dgvChonSP.CellClick += dgvChonSP_CellClick;

            // Tải giỏ hàng ban đầu
            if (dgvChonSP.Rows.Count > 0)
            {
                dgvChonSP.Rows[0].Selected = true;
            }
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

            // Định dạng cho cột thành tiền
            if (dgvGioHang.Columns["GiamGia"] != null)
            {
                dgvGioHang.Columns["GiamGia"].HeaderText = "Giảm Giá (%)";
                // Đặt các cột khác thành chỉ đọc
                foreach (DataGridViewColumn column in dgvGioHang.Columns)
                {
                    if (column.Name != "GiamGia")
                    {
                        column.ReadOnly = true;
                    }
                }
            }
        }
        private void UpdateTongTien()
        {
            // Tính tổng tiền từ giỏ hàng
            decimal tongThanhToan = gioHang.Sum(item => item.ThanhTien);
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
                    // Tạo hóa đơn mới (không còn giảm giá chung)
                    decimal tongTien = gioHang.Sum(item => item.ThanhTien);
                    string queryHoaDon = "INSERT INTO HoaDon (TongTien) OUTPUT INSERTED.Id VALUES (@tongTien)";
                    int idHoaDonMoi;
                    using (SqlCommand cmd = new SqlCommand(queryHoaDon, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@tongTien", tongTien);
                        idHoaDonMoi = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    // Lưu chi tiết hóa đơn
                    foreach (ChiTietHoaDon item in gioHang)
                    {
                        var danhSachSP_HienThi = (List<HoaQua>)dgvChonSP.DataSource;
                        HoaQua sanPhamDaBan = danhSachSP_HienThi.FirstOrDefault(sp => sp.Id == item.IdSanPham);
                        if (sanPhamDaBan != null)
                        {
                            sanPhamDaBan.SoLuongTon -= item.SoLuong;
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

        private void dgvGioHang_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // e.RowIndex >= 0 để đảm bảo đây là hàng dữ liệu
            if (e.RowIndex >= 0)
            {
                // Kiểm tra xem có phải cột "GiamGia" được thay đổi không
                if (dgvGioHang.Columns[e.ColumnIndex].Name == "GiamGia")
                {
                    // Cập nhật lại tổng tiền
                    UpdateTongTien();
                    // Vẽ lại hàng để cột Thành Tiền hiển thị giá trị mới
                    dgvGioHang.InvalidateRow(e.RowIndex);
                }
            }
        }        
    }
}
