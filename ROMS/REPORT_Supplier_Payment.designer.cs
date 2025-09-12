namespace ROMS
{
    partial class REPORT_Supplier_Payment
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ReportSupplier = new System.Windows.Forms.ToolStrip();
            this.tspHeader = new System.Windows.Forms.ToolStripLabel();
            this.tsbPrintFormat = new System.Windows.Forms.ToolStripButton();
            this.tsbFormat = new System.Windows.Forms.ToolStripButton();
            this.pnlReportStockLocation = new System.Windows.Forms.Panel();
            this.DGV_FilterProduct = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.grpfilter = new System.Windows.Forms.GroupBox();
            this.lblSupplierCode = new System.Windows.Forms.Label();
            this.dpToDate = new System.Windows.Forms.DateTimePicker();
            this.txtSupplier = new System.Windows.Forms.TextBox();
            this.lblschedleCode = new System.Windows.Forms.Label();
            this.dpFromDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbPayType = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnView = new System.Windows.Forms.Button();
            this.lblNoRecordsFound = new System.Windows.Forms.Label();
            this.picLoader = new System.Windows.Forms.PictureBox();
            this.RPTViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbConcern = new System.Windows.Forms.ComboBox();
            this.cmbReportType = new System.Windows.Forms.ComboBox();
            this.lblReportType = new System.Windows.Forms.Label();
            this.ReportSupplier.SuspendLayout();
            this.pnlReportStockLocation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_FilterProduct)).BeginInit();
            this.grpfilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).BeginInit();
            this.SuspendLayout();
            // 
            // ReportSupplier
            // 
            this.ReportSupplier.BackColor = System.Drawing.Color.White;
            this.ReportSupplier.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReportSupplier.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ReportSupplier.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ReportSupplier.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspHeader,
            this.tsbPrintFormat,
            this.tsbFormat});
            this.ReportSupplier.Location = new System.Drawing.Point(0, 0);
            this.ReportSupplier.Name = "ReportSupplier";
            this.ReportSupplier.Size = new System.Drawing.Size(1354, 27);
            this.ReportSupplier.TabIndex = 35;
            this.ReportSupplier.Text = "GRN Summary Report";
            // 
            // tspHeader
            // 
            this.tspHeader.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tspHeader.Image = global::ROMS.Properties.Resources.bread_crumb;
            this.tspHeader.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tspHeader.Margin = new System.Windows.Forms.Padding(15, 1, 0, 2);
            this.tspHeader.Name = "tspHeader";
            this.tspHeader.Size = new System.Drawing.Size(160, 24);
            this.tspHeader.Text = "Supplier Payment Report";
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
            this.tsbPrintFormat.Size = new System.Drawing.Size(89, 24);
            this.tsbPrintFormat.Text = "A3-Landscape";
            this.tsbPrintFormat.ToolTipText = "Total GRN ";
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
            this.tsbFormat.ToolTipText = "Total GRN ";
            // 
            // pnlReportStockLocation
            // 
            this.pnlReportStockLocation.BackColor = System.Drawing.Color.White;
            this.pnlReportStockLocation.Controls.Add(this.DGV_FilterProduct);
            this.pnlReportStockLocation.Controls.Add(this.grpfilter);
            this.pnlReportStockLocation.Controls.Add(this.lblNoRecordsFound);
            this.pnlReportStockLocation.Controls.Add(this.picLoader);
            this.pnlReportStockLocation.Controls.Add(this.RPTViewer);
            this.pnlReportStockLocation.Location = new System.Drawing.Point(0, 29);
            this.pnlReportStockLocation.Name = "pnlReportStockLocation";
            this.pnlReportStockLocation.Size = new System.Drawing.Size(1354, 643);
            this.pnlReportStockLocation.TabIndex = 0;
            // 
            // DGV_FilterProduct
            // 
            this.DGV_FilterProduct.AllowUserToAddRows = false;
            this.DGV_FilterProduct.AllowUserToDeleteRows = false;
            this.DGV_FilterProduct.AllowUserToResizeColumns = false;
            this.DGV_FilterProduct.AllowUserToResizeRows = false;
            this.DGV_FilterProduct.BackgroundColor = System.Drawing.Color.White;
            this.DGV_FilterProduct.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.Chocolate;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.Chocolate;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_FilterProduct.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.DGV_FilterProduct.ColumnHeadersHeight = 30;
            this.DGV_FilterProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV_FilterProduct.DefaultCellStyle = dataGridViewCellStyle8;
            this.DGV_FilterProduct.EnableHeadersVisualStyles = false;
            this.DGV_FilterProduct.GridColor = System.Drawing.Color.White;
            this.DGV_FilterProduct.Location = new System.Drawing.Point(506, 75);
            this.DGV_FilterProduct.Name = "DGV_FilterProduct";
            this.DGV_FilterProduct.ReadOnly = true;
            this.DGV_FilterProduct.RowHeadersVisible = false;
            this.DGV_FilterProduct.RowHeadersWidth = 51;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.DGV_FilterProduct.RowsDefaultCellStyle = dataGridViewCellStyle9;
            this.DGV_FilterProduct.RowTemplate.Height = 25;
            this.DGV_FilterProduct.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV_FilterProduct.Size = new System.Drawing.Size(305, 226);
            this.DGV_FilterProduct.TabIndex = 1111233;
            this.DGV_FilterProduct.Visible = false;
            this.DGV_FilterProduct.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_FilterProduct_CellDoubleClick);
            this.DGV_FilterProduct.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DGV_FilterProduct_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(503, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 20);
            this.label2.TabIndex = 1111187;
            this.label2.Text = "Supplier Name";
            // 
            // grpfilter
            // 
            this.grpfilter.Controls.Add(this.label10);
            this.grpfilter.Controls.Add(this.lblSupplierCode);
            this.grpfilter.Controls.Add(this.cmbConcern);
            this.grpfilter.Controls.Add(this.cmbReportType);
            this.grpfilter.Controls.Add(this.dpToDate);
            this.grpfilter.Controls.Add(this.lblReportType);
            this.grpfilter.Controls.Add(this.txtSupplier);
            this.grpfilter.Controls.Add(this.lblschedleCode);
            this.grpfilter.Controls.Add(this.dpFromDate);
            this.grpfilter.Controls.Add(this.label2);
            this.grpfilter.Controls.Add(this.label3);
            this.grpfilter.Controls.Add(this.label1);
            this.grpfilter.Controls.Add(this.cmbPayType);
            this.grpfilter.Controls.Add(this.lblStatus);
            this.grpfilter.Controls.Add(this.btnView);
            this.grpfilter.Location = new System.Drawing.Point(3, 2);
            this.grpfilter.Name = "grpfilter";
            this.grpfilter.Size = new System.Drawing.Size(1348, 82);
            this.grpfilter.TabIndex = 0;
            this.grpfilter.TabStop = false;
            this.grpfilter.Text = "Filter By";
            // 
            // lblSupplierCode
            // 
            this.lblSupplierCode.AutoSize = true;
            this.lblSupplierCode.BackColor = System.Drawing.Color.Green;
            this.lblSupplierCode.Location = new System.Drawing.Point(734, 23);
            this.lblSupplierCode.Name = "lblSupplierCode";
            this.lblSupplierCode.Size = new System.Drawing.Size(16, 20);
            this.lblSupplierCode.TabIndex = 1111192;
            this.lblSupplierCode.Text = "0";
            this.lblSupplierCode.Visible = false;
            // 
            // dpToDate
            // 
            this.dpToDate.CustomFormat = "dd/MM/yyyy";
            this.dpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpToDate.Location = new System.Drawing.Point(390, 46);
            this.dpToDate.Name = "dpToDate";
            this.dpToDate.Size = new System.Drawing.Size(107, 27);
            this.dpToDate.TabIndex = 3;
            this.dpToDate.Enter += new System.EventHandler(this.DpToDate_Enter);
            this.dpToDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DpToDate_KeyDown);
            this.dpToDate.Leave += new System.EventHandler(this.DpToDate_Leave);
            // 
            // txtSupplier
            // 
            this.txtSupplier.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtSupplier.Location = new System.Drawing.Point(503, 46);
            this.txtSupplier.MaxLength = 100;
            this.txtSupplier.Name = "txtSupplier";
            this.txtSupplier.Size = new System.Drawing.Size(305, 27);
            this.txtSupplier.TabIndex = 4;
            this.txtSupplier.TextChanged += new System.EventHandler(this.TxtSupplier_TextChanged);
            this.txtSupplier.Enter += new System.EventHandler(this.TxtSupplier_Enter);
            this.txtSupplier.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtSupplier_KeyDown);
            this.txtSupplier.Leave += new System.EventHandler(this.TxtSupplier_Leave);
            // 
            // lblschedleCode
            // 
            this.lblschedleCode.AutoSize = true;
            this.lblschedleCode.BackColor = System.Drawing.Color.LimeGreen;
            this.lblschedleCode.Location = new System.Drawing.Point(712, 23);
            this.lblschedleCode.Name = "lblschedleCode";
            this.lblschedleCode.Size = new System.Drawing.Size(16, 20);
            this.lblschedleCode.TabIndex = 1111191;
            this.lblschedleCode.Text = "0";
            this.lblschedleCode.Visible = false;
            // 
            // dpFromDate
            // 
            this.dpFromDate.CustomFormat = "dd/MM/yyyy";
            this.dpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpFromDate.Location = new System.Drawing.Point(277, 46);
            this.dpFromDate.Name = "dpFromDate";
            this.dpFromDate.Size = new System.Drawing.Size(107, 27);
            this.dpFromDate.TabIndex = 2;
            this.dpFromDate.ValueChanged += new System.EventHandler(this.DpFromDate_ValueChanged);
            this.dpFromDate.Enter += new System.EventHandler(this.DpFromDate_Enter);
            this.dpFromDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DpFromDate_KeyDown);
            this.dpFromDate.Leave += new System.EventHandler(this.DpFromDate_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(390, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 20);
            this.label3.TabIndex = 1111190;
            this.label3.Text = "To Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(277, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 20);
            this.label1.TabIndex = 1111189;
            this.label1.Text = "From Date";
            // 
            // cmbPayType
            // 
            this.cmbPayType.FormattingEnabled = true;
            this.cmbPayType.Location = new System.Drawing.Point(814, 46);
            this.cmbPayType.Name = "cmbPayType";
            this.cmbPayType.Size = new System.Drawing.Size(120, 27);
            this.cmbPayType.TabIndex = 4;
            this.cmbPayType.Enter += new System.EventHandler(this.cmbPayType_Enter);
            this.cmbPayType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbPayType_KeyDown);
            this.cmbPayType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbPayType_KeyPress);
            this.cmbPayType.Leave += new System.EventHandler(this.cmbPayType_Leave);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(814, 23);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(56, 20);
            this.lblStatus.TabIndex = 1111182;
            this.lblStatus.Text = "Pay Type";
            // 
            // btnView
            // 
            this.btnView.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnView.Image = global::ROMS.Properties.Resources.view;
            this.btnView.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnView.Location = new System.Drawing.Point(940, 45);
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
            this.picLoader.Location = new System.Drawing.Point(3, 90);
            this.picLoader.Name = "picLoader";
            this.picLoader.Size = new System.Drawing.Size(1351, 552);
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
            this.RPTViewer.Location = new System.Drawing.Point(3, 90);
            this.RPTViewer.Name = "RPTViewer";
            this.RPTViewer.ReuseParameterValuesOnRefresh = true;
            this.RPTViewer.Size = new System.Drawing.Size(1348, 549);
            this.RPTViewer.TabIndex = 1111227;
            this.RPTViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.RPTViewer.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(203, 23);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 20);
            this.label10.TabIndex = 111111188;
            this.label10.Text = "Concern";
            // 
            // cmbConcern
            // 
            this.cmbConcern.FormattingEnabled = true;
            this.cmbConcern.Location = new System.Drawing.Point(203, 46);
            this.cmbConcern.Name = "cmbConcern";
            this.cmbConcern.Size = new System.Drawing.Size(68, 27);
            this.cmbConcern.TabIndex = 1;
            this.cmbConcern.Enter += new System.EventHandler(this.CmbConcern_Enter);
            this.cmbConcern.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbConcern_KeyDown);
            this.cmbConcern.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbConcern_KeyPress);
            this.cmbConcern.Leave += new System.EventHandler(this.CmbConcern_Leave);
            // 
            // cmbReportType
            // 
            this.cmbReportType.FormattingEnabled = true;
            this.cmbReportType.Location = new System.Drawing.Point(9, 46);
            this.cmbReportType.Name = "cmbReportType";
            this.cmbReportType.Size = new System.Drawing.Size(187, 27);
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
            this.lblReportType.Size = new System.Drawing.Size(73, 20);
            this.lblReportType.TabIndex = 111111187;
            this.lblReportType.Text = "Report type";
            // 
            // REPORT_Supplier_Payment
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
            this.Name = "REPORT_Supplier_Payment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Supplier Payment Report";
            this.Load += new System.EventHandler(this.REPORT_Purchase_Details_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.REPORT_GRN_Details_KeyDown);
            this.ReportSupplier.ResumeLayout(false);
            this.ReportSupplier.PerformLayout();
            this.pnlReportStockLocation.ResumeLayout(false);
            this.pnlReportStockLocation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_FilterProduct)).EndInit();
            this.grpfilter.ResumeLayout(false);
            this.grpfilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip ReportSupplier;
        private System.Windows.Forms.ToolStripLabel tspHeader;
        private System.Windows.Forms.Panel pnlReportStockLocation;
        private System.Windows.Forms.Label lblNoRecordsFound;
        private System.Windows.Forms.GroupBox grpfilter;
        public System.Windows.Forms.PictureBox picLoader;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer RPTViewer;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbPayType;
        private System.Windows.Forms.TextBox txtSupplier;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dpToDate;
        private System.Windows.Forms.DateTimePicker dpFromDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label lblSupplierCode;
        public System.Windows.Forms.Label lblschedleCode;
        public System.Windows.Forms.DataGridView DGV_FilterProduct;
        public System.Windows.Forms.ToolStripButton tsbPrintFormat;
        public System.Windows.Forms.ToolStripButton tsbFormat;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbConcern;
        private System.Windows.Forms.ComboBox cmbReportType;
        private System.Windows.Forms.Label lblReportType;
    }
}