namespace ROMS
{
    partial class REPORT_PUR_BatchDetails
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle79 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle80 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle81 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ReportCity = new System.Windows.Forms.ToolStrip();
            this.pnlReportCity = new System.Windows.Forms.Panel();
            this.grpfilter = new System.Windows.Forms.GroupBox();
            this.dpToDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbSupplierType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dpFromDate = new System.Windows.Forms.DateTimePicker();
            this.lblNoRecordsFound = new System.Windows.Forms.Label();
            this.RPTViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.epReport = new System.Windows.Forms.ErrorProvider(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.txtSupplier = new System.Windows.Forms.TextBox();
            this.lblSupplierCode = new System.Windows.Forms.Label();
            this.lblScheduleCode = new System.Windows.Forms.Label();
            this.DGV_FilterSupplier = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbPurchaseType = new System.Windows.Forms.ComboBox();
            this.cmbPaymentType = new System.Windows.Forms.ComboBox();
            this.cmbConditionType = new System.Windows.Forms.ComboBox();
            this.btnListPrint = new System.Windows.Forms.Button();
            this.picLoader = new System.Windows.Forms.PictureBox();
            this.tspHeader = new System.Windows.Forms.ToolStripLabel();
            this.cmbProductName = new System.Windows.Forms.ComboBox();
            this.lblProductName = new System.Windows.Forms.Label();
            this.ReportCity.SuspendLayout();
            this.pnlReportCity.SuspendLayout();
            this.grpfilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_FilterSupplier)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).BeginInit();
            this.SuspendLayout();
            // 
            // ReportCity
            // 
            this.ReportCity.BackColor = System.Drawing.Color.White;
            this.ReportCity.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReportCity.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ReportCity.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ReportCity.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspHeader});
            this.ReportCity.Location = new System.Drawing.Point(0, 0);
            this.ReportCity.Name = "ReportCity";
            this.ReportCity.Size = new System.Drawing.Size(1354, 25);
            this.ReportCity.TabIndex = 35;
            this.ReportCity.Text = "City Report";
            // 
            // pnlReportCity
            // 
            this.pnlReportCity.BackColor = System.Drawing.Color.White;
            this.pnlReportCity.Controls.Add(this.DGV_FilterSupplier);
            this.pnlReportCity.Controls.Add(this.label6);
            this.pnlReportCity.Controls.Add(this.btnListPrint);
            this.pnlReportCity.Controls.Add(this.grpfilter);
            this.pnlReportCity.Controls.Add(this.lblSupplierCode);
            this.pnlReportCity.Controls.Add(this.lblNoRecordsFound);
            this.pnlReportCity.Controls.Add(this.lblScheduleCode);
            this.pnlReportCity.Controls.Add(this.picLoader);
            this.pnlReportCity.Controls.Add(this.RPTViewer);
            this.pnlReportCity.Location = new System.Drawing.Point(0, 29);
            this.pnlReportCity.Name = "pnlReportCity";
            this.pnlReportCity.Size = new System.Drawing.Size(1354, 643);
            this.pnlReportCity.TabIndex = 958788;
            // 
            // grpfilter
            // 
            this.grpfilter.Controls.Add(this.lblProductName);
            this.grpfilter.Controls.Add(this.cmbProductName);
            this.grpfilter.Controls.Add(this.cmbConditionType);
            this.grpfilter.Controls.Add(this.cmbPaymentType);
            this.grpfilter.Controls.Add(this.cmbPurchaseType);
            this.grpfilter.Controls.Add(this.label7);
            this.grpfilter.Controls.Add(this.label5);
            this.grpfilter.Controls.Add(this.label4);
            this.grpfilter.Controls.Add(this.dpToDate);
            this.grpfilter.Controls.Add(this.label3);
            this.grpfilter.Controls.Add(this.txtSupplier);
            this.grpfilter.Controls.Add(this.label2);
            this.grpfilter.Controls.Add(this.cmbSupplierType);
            this.grpfilter.Controls.Add(this.label1);
            this.grpfilter.Controls.Add(this.dpFromDate);
            this.grpfilter.Location = new System.Drawing.Point(3, 0);
            this.grpfilter.Name = "grpfilter";
            this.grpfilter.Size = new System.Drawing.Size(1348, 84);
            this.grpfilter.TabIndex = 0;
            this.grpfilter.TabStop = false;
            this.grpfilter.Text = "Filter By";
            // 
            // dpToDate
            // 
            this.dpToDate.CustomFormat = "dd/MM/yyyy";
            this.dpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpToDate.Location = new System.Drawing.Point(123, 46);
            this.dpToDate.Name = "dpToDate";
            this.dpToDate.Size = new System.Drawing.Size(103, 27);
            this.dpToDate.TabIndex = 1;
            this.dpToDate.Enter += new System.EventHandler(this.DpToDate_Enter);
            this.dpToDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DpToDate_KeyDown);
            this.dpToDate.Leave += new System.EventHandler(this.DpToDate_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(123, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 20);
            this.label3.TabIndex = 111111188;
            this.label3.Text = "To Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(232, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 20);
            this.label2.TabIndex = 111111186;
            this.label2.Text = "Supplier Type";
            // 
            // cmbSupplierType
            // 
            this.cmbSupplierType.FormattingEnabled = true;
            this.cmbSupplierType.Location = new System.Drawing.Point(232, 46);
            this.cmbSupplierType.Name = "cmbSupplierType";
            this.cmbSupplierType.Size = new System.Drawing.Size(86, 27);
            this.cmbSupplierType.TabIndex = 2;
            this.cmbSupplierType.Enter += new System.EventHandler(this.CmbSupplierType_Enter);
            this.cmbSupplierType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbSupplierType_KeyDown);
            this.cmbSupplierType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbSupplierType_KeyPress);
            this.cmbSupplierType.Leave += new System.EventHandler(this.CmbSupplierType_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 20);
            this.label1.TabIndex = 111111184;
            this.label1.Text = "From Date";
            // 
            // dpFromDate
            // 
            this.dpFromDate.CustomFormat = "dd/MM/yyyy";
            this.dpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpFromDate.Location = new System.Drawing.Point(10, 46);
            this.dpFromDate.Name = "dpFromDate";
            this.dpFromDate.Size = new System.Drawing.Size(107, 27);
            this.dpFromDate.TabIndex = 0;
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
            this.lblNoRecordsFound.Location = new System.Drawing.Point(625, 356);
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
            this.RPTViewer.Location = new System.Drawing.Point(3, 90);
            this.RPTViewer.Name = "RPTViewer";
            this.RPTViewer.ReuseParameterValuesOnRefresh = true;
            this.RPTViewer.Size = new System.Drawing.Size(1348, 549);
            this.RPTViewer.TabIndex = 1111227;
            this.RPTViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.RPTViewer.Visible = false;
            // 
            // epReport
            // 
            this.epReport.ContainerControl = this;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(324, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 20);
            this.label6.TabIndex = 111111190;
            this.label6.Text = "Supplier Name";
            // 
            // txtSupplier
            // 
            this.txtSupplier.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtSupplier.Location = new System.Drawing.Point(324, 46);
            this.txtSupplier.MaxLength = 100;
            this.txtSupplier.Name = "txtSupplier";
            this.txtSupplier.Size = new System.Drawing.Size(282, 27);
            this.txtSupplier.TabIndex = 3;
            this.txtSupplier.TextChanged += new System.EventHandler(this.TxtSupplier_TextChanged);
            this.txtSupplier.Enter += new System.EventHandler(this.TxtSupplier_Enter);
            this.txtSupplier.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtSupplier_KeyDown);
            this.txtSupplier.Leave += new System.EventHandler(this.TxtSupplier_Leave);
            // 
            // lblSupplierCode
            // 
            this.lblSupplierCode.AutoSize = true;
            this.lblSupplierCode.BackColor = System.Drawing.Color.Green;
            this.lblSupplierCode.Location = new System.Drawing.Point(515, 24);
            this.lblSupplierCode.Name = "lblSupplierCode";
            this.lblSupplierCode.Size = new System.Drawing.Size(16, 20);
            this.lblSupplierCode.TabIndex = 111111192;
            this.lblSupplierCode.Text = "0";
            this.lblSupplierCode.Visible = false;
            // 
            // lblScheduleCode
            // 
            this.lblScheduleCode.AutoSize = true;
            this.lblScheduleCode.BackColor = System.Drawing.Color.LimeGreen;
            this.lblScheduleCode.Location = new System.Drawing.Point(493, 24);
            this.lblScheduleCode.Name = "lblScheduleCode";
            this.lblScheduleCode.Size = new System.Drawing.Size(16, 20);
            this.lblScheduleCode.TabIndex = 111111191;
            this.lblScheduleCode.Text = "0";
            this.lblScheduleCode.Visible = false;
            // 
            // DGV_FilterSupplier
            // 
            this.DGV_FilterSupplier.AllowUserToAddRows = false;
            this.DGV_FilterSupplier.AllowUserToDeleteRows = false;
            this.DGV_FilterSupplier.AllowUserToResizeColumns = false;
            this.DGV_FilterSupplier.AllowUserToResizeRows = false;
            this.DGV_FilterSupplier.BackgroundColor = System.Drawing.Color.White;
            this.DGV_FilterSupplier.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle79.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle79.BackColor = System.Drawing.Color.Chocolate;
            dataGridViewCellStyle79.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle79.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle79.SelectionBackColor = System.Drawing.Color.Chocolate;
            dataGridViewCellStyle79.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle79.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_FilterSupplier.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle79;
            this.DGV_FilterSupplier.ColumnHeadersHeight = 30;
            this.DGV_FilterSupplier.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle80.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle80.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle80.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle80.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle80.SelectionBackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle80.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle80.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV_FilterSupplier.DefaultCellStyle = dataGridViewCellStyle80;
            this.DGV_FilterSupplier.EnableHeadersVisualStyles = false;
            this.DGV_FilterSupplier.GridColor = System.Drawing.Color.White;
            this.DGV_FilterSupplier.Location = new System.Drawing.Point(328, 73);
            this.DGV_FilterSupplier.Name = "DGV_FilterSupplier";
            this.DGV_FilterSupplier.ReadOnly = true;
            this.DGV_FilterSupplier.RowHeadersVisible = false;
            this.DGV_FilterSupplier.RowHeadersWidth = 51;
            dataGridViewCellStyle81.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle81.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.DGV_FilterSupplier.RowsDefaultCellStyle = dataGridViewCellStyle81;
            this.DGV_FilterSupplier.RowTemplate.Height = 25;
            this.DGV_FilterSupplier.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV_FilterSupplier.Size = new System.Drawing.Size(281, 226);
            this.DGV_FilterSupplier.TabIndex = 111111193;
            this.DGV_FilterSupplier.Visible = false;
            this.DGV_FilterSupplier.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_FilterSupplier_CellDoubleClick);
            this.DGV_FilterSupplier.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DGV_FilterSupplier_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(612, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 20);
            this.label4.TabIndex = 111111190;
            this.label4.Text = "Purchase Type";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(716, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 20);
            this.label5.TabIndex = 111111191;
            this.label5.Text = "Payment Type";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(806, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 20);
            this.label7.TabIndex = 111111194;
            this.label7.Text = "Condition Type";
            // 
            // cmbPurchaseType
            // 
            this.cmbPurchaseType.FormattingEnabled = true;
            this.cmbPurchaseType.Location = new System.Drawing.Point(612, 46);
            this.cmbPurchaseType.Name = "cmbPurchaseType";
            this.cmbPurchaseType.Size = new System.Drawing.Size(98, 27);
            this.cmbPurchaseType.TabIndex = 4;
            this.cmbPurchaseType.Enter += new System.EventHandler(this.CmbPurchaseType_Enter);
            this.cmbPurchaseType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbPurchaseType_KeyDown);
            this.cmbPurchaseType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbPurchaseType_KeyPress);
            this.cmbPurchaseType.Leave += new System.EventHandler(this.CmbPurchaseType_Leave);
            // 
            // cmbPaymentType
            // 
            this.cmbPaymentType.FormattingEnabled = true;
            this.cmbPaymentType.Location = new System.Drawing.Point(716, 46);
            this.cmbPaymentType.Name = "cmbPaymentType";
            this.cmbPaymentType.Size = new System.Drawing.Size(84, 27);
            this.cmbPaymentType.TabIndex = 5;
            this.cmbPaymentType.Enter += new System.EventHandler(this.CmbPaymentType_Enter);
            this.cmbPaymentType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbPaymentType_KeyDown);
            this.cmbPaymentType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbPaymentType_KeyPress);
            this.cmbPaymentType.Leave += new System.EventHandler(this.CmbPaymentType_Leave);
            // 
            // cmbConditionType
            // 
            this.cmbConditionType.FormattingEnabled = true;
            this.cmbConditionType.Location = new System.Drawing.Point(806, 46);
            this.cmbConditionType.Name = "cmbConditionType";
            this.cmbConditionType.Size = new System.Drawing.Size(166, 27);
            this.cmbConditionType.TabIndex = 6;
            this.cmbConditionType.Enter += new System.EventHandler(this.CmbConditionType_Enter);
            this.cmbConditionType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbConditionType_KeyDown);
            this.cmbConditionType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbConditionType_KeyPress);
            this.cmbConditionType.Leave += new System.EventHandler(this.CmbConditionType_Leave);
            // 
            // btnListPrint
            // 
            this.btnListPrint.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListPrint.Image = global::ROMS.Properties.Resources.view;
            this.btnListPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnListPrint.Location = new System.Drawing.Point(1103, 45);
            this.btnListPrint.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnListPrint.Name = "btnListPrint";
            this.btnListPrint.Size = new System.Drawing.Size(75, 29);
            this.btnListPrint.TabIndex = 8;
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
            this.picLoader.Location = new System.Drawing.Point(3, 90);
            this.picLoader.Name = "picLoader";
            this.picLoader.Size = new System.Drawing.Size(1351, 552);
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
            this.tspHeader.Size = new System.Drawing.Size(190, 22);
            this.tspHeader.Text = "Purchase Batch Details Report";
            // 
            // cmbProductName
            // 
            this.cmbProductName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProductName.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbProductName.FormattingEnabled = true;
            this.cmbProductName.Location = new System.Drawing.Point(977, 45);
            this.cmbProductName.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.cmbProductName.Name = "cmbProductName";
            this.cmbProductName.Size = new System.Drawing.Size(118, 28);
            this.cmbProductName.TabIndex = 7;
            this.cmbProductName.Enter += new System.EventHandler(this.CmbProductName_Enter);
            this.cmbProductName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbProductName_KeyDown);
            this.cmbProductName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbProductName_KeyPress);
            this.cmbProductName.Leave += new System.EventHandler(this.CmbProductName_Leave);
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductName.Location = new System.Drawing.Point(977, 23);
            this.lblProductName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(85, 20);
            this.lblProductName.TabIndex = 111111200;
            this.lblProductName.Text = "Product Name";
            // 
            // REPORT_PUR_BatchDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(1354, 675);
            this.Controls.Add(this.pnlReportCity);
            this.Controls.Add(this.ReportCity);
            this.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "REPORT_PUR_BatchDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "City Report";
            this.Load += new System.EventHandler(this.REPORT_CP_City_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.REPORT_CP_City_KeyDown);
            this.ReportCity.ResumeLayout(false);
            this.ReportCity.PerformLayout();
            this.pnlReportCity.ResumeLayout(false);
            this.pnlReportCity.PerformLayout();
            this.grpfilter.ResumeLayout(false);
            this.grpfilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_FilterSupplier)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip ReportCity;
        private System.Windows.Forms.ToolStripLabel tspHeader;
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
        private System.Windows.Forms.ComboBox cmbSupplierType;
        private System.Windows.Forms.DateTimePicker dpToDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSupplier;
        public System.Windows.Forms.Label lblSupplierCode;
        public System.Windows.Forms.Label lblScheduleCode;
        public System.Windows.Forms.DataGridView DGV_FilterSupplier;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbConditionType;
        private System.Windows.Forms.ComboBox cmbPaymentType;
        private System.Windows.Forms.ComboBox cmbPurchaseType;
        public System.Windows.Forms.ComboBox cmbProductName;
        public System.Windows.Forms.Label lblProductName;
    }
}