namespace ROMS
{
    partial class PUR_DCGoodsInward
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PUR_DCGoodsInward));
            this.epLocation = new System.Windows.Forms.ErrorProvider(this.components);
            this.label23 = new System.Windows.Forms.Label();
            this.lblUnit = new System.Windows.Forms.Label();
            this.txtBatchNo = new System.Windows.Forms.TextBox();
            this.lblbatchno = new System.Windows.Forms.Label();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.txtActualQty = new System.Windows.Forms.TextBox();
            this.lblActualQty = new System.Windows.Forms.Label();
            this.lblExpiryDate = new System.Windows.Forms.Label();
            this.txtMrp = new System.Windows.Forms.TextBox();
            this.lblMrp = new System.Windows.Forms.Label();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.lblProductName = new System.Windows.Forms.Label();
            this.txtDay = new System.Windows.Forms.TextBox();
            this.txtMonth = new System.Windows.Forms.TextBox();
            this.lblYyyy = new System.Windows.Forms.Label();
            this.lblMM = new System.Windows.Forms.Label();
            this.lblDd = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.grpproductname = new System.Windows.Forms.GroupBox();
            this.lblProductcode = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.pnlinward = new System.Windows.Forms.Panel();
            this.lvproduct = new System.Windows.Forms.ListView();
            this.RMcode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RMTname = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader17 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader18 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader19 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader20 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txttotalitem = new System.Windows.Forms.TextBox();
            this.lbltotalproducts = new System.Windows.Forms.Label();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.lblnarration = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.grdProductExchage = new System.Windows.Forms.DataGridView();
            this.epProductExchange = new System.Windows.Forms.ErrorProvider(this.components);
            this.clmdsno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPIcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmproductname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmunit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmmrp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmexpirydate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmBatchNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmremove = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.epLocation)).BeginInit();
            this.grpproductname.SuspendLayout();
            this.pnlinward.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdProductExchage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epProductExchange)).BeginInit();
            this.SuspendLayout();
            // 
            // epLocation
            // 
            this.epLocation.ContainerControl = this;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(362, 37);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(17, 20);
            this.label23.TabIndex = 1111184;
            this.label23.Text = "₹";
            // 
            // lblUnit
            // 
            this.lblUnit.AutoSize = true;
            this.lblUnit.Location = new System.Drawing.Point(809, 37);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Size = new System.Drawing.Size(33, 20);
            this.lblUnit.TabIndex = 958825;
            this.lblUnit.Text = "Pkts";
            // 
            // txtBatchNo
            // 
            this.txtBatchNo.Location = new System.Drawing.Point(642, 34);
            this.txtBatchNo.Name = "txtBatchNo";
            this.txtBatchNo.Size = new System.Drawing.Size(115, 27);
            this.txtBatchNo.TabIndex = 5;
            this.txtBatchNo.Enter += new System.EventHandler(this.TxtBatchNo_Enter);
            this.txtBatchNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtBatchNo_KeyDown);
            this.txtBatchNo.Leave += new System.EventHandler(this.TxtBatchNo_Leave);
            // 
            // lblbatchno
            // 
            this.lblbatchno.AutoSize = true;
            this.lblbatchno.Location = new System.Drawing.Point(642, 11);
            this.lblbatchno.Name = "lblbatchno";
            this.lblbatchno.Size = new System.Drawing.Size(61, 20);
            this.lblbatchno.TabIndex = 958816;
            this.lblbatchno.Text = "Batch No.";
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(11, 34);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(349, 27);
            this.txtProductName.TabIndex = 0;
            this.txtProductName.TextChanged += new System.EventHandler(this.TxtProductName_TextChanged);
            this.txtProductName.Enter += new System.EventHandler(this.TxtProductName_Enter);
            this.txtProductName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtProductName_KeyDown);
            this.txtProductName.Leave += new System.EventHandler(this.TxtProductName_Leave);
            // 
            // txtActualQty
            // 
            this.txtActualQty.Location = new System.Drawing.Point(760, 34);
            this.txtActualQty.Name = "txtActualQty";
            this.txtActualQty.Size = new System.Drawing.Size(46, 27);
            this.txtActualQty.TabIndex = 6;
            this.txtActualQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtActualQty.Enter += new System.EventHandler(this.TxtActualQty_Enter);
            this.txtActualQty.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtActualQty_KeyDown);
            this.txtActualQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtActualQty_KeyPress);
            this.txtActualQty.Leave += new System.EventHandler(this.TxtActualQty_Leave);
            // 
            // lblActualQty
            // 
            this.lblActualQty.AutoSize = true;
            this.lblActualQty.Location = new System.Drawing.Point(760, 11);
            this.lblActualQty.Name = "lblActualQty";
            this.lblActualQty.Size = new System.Drawing.Size(28, 20);
            this.lblActualQty.TabIndex = 80;
            this.lblActualQty.Text = "Qty";
            // 
            // lblExpiryDate
            // 
            this.lblExpiryDate.AutoSize = true;
            this.lblExpiryDate.Location = new System.Drawing.Point(464, 37);
            this.lblExpiryDate.Name = "lblExpiryDate";
            this.lblExpiryDate.Size = new System.Drawing.Size(70, 20);
            this.lblExpiryDate.TabIndex = 958821;
            this.lblExpiryDate.Text = "Expiry Date";
            // 
            // txtMrp
            // 
            this.txtMrp.Location = new System.Drawing.Point(381, 34);
            this.txtMrp.Name = "txtMrp";
            this.txtMrp.Size = new System.Drawing.Size(75, 27);
            this.txtMrp.TabIndex = 1;
            this.txtMrp.Enter += new System.EventHandler(this.TxtMrp_Enter);
            this.txtMrp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtMrp_KeyDown);
            this.txtMrp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtMrp_KeyPress);
            this.txtMrp.Leave += new System.EventHandler(this.TxtMrp_Leave);
            // 
            // lblMrp
            // 
            this.lblMrp.AutoSize = true;
            this.lblMrp.Location = new System.Drawing.Point(381, 11);
            this.lblMrp.Name = "lblMrp";
            this.lblMrp.Size = new System.Drawing.Size(34, 20);
            this.lblMrp.TabIndex = 77;
            this.lblMrp.Text = "MRP";
            // 
            // txtYear
            // 
            this.txtYear.Location = new System.Drawing.Point(604, 34);
            this.txtYear.MaxLength = 2;
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(34, 27);
            this.txtYear.TabIndex = 4;
            this.txtYear.TextChanged += new System.EventHandler(this.TxtYear_TextChanged);
            this.txtYear.Enter += new System.EventHandler(this.TxtYear_Enter);
            this.txtYear.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtYear_KeyDown);
            this.txtYear.Leave += new System.EventHandler(this.TxtYear_Leave);
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Location = new System.Drawing.Point(6, -3);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(134, 20);
            this.lblProductName.TabIndex = 28;
            this.lblProductName.Text = "Product Name/P.I Code";
            // 
            // txtDay
            // 
            this.txtDay.Location = new System.Drawing.Point(537, 34);
            this.txtDay.MaxLength = 2;
            this.txtDay.Name = "txtDay";
            this.txtDay.Size = new System.Drawing.Size(33, 27);
            this.txtDay.TabIndex = 2;
            this.txtDay.TextChanged += new System.EventHandler(this.TxtDay_TextChanged);
            this.txtDay.Enter += new System.EventHandler(this.TxtDay_Enter);
            this.txtDay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtDay_KeyDown);
            this.txtDay.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtDay_KeyPress);
            this.txtDay.Leave += new System.EventHandler(this.TxtDay_Leave);
            // 
            // txtMonth
            // 
            this.txtMonth.Location = new System.Drawing.Point(570, 34);
            this.txtMonth.MaxLength = 2;
            this.txtMonth.Name = "txtMonth";
            this.txtMonth.Size = new System.Drawing.Size(34, 27);
            this.txtMonth.TabIndex = 3;
            this.txtMonth.TextChanged += new System.EventHandler(this.TxtMonth_TextChanged);
            this.txtMonth.Enter += new System.EventHandler(this.TxtMonth_Enter);
            this.txtMonth.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtMonth_KeyDown);
            this.txtMonth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtMonth_KeyPress);
            this.txtMonth.Leave += new System.EventHandler(this.TxtMonth_Leave);
            // 
            // lblYyyy
            // 
            this.lblYyyy.AutoSize = true;
            this.lblYyyy.Font = new System.Drawing.Font("Oswald Regular", 8.75F);
            this.lblYyyy.Location = new System.Drawing.Point(610, 18);
            this.lblYyyy.Name = "lblYyyy";
            this.lblYyyy.Size = new System.Drawing.Size(20, 16);
            this.lblYyyy.TabIndex = 958824;
            this.lblYyyy.Text = "YY";
            // 
            // lblMM
            // 
            this.lblMM.AutoSize = true;
            this.lblMM.Font = new System.Drawing.Font("Oswald Regular", 8.75F);
            this.lblMM.Location = new System.Drawing.Point(576, 18);
            this.lblMM.Name = "lblMM";
            this.lblMM.Size = new System.Drawing.Size(24, 16);
            this.lblMM.TabIndex = 958823;
            this.lblMM.Text = "MM";
            // 
            // lblDd
            // 
            this.lblDd.AutoSize = true;
            this.lblDd.Font = new System.Drawing.Font("Oswald Regular", 8.75F);
            this.lblDd.Location = new System.Drawing.Point(543, 18);
            this.lblDd.Name = "lblDd";
            this.lblDd.Size = new System.Drawing.Size(20, 16);
            this.lblDd.TabIndex = 958822;
            this.lblDd.Text = "DD";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnSave.Image = global::ROMS.Properties.Resources.save;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(829, 530);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(84, 29);
            this.btnSave.TabIndex = 958810;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // grpproductname
            // 
            this.grpproductname.Controls.Add(this.lblProductcode);
            this.grpproductname.Controls.Add(this.btnAdd);
            this.grpproductname.Controls.Add(this.label23);
            this.grpproductname.Controls.Add(this.lblUnit);
            this.grpproductname.Controls.Add(this.txtBatchNo);
            this.grpproductname.Controls.Add(this.lblbatchno);
            this.grpproductname.Controls.Add(this.txtProductName);
            this.grpproductname.Controls.Add(this.txtActualQty);
            this.grpproductname.Controls.Add(this.lblActualQty);
            this.grpproductname.Controls.Add(this.lblExpiryDate);
            this.grpproductname.Controls.Add(this.txtMrp);
            this.grpproductname.Controls.Add(this.lblMrp);
            this.grpproductname.Controls.Add(this.txtYear);
            this.grpproductname.Controls.Add(this.lblProductName);
            this.grpproductname.Controls.Add(this.txtDay);
            this.grpproductname.Controls.Add(this.txtMonth);
            this.grpproductname.Controls.Add(this.lblYyyy);
            this.grpproductname.Controls.Add(this.lblMM);
            this.grpproductname.Controls.Add(this.lblDd);
            this.grpproductname.Location = new System.Drawing.Point(18, 13);
            this.grpproductname.Name = "grpproductname";
            this.grpproductname.Size = new System.Drawing.Size(972, 70);
            this.grpproductname.TabIndex = 958806;
            this.grpproductname.TabStop = false;
            // 
            // lblProductcode
            // 
            this.lblProductcode.AutoSize = true;
            this.lblProductcode.Location = new System.Drawing.Point(266, 38);
            this.lblProductcode.Name = "lblProductcode";
            this.lblProductcode.Size = new System.Drawing.Size(16, 20);
            this.lblProductcode.TabIndex = 1111210;
            this.lblProductcode.Text = "0";
            this.lblProductcode.Visible = false;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.White;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAdd.Image = global::ROMS.Properties.Resources.plus;
            this.btnAdd.Location = new System.Drawing.Point(845, 34);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(0);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(23, 27);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            this.btnAdd.Enter += new System.EventHandler(this.BtnAdd_Enter);
            this.btnAdd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BtnAdd_KeyDown);
            this.btnAdd.Leave += new System.EventHandler(this.BtnAdd_Leave);
            // 
            // pnlinward
            // 
            this.pnlinward.BackColor = System.Drawing.Color.White;
            this.pnlinward.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlinward.Controls.Add(this.lvproduct);
            this.pnlinward.Controls.Add(this.txttotalitem);
            this.pnlinward.Controls.Add(this.lbltotalproducts);
            this.pnlinward.Controls.Add(this.txtRemark);
            this.pnlinward.Controls.Add(this.lblnarration);
            this.pnlinward.Controls.Add(this.btnSave);
            this.pnlinward.Controls.Add(this.btnClose);
            this.pnlinward.Controls.Add(this.grdProductExchage);
            this.pnlinward.Controls.Add(this.grpproductname);
            this.pnlinward.Location = new System.Drawing.Point(7, 12);
            this.pnlinward.Name = "pnlinward";
            this.pnlinward.Size = new System.Drawing.Size(1001, 608);
            this.pnlinward.TabIndex = 39;
            // 
            // lvproduct
            // 
            this.lvproduct.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.RMcode,
            this.RMTname,
            this.columnHeader13,
            this.columnHeader14,
            this.columnHeader15,
            this.columnHeader16,
            this.columnHeader17,
            this.columnHeader18,
            this.columnHeader19,
            this.columnHeader20});
            this.lvproduct.FullRowSelect = true;
            this.lvproduct.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvproduct.HideSelection = false;
            this.lvproduct.Location = new System.Drawing.Point(24, 127);
            this.lvproduct.Name = "lvproduct";
            this.lvproduct.Size = new System.Drawing.Size(703, 140);
            this.lvproduct.TabIndex = 1111185;
            this.lvproduct.UseCompatibleStateImageBehavior = false;
            this.lvproduct.View = System.Windows.Forms.View.Details;
            this.lvproduct.Visible = false;
            this.lvproduct.DoubleClick += new System.EventHandler(this.Lvproduct_DoubleClick);
            this.lvproduct.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Lvproduct_KeyDown);
            // 
            // RMcode
            // 
            this.RMcode.Text = "P.I Code";
            this.RMcode.Width = 250;
            // 
            // RMTname
            // 
            this.RMTname.Text = "Product Name";
            this.RMTname.Width = 250;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "Unit";
            this.columnHeader13.Width = 0;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Width = 0;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Width = 0;
            // 
            // columnHeader16
            // 
            this.columnHeader16.Width = 0;
            // 
            // columnHeader17
            // 
            this.columnHeader17.Width = 0;
            // 
            // columnHeader18
            // 
            this.columnHeader18.Width = 0;
            // 
            // columnHeader19
            // 
            this.columnHeader19.Width = 0;
            // 
            // columnHeader20
            // 
            this.columnHeader20.Width = 0;
            // 
            // txttotalitem
            // 
            this.txttotalitem.Location = new System.Drawing.Point(757, 530);
            this.txttotalitem.Name = "txttotalitem";
            this.txttotalitem.ReadOnly = true;
            this.txttotalitem.Size = new System.Drawing.Size(62, 27);
            this.txttotalitem.TabIndex = 958822;
            // 
            // lbltotalproducts
            // 
            this.lbltotalproducts.AutoSize = true;
            this.lbltotalproducts.Location = new System.Drawing.Point(667, 530);
            this.lbltotalproducts.Name = "lbltotalproducts";
            this.lbltotalproducts.Size = new System.Drawing.Size(87, 20);
            this.lbltotalproducts.TabIndex = 958821;
            this.lbltotalproducts.Text = "Total Products";
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(76, 530);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(511, 56);
            this.txtRemark.TabIndex = 958807;
            // 
            // lblnarration
            // 
            this.lblnarration.AutoSize = true;
            this.lblnarration.Location = new System.Drawing.Point(17, 530);
            this.lblnarration.Name = "lblnarration";
            this.lblnarration.Size = new System.Drawing.Size(56, 20);
            this.lblnarration.TabIndex = 958812;
            this.lblnarration.Text = "Remarks";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnClose.Image = global::ROMS.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(916, 530);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 29);
            this.btnClose.TabIndex = 958811;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // grdProductExchage
            // 
            this.grdProductExchage.AllowUserToAddRows = false;
            this.grdProductExchage.AllowUserToDeleteRows = false;
            this.grdProductExchage.AllowUserToResizeRows = false;
            this.grdProductExchage.BackgroundColor = System.Drawing.Color.White;
            this.grdProductExchage.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(242)))), ((int)(((byte)(213)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdProductExchage.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdProductExchage.ColumnHeadersHeight = 30;
            this.grdProductExchage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdProductExchage.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmdsno,
            this.clmPIcode,
            this.clmproductname,
            this.clmunit,
            this.clmmrp,
            this.clmexpirydate,
            this.clmBatchNo,
            this.clmQuantity,
            this.clmremove});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdProductExchage.DefaultCellStyle = dataGridViewCellStyle2;
            this.grdProductExchage.EnableHeadersVisualStyles = false;
            this.grdProductExchage.GridColor = System.Drawing.Color.White;
            this.grdProductExchage.Location = new System.Drawing.Point(17, 88);
            this.grdProductExchage.Name = "grdProductExchage";
            this.grdProductExchage.RowHeadersVisible = false;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.grdProductExchage.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.grdProductExchage.RowTemplate.Height = 25;
            this.grdProductExchage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.grdProductExchage.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.grdProductExchage.ShowRowErrors = false;
            this.grdProductExchage.Size = new System.Drawing.Size(974, 422);
            this.grdProductExchage.TabIndex = 958809;
            // 
            // epProductExchange
            // 
            this.epProductExchange.ContainerControl = this;
            // 
            // clmdsno
            // 
            this.clmdsno.HeaderText = "S.No.";
            this.clmdsno.Name = "clmdsno";
            this.clmdsno.Width = 50;
            // 
            // clmPIcode
            // 
            this.clmPIcode.HeaderText = "P.I Code";
            this.clmPIcode.Name = "clmPIcode";
            this.clmPIcode.Width = 80;
            // 
            // clmproductname
            // 
            this.clmproductname.HeaderText = "Product Name";
            this.clmproductname.Name = "clmproductname";
            this.clmproductname.Width = 200;
            // 
            // clmunit
            // 
            this.clmunit.HeaderText = "Unit";
            this.clmunit.Name = "clmunit";
            this.clmunit.Width = 50;
            // 
            // clmmrp
            // 
            this.clmmrp.HeaderText = "MRP";
            this.clmmrp.Name = "clmmrp";
            this.clmmrp.Width = 50;
            // 
            // clmexpirydate
            // 
            this.clmexpirydate.HeaderText = "Expiry Date";
            this.clmexpirydate.Name = "clmexpirydate";
            // 
            // clmBatchNo
            // 
            this.clmBatchNo.HeaderText = "Batch No.";
            this.clmBatchNo.Name = "clmBatchNo";
            this.clmBatchNo.ReadOnly = true;
            // 
            // clmQuantity
            // 
            this.clmQuantity.HeaderText = "Quantity";
            this.clmQuantity.Name = "clmQuantity";
            // 
            // clmremove
            // 
            this.clmremove.HeaderText = "Remove";
            this.clmremove.Name = "clmremove";
            // 
            // PUR_DCGoodsInward
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1018, 636);
            this.Controls.Add(this.pnlinward);
            this.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PUR_DCGoodsInward";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Product Exchange Details";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PUR_DCGoodsInward_FormClosing);
            this.Load += new System.EventHandler(this.PUR_DCGoodsInward_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PUR_DCGoodsInward_KeyDown);
            this.Leave += new System.EventHandler(this.PUR_DCGoodsInward_Leave);
            ((System.ComponentModel.ISupportInitialize)(this.epLocation)).EndInit();
            this.grpproductname.ResumeLayout(false);
            this.grpproductname.PerformLayout();
            this.pnlinward.ResumeLayout(false);
            this.pnlinward.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdProductExchage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epProductExchange)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ErrorProvider epLocation;
        private System.Windows.Forms.Panel pnlinward;
        private System.Windows.Forms.TextBox txttotalitem;
        private System.Windows.Forms.Label lbltotalproducts;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label lblnarration;
        public System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        public System.Windows.Forms.DataGridView grdProductExchage;
        private System.Windows.Forms.GroupBox grpproductname;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label lblUnit;
        private System.Windows.Forms.TextBox txtBatchNo;
        private System.Windows.Forms.Label lblbatchno;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.TextBox txtActualQty;
        private System.Windows.Forms.Label lblActualQty;
        private System.Windows.Forms.Label lblExpiryDate;
        private System.Windows.Forms.TextBox txtMrp;
        private System.Windows.Forms.Label lblMrp;
        private System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.TextBox txtDay;
        private System.Windows.Forms.TextBox txtMonth;
        private System.Windows.Forms.Label lblYyyy;
        private System.Windows.Forms.Label lblMM;
        private System.Windows.Forms.Label lblDd;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ErrorProvider epProductExchange;
        private System.Windows.Forms.ListView lvproduct;
        private System.Windows.Forms.ColumnHeader RMcode;
        private System.Windows.Forms.ColumnHeader RMTname;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.ColumnHeader columnHeader16;
        private System.Windows.Forms.ColumnHeader columnHeader17;
        private System.Windows.Forms.ColumnHeader columnHeader18;
        private System.Windows.Forms.ColumnHeader columnHeader19;
        private System.Windows.Forms.ColumnHeader columnHeader20;
        private System.Windows.Forms.Label lblProductcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmdsno;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPIcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmproductname;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmunit;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmmrp;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmexpirydate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmBatchNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmremove;
    }
}