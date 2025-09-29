namespace ROMS
{
    partial class REPORT_HSN_Tax_Summary
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ReportHSN = new System.Windows.Forms.ToolStrip();
            this.tspHeader = new System.Windows.Forms.ToolStripLabel();
            this.tsbPrintFormat = new System.Windows.Forms.ToolStripButton();
            this.tsbFormat = new System.Windows.Forms.ToolStripButton();
            this.pnlReportHSN = new System.Windows.Forms.Panel();
            this.DGV_FilterHSN = new System.Windows.Forms.DataGridView();
            this.lvHsnName = new System.Windows.Forms.ListView();
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader30 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader31 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grpfilter = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbSupplierType = new System.Windows.Forms.ComboBox();
            this.txtHsnName = new System.Windows.Forms.TextBox();
            this.dpToDate = new System.Windows.Forms.DateTimePicker();
            this.dpFromDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblHsnName = new System.Windows.Forms.Label();
            this.cmbGST = new System.Windows.Forms.ComboBox();
            this.lblGST = new System.Windows.Forms.Label();
            this.lblHSN = new System.Windows.Forms.Label();
            this.btnListPrint = new System.Windows.Forms.Button();
            this.lblNoRecordsFound = new System.Windows.Forms.Label();
            this.picLoader = new System.Windows.Forms.PictureBox();
            this.RPTViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.epReport = new System.Windows.Forms.ErrorProvider(this.components);
            this.ReportHSN.SuspendLayout();
            this.pnlReportHSN.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_FilterHSN)).BeginInit();
            this.grpfilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epReport)).BeginInit();
            this.SuspendLayout();
            // 
            // ReportHSN
            // 
            this.ReportHSN.BackColor = System.Drawing.Color.White;
            this.ReportHSN.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReportHSN.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ReportHSN.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ReportHSN.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspHeader,
            this.tsbPrintFormat,
            this.tsbFormat});
            this.ReportHSN.Location = new System.Drawing.Point(0, 0);
            this.ReportHSN.Name = "ReportHSN";
            this.ReportHSN.Size = new System.Drawing.Size(1354, 27);
            this.ReportHSN.TabIndex = 35;
            this.ReportHSN.Text = "HSN Report";
            // 
            // tspHeader
            // 
            this.tspHeader.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tspHeader.Image = global::ROMS.Properties.Resources.bread_crumb;
            this.tspHeader.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tspHeader.Margin = new System.Windows.Forms.Padding(15, 1, 0, 2);
            this.tspHeader.Name = "tspHeader";
            this.tspHeader.Size = new System.Drawing.Size(226, 24);
            this.tspHeader.Text = "HSN Wise Tax Detail Summary Report";
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
            // pnlReportHSN
            // 
            this.pnlReportHSN.BackColor = System.Drawing.Color.White;
            this.pnlReportHSN.Controls.Add(this.DGV_FilterHSN);
            this.pnlReportHSN.Controls.Add(this.lvHsnName);
            this.pnlReportHSN.Controls.Add(this.grpfilter);
            this.pnlReportHSN.Controls.Add(this.lblNoRecordsFound);
            this.pnlReportHSN.Controls.Add(this.picLoader);
            this.pnlReportHSN.Controls.Add(this.RPTViewer);
            this.pnlReportHSN.Location = new System.Drawing.Point(0, 29);
            this.pnlReportHSN.Name = "pnlReportHSN";
            this.pnlReportHSN.Size = new System.Drawing.Size(1354, 643);
            this.pnlReportHSN.TabIndex = 958788;
            // 
            // DGV_FilterHSN
            // 
            this.DGV_FilterHSN.AllowUserToAddRows = false;
            this.DGV_FilterHSN.AllowUserToDeleteRows = false;
            this.DGV_FilterHSN.AllowUserToResizeColumns = false;
            this.DGV_FilterHSN.AllowUserToResizeRows = false;
            this.DGV_FilterHSN.BackgroundColor = System.Drawing.Color.White;
            this.DGV_FilterHSN.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.Chocolate;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.Chocolate;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_FilterHSN.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.DGV_FilterHSN.ColumnHeadersHeight = 30;
            this.DGV_FilterHSN.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV_FilterHSN.DefaultCellStyle = dataGridViewCellStyle8;
            this.DGV_FilterHSN.EnableHeadersVisualStyles = false;
            this.DGV_FilterHSN.GridColor = System.Drawing.Color.White;
            this.DGV_FilterHSN.Location = new System.Drawing.Point(387, 73);
            this.DGV_FilterHSN.Name = "DGV_FilterHSN";
            this.DGV_FilterHSN.ReadOnly = true;
            this.DGV_FilterHSN.RowHeadersVisible = false;
            this.DGV_FilterHSN.RowHeadersWidth = 51;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.DGV_FilterHSN.RowsDefaultCellStyle = dataGridViewCellStyle9;
            this.DGV_FilterHSN.RowTemplate.Height = 25;
            this.DGV_FilterHSN.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV_FilterHSN.Size = new System.Drawing.Size(218, 226);
            this.DGV_FilterHSN.TabIndex = 1111231;
            this.DGV_FilterHSN.Visible = false;
            this.DGV_FilterHSN.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_FilterProduct_CellDoubleClick);
            this.DGV_FilterHSN.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DGV_FilterProduct_KeyDown);
            // 
            // lvHsnName
            // 
            this.lvHsnName.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader10,
            this.columnHeader30,
            this.columnHeader31});
            this.lvHsnName.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvHsnName.HideSelection = false;
            this.lvHsnName.Location = new System.Drawing.Point(387, 73);
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
            this.grpfilter.Controls.Add(this.label2);
            this.grpfilter.Controls.Add(this.cmbSupplierType);
            this.grpfilter.Controls.Add(this.txtHsnName);
            this.grpfilter.Controls.Add(this.dpToDate);
            this.grpfilter.Controls.Add(this.dpFromDate);
            this.grpfilter.Controls.Add(this.label3);
            this.grpfilter.Controls.Add(this.label1);
            this.grpfilter.Controls.Add(this.lblHsnName);
            this.grpfilter.Controls.Add(this.cmbGST);
            this.grpfilter.Controls.Add(this.lblGST);
            this.grpfilter.Controls.Add(this.lblHSN);
            this.grpfilter.Controls.Add(this.btnListPrint);
            this.grpfilter.Location = new System.Drawing.Point(3, 2);
            this.grpfilter.Name = "grpfilter";
            this.grpfilter.Size = new System.Drawing.Size(1348, 92);
            this.grpfilter.TabIndex = 0;
            this.grpfilter.TabStop = false;
            this.grpfilter.Text = "Filter By";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(235, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 20);
            this.label2.TabIndex = 1111229;
            this.label2.Text = "Supplier Type";
            // 
            // cmbSupplierType
            // 
            this.cmbSupplierType.FormattingEnabled = true;
            this.cmbSupplierType.Location = new System.Drawing.Point(235, 44);
            this.cmbSupplierType.Name = "cmbSupplierType";
            this.cmbSupplierType.Size = new System.Drawing.Size(143, 27);
            this.cmbSupplierType.TabIndex = 3;
            this.cmbSupplierType.SelectedIndexChanged += new System.EventHandler(this.CmbSupplierType_SelectedIndexChanged);
            this.cmbSupplierType.Enter += new System.EventHandler(this.CmbSupplierType_Enter);
            this.cmbSupplierType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbSupplierType_KeyDown);
            this.cmbSupplierType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbSupplierType_KeyPress);
            this.cmbSupplierType.Leave += new System.EventHandler(this.CmbSupplierType_Leave);
            // 
            // txtHsnName
            // 
            this.txtHsnName.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtHsnName.Location = new System.Drawing.Point(384, 44);
            this.txtHsnName.MaxLength = 50;
            this.txtHsnName.Name = "txtHsnName";
            this.txtHsnName.Size = new System.Drawing.Size(177, 27);
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
            this.dpToDate.Location = new System.Drawing.Point(122, 45);
            this.dpToDate.Name = "dpToDate";
            this.dpToDate.Size = new System.Drawing.Size(107, 27);
            this.dpToDate.TabIndex = 2;
            this.dpToDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DpToDate_KeyDown);
            // 
            // dpFromDate
            // 
            this.dpFromDate.CustomFormat = "dd/MM/yyyy";
            this.dpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpFromDate.Location = new System.Drawing.Point(9, 45);
            this.dpFromDate.Name = "dpFromDate";
            this.dpFromDate.Size = new System.Drawing.Size(107, 27);
            this.dpFromDate.TabIndex = 1;
            this.dpFromDate.ValueChanged += new System.EventHandler(this.dpFromDate_ValueChanged);
            this.dpFromDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DpFromDate_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(122, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 20);
            this.label3.TabIndex = 1111194;
            this.label3.Text = "To Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 20);
            this.label1.TabIndex = 1111193;
            this.label1.Text = "From Date";
            // 
            // lblHsnName
            // 
            this.lblHsnName.AutoSize = true;
            this.lblHsnName.Location = new System.Drawing.Point(452, 23);
            this.lblHsnName.Name = "lblHsnName";
            this.lblHsnName.Size = new System.Drawing.Size(16, 20);
            this.lblHsnName.TabIndex = 958789;
            this.lblHsnName.Text = "0";
            this.lblHsnName.Visible = false;
            // 
            // cmbGST
            // 
            this.cmbGST.FormattingEnabled = true;
            this.cmbGST.Location = new System.Drawing.Point(567, 44);
            this.cmbGST.Name = "cmbGST";
            this.cmbGST.Size = new System.Drawing.Size(109, 27);
            this.cmbGST.TabIndex = 5;
            this.cmbGST.Enter += new System.EventHandler(this.CmbGST_Enter);
            this.cmbGST.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbGST_KeyDown);
            this.cmbGST.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbGST_KeyPress);
            this.cmbGST.Leave += new System.EventHandler(this.CmbGST_Leave);
            // 
            // lblGST
            // 
            this.lblGST.AutoSize = true;
            this.lblGST.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGST.Location = new System.Drawing.Point(567, 22);
            this.lblGST.Name = "lblGST";
            this.lblGST.Size = new System.Drawing.Size(30, 20);
            this.lblGST.TabIndex = 1111180;
            this.lblGST.Text = "GST";
            // 
            // lblHSN
            // 
            this.lblHSN.AutoSize = true;
            this.lblHSN.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHSN.Location = new System.Drawing.Point(384, 22);
            this.lblHSN.Name = "lblHSN";
            this.lblHSN.Size = new System.Drawing.Size(62, 20);
            this.lblHSN.TabIndex = 1111178;
            this.lblHSN.Text = "HSN Code";
            // 
            // btnListPrint
            // 
            this.btnListPrint.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListPrint.Image = global::ROMS.Properties.Resources.view;
            this.btnListPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnListPrint.Location = new System.Drawing.Point(682, 43);
            this.btnListPrint.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnListPrint.Name = "btnListPrint";
            this.btnListPrint.Size = new System.Drawing.Size(75, 29);
            this.btnListPrint.TabIndex = 6;
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
            this.picLoader.Location = new System.Drawing.Point(3, 100);
            this.picLoader.Name = "picLoader";
            this.picLoader.Size = new System.Drawing.Size(1351, 542);
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
            // REPORT_HSN_Tax_Summary
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
            this.Name = "REPORT_HSN_Tax_Summary";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HSN Report";
            this.Load += new System.EventHandler(this.REPORT_CP_HSN_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.REPORT_CP_HSN_KeyDown);
            this.ReportHSN.ResumeLayout(false);
            this.ReportHSN.PerformLayout();
            this.pnlReportHSN.ResumeLayout(false);
            this.pnlReportHSN.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_FilterHSN)).EndInit();
            this.grpfilter.ResumeLayout(false);
            this.grpfilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epReport)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip ReportHSN;
        private System.Windows.Forms.ToolStripLabel tspHeader;
        private System.Windows.Forms.Panel pnlReportHSN;
        private System.Windows.Forms.Label lblNoRecordsFound;
        private System.Windows.Forms.GroupBox grpfilter;
        public System.Windows.Forms.PictureBox picLoader;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer RPTViewer;
        private System.Windows.Forms.Button btnListPrint;
        private System.Windows.Forms.Label lblHSN;
        private System.Windows.Forms.Label lblGST;
        private System.Windows.Forms.ComboBox cmbGST;
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
        private System.Windows.Forms.ErrorProvider epReport;
        public System.Windows.Forms.DataGridView DGV_FilterHSN;
        public System.Windows.Forms.ToolStripButton tsbPrintFormat;
        public System.Windows.Forms.ToolStripButton tsbFormat;
    }
}