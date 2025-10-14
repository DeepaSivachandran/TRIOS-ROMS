namespace ROMS
{
    partial class INV_StockJournal_ConversionList
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
            this.grdStockJournal = new System.Windows.Forms.DataGridView();
            this.clmPrint = new System.Windows.Forms.DataGridViewImageColumn();
            this.grbFilterBy = new System.Windows.Forms.GroupBox();
            this.dtpstkconvtodate = new System.Windows.Forms.DateTimePicker();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.lblDProductNamePicode = new System.Windows.Forms.Label();
            this.dtpstkconvdate = new System.Windows.Forms.DateTimePicker();
            this.lbloutwarddate = new System.Windows.Forms.Label();
            this.lblDConcern = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.cmbConcern = new System.Windows.Forms.ComboBox();
            this.lblNoRecordsFound = new System.Windows.Forms.Label();
            this.picLoader = new System.Windows.Forms.PictureBox();
            this.tsRackGroupList.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_FilterProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_SearchGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdStockJournal)).BeginInit();
            this.grbFilterBy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).BeginInit();
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
            this.tspHeader.Image = global::ROMS.Properties.Resources.bread_crumb;
            this.tspHeader.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tspHeader.Margin = new System.Windows.Forms.Padding(15, 1, 0, 2);
            this.tspHeader.Name = "tspHeader";
            this.tspHeader.Size = new System.Drawing.Size(97, 24);
            this.tspHeader.Text = "Stock Journal";
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
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.DGV_FilterProduct);
            this.panel1.Controls.Add(this.DGV_SearchGrid);
            this.panel1.Controls.Add(this.grdStockJournal);
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Chocolate;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Chocolate;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_FilterProduct.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DGV_FilterProduct.ColumnHeadersHeight = 30;
            this.DGV_FilterProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV_FilterProduct.DefaultCellStyle = dataGridViewCellStyle2;
            this.DGV_FilterProduct.EnableHeadersVisualStyles = false;
            this.DGV_FilterProduct.GridColor = System.Drawing.Color.White;
            this.DGV_FilterProduct.Location = new System.Drawing.Point(336, 76);
            this.DGV_FilterProduct.Name = "DGV_FilterProduct";
            this.DGV_FilterProduct.ReadOnly = true;
            this.DGV_FilterProduct.RowHeadersVisible = false;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.DGV_FilterProduct.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.DGV_FilterProduct.RowTemplate.Height = 25;
            this.DGV_FilterProduct.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV_FilterProduct.Size = new System.Drawing.Size(585, 226);
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
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(242)))), ((int)(((byte)(213)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_SearchGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.DGV_SearchGrid.ColumnHeadersHeight = 30;
            this.DGV_SearchGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV_SearchGrid.DefaultCellStyle = dataGridViewCellStyle5;
            this.DGV_SearchGrid.EnableHeadersVisualStyles = false;
            this.DGV_SearchGrid.GridColor = System.Drawing.Color.White;
            this.DGV_SearchGrid.Location = new System.Drawing.Point(2, 91);
            this.DGV_SearchGrid.Name = "DGV_SearchGrid";
            this.DGV_SearchGrid.RowHeadersVisible = false;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            this.DGV_SearchGrid.RowsDefaultCellStyle = dataGridViewCellStyle6;
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
            // grdStockJournal
            // 
            this.grdStockJournal.AllowUserToAddRows = false;
            this.grdStockJournal.AllowUserToDeleteRows = false;
            this.grdStockJournal.AllowUserToResizeColumns = false;
            this.grdStockJournal.AllowUserToResizeRows = false;
            this.grdStockJournal.BackgroundColor = System.Drawing.Color.White;
            this.grdStockJournal.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdStockJournal.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.grdStockJournal.ColumnHeadersHeight = 30;
            this.grdStockJournal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdStockJournal.ColumnHeadersVisible = false;
            this.grdStockJournal.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmPrint});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdStockJournal.DefaultCellStyle = dataGridViewCellStyle8;
            this.grdStockJournal.EnableHeadersVisualStyles = false;
            this.grdStockJournal.GridColor = System.Drawing.Color.White;
            this.grdStockJournal.Location = new System.Drawing.Point(2, 147);
            this.grdStockJournal.Name = "grdStockJournal";
            this.grdStockJournal.ReadOnly = true;
            this.grdStockJournal.RowHeadersVisible = false;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.White;
            this.grdStockJournal.RowsDefaultCellStyle = dataGridViewCellStyle9;
            this.grdStockJournal.RowTemplate.Height = 25;
            this.grdStockJournal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdStockJournal.Size = new System.Drawing.Size(1348, 493);
            this.grdStockJournal.TabIndex = 111111133;
            this.grdStockJournal.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrdOutwardList_CellContentClick);
            this.grdStockJournal.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.GrdUserList_DataBindingComplete);
            this.grdStockJournal.Scroll += new System.Windows.Forms.ScrollEventHandler(this.GrdUserList_Scroll);
            this.grdStockJournal.DoubleClick += new System.EventHandler(this.GrdUserList_DoubleClick);
            this.grdStockJournal.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GrdUserList_KeyDown);
            // 
            // clmPrint
            // 
            this.clmPrint.HeaderText = "Print";
            this.clmPrint.Image = global::ROMS.Properties.Resources.print16;
            this.clmPrint.Name = "clmPrint";
            this.clmPrint.ReadOnly = true;
            this.clmPrint.Width = 50;
            // 
            // grbFilterBy
            // 
            this.grbFilterBy.Controls.Add(this.dtpstkconvtodate);
            this.grbFilterBy.Controls.Add(this.txtProductName);
            this.grbFilterBy.Controls.Add(this.lblDProductNamePicode);
            this.grbFilterBy.Controls.Add(this.dtpstkconvdate);
            this.grbFilterBy.Controls.Add(this.lbloutwarddate);
            this.grbFilterBy.Controls.Add(this.lblDConcern);
            this.grbFilterBy.Controls.Add(this.btnExport);
            this.grbFilterBy.Controls.Add(this.btnView);
            this.grbFilterBy.Controls.Add(this.cmbConcern);
            this.grbFilterBy.Location = new System.Drawing.Point(3, 2);
            this.grbFilterBy.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbFilterBy.Name = "grbFilterBy";
            this.grbFilterBy.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbFilterBy.Size = new System.Drawing.Size(1348, 84);
            this.grbFilterBy.TabIndex = 958800;
            this.grbFilterBy.TabStop = false;
            this.grbFilterBy.Text = "Filter By ";
            // 
            // dtpstkconvtodate
            // 
            this.dtpstkconvtodate.CustomFormat = "dd/MM/yyyy";
            this.dtpstkconvtodate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpstkconvtodate.Location = new System.Drawing.Point(227, 47);
            this.dtpstkconvtodate.Name = "dtpstkconvtodate";
            this.dtpstkconvtodate.Size = new System.Drawing.Size(104, 27);
            this.dtpstkconvtodate.TabIndex = 2;
            this.dtpstkconvtodate.Enter += new System.EventHandler(this.DtpOutwardToDate_Enter);
            this.dtpstkconvtodate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DtpOutwardToDate_KeyDown);
            this.dtpstkconvtodate.Leave += new System.EventHandler(this.DtpOutwardToDate_Leave);
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(336, 47);
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
            this.lblDProductNamePicode.Location = new System.Drawing.Point(335, 24);
            this.lblDProductNamePicode.Name = "lblDProductNamePicode";
            this.lblDProductNamePicode.Size = new System.Drawing.Size(134, 20);
            this.lblDProductNamePicode.TabIndex = 958811;
            this.lblDProductNamePicode.Text = "Product Name/P.I Code";
            // 
            // dtpstkconvdate
            // 
            this.dtpstkconvdate.CustomFormat = "dd/MM/yyyy";
            this.dtpstkconvdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpstkconvdate.Location = new System.Drawing.Point(118, 47);
            this.dtpstkconvdate.Name = "dtpstkconvdate";
            this.dtpstkconvdate.Size = new System.Drawing.Size(104, 27);
            this.dtpstkconvdate.TabIndex = 1;
            this.dtpstkconvdate.ValueChanged += new System.EventHandler(this.DtpOutwardDate_ValueChanged);
            this.dtpstkconvdate.Enter += new System.EventHandler(this.DtpOutwardDate_Enter);
            this.dtpstkconvdate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DtpOutwardDate_KeyDown);
            this.dtpstkconvdate.Leave += new System.EventHandler(this.DtpOutwardDate_Leave);
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
            this.btnExport.Image = global::ROMS.Properties.Resources.excel;
            this.btnExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExport.Location = new System.Drawing.Point(823, 46);
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
            this.btnView.Image = global::ROMS.Properties.Resources.view;
            this.btnView.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnView.Location = new System.Drawing.Point(743, 46);
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
            this.picLoader.Image = global::ROMS.Properties.Resources.Iphone_spinner_2;
            this.picLoader.InitialImage = null;
            this.picLoader.Location = new System.Drawing.Point(0, 2);
            this.picLoader.Name = "picLoader";
            this.picLoader.Size = new System.Drawing.Size(1351, 640);
            this.picLoader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picLoader.TabIndex = 958799;
            this.picLoader.TabStop = false;
            this.picLoader.Visible = false;
            // 
            // INV_StockJournal_ConversionList
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
            this.Name = "INV_StockJournal_ConversionList";
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
            ((System.ComponentModel.ISupportInitialize)(this.grdStockJournal)).EndInit();
            this.grbFilterBy.ResumeLayout(false);
            this.grbFilterBy.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).EndInit();
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
        private System.Windows.Forms.ComboBox cmbConcern;
        private System.Windows.Forms.Label lblDConcern;
        private System.Windows.Forms.DateTimePicker dtpstkconvdate;
        private System.Windows.Forms.Label lbloutwarddate;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Label lblDProductNamePicode;
        private System.Windows.Forms.DateTimePicker dtpstkconvtodate;
        public System.Windows.Forms.DataGridView grdStockJournal;
        public System.Windows.Forms.DataGridView DGV_SearchGrid;
        private System.Windows.Forms.PictureBox picLoader;
        public System.Windows.Forms.DataGridView DGV_FilterProduct;
        private System.Windows.Forms.DataGridViewImageColumn clmPrint;
        private System.Windows.Forms.Button btnView;
    }
}