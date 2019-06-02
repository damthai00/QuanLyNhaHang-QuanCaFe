using QuanLyQuanCafe.Controller;
using QuanLyQuanCafe.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanCafe
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void bnt_thoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát chương trình?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
                e.Cancel = true;
        }

        private void bnt_dangnhap_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Text))
                MessageBox.Show("Chưa nhập tài khoản hoặc mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                String username = txtUsername.Text;
                String password = txtPassword.Text;
               
                if (XuLyDangNhapController.Instance.XuLyDangNhap(username, password))
                {
                    ManangerForm f = new ManangerForm();
                    this.Hide();
                    f.ShowDialog();
                    this.Show();
                }
                else
                    MessageBox.Show("Sai tài khoản hoặc mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }                 
        }

        private void label3_Click(object sender, EventArgs e)
        {
            DangKiForm f = new DangKiForm();
            f.ShowDialog();
        }
    }
}
