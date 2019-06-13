using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.Model
{
    class BanHienThi
    {
        private String id;
        private String ten;
        private String trangthai;

        public BanHienThi()
        {
        }
        public BanHienThi(String id,String ten,String trangthai)
        {
            this.id = id;
            this.ten = ten;
            this.trangthai = trangthai;
        }
        public BanHienThi(String ten, String trangthai)
        {
            this.ten = ten;
            this.trangthai = trangthai;
        }

          public BanHienThi(DataRow row)
        {
            this.id = row["id"].ToString();
            this.ten = row["ten"].ToString();
            if ((int)row["trangthai"] == 0)
                this.trangthai = "Còn trống";
            else
                if ((int)row["trangthai"] == 1)
                     this.trangthai = "Có khách";
                else
                    if ((int)row["trangthai"] == 2)
                        this.trangthai = "Đang sửa";
                    else
                        if ((int)row["trangthai"] == -1)
                            this.trangthai = "Ngưng sử dụng";
                        else
                            this.trangthai = "Không có thông tin";
        }

        public String Id
        {
            get { return id; }
            set { id = value; }
        }
        public String Ten
        {
            get { return ten; }
            set { ten = value; }
        }
        public String Trangthai
        {
            get { return trangthai; }
            set { trangthai = value; }
        }
    }
}
