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
    public partial class Phong : Form
    {
        private ConnectDataBase connectDB;
        public Phong()
        {
            InitializeComponent();
            connectDB = new ConnectDataBase();
            cbbRap.SelectedIndexChanged += new EventHandler(cbbRap_SelectedIndexChanged);
        }

        private void Phong_Load(object sender, EventArgs e)
        {
            dgvDSPhong.DataSource = connectDB.DanhSachPhong();
            dgvDSPhong.CellClick += dgvDSPhong_CellContentClick;

            //combobox rạp
            DataTable dtRap = connectDB.LayDanhSachRapPhim();
            cbbRap.DataSource = dtRap;
            cbbRap.DisplayMember = "TenRap";
            cbbRap.ValueMember = "MaRap";
            cbbRap.SelectedIndex = -1;

            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            
        }

        private void cbbRap_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedRap = cbbRap.SelectedValue?.ToString();
            //combobox nhân viên
            if (!string.IsNullOrEmpty(selectedRap))
            {
                DataTable dtNhanVien = connectDB.DanhSachComboboxNhanVien(selectedRap);
                cbbNhanVien.DataSource = dtNhanVien;
                cbbNhanVien.SelectedIndex = -1;
                cbbNhanVien.ValueMember = "MaNV";
                cbbNhanVien.DisplayMember = "TenNV";
            }
        }
        //thêm phòng
        private void btnThem_Click(object sender, EventArgs e)
        {
            string maPhong = txtMaPhong.Text;
            string maRap = cbbRap.SelectedValue.ToString();
            string tenPhong = txtTenPhong.Text;
            string maNV = cbbNhanVien.SelectedValue.ToString();
            string tinhtrangPhong = cbbTinhtrang.SelectedItem.ToString();

            connectDB.ThemPhong(maPhong, maRap, tenPhong, maNV, tinhtrangPhong);
            
            dgvDSPhong.DataSource = connectDB.DanhSachPhong();

            txtMaPhong.Clear();
            txtTenPhong.Clear();
            cbbRap.SelectedIndex = -1;
            cbbNhanVien.SelectedIndex = -1;
            cbbTinhtrang.SelectedIndex = -1;
            errorProvider1.Clear();
        }
        //xóa phòng 
        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult d;
            d = MessageBox.Show("Bạn có muốn xóa Phòng này không?", "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1);
            if (d == DialogResult.Yes)
            {
                string maPhong = txtMaPhong.Text;
                string maRap = cbbRap.SelectedValue.ToString();
                connectDB.XoaGheTuDong(maPhong);
                connectDB.XoaPhong(maPhong, maRap);
                
                dgvDSPhong.DataSource = connectDB.DanhSachPhong();

                txtMaPhong.Clear();
                txtTenPhong.Clear();
                cbbRap.SelectedIndex = -1;
                cbbNhanVien.SelectedIndex = -1;
                cbbTinhtrang.SelectedIndex = -1;
                errorProvider1.Clear();
            }
                
        }
        
        private void dgvDSPhong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            /*if(e.RowIndex >= 0 || e.ColumnIndex >= 0)
            {
                DataGridViewRow row = dgvDSPhong.Rows[e.RowIndex];

                string maPhong = row.Cells["maPhong"].Value.ToString();

                DataTable dtPhong = connectDB.LayThongTinPhong(maPhong);

                if(dtPhong.Rows.Count > 0)
                {
                    txtMaPhong.Text = dtPhong.Rows[0]["MaPhong"].ToString();
                    cbbRap.Text = dtPhong.Rows[0]["TenRap"].ToString();
                    txtTenPhong.Text = dtPhong.Rows[0]["TenPhong"].ToString();
                    if(dtPhong.Rows[0]["TenNV"].ToString().Length != 0)
                    {
                        cbbNhanVien.SelectedValue = dtPhong.Rows[0]["TenNV"].ToString();
                    }
                    cbbTinhtrang.SelectedValue = dtPhong.Rows[0]["TinhTrangPhong"].ToString();
                    
                }
            }*/
            int dong = dgvDSPhong.CurrentCell.RowIndex;
            txtMaPhong.Text = dgvDSPhong.Rows[dong].Cells[0].Value.ToString();
            cbbRap.SelectedValue = dgvDSPhong.Rows[dong].Cells[1].Value.ToString();
            cbbNhanVien.SelectedValue = dgvDSPhong.Rows[dong].Cells[2].Value.ToString();
            txtTenPhong.Text = dgvDSPhong.Rows[dong].Cells[3].Value.ToString();
            cbbTinhtrang.Text = dgvDSPhong.Rows[dong].Cells[5].Value.ToString();
            cbbRap.Enabled = false;
            txtMaPhong.Enabled = false;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnThem.Enabled = false;
            errorProvider1.Clear();
        }
        private void btnLammoi_Click(object sender, EventArgs e)
        {
            txtMaPhong.Clear();
            txtTenPhong.Clear();
            cbbRap.SelectedIndex = -1;
            cbbNhanVien.SelectedIndex = -1;
            cbbTinhtrang.SelectedIndex = -1;
            errorProvider1.Clear();

            txtMaPhong.Enabled = true;
            cbbRap.Enabled = true;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnThem.Enabled = false;

            dgvDSPhong.DataSource = connectDB.DanhSachPhong();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult d;
            d = MessageBox.Show("Bạn có muốn đóng cửa sổ này không?", "Thông báo",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1);
            if (d == DialogResult.Yes)
            {
                Close();
            }
        }

        private void txtMaPhong_TextChanged(object sender, EventArgs e)
        {
            if(txtMaPhong.Text != "")
            {
                btnThem.Enabled = true;
                errorProvider1.Clear();
            }
            else
            {
                btnThem.Enabled = false;
                this.errorProvider1.SetError(txtMaPhong, "Trường này không được để trống!");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string maPhong = txtMaPhong.Text;
            string tenPhong = txtTenPhong.Text;
            string maNV = cbbNhanVien.SelectedValue.ToString();
            string tinhtrangPhong = cbbTinhtrang.SelectedItem.ToString();

            connectDB.SuaPhong(maPhong, tenPhong, maNV, tinhtrangPhong);

            dgvDSPhong.DataSource = connectDB.DanhSachPhong();

            txtMaPhong.Clear();
            txtTenPhong.Clear();
            cbbRap.SelectedIndex = -1;
            cbbNhanVien.SelectedIndex = -1;
            cbbTinhtrang.SelectedIndex = -1;
            errorProvider1.Clear();
        }
    }
}
