using QuanLyQuanCafe.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.Controller
{
    class XuLyThucDonController
    {
        private static XuLyThucDonController instance;

        internal static XuLyThucDonController Instance
        {
            get { if (instance == null) instance = new XuLyThucDonController(); return XuLyThucDonController.instance; }
           private set {instance = value; }
        }
        private XuLyThucDonController() { }

        public List<ThucDonHienThi> XuLyThucDon()
        {
            DataTable dt = ThucDonController.Instance.getAllThucDon2();
            List<ThucDonHienThi> list = new List<ThucDonHienThi>();

            foreach (DataRow item in dt.Rows)
            {
                ThucDonHienThi tdht = new ThucDonHienThi(item);
                list.Add(tdht);
            }

            return list;
        }

        public List<ThucDonHienThi> XuLyThucDonConHang()
        {
            DataTable dt = ThucDonController.Instance.getThucDonConHang();
            List<ThucDonHienThi> list = new List<ThucDonHienThi>();

            foreach (DataRow item in dt.Rows)
            {
                ThucDonHienThi tdht = new ThucDonHienThi(item);
                list.Add(tdht);
            }

            return list;
        }

        public List<ThucDonHienThi> XuLyThucDonTimTheoTen(String ten)
        {
            DataTable dt = ThucDonController.Instance.getThucDonTheoTen(ten);

            List<ThucDonHienThi> list = new List<ThucDonHienThi>();
            foreach (DataRow item in dt.Rows)
            {
                ThucDonHienThi thucdon = new ThucDonHienThi(item);
                list.Add(thucdon);
            }
            return list;
        }

        public DataTable getAllThucDon()
        {
           DataTable dt = ThucDonController.Instance.getAllThucDon();

            return dt;
        }

        public DataTable getThucDonTheoID(int id){
            return ThucDonController.Instance.getThucDonTheoID(id);
        }

        public List<ThucDonHienThi> XuLyThucDonTimTheoID(int id)
        {
            DataTable dt = ThucDonController.Instance.getThucDonTheoID(id);
            List<ThucDonHienThi> list = new List<ThucDonHienThi>();
            foreach(DataRow item in dt.Rows)
            {
                ThucDonHienThi thucdon = new ThucDonHienThi(item);
                list.Add(thucdon);
            }
            return list;
        }

        public bool UpdateSoLuongThucDon(int id, int soluong)
        {
            return ThucDonController.Instance.updateSoLuongThucDonTheoId(id, soluong);
        }

        public int getIDNewThucDon()
        {
            int idNew = 0;
            DataTable dt = ThucDonController.Instance.getLastThucDon();
            
            foreach(DataRow item in dt.Rows)
            {
                idNew = (int)item["id"];
            }
            return idNew + 1;
        }

        public bool insertThucDon(ThucDon thucdon)
        {
            return ThucDonController.Instance.insertThucDon(thucdon);
        }

        public bool updateThucDon(ThucDon thucdon)
        {
            return ThucDonController.Instance.updateThucDon(thucdon);
        }
    }
}
