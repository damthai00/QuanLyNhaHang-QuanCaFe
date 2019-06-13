using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.Model
{
    class Ban
    {
        private int id;
        private String ten;
        private int trangthai;

        public Ban()
        {
        }
        public Ban(int id,String name,int trangthai)
        {
            this.id = id;
            this.ten = name;
            this.trangthai = trangthai;
        }
        public Ban(String name, int trangthai)
        {
            this.ten = name;
            this.trangthai = trangthai;
        }


        public Ban(DataRow row)
        {
            this.id = (int)row["id"];
            this.ten = row["ten"].ToString();
            this.trangthai = (int)row["trangthai"];
        }


        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public String Name
        {
            get { return ten; }
            set { ten = value; }
        }
        public int Trangthai
        {
            get { return trangthai; }
            set { trangthai = value; }
        }
    }
}
