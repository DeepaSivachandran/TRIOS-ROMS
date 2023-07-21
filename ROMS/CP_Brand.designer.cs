namespace ROMS
{
    partial class CP_Brand
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CP_Brand));
            this.txtDEBrandNameInEnglish = new System.Windows.Forms.TextBox();
            this.txtEBrandNameInEnglish = new System.Windows.Forms.TextBox();
            this.grbform = new System.Windows.Forms.GroupBox();
            this.txtDEBrandNameInTamil = new System.Windows.Forms.TextBox();
            this.txtEBrandNameInTamil = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.errBrand = new System.Windows.Forms.ErrorProvider(this.components);
            this.grdBrandList = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Label();
            this.lvSubGroup = new System.Windows.Forms.ListView();
            this.txtSubGroup = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.clmsno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmsubgroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmifscode = new System.Windows.Forms.DataGridViewButtonColumn();
            this.grbform.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errBrand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBrandList)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDEBrandNameInEnglish
            // 
            this.txtDEBrandNameInEnglish.BackColor = System.Drawing.SystemColors.Control;
            this.txtDEBrandNameInEnglish.Enabled = false;
            this.txtDEBrandNameInEnglish.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDEBrandNameInEnglish.Location = new System.Drawing.Point(20, 29);
            this.txtDEBrandNameInEnglish.Name = "txtDEBrandNameInEnglish";
            this.txtDEBrandNameInEnglish.ReadOnly = true;
            this.txtDEBrandNameInEnglish.Size = new System.Drawing.Size(181, 27);
            this.txtDEBrandNameInEnglish.TabIndex = 7;
            this.txtDEBrandNameInEnglish.Text = "Brand Name In English";
            // 
            // txtEBrandNameInEnglish
            // 
            this.txtEBrandNameInEnglish.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEBrandNameInEnglish.Location = new System.Drawing.Point(201, 29);
            this.txtEBrandNameInEnglish.MaxLength = 50;
            this.txtEBrandNameInEnglish.Name = "txtEBrandNameInEnglish";
            this.txtEBrandNameInEnglish.Size = new System.Drawing.Size(287, 27);
            this.txtEBrandNameInEnglish.TabIndex = 0;
            this.txtEBrandNameInEnglish.Enter += new System.EventHandler(this.TxtEBrandNameInEnglish_Enter);
            this.txtEBrandNameInEnglish.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtEBrandNameInEnglish_KeyDown);
            this.txtEBrandNameInEnglish.Leave += new System.EventHandler(this.TxtEBrandNameInEnglish_Leave);
            // 
            // grbform
            // 
            this.grbform.Controls.Add(this.textBox1);
            this.grbform.Controls.Add(this.lvSubGroup);
            this.grbform.Controls.Add(this.txtSubGroup);
            this.grbform.Controls.Add(this.grdBrandList);
            this.grbform.Controls.Add(this.btnAdd);
            this.grbform.Controls.Add(this.txtDEBrandNameInTamil);
            this.grbform.Controls.Add(this.txtEBrandNameInTamil);
            this.grbform.Controls.Add(this.txtDEBrandNameInEnglish);
            this.grbform.Controls.Add(this.btnClose);
            this.grbform.Controls.Add(this.btnSave);
            this.grbform.Controls.Add(this.txtEBrandNameInEnglish);
            this.grbform.Location = new System.Drawing.Point(17, 12);
            this.grbform.Name = "grbform";
            this.grbform.Size = new System.Drawing.Size(508, 409);
            this.grbform.TabIndex = 28;
            this.grbform.TabStop = false;
            this.grbform.Enter += new System.EventHandler(this.Grbform_Enter);
            // 
            // txtDEBrandNameInTamil
            // 
            this.txtDEBrandNameInTamil.BackColor = System.Drawing.SystemColors.Control;
            this.txtDEBrandNameInTamil.Enabled = false;
            this.txtDEBrandNameInTamil.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDEBrandNameInTamil.Location = new System.Drawing.Point(20, 56);
            this.txtDEBrandNameInTamil.Name = "txtDEBrandNameInTamil";
            this.txtDEBrandNameInTamil.ReadOnly = true;
            this.txtDEBrandNameInTamil.Size = new System.Drawing.Size(181, 27);
            this.txtDEBrandNameInTamil.TabIndex = 1111137;
            this.txtDEBrandNameInTamil.Text = "Brand Name In Tamil";
            // 
            // txtEBrandNameInTamil
            // 
            this.txtEBrandNameInTamil.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEBrandNameInTamil.Location = new System.Drawing.Point(201, 56);
            this.txtEBrandNameInTamil.MaxLength = 50;
            this.txtEBrandNameInTamil.Name = "txtEBrandNameInTamil";
            this.txtEBrandNameInTamil.Size = new System.Drawing.Size(287, 27);
            this.txtEBrandNameInTamil.TabIndex = 1;
            this.txtEBrandNameInTamil.Enter += new System.EventHandler(this.TxtEBrandNameInTamil_Enter);
            this.txtEBrandNameInTamil.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtEBrandNameInTamil_KeyDown);
            this.txtEBrandNameInTamil.Leave += new System.EventHandler(this.TxtEBrandNameInTamil_Leave);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnClose.Image = global::ROMS.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(413, 370);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 29);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            this.btnClose.Enter += new System.EventHandler(this.btnClose_Enter);
            this.btnClose.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnClose_KeyDown);
            this.btnClose.Leave += new System.EventHandler(this.btnClose_Leave);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnSave.Image = global::ROMS.Properties.Resources.save;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(323, 370);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(84, 29);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.Enter += new System.EventHandler(this.btnSave_Enter);
            this.btnSave.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnSave_KeyDown);
            this.btnSave.Leave += new System.EventHandler(this.btnSave_Leave);
            // 
            // errBrand
            // 
            this.errBrand.ContainerControl = this;
            // 
            // grdBrandList
            // 
            this.grdBrandList.AllowUserToAddRows = false;
            this.grdBrandList.AllowUserToDeleteRows = false;
            this.grdBrandList.AllowUserToResizeColumns = false;
            this.grdBrandList.AllowUserToResizeRows = false;
            this.grdBrandList.BackgroundColor = System.Drawing.Color.White;
            this.grdBrandList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(242)))), ((int)(((byte)(213)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdBrandList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdBrandList.ColumnHeadersHeight = 30;
            this.grdBrandList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdBrandList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmsno,
            this.clmsubgroup,
            this.clmifscode});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdBrandList.DefaultCellStyle = dataGridViewCellStyle2;
            this.grdBrandList.EnableHeadersVisualStyles = false;
            this.grdBrandList.GridColor = System.Drawing.Color.White;
            this.grdBrandList.Location = new System.Drawing.Point(20, 148);
            this.grdBrandList.Name = "grdBrandList";
            this.grdBrandList.ReadOnly = true;
            this.grdBrandList.RowHeadersVisible = false;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.grdBrandList.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.grdBrandList.RowTemplate.Height = 25;
            this.grdBrandList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdBrandList.Size = new System.Drawing.Size(468, 216);
            this.grdBrandList.TabIndex = 1111139;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.SystemColors.Control;
            this.btnAdd.Image = global::ROMS.Properties.Resources.plus;
            this.btnAdd.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAdd.Location = new System.Drawing.Point(467, 111);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(21, 22);
            this.btnAdd.TabIndex = 1111138;
            this.btnAdd.Text = "        ";
            // 
            // lvSubGroup
            // 
            this.lvSubGroup.HideSelection = false;
            this.lvSubGroup.Location = new System.Drawing.Point(201, 136);
            this.lvSubGroup.Name = "lvSubGroup";
            this.lvSubGroup.Size = new System.Drawing.Size(287, 52);
            this.lvSubGroup.TabIndex = 1111181;
            this.lvSubGroup.UseCompatibleStateImageBehavior = false;
            this.lvSubGroup.Visible = false;
            // 
            // txtSubGroup
            // 
            this.txtSubGroup.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubGroup.Location = new System.Drawing.Point(201, 109);
            this.txtSubGroup.MaxLength = 50;
            this.txtSubGroup.Name = "txtSubGroup";
            this.txtSubGroup.Size = new System.Drawing.Size(264, 27);
            this.txtSubGroup.TabIndex = 1111182;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(20, 109);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(181, 27);
            this.textBox1.TabIndex = 1111183;
            this.textBox1.Text = "Product Sub Group Name";
            // 
            // clmsno
            // 
            this.clmsno.HeaderText = "S.No.";
            this.clmsno.Name = "clmsno";
            this.clmsno.ReadOnly = true;
            this.clmsno.Width = 50;
            // 
            // clmsubgroup
            // 
            this.clmsubgroup.HeaderText = "Product Sub Group Name";
            this.clmsubgroup.Name = "clmsubgroup";
            this.clmsubgroup.ReadOnly = true;
            this.clmsubgroup.Width = 300;
            // 
            // clmifscode
            // 
            this.clmifscode.HeaderText = "Remove";
            this.clmifscode.Name = "clmifscode";
            this.clmifscode.ReadOnly = true;
            this.clmifscode.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmifscode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.clmifscode.Width = 75;
            // 
            // CP_Brand
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(541, 438);
            this.Controls.Add(this.grbform);
            this.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CP_Brand";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Brand";
            this.Load += new System.EventHandler(this.CP_Brand_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CP_Brand_KeyDown);
            this.Leave += new System.EventHandler(this.CP_Brand_Leave);
            this.grbform.ResumeLayout(false);
            this.grbform.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errBrand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBrandList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txtDEBrandNameInEnglish;
        private System.Windows.Forms.TextBox txtEBrandNameInEnglish;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox grbform;
        private System.Windows.Forms.ErrorProvider errBrand;
        private System.Windows.Forms.TextBox txtDEBrandNameInTamil;
        private System.Windows.Forms.TextBox txtEBrandNameInTamil;
        public System.Windows.Forms.DataGridView grdBrandList;
        internal System.Windows.Forms.Label btnAdd;
        private System.Windows.Forms.ListView lvSubGroup;
        private System.Windows.Forms.TextBox txtSubGroup;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmsno;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmsubgroup;
        private System.Windows.Forms.DataGridViewButtonColumn clmifscode;
    }
}