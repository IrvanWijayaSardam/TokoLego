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
    public partial class kelolaBarang : Form
    {
        config con = new config();
        SqlCommand cmd;
        SqlDataAdapter adapter;
        SqlDataReader reader;
        string urut;


        public kelolaBarang()
        {
            InitializeComponent();
            showData();
            autoNumber();
        }

        public void showData ()
        {
            try
            {
                adapter = new SqlDataAdapter("SELECT * FROM [dbo].[tabel_barang]", con.buka());
                DataSet ds = new DataSet();
                adapter.Fill(ds, "tabel_barang");
                dataGridView1.DataSource = ds.Tables["tabel_barang"].DefaultView;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void autoNumber()
        {
            long hitung;
            cmd = new SqlCommand("SELECT id_barang FROM [dbo].[tabel_barang] WHERE id_barang in(SELECT MAX(id_barang) FROM [dbo].[tabel_barang]) ORDER BY id_barang DESC", con.buka());
            reader = cmd.ExecuteReader();
            reader.Read();
            if (reader.HasRows)
            {
                hitung = Convert.ToInt64(reader[0].ToString().Substring(reader["id_barang"].ToString().Length - 12, 4)) + 1;
                string joinstr = "0000" + hitung;
                urut = "BRG-" + joinstr.Substring(joinstr.Length - 4, 4) + "/" + DateTime.Now.ToString("MM/yyyy");
            }
            else
            {
                urut = "BRG-0001/" + DateTime.Now.ToString("MM/yyyy");
            }
            reader.Close();
            txtidBarang.Text = urut;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
            txtidBarang.Text = row.Cells["id_barang"].Value.ToString();
            txtnamaBarang.Text = row.Cells["nama"].Value.ToString();
            txtStok.Text = row.Cells["jumlah"].Value.ToString();
            txtSatuan.Text = row.Cells["satuan"].Value.ToString();
            txthargaBeli.Text = row.Cells["harga_beli"].Value.ToString();
            txthargaJual.Text = row.Cells["harga_jual"].Value.ToString();
        }

        private void btnbarangBaru_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnbarangBaru.Text == "Barang Baru")
                {
                    bersih();
                    btntambahBarang.Visible = true;
                    btnbarangBaru.Text = "Batal";
                    autoNumber();
                }
                else if (btnbarangBaru.Text == "Batal")
                {
                    btntambahBarang.Visible = false;
                    btnbarangBaru.Text = "Barang Baru";
                    bersih();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bersih ()
        {
            txtidBarang.Text = urut;
            txtnamaBarang.Text = "";
            txtSatuan.Text = "";
            txtStok.Text = "";
            txthargaBeli.Text = "";
            txthargaJual.Text = "";

        }

        private void btntambahBarang_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("INSERT INTO [dbo].[tabel_barang] VALUES ('" + txtidBarang.Text + "','" + txtnamaBarang.Text + "','" + txtStok.Text + "','" + txtSatuan.Text + "','" + txthargaBeli.Text + "','" + txthargaJual.Text + "')", con.buka());
                reader = cmd.ExecuteReader();
                MessageBox.Show("Berhasil Menambah Barang");
                showData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnhapusBarang_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("DELETE FROM [dbo].[tabel_barang] WHERE id_barang = '" + txtidBarang.Text + "'", con.buka());
                reader = cmd.ExecuteReader();
                MessageBox.Show("Barang Telah Terhapus");
                showData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnupdateBarang_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("UPDATE [dbo].[tabel_barang] SET nama='" + txtnamaBarang.Text + "',jumlah = '" + txtStok.Text + "',satuan = '" + txtSatuan.Text + "',harga_beli = '" + txthargaBeli.Text + "', harga_jual = '" + txthargaJual.Text + "' WHERE id_barang = '"+txtidBarang.Text+"'", con.buka());
                reader = cmd.ExecuteReader();
                showData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtcariBarang_TextChanged(object sender, EventArgs e)
        {
            try
            {
                adapter = new SqlDataAdapter("SELECT * FROM [dbo].[tabel_barang] WHERE nama LIKE '%" + txtcariBarang.Text + "%'", con.buka());
                DataSet ds = new DataSet();
                adapter.Fill(ds, "tabel_barang");
                dataGridView1.DataSource = ds.Tables["tabel_barang"].DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
