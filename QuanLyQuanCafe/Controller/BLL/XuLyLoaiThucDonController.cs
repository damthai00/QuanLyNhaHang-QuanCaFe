using QuanLyQuanCafe.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.Controller.BLL
{
    class XuLyLoaiThucDonController
    {
        private static XuLyLoaiThucDonController instance;

        internal static XuLyLoaiThucDonController Instance
        {
            get { if (instance == null) instance = new XuLyLoaiThucDonController(); return XuLyLoaiThucDonController.instance; }
            private  set { XuLyLoaiThucDonController.instance = value; }
        }

        private XuLyLoaiThucDonController() { }

        public List<LoaiThucDon> getAllLoaiThucDon()
        {
            DataTable dt = LoaiThucDonController.Instance.getAllLoaiThucDon();
            List<LoaiThucDon> list = new List<LoaiThucDon>();
            foreach (DataRow item in dt.Rows)
            {
                LoaiThucDon loaiThucDon = new LoaiThucDon(item);
                list.Add(loaiThucDon);
            }
            return list;
        }

        public bool insertLoaiThucDon(LoaiThucDon ltd)
        {
            return LoaiThucDonController.Instance.insertLoaiThucDon(ltd);
        }

        public bool updateLoaiThucDon(LoaiThucDon ltd)
        {
            return LoaiThucDonController.Instance.updatetLoaiThucDon(ltd);
        }

        public bool deleteLoaiThucDon(int id)
        {
            return LoaiThucDonController.Instance.deleteLoaiThucDon(id);
        }
    }
}
