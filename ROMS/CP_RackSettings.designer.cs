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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tsRackSettings = new System.Windows.Forms.ToolStrip();
            this.tspRackSettings = new System.Windows.Forms.ToolStripLabel();
            this.lblNoRecordsFound = new System.Windows.Forms.Label();
            this.pnlRackSettings = new System.Windows.Forms.Panel();
            this.grpRackSettings = new System.Windows.Forms.GroupBox();
            this.txtSearchByProduct2 = new System.Windows.Forms.TextBox();
            this.lblSearchByProduct2 = new System.Windows.Forms.Label();
            this.grdViewSupplierMapping = new System.Windows.Forms.DataGridView();
            this.chkRackSettings = new System.Windows.Forms.CheckBox();
            this.txtSearchByProduct1 = new System.Windows.Forms.TextBox();
            this.lblSearchbyProduct1 = new System.Windows.Forms.Label();
            this.grdSupplierMapping = new System.Windows.Forms.DataGridView();
            this.btnView = new System.Windows.Forms.Button();
            this.cmbSubGroup = new System.Windows.Forms.ComboBox();
            this.lblDESubGroup = new System.Windows.Forms.Label();
            this.cmbGroup = new System.Windows.Forms.ComboBox();
            this.lblDEGroup = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.grbDestination = new System.Windows.Forms.GroupBox();
            this.cmbDStockLocation = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbDRack = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.grpSource = new System.Windows.Forms.GroupBox();
            this.cmbSStockLocation = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbSRack = new System.Windows.Forms.ComboBox();
            this.lblDERack = new System.Windows.Forms.Label();
            this.grbProductAddMove = new System.Windows.Forms.GroupBox();
            this.rbMove = new System.Windows.Forms.RadioButton();
            this.rbAdd = new System.Windows.Forms.RadioButton();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.epRackSettings = new System.Windows.Forms.ErrorProvider(this.components);
            this.PRODUCTID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmdpicode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmProductEnglish = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBox5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmRemoveSupplier = new System.Windows.Forms.DataGridViewImageColumn();
            this.tsRackSettings.SuspendLayout();
            this.pnlRackSettings.SuspendLayout();
            this.grpRackSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdViewSupplierMapping)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSupplierMapping)).BeginInit();
            this.grbDestination.SuspendLayout();
            this.grpSource.SuspendLayout();
            this.grbProductAddMove.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epRackSettings)).BeginInit();
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
            this.pnlRackSettings.Location = new System.Drawing.Point(0, 28);
            this.pnlRackSettings.Name = "pnlRackSettings";
            this.pnlRackSettings.Size = new System.Drawing.Size(1354, 646);
            this.pnlRackSettings.TabIndex = 958764;
            // 
            // grpRackSettings
            // 
            this.grpRackSettings.BackColor = System.Drawing.Color.White;
            this.grpRackSettings.Controls.Add(this.txtSearchByProduct2);
            this.grpRackSettings.Controls.Add(this.lblSearchByProduct2);
            this.grpRackSettings.Controls.Add(this.grdViewSupplierMapping);
            this.grpRackSettings.Controls.Add(this.chkRackSettings);
            this.grpRackSettings.Controls.Add(this.txtSearchByProduct1);
            this.grpRackSettings.Controls.Add(this.lblSearchbyProduct1);
            this.grpRackSettings.Controls.Add(this.grdSupplierMapping);
            this.grpRackSettings.Controls.Add(this.btnView);
            this.grpRackSettings.Controls.Add(this.cmbSubGroup);
            this.grpRackSettings.Controls.Add(this.lblDESubGroup);
            this.grpRackSettings.Controls.Add(this.cmbGroup);
            this.grpRackSettings.Controls.Add(this.lblDEGroup);
            this.grpRackSettings.Controls.Add(this.btnAdd);
            this.grpRackSettings.Controls.Add(this.grbDestination);
            this.grpRackSettings.Controls.Add(this.grpSource);
            this.grpRackSettings.Controls.Add(this.grbProductAddMove);
            this.grpRackSettings.Controls.Add(this.btnClose);
            this.grpRackSettings.Controls.Add(this.btnSave);
            this.grpRackSettings.Location = new System.Drawing.Point(7, 1);
            this.grpRackSettings.Name = "grpRackSettings";
            this.grpRackSettings.Size = new System.Drawing.Size(1339, 633);
            this.grpRackSettings.TabIndex = 0;
            this.grpRackSettings.TabStop = false;
            // 
            // txtSearchByProduct2
            // 
            this.txtSearchByProduct2.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchByProduct2.Location = new System.Drawing.Point(887, 226);
            this.txtSearchByProduct2.MaxLength = 50;
            this.txtSearchByProduct2.Name = "txtSearchByProduct2";
            this.txtSearchByProduct2.Size = new System.Drawing.Size(403, 27);
            this.txtSearchByProduct2.TabIndex = 111111;
            //this.txtSearchByProduct2.TextChanged += new System.EventHandler(this.TxtSearchByProduct2_TextChanged);
            //this.txtSearchByProduct2.Enter += new System.EventHandler(this.TxtSearchByProduct2_Enter);
            //this.txtSearchByProduct2.Leave += new System.EventHandler(this.TxtSearchByProduct2_Leave);
            // 
            // lblSearchByProduct2
            // 
            this.lblSearchByProduct2.AutoSize = true;
            this.lblSearchByProduct2.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchByProduct2.Location = new System.Drawing.Point(692, 229);
            this.lblSearchByProduct2.Name = "lblSearchByProduct2";
            this.lblSearchByProduct2.Size = new System.Drawing.Size(190, 20);
            this.lblSearchByProduct2.TabIndex = 1111177;
            this.lblSearchByProduct2.Text = "Search by Product Name/P.I Code";
            // 
            // grdViewSupplierMapping
            // 
            this.grdViewSupplierMapping.AllowUserToAddRows = false;
            this.grdViewSupplierMapping.AllowUserToDeleteRows = false;
            this.grdViewSupplierMapping.AllowUserToResizeRows = false;
            this.grdViewSupplierMapping.BackgroundColor = System.Drawing.Color.White;
            this.grdViewSupplierMapping.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(242)))), ((int)(((byte)(213)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdViewSupplierMapping.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdViewSupplierMapping.ColumnHeadersHeight = 30;
            this.grdViewSupplierMapping.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdViewSupplierMapping.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PRODUCTID,
            this.clmdpicode,
            this.clmProductEnglish,
            this.dataGridViewTextBox5,
            this.dataGridViewTextBoxColumn6,
            this.clmRemoveSupplier});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdViewSupplierMapping.DefaultCellStyle = dataGridViewCellStyle2;
            this.grdViewSupplierMapping.EnableHeadersVisualStyles = false;
            this.grdViewSupplierMapping.GridColor = System.Drawing.Color.White;
            this.grdViewSupplierMapping.Location = new System.Drawing.Point(673, 258);
            this.grdViewSupplierMapping.Name = "grdViewSupplierMapping";
            this.grdViewSupplierMapping.RowHeadersVisible = false;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.grdViewSupplierMapping.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.grdViewSupplierMapping.RowTemplate.Height = 25;
            this.grdViewSupplierMapping.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdViewSupplierMapping.ShowRowErrors = false;
            this.grdViewSupplierMapping.Size = new System.Drawing.Size(619, 315);
            this.grdViewSupplierMapping.TabIndex = 111111111;
        //    this.grdViewSupplierMapping.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrdViewSupplierMapping_CellContentClick);
            // 
            // chkRackSettings
            // 
            this.chkRackSettings.AutoSize = true;
            this.chkRackSettings.Location = new System.Drawing.Point(27, 267);
            this.chkRackSettings.Name = "chkRackSettings";
            this.chkRackSettings.Size = new System.Drawing.Size(15, 14);
            this.chkRackSettings.TabIndex = 1111167;
            this.chkRackSettings.UseVisualStyleBackColor = true;
            this.chkRackSettings.CheckedChanged += new System.EventHandler(this.ChkRackSettings_CheckedChanged);
            // 
            // txtSearchByProduct1
            // 
            this.txtSearchByProduct1.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchByProduct1.Location = new System.Drawing.Point(217, 226);
            this.txtSearchByProduct1.MaxLength = 50;
            this.txtSearchByProduct1.Name = "txtSearchByProduct1";
            this.txtSearchByProduct1.Size = new System.Drawing.Size(403, 27);
            this.txtSearchByProduct1.TabIndex = 1111111;
            //this.txtSearchByProduct1.TextChanged += new System.EventHandler(this.TxtSearchByProduct1_TextChanged);
            //this.txtSearchByProduct1.Enter += new System.EventHandler(this.TxtSearchByProduct1_Enter);
            //this.txtSearchByProduct1.Leave += new System.EventHandler(this.TxtSearchByProduct1_Leave);
            // 
            // lblSearchbyProduct1
            // 
            this.lblSearchbyProduct1.AutoSize = true;
            this.lblSearchbyProduct1.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchbyProduct1.Location = new System.Drawing.Point(22, 229);
            this.lblSearchbyProduct1.Name = "lblSearchbyProduct1";
            this.lblSearchbyProduct1.Size = new System.Drawing.Size(190, 20);
            this.lblSearchbyProduct1.TabIndex = 1111174;
            this.lblSearchbyProduct1.Text = "Search by Product Name/P.I Code";
            // 
            // grdSupplierMapping
            // 
            this.grdSupplierMapping.AllowUserToAddRows = false;
            this.grdSupplierMapping.AllowUserToDeleteRows = false;
            this.grdSupplierMapping.AllowUserToResizeRows = false;
            this.grdSupplierMapping.BackgroundColor = System.Drawing.Color.White;
            this.grdSupplierMapping.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(242)))), ((int)(((byte)(213)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdSupplierMapping.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.grdSupplierMapping.ColumnHeadersHeight = 30;
            this.grdSupplierMapping.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdSupplierMapping.DefaultCellStyle = dataGridViewCellStyle5;
            this.grdSupplierMapping.EnableHeadersVisualStyles = false;
            this.grdSupplierMapping.GridColor = System.Drawing.Color.White;
            this.grdSupplierMapping.Location = new System.Drawing.Point(17, 258);
            this.grdSupplierMapping.Name = "grdSupplierMapping";
            this.grdSupplierMapping.RowHeadersVisible = false;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            this.grdSupplierMapping.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.grdSupplierMapping.RowTemplate.Height = 25;
            this.grdSupplierMapping.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdSupplierMapping.ShowRowErrors = false;
            this.grdSupplierMapping.Size = new System.Drawing.Size(603, 315);
            this.grdSupplierMapping.TabIndex = 1111111;
            this.grdSupplierMapping.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrdSupplierMapping_CellContentClick);
            // 
            // btnView
            // 
            this.btnView.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnView.Image = global::ROMS.Properties.Resources.view;
            this.btnView.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnView.Location = new System.Drawing.Point(345, 184);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(75, 29);
            this.btnView.TabIndex = 9;
            this.btnView.Text = "View";
            this.btnView.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.BtnView_Click);
            this.btnView.Enter += new System.EventHandler(this.BtnView_Enter);
            this.btnView.Leave += new System.EventHandler(this.BtnView_Leave);
            // 
            // cmbSubGroup
            // 
            this.cmbSubGroup.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSubGroup.FormattingEnabled = true;
            this.cmbSubGroup.Location = new System.Drawing.Point(194, 186);
            this.cmbSubGroup.Name = "cmbSubGroup";
            this.cmbSubGroup.Size = new System.Drawing.Size(140, 27);
            this.cmbSubGroup.TabIndex = 8;
            this.cmbSubGroup.SelectedIndexChanged += new System.EventHandler(this.CmbSubGroup_SelectedIndexChanged);
            // 
            // lblDESubGroup
            // 
            this.lblDESubGroup.AutoSize = true;
            this.lblDESubGroup.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDESubGroup.Location = new System.Drawing.Point(194, 163);
            this.lblDESubGroup.Name = "lblDESubGroup";
            this.lblDESubGroup.Size = new System.Drawing.Size(112, 20);
            this.lblDESubGroup.TabIndex = 1111170;
            this.lblDESubGroup.Text = "Product Sub Group";
            // 
            // cmbGroup
            // 
            this.cmbGroup.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbGroup.FormattingEnabled = true;
            this.cmbGroup.Location = new System.Drawing.Point(17, 186);
            this.cmbGroup.Name = "cmbGroup";
            this.cmbGroup.Size = new System.Drawing.Size(163, 27);
            this.cmbGroup.TabIndex = 7;
            this.cmbGroup.SelectedIndexChanged += new System.EventHandler(this.CmbGroup_SelectedIndexChanged);
            // 
            // lblDEGroup
            // 
            this.lblDEGroup.AutoSize = true;
            this.lblDEGroup.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDEGroup.Location = new System.Drawing.Point(17, 163);
            this.lblDEGroup.Name = "lblDEGroup";
            this.lblDEGroup.Size = new System.Drawing.Size(88, 20);
            this.lblDEGroup.TabIndex = 1111168;
            this.lblDEGroup.Text = "Product Group";
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnAdd.Image = global::ROMS.Properties.Resources.add;
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(632, 427);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(29, 29);
            this.btnAdd.TabIndex = 111111;
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdd.UseVisualStyleBackColor = true;
       //     this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // grbDestination
            // 
            this.grbDestination.Controls.Add(this.cmbDStockLocation);
            this.grbDestination.Controls.Add(this.label2);
            this.grbDestination.Controls.Add(this.cmbDRack);
            this.grbDestination.Controls.Add(this.label3);
            this.grbDestination.Location = new System.Drawing.Point(328, 63);
            this.grbDestination.Name = "grbDestination";
            this.grbDestination.Size = new System.Drawing.Size(290, 98);
            this.grbDestination.TabIndex = 5;
            this.grbDestination.TabStop = false;
            this.grbDestination.Text = "Destination";
            // 
            // cmbDStockLocation
            // 
            this.cmbDStockLocation.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDStockLocation.FormattingEnabled = true;
            this.cmbDStockLocation.Location = new System.Drawing.Point(103, 25);
            this.cmbDStockLocation.Name = "cmbDStockLocation";
            this.cmbDStockLocation.Size = new System.Drawing.Size(156, 27);
            this.cmbDStockLocation.TabIndex = 5;
            this.cmbDStockLocation.Enter += new System.EventHandler(this.CmbDStockLocation_Enter);
            this.cmbDStockLocation.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbDStockLocation_KeyDown);
            this.cmbDStockLocation.Leave += new System.EventHandler(this.CmbDStockLocation_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 20);
            this.label2.TabIndex = 1111151;
            this.label2.Text = "Stock Location";
            // 
            // cmbDRack
            // 
            this.cmbDRack.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDRack.FormattingEnabled = true;
            this.cmbDRack.Location = new System.Drawing.Point(103, 59);
            this.cmbDRack.Name = "cmbDRack";
            this.cmbDRack.Size = new System.Drawing.Size(156, 27);
            this.cmbDRack.TabIndex = 6;
            this.cmbDRack.Enter += new System.EventHandler(this.CmbDRack_Enter);
            this.cmbDRack.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbDRack_KeyDown);
            this.cmbDRack.Leave += new System.EventHandler(this.CmbDRack_Leave);
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
            this.grpSource.Controls.Add(this.cmbSStockLocation);
            this.grpSource.Controls.Add(this.label1);
            this.grpSource.Controls.Add(this.cmbSRack);
            this.grpSource.Controls.Add(this.lblDERack);
            this.grpSource.Location = new System.Drawing.Point(21, 63);
            this.grpSource.Name = "grpSource";
            this.grpSource.Size = new System.Drawing.Size(290, 98);
            this.grpSource.TabIndex = 3;
            this.grpSource.TabStop = false;
            this.grpSource.Text = "Source";
            // 
            // cmbSStockLocation
            // 
            this.cmbSStockLocation.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSStockLocation.FormattingEnabled = true;
            this.cmbSStockLocation.Location = new System.Drawing.Point(109, 25);
            this.cmbSStockLocation.Name = "cmbSStockLocation";
            this.cmbSStockLocation.Size = new System.Drawing.Size(156, 27);
            this.cmbSStockLocation.TabIndex = 3;
            this.cmbSStockLocation.SelectedIndexChanged += new System.EventHandler(this.CmbSStockLocation_SelectedIndexChanged);
            this.cmbSStockLocation.Enter += new System.EventHandler(this.CmbSStockLocation_Enter);
            this.cmbSStockLocation.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbSStockLocation_KeyDown);
            this.cmbSStockLocation.Leave += new System.EventHandler(this.CmbSStockLocation_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 20);
            this.label1.TabIndex = 1111151;
            this.label1.Text = "Stock Location";
            // 
            // cmbSRack
            // 
            this.cmbSRack.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSRack.FormattingEnabled = true;
            this.cmbSRack.Location = new System.Drawing.Point(109, 59);
            this.cmbSRack.Name = "cmbSRack";
            this.cmbSRack.Size = new System.Drawing.Size(156, 27);
            this.cmbSRack.TabIndex = 4;
            this.cmbSRack.SelectedIndexChanged += new System.EventHandler(this.CmbSRack_SelectedIndexChanged);
            this.cmbSRack.Enter += new System.EventHandler(this.CmbSRack_Enter);
            this.cmbSRack.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbSRack_KeyDown);
            this.cmbSRack.Leave += new System.EventHandler(this.CmbSRack_Leave);
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
            // grbProductAddMove
            // 
            this.grbProductAddMove.Controls.Add(this.rbMove);
            this.grbProductAddMove.Controls.Add(this.rbAdd);
            this.grbProductAddMove.Location = new System.Drawing.Point(21, 15);
            this.grbProductAddMove.Name = "grbProductAddMove";
            this.grbProductAddMove.Size = new System.Drawing.Size(188, 46);
            this.grbProductAddMove.TabIndex = 1;
            this.grbProductAddMove.TabStop = false;
            // 
            // rbMove
            // 
            this.rbMove.AutoSize = true;
            this.rbMove.Font = new System.Drawing.Font("Oswald Regular", 9.75F);
            this.rbMove.Location = new System.Drawing.Point(95, 17);
            this.rbMove.Name = "rbMove";
            this.rbMove.Size = new System.Drawing.Size(91, 21);
            this.rbMove.TabIndex = 2;
            this.rbMove.Text = "Move Product";
            this.rbMove.UseVisualStyleBackColor = true;
            this.rbMove.CheckedChanged += new System.EventHandler(this.RbMove_CheckedChanged);
            // 
            // rbAdd
            // 
            this.rbAdd.AutoSize = true;
            this.rbAdd.Checked = true;
            this.rbAdd.Font = new System.Drawing.Font("Oswald Regular", 9.75F);
            this.rbAdd.Location = new System.Drawing.Point(5, 17);
            this.rbAdd.Name = "rbAdd";
            this.rbAdd.Size = new System.Drawing.Size(84, 21);
            this.rbAdd.TabIndex = 1;
            this.rbAdd.TabStop = true;
            this.rbAdd.Text = "Add Product";
            this.rbAdd.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnClose.Image = global::ROMS.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(1245, 585);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 29);
            this.btnClose.TabIndex = 11;
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
            this.btnSave.Location = new System.Drawing.Point(1155, 585);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(84, 29);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            this.btnSave.Enter += new System.EventHandler(this.BtnSave_Enter);
            this.btnSave.Leave += new System.EventHandler(this.BtnSave_Leave);
            // 
            // epRackSettings
            // 
            this.epRackSettings.ContainerControl = this;
            // 
            // PRODUCTID
            // 
            this.PRODUCTID.HeaderText = "S.No.";
            this.PRODUCTID.Name = "PRODUCTID";
            this.PRODUCTID.Visible = false;
            // 
            // clmdpicode
            // 
            this.clmdpicode.HeaderText = "P.I Code";
            this.clmdpicode.Name = "clmdpicode";
            // 
            // clmProductEnglish
            // 
            this.clmProductEnglish.HeaderText = "Product Name in English";
            this.clmProductEnglish.Name = "clmProductEnglish";
            this.clmProductEnglish.Width = 220;
            // 
            // dataGridViewTextBox5
            // 
            this.dataGridViewTextBox5.HeaderText = "Product Name in Tamil";
            this.dataGridViewTextBox5.Name = "dataGridViewTextBox5";
            this.dataGridViewTextBox5.Width = 220;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Unit";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // clmRemoveSupplier
            // 
            this.clmRemoveSupplier.HeaderText = "Remove";
            this.clmRemoveSupplier.Image = global::ROMS.Properties.Resources.remove;
            this.clmRemoveSupplier.Name = "clmRemoveSupplier";
            this.clmRemoveSupplier.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmRemoveSupplier.Width = 70;
            // 
            // CP_RackSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
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
            ((System.ComponentModel.ISupportInitialize)(this.grdViewSupplierMapping)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSupplierMapping)).EndInit();
            this.grbDestination.ResumeLayout(false);
            this.grbDestination.PerformLayout();
            this.grpSource.ResumeLayout(false);
            this.grpSource.PerformLayout();
            this.grbProductAddMove.ResumeLayout(false);
            this.grbProductAddMove.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epRackSettings)).EndInit();
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
        private System.Windows.Forms.GroupBox grbProductAddMove;
        private System.Windows.Forms.RadioButton rbMove;
        private System.Windows.Forms.RadioButton rbAdd;
        private System.Windows.Forms.Label lblDERack;
        private System.Windows.Forms.ComboBox cmbSRack;
        private System.Windows.Forms.GroupBox grpSource;
        private System.Windows.Forms.ComboBox cmbSStockLocation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grbDestination;
        private System.Windows.Forms.ComboBox cmbDStockLocation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbDRack;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkRackSettings;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.ComboBox cmbSubGroup;
        private System.Windows.Forms.Label lblDESubGroup;
        private System.Windows.Forms.ComboBox cmbGroup;
        private System.Windows.Forms.Label lblDEGroup;
        private System.Windows.Forms.TextBox txtSearchByProduct1;
        private System.Windows.Forms.Label lblSearchbyProduct1;
        public System.Windows.Forms.DataGridView grdSupplierMapping;
        private System.Windows.Forms.TextBox txtSearchByProduct2;
        private System.Windows.Forms.Label lblSearchByProduct2;
        public System.Windows.Forms.DataGridView grdViewSupplierMapping;
        private System.Windows.Forms.ErrorProvider epRackSettings;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRODUCTID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmdpicode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmProductEnglish;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBox5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewImageColumn clmRemoveSupplier;
    }
}