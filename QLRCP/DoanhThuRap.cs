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
    public partial class DoanhThuRap : Form
    {
        public DoanhThuRap()
        {
            InitializeComponent();
        }
        ketNoiDB ketNoi = new ketNoiDB();
        private DataTable dtDoanhThu = new DataTable();
        private void LayDanhSachRap()
        {
            cmbMaRap.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMaRap.DataSource = ketNoi.LayDanhSach("LayDanhSachRap");
            cmbMaRap.DisplayMember = "tenRap";
            cmbMaRap.ValueMember = "maRap";
            cmbMaRap.SelectedIndex = 0;
        }

        private void DoanhThuRap_Load(object sender, EventArgs e)
        {          
            LayDanhSachRap();
        }
        private void LayDanhSachDoanhThu()
        {
            try
            {
                ketNoi.Connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = ketNoi.Connection;
                cmd.CommandText = "DoanhThuRap";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@marap", SqlDbType.NVarChar, 10)).Value = cmbMaRap.SelectedValue;
                cmd.Parameters.Add(new SqlParameter("@tungay", SqlDbType.Date)).Value = dateTimeTuNgay.Value.Date;
                cmd.Parameters.Add(new SqlParameter("@denngay", SqlDbType.Date)).Value = dateTimeDenNgay.Value.Date;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvDoanhThu.DataSource = dt;
                da.Fill(dtDoanhThu);
                if (dt.Rows.Count > 0)
                {
                    float TongDoanhThu = 0;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string TongTien = dt.Rows[i]["tongTien"].ToString();
                        TongDoanhThu += float.Parse(TongTien);
                    }
                    txtTongTien.Text = TongDoanhThu.ToString() + " đ";
                }
                else
                {
                    MessageBox.Show("Không có doanh thu nào", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi" + ex, "Thông báo");
            }
            finally
            {
                ketNoi.Connection.Close();
            }
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            LayDanhSachDoanhThu();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            CrystalReportDoanhThuRap baoCaoDoanhThuRap = new CrystalReportDoanhThuRap();
            baoCaoDoanhThuRap.SetDataSource(dtDoanhThu);
            InDoanhThuRap inDoanhThuRap = new InDoanhThuRap();
            inDoanhThuRap.crystalReportViewerDoanhThuRap.ReportSource = baoCaoDoanhThuRap;
            inDoanhThuRap.ShowDialog();
        }
    }
}
