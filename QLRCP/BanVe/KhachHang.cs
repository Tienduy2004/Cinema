using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLRCP.BanVe
{
    internal class KhachHang
    {
        private String maKH;
        private String tenKH;
        private String soDT;
        private DateTime ngaySinh;
        private String gioTinh;

        public string MaKH { get => maKH; set => maKH = value; }
        public string TenKH { get => tenKH; set => tenKH = value; }
        public string SoDT { get => soDT; set => soDT = value; }
        public DateTime NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public string GioTinh { get => gioTinh; set => gioTinh = value; }
        public KhachHang() { }
    }
}
