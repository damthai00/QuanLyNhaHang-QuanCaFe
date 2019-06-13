using QuanLyQuanCafe.View;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.Controller.DAL
{
    class KhachHangController
    {
        private static KhachHangController instance;

        internal static KhachHangController Instance
        {
            get { if (instance == null)instance = new KhachHangController(); return KhachHangController.instance; }
           private set { KhachHangController.instance = value; }
        }

        public KhachHangController() { }


        SqlDataAdapter da;
        SqlCommand cmd;
        public DataTable getAllKhachHang()
        {
            DataTable dt = new DataTable();
            String Sql = "SELECT * FROM khachhang";
            SqlConnection conn = DBConnection.Instance.getConnection();
            da = new SqlDataAdapter(Sql,conn);
            try
            {
                conn.Open();
                da.Fill(dt);
                conn.Close();
            }catch(Exception e){
                return null;
            }
            return dt;
        }

        public DataTable getKhachHangByID(int id)
        {
            DataTable dt = new DataTable();
            String Sql = "SELECT * FROM khachhang where id = "+id;
            SqlConnection conn = DBConnection.Instance.getConnection();
            da = new SqlDataAdapter(Sql, conn);
            try
            {
                conn.Open();
                da.Fill(dt);
                conn.Close();
            }
            catch (Exception e)
            {
                return null;
            }
            return dt;
        }

        public bool insertKhachHang(KhachHang kh)
        {
           
            String Sql = "INSERT INTO khachhang(fname,lname,ngsinh,gioitinh,phone,email,adress,point,solan)  VALUES(@fname,@lname,@ngsinh,@gioitinh,@phone,@email,@adress,@point,@solan)";
            SqlConnection conn = DBConnection.Instance.getConnection();
            cmd = new SqlCommand(Sql, conn);
            try
            {
                conn.Open();

                cmd.Parameters.Add("@fname", SqlDbType.NVarChar).Value = kh.Fname;
                cmd.Parameters.Add("@lname", SqlDbType.NVarChar).Value = kh.Lname;
                cmd.Parameters.Add("@ngsinh", SqlDbType.Date).Value = kh.Ngsinh;
                cmd.Parameters.Add("@gioitinh", SqlDbType.Int).Value = kh.Gioitinh;
                cmd.Parameters.Add("@phone", SqlDbType.NVarChar).Value = kh.Phone;
                cmd.Parameters.Add("@email", SqlDbType.NVarChar).Value = kh.Email;
                cmd.Parameters.Add("@adress", SqlDbType.NVarChar).Value = kh.Adress;
                cmd.Parameters.Add("@point", SqlDbType.Int).Value = kh.Point;
                cmd.Parameters.Add("@solan", SqlDbType.Int).Value = kh.Solan;

                cmd.ExecuteNonQuery();
                conn.Close();

            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public bool updateKhachHang(KhachHang kh)
        {

            String Sql = "UPDATE khachhang SET fname = @fname,lname = @lname,ngsinh = @ngsinh, gioitinh = @gioitinh, phone = @phone, email = @email, adress = @adress, point = @point, solan = @solan WHERE id = @id";
            SqlConnection conn = DBConnection.Instance.getConnection();
            cmd = new SqlCommand(Sql, conn);
            try
            {
                conn.Open();

                cmd.Parameters.Add("@id", SqlDbType.Int).Value = kh.Id;
                cmd.Parameters.Add("@fname", SqlDbType.NVarChar).Value = kh.Fname;
                cmd.Parameters.Add("@lname", SqlDbType.NVarChar).Value = kh.Lname;
                cmd.Parameters.Add("@ngsinh", SqlDbType.Date).Value = kh.Ngsinh;
                cmd.Parameters.Add("@gioitinh", SqlDbType.Int).Value = kh.Gioitinh;
                cmd.Parameters.Add("@phone", SqlDbType.NVarChar).Value = kh.Phone;
                cmd.Parameters.Add("@email", SqlDbType.NVarChar).Value = kh.Email;
                cmd.Parameters.Add("@adress", SqlDbType.NVarChar).Value = kh.Adress;
                cmd.Parameters.Add("@point", SqlDbType.Int).Value = kh.Point;
                cmd.Parameters.Add("@solan", SqlDbType.Int).Value = kh.Solan;

                cmd.ExecuteNonQuery();
                conn.Close();

            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public bool deleteKhachHang(KhachHang kh)
        {

            String Sql = "DELETE FROM khachhang WHERE id = @id";
            SqlConnection conn = DBConnection.Instance.getConnection();
            cmd = new SqlCommand(Sql, conn);
            try
            {
                conn.Open();

                cmd.Parameters.Add("@id", SqlDbType.Int).Value = kh.Id;
                

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
