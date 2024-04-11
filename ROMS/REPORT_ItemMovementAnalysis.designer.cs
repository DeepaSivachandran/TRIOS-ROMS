namespace ROMS
{
    partial class REPORT_ItemMovementAnalysis
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
            this.StockReport = new System.Windows.Forms.ToolStrip();
            this.tspHeader = new System.Windows.Forms.ToolStripLabel();
            this.pnlReportProduct = new System.Windows.Forms.Panel();
            this.lvRack = new System.Windows.Forms.ListView();
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvLocation = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.lvProduct = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label2 = new System.Windows.Forms.Label();
            this.grpfilter = new System.Windows.Forms.GroupBox();
            this.dptodate = new System.Windows.Forms.DateTimePicker();
            this.txtRack = new System.Windows.Forms.TextBox();
            this.lblProduct = new System.Windows.Forms.Label();
            this.lblRack = new System.Windows.Forms.Label();
            this.dpFromDate = new System.Windows.Forms.DateTimePicker();
            this.lblConcern = new System.Windows.Forms.Label();
            this.lblInvoicedate = new System.Windows.Forms.Label();
            this.cmbConcern = new System.Windows.Forms.ComboBox();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnView = new System.Windows.Forms.Button();
            this.lblNoRecordsFound = new System.Windows.Forms.Label();
            this.picLoader = new System.Windows.Forms.PictureBox();
            this.RPTViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.lblRackCode = new System.Windows.Forms.Label();
            this.epItemAnalysis = new System.Windows.Forms.ErrorProvider(this.components);
            this.StockReport.SuspendLayout();
            this.pnlReportProduct.SuspendLayout();
            this.grpfilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epItemAnalysis)).BeginInit();
            this.SuspendLayout();
            // 
            // StockReport
            // 
            this.StockReport.BackColor = System.Drawing.Color.White;
            this.StockReport.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StockReport.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.StockReport.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.StockReport.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspHeader});
            this.StockReport.Location = new System.Drawing.Point(0, 0);
            this.StockReport.Name = "StockReport";
            this.StockReport.Size = new System.Drawing.Size(1354, 25);
            this.StockReport.TabIndex = 35;
            this.StockReport.Text = "Stock Report";
            // 
            // tspHeader
            // 
            this.tspHeader.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tspHeader.Image = global::ROMS.Properties.Resources.bread_crumb;
            this.tspHeader.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tspHeader.Margin = new System.Windows.Forms.Padding(15, 1, 0, 2);
            this.tspHeader.Name = "tspHeader";
            this.tspHeader.Size = new System.Drawing.Size(156, 22);
            this.tspHeader.Text = "Item Movement Analysis";
            // 
            // pnlReportProduct
            // 
            this.pnlReportProduct.BackColor = System.Drawing.Color.White;
            this.pnlReportProduct.Controls.Add(this.lvRack);
            this.pnlReportProduct.Controls.Add(this.lvLocation);
            this.pnlReportProduct.Controls.Add(this.txtLocation);
            this.pnlReportProduct.Controls.Add(this.lvProduct);
            this.pnlReportProduct.Controls.Add(this.label2);
            this.pnlReportProduct.Controls.Add(this.grpfilter);
            this.pnlReportProduct.Controls.Add(this.lblNoRecordsFound);
            this.pnlReportProduct.Controls.Add(this.picLoader);
            this.pnlReportProduct.Controls.Add(this.RPTViewer);
            this.pnlReportProduct.Location = new System.Drawing.Point(0, 29);
            this.pnlReportProduct.Name = "pnlReportProduct";
            this.pnlReportProduct.Size = new System.Drawing.Size(1354, 643);
            this.pnlReportProduct.TabIndex = 958788;
            // 
            // lvRack
            // 
            this.lvRack.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader13,
            this.columnHeader14,
            this.columnHeader15});
            this.lvRack.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.lvRack.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvRack.HideSelection = false;
            this.lvRack.Location = new System.Drawing.Point(774, 74);
            this.lvRack.Name = "lvRack";
            this.lvRack.Size = new System.Drawing.Size(398, 194);
            this.lvRack.TabIndex = 111111153;
            this.lvRack.UseCompatibleStateImageBehavior = false;
            this.lvRack.View = System.Windows.Forms.View.Details;
            this.lvRack.Visible = false;
            this.lvRack.DoubleClick += new System.EventHandler(this.LvRack_DoubleClick);
            this.lvRack.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LvRack_KeyDown);
            // 
            // columnHeader11
            // 
            this.columnHeader11.Width = 120;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Width = 0;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Width = 0;
            // 
            // lvLocation
            // 
            this.lvLocation.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader10});
            this.lvLocation.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.lvLocation.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvLocation.HideSelection = false;
            this.lvLocation.Location = new System.Drawing.Point(610, 74);
            this.lvLocation.Name = "lvLocation";
            this.lvLocation.Size = new System.Drawing.Size(398, 194);
            this.lvLocation.TabIndex = 111111150;
            this.lvLocation.UseCompatibleStateImageBehavior = false;
            this.lvLocation.View = System.Windows.Forms.View.Details;
            this.lvLocation.Visible = false;
            this.lvLocation.DoubleClick += new System.EventHandler(this.LvLocation_DoubleClick);
            this.lvLocation.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LvLocation_KeyDown);
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
            // txtLocation
            // 
            this.txtLocation.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtLocation.Location = new System.Drawing.Point(610, 47);
            this.txtLocation.MaxLength = 50;
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(159, 27);
            this.txtLocation.TabIndex = 4;
            this.txtLocation.TextChanged += new System.EventHandler(this.TxtLocation_TextChanged);
            this.txtLocation.Enter += new System.EventHandler(this.TxtLocation_Enter);
            this.txtLocation.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtLocation_KeyDown);
            this.txtLocation.Leave += new System.EventHandler(this.TxtLocation_Leave);
            // 
            // lvProduct
            // 
            this.lvProduct.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9});
            this.lvProduct.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.lvProduct.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvProduct.HideSelection = false;
            this.lvProduct.Location = new System.Drawing.Point(342, 74);
            this.lvProduct.Name = "lvProduct";
            this.lvProduct.Size = new System.Drawing.Size(638, 194);
            this.lvProduct.TabIndex = 111111144;
            this.lvProduct.UseCompatibleStateImageBehavior = false;
            this.lvProduct.View = System.Windows.Forms.View.Details;
            this.lvProduct.Visible = false;
            this.lvProduct.DoubleClick += new System.EventHandler(this.LvProduct_DoubleClick);
            this.lvProduct.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LvProduct_KeyDown);
            // 
            // columnHeader5
            // 
            this.columnHeader5.Width = 120;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Width = 0;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Width = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(610, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 20);
            this.label2.TabIndex = 111111149;
            this.label2.Text = "Location";
            // 
            // grpfilter
            // 
            this.grpfilter.Controls.Add(this.lblRackCode);
            this.grpfilter.Controls.Add(this.dptodate);
            this.grpfilter.Controls.Add(this.txtRack);
            this.grpfilter.Controls.Add(this.lblProduct);
            this.grpfilter.Controls.Add(this.lblRack);
            this.grpfilter.Controls.Add(this.dpFromDate);
            this.grpfilter.Controls.Add(this.lblConcern);
            this.grpfilter.Controls.Add(this.lblInvoicedate);
            this.grpfilter.Controls.Add(this.cmbConcern);
            this.grpfilter.Controls.Add(this.txtProductName);
            this.grpfilter.Controls.Add(this.label1);
            this.grpfilter.Controls.Add(this.btnView);
            this.grpfilter.Location = new System.Drawing.Point(3, 2);
            this.grpfilter.Name = "grpfilter";
            this.grpfilter.Size = new System.Drawing.Size(1348, 86);
            this.grpfilter.TabIndex = 0;
            this.grpfilter.TabStop = false;
            this.grpfilter.Text = "Filter By";
            // 
            // dptodate
            // 
            this.dptodate.CustomFormat = "dd/MM/yyyy";
            this.dptodate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dptodate.Location = new System.Drawing.Point(231, 45);
            this.dptodate.Name = "dptodate";
            this.dptodate.Size = new System.Drawing.Size(104, 27);
            this.dptodate.TabIndex = 2;
            // 
            // txtRack
            // 
            this.txtRack.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtRack.Location = new System.Drawing.Point(770, 45);
            this.txtRack.MaxLength = 50;
            this.txtRack.Name = "txtRack";
            this.txtRack.Size = new System.Drawing.Size(159, 27);
            this.txtRack.TabIndex = 5;
            this.txtRack.TextChanged += new System.EventHandler(this.TxtRack_TextChanged);
            this.txtRack.Enter += new System.EventHandler(this.TxtRack_Enter);
            this.txtRack.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtRack_KeyDown);
            this.txtRack.Leave += new System.EventHandler(this.TxtRack_Leave);
            // 
            // lblProduct
            // 
            this.lblProduct.AutoSize = true;
            this.lblProduct.Location = new System.Drawing.Point(335, 15);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(0, 20);
            this.lblProduct.TabIndex = 1111238;
            this.lblProduct.Visible = false;
            // 
            // lblRack
            // 
            this.lblRack.AutoSize = true;
            this.lblRack.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRack.Location = new System.Drawing.Point(770, 20);
            this.lblRack.Name = "lblRack";
            this.lblRack.Size = new System.Drawing.Size(35, 20);
            this.lblRack.TabIndex = 111111152;
            this.lblRack.Text = "Rack";
            // 
            // dpFromDate
            // 
            this.dpFromDate.CustomFormat = "dd/MM/yyyy";
            this.dpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpFromDate.Location = new System.Drawing.Point(121, 45);
            this.dpFromDate.Name = "dpFromDate";
            this.dpFromDate.Size = new System.Drawing.Size(104, 27);
            this.dpFromDate.TabIndex = 1;
            // 
            // lblConcern
            // 
            this.lblConcern.AutoSize = true;
            this.lblConcern.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConcern.Location = new System.Drawing.Point(6, 22);
            this.lblConcern.Name = "lblConcern";
            this.lblConcern.Size = new System.Drawing.Size(54, 20);
            this.lblConcern.TabIndex = 1111237;
            this.lblConcern.Text = "Concern";
            // 
            // lblInvoicedate
            // 
            this.lblInvoicedate.AutoSize = true;
            this.lblInvoicedate.Location = new System.Drawing.Point(122, 22);
            this.lblInvoicedate.Name = "lblInvoicedate";
            this.lblInvoicedate.Size = new System.Drawing.Size(64, 20);
            this.lblInvoicedate.TabIndex = 111111147;
            this.lblInvoicedate.Text = "From Date";
            // 
            // cmbConcern
            // 
            this.cmbConcern.FormattingEnabled = true;
            this.cmbConcern.Location = new System.Drawing.Point(6, 45);
            this.cmbConcern.Name = "cmbConcern";
            this.cmbConcern.Size = new System.Drawing.Size(110, 27);
            this.cmbConcern.TabIndex = 0;
            this.cmbConcern.Enter += new System.EventHandler(this.CmbConcern_Enter);
            this.cmbConcern.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbConcern_KeyDown);
            this.cmbConcern.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbConcern_KeyPress);
            this.cmbConcern.Leave += new System.EventHandler(this.CmbConcern_Leave);
            // 
            // txtProductName
            // 
            this.txtProductName.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtProductName.Location = new System.Drawing.Point(339, 45);
            this.txtProductName.MaxLength = 50;
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(264, 27);
            this.txtProductName.TabIndex = 3;
            this.txtProductName.TextChanged += new System.EventHandler(this.TxtProductName_TextChanged);
            this.txtProductName.Enter += new System.EventHandler(this.TxtProductName_Enter);
            this.txtProductName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtProductName_KeyDown);
            this.txtProductName.Leave += new System.EventHandler(this.TxtProductName_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(339, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 20);
            this.label1.TabIndex = 1111232;
            this.label1.Text = "Product Name/PI Code";
            // 
            // btnView
            // 
            this.btnView.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnView.Image = global::ROMS.Properties.Resources.view;
            this.btnView.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnView.Location = new System.Drawing.Point(933, 43);
            this.btnView.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(75, 29);
            this.btnView.TabIndex = 6;
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
            this.picLoader.Location = new System.Drawing.Point(3, 94);
            this.picLoader.Name = "picLoader";
            this.picLoader.Size = new System.Drawing.Size(1351, 548);
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
            this.RPTViewer.Location = new System.Drawing.Point(3, 94);
            this.RPTViewer.Name = "RPTViewer";
            this.RPTViewer.ReuseParameterValuesOnRefresh = true;
            this.RPTViewer.Size = new System.Drawing.Size(1348, 545);
            this.RPTViewer.TabIndex = 1111227;
            this.RPTViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.RPTViewer.Visible = false;
            // 
            // lblRackCode
            // 
            this.lblRackCode.AutoSize = true;
            this.lblRackCode.Location = new System.Drawing.Point(809, 49);
            this.lblRackCode.Name = "lblRackCode";
            this.lblRackCode.Size = new System.Drawing.Size(16, 20);
            this.lblRackCode.TabIndex = 111111154;
            this.lblRackCode.Text = "0";
            this.lblRackCode.Visible = false;
            // 
            // epItemAnalysis
            // 
            this.epItemAnalysis.ContainerControl = this;
            // 
            // REPORT_ItemMovementAnalysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(1354, 675);
            this.Controls.Add(this.pnlReportProduct);
            this.Controls.Add(this.StockReport);
            this.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "REPORT_ItemMovementAnalysis";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report Stock";
            this.Load += new System.EventHandler(this.REPORT_CP_Product_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.REPORT_CP_Product_KeyDown);
            this.StockReport.ResumeLayout(false);
            this.StockReport.PerformLayout();
            this.pnlReportProduct.ResumeLayout(false);
            this.pnlReportProduct.PerformLayout();
            this.grpfilter.ResumeLayout(false);
            this.grpfilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epItemAnalysis)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip StockReport;
        private System.Windows.Forms.ToolStripLabel tspHeader;
        private System.Windows.Forms.Panel pnlReportProduct;
        private System.Windows.Forms.Label lblNoRecordsFound;
        private System.Windows.Forms.GroupBox grpfilter;
        public System.Windows.Forms.PictureBox picLoader;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer RPTViewer;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbConcern;
        private System.Windows.Forms.Label lblConcern;
        public System.Windows.Forms.ListView lvProduct;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.DateTimePicker dptodate;
        private System.Windows.Forms.DateTimePicker dpFromDate;
        private System.Windows.Forms.Label lblInvoicedate;
        public System.Windows.Forms.ListView lvLocation;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ListView lvRack;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.TextBox txtRack;
        private System.Windows.Forms.Label lblRack;
        private System.Windows.Forms.Label lblRackCode;
        private System.Windows.Forms.ErrorProvider epItemAnalysis;
    }
}