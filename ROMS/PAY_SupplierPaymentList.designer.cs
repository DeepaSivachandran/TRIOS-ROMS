namespace ROMS
{
    partial class PAY_SupplierPaymentList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle103 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle104 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle105 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle106 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle107 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle108 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tsSupplierPaymentList = new System.Windows.Forms.ToolStrip();
            this.tspHeader = new System.Windows.Forms.ToolStripLabel();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.tssEdit = new System.Windows.Forms.ToolStripSeparator();
            this.tsbEdit = new System.Windows.Forms.ToolStripButton();
            this.tssNew = new System.Windows.Forms.ToolStripSeparator();
            this.tsbNew = new System.Windows.Forms.ToolStripButton();
            this.grdSupllierPaymentList = new System.Windows.Forms.DataGridView();
            this.clmStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTransaction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTransactionNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSupplier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPaymentMode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPaymentDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPaidAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblNoRecordsFound = new System.Windows.Forms.Label();
            this.picLoader = new System.Windows.Forms.PictureBox();
            this.DGV_SearchGrid = new System.Windows.Forms.DataGridView();
            this.pnlbrand = new System.Windows.Forms.Panel();
            this.grbFilterBy = new System.Windows.Forms.GroupBox();
            this.dpTodate = new System.Windows.Forms.DateTimePicker();
            this.txtSupplier = new System.Windows.Forms.TextBox();
            this.lblDSupplier = new System.Windows.Forms.Label();
            this.dpFromdate = new System.Windows.Forms.DateTimePicker();
            this.lblTransactiondate = new System.Windows.Forms.Label();
            this.lblDConcern = new System.Windows.Forms.Label();
            this.btnView = new System.Windows.Forms.Button();
            this.cmbConcern = new System.Windows.Forms.ComboBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.tsSupplierPaymentList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSupllierPaymentList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_SearchGrid)).BeginInit();
            this.pnlbrand.SuspendLayout();
            this.grbFilterBy.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsSupplierPaymentList
            // 
            this.tsSupplierPaymentList.BackColor = System.Drawing.Color.White;
            this.tsSupplierPaymentList.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsSupplierPaymentList.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsSupplierPaymentList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspHeader,
            this.tsbDelete,
            this.tssEdit,
            this.tsbEdit,
            this.tssNew,
            this.tsbNew});
            this.tsSupplierPaymentList.Location = new System.Drawing.Point(0, 0);
            this.tsSupplierPaymentList.Name = "tsSupplierPaymentList";
            this.tsSupplierPaymentList.Size = new System.Drawing.Size(1354, 27);
            this.tsSupplierPaymentList.TabIndex = 35;
            this.tsSupplierPaymentList.Text = "Brand";
            // 
            // tspHeader
            // 
            this.tspHeader.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tspHeader.Image = global::ROMS.Properties.Resources.bread_crumb;
            this.tspHeader.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tspHeader.Margin = new System.Windows.Forms.Padding(15, 1, 0, 2);
            this.tspHeader.Name = "tspHeader";
            this.tspHeader.Size = new System.Drawing.Size(120, 24);
            this.tspHeader.Text = "Supplier Payment";
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
            // grdSupllierPaymentList
            // 
            this.grdSupllierPaymentList.AllowUserToAddRows = false;
            this.grdSupllierPaymentList.AllowUserToDeleteRows = false;
            this.grdSupllierPaymentList.AllowUserToResizeColumns = false;
            this.grdSupllierPaymentList.AllowUserToResizeRows = false;
            this.grdSupllierPaymentList.BackgroundColor = System.Drawing.Color.White;
            this.grdSupllierPaymentList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle103.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle103.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle103.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle103.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle103.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(242)))), ((int)(((byte)(213)))));
            dataGridViewCellStyle103.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle103.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdSupllierPaymentList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle103;
            this.grdSupllierPaymentList.ColumnHeadersHeight = 30;
            this.grdSupllierPaymentList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdSupllierPaymentList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmStatus,
            this.clmTransaction,
            this.clmTransactionNo,
            this.clmSupplier,
            this.clmPaymentMode,
            this.clmPaymentDate,
            this.clmPaidAmount});
            dataGridViewCellStyle104.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle104.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle104.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle104.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle104.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle104.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle104.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdSupllierPaymentList.DefaultCellStyle = dataGridViewCellStyle104;
            this.grdSupllierPaymentList.EnableHeadersVisualStyles = false;
            this.grdSupllierPaymentList.GridColor = System.Drawing.Color.White;
            this.grdSupllierPaymentList.Location = new System.Drawing.Point(3, 130);
            this.grdSupllierPaymentList.Name = "grdSupllierPaymentList";
            this.grdSupllierPaymentList.ReadOnly = true;
            this.grdSupllierPaymentList.RowHeadersVisible = false;
            dataGridViewCellStyle105.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle105.SelectionForeColor = System.Drawing.Color.White;
            this.grdSupllierPaymentList.RowsDefaultCellStyle = dataGridViewCellStyle105;
            this.grdSupllierPaymentList.RowTemplate.Height = 25;
            this.grdSupllierPaymentList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdSupllierPaymentList.Size = new System.Drawing.Size(1348, 515);
            this.grdSupllierPaymentList.TabIndex = 1;
            // 
            // clmStatus
            // 
            this.clmStatus.HeaderText = "S.No";
            this.clmStatus.Name = "clmStatus";
            this.clmStatus.ReadOnly = true;
            this.clmStatus.Width = 50;
            // 
            // clmTransaction
            // 
            this.clmTransaction.HeaderText = "Transaction Date";
            this.clmTransaction.Name = "clmTransaction";
            this.clmTransaction.ReadOnly = true;
            this.clmTransaction.Width = 150;
            // 
            // clmTransactionNo
            // 
            this.clmTransactionNo.HeaderText = "Transaction No.";
            this.clmTransactionNo.Name = "clmTransactionNo";
            this.clmTransactionNo.ReadOnly = true;
            this.clmTransactionNo.Width = 200;
            // 
            // clmSupplier
            // 
            this.clmSupplier.HeaderText = "Supplier";
            this.clmSupplier.Name = "clmSupplier";
            this.clmSupplier.ReadOnly = true;
            this.clmSupplier.Width = 200;
            // 
            // clmPaymentMode
            // 
            this.clmPaymentMode.HeaderText = "Payment Mode";
            this.clmPaymentMode.Name = "clmPaymentMode";
            this.clmPaymentMode.ReadOnly = true;
            // 
            // clmPaymentDate
            // 
            this.clmPaymentDate.HeaderText = "Payment Date";
            this.clmPaymentDate.Name = "clmPaymentDate";
            this.clmPaymentDate.ReadOnly = true;
            // 
            // clmPaidAmount
            // 
            this.clmPaidAmount.HeaderText = "Paid Amount";
            this.clmPaidAmount.Name = "clmPaidAmount";
            this.clmPaidAmount.ReadOnly = true;
            // 
            // lblNoRecordsFound
            // 
            this.lblNoRecordsFound.AutoSize = true;
            this.lblNoRecordsFound.BackColor = System.Drawing.Color.White;
            this.lblNoRecordsFound.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoRecordsFound.Location = new System.Drawing.Point(624, 377);
            this.lblNoRecordsFound.Name = "lblNoRecordsFound";
            this.lblNoRecordsFound.Size = new System.Drawing.Size(106, 20);
            this.lblNoRecordsFound.TabIndex = 958763;
            this.lblNoRecordsFound.Text = "No Records Found";
            this.lblNoRecordsFound.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // picLoader
            // 
            this.picLoader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picLoader.ErrorImage = null;
            this.picLoader.Image = global::ROMS.Properties.Resources.loader;
            this.picLoader.InitialImage = null;
            this.picLoader.Location = new System.Drawing.Point(942, 398);
            this.picLoader.Name = "picLoader";
            this.picLoader.Size = new System.Drawing.Size(399, 229);
            this.picLoader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picLoader.TabIndex = 958787;
            this.picLoader.TabStop = false;
            this.picLoader.Visible = false;
            // 
            // DGV_SearchGrid
            // 
            this.DGV_SearchGrid.AllowUserToAddRows = false;
            this.DGV_SearchGrid.AllowUserToDeleteRows = false;
            this.DGV_SearchGrid.AllowUserToResizeRows = false;
            this.DGV_SearchGrid.BackgroundColor = System.Drawing.Color.White;
            this.DGV_SearchGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle106.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle106.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle106.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle106.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle106.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(242)))), ((int)(((byte)(213)))));
            dataGridViewCellStyle106.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle106.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_SearchGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle106;
            this.DGV_SearchGrid.ColumnHeadersHeight = 30;
            this.DGV_SearchGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle107.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle107.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle107.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle107.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle107.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle107.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle107.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV_SearchGrid.DefaultCellStyle = dataGridViewCellStyle107;
            this.DGV_SearchGrid.EnableHeadersVisualStyles = false;
            this.DGV_SearchGrid.GridColor = System.Drawing.Color.White;
            this.DGV_SearchGrid.Location = new System.Drawing.Point(3, 74);
            this.DGV_SearchGrid.Name = "DGV_SearchGrid";
            this.DGV_SearchGrid.RowHeadersVisible = false;
            dataGridViewCellStyle108.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle108.SelectionForeColor = System.Drawing.Color.Black;
            this.DGV_SearchGrid.RowsDefaultCellStyle = dataGridViewCellStyle108;
            this.DGV_SearchGrid.RowTemplate.Height = 25;
            this.DGV_SearchGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DGV_SearchGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DGV_SearchGrid.ShowRowErrors = false;
            this.DGV_SearchGrid.Size = new System.Drawing.Size(1348, 56);
            this.DGV_SearchGrid.TabIndex = 958796;
            this.DGV_SearchGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_SearchGrid_CellEndEdit);
            this.DGV_SearchGrid.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.DGV_SearchGrid_CellPainting);
            this.DGV_SearchGrid.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DGV_SearchGrid_ColumnHeaderMouseClick);
            this.DGV_SearchGrid.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.DGV_SearchGrid_ColumnWidthChanged);
            // 
            // pnlbrand
            // 
            this.pnlbrand.BackColor = System.Drawing.Color.White;
            this.pnlbrand.Controls.Add(this.grbFilterBy);
            this.pnlbrand.Controls.Add(this.DGV_SearchGrid);
            this.pnlbrand.Controls.Add(this.lblNoRecordsFound);
            this.pnlbrand.Controls.Add(this.grdSupllierPaymentList);
            this.pnlbrand.Controls.Add(this.picLoader);
            this.pnlbrand.Location = new System.Drawing.Point(0, 31);
            this.pnlbrand.Name = "pnlbrand";
            this.pnlbrand.Size = new System.Drawing.Size(1354, 641);
            this.pnlbrand.TabIndex = 958797;
            // 
            // grbFilterBy
            // 
            this.grbFilterBy.Controls.Add(this.btnExport);
            this.grbFilterBy.Controls.Add(this.cmbConcern);
            this.grbFilterBy.Controls.Add(this.dpTodate);
            this.grbFilterBy.Controls.Add(this.txtSupplier);
            this.grbFilterBy.Controls.Add(this.lblDSupplier);
            this.grbFilterBy.Controls.Add(this.dpFromdate);
            this.grbFilterBy.Controls.Add(this.lblTransactiondate);
            this.grbFilterBy.Controls.Add(this.lblDConcern);
            this.grbFilterBy.Controls.Add(this.btnView);
            this.grbFilterBy.Location = new System.Drawing.Point(3, 2);
            this.grbFilterBy.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbFilterBy.Name = "grbFilterBy";
            this.grbFilterBy.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbFilterBy.Size = new System.Drawing.Size(1348, 67);
            this.grbFilterBy.TabIndex = 0;
            this.grbFilterBy.TabStop = false;
            this.grbFilterBy.Text = "Filter By ";
            // 
            // dpTodate
            // 
            this.dpTodate.CustomFormat = "dd/MM/yyyy";
            this.dpTodate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpTodate.Location = new System.Drawing.Point(419, 23);
            this.dpTodate.Name = "dpTodate";
            this.dpTodate.Size = new System.Drawing.Size(104, 27);
            this.dpTodate.TabIndex = 2;
            this.dpTodate.Enter += new System.EventHandler(this.DpTodate_Enter);
            this.dpTodate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DpTodate_KeyDown);
            this.dpTodate.Leave += new System.EventHandler(this.DpTodate_Leave);
            // 
            // txtSupplier
            // 
            this.txtSupplier.Location = new System.Drawing.Point(589, 23);
            this.txtSupplier.MaxLength = 2;
            this.txtSupplier.Name = "txtSupplier";
            this.txtSupplier.Size = new System.Drawing.Size(254, 27);
            this.txtSupplier.TabIndex = 3;
            this.txtSupplier.Enter += new System.EventHandler(this.TxtSupplier_Enter);
            this.txtSupplier.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtSupplier_KeyDown);
            this.txtSupplier.Leave += new System.EventHandler(this.TxtSupplier_Leave);
            // 
            // lblDSupplier
            // 
            this.lblDSupplier.AutoSize = true;
            this.lblDSupplier.Location = new System.Drawing.Point(529, 26);
            this.lblDSupplier.Name = "lblDSupplier";
            this.lblDSupplier.Size = new System.Drawing.Size(54, 20);
            this.lblDSupplier.TabIndex = 958811;
            this.lblDSupplier.Text = "Supplier";
            // 
            // dpFromdate
            // 
            this.dpFromdate.CustomFormat = "dd/MM/yyyy";
            this.dpFromdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpFromdate.Location = new System.Drawing.Point(309, 23);
            this.dpFromdate.Name = "dpFromdate";
            this.dpFromdate.Size = new System.Drawing.Size(104, 27);
            this.dpFromdate.TabIndex = 1;
            this.dpFromdate.Enter += new System.EventHandler(this.DpFromdate_Enter);
            this.dpFromdate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DpFromdate_KeyDown);
            this.dpFromdate.Leave += new System.EventHandler(this.DpFromdate_Leave);
            // 
            // lblTransactiondate
            // 
            this.lblTransactiondate.AutoSize = true;
            this.lblTransactiondate.Location = new System.Drawing.Point(203, 26);
            this.lblTransactiondate.Name = "lblTransactiondate";
            this.lblTransactiondate.Size = new System.Drawing.Size(100, 20);
            this.lblTransactiondate.TabIndex = 92;
            this.lblTransactiondate.Text = "Transaction Date";
            // 
            // lblDConcern
            // 
            this.lblDConcern.AutoSize = true;
            this.lblDConcern.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.lblDConcern.Location = new System.Drawing.Point(6, 26);
            this.lblDConcern.Name = "lblDConcern";
            this.lblDConcern.Size = new System.Drawing.Size(54, 20);
            this.lblDConcern.TabIndex = 36;
            this.lblDConcern.Text = "Concern";
            // 
            // btnView
            // 
            this.btnView.Image = global::ROMS.Properties.Resources.view;
            this.btnView.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnView.Location = new System.Drawing.Point(849, 22);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(75, 29);
            this.btnView.TabIndex = 4;
            this.btnView.Text = "View";
            this.btnView.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.BtnView_Click);
            this.btnView.Enter += new System.EventHandler(this.BtnView_Enter);
            this.btnView.Leave += new System.EventHandler(this.BtnView_Leave);
            // 
            // cmbConcern
            // 
            this.cmbConcern.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbConcern.FormattingEnabled = true;
            this.cmbConcern.Location = new System.Drawing.Point(66, 23);
            this.cmbConcern.Name = "cmbConcern";
            this.cmbConcern.Size = new System.Drawing.Size(131, 27);
            this.cmbConcern.TabIndex = 0;
            this.cmbConcern.Enter += new System.EventHandler(this.CmbConcern_Enter);
            this.cmbConcern.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbConcern_KeyDown);
            this.cmbConcern.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbConcern_KeyPress);
            this.cmbConcern.Leave += new System.EventHandler(this.CmbConcern_Leave);
            // 
            // btnExport
            // 
            this.btnExport.Image = global::ROMS.Properties.Resources.excel;
            this.btnExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExport.Location = new System.Drawing.Point(930, 22);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(79, 29);
            this.btnExport.TabIndex = 5;
            this.btnExport.Text = "Export";
            this.btnExport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.BtnExport_Click);
            this.btnExport.Enter += new System.EventHandler(this.BtnExport_Enter);
            this.btnExport.Leave += new System.EventHandler(this.BtnExport_Leave);
            // 
            // PAY_SupplierPaymentList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(1354, 675);
            this.Controls.Add(this.pnlbrand);
            this.Controls.Add(this.tsSupplierPaymentList);
            this.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "PAY_SupplierPaymentList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Brand";
            this.Load += new System.EventHandler(this.PAY_SupplierPaymentList_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PAY_SupplierPaymentList_KeyDown);
            this.tsSupplierPaymentList.ResumeLayout(false);
            this.tsSupplierPaymentList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSupllierPaymentList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_SearchGrid)).EndInit();
            this.pnlbrand.ResumeLayout(false);
            this.pnlbrand.PerformLayout();
            this.grbFilterBy.ResumeLayout(false);
            this.grbFilterBy.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsSupplierPaymentList;
        private System.Windows.Forms.ToolStripLabel tspHeader;
        public System.Windows.Forms.DataGridView grdSupllierPaymentList;
        private System.Windows.Forms.Label lblNoRecordsFound;
        private System.Windows.Forms.PictureBox picLoader;
        public System.Windows.Forms.ToolStripButton tsbDelete;
        public System.Windows.Forms.ToolStripSeparator tssEdit;
        public System.Windows.Forms.ToolStripButton tsbEdit;
        public System.Windows.Forms.ToolStripSeparator tssNew;
        public System.Windows.Forms.ToolStripButton tsbNew;
        public System.Windows.Forms.DataGridView DGV_SearchGrid;
        private System.Windows.Forms.Panel pnlbrand;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTransaction;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTransactionNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSupplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPaymentMode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPaymentDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPaidAmount;
        private System.Windows.Forms.GroupBox grbFilterBy;
        private System.Windows.Forms.TextBox txtSupplier;
        private System.Windows.Forms.Label lblDSupplier;
        private System.Windows.Forms.DateTimePicker dpFromdate;
        private System.Windows.Forms.Label lblTransactiondate;
        private System.Windows.Forms.Label lblDConcern;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.DateTimePicker dpTodate;
        private System.Windows.Forms.ComboBox cmbConcern;
        private System.Windows.Forms.Button btnExport;
    }
}