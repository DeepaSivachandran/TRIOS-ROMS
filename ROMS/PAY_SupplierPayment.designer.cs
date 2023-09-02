namespace ROMS
{
    partial class PAY_SupplierPayment
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tspHeader = new System.Windows.Forms.ToolStripLabel();
            this.tsSupplierPayment = new System.Windows.Forms.ToolStrip();
            this.pnlinward = new System.Windows.Forms.Panel();
            this.lblRupee = new System.Windows.Forms.Label();
            this.lblGrandTotal = new System.Windows.Forms.Label();
            this.cmbPaymentmode = new System.Windows.Forms.ComboBox();
            this.txtDPaymentMode = new System.Windows.Forms.TextBox();
            this.cmbBankName = new System.Windows.Forms.ComboBox();
            this.txtChequeNo = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.txtChequeDate = new System.Windows.Forms.TextBox();
            this.txtDChequeNo = new System.Windows.Forms.TextBox();
            this.txtDBankName = new System.Windows.Forms.TextBox();
            this.DGV_inward = new System.Windows.Forms.DataGridView();
            this.lvSupplier = new System.Windows.Forms.ListView();
            this.cbch = new System.Windows.Forms.CheckBox();
            this.grbSalesManDetails = new System.Windows.Forms.GroupBox();
            this.grbSupplierDetails = new System.Windows.Forms.GroupBox();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.lblnarration = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.grbgodown = new System.Windows.Forms.GroupBox();
            this.cmbConcern = new System.Windows.Forms.ComboBox();
            this.txtTransactionno = new System.Windows.Forms.TextBox();
            this.lblTransactionNo = new System.Windows.Forms.Label();
            this.lblConcern = new System.Windows.Forms.Label();
            this.dpDate = new System.Windows.Forms.DateTimePicker();
            this.txtsuppliername = new System.Windows.Forms.TextBox();
            this.lblSupplier = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblEdit = new System.Windows.Forms.Label();
            this.clmch = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clmdsno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmVoucherDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmvoucherno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmInvoiceDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmInvoiceNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmenteredBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmApprovedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmBillAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tsSupplierPayment.SuspendLayout();
            this.pnlinward.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_inward)).BeginInit();
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
            this.tspHeader.Size = new System.Drawing.Size(120, 22);
            this.tspHeader.Text = "Supplier Payment";
            // 
            // tsSupplierPayment
            // 
            this.tsSupplierPayment.BackColor = System.Drawing.Color.White;
            this.tsSupplierPayment.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsSupplierPayment.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsSupplierPayment.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspHeader});
            this.tsSupplierPayment.Location = new System.Drawing.Point(0, 0);
            this.tsSupplierPayment.Name = "tsSupplierPayment";
            this.tsSupplierPayment.Size = new System.Drawing.Size(1354, 25);
            this.tsSupplierPayment.TabIndex = 35;
            this.tsSupplierPayment.Text = "Supplier Payment";
            // 
            // pnlinward
            // 
            this.pnlinward.BackColor = System.Drawing.Color.White;
            this.pnlinward.Controls.Add(this.lblRupee);
            this.pnlinward.Controls.Add(this.lblGrandTotal);
            this.pnlinward.Controls.Add(this.cmbPaymentmode);
            this.pnlinward.Controls.Add(this.txtDPaymentMode);
            this.pnlinward.Controls.Add(this.cmbBankName);
            this.pnlinward.Controls.Add(this.txtChequeNo);
            this.pnlinward.Controls.Add(this.dateTimePicker1);
            this.pnlinward.Controls.Add(this.txtChequeDate);
            this.pnlinward.Controls.Add(this.txtDChequeNo);
            this.pnlinward.Controls.Add(this.txtDBankName);
            this.pnlinward.Controls.Add(this.DGV_inward);
            this.pnlinward.Controls.Add(this.lvSupplier);
            this.pnlinward.Controls.Add(this.cbch);
            this.pnlinward.Controls.Add(this.grbSalesManDetails);
            this.pnlinward.Controls.Add(this.grbSupplierDetails);
            this.pnlinward.Controls.Add(this.txtRemark);
            this.pnlinward.Controls.Add(this.lblnarration);
            this.pnlinward.Controls.Add(this.btnSave);
            this.pnlinward.Controls.Add(this.btnClose);
            this.pnlinward.Controls.Add(this.grbgodown);
            this.pnlinward.Location = new System.Drawing.Point(2, 37);
            this.pnlinward.Name = "pnlinward";
            this.pnlinward.Size = new System.Drawing.Size(1354, 637);
            this.pnlinward.TabIndex = 36;
            // 
            // lblRupee
            // 
            this.lblRupee.AutoSize = true;
            this.lblRupee.Font = new System.Drawing.Font("Rupee Foradian", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRupee.Location = new System.Drawing.Point(1233, 538);
            this.lblRupee.Name = "lblRupee";
            this.lblRupee.Size = new System.Drawing.Size(23, 28);
            this.lblRupee.TabIndex = 1111174;
            this.lblRupee.Text = "₹";
            // 
            // lblGrandTotal
            // 
            this.lblGrandTotal.AutoSize = true;
            this.lblGrandTotal.Font = new System.Drawing.Font("Oswald Regular", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGrandTotal.ForeColor = System.Drawing.Color.Black;
            this.lblGrandTotal.Location = new System.Drawing.Point(1251, 528);
            this.lblGrandTotal.Name = "lblGrandTotal";
            this.lblGrandTotal.Size = new System.Drawing.Size(92, 40);
            this.lblGrandTotal.TabIndex = 1111173;
            this.lblGrandTotal.Text = "12500";
            // 
            // cmbPaymentmode
            // 
            this.cmbPaymentmode.FormattingEnabled = true;
            this.cmbPaymentmode.Items.AddRange(new object[] {
            "Cash",
            "Cheque"});
            this.cmbPaymentmode.Location = new System.Drawing.Point(600, 522);
            this.cmbPaymentmode.Name = "cmbPaymentmode";
            this.cmbPaymentmode.Size = new System.Drawing.Size(150, 27);
            this.cmbPaymentmode.TabIndex = 1111172;
            // 
            // txtDPaymentMode
            // 
            this.txtDPaymentMode.BackColor = System.Drawing.SystemColors.Control;
            this.txtDPaymentMode.Enabled = false;
            this.txtDPaymentMode.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtDPaymentMode.Location = new System.Drawing.Point(461, 522);
            this.txtDPaymentMode.Name = "txtDPaymentMode";
            this.txtDPaymentMode.ReadOnly = true;
            this.txtDPaymentMode.Size = new System.Drawing.Size(139, 27);
            this.txtDPaymentMode.TabIndex = 1111171;
            this.txtDPaymentMode.TabStop = false;
            this.txtDPaymentMode.Text = "Payment Mode";
            // 
            // cmbBankName
            // 
            this.cmbBankName.FormattingEnabled = true;
            this.cmbBankName.Location = new System.Drawing.Point(600, 603);
            this.cmbBankName.Name = "cmbBankName";
            this.cmbBankName.Size = new System.Drawing.Size(150, 27);
            this.cmbBankName.TabIndex = 1111170;
            // 
            // txtChequeNo
            // 
            this.txtChequeNo.Location = new System.Drawing.Point(600, 576);
            this.txtChequeNo.Name = "txtChequeNo";
            this.txtChequeNo.Size = new System.Drawing.Size(150, 27);
            this.txtChequeNo.TabIndex = 1111169;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(600, 549);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(150, 27);
            this.dateTimePicker1.TabIndex = 1111168;
            // 
            // txtChequeDate
            // 
            this.txtChequeDate.BackColor = System.Drawing.SystemColors.Control;
            this.txtChequeDate.Enabled = false;
            this.txtChequeDate.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtChequeDate.Location = new System.Drawing.Point(461, 549);
            this.txtChequeDate.Name = "txtChequeDate";
            this.txtChequeDate.ReadOnly = true;
            this.txtChequeDate.Size = new System.Drawing.Size(139, 27);
            this.txtChequeDate.TabIndex = 1111167;
            this.txtChequeDate.TabStop = false;
            this.txtChequeDate.Text = "Cheque Date";
            // 
            // txtDChequeNo
            // 
            this.txtDChequeNo.BackColor = System.Drawing.SystemColors.Control;
            this.txtDChequeNo.Enabled = false;
            this.txtDChequeNo.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtDChequeNo.Location = new System.Drawing.Point(461, 576);
            this.txtDChequeNo.Name = "txtDChequeNo";
            this.txtDChequeNo.ReadOnly = true;
            this.txtDChequeNo.Size = new System.Drawing.Size(139, 27);
            this.txtDChequeNo.TabIndex = 1111166;
            this.txtDChequeNo.TabStop = false;
            this.txtDChequeNo.Text = "Cheque No";
            // 
            // txtDBankName
            // 
            this.txtDBankName.BackColor = System.Drawing.SystemColors.Control;
            this.txtDBankName.Enabled = false;
            this.txtDBankName.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtDBankName.Location = new System.Drawing.Point(461, 603);
            this.txtDBankName.Name = "txtDBankName";
            this.txtDBankName.ReadOnly = true;
            this.txtDBankName.Size = new System.Drawing.Size(139, 27);
            this.txtDBankName.TabIndex = 1111165;
            this.txtDBankName.TabStop = false;
            this.txtDBankName.Text = "Bank Name";
            // 
            // DGV_inward
            // 
            this.DGV_inward.AllowUserToAddRows = false;
            this.DGV_inward.AllowUserToDeleteRows = false;
            this.DGV_inward.AllowUserToResizeRows = false;
            this.DGV_inward.BackgroundColor = System.Drawing.Color.White;
            this.DGV_inward.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(242)))), ((int)(((byte)(213)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_inward.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.DGV_inward.ColumnHeadersHeight = 30;
            this.DGV_inward.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGV_inward.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmch,
            this.clmdsno,
            this.clmVoucherDate,
            this.clmvoucherno,
            this.clmInvoiceDate,
            this.clmInvoiceNo,
            this.clmenteredBy,
            this.clmApprovedBy,
            this.clmBillAmount,
            this.clmAmount,
            this.Column1,
            this.Column3,
            this.Column2});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV_inward.DefaultCellStyle = dataGridViewCellStyle8;
            this.DGV_inward.EnableHeadersVisualStyles = false;
            this.DGV_inward.GridColor = System.Drawing.Color.White;
            this.DGV_inward.Location = new System.Drawing.Point(10, 109);
            this.DGV_inward.Name = "DGV_inward";
            this.DGV_inward.RowHeadersVisible = false;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.White;
            this.DGV_inward.RowsDefaultCellStyle = dataGridViewCellStyle9;
            this.DGV_inward.RowTemplate.Height = 25;
            this.DGV_inward.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DGV_inward.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DGV_inward.ShowRowErrors = false;
            this.DGV_inward.Size = new System.Drawing.Size(1335, 399);
            this.DGV_inward.TabIndex = 958809;
            // 
            // lvSupplier
            // 
            this.lvSupplier.HideSelection = false;
            this.lvSupplier.Location = new System.Drawing.Point(426, 68);
            this.lvSupplier.Name = "lvSupplier";
            this.lvSupplier.Size = new System.Drawing.Size(311, 66);
            this.lvSupplier.TabIndex = 1111162;
            this.lvSupplier.UseCompatibleStateImageBehavior = false;
            this.lvSupplier.Visible = false;
            // 
            // cbch
            // 
            this.cbch.AutoSize = true;
            this.cbch.Location = new System.Drawing.Point(27, 120);
            this.cbch.Name = "cbch";
            this.cbch.Size = new System.Drawing.Size(15, 14);
            this.cbch.TabIndex = 958826;
            this.cbch.UseVisualStyleBackColor = true;
            // 
            // grbSalesManDetails
            // 
            this.grbSalesManDetails.Location = new System.Drawing.Point(1045, 6);
            this.grbSalesManDetails.Name = "grbSalesManDetails";
            this.grbSalesManDetails.Size = new System.Drawing.Size(300, 97);
            this.grbSalesManDetails.TabIndex = 958815;
            this.grbSalesManDetails.TabStop = false;
            this.grbSalesManDetails.Text = "Salesman Details";
            // 
            // grbSupplierDetails
            // 
            this.grbSupplierDetails.Location = new System.Drawing.Point(736, 6);
            this.grbSupplierDetails.Name = "grbSupplierDetails";
            this.grbSupplierDetails.Size = new System.Drawing.Size(300, 97);
            this.grbSupplierDetails.TabIndex = 958813;
            this.grbSupplierDetails.TabStop = false;
            this.grbSupplierDetails.Text = "Supplier Details";
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(69, 522);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(386, 97);
            this.txtRemark.TabIndex = 958807;
            // 
            // lblnarration
            // 
            this.lblnarration.AutoSize = true;
            this.lblnarration.Location = new System.Drawing.Point(10, 522);
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
            this.btnClose.Location = new System.Drawing.Point(1270, 592);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 29);
            this.btnClose.TabIndex = 958811;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // grbgodown
            // 
            this.grbgodown.Controls.Add(this.cmbConcern);
            this.grbgodown.Controls.Add(this.txtTransactionno);
            this.grbgodown.Controls.Add(this.lblTransactionNo);
            this.grbgodown.Controls.Add(this.lblConcern);
            this.grbgodown.Controls.Add(this.dpDate);
            this.grbgodown.Controls.Add(this.txtsuppliername);
            this.grbgodown.Controls.Add(this.lblSupplier);
            this.grbgodown.Controls.Add(this.lblDate);
            this.grbgodown.Location = new System.Drawing.Point(10, 6);
            this.grbgodown.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbgodown.Name = "grbgodown";
            this.grbgodown.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbgodown.Size = new System.Drawing.Size(717, 70);
            this.grbgodown.TabIndex = 958805;
            this.grbgodown.TabStop = false;
            // 
            // cmbConcern
            // 
            this.cmbConcern.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbConcern.FormattingEnabled = true;
            this.cmbConcern.Location = new System.Drawing.Point(128, 36);
            this.cmbConcern.Name = "cmbConcern";
            this.cmbConcern.Size = new System.Drawing.Size(108, 27);
            this.cmbConcern.TabIndex = 92;
            // 
            // txtTransactionno
            // 
            this.txtTransactionno.Enabled = false;
            this.txtTransactionno.Location = new System.Drawing.Point(243, 36);
            this.txtTransactionno.Name = "txtTransactionno";
            this.txtTransactionno.ReadOnly = true;
            this.txtTransactionno.Size = new System.Drawing.Size(166, 27);
            this.txtTransactionno.TabIndex = 91;
            // 
            // lblTransactionNo
            // 
            this.lblTransactionNo.AutoSize = true;
            this.lblTransactionNo.Location = new System.Drawing.Point(243, 14);
            this.lblTransactionNo.Name = "lblTransactionNo";
            this.lblTransactionNo.Size = new System.Drawing.Size(92, 20);
            this.lblTransactionNo.TabIndex = 90;
            this.lblTransactionNo.Text = "Transaction No.";
            // 
            // lblConcern
            // 
            this.lblConcern.AutoSize = true;
            this.lblConcern.Location = new System.Drawing.Point(128, 14);
            this.lblConcern.Name = "lblConcern";
            this.lblConcern.Size = new System.Drawing.Size(54, 20);
            this.lblConcern.TabIndex = 87;
            this.lblConcern.Text = "Concern";
            // 
            // dpDate
            // 
            this.dpDate.CustomFormat = "dd/MM/yyyy";
            this.dpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpDate.Location = new System.Drawing.Point(13, 36);
            this.dpDate.Name = "dpDate";
            this.dpDate.Size = new System.Drawing.Size(108, 27);
            this.dpDate.TabIndex = 86;
            // 
            // txtsuppliername
            // 
            this.txtsuppliername.Location = new System.Drawing.Point(416, 36);
            this.txtsuppliername.Name = "txtsuppliername";
            this.txtsuppliername.Size = new System.Drawing.Size(288, 27);
            this.txtsuppliername.TabIndex = 83;
            this.txtsuppliername.TextChanged += new System.EventHandler(this.Txtsuppliername_TextChanged);
            // 
            // lblSupplier
            // 
            this.lblSupplier.AutoSize = true;
            this.lblSupplier.Location = new System.Drawing.Point(416, 14);
            this.lblSupplier.Name = "lblSupplier";
            this.lblSupplier.Size = new System.Drawing.Size(57, 20);
            this.lblSupplier.TabIndex = 27;
            this.lblSupplier.Text = "Supplier ";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(13, 14);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(34, 20);
            this.lblDate.TabIndex = 70;
            this.lblDate.Text = "Date";
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
            // clmch
            // 
            this.clmch.HeaderText = "";
            this.clmch.Name = "clmch";
            this.clmch.Width = 50;
            // 
            // clmdsno
            // 
            this.clmdsno.HeaderText = "S.No.";
            this.clmdsno.Name = "clmdsno";
            this.clmdsno.Width = 50;
            // 
            // clmVoucherDate
            // 
            this.clmVoucherDate.HeaderText = "Voucher Date";
            this.clmVoucherDate.Name = "clmVoucherDate";
            // 
            // clmvoucherno
            // 
            this.clmvoucherno.HeaderText = "Voucher No.";
            this.clmvoucherno.Name = "clmvoucherno";
            // 
            // clmInvoiceDate
            // 
            this.clmInvoiceDate.HeaderText = "Invoice Date";
            this.clmInvoiceDate.Name = "clmInvoiceDate";
            // 
            // clmInvoiceNo
            // 
            this.clmInvoiceNo.HeaderText = "Invoice No";
            this.clmInvoiceNo.Name = "clmInvoiceNo";
            // 
            // clmenteredBy
            // 
            this.clmenteredBy.HeaderText = "Entered By";
            this.clmenteredBy.Name = "clmenteredBy";
            // 
            // clmApprovedBy
            // 
            this.clmApprovedBy.HeaderText = "Approved By";
            this.clmApprovedBy.Name = "clmApprovedBy";
            // 
            // clmBillAmount
            // 
            this.clmBillAmount.HeaderText = "Taxable Amount";
            this.clmBillAmount.Name = "clmBillAmount";
            // 
            // clmAmount
            // 
            this.clmAmount.HeaderText = "Tax Amount";
            this.clmAmount.Name = "clmAmount";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Invoice Amount";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Purchase Return Adjustment";
            this.Column3.Name = "Column3";
            this.Column3.Width = 200;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Pay Amount";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // PAY_SupplierPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(1354, 675);
            this.Controls.Add(this.lblEdit);
            this.Controls.Add(this.tsSupplierPayment);
            this.Controls.Add(this.pnlinward);
            this.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "PAY_SupplierPayment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Supplier Payment";
            this.Load += new System.EventHandler(this.INV_Inward_Load);
            this.tsSupplierPayment.ResumeLayout(false);
            this.tsSupplierPayment.PerformLayout();
            this.pnlinward.ResumeLayout(false);
            this.pnlinward.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_inward)).EndInit();
            this.grbgodown.ResumeLayout(false);
            this.grbgodown.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStripLabel tspHeader;
        private System.Windows.Forms.ToolStrip tsSupplierPayment;
        private System.Windows.Forms.Panel pnlinward;
        private System.Windows.Forms.TextBox txtsuppliername;
        private System.Windows.Forms.GroupBox grbSupplierDetails;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label lblnarration;
        public System.Windows.Forms.DataGridView DGV_inward;
        private System.Windows.Forms.GroupBox grbgodown;
        private System.Windows.Forms.Label lblSupplier;
        private System.Windows.Forms.Label lblEdit;
        public System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DateTimePicker dpDate;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.GroupBox grbSalesManDetails;
        private System.Windows.Forms.CheckBox cbch;
        private System.Windows.Forms.TextBox txtTransactionno;
        private System.Windows.Forms.Label lblTransactionNo;
        private System.Windows.Forms.Label lblConcern;
        private System.Windows.Forms.ComboBox cmbConcern;
        private System.Windows.Forms.ListView lvSupplier;
        private System.Windows.Forms.ComboBox cmbPaymentmode;
        private System.Windows.Forms.TextBox txtDPaymentMode;
        private System.Windows.Forms.ComboBox cmbBankName;
        private System.Windows.Forms.TextBox txtChequeNo;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox txtChequeDate;
        private System.Windows.Forms.TextBox txtDChequeNo;
        private System.Windows.Forms.TextBox txtDBankName;
        private System.Windows.Forms.Label lblRupee;
        private System.Windows.Forms.Label lblGrandTotal;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clmch;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmdsno;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmVoucherDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmvoucherno;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmInvoiceDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmInvoiceNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmenteredBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmApprovedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmBillAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    }
}