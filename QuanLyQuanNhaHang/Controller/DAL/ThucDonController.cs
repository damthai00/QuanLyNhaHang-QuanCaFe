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
    class ThucDonController
    {
        private static ThucDonController instance;

        internal static ThucDonController Instance
        {
            get { if (instance == null) instance = new ThucDonController(); return ThucDonController.instance; }
            set { ThucDonController.instance = value; }
        }

        private ThucDonController() { }

        SqlDataAdapter da;
        SqlCommand cmd;

        public DataTable getAllThucDon()
        {
            DataTable dt = new DataTable();

            String sql = "SELECT * FROM thucdon";
            SqlConnection conn = DBConnection.Instance.getConnection();
            da = new SqlDataAdapter();
            da = new SqlDataAdapter(sql, conn);

            conn.Open();
            da.Fill(dt);
            conn.Close();

            return dt;
        }
        public DataTable getAllThucDon2()
        {
            DataTable dt = new DataTable();

            String sql = "SELECT thucdon.id,thucdon.ten,loaithucdon.ten as ten_loaithucdon,thucdon.soluong,thucdon.dongia,thucdon.trangthai,loaithucdon.id as id_loai FROM thucdon left join loaithucdon on thucdon.id_loaithucdon = loaithucdon.id order by thucdon.id";
            SqlConnection conn = DBConnection.Instance.getConnection();
            da = new SqlDataAdapter();
            da = new SqlDataAdapter(sql, conn);

            conn.Open();
            da.Fill(dt);
            conn.Close();

            return dt;
        }

        public DataTable getThucDonDangSuDung(int id_thucdon)
        {
            DataTable dt = new DataTable();

            String sql = "select cthoadon.id_thucdon from cthoadon,hoadon where cthoadon.id_hoadon = hoadon.id and hoadon.trangthai  =1 and cthoadon.id_thucdon = "+id_thucdon;
            SqlConnection conn = DBConnection.Instance.getConnection();
            da = new SqlDataAdapter();
            da = new SqlDataAdapter(sql, conn);

            conn.Open();
            da.Fill(dt);
            conn.Close();

            return dt;
        }

        public DataTable getThucDonConHang()
        {
            DataTable dt = new DataTable();

            String sql = "SELECT thucdon.id,thucdon.ten,loaithucdon.ten as ten_loaithucdon,thucdon.soluong,thucdon.dongia,thucdon.trangthai,loaithucdon.id as id_loai FROM thucdon left join loaithucdon on loaithucdon.id = thucdon.id_loaithucdon order by thucdon.id";
            SqlConnection conn = DBConnection.Instance.getConnection();
            da = new SqlDataAdapter();
            da = new SqlDataAdapter(sql, conn);

            conn.Open();
            da.Fill(dt);
            conn.Close();

            return dt;
        }

        public DataTable getThucDonTheoID(int id)
        {
            DataTable dt = new DataTable();

            String sql = "SELECT thucdon.id,thucdon.ten,loaithucdon.ten as ten_loaithucdon,thucdon.soluong,thucdon.dongia,thucdon.trangthai,loaithucdon.id as id_loai FROM thucdon,loaithucdon where thucdon.id_loaithucdon = loaithucdon.id and thucdon.trangthai = 1 and thucdon.id = " + id;
            SqlConnection conn = DBConnection.Instance.getConnection();
            da = new SqlDataAdapter();
            da = new SqlDataAdapter(sql, conn);

            conn.Open();
            da.Fill(dt);
            conn.Close();

            return dt;
        }

        public DataTable getThucDonTheoTen(String ten)
        {
            DataTable dt = new DataTable();
            String sql = "SELECT thucdon.id,thucdon.ten,loaithucdon.ten as ten_loaithucdon,thucdon.soluong,thucdon.dongia,thucdon.trangthai,loaithucdon.id as id_loai FROM thucdon,loaithucdon where thucdon.id_loaithucdon = loaithucdon.id and thucdon.trangthai = 1 and thucdon.ten like N'%" + ten + "%'";

            SqlConnection conn = DBConnection.Instance.getConnection();
            da = new SqlDataAdapter();
            da = new SqlDataAdapter(sql, conn);

            conn.Open();
            da.Fill(dt);
            conn.Close();

            return dt;
        }

        public DataTable getLastThucDon()
        {
            DataTable dt = new DataTable();

            String sql = "SELECT MAX(id) as id From thucdon ";
            SqlConnection conn = DBConnection.Instance.getConnection();
            da = new SqlDataAdapter();
            da = new SqlDataAdapter(sql, conn);

            conn.Open();
            da.Fill(dt);
            conn.Close();

            return dt;
        }

        public bool insertThucDon(ThucDon thucdon)
        {
            string sql = "INSERT INTO thucdon(ten,id_loaithucdon,soluong,dongia,trangthai) VALUES(@ten, @id_loaithucdon, @soluong, @dongia, @trangthai) ";
            SqlConnection conn = DBConnection.Instance.getConnection();
            try
            {
                cmd = new SqlCommand(sql, conn);
                conn.Open();

                cmd.Parameters.Add("@ten", SqlDbType.NVarChar).Value = thucdon.Ten;
                cmd.Parameters.Add("@id_loaithucdon", SqlDbType.Int).Value = thucdon.Id_loaithucdon;
                cmd.Parameters.Add("@soluong", SqlDbType.Int).Value = thucdon.Soluong;
                cmd.Parameters.Add("@dongia", SqlDbType.Float).Value = thucdon.Dongia;
                cmd.Parameters.Add("@trangthai", SqlDbType.NVarChar).Value = thucdon.Trangthai;

                cmd.ExecuteNonQuery();
                conn.Close();

            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public bool updateSoLuongThucDonTheoId(int id, int soluong)
        {
            if(soluong >0)
            {
                string sql = "UPDATE thucdon SET soluong = @soluong where id = @id";
                SqlConnection conn = DBConnection.Instance.getConnection();
                try
                {
                    cmd = new SqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.Add("@soluong", SqlDbType.Int).Value = soluong;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

                    cmd.ExecuteNonQuery();
                    conn.Close();

                }
                catch (Exception e)
                {
                    return false;
                }
            }
            else 
                if (soluong <= 0)
                {
                    string sql = "UPDATE thucdon SET soluong = 0,trangthai = 0 where id = @id";
                    SqlConnection conn = DBConnection.Instance.getConnection();
                    try
                    {
                        cmd = new SqlCommand(sql, conn);
                        conn.Open();
                        cmd.Parameters.Add("@soluong", SqlDbType.Int).Value = soluong;
                        cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

                        cmd.ExecuteNonQuery();
                        conn.Close();

                    }
                    catch (Exception e)
                    {
                        return false;
                    }
                }
            
            return true;
        }
        

        public bool updateThucDon(ThucDon thucdon)
        {
            string sql = "UPDATE thucdon SET ten = @ten, id_loaithucdon = @id_loaithucdon, soluong = @soluong, dongia = @dongia, trangthai = @trangthai where id = @id";
            SqlConnection conn = DBConnection.Instance.getConnection();
            try
            {
                cmd = new SqlCommand(sql, conn);
                conn.Open();

                cmd.Parameters.Add("@ten", SqlDbType.NVarChar).Value = thucdon.Ten;
                cmd.Parameters.Add("@id_loaithucdon", SqlDbType.Int).Value = thucdon.Id_loaithucdon;
                cmd.Parameters.Add("@soluong", SqlDbType.Int).Value = thucdon.Soluong;
                cmd.Parameters.Add("@dongia", SqlDbType.Float).Value = thucdon.Dongia;
                cmd.Parameters.Add("@trangthai", SqlDbType.NVarChar).Value = thucdon.Trangthai;
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = thucdon.Id;

                cmd.ExecuteNonQuery();
                conn.Close();

            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public bool updateSoLuongThucDon(int id,int soluong)
        {
            string sql = "UPDATE thucdon SET soluong = soluong + @soluong where id = @id";
            SqlConnection conn = DBConnection.Instance.getConnection();
            try
            {
                cmd = new SqlCommand(sql, conn);
                conn.Open();
                cmd.Parameters.Add("@soluong", SqlDbType.Int).Value = soluong;

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

        public bool deleteThucDon(int id_thucdon)
        {
            string sql = "DELETE FROM thucdon WHERE id = @id_thucdon";
            SqlConnection conn = DBConnection.Instance.getConnection();
            try
            {
                cmd = new SqlCommand(sql, conn);
                conn.Open();

                cmd.Parameters.Add("@id_thucdon", SqlDbType.Int).Value = id_thucdon;
                

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
