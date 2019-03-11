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
    public partial class customerManager : Form
    {
        config con = new config();
        SqlCommand cmd;
        SqlDataAdapter adapter;
        SqlDataReader reader;
        string urut;

        public customerManager()
        {
            InitializeComponent();
            tampilAwal();
            autoCusid();
        }

        private void tampilAwal()
        {
            try
            {
                adapter = new SqlDataAdapter("SELECT * FROM [dbo].[tabel_customer]", con.buka());
                DataSet ds = new DataSet();
                adapter.Fill(ds, "tabel_customer");
                dataGridView1.DataSource = ds.Tables["tabel_customer"].DefaultView;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                txtIdPel.Text = row.Cells["id_cost"].Value.ToString();
                txtNama.Text = row.Cells["nama"].Value.ToString();
                txtTelp.Text = row.Cells["no_telp"].Value.ToString();
                txtAlamat.Text = row.Cells["alamat"].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void bersih()
        {
            txtNama.Text = "";
            txtAlamat.Text = "";
            txtTelp.Text = "";
        }
        private void autoCusid()
        {
            long hitung;
            cmd = new SqlCommand("SELECT id_cost FROM [dbo].[tabel_customer] WHERE id_cost IN (SELECT MAX (id_cost) FROM [dbo].[tabel_customer]) ORDER BY id_cost DESC", con.buka());
            reader = cmd.ExecuteReader();
            reader.Read();
            if (reader.HasRows)
            {
                hitung = Convert.ToInt64(reader[0].ToString().Substring(reader["id_cost"].ToString().Length - 4, 4)) + 1;
                string joinstr = "0000" + hitung;
                urut = "CUS" + joinstr.Substring(joinstr.Length - 5, 5);
            }
            else
            {
                urut = "CUS00001";
            }
            txtIdPel.Text = urut;
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (txtNama.Text == "" || txtAlamat.Text == "" || txtTelp.Text == "")
            {
                MessageBox.Show("Silahkan Pastikan Semua Kolom Terisi");
            }
            else
            {
                try
                {
                    cmd = new SqlCommand("INSERT INTO [dbo].[tabel_customer] VALUES ('" + txtIdPel.Text + "','" + txtNama.Text + "','" + txtAlamat.Text + "','" + txtTelp.Text + "')", con.buka());
                    reader = cmd.ExecuteReader();
                    MessageBox.Show("Berhasil Menambahkan Pelanggan");
                    tampilAwal();
                    bersih();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (btnNew.Text == "New")
            {
                btnNew.Text = "Cancel";
                btnSimpan.Visible = true;
                txtIdPel.Text = urut;
                bersih();
            }
            else if (btnNew.Text == "Cancel")
            {
                btnSimpan.Visible = false;
                btnNew.Text = "New";
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtNama.Text == "" || txtAlamat.Text == "" || txtTelp.Text == "")
            {
                MessageBox.Show("Silahkan Pastikan Semua Kolom Terisi");
            }

            else
            {
                try
                {
                    cmd = new SqlCommand("UPDATE [dbo].[tabel_customer] SET nama='" + txtNama.Text + "',alamat = '" + txtAlamat.Text + "', no_telp = '" + txtTelp.Text + "' WHERE id_cost = '" + txtIdPel.Text + "'", con.buka());
                    reader = cmd.ExecuteReader();
                    MessageBox.Show("Berhasil Meng Update Data Pelanggan");
                    tampilAwal();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtNama.Text == "" || txtAlamat.Text == "" || txtTelp.Text == "")
            {
                MessageBox.Show("Pastikan Semua Kolom Terisi Dengan Benar");
            }
            else
            {
                try
                {
                    cmd = new SqlCommand("DELETE FROM [dbo].[tabel_customer] WHERE id_cost = '" + txtIdPel.Text + "'", con.buka());
                    reader = cmd.ExecuteReader();
                    MessageBox.Show("Berhasil Menghapus Data");
                    tampilAwal();
                    bersih();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void txtCari_TextChanged(object sender, EventArgs e)
        {
            try
            {
                adapter = new SqlDataAdapter("SELECT * FROM [dbo].[tabel_customer] WHERE nama LIKE '%" + txtCari.Text + "%'", con.buka());
                DataSet ds = new DataSet();
                adapter.Fill(ds, "tabel_customer");
                dataGridView1.DataSource = ds.Tables["tabel_customer"].DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
