namespace QLRCP
{
    partial class DashboardNV
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DashboardNV));
            this.lableUserName = new System.Windows.Forms.Label();
            this.btnBanVe = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lableUserName
            // 
            this.lableUserName.AutoSize = true;
            this.lableUserName.Location = new System.Drawing.Point(144, 40);
            this.lableUserName.Name = "lableUserName";
            this.lableUserName.Size = new System.Drawing.Size(76, 16);
            this.lableUserName.TabIndex = 7;
            this.lableUserName.Text = "tentaikhoan";
            // 
            // btnBanVe
            // 
            this.btnBanVe.Location = new System.Drawing.Point(172, 124);
            this.btnBanVe.Name = "btnBanVe";
            this.btnBanVe.Size = new System.Drawing.Size(176, 54);
            this.btnBanVe.TabIndex = 6;
            this.btnBanVe.Text = "Bán vé";
            this.btnBanVe.UseVisualStyleBackColor = true;
            this.btnBanVe.Click += new System.EventHandler(this.btnBanVe_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Tên tài khoản:";
            // 
            // DashboardNV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 272);
            this.Controls.Add(this.lableUserName);
            this.Controls.Add(this.btnBanVe);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DashboardNV";
            this.Text = "DashboardNV";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DashboardNV_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lableUserName;
        private System.Windows.Forms.Button btnBanVe;
        private System.Windows.Forms.Label label1;
    }
}