namespace ROMS
{
    partial class INV_ReconciliationList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle64 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle65 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle66 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle67 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle68 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle69 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle70 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle71 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle72 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle61 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle62 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle63 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tsRackGroupList = new System.Windows.Forms.ToolStrip();
            this.tspHeader = new System.Windows.Forms.ToolStripLabel();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.tssEdit = new System.Windows.Forms.ToolStripSeparator();
            this.tsbEdit = new System.Windows.Forms.ToolStripButton();
            this.tssNew = new System.Windows.Forms.ToolStripSeparator();
            this.tsbNew = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.DGV_FilterProduct = new System.Windows.Forms.DataGridView();
            this.DGV_SearchGrid = new System.Windows.Forms.DataGridView();
            this.grdStockReconciliationList = new System.Windows.Forms.DataGridView();
            this.clmPrint = new System.Windows.Forms.DataGridViewImageColumn();
            this.grbFilterBy = new System.Windows.Forms.GroupBox();
            this.cmbTransactionType = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtStockLocation = new System.Windows.Forms.TextBox();
            this.dtpReconToDate = new System.Windows.Forms.DateTimePicker();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.lblDProductNamePicode = new System.Windows.Forms.Label();
            this.dtpReconDate = new System.Windows.Forms.DateTimePicker();
            this.lblDGodown = new System.Windows.Forms.Label();
            this.lbloutwarddate = new System.Windows.Forms.Label();
            this.lblDConcern = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.cmbConcern = new System.Windows.Forms.ComboBox();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.lblNoRecordsFound = new System.Windows.Forms.Label();
            this.picLoader = new System.Windows.Forms.PictureBox();
            this.DGV_FilterLocation = new System.Windows.Forms.DataGridView();
            this.tsRackGroupList.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_FilterProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_SearchGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdStockReconciliationList)).BeginInit();
            this.grbFilterBy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_FilterLocation)).BeginInit();
            this.SuspendLayout();
            // 
            // tsRackGroupList
            // 
            this.tsRackGroupList.BackColor = System.Drawing.Color.White;
            this.tsRackGroupList.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsRackGroupList.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsRackGroupList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspHeader,
            this.tsbDelete,
            this.tssEdit,
            this.tsbEdit,
            this.tssNew,
            this.tsbNew});
            this.tsRackGroupList.Location = new System.Drawing.Point(0, 0);
            this.tsRackGroupList.Name = "tsRackGroupList";
            this.tsRackGroupList.Size = new System.Drawing.Size(1354, 27);
            this.tsRackGroupList.TabIndex = 35;
            this.tsRackGroupList.Text = "Rack Group";
            // 
            // tspHeader
            // 
            this.tspHeader.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tspHeader.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tspHeader.Margin = new System.Windows.Forms.Padding(15, 1, 0, 2);
            this.tspHeader.Name = "tspHeader";
            this.tspHeader.Size = new System.Drawing.Size(133, 24);
            this.tspHeader.Text = "Stock Reconciliation";
            // 
            // tsbDelete
            // 
            this.tsbDelete.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
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
            this.tsbNew.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNew.Margin = new System.Windows.Forms.Padding(0, 1, 10, 2);
            this.tsbNew.Name = "tsbNew";
            this.tsbNew.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tsbNew.Size = new System.Drawing.Size(52, 24);
            this.tsbNew.Text = "&New";
            this.tsbNew.Click += new System.EventHandler(this.tsbNew_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.DGV_FilterLocation);
            this.panel1.Controls.Add(this.DGV_FilterProduct);
            this.panel1.Controls.Add(this.DGV_SearchGrid);
            this.panel1.Controls.Add(this.grdStockReconciliationList);
            this.panel1.Controls.Add(this.grbFilterBy);
            this.panel1.Controls.Add(this.lblNoRecordsFound);
            this.panel1.Controls.Add(this.picLoader);
            this.panel1.Location = new System.Drawing.Point(0, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1354, 643);
            this.panel1.TabIndex = 36;
            // 
            // DGV_FilterProduct
            // 
            this.DGV_FilterProduct.AllowUserToAddRows = false;
            this.DGV_FilterProduct.AllowUserToDeleteRows = false;
            this.DGV_FilterProduct.AllowUserToResizeColumns = false;
            this.DGV_FilterProduct.AllowUserToResizeRows = false;
            this.DGV_FilterProduct.BackgroundColor = System.Drawing.Color.White;
            this.DGV_FilterProduct.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle64.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle64.BackColor = System.Drawing.Color.Chocolate;
            dataGridViewCellStyle64.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle64.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle64.SelectionBackColor = System.Drawing.Color.Chocolate;
            dataGridViewCellStyle64.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle64.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_FilterProduct.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle64;
            this.DGV_FilterProduct.ColumnHeadersHeight = 30;
            this.DGV_FilterProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle65.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle65.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle65.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle65.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle65.SelectionBackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle65.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle65.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV_FilterProduct.DefaultCellStyle = dataGridViewCellStyle65;
            this.DGV_FilterProduct.EnableHeadersVisualStyles = false;
            this.DGV_FilterProduct.GridColor = System.Drawing.Color.White;
            this.DGV_FilterProduct.Location = new System.Drawing.Point(563, 76);
            this.DGV_FilterProduct.Name = "DGV_FilterProduct";
            this.DGV_FilterProduct.ReadOnly = true;
            this.DGV_FilterProduct.RowHeadersVisible = false;
            dataGridViewCellStyle66.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle66.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.DGV_FilterProduct.RowsDefaultCellStyle = dataGridViewCellStyle66;
            this.DGV_FilterProduct.RowTemplate.Height = 25;
            this.DGV_FilterProduct.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV_FilterProduct.Size = new System.Drawing.Size(721, 226);
            this.DGV_FilterProduct.TabIndex = 111111137;
            this.DGV_FilterProduct.Visible = false;
            this.DGV_FilterProduct.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_FilterProduct_CellDoubleClick);
            this.DGV_FilterProduct.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DGV_FilterProduct_KeyDown);
            // 
            // DGV_SearchGrid
            // 
            this.DGV_SearchGrid.AllowUserToAddRows = false;
            this.DGV_SearchGrid.AllowUserToDeleteRows = false;
            this.DGV_SearchGrid.AllowUserToResizeRows = false;
            this.DGV_SearchGrid.BackgroundColor = System.Drawing.Color.White;
            this.DGV_SearchGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle67.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle67.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle67.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle67.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle67.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(242)))), ((int)(((byte)(213)))));
            dataGridViewCellStyle67.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle67.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_SearchGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle67;
            this.DGV_SearchGrid.ColumnHeadersHeight = 30;
            this.DGV_SearchGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle68.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle68.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle68.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle68.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle68.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle68.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle68.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV_SearchGrid.DefaultCellStyle = dataGridViewCellStyle68;
            this.DGV_SearchGrid.EnableHeadersVisualStyles = false;
            this.DGV_SearchGrid.GridColor = System.Drawing.Color.White;
            this.DGV_SearchGrid.Location = new System.Drawing.Point(2, 91);
            this.DGV_SearchGrid.Name = "DGV_SearchGrid";
            this.DGV_SearchGrid.RowHeadersVisible = false;
            dataGridViewCellStyle69.SelectionBackColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle69.SelectionForeColor = System.Drawing.Color.Black;
            this.DGV_SearchGrid.RowsDefaultCellStyle = dataGridViewCellStyle69;
            this.DGV_SearchGrid.RowTemplate.Height = 25;
            this.DGV_SearchGrid.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.DGV_SearchGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DGV_SearchGrid.ShowRowErrors = false;
            this.DGV_SearchGrid.Size = new System.Drawing.Size(1348, 56);
            this.DGV_SearchGrid.TabIndex = 111111134;
            this.DGV_SearchGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_SearchGrid_CellEndEdit);
            this.DGV_SearchGrid.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.DGV_SearchGrid_CellPainting);
            this.DGV_SearchGrid.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DGV_SearchGrid_ColumnHeaderMouseClick);
            this.DGV_SearchGrid.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.DGV_SearchGrid_ColumnWidthChanged);
            this.DGV_SearchGrid.CurrentCellDirtyStateChanged += new System.EventHandler(this.DGV_SearchGrid_CurrentCellDirtyStateChanged);
            this.DGV_SearchGrid.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.DGV_SearchGrid_EditingControlShowing);
            this.DGV_SearchGrid.Scroll += new System.Windows.Forms.ScrollEventHandler(this.DGV_SearchGrid_Scroll);
            // 
            // grdStockReconciliationList
            // 
            this.grdStockReconciliationList.AllowUserToAddRows = false;
            this.grdStockReconciliationList.AllowUserToDeleteRows = false;
            this.grdStockReconciliationList.AllowUserToResizeColumns = false;
            this.grdStockReconciliationList.AllowUserToResizeRows = false;
            this.grdStockReconciliationList.BackgroundColor = System.Drawing.Color.White;
            this.grdStockReconciliationList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle70.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle70.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle70.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle70.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle70.SelectionBackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle70.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle70.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdStockReconciliationList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle70;
            this.grdStockReconciliationList.ColumnHeadersHeight = 30;
            this.grdStockReconciliationList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdStockReconciliationList.ColumnHeadersVisible = false;
            this.grdStockReconciliationList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmPrint});
            dataGridViewCellStyle71.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle71.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle71.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle71.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle71.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle71.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle71.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdStockReconciliationList.DefaultCellStyle = dataGridViewCellStyle71;
            this.grdStockReconciliationList.EnableHeadersVisualStyles = false;
            this.grdStockReconciliationList.GridColor = System.Drawing.Color.White;
            this.grdStockReconciliationList.Location = new System.Drawing.Point(2, 147);
            this.grdStockReconciliationList.Name = "grdStockReconciliationList";
            this.grdStockReconciliationList.ReadOnly = true;
            this.grdStockReconciliationList.RowHeadersVisible = false;
            dataGridViewCellStyle72.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle72.SelectionForeColor = System.Drawing.Color.White;
            this.grdStockReconciliationList.RowsDefaultCellStyle = dataGridViewCellStyle72;
            this.grdStockReconciliationList.RowTemplate.Height = 25;
            this.grdStockReconciliationList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdStockReconciliationList.Size = new System.Drawing.Size(1348, 493);
            this.grdStockReconciliationList.TabIndex = 111111133;
            this.grdStockReconciliationList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrdOutwardList_CellContentClick);
            this.grdStockReconciliationList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.GrdUserList_DataBindingComplete);
            this.grdStockReconciliationList.Scroll += new System.Windows.Forms.ScrollEventHandler(this.GrdUserList_Scroll);
            this.grdStockReconciliationList.DoubleClick += new System.EventHandler(this.GrdUserList_DoubleClick);
            this.grdStockReconciliationList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GrdUserList_KeyDown);
            // 
            // clmPrint
            // 
            this.clmPrint.HeaderText = "Print";
            this.clmPrint.Name = "clmPrint";
            this.clmPrint.ReadOnly = true;
            this.clmPrint.Visible = false;
            this.clmPrint.Width = 50;
            // 
            // grbFilterBy
            // 
            this.grbFilterBy.Controls.Add(this.cmbTransactionType);
            this.grbFilterBy.Controls.Add(this.lblStatus);
            this.grbFilterBy.Controls.Add(this.label1);
            this.grbFilterBy.Controls.Add(this.txtStockLocation);
            this.grbFilterBy.Controls.Add(this.dtpReconToDate);
            this.grbFilterBy.Controls.Add(this.txtProductName);
            this.grbFilterBy.Controls.Add(this.lblDProductNamePicode);
            this.grbFilterBy.Controls.Add(this.dtpReconDate);
            this.grbFilterBy.Controls.Add(this.lblDGodown);
            this.grbFilterBy.Controls.Add(this.lbloutwarddate);
            this.grbFilterBy.Controls.Add(this.lblDConcern);
            this.grbFilterBy.Controls.Add(this.btnExport);
            this.grbFilterBy.Controls.Add(this.btnView);
            this.grbFilterBy.Controls.Add(this.cmbConcern);
            this.grbFilterBy.Controls.Add(this.cmbStatus);
            this.grbFilterBy.Location = new System.Drawing.Point(3, 2);
            this.grbFilterBy.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbFilterBy.Name = "grbFilterBy";
            this.grbFilterBy.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbFilterBy.Size = new System.Drawing.Size(1348, 84);
            this.grbFilterBy.TabIndex = 958800;
            this.grbFilterBy.TabStop = false;
            this.grbFilterBy.Text = "Filter By ";
            // 
            // cmbTransactionType
            // 
            this.cmbTransactionType.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTransactionType.FormattingEnabled = true;
            this.cmbTransactionType.Location = new System.Drawing.Point(967, 47);
            this.cmbTransactionType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbTransactionType.Name = "cmbTransactionType";
            this.cmbTransactionType.Size = new System.Drawing.Size(107, 27);
            this.cmbTransactionType.TabIndex = 5;
            this.cmbTransactionType.Enter += new System.EventHandler(this.cmbTransactionType_Enter);
            this.cmbTransactionType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbTransactionType_KeyDown);
            this.cmbTransactionType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbTransactionType_KeyPress);
            this.cmbTransactionType.Leave += new System.EventHandler(this.cmbTransactionType_Leave);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(1077, 22);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(45, 20);
            this.lblStatus.TabIndex = 111111135;
            this.lblStatus.Text = "Status";
            this.lblStatus.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(960, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.TabIndex = 111111139;
            this.label1.Text = "Transaction Type";
            // 
            // txtStockLocation
            // 
            this.txtStockLocation.Location = new System.Drawing.Point(336, 47);
            this.txtStockLocation.Name = "txtStockLocation";
            this.txtStockLocation.Size = new System.Drawing.Size(218, 27);
            this.txtStockLocation.TabIndex = 3;
            this.txtStockLocation.TextChanged += new System.EventHandler(this.TxtStockLocation_TextChanged);
            this.txtStockLocation.Enter += new System.EventHandler(this.TxtStockLocation_Enter);
            this.txtStockLocation.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtStockLocation_KeyDown);
            this.txtStockLocation.Leave += new System.EventHandler(this.TxtStockLocation_Leave);
            // 
            // dtpReconToDate
            // 
            this.dtpReconToDate.CustomFormat = "dd/MM/yyyy";
            this.dtpReconToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpReconToDate.Location = new System.Drawing.Point(227, 47);
            this.dtpReconToDate.Name = "dtpReconToDate";
            this.dtpReconToDate.Size = new System.Drawing.Size(104, 27);
            this.dtpReconToDate.TabIndex = 2;
            this.dtpReconToDate.Enter += new System.EventHandler(this.DtpOutwardToDate_Enter);
            this.dtpReconToDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DtpOutwardToDate_KeyDown);
            this.dtpReconToDate.Leave += new System.EventHandler(this.DtpOutwardToDate_Leave);
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(559, 47);
            this.txtProductName.MaxLength = 50;
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(402, 27);
            this.txtProductName.TabIndex = 4;
            this.txtProductName.TextChanged += new System.EventHandler(this.TxtProductName_TextChanged);
            this.txtProductName.Enter += new System.EventHandler(this.TxtProductName_Enter);
            this.txtProductName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtProductName_KeyDown);
            this.txtProductName.Leave += new System.EventHandler(this.TxtProductName_Leave);
            // 
            // lblDProductNamePicode
            // 
            this.lblDProductNamePicode.AutoSize = true;
            this.lblDProductNamePicode.Location = new System.Drawing.Point(562, 24);
            this.lblDProductNamePicode.Name = "lblDProductNamePicode";
            this.lblDProductNamePicode.Size = new System.Drawing.Size(134, 20);
            this.lblDProductNamePicode.TabIndex = 958811;
            this.lblDProductNamePicode.Text = "Product Name/P.I Code";
            // 
            // dtpReconDate
            // 
            this.dtpReconDate.CustomFormat = "dd/MM/yyyy";
            this.dtpReconDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpReconDate.Location = new System.Drawing.Point(118, 47);
            this.dtpReconDate.Name = "dtpReconDate";
            this.dtpReconDate.Size = new System.Drawing.Size(104, 27);
            this.dtpReconDate.TabIndex = 1;
            this.dtpReconDate.ValueChanged += new System.EventHandler(this.DtpOutwardDate_ValueChanged);
            this.dtpReconDate.Enter += new System.EventHandler(this.DtpOutwardDate_Enter);
            this.dtpReconDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DtpOutwardDate_KeyDown);
            this.dtpReconDate.Leave += new System.EventHandler(this.DtpOutwardDate_Leave);
            // 
            // lblDGodown
            // 
            this.lblDGodown.AutoSize = true;
            this.lblDGodown.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.lblDGodown.Location = new System.Drawing.Point(338, 22);
            this.lblDGodown.Name = "lblDGodown";
            this.lblDGodown.Size = new System.Drawing.Size(54, 20);
            this.lblDGodown.TabIndex = 38;
            this.lblDGodown.Text = "Location";
            // 
            // lbloutwarddate
            // 
            this.lbloutwarddate.AutoSize = true;
            this.lbloutwarddate.Location = new System.Drawing.Point(118, 22);
            this.lbloutwarddate.Name = "lbloutwarddate";
            this.lbloutwarddate.Size = new System.Drawing.Size(100, 20);
            this.lbloutwarddate.TabIndex = 92;
            this.lbloutwarddate.Text = "Transaction Date";
            // 
            // lblDConcern
            // 
            this.lblDConcern.AutoSize = true;
            this.lblDConcern.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.lblDConcern.Location = new System.Drawing.Point(9, 22);
            this.lblDConcern.Name = "lblDConcern";
            this.lblDConcern.Size = new System.Drawing.Size(54, 20);
            this.lblDConcern.TabIndex = 36;
            this.lblDConcern.Text = "Concern";
            // 
            // btnExport
            // 
            this.btnExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExport.Location = new System.Drawing.Point(1161, 46);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(79, 29);
            this.btnExport.TabIndex = 7;
            this.btnExport.Text = "Export";
            this.btnExport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.BtnExport_Click);
            this.btnExport.Enter += new System.EventHandler(this.BtnExport_Enter);
            this.btnExport.Leave += new System.EventHandler(this.BtnExport_Leave);
            // 
            // btnView
            // 
            this.btnView.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnView.Location = new System.Drawing.Point(1080, 46);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(75, 29);
            this.btnView.TabIndex = 6;
            this.btnView.Text = "View";
            this.btnView.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.BtnView_Click);
            this.btnView.Enter += new System.EventHandler(this.BtnView_Enter);
            this.btnView.Leave += new System.EventHandler(this.BtnView_Leave);
            // 
            // cmbConcern
            // 
            this.cmbConcern.FormattingEnabled = true;
            this.cmbConcern.Location = new System.Drawing.Point(9, 47);
            this.cmbConcern.Name = "cmbConcern";
            this.cmbConcern.Size = new System.Drawing.Size(104, 27);
            this.cmbConcern.TabIndex = 0;
            this.cmbConcern.Enter += new System.EventHandler(this.CmbConcern_Enter);
            this.cmbConcern.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbConcern_KeyDown);
            this.cmbConcern.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbConcern_KeyPress);
            this.cmbConcern.Leave += new System.EventHandler(this.CmbConcern_Leave);
            // 
            // cmbStatus
            // 
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(1078, 47);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(103, 27);
            this.cmbStatus.TabIndex = 5;
            this.cmbStatus.Visible = false;
            this.cmbStatus.Enter += new System.EventHandler(this.CmbStatus_Enter);
            this.cmbStatus.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbStatus_KeyDown);
            this.cmbStatus.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbStatus_KeyPress);
            this.cmbStatus.Leave += new System.EventHandler(this.CmbStatus_Leave);
            // 
            // lblNoRecordsFound
            // 
            this.lblNoRecordsFound.AutoSize = true;
            this.lblNoRecordsFound.BackColor = System.Drawing.Color.White;
            this.lblNoRecordsFound.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoRecordsFound.Location = new System.Drawing.Point(625, 389);
            this.lblNoRecordsFound.Name = "lblNoRecordsFound";
            this.lblNoRecordsFound.Size = new System.Drawing.Size(106, 20);
            this.lblNoRecordsFound.TabIndex = 958798;
            this.lblNoRecordsFound.Text = "No Records Found";
            this.lblNoRecordsFound.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // picLoader
            // 
            this.picLoader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picLoader.ErrorImage = null;
            this.picLoader.InitialImage = null;
            this.picLoader.Location = new System.Drawing.Point(0, 3);
            this.picLoader.Name = "picLoader";
            this.picLoader.Size = new System.Drawing.Size(1350, 639);
            this.picLoader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picLoader.TabIndex = 958799;
            this.picLoader.TabStop = false;
            this.picLoader.Visible = false;
            // 
            // DGV_FilterLocation
            // 
            this.DGV_FilterLocation.AllowUserToAddRows = false;
            this.DGV_FilterLocation.AllowUserToDeleteRows = false;
            this.DGV_FilterLocation.AllowUserToResizeColumns = false;
            this.DGV_FilterLocation.AllowUserToResizeRows = false;
            this.DGV_FilterLocation.BackgroundColor = System.Drawing.Color.White;
            this.DGV_FilterLocation.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle61.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle61.BackColor = System.Drawing.Color.Chocolate;
            dataGridViewCellStyle61.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle61.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle61.SelectionBackColor = System.Drawing.Color.Chocolate;
            dataGridViewCellStyle61.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle61.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_FilterLocation.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle61;
            this.DGV_FilterLocation.ColumnHeadersHeight = 30;
            this.DGV_FilterLocation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle62.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle62.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle62.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle62.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle62.SelectionBackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle62.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle62.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV_FilterLocation.DefaultCellStyle = dataGridViewCellStyle62;
            this.DGV_FilterLocation.EnableHeadersVisualStyles = false;
            this.DGV_FilterLocation.GridColor = System.Drawing.Color.White;
            this.DGV_FilterLocation.Location = new System.Drawing.Point(339, 76);
            this.DGV_FilterLocation.Name = "DGV_FilterLocation";
            this.DGV_FilterLocation.ReadOnly = true;
            this.DGV_FilterLocation.RowHeadersVisible = false;
            this.DGV_FilterLocation.RowHeadersWidth = 51;
            dataGridViewCellStyle63.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle63.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.DGV_FilterLocation.RowsDefaultCellStyle = dataGridViewCellStyle63;
            this.DGV_FilterLocation.RowTemplate.Height = 25;
            this.DGV_FilterLocation.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV_FilterLocation.Size = new System.Drawing.Size(214, 226);
            this.DGV_FilterLocation.TabIndex = 111111175;
            this.DGV_FilterLocation.Visible = false;
            this.DGV_FilterLocation.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_FilterLocation_CellDoubleClick);
            this.DGV_FilterLocation.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DGV_FilterLocation_KeyDown);
            // 
            // INV_ReconciliationList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(1354, 675);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tsRackGroupList);
            this.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "INV_ReconciliationList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User";
            this.Load += new System.EventHandler(this.INV_GodownOutwardList_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.INV_GodownOutwardList_KeyDown);
            this.tsRackGroupList.ResumeLayout(false);
            this.tsRackGroupList.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_FilterProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_SearchGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdStockReconciliationList)).EndInit();
            this.grbFilterBy.ResumeLayout(false);
            this.grbFilterBy.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_FilterLocation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsRackGroupList;
        private System.Windows.Forms.ToolStripLabel tspHeader;
        public System.Windows.Forms.ToolStripSeparator tssEdit;
        public System.Windows.Forms.ToolStripButton tsbEdit;
        public System.Windows.Forms.ToolStripSeparator tssNew;
        public System.Windows.Forms.ToolStripButton tsbNew;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblNoRecordsFound;
        public System.Windows.Forms.ToolStripButton tsbDelete;
        private System.Windows.Forms.GroupBox grbFilterBy;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.ComboBox cmbConcern;
        private System.Windows.Forms.Label lblDGodown;
        private System.Windows.Forms.Label lblDConcern;
        private System.Windows.Forms.DateTimePicker dtpReconDate;
        private System.Windows.Forms.Label lbloutwarddate;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Label lblDProductNamePicode;
        private System.Windows.Forms.DateTimePicker dtpReconToDate;
        private System.Windows.Forms.TextBox txtStockLocation;
        public System.Windows.Forms.DataGridView grdStockReconciliationList;
        public System.Windows.Forms.DataGridView DGV_SearchGrid;
        private System.Windows.Forms.PictureBox picLoader;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label lblStatus;
        public System.Windows.Forms.DataGridView DGV_FilterProduct;
        private System.Windows.Forms.ComboBox cmbTransactionType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewImageColumn clmPrint;
        public System.Windows.Forms.DataGridView DGV_FilterLocation;
    }
}