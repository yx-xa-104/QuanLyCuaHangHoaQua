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
            // Đảm bảo DataGridView được làm mới trước khi gán nguồn dữ liệu mới
            dgvDanhSachSP.DataSource = null;
            // Gán danh sách hoa quả vào DataGridView
            dgvDanhSachSP.DataSource = danhSachHoaQua;
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
            if (dgvDanhSachSP.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            HoaQua spChon = (HoaQua)dgvDanhSachSP.SelectedRows[0].DataBoundItem;
            DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa sản phẩm '{spChon.TenSP}' không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                danhSachHoaQua.Remove(spChon);
                LoadDataToGrid();
            }
        }
    }
}
