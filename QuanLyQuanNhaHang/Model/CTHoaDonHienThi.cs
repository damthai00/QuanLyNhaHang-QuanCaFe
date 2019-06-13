using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.Model
{
    class CTHoaDonHienThi
    {
        // ten_thucdon      -- Tên thực đơn
        //  solong          --Số lượng
        //  dongia          --Đơn giá
        // thanhtien        --Thành tiền


        public CTHoaDonHienThi() { }
        public CTHoaDonHienThi(String id,String ten, String sl, String dg,String tt) 
        {
            this.id = id;
            this.ten_thucdon = ten;
            this.soluong = sl;
            this.dongia = dg;
            this.thanhtien = tt;
        }
        private String id;

        public String Id
        {
            get { return id; }
            set { id = value; }
        }

        private String ten_thucdon;

        public String Ten_thucdon
        {
            get { return ten_thucdon; }
            set { ten_thucdon = value; }
        }
        private String soluong;

        public String Soluong
        {
            get { return soluong; }
            set { soluong = value; }
        }

        private String dongia;

        public String Dongia
        {
            get { return dongia; }
            set { dongia = value; }
        }

        private String thanhtien;

        public String Thanhtien
        {
            get { return thanhtien; }
            set { thanhtien = value; }
        }

    }
}
