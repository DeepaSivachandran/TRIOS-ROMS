namespace ROMS
{
    partial class PAY_BlockedSupplier
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tsBlockSupplier = new System.Windows.Forms.ToolStrip();
            this.tspBlockedSupplier = new System.Windows.Forms.ToolStripLabel();
            this.lblNoRecordsFound = new System.Windows.Forms.Label();
            this.pnlBlockedSupplier = new System.Windows.Forms.Panel();
            this.grpSupplier = new System.Windows.Forms.GroupBox();
            this.lblSupplierCode = new System.Windows.Forms.Label();
            this.lblschedule = new System.Windows.Forms.Label();
            this.cmbReason = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.LV_Supplier = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtSupplier = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.DGV_SearchGrid = new System.Windows.Forms.DataGridView();
            this.grdBlockedSupplier = new System.Windows.Forms.DataGridView();
            this.clmDelete = new System.Windows.Forms.DataGridViewImageColumn();
            this.btnSave = new System.Windows.Forms.Button();
            this.epBlockedSupplier = new System.Windows.Forms.ErrorProvider(this.components);
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn3 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn4 = new System.Windows.Forms.DataGridViewImageColumn();
            this.tsBlockSupplier.SuspendLayout();
            this.pnlBlockedSupplier.SuspendLayout();
            this.grpSupplier.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_SearchGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBlockedSupplier)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epBlockedSupplier)).BeginInit();
            this.SuspendLayout();
            // 
            // tsBlockSupplier
            // 
            this.tsBlockSupplier.BackColor = System.Drawing.Color.White;
            this.tsBlockSupplier.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsBlockSupplier.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsBlockSupplier.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspBlockedSupplier});
            this.tsBlockSupplier.Location = new System.Drawing.Point(0, 0);
            this.tsBlockSupplier.Name = "tsBlockSupplier";
            this.tsBlockSupplier.Size = new System.Drawing.Size(1354, 25);
            this.tsBlockSupplier.TabIndex = 35;
            this.tsBlockSupplier.Text = "Stock Hold";
            // 
            // tspBlockedSupplier
            // 
            this.tspBlockedSupplier.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tspBlockedSupplier.Image = global::ROMS.Properties.Resources.bread_crumb;
            this.tspBlockedSupplier.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tspBlockedSupplier.Margin = new System.Windows.Forms.Padding(15, 1, 0, 2);
            this.tspBlockedSupplier.Name = "tspBlockedSupplier";
            this.tspBlockedSupplier.Size = new System.Drawing.Size(115, 22);
            this.tspBlockedSupplier.Text = "Blocked Supplier";
            // 
            // lblNoRecordsFound
            // 
            this.lblNoRecordsFound.AutoSize = true;
            this.lblNoRecordsFound.BackColor = System.Drawing.Color.White;
            this.lblNoRecordsFound.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoRecordsFound.Location = new System.Drawing.Point(627, 327);
            this.lblNoRecordsFound.Name = "lblNoRecordsFound";
            this.lblNoRecordsFound.Size = new System.Drawing.Size(106, 20);
            this.lblNoRecordsFound.TabIndex = 958763;
            this.lblNoRecordsFound.Text = "No Records Found";
            this.lblNoRecordsFound.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pnlBlockedSupplier
            // 
            this.pnlBlockedSupplier.BackColor = System.Drawing.Color.White;
            this.pnlBlockedSupplier.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBlockedSupplier.Controls.Add(this.grpSupplier);
            this.pnlBlockedSupplier.Location = new System.Drawing.Point(0, 29);
            this.pnlBlockedSupplier.Name = "pnlBlockedSupplier";
            this.pnlBlockedSupplier.Size = new System.Drawing.Size(1354, 644);
            this.pnlBlockedSupplier.TabIndex = 958764;
            // 
            // grpSupplier
            // 
            this.grpSupplier.BackColor = System.Drawing.Color.White;
            this.grpSupplier.Controls.Add(this.lblSupplierCode);
            this.grpSupplier.Controls.Add(this.lblschedule);
            this.grpSupplier.Controls.Add(this.cmbReason);
            this.grpSupplier.Controls.Add(this.label1);
            this.grpSupplier.Controls.Add(this.LV_Supplier);
            this.grpSupplier.Controls.Add(this.txtSupplier);
            this.grpSupplier.Controls.Add(this.label3);
            this.grpSupplier.Controls.Add(this.DGV_SearchGrid);
            this.grpSupplier.Controls.Add(this.grdBlockedSupplier);
            this.grpSupplier.Controls.Add(this.btnSave);
            this.grpSupplier.Location = new System.Drawing.Point(12, 3);
            this.grpSupplier.Name = "grpSupplier";
            this.grpSupplier.Size = new System.Drawing.Size(1329, 634);
            this.grpSupplier.TabIndex = 0;
            this.grpSupplier.TabStop = false;
            // 
            // lblSupplierCode
            // 
            this.lblSupplierCode.AutoSize = true;
            this.lblSupplierCode.Location = new System.Drawing.Point(851, 23);
            this.lblSupplierCode.Name = "lblSupplierCode";
            this.lblSupplierCode.Size = new System.Drawing.Size(16, 20);
            this.lblSupplierCode.TabIndex = 1110000996;
            this.lblSupplierCode.Text = "0";
            this.lblSupplierCode.Visible = false;
            // 
            // lblschedule
            // 
            this.lblschedule.AutoSize = true;
            this.lblschedule.Location = new System.Drawing.Point(829, 23);
            this.lblschedule.Name = "lblschedule";
            this.lblschedule.Size = new System.Drawing.Size(16, 20);
            this.lblschedule.TabIndex = 1110000997;
            this.lblschedule.Text = "0";
            this.lblschedule.Visible = false;
            // 
            // cmbReason
            // 
            this.cmbReason.FormattingEnabled = true;
            this.cmbReason.Location = new System.Drawing.Point(521, 20);
            this.cmbReason.Name = "cmbReason";
            this.cmbReason.Size = new System.Drawing.Size(213, 27);
            this.cmbReason.TabIndex = 1;
            this.cmbReason.Enter += new System.EventHandler(this.CmbReason_Enter);
            this.cmbReason.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbReason_KeyDown);
            this.cmbReason.Leave += new System.EventHandler(this.CmbReason_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(467, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 20);
            this.label1.TabIndex = 1110000995;
            this.label1.Text = "Reason";
            // 
            // LV_Supplier
            // 
            this.LV_Supplier.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader8,
            this.columnHeader9});
            this.LV_Supplier.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.LV_Supplier.HideSelection = false;
            this.LV_Supplier.Location = new System.Drawing.Point(66, 47);
            this.LV_Supplier.Name = "LV_Supplier";
            this.LV_Supplier.Size = new System.Drawing.Size(395, 135);
            this.LV_Supplier.TabIndex = 1110000994;
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
            // txtSupplier
            // 
            this.txtSupplier.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtSupplier.Location = new System.Drawing.Point(66, 20);
            this.txtSupplier.MaxLength = 100;
            this.txtSupplier.Name = "txtSupplier";
            this.txtSupplier.Size = new System.Drawing.Size(395, 27);
            this.txtSupplier.TabIndex = 0;
            this.txtSupplier.TextChanged += new System.EventHandler(this.TxtSupplier_TextChanged);
            this.txtSupplier.Enter += new System.EventHandler(this.TxtSupplier_Enter);
            this.txtSupplier.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtSupplier_KeyDown);
            this.txtSupplier.Leave += new System.EventHandler(this.TxtSupplier_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 20);
            this.label3.TabIndex = 1110000992;
            this.label3.Text = "Supplier";
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
            this.DGV_SearchGrid.Location = new System.Drawing.Point(6, 54);
            this.DGV_SearchGrid.Name = "DGV_SearchGrid";
            this.DGV_SearchGrid.RowHeadersVisible = false;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.DGV_SearchGrid.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.DGV_SearchGrid.RowTemplate.Height = 25;
            this.DGV_SearchGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DGV_SearchGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DGV_SearchGrid.ShowRowErrors = false;
            this.DGV_SearchGrid.Size = new System.Drawing.Size(1317, 56);
            this.DGV_SearchGrid.TabIndex = 1110000989;
            this.DGV_SearchGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_SearchGrid_CellEndEdit);
            this.DGV_SearchGrid.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.DGV_SearchGrid_CellPainting);
            this.DGV_SearchGrid.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DGV_SearchGrid_ColumnHeaderMouseClick);
            this.DGV_SearchGrid.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.DGV_SearchGrid_ColumnWidthChanged);
            this.DGV_SearchGrid.CurrentCellDirtyStateChanged += new System.EventHandler(this.DGV_SearchGrid_CurrentCellDirtyStateChanged);
            this.DGV_SearchGrid.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.DGV_SearchGrid_EditingControlShowing);
            this.DGV_SearchGrid.Scroll += new System.Windows.Forms.ScrollEventHandler(this.DGV_SearchGrid_Scroll);
            // 
            // grdBlockedSupplier
            // 
            this.grdBlockedSupplier.AllowUserToAddRows = false;
            this.grdBlockedSupplier.AllowUserToDeleteRows = false;
            this.grdBlockedSupplier.AllowUserToResizeColumns = false;
            this.grdBlockedSupplier.AllowUserToResizeRows = false;
            this.grdBlockedSupplier.BackgroundColor = System.Drawing.Color.White;
            this.grdBlockedSupplier.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdBlockedSupplier.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.grdBlockedSupplier.ColumnHeadersHeight = 30;
            this.grdBlockedSupplier.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdBlockedSupplier.ColumnHeadersVisible = false;
            this.grdBlockedSupplier.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmDelete});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdBlockedSupplier.DefaultCellStyle = dataGridViewCellStyle5;
            this.grdBlockedSupplier.EnableHeadersVisualStyles = false;
            this.grdBlockedSupplier.GridColor = System.Drawing.Color.White;
            this.grdBlockedSupplier.Location = new System.Drawing.Point(6, 110);
            this.grdBlockedSupplier.Name = "grdBlockedSupplier";
            this.grdBlockedSupplier.ReadOnly = true;
            this.grdBlockedSupplier.RowHeadersVisible = false;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            this.grdBlockedSupplier.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.grdBlockedSupplier.RowTemplate.Height = 25;
            this.grdBlockedSupplier.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdBlockedSupplier.Size = new System.Drawing.Size(1317, 516);
            this.grdBlockedSupplier.TabIndex = 1110000990;
            this.grdBlockedSupplier.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrdBlockedSupplier_CellContentClick);
            this.grdBlockedSupplier.Scroll += new System.Windows.Forms.ScrollEventHandler(this.GrdBlockedSupplier_Scroll);
            // 
            // clmDelete
            // 
            this.clmDelete.HeaderText = "Delete";
            this.clmDelete.Image = global::ROMS.Properties.Resources.Delete;
            this.clmDelete.Name = "clmDelete";
            this.clmDelete.ReadOnly = true;
            this.clmDelete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmDelete.Width = 40;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnSave.Image = global::ROMS.Properties.Resources.save;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(740, 19);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(83, 29);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Update";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            this.btnSave.Enter += new System.EventHandler(this.BtnSave_Enter);
            this.btnSave.Leave += new System.EventHandler(this.BtnSave_Leave);
            // 
            // epBlockedSupplier
            // 
            this.epBlockedSupplier.ContainerControl = this;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "Delete";
            this.dataGridViewImageColumn1.Image = global::ROMS.Properties.Resources.Delete;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.HeaderText = "Edit";
            this.dataGridViewImageColumn2.Image = global::ROMS.Properties.Resources.Edit;
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.ReadOnly = true;
            this.dataGridViewImageColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // dataGridViewImageColumn3
            // 
            this.dataGridViewImageColumn3.HeaderText = "Move";
            this.dataGridViewImageColumn3.Image = global::ROMS.Properties.Resources.add;
            this.dataGridViewImageColumn3.Name = "dataGridViewImageColumn3";
            this.dataGridViewImageColumn3.ReadOnly = true;
            // 
            // dataGridViewImageColumn4
            // 
            this.dataGridViewImageColumn4.HeaderText = "Convert";
            this.dataGridViewImageColumn4.Image = global::ROMS.Properties.Resources.Convertion;
            this.dataGridViewImageColumn4.Name = "dataGridViewImageColumn4";
            this.dataGridViewImageColumn4.ReadOnly = true;
            // 
            // PAY_BlockedSupplier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(1354, 675);
            this.Controls.Add(this.tsBlockSupplier);
            this.Controls.Add(this.pnlBlockedSupplier);
            this.Controls.Add(this.lblNoRecordsFound);
            this.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "PAY_BlockedSupplier";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Blocked Supplier";
            this.Load += new System.EventHandler(this.PAY_BlockedSupplier_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PAY_BlockedSupplier_KeyDown);
            this.tsBlockSupplier.ResumeLayout(false);
            this.tsBlockSupplier.PerformLayout();
            this.pnlBlockedSupplier.ResumeLayout(false);
            this.grpSupplier.ResumeLayout(false);
            this.grpSupplier.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_SearchGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBlockedSupplier)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epBlockedSupplier)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip tsBlockSupplier;
        private System.Windows.Forms.ToolStripLabel tspBlockedSupplier;
        private System.Windows.Forms.Label lblNoRecordsFound;
        private System.Windows.Forms.Panel pnlBlockedSupplier;
        private System.Windows.Forms.GroupBox grpSupplier;
        public System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ErrorProvider epBlockedSupplier;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn3;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn4;
        public System.Windows.Forms.DataGridView DGV_SearchGrid;
        public System.Windows.Forms.DataGridView grdBlockedSupplier;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.ListView LV_Supplier;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.TextBox txtSupplier;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbReason;
        private System.Windows.Forms.Label lblSupplierCode;
        private System.Windows.Forms.Label lblschedule;
        private System.Windows.Forms.DataGridViewImageColumn clmDelete;
    }
}