using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.Controller
{
    

    class ChuyenDoi
    {
        private static ChuyenDoi instance;

        internal static ChuyenDoi Instance
        {
            get { if (instance == null) instance = new ChuyenDoi(); return ChuyenDoi.instance; }
            private set { ChuyenDoi.instance = value; }
        }

        private ChuyenDoi() { }

        public String ChuyenDoiThanhTien(String sotien)
        {
            double sotienD = Convert.ToDouble(sotien);
           return string.Format("{0:0,0 VNĐ}",sotienD);
        }

        public double ChuyenDoiThanhSo(String tien)
        {
            String kq = "";
            for (int i = 0; i < tien.Length; i++)
            {
                Char x = tien[i];
                if (Char.IsDigit(x))
                    kq = kq + x;

            }
            return Convert.ToDouble(kq);
        }

    }
}
