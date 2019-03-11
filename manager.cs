using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace latLks
{
    public partial class manager : Form
    {
        private int childFormNumber = 0;
        profile p;
        penjualan pen;
        dataSupplier sup;
        lPenjualan lapPen;
        kelolaBarang kelBar;
        customerManager cm;
        kelolaUser ku;
        public manager()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void profileDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (p == null)
            {
                profile p = new profile();
                p.MdiParent = this;
                p.FormClosed += new FormClosedEventHandler (P_FormClosed);
                p.Show();
            }
            else
            {
                p.Activate();
            }
            
        }

        private void P_FormClosed(object sender, FormClosedEventArgs e)
        {
            p = null;
        }

        private void penjualanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pen == null)
            {
                penjualan pen = new penjualan();
                pen.MdiParent = this;
                pen.FormClosed += new FormClosedEventHandler (Pen_FormClosed);
                pen.Show();
            }
            else
            {
                pen.Activate();
            }
        }

        private void Pen_FormClosed(object sender, FormClosedEventArgs e)
        {
            pen = null;
        }

        private void supplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sup == null)
            {
                dataSupplier sup = new dataSupplier();
                sup.MdiParent = this;
                sup.FormClosed += new FormClosedEventHandler (Sup_FormClosed);
                sup.Show();
            }
            else
            {
                sup.Activate();
            }
        }

        private void Sup_FormClosed(object sender, FormClosedEventArgs e)
        {
            sup = null;
        }

        private void laporanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lapPen == null)
            {
                lPenjualan lapPen = new lPenjualan();
                lapPen.MdiParent = this;
                lapPen.FormClosed += new FormClosedEventHandler (LapPen_FormClosed);
                lapPen.Show();
            }
            else
            {
                lapPen.Activate();
            }
        }

        private void LapPen_FormClosed(object sender, FormClosedEventArgs e)
        {
            lapPen = null;
        }

        private void dataBarangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (kelBar == null)
            {
                kelolaBarang kelBar = new kelolaBarang();
                kelBar.MdiParent = this;
                kelBar.FormClosed += new FormClosedEventHandler (KelBar_FormClosed);
                kelBar.Show();
            }
            else
            {
                kelBar.Activate();
            }
        }

        private void KelBar_FormClosed(object sender, FormClosedEventArgs e)
        {
            kelBar = null;
        }

        private void dataPelangganToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cm == null)
            {
                customerManager cm = new customerManager();
                cm.MdiParent = this;
                cm.FormClosed += new FormClosedEventHandler (Cm_FormClosed);
                cm.Show();
            }
            else
            {
                cm.Activate();
            }
            
        }

        private void Cm_FormClosed(object sender, FormClosedEventArgs e)
        {
            cm = null;
        }

        private void dataUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ku == null)
            {
                kelolaUser ku = new kelolaUser();
                ku.MdiParent = this;
                ku.FormClosed += new FormClosedEventHandler (Ku_FormClosed);
                ku.Show();
            }
            else
            {
                ku.Activate();
            }
        }

        private void Ku_FormClosed(object sender, FormClosedEventArgs e)
        {
            ku = null;
        }
    }
}
