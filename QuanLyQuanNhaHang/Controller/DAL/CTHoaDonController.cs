using QuanLyQuanCafe.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.Controller
{
    class CTHoaDonController
    {


        private static CTHoaDonController instance;

        internal static CTHoaDonController Instance
        {
            get { if (instance == null) instance = new CTHoaDonController(); return instance; }
            private set { instance = value; }
        }

        private CTHoaDonController() { }


        SqlCommand cmd;
        SqlDataAdapter da;

        public DataTable getCTHoaDon_TheoIdHoaDon(int id_hoadon)
        {
            DataTable dt = new DataTable();


            String sql = "SELECT * FROM cthoadon where id_hoadon = " + id_hoadon;
            SqlConnection conn = DBConnection.Instance.getConnection();
            SqlCommand sc = new SqlCommand(sql, conn);

            da = new SqlDataAdapter(sc);

            conn.Open();
            da.Fill(dt);
            conn.Close();

            return dt;
        }

        public DataTable getCTHoaDonDoanhThuByIDHoaDon(int id_hoadon)
        {
            DataTable dt = new DataTable();

            String sql = "SELECT cthoadon.id,thucdon.ten,cthoadon.soluong,thucdon.dongia FROM cthoadon "+
                "left join thucdon on thucdon.id = cthoadon.id_thucdon "+
                "where cthoadon.id_hoadon = "+id_hoadon;
            SqlConnection conn = DBConnection.Instance.getConnection();
            SqlCommand sc = new SqlCommand(sql, conn);

            da = new SqlDataAdapter(sc);

            conn.Open();
            da.Fill(dt);
            conn.Close();

            return dt;
        }

        public DataTable getCTHoaDonHienThi(int id_hoadon)
        {
             DataTable dt = new DataTable();

             String sql = "SELECT cthoadon.id,cthoadon.soluong,thucdon.ten,thucdon.dongia FROM cthoadon,thucdon,hoadon WHERE cthoadon.id_thucdon = thucdon.id and hoadon.id = cthoadon.id_hoadon and hoadon.id =" + id_hoadon;
            
           using( SqlConnection conn = DBConnection.Instance.getConnection())
           {
               conn.Open();
               SqlCommand sc = new SqlCommand(sql, conn);

               SqlDataAdapter sd = new SqlDataAdapter(sc);


               sd.Fill(dt);
               conn.Close();

              
           }
           return dt;
        }

        public DataTable getCTHoaDonByID(int id)
        {
            DataTable dt = new DataTable();

            String sql = "SELECT * FROM cthoadon where id = "+id;

            using (SqlConnection conn = DBConnection.Instance.getConnection())
            {
                conn.Open();
                SqlCommand sc = new SqlCommand(sql, conn);

                SqlDataAdapter sd = new SqlDataAdapter(sc);


                sd.Fill(dt);
                conn.Close();


            }
            return dt;
        }

        public bool deleteCTHoaDon(int id)
        {
            String sql = "DELETE FROM cthoadon WHERE id = @id";
            SqlConnection conn = DBConnection.Instance.getConnection();
            try
            {
                cmd = new SqlCommand(sql, conn);
                conn.Open();
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                
                cmd.ExecuteNonQuery();
                conn.Close();

            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public bool addCTHoaDon(CTHoaDon cthd)
        {
            
            String sql = "insert into cthoadon(id_hoadon,id_thucdon,soluong) values (@id_hoadon, @id_thucdon,@soluong)";
            SqlConnection conn = DBConnection.Instance.getConnection();
            try
            {
                cmd = new SqlCommand(sql, conn);
                conn.Open();
                cmd.Parameters.Add("@id_hoadon", SqlDbType.Int).Value = cthd.Id_hoadon;
                cmd.Parameters.Add("@id_thucdon", SqlDbType.Int).Value = cthd.Id_thucdon;
                cmd.Parameters.Add("@soluong", SqlDbType.Int).Value = cthd.Soluong;
                cmd.ExecuteNonQuery();
                conn.Close(); 

            }catch(Exception e)
            {
                return false;
            }
            return true;
        }


    }
}
