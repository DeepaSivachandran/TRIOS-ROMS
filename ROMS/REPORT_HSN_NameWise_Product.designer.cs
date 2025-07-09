namespace ROMS
{
    partial class REPORT_HSN_NameWise_Product
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
            this.ReportHSN = new System.Windows.Forms.ToolStrip();
            this.pnlReportHSN = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.lvproduct = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblProductcode = new System.Windows.Forms.Label();
            this.lvHsnName = new System.Windows.Forms.ListView();
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader30 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader31 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grpfilter = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.cmbSupplierType = new System.Windows.Forms.ComboBox();
            this.txtHsnName = new System.Windows.Forms.TextBox();
            this.dpToDate = new System.Windows.Forms.DateTimePicker();
            this.dpFromDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblHsnName = new System.Windows.Forms.Label();
            this.lblHSN = new System.Windows.Forms.Label();
            this.cmbReportType = new System.Windows.Forms.ComboBox();
            this.lblReportType = new System.Windows.Forms.Label();
            this.lblNoRecordsFound = new System.Windows.Forms.Label();
            this.RPTViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.lblGroupCode = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtGroup = new System.Windows.Forms.TextBox();
            this.lvGroup = new System.Windows.Forms.ListView();
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblSubGroupCode = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSubGroup = new System.Windows.Forms.TextBox();
            this.lvSubGroup = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader28 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader29 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnListPrint = new System.Windows.Forms.Button();
            this.picLoader = new System.Windows.Forms.PictureBox();
            this.tspHeader = new System.Windows.Forms.ToolStripLabel();
            this.ReportHSN.SuspendLayout();
            this.pnlReportHSN.SuspendLayout();
            this.grpfilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).BeginInit();
            this.SuspendLayout();
            // 
            // ReportHSN
            // 
            this.ReportHSN.BackColor = System.Drawing.Color.White;
            this.ReportHSN.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReportHSN.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ReportHSN.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ReportHSN.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspHeader});
            this.ReportHSN.Location = new System.Drawing.Point(0, 0);
            this.ReportHSN.Name = "ReportHSN";
            this.ReportHSN.Size = new System.Drawing.Size(1354, 25);
            this.ReportHSN.TabIndex = 35;
            this.ReportHSN.Text = "HSN Report";
            // 
            // pnlReportHSN
            // 
            this.pnlReportHSN.BackColor = System.Drawing.Color.White;
            this.pnlReportHSN.Controls.Add(this.lvHsnName);
            this.pnlReportHSN.Controls.Add(this.lvGroup);
            this.pnlReportHSN.Controls.Add(this.lblGroupCode);
            this.pnlReportHSN.Controls.Add(this.lvSubGroup);
            this.pnlReportHSN.Controls.Add(this.label4);
            this.pnlReportHSN.Controls.Add(this.lvproduct);
            this.pnlReportHSN.Controls.Add(this.grpfilter);
            this.pnlReportHSN.Controls.Add(this.lblNoRecordsFound);
            this.pnlReportHSN.Controls.Add(this.picLoader);
            this.pnlReportHSN.Controls.Add(this.RPTViewer);
            this.pnlReportHSN.Location = new System.Drawing.Point(0, 29);
            this.pnlReportHSN.Name = "pnlReportHSN";
            this.pnlReportHSN.Size = new System.Drawing.Size(1354, 643);
            this.pnlReportHSN.TabIndex = 958788;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(438, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(132, 20);
            this.label5.TabIndex = 111111150;
            this.label5.Text = "Product Name/PI Code";
            // 
            // lvproduct
            // 
            this.lvproduct.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader8,
            this.columnHeader9});
            this.lvproduct.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.lvproduct.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvproduct.HideSelection = false;
            this.lvproduct.Location = new System.Drawing.Point(446, 127);
            this.lvproduct.Name = "lvproduct";
            this.lvproduct.Size = new System.Drawing.Size(450, 194);
            this.lvproduct.TabIndex = 111111151;
            this.lvproduct.UseCompatibleStateImageBehavior = false;
            this.lvproduct.View = System.Windows.Forms.View.Details;
            this.lvproduct.Visible = false;
            this.lvproduct.DoubleClick += new System.EventHandler(this.Lvproduct_DoubleClick);
            this.lvproduct.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Lvproduct_KeyDown);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 120;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Width = 0;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Width = 0;
            // 
            // lblProductcode
            // 
            this.lblProductcode.AutoSize = true;
            this.lblProductcode.Location = new System.Drawing.Point(587, 77);
            this.lblProductcode.Name = "lblProductcode";
            this.lblProductcode.Size = new System.Drawing.Size(16, 20);
            this.lblProductcode.TabIndex = 111111152;
            this.lblProductcode.Text = "0";
            this.lblProductcode.Visible = false;
            // 
            // lvHsnName
            // 
            this.lvHsnName.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader10,
            this.columnHeader30,
            this.columnHeader31});
            this.lvHsnName.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvHsnName.HideSelection = false;
            this.lvHsnName.Location = new System.Drawing.Point(594, 73);
            this.lvHsnName.Name = "lvHsnName";
            this.lvHsnName.Size = new System.Drawing.Size(328, 178);
            this.lvHsnName.TabIndex = 1111229;
            this.lvHsnName.UseCompatibleStateImageBehavior = false;
            this.lvHsnName.View = System.Windows.Forms.View.Details;
            this.lvHsnName.Visible = false;
            this.lvHsnName.DoubleClick += new System.EventHandler(this.LvHsnName_DoubleClick);
            this.lvHsnName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LvHsnName_KeyDown);
            // 
            // columnHeader10
            // 
            this.columnHeader10.Width = 80;
            // 
            // columnHeader30
            // 
            this.columnHeader30.Width = 80;
            // 
            // columnHeader31
            // 
            this.columnHeader31.Width = 0;
            // 
            // grpfilter
            // 
            this.grpfilter.Controls.Add(this.lblSubGroupCode);
            this.grpfilter.Controls.Add(this.label6);
            this.grpfilter.Controls.Add(this.label5);
            this.grpfilter.Controls.Add(this.txtSubGroup);
            this.grpfilter.Controls.Add(this.label2);
            this.grpfilter.Controls.Add(this.txtProductName);
            this.grpfilter.Controls.Add(this.cmbSupplierType);
            this.grpfilter.Controls.Add(this.lblProductcode);
            this.grpfilter.Controls.Add(this.txtHsnName);
            this.grpfilter.Controls.Add(this.txtGroup);
            this.grpfilter.Controls.Add(this.dpToDate);
            this.grpfilter.Controls.Add(this.dpFromDate);
            this.grpfilter.Controls.Add(this.label3);
            this.grpfilter.Controls.Add(this.label1);
            this.grpfilter.Controls.Add(this.lblHsnName);
            this.grpfilter.Controls.Add(this.lblHSN);
            this.grpfilter.Controls.Add(this.btnListPrint);
            this.grpfilter.Controls.Add(this.cmbReportType);
            this.grpfilter.Controls.Add(this.lblReportType);
            this.grpfilter.Location = new System.Drawing.Point(3, 2);
            this.grpfilter.Name = "grpfilter";
            this.grpfilter.Size = new System.Drawing.Size(1348, 138);
            this.grpfilter.TabIndex = 0;
            this.grpfilter.TabStop = false;
            this.grpfilter.Text = "Filter By";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(438, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 20);
            this.label2.TabIndex = 1111229;
            this.label2.Text = "Supplier Type";
            // 
            // txtProductName
            // 
            this.txtProductName.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtProductName.Location = new System.Drawing.Point(443, 100);
            this.txtProductName.MaxLength = 50;
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(325, 27);
            this.txtProductName.TabIndex = 8;
            this.txtProductName.TextChanged += new System.EventHandler(this.TxtProductName_TextChanged);
            this.txtProductName.Enter += new System.EventHandler(this.TxtProductName_Enter);
            this.txtProductName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtProductName_KeyDown);
            this.txtProductName.Leave += new System.EventHandler(this.TxtProductName_Leave);
            // 
            // cmbSupplierType
            // 
            this.cmbSupplierType.FormattingEnabled = true;
            this.cmbSupplierType.Location = new System.Drawing.Point(442, 44);
            this.cmbSupplierType.Name = "cmbSupplierType";
            this.cmbSupplierType.Size = new System.Drawing.Size(88, 27);
            this.cmbSupplierType.TabIndex = 3;
            this.cmbSupplierType.Enter += new System.EventHandler(this.CmbSupplierType_Enter);
            this.cmbSupplierType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbSupplierType_KeyDown);
            this.cmbSupplierType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbSupplierType_KeyPress);
            this.cmbSupplierType.Leave += new System.EventHandler(this.CmbSupplierType_Leave);
            // 
            // txtHsnName
            // 
            this.txtHsnName.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtHsnName.Location = new System.Drawing.Point(536, 44);
            this.txtHsnName.MaxLength = 50;
            this.txtHsnName.Name = "txtHsnName";
            this.txtHsnName.Size = new System.Drawing.Size(232, 27);
            this.txtHsnName.TabIndex = 4;
            this.txtHsnName.TextChanged += new System.EventHandler(this.TxtHsnName_TextChanged);
            this.txtHsnName.Enter += new System.EventHandler(this.TxtHsnName_Enter);
            this.txtHsnName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtHsnName_KeyDown);
            this.txtHsnName.Leave += new System.EventHandler(this.TxtHsnName_Leave);
            // 
            // dpToDate
            // 
            this.dpToDate.CustomFormat = "dd/MM/yyyy";
            this.dpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpToDate.Location = new System.Drawing.Point(329, 45);
            this.dpToDate.Name = "dpToDate";
            this.dpToDate.Size = new System.Drawing.Size(107, 27);
            this.dpToDate.TabIndex = 2;
            this.dpToDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DpToDate_KeyDown);
            // 
            // dpFromDate
            // 
            this.dpFromDate.CustomFormat = "dd/MM/yyyy";
            this.dpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpFromDate.Location = new System.Drawing.Point(216, 45);
            this.dpFromDate.Name = "dpFromDate";
            this.dpFromDate.Size = new System.Drawing.Size(107, 27);
            this.dpFromDate.TabIndex = 1;
            this.dpFromDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DpFromDate_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(329, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 20);
            this.label3.TabIndex = 1111194;
            this.label3.Text = "To Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(212, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 20);
            this.label1.TabIndex = 1111193;
            this.label1.Text = "From Date";
            // 
            // lblHsnName
            // 
            this.lblHsnName.AutoSize = true;
            this.lblHsnName.Location = new System.Drawing.Point(609, 23);
            this.lblHsnName.Name = "lblHsnName";
            this.lblHsnName.Size = new System.Drawing.Size(16, 20);
            this.lblHsnName.TabIndex = 958789;
            this.lblHsnName.Text = "0";
            this.lblHsnName.Visible = false;
            // 
            // lblHSN
            // 
            this.lblHSN.AutoSize = true;
            this.lblHSN.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHSN.Location = new System.Drawing.Point(538, 22);
            this.lblHSN.Name = "lblHSN";
            this.lblHSN.Size = new System.Drawing.Size(65, 20);
            this.lblHSN.TabIndex = 1111178;
            this.lblHSN.Text = "HSN Name";
            // 
            // cmbReportType
            // 
            this.cmbReportType.FormattingEnabled = true;
            this.cmbReportType.Location = new System.Drawing.Point(9, 45);
            this.cmbReportType.Name = "cmbReportType";
            this.cmbReportType.Size = new System.Drawing.Size(201, 27);
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
            this.lblReportType.Location = new System.Drawing.Point(9, 22);
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
            // RPTViewer
            // 
            this.RPTViewer.ActiveViewIndex = -1;
            this.RPTViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RPTViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.RPTViewer.Location = new System.Drawing.Point(3, 146);
            this.RPTViewer.Name = "RPTViewer";
            this.RPTViewer.ReuseParameterValuesOnRefresh = true;
            this.RPTViewer.Size = new System.Drawing.Size(1348, 493);
            this.RPTViewer.TabIndex = 1111227;
            this.RPTViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.RPTViewer.Visible = false;
            // 
            // lblGroupCode
            // 
            this.lblGroupCode.AutoSize = true;
            this.lblGroupCode.Location = new System.Drawing.Point(58, 77);
            this.lblGroupCode.Name = "lblGroupCode";
            this.lblGroupCode.Size = new System.Drawing.Size(16, 20);
            this.lblGroupCode.TabIndex = 111111153;
            this.lblGroupCode.Text = "0";
            this.lblGroupCode.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 20);
            this.label4.TabIndex = 111111151;
            this.label4.Text = "Group";
            // 
            // txtGroup
            // 
            this.txtGroup.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtGroup.Location = new System.Drawing.Point(9, 100);
            this.txtGroup.MaxLength = 100;
            this.txtGroup.Name = "txtGroup";
            this.txtGroup.Size = new System.Drawing.Size(201, 27);
            this.txtGroup.TabIndex = 6;
            this.txtGroup.TextChanged += new System.EventHandler(this.TxtGroup_TextChanged);
            this.txtGroup.Enter += new System.EventHandler(this.TxtGroup_Enter);
            this.txtGroup.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtGroup_KeyDown);
            this.txtGroup.Leave += new System.EventHandler(this.TxtGroup_Leave);
            // 
            // lvGroup
            // 
            this.lvGroup.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader13});
            this.lvGroup.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvGroup.HideSelection = false;
            this.lvGroup.Location = new System.Drawing.Point(12, 127);
            this.lvGroup.Name = "lvGroup";
            this.lvGroup.Size = new System.Drawing.Size(457, 171);
            this.lvGroup.TabIndex = 111111152;
            this.lvGroup.UseCompatibleStateImageBehavior = false;
            this.lvGroup.View = System.Windows.Forms.View.Details;
            this.lvGroup.Visible = false;
            this.lvGroup.DoubleClick += new System.EventHandler(this.LvGroup_DoubleClick);
            this.lvGroup.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LvGroup_KeyDown);
            // 
            // columnHeader11
            // 
            this.columnHeader11.Width = 170;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Width = 170;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Width = 0;
            // 
            // lblSubGroupCode
            // 
            this.lblSubGroupCode.AutoSize = true;
            this.lblSubGroupCode.Location = new System.Drawing.Point(282, 77);
            this.lblSubGroupCode.Name = "lblSubGroupCode";
            this.lblSubGroupCode.Size = new System.Drawing.Size(16, 20);
            this.lblSubGroupCode.TabIndex = 111111154;
            this.lblSubGroupCode.Text = "0";
            this.lblSubGroupCode.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(214, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 20);
            this.label6.TabIndex = 111111153;
            this.label6.Text = "Subgroup";
            // 
            // txtSubGroup
            // 
            this.txtSubGroup.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtSubGroup.Location = new System.Drawing.Point(216, 100);
            this.txtSubGroup.MaxLength = 100;
            this.txtSubGroup.Name = "txtSubGroup";
            this.txtSubGroup.Size = new System.Drawing.Size(220, 27);
            this.txtSubGroup.TabIndex = 7;
            this.txtSubGroup.TextChanged += new System.EventHandler(this.TxtSubGroup_TextChanged);
            this.txtSubGroup.Enter += new System.EventHandler(this.TxtSubGroup_Enter);
            this.txtSubGroup.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtSubGroup_KeyDown);
            this.txtSubGroup.Leave += new System.EventHandler(this.TxtSubGroup_Leave);
            // 
            // lvSubGroup
            // 
            this.lvSubGroup.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader28,
            this.columnHeader29});
            this.lvSubGroup.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvSubGroup.HideSelection = false;
            this.lvSubGroup.Location = new System.Drawing.Point(219, 127);
            this.lvSubGroup.Name = "lvSubGroup";
            this.lvSubGroup.Size = new System.Drawing.Size(457, 171);
            this.lvSubGroup.TabIndex = 111111152;
            this.lvSubGroup.UseCompatibleStateImageBehavior = false;
            this.lvSubGroup.View = System.Windows.Forms.View.Details;
            this.lvSubGroup.Visible = false;
            this.lvSubGroup.DoubleClick += new System.EventHandler(this.LvSubGroup_DoubleClick);
            this.lvSubGroup.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LvSubGroup_KeyDown);
            // 
            // columnHeader4
            // 
            this.columnHeader4.Width = 170;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Width = 170;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Width = 0;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Width = 0;
            // 
            // columnHeader28
            // 
            this.columnHeader28.Width = 0;
            // 
            // columnHeader29
            // 
            this.columnHeader29.Width = 0;
            // 
            // btnListPrint
            // 
            this.btnListPrint.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListPrint.Image = global::ROMS.Properties.Resources.view;
            this.btnListPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnListPrint.Location = new System.Drawing.Point(774, 98);
            this.btnListPrint.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnListPrint.Name = "btnListPrint";
            this.btnListPrint.Size = new System.Drawing.Size(75, 29);
            this.btnListPrint.TabIndex = 9;
            this.btnListPrint.Text = "View";
            this.btnListPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnListPrint.UseVisualStyleBackColor = true;
            this.btnListPrint.Click += new System.EventHandler(this.BtnListPrint_Click);
            this.btnListPrint.Enter += new System.EventHandler(this.BtnListPrint_Enter);
            this.btnListPrint.Leave += new System.EventHandler(this.BtnListPrint_Leave);
            // 
            // picLoader
            // 
            this.picLoader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picLoader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picLoader.ErrorImage = null;
            this.picLoader.Image = global::ROMS.Properties.Resources.Iphone_spinner_2;
            this.picLoader.InitialImage = null;
            this.picLoader.Location = new System.Drawing.Point(3, 146);
            this.picLoader.Name = "picLoader";
            this.picLoader.Size = new System.Drawing.Size(1348, 496);
            this.picLoader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picLoader.TabIndex = 958790;
            this.picLoader.TabStop = false;
            this.picLoader.Visible = false;
            // 
            // tspHeader
            // 
            this.tspHeader.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tspHeader.Image = global::ROMS.Properties.Resources.bread_crumb;
            this.tspHeader.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tspHeader.Margin = new System.Windows.Forms.Padding(15, 1, 0, 2);
            this.tspHeader.Name = "tspHeader";
            this.tspHeader.Size = new System.Drawing.Size(196, 22);
            this.tspHeader.Text = "HSN Name Wise Product Report";
            // 
            // REPORT_HSN_NameWise_Product
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(1354, 675);
            this.Controls.Add(this.pnlReportHSN);
            this.Controls.Add(this.ReportHSN);
            this.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "REPORT_HSN_NameWise_Product";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HSN Name Wise Product Report";
            this.Load += new System.EventHandler(this.REPORT_CP_HSN_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.REPORT_CP_HSN_KeyDown);
            this.ReportHSN.ResumeLayout(false);
            this.ReportHSN.PerformLayout();
            this.pnlReportHSN.ResumeLayout(false);
            this.pnlReportHSN.PerformLayout();
            this.grpfilter.ResumeLayout(false);
            this.grpfilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip ReportHSN;
        private System.Windows.Forms.ToolStripLabel tspHeader;
        private System.Windows.Forms.Panel pnlReportHSN;
        private System.Windows.Forms.Label lblNoRecordsFound;
        private System.Windows.Forms.GroupBox grpfilter;
        private System.Windows.Forms.ComboBox cmbReportType;
        private System.Windows.Forms.Label lblReportType;
        public System.Windows.Forms.PictureBox picLoader;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer RPTViewer;
        private System.Windows.Forms.Button btnListPrint;
        private System.Windows.Forms.Label lblHSN;
        private System.Windows.Forms.TextBox txtHsnName;
        public System.Windows.Forms.ListView lvHsnName;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader30;
        private System.Windows.Forms.ColumnHeader columnHeader31;
        public System.Windows.Forms.Label lblHsnName;
        private System.Windows.Forms.DateTimePicker dpToDate;
        private System.Windows.Forms.DateTimePicker dpFromDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbSupplierType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtProductName;
        public System.Windows.Forms.ListView lvproduct;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.Label lblProductcode;
        private System.Windows.Forms.Label lblGroupCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtGroup;
        public System.Windows.Forms.ListView lvGroup;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.Label lblSubGroupCode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSubGroup;
        public System.Windows.Forms.ListView lvSubGroup;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader28;
        private System.Windows.Forms.ColumnHeader columnHeader29;
    }
}