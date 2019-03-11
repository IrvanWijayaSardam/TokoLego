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
    public partial class cariBarang : Form
    {
        SqlCommand cmd;
        SqlDataAdapter adapter;
        SqlDataReader reader;
        config con = new config();
        public static string idBarang, namaBarang, hargaBarang;
        public static int stok;
        public cariBarang()
        {
            InitializeComponent();
            tampilBarang();
        }

        public void tampilBarang ()
        {
            try
            {
                adapter = new SqlDataAdapter("SELECT * FROM [dbo].[tabel_barang]", con.buka());
                DataSet ds = new DataSet();
                adapter.Fill(ds, "tabel_barang");
                dgrBarang.DataSource = ds.Tables["tabel_barang"].DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtCaribarang_TextChanged(object sender, EventArgs e)
        {
            try
            {
                adapter = new SqlDataAdapter("SELECT * FROM [dbo].[tabel_barang] WHERE nama LIKE '%" + txtCaribarang.Text + "%'", con.buka());
                DataSet ds = new DataSet();
                adapter.Fill(ds, "tabel_barang");
                dgrBarang.DataSource = ds.Tables["tabel_barang"].DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgrBarang_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = this.dgrBarang.Rows[e.RowIndex];
                idBarang = row.Cells["id_barang"].Value.ToString();
                namaBarang = row.Cells["nama"].Value.ToString();
                hargaBarang = row.Cells["harga_jual"].Value.ToString();
                stok = (int)row.Cells["jumlah"].Value;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public string getId ()
        {
            return idBarang;
        }
        public string getNama ()
        {
            return namaBarang;
        }
        public string getHarga()
        {
            return hargaBarang;
        }

        public int getJumlah()
        {
            return stok;
        }

    }
}
