namespace ROMS
{
    partial class REPORT_Stock_Valuation_DateWise
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(REPORT_Stock_Valuation_DateWise));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle37 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle38 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle39 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle40 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle41 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle42 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tsDateWiseStockValuationReport = new System.Windows.Forms.ToolStrip();
            this.tsbPrintFormat = new System.Windows.Forms.ToolStripButton();
            this.tsbFormat = new System.Windows.Forms.ToolStripButton();
            this.tsLabelPlaceholder = new System.Windows.Forms.ToolStripLabel();
            this.pnlReportStockLocation = new System.Windows.Forms.Panel();
            this.DGV_FilterSubgroup = new System.Windows.Forms.DataGridView();
            this.DGV_FilterGroup = new System.Windows.Forms.DataGridView();
            this.grpfilter = new System.Windows.Forms.GroupBox();
            this.txtGroup = new System.Windows.Forms.TextBox();
            this.lblGroup = new System.Windows.Forms.Label();
            this.cmbReportType = new System.Windows.Forms.ComboBox();
            this.lblGroupCode = new System.Windows.Forms.Label();
            this.lblReportType = new System.Windows.Forms.Label();
            this.lblSubGroupCode = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtSubGroup = new System.Windows.Forms.TextBox();
            this.lblSubgroup = new System.Windows.Forms.Label();
            this.cmbConcern = new System.Windows.Forms.ComboBox();
            this.btnView = new System.Windows.Forms.Button();
            this.lblNoRecordsFound = new System.Windows.Forms.Label();
            this.picLoader = new System.Windows.Forms.PictureBox();
            this.RPTViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.epReport = new System.Windows.Forms.ErrorProvider(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.dpFromDate = new System.Windows.Forms.DateTimePicker();
            this.dynamicLabelControl = new ROMS.DynamicToolStripLabelControl();
            this.btnTelegram = new System.Windows.Forms.Button();
            this.tsDateWiseStockValuationReport.SuspendLayout();
            this.pnlReportStockLocation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_FilterSubgroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_FilterGroup)).BeginInit();
            this.grpfilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epReport)).BeginInit();
            this.SuspendLayout();
            // 
            // tsDateWiseStockValuationReport
            // 
            this.tsDateWiseStockValuationReport.BackColor = System.Drawing.Color.White;
            this.tsDateWiseStockValuationReport.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsDateWiseStockValuationReport.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsDateWiseStockValuationReport.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsDateWiseStockValuationReport.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbPrintFormat,
            this.tsbFormat,
            this.tsLabelPlaceholder});
            this.tsDateWiseStockValuationReport.Location = new System.Drawing.Point(0, 0);
            this.tsDateWiseStockValuationReport.Name = "tsDateWiseStockValuationReport";
            this.tsDateWiseStockValuationReport.Size = new System.Drawing.Size(1354, 27);
            this.tsDateWiseStockValuationReport.TabIndex = 35;
            this.tsDateWiseStockValuationReport.Text = "GRN Summary Report";
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
            this.pnlReportStockLocation.Controls.Add(this.DGV_FilterSubgroup);
            this.pnlReportStockLocation.Controls.Add(this.DGV_FilterGroup);
            this.pnlReportStockLocation.Controls.Add(this.grpfilter);
            this.pnlReportStockLocation.Controls.Add(this.lblNoRecordsFound);
            this.pnlReportStockLocation.Controls.Add(this.picLoader);
            this.pnlReportStockLocation.Controls.Add(this.RPTViewer);
            this.pnlReportStockLocation.Location = new System.Drawing.Point(0, 29);
            this.pnlReportStockLocation.Name = "pnlReportStockLocation";
            this.pnlReportStockLocation.Size = new System.Drawing.Size(1354, 646);
            this.pnlReportStockLocation.TabIndex = 0;
            // 
            // DGV_FilterSubgroup
            // 
            this.DGV_FilterSubgroup.AllowUserToAddRows = false;
            this.DGV_FilterSubgroup.AllowUserToDeleteRows = false;
            this.DGV_FilterSubgroup.AllowUserToResizeColumns = false;
            this.DGV_FilterSubgroup.AllowUserToResizeRows = false;
            this.DGV_FilterSubgroup.BackgroundColor = System.Drawing.Color.White;
            this.DGV_FilterSubgroup.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle37.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle37.BackColor = System.Drawing.Color.Chocolate;
            dataGridViewCellStyle37.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle37.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle37.SelectionBackColor = System.Drawing.Color.Chocolate;
            dataGridViewCellStyle37.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle37.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_FilterSubgroup.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle37;
            this.DGV_FilterSubgroup.ColumnHeadersHeight = 30;
            this.DGV_FilterSubgroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle38.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle38.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle38.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle38.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle38.SelectionBackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle38.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle38.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV_FilterSubgroup.DefaultCellStyle = dataGridViewCellStyle38;
            this.DGV_FilterSubgroup.EnableHeadersVisualStyles = false;
            this.DGV_FilterSubgroup.GridColor = System.Drawing.Color.White;
            this.DGV_FilterSubgroup.Location = new System.Drawing.Point(645, 72);
            this.DGV_FilterSubgroup.Name = "DGV_FilterSubgroup";
            this.DGV_FilterSubgroup.ReadOnly = true;
            this.DGV_FilterSubgroup.RowHeadersVisible = false;
            this.DGV_FilterSubgroup.RowHeadersWidth = 51;
            dataGridViewCellStyle39.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle39.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.DGV_FilterSubgroup.RowsDefaultCellStyle = dataGridViewCellStyle39;
            this.DGV_FilterSubgroup.RowTemplate.Height = 25;
            this.DGV_FilterSubgroup.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV_FilterSubgroup.Size = new System.Drawing.Size(385, 226);
            this.DGV_FilterSubgroup.TabIndex = 111111186;
            this.DGV_FilterSubgroup.Visible = false;
            this.DGV_FilterSubgroup.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_FilterSubgroup_CellDoubleClick);
            this.DGV_FilterSubgroup.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DGV_FilterSubgroup_KeyDown);
            // 
            // DGV_FilterGroup
            // 
            this.DGV_FilterGroup.AllowUserToAddRows = false;
            this.DGV_FilterGroup.AllowUserToDeleteRows = false;
            this.DGV_FilterGroup.AllowUserToResizeColumns = false;
            this.DGV_FilterGroup.AllowUserToResizeRows = false;
            this.DGV_FilterGroup.BackgroundColor = System.Drawing.Color.White;
            this.DGV_FilterGroup.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle40.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle40.BackColor = System.Drawing.Color.Chocolate;
            dataGridViewCellStyle40.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle40.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle40.SelectionBackColor = System.Drawing.Color.Chocolate;
            dataGridViewCellStyle40.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle40.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_FilterGroup.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle40;
            this.DGV_FilterGroup.ColumnHeadersHeight = 30;
            this.DGV_FilterGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle41.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle41.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle41.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle41.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle41.SelectionBackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle41.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle41.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV_FilterGroup.DefaultCellStyle = dataGridViewCellStyle41;
            this.DGV_FilterGroup.EnableHeadersVisualStyles = false;
            this.DGV_FilterGroup.GridColor = System.Drawing.Color.White;
            this.DGV_FilterGroup.Location = new System.Drawing.Point(453, 72);
            this.DGV_FilterGroup.Name = "DGV_FilterGroup";
            this.DGV_FilterGroup.ReadOnly = true;
            this.DGV_FilterGroup.RowHeadersVisible = false;
            this.DGV_FilterGroup.RowHeadersWidth = 51;
            dataGridViewCellStyle42.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle42.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.DGV_FilterGroup.RowsDefaultCellStyle = dataGridViewCellStyle42;
            this.DGV_FilterGroup.RowTemplate.Height = 25;
            this.DGV_FilterGroup.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV_FilterGroup.Size = new System.Drawing.Size(291, 226);
            this.DGV_FilterGroup.TabIndex = 111111185;
            this.DGV_FilterGroup.Visible = false;
            this.DGV_FilterGroup.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_FilterGroup_CellDoubleClick);
            this.DGV_FilterGroup.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DGV_FilterGroup_KeyDown);
            // 
            // grpfilter
            // 
            this.grpfilter.Controls.Add(this.btnTelegram);
            this.grpfilter.Controls.Add(this.label1);
            this.grpfilter.Controls.Add(this.dpFromDate);
            this.grpfilter.Controls.Add(this.txtGroup);
            this.grpfilter.Controls.Add(this.lblGroup);
            this.grpfilter.Controls.Add(this.cmbReportType);
            this.grpfilter.Controls.Add(this.lblGroupCode);
            this.grpfilter.Controls.Add(this.lblReportType);
            this.grpfilter.Controls.Add(this.lblSubGroupCode);
            this.grpfilter.Controls.Add(this.label10);
            this.grpfilter.Controls.Add(this.txtSubGroup);
            this.grpfilter.Controls.Add(this.lblSubgroup);
            this.grpfilter.Controls.Add(this.cmbConcern);
            this.grpfilter.Controls.Add(this.btnView);
            this.grpfilter.Location = new System.Drawing.Point(12, 2);
            this.grpfilter.Name = "grpfilter";
            this.grpfilter.Size = new System.Drawing.Size(1330, 80);
            this.grpfilter.TabIndex = 0;
            this.grpfilter.TabStop = false;
            this.grpfilter.Text = "Filter By";
            // 
            // txtGroup
            // 
            this.txtGroup.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtGroup.Location = new System.Drawing.Point(441, 43);
            this.txtGroup.MaxLength = 100;
            this.txtGroup.Name = "txtGroup";
            this.txtGroup.Size = new System.Drawing.Size(186, 27);
            this.txtGroup.TabIndex = 3;
            this.txtGroup.TextChanged += new System.EventHandler(this.TxtGroup_TextChanged);
            this.txtGroup.Enter += new System.EventHandler(this.TxtGroup_Enter);
            this.txtGroup.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtGroup_KeyDown);
            this.txtGroup.Leave += new System.EventHandler(this.TxtGroup_Leave);
            // 
            // lblGroup
            // 
            this.lblGroup.AutoSize = true;
            this.lblGroup.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGroup.Location = new System.Drawing.Point(441, 20);
            this.lblGroup.Name = "lblGroup";
            this.lblGroup.Size = new System.Drawing.Size(42, 20);
            this.lblGroup.TabIndex = 111111181;
            this.lblGroup.Text = "Group";
            // 
            // cmbReportType
            // 
            this.cmbReportType.FormattingEnabled = true;
            this.cmbReportType.Location = new System.Drawing.Point(6, 43);
            this.cmbReportType.Name = "cmbReportType";
            this.cmbReportType.Size = new System.Drawing.Size(209, 27);
            this.cmbReportType.TabIndex = 0;
            this.cmbReportType.SelectedIndexChanged += new System.EventHandler(this.CmbReportType_SelectedIndexChanged);
            this.cmbReportType.Enter += new System.EventHandler(this.CmbReportType_Enter);
            this.cmbReportType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbReportType_KeyDown);
            this.cmbReportType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbReportType_KeyPress);
            this.cmbReportType.Leave += new System.EventHandler(this.CmbReportType_Leave);
            // 
            // lblGroupCode
            // 
            this.lblGroupCode.AutoSize = true;
            this.lblGroupCode.Location = new System.Drawing.Point(611, 20);
            this.lblGroupCode.Name = "lblGroupCode";
            this.lblGroupCode.Size = new System.Drawing.Size(16, 20);
            this.lblGroupCode.TabIndex = 111111182;
            this.lblGroupCode.Text = "0";
            this.lblGroupCode.Visible = false;
            // 
            // lblReportType
            // 
            this.lblReportType.AutoSize = true;
            this.lblReportType.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReportType.Location = new System.Drawing.Point(6, 20);
            this.lblReportType.Name = "lblReportType";
            this.lblReportType.Size = new System.Drawing.Size(73, 20);
            this.lblReportType.TabIndex = 111111171;
            this.lblReportType.Text = "Report type";
            // 
            // lblSubGroupCode
            // 
            this.lblSubGroupCode.AutoSize = true;
            this.lblSubGroupCode.Location = new System.Drawing.Point(716, 20);
            this.lblSubGroupCode.Name = "lblSubGroupCode";
            this.lblSubGroupCode.Size = new System.Drawing.Size(16, 20);
            this.lblSubGroupCode.TabIndex = 111111183;
            this.lblSubGroupCode.Text = "0";
            this.lblSubGroupCode.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(221, 20);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 20);
            this.label10.TabIndex = 111111167;
            this.label10.Text = "Concern";
            // 
            // txtSubGroup
            // 
            this.txtSubGroup.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtSubGroup.Location = new System.Drawing.Point(633, 43);
            this.txtSubGroup.MaxLength = 100;
            this.txtSubGroup.Name = "txtSubGroup";
            this.txtSubGroup.Size = new System.Drawing.Size(186, 27);
            this.txtSubGroup.TabIndex = 4;
            this.txtSubGroup.TextChanged += new System.EventHandler(this.TxtSubGroup_TextChanged);
            this.txtSubGroup.Enter += new System.EventHandler(this.TxtSubGroup_Enter);
            this.txtSubGroup.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtSubGroup_KeyDown);
            this.txtSubGroup.Leave += new System.EventHandler(this.TxtSubGroup_Leave);
            // 
            // lblSubgroup
            // 
            this.lblSubgroup.AutoSize = true;
            this.lblSubgroup.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubgroup.Location = new System.Drawing.Point(633, 20);
            this.lblSubgroup.Name = "lblSubgroup";
            this.lblSubgroup.Size = new System.Drawing.Size(62, 20);
            this.lblSubgroup.TabIndex = 111111180;
            this.lblSubgroup.Text = "Subgroup";
            // 
            // cmbConcern
            // 
            this.cmbConcern.FormattingEnabled = true;
            this.cmbConcern.Location = new System.Drawing.Point(221, 43);
            this.cmbConcern.Name = "cmbConcern";
            this.cmbConcern.Size = new System.Drawing.Size(105, 27);
            this.cmbConcern.TabIndex = 1;
            this.cmbConcern.Enter += new System.EventHandler(this.CmbConcern_Enter);
            this.cmbConcern.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbConcern_KeyDown);
            this.cmbConcern.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbConcern_KeyPress);
            this.cmbConcern.Leave += new System.EventHandler(this.CmbConcern_Leave);
            // 
            // btnView
            // 
            this.btnView.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnView.Image = global::ROMS.Properties.Resources.view;
            this.btnView.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnView.Location = new System.Drawing.Point(825, 42);
            this.btnView.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(69, 29);
            this.btnView.TabIndex = 5;
            this.btnView.Text = "View";
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
            this.lblNoRecordsFound.Location = new System.Drawing.Point(624, 355);
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
            this.picLoader.Location = new System.Drawing.Point(12, 88);
            this.picLoader.Name = "picLoader";
            this.picLoader.Size = new System.Drawing.Size(1330, 554);
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
            this.RPTViewer.Location = new System.Drawing.Point(12, 88);
            this.RPTViewer.Name = "RPTViewer";
            this.RPTViewer.ReuseParameterValuesOnRefresh = true;
            this.RPTViewer.Size = new System.Drawing.Size(1330, 551);
            this.RPTViewer.TabIndex = 1111227;
            this.RPTViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.RPTViewer.Visible = false;
            // 
            // epReport
            // 
            this.epReport.ContainerControl = this;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(332, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 20);
            this.label1.TabIndex = 111111186;
            this.label1.Text = "Date";
            // 
            // dpFromDate
            // 
            this.dpFromDate.CustomFormat = "dd/MM/yyyy";
            this.dpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpFromDate.Location = new System.Drawing.Point(332, 43);
            this.dpFromDate.Name = "dpFromDate";
            this.dpFromDate.Size = new System.Drawing.Size(103, 27);
            this.dpFromDate.TabIndex = 2;
            this.dpFromDate.Enter += new System.EventHandler(this.dpFromDate_Enter);
            this.dpFromDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dpFromDate_KeyDown);
            this.dpFromDate.Leave += new System.EventHandler(this.dpFromDate_Leave);
            // 
            // dynamicLabelControl
            // 
            this.dynamicLabelControl.PlaceholderLabel = null;
            // 
            // btnTelegram
            // 
            this.btnTelegram.Image = ((System.Drawing.Image)(resources.GetObject("btnTelegram.Image")));
            this.btnTelegram.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTelegram.Location = new System.Drawing.Point(900, 41);
            this.btnTelegram.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnTelegram.Name = "btnTelegram";
            this.btnTelegram.Size = new System.Drawing.Size(35, 30);
            this.btnTelegram.TabIndex = 6;
            this.btnTelegram.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTelegram.UseVisualStyleBackColor = true;
            this.btnTelegram.Click += new System.EventHandler(this.btnTelegram_Click);
            this.btnTelegram.Enter += new System.EventHandler(this.btnTelegram_Enter);
            this.btnTelegram.Leave += new System.EventHandler(this.btnTelegram_Leave);
            // 
            // REPORT_Stock_Valuation_DateWise
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(1354, 675);
            this.Controls.Add(this.pnlReportStockLocation);
            this.Controls.Add(this.tsDateWiseStockValuationReport);
            this.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "REPORT_Stock_Valuation_DateWise";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stock Aging Report";
            this.Load += new System.EventHandler(this.REPORT_GRNSummary_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.REPORT_GRNSummary_KeyDown);
            this.tsDateWiseStockValuationReport.ResumeLayout(false);
            this.tsDateWiseStockValuationReport.PerformLayout();
            this.pnlReportStockLocation.ResumeLayout(false);
            this.pnlReportStockLocation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_FilterSubgroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_FilterGroup)).EndInit();
            this.grpfilter.ResumeLayout(false);
            this.grpfilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epReport)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsDateWiseStockValuationReport;
        private System.Windows.Forms.Panel pnlReportStockLocation;
        private System.Windows.Forms.Label lblNoRecordsFound;
        private System.Windows.Forms.GroupBox grpfilter;
        public System.Windows.Forms.PictureBox picLoader;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer RPTViewer;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.ComboBox cmbConcern;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ErrorProvider epReport;
        private System.Windows.Forms.ComboBox cmbReportType;
        private System.Windows.Forms.Label lblReportType;
        public System.Windows.Forms.ToolStripButton tsbPrintFormat;
        public System.Windows.Forms.ToolStripButton tsbFormat;
        private System.Windows.Forms.TextBox txtGroup;
        private System.Windows.Forms.Label lblGroup;
        public System.Windows.Forms.DataGridView DGV_FilterGroup;
        private System.Windows.Forms.Label lblGroupCode;
        private System.Windows.Forms.Label lblSubGroupCode;
        private System.Windows.Forms.TextBox txtSubGroup;
        private System.Windows.Forms.Label lblSubgroup;
        public System.Windows.Forms.DataGridView DGV_FilterSubgroup;
        private DynamicToolStripLabelControl dynamicLabelControl;
        private System.Windows.Forms.ToolStripLabel tsLabelPlaceholder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dpFromDate;
        private System.Windows.Forms.Button btnTelegram;
    }
}