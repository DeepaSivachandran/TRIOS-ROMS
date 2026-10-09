namespace ROMS
{
    partial class REPORT_SALES_Scheme
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(REPORT_SALES_Scheme));
            this.tsProductCategoryReport = new System.Windows.Forms.ToolStrip();
            this.tsbPrintFormat = new System.Windows.Forms.ToolStripButton();
            this.tsbFormat = new System.Windows.Forms.ToolStripButton();
            this.tsLabelPlaceholder = new System.Windows.Forms.ToolStripLabel();
            this.pnlReportStockLocation = new System.Windows.Forms.Panel();
            this.grpfilter = new System.Windows.Forms.GroupBox();
            this.cmbRateCategory = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbRecursive = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbSchemeAvailTime = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbDaysType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbValidityType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbSchemeType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbConcern = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnTelegram = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.lblNoRecordsFound = new System.Windows.Forms.Label();
            this.picLoader = new System.Windows.Forms.PictureBox();
            this.RPTViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.epReport = new System.Windows.Forms.ErrorProvider(this.components);
            this.dynamicToolStripLabelControl1 = new ROMS.DynamicToolStripLabelControl();
            this.tsProductCategoryReport.SuspendLayout();
            this.pnlReportStockLocation.SuspendLayout();
            this.grpfilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epReport)).BeginInit();
            this.SuspendLayout();
            // 
            // tsProductCategoryReport
            // 
            this.tsProductCategoryReport.BackColor = System.Drawing.Color.White;
            this.tsProductCategoryReport.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsProductCategoryReport.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsProductCategoryReport.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsProductCategoryReport.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbPrintFormat,
            this.tsbFormat,
            this.tsLabelPlaceholder});
            this.tsProductCategoryReport.Location = new System.Drawing.Point(0, 0);
            this.tsProductCategoryReport.Name = "tsProductCategoryReport";
            this.tsProductCategoryReport.Size = new System.Drawing.Size(1354, 27);
            this.tsProductCategoryReport.TabIndex = 35;
            this.tsProductCategoryReport.Text = "GRN Summary Report";
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
            this.tsLabelPlaceholder.Visible = false;
            // 
            // pnlReportStockLocation
            // 
            this.pnlReportStockLocation.BackColor = System.Drawing.Color.White;
            this.pnlReportStockLocation.Controls.Add(this.grpfilter);
            this.pnlReportStockLocation.Controls.Add(this.lblNoRecordsFound);
            this.pnlReportStockLocation.Controls.Add(this.picLoader);
            this.pnlReportStockLocation.Controls.Add(this.RPTViewer);
            this.pnlReportStockLocation.Location = new System.Drawing.Point(0, 29);
            this.pnlReportStockLocation.Name = "pnlReportStockLocation";
            this.pnlReportStockLocation.Size = new System.Drawing.Size(1354, 643);
            this.pnlReportStockLocation.TabIndex = 0;
            // 
            // grpfilter
            // 
            this.grpfilter.Controls.Add(this.cmbRateCategory);
            this.grpfilter.Controls.Add(this.label9);
            this.grpfilter.Controls.Add(this.cmbRecursive);
            this.grpfilter.Controls.Add(this.label3);
            this.grpfilter.Controls.Add(this.cmbStatus);
            this.grpfilter.Controls.Add(this.label8);
            this.grpfilter.Controls.Add(this.cmbSchemeAvailTime);
            this.grpfilter.Controls.Add(this.label7);
            this.grpfilter.Controls.Add(this.cmbDaysType);
            this.grpfilter.Controls.Add(this.label5);
            this.grpfilter.Controls.Add(this.cmbValidityType);
            this.grpfilter.Controls.Add(this.label4);
            this.grpfilter.Controls.Add(this.cmbSchemeType);
            this.grpfilter.Controls.Add(this.label2);
            this.grpfilter.Controls.Add(this.cmbConcern);
            this.grpfilter.Controls.Add(this.label6);
            this.grpfilter.Controls.Add(this.btnTelegram);
            this.grpfilter.Controls.Add(this.btnView);
            this.grpfilter.Location = new System.Drawing.Point(3, 2);
            this.grpfilter.Name = "grpfilter";
            this.grpfilter.Size = new System.Drawing.Size(1348, 98);
            this.grpfilter.TabIndex = 0;
            this.grpfilter.TabStop = false;
            this.grpfilter.Text = "Filter By";
            // 
            // cmbRateCategory
            // 
            this.cmbRateCategory.FormattingEnabled = true;
            this.cmbRateCategory.Location = new System.Drawing.Point(370, 56);
            this.cmbRateCategory.Name = "cmbRateCategory";
            this.cmbRateCategory.Size = new System.Drawing.Size(119, 27);
            this.cmbRateCategory.TabIndex = 111111247;
            this.cmbRateCategory.Enter += new System.EventHandler(this.cmbRateCategory_Enter);
            this.cmbRateCategory.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbRateCategory_KeyDown);
            this.cmbRateCategory.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbRateCategory_KeyPress);
            this.cmbRateCategory.Leave += new System.EventHandler(this.cmbRateCategory_Leave);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(370, 29);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(120, 20);
            this.label9.TabIndex = 111111248;
            this.label9.Text = "Applicable Rate Type";
            // 
            // cmbRecursive
            // 
            this.cmbRecursive.FormattingEnabled = true;
            this.cmbRecursive.Location = new System.Drawing.Point(244, 56);
            this.cmbRecursive.Name = "cmbRecursive";
            this.cmbRecursive.Size = new System.Drawing.Size(112, 27);
            this.cmbRecursive.TabIndex = 2;
            this.cmbRecursive.Enter += new System.EventHandler(this.cmbRecursive_Enter);
            this.cmbRecursive.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbRecursive_KeyDown);
            this.cmbRecursive.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbRecursive_KeyPress);
            this.cmbRecursive.Leave += new System.EventHandler(this.cmbRecursive_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(244, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 20);
            this.label3.TabIndex = 111111246;
            this.label3.Text = "Recusrive";
            // 
            // cmbStatus
            // 
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(830, 56);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(94, 27);
            this.cmbStatus.TabIndex = 7;
            this.cmbStatus.Enter += new System.EventHandler(this.cmbStatus_Enter);
            this.cmbStatus.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbStatus_KeyDown);
            this.cmbStatus.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbStatus_KeyPress);
            this.cmbStatus.Leave += new System.EventHandler(this.cmbStatus_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(830, 28);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 20);
            this.label8.TabIndex = 111111227;
            this.label8.Text = "Status";
            // 
            // cmbSchemeAvailTime
            // 
            this.cmbSchemeAvailTime.FormattingEnabled = true;
            this.cmbSchemeAvailTime.Location = new System.Drawing.Point(705, 56);
            this.cmbSchemeAvailTime.Name = "cmbSchemeAvailTime";
            this.cmbSchemeAvailTime.Size = new System.Drawing.Size(118, 27);
            this.cmbSchemeAvailTime.TabIndex = 6;
            this.cmbSchemeAvailTime.Enter += new System.EventHandler(this.cmbSchemeAvailTime_Enter);
            this.cmbSchemeAvailTime.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbSchemeAvailTime_KeyDown);
            this.cmbSchemeAvailTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbSchemeAvailTime_KeyPress);
            this.cmbSchemeAvailTime.Leave += new System.EventHandler(this.cmbSchemeAvailTime_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(705, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 20);
            this.label7.TabIndex = 111111225;
            this.label7.Text = "Scheme Avail Time";
            // 
            // cmbDaysType
            // 
            this.cmbDaysType.FormattingEnabled = true;
            this.cmbDaysType.Location = new System.Drawing.Point(602, 56);
            this.cmbDaysType.Name = "cmbDaysType";
            this.cmbDaysType.Size = new System.Drawing.Size(94, 27);
            this.cmbDaysType.TabIndex = 5;
            this.cmbDaysType.Enter += new System.EventHandler(this.cmbDaysType_Enter);
            this.cmbDaysType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbDaysType_KeyDown);
            this.cmbDaysType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbDaysType_KeyPress);
            this.cmbDaysType.Leave += new System.EventHandler(this.cmbDaysType_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(602, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 20);
            this.label5.TabIndex = 111111223;
            this.label5.Text = "Days Type";
            // 
            // cmbValidityType
            // 
            this.cmbValidityType.FormattingEnabled = true;
            this.cmbValidityType.Location = new System.Drawing.Point(501, 56);
            this.cmbValidityType.Name = "cmbValidityType";
            this.cmbValidityType.Size = new System.Drawing.Size(94, 27);
            this.cmbValidityType.TabIndex = 4;
            this.cmbValidityType.Enter += new System.EventHandler(this.cmbValidityType_Enter);
            this.cmbValidityType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbValidityType_KeyDown);
            this.cmbValidityType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbValidityType_KeyPress);
            this.cmbValidityType.Leave += new System.EventHandler(this.cmbValidityType_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(501, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 20);
            this.label4.TabIndex = 111111221;
            this.label4.Text = "Validity Type";
            // 
            // cmbSchemeType
            // 
            this.cmbSchemeType.FormattingEnabled = true;
            this.cmbSchemeType.Location = new System.Drawing.Point(113, 56);
            this.cmbSchemeType.Name = "cmbSchemeType";
            this.cmbSchemeType.Size = new System.Drawing.Size(125, 27);
            this.cmbSchemeType.TabIndex = 1;
            this.cmbSchemeType.Enter += new System.EventHandler(this.cmbSchemeType_Enter);
            this.cmbSchemeType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbSchemeType_KeyDown);
            this.cmbSchemeType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbSchemeType_KeyPress);
            this.cmbSchemeType.Leave += new System.EventHandler(this.cmbSchemeType_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(113, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 20);
            this.label2.TabIndex = 111111217;
            this.label2.Text = "Scheme";
            // 
            // cmbConcern
            // 
            this.cmbConcern.FormattingEnabled = true;
            this.cmbConcern.Location = new System.Drawing.Point(13, 56);
            this.cmbConcern.Name = "cmbConcern";
            this.cmbConcern.Size = new System.Drawing.Size(94, 27);
            this.cmbConcern.TabIndex = 0;
            this.cmbConcern.Enter += new System.EventHandler(this.cmbconcern_Enter);
            this.cmbConcern.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbconcern_KeyDown);
            this.cmbConcern.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbconcern_KeyPress);
            this.cmbConcern.Leave += new System.EventHandler(this.cmbconcern_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 20);
            this.label6.TabIndex = 111111213;
            this.label6.Text = "Concern";
            // 
            // btnTelegram
            // 
            this.btnTelegram.Image = ((System.Drawing.Image)(resources.GetObject("btnTelegram.Image")));
            this.btnTelegram.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTelegram.Location = new System.Drawing.Point(1007, 56);
            this.btnTelegram.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnTelegram.Name = "btnTelegram";
            this.btnTelegram.Size = new System.Drawing.Size(33, 29);
            this.btnTelegram.TabIndex = 9;
            this.btnTelegram.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTelegram.UseVisualStyleBackColor = true;
            this.btnTelegram.Click += new System.EventHandler(this.btnTelegram_Click);
            this.btnTelegram.Enter += new System.EventHandler(this.btnTelegram_Enter);
            this.btnTelegram.Leave += new System.EventHandler(this.btnTelegram_Leave);
            // 
            // btnView
            // 
            this.btnView.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnView.Image = global::ROMS.Properties.Resources.view;
            this.btnView.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnView.Location = new System.Drawing.Point(930, 56);
            this.btnView.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(65, 29);
            this.btnView.TabIndex = 8;
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
            this.picLoader.Location = new System.Drawing.Point(3, 100);
            this.picLoader.Name = "picLoader";
            this.picLoader.Size = new System.Drawing.Size(1351, 534);
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
            this.RPTViewer.Location = new System.Drawing.Point(3, 100);
            this.RPTViewer.Name = "RPTViewer";
            this.RPTViewer.ReuseParameterValuesOnRefresh = true;
            this.RPTViewer.Size = new System.Drawing.Size(1348, 539);
            this.RPTViewer.TabIndex = 1111227;
            this.RPTViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.RPTViewer.Visible = false;
            // 
            // epReport
            // 
            this.epReport.ContainerControl = this;
            // 
            // dynamicToolStripLabelControl1
            // 
            this.dynamicToolStripLabelControl1.PlaceholderLabel = null;
            // 
            // REPORT_SALES_Scheme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(1354, 675);
            this.Controls.Add(this.pnlReportStockLocation);
            this.Controls.Add(this.tsProductCategoryReport);
            this.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "REPORT_SALES_Scheme";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Product Category Report";
            this.Load += new System.EventHandler(this.REPORT_GRNSummary_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.REPORT_GRNSummary_KeyDown);
            this.tsProductCategoryReport.ResumeLayout(false);
            this.tsProductCategoryReport.PerformLayout();
            this.pnlReportStockLocation.ResumeLayout(false);
            this.pnlReportStockLocation.PerformLayout();
            this.grpfilter.ResumeLayout(false);
            this.grpfilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epReport)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsProductCategoryReport;
        private System.Windows.Forms.Panel pnlReportStockLocation;
        private System.Windows.Forms.Label lblNoRecordsFound;
        private System.Windows.Forms.GroupBox grpfilter;
        public System.Windows.Forms.PictureBox picLoader;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer RPTViewer;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.ErrorProvider epReport;
        public System.Windows.Forms.ToolStripButton tsbPrintFormat;
        public System.Windows.Forms.ToolStripButton tsbFormat;
        private DynamicToolStripLabelControl dynamicLabelControl;
        private System.Windows.Forms.ToolStripLabel tsLabelPlaceholder;
        private System.Windows.Forms.Button btnTelegram;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbConcern;
        private System.Windows.Forms.ComboBox cmbSchemeType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbSchemeAvailTime;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbDaysType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbValidityType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label label8;
        private DynamicToolStripLabelControl dynamicToolStripLabelControl1;
        private System.Windows.Forms.ComboBox cmbRecursive;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbRateCategory;
        private System.Windows.Forms.Label label9;
    }
}