using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace QLRCP
{
    public partial class NhanVien : Form
    {
        ConnectDataBase connectData;

        public NhanVien()
        {
            InitializeComponent();
            connectData = new ConnectDataBase();
        }
        private string maRapTam;

        private void NhanVien_Load(object sender, EventArgs e)
        {
            //danh sách nhân viên
            dgvDSNhanVien.DataSource = connectData.DanhSachNhanVien();

            //combobox Rạp phim
            DataTable dtRapPhim = connectData.LayDanhSachRapPhim();
            cmbMaRap.DataSource = dtRapPhim;
            cmbMaRap.SelectedIndex = -1;
            cmbMaRap.ValueMember = "MaRap";
            cmbMaRap.DisplayMember = "TenRap";

            //combobox Chức vụ
            DataTable dtChucVu = connectData.LayChucVu();
            cmbChucVu.DataSource = dtChucVu;
            cmbChucVu.SelectedIndex = -1;
            cmbChucVu.DisplayMember = "TenChucVu";
            cmbChucVu.ValueMember = "MaChucVu";
            
            
        }

        

        private void btnSua_Click_1(object sender, EventArgs e)
        {
            if (check())
            {
                string maNV = txtMaNV.Text;
                string maRap = cmbMaRap.SelectedValue.ToString();
                string tenNV = txtTenNV.Text;
                string sdtNV = txtSdtNV.Text;
                DateTime dateNV = dateNgaySinh.Value;
                string diaChiNV = txtDiaChiNV.Text;
                string queQuanNV = txtQueQuan.Text;
                string genderNV = rdNam.Checked ? "Nam" : "Nữ";
                string emailNV = txtEmailNV.Text;
                string cccdNV = txtCCCD.Text;
                string chucVu = cmbChucVu.SelectedValue.ToString();
                string mucLuongNV = txtLuongNV.Text;
                if (maRapTam.Equals(cmbMaRap.SelectedValue))
                {

                }
                else
                {
                    connectData.LayDanhSachPhongTheoMa(maNV);
                }
                connectData.SuaNhanVien(maNV, maRap, tenNV, sdtNV, dateNV, diaChiNV, queQuanNV, genderNV, emailNV,cccdNV, chucVu, mucLuongNV);
                
                dgvDSNhanVien.DataSource = connectData.DanhSachNhanVien();
            }
        }

        

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (check())
            {
                string maNV = txtMaNV.Text;
                string maRap = cmbMaRap.SelectedValue.ToString();
                string tenNV = txtTenNV.Text;
                string sdtNV = txtSdtNV.Text;
                DateTime dateNV = dateNgaySinh.Value;
                string diaChiNV = txtDiaChiNV.Text;
                string queQuanNV = txtQueQuan.Text;
                string genderNV = rdNam.Checked ? "Nam" : "Nữ";
                string emailNV = txtEmailNV.Text;
                string cccdNV = txtCCCD.Text;
                string chucVu = cmbChucVu.SelectedValue.ToString();
                string mucLuongNV = txtLuongNV.Text;

                connectData.ThemNhanVien(maNV, maRap, tenNV,sdtNV,dateNV,diaChiNV,queQuanNV, genderNV, emailNV,cccdNV, chucVu,mucLuongNV);

                dgvDSNhanVien.DataSource = connectData.DanhSachNhanVien();
            }
        }

        private void dgvDSNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int dong = dgvDSNhanVien.CurrentCell.RowIndex;
            txtMaNV.Text = dgvDSNhanVien.Rows[dong].Cells[0].Value.ToString();
            cmbMaRap.SelectedValue = dgvDSNhanVien.Rows[dong].Cells[1].Value.ToString();
            txtTenNV.Text = dgvDSNhanVien.Rows[dong].Cells[2].Value.ToString();
            txtSdtNV.Text = dgvDSNhanVien.Rows[dong].Cells[3].Value.ToString();
            dateNgaySinh.Value = DateTime.Parse(dgvDSNhanVien.Rows[dong].Cells[4].Value.ToString());
            txtDiaChiNV.Text = dgvDSNhanVien.Rows[dong].Cells[5].Value.ToString();
            txtQueQuan.Text = dgvDSNhanVien.Rows[dong].Cells[6].Value.ToString();
            if (dgvDSNhanVien.Rows[dong].Cells[7].Value.ToString() == "Nam")
            {
                rdNam.Checked = true;
            }else if (dgvDSNhanVien.Rows[dong].Cells[7].Value.ToString()== "Nữ")
            {
                rdNu.Checked = true;
            }
            txtEmailNV.Text = dgvDSNhanVien.Rows[dong].Cells[8].Value.ToString();
            txtCCCD.Text = dgvDSNhanVien.Rows[dong].Cells[9].Value.ToString();
            cmbChucVu.SelectedValue = dgvDSNhanVien.Rows[dong].Cells[10].Value.ToString();
            txtLuongNV.Text = dgvDSNhanVien.Rows[dong].Cells[11].Value.ToString();
            maRapTam = dgvDSNhanVien.Rows[dong].Cells[1].Value.ToString();
        }

        

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (check())
            {
                string maNV = txtMaNV.Text;
                connectData.LayDanhSachPhongTheoMa(maNV);
                connectData.XoaNhanVien(maNV);
                
                dgvDSNhanVien.DataSource = connectData.DanhSachNhanVien();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát hay không?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnLammoi_Click(object sender, EventArgs e)
        {
            RefreshDanhSach();
        }

        private void RefreshDanhSach()
        {
            dgvDSNhanVien.DataSource = connectData.DanhSachNhanVien();
            ClearTextBoxes();
        }

        private void ClearTextBoxes()
        {
            txtMaNV.Text = "";
            txtTenNV.Text = "";
            txtDiaChiNV.Text = "";
            txtQueQuan.Text = "";
            txtSdtNV.Text = "";
            txtEmailNV.Text = "";
            txtCCCD.Text = "";
            txtLuongNV.Text = "";
            rdNam.Checked = false;
            rdNu.Checked = false;
        }

        //hàm kiểm tra
        private bool check()
        {
            if (txtMaNV.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mã nhân viên!!", "Thông báo");
                txtMaNV.Focus();
                return false;
            }
            if (txtTenNV.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tên nhân viên!!", "Thông báo");
                txtTenNV.Focus();
                return false;
            }
            if (!IsNumber(txtSdtNV.Text) || txtSdtNV.Text.Length != 10)
            {
                MessageBox.Show("Số điện thoại không hợp lệ. Vui lòng nhập đủ 10 số!!");
                return false;
            }
            DateTime ngaySinh = dateNgaySinh.Value;
            if (!KiemTraTuoiNV(ngaySinh))
            {
                MessageBox.Show("Nhân viên phải đủ 16 tuổi trở lên!!", "Thông báo");
                return false;
            }
            if (txtDiaChiNV.Text == "")
            {
                MessageBox.Show("Vui lòng nhập địa chỉ nhân viên!!", "Thông báo");
                txtDiaChiNV.Focus();
                return false;
            }
            if (txtQueQuan.Text == "")
            {
                MessageBox.Show("Vui lòng nhập quê quán nhân viên!!", "Thông báo");
                txtQueQuan.Focus();
                return false;
            }
            if(!rdNam.Checked && !rdNu.Checked)
            {
                MessageBox.Show("Vui lòng chọn giới tính nhân viên!!", "Thông báo");
                return false;
            }
            if (txtTenNV.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tên nhân viên!!", "Thông báo");
                txtTenNV.Focus();
                return false;
            }
            if(string.IsNullOrWhiteSpace(txtLuongNV.Text))
            {
                MessageBox.Show("Vui lòng nhập lương nhân viên!!");
                return false;
            }
            if (!KiemTraLuongNV(txtLuongNV.Text))
            {
                MessageBox.Show("Lương nhân viên phải là số và lớn hơn 0!!", "Thông báo");
                return false;
            }

            return true;
        }
        //Hàm kiểm tra tuổi Nhân Viên
        private bool KiemTraTuoiNV(DateTime birth)
        {
            int tuoi = DateTime.Now.Year - birth.Year;

            if (birth.Date > DateTime.Now.Date.AddYears(-tuoi))
            {
                tuoi--;
            }

            return tuoi > 16;
        }
        private bool KiemTraLuongNV(string luong)
        {
            if(decimal.TryParse(luong, out decimal result))
            {
                return result > 0;
            }
            return false;
        }

        private bool IsNumber(string input)
        {
            return input.All(char.IsDigit);
        }

        private void cmbChucVu_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
