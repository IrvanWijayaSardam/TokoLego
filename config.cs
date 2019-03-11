
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace latLks
{
    class config
    {
        SqlConnection cnn;
        private string strkoneksi = null;
        
        public SqlConnection buka()
        {
            try
            { 
            strkoneksi = "Server = .\\SQLEXPRESS; Database = kasir ; Integrated Security = SSPI";
            cnn = new SqlConnection(strkoneksi);
            cnn.Open();
            //MessageBox.Show("Berhasil Konek");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return cnn;
        }       
    
    }
}
