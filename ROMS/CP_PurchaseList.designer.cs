namespace ROMS
{
    partial class CP_PurchaseList
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
            this.tsPurchaseList = new System.Windows.Forms.ToolStrip();
            this.tspHeader = new System.Windows.Forms.ToolStripLabel();
            this.tsTotalQueue = new System.Windows.Forms.ToolStripButton();
            this.tsbQueue = new System.Windows.Forms.ToolStripButton();
            this.tssDelete = new System.Windows.Forms.ToolStripSeparator();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.tssEdit = new System.Windows.Forms.ToolStripSeparator();
            this.tsbEdit = new System.Windows.Forms.ToolStripButton();
            this.tssNew = new System.Windows.Forms.ToolStripSeparator();
            this.tsbNew = new System.Windows.Forms.ToolStripButton();
            this.grdPurchaseEntryList = new System.Windows.Forms.DataGridView();
            this.clmCheck = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmEdit = new System.Windows.Forms.DataGridViewImageColumn();
            this.lblNoRecordsFound = new System.Windows.Forms.Label();
            this.DGV_SearchGrid = new System.Windows.Forms.DataGridView();
            this.pnlpurchase = new System.Windows.Forms.Panel();
            this.LV_Supplier = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grpFilterby = new System.Windows.Forms.GroupBox();
            this.lblQueueCount = new System.Windows.Forms.Label();
            this.btnTally = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbstatus = new System.Windows.Forms.ComboBox();
            this.cmbConcern = new System.Windows.Forms.ComboBox();
            this.txtSupplier = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbOrdertype = new System.Windows.Forms.ComboBox();
            this.dpToDate = new System.Windows.Forms.DateTimePicker();
            this.dpFromDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnView = new System.Windows.Forms.Button();
            this.picLoader = new System.Windows.Forms.PictureBox();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.lblSupplierCode = new System.Windows.Forms.Label();
            this.lblschedleCode = new System.Windows.Forms.Label();
            this.errPurchaseList = new System.Windows.Forms.ErrorProvider(this.components);
            this.tsPurchaseList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPurchaseEntryList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_SearchGrid)).BeginInit();
            this.pnlpurchase.SuspendLayout();
            this.grpFilterby.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errPurchaseList)).BeginInit();
            this.SuspendLayout();
            // 
            // tsPurchaseList
            // 
            this.tsPurchaseList.BackColor = System.Drawing.Color.White;
            this.tsPurchaseList.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsPurchaseList.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsPurchaseList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspHeader,
            this.tsTotalQueue,
            this.tsbQueue,
            this.tssDelete,
            this.tsbDelete,
            this.tssEdit,
            this.tsbEdit,
            this.tssNew,
            this.tsbNew});
            this.tsPurchaseList.Location = new System.Drawing.Point(0, 0);
            this.tsPurchaseList.Name = "tsPurchaseList";
            this.tsPurchaseList.Size = new System.Drawing.Size(1354, 27);
            this.tsPurchaseList.TabIndex = 35;
            this.tsPurchaseList.Text = "Brand";
            this.tsPurchaseList.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tsPurchaseList_ItemClicked);
            // 
            // tspHeader
            // 
            this.tspHeader.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tspHeader.Image = global::ROMS.Properties.Resources.bread_crumb;
            this.tspHeader.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tspHeader.Margin = new System.Windows.Forms.Padding(15, 1, 0, 2);
            this.tspHeader.Name = "tspHeader";
            this.tspHeader.Size = new System.Drawing.Size(107, 24);
            this.tspHeader.Text = "Purchase Entry";
            // 
            // tsTotalQueue
            // 
            this.tsTotalQueue.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsTotalQueue.Enabled = false;
            this.tsTotalQueue.ForeColor = System.Drawing.Color.DarkGreen;
            this.tsTotalQueue.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsTotalQueue.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsTotalQueue.Margin = new System.Windows.Forms.Padding(0, 1, 5, 2);
            this.tsTotalQueue.Name = "tsTotalQueue";
            this.tsTotalQueue.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tsTotalQueue.Size = new System.Drawing.Size(23, 24);
            this.tsTotalQueue.Text = "0";
            // 
            // tsbQueue
            // 
            this.tsbQueue.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbQueue.Image = global::ROMS.Properties.Resources.queue;
            this.tsbQueue.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbQueue.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbQueue.Margin = new System.Windows.Forms.Padding(0, 1, 5, 2);
            this.tsbQueue.Name = "tsbQueue";
            this.tsbQueue.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tsbQueue.Size = new System.Drawing.Size(63, 24);
            this.tsbQueue.Text = "Queue";
            this.tsbQueue.Click += new System.EventHandler(this.TsbQue_Click);
            // 
            // tssDelete
            // 
            this.tssDelete.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tssDelete.Margin = new System.Windows.Forms.Padding(0, 0, 15, 0);
            this.tssDelete.Name = "tssDelete";
            this.tssDelete.Size = new System.Drawing.Size(6, 27);
            // 
            // tsbDelete
            // 
            this.tsbDelete.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbDelete.Image = global::ROMS.Properties.Resources.Delete;
            this.tsbDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDelete.Margin = new System.Windows.Forms.Padding(0, 1, 5, 2);
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
            this.tsbEdit.Margin = new System.Windows.Forms.Padding(0, 1, 5, 2);
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
            this.tsbNew.Margin = new System.Windows.Forms.Padding(0, 1, 5, 2);
            this.tsbNew.Name = "tsbNew";
            this.tsbNew.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tsbNew.Size = new System.Drawing.Size(52, 24);
            this.tsbNew.Text = "&New";
            this.tsbNew.Click += new System.EventHandler(this.tsbNew_Click);
            // 
            // grdPurchaseEntryList
            // 
            this.grdPurchaseEntryList.AllowUserToAddRows = false;
            this.grdPurchaseEntryList.AllowUserToDeleteRows = false;
            this.grdPurchaseEntryList.AllowUserToResizeColumns = false;
            this.grdPurchaseEntryList.AllowUserToResizeRows = false;
            this.grdPurchaseEntryList.BackgroundColor = System.Drawing.Color.White;
            this.grdPurchaseEntryList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdPurchaseEntryList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdPurchaseEntryList.ColumnHeadersHeight = 30;
            this.grdPurchaseEntryList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdPurchaseEntryList.ColumnHeadersVisible = false;
            this.grdPurchaseEntryList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmCheck,
            this.clmEdit});
            this.grdPurchaseEntryList.EnableHeadersVisualStyles = false;
            this.grdPurchaseEntryList.GridColor = System.Drawing.Color.White;
            this.grdPurchaseEntryList.Location = new System.Drawing.Point(3, 130);
            this.grdPurchaseEntryList.Name = "grdPurchaseEntryList";
            this.grdPurchaseEntryList.ReadOnly = true;
            this.grdPurchaseEntryList.RowHeadersVisible = false;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            this.grdPurchaseEntryList.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.grdPurchaseEntryList.RowTemplate.Height = 25;
            this.grdPurchaseEntryList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdPurchaseEntryList.Size = new System.Drawing.Size(1348, 510);
            this.grdPurchaseEntryList.TabIndex = 958797;
            this.grdPurchaseEntryList.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.GrdPurchaseEntryList_CellFormatting);
            this.grdPurchaseEntryList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.GrdPurchaseEntryList_DataBindingComplete);
            this.grdPurchaseEntryList.Scroll += new System.Windows.Forms.ScrollEventHandler(this.GrdSupplierList_Scroll);
            this.grdPurchaseEntryList.SelectionChanged += new System.EventHandler(this.GrdPurchaseEntryList_SelectionChanged);
            this.grdPurchaseEntryList.DoubleClick += new System.EventHandler(this.GrdPurchaseEntryList_DoubleClick);
            this.grdPurchaseEntryList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GrdPurchaseEntryList_KeyDown);
            // 
            // clmCheck
            // 
            this.clmCheck.HeaderText = "";
            this.clmCheck.Name = "clmCheck";
            this.clmCheck.ReadOnly = true;
            // 
            // clmEdit
            // 
            this.clmEdit.HeaderText = "GSTR Status";
            this.clmEdit.Image = global::ROMS.Properties.Resources.pending;
            this.clmEdit.Name = "clmEdit";
            this.clmEdit.ReadOnly = true;
            this.clmEdit.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmEdit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.clmEdit.Visible = false;
            // 
            // lblNoRecordsFound
            // 
            this.lblNoRecordsFound.AutoSize = true;
            this.lblNoRecordsFound.BackColor = System.Drawing.Color.White;
            this.lblNoRecordsFound.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoRecordsFound.Location = new System.Drawing.Point(624, 375);
            this.lblNoRecordsFound.Name = "lblNoRecordsFound";
            this.lblNoRecordsFound.Size = new System.Drawing.Size(106, 20);
            this.lblNoRecordsFound.TabIndex = 958798;
            this.lblNoRecordsFound.Text = "No Records Found";
            this.lblNoRecordsFound.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // DGV_SearchGrid
            // 
            this.DGV_SearchGrid.AllowUserToAddRows = false;
            this.DGV_SearchGrid.AllowUserToDeleteRows = false;
            this.DGV_SearchGrid.AllowUserToResizeRows = false;
            this.DGV_SearchGrid.BackgroundColor = System.Drawing.Color.White;
            this.DGV_SearchGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_SearchGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DGV_SearchGrid.ColumnHeadersHeight = 30;
            this.DGV_SearchGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV_SearchGrid.DefaultCellStyle = dataGridViewCellStyle4;
            this.DGV_SearchGrid.EnableHeadersVisualStyles = false;
            this.DGV_SearchGrid.GridColor = System.Drawing.Color.White;
            this.DGV_SearchGrid.Location = new System.Drawing.Point(3, 74);
            this.DGV_SearchGrid.Name = "DGV_SearchGrid";
            this.DGV_SearchGrid.RowHeadersVisible = false;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            this.DGV_SearchGrid.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.DGV_SearchGrid.RowTemplate.Height = 25;
            this.DGV_SearchGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DGV_SearchGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DGV_SearchGrid.ShowRowErrors = false;
            this.DGV_SearchGrid.Size = new System.Drawing.Size(1348, 56);
            this.DGV_SearchGrid.TabIndex = 958800;
            this.DGV_SearchGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_SearchGrid_CellEndEdit);
            this.DGV_SearchGrid.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DGV_SearchGrid_CellFormatting);
            this.DGV_SearchGrid.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.DGV_SearchGrid_CellPainting);
            this.DGV_SearchGrid.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DGV_SearchGrid_ColumnHeaderMouseClick);
            this.DGV_SearchGrid.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.DGV_SearchGrid_ColumnWidthChanged);
            this.DGV_SearchGrid.CurrentCellDirtyStateChanged += new System.EventHandler(this.DGV_SearchGrid_CurrentCellDirtyStateChanged);
            this.DGV_SearchGrid.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.DGV_SearchGrid_EditingControlShowing);
            this.DGV_SearchGrid.Scroll += new System.Windows.Forms.ScrollEventHandler(this.DGV_SearchGrid_Scroll);
            // 
            // pnlpurchase
            // 
            this.pnlpurchase.BackColor = System.Drawing.Color.White;
            this.pnlpurchase.Controls.Add(this.LV_Supplier);
            this.pnlpurchase.Controls.Add(this.grpFilterby);
            this.pnlpurchase.Controls.Add(this.DGV_SearchGrid);
            this.pnlpurchase.Controls.Add(this.lblNoRecordsFound);
            this.pnlpurchase.Controls.Add(this.grdPurchaseEntryList);
            this.pnlpurchase.Controls.Add(this.picLoader);
            this.pnlpurchase.Location = new System.Drawing.Point(0, 31);
            this.pnlpurchase.Name = "pnlpurchase";
            this.pnlpurchase.Size = new System.Drawing.Size(1354, 641);
            this.pnlpurchase.TabIndex = 36;
            // 
            // LV_Supplier
            // 
            this.LV_Supplier.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.LV_Supplier.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.LV_Supplier.HideSelection = false;
            this.LV_Supplier.Location = new System.Drawing.Point(561, 52);
            this.LV_Supplier.Name = "LV_Supplier";
            this.LV_Supplier.Size = new System.Drawing.Size(487, 93);
            this.LV_Supplier.TabIndex = 1111195;
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
            // grpFilterby
            // 
            this.grpFilterby.Controls.Add(this.lblQueueCount);
            this.grpFilterby.Controls.Add(this.btnTally);
            this.grpFilterby.Controls.Add(this.btnExport);
            this.grpFilterby.Controls.Add(this.label5);
            this.grpFilterby.Controls.Add(this.cmbstatus);
            this.grpFilterby.Controls.Add(this.cmbConcern);
            this.grpFilterby.Controls.Add(this.txtSupplier);
            this.grpFilterby.Controls.Add(this.label10);
            this.grpFilterby.Controls.Add(this.label4);
            this.grpFilterby.Controls.Add(this.label2);
            this.grpFilterby.Controls.Add(this.cmbOrdertype);
            this.grpFilterby.Controls.Add(this.dpToDate);
            this.grpFilterby.Controls.Add(this.dpFromDate);
            this.grpFilterby.Controls.Add(this.label1);
            this.grpFilterby.Controls.Add(this.label3);
            this.grpFilterby.Controls.Add(this.btnView);
            this.grpFilterby.Location = new System.Drawing.Point(3, 2);
            this.grpFilterby.Name = "grpFilterby";
            this.grpFilterby.Size = new System.Drawing.Size(1347, 67);
            this.grpFilterby.TabIndex = 958802;
            this.grpFilterby.TabStop = false;
            this.grpFilterby.Text = "Filter By";
            // 
            // lblQueueCount
            // 
            this.lblQueueCount.AutoSize = true;
            this.lblQueueCount.BackColor = System.Drawing.SystemColors.Window;
            this.lblQueueCount.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQueueCount.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblQueueCount.Location = new System.Drawing.Point(1271, 0);
            this.lblQueueCount.Name = "lblQueueCount";
            this.lblQueueCount.Size = new System.Drawing.Size(17, 20);
            this.lblQueueCount.TabIndex = 1111198;
            this.lblQueueCount.Text = "0";
            this.lblQueueCount.Visible = false;
            // 
            // btnTally
            // 
            this.btnTally.Location = new System.Drawing.Point(1245, 20);
            this.btnTally.Name = "btnTally";
            this.btnTally.Size = new System.Drawing.Size(93, 33);
            this.btnTally.TabIndex = 50;
            this.btnTally.Text = "Export to Tally";
            this.btnTally.UseVisualStyleBackColor = true;
            this.btnTally.Visible = false;
            this.btnTally.Click += new System.EventHandler(this.BtnTally_Click);
            this.btnTally.Enter += new System.EventHandler(this.BtnTally_Enter);
            this.btnTally.Leave += new System.EventHandler(this.BtnTally_Leave);
            // 
            // btnExport
            // 
            this.btnExport.Image = global::ROMS.Properties.Resources.excel;
            this.btnExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExport.Location = new System.Drawing.Point(1210, 20);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(32, 33);
            this.btnExport.TabIndex = 44;
            this.btnExport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.BtnExport_Click);
            this.btnExport.Enter += new System.EventHandler(this.BtnExport_Enter);
            this.btnExport.Leave += new System.EventHandler(this.BtnExport_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(1006, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 20);
            this.label5.TabIndex = 1111197;
            this.label5.Text = "Status";
            // 
            // cmbstatus
            // 
            this.cmbstatus.FormattingEnabled = true;
            this.cmbstatus.Location = new System.Drawing.Point(1052, 23);
            this.cmbstatus.Name = "cmbstatus";
            this.cmbstatus.Size = new System.Drawing.Size(120, 27);
            this.cmbstatus.TabIndex = 6;
            this.cmbstatus.Enter += new System.EventHandler(this.Cmbstatus_Enter);
            this.cmbstatus.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Cmbstatus_KeyDown);
            this.cmbstatus.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Cmbstatus_KeyPress);
            this.cmbstatus.Leave += new System.EventHandler(this.Cmbstatus_Leave);
            // 
            // cmbConcern
            // 
            this.cmbConcern.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbConcern.FormattingEnabled = true;
            this.cmbConcern.Location = new System.Drawing.Point(67, 23);
            this.cmbConcern.Name = "cmbConcern";
            this.cmbConcern.Size = new System.Drawing.Size(83, 27);
            this.cmbConcern.TabIndex = 1;
            this.cmbConcern.Enter += new System.EventHandler(this.CmbConcern_Enter);
            this.cmbConcern.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbConcern_KeyDown);
            this.cmbConcern.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbConcern_KeyPress);
            this.cmbConcern.Leave += new System.EventHandler(this.CmbConcern_Leave);
            // 
            // txtSupplier
            // 
            this.txtSupplier.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtSupplier.Location = new System.Drawing.Point(557, 23);
            this.txtSupplier.MaxLength = 100;
            this.txtSupplier.Name = "txtSupplier";
            this.txtSupplier.Size = new System.Drawing.Size(246, 27);
            this.txtSupplier.TabIndex = 4;
            this.txtSupplier.TextChanged += new System.EventHandler(this.TxtSupplier_TextChanged);
            this.txtSupplier.Enter += new System.EventHandler(this.TxtSupplier_Enter);
            this.txtSupplier.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtSupplier_KeyDown);
            this.txtSupplier.Leave += new System.EventHandler(this.TxtSupplier_Leave);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(7, 26);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 20);
            this.label10.TabIndex = 1111194;
            this.label10.Text = "Concern";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(806, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 20);
            this.label4.TabIndex = 1111193;
            this.label4.Text = "Entry Type";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(467, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 20);
            this.label2.TabIndex = 1111192;
            this.label2.Text = "Supplier Name";
            // 
            // cmbOrdertype
            // 
            this.cmbOrdertype.FormattingEnabled = true;
            this.cmbOrdertype.Location = new System.Drawing.Point(874, 23);
            this.cmbOrdertype.Name = "cmbOrdertype";
            this.cmbOrdertype.Size = new System.Drawing.Size(129, 27);
            this.cmbOrdertype.TabIndex = 5;
            this.cmbOrdertype.Enter += new System.EventHandler(this.CmbOrdertype_Enter);
            this.cmbOrdertype.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbOrdertype_KeyDown);
            this.cmbOrdertype.Leave += new System.EventHandler(this.CmbOrdertype_Leave);
            // 
            // dpToDate
            // 
            this.dpToDate.CustomFormat = "dd/MM/yyyy";
            this.dpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpToDate.Location = new System.Drawing.Point(356, 23);
            this.dpToDate.Name = "dpToDate";
            this.dpToDate.Size = new System.Drawing.Size(107, 27);
            this.dpToDate.TabIndex = 3;
            this.dpToDate.Enter += new System.EventHandler(this.DpToDate_Enter);
            this.dpToDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DpToDate_KeyDown);
            this.dpToDate.Leave += new System.EventHandler(this.DpToDate_Leave);
            // 
            // dpFromDate
            // 
            this.dpFromDate.CustomFormat = "dd/MM/yyyy";
            this.dpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpFromDate.Location = new System.Drawing.Point(244, 23);
            this.dpFromDate.Name = "dpFromDate";
            this.dpFromDate.Size = new System.Drawing.Size(107, 27);
            this.dpFromDate.TabIndex = 2;
            this.dpFromDate.ValueChanged += new System.EventHandler(this.DpFromDate_ValueChanged);
            this.dpFromDate.Enter += new System.EventHandler(this.DpFromDate_Enter);
            this.dpFromDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DpFromDate_KeyDown);
            this.dpFromDate.Leave += new System.EventHandler(this.DpFromDate_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(153, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 20);
            this.label1.TabIndex = 1111191;
            this.label1.Text = "Purchase Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1252, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 20);
            this.label3.TabIndex = 1111196;
            this.label3.Text = "0";
            this.label3.Visible = false;
            // 
            // btnView
            // 
            this.btnView.Image = global::ROMS.Properties.Resources.view;
            this.btnView.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnView.Location = new System.Drawing.Point(1175, 20);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(32, 33);
            this.btnView.TabIndex = 7;
            this.btnView.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.BtnView_Click);
            this.btnView.Enter += new System.EventHandler(this.BtnView_Enter);
            this.btnView.Leave += new System.EventHandler(this.BtnView_Leave);
            // 
            // picLoader
            // 
            this.picLoader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picLoader.ErrorImage = null;
            this.picLoader.Image = global::ROMS.Properties.Resources.Iphone_spinner_2;
            this.picLoader.InitialImage = null;
            this.picLoader.Location = new System.Drawing.Point(3, 130);
            this.picLoader.Name = "picLoader";
            this.picLoader.Size = new System.Drawing.Size(1348, 536);
            this.picLoader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picLoader.TabIndex = 1111196;
            this.picLoader.TabStop = false;
            this.picLoader.Visible = false;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "GSTR Status";
            this.dataGridViewImageColumn1.Image = global::ROMS.Properties.Resources.pending;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // lblSupplierCode
            // 
            this.lblSupplierCode.AutoSize = true;
            this.lblSupplierCode.BackColor = System.Drawing.Color.Green;
            this.lblSupplierCode.Location = new System.Drawing.Point(928, 7);
            this.lblSupplierCode.Name = "lblSupplierCode";
            this.lblSupplierCode.Size = new System.Drawing.Size(16, 20);
            this.lblSupplierCode.TabIndex = 1111197;
            this.lblSupplierCode.Text = "0";
            this.lblSupplierCode.Visible = false;
            // 
            // lblschedleCode
            // 
            this.lblschedleCode.AutoSize = true;
            this.lblschedleCode.BackColor = System.Drawing.Color.LimeGreen;
            this.lblschedleCode.Location = new System.Drawing.Point(874, 7);
            this.lblschedleCode.Name = "lblschedleCode";
            this.lblschedleCode.Size = new System.Drawing.Size(16, 20);
            this.lblschedleCode.TabIndex = 1111196;
            this.lblschedleCode.Text = "0";
            this.lblschedleCode.Visible = false;
            // 
            // errPurchaseList
            // 
            this.errPurchaseList.ContainerControl = this;
            // 
            // CP_PurchaseList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(1354, 675);
            this.Controls.Add(this.lblSupplierCode);
            this.Controls.Add(this.lblschedleCode);
            this.Controls.Add(this.pnlpurchase);
            this.Controls.Add(this.tsPurchaseList);
            this.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "CP_PurchaseList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Purchase Entry";
            this.Load += new System.EventHandler(this.CP_PurchaseList_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CP_PurchaseList_KeyDown);
            this.tsPurchaseList.ResumeLayout(false);
            this.tsPurchaseList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPurchaseEntryList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_SearchGrid)).EndInit();
            this.pnlpurchase.ResumeLayout(false);
            this.pnlpurchase.PerformLayout();
            this.grpFilterby.ResumeLayout(false);
            this.grpFilterby.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errPurchaseList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsPurchaseList;
        private System.Windows.Forms.ToolStripLabel tspHeader;
        public System.Windows.Forms.ToolStripButton tsbQueue;
        public System.Windows.Forms.ToolStripSeparator tssEdit;
        public System.Windows.Forms.ToolStripButton tsbEdit;
        public System.Windows.Forms.ToolStripSeparator tssNew;
        public System.Windows.Forms.ToolStripButton tsbNew;
        private System.Windows.Forms.Panel pnlpurchase;
        public System.Windows.Forms.DataGridView DGV_SearchGrid;
        private System.Windows.Forms.Label lblNoRecordsFound;
        public System.Windows.Forms.DataGridView grdPurchaseEntryList;
        private System.Windows.Forms.GroupBox grpFilterby;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        public System.Windows.Forms.ListView LV_Supplier;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.ComboBox cmbstatus;
        private System.Windows.Forms.ComboBox cmbConcern;
        private System.Windows.Forms.TextBox txtSupplier;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox cmbOrdertype;
        private System.Windows.Forms.DateTimePicker dpToDate;
        private System.Windows.Forms.DateTimePicker dpFromDate;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label lblSupplierCode;
        public System.Windows.Forms.Label lblschedleCode;
        private System.Windows.Forms.ErrorProvider errPurchaseList;
        private System.Windows.Forms.PictureBox picLoader;
        private System.Windows.Forms.Label lblQueueCount;
        public System.Windows.Forms.ToolStripSeparator tssDelete;
        public System.Windows.Forms.ToolStripButton tsbDelete;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnTally;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCheck;
        private System.Windows.Forms.DataGridViewImageColumn clmEdit;
        public System.Windows.Forms.ToolStripButton tsTotalQueue;
    }
}