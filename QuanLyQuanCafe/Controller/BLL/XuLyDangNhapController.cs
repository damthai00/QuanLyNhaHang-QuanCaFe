using QuanLyQuanCafe.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace QuanLyQuanCafe.Controller
{
    class XuLyDangNhapController
    {
        private static XuLyDangNhapController instance;

        internal static XuLyDangNhapController Instance
        {
            get { if (instance == null) instance = new XuLyDangNhapController(); return XuLyDangNhapController.instance; }
            set { XuLyDangNhapController.instance = value; }
        }


        private XuLyDangNhapController()
        {
        }

        public bool XuLyDangNhap(String user, String pass)
        {
            DataTable dt = TaiKhoanController.Instance.getTaiKhoan(user, pass);
            List<TaiKhoan> list = new List<TaiKhoan>();

            if (dt.Rows.Count > 0)
                return true;
            else return false;

        }
    }


}
