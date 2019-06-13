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
        public DataTable getCTHDByIDHoaDon(int id_hoadon)
        {
            return CTHoaDonController.Instance.getCTHoaDonHienThi(id_hoadon);
        }

        public List<CTHoaDonHienThi> getListHienThi(DataTable dt)
        {
            List<CTHoaDonHienThi> list = new List<CTHoaDonHienThi>();

            foreach(DataRow item in dt.Rows)
            {
                String id = item["id"].ToString();
                String ten_thucdon = item["ten"].ToString();
                String soluong = item["soluong"].ToString();
                String dongia = item["dongia"].ToString();
                String thanhtien;
                if (dongia != "")
                    thanhtien = (Convert.ToInt32(soluong) * Convert.ToInt32(dongia)).ToString();
                else
                    thanhtien = "";

                CTHoaDonHienThi x = new CTHoaDonHienThi(id,ten_thucdon,soluong,dongia,thanhtien);
                list.Add(x);

            }
            return list;
        }

      

        public bool addCTHoaDon(CTHoaDon cthd)
        {
            return CTHoaDonController.Instance.addCTHoaDon(cthd);
        }
        public DataTable getCTHoaDonDoanhThuByIDHoaDon(int id_hoadon)
        {
            return CTHoaDonController.Instance.getCTHoaDonDoanhThuByIDHoaDon(id_hoadon);
        }

        public bool XuLyXoaCTThucDon(int id_cthd,float sotien)
        {
            //Khôi phục thực đơn (+ thêm số lượng đã trừ đi)
            DataTable dt = CTHoaDonController.Instance.getCTHoaDonByID(id_cthd);
            int id_thucdon = (int)dt.Rows[0]["id_thucdon"];
            int soluong = (int)dt.Rows[0]["soluong"];
            int id_hoadon=(int)dt.Rows[0]["id_hoadon"];

            if (ThucDonController.Instance.updateSoLuongThucDon(id_thucdon, soluong) && HoaDonController.Instance.updateSoTienHoaDonTru(sotien, id_hoadon) && CTHoaDonController.Instance.deleteCTHoaDon(id_cthd))
                return true;
            return false;
            
        }

        public int getIDBanByIDCTHD(int id_cthd)
        {
            
            
            DataTable dt = CTHoaDonController.Instance.getCTHoaDonByID(id_cthd);
            int id_thucdon = (int)dt.Rows[0]["id_thucdon"];
            int soluong = (int)dt.Rows[0]["soluong"];
            int id_hoadon = (int)dt.Rows[0]["id_hoadon"];

            

            DataTable dt2 = HoaDonController.Instance.getHDByID(id_hoadon);
            int id_ban = Convert.ToInt32(dt2.Rows[0]["id_ban"]);
            return id_ban;
        }

    }
}
