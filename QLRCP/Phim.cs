using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLRCP
{
    public partial class Phim : Form
    {
        private ConnectDataBase dbConnector;
        public Phim()
        {
            InitializeComponent();
            dbConnector = new ConnectDataBase();
        }
        private void Phim_Load(object sender, EventArgs e)
        {
            //danh sách Phim
            dgvPhim.DataSource = dbConnector.DanhSachPhim();
            dgvPhim.CellClick += dgvPhim_CellContentClick;

            //danh sách thể loại
            DataTable dtTheLoai = dbConnector.LayDanhSachTheLoai();
            cbbTL.DataSource = dtTheLoai;
            cbbTL.DisplayMember = "TenTheLoai";
            cbbTL.SelectedIndex = -1;
            cbbTL.ValueMember = "MaTheLoai";
            //danh sách hãng
            DataTable dtHang = dbConnector.DanhSachHangSX();
            cbbHang.DataSource = dtHang;
            cbbHang.DisplayMember = "TenHangSX";
            cbbHang.SelectedIndex = -1;
            cbbHang.ValueMember = "MaHangSX";
            //danh sách nước sản xuất
            DataTable dtNuoc = dbConnector.LayDanhSachNuocSX();
            cbbNuoc.DataSource = dtNuoc;
            cbbNuoc.DisplayMember = "TenNuocSX";
            cbbNuoc.SelectedIndex = -1;
            cbbNuoc.ValueMember = "MaNuocSX";

            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void timeStart_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void dgvPhim_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 || e.ColumnIndex >= 0)
            {
                DataGridViewRow row = dgvPhim.Rows[e.RowIndex];

                string maPhim = row.Cells["Mã Phim"].Value.ToString();

                DataTable dtPhim = dbConnector.LayThongTinPhim(maPhim);

                if (dtPhim.Rows.Count > 0)
                {
                    txtMaPhim.Text = dtPhim.Rows[0]["MaPhim"].ToString();
                    txtTenPhim.Text = dtPhim.Rows[0]["TenPhim"].ToString();
                    txtDaodien.Text = dtPhim.Rows[0]["DaoDien"].ToString();
                    txtDienVien.Text = dtPhim.Rows[0]["DienVien"].ToString();
                    cbbTL.Text = dtPhim.Rows[0]["TenTheLoai"].ToString();
                    cbbHang.Text = dtPhim.Rows[0]["TenHangSX"].ToString();
                    cbbNuoc.Text = dtPhim.Rows[0]["TenNuocSX"].ToString();
                    timeNamSX.Text = dtPhim.Rows[0]["NamSX"].ToString();
                    thoiLuongPhim.Text = dtPhim.Rows[0]["ThoiLuongPhim"].ToString();
                    txtNoidungphim.Text = dtPhim.Rows[0]["NoiDungPhim"].ToString();
                    timeStart.Text = dtPhim.Rows[0]["TimeStart"].ToString();
                    timeEnd.Text = dtPhim.Rows[0]["TimeEnd"].ToString();
                }
            }
            txtMaPhim.Enabled = false;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnThem.Enabled = false;
        }
        private void cbbTL_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string maPhim = txtMaPhim.Text;
            string tenPhim = txtTenPhim.Text;
            string daoDien = txtDaodien.Text;
            string dienVien = txtDienVien.Text;
            string matheloaiPhim = cbbTL.SelectedValue.ToString(); 
            string mahangSX = cbbHang.SelectedValue.ToString(); 
            string manuocSX = cbbNuoc.SelectedValue.ToString(); 
            DateTime namSX = timeNamSX.Value.Date;
            string noidungPhim = txtNoidungphim.Text;
            DateTime thoiluongPhim = thoiLuongPhim.Value;
            DateTime timeStartt = timeStart.Value;
            DateTime timeEndd = timeEnd.Value;

            dbConnector.ThemPhim(maPhim, tenPhim, daoDien, dienVien, matheloaiPhim, mahangSX, manuocSX, namSX, noidungPhim, thoiluongPhim, timeStartt, timeEndd);

            
            // Xóa dữ liệu trong các textbox
            txtMaPhim.Clear();
            txtTenPhim.Clear();
            txtDaodien.Clear();
            txtDienVien.Clear();
            txtNoidungphim.Clear();
            thoiLuongPhim.Value = DateTime.Now;
            errorProvider1.Clear();

            // Đặt các DateTimePicker về giá trị mặc định
            timeNamSX.Value = DateTime.Now;
            timeStart.Value = DateTime.Now;
            timeEnd.Value = DateTime.Now;

            // Đặt các ComboBox về giá trị mặc định hoặc làm sạch dữ liệu
            cbbTL.SelectedIndex = -1;
            cbbHang.SelectedIndex = -1;
            cbbNuoc.SelectedIndex = -1;

            dgvPhim.DataSource = dbConnector.DanhSachPhim();
        }

        private void txtDienVien_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string maPhim = txtMaPhim.Text;
            string tenPhim = txtTenPhim.Text;
            string daoDien = txtDaodien.Text;
            string dienVien = txtDienVien.Text;
            string matheloaiPhim = cbbTL.SelectedValue.ToString();
            string mahangSX = cbbHang.SelectedValue.ToString();
            string manuocSX = cbbNuoc.SelectedValue.ToString();
            DateTime namSX = timeNamSX.Value;
            string noidungPhim = txtNoidungphim.Text;
            DateTime thoiluong = thoiLuongPhim.Value;
            DateTime timeStartt = timeStart.Value;
            DateTime timeEndd = timeEnd.Value;

            dbConnector.SuaPhim(maPhim, tenPhim, daoDien, dienVien, matheloaiPhim, mahangSX, manuocSX, namSX, noidungPhim, thoiluong, timeStartt, timeEndd);

            // Xóa dữ liệu trong các textbox
            txtMaPhim.Clear();
            txtTenPhim.Clear();
            txtDaodien.Clear();
            txtDienVien.Clear();
            txtNoidungphim.Clear();
            errorProvider1.Clear();

            // Đặt các DateTimePicker về giá trị mặc định
            thoiLuongPhim.Value = DateTime.Now;
            timeNamSX.Value = DateTime.Now;
            timeStart.Value = DateTime.Now;
            timeEnd.Value = DateTime.Now;

            // Đặt các ComboBox về giá trị mặc định hoặc làm sạch dữ liệu
            cbbTL.SelectedIndex = -1;
            cbbHang.SelectedIndex = -1;
            cbbNuoc.SelectedIndex = -1;

            dgvPhim.DataSource = dbConnector.DanhSachPhim();

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult d;
            d = MessageBox.Show("Bạn có muốn xóa Phim này không?", "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1);
            if (d == DialogResult.Yes)
            {
                string maPhim = txtMaPhim.Text;

                dbConnector.XoaPhim(maPhim);

                // Xóa dữ liệu trong các textbox
                txtMaPhim.Clear();
                txtTenPhim.Clear();
                txtDaodien.Clear();
                txtDienVien.Clear();
                txtNoidungphim.Clear();
                errorProvider1.Clear();

                // Đặt các DateTimePicker về giá trị mặc định
                timeNamSX.Value = DateTime.Now;
                timeStart.Value = DateTime.Now;
                timeEnd.Value = DateTime.Now;
                thoiLuongPhim.Value = DateTime.Now;

                // Đặt các ComboBox về giá trị mặc định hoặc làm sạch dữ liệu
                cbbTL.SelectedIndex = -1;
                cbbHang.SelectedIndex = -1;
                cbbNuoc.SelectedIndex = -1;

                dgvPhim.DataSource = dbConnector.DanhSachPhim();
            }
            
        }

        private void btnLammoi_Click(object sender, EventArgs e)
        {
            // Xóa dữ liệu trong các textbox
            txtMaPhim.Clear();
            txtTenPhim.Clear();
            txtDaodien.Clear();
            txtDienVien.Clear();
            txtNoidungphim.Clear();
            errorProvider1.Clear();

            // Đặt các DateTimePicker về giá trị mặc định
            timeNamSX.Value = DateTime.Now;
            timeStart.Value = DateTime.Now;
            timeEnd.Value = DateTime.Now;
            thoiLuongPhim.Value = DateTime.Now;

            // Đặt các ComboBox về giá trị mặc định hoặc làm sạch dữ liệu
            cbbTL.SelectedIndex = -1;
            cbbHang.SelectedIndex = -1;
            cbbNuoc.SelectedIndex = -1;

            //
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            txtMaPhim.Enabled = true;

            dgvPhim.DataSource = dbConnector.DanhSachPhim();
        }

        private void txtMaPhim_TextChanged(object sender, EventArgs e)
        {
            if(txtMaPhim.Text != "")
            {
                btnThem.Enabled =true;
                errorProvider1.Clear();
            }
            else
            {
                btnThem.Enabled =false;
                this.errorProvider1.SetError(txtMaPhim, "Trường này không được để trống");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult d;
            d = MessageBox.Show("Bạn có muốn đóng cửa sổ này không?", "Thông báo",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1);
            if( d == DialogResult.Yes )
            {
                Close();
            }
        }
    }
}
