namespace ROMS
{
    partial class INV_StockRequestQueueList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tsStockRequestList = new System.Windows.Forms.ToolStrip();
            this.tspShopStkReqQueue = new System.Windows.Forms.ToolStripLabel();
            this.pnlStockRequestList = new System.Windows.Forms.Panel();
            this.DGV_FilterLocation = new System.Windows.Forms.DataGridView();
            this.btnExport = new System.Windows.Forms.Button();
            this.DGV__SearchGrid = new System.Windows.Forms.DataGridView();
            this.grbFilterBy = new System.Windows.Forms.GroupBox();
            this.lblLocationCode = new System.Windows.Forms.Label();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.lblLocationName = new System.Windows.Forms.Label();
            this.btnView = new System.Windows.Forms.Button();
            this.lblRequestTodate = new System.Windows.Forms.Label();
            this.lblProduct = new System.Windows.Forms.Label();
            this.cmbConcern = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.dpEntryToDate = new System.Windows.Forms.DateTimePicker();
            this.dpFromDate = new System.Windows.Forms.DateTimePicker();
            this.lblEntryFromDate = new System.Windows.Forms.Label();
            this.lblNoRecordsFound = new System.Windows.Forms.Label();
            this.grdStockRequestList = new System.Windows.Forms.DataGridView();
            this.clmprint = new System.Windows.Forms.DataGridViewImageColumn();
            this.picLoader = new System.Windows.Forms.PictureBox();
            this.DGV_SearchGridPro = new System.Windows.Forms.DataGridView();
            this.grdProDetails = new System.Windows.Forms.DataGridView();
            this.tsStockRequestList.SuspendLayout();
            this.pnlStockRequestList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_FilterLocation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV__SearchGrid)).BeginInit();
            this.grbFilterBy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdStockRequestList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_SearchGridPro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdProDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // tsStockRequestList
            // 
            this.tsStockRequestList.BackColor = System.Drawing.Color.White;
            this.tsStockRequestList.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsStockRequestList.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsStockRequestList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspShopStkReqQueue});
            this.tsStockRequestList.Location = new System.Drawing.Point(0, 0);
            this.tsStockRequestList.Name = "tsStockRequestList";
            this.tsStockRequestList.Size = new System.Drawing.Size(1354, 25);
            this.tsStockRequestList.TabIndex = 35;
            this.tsStockRequestList.Text = "Stock Request";
            // 
            // tspShopStkReqQueue
            // 
            this.tspShopStkReqQueue.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tspShopStkReqQueue.Image = global::ROMS.Properties.Resources.bread_crumb;
            this.tspShopStkReqQueue.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tspShopStkReqQueue.Margin = new System.Windows.Forms.Padding(15, 1, 0, 2);
            this.tspShopStkReqQueue.Name = "tspShopStkReqQueue";
            this.tspShopStkReqQueue.Size = new System.Drawing.Size(170, 22);
            this.tspShopStkReqQueue.Text = "Shop Stock Request Queue";
            // 
            // pnlStockRequestList
            // 
            this.pnlStockRequestList.BackColor = System.Drawing.Color.White;
            this.pnlStockRequestList.Controls.Add(this.DGV_FilterLocation);
            this.pnlStockRequestList.Controls.Add(this.btnExport);
            this.pnlStockRequestList.Controls.Add(this.DGV__SearchGrid);
            this.pnlStockRequestList.Controls.Add(this.grbFilterBy);
            this.pnlStockRequestList.Controls.Add(this.lblNoRecordsFound);
            this.pnlStockRequestList.Controls.Add(this.grdStockRequestList);
            this.pnlStockRequestList.Controls.Add(this.picLoader);
            this.pnlStockRequestList.Controls.Add(this.DGV_SearchGridPro);
            this.pnlStockRequestList.Controls.Add(this.grdProDetails);
            this.pnlStockRequestList.Location = new System.Drawing.Point(0, 31);
            this.pnlStockRequestList.Name = "pnlStockRequestList";
            this.pnlStockRequestList.Size = new System.Drawing.Size(1354, 642);
            this.pnlStockRequestList.TabIndex = 36;
            this.pnlStockRequestList.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlStockRequestList_Paint);
            // 
            // DGV_FilterLocation
            // 
            this.DGV_FilterLocation.AllowUserToAddRows = false;
            this.DGV_FilterLocation.AllowUserToDeleteRows = false;
            this.DGV_FilterLocation.AllowUserToResizeColumns = false;
            this.DGV_FilterLocation.AllowUserToResizeRows = false;
            this.DGV_FilterLocation.BackgroundColor = System.Drawing.Color.White;
            this.DGV_FilterLocation.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Chocolate;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Chocolate;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_FilterLocation.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DGV_FilterLocation.ColumnHeadersHeight = 30;
            this.DGV_FilterLocation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV_FilterLocation.DefaultCellStyle = dataGridViewCellStyle2;
            this.DGV_FilterLocation.EnableHeadersVisualStyles = false;
            this.DGV_FilterLocation.GridColor = System.Drawing.Color.White;
            this.DGV_FilterLocation.Location = new System.Drawing.Point(413, 77);
            this.DGV_FilterLocation.Name = "DGV_FilterLocation";
            this.DGV_FilterLocation.ReadOnly = true;
            this.DGV_FilterLocation.RowHeadersVisible = false;
            this.DGV_FilterLocation.RowHeadersWidth = 51;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.DGV_FilterLocation.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.DGV_FilterLocation.RowTemplate.Height = 25;
            this.DGV_FilterLocation.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV_FilterLocation.Size = new System.Drawing.Size(273, 226);
            this.DGV_FilterLocation.TabIndex = 111111167;
            this.DGV_FilterLocation.Visible = false;
            this.DGV_FilterLocation.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_FilterLocation_CellContentDoubleClick);
            this.DGV_FilterLocation.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DGV_FilterLocation_KeyDown);
            // 
            // btnExport
            // 
            this.btnExport.Image = global::ROMS.Properties.Resources.excel;
            this.btnExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExport.Location = new System.Drawing.Point(777, 48);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 29);
            this.btnExport.TabIndex = 5;
            this.btnExport.Text = "Export";
            this.btnExport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.BtnExport_Click);
            this.btnExport.Enter += new System.EventHandler(this.BtnExport_Enter);
            this.btnExport.Leave += new System.EventHandler(this.BtnExport_Leave);
            // 
            // DGV__SearchGrid
            // 
            this.DGV__SearchGrid.AllowUserToAddRows = false;
            this.DGV__SearchGrid.AllowUserToDeleteRows = false;
            this.DGV__SearchGrid.AllowUserToResizeRows = false;
            this.DGV__SearchGrid.BackgroundColor = System.Drawing.Color.White;
            this.DGV__SearchGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV__SearchGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.DGV__SearchGrid.ColumnHeadersHeight = 30;
            this.DGV__SearchGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV__SearchGrid.DefaultCellStyle = dataGridViewCellStyle5;
            this.DGV__SearchGrid.EnableHeadersVisualStyles = false;
            this.DGV__SearchGrid.GridColor = System.Drawing.Color.White;
            this.DGV__SearchGrid.Location = new System.Drawing.Point(3, 97);
            this.DGV__SearchGrid.Name = "DGV__SearchGrid";
            this.DGV__SearchGrid.RowHeadersVisible = false;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            this.DGV__SearchGrid.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.DGV__SearchGrid.RowTemplate.Height = 25;
            this.DGV__SearchGrid.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.DGV__SearchGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DGV__SearchGrid.ShowRowErrors = false;
            this.DGV__SearchGrid.Size = new System.Drawing.Size(1348, 56);
            this.DGV__SearchGrid.TabIndex = 958802;
            this.DGV__SearchGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV__SearchGrid_CellEndEdit);
            this.DGV__SearchGrid.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.DGV__SearchGrid_CellPainting);
            this.DGV__SearchGrid.ColumnHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DGV__SearchGrid_ColumnHeaderMouseDoubleClick);
            this.DGV__SearchGrid.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.DGV__SearchGrid_ColumnWidthChanged);
            this.DGV__SearchGrid.CurrentCellDirtyStateChanged += new System.EventHandler(this.DGV__SearchGrid_CurrentCellDirtyStateChanged);
            this.DGV__SearchGrid.Scroll += new System.Windows.Forms.ScrollEventHandler(this.DGV__SearchGrid_Scroll);
            // 
            // grbFilterBy
            // 
            this.grbFilterBy.Controls.Add(this.lblLocationCode);
            this.grbFilterBy.Controls.Add(this.txtLocation);
            this.grbFilterBy.Controls.Add(this.lblLocationName);
            this.grbFilterBy.Controls.Add(this.btnView);
            this.grbFilterBy.Controls.Add(this.lblRequestTodate);
            this.grbFilterBy.Controls.Add(this.lblProduct);
            this.grbFilterBy.Controls.Add(this.cmbConcern);
            this.grbFilterBy.Controls.Add(this.label12);
            this.grbFilterBy.Controls.Add(this.dpEntryToDate);
            this.grbFilterBy.Controls.Add(this.dpFromDate);
            this.grbFilterBy.Controls.Add(this.lblEntryFromDate);
            this.grbFilterBy.Location = new System.Drawing.Point(3, 2);
            this.grbFilterBy.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbFilterBy.Name = "grbFilterBy";
            this.grbFilterBy.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbFilterBy.Size = new System.Drawing.Size(1348, 88);
            this.grbFilterBy.TabIndex = 0;
            this.grbFilterBy.TabStop = false;
            this.grbFilterBy.Text = "Filter By";
            // 
            // lblLocationCode
            // 
            this.lblLocationCode.AutoSize = true;
            this.lblLocationCode.Location = new System.Drawing.Point(674, 34);
            this.lblLocationCode.Name = "lblLocationCode";
            this.lblLocationCode.Size = new System.Drawing.Size(16, 20);
            this.lblLocationCode.TabIndex = 1111232;
            this.lblLocationCode.Text = "0";
            this.lblLocationCode.Visible = false;
            // 
            // txtLocation
            // 
            this.txtLocation.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtLocation.Location = new System.Drawing.Point(408, 47);
            this.txtLocation.MaxLength = 100;
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(275, 27);
            this.txtLocation.TabIndex = 3;
            this.txtLocation.TextChanged += new System.EventHandler(this.txtLocation_TextChanged);
            this.txtLocation.Enter += new System.EventHandler(this.txtLocation_Enter);
            this.txtLocation.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLocation_KeyDown);
            this.txtLocation.Leave += new System.EventHandler(this.txtLocation_Leave);
            // 
            // lblLocationName
            // 
            this.lblLocationName.AutoSize = true;
            this.lblLocationName.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocationName.Location = new System.Drawing.Point(408, 24);
            this.lblLocationName.Name = "lblLocationName";
            this.lblLocationName.Size = new System.Drawing.Size(87, 20);
            this.lblLocationName.TabIndex = 1111181;
            this.lblLocationName.Text = "Location Name";
            // 
            // btnView
            // 
            this.btnView.Image = global::ROMS.Properties.Resources.view;
            this.btnView.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnView.Location = new System.Drawing.Point(693, 46);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(75, 29);
            this.btnView.TabIndex = 4;
            this.btnView.Text = "View";
            this.btnView.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.BtnView_Click);
            this.btnView.Enter += new System.EventHandler(this.BtnView_Enter);
            this.btnView.Leave += new System.EventHandler(this.BtnView_Leave);
            // 
            // lblRequestTodate
            // 
            this.lblRequestTodate.AutoSize = true;
            this.lblRequestTodate.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRequestTodate.Location = new System.Drawing.Point(293, 24);
            this.lblRequestTodate.Name = "lblRequestTodate";
            this.lblRequestTodate.Size = new System.Drawing.Size(49, 20);
            this.lblRequestTodate.TabIndex = 1111179;
            this.lblRequestTodate.Text = "To Date";
            // 
            // lblProduct
            // 
            this.lblProduct.AutoSize = true;
            this.lblProduct.Location = new System.Drawing.Point(558, 16);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(0, 20);
            this.lblProduct.TabIndex = 1111178;
            this.lblProduct.Visible = false;
            // 
            // cmbConcern
            // 
            this.cmbConcern.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbConcern.FormattingEnabled = true;
            this.cmbConcern.Location = new System.Drawing.Point(9, 47);
            this.cmbConcern.Name = "cmbConcern";
            this.cmbConcern.Size = new System.Drawing.Size(165, 27);
            this.cmbConcern.TabIndex = 0;
            this.cmbConcern.Enter += new System.EventHandler(this.CmbConcern_Enter);
            this.cmbConcern.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbConcern_KeyDown);
            this.cmbConcern.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbConcern_KeyPress);
            this.cmbConcern.Leave += new System.EventHandler(this.CmbConcern_Leave);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(9, 24);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(54, 20);
            this.label12.TabIndex = 1111177;
            this.label12.Text = "Concern";
            // 
            // dpEntryToDate
            // 
            this.dpEntryToDate.CustomFormat = "dd/MM/yyyy";
            this.dpEntryToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpEntryToDate.Location = new System.Drawing.Point(293, 47);
            this.dpEntryToDate.Name = "dpEntryToDate";
            this.dpEntryToDate.Size = new System.Drawing.Size(107, 27);
            this.dpEntryToDate.TabIndex = 2;
            this.dpEntryToDate.Enter += new System.EventHandler(this.DpEntryToDate_Enter);
            this.dpEntryToDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DpEntryToDate_KeyDown);
            this.dpEntryToDate.Leave += new System.EventHandler(this.DpEntryToDate_Leave);
            // 
            // dpFromDate
            // 
            this.dpFromDate.CustomFormat = "dd/MM/yyyy";
            this.dpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpFromDate.Location = new System.Drawing.Point(180, 47);
            this.dpFromDate.Name = "dpFromDate";
            this.dpFromDate.Size = new System.Drawing.Size(107, 27);
            this.dpFromDate.TabIndex = 1;
            this.dpFromDate.ValueChanged += new System.EventHandler(this.DpFromDate_ValueChanged);
            this.dpFromDate.Enter += new System.EventHandler(this.DpFromDate_Enter);
            this.dpFromDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DpFromDate_KeyDown);
            this.dpFromDate.Leave += new System.EventHandler(this.DpFromDate_Leave);
            // 
            // lblEntryFromDate
            // 
            this.lblEntryFromDate.AutoSize = true;
            this.lblEntryFromDate.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEntryFromDate.Location = new System.Drawing.Point(180, 24);
            this.lblEntryFromDate.Name = "lblEntryFromDate";
            this.lblEntryFromDate.Size = new System.Drawing.Size(64, 20);
            this.lblEntryFromDate.TabIndex = 1111154;
            this.lblEntryFromDate.Text = "From Date";
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
            // grdStockRequestList
            // 
            this.grdStockRequestList.AllowUserToAddRows = false;
            this.grdStockRequestList.AllowUserToDeleteRows = false;
            this.grdStockRequestList.AllowUserToResizeColumns = false;
            this.grdStockRequestList.AllowUserToResizeRows = false;
            this.grdStockRequestList.BackgroundColor = System.Drawing.Color.White;
            this.grdStockRequestList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdStockRequestList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.grdStockRequestList.ColumnHeadersHeight = 30;
            this.grdStockRequestList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdStockRequestList.ColumnHeadersVisible = false;
            this.grdStockRequestList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmprint});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdStockRequestList.DefaultCellStyle = dataGridViewCellStyle8;
            this.grdStockRequestList.EnableHeadersVisualStyles = false;
            this.grdStockRequestList.GridColor = System.Drawing.Color.White;
            this.grdStockRequestList.Location = new System.Drawing.Point(3, 151);
            this.grdStockRequestList.Name = "grdStockRequestList";
            this.grdStockRequestList.ReadOnly = true;
            this.grdStockRequestList.RowHeadersVisible = false;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.White;
            this.grdStockRequestList.RowsDefaultCellStyle = dataGridViewCellStyle9;
            this.grdStockRequestList.RowTemplate.Height = 25;
            this.grdStockRequestList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdStockRequestList.ShowRowErrors = false;
            this.grdStockRequestList.Size = new System.Drawing.Size(1348, 489);
            this.grdStockRequestList.TabIndex = 958797;
            this.grdStockRequestList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrdStockRequestList_CellContentClick);
            this.grdStockRequestList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrdStockRequestList_CellDoubleClick);
            this.grdStockRequestList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.GrdStockRequestList_DataBindingComplete);
            this.grdStockRequestList.Scroll += new System.Windows.Forms.ScrollEventHandler(this.GrdStockRequestList_Scroll);
            this.grdStockRequestList.SelectionChanged += new System.EventHandler(this.GrdStockRequestList_SelectionChanged);
            this.grdStockRequestList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GrdStockRequestList_KeyDown);
            // 
            // clmprint
            // 
            this.clmprint.HeaderText = "Print";
            this.clmprint.Image = global::ROMS.Properties.Resources.print16x16__2_;
            this.clmprint.Name = "clmprint";
            this.clmprint.ReadOnly = true;
            this.clmprint.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmprint.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.clmprint.Width = 70;
            // 
            // picLoader
            // 
            this.picLoader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picLoader.ErrorImage = null;
            this.picLoader.Image = global::ROMS.Properties.Resources.Iphone_spinner_2;
            this.picLoader.InitialImage = null;
            this.picLoader.Location = new System.Drawing.Point(3, 97);
            this.picLoader.Name = "picLoader";
            this.picLoader.Size = new System.Drawing.Size(1348, 542);
            this.picLoader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picLoader.TabIndex = 958799;
            this.picLoader.TabStop = false;
            this.picLoader.Visible = false;
            // 
            // DGV_SearchGridPro
            // 
            this.DGV_SearchGridPro.AllowUserToAddRows = false;
            this.DGV_SearchGridPro.AllowUserToDeleteRows = false;
            this.DGV_SearchGridPro.AllowUserToResizeRows = false;
            this.DGV_SearchGridPro.BackgroundColor = System.Drawing.Color.White;
            this.DGV_SearchGridPro.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(242)))), ((int)(((byte)(213)))));
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_SearchGridPro.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.DGV_SearchGridPro.ColumnHeadersHeight = 30;
            this.DGV_SearchGridPro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV_SearchGridPro.DefaultCellStyle = dataGridViewCellStyle11;
            this.DGV_SearchGridPro.EnableHeadersVisualStyles = false;
            this.DGV_SearchGridPro.GridColor = System.Drawing.Color.White;
            this.DGV_SearchGridPro.Location = new System.Drawing.Point(3, 97);
            this.DGV_SearchGridPro.Name = "DGV_SearchGridPro";
            this.DGV_SearchGridPro.RowHeadersVisible = false;
            this.DGV_SearchGridPro.RowHeadersWidth = 70;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.Black;
            this.DGV_SearchGridPro.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.DGV_SearchGridPro.RowTemplate.Height = 25;
            this.DGV_SearchGridPro.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.DGV_SearchGridPro.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DGV_SearchGridPro.ShowRowErrors = false;
            this.DGV_SearchGridPro.Size = new System.Drawing.Size(1348, 56);
            this.DGV_SearchGridPro.TabIndex = 111111146;
            this.DGV_SearchGridPro.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_SearchGridPro_CellEndEdit);
            this.DGV_SearchGridPro.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.DGV_SearchGridPro_CellPainting);
            this.DGV_SearchGridPro.ColumnHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DGV_SearchGridPro_ColumnHeaderMouseDoubleClick);
            this.DGV_SearchGridPro.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.DGV_SearchGridPro_ColumnWidthChanged);
            this.DGV_SearchGridPro.CurrentCellDirtyStateChanged += new System.EventHandler(this.DGV_SearchGridPro_CurrentCellDirtyStateChanged);
            this.DGV_SearchGridPro.Scroll += new System.Windows.Forms.ScrollEventHandler(this.DGV_SearchGridPro_Scroll);
            // 
            // grdProDetails
            // 
            this.grdProDetails.AllowUserToAddRows = false;
            this.grdProDetails.AllowUserToDeleteRows = false;
            this.grdProDetails.AllowUserToResizeColumns = false;
            this.grdProDetails.AllowUserToResizeRows = false;
            this.grdProDetails.BackgroundColor = System.Drawing.Color.White;
            this.grdProDetails.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle13.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdProDetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.grdProDetails.ColumnHeadersHeight = 30;
            this.grdProDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdProDetails.ColumnHeadersVisible = false;
            this.grdProDetails.EnableHeadersVisualStyles = false;
            this.grdProDetails.GridColor = System.Drawing.Color.White;
            this.grdProDetails.Location = new System.Drawing.Point(3, 151);
            this.grdProDetails.Name = "grdProDetails";
            this.grdProDetails.ReadOnly = true;
            this.grdProDetails.RowHeadersVisible = false;
            this.grdProDetails.RowHeadersWidth = 100;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.grdProDetails.RowsDefaultCellStyle = dataGridViewCellStyle14;
            this.grdProDetails.RowTemplate.Height = 25;
            this.grdProDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdProDetails.Size = new System.Drawing.Size(1348, 489);
            this.grdProDetails.TabIndex = 111111145;
            this.grdProDetails.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.GrdProDetails_DataBindingComplete);
            this.grdProDetails.Scroll += new System.Windows.Forms.ScrollEventHandler(this.GrdProDetails_Scroll);
            // 
            // INV_StockRequestQueueList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(1354, 675);
            this.Controls.Add(this.pnlStockRequestList);
            this.Controls.Add(this.tsStockRequestList);
            this.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "INV_StockRequestQueueList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Shop Stock Request";
            this.Load += new System.EventHandler(this.INV_StockRequestList_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CP_Supplierlist_KeyDown);
            this.tsStockRequestList.ResumeLayout(false);
            this.tsStockRequestList.PerformLayout();
            this.pnlStockRequestList.ResumeLayout(false);
            this.pnlStockRequestList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_FilterLocation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV__SearchGrid)).EndInit();
            this.grbFilterBy.ResumeLayout(false);
            this.grbFilterBy.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdStockRequestList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_SearchGridPro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdProDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsStockRequestList;
        private System.Windows.Forms.Panel pnlStockRequestList;
        private System.Windows.Forms.Label lblNoRecordsFound;
        public System.Windows.Forms.DataGridView grdStockRequestList;
        private System.Windows.Forms.PictureBox picLoader;
        private System.Windows.Forms.GroupBox grbFilterBy;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Label lblEntryFromDate;
        private System.Windows.Forms.DateTimePicker dpFromDate;
        private System.Windows.Forms.DateTimePicker dpEntryToDate;
        public System.Windows.Forms.DataGridView DGV__SearchGrid;
        private System.Windows.Forms.ComboBox cmbConcern;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Label lblRequestTodate;
        private System.Windows.Forms.DataGridViewImageColumn clmprint;
        public System.Windows.Forms.DataGridView grdProDetails;
        public System.Windows.Forms.DataGridView DGV_SearchGridPro;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Label lblLocationName;
        public System.Windows.Forms.DataGridView DGV_FilterLocation;
        public System.Windows.Forms.Label lblLocationCode;
        public System.Windows.Forms.ToolStripLabel tspShopStkReqQueue;
    }
}