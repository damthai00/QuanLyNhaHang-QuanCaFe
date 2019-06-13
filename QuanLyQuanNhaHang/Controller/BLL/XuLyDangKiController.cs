using QuanLyQuanCafe.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.Controller.BLL
{
    class XuLyDangKiController
    {
        private static XuLyDangKiController instance;

        internal static XuLyDangKiController Instance
        {
            get { if (instance == null) instance = new XuLyDangKiController(); return XuLyDangKiController.instance; }
            private set { XuLyDangKiController.instance = value; }
        }
        private XuLyDangKiController()
        {

        }

        public int XuLyDangKy(TaiKhoan tk)
        {
            if (TaiKhoanController.Instance.getTaiKhoan(tk.getUsername(), tk.getPasswords()).Rows.Count > 0)
                return 1;
            else
                if (TaiKhoanController.Instance.addTaiKhoan(tk))
                    return 0;
                else
                    return -1;
        }

    }
}
