using QuanLyQuanCafe.Controller.DAL;
using QuanLyQuanCafe.Model;
using QuanLyQuanCafe.View;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.Controller.BLL
{
    class XuLyKhachHangController
    {
        private static XuLyKhachHangController instance;

        internal static XuLyKhachHangController Instance
        {
            get { if (instance == null) instance = new XuLyKhachHangController(); return XuLyKhachHangController.instance; }
            private set { XuLyKhachHangController.instance = value; }
        }

        public XuLyKhachHangController() { }

        public List<KhachHangHienThi> XuLyHienThiKhachHang()
        {

            List<KhachHangHienThi> list = new List<KhachHangHienThi>();
            DataTable dt = KhachHangController.Instance.getAllKhachHang();
            if(dt != null)
            {
                foreach(DataRow item in dt.Rows)
                {
                    KhachHangHienThi kh = new KhachHangHienThi(item);
                    
                    list.Add(kh);
                }
                return list;
            }
            else 
                return null;
        }

        public bool insertKhachHang(KhachHang kh)
        {
            return KhachHangController.Instance.insertKhachHang(kh);
        }

        public bool updateKhachHang(KhachHang kh)
        {
            return KhachHangController.Instance.updateKhachHang(kh);
        }

        public bool deleteKhachHang(KhachHang kh)
        {
            return KhachHangController.Instance.deleteKhachHang(kh);
        }

        public double XuLyKM(int id,double sotien)
        {
            double tien = sotien;
            KhachHang kh;
            DataTable dt = KhachHangController.Instance.getKhachHangByID(id);
            
            kh = new KhachHang(dt.Rows[0]);
            
            int tongdiem;
            int tichdiem = (int) (sotien / 1000000);
            if(kh.Solan != 0)
                tongdiem= kh.Point % kh.Solan;
            else
                tongdiem = kh.Point - kh.Solan;
            
            int km = (tongdiem  + tichdiem)/ 5;
            
            tien = sotien - (sotien * km )/ 10;
            return tien;
        }


        public KhachHang XuLyKhachHang(int id,double sotien)
        {
            KhachHang kh;
            DataTable dt = KhachHangController.Instance.getKhachHangByID(id);

            kh = new KhachHang(dt.Rows[0]);

            int tichdiem = (int)(sotien / 1000000);
            int tongdiem;
            if (kh.Solan != 0)
                tongdiem = kh.Point % kh.Solan;
            else
                tongdiem = kh.Point - kh.Solan;
            int km = (tongdiem + tichdiem) / 5;
            kh.Solan = kh.Solan + km;
            kh.Point = kh.Point + tichdiem;
            return kh;
        }


        public List<KhachHang> listKhachHang()           
        { 
            DataTable dt = KhachHangController.Instance.getAllKhachHang();
            List<KhachHang> list = new List<KhachHang>();
            if(dt.Rows.Count >0)
                foreach (DataRow item in dt.Rows)
                {
                    KhachHang kh = new KhachHang(item);
                    list.Add(kh);
                }
            return list;
        }
    }
}
