namespace ROMS
{
    partial class REPORT_PUR_PurchaseOrder
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
            this.ReportProduct = new System.Windows.Forms.ToolStrip();
            this.tspHeader = new System.Windows.Forms.ToolStripLabel();
            this.pnlReportProduct = new System.Windows.Forms.Panel();
            this.lvproduct = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LV_Supplier = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvSubGroup = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader28 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader29 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvGroup = new System.Windows.Forms.ListView();
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grpfilter = new System.Windows.Forms.GroupBox();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblProductcode = new System.Windows.Forms.Label();
            this.lblscheduleName = new System.Windows.Forms.Label();
            this.lblschedleCode = new System.Windows.Forms.Label();
            this.lblSupplierCode = new System.Windows.Forms.Label();
            this.txtSupplier = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtProduct = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbShow = new System.Windows.Forms.ComboBox();
            this.lblGroupCode = new System.Windows.Forms.Label();
            this.lblSubGroupCode = new System.Windows.Forms.Label();
            this.txtGroup = new System.Windows.Forms.TextBox();
            this.txtSubGroup = new System.Windows.Forms.TextBox();
            this.lblGroup = new System.Windows.Forms.Label();
            this.lblSubgroup = new System.Windows.Forms.Label();
            this.btnListPrint = new System.Windows.Forms.Button();
            this.lblNoRecordsFound = new System.Windows.Forms.Label();
            this.picLoader = new System.Windows.Forms.PictureBox();
            this.RPTViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.ReportProduct.SuspendLayout();
            this.pnlReportProduct.SuspendLayout();
            this.grpfilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).BeginInit();
            this.SuspendLayout();
            // 
            // ReportProduct
            // 
            this.ReportProduct.BackColor = System.Drawing.Color.White;
            this.ReportProduct.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReportProduct.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ReportProduct.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ReportProduct.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspHeader});
            this.ReportProduct.Location = new System.Drawing.Point(0, 0);
            this.ReportProduct.Name = "ReportProduct";
            this.ReportProduct.Size = new System.Drawing.Size(1354, 25);
            this.ReportProduct.TabIndex = 35;
            this.ReportProduct.Text = "Product Report";
            // 
            // tspHeader
            // 
            this.tspHeader.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tspHeader.Image = global::ROMS.Properties.Resources.bread_crumb;
            this.tspHeader.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tspHeader.Margin = new System.Windows.Forms.Padding(15, 1, 0, 2);
            this.tspHeader.Name = "tspHeader";
            this.tspHeader.Size = new System.Drawing.Size(186, 22);
            this.tspHeader.Text = "Purchase Order-Product Wise";
            // 
            // pnlReportProduct
            // 
            this.pnlReportProduct.BackColor = System.Drawing.Color.White;
            this.pnlReportProduct.Controls.Add(this.lvproduct);
            this.pnlReportProduct.Controls.Add(this.LV_Supplier);
            this.pnlReportProduct.Controls.Add(this.lvSubGroup);
            this.pnlReportProduct.Controls.Add(this.lvGroup);
            this.pnlReportProduct.Controls.Add(this.grpfilter);
            this.pnlReportProduct.Controls.Add(this.lblNoRecordsFound);
            this.pnlReportProduct.Controls.Add(this.picLoader);
            this.pnlReportProduct.Controls.Add(this.RPTViewer);
            this.pnlReportProduct.Location = new System.Drawing.Point(0, 29);
            this.pnlReportProduct.Name = "pnlReportProduct";
            this.pnlReportProduct.Size = new System.Drawing.Size(1354, 643);
            this.pnlReportProduct.TabIndex = 958788;
            // 
            // lvproduct
            // 
            this.lvproduct.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader10,
            this.columnHeader14,
            this.columnHeader15,
            this.columnHeader16});
            this.lvproduct.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvproduct.HideSelection = false;
            this.lvproduct.Location = new System.Drawing.Point(294, 76);
            this.lvproduct.Name = "lvproduct";
            this.lvproduct.Size = new System.Drawing.Size(457, 93);
            this.lvproduct.TabIndex = 1111237;
            this.lvproduct.UseCompatibleStateImageBehavior = false;
            this.lvproduct.View = System.Windows.Forms.View.Details;
            this.lvproduct.Visible = false;
            this.lvproduct.DoubleClick += new System.EventHandler(this.Lvproduct_DoubleClick);
            this.lvproduct.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Lvproduct_KeyDown);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Width = 170;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Width = 170;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Width = 0;
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
            // LV_Supplier
            // 
            this.LV_Supplier.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader8,
            this.columnHeader9});
            this.LV_Supplier.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.LV_Supplier.HideSelection = false;
            this.LV_Supplier.Location = new System.Drawing.Point(514, 76);
            this.LV_Supplier.Name = "LV_Supplier";
            this.LV_Supplier.Size = new System.Drawing.Size(539, 93);
            this.LV_Supplier.TabIndex = 1111236;
            this.LV_Supplier.UseCompatibleStateImageBehavior = false;
            this.LV_Supplier.View = System.Windows.Forms.View.Details;
            this.LV_Supplier.Visible = false;
            this.LV_Supplier.DoubleClick += new System.EventHandler(this.LV_Supplier_DoubleClick);
            this.LV_Supplier.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LV_Supplier_KeyDown);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 180;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Width = 120;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Width = 0;
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
            this.lvSubGroup.Location = new System.Drawing.Point(135, 76);
            this.lvSubGroup.Name = "lvSubGroup";
            this.lvSubGroup.Size = new System.Drawing.Size(457, 93);
            this.lvSubGroup.TabIndex = 1111229;
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
            // lvGroup
            // 
            this.lvGroup.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader13});
            this.lvGroup.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvGroup.HideSelection = false;
            this.lvGroup.Location = new System.Drawing.Point(12, 76);
            this.lvGroup.Name = "lvGroup";
            this.lvGroup.Size = new System.Drawing.Size(457, 93);
            this.lvGroup.TabIndex = 1111230;
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
            // grpfilter
            // 
            this.grpfilter.Controls.Add(this.cmbStatus);
            this.grpfilter.Controls.Add(this.lblStatus);
            this.grpfilter.Controls.Add(this.lblProductcode);
            this.grpfilter.Controls.Add(this.lblscheduleName);
            this.grpfilter.Controls.Add(this.lblschedleCode);
            this.grpfilter.Controls.Add(this.lblSupplierCode);
            this.grpfilter.Controls.Add(this.txtSupplier);
            this.grpfilter.Controls.Add(this.label3);
            this.grpfilter.Controls.Add(this.txtProduct);
            this.grpfilter.Controls.Add(this.label1);
            this.grpfilter.Controls.Add(this.label2);
            this.grpfilter.Controls.Add(this.cmbShow);
            this.grpfilter.Controls.Add(this.lblGroupCode);
            this.grpfilter.Controls.Add(this.lblSubGroupCode);
            this.grpfilter.Controls.Add(this.txtGroup);
            this.grpfilter.Controls.Add(this.txtSubGroup);
            this.grpfilter.Controls.Add(this.lblGroup);
            this.grpfilter.Controls.Add(this.lblSubgroup);
            this.grpfilter.Controls.Add(this.btnListPrint);
            this.grpfilter.Location = new System.Drawing.Point(3, 2);
            this.grpfilter.Name = "grpfilter";
            this.grpfilter.Size = new System.Drawing.Size(1348, 74);
            this.grpfilter.TabIndex = 0;
            this.grpfilter.TabStop = false;
            this.grpfilter.Text = "Filter By";
            // 
            // cmbStatus
            // 
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(999, 44);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(100, 27);
            this.cmbStatus.TabIndex = 9;
            this.cmbStatus.Enter += new System.EventHandler(this.CmbStatus_Enter);
            this.cmbStatus.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbStatus_KeyDown);
            this.cmbStatus.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbStatus_KeyPress);
            this.cmbStatus.Leave += new System.EventHandler(this.CmbStatus_Leave);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(999, 20);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(45, 20);
            this.lblStatus.TabIndex = 1111182;
            this.lblStatus.Text = "Status";
            // 
            // lblProductcode
            // 
            this.lblProductcode.AutoSize = true;
            this.lblProductcode.Location = new System.Drawing.Point(804, 3);
            this.lblProductcode.Name = "lblProductcode";
            this.lblProductcode.Size = new System.Drawing.Size(16, 20);
            this.lblProductcode.TabIndex = 1111239;
            this.lblProductcode.Text = "0";
            this.lblProductcode.Visible = false;
            // 
            // lblscheduleName
            // 
            this.lblscheduleName.AutoSize = true;
            this.lblscheduleName.Location = new System.Drawing.Point(712, 3);
            this.lblscheduleName.Name = "lblscheduleName";
            this.lblscheduleName.Size = new System.Drawing.Size(0, 20);
            this.lblscheduleName.TabIndex = 1111238;
            this.lblscheduleName.Visible = false;
            // 
            // lblschedleCode
            // 
            this.lblschedleCode.AutoSize = true;
            this.lblschedleCode.Location = new System.Drawing.Point(660, 0);
            this.lblschedleCode.Name = "lblschedleCode";
            this.lblschedleCode.Size = new System.Drawing.Size(16, 20);
            this.lblschedleCode.TabIndex = 1111237;
            this.lblschedleCode.Text = "0";
            this.lblschedleCode.Visible = false;
            // 
            // lblSupplierCode
            // 
            this.lblSupplierCode.AutoSize = true;
            this.lblSupplierCode.Location = new System.Drawing.Point(622, 3);
            this.lblSupplierCode.Name = "lblSupplierCode";
            this.lblSupplierCode.Size = new System.Drawing.Size(16, 20);
            this.lblSupplierCode.TabIndex = 1111236;
            this.lblSupplierCode.Text = "0";
            this.lblSupplierCode.Visible = false;
            // 
            // txtSupplier
            // 
            this.txtSupplier.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtSupplier.Location = new System.Drawing.Point(611, 43);
            this.txtSupplier.MaxLength = 100;
            this.txtSupplier.Name = "txtSupplier";
            this.txtSupplier.Size = new System.Drawing.Size(275, 27);
            this.txtSupplier.TabIndex = 4;
            this.txtSupplier.TextChanged += new System.EventHandler(this.TxtSupplier_TextChanged);
            this.txtSupplier.Enter += new System.EventHandler(this.TxtSupplier_Enter);
            this.txtSupplier.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtSupplier_KeyDown);
            this.txtSupplier.Leave += new System.EventHandler(this.TxtSupplier_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(611, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 20);
            this.label3.TabIndex = 1111235;
            this.label3.Text = "Supplier";
            // 
            // txtProduct
            // 
            this.txtProduct.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtProduct.Location = new System.Drawing.Point(349, 43);
            this.txtProduct.MaxLength = 100;
            this.txtProduct.Name = "txtProduct";
            this.txtProduct.Size = new System.Drawing.Size(256, 27);
            this.txtProduct.TabIndex = 3;
            this.txtProduct.TextChanged += new System.EventHandler(this.TxtProduct_TextChanged);
            this.txtProduct.Enter += new System.EventHandler(this.TxtProductName_Enter);
            this.txtProduct.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtProductName_KeyDown);
            this.txtProduct.Leave += new System.EventHandler(this.TxtProductName_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(349, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 20);
            this.label1.TabIndex = 1111233;
            this.label1.Text = "Product";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(892, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 20);
            this.label2.TabIndex = 1111230;
            this.label2.Text = "Order By";
            // 
            // cmbShow
            // 
            this.cmbShow.FormattingEnabled = true;
            this.cmbShow.Items.AddRange(new object[] {
            "Purchase Order List",
            "Product List"});
            this.cmbShow.Location = new System.Drawing.Point(892, 43);
            this.cmbShow.Name = "cmbShow";
            this.cmbShow.Size = new System.Drawing.Size(101, 27);
            this.cmbShow.TabIndex = 6;
            this.cmbShow.Enter += new System.EventHandler(this.CmbShow_Enter);
            this.cmbShow.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbShow_KeyDown);
            this.cmbShow.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbShow_KeyPress);
            this.cmbShow.Leave += new System.EventHandler(this.CmbShow_Leave);
            // 
            // lblGroupCode
            // 
            this.lblGroupCode.AutoSize = true;
            this.lblGroupCode.Location = new System.Drawing.Point(558, 3);
            this.lblGroupCode.Name = "lblGroupCode";
            this.lblGroupCode.Size = new System.Drawing.Size(16, 20);
            this.lblGroupCode.TabIndex = 1111231;
            this.lblGroupCode.Text = "0";
            this.lblGroupCode.Visible = false;
            // 
            // lblSubGroupCode
            // 
            this.lblSubGroupCode.AutoSize = true;
            this.lblSubGroupCode.Location = new System.Drawing.Point(758, 3);
            this.lblSubGroupCode.Name = "lblSubGroupCode";
            this.lblSubGroupCode.Size = new System.Drawing.Size(16, 20);
            this.lblSubGroupCode.TabIndex = 1111231;
            this.lblSubGroupCode.Text = "0";
            this.lblSubGroupCode.Visible = false;
            // 
            // txtGroup
            // 
            this.txtGroup.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtGroup.Location = new System.Drawing.Point(10, 43);
            this.txtGroup.MaxLength = 100;
            this.txtGroup.Name = "txtGroup";
            this.txtGroup.Size = new System.Drawing.Size(129, 27);
            this.txtGroup.TabIndex = 1;
            this.txtGroup.TextChanged += new System.EventHandler(this.TxtGroup_TextChanged);
            this.txtGroup.Enter += new System.EventHandler(this.TxtGroup_Enter);
            this.txtGroup.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtGroup_KeyDown);
            this.txtGroup.Leave += new System.EventHandler(this.TxtGroup_Leave);
            // 
            // txtSubGroup
            // 
            this.txtSubGroup.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtSubGroup.Location = new System.Drawing.Point(145, 43);
            this.txtSubGroup.MaxLength = 100;
            this.txtSubGroup.Name = "txtSubGroup";
            this.txtSubGroup.Size = new System.Drawing.Size(198, 27);
            this.txtSubGroup.TabIndex = 2;
            this.txtSubGroup.TextChanged += new System.EventHandler(this.TxtSubGroup_TextChanged);
            this.txtSubGroup.Enter += new System.EventHandler(this.TxtSubGroup_Enter);
            this.txtSubGroup.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtSubGroup_KeyDown);
            this.txtSubGroup.Leave += new System.EventHandler(this.TxtSubGroup_Leave);
            // 
            // lblGroup
            // 
            this.lblGroup.AutoSize = true;
            this.lblGroup.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGroup.Location = new System.Drawing.Point(10, 20);
            this.lblGroup.Name = "lblGroup";
            this.lblGroup.Size = new System.Drawing.Size(42, 20);
            this.lblGroup.TabIndex = 1111181;
            this.lblGroup.Text = "Group";
            // 
            // lblSubgroup
            // 
            this.lblSubgroup.AutoSize = true;
            this.lblSubgroup.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubgroup.Location = new System.Drawing.Point(145, 20);
            this.lblSubgroup.Name = "lblSubgroup";
            this.lblSubgroup.Size = new System.Drawing.Size(62, 20);
            this.lblSubgroup.TabIndex = 1111180;
            this.lblSubgroup.Text = "Subgroup";
            // 
            // btnListPrint
            // 
            this.btnListPrint.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListPrint.Image = global::ROMS.Properties.Resources.view;
            this.btnListPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnListPrint.Location = new System.Drawing.Point(1105, 42);
            this.btnListPrint.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnListPrint.Name = "btnListPrint";
            this.btnListPrint.Size = new System.Drawing.Size(69, 29);
            this.btnListPrint.TabIndex = 13;
            this.btnListPrint.Text = "View";
            this.btnListPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnListPrint.UseVisualStyleBackColor = true;
            this.btnListPrint.Click += new System.EventHandler(this.BtnListPrint_Click);
            this.btnListPrint.Enter += new System.EventHandler(this.BtnListPrint_Enter);
            this.btnListPrint.Leave += new System.EventHandler(this.BtnListPrint_Leave);
            // 
            // lblNoRecordsFound
            // 
            this.lblNoRecordsFound.AutoSize = true;
            this.lblNoRecordsFound.BackColor = System.Drawing.Color.White;
            this.lblNoRecordsFound.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoRecordsFound.Location = new System.Drawing.Point(625, 344);
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
            this.picLoader.Location = new System.Drawing.Point(3, 82);
            this.picLoader.Name = "picLoader";
            this.picLoader.Size = new System.Drawing.Size(1348, 557);
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
            this.RPTViewer.Location = new System.Drawing.Point(3, 78);
            this.RPTViewer.Name = "RPTViewer";
            this.RPTViewer.ReuseParameterValuesOnRefresh = true;
            this.RPTViewer.Size = new System.Drawing.Size(1348, 561);
            this.RPTViewer.TabIndex = 1111227;
            this.RPTViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.RPTViewer.Visible = false;
            // 
            // REPORT_PUR_PurchaseOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(1354, 675);
            this.Controls.Add(this.pnlReportProduct);
            this.Controls.Add(this.ReportProduct);
            this.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "REPORT_PUR_PurchaseOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HSN Report";
            this.Load += new System.EventHandler(this.REPORT_CP_Product_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.REPORT_CP_Product_KeyDown);
            this.ReportProduct.ResumeLayout(false);
            this.ReportProduct.PerformLayout();
            this.pnlReportProduct.ResumeLayout(false);
            this.pnlReportProduct.PerformLayout();
            this.grpfilter.ResumeLayout(false);
            this.grpfilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip ReportProduct;
        private System.Windows.Forms.ToolStripLabel tspHeader;
        private System.Windows.Forms.Panel pnlReportProduct;
        private System.Windows.Forms.Label lblNoRecordsFound;
        private System.Windows.Forms.GroupBox grpfilter;
        public System.Windows.Forms.PictureBox picLoader;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer RPTViewer;
        private System.Windows.Forms.Button btnListPrint;
        private System.Windows.Forms.Label lblSubgroup;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label lblGroup;
        private System.Windows.Forms.TextBox txtSubGroup;
        private System.Windows.Forms.TextBox txtGroup;
        public System.Windows.Forms.ListView lvSubGroup;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader28;
        private System.Windows.Forms.ColumnHeader columnHeader29;
        public System.Windows.Forms.ListView lvGroup;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.Label lblSubGroupCode;
        private System.Windows.Forms.Label lblGroupCode;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox cmbShow;
        private System.Windows.Forms.TextBox txtProduct;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSupplier;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.ListView LV_Supplier;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.Label lblscheduleName;
        private System.Windows.Forms.Label lblschedleCode;
        private System.Windows.Forms.Label lblSupplierCode;
        public System.Windows.Forms.ListView lvproduct;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.ColumnHeader columnHeader16;
        private System.Windows.Forms.Label lblProductcode;
    }
}