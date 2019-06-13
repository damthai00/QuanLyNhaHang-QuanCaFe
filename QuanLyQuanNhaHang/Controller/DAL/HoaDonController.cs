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
    class HoaDonController
    {
        private static HoaDonController instance;

        internal static HoaDonController Instance
        {
            get { if (instance == null) instance = new HoaDonController(); return instance; }
           private set { instance = value; }
        }

        private HoaDonController() { }

        private SqlDataAdapter da;
        private SqlCommand cmd;
        public DataTable getAllHoaDon()
        {
            DataTable dt = new DataTable();

            String sql = "SELECT * FROM hoadon";
            SqlConnection conn = DBConnection.Instance.getConnection();

            da = new SqlDataAdapter(sql, conn);

            conn.Open();
            da.Fill(dt);
            conn.Close();

            return dt;
        }

        public DataTable getHDByID(int id_hoadon)
        {
            DataTable dt = new DataTable();

            String sql = "SELECT * FROM hoadon where id= "+id_hoadon;
            SqlConnection conn = DBConnection.Instance.getConnection();

            da = new SqlDataAdapter(sql, conn);

            conn.Open();
            da.Fill(dt);
            conn.Close();

            return dt;
        }

        public DataTable getHDTinhTien(int id_hoadon)
        {
            DataTable dt = new DataTable();

            String sql = "select hoadon.id,hoadon.ngayhd,hoadon.id_ban,ban.ten from hoadon,ban where hoadon.id_ban = ban.id and hoadon.id = "+id_hoadon;
            SqlConnection conn = DBConnection.Instance.getConnection();

            da = new SqlDataAdapter(sql, conn);

            conn.Open();
            da.Fill(dt);
            conn.Close();

            return dt;
        
        }

        public DataTable getAllHoaDonHienThi()
        {
            DataTable dt = new DataTable();

            String sql = "select hoadon.id,hoadon.ngayhd,hoadon.sotien,hoadon.trangthai,concat(khachhang.fname,khachhang.lname) as hoten,ban.ten as ten_ban " +
                "FROM hoadon " +
                "left join ban on ban.id = hoadon.id_ban " +
                "left join khachhang on khachhang.id = hoadon.id_khachhang " +
                "order by hoadon.id";
            SqlConnection conn = DBConnection.Instance.getConnection();

            da = new SqlDataAdapter(sql, conn);

            conn.Open();
            da.Fill(dt);
            conn.Close();

            return dt;
        }


        public int getIdHoaDonUnCheck_TheoIdBan(int id_ban)
        {
            int id_hoadon =-1;
            DataTable dt = new DataTable();

            String sql = "SELECT * FROM hoadon WHERE id_ban = '" +id_ban+"' and trangthai = 1"; // trạng thái = 1 =>chưa thanh toán
            SqlConnection conn = DBConnection.Instance.getConnection();

            da = new SqlDataAdapter(sql, conn);

            conn.Open();
            da.Fill(dt);
            conn.Close();
            if (dt.Rows.Count > 0) {
                DataRow x = dt.Rows[0];
                id_hoadon = (int)x["id"];
            }
              
            return id_hoadon;
        }

        public int getMaxIDHoaDon()
        {
            int id = -1;
            String idString = "";
            DataTable dt = new DataTable();

            String sql = "SELECT MAX(id) as id FROM hoadon "; //lấy id hóa đơn cuối cùng
            SqlConnection conn = DBConnection.Instance.getConnection();

            da = new SqlDataAdapter(sql, conn);

            conn.Open();
            da.Fill(dt);
            conn.Close();
            if (dt.Rows.Count >0)
            {
                if (dt.Rows[0]["id"].ToString() != "")
                    id = (int)dt.Rows[0]["id"];
                else
                    id = 0 ;
                    
            }

            return id;
        }

     

        public bool updateSoTienHoaDon(HoaDon hd)
        {
            String sql = "update hoadon set sotien = sotien + @sotien  where id = @id";
            SqlConnection conn = DBConnection.Instance.getConnection();
            try
            {
                cmd = new SqlCommand(sql, conn);
                conn.Open();
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = hd.Id;
                cmd.Parameters.Add("@sotien", SqlDbType.Float).Value = hd.Sotie;
               
                cmd.ExecuteNonQuery();
                conn.Close();

            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        public bool updateSoTienHoaDonTru(float sotien,int id)
        {
            String sql = "update hoadon set sotien = sotien - @sotien  where id = @id";
            SqlConnection conn = DBConnection.Instance.getConnection();
            try
            {
                cmd = new SqlCommand(sql, conn);
                conn.Open();
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                cmd.Parameters.Add("@sotien", SqlDbType.Float).Value = sotien;

                cmd.ExecuteNonQuery();
                conn.Close();

            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        public bool updateTinhTienHoaDon(HoaDon hd)
        {
            String sql ;
            SqlConnection conn = DBConnection.Instance.getConnection();
            if(hd.Id_khachhang != -1)
            {
                sql = "update hoadon set id_khachhang = @id_khachhang, trangthai = @trangthai, ngayhd = @ngayhd,sotien = @sotien  where id = @id";
                try
                {
                    cmd = new SqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = hd.Id;
                    cmd.Parameters.Add("@trangthai", SqlDbType.Int).Value = hd.Trangthai;
                    cmd.Parameters.Add("@ngayhd", SqlDbType.Date).Value = hd.Ngayhd;
                    cmd.Parameters.Add("@id_khachhang", SqlDbType.Int).Value = hd.Id_khachhang;
                    cmd.Parameters.Add("@sotien", SqlDbType.Float).Value = hd.Sotie;
                    cmd.ExecuteNonQuery();
                    conn.Close();

                }
                catch (Exception e)
                {
                    return false;
                }
            }

            else
            {
                sql = "update hoadon set trangthai = @trangthai, ngayhd = @ngayhd,sotien = @sotien  where id = @id";
                try
                {
                    cmd = new SqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = hd.Id;
                    cmd.Parameters.Add("@trangthai", SqlDbType.Int).Value = hd.Trangthai;
                    cmd.Parameters.Add("@ngayhd", SqlDbType.Date).Value = hd.Ngayhd;
                    cmd.Parameters.Add("@sotien", SqlDbType.Float).Value = hd.Sotie;
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


        public bool addHoaDon(HoaDon hd)
        {
            String sql = "insert into hoadon(id_ban,ngayhd,sotien,trangthai) values (@id_ban,@ngayhd,@sotien,@trangthai)";
            SqlConnection conn = DBConnection.Instance.getConnection();
            try
            {
                cmd = new SqlCommand(sql, conn);
                conn.Open();
                cmd.Parameters.Add("@id_ban", SqlDbType.Int).Value = hd.Id_ban;
                //cmd.Parameters.Add("@id_khachhang", SqlDbType.Int).Value = hd.Id_khachhang;
                cmd.Parameters.Add("@ngayhd", SqlDbType.Date).Value =hd.Ngayhd;
                cmd.Parameters.Add("@sotien", SqlDbType.Float).Value = hd.Sotie;
                cmd.Parameters.Add("@trangthai", SqlDbType.Int).Value = hd.Trangthai;
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
