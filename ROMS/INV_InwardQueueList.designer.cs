namespace ROMS
{
    partial class INV_InwardQueueList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle43 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle44 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle45 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle46 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle47 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle48 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tsInwardList = new System.Windows.Forms.ToolStrip();
            this.tspHeader = new System.Windows.Forms.ToolStripLabel();
            this.tsbEdit = new System.Windows.Forms.ToolStripButton();
            this.pnlinward = new System.Windows.Forms.Panel();
            this.DGV_SearchGrid = new System.Windows.Forms.DataGridView();
            this.clmdsno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmdpurchaseno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmdinvoiceno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmdinvoicedate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmdsuppliername = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmdtotalitems = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmdtotalqty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblNoRecordsFound = new System.Windows.Forms.Label();
            this.grdInwardList = new System.Windows.Forms.DataGridView();
            this.clmsno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmpurchaseno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clminvoiceno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clminvoicedate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmsuppliername = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmtotalitems = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmtotalqty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.picLoader = new System.Windows.Forms.PictureBox();
            this.grbFilterBy = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.txtDay = new System.Windows.Forms.TextBox();
            this.lblDProductNamePicode = new System.Windows.Forms.Label();
            this.dtpoutwarddate = new System.Windows.Forms.DateTimePicker();
            this.lblDGodown = new System.Windows.Forms.Label();
            this.lblinwarddate = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.lblDConcern = new System.Windows.Forms.Label();
            this.btnView = new System.Windows.Forms.Button();
            this.cmbconcern = new System.Windows.Forms.ComboBox();
            this.tsbQue = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsInwardList.SuspendLayout();
            this.pnlinward.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_SearchGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdInwardList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).BeginInit();
            this.grbFilterBy.SuspendLayout();
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
            this.toolStripSeparator1,
            this.tsbEdit});
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
            this.tspHeader.Size = new System.Drawing.Size(219, 24);
            this.tspHeader.Text = "Goods Inward Queue From Purchase";
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
            // pnlinward
            // 
            this.pnlinward.BackColor = System.Drawing.Color.White;
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
            // DGV_SearchGrid
            // 
            this.DGV_SearchGrid.AllowUserToAddRows = false;
            this.DGV_SearchGrid.AllowUserToDeleteRows = false;
            this.DGV_SearchGrid.AllowUserToResizeRows = false;
            this.DGV_SearchGrid.BackgroundColor = System.Drawing.Color.White;
            this.DGV_SearchGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle43.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle43.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle43.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle43.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle43.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle43.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle43.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_SearchGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle43;
            this.DGV_SearchGrid.ColumnHeadersHeight = 30;
            this.DGV_SearchGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGV_SearchGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmdsno,
            this.Column1,
            this.Column2,
            this.Column3,
            this.clmdpurchaseno,
            this.Column4,
            this.clmdinvoiceno,
            this.clmdinvoicedate,
            this.clmdsuppliername,
            this.clmdtotalitems,
            this.Column12,
            this.clmdtotalqty,
            this.Column5});
            dataGridViewCellStyle44.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle44.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle44.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle44.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle44.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle44.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle44.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV_SearchGrid.DefaultCellStyle = dataGridViewCellStyle44;
            this.DGV_SearchGrid.EnableHeadersVisualStyles = false;
            this.DGV_SearchGrid.GridColor = System.Drawing.Color.White;
            this.DGV_SearchGrid.Location = new System.Drawing.Point(3, 81);
            this.DGV_SearchGrid.Name = "DGV_SearchGrid";
            this.DGV_SearchGrid.RowHeadersVisible = false;
            dataGridViewCellStyle45.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle45.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.DGV_SearchGrid.RowsDefaultCellStyle = dataGridViewCellStyle45;
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
            // Column1
            // 
            this.Column1.HeaderText = "Concern";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "GRN No.";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "GRN Date";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // clmdpurchaseno
            // 
            this.clmdpurchaseno.HeaderText = "Voucher No.";
            this.clmdpurchaseno.Name = "clmdpurchaseno";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Voucher Date";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // clmdinvoiceno
            // 
            this.clmdinvoiceno.HeaderText = "Invoice No.";
            this.clmdinvoiceno.Name = "clmdinvoiceno";
            // 
            // clmdinvoicedate
            // 
            this.clmdinvoicedate.HeaderText = "Invoice Date";
            this.clmdinvoicedate.Name = "clmdinvoicedate";
            // 
            // clmdsuppliername
            // 
            this.clmdsuppliername.HeaderText = "Supplier Name";
            this.clmdsuppliername.Name = "clmdsuppliername";
            this.clmdsuppliername.Width = 200;
            // 
            // clmdtotalitems
            // 
            this.clmdtotalitems.HeaderText = "Total Products in Invoice";
            this.clmdtotalitems.Name = "clmdtotalitems";
            this.clmdtotalitems.Width = 150;
            // 
            // Column12
            // 
            this.Column12.HeaderText = "My Products";
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            // 
            // clmdtotalqty
            // 
            this.clmdtotalqty.HeaderText = "Status";
            this.clmdtotalqty.Name = "clmdtotalqty";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Created By";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // lblNoRecordsFound
            // 
            this.lblNoRecordsFound.AutoSize = true;
            this.lblNoRecordsFound.BackColor = System.Drawing.Color.White;
            this.lblNoRecordsFound.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoRecordsFound.Location = new System.Drawing.Point(624, 378);
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
            dataGridViewCellStyle46.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle46.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle46.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle46.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle46.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle46.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle46.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdInwardList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle46;
            this.grdInwardList.ColumnHeadersHeight = 30;
            this.grdInwardList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdInwardList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmsno,
            this.Column6,
            this.Column7,
            this.Column8,
            this.clmpurchaseno,
            this.Column9,
            this.clminvoiceno,
            this.clminvoicedate,
            this.clmsuppliername,
            this.clmtotalitems,
            this.Column11,
            this.clmtotalqty,
            this.Column10});
            dataGridViewCellStyle47.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle47.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle47.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle47.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle47.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle47.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle47.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdInwardList.DefaultCellStyle = dataGridViewCellStyle47;
            this.grdInwardList.EnableHeadersVisualStyles = false;
            this.grdInwardList.GridColor = System.Drawing.Color.White;
            this.grdInwardList.Location = new System.Drawing.Point(3, 137);
            this.grdInwardList.Name = "grdInwardList";
            this.grdInwardList.ReadOnly = true;
            this.grdInwardList.RowHeadersVisible = false;
            dataGridViewCellStyle48.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle48.SelectionForeColor = System.Drawing.Color.White;
            this.grdInwardList.RowsDefaultCellStyle = dataGridViewCellStyle48;
            this.grdInwardList.RowTemplate.Height = 25;
            this.grdInwardList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdInwardList.Size = new System.Drawing.Size(1348, 502);
            this.grdInwardList.TabIndex = 958797;
            // 
            // clmsno
            // 
            this.clmsno.HeaderText = "S.No.";
            this.clmsno.Name = "clmsno";
            this.clmsno.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Concern";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "GRN No.";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "GRN Date";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // clmpurchaseno
            // 
            this.clmpurchaseno.HeaderText = "Voucher No.";
            this.clmpurchaseno.Name = "clmpurchaseno";
            this.clmpurchaseno.ReadOnly = true;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Voucher Date";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            // 
            // clminvoiceno
            // 
            this.clminvoiceno.HeaderText = "Invoice No.";
            this.clminvoiceno.Name = "clminvoiceno";
            this.clminvoiceno.ReadOnly = true;
            // 
            // clminvoicedate
            // 
            this.clminvoicedate.HeaderText = "Invoice Date";
            this.clminvoicedate.Name = "clminvoicedate";
            this.clminvoicedate.ReadOnly = true;
            // 
            // clmsuppliername
            // 
            this.clmsuppliername.HeaderText = "Supplier Name";
            this.clmsuppliername.Name = "clmsuppliername";
            this.clmsuppliername.ReadOnly = true;
            this.clmsuppliername.Width = 200;
            // 
            // clmtotalitems
            // 
            this.clmtotalitems.HeaderText = "Total Products in Invoice";
            this.clmtotalitems.Name = "clmtotalitems";
            this.clmtotalitems.ReadOnly = true;
            this.clmtotalitems.Width = 150;
            // 
            // Column11
            // 
            this.Column11.HeaderText = "My Products";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            // 
            // clmtotalqty
            // 
            this.clmtotalqty.HeaderText = "Status";
            this.clmtotalqty.Name = "clmtotalqty";
            this.clmtotalqty.ReadOnly = true;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "Created By";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
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
            // grbFilterBy
            // 
            this.grbFilterBy.Controls.Add(this.label1);
            this.grbFilterBy.Controls.Add(this.dateTimePicker1);
            this.grbFilterBy.Controls.Add(this.txtDay);
            this.grbFilterBy.Controls.Add(this.lblDProductNamePicode);
            this.grbFilterBy.Controls.Add(this.dtpoutwarddate);
            this.grbFilterBy.Controls.Add(this.lblDGodown);
            this.grbFilterBy.Controls.Add(this.lblinwarddate);
            this.grbFilterBy.Controls.Add(this.comboBox1);
            this.grbFilterBy.Controls.Add(this.lblDConcern);
            this.grbFilterBy.Controls.Add(this.btnView);
            this.grbFilterBy.Controls.Add(this.cmbconcern);
            this.grbFilterBy.Location = new System.Drawing.Point(3, 2);
            this.grbFilterBy.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbFilterBy.Name = "grbFilterBy";
            this.grbFilterBy.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbFilterBy.Size = new System.Drawing.Size(1347, 76);
            this.grbFilterBy.TabIndex = 958802;
            this.grbFilterBy.TabStop = false;
            this.grbFilterBy.Text = "Filter By ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.label1.Location = new System.Drawing.Point(142, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.TabIndex = 958816;
            this.label1.Text = "Transaction Date";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(257, 42);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(104, 27);
            this.dateTimePicker1.TabIndex = 958814;
            // 
            // txtDay
            // 
            this.txtDay.Location = new System.Drawing.Point(497, 42);
            this.txtDay.MaxLength = 2;
            this.txtDay.Name = "txtDay";
            this.txtDay.Size = new System.Drawing.Size(267, 27);
            this.txtDay.TabIndex = 958812;
            // 
            // lblDProductNamePicode
            // 
            this.lblDProductNamePicode.AutoSize = true;
            this.lblDProductNamePicode.Location = new System.Drawing.Point(497, 19);
            this.lblDProductNamePicode.Name = "lblDProductNamePicode";
            this.lblDProductNamePicode.Size = new System.Drawing.Size(134, 20);
            this.lblDProductNamePicode.TabIndex = 958811;
            this.lblDProductNamePicode.Text = "Product Name/P.I Code";
            // 
            // dtpoutwarddate
            // 
            this.dtpoutwarddate.CustomFormat = "dd/MM/yyyy";
            this.dtpoutwarddate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpoutwarddate.Location = new System.Drawing.Point(146, 42);
            this.dtpoutwarddate.Name = "dtpoutwarddate";
            this.dtpoutwarddate.Size = new System.Drawing.Size(104, 27);
            this.dtpoutwarddate.TabIndex = 93;
            // 
            // lblDGodown
            // 
            this.lblDGodown.AutoSize = true;
            this.lblDGodown.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.lblDGodown.Location = new System.Drawing.Point(368, 19);
            this.lblDGodown.Name = "lblDGodown";
            this.lblDGodown.Size = new System.Drawing.Size(87, 20);
            this.lblDGodown.TabIndex = 38;
            this.lblDGodown.Text = "Stock Location";
            // 
            // lblinwarddate
            // 
            this.lblinwarddate.AutoSize = true;
            this.lblinwarddate.Location = new System.Drawing.Point(307, 19);
            this.lblinwarddate.Name = "lblinwarddate";
            this.lblinwarddate.Size = new System.Drawing.Size(0, 20);
            this.lblinwarddate.TabIndex = 92;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(368, 42);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(122, 27);
            this.comboBox1.TabIndex = 37;
            // 
            // lblDConcern
            // 
            this.lblDConcern.AutoSize = true;
            this.lblDConcern.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.lblDConcern.Location = new System.Drawing.Point(26, 19);
            this.lblDConcern.Name = "lblDConcern";
            this.lblDConcern.Size = new System.Drawing.Size(54, 20);
            this.lblDConcern.TabIndex = 36;
            this.lblDConcern.Text = "Concern";
            // 
            // btnView
            // 
            this.btnView.Image = global::ROMS.Properties.Resources.view;
            this.btnView.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnView.Location = new System.Drawing.Point(779, 41);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(75, 29);
            this.btnView.TabIndex = 4;
            this.btnView.Text = "View";
            this.btnView.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnView.UseVisualStyleBackColor = true;
            // 
            // cmbconcern
            // 
            this.cmbconcern.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbconcern.FormattingEnabled = true;
            this.cmbconcern.Location = new System.Drawing.Point(26, 42);
            this.cmbconcern.Name = "cmbconcern";
            this.cmbconcern.Size = new System.Drawing.Size(114, 27);
            this.cmbconcern.TabIndex = 2;
            // 
            // tsbQue
            // 
            this.tsbQue.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbQue.Image = global::ROMS.Properties.Resources.include;
            this.tsbQue.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbQue.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbQue.Margin = new System.Windows.Forms.Padding(0, 1, 15, 2);
            this.tsbQue.Name = "tsbQue";
            this.tsbQue.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tsbQue.Size = new System.Drawing.Size(90, 24);
            this.tsbQue.Text = "Inward List";
            this.tsbQue.Click += new System.EventHandler(this.TsbQue_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator1.Margin = new System.Windows.Forms.Padding(0, 0, 15, 0);
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // INV_InwardQueueList
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
            this.Name = "INV_InwardQueueList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Brand";
            this.Load += new System.EventHandler(this.INV_InwardQueueList_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.INV_InwardQueueList_KeyDown);
            this.tsInwardList.ResumeLayout(false);
            this.tsInwardList.PerformLayout();
            this.pnlinward.ResumeLayout(false);
            this.pnlinward.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_SearchGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdInwardList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).EndInit();
            this.grbFilterBy.ResumeLayout(false);
            this.grbFilterBy.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStripLabel tspHeader;
        public System.Windows.Forms.ToolStripButton tsbEdit;
        private System.Windows.Forms.ToolStrip tsInwardList;
        private System.Windows.Forms.Panel pnlinward;
        public System.Windows.Forms.DataGridView DGV_SearchGrid;
        private System.Windows.Forms.Label lblNoRecordsFound;
        public System.Windows.Forms.DataGridView grdInwardList;
        private System.Windows.Forms.PictureBox picLoader;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmdsno;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmdpurchaseno;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmdinvoiceno;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmdinvoicedate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmdsuppliername;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmdtotalitems;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmdtotalqty;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmsno;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmpurchaseno;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn clminvoiceno;
        private System.Windows.Forms.DataGridViewTextBoxColumn clminvoicedate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmsuppliername;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmtotalitems;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmtotalqty;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.GroupBox grbFilterBy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox txtDay;
        private System.Windows.Forms.Label lblDProductNamePicode;
        private System.Windows.Forms.DateTimePicker dtpoutwarddate;
        private System.Windows.Forms.Label lblDGodown;
        private System.Windows.Forms.Label lblinwarddate;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label lblDConcern;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.ComboBox cmbconcern;
        public System.Windows.Forms.ToolStripButton tsbQue;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}