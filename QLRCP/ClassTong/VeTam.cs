using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLRCP.ClassTong
{
    public class VeTam
    {
        private String tenPhong;
        private String tenPhim;
        private String tenGhe;
        private String loaiVe;
        private DateTime ngayChieu;
        private TimeSpan gioChieu;
        private float giaVe;


        public VeTam()
        {
            this.TenPhong = "";
            this.TenPhim = "";
            this.TenGhe = "";
            this.LoaiVe = "";
            this.NgayChieu = DateTime.Now;
            this.GioChieu = TimeSpan.Zero;
            this.GiaVe = 0;
        }

        public string TenPhong { get => tenPhong; set => tenPhong = value; }
        public string TenPhim { get => tenPhim; set => tenPhim = value; }
        public string TenGhe { get => tenGhe; set => tenGhe = value; }
        public string LoaiVe { get => loaiVe; set => loaiVe = value; }
        public DateTime NgayChieu { get => ngayChieu; set => ngayChieu = value; }
        public TimeSpan GioChieu { get => gioChieu; set => gioChieu = value; }
        public float GiaVe { get => giaVe; set => giaVe = value; }
    }
}
