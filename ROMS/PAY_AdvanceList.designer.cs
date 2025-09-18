namespace ROMS
{
    partial class PAY_AdvanceList
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
            this.tsAdvanceList = new System.Windows.Forms.ToolStrip();
            this.tspHeader = new System.Windows.Forms.ToolStripLabel();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.tssEdit = new System.Windows.Forms.ToolStripSeparator();
            this.tsbEdit = new System.Windows.Forms.ToolStripButton();
            this.tssNew = new System.Windows.Forms.ToolStripSeparator();
            this.tsbNew = new System.Windows.Forms.ToolStripButton();
            this.pnlunitlist = new System.Windows.Forms.Panel();
            this.LV_Supplier = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grpfilter = new System.Windows.Forms.GroupBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.lblSupplierCode = new System.Windows.Forms.Label();
            this.lblschedleCode = new System.Windows.Forms.Label();
            this.cmbstatus = new System.Windows.Forms.ComboBox();
            this.cmbConcern = new System.Windows.Forms.ComboBox();
            this.txtSupplier = new System.Windows.Forms.TextBox();
            this.btnView = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dpToDate = new System.Windows.Forms.DateTimePicker();
            this.dpFromDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.DGV_SearchGrid = new System.Windows.Forms.DataGridView();
            this.grdAdvanceList = new System.Windows.Forms.DataGridView();
            this.lblNoRecordsFound = new System.Windows.Forms.Label();
            this.picLoader = new System.Windows.Forms.PictureBox();
            this.clmChequePrint = new System.Windows.Forms.DataGridViewImageColumn();
            this.clmPrint = new System.Windows.Forms.DataGridViewImageColumn();
            this.clmEnvelopPrint = new System.Windows.Forms.DataGridViewImageColumn();
            this.tsAdvanceList.SuspendLayout();
            this.pnlunitlist.SuspendLayout();
            this.grpfilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_SearchGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAdvanceList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).BeginInit();
            this.SuspendLayout();
            // 
            // tsAdvanceList
            // 
            this.tsAdvanceList.BackColor = System.Drawing.Color.White;
            this.tsAdvanceList.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsAdvanceList.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsAdvanceList.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsAdvanceList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspHeader,
            this.tsbDelete,
            this.tssEdit,
            this.tsbEdit,
            this.tssNew,
            this.tsbNew});
            this.tsAdvanceList.Location = new System.Drawing.Point(0, 0);
            this.tsAdvanceList.Name = "tsAdvanceList";
            this.tsAdvanceList.Size = new System.Drawing.Size(1354, 27);
            this.tsAdvanceList.TabIndex = 35;
            this.tsAdvanceList.Text = "Advance";
            // 
            // tspHeader
            // 
            this.tspHeader.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tspHeader.Image = global::ROMS.Properties.Resources.bread_crumb;
            this.tspHeader.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tspHeader.Margin = new System.Windows.Forms.Padding(15, 1, 0, 2);
            this.tspHeader.Name = "tspHeader";
            this.tspHeader.Size = new System.Drawing.Size(70, 24);
            this.tspHeader.Text = "Advance";
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
            this.tsbEdit.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.tsbNew.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            // pnlunitlist
            // 
            this.pnlunitlist.BackColor = System.Drawing.Color.White;
            this.pnlunitlist.Controls.Add(this.LV_Supplier);
            this.pnlunitlist.Controls.Add(this.grpfilter);
            this.pnlunitlist.Controls.Add(this.DGV_SearchGrid);
            this.pnlunitlist.Controls.Add(this.grdAdvanceList);
            this.pnlunitlist.Location = new System.Drawing.Point(0, 31);
            this.pnlunitlist.Name = "pnlunitlist";
            this.pnlunitlist.Size = new System.Drawing.Size(1354, 641);
            this.pnlunitlist.TabIndex = 36;
            // 
            // LV_Supplier
            // 
            this.LV_Supplier.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.LV_Supplier.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.LV_Supplier.HideSelection = false;
            this.LV_Supplier.Location = new System.Drawing.Point(615, 57);
            this.LV_Supplier.Name = "LV_Supplier";
            this.LV_Supplier.Size = new System.Drawing.Size(362, 93);
            this.LV_Supplier.TabIndex = 1111180;
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
            this.grpfilter.Controls.Add(this.btnExport);
            this.grpfilter.Controls.Add(this.label5);
            this.grpfilter.Controls.Add(this.lblSupplierCode);
            this.grpfilter.Controls.Add(this.lblschedleCode);
            this.grpfilter.Controls.Add(this.cmbstatus);
            this.grpfilter.Controls.Add(this.cmbConcern);
            this.grpfilter.Controls.Add(this.txtSupplier);
            this.grpfilter.Controls.Add(this.btnView);
            this.grpfilter.Controls.Add(this.label10);
            this.grpfilter.Controls.Add(this.label2);
            this.grpfilter.Controls.Add(this.dpToDate);
            this.grpfilter.Controls.Add(this.dpFromDate);
            this.grpfilter.Controls.Add(this.label1);
            this.grpfilter.Location = new System.Drawing.Point(3, 2);
            this.grpfilter.Name = "grpfilter";
            this.grpfilter.Size = new System.Drawing.Size(1348, 67);
            this.grpfilter.TabIndex = 0;
            this.grpfilter.TabStop = false;
            this.grpfilter.Text = "Filter By";
            // 
            // btnExport
            // 
            this.btnExport.Image = global::ROMS.Properties.Resources.excel;
            this.btnExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExport.Location = new System.Drawing.Point(1110, 25);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(34, 33);
            this.btnExport.TabIndex = 1111185;
            this.btnExport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.BtnExport_Click);
            this.btnExport.Enter += new System.EventHandler(this.BtnExport_Enter);
            this.btnExport.Leave += new System.EventHandler(this.BtnExport_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(891, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 20);
            this.label5.TabIndex = 1111184;
            this.label5.Text = "Status";
            // 
            // lblSupplierCode
            // 
            this.lblSupplierCode.AutoSize = true;
            this.lblSupplierCode.BackColor = System.Drawing.Color.Green;
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
            this.lblschedleCode.BackColor = System.Drawing.Color.LimeGreen;
            this.lblschedleCode.Location = new System.Drawing.Point(942, 4);
            this.lblschedleCode.Name = "lblschedleCode";
            this.lblschedleCode.Size = new System.Drawing.Size(16, 20);
            this.lblschedleCode.TabIndex = 1111181;
            this.lblschedleCode.Text = "0";
            this.lblschedleCode.Visible = false;
            // 
            // cmbstatus
            // 
            this.cmbstatus.FormattingEnabled = true;
            this.cmbstatus.Location = new System.Drawing.Point(942, 28);
            this.cmbstatus.Name = "cmbstatus";
            this.cmbstatus.Size = new System.Drawing.Size(122, 27);
            this.cmbstatus.TabIndex = 4;
            this.cmbstatus.Enter += new System.EventHandler(this.Cmbstatus_Enter);
            this.cmbstatus.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Cmbstatus_KeyDown);
            this.cmbstatus.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Cmbstatus_KeyPress);
            this.cmbstatus.Leave += new System.EventHandler(this.Cmbstatus_Leave);
            // 
            // cmbConcern
            // 
            this.cmbConcern.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbConcern.FormattingEnabled = true;
            this.cmbConcern.Location = new System.Drawing.Point(64, 28);
            this.cmbConcern.Name = "cmbConcern";
            this.cmbConcern.Size = new System.Drawing.Size(117, 27);
            this.cmbConcern.TabIndex = 0;
            this.cmbConcern.Enter += new System.EventHandler(this.CmbConcern_Enter);
            this.cmbConcern.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbConcern_KeyDown);
            this.cmbConcern.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbConcern_KeyPress);
            this.cmbConcern.Leave += new System.EventHandler(this.CmbConcern_Leave);
            // 
            // txtSupplier
            // 
            this.txtSupplier.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtSupplier.Location = new System.Drawing.Point(612, 28);
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
            this.btnView.Location = new System.Drawing.Point(1070, 25);
            this.btnView.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(34, 33);
            this.btnView.TabIndex = 5;
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
            this.label10.Location = new System.Drawing.Point(4, 31);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 20);
            this.label10.TabIndex = 1111166;
            this.label10.Text = "Concern";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(519, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 20);
            this.label2.TabIndex = 1111140;
            this.label2.Text = "Supplier Name";
            // 
            // dpToDate
            // 
            this.dpToDate.CustomFormat = "dd/MM/yyyy";
            this.dpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpToDate.Location = new System.Drawing.Point(406, 28);
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
            this.dpFromDate.Location = new System.Drawing.Point(293, 28);
            this.dpFromDate.Name = "dpFromDate";
            this.dpFromDate.Size = new System.Drawing.Size(107, 27);
            this.dpFromDate.TabIndex = 1;
            this.dpFromDate.ValueChanged += new System.EventHandler(this.DpFromDate_ValueChanged);
            this.dpFromDate.Enter += new System.EventHandler(this.DpFromDate_Enter);
            this.dpFromDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DpFromDate_KeyDown);
            this.dpFromDate.Leave += new System.EventHandler(this.DpFromDate_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(187, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.TabIndex = 1111139;
            this.label1.Text = "Transaction Date";
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
            this.DGV_SearchGrid.RowHeadersWidth = 70;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.DGV_SearchGrid.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.DGV_SearchGrid.RowTemplate.Height = 25;
            this.DGV_SearchGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DGV_SearchGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DGV_SearchGrid.ShowRowErrors = false;
            this.DGV_SearchGrid.Size = new System.Drawing.Size(1348, 56);
            this.DGV_SearchGrid.TabIndex = 958800;
            this.DGV_SearchGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_SearchGrid_CellEndEdit);
            this.DGV_SearchGrid.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.DGV_SearchGrid_CellPainting);
            this.DGV_SearchGrid.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DGV_SearchGrid_ColumnHeaderMouseClick);
            this.DGV_SearchGrid.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.DGV_SearchGrid_ColumnWidthChanged);
            this.DGV_SearchGrid.CurrentCellDirtyStateChanged += new System.EventHandler(this.DGV_SearchGrid_CurrentCellDirtyStateChanged);
            this.DGV_SearchGrid.Scroll += new System.Windows.Forms.ScrollEventHandler(this.DGV_SearchGrid_Scroll);
            // 
            // grdAdvanceList
            // 
            this.grdAdvanceList.AllowUserToAddRows = false;
            this.grdAdvanceList.AllowUserToDeleteRows = false;
            this.grdAdvanceList.AllowUserToResizeColumns = false;
            this.grdAdvanceList.AllowUserToResizeRows = false;
            this.grdAdvanceList.BackgroundColor = System.Drawing.Color.White;
            this.grdAdvanceList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(242)))), ((int)(((byte)(213)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdAdvanceList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.grdAdvanceList.ColumnHeadersHeight = 30;
            this.grdAdvanceList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdAdvanceList.ColumnHeadersVisible = false;
            this.grdAdvanceList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmChequePrint,
            this.clmPrint,
            this.clmEnvelopPrint});
            this.grdAdvanceList.EnableHeadersVisualStyles = false;
            this.grdAdvanceList.GridColor = System.Drawing.Color.White;
            this.grdAdvanceList.Location = new System.Drawing.Point(3, 130);
            this.grdAdvanceList.Name = "grdAdvanceList";
            this.grdAdvanceList.ReadOnly = true;
            this.grdAdvanceList.RowHeadersVisible = false;
            this.grdAdvanceList.RowHeadersWidth = 100;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            this.grdAdvanceList.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.grdAdvanceList.RowTemplate.Height = 25;
            this.grdAdvanceList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdAdvanceList.Size = new System.Drawing.Size(1348, 510);
            this.grdAdvanceList.TabIndex = 958797;
            this.grdAdvanceList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrdAdvanceList_CellContentClick);
            this.grdAdvanceList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.GrdAdvanceList_DataBindingComplete);
            this.grdAdvanceList.Scroll += new System.Windows.Forms.ScrollEventHandler(this.GrdUnitList_Scroll);
            this.grdAdvanceList.SelectionChanged += new System.EventHandler(this.GrdAdvanceList_SelectionChanged);
            this.grdAdvanceList.DoubleClick += new System.EventHandler(this.GrdAdvanceList_DoubleClick);
            this.grdAdvanceList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GrdAdvanceList_KeyDown);
            // 
            // lblNoRecordsFound
            // 
            this.lblNoRecordsFound.AutoSize = true;
            this.lblNoRecordsFound.BackColor = System.Drawing.Color.White;
            this.lblNoRecordsFound.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoRecordsFound.Location = new System.Drawing.Point(624, 375);
            this.lblNoRecordsFound.Name = "lblNoRecordsFound";
            this.lblNoRecordsFound.Size = new System.Drawing.Size(106, 20);
            this.lblNoRecordsFound.TabIndex = 958798;
            this.lblNoRecordsFound.Text = "No Records Found";
            this.lblNoRecordsFound.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // picLoader
            // 
            this.picLoader.BackColor = System.Drawing.Color.White;
            this.picLoader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picLoader.ErrorImage = null;
            this.picLoader.Image = global::ROMS.Properties.Resources.Iphone_spinner_2;
            this.picLoader.InitialImage = null;
            this.picLoader.Location = new System.Drawing.Point(0, 30);
            this.picLoader.Name = "picLoader";
            this.picLoader.Size = new System.Drawing.Size(1354, 642);
            this.picLoader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picLoader.TabIndex = 958799;
            this.picLoader.TabStop = false;
            this.picLoader.Visible = false;
            // 
            // clmChequePrint
            // 
            this.clmChequePrint.HeaderText = "Cheque Print";
            this.clmChequePrint.Image = global::ROMS.Properties.Resources.print16x16__2_;
            this.clmChequePrint.Name = "clmChequePrint";
            this.clmChequePrint.ReadOnly = true;
            this.clmChequePrint.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmChequePrint.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // clmPrint
            // 
            this.clmPrint.HeaderText = "";
            this.clmPrint.Image = global::ROMS.Properties.Resources.print16x16__2_;
            this.clmPrint.Name = "clmPrint";
            this.clmPrint.ReadOnly = true;
            this.clmPrint.Width = 50;
            // 
            // clmEnvelopPrint
            // 
            this.clmEnvelopPrint.HeaderText = "Envelope Print";
            this.clmEnvelopPrint.Image = global::ROMS.Properties.Resources.Envelope_Print;
            this.clmEnvelopPrint.Name = "clmEnvelopPrint";
            this.clmEnvelopPrint.ReadOnly = true;
            // 
            // PAY_AdvanceList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(1354, 675);
            this.Controls.Add(this.lblNoRecordsFound);
            this.Controls.Add(this.pnlunitlist);
            this.Controls.Add(this.tsAdvanceList);
            this.Controls.Add(this.picLoader);
            this.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "PAY_AdvanceList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Advance";
            this.Load += new System.EventHandler(this.PAY_AdvanceList_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PAY_AdvanceList_KeyDown);
            this.tsAdvanceList.ResumeLayout(false);
            this.tsAdvanceList.PerformLayout();
            this.pnlunitlist.ResumeLayout(false);
            this.grpfilter.ResumeLayout(false);
            this.grpfilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_SearchGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAdvanceList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsAdvanceList;
        private System.Windows.Forms.ToolStripLabel tspHeader;
        public System.Windows.Forms.ToolStripButton tsbDelete;
        public System.Windows.Forms.ToolStripSeparator tssEdit;
        public System.Windows.Forms.ToolStripButton tsbEdit;
        public System.Windows.Forms.ToolStripSeparator tssNew;
        public System.Windows.Forms.ToolStripButton tsbNew;
        private System.Windows.Forms.Panel pnlunitlist;
        public System.Windows.Forms.DataGridView DGV_SearchGrid;
        private System.Windows.Forms.Label lblNoRecordsFound;
        public System.Windows.Forms.DataGridView grdAdvanceList;
        public System.Windows.Forms.PictureBox picLoader;
        private System.Windows.Forms.GroupBox grpfilter;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label lblSupplierCode;
        public System.Windows.Forms.Label lblschedleCode;
        public System.Windows.Forms.ComboBox cmbstatus;
        private System.Windows.Forms.ComboBox cmbConcern;
        private System.Windows.Forms.TextBox txtSupplier;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dpFromDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dpToDate;
        public System.Windows.Forms.ListView LV_Supplier;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.DataGridViewImageColumn clmChequePrint;
        private System.Windows.Forms.DataGridViewImageColumn clmPrint;
        private System.Windows.Forms.DataGridViewImageColumn clmEnvelopPrint;
    }
}