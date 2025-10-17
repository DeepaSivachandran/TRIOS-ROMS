namespace ROMS
{
    partial class PAY_DiscountVoucherList
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
            this.tsDiscountList = new System.Windows.Forms.ToolStrip();
            this.tspHeader = new System.Windows.Forms.ToolStripLabel();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.tssEdit = new System.Windows.Forms.ToolStripSeparator();
            this.tsbEdit = new System.Windows.Forms.ToolStripButton();
            this.tssNew = new System.Windows.Forms.ToolStripSeparator();
            this.tsbNew = new System.Windows.Forms.ToolStripButton();
            this.grdDiscountList = new System.Windows.Forms.DataGridView();
            this.lblNoRecordsFound = new System.Windows.Forms.Label();
            this.DGV_SearchGrid = new System.Windows.Forms.DataGridView();
            this.pnlDiscount = new System.Windows.Forms.Panel();
            this.lvSupplier = new System.Windows.Forms.ListView();
            this.columnHeader21 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader22 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader23 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grbFilterBy = new System.Windows.Forms.GroupBox();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblSchedule = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            this.lblSupplierCode = new System.Windows.Forms.Label();
            this.cmbConcern = new System.Windows.Forms.ComboBox();
            this.dpTodate = new System.Windows.Forms.DateTimePicker();
            this.txtSupplier = new System.Windows.Forms.TextBox();
            this.lblDSupplier = new System.Windows.Forms.Label();
            this.dpFromdate = new System.Windows.Forms.DateTimePicker();
            this.lblTransactiondate = new System.Windows.Forms.Label();
            this.lblDConcern = new System.Windows.Forms.Label();
            this.btnView = new System.Windows.Forms.Button();
            this.picLoader = new System.Windows.Forms.PictureBox();
            this.tss = new System.Windows.Forms.ToolStripSeparator();
            this.tsDiscountList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDiscountList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_SearchGrid)).BeginInit();
            this.pnlDiscount.SuspendLayout();
            this.grbFilterBy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).BeginInit();
            this.SuspendLayout();
            // 
            // tsDiscountList
            // 
            this.tsDiscountList.BackColor = System.Drawing.Color.White;
            this.tsDiscountList.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsDiscountList.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsDiscountList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspHeader,
            this.tss,
            this.tsbDelete,
            this.tssEdit,
            this.tsbEdit,
            this.tssNew,
            this.tsbNew});
            this.tsDiscountList.Location = new System.Drawing.Point(0, 0);
            this.tsDiscountList.Name = "tsDiscountList";
            this.tsDiscountList.Size = new System.Drawing.Size(1354, 27);
            this.tsDiscountList.TabIndex = 35;
            this.tsDiscountList.Text = "Discout";
            // 
            // tspHeader
            // 
            this.tspHeader.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tspHeader.Image = global::ROMS.Properties.Resources.bread_crumb;
            this.tspHeader.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tspHeader.Margin = new System.Windows.Forms.Padding(15, 1, 0, 2);
            this.tspHeader.Name = "tspHeader";
            this.tspHeader.Size = new System.Drawing.Size(144, 24);
            this.tspHeader.Text = "Discount Voucher List";
            // 
            // tsbDelete
            // 
            this.tsbDelete.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbDelete.Image = global::ROMS.Properties.Resources.Delete;
            this.tsbDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDelete.Margin = new System.Windows.Forms.Padding(0, 1, 2, 2);
            this.tsbDelete.Name = "tsbDelete";
            this.tsbDelete.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tsbDelete.Size = new System.Drawing.Size(63, 24);
            this.tsbDelete.Text = "Delete";
            this.tsbDelete.Click += new System.EventHandler(this.tsbDelete_Click);
            // 
            // tssEdit
            // 
            this.tssEdit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tssEdit.Margin = new System.Windows.Forms.Padding(0, 1, 2, 2);
            this.tssEdit.Name = "tssEdit";
            this.tssEdit.Size = new System.Drawing.Size(6, 24);
            // 
            // tsbEdit
            // 
            this.tsbEdit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbEdit.Image = global::ROMS.Properties.Resources.Edit;
            this.tsbEdit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEdit.Margin = new System.Windows.Forms.Padding(0, 1, 2, 2);
            this.tsbEdit.Name = "tsbEdit";
            this.tsbEdit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tsbEdit.Size = new System.Drawing.Size(50, 24);
            this.tsbEdit.Text = "&Edit";
            this.tsbEdit.Click += new System.EventHandler(this.tsbEdit_Click);
            // 
            // tssNew
            // 
            this.tssNew.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tssNew.Margin = new System.Windows.Forms.Padding(0, 1, 2, 2);
            this.tssNew.Name = "tssNew";
            this.tssNew.Size = new System.Drawing.Size(6, 24);
            // 
            // tsbNew
            // 
            this.tsbNew.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbNew.Image = global::ROMS.Properties.Resources.New;
            this.tsbNew.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNew.Margin = new System.Windows.Forms.Padding(0, 1, 2, 2);
            this.tsbNew.Name = "tsbNew";
            this.tsbNew.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tsbNew.Size = new System.Drawing.Size(52, 24);
            this.tsbNew.Text = "&New";
            this.tsbNew.Click += new System.EventHandler(this.tsbNew_Click);
            // 
            // grdDiscountList
            // 
            this.grdDiscountList.AllowUserToAddRows = false;
            this.grdDiscountList.AllowUserToDeleteRows = false;
            this.grdDiscountList.AllowUserToResizeColumns = false;
            this.grdDiscountList.AllowUserToResizeRows = false;
            this.grdDiscountList.BackgroundColor = System.Drawing.Color.White;
            this.grdDiscountList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(242)))), ((int)(((byte)(213)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdDiscountList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdDiscountList.ColumnHeadersHeight = 30;
            this.grdDiscountList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdDiscountList.ColumnHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdDiscountList.DefaultCellStyle = dataGridViewCellStyle2;
            this.grdDiscountList.EnableHeadersVisualStyles = false;
            this.grdDiscountList.GridColor = System.Drawing.Color.White;
            this.grdDiscountList.Location = new System.Drawing.Point(3, 130);
            this.grdDiscountList.Name = "grdDiscountList";
            this.grdDiscountList.ReadOnly = true;
            this.grdDiscountList.RowHeadersVisible = false;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.grdDiscountList.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.grdDiscountList.RowTemplate.Height = 25;
            this.grdDiscountList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdDiscountList.Size = new System.Drawing.Size(1348, 515);
            this.grdDiscountList.TabIndex = 1;
            this.grdDiscountList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.GrdDiscountList_DataBindingComplete);
            this.grdDiscountList.Scroll += new System.Windows.Forms.ScrollEventHandler(this.GrdDiscountList_Scroll);
            this.grdDiscountList.SelectionChanged += new System.EventHandler(this.GrdDiscountList_SelectionChanged);
            this.grdDiscountList.DoubleClick += new System.EventHandler(this.GrdDiscountList_DoubleClick);
            this.grdDiscountList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GrdDiscountList_KeyDown);
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
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.White;
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
            this.DGV_SearchGrid.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DGV_SearchGrid_ColumnHeaderMouseClick);
            this.DGV_SearchGrid.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.DGV_SearchGrid_ColumnWidthChanged);
            this.DGV_SearchGrid.CurrentCellDirtyStateChanged += new System.EventHandler(this.DGV_SearchGrid_CurrentCellDirtyStateChanged);
            this.DGV_SearchGrid.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.DGV_SearchGrid_EditingControlShowing);
            this.DGV_SearchGrid.Scroll += new System.Windows.Forms.ScrollEventHandler(this.DGV_SearchGrid_Scroll);
            // 
            // pnlDiscount
            // 
            this.pnlDiscount.BackColor = System.Drawing.Color.White;
            this.pnlDiscount.Controls.Add(this.lvSupplier);
            this.pnlDiscount.Controls.Add(this.grbFilterBy);
            this.pnlDiscount.Controls.Add(this.DGV_SearchGrid);
            this.pnlDiscount.Controls.Add(this.lblNoRecordsFound);
            this.pnlDiscount.Controls.Add(this.grdDiscountList);
            this.pnlDiscount.Controls.Add(this.picLoader);
            this.pnlDiscount.Location = new System.Drawing.Point(0, 31);
            this.pnlDiscount.Name = "pnlDiscount";
            this.pnlDiscount.Size = new System.Drawing.Size(1354, 641);
            this.pnlDiscount.TabIndex = 958797;
            // 
            // lvSupplier
            // 
            this.lvSupplier.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader21,
            this.columnHeader22,
            this.columnHeader23});
            this.lvSupplier.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.lvSupplier.FullRowSelect = true;
            this.lvSupplier.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvSupplier.HideSelection = false;
            this.lvSupplier.Location = new System.Drawing.Point(592, 52);
            this.lvSupplier.Name = "lvSupplier";
            this.lvSupplier.Size = new System.Drawing.Size(420, 219);
            this.lvSupplier.TabIndex = 111111145;
            this.lvSupplier.UseCompatibleStateImageBehavior = false;
            this.lvSupplier.View = System.Windows.Forms.View.Details;
            this.lvSupplier.Visible = false;
            this.lvSupplier.DoubleClick += new System.EventHandler(this.LvSupplier_DoubleClick);
            this.lvSupplier.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LvSupplier_KeyDown);
            // 
            // columnHeader21
            // 
            this.columnHeader21.Width = 250;
            // 
            // columnHeader22
            // 
            this.columnHeader22.Width = 0;
            // 
            // columnHeader23
            // 
            this.columnHeader23.Width = 0;
            // 
            // grbFilterBy
            // 
            this.grbFilterBy.Controls.Add(this.cmbStatus);
            this.grbFilterBy.Controls.Add(this.lblStatus);
            this.grbFilterBy.Controls.Add(this.lblSchedule);
            this.grbFilterBy.Controls.Add(this.btnExport);
            this.grbFilterBy.Controls.Add(this.lblSupplierCode);
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
            // cmbStatus
            // 
            this.cmbStatus.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(900, 23);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(146, 27);
            this.cmbStatus.TabIndex = 4;
            this.cmbStatus.Enter += new System.EventHandler(this.CmbStatus_Enter);
            this.cmbStatus.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbStatus_KeyDown);
            this.cmbStatus.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbStatus_KeyPress);
            this.cmbStatus.Leave += new System.EventHandler(this.CmbStatus_Leave);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(849, 26);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(45, 20);
            this.lblStatus.TabIndex = 111111149;
            this.lblStatus.Text = "Status";
            // 
            // lblSchedule
            // 
            this.lblSchedule.AutoSize = true;
            this.lblSchedule.Location = new System.Drawing.Point(1323, 26);
            this.lblSchedule.Name = "lblSchedule";
            this.lblSchedule.Size = new System.Drawing.Size(16, 20);
            this.lblSchedule.TabIndex = 111111147;
            this.lblSchedule.Text = "0";
            this.lblSchedule.Visible = false;
            // 
            // btnExport
            // 
            this.btnExport.Image = global::ROMS.Properties.Resources.excel;
            this.btnExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExport.Location = new System.Drawing.Point(1133, 22);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(79, 29);
            this.btnExport.TabIndex = 6;
            this.btnExport.Text = "Export";
            this.btnExport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.BtnExport_Click);
            this.btnExport.Enter += new System.EventHandler(this.BtnExport_Enter);
            this.btnExport.Leave += new System.EventHandler(this.BtnExport_Leave);
            // 
            // lblSupplierCode
            // 
            this.lblSupplierCode.AutoSize = true;
            this.lblSupplierCode.Location = new System.Drawing.Point(1301, 26);
            this.lblSupplierCode.Name = "lblSupplierCode";
            this.lblSupplierCode.Size = new System.Drawing.Size(16, 20);
            this.lblSupplierCode.TabIndex = 111111146;
            this.lblSupplierCode.Text = "0";
            this.lblSupplierCode.Visible = false;
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
            this.txtSupplier.TextChanged += new System.EventHandler(this.TxtSupplier_TextChanged);
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
            this.dpFromdate.ValueChanged += new System.EventHandler(this.DpFromdate_ValueChanged);
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
            this.btnView.Location = new System.Drawing.Point(1052, 22);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(75, 29);
            this.btnView.TabIndex = 5;
            this.btnView.Text = "View";
            this.btnView.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.BtnView_Click);
            this.btnView.Enter += new System.EventHandler(this.BtnView_Enter);
            this.btnView.Leave += new System.EventHandler(this.BtnView_Leave);
            // 
            // picLoader
            // 
            this.picLoader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picLoader.ErrorImage = null;
            this.picLoader.Image = global::ROMS.Properties.Resources.Iphone_spinner_2;
            this.picLoader.InitialImage = null;
            this.picLoader.Location = new System.Drawing.Point(3, 107);
            this.picLoader.Name = "picLoader";
            this.picLoader.Size = new System.Drawing.Size(1348, 536);
            this.picLoader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picLoader.TabIndex = 111111148;
            this.picLoader.TabStop = false;
            this.picLoader.Visible = false;
            // 
            // tss
            // 
            this.tss.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tss.Margin = new System.Windows.Forms.Padding(0, 1, 2, 2);
            this.tss.Name = "tss";
            this.tss.Size = new System.Drawing.Size(6, 24);
            // 
            // PAY_DiscountVoucherList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(1354, 675);
            this.Controls.Add(this.pnlDiscount);
            this.Controls.Add(this.tsDiscountList);
            this.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "PAY_DiscountVoucherList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Discount Voucher";
            this.Load += new System.EventHandler(this.PAY_DiscountVoucherList_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PAY_DiscountVoucherList_KeyDown);
            this.tsDiscountList.ResumeLayout(false);
            this.tsDiscountList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDiscountList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_SearchGrid)).EndInit();
            this.pnlDiscount.ResumeLayout(false);
            this.pnlDiscount.PerformLayout();
            this.grbFilterBy.ResumeLayout(false);
            this.grbFilterBy.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsDiscountList;
        private System.Windows.Forms.ToolStripLabel tspHeader;
        public System.Windows.Forms.DataGridView grdDiscountList;
        private System.Windows.Forms.Label lblNoRecordsFound;
        public System.Windows.Forms.ToolStripButton tsbDelete;
        public System.Windows.Forms.ToolStripSeparator tssEdit;
        public System.Windows.Forms.ToolStripButton tsbEdit;
        public System.Windows.Forms.ToolStripSeparator tssNew;
        public System.Windows.Forms.ToolStripButton tsbNew;
        public System.Windows.Forms.DataGridView DGV_SearchGrid;
        private System.Windows.Forms.Panel pnlDiscount;
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
        public System.Windows.Forms.ListView lvSupplier;
        private System.Windows.Forms.ColumnHeader columnHeader21;
        private System.Windows.Forms.ColumnHeader columnHeader22;
        private System.Windows.Forms.ColumnHeader columnHeader23;
        private System.Windows.Forms.Label lblSchedule;
        private System.Windows.Forms.Label lblSupplierCode;
        public System.Windows.Forms.PictureBox picLoader;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label lblStatus;
        public System.Windows.Forms.ToolStripSeparator tss;
    }
}