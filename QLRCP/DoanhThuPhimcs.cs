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
    public partial class DoanhThuPhimcs : Form
    {
        public DoanhThuPhimcs()
        {
            InitializeComponent();
        }
        ketNoiDB ketNoi = new ketNoiDB();
        private bool ktra = false;
        private DataTable dtDoanhThu = new DataTable();
        private void DoanhThuPhimcs_Load(object sender, EventArgs e)
        {
            cmbPhim.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPhim.DataSource = ketNoi.LayDanhSach("LayDSPhim");
            cmbPhim.DisplayMember = "tenPhim";
            cmbPhim.ValueMember = "maPhim";
            cmbPhim.SelectedIndex = 0;
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            LayDanhSachDoanhThu();
        }
        private void LayDanhSachDoanhThu()
        {
            try
            {
                ketNoi.Connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = ketNoi.Connection;
                cmd.CommandText = "DoanhThuPhim";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@maphim", SqlDbType.NVarChar, 10)).Value = cmbPhim.SelectedValue;
                cmd.Parameters.Add(new SqlParameter("@tungay", SqlDbType.Date)).Value = dateTimeTuNgay.Value.Date;
                cmd.Parameters.Add(new SqlParameter("@denngay", SqlDbType.Date)).Value = dateTimeDenNgay.Value.Date;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                da.Fill(dtDoanhThu);
                dgvDoanhThu.DataSource = dt;
                if(dt.Rows.Count > 0 )
                {
                    float TongDoanhThu = 0;
                    for( int i = 0; i < dt.Rows.Count; i++ )
                    {
                        string TongTien = dt.Rows[i]["tongTien"].ToString();
                        TongDoanhThu += float.Parse(TongTien);
                    }
                    txtTongTien.Text = TongDoanhThu.ToString() +" đ";
                    ktra = true;
                } else
                {
                    MessageBox.Show("Không có doanh thu nào", "Thông báo");
                    ktra = false;
                }    
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi" + ex, "Thông báo");
            }finally
            {
                ketNoi.Connection.Close(); 
            }
        }

        private void btnInBaoCao_Click(object sender, EventArgs e)
        {
            if (ktra == true)
            {
                CrystalReportDoanhThuPhim baoCaoDoanhThuPhim = new CrystalReportDoanhThuPhim();
                baoCaoDoanhThuPhim.SetDataSource(dtDoanhThu);
                InDoanhThuPhim inDoanhThuPhim = new InDoanhThuPhim();
                inDoanhThuPhim.crystalReportViewerDoanhThuPhim.ReportSource = baoCaoDoanhThuPhim;
                inDoanhThuPhim.ShowDialog();
            }
            else
            {
                    MessageBox.Show("Không có doanh thu nào", "Thông báo");
            }

        }
    }
}
