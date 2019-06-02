using QuanLyQuanCafe.Controller;
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
using QuanLyQuanCafe.View;

namespace QuanLyQuanCafe
{
    public partial class ManangerForm : Form
    {
        public ManangerForm()
        {
            InitializeComponent();
            this.loadBan();
            this.loadDSThucDon();
            this.cbbTimKiemThucDon.SelectedIndex =1;
            loadCBBBan();
        }

        private void nhàHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyNhaHangForm f = new QuanLyNhaHangForm();
            f.ShowDialog();
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyNhanVienForm f = new QuanLyNhanVienForm();
            f.ShowDialog();
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyKhachHang f = new QuanLyKhachHang();
            f.ShowDialog();
        }

        private void doanhThuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyDoanhThu f = new QuanLyDoanhThu();
            f.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pn_goimon.Enabled = true;
            loadDSThucDon();
        }


        public void loadBan()
        {
            fpnBan.Controls.Clear();
            List<Ban> list = XuLyBanController.Instance.getBanSuDung();


            foreach(Ban item in list)
            {
                Button button = new Button();
                button.Name = item.Id.ToString();
                button.Width = 60;
                button.Height = 60;
                button.Text = item.Name.ToString();
                if (item.Trangthai == 0)
                    button.BackColor = Color.WhiteSmoke;
                else
                    button.BackColor = Color.Red;

                this.fpnBan.Controls.Add(button);
                button.Click +=button_Click;
            }
        }

        public void showCTHoaDon(int id_ban)
        {
            
            int id_hoadon = HoaDonController.Instance.getIdHoaDonUnCheck_TheoIdBan(id_ban);

            String id = id_hoadon.ToString();

           // MessageBox.Show(id, "Thông báo", MessageBoxButtons.OKCancel);
            DataTable dt = XuLyCTHoaDonController.Instance.getCTHoaDon_TheoIdBan(id_ban);

           List<CTHoaDonHienThi> list = XuLyCTHoaDonController.Instance.getListHienThi(dt);
            
           dtgCTHD.DataSource = list;
          
            double Tong = 0;
            for (int i = 0; i < list.Count; i++)
                Tong = Tong + double.Parse(list[i].Thanhtien);
            String TongString = ChuyenDoi.Instance.ChuyenDoiThanhTien(Tong.ToString());
            //MessageBox.Show(TongString, "", MessageBoxButtons.OK);
            lbTongTien.Text = TongString;
            //MessageBox.Show(String.Format("{0:0,0} VNĐ", Tong),"",MessageBoxButtons.OK);
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button bnt = (sender as Button);
            int id_ban =Convert.ToInt32((sender as Button).Name);
            if (XuLyBanController.Instance.checkBan(id_ban))
                this.showCTHoaDon(id_ban);
            else
            {
                dtgCTHD.DataSource = new List<CTHoaDonHienThi>();
                lbTongTien.Text = "";
            }
                
            lbTenBan.Text = bnt.Text;

            if (this.pn_goimon.Enabled == true)
            {
                cbbMaBanChon.SelectedValue = id_ban;
               // MessageBox.Show(cbbMaBanChon.SelectedValue.ToString(), "", MessageBoxButtons.OK);
            }
               
        }

        public void loadDSThucDon()
        {
            List<ThucDonHienThi>  dt= XuLyThucDonController.Instance.XuLyThucDonConHang();
            this.dtgThucDon.DataSource = dt;
        }


        public void loadCBBBan()
        {
            DataTable dtban = XuLyBanController.Instance.loadBanDTT();
            cbbMaBanChon.DataSource = dtban;
            cbbMaBanChon.DisplayMember = "id";
            cbbMaBanChon.ValueMember = "id";
            

            cbbTenBanChon.DataSource = dtban;
            cbbTenBanChon.DisplayMember = "ten";
            cbbTenBanChon.ValueMember = "id";

            //Load dữ liệu cho comboBox chọn thực đơn  khi gọi món
            DataTable dtThucDon = XuLyThucDonController.Instance.getAllThucDon();
            cbbMaTDChon.DataSource = dtThucDon;
            cbbMaTDChon.DisplayMember = "id";
            cbbMaTDChon.ValueMember = "id";

            cbbTenTDChon.DataSource = dtThucDon;
            cbbTenTDChon.DisplayMember = "ten";
            cbbTenTDChon.ValueMember = "id";

        }

        private void cbbMaBanChon_SelectedIndexChanged(object sender, EventArgs e)
        {

            int id_ban = -1;
            int id_hoadon = -1;
            if (cbbMaBanChon.SelectedItem != null)
            {
                DataRowView item = (DataRowView)cbbMaBanChon.SelectedItem;
                DataRow dtr = (DataRow)item.Row;
                id_ban = Convert.ToInt32(dtr["id"]);
                id_hoadon = XuLyHoaDonController.Instance.getIdHoaDonTheoBan(id_ban);
            }
            
           
             if (id_hoadon != -1){
                 this.txtIDHoaDonChon.Text = id_hoadon.ToString();
                 lbbbb.Visible = false;
             }
                 
             else
             {
                 id_hoadon = XuLyHoaDonController.Instance.getMAXIDHoaDon() + 1;
                 this.txtIDHoaDonChon.Text = id_hoadon.ToString();
                 lbbbb.Visible = true;
             }

            
        }

        private void cbbMaTDChon_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idTD = -1;
            if(cbbMaTDChon.SelectedItem != null)
            {
                DataRowView  item = (DataRowView) cbbMaTDChon.SelectedItem;
                 DataRow dtr = (DataRow)item.Row;
                idTD = Convert.ToInt32(dtr["id"]);
            }
            int soluong = -1;
            
            DataTable dt = XuLyThucDonController.Instance.getThucDonTheoID(idTD);
            if(dt.Rows.Count >0)
            {
                soluong = (int)dt.Rows[0]["soluong"];
                txtSoLuongTDConLai.Text = soluong.ToString();
                double gia = (double)dt.Rows[0]["dongia"];
                txtDonGiaTDChon.Text = ChuyenDoi.Instance.ChuyenDoiThanhTien(gia.ToString());

                txtSoTienChon.Text = (Convert.ToDouble(nbrSoLuong.Value) * gia).ToString();
                nbrSoLuong.Maximum = soluong;
                nbrSoLuong.Value = 0;
            }
 
        }

        private void nbrSoLuong_ValueChanged(object sender, EventArgs e)
        {
            double gia = ChuyenDoi.Instance.ChuyenDoiThanhSo(txtDonGiaTDChon.Text);
            double sotien =Convert.ToDouble(nbrSoLuong.Value) * gia;
            txtSoTienChon.Text = ChuyenDoi.Instance.ChuyenDoiThanhTien( sotien.ToString());
        }

        private void bntXacNhanGoiMon_Click(object sender, EventArgs e)
        {


            if (Convert.ToInt32(txtSoLuongTDConLai.Text) < 1)
                MessageBox.Show("Thực đơn chọn tạm hết! Vui lòng chọn thực đơn khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                if (nbrSoLuong.Value < 1 || nbrSoLuong.Value > Convert.ToInt32(txtSoLuongTDConLai.Text))
                    MessageBox.Show("Chưa chọn số lượng thực đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    if (lbbbb.Visible == true)
                    {
                        HoaDon hd = new HoaDon();
                        hd.Id_ban = Convert.ToInt32(cbbMaBanChon.SelectedValue);
                        hd.Id_khachhang = -1;
                        hd.Ngayhd = new DateTime();
                        hd.Sotie = Convert.ToInt32(ChuyenDoi.Instance.ChuyenDoiThanhSo(txtSoTienChon.Text));
                        hd.Trangthai = 1;
                        if (XuLyHoaDonController.Instance.AddHoaDon(hd))
                        {
                            CTHoaDon cthd = new CTHoaDon();
                            cthd.Id_hoadon = Convert.ToInt32(txtIDHoaDonChon.Text);
                            cthd.Id_thucdon = Convert.ToInt32(cbbMaTDChon.SelectedValue);
                            cthd.Soluong = (int)nbrSoLuong.Value;
                            int soluongconlai = int.Parse(txtSoLuongTDConLai.Text) - (int)nbrSoLuong.Value;
                            if (XuLyCTHoaDonController.Instance.addCTHoaDon(cthd) && XuLyThucDonController.Instance.UpdateSoLuongThucDon(cthd.Id_thucdon,soluongconlai))
                            {
                                MessageBox.Show("Gọi món thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.showCTHoaDon(hd.Id_ban);
                                pn_goimon.Enabled = false;
                                loadDSThucDon();
                                if (XuLyBanController.Instance.updateTrangThaiBan(hd.Id_ban, 1))
                                {
                                    loadBan();
                                    
                                }
                                    
                            }

                            else
                                MessageBox.Show("Gọi món thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Gọi món thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        CTHoaDon cthd = new CTHoaDon();
                        cthd.Id_hoadon = Convert.ToInt32(txtIDHoaDonChon.Text);
                        
                        cthd.Id_thucdon = Convert.ToInt32(cbbMaTDChon.SelectedValue);
                        cthd.Soluong = (int)nbrSoLuong.Value;
                        int soluongconlai = int.Parse(txtSoLuongTDConLai.Text) - (int)nbrSoLuong.Value;
                        if (XuLyCTHoaDonController.Instance.addCTHoaDon(cthd) && XuLyThucDonController.Instance.UpdateSoLuongThucDon(cthd.Id_thucdon, soluongconlai))
                        {
                            MessageBox.Show("Gọi món thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.showCTHoaDon(Convert.ToInt32(cbbMaBanChon.SelectedValue));
                            pn_goimon.Enabled = false;
                            loadDSThucDon();
                            if (XuLyBanController.Instance.updateTrangThaiBan(Convert.ToInt32(cbbMaBanChon.SelectedValue), 1))
                                loadBan();
                        }

                        else
                            MessageBox.Show("Gọi món thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            DataTable dt;
            List<ThucDonHienThi> thucdon = new List<ThucDonHienThi>();
           
            if (txtSearchThucDon.Text != "" &&cbbTimKiemThucDon.SelectedIndex == 1)
            {
                 thucdon = XuLyThucDonController.Instance.XuLyThucDonTimTheoTen(txtSearchThucDon.Text);
                 dtgThucDon.DataSource = thucdon;
            }
           
             if(txtSearchThucDon.Text != "" &&cbbTimKiemThucDon.SelectedIndex == 0)
             {
                 thucdon = XuLyThucDonController.Instance.XuLyThucDonTimTheoID(Convert.ToInt32(txtSearchThucDon.Text));
                 dtgThucDon.DataSource = thucdon;
             }
             if (txtSearchThucDon.Text == "")
                this.loadDSThucDon();

        }

        private void txtSearchThucDon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(cbbTimKiemThucDon.SelectedIndex==0)
            {
                if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                    e.Handled = true;
            }          
        }

        private void cbbTimKiemThucDon_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearchThucDon.Text = "";
        }

        private void dtgThucDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int dong = e.RowIndex;
            
            if(pn_goimon.Enabled == true && dong >=0)
            {
                cbbMaTDChon.SelectedValue = dtgThucDon.Rows[dong].Cells["id"].Value;
            }
        }
    }
}
