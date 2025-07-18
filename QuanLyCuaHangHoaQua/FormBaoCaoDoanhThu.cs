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
    public partial class FormBaoCaoDoanhThu : Form
    {
        public FormBaoCaoDoanhThu()
        {
            InitializeComponent();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy dữ liệu doanh thu từ CSDL
                var revenueData = Database.GetDailyRevenue(dtpTuNgay.Value, dtpDenNgay.Value);

                // Lấy ra Series "DoanhThu" để làm việc
                var series = chartDoanhThu.Series["DoanhThu"];

                // Xóa dữ liệu cũ trên chart
                series.Points.Clear();

                // Thiết lập loại biểu đồ là biểu đồ cột
                series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;

                // Chỉ định rằng trục X là dữ liệu kiểu ngày tháng
                series.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;

                // Định dạng nhãn trên trục X để chỉ hiển thị ngày/tháng
                chartDoanhThu.ChartAreas[0].AxisX.LabelStyle.Format = "dd/MM";

                // Định dạng cho trục Y (trục tiền)
                chartDoanhThu.ChartAreas[0].AxisY.LabelStyle.Format = "N0";
                chartDoanhThu.ChartAreas[0].AxisY.Title = "Doanh thu (VNĐ)";

                // Lặp qua dữ liệu và thêm các điểm vào chart
                foreach (var dataPoint in revenueData)
                {
                    // Thêm điểm dữ liệu: Trục X là đối tượng DateTime, trục Y là Doanh thu
                    series.Points.AddXY(dataPoint.Key, dataPoint.Value);
                }

                // Tải danh sách hoá đơn từ CSDL theo khoảng thời gian đã chọn
                var invoiceData = Database.GetInvoicesByDateRange(dtpTuNgay.Value, dtpDenNgay.Value);
                dgvHoaDon.DataSource = null;
                dgvHoaDon.DataSource = invoiceData;

                // Tùy chỉnh các cột cho DataGridView hóa đơn
                if (dgvHoaDon.Columns["Id"] != null)
                {
                    dgvHoaDon.Columns["Id"].HeaderText = "Mã HĐ";
                    dgvHoaDon.Columns["Id"].FillWeight = 20;
                }
                if (dgvHoaDon.Columns["NgayTao"] != null)
                {
                    dgvHoaDon.Columns["NgayTao"].HeaderText = "Ngày Tạo";
                    dgvHoaDon.Columns["NgayTao"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                    dgvHoaDon.Columns["NgayTao"].FillWeight = 50;
                }
                if (dgvHoaDon.Columns["TongTien"] != null)
                {
                    dgvHoaDon.Columns["TongTien"].HeaderText = "Tổng Tiền";
                    dgvHoaDon.Columns["TongTien"].DefaultCellStyle.Format = "N0";
                    dgvHoaDon.Columns["TongTien"].FillWeight = 30;
                }
                // Ẩn các cột không cần thiết
                if (dgvHoaDon.Columns["GiamGiaPhanTram"] != null) dgvHoaDon.Columns["GiamGiaPhanTram"].Visible = false;
                if (dgvHoaDon.Columns["ChiTiet"] != null) dgvHoaDon.Columns["ChiTiet"].Visible = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
