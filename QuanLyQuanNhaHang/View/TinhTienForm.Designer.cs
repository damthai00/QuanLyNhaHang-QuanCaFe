namespace QuanLyQuanCafe.View
{
    partial class TinhTienForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtIDHD = new System.Windows.Forms.TextBox();
            this.txtNgayHD = new System.Windows.Forms.TextBox();
            this.txtIDBan = new System.Windows.Forms.TextBox();
            this.txtTenBan = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtgCTHD = new System.Windows.Forms.DataGridView();
            this.ten_thucdon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.soluong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dongia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.thanhtien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cbbTenKhachHang = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.cbbIDKH = new System.Windows.Forms.ComboBox();
            this.panelKH = new System.Windows.Forms.Panel();
            this.cbKH = new System.Windows.Forms.CheckBox();
            this.panel8 = new System.Windows.Forms.Panel();
            this.lbTongTien = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCTHD)).BeginInit();
            this.panelKH.SuspendLayout();
            this.panel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(114, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã hóa đơn";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(114, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ngày hóa đơn";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(357, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mã bàn";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(357, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Tên bàn";
            // 
            // txtIDHD
            // 
            this.txtIDHD.Enabled = false;
            this.txtIDHD.Location = new System.Drawing.Point(195, 12);
            this.txtIDHD.Name = "txtIDHD";
            this.txtIDHD.Size = new System.Drawing.Size(73, 20);
            this.txtIDHD.TabIndex = 4;
            // 
            // txtNgayHD
            // 
            this.txtNgayHD.Enabled = false;
            this.txtNgayHD.Location = new System.Drawing.Point(195, 40);
            this.txtNgayHD.Name = "txtNgayHD";
            this.txtNgayHD.Size = new System.Drawing.Size(73, 20);
            this.txtNgayHD.TabIndex = 5;
            // 
            // txtIDBan
            // 
            this.txtIDBan.Enabled = false;
            this.txtIDBan.Location = new System.Drawing.Point(410, 12);
            this.txtIDBan.Name = "txtIDBan";
            this.txtIDBan.Size = new System.Drawing.Size(100, 20);
            this.txtIDBan.TabIndex = 6;
            // 
            // txtTenBan
            // 
            this.txtTenBan.Enabled = false;
            this.txtTenBan.Location = new System.Drawing.Point(410, 38);
            this.txtTenBan.Name = "txtTenBan";
            this.txtTenBan.Size = new System.Drawing.Size(100, 20);
            this.txtTenBan.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(72, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Chi tiết hóa đơn";
            // 
            // dtgCTHD
            // 
            this.dtgCTHD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgCTHD.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ten_thucdon,
            this.soluong,
            this.dongia,
            this.thanhtien});
            this.dtgCTHD.Location = new System.Drawing.Point(74, 142);
            this.dtgCTHD.Name = "dtgCTHD";
            this.dtgCTHD.Size = new System.Drawing.Size(506, 149);
            this.dtgCTHD.TabIndex = 9;
            // 
            // ten_thucdon
            // 
            this.ten_thucdon.DataPropertyName = "ten_thucdon";
            this.ten_thucdon.HeaderText = "Tên thực đơn";
            this.ten_thucdon.Name = "ten_thucdon";
            this.ten_thucdon.Width = 150;
            // 
            // soluong
            // 
            this.soluong.DataPropertyName = "soluong";
            this.soluong.HeaderText = "Số lượng";
            this.soluong.Name = "soluong";
            this.soluong.Width = 75;
            // 
            // dongia
            // 
            this.dongia.DataPropertyName = "dongia";
            this.dongia.HeaderText = "Đơn giá";
            this.dongia.Name = "dongia";
            // 
            // thanhtien
            // 
            this.thanhtien.DataPropertyName = "thanhtien";
            this.thanhtien.HeaderText = "Thành tiền";
            this.thanhtien.Name = "thanhtien";
            this.thanhtien.Width = 120;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(220, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Tên KH";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(39, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Mã KH";
            // 
            // cbbTenKhachHang
            // 
            this.cbbTenKhachHang.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbbTenKhachHang.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbbTenKhachHang.FormattingEnabled = true;
            this.cbbTenKhachHang.Location = new System.Drawing.Point(270, 16);
            this.cbbTenKhachHang.Name = "cbbTenKhachHang";
            this.cbbTenKhachHang.Size = new System.Drawing.Size(165, 21);
            this.cbbTenKhachHang.TabIndex = 14;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(227, 348);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 33);
            this.button1.TabIndex = 15;
            this.button1.Text = "Xác nhận";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(360, 348);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(106, 33);
            this.button2.TabIndex = 16;
            this.button2.Text = "Thoát";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // cbbIDKH
            // 
            this.cbbIDKH.BackColor = System.Drawing.Color.White;
            this.cbbIDKH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbIDKH.Enabled = false;
            this.cbbIDKH.FormattingEnabled = true;
            this.cbbIDKH.Location = new System.Drawing.Point(120, 13);
            this.cbbIDKH.Name = "cbbIDKH";
            this.cbbIDKH.Size = new System.Drawing.Size(73, 21);
            this.cbbIDKH.TabIndex = 17;
            this.cbbIDKH.SelectedIndexChanged += new System.EventHandler(this.cbbIDKH_SelectedIndexChanged);
            // 
            // panelKH
            // 
            this.panelKH.Controls.Add(this.cbbIDKH);
            this.panelKH.Controls.Add(this.label6);
            this.panelKH.Controls.Add(this.label7);
            this.panelKH.Controls.Add(this.cbbTenKhachHang);
            this.panelKH.Location = new System.Drawing.Point(75, 66);
            this.panelKH.Name = "panelKH";
            this.panelKH.Size = new System.Drawing.Size(446, 46);
            this.panelKH.TabIndex = 18;
            this.panelKH.Visible = false;
            // 
            // cbKH
            // 
            this.cbKH.AutoSize = true;
            this.cbKH.Location = new System.Drawing.Point(527, 85);
            this.cbKH.Name = "cbKH";
            this.cbKH.Size = new System.Drawing.Size(84, 17);
            this.cbKH.TabIndex = 19;
            this.cbKH.Text = "Khách hàng";
            this.cbKH.UseVisualStyleBackColor = true;
            this.cbKH.CheckedChanged += new System.EventHandler(this.cbKH_CheckedChanged);
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.lbTongTien);
            this.panel8.Controls.Add(this.label8);
            this.panel8.Location = new System.Drawing.Point(74, 297);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(326, 43);
            this.panel8.TabIndex = 20;
            // 
            // lbTongTien
            // 
            this.lbTongTien.AutoSize = true;
            this.lbTongTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbTongTien.ForeColor = System.Drawing.Color.DarkRed;
            this.lbTongTien.Location = new System.Drawing.Point(132, 9);
            this.lbTongTien.Name = "lbTongTien";
            this.lbTongTien.Size = new System.Drawing.Size(103, 25);
            this.lbTongTien.TabIndex = 15;
            this.lbTongTien.Text = "1000000";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label8.ForeColor = System.Drawing.Color.Green;
            this.label8.Location = new System.Drawing.Point(3, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(125, 25);
            this.label8.TabIndex = 14;
            this.label8.Text = "Tổng tiền: ";
            // 
            // TinhTienForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 403);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.cbKH);
            this.Controls.Add(this.panelKH);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dtgCTHD);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTenBan);
            this.Controls.Add(this.txtIDBan);
            this.Controls.Add(this.txtNgayHD);
            this.Controls.Add(this.txtIDHD);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "TinhTienForm";
            this.Text = "TinhTienForm";
            ((System.ComponentModel.ISupportInitialize)(this.dtgCTHD)).EndInit();
            this.panelKH.ResumeLayout(false);
            this.panelKH.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtIDHD;
        private System.Windows.Forms.TextBox txtNgayHD;
        private System.Windows.Forms.TextBox txtIDBan;
        private System.Windows.Forms.TextBox txtTenBan;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dtgCTHD;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbbTenKhachHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn ten_thucdon;
        private System.Windows.Forms.DataGridViewTextBoxColumn soluong;
        private System.Windows.Forms.DataGridViewTextBoxColumn dongia;
        private System.Windows.Forms.DataGridViewTextBoxColumn thanhtien;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox cbbIDKH;
        private System.Windows.Forms.Panel panelKH;
        private System.Windows.Forms.CheckBox cbKH;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label lbTongTien;
        private System.Windows.Forms.Label label8;
    }
}