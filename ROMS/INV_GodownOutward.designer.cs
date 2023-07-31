namespace ROMS
{
    partial class INV_GodownOutward
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(INV_GodownOutward));
            this.errGroup = new System.Windows.Forms.ErrorProvider(this.components);
            this.tsStockTransferList = new System.Windows.Forms.ToolStrip();
            this.tspHeader = new System.Windows.Forms.ToolStripLabel();
            this.pnlGoodsOutward = new System.Windows.Forms.Panel();
            this.grpGoodsOutward = new System.Windows.Forms.GroupBox();
            this.txttotalitem = new System.Windows.Forms.TextBox();
            this.lbltotalproducts = new System.Windows.Forms.Label();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.lblRemark = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.DGV_inward = new System.Windows.Forms.DataGridView();
            this.clmdsno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmicode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmproductname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmbatch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmexpirydate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmunit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.grbgodownoutward = new System.Windows.Forms.GroupBox();
            this.cmbTransactionType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtOutwardNo = new System.Windows.Forms.TextBox();
            this.cmbGodown = new System.Windows.Forms.ComboBox();
            this.dtpoutwarddate = new System.Windows.Forms.DateTimePicker();
            this.lblGodown = new System.Windows.Forms.Label();
            this.lbloutwarddate = new System.Windows.Forms.Label();
            this.cmbConcern = new System.Windows.Forms.ComboBox();
            this.lblConcern = new System.Windows.Forms.Label();
            this.lbloutwardno = new System.Windows.Forms.Label();
            this.grpproductname = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.lblStock = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Label();
            this.lblBatchNo = new System.Windows.Forms.Label();
            this.lblMRP = new System.Windows.Forms.Label();
            this.txtProduct = new System.Windows.Forms.TextBox();
            this.lblProductName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errGroup)).BeginInit();
            this.tsStockTransferList.SuspendLayout();
            this.pnlGoodsOutward.SuspendLayout();
            this.grpGoodsOutward.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_inward)).BeginInit();
            this.grbgodownoutward.SuspendLayout();
            this.grpproductname.SuspendLayout();
            this.SuspendLayout();
            // 
            // errGroup
            // 
            this.errGroup.ContainerControl = this;
            // 
            // tsStockTransferList
            // 
            this.tsStockTransferList.BackColor = System.Drawing.Color.White;
            this.tsStockTransferList.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsStockTransferList.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsStockTransferList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspHeader});
            this.tsStockTransferList.Location = new System.Drawing.Point(0, 0);
            this.tsStockTransferList.Name = "tsStockTransferList";
            this.tsStockTransferList.Size = new System.Drawing.Size(1354, 25);
            this.tsStockTransferList.TabIndex = 958817;
            this.tsStockTransferList.Text = "Goods Outward";
            // 
            // tspHeader
            // 
            this.tspHeader.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tspHeader.Image = global::ROMS.Properties.Resources.bread_crumb;
            this.tspHeader.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tspHeader.Margin = new System.Windows.Forms.Padding(15, 1, 0, 2);
            this.tspHeader.Name = "tspHeader";
            this.tspHeader.Size = new System.Drawing.Size(108, 22);
            this.tspHeader.Text = "Goods Outward";
            // 
            // pnlGoodsOutward
            // 
            this.pnlGoodsOutward.BackColor = System.Drawing.Color.White;
            this.pnlGoodsOutward.Controls.Add(this.grpGoodsOutward);
            this.pnlGoodsOutward.Location = new System.Drawing.Point(0, 29);
            this.pnlGoodsOutward.Name = "pnlGoodsOutward";
            this.pnlGoodsOutward.Size = new System.Drawing.Size(1354, 643);
            this.pnlGoodsOutward.TabIndex = 958819;
            // 
            // grpGoodsOutward
            // 
            this.grpGoodsOutward.BackColor = System.Drawing.Color.White;
            this.grpGoodsOutward.Controls.Add(this.txttotalitem);
            this.grpGoodsOutward.Controls.Add(this.lbltotalproducts);
            this.grpGoodsOutward.Controls.Add(this.txtRemark);
            this.grpGoodsOutward.Controls.Add(this.lblRemark);
            this.grpGoodsOutward.Controls.Add(this.btnSave);
            this.grpGoodsOutward.Controls.Add(this.btnClose);
            this.grpGoodsOutward.Controls.Add(this.DGV_inward);
            this.grpGoodsOutward.Controls.Add(this.grbgodownoutward);
            this.grpGoodsOutward.Controls.Add(this.grpproductname);
            this.grpGoodsOutward.Location = new System.Drawing.Point(11, 3);
            this.grpGoodsOutward.Name = "grpGoodsOutward";
            this.grpGoodsOutward.Size = new System.Drawing.Size(1331, 638);
            this.grpGoodsOutward.TabIndex = 958819;
            this.grpGoodsOutward.TabStop = false;
            // 
            // txttotalitem
            // 
            this.txttotalitem.Location = new System.Drawing.Point(1084, 601);
            this.txttotalitem.Name = "txttotalitem";
            this.txttotalitem.ReadOnly = true;
            this.txttotalitem.Size = new System.Drawing.Size(62, 27);
            this.txttotalitem.TabIndex = 958826;
            // 
            // lbltotalproducts
            // 
            this.lbltotalproducts.AutoSize = true;
            this.lbltotalproducts.Location = new System.Drawing.Point(994, 604);
            this.lbltotalproducts.Name = "lbltotalproducts";
            this.lbltotalproducts.Size = new System.Drawing.Size(87, 20);
            this.lbltotalproducts.TabIndex = 958825;
            this.lbltotalproducts.Text = "Total Products";
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(64, 580);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(479, 50);
            this.txtRemark.TabIndex = 958821;
            // 
            // lblRemark
            // 
            this.lblRemark.AutoSize = true;
            this.lblRemark.Location = new System.Drawing.Point(10, 582);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.Size = new System.Drawing.Size(56, 20);
            this.lblRemark.TabIndex = 958824;
            this.lblRemark.Text = "Remarks";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnSave.Image = global::ROMS.Properties.Resources.save;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(1155, 600);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(85, 29);
            this.btnSave.TabIndex = 958822;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnClose.Image = global::ROMS.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(1247, 600);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(78, 29);
            this.btnClose.TabIndex = 958823;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click_1);
            // 
            // DGV_inward
            // 
            this.DGV_inward.AllowUserToAddRows = false;
            this.DGV_inward.AllowUserToDeleteRows = false;
            this.DGV_inward.AllowUserToResizeRows = false;
            this.DGV_inward.BackgroundColor = System.Drawing.Color.White;
            this.DGV_inward.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(242)))), ((int)(((byte)(213)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_inward.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DGV_inward.ColumnHeadersHeight = 30;
            this.DGV_inward.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGV_inward.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmdsno,
            this.clmicode,
            this.clmproductname,
            this.Column3,
            this.Column1,
            this.Column2,
            this.clmbatch,
            this.clmexpirydate,
            this.clmunit,
            this.Column4});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV_inward.DefaultCellStyle = dataGridViewCellStyle2;
            this.DGV_inward.EnableHeadersVisualStyles = false;
            this.DGV_inward.GridColor = System.Drawing.Color.White;
            this.DGV_inward.Location = new System.Drawing.Point(11, 163);
            this.DGV_inward.Name = "DGV_inward";
            this.DGV_inward.RowHeadersVisible = false;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.DGV_inward.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.DGV_inward.RowTemplate.Height = 25;
            this.DGV_inward.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DGV_inward.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DGV_inward.ShowRowErrors = false;
            this.DGV_inward.Size = new System.Drawing.Size(1314, 404);
            this.DGV_inward.TabIndex = 958813;
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
            this.clmproductname.Width = 300;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "MRP";
            this.Column3.Name = "Column3";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Expiry Date";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Batch No.";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // clmbatch
            // 
            this.clmbatch.HeaderText = "Requested Qty";
            this.clmbatch.Name = "clmbatch";
            // 
            // clmexpirydate
            // 
            this.clmexpirydate.HeaderText = "Outward Qty";
            this.clmexpirydate.Name = "clmexpirydate";
            // 
            // clmunit
            // 
            this.clmunit.HeaderText = "Unit";
            this.clmunit.Name = "clmunit";
            this.clmunit.Width = 70;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Remove";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // grbgodownoutward
            // 
            this.grbgodownoutward.Controls.Add(this.cmbTransactionType);
            this.grbgodownoutward.Controls.Add(this.label1);
            this.grbgodownoutward.Controls.Add(this.txtOutwardNo);
            this.grbgodownoutward.Controls.Add(this.cmbGodown);
            this.grbgodownoutward.Controls.Add(this.dtpoutwarddate);
            this.grbgodownoutward.Controls.Add(this.lblGodown);
            this.grbgodownoutward.Controls.Add(this.lbloutwarddate);
            this.grbgodownoutward.Controls.Add(this.cmbConcern);
            this.grbgodownoutward.Controls.Add(this.lblConcern);
            this.grbgodownoutward.Controls.Add(this.lbloutwardno);
            this.grbgodownoutward.Location = new System.Drawing.Point(11, 11);
            this.grbgodownoutward.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbgodownoutward.Name = "grbgodownoutward";
            this.grbgodownoutward.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbgodownoutward.Size = new System.Drawing.Size(1314, 70);
            this.grbgodownoutward.TabIndex = 958811;
            this.grbgodownoutward.TabStop = false;
            // 
            // cmbTransactionType
            // 
            this.cmbTransactionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTransactionType.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTransactionType.FormattingEnabled = true;
            this.cmbTransactionType.Items.AddRange(new object[] {
            "Regular",
            "Stock Request"});
            this.cmbTransactionType.Location = new System.Drawing.Point(585, 36);
            this.cmbTransactionType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbTransactionType.Name = "cmbTransactionType";
            this.cmbTransactionType.Size = new System.Drawing.Size(135, 27);
            this.cmbTransactionType.TabIndex = 91;
            this.cmbTransactionType.SelectedIndexChanged += new System.EventHandler(this.ComboBox2_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(585, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.TabIndex = 90;
            this.label1.Text = "Transaction Type";
            // 
            // txtOutwardNo
            // 
            this.txtOutwardNo.Enabled = false;
            this.txtOutwardNo.Location = new System.Drawing.Point(238, 36);
            this.txtOutwardNo.Name = "txtOutwardNo";
            this.txtOutwardNo.ReadOnly = true;
            this.txtOutwardNo.Size = new System.Drawing.Size(150, 27);
            this.txtOutwardNo.TabIndex = 89;
            // 
            // cmbGodown
            // 
            this.cmbGodown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGodown.Enabled = false;
            this.cmbGodown.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbGodown.FormattingEnabled = true;
            this.cmbGodown.Location = new System.Drawing.Point(415, 36);
            this.cmbGodown.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbGodown.Name = "cmbGodown";
            this.cmbGodown.Size = new System.Drawing.Size(135, 27);
            this.cmbGodown.TabIndex = 88;
            // 
            // dtpoutwarddate
            // 
            this.dtpoutwarddate.CustomFormat = "dd/MM/yyyy";
            this.dtpoutwarddate.Enabled = false;
            this.dtpoutwarddate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpoutwarddate.Location = new System.Drawing.Point(119, 36);
            this.dtpoutwarddate.Name = "dtpoutwarddate";
            this.dtpoutwarddate.Size = new System.Drawing.Size(107, 27);
            this.dtpoutwarddate.TabIndex = 87;
            // 
            // lblGodown
            // 
            this.lblGodown.AutoSize = true;
            this.lblGodown.Location = new System.Drawing.Point(415, 12);
            this.lblGodown.Name = "lblGodown";
            this.lblGodown.Size = new System.Drawing.Size(87, 20);
            this.lblGodown.TabIndex = 86;
            this.lblGodown.Text = "Stock Location";
            // 
            // lbloutwarddate
            // 
            this.lbloutwarddate.AutoSize = true;
            this.lbloutwarddate.Location = new System.Drawing.Point(119, 14);
            this.lbloutwarddate.Name = "lbloutwarddate";
            this.lbloutwarddate.Size = new System.Drawing.Size(84, 20);
            this.lbloutwarddate.TabIndex = 84;
            this.lbloutwarddate.Text = "Outward Date";
            // 
            // cmbConcern
            // 
            this.cmbConcern.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbConcern.Enabled = false;
            this.cmbConcern.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbConcern.FormattingEnabled = true;
            this.cmbConcern.Location = new System.Drawing.Point(13, 36);
            this.cmbConcern.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbConcern.Name = "cmbConcern";
            this.cmbConcern.Size = new System.Drawing.Size(94, 27);
            this.cmbConcern.TabIndex = 73;
            // 
            // lblConcern
            // 
            this.lblConcern.AutoSize = true;
            this.lblConcern.Location = new System.Drawing.Point(13, 14);
            this.lblConcern.Name = "lblConcern";
            this.lblConcern.Size = new System.Drawing.Size(54, 20);
            this.lblConcern.TabIndex = 70;
            this.lblConcern.Text = "Concern";
            // 
            // lbloutwardno
            // 
            this.lbloutwardno.AutoSize = true;
            this.lbloutwardno.Location = new System.Drawing.Point(238, 14);
            this.lbloutwardno.Name = "lbloutwardno";
            this.lbloutwardno.Size = new System.Drawing.Size(76, 20);
            this.lbloutwardno.TabIndex = 68;
            this.lbloutwardno.Text = "Outward No.";
            // 
            // grpproductname
            // 
            this.grpproductname.Controls.Add(this.label4);
            this.grpproductname.Controls.Add(this.label3);
            this.grpproductname.Controls.Add(this.textBox4);
            this.grpproductname.Controls.Add(this.textBox3);
            this.grpproductname.Controls.Add(this.label2);
            this.grpproductname.Controls.Add(this.textBox1);
            this.grpproductname.Controls.Add(this.textBox2);
            this.grpproductname.Controls.Add(this.lblStock);
            this.grpproductname.Controls.Add(this.btnAdd);
            this.grpproductname.Controls.Add(this.lblBatchNo);
            this.grpproductname.Controls.Add(this.lblMRP);
            this.grpproductname.Controls.Add(this.txtProduct);
            this.grpproductname.Controls.Add(this.lblProductName);
            this.grpproductname.Location = new System.Drawing.Point(11, 77);
            this.grpproductname.Name = "grpproductname";
            this.grpproductname.Size = new System.Drawing.Size(1314, 77);
            this.grpproductname.TabIndex = 958812;
            this.grpproductname.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(398, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 20);
            this.label4.TabIndex = 1111186;
            this.label4.Text = "₹";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(979, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 20);
            this.label3.TabIndex = 958834;
            this.label3.Text = "Pkts";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(868, 40);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(104, 27);
            this.textBox4.TabIndex = 958831;
            // 
            // textBox3
            // 
            this.textBox3.Enabled = false;
            this.textBox3.Location = new System.Drawing.Point(708, 40);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(154, 27);
            this.textBox3.TabIndex = 958826;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(868, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 20);
            this.label2.TabIndex = 958829;
            this.label2.Text = "Outward Quantity";
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(415, 40);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(114, 27);
            this.textBox1.TabIndex = 958823;
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(541, 40);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(161, 27);
            this.textBox2.TabIndex = 958825;
            // 
            // lblStock
            // 
            this.lblStock.AutoSize = true;
            this.lblStock.Location = new System.Drawing.Point(541, 16);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(70, 20);
            this.lblStock.TabIndex = 958833;
            this.lblStock.Text = "Expiry Date";
            // 
            // btnAdd
            // 
            this.btnAdd.Image = global::ROMS.Properties.Resources.plus;
            this.btnAdd.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAdd.Location = new System.Drawing.Point(1029, 42);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(21, 22);
            this.btnAdd.TabIndex = 958832;
            this.btnAdd.Text = "        ";
            // 
            // lblBatchNo
            // 
            this.lblBatchNo.AutoSize = true;
            this.lblBatchNo.Location = new System.Drawing.Point(708, 14);
            this.lblBatchNo.Name = "lblBatchNo";
            this.lblBatchNo.Size = new System.Drawing.Size(61, 20);
            this.lblBatchNo.TabIndex = 958827;
            this.lblBatchNo.Text = "Batch No.";
            // 
            // lblMRP
            // 
            this.lblMRP.AutoSize = true;
            this.lblMRP.Location = new System.Drawing.Point(415, 15);
            this.lblMRP.Name = "lblMRP";
            this.lblMRP.Size = new System.Drawing.Size(34, 20);
            this.lblMRP.TabIndex = 958824;
            this.lblMRP.Text = "MRP";
            // 
            // txtProduct
            // 
            this.txtProduct.Location = new System.Drawing.Point(13, 40);
            this.txtProduct.Name = "txtProduct";
            this.txtProduct.Size = new System.Drawing.Size(375, 27);
            this.txtProduct.TabIndex = 82;
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Location = new System.Drawing.Point(13, 17);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(134, 20);
            this.lblProductName.TabIndex = 28;
            this.lblProductName.Text = "Product Name/P.I Code";
            // 
            // INV_GodownOutward
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(1354, 675);
            this.Controls.Add(this.pnlGoodsOutward);
            this.Controls.Add(this.tsStockTransferList);
            this.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "INV_GodownOutward";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Goods Outward";
            this.Load += new System.EventHandler(this.CP_Rack_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CP_Rack_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.errGroup)).EndInit();
            this.tsStockTransferList.ResumeLayout(false);
            this.tsStockTransferList.PerformLayout();
            this.pnlGoodsOutward.ResumeLayout(false);
            this.grpGoodsOutward.ResumeLayout(false);
            this.grpGoodsOutward.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_inward)).EndInit();
            this.grbgodownoutward.ResumeLayout(false);
            this.grbgodownoutward.PerformLayout();
            this.grpproductname.ResumeLayout(false);
            this.grpproductname.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ErrorProvider errGroup;
        private System.Windows.Forms.ToolStrip tsStockTransferList;
        private System.Windows.Forms.ToolStripLabel tspHeader;
        private System.Windows.Forms.Panel pnlGoodsOutward;
        private System.Windows.Forms.GroupBox grpGoodsOutward;
        public System.Windows.Forms.DataGridView DGV_inward;
        private System.Windows.Forms.GroupBox grbgodownoutward;
        private System.Windows.Forms.TextBox txtOutwardNo;
        private System.Windows.Forms.ComboBox cmbGodown;
        private System.Windows.Forms.DateTimePicker dtpoutwarddate;
        private System.Windows.Forms.Label lblGodown;
        private System.Windows.Forms.Label lbloutwarddate;
        private System.Windows.Forms.ComboBox cmbConcern;
        private System.Windows.Forms.Label lblConcern;
        private System.Windows.Forms.Label lbloutwardno;
        private System.Windows.Forms.GroupBox grpproductname;
        private System.Windows.Forms.TextBox txtProduct;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label lblRemark;
        public System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ComboBox cmbTransactionType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label lblStock;
        internal System.Windows.Forms.Label btnAdd;
        private System.Windows.Forms.Label lblBatchNo;
        private System.Windows.Forms.Label lblMRP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txttotalitem;
        private System.Windows.Forms.Label lbltotalproducts;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmdsno;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmicode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmproductname;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmbatch;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmexpirydate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmunit;
        private System.Windows.Forms.DataGridViewButtonColumn Column4;
    }
}