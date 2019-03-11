using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace latLks
{
    public partial class cariKonsumen : Form
    {
        SqlCommand cmd;
        SqlDataAdapter adapter;
        SqlDataReader reader;
        config con = new config();
        public static string idCost, namaCost = "";
        public cariKonsumen()
        {
            InitializeComponent();
            tampilKon();
        }

        private void tampilKon ()
        {
            try
            {
                adapter = new SqlDataAdapter("SELECT * FROM [dbo].[tabel_customer]", con.buka());
                DataSet ds = new DataSet();
                adapter.Fill(ds, "tabel_customer");
                dgrKonsumen.DataSource = ds.Tables["tabel_customer"].DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgrKonsumen_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = this.dgrKonsumen.Rows[e.RowIndex];
                idCost = row.Cells["id_cost"].Value.ToString();
                namaCost = row.Cells["nama"].Value.ToString();
                reopen();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtcariKon_TextChanged(object sender, EventArgs e)
        {
            try
            {
                adapter = new SqlDataAdapter("SELECT * FROM [dbo].[tabel_customer] WHERE nama LIKE '%" + txtcariKon.Text + "%'", con.buka());
                DataSet ds = new DataSet();
                adapter.Fill(ds, "tabel_customer");
                dgrKonsumen.DataSource = ds.Tables["tabel_customer"].DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void reopen()
        {
            penjualan pen = new penjualan();
            pen.Activate();
            this.Close();
        }
        
        public string getId ()
        {
            return idCost;
        }
        public string getNama ()
        {
            return namaCost;
        }

    }
}
