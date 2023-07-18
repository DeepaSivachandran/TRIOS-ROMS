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
            this.lblNoRecordsFound = new System.Windows.Forms.Label();
            this.dgvStockTransferList = new System.Windows.Forms.DataGridView();
            this.grbFilterBy = new System.Windows.Forms.GroupBox();
            this.txtProductNamePICode = new System.Windows.Forms.TextBox();
            this.lvProductNamePICode = new System.Windows.Forms.ListView();
            this.dpTransferToDate = new System.Windows.Forms.DateTimePicker();
            this.dpTrannsferFromDate = new System.Windows.Forms.DateTimePicker();
            this.lblProductNamePICode = new System.Windows.Forms.Label();
            this.lblTransferToDate = new System.Windows.Forms.Label();
            this.lblTransferFromDate = new System.Windows.Forms.Label();
            this.lblConcern = new System.Windows.Forms.Label();
            this.cmbConcer = new System.Windows.Forms.ComboBox();
            this.btnView = new System.Windows.Forms.Button();
            this.DGV_SearchGrid = new System.Windows.Forms.DataGridView();
            this.picLoader = new System.Windows.Forms.PictureBox();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmdsno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmdtransferdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTransferNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmconcern = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmsource = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmdestination = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmdsalename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTotalQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.tsStockTransferList.Text = "Stock Transfer List";
            // 
            // tspHeader
            // 
            this.tspHeader.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tspHeader.Image = global::ROMS.Properties.Resources.bread_crumb;
            this.tspHeader.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tspHeader.Margin = new System.Windows.Forms.Padding(15, 1, 0, 2);
            this.tspHeader.Name = "tspHeader";
            this.tspHeader.Size = new System.Drawing.Size(126, 24);
            this.tspHeader.Text = "Stock Transfer List";
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
            this.pnlStockTransferList.Controls.Add(this.lblNoRecordsFound);
            this.pnlStockTransferList.Controls.Add(this.dgvStockTransferList);
            this.pnlStockTransferList.Controls.Add(this.grbFilterBy);
            this.pnlStockTransferList.Controls.Add(this.DGV_SearchGrid);
            this.pnlStockTransferList.Controls.Add(this.picLoader);
            this.pnlStockTransferList.Location = new System.Drawing.Point(0, 28);
            this.pnlStockTransferList.Name = "pnlStockTransferList";
            this.pnlStockTransferList.Size = new System.Drawing.Size(1354, 644);
            this.pnlStockTransferList.TabIndex = 36;
            // 
            // lblNoRecordsFound
            // 
            this.lblNoRecordsFound.AutoSize = true;
            this.lblNoRecordsFound.BackColor = System.Drawing.Color.White;
            this.lblNoRecordsFound.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoRecordsFound.Location = new System.Drawing.Point(624, 403);
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(242)))), ((int)(((byte)(213)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvStockTransferList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvStockTransferList.ColumnHeadersHeight = 30;
            this.dgvStockTransferList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvStockTransferList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvStockTransferList.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvStockTransferList.EnableHeadersVisualStyles = false;
            this.dgvStockTransferList.GridColor = System.Drawing.Color.White;
            this.dgvStockTransferList.Location = new System.Drawing.Point(13, 163);
            this.dgvStockTransferList.Name = "dgvStockTransferList";
            this.dgvStockTransferList.RowHeadersVisible = false;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvStockTransferList.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvStockTransferList.RowTemplate.Height = 25;
            this.dgvStockTransferList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvStockTransferList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvStockTransferList.ShowRowErrors = false;
            this.dgvStockTransferList.Size = new System.Drawing.Size(1329, 481);
            this.dgvStockTransferList.TabIndex = 958802;
            // 
            // grbFilterBy
            // 
            this.grbFilterBy.Controls.Add(this.txtProductNamePICode);
            this.grbFilterBy.Controls.Add(this.lvProductNamePICode);
            this.grbFilterBy.Controls.Add(this.dpTransferToDate);
            this.grbFilterBy.Controls.Add(this.dpTrannsferFromDate);
            this.grbFilterBy.Controls.Add(this.lblProductNamePICode);
            this.grbFilterBy.Controls.Add(this.lblTransferToDate);
            this.grbFilterBy.Controls.Add(this.lblTransferFromDate);
            this.grbFilterBy.Controls.Add(this.lblConcern);
            this.grbFilterBy.Controls.Add(this.cmbConcer);
            this.grbFilterBy.Controls.Add(this.btnView);
            this.grbFilterBy.Location = new System.Drawing.Point(25, 15);
            this.grbFilterBy.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbFilterBy.Name = "grbFilterBy";
            this.grbFilterBy.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbFilterBy.Size = new System.Drawing.Size(918, 92);
            this.grbFilterBy.TabIndex = 958801;
            this.grbFilterBy.TabStop = false;
            this.grbFilterBy.Text = "Filter By";
            // 
            // txtProductNamePICode
            // 
            this.txtProductNamePICode.Location = new System.Drawing.Point(484, 51);
            this.txtProductNamePICode.Name = "txtProductNamePICode";
            this.txtProductNamePICode.Size = new System.Drawing.Size(340, 27);
            this.txtProductNamePICode.TabIndex = 958822;
            // 
            // lvProductNamePICode
            // 
            this.lvProductNamePICode.HideSelection = false;
            this.lvProductNamePICode.Location = new System.Drawing.Point(484, 77);
            this.lvProductNamePICode.Name = "lvProductNamePICode";
            this.lvProductNamePICode.Size = new System.Drawing.Size(340, 56);
            this.lvProductNamePICode.TabIndex = 958823;
            this.lvProductNamePICode.UseCompatibleStateImageBehavior = false;
            this.lvProductNamePICode.Visible = false;
            // 
            // dpTransferToDate
            // 
            this.dpTransferToDate.CustomFormat = "dd/MM/yyyy";
            this.dpTransferToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpTransferToDate.Location = new System.Drawing.Point(371, 51);
            this.dpTransferToDate.Name = "dpTransferToDate";
            this.dpTransferToDate.Size = new System.Drawing.Size(92, 27);
            this.dpTransferToDate.TabIndex = 958821;
            // 
            // dpTrannsferFromDate
            // 
            this.dpTrannsferFromDate.CustomFormat = "dd/MM/yyyy";
            this.dpTrannsferFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpTrannsferFromDate.Location = new System.Drawing.Point(244, 51);
            this.dpTrannsferFromDate.Name = "dpTrannsferFromDate";
            this.dpTrannsferFromDate.Size = new System.Drawing.Size(92, 27);
            this.dpTrannsferFromDate.TabIndex = 958820;
            // 
            // lblProductNamePICode
            // 
            this.lblProductNamePICode.AutoSize = true;
            this.lblProductNamePICode.Location = new System.Drawing.Point(484, 25);
            this.lblProductNamePICode.Name = "lblProductNamePICode";
            this.lblProductNamePICode.Size = new System.Drawing.Size(134, 20);
            this.lblProductNamePICode.TabIndex = 958818;
            this.lblProductNamePICode.Text = "Product Name/P.I Code";
            // 
            // lblTransferToDate
            // 
            this.lblTransferToDate.AutoSize = true;
            this.lblTransferToDate.Location = new System.Drawing.Point(371, 25);
            this.lblTransferToDate.Name = "lblTransferToDate";
            this.lblTransferToDate.Size = new System.Drawing.Size(97, 20);
            this.lblTransferToDate.TabIndex = 958817;
            this.lblTransferToDate.Text = "Transfer To Date";
            // 
            // lblTransferFromDate
            // 
            this.lblTransferFromDate.AutoSize = true;
            this.lblTransferFromDate.Location = new System.Drawing.Point(244, 25);
            this.lblTransferFromDate.Name = "lblTransferFromDate";
            this.lblTransferFromDate.Size = new System.Drawing.Size(112, 20);
            this.lblTransferFromDate.TabIndex = 958816;
            this.lblTransferFromDate.Text = "Transfer From Date";
            // 
            // lblConcern
            // 
            this.lblConcern.AutoSize = true;
            this.lblConcern.Location = new System.Drawing.Point(13, 25);
            this.lblConcern.Name = "lblConcern";
            this.lblConcern.Size = new System.Drawing.Size(54, 20);
            this.lblConcern.TabIndex = 958815;
            this.lblConcern.Text = "Concern";
            // 
            // cmbConcer
            // 
            this.cmbConcer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbConcer.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbConcer.FormattingEnabled = true;
            this.cmbConcer.Location = new System.Drawing.Point(13, 51);
            this.cmbConcer.Name = "cmbConcer";
            this.cmbConcer.Size = new System.Drawing.Size(216, 27);
            this.cmbConcer.TabIndex = 958814;
            // 
            // btnView
            // 
            this.btnView.Image = global::ROMS.Properties.Resources.view;
            this.btnView.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnView.Location = new System.Drawing.Point(830, 49);
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
            this.DGV_SearchGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmdsno,
            this.clmdtransferdate,
            this.clmTransferNo,
            this.clmconcern,
            this.clmsource,
            this.clmdestination,
            this.clmdsalename,
            this.clmTotalQty});
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
            this.DGV_SearchGrid.Location = new System.Drawing.Point(13, 107);
            this.DGV_SearchGrid.Name = "DGV_SearchGrid";
            this.DGV_SearchGrid.RowHeadersVisible = false;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            this.DGV_SearchGrid.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.DGV_SearchGrid.RowTemplate.Height = 25;
            this.DGV_SearchGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DGV_SearchGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DGV_SearchGrid.ShowRowErrors = false;
            this.DGV_SearchGrid.Size = new System.Drawing.Size(1329, 56);
            this.DGV_SearchGrid.TabIndex = 958800;
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
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "S.No.";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
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
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Concern";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Source";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Destination";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "No. Of Items";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 200;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "Total Qty";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // clmdsno
            // 
            this.clmdsno.HeaderText = "S.No.";
            this.clmdsno.Name = "clmdsno";
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
            // clmconcern
            // 
            this.clmconcern.HeaderText = "Concern";
            this.clmconcern.Name = "clmconcern";
            // 
            // clmsource
            // 
            this.clmsource.HeaderText = "Source";
            this.clmsource.Name = "clmsource";
            // 
            // clmdestination
            // 
            this.clmdestination.HeaderText = "Destination";
            this.clmdestination.Name = "clmdestination";
            // 
            // clmdsalename
            // 
            this.clmdsalename.HeaderText = "No. Of Items";
            this.clmdsalename.Name = "clmdsalename";
            this.clmdsalename.Width = 200;
            // 
            // clmTotalQty
            // 
            this.clmTotalQty.HeaderText = "Total Qty";
            this.clmTotalQty.Name = "clmTotalQty";
            // 
            // INV_StockTransferList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
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
        private System.Windows.Forms.Label lblConcern;
        private System.Windows.Forms.ComboBox cmbConcer;
        private System.Windows.Forms.Label lblTransferFromDate;
        private System.Windows.Forms.Label lblProductNamePICode;
        private System.Windows.Forms.Label lblTransferToDate;
        private System.Windows.Forms.DateTimePicker dpTransferToDate;
        private System.Windows.Forms.DateTimePicker dpTrannsferFromDate;
        public System.Windows.Forms.DataGridView dgvStockTransferList;
        private System.Windows.Forms.TextBox txtProductNamePICode;
        private System.Windows.Forms.ListView lvProductNamePICode;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmdsno;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmdtransferdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTransferNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmconcern;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmsource;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmdestination;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmdsalename;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTotalQty;
    }
}