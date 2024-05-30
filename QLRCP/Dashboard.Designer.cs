namespace QLRCP
{
    partial class Dashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            this.label1 = new System.Windows.Forms.Label();
            this.btnQuanLy = new System.Windows.Forms.Button();
            this.btnBanVe = new System.Windows.Forms.Button();
            this.lableUserName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên tài khoản:";
            // 
            // btnQuanLy
            // 
            this.btnQuanLy.Location = new System.Drawing.Point(163, 107);
            this.btnQuanLy.Name = "btnQuanLy";
            this.btnQuanLy.Size = new System.Drawing.Size(176, 54);
            this.btnQuanLy.TabIndex = 1;
            this.btnQuanLy.Text = "Quản lý";
            this.btnQuanLy.UseVisualStyleBackColor = true;
            this.btnQuanLy.Click += new System.EventHandler(this.btnQuanLy_Click);
            // 
            // btnBanVe
            // 
            this.btnBanVe.Location = new System.Drawing.Point(163, 175);
            this.btnBanVe.Name = "btnBanVe";
            this.btnBanVe.Size = new System.Drawing.Size(176, 54);
            this.btnBanVe.TabIndex = 2;
            this.btnBanVe.Text = "Bán vé";
            this.btnBanVe.UseVisualStyleBackColor = true;
            this.btnBanVe.Click += new System.EventHandler(this.btnBanVe_Click);
            // 
            // lableUserName
            // 
            this.lableUserName.AutoSize = true;
            this.lableUserName.Location = new System.Drawing.Point(109, 35);
            this.lableUserName.Name = "lableUserName";
            this.lableUserName.Size = new System.Drawing.Size(76, 16);
            this.lableUserName.TabIndex = 3;
            this.lableUserName.Text = "tentaikhoan";
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 307);
            this.Controls.Add(this.lableUserName);
            this.Controls.Add(this.btnBanVe);
            this.Controls.Add(this.btnQuanLy);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Dashboard";
            this.Text = "Dashboard";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Dashboard_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnQuanLy;
        private System.Windows.Forms.Button btnBanVe;
        private System.Windows.Forms.Label lableUserName;
    }
}