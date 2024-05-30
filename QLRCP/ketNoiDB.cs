using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLRCP
{
    internal class ketNoiDB
    {
        private SqlConnection connection;
        private SqlCommand cmd;
        private SqlDataAdapter da;
        private DataTable dt;

        public SqlConnection Connection { get => connection; set => connection = value; }
        public SqlCommand Cmd { get => cmd; set => cmd = value; }
        public SqlDataAdapter Da { get => da; set => da = value; }
        public DataTable Dt { get => dt; set => dt = value; }
        public ketNoiDB() { 
            this.connection = new SqlConnection("Data Source=MSI;Initial Catalog=HeThongRapChieuPhim1;Integrated Security=True");
        }
        public ketNoiDB(SqlCommand cmd,SqlDataAdapter da,DataTable dt)
        {
            this.cmd = cmd;
            this.da = da;
            this.dt = dt;
        }
        public DataTable LayDanhSach(String cmdText)
        {
            try
            {
                connection.Open();
                cmd = new SqlCommand();
                cmd.CommandText = cmdText;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = connection;
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { connection.Close(); }
            return dt;
        }
    }
    
}
