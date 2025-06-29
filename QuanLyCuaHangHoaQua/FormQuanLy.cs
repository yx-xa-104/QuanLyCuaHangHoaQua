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

        private void LoadDataToGrid(string tuKhoa = "") // Thêm tham số tuKhoa để lọc dữ liệu
        {
            try
            {
                // Chỉ cần gọi phương thức từ lớp Database để lấy dữ liệu
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
            FormThemSuaSanPham formThem = new FormThemSuaSanPham(danhSachHoaQua);

            // Mở form dưới dạng Dialog
            formThem.ShowDialog();

            // Gọi lại hàm LoadDataToGrid() để cập nhật lại bảng là xong.
            LoadDataToGrid();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvDanhSachSP.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Lấy sản phẩm đang được chọn trong DataGridView
            HoaQua spChon = (HoaQua)dgvDanhSachSP.SelectedRows[0].DataBoundItem;

            // Mở form sửa sản phẩm và truyền danh sách hoa quả cùng sản phẩm được chọn
            FormThemSuaSanPham formSua = new FormThemSuaSanPham(danhSachHoaQua, spChon);

            // Mở form dưới dạng Dialog
            formSua.ShowDialog();
            LoadDataToGrid();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Bước 1: Kiểm tra xem người dùng đã chọn hàng nào chưa (giữ nguyên)
            if (dgvDanhSachSP.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Bước 2: Lấy đối tượng sản phẩm từ hàng được chọn (giữ nguyên)
            HoaQua spChon = (HoaQua)dgvDanhSachSP.SelectedRows[0].DataBoundItem;

            // Bước 3: Hỏi xác nhận với một thông điệp cảnh báo mạnh mẽ hơn
            DialogResult result = MessageBox.Show(
                "Dữ liệu sẽ bị xóa vĩnh viễn! Bạn có chắc chắn muốn xóa sản phẩm: '" + spChon.TenSP + "' không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            // Bước 4: Nếu người dùng xác nhận "Yes", tiến hành xóa trong CSDL
            if (result == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = Database.GetConnection())
                    {
                        conn.Open();

                        // Viết câu lệnh DELETE với Parameter để chỉ định đúng Id
                        string query = "DELETE FROM SanPham WHERE Id = @id";

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            // Gắn giá trị cho tham số @id
                            cmd.Parameters.AddWithValue("@id", spChon.Id);

                            // Thực thi câu lệnh
                            int res = cmd.ExecuteNonQuery();

                            // Kiểm tra và thông báo kết quả
                            if (res > 0)
                            {
                                MessageBox.Show("Xóa sản phẩm thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                // Tải lại dữ liệu lên Grid để cập nhật giao diện
                                LoadDataToGrid();
                            }
                            else
                            {
                                MessageBox.Show("Xóa thất bại. Có thể sản phẩm đã được xóa bởi một người khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi trong quá trình xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            // Nếu người dùng chọn "No", không làm gì cả.
        }



        private void FormQuanLy_Load(object sender, EventArgs e)
        {
            LoadDataToGrid();
        }

        private void dgvDanhSachSP_SelectionChanged(object sender, EventArgs e)
        {
            // Đã chuyển code đến sự kiện CellClick để xử lý việc hiển thị chi tiết sản phẩm
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
            // Khi không có hàng nào được chọn (ví dụ lúc mới tải form), SelectedRows.Count = 0
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
            formBaoCao.Show(); // Dùng Show() để có thể xem báo cáo song song với form chính

        }
    }
}
