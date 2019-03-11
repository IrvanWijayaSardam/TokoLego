namespace latLks
{
    partial class dataSupplier
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dataSupplier));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtkodeSup = new System.Windows.Forms.TextBox();
            this.txtnamaSup = new System.Windows.Forms.TextBox();
            this.txtTel = new System.Windows.Forms.TextBox();
            this.txtalamatSup = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCari = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnnewSave = new System.Windows.Forms.Button();
            this.dgrSupplier = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrSupplier)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kode Supplier";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nama";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Telepon";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Alamat";
            // 
            // txtkodeSup
            // 
            this.txtkodeSup.Location = new System.Drawing.Point(139, 61);
            this.txtkodeSup.Name = "txtkodeSup";
            this.txtkodeSup.Size = new System.Drawing.Size(160, 20);
            this.txtkodeSup.TabIndex = 4;
            // 
            // txtnamaSup
            // 
            this.txtnamaSup.Location = new System.Drawing.Point(139, 90);
            this.txtnamaSup.Name = "txtnamaSup";
            this.txtnamaSup.Size = new System.Drawing.Size(160, 20);
            this.txtnamaSup.TabIndex = 5;
            // 
            // txtTel
            // 
            this.txtTel.Location = new System.Drawing.Point(139, 119);
            this.txtTel.MaxLength = 15;
            this.txtTel.Name = "txtTel";
            this.txtTel.Size = new System.Drawing.Size(160, 20);
            this.txtTel.TabIndex = 6;
            // 
            // txtalamatSup
            // 
            this.txtalamatSup.Location = new System.Drawing.Point(139, 148);
            this.txtalamatSup.Name = "txtalamatSup";
            this.txtalamatSup.Size = new System.Drawing.Size(160, 20);
            this.txtalamatSup.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(427, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Cari";
            // 
            // txtCari
            // 
            this.txtCari.Location = new System.Drawing.Point(468, 61);
            this.txtCari.Name = "txtCari";
            this.txtCari.Size = new System.Drawing.Size(100, 20);
            this.txtCari.TabIndex = 9;
            this.txtCari.TextChanged += new System.EventHandler(this.txtCari_TextChanged);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(29, 46);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(593, 132);
            this.panel1.TabIndex = 10;
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(40, 198);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "SAVE";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Enabled = false;
            this.btnEdit.Location = new System.Drawing.Point(139, 198);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 12;
            this.btnEdit.Text = "EDIT";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(215, 13);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 13;
            this.btnNew.Text = "NEW";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(309, 13);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 14;
            this.btnDelete.Text = "DELETE";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Enabled = false;
            this.btnCancel.Location = new System.Drawing.Point(401, 13);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(501, 13);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 16;
            this.btnExit.Text = "EXIT";
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnnewSave);
            this.panel2.Controls.Add(this.btnNew);
            this.panel2.Controls.Add(this.btnDelete);
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Controls.Add(this.btnExit);
            this.panel2.Location = new System.Drawing.Point(29, 185);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(593, 67);
            this.panel2.TabIndex = 17;
            // 
            // btnnewSave
            // 
            this.btnnewSave.Location = new System.Drawing.Point(215, 43);
            this.btnnewSave.Name = "btnnewSave";
            this.btnnewSave.Size = new System.Drawing.Size(75, 23);
            this.btnnewSave.TabIndex = 17;
            this.btnnewSave.Text = "Save";
            this.btnnewSave.UseVisualStyleBackColor = true;
            this.btnnewSave.Visible = false;
            this.btnnewSave.Click += new System.EventHandler(this.btnnewSave_Click);
            // 
            // dgrSupplier
            // 
            this.dgrSupplier.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrSupplier.Location = new System.Drawing.Point(29, 258);
            this.dgrSupplier.Name = "dgrSupplier";
            this.dgrSupplier.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgrSupplier.Size = new System.Drawing.Size(593, 151);
            this.dgrSupplier.TabIndex = 18;
            this.dgrSupplier.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrSupplier_CellContentClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(214, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(199, 24);
            this.label6.TabIndex = 19;
            this.label6.Text = "Kelola Data Supplier";
            // 
            // dataSupplier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 432);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dgrSupplier);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtCari);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtalamatSup);
            this.Controls.Add(this.txtTel);
            this.Controls.Add(this.txtnamaSup);
            this.Controls.Add(this.txtkodeSup);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "dataSupplier";
            this.Tag = "";
            this.Text = "Lego Store :: Kelola Supplier";
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrSupplier)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtkodeSup;
        private System.Windows.Forms.TextBox txtnamaSup;
        private System.Windows.Forms.TextBox txtTel;
        private System.Windows.Forms.TextBox txtalamatSup;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCari;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgrSupplier;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnnewSave;
    }
}