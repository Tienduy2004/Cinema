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
    public partial class Rapphim : Form
    {
        private ConnectDataBase dbConnector;
        public Rapphim()
        {
            InitializeComponent();
            dbConnector = new ConnectDataBase();
        }
        
        private void Rapphim_Load(object sender, EventArgs e)
        {
            dgvDSRapPhim.DataSource = dbConnector.LayDanhSachRapPhim();

            dgvDSRapPhim.CellClick += dgvDSRapPhim_CellContentClick;


            //mở nút
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnThem.Enabled = false;
        }
       
        private void dgvDSRapPhim_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow row = dgvDSRapPhim.Rows[e.RowIndex];

                //lấy dữ liệu 
                string maRap = row.Cells["MaRap"].Value.ToString();
                //gọi Store
                DataTable dtThongTinRap = dbConnector.LayThongTinRapPhim(maRap);

                //kiem tra xem co du lieu khong
                if(dtThongTinRap.Rows.Count > 0)
                {
                    txtMaRap.Text = dtThongTinRap.Rows[0]["MaRap"].ToString();
                    txtTenRap.Text = dtThongTinRap.Rows[0]["TenRap"].ToString();
                    txtDiachi.Text = dtThongTinRap.Rows[0]["DiaChiRap"].ToString();
                    txtTimeHoatDong.Text = dtThongTinRap.Rows[0]["TimeHoatDong"].ToString();
                    txtSdt.Text = dtThongTinRap.Rows[0]["SdtRap"].ToString();
                }

                //mở nút
                txtMaRap.Enabled = false;
                btnXoa.Enabled = true;
                btnSua.Enabled = true;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string maRap = txtMaRap.Text;
            string tenRap = txtTenRap.Text;
            string diaChi = txtDiachi.Text;
            string timeHoatDong = txtTimeHoatDong.Text;
            string sdt = txtSdt.Text;

            //Connect DB
            dbConnector.ThemRapPhim(maRap, tenRap, diaChi, timeHoatDong, sdt);

            txtMaRap.Clear();
            txtTenRap.Clear();
            txtDiachi.Clear();
            txtTimeHoatDong.Clear();
            txtSdt.Clear();
            errorProvider1.Clear();
        }

        private void btnLammoi_Click(object sender, EventArgs e)
        {
            dgvDSRapPhim.DataSource = dbConnector.LayDanhSachRapPhim();

            txtMaRap.Clear();
            txtTenRap.Clear();
            txtDiachi.Clear();
            txtTimeHoatDong.Clear();
            txtSdt.Clear();


            //mở nút
            txtMaRap.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            errorProvider1.Clear();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult d;
            d = MessageBox.Show("Bạn có muốn thoát cửa sổ này không?", "Exit",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1);
            if (d == DialogResult.Yes)
            {
                Close();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string maRap = txtMaRap.Text;
            string tenRap = txtTenRap.Text;
            string diaChi = txtDiachi.Text;
            string timeHoatdong = txtTimeHoatDong.Text;
            string sdt = txtSdt.Text;

            dbConnector.SuaRapPhim(maRap, tenRap, diaChi, timeHoatdong, sdt);

            txtMaRap.Clear();
            txtTenRap.Clear();
            txtDiachi.Clear();
            txtTimeHoatDong.Clear();
            txtSdt.Clear();
            errorProvider1.Clear();

            dgvDSRapPhim.DataSource = dbConnector.LayDanhSachRapPhim();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Bạn có muốn xóa không", "Thông báo",
                             MessageBoxButtons.YesNo,
                             MessageBoxIcon.Question,
                             MessageBoxDefaultButton.Button1);
            if(d == DialogResult.Yes)
            {
                string maRap = dgvDSRapPhim.CurrentRow.Cells["MaRap"].Value.ToString();

                dbConnector.XoaRapPhim(maRap);

                //load
                dgvDSRapPhim.DataSource = dbConnector.LayDanhSachRapPhim();

                //xoa du lieu text box
                txtMaRap.Clear();
                txtTenRap.Clear();
                txtDiachi.Clear();
                txtTimeHoatDong.Clear();
                txtSdt.Clear();
                errorProvider1.Clear();
            }
            
        }

        private void txtMaRap_TextChanged(object sender, EventArgs e)
        {
            if(txtMaRap.Text != "")
            {
                //mở nút
                 btnThem.Enabled = true;
                errorProvider1.Clear();
            }
            else
            {
                btnThem.Enabled = false;
                this.errorProvider1.SetError(txtMaRap, "Trường này không được để trống!");
            }
        }
    }
}
