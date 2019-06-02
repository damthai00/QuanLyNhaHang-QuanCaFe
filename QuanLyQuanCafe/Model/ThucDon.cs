using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.Model
{
    class ThucDon
    {
       // private int id;
        //private String ten;
       // private int id_loaithucdon;
       // private int soluong;
       // private float dongia;
       // private String trangthai;


        public ThucDon() { }
        public ThucDon(int id,String ten,int id_loaithucdon,int soluong,float dongia,int trangthai)
        {
            this.id = id;
            this.ten = ten;
            this.id_loaithucdon = id_loaithucdon;
            this.soluong = soluong;
            this.dongia = dongia;
            this.trangthai = trangthai;
        }
        public ThucDon(String ten, int id_loaithucdon, int soluong, float dongia, int trangthai) 
        {
            this.ten = ten;
            this.id_loaithucdon = id_loaithucdon;
            this.soluong = soluong;
            this.dongia = dongia;
            this.trangthai = trangthai;
        }
        public ThucDon(DataRow row) 
        {
            this.id = (int)row["id"];
            this.ten = row["ten"].ToString();
            this.id_loaithucdon = (int)row["id_loaithucdon"];
            this.soluong = (int)row["soluong"];
           // this.dongia = (float)row["dongia"];
            this.trangthai =(int) row["trangthai"];
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
        private int id_loaithucdon;

        public int Id_loaithucdon
        {
            get { return id_loaithucdon; }
            set { id_loaithucdon = value; }
        }
        private int soluong;

        public int Soluong
        {
            get { return soluong; }
            set { soluong = value; }
        }
        private float dongia;

        public float Dongia
        {
            get { return dongia; }
            set { dongia = value; }
        }
        private int trangthai;

        public int Trangthai
        {
            get { return trangthai; }
            set { trangthai = value; }
        }

   
    }
}
