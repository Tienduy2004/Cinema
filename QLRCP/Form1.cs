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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void lịchChiếuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyLichChieu quanLyLichChieu = new QuanLyLichChieu();
            quanLyLichChieu.ShowDialog();
        }

        private void bánVéToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LichChieuBanVe lichChieuBanVe = new LichChieuBanVe();
            lichChieuBanVe.ShowDialog();
        }

        private void phimToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            DoanhThuPhimcs doanhThuPhimcs = new DoanhThuPhimcs();
            doanhThuPhimcs.ShowDialog();
        }

        private void rạpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DoanhThuRap doanhThuRap = new DoanhThuRap();
            doanhThuRap.ShowDialog();
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyKhachHang quanLyKhachHang = new QuanLyKhachHang();
            quanLyKhachHang.ShowDialog();
        }

        private void rạpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rapphim rapphim = new Rapphim();
            rapphim.ShowDialog();
        }

        private void phòngChiếuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Phong phong = new Phong();
            phong.ShowDialog();
        }

        private void phimToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Phim phim = new Phim();
            phim.ShowDialog();
        }

        private void thểLoạiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TheLoai theLoai = new TheLoai();
            theLoai.ShowDialog();
        }

        private void hãngSảnXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HangSanXuat hangSanXuat = new HangSanXuat();
            hangSanXuat.ShowDialog();
        }

        private void nướcSảnXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NuocSanXuat nuocSanXuat = new NuocSanXuat();
            nuocSanXuat .ShowDialog();
        }

        private void nhânViênQuảnLýToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NhanVien nhanVien = new NhanVien();
            nhanVien .ShowDialog();
        }

        private void phimToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            VeDaBan veDaBan = new VeDaBan();
            veDaBan.ShowDialog();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                e.Cancel = true; // Ngăn không cho form đóng
            }
        }

        private void tàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyTaiKhoan quanLyTaiKhoan = new QuanLyTaiKhoan();
            quanLyTaiKhoan .ShowDialog();
        }

        private void pToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FindPhim findPhim = new FindPhim();
            findPhim.ShowDialog();
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TimKiem timKiem = new TimKiem();
            timKiem.ShowDialog();
        }
    }
}
