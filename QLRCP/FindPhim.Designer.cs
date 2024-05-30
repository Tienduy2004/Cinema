namespace QLRCP
{
    partial class FindPhim
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
            this.txtFindPhim = new System.Windows.Forms.TextBox();
            this.text1 = new System.Windows.Forms.Label();
            this.dgvPhim = new System.Windows.Forms.DataGridView();
            this.radioTenPhim = new System.Windows.Forms.RadioButton();
            this.radioMaPhim = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhim)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtFindPhim
            // 
            this.txtFindPhim.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFindPhim.Location = new System.Drawing.Point(556, 124);
            this.txtFindPhim.Name = "txtFindPhim";
            this.txtFindPhim.Size = new System.Drawing.Size(414, 30);
            this.txtFindPhim.TabIndex = 9;
            this.txtFindPhim.TextChanged += new System.EventHandler(this.txtFindPhim_TextChanged);
            // 
            // text1
            // 
            this.text1.AutoSize = true;
            this.text1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text1.Location = new System.Drawing.Point(559, 29);
            this.text1.Name = "text1";
            this.text1.Size = new System.Drawing.Size(268, 32);
            this.text1.TabIndex = 7;
            this.text1.Text = "DANH SÁCH PHIM";
            // 
            // dgvPhim
            // 
            this.dgvPhim.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPhim.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhim.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvPhim.Location = new System.Drawing.Point(0, 421);
            this.dgvPhim.Name = "dgvPhim";
            this.dgvPhim.RowHeadersWidth = 51;
            this.dgvPhim.RowTemplate.Height = 24;
            this.dgvPhim.Size = new System.Drawing.Size(1083, 264);
            this.dgvPhim.TabIndex = 6;
            // 
            // radioTenPhim
            // 
            this.radioTenPhim.AutoSize = true;
            this.radioTenPhim.Location = new System.Drawing.Point(100, 26);
            this.radioTenPhim.Name = "radioTenPhim";
            this.radioTenPhim.Size = new System.Drawing.Size(115, 29);
            this.radioTenPhim.TabIndex = 12;
            this.radioTenPhim.TabStop = true;
            this.radioTenPhim.Text = "Tên phim";
            this.radioTenPhim.UseVisualStyleBackColor = true;
            // 
            // radioMaPhim
            // 
            this.radioMaPhim.AutoSize = true;
            this.radioMaPhim.Location = new System.Drawing.Point(249, 26);
            this.radioMaPhim.Name = "radioMaPhim";
            this.radioMaPhim.Size = new System.Drawing.Size(108, 29);
            this.radioMaPhim.TabIndex = 13;
            this.radioMaPhim.TabStop = true;
            this.radioMaPhim.Text = "Mã phim";
            this.radioMaPhim.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioMaPhim);
            this.groupBox1.Controls.Add(this.radioTenPhim);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(512, 213);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(707, 154);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tìm Phim Theo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(435, 129);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 25);
            this.label1.TabIndex = 15;
            this.label1.Text = "Tìm kiếm:";
            // 
            // FindPhim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1083, 685);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtFindPhim);
            this.Controls.Add(this.text1);
            this.Controls.Add(this.dgvPhim);
            this.Name = "FindPhim";
            this.Text = "FindPhim";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FindPhim_FormClosing);
            this.Load += new System.EventHandler(this.FindPhim_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhim)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtFindPhim;
        private System.Windows.Forms.Label text1;
        private System.Windows.Forms.DataGridView dgvPhim;
        private System.Windows.Forms.RadioButton radioTenPhim;
        private System.Windows.Forms.RadioButton radioMaPhim;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
    }
}