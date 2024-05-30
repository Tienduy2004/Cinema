namespace QLRCP
{
    partial class Phim
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.thoiLuongPhim = new System.Windows.Forms.DateTimePicker();
            this.timeNamSX = new System.Windows.Forms.DateTimePicker();
            this.label14 = new System.Windows.Forms.Label();
            this.cbbNuoc = new System.Windows.Forms.ComboBox();
            this.cbbTL = new System.Windows.Forms.ComboBox();
            this.cbbHang = new System.Windows.Forms.ComboBox();
            this.timeEnd = new System.Windows.Forms.DateTimePicker();
            this.timeStart = new System.Windows.Forms.DateTimePicker();
            this.txtDienVien = new System.Windows.Forms.TextBox();
            this.txtDaodien = new System.Windows.Forms.TextBox();
            this.txtNoidungphim = new System.Windows.Forms.TextBox();
            this.txtTenPhim = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtMaPhim = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnLammoi = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.dgvPhim = new System.Windows.Forms.DataGridView();
            this.label13 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhim)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(465, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(236, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "Quản Lý Phim";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.thoiLuongPhim);
            this.groupBox.Controls.Add(this.timeNamSX);
            this.groupBox.Controls.Add(this.label14);
            this.groupBox.Controls.Add(this.cbbNuoc);
            this.groupBox.Controls.Add(this.cbbTL);
            this.groupBox.Controls.Add(this.cbbHang);
            this.groupBox.Controls.Add(this.timeEnd);
            this.groupBox.Controls.Add(this.timeStart);
            this.groupBox.Controls.Add(this.txtDienVien);
            this.groupBox.Controls.Add(this.txtDaodien);
            this.groupBox.Controls.Add(this.txtNoidungphim);
            this.groupBox.Controls.Add(this.txtTenPhim);
            this.groupBox.Controls.Add(this.label10);
            this.groupBox.Controls.Add(this.txtMaPhim);
            this.groupBox.Controls.Add(this.label12);
            this.groupBox.Controls.Add(this.label11);
            this.groupBox.Controls.Add(this.label9);
            this.groupBox.Controls.Add(this.label8);
            this.groupBox.Controls.Add(this.label7);
            this.groupBox.Controls.Add(this.label6);
            this.groupBox.Controls.Add(this.label5);
            this.groupBox.Controls.Add(this.label4);
            this.groupBox.Controls.Add(this.label3);
            this.groupBox.Controls.Add(this.label2);
            this.groupBox.Location = new System.Drawing.Point(12, 107);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(1158, 201);
            this.groupBox.TabIndex = 1;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Thông tin phim";
            // 
            // thoiLuongPhim
            // 
            this.thoiLuongPhim.CustomFormat = "HH:mm";
            this.thoiLuongPhim.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.thoiLuongPhim.Location = new System.Drawing.Point(146, 151);
            this.thoiLuongPhim.Name = "thoiLuongPhim";
            this.thoiLuongPhim.Size = new System.Drawing.Size(200, 22);
            this.thoiLuongPhim.TabIndex = 26;
            // 
            // timeNamSX
            // 
            this.timeNamSX.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.timeNamSX.Location = new System.Drawing.Point(566, 120);
            this.timeNamSX.Name = "timeNamSX";
            this.timeNamSX.Size = new System.Drawing.Size(169, 22);
            this.timeNamSX.TabIndex = 25;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(457, 126);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(91, 16);
            this.label14.TabIndex = 24;
            this.label14.Text = "Năm sản xuất:";
            // 
            // cbbNuoc
            // 
            this.cbbNuoc.FormattingEnabled = true;
            this.cbbNuoc.Location = new System.Drawing.Point(566, 57);
            this.cbbNuoc.Name = "cbbNuoc";
            this.cbbNuoc.Size = new System.Drawing.Size(169, 24);
            this.cbbNuoc.TabIndex = 23;
            // 
            // cbbTL
            // 
            this.cbbTL.FormattingEnabled = true;
            this.cbbTL.Location = new System.Drawing.Point(566, 90);
            this.cbbTL.Name = "cbbTL";
            this.cbbTL.Size = new System.Drawing.Size(169, 24);
            this.cbbTL.TabIndex = 21;
            this.cbbTL.SelectedIndexChanged += new System.EventHandler(this.cbbTL_SelectedIndexChanged);
            // 
            // cbbHang
            // 
            this.cbbHang.FormattingEnabled = true;
            this.cbbHang.Location = new System.Drawing.Point(566, 24);
            this.cbbHang.Name = "cbbHang";
            this.cbbHang.Size = new System.Drawing.Size(169, 24);
            this.cbbHang.TabIndex = 19;
            // 
            // timeEnd
            // 
            this.timeEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.timeEnd.Location = new System.Drawing.Point(515, 152);
            this.timeEnd.Name = "timeEnd";
            this.timeEnd.Size = new System.Drawing.Size(114, 22);
            this.timeEnd.TabIndex = 18;
            // 
            // timeStart
            // 
            this.timeStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.timeStart.Location = new System.Drawing.Point(710, 151);
            this.timeStart.Name = "timeStart";
            this.timeStart.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.timeStart.Size = new System.Drawing.Size(114, 22);
            this.timeStart.TabIndex = 17;
            this.timeStart.ValueChanged += new System.EventHandler(this.timeStart_ValueChanged);
            // 
            // txtDienVien
            // 
            this.txtDienVien.Location = new System.Drawing.Point(146, 123);
            this.txtDienVien.Name = "txtDienVien";
            this.txtDienVien.Size = new System.Drawing.Size(280, 22);
            this.txtDienVien.TabIndex = 15;
            this.txtDienVien.TextChanged += new System.EventHandler(this.txtDienVien_TextChanged);
            // 
            // txtDaodien
            // 
            this.txtDaodien.Location = new System.Drawing.Point(146, 92);
            this.txtDaodien.Name = "txtDaodien";
            this.txtDaodien.Size = new System.Drawing.Size(280, 22);
            this.txtDaodien.TabIndex = 14;
            // 
            // txtNoidungphim
            // 
            this.txtNoidungphim.Location = new System.Drawing.Point(866, 24);
            this.txtNoidungphim.Multiline = true;
            this.txtNoidungphim.Name = "txtNoidungphim";
            this.txtNoidungphim.Size = new System.Drawing.Size(286, 150);
            this.txtNoidungphim.TabIndex = 11;
            // 
            // txtTenPhim
            // 
            this.txtTenPhim.Location = new System.Drawing.Point(146, 59);
            this.txtTenPhim.Name = "txtTenPhim";
            this.txtTenPhim.Size = new System.Drawing.Size(280, 22);
            this.txtTenPhim.TabIndex = 13;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(762, 33);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(98, 16);
            this.label10.TabIndex = 8;
            this.label10.Text = "Nội dung chính:";
            // 
            // txtMaPhim
            // 
            this.txtMaPhim.Location = new System.Drawing.Point(146, 27);
            this.txtMaPhim.Name = "txtMaPhim";
            this.txtMaPhim.Size = new System.Drawing.Size(280, 22);
            this.txtMaPhim.TabIndex = 12;
            this.txtMaPhim.TextChanged += new System.EventHandler(this.txtMaPhim_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(457, 158);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(34, 16);
            this.label12.TabIndex = 10;
            this.label12.Text = "End:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(26, 158);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(105, 16);
            this.label11.TabIndex = 9;
            this.label11.Text = "Thời lượng phim:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(652, 156);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 16);
            this.label9.TabIndex = 7;
            this.label9.Text = "Start:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(457, 98);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 16);
            this.label8.TabIndex = 6;
            this.label8.Text = "Thể loại phim:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(26, 65);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 16);
            this.label7.TabIndex = 5;
            this.label7.Text = "Tên Phim:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 98);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 16);
            this.label6.TabIndex = 4;
            this.label6.Text = "Đạo diễn:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 16);
            this.label5.TabIndex = 3;
            this.label5.Text = "Diễn viên chính:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(457, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "Hãng phim:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(457, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "Nước sản xuất:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mã Phim:";
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.White;
            this.btnThoat.Location = new System.Drawing.Point(605, 18);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(100, 39);
            this.btnThoat.TabIndex = 4;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(462, 18);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(3, 3, 40, 3);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(100, 39);
            this.btnXoa.TabIndex = 3;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.White;
            this.btnSua.Location = new System.Drawing.Point(319, 18);
            this.btnSua.Margin = new System.Windows.Forms.Padding(3, 3, 40, 3);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(100, 39);
            this.btnSua.TabIndex = 2;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(176, 18);
            this.btnThem.Margin = new System.Windows.Forms.Padding(3, 3, 40, 3);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(100, 39);
            this.btnThem.TabIndex = 1;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnLammoi
            // 
            this.btnLammoi.BackColor = System.Drawing.Color.White;
            this.btnLammoi.Location = new System.Drawing.Point(33, 18);
            this.btnLammoi.Margin = new System.Windows.Forms.Padding(3, 3, 40, 3);
            this.btnLammoi.Name = "btnLammoi";
            this.btnLammoi.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnLammoi.Size = new System.Drawing.Size(100, 39);
            this.btnLammoi.TabIndex = 0;
            this.btnLammoi.Text = "Làm mới";
            this.btnLammoi.UseVisualStyleBackColor = false;
            this.btnLammoi.Click += new System.EventHandler(this.btnLammoi_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Silver;
            this.flowLayoutPanel1.Controls.Add(this.btnLammoi);
            this.flowLayoutPanel1.Controls.Add(this.btnThem);
            this.flowLayoutPanel1.Controls.Add(this.btnSua);
            this.flowLayoutPanel1.Controls.Add(this.btnXoa);
            this.flowLayoutPanel1.Controls.Add(this.btnThoat);
            this.flowLayoutPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flowLayoutPanel1.Location = new System.Drawing.Point(199, 314);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(30, 15, 0, 0);
            this.flowLayoutPanel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.flowLayoutPanel1.Size = new System.Drawing.Size(753, 76);
            this.flowLayoutPanel1.TabIndex = 13;
            // 
            // dgvPhim
            // 
            this.dgvPhim.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhim.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvPhim.Location = new System.Drawing.Point(0, 427);
            this.dgvPhim.Name = "dgvPhim";
            this.dgvPhim.RowHeadersWidth = 51;
            this.dgvPhim.RowTemplate.Height = 24;
            this.dgvPhim.Size = new System.Drawing.Size(1182, 226);
            this.dgvPhim.TabIndex = 14;
            this.dgvPhim.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPhim_CellContentClick);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(8, 406);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(115, 18);
            this.label13.TabIndex = 15;
            this.label13.Text = "Danh sách phim";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // Phim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 653);
            this.ControlBox = false;
            this.Controls.Add(this.label13);
            this.Controls.Add(this.dgvPhim);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.label1);
            this.Name = "Phim";
            this.Text = "Phim";
            this.Load += new System.EventHandler(this.Phim_Load);
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhim)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.ComboBox cbbTL;
        private System.Windows.Forms.ComboBox cbbHang;
        private System.Windows.Forms.DateTimePicker timeEnd;
        private System.Windows.Forms.TextBox txtDienVien;
        private System.Windows.Forms.TextBox txtDaodien;
        private System.Windows.Forms.TextBox txtNoidungphim;
        private System.Windows.Forms.TextBox txtTenPhim;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtMaPhim;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker timeStart;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnLammoi;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.DataGridView dgvPhim;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cbbNuoc;
        private System.Windows.Forms.DateTimePicker timeNamSX;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.DateTimePicker thoiLuongPhim;
    }
}