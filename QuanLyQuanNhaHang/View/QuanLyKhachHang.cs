using QuanLyQuanCafe.Controller.BLL;
using QuanLyQuanCafe.Controller.DAL;
using QuanLyQuanCafe.Model;
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
    public partial class QuanLyKhachHang : Form
    {
        public QuanLyKhachHang()
        {
            InitializeComponent();
            this.loadDSKhachHang();
        }

        public void loadDSKhachHang()
        {
            List<KhachHangHienThi> list = XuLyKhachHangController.Instance.XuLyHienThiKhachHang();
            dtgKhachHang.DataSource = list;
        }

        private void dtgKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            bntSuaKH.Enabled = true;
            bntXoaKH.Enabled = true;
            bntXacNhanKH.Enabled = false;
            bntHuyKH.Enabled = false;
            int dong = e.RowIndex;
            if(dong >=0)
            {
                txtMaKH.Text = dtgKhachHang.Rows[dong].Cells["id"].Value.ToString();
                txtHoKH.Text = dtgKhachHang.Rows[dong].Cells["fname"].Value.ToString();
                txtTenKH.Text = dtgKhachHang.Rows[dong].Cells["lname"].Value.ToString();
                //if(!(dtgKhachHang.Rows[dong].Cells["ngsinh"].Value.ToString() == ""))
                dtpickerNgaySinhKH.Value = Convert.ToDateTime(dtgKhachHang.Rows[dong].Cells["ngsinh"].Value.ToString());
                cbbGioiTinhKH.Text = dtgKhachHang.Rows[dong].Cells["gioitinh"].Value.ToString();
                txtDiaChiKG.Text = dtgKhachHang.Rows[dong].Cells["adress"].Value.ToString();
                txtEmailKH.Text = dtgKhachHang.Rows[dong].Cells["email"].Value.ToString();
                txtPhoneKH.Text = dtgKhachHang.Rows[dong].Cells["phone"].Value.ToString();
                txtDiemKH.Text = dtgKhachHang.Rows[dong].Cells["point"].Value.ToString();
                txtSoLanKH.Text = dtgKhachHang.Rows[dong].Cells["solan"].Value.ToString();
                
            }
        }

        private void bntThemKH_Click(object sender, EventArgs e)
        {
            panelThongTinKH.Enabled = true;
            bntSuaKH.Enabled = false;
            bntXoaKH.Enabled = false;
            bntXacNhanKH.Enabled = true;
            bntHuyKH.Enabled = true;
            txtMaKH.Text = "New *";

            txtHoKH.Text = "";
            txtTenKH.Text = "";
            //if(!(dtgKhachHang.Rows[dong].Cells["ngsinh"].Value.ToString() == ""))
            
            
            txtDiaChiKG.Text = "";
            txtEmailKH.Text = "";
            txtPhoneKH.Text = "";
            txtDiemKH.Text = "0";
            txtDiemKH.Enabled = false;
            txtSoLanKH.Text = "0";
            txtSoLanKH.Enabled=false;
        }

        public bool KiemTraThongTinNhap()
        {
            if (txtHoKH.Text == "")
                return false;
            if (txtTenKH.Text== "")
                return false;
            if (cbbGioiTinhKH.SelectedIndex <0 )
                return false;
            return true;
        }

        public void ThemKhachHang()
        {
            if(!KiemTraThongTinNhap())
                MessageBox.Show("Nhập thiếu thông tin!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                KhachHang kh = new KhachHang();
                kh.Id = -1;
                kh.Fname = txtHoKH.Text;
                kh.Lname = txtTenKH.Text;
                kh.Ngsinh = dtpickerNgaySinhKH.Value;
                kh.Phone = txtPhoneKH.Text;
                kh.Email = txtEmailKH.Text;
                kh.Adress = txtDiaChiKG.Text;
                if (cbbGioiTinhKH.SelectedIndex == 0)
                    kh.Gioitinh = 1;
                else
                    kh.Gioitinh = -1;
                kh.Point = Convert.ToInt32(txtDiemKH.Text);
                kh.Solan = Convert.ToInt32(txtSoLanKH.Text);

                if (KhachHangController.Instance.insertKhachHang(kh))
                {
                    MessageBox.Show("Thêm khách hàng mới thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadDSKhachHang();
                    bntXacNhanKH.Enabled = false;
                    bntHuyKH.Enabled = false;
                    panelThongTinKH.Enabled = false;
                }

                else
                    MessageBox.Show("Có lỗi sảy ra! Kiểm tra lại!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void bntXacNhanKH_Click(object sender, EventArgs e)
        {
            if (bntThemKH.Enabled == true && bntSuaKH.Enabled == false && bntXoaKH.Enabled == false)
                ThemKhachHang();
            if (bntThemKH.Enabled == false && bntSuaKH.Enabled == true && bntXoaKH.Enabled == false)
                updateKhachHang();
        }

        private void bntSuaKH_Click(object sender, EventArgs e)
        {
            bntThemKH.Enabled = false;
            bntXoaKH.Enabled = false;
            bntXacNhanKH.Enabled = true;
            bntHuyKH.Enabled = true;
            panelThongTinKH.Enabled = true;
        }

        public void updateKhachHang()
        {
            if(!KiemTraThongTinNhap())
                MessageBox.Show("Nhập thiếu thông tin!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else 
            {
                KhachHang kh = new KhachHang();
                kh.Id =Convert.ToInt32( txtMaKH.Text);
                kh.Fname = txtHoKH.Text;
                kh.Lname = txtTenKH.Text;
                kh.Ngsinh = dtpickerNgaySinhKH.Value;
                kh.Phone = txtPhoneKH.Text;
                kh.Email = txtEmailKH.Text;
                kh.Adress = txtDiaChiKG.Text;
                if (cbbGioiTinhKH.SelectedIndex == 0)
                    kh.Gioitinh = 1;
                else
                    kh.Gioitinh = -1;
                kh.Point = Convert.ToInt32(txtDiemKH.Text);
                kh.Solan = Convert.ToInt32(txtSoLanKH.Text);

                if (KhachHangController.Instance.updateKhachHang(kh))
                {
                    MessageBox.Show("Sửa thông tin thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadDSKhachHang();
                    bntXacNhanKH.Enabled = false;
                    bntHuyKH.Enabled = false;
                    panelThongTinKH.Enabled = false;
                    bntThemKH.Enabled = true;
                    bntSuaKH.Enabled = false;
                    bntXoaKH.Enabled = false;
                }

                else
                    MessageBox.Show("Có lỗi sảy ra! Kiểm tra lại!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void bntXoaKH_Click(object sender, EventArgs e)
        {
            if(txtMaKH.Text != null)
            {
                KhachHang kh = new KhachHang();
                kh.Id = Convert.ToInt32(txtMaKH.Text);
                if(XuLyKhachHangController.Instance.deleteKhachHang(kh))
                {
                    MessageBox.Show("Xóa khách hàng thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadDSKhachHang();
                    bntXacNhanKH.Enabled = false;
                    bntHuyKH.Enabled = false;
                    panelThongTinKH.Enabled = false;
                    bntThemKH.Enabled = true;
                    bntSuaKH.Enabled = false;
                    bntXoaKH.Enabled = false;
                }
                else MessageBox.Show("Có lỗi sảy ra! Kiểm tra lại!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
    }
}
