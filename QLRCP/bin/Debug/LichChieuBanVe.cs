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
    public partial class LichChieuBanVe : Form
    {
        public LichChieuBanVe()
        {
            InitializeComponent();
        }
        ketNoiDB ketNoi = new ketNoiDB();
        private LichChieu lichChieu = new LichChieu();
        private bool ktraNhan = false;

        internal LichChieu LichChieu { get => lichChieu; set => lichChieu = value; }

        private void LichChieuBanVe_Load(object sender, EventArgs e)
        {
            DateTime ngayChieu = dateChieu.Value.Date;
            cmbPhim.DropDownStyle = ComboBoxStyle.DropDownList;
            LayDSPhimTrongNgay(ngayChieu);
            cmbPhim.DataSource = ketNoi.LayDanhSach("LayDSPhim");
            cmbPhim.DisplayMember = "tenPhim";
            cmbPhim.ValueMember = "maPhim";
            cmbPhim.SelectedIndex = 0;
            

        }
        private void HienThiLichChieuPhim(string maPhim)
        {
            try
            {
                ketNoi.Connection.Open();

                // Tạo SqlCommand để thực hiện stored procedure LayDSLichChieuTheoPhim
                SqlCommand cmdLichChieuTheoPhim = new SqlCommand();
                cmdLichChieuTheoPhim.CommandText = "LayDSLichChieuTuPhim";
                cmdLichChieuTheoPhim.CommandType = CommandType.StoredProcedure;
                cmdLichChieuTheoPhim.Connection = ketNoi.Connection;

                // Thêm parameter cho stored procedure
                cmdLichChieuTheoPhim.Parameters.AddWithValue("@MaPhim", maPhim);
                DateTime ngayChieu = dateChieu.Value.Date;
                
                
                cmdLichChieuTheoPhim.Parameters.AddWithValue("@NgayChieu", ngayChieu);
                
                
                // Tạo SqlDataAdapter và DataTable để đổ dữ liệu
                SqlDataAdapter daLichChieu = new SqlDataAdapter(cmdLichChieuTheoPhim);
                DataTable dtLichChieu = new DataTable();

                // Đổ dữ liệu từ SqlDataAdapter vào DataTable
              
                daLichChieu.Fill(dtLichChieu);

                // Hiển thị dữ liệu trong DataGridView
                dgvLichChieu.DataSource = dtLichChieu;
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

        private void cmbPhim_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Lấy mã phim đã chọn từ ComboBox
            string maPhim = cmbPhim.SelectedValue.ToString();

            // Hiển thị lịch chiếu của phim đã chọn trong DataGridView
            HienThiLichChieuPhim(maPhim);
        }
        private void LayDSPhimTrongNgay(DateTime ngayChieu)
        {
            try
            {
                ketNoi.Connection.Open();
                SqlCommand cmd = new SqlCommand("LayDSPhimTrongNgay", ketNoi.Connection);
                cmd.CommandType = CommandType.StoredProcedure;

                // Thêm tham số cho stored procedure
                cmd.Parameters.AddWithValue("@NgayChieu", ngayChieu.Date);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvLichChieu.DataSource= dt;
                // Hiển thị kết quả trong DataGridView hoặc bất kỳ điều gì khác
                // Ví dụ: dataGridViewPhim.DataSource = dt;
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

        private void btnChonVe_Click(object sender, EventArgs e)
        {
            if(ktraNhan == true)
            {
                LichChieu tamLichChieu = lichChieu;
                ManChieuBanVe manChieuBanVe = new ManChieuBanVe(tamLichChieu);
                manChieuBanVe.ShowDialog();
            }
            else
            {
                MessageBox.Show("Chưa chọn lịch chiếu", "Thông báo");
            }
            
        }

        private void LichChieuBanVe_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                e.Cancel = true; // Ngăn không cho form đóng
            }
        }

        private void dgvLichChieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int dong = dgvLichChieu.CurrentCell.RowIndex;
            lichChieu.MaShow = dgvLichChieu.Rows[dong].Cells[0].Value.ToString();
            lichChieu.MaPhim = dgvLichChieu.Rows[dong].Cells[1].Value.ToString();
            string ngayChieuString = dgvLichChieu.Rows[dong].Cells[2].Value.ToString();

            // Thử chuyển đổi giá trị thành kiểu DateTime
            if (DateTime.TryParse(ngayChieuString, out DateTime ngayChieu))
            {
                // Nếu chuyển đổi thành công, gán giá trị cho NgayChieu
                lichChieu.NgayChieu = ngayChieu;
            }
            string gioChieuString = dgvLichChieu.Rows[dong].Cells[3].Value.ToString();
            // Thử chuyển đổi giá trị thành kiểu DateTime
            if (TimeSpan.TryParse(gioChieuString, out TimeSpan gioChieu))
            {
                // Nếu chuyển đổi thành công, gán giá trị cho NgayChieu
                lichChieu.GioChieu = gioChieu;
            }
            lichChieu.MaPhong = dgvLichChieu.Rows[dong].Cells[4].Value.ToString();
            lichChieu.MaRap = dgvLichChieu.Rows[dong].Cells[5].Value.ToString();
            ktraNhan = true;
        }
    }
}
