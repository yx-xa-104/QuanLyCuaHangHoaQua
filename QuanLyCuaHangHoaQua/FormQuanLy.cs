using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace QuanLyCuaHangHoaQua
{
    public partial class FormQuanLy : Form
    {
        // Danh sách lưu trữ các đối tượng HoaQua
        List<HoaQua> danhSachHoaQua = new List<HoaQua>();

        public FormQuanLy()
        {
            InitializeComponent();
        }

        // Hàm này sẽ được gọi để tải dữ liệu từ cơ sở dữ liệu vào DataGridView
        private void LoadDataToGrid(string tuKhoa = "") // Thêm tham số tuKhoa để lọc dữ liệu
        {
            try
            {
                // Gọi phương thức từ lớp Database để lấy dữ liệu
                danhSachHoaQua = Database.GetAllProducts(tuKhoa);

                // Gán danh sách hoa quả vào DataGridView
                dgvDanhSachSP.DataSource = null;
                dgvDanhSachSP.DataSource = danhSachHoaQua;

                // Thiết lập các cột hiển thị trong DataGridView
                if (dgvDanhSachSP.Columns["HinhAnh"] != null)
                    dgvDanhSachSP.Columns["HinhAnh"].Visible = false;
                if (dgvDanhSachSP.Columns["MoTa"] != null)
                    dgvDanhSachSP.Columns["MoTa"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            // Khi người dùng nhấn nút "Thêm mới", mở form thêm sản phẩm mới
            FormThemSuaSanPham formThem = new FormThemSuaSanPham(danhSachHoaQua, -1);

            formThem.ShowDialog();

            // Gọi lại hàm LoadDataToGrid() để cập nhật lại bảng
            LoadDataToGrid();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có hàng nào được chọn không
            if (dgvDanhSachSP.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần sửa.");
                return;
            }

            // Lấy VỊ TRÍ (INDEX) của hàng đang được chọn
            int viTriChon = dgvDanhSachSP.SelectedRows[0].Index;

            // Tạo form sửa và truyền toàn bộ danh sách cùng với vị trí bắt đầu
            FormThemSuaSanPham formSua = new FormThemSuaSanPham(danhSachHoaQua, viTriChon);

            formSua.ShowDialog();

            LoadDataToGrid();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có hàng nào được chọn không
            if (dgvDanhSachSP.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Lấy sản phẩm được chọn từ DataGridView
            HoaQua spChon = (HoaQua)dgvDanhSachSP.SelectedRows[0].DataBoundItem;

            // Xác định hành động và thông điệp
            bool trangThaiMoi = !spChon.TrangThai; // Đảo ngược trạng thái hiện tại
            string thongDiep = trangThaiMoi
                ? "Bạn có chắc muốn KINH DOANH TRỞ LẠI sản phẩm này?"
                : "Bạn có chắc chắn muốn NGỪNG KINH DOANH sản phẩm này không?";

            DialogResult result = MessageBox.Show(thongDiep, "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            // Nếu người dùng chọn Yes, thực hiện cập nhật trạng thái
            if (result == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = Database.GetConnection())
                    {
                        conn.Open();
                        string query = "UPDATE SanPham SET TrangThai = @TrangThaiMoi WHERE Id = @id";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@TrangThaiMoi", trangThaiMoi);
                            cmd.Parameters.AddWithValue("@id", spChon.Id);

                            if (cmd.ExecuteNonQuery() > 0)
                            {
                                MessageBox.Show("Thay đổi trạng thái thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadDataToGrid(); // Tải lại để cập nhật giao diện
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void FormQuanLy_Load(object sender, EventArgs e)
        {
            LoadDataToGrid();
        }

        private void dgvDanhSachSP_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDanhSachSP.SelectedRows.Count > 0)
            {
                // Lấy hàng đang được chọn trong DataGridView
                DataGridViewRow row = dgvDanhSachSP.SelectedRows[0];

                // Lấy đối tượng HoaQua tương ứng với hàng đang được chọn
                HoaQua spChon = (HoaQua)row.DataBoundItem;

                // Kiểm tra xem đối tượng đó và dữ liệu ảnh của nó có tồn tại không
                if (spChon != null && !string.IsNullOrEmpty(spChon.HinhAnh) && File.Exists(spChon.HinhAnh))
                {
                    // Chỉ hiển thị ảnh nếu đường dẫn hợp lệ và file thực sự tồn tại
                    picPreview.Image = Image.FromFile(spChon.HinhAnh);
                }
                else
                {
                    picPreview.Image = null; // Xóa ảnh preview nếu không có đường dẫn hoặc file không tồn tại
                }
                if (spChon != null)
                {
                    // Cập nhật các thông tin chi tiết của sản phẩm được chọn
                    lbDetailTenSP.Text = spChon.TenSP;
                    lbDetailGia.Text = "Đơn giá: " + spChon.DonGia.ToString("N0") + " VNĐ";
                    lbDetailXuatXu.Text = "Xuất xứ: " + spChon.XuatXu;
                    lbDetailDVT.Text = "Đơn vị tính: " + spChon.DonViTinh;
                    txtDetailMoTa.Text = spChon.MoTa;
                    lbDetailSoLuong.Text = "Tồn kho: " + spChon.SoLuongTon.ToString();
                }
            }
            else
            {
                // Nếu không có gì được chọn, xóa trắng các thông tin
                picPreview.Image = null;
                lbDetailTenSP.Text = "(Chưa chọn sản phẩm)";
                lbDetailGia.Text = "Đơn giá:";
                lbDetailXuatXu.Text = "Xuất xứ:";
                lbDetailDVT.Text = "Đơn vị tính:";
                txtDetailMoTa.Text = "";
            }
        }

        private void txtMoTa_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            // Khi người dùng nhập từ khóa tìm kiếm, gọi hàm LoadDataToGrid với từ khóa đó
            string tuKhoa = txtTimKiem.Text;
            LoadDataToGrid(tuKhoa);
        }

        private void dgvDanhSachSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem có hàng nào đang được chọn không.
            if (e.RowIndex >= 0)
            {
                // Lấy hàng đang được chọn trong DataGridView
                DataGridViewRow row = this.dgvDanhSachSP.Rows[e.RowIndex];

                // Lấy đối tượng HoaQua tương ứng với hàng đang được chọn
                HoaQua spChon = (HoaQua)row.DataBoundItem;

                // Kiểm tra xem đối tượng đó và dữ liệu ảnh của nó có tồn tại không
                if (spChon != null && !string.IsNullOrEmpty(spChon.HinhAnh) && File.Exists(spChon.HinhAnh))
                {
                    // Chỉ hiển thị ảnh nếu đường dẫn hợp lệ và file thực sự tồn tại
                    picPreview.Image = Image.FromFile(spChon.HinhAnh);
                }
                else
                {
                    picPreview.Image = null; // Xóa ảnh preview nếu không có đường dẫn hoặc file không tồn tại
                }
                if (spChon != null)
                {
                    // Cập nhật các thông tin chi tiết của sản phẩm được chọn
                    lbDetailTenSP.Text = spChon.TenSP;
                    lbDetailGia.Text = "Đơn giá: " + spChon.DonGia.ToString("N0") + " VNĐ";
                    lbDetailXuatXu.Text = "Xuất xứ: " + spChon.XuatXu;
                    lbDetailDVT.Text = "Đơn vị tính: " + spChon.DonViTinh;
                    txtDetailMoTa.Text = spChon.MoTa;
                    lbDetailSoLuong.Text = "Tồn kho: " + spChon.SoLuongTon.ToString();
                }
            }
            else
            {
                // Nếu không có gì được chọn, xóa trắng các thông tin
                picPreview.Image = null;
                lbDetailTenSP.Text = "(Chưa chọn sản phẩm)";
                lbDetailGia.Text = "Đơn giá:";
                lbDetailXuatXu.Text = "Xuất xứ:";
                lbDetailDVT.Text = "Đơn vị tính:";
                txtDetailMoTa.Text = "";
            }
        }

        private void dgvDanhSachSP_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            // Khi người dùng nhấn nút "Báo cáo doanh thu", mở form báo cáo doanh thu
            FormBaoCaoDoanhThu formBaoCao = new FormBaoCaoDoanhThu();
            formBaoCao.Show(); 

        }

        private void dgvDanhSachSP_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Kiểm tra xem có phải là hàng dữ liệu không
            if (e.RowIndex >= 0)
            {
                // Lấy đối tượng sản phẩm tương ứng với hàng
                HoaQua sp = this.dgvDanhSachSP.Rows[e.RowIndex].DataBoundItem as HoaQua;
                if (sp != null)
                {
                    // Nếu sản phẩm đã ngừng kinh doanh (TrangThai = false)
                    if (!sp.TrangThai)
                    {
                        // Tô màu xám cho cả hàng
                        e.CellStyle.BackColor = Color.LightGray;
                        e.CellStyle.ForeColor = Color.DarkGray;
                    }
                }
            }
        }
    }
}
