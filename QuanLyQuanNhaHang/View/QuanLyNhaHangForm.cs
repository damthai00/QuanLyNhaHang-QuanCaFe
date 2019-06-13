using QuanLyQuanCafe.Controller;
using QuanLyQuanCafe.Controller.BLL;
using QuanLyQuanCafe.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanCafe
{
    public partial class QuanLyNhaHangForm : Form
    {
        ManangerForm mainForm;
        public QuanLyNhaHangForm(ManangerForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            loadBan();
            loadThucDon();
            loadLoaiThucDon();
            
        }

        public void loadBan()
        {
            List<BanHienThi> lits = new List<BanHienThi>();
            DataTable tb = BanController.Instance.getAllBan();

            foreach(DataRow item in tb.Rows)
            {
                BanHienThi ban = new BanHienThi(item);
                lits.Add(ban);
                
            }
            //this.dtgBan.AutoGenerateColumns = false;
            this.dtgBan.DataSource = lits;
            this.DongNhap_Ban();
            this.setButton_BanDau_Ban();
        }

        //Ngọc Ánh thúi
   
        public void loadThucDon()
        {
          List<ThucDonHienThi> list = XuLyThucDonController.Instance.XuLyThucDon();
          
            dtgThucDon.DataSource = list;
            loadCBBLoaiThucDon();
            bnt_xnThucDon.Enabled = false;
            bnt_huyThucDon.Enabled = false;
            bnt_suaThucDon.Enabled = false;
            bnt_xoaThucDon.Enabled = false;
        }

        public void loadLoaiThucDon()
        {
            DataTable dt = LoaiThucDonController.Instance.getAllLoaiThucDon();
            dtgLoaiThucDon.DataSource = dt;
        }

        private void dtgThucDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            int dong = e.RowIndex;
            if(dong >=0)
            {
                txt_idThucDon_ThucDon.Text = dtgThucDon.Rows[dong].Cells["thucdon_id"].Value.ToString();
                txt_tenThucDon_ThucDon.Text = dtgThucDon.Rows[dong].Cells["thucdon_ten"].Value.ToString();

                txt_soluong_ThucDon.Text = dtgThucDon.Rows[dong].Cells["thucdon_soluong"].Value.ToString();
                txt_DonGia_ThucDon.Text = dtgThucDon.Rows[dong].Cells["thucdon_dongia"].Value.ToString();
                cbbTrangThai_ThucDon.Text = dtgThucDon.Rows[dong].Cells["thucdon_trangthai"].Value.ToString();
                cbbLoaiTD_ThucDon.SelectedValue = dtgThucDon.Rows[dong].Cells["Id_loai"].Value.ToString();
                cbbLoaiTD_ThucDon.Text = dtgThucDon.Rows[dong].Cells["thucdon_loai"].Value.ToString();

                this.DongNhap_ThucDon();
                bnt_themThucDon.Enabled = true;
                bnt_suaThucDon.Enabled = true;
                bnt_xoaThucDon.Enabled = true;
                bnt_xnThucDon.Enabled = false;
                bnt_huyThucDon.Enabled = false;
            }
            
            
        }

        public void newData_ThucDon()
        {
            txt_idThucDon_ThucDon.Text = "";
            txt_tenThucDon_ThucDon.Text = "";
            loadCBBLoaiThucDon();
            cbbLoaiTD_ThucDon.SelectedIndex = -1;
            txt_soluong_ThucDon.Text = "0";
            txt_DonGia_ThucDon.Text = "";
            cbbTrangThai_ThucDon.SelectedIndex = 0;
        }
        private void bnt_themThucDon_Click(object sender, EventArgs e)
        {
            this.ChoPhepNhap_ThucDon();
            newData_ThucDon();
            txt_idThucDon_ThucDon.Text = "(New *)";
            bnt_suaThucDon.Enabled = false;
            bnt_xoaThucDon.Enabled = false;
            bnt_xnThucDon.Enabled = true;
            bnt_huyThucDon.Enabled = true;         
        }

        private void checkbox_soluong_ThucDon_CheckedChanged(object sender, EventArgs e)
        {
            txt_soluong_ThucDon.Enabled = true;
        }


        public void loadCBBLoaiThucDon()
        {
            List<LoaiThucDon> list = XuLyLoaiThucDonController.Instance.getAllLoaiThucDon();
            cbbLoaiTD_ThucDon.DataSource = list;
            cbbLoaiTD_ThucDon.DisplayMember = "ten";
            cbbLoaiTD_ThucDon.ValueMember = "id";
        }

        private void bnt_xnThucDon_Click(object sender, EventArgs e)
        {
            if (bnt_themThucDon.Enabled == true && bnt_xoaThucDon.Enabled == false && bnt_suaThucDon.Enabled == false)
                this.ThemThucDon();
            else
                if (bnt_themThucDon.Enabled == false && bnt_xoaThucDon.Enabled == false && bnt_suaThucDon.Enabled == true)
                    this.SuaThucDon();
            this.SetButton_BanDau_ThucDon();
            this.DongNhap_ThucDon();
        }

        public bool KTNhapThucDon()
        {
            if (txt_tenThucDon_ThucDon.Text == "")
                return false;
            if (cbbLoaiTD_ThucDon.SelectedIndex < 0)
                return false;
            if (cbbTrangThai_ThucDon.SelectedIndex < 0)
                return false;
            return true;
        }

        public void ChoPhepNhap_ThucDon()
        {
            txt_tenThucDon_ThucDon.Enabled = true;
            cbbLoaiTD_ThucDon.Enabled = true;
            cbbTrangThai_ThucDon.Enabled = true;
            // txtLoaiThucDon_TD.Enabled = true;
            txt_DonGia_ThucDon.Enabled = true;
            checkbox_soluong_ThucDon.Enabled = true; ;
          
        }
        public void DongNhap_ThucDon()
        {
            txt_tenThucDon_ThucDon.Enabled = false;
            cbbLoaiTD_ThucDon.Enabled = false;
            cbbTrangThai_ThucDon.Enabled = false;
            // txtLoaiThucDon_TD.Enabled = true;
            txt_DonGia_ThucDon.Enabled = false;
            checkbox_soluong_ThucDon.Enabled = false;
            txt_soluong_ThucDon.Enabled = false;
        }

        public int setTrangthaiThucDon()
        {
            if (cbbTrangThai_ThucDon.SelectedIndex == 0)
                return 1;
            if (cbbTrangThai_ThucDon.SelectedIndex == 1)
                return 0;
            if (cbbTrangThai_ThucDon.SelectedIndex == 2)
                return 2;
            if (cbbTrangThai_ThucDon.SelectedIndex == 3)
                return -1;
            return 0;
        }

        private void bnt_huyThucDon_Click(object sender, EventArgs e)
        {
            DongNhap_ThucDon();
            bnt_huyThucDon.Enabled = false;
            bnt_suaThucDon.Enabled = false;
            bnt_xnThucDon.Enabled = false;
            bnt_themThucDon.Enabled = true;
        }

        private void bnt_suaThucDon_Click(object sender, EventArgs e)
        {
            this.ChoPhepNhap_ThucDon();
            bnt_themThucDon.Enabled = false;
            bnt_xoaThucDon.Enabled = false;
            bnt_xnThucDon.Enabled = true;
            bnt_huyThucDon.Enabled = true;
            
        }
        public void ThemThucDon(){
            if (this.KTNhapThucDon() == false)
                MessageBox.Show("Lỗi nhập dữ liệu!", "Kiểm tra lại!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                ThucDon thucdon = new ThucDon();
                thucdon.Ten = txt_tenThucDon_ThucDon.Text;
                thucdon.Id_loaithucdon = int.Parse(cbbLoaiTD_ThucDon.SelectedValue.ToString());
                thucdon.Soluong = int.Parse(txt_soluong_ThucDon.Text);
                if (txt_DonGia_ThucDon.Text == "")
                    thucdon.Dongia = 0;
                else
                    thucdon.Dongia = int.Parse(txt_DonGia_ThucDon.Text);
                thucdon.Trangthai = setTrangthaiThucDon();
                if (int.Parse(txt_soluong_ThucDon.Text) > 0)
                    thucdon.Trangthai = 1;

                if (XuLyThucDonController.Instance.insertThucDon(thucdon))
                {
                    MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadThucDon();
                    SetButton_BanDau_ThucDon();
                    this.mainForm.loadDSThucDon();
                }

                else
                    MessageBox.Show("Có lỗi sảy ra! Kiểm tra lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        public void SetButton_BanDau_ThucDon()
        {
            bnt_themThucDon.Enabled = true;
            bnt_suaThucDon.Enabled = true;
            bnt_xoaThucDon.Enabled = true;
            bnt_xnThucDon.Enabled = false;
            bnt_huyThucDon.Enabled = false;
        }
        public void SuaThucDon()
        {
            if(KTNhapThucDon() == false)
                MessageBox.Show("Lỗi nhập dữ liệu!,Kiểm tra lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                ThucDon thucdon = new ThucDon();
                thucdon.Id =int.Parse( txt_idThucDon_ThucDon.Text);
                thucdon.Ten = txt_tenThucDon_ThucDon.Text;
                thucdon.Id_loaithucdon = int.Parse(cbbLoaiTD_ThucDon.SelectedValue.ToString());
                thucdon.Soluong = int.Parse(txt_soluong_ThucDon.Text);
                thucdon.Dongia = int.Parse(txt_DonGia_ThucDon.Text);
                thucdon.Trangthai = setTrangthaiThucDon();
                if(XuLyThucDonController.Instance.updateThucDon(thucdon) == false)
                    MessageBox.Show("Có lỗi sảy ra! Kiểm tra lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.checkbox_soluong_ThucDon.Checked = false;
                    this.txt_soluong_ThucDon.Enabled = false;
                    loadThucDon();
                    SetButton_BanDau_ThucDon();
                    this.mainForm.loadDSThucDon();
                }
            }
        }

        public void XoaThucDon()
        {
            if(MessageBox.Show("Bạn có chắc muốn xóa Thực đơn này!" + txt_idThucDon_ThucDon.Text, "Cảnh báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)  
            {
                ThucDon thucdon = new ThucDon();
                thucdon.Id = int.Parse(txt_idThucDon_ThucDon.Text);
                thucdon.Ten = txt_tenThucDon_ThucDon.Text;
                thucdon.Id_loaithucdon = int.Parse(cbbLoaiTD_ThucDon.SelectedValue.ToString());
                thucdon.Soluong = int.Parse(txt_soluong_ThucDon.Text);
                thucdon.Dongia = int.Parse(txt_DonGia_ThucDon.Text);
                thucdon.Trangthai = -1;
                if (XuLyThucDonController.Instance.updateThucDon(thucdon) == false)
                    MessageBox.Show("Có lỗi sảy ra! Kiểm tra lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadThucDon();
                    SetButton_BanDau_ThucDon();
                }
            }
        }

        private void bnt_xoaThucDon_Click(object sender, EventArgs e)
        {
            if (txt_idThucDon_ThucDon.Text == "")
                MessageBox.Show("Chọn thực đơn cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                int id_thucdon =Convert.ToInt32( txt_idThucDon_ThucDon.Text);
                if(XuLyThucDonController.Instance.KiemTraThucDonDangSuDung(id_thucdon))
                    MessageBox.Show("Thực đơn có người sử dụng, Không thể xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    if(XuLyThucDonController.Instance.deleteThucDon(id_thucdon))
                    {
                        MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.loadThucDon();
                        this.mainForm.loadDSThucDon();
                    }
                    else
                        MessageBox.Show("Có lỗi sảy ra! Kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            
        }

        ////////////////////////////////////////////////////////////////////////////////////
         
        public void ChoPhepNhap_Ban()
        {
            
            txt_tenban_ban.Enabled = true;
            cbb_TrangThai_Ban.Enabled = true;
        }
        public void setButton_BanDau_Ban()
        {
            bnt_Huy_Ban.Enabled = false;
            bnt_XacNhan_Ban.Enabled = false;
            bnt_Them_Ban.Enabled = true;
            bnt_Sua_ban.Enabled = false;
            bnt_Xoa_Ban.Enabled = false;
        }

        public void DongNhap_Ban()
        {
            txt_maban_Ban.Enabled = false;
            txt_tenban_ban.Enabled = false;
            cbb_TrangThai_Ban.Enabled = false;
        }

        private void dtgBan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.DongNhap_Ban();
            int dong = e.RowIndex;
            if(dong >-1)
            {
                txt_maban_Ban.Text = dtgBan.Rows[dong].Cells["id"].Value.ToString();
                this.txt_tenban_ban.Text = dtgBan.Rows[dong].Cells["ten"].Value.ToString();
                String trangthai = dtgBan.Rows[dong].Cells["trangthai"].Value.ToString();
                cbb_TrangThai_Ban.Text = dtgBan.Rows[dong].Cells["trangthai"].Value.ToString();
                bnt_Sua_ban.Enabled = true;
                bnt_Xoa_Ban.Enabled = true;
                bnt_Them_Ban.Enabled = true;
            }
        }

        private void bnt_Them_Ban_Click(object sender, EventArgs e)
        {
            this.ChoPhepNhap_Ban();
            txt_maban_Ban.Text = "";
            txt_tenban_ban.Text = "";
            cbb_TrangThai_Ban.SelectedIndex = 0;
            bnt_Sua_ban.Enabled = false;
            bnt_Xoa_Ban.Enabled = false;
            bnt_XacNhan_Ban.Enabled = true;
            bnt_Huy_Ban.Enabled = true;
        }

        public bool KTNhap_Ban()
        {
            
            if (txt_tenban_ban.Text == "")
                return false;
            if (cbb_TrangThai_Ban.SelectedIndex < 0)
                return false;
            return true;
        }

        public void ThemBanMoi()
        {
            if(KTNhap_Ban()==false)
                MessageBox.Show("Kiểm tra thông tin nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else {
                Ban ban = new Ban();
                
                ban.Name = txt_tenban_ban.Text;
                if (cbb_TrangThai_Ban.SelectedIndex == 0)
                    ban.Trangthai = 0;
                if (cbb_TrangThai_Ban.SelectedIndex == 1)
                    ban.Trangthai = 0;
                if (cbb_TrangThai_Ban.SelectedIndex == 2)
                    ban.Trangthai = 2;
                if (cbb_TrangThai_Ban.SelectedIndex == 3)
                    ban.Trangthai = -1;

                if (XuLyBanController.Instance.insertBan(ban) == false)
                    MessageBox.Show("Có lỗi sảy ra! Kiểm tra lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadBan();
                    setButton_BanDau_Ban();
                    this.mainForm.loadBan();
                    this.mainForm.loadCBBBan();
                }
            }
        }

        private void bnt_XacNhan_Ban_Click(object sender, EventArgs e)
        {
            if (bnt_Them_Ban.Enabled == true && bnt_Sua_ban.Enabled == false && bnt_Xoa_Ban.Enabled == false)
                this.ThemBanMoi();

            if (bnt_Them_Ban.Enabled == false && bnt_Sua_ban.Enabled == true && bnt_Xoa_Ban.Enabled == false)
                this.SuaBan();
        }

        private void bnt_Sua_ban_Click(object sender, EventArgs e)
        {
            bnt_Them_Ban.Enabled = false;
            bnt_Xoa_Ban.Enabled = false;
            bnt_XacNhan_Ban.Enabled = true;
            bnt_Huy_Ban.Enabled = true;
            this.ChoPhepNhap_Ban();
        }

        public void SuaBan()
        {
               if (KTNhap_Ban() == false)
                   MessageBox.Show("Kiểm tra thông tin nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
               else
               {
                   Ban ban = new Ban();
                   ban.Id = int.Parse(txt_maban_Ban.Text);
                   ban.Name = txt_tenban_ban.Text;
                   if (cbb_TrangThai_Ban.SelectedIndex == 0)
                       ban.Trangthai = 0;
                   if (cbb_TrangThai_Ban.SelectedIndex == 1)
                       ban.Trangthai = 1;
                   if (cbb_TrangThai_Ban.SelectedIndex == 2)
                       ban.Trangthai = 2;
                   if (cbb_TrangThai_Ban.SelectedIndex == 3)
                       ban.Trangthai = -1;

                   if (XuLyBanController.Instance.updateBan(ban) == false)
                       MessageBox.Show("Có lỗi sảy ra! Kiểm tra lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   else
                   {
                       MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                       loadBan();
                       setButton_BanDau_Ban();
                       this.mainForm.loadBan();
                       this.mainForm.loadCBBBan();
                   }
               }
        }

        private void bnt_Huy_Ban_Click(object sender, EventArgs e)
        {
            this.DongNhap_Ban();
            this.setButton_BanDau_Ban();
            bnt_XacNhan_Ban.Enabled = false;
            bnt_Sua_ban.Enabled = false;
            bnt_Xoa_Ban.Enabled = false;
            bnt_Them_Ban.Enabled = true;
            bnt_XacNhan_Ban.Enabled = false;
        }

        private void dgtLoaiThucDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           

            int dong = e.RowIndex;
            if (dong > -1)
            {
                txt_Ma_LTD.Text = dtgLoaiThucDon.Rows[dong].Cells["maloai"].Value.ToString();
                txt_TenLTD.Text = dtgLoaiThucDon.Rows[dong].Cells["tenloai"].Value.ToString();
               
                bnt_Sua_LTD.Enabled = true;
                bnt_Xoa_LTD.Enabled = true;
                bnt_Them_LTD.Enabled = true;
                txt_TenLTD.Enabled = false;
            }
        }


        private void bnt_Them_LTD_Click(object sender, EventArgs e)
        {
            bnt_Sua_LTD.Enabled = false;
            bnt_Xoa_LTD.Enabled = false;
            bnt_XacNhan_LTD.Enabled = true;
            bnt_Huy_LTD.Enabled = true;
            txt_TenLTD.Enabled = true;
            txt_Ma_LTD.Text = "New*";
            txt_TenLTD.Text = "";
        }

        public void ThemLoaiThucDon()
        {
            if(txt_TenLTD.Text == "")
                MessageBox.Show("Kiểm tra thông tin nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                LoaiThucDon ltd = new LoaiThucDon();
                ltd.Ten = txt_TenLTD.Text;
                MessageBox.Show(ltd.Ten, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
                if (XuLyLoaiThucDonController.Instance.insertLoaiThucDon(ltd) == false)
                    MessageBox.Show("Có lỗi sảy ra! Kiểm tra lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadLoaiThucDon();
                    loadCBBLoaiThucDon();
                    bnt_Them_LTD.Enabled = true;
                    bnt_Sua_LTD.Enabled = false;
                    bnt_Xoa_LTD.Enabled = false;
                    bnt_XacNhan_LTD.Enabled = false;
                    bnt_Huy_LTD.Enabled = false;
                    txt_TenLTD.Enabled = false;
                
                }
            }
        }

        public void SuaLoaiThucDon()
        {
            if (txt_TenLTD.Text == "")
                MessageBox.Show("Kiểm tra thông tin nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                LoaiThucDon ltd = new LoaiThucDon();
                ltd.Id = int.Parse(txt_Ma_LTD.Text);
                ltd.Ten = txt_TenLTD.Text;

                if (XuLyLoaiThucDonController.Instance.updateLoaiThucDon(ltd) == false)
                    MessageBox.Show("Có lỗi sảy ra! Kiểm tra lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadLoaiThucDon();
                    loadCBBLoaiThucDon();
                    bnt_Them_LTD.Enabled = true;
                    bnt_Sua_LTD.Enabled = false;
                    bnt_Xoa_LTD.Enabled = false;
                    bnt_XacNhan_LTD.Enabled = false;
                    bnt_Huy_LTD.Enabled = false;
                    txt_TenLTD.Enabled = false;

                }
            }
        }

        private void bnt_XacNhan_LTD_Click(object sender, EventArgs e)
        {
            if (bnt_Them_LTD.Enabled == true && bnt_Sua_LTD.Enabled == false && bnt_Xoa_LTD.Enabled == false)
                this.ThemLoaiThucDon();
            else
                if (bnt_Them_LTD.Enabled == false && bnt_Sua_LTD.Enabled == true && bnt_Xoa_LTD.Enabled == false)
                    this.SuaLoaiThucDon();
        }

        private void bnt_Sua_LTD_Click(object sender, EventArgs e)
        {
            bnt_Them_LTD.Enabled = false;
            bnt_Xoa_LTD.Enabled = false;
            bnt_XacNhan_LTD.Enabled = true;
            bnt_Huy_LTD.Enabled = true;
            txt_TenLTD.Enabled = true;
        }

        private void bnt_Xoa_Ban_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txt_maban_Ban.Text);
            if(cbb_TrangThai_Ban.Text == "Có khách")
                MessageBox.Show("Bàn đang có người sử dụng, không thể xóa!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else 
            {
                if (XuLyBanController.Instance.deleteBan(id))
                {
                    MessageBox.Show("Xóa bàn thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadBan();
                    this.mainForm.loadBan();
                    this.mainForm.loadCBBBan();
                }

                else
                    MessageBox.Show("Không thể xóa bàn!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           
            
        }

        private void bnt_Xoa_LTD_Click(object sender, EventArgs e)
        {
            if(txt_Ma_LTD.Text == "")
                 MessageBox.Show("Chọn Loại thực đơn cần xóa?","Thông báo!",MessageBoxButtons.OK,MessageBoxIcon.Information);
            else  
                if(XuLyLoaiThucDonController.Instance.deleteLoaiThucDon(int.Parse(txt_Ma_LTD.Text)))
                {
                    loadLoaiThucDon();
                    MessageBox.Show("Xóa thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.loadThucDon();
                    this.loadBan();
                    this.loadCBBLoaiThucDon();
                }
                   
                else
                        MessageBox.Show("Có lỗi sảy ra! Kiểm tra lại!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txt_soluong_ThucDon_TextChanged(object sender, EventArgs e)
        {

            if (txt_soluong_ThucDon.Text == "" || txt_soluong_ThucDon.Text == "0")
                cbbTrangThai_ThucDon.SelectedIndex = 1;
            else
                cbbTrangThai_ThucDon.SelectedIndex = 0;
        }

        private void bnt_Huy_LTD_Click(object sender, EventArgs e)
        {
            bnt_Them_LTD.Enabled = true;
            bnt_Sua_LTD.Enabled = false;
            bnt_xoaThucDon.Enabled = false;
            bnt_XacNhan_LTD.Enabled = false;
            bnt_Huy_LTD.Enabled = false;
            txt_TenLTD.Enabled = false;
        }
    }
}
