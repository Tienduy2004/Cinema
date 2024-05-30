using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLRCP
{
    public partial class Dashboard : Form
    {
        public Dashboard(string taikhoan)
        {
            InitializeComponent();
            lableUserName.Text = taikhoan;
        }

        private void btnQuanLy_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.ShowDialog();
        }

        private void btnBanVe_Click(object sender, EventArgs e)
        {
            LichChieuBanVe lichChieuBanVe = new LichChieuBanVe();
            lichChieuBanVe.ShowDialog();
        }

        private void Dashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                e.Cancel = true; // Ngăn không cho form đóng
            }
        }
    }
}
