namespace ROMS
{
    partial class INV_Inward
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tspHeader = new System.Windows.Forms.ToolStripLabel();
            this.tsInwardList = new System.Windows.Forms.ToolStrip();
            this.pnlinward = new System.Windows.Forms.Panel();
            this.lvProductName = new System.Windows.Forms.ListView();
            this.btnsaveasdraft = new System.Windows.Forms.Button();
            this.txttotalitem = new System.Windows.Forms.TextBox();
            this.lbltotalproducts = new System.Windows.Forms.Label();
            this.grpsalesmandetails = new System.Windows.Forms.GroupBox();
            this.grbSupplierDetails = new System.Windows.Forms.GroupBox();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.lblnarration = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.DGV_inward = new System.Windows.Forms.DataGridView();
            this.clmdsno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmicode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmproductname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmexpirydate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmdop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmmrp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clminvoiceqty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmactualqty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmunit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmremove = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpproductname = new System.Windows.Forms.GroupBox();
            this.lblYyyy = new System.Windows.Forms.Label();
            this.lblMM = new System.Windows.Forms.Label();
            this.lblDd = new System.Windows.Forms.Label();
            this.lblExpiryDate = new System.Windows.Forms.Label();
            this.txtunitrate = new System.Windows.Forms.TextBox();
            this.lblbatchno = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtDay = new System.Windows.Forms.TextBox();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.txtActualQty = new System.Windows.Forms.TextBox();
            this.lblActualQty = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Label();
            this.txtMrp = new System.Windows.Forms.TextBox();
            this.lblMrp = new System.Windows.Forms.Label();
            this.lblProductName = new System.Windows.Forms.Label();
            this.grbgodown = new System.Windows.Forms.GroupBox();
            this.txtInwardNo = new System.Windows.Forms.TextBox();
            this.lblInwardNo = new System.Windows.Forms.Label();
            this.lblInwardDate = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.cmbinwardtype = new System.Windows.Forms.ComboBox();
            this.lblinwardtype = new System.Windows.Forms.Label();
            this.lblConcern = new System.Windows.Forms.Label();
            this.txtsuppliername = new System.Windows.Forms.TextBox();
            this.cmbGodown = new System.Windows.Forms.ComboBox();
            this.lblGodown = new System.Windows.Forms.Label();
            this.lblSupplierName = new System.Windows.Forms.Label();
            this.lblVoucherNo = new System.Windows.Forms.Label();
            this.lblEdit = new System.Windows.Forms.Label();
            this.txtVoucherNo = new System.Windows.Forms.TextBox();
            this.tsInwardList.SuspendLayout();
            this.pnlinward.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_inward)).BeginInit();
            this.grpproductname.SuspendLayout();
            this.grbgodown.SuspendLayout();
            this.SuspendLayout();
            // 
            // tspHeader
            // 
            this.tspHeader.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tspHeader.Image = global::ROMS.Properties.Resources.bread_crumb;
            this.tspHeader.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tspHeader.Margin = new System.Windows.Forms.Padding(15, 1, 0, 2);
            this.tspHeader.Name = "tspHeader";
            this.tspHeader.Size = new System.Drawing.Size(112, 22);
            this.tspHeader.Text = "Godown Inward ";
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
            this.pnlinward.Controls.Add(this.btnsaveasdraft);
            this.pnlinward.Controls.Add(this.txttotalitem);
            this.pnlinward.Controls.Add(this.lbltotalproducts);
            this.pnlinward.Controls.Add(this.grpsalesmandetails);
            this.pnlinward.Controls.Add(this.grbSupplierDetails);
            this.pnlinward.Controls.Add(this.txtRemark);
            this.pnlinward.Controls.Add(this.lblnarration);
            this.pnlinward.Controls.Add(this.btnSave);
            this.pnlinward.Controls.Add(this.btnClose);
            this.pnlinward.Controls.Add(this.DGV_inward);
            this.pnlinward.Controls.Add(this.grpproductname);
            this.pnlinward.Controls.Add(this.grbgodown);
            this.pnlinward.Location = new System.Drawing.Point(0, 29);
            this.pnlinward.Name = "pnlinward";
            this.pnlinward.Size = new System.Drawing.Size(1354, 645);
            this.pnlinward.TabIndex = 36;
            // 
            // lvProductName
            // 
            this.lvProductName.HideSelection = false;
            this.lvProductName.Location = new System.Drawing.Point(15, 193);
            this.lvProductName.Name = "lvProductName";
            this.lvProductName.Size = new System.Drawing.Size(378, 69);
            this.lvProductName.TabIndex = 958808;
            this.lvProductName.UseCompatibleStateImageBehavior = false;
            this.lvProductName.Visible = false;
            // 
            // btnsaveasdraft
            // 
            this.btnsaveasdraft.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnsaveasdraft.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnsaveasdraft.Location = new System.Drawing.Point(1069, 592);
            this.btnsaveasdraft.Name = "btnsaveasdraft";
            this.btnsaveasdraft.Size = new System.Drawing.Size(97, 29);
            this.btnsaveasdraft.TabIndex = 958825;
            this.btnsaveasdraft.Text = "Save as Draft";
            this.btnsaveasdraft.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnsaveasdraft.UseVisualStyleBackColor = true;
            this.btnsaveasdraft.Click += new System.EventHandler(this.Btnsaveasdraft_Click);
            // 
            // txttotalitem
            // 
            this.txttotalitem.Location = new System.Drawing.Point(995, 594);
            this.txttotalitem.Name = "txttotalitem";
            this.txttotalitem.ReadOnly = true;
            this.txttotalitem.Size = new System.Drawing.Size(62, 27);
            this.txttotalitem.TabIndex = 958822;
            // 
            // lbltotalproducts
            // 
            this.lbltotalproducts.AutoSize = true;
            this.lbltotalproducts.Location = new System.Drawing.Point(905, 597);
            this.lbltotalproducts.Name = "lbltotalproducts";
            this.lbltotalproducts.Size = new System.Drawing.Size(87, 20);
            this.lbltotalproducts.TabIndex = 958821;
            this.lbltotalproducts.Text = "Total Products";
            // 
            // grpsalesmandetails
            // 
            this.grpsalesmandetails.Location = new System.Drawing.Point(1116, 2);
            this.grpsalesmandetails.Name = "grpsalesmandetails";
            this.grpsalesmandetails.Size = new System.Drawing.Size(227, 198);
            this.grpsalesmandetails.TabIndex = 958814;
            this.grpsalesmandetails.TabStop = false;
            this.grpsalesmandetails.Text = "Sales Man Details";
            // 
            // grbSupplierDetails
            // 
            this.grbSupplierDetails.Location = new System.Drawing.Point(879, 1);
            this.grbSupplierDetails.Name = "grbSupplierDetails";
            this.grbSupplierDetails.Size = new System.Drawing.Size(227, 198);
            this.grbSupplierDetails.TabIndex = 958813;
            this.grbSupplierDetails.TabStop = false;
            this.grbSupplierDetails.Text = "Supplier Details";
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(83, 593);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(320, 50);
            this.txtRemark.TabIndex = 958807;
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
            this.btnSave.TabIndex = 958810;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnClose.Image = global::ROMS.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(1268, 592);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 29);
            this.btnClose.TabIndex = 958811;
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
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(242)))), ((int)(((byte)(213)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_inward.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.DGV_inward.ColumnHeadersHeight = 30;
            this.DGV_inward.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGV_inward.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmdsno,
            this.clmicode,
            this.clmproductname,
            this.clmexpirydate,
            this.clmdop,
            this.clmmrp,
            this.clminvoiceqty,
            this.clmactualqty,
            this.clmunit,
            this.clmremove});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV_inward.DefaultCellStyle = dataGridViewCellStyle5;
            this.DGV_inward.EnableHeadersVisualStyles = false;
            this.DGV_inward.GridColor = System.Drawing.Color.White;
            this.DGV_inward.Location = new System.Drawing.Point(3, 205);
            this.DGV_inward.Name = "DGV_inward";
            this.DGV_inward.RowHeadersVisible = false;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            this.DGV_inward.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.DGV_inward.RowTemplate.Height = 25;
            this.DGV_inward.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DGV_inward.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DGV_inward.ShowRowErrors = false;
            this.DGV_inward.Size = new System.Drawing.Size(1340, 382);
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
            // clmexpirydate
            // 
            this.clmexpirydate.HeaderText = "Expiry Date";
            this.clmexpirydate.Name = "clmexpirydate";
            // 
            // clmdop
            // 
            this.clmdop.HeaderText = "DOP";
            this.clmdop.Name = "clmdop";
            // 
            // clmmrp
            // 
            this.clmmrp.HeaderText = "MRP";
            this.clmmrp.Name = "clmmrp";
            // 
            // clminvoiceqty
            // 
            this.clminvoiceqty.HeaderText = "Invoice Qty";
            this.clminvoiceqty.Name = "clminvoiceqty";
            // 
            // clmactualqty
            // 
            this.clmactualqty.HeaderText = "Actual Qty";
            this.clmactualqty.Name = "clmactualqty";
            // 
            // clmunit
            // 
            this.clmunit.HeaderText = "Unit";
            this.clmunit.Name = "clmunit";
            // 
            // clmremove
            // 
            this.clmremove.HeaderText = "Remove";
            this.clmremove.Name = "clmremove";
            // 
            // grpproductname
            // 
            this.grpproductname.Controls.Add(this.lblYyyy);
            this.grpproductname.Controls.Add(this.lblMM);
            this.grpproductname.Controls.Add(this.lblDd);
            this.grpproductname.Controls.Add(this.lblExpiryDate);
            this.grpproductname.Controls.Add(this.txtunitrate);
            this.grpproductname.Controls.Add(this.lblbatchno);
            this.grpproductname.Controls.Add(this.textBox2);
            this.grpproductname.Controls.Add(this.textBox1);
            this.grpproductname.Controls.Add(this.txtDay);
            this.grpproductname.Controls.Add(this.txtProductName);
            this.grpproductname.Controls.Add(this.txtActualQty);
            this.grpproductname.Controls.Add(this.lblActualQty);
            this.grpproductname.Controls.Add(this.btnAdd);
            this.grpproductname.Controls.Add(this.txtMrp);
            this.grpproductname.Controls.Add(this.lblMrp);
            this.grpproductname.Controls.Add(this.lblProductName);
            this.grpproductname.Location = new System.Drawing.Point(3, 129);
            this.grpproductname.Name = "grpproductname";
            this.grpproductname.Size = new System.Drawing.Size(865, 70);
            this.grpproductname.TabIndex = 958806;
            this.grpproductname.TabStop = false;
            // 
            // lblYyyy
            // 
            this.lblYyyy.AutoSize = true;
            this.lblYyyy.Location = new System.Drawing.Point(510, 14);
            this.lblYyyy.Name = "lblYyyy";
            this.lblYyyy.Size = new System.Drawing.Size(37, 20);
            this.lblYyyy.TabIndex = 958824;
            this.lblYyyy.Text = "YYYY";
            // 
            // lblMM
            // 
            this.lblMM.AutoSize = true;
            this.lblMM.Location = new System.Drawing.Point(476, 14);
            this.lblMM.Name = "lblMM";
            this.lblMM.Size = new System.Drawing.Size(29, 20);
            this.lblMM.TabIndex = 958823;
            this.lblMM.Text = "MM";
            // 
            // lblDd
            // 
            this.lblDd.AutoSize = true;
            this.lblDd.Location = new System.Drawing.Point(443, 14);
            this.lblDd.Name = "lblDd";
            this.lblDd.Size = new System.Drawing.Size(25, 20);
            this.lblDd.TabIndex = 958822;
            this.lblDd.Text = "DD";
            // 
            // lblExpiryDate
            // 
            this.lblExpiryDate.AutoSize = true;
            this.lblExpiryDate.Location = new System.Drawing.Point(370, 40);
            this.lblExpiryDate.Name = "lblExpiryDate";
            this.lblExpiryDate.Size = new System.Drawing.Size(70, 20);
            this.lblExpiryDate.TabIndex = 958821;
            this.lblExpiryDate.Text = "Expiry Date";
            // 
            // txtunitrate
            // 
            this.txtunitrate.Location = new System.Drawing.Point(617, 37);
            this.txtunitrate.Name = "txtunitrate";
            this.txtunitrate.Size = new System.Drawing.Size(115, 27);
            this.txtunitrate.TabIndex = 958815;
            // 
            // lblbatchno
            // 
            this.lblbatchno.AutoSize = true;
            this.lblbatchno.Location = new System.Drawing.Point(617, 14);
            this.lblbatchno.Name = "lblbatchno";
            this.lblbatchno.Size = new System.Drawing.Size(61, 20);
            this.lblbatchno.TabIndex = 958816;
            this.lblbatchno.Text = "Batch No.";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(510, 37);
            this.textBox2.MaxLength = 4;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(34, 27);
            this.textBox2.TabIndex = 958814;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(476, 37);
            this.textBox1.MaxLength = 2;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(34, 27);
            this.textBox1.TabIndex = 958812;
            // 
            // txtDay
            // 
            this.txtDay.Location = new System.Drawing.Point(443, 37);
            this.txtDay.MaxLength = 2;
            this.txtDay.Name = "txtDay";
            this.txtDay.Size = new System.Drawing.Size(34, 27);
            this.txtDay.TabIndex = 958810;
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(13, 37);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(349, 27);
            this.txtProductName.TabIndex = 82;
            // 
            // txtActualQty
            // 
            this.txtActualQty.Location = new System.Drawing.Point(744, 37);
            this.txtActualQty.Name = "txtActualQty";
            this.txtActualQty.Size = new System.Drawing.Size(69, 27);
            this.txtActualQty.TabIndex = 81;
            // 
            // lblActualQty
            // 
            this.lblActualQty.AutoSize = true;
            this.lblActualQty.Location = new System.Drawing.Point(744, 14);
            this.lblActualQty.Name = "lblActualQty";
            this.lblActualQty.Size = new System.Drawing.Size(68, 20);
            this.lblActualQty.TabIndex = 80;
            this.lblActualQty.Text = "Actual Qty.";
            // 
            // btnAdd
            // 
            this.btnAdd.Image = global::ROMS.Properties.Resources.plus;
            this.btnAdd.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAdd.Location = new System.Drawing.Point(830, 42);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(21, 22);
            this.btnAdd.TabIndex = 958800;
            this.btnAdd.Text = "        ";
            // 
            // txtMrp
            // 
            this.txtMrp.Enabled = false;
            this.txtMrp.Location = new System.Drawing.Point(557, 37);
            this.txtMrp.Name = "txtMrp";
            this.txtMrp.Size = new System.Drawing.Size(52, 27);
            this.txtMrp.TabIndex = 74;
            // 
            // lblMrp
            // 
            this.lblMrp.AutoSize = true;
            this.lblMrp.Location = new System.Drawing.Point(557, 14);
            this.lblMrp.Name = "lblMrp";
            this.lblMrp.Size = new System.Drawing.Size(34, 20);
            this.lblMrp.TabIndex = 77;
            this.lblMrp.Text = "MRP";
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
            // grbgodown
            // 
            this.grbgodown.Controls.Add(this.txtVoucherNo);
            this.grbgodown.Controls.Add(this.txtInwardNo);
            this.grbgodown.Controls.Add(this.lblInwardNo);
            this.grbgodown.Controls.Add(this.lblInwardDate);
            this.grbgodown.Controls.Add(this.dateTimePicker1);
            this.grbgodown.Controls.Add(this.comboBox1);
            this.grbgodown.Controls.Add(this.cmbinwardtype);
            this.grbgodown.Controls.Add(this.lblinwardtype);
            this.grbgodown.Controls.Add(this.lblConcern);
            this.grbgodown.Controls.Add(this.txtsuppliername);
            this.grbgodown.Controls.Add(this.cmbGodown);
            this.grbgodown.Controls.Add(this.lblGodown);
            this.grbgodown.Controls.Add(this.lblSupplierName);
            this.grbgodown.Controls.Add(this.lblVoucherNo);
            this.grbgodown.Location = new System.Drawing.Point(3, 2);
            this.grbgodown.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbgodown.Name = "grbgodown";
            this.grbgodown.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbgodown.Size = new System.Drawing.Size(866, 125);
            this.grbgodown.TabIndex = 958805;
            this.grbgodown.TabStop = false;
            // 
            // txtInwardNo
            // 
            this.txtInwardNo.Location = new System.Drawing.Point(344, 36);
            this.txtInwardNo.Name = "txtInwardNo";
            this.txtInwardNo.Size = new System.Drawing.Size(153, 27);
            this.txtInwardNo.TabIndex = 958819;
            // 
            // lblInwardNo
            // 
            this.lblInwardNo.AutoSize = true;
            this.lblInwardNo.Location = new System.Drawing.Point(344, 14);
            this.lblInwardNo.Name = "lblInwardNo";
            this.lblInwardNo.Size = new System.Drawing.Size(67, 20);
            this.lblInwardNo.TabIndex = 958818;
            this.lblInwardNo.Text = "Inward No.";
            // 
            // lblInwardDate
            // 
            this.lblInwardDate.AutoSize = true;
            this.lblInwardDate.Location = new System.Drawing.Point(225, 14);
            this.lblInwardDate.Name = "lblInwardDate";
            this.lblInwardDate.Size = new System.Drawing.Size(75, 20);
            this.lblInwardDate.TabIndex = 958817;
            this.lblInwardDate.Text = "Inward Date";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(225, 36);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(104, 27);
            this.dateTimePicker1.TabIndex = 958816;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(13, 36);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(201, 27);
            this.comboBox1.TabIndex = 87;
            // 
            // cmbinwardtype
            // 
            this.cmbinwardtype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbinwardtype.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbinwardtype.FormattingEnabled = true;
            this.cmbinwardtype.Items.AddRange(new object[] {
            "Purchase",
            "Direct"});
            this.cmbinwardtype.Location = new System.Drawing.Point(223, 87);
            this.cmbinwardtype.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbinwardtype.Name = "cmbinwardtype";
            this.cmbinwardtype.Size = new System.Drawing.Size(104, 27);
            this.cmbinwardtype.TabIndex = 85;
            // 
            // lblinwardtype
            // 
            this.lblinwardtype.AutoSize = true;
            this.lblinwardtype.Location = new System.Drawing.Point(225, 66);
            this.lblinwardtype.Name = "lblinwardtype";
            this.lblinwardtype.Size = new System.Drawing.Size(75, 20);
            this.lblinwardtype.TabIndex = 84;
            this.lblinwardtype.Text = "Inward Type";
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
            // txtsuppliername
            // 
            this.txtsuppliername.Location = new System.Drawing.Point(510, 36);
            this.txtsuppliername.Name = "txtsuppliername";
            this.txtsuppliername.Size = new System.Drawing.Size(333, 27);
            this.txtsuppliername.TabIndex = 83;
            this.txtsuppliername.TextChanged += new System.EventHandler(this.Txtsuppliername_TextChanged);
            // 
            // cmbGodown
            // 
            this.cmbGodown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGodown.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbGodown.FormattingEnabled = true;
            this.cmbGodown.Location = new System.Drawing.Point(15, 87);
            this.cmbGodown.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbGodown.Name = "cmbGodown";
            this.cmbGodown.Size = new System.Drawing.Size(201, 27);
            this.cmbGodown.TabIndex = 73;
            // 
            // lblGodown
            // 
            this.lblGodown.AutoSize = true;
            this.lblGodown.Location = new System.Drawing.Point(15, 65);
            this.lblGodown.Name = "lblGodown";
            this.lblGodown.Size = new System.Drawing.Size(52, 20);
            this.lblGodown.TabIndex = 70;
            this.lblGodown.Text = "Godown";
            // 
            // lblSupplierName
            // 
            this.lblSupplierName.AutoSize = true;
            this.lblSupplierName.Location = new System.Drawing.Point(510, 14);
            this.lblSupplierName.Name = "lblSupplierName";
            this.lblSupplierName.Size = new System.Drawing.Size(87, 20);
            this.lblSupplierName.TabIndex = 27;
            this.lblSupplierName.Text = "Supplier Name";
            // 
            // lblVoucherNo
            // 
            this.lblVoucherNo.AutoSize = true;
            this.lblVoucherNo.Location = new System.Drawing.Point(344, 66);
            this.lblVoucherNo.Name = "lblVoucherNo";
            this.lblVoucherNo.Size = new System.Drawing.Size(74, 20);
            this.lblVoucherNo.TabIndex = 66;
            this.lblVoucherNo.Text = "Voucher No.";
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
            // txtVoucherNo
            // 
            this.txtVoucherNo.Location = new System.Drawing.Point(344, 87);
            this.txtVoucherNo.Name = "txtVoucherNo";
            this.txtVoucherNo.ReadOnly = true;
            this.txtVoucherNo.Size = new System.Drawing.Size(153, 27);
            this.txtVoucherNo.TabIndex = 958820;
            // 
            // INV_Inward
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
            this.Name = "INV_Inward";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Brand";
            this.Load += new System.EventHandler(this.INV_Inward_Load);
            this.tsInwardList.ResumeLayout(false);
            this.tsInwardList.PerformLayout();
            this.pnlinward.ResumeLayout(false);
            this.pnlinward.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_inward)).EndInit();
            this.grpproductname.ResumeLayout(false);
            this.grpproductname.PerformLayout();
            this.grbgodown.ResumeLayout(false);
            this.grbgodown.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStripLabel tspHeader;
        private System.Windows.Forms.ToolStrip tsInwardList;
        private System.Windows.Forms.Panel pnlinward;
        private System.Windows.Forms.TextBox txtsuppliername;
        private System.Windows.Forms.GroupBox grbSupplierDetails;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label lblnarration;
        private System.Windows.Forms.ListView lvProductName;
        public System.Windows.Forms.DataGridView DGV_inward;
        private System.Windows.Forms.GroupBox grpproductname;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.TextBox txtActualQty;
        private System.Windows.Forms.Label lblActualQty;
        internal System.Windows.Forms.Label btnAdd;
        private System.Windows.Forms.Label lblMrp;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.GroupBox grbgodown;
        private System.Windows.Forms.ComboBox cmbGodown;
        private System.Windows.Forms.Label lblGodown;
        private System.Windows.Forms.Label lblVoucherNo;
        private System.Windows.Forms.Label lblSupplierName;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox txtDay;
        private System.Windows.Forms.TextBox txtMrp;
        private System.Windows.Forms.GroupBox grpsalesmandetails;
        private System.Windows.Forms.ComboBox cmbinwardtype;
        private System.Windows.Forms.Label lblinwardtype;
        private System.Windows.Forms.TextBox txttotalitem;
        private System.Windows.Forms.Label lbltotalproducts;
        private System.Windows.Forms.Label lblEdit;
        public System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblExpiryDate;
        public System.Windows.Forms.Button btnsaveasdraft;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtunitrate;
        private System.Windows.Forms.Label lblbatchno;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmdsno;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmicode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmproductname;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmexpirydate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmdop;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmmrp;
        private System.Windows.Forms.DataGridViewTextBoxColumn clminvoiceqty;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmactualqty;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmunit;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmremove;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label lblConcern;
        private System.Windows.Forms.TextBox txtInwardNo;
        private System.Windows.Forms.Label lblInwardNo;
        private System.Windows.Forms.Label lblInwardDate;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label lblYyyy;
        private System.Windows.Forms.Label lblMM;
        private System.Windows.Forms.Label lblDd;
        private System.Windows.Forms.TextBox txtVoucherNo;
    }
}