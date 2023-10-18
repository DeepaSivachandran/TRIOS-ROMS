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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.DGV_inward = new System.Windows.Forms.DataGridView();
            this.clmdsno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmicode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmproductname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmmrp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmexpirydate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmunit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSupplier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmremove = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grbgodown = new System.Windows.Forms.GroupBox();
            this.txtEntryNo = new System.Windows.Forms.TextBox();
            this.lbEntryNo = new System.Windows.Forms.Label();
            this.lblEntryDate = new System.Windows.Forms.Label();
            this.dpEntryDate = new System.Windows.Forms.DateTimePicker();
            this.cmbConcern = new System.Windows.Forms.ComboBox();
            this.lblConcern = new System.Windows.Forms.Label();
            this.grpproductname = new System.Windows.Forms.GroupBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.txtDay = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblYyyy = new System.Windows.Forms.Label();
            this.lblMM = new System.Windows.Forms.Label();
            this.lblDd = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtunitrate = new System.Windows.Forms.TextBox();
            this.lblbatchno = new System.Windows.Forms.Label();
            this.lblExpiryDate = new System.Windows.Forms.Label();
            this.txtsuppliername = new System.Windows.Forms.TextBox();
            this.lblSupplierName = new System.Windows.Forms.Label();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.txtActualQty = new System.Windows.Forms.TextBox();
            this.lblQty = new System.Windows.Forms.Label();
            this.lblProductName = new System.Windows.Forms.Label();
            this.txtMrp = new System.Windows.Forms.TextBox();
            this.lblMrp = new System.Windows.Forms.Label();
            this.lblEdit = new System.Windows.Forms.Label();
            this.epDamageEntry = new System.Windows.Forms.ErrorProvider(this.components);
            this.tsInwardList.SuspendLayout();
            this.pnlinward.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_inward)).BeginInit();
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
            this.pnlinward.Controls.Add(this.DGV_inward);
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
            this.lvProductName.Location = new System.Drawing.Point(16, 136);
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
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnClose.Image = global::ROMS.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(1268, 592);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 29);
            this.btnClose.TabIndex = 15;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // DGV_inward
            // 
            this.DGV_inward.AllowUserToAddRows = false;
            this.DGV_inward.AllowUserToDeleteRows = false;
            this.DGV_inward.AllowUserToResizeRows = false;
            this.DGV_inward.BackgroundColor = System.Drawing.Color.White;
            this.DGV_inward.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(242)))), ((int)(((byte)(213)))));
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_inward.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.DGV_inward.ColumnHeadersHeight = 30;
            this.DGV_inward.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGV_inward.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmdsno,
            this.clmicode,
            this.clmproductname,
            this.clmmrp,
            this.clmexpirydate,
            this.Column1,
            this.clmQuantity,
            this.clmunit,
            this.clmSupplier,
            this.clmremove});
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV_inward.DefaultCellStyle = dataGridViewCellStyle11;
            this.DGV_inward.EnableHeadersVisualStyles = false;
            this.DGV_inward.GridColor = System.Drawing.Color.White;
            this.DGV_inward.Location = new System.Drawing.Point(3, 157);
            this.DGV_inward.Name = "DGV_inward";
            this.DGV_inward.RowHeadersVisible = false;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.Black;
            this.DGV_inward.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.DGV_inward.RowTemplate.Height = 25;
            this.DGV_inward.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DGV_inward.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DGV_inward.ShowRowErrors = false;
            this.DGV_inward.Size = new System.Drawing.Size(1340, 423);
            this.DGV_inward.TabIndex = 958809;
            // 
            // clmdsno
            // 
            this.clmdsno.HeaderText = "S.No.";
            this.clmdsno.Name = "clmdsno";
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
            // clmremove
            // 
            this.clmremove.HeaderText = "Remove";
            this.clmremove.Name = "clmremove";
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
            this.grpproductname.Controls.Add(this.btnAdd);
            this.grpproductname.Controls.Add(this.textBox2);
            this.grpproductname.Controls.Add(this.txtDay);
            this.grpproductname.Controls.Add(this.textBox1);
            this.grpproductname.Controls.Add(this.lblYyyy);
            this.grpproductname.Controls.Add(this.lblMM);
            this.grpproductname.Controls.Add(this.lblDd);
            this.grpproductname.Controls.Add(this.textBox5);
            this.grpproductname.Controls.Add(this.label3);
            this.grpproductname.Controls.Add(this.txtunitrate);
            this.grpproductname.Controls.Add(this.lblbatchno);
            this.grpproductname.Controls.Add(this.lblExpiryDate);
            this.grpproductname.Controls.Add(this.txtsuppliername);
            this.grpproductname.Controls.Add(this.lblSupplierName);
            this.grpproductname.Controls.Add(this.txtProductName);
            this.grpproductname.Controls.Add(this.txtActualQty);
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
            this.btnAdd.Location = new System.Drawing.Point(1158, 36);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(0);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(23, 27);
            this.btnAdd.TabIndex = 11;
            this.btnAdd.UseVisualStyleBackColor = false;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(551, 36);
            this.textBox2.MaxLength = 2;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(34, 27);
            this.textBox2.TabIndex = 7;
            // 
            // txtDay
            // 
            this.txtDay.Location = new System.Drawing.Point(484, 36);
            this.txtDay.MaxLength = 2;
            this.txtDay.Name = "txtDay";
            this.txtDay.Size = new System.Drawing.Size(33, 27);
            this.txtDay.TabIndex = 5;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(517, 36);
            this.textBox1.MaxLength = 2;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(34, 27);
            this.textBox1.TabIndex = 6;
            // 
            // lblYyyy
            // 
            this.lblYyyy.AutoSize = true;
            this.lblYyyy.Font = new System.Drawing.Font("Oswald Regular", 8.75F);
            this.lblYyyy.Location = new System.Drawing.Point(557, 21);
            this.lblYyyy.Name = "lblYyyy";
            this.lblYyyy.Size = new System.Drawing.Size(20, 16);
            this.lblYyyy.TabIndex = 1111243;
            this.lblYyyy.Text = "YY";
            // 
            // lblMM
            // 
            this.lblMM.AutoSize = true;
            this.lblMM.Font = new System.Drawing.Font("Oswald Regular", 8.75F);
            this.lblMM.Location = new System.Drawing.Point(523, 21);
            this.lblMM.Name = "lblMM";
            this.lblMM.Size = new System.Drawing.Size(24, 16);
            this.lblMM.TabIndex = 1111242;
            this.lblMM.Text = "MM";
            // 
            // lblDd
            // 
            this.lblDd.AutoSize = true;
            this.lblDd.Font = new System.Drawing.Font("Oswald Regular", 8.75F);
            this.lblDd.Location = new System.Drawing.Point(490, 21);
            this.lblDd.Name = "lblDd";
            this.lblDd.Size = new System.Drawing.Size(20, 16);
            this.lblDd.TabIndex = 1111241;
            this.lblDd.Text = "DD";
            // 
            // textBox5
            // 
            this.textBox5.Font = new System.Drawing.Font("Rupee Foradian", 12.75F);
            this.textBox5.Location = new System.Drawing.Point(334, 36);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(17, 27);
            this.textBox5.TabIndex = 1111237;
            this.textBox5.Text = "₹";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(801, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 20);
            this.label3.TabIndex = 1111186;
            this.label3.Text = "Pkts";
            // 
            // txtunitrate
            // 
            this.txtunitrate.Location = new System.Drawing.Point(592, 36);
            this.txtunitrate.Name = "txtunitrate";
            this.txtunitrate.Size = new System.Drawing.Size(124, 27);
            this.txtunitrate.TabIndex = 8;
            // 
            // lblbatchno
            // 
            this.lblbatchno.AutoSize = true;
            this.lblbatchno.Location = new System.Drawing.Point(592, 14);
            this.lblbatchno.Name = "lblbatchno";
            this.lblbatchno.Size = new System.Drawing.Size(61, 20);
            this.lblbatchno.TabIndex = 958816;
            this.lblbatchno.Text = "Batch No.";
            // 
            // lblExpiryDate
            // 
            this.lblExpiryDate.AutoSize = true;
            this.lblExpiryDate.Location = new System.Drawing.Point(409, 39);
            this.lblExpiryDate.Name = "lblExpiryDate";
            this.lblExpiryDate.Size = new System.Drawing.Size(70, 20);
            this.lblExpiryDate.TabIndex = 958821;
            this.lblExpiryDate.Text = "Expiry Date";
            // 
            // txtsuppliername
            // 
            this.txtsuppliername.Location = new System.Drawing.Point(836, 36);
            this.txtsuppliername.Name = "txtsuppliername";
            this.txtsuppliername.Size = new System.Drawing.Size(317, 27);
            this.txtsuppliername.TabIndex = 10;
            // 
            // lblSupplierName
            // 
            this.lblSupplierName.AutoSize = true;
            this.lblSupplierName.Location = new System.Drawing.Point(836, 14);
            this.lblSupplierName.Name = "lblSupplierName";
            this.lblSupplierName.Size = new System.Drawing.Size(87, 20);
            this.lblSupplierName.TabIndex = 27;
            this.lblSupplierName.Text = "Supplier Name";
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(13, 37);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(309, 27);
            this.txtProductName.TabIndex = 3;
            this.txtProductName.Enter += new System.EventHandler(this.TxtProductName_Enter);
            this.txtProductName.Leave += new System.EventHandler(this.TxtProductName_Leave);
            // 
            // txtActualQty
            // 
            this.txtActualQty.Location = new System.Drawing.Point(721, 37);
            this.txtActualQty.Name = "txtActualQty";
            this.txtActualQty.Size = new System.Drawing.Size(76, 27);
            this.txtActualQty.TabIndex = 9;
            // 
            // lblQty
            // 
            this.lblQty.AutoSize = true;
            this.lblQty.Location = new System.Drawing.Point(721, 14);
            this.lblQty.Name = "lblQty";
            this.lblQty.Size = new System.Drawing.Size(56, 20);
            this.lblQty.TabIndex = 80;
            this.lblQty.Text = "Quantity";
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Location = new System.Drawing.Point(13, 14);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(134, 20);
            this.lblProductName.TabIndex = 28;
            this.lblProductName.Text = "Product Name/P.I Code";
            // 
            // txtMrp
            // 
            this.txtMrp.Location = new System.Drawing.Point(351, 36);
            this.txtMrp.Name = "txtMrp";
            this.txtMrp.Size = new System.Drawing.Size(52, 27);
            this.txtMrp.TabIndex = 4;
            this.txtMrp.Enter += new System.EventHandler(this.TxtMrp_Enter);
            this.txtMrp.Leave += new System.EventHandler(this.TxtMrp_Leave);
            // 
            // lblMrp
            // 
            this.lblMrp.AutoSize = true;
            this.lblMrp.Location = new System.Drawing.Point(351, 13);
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
            this.Text = "Brand";
            this.Load += new System.EventHandler(this.INV_Inward_Load);
            this.tsInwardList.ResumeLayout(false);
            this.tsInwardList.PerformLayout();
            this.pnlinward.ResumeLayout(false);
            this.pnlinward.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_inward)).EndInit();
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
        public System.Windows.Forms.DataGridView DGV_inward;
        private System.Windows.Forms.GroupBox grpproductname;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.TextBox txtActualQty;
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
        private System.Windows.Forms.TextBox txtunitrate;
        private System.Windows.Forms.Label lblbatchno;
        private System.Windows.Forms.ComboBox cmbConcern;
        private System.Windows.Forms.Label lblConcern;
        private System.Windows.Forms.TextBox txtEntryNo;
        private System.Windows.Forms.Label lbEntryNo;
        private System.Windows.Forms.Label lblEntryDate;
        private System.Windows.Forms.DateTimePicker dpEntryDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox txtDay;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblYyyy;
        private System.Windows.Forms.Label lblMM;
        private System.Windows.Forms.Label lblDd;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmdsno;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmicode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmproductname;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmmrp;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmexpirydate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmunit;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSupplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmremove;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ErrorProvider epDamageEntry;
    }
}