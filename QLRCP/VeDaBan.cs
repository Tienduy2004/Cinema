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
    public partial class VeDaBan : Form
    {
        public VeDaBan()
        {
            InitializeComponent();
            txtMaVe.KeyPress += NumericTextBox_KeyPress;
        }
        ketNoiDB ketNoi = new ketNoiDB();
        private void dgvVe_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void VeDaBan_Load(object sender, EventArgs e)
        {
            dgvVe.DataSource = ketNoi.LayDanhSach("LayDanhSachVe");
        }

        private void VeDaBan_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                e.Cancel = true; // Ngăn không cho form đóng
            }
        }
        private void NumericTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Kiểm tra xem ký tự nhập vào có phải là số hay không
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Nếu không phải là số, thì hủy bỏ sự kiện
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            if(txtMaVe.Text.Length > 0)
            {
                dgvVe.DataSource = TimVe();
            }
        }
        private DataTable TimVe()
        {
            DataTable dt = new DataTable();
            try
            {
                ketNoi.Connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = ketNoi.Connection;
                cmd.CommandText = "TimVe";
                cmd.CommandType = CommandType.StoredProcedure;
                int maVe = int.Parse(txtMaVe.Text);
                cmd.Parameters.Add(new SqlParameter("@mave", SqlDbType.Int)).Value = maVe;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }catch (Exception ex)
            {

            }
            finally
            {
                ketNoi.Connection.Close();
            }
            return dt;
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            dgvVe.DataSource = ketNoi.LayDanhSach("LayDanhSachVe");
            txtMaVe.Text = "";
        }
    }
}
