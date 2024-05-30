using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLRCP
{
    public partial class TimKiem : Form
    {
        private SqlConnection conn;
        private SqlCommand cmdNhanVien;

        public TimKiem()
        {
            InitializeComponent();
            conn = new SqlConnection("Data Source=MSI;Initial Catalog=HeThongRapChieuPhim1;Integrated Security=True");

            cmdNhanVien = new SqlCommand();
            cmdNhanVien.Connection = conn;
        }

        private void btnTimKiemNV_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiemNV.Text.Trim();

            if (string.IsNullOrWhiteSpace(keyword))
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm.", "Thông báo");
                return;
            }

            try
            {
                conn.Open();
                cmdNhanVien = new SqlCommand();
                cmdNhanVien.Connection = conn;

                if (rdMaNV.Checked)
                {
                    cmdNhanVien.CommandText = "SELECT * FROM NhanVien WHERE MaNV LIKE @Keyword";
                    cmdNhanVien.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");
                }
                else if (rdTenNV.Checked)
                {
                    cmdNhanVien.CommandText = "SELECT * FROM NhanVien WHERE TenNV LIKE @Keyword";
                    cmdNhanVien.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");
                }
                else if (rdGender.Checked)
                {

                    cmdNhanVien.CommandText = "SELECT * FROM NhanVien WHERE GenderNV LIKE @Keyword";
                    cmdNhanVien.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");
                }
                else
                {
                    cmdNhanVien.CommandText = "SELECT * FROM NhanVien WHERE TenNV LIKE @Keyword";
                    cmdNhanVien.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");
                }

                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmdNhanVien);
                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    dataGridViewTimKiemNV.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy kết quả nào.", "Thông báo");
                    dataGridViewTimKiemNV.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo");
            }
            finally
            {
                conn.Close();
            }
        }


        private void rdNhanVien_CheckedChanged(object sender, EventArgs e)
        {
            if (rdMaNV.Checked)
            {

            }
        }

        private void rdTimGender_CheckedChanged(object sender, EventArgs e)
        {
            if (rdGender.Checked)
            {
                string keyword = txtTimKiemNV.Text.Trim();
                DataTable dt = TimGender(keyword);

                if (dt.Rows.Count > 0)
                {
                    dataGridViewTimKiemNV.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy kết quả nào.", "Thông báo");
                    dataGridViewTimKiemNV.DataSource = null;
                }
            }
        }

        private void rdTimMaNV_CheckedChanged(object sender, EventArgs e)
        {
            if (rdMaNV.Checked)
            {
                string keyword = txtTimKiemNV.Text.Trim();
                DataTable dt = TimMaNV(keyword);

                if (dt.Rows.Count > 0)
                {
                    dataGridViewTimKiemNV.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy kết quả nào.", "Thông báo");
                    dataGridViewTimKiemNV.DataSource = null;
                }
            }
        }

        private void rdTimTenNV_CheckedChanged(object sender, EventArgs e)
        {
            if (rdTenNV.Checked)
            {
                string keyword = txtTimKiemNV.Text.Trim();
                DataTable dt = TimTenNV(keyword);

                if (dt.Rows.Count > 0)
                {
                    dataGridViewTimKiemNV.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy kết quả nào.", "Thông báo");
                    dataGridViewTimKiemNV.DataSource = null;
                }
            }
        }

        private DataTable TimGender(string keyword)
{
    DataTable dt = new DataTable();

    try
    {
        conn.Open();
        cmdNhanVien.CommandText = "SELECT * FROM NhanVien WHERE GenderNV LIKE @Keyword";
        cmdNhanVien.Parameters.Clear();
        cmdNhanVien.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");

        SqlDataAdapter adapter = new SqlDataAdapter(cmdNhanVien);
        adapter.Fill(dt);
    }
    catch (Exception ex)
    {
        MessageBox.Show("Lỗi: " + ex.Message, "Thông báo");
    }
    finally
    {
        conn.Close();
    }

    return dt;
}


        private DataTable TimMaNV(string keyword)
        {
            DataTable dt = new DataTable();

            try
            {
                conn.Open();
                cmdNhanVien.CommandText = "SELECT * FROM NhanVien WHERE MaNV LIKE @Keyword";
                cmdNhanVien.Parameters.Clear();
                cmdNhanVien.Parameters.AddWithValue("@Keyword", keyword);  // Use the exact keyword for MaNV

                SqlDataAdapter adapter = new SqlDataAdapter(cmdNhanVien);
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo");
            }
            finally
            {
                conn.Close();
            }

            return dt;
        }



        private DataTable TimTenNV(string keyword)
        {
            DataTable dt = new DataTable();

            try
            {
                conn.Open();
                cmdNhanVien.CommandText = "SELECT * FROM NhanVien WHERE TenNV LIKE @Keyword";
                cmdNhanVien.Parameters.Clear();
                cmdNhanVien.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");

                SqlDataAdapter adapter = new SqlDataAdapter(cmdNhanVien);
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo");
            }
            finally
            {
                conn.Close();
            }

            return dt;
        }



        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát hay không?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
