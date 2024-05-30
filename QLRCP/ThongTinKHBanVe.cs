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
    public partial class ThongTinKHBanVe : Form
    {
        public ThongTinKHBanVe()
        {
            InitializeComponent();
            txtSDT.KeyPress += NumericTextBox_KeyPress;
        }
        ketNoiDB ketNoi = new ketNoiDB();
        private string TenKhachHang;
        private string SoDT;
        private int DiemTichLy;
        private bool _daXacNhan = false;

        public bool DaXacNhan
        {
            get { return _daXacNhan; }
            set { _daXacNhan = value; }
        }
        private void NumericTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Kiểm tra xem ký tự nhập vào có phải là số hay không
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Nếu không phải là số, thì hủy bỏ sự kiện
            }
        }

        public string TenKhachHang1 { get => TenKhachHang; set => TenKhachHang = value; }
        public string SoDT1 { get => SoDT; set => SoDT = value; }
        public int DiemTichLy1 { get => DiemTichLy; set => DiemTichLy = value; }

        public bool LayKhachHang()
        {
            bool ktra = false;
            try
            {
                
                ketNoi.Connection.Open();

                // Tạo SqlCommand để thực hiện stored procedure LayKhachHang
                SqlCommand cmdKhachHang = new SqlCommand();
                cmdKhachHang.Connection = ketNoi.Connection;
                cmdKhachHang.CommandText = "LayKhachHang";
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
                    // Đọc thông tin từ DataTable
                    TenKhachHang = dtKhachHang.Rows[0]["tenKH"].ToString();
                    SoDT = dtKhachHang.Rows[0]["sdtKH"].ToString();
                    DiemTichLy = int.Parse(dtKhachHang.Rows[0]["diemTichLuy"].ToString());

                    // Kiểm tra thông tin khách hàng
                    if (txtSDT.Text.Equals(dtKhachHang.Rows[0]["sdtKH"].ToString()) && txtHoTen.Text.Equals(dtKhachHang.Rows[0]["tenKH"].ToString()))
                    {
                        ktra = true;
                    }
                    /*else
                    {
                        MessageBox.Show("Khách hàng chưa tồn tại", "Thông báo");
                    }*/
                }
                else
                {
                    MessageBox.Show("Khách hàng chưa tồn tại", "Thông báo");
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

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if(txtHoTen.Text.Length != 0 && txtSDT.Text.Length != 0)
            {
                if (LayKhachHang() == true)
                {
                    DaXacNhan = true;
                    this.Close();
                }
            }
            
         
            
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            DangKiKhachHang dangKiKhachHang = new DangKiKhachHang();
            dangKiKhachHang.ShowDialog(this);
        }
    }
}
