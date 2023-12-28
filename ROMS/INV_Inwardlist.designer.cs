namespace ROMS
{
    partial class INV_Inwardlist
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tsInwardList = new System.Windows.Forms.ToolStrip();
            this.tspHeader = new System.Windows.Forms.ToolStripLabel();
            this.tsbQue = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbNew = new System.Windows.Forms.ToolStripButton();
            this.pnlinward = new System.Windows.Forms.Panel();
            this.lvProduct = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvSLocation = new System.Windows.Forms.ListView();
            this.columnHeader22 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader23 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader24 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grbFilterBy = new System.Windows.Forms.GroupBox();
            this.txtStockLocation = new System.Windows.Forms.TextBox();
            this.cmbConcern = new System.Windows.Forms.ComboBox();
            this.dpToDate = new System.Windows.Forms.DateTimePicker();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.lblDProductNamePicode = new System.Windows.Forms.Label();
            this.dpFromDate = new System.Windows.Forms.DateTimePicker();
            this.lblDGodown = new System.Windows.Forms.Label();
            this.lblinwarddate = new System.Windows.Forms.Label();
            this.lblDConcern = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.DGV_SearchGrid = new System.Windows.Forms.DataGridView();
            this.clmdsno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmdpurchaseno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmInwardType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmdinvoicedate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmdsuppliername = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmdtotalitems = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmdtotalqty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblNoRecordsFound = new System.Windows.Forms.Label();
            this.grdInwardList = new System.Windows.Forms.DataGridView();
            this.picLoader = new System.Windows.Forms.PictureBox();
            this.tsInwardList.SuspendLayout();
            this.pnlinward.SuspendLayout();
            this.grbFilterBy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_SearchGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdInwardList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).BeginInit();
            this.SuspendLayout();
            // 
            // tsInwardList
            // 
            this.tsInwardList.BackColor = System.Drawing.Color.White;
            this.tsInwardList.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsInwardList.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsInwardList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspHeader,
            this.tsbQue,
            this.toolStripSeparator3,
            this.tsbDelete,
            this.toolStripSeparator2,
            this.tsbEdit,
            this.toolStripSeparator1,
            this.tsbNew});
            this.tsInwardList.Location = new System.Drawing.Point(0, 0);
            this.tsInwardList.Name = "tsInwardList";
            this.tsInwardList.Size = new System.Drawing.Size(1354, 27);
            this.tsInwardList.TabIndex = 35;
            this.tsInwardList.Text = "Inward";
            // 
            // tspHeader
            // 
            this.tspHeader.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tspHeader.Image = global::ROMS.Properties.Resources.bread_crumb;
            this.tspHeader.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tspHeader.Margin = new System.Windows.Forms.Padding(15, 1, 0, 2);
            this.tspHeader.Name = "tspHeader";
            this.tspHeader.Size = new System.Drawing.Size(172, 24);
            this.tspHeader.Text = "Goods Inward  From Others";
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
            this.tsbQue.Size = new System.Drawing.Size(63, 24);
            this.tsbQue.Text = "Queue";
            this.tsbQue.Click += new System.EventHandler(this.TsbQue_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator3.Margin = new System.Windows.Forms.Padding(0, 0, 15, 0);
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 27);
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
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator2.Margin = new System.Windows.Forms.Padding(0, 0, 15, 0);
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // tsbEdit
            // 
            this.tsbEdit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbEdit.Image = global::ROMS.Properties.Resources.Edit;
            this.tsbEdit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEdit.Margin = new System.Windows.Forms.Padding(0, 1, 10, 2);
            this.tsbEdit.Name = "tsbEdit";
            this.tsbEdit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tsbEdit.Size = new System.Drawing.Size(50, 24);
            this.tsbEdit.Text = "&Edit";
            this.tsbEdit.Click += new System.EventHandler(this.tsbEdit_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // tsbNew
            // 
            this.tsbNew.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbNew.Image = global::ROMS.Properties.Resources.New;
            this.tsbNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNew.Name = "tsbNew";
            this.tsbNew.Size = new System.Drawing.Size(52, 24);
            this.tsbNew.Text = "&New";
            this.tsbNew.Click += new System.EventHandler(this.TsbNew_Click_1);
            // 
            // pnlinward
            // 
            this.pnlinward.BackColor = System.Drawing.Color.White;
            this.pnlinward.Controls.Add(this.lvProduct);
            this.pnlinward.Controls.Add(this.lvSLocation);
            this.pnlinward.Controls.Add(this.grbFilterBy);
            this.pnlinward.Controls.Add(this.DGV_SearchGrid);
            this.pnlinward.Controls.Add(this.lblNoRecordsFound);
            this.pnlinward.Controls.Add(this.grdInwardList);
            this.pnlinward.Controls.Add(this.picLoader);
            this.pnlinward.Location = new System.Drawing.Point(0, 31);
            this.pnlinward.Name = "pnlinward";
            this.pnlinward.Size = new System.Drawing.Size(1354, 641);
            this.pnlinward.TabIndex = 36;
            // 
            // lvProduct
            // 
            this.lvProduct.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.lvProduct.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvProduct.HideSelection = false;
            this.lvProduct.Location = new System.Drawing.Point(864, 53);
            this.lvProduct.Name = "lvProduct";
            this.lvProduct.Size = new System.Drawing.Size(430, 155);
            this.lvProduct.TabIndex = 111111134;
            this.lvProduct.UseCompatibleStateImageBehavior = false;
            this.lvProduct.View = System.Windows.Forms.View.Details;
            this.lvProduct.Visible = false;
            this.lvProduct.DoubleClick += new System.EventHandler(this.LvProduct_DoubleClick);
            this.lvProduct.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LvProduct_KeyDown);
            // 
            // columnHeader4
            // 
            this.columnHeader4.Width = 150;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Width = 150;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Width = 0;
            // 
            // lvSLocation
            // 
            this.lvSLocation.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader22,
            this.columnHeader23,
            this.columnHeader24});
            this.lvSLocation.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.lvSLocation.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvSLocation.HideSelection = false;
            this.lvSLocation.Location = new System.Drawing.Point(597, 53);
            this.lvSLocation.Name = "lvSLocation";
            this.lvSLocation.Size = new System.Drawing.Size(305, 155);
            this.lvSLocation.TabIndex = 111111133;
            this.lvSLocation.UseCompatibleStateImageBehavior = false;
            this.lvSLocation.View = System.Windows.Forms.View.Details;
            this.lvSLocation.Visible = false;
            this.lvSLocation.DoubleClick += new System.EventHandler(this.LvSLocation_DoubleClick);
            this.lvSLocation.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LvSLocation_KeyDown);
            // 
            // columnHeader22
            // 
            this.columnHeader22.Width = 180;
            // 
            // columnHeader23
            // 
            this.columnHeader23.Width = 120;
            // 
            // columnHeader24
            // 
            this.columnHeader24.Width = 0;
            // 
            // grbFilterBy
            // 
            this.grbFilterBy.Controls.Add(this.txtStockLocation);
            this.grbFilterBy.Controls.Add(this.cmbConcern);
            this.grbFilterBy.Controls.Add(this.dpToDate);
            this.grbFilterBy.Controls.Add(this.txtProductName);
            this.grbFilterBy.Controls.Add(this.lblDProductNamePicode);
            this.grbFilterBy.Controls.Add(this.dpFromDate);
            this.grbFilterBy.Controls.Add(this.lblDGodown);
            this.grbFilterBy.Controls.Add(this.lblinwarddate);
            this.grbFilterBy.Controls.Add(this.lblDConcern);
            this.grbFilterBy.Controls.Add(this.btnExport);
            this.grbFilterBy.Controls.Add(this.btnView);
            this.grbFilterBy.Location = new System.Drawing.Point(3, 2);
            this.grbFilterBy.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbFilterBy.Name = "grbFilterBy";
            this.grbFilterBy.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbFilterBy.Size = new System.Drawing.Size(1328, 67);
            this.grbFilterBy.TabIndex = 958801;
            this.grbFilterBy.TabStop = false;
            this.grbFilterBy.Text = "Filter By ";
            // 
            // txtStockLocation
            // 
            this.txtStockLocation.Location = new System.Drawing.Point(594, 24);
            this.txtStockLocation.Name = "txtStockLocation";
            this.txtStockLocation.Size = new System.Drawing.Size(131, 27);
            this.txtStockLocation.TabIndex = 958816;
            this.txtStockLocation.TextChanged += new System.EventHandler(this.TxtStockLocation_TextChanged);
            this.txtStockLocation.Enter += new System.EventHandler(this.TxtStockLocation_Enter);
            this.txtStockLocation.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtStockLocation_KeyDown);
            this.txtStockLocation.Leave += new System.EventHandler(this.TxtStockLocation_Leave);
            // 
            // cmbConcern
            // 
            this.cmbConcern.FormattingEnabled = true;
            this.cmbConcern.Location = new System.Drawing.Point(86, 24);
            this.cmbConcern.Name = "cmbConcern";
            this.cmbConcern.Size = new System.Drawing.Size(121, 27);
            this.cmbConcern.TabIndex = 958815;
            this.cmbConcern.Enter += new System.EventHandler(this.CmbConcern_Enter);
            this.cmbConcern.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbConcern_KeyDown);
            this.cmbConcern.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbConcern_KeyPress);
            this.cmbConcern.Leave += new System.EventHandler(this.CmbConcern_Leave);
            // 
            // dpToDate
            // 
            this.dpToDate.CustomFormat = "dd/MM/yyyy";
            this.dpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpToDate.Location = new System.Drawing.Point(403, 24);
            this.dpToDate.Name = "dpToDate";
            this.dpToDate.Size = new System.Drawing.Size(104, 27);
            this.dpToDate.TabIndex = 958814;
            this.dpToDate.Enter += new System.EventHandler(this.DpToDate_Enter);
            this.dpToDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DpToDate_KeyDown);
            this.dpToDate.Leave += new System.EventHandler(this.DpToDate_Leave);
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(861, 24);
            this.txtProductName.MaxLength = 2;
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(267, 27);
            this.txtProductName.TabIndex = 958812;
            this.txtProductName.TextChanged += new System.EventHandler(this.TxtProductName_TextChanged);
            this.txtProductName.Enter += new System.EventHandler(this.TxtProductName_Enter);
            this.txtProductName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtProductName_KeyDown);
            this.txtProductName.Leave += new System.EventHandler(this.TxtProductName_Leave);
            // 
            // lblDProductNamePicode
            // 
            this.lblDProductNamePicode.AutoSize = true;
            this.lblDProductNamePicode.Location = new System.Drawing.Point(725, 26);
            this.lblDProductNamePicode.Name = "lblDProductNamePicode";
            this.lblDProductNamePicode.Size = new System.Drawing.Size(134, 20);
            this.lblDProductNamePicode.TabIndex = 958811;
            this.lblDProductNamePicode.Text = "Product Name/P.I Code";
            // 
            // dpFromDate
            // 
            this.dpFromDate.CustomFormat = "dd/MM/yyyy";
            this.dpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpFromDate.Location = new System.Drawing.Point(295, 24);
            this.dpFromDate.Name = "dpFromDate";
            this.dpFromDate.Size = new System.Drawing.Size(104, 27);
            this.dpFromDate.TabIndex = 93;
            this.dpFromDate.ValueChanged += new System.EventHandler(this.DpFromDate_ValueChanged);
            this.dpFromDate.Enter += new System.EventHandler(this.DpFromDate_Enter);
            this.dpFromDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DpFromDate_KeyDown);
            this.dpFromDate.Leave += new System.EventHandler(this.DpFromDate_Leave);
            // 
            // lblDGodown
            // 
            this.lblDGodown.AutoSize = true;
            this.lblDGodown.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.lblDGodown.Location = new System.Drawing.Point(509, 26);
            this.lblDGodown.Name = "lblDGodown";
            this.lblDGodown.Size = new System.Drawing.Size(87, 20);
            this.lblDGodown.TabIndex = 38;
            this.lblDGodown.Text = "Stock Location";
            // 
            // lblinwarddate
            // 
            this.lblinwarddate.AutoSize = true;
            this.lblinwarddate.Location = new System.Drawing.Point(217, 26);
            this.lblinwarddate.Name = "lblinwarddate";
            this.lblinwarddate.Size = new System.Drawing.Size(75, 20);
            this.lblinwarddate.TabIndex = 92;
            this.lblinwarddate.Text = "Inward Date";
            // 
            // lblDConcern
            // 
            this.lblDConcern.AutoSize = true;
            this.lblDConcern.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.lblDConcern.Location = new System.Drawing.Point(26, 26);
            this.lblDConcern.Name = "lblDConcern";
            this.lblDConcern.Size = new System.Drawing.Size(54, 20);
            this.lblDConcern.TabIndex = 36;
            this.lblDConcern.Text = "Concern";
            // 
            // btnExport
            // 
            this.btnExport.Image = global::ROMS.Properties.Resources.excel;
            this.btnExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExport.Location = new System.Drawing.Point(1212, 22);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(79, 29);
            this.btnExport.TabIndex = 5;
            this.btnExport.Text = "Export";
            this.btnExport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExport.UseVisualStyleBackColor = true;
            // 
            // btnView
            // 
            this.btnView.Image = global::ROMS.Properties.Resources.view;
            this.btnView.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnView.Location = new System.Drawing.Point(1133, 22);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(75, 29);
            this.btnView.TabIndex = 4;
            this.btnView.Text = "View";
            this.btnView.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.BtnView_Click);
            // 
            // DGV_SearchGrid
            // 
            this.DGV_SearchGrid.AllowUserToAddRows = false;
            this.DGV_SearchGrid.AllowUserToDeleteRows = false;
            this.DGV_SearchGrid.AllowUserToResizeRows = false;
            this.DGV_SearchGrid.BackgroundColor = System.Drawing.Color.White;
            this.DGV_SearchGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_SearchGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.DGV_SearchGrid.ColumnHeadersHeight = 30;
            this.DGV_SearchGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGV_SearchGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmdsno,
            this.clmdpurchaseno,
            this.clmInwardType,
            this.clmdinvoicedate,
            this.clmdsuppliername,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.Column1,
            this.Column2,
            this.clmdtotalitems,
            this.dataGridViewTextBoxColumn3,
            this.clmdtotalqty});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV_SearchGrid.DefaultCellStyle = dataGridViewCellStyle8;
            this.DGV_SearchGrid.EnableHeadersVisualStyles = false;
            this.DGV_SearchGrid.GridColor = System.Drawing.Color.White;
            this.DGV_SearchGrid.Location = new System.Drawing.Point(3, 74);
            this.DGV_SearchGrid.Name = "DGV_SearchGrid";
            this.DGV_SearchGrid.RowHeadersVisible = false;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.DGV_SearchGrid.RowsDefaultCellStyle = dataGridViewCellStyle9;
            this.DGV_SearchGrid.RowTemplate.Height = 25;
            this.DGV_SearchGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DGV_SearchGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DGV_SearchGrid.ShowRowErrors = false;
            this.DGV_SearchGrid.Size = new System.Drawing.Size(1348, 56);
            this.DGV_SearchGrid.TabIndex = 958800;
            // 
            // clmdsno
            // 
            this.clmdsno.HeaderText = "S.No.";
            this.clmdsno.Name = "clmdsno";
            // 
            // clmdpurchaseno
            // 
            this.clmdpurchaseno.HeaderText = "Concern";
            this.clmdpurchaseno.Name = "clmdpurchaseno";
            // 
            // clmInwardType
            // 
            this.clmInwardType.HeaderText = "Inward No.";
            this.clmInwardType.Name = "clmInwardType";
            // 
            // clmdinvoicedate
            // 
            this.clmdinvoicedate.HeaderText = "Inward Date";
            this.clmdinvoicedate.Name = "clmdinvoicedate";
            // 
            // clmdsuppliername
            // 
            this.clmdsuppliername.HeaderText = "Supplier";
            this.clmdsuppliername.Name = "clmdsuppliername";
            this.clmdsuppliername.Width = 200;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "City";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "GSTIN";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Stock Location";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Transaction Type";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 120;
            // 
            // clmdtotalitems
            // 
            this.clmdtotalitems.HeaderText = "Total Products";
            this.clmdtotalitems.Name = "clmdtotalitems";
            this.clmdtotalitems.Width = 200;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Status";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // clmdtotalqty
            // 
            this.clmdtotalqty.HeaderText = "Created By";
            this.clmdtotalqty.Name = "clmdtotalqty";
            this.clmdtotalqty.Width = 200;
            // 
            // lblNoRecordsFound
            // 
            this.lblNoRecordsFound.AutoSize = true;
            this.lblNoRecordsFound.BackColor = System.Drawing.Color.White;
            this.lblNoRecordsFound.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoRecordsFound.Location = new System.Drawing.Point(622, 381);
            this.lblNoRecordsFound.Name = "lblNoRecordsFound";
            this.lblNoRecordsFound.Size = new System.Drawing.Size(106, 20);
            this.lblNoRecordsFound.TabIndex = 958798;
            this.lblNoRecordsFound.Text = "No Records Found";
            this.lblNoRecordsFound.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // grdInwardList
            // 
            this.grdInwardList.AllowUserToAddRows = false;
            this.grdInwardList.AllowUserToDeleteRows = false;
            this.grdInwardList.AllowUserToResizeColumns = false;
            this.grdInwardList.AllowUserToResizeRows = false;
            this.grdInwardList.BackgroundColor = System.Drawing.Color.White;
            this.grdInwardList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdInwardList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.grdInwardList.ColumnHeadersHeight = 30;
            this.grdInwardList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdInwardList.DefaultCellStyle = dataGridViewCellStyle11;
            this.grdInwardList.EnableHeadersVisualStyles = false;
            this.grdInwardList.GridColor = System.Drawing.Color.White;
            this.grdInwardList.Location = new System.Drawing.Point(3, 130);
            this.grdInwardList.Name = "grdInwardList";
            this.grdInwardList.ReadOnly = true;
            this.grdInwardList.RowHeadersVisible = false;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.White;
            this.grdInwardList.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.grdInwardList.RowTemplate.Height = 25;
            this.grdInwardList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdInwardList.Size = new System.Drawing.Size(1348, 570);
            this.grdInwardList.TabIndex = 958797;
            // 
            // picLoader
            // 
            this.picLoader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picLoader.ErrorImage = null;
            this.picLoader.Image = global::ROMS.Properties.Resources.loader;
            this.picLoader.InitialImage = null;
            this.picLoader.Location = new System.Drawing.Point(797, 381);
            this.picLoader.Name = "picLoader";
            this.picLoader.Size = new System.Drawing.Size(544, 247);
            this.picLoader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picLoader.TabIndex = 958799;
            this.picLoader.TabStop = false;
            this.picLoader.Visible = false;
            // 
            // INV_Inwardlist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(1354, 675);
            this.Controls.Add(this.pnlinward);
            this.Controls.Add(this.tsInwardList);
            this.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "INV_Inwardlist";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inward";
            this.Load += new System.EventHandler(this.INV_Inwardlist_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.INV_Inwardlist_KeyDown);
            this.tsInwardList.ResumeLayout(false);
            this.tsInwardList.PerformLayout();
            this.pnlinward.ResumeLayout(false);
            this.pnlinward.PerformLayout();
            this.grbFilterBy.ResumeLayout(false);
            this.grbFilterBy.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_SearchGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdInwardList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStripLabel tspHeader;
        public System.Windows.Forms.ToolStripButton tsbEdit;
        private System.Windows.Forms.ToolStrip tsInwardList;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbNew;
        private System.Windows.Forms.Panel pnlinward;
        public System.Windows.Forms.DataGridView DGV_SearchGrid;
        private System.Windows.Forms.Label lblNoRecordsFound;
        public System.Windows.Forms.DataGridView grdInwardList;
        private System.Windows.Forms.PictureBox picLoader;
        private System.Windows.Forms.GroupBox grbFilterBy;
        private System.Windows.Forms.DateTimePicker dpToDate;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Label lblDProductNamePicode;
        private System.Windows.Forms.DateTimePicker dpFromDate;
        private System.Windows.Forms.Label lblDGodown;
        private System.Windows.Forms.Label lblinwarddate;
        private System.Windows.Forms.Label lblDConcern;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmdsno;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmdpurchaseno;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmInwardType;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmdinvoicedate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmdsuppliername;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmdtotalitems;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmdtotalqty;
        public System.Windows.Forms.ToolStripButton tsbQue;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        public System.Windows.Forms.ToolStripButton tsbDelete;
        private System.Windows.Forms.ComboBox cmbConcern;
        private System.Windows.Forms.TextBox txtStockLocation;
        public System.Windows.Forms.ListView lvSLocation;
        private System.Windows.Forms.ColumnHeader columnHeader22;
        private System.Windows.Forms.ColumnHeader columnHeader23;
        private System.Windows.Forms.ColumnHeader columnHeader24;
        public System.Windows.Forms.ListView lvProduct;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
    }
}