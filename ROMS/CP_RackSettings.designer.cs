namespace ROMS
{
    partial class CP_RackSettings
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tsRackSettings = new System.Windows.Forms.ToolStrip();
            this.tspRackSettings = new System.Windows.Forms.ToolStripLabel();
            this.lblNoRecordsFound = new System.Windows.Forms.Label();
            this.pnlRackSettings = new System.Windows.Forms.Panel();
            this.grpRackSettings = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.grpSource = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbRack = new System.Windows.Forms.ComboBox();
            this.lblDERack = new System.Windows.Forms.Label();
            this.chkSelectAll = new System.Windows.Forms.CheckBox();
            this.btnAdd = new System.Windows.Forms.Label();
            this.grdRackSettings = new System.Windows.Forms.DataGridView();
            this.grbProductAddMove = new System.Windows.Forms.GroupBox();
            this.rbMove = new System.Windows.Forms.RadioButton();
            this.rbAdd = new System.Windows.Forms.RadioButton();
            this.txtProductNamePICode = new System.Windows.Forms.TextBox();
            this.lblDEProductName = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.chksupplier = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPICode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmProductnameInEnglish = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmProductNameInTamil = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tsRackSettings.SuspendLayout();
            this.pnlRackSettings.SuspendLayout();
            this.grpRackSettings.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.grpSource.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdRackSettings)).BeginInit();
            this.grbProductAddMove.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsRackSettings
            // 
            this.tsRackSettings.BackColor = System.Drawing.Color.White;
            this.tsRackSettings.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsRackSettings.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsRackSettings.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspRackSettings});
            this.tsRackSettings.Location = new System.Drawing.Point(0, 0);
            this.tsRackSettings.Name = "tsRackSettings";
            this.tsRackSettings.Size = new System.Drawing.Size(1354, 25);
            this.tsRackSettings.TabIndex = 35;
            this.tsRackSettings.Text = "Rack Settings";
            // 
            // tspRackSettings
            // 
            this.tspRackSettings.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tspRackSettings.Image = global::ROMS.Properties.Resources.bread_crumb;
            this.tspRackSettings.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tspRackSettings.Margin = new System.Windows.Forms.Padding(15, 1, 0, 2);
            this.tspRackSettings.Name = "tspRackSettings";
            this.tspRackSettings.Size = new System.Drawing.Size(100, 22);
            this.tspRackSettings.Text = "Rack Settings";
            // 
            // lblNoRecordsFound
            // 
            this.lblNoRecordsFound.AutoSize = true;
            this.lblNoRecordsFound.BackColor = System.Drawing.Color.White;
            this.lblNoRecordsFound.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoRecordsFound.Location = new System.Drawing.Point(627, 327);
            this.lblNoRecordsFound.Name = "lblNoRecordsFound";
            this.lblNoRecordsFound.Size = new System.Drawing.Size(106, 20);
            this.lblNoRecordsFound.TabIndex = 958763;
            this.lblNoRecordsFound.Text = "No Records Found";
            this.lblNoRecordsFound.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pnlRackSettings
            // 
            this.pnlRackSettings.BackColor = System.Drawing.Color.White;
            this.pnlRackSettings.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRackSettings.Controls.Add(this.grpRackSettings);
            this.pnlRackSettings.Location = new System.Drawing.Point(1, 38);
            this.pnlRackSettings.Name = "pnlRackSettings";
            this.pnlRackSettings.Size = new System.Drawing.Size(1359, 648);
            this.pnlRackSettings.TabIndex = 958764;
            // 
            // grpRackSettings
            // 
            this.grpRackSettings.BackColor = System.Drawing.Color.White;
            this.grpRackSettings.Controls.Add(this.groupBox1);
            this.grpRackSettings.Controls.Add(this.grpSource);
            this.grpRackSettings.Controls.Add(this.chkSelectAll);
            this.grpRackSettings.Controls.Add(this.btnAdd);
            this.grpRackSettings.Controls.Add(this.grdRackSettings);
            this.grpRackSettings.Controls.Add(this.grbProductAddMove);
            this.grpRackSettings.Controls.Add(this.txtProductNamePICode);
            this.grpRackSettings.Controls.Add(this.lblDEProductName);
            this.grpRackSettings.Controls.Add(this.btnClose);
            this.grpRackSettings.Controls.Add(this.btnSave);
            this.grpRackSettings.Location = new System.Drawing.Point(12, 3);
            this.grpRackSettings.Name = "grpRackSettings";
            this.grpRackSettings.Size = new System.Drawing.Size(1330, 615);
            this.grpRackSettings.TabIndex = 958765;
            this.grpRackSettings.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboBox4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(328, 63);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(290, 98);
            this.groupBox1.TabIndex = 1111158;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Destination";
            // 
            // comboBox3
            // 
            this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox3.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(103, 25);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(156, 27);
            this.comboBox3.TabIndex = 1111152;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 20);
            this.label2.TabIndex = 1111151;
            this.label2.Text = "Shop Location";
            // 
            // comboBox4
            // 
            this.comboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox4.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Location = new System.Drawing.Point(103, 59);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(156, 27);
            this.comboBox4.TabIndex = 1111150;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(18, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 20);
            this.label3.TabIndex = 1111149;
            this.label3.Text = "Rack";
            // 
            // grpSource
            // 
            this.grpSource.Controls.Add(this.comboBox1);
            this.grpSource.Controls.Add(this.label1);
            this.grpSource.Controls.Add(this.cmbRack);
            this.grpSource.Controls.Add(this.lblDERack);
            this.grpSource.Location = new System.Drawing.Point(21, 63);
            this.grpSource.Name = "grpSource";
            this.grpSource.Size = new System.Drawing.Size(290, 98);
            this.grpSource.TabIndex = 1111157;
            this.grpSource.TabStop = false;
            this.grpSource.Text = "Source";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(109, 25);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(156, 27);
            this.comboBox1.TabIndex = 1111152;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 20);
            this.label1.TabIndex = 1111151;
            this.label1.Text = "Shop Location";
            // 
            // cmbRack
            // 
            this.cmbRack.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRack.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRack.FormattingEnabled = true;
            this.cmbRack.Location = new System.Drawing.Point(109, 59);
            this.cmbRack.Name = "cmbRack";
            this.cmbRack.Size = new System.Drawing.Size(156, 27);
            this.cmbRack.TabIndex = 1111150;
            // 
            // lblDERack
            // 
            this.lblDERack.AutoSize = true;
            this.lblDERack.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDERack.Location = new System.Drawing.Point(20, 61);
            this.lblDERack.Name = "lblDERack";
            this.lblDERack.Size = new System.Drawing.Size(35, 20);
            this.lblDERack.TabIndex = 1111149;
            this.lblDERack.Text = "Rack";
            // 
            // chkSelectAll
            // 
            this.chkSelectAll.AutoSize = true;
            this.chkSelectAll.Location = new System.Drawing.Point(39, 207);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Size = new System.Drawing.Size(15, 14);
            this.chkSelectAll.TabIndex = 1111148;
            this.chkSelectAll.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.SystemColors.Control;
            this.btnAdd.Image = global::ROMS.Properties.Resources.plus;
            this.btnAdd.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAdd.Location = new System.Drawing.Point(595, 168);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(21, 22);
            this.btnAdd.TabIndex = 1111156;
            this.btnAdd.Text = "        ";
            // 
            // grdRackSettings
            // 
            this.grdRackSettings.AllowUserToAddRows = false;
            this.grdRackSettings.AllowUserToDeleteRows = false;
            this.grdRackSettings.AllowUserToResizeColumns = false;
            this.grdRackSettings.AllowUserToResizeRows = false;
            this.grdRackSettings.BackgroundColor = System.Drawing.Color.White;
            this.grdRackSettings.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(242)))), ((int)(((byte)(213)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdRackSettings.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdRackSettings.ColumnHeadersHeight = 30;
            this.grdRackSettings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdRackSettings.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chksupplier,
            this.Column1,
            this.clmPICode,
            this.clmProductnameInEnglish,
            this.clmProductNameInTamil,
            this.Column2,
            this.clmUnit});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdRackSettings.DefaultCellStyle = dataGridViewCellStyle2;
            this.grdRackSettings.EnableHeadersVisualStyles = false;
            this.grdRackSettings.GridColor = System.Drawing.Color.White;
            this.grdRackSettings.Location = new System.Drawing.Point(21, 197);
            this.grdRackSettings.Name = "grdRackSettings";
            this.grdRackSettings.ReadOnly = true;
            this.grdRackSettings.RowHeadersVisible = false;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.grdRackSettings.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.grdRackSettings.RowTemplate.Height = 25;
            this.grdRackSettings.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdRackSettings.Size = new System.Drawing.Size(1286, 377);
            this.grdRackSettings.TabIndex = 1111147;
            // 
            // grbProductAddMove
            // 
            this.grbProductAddMove.Controls.Add(this.rbMove);
            this.grbProductAddMove.Controls.Add(this.rbAdd);
            this.grbProductAddMove.Location = new System.Drawing.Point(21, 15);
            this.grbProductAddMove.Name = "grbProductAddMove";
            this.grbProductAddMove.Size = new System.Drawing.Size(188, 46);
            this.grbProductAddMove.TabIndex = 1111155;
            this.grbProductAddMove.TabStop = false;
            // 
            // rbMove
            // 
            this.rbMove.AutoSize = true;
            this.rbMove.Font = new System.Drawing.Font("Oswald Regular", 9.75F);
            this.rbMove.Location = new System.Drawing.Point(95, 17);
            this.rbMove.Name = "rbMove";
            this.rbMove.Size = new System.Drawing.Size(91, 21);
            this.rbMove.TabIndex = 32;
            this.rbMove.Text = "Move Product";
            this.rbMove.UseVisualStyleBackColor = true;
            // 
            // rbAdd
            // 
            this.rbAdd.AutoSize = true;
            this.rbAdd.Checked = true;
            this.rbAdd.Font = new System.Drawing.Font("Oswald Regular", 9.75F);
            this.rbAdd.Location = new System.Drawing.Point(5, 17);
            this.rbAdd.Name = "rbAdd";
            this.rbAdd.Size = new System.Drawing.Size(84, 21);
            this.rbAdd.TabIndex = 31;
            this.rbAdd.TabStop = true;
            this.rbAdd.Text = "Add Product";
            this.rbAdd.UseVisualStyleBackColor = true;
            // 
            // txtProductNamePICode
            // 
            this.txtProductNamePICode.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductNamePICode.Location = new System.Drawing.Point(164, 166);
            this.txtProductNamePICode.MaxLength = 50;
            this.txtProductNamePICode.Name = "txtProductNamePICode";
            this.txtProductNamePICode.Size = new System.Drawing.Size(423, 27);
            this.txtProductNamePICode.TabIndex = 1111151;
            // 
            // lblDEProductName
            // 
            this.lblDEProductName.AutoSize = true;
            this.lblDEProductName.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDEProductName.Location = new System.Drawing.Point(21, 169);
            this.lblDEProductName.Name = "lblDEProductName";
            this.lblDEProductName.Size = new System.Drawing.Size(140, 20);
            this.lblDEProductName.TabIndex = 1111152;
            this.lblDEProductName.Text = "Product Name / P.I Code";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnClose.Image = global::ROMS.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(1232, 580);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 29);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnSave.Image = global::ROMS.Properties.Resources.save;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(1139, 580);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(84, 29);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // chksupplier
            // 
            this.chksupplier.HeaderText = "";
            this.chksupplier.Name = "chksupplier";
            this.chksupplier.ReadOnly = true;
            this.chksupplier.Width = 50;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "S.No.";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 50;
            // 
            // clmPICode
            // 
            this.clmPICode.HeaderText = "P.I Code";
            this.clmPICode.Name = "clmPICode";
            this.clmPICode.ReadOnly = true;
            // 
            // clmProductnameInEnglish
            // 
            this.clmProductnameInEnglish.HeaderText = "Product Name In English";
            this.clmProductnameInEnglish.Name = "clmProductnameInEnglish";
            this.clmProductnameInEnglish.ReadOnly = true;
            this.clmProductnameInEnglish.Width = 400;
            // 
            // clmProductNameInTamil
            // 
            this.clmProductNameInTamil.HeaderText = "Product Name In Tamil";
            this.clmProductNameInTamil.Name = "clmProductNameInTamil";
            this.clmProductNameInTamil.ReadOnly = true;
            this.clmProductNameInTamil.Width = 400;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Maximum Order Qty";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 150;
            // 
            // clmUnit
            // 
            this.clmUnit.HeaderText = "Unit";
            this.clmUnit.Name = "clmUnit";
            this.clmUnit.ReadOnly = true;
            // 
            // CP_RackSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(1354, 675);
            this.Controls.Add(this.pnlRackSettings);
            this.Controls.Add(this.lblNoRecordsFound);
            this.Controls.Add(this.tsRackSettings);
            this.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "CP_RackSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Supplier Mapping";
            this.Load += new System.EventHandler(this.CP_BrandList_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CP_BrandList_KeyDown);
            this.tsRackSettings.ResumeLayout(false);
            this.tsRackSettings.PerformLayout();
            this.pnlRackSettings.ResumeLayout(false);
            this.grpRackSettings.ResumeLayout(false);
            this.grpRackSettings.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpSource.ResumeLayout(false);
            this.grpSource.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdRackSettings)).EndInit();
            this.grbProductAddMove.ResumeLayout(false);
            this.grbProductAddMove.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsRackSettings;
        private System.Windows.Forms.ToolStripLabel tspRackSettings;
        private System.Windows.Forms.Label lblNoRecordsFound;
        private System.Windows.Forms.Panel pnlRackSettings;
        private System.Windows.Forms.GroupBox grpRackSettings;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox chkSelectAll;
        internal System.Windows.Forms.Label btnAdd;
        public System.Windows.Forms.DataGridView grdRackSettings;
        private System.Windows.Forms.GroupBox grbProductAddMove;
        private System.Windows.Forms.RadioButton rbMove;
        private System.Windows.Forms.RadioButton rbAdd;
        private System.Windows.Forms.TextBox txtProductNamePICode;
        private System.Windows.Forms.Label lblDEProductName;
        private System.Windows.Forms.Label lblDERack;
        private System.Windows.Forms.ComboBox cmbRack;
        private System.Windows.Forms.GroupBox grpSource;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chksupplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPICode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmProductnameInEnglish;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmProductNameInTamil;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmUnit;
    }
}