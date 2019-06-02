using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.Model
{
    class CTHoaDon
    {
            // private int id;
          //  private int id_hoadon;
             //private int id_thucdon;
            // private int soluong;


        public CTHoaDon() { }

        public CTHoaDon(int id,int id_hoadon,int id_thucdon,int soluong) 
        {
            this.id = id;
            this.id_hoadon = id_hoadon;
            this.id_thucdon = id_thucdon;
            this.soluong = soluong;
        }
        public CTHoaDon(int id_hoadon, int id_thucdon, int soluong)
        {
            this.id_hoadon = id_hoadon;
            this.id_thucdon = id_thucdon;
            this.soluong = soluong;
        }
        public CTHoaDon(DataRow row)
        {
            this.id =(int) row["id"];
            this.id_hoadon = (int)row["id_hoadon"];
            this.id_thucdon = (int)row["id_thucdon"];
            this.soluong = (int)row["soluong"];
        }

         private int id;

         public int Id
         {
             get { return id; }
             set { id = value; }
         }
         private int id_hoadon;

         public int Id_hoadon
         {
             get { return id_hoadon; }
             set { id_hoadon = value; }
         }
         private int id_thucdon;

         public int Id_thucdon
         {
             get { return id_thucdon; }
             set { id_thucdon = value; }
         }
         private int soluong;

         public int Soluong
         {
             get { return soluong; }
             set { soluong = value; }
         }
    }
}
