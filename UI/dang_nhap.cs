using Quan_li_sinh_vien.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_li_sinh_vien.UI
{
    public partial class dang_nhap : Form
    {
        public dang_nhap()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {

            Application.Exit();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            String username = txtTenDangNhap.Text;
            String password = txtMatKhau.Text;
            UserRepo userRepo = new UserRepo();
            String role = userRepo.CheckUser(username, password);
            if (role != null)
            {
                if (role.Equals("USER"))
                {
                    MessageBox.Show("Đăng nhập thành công với quyền USER");
                    new home().Show();
                }
                else if (role.Equals("ADMIN"))
                {
                    MessageBox.Show("Đăng nhập thành công với quyền ADMIN");
                    new home().Show();
                }
                else
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu không đúng");
                }
            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không tồn tại");
            }
        }
    }
}
