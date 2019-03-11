namespace latLks
{
    partial class cariKonsumen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(cariKonsumen));
            this.label1 = new System.Windows.Forms.Label();
            this.txtcariKon = new System.Windows.Forms.TextBox();
            this.dgrKonsumen = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgrKonsumen)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cari Konsumen";
            // 
            // txtcariKon
            // 
            this.txtcariKon.Location = new System.Drawing.Point(108, 27);
            this.txtcariKon.Name = "txtcariKon";
            this.txtcariKon.Size = new System.Drawing.Size(263, 20);
            this.txtcariKon.TabIndex = 1;
            this.txtcariKon.TextChanged += new System.EventHandler(this.txtcariKon_TextChanged);
            // 
            // dgrKonsumen
            // 
            this.dgrKonsumen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrKonsumen.Location = new System.Drawing.Point(16, 61);
            this.dgrKonsumen.Name = "dgrKonsumen";
            this.dgrKonsumen.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgrKonsumen.Size = new System.Drawing.Size(355, 233);
            this.dgrKonsumen.TabIndex = 2;
            this.dgrKonsumen.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrKonsumen_CellContentDoubleClick);
            // 
            // cariKonsumen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 306);
            this.Controls.Add(this.dgrKonsumen);
            this.Controls.Add(this.txtcariKon);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "cariKonsumen";
            this.Text = "Lego Store :: Cari Konsumen";
            ((System.ComponentModel.ISupportInitialize)(this.dgrKonsumen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtcariKon;
        private System.Windows.Forms.DataGridView dgrKonsumen;
    }
}