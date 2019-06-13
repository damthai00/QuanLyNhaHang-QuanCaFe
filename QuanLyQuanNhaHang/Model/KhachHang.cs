using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.View
{
    class KhachHang
    {
        //private int id;
        //private String fname;
        //private String lname;
        //private DateTime ngsinh;
        //private int gioitinh;
        //private String phone;
        //private String email;
        //private String adress;
        //private int point;
        //private int solan;


        public KhachHang() { }

        public KhachHang(DataRow row) {
            {
                this.id = (int)row["id"];
                this.fname = row["fname"].ToString();
                this.lname = row["lname"].ToString();
                this.ngsinh = (DateTime)row["ngsinh"];
                this.gioitinh = (int)row["gioitinh"];
                this.phone = row["phone"].ToString();
                this.email = row["email"].ToString();
                this.adress = row["adress"].ToString();
                this.point =(int) row["point"];
                this.solan = (int)row["solan"];
            }
        }

        private int id;

        public int Id
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
        private DateTime ngsinh;

        public DateTime Ngsinh
        {
            get { return ngsinh; }
            set { ngsinh = value; }
        }
        private int gioitinh;

        public int Gioitinh
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
        private int point;

        public int Point
        {
            get { return point; }
            set { point = value; }
        }
        private int solan;

        public int Solan
        {
            get { return solan; }
            set { solan = value; }
        }
    }
}
