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
    class BanController
    {
        private static BanController instance;

        public static BanController Instance
        {
            get { if (instance == null) instance = new BanController(); return instance; }
            private set { instance = value; }
        }

        public List<Ban> getListBan()
        {
            DataTable dt = getAllBan();
            List<Ban> list = new List<Ban>();
            
            foreach(DataRow item in dt.Rows)
            {
                Ban ban = new Ban(item);
                list.Add(ban);
            }
            return list;
        }
    

        private BanController()
        {
        }

        SqlDataAdapter da;
        SqlCommand cmd;
        public DataTable getAllBan()
        {
            DataTable dt = new DataTable();

            String sql = "SELECT * FROM ban";
            SqlConnection conn = DBConnection.Instance.getConnection();
           
            da = new SqlDataAdapter(sql, conn);

            conn.Open();
            da.Fill(dt);
            conn.Close();

            return dt;
        }

        public DataTable getBan(int id)
        {
            DataTable dt = new DataTable();

            String sql = "SELECT * FROM ban WHERE id = '"+id+"'";
            SqlConnection conn = DBConnection.Instance.getConnection();
            da = new SqlDataAdapter(sql,conn);
            conn.Open();
            da.Fill(dt);
            conn.Close();
            return dt;
        }

    
        public DataTable getBanSuDung()
        {
            DataTable dt = new DataTable();

            String sql = "SELECT * FROM ban WHERE trangthai = 1 or trangthai = 0";
            SqlConnection conn = DBConnection.Instance.getConnection();
            da = new SqlDataAdapter(sql, conn);
            conn.Open();
            da.Fill(dt);
            conn.Close();
            return dt;
        }

      

        public bool updateTrangThaiBan(int id,int trangthai)     
        {
            String sql = "update ban set trangthai = " +trangthai+ " where id = " + id;
            SqlConnection conn = DBConnection.Instance.getConnection();
            
                cmd = new SqlCommand(sql, conn);
                conn.Open();
                
                cmd.ExecuteNonQuery();
                conn.Close();

         

            return true;
        }

        public bool insertBan(Ban ban)
        {
            string sql = "INSERT INTO ban(ten,trangthai) VALUES (@ten,@trangthai)";
            SqlConnection conn = DBConnection.Instance.getConnection();
            try
            {
                cmd = new SqlCommand(sql, conn);
                conn.Open();

                cmd.Parameters.Add("@ten", SqlDbType.NVarChar).Value = ban.Name;
                cmd.Parameters.Add("@trangthai", SqlDbType.Int).Value = ban.Trangthai;
               
                cmd.ExecuteNonQuery();
                conn.Close();

            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public bool updateBan(Ban ban)
        {
            string sql = "UPDATE ban SET ten = @ten, trangthai = @trangthai WHERE id = @id";
            SqlConnection conn = DBConnection.Instance.getConnection();
            try
            {
                cmd = new SqlCommand(sql, conn);
                conn.Open();

                cmd.Parameters.Add("@ten", SqlDbType.NVarChar).Value = ban.Name;
                cmd.Parameters.Add("@trangthai", SqlDbType.Int).Value = ban.Trangthai;
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = ban.Id;

                cmd.ExecuteNonQuery();
                conn.Close();

            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }


        public bool deleteBan(int id)
        {
            string sql = "DELETE FROM ban WHERE id = @id";
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

    }
}
