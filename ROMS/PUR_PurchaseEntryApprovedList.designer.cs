namespace ROMS
{
    partial class PUR_PurchaseEntryApprovedList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tsBrandList = new System.Windows.Forms.ToolStrip();
            this.tspHeader = new System.Windows.Forms.ToolStripLabel();
            this.tsbQue = new System.Windows.Forms.ToolStripButton();
            this.tssEdit = new System.Windows.Forms.ToolStripSeparator();
            this.tsbEdit = new System.Windows.Forms.ToolStripButton();
            this.pnlpurchaseapproval = new System.Windows.Forms.Panel();
            this.lvSupplier = new System.Windows.Forms.ListView();
            this.columnHeader21 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader22 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader23 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnExport = new System.Windows.Forms.Button();
            this.grdPurchaseEntryApproval = new System.Windows.Forms.DataGridView();
            this.clmCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clmUnapproved = new System.Windows.Forms.DataGridViewImageColumn();
            this.lblNoRecordsFound = new System.Windows.Forms.Label();
            this.grpfilter = new System.Windows.Forms.GroupBox();
            this.btnTally = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblschedleCode = new System.Windows.Forms.Label();
            this.lblScheduleCode = new System.Windows.Forms.Label();
            this.lblSupplierCode = new System.Windows.Forms.Label();
            this.cmbReason = new System.Windows.Forms.ComboBox();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.txtSupplier = new System.Windows.Forms.TextBox();
            this.dpToDate = new System.Windows.Forms.DateTimePicker();
            this.dpFromDate = new System.Windows.Forms.DateTimePicker();
            this.cmbConcern = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.btnView = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DGV_SearchGrid = new System.Windows.Forms.DataGridView();
            this.picLoader = new System.Windows.Forms.PictureBox();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.errPurchaseEntryApproval = new System.Windows.Forms.ErrorProvider(this.components);
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.tsBrandList.SuspendLayout();
            this.pnlpurchaseapproval.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPurchaseEntryApproval)).BeginInit();
            this.grpfilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_SearchGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errPurchaseEntryApproval)).BeginInit();
            this.SuspendLayout();
            // 
            // tsBrandList
            // 
            this.tsBrandList.BackColor = System.Drawing.Color.White;
            this.tsBrandList.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsBrandList.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsBrandList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspHeader,
            this.tsbQue,
            this.tssEdit,
            this.tsbEdit});
            this.tsBrandList.Location = new System.Drawing.Point(0, 0);
            this.tsBrandList.Name = "tsBrandList";
            this.tsBrandList.Size = new System.Drawing.Size(1354, 27);
            this.tsBrandList.TabIndex = 35;
            this.tsBrandList.Text = "Brand";
            // 
            // tspHeader
            // 
            this.tspHeader.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tspHeader.Image = global::ROMS.Properties.Resources.bread_crumb;
            this.tspHeader.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tspHeader.Margin = new System.Windows.Forms.Padding(15, 1, 0, 2);
            this.tspHeader.Name = "tspHeader";
            this.tspHeader.Size = new System.Drawing.Size(184, 24);
            this.tspHeader.Text = "Purchase Entry Approved List";
            // 
            // tsbQue
            // 
            this.tsbQue.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbQue.Image = global::ROMS.Properties.Resources.queue;
            this.tsbQue.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbQue.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbQue.Margin = new System.Windows.Forms.Padding(0, 1, 15, 2);
            this.tsbQue.Name = "tsbQue";
            this.tsbQue.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tsbQue.Size = new System.Drawing.Size(161, 24);
            this.tsbQue.Text = "Purchase Entry Approval";
            this.tsbQue.Click += new System.EventHandler(this.TsbQue_Click);
            // 
            // tssEdit
            // 
            this.tssEdit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tssEdit.Margin = new System.Windows.Forms.Padding(0, 0, 15, 0);
            this.tssEdit.Name = "tssEdit";
            this.tssEdit.Size = new System.Drawing.Size(6, 27);
            // 
            // tsbEdit
            // 
            this.tsbEdit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbEdit.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsbEdit.Image = global::ROMS.Properties.Resources.Edit;
            this.tsbEdit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEdit.Margin = new System.Windows.Forms.Padding(0, 1, 15, 2);
            this.tsbEdit.Name = "tsbEdit";
            this.tsbEdit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tsbEdit.Size = new System.Drawing.Size(50, 24);
            this.tsbEdit.Text = "&Edit";
            this.tsbEdit.Click += new System.EventHandler(this.TsbEdit_Click);
            // 
            // pnlpurchaseapproval
            // 
            this.pnlpurchaseapproval.BackColor = System.Drawing.Color.White;
            this.pnlpurchaseapproval.Controls.Add(this.lvSupplier);
            this.pnlpurchaseapproval.Controls.Add(this.btnExport);
            this.pnlpurchaseapproval.Controls.Add(this.grdPurchaseEntryApproval);
            this.pnlpurchaseapproval.Controls.Add(this.lblNoRecordsFound);
            this.pnlpurchaseapproval.Controls.Add(this.grpfilter);
            this.pnlpurchaseapproval.Controls.Add(this.DGV_SearchGrid);
            this.pnlpurchaseapproval.Controls.Add(this.picLoader);
            this.pnlpurchaseapproval.Location = new System.Drawing.Point(0, 29);
            this.pnlpurchaseapproval.Name = "pnlpurchaseapproval";
            this.pnlpurchaseapproval.Size = new System.Drawing.Size(1354, 643);
            this.pnlpurchaseapproval.TabIndex = 958789;
            // 
            // lvSupplier
            // 
            this.lvSupplier.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader21,
            this.columnHeader22,
            this.columnHeader23});
            this.lvSupplier.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.lvSupplier.FullRowSelect = true;
            this.lvSupplier.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvSupplier.HideSelection = false;
            this.lvSupplier.Location = new System.Drawing.Point(571, 53);
            this.lvSupplier.Name = "lvSupplier";
            this.lvSupplier.Size = new System.Drawing.Size(457, 219);
            this.lvSupplier.TabIndex = 111111145;
            this.lvSupplier.UseCompatibleStateImageBehavior = false;
            this.lvSupplier.View = System.Windows.Forms.View.Details;
            this.lvSupplier.Visible = false;
            this.lvSupplier.DoubleClick += new System.EventHandler(this.LvSupplier_DoubleClick);
            this.lvSupplier.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LvSupplier_KeyDown);
            // 
            // columnHeader21
            // 
            this.columnHeader21.Width = 250;
            // 
            // columnHeader22
            // 
            this.columnHeader22.Width = 0;
            // 
            // columnHeader23
            // 
            this.columnHeader23.Width = 0;
            // 
            // btnExport
            // 
            this.btnExport.Image = global::ROMS.Properties.Resources.excel;
            this.btnExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExport.Location = new System.Drawing.Point(930, 25);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(74, 29);
            this.btnExport.TabIndex = 5;
            this.btnExport.Text = "Export";
            this.btnExport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.BtnExport_Click);
            this.btnExport.Enter += new System.EventHandler(this.BtnExport_Enter);
            this.btnExport.Leave += new System.EventHandler(this.BtnExport_Leave);
            // 
            // grdPurchaseEntryApproval
            // 
            this.grdPurchaseEntryApproval.AllowUserToAddRows = false;
            this.grdPurchaseEntryApproval.AllowUserToDeleteRows = false;
            this.grdPurchaseEntryApproval.AllowUserToResizeColumns = false;
            this.grdPurchaseEntryApproval.AllowUserToResizeRows = false;
            this.grdPurchaseEntryApproval.BackgroundColor = System.Drawing.Color.White;
            this.grdPurchaseEntryApproval.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdPurchaseEntryApproval.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdPurchaseEntryApproval.ColumnHeadersHeight = 30;
            this.grdPurchaseEntryApproval.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdPurchaseEntryApproval.ColumnHeadersVisible = false;
            this.grdPurchaseEntryApproval.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmCheck,
            this.clmUnapproved});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdPurchaseEntryApproval.DefaultCellStyle = dataGridViewCellStyle2;
            this.grdPurchaseEntryApproval.EnableHeadersVisualStyles = false;
            this.grdPurchaseEntryApproval.GridColor = System.Drawing.Color.White;
            this.grdPurchaseEntryApproval.Location = new System.Drawing.Point(3, 130);
            this.grdPurchaseEntryApproval.Name = "grdPurchaseEntryApproval";
            this.grdPurchaseEntryApproval.RowHeadersVisible = false;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.grdPurchaseEntryApproval.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.grdPurchaseEntryApproval.RowTemplate.Height = 25;
            this.grdPurchaseEntryApproval.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdPurchaseEntryApproval.ShowRowErrors = false;
            this.grdPurchaseEntryApproval.Size = new System.Drawing.Size(1348, 513);
            this.grdPurchaseEntryApproval.TabIndex = 111111148;
            this.grdPurchaseEntryApproval.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrdPurchaseEntryApproval_CellContentClick);
            this.grdPurchaseEntryApproval.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.GrdPurchaseEntryApproval_CellFormatting);
            this.grdPurchaseEntryApproval.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.GrdPurchaseEntryApproval_DataBindingComplete);
            this.grdPurchaseEntryApproval.Scroll += new System.Windows.Forms.ScrollEventHandler(this.GrdPurchaseEntryApproval_Scroll);
            this.grdPurchaseEntryApproval.DoubleClick += new System.EventHandler(this.GrdPurchaseApproval_DoubleClick);
            this.grdPurchaseEntryApproval.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GrdPurchaseEntryApproval_KeyDown);
            // 
            // clmCheck
            // 
            this.clmCheck.HeaderText = "";
            this.clmCheck.Name = "clmCheck";
            this.clmCheck.Width = 50;
            // 
            // clmUnapproved
            // 
            this.clmUnapproved.HeaderText = "Unapprove";
            this.clmUnapproved.Image = global::ROMS.Properties.Resources.Unapproved;
            this.clmUnapproved.Name = "clmUnapproved";
            this.clmUnapproved.Width = 90;
            // 
            // lblNoRecordsFound
            // 
            this.lblNoRecordsFound.AutoSize = true;
            this.lblNoRecordsFound.BackColor = System.Drawing.Color.White;
            this.lblNoRecordsFound.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoRecordsFound.Location = new System.Drawing.Point(624, 375);
            this.lblNoRecordsFound.Name = "lblNoRecordsFound";
            this.lblNoRecordsFound.Size = new System.Drawing.Size(106, 20);
            this.lblNoRecordsFound.TabIndex = 111111146;
            this.lblNoRecordsFound.Text = "No Records Found";
            this.lblNoRecordsFound.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // grpfilter
            // 
            this.grpfilter.Controls.Add(this.btnTally);
            this.grpfilter.Controls.Add(this.label3);
            this.grpfilter.Controls.Add(this.label5);
            this.grpfilter.Controls.Add(this.lblschedleCode);
            this.grpfilter.Controls.Add(this.lblScheduleCode);
            this.grpfilter.Controls.Add(this.lblSupplierCode);
            this.grpfilter.Controls.Add(this.cmbReason);
            this.grpfilter.Controls.Add(this.cmbStatus);
            this.grpfilter.Controls.Add(this.txtSupplier);
            this.grpfilter.Controls.Add(this.dpToDate);
            this.grpfilter.Controls.Add(this.dpFromDate);
            this.grpfilter.Controls.Add(this.cmbConcern);
            this.grpfilter.Controls.Add(this.label4);
            this.grpfilter.Controls.Add(this.label12);
            this.grpfilter.Controls.Add(this.btnView);
            this.grpfilter.Controls.Add(this.label2);
            this.grpfilter.Controls.Add(this.label1);
            this.grpfilter.Location = new System.Drawing.Point(3, 2);
            this.grpfilter.Name = "grpfilter";
            this.grpfilter.Size = new System.Drawing.Size(1345, 67);
            this.grpfilter.TabIndex = 0;
            this.grpfilter.TabStop = false;
            this.grpfilter.Text = "Filter By";
            // 
            // btnTally
            // 
            this.btnTally.Location = new System.Drawing.Point(1007, 23);
            this.btnTally.Name = "btnTally";
            this.btnTally.Size = new System.Drawing.Size(93, 29);
            this.btnTally.TabIndex = 6;
            this.btnTally.Text = "Export to Tally";
            this.btnTally.UseVisualStyleBackColor = true;
            this.btnTally.Click += new System.EventHandler(this.BtnTally_Click);
            this.btnTally.Enter += new System.EventHandler(this.BtnTally_Enter);
            this.btnTally.Leave += new System.EventHandler(this.BtnTally_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1078, 157);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 20);
            this.label3.TabIndex = 1111175;
            this.label3.Text = "Status";
            this.label3.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Green;
            this.label5.Location = new System.Drawing.Point(691, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 20);
            this.label5.TabIndex = 1111199;
            this.label5.Text = "0";
            this.label5.Visible = false;
            // 
            // lblschedleCode
            // 
            this.lblschedleCode.AutoSize = true;
            this.lblschedleCode.BackColor = System.Drawing.Color.LimeGreen;
            this.lblschedleCode.Location = new System.Drawing.Point(637, 26);
            this.lblschedleCode.Name = "lblschedleCode";
            this.lblschedleCode.Size = new System.Drawing.Size(16, 20);
            this.lblschedleCode.TabIndex = 1111198;
            this.lblschedleCode.Text = "0";
            this.lblschedleCode.Visible = false;
            // 
            // lblScheduleCode
            // 
            this.lblScheduleCode.AutoSize = true;
            this.lblScheduleCode.Location = new System.Drawing.Point(775, 1);
            this.lblScheduleCode.Name = "lblScheduleCode";
            this.lblScheduleCode.Size = new System.Drawing.Size(0, 20);
            this.lblScheduleCode.TabIndex = 1111179;
            this.lblScheduleCode.Visible = false;
            // 
            // lblSupplierCode
            // 
            this.lblSupplierCode.AutoSize = true;
            this.lblSupplierCode.Location = new System.Drawing.Point(631, 1);
            this.lblSupplierCode.Name = "lblSupplierCode";
            this.lblSupplierCode.Size = new System.Drawing.Size(0, 20);
            this.lblSupplierCode.TabIndex = 1111178;
            this.lblSupplierCode.Visible = false;
            // 
            // cmbReason
            // 
            this.cmbReason.FormattingEnabled = true;
            this.cmbReason.Location = new System.Drawing.Point(1177, 19);
            this.cmbReason.Name = "cmbReason";
            this.cmbReason.Size = new System.Drawing.Size(174, 27);
            this.cmbReason.TabIndex = 55676888;
            this.cmbReason.Visible = false;
            this.cmbReason.Enter += new System.EventHandler(this.CmbReason_Enter);
            this.cmbReason.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbReason_KeyDown);
            this.cmbReason.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbReason_KeyPress);
            this.cmbReason.Leave += new System.EventHandler(this.CmbReason_Leave);
            // 
            // cmbStatus
            // 
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(945, 157);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(127, 27);
            this.cmbStatus.TabIndex = 132344556;
            this.cmbStatus.Visible = false;
            this.cmbStatus.Enter += new System.EventHandler(this.CmbStatus_Enter);
            this.cmbStatus.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbStatus_KeyDown);
            this.cmbStatus.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbStatus_KeyPress);
            this.cmbStatus.Leave += new System.EventHandler(this.CmbStatus_Leave);
            // 
            // txtSupplier
            // 
            this.txtSupplier.Location = new System.Drawing.Point(568, 24);
            this.txtSupplier.MaxLength = 50;
            this.txtSupplier.Name = "txtSupplier";
            this.txtSupplier.Size = new System.Drawing.Size(273, 27);
            this.txtSupplier.TabIndex = 3;
            this.txtSupplier.TextChanged += new System.EventHandler(this.TxtSupplierName_TextChanged);
            this.txtSupplier.Enter += new System.EventHandler(this.TxtSupplierName_Enter);
            this.txtSupplier.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtSupplierName_KeyDown);
            this.txtSupplier.Leave += new System.EventHandler(this.TxtSupplierName_Leave);
            // 
            // dpToDate
            // 
            this.dpToDate.CustomFormat = "dd/MM/yyyy";
            this.dpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpToDate.Location = new System.Drawing.Point(364, 24);
            this.dpToDate.Name = "dpToDate";
            this.dpToDate.Size = new System.Drawing.Size(107, 27);
            this.dpToDate.TabIndex = 2;
            this.dpToDate.Enter += new System.EventHandler(this.DpToDate_Enter);
            this.dpToDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DpToDate_KeyDown);
            this.dpToDate.Leave += new System.EventHandler(this.DpToDate_Leave);
            // 
            // dpFromDate
            // 
            this.dpFromDate.CustomFormat = "dd/MM/yyyy";
            this.dpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpFromDate.Location = new System.Drawing.Point(251, 24);
            this.dpFromDate.Name = "dpFromDate";
            this.dpFromDate.Size = new System.Drawing.Size(107, 27);
            this.dpFromDate.TabIndex = 1;
            this.dpFromDate.ValueChanged += new System.EventHandler(this.DpFromDate_ValueChanged);
            this.dpFromDate.Enter += new System.EventHandler(this.DpFromDate_Enter);
            this.dpFromDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DpFromDate_KeyDown);
            this.dpFromDate.Leave += new System.EventHandler(this.DpFromDate_Leave);
            // 
            // cmbConcern
            // 
            this.cmbConcern.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbConcern.FormattingEnabled = true;
            this.cmbConcern.Location = new System.Drawing.Point(66, 24);
            this.cmbConcern.Name = "cmbConcern";
            this.cmbConcern.Size = new System.Drawing.Size(91, 27);
            this.cmbConcern.TabIndex = 0;
            this.cmbConcern.Enter += new System.EventHandler(this.CmbConcern_Enter);
            this.cmbConcern.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbConcern_KeyDown);
            this.cmbConcern.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbConcern_KeyPress);
            this.cmbConcern.Leave += new System.EventHandler(this.CmbConcern_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(1198, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 20);
            this.label4.TabIndex = 1111177;
            this.label4.Text = "Reason";
            this.label4.Visible = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(6, 27);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(54, 20);
            this.label12.TabIndex = 1111173;
            this.label12.Text = "Concern";
            // 
            // btnView
            // 
            this.btnView.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnView.Image = global::ROMS.Properties.Resources.view;
            this.btnView.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnView.Location = new System.Drawing.Point(847, 23);
            this.btnView.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(74, 29);
            this.btnView.TabIndex = 4;
            this.btnView.Text = "View";
            this.btnView.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.BtnView_Click);
            this.btnView.Enter += new System.EventHandler(this.BtnView_Enter);
            this.btnView.Leave += new System.EventHandler(this.BtnView_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(475, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 20);
            this.label2.TabIndex = 1111140;
            this.label2.Text = "Supplier Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(163, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 20);
            this.label1.TabIndex = 1111139;
            this.label1.Text = "Approval Date";
            // 
            // DGV_SearchGrid
            // 
            this.DGV_SearchGrid.AllowUserToAddRows = false;
            this.DGV_SearchGrid.AllowUserToDeleteRows = false;
            this.DGV_SearchGrid.AllowUserToResizeRows = false;
            this.DGV_SearchGrid.BackgroundColor = System.Drawing.Color.White;
            this.DGV_SearchGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_SearchGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.DGV_SearchGrid.ColumnHeadersHeight = 30;
            this.DGV_SearchGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV_SearchGrid.DefaultCellStyle = dataGridViewCellStyle5;
            this.DGV_SearchGrid.EnableHeadersVisualStyles = false;
            this.DGV_SearchGrid.GridColor = System.Drawing.Color.White;
            this.DGV_SearchGrid.Location = new System.Drawing.Point(3, 74);
            this.DGV_SearchGrid.Name = "DGV_SearchGrid";
            this.DGV_SearchGrid.RowHeadersVisible = false;
            this.DGV_SearchGrid.RowHeadersWidth = 70;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            this.DGV_SearchGrid.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.DGV_SearchGrid.RowTemplate.Height = 25;
            this.DGV_SearchGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DGV_SearchGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DGV_SearchGrid.ShowRowErrors = false;
            this.DGV_SearchGrid.Size = new System.Drawing.Size(1348, 56);
            this.DGV_SearchGrid.TabIndex = 958798;
            this.DGV_SearchGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_SearchGrid_CellEndEdit);
            this.DGV_SearchGrid.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DGV_SearchGrid_CellFormatting);
            this.DGV_SearchGrid.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.DGV_SearchGrid_CellPainting);
            this.DGV_SearchGrid.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DGV_SearchGrid_ColumnHeaderMouseClick);
            this.DGV_SearchGrid.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.DGV_SearchGrid_ColumnWidthChanged);
            this.DGV_SearchGrid.CurrentCellDirtyStateChanged += new System.EventHandler(this.DGV_SearchGrid_CurrentCellDirtyStateChanged);
            this.DGV_SearchGrid.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.DGV_SearchGrid_EditingControlShowing);
            this.DGV_SearchGrid.Scroll += new System.Windows.Forms.ScrollEventHandler(this.DGV_SearchGrid_Scroll);
            // 
            // picLoader
            // 
            this.picLoader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picLoader.ErrorImage = null;
            this.picLoader.Image = global::ROMS.Properties.Resources.Iphone_spinner_2;
            this.picLoader.InitialImage = null;
            this.picLoader.Location = new System.Drawing.Point(4, 132);
            this.picLoader.Name = "picLoader";
            this.picLoader.Size = new System.Drawing.Size(1347, 510);
            this.picLoader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picLoader.TabIndex = 111111147;
            this.picLoader.TabStop = false;
            this.picLoader.Visible = false;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Reason";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // errPurchaseEntryApproval
            // 
            this.errPurchaseEntryApproval.ContainerControl = this;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "Unapprove";
            this.dataGridViewImageColumn1.Image = global::ROMS.Properties.Resources.Pur_Unapproved;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Width = 90;
            // 
            // PUR_PurchaseEntryApprovedList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(1354, 675);
            this.Controls.Add(this.pnlpurchaseapproval);
            this.Controls.Add(this.tsBrandList);
            this.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "PUR_PurchaseEntryApprovedList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Purchase Entry Approval";
            this.Load += new System.EventHandler(this.PUR_PurchaseApprovalList_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PUR_PurchaseApprovalList_KeyDown);
            this.Leave += new System.EventHandler(this.PUR_PurchaseApprovalList_Leave);
            this.tsBrandList.ResumeLayout(false);
            this.tsBrandList.PerformLayout();
            this.pnlpurchaseapproval.ResumeLayout(false);
            this.pnlpurchaseapproval.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPurchaseEntryApproval)).EndInit();
            this.grpfilter.ResumeLayout(false);
            this.grpfilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_SearchGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errPurchaseEntryApproval)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsBrandList;
        private System.Windows.Forms.ToolStripLabel tspHeader;
        private System.Windows.Forms.Panel pnlpurchaseapproval;
        public System.Windows.Forms.DataGridView DGV_SearchGrid;
        private System.Windows.Forms.GroupBox grpfilter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.ComboBox cmbConcern;
        private System.Windows.Forms.DateTimePicker dpFromDate;
        private System.Windows.Forms.DateTimePicker dpToDate;
        private System.Windows.Forms.TextBox txtSupplier;
        private System.Windows.Forms.ComboBox cmbReason;
        private System.Windows.Forms.ComboBox cmbStatus;
        public System.Windows.Forms.ListView lvSupplier;
        private System.Windows.Forms.ColumnHeader columnHeader21;
        private System.Windows.Forms.ColumnHeader columnHeader22;
        private System.Windows.Forms.ColumnHeader columnHeader23;
        private System.Windows.Forms.Label lblSupplierCode;
        private System.Windows.Forms.Label lblScheduleCode;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label lblschedleCode;
        private System.Windows.Forms.ErrorProvider errPurchaseEntryApproval;
        private System.Windows.Forms.Label lblNoRecordsFound;
        private System.Windows.Forms.PictureBox picLoader;
        public System.Windows.Forms.DataGridView grdPurchaseEntryApproval;
        private System.Windows.Forms.Button btnExport;
        public System.Windows.Forms.ToolStripButton tsbQue;
        public System.Windows.Forms.ToolStripSeparator tssEdit;
        public System.Windows.Forms.ToolStripButton tsbEdit;
        private System.Windows.Forms.Button btnTally;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clmCheck;
        private System.Windows.Forms.DataGridViewImageColumn clmUnapproved;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
    }
}