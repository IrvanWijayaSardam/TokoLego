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
    public partial class Form1 : Form
    {
        config con = new config();
        SqlCommand cmd;
        SqlDataAdapter adapter;
        SqlDataReader reader;
        public static string username, password,di;
        string akses;
        int max;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
                if ( txtUser.Text =="" || txtPassword.Text =="")
                {
                    MessageBox.Show("Tolong Isi Semua Isian dengan benar");
                }
                else
                {
                if (max >= 3)
                {
                    btnLogin.Enabled = false;
                    MessageBox.Show("Maaf Kami Tidak Dapat Memverifikasi Bahwa Anda Pemilik Akun");
                }
                else
                {
                    try
                    {
                        cmd = new SqlCommand("SELECT * FROM [dbo].[tabel_user] WHERE username='" + txtUser.Text + "' AND password='" + txtPassword.Text + "'", con.buka());
                        reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                di = reader["id_user"].ToString();
                                username = reader["username"].ToString();
                                password = reader["password"].ToString();
                                akses = reader["status"].ToString();
                                if (akses == "1")
                                {
                                    admin admin = new admin();
                                    admin.Show();
                                    this.Hide();
                                }
                                else if (akses == "2")
                                {
                                    kasir kasir = new kasir();
                                    kasir.Show();
                                    this.Hide();
                                }
                                else if (akses == "3")
                                {
                                    manager manager = new manager();
                                    manager.Show();
                                    this.Hide();
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Username Atau Password Yang Anda Masukkan Tidak Sesuai");
                            max++;
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                }        
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            if (btnShow.Text == "show")
            {
                txtPassword.UseSystemPasswordChar = false;
                btnShow.Text = "hide";
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
                btnShow.Text = "show";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            con.buka();
        }
    }
}
