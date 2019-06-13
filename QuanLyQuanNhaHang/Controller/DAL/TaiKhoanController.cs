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
    class TaiKhoanController
    {
        private static TaiKhoanController instance;

        public static TaiKhoanController Instance
        {
            get { if (instance == null) instance = new TaiKhoanController(); return TaiKhoanController.instance; }
            set { TaiKhoanController.instance = value; }
        }


        SqlDataAdapter da;
        SqlCommand cmd;
        private TaiKhoanController()
        {   
        }

        //Lấy tất cả tài khoản trong csdl
        public DataTable getAllTaiKhoan()
        {
            DataTable dt = new DataTable();

            String sql = "SELECT * FROM taikhoan";
            SqlConnection conn = DBConnection.Instance.getConnection();
            da = new SqlDataAdapter(sql, conn);

            conn.Open();
            da.Fill(dt);
            conn.Close();

            return dt;
        }

        public DataTable DangKy(String username)
        {
            DataTable dt = new DataTable();

            String sql = "SELECT * FROM taikhoan WHERE username = "+username;
            SqlConnection conn = DBConnection.Instance.getConnection();
            da = new SqlDataAdapter(sql, conn);

            conn.Open();
            da.Fill(dt);
            conn.Close();

            return dt;
        }

        //Lấy tài khoản theo username
        public DataTable getTaiKhoan(String username,String password)
        {
            DataTable dt = new DataTable();

            String sql = "SELECT * FROM taikhoan WHERE username = '" +username+"' AND passwords = '"+password+"'" ;
            SqlConnection conn = DBConnection.Instance.getConnection();
            da = new SqlDataAdapter(sql, conn);

            conn.Open();
            da.Fill(dt);
            conn.Close();

            return dt;
        }

        public bool addTaiKhoan(TaiKhoan tk)
        {
            String Sql = "INSERT INTO taikhoan(username,passwords,fullname,loai) VALUES(@username,@password,@fullname,@loai)";
            SqlConnection conn = DBConnection.Instance.getConnection();
            
            try { 
                cmd = new SqlCommand(Sql, conn);
                conn.Open();
                cmd.Parameters.Add("@username", SqlDbType.NVarChar).Value = tk.getUsername();
                cmd.Parameters.Add("@password", SqlDbType.NVarChar).Value = tk.getPasswords();
                cmd.Parameters.Add("@fullname", SqlDbType.NVarChar).Value = tk.getFullname();
                cmd.Parameters.Add("@loai", SqlDbType.NVarChar).Value = tk.getLoai();
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
