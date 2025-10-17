namespace ROMS
{
    partial class REPORT_CP_Supplier
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(REPORT_CP_Supplier));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tsSupplierReport = new System.Windows.Forms.ToolStrip();
            this.tsbPrintFormat = new System.Windows.Forms.ToolStripButton();
            this.tsbFormat = new System.Windows.Forms.ToolStripButton();
            this.tsLabelPlaceholder = new System.Windows.Forms.ToolStripLabel();
            this.pnlReportStockLocation = new System.Windows.Forms.Panel();
            this.DGV_FilterCity = new System.Windows.Forms.DataGridView();
            this.lvCity = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grpfilter = new System.Windows.Forms.GroupBox();
            this.lblcityid = new System.Windows.Forms.Label();
            this.cmbSupplierType = new System.Windows.Forms.ComboBox();
            this.cmbReturnPolicy = new System.Windows.Forms.ComboBox();
            this.cmbPaymentTerm = new System.Windows.Forms.ComboBox();
            this.cmbOrderType = new System.Windows.Forms.ComboBox();
            this.lblReturnPolicy = new System.Windows.Forms.Label();
            this.lblOrderType = new System.Windows.Forms.Label();
            this.lblPaymentTerm = new System.Windows.Forms.Label();
            this.lblSupplierType = new System.Windows.Forms.Label();
            this.lblCity = new System.Windows.Forms.Label();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.cmbState = new System.Windows.Forms.ComboBox();
            this.lblState = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnListPrint = new System.Windows.Forms.Button();
            this.cmbReportType = new System.Windows.Forms.ComboBox();
            this.lblReportType = new System.Windows.Forms.Label();
            this.lblNoRecordsFound = new System.Windows.Forms.Label();
            this.picLoader = new System.Windows.Forms.PictureBox();
            this.RPTViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.dynamicLabelControl = new ROMS.DynamicToolStripLabelControl();
            this.btnTelegram = new System.Windows.Forms.Button(); 
            this.tsSupplierReport.SuspendLayout();
            this.pnlReportStockLocation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_FilterCity)).BeginInit();
            this.grpfilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).BeginInit();
            this.SuspendLayout();
            // 
            // tsSupplierReport
            // 
            this.tsSupplierReport.BackColor = System.Drawing.Color.White;
            this.tsSupplierReport.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsSupplierReport.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsSupplierReport.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsSupplierReport.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbPrintFormat,
            this.tsbFormat,
            this.tsLabelPlaceholder});
            this.tsSupplierReport.Location = new System.Drawing.Point(0, 0);
            this.tsSupplierReport.Name = "tsSupplierReport";
            this.tsSupplierReport.Size = new System.Drawing.Size(1354, 27);
            this.tsSupplierReport.TabIndex = 35;
            this.tsSupplierReport.Text = "Supplier Report";
            // 
            // tsbPrintFormat
            // 
            this.tsbPrintFormat.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbPrintFormat.BackColor = System.Drawing.Color.Green;
            this.tsbPrintFormat.ForeColor = System.Drawing.Color.White;
            this.tsbPrintFormat.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbPrintFormat.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPrintFormat.Margin = new System.Windows.Forms.Padding(-5, 1, 30, 2);
            this.tsbPrintFormat.Name = "tsbPrintFormat";
            this.tsbPrintFormat.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tsbPrintFormat.Size = new System.Drawing.Size(74, 24);
            this.tsbPrintFormat.Text = "A4-Portrait";
            this.tsbPrintFormat.ToolTipText = "A4-Portrait";
            // 
            // tsbFormat
            // 
            this.tsbFormat.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbFormat.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbFormat.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFormat.Margin = new System.Windows.Forms.Padding(-5, 1, 30, 2);
            this.tsbFormat.Name = "tsbFormat";
            this.tsbFormat.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tsbFormat.Size = new System.Drawing.Size(90, 24);
            this.tsbFormat.Text = "Print Format : ";
            this.tsbFormat.ToolTipText = "Print Format";
            // 
            // tsLabelPlaceholder
            // 
            this.tsLabelPlaceholder.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsLabelPlaceholder.Image = ((System.Drawing.Image)(resources.GetObject("tsLabelPlaceholder.Image")));
            this.tsLabelPlaceholder.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsLabelPlaceholder.Margin = new System.Windows.Forms.Padding(15, 1, 0, 2);
            this.tsLabelPlaceholder.Name = "tsLabelPlaceholder";
            this.tsLabelPlaceholder.Size = new System.Drawing.Size(58, 24);
            this.tsLabelPlaceholder.Text = "Levels";
            // 
            // pnlReportStockLocation
            // 
            this.pnlReportStockLocation.BackColor = System.Drawing.Color.White;
            this.pnlReportStockLocation.Controls.Add(this.DGV_FilterCity);
            this.pnlReportStockLocation.Controls.Add(this.lvCity);
            this.pnlReportStockLocation.Controls.Add(this.grpfilter);
            this.pnlReportStockLocation.Controls.Add(this.lblNoRecordsFound);
            this.pnlReportStockLocation.Controls.Add(this.picLoader);
            this.pnlReportStockLocation.Controls.Add(this.RPTViewer);
            this.pnlReportStockLocation.Location = new System.Drawing.Point(0, 29);
            this.pnlReportStockLocation.Name = "pnlReportStockLocation";
            this.pnlReportStockLocation.Size = new System.Drawing.Size(1354, 643);
            this.pnlReportStockLocation.TabIndex = 958788;
            // 
            // DGV_FilterCity
            // 
            this.DGV_FilterCity.AllowUserToAddRows = false;
            this.DGV_FilterCity.AllowUserToDeleteRows = false;
            this.DGV_FilterCity.AllowUserToResizeColumns = false;
            this.DGV_FilterCity.AllowUserToResizeRows = false;
            this.DGV_FilterCity.BackgroundColor = System.Drawing.Color.White;
            this.DGV_FilterCity.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.Chocolate;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.Chocolate;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_FilterCity.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.DGV_FilterCity.ColumnHeadersHeight = 30;
            this.DGV_FilterCity.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV_FilterCity.DefaultCellStyle = dataGridViewCellStyle8;
            this.DGV_FilterCity.EnableHeadersVisualStyles = false;
            this.DGV_FilterCity.GridColor = System.Drawing.Color.White;
            this.DGV_FilterCity.Location = new System.Drawing.Point(433, 71);
            this.DGV_FilterCity.Name = "DGV_FilterCity";
            this.DGV_FilterCity.ReadOnly = true;
            this.DGV_FilterCity.RowHeadersVisible = false;
            this.DGV_FilterCity.RowHeadersWidth = 51;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.DGV_FilterCity.RowsDefaultCellStyle = dataGridViewCellStyle9;
            this.DGV_FilterCity.RowTemplate.Height = 25;
            this.DGV_FilterCity.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV_FilterCity.Size = new System.Drawing.Size(211, 226);
            this.DGV_FilterCity.TabIndex = 111111167;
            this.DGV_FilterCity.Visible = false;
            this.DGV_FilterCity.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_FilterCity_CellDoubleClick);
            this.DGV_FilterCity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DGV_FilterCity_KeyDown);
            // 
            // lvCity
            // 
            this.lvCity.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvCity.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvCity.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvCity.HideSelection = false;
            this.lvCity.Location = new System.Drawing.Point(433, 71);
            this.lvCity.Name = "lvCity";
            this.lvCity.Size = new System.Drawing.Size(306, 134);
            this.lvCity.TabIndex = 1111229;
            this.lvCity.UseCompatibleStateImageBehavior = false;
            this.lvCity.View = System.Windows.Forms.View.Details;
            this.lvCity.Visible = false;
            this.lvCity.DoubleClick += new System.EventHandler(this.LvCity_DoubleClick);
            this.lvCity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LvCity_KeyDown);
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
            // grpfilter
            // 
            this.grpfilter.Controls.Add(this.btnTelegram);
            this.grpfilter.Controls.Add(this.lblcityid);
            this.grpfilter.Controls.Add(this.cmbSupplierType);
            this.grpfilter.Controls.Add(this.cmbReturnPolicy);
            this.grpfilter.Controls.Add(this.cmbPaymentTerm);
            this.grpfilter.Controls.Add(this.cmbOrderType);
            this.grpfilter.Controls.Add(this.lblReturnPolicy);
            this.grpfilter.Controls.Add(this.lblOrderType);
            this.grpfilter.Controls.Add(this.lblPaymentTerm);
            this.grpfilter.Controls.Add(this.lblSupplierType);
            this.grpfilter.Controls.Add(this.lblCity);
            this.grpfilter.Controls.Add(this.txtCity);
            this.grpfilter.Controls.Add(this.cmbState);
            this.grpfilter.Controls.Add(this.lblState);
            this.grpfilter.Controls.Add(this.cmbStatus);
            this.grpfilter.Controls.Add(this.lblStatus);
            this.grpfilter.Controls.Add(this.btnListPrint);
            this.grpfilter.Controls.Add(this.cmbReportType);
            this.grpfilter.Controls.Add(this.lblReportType);
            this.grpfilter.Location = new System.Drawing.Point(3, 2);
            this.grpfilter.Name = "grpfilter";
            this.grpfilter.Size = new System.Drawing.Size(1348, 82);
            this.grpfilter.TabIndex = 0;
            this.grpfilter.TabStop = false;
            this.grpfilter.Text = "Filter By";
            // 
            // lblcityid
            // 
            this.lblcityid.AutoSize = true;
            this.lblcityid.Location = new System.Drawing.Point(500, 19);
            this.lblcityid.Name = "lblcityid";
            this.lblcityid.Size = new System.Drawing.Size(0, 20);
            this.lblcityid.TabIndex = 1111191;
            this.lblcityid.Visible = false;
            // 
            // cmbSupplierType
            // 
            this.cmbSupplierType.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSupplierType.FormattingEnabled = true;
            this.cmbSupplierType.Items.AddRange(new object[] {
            "Registered",
            "Composite",
            "URD"});
            this.cmbSupplierType.Location = new System.Drawing.Point(622, 42);
            this.cmbSupplierType.Name = "cmbSupplierType";
            this.cmbSupplierType.Size = new System.Drawing.Size(136, 27);
            this.cmbSupplierType.TabIndex = 3;
            this.cmbSupplierType.Enter += new System.EventHandler(this.CmbSupplierType_Enter);
            this.cmbSupplierType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbSupplierType_KeyDown);
            this.cmbSupplierType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbSupplierType_KeyPress);
            this.cmbSupplierType.Leave += new System.EventHandler(this.CmbSupplierType_Leave);
            // 
            // cmbReturnPolicy
            // 
            this.cmbReturnPolicy.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbReturnPolicy.FormattingEnabled = true;
            this.cmbReturnPolicy.Location = new System.Drawing.Point(1057, 42);
            this.cmbReturnPolicy.Name = "cmbReturnPolicy";
            this.cmbReturnPolicy.Size = new System.Drawing.Size(85, 27);
            this.cmbReturnPolicy.TabIndex = 6;
            this.cmbReturnPolicy.Enter += new System.EventHandler(this.CmbReturnPolicy_Enter);
            this.cmbReturnPolicy.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbReturnPolicy_KeyDown);
            this.cmbReturnPolicy.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbReturnPolicy_KeyPress);
            this.cmbReturnPolicy.Leave += new System.EventHandler(this.CmbReturnPolicy_Leave);
            // 
            // cmbPaymentTerm
            // 
            this.cmbPaymentTerm.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPaymentTerm.FormattingEnabled = true;
            this.cmbPaymentTerm.ItemHeight = 19;
            this.cmbPaymentTerm.Items.AddRange(new object[] {
            "Nett Amount",
            "Taxable Amount"});
            this.cmbPaymentTerm.Location = new System.Drawing.Point(764, 42);
            this.cmbPaymentTerm.Name = "cmbPaymentTerm";
            this.cmbPaymentTerm.Size = new System.Drawing.Size(149, 27);
            this.cmbPaymentTerm.TabIndex = 4;
            this.cmbPaymentTerm.Enter += new System.EventHandler(this.CmbPaymentTerm_Enter);
            this.cmbPaymentTerm.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbPaymentTerm_KeyDown);
            this.cmbPaymentTerm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbPaymentTerm_KeyPress);
            this.cmbPaymentTerm.Leave += new System.EventHandler(this.CmbPaymentTerm_Leave);
            // 
            // cmbOrderType
            // 
            this.cmbOrderType.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbOrderType.FormattingEnabled = true;
            this.cmbOrderType.Items.AddRange(new object[] {
            "Phone",
            "Visit",
            "Mobile App"});
            this.cmbOrderType.Location = new System.Drawing.Point(919, 42);
            this.cmbOrderType.Name = "cmbOrderType";
            this.cmbOrderType.Size = new System.Drawing.Size(132, 27);
            this.cmbOrderType.TabIndex = 5;
            this.cmbOrderType.Enter += new System.EventHandler(this.CmbOrderType_Enter);
            this.cmbOrderType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbOrderType_KeyDown);
            this.cmbOrderType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbOrderType_KeyPress);
            this.cmbOrderType.Leave += new System.EventHandler(this.CmbOrderType_Leave);
            // 
            // lblReturnPolicy
            // 
            this.lblReturnPolicy.AutoSize = true;
            this.lblReturnPolicy.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReturnPolicy.Location = new System.Drawing.Point(1057, 19);
            this.lblReturnPolicy.Name = "lblReturnPolicy";
            this.lblReturnPolicy.Size = new System.Drawing.Size(81, 20);
            this.lblReturnPolicy.TabIndex = 1111190;
            this.lblReturnPolicy.Text = "Return Policy";
            // 
            // lblOrderType
            // 
            this.lblOrderType.AutoSize = true;
            this.lblOrderType.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderType.Location = new System.Drawing.Point(919, 19);
            this.lblOrderType.Name = "lblOrderType";
            this.lblOrderType.Size = new System.Drawing.Size(68, 20);
            this.lblOrderType.TabIndex = 1111189;
            this.lblOrderType.Text = "Order Type";
            // 
            // lblPaymentTerm
            // 
            this.lblPaymentTerm.AutoSize = true;
            this.lblPaymentTerm.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaymentTerm.Location = new System.Drawing.Point(764, 19);
            this.lblPaymentTerm.Name = "lblPaymentTerm";
            this.lblPaymentTerm.Size = new System.Drawing.Size(86, 20);
            this.lblPaymentTerm.TabIndex = 1111188;
            this.lblPaymentTerm.Text = "Payment Term";
            // 
            // lblSupplierType
            // 
            this.lblSupplierType.AutoSize = true;
            this.lblSupplierType.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSupplierType.Location = new System.Drawing.Point(622, 19);
            this.lblSupplierType.Name = "lblSupplierType";
            this.lblSupplierType.Size = new System.Drawing.Size(82, 20);
            this.lblSupplierType.TabIndex = 1111187;
            this.lblSupplierType.Text = "Supplier Type";
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCity.Location = new System.Drawing.Point(430, 19);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(31, 20);
            this.lblCity.TabIndex = 1111186;
            this.lblCity.Text = "City";
            // 
            // txtCity
            // 
            this.txtCity.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtCity.Location = new System.Drawing.Point(430, 42);
            this.txtCity.MaxLength = 100;
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(186, 27);
            this.txtCity.TabIndex = 2;
            this.txtCity.TextChanged += new System.EventHandler(this.TxtCity_TextChanged);
            this.txtCity.Enter += new System.EventHandler(this.TxtCity_Enter);
            this.txtCity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtCity_KeyDown);
            this.txtCity.Leave += new System.EventHandler(this.TxtCity_Leave);
            // 
            // cmbState
            // 
            this.cmbState.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbState.FormattingEnabled = true;
            this.cmbState.Location = new System.Drawing.Point(238, 42);
            this.cmbState.Name = "cmbState";
            this.cmbState.Size = new System.Drawing.Size(186, 27);
            this.cmbState.TabIndex = 1;
            this.cmbState.Enter += new System.EventHandler(this.CmbState_Enter);
            this.cmbState.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbState_KeyDown);
            this.cmbState.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbState_KeyPress);
            this.cmbState.Leave += new System.EventHandler(this.CmbState_Leave);
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblState.Location = new System.Drawing.Point(238, 19);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(38, 20);
            this.lblState.TabIndex = 1111183;
            this.lblState.Text = "State";
            // 
            // cmbStatus
            // 
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(1148, 42);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(103, 27);
            this.cmbStatus.TabIndex = 7;
            this.cmbStatus.Enter += new System.EventHandler(this.CmbStatus_Enter);
            this.cmbStatus.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbStatus_KeyDown);
            this.cmbStatus.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbStatus_KeyPress);
            this.cmbStatus.Leave += new System.EventHandler(this.CmbStatus_Leave);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(1148, 19);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(45, 20);
            this.lblStatus.TabIndex = 1111182;
            this.lblStatus.Text = "Status";
            // 
            // btnListPrint
            // 
            this.btnListPrint.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListPrint.Image = global::ROMS.Properties.Resources.view;
            this.btnListPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnListPrint.Location = new System.Drawing.Point(1257, 41);
            this.btnListPrint.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnListPrint.Name = "btnListPrint";
            this.btnListPrint.Size = new System.Drawing.Size(33, 29);
            this.btnListPrint.TabIndex = 8;
            this.btnListPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnListPrint.UseVisualStyleBackColor = true;
            this.btnListPrint.Click += new System.EventHandler(this.BtnListPrint_Click);
            this.btnListPrint.Enter += new System.EventHandler(this.BtnListPrint_Enter);
            this.btnListPrint.Leave += new System.EventHandler(this.BtnListPrint_Leave);
            // 
            // cmbReportType
            // 
            this.cmbReportType.FormattingEnabled = true;
            this.cmbReportType.Location = new System.Drawing.Point(6, 42);
            this.cmbReportType.Name = "cmbReportType";
            this.cmbReportType.Size = new System.Drawing.Size(226, 27);
            this.cmbReportType.TabIndex = 0;
            this.cmbReportType.SelectedIndexChanged += new System.EventHandler(this.CmbReportType_SelectedIndexChanged);
            this.cmbReportType.Enter += new System.EventHandler(this.CmbReportType_Enter);
            this.cmbReportType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbReportType_KeyDown);
            this.cmbReportType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbReportType_KeyPress);
            this.cmbReportType.Leave += new System.EventHandler(this.CmbReportType_Leave);
            // 
            // lblReportType
            // 
            this.lblReportType.AutoSize = true;
            this.lblReportType.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReportType.Location = new System.Drawing.Point(6, 19);
            this.lblReportType.Name = "lblReportType";
            this.lblReportType.Size = new System.Drawing.Size(73, 20);
            this.lblReportType.TabIndex = 1111176;
            this.lblReportType.Text = "Report type";
            // 
            // lblNoRecordsFound
            // 
            this.lblNoRecordsFound.AutoSize = true;
            this.lblNoRecordsFound.BackColor = System.Drawing.Color.White;
            this.lblNoRecordsFound.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoRecordsFound.Location = new System.Drawing.Point(625, 356);
            this.lblNoRecordsFound.Name = "lblNoRecordsFound";
            this.lblNoRecordsFound.Size = new System.Drawing.Size(106, 20);
            this.lblNoRecordsFound.TabIndex = 958789;
            this.lblNoRecordsFound.Text = "No Records Found";
            this.lblNoRecordsFound.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // picLoader
            // 
            this.picLoader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picLoader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picLoader.ErrorImage = null;
            this.picLoader.Image = global::ROMS.Properties.Resources.Iphone_spinner_2;
            this.picLoader.InitialImage = null;
            this.picLoader.Location = new System.Drawing.Point(3, 90);
            this.picLoader.Name = "picLoader";
            this.picLoader.Size = new System.Drawing.Size(1351, 552);
            this.picLoader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picLoader.TabIndex = 958790;
            this.picLoader.TabStop = false;
            this.picLoader.Visible = false;
            // 
            // RPTViewer
            // 
            this.RPTViewer.ActiveViewIndex = -1;
            this.RPTViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RPTViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.RPTViewer.Location = new System.Drawing.Point(3, 90);
            this.RPTViewer.Name = "RPTViewer";
            this.RPTViewer.ReuseParameterValuesOnRefresh = true;
            this.RPTViewer.Size = new System.Drawing.Size(1348, 549);
            this.RPTViewer.TabIndex = 1111227;
            this.RPTViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.RPTViewer.Visible = false;
            // 
            // dynamicLabelControl
            // 
            this.dynamicLabelControl.PlaceholderLabel = null;
            // 
            // btnTelegram
            // 
            this.btnTelegram.Image = ((System.Drawing.Image)(resources.GetObject("btnTelegram.Image")));
            this.btnTelegram.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTelegram.Location = new System.Drawing.Point(1296, 41);
            this.btnTelegram.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnTelegram.Name = "btnTelegram";
            this.btnTelegram.Size = new System.Drawing.Size(35, 30);
            this.btnTelegram.TabIndex = 9;
            this.btnTelegram.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTelegram.UseVisualStyleBackColor = true;
            this.btnTelegram.Click += new System.EventHandler(this.btnTelegram_Click);
            this.btnTelegram.Enter += new System.EventHandler(this.btnTelegram_Enter);
            this.btnTelegram.Leave += new System.EventHandler(this.btnTelegram_Leave);
            // 
            // REPORT_CP_Supplier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(1354, 675);
            this.Controls.Add(this.pnlReportStockLocation);
            this.Controls.Add(this.tsSupplierReport);
            this.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "REPORT_CP_Supplier";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Supplier Report";
            this.Load += new System.EventHandler(this.REPORT_CP_Supplier_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.REPORT_CP_Supplier_KeyDown);
            this.tsSupplierReport.ResumeLayout(false);
            this.tsSupplierReport.PerformLayout();
            this.pnlReportStockLocation.ResumeLayout(false);
            this.pnlReportStockLocation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_FilterCity)).EndInit();
            this.grpfilter.ResumeLayout(false);
            this.grpfilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsSupplierReport;
        private System.Windows.Forms.Panel pnlReportStockLocation;
        private System.Windows.Forms.Label lblNoRecordsFound;
        private System.Windows.Forms.GroupBox grpfilter;
        private System.Windows.Forms.ComboBox cmbReportType;
        private System.Windows.Forms.Label lblReportType;
        public System.Windows.Forms.PictureBox picLoader;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer RPTViewer;
        private System.Windows.Forms.Button btnListPrint;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.ComboBox cmbState;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.Label lblSupplierType;
        public System.Windows.Forms.ListView lvCity;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Label lblPaymentTerm;
        private System.Windows.Forms.Label lblOrderType;
        private System.Windows.Forms.Label lblReturnPolicy;
        private System.Windows.Forms.ComboBox cmbOrderType;
        private System.Windows.Forms.ComboBox cmbPaymentTerm;
        private System.Windows.Forms.ComboBox cmbReturnPolicy;
        private System.Windows.Forms.ComboBox cmbSupplierType;
        private System.Windows.Forms.Label lblcityid;
        public System.Windows.Forms.DataGridView DGV_FilterCity;
        public System.Windows.Forms.ToolStripButton tsbPrintFormat;
        public System.Windows.Forms.ToolStripButton tsbFormat;
        private DynamicToolStripLabelControl dynamicLabelControl;
        private System.Windows.Forms.ToolStripLabel tsLabelPlaceholder;
        private System.Windows.Forms.Button btnTelegram;
    }
}