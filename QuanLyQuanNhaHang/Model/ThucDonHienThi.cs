using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.Model
{
    class ThucDonHienThi
    {
        private String id;

        public String Id
        {
            get { return id; }
            set { id = value; }
        }
        private String ten;

        public String Ten
        {
            get { return ten; }
            set { ten = value; }
        }
        private String ten_loai;

        public String Ten_loai
        {
            get { return ten_loai; }
            set { ten_loai = value; }
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
        private String trangthai;

        public String Trangthai
        {
            get { return trangthai; }
            set { trangthai = value; }
        }
        private String id_loai;

        public String Id_loai
        {
            get { return id_loai; }
            set { id_loai = value; }
        }

        public ThucDonHienThi(DataRow row)
        {
            this.id = row["id"].ToString();
            this.ten = row["ten"].ToString();
            this.ten_loai = row["ten_loaithucdon"].ToString();
            this.soluong = row["soluong"].ToString();
            this.dongia = row["dongia"].ToString();
            this.trangthai = row["trangthai"].ToString();
            
            this.id_loai = row["id_loai"].ToString();
            if (this.Trangthai == "0")
                this.Trangthai = "Hết hàng";
            if (this.Trangthai == "1")
                this.Trangthai = "Còn hàng";
            if (this.Trangthai == "2")
                this.Trangthai = "Tạm ngưng bán";
            if (this.Trangthai == "-1")
                this.Trangthai = "Ngừng kinh doanh";
            this.Id_loai = row["id_loai"].ToString();
        }

    }
}
