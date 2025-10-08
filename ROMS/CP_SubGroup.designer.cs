namespace ROMS
{
    partial class CP_SubGroup
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CP_SubGroup));
            this.grbform = new System.Windows.Forms.GroupBox();
            this.lvGroupName = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.cmbSubgroupType = new System.Windows.Forms.ComboBox();
            this.lblGroupCode = new System.Windows.Forms.Label();
            this.txtProductGroupName = new System.Windows.Forms.TextBox();
            this.cmbBatchNo = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtEProductSubGroupNameTamil = new System.Windows.Forms.TextBox();
            this.txtESubGroupNameTamil = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Label();
            this.txtDGroupName = new System.Windows.Forms.TextBox();
            this.txtDStatus = new System.Windows.Forms.TextBox();
            this.pnlStatus = new System.Windows.Forms.Panel();
            this.rbActive = new System.Windows.Forms.RadioButton();
            this.rbInactive = new System.Windows.Forms.RadioButton();
            this.txtDEProductSubGroupNameEnglish = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtESubGroupNameEnglish = new System.Windows.Forms.TextBox();
            this.grpPurchaseStockLocation = new System.Windows.Forms.GroupBox();
            this.txtRack = new System.Windows.Forms.TextBox();
            this.grdRackList = new System.Windows.Forms.DataGridView();
            this.btnNewRack = new System.Windows.Forms.Label();
            this.btnewlocation = new System.Windows.Forms.Label();
            this.lblRack = new System.Windows.Forms.Label();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.txtSDtockLocation = new System.Windows.Forms.TextBox();
            this.txtDRack = new System.Windows.Forms.TextBox();
            this.epSubGroup = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblLocation = new System.Windows.Forms.Label();
            this.DGV_FilterLocation = new System.Windows.Forms.DataGridView();
            this.grbform.SuspendLayout();
            this.pnlStatus.SuspendLayout();
            this.grpPurchaseStockLocation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdRackList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epSubGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_FilterLocation)).BeginInit();
            this.SuspendLayout();
            // 
            // grbform
            // 
            this.grbform.Controls.Add(this.DGV_FilterLocation);
            this.grbform.Controls.Add(this.lvGroupName);
            this.grbform.Controls.Add(this.textBox2);
            this.grbform.Controls.Add(this.cmbSubgroupType);
            this.grbform.Controls.Add(this.lblGroupCode);
            this.grbform.Controls.Add(this.txtProductGroupName);
            this.grbform.Controls.Add(this.cmbBatchNo);
            this.grbform.Controls.Add(this.textBox1);
            this.grbform.Controls.Add(this.txtEProductSubGroupNameTamil);
            this.grbform.Controls.Add(this.txtESubGroupNameTamil);
            this.grbform.Controls.Add(this.btnAdd);
            this.grbform.Controls.Add(this.txtDGroupName);
            this.grbform.Controls.Add(this.txtDStatus);
            this.grbform.Controls.Add(this.pnlStatus);
            this.grbform.Controls.Add(this.txtDEProductSubGroupNameEnglish);
            this.grbform.Controls.Add(this.btnClose);
            this.grbform.Controls.Add(this.btnSave);
            this.grbform.Controls.Add(this.txtESubGroupNameEnglish);
            this.grbform.Controls.Add(this.grpPurchaseStockLocation);
            this.grbform.Location = new System.Drawing.Point(11, 1);
            this.grbform.Name = "grbform";
            this.grbform.Size = new System.Drawing.Size(453, 446);
            this.grbform.TabIndex = 0;
            this.grbform.TabStop = false;
            // 
            // lvGroupName
            // 
            this.lvGroupName.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvGroupName.Font = new System.Drawing.Font("Oswald Regular", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvGroupName.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvGroupName.HideSelection = false;
            this.lvGroupName.Location = new System.Drawing.Point(224, 48);
            this.lvGroupName.Name = "lvGroupName";
            this.lvGroupName.Size = new System.Drawing.Size(223, 90);
            this.lvGroupName.TabIndex = 1111144;
            this.lvGroupName.UseCompatibleStateImageBehavior = false;
            this.lvGroupName.View = System.Windows.Forms.View.Details;
            this.lvGroupName.Visible = false;
            this.lvGroupName.DoubleClick += new System.EventHandler(this.LvGroupName_DoubleClick);
            this.lvGroupName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LvGroupName_KeyDown);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 180;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Width = 120;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Width = 0;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.Control;
            this.textBox2.Enabled = false;
            this.textBox2.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(24, 101);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(200, 27);
            this.textBox2.TabIndex = 1111147;
            this.textBox2.Text = "Product Subgroup Type";
            // 
            // cmbSubgroupType
            // 
            this.cmbSubgroupType.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSubgroupType.FormattingEnabled = true;
            this.cmbSubgroupType.Location = new System.Drawing.Point(224, 101);
            this.cmbSubgroupType.Name = "cmbSubgroupType";
            this.cmbSubgroupType.Size = new System.Drawing.Size(200, 27);
            this.cmbSubgroupType.TabIndex = 3;
            this.cmbSubgroupType.Enter += new System.EventHandler(this.CmbSubgroupType_Enter);
            this.cmbSubgroupType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbSubgroupType_KeyDown);
            this.cmbSubgroupType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbSubgroupType_KeyPress);
            this.cmbSubgroupType.Leave += new System.EventHandler(this.CmbSubgroupType_Leave);
            // 
            // lblGroupCode
            // 
            this.lblGroupCode.AutoSize = true;
            this.lblGroupCode.Location = new System.Drawing.Point(9, 25);
            this.lblGroupCode.Name = "lblGroupCode";
            this.lblGroupCode.Size = new System.Drawing.Size(0, 18);
            this.lblGroupCode.TabIndex = 1111145;
            this.lblGroupCode.Visible = false;
            // 
            // txtProductGroupName
            // 
            this.txtProductGroupName.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductGroupName.Location = new System.Drawing.Point(224, 20);
            this.txtProductGroupName.MaxLength = 100;
            this.txtProductGroupName.Name = "txtProductGroupName";
            this.txtProductGroupName.Size = new System.Drawing.Size(200, 28);
            this.txtProductGroupName.TabIndex = 0;
            this.txtProductGroupName.TextChanged += new System.EventHandler(this.TxtProductGroupName_TextChanged);
            this.txtProductGroupName.Enter += new System.EventHandler(this.TxtProductGroupName_Enter);
            this.txtProductGroupName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtProductGroupName_KeyDown);
            this.txtProductGroupName.Leave += new System.EventHandler(this.TxtProductGroupName_Leave);
            // 
            // cmbBatchNo
            // 
            this.cmbBatchNo.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBatchNo.FormattingEnabled = true;
            this.cmbBatchNo.Location = new System.Drawing.Point(224, 128);
            this.cmbBatchNo.Name = "cmbBatchNo";
            this.cmbBatchNo.Size = new System.Drawing.Size(200, 27);
            this.cmbBatchNo.TabIndex = 3;
            this.cmbBatchNo.Visible = false;
            this.cmbBatchNo.SelectedIndexChanged += new System.EventHandler(this.CmbBatchNo_SelectedIndexChanged);
            this.cmbBatchNo.Enter += new System.EventHandler(this.CmbBatchNo_Enter);
            this.cmbBatchNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbBatchNo_KeyDown);
            this.cmbBatchNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbBatchNo_KeyPress);
            this.cmbBatchNo.Leave += new System.EventHandler(this.CmbBatchNo_Leave);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(24, 128);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(200, 27);
            this.textBox1.TabIndex = 1111142;
            this.textBox1.Text = "Batch No.";
            this.textBox1.Visible = false;
            // 
            // txtEProductSubGroupNameTamil
            // 
            this.txtEProductSubGroupNameTamil.BackColor = System.Drawing.SystemColors.Control;
            this.txtEProductSubGroupNameTamil.Enabled = false;
            this.txtEProductSubGroupNameTamil.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEProductSubGroupNameTamil.Location = new System.Drawing.Point(24, 74);
            this.txtEProductSubGroupNameTamil.Name = "txtEProductSubGroupNameTamil";
            this.txtEProductSubGroupNameTamil.ReadOnly = true;
            this.txtEProductSubGroupNameTamil.Size = new System.Drawing.Size(200, 27);
            this.txtEProductSubGroupNameTamil.TabIndex = 1111133;
            this.txtEProductSubGroupNameTamil.Text = "Product Subgroup Name in Tamil";
            // 
            // txtESubGroupNameTamil
            // 
            this.txtESubGroupNameTamil.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtESubGroupNameTamil.Location = new System.Drawing.Point(224, 74);
            this.txtESubGroupNameTamil.MaxLength = 100;
            this.txtESubGroupNameTamil.Name = "txtESubGroupNameTamil";
            this.txtESubGroupNameTamil.Size = new System.Drawing.Size(200, 27);
            this.txtESubGroupNameTamil.TabIndex = 2;
            this.txtESubGroupNameTamil.Enter += new System.EventHandler(this.TxtESubGroupNameTamil_Enter);
            this.txtESubGroupNameTamil.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtESubGroupNameTamil_KeyDown);
            this.txtESubGroupNameTamil.Leave += new System.EventHandler(this.TxtESubGroupNameTamil_Leave);
            // 
            // btnAdd
            // 
            this.btnAdd.Image = global::ROMS.Properties.Resources.New;
            this.btnAdd.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAdd.Location = new System.Drawing.Point(427, 22);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(21, 22);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "        ";
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // txtDGroupName
            // 
            this.txtDGroupName.BackColor = System.Drawing.SystemColors.Control;
            this.txtDGroupName.Enabled = false;
            this.txtDGroupName.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDGroupName.Location = new System.Drawing.Point(24, 20);
            this.txtDGroupName.Name = "txtDGroupName";
            this.txtDGroupName.ReadOnly = true;
            this.txtDGroupName.Size = new System.Drawing.Size(200, 27);
            this.txtDGroupName.TabIndex = 1111130;
            this.txtDGroupName.Text = "Product Group Name";
            // 
            // txtDStatus
            // 
            this.txtDStatus.BackColor = System.Drawing.SystemColors.Control;
            this.txtDStatus.Enabled = false;
            this.txtDStatus.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDStatus.Location = new System.Drawing.Point(24, 369);
            this.txtDStatus.Name = "txtDStatus";
            this.txtDStatus.ReadOnly = true;
            this.txtDStatus.Size = new System.Drawing.Size(200, 27);
            this.txtDStatus.TabIndex = 17;
            this.txtDStatus.Text = "Status";
            // 
            // pnlStatus
            // 
            this.pnlStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlStatus.Controls.Add(this.rbActive);
            this.pnlStatus.Controls.Add(this.rbInactive);
            this.pnlStatus.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlStatus.Location = new System.Drawing.Point(224, 369);
            this.pnlStatus.Name = "pnlStatus";
            this.pnlStatus.Size = new System.Drawing.Size(199, 27);
            this.pnlStatus.TabIndex = 7;
            // 
            // rbActive
            // 
            this.rbActive.AutoSize = true;
            this.rbActive.Checked = true;
            this.rbActive.Font = new System.Drawing.Font("Oswald Regular", 9.75F);
            this.rbActive.Location = new System.Drawing.Point(20, 1);
            this.rbActive.Name = "rbActive";
            this.rbActive.Size = new System.Drawing.Size(54, 21);
            this.rbActive.TabIndex = 6;
            this.rbActive.TabStop = true;
            this.rbActive.Text = "Active";
            this.rbActive.UseVisualStyleBackColor = true;
            this.rbActive.Enter += new System.EventHandler(this.RbActive_Enter);
            this.rbActive.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RbActive_KeyDown);
            this.rbActive.Leave += new System.EventHandler(this.RbActive_Leave);
            // 
            // rbInactive
            // 
            this.rbInactive.AutoSize = true;
            this.rbInactive.Font = new System.Drawing.Font("Oswald Regular", 9.75F);
            this.rbInactive.Location = new System.Drawing.Point(112, 1);
            this.rbInactive.Name = "rbInactive";
            this.rbInactive.Size = new System.Drawing.Size(63, 21);
            this.rbInactive.TabIndex = 7;
            this.rbInactive.Text = "Inactive";
            this.rbInactive.UseVisualStyleBackColor = true;
            this.rbInactive.Enter += new System.EventHandler(this.RbInactive_Enter);
            this.rbInactive.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RbInactive_KeyDown);
            this.rbInactive.Leave += new System.EventHandler(this.RbInactive_Leave);
            // 
            // txtDEProductSubGroupNameEnglish
            // 
            this.txtDEProductSubGroupNameEnglish.BackColor = System.Drawing.SystemColors.Control;
            this.txtDEProductSubGroupNameEnglish.Enabled = false;
            this.txtDEProductSubGroupNameEnglish.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDEProductSubGroupNameEnglish.Location = new System.Drawing.Point(24, 47);
            this.txtDEProductSubGroupNameEnglish.Name = "txtDEProductSubGroupNameEnglish";
            this.txtDEProductSubGroupNameEnglish.ReadOnly = true;
            this.txtDEProductSubGroupNameEnglish.Size = new System.Drawing.Size(200, 27);
            this.txtDEProductSubGroupNameEnglish.TabIndex = 11;
            this.txtDEProductSubGroupNameEnglish.Text = "Product Subgroup Name in English";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnClose.Image = global::ROMS.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(345, 402);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(79, 29);
            this.btnClose.TabIndex = 9;
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
            this.btnSave.Location = new System.Drawing.Point(263, 402);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(79, 29);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.Enter += new System.EventHandler(this.btnSave_Enter);
            this.btnSave.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnSave_KeyDown);
            this.btnSave.Leave += new System.EventHandler(this.btnSave_Leave);
            // 
            // txtESubGroupNameEnglish
            // 
            this.txtESubGroupNameEnglish.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtESubGroupNameEnglish.Location = new System.Drawing.Point(224, 47);
            this.txtESubGroupNameEnglish.MaxLength = 100;
            this.txtESubGroupNameEnglish.Name = "txtESubGroupNameEnglish";
            this.txtESubGroupNameEnglish.Size = new System.Drawing.Size(200, 27);
            this.txtESubGroupNameEnglish.TabIndex = 1;
            this.txtESubGroupNameEnglish.Enter += new System.EventHandler(this.txtESubGroupNameEnglish_Enter);
            this.txtESubGroupNameEnglish.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtESubGroupNameEnglish_KeyDown);
            this.txtESubGroupNameEnglish.Leave += new System.EventHandler(this.txtESubGroupNameEnglish_Leave);
            // 
            // grpPurchaseStockLocation
            // 
            this.grpPurchaseStockLocation.Controls.Add(this.txtRack);
            this.grpPurchaseStockLocation.Controls.Add(this.grdRackList);
            this.grpPurchaseStockLocation.Controls.Add(this.btnNewRack);
            this.grpPurchaseStockLocation.Controls.Add(this.btnewlocation);
            this.grpPurchaseStockLocation.Controls.Add(this.lblRack);
            this.grpPurchaseStockLocation.Controls.Add(this.txtLocation);
            this.grpPurchaseStockLocation.Controls.Add(this.txtSDtockLocation);
            this.grpPurchaseStockLocation.Controls.Add(this.txtDRack);
            this.grpPurchaseStockLocation.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.grpPurchaseStockLocation.Location = new System.Drawing.Point(7, 128);
            this.grpPurchaseStockLocation.Name = "grpPurchaseStockLocation";
            this.grpPurchaseStockLocation.Size = new System.Drawing.Size(440, 235);
            this.grpPurchaseStockLocation.TabIndex = 4;
            this.grpPurchaseStockLocation.TabStop = false;
            this.grpPurchaseStockLocation.Text = "Default Stock Location for Purchase";
            // 
            // txtRack
            // 
            this.txtRack.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtRack.Location = new System.Drawing.Point(217, 57);
            this.txtRack.MaxLength = 100;
            this.txtRack.Name = "txtRack";
            this.txtRack.Size = new System.Drawing.Size(200, 27);
            this.txtRack.TabIndex = 5;
            this.txtRack.TextChanged += new System.EventHandler(this.TxtRack_TextChanged);
            this.txtRack.Enter += new System.EventHandler(this.TxtRack_Enter);
            this.txtRack.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtRack_KeyDown);
            this.txtRack.Layout += new System.Windows.Forms.LayoutEventHandler(this.TxtRack_Layout);
            this.txtRack.Leave += new System.EventHandler(this.TxtRack_Leave);
            // 
            // grdRackList
            // 
            this.grdRackList.AllowUserToAddRows = false;
            this.grdRackList.AllowUserToDeleteRows = false;
            this.grdRackList.AllowUserToResizeColumns = false;
            this.grdRackList.AllowUserToResizeRows = false;
            this.grdRackList.BackgroundColor = System.Drawing.Color.White;
            this.grdRackList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdRackList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.grdRackList.ColumnHeadersHeight = 25;
            this.grdRackList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdRackList.DefaultCellStyle = dataGridViewCellStyle6;
            this.grdRackList.EnableHeadersVisualStyles = false;
            this.grdRackList.GridColor = System.Drawing.Color.White;
            this.grdRackList.Location = new System.Drawing.Point(17, 84);
            this.grdRackList.Name = "grdRackList";
            this.grdRackList.RowHeadersVisible = false;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.White;
            this.grdRackList.RowsDefaultCellStyle = dataGridViewCellStyle7;
            this.grdRackList.RowTemplate.Height = 25;
            this.grdRackList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdRackList.Size = new System.Drawing.Size(400, 142);
            this.grdRackList.TabIndex = 6;
            this.grdRackList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrdRackList_CellContentClick);
            this.grdRackList.CurrentCellDirtyStateChanged += new System.EventHandler(this.GrdRackList_CurrentCellDirtyStateChanged);
            this.grdRackList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.GrdRackList_DataBindingComplete);
            // 
            // btnNewRack
            // 
            this.btnNewRack.Image = global::ROMS.Properties.Resources.New;
            this.btnNewRack.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnNewRack.Location = new System.Drawing.Point(419, 59);
            this.btnNewRack.Name = "btnNewRack";
            this.btnNewRack.Size = new System.Drawing.Size(21, 22);
            this.btnNewRack.TabIndex = 1111150;
            this.btnNewRack.Text = "        ";
            this.btnNewRack.Click += new System.EventHandler(this.BtnNewRack_Click);
            // 
            // btnewlocation
            // 
            this.btnewlocation.Image = global::ROMS.Properties.Resources.New;
            this.btnewlocation.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnewlocation.Location = new System.Drawing.Point(419, 32);
            this.btnewlocation.Name = "btnewlocation";
            this.btnewlocation.Size = new System.Drawing.Size(21, 22);
            this.btnewlocation.TabIndex = 1111149;
            this.btnewlocation.Text = "        ";
            this.btnewlocation.Click += new System.EventHandler(this.Btnewlocation_Click);
            // 
            // lblRack
            // 
            this.lblRack.AutoSize = true;
            this.lblRack.Location = new System.Drawing.Point(11, 62);
            this.lblRack.Name = "lblRack";
            this.lblRack.Size = new System.Drawing.Size(0, 20);
            this.lblRack.TabIndex = 1111148;
            this.lblRack.Visible = false;
            // 
            // txtLocation
            // 
            this.txtLocation.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtLocation.Location = new System.Drawing.Point(217, 30);
            this.txtLocation.MaxLength = 100;
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(200, 27);
            this.txtLocation.TabIndex = 4;
            this.txtLocation.TextChanged += new System.EventHandler(this.TxtLocation_TextChanged);
            this.txtLocation.Enter += new System.EventHandler(this.TxtLocation_Enter);
            this.txtLocation.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtLocation_KeyDown);
            this.txtLocation.Leave += new System.EventHandler(this.TxtLocation_Leave);
            // 
            // txtSDtockLocation
            // 
            this.txtSDtockLocation.BackColor = System.Drawing.SystemColors.Control;
            this.txtSDtockLocation.Enabled = false;
            this.txtSDtockLocation.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSDtockLocation.Location = new System.Drawing.Point(17, 30);
            this.txtSDtockLocation.Name = "txtSDtockLocation";
            this.txtSDtockLocation.ReadOnly = true;
            this.txtSDtockLocation.Size = new System.Drawing.Size(200, 27);
            this.txtSDtockLocation.TabIndex = 1111136;
            this.txtSDtockLocation.Text = "Stock Location";
            // 
            // txtDRack
            // 
            this.txtDRack.BackColor = System.Drawing.SystemColors.Control;
            this.txtDRack.Enabled = false;
            this.txtDRack.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDRack.Location = new System.Drawing.Point(17, 57);
            this.txtDRack.Name = "txtDRack";
            this.txtDRack.ReadOnly = true;
            this.txtDRack.Size = new System.Drawing.Size(200, 27);
            this.txtDRack.TabIndex = 1111138;
            this.txtDRack.Text = "Rack";
            // 
            // epSubGroup
            // 
            this.epSubGroup.ContainerControl = this;
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new System.Drawing.Point(24, 168);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(0, 18);
            this.lblLocation.TabIndex = 1;
            this.lblLocation.Visible = false;
            // 
            // DGV_FilterLocation
            // 
            this.DGV_FilterLocation.AllowUserToAddRows = false;
            this.DGV_FilterLocation.AllowUserToDeleteRows = false;
            this.DGV_FilterLocation.AllowUserToResizeColumns = false;
            this.DGV_FilterLocation.AllowUserToResizeRows = false;
            this.DGV_FilterLocation.BackgroundColor = System.Drawing.Color.White;
            this.DGV_FilterLocation.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Chocolate;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Chocolate;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_FilterLocation.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DGV_FilterLocation.ColumnHeadersHeight = 30;
            this.DGV_FilterLocation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV_FilterLocation.DefaultCellStyle = dataGridViewCellStyle2;
            this.DGV_FilterLocation.EnableHeadersVisualStyles = false;
            this.DGV_FilterLocation.GridColor = System.Drawing.Color.White;
            this.DGV_FilterLocation.Location = new System.Drawing.Point(224, 185);
            this.DGV_FilterLocation.Name = "DGV_FilterLocation";
            this.DGV_FilterLocation.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_FilterLocation.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DGV_FilterLocation.RowHeadersVisible = false;
            this.DGV_FilterLocation.RowHeadersWidth = 51;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.DGV_FilterLocation.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.DGV_FilterLocation.RowTemplate.Height = 25;
            this.DGV_FilterLocation.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV_FilterLocation.Size = new System.Drawing.Size(200, 226);
            this.DGV_FilterLocation.TabIndex = 111111173;
            this.DGV_FilterLocation.Visible = false;
            this.DGV_FilterLocation.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_FilterLocation_CellDoubleClick);
            this.DGV_FilterLocation.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DGV_FilterLocation_KeyDown);
            // 
            // CP_SubGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(475, 457);
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.grbform);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CP_SubGroup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Product Sub Group";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CP_SubGroup_FormClosing);
            this.Load += new System.EventHandler(this.CP_SubGroup_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CP_SubGroup_KeyDown);
            this.Leave += new System.EventHandler(this.CP_SubGroup_Leave);
            this.grbform.ResumeLayout(false);
            this.grbform.PerformLayout();
            this.pnlStatus.ResumeLayout(false);
            this.pnlStatus.PerformLayout();
            this.grpPurchaseStockLocation.ResumeLayout(false);
            this.grpPurchaseStockLocation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdRackList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epSubGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_FilterLocation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox grbform;
        private System.Windows.Forms.TextBox txtDEProductSubGroupNameEnglish;
        private System.Windows.Forms.TextBox txtESubGroupNameEnglish;
        private System.Windows.Forms.ErrorProvider epSubGroup;
        private System.Windows.Forms.TextBox txtDStatus;
        private System.Windows.Forms.Panel pnlStatus;
        private System.Windows.Forms.RadioButton rbInactive;
        private System.Windows.Forms.RadioButton rbActive;
        internal System.Windows.Forms.Label btnAdd;
        private System.Windows.Forms.TextBox txtDGroupName;
        private System.Windows.Forms.TextBox txtEProductSubGroupNameTamil;
        private System.Windows.Forms.TextBox txtESubGroupNameTamil;
        private System.Windows.Forms.TextBox txtSDtockLocation;
        private System.Windows.Forms.TextBox txtDRack;
        private System.Windows.Forms.GroupBox grpPurchaseStockLocation;
        private System.Windows.Forms.ComboBox cmbBatchNo;
        private System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtProductGroupName;
        public System.Windows.Forms.ListView lvGroupName;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Label lblGroupCode;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Label lblRack;
        internal System.Windows.Forms.Label btnewlocation;
        internal System.Windows.Forms.Label btnNewRack;
        public System.Windows.Forms.DataGridView grdRackList;
        private System.Windows.Forms.TextBox txtRack;
        private System.Windows.Forms.ComboBox cmbSubgroupType;
        private System.Windows.Forms.TextBox textBox2;
        public System.Windows.Forms.DataGridView DGV_FilterLocation;
    }
}