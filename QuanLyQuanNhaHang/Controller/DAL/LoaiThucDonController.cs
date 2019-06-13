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
    class LoaiThucDonController
    {
        private static LoaiThucDonController instance;

        internal static LoaiThucDonController Instance
        {
            get { if (instance == null) instance = new LoaiThucDonController(); return LoaiThucDonController.instance; }
           private set { LoaiThucDonController.instance = value; }
        }

        private LoaiThucDonController() { }
        SqlDataAdapter da;
        SqlCommand cmd;
        public DataTable getAllLoaiThucDon()
        {
            DataTable dt = new DataTable();

            String sql = "SELECT * FROM loaithucdon";
            SqlConnection conn = DBConnection.Instance.getConnection();

            da = new SqlDataAdapter(sql, conn);

            conn.Open();
            da.Fill(dt);
            conn.Close();

            return dt;
        }

        public bool insertLoaiThucDon(LoaiThucDon ltd)
        {
            string sql = "INSERT INTO loaithucdon(ten) Values(@ten)";
            SqlConnection conn = DBConnection.Instance.getConnection();
            try
            {
                cmd = new SqlCommand(sql, conn);
                conn.Open();

                cmd.Parameters.Add("@ten", SqlDbType.NVarChar).Value = ltd.Ten;
               

                cmd.ExecuteNonQuery();
                conn.Close();

            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public bool updatetLoaiThucDon(LoaiThucDon ltd)
        {
            string sql = "UPDATE loaithucdon SET ten = @ten where id = @id";
            SqlConnection conn = DBConnection.Instance.getConnection();
            try
            {
                cmd = new SqlCommand(sql, conn);
                conn.Open();

                cmd.Parameters.Add("@ten", SqlDbType.NVarChar).Value = ltd.Ten;
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = ltd.Id;


                cmd.ExecuteNonQuery();
                conn.Close();

            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public bool deleteLoaiThucDon(int id)
        {
            string sql = "DELETE from loaithucdon where id = @id";
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
