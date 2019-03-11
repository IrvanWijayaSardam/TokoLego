namespace latLks
{
    partial class cariBarang
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(cariBarang));
            this.txtCaribarang = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgrBarang = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgrBarang)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCaribarang
            // 
            this.txtCaribarang.Location = new System.Drawing.Point(100, 14);
            this.txtCaribarang.Name = "txtCaribarang";
            this.txtCaribarang.Size = new System.Drawing.Size(336, 20);
            this.txtCaribarang.TabIndex = 0;
            this.txtCaribarang.TextChanged += new System.EventHandler(this.txtCaribarang_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cari Barang";
            // 
            // dgrBarang
            // 
            this.dgrBarang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrBarang.Location = new System.Drawing.Point(15, 53);
            this.dgrBarang.Name = "dgrBarang";
            this.dgrBarang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgrBarang.Size = new System.Drawing.Size(422, 248);
            this.dgrBarang.TabIndex = 2;
            this.dgrBarang.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrBarang_CellDoubleClick);
            // 
            // cariBarang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 313);
            this.Controls.Add(this.dgrBarang);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCaribarang);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "cariBarang";
            this.Text = "Lego Store :: Cari Barang";
            ((System.ComponentModel.ISupportInitialize)(this.dgrBarang)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCaribarang;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgrBarang;
    }
}