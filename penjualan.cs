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
    public partial class penjualan : Form
    {
        SqlDataAdapter adapter;
        SqlCommand cmd;
        String username = Form1.username;
        SqlDataReader rd;
        int totalData;
        config con = new config();
        cariBarang cb = new cariBarang();
        int hasil,stok,kembalian;

        public penjualan()
        {
            InitializeComponent();
            showData();
            autoNumber();
            openvw();
        }


        private void showData()
        {
            adapter = new SqlDataAdapter("SELECT * FROM [dbo].[vw_detail] WHERE id_jual = '"+txtnoFaktur.Text+"'", con.buka());
            DataSet ds = new DataSet();
            adapter.Fill(ds, "tabel_barang");
            txtJumlah.Text = ds.Tables["tabel_barang"].Rows.Count.ToString();
            l_kasir.Text = username;
            dtTanggal.Value = DateTime.Now;
        }

        private void showDataBarang ()
        {
            txtkodeBarang.Text = cb.getId();
            txtNamaBarang.Text = cb.getNama();
            txtHargaBarang.Text = cb.getHarga();
        }

        private void simpanMasterPenjualan()
        {
            try
            {
                cmd = new SqlCommand("INSERT INTO [dbo].[header_jual] VALUES ('" + txtnoFaktur.Text + "','" + dtTanggal.Text + "','" + l_kasir.Text + "','" + txtnamaKonsumen.Text + "','" + txtJumlahBarang.Text + "')", con.buka());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void simpanDetailPenjualan ()
        {
            try
            {
                cmd = new SqlCommand("INSERT INTO [dbo].[detail_jual] (id_jual,id_barang,subtotal,qty,nama) VALUES ('"+txtnoFaktur.Text+"','"+txtkodeBarang.Text+"','"+txtHargaBarang.Text+"','"+txtJumlahBarang.Text+"','"+txtNamaBarang.Text+"')", con.buka());
                rd = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void refreshPenjualan()
        {
            try
            {
                adapter = new SqlDataAdapter("SELECT * FROM [dbo].[vw_detail] WHERE id_jual='" + txtnoFaktur.Text + "'", con.buka());
                DataSet ds = new DataSet();
                adapter.Fill(ds, "vw_detail");
                dgrUtama.DataSource = ds.Tables["vw_detail"].DefaultView;
                dgrUtama.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bersih ()
        {
            cusId.Enabled = false;
            txtSimpan.Enabled = true;
            cusId.Text = "";
            txtHargaBarang.Text = "";
            txtJumlahBarang.Text = "";
            txtkodeBarang.Text = "";
            txtnamaKonsumen.Text = "";
            txtNamaBarang.Text = "";
            l_kembalian.Text = "";
            l_subtotal.Text = "";
            txtBayar.Text = "";
        }

        private void openvw ()
        {
            try
            {
                adapter = new SqlDataAdapter("SELECT * FROM [dbo].[vw_penjualan] ORDER BY id DESC", con.buka());
                DataSet ds = new DataSet();
                adapter.Fill(ds, "vw_penjualan");
                dgrUtama.DataSource = ds;
                dgrUtama.DataMember = "vw_penjualan";
                dgrUtama.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgrUtama.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void autoNumber()
        {
            long hitung;
            string urut;
            cmd = new SqlCommand("SELECT id_jual FROM [dbo].[detail_jual] WHERE id_jual in(SELECT MAX(id_jual) FROM [dbo].[detail_jual]) ORDER BY id_jual DESC", con.buka());
            rd = cmd.ExecuteReader();
            rd.Read();
            if (rd.HasRows)
            {
                hitung = Convert.ToInt64(rd[0].ToString().Substring(rd["id_jual"].ToString().Length - 12, 4)) + 1;
                string joinstr = "0000" + hitung;
                urut = "Trx-" + joinstr.Substring(joinstr.Length - 4, 4) + "/" + DateTime.Now.ToString("MM/yyyy");
            }
            else
            {
                urut = "Trx-0001/" + DateTime.Now.ToString("MM/yyyy");
            }
            rd.Close();
            txtnoFaktur.Text = urut;
            txtnoFaktur.Enabled = false;
        }

        private void btncariBar_Click(object sender, EventArgs e)
        {
            cariBarang cariBar = new cariBarang();
            cariBar.ShowDialog();
            txtHargaBarang.Text = cariBar.getHarga();
            txtkodeBarang.Text = cariBar.getId();
            txtNamaBarang.Text = cariBar.getNama();
            stok = cb.getJumlah();
        }

        private void btncariKon_Click(object sender, EventArgs e)
        {
            cariKonsumen kon = new cariKonsumen();
            kon.ShowDialog();
            cusId.Text = kon.getId();
            txtnamaKonsumen.Text = kon.getNama();
        }

        private void refreshTransaksi()
        {
            refreshPenjualan();
            txtkodeBarang.Clear();
            txtNamaBarang.Clear();
            txtHargaBarang.Text = "0";
            txtJumlahBarang.Text = "0";
        }

        private void txtSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                int a = int.Parse(txtJumlahBarang.Text);
                if (stok < a)
                {
                    MessageBox.Show("Stok Barang Yang Tersedia Adalah : " + stok);
                }
                else
                {
                    if (txtnoFaktur.Text.Trim() == "" || cusId.Text.Trim() == "" || txtkodeBarang.Text.Trim() == "" || txtJumlahBarang.Text.Trim() == "")
                    {
                        MessageBox.Show("Silahkan Isi Semua Data Dengan Lengkap");
                    }
                    else
                    {
                        cmd = new SqlCommand("SELECT * FROM [dbo].[detail_jual] WHERE id_jual = '" + txtnoFaktur.Text + "'", con.buka());
                        rd = cmd.ExecuteReader();
                        if (rd.Read())
                        {
                            simpanDetailPenjualan();
                        }
                        else
                        {
                            simpanMasterPenjualan();
                            simpanDetailPenjualan();
                        }
                        totalBayar();
                        refreshTransaksi();
                    }
                    totalBayar();
                    showData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgrUtama_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dgrUtama.Rows[e.RowIndex];
            txtkodeBarang.Text = row.Cells["id_barang"].Value.ToString();
            txtNamaBarang.Text = row.Cells["nama"].Value.ToString();
            txtHargaBarang.Text = row.Cells["subtotal"].Value.ToString();
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("DELETE FROM [dbo].[detail_jual] WHERE id_jual='" + txtnoFaktur.Text + "' AND id_barang ='" + txtkodeBarang.Text + "'", con.buka());
                rd = cmd.ExecuteReader();
                refreshTransaksi();
                totalBayar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            showData();
        }

        private void txtNew_Click(object sender, EventArgs e)
        {
            try
            {
                bersih();
                autoNumber();
                openvw();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtBayar_TextChanged(object sender, EventArgs e)
        {
            int bayar;
            if (Int32.TryParse(txtBayar.Text, out bayar))
            {
                kembalian = bayar - hasil;
                l_kembalian.Text = kembalian.ToString();
                if (kembalian < 0)
                {
                    txtBayar.Focus();
                }
            }
        }

        private void totalBayar()
        {
            try
            {
                cmd = new SqlCommand("SELECT SUM(subtotal) FROM [dbo].[vw_detail] WHERE id_jual='" + txtnoFaktur.Text + "'", con.buka());
                object a = cmd.ExecuteScalar();
                if (a == null || a is DBNull)
                {
                    hasil = 0;
                }
                else
                {
                    hasil = Convert.ToInt32(cmd.ExecuteScalar());
                }
                string totalBayar = hasil.ToString();
                l_subtotal.Text = totalBayar;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
