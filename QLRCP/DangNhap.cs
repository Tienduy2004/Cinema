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
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }
        ketNoiDB ketNoi = new ketNoiDB();
        private string quyen;
        private string username;
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(txtTK.Text.Length != 0 && txtMK.Text.Length != 0)
            {
                if (KtraTK() == true)
                {
                    if (quyen.Equals("admin"))
                    {
                        txtTK.Text = "";
                        txtMK.Text = "";
                        Dashboard dashboard = new Dashboard(username);
                        dashboard.ShowDialog();
                    }
                    if (quyen.Equals("Nhân viên"))
                    {
                        txtTK.Text = "";
                        txtMK.Text = "";
                        DashboardNV dashboard = new DashboardNV(username);
                        dashboard.ShowDialog();
                    }

                }
                else
                {
                    MessageBox.Show("Sai tài khoản hoặc mật khẩu", "Thông báo");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng điền thông tin", "Thông báo");
            }
            
        }
        private bool KtraTK()
        {
            bool ktra = false;
            try
            {
                ketNoi.Connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = ketNoi.Connection;
                cmd.CommandText = "LayTaiKhoan";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@username", SqlDbType.NVarChar, 30)).Value = txtTK.Text;
                cmd.Parameters.Add(new SqlParameter("@pass", SqlDbType.NVarChar, 30)).Value = txtMK.Text;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if(dt.Rows.Count == 1 )
                {
                    if (txtTK.Text.Equals(dt.Rows[0]["userName"].ToString()) && txtMK.Text.Equals(dt.Rows[0]["pass"].ToString()))
                    {
                        ktra = true;
                        quyen = dt.Rows[0]["quyen"].ToString();
                        username = dt.Rows[0]["userName"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }finally
            {
                ketNoi.Connection.Close();
            }
            return ktra;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void DangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                e.Cancel = true; // Ngăn không cho form đóng
            }
        }
    }
}
