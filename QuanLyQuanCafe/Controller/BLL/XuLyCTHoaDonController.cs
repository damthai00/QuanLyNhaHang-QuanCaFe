using QuanLyQuanCafe.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.Controller
{
    class XuLyCTHoaDonController
    {
        private static XuLyCTHoaDonController instance;

        internal static XuLyCTHoaDonController Instance
        {
            get { if (instance == null) instance =new XuLyCTHoaDonController(); return instance; }
           private set { instance = value; }
        }

        private XuLyCTHoaDonController() { }

        public DataTable getCTHoaDon_TheoIdBan(int id_ban)
        {
            DataTable dt = new DataTable();
            int id_hoadon = HoaDonController.Instance.getIdHoaDonUnCheck_TheoIdBan(id_ban);
            dt = CTHoaDonController.Instance.getCTHoaDonHienThi(id_hoadon);

            return dt;
        }


        public List<CTHoaDonHienThi> getListHienThi(DataTable dt)
        {
            List<CTHoaDonHienThi> list = new List<CTHoaDonHienThi>();

            foreach(DataRow item in dt.Rows)
            {
                String ten_thucdon = item["ten"].ToString();
                String soluong = item["soluong"].ToString();
                String dongia = item["dongia"].ToString();
                String thanhtien = (Convert.ToInt32(soluong) * Convert.ToInt32(dongia)).ToString();

                CTHoaDonHienThi x = new CTHoaDonHienThi(ten_thucdon,soluong,dongia,thanhtien);
                list.Add(x);

            }
            return list;
        }

        public bool addCTHoaDon(CTHoaDon cthd)
        {
            return CTHoaDonController.Instance.addCTHoaDon(cthd);
        }
    }
}
