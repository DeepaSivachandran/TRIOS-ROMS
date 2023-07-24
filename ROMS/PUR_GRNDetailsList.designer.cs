namespace ROMS
{
    partial class PUR_GRNDetailsList
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
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.tssEdit = new System.Windows.Forms.ToolStripSeparator();
            this.tsbEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbNew = new System.Windows.Forms.ToolStripButton();
            this.pnlpurchaseapproval = new System.Windows.Forms.Panel();
            this.lvSupplier = new System.Windows.Forms.ListView();
            this.grpfilter = new System.Windows.Forms.GroupBox();
            this.cmbConcern = new System.Windows.Forms.ComboBox();
            this.btnView = new System.Windows.Forms.Button();
            this.txtSupplier = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmOrdertype = new System.Windows.Forms.ComboBox();
            this.dpToDate = new System.Windows.Forms.DateTimePicker();
            this.dpFromDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.DGV_SearchGrid = new System.Windows.Forms.DataGridView();
            this.clmdsno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmdconcern = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmdgrndate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmdGrnno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmdsupplier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmdinvoicedate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmdinvoice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmdinvoiceamt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmdordertype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AnyPurchaseReturns = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Createby = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreatedOn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grdPurchaseApproval = new System.Windows.Forms.DataGridView();
            this.clmsno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmconcern = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmgrndate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmgrnno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmsupplier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clminvoicedate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clminvoiceno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clminvoice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmordertype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmAnyPurchaseReturns = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCreatedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCreatedOn = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.tspHeader,
            this.tsbDelete,
            this.tssEdit,
            this.tsbEdit,
            this.toolStripSeparator1,
            this.tsbNew});
            this.tsBrandList.Location = new System.Drawing.Point(0, 0);
            this.tsBrandList.Name = "tsBrandList";
            this.tsBrandList.Size = new System.Drawing.Size(1354, 27);
            this.tsBrandList.TabIndex = 35;
            this.tsBrandList.Text = "Brand";
            this.tsBrandList.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.TsBrandList_ItemClicked);
            // 
            // tspHeader
            // 
            this.tspHeader.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tspHeader.Image = global::ROMS.Properties.Resources.bread_crumb;
            this.tspHeader.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tspHeader.Margin = new System.Windows.Forms.Padding(15, 1, 0, 2);
            this.tspHeader.Name = "tspHeader";
            this.tspHeader.Size = new System.Drawing.Size(137, 24);
            this.tspHeader.Text = "Goods Received Note";
            // 
            // tsbDelete
            // 
            this.tsbDelete.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbDelete.Image = global::ROMS.Properties.Resources.Delete;
            this.tsbDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDelete.Margin = new System.Windows.Forms.Padding(0, 1, 15, 2);
            this.tsbDelete.Name = "tsbDelete";
            this.tsbDelete.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tsbDelete.Size = new System.Drawing.Size(63, 24);
            this.tsbDelete.Text = "Delete";
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
            this.tsbEdit.Image = global::ROMS.Properties.Resources.Edit;
            this.tsbEdit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEdit.Margin = new System.Windows.Forms.Padding(0, 1, 15, 2);
            this.tsbEdit.Name = "tsbEdit";
            this.tsbEdit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tsbEdit.Size = new System.Drawing.Size(50, 24);
            this.tsbEdit.Text = "&Edit";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator1.Margin = new System.Windows.Forms.Padding(0, 0, 15, 0);
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // tsbNew
            // 
            this.tsbNew.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbNew.Image = global::ROMS.Properties.Resources.New;
            this.tsbNew.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNew.Margin = new System.Windows.Forms.Padding(0, 1, 10, 2);
            this.tsbNew.Name = "tsbNew";
            this.tsbNew.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tsbNew.Size = new System.Drawing.Size(52, 24);
            this.tsbNew.Text = "&New";
            this.tsbNew.Click += new System.EventHandler(this.TsbNew_Click);
            // 
            // pnlpurchaseapproval
            // 
            this.pnlpurchaseapproval.BackColor = System.Drawing.Color.White;
            this.pnlpurchaseapproval.Controls.Add(this.lvSupplier);
            this.pnlpurchaseapproval.Controls.Add(this.grpfilter);
            this.pnlpurchaseapproval.Controls.Add(this.DGV_SearchGrid);
            this.pnlpurchaseapproval.Controls.Add(this.grdPurchaseApproval);
            this.pnlpurchaseapproval.Location = new System.Drawing.Point(0, 31);
            this.pnlpurchaseapproval.Name = "pnlpurchaseapproval";
            this.pnlpurchaseapproval.Size = new System.Drawing.Size(1354, 643);
            this.pnlpurchaseapproval.TabIndex = 958789;
            // 
            // lvSupplier
            // 
            this.lvSupplier.HideSelection = false;
            this.lvSupplier.Location = new System.Drawing.Point(640, 54);
            this.lvSupplier.Name = "lvSupplier";
            this.lvSupplier.Size = new System.Drawing.Size(318, 84);
            this.lvSupplier.TabIndex = 1111146;
            this.lvSupplier.UseCompatibleStateImageBehavior = false;
            this.lvSupplier.Visible = false;
            // 
            // grpfilter
            // 
            this.grpfilter.Controls.Add(this.cmbConcern);
            this.grpfilter.Controls.Add(this.btnView);
            this.grpfilter.Controls.Add(this.txtSupplier);
            this.grpfilter.Controls.Add(this.label10);
            this.grpfilter.Controls.Add(this.label4);
            this.grpfilter.Controls.Add(this.label2);
            this.grpfilter.Controls.Add(this.cmOrdertype);
            this.grpfilter.Controls.Add(this.dpToDate);
            this.grpfilter.Controls.Add(this.dpFromDate);
            this.grpfilter.Controls.Add(this.label1);
            this.grpfilter.Location = new System.Drawing.Point(3, 2);
            this.grpfilter.Name = "grpfilter";
            this.grpfilter.Size = new System.Drawing.Size(1329, 67);
            this.grpfilter.TabIndex = 958799;
            this.grpfilter.TabStop = false;
            this.grpfilter.Text = "Filter By";
            // 
            // cmbConcern
            // 
            this.cmbConcern.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbConcern.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbConcern.FormattingEnabled = true;
            this.cmbConcern.Items.AddRange(new object[] {
            "Direct",
            "Purchase Order"});
            this.cmbConcern.Location = new System.Drawing.Point(76, 23);
            this.cmbConcern.Name = "cmbConcern";
            this.cmbConcern.Size = new System.Drawing.Size(163, 27);
            this.cmbConcern.TabIndex = 1111165;
            // 
            // btnView
            // 
            this.btnView.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnView.Image = global::ROMS.Properties.Resources.view;
            this.btnView.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnView.Location = new System.Drawing.Point(1180, 20);
            this.btnView.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(74, 33);
            this.btnView.TabIndex = 1111141;
            this.btnView.Text = "View";
            this.btnView.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnView.UseVisualStyleBackColor = true;
            // 
            // txtSupplier
            // 
            this.txtSupplier.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSupplier.Location = new System.Drawing.Point(637, 23);
            this.txtSupplier.MaxLength = 50;
            this.txtSupplier.Name = "txtSupplier";
            this.txtSupplier.Size = new System.Drawing.Size(309, 27);
            this.txtSupplier.TabIndex = 1111147;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(26, 26);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 20);
            this.label10.TabIndex = 1111166;
            this.label10.Text = "Concern";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(952, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 20);
            this.label4.TabIndex = 1111148;
            this.label4.Text = "Order Type";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(544, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 20);
            this.label2.TabIndex = 1111140;
            this.label2.Text = "Supplier Name";
            // 
            // cmOrdertype
            // 
            this.cmOrdertype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmOrdertype.FormattingEnabled = true;
            this.cmOrdertype.Location = new System.Drawing.Point(1026, 23);
            this.cmOrdertype.Name = "cmOrdertype";
            this.cmOrdertype.Size = new System.Drawing.Size(150, 27);
            this.cmOrdertype.TabIndex = 1111147;
            // 
            // dpToDate
            // 
            this.dpToDate.CustomFormat = "dd/MM/yyyy";
            this.dpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpToDate.Location = new System.Drawing.Point(431, 23);
            this.dpToDate.Name = "dpToDate";
            this.dpToDate.Size = new System.Drawing.Size(107, 27);
            this.dpToDate.TabIndex = 1111142;
            // 
            // dpFromDate
            // 
            this.dpFromDate.CustomFormat = "dd/MM/yyyy";
            this.dpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpFromDate.Location = new System.Drawing.Point(320, 23);
            this.dpFromDate.Name = "dpFromDate";
            this.dpFromDate.Size = new System.Drawing.Size(107, 27);
            this.dpFromDate.TabIndex = 1111138;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(245, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 20);
            this.label1.TabIndex = 1111139;
            this.label1.Text = "GRN Date";
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
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(242)))), ((int)(((byte)(213)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_SearchGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DGV_SearchGrid.ColumnHeadersHeight = 30;
            this.DGV_SearchGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGV_SearchGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmdsno,
            this.clmdconcern,
            this.clmdgrndate,
            this.clmdGrnno,
            this.clmdsupplier,
            this.clmdinvoicedate,
            this.clmdinvoice,
            this.clmdinvoiceamt,
            this.clmdordertype,
            this.AnyPurchaseReturns,
            this.Createby,
            this.CreatedOn});
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
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
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
            // clmdconcern
            // 
            this.clmdconcern.HeaderText = "Concern";
            this.clmdconcern.Name = "clmdconcern";
            this.clmdconcern.ReadOnly = true;
            // 
            // clmdgrndate
            // 
            this.clmdgrndate.HeaderText = "GRN Date";
            this.clmdgrndate.MinimumWidth = 6;
            this.clmdgrndate.Name = "clmdgrndate";
            // 
            // clmdGrnno
            // 
            this.clmdGrnno.HeaderText = "GRN No.";
            this.clmdGrnno.MinimumWidth = 6;
            this.clmdGrnno.Name = "clmdGrnno";
            // 
            // clmdsupplier
            // 
            this.clmdsupplier.HeaderText = "Supplier Name";
            this.clmdsupplier.Name = "clmdsupplier";
            this.clmdsupplier.ReadOnly = true;
            this.clmdsupplier.Width = 200;
            // 
            // clmdinvoicedate
            // 
            this.clmdinvoicedate.HeaderText = "Invoice Date";
            this.clmdinvoicedate.Name = "clmdinvoicedate";
            this.clmdinvoicedate.ReadOnly = true;
            // 
            // clmdinvoice
            // 
            this.clmdinvoice.HeaderText = "Invoice No.";
            this.clmdinvoice.Name = "clmdinvoice";
            this.clmdinvoice.ReadOnly = true;
            // 
            // clmdinvoiceamt
            // 
            this.clmdinvoiceamt.HeaderText = "Invoice Amount";
            this.clmdinvoiceamt.Name = "clmdinvoiceamt";
            this.clmdinvoiceamt.ReadOnly = true;
            // 
            // clmdordertype
            // 
            this.clmdordertype.HeaderText = "Order Type";
            this.clmdordertype.Name = "clmdordertype";
            this.clmdordertype.ReadOnly = true;
            // 
            // AnyPurchaseReturns
            // 
            this.AnyPurchaseReturns.HeaderText = "Any Purchase Returns";
            this.AnyPurchaseReturns.Name = "AnyPurchaseReturns";
            this.AnyPurchaseReturns.Width = 150;
            // 
            // Createby
            // 
            this.Createby.HeaderText = "Created By";
            this.Createby.Name = "Createby";
            // 
            // CreatedOn
            // 
            this.CreatedOn.HeaderText = "Created On";
            this.CreatedOn.Name = "CreatedOn";
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
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(242)))), ((int)(((byte)(213)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdPurchaseApproval.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.grdPurchaseApproval.ColumnHeadersHeight = 30;
            this.grdPurchaseApproval.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdPurchaseApproval.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmsno,
            this.clmconcern,
            this.clmgrndate,
            this.clmgrnno,
            this.clmsupplier,
            this.clminvoicedate,
            this.clminvoiceno,
            this.clminvoice,
            this.clmordertype,
            this.clmAnyPurchaseReturns,
            this.clmCreatedBy,
            this.clmCreatedOn});
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
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            this.grdPurchaseApproval.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.grdPurchaseApproval.RowTemplate.Height = 25;
            this.grdPurchaseApproval.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdPurchaseApproval.Size = new System.Drawing.Size(1348, 510);
            this.grdPurchaseApproval.TabIndex = 958797;
            // 
            // clmsno
            // 
            this.clmsno.HeaderText = "S.No.";
            this.clmsno.MinimumWidth = 6;
            this.clmsno.Name = "clmsno";
            this.clmsno.ReadOnly = true;
            this.clmsno.Width = 75;
            // 
            // clmconcern
            // 
            this.clmconcern.HeaderText = "Concern";
            this.clmconcern.Name = "clmconcern";
            this.clmconcern.ReadOnly = true;
            // 
            // clmgrndate
            // 
            this.clmgrndate.HeaderText = "GRN Date";
            this.clmgrndate.MinimumWidth = 6;
            this.clmgrndate.Name = "clmgrndate";
            this.clmgrndate.ReadOnly = true;
            // 
            // clmgrnno
            // 
            this.clmgrnno.HeaderText = "GRN No.";
            this.clmgrnno.MinimumWidth = 6;
            this.clmgrnno.Name = "clmgrnno";
            this.clmgrnno.ReadOnly = true;
            // 
            // clmsupplier
            // 
            this.clmsupplier.HeaderText = "Supplier Name";
            this.clmsupplier.Name = "clmsupplier";
            this.clmsupplier.ReadOnly = true;
            this.clmsupplier.Width = 200;
            // 
            // clminvoicedate
            // 
            this.clminvoicedate.HeaderText = "Invoice Date";
            this.clminvoicedate.Name = "clminvoicedate";
            this.clminvoicedate.ReadOnly = true;
            // 
            // clminvoiceno
            // 
            this.clminvoiceno.HeaderText = "Invoice No.";
            this.clminvoiceno.Name = "clminvoiceno";
            this.clminvoiceno.ReadOnly = true;
            // 
            // clminvoice
            // 
            this.clminvoice.HeaderText = "Invoice Amount";
            this.clminvoice.Name = "clminvoice";
            this.clminvoice.ReadOnly = true;
            // 
            // clmordertype
            // 
            this.clmordertype.HeaderText = "Order Type";
            this.clmordertype.Name = "clmordertype";
            this.clmordertype.ReadOnly = true;
            // 
            // clmAnyPurchaseReturns
            // 
            this.clmAnyPurchaseReturns.HeaderText = "Any Purchase Returns";
            this.clmAnyPurchaseReturns.Name = "clmAnyPurchaseReturns";
            this.clmAnyPurchaseReturns.ReadOnly = true;
            this.clmAnyPurchaseReturns.Width = 150;
            // 
            // clmCreatedBy
            // 
            this.clmCreatedBy.HeaderText = "Created By";
            this.clmCreatedBy.Name = "clmCreatedBy";
            this.clmCreatedBy.ReadOnly = true;
            // 
            // clmCreatedOn
            // 
            this.clmCreatedOn.HeaderText = "Created On";
            this.clmCreatedOn.Name = "clmCreatedOn";
            this.clmCreatedOn.ReadOnly = true;
            // 
            // PUR_GRNDetailsList
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
            this.Name = "PUR_GRNDetailsList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Goods Receipt";
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
        private System.Windows.Forms.DateTimePicker dpFromDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.DateTimePicker dpToDate;
        private System.Windows.Forms.ListView lvSupplier;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.ComboBox cmOrdertype;
        private System.Windows.Forms.TextBox txtSupplier;
        public System.Windows.Forms.ToolStripButton tsbDelete;
        public System.Windows.Forms.ToolStripSeparator tssEdit;
        public System.Windows.Forms.ToolStripButton tsbEdit;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        public System.Windows.Forms.ToolStripButton tsbNew;
        private System.Windows.Forms.ComboBox cmbConcern;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmsno;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmconcern;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmgrndate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmgrnno;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmsupplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn clminvoicedate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clminvoiceno;
        private System.Windows.Forms.DataGridViewTextBoxColumn clminvoice;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmordertype;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmAnyPurchaseReturns;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCreatedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCreatedOn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmdsno;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmdconcern;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmdgrndate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmdGrnno;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmdsupplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmdinvoicedate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmdinvoice;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmdinvoiceamt;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmdordertype;
        private System.Windows.Forms.DataGridViewTextBoxColumn AnyPurchaseReturns;
        private System.Windows.Forms.DataGridViewTextBoxColumn Createby;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreatedOn;
    }
}