namespace ROMS
{
    partial class PUR_GRNDetailsList
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
            this.tsBrandList = new System.Windows.Forms.ToolStrip();
            this.tspHeader = new System.Windows.Forms.ToolStripLabel();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.tssEdit = new System.Windows.Forms.ToolStripSeparator();
            this.tsbEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbNew = new System.Windows.Forms.ToolStripButton();
            this.pnlpurchaseapproval = new System.Windows.Forms.Panel();
            this.lblNoRecordsFound = new System.Windows.Forms.Label();
            this.LV_Supplier = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grpfilter = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblSupplierCode = new System.Windows.Forms.Label();
            this.lblschedleCode = new System.Windows.Forms.Label();
            this.cmbConcern = new System.Windows.Forms.ComboBox();
            this.txtSupplier = new System.Windows.Forms.TextBox();
            this.btnView = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbOrdertype = new System.Windows.Forms.ComboBox();
            this.dpToDate = new System.Windows.Forms.DateTimePicker();
            this.dpFromDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.DGV_SearchGrid = new System.Windows.Forms.DataGridView();
            this.clmdsno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmdconcern = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmdgrndate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmdGrnno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmdsupplier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmdinvoicedate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmdinvoice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmdinvoiceamt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmdordertype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AnyPurchaseReturns = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Createby = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreatedOn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grdGRNList = new System.Windows.Forms.DataGridView();
            this.ClmEdit = new System.Windows.Forms.DataGridViewImageColumn();
            this.clmPrint = new System.Windows.Forms.DataGridViewImageColumn();
            this.picLoader = new System.Windows.Forms.PictureBox();
            this.tsBrandList.SuspendLayout();
            this.pnlpurchaseapproval.SuspendLayout();
            this.grpfilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_SearchGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdGRNList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).BeginInit();
            this.SuspendLayout();
            // 
            // tsBrandList
            // 
            this.tsBrandList.BackColor = System.Drawing.Color.White;
            this.tsBrandList.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsBrandList.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsBrandList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspHeader,
            this.tsbDelete,
            this.tssEdit,
            this.tsbEdit,
            this.toolStripSeparator1,
            this.tsbNew});
            this.tsBrandList.Location = new System.Drawing.Point(0, 0);
            this.tsBrandList.Name = "tsBrandList";
            this.tsBrandList.Size = new System.Drawing.Size(1354, 27);
            this.tsBrandList.TabIndex = 35;
            this.tsBrandList.Text = "Brand";
            // 
            // tspHeader
            // 
            this.tspHeader.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tspHeader.Image = global::ROMS.Properties.Resources.bread_crumb;
            this.tspHeader.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tspHeader.Margin = new System.Windows.Forms.Padding(15, 1, 0, 2);
            this.tspHeader.Name = "tspHeader";
            this.tspHeader.Size = new System.Drawing.Size(81, 24);
            this.tspHeader.Text = "GRN Entry";
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
            this.tsbEdit.Click += new System.EventHandler(this.TsbEdit_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator1.Margin = new System.Windows.Forms.Padding(0, 0, 15, 0);
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
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
            this.tsbNew.Click += new System.EventHandler(this.TsbNew_Click);
            // 
            // pnlpurchaseapproval
            // 
            this.pnlpurchaseapproval.BackColor = System.Drawing.Color.White;
            this.pnlpurchaseapproval.Controls.Add(this.lblNoRecordsFound);
            this.pnlpurchaseapproval.Controls.Add(this.LV_Supplier);
            this.pnlpurchaseapproval.Controls.Add(this.grpfilter);
            this.pnlpurchaseapproval.Controls.Add(this.DGV_SearchGrid);
            this.pnlpurchaseapproval.Controls.Add(this.grdGRNList);
            this.pnlpurchaseapproval.Controls.Add(this.picLoader);
            this.pnlpurchaseapproval.Location = new System.Drawing.Point(0, 31);
            this.pnlpurchaseapproval.Name = "pnlpurchaseapproval";
            this.pnlpurchaseapproval.Size = new System.Drawing.Size(1354, 643);
            this.pnlpurchaseapproval.TabIndex = 958789;
            // 
            // lblNoRecordsFound
            // 
            this.lblNoRecordsFound.AutoSize = true;
            this.lblNoRecordsFound.BackColor = System.Drawing.Color.White;
            this.lblNoRecordsFound.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoRecordsFound.Location = new System.Drawing.Point(624, 375);
            this.lblNoRecordsFound.Name = "lblNoRecordsFound";
            this.lblNoRecordsFound.Size = new System.Drawing.Size(106, 20);
            this.lblNoRecordsFound.TabIndex = 1111183;
            this.lblNoRecordsFound.Text = "No Records Found";
            this.lblNoRecordsFound.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // LV_Supplier
            // 
            this.LV_Supplier.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader8,
            this.columnHeader9});
            this.LV_Supplier.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.LV_Supplier.HideSelection = false;
            this.LV_Supplier.Location = new System.Drawing.Point(653, 55);
            this.LV_Supplier.Name = "LV_Supplier";
            this.LV_Supplier.Size = new System.Drawing.Size(362, 93);
            this.LV_Supplier.TabIndex = 1111179;
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
            // grpfilter
            // 
            this.grpfilter.Controls.Add(this.label3);
            this.grpfilter.Controls.Add(this.lblSupplierCode);
            this.grpfilter.Controls.Add(this.lblschedleCode);
            this.grpfilter.Controls.Add(this.cmbConcern);
            this.grpfilter.Controls.Add(this.txtSupplier);
            this.grpfilter.Controls.Add(this.btnView);
            this.grpfilter.Controls.Add(this.label10);
            this.grpfilter.Controls.Add(this.label4);
            this.grpfilter.Controls.Add(this.label2);
            this.grpfilter.Controls.Add(this.cmbOrdertype);
            this.grpfilter.Controls.Add(this.dpToDate);
            this.grpfilter.Controls.Add(this.dpFromDate);
            this.grpfilter.Controls.Add(this.label1);
            this.grpfilter.Location = new System.Drawing.Point(3, 2);
            this.grpfilter.Name = "grpfilter";
            this.grpfilter.Size = new System.Drawing.Size(1329, 67);
            this.grpfilter.TabIndex = 958799;
            this.grpfilter.TabStop = false;
            this.grpfilter.Text = "Filter By";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(943, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 20);
            this.label3.TabIndex = 1111182;
            this.label3.Text = "0";
            this.label3.Visible = false;
            // 
            // lblSupplierCode
            // 
            this.lblSupplierCode.AutoSize = true;
            this.lblSupplierCode.Location = new System.Drawing.Point(996, 6);
            this.lblSupplierCode.Name = "lblSupplierCode";
            this.lblSupplierCode.Size = new System.Drawing.Size(16, 20);
            this.lblSupplierCode.TabIndex = 1111182;
            this.lblSupplierCode.Text = "0";
            this.lblSupplierCode.Visible = false;
            // 
            // lblschedleCode
            // 
            this.lblschedleCode.AutoSize = true;
            this.lblschedleCode.Location = new System.Drawing.Point(942, 6);
            this.lblschedleCode.Name = "lblschedleCode";
            this.lblschedleCode.Size = new System.Drawing.Size(16, 20);
            this.lblschedleCode.TabIndex = 1111181;
            this.lblschedleCode.Text = "0";
            this.lblschedleCode.Visible = false;
            // 
            // cmbConcern
            // 
            this.cmbConcern.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbConcern.FormattingEnabled = true;
            this.cmbConcern.Location = new System.Drawing.Point(89, 23);
            this.cmbConcern.Name = "cmbConcern";
            this.cmbConcern.Size = new System.Drawing.Size(163, 27);
            this.cmbConcern.TabIndex = 0;
            this.cmbConcern.SelectedIndexChanged += new System.EventHandler(this.CmbConcern_SelectedIndexChanged);
            this.cmbConcern.Enter += new System.EventHandler(this.CmbConcern_Enter);
            this.cmbConcern.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbConcern_KeyDown);
            this.cmbConcern.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbConcern_KeyPress);
            this.cmbConcern.Leave += new System.EventHandler(this.CmbConcern_Leave);
            // 
            // txtSupplier
            // 
            this.txtSupplier.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtSupplier.Location = new System.Drawing.Point(650, 23);
            this.txtSupplier.MaxLength = 100;
            this.txtSupplier.Name = "txtSupplier";
            this.txtSupplier.Size = new System.Drawing.Size(273, 27);
            this.txtSupplier.TabIndex = 3;
            this.txtSupplier.TextChanged += new System.EventHandler(this.TxtSupplier_TextChanged);
            this.txtSupplier.Enter += new System.EventHandler(this.TxtSupplier_Enter);
            this.txtSupplier.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtSupplier_KeyDown);
            this.txtSupplier.Leave += new System.EventHandler(this.TxtSupplier_Leave);
            // 
            // btnView
            // 
            this.btnView.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnView.Image = global::ROMS.Properties.Resources.view;
            this.btnView.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnView.Location = new System.Drawing.Point(1193, 20);
            this.btnView.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(74, 33);
            this.btnView.TabIndex = 5;
            this.btnView.Text = "View";
            this.btnView.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.BtnView_Click);
            this.btnView.Enter += new System.EventHandler(this.BtnView_Enter);
            this.btnView.Leave += new System.EventHandler(this.BtnView_Leave);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(26, 26);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 20);
            this.label10.TabIndex = 1111166;
            this.label10.Text = "Concern";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(965, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 20);
            this.label4.TabIndex = 1111148;
            this.label4.Text = "Order Type";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(557, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 20);
            this.label2.TabIndex = 1111140;
            this.label2.Text = "Supplier Name";
            // 
            // cmbOrdertype
            // 
            this.cmbOrdertype.FormattingEnabled = true;
            this.cmbOrdertype.Location = new System.Drawing.Point(1039, 23);
            this.cmbOrdertype.Name = "cmbOrdertype";
            this.cmbOrdertype.Size = new System.Drawing.Size(150, 27);
            this.cmbOrdertype.TabIndex = 4;
            this.cmbOrdertype.Enter += new System.EventHandler(this.CmbOrdertype_Enter);
            this.cmbOrdertype.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbOrdertype_KeyDown);
            this.cmbOrdertype.Leave += new System.EventHandler(this.CmbOrdertype_Leave);
            // 
            // dpToDate
            // 
            this.dpToDate.CustomFormat = "dd/MM/yyyy";
            this.dpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpToDate.Location = new System.Drawing.Point(444, 23);
            this.dpToDate.Name = "dpToDate";
            this.dpToDate.Size = new System.Drawing.Size(107, 27);
            this.dpToDate.TabIndex = 2;
            this.dpToDate.Enter += new System.EventHandler(this.DpToDate_Enter);
            this.dpToDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DpToDate_KeyDown);
            this.dpToDate.Leave += new System.EventHandler(this.DpToDate_Leave);
            // 
            // dpFromDate
            // 
            this.dpFromDate.CustomFormat = "dd/MM/yyyy";
            this.dpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpFromDate.Location = new System.Drawing.Point(333, 23);
            this.dpFromDate.Name = "dpFromDate";
            this.dpFromDate.Size = new System.Drawing.Size(107, 27);
            this.dpFromDate.TabIndex = 1;
            this.dpFromDate.Enter += new System.EventHandler(this.DpFromDate_Enter);
            this.dpFromDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DpFromDate_KeyDown);
            this.dpFromDate.Leave += new System.EventHandler(this.DpFromDate_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(258, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 20);
            this.label1.TabIndex = 1111139;
            this.label1.Text = "GRN Date";
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
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_SearchGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DGV_SearchGrid.ColumnHeadersHeight = 30;
            this.DGV_SearchGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGV_SearchGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmdsno,
            this.clmdconcern,
            this.clmdgrndate,
            this.clmdGrnno,
            this.clmdsupplier,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.clmdinvoicedate,
            this.clmdinvoice,
            this.clmdinvoiceamt,
            this.clmdordertype,
            this.AnyPurchaseReturns,
            this.Createby,
            this.CreatedOn});
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
            this.DGV_SearchGrid.RowHeadersWidth = 70;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.DGV_SearchGrid.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.DGV_SearchGrid.RowTemplate.Height = 25;
            this.DGV_SearchGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DGV_SearchGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DGV_SearchGrid.ShowRowErrors = false;
            this.DGV_SearchGrid.Size = new System.Drawing.Size(1348, 56);
            this.DGV_SearchGrid.TabIndex = 958798;
            this.DGV_SearchGrid.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.DGV_SearchGrid_CellPainting);
            this.DGV_SearchGrid.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DGV_SearchGrid_ColumnHeaderMouseClick);
            this.DGV_SearchGrid.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.DGV_SearchGrid_ColumnWidthChanged);
            this.DGV_SearchGrid.CurrentCellDirtyStateChanged += new System.EventHandler(this.DGV_SearchGrid_CurrentCellDirtyStateChanged);
            this.DGV_SearchGrid.Scroll += new System.Windows.Forms.ScrollEventHandler(this.DGV_SearchGrid_Scroll);
            // 
            // clmdsno
            // 
            this.clmdsno.HeaderText = "S.No.";
            this.clmdsno.MinimumWidth = 6;
            this.clmdsno.Name = "clmdsno";
            this.clmdsno.Width = 75;
            // 
            // clmdconcern
            // 
            this.clmdconcern.HeaderText = "Concern";
            this.clmdconcern.Name = "clmdconcern";
            this.clmdconcern.ReadOnly = true;
            // 
            // clmdgrndate
            // 
            this.clmdgrndate.HeaderText = "GRN Date";
            this.clmdgrndate.MinimumWidth = 6;
            this.clmdgrndate.Name = "clmdgrndate";
            // 
            // clmdGrnno
            // 
            this.clmdGrnno.HeaderText = "GRN No.";
            this.clmdGrnno.MinimumWidth = 6;
            this.clmdGrnno.Name = "clmdGrnno";
            // 
            // clmdsupplier
            // 
            this.clmdsupplier.HeaderText = "Supplier Name";
            this.clmdsupplier.Name = "clmdsupplier";
            this.clmdsupplier.ReadOnly = true;
            this.clmdsupplier.Width = 200;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "City";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "GSTIN";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // clmdinvoicedate
            // 
            this.clmdinvoicedate.HeaderText = "Invoice Date";
            this.clmdinvoicedate.Name = "clmdinvoicedate";
            this.clmdinvoicedate.ReadOnly = true;
            // 
            // clmdinvoice
            // 
            this.clmdinvoice.HeaderText = "Invoice No.";
            this.clmdinvoice.Name = "clmdinvoice";
            this.clmdinvoice.ReadOnly = true;
            // 
            // clmdinvoiceamt
            // 
            this.clmdinvoiceamt.HeaderText = "Invoice Amount";
            this.clmdinvoiceamt.Name = "clmdinvoiceamt";
            this.clmdinvoiceamt.ReadOnly = true;
            // 
            // clmdordertype
            // 
            this.clmdordertype.HeaderText = "Order Type";
            this.clmdordertype.Name = "clmdordertype";
            this.clmdordertype.ReadOnly = true;
            // 
            // AnyPurchaseReturns
            // 
            this.AnyPurchaseReturns.HeaderText = "Any Purchase Returns";
            this.AnyPurchaseReturns.Name = "AnyPurchaseReturns";
            this.AnyPurchaseReturns.Width = 150;
            // 
            // Createby
            // 
            this.Createby.HeaderText = "Created By";
            this.Createby.Name = "Createby";
            // 
            // CreatedOn
            // 
            this.CreatedOn.HeaderText = "Created On";
            this.CreatedOn.Name = "CreatedOn";
            // 
            // grdGRNList
            // 
            this.grdGRNList.AllowUserToAddRows = false;
            this.grdGRNList.AllowUserToDeleteRows = false;
            this.grdGRNList.AllowUserToResizeColumns = false;
            this.grdGRNList.AllowUserToResizeRows = false;
            this.grdGRNList.BackgroundColor = System.Drawing.Color.White;
            this.grdGRNList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdGRNList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.grdGRNList.ColumnHeadersHeight = 30;
            this.grdGRNList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdGRNList.ColumnHeadersVisible = false;
            this.grdGRNList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ClmEdit,
            this.clmPrint});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdGRNList.DefaultCellStyle = dataGridViewCellStyle5;
            this.grdGRNList.EnableHeadersVisualStyles = false;
            this.grdGRNList.GridColor = System.Drawing.Color.White;
            this.grdGRNList.Location = new System.Drawing.Point(3, 130);
            this.grdGRNList.Name = "grdGRNList";
            this.grdGRNList.ReadOnly = true;
            this.grdGRNList.RowHeadersVisible = false;
            this.grdGRNList.RowHeadersWidth = 100;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.grdGRNList.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.grdGRNList.RowTemplate.Height = 25;
            this.grdGRNList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdGRNList.Size = new System.Drawing.Size(1348, 510);
            this.grdGRNList.TabIndex = 958797;
            this.grdGRNList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrdPurchaseApproval_CellContentClick);
            this.grdGRNList.Scroll += new System.Windows.Forms.ScrollEventHandler(this.GrdGRNList_Scroll);
            this.grdGRNList.DoubleClick += new System.EventHandler(this.GrdPurchaseApproval_DoubleClick);
            this.grdGRNList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GrdGRNList_KeyDown);
            // 
            // ClmEdit
            // 
            this.ClmEdit.HeaderText = "Edit";
            this.ClmEdit.Image = global::ROMS.Properties.Resources.Edit;
            this.ClmEdit.Name = "ClmEdit";
            this.ClmEdit.ReadOnly = true;
            this.ClmEdit.Width = 50;
            // 
            // clmPrint
            // 
            this.clmPrint.HeaderText = "Reprint";
            this.clmPrint.Image = global::ROMS.Properties.Resources.print16x16__2_;
            this.clmPrint.Name = "clmPrint";
            this.clmPrint.ReadOnly = true;
            this.clmPrint.Width = 50;
            // 
            // picLoader
            // 
            this.picLoader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picLoader.ErrorImage = null;
            this.picLoader.Image = global::ROMS.Properties.Resources.Iphone_spinner_2;
            this.picLoader.InitialImage = null;
            this.picLoader.Location = new System.Drawing.Point(3, 130);
            this.picLoader.Name = "picLoader";
            this.picLoader.Size = new System.Drawing.Size(1348, 510);
            this.picLoader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picLoader.TabIndex = 1111184;
            this.picLoader.TabStop = false;
            this.picLoader.Visible = false;
            // 
            // PUR_GRNDetailsList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(1354, 675);
            this.Controls.Add(this.pnlpurchaseapproval);
            this.Controls.Add(this.tsBrandList);
            this.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "PUR_GRNDetailsList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Goods Receipt";
            this.Load += new System.EventHandler(this.PUR_GRNDetailsList_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PUR_GRNDetailsList_KeyDown);
            this.tsBrandList.ResumeLayout(false);
            this.tsBrandList.PerformLayout();
            this.pnlpurchaseapproval.ResumeLayout(false);
            this.pnlpurchaseapproval.PerformLayout();
            this.grpfilter.ResumeLayout(false);
            this.grpfilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_SearchGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdGRNList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsBrandList;
        private System.Windows.Forms.ToolStripLabel tspHeader;
        private System.Windows.Forms.Panel pnlpurchaseapproval;
        public System.Windows.Forms.DataGridView DGV_SearchGrid;
        public System.Windows.Forms.DataGridView grdGRNList;
        private System.Windows.Forms.GroupBox grpfilter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dpFromDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.DateTimePicker dpToDate;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.ComboBox cmbOrdertype;
        public System.Windows.Forms.ToolStripButton tsbDelete;
        public System.Windows.Forms.ToolStripSeparator tssEdit;
        public System.Windows.Forms.ToolStripButton tsbEdit;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        public System.Windows.Forms.ToolStripButton tsbNew;
        private System.Windows.Forms.ComboBox cmbConcern;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmdsno;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmdconcern;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmdgrndate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmdGrnno;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmdsupplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmdinvoicedate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmdinvoice;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmdinvoiceamt;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmdordertype;
        private System.Windows.Forms.DataGridViewTextBoxColumn AnyPurchaseReturns;
        private System.Windows.Forms.DataGridViewTextBoxColumn Createby;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreatedOn;
        public System.Windows.Forms.ListView LV_Supplier;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.TextBox txtSupplier;
        public System.Windows.Forms.Label lblSupplierCode;
        public System.Windows.Forms.Label lblschedleCode;
        public System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblNoRecordsFound;
        private System.Windows.Forms.PictureBox picLoader;
        private System.Windows.Forms.DataGridViewImageColumn ClmEdit;
        private System.Windows.Forms.DataGridViewImageColumn clmPrint;
    }
}