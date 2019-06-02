using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.Model
{
    class TaiKhoan
    {
        private int id;
        private String username;
        private String passwords; 
        private String fullname;
        private int loai;


        public TaiKhoan(DataRow row)
        {
            this.id = (int)row["id"];
            this.username = row["username"].ToString();
            this.passwords = row["passwords"].ToString();
            this.id = (int)row["loai"];
        }

        public TaiKhoan()
        {
        }
        public TaiKhoan(int id,String username,String passwords,String fullname,int loai)
        {
            this.id = id;
            this.username = username;
            this.passwords = passwords;
            this.fullname = fullname;
            this.loai = loai;
        }

        public TaiKhoan(String username, String passwords, String fullname, int loai)
        {
            this.username = username;
            this.passwords = passwords;
            this.fullname = fullname;
            this.loai = loai;
        }

        public int getId()
        {
            return this.id;
        }
        public String getUsername()
        {
            return this.username;
        }
        public String getPasswords()
        {
            return this.passwords;
        }
        public String getFullname()
        {
            return this.fullname;
        }
        public int getLoai()
        {
            return this.loai;
        }

        //hàm set
        public void setId(int id)
        {
            this.id = id;
        }

        public void setUsername(String x)
        {
            this.username = x;
        }
        public void setPasswords(String x)
        {
            this.passwords = x;
        }
        public void setFullname(String x)
        {
            this.fullname = x;
        }
        public void setLoai(int loai)
        {
            this.loai = loai;
        }

    }
}
