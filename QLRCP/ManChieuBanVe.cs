using QLRCP.BanVe;
using QLRCP.ClassTong;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace QLRCP
{
    public partial class ManChieuBanVe : Form
    {
        private LichChieu lichChieu = new LichChieu();
        private Button selectedButton = null;
        private bool ktraButton = false;
        private string maGhe;
        private double GiamTien = 0;
        private string sdtKH;
        private int diemCong;
        private int soVeDaBanTam;
        private float tongTienTam;
        public ManChieuBanVe(LichChieu lichChieu)
        {
            InitializeComponent();
            this.lichChieu = lichChieu;
        }
        
        ketNoiDB ketNoi = new ketNoiDB();

        private void checkBoxKH_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxKH.Checked == true)
            {
                ThongTinKHBanVe thongTinKHBanVe = new ThongTinKHBanVe();
                thongTinKHBanVe.ShowDialog();
                // Chỉ truy cập thông tin nếu đã xác nhận
                if (thongTinKHBanVe.DaXacNhan)
                {
                    // Truy cập thông tin khách hàng từ form ThongTinKHBanVe
                    string tenKhachHang = thongTinKHBanVe.TenKhachHang1;
                    sdtKH = thongTinKHBanVe.SoDT1;
                    String diemTL = thongTinKHBanVe.DiemTichLy1.ToString();

                    // Thực hiện các tác vụ khác dựa trên thông tin khách hàng
                    // Ví dụ: Hiển thị thông tin khách hàng ở textBox hoặc các controls khác.
                    txtTenKH.Text = tenKhachHang;
                    txtDiemTL.Text = diemTL;
                }

            }
            else
            {
                txtTenKH.Text = "";
            }
        }

        private void ManChieuBanVe_Load(object sender, EventArgs e)
        {
            txtTongTien.Text = "0";
            txtTienGiam.Text = "0";
            txtTienGiaVe.Text = "0";
            txtDiemTL.Text = "0";
            
            LayGhePhong();
            ktraGhe();
            TinhTien();
            
        }
        private string LayMaPhong()
        {
            string maPhong = "";
            try
            {
                ketNoi.Connection.Open();
                SqlCommand cmdGhe = new SqlCommand();
                cmdGhe.Connection = ketNoi.Connection;
                cmdGhe.CommandText = "LayLichChieuTuMa";
                cmdGhe.CommandType = CommandType.StoredProcedure;
                cmdGhe.Parameters.Add(new SqlParameter("@mashow", SqlDbType.NVarChar, 10)).Value = lichChieu.MaShow;
                SqlDataAdapter daGhe = new SqlDataAdapter(cmdGhe);
                DataTable dtGhe = new DataTable();
                daGhe.Fill(dtGhe);
                if (dtGhe.Rows.Count > 0)
                {
                    // Đọc thông tin từ DataTable
                    maPhong = dtGhe.Rows[0]["maPhong"].ToString();
                    
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
            return maPhong;
        }
        private void ktraGhe()
        {
            LichChieu lichChieu = LayLichChieu();
            Color hoverColor = Color.Gray;
            try
            {
                ketNoi.Connection.Open();
                SqlCommand cmdGhe = new SqlCommand();
                cmdGhe.Connection = ketNoi.Connection;
                cmdGhe.CommandText = "LayTrangThaiGhe";
                cmdGhe.CommandType = CommandType.StoredProcedure;
                cmdGhe.Parameters.Add(new SqlParameter("@mashow", SqlDbType.NVarChar, 10)).Value = lichChieu.MaShow;
                SqlDataAdapter daGhe = new SqlDataAdapter(cmdGhe);
                DataTable dtGhe = new DataTable();
                daGhe.Fill(dtGhe);
                if (dtGhe.Rows.Count > 0)
                {
                    
                    if (dtGhe.Rows[0]["trangthaiGhe"].ToString().Equals("Đã đặt")){
                        btn1.BackColor = hoverColor;
                        btn1.Enabled = false;
                    }
                    if (dtGhe.Rows[1]["trangthaiGhe"].ToString().Equals("Đã đặt"))
                    {
                        btn2.BackColor = hoverColor;
                        btn2.Enabled = false;
                    }
                    if (dtGhe.Rows[2]["trangthaiGhe"].ToString().Equals("Đã đặt"))
                    {
                        btn3.BackColor = hoverColor;
                        btn3.Enabled = false;
                    }
                    if (dtGhe.Rows[3]["trangthaiGhe"].ToString().Equals("Đã đặt"))
                    {
                        btn4.BackColor = hoverColor;
                        btn4.Enabled = false;
                    }
                    if (dtGhe.Rows[4]["trangthaiGhe"].ToString().Equals("Đã đặt"))
                    {
                        btn5.BackColor = hoverColor;
                        btn5.Enabled = false;
                    }
                    if (dtGhe.Rows[5]["trangthaiGhe"].ToString().Equals("Đã đặt"))
                    {
                        btn6.BackColor = hoverColor;
                        btn6.Enabled = false;
                    }
                    if (dtGhe.Rows[6]["trangthaiGhe"].ToString().Equals("Đã đặt"))
                    {
                        btn7.BackColor = hoverColor;
                        btn7.Enabled = false;
                    }
                    if (dtGhe.Rows[7]["trangthaiGhe"].ToString().Equals("Đã đặt"))
                    {
                        btn8.BackColor = hoverColor;
                        btn8.Enabled = false;
                    }
                    if (dtGhe.Rows[8]["trangthaiGhe"].ToString().Equals("Đã đặt"))
                    {
                        btn9.BackColor = hoverColor;
                        btn9.Enabled = false;
                    }
                    if (dtGhe.Rows[9]["trangthaiGhe"].ToString().Equals("Đã đặt"))
                    {
                        btn10.BackColor = hoverColor;
                        btn10.Enabled = false;
                    }
                    //
                    if (dtGhe.Rows[10]["trangthaiGhe"].ToString().Equals("Đã đặt"))
                    {
                        btn11.BackColor = hoverColor;
                        btn11.Enabled = false;
                    }
                    if (dtGhe.Rows[11]["trangthaiGhe"].ToString().Equals("Đã đặt"))
                    {
                        btn12.BackColor = hoverColor;
                        btn12.Enabled = false;
                    }
                    if (dtGhe.Rows[12]["trangthaiGhe"].ToString().Equals("Đã đặt"))
                    {
                        btn13.BackColor = hoverColor;
                        btn13.Enabled = false;
                    }
                    if (dtGhe.Rows[13]["trangthaiGhe"].ToString().Equals("Đã đặt"))
                    {
                        btn14.BackColor = hoverColor;
                        btn14.Enabled = false;
                    }
                    if (dtGhe.Rows[14]["trangthaiGhe"].ToString().Equals("Đã đặt"))
                    {
                        btn15.BackColor = hoverColor;
                        btn15.Enabled = false;
                    }
                    if (dtGhe.Rows[15]["trangthaiGhe"].ToString().Equals("Đã đặt"))
                    {
                        btn16.BackColor = hoverColor;
                        btn16.Enabled = false;
                    }
                    if (dtGhe.Rows[16]["trangthaiGhe"].ToString().Equals("Đã đặt"))
                    {
                        btn17.BackColor = hoverColor;
                        btn17.Enabled = false;
                    }
                    if (dtGhe.Rows[17]["trangthaiGhe"].ToString().Equals("Đã đặt"))
                    {
                        btn18.BackColor = hoverColor;
                        btn18.Enabled = false;
                    }
                    if (dtGhe.Rows[18]["trangthaiGhe"].ToString().Equals("Đã đặt"))
                    {
                        btn19.BackColor = hoverColor;
                        btn19.Enabled = false;
                    }
                    if (dtGhe.Rows[19]["trangthaiGhe"].ToString().Equals("Đã đặt"))
                    {
                        btn20.BackColor = hoverColor;
                        btn20.Enabled = false;
                    }
                    //
                    if (dtGhe.Rows[20]["trangthaiGhe"].ToString().Equals("Đã đặt"))
                    {
                        btn21.BackColor = hoverColor;
                        btn21.Enabled = false;
                    }
                    if (dtGhe.Rows[21]["trangthaiGhe"].ToString().Equals("Đã đặt"))
                    {
                        btn22.BackColor = hoverColor;
                        btn22.Enabled = false;
                    }
                    if (dtGhe.Rows[22]["trangthaiGhe"].ToString().Equals("Đã đặt"))
                    {
                        btn23.BackColor = hoverColor;
                        btn23.Enabled = false;
                    }
                    if (dtGhe.Rows[23]["trangthaiGhe"].ToString().Equals("Đã đặt"))
                    {
                        btn24.BackColor = hoverColor;
                        btn24.Enabled = false;
                    }
                    if (dtGhe.Rows[24]["trangthaiGhe"].ToString().Equals("Đã đặt"))
                    {
                        btn25.BackColor = hoverColor;
                        btn25.Enabled = false;
                    }
                    if (dtGhe.Rows[25]["trangthaiGhe"].ToString().Equals("Đã đặt"))
                    {
                        btn26.BackColor = hoverColor;
                        btn26.Enabled = false;
                    }
                    if (dtGhe.Rows[26]["trangthaiGhe"].ToString().Equals("Đã đặt"))
                    {
                        btn27.BackColor = hoverColor;
                        btn27.Enabled = false;
                    }
                    if (dtGhe.Rows[27]["trangthaiGhe"].ToString().Equals("Đã đặt"))
                    {
                        btn28.BackColor = hoverColor;
                        btn28.Enabled = false;
                    }
                    if (dtGhe.Rows[28]["trangthaiGhe"].ToString().Equals("Đã đặt"))
                    {
                        btn29.BackColor = hoverColor;
                        btn29.Enabled = false;
                    }
                    if (dtGhe.Rows[29]["trangthaiGhe"].ToString().Equals("Đã đặt"))
                    {
                        btn30.BackColor = hoverColor;
                        btn30.Enabled = false;
                    }
                    //
                    if (dtGhe.Rows[30]["trangthaiGhe"].ToString().Equals("Đã đặt"))
                    {
                        btn31.BackColor = hoverColor;
                        btn31.Enabled = false;
                    }
                    if (dtGhe.Rows[31]["trangthaiGhe"].ToString().Equals("Đã đặt"))
                    {
                        btn32.BackColor = hoverColor;
                        btn32.Enabled = false;
                    }
                    if (dtGhe.Rows[32]["trangthaiGhe"].ToString().Equals("Đã đặt"))
                    {
                        btn33.BackColor = hoverColor;
                        btn33.Enabled = false;
                    }
                    if (dtGhe.Rows[33]["trangthaiGhe"].ToString().Equals("Đã đặt"))
                    {
                        btn34.BackColor = hoverColor;
                        btn34.Enabled = false;
                    }
                    if (dtGhe.Rows[34]["trangthaiGhe"].ToString().Equals("Đã đặt"))
                    {
                        btn35.BackColor = hoverColor;
                        btn35.Enabled = false;
                    }
                    if (dtGhe.Rows[35]["trangthaiGhe"].ToString().Equals("Đã đặt"))
                    {
                        btn36.BackColor = hoverColor;
                        btn36.Enabled = false;
                    }
                    if (dtGhe.Rows[36]["trangthaiGhe"].ToString().Equals("Đã đặt"))
                    {
                        btn37.BackColor = hoverColor;
                        btn37.Enabled = false;
                    }
                    if (dtGhe.Rows[37]["trangthaiGhe"].ToString().Equals("Đã đặt"))
                    {
                        btn38.BackColor = hoverColor;
                        btn38.Enabled = false;
                    }
                    if (dtGhe.Rows[38]["trangthaiGhe"].ToString().Equals("Đã đặt"))
                    {
                        btn39.BackColor = hoverColor;
                        btn39.Enabled = false;
                    }
                    if (dtGhe.Rows[39]["trangthaiGhe"].ToString().Equals("Đã đặt"))
                    {
                        btn40.BackColor = hoverColor;
                        btn40.Enabled = false;
                    }
                    //
                    if (dtGhe.Rows[40]["trangthaiGhe"].ToString().Equals("Đã đặt"))
                    {
                        btn41.BackColor = hoverColor;
                        btn41.Enabled = false;
                    }
                    if (dtGhe.Rows[41]["trangthaiGhe"].ToString().Equals("Đã đặt"))
                    {
                        btn42.BackColor = hoverColor;
                        btn42.Enabled = false;
                    }
                    if (dtGhe.Rows[42]["trangthaiGhe"].ToString().Equals("Đã đặt"))
                    {
                        btn43.BackColor = hoverColor;
                        btn43.Enabled = false;
                    }
                    if (dtGhe.Rows[43]["trangthaiGhe"].ToString().Equals("Đã đặt"))
                    {
                        btn44.BackColor = hoverColor;
                        btn44.Enabled = false;
                    }
                    if (dtGhe.Rows[44]["trangthaiGhe"].ToString().Equals("Đã đặt"))
                    {
                        btn45.BackColor = hoverColor;
                        btn45.Enabled = false;
                    }
                    if (dtGhe.Rows[45]["trangthaiGhe"].ToString().Equals("Đã đặt"))
                    {
                        btn46.BackColor = hoverColor;
                        btn46.Enabled = false;
                    }
                    if (dtGhe.Rows[46]["trangthaiGhe"].ToString().Equals("Đã đặt"))
                    {
                        btn47.BackColor = hoverColor;
                        btn47.Enabled = false;
                    }
                    if (dtGhe.Rows[47]["trangthaiGhe"].ToString().Equals("Đã đặt"))
                    {
                        btn48.BackColor = hoverColor;
                        btn48.Enabled = false;
                    }
                    if (dtGhe.Rows[48]["trangthaiGhe"].ToString().Equals("Đã đặt"))
                    {
                        btn49.BackColor = hoverColor;
                        btn49.Enabled = false;
                    }
                    if (dtGhe.Rows[49]["trangthaiGhe"].ToString().Equals("Đã đặt"))
                    {
                        btn50.BackColor = hoverColor;
                        btn50.Enabled = false;
                    }

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
        private void LayGhePhong()
        {
            LichChieu lichChieu = LayLichChieu();
            string maPhong = LayMaPhong();
            try
            {
                ketNoi.Connection.Open();
                SqlCommand cmdGhe = new SqlCommand();
                cmdGhe.Connection = ketNoi.Connection;
                cmdGhe.CommandText = "LayGhePhong";
                cmdGhe.CommandType = CommandType.StoredProcedure;
                cmdGhe.Parameters.Add(new SqlParameter("@maphong", SqlDbType.NVarChar, 10)).Value = maPhong;
               
                SqlDataAdapter daGhe = new SqlDataAdapter(cmdGhe);
                DataTable dtGhe = new DataTable();
                daGhe.Fill(dtGhe);
                if(dtGhe.Rows.Count > 0)
                {
                    // 2 hàng đầu
                    btn1.Text = dtGhe.Rows[0]["tenGhe"].ToString();
                    btn2.Text = dtGhe.Rows[1]["tenGhe"].ToString();
                    btn3.Text = dtGhe.Rows[2]["tenGhe"].ToString();
                    btn4.Text = dtGhe.Rows[3]["tenGhe"].ToString();
                    btn5.Text = dtGhe.Rows[4]["tenGhe"].ToString();
                    btn6.Text = dtGhe.Rows[5]["tenGhe"].ToString();
                    btn7.Text = dtGhe.Rows[6]["tenGhe"].ToString();
                    btn8.Text = dtGhe.Rows[7]["tenGhe"].ToString();
                    btn9.Text = dtGhe.Rows[8]["tenGhe"].ToString();
                    btn10.Text = dtGhe.Rows[9]["tenGhe"].ToString();
                    //
                    btn11.Text = dtGhe.Rows[10]["tenGhe"].ToString();
                    btn12.Text = dtGhe.Rows[11]["tenGhe"].ToString();
                    btn13.Text = dtGhe.Rows[12]["tenGhe"].ToString();
                    btn14.Text = dtGhe.Rows[13]["tenGhe"].ToString();
                    btn15.Text = dtGhe.Rows[14]["tenGhe"].ToString();
                    btn16.Text = dtGhe.Rows[15]["tenGhe"].ToString();
                    btn17.Text = dtGhe.Rows[16]["tenGhe"].ToString();
                    btn18.Text = dtGhe.Rows[17]["tenGhe"].ToString();
                    btn19.Text = dtGhe.Rows[18]["tenGhe"].ToString();
                    btn20.Text = dtGhe.Rows[19]["tenGhe"].ToString();
                    //
                    btn21.Text = dtGhe.Rows[20]["tenGhe"].ToString();
                    btn22.Text = dtGhe.Rows[21]["tenGhe"].ToString();
                    btn23.Text = dtGhe.Rows[22]["tenGhe"].ToString();
                    btn24.Text = dtGhe.Rows[23]["tenGhe"].ToString();
                    btn25.Text = dtGhe.Rows[24]["tenGhe"].ToString();
                    btn26.Text = dtGhe.Rows[25]["tenGhe"].ToString();
                    btn27.Text = dtGhe.Rows[26]["tenGhe"].ToString();
                    btn28.Text = dtGhe.Rows[27]["tenGhe"].ToString();
                    btn29.Text = dtGhe.Rows[28]["tenGhe"].ToString();
                    btn30.Text = dtGhe.Rows[29]["tenGhe"].ToString();
                    //
                    btn31.Text = dtGhe.Rows[30]["tenGhe"].ToString();
                    btn32.Text = dtGhe.Rows[31]["tenGhe"].ToString();
                    btn33.Text = dtGhe.Rows[32]["tenGhe"].ToString();
                    btn34.Text = dtGhe.Rows[33]["tenGhe"].ToString();
                    btn35.Text = dtGhe.Rows[34]["tenGhe"].ToString();
                    btn36.Text = dtGhe.Rows[35]["tenGhe"].ToString();
                    btn37.Text = dtGhe.Rows[36]["tenGhe"].ToString();
                    btn38.Text = dtGhe.Rows[37]["tenGhe"].ToString();
                    btn39.Text = dtGhe.Rows[38]["tenGhe"].ToString();
                    btn40.Text = dtGhe.Rows[39]["tenGhe"].ToString();
                    //
                    btn41.Text = dtGhe.Rows[40]["tenGhe"].ToString();
                    btn42.Text = dtGhe.Rows[41]["tenGhe"].ToString();
                    btn43.Text = dtGhe.Rows[42]["tenGhe"].ToString();
                    btn44.Text = dtGhe.Rows[43]["tenGhe"].ToString();
                    btn45.Text = dtGhe.Rows[44]["tenGhe"].ToString();
                    btn46.Text = dtGhe.Rows[45]["tenGhe"].ToString();
                    btn47.Text = dtGhe.Rows[46]["tenGhe"].ToString();
                    btn48.Text = dtGhe.Rows[47]["tenGhe"].ToString();
                    btn49.Text = dtGhe.Rows[48]["tenGhe"].ToString();
                    btn50.Text = dtGhe.Rows[49]["tenGhe"].ToString();
                }
                else
                {
                    MessageBox.Show("Lỗi phòng chưa có ghế", "Thông báo");
                    this.Close();
                }    

            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi" + ex, "Thông báo");
            }
            finally
            {
                ketNoi.Connection.Close();
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;

            if (clickedButton != null)
            {
                // Nếu đã chọn rồi, đặt lại màu nền về màu trắng
                if (clickedButton == selectedButton)
                {
                    clickedButton.BackColor = Color.White;
                    selectedButton = null;
                    ktraButton = false;
                    maGhe = "";
                }
                else
                {
                    // Nếu chưa chọn, đặt màu nền của nút được chọn thành màu vàng
                    if (selectedButton != null)
                    {
                        selectedButton.BackColor = Color.White;
                    }

                    clickedButton.BackColor = Color.Yellow;
                    selectedButton = clickedButton;
                    ktraButton = true;
                    maGhe = clickedButton.Text;
                }
            }
        }
        private LichChieu LayLichChieu()
        {
            LichChieu lichChieu = new LichChieu();
            try
            {
                ketNoi.Connection.Open();
                SqlCommand cmdGhe = new SqlCommand();
                cmdGhe.Connection = ketNoi.Connection;
                cmdGhe.CommandText = "LayLichChieu";
                cmdGhe.CommandType = CommandType.StoredProcedure;
                cmdGhe.Parameters.Add(new SqlParameter("@mashow", SqlDbType.NVarChar, 10)).Value = this.lichChieu.MaShow;
                SqlDataAdapter daGhe = new SqlDataAdapter(cmdGhe);
                DataTable dtGhe = new DataTable();
                daGhe.Fill(dtGhe);
                if (dtGhe.Rows.Count > 0)
                {
                    //MessageBox.Show(dtGhe.Rows[0]["maShow"].ToString(), "Thông báo");
                    // Đọc thông tin từ DataTable
                    lichChieu.MaShow = dtGhe.Rows[0]["maShow"].ToString();
                    lichChieu.MaPhim = dtGhe.Rows[0]["maPhim"].ToString();
                    lichChieu.MaRap = dtGhe.Rows[0]["maRap"].ToString();
                    lichChieu.MaPhong = dtGhe.Rows[0]["maPhong"].ToString();
                    string ngayChieuString = dtGhe.Rows[0]["ngayChieu"].ToString();
                    // Thử chuyển đổi giá trị thành kiểu DateTime
                    if (DateTime.TryParse(ngayChieuString, out DateTime ngayChieu))
                    {
                        // Nếu chuyển đổi thành công, gán giá trị cho NgayChieu
                        lichChieu.NgayChieu = ngayChieu;
                    }
                    lichChieu.GioChieu = (TimeSpan)dtGhe.Rows[0]["gioChieu"];
                    string giaVe = dtGhe.Rows[0]["giaVe"].ToString();
                    lichChieu.GiaVe = float.Parse(giaVe);
                    int soVeDaBan = int.Parse(dtGhe.Rows[0]["soVeDaBan"].ToString());
                    float tongTien = float.Parse(dtGhe.Rows[0]["tongTien"].ToString());
                    lichChieu.SoVeDaBan = soVeDaBan;
                    lichChieu.TongTien = tongTien;
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
            return lichChieu;

        }
        private VeTam LayLichChieuChoVeTam()
        {
            VeTam veTam = new VeTam();
            try
            {
                ketNoi.Connection.Open();
                SqlCommand cmdGhe = new SqlCommand();
                cmdGhe.Connection = ketNoi.Connection;
                cmdGhe.CommandText = "LayLichChieuChoVeTam";
                cmdGhe.CommandType = CommandType.StoredProcedure;
                cmdGhe.Parameters.Add(new SqlParameter("@mashow", SqlDbType.NVarChar, 10)).Value = this.lichChieu.MaShow;
                SqlDataAdapter daGhe = new SqlDataAdapter(cmdGhe);
                DataTable dtGhe = new DataTable();
                daGhe.Fill(dtGhe);
                if (dtGhe.Rows.Count > 0)
                {
                    //MessageBox.Show(dtGhe.Rows[0]["maShow"].ToString(), "Thông báo");
                    // Đọc thông tin từ DataTable
                    veTam.TenPhim = dtGhe.Rows[0]["tenPhim"].ToString();
                    veTam.TenPhong = dtGhe.Rows[0]["tenPhong"].ToString();
                    string ngayChieuString = dtGhe.Rows[0]["ngayChieu"].ToString();
                    // Thử chuyển đổi giá trị thành kiểu DateTime
                    if (DateTime.TryParse(ngayChieuString, out DateTime ngayChieu))
                    {
                        // Nếu chuyển đổi thành công, gán giá trị cho NgayChieu
                        veTam.NgayChieu = ngayChieu;
                    }
                    veTam.GioChieu = (TimeSpan)dtGhe.Rows[0]["gioChieu"];
                    string giaVe = dtGhe.Rows[0]["giaVe"].ToString();
                    veTam.GiaVe = float.Parse(giaVe);
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
            return veTam;

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            LichChieu lichChieu = LayLichChieu();
            VeTam veTam = LayLichChieuChoVeTam();
            if(ktraButton == true) {
                if(radioNguoiLon.Checked == true)
                {
                    dgvVe.Rows.Add(veTam.TenPhong, maGhe, veTam.TenPhim, "Người lớn",veTam.NgayChieu.ToString(), veTam.GiaVe, veTam.GioChieu.ToString("hh':'mm"));
                    TinhTien();
                    diemCong += 1;
                    soVeDaBanTam += 1;
                    if (selectedButton != null)
                    {
                        selectedButton.BackColor = Color.Gray;
                        selectedButton.Enabled = false;
                    }
                    selectedButton = null;
                    ktraButton = false;
                }
                else if(radioTreEm.Checked == true)
                {
                    dgvVe.Rows.Add(veTam.TenPhong, maGhe, veTam.TenPhim, "Trẻ em", veTam.NgayChieu.ToString(), veTam.GiaVe, veTam.GioChieu.ToString("hh':'mm"));
                    TinhTien();
                    diemCong += 1;
                    soVeDaBanTam += 1;
                    if (selectedButton != null)
                    {
                        selectedButton.BackColor = Color.Gray;
                        selectedButton.Enabled = false;
                    }
                    selectedButton = null;
                    ktraButton = false;
                }
                else
                {
                    MessageBox.Show("Chưa chọn loại vé", "Thông báo");
                }    
                

            }
            numericUpDownDiemCong.Value = diemCong;
        }
        private void TinhTien()
        {
            LichChieu lichChieu = LayLichChieu();
            if (dgvVe.Rows.Count > 1)
            {
                double TienVe = lichChieu.GiaVe * (dgvVe.Rows.Count - 1);
                txtTienGiaVe.Text = TienVe.ToString();
                if (radioTreEm.Checked == true)
                {
                    this.GiamTien += (lichChieu.GiaVe * 0.05);  
                    txtTienGiam.Text =this.GiamTien.ToString();   
                }
                

            }
            else
            {
                txtTienGiam.Text = "0";
                txtTienGiaVe.Text = "0";
                txtTongTien.Text = "0";
            }
            double TongTien = double.Parse(txtTienGiaVe.Text) - double.Parse(txtTienGiam.Text);
            txtTongTien.Text = TongTien.ToString();
             
            
        }

        private void radioTreEm_CheckedChanged(object sender, EventArgs e)
        {
            if (radioTreEm.Checked)
            {
                radioTreEm.Checked = true;
            }
            if (radioNguoiLon.Checked)
            {
                radioNguoiLon.Checked = true;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvVe.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa mục này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    int rowIndex = dgvVe.SelectedRows[0].Index;

                    // Lấy thông tin Mã Ghế từ cột "MaGhe" của dòng bị xóa
                    string maGhe = dgvVe.Rows[rowIndex].Cells["maGheVe"].Value.ToString();
                    string loaive = dgvVe.Rows[rowIndex].Cells["loaiVe"].Value.ToString();
                    // Gọi lại hàm tính tiền sau khi xóa
                    LichChieu lichChieu = LayLichChieu();
                    if (loaive.Equals("Trẻ em"))
                    {;
                        this.GiamTien -= 5000;
                        txtTienGiam.Text = this.GiamTien.ToString();
                    }

                    // Xóa hàng từ DataGridView
                    dgvVe.Rows.RemoveAt(rowIndex);
                    
                    if (dgvVe.Rows.Count > 1)
                    {
                        double TienVe = lichChieu.GiaVe * (dgvVe.Rows.Count - 1);
                        txtTienGiaVe.Text = TienVe.ToString();
                        
                    }
                    else
                    {
                        txtTienGiam.Text = "0";
                        txtTienGiaVe.Text = "0";
                        txtTongTien.Text = "0";
                    }
                    double TongTien = double.Parse(txtTienGiaVe.Text) - double.Parse(txtTienGiam.Text);
                    txtTongTien.Text = TongTien.ToString();
                    // Khôi phục trạng thái của nút ghế tương ứng
                    KhoiPhucTrangThaiNutGheTheoText(maGhe);
                    diemCong -= 1;
                    soVeDaBanTam -= 1;
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            numericUpDownDiemCong.Value = diemCong;
        }
        private void KhoiPhucTrangThaiNutGheTheoText(string text)
        {
            // Tìm control có thuộc tính Text là text trong Controls của form
            Button nutGhe = this.Controls.OfType<Button>().FirstOrDefault(btn => btn.Text == text);

            if (nutGhe != null)
            {
                // Cập nhật trạng thái của nút ghế tương ứng ở đây
                nutGhe.BackColor = Color.White;
                nutGhe.Enabled = true;
            }
            else
            {
                MessageBox.Show("Không tìm thấy nút ghế tương ứng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSuDung_Click(object sender, EventArgs e)
        {
            
            int giamTienDiem = int.Parse(txtDiemTL.Text);
            if(giamTienDiem > 0)
            {
                this.GiamTien += giamTienDiem * 1000;
                txtDiemTL.Text = "0";
                txtTienGiam.Text = this.GiamTien.ToString();
                LichChieu lichChieu = LayLichChieu();
                if (dgvVe.Rows.Count > 1)
                {
                    double TienVe = lichChieu.GiaVe * (dgvVe.Rows.Count - 1);
                    txtTienGiaVe.Text = TienVe.ToString();

                }
                else
                {
                    txtTienGiam.Text = "0";
                    txtTienGiaVe.Text = "0";
                    txtTongTien.Text = "0";
                }
                double TongTien = double.Parse(txtTienGiaVe.Text) - double.Parse(txtTienGiam.Text);
                txtTongTien.Text = TongTien.ToString();

            }
            else
            {
                MessageBox.Show("Không có điểm", "Thông báo");
            } 
            
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            LichChieu lichChieu = LayLichChieu();
            soVeDaBanTam += lichChieu.SoVeDaBan;
            tongTienTam = float.Parse(txtTongTien.Text) + lichChieu.TongTien;

            if(dgvVe.Rows.Count > 1)
            {
                ThemVeTam();
                if(checkBoxKH.Checked == true)
                {
                    ThemDiemCongChoKH();
                }    
                CapNhatLichChieu(lichChieu.MaShow,soVeDaBanTam, tongTienTam);
                HoaDonBanVe hoaDonBanVe = new HoaDonBanVe(txtTongTien.Text);
                this.Close();
                hoaDonBanVe.ShowDialog();
            }
            else
            {
                MessageBox.Show("Chưa chọn ghế", "Thông báo");
            }
            
           
        }
        private void ThemVeTam()
        {
            LichChieu lichChieu = LayLichChieu();
            try
            {
                foreach(DataGridViewRow row in dgvVe.Rows)
                {
                    if(!row.IsNewRow)
                    {
                        string tenPhong = row.Cells[0].Value.ToString();
                        string tenGhe = row.Cells[1].Value.ToString();
                        string tenphim = row.Cells[2].Value.ToString();
                        string loaiVe = row.Cells[3].Value.ToString();
                        DateTime ngayChieu;
                        if (DateTime.TryParse(row.Cells[4].Value.ToString(), out ngayChieu))
                        {

                        }
                        else
                        {
                            // Xử lý trường hợp không chuyển đổi được
                            Console.WriteLine("Không thể chuyển đổi chuỗi thành TimeSpan.");
                        }
                        float giaVe = float.Parse(row.Cells[5].Value.ToString());
                        TimeSpan suatChieu;
                        if (TimeSpan.TryParse(row.Cells[6].Value.ToString(), out suatChieu))
                        {
                            
                        }
                        else
                        {
                            // Xử lý trường hợp không chuyển đổi được
                            Console.WriteLine("Không thể chuyển đổi chuỗi thành TimeSpan.");
                        }
                        LuuVeTam(tenPhong,tenGhe, tenphim,loaiVe,ngayChieu,giaVe,suatChieu);
                        int maGheVe = int.Parse(LayMaghe(tenGhe, lichChieu.MaPhong));
                        LuuVe(lichChieu.MaPhong, maGheVe, lichChieu.MaShow, loaiVe, giaVe, suatChieu);
                        CapNhatGhe(maGheVe, lichChieu.MaShow);
                    }
                }
            }catch (Exception ex)
            {
                MessageBox.Show("Lỗi" + ex, "Thông báo");
            }
            finally
            {

            }
        }
        private void LuuVeTam(string maPhong,string maGhe,string maShow,string loaiVe,DateTime ngayChieu,float giaVe,TimeSpan suatChieu)
        {
            try
            {

                ketNoi.Connection.Open();

                // Tạo SqlCommand để thực hiện stored procedure LayKhachHang
                SqlCommand cmdKhachHang = new SqlCommand();
                cmdKhachHang.Connection = ketNoi.Connection;
                cmdKhachHang.CommandText = "LuuVeTam";
                cmdKhachHang.CommandType = CommandType.StoredProcedure;


                // Thêm parameter cho stored procedure
                cmdKhachHang.Parameters.Add(new SqlParameter("@tenphong", SqlDbType.NVarChar, 100)).Value = maPhong;
                cmdKhachHang.Parameters.Add(new SqlParameter("@tenghe", SqlDbType.NVarChar, 10)).Value = maGhe;
                cmdKhachHang.Parameters.Add(new SqlParameter("@tenphim", SqlDbType.NVarChar, 100)).Value = maShow;
                cmdKhachHang.Parameters.Add(new SqlParameter("@loaive", SqlDbType.NVarChar, 20)).Value = loaiVe;
                cmdKhachHang.Parameters.Add(new SqlParameter("@ngaychieu", SqlDbType.Date)).Value = ngayChieu;
                cmdKhachHang.Parameters.Add(new SqlParameter("@giave", SqlDbType.Float)).Value = giaVe;
                cmdKhachHang.Parameters.Add(new SqlParameter("@suatchieu", SqlDbType.Time)).Value = suatChieu;
                cmdKhachHang.ExecuteNonQuery();

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
        private string LayMaghe(string tenghe,string maPhong)
        {
            string maGhe = "";
            try
            {
                ketNoi.Connection.Open();
                SqlCommand cmdMaGhe = new SqlCommand();
                cmdMaGhe.Connection = ketNoi.Connection;
                cmdMaGhe.CommandText = "LayMaGhe";
                cmdMaGhe.CommandType = CommandType.StoredProcedure;
                cmdMaGhe.Parameters.Add(new SqlParameter("@tenghe", SqlDbType.NVarChar,10)).Value = tenghe;
                cmdMaGhe.Parameters.Add(new SqlParameter("@maphong", SqlDbType.NVarChar, 10)).Value = maPhong;
                SqlDataAdapter daGhe = new SqlDataAdapter(cmdMaGhe);
                DataTable dt = new DataTable();
                daGhe.Fill(dt);
                if(dt.Rows.Count > 0 )
                {
                    maGhe = dt.Rows[0]["maGhe"].ToString();
                }    
                
            }catch (Exception ex)
            {
                MessageBox.Show("Lỗi" + ex, "Thông báo");
            }
            finally { ketNoi.Connection.Close();}
            return maGhe;
        }
        private void LuuVe(string maPhong, int maGhe, string maShow, string loaiVe, float giaVe, TimeSpan suatChieu)
        {
            try
            {

                ketNoi.Connection.Open();

                // Tạo SqlCommand để thực hiện stored procedure LayKhachHang
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = ketNoi.Connection;
                cmd.CommandText = "LuuVe";
                cmd.CommandType = CommandType.StoredProcedure;


                // Thêm parameter cho stored procedure
                cmd.Parameters.Add(new SqlParameter("@maphong", SqlDbType.NVarChar, 10)).Value = maPhong;
                cmd.Parameters.Add(new SqlParameter("@maghe", SqlDbType.Int)).Value = maGhe;
                cmd.Parameters.Add(new SqlParameter("@mashow", SqlDbType.NVarChar, 10)).Value = maShow;
                cmd.Parameters.Add(new SqlParameter("@loaive", SqlDbType.NVarChar, 20)).Value = loaiVe;
                cmd.Parameters.Add(new SqlParameter("@giave", SqlDbType.Float)).Value = giaVe;
                cmd.Parameters.Add(new SqlParameter("@suatchieu", SqlDbType.Time)).Value = suatChieu;
                cmd.ExecuteNonQuery();

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
        private void CapNhatGhe(int maGhe,string maShow)
        {
            
            try
            {
                ketNoi.Connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = ketNoi.Connection;
                cmd.CommandText = "CapNhatGhe";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@maghe", SqlDbType.Int)).Value = maGhe;
                cmd.Parameters.Add(new SqlParameter("@mashow", SqlDbType.NVarChar)).Value = maShow;
                cmd.Parameters.Add(new SqlParameter("@trangthaighe", SqlDbType.NVarChar, 10)).Value = "Đã đặt";
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }finally { ketNoi.Connection.Close();}
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ThemDiemCongChoKH()
        {
            try
            {
                ketNoi.Connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection= ketNoi.Connection;
                cmd.CommandText = "CapNhatDiemChoKH";
                cmd.CommandType= CommandType.StoredProcedure;
                int DiemTL = int.Parse(txtDiemTL.Text);
                cmd.Parameters.Add(new SqlParameter("@diemtichluy", SqlDbType.Int)).Value = numericUpDownDiemCong.Value + DiemTL;
                cmd.Parameters.Add(new SqlParameter("@sdt", SqlDbType.Char, 10)).Value = sdtKH;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }finally
            { ketNoi.Connection.Close();}
        }
        private void CapNhatLichChieu(string maShow,int soVeDaBan,float tongTien)
        {
            try
            {
                ketNoi.Connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = ketNoi.Connection;
                cmd.CommandText = "CapNhatVeChoLichChieu";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@sovedaban", SqlDbType.Int)).Value = soVeDaBan;
                cmd.Parameters.Add(new SqlParameter("@mashow", SqlDbType.NVarChar, 10)).Value = maShow;
                cmd.Parameters.Add(new SqlParameter("@tongtien", SqlDbType.Float)).Value = tongTien;
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { ketNoi.Connection.Close(); }
        }

    }
    
}
