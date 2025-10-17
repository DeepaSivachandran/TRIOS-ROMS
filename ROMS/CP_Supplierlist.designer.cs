namespace ROMS
{
    partial class CP_Supplierlist
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
            this.tsSupplierList = new System.Windows.Forms.ToolStrip();
            this.tspHeader = new System.Windows.Forms.ToolStripLabel();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.tssEdit = new System.Windows.Forms.ToolStripSeparator();
            this.tsbEdit = new System.Windows.Forms.ToolStripButton();
            this.tssNew = new System.Windows.Forms.ToolStripSeparator();
            this.tsbNew = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbEnvelopPrint = new System.Windows.Forms.ToolStripButton();
            this.pnlsupplier = new System.Windows.Forms.Panel();
            this.LV_Supplier = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblNotDefined = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblSubGroup = new System.Windows.Forms.Label();
            this.lblInactiveCount = new System.Windows.Forms.Label();
            this.lblActiveCount = new System.Windows.Forms.Label();
            this.lblGroup = new System.Windows.Forms.Label();
            this.lblTotProducts = new System.Windows.Forms.Label();
            this.btnSummary = new System.Windows.Forms.Button();
            this.DGV_SearchGrid = new System.Windows.Forms.DataGridView();
            this.lblSupplierCode = new System.Windows.Forms.Label();
            this.lblNoRecordsFound = new System.Windows.Forms.Label();
            this.grdSupplierList = new System.Windows.Forms.DataGridView();
            this.clmCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.picLoader = new System.Windows.Forms.PictureBox();
            this.grbFilterBySupplier = new System.Windows.Forms.GroupBox();
            this.lblschedule = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.txtSupplier = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.grbSupplierDetails = new System.Windows.Forms.GroupBox();
            this.grdDaywiseProduct = new System.Windows.Forms.DataGridView();
            this.cmbDay = new System.Windows.Forms.ComboBox();
            this.lblDay = new System.Windows.Forms.Label();
            this.RPTViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.ep_Supplierlist = new System.Windows.Forms.ErrorProvider(this.components);
            this.tsSupplierList.SuspendLayout();
            this.pnlsupplier.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_SearchGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSupplierList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).BeginInit();
            this.grbFilterBySupplier.SuspendLayout();
            this.grbSupplierDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDaywiseProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ep_Supplierlist)).BeginInit();
            this.SuspendLayout();
            // 
            // tsSupplierList
            // 
            this.tsSupplierList.BackColor = System.Drawing.Color.White;
            this.tsSupplierList.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsSupplierList.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsSupplierList.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsSupplierList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspHeader,
            this.tsbDelete,
            this.tssEdit,
            this.tsbEdit,
            this.tssNew,
            this.tsbNew,
            this.toolStripSeparator1,
            this.tsbEnvelopPrint});
            this.tsSupplierList.Location = new System.Drawing.Point(0, 0);
            this.tsSupplierList.Name = "tsSupplierList";
            this.tsSupplierList.Size = new System.Drawing.Size(1354, 27);
            this.tsSupplierList.TabIndex = 35;
            this.tsSupplierList.Text = "Supplier List";
            // 
            // tspHeader
            // 
            this.tspHeader.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tspHeader.Image = global::ROMS.Properties.Resources.bread_crumb;
            this.tspHeader.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tspHeader.Margin = new System.Windows.Forms.Padding(15, 1, 0, 2);
            this.tspHeader.Name = "tspHeader";
            this.tspHeader.Size = new System.Drawing.Size(70, 24);
            this.tspHeader.Text = "Supplier";
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
            this.tsbDelete.Click += new System.EventHandler(this.tsbDelete_Click);
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
            this.tsbEdit.Click += new System.EventHandler(this.tsbEdit_Click);
            // 
            // tssNew
            // 
            this.tssNew.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tssNew.Margin = new System.Windows.Forms.Padding(0, 0, 15, 0);
            this.tssNew.Name = "tssNew";
            this.tssNew.Size = new System.Drawing.Size(6, 27);
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
            this.tsbNew.Click += new System.EventHandler(this.tsbNew_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator1.Margin = new System.Windows.Forms.Padding(0, 0, 15, 0);
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // tsbEnvelopPrint
            // 
            this.tsbEnvelopPrint.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbEnvelopPrint.Image = global::ROMS.Properties.Resources.print16;
            this.tsbEnvelopPrint.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbEnvelopPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEnvelopPrint.Margin = new System.Windows.Forms.Padding(0, 1, 10, 2);
            this.tsbEnvelopPrint.Name = "tsbEnvelopPrint";
            this.tsbEnvelopPrint.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tsbEnvelopPrint.Size = new System.Drawing.Size(106, 24);
            this.tsbEnvelopPrint.Text = "Envelope Print";
            this.tsbEnvelopPrint.Click += new System.EventHandler(this.TsbEnvelopPrint_Click);
            // 
            // pnlsupplier
            // 
            this.pnlsupplier.BackColor = System.Drawing.Color.White;
            this.pnlsupplier.Controls.Add(this.LV_Supplier);
            this.pnlsupplier.Controls.Add(this.groupBox1);
            this.pnlsupplier.Controls.Add(this.btnSummary);
            this.pnlsupplier.Controls.Add(this.DGV_SearchGrid);
            this.pnlsupplier.Controls.Add(this.lblSupplierCode);
            this.pnlsupplier.Controls.Add(this.lblNoRecordsFound);
            this.pnlsupplier.Controls.Add(this.grdSupplierList);
            this.pnlsupplier.Controls.Add(this.picLoader);
            this.pnlsupplier.Controls.Add(this.grbFilterBySupplier);
            this.pnlsupplier.Controls.Add(this.grbSupplierDetails);
            this.pnlsupplier.Controls.Add(this.RPTViewer);
            this.pnlsupplier.Location = new System.Drawing.Point(0, 31);
            this.pnlsupplier.Name = "pnlsupplier";
            this.pnlsupplier.Size = new System.Drawing.Size(1354, 641);
            this.pnlsupplier.TabIndex = 36;
            // 
            // LV_Supplier
            // 
            this.LV_Supplier.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader8,
            this.columnHeader9});
            this.LV_Supplier.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.LV_Supplier.HideSelection = false;
            this.LV_Supplier.Location = new System.Drawing.Point(12, 54);
            this.LV_Supplier.Name = "LV_Supplier";
            this.LV_Supplier.Size = new System.Drawing.Size(395, 93);
            this.LV_Supplier.TabIndex = 958803;
            this.LV_Supplier.UseCompatibleStateImageBehavior = false;
            this.LV_Supplier.View = System.Windows.Forms.View.Details;
            this.LV_Supplier.Visible = false;
            this.LV_Supplier.DoubleClick += new System.EventHandler(this.LV_Supplier_DoubleClick);
            this.LV_Supplier.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LV_Supplier_KeyDown);
            // 
            // columnHeader5
            // 
            this.columnHeader5.Width = 180;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Width = 120;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Width = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblNotDefined);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblTotal);
            this.groupBox1.Controls.Add(this.lblSubGroup);
            this.groupBox1.Controls.Add(this.lblInactiveCount);
            this.groupBox1.Controls.Add(this.lblActiveCount);
            this.groupBox1.Controls.Add(this.lblGroup);
            this.groupBox1.Controls.Add(this.lblTotProducts);
            this.groupBox1.Location = new System.Drawing.Point(856, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(403, 65);
            this.groupBox1.TabIndex = 1111172;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Supplier - Schedule Status";
            // 
            // lblNotDefined
            // 
            this.lblNotDefined.AutoSize = true;
            this.lblNotDefined.BackColor = System.Drawing.Color.SteelBlue;
            this.lblNotDefined.ForeColor = System.Drawing.Color.White;
            this.lblNotDefined.Location = new System.Drawing.Point(267, 27);
            this.lblNotDefined.Name = "lblNotDefined";
            this.lblNotDefined.Size = new System.Drawing.Size(44, 20);
            this.lblNotDefined.TabIndex = 27;
            this.lblNotDefined.Text = "00000";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(195, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 20);
            this.label2.TabIndex = 26;
            this.label2.Text = "Not Defined";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.BackColor = System.Drawing.Color.BlueViolet;
            this.lblTotal.ForeColor = System.Drawing.Color.White;
            this.lblTotal.Location = new System.Drawing.Point(353, 27);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(44, 20);
            this.lblTotal.TabIndex = 25;
            this.lblTotal.Text = "00000";
            // 
            // lblSubGroup
            // 
            this.lblSubGroup.AutoSize = true;
            this.lblSubGroup.Location = new System.Drawing.Point(314, 27);
            this.lblSubGroup.Name = "lblSubGroup";
            this.lblSubGroup.Size = new System.Drawing.Size(35, 20);
            this.lblSubGroup.TabIndex = 24;
            this.lblSubGroup.Text = "Total";
            // 
            // lblInactiveCount
            // 
            this.lblInactiveCount.AutoSize = true;
            this.lblInactiveCount.BackColor = System.Drawing.Color.Tomato;
            this.lblInactiveCount.ForeColor = System.Drawing.Color.White;
            this.lblInactiveCount.Location = new System.Drawing.Point(148, 27);
            this.lblInactiveCount.Name = "lblInactiveCount";
            this.lblInactiveCount.Size = new System.Drawing.Size(44, 20);
            this.lblInactiveCount.TabIndex = 21;
            this.lblInactiveCount.Text = "00000";
            // 
            // lblActiveCount
            // 
            this.lblActiveCount.AutoSize = true;
            this.lblActiveCount.BackColor = System.Drawing.Color.LimeGreen;
            this.lblActiveCount.ForeColor = System.Drawing.Color.White;
            this.lblActiveCount.Location = new System.Drawing.Point(48, 27);
            this.lblActiveCount.Name = "lblActiveCount";
            this.lblActiveCount.Size = new System.Drawing.Size(44, 20);
            this.lblActiveCount.TabIndex = 20;
            this.lblActiveCount.Text = "00000";
            // 
            // lblGroup
            // 
            this.lblGroup.AutoSize = true;
            this.lblGroup.Location = new System.Drawing.Point(95, 27);
            this.lblGroup.Name = "lblGroup";
            this.lblGroup.Size = new System.Drawing.Size(52, 20);
            this.lblGroup.TabIndex = 17;
            this.lblGroup.Text = "Inactive";
            // 
            // lblTotProducts
            // 
            this.lblTotProducts.AutoSize = true;
            this.lblTotProducts.Location = new System.Drawing.Point(4, 27);
            this.lblTotProducts.Name = "lblTotProducts";
            this.lblTotProducts.Size = new System.Drawing.Size(42, 20);
            this.lblTotProducts.TabIndex = 16;
            this.lblTotProducts.Text = "Active";
            // 
            // btnSummary
            // 
            this.btnSummary.Image = global::ROMS.Properties.Resources.clipboard;
            this.btnSummary.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSummary.Location = new System.Drawing.Point(1262, 27);
            this.btnSummary.Name = "btnSummary";
            this.btnSummary.Size = new System.Drawing.Size(83, 29);
            this.btnSummary.TabIndex = 958806;
            this.btnSummary.Text = "Summary";
            this.btnSummary.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSummary.UseVisualStyleBackColor = true;
            this.btnSummary.Click += new System.EventHandler(this.BtnSummary_Click);
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
            this.DGV_SearchGrid.RowHeadersWidth = 51;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.DGV_SearchGrid.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.DGV_SearchGrid.RowTemplate.Height = 25;
            this.DGV_SearchGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DGV_SearchGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DGV_SearchGrid.ShowRowErrors = false;
            this.DGV_SearchGrid.Size = new System.Drawing.Size(1348, 56);
            this.DGV_SearchGrid.TabIndex = 958805;
            this.DGV_SearchGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_SearchGrid_CellContentClick);
            this.DGV_SearchGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_SearchGrid_CellContentClick);
            this.DGV_SearchGrid.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.DGV_SearchGrid_CellPainting);
            this.DGV_SearchGrid.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DGV_SearchGrid_ColumnHeaderMouseClick);
            this.DGV_SearchGrid.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.DGV_SearchGrid_ColumnWidthChanged);
            this.DGV_SearchGrid.CurrentCellDirtyStateChanged += new System.EventHandler(this.DGV_SearchGrid_CurrentCellDirtyStateChanged);
            this.DGV_SearchGrid.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.DGV_SearchGrid_EditingControlShowing);
            this.DGV_SearchGrid.Scroll += new System.Windows.Forms.ScrollEventHandler(this.DGV_SearchGrid_Scroll);
            // 
            // lblSupplierCode
            // 
            this.lblSupplierCode.AutoSize = true;
            this.lblSupplierCode.Location = new System.Drawing.Point(480, 176);
            this.lblSupplierCode.Name = "lblSupplierCode";
            this.lblSupplierCode.Size = new System.Drawing.Size(16, 20);
            this.lblSupplierCode.TabIndex = 958804;
            this.lblSupplierCode.Text = "0";
            this.lblSupplierCode.Visible = false;
            // 
            // lblNoRecordsFound
            // 
            this.lblNoRecordsFound.AutoSize = true;
            this.lblNoRecordsFound.BackColor = System.Drawing.Color.White;
            this.lblNoRecordsFound.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoRecordsFound.Location = new System.Drawing.Point(624, 385);
            this.lblNoRecordsFound.Name = "lblNoRecordsFound";
            this.lblNoRecordsFound.Size = new System.Drawing.Size(106, 20);
            this.lblNoRecordsFound.TabIndex = 958798;
            this.lblNoRecordsFound.Text = "No Records Found";
            this.lblNoRecordsFound.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // grdSupplierList
            // 
            this.grdSupplierList.AllowUserToAddRows = false;
            this.grdSupplierList.AllowUserToDeleteRows = false;
            this.grdSupplierList.AllowUserToResizeColumns = false;
            this.grdSupplierList.AllowUserToResizeRows = false;
            this.grdSupplierList.BackgroundColor = System.Drawing.Color.White;
            this.grdSupplierList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.grdSupplierList.ColumnHeadersHeight = 30;
            this.grdSupplierList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdSupplierList.ColumnHeadersVisible = false;
            this.grdSupplierList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmCheck});
            this.grdSupplierList.EnableHeadersVisualStyles = false;
            this.grdSupplierList.GridColor = System.Drawing.Color.White;
            this.grdSupplierList.Location = new System.Drawing.Point(3, 130);
            this.grdSupplierList.Name = "grdSupplierList";
            this.grdSupplierList.RowHeadersVisible = false;
            this.grdSupplierList.RowHeadersWidth = 51;
            this.grdSupplierList.RowTemplate.Height = 25;
            this.grdSupplierList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdSupplierList.Size = new System.Drawing.Size(1348, 501);
            this.grdSupplierList.TabIndex = 958797;
            this.grdSupplierList.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.GrdSupplierList_CellBeginEdit);
            this.grdSupplierList.CurrentCellDirtyStateChanged += new System.EventHandler(this.GrdSupplierList_CurrentCellDirtyStateChanged);
            this.grdSupplierList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.GrdSupplierList_DataBindingComplete);
            this.grdSupplierList.Scroll += new System.Windows.Forms.ScrollEventHandler(this.GrdSupplierList_Scroll);
            this.grdSupplierList.DoubleClick += new System.EventHandler(this.GrdSupplierList_DoubleClick);
            this.grdSupplierList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GrdSupplierList_KeyDown);
            // 
            // clmCheck
            // 
            this.clmCheck.HeaderText = "";
            this.clmCheck.MinimumWidth = 6;
            this.clmCheck.Name = "clmCheck";
            this.clmCheck.ReadOnly = true;
            this.clmCheck.Width = 50;
            // 
            // picLoader
            // 
            this.picLoader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picLoader.ErrorImage = null;
            this.picLoader.Image = global::ROMS.Properties.Resources.Iphone_spinner_2;
            this.picLoader.InitialImage = null;
            this.picLoader.Location = new System.Drawing.Point(3, 76);
            this.picLoader.Name = "picLoader";
            this.picLoader.Size = new System.Drawing.Size(1347, 566);
            this.picLoader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picLoader.TabIndex = 958799;
            this.picLoader.TabStop = false;
            this.picLoader.Visible = false;
            // 
            // grbFilterBySupplier
            // 
            this.grbFilterBySupplier.Controls.Add(this.lblschedule);
            this.grbFilterBySupplier.Controls.Add(this.cmbStatus);
            this.grbFilterBySupplier.Controls.Add(this.txtSupplier);
            this.grbFilterBySupplier.Controls.Add(this.lblStatus);
            this.grbFilterBySupplier.Controls.Add(this.btnExport);
            this.grbFilterBySupplier.Controls.Add(this.btnView);
            this.grbFilterBySupplier.Controls.Add(this.btnPrint);
            this.grbFilterBySupplier.Location = new System.Drawing.Point(3, 1);
            this.grbFilterBySupplier.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbFilterBySupplier.Name = "grbFilterBySupplier";
            this.grbFilterBySupplier.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbFilterBySupplier.Size = new System.Drawing.Size(847, 67);
            this.grbFilterBySupplier.TabIndex = 958801;
            this.grbFilterBySupplier.TabStop = false;
            this.grbFilterBySupplier.Text = "Filter By Supplier";
            // 
            // lblschedule
            // 
            this.lblschedule.AutoSize = true;
            this.lblschedule.Location = new System.Drawing.Point(419, 70);
            this.lblschedule.Name = "lblschedule";
            this.lblschedule.Size = new System.Drawing.Size(16, 20);
            this.lblschedule.TabIndex = 958805;
            this.lblschedule.Text = "0";
            this.lblschedule.Visible = false;
            // 
            // cmbStatus
            // 
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(461, 26);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(131, 27);
            this.cmbStatus.TabIndex = 2;
            this.cmbStatus.SelectedIndexChanged += new System.EventHandler(this.CmbStatus_SelectedIndexChanged);
            this.cmbStatus.Enter += new System.EventHandler(this.CmbStatus_Enter);
            this.cmbStatus.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbStatus_KeyDown);
            this.cmbStatus.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbStatus_KeyPress);
            this.cmbStatus.Leave += new System.EventHandler(this.CmbStatus_Leave);
            // 
            // txtSupplier
            // 
            this.txtSupplier.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtSupplier.Location = new System.Drawing.Point(9, 26);
            this.txtSupplier.MaxLength = 100;
            this.txtSupplier.Name = "txtSupplier";
            this.txtSupplier.Size = new System.Drawing.Size(395, 27);
            this.txtSupplier.TabIndex = 1;
            this.txtSupplier.TextChanged += new System.EventHandler(this.TxtSupplier_TextChanged);
            this.txtSupplier.Enter += new System.EventHandler(this.TxtSupplier_Enter);
            this.txtSupplier.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtSupplier_KeyDown);
            this.txtSupplier.Leave += new System.EventHandler(this.TxtSupplier_Leave);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(410, 29);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(45, 20);
            this.lblStatus.TabIndex = 958804;
            this.lblStatus.Text = "Status";
            // 
            // btnExport
            // 
            this.btnExport.Image = global::ROMS.Properties.Resources.excel;
            this.btnExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExport.Location = new System.Drawing.Point(683, 25);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(79, 29);
            this.btnExport.TabIndex = 4;
            this.btnExport.Text = "Export";
            this.btnExport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.BtnExport_Click);
            this.btnExport.Enter += new System.EventHandler(this.BtnExport_Enter);
            this.btnExport.Leave += new System.EventHandler(this.BtnExport_Leave);
            // 
            // btnView
            // 
            this.btnView.Image = global::ROMS.Properties.Resources.view;
            this.btnView.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnView.Location = new System.Drawing.Point(600, 25);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(75, 29);
            this.btnView.TabIndex = 3;
            this.btnView.Text = "View";
            this.btnView.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.BtnView_Click);
            this.btnView.Enter += new System.EventHandler(this.BtnView_Enter);
            this.btnView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BtnView_KeyDown);
            this.btnView.Leave += new System.EventHandler(this.BtnView_Leave);
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Image = global::ROMS.Properties.Resources.print;
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(768, 25);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(73, 29);
            this.btnPrint.TabIndex = 5;
            this.btnPrint.Text = "Print";
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.BtnPrint_Click);
            this.btnPrint.Enter += new System.EventHandler(this.BtnPrint_Enter);
            this.btnPrint.Leave += new System.EventHandler(this.BtnPrint_Leave);
            // 
            // grbSupplierDetails
            // 
            this.grbSupplierDetails.Controls.Add(this.grdDaywiseProduct);
            this.grbSupplierDetails.Controls.Add(this.cmbDay);
            this.grbSupplierDetails.Controls.Add(this.lblDay);
            this.grbSupplierDetails.Location = new System.Drawing.Point(782, 1);
            this.grbSupplierDetails.Name = "grbSupplierDetails";
            this.grbSupplierDetails.Size = new System.Drawing.Size(569, 90);
            this.grbSupplierDetails.TabIndex = 5;
            this.grbSupplierDetails.TabStop = false;
            this.grbSupplierDetails.Text = "Filter by Day";
            this.grbSupplierDetails.Visible = false;
            // 
            // grdDaywiseProduct
            // 
            this.grdDaywiseProduct.AllowUserToAddRows = false;
            this.grdDaywiseProduct.AllowUserToDeleteRows = false;
            this.grdDaywiseProduct.AllowUserToResizeRows = false;
            this.grdDaywiseProduct.BackgroundColor = System.Drawing.Color.White;
            this.grdDaywiseProduct.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(242)))), ((int)(((byte)(213)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdDaywiseProduct.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.grdDaywiseProduct.ColumnHeadersHeight = 25;
            this.grdDaywiseProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdDaywiseProduct.DefaultCellStyle = dataGridViewCellStyle5;
            this.grdDaywiseProduct.EnableHeadersVisualStyles = false;
            this.grdDaywiseProduct.GridColor = System.Drawing.Color.White;
            this.grdDaywiseProduct.Location = new System.Drawing.Point(168, 12);
            this.grdDaywiseProduct.Name = "grdDaywiseProduct";
            this.grdDaywiseProduct.ReadOnly = true;
            this.grdDaywiseProduct.RowHeadersVisible = false;
            this.grdDaywiseProduct.RowHeadersWidth = 51;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.grdDaywiseProduct.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.grdDaywiseProduct.RowTemplate.Height = 25;
            this.grdDaywiseProduct.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.grdDaywiseProduct.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.grdDaywiseProduct.ShowRowErrors = false;
            this.grdDaywiseProduct.Size = new System.Drawing.Size(398, 74);
            this.grdDaywiseProduct.TabIndex = 958802;
            this.grdDaywiseProduct.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.GrdDaywiseProduct_DataBindingComplete);
            // 
            // cmbDay
            // 
            this.cmbDay.FormattingEnabled = true;
            this.cmbDay.Location = new System.Drawing.Point(37, 26);
            this.cmbDay.Name = "cmbDay";
            this.cmbDay.Size = new System.Drawing.Size(127, 27);
            this.cmbDay.TabIndex = 5;
            this.cmbDay.SelectedIndexChanged += new System.EventHandler(this.CmbDay_SelectedIndexChanged);
            this.cmbDay.Enter += new System.EventHandler(this.CmbDay_Enter);
            this.cmbDay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbDay_KeyDown);
            this.cmbDay.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbDay_KeyPress);
            this.cmbDay.Leave += new System.EventHandler(this.CmbDay_Leave);
            // 
            // lblDay
            // 
            this.lblDay.AutoSize = true;
            this.lblDay.Location = new System.Drawing.Point(4, 29);
            this.lblDay.Name = "lblDay";
            this.lblDay.Size = new System.Drawing.Size(29, 20);
            this.lblDay.TabIndex = 6;
            this.lblDay.Text = "Day";
            // 
            // RPTViewer
            // 
            this.RPTViewer.ActiveViewIndex = -1;
            this.RPTViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RPTViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.RPTViewer.Location = new System.Drawing.Point(3, 75);
            this.RPTViewer.Name = "RPTViewer";
            this.RPTViewer.ReuseParameterValuesOnRefresh = true;
            this.RPTViewer.Size = new System.Drawing.Size(1348, 556);
            this.RPTViewer.TabIndex = 1111228;
            this.RPTViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.RPTViewer.Visible = false;
            // 
            // ep_Supplierlist
            // 
            this.ep_Supplierlist.ContainerControl = this;
            // 
            // CP_Supplierlist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(1354, 675);
            this.Controls.Add(this.pnlsupplier);
            this.Controls.Add(this.tsSupplierList);
            this.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "CP_Supplierlist";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Supplier";
            this.Load += new System.EventHandler(this.CP_Supplierlist_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CP_Supplierlist_KeyDown);
            this.tsSupplierList.ResumeLayout(false);
            this.tsSupplierList.PerformLayout();
            this.pnlsupplier.ResumeLayout(false);
            this.pnlsupplier.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_SearchGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSupplierList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).EndInit();
            this.grbFilterBySupplier.ResumeLayout(false);
            this.grbFilterBySupplier.PerformLayout();
            this.grbSupplierDetails.ResumeLayout(false);
            this.grbSupplierDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDaywiseProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ep_Supplierlist)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsSupplierList;
        private System.Windows.Forms.ToolStripLabel tspHeader;
        public System.Windows.Forms.ToolStripButton tsbDelete;
        public System.Windows.Forms.ToolStripSeparator tssEdit;
        public System.Windows.Forms.ToolStripButton tsbEdit;
        public System.Windows.Forms.ToolStripSeparator tssNew;
        public System.Windows.Forms.ToolStripButton tsbNew;
        private System.Windows.Forms.Panel pnlsupplier;
        private System.Windows.Forms.Label lblNoRecordsFound;
        private System.Windows.Forms.PictureBox picLoader;
        private System.Windows.Forms.GroupBox grbFilterBySupplier;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.TextBox txtSupplier;
        private System.Windows.Forms.GroupBox grbSupplierDetails;
        private System.Windows.Forms.ComboBox cmbDay;
        private System.Windows.Forms.Label lblDay;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label lblStatus;
        public System.Windows.Forms.DataGridView grdDaywiseProduct;
        public System.Windows.Forms.ListView LV_Supplier;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.Label lblSupplierCode;
        public System.Windows.Forms.DataGridView grdSupplierList;
        public System.Windows.Forms.DataGridView DGV_SearchGrid;
        private System.Windows.Forms.ErrorProvider ep_Supplierlist;
        private System.Windows.Forms.Label lblschedule;
        private System.Windows.Forms.Button btnSummary;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblSubGroup;
        private System.Windows.Forms.Label lblInactiveCount;
        private System.Windows.Forms.Label lblActiveCount;
        private System.Windows.Forms.Label lblGroup;
        private System.Windows.Forms.Label lblTotProducts;
        private System.Windows.Forms.Button btnPrint;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer RPTViewer;
        private System.Windows.Forms.Label lblNotDefined;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clmCheck;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        public System.Windows.Forms.ToolStripButton tsbEnvelopPrint;
    }
}