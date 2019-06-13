using QuanLyQuanCafe.Controller.BLL;
using QuanLyQuanCafe.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanCafe.View
{
    public partial class DangKiForm : Form
    {
        public DangKiForm()
        {
            InitializeComponent();
        }

        

        public bool CheckInput()
        {
            if (txtUserName.Text == "")
            {
                MessageBox.Show("Vui lòng nhập Username!","Thông báo");
                return false;
            }
                
            if (txtPassword.Text == "")
            {
                MessageBox.Show("Vui lòng nhập Password!","Thông báo");
                return false;
            }
             if (txtConfirm.Text == "")
            {
                MessageBox.Show("Vui lòng Xác nhận mật khẩu!","Thông báo");
                return false;
            }
            if (txthovaten.Text == "")
            {
                MessageBox.Show("Vui lòng nhập Họ tên!","Thông báo");
                return false;
            }
            if (txtLoai.Text == "")
            {
                MessageBox.Show("Vui lòng nhập Loại tài khoản!","Thông báo");
                return false;
            }

            if(txtConfirm.Text != txtPassword.Text)
            {
                MessageBox.Show("Mật khẩu không khớp! Kiểm tra lại", "Thông báo");
                return false;
            }
            return true;
           
        }

        private void bntXacNhan_Click(object sender, EventArgs e)
        {
            if(CheckInput())
            {
                TaiKhoan tk = new TaiKhoan();
                tk.setUsername(txtUserName.Text);
                tk.setPasswords(txtPassword.Text);
                tk.setFullname(txthovaten.Text);
                tk.setLoai(Convert.ToInt32(txtLoai.Text));
                if(XuLyDangKiController.Instance.XuLyDangKy(tk) == 0)
                {
                    MessageBox.Show("Đăng kí thành công!","Thông báo!");
                    this.Close();
                }
                else
                    if (XuLyDangKiController.Instance.XuLyDangKy(tk) == 1)
                {
                    MessageBox.Show("Tên tài khoản đã tồn tại!", "Thông báo!");
                }
                    else
                        MessageBox.Show("Đăng kí thất bại!", "Thông báo!");
            }
        }
    }
}
