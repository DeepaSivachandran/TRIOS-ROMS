namespace ROMS
{
    partial class INV_SalesInvoiceList
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
            this.tsPurchaseInvoiceList = new System.Windows.Forms.ToolStrip();
            this.tspHeader = new System.Windows.Forms.ToolStripLabel();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.tssEdit = new System.Windows.Forms.ToolStripSeparator();
            this.tsbEdit = new System.Windows.Forms.ToolStripButton();
            this.tssNew = new System.Windows.Forms.ToolStripSeparator();
            this.tsbNew = new System.Windows.Forms.ToolStripButton();
            this.grdCityList = new System.Windows.Forms.DataGridView();
            this.clmsno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmcompanyname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmInvoiceNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clminvoiceDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnoofproducts = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblNoRecordsFound = new System.Windows.Forms.Label();
            this.DGV_SearchGrid = new System.Windows.Forms.DataGridView();
            this.clmdsno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmdcompanyname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDInvoiceNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDInvoiceDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDNoofProducts = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.picLoader = new System.Windows.Forms.PictureBox();
            this.pnlcity = new System.Windows.Forms.Panel();
            this.grbFilterBy = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblTo = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.txtDay = new System.Windows.Forms.TextBox();
            this.lblDSupplier = new System.Windows.Forms.Label();
            this.dtpoutwarddate = new System.Windows.Forms.DateTimePicker();
            this.lblInvoicedate = new System.Windows.Forms.Label();
            this.btnView = new System.Windows.Forms.Button();
            this.tsPurchaseInvoiceList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCityList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_SearchGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).BeginInit();
            this.pnlcity.SuspendLayout();
            this.grbFilterBy.SuspendLayout();
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
            this.tsbDelete,
            this.tssEdit,
            this.tsbEdit,
            this.tssNew,
            this.tsbNew});
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
            this.tspHeader.Size = new System.Drawing.Size(217, 24);
            this.tspHeader.Text = "Sales Invoice for Damaged Products";
            // 
            // tsbDelete
            // 
            this.tsbDelete.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbDelete.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.tsbEdit.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsbEdit.Image = global::ROMS.Properties.Resources.Edit;
            this.tsbEdit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEdit.Margin = new System.Windows.Forms.Padding(0, 1, 15, 2);
            this.tsbEdit.Name = "tsbEdit";
            this.tsbEdit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tsbEdit.Size = new System.Drawing.Size(50, 24);
            this.tsbEdit.Text = "&Edit";
            this.tsbEdit.Click += new System.EventHandler(this.TsbEdit_Click_1);
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
            this.tsbNew.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsbNew.Image = global::ROMS.Properties.Resources.New;
            this.tsbNew.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNew.Margin = new System.Windows.Forms.Padding(0, 1, 10, 2);
            this.tsbNew.Name = "tsbNew";
            this.tsbNew.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tsbNew.Size = new System.Drawing.Size(52, 24);
            this.tsbNew.Text = "&New";
            this.tsbNew.Click += new System.EventHandler(this.TsbNew_Click_1);
            // 
            // grdCityList
            // 
            this.grdCityList.AllowUserToAddRows = false;
            this.grdCityList.AllowUserToDeleteRows = false;
            this.grdCityList.AllowUserToResizeColumns = false;
            this.grdCityList.AllowUserToResizeRows = false;
            this.grdCityList.BackgroundColor = System.Drawing.Color.White;
            this.grdCityList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(242)))), ((int)(((byte)(213)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdCityList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.grdCityList.ColumnHeadersHeight = 30;
            this.grdCityList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdCityList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmsno,
            this.clmcompanyname,
            this.clmInvoiceNo,
            this.clminvoiceDate,
            this.clmnoofproducts,
            this.clmStatus});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdCityList.DefaultCellStyle = dataGridViewCellStyle8;
            this.grdCityList.EnableHeadersVisualStyles = false;
            this.grdCityList.GridColor = System.Drawing.Color.White;
            this.grdCityList.Location = new System.Drawing.Point(12, 141);
            this.grdCityList.Name = "grdCityList";
            this.grdCityList.ReadOnly = true;
            this.grdCityList.RowHeadersVisible = false;
            this.grdCityList.RowHeadersWidth = 100;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.White;
            this.grdCityList.RowsDefaultCellStyle = dataGridViewCellStyle9;
            this.grdCityList.RowTemplate.Height = 25;
            this.grdCityList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdCityList.Size = new System.Drawing.Size(1329, 488);
            this.grdCityList.TabIndex = 1;
            // 
            // clmsno
            // 
            this.clmsno.HeaderText = "S.No.";
            this.clmsno.MinimumWidth = 6;
            this.clmsno.Name = "clmsno";
            this.clmsno.ReadOnly = true;
            this.clmsno.Width = 125;
            // 
            // clmcompanyname
            // 
            this.clmcompanyname.HeaderText = "Supplier";
            this.clmcompanyname.MinimumWidth = 6;
            this.clmcompanyname.Name = "clmcompanyname";
            this.clmcompanyname.ReadOnly = true;
            this.clmcompanyname.Width = 200;
            // 
            // clmInvoiceNo
            // 
            this.clmInvoiceNo.HeaderText = "Invoice No.";
            this.clmInvoiceNo.Name = "clmInvoiceNo";
            this.clmInvoiceNo.ReadOnly = true;
            this.clmInvoiceNo.Width = 200;
            // 
            // clminvoiceDate
            // 
            this.clminvoiceDate.HeaderText = "Invoice Date";
            this.clminvoiceDate.Name = "clminvoiceDate";
            this.clminvoiceDate.ReadOnly = true;
            // 
            // clmnoofproducts
            // 
            this.clmnoofproducts.HeaderText = "No.of Products";
            this.clmnoofproducts.Name = "clmnoofproducts";
            this.clmnoofproducts.ReadOnly = true;
            // 
            // clmStatus
            // 
            this.clmStatus.HeaderText = "Status";
            this.clmStatus.Name = "clmStatus";
            this.clmStatus.ReadOnly = true;
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
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(242)))), ((int)(((byte)(213)))));
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_SearchGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.DGV_SearchGrid.ColumnHeadersHeight = 30;
            this.DGV_SearchGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGV_SearchGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmdsno,
            this.clmdcompanyname,
            this.clmDInvoiceNo,
            this.clmDInvoiceDate,
            this.clmDNoofProducts,
            this.clmDStatus});
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV_SearchGrid.DefaultCellStyle = dataGridViewCellStyle11;
            this.DGV_SearchGrid.EnableHeadersVisualStyles = false;
            this.DGV_SearchGrid.GridColor = System.Drawing.Color.White;
            this.DGV_SearchGrid.Location = new System.Drawing.Point(12, 85);
            this.DGV_SearchGrid.Name = "DGV_SearchGrid";
            this.DGV_SearchGrid.RowHeadersVisible = false;
            this.DGV_SearchGrid.RowHeadersWidth = 70;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.Black;
            this.DGV_SearchGrid.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.DGV_SearchGrid.RowTemplate.Height = 25;
            this.DGV_SearchGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DGV_SearchGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DGV_SearchGrid.ShowRowErrors = false;
            this.DGV_SearchGrid.Size = new System.Drawing.Size(1329, 56);
            this.DGV_SearchGrid.TabIndex = 958796;
            // 
            // clmdsno
            // 
            this.clmdsno.HeaderText = "S.No.";
            this.clmdsno.MinimumWidth = 6;
            this.clmdsno.Name = "clmdsno";
            this.clmdsno.Width = 125;
            // 
            // clmdcompanyname
            // 
            this.clmdcompanyname.HeaderText = "Supplier";
            this.clmdcompanyname.MinimumWidth = 6;
            this.clmdcompanyname.Name = "clmdcompanyname";
            this.clmdcompanyname.Width = 200;
            // 
            // clmDInvoiceNo
            // 
            this.clmDInvoiceNo.HeaderText = "Invoice No.";
            this.clmDInvoiceNo.Name = "clmDInvoiceNo";
            this.clmDInvoiceNo.Width = 200;
            // 
            // clmDInvoiceDate
            // 
            this.clmDInvoiceDate.HeaderText = "Invoice Date";
            this.clmDInvoiceDate.Name = "clmDInvoiceDate";
            // 
            // clmDNoofProducts
            // 
            this.clmDNoofProducts.HeaderText = "No.of Products";
            this.clmDNoofProducts.Name = "clmDNoofProducts";
            // 
            // clmDStatus
            // 
            this.clmDStatus.HeaderText = "Status";
            this.clmDStatus.Name = "clmDStatus";
            // 
            // picLoader
            // 
            this.picLoader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picLoader.ErrorImage = null;
            this.picLoader.Image = global::ROMS.Properties.Resources.loader;
            this.picLoader.InitialImage = null;
            this.picLoader.Location = new System.Drawing.Point(12, 11);
            this.picLoader.Name = "picLoader";
            this.picLoader.Size = new System.Drawing.Size(1329, 619);
            this.picLoader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picLoader.TabIndex = 958787;
            this.picLoader.TabStop = false;
            this.picLoader.Visible = false;
            // 
            // pnlcity
            // 
            this.pnlcity.BackColor = System.Drawing.Color.White;
            this.pnlcity.Controls.Add(this.grbFilterBy);
            this.pnlcity.Controls.Add(this.lblNoRecordsFound);
            this.pnlcity.Controls.Add(this.DGV_SearchGrid);
            this.pnlcity.Controls.Add(this.grdCityList);
            this.pnlcity.Controls.Add(this.picLoader);
            this.pnlcity.Location = new System.Drawing.Point(0, 40);
            this.pnlcity.Name = "pnlcity";
            this.pnlcity.Size = new System.Drawing.Size(1354, 637);
            this.pnlcity.TabIndex = 958797;
            // 
            // grbFilterBy
            // 
            this.grbFilterBy.Controls.Add(this.textBox1);
            this.grbFilterBy.Controls.Add(this.lblStatus);
            this.grbFilterBy.Controls.Add(this.lblTo);
            this.grbFilterBy.Controls.Add(this.dateTimePicker1);
            this.grbFilterBy.Controls.Add(this.txtDay);
            this.grbFilterBy.Controls.Add(this.lblDSupplier);
            this.grbFilterBy.Controls.Add(this.dtpoutwarddate);
            this.grbFilterBy.Controls.Add(this.lblInvoicedate);
            this.grbFilterBy.Controls.Add(this.btnView);
            this.grbFilterBy.Location = new System.Drawing.Point(12, 11);
            this.grbFilterBy.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbFilterBy.Name = "grbFilterBy";
            this.grbFilterBy.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbFilterBy.Size = new System.Drawing.Size(975, 67);
            this.grbFilterBy.TabIndex = 958801;
            this.grbFilterBy.TabStop = false;
            this.grbFilterBy.Text = "Filter By ";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(757, 25);
            this.textBox1.MaxLength = 2;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(105, 27);
            this.textBox1.TabIndex = 958817;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(709, 28);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(45, 20);
            this.lblStatus.TabIndex = 958816;
            this.lblStatus.Text = "Status";
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(239, 28);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(21, 20);
            this.lblTo.TabIndex = 958815;
            this.lblTo.Text = "To";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(264, 25);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(104, 27);
            this.dateTimePicker1.TabIndex = 958814;
            // 
            // txtDay
            // 
            this.txtDay.Location = new System.Drawing.Point(437, 25);
            this.txtDay.MaxLength = 2;
            this.txtDay.Name = "txtDay";
            this.txtDay.Size = new System.Drawing.Size(264, 27);
            this.txtDay.TabIndex = 958812;
            // 
            // lblDSupplier
            // 
            this.lblDSupplier.AutoSize = true;
            this.lblDSupplier.Location = new System.Drawing.Point(380, 28);
            this.lblDSupplier.Name = "lblDSupplier";
            this.lblDSupplier.Size = new System.Drawing.Size(54, 20);
            this.lblDSupplier.TabIndex = 958811;
            this.lblDSupplier.Text = "Supplier";
            // 
            // dtpoutwarddate
            // 
            this.dtpoutwarddate.CustomFormat = "dd/MM/yyyy";
            this.dtpoutwarddate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpoutwarddate.Location = new System.Drawing.Point(131, 25);
            this.dtpoutwarddate.Name = "dtpoutwarddate";
            this.dtpoutwarddate.Size = new System.Drawing.Size(104, 27);
            this.dtpoutwarddate.TabIndex = 93;
            // 
            // lblInvoicedate
            // 
            this.lblInvoicedate.AutoSize = true;
            this.lblInvoicedate.Location = new System.Drawing.Point(23, 28);
            this.lblInvoicedate.Name = "lblInvoicedate";
            this.lblInvoicedate.Size = new System.Drawing.Size(105, 20);
            this.lblInvoicedate.TabIndex = 92;
            this.lblInvoicedate.Text = "Invoice Date From";
            // 
            // btnView
            // 
            this.btnView.Image = global::ROMS.Properties.Resources.view;
            this.btnView.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnView.Location = new System.Drawing.Point(875, 24);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(75, 29);
            this.btnView.TabIndex = 4;
            this.btnView.Text = "View";
            this.btnView.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnView.UseVisualStyleBackColor = true;
            // 
            // INV_SalesInvoiceList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(1354, 675);
            this.Controls.Add(this.pnlcity);
            this.Controls.Add(this.tsPurchaseInvoiceList);
            this.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "INV_SalesInvoiceList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sales Invoice";
            this.tsPurchaseInvoiceList.ResumeLayout(false);
            this.tsPurchaseInvoiceList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCityList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_SearchGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).EndInit();
            this.pnlcity.ResumeLayout(false);
            this.pnlcity.PerformLayout();
            this.grbFilterBy.ResumeLayout(false);
            this.grbFilterBy.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsPurchaseInvoiceList;
        private System.Windows.Forms.ToolStripLabel tspHeader;
        public System.Windows.Forms.DataGridView grdCityList;
        private System.Windows.Forms.Label lblNoRecordsFound;
        private System.Windows.Forms.PictureBox picLoader;
        public System.Windows.Forms.ToolStripButton tsbDelete;
        public System.Windows.Forms.ToolStripSeparator tssEdit;
        public System.Windows.Forms.ToolStripButton tsbEdit;
        public System.Windows.Forms.ToolStripSeparator tssNew;
        public System.Windows.Forms.ToolStripButton tsbNew;
        public System.Windows.Forms.DataGridView DGV_SearchGrid;
        private System.Windows.Forms.Panel pnlcity;
        private System.Windows.Forms.GroupBox grbFilterBy;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox txtDay;
        private System.Windows.Forms.Label lblDSupplier;
        private System.Windows.Forms.DateTimePicker dtpoutwarddate;
        private System.Windows.Forms.Label lblInvoicedate;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmsno;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmcompanyname;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmInvoiceNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clminvoiceDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnoofproducts;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmdsno;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmdcompanyname;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDInvoiceNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDInvoiceDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDNoofProducts;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDStatus;
    }
}