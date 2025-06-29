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

                // Xóa dữ liệu cũ trên chart trước khi vẽ cái mới
                chartDoanhThu.Series["DoanhThu"].Points.Clear();

                // Định dạng cho trục Y (trục tiền) hiển thị dạng số có dấu phẩy
                chartDoanhThu.ChartAreas[0].AxisY.LabelStyle.Format = "N0";

                // Lặp qua dữ liệu và thêm các điểm vào chart
                foreach (var dataPoint in revenueData)
                {
                    // Thêm một điểm dữ liệu với trục X là Ngày, trục Y là Doanh thu
                    chartDoanhThu.Series["DoanhThu"].Points.AddXY(dataPoint.Key.ToShortDateString(), dataPoint.Value);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
