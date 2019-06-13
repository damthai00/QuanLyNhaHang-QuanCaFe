using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.Controller
{
    class DBConnection 
    {
        private static DBConnection instance;
        public static DBConnection Instance
        {
            get { if (instance == null) instance = new DBConnection(); return DBConnection.instance; }
            private set { DBConnection.instance = value; }
        }

        private String conStr;
        private DBConnection()
        {
            conStr = @"Data Source=.\SQL_EXPRESS;Initial Catalog=QLNhaHang;Integrated Security=True";
            SqlConnection conn = new SqlConnection(conStr);
        }


        public SqlConnection getConnection()
        {
            SqlConnection conn = new SqlConnection(conStr);

            return new SqlConnection(conStr);

        }
    }
}
