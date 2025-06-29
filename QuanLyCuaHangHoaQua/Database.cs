using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace QuanLyCuaHangHoaQua
{
    public static class Database
    {
        private static string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=QuanLyCuaHangHoaQua;Trusted_Connection=True;";
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
        public static List<HoaQua> GetAllProducts(string tuKhoa = "")
        {
            List<HoaQua> danhSachHoaQua = new List<HoaQua>();
            try
            {
                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    // Id bị nhảy nguyên nhân là do server restart
                    // Câu lệnh SQL để lấy danh sách sản phẩm với số thứ tự
                    string query = "SELECT ROW_NUMBER() OVER (ORDER BY TenSP ASC) AS STT, Id, TenSP, DonViTinh, DonGia, XuatXu, HinhAnh, MoTa, SoLuongTon FROM SanPham";

                    // Kiểm tra nếu có từ khóa tìm kiếm
                    if (!string.IsNullOrWhiteSpace(tuKhoa))
                    {
                        query += " WHERE TenSP LIKE @tuKhoa";
                    }
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Nếu có từ khóa tìm kiếm, thêm tham số vào câu lệnh
                        if (!string.IsNullOrWhiteSpace(tuKhoa))
                        {
                            cmd.Parameters.AddWithValue("@tuKhoa", "%" + tuKhoa + "%"); // Thêm tham số để tìm kiếm
                        }

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
                                    sp.HinhAnh = Convert.ToString(reader["HinhAnh"]);
                                }
                                sp.SoLuongTon = Convert.ToInt32(reader["SoLuongTon"]);

                                danhSachHoaQua.Add(sp);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách sản phẩm: " + ex.Message);
            }
            return danhSachHoaQua;
        }
       
        // Lấy doanh thu hàng ngày trong khoảng thời gian từ ngày TuNgay đến DenNgay
        public static Dictionary<DateTime, decimal> GetDailyRevenue(DateTime fromDate, DateTime toDate)
        {
            // Kiểm tra ngày hợp lệ
            var revenueData = new Dictionary<DateTime, decimal>();
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT
                                CAST(NgayTao AS DATE) AS Ngay,
                                SUM(TongTien) AS TongDoanhThu
                             FROM HoaDon
                             WHERE NgayTao BETWEEN @TuNgay AND @DenNgay
                             GROUP BY CAST(NgayTao AS DATE)
                             ORDER BY Ngay;";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@TuNgay", fromDate);
                        cmd.Parameters.AddWithValue("@DenNgay", toDate);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                revenueData.Add(Convert.ToDateTime(reader["Ngay"]), Convert.ToDecimal(reader["TongDoanhThu"]));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy dữ liệu báo cáo: " + ex.Message);
            }
            return revenueData;
        }
    }
}
