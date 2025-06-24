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

        private void LoadDataToGrid()
        {
            // Xóa sạch dữ liệu trong DataGridView
            danhSachHoaQua.Clear();

            try
            {
                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT Id, TenSP, DonViTinh, DonGia, XuatXu, HinhAnh, MoTa FROM SanPham";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Tạo một đối tượng HoaQua mới và gán giá trị từ SqlDataReader
                                HoaQua sp = new HoaQua();
                                sp.Id = Convert.ToInt32(reader["Id"]);
                                sp.TenSP = Convert.ToString(reader["TenSP"]);
                                sp.DonViTinh = Convert.ToString(reader["DonViTinh"]);
                                sp.DonGia = Convert.ToDecimal(reader["DonGia"]);
                                sp.XuatXu = Convert.ToString(reader["XuatXu"]);
                                sp.MoTa = Convert.ToString(reader["MoTa"]);
                                if (reader["HinhAnh"] != DBNull.Value)
                                {
                                    // Chỉ khi cột HinhAnh có dữ liệu, chúng ta mới thực hiện ép kiểu
                                    sp.HinhAnh = (byte[])reader["HinhAnh"];
                                }

                                danhSachHoaQua.Add(sp);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dgvDanhSachSP.DataSource = null; // Đặt DataSource về null để làm mới
            dgvDanhSachSP.DataSource = danhSachHoaQua; // Gán lại DataSource với danh sách mới
            // Thiết lập các cột hiển thị trong DataGridView
            if (dgvDanhSachSP.Columns["HinhAnh"] != null)
            {
                dgvDanhSachSP.Columns["HinhAnh"].Visible = false;
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
            // Kiểm tra xem có hàng nào đang được chọn không.
            // Khi không có hàng nào được chọn (ví dụ lúc mới tải form), SelectedRows.Count = 0
            if (dgvDanhSachSP.SelectedRows.Count > 0)
            {
                // Lấy đối tượng HoaQua tương ứng với hàng đang được chọn
                HoaQua spChon = (HoaQua)dgvDanhSachSP.SelectedRows[0].DataBoundItem;

                // Kiểm tra xem đối tượng đó và dữ liệu ảnh của nó có tồn tại không
                if (spChon != null && spChon.HinhAnh != null)
                {
                    // Sử dụng MemoryStream để chuyển đổi mảng byte[] thành đối tượng Image
                    using (MemoryStream ms = new MemoryStream(spChon.HinhAnh))
                    {
                        picPreview.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    // Nếu sản phẩm không có ảnh, xóa ảnh đang hiển thị trên PictureBox
                    picPreview.Image = null;
                }
                if (spChon != null)
                {
                    lbDetailTenSP.Text = spChon.TenSP;
                    lbDetailGia.Text = "Đơn giá: " + spChon.DonGia.ToString("N0") + " VNĐ";
                    lbDetailXuatXu.Text = "Xuất xứ: " + spChon.XuatXu;
                    lbDetailDVT.Text = "Đơn vị tính: " + spChon.DonViTinh;
                    txtDetailMoTa.Text = spChon.MoTa;
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
    }
}
