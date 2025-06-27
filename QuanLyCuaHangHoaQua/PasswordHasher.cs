using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace QuanLyCuaHangHoaQua
{
    public static class PasswordHasher
    {
        // Hàm này nhận mật khẩu gốc và trả về một chuỗi hash đã được băm bằng thuật toán SHA-256
        public static string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Chuyển đổi mật khẩu thành mảng byte và băm nó
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        // Hàm này so sánh mật khẩu gốc với một chuỗi hash đã có
        public static bool VerifyPassword(string password, string hashedPassword)
        {
            // Băm mật khẩu được nhập vào
            string hashOfInput = HashPassword(password);

            // So sánh hai chuỗi hash
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;
            return comparer.Compare(hashOfInput, hashedPassword) == 0;
        }
    }
}
