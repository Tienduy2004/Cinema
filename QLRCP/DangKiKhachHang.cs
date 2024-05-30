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
    public partial class DangKiKhachHang : Form
    {
        public DangKiKhachHang()
        {
            InitializeComponent();
            txtSDT.KeyPress += NumericTextBox_KeyPress;
        }
        ketNoiDB ketNoi = new ketNoiDB();
        private void DangKiKhachHang_Load(object sender, EventArgs e)
        {
            
        }
        private void NumericTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Kiểm tra xem ký tự nhập vào có phải là số hay không
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Nếu không phải là số, thì hủy bỏ sự kiện
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
                cmdKhachHang.Parameters.Add(new SqlParameter("@DateKH", SqlDbType.Date)).Value = dateTimeNamSinh.Value;
                if (radioButtonNam.Checked)
                {
                    cmdKhachHang.Parameters.Add(new SqlParameter("@GenderKH", SqlDbType.NVarChar, 3)).Value = "Nam";
                }
                if (radioButtonNu.Checked)
                {
                    cmdKhachHang.Parameters.Add(new SqlParameter("@GenderKH", SqlDbType.NVarChar, 3)).Value = "Nữ";
                }
                cmdKhachHang.Parameters.Add(new SqlParameter("@SdtKH", SqlDbType.Char, 10)).Value = txtSDT.Text;
                cmdKhachHang.Parameters.Add(new SqlParameter("@DiemTichLuy",SqlDbType.Int) ).Value = 0;
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

        private void btnDangKy_Click(object sender, EventArgs e)
        {   
            if((radioButtonNam.Checked || radioButtonNu.Checked)&& (txtHoTen.Text.Length !=0 && txtSDT.Text.Length != 0))
            {
                if (ktraKhachHangDK() == true)
                {
                    MessageBox.Show("Khách hàng đã tồn tại", "Thông báo");
                }
                else
                {
                    ThemKhachHang();
                }
            }
            else
            {
                MessageBox.Show("Chưa nhập dữ liệu", "Thông báo");
            }
            
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void loadtxt()
        {
            txtHoTen.Text = "";
            txtSDT.Text = "";
            dateTimeNamSinh.Text = DateTime.Now.ToString();
            radioButtonNam.Checked = false;
            radioButtonNu.Checked = false;
        }
    }
}
