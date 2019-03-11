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
    public partial class kelolaUser : Form
    {
        config con = new config();
        SqlCommand cmd;
        SqlDataAdapter adapter;
        SqlDataReader reader;
        string urut;
        string jabatan;
        public kelolaUser()
        {
            InitializeComponent();
            tampilAwal();
            autoUserid();
        }

        private void tampilAwal()
        {
            try
            {
                adapter = new SqlDataAdapter("SELECT * FROM [dbo].[tabel_user]", con.buka());
                DataSet ds = new DataSet();
                adapter.Fill(ds, "tabel_user");
                dataGridView1.DataSource = ds.Tables["tabel_user"].DefaultView;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                bersih();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtidUser.Text == "" || txtNama.Text == "" || txtPassword.Text == "" || txtTelp.Text == "" || txtUsername.Text =="")
            {
                MessageBox.Show("Silahkan Isi Semua Form Dengan Benar");
            }

            else
            {
                try
                {
                    string akses = comboBox1.Items[comboBox1.SelectedIndex].ToString();
                    if (akses == "kasir")
                    {
                        jabatan = "1";
                    }
                    else if (akses == "admin")
                    {
                        jabatan = "2";
                    }
                    else if (akses == "manager")
                    {
                        jabatan = "3";
                    }
                    else
                    {
                        MessageBox.Show("Error");
                    }
                    cmd = new SqlCommand("INSERT INTO [dbo].[tabel_user] VALUES ('" + txtNama.Text + "','" + txtAlamat.Text + "','" + txtTelp.Text + "','" + txtUsername.Text + "','" + txtPassword.Text + "','" + jabatan + "')", con.buka());
                    reader = cmd.ExecuteReader();
                    MessageBox.Show("Berhasil Menambahkan User");
                    tampilAwal();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void bersih()
        {
            txtNama.Text = "";
            txtPassword.Text = "";
            txtTelp.Text = "";
            txtUsername.Text = "";
            txtcariUser.Text = "";
            txtAlamat.Text = "";
        }

        private void autoUserid()
        {
            long hitung;
            cmd = new SqlCommand("SELECT id_user FROM [dbo].[tabel_user] WHERE id_user IN (SELECT MAX (id_user) FROM [dbo].[tabel_user]) ORDER BY id_user DESC", con.buka());
            reader = cmd.ExecuteReader();
            reader.Read();
            if (reader.HasRows)
            {
                hitung = Convert.ToInt64(reader[0].ToString().Substring(reader["id_user"].ToString().Length - 1)) + 1;
                string joinstr = "" + hitung;
                urut = "" + joinstr.Substring(joinstr.Length - 1, 1);
            }
            else
            {
                urut = "1";
            }
            txtidUser.Text = urut;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (btnNew.Text == "New")
            {
                btnSave.Visible = true;
                btnNew.Text = "Cancel";
                bersih();
                txtidUser.Text = urut;
            }
            else if (btnNew.Text == "Cancel")
            {
                btnSave.Visible = false;
                bersih();
                btnNew.Text = "New";
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                txtidUser.Text = row.Cells["id_user"].Value.ToString();
                txtNama.Text = row.Cells["nama"].Value.ToString();
                txtPassword.Text = row.Cells["password"].Value.ToString();
                txtTelp.Text = row.Cells["telp"].Value.ToString();
                txtUsername.Text = row.Cells["username"].Value.ToString();
                txtAlamat.Text = row.Cells["alamat"].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtidUser.Text == "" || txtNama.Text == "" || txtPassword.Text == "" || txtTelp.Text == "" || txtUsername.Text == "")
            {
                MessageBox.Show("Silahkan isi semua kolom dengan benar");
            }
            else
            {
                try
                {
                    cmd = new SqlCommand("UPDATE [dbo].[tabel_user] SET nama='"+txtNama.Text+"',alamat = '"+txtAlamat.Text+"',telp ='"+txtAlamat.Text+"',username = '"+txtidUser.Text+"', password = '"+txtPassword.Text+"' WHERE id_user = '"+txtidUser.Text+"'",con.buka());
                    reader = cmd.ExecuteReader();
                    MessageBox.Show("Berhasil Meng Update User");
                    tampilAwal();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void txtcariUser_TextChanged(object sender, EventArgs e)
        {
            try
            {
                adapter = new SqlDataAdapter("SELECT * FROM [dbo].[tabel_user] WHERE nama LIKE'%" + txtcariUser.Text + "%'", con.buka());
                DataSet ds = new DataSet();
                adapter.Fill(ds, "tabel_user");
                dataGridView1.DataSource = ds.Tables["tabel_user"].DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtidUser.Text == "")
            {
                MessageBox.Show("Belum ada user yang di pilih");
            }
            else
            {
                try
                {
                    cmd = new SqlCommand("DELETE FROM [dbo].[tabel_user] WHERE id_user = '" + txtidUser.Text + "'", con.buka());
                    reader = cmd.ExecuteReader();
                    MessageBox.Show("Berhasil Menghapus User");
                    tampilAwal();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
