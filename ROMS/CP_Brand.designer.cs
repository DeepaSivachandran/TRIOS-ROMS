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
            this.txtDEBrandName = new System.Windows.Forms.TextBox();
            this.txtEBrandName = new System.Windows.Forms.TextBox();
            this.grbform = new System.Windows.Forms.GroupBox();
            this.grdGroupList = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.errBrand = new System.Windows.Forms.ErrorProvider(this.components);
            this.cmbUserRole = new System.Windows.Forms.ComboBox();
            this.txtDSlNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.grbform.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdGroupList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errBrand)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDEBrandName
            // 
            this.txtDEBrandName.BackColor = System.Drawing.SystemColors.Control;
            this.txtDEBrandName.Enabled = false;
            this.txtDEBrandName.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDEBrandName.Location = new System.Drawing.Point(44, 30);
            this.txtDEBrandName.Name = "txtDEBrandName";
            this.txtDEBrandName.ReadOnly = true;
            this.txtDEBrandName.Size = new System.Drawing.Size(181, 27);
            this.txtDEBrandName.TabIndex = 7;
            this.txtDEBrandName.Text = "Brand Name";
            // 
            // txtEBrandName
            // 
            this.txtEBrandName.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEBrandName.Location = new System.Drawing.Point(225, 30);
            this.txtEBrandName.MaxLength = 50;
            this.txtEBrandName.Name = "txtEBrandName";
            this.txtEBrandName.Size = new System.Drawing.Size(287, 27);
            this.txtEBrandName.TabIndex = 0;
            this.txtEBrandName.Enter += new System.EventHandler(this.txtEBrandName_Enter);
            this.txtEBrandName.Leave += new System.EventHandler(this.txtEBrandName_Leave);
            // 
            // grbform
            // 
            this.grbform.Controls.Add(this.label1);
            this.grbform.Controls.Add(this.btnAdd);
            this.grbform.Controls.Add(this.cmbUserRole);
            this.grbform.Controls.Add(this.txtDSlNo);
            this.grbform.Controls.Add(this.grdGroupList);
            this.grbform.Controls.Add(this.txtDEBrandName);
            this.grbform.Controls.Add(this.btnClose);
            this.grbform.Controls.Add(this.btnSave);
            this.grbform.Controls.Add(this.txtEBrandName);
            this.grbform.Location = new System.Drawing.Point(18, 14);
            this.grbform.Name = "grbform";
            this.grbform.Size = new System.Drawing.Size(638, 327);
            this.grbform.TabIndex = 28;
            this.grbform.TabStop = false;
            // 
            // grdGroupList
            // 
            this.grdGroupList.AllowUserToAddRows = false;
            this.grdGroupList.AllowUserToDeleteRows = false;
            this.grdGroupList.AllowUserToResizeColumns = false;
            this.grdGroupList.AllowUserToResizeRows = false;
            this.grdGroupList.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(242)))), ((int)(((byte)(213)))));
            this.grdGroupList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(202)))), ((int)(((byte)(148)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(242)))), ((int)(((byte)(213)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdGroupList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdGroupList.ColumnHeadersHeight = 30;
            this.grdGroupList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdGroupList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column3});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdGroupList.DefaultCellStyle = dataGridViewCellStyle2;
            this.grdGroupList.EnableHeadersVisualStyles = false;
            this.grdGroupList.GridColor = System.Drawing.Color.White;
            this.grdGroupList.Location = new System.Drawing.Point(44, 95);
            this.grdGroupList.Name = "grdGroupList";
            this.grdGroupList.ReadOnly = true;
            this.grdGroupList.RowHeadersVisible = false;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.grdGroupList.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.grdGroupList.RowTemplate.Height = 25;
            this.grdGroupList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdGroupList.Size = new System.Drawing.Size(468, 148);
            this.grdGroupList.TabIndex = 8;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "S.No.";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Group";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 200;
            // 
            // errBrand
            // 
            this.errBrand.ContainerControl = this;
            // 
            // cmbUserRole
            // 
            this.cmbUserRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUserRole.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbUserRole.FormattingEnabled = true;
            this.cmbUserRole.Location = new System.Drawing.Point(225, 57);
            this.cmbUserRole.Name = "cmbUserRole";
            this.cmbUserRole.Size = new System.Drawing.Size(287, 27);
            this.cmbUserRole.TabIndex = 1111132;
            // 
            // txtDSlNo
            // 
            this.txtDSlNo.BackColor = System.Drawing.SystemColors.Control;
            this.txtDSlNo.Enabled = false;
            this.txtDSlNo.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDSlNo.Location = new System.Drawing.Point(44, 57);
            this.txtDSlNo.Name = "txtDSlNo";
            this.txtDSlNo.ReadOnly = true;
            this.txtDSlNo.Size = new System.Drawing.Size(181, 27);
            this.txtDSlNo.TabIndex = 1111133;
            this.txtDSlNo.Text = "Group";
            // 
            // label1
            // 
            this.label1.Image = global::ROMS.Properties.Resources.New;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(517, 57);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 22);
            this.label1.TabIndex = 1111135;
            this.label1.Text = "        ";
            // 
            // btnAdd
            // 
            this.btnAdd.Image = global::ROMS.Properties.Resources.plus;
            this.btnAdd.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAdd.Location = new System.Drawing.Point(542, 57);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(21, 22);
            this.btnAdd.TabIndex = 1111134;
            this.btnAdd.Text = "        ";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnClose.Image = global::ROMS.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(439, 278);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 29);
            this.btnClose.TabIndex = 5;
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
            this.btnSave.Location = new System.Drawing.Point(347, 278);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(84, 29);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.Enter += new System.EventHandler(this.btnSave_Enter);
            this.btnSave.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnSave_KeyDown);
            this.btnSave.Leave += new System.EventHandler(this.btnSave_Leave);
            // 
            // CP_Brand
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(675, 374);
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
            ((System.ComponentModel.ISupportInitialize)(this.grdGroupList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errBrand)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txtDEBrandName;
        private System.Windows.Forms.TextBox txtEBrandName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox grbform;
        private System.Windows.Forms.ErrorProvider errBrand;
        public System.Windows.Forms.DataGridView grdGroupList;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label btnAdd;
        private System.Windows.Forms.ComboBox cmbUserRole;
        private System.Windows.Forms.TextBox txtDSlNo;
    }
}