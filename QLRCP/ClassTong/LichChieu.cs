using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLRCP.ClassTong
{
    public class LichChieu
    {
        private String maShow;
        private String maPhim;
        private String maRap;
        private String maPhong;
        private DateTime ngayChieu;
        private TimeSpan gioChieu;
        private float giaVe;
        private int soVeDaBan;
        private float tongTien;

       
        public LichChieu()
        {
            this.maRap = "";
            this.MaShow = "";
            this.maPhim = "";
            this.maPhong = "";
            this.NgayChieu = DateTime.Now;
            this.GioChieu = TimeSpan.Zero;
            this.GiaVe = 0;
            this.SoVeDaBan = 0; 
            this.TongTien = 0;
        }

        public string MaShow { get => maShow; set => maShow = value; }
        public string MaPhim { get => maPhim; set => maPhim = value; }
        public string MaRap { get => maRap; set => maRap = value; }
        public string MaPhong { get => maPhong; set => maPhong = value; }
        public DateTime NgayChieu { get => ngayChieu; set => ngayChieu = value; }
        public TimeSpan GioChieu { get => gioChieu; set => gioChieu = value; }
        public float GiaVe { get => giaVe; set => giaVe = value; }
        public int SoVeDaBan { get => soVeDaBan; set => soVeDaBan = value; }
        public float TongTien { get => tongTien; set => tongTien = value; }
    }
    
}
