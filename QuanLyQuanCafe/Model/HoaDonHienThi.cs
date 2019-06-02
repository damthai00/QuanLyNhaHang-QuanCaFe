using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.Model
{
    class HoaDonHienThi
    {
        //  int id;
        //  int id_ban;
        //  int id_khachhang;
        //  DateTime ngayhd;
        //   float sotien;
        //   int trangthai;


        public HoaDonHienThi() { }

        public HoaDonHienThi(String id, String id_ban, String id_khachhang, String ngayhd, String sotien, String trangthai)
        {
            this.id = id;
            this.id_ban = id_ban;
            this.id_khachhang = id_khachhang;
            this.ngayhd = ngayhd;
            this.sotien = sotien;
            this.trangthai = trangthai;
        }

        public HoaDonHienThi(DataRow row)
        {
            this.id = row["id"].ToString();
            this.id_ban =row["id_ban"].ToString();
            this.id_khachhang = row["id_khachhang"].ToString();
            this.ngayhd = row["ngayhd"].ToString();
            this.sotien = row["sotien"].ToString();
            this.trangthai = row["trangthai"].ToString();
        }


        private String id;

        public String Id
        {
            get { return id; }
            set { id = value; }
        }
        private String id_ban;

        public String Id_ban
        {
            get { return id_ban; }
            set { id_ban = value; }
        }
        private String id_khachhang;

        public String Id_khachhang
        {
            get { return id_khachhang; }
            set { id_khachhang = value; }
        }
        private String ngayhd;

        public String Ngayhd
        {
            get { return ngayhd; }
            set { ngayhd = value; }
        }
        private String sotien;

        public String Sotien
        {
            get { return sotien; }
            set { sotien = value; }
        }
        private String trangthai;

        public String Trangthai
        {
            get { return trangthai; }
            set { trangthai = value; }
        }
    }
}
