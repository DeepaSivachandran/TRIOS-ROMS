namespace ROMS
{
    partial class REPORT_SALES_Area
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(REPORT_SALES_Area));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle115 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle116 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle117 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle109 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle110 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle111 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle112 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle113 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle114 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tpRouteReport = new System.Windows.Forms.ToolStrip();
            this.tsbPrintFormat = new System.Windows.Forms.ToolStripButton();
            this.tsbFormat = new System.Windows.Forms.ToolStripButton();
            this.tsLabelPlaceholder = new System.Windows.Forms.ToolStripLabel();
            this.pnlReportArea = new System.Windows.Forms.Panel();
            this.DGV_FilterRoute = new System.Windows.Forms.DataGridView();
            this.grpfilter = new System.Windows.Forms.GroupBox();
            this.lblRouteId = new System.Windows.Forms.Label();
            this.txtRoute = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnListPrint = new System.Windows.Forms.Button();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblNoRecordsFound = new System.Windows.Forms.Label();
            this.picLoader = new System.Windows.Forms.PictureBox();
            this.RPTViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.lblAreaId = new System.Windows.Forms.Label();
            this.txtArea = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.DGV_FilterArea = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbReportType = new System.Windows.Forms.ComboBox();
            this.lblCustomerId = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.DGV_Customer = new System.Windows.Forms.DataGridView();
            this.cmbCustomerType = new System.Windows.Forms.ComboBox();
            this.cmbCustomerCategory = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.epReport = new System.Windows.Forms.ErrorProvider(this.components);
            this.dynamicLabelControl = new ROMS.DynamicToolStripLabelControl();
            this.tpRouteReport.SuspendLayout();
            this.pnlReportArea.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_FilterRoute)).BeginInit();
            this.grpfilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_FilterArea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Customer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epReport)).BeginInit();
            this.SuspendLayout();
            // 
            // tpRouteReport
            // 
            this.tpRouteReport.BackColor = System.Drawing.Color.White;
            this.tpRouteReport.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpRouteReport.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tpRouteReport.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tpRouteReport.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbPrintFormat,
            this.tsbFormat,
            this.tsLabelPlaceholder});
            this.tpRouteReport.Location = new System.Drawing.Point(0, 0);
            this.tpRouteReport.Name = "tpRouteReport";
            this.tpRouteReport.Size = new System.Drawing.Size(1354, 27);
            this.tpRouteReport.TabIndex = 35;
            this.tpRouteReport.Text = "City Report";
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
            // pnlReportArea
            // 
            this.pnlReportArea.BackColor = System.Drawing.Color.White;
            this.pnlReportArea.Controls.Add(this.DGV_FilterArea);
            this.pnlReportArea.Controls.Add(this.DGV_Customer);
            this.pnlReportArea.Controls.Add(this.DGV_FilterRoute);
            this.pnlReportArea.Controls.Add(this.grpfilter);
            this.pnlReportArea.Controls.Add(this.lblNoRecordsFound);
            this.pnlReportArea.Controls.Add(this.picLoader);
            this.pnlReportArea.Controls.Add(this.RPTViewer);
            this.pnlReportArea.Location = new System.Drawing.Point(0, 29);
            this.pnlReportArea.Name = "pnlReportArea";
            this.pnlReportArea.Size = new System.Drawing.Size(1354, 643);
            this.pnlReportArea.TabIndex = 958788;
            // 
            // DGV_FilterRoute
            // 
            this.DGV_FilterRoute.AllowUserToAddRows = false;
            this.DGV_FilterRoute.AllowUserToDeleteRows = false;
            this.DGV_FilterRoute.AllowUserToResizeColumns = false;
            this.DGV_FilterRoute.AllowUserToResizeRows = false;
            this.DGV_FilterRoute.BackgroundColor = System.Drawing.Color.White;
            this.DGV_FilterRoute.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle115.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle115.BackColor = System.Drawing.Color.Chocolate;
            dataGridViewCellStyle115.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle115.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle115.SelectionBackColor = System.Drawing.Color.Chocolate;
            dataGridViewCellStyle115.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle115.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_FilterRoute.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle115;
            this.DGV_FilterRoute.ColumnHeadersHeight = 30;
            this.DGV_FilterRoute.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle116.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle116.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle116.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle116.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle116.SelectionBackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle116.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle116.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV_FilterRoute.DefaultCellStyle = dataGridViewCellStyle116;
            this.DGV_FilterRoute.EnableHeadersVisualStyles = false;
            this.DGV_FilterRoute.GridColor = System.Drawing.Color.White;
            this.DGV_FilterRoute.Location = new System.Drawing.Point(317, 72);
            this.DGV_FilterRoute.Name = "DGV_FilterRoute";
            this.DGV_FilterRoute.ReadOnly = true;
            this.DGV_FilterRoute.RowHeadersVisible = false;
            this.DGV_FilterRoute.RowHeadersWidth = 51;
            dataGridViewCellStyle117.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle117.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.DGV_FilterRoute.RowsDefaultCellStyle = dataGridViewCellStyle117;
            this.DGV_FilterRoute.RowTemplate.Height = 25;
            this.DGV_FilterRoute.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV_FilterRoute.Size = new System.Drawing.Size(197, 226);
            this.DGV_FilterRoute.TabIndex = 111111170;
            this.DGV_FilterRoute.Visible = false;
            this.DGV_FilterRoute.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_FilterRoute_CellDoubleClick);
            this.DGV_FilterRoute.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DGV_FilterRoute_KeyDown);
            // 
            // grpfilter
            // 
            this.grpfilter.Controls.Add(this.label5);
            this.grpfilter.Controls.Add(this.label4);
            this.grpfilter.Controls.Add(this.lblRouteId);
            this.grpfilter.Controls.Add(this.lblCustomerId);
            this.grpfilter.Controls.Add(this.lblAreaId);
            this.grpfilter.Controls.Add(this.cmbCustomerCategory);
            this.grpfilter.Controls.Add(this.btnListPrint);
            this.grpfilter.Controls.Add(this.cmbCustomerType);
            this.grpfilter.Controls.Add(this.label6);
            this.grpfilter.Controls.Add(this.txtCustomer);
            this.grpfilter.Controls.Add(this.cmbReportType);
            this.grpfilter.Controls.Add(this.label3);
            this.grpfilter.Controls.Add(this.lblStatus);
            this.grpfilter.Controls.Add(this.txtRoute);
            this.grpfilter.Controls.Add(this.txtArea);
            this.grpfilter.Controls.Add(this.label1);
            this.grpfilter.Controls.Add(this.cmbStatus);
            this.grpfilter.Controls.Add(this.label2);
            this.grpfilter.Location = new System.Drawing.Point(3, 0);
            this.grpfilter.Name = "grpfilter";
            this.grpfilter.Size = new System.Drawing.Size(1348, 85);
            this.grpfilter.TabIndex = 0;
            this.grpfilter.TabStop = false;
            this.grpfilter.Text = "Filter By";
            // 
            // lblRouteId
            // 
            this.lblRouteId.AutoSize = true;
            this.lblRouteId.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRouteId.Location = new System.Drawing.Point(422, 22);
            this.lblRouteId.Name = "lblRouteId";
            this.lblRouteId.Size = new System.Drawing.Size(16, 20);
            this.lblRouteId.TabIndex = 111111222;
            this.lblRouteId.Text = "0";
            this.lblRouteId.Visible = false;
            // 
            // txtRoute
            // 
            this.txtRoute.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtRoute.Location = new System.Drawing.Point(314, 45);
            this.txtRoute.MaxLength = 100;
            this.txtRoute.Name = "txtRoute";
            this.txtRoute.Size = new System.Drawing.Size(189, 27);
            this.txtRoute.TabIndex = 1;
            this.txtRoute.TextChanged += new System.EventHandler(this.txtRoute_TextChanged);
            this.txtRoute.Enter += new System.EventHandler(this.txtRoute_Enter);
            this.txtRoute.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRoute_KeyDown);
            this.txtRoute.Leave += new System.EventHandler(this.txtRoute_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(314, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 20);
            this.label1.TabIndex = 1111177;
            this.label1.Text = "Route";
            // 
            // btnListPrint
            // 
            this.btnListPrint.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListPrint.Image = global::ROMS.Properties.Resources.view;
            this.btnListPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnListPrint.Location = new System.Drawing.Point(1295, 44);
            this.btnListPrint.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnListPrint.Name = "btnListPrint";
            this.btnListPrint.Size = new System.Drawing.Size(31, 29);
            this.btnListPrint.TabIndex = 7;
            this.btnListPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnListPrint.UseVisualStyleBackColor = true;
            this.btnListPrint.Click += new System.EventHandler(this.BtnListPrint_Click);
            this.btnListPrint.Enter += new System.EventHandler(this.BtnListPrint_Enter);
            this.btnListPrint.Leave += new System.EventHandler(this.BtnListPrint_Leave);
            // 
            // cmbStatus
            // 
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(1163, 45);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(126, 27);
            this.cmbStatus.TabIndex = 6;
            this.cmbStatus.SelectedIndexChanged += new System.EventHandler(this.CmbStatus_SelectedIndexChanged);
            this.cmbStatus.Enter += new System.EventHandler(this.CmbStatus_Enter);
            this.cmbStatus.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbStatus_KeyDown);
            this.cmbStatus.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbStatus_KeyPress);
            this.cmbStatus.Leave += new System.EventHandler(this.CmbStatus_Leave);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(1159, 22);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(45, 20);
            this.lblStatus.TabIndex = 1111176;
            this.lblStatus.Text = "Status";
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
            this.picLoader.Location = new System.Drawing.Point(3, 91);
            this.picLoader.Name = "picLoader";
            this.picLoader.Size = new System.Drawing.Size(1351, 551);
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
            this.RPTViewer.Location = new System.Drawing.Point(3, 91);
            this.RPTViewer.Name = "RPTViewer";
            this.RPTViewer.ReuseParameterValuesOnRefresh = true;
            this.RPTViewer.Size = new System.Drawing.Size(1348, 548);
            this.RPTViewer.TabIndex = 1111227;
            this.RPTViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.RPTViewer.Visible = false;
            // 
            // lblAreaId
            // 
            this.lblAreaId.AutoSize = true;
            this.lblAreaId.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAreaId.Location = new System.Drawing.Point(612, 22);
            this.lblAreaId.Name = "lblAreaId";
            this.lblAreaId.Size = new System.Drawing.Size(16, 20);
            this.lblAreaId.TabIndex = 111111228;
            this.lblAreaId.Text = "0";
            this.lblAreaId.Visible = false;
            // 
            // txtArea
            // 
            this.txtArea.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtArea.Location = new System.Drawing.Point(509, 45);
            this.txtArea.MaxLength = 100;
            this.txtArea.Name = "txtArea";
            this.txtArea.Size = new System.Drawing.Size(189, 27);
            this.txtArea.TabIndex = 2;
            this.txtArea.TextChanged += new System.EventHandler(this.txtArea_TextChanged);
            this.txtArea.Enter += new System.EventHandler(this.txtArea_Enter);
            this.txtArea.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtArea_KeyDown);
            this.txtArea.Leave += new System.EventHandler(this.txtArea_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(509, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 20);
            this.label2.TabIndex = 111111227;
            this.label2.Text = "Area";
            // 
            // DGV_FilterArea
            // 
            this.DGV_FilterArea.AllowUserToAddRows = false;
            this.DGV_FilterArea.AllowUserToDeleteRows = false;
            this.DGV_FilterArea.AllowUserToResizeColumns = false;
            this.DGV_FilterArea.AllowUserToResizeRows = false;
            this.DGV_FilterArea.BackgroundColor = System.Drawing.Color.White;
            this.DGV_FilterArea.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle109.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle109.BackColor = System.Drawing.Color.Chocolate;
            dataGridViewCellStyle109.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle109.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle109.SelectionBackColor = System.Drawing.Color.Chocolate;
            dataGridViewCellStyle109.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle109.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_FilterArea.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle109;
            this.DGV_FilterArea.ColumnHeadersHeight = 30;
            this.DGV_FilterArea.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle110.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle110.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle110.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle110.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle110.SelectionBackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle110.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle110.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV_FilterArea.DefaultCellStyle = dataGridViewCellStyle110;
            this.DGV_FilterArea.EnableHeadersVisualStyles = false;
            this.DGV_FilterArea.GridColor = System.Drawing.Color.White;
            this.DGV_FilterArea.Location = new System.Drawing.Point(512, 72);
            this.DGV_FilterArea.Name = "DGV_FilterArea";
            this.DGV_FilterArea.ReadOnly = true;
            this.DGV_FilterArea.RowHeadersVisible = false;
            this.DGV_FilterArea.RowHeadersWidth = 51;
            dataGridViewCellStyle111.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle111.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.DGV_FilterArea.RowsDefaultCellStyle = dataGridViewCellStyle111;
            this.DGV_FilterArea.RowTemplate.Height = 25;
            this.DGV_FilterArea.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV_FilterArea.Size = new System.Drawing.Size(197, 226);
            this.DGV_FilterArea.TabIndex = 111111226;
            this.DGV_FilterArea.Visible = false;
            this.DGV_FilterArea.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_FilterArea_CellDoubleClick);
            this.DGV_FilterArea.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DGV_FilterArea_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 20);
            this.label3.TabIndex = 111111228;
            this.label3.Text = "Report Type";
            // 
            // cmbReportType
            // 
            this.cmbReportType.FormattingEnabled = true;
            this.cmbReportType.Location = new System.Drawing.Point(9, 45);
            this.cmbReportType.Name = "cmbReportType";
            this.cmbReportType.Size = new System.Drawing.Size(299, 27);
            this.cmbReportType.TabIndex = 0;
            this.cmbReportType.SelectedIndexChanged += new System.EventHandler(this.cmbReportType_SelectedIndexChanged);
            this.cmbReportType.Enter += new System.EventHandler(this.cmbReportType_Enter);
            this.cmbReportType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbReportType_KeyDown);
            this.cmbReportType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbReportType_KeyPress);
            this.cmbReportType.Leave += new System.EventHandler(this.cmbReportType_Leave);
            // 
            // lblCustomerId
            // 
            this.lblCustomerId.AutoSize = true;
            this.lblCustomerId.Location = new System.Drawing.Point(833, 22);
            this.lblCustomerId.Name = "lblCustomerId";
            this.lblCustomerId.Size = new System.Drawing.Size(16, 20);
            this.lblCustomerId.TabIndex = 111111232;
            this.lblCustomerId.Text = "0";
            this.lblCustomerId.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(704, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 20);
            this.label6.TabIndex = 111111231;
            this.label6.Text = "Customer Name";
            // 
            // txtCustomer
            // 
            this.txtCustomer.Location = new System.Drawing.Point(704, 45);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(189, 27);
            this.txtCustomer.TabIndex = 3;
            this.txtCustomer.TextChanged += new System.EventHandler(this.txtCustomer_TextChanged);
            this.txtCustomer.Enter += new System.EventHandler(this.txtCustomer_Enter);
            this.txtCustomer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCustomer_KeyDown);
            this.txtCustomer.Leave += new System.EventHandler(this.txtCustomer_Leave);
            // 
            // DGV_Customer
            // 
            this.DGV_Customer.AllowUserToAddRows = false;
            this.DGV_Customer.AllowUserToDeleteRows = false;
            this.DGV_Customer.AllowUserToResizeColumns = false;
            this.DGV_Customer.AllowUserToResizeRows = false;
            this.DGV_Customer.BackgroundColor = System.Drawing.Color.White;
            this.DGV_Customer.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle112.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle112.BackColor = System.Drawing.Color.Chocolate;
            dataGridViewCellStyle112.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle112.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle112.SelectionBackColor = System.Drawing.Color.Chocolate;
            dataGridViewCellStyle112.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle112.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_Customer.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle112;
            this.DGV_Customer.ColumnHeadersHeight = 30;
            this.DGV_Customer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle113.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle113.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle113.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle113.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle113.SelectionBackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle113.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle113.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV_Customer.DefaultCellStyle = dataGridViewCellStyle113;
            this.DGV_Customer.EnableHeadersVisualStyles = false;
            this.DGV_Customer.GridColor = System.Drawing.Color.White;
            this.DGV_Customer.Location = new System.Drawing.Point(707, 72);
            this.DGV_Customer.Name = "DGV_Customer";
            this.DGV_Customer.ReadOnly = true;
            this.DGV_Customer.RowHeadersVisible = false;
            this.DGV_Customer.RowHeadersWidth = 51;
            dataGridViewCellStyle114.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle114.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.DGV_Customer.RowsDefaultCellStyle = dataGridViewCellStyle114;
            this.DGV_Customer.RowTemplate.Height = 25;
            this.DGV_Customer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV_Customer.Size = new System.Drawing.Size(237, 226);
            this.DGV_Customer.TabIndex = 111111233;
            this.DGV_Customer.Visible = false;
            this.DGV_Customer.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_Customer_CellDoubleClick);
            this.DGV_Customer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DGV_Customer_KeyDown);
            // 
            // cmbCustomerType
            // 
            this.cmbCustomerType.FormattingEnabled = true;
            this.cmbCustomerType.Location = new System.Drawing.Point(899, 45);
            this.cmbCustomerType.Name = "cmbCustomerType";
            this.cmbCustomerType.Size = new System.Drawing.Size(126, 27);
            this.cmbCustomerType.TabIndex = 4;
            this.cmbCustomerType.Enter += new System.EventHandler(this.cmbCustomerType_Enter);
            this.cmbCustomerType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbCustomerType_KeyDown);
            this.cmbCustomerType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbCustomerType_KeyPress);
            this.cmbCustomerType.Leave += new System.EventHandler(this.cmbCustomerType_Leave);
            // 
            // cmbCustomerCategory
            // 
            this.cmbCustomerCategory.FormattingEnabled = true;
            this.cmbCustomerCategory.Location = new System.Drawing.Point(1031, 45);
            this.cmbCustomerCategory.Name = "cmbCustomerCategory";
            this.cmbCustomerCategory.Size = new System.Drawing.Size(126, 27);
            this.cmbCustomerCategory.TabIndex = 5;
            this.cmbCustomerCategory.Enter += new System.EventHandler(this.cmbCustomerCategory_Enter);
            this.cmbCustomerCategory.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbCustomerCategory_KeyDown);
            this.cmbCustomerCategory.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbCustomerCategory_KeyPress);
            this.cmbCustomerCategory.Leave += new System.EventHandler(this.cmbCustomerCategory_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(1031, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 20);
            this.label4.TabIndex = 111111234;
            this.label4.Text = "Customer Category";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(899, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 20);
            this.label5.TabIndex = 111111235;
            this.label5.Text = "Customer Type";
            // 
            // epReport
            // 
            this.epReport.ContainerControl = this;
            // 
            // dynamicLabelControl
            // 
            this.dynamicLabelControl.PlaceholderLabel = null;
            // 
            // REPORT_SALES_Area
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(1354, 675);
            this.Controls.Add(this.pnlReportArea);
            this.Controls.Add(this.tpRouteReport);
            this.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "REPORT_SALES_Area";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Area Report";
            this.Load += new System.EventHandler(this.REPORT_CP_Route_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.REPORT_CP_Route_KeyDown);
            this.tpRouteReport.ResumeLayout(false);
            this.tpRouteReport.PerformLayout();
            this.pnlReportArea.ResumeLayout(false);
            this.pnlReportArea.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_FilterRoute)).EndInit();
            this.grpfilter.ResumeLayout(false);
            this.grpfilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_FilterArea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Customer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epReport)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tpRouteReport;
        private System.Windows.Forms.Panel pnlReportArea;
        private System.Windows.Forms.Label lblNoRecordsFound;
        private System.Windows.Forms.GroupBox grpfilter;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label lblStatus;
        public System.Windows.Forms.PictureBox picLoader;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer RPTViewer;
        private System.Windows.Forms.Button btnListPrint;
        public System.Windows.Forms.ToolStripButton tsbPrintFormat;
        public System.Windows.Forms.ToolStripButton tsbFormat;
        private System.Windows.Forms.ToolStripLabel tsLabelPlaceholder;
        private DynamicToolStripLabelControl dynamicLabelControl;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.DataGridView DGV_FilterRoute;
        private System.Windows.Forms.TextBox txtRoute;
        private System.Windows.Forms.Label lblRouteId;
        private System.Windows.Forms.Label lblAreaId;
        private System.Windows.Forms.TextBox txtArea;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.DataGridView DGV_FilterArea;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbReportType;
        public System.Windows.Forms.Label lblCustomerId;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCustomer;
        public System.Windows.Forms.DataGridView DGV_Customer;
        private System.Windows.Forms.ComboBox cmbCustomerCategory;
        private System.Windows.Forms.ComboBox cmbCustomerType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ErrorProvider epReport;
    }
}