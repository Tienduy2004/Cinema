namespace QLRCP
{
    partial class HoaDonBanVe
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
            this.dgvDanhSachVe = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnXuatHoaDon = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachVe)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDanhSachVe
            // 
            this.dgvDanhSachVe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhSachVe.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvDanhSachVe.Location = new System.Drawing.Point(0, 236);
            this.dgvDanhSachVe.Name = "dgvDanhSachVe";
            this.dgvDanhSachVe.RowHeadersWidth = 51;
            this.dgvDanhSachVe.RowTemplate.Height = 24;
            this.dgvDanhSachVe.Size = new System.Drawing.Size(844, 283);
            this.dgvDanhSachVe.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(212, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(423, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "DANH SÁCH VÉ ĐƯỢC CHỌN";
            // 
            // btnXuatHoaDon
            // 
            this.btnXuatHoaDon.Location = new System.Drawing.Point(21, 175);
            this.btnXuatHoaDon.Name = "btnXuatHoaDon";
            this.btnXuatHoaDon.Size = new System.Drawing.Size(107, 45);
            this.btnXuatHoaDon.TabIndex = 2;
            this.btnXuatHoaDon.Text = "Xuất hóa đơn";
            this.btnXuatHoaDon.UseVisualStyleBackColor = true;
            this.btnXuatHoaDon.Click += new System.EventHandler(this.btnXuatHoaDon_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tổng Tiền:";
            // 
            // txtTongTien
            // 
            this.txtTongTien.Enabled = false;
            this.txtTongTien.Location = new System.Drawing.Point(96, 88);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.ReadOnly = true;
            this.txtTongTien.Size = new System.Drawing.Size(137, 22);
            this.txtTongTien.TabIndex = 4;
            // 
            // HoaDonBanVe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 519);
            this.Controls.Add(this.txtTongTien);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnXuatHoaDon);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvDanhSachVe);
            this.Name = "HoaDonBanVe";
            this.Text = "HoaDonBanVe";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HoaDonBanVe_FormClosing);
            this.Load += new System.EventHandler(this.HoaDonBanVe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachVe)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDanhSachVe;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnXuatHoaDon;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTongTien;
    }
}