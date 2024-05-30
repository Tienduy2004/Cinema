using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLRCP
{
    public partial class FindPhim : Form
    {
        public FindPhim()
        {
            InitializeComponent();
        }
        ketNoiDB ketNoi = new ketNoiDB();

        private void btnTim_Click(object sender, EventArgs e)
        {
            
        }
        private DataTable LayPhimTheoTen() {
            DataTable dt = new DataTable();
            try
            {
                ketNoi.Connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = ketNoi.Connection;
                cmd.CommandText = "TimPhimTheoTen";
                cmd.CommandType = CommandType.StoredProcedure;
                string str = "%"+txtFindPhim.Text+"%";
                cmd.Parameters.Add(new SqlParameter("@tenphim", SqlDbType.NVarChar, 100)).Value = str;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                ketNoi.Connection.Close();
            }
            return dt;
        }
        private DataTable LayPhimTheoMa()
        {
            DataTable dt = new DataTable();
            try
            {
                ketNoi.Connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = ketNoi.Connection;
                cmd.CommandText = "TimPhimTheoMa";
                cmd.CommandType = CommandType.StoredProcedure;
                string str = "%" + txtFindPhim.Text + "%";
                cmd.Parameters.Add(new SqlParameter("@maphim", SqlDbType.NVarChar, 10)).Value = str;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                ketNoi.Connection.Close();
            }
            return dt;
        }

        private void txtFindPhim_TextChanged(object sender, EventArgs e)
        {
            if(radioTenPhim.Checked)
            {
                dgvPhim.DataSource = LayPhimTheoTen();
            }
            else if(radioMaPhim.Checked)
            {
                dgvPhim.DataSource = LayPhimTheoMa();
            }
            
            
        }

        private void FindPhim_Load(object sender, EventArgs e)
        {
            radioTenPhim.Checked = true;
            dgvPhim.DataSource= ketNoi.LayDanhSach("LayDSPhim");
        }

        private void FindPhim_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                e.Cancel = true; // Ngăn không cho form đóng
            }
        }
    }
}
