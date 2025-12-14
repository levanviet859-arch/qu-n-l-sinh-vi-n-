using Microsoft.Data.SqlClient;
using Quan_li_sinh_vien.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Quan_li_sinh_vien.BLL
{
    public class UserRepo
    {
        public string CheckUser(string username, string password)
        {
            using (SqlConnection conn = DbHelper.GetConnection())
            {
                conn.Open();
                string sql = "SELECT role FROM Users WHERE username = @username AND password_hash = @password ";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", hashPassword(password));

                    object result = cmd.ExecuteScalar();
                    return result?.ToString();
                }

            }
        }

        public static string hashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                //làm cái gì đó để mã hóa và giải mã ở đây
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
