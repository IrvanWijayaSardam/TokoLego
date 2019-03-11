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
    public partial class profile : Form
    {
        config con = new config();
        Form1 form1 = new Form1();
        string di = Form1.di;
        SqlCommand cmd;
        SqlDataAdapter adapter;
        SqlDataReader reader;
        string pw = Form1.password;
        public profile()
        {
            InitializeComponent();
            muncul();
        }

        public void muncul()
        {
            cmd = new SqlCommand("SELECT * FROM [dbo].[tabel_user] WHERE id_user='"+di+"'",con.buka());
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    txtKode.Text = reader["id_user"].ToString();
                    txtNama.Text = reader["nama"].ToString();
                    txtAlamat.Text = reader["alamat"].ToString();
                    txtTel.Text = reader["telp"].ToString();
                    txtUser.Text = reader["username"].ToString();
                    txtPassword.Text = reader["password"].ToString();
                    txtPwlama.Text = reader["password"].ToString();
                    txtConpw.Text = reader["password"].ToString();
                    txtUser.Enabled = false;
                    txtPassword.Enabled = false;
                }
            }
        }

        private void btnUbah_Click(object sender, EventArgs e)
        {
            if (btnUbah.Text == "Ubah Password")
            { 
            l_password.Text = "Password Baru";
            btnUbah.Text = "Cancel";
            Conpw.Visible = true;
            pwLama.Visible = true;
            txtConpw.Visible = true;
            txtPwlama.Visible = true;
            btnSimpanpw.Visible = true;
            txtPassword.Text = "";
            txtConpw.Text = "";
            txtPassword.UseSystemPasswordChar = true;
            txtConpw.UseSystemPasswordChar = true;
            txtPassword.Enabled = true;
            }
            else
            {
                l_password.Text = "Password";
                btnUbah.Text = "Ubah Password";
                Conpw.Visible = false;
                pwLama.Visible = false;
                txtConpw.Visible = false;
                txtPwlama.Visible = false;
                btnSimpanpw.Visible = false;
                txtPassword.Enabled = true;
                txtPassword.Text = pw;
                txtPassword.Enabled = false;
            }
        }

        private void btnSimpanpw_Click(object sender, EventArgs e)
        {
            try
            {
                    if (txtPassword.Text == txtConpw.Text)
                    {
                    cmd = new SqlCommand("UPDATE [dbo].[tabel_user] SET password='" + txtConpw.Text + "' WHERE id_user='"+di+"'", con.buka());
                        reader = cmd.ExecuteReader();
                        MessageBox.Show("Berhasil Mengganti Password");
                    }
                    else if (txtPwlama.Text != pw)
                    {
                        MessageBox.Show("Password Lama Salah");
                    }
                    else if (txtConpw.Text != txtPassword.Text)
                    {
                        MessageBox.Show("Password Konfirmasi Tidak Sama");
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("UPDATE [dbo].[tabel_user] SET nama='"+txtNama.Text+"', alamat='"+txtAlamat.Text+"', telp='"+txtTel.Text+"' WHERE id_user='"+di+"'",con.buka());
                reader = cmd.ExecuteReader();
                MessageBox.Show("Berhasil Mengganti Informasi");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

