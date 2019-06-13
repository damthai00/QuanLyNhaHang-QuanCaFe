using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.Model
{
    class KhachHangHienThi
    {
        public KhachHangHienThi() { }
        public KhachHangHienThi(DataRow row)
        {
            this.id = row["id"].ToString();
            this.fname = row["fname"].ToString();
            this.lname = row["lname"].ToString();
            this.ngsinh = row["ngsinh"].ToString();

            if ((int)row["gioitinh"] == 1)
                this.gioitinh = "Nam";
            else
                this.Gioitinh = "Nữ";
            this.phone = row["phone"].ToString();
            this.email = row["email"].ToString();
            this.adress = row["adress"].ToString();
            this.point = row["point"].ToString();
            this.solan = row["solan"].ToString();
        }

        private String id;

        public String Id
        {
            get { return id; }
            set { id = value; }
        }
        private String fname;

        public String Fname
        {
            get { return fname; }
            set { fname = value; }
        }
        private String lname;

        public String Lname
        {
            get { return lname; }
            set { lname = value; }
        }
        private String ngsinh;

        public String Ngsinh
        {
            get { return ngsinh; }
            set { ngsinh = value; }
        }
        private String gioitinh;

        public String Gioitinh
        {
            get { return gioitinh; }
            set { gioitinh = value; }
        }
        private String phone;

        public String Phone
        {
            get { return phone; }
            set { phone = value; }
        }
        private String email;

        public String Email
        {
            get { return email; }
            set { email = value; }
        }
        private String adress;

        public String Adress
        {
            get { return adress; }
            set { adress = value; }
        }
        private String point;

        public String Point
        {
            get { return point; }
            set { point = value; }
        }
        private String solan;

        public String Solan
        {
            get { return solan; }
            set { solan = value; }
        }
    }
}
