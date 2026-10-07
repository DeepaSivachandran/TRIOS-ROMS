namespace ROMS
{
    partial class REPORT_SALES_TaxDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(REPORT_SALES_TaxDetail));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ReportSupplier = new System.Windows.Forms.ToolStrip();
            this.tsbPrintFormat = new System.Windows.Forms.ToolStripButton();
            this.tsbFormat = new System.Windows.Forms.ToolStripButton();
            this.tsLabelPlaceholder = new System.Windows.Forms.ToolStripLabel();
            this.pnlReportStockLocation = new System.Windows.Forms.Panel();
            this.DGV_Customer = new System.Windows.Forms.DataGridView();
            this.grpfilter = new System.Windows.Forms.GroupBox();
            this.cmbGSTType = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cmbDayFilter = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.lblCustomerId = new System.Windows.Forms.Label();
            this.lblDays = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.cmbMultiSelectDays = new MultiSelectComboBox();
            this.lblMonths = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbMultiMonths = new MultiSelectComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cmbBillType = new System.Windows.Forms.ComboBox();
            this.cmbSalesType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dpToDate = new System.Windows.Forms.DateTimePicker();
            this.btnTelegram = new System.Windows.Forms.Button();
            this.cmbReportType = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dpFromDate = new System.Windows.Forms.DateTimePicker();
            this.btnView = new System.Windows.Forms.Button();
            this.lblNoRecordsFound = new System.Windows.Forms.Label();
            this.picLoader = new System.Windows.Forms.PictureBox();
            this.RPTViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.epReport = new System.Windows.Forms.ErrorProvider(this.components);
            this.dynamicLabelControl = new ROMS.DynamicToolStripLabelControl();
            this.ReportSupplier.SuspendLayout();
            this.pnlReportStockLocation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Customer)).BeginInit();
            this.grpfilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epReport)).BeginInit();
            this.SuspendLayout();
            // 
            // ReportSupplier
            // 
            this.ReportSupplier.BackColor = System.Drawing.Color.White;
            this.ReportSupplier.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReportSupplier.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ReportSupplier.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ReportSupplier.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbPrintFormat,
            this.tsbFormat,
            this.tsLabelPlaceholder});
            this.ReportSupplier.Location = new System.Drawing.Point(0, 0);
            this.ReportSupplier.Name = "ReportSupplier";
            this.ReportSupplier.Size = new System.Drawing.Size(1354, 27);
            this.ReportSupplier.TabIndex = 35;
            this.ReportSupplier.Text = "GRN Summary Report";
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
            this.pnlReportStockLocation.Controls.Add(this.DGV_Customer);
            this.pnlReportStockLocation.Controls.Add(this.grpfilter);
            this.pnlReportStockLocation.Controls.Add(this.lblNoRecordsFound);
            this.pnlReportStockLocation.Controls.Add(this.picLoader);
            this.pnlReportStockLocation.Controls.Add(this.RPTViewer);
            this.pnlReportStockLocation.Location = new System.Drawing.Point(0, 29);
            this.pnlReportStockLocation.Name = "pnlReportStockLocation";
            this.pnlReportStockLocation.Size = new System.Drawing.Size(1354, 643);
            this.pnlReportStockLocation.TabIndex = 0;
            // 
            // DGV_Customer
            // 
            this.DGV_Customer.AllowUserToAddRows = false;
            this.DGV_Customer.AllowUserToDeleteRows = false;
            this.DGV_Customer.AllowUserToResizeColumns = false;
            this.DGV_Customer.AllowUserToResizeRows = false;
            this.DGV_Customer.BackgroundColor = System.Drawing.Color.White;
            this.DGV_Customer.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Chocolate;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Chocolate;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_Customer.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DGV_Customer.ColumnHeadersHeight = 30;
            this.DGV_Customer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV_Customer.DefaultCellStyle = dataGridViewCellStyle2;
            this.DGV_Customer.EnableHeadersVisualStyles = false;
            this.DGV_Customer.GridColor = System.Drawing.Color.White;
            this.DGV_Customer.Location = new System.Drawing.Point(963, 75);
            this.DGV_Customer.Name = "DGV_Customer";
            this.DGV_Customer.ReadOnly = true;
            this.DGV_Customer.RowHeadersVisible = false;
            this.DGV_Customer.RowHeadersWidth = 51;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.DGV_Customer.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.DGV_Customer.RowTemplate.Height = 25;
            this.DGV_Customer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV_Customer.Size = new System.Drawing.Size(300, 226);
            this.DGV_Customer.TabIndex = 111111217;
            this.DGV_Customer.Visible = false;
            this.DGV_Customer.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_Customer_CellDoubleClick);
            this.DGV_Customer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DGV_Customer_KeyDown);
            // 
            // grpfilter
            // 
            this.grpfilter.Controls.Add(this.cmbGSTType);
            this.grpfilter.Controls.Add(this.label14);
            this.grpfilter.Controls.Add(this.cmbDayFilter);
            this.grpfilter.Controls.Add(this.label12);
            this.grpfilter.Controls.Add(this.lblCustomerId);
            this.grpfilter.Controls.Add(this.lblDays);
            this.grpfilter.Controls.Add(this.label6);
            this.grpfilter.Controls.Add(this.label11);
            this.grpfilter.Controls.Add(this.txtCustomer);
            this.grpfilter.Controls.Add(this.cmbMultiSelectDays);
            this.grpfilter.Controls.Add(this.lblMonths);
            this.grpfilter.Controls.Add(this.label9);
            this.grpfilter.Controls.Add(this.cmbMultiMonths);
            this.grpfilter.Controls.Add(this.label13);
            this.grpfilter.Controls.Add(this.cmbBillType);
            this.grpfilter.Controls.Add(this.cmbSalesType);
            this.grpfilter.Controls.Add(this.label2);
            this.grpfilter.Controls.Add(this.dpToDate);
            this.grpfilter.Controls.Add(this.btnTelegram);
            this.grpfilter.Controls.Add(this.cmbReportType);
            this.grpfilter.Controls.Add(this.label8);
            this.grpfilter.Controls.Add(this.label7);
            this.grpfilter.Controls.Add(this.label3);
            this.grpfilter.Controls.Add(this.dpFromDate);
            this.grpfilter.Controls.Add(this.btnView);
            this.grpfilter.Location = new System.Drawing.Point(3, 2);
            this.grpfilter.Name = "grpfilter";
            this.grpfilter.Size = new System.Drawing.Size(1348, 154);
            this.grpfilter.TabIndex = 0;
            this.grpfilter.TabStop = false;
            this.grpfilter.Text = "Filter By";
            // 
            // cmbGSTType
            // 
            this.cmbGSTType.FormattingEnabled = true;
            this.cmbGSTType.Location = new System.Drawing.Point(541, 43);
            this.cmbGSTType.Name = "cmbGSTType";
            this.cmbGSTType.Size = new System.Drawing.Size(117, 27);
            this.cmbGSTType.TabIndex = 3;
            this.cmbGSTType.Enter += new System.EventHandler(this.cmbGSTType_Enter);
            this.cmbGSTType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbGSTType_KeyDown);
            this.cmbGSTType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbGSTType_KeyPress);
            this.cmbGSTType.Leave += new System.EventHandler(this.cmbGSTType_Leave);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(541, 20);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(58, 20);
            this.label14.TabIndex = 111111230;
            this.label14.Text = "GST Type";
            // 
            // cmbDayFilter
            // 
            this.cmbDayFilter.FormattingEnabled = true;
            this.cmbDayFilter.Items.AddRange(new object[] {
            "-All Days-",
            "Specific Days"});
            this.cmbDayFilter.Location = new System.Drawing.Point(6, 101);
            this.cmbDayFilter.Name = "cmbDayFilter";
            this.cmbDayFilter.Size = new System.Drawing.Size(91, 27);
            this.cmbDayFilter.TabIndex = 7;
            this.cmbDayFilter.SelectedIndexChanged += new System.EventHandler(this.cmbDayFilter_SelectedIndexChanged);
            this.cmbDayFilter.Enter += new System.EventHandler(this.cmbDayFilter_Enter);
            this.cmbDayFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbDayFilter_KeyDown);
            this.cmbDayFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbDayFilter_KeyPress);
            this.cmbDayFilter.Leave += new System.EventHandler(this.cmbDayFilter_Leave);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(6, 77);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(66, 20);
            this.label12.TabIndex = 111111228;
            this.label12.Text = "Days Filter";
            // 
            // lblCustomerId
            // 
            this.lblCustomerId.AutoSize = true;
            this.lblCustomerId.Location = new System.Drawing.Point(1132, 50);
            this.lblCustomerId.Name = "lblCustomerId";
            this.lblCustomerId.Size = new System.Drawing.Size(16, 20);
            this.lblCustomerId.TabIndex = 111111218;
            this.lblCustomerId.Text = "0";
            this.lblCustomerId.Visible = false;
            // 
            // lblDays
            // 
            this.lblDays.AutoSize = true;
            this.lblDays.Font = new System.Drawing.Font("Oswald Regular", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDays.Location = new System.Drawing.Point(111, 131);
            this.lblDays.Name = "lblDays";
            this.lblDays.Size = new System.Drawing.Size(90, 15);
            this.lblDays.TabIndex = 111111214;
            this.lblDays.Text = "Su,Mo,Tu,We,Th,Fr,Sa";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(963, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 20);
            this.label6.TabIndex = 111111216;
            this.label6.Text = "Customer Name";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(107, 77);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 20);
            this.label11.TabIndex = 111111213;
            this.label11.Text = "Days";
            // 
            // txtCustomer
            // 
            this.txtCustomer.Location = new System.Drawing.Point(963, 43);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(254, 27);
            this.txtCustomer.TabIndex = 6;
            this.txtCustomer.TextChanged += new System.EventHandler(this.txtCustomer_TextChanged);
            this.txtCustomer.Enter += new System.EventHandler(this.txtCustomer_Enter);
            this.txtCustomer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCustomer_KeyDown);
            this.txtCustomer.Leave += new System.EventHandler(this.txtCustomer_Leave);
            // 
            // cmbMultiSelectDays
            // 
            this.cmbMultiSelectDays.BackColor = System.Drawing.SystemColors.Window;
            this.cmbMultiSelectDays.DropDownHeight = 1;
            this.cmbMultiSelectDays.FormattingEnabled = true;
            this.cmbMultiSelectDays.IntegralHeight = false;
            this.cmbMultiSelectDays.Location = new System.Drawing.Point(107, 101);
            this.cmbMultiSelectDays.Name = "cmbMultiSelectDays";
            this.cmbMultiSelectDays.Size = new System.Drawing.Size(94, 27);
            this.cmbMultiSelectDays.TabIndex = 8;
            this.cmbMultiSelectDays.Enter += new System.EventHandler(this.cmbMultiSelectDays_Enter);
            this.cmbMultiSelectDays.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbMultiSelectDays_KeyDown);
            this.cmbMultiSelectDays.Leave += new System.EventHandler(this.cmbMultiSelectDays_Leave);
            // 
            // lblMonths
            // 
            this.lblMonths.AutoSize = true;
            this.lblMonths.Font = new System.Drawing.Font("Oswald Regular", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonths.Location = new System.Drawing.Point(212, 131);
            this.lblMonths.Name = "lblMonths";
            this.lblMonths.Size = new System.Drawing.Size(234, 15);
            this.lblMonths.TabIndex = 111111212;
            this.lblMonths.Text = "Jan, Feb, Mar, Apr, May, Jun, Jul, Aug, Sep, Oct, Nov, Dec";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(212, 77);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 20);
            this.label9.TabIndex = 111111211;
            this.label9.Text = "Months";
            // 
            // cmbMultiMonths
            // 
            this.cmbMultiMonths.BackColor = System.Drawing.SystemColors.Window;
            this.cmbMultiMonths.DropDownHeight = 1;
            this.cmbMultiMonths.FormattingEnabled = true;
            this.cmbMultiMonths.IntegralHeight = false;
            this.cmbMultiMonths.Location = new System.Drawing.Point(212, 101);
            this.cmbMultiMonths.Name = "cmbMultiMonths";
            this.cmbMultiMonths.Size = new System.Drawing.Size(94, 27);
            this.cmbMultiMonths.TabIndex = 9;
            this.cmbMultiMonths.Enter += new System.EventHandler(this.cmbMultiMonths_Enter);
            this.cmbMultiMonths.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbMultiMonths_KeyDown);
            this.cmbMultiMonths.Leave += new System.EventHandler(this.cmbMultiMonths_Leave);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(674, 20);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(54, 20);
            this.label13.TabIndex = 111111196;
            this.label13.Text = "Bill Type";
            // 
            // cmbBillType
            // 
            this.cmbBillType.FormattingEnabled = true;
            this.cmbBillType.Location = new System.Drawing.Point(669, 43);
            this.cmbBillType.Name = "cmbBillType";
            this.cmbBillType.Size = new System.Drawing.Size(130, 27);
            this.cmbBillType.TabIndex = 4;
            this.cmbBillType.Enter += new System.EventHandler(this.cmbBillType_Enter);
            this.cmbBillType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbBillType_KeyDown);
            this.cmbBillType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbBillType_KeyPress);
            this.cmbBillType.Leave += new System.EventHandler(this.cmbBillType_Leave);
            // 
            // cmbSalesType
            // 
            this.cmbSalesType.FormattingEnabled = true;
            this.cmbSalesType.Location = new System.Drawing.Point(814, 43);
            this.cmbSalesType.Name = "cmbSalesType";
            this.cmbSalesType.Size = new System.Drawing.Size(136, 27);
            this.cmbSalesType.TabIndex = 5;
            this.cmbSalesType.Enter += new System.EventHandler(this.cmbSalesType_Enter);
            this.cmbSalesType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbSalesType_KeyDown);
            this.cmbSalesType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbSalesType_KeyPress);
            this.cmbSalesType.Leave += new System.EventHandler(this.cmbSalesType_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(426, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 20);
            this.label2.TabIndex = 111111185;
            this.label2.Text = "To Date";
            // 
            // dpToDate
            // 
            this.dpToDate.CustomFormat = "dd/MM/yyyy";
            this.dpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpToDate.Location = new System.Drawing.Point(426, 43);
            this.dpToDate.Name = "dpToDate";
            this.dpToDate.Size = new System.Drawing.Size(103, 27);
            this.dpToDate.TabIndex = 2;
            this.dpToDate.Enter += new System.EventHandler(this.dpToDate_Enter);
            this.dpToDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dpToDate_KeyDown);
            this.dpToDate.Leave += new System.EventHandler(this.dpToDate_Leave);
            // 
            // btnTelegram
            // 
            this.btnTelegram.Image = ((System.Drawing.Image)(resources.GetObject("btnTelegram.Image")));
            this.btnTelegram.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTelegram.Location = new System.Drawing.Point(351, 101);
            this.btnTelegram.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnTelegram.Name = "btnTelegram";
            this.btnTelegram.Size = new System.Drawing.Size(33, 29);
            this.btnTelegram.TabIndex = 11;
            this.btnTelegram.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTelegram.UseVisualStyleBackColor = true;
            this.btnTelegram.Click += new System.EventHandler(this.btnTelegram_Click);
            this.btnTelegram.Enter += new System.EventHandler(this.btnTelegram_Enter);
            this.btnTelegram.Leave += new System.EventHandler(this.btnTelegram_Leave);
            // 
            // cmbReportType
            // 
            this.cmbReportType.FormattingEnabled = true;
            this.cmbReportType.Location = new System.Drawing.Point(6, 43);
            this.cmbReportType.Name = "cmbReportType";
            this.cmbReportType.Size = new System.Drawing.Size(291, 27);
            this.cmbReportType.TabIndex = 0;
            this.cmbReportType.SelectedIndexChanged += new System.EventHandler(this.cmbReportType_SelectedIndexChanged);
            this.cmbReportType.Enter += new System.EventHandler(this.cmbReportType_Enter);
            this.cmbReportType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbReportType_KeyDown);
            this.cmbReportType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbReportType_KeyPress);
            this.cmbReportType.Leave += new System.EventHandler(this.cmbReportType_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(6, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 20);
            this.label8.TabIndex = 111111182;
            this.label8.Text = "Report type";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(814, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 20);
            this.label7.TabIndex = 111111180;
            this.label7.Text = "Sales Type";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(309, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 20);
            this.label3.TabIndex = 111111176;
            this.label3.Text = "From Date";
            // 
            // dpFromDate
            // 
            this.dpFromDate.CustomFormat = "dd/MM/yyyy";
            this.dpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpFromDate.Location = new System.Drawing.Point(309, 43);
            this.dpFromDate.Name = "dpFromDate";
            this.dpFromDate.Size = new System.Drawing.Size(103, 27);
            this.dpFromDate.TabIndex = 1;
            this.dpFromDate.ValueChanged += new System.EventHandler(this.dpFromDate_ValueChanged);
            this.dpFromDate.Enter += new System.EventHandler(this.dpFromDate_Enter);
            this.dpFromDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dpFromDate_KeyDown);
            this.dpFromDate.Leave += new System.EventHandler(this.dpFromDate_Leave);
            // 
            // btnView
            // 
            this.btnView.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnView.Image = global::ROMS.Properties.Resources.view;
            this.btnView.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnView.Location = new System.Drawing.Point(313, 101);
            this.btnView.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(32, 29);
            this.btnView.TabIndex = 10;
            this.btnView.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.BtnListPrint_Click);
            this.btnView.Enter += new System.EventHandler(this.BtnListPrint_Enter);
            this.btnView.Leave += new System.EventHandler(this.BtnListPrint_Leave);
            // 
            // lblNoRecordsFound
            // 
            this.lblNoRecordsFound.AutoSize = true;
            this.lblNoRecordsFound.BackColor = System.Drawing.Color.White;
            this.lblNoRecordsFound.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoRecordsFound.Location = new System.Drawing.Point(625, 392);
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
            this.picLoader.Location = new System.Drawing.Point(3, 162);
            this.picLoader.Name = "picLoader";
            this.picLoader.Size = new System.Drawing.Size(1351, 480);
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
            this.RPTViewer.Location = new System.Drawing.Point(3, 162);
            this.RPTViewer.Name = "RPTViewer";
            this.RPTViewer.ReuseParameterValuesOnRefresh = true;
            this.RPTViewer.Size = new System.Drawing.Size(1348, 477);
            this.RPTViewer.TabIndex = 1111227;
            this.RPTViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.RPTViewer.Visible = false;
            // 
            // epReport
            // 
            this.epReport.ContainerControl = this;
            // 
            // dynamicLabelControl
            // 
            this.dynamicLabelControl.PlaceholderLabel = null;
            // 
            // REPORT_SALES_TaxDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(1354, 675);
            this.Controls.Add(this.pnlReportStockLocation);
            this.Controls.Add(this.ReportSupplier);
            this.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "REPORT_SALES_TaxDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Price List Report";
            this.Load += new System.EventHandler(this.REPORT_GRNSummary_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.REPORT_GRNSummary_KeyDown);
            this.ReportSupplier.ResumeLayout(false);
            this.ReportSupplier.PerformLayout();
            this.pnlReportStockLocation.ResumeLayout(false);
            this.pnlReportStockLocation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Customer)).EndInit();
            this.grpfilter.ResumeLayout(false);
            this.grpfilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epReport)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip ReportSupplier;
        private System.Windows.Forms.Panel pnlReportStockLocation;
        private System.Windows.Forms.Label lblNoRecordsFound;
        private System.Windows.Forms.GroupBox grpfilter;
        public System.Windows.Forms.PictureBox picLoader;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer RPTViewer;
        private System.Windows.Forms.Button btnView;
        public System.Windows.Forms.ToolStripButton tsbPrintFormat;
        public System.Windows.Forms.ToolStripButton tsbFormat;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dpFromDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbReportType;
        private System.Windows.Forms.ToolStripLabel tsLabelPlaceholder;
        private DynamicToolStripLabelControl dynamicLabelControl;
        private System.Windows.Forms.ErrorProvider epReport;
        private System.Windows.Forms.Button btnTelegram;
        private System.Windows.Forms.DateTimePicker dpToDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbSalesType;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cmbBillType;
        private System.Windows.Forms.Label lblDays;
        private System.Windows.Forms.Label label11;
        private MultiSelectComboBox cmbMultiSelectDays;
        private System.Windows.Forms.Label lblMonths;
        private System.Windows.Forms.Label label9;
        private MultiSelectComboBox cmbMultiMonths;
        public System.Windows.Forms.Label lblCustomerId;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCustomer;
        public System.Windows.Forms.DataGridView DGV_Customer;
        private System.Windows.Forms.ComboBox cmbGSTType;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cmbDayFilter;
        private System.Windows.Forms.Label label12;
    }
}