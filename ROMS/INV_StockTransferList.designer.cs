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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.dgvStockTransferList = new System.Windows.Forms.DataGridView();
            this.grbFilterBy = new System.Windows.Forms.GroupBox();
            this.txtProductNamePICode = new System.Windows.Forms.TextBox();
            this.dpTransferToDate = new System.Windows.Forms.DateTimePicker();
            this.dpTrannsferFromDate = new System.Windows.Forms.DateTimePicker();
            this.lblProductNamePICode = new System.Windows.Forms.Label();
            this.lblTransferFromDate = new System.Windows.Forms.Label();
            this.btnView = new System.Windows.Forms.Button();
            this.DGV_SearchGrid = new System.Windows.Forms.DataGridView();
            this.picLoader = new System.Windows.Forms.PictureBox();
            this.cmbConcern = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmdsno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmdtransferdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTransferNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmsource = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmdestination = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmdsalename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTotalQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tsStockTransferList.SuspendLayout();
            this.pnlStockTransferList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockTransferList)).BeginInit();
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
            this.tsStockTransferList.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.TsStockTransferList_ItemClicked);
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
            // pnlStockTransferList
            // 
            this.pnlStockTransferList.BackColor = System.Drawing.Color.White;
            this.pnlStockTransferList.Controls.Add(this.lvProductNamePICode);
            this.pnlStockTransferList.Controls.Add(this.lblNoRecordsFound);
            this.pnlStockTransferList.Controls.Add(this.dgvStockTransferList);
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
            this.lvProductNamePICode.Location = new System.Drawing.Point(613, 55);
            this.lvProductNamePICode.Name = "lvProductNamePICode";
            this.lvProductNamePICode.Size = new System.Drawing.Size(340, 95);
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
            // dgvStockTransferList
            // 
            this.dgvStockTransferList.AllowUserToAddRows = false;
            this.dgvStockTransferList.AllowUserToDeleteRows = false;
            this.dgvStockTransferList.AllowUserToResizeRows = false;
            this.dgvStockTransferList.BackgroundColor = System.Drawing.Color.White;
            this.dgvStockTransferList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle13.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(242)))), ((int)(((byte)(213)))));
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvStockTransferList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.dgvStockTransferList.ColumnHeadersHeight = 30;
            this.dgvStockTransferList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvStockTransferList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.Column1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn5,
            this.Column2,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.Column4});
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvStockTransferList.DefaultCellStyle = dataGridViewCellStyle14;
            this.dgvStockTransferList.EnableHeadersVisualStyles = false;
            this.dgvStockTransferList.GridColor = System.Drawing.Color.White;
            this.dgvStockTransferList.Location = new System.Drawing.Point(3, 130);
            this.dgvStockTransferList.Name = "dgvStockTransferList";
            this.dgvStockTransferList.RowHeadersVisible = false;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvStockTransferList.RowsDefaultCellStyle = dataGridViewCellStyle15;
            this.dgvStockTransferList.RowTemplate.Height = 25;
            this.dgvStockTransferList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvStockTransferList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvStockTransferList.ShowRowErrors = false;
            this.dgvStockTransferList.Size = new System.Drawing.Size(1339, 493);
            this.dgvStockTransferList.TabIndex = 958802;
            // 
            // grbFilterBy
            // 
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
            this.grbFilterBy.TabIndex = 958801;
            this.grbFilterBy.TabStop = false;
            this.grbFilterBy.Text = "Filter By";
            // 
            // txtProductNamePICode
            // 
            this.txtProductNamePICode.Location = new System.Drawing.Point(613, 23);
            this.txtProductNamePICode.Name = "txtProductNamePICode";
            this.txtProductNamePICode.Size = new System.Drawing.Size(340, 27);
            this.txtProductNamePICode.TabIndex = 958822;
            // 
            // dpTransferToDate
            // 
            this.dpTransferToDate.CustomFormat = "dd/MM/yyyy";
            this.dpTransferToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpTransferToDate.Location = new System.Drawing.Point(383, 23);
            this.dpTransferToDate.Name = "dpTransferToDate";
            this.dpTransferToDate.Size = new System.Drawing.Size(92, 27);
            this.dpTransferToDate.TabIndex = 958821;
            // 
            // dpTrannsferFromDate
            // 
            this.dpTrannsferFromDate.CustomFormat = "dd/MM/yyyy";
            this.dpTrannsferFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpTrannsferFromDate.Location = new System.Drawing.Point(289, 23);
            this.dpTrannsferFromDate.Name = "dpTrannsferFromDate";
            this.dpTrannsferFromDate.Size = new System.Drawing.Size(92, 27);
            this.dpTrannsferFromDate.TabIndex = 958820;
            // 
            // lblProductNamePICode
            // 
            this.lblProductNamePICode.AutoSize = true;
            this.lblProductNamePICode.Location = new System.Drawing.Point(477, 26);
            this.lblProductNamePICode.Name = "lblProductNamePICode";
            this.lblProductNamePICode.Size = new System.Drawing.Size(134, 20);
            this.lblProductNamePICode.TabIndex = 958818;
            this.lblProductNamePICode.Text = "Product Name/P.I Code";
            // 
            // lblTransferFromDate
            // 
            this.lblTransferFromDate.AutoSize = true;
            this.lblTransferFromDate.Location = new System.Drawing.Point(205, 26);
            this.lblTransferFromDate.Name = "lblTransferFromDate";
            this.lblTransferFromDate.Size = new System.Drawing.Size(82, 20);
            this.lblTransferFromDate.TabIndex = 958816;
            this.lblTransferFromDate.Text = "Transfer Date";
            // 
            // btnView
            // 
            this.btnView.Image = global::ROMS.Properties.Resources.view;
            this.btnView.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnView.Location = new System.Drawing.Point(955, 22);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(75, 29);
            this.btnView.TabIndex = 4;
            this.btnView.Text = "View";
            this.btnView.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnView.UseVisualStyleBackColor = true;
            // 
            // DGV_SearchGrid
            // 
            this.DGV_SearchGrid.AllowUserToAddRows = false;
            this.DGV_SearchGrid.AllowUserToDeleteRows = false;
            this.DGV_SearchGrid.AllowUserToResizeRows = false;
            this.DGV_SearchGrid.BackgroundColor = System.Drawing.Color.White;
            this.DGV_SearchGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle16.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle16.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(242)))), ((int)(((byte)(213)))));
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_SearchGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle16;
            this.DGV_SearchGrid.ColumnHeadersHeight = 30;
            this.DGV_SearchGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGV_SearchGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmdsno,
            this.Column3,
            this.clmdtransferdate,
            this.clmTransferNo,
            this.clmsource,
            this.clmdestination,
            this.clmdsalename,
            this.clmTotalQty,
            this.Column5});
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle17.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV_SearchGrid.DefaultCellStyle = dataGridViewCellStyle17;
            this.DGV_SearchGrid.EnableHeadersVisualStyles = false;
            this.DGV_SearchGrid.GridColor = System.Drawing.Color.White;
            this.DGV_SearchGrid.Location = new System.Drawing.Point(3, 74);
            this.DGV_SearchGrid.Name = "DGV_SearchGrid";
            this.DGV_SearchGrid.RowHeadersVisible = false;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.Color.Black;
            this.DGV_SearchGrid.RowsDefaultCellStyle = dataGridViewCellStyle18;
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
            // cmbConcern
            // 
            this.cmbConcern.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbConcern.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbConcern.FormattingEnabled = true;
            this.cmbConcern.Location = new System.Drawing.Point(82, 23);
            this.cmbConcern.Name = "cmbConcern";
            this.cmbConcern.Size = new System.Drawing.Size(121, 27);
            this.cmbConcern.TabIndex = 1111185;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(26, 26);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(54, 20);
            this.label12.TabIndex = 1111186;
            this.label12.Text = "Concern";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "S.No.";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Concern";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Transfer Date";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Transfer No.";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Source";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 150;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Destination";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 150;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "Total Products";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "Created by";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Width = 200;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Status";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // clmdsno
            // 
            this.clmdsno.HeaderText = "S.No.";
            this.clmdsno.Name = "clmdsno";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Concern";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // clmdtransferdate
            // 
            this.clmdtransferdate.HeaderText = "Transfer Date";
            this.clmdtransferdate.Name = "clmdtransferdate";
            // 
            // clmTransferNo
            // 
            this.clmTransferNo.HeaderText = "Transfer No.";
            this.clmTransferNo.Name = "clmTransferNo";
            // 
            // clmsource
            // 
            this.clmsource.HeaderText = "Source";
            this.clmsource.Name = "clmsource";
            this.clmsource.Width = 150;
            // 
            // clmdestination
            // 
            this.clmdestination.HeaderText = "Destination";
            this.clmdestination.Name = "clmdestination";
            this.clmdestination.Width = 150;
            // 
            // clmdsalename
            // 
            this.clmdsalename.HeaderText = "Total Products";
            this.clmdsalename.Name = "clmdsalename";
            // 
            // clmTotalQty
            // 
            this.clmTotalQty.HeaderText = "Created By";
            this.clmTotalQty.Name = "clmTotalQty";
            this.clmTotalQty.Width = 200;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Status";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
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
            this.Load += new System.EventHandler(this.CP_Supplierlist_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CP_Supplierlist_KeyDown);
            this.tsStockTransferList.ResumeLayout(false);
            this.tsStockTransferList.PerformLayout();
            this.pnlStockTransferList.ResumeLayout(false);
            this.pnlStockTransferList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockTransferList)).EndInit();
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
        public System.Windows.Forms.DataGridView dgvStockTransferList;
        private System.Windows.Forms.TextBox txtProductNamePICode;
        private System.Windows.Forms.ListView lvProductNamePICode;
        private System.Windows.Forms.ComboBox cmbConcern;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmdsno;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmdtransferdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTransferNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmsource;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmdestination;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmdsalename;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTotalQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
    }
}