namespace ROMS
{
    partial class CP_AddressBookList
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
            this.tsSupplierList = new System.Windows.Forms.ToolStrip();
            this.tspHeader = new System.Windows.Forms.ToolStripLabel();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.tssEdit = new System.Windows.Forms.ToolStripSeparator();
            this.tsbEdit = new System.Windows.Forms.ToolStripButton();
            this.tssNew = new System.Windows.Forms.ToolStripSeparator();
            this.tsbNew = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbFilled = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbEmpty = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbEnvelopPrint = new System.Windows.Forms.ToolStripButton();
            this.pnlsupplier = new System.Windows.Forms.Panel();
            this.DGV_SearchGrid = new System.Windows.Forms.DataGridView();
            this.lblSupplierCode = new System.Windows.Forms.Label();
            this.lblNoRecordsFound = new System.Windows.Forms.Label();
            this.grdAddressBookList = new System.Windows.Forms.DataGridView();
            this.clmCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.picLoader = new System.Windows.Forms.PictureBox();
            this.grbFilterBySupplier = new System.Windows.Forms.GroupBox();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblschedule = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.RPTViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.ep_Supplierlist = new System.Windows.Forms.ErrorProvider(this.components);
            this.tsSupplierList.SuspendLayout();
            this.pnlsupplier.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_SearchGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAddressBookList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).BeginInit();
            this.grbFilterBySupplier.SuspendLayout();
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
            this.tsbFilled,
            this.toolStripSeparator3,
            this.tsbEmpty,
            this.toolStripSeparator2,
            this.tsbEnvelopPrint});
            this.tsSupplierList.Location = new System.Drawing.Point(0, 0);
            this.tsSupplierList.Name = "tsSupplierList";
            this.tsSupplierList.Size = new System.Drawing.Size(1354, 27);
            this.tsSupplierList.TabIndex = 35;
            this.tsSupplierList.Text = "Supplier List";
            this.tsSupplierList.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tsSupplierList_ItemClicked);
            // 
            // tspHeader
            // 
            this.tspHeader.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tspHeader.Image = global::ROMS.Properties.Resources.bread_crumb;
            this.tspHeader.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tspHeader.Margin = new System.Windows.Forms.Padding(15, 1, 0, 2);
            this.tspHeader.Name = "tspHeader";
            this.tspHeader.Size = new System.Drawing.Size(121, 24);
            this.tspHeader.Text = "Address Book List";
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
            this.toolStripSeparator1.Click += new System.EventHandler(this.toolStripSeparator1_Click);
            // 
            // tsbFilled
            // 
            this.tsbFilled.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbFilled.Image = global::ROMS.Properties.Resources.print16;
            this.tsbFilled.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbFilled.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFilled.Margin = new System.Windows.Forms.Padding(0, 1, 10, 2);
            this.tsbFilled.Name = "tsbFilled";
            this.tsbFilled.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tsbFilled.Size = new System.Drawing.Size(57, 24);
            this.tsbFilled.Text = "Filled";
            this.tsbFilled.Click += new System.EventHandler(this.tsbFilled_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator3.Margin = new System.Windows.Forms.Padding(0, 0, 15, 0);
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 27);
            // 
            // tsbEmpty
            // 
            this.tsbEmpty.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbEmpty.Image = global::ROMS.Properties.Resources.print16;
            this.tsbEmpty.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbEmpty.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEmpty.Margin = new System.Windows.Forms.Padding(0, 1, 10, 2);
            this.tsbEmpty.Name = "tsbEmpty";
            this.tsbEmpty.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tsbEmpty.Size = new System.Drawing.Size(63, 24);
            this.tsbEmpty.Text = "Empty";
            this.tsbEmpty.Click += new System.EventHandler(this.tsbEmpty_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator2.Margin = new System.Windows.Forms.Padding(0, 0, 15, 0);
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
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
            this.pnlsupplier.Controls.Add(this.DGV_SearchGrid);
            this.pnlsupplier.Controls.Add(this.lblSupplierCode);
            this.pnlsupplier.Controls.Add(this.lblNoRecordsFound);
            this.pnlsupplier.Controls.Add(this.grdAddressBookList);
            this.pnlsupplier.Controls.Add(this.picLoader);
            this.pnlsupplier.Controls.Add(this.grbFilterBySupplier);
            this.pnlsupplier.Controls.Add(this.RPTViewer);
            this.pnlsupplier.Location = new System.Drawing.Point(0, 31);
            this.pnlsupplier.Name = "pnlsupplier";
            this.pnlsupplier.Size = new System.Drawing.Size(1354, 641);
            this.pnlsupplier.TabIndex = 36;
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
            // grdAddressBookList
            // 
            this.grdAddressBookList.AllowUserToAddRows = false;
            this.grdAddressBookList.AllowUserToDeleteRows = false;
            this.grdAddressBookList.AllowUserToResizeColumns = false;
            this.grdAddressBookList.AllowUserToResizeRows = false;
            this.grdAddressBookList.BackgroundColor = System.Drawing.Color.White;
            this.grdAddressBookList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.grdAddressBookList.ColumnHeadersHeight = 30;
            this.grdAddressBookList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdAddressBookList.ColumnHeadersVisible = false;
            this.grdAddressBookList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmCheck});
            this.grdAddressBookList.EnableHeadersVisualStyles = false;
            this.grdAddressBookList.GridColor = System.Drawing.Color.White;
            this.grdAddressBookList.Location = new System.Drawing.Point(3, 130);
            this.grdAddressBookList.Name = "grdAddressBookList";
            this.grdAddressBookList.RowHeadersVisible = false;
            this.grdAddressBookList.RowHeadersWidth = 51;
            this.grdAddressBookList.RowTemplate.Height = 25;
            this.grdAddressBookList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdAddressBookList.Size = new System.Drawing.Size(1348, 501);
            this.grdAddressBookList.TabIndex = 958797;
            this.grdAddressBookList.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.GrdSupplierList_CellBeginEdit);
            this.grdAddressBookList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdAddressBookList_CellContentClick);
            this.grdAddressBookList.CurrentCellDirtyStateChanged += new System.EventHandler(this.GrdSupplierList_CurrentCellDirtyStateChanged);
            this.grdAddressBookList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.GrdSupplierList_DataBindingComplete);
            this.grdAddressBookList.Scroll += new System.Windows.Forms.ScrollEventHandler(this.GrdSupplierList_Scroll);
            this.grdAddressBookList.DoubleClick += new System.EventHandler(this.GrdSupplierList_DoubleClick);
            this.grdAddressBookList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GrdSupplierList_KeyDown);
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
            this.grbFilterBySupplier.Controls.Add(this.cmbType);
            this.grbFilterBySupplier.Controls.Add(this.label1);
            this.grbFilterBySupplier.Controls.Add(this.lblschedule);
            this.grbFilterBySupplier.Controls.Add(this.cmbStatus);
            this.grbFilterBySupplier.Controls.Add(this.lblStatus);
            this.grbFilterBySupplier.Controls.Add(this.btnExport);
            this.grbFilterBySupplier.Controls.Add(this.btnView);
            this.grbFilterBySupplier.Location = new System.Drawing.Point(3, 1);
            this.grbFilterBySupplier.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbFilterBySupplier.Name = "grbFilterBySupplier";
            this.grbFilterBySupplier.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbFilterBySupplier.Size = new System.Drawing.Size(1344, 67);
            this.grbFilterBySupplier.TabIndex = 958801;
            this.grbFilterBySupplier.TabStop = false;
            this.grbFilterBySupplier.Text = "Filter By";
            this.grbFilterBySupplier.Enter += new System.EventHandler(this.grbFilterBySupplier_Enter);
            // 
            // cmbType
            // 
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(54, 26);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(108, 27);
            this.cmbType.TabIndex = 0;
            this.cmbType.Enter += new System.EventHandler(this.cmbType_Enter);
            this.cmbType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbType_KeyDown);
            this.cmbType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbType_KeyPress);
            this.cmbType.Leave += new System.EventHandler(this.cmbType_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 20);
            this.label1.TabIndex = 958807;
            this.label1.Text = "Type";
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
            this.cmbStatus.Location = new System.Drawing.Point(223, 26);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(131, 27);
            this.cmbStatus.TabIndex = 1;
            this.cmbStatus.SelectedIndexChanged += new System.EventHandler(this.CmbStatus_SelectedIndexChanged);
            this.cmbStatus.Enter += new System.EventHandler(this.CmbStatus_Enter);
            this.cmbStatus.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbStatus_KeyDown);
            this.cmbStatus.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbStatus_KeyPress);
            this.cmbStatus.Leave += new System.EventHandler(this.CmbStatus_Leave);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(172, 29);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(45, 20);
            this.lblStatus.TabIndex = 958804;
            this.lblStatus.Text = "Status";
            // 
            // btnExport
            // 
            this.btnExport.Image = global::ROMS.Properties.Resources.excel;
            this.btnExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExport.Location = new System.Drawing.Point(445, 25);
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
            this.btnView.Location = new System.Drawing.Point(362, 25);
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
            // CP_AddressBookList
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
            this.Name = "CP_AddressBookList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Supplier";
            this.Load += new System.EventHandler(this.CP_Supplierlist_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CP_Supplierlist_KeyDown);
            this.tsSupplierList.ResumeLayout(false);
            this.tsSupplierList.PerformLayout();
            this.pnlsupplier.ResumeLayout(false);
            this.pnlsupplier.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_SearchGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAddressBookList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).EndInit();
            this.grbFilterBySupplier.ResumeLayout(false);
            this.grbFilterBySupplier.PerformLayout();
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
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblSupplierCode;
        public System.Windows.Forms.DataGridView grdAddressBookList;
        public System.Windows.Forms.DataGridView DGV_SearchGrid;
        private System.Windows.Forms.ErrorProvider ep_Supplierlist;
        private System.Windows.Forms.Label lblschedule;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer RPTViewer;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clmCheck;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        public System.Windows.Forms.ToolStripButton tsbEnvelopPrint;
        public System.Windows.Forms.ToolStripButton tsbFilled;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        public System.Windows.Forms.ToolStripButton tsbEmpty;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Label label1;
    }
}