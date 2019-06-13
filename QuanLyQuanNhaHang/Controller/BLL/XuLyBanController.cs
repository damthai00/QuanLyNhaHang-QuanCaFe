using QuanLyQuanCafe.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.Controller
{
    class XuLyBanController
    {

        private static XuLyBanController instance;

        internal static XuLyBanController Instance
        {
            get { if (instance == null) instance = new XuLyBanController(); return XuLyBanController.instance; }
            set { XuLyBanController.instance = value; }
        }


        private XuLyBanController()
        {
        }

        public List<Ban> loadBan()
        {
            return BanController.Instance.getListBan();

        }

        public DataTable loadBanDTT()
        {
            return BanController.Instance.getAllBan();
        }

        public List<Ban> getBanSuDung()
        {
            DataTable dt = BanController.Instance.getBanSuDung();
            List<Ban> list = new List<Ban>();
            foreach (DataRow item in dt.Rows)
            {
                Ban ban = new Ban(item);
                list.Add(ban);
            }

            return list;
        }

        public DataTable getBanSuDung2()
        {
            return BanController.Instance.getBanSuDung();
        }

        public DataTable getBan() {
            DataTable dt = BanController.Instance.getAllBan();
            DataTable dt2 = new DataTable();

            foreach(DataRow item in dt.Rows)
            {
                if ((int)item["trangthai"] == 1)
                    item["trangthai"] = "Có người";
                else
                    item["trangthai"] = "Có người";
            }
            return dt;
        }


        public Boolean checkBan(int id) {
            DataTable dt = BanController.Instance.getBan(id);

           foreach(DataRow item in dt.Rows)
           {
               if ((int)item["trangthai"] == 1)
                   return true;
           }
            return false;
        }

        public bool updateTrangThaiBan(int id,int trangthai)
        {
            return BanController.Instance.updateTrangThaiBan(id,trangthai);
        }
        public bool insertBan(Ban ban)
        {
            return BanController.Instance.insertBan(ban);
        }

        public bool updateBan(Ban ban)
        {
            return BanController.Instance.updateBan(ban);
        }

        public bool deleteBan(int id)
        {
            return BanController.Instance.deleteBan(id);
        }
    }
 
}
