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
    public partial class dataSupplier : Form
    {
        SqlDataAdapter adapter;
        SqlDataReader reader;
        SqlCommand cmd;
        config con = new config();
        string urut;
        String nama, alamat, notel = null;
        public dataSupplier()
        {
            InitializeComponent();
            tampilSup();
            autoSupid();
        }

        private void tampilSup ()
        {
            try
            {
                adapter = new SqlDataAdapter("SELECT * FROM [dbo].[tabel_supplier]", con.buka());
                DataSet ds = new DataSet();
                adapter.Fill(ds, "tabel_supplier");
                dgrSupplier.DataSource = ds.Tables["tabel_supplier"].DefaultView;
                dgrSupplier.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgrSupplier.AllowUserToAddRows = false;
                dgrSupplier.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void autoSupid ()
        {
            long hitung;
            cmd = new SqlCommand("SELECT id_supplier FROM [dbo].[tabel_supplier] WHERE id_supplier IN (SELECT MAX (id_supplier) FROM [dbo].[tabel_supplier]) ORDER BY id_supplier DESC", con.buka());
            reader = cmd.ExecuteReader();
            reader.Read();
            if (reader.HasRows)
            {
                hitung = Convert.ToInt64(reader[0].ToString().Substring(reader["id_supplier"].ToString().Length - 4, 4)) + 1;
                string joinstr = "0000" + hitung;
                urut = "SP" + joinstr.Substring(joinstr.Length - 5, 5);
            }
            else
            {
                urut = "SP00001";
            }
            txtkodeSup.Text = urut;
            txtkodeSup.Enabled = false;
            btnSave.Enabled = false;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (btnNew.Text == "NEW")
            {
                btnnewSave.Visible = true;
                btnNew.Text = "cancel";
                bersih();
                autoSupid();
            }
            else if (btnNew.Text == "cancel")
            {
                btnnewSave.Visible = false;
                btnNew.Text = "NEW";
                bersih();
                autoSupid();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("UPDATE [dbo].[tabel_supplier] SET nama='" + txtnamaSup.Text + "', alamat='" + txtalamatSup.Text + "', no_telp='" + txtTel.Text + "' WHERE id_supplier ='" + txtkodeSup.Text + "'", con.buka());
                reader = cmd.ExecuteReader();
                MessageBox.Show("Berhasil Mengupdate Data Supplier");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            tampilSup();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtnamaSup.Text = null;
            txtalamatSup.Text = null;
            txtTel.Text = null;
            btnNew.Enabled = true;
            txtkodeSup.Text = urut;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("DELETE FROM [dbo].[tabel_supplier] WHERE id_supplier='" + txtkodeSup.Text + "'",con.buka());
                reader = cmd.ExecuteReader();
                MessageBox.Show("Berhasil Menghapus");
                tampilSup();
                bersih();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtCari_TextChanged(object sender, EventArgs e)
        {
            try
            {
                adapter = new SqlDataAdapter("SELECT * FROM [dbo].[tabel_supplier] WHERE nama LIKE '%" + txtCari.Text + "%'", con.buka());
                DataSet ds = new DataSet();
                adapter.Fill(ds, "tabel_supplier");
                dgrSupplier.DataSource = ds.Tables["tabel_supplier"].DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnnewSave_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("INSERT INTO [dbo].[tabel_supplier] (id_supplier,nama,alamat,no_telp) VALUES ('" + txtkodeSup.Text + "','" + txtnamaSup.Text + "','" + txtalamatSup.Text + "','" + txtTel.Text + "')", con.buka());
                reader = cmd.ExecuteReader();
                MessageBox.Show("Berhasil Menambahkan Supplier");
                dgrSupplier.Refresh();
                this.Refresh();
                bersih();
                tampilSup();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgrSupplier_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dgrSupplier.Rows[e.RowIndex];
            txtkodeSup.Text = row.Cells["id_supplier"].Value.ToString();
            nama = row.Cells["nama"].Value.ToString();
            alamat = row.Cells["alamat"].Value.ToString();
            notel = row.Cells["no_telp"].Value.ToString();
            txtkodeSup.Enabled = false;
            txtnamaSup.Enabled = false;
            txtalamatSup.Enabled = false;
            txtTel.Enabled = false;
            btnEdit.Enabled = true;
            txtnamaSup.Text = nama;
            txtalamatSup.Text = alamat;
            txtTel.Text = notel;
            btnDelete.Enabled = true;
            btnNew.Enabled = true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            txtnamaSup.Enabled = true;
            txtalamatSup.Enabled = true;
            txtTel.Enabled = true;
            btnCancel.Enabled = true;
        }
        private void bersih ()
        {
            txtalamatSup.Text = "";
            txtTel.Text = "";
            txtnamaSup.Text = "";
            autoSupid();
            btnSave.Enabled = true;
            txtnamaSup.Enabled = true;
            txtalamatSup.Enabled = true;
            txtTel.Enabled = true;
        }
    }
}
