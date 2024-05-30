using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLRCP
{
    public partial class TheLoai : Form
    {
        private ConnectDataBase dbConnector;
        public TheLoai()
        {
            InitializeComponent();
            dbConnector = new ConnectDataBase();
        }
        private void TheLoai_Load(object sender, EventArgs e)
        {
            dgvDSTheLoai.DataSource = dbConnector.LayDanhSachTheLoai();
            dgvDSTheLoai.CellClick += dgvDSTheLoai_CellContentClick;

            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }


        private void dgvDSTheLoai_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0 || e.ColumnIndex >= 0)
            {
                DataGridViewRow row = dgvDSTheLoai.Rows[e.RowIndex];

                //lấy dữ liệu
                string maTheLoai = row.Cells["MaTheLoai"].Value.ToString();

                //goi store 
                DataTable dtTheLoai = dbConnector.LayThongTinTheLoai(maTheLoai);

                //kiem tra du lieu
                if(dtTheLoai.Rows.Count > 0)
                {
                    txtMaTL.Text = dtTheLoai.Rows[0]["MaTheLoai"].ToString();
                    txtTenTL.Text = dtTheLoai.Rows[0]["TenTheLoai"].ToString();
                }
            }
            txtMaTL.Enabled = false;
            btnThem.Enabled = false;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
        }
        //Thoát
        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult d;
            d = MessageBox.Show("Bạn có muốn đóng cửa số này không?", "Exit",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1);
            if (d == DialogResult.Yes)
            {
                Close();
            }
        }
        //Thêm
        private void btnThem_Click(object sender, EventArgs e)
        {
            string maTL = txtMaTL.Text;
            string tenTL = txtTenTL.Text;

            dbConnector.ThemTheLoai(maTL, tenTL);

            txtMaTL.Clear();
            txtTenTL.Clear();
            errorProvider1.Clear();

            dgvDSTheLoai.DataSource = dbConnector.LayDanhSachTheLoai();
        }
        //Sửa
        private void btnSua_Click(object sender, EventArgs e)
        {
            string maTL = txtMaTL.Text;
            string tenTL = txtTenTL.Text;

            dbConnector.SuaTheLoai(maTL, tenTL);

            txtMaTL.Clear();
            txtTenTL.Clear();
            errorProvider1.Clear();

            dgvDSTheLoai.DataSource = dbConnector.LayDanhSachTheLoai();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult d;
            d = MessageBox.Show("Bạn có muốn xóa không", "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1);
            if (d == DialogResult.Yes)
            {
                string maTL = dgvDSTheLoai.CurrentRow.Cells["MaTheLoai"].Value.ToString();

                dbConnector.XoaTheLoai(maTL);

                //xóa dữ liệu textbox
                txtMaTL.Clear();
                txtTenTL.Clear();
                errorProvider1.Clear();

                dgvDSTheLoai.DataSource = dbConnector.LayDanhSachTheLoai();
            }
        }
        //làm mới
        private void btnLammoi_Click(object sender, EventArgs e)
        {
            dgvDSTheLoai.DataSource = dbConnector.LayDanhSachTheLoai();

            txtMaTL.Clear();
            txtTenTL.Clear();
            errorProvider1.Clear();

            txtMaTL.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = false;
        }

        private void txtMaTL_TextChanged(object sender, EventArgs e)
        {
            if(txtMaTL.Text != "")  
            {
                btnThem.Enabled = true;
                errorProvider1.Clear();
            }
            else
            {
                btnThem.Enabled = false;
                this.errorProvider1.SetError(txtMaTL, "Trường này không được để trống!");
            }
        }
    }
}
