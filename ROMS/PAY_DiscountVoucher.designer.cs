namespace ROMS
{
    partial class PAY_DiscountVoucher
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PAY_DiscountVoucher));
            this.epDiscount = new System.Windows.Forms.ErrorProvider(this.components);
            this.grbDiscount = new System.Windows.Forms.GroupBox();
            this.LV_Supplier = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblReturn = new System.Windows.Forms.Label();
            this.lblSupplierOrderpolicy = new System.Windows.Forms.Label();
            this.lblsupplierpayment = new System.Windows.Forms.Label();
            this.lblsupplierScheduletype = new System.Windows.Forms.Label();
            this.lblsupplierGST = new System.Windows.Forms.Label();
            this.lblSupplierCity = new System.Windows.Forms.Label();
            this.lblSuppliername = new System.Windows.Forms.Label();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.grbInvoiceDetails = new System.Windows.Forms.GroupBox();
            this.grdInvoice = new System.Windows.Forms.DataGridView();
            this.clmcheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clmdsno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmvoucherno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmVoucherDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmInvoiceNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmInvoiceDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPURID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSTSID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblschedule = new System.Windows.Forms.Label();
            this.lblSupplierCode = new System.Windows.Forms.Label();
            this.lblDESupplier = new System.Windows.Forms.Label();
            this.txtSupplier = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtInvoiceamt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDiscNo = new System.Windows.Forms.TextBox();
            this.lblVoucDate = new System.Windows.Forms.Label();
            this.dpVoucDate = new System.Windows.Forms.DateTimePicker();
            this.cmbConcern = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.epDiscount)).BeginInit();
            this.grbDiscount.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.grbInvoiceDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdInvoice)).BeginInit();
            this.SuspendLayout();
            // 
            // epDiscount
            // 
            this.epDiscount.ContainerControl = this;
            // 
            // grbDiscount
            // 
            this.grbDiscount.Controls.Add(this.LV_Supplier);
            this.grbDiscount.Controls.Add(this.groupBox2);
            this.grbDiscount.Controls.Add(this.txtRemark);
            this.grbDiscount.Controls.Add(this.label2);
            this.grbDiscount.Controls.Add(this.grbInvoiceDetails);
            this.grbDiscount.Controls.Add(this.btnSave);
            this.grbDiscount.Controls.Add(this.lblschedule);
            this.grbDiscount.Controls.Add(this.lblSupplierCode);
            this.grbDiscount.Controls.Add(this.lblDESupplier);
            this.grbDiscount.Controls.Add(this.txtSupplier);
            this.grbDiscount.Controls.Add(this.label5);
            this.grbDiscount.Controls.Add(this.txtInvoiceamt);
            this.grbDiscount.Controls.Add(this.label1);
            this.grbDiscount.Controls.Add(this.txtDiscNo);
            this.grbDiscount.Controls.Add(this.lblVoucDate);
            this.grbDiscount.Controls.Add(this.dpVoucDate);
            this.grbDiscount.Controls.Add(this.cmbConcern);
            this.grbDiscount.Controls.Add(this.label10);
            this.grbDiscount.Controls.Add(this.textBox1);
            this.grbDiscount.Location = new System.Drawing.Point(10, -1);
            this.grbDiscount.Name = "grbDiscount";
            this.grbDiscount.Size = new System.Drawing.Size(899, 447);
            this.grbDiscount.TabIndex = 0;
            this.grbDiscount.TabStop = false;
            // 
            // LV_Supplier
            // 
            this.LV_Supplier.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader8,
            this.columnHeader9});
            this.LV_Supplier.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.LV_Supplier.HideSelection = false;
            this.LV_Supplier.Location = new System.Drawing.Point(319, 48);
            this.LV_Supplier.Name = "LV_Supplier";
            this.LV_Supplier.Size = new System.Drawing.Size(344, 93);
            this.LV_Supplier.TabIndex = 1111208;
            this.LV_Supplier.UseCompatibleStateImageBehavior = false;
            this.LV_Supplier.View = System.Windows.Forms.View.Details;
            this.LV_Supplier.Visible = false;
            this.LV_Supplier.DoubleClick += new System.EventHandler(this.LV_Supplier_DoubleClick);
            this.LV_Supplier.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LV_Supplier_KeyDown);
            // 
            // columnHeader5
            // 
            this.columnHeader5.Width = 180;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Width = 120;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Width = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblReturn);
            this.groupBox2.Controls.Add(this.lblSupplierOrderpolicy);
            this.groupBox2.Controls.Add(this.lblsupplierpayment);
            this.groupBox2.Controls.Add(this.lblsupplierScheduletype);
            this.groupBox2.Controls.Add(this.lblsupplierGST);
            this.groupBox2.Controls.Add(this.lblSupplierCity);
            this.groupBox2.Controls.Add(this.lblSuppliername);
            this.groupBox2.Font = new System.Drawing.Font("Oswald Regular", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(678, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(209, 123);
            this.groupBox2.TabIndex = 1111241;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Supplier Details";
            // 
            // lblReturn
            // 
            this.lblReturn.AutoSize = true;
            this.lblReturn.BackColor = System.Drawing.Color.White;
            this.lblReturn.Font = new System.Drawing.Font("Oswald Regular", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReturn.Location = new System.Drawing.Point(166, 88);
            this.lblReturn.Name = "lblReturn";
            this.lblReturn.Size = new System.Drawing.Size(37, 16);
            this.lblReturn.TabIndex = 1111207;
            this.lblReturn.Text = "Retrun";
            this.lblReturn.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblReturn.Visible = false;
            // 
            // lblSupplierOrderpolicy
            // 
            this.lblSupplierOrderpolicy.AutoSize = true;
            this.lblSupplierOrderpolicy.BackColor = System.Drawing.Color.White;
            this.lblSupplierOrderpolicy.Font = new System.Drawing.Font("Oswald Regular", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSupplierOrderpolicy.Location = new System.Drawing.Point(6, 98);
            this.lblSupplierOrderpolicy.Name = "lblSupplierOrderpolicy";
            this.lblSupplierOrderpolicy.Size = new System.Drawing.Size(61, 16);
            this.lblSupplierOrderpolicy.TabIndex = 1111206;
            this.lblSupplierOrderpolicy.Text = "Order policy";
            this.lblSupplierOrderpolicy.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblsupplierpayment
            // 
            this.lblsupplierpayment.AutoSize = true;
            this.lblsupplierpayment.BackColor = System.Drawing.Color.White;
            this.lblsupplierpayment.Font = new System.Drawing.Font("Oswald Regular", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsupplierpayment.Location = new System.Drawing.Point(6, 81);
            this.lblsupplierpayment.Name = "lblsupplierpayment";
            this.lblsupplierpayment.Size = new System.Drawing.Size(46, 16);
            this.lblsupplierpayment.TabIndex = 1111205;
            this.lblsupplierpayment.Text = "Payment";
            this.lblsupplierpayment.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblsupplierScheduletype
            // 
            this.lblsupplierScheduletype.AutoSize = true;
            this.lblsupplierScheduletype.BackColor = System.Drawing.Color.White;
            this.lblsupplierScheduletype.Font = new System.Drawing.Font("Oswald Regular", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsupplierScheduletype.Location = new System.Drawing.Point(6, 65);
            this.lblsupplierScheduletype.Name = "lblsupplierScheduletype";
            this.lblsupplierScheduletype.Size = new System.Drawing.Size(70, 16);
            this.lblsupplierScheduletype.TabIndex = 1111204;
            this.lblsupplierScheduletype.Text = "Schedule Type";
            this.lblsupplierScheduletype.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblsupplierGST
            // 
            this.lblsupplierGST.AutoSize = true;
            this.lblsupplierGST.BackColor = System.Drawing.Color.White;
            this.lblsupplierGST.Font = new System.Drawing.Font("Oswald Regular", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsupplierGST.Location = new System.Drawing.Point(6, 46);
            this.lblsupplierGST.Name = "lblsupplierGST";
            this.lblsupplierGST.Size = new System.Drawing.Size(21, 16);
            this.lblsupplierGST.TabIndex = 1111203;
            this.lblsupplierGST.Text = "gst";
            this.lblsupplierGST.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblSupplierCity
            // 
            this.lblSupplierCity.AutoSize = true;
            this.lblSupplierCity.BackColor = System.Drawing.Color.White;
            this.lblSupplierCity.Font = new System.Drawing.Font("Oswald Regular", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSupplierCity.Location = new System.Drawing.Point(6, 30);
            this.lblSupplierCity.Name = "lblSupplierCity";
            this.lblSupplierCity.Size = new System.Drawing.Size(25, 16);
            this.lblSupplierCity.TabIndex = 1111202;
            this.lblSupplierCity.Text = "city";
            this.lblSupplierCity.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblSuppliername
            // 
            this.lblSuppliername.AutoSize = true;
            this.lblSuppliername.BackColor = System.Drawing.Color.White;
            this.lblSuppliername.Font = new System.Drawing.Font("Oswald Regular", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSuppliername.Location = new System.Drawing.Point(6, 13);
            this.lblSuppliername.Name = "lblSuppliername";
            this.lblSuppliername.Size = new System.Drawing.Size(46, 17);
            this.lblSuppliername.TabIndex = 1111201;
            this.lblSuppliername.Text = "supplier";
            this.lblSuppliername.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtRemark
            // 
            this.txtRemark.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemark.Location = new System.Drawing.Point(68, 370);
            this.txtRemark.MaxLength = 100;
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(449, 58);
            this.txtRemark.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 370);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 20);
            this.label2.TabIndex = 1111216;
            this.label2.Text = "Remarks";
            // 
            // grbInvoiceDetails
            // 
            this.grbInvoiceDetails.Controls.Add(this.grdInvoice);
            this.grbInvoiceDetails.Location = new System.Drawing.Point(10, 133);
            this.grbInvoiceDetails.Name = "grbInvoiceDetails";
            this.grbInvoiceDetails.Size = new System.Drawing.Size(883, 231);
            this.grbInvoiceDetails.TabIndex = 1111215;
            this.grbInvoiceDetails.TabStop = false;
            this.grbInvoiceDetails.Text = "Outstanding Invoices";
            // 
            // grdInvoice
            // 
            this.grdInvoice.AllowUserToAddRows = false;
            this.grdInvoice.AllowUserToDeleteRows = false;
            this.grdInvoice.AllowUserToResizeRows = false;
            this.grdInvoice.BackgroundColor = System.Drawing.Color.White;
            this.grdInvoice.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(242)))), ((int)(((byte)(213)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdInvoice.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdInvoice.ColumnHeadersHeight = 30;
            this.grdInvoice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdInvoice.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmcheck,
            this.clmdsno,
            this.clmvoucherno,
            this.clmVoucherDate,
            this.clmInvoiceNo,
            this.clmInvoiceDate,
            this.clmAmount,
            this.clmStatus,
            this.clmPURID,
            this.clmSTSID});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdInvoice.DefaultCellStyle = dataGridViewCellStyle2;
            this.grdInvoice.EnableHeadersVisualStyles = false;
            this.grdInvoice.GridColor = System.Drawing.Color.White;
            this.grdInvoice.Location = new System.Drawing.Point(6, 27);
            this.grdInvoice.Name = "grdInvoice";
            this.grdInvoice.RowHeadersVisible = false;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.grdInvoice.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.grdInvoice.RowTemplate.Height = 25;
            this.grdInvoice.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.grdInvoice.ShowRowErrors = false;
            this.grdInvoice.Size = new System.Drawing.Size(871, 198);
            this.grdInvoice.TabIndex = 1111214;
            this.grdInvoice.CurrentCellDirtyStateChanged += new System.EventHandler(this.GrdInvoice_CurrentCellDirtyStateChanged);
            // 
            // clmcheck
            // 
            this.clmcheck.HeaderText = "";
            this.clmcheck.Name = "clmcheck";
            this.clmcheck.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmcheck.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.clmcheck.Width = 50;
            // 
            // clmdsno
            // 
            this.clmdsno.HeaderText = "S.No.";
            this.clmdsno.Name = "clmdsno";
            this.clmdsno.ReadOnly = true;
            this.clmdsno.Width = 50;
            // 
            // clmvoucherno
            // 
            this.clmvoucherno.HeaderText = "Voucher No.";
            this.clmvoucherno.Name = "clmvoucherno";
            this.clmvoucherno.ReadOnly = true;
            this.clmvoucherno.Width = 80;
            // 
            // clmVoucherDate
            // 
            this.clmVoucherDate.HeaderText = "Voucher Date";
            this.clmVoucherDate.Name = "clmVoucherDate";
            this.clmVoucherDate.ReadOnly = true;
            this.clmVoucherDate.Width = 90;
            // 
            // clmInvoiceNo
            // 
            this.clmInvoiceNo.HeaderText = "Invoice No.";
            this.clmInvoiceNo.Name = "clmInvoiceNo";
            this.clmInvoiceNo.ReadOnly = true;
            this.clmInvoiceNo.Width = 200;
            // 
            // clmInvoiceDate
            // 
            this.clmInvoiceDate.HeaderText = "Invoice Date";
            this.clmInvoiceDate.Name = "clmInvoiceDate";
            this.clmInvoiceDate.ReadOnly = true;
            this.clmInvoiceDate.Width = 85;
            // 
            // clmAmount
            // 
            this.clmAmount.HeaderText = "Invoice Amount";
            this.clmAmount.Name = "clmAmount";
            this.clmAmount.ReadOnly = true;
            // 
            // clmStatus
            // 
            this.clmStatus.HeaderText = "Status";
            this.clmStatus.Name = "clmStatus";
            this.clmStatus.ReadOnly = true;
            this.clmStatus.Width = 180;
            // 
            // clmPURID
            // 
            this.clmPURID.HeaderText = "ID";
            this.clmPURID.Name = "clmPURID";
            this.clmPURID.ReadOnly = true;
            this.clmPURID.Visible = false;
            this.clmPURID.Width = 10;
            // 
            // clmSTSID
            // 
            this.clmSTSID.HeaderText = "STSID";
            this.clmSTSID.Name = "clmSTSID";
            this.clmSTSID.ReadOnly = true;
            this.clmSTSID.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnSave.Image = global::ROMS.Properties.Resources.save;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(733, 412);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(79, 29);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // lblschedule
            // 
            this.lblschedule.AutoSize = true;
            this.lblschedule.Location = new System.Drawing.Point(501, 63);
            this.lblschedule.Name = "lblschedule";
            this.lblschedule.Size = new System.Drawing.Size(16, 20);
            this.lblschedule.TabIndex = 1111213;
            this.lblschedule.Text = "0";
            this.lblschedule.Visible = false;
            // 
            // lblSupplierCode
            // 
            this.lblSupplierCode.AutoSize = true;
            this.lblSupplierCode.Location = new System.Drawing.Point(479, 63);
            this.lblSupplierCode.Name = "lblSupplierCode";
            this.lblSupplierCode.Size = new System.Drawing.Size(16, 20);
            this.lblSupplierCode.TabIndex = 1111211;
            this.lblSupplierCode.Text = "0";
            this.lblSupplierCode.Visible = false;
            // 
            // lblDESupplier
            // 
            this.lblDESupplier.AutoSize = true;
            this.lblDESupplier.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDESupplier.Location = new System.Drawing.Point(211, 24);
            this.lblDESupplier.Name = "lblDESupplier";
            this.lblDESupplier.Size = new System.Drawing.Size(54, 20);
            this.lblDESupplier.TabIndex = 1111193;
            this.lblDESupplier.Text = "Supplier";
            // 
            // txtSupplier
            // 
            this.txtSupplier.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSupplier.Location = new System.Drawing.Point(319, 21);
            this.txtSupplier.MaxLength = 50;
            this.txtSupplier.Name = "txtSupplier";
            this.txtSupplier.Size = new System.Drawing.Size(344, 27);
            this.txtSupplier.TabIndex = 3;
            this.txtSupplier.TextChanged += new System.EventHandler(this.TxtSupplier_TextChanged);
            this.txtSupplier.Enter += new System.EventHandler(this.TxtSupplier_Enter);
            this.txtSupplier.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtSupplier_KeyDown);
            this.txtSupplier.Leave += new System.EventHandler(this.TxtSupplier_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(211, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 20);
            this.label5.TabIndex = 1111192;
            this.label5.Text = "Discount Amount";
            // 
            // txtInvoiceamt
            // 
            this.txtInvoiceamt.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInvoiceamt.Location = new System.Drawing.Point(340, 60);
            this.txtInvoiceamt.MaxLength = 10;
            this.txtInvoiceamt.Name = "txtInvoiceamt";
            this.txtInvoiceamt.Size = new System.Drawing.Size(125, 27);
            this.txtInvoiceamt.TabIndex = 4;
            this.txtInvoiceamt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtInvoiceamt.Enter += new System.EventHandler(this.TxtInvoiceamt_Enter);
            this.txtInvoiceamt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtInvoiceamt_KeyDown);
            this.txtInvoiceamt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtInvoiceamt_KeyPress);
            this.txtInvoiceamt.Leave += new System.EventHandler(this.TxtInvoiceamt_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 20);
            this.label1.TabIndex = 1111185;
            this.label1.Text = "Voucher No.";
            // 
            // txtDiscNo
            // 
            this.txtDiscNo.Enabled = false;
            this.txtDiscNo.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiscNo.Location = new System.Drawing.Point(94, 60);
            this.txtDiscNo.MaxLength = 50;
            this.txtDiscNo.Name = "txtDiscNo";
            this.txtDiscNo.ReadOnly = true;
            this.txtDiscNo.Size = new System.Drawing.Size(111, 27);
            this.txtDiscNo.TabIndex = 1;
            // 
            // lblVoucDate
            // 
            this.lblVoucDate.AutoSize = true;
            this.lblVoucDate.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVoucDate.Location = new System.Drawing.Point(6, 103);
            this.lblVoucDate.Name = "lblVoucDate";
            this.lblVoucDate.Size = new System.Drawing.Size(82, 20);
            this.lblVoucDate.TabIndex = 1111183;
            this.lblVoucDate.Text = "Voucher Date";
            // 
            // dpVoucDate
            // 
            this.dpVoucDate.CustomFormat = "dd/MM/yyyy";
            this.dpVoucDate.Enabled = false;
            this.dpVoucDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpVoucDate.Location = new System.Drawing.Point(94, 99);
            this.dpVoucDate.Name = "dpVoucDate";
            this.dpVoucDate.Size = new System.Drawing.Size(111, 28);
            this.dpVoucDate.TabIndex = 2;
            this.dpVoucDate.ValueChanged += new System.EventHandler(this.DpVoucDate_ValueChanged);
            this.dpVoucDate.Enter += new System.EventHandler(this.DpVoucDate_Enter);
            this.dpVoucDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DpVoucDate_KeyDown);
            this.dpVoucDate.Leave += new System.EventHandler(this.DpVoucDate_Leave);
            // 
            // cmbConcern
            // 
            this.cmbConcern.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbConcern.FormattingEnabled = true;
            this.cmbConcern.Location = new System.Drawing.Point(94, 21);
            this.cmbConcern.Name = "cmbConcern";
            this.cmbConcern.Size = new System.Drawing.Size(111, 27);
            this.cmbConcern.TabIndex = 0;
            this.cmbConcern.SelectedIndexChanged += new System.EventHandler(this.CmbConcern_SelectedIndexChanged);
            this.cmbConcern.Enter += new System.EventHandler(this.CmbConcern_Enter);
            this.cmbConcern.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbConcern_KeyDown);
            this.cmbConcern.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbConcern_KeyPress);
            this.cmbConcern.Leave += new System.EventHandler(this.CmbConcern_Leave);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(6, 24);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 20);
            this.label10.TabIndex = 1111182;
            this.label10.Text = "Concern";
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Oswald Regular", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(319, 60);
            this.textBox1.MaxLength = 50;
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(21, 27);
            this.textBox1.TabIndex = 1111233;
            this.textBox1.Text = "₹";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnClose.Image = global::ROMS.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(828, 411);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 29);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // PAY_DiscountVoucher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(921, 456);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.grbDiscount);
            this.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PAY_DiscountVoucher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Discount Voucher";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PAY_Discount_FormClosing);
            this.Load += new System.EventHandler(this.PAY_DiscountVoucher_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PAY_DiscountVoucher_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.epDiscount)).EndInit();
            this.grbDiscount.ResumeLayout(false);
            this.grbDiscount.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.grbInvoiceDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdInvoice)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ErrorProvider epDiscount;
        private System.Windows.Forms.GroupBox grbDiscount;
        private System.Windows.Forms.Label lblDESupplier;
        private System.Windows.Forms.TextBox txtSupplier;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtInvoiceamt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDiscNo;
        private System.Windows.Forms.Label lblVoucDate;
        private System.Windows.Forms.DateTimePicker dpVoucDate;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnClose;
        public System.Windows.Forms.Button btnSave;
        public System.Windows.Forms.ListView LV_Supplier;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        public System.Windows.Forms.Label lblschedule;
        public System.Windows.Forms.ComboBox cmbConcern;
        public System.Windows.Forms.Label lblSupplierCode;
        public System.Windows.Forms.DataGridView grdInvoice;
        private System.Windows.Forms.GroupBox grbInvoiceDetails;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblReturn;
        private System.Windows.Forms.Label lblSupplierOrderpolicy;
        private System.Windows.Forms.Label lblsupplierpayment;
        private System.Windows.Forms.Label lblsupplierScheduletype;
        private System.Windows.Forms.Label lblsupplierGST;
        private System.Windows.Forms.Label lblSupplierCity;
        private System.Windows.Forms.Label lblSuppliername;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clmcheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmdsno;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmvoucherno;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmVoucherDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmInvoiceNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmInvoiceDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPURID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSTSID;
    }
}