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

    }
}
