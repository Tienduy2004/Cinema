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
    public partial class QuanLyTaiKhoan : Form
    {
        public QuanLyTaiKhoan()
        {
            InitializeComponent();
        }
        ketNoiDB ketNoi = new ketNoiDB();
        private bool ktraNhan = false;
        private string usernamecu;
        private void QuanLyTaiKhoan_Load(object sender, EventArgs e)
        {
            dgvTaiKhoan.DataSource = LayDSTaiKhoan();
        }
        private DataTable LayDSTaiKhoan()
        {
            DataTable dt = ketNoi.LayDanhSach("LayDanhSachTaiKhoan");
            return dt;
        }

        private void dgvTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int dong = dgvTaiKhoan.CurrentCell.RowIndex;
            txtTaiKhoan.Text = dgvTaiKhoan.Rows[dong].Cells[0].Value.ToString();
            txtMatKhau.Text = dgvTaiKhoan.Rows[dong].Cells[1].Value.ToString();
            if (dgvTaiKhoan.Rows[dong].Cells[2].Value.ToString().Equals("admin"))
            {
                radioButtonAdmin.Checked = true;
            }
            else
            {
                radioButtonNhanVien.Checked = true;
            }
            usernamecu = dgvTaiKhoan.Rows[dong].Cells[0].Value.ToString();
            ktraNhan = true;
        }
        private void loadtxt()
        {
            txtTaiKhoan.Text = "";
            txtMatKhau.Text = "";
            radioButtonAdmin.Checked = false;
            radioButtonNhanVien.Checked = false;
        }
        private bool ktraTaiKhoanDK()
        {
            bool ktra = false;
            try
            {

                ketNoi.Connection.Open();

                // Tạo SqlCommand để thực hiện stored procedure LayKhachHang
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = ketNoi.Connection;
                cmd.CommandText = "KTraTaiKhoan";
                cmd.CommandType = CommandType.StoredProcedure;


                // Thêm parameter cho stored procedure
                cmd.Parameters.Add(new SqlParameter("@username", SqlDbType.Char, 10)).Value = txtTaiKhoan.Text;

                // Tạo SqlDataAdapter và DataTable để đổ dữ liệu
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                // Đổ dữ liệu từ SqlDataAdapter vào DataTable
                da.Fill(dt);

                // Kiểm tra xem có dữ liệu trả về hay không
                if (dt.Rows.Count > 0)
                {
                    ktra = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                ketNoi.Connection.Close();
            }
            return ktra;

        }
        private void ThemTaiKhoan()
        {
            try
            {

                ketNoi.Connection.Open();

                // Tạo SqlCommand để thực hiện stored procedure LayKhachHang
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = ketNoi.Connection;
                cmd.CommandText = "ThemTaiKhoan";
                cmd.CommandType = CommandType.StoredProcedure;


                // Thêm parameter cho stored procedure
                cmd.Parameters.Add(new SqlParameter("@username", SqlDbType.NVarChar, 30)).Value = txtTaiKhoan.Text;
                cmd.Parameters.Add(new SqlParameter("@pass", SqlDbType.NVarChar, 30)).Value = txtMatKhau.Text;
                if (radioButtonAdmin.Checked)
                {
                    cmd.Parameters.Add(new SqlParameter("@quyen", SqlDbType.NVarChar, 10)).Value = "admin";
                }
                else if (radioButtonNhanVien.Checked)
                {
                    cmd.Parameters.Add(new SqlParameter("@quyen", SqlDbType.NVarChar, 10)).Value = "Nhân viên";
                }
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm thành công", "Thông báo");
                loadtxt();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                ketNoi.Connection.Close();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if ((radioButtonAdmin.Checked || radioButtonNhanVien.Checked) && (txtTaiKhoan.Text.Length != 0 && txtMatKhau.Text.Length != 0))
            {
                if (ktraTaiKhoanDK() == true)
                {
                    MessageBox.Show("Tài khoản đã tồn tại", "Thông báo");
                }
                else
                {
                    ThemTaiKhoan();
                    dgvTaiKhoan.DataSource = LayDSTaiKhoan();
                }
            }
            else
            {
                MessageBox.Show("Chưa nhập dữ liệu", "Thông báo");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {   
            if((radioButtonAdmin.Checked || radioButtonNhanVien.Checked) && (txtTaiKhoan.Text.Length != 0 && txtMatKhau.Text.Length != 0)){
                if (ktraNhan == true)
                {
                    if (ktraTaiKhoanSua() == false)
                    {
                        SuaTaiKhoan();
                        dgvTaiKhoan.DataSource = LayDSTaiKhoan();
                    }
                    else
                    {
                        MessageBox.Show("Tài khoản đã tồn tại", "Thông báo");
                    }

                }
                else
                {
                    MessageBox.Show("Chưa chọn tài khoản", "Thông báo");
                }
            }
            else
            {
                MessageBox.Show("Chưa nhập dữ liệu", "Thông báo");
            }

        }
        private void SuaTaiKhoan()
        {
            try
            {

                ketNoi.Connection.Open();

                // Tạo SqlCommand để thực hiện stored procedure LayKhachHang
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = ketNoi.Connection;
                cmd.CommandText = "SuaTaiKhoan";
                cmd.CommandType = CommandType.StoredProcedure;


                // Thêm parameter cho stored procedure
                cmd.Parameters.Add(new SqlParameter("@username", SqlDbType.NVarChar, 30)).Value = txtTaiKhoan.Text;
                cmd.Parameters.Add(new SqlParameter("@pass", SqlDbType.NVarChar, 30)).Value = txtMatKhau.Text;
                if (radioButtonAdmin.Checked)
                {
                    cmd.Parameters.Add(new SqlParameter("@quyen", SqlDbType.NVarChar, 10)).Value = "admin";
                }
                else if (radioButtonNhanVien.Checked)
                {
                    cmd.Parameters.Add(new SqlParameter("@quyen", SqlDbType.NVarChar, 10)).Value = "Nhân viên";
                }
                cmd.Parameters.Add(new SqlParameter("@usernamecu", SqlDbType.NVarChar, 30)).Value = usernamecu;
                cmd.ExecuteNonQuery();
                
                loadtxt();
                ktraNhan = false;
                MessageBox.Show("Sửa thành công", "Thông báo");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                ketNoi.Connection.Close();
            }
        }
        private bool ktraTaiKhoanSua()
        {
            bool ktra = false;
            try
            {

                ketNoi.Connection.Open();

                // Tạo SqlCommand để thực hiện stored procedure LayKhachHang
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = ketNoi.Connection;
                cmd.CommandText = "KtraTaiKhoanSua";
                cmd.CommandType = CommandType.StoredProcedure;
                // Thêm parameter cho stored procedure
                cmd.Parameters.Add(new SqlParameter("@username", SqlDbType.NVarChar, 30)).Value = txtTaiKhoan.Text;
                cmd.Parameters.Add(new SqlParameter("@usernamecu", SqlDbType.NVarChar, 30)).Value = usernamecu;
                // Tạo SqlDataAdapter và DataTable để đổ dữ liệu
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    ktra = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                ketNoi.Connection.Close();
            }
            return ktra;

        }
        private void XoaTaiKhoan()
        {
            try
            {
                ketNoi.Connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = ketNoi.Connection;
                cmd.CommandText = "XoaTaiKhoan";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@username", SqlDbType.Char, 10)).Value = txtTaiKhoan.Text;
                cmd.ExecuteNonQuery();

                
                loadtxt();
                ktraNhan = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { ketNoi.Connection.Close(); }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(ktraNhan == true)
            {
                XoaTaiKhoan();
                MessageBox.Show("Xóa thành công", "Thông báo");
                dgvTaiKhoan.DataSource = LayDSTaiKhoan();
            }
            else
            {
                MessageBox.Show("Chưa chọn tài khoản", "Thông báo");
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            loadtxt();
            ktraNhan = false;
        }

        private void QuanLyTaiKhoan_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                e.Cancel = true; // Ngăn không cho form đóng
            }
        }
    }
}
