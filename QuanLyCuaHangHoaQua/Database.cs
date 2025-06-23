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
    }
}
