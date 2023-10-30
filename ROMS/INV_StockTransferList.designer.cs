namespace ROMS
{
    partial class INV_StockTransferList
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
            this.tsStockTransferList = new System.Windows.Forms.ToolStrip();
            this.tspHeader = new System.Windows.Forms.ToolStripLabel();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.tssEdit = new System.Windows.Forms.ToolStripSeparator();
            this.tsbEdit = new System.Windows.Forms.ToolStripButton();
            this.tssNew = new System.Windows.Forms.ToolStripSeparator();
            this.tsbNew = new System.Windows.Forms.ToolStripButton();
            this.pnlStockTransferList = new System.Windows.Forms.Panel();
            this.lvProductNamePICode = new System.Windows.Forms.ListView();
            this.lblNoRecordsFound = new System.Windows.Forms.Label();
            this.grdStockTransfer = new System.Windows.Forms.DataGridView();
            this.grbFilterBy = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbConcern = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtProductNamePICode = new System.Windows.Forms.TextBox();
            this.dpTransferToDate = new System.Windows.Forms.DateTimePicker();
            this.dpTrannsferFromDate = new System.Windows.Forms.DateTimePicker();
            this.lblProductNamePICode = new System.Windows.Forms.Label();
            this.lblTransferFromDate = new System.Windows.Forms.Label();
            this.btnView = new System.Windows.Forms.Button();
            this.DGV_SearchGrid = new System.Windows.Forms.DataGridView();
            this.picLoader = new System.Windows.Forms.PictureBox();
            this.txtSLocation = new System.Windows.Forms.TextBox();
            this.txtDLocation = new System.Windows.Forms.TextBox();
            this.lvSLocation = new System.Windows.Forms.ListView();
            this.columnHeader22 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader23 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader24 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvDLocation = new System.Windows.Forms.ListView();
            this.columnHeader28 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader29 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader30 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblSLocation = new System.Windows.Forms.Label();
            this.lblDLocation = new System.Windows.Forms.Label();
            this.tsStockTransferList.SuspendLayout();
            this.pnlStockTransferList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdStockTransfer)).BeginInit();
            this.grbFilterBy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_SearchGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).BeginInit();
            this.SuspendLayout();
            // 
            // tsStockTransferList
            // 
            this.tsStockTransferList.BackColor = System.Drawing.Color.White;
            this.tsStockTransferList.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsStockTransferList.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsStockTransferList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspHeader,
            this.tsbDelete,
            this.tssEdit,
            this.tsbEdit,
            this.tssNew,
            this.tsbNew});
            this.tsStockTransferList.Location = new System.Drawing.Point(0, 0);
            this.tsStockTransferList.Name = "tsStockTransferList";
            this.tsStockTransferList.Size = new System.Drawing.Size(1354, 27);
            this.tsStockTransferList.TabIndex = 35;
            this.tsStockTransferList.Text = "Stock Transfer";
            // 
            // tspHeader
            // 
            this.tspHeader.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tspHeader.Image = global::ROMS.Properties.Resources.bread_crumb;
            this.tspHeader.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tspHeader.Margin = new System.Windows.Forms.Padding(15, 1, 0, 2);
            this.tspHeader.Name = "tspHeader";
            this.tspHeader.Size = new System.Drawing.Size(103, 24);
            this.tspHeader.Text = "Stock Transfer";
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
            // pnlStockTransferList
            // 
            this.pnlStockTransferList.BackColor = System.Drawing.Color.White;
            this.pnlStockTransferList.Controls.Add(this.lvDLocation);
            this.pnlStockTransferList.Controls.Add(this.lvSLocation);
            this.pnlStockTransferList.Controls.Add(this.lvProductNamePICode);
            this.pnlStockTransferList.Controls.Add(this.lblNoRecordsFound);
            this.pnlStockTransferList.Controls.Add(this.grdStockTransfer);
            this.pnlStockTransferList.Controls.Add(this.grbFilterBy);
            this.pnlStockTransferList.Controls.Add(this.DGV_SearchGrid);
            this.pnlStockTransferList.Controls.Add(this.picLoader);
            this.pnlStockTransferList.Location = new System.Drawing.Point(0, 31);
            this.pnlStockTransferList.Name = "pnlStockTransferList";
            this.pnlStockTransferList.Size = new System.Drawing.Size(1354, 643);
            this.pnlStockTransferList.TabIndex = 36;
            // 
            // lvProductNamePICode
            // 
            this.lvProductNamePICode.HideSelection = false;
            this.lvProductNamePICode.Location = new System.Drawing.Point(973, 52);
            this.lvProductNamePICode.Name = "lvProductNamePICode";
            this.lvProductNamePICode.Size = new System.Drawing.Size(281, 95);
            this.lvProductNamePICode.TabIndex = 958823;
            this.lvProductNamePICode.UseCompatibleStateImageBehavior = false;
            this.lvProductNamePICode.Visible = false;
            // 
            // lblNoRecordsFound
            // 
            this.lblNoRecordsFound.AutoSize = true;
            this.lblNoRecordsFound.BackColor = System.Drawing.Color.White;
            this.lblNoRecordsFound.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoRecordsFound.Location = new System.Drawing.Point(614, 382);
            this.lblNoRecordsFound.Name = "lblNoRecordsFound";
            this.lblNoRecordsFound.Size = new System.Drawing.Size(106, 20);
            this.lblNoRecordsFound.TabIndex = 958798;
            this.lblNoRecordsFound.Text = "No Records Found";
            this.lblNoRecordsFound.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // grdStockTransfer
            // 
            this.grdStockTransfer.AllowUserToAddRows = false;
            this.grdStockTransfer.AllowUserToDeleteRows = false;
            this.grdStockTransfer.AllowUserToResizeRows = false;
            this.grdStockTransfer.BackgroundColor = System.Drawing.Color.White;
            this.grdStockTransfer.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(242)))), ((int)(((byte)(213)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdStockTransfer.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdStockTransfer.ColumnHeadersHeight = 30;
            this.grdStockTransfer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdStockTransfer.DefaultCellStyle = dataGridViewCellStyle2;
            this.grdStockTransfer.EnableHeadersVisualStyles = false;
            this.grdStockTransfer.GridColor = System.Drawing.Color.White;
            this.grdStockTransfer.Location = new System.Drawing.Point(3, 130);
            this.grdStockTransfer.Name = "grdStockTransfer";
            this.grdStockTransfer.RowHeadersVisible = false;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.grdStockTransfer.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.grdStockTransfer.RowTemplate.Height = 25;
            this.grdStockTransfer.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.grdStockTransfer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.grdStockTransfer.ShowRowErrors = false;
            this.grdStockTransfer.Size = new System.Drawing.Size(1339, 510);
            this.grdStockTransfer.TabIndex = 958802;
            // 
            // grbFilterBy
            // 
            this.grbFilterBy.Controls.Add(this.lblDLocation);
            this.grbFilterBy.Controls.Add(this.lblSLocation);
            this.grbFilterBy.Controls.Add(this.txtDLocation);
            this.grbFilterBy.Controls.Add(this.txtSLocation);
            this.grbFilterBy.Controls.Add(this.label2);
            this.grbFilterBy.Controls.Add(this.label1);
            this.grbFilterBy.Controls.Add(this.cmbConcern);
            this.grbFilterBy.Controls.Add(this.label12);
            this.grbFilterBy.Controls.Add(this.txtProductNamePICode);
            this.grbFilterBy.Controls.Add(this.dpTransferToDate);
            this.grbFilterBy.Controls.Add(this.dpTrannsferFromDate);
            this.grbFilterBy.Controls.Add(this.lblProductNamePICode);
            this.grbFilterBy.Controls.Add(this.lblTransferFromDate);
            this.grbFilterBy.Controls.Add(this.btnView);
            this.grbFilterBy.Location = new System.Drawing.Point(3, 2);
            this.grbFilterBy.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbFilterBy.Name = "grbFilterBy";
            this.grbFilterBy.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbFilterBy.Size = new System.Drawing.Size(1339, 67);
            this.grbFilterBy.TabIndex = 0;
            this.grbFilterBy.TabStop = false;
            this.grbFilterBy.Text = "Filter By";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(646, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 20);
            this.label2.TabIndex = 1111190;
            this.label2.Text = "Destination";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(477, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 20);
            this.label1.TabIndex = 1111188;
            this.label1.Text = "Source";
            // 
            // cmbConcern
            // 
            this.cmbConcern.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbConcern.FormattingEnabled = true;
            this.cmbConcern.Location = new System.Drawing.Point(66, 23);
            this.cmbConcern.Name = "cmbConcern";
            this.cmbConcern.Size = new System.Drawing.Size(121, 27);
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
            this.label12.Location = new System.Drawing.Point(6, 26);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(54, 20);
            this.label12.TabIndex = 1111186;
            this.label12.Text = "Concern";
            // 
            // txtProductNamePICode
            // 
            this.txtProductNamePICode.Location = new System.Drawing.Point(970, 23);
            this.txtProductNamePICode.Name = "txtProductNamePICode";
            this.txtProductNamePICode.Size = new System.Drawing.Size(281, 27);
            this.txtProductNamePICode.TabIndex = 5;
            this.txtProductNamePICode.Enter += new System.EventHandler(this.TxtProductNamePICode_Enter);
            this.txtProductNamePICode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtProductNamePICode_KeyDown);
            this.txtProductNamePICode.Leave += new System.EventHandler(this.TxtProductNamePICode_Leave);
            // 
            // dpTransferToDate
            // 
            this.dpTransferToDate.CustomFormat = "dd/MM/yyyy";
            this.dpTransferToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpTransferToDate.Location = new System.Drawing.Point(379, 23);
            this.dpTransferToDate.Name = "dpTransferToDate";
            this.dpTransferToDate.Size = new System.Drawing.Size(92, 27);
            this.dpTransferToDate.TabIndex = 2;
            this.dpTransferToDate.Enter += new System.EventHandler(this.DpTransferToDate_Enter);
            this.dpTransferToDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DpTransferToDate_KeyDown);
            this.dpTransferToDate.Leave += new System.EventHandler(this.DpTransferToDate_Leave);
            // 
            // dpTrannsferFromDate
            // 
            this.dpTrannsferFromDate.CustomFormat = "dd/MM/yyyy";
            this.dpTrannsferFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpTrannsferFromDate.Location = new System.Drawing.Point(281, 23);
            this.dpTrannsferFromDate.Name = "dpTrannsferFromDate";
            this.dpTrannsferFromDate.Size = new System.Drawing.Size(92, 27);
            this.dpTrannsferFromDate.TabIndex = 1;
            this.dpTrannsferFromDate.ValueChanged += new System.EventHandler(this.DpTrannsferFromDate_ValueChanged);
            this.dpTrannsferFromDate.Enter += new System.EventHandler(this.DpTrannsferFromDate_Enter);
            this.dpTrannsferFromDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DpTrannsferFromDate_KeyDown);
            this.dpTrannsferFromDate.Leave += new System.EventHandler(this.DpTrannsferFromDate_Leave);
            // 
            // lblProductNamePICode
            // 
            this.lblProductNamePICode.AutoSize = true;
            this.lblProductNamePICode.Location = new System.Drawing.Point(834, 26);
            this.lblProductNamePICode.Name = "lblProductNamePICode";
            this.lblProductNamePICode.Size = new System.Drawing.Size(134, 20);
            this.lblProductNamePICode.TabIndex = 958818;
            this.lblProductNamePICode.Text = "Product Name/P.I Code";
            // 
            // lblTransferFromDate
            // 
            this.lblTransferFromDate.AutoSize = true;
            this.lblTransferFromDate.Location = new System.Drawing.Point(193, 26);
            this.lblTransferFromDate.Name = "lblTransferFromDate";
            this.lblTransferFromDate.Size = new System.Drawing.Size(82, 20);
            this.lblTransferFromDate.TabIndex = 958816;
            this.lblTransferFromDate.Text = "Transfer Date";
            // 
            // btnView
            // 
            this.btnView.Image = global::ROMS.Properties.Resources.view;
            this.btnView.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnView.Location = new System.Drawing.Point(1254, 22);
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
            this.DGV_SearchGrid.Location = new System.Drawing.Point(3, 74);
            this.DGV_SearchGrid.Name = "DGV_SearchGrid";
            this.DGV_SearchGrid.RowHeadersVisible = false;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.DGV_SearchGrid.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.DGV_SearchGrid.RowTemplate.Height = 25;
            this.DGV_SearchGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DGV_SearchGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DGV_SearchGrid.ShowRowErrors = false;
            this.DGV_SearchGrid.Size = new System.Drawing.Size(1339, 56);
            this.DGV_SearchGrid.TabIndex = 958800;
            // 
            // picLoader
            // 
            this.picLoader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picLoader.ErrorImage = null;
            this.picLoader.Image = global::ROMS.Properties.Resources.loader;
            this.picLoader.InitialImage = null;
            this.picLoader.Location = new System.Drawing.Point(1058, 431);
            this.picLoader.Name = "picLoader";
            this.picLoader.Size = new System.Drawing.Size(236, 187);
            this.picLoader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picLoader.TabIndex = 958799;
            this.picLoader.TabStop = false;
            this.picLoader.Visible = false;
            // 
            // txtSLocation
            // 
            this.txtSLocation.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtSLocation.Location = new System.Drawing.Point(529, 23);
            this.txtSLocation.MaxLength = 100;
            this.txtSLocation.Name = "txtSLocation";
            this.txtSLocation.Size = new System.Drawing.Size(111, 27);
            this.txtSLocation.TabIndex = 958824;
            this.txtSLocation.TextChanged += new System.EventHandler(this.TxtSLocation_TextChanged);
            this.txtSLocation.Enter += new System.EventHandler(this.TxtSLocation_Enter);
            this.txtSLocation.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtSLocation_KeyDown);
            this.txtSLocation.Leave += new System.EventHandler(this.TxtSLocation_Leave);
            // 
            // txtDLocation
            // 
            this.txtDLocation.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtDLocation.Location = new System.Drawing.Point(723, 23);
            this.txtDLocation.MaxLength = 100;
            this.txtDLocation.Name = "txtDLocation";
            this.txtDLocation.Size = new System.Drawing.Size(111, 27);
            this.txtDLocation.TabIndex = 1111191;
            this.txtDLocation.TextChanged += new System.EventHandler(this.TxtDLocation_TextChanged);
            this.txtDLocation.Enter += new System.EventHandler(this.TxtDLocation_Enter);
            this.txtDLocation.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtDLocation_KeyDown);
            this.txtDLocation.Leave += new System.EventHandler(this.TxtDLocation_Leave);
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
            this.lvSLocation.Location = new System.Drawing.Point(532, 52);
            this.lvSLocation.Name = "lvSLocation";
            this.lvSLocation.Size = new System.Drawing.Size(252, 115);
            this.lvSLocation.TabIndex = 111111132;
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
            // lvDLocation
            // 
            this.lvDLocation.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader28,
            this.columnHeader29,
            this.columnHeader30});
            this.lvDLocation.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.lvDLocation.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvDLocation.HideSelection = false;
            this.lvDLocation.Location = new System.Drawing.Point(726, 52);
            this.lvDLocation.Name = "lvDLocation";
            this.lvDLocation.Size = new System.Drawing.Size(252, 115);
            this.lvDLocation.TabIndex = 111111141;
            this.lvDLocation.UseCompatibleStateImageBehavior = false;
            this.lvDLocation.View = System.Windows.Forms.View.Details;
            this.lvDLocation.Visible = false;
            this.lvDLocation.DoubleClick += new System.EventHandler(this.LvDLocation_DoubleClick);
            this.lvDLocation.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LvDLocation_KeyDown);
            // 
            // columnHeader28
            // 
            this.columnHeader28.Width = 180;
            // 
            // columnHeader29
            // 
            this.columnHeader29.Width = 120;
            // 
            // columnHeader30
            // 
            this.columnHeader30.Width = 0;
            // 
            // lblSLocation
            // 
            this.lblSLocation.AutoSize = true;
            this.lblSLocation.Location = new System.Drawing.Point(482, 6);
            this.lblSLocation.Name = "lblSLocation";
            this.lblSLocation.Size = new System.Drawing.Size(0, 20);
            this.lblSLocation.TabIndex = 1111192;
            this.lblSLocation.Visible = false;
            // 
            // lblDLocation
            // 
            this.lblDLocation.AutoSize = true;
            this.lblDLocation.Location = new System.Drawing.Point(646, 6);
            this.lblDLocation.Name = "lblDLocation";
            this.lblDLocation.Size = new System.Drawing.Size(0, 20);
            this.lblDLocation.TabIndex = 1111193;
            this.lblDLocation.Visible = false;
            // 
            // INV_StockTransferList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(1354, 675);
            this.Controls.Add(this.pnlStockTransferList);
            this.Controls.Add(this.tsStockTransferList);
            this.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "INV_StockTransferList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Supplier List";
            this.Load += new System.EventHandler(this.INV_StockTransferList_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.INV_StockTransferList_KeyDown);
            this.tsStockTransferList.ResumeLayout(false);
            this.tsStockTransferList.PerformLayout();
            this.pnlStockTransferList.ResumeLayout(false);
            this.pnlStockTransferList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdStockTransfer)).EndInit();
            this.grbFilterBy.ResumeLayout(false);
            this.grbFilterBy.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_SearchGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsStockTransferList;
        private System.Windows.Forms.ToolStripLabel tspHeader;
        public System.Windows.Forms.ToolStripButton tsbDelete;
        public System.Windows.Forms.ToolStripSeparator tssEdit;
        public System.Windows.Forms.ToolStripButton tsbEdit;
        public System.Windows.Forms.ToolStripSeparator tssNew;
        public System.Windows.Forms.ToolStripButton tsbNew;
        private System.Windows.Forms.Panel pnlStockTransferList;
        public System.Windows.Forms.DataGridView DGV_SearchGrid;
        private System.Windows.Forms.Label lblNoRecordsFound;
        private System.Windows.Forms.PictureBox picLoader;
        private System.Windows.Forms.GroupBox grbFilterBy;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Label lblTransferFromDate;
        private System.Windows.Forms.Label lblProductNamePICode;
        private System.Windows.Forms.DateTimePicker dpTransferToDate;
        private System.Windows.Forms.DateTimePicker dpTrannsferFromDate;
        public System.Windows.Forms.DataGridView grdStockTransfer;
        private System.Windows.Forms.TextBox txtProductNamePICode;
        private System.Windows.Forms.ListView lvProductNamePICode;
        private System.Windows.Forms.ComboBox cmbConcern;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSLocation;
        private System.Windows.Forms.TextBox txtDLocation;
        public System.Windows.Forms.ListView lvSLocation;
        private System.Windows.Forms.ColumnHeader columnHeader22;
        private System.Windows.Forms.ColumnHeader columnHeader23;
        private System.Windows.Forms.ColumnHeader columnHeader24;
        public System.Windows.Forms.ListView lvDLocation;
        private System.Windows.Forms.ColumnHeader columnHeader28;
        private System.Windows.Forms.ColumnHeader columnHeader29;
        private System.Windows.Forms.ColumnHeader columnHeader30;
        private System.Windows.Forms.Label lblDLocation;
        private System.Windows.Forms.Label lblSLocation;
    }
}