namespace ROMS
{
    partial class INV_DamageEntry
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tspHeader = new System.Windows.Forms.ToolStripLabel();
            this.tsInwardList = new System.Windows.Forms.ToolStrip();
            this.pnlinward = new System.Windows.Forms.Panel();
            this.lvProductName = new System.Windows.Forms.ListView();
            this.txttotalitem = new System.Windows.Forms.TextBox();
            this.lbltotalproducts = new System.Windows.Forms.Label();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.lblnarration = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.grdDamageEntry = new System.Windows.Forms.DataGridView();
            this.clmdsno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmicode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmproductname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmmrp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmexpirydate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmunit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSupplier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmMonth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmYear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmremove = new System.Windows.Forms.DataGridViewImageColumn();
            this.grbgodown = new System.Windows.Forms.GroupBox();
            this.txtEntryNo = new System.Windows.Forms.TextBox();
            this.lbEntryNo = new System.Windows.Forms.Label();
            this.lblEntryDate = new System.Windows.Forms.Label();
            this.dpEntryDate = new System.Windows.Forms.DateTimePicker();
            this.cmbConcern = new System.Windows.Forms.ComboBox();
            this.lblConcern = new System.Windows.Forms.Label();
            this.grpproductname = new System.Windows.Forms.GroupBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBatchNo = new System.Windows.Forms.TextBox();
            this.lblbatchno = new System.Windows.Forms.Label();
            this.lblExpiryDate = new System.Windows.Forms.Label();
            this.txtsuppliername = new System.Windows.Forms.TextBox();
            this.lblSupplierName = new System.Windows.Forms.Label();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.lblQty = new System.Windows.Forms.Label();
            this.lblProductName = new System.Windows.Forms.Label();
            this.txtMrp = new System.Windows.Forms.TextBox();
            this.lblMrp = new System.Windows.Forms.Label();
            this.lblEdit = new System.Windows.Forms.Label();
            this.epDamageEntry = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtExpiryDate = new System.Windows.Forms.TextBox();
            this.txtStockQty = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tsInwardList.SuspendLayout();
            this.pnlinward.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDamageEntry)).BeginInit();
            this.grbgodown.SuspendLayout();
            this.grpproductname.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epDamageEntry)).BeginInit();
            this.SuspendLayout();
            // 
            // tspHeader
            // 
            this.tspHeader.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tspHeader.Image = global::ROMS.Properties.Resources.bread_crumb;
            this.tspHeader.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tspHeader.Margin = new System.Windows.Forms.Padding(15, 1, 0, 2);
            this.tspHeader.Name = "tspHeader";
            this.tspHeader.Size = new System.Drawing.Size(100, 22);
            this.tspHeader.Text = "Damage Entry";
            // 
            // tsInwardList
            // 
            this.tsInwardList.BackColor = System.Drawing.Color.White;
            this.tsInwardList.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsInwardList.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsInwardList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspHeader});
            this.tsInwardList.Location = new System.Drawing.Point(0, 0);
            this.tsInwardList.Name = "tsInwardList";
            this.tsInwardList.Size = new System.Drawing.Size(1354, 25);
            this.tsInwardList.TabIndex = 35;
            this.tsInwardList.Text = "Inward";
            // 
            // pnlinward
            // 
            this.pnlinward.BackColor = System.Drawing.Color.White;
            this.pnlinward.Controls.Add(this.lvProductName);
            this.pnlinward.Controls.Add(this.txttotalitem);
            this.pnlinward.Controls.Add(this.lbltotalproducts);
            this.pnlinward.Controls.Add(this.txtRemark);
            this.pnlinward.Controls.Add(this.lblnarration);
            this.pnlinward.Controls.Add(this.btnSave);
            this.pnlinward.Controls.Add(this.btnClose);
            this.pnlinward.Controls.Add(this.grdDamageEntry);
            this.pnlinward.Controls.Add(this.grbgodown);
            this.pnlinward.Controls.Add(this.grpproductname);
            this.pnlinward.Location = new System.Drawing.Point(0, 29);
            this.pnlinward.Name = "pnlinward";
            this.pnlinward.Size = new System.Drawing.Size(1354, 645);
            this.pnlinward.TabIndex = 36;
            // 
            // lvProductName
            // 
            this.lvProductName.HideSelection = false;
            this.lvProductName.Location = new System.Drawing.Point(9, 136);
            this.lvProductName.Name = "lvProductName";
            this.lvProductName.Size = new System.Drawing.Size(378, 69);
            this.lvProductName.TabIndex = 958808;
            this.lvProductName.UseCompatibleStateImageBehavior = false;
            this.lvProductName.Visible = false;
            // 
            // txttotalitem
            // 
            this.txttotalitem.Location = new System.Drawing.Point(1103, 594);
            this.txttotalitem.Name = "txttotalitem";
            this.txttotalitem.ReadOnly = true;
            this.txttotalitem.Size = new System.Drawing.Size(62, 27);
            this.txttotalitem.TabIndex = 13;
            // 
            // lbltotalproducts
            // 
            this.lbltotalproducts.AutoSize = true;
            this.lbltotalproducts.Location = new System.Drawing.Point(1013, 597);
            this.lbltotalproducts.Name = "lbltotalproducts";
            this.lbltotalproducts.Size = new System.Drawing.Size(87, 20);
            this.lbltotalproducts.TabIndex = 958821;
            this.lbltotalproducts.Text = "Total Products";
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(83, 593);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(320, 50);
            this.txtRemark.TabIndex = 12;
            this.txtRemark.Enter += new System.EventHandler(this.TxtRemark_Enter);
            this.txtRemark.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtRemark_KeyDown);
            this.txtRemark.Leave += new System.EventHandler(this.TxtRemark_Leave);
            // 
            // lblnarration
            // 
            this.lblnarration.AutoSize = true;
            this.lblnarration.Location = new System.Drawing.Point(18, 593);
            this.lblnarration.Name = "lblnarration";
            this.lblnarration.Size = new System.Drawing.Size(56, 20);
            this.lblnarration.TabIndex = 958812;
            this.lblnarration.Text = "Remarks";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnSave.Image = global::ROMS.Properties.Resources.save;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(1176, 592);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(84, 29);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            this.btnSave.Enter += new System.EventHandler(this.BtnSave_Enter);
            this.btnSave.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BtnSave_KeyDown);
            this.btnSave.Leave += new System.EventHandler(this.BtnSave_Leave);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnClose.Image = global::ROMS.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(1268, 592);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 29);
            this.btnClose.TabIndex = 14;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            this.btnClose.Enter += new System.EventHandler(this.BtnClose_Enter);
            this.btnClose.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BtnClose_KeyDown);
            this.btnClose.Leave += new System.EventHandler(this.BtnClose_Leave);
            // 
            // grdDamageEntry
            // 
            this.grdDamageEntry.AllowUserToAddRows = false;
            this.grdDamageEntry.AllowUserToDeleteRows = false;
            this.grdDamageEntry.AllowUserToResizeRows = false;
            this.grdDamageEntry.BackgroundColor = System.Drawing.Color.White;
            this.grdDamageEntry.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle25.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle25.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle25.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle25.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(242)))), ((int)(((byte)(213)))));
            dataGridViewCellStyle25.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle25.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdDamageEntry.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle25;
            this.grdDamageEntry.ColumnHeadersHeight = 30;
            this.grdDamageEntry.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdDamageEntry.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmdsno,
            this.clmicode,
            this.clmproductname,
            this.clmmrp,
            this.clmexpirydate,
            this.Column1,
            this.clmQuantity,
            this.clmunit,
            this.clmSupplier,
            this.clmDay,
            this.clmMonth,
            this.clmYear,
            this.clmremove});
            dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle26.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle26.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle26.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle26.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle26.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle26.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdDamageEntry.DefaultCellStyle = dataGridViewCellStyle26;
            this.grdDamageEntry.EnableHeadersVisualStyles = false;
            this.grdDamageEntry.GridColor = System.Drawing.Color.White;
            this.grdDamageEntry.Location = new System.Drawing.Point(3, 157);
            this.grdDamageEntry.Name = "grdDamageEntry";
            this.grdDamageEntry.RowHeadersVisible = false;
            dataGridViewCellStyle27.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle27.SelectionForeColor = System.Drawing.Color.Black;
            this.grdDamageEntry.RowsDefaultCellStyle = dataGridViewCellStyle27;
            this.grdDamageEntry.RowTemplate.Height = 25;
            this.grdDamageEntry.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.grdDamageEntry.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.grdDamageEntry.ShowRowErrors = false;
            this.grdDamageEntry.Size = new System.Drawing.Size(1340, 423);
            this.grdDamageEntry.TabIndex = 958809;
            this.grdDamageEntry.TabStop = false;
            this.grdDamageEntry.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrdDamageEntry_CellContentClick);
            // 
            // clmdsno
            // 
            this.clmdsno.HeaderText = "S.No.";
            this.clmdsno.Name = "clmdsno";
            this.clmdsno.Width = 50;
            // 
            // clmicode
            // 
            this.clmicode.HeaderText = "P.I Code";
            this.clmicode.Name = "clmicode";
            // 
            // clmproductname
            // 
            this.clmproductname.HeaderText = "Product Name";
            this.clmproductname.Name = "clmproductname";
            this.clmproductname.Width = 200;
            // 
            // clmmrp
            // 
            this.clmmrp.HeaderText = "MRP";
            this.clmmrp.Name = "clmmrp";
            // 
            // clmexpirydate
            // 
            this.clmexpirydate.HeaderText = "Expiry Date";
            this.clmexpirydate.Name = "clmexpirydate";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Batch No.";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // clmQuantity
            // 
            this.clmQuantity.HeaderText = "Quantity";
            this.clmQuantity.Name = "clmQuantity";
            // 
            // clmunit
            // 
            this.clmunit.HeaderText = "Unit";
            this.clmunit.Name = "clmunit";
            // 
            // clmSupplier
            // 
            this.clmSupplier.HeaderText = "Supplier";
            this.clmSupplier.Name = "clmSupplier";
            this.clmSupplier.ReadOnly = true;
            this.clmSupplier.Width = 200;
            // 
            // clmDay
            // 
            this.clmDay.HeaderText = "Day";
            this.clmDay.Name = "clmDay";
            this.clmDay.ReadOnly = true;
            this.clmDay.Width = 50;
            // 
            // clmMonth
            // 
            this.clmMonth.HeaderText = "Month";
            this.clmMonth.Name = "clmMonth";
            this.clmMonth.ReadOnly = true;
            this.clmMonth.Width = 50;
            // 
            // clmYear
            // 
            this.clmYear.HeaderText = "Year";
            this.clmYear.Name = "clmYear";
            this.clmYear.ReadOnly = true;
            this.clmYear.Width = 50;
            // 
            // clmremove
            // 
            this.clmremove.HeaderText = "Remove";
            this.clmremove.Image = global::ROMS.Properties.Resources.remove;
            this.clmremove.Name = "clmremove";
            this.clmremove.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmremove.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.clmremove.Width = 80;
            // 
            // grbgodown
            // 
            this.grbgodown.Controls.Add(this.txtEntryNo);
            this.grbgodown.Controls.Add(this.lbEntryNo);
            this.grbgodown.Controls.Add(this.lblEntryDate);
            this.grbgodown.Controls.Add(this.dpEntryDate);
            this.grbgodown.Controls.Add(this.cmbConcern);
            this.grbgodown.Controls.Add(this.lblConcern);
            this.grbgodown.Location = new System.Drawing.Point(3, 2);
            this.grbgodown.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbgodown.Name = "grbgodown";
            this.grbgodown.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbgodown.Size = new System.Drawing.Size(1338, 77);
            this.grbgodown.TabIndex = 958805;
            this.grbgodown.TabStop = false;
            // 
            // txtEntryNo
            // 
            this.txtEntryNo.Location = new System.Drawing.Point(344, 36);
            this.txtEntryNo.Name = "txtEntryNo";
            this.txtEntryNo.ReadOnly = true;
            this.txtEntryNo.Size = new System.Drawing.Size(171, 27);
            this.txtEntryNo.TabIndex = 2;
            // 
            // lbEntryNo
            // 
            this.lbEntryNo.AutoSize = true;
            this.lbEntryNo.Location = new System.Drawing.Point(347, 14);
            this.lbEntryNo.Name = "lbEntryNo";
            this.lbEntryNo.Size = new System.Drawing.Size(58, 20);
            this.lbEntryNo.TabIndex = 958818;
            this.lbEntryNo.Text = "Entry No.";
            // 
            // lblEntryDate
            // 
            this.lblEntryDate.AutoSize = true;
            this.lblEntryDate.Location = new System.Drawing.Point(215, 14);
            this.lblEntryDate.Name = "lblEntryDate";
            this.lblEntryDate.Size = new System.Drawing.Size(66, 20);
            this.lblEntryDate.TabIndex = 958817;
            this.lblEntryDate.Text = "Entry Date";
            // 
            // dpEntryDate
            // 
            this.dpEntryDate.CustomFormat = "dd/MM/yyyy";
            this.dpEntryDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpEntryDate.Location = new System.Drawing.Point(215, 36);
            this.dpEntryDate.Name = "dpEntryDate";
            this.dpEntryDate.Size = new System.Drawing.Size(107, 27);
            this.dpEntryDate.TabIndex = 1;
            this.dpEntryDate.Enter += new System.EventHandler(this.DpEntryDate_Enter);
            this.dpEntryDate.Leave += new System.EventHandler(this.DpEntryDate_Leave);
            // 
            // cmbConcern
            // 
            this.cmbConcern.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbConcern.FormattingEnabled = true;
            this.cmbConcern.Location = new System.Drawing.Point(13, 36);
            this.cmbConcern.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbConcern.Name = "cmbConcern";
            this.cmbConcern.Size = new System.Drawing.Size(183, 27);
            this.cmbConcern.TabIndex = 0;
            this.cmbConcern.SelectedIndexChanged += new System.EventHandler(this.CmbConcern_SelectedIndexChanged);
            this.cmbConcern.Enter += new System.EventHandler(this.CmbConcern_Enter);
            this.cmbConcern.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbConcern_KeyDown);
            this.cmbConcern.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbConcern_KeyPress);
            this.cmbConcern.Leave += new System.EventHandler(this.CmbConcern_Leave);
            // 
            // lblConcern
            // 
            this.lblConcern.AutoSize = true;
            this.lblConcern.Location = new System.Drawing.Point(13, 14);
            this.lblConcern.Name = "lblConcern";
            this.lblConcern.Size = new System.Drawing.Size(54, 20);
            this.lblConcern.TabIndex = 86;
            this.lblConcern.Text = "Concern";
            // 
            // grpproductname
            // 
            this.grpproductname.Controls.Add(this.textBox2);
            this.grpproductname.Controls.Add(this.label1);
            this.grpproductname.Controls.Add(this.textBox1);
            this.grpproductname.Controls.Add(this.txtExpiryDate);
            this.grpproductname.Controls.Add(this.btnAdd);
            this.grpproductname.Controls.Add(this.txtStockQty);
            this.grpproductname.Controls.Add(this.textBox5);
            this.grpproductname.Controls.Add(this.label3);
            this.grpproductname.Controls.Add(this.txtBatchNo);
            this.grpproductname.Controls.Add(this.lblbatchno);
            this.grpproductname.Controls.Add(this.lblExpiryDate);
            this.grpproductname.Controls.Add(this.txtsuppliername);
            this.grpproductname.Controls.Add(this.lblSupplierName);
            this.grpproductname.Controls.Add(this.txtProductName);
            this.grpproductname.Controls.Add(this.txtQuantity);
            this.grpproductname.Controls.Add(this.lblQty);
            this.grpproductname.Controls.Add(this.lblProductName);
            this.grpproductname.Controls.Add(this.txtMrp);
            this.grpproductname.Controls.Add(this.lblMrp);
            this.grpproductname.Location = new System.Drawing.Point(3, 72);
            this.grpproductname.Name = "grpproductname";
            this.grpproductname.Size = new System.Drawing.Size(1339, 77);
            this.grpproductname.TabIndex = 958806;
            this.grpproductname.TabStop = false;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.White;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAdd.Image = global::ROMS.Properties.Resources.plus;
            this.btnAdd.Location = new System.Drawing.Point(1313, 36);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(0);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(23, 27);
            this.btnAdd.TabIndex = 11;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            this.btnAdd.Enter += new System.EventHandler(this.BtnAdd_Enter);
            this.btnAdd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BtnAdd_KeyDown);
            this.btnAdd.Leave += new System.EventHandler(this.BtnAdd_Leave);
            // 
            // textBox5
            // 
            this.textBox5.Font = new System.Drawing.Font("Rupee Foradian", 12.75F);
            this.textBox5.Location = new System.Drawing.Point(623, 36);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(17, 27);
            this.textBox5.TabIndex = 1111237;
            this.textBox5.TabStop = false;
            this.textBox5.Text = "₹";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1044, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 20);
            this.label3.TabIndex = 1111186;
            this.label3.Text = "Pkts";
            // 
            // txtBatchNo
            // 
            this.txtBatchNo.Location = new System.Drawing.Point(774, 36);
            this.txtBatchNo.Name = "txtBatchNo";
            this.txtBatchNo.Size = new System.Drawing.Size(124, 27);
            this.txtBatchNo.TabIndex = 8;
            this.txtBatchNo.Enter += new System.EventHandler(this.TxtBatchNo_Enter);
            this.txtBatchNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtBatchNo_KeyDown);
            this.txtBatchNo.Leave += new System.EventHandler(this.TxtBatchNo_Leave);
            // 
            // lblbatchno
            // 
            this.lblbatchno.AutoSize = true;
            this.lblbatchno.Location = new System.Drawing.Point(774, 14);
            this.lblbatchno.Name = "lblbatchno";
            this.lblbatchno.Size = new System.Drawing.Size(61, 20);
            this.lblbatchno.TabIndex = 958816;
            this.lblbatchno.Text = "Batch No.";
            // 
            // lblExpiryDate
            // 
            this.lblExpiryDate.AutoSize = true;
            this.lblExpiryDate.Location = new System.Drawing.Point(698, 14);
            this.lblExpiryDate.Name = "lblExpiryDate";
            this.lblExpiryDate.Size = new System.Drawing.Size(70, 20);
            this.lblExpiryDate.TabIndex = 958821;
            this.lblExpiryDate.Text = "Expiry Date";
            // 
            // txtsuppliername
            // 
            this.txtsuppliername.Location = new System.Drawing.Point(1083, 36);
            this.txtsuppliername.Name = "txtsuppliername";
            this.txtsuppliername.Size = new System.Drawing.Size(216, 27);
            this.txtsuppliername.TabIndex = 10;
            this.txtsuppliername.Enter += new System.EventHandler(this.Txtsuppliername_Enter);
            this.txtsuppliername.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Txtsuppliername_KeyDown);
            this.txtsuppliername.Leave += new System.EventHandler(this.Txtsuppliername_Leave);
            // 
            // lblSupplierName
            // 
            this.lblSupplierName.AutoSize = true;
            this.lblSupplierName.Location = new System.Drawing.Point(1083, 14);
            this.lblSupplierName.Name = "lblSupplierName";
            this.lblSupplierName.Size = new System.Drawing.Size(87, 20);
            this.lblSupplierName.TabIndex = 27;
            this.lblSupplierName.Text = "Supplier Name";
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(6, 37);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(309, 27);
            this.txtProductName.TabIndex = 3;
            this.txtProductName.Enter += new System.EventHandler(this.TxtProductName_Enter);
            this.txtProductName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtProductName_KeyDown);
            this.txtProductName.Leave += new System.EventHandler(this.TxtProductName_Leave);
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(974, 37);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(64, 27);
            this.txtQuantity.TabIndex = 9;
            this.txtQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtQuantity.Enter += new System.EventHandler(this.TxtQuantity_Enter);
            this.txtQuantity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtQuantity_KeyDown);
            this.txtQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtQuantity_KeyPress);
            this.txtQuantity.Leave += new System.EventHandler(this.TxtQuantity_Leave);
            // 
            // lblQty
            // 
            this.lblQty.AutoSize = true;
            this.lblQty.Location = new System.Drawing.Point(999, 14);
            this.lblQty.Name = "lblQty";
            this.lblQty.Size = new System.Drawing.Size(56, 20);
            this.lblQty.TabIndex = 80;
            this.lblQty.Text = "Quantity";
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Location = new System.Drawing.Point(6, 14);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(134, 20);
            this.lblProductName.TabIndex = 28;
            this.lblProductName.Text = "Product Name/P.I Code";
            // 
            // txtMrp
            // 
            this.txtMrp.Location = new System.Drawing.Point(640, 36);
            this.txtMrp.Name = "txtMrp";
            this.txtMrp.Size = new System.Drawing.Size(52, 27);
            this.txtMrp.TabIndex = 4;
            this.txtMrp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMrp.Enter += new System.EventHandler(this.TxtMrp_Enter);
            this.txtMrp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtMrp_KeyDown);
            this.txtMrp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtMrp_KeyPress);
            this.txtMrp.Leave += new System.EventHandler(this.TxtMrp_Leave);
            // 
            // lblMrp
            // 
            this.lblMrp.AutoSize = true;
            this.lblMrp.Location = new System.Drawing.Point(640, 14);
            this.lblMrp.Name = "lblMrp";
            this.lblMrp.Size = new System.Drawing.Size(34, 20);
            this.lblMrp.TabIndex = 77;
            this.lblMrp.Text = "MRP";
            // 
            // lblEdit
            // 
            this.lblEdit.AutoSize = true;
            this.lblEdit.Location = new System.Drawing.Point(711, 19);
            this.lblEdit.Name = "lblEdit";
            this.lblEdit.Size = new System.Drawing.Size(0, 20);
            this.lblEdit.TabIndex = 37;
            this.lblEdit.Visible = false;
            // 
            // epDamageEntry
            // 
            this.epDamageEntry.ContainerControl = this;
            // 
            // txtExpiryDate
            // 
            this.txtExpiryDate.Enabled = false;
            this.txtExpiryDate.Location = new System.Drawing.Point(698, 37);
            this.txtExpiryDate.Name = "txtExpiryDate";
            this.txtExpiryDate.ReadOnly = true;
            this.txtExpiryDate.Size = new System.Drawing.Size(70, 27);
            this.txtExpiryDate.TabIndex = 958819;
            // 
            // txtStockQty
            // 
            this.txtStockQty.Enabled = false;
            this.txtStockQty.Location = new System.Drawing.Point(904, 36);
            this.txtStockQty.Name = "txtStockQty";
            this.txtStockQty.ReadOnly = true;
            this.txtStockQty.Size = new System.Drawing.Size(64, 27);
            this.txtStockQty.TabIndex = 1111238;
            this.txtStockQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(321, 37);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(145, 27);
            this.textBox1.TabIndex = 1111239;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(472, 36);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(145, 27);
            this.textBox2.TabIndex = 1111240;
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(904, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 20);
            this.label1.TabIndex = 1111239;
            this.label1.Text = "Stock Quantity";
            // 
            // INV_DamageEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(1354, 675);
            this.Controls.Add(this.lblEdit);
            this.Controls.Add(this.tsInwardList);
            this.Controls.Add(this.pnlinward);
            this.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "INV_DamageEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Damage Entry";
            this.Load += new System.EventHandler(this.INV_DamageEntry_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.INV_DamageEntry_KeyDown);
            this.tsInwardList.ResumeLayout(false);
            this.tsInwardList.PerformLayout();
            this.pnlinward.ResumeLayout(false);
            this.pnlinward.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDamageEntry)).EndInit();
            this.grbgodown.ResumeLayout(false);
            this.grbgodown.PerformLayout();
            this.grpproductname.ResumeLayout(false);
            this.grpproductname.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epDamageEntry)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStripLabel tspHeader;
        private System.Windows.Forms.ToolStrip tsInwardList;
        private System.Windows.Forms.Panel pnlinward;
        private System.Windows.Forms.TextBox txtsuppliername;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label lblnarration;
        private System.Windows.Forms.ListView lvProductName;
        public System.Windows.Forms.DataGridView grdDamageEntry;
        private System.Windows.Forms.GroupBox grpproductname;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Label lblQty;
        private System.Windows.Forms.Label lblMrp;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.GroupBox grbgodown;
        private System.Windows.Forms.Label lblSupplierName;
        private System.Windows.Forms.TextBox txtMrp;
        private System.Windows.Forms.TextBox txttotalitem;
        private System.Windows.Forms.Label lbltotalproducts;
        private System.Windows.Forms.Label lblEdit;
        public System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblExpiryDate;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtBatchNo;
        private System.Windows.Forms.Label lblbatchno;
        private System.Windows.Forms.ComboBox cmbConcern;
        private System.Windows.Forms.Label lblConcern;
        private System.Windows.Forms.TextBox txtEntryNo;
        private System.Windows.Forms.Label lbEntryNo;
        private System.Windows.Forms.Label lblEntryDate;
        private System.Windows.Forms.DateTimePicker dpEntryDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ErrorProvider epDamageEntry;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmdsno;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmicode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmproductname;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmmrp;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmexpirydate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmunit;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSupplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDay;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmMonth;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmYear;
        private System.Windows.Forms.DataGridViewImageColumn clmremove;
        private System.Windows.Forms.TextBox txtExpiryDate;
        private System.Windows.Forms.TextBox txtStockQty;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
    }
}