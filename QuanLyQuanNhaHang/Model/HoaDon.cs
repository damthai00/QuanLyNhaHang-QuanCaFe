using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.Model
{
    class HoaDon
    {
        //  int id;
        //  int id_ban;
        //  int id_khachhang;
        //  DateTime ngayhd;
       //   float sotien;
       //   int trangthai;


        public HoaDon() { }

        public HoaDon(int id, int id_ban, int id_khachhang, DateTime ngayhd, float sotien, int trangthai)
        {
            this.id = id;
            this.id_ban = id_ban;
            this.id_khachhang = id_khachhang;
            this.ngayhd = ngayhd;
            this.sotien = sotien;
            this.trangthai = trangthai;
        }

        public HoaDon(DataRow row)
        {
            this.id = (int)row["id"];
            this.id_ban = (int)row["id_ban"];
            this.id_khachhang = (int)row["id_khachhang"];
            this.ngayhd = (DateTime)row["ngayhd"];
            this.sotien = (float)row["sotien"];
            this.trangthai = (int)row["trangthai"];
        }


        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private int id_ban;

        public int Id_ban
        {
            get { return id_ban; }
            set { id_ban = value; }
        }
        private int id_khachhang;

        public int Id_khachhang
        {
            get { return id_khachhang; }
            set { id_khachhang = value; }
        }
        private DateTime ngayhd;

        public DateTime Ngayhd
        {
            get { return ngayhd; }
            set { ngayhd = value; }
        }
        private float sotien;

        public float Sotie
        {
            get { return sotien; }
            set { sotien = value; }
        }
        private int trangthai;

        public int Trangthai
        {
            get { return trangthai; }
            set { trangthai = value; }
        }
    }
}
