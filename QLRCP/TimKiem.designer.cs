namespace QLRCP
{
    partial class TimKiem
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
            this.txtTimKiemNV = new System.Windows.Forms.TextBox();
            this.btnTimKiemNV = new System.Windows.Forms.Button();
            this.dataGridViewTimKiemNV = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.btnThoat = new System.Windows.Forms.Button();
            this.lblTimKiem = new System.Windows.Forms.Label();
            this.rdMaNV = new System.Windows.Forms.RadioButton();
            this.rdTenNV = new System.Windows.Forms.RadioButton();
            this.rdGender = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTimKiemNV)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTimKiemNV
            // 
            this.txtTimKiemNV.Location = new System.Drawing.Point(258, 124);
            this.txtTimKiemNV.Name = "txtTimKiemNV";
            this.txtTimKiemNV.Size = new System.Drawing.Size(270, 20);
            this.txtTimKiemNV.TabIndex = 0;
            // 
            // btnTimKiemNV
            // 
            this.btnTimKiemNV.Location = new System.Drawing.Point(548, 124);
            this.btnTimKiemNV.Name = "btnTimKiemNV";
            this.btnTimKiemNV.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnTimKiemNV.Size = new System.Drawing.Size(75, 23);
            this.btnTimKiemNV.TabIndex = 1;
            this.btnTimKiemNV.Text = "Tìm Kiếm";
            this.btnTimKiemNV.UseVisualStyleBackColor = true;
            this.btnTimKiemNV.Click += new System.EventHandler(this.btnTimKiemNV_Click);
            // 
            // dataGridViewTimKiemNV
            // 
            this.dataGridViewTimKiemNV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTimKiemNV.Location = new System.Drawing.Point(12, 218);
            this.dataGridViewTimKiemNV.Name = "dataGridViewTimKiemNV";
            this.dataGridViewTimKiemNV.Size = new System.Drawing.Size(763, 161);
            this.dataGridViewTimKiemNV.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(340, 51);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(135, 31);
            this.label8.TabIndex = 6;
            this.label8.Text = "Tìm Kiếm";
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(636, 404);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnThoat.Size = new System.Drawing.Size(75, 23);
            this.btnThoat.TabIndex = 7;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // lblTimKiem
            // 
            this.lblTimKiem.AutoSize = true;
            this.lblTimKiem.Location = new System.Drawing.Point(171, 127);
            this.lblTimKiem.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTimKiem.Name = "lblTimKiem";
            this.lblTimKiem.Size = new System.Drawing.Size(80, 13);
            this.lblTimKiem.TabIndex = 36;
            this.lblTimKiem.Text = "Nhập thông tin:";
            // 
            // rdMaNV
            // 
            this.rdMaNV.AutoSize = true;
            this.rdMaNV.Location = new System.Drawing.Point(165, 171);
            this.rdMaNV.Name = "rdMaNV";
            this.rdMaNV.Size = new System.Drawing.Size(93, 17);
            this.rdMaNV.TabIndex = 37;
            this.rdMaNV.TabStop = true;
            this.rdMaNV.Text = "Mã Nhân Viên";
            this.rdMaNV.UseVisualStyleBackColor = true;
            // 
            // rdTenNV
            // 
            this.rdTenNV.AutoSize = true;
            this.rdTenNV.Location = new System.Drawing.Point(346, 171);
            this.rdTenNV.Name = "rdTenNV";
            this.rdTenNV.Size = new System.Drawing.Size(97, 17);
            this.rdTenNV.TabIndex = 38;
            this.rdTenNV.TabStop = true;
            this.rdTenNV.Text = "Tên Nhân Viên";
            this.rdTenNV.UseVisualStyleBackColor = true;
            // 
            // rdGender
            // 
            this.rdGender.AutoSize = true;
            this.rdGender.Location = new System.Drawing.Point(511, 171);
            this.rdGender.Name = "rdGender";
            this.rdGender.Size = new System.Drawing.Size(60, 17);
            this.rdGender.TabIndex = 39;
            this.rdGender.TabStop = true;
            this.rdGender.Text = "Gender";
            this.rdGender.UseVisualStyleBackColor = true;
            // 
            // TimKiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rdGender);
            this.Controls.Add(this.rdTenNV);
            this.Controls.Add(this.rdMaNV);
            this.Controls.Add(this.lblTimKiem);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dataGridViewTimKiemNV);
            this.Controls.Add(this.btnTimKiemNV);
            this.Controls.Add(this.txtTimKiemNV);
            this.Name = "TimKiem";
            this.Text = "Tìm Kiếm Nhân Viên";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTimKiemNV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTimKiemNV;
        private System.Windows.Forms.Button btnTimKiemNV;
        private System.Windows.Forms.DataGridView dataGridViewTimKiemNV;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Label lblTimKiem;
        private System.Windows.Forms.RadioButton rdMaNV;
        private System.Windows.Forms.RadioButton rdTenNV;
        private System.Windows.Forms.RadioButton rdGender;
    }
}