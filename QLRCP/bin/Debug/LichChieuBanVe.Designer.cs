namespace QLRCP
{
    partial class LichChieuBanVe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LichChieuBanVe));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnChonVe = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.cmbPhim = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dateChieu = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvLichChieu = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichChieu)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnChonVe);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.cmbPhim);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dateChieu);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Red;
            this.groupBox1.Location = new System.Drawing.Point(53, 172);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(381, 606);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chi tiết";
            // 
            // btnChonVe
            // 
            this.btnChonVe.Location = new System.Drawing.Point(246, 548);
            this.btnChonVe.Name = "btnChonVe";
            this.btnChonVe.Size = new System.Drawing.Size(129, 52);
            this.btnChonVe.TabIndex = 5;
            this.btnChonVe.Text = "Chọn vé";
            this.btnChonVe.UseVisualStyleBackColor = true;
            this.btnChonVe.Click += new System.EventHandler(this.btnChonVe_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(256, 762);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(119, 56);
            this.button1.TabIndex = 4;
            this.button1.Text = "Chọn vé";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // cmbPhim
            // 
            this.cmbPhim.FormattingEnabled = true;
            this.cmbPhim.Location = new System.Drawing.Point(26, 131);
            this.cmbPhim.Name = "cmbPhim";
            this.cmbPhim.Size = new System.Drawing.Size(315, 33);
            this.cmbPhim.TabIndex = 3;
            this.cmbPhim.SelectedIndexChanged += new System.EventHandler(this.cmbPhim_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Phim:";
            // 
            // dateChieu
            // 
            this.dateChieu.CustomFormat = "dd/MM/yyyy";
            this.dateChieu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateChieu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateChieu.Location = new System.Drawing.Point(26, 65);
            this.dateChieu.Name = "dateChieu";
            this.dateChieu.Size = new System.Drawing.Size(321, 30);
            this.dateChieu.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thời gian:";
            // 
            // dgvLichChieu
            // 
            this.dgvLichChieu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLichChieu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLichChieu.Location = new System.Drawing.Point(483, 172);
            this.dgvLichChieu.Name = "dgvLichChieu";
            this.dgvLichChieu.RowHeadersWidth = 51;
            this.dgvLichChieu.RowTemplate.Height = 24;
            this.dgvLichChieu.Size = new System.Drawing.Size(948, 606);
            this.dgvLichChieu.TabIndex = 9;
            this.dgvLichChieu.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLichChieu_CellClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Location = new System.Drawing.Point(231, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(727, 91);
            this.label3.TabIndex = 10;
            this.label3.Text = "LỊCH CHIẾU PHIM";
            // 
            // LichChieuBanVe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1489, 843);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvLichChieu);
            this.Controls.Add(this.label3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LichChieuBanVe";
            this.Text = "LichChieuBanVe";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LichChieuBanVe_FormClosing);
            this.Load += new System.EventHandler(this.LichChieuBanVe_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichChieu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cmbPhim;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateChieu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvLichChieu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnChonVe;
    }
}