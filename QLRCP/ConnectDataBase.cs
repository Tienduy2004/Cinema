using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLRCP
{
    internal class ConnectDataBase
    {
        //connect db
        private string connectDB = "Data Source=MSI;Initial Catalog=HeThongRapChieuPhim1;Integrated Security=True";

        /// <summary>
        /// Rạp phim
        /// </summary>
        /// <returns></returns>
        //store lấy ds rạp
        public DataTable LayDanhSachRapPhim()
        {
            DataTable dtRapphim = new DataTable();

            using (SqlConnection con = new SqlConnection(connectDB))
            {
                try
                {
                    con.Open();
                    SqlCommand cmdRapphim = new SqlCommand("LayDSRapPhim", con);
                    cmdRapphim.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter daRapphim = new SqlDataAdapter(cmdRapphim);
                    daRapphim.Fill(dtRapphim);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi" + ex.Message, "Thông báo");
                }
                finally { con.Close(); }
            }
            return dtRapphim;
        }
        //thêm rạp phim
        public void ThemRapPhim(string maRap, string tenRap, string diachiRap, string timeHoatdong, string sdtRap)
        {
            using (SqlConnection connection = new SqlConnection(connectDB))
            {
                try
                {
                    connection.Open();
                    SqlCommand cmdInsert = new SqlCommand("INSERT INTO Rapphim (MaRap, TenRap, DiaChiRap, TimeHoatdong, SdtRap) VALUES (@MaRap, @TenRap, @DiaChiRap, @TimeHoatdong, @SDTRap)", connection);

                    cmdInsert.Parameters.AddWithValue("@MaRap", maRap);
                    cmdInsert.Parameters.AddWithValue("@TenRap", tenRap);
                    cmdInsert.Parameters.AddWithValue("@DiaChiRap", diachiRap);
                    cmdInsert.Parameters.AddWithValue("@TimeHoatDong", timeHoatdong);
                    cmdInsert.Parameters.AddWithValue("@SdtRap", sdtRap);

                    cmdInsert.ExecuteNonQuery();
                    MessageBox.Show("Thêm dữ liệu thành công!", "Thông báo");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Thông báo");
                }
                finally { connection.Close(); }
            }
        }
        //sửa rạp phim
        public void SuaRapPhim(string maRap, string tenRap, string diaChiRap, string timeHoatDong, string sdtRap)
        {
            using (SqlConnection connection = new SqlConnection(connectDB))
            {
                try
                {
                    connection.Open();
                    SqlCommand cmdUpdate = new SqlCommand("UPDATE Rapphim SET TenRap = @TenRap, DiaChiRap = @DiaChiRap, TimeHoatDong = @TimeHoatDong, SDTRap = @SDTRap WHERE MaRap = @MaRap", connection);

                    cmdUpdate.Parameters.AddWithValue("@MaRap", maRap);
                    cmdUpdate.Parameters.AddWithValue("@TenRap", tenRap);
                    cmdUpdate.Parameters.AddWithValue("@DiaChiRap", diaChiRap);
                    cmdUpdate.Parameters.AddWithValue("@TimeHoatDong", timeHoatDong);
                    cmdUpdate.Parameters.AddWithValue("@SdtRap", sdtRap);

                    cmdUpdate.ExecuteNonQuery();
                    MessageBox.Show("Sửa thông tin thành công", "Thông báo");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Thông báo");
                }
                finally { connection.Close(); }
            }
        }
        // store lấy tt rạp
        public DataTable LayThongTinRapPhim(string maRap)
        {
            DataTable dtThongTinRap = new DataTable();
            using (SqlConnection con = new SqlConnection(connectDB))
            {
                try
                {
                    con.Open();
                    SqlCommand cmdThongTinRap = new SqlCommand("LayThongTinRapPhim", con);
                    cmdThongTinRap.CommandType = CommandType.StoredProcedure;

                    //thêm tham số
                    cmdThongTinRap.Parameters.AddWithValue("@MaRap", maRap);

                    SqlDataAdapter daThongTinRap = new SqlDataAdapter(cmdThongTinRap);
                    daThongTinRap.Fill(dtThongTinRap);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Thông báo");
                }
                finally { con.Close(); }
            }
            return dtThongTinRap;
        }
        // xóa rạp
        public void XoaRapPhim(string maRap)
        {
            using (SqlConnection con = new SqlConnection(connectDB))
            {
                try
                {
                    con.Open();
                    SqlCommand cmdRemove = new SqlCommand("XoaRapPhim", con);
                    cmdRemove.CommandType = CommandType.StoredProcedure;

                    //tham số
                    cmdRemove.Parameters.AddWithValue("@MaRap", maRap);

                    cmdRemove.ExecuteNonQuery();
                    MessageBox.Show("Xóa thành công", "Thông báo");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Thông báo");
                }
                finally { con.Close(); }
            }
        }



        /// <summary>
        /// Thể loại phim
        /// </summary>
        /// <returns></returns>
        //Hiển thị danh sách rạp phim
        public DataTable LayDanhSachTheLoai()
        {
            DataTable dtTheLoai = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectDB))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmdTheLoai = new SqlCommand("LayDanhSachTheLoai", conn);
                    cmdTheLoai.CommandType = CommandType.StoredProcedure;


                    SqlDataAdapter daTheLoai = new SqlDataAdapter(cmdTheLoai);
                    daTheLoai.Fill(dtTheLoai);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Thông báo");
                }
                finally { conn.Close(); }
            }
            return dtTheLoai;
        }
        //lấy 1 thể loại
        public DataTable LayThongTinTheLoai(string maTL)
        {
            DataTable dtTheLoai = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectDB))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmdTheLoai = new SqlCommand("LayThongTinTheLoai", conn);
                    cmdTheLoai.CommandType = CommandType.StoredProcedure;

                    //thêm tham số
                    cmdTheLoai.Parameters.AddWithValue("@MaTheLoai", maTL);

                    SqlDataAdapter daTheLoai = new SqlDataAdapter(cmdTheLoai);
                    daTheLoai.Fill(dtTheLoai);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
                finally { conn.Close(); }
            }
            return dtTheLoai;
        }
        //thêm thể loại
        public void ThemTheLoai(string maTL, string tenTL)
        {
            using (SqlConnection conn = new SqlConnection(connectDB))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmdTL = new SqlCommand("ThemTheLoai", conn);
                    cmdTL.CommandType = CommandType.StoredProcedure;

                    //tham số
                    cmdTL.Parameters.Add("@maTheLoai", SqlDbType.NVarChar, 10).Value = maTL;
                    cmdTL.Parameters.Add("@tenTheLoai", SqlDbType.NVarChar, 100).Value = tenTL;
                    cmdTL.ExecuteNonQuery();

                    MessageBox.Show("Thêm thành công");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Error");
                }
                finally { conn.Close(); }
            }
        }
        //xóa thể loại
        public void XoaTheLoai(string maTL)
        {
            using (SqlConnection conn = new SqlConnection(connectDB))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmdTL = new SqlCommand("XoaTheLoai", conn);
                    cmdTL.CommandType = CommandType.StoredProcedure;

                    //tham số
                    cmdTL.Parameters.AddWithValue("@MaTheLoai", maTL);
                    cmdTL.ExecuteNonQuery();

                    MessageBox.Show("Xóa thành công");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Error");
                }
                finally { conn.Close(); }
            }
        }
        //sửa thể loại
        public void SuaTheLoai(string maTL, string tenTL)
        {
            using (SqlConnection conn = new SqlConnection(connectDB))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmdTL = new SqlCommand("SuaTheLoai", conn);
                    cmdTL.CommandType = CommandType.StoredProcedure;

                    //tham số
                    cmdTL.Parameters.AddWithValue("@MaTheLoai", maTL);
                    cmdTL.Parameters.AddWithValue("@TenTheLoai", tenTL);

                    cmdTL.ExecuteNonQuery();
                    MessageBox.Show("Sửa thành công", "Thông báo");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Error");
                }
                finally { conn.Close(); }
            }
        }

        /// <summary>
        /// Nước Sản Xuất
        /// </summary>
        /// <returns></returns>
        //Lấy danh sách nước sản xuất
        public DataTable LayDanhSachNuocSX()
        {
            DataTable dtNuocSX = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectDB))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmdNuocSX = new SqlCommand("LayDanhSachNuocSX", conn);
                    cmdNuocSX.CommandType = CommandType.StoredProcedure;


                    SqlDataAdapter daTheLoai = new SqlDataAdapter(cmdNuocSX);
                    daTheLoai.Fill(dtNuocSX);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Thông báo");
                }
            }
            return dtNuocSX;
        }
        //thêm nước sản xuất
        public void ThemNuocSX(string maNuoc, string tenNuoc)
        {
            using (SqlConnection conn = new SqlConnection(connectDB))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmdNuoc = new SqlCommand("ThemNuocSX", conn);
                    cmdNuoc.CommandType = CommandType.StoredProcedure;

                    //tham số
                    cmdNuoc.Parameters.Add("@MaNuocSX", SqlDbType.NVarChar, 10).Value = maNuoc;
                    cmdNuoc.Parameters.Add("@TenNuocSX", SqlDbType.NVarChar, 100).Value = tenNuoc;
                    cmdNuoc.ExecuteNonQuery();

                    MessageBox.Show("Thêm thành công", "Thông báo");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Error");
                }
            }
        }
        //Xóa nước sản xuất
        public void XoaNuocSX(string maNuoc)
        {
            using (SqlConnection conn = new SqlConnection(connectDB))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmdNuoc = new SqlCommand("XoaNuocSX", conn);
                    cmdNuoc.CommandType = CommandType.StoredProcedure;

                    //tham số
                    cmdNuoc.Parameters.AddWithValue("@MaNuocSX", maNuoc);
                    cmdNuoc.ExecuteNonQuery();

                    MessageBox.Show("Xóa thành công", "Thông báo");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Error");
                }
            }
        }
        //Sửa nước sản xuất
        public void SuaNuocSX(string maNuoc, string tenNuoc)
        {
            using (SqlConnection conn = new SqlConnection(connectDB))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmdNuoc = new SqlCommand("SuaNuocSX", conn);
                    cmdNuoc.CommandType = CommandType.StoredProcedure;

                    //tham số
                    cmdNuoc.Parameters.AddWithValue("@MaNuocSX", maNuoc);
                    cmdNuoc.Parameters.AddWithValue("@TenNuocSX", tenNuoc);
                    cmdNuoc.ExecuteNonQuery();

                    MessageBox.Show("Sửa thành công", "Thông báo");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Error");
                }
            }
        }
        //lấy 1 thông tin
        public DataTable LayThongTinNuocSX(string maNuocSX)
        {
            DataTable dtNuocSX = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectDB))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmdNuoc = new SqlCommand("LayThongTinNuocSX", conn);
                    cmdNuoc.CommandType = CommandType.StoredProcedure;

                    //tham số
                    cmdNuoc.Parameters.AddWithValue("@MaNuocSX", maNuocSX);

                    SqlDataAdapter daNuocSX = new SqlDataAdapter(cmdNuoc);
                    daNuocSX.Fill(dtNuocSX);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Error");
                }
            }
            return dtNuocSX;
        }

        /// <summary>
        /// Hãng phim
        /// </summary>
        /// <returns></returns>
        //Danh sách hãng phim
        public DataTable DanhSachHangSX()
        {
            DataTable dtHang = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectDB))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmdHang = new SqlCommand("DanhSachHangSX", conn);
                    cmdHang.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter daHang = new SqlDataAdapter(cmdHang);
                    daHang.Fill(dtHang);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Error");
                }
                finally
                {
                    conn.Close();
                }
            }
            return dtHang;
        }
        //Lấy danh sách hãng phim
        public DataTable LayThongTinHangSX(string maHang)
        {
            DataTable dtHang = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectDB))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmdHang = new SqlCommand("LayThongTinHangSX", conn);
                    cmdHang.CommandType = CommandType.StoredProcedure;

                    //tham số
                    cmdHang.Parameters.AddWithValue("@MaHangSX", maHang);

                    SqlDataAdapter daHang = new SqlDataAdapter(cmdHang);
                    daHang.Fill(dtHang);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Error");
                }
                finally { conn.Close(); }
            }
            return dtHang;
        }
        //Thêm hãng 
        public void ThemHangSX(string maHang, string tenHang)
        {
            using (SqlConnection conn = new SqlConnection(connectDB))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmdHang = new SqlCommand("ThemHangSX", conn);
                    cmdHang.CommandType = CommandType.StoredProcedure;

                    //tham so
                    cmdHang.Parameters.Add("@MaHangSX", SqlDbType.NVarChar, 10).Value = maHang;
                    cmdHang.Parameters.Add("@TenHangSX", SqlDbType.NVarChar, 100).Value = tenHang;

                    cmdHang.ExecuteNonQuery();
                    MessageBox.Show("Thêm thành công", "Thông báo");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Error");
                }
                finally { conn.Close(); }
            }
        }
        //xóa hãng
        public void XoaHangSX(string maHang)
        {
            using (SqlConnection conn = new SqlConnection(connectDB))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmdHang = new SqlCommand("XoaHangSX", conn);
                    cmdHang.CommandType = CommandType.StoredProcedure;

                    //tham so
                    cmdHang.Parameters.AddWithValue("@MaHangSX", maHang);
                    cmdHang.ExecuteNonQuery();

                    MessageBox.Show("Xóa thành công", "Thông báo");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Error");
                }
            }
        }
        // sửa hãng
        public void SuaHangSX(string maHang, string tenHang)
        {
            using (SqlConnection conn = new SqlConnection(connectDB))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmdHang = new SqlCommand("SuaHangSX", conn);
                    cmdHang.CommandType = CommandType.StoredProcedure;

                    //tham so
                    cmdHang.Parameters.AddWithValue("@MaHangSX", maHang);
                    cmdHang.Parameters.AddWithValue("@TenHangSX", tenHang);
                    cmdHang.ExecuteNonQuery();

                    MessageBox.Show("Sửa thành công", "Thông báo");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Error");
                }
            }
        }

        /// <summary>
        /// Phim
        /// </summary>
        /// <returns></returns>
        //Danh sách phim
        public DataTable DanhSachPhim()
        {
            DataTable dtPhim = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectDB))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmdPhim = new SqlCommand("DanhSachPhim", conn);
                    cmdPhim.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter daPhim = new SqlDataAdapter(cmdPhim);
                    daPhim.Fill(dtPhim);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Error");
                }
                finally { conn.Close(); }
            }
            return dtPhim;
        }
        //Lấy thông tin phim
        public DataTable LayThongTinPhim(string maPhim)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectDB))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmdPhim = new SqlCommand("LayThongTinPhim", conn);
                    cmdPhim.CommandType = CommandType.StoredProcedure;

                    //tham số
                    cmdPhim.Parameters.AddWithValue("@MaPhim", maPhim);

                    SqlDataAdapter daPhim = new SqlDataAdapter(cmdPhim);
                    daPhim.Fill(dt);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Error");
                }
                finally { conn.Close(); }
            }
            return dt;
        }
        //Thêm phim
        public void ThemPhim(string maPhim, string tenPhim, string daoDien, string dienVien, string theloaiPhim, string hangSX, string nuocSX, DateTime namSX, string noidungPhim, DateTime thoiluongPhim, DateTime timeStart, DateTime timeEnd)
        {
            using (SqlConnection conn = new SqlConnection(connectDB))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmdPhim = new SqlCommand("ThemPhim", conn);
                    cmdPhim.CommandType = CommandType.StoredProcedure;

                    //tham số
                    cmdPhim.Parameters.AddWithValue("@maPhim", maPhim);
                    cmdPhim.Parameters.AddWithValue("@tenPhim", tenPhim);
                    cmdPhim.Parameters.AddWithValue("@daoDien", daoDien);
                    cmdPhim.Parameters.AddWithValue("@dienVien", dienVien);
                    cmdPhim.Parameters.AddWithValue("@maTheLoai", theloaiPhim);
                    cmdPhim.Parameters.AddWithValue("@maHangSX", hangSX);
                    cmdPhim.Parameters.AddWithValue("@maNuocSX", nuocSX);
                    cmdPhim.Parameters.AddWithValue("@namSX", namSX);
                    cmdPhim.Parameters.AddWithValue("@noidungPhim", noidungPhim);
                    cmdPhim.Parameters.AddWithValue("@thoiluongPhim", thoiluongPhim);
                    cmdPhim.Parameters.AddWithValue("@timeStart", timeStart);
                    cmdPhim.Parameters.AddWithValue("@timeEnd", timeEnd);

                    cmdPhim.ExecuteNonQuery();
                    MessageBox.Show("Thêm thành công", "Thông báo");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Error");
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        //Sửa phim 
        public void SuaPhim(string maPhim, string tenPhim, string daoDien, string dienVien, string theloaiPhim, string hangSX, string nuocSX, DateTime namSX, string noidungPhim, DateTime thoiluongPhim, DateTime timeStart, DateTime timeEnd)
        {
            using (SqlConnection conn = new SqlConnection(connectDB))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmdPhim = new SqlCommand("SuaPhim", conn);
                    cmdPhim.CommandType = CommandType.StoredProcedure;

                    //tham soos
                    cmdPhim.Parameters.AddWithValue("@maPhim", maPhim);
                    cmdPhim.Parameters.AddWithValue("@tenPhim", tenPhim);
                    cmdPhim.Parameters.AddWithValue("@daoDien", daoDien);
                    cmdPhim.Parameters.AddWithValue("@dienVien", dienVien);
                    cmdPhim.Parameters.AddWithValue("@maTheLoai", theloaiPhim);
                    cmdPhim.Parameters.AddWithValue("@maHangSX", hangSX);
                    cmdPhim.Parameters.AddWithValue("@maNuocSX", nuocSX);
                    cmdPhim.Parameters.AddWithValue("@namSX", namSX);
                    cmdPhim.Parameters.AddWithValue("@noidungPhim", noidungPhim);
                    cmdPhim.Parameters.AddWithValue("@thoiluongPhim", thoiluongPhim);
                    cmdPhim.Parameters.AddWithValue("@timeStart", timeStart);
                    cmdPhim.Parameters.AddWithValue("@timeEnd", timeEnd);

                    cmdPhim.ExecuteNonQuery();
                    MessageBox.Show("Sửa thành công", "Thông báo");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Error");
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        //Xóa phim
        public void XoaPhim(string maPhim)
        {
            using (SqlConnection conn = new SqlConnection(connectDB))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmdPhim = new SqlCommand("XoaPhim", conn);
                    cmdPhim.CommandType = CommandType.StoredProcedure;

                    cmdPhim.Parameters.AddWithValue("@MaPhim", maPhim);
                    cmdPhim.ExecuteNonQuery();

                    MessageBox.Show("Xóa thành công", "Thông báo");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Error");
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        /// <summary>
        /// Phòng
        /// </summary>
        /// <returns></returns>
        // danh sách phòng
        public DataTable DanhSachPhong()
        {
            DataTable dtPhong = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectDB))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmdPhong = new SqlCommand("DanhSachPhong", conn);
                    cmdPhong.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter daPhong = new SqlDataAdapter(cmdPhong);
                    daPhong.Fill(dtPhong);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Error");
                }
                finally { conn.Close(); }
            }
            return dtPhong;
        }
        //lấy thông tin phòng
        public DataTable LayThongTinPhong(string maPhong)
        {
            DataTable dtPhong = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectDB))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmdPhong = new SqlCommand("LayThongTinPhong", conn);
                    cmdPhong.CommandType = CommandType.StoredProcedure;

                    cmdPhong.Parameters.AddWithValue("@MaPhong", maPhong);

                    SqlDataAdapter daPhong = new SqlDataAdapter(cmdPhong);
                    daPhong.Fill(dtPhong);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Error");
                }
                finally
                {
                    conn.Close();
                }
            }
            return dtPhong;
        }
        //thêm phòng
        public void ThemPhong(string maPhong, string maRap, string tenPhong, string nhanVien, string tinhtrangPhong)
        {
            using (SqlConnection conn = new SqlConnection(connectDB))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmdPhong = new SqlCommand("ThemPhong", conn);
                    cmdPhong.CommandType = CommandType.StoredProcedure;

                    cmdPhong.Parameters.Add(new SqlParameter("@maPhong", SqlDbType.NVarChar, 10)).Value = maPhong;
                    cmdPhong.Parameters.Add(new SqlParameter("@maRap", SqlDbType.NVarChar, 10)).Value = maRap;
                    cmdPhong.Parameters.Add(new SqlParameter("@tenPhong", SqlDbType.NVarChar, 100)).Value = tenPhong;
                    cmdPhong.Parameters.Add(new SqlParameter("@maNV", SqlDbType.NVarChar, 10)).Value = nhanVien;
                    cmdPhong.Parameters.Add(new SqlParameter("@tinhtrangPhong", 30)).Value = tinhtrangPhong;

                    cmdPhong.ExecuteNonQuery();
                    MessageBox.Show("Thêm thành công", "Thông báo");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Error");
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        //Sửa phòng
        public void SuaPhong(string maPhong, string tenPhong, string nhanVien, string tinhtrangPhong)
        {
            SqlConnection conn = new SqlConnection(connectDB);

            try
            {
                    
                    conn.Open();
                    SqlCommand cmdPhong = new SqlCommand("SuaPhong", conn);
                    cmdPhong.CommandType = CommandType.StoredProcedure;
                    //tham so
                    cmdPhong.Parameters.AddWithValue("@MaPhong", maPhong);
                    cmdPhong.Parameters.AddWithValue("@TenPhong", tenPhong);
                    cmdPhong.Parameters.AddWithValue("@MaNV", nhanVien);
                    cmdPhong.Parameters.AddWithValue("@TinhTrangPhong", tinhtrangPhong);
                    cmdPhong.ExecuteNonQuery();
                    MessageBox.Show("Sửa thành công", "Thông báo");
             }
             catch (Exception ex)
             {
               MessageBox.Show("Lỗi: " + ex.Message, "Error");
             }
             finally { conn.Close(); }
            
        }
        //Xóa phòng 
        public void XoaPhong(string maPhong, string maRap)
        {
            using (SqlConnection conn = new SqlConnection(connectDB))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmdPhong = new SqlCommand("XoaPhong", conn);
                    cmdPhong.CommandType = CommandType.StoredProcedure;

                    cmdPhong.Parameters.AddWithValue("@MaPhong", maPhong);
                    cmdPhong.Parameters.AddWithValue("@MaRap", maRap);

                    cmdPhong.ExecuteNonQuery();

                    MessageBox.Show("Xóa thành công", "Thông báo");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Error");
                }
                finally { conn.Close(); }
            }
        }
        //Danh sách nhân viên trong combobox Phong
        public DataTable DanhSachComboboxNhanVien(string maRap)
        {
            DataTable dtNhanVien = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectDB))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmdNhanVien = new SqlCommand("DanhSachNhanVien", conn);
                    cmdNhanVien.CommandType = CommandType.StoredProcedure;

                    cmdNhanVien.Parameters.AddWithValue("@MaRap", maRap);

                    SqlDataAdapter daNhanVien = new SqlDataAdapter(cmdNhanVien);
                    daNhanVien.Fill(dtNhanVien);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Error");
                }
                finally { conn.Close(); }
            }
            return dtNhanVien;
        }
        public void ThemNhanVien(string maNV, string maRap, string tenNV, string sdtNV, DateTime dateNV, string diachiNV, string quequanNV, string genderNV, string emailNV, string CCCD, string maChucvu, string luongNV)
        {
            using (SqlConnection con = new SqlConnection(connectDB))
            {
                try
                {
                    con.Open();
                    SqlCommand cmdNV = new SqlCommand("ThemNhanVien", con);
                    cmdNV.CommandType = CommandType.StoredProcedure;

                    cmdNV.Parameters.AddWithValue("@maNV", maNV);
                    cmdNV.Parameters.AddWithValue("@maRap", maRap);
                    cmdNV.Parameters.AddWithValue("@tenNV", tenNV);
                    cmdNV.Parameters.AddWithValue("@sdtNV", sdtNV);
                    cmdNV.Parameters.AddWithValue("@dateNV", dateNV);
                    cmdNV.Parameters.AddWithValue("@diaChiNV", diachiNV);
                    cmdNV.Parameters.AddWithValue("@queQuanNV", quequanNV);
                    cmdNV.Parameters.AddWithValue("@genderNV", genderNV);
                    cmdNV.Parameters.AddWithValue("@emailNV", emailNV);
                    cmdNV.Parameters.AddWithValue("@cccdNV", CCCD);
                    cmdNV.Parameters.AddWithValue("@maChucVu", maChucvu);
                    cmdNV.Parameters.AddWithValue("@mucLuongNV", luongNV);

                    cmdNV.ExecuteNonQuery();
                    MessageBox.Show("Thêm thành công", "Thông báo");

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Error");
                }
            }

        }
        public DataTable LayChucVu()
        {
            DataTable dtChucvu = new DataTable();
            using (SqlConnection con = new SqlConnection(connectDB))
            {
                try
                {
                    con.Open();
                    SqlCommand cmdChucVu = new SqlCommand("LayChucVu", con);
                    cmdChucVu.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter daChucVu = new SqlDataAdapter(cmdChucVu);
                    daChucVu.Fill(dtChucvu);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Error");
                }
            }
            return dtChucvu;
        }
        //Danh sách nhân viên
        public DataTable DanhSachNhanVien()
        {
            DataTable dtNhanVien = new DataTable();
            using (SqlConnection con = new SqlConnection(connectDB))
            {
                try
                {
                    con.Open();
                    SqlCommand cmdNhanVien = new SqlCommand("InDSNV", con);
                    cmdNhanVien.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter daNhanVien = new SqlDataAdapter(cmdNhanVien);
                    daNhanVien.Fill(dtNhanVien);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Error");
                }
            }
            return dtNhanVien;
        }
        //lấy rạp phim


        public void SuaNhanVien(string maNV, string maRap, string tenNV, string sdtNV, DateTime dateNV, string diachiNV, string quequanNV, string genderNV, string emailNV, string CCCD, string maChucvu, string luongNV)
        {
            using (SqlConnection con = new SqlConnection(connectDB))
            {
                try
                {
                    con.Open();
                    SqlCommand cmdSuaNV = new SqlCommand("SuaNhanVien", con);
                    cmdSuaNV.CommandType = CommandType.StoredProcedure;

                    cmdSuaNV.Parameters.AddWithValue("@maNV", maNV);
                    cmdSuaNV.Parameters.AddWithValue("@maRap", maRap);
                    cmdSuaNV.Parameters.AddWithValue("@tenNV", tenNV);
                    cmdSuaNV.Parameters.AddWithValue("@sdtNV", sdtNV);
                    cmdSuaNV.Parameters.AddWithValue("@dateNV", dateNV);
                    cmdSuaNV.Parameters.AddWithValue("@diaChiNV", diachiNV);
                    cmdSuaNV.Parameters.AddWithValue("@queQuanNV", quequanNV);
                    cmdSuaNV.Parameters.AddWithValue("@genderNV", genderNV);
                    cmdSuaNV.Parameters.AddWithValue("@emailNV", emailNV);
                    cmdSuaNV.Parameters.AddWithValue("@cccdNV", CCCD);
                    cmdSuaNV.Parameters.AddWithValue("@maChucVu", maChucvu);
                    cmdSuaNV.Parameters.AddWithValue("@mucLuongNV", luongNV);

                    cmdSuaNV.ExecuteNonQuery();
                    MessageBox.Show("Sửa thành công", "Thông báo");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Error");
                }
            }
        }
        public void XoaNhanVien(String MaNV)
        {
            DialogResult result = MessageBox.Show("Chắc chắn bạn muốn xóa nhân viên này không?", "Xác nhận xóa", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                using (SqlConnection con = new SqlConnection(connectDB))
                    try
                    {
                        con.Open();
                        using (SqlCommand cmdXoaNV = new SqlCommand("XoaNhanVien", con))
                        {
                            cmdXoaNV.CommandType = CommandType.StoredProcedure;
                            cmdXoaNV.Parameters.AddWithValue("@maNV", MaNV);

                            cmdXoaNV.ExecuteNonQuery();
                        }
                        MessageBox.Show("Xóa thành công!!", "Thông báo");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Xóa không thành công!!. Lỗi:" + ex.Message, "Thông báo");
                    }
            }
        }
        public void CapNhapNVChoPhong(string MaNV, string maPhong) {
            using (SqlConnection con = new SqlConnection(connectDB))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("CapNhatNVChoPhong", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@manv", MaNV);
                    cmd.Parameters.AddWithValue("@maphong", maPhong);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Error");
                }
            }
        }
        public void LayDanhSachPhongTheoMa(string MaNV)
        {
            using (SqlConnection con = new SqlConnection(connectDB))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("LayPhongTheoMa", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@maNV", MaNV);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if(dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            string maPhong = dt.Rows[i]["maPhong"].ToString();
                            CapNhapNVChoPhong(MaNV, maPhong);
                        }
                    }
                    MessageBox.Show("Sửa thành công", "Thông báo");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Error");
                }
            }
        }
        public void XoaGheTuDong(string maPhong)
        {
            SqlConnection conn = new SqlConnection(connectDB);

            try
            {

                conn.Open();
                SqlCommand cmdPhong = new SqlCommand("XoaGhePhong", conn);
                cmdPhong.CommandType = CommandType.StoredProcedure;
                //tham so
                cmdPhong.Parameters.AddWithValue("@maPhong", maPhong);
                
                cmdPhong.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Error");
            }
            finally { conn.Close(); }
        }
    }
}
