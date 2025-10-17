namespace ROMS
{
    partial class PUR_ReturnDCApprovedList
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
            this.tsPurchaseInvoiceList = new System.Windows.Forms.ToolStrip();
            this.tspHeader = new System.Windows.Forms.ToolStripLabel();
            this.tsbDClist = new System.Windows.Forms.ToolStripButton();
            this.tssEdit = new System.Windows.Forms.ToolStripSeparator();
            this.tsbEdit = new System.Windows.Forms.ToolStripButton();
            this.grdReturnDCList = new System.Windows.Forms.DataGridView();
            this.Print = new System.Windows.Forms.DataGridViewImageColumn();
            this.lblNoRecordsFound = new System.Windows.Forms.Label();
            this.DGV_SearchGrid = new System.Windows.Forms.DataGridView();
            this.picLoader = new System.Windows.Forms.PictureBox();
            this.pnlcity = new System.Windows.Forms.Panel();
            this.LV_Supplier = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grbFilterBy = new System.Windows.Forms.GroupBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.lblschedule = new System.Windows.Forms.Label();
            this.lblSupplierCode = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            this.cmbDCType = new System.Windows.Forms.ComboBox();
            this.lblDCType = new System.Windows.Forms.Label();
            this.cmbConcern = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.dpToDate = new System.Windows.Forms.DateTimePicker();
            this.txtSupplier = new System.Windows.Forms.TextBox();
            this.lblDSupplier = new System.Windows.Forms.Label();
            this.dpFromDate = new System.Windows.Forms.DateTimePicker();
            this.lblInvoicedate = new System.Windows.Forms.Label();
            this.btnView = new System.Windows.Forms.Button();
            this.ep_ReturnDC = new System.Windows.Forms.ErrorProvider(this.components);
            this.clmPrint = new System.Windows.Forms.DataGridViewImageColumn();
            this.tsPurchaseInvoiceList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdReturnDCList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_SearchGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).BeginInit();
            this.pnlcity.SuspendLayout();
            this.grbFilterBy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ep_ReturnDC)).BeginInit();
            this.SuspendLayout();
            // 
            // tsPurchaseInvoiceList
            // 
            this.tsPurchaseInvoiceList.BackColor = System.Drawing.Color.White;
            this.tsPurchaseInvoiceList.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsPurchaseInvoiceList.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsPurchaseInvoiceList.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsPurchaseInvoiceList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspHeader,
            this.tsbDClist,
            this.tssEdit,
            this.tsbEdit});
            this.tsPurchaseInvoiceList.Location = new System.Drawing.Point(0, 0);
            this.tsPurchaseInvoiceList.Name = "tsPurchaseInvoiceList";
            this.tsPurchaseInvoiceList.Size = new System.Drawing.Size(1354, 27);
            this.tsPurchaseInvoiceList.TabIndex = 35;
            this.tsPurchaseInvoiceList.Text = "Purchase Invoice";
            // 
            // tspHeader
            // 
            this.tspHeader.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tspHeader.Image = global::ROMS.Properties.Resources.bread_crumb;
            this.tspHeader.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tspHeader.Margin = new System.Windows.Forms.Padding(15, 1, 0, 2);
            this.tspHeader.Name = "tspHeader";
            this.tspHeader.Size = new System.Drawing.Size(185, 24);
            this.tspHeader.Text = "Purchase Return DC Approval";
            // 
            // tsbDClist
            // 
            this.tsbDClist.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbDClist.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsbDClist.Image = global::ROMS.Properties.Resources.queue;
            this.tsbDClist.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbDClist.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDClist.Margin = new System.Windows.Forms.Padding(0, 1, 10, 2);
            this.tsbDClist.Name = "tsbDClist";
            this.tsbDClist.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tsbDClist.Size = new System.Drawing.Size(162, 24);
            this.tsbDClist.Text = "Purchase Return DC List";
            this.tsbDClist.Click += new System.EventHandler(this.TsbDClist_Click);
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
            this.tsbEdit.Click += new System.EventHandler(this.tsbEdit_Click);
            // 
            // grdReturnDCList
            // 
            this.grdReturnDCList.AllowUserToAddRows = false;
            this.grdReturnDCList.AllowUserToDeleteRows = false;
            this.grdReturnDCList.AllowUserToResizeColumns = false;
            this.grdReturnDCList.AllowUserToResizeRows = false;
            this.grdReturnDCList.BackgroundColor = System.Drawing.Color.White;
            this.grdReturnDCList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdReturnDCList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdReturnDCList.ColumnHeadersHeight = 30;
            this.grdReturnDCList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdReturnDCList.ColumnHeadersVisible = false;
            this.grdReturnDCList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Print});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdReturnDCList.DefaultCellStyle = dataGridViewCellStyle2;
            this.grdReturnDCList.EnableHeadersVisualStyles = false;
            this.grdReturnDCList.GridColor = System.Drawing.Color.White;
            this.grdReturnDCList.Location = new System.Drawing.Point(3, 130);
            this.grdReturnDCList.Name = "grdReturnDCList";
            this.grdReturnDCList.ReadOnly = true;
            this.grdReturnDCList.RowHeadersVisible = false;
            this.grdReturnDCList.RowHeadersWidth = 100;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.grdReturnDCList.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.grdReturnDCList.RowTemplate.Height = 25;
            this.grdReturnDCList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdReturnDCList.Size = new System.Drawing.Size(1348, 510);
            this.grdReturnDCList.TabIndex = 1;
            this.grdReturnDCList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrdReturnDCList_CellContentClick);
            this.grdReturnDCList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.GrdReturnDCList_DataBindingComplete);
            this.grdReturnDCList.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrdReturnDCList_RowEnter);
            this.grdReturnDCList.Scroll += new System.Windows.Forms.ScrollEventHandler(this.GrdReturnDCList_Scroll);
            this.grdReturnDCList.SelectionChanged += new System.EventHandler(this.GrdReturnDCList_SelectionChanged);
            this.grdReturnDCList.DoubleClick += new System.EventHandler(this.GrdReturnDCList_DoubleClick);
            this.grdReturnDCList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GrdReturnDCList_KeyDown);
            // 
            // Print
            // 
            this.Print.HeaderText = "Print";
            this.Print.Image = global::ROMS.Properties.Resources.print16x16__2_;
            this.Print.Name = "Print";
            this.Print.ReadOnly = true;
            this.Print.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Print.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // lblNoRecordsFound
            // 
            this.lblNoRecordsFound.AutoSize = true;
            this.lblNoRecordsFound.BackColor = System.Drawing.Color.White;
            this.lblNoRecordsFound.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoRecordsFound.Location = new System.Drawing.Point(623, 375);
            this.lblNoRecordsFound.Name = "lblNoRecordsFound";
            this.lblNoRecordsFound.Size = new System.Drawing.Size(106, 20);
            this.lblNoRecordsFound.TabIndex = 958763;
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
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Honeydew;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
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
            this.DGV_SearchGrid.TabIndex = 958796;
            this.DGV_SearchGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_SearchGrid_CellEndEdit);
            this.DGV_SearchGrid.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.DGV_SearchGrid_CellPainting);
            this.DGV_SearchGrid.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DGV_SearchGrid_ColumnHeaderMouseClick_1);
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
            this.picLoader.Location = new System.Drawing.Point(3, 130);
            this.picLoader.Name = "picLoader";
            this.picLoader.Size = new System.Drawing.Size(1347, 510);
            this.picLoader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picLoader.TabIndex = 958787;
            this.picLoader.TabStop = false;
            this.picLoader.Visible = false;
            // 
            // pnlcity
            // 
            this.pnlcity.BackColor = System.Drawing.Color.White;
            this.pnlcity.Controls.Add(this.LV_Supplier);
            this.pnlcity.Controls.Add(this.grbFilterBy);
            this.pnlcity.Controls.Add(this.lblNoRecordsFound);
            this.pnlcity.Controls.Add(this.DGV_SearchGrid);
            this.pnlcity.Controls.Add(this.grdReturnDCList);
            this.pnlcity.Controls.Add(this.picLoader);
            this.pnlcity.Location = new System.Drawing.Point(0, 31);
            this.pnlcity.Name = "pnlcity";
            this.pnlcity.Size = new System.Drawing.Size(1354, 643);
            this.pnlcity.TabIndex = 958797;
            // 
            // LV_Supplier
            // 
            this.LV_Supplier.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader1});
            this.LV_Supplier.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.LV_Supplier.HideSelection = false;
            this.LV_Supplier.Location = new System.Drawing.Point(520, 55);
            this.LV_Supplier.Name = "LV_Supplier";
            this.LV_Supplier.Size = new System.Drawing.Size(366, 93);
            this.LV_Supplier.TabIndex = 1111210;
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
            // grbFilterBy
            // 
            this.grbFilterBy.Controls.Add(this.btnPrint);
            this.grbFilterBy.Controls.Add(this.lblschedule);
            this.grbFilterBy.Controls.Add(this.lblSupplierCode);
            this.grbFilterBy.Controls.Add(this.btnExport);
            this.grbFilterBy.Controls.Add(this.cmbDCType);
            this.grbFilterBy.Controls.Add(this.lblDCType);
            this.grbFilterBy.Controls.Add(this.cmbConcern);
            this.grbFilterBy.Controls.Add(this.label12);
            this.grbFilterBy.Controls.Add(this.dpToDate);
            this.grbFilterBy.Controls.Add(this.txtSupplier);
            this.grbFilterBy.Controls.Add(this.lblDSupplier);
            this.grbFilterBy.Controls.Add(this.dpFromDate);
            this.grbFilterBy.Controls.Add(this.lblInvoicedate);
            this.grbFilterBy.Controls.Add(this.btnView);
            this.grbFilterBy.Location = new System.Drawing.Point(3, 3);
            this.grbFilterBy.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbFilterBy.Name = "grbFilterBy";
            this.grbFilterBy.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbFilterBy.Size = new System.Drawing.Size(1348, 67);
            this.grbFilterBy.TabIndex = 958801;
            this.grbFilterBy.TabStop = false;
            this.grbFilterBy.Text = "Filter By ";
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Image = global::ROMS.Properties.Resources.print;
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(1040, 23);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(32, 33);
            this.btnPrint.TabIndex = 1111211;
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Visible = false;
            this.btnPrint.Click += new System.EventHandler(this.BtnPrint_Click);
            this.btnPrint.Enter += new System.EventHandler(this.BtnPrint_Enter);
            this.btnPrint.Leave += new System.EventHandler(this.BtnPrint_Leave);
            // 
            // lblschedule
            // 
            this.lblschedule.AutoSize = true;
            this.lblschedule.Location = new System.Drawing.Point(553, 29);
            this.lblschedule.Name = "lblschedule";
            this.lblschedule.Size = new System.Drawing.Size(16, 20);
            this.lblschedule.TabIndex = 1111178;
            this.lblschedule.Text = "0";
            this.lblschedule.Visible = false;
            // 
            // lblSupplierCode
            // 
            this.lblSupplierCode.AutoSize = true;
            this.lblSupplierCode.Location = new System.Drawing.Point(529, 29);
            this.lblSupplierCode.Name = "lblSupplierCode";
            this.lblSupplierCode.Size = new System.Drawing.Size(16, 20);
            this.lblSupplierCode.TabIndex = 1111177;
            this.lblSupplierCode.Text = "0";
            this.lblSupplierCode.Visible = false;
            // 
            // btnExport
            // 
            this.btnExport.Image = global::ROMS.Properties.Resources.excel;
            this.btnExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExport.Location = new System.Drawing.Point(1002, 23);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(32, 33);
            this.btnExport.TabIndex = 7;
            this.btnExport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.BtnExport_Click);
            this.btnExport.Enter += new System.EventHandler(this.BtnExport_Enter);
            this.btnExport.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BtnExport_KeyDown);
            this.btnExport.Leave += new System.EventHandler(this.BtnExport_Leave);
            // 
            // cmbDCType
            // 
            this.cmbDCType.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDCType.FormattingEnabled = true;
            this.cmbDCType.Items.AddRange(new object[] {
            "--Select--",
            "Damage",
            "Excess"});
            this.cmbDCType.Location = new System.Drawing.Point(835, 26);
            this.cmbDCType.Name = "cmbDCType";
            this.cmbDCType.Size = new System.Drawing.Size(123, 27);
            this.cmbDCType.TabIndex = 4;
            this.cmbDCType.SelectedIndexChanged += new System.EventHandler(this.CmbDCType_SelectedIndexChanged);
            this.cmbDCType.Enter += new System.EventHandler(this.CmbDCType_Enter);
            this.cmbDCType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbDCType_KeyDown);
            this.cmbDCType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbDCType_KeyPress);
            this.cmbDCType.Leave += new System.EventHandler(this.CmbDCType_Leave);
            // 
            // lblDCType
            // 
            this.lblDCType.AutoSize = true;
            this.lblDCType.Location = new System.Drawing.Point(783, 29);
            this.lblDCType.Name = "lblDCType";
            this.lblDCType.Size = new System.Drawing.Size(53, 20);
            this.lblDCType.TabIndex = 1111175;
            this.lblDCType.Text = "DC Type";
            // 
            // cmbConcern
            // 
            this.cmbConcern.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbConcern.FormattingEnabled = true;
            this.cmbConcern.Location = new System.Drawing.Point(76, 26);
            this.cmbConcern.Name = "cmbConcern";
            this.cmbConcern.Size = new System.Drawing.Size(98, 27);
            this.cmbConcern.TabIndex = 0;
            this.cmbConcern.SelectedIndexChanged += new System.EventHandler(this.CmbConcern_SelectedIndexChanged);
            this.cmbConcern.Enter += new System.EventHandler(this.CmbConcern_Enter);
            this.cmbConcern.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbConcern_KeyDown);
            this.cmbConcern.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbConcern_KeyPress);
            this.cmbConcern.Leave += new System.EventHandler(this.CmbConcern_Leave);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(16, 29);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(54, 20);
            this.label12.TabIndex = 1111173;
            this.label12.Text = "Concern";
            // 
            // dpToDate
            // 
            this.dpToDate.CustomFormat = "dd/MM/yyyy";
            this.dpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpToDate.Location = new System.Drawing.Point(347, 26);
            this.dpToDate.Name = "dpToDate";
            this.dpToDate.Size = new System.Drawing.Size(104, 27);
            this.dpToDate.TabIndex = 2;
            this.dpToDate.ValueChanged += new System.EventHandler(this.DpToDate_ValueChanged);
            this.dpToDate.Enter += new System.EventHandler(this.DpToDate_Enter);
            this.dpToDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DpToDate_KeyDown);
            this.dpToDate.Leave += new System.EventHandler(this.DpToDate_Leave);
            // 
            // txtSupplier
            // 
            this.txtSupplier.Location = new System.Drawing.Point(517, 26);
            this.txtSupplier.MaxLength = 150;
            this.txtSupplier.Name = "txtSupplier";
            this.txtSupplier.Size = new System.Drawing.Size(264, 27);
            this.txtSupplier.TabIndex = 3;
            this.txtSupplier.TextChanged += new System.EventHandler(this.TxtSupplier_TextChanged);
            this.txtSupplier.Enter += new System.EventHandler(this.TxtSupplier_Enter);
            this.txtSupplier.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtSupplier_KeyDown);
            this.txtSupplier.Leave += new System.EventHandler(this.TxtSupplier_Leave);
            // 
            // lblDSupplier
            // 
            this.lblDSupplier.AutoSize = true;
            this.lblDSupplier.Location = new System.Drawing.Point(457, 29);
            this.lblDSupplier.Name = "lblDSupplier";
            this.lblDSupplier.Size = new System.Drawing.Size(54, 20);
            this.lblDSupplier.TabIndex = 958811;
            this.lblDSupplier.Text = "Supplier";
            // 
            // dpFromDate
            // 
            this.dpFromDate.CustomFormat = "dd/MM/yyyy";
            this.dpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpFromDate.Location = new System.Drawing.Point(237, 26);
            this.dpFromDate.Name = "dpFromDate";
            this.dpFromDate.Size = new System.Drawing.Size(104, 27);
            this.dpFromDate.TabIndex = 1;
            this.dpFromDate.ValueChanged += new System.EventHandler(this.DpFromDate_ValueChanged);
            this.dpFromDate.Enter += new System.EventHandler(this.DpFromDate_Enter);
            this.dpFromDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DpFromDate_KeyDown);
            this.dpFromDate.Leave += new System.EventHandler(this.DpFromDate_Leave);
            // 
            // lblInvoicedate
            // 
            this.lblInvoicedate.AutoSize = true;
            this.lblInvoicedate.Location = new System.Drawing.Point(180, 29);
            this.lblInvoicedate.Name = "lblInvoicedate";
            this.lblInvoicedate.Size = new System.Drawing.Size(53, 20);
            this.lblInvoicedate.TabIndex = 92;
            this.lblInvoicedate.Text = "DC Date";
            // 
            // btnView
            // 
            this.btnView.Image = global::ROMS.Properties.Resources.view;
            this.btnView.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnView.Location = new System.Drawing.Point(964, 23);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(32, 33);
            this.btnView.TabIndex = 6;
            this.btnView.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.BtnView_Click);
            this.btnView.Enter += new System.EventHandler(this.BtnView_Enter);
            this.btnView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BtnView_KeyDown);
            this.btnView.Leave += new System.EventHandler(this.BtnView_Leave);
            // 
            // ep_ReturnDC
            // 
            this.ep_ReturnDC.ContainerControl = this;
            // 
            // clmPrint
            // 
            this.clmPrint.HeaderText = "Print";
            this.clmPrint.Image = global::ROMS.Properties.Resources.print16x16__2_;
            this.clmPrint.Name = "clmPrint";
            this.clmPrint.ReadOnly = true;
            this.clmPrint.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmPrint.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // PUR_ReturnDCApprovedList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(1354, 675);
            this.Controls.Add(this.pnlcity);
            this.Controls.Add(this.tsPurchaseInvoiceList);
            this.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "PUR_ReturnDCApprovedList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Return DC Approval";
            this.Load += new System.EventHandler(this.PUR_ReturnDCList_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PUR_ReturnDCList_KeyDown);
            this.tsPurchaseInvoiceList.ResumeLayout(false);
            this.tsPurchaseInvoiceList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdReturnDCList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_SearchGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).EndInit();
            this.pnlcity.ResumeLayout(false);
            this.pnlcity.PerformLayout();
            this.grbFilterBy.ResumeLayout(false);
            this.grbFilterBy.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ep_ReturnDC)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsPurchaseInvoiceList;
        private System.Windows.Forms.ToolStripLabel tspHeader;
        public System.Windows.Forms.DataGridView grdReturnDCList;
        private System.Windows.Forms.Label lblNoRecordsFound;
        private System.Windows.Forms.PictureBox picLoader;
        public System.Windows.Forms.ToolStripSeparator tssEdit;
        public System.Windows.Forms.ToolStripButton tsbEdit;
        public System.Windows.Forms.DataGridView DGV_SearchGrid;
        private System.Windows.Forms.Panel pnlcity;
        private System.Windows.Forms.GroupBox grbFilterBy;
        private System.Windows.Forms.DateTimePicker dpToDate;
        private System.Windows.Forms.TextBox txtSupplier;
        private System.Windows.Forms.Label lblDSupplier;
        private System.Windows.Forms.DateTimePicker dpFromDate;
        private System.Windows.Forms.Label lblInvoicedate;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.ComboBox cmbConcern;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbDCType;
        private System.Windows.Forms.Label lblDCType;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Label lblschedule;
        private System.Windows.Forms.Label lblSupplierCode;
        public System.Windows.Forms.ListView LV_Supplier;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ErrorProvider ep_ReturnDC;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.DataGridViewImageColumn clmPrint;
        private System.Windows.Forms.DataGridViewImageColumn Print;
        public System.Windows.Forms.ToolStripButton tsbDClist;
    }
}