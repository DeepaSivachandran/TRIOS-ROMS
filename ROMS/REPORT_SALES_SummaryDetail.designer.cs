namespace ROMS
{
    partial class REPORT_SALES_SummaryDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(REPORT_SALES_SummaryDetail));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ReportSupplier = new System.Windows.Forms.ToolStrip();
            this.tsbPrintFormat = new System.Windows.Forms.ToolStripButton();
            this.tsbFormat = new System.Windows.Forms.ToolStripButton();
            this.tsLabelPlaceholder = new System.Windows.Forms.ToolStripLabel();
            this.pnlReportStockLocation = new System.Windows.Forms.Panel();
            this.DGV_BilledBy = new System.Windows.Forms.DataGridView();
            this.DGV_Customer = new System.Windows.Forms.DataGridView();
            this.grpfilter = new System.Windows.Forms.GroupBox();
            this.cmbFormat2 = new System.Windows.Forms.ComboBox();
            this.mtbTime2 = new System.Windows.Forms.MaskedTextBox();
            this.cmbFormat1 = new System.Windows.Forms.ComboBox();
            this.mtbTime1 = new System.Windows.Forms.MaskedTextBox();
            this.cmbDayFilter = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.chkTimeRange = new System.Windows.Forms.CheckBox();
            this.lblBilledByID = new System.Windows.Forms.Label();
            this.txtBilledBy = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbCustomerCategory = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbBillCategory = new System.Windows.Forms.ComboBox();
            this.lblCustomerId = new System.Windows.Forms.Label();
            this.lblDays = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.cmbMultiSelectDays = new MultiSelectComboBox();
            this.lblMonths = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbMultiMonths = new MultiSelectComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbSchemeType = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.cmbPrintType = new System.Windows.Forms.ComboBox();
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
            ((System.ComponentModel.ISupportInitialize)(this.DGV_BilledBy)).BeginInit();
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
            this.pnlReportStockLocation.Controls.Add(this.DGV_BilledBy);
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
            // DGV_BilledBy
            // 
            this.DGV_BilledBy.AllowUserToAddRows = false;
            this.DGV_BilledBy.AllowUserToDeleteRows = false;
            this.DGV_BilledBy.AllowUserToResizeColumns = false;
            this.DGV_BilledBy.AllowUserToResizeRows = false;
            this.DGV_BilledBy.BackgroundColor = System.Drawing.Color.White;
            this.DGV_BilledBy.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Chocolate;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Chocolate;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_BilledBy.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DGV_BilledBy.ColumnHeadersHeight = 30;
            this.DGV_BilledBy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV_BilledBy.DefaultCellStyle = dataGridViewCellStyle2;
            this.DGV_BilledBy.EnableHeadersVisualStyles = false;
            this.DGV_BilledBy.GridColor = System.Drawing.Color.White;
            this.DGV_BilledBy.Location = new System.Drawing.Point(1131, 72);
            this.DGV_BilledBy.Name = "DGV_BilledBy";
            this.DGV_BilledBy.ReadOnly = true;
            this.DGV_BilledBy.RowHeadersVisible = false;
            this.DGV_BilledBy.RowHeadersWidth = 51;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.DGV_BilledBy.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.DGV_BilledBy.RowTemplate.Height = 25;
            this.DGV_BilledBy.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV_BilledBy.Size = new System.Drawing.Size(214, 226);
            this.DGV_BilledBy.TabIndex = 111111218;
            this.DGV_BilledBy.Visible = false;
            this.DGV_BilledBy.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_BilledBy_CellDoubleClick);
            this.DGV_BilledBy.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DGV_BilledBy_KeyDown);
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
            this.DGV_Customer.Location = new System.Drawing.Point(233, 131);
            this.DGV_Customer.Name = "DGV_Customer";
            this.DGV_Customer.ReadOnly = true;
            this.DGV_Customer.RowHeadersVisible = false;
            this.DGV_Customer.RowHeadersWidth = 51;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.DGV_Customer.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.DGV_Customer.RowTemplate.Height = 25;
            this.DGV_Customer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV_Customer.Size = new System.Drawing.Size(237, 226);
            this.DGV_Customer.TabIndex = 111111217;
            this.DGV_Customer.Visible = false;
            this.DGV_Customer.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_Customer_CellDoubleClick);
            this.DGV_Customer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DGV_Customer_KeyDown);
            // 
            // grpfilter
            // 
            this.grpfilter.Controls.Add(this.cmbFormat2);
            this.grpfilter.Controls.Add(this.mtbTime2);
            this.grpfilter.Controls.Add(this.cmbFormat1);
            this.grpfilter.Controls.Add(this.mtbTime1);
            this.grpfilter.Controls.Add(this.cmbDayFilter);
            this.grpfilter.Controls.Add(this.label12);
            this.grpfilter.Controls.Add(this.chkTimeRange);
            this.grpfilter.Controls.Add(this.lblBilledByID);
            this.grpfilter.Controls.Add(this.txtBilledBy);
            this.grpfilter.Controls.Add(this.label10);
            this.grpfilter.Controls.Add(this.label5);
            this.grpfilter.Controls.Add(this.cmbCustomerCategory);
            this.grpfilter.Controls.Add(this.label4);
            this.grpfilter.Controls.Add(this.cmbBillCategory);
            this.grpfilter.Controls.Add(this.lblCustomerId);
            this.grpfilter.Controls.Add(this.lblDays);
            this.grpfilter.Controls.Add(this.label6);
            this.grpfilter.Controls.Add(this.label11);
            this.grpfilter.Controls.Add(this.txtCustomer);
            this.grpfilter.Controls.Add(this.cmbMultiSelectDays);
            this.grpfilter.Controls.Add(this.lblMonths);
            this.grpfilter.Controls.Add(this.label9);
            this.grpfilter.Controls.Add(this.cmbMultiMonths);
            this.grpfilter.Controls.Add(this.label1);
            this.grpfilter.Controls.Add(this.cmbSchemeType);
            this.grpfilter.Controls.Add(this.label18);
            this.grpfilter.Controls.Add(this.label17);
            this.grpfilter.Controls.Add(this.label16);
            this.grpfilter.Controls.Add(this.cmbPrintType);
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
            // cmbFormat2
            // 
            this.cmbFormat2.FormattingEnabled = true;
            this.cmbFormat2.Items.AddRange(new object[] {
            "AM",
            "PM"});
            this.cmbFormat2.Location = new System.Drawing.Point(700, 43);
            this.cmbFormat2.Name = "cmbFormat2";
            this.cmbFormat2.Size = new System.Drawing.Size(41, 27);
            this.cmbFormat2.TabIndex = 7;
            this.cmbFormat2.Enter += new System.EventHandler(this.cmbFormat2_Enter);
            this.cmbFormat2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbFormat2_KeyDown);
            this.cmbFormat2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbFormat2_KeyPress);
            this.cmbFormat2.Leave += new System.EventHandler(this.cmbFormat2_Leave);
            // 
            // mtbTime2
            // 
            this.mtbTime2.Location = new System.Drawing.Point(647, 43);
            this.mtbTime2.Mask = "90:00";
            this.mtbTime2.Name = "mtbTime2";
            this.mtbTime2.Size = new System.Drawing.Size(53, 27);
            this.mtbTime2.TabIndex = 6;
            this.mtbTime2.ValidatingType = typeof(System.DateTime);
            this.mtbTime2.Enter += new System.EventHandler(this.mtbTime2_Enter);
            this.mtbTime2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mtbTime2_KeyDown);
            this.mtbTime2.Leave += new System.EventHandler(this.mtbTime2_Leave);
            // 
            // cmbFormat1
            // 
            this.cmbFormat1.FormattingEnabled = true;
            this.cmbFormat1.Items.AddRange(new object[] {
            "AM",
            "PM"});
            this.cmbFormat1.Location = new System.Drawing.Point(598, 43);
            this.cmbFormat1.Name = "cmbFormat1";
            this.cmbFormat1.Size = new System.Drawing.Size(41, 27);
            this.cmbFormat1.TabIndex = 5;
            this.cmbFormat1.SelectedIndexChanged += new System.EventHandler(this.cmbFormat1_SelectedIndexChanged);
            this.cmbFormat1.Enter += new System.EventHandler(this.cmbFormat1_Enter);
            this.cmbFormat1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbFormat1_KeyDown);
            this.cmbFormat1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbFormat1_KeyPress);
            this.cmbFormat1.Leave += new System.EventHandler(this.cmbFormat1_Leave);
            // 
            // mtbTime1
            // 
            this.mtbTime1.Location = new System.Drawing.Point(545, 43);
            this.mtbTime1.Mask = "90:00";
            this.mtbTime1.Name = "mtbTime1";
            this.mtbTime1.Size = new System.Drawing.Size(53, 27);
            this.mtbTime1.TabIndex = 4;
            this.mtbTime1.ValidatingType = typeof(System.DateTime);
            this.mtbTime1.Enter += new System.EventHandler(this.mtbTime1_Enter);
            this.mtbTime1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mtbTime1_KeyDown);
            this.mtbTime1.Leave += new System.EventHandler(this.mtbTime1_Leave_1);
            // 
            // cmbDayFilter
            // 
            this.cmbDayFilter.FormattingEnabled = true;
            this.cmbDayFilter.Items.AddRange(new object[] {
            "-All Days-",
            "Specific Days"});
            this.cmbDayFilter.Location = new System.Drawing.Point(448, 102);
            this.cmbDayFilter.Name = "cmbDayFilter";
            this.cmbDayFilter.Size = new System.Drawing.Size(91, 27);
            this.cmbDayFilter.TabIndex = 15;
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
            this.label12.Location = new System.Drawing.Point(448, 79);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(66, 20);
            this.label12.TabIndex = 111111228;
            this.label12.Text = "Days Filter";
            // 
            // chkTimeRange
            // 
            this.chkTimeRange.AutoSize = true;
            this.chkTimeRange.Location = new System.Drawing.Point(448, 44);
            this.chkTimeRange.Name = "chkTimeRange";
            this.chkTimeRange.Size = new System.Drawing.Size(91, 24);
            this.chkTimeRange.TabIndex = 3;
            this.chkTimeRange.Text = "Enable Time";
            this.chkTimeRange.UseVisualStyleBackColor = true;
            this.chkTimeRange.CheckedChanged += new System.EventHandler(this.chkTimeRange_CheckedChanged);
            this.chkTimeRange.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chkTimeRange_KeyDown);
            // 
            // lblBilledByID
            // 
            this.lblBilledByID.AutoSize = true;
            this.lblBilledByID.Location = new System.Drawing.Point(1235, 21);
            this.lblBilledByID.Name = "lblBilledByID";
            this.lblBilledByID.Size = new System.Drawing.Size(16, 20);
            this.lblBilledByID.TabIndex = 111111225;
            this.lblBilledByID.Text = "0";
            this.lblBilledByID.Visible = false;
            // 
            // txtBilledBy
            // 
            this.txtBilledBy.Location = new System.Drawing.Point(1128, 43);
            this.txtBilledBy.Name = "txtBilledBy";
            this.txtBilledBy.Size = new System.Drawing.Size(211, 27);
            this.txtBilledBy.TabIndex = 11;
            this.txtBilledBy.TextChanged += new System.EventHandler(this.txtBilledBy_TextChanged);
            this.txtBilledBy.Enter += new System.EventHandler(this.txtBilledBy_Enter);
            this.txtBilledBy.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBilledBy_KeyDown);
            this.txtBilledBy.Leave += new System.EventHandler(this.txtBilledBy_Leave);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(1128, 20);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 20);
            this.label10.TabIndex = 111111223;
            this.label10.Text = "Billed By";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(120, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 20);
            this.label5.TabIndex = 111111222;
            this.label5.Text = "Customer Type";
            // 
            // cmbCustomerCategory
            // 
            this.cmbCustomerCategory.FormattingEnabled = true;
            this.cmbCustomerCategory.Location = new System.Drawing.Point(120, 102);
            this.cmbCustomerCategory.Name = "cmbCustomerCategory";
            this.cmbCustomerCategory.Size = new System.Drawing.Size(101, 27);
            this.cmbCustomerCategory.TabIndex = 13;
            this.cmbCustomerCategory.Enter += new System.EventHandler(this.cmbCustomerCategory_Enter);
            this.cmbCustomerCategory.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbCustomerCategory_KeyDown);
            this.cmbCustomerCategory.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbCustomerCategory_KeyPress);
            this.cmbCustomerCategory.Leave += new System.EventHandler(this.cmbCustomerCategory_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 20);
            this.label4.TabIndex = 111111220;
            this.label4.Text = "Bill Category";
            // 
            // cmbBillCategory
            // 
            this.cmbBillCategory.FormattingEnabled = true;
            this.cmbBillCategory.Location = new System.Drawing.Point(10, 102);
            this.cmbBillCategory.Name = "cmbBillCategory";
            this.cmbBillCategory.Size = new System.Drawing.Size(104, 27);
            this.cmbBillCategory.TabIndex = 12;
            this.cmbBillCategory.Enter += new System.EventHandler(this.cmbBillCategory_Enter);
            this.cmbBillCategory.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbBillCategory_KeyDown);
            this.cmbBillCategory.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbBillCategory_KeyPress);
            this.cmbBillCategory.Leave += new System.EventHandler(this.cmbBillCategory_Leave);
            // 
            // lblCustomerId
            // 
            this.lblCustomerId.AutoSize = true;
            this.lblCustomerId.Location = new System.Drawing.Point(339, 79);
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
            this.lblDays.Location = new System.Drawing.Point(549, 132);
            this.lblDays.Name = "lblDays";
            this.lblDays.Size = new System.Drawing.Size(90, 15);
            this.lblDays.TabIndex = 111111214;
            this.lblDays.Text = "Su,Mo,Tu,We,Th,Fr,Sa";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(230, 79);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 20);
            this.label6.TabIndex = 111111216;
            this.label6.Text = "Customer Name";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(545, 79);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 20);
            this.label11.TabIndex = 111111213;
            this.label11.Text = "Days";
            // 
            // txtCustomer
            // 
            this.txtCustomer.Location = new System.Drawing.Point(230, 102);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(212, 27);
            this.txtCustomer.TabIndex = 14;
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
            this.cmbMultiSelectDays.Location = new System.Drawing.Point(545, 102);
            this.cmbMultiSelectDays.Name = "cmbMultiSelectDays";
            this.cmbMultiSelectDays.Size = new System.Drawing.Size(94, 27);
            this.cmbMultiSelectDays.TabIndex = 16;
            this.cmbMultiSelectDays.Enter += new System.EventHandler(this.cmbMultiSelectDays_Enter);
            this.cmbMultiSelectDays.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbMultiSelectDays_KeyDown);
            this.cmbMultiSelectDays.Leave += new System.EventHandler(this.cmbMultiSelectDays_Leave);
            // 
            // lblMonths
            // 
            this.lblMonths.AutoSize = true;
            this.lblMonths.Font = new System.Drawing.Font("Oswald Regular", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonths.Location = new System.Drawing.Point(645, 132);
            this.lblMonths.Name = "lblMonths";
            this.lblMonths.Size = new System.Drawing.Size(234, 15);
            this.lblMonths.TabIndex = 111111212;
            this.lblMonths.Text = "Jan, Feb, Mar, Apr, May, Jun, Jul, Aug, Sep, Oct, Nov, Dec";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(647, 79);
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
            this.cmbMultiMonths.Location = new System.Drawing.Point(647, 102);
            this.cmbMultiMonths.Name = "cmbMultiMonths";
            this.cmbMultiMonths.Size = new System.Drawing.Size(94, 27);
            this.cmbMultiMonths.TabIndex = 17;
            this.cmbMultiMonths.Enter += new System.EventHandler(this.cmbMultiMonths_Enter);
            this.cmbMultiMonths.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbMultiMonths_KeyDown);
            this.cmbMultiMonths.Leave += new System.EventHandler(this.cmbMultiMonths_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(958, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 111111208;
            this.label1.Text = "Scheme Type";
            // 
            // cmbSchemeType
            // 
            this.cmbSchemeType.FormattingEnabled = true;
            this.cmbSchemeType.Location = new System.Drawing.Point(958, 43);
            this.cmbSchemeType.Name = "cmbSchemeType";
            this.cmbSchemeType.Size = new System.Drawing.Size(164, 27);
            this.cmbSchemeType.TabIndex = 10;
            this.cmbSchemeType.Enter += new System.EventHandler(this.cmbSchemeType_Enter);
            this.cmbSchemeType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbSchemeType_KeyDown);
            this.cmbSchemeType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbSchemeType_KeyPress);
            this.cmbSchemeType.Leave += new System.EventHandler(this.cmbSchemeType_Leave);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(747, 79);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(64, 20);
            this.label18.TabIndex = 111111206;
            this.label18.Text = "Print Type";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(647, 20);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(49, 20);
            this.label17.TabIndex = 111111203;
            this.label17.Text = "To Time";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(545, 20);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(64, 20);
            this.label16.TabIndex = 111111202;
            this.label16.Text = "From Time";
            // 
            // cmbPrintType
            // 
            this.cmbPrintType.FormattingEnabled = true;
            this.cmbPrintType.Location = new System.Drawing.Point(747, 102);
            this.cmbPrintType.Name = "cmbPrintType";
            this.cmbPrintType.Size = new System.Drawing.Size(205, 27);
            this.cmbPrintType.TabIndex = 18;
            this.cmbPrintType.Enter += new System.EventHandler(this.cmbPrintType_Enter);
            this.cmbPrintType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbPrintType_KeyDown);
            this.cmbPrintType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbPrintType_KeyPress);
            this.cmbPrintType.Leave += new System.EventHandler(this.cmbPrintType_Leave);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(852, 20);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(54, 20);
            this.label13.TabIndex = 111111196;
            this.label13.Text = "Bill Type";
            // 
            // cmbBillType
            // 
            this.cmbBillType.FormattingEnabled = true;
            this.cmbBillType.Location = new System.Drawing.Point(852, 43);
            this.cmbBillType.Name = "cmbBillType";
            this.cmbBillType.Size = new System.Drawing.Size(100, 27);
            this.cmbBillType.TabIndex = 9;
            this.cmbBillType.Enter += new System.EventHandler(this.cmbBillType_Enter);
            this.cmbBillType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbBillType_KeyDown);
            this.cmbBillType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbBillType_KeyPress);
            this.cmbBillType.Leave += new System.EventHandler(this.cmbBillType_Leave);
            // 
            // cmbSalesType
            // 
            this.cmbSalesType.FormattingEnabled = true;
            this.cmbSalesType.Location = new System.Drawing.Point(747, 43);
            this.cmbSalesType.Name = "cmbSalesType";
            this.cmbSalesType.Size = new System.Drawing.Size(99, 27);
            this.cmbSalesType.TabIndex = 8;
            this.cmbSalesType.Enter += new System.EventHandler(this.cmbSalesType_Enter);
            this.cmbSalesType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbSalesType_KeyDown);
            this.cmbSalesType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbSalesType_KeyPress);
            this.cmbSalesType.Leave += new System.EventHandler(this.cmbSalesType_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(339, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 20);
            this.label2.TabIndex = 111111185;
            this.label2.Text = "To Date";
            // 
            // dpToDate
            // 
            this.dpToDate.CustomFormat = "dd/MM/yyyy";
            this.dpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpToDate.Location = new System.Drawing.Point(339, 43);
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
            this.btnTelegram.Location = new System.Drawing.Point(996, 101);
            this.btnTelegram.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnTelegram.Name = "btnTelegram";
            this.btnTelegram.Size = new System.Drawing.Size(33, 29);
            this.btnTelegram.TabIndex = 20;
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
            this.cmbReportType.Size = new System.Drawing.Size(218, 27);
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
            this.label7.Location = new System.Drawing.Point(747, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 20);
            this.label7.TabIndex = 111111180;
            this.label7.Text = "Sales Type";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(230, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 20);
            this.label3.TabIndex = 111111176;
            this.label3.Text = "From Date";
            // 
            // dpFromDate
            // 
            this.dpFromDate.CustomFormat = "dd/MM/yyyy";
            this.dpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpFromDate.Location = new System.Drawing.Point(230, 43);
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
            this.btnView.Location = new System.Drawing.Point(958, 101);
            this.btnView.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(32, 29);
            this.btnView.TabIndex = 19;
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
            // REPORT_SALES_SummaryDetail
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
            this.Name = "REPORT_SALES_SummaryDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Price List Report";
            this.Load += new System.EventHandler(this.REPORT_GRNSummary_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.REPORT_GRNSummary_KeyDown);
            this.ReportSupplier.ResumeLayout(false);
            this.ReportSupplier.PerformLayout();
            this.pnlReportStockLocation.ResumeLayout(false);
            this.pnlReportStockLocation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_BilledBy)).EndInit();
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
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox cmbPrintType;
        private System.Windows.Forms.ComboBox cmbSchemeType;
        private System.Windows.Forms.Label label1;
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
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbBillCategory;
        private System.Windows.Forms.ComboBox cmbCustomerCategory;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtBilledBy;
        public System.Windows.Forms.DataGridView DGV_BilledBy;
        public System.Windows.Forms.Label lblBilledByID;
        private System.Windows.Forms.CheckBox chkTimeRange;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbDayFilter;
        private System.Windows.Forms.ComboBox cmbFormat1;
        private System.Windows.Forms.MaskedTextBox mtbTime1;
        private System.Windows.Forms.ComboBox cmbFormat2;
        private System.Windows.Forms.MaskedTextBox mtbTime2;
    }
}