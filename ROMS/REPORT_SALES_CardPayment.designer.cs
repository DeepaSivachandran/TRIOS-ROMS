namespace ROMS
{
    partial class REPORT_SALES_CardPayment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(REPORT_SALES_CardPayment));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tsRateChangeReport = new System.Windows.Forms.ToolStrip();
            this.tsbPrintFormat = new System.Windows.Forms.ToolStripButton();
            this.tsbFormat = new System.Windows.Forms.ToolStripButton();
            this.tsLabelPlaceholder = new System.Windows.Forms.ToolStripLabel();
            this.pnlReportBrand = new System.Windows.Forms.Panel();
            this.DGV_Customer = new System.Windows.Forms.DataGridView();
            this.grpfilter = new System.Windows.Forms.GroupBox();
            this.lblCustomerId = new System.Windows.Forms.Label();
            this.cmbConcern = new System.Windows.Forms.ComboBox();
            this.lblConcern = new System.Windows.Forms.Label();
            this.lblDays = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbMultiSelectDays = new MultiSelectComboBox();
            this.lblMonths = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbMultiMonths = new MultiSelectComboBox();
            this.txtBillAmt = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtBillno = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbBillType = new System.Windows.Forms.ComboBox();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbVendor = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbMachineId = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnTelegram = new System.Windows.Forms.Button();
            this.dpToDate = new System.Windows.Forms.DateTimePicker();
            this.dpFromDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblBrandCode = new System.Windows.Forms.Label();
            this.lblGroupCode = new System.Windows.Forms.Label();
            this.btnListPrint = new System.Windows.Forms.Button();
            this.cmbReportType = new System.Windows.Forms.ComboBox();
            this.lblReportType = new System.Windows.Forms.Label();
            this.lblNoRecordsFound = new System.Windows.Forms.Label();
            this.picLoader = new System.Windows.Forms.PictureBox();
            this.lblProductcode = new System.Windows.Forms.Label();
            this.RPTViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.lblSubGroupCode = new System.Windows.Forms.Label();
            this.dynamicLabelControl = new ROMS.DynamicToolStripLabelControl();
            this.epReport = new System.Windows.Forms.ErrorProvider(this.components);
            this.tsRateChangeReport.SuspendLayout();
            this.pnlReportBrand.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Customer)).BeginInit();
            this.grpfilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epReport)).BeginInit();
            this.SuspendLayout();
            // 
            // tsRateChangeReport
            // 
            this.tsRateChangeReport.BackColor = System.Drawing.Color.White;
            this.tsRateChangeReport.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsRateChangeReport.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsRateChangeReport.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsRateChangeReport.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbPrintFormat,
            this.tsbFormat,
            this.tsLabelPlaceholder});
            this.tsRateChangeReport.Location = new System.Drawing.Point(0, 0);
            this.tsRateChangeReport.Name = "tsRateChangeReport";
            this.tsRateChangeReport.Size = new System.Drawing.Size(1354, 27);
            this.tsRateChangeReport.TabIndex = 35;
            this.tsRateChangeReport.Text = "Brand Report";
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
            // pnlReportBrand
            // 
            this.pnlReportBrand.BackColor = System.Drawing.Color.White;
            this.pnlReportBrand.Controls.Add(this.DGV_Customer);
            this.pnlReportBrand.Controls.Add(this.grpfilter);
            this.pnlReportBrand.Controls.Add(this.lblNoRecordsFound);
            this.pnlReportBrand.Controls.Add(this.picLoader);
            this.pnlReportBrand.Controls.Add(this.lblProductcode);
            this.pnlReportBrand.Controls.Add(this.RPTViewer);
            this.pnlReportBrand.Controls.Add(this.lblSubGroupCode);
            this.pnlReportBrand.Location = new System.Drawing.Point(0, 29);
            this.pnlReportBrand.Name = "pnlReportBrand";
            this.pnlReportBrand.Size = new System.Drawing.Size(1354, 643);
            this.pnlReportBrand.TabIndex = 958788;
            // 
            // DGV_Customer
            // 
            this.DGV_Customer.AllowUserToAddRows = false;
            this.DGV_Customer.AllowUserToDeleteRows = false;
            this.DGV_Customer.AllowUserToResizeColumns = false;
            this.DGV_Customer.AllowUserToResizeRows = false;
            this.DGV_Customer.BackgroundColor = System.Drawing.Color.White;
            this.DGV_Customer.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Chocolate;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Chocolate;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_Customer.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.DGV_Customer.ColumnHeadersHeight = 30;
            this.DGV_Customer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV_Customer.DefaultCellStyle = dataGridViewCellStyle5;
            this.DGV_Customer.EnableHeadersVisualStyles = false;
            this.DGV_Customer.GridColor = System.Drawing.Color.White;
            this.DGV_Customer.Location = new System.Drawing.Point(295, 80);
            this.DGV_Customer.Name = "DGV_Customer";
            this.DGV_Customer.ReadOnly = true;
            this.DGV_Customer.RowHeadersVisible = false;
            this.DGV_Customer.RowHeadersWidth = 51;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.DGV_Customer.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.DGV_Customer.RowTemplate.Height = 25;
            this.DGV_Customer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV_Customer.Size = new System.Drawing.Size(281, 226);
            this.DGV_Customer.TabIndex = 111111176;
            this.DGV_Customer.Visible = false;
            this.DGV_Customer.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_Customer_CellDoubleClick);
            this.DGV_Customer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DGV_Customer_KeyDown);
            // 
            // grpfilter
            // 
            this.grpfilter.Controls.Add(this.lblCustomerId);
            this.grpfilter.Controls.Add(this.cmbConcern);
            this.grpfilter.Controls.Add(this.lblConcern);
            this.grpfilter.Controls.Add(this.lblDays);
            this.grpfilter.Controls.Add(this.label11);
            this.grpfilter.Controls.Add(this.cmbMultiSelectDays);
            this.grpfilter.Controls.Add(this.lblMonths);
            this.grpfilter.Controls.Add(this.label8);
            this.grpfilter.Controls.Add(this.label9);
            this.grpfilter.Controls.Add(this.cmbMultiMonths);
            this.grpfilter.Controls.Add(this.txtBillAmt);
            this.grpfilter.Controls.Add(this.label7);
            this.grpfilter.Controls.Add(this.txtBillno);
            this.grpfilter.Controls.Add(this.label6);
            this.grpfilter.Controls.Add(this.cmbBillType);
            this.grpfilter.Controls.Add(this.txtCustomer);
            this.grpfilter.Controls.Add(this.label5);
            this.grpfilter.Controls.Add(this.cmbVendor);
            this.grpfilter.Controls.Add(this.label4);
            this.grpfilter.Controls.Add(this.cmbMachineId);
            this.grpfilter.Controls.Add(this.label2);
            this.grpfilter.Controls.Add(this.btnTelegram);
            this.grpfilter.Controls.Add(this.dpToDate);
            this.grpfilter.Controls.Add(this.dpFromDate);
            this.grpfilter.Controls.Add(this.label3);
            this.grpfilter.Controls.Add(this.label1);
            this.grpfilter.Controls.Add(this.lblBrandCode);
            this.grpfilter.Controls.Add(this.lblGroupCode);
            this.grpfilter.Controls.Add(this.btnListPrint);
            this.grpfilter.Controls.Add(this.cmbReportType);
            this.grpfilter.Controls.Add(this.lblReportType);
            this.grpfilter.Location = new System.Drawing.Point(3, 2);
            this.grpfilter.Name = "grpfilter";
            this.grpfilter.Size = new System.Drawing.Size(1348, 99);
            this.grpfilter.TabIndex = 0;
            this.grpfilter.TabStop = false;
            this.grpfilter.Text = "Filter By";
            // 
            // lblCustomerId
            // 
            this.lblCustomerId.AutoSize = true;
            this.lblCustomerId.Location = new System.Drawing.Point(253, 75);
            this.lblCustomerId.Name = "lblCustomerId";
            this.lblCustomerId.Size = new System.Drawing.Size(16, 20);
            this.lblCustomerId.TabIndex = 111111206;
            this.lblCustomerId.Text = "0";
            this.lblCustomerId.Visible = false;
            // 
            // cmbConcern
            // 
            this.cmbConcern.BackColor = System.Drawing.SystemColors.Window;
            this.cmbConcern.DropDownWidth = 94;
            this.cmbConcern.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbConcern.FormattingEnabled = true;
            this.cmbConcern.Location = new System.Drawing.Point(437, 19);
            this.cmbConcern.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbConcern.Name = "cmbConcern";
            this.cmbConcern.Size = new System.Drawing.Size(66, 27);
            this.cmbConcern.TabIndex = 1;
            this.cmbConcern.Enter += new System.EventHandler(this.cmbConcern_Enter);
            this.cmbConcern.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbConcern_KeyDown);
            this.cmbConcern.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbConcern_KeyPress);
            this.cmbConcern.Leave += new System.EventHandler(this.cmbConcern_Leave);
            // 
            // lblConcern
            // 
            this.lblConcern.AutoSize = true;
            this.lblConcern.Location = new System.Drawing.Point(377, 22);
            this.lblConcern.Name = "lblConcern";
            this.lblConcern.Size = new System.Drawing.Size(54, 20);
            this.lblConcern.TabIndex = 1111229;
            this.lblConcern.Text = "Concern";
            // 
            // lblDays
            // 
            this.lblDays.AutoSize = true;
            this.lblDays.Font = new System.Drawing.Font("Oswald Regular", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDays.Location = new System.Drawing.Point(957, 78);
            this.lblDays.Name = "lblDays";
            this.lblDays.Size = new System.Drawing.Size(90, 15);
            this.lblDays.TabIndex = 111111205;
            this.lblDays.Text = "Su,Mo,Tu,We,Th,Fr,Sa";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(884, 53);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 20);
            this.label11.TabIndex = 111111204;
            this.label11.Text = "Days";
            // 
            // cmbMultiSelectDays
            // 
            this.cmbMultiSelectDays.BackColor = System.Drawing.SystemColors.Window;
            this.cmbMultiSelectDays.DropDownHeight = 1;
            this.cmbMultiSelectDays.FormattingEnabled = true;
            this.cmbMultiSelectDays.IntegralHeight = false;
            this.cmbMultiSelectDays.Location = new System.Drawing.Point(960, 50);
            this.cmbMultiSelectDays.Name = "cmbMultiSelectDays";
            this.cmbMultiSelectDays.Size = new System.Drawing.Size(105, 27);
            this.cmbMultiSelectDays.TabIndex = 10;
            this.cmbMultiSelectDays.Enter += new System.EventHandler(this.cmbMultiSelectDays_Enter);
            this.cmbMultiSelectDays.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbMultiSelectDays_KeyDown);
            this.cmbMultiSelectDays.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbMultiSelectDays_KeyPress);
            this.cmbMultiSelectDays.Leave += new System.EventHandler(this.cmbMultiSelectDays_Leave);
            // 
            // lblMonths
            // 
            this.lblMonths.AutoSize = true;
            this.lblMonths.Font = new System.Drawing.Font("Oswald Regular", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonths.Location = new System.Drawing.Point(1080, 78);
            this.lblMonths.Name = "lblMonths";
            this.lblMonths.Size = new System.Drawing.Size(234, 15);
            this.lblMonths.TabIndex = 111111202;
            this.lblMonths.Text = "Jan, Feb, Mar, Apr, May, Jun, Jul, Aug, Sep, Oct, Nov, Dec";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(688, 53);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 20);
            this.label8.TabIndex = 111111179;
            this.label8.Text = "Bill Amount";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(1075, 53);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 20);
            this.label9.TabIndex = 111111201;
            this.label9.Text = "Months";
            // 
            // cmbMultiMonths
            // 
            this.cmbMultiMonths.BackColor = System.Drawing.SystemColors.Window;
            this.cmbMultiMonths.DropDownHeight = 1;
            this.cmbMultiMonths.FormattingEnabled = true;
            this.cmbMultiMonths.IntegralHeight = false;
            this.cmbMultiMonths.Location = new System.Drawing.Point(1136, 50);
            this.cmbMultiMonths.Name = "cmbMultiMonths";
            this.cmbMultiMonths.Size = new System.Drawing.Size(105, 27);
            this.cmbMultiMonths.TabIndex = 11;
            this.cmbMultiMonths.Enter += new System.EventHandler(this.cmbMultiMonths_Enter);
            this.cmbMultiMonths.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbMultiMonths_KeyDown);
            this.cmbMultiMonths.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbMultiMonths_KeyPress);
            this.cmbMultiMonths.Leave += new System.EventHandler(this.cmbMultiMonths_Leave);
            // 
            // txtBillAmt
            // 
            this.txtBillAmt.Location = new System.Drawing.Point(765, 50);
            this.txtBillAmt.MaxLength = 15;
            this.txtBillAmt.Name = "txtBillAmt";
            this.txtBillAmt.Size = new System.Drawing.Size(107, 27);
            this.txtBillAmt.TabIndex = 9;
            this.txtBillAmt.Enter += new System.EventHandler(this.txtbillamtt_Enter);
            this.txtBillAmt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtbillamtt_KeyDown);
            this.txtBillAmt.Leave += new System.EventHandler(this.txtbillamtt_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(507, 53);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 20);
            this.label7.TabIndex = 111111177;
            this.label7.Text = "Bill No.";
            // 
            // txtBillno
            // 
            this.txtBillno.Location = new System.Drawing.Point(571, 50);
            this.txtBillno.Name = "txtBillno";
            this.txtBillno.Size = new System.Drawing.Size(107, 27);
            this.txtBillno.TabIndex = 8;
            this.txtBillno.Enter += new System.EventHandler(this.txtBillno_Enter);
            this.txtBillno.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBillno_KeyDown);
            this.txtBillno.Leave += new System.EventHandler(this.txtBillno_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(194, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 20);
            this.label6.TabIndex = 111111175;
            this.label6.Text = "Customer Name";
            // 
            // cmbBillType
            // 
            this.cmbBillType.BackColor = System.Drawing.SystemColors.Window;
            this.cmbBillType.DropDownWidth = 94;
            this.cmbBillType.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBillType.FormattingEnabled = true;
            this.cmbBillType.Location = new System.Drawing.Point(79, 50);
            this.cmbBillType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbBillType.Name = "cmbBillType";
            this.cmbBillType.Size = new System.Drawing.Size(105, 27);
            this.cmbBillType.TabIndex = 6;
            this.cmbBillType.Enter += new System.EventHandler(this.cmbBillType_Enter);
            this.cmbBillType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbBillType_KeyDown);
            this.cmbBillType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbBillType_KeyPress);
            this.cmbBillType.Leave += new System.EventHandler(this.cmbBillType_Leave);
            // 
            // txtCustomer
            // 
            this.txtCustomer.Location = new System.Drawing.Point(291, 50);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(212, 27);
            this.txtCustomer.TabIndex = 7;
            this.txtCustomer.TextChanged += new System.EventHandler(this.txtCustomer_TextChanged);
            this.txtCustomer.Enter += new System.EventHandler(this.txtCustomer_Enter);
            this.txtCustomer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCustomer_KeyDown);
            this.txtCustomer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCustomer_KeyPress);
            this.txtCustomer.Leave += new System.EventHandler(this.txtCustomer_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 20);
            this.label5.TabIndex = 111111174;
            this.label5.Text = "Bill Type";
            // 
            // cmbVendor
            // 
            this.cmbVendor.BackColor = System.Drawing.SystemColors.Window;
            this.cmbVendor.DropDownWidth = 94;
            this.cmbVendor.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbVendor.FormattingEnabled = true;
            this.cmbVendor.Location = new System.Drawing.Point(1135, 19);
            this.cmbVendor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbVendor.Name = "cmbVendor";
            this.cmbVendor.Size = new System.Drawing.Size(105, 27);
            this.cmbVendor.TabIndex = 5;
            this.cmbVendor.Enter += new System.EventHandler(this.cmbVendor_Enter);
            this.cmbVendor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbVendor_KeyDown);
            this.cmbVendor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbVendor_KeyPress);
            this.cmbVendor.Leave += new System.EventHandler(this.cmbVendor_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1075, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 20);
            this.label4.TabIndex = 111111172;
            this.label4.Text = "Vendor";
            // 
            // cmbMachineId
            // 
            this.cmbMachineId.BackColor = System.Drawing.SystemColors.Window;
            this.cmbMachineId.DropDownWidth = 94;
            this.cmbMachineId.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMachineId.FormattingEnabled = true;
            this.cmbMachineId.Location = new System.Drawing.Point(959, 19);
            this.cmbMachineId.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbMachineId.Name = "cmbMachineId";
            this.cmbMachineId.Size = new System.Drawing.Size(105, 27);
            this.cmbMachineId.TabIndex = 4;
            this.cmbMachineId.Enter += new System.EventHandler(this.cmbMachineId_Enter);
            this.cmbMachineId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbMachineId_KeyDown);
            this.cmbMachineId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbMachineId_KeyPress);
            this.cmbMachineId.Leave += new System.EventHandler(this.cmbMachineId_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(884, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 20);
            this.label2.TabIndex = 111111170;
            this.label2.Text = "Machine ID";
            // 
            // btnTelegram
            // 
            this.btnTelegram.Image = ((System.Drawing.Image)(resources.GetObject("btnTelegram.Image")));
            this.btnTelegram.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTelegram.Location = new System.Drawing.Point(1296, 49);
            this.btnTelegram.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnTelegram.Name = "btnTelegram";
            this.btnTelegram.Size = new System.Drawing.Size(33, 29);
            this.btnTelegram.TabIndex = 13;
            this.btnTelegram.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTelegram.UseVisualStyleBackColor = true;
            this.btnTelegram.Click += new System.EventHandler(this.btnTelegram_Click);
            this.btnTelegram.Enter += new System.EventHandler(this.btnTelegram_Enter);
            this.btnTelegram.Leave += new System.EventHandler(this.btnTelegram_Leave);
            // 
            // dpToDate
            // 
            this.dpToDate.CustomFormat = "dd/MM/yyyy";
            this.dpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpToDate.Location = new System.Drawing.Point(762, 19);
            this.dpToDate.Name = "dpToDate";
            this.dpToDate.Size = new System.Drawing.Size(110, 27);
            this.dpToDate.TabIndex = 3;
            this.dpToDate.Enter += new System.EventHandler(this.dpToDate_Enter);
            this.dpToDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dpToDate_KeyDown);
            this.dpToDate.Leave += new System.EventHandler(this.dpToDate_Leave);
            // 
            // dpFromDate
            // 
            this.dpFromDate.CustomFormat = "dd/MM/yyyy";
            this.dpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpFromDate.Location = new System.Drawing.Point(571, 19);
            this.dpFromDate.Name = "dpFromDate";
            this.dpFromDate.Size = new System.Drawing.Size(107, 27);
            this.dpFromDate.TabIndex = 2;
            this.dpFromDate.ValueChanged += new System.EventHandler(this.dpFromDate_ValueChanged);
            this.dpFromDate.Enter += new System.EventHandler(this.dpFromDate_Enter);
            this.dpFromDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dpFromDate_KeyDown);
            this.dpFromDate.Leave += new System.EventHandler(this.dpFromDate_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(688, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 20);
            this.label3.TabIndex = 111111168;
            this.label3.Text = "To Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(507, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 20);
            this.label1.TabIndex = 111111167;
            this.label1.Text = "From Date";
            // 
            // lblBrandCode
            // 
            this.lblBrandCode.AutoSize = true;
            this.lblBrandCode.Location = new System.Drawing.Point(472, 2);
            this.lblBrandCode.Name = "lblBrandCode";
            this.lblBrandCode.Size = new System.Drawing.Size(16, 20);
            this.lblBrandCode.TabIndex = 1111231;
            this.lblBrandCode.Text = "0";
            this.lblBrandCode.Visible = false;
            // 
            // lblGroupCode
            // 
            this.lblGroupCode.AutoSize = true;
            this.lblGroupCode.Location = new System.Drawing.Point(572, 2);
            this.lblGroupCode.Name = "lblGroupCode";
            this.lblGroupCode.Size = new System.Drawing.Size(16, 20);
            this.lblGroupCode.TabIndex = 1111231;
            this.lblGroupCode.Text = "0";
            this.lblGroupCode.Visible = false;
            // 
            // btnListPrint
            // 
            this.btnListPrint.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListPrint.Image = global::ROMS.Properties.Resources.view;
            this.btnListPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnListPrint.Location = new System.Drawing.Point(1252, 49);
            this.btnListPrint.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnListPrint.Name = "btnListPrint";
            this.btnListPrint.Size = new System.Drawing.Size(33, 29);
            this.btnListPrint.TabIndex = 12;
            this.btnListPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnListPrint.UseVisualStyleBackColor = true;
            this.btnListPrint.Click += new System.EventHandler(this.BtnListPrint_Click);
            this.btnListPrint.Enter += new System.EventHandler(this.BtnListPrint_Enter);
            this.btnListPrint.Leave += new System.EventHandler(this.BtnListPrint_Leave);
            // 
            // cmbReportType
            // 
            this.cmbReportType.FormattingEnabled = true;
            this.cmbReportType.Location = new System.Drawing.Point(79, 19);
            this.cmbReportType.Name = "cmbReportType";
            this.cmbReportType.Size = new System.Drawing.Size(292, 27);
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
            this.lblReportType.Location = new System.Drawing.Point(6, 22);
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
            this.lblNoRecordsFound.Location = new System.Drawing.Point(625, 357);
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
            this.picLoader.Location = new System.Drawing.Point(3, 107);
            this.picLoader.Name = "picLoader";
            this.picLoader.Size = new System.Drawing.Size(1348, 535);
            this.picLoader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picLoader.TabIndex = 958790;
            this.picLoader.TabStop = false;
            this.picLoader.Visible = false;
            // 
            // lblProductcode
            // 
            this.lblProductcode.AutoSize = true;
            this.lblProductcode.Location = new System.Drawing.Point(485, -2);
            this.lblProductcode.Name = "lblProductcode";
            this.lblProductcode.Size = new System.Drawing.Size(16, 20);
            this.lblProductcode.TabIndex = 111111169;
            this.lblProductcode.Text = "0";
            this.lblProductcode.Visible = false;
            // 
            // RPTViewer
            // 
            this.RPTViewer.ActiveViewIndex = -1;
            this.RPTViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RPTViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.RPTViewer.Location = new System.Drawing.Point(3, 107);
            this.RPTViewer.Name = "RPTViewer";
            this.RPTViewer.ReuseParameterValuesOnRefresh = true;
            this.RPTViewer.Size = new System.Drawing.Size(1348, 532);
            this.RPTViewer.TabIndex = 1111227;
            this.RPTViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.RPTViewer.Visible = false;
            // 
            // lblSubGroupCode
            // 
            this.lblSubGroupCode.AutoSize = true;
            this.lblSubGroupCode.Location = new System.Drawing.Point(490, -21);
            this.lblSubGroupCode.Name = "lblSubGroupCode";
            this.lblSubGroupCode.Size = new System.Drawing.Size(16, 20);
            this.lblSubGroupCode.TabIndex = 1111231;
            this.lblSubGroupCode.Text = "0";
            this.lblSubGroupCode.Visible = false;
            // 
            // dynamicLabelControl
            // 
            this.dynamicLabelControl.PlaceholderLabel = null;
            // 
            // epReport
            // 
            this.epReport.ContainerControl = this;
            // 
            // REPORT_SALES_CardPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(1354, 675);
            this.Controls.Add(this.pnlReportBrand);
            this.Controls.Add(this.tsRateChangeReport);
            this.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "REPORT_SALES_CardPayment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rate Change Report";
            this.Load += new System.EventHandler(this.REPORT_CP_RateChange_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.REPORT_CP_RateChange_KeyDown);
            this.tsRateChangeReport.ResumeLayout(false);
            this.tsRateChangeReport.PerformLayout();
            this.pnlReportBrand.ResumeLayout(false);
            this.pnlReportBrand.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Customer)).EndInit();
            this.grpfilter.ResumeLayout(false);
            this.grpfilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epReport)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsRateChangeReport;
        private System.Windows.Forms.Panel pnlReportBrand;
        private System.Windows.Forms.Label lblNoRecordsFound;
        private System.Windows.Forms.GroupBox grpfilter;
        private System.Windows.Forms.ComboBox cmbReportType;
        private System.Windows.Forms.Label lblReportType;
        public System.Windows.Forms.PictureBox picLoader;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer RPTViewer;
        private System.Windows.Forms.Button btnListPrint;
        private System.Windows.Forms.Label lblSubGroupCode;
        private System.Windows.Forms.Label lblGroupCode;
        public System.Windows.Forms.Label lblBrandCode;
        private System.Windows.Forms.DateTimePicker dpToDate;
        private System.Windows.Forms.DateTimePicker dpFromDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblProductcode;
        public System.Windows.Forms.ToolStripButton tsbPrintFormat;
        public System.Windows.Forms.ToolStripButton tsbFormat;
        private System.Windows.Forms.ToolStripLabel tsLabelPlaceholder;
        private DynamicToolStripLabelControl dynamicLabelControl;
        private System.Windows.Forms.Button btnTelegram;
        private System.Windows.Forms.ComboBox cmbVendor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbMachineId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbConcern;
        private System.Windows.Forms.Label lblConcern;
        private System.Windows.Forms.ComboBox cmbBillType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCustomer;
        public System.Windows.Forms.DataGridView DGV_Customer;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtBillAmt;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtBillno;
        private System.Windows.Forms.Label lblDays;
        private System.Windows.Forms.Label label11;
        private MultiSelectComboBox cmbMultiSelectDays;
        private System.Windows.Forms.Label lblMonths;
        private System.Windows.Forms.Label label9;
        private MultiSelectComboBox cmbMultiMonths;
        public System.Windows.Forms.Label lblCustomerId;
        private System.Windows.Forms.ErrorProvider epReport;
    }
}