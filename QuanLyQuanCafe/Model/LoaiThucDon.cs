using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.Model
{
    class LoaiThucDon
    {
         //int id;
        // String ten;

        public LoaiThucDon() { }

        public LoaiThucDon(int id,  String ten) 
        {
            this.id = id;
            this.ten = ten;
        }

        public LoaiThucDon( String ten)
        {
            this.ten = ten;
        }

        public LoaiThucDon(DataRow row)
        {
            this.id = (int)row["id"];
            this.ten = row["ten"].ToString();
        }



        private int id;

        public int Id
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
    }
}
