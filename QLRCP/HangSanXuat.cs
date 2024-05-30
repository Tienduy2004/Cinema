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
    public partial class HangSanXuat : Form
    {
        private ConnectDataBase dbConnect;
        public HangSanXuat()
        {
            InitializeComponent();
            dbConnect = new ConnectDataBase();
        }

        private void HangSanXuat_Load(object sender, EventArgs e)
        {
            dgvDSHang.DataSource = dbConnect.DanhSachHangSX();
            dgvDSHang.CellClick += dgvDSHang_CellContentClick;

            btnThem.Enabled= false;
            btnXoa.Enabled= false;
            btnSua.Enabled= false;
        }

        private void dgvDSHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0 || e.ColumnIndex >= 0)
            {
                DataGridViewRow row = dgvDSHang.Rows[e.RowIndex];

                string maHang = row.Cells["MaHangSX"].Value.ToString();

                
               DataTable dtHang = dbConnect.LayThongTinHangSX(maHang);

                //kiem tra
                if(dtHang.Rows.Count > 0)
                {
                    txtMaHang.Text = dtHang.Rows[0]["MaHangSX"].ToString();
                    txtTenHang.Text = dtHang.Rows[0]["TenHangSX"].ToString();
                }
            }
            txtMaHang.Enabled = false;
            btnThem.Enabled = false;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string maHang = txtMaHang.Text;
            string tenHang = txtTenHang.Text;

            dbConnect.ThemHangSX(maHang, tenHang);

            txtMaHang.Clear();
            txtTenHang.Clear();
            errorProvider1.Clear();

            dgvDSHang.DataSource = dbConnect.DanhSachHangSX();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string maHang = txtMaHang.Text;
            string tenHang = txtTenHang.Text;

            dbConnect.SuaHangSX(maHang, tenHang);

            txtMaHang.Clear();
            txtTenHang.Clear();
            errorProvider1.Clear();

            dgvDSHang.DataSource = dbConnect.DanhSachHangSX();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult d;
            d = MessageBox.Show("Bạn có muốn xóa không?", "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1);
            if(d == DialogResult.Yes)
            {
                string maHang = txtMaHang.Text;

                dbConnect.XoaHangSX(maHang);

                txtMaHang.Clear();
                txtTenHang.Clear();
                errorProvider1.Clear();

                dgvDSHang.DataSource = dbConnect.DanhSachHangSX();
            }
 
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult d;
            d = MessageBox.Show("Bạn có muốn thoát cửa số này không?", "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1);
            if(d == DialogResult.Yes)
            {
                Close();
            }
        }

        private void btnLammoi_Click(object sender, EventArgs e)
        {
            dgvDSHang.DataSource = dbConnect.DanhSachHangSX();

            txtMaHang.Clear();
            txtTenHang.Clear();
            errorProvider1.Clear();

            txtMaHang.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = false;
        }

        private void txtMaHang_TextChanged(object sender, EventArgs e)
        {
            if(txtMaHang.Text != "")
            {
                btnThem.Enabled = true;
                errorProvider1.Clear();
            }
            else
            {
                btnThem.Enabled = false;
                this.errorProvider1.SetError(txtMaHang, "Trường này không được đế trống");
            }
        }
    }
}
