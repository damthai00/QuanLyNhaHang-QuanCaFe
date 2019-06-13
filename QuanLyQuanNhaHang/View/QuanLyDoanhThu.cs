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

namespace QuanLyQuanCafe
{
    public partial class QuanLyDoanhThu : Form
    {
        public QuanLyDoanhThu()
        {
            InitializeComponent();
            this.loadHoaDon();
        }


        public void loadHoaDon()
        {
            List<HoaDonHienThi> list = XuLyHoaDonController.Instance.loadHoaDon();
            dtgHoaDon.DataSource = list;
 
        }


        public void loadCTHD(int id_hoadon)
        {
            DataTable dt = XuLyCTHoaDonController.Instance.getCTHoaDonDoanhThuByIDHoaDon(id_hoadon);

            List<CTHoaDonHienThi> list = XuLyCTHoaDonController.Instance.getListHienThi(dt);

            dtgCTHD.DataSource = list;
        }

        private void dtgHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
              int dong = e.RowIndex;
            
            if(dong >=0)
            {
                int id_hoadon =Convert.ToInt32( dtgHoaDon.Rows[dong].Cells["id_hoadon"].Value);
                loadCTHD(id_hoadon);
            }
        }

    }
}
