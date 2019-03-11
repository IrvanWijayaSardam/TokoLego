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
using Microsoft.Office.Interop.Excel;

namespace latLks
{
    public partial class lPenjualan : Form
    {
        config con = new config();
        SqlCommand cmd;
        SqlDataAdapter adapter;
        public lPenjualan()
        {
            InitializeComponent();
        }

        private void lPenjualan_Load(object sender, EventArgs e)
        {
            tampil();
        }

        private void tampil()
        {
            try
            {
                cmd = new SqlCommand("SELECT * FROM [dbo].[vw_detail]", con.buka());
                adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;
                System.Data.DataTable dt = new System.Data.DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnTampilSemua_Click(object sender, EventArgs e)
        {
            tampil();
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            Workbook wb = excel.Workbooks.Add(XlSheetType.xlWorksheet);
            Worksheet ws = (Worksheet)excel.ActiveSheet;
            excel.Visible = true;

            ws.Cells[1, 1] = "No Faktur";
            ws.Cells[1, 2] = "ID Barang";
            ws.Cells[1, 3] = "Nama Barang";
            ws.Cells[1, 4] = "Harga_jual";
            ws.Cells[1, 5] = "satuan";
            ws.Cells[1, 6] = "subtotal";

            for (int j = 2; j < dataGridView1.Rows.Count; j++)
            {
                for (int i = 1; i <= 6; i++)
                {
                    ws.Cells[j, i] = dataGridView1.Rows[j - 2].Cells[i - 1].Value;
                }
            }

        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            try
            {
                adapter = new SqlDataAdapter("SELECT * FROM [dbo].[detail_jual] WHERE id_jual LIKE '%" + dateTimePicker1.Text + "%'", con.buka());
                DataSet ds = new DataSet();
                adapter.Fill(ds, "detail_jual");
                dataGridView1.DataSource = ds.Tables["detail_jual"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } 
        }
    }
}