using QuanLyQuanCafe.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.Controller.BLL
{
    class XuLyHoaDonController
    {
        private static XuLyHoaDonController instance;

        internal static XuLyHoaDonController Instance
        {
            get { if (instance == null) instance = new XuLyHoaDonController(); return XuLyHoaDonController.instance; }
            set { XuLyHoaDonController.instance = value; }
        }


        public XuLyHoaDonController() { }


        public List<HoaDonHienThi> loadHoaDon()
        {
            List<HoaDonHienThi> list = new List<HoaDonHienThi>();
            DataTable dt = HoaDonController.Instance.getAllHoaDonHienThi();

            foreach(DataRow item in dt.Rows)
            {
                String id = item["id"].ToString();
                String id_khachhang = item["fname"].ToString() + "  "+item["lname"];
                String id_ban = item["ten"].ToString();
                String ngayhd = item["ngayhd"].ToString();
                String sotien = item["sotien"].ToString();
                String trangthai;
                if ((int)item["trangthai"] == 1)
                    trangthai = "Chưa thanh toán";
                else
                    trangthai = "Đã thanh toán";
                HoaDonHienThi dh = new HoaDonHienThi(id, id_ban, id_khachhang, ngayhd, sotien, trangthai);
                list.Add(dh);

            }

            return list;
        }

        public int getMAXIDHoaDon()
        {
            return HoaDonController.Instance.getMaxIDHoaDon();
        }
        public int getIdHoaDonTheoBan(int id)
        {
            return HoaDonController.Instance.getIdHoaDonUnCheck_TheoIdBan(id);
        }

        public int getIDHoaDonDefault()
        {
            int id_hoadon = -1;
            DataTable dt = BanController.Instance.getAllBan();
            int id_ban = (int)dt.Rows[0]["id"];
            id_hoadon = HoaDonController.Instance.getIdHoaDonUnCheck_TheoIdBan(id_ban);

            return id_hoadon;
        }


        public bool AddHoaDon(HoaDon hd)
        {
           return HoaDonController.Instance.addHoaDon(hd);
        }
    }
}
