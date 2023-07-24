namespace ROMS
{
    partial class INV_StockRequestList
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
            this.tsStockRequestList = new System.Windows.Forms.ToolStrip();
            this.tspHeader = new System.Windows.Forms.ToolStripLabel();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.tssEdit = new System.Windows.Forms.ToolStripSeparator();
            this.tsbEdit = new System.Windows.Forms.ToolStripButton();
            this.tssNew = new System.Windows.Forms.ToolStripSeparator();
            this.tsbNew = new System.Windows.Forms.ToolStripButton();
            this.pnlStockRequestList = new System.Windows.Forms.Panel();
            this.DGV__SearchGrid = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grbFilterBy = new System.Windows.Forms.GroupBox();
            this.txtProductNamePICode = new System.Windows.Forms.TextBox();
            this.lblDEProductName = new System.Windows.Forms.Label();
            this.dpEntryToDate = new System.Windows.Forms.DateTimePicker();
            this.lblEntrytoDate = new System.Windows.Forms.Label();
            this.dpFromDate = new System.Windows.Forms.DateTimePicker();
            this.lblEntryFromDate = new System.Windows.Forms.Label();
            this.btnView = new System.Windows.Forms.Button();
            this.lblNoRecordsFound = new System.Windows.Forms.Label();
            this.grdStockRequestList = new System.Windows.Forms.DataGridView();
            this.clmsno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmEntryDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmRequestNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmRequestedQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmReceivedQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.picLoader = new System.Windows.Forms.PictureBox();
            this.tsStockRequestList.SuspendLayout();
            this.pnlStockRequestList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV__SearchGrid)).BeginInit();
            this.grbFilterBy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdStockRequestList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).BeginInit();
            this.SuspendLayout();
            // 
            // tsStockRequestList
            // 
            this.tsStockRequestList.BackColor = System.Drawing.Color.White;
            this.tsStockRequestList.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsStockRequestList.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsStockRequestList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspHeader,
            this.tsbDelete,
            this.tssEdit,
            this.tsbEdit,
            this.tssNew,
            this.tsbNew});
            this.tsStockRequestList.Location = new System.Drawing.Point(0, 0);
            this.tsStockRequestList.Name = "tsStockRequestList";
            this.tsStockRequestList.Size = new System.Drawing.Size(1354, 27);
            this.tsStockRequestList.TabIndex = 35;
            this.tsStockRequestList.Text = "Stock Request";
            // 
            // tspHeader
            // 
            this.tspHeader.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tspHeader.Image = global::ROMS.Properties.Resources.bread_crumb;
            this.tspHeader.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tspHeader.Margin = new System.Windows.Forms.Padding(15, 1, 0, 2);
            this.tspHeader.Name = "tspHeader";
            this.tspHeader.Size = new System.Drawing.Size(103, 24);
            this.tspHeader.Text = "Stock Request";
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
            // pnlStockRequestList
            // 
            this.pnlStockRequestList.BackColor = System.Drawing.Color.White;
            this.pnlStockRequestList.Controls.Add(this.DGV__SearchGrid);
            this.pnlStockRequestList.Controls.Add(this.grbFilterBy);
            this.pnlStockRequestList.Controls.Add(this.lblNoRecordsFound);
            this.pnlStockRequestList.Controls.Add(this.grdStockRequestList);
            this.pnlStockRequestList.Controls.Add(this.picLoader);
            this.pnlStockRequestList.Location = new System.Drawing.Point(0, 28);
            this.pnlStockRequestList.Name = "pnlStockRequestList";
            this.pnlStockRequestList.Size = new System.Drawing.Size(1354, 644);
            this.pnlStockRequestList.TabIndex = 36;
            // 
            // DGV__SearchGrid
            // 
            this.DGV__SearchGrid.AllowUserToAddRows = false;
            this.DGV__SearchGrid.AllowUserToDeleteRows = false;
            this.DGV__SearchGrid.AllowUserToResizeColumns = false;
            this.DGV__SearchGrid.AllowUserToResizeRows = false;
            this.DGV__SearchGrid.BackgroundColor = System.Drawing.Color.White;
            this.DGV__SearchGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(242)))), ((int)(((byte)(213)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV__SearchGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DGV__SearchGrid.ColumnHeadersHeight = 30;
            this.DGV__SearchGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGV__SearchGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV__SearchGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.DGV__SearchGrid.EnableHeadersVisualStyles = false;
            this.DGV__SearchGrid.GridColor = System.Drawing.Color.White;
            this.DGV__SearchGrid.Location = new System.Drawing.Point(13, 96);
            this.DGV__SearchGrid.Name = "DGV__SearchGrid";
            this.DGV__SearchGrid.ReadOnly = true;
            this.DGV__SearchGrid.RowHeadersVisible = false;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.DGV__SearchGrid.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.DGV__SearchGrid.RowTemplate.Height = 25;
            this.DGV__SearchGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV__SearchGrid.Size = new System.Drawing.Size(1329, 56);
            this.DGV__SearchGrid.TabIndex = 958802;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "S.No.";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Entry Date";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Request No";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Request Qty";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Received Qty";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Unit";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "Status";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // grbFilterBy
            // 
            this.grbFilterBy.Controls.Add(this.txtProductNamePICode);
            this.grbFilterBy.Controls.Add(this.lblDEProductName);
            this.grbFilterBy.Controls.Add(this.dpEntryToDate);
            this.grbFilterBy.Controls.Add(this.lblEntrytoDate);
            this.grbFilterBy.Controls.Add(this.dpFromDate);
            this.grbFilterBy.Controls.Add(this.lblEntryFromDate);
            this.grbFilterBy.Controls.Add(this.btnView);
            this.grbFilterBy.Location = new System.Drawing.Point(25, 14);
            this.grbFilterBy.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbFilterBy.Name = "grbFilterBy";
            this.grbFilterBy.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbFilterBy.Size = new System.Drawing.Size(1067, 67);
            this.grbFilterBy.TabIndex = 958801;
            this.grbFilterBy.TabStop = false;
            this.grbFilterBy.Text = "Filter By";
            // 
            // txtProductNamePICode
            // 
            this.txtProductNamePICode.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductNamePICode.Location = new System.Drawing.Point(576, 25);
            this.txtProductNamePICode.MaxLength = 50;
            this.txtProductNamePICode.Name = "txtProductNamePICode";
            this.txtProductNamePICode.Size = new System.Drawing.Size(393, 27);
            this.txtProductNamePICode.TabIndex = 1111158;
            // 
            // lblDEProductName
            // 
            this.lblDEProductName.AutoSize = true;
            this.lblDEProductName.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDEProductName.Location = new System.Drawing.Point(436, 28);
            this.lblDEProductName.Name = "lblDEProductName";
            this.lblDEProductName.Size = new System.Drawing.Size(134, 20);
            this.lblDEProductName.TabIndex = 1111159;
            this.lblDEProductName.Text = "Product Name/P.I Code";
            // 
            // dpEntryToDate
            // 
            this.dpEntryToDate.CustomFormat = "dd/MM/yyyy";
            this.dpEntryToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpEntryToDate.Location = new System.Drawing.Point(323, 25);
            this.dpEntryToDate.Name = "dpEntryToDate";
            this.dpEntryToDate.Size = new System.Drawing.Size(107, 27);
            this.dpEntryToDate.TabIndex = 1111157;
            // 
            // lblEntrytoDate
            // 
            this.lblEntrytoDate.AutoSize = true;
            this.lblEntrytoDate.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEntrytoDate.Location = new System.Drawing.Point(235, 28);
            this.lblEntrytoDate.Name = "lblEntrytoDate";
            this.lblEntrytoDate.Size = new System.Drawing.Size(81, 20);
            this.lblEntrytoDate.TabIndex = 1111156;
            this.lblEntrytoDate.Text = "Entry To Date";
            // 
            // dpFromDate
            // 
            this.dpFromDate.CustomFormat = "dd/MM/yyyy";
            this.dpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpFromDate.Location = new System.Drawing.Point(108, 25);
            this.dpFromDate.Name = "dpFromDate";
            this.dpFromDate.Size = new System.Drawing.Size(107, 27);
            this.dpFromDate.TabIndex = 1111155;
            // 
            // lblEntryFromDate
            // 
            this.lblEntryFromDate.AutoSize = true;
            this.lblEntryFromDate.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEntryFromDate.Location = new System.Drawing.Point(6, 28);
            this.lblEntryFromDate.Name = "lblEntryFromDate";
            this.lblEntryFromDate.Size = new System.Drawing.Size(96, 20);
            this.lblEntryFromDate.TabIndex = 1111154;
            this.lblEntryFromDate.Text = "Entry From Date";
            // 
            // btnView
            // 
            this.btnView.Image = global::ROMS.Properties.Resources.view;
            this.btnView.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnView.Location = new System.Drawing.Point(981, 24);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(75, 29);
            this.btnView.TabIndex = 4;
            this.btnView.Text = "View";
            this.btnView.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnView.UseVisualStyleBackColor = true;
            // 
            // lblNoRecordsFound
            // 
            this.lblNoRecordsFound.AutoSize = true;
            this.lblNoRecordsFound.BackColor = System.Drawing.Color.White;
            this.lblNoRecordsFound.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoRecordsFound.Location = new System.Drawing.Point(624, 380);
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
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(242)))), ((int)(((byte)(213)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdStockRequestList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.grdStockRequestList.ColumnHeadersHeight = 30;
            this.grdStockRequestList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdStockRequestList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmsno,
            this.clmEntryDate,
            this.clmRequestNo,
            this.clmRequestedQty,
            this.clmReceivedQty,
            this.clmUnit,
            this.clmStatus});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdStockRequestList.DefaultCellStyle = dataGridViewCellStyle5;
            this.grdStockRequestList.EnableHeadersVisualStyles = false;
            this.grdStockRequestList.GridColor = System.Drawing.Color.White;
            this.grdStockRequestList.Location = new System.Drawing.Point(13, 152);
            this.grdStockRequestList.Name = "grdStockRequestList";
            this.grdStockRequestList.ReadOnly = true;
            this.grdStockRequestList.RowHeadersVisible = false;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            this.grdStockRequestList.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.grdStockRequestList.RowTemplate.Height = 25;
            this.grdStockRequestList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdStockRequestList.Size = new System.Drawing.Size(1329, 476);
            this.grdStockRequestList.TabIndex = 958797;
            // 
            // clmsno
            // 
            this.clmsno.HeaderText = "S.No.";
            this.clmsno.Name = "clmsno";
            this.clmsno.ReadOnly = true;
            // 
            // clmEntryDate
            // 
            this.clmEntryDate.HeaderText = "Entry Date";
            this.clmEntryDate.Name = "clmEntryDate";
            this.clmEntryDate.ReadOnly = true;
            // 
            // clmRequestNo
            // 
            this.clmRequestNo.HeaderText = "Request No";
            this.clmRequestNo.Name = "clmRequestNo";
            this.clmRequestNo.ReadOnly = true;
            // 
            // clmRequestedQty
            // 
            this.clmRequestedQty.HeaderText = "Request Qty";
            this.clmRequestedQty.Name = "clmRequestedQty";
            this.clmRequestedQty.ReadOnly = true;
            // 
            // clmReceivedQty
            // 
            this.clmReceivedQty.HeaderText = "Received Qty";
            this.clmReceivedQty.Name = "clmReceivedQty";
            this.clmReceivedQty.ReadOnly = true;
            // 
            // clmUnit
            // 
            this.clmUnit.HeaderText = "Unit";
            this.clmUnit.Name = "clmUnit";
            this.clmUnit.ReadOnly = true;
            // 
            // clmStatus
            // 
            this.clmStatus.HeaderText = "Status";
            this.clmStatus.Name = "clmStatus";
            this.clmStatus.ReadOnly = true;
            // 
            // picLoader
            // 
            this.picLoader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picLoader.ErrorImage = null;
            this.picLoader.Image = global::ROMS.Properties.Resources.loader;
            this.picLoader.InitialImage = null;
            this.picLoader.Location = new System.Drawing.Point(12, 9);
            this.picLoader.Name = "picLoader";
            this.picLoader.Size = new System.Drawing.Size(1329, 619);
            this.picLoader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picLoader.TabIndex = 958799;
            this.picLoader.TabStop = false;
            this.picLoader.Visible = false;
            // 
            // INV_StockRequestList
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
            this.Name = "INV_StockRequestList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Supplier List";
            this.Load += new System.EventHandler(this.CP_Supplierlist_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CP_Supplierlist_KeyDown);
            this.tsStockRequestList.ResumeLayout(false);
            this.tsStockRequestList.PerformLayout();
            this.pnlStockRequestList.ResumeLayout(false);
            this.pnlStockRequestList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV__SearchGrid)).EndInit();
            this.grbFilterBy.ResumeLayout(false);
            this.grbFilterBy.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdStockRequestList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsStockRequestList;
        private System.Windows.Forms.ToolStripLabel tspHeader;
        public System.Windows.Forms.ToolStripButton tsbDelete;
        public System.Windows.Forms.ToolStripSeparator tssEdit;
        public System.Windows.Forms.ToolStripButton tsbEdit;
        public System.Windows.Forms.ToolStripSeparator tssNew;
        public System.Windows.Forms.ToolStripButton tsbNew;
        private System.Windows.Forms.Panel pnlStockRequestList;
        private System.Windows.Forms.Label lblNoRecordsFound;
        public System.Windows.Forms.DataGridView grdStockRequestList;
        private System.Windows.Forms.PictureBox picLoader;
        private System.Windows.Forms.GroupBox grbFilterBy;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Label lblEntryFromDate;
        private System.Windows.Forms.DateTimePicker dpFromDate;
        private System.Windows.Forms.DateTimePicker dpEntryToDate;
        private System.Windows.Forms.Label lblEntrytoDate;
        private System.Windows.Forms.TextBox txtProductNamePICode;
        private System.Windows.Forms.Label lblDEProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmsno;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmEntryDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmRequestNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmRequestedQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmReceivedQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmStatus;
        public System.Windows.Forms.DataGridView DGV__SearchGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
    }
}