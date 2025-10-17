namespace ROMS
{
    partial class PAY_CreditNoteList
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
            this.tsCreditNote = new System.Windows.Forms.ToolStrip();
            this.tspHeader = new System.Windows.Forms.ToolStripLabel();
            this.tsbEdit = new System.Windows.Forms.ToolStripButton();
            this.lblNoRecordsFound = new System.Windows.Forms.Label();
            this.picLoader = new System.Windows.Forms.PictureBox();
            this.pnlbrand = new System.Windows.Forms.Panel();
            this.LV_Supplier = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grdCreditNoteList = new System.Windows.Forms.DataGridView();
            this.clmPrint = new System.Windows.Forms.DataGridViewImageColumn();
            this.DGV_SearchGrid = new System.Windows.Forms.DataGridView();
            this.grbFilterBy = new System.Windows.Forms.GroupBox();
            this.cmbConcern = new System.Windows.Forms.ComboBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.dpToDate = new System.Windows.Forms.DateTimePicker();
            this.txtSupplier = new System.Windows.Forms.TextBox();
            this.lblDSupplier = new System.Windows.Forms.Label();
            this.dpFromDate = new System.Windows.Forms.DateTimePicker();
            this.lblTransactiondate = new System.Windows.Forms.Label();
            this.lblDConcern = new System.Windows.Forms.Label();
            this.btnView = new System.Windows.Forms.Button();
            this.tss = new System.Windows.Forms.ToolStripSeparator();
            this.tsCreditNote.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).BeginInit();
            this.pnlbrand.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCreditNoteList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_SearchGrid)).BeginInit();
            this.grbFilterBy.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsCreditNote
            // 
            this.tsCreditNote.BackColor = System.Drawing.Color.White;
            this.tsCreditNote.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsCreditNote.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsCreditNote.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspHeader,
            this.tss,
            this.tsbEdit});
            this.tsCreditNote.Location = new System.Drawing.Point(0, 0);
            this.tsCreditNote.Name = "tsCreditNote";
            this.tsCreditNote.Size = new System.Drawing.Size(1354, 27);
            this.tsCreditNote.TabIndex = 35;
            this.tsCreditNote.Text = "Brand";
            // 
            // tspHeader
            // 
            this.tspHeader.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tspHeader.Image = global::ROMS.Properties.Resources.bread_crumb;
            this.tspHeader.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tspHeader.Margin = new System.Windows.Forms.Padding(15, 1, 0, 2);
            this.tspHeader.Name = "tspHeader";
            this.tspHeader.Size = new System.Drawing.Size(87, 24);
            this.tspHeader.Text = "Credit Note";
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
            this.tsbEdit.Click += new System.EventHandler(this.TsbEdit_Click);
            // 
            // lblNoRecordsFound
            // 
            this.lblNoRecordsFound.AutoSize = true;
            this.lblNoRecordsFound.BackColor = System.Drawing.Color.White;
            this.lblNoRecordsFound.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoRecordsFound.Location = new System.Drawing.Point(624, 350);
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
            this.picLoader.Image = global::ROMS.Properties.Resources.Iphone_spinner_2;
            this.picLoader.InitialImage = null;
            this.picLoader.Location = new System.Drawing.Point(3, 77);
            this.picLoader.Name = "picLoader";
            this.picLoader.Size = new System.Drawing.Size(1351, 564);
            this.picLoader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picLoader.TabIndex = 958787;
            this.picLoader.TabStop = false;
            this.picLoader.Visible = false;
            // 
            // pnlbrand
            // 
            this.pnlbrand.BackColor = System.Drawing.Color.White;
            this.pnlbrand.Controls.Add(this.LV_Supplier);
            this.pnlbrand.Controls.Add(this.grdCreditNoteList);
            this.pnlbrand.Controls.Add(this.DGV_SearchGrid);
            this.pnlbrand.Controls.Add(this.grbFilterBy);
            this.pnlbrand.Controls.Add(this.lblNoRecordsFound);
            this.pnlbrand.Controls.Add(this.picLoader);
            this.pnlbrand.Location = new System.Drawing.Point(0, 31);
            this.pnlbrand.Name = "pnlbrand";
            this.pnlbrand.Size = new System.Drawing.Size(1354, 641);
            this.pnlbrand.TabIndex = 958797;
            // 
            // LV_Supplier
            // 
            this.LV_Supplier.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader1});
            this.LV_Supplier.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.LV_Supplier.HideSelection = false;
            this.LV_Supplier.Location = new System.Drawing.Point(608, 52);
            this.LV_Supplier.Name = "LV_Supplier";
            this.LV_Supplier.Size = new System.Drawing.Size(401, 111);
            this.LV_Supplier.TabIndex = 1111209;
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
            // grdCreditNoteList
            // 
            this.grdCreditNoteList.AllowUserToAddRows = false;
            this.grdCreditNoteList.AllowUserToDeleteRows = false;
            this.grdCreditNoteList.AllowUserToResizeColumns = false;
            this.grdCreditNoteList.AllowUserToResizeRows = false;
            this.grdCreditNoteList.BackgroundColor = System.Drawing.Color.White;
            this.grdCreditNoteList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(242)))), ((int)(((byte)(213)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdCreditNoteList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdCreditNoteList.ColumnHeadersHeight = 30;
            this.grdCreditNoteList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdCreditNoteList.ColumnHeadersVisible = false;
            this.grdCreditNoteList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmPrint});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdCreditNoteList.DefaultCellStyle = dataGridViewCellStyle2;
            this.grdCreditNoteList.EnableHeadersVisualStyles = false;
            this.grdCreditNoteList.GridColor = System.Drawing.Color.White;
            this.grdCreditNoteList.Location = new System.Drawing.Point(3, 130);
            this.grdCreditNoteList.Name = "grdCreditNoteList";
            this.grdCreditNoteList.ReadOnly = true;
            this.grdCreditNoteList.RowHeadersVisible = false;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.grdCreditNoteList.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.grdCreditNoteList.RowTemplate.Height = 25;
            this.grdCreditNoteList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdCreditNoteList.Size = new System.Drawing.Size(1348, 508);
            this.grdCreditNoteList.TabIndex = 1110000989;
            this.grdCreditNoteList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrdCreditNoteList_CellDoubleClick);
            this.grdCreditNoteList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.GrdCreditNoteList_DataBindingComplete);
            this.grdCreditNoteList.Scroll += new System.Windows.Forms.ScrollEventHandler(this.GrdCreditNoteList_Scroll);
            this.grdCreditNoteList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GrdCreditNoteList_KeyDown);
            // 
            // clmPrint
            // 
            this.clmPrint.HeaderText = "Print";
            this.clmPrint.Image = global::ROMS.Properties.Resources.print16x16__2_;
            this.clmPrint.Name = "clmPrint";
            this.clmPrint.ReadOnly = true;
            this.clmPrint.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmPrint.Width = 60;
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
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            this.DGV_SearchGrid.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.DGV_SearchGrid.RowTemplate.Height = 25;
            this.DGV_SearchGrid.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.DGV_SearchGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DGV_SearchGrid.ShowRowErrors = false;
            this.DGV_SearchGrid.Size = new System.Drawing.Size(1348, 56);
            this.DGV_SearchGrid.TabIndex = 111111136;
            this.DGV_SearchGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_SearchGrid_CellEndEdit_1);
            this.DGV_SearchGrid.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.DGV_SearchGrid_CellPainting_1);
            this.DGV_SearchGrid.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DGV_SearchGrid_ColumnHeaderMouseClick_1);
            this.DGV_SearchGrid.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.DGV_SearchGrid_ColumnWidthChanged_1);
            this.DGV_SearchGrid.CurrentCellDirtyStateChanged += new System.EventHandler(this.DGV_SearchGrid_CurrentCellDirtyStateChanged);
            this.DGV_SearchGrid.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.DGV_SearchGrid_EditingControlShowing);
            this.DGV_SearchGrid.Scroll += new System.Windows.Forms.ScrollEventHandler(this.DGV_SearchGrid_Scroll);
            // 
            // grbFilterBy
            // 
            this.grbFilterBy.Controls.Add(this.cmbConcern);
            this.grbFilterBy.Controls.Add(this.btnExport);
            this.grbFilterBy.Controls.Add(this.dpToDate);
            this.grbFilterBy.Controls.Add(this.txtSupplier);
            this.grbFilterBy.Controls.Add(this.lblDSupplier);
            this.grbFilterBy.Controls.Add(this.dpFromDate);
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
            // cmbConcern
            // 
            this.cmbConcern.FormattingEnabled = true;
            this.cmbConcern.Location = new System.Drawing.Point(86, 23);
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
            this.btnExport.Location = new System.Drawing.Point(1012, 22);
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
            // dpToDate
            // 
            this.dpToDate.CustomFormat = "dd/MM/yyyy";
            this.dpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpToDate.Location = new System.Drawing.Point(437, 23);
            this.dpToDate.Name = "dpToDate";
            this.dpToDate.Size = new System.Drawing.Size(104, 27);
            this.dpToDate.TabIndex = 2;
            this.dpToDate.Enter += new System.EventHandler(this.DpToDate_Enter);
            this.dpToDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DpToDate_KeyDown);
            this.dpToDate.Leave += new System.EventHandler(this.DpToDate_Leave);
            // 
            // txtSupplier
            // 
            this.txtSupplier.Location = new System.Drawing.Point(605, 23);
            this.txtSupplier.MaxLength = 2;
            this.txtSupplier.Name = "txtSupplier";
            this.txtSupplier.Size = new System.Drawing.Size(321, 27);
            this.txtSupplier.TabIndex = 3;
            this.txtSupplier.TextChanged += new System.EventHandler(this.TxtSupplier_TextChanged);
            this.txtSupplier.Enter += new System.EventHandler(this.TxtSupplier_Enter);
            this.txtSupplier.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtSupplier_KeyDown);
            this.txtSupplier.Leave += new System.EventHandler(this.TxtSupplier_Leave);
            // 
            // lblDSupplier
            // 
            this.lblDSupplier.AutoSize = true;
            this.lblDSupplier.Location = new System.Drawing.Point(546, 26);
            this.lblDSupplier.Name = "lblDSupplier";
            this.lblDSupplier.Size = new System.Drawing.Size(54, 20);
            this.lblDSupplier.TabIndex = 958811;
            this.lblDSupplier.Text = "Supplier";
            // 
            // dpFromDate
            // 
            this.dpFromDate.CustomFormat = "dd/MM/yyyy";
            this.dpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpFromDate.Location = new System.Drawing.Point(328, 23);
            this.dpFromDate.Name = "dpFromDate";
            this.dpFromDate.Size = new System.Drawing.Size(104, 27);
            this.dpFromDate.TabIndex = 1;
            this.dpFromDate.ValueChanged += new System.EventHandler(this.DpFromDate_ValueChanged);
            this.dpFromDate.Enter += new System.EventHandler(this.DpFromDate_Enter);
            this.dpFromDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DpFromDate_KeyDown);
            this.dpFromDate.Leave += new System.EventHandler(this.DpFromDate_Leave);
            // 
            // lblTransactiondate
            // 
            this.lblTransactiondate.AutoSize = true;
            this.lblTransactiondate.Location = new System.Drawing.Point(222, 26);
            this.lblTransactiondate.Name = "lblTransactiondate";
            this.lblTransactiondate.Size = new System.Drawing.Size(100, 20);
            this.lblTransactiondate.TabIndex = 92;
            this.lblTransactiondate.Text = "Transaction Date";
            // 
            // lblDConcern
            // 
            this.lblDConcern.AutoSize = true;
            this.lblDConcern.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.lblDConcern.Location = new System.Drawing.Point(28, 26);
            this.lblDConcern.Name = "lblDConcern";
            this.lblDConcern.Size = new System.Drawing.Size(54, 20);
            this.lblDConcern.TabIndex = 36;
            this.lblDConcern.Text = "Concern";
            // 
            // btnView
            // 
            this.btnView.Image = global::ROMS.Properties.Resources.view;
            this.btnView.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnView.Location = new System.Drawing.Point(932, 22);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(75, 29);
            this.btnView.TabIndex = 4;
            this.btnView.Text = "View";
            this.btnView.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.BtnView_Click);
            this.btnView.Enter += new System.EventHandler(this.BtnView_Enter);
            this.btnView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BtnView_KeyDown);
            this.btnView.Leave += new System.EventHandler(this.BtnView_Leave);
            // 
            // tss
            // 
            this.tss.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tss.Margin = new System.Windows.Forms.Padding(0, 1, 2, 2);
            this.tss.Name = "tss";
            this.tss.Size = new System.Drawing.Size(6, 24);
            // 
            // PAY_CreditNoteList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(1354, 675);
            this.Controls.Add(this.pnlbrand);
            this.Controls.Add(this.tsCreditNote);
            this.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "PAY_CreditNoteList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Credit Note";
            this.Load += new System.EventHandler(this.PAY_CreditNoteList_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PAY_CreditNoteList_KeyDown);
            this.tsCreditNote.ResumeLayout(false);
            this.tsCreditNote.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).EndInit();
            this.pnlbrand.ResumeLayout(false);
            this.pnlbrand.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCreditNoteList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_SearchGrid)).EndInit();
            this.grbFilterBy.ResumeLayout(false);
            this.grbFilterBy.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsCreditNote;
        private System.Windows.Forms.ToolStripLabel tspHeader;
        private System.Windows.Forms.Label lblNoRecordsFound;
        private System.Windows.Forms.PictureBox picLoader;
        private System.Windows.Forms.Panel pnlbrand;
        private System.Windows.Forms.GroupBox grbFilterBy;
        private System.Windows.Forms.TextBox txtSupplier;
        private System.Windows.Forms.Label lblDSupplier;
        private System.Windows.Forms.DateTimePicker dpFromDate;
        private System.Windows.Forms.Label lblTransactiondate;
        private System.Windows.Forms.Label lblDConcern;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.DateTimePicker dpToDate;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.ComboBox cmbConcern;
        public System.Windows.Forms.ListView LV_Supplier;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        public System.Windows.Forms.DataGridView DGV_SearchGrid;
        public System.Windows.Forms.DataGridView grdCreditNoteList;
        private System.Windows.Forms.DataGridViewImageColumn clmPrint;
        public System.Windows.Forms.ToolStripButton tsbEdit;
        public System.Windows.Forms.ToolStripSeparator tss;
    }
}