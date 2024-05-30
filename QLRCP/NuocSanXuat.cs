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
    public partial class NuocSanXuat : Form
    {
        private ConnectDataBase dbConnector;
        public NuocSanXuat()
        {
            InitializeComponent();
            dbConnector = new ConnectDataBase();
        }

        private void NuocSanXuat_Load(object sender, EventArgs e)
        {
            dgvDSNuoc.DataSource = dbConnector.LayDanhSachNuocSX();
            dgvDSNuoc.CellClick += dgvDSNuoc_CellContentClick;

            btnSua.Enabled = false;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult d;
            d = MessageBox.Show("Bạn có muốn đóng cửa sổ này không?", "Xác nhận",
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
            dgvDSNuoc.DataSource = dbConnector.LayDanhSachNuocSX();

            txtMaNuoc.Clear();
            txtTenNuoc.Clear();

            txtMaNuoc.Enabled = true;
            btnSua.Enabled = false;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            errorProvider1.Clear();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string maNuoc = txtMaNuoc.Text;
            string tenNuoc = txtTenNuoc.Text;

            dbConnector.ThemNuocSX(maNuoc, tenNuoc);

            txtMaNuoc.Clear();
            txtTenNuoc.Clear();
            errorProvider1.Clear();

            dgvDSNuoc.DataSource = dbConnector.LayDanhSachNuocSX();
        }

        private void txtMaNuoc_TextChanged(object sender, EventArgs e)
        {
            if(txtMaNuoc.Text != "")
            {
                btnThem.Enabled = true;
                errorProvider1.Clear();
            }
            else
            {
                btnThem.Enabled = false;
                this.errorProvider1.SetError(txtMaNuoc, "Trường này không được để trống!");
            }
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
                string maNuoc = txtMaNuoc.Text;

                dbConnector.XoaNuocSX(maNuoc);

                txtMaNuoc.Clear();
                txtTenNuoc.Clear();
                errorProvider1.Clear();

                dgvDSNuoc.DataSource = dbConnector.LayDanhSachNuocSX();
            }
        }

        private void dgvDSNuoc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0 || e.ColumnIndex >= 0)
            {
                DataGridViewRow row = dgvDSNuoc.Rows[e.RowIndex];

                //lấy dữ liệu
                string maNuoc = row.Cells["MaNuocSX"].Value.ToString();

                DataTable dtNuoc = dbConnector.LayThongTinNuocSX(maNuoc);

                //kiểm tra dữ liệu
                if(dtNuoc.Rows.Count > 0)
                {
                    txtMaNuoc.Text = dtNuoc.Rows[0]["MaNuocSX"].ToString();
                    txtTenNuoc.Text = dtNuoc.Rows[0]["TenNuocSX"].ToString();
                }
            }
            txtMaNuoc.Enabled= false;
            btnSua.Enabled = true;
            btnThem.Enabled = false;
            btnXoa.Enabled = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string maNuoc = txtMaNuoc.Text;
            string tenNuoc = txtTenNuoc.Text;

            dbConnector.SuaNuocSX(maNuoc, tenNuoc);

            txtTenNuoc.Clear();
            txtMaNuoc.Clear();
            errorProvider1.Clear();

            dgvDSNuoc.DataSource = dbConnector.LayDanhSachNuocSX();
        }
    }
}
