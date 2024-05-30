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
    public partial class DashboardNV : Form
    {
        public DashboardNV(string taiKhoan)
        {
            InitializeComponent();
            lableUserName.Text = taiKhoan;
        }

        private void btnBanVe_Click(object sender, EventArgs e)
        {
            LichChieuBanVe lichChieuBanVe = new LichChieuBanVe();
            lichChieuBanVe.ShowDialog();
        }

        private void DashboardNV_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                e.Cancel = true; // Ngăn không cho form đóng
            }
        }
    }
}
