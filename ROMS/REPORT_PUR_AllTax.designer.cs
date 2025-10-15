namespace ROMS
{
    partial class REPORT_PUR_AllTax
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(REPORT_PUR_AllTax));
            this.tsAllPurchaseReport = new System.Windows.Forms.ToolStrip();
            this.tsbPrintFormat = new System.Windows.Forms.ToolStripButton();
            this.tsbFormat = new System.Windows.Forms.ToolStripButton();
            this.tsLabelPlaceholder = new System.Windows.Forms.ToolStripLabel();
            this.pnlReportCity = new System.Windows.Forms.Panel();
            this.grpfilter = new System.Windows.Forms.GroupBox();
            this.lblMonths = new System.Windows.Forms.Label();
            this.cmbMultiMonths = new MultiSelectComboBox();
            this.cmbGST = new System.Windows.Forms.ComboBox();
            this.cmbMonths = new System.Windows.Forms.ComboBox();
            this.btnListPrint = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbReportType = new System.Windows.Forms.ComboBox();
            this.lblReportType = new System.Windows.Forms.Label();
            this.dpToDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dpFromDate = new System.Windows.Forms.DateTimePicker();
            this.lblNoRecordsFound = new System.Windows.Forms.Label();
            this.picLoader = new System.Windows.Forms.PictureBox();
            this.RPTViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.epReport = new System.Windows.Forms.ErrorProvider(this.components);
            this.dynamicLabelControl = new ROMS.DynamicToolStripLabelControl();
            this.tsAllPurchaseReport.SuspendLayout();
            this.pnlReportCity.SuspendLayout();
            this.grpfilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epReport)).BeginInit();
            this.SuspendLayout();
            // 
            // tsAllPurchaseReport
            // 
            this.tsAllPurchaseReport.BackColor = System.Drawing.Color.White;
            this.tsAllPurchaseReport.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsAllPurchaseReport.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsAllPurchaseReport.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsAllPurchaseReport.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbPrintFormat,
            this.tsbFormat,
            this.tsLabelPlaceholder});
            this.tsAllPurchaseReport.Location = new System.Drawing.Point(0, 0);
            this.tsAllPurchaseReport.Name = "tsAllPurchaseReport";
            this.tsAllPurchaseReport.Size = new System.Drawing.Size(1354, 32);
            this.tsAllPurchaseReport.TabIndex = 35;
            this.tsAllPurchaseReport.Text = "City Report";
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
            this.tsbPrintFormat.Size = new System.Drawing.Size(109, 29);
            this.tsbPrintFormat.Text = "A4-Landscape";
            this.tsbPrintFormat.ToolTipText = "A4-Landscape";
            // 
            // tsbFormat
            // 
            this.tsbFormat.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbFormat.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbFormat.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFormat.Margin = new System.Windows.Forms.Padding(-5, 1, 30, 2);
            this.tsbFormat.Name = "tsbFormat";
            this.tsbFormat.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tsbFormat.Size = new System.Drawing.Size(112, 29);
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
            this.tsLabelPlaceholder.Size = new System.Drawing.Size(69, 29);
            this.tsLabelPlaceholder.Text = "Levels";
            // 
            // pnlReportCity
            // 
            this.pnlReportCity.BackColor = System.Drawing.Color.White;
            this.pnlReportCity.Controls.Add(this.grpfilter);
            this.pnlReportCity.Controls.Add(this.lblNoRecordsFound);
            this.pnlReportCity.Controls.Add(this.picLoader);
            this.pnlReportCity.Controls.Add(this.RPTViewer);
            this.pnlReportCity.Location = new System.Drawing.Point(0, 29);
            this.pnlReportCity.Name = "pnlReportCity";
            this.pnlReportCity.Size = new System.Drawing.Size(1354, 643);
            this.pnlReportCity.TabIndex = 958788;
            // 
            // grpfilter
            // 
            this.grpfilter.Controls.Add(this.lblMonths);
            this.grpfilter.Controls.Add(this.cmbMultiMonths);
            this.grpfilter.Controls.Add(this.cmbGST);
            this.grpfilter.Controls.Add(this.cmbMonths);
            this.grpfilter.Controls.Add(this.btnListPrint);
            this.grpfilter.Controls.Add(this.label7);
            this.grpfilter.Controls.Add(this.cmbReportType);
            this.grpfilter.Controls.Add(this.lblReportType);
            this.grpfilter.Controls.Add(this.dpToDate);
            this.grpfilter.Controls.Add(this.label3);
            this.grpfilter.Controls.Add(this.label2);
            this.grpfilter.Controls.Add(this.label1);
            this.grpfilter.Controls.Add(this.dpFromDate);
            this.grpfilter.Location = new System.Drawing.Point(12, 0);
            this.grpfilter.Name = "grpfilter";
            this.grpfilter.Size = new System.Drawing.Size(1330, 111);
            this.grpfilter.TabIndex = 0;
            this.grpfilter.TabStop = false;
            this.grpfilter.Text = "Filter By";
            // 
            // lblMonths
            // 
            this.lblMonths.AutoSize = true;
            this.lblMonths.Font = new System.Drawing.Font("Oswald Regular", 9.25F);
            this.lblMonths.Location = new System.Drawing.Point(623, 79);
            this.lblMonths.Name = "lblMonths";
            this.lblMonths.Size = new System.Drawing.Size(336, 21);
            this.lblMonths.TabIndex = 111111199;
            this.lblMonths.Text = "Jan, Feb, Mar, Apr, May, Jun, Jul, Aug, Sep, Oct, Nov, Dec";
            // 
            // cmbMultiMonths
            // 
            this.cmbMultiMonths.BackColor = System.Drawing.SystemColors.Window;
            this.cmbMultiMonths.DropDownHeight = 1;
            this.cmbMultiMonths.FormattingEnabled = true;
            this.cmbMultiMonths.IntegralHeight = false;
            this.cmbMultiMonths.Location = new System.Drawing.Point(623, 46);
            this.cmbMultiMonths.Name = "cmbMultiMonths";
            this.cmbMultiMonths.Size = new System.Drawing.Size(121, 33);
            this.cmbMultiMonths.TabIndex = 4;
            this.cmbMultiMonths.Enter += new System.EventHandler(this.CmbMultiMonths_Enter);
            this.cmbMultiMonths.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbMultiMonths_KeyDown);
            this.cmbMultiMonths.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbMultiMonths_KeyPress);
            this.cmbMultiMonths.Leave += new System.EventHandler(this.CmbMultiMonths_Leave);
            // 
            // cmbGST
            // 
            this.cmbGST.FormattingEnabled = true;
            this.cmbGST.Location = new System.Drawing.Point(508, 46);
            this.cmbGST.Name = "cmbGST";
            this.cmbGST.Size = new System.Drawing.Size(109, 33);
            this.cmbGST.TabIndex = 3;
            this.cmbGST.Enter += new System.EventHandler(this.CmbGST_Enter);
            this.cmbGST.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbGST_KeyDown);
            this.cmbGST.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbGST_KeyPress);
            this.cmbGST.Leave += new System.EventHandler(this.CmbGST_Leave);
            // 
            // cmbMonths
            // 
            this.cmbMonths.FormattingEnabled = true;
            this.cmbMonths.Location = new System.Drawing.Point(623, 46);
            this.cmbMonths.Name = "cmbMonths";
            this.cmbMonths.Size = new System.Drawing.Size(109, 33);
            this.cmbMonths.TabIndex = 4;
            this.cmbMonths.Visible = false;
            this.cmbMonths.Enter += new System.EventHandler(this.CmbMonths_Enter);
            this.cmbMonths.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbMonths_KeyDown);
            this.cmbMonths.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbMonths_KeyPress);
            this.cmbMonths.Leave += new System.EventHandler(this.CmbMonths_Leave);
            // 
            // btnListPrint
            // 
            this.btnListPrint.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListPrint.Image = global::ROMS.Properties.Resources.view;
            this.btnListPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnListPrint.Location = new System.Drawing.Point(750, 45);
            this.btnListPrint.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnListPrint.Name = "btnListPrint";
            this.btnListPrint.Size = new System.Drawing.Size(75, 29);
            this.btnListPrint.TabIndex = 5;
            this.btnListPrint.Text = "View";
            this.btnListPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnListPrint.UseVisualStyleBackColor = true;
            this.btnListPrint.Click += new System.EventHandler(this.BtnListPrint_Click);
            this.btnListPrint.Enter += new System.EventHandler(this.BtnListPrint_Enter);
            this.btnListPrint.Leave += new System.EventHandler(this.BtnListPrint_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(623, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 26);
            this.label7.TabIndex = 111111195;
            this.label7.Text = "Months";
            // 
            // cmbReportType
            // 
            this.cmbReportType.FormattingEnabled = true;
            this.cmbReportType.Location = new System.Drawing.Point(9, 46);
            this.cmbReportType.Name = "cmbReportType";
            this.cmbReportType.Size = new System.Drawing.Size(271, 33);
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
            this.lblReportType.Location = new System.Drawing.Point(9, 23);
            this.lblReportType.Name = "lblReportType";
            this.lblReportType.Size = new System.Drawing.Size(91, 26);
            this.lblReportType.TabIndex = 111111193;
            this.lblReportType.Text = "Report type";
            // 
            // dpToDate
            // 
            this.dpToDate.CustomFormat = "dd/MM/yyyy";
            this.dpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpToDate.Location = new System.Drawing.Point(399, 46);
            this.dpToDate.Name = "dpToDate";
            this.dpToDate.Size = new System.Drawing.Size(103, 32);
            this.dpToDate.TabIndex = 2;
            this.dpToDate.Enter += new System.EventHandler(this.DpToDate_Enter);
            this.dpToDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DpToDate_KeyDown);
            this.dpToDate.Leave += new System.EventHandler(this.DpToDate_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(399, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 26);
            this.label3.TabIndex = 111111188;
            this.label3.Text = "To Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(508, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 26);
            this.label2.TabIndex = 111111186;
            this.label2.Text = "GST %";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(286, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 26);
            this.label1.TabIndex = 111111184;
            this.label1.Text = "From Date";
            // 
            // dpFromDate
            // 
            this.dpFromDate.CustomFormat = "dd/MM/yyyy";
            this.dpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpFromDate.Location = new System.Drawing.Point(286, 46);
            this.dpFromDate.Name = "dpFromDate";
            this.dpFromDate.Size = new System.Drawing.Size(107, 32);
            this.dpFromDate.TabIndex = 1;
            this.dpFromDate.ValueChanged += new System.EventHandler(this.DpFromDate_ValueChanged);
            this.dpFromDate.Enter += new System.EventHandler(this.DpFromDate_Enter);
            this.dpFromDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DpFromDate_KeyDown);
            this.dpFromDate.Leave += new System.EventHandler(this.DpFromDate_Leave);
            // 
            // lblNoRecordsFound
            // 
            this.lblNoRecordsFound.AutoSize = true;
            this.lblNoRecordsFound.BackColor = System.Drawing.Color.White;
            this.lblNoRecordsFound.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoRecordsFound.Location = new System.Drawing.Point(624, 354);
            this.lblNoRecordsFound.Name = "lblNoRecordsFound";
            this.lblNoRecordsFound.Size = new System.Drawing.Size(130, 25);
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
            this.picLoader.Location = new System.Drawing.Point(12, 117);
            this.picLoader.Name = "picLoader";
            this.picLoader.Size = new System.Drawing.Size(1330, 525);
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
            this.RPTViewer.Location = new System.Drawing.Point(12, 117);
            this.RPTViewer.Name = "RPTViewer";
            this.RPTViewer.ReuseParameterValuesOnRefresh = true;
            this.RPTViewer.Size = new System.Drawing.Size(1330, 522);
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
            // REPORT_PUR_AllTax
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(1354, 675);
            this.Controls.Add(this.pnlReportCity);
            this.Controls.Add(this.tsAllPurchaseReport);
            this.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "REPORT_PUR_AllTax";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "All Purchase Tax Report";
            this.Load += new System.EventHandler(this.REPORT_CP_City_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.REPORT_CP_City_KeyDown);
            this.tsAllPurchaseReport.ResumeLayout(false);
            this.tsAllPurchaseReport.PerformLayout();
            this.pnlReportCity.ResumeLayout(false);
            this.pnlReportCity.PerformLayout();
            this.grpfilter.ResumeLayout(false);
            this.grpfilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epReport)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsAllPurchaseReport;
        private System.Windows.Forms.Panel pnlReportCity;
        private System.Windows.Forms.Label lblNoRecordsFound;
        private System.Windows.Forms.GroupBox grpfilter;
        public System.Windows.Forms.PictureBox picLoader;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer RPTViewer;
        private System.Windows.Forms.Button btnListPrint;
        private System.Windows.Forms.DateTimePicker dpFromDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider epReport;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dpToDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbReportType;
        private System.Windows.Forms.Label lblReportType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbMonths;
        private System.Windows.Forms.ComboBox cmbGST;
        public System.Windows.Forms.ToolStripButton tsbPrintFormat;
        public System.Windows.Forms.ToolStripButton tsbFormat;
        private MultiSelectComboBox cmbMultiMonths;
        private System.Windows.Forms.Label lblMonths;
        private System.Windows.Forms.ToolStripLabel tsLabelPlaceholder;
        private DynamicToolStripLabelControl dynamicLabelControl;
    }
}