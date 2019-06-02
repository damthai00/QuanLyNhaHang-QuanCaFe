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
    }
}
