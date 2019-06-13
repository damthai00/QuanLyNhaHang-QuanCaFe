namespace QuanLyQuanCafe
{
    partial class QuanLyDoanhThu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dtgCTHD = new System.Windows.Forms.DataGridView();
            this.thanhtien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dongia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.soluong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ten_thucdon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ma_cthd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgHoaDon = new System.Windows.Forms.DataGridView();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_hoadon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label8 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCTHD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgHoaDon)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.dtgHoaDon);
            this.tabPage1.Controls.Add(this.panel3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1249, 451);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Hóa đơn";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dtgCTHD);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Location = new System.Drawing.Point(612, 50);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(576, 395);
            this.panel3.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 24);
            this.label1.TabIndex = 11;
            this.label1.Text = "Chi tiết hóa đơn";
            // 
            // dtgCTHD
            // 
            this.dtgCTHD.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dtgCTHD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgCTHD.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ma_cthd,
            this.ten_thucdon,
            this.soluong,
            this.dongia,
            this.thanhtien});
            this.dtgCTHD.Location = new System.Drawing.Point(3, 31);
            this.dtgCTHD.Name = "dtgCTHD";
            this.dtgCTHD.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtgCTHD.Size = new System.Drawing.Size(563, 361);
            this.dtgCTHD.TabIndex = 12;
            // 
            // thanhtien
            // 
            this.thanhtien.DataPropertyName = "thanhtien";
            this.thanhtien.HeaderText = "Thành tiền";
            this.thanhtien.Name = "thanhtien";
            this.thanhtien.Width = 125;
            // 
            // dongia
            // 
            this.dongia.DataPropertyName = "dongia";
            this.dongia.Frozen = true;
            this.dongia.HeaderText = "Đơn giá";
            this.dongia.Name = "dongia";
            // 
            // soluong
            // 
            this.soluong.DataPropertyName = "soluong";
            this.soluong.Frozen = true;
            this.soluong.HeaderText = "Số lượng";
            this.soluong.Name = "soluong";
            this.soluong.Width = 70;
            // 
            // ten_thucdon
            // 
            this.ten_thucdon.DataPropertyName = "ten_thucdon";
            this.ten_thucdon.Frozen = true;
            this.ten_thucdon.HeaderText = "Tên thực đơn";
            this.ten_thucdon.Name = "ten_thucdon";
            this.ten_thucdon.Width = 150;
            // 
            // ma_cthd
            // 
            this.ma_cthd.DataPropertyName = "id";
            this.ma_cthd.Frozen = true;
            this.ma_cthd.HeaderText = "Mã";
            this.ma_cthd.Name = "ma_cthd";
            this.ma_cthd.Width = 50;
            // 
            // dtgHoaDon
            // 
            this.dtgHoaDon.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dtgHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgHoaDon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_hoadon,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.dtgHoaDon.Location = new System.Drawing.Point(0, 50);
            this.dtgHoaDon.Name = "dtgHoaDon";
            this.dtgHoaDon.Size = new System.Drawing.Size(606, 395);
            this.dtgHoaDon.TabIndex = 0;
            this.dtgHoaDon.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgHoaDon_CellClick);
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "trangthai";
            this.Column6.HeaderText = "Trạng thái";
            this.Column6.Name = "Column6";
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "sotien";
            this.Column5.HeaderText = "Số tiền";
            this.Column5.Name = "Column5";
            this.Column5.Width = 80;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "ngayhd";
            this.Column4.HeaderText = "Ngày HĐ";
            this.Column4.Name = "Column4";
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "id_ban";
            this.Column3.HeaderText = "Tên bàn";
            this.Column3.Name = "Column3";
            this.Column3.Width = 80;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "id_khachhang";
            this.Column2.HeaderText = "Tên Khách hàng";
            this.Column2.Name = "Column2";
            this.Column2.Width = 130;
            // 
            // id_hoadon
            // 
            this.id_hoadon.DataPropertyName = "id";
            this.id_hoadon.HeaderText = "Mã HĐ";
            this.id_hoadon.Name = "id_hoadon";
            this.id_hoadon.Width = 54;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label8.Location = new System.Drawing.Point(0, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 24);
            this.label8.TabIndex = 12;
            this.label8.Text = "Hóa đơn";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1257, 477);
            this.tabControl1.TabIndex = 11;
            // 
            // QuanLyDoanhThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1219, 501);
            this.Controls.Add(this.tabControl1);
            this.Name = "QuanLyDoanhThu";
            this.Text = "Quản Lý Doanh Thu";
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCTHD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgHoaDon)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dtgHoaDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_hoadon;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dtgCTHD;
        private System.Windows.Forms.DataGridViewTextBoxColumn ma_cthd;
        private System.Windows.Forms.DataGridViewTextBoxColumn ten_thucdon;
        private System.Windows.Forms.DataGridViewTextBoxColumn soluong;
        private System.Windows.Forms.DataGridViewTextBoxColumn dongia;
        private System.Windows.Forms.DataGridViewTextBoxColumn thanhtien;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;


    }
}