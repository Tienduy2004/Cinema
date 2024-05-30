namespace QLRCP
{
    partial class InDoanhThuRap
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
            this.crystalReportViewerDoanhThuRap = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crystalReportViewerDoanhThuRap
            // 
            this.crystalReportViewerDoanhThuRap.ActiveViewIndex = -1;
            this.crystalReportViewerDoanhThuRap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewerDoanhThuRap.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewerDoanhThuRap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewerDoanhThuRap.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewerDoanhThuRap.Name = "crystalReportViewerDoanhThuRap";
            this.crystalReportViewerDoanhThuRap.Size = new System.Drawing.Size(800, 450);
            this.crystalReportViewerDoanhThuRap.TabIndex = 0;
            // 
            // InDoanhThuRap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.crystalReportViewerDoanhThuRap);
            this.Name = "InDoanhThuRap";
            this.Text = "InDoanhThuRap";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewerDoanhThuRap;
    }
}