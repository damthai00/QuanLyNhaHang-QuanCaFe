using QuanLyQuanCafe.Controller;
using QuanLyQuanCafe.Controller.BLL;
using QuanLyQuanCafe.Controller.DAL;
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
    public partial class TinhTienForm : Form
    {
        ManangerForm mainFrame;
        int id_ban;

      
        public void NhanDuLieu(int id_ban)
        {
            this.id_ban = id_ban;
        }
        public TinhTienForm(ManangerForm mainFrame)
        {
            InitializeComponent();
            this.mainFrame = mainFrame;
            
                loadCTHD(mainFrame.idBanClick);
        }
        double Tong = 0;
        public void loadCTHD(int id_ban)
        {
            DataTable dt = XuLyCTHoaDonController.Instance.getCTHoaDon_TheoIdBan(id_ban);

            List<CTHoaDonHienThi> list = XuLyCTHoaDonController.Instance.getListHienThi(dt);

            dtgCTHD.DataSource = list;
           
            int id_hoadon = XuLyHoaDonController.Instance.getIdHoaDonTheoBan(id_ban);
            DataTable dthd = HoaDonController.Instance.getHDTinhTien(id_hoadon);
            foreach(DataRow item in dthd.Rows)
            {
                txtIDHD.Text = item["id"].ToString();
                txtNgayHD.Text = item["ngayhd"].ToString();
                txtTenBan.Text = item["ten"].ToString();
                txtIDBan.Text = id_ban.ToString();
            }

            DataTable dtkh = KhachHangController.Instance.getAllKhachHang();
            List<KhachHang> listkh = XuLyKhachHangController.Instance.listKhachHang();
            for (int i = 0; i < listkh.Count; i++)
                listkh[i].Fname = listkh[i].Fname + listkh[i].Lname;
            cbbTenKhachHang.DataSource = listkh;
            cbbTenKhachHang.DisplayMember = "fname";
            cbbTenKhachHang.ValueMember = "id";
            

            cbbIDKH.DataSource = listkh;
            cbbIDKH.DisplayMember = "id";
            cbbIDKH.ValueMember = "id";

           
            for (int i = 0; i < list.Count; i++)
                Tong = Tong + double.Parse(list[i].Thanhtien);
            String TongString = ChuyenDoi.Instance.ChuyenDoiThanhTien(Tong.ToString());
            //MessageBox.Show(TongString, "", MessageBoxButtons.OK);
            lbTongTien.Text = TongString;
            //MessageBox.Show(String.Format("{0:0,0} VNĐ", Tong),"",MessageBoxButtons.OK);
        }

        private void cbKH_CheckedChanged(object sender, EventArgs e)
        {
            if (cbKH.Checked == true)
                panelKH.Visible = true;
            else
                panelKH.Visible = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            HoaDon hd = new HoaDon();
            hd.Id =Convert.ToInt32( txtIDHD.Text);
            hd.Id_ban = Convert.ToInt32(txtIDBan.Text);
            hd.Ngayhd = DateTime.Now;
            hd.Sotie = (float)(ChuyenDoi.Instance.ChuyenDoiThanhSo(lbTongTien.Text));
            
            hd.Trangthai = 0;
            if (cbKH.Checked == true)
            {
                hd.Id_khachhang = Convert.ToInt32(cbbIDKH.SelectedValue);
                KhachHang kh = XuLyKhachHangController.Instance.XuLyKhachHang(hd.Id_khachhang,Tong);
                if (XuLyHoaDonController.Instance.updatTinhTienHoaDon(hd) && XuLyBanController.Instance.updateTrangThaiBan(hd.Id_ban, 0) && XuLyKhachHangController.Instance.updateKhachHang(kh))
                {
                    mainFrame.loadBan();
                    mainFrame.loadCBBBan();
                    mainFrame.loadDSThucDon();
                    DialogResult dlr = MessageBox.Show("Thao tác thành công!", "Thông báo");
                    if (dlr == DialogResult.OK)
                        this.Visible = false;
                }
                else
                    MessageBox.Show("Thất bại!", "Thông báo");
            }
               
            else
            {
                hd.Id_khachhang = -1;
               
                if (XuLyHoaDonController.Instance.updatTinhTienHoaDon(hd) && XuLyBanController.Instance.updateTrangThaiBan(hd.Id_ban, 0))
                {
                    mainFrame.loadBan();
                    mainFrame.loadCBBBan();
                    mainFrame.loadDSThucDon();
                    DialogResult dlr = MessageBox.Show("Thao tác thành công!", "Thông báo");
                    if (dlr == DialogResult.OK)
                        this.Visible = false;
                }

                else
                    MessageBox.Show("Thất bại!", "Thông báo");

            }
        }

        private void cbbIDKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(cbbTenKhachHang.SelectedValue);
           double tongtien = XuLyKhachHangController.Instance.XuLyKM(id, Tong);
            lbTongTien.Text = ChuyenDoi.Instance.ChuyenDoiThanhTien(tongtien.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

     

        
     



  

 
    }
}
