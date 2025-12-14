using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_li_sinh_vien.DAL
{
    public class DbHelper
    {
        private static readonly string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\ASUS TUF\\Documents\\QuanLiSinhVien.mdf\";Integrated Security=True;Connect Timeout=30;Encrypt=True";
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
