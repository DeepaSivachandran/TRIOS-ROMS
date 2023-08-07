namespace ROMS
{
    partial class PUR_PurchaseApprovalList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tsBrandList = new System.Windows.Forms.ToolStrip();
            this.tspHeader = new System.Windows.Forms.ToolStripLabel();
            this.pnlpurchaseapproval = new System.Windows.Forms.Panel();
            this.grpfilter = new System.Windows.Forms.GroupBox();
            this.cmbReason = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbConcern = new System.Windows.Forms.ComboBox();
            this.txtSupplier = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btnView = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dpPlanDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.DGV_SearchGrid = new System.Windows.Forms.DataGridView();
            this.clmdsno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmddate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmdpurchasenumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmdpono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmdsupplier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmdbillamt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmdtotalitem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmdstatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmdenterby = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmdapprovedby = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grdPurchaseApproval = new System.Windows.Forms.DataGridView();
            this.clmsno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmpurchaseno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmpono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmsupplier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmbill = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmtotalitem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmsts = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmenterby = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmapproved = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tsBrandList.SuspendLayout();
            this.pnlpurchaseapproval.SuspendLayout();
            this.grpfilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_SearchGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPurchaseApproval)).BeginInit();
            this.SuspendLayout();
            // 
            // tsBrandList
            // 
            this.tsBrandList.BackColor = System.Drawing.Color.White;
            this.tsBrandList.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsBrandList.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsBrandList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspHeader});
            this.tsBrandList.Location = new System.Drawing.Point(0, 0);
            this.tsBrandList.Name = "tsBrandList";
            this.tsBrandList.Size = new System.Drawing.Size(1354, 25);
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
            this.tspHeader.Size = new System.Drawing.Size(125, 22);
            this.tspHeader.Text = "Purchase Approval";
            // 
            // pnlpurchaseapproval
            // 
            this.pnlpurchaseapproval.BackColor = System.Drawing.Color.White;
            this.pnlpurchaseapproval.Controls.Add(this.grpfilter);
            this.pnlpurchaseapproval.Controls.Add(this.DGV_SearchGrid);
            this.pnlpurchaseapproval.Controls.Add(this.grdPurchaseApproval);
            this.pnlpurchaseapproval.Location = new System.Drawing.Point(0, 29);
            this.pnlpurchaseapproval.Name = "pnlpurchaseapproval";
            this.pnlpurchaseapproval.Size = new System.Drawing.Size(1354, 643);
            this.pnlpurchaseapproval.TabIndex = 958789;
            // 
            // grpfilter
            // 
            this.grpfilter.Controls.Add(this.cmbReason);
            this.grpfilter.Controls.Add(this.label4);
            this.grpfilter.Controls.Add(this.cmbStatus);
            this.grpfilter.Controls.Add(this.label3);
            this.grpfilter.Controls.Add(this.cmbConcern);
            this.grpfilter.Controls.Add(this.txtSupplier);
            this.grpfilter.Controls.Add(this.label12);
            this.grpfilter.Controls.Add(this.dateTimePicker1);
            this.grpfilter.Controls.Add(this.btnView);
            this.grpfilter.Controls.Add(this.label2);
            this.grpfilter.Controls.Add(this.dpPlanDate);
            this.grpfilter.Controls.Add(this.label1);
            this.grpfilter.Location = new System.Drawing.Point(3, 2);
            this.grpfilter.Name = "grpfilter";
            this.grpfilter.Size = new System.Drawing.Size(1345, 67);
            this.grpfilter.TabIndex = 958799;
            this.grpfilter.TabStop = false;
            this.grpfilter.Text = "Filter By";
            // 
            // cmbReason
            // 
            this.cmbReason.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReason.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbReason.FormattingEnabled = true;
            this.cmbReason.Items.AddRange(new object[] {
            "MRP Mismatched",
            "Shelf Life < 25 %",
            "Shelf Life < 50 %",
            "Excess Qty",
            "Extra Items"});
            this.cmbReason.Location = new System.Drawing.Point(1104, 24);
            this.cmbReason.Name = "cmbReason";
            this.cmbReason.Size = new System.Drawing.Size(140, 27);
            this.cmbReason.TabIndex = 1111176;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(1048, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 20);
            this.label4.TabIndex = 1111177;
            this.label4.Text = "Reason";
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "Approval Pending",
            "Rejected",
            "Approved"});
            this.cmbStatus.Location = new System.Drawing.Point(900, 24);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(146, 27);
            this.cmbStatus.TabIndex = 1111174;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(852, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 20);
            this.label3.TabIndex = 1111175;
            this.label3.Text = "Status";
            // 
            // cmbConcern
            // 
            this.cmbConcern.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbConcern.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbConcern.FormattingEnabled = true;
            this.cmbConcern.Location = new System.Drawing.Point(64, 24);
            this.cmbConcern.Name = "cmbConcern";
            this.cmbConcern.Size = new System.Drawing.Size(98, 27);
            this.cmbConcern.TabIndex = 1111172;
            // 
            // txtSupplier
            // 
            this.txtSupplier.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSupplier.Location = new System.Drawing.Point(570, 24);
            this.txtSupplier.MaxLength = 50;
            this.txtSupplier.Name = "txtSupplier";
            this.txtSupplier.Size = new System.Drawing.Size(280, 27);
            this.txtSupplier.TabIndex = 1111165;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(8, 27);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(54, 20);
            this.label12.TabIndex = 1111173;
            this.label12.Text = "Concern";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(366, 24);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(107, 27);
            this.dateTimePicker1.TabIndex = 1111143;
            // 
            // btnView
            // 
            this.btnView.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnView.Image = global::ROMS.Properties.Resources.view;
            this.btnView.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnView.Location = new System.Drawing.Point(1249, 21);
            this.btnView.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(74, 33);
            this.btnView.TabIndex = 1111141;
            this.btnView.Text = "View";
            this.btnView.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnView.UseVisualStyleBackColor = true;
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
            // dpPlanDate
            // 
            this.dpPlanDate.CustomFormat = "dd/MM/yyyy";
            this.dpPlanDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpPlanDate.Location = new System.Drawing.Point(251, 24);
            this.dpPlanDate.Name = "dpPlanDate";
            this.dpPlanDate.Size = new System.Drawing.Size(107, 27);
            this.dpPlanDate.TabIndex = 1111138;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(165, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 20);
            this.label1.TabIndex = 1111139;
            this.label1.Text = "Voucher Date";
            // 
            // DGV_SearchGrid
            // 
            this.DGV_SearchGrid.AllowUserToAddRows = false;
            this.DGV_SearchGrid.AllowUserToDeleteRows = false;
            this.DGV_SearchGrid.AllowUserToResizeRows = false;
            this.DGV_SearchGrid.BackgroundColor = System.Drawing.Color.White;
            this.DGV_SearchGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_SearchGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DGV_SearchGrid.ColumnHeadersHeight = 30;
            this.DGV_SearchGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGV_SearchGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmdsno,
            this.Column4,
            this.clmddate,
            this.clmdpurchasenumber,
            this.Column5,
            this.clmdpono,
            this.clmdsupplier,
            this.clmdbillamt,
            this.clmdtotalitem,
            this.clmdstatus,
            this.clmdenterby,
            this.clmdapprovedby,
            this.Column6});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV_SearchGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.DGV_SearchGrid.EnableHeadersVisualStyles = false;
            this.DGV_SearchGrid.GridColor = System.Drawing.Color.White;
            this.DGV_SearchGrid.Location = new System.Drawing.Point(3, 74);
            this.DGV_SearchGrid.Name = "DGV_SearchGrid";
            this.DGV_SearchGrid.RowHeadersVisible = false;
            this.DGV_SearchGrid.RowHeadersWidth = 70;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.DGV_SearchGrid.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.DGV_SearchGrid.RowTemplate.Height = 25;
            this.DGV_SearchGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DGV_SearchGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DGV_SearchGrid.ShowRowErrors = false;
            this.DGV_SearchGrid.Size = new System.Drawing.Size(1348, 56);
            this.DGV_SearchGrid.TabIndex = 958798;
            // 
            // clmdsno
            // 
            this.clmdsno.HeaderText = "S.No.";
            this.clmdsno.MinimumWidth = 6;
            this.clmdsno.Name = "clmdsno";
            this.clmdsno.Width = 75;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Concern";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // clmddate
            // 
            this.clmddate.HeaderText = "Voucher Date";
            this.clmddate.MinimumWidth = 6;
            this.clmddate.Name = "clmddate";
            // 
            // clmdpurchasenumber
            // 
            this.clmdpurchasenumber.HeaderText = "Voucher No.";
            this.clmdpurchasenumber.MinimumWidth = 6;
            this.clmdpurchasenumber.Name = "clmdpurchasenumber";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Invoice Date";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // clmdpono
            // 
            this.clmdpono.HeaderText = "Invoice No.";
            this.clmdpono.MinimumWidth = 6;
            this.clmdpono.Name = "clmdpono";
            // 
            // clmdsupplier
            // 
            this.clmdsupplier.HeaderText = "Invoice Amt";
            this.clmdsupplier.Name = "clmdsupplier";
            this.clmdsupplier.ReadOnly = true;
            // 
            // clmdbillamt
            // 
            this.clmdbillamt.HeaderText = "Purchase Type";
            this.clmdbillamt.Name = "clmdbillamt";
            this.clmdbillamt.ReadOnly = true;
            // 
            // clmdtotalitem
            // 
            this.clmdtotalitem.HeaderText = "Total Products";
            this.clmdtotalitem.Name = "clmdtotalitem";
            this.clmdtotalitem.ReadOnly = true;
            // 
            // clmdstatus
            // 
            this.clmdstatus.HeaderText = "Status";
            this.clmdstatus.Name = "clmdstatus";
            this.clmdstatus.ReadOnly = true;
            // 
            // clmdenterby
            // 
            this.clmdenterby.HeaderText = "Created By";
            this.clmdenterby.Name = "clmdenterby";
            this.clmdenterby.ReadOnly = true;
            this.clmdenterby.Width = 150;
            // 
            // clmdapprovedby
            // 
            this.clmdapprovedby.HeaderText = "Approved By";
            this.clmdapprovedby.Name = "clmdapprovedby";
            this.clmdapprovedby.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Remarks";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 200;
            // 
            // grdPurchaseApproval
            // 
            this.grdPurchaseApproval.AllowUserToAddRows = false;
            this.grdPurchaseApproval.AllowUserToDeleteRows = false;
            this.grdPurchaseApproval.AllowUserToResizeColumns = false;
            this.grdPurchaseApproval.AllowUserToResizeRows = false;
            this.grdPurchaseApproval.BackgroundColor = System.Drawing.Color.White;
            this.grdPurchaseApproval.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdPurchaseApproval.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.grdPurchaseApproval.ColumnHeadersHeight = 30;
            this.grdPurchaseApproval.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdPurchaseApproval.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmsno,
            this.Column1,
            this.clmdate,
            this.clmpurchaseno,
            this.Column2,
            this.clmpono,
            this.clmsupplier,
            this.clmbill,
            this.clmtotalitem,
            this.clmsts,
            this.clmenterby,
            this.clmapproved,
            this.Column3});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdPurchaseApproval.DefaultCellStyle = dataGridViewCellStyle5;
            this.grdPurchaseApproval.EnableHeadersVisualStyles = false;
            this.grdPurchaseApproval.GridColor = System.Drawing.Color.White;
            this.grdPurchaseApproval.Location = new System.Drawing.Point(3, 130);
            this.grdPurchaseApproval.Name = "grdPurchaseApproval";
            this.grdPurchaseApproval.ReadOnly = true;
            this.grdPurchaseApproval.RowHeadersVisible = false;
            this.grdPurchaseApproval.RowHeadersWidth = 100;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            this.grdPurchaseApproval.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.grdPurchaseApproval.RowTemplate.Height = 25;
            this.grdPurchaseApproval.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdPurchaseApproval.Size = new System.Drawing.Size(1348, 510);
            this.grdPurchaseApproval.TabIndex = 958797;
            this.grdPurchaseApproval.DoubleClick += new System.EventHandler(this.GrdPurchaseApproval_DoubleClick);
            // 
            // clmsno
            // 
            this.clmsno.HeaderText = "S.No.";
            this.clmsno.MinimumWidth = 6;
            this.clmsno.Name = "clmsno";
            this.clmsno.ReadOnly = true;
            this.clmsno.Width = 75;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Concern";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // clmdate
            // 
            this.clmdate.HeaderText = "Voucher Date";
            this.clmdate.MinimumWidth = 6;
            this.clmdate.Name = "clmdate";
            this.clmdate.ReadOnly = true;
            // 
            // clmpurchaseno
            // 
            this.clmpurchaseno.HeaderText = "Voucher No.";
            this.clmpurchaseno.MinimumWidth = 6;
            this.clmpurchaseno.Name = "clmpurchaseno";
            this.clmpurchaseno.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Invoice Date";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // clmpono
            // 
            this.clmpono.HeaderText = "Invoice No.";
            this.clmpono.MinimumWidth = 6;
            this.clmpono.Name = "clmpono";
            this.clmpono.ReadOnly = true;
            // 
            // clmsupplier
            // 
            this.clmsupplier.HeaderText = "Invoice Amt";
            this.clmsupplier.Name = "clmsupplier";
            this.clmsupplier.ReadOnly = true;
            // 
            // clmbill
            // 
            this.clmbill.HeaderText = "Purchase Type";
            this.clmbill.Name = "clmbill";
            this.clmbill.ReadOnly = true;
            // 
            // clmtotalitem
            // 
            this.clmtotalitem.HeaderText = "Total Products";
            this.clmtotalitem.Name = "clmtotalitem";
            this.clmtotalitem.ReadOnly = true;
            // 
            // clmsts
            // 
            this.clmsts.HeaderText = "Status";
            this.clmsts.Name = "clmsts";
            this.clmsts.ReadOnly = true;
            // 
            // clmenterby
            // 
            this.clmenterby.HeaderText = "Created By";
            this.clmenterby.Name = "clmenterby";
            this.clmenterby.ReadOnly = true;
            this.clmenterby.Width = 150;
            // 
            // clmapproved
            // 
            this.clmapproved.HeaderText = "Approved By";
            this.clmapproved.Name = "clmapproved";
            this.clmapproved.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Remarks";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 200;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Reason";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // PUR_PurchaseApprovalList
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
            this.Name = "PUR_PurchaseApprovalList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Purchase Approval";
            this.Load += new System.EventHandler(this.PUR_PurchaseApprovalList_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PUR_PurchaseApprovalList_KeyDown);
            this.tsBrandList.ResumeLayout(false);
            this.tsBrandList.PerformLayout();
            this.pnlpurchaseapproval.ResumeLayout(false);
            this.grpfilter.ResumeLayout(false);
            this.grpfilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_SearchGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPurchaseApproval)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsBrandList;
        private System.Windows.Forms.ToolStripLabel tspHeader;
        private System.Windows.Forms.Panel pnlpurchaseapproval;
        public System.Windows.Forms.DataGridView DGV_SearchGrid;
        public System.Windows.Forms.DataGridView grdPurchaseApproval;
        private System.Windows.Forms.GroupBox grpfilter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dpPlanDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox txtSupplier;
        private System.Windows.Forms.ComboBox cmbConcern;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbReason;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmsno;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmpurchaseno;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmpono;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmsupplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmbill;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmtotalitem;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmsts;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmenterby;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmapproved;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmdsno;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmddate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmdpurchasenumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmdpono;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmdsupplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmdbillamt;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmdtotalitem;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmdstatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmdenterby;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmdapprovedby;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
    }
}