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
    public partial class QuanLyKhachHang : Form
    {
        public QuanLyKhachHang()
        {
            InitializeComponent();
            txtSDT.KeyPress += NumericTextBox_KeyPress;
        }
        ketNoiDB ketNoi = new ketNoiDB();
        private string sdtTam;
        private bool ktraNhan = false;
        private DataTable LayKhachHang()
        {
            DataTable dt = ketNoi.LayDanhSach("LayDSKhachHang");
            return dt;
        }
        private void NumericTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Kiểm tra xem ký tự nhập vào có phải là số hay không
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Nếu không phải là số, thì hủy bỏ sự kiện
            }
        }

        private void QuanLyKhachHang_Load(object sender, EventArgs e)
        {
            txtHoTen.Focus();
            dgvKhachHang.DataSource = LayKhachHang();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if((radioButtonNam.Checked || radioButtonNu.Checked) && (txtSDT.Text.Length != 0 && txtHoTen.Text.Length != 0))
            {
                if (ktraKhachHangDK() == true)
                {
                    MessageBox.Show("Khách hàng đã tồn tại", "Thông báo");
                }
                else
                {
                    ThemKhachHang();
                    dgvKhachHang.DataSource = LayKhachHang();
                }
            }
            else
            {
                MessageBox.Show("Chưa nhập dữ liệu", "Thông báo");
            }
            
        }
        private bool ktraKhachHangDK()
        {
            bool ktra = false;
            try
            {

                ketNoi.Connection.Open();

                // Tạo SqlCommand để thực hiện stored procedure LayKhachHang
                SqlCommand cmdKhachHang = new SqlCommand();
                cmdKhachHang.Connection = ketNoi.Connection;
                cmdKhachHang.CommandText = "KTraKhachHang";
                cmdKhachHang.CommandType = CommandType.StoredProcedure;


                // Thêm parameter cho stored procedure
                cmdKhachHang.Parameters.Add(new SqlParameter("@sdtKH", SqlDbType.Char, 10)).Value = txtSDT.Text;

                // Tạo SqlDataAdapter và DataTable để đổ dữ liệu
                SqlDataAdapter daKhachHang = new SqlDataAdapter(cmdKhachHang);
                DataTable dtKhachHang = new DataTable();

                // Đổ dữ liệu từ SqlDataAdapter vào DataTable
                daKhachHang.Fill(dtKhachHang);

                // Kiểm tra xem có dữ liệu trả về hay không
                if (dtKhachHang.Rows.Count > 0)
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
        private void ThemKhachHang()
        {
            try
            {

                ketNoi.Connection.Open();

                // Tạo SqlCommand để thực hiện stored procedure LayKhachHang
                SqlCommand cmdKhachHang = new SqlCommand();
                cmdKhachHang.Connection = ketNoi.Connection;
                cmdKhachHang.CommandText = "ThemKhachHang";
                cmdKhachHang.CommandType = CommandType.StoredProcedure;


                // Thêm parameter cho stored procedure
                cmdKhachHang.Parameters.Add(new SqlParameter("@TenKH", SqlDbType.NVarChar, 100)).Value = txtHoTen.Text;
                cmdKhachHang.Parameters.Add(new SqlParameter("@DateKH", SqlDbType.Date)).Value = dateTimeNgaySinh.Value;
                if (radioButtonNam.Checked)
                {
                    cmdKhachHang.Parameters.Add(new SqlParameter("@GenderKH", SqlDbType.NVarChar, 3)).Value = "Nam";
                }
                else if (radioButtonNu.Checked)
                {
                    cmdKhachHang.Parameters.Add(new SqlParameter("@GenderKH", SqlDbType.NVarChar, 3)).Value = "Nữ";
                }
                cmdKhachHang.Parameters.Add(new SqlParameter("@SdtKH", SqlDbType.Char, 10)).Value = txtSDT.Text;
                cmdKhachHang.Parameters.Add(new SqlParameter("@DiemTichLuy", SqlDbType.Int)).Value = 0;
                cmdKhachHang.ExecuteNonQuery();
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
        private void loadtxt()
        {
            txtHoTen.Text = "";
            txtSDT.Text = "";
            dateTimeNgaySinh.Text = DateTime.Now.ToString();
            radioButtonNam.Checked = false;
            radioButtonNu.Checked = false;
        }

       
        private void SuaKhachHang()
        {
            try
            {
                ketNoi.Connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = ketNoi.Connection;
                cmd.CommandText = "SuaKhachHang";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@TenKH", SqlDbType.NVarChar, 100)).Value = txtHoTen.Text;
                cmd.Parameters.Add(new SqlParameter("@DateKH", SqlDbType.Date)).Value = dateTimeNgaySinh.Value.Date;
                if(radioButtonNam.Checked )
                {
                    cmd.Parameters.Add(new SqlParameter("@GenderKH", SqlDbType.NVarChar, 3)).Value = radioButtonNam.Text;
                }
                else
                {
                    cmd.Parameters.Add(new SqlParameter("@GenderKH", SqlDbType.NVarChar, 3)).Value = radioButtonNu.Text;
                }    
                
                cmd.Parameters.Add(new SqlParameter("@SdtKH", SqlDbType.Char, 10)).Value = txtSDT.Text;
                cmd.Parameters.Add(new SqlParameter("@DiemTichLuy", SqlDbType.Int)).Value = numericUpDownDiemTL.Value;
                cmd.Parameters.Add(new SqlParameter("@SdtCu", SqlDbType.Char, 10)).Value = sdtTam;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Sửa thành công", "Thông báo");
                setNhap();
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { ketNoi.Connection.Close();}
        }
        private void setNhap()
        {
            txtHoTen.Text = "";
            txtSDT.Text = "";
            dateTimeNgaySinh.Value = DateTime.Now;
            radioButtonNam.Checked = false;
            radioButtonNu.Checked = false;
            numericUpDownDiemTL.Value = 0;
            ktraNhan = false;
        }
        private bool ktraKhachHangSua()
        {
            bool ktra = false;
            try
            {

                ketNoi.Connection.Open();

                // Tạo SqlCommand để thực hiện stored procedure LayKhachHang
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = ketNoi.Connection;
                cmd.CommandText = "KtraKhachHangSua";
                cmd.CommandType = CommandType.StoredProcedure;

                // Thêm parameter cho stored procedure
                cmd.Parameters.Add(new SqlParameter("@sdtKH", SqlDbType.Char, 10)).Value = txtSDT.Text;
                cmd.Parameters.Add(new SqlParameter("@sdtKHCu", SqlDbType.Char, 10)).Value = sdtTam;
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

        private void btnSua_Click(object sender, EventArgs e)
        {
            if((radioButtonNam.Checked || radioButtonNu.Checked) && (txtSDT.Text.Length != 0 && txtHoTen.Text.Length != 0))
            {                   
                    if (ktraNhan == true)
                    {
                        if (ktraKhachHangSua() == true)
                        {
                            MessageBox.Show("Khách hàng đã tồn tại", "Thông báo");
                        }
                        else
                        {
                            SuaKhachHang();
                            dgvKhachHang.DataSource = LayKhachHang();
                        }

                    }
                    else
                    {
                        MessageBox.Show("Chưa chọn khách hàng", "Thông báo");
                    }
            }
            else
            {
                MessageBox.Show("Chưa nhập dữ liệu", "Thông báo");
            }
            
            
        }
        private void XoaKhachHang()
        {
            try
            {
                ketNoi.Connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = ketNoi.Connection;
                cmd.CommandText = "XoaKhachHang";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@SdtKH", SqlDbType.Char, 10)).Value = txtSDT.Text;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Xóa thành công", "Thông báo");
                setNhap();
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
                XoaKhachHang();
                dgvKhachHang.DataSource = LayKhachHang();
            }
            else
            {
                MessageBox.Show("Chưa chọn khách hàng", "Thông báo");
            }    
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            setNhap();
        }

        private void QuanLyKhachHang_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            DialogResult result = MessageBox.Show("Bạn có muốn thoát không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                e.Cancel = true; // Ngăn không cho form đóng
            }
        }

        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            int dong = dgvKhachHang.CurrentCell.RowIndex;
            txtHoTen.Text = dgvKhachHang.Rows[dong].Cells[0].Value.ToString();
            string ngaySinhString = dgvKhachHang.Rows[dong].Cells[1].Value.ToString();
            // Thử chuyển đổi giá trị thành kiểu DateTime
            if (DateTime.TryParse(ngaySinhString, out DateTime ngaySinh))
            {
                // Nếu chuyển đổi thành công, gán giá trị cho NgayChieu
                dateTimeNgaySinh.Value = ngaySinh;
            }
            if (dgvKhachHang.Rows[dong].Cells[2].Value.ToString().Equals("Nam"))
            {
                radioButtonNam.Checked = true;
            }
            else
            {
                radioButtonNu.Checked = true;
            }
            txtSDT.Text = dgvKhachHang.Rows[dong].Cells[3].Value.ToString();
            int.TryParse(dgvKhachHang.Rows[dong].Cells[4].Value.ToString(), out int DiemTL);
            numericUpDownDiemTL.Value = DiemTL;
            sdtTam = txtSDT.Text;
            ktraNhan = true;
        }
    }
    
}
