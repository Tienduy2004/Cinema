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
    public partial class HoaDonBanVe : Form
    {
        public HoaDonBanVe(string tongTien)
        {
            InitializeComponent();
            txtTongTien.Text = tongTien+"đ";
        }
        ketNoiDB ketNoi = new ketNoiDB();
        private void HoaDonBanVe_Load(object sender, EventArgs e)
        {
            dgvDanhSachVe.DataSource = LayDanhSach();
        }
        public DataTable LayDanhSach()
        {
            DataTable dt = new DataTable();
            try
            {
                ketNoi.Connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "LayDanhSachVeTam";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = ketNoi.Connection;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { ketNoi.Connection.Close(); }
            return dt;
        }
        private void XoaveTam(int maVe)
        {
            try
            {
                ketNoi.Connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "XoaVeTam";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = ketNoi.Connection;
                cmd.Parameters.Add(new SqlParameter("mave", SqlDbType.Int)).Value = maVe;
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { ketNoi.Connection.Close(); }
        }

        private void btnXuatHoaDon_Click(object sender, EventArgs e)
        {
            DataTable dt = LayDanhSach();
            CrystalReportHoaDon crystalReportHoaDon = new CrystalReportHoaDon();
            crystalReportHoaDon.SetDataSource(dt);
            InHoaDon inHoaDon = new InHoaDon();
            inHoaDon.crystalReportViewer2.ReportSource = crystalReportHoaDon;
            inHoaDon.ShowDialog();
            foreach (DataGridViewRow row in dgvDanhSachVe.Rows)
            {
                if (!row.IsNewRow)
                {
                    int maVeTam = int.Parse(row.Cells[0].Value.ToString());
                    XoaveTam(maVeTam);
                }
            }
            dgvDanhSachVe.DataSource = LayDanhSach();
            txtTongTien.Text = "";
            
            
        }

        private void HoaDonBanVe_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                e.Cancel = true; // Ngăn không cho form đóng
            }
        }
    }
}
