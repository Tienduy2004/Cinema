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

namespace QLRCP
{
    public partial class QuanLyLichChieu : Form
    {
        public QuanLyLichChieu()
        {
            InitializeComponent();
            txtGiaVe.KeyPress += FloatTextBox_KeyPress;
        }
        private string maShowTam;
        ketNoiDB ketNoi = new ketNoiDB();
        private string maRap;
        private bool ktraNhan = false;

        private void btnThem_Click(object sender, EventArgs e)
        {
            if(txtGiaVe.Text.Length != 0 && txtMaShow.Text.Length != 0)
            {
                bool ktra = false;
                if (KtraLichChieu(ktra) == false)
                {
                    ThemLichChieu();
                    DataTable dt = LayDanhSachMaGhe();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        int maGhe = int.Parse(dt.Rows[i]["maGhe"].ToString());
                        ThemTrangThaiGhe(maGhe);
                    }
                    MessageBox.Show("Thêm thành Công", "Thông báo");
                }
                else
                {
                    MessageBox.Show("Thêm Không thành Công", "Thông báo");
                }
                dgvLichChieu.DataSource = LayDanhSachLichChieu();
            }
            else
            {
                MessageBox.Show("Chưa nhập dữ liêu", "Thông báo");
            }
            


        }

        private void QuanLyLichChieu_Load(object sender, EventArgs e)
        {
            CapNhatTrangThaiChieu();
            
            dgvLichChieu.DataSource = LayDanhSachLichChieu();
            LayDanhSachRap();
            LayDanhSachPhim();
            LayDanhSachPhong();
            
        }
        private void FloatTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Kiểm tra xem ký tự nhập vào có phải là số hoặc dấu chấm thập phân hay không
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.') && (e.KeyChar != '-'))
            {
                e.Handled = true; // Nếu không phải là số hoặc dấu chấm thập phân, thì hủy bỏ sự kiện
            }

            // Nếu đã có dấu chấm thập phân và người dùng nhập thêm dấu chấm, thì hủy bỏ sự kiện
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }

            // Nếu đã có dấu trừ và người dùng nhập thêm dấu trừ, thì hủy bỏ sự kiện
            if ((e.KeyChar == '-') && ((sender as TextBox).Text.IndexOf('-') > -1))
            {
                e.Handled = true;
            }
        }
        public DataTable LayDanhSachLichChieu()
        {
            DataTable dt = new DataTable();
            try
            {
                ketNoi.Connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "LayDanhSachLichChieu";
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
        private void LayDanhSachPhim()
        {
            cmbMaPhim.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMaPhim.DataSource = ketNoi.LayDanhSach("LayDSPhim");
            cmbMaPhim.DisplayMember = "tenPhim";
            cmbMaPhim.ValueMember = "maPhim";
            cmbMaPhim.SelectedIndex = 0;
        }
        private void LayDanhSachRap()
        {
            cmbMaRap.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMaRap.DataSource = ketNoi.LayDanhSach("LayDanhSachRap");
            cmbMaRap.DisplayMember = "tenRap";
            cmbMaRap.ValueMember = "maRap";
            cmbMaRap.SelectedIndex = 0;
        }
        private void LayDanhSachPhong()
        {
            cmbMaPhong.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMaPhong.DataSource = DanhSachPhongTheoRap(cmbMaRap.SelectedValue.ToString());
            cmbMaPhong.DisplayMember = "tenPhong";
            cmbMaPhong.ValueMember = "maPhong";
            //cmbMaPhong.SelectedIndex = 0;
        }
        private DataTable LayDanhSachMaGhe()
        {
            DataTable dt = new DataTable();
            try
            {
                ketNoi.Connection.Open();

                // Tạo SqlCommand để thực hiện stored procedure LayKhachHang
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = ketNoi.Connection;
                cmd.CommandText = "LayDanhSachMaGhe";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@maphong", SqlDbType.NVarChar, 10)).Value = cmbMaPhong.SelectedValue;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                
                da.Fill(dt);
                if(dt.Rows.Count > 0)
                {
                   
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
            return dt;
        }
        private void ThemTrangThaiGhe(int maGhe)
        {
            try
            {

                ketNoi.Connection.Open();
                // Tạo SqlCommand để thực hiện stored procedure LayKhachHang
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = ketNoi.Connection;
                cmd.CommandText = "ThemTrangThaiGhe";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@maghe", SqlDbType.Int)).Value = maGhe;
                cmd.Parameters.Add(new SqlParameter("@mashow", SqlDbType.NVarChar, 10)).Value = maShowTam;
                cmd.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { ketNoi.Connection.Close();}
            
        }
        private void ThemLichChieu()
        {
            try
            {

                ketNoi.Connection.Open();

                // Tạo SqlCommand để thực hiện stored procedure LayKhachHang
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = ketNoi.Connection;
                cmd.CommandText = "ThemLichChieu";
                cmd.CommandType = CommandType.StoredProcedure;

                DateTime ngayChieu = dateTimeNgayChieu.Value.Date;
                // Thêm parameter cho stored procedure
                cmd.Parameters.Add(new SqlParameter("@mashow", SqlDbType.NVarChar, 10)).Value = txtMaShow.Text;
                cmd.Parameters.Add(new SqlParameter("@maphim", SqlDbType.NVarChar, 10)).Value = cmbMaPhim.SelectedValue;
                cmd.Parameters.Add(new SqlParameter("@marap", SqlDbType.NVarChar, 10)).Value = cmbMaRap.SelectedValue;
                cmd.Parameters.Add(new SqlParameter("@maphong", SqlDbType.NVarChar, 10)).Value = cmbMaPhong.SelectedValue;
                cmd.Parameters.Add(new SqlParameter("@ngaychieu", SqlDbType.Date)).Value = dateTimeNgayChieu.Value.Date;
                cmd.Parameters.Add(new SqlParameter("@giochieu", SqlDbType.Time)).Value = dateTimeGioChieu.Value.TimeOfDay;
                cmd.Parameters.Add(new SqlParameter("@giave", SqlDbType.Float)).Value = txtGiaVe.Text;
                cmd.ExecuteNonQuery();
                maShowTam = txtMaShow.Text;

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
        private bool KtraLichChieu(bool ktra)
        {
            try
            {

                ketNoi.Connection.Open();
                // Tạo SqlCommand để thực hiện stored procedure LayKhachHang
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = ketNoi.Connection;
                cmd.CommandText = "KtraLichChieu";
                cmd.CommandType = CommandType.StoredProcedure;
                DateTime ngayChieu = dateTimeNgayChieu.Value.Date;
                // Thêm parameter cho stored procedure
                cmd.Parameters.Add(new SqlParameter("@maphong", SqlDbType.NVarChar, 10)).Value = cmbMaPhong.SelectedValue;
                cmd.Parameters.Add(new SqlParameter("@ngaychieu", SqlDbType.Date)).Value = ngayChieu;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    TimeSpan khoangThoiGian = new TimeSpan(3, 0, 0);
                    TimeSpan gioChieuMoi = dateTimeGioChieu.Value.TimeOfDay;
                    int ktraTest = 0;

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        TimeSpan gioChieuCu = (TimeSpan)dt.Rows[i]["gioChieu"];
                        TimeSpan gioKtraMin = gioChieuCu - khoangThoiGian;
                        TimeSpan gioKtraMax = gioChieuCu + khoangThoiGian;

                        if ((gioChieuMoi < gioChieuCu && gioChieuMoi + khoangThoiGian > gioChieuCu) ||
                            (gioChieuCu < gioChieuMoi && gioChieuCu + khoangThoiGian > gioChieuMoi))
                        {
                            ktraTest++;
                        }
                        if(gioChieuMoi == gioChieuCu)
                        {
                            ktraTest++;
                        }
                    }

                    if (ktraTest > 0)
                    {
                        MessageBox.Show("Lỗi: Thời gian lịch chiếu\n Lịch chiếu phải cách nhau 3h", "Thông báo");
                        ktra = true;
                    }
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
        private void CapNhatTrangThaiChieu()
        {
            DateTime now = DateTime.Now;
            DataTable dt = LayDanhSachLichChieu();
            if(dt.Rows.Count > 0)
            {
                for(int i = 0; i < dt.Rows.Count; i++)
                {
                    DateTime dateTimeLichChieu = DateTime.Parse(dt.Rows[i]["ngayChieu"].ToString());
                    dateTimeLichChieu = dateTimeLichChieu.AddDays(1);
                    if (dateTimeLichChieu < now)
                    {
                        CapNhatTrangThai(dt.Rows[i]["maShow"].ToString());
                    }
                }    
            }
        }
        private void CapNhatTrangThai(string maShow)
        {
            try
            {

                ketNoi.Connection.Open();
                // Tạo SqlCommand để thực hiện stored procedure LayKhachHang
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = ketNoi.Connection;
                cmd.CommandText = "CapNhatTrangThaiChieu";
                cmd.CommandType = CommandType.StoredProcedure;
                DateTime ngayChieu = dateTimeNgayChieu.Value.Date;
                // Thêm parameter cho stored procedure
                cmd.Parameters.Add(new SqlParameter("@mashow", SqlDbType.NVarChar, 10)).Value = maShow;
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
        private DataTable DanhSachPhongTheoRap(string maRap)
        {
            DataTable dt = new DataTable();
            try
            {
                ketNoi.Connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = ketNoi.Connection;
                cmd.CommandText = "LayDanhSachPhong";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@marap", SqlDbType.NVarChar, 10)).Value = maRap;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }catch(Exception ex)
            {
                MessageBox.Show("Lỗi"+ex,"Thông báo");
            }finally { ketNoi.Connection.Close();}
            return dt;
        }

        private void cmbMaRap_SelectedIndexChanged(object sender, EventArgs e)
        {
            ktraNhan = true;
            maRap = cmbMaRap.SelectedItem.ToString();
            DanhSachPhongTheoRap(maRap);
            LayDanhSachPhong();
        }

        private void SuaLichChieu()
        {
    
            try
            {
                ketNoi.Connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = ketNoi.Connection;
                cmd.CommandText = "SuaLichChieu";
                cmd.CommandType = CommandType.StoredProcedure;
                DateTime ngayChieu = dateTimeNgayChieu.Value.Date;
                // Thêm parameter cho stored procedure
                cmd.Parameters.Add(new SqlParameter("@mashow", SqlDbType.NVarChar, 10)).Value = txtMaShow.Text;
                cmd.Parameters.Add(new SqlParameter("@maphim", SqlDbType.NVarChar, 10)).Value = cmbMaPhim.SelectedValue;
                cmd.Parameters.Add(new SqlParameter("@marap", SqlDbType.NVarChar, 10)).Value = cmbMaRap.SelectedValue;
                cmd.Parameters.Add(new SqlParameter("@maphong", SqlDbType.NVarChar, 10)).Value = cmbMaPhong.SelectedValue;
                cmd.Parameters.Add(new SqlParameter("@ngaychieu", SqlDbType.Date)).Value = dateTimeNgayChieu.Value.Date;
                cmd.Parameters.Add(new SqlParameter("@giochieu", SqlDbType.Time)).Value = dateTimeGioChieu.Value.TimeOfDay;
                cmd.Parameters.Add(new SqlParameter("@giave", SqlDbType.Float)).Value = txtGiaVe.Text;
                cmd.ExecuteNonQuery();
                maShowTam = txtMaShow.Text;
                
            }
            catch(Exception ex) {
                MessageBox.Show("Lỗi" + ex, "Thông báo");
            }finally {
                ketNoi.Connection.Close();
            }
            
            
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if(txtGiaVe.Text.Length != 0 && txtMaShow.Text.Length != 0)
            {
                if (ktraNhan == true)
                {
                    if (txtGiaVe.Text.Length != 0)
                    {
                        bool ktra = false;
                        if (KtraLichChieuSua(ktra) == false)
                        {
                            SuaLichChieu();
                            XoaTrangThaiGhe();
                            DataTable dt = LayDanhSachMaGhe();
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                int maGhe = int.Parse(dt.Rows[i]["maGhe"].ToString());
                                ThemTrangThaiGhe(maGhe);
                            }
                            MessageBox.Show("Sửa thành Công", "Thông báo");
                            setNhap();
                        }
                        else
                        {
                            MessageBox.Show("Sửa Không thành Công", "Thông báo");
                            setNhap();
                        }
                        dgvLichChieu.DataSource = LayDanhSachLichChieu();
                    }
                    else
                    {
                        MessageBox.Show("Chưa nhập giá vé", "Thông báo");
                    }

                }
                else
                {
                    MessageBox.Show("Chưa chọn", "Thông báo");
                }
            }
            else
            {
                MessageBox.Show("Chưa nhập dữ liêu", "Thông báo");
            }
        }
        private void XoaTrangThaiGhe()
        {
           
            try
            {
                ketNoi.Connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = ketNoi.Connection;
                cmd.CommandText = "XoaTrangThaiGhe";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@mashow", SqlDbType.NVarChar, 10)).Value = txtMaShow.Text;
                cmd.ExecuteNonQuery();
                maShowTam = txtMaShow.Text;

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

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            setNhap();
        }
        private void XoaLichChieu()
        {
            try
            {
                ketNoi.Connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = ketNoi.Connection;
                cmd.CommandText = "XoaLichChieu";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@mashow", SqlDbType.NVarChar, 10)).Value = txtMaShow.Text;
                cmd.ExecuteNonQuery();
                if(cmd.Parameters.Count > 0 )
                {
                    MessageBox.Show("Xóa thành công", "Thông báo");
                }
                maShowTam = txtMaShow.Text;

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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (ktraNhan == true)
            {
                XoaTrangThaiGhe();
                XoaLichChieu();
                dgvLichChieu.DataSource = LayDanhSachLichChieu();
                setNhap();
            }
            else
            {
                MessageBox.Show("Chưa chọn", "Thông báo");
            }
            
        }
        private void setNhap()
        {
            txtMaShow.ReadOnly = false;
            txtMaShow.Text = "";
            txtGiaVe.Text = "";
            cmbMaPhim.SelectedIndex = 0;
            cmbMaPhong.SelectedIndex = 0;
            cmbMaRap.SelectedIndex = 0;
            dateTimeGioChieu.Value = DateTime.Now;
            dateTimeNgayChieu.Value = DateTime.Now;
            ktraNhan = false;
        }

        private void QuanLyLichChieu_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                e.Cancel = true; // Ngăn không cho form đóng
            }
        }
        private bool KtraLichChieuSua(bool ktra)
        {
            try
            {

                ketNoi.Connection.Open();
                // Tạo SqlCommand để thực hiện stored procedure LayKhachHang
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = ketNoi.Connection;
                cmd.CommandText = "KTraLichChieuSua";
                cmd.CommandType = CommandType.StoredProcedure;
                DateTime ngayChieu = dateTimeNgayChieu.Value.Date;
                // Thêm parameter cho stored procedure
                cmd.Parameters.Add(new SqlParameter("@mashow", SqlDbType.NVarChar, 10)).Value = txtMaShow.Text;
                cmd.Parameters.Add(new SqlParameter("@maphong", SqlDbType.NVarChar, 10)).Value = cmbMaPhong.SelectedValue;
                cmd.Parameters.Add(new SqlParameter("@ngaychieu", SqlDbType.Date)).Value = ngayChieu;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    TimeSpan khoangThoiGian = new TimeSpan(3, 0, 0);
                    TimeSpan gioChieuMoi = dateTimeGioChieu.Value.TimeOfDay;
                    int ktraTest = 0;

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        TimeSpan gioChieuCu = (TimeSpan)dt.Rows[i]["gioChieu"];
                        TimeSpan gioKtraMin = gioChieuCu - khoangThoiGian;
                        TimeSpan gioKtraMax = gioChieuCu + khoangThoiGian;

                        if ((gioChieuMoi < gioChieuCu && gioChieuMoi + khoangThoiGian > gioChieuCu) ||
                            (gioChieuCu < gioChieuMoi && gioChieuCu + khoangThoiGian > gioChieuMoi))
                        {
                            ktraTest++;
                        }
                        if (gioChieuMoi == gioChieuCu)
                        {
                            ktraTest++;
                        }
                    }

                    if (ktraTest > 0)
                    {
                        MessageBox.Show("Lỗi: Thời gian lịch chiếu\n Lịch chiếu phải cách nhau 3h", "Thông báo");
                        ktra = true;
                    }
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

        private void dgvLichChieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaShow.ReadOnly = true;
            int dong = dgvLichChieu.CurrentCell.RowIndex;
            string str = dgvLichChieu.Rows[dong].Cells[7].Value.ToString();
            int soVeBan = int.Parse(str);
            if (soVeBan == 0)
            {
                txtMaShow.Text = dgvLichChieu.Rows[dong].Cells[0].Value.ToString();
                string maPhim = dgvLichChieu.Rows[dong].Cells[1].Value.ToString();

                // Assuming that LayDSPhim returns a DataTable
                DataTable phimTable = ketNoi.LayDanhSach("LayDSPhim");

                // Find the row with the matching maPhim in the DataTable
                DataRow[] rows = phimTable.Select($"maPhim = '{maPhim}'");

                if (rows.Length > 0)
                {
                    // Set the selected item in cmbMaPhim based on the found DataRow's ValueMember
                    cmbMaPhim.SelectedValue = rows[0]["maPhim"];
                }
                else
                {
                    MessageBox.Show("Không tìm thấy mã phim trong danh sách.", "Thông báo");
                }
                cmbMaRap.SelectedValue = dgvLichChieu.Rows[dong].Cells[2].Value.ToString();
                cmbMaPhong.SelectedValue = dgvLichChieu.Rows[dong].Cells[3].Value.ToString();
                string ngayChieuString = dgvLichChieu.Rows[dong].Cells[4].Value.ToString();
                // Thử chuyển đổi giá trị thành kiểu DateTime
                if (DateTime.TryParse(ngayChieuString, out DateTime ngayChieu))
                {
                    // Nếu chuyển đổi thành công, gán giá trị cho NgayChieu
                    dateTimeNgayChieu.Value = ngayChieu;
                }
                string gioChieuString = dgvLichChieu.Rows[dong].Cells[5].Value.ToString();
                // Thử chuyển đổi giá trị thành kiểu DateTime
                if (TimeSpan.TryParse(gioChieuString, out TimeSpan gioChieu))
                {
                    // Nếu chuyển đổi thành công, gán giá trị cho NgayChieu
                    dateTimeGioChieu.Value = DateTime.Today + gioChieu;
                }
                txtGiaVe.Text = dgvLichChieu.Rows[dong].Cells[6].Value.ToString();
                ktraNhan = true;
            }
            else
            {
                MessageBox.Show("Lịch chiếu đã đặt vé", "Thông báo");
            }
        }
    }
}
