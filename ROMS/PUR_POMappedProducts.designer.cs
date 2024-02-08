namespace ROMS
{
    partial class PUR_POMappedProducts
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PUR_POMappedProducts));
            this.errUnit = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.grdPurchaseOrder = new System.Windows.Forms.DataGridView();
            this.lblNoRecordsFound = new System.Windows.Forms.Label();
            this.btnselectall = new System.Windows.Forms.Button();
            this.btnunselectall = new System.Windows.Forms.Button();
            this.lblPC = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.DGV_SearchGrid = new System.Windows.Forms.DataGridView();
            this.clmdsno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmdconcern = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmdpono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmddate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmdsupplier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmdtotalitem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmdtotalqty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmdbillamt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmcreated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCreaedon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmmode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmdinwarddate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmdenterby = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmdstatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.errUnit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPurchaseOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_SearchGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // errUnit
            // 
            this.errUnit.ContainerControl = this;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::ROMS.Properties.Resources.submit;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(814, 495);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(81, 33);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Submit";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            this.btnSave.Enter += new System.EventHandler(this.BtnSave_Enter);
            this.btnSave.Leave += new System.EventHandler(this.BtnSave_Leave);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::ROMS.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(905, 495);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(72, 33);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            this.btnClose.Enter += new System.EventHandler(this.BtnClose_Enter);
            this.btnClose.Leave += new System.EventHandler(this.BtnClose_Leave);
            // 
            // grdPurchaseOrder
            // 
            this.grdPurchaseOrder.AllowUserToAddRows = false;
            this.grdPurchaseOrder.AllowUserToDeleteRows = false;
            this.grdPurchaseOrder.AllowUserToResizeColumns = false;
            this.grdPurchaseOrder.AllowUserToResizeRows = false;
            this.grdPurchaseOrder.BackgroundColor = System.Drawing.Color.White;
            this.grdPurchaseOrder.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdPurchaseOrder.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.grdPurchaseOrder.ColumnHeadersHeight = 30;
            this.grdPurchaseOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdPurchaseOrder.ColumnHeadersVisible = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdPurchaseOrder.DefaultCellStyle = dataGridViewCellStyle5;
            this.grdPurchaseOrder.EnableHeadersVisualStyles = false;
            this.grdPurchaseOrder.GridColor = System.Drawing.Color.White;
            this.grdPurchaseOrder.Location = new System.Drawing.Point(12, 68);
            this.grdPurchaseOrder.Name = "grdPurchaseOrder";
            this.grdPurchaseOrder.RowHeadersVisible = false;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            this.grdPurchaseOrder.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.grdPurchaseOrder.RowTemplate.Height = 25;
            this.grdPurchaseOrder.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdPurchaseOrder.Size = new System.Drawing.Size(965, 419);
            this.grdPurchaseOrder.TabIndex = 2;
            this.grdPurchaseOrder.CurrentCellDirtyStateChanged += new System.EventHandler(this.GrdPurchaseOrder_CurrentCellDirtyStateChanged);
            this.grdPurchaseOrder.Scroll += new System.Windows.Forms.ScrollEventHandler(this.GrdPurchaseOrder_Scroll);
            // 
            // lblNoRecordsFound
            // 
            this.lblNoRecordsFound.AutoSize = true;
            this.lblNoRecordsFound.BackColor = System.Drawing.Color.White;
            this.lblNoRecordsFound.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoRecordsFound.Location = new System.Drawing.Point(441, 267);
            this.lblNoRecordsFound.Name = "lblNoRecordsFound";
            this.lblNoRecordsFound.Size = new System.Drawing.Size(106, 20);
            this.lblNoRecordsFound.TabIndex = 1111149;
            this.lblNoRecordsFound.Text = "No Records Found";
            this.lblNoRecordsFound.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnselectall
            // 
            this.btnselectall.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnselectall.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnselectall.Location = new System.Drawing.Point(12, 495);
            this.btnselectall.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnselectall.Name = "btnselectall";
            this.btnselectall.Size = new System.Drawing.Size(73, 33);
            this.btnselectall.TabIndex = 1111150;
            this.btnselectall.Text = "Select All";
            this.btnselectall.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnselectall.UseVisualStyleBackColor = true;
            this.btnselectall.Click += new System.EventHandler(this.Btnselectall_Click);
            // 
            // btnunselectall
            // 
            this.btnunselectall.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnunselectall.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnunselectall.Location = new System.Drawing.Point(90, 495);
            this.btnunselectall.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnunselectall.Name = "btnunselectall";
            this.btnunselectall.Size = new System.Drawing.Size(83, 33);
            this.btnunselectall.TabIndex = 1111151;
            this.btnunselectall.Text = "Unselect All";
            this.btnunselectall.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnunselectall.UseVisualStyleBackColor = true;
            this.btnunselectall.Click += new System.EventHandler(this.Btnunselectall_Click);
            // 
            // lblPC
            // 
            this.lblPC.AutoSize = true;
            this.lblPC.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Bold);
            this.lblPC.ForeColor = System.Drawing.Color.Crimson;
            this.lblPC.Location = new System.Drawing.Point(781, 501);
            this.lblPC.Name = "lblPC";
            this.lblPC.Size = new System.Drawing.Size(17, 20);
            this.lblPC.TabIndex = 1111192;
            this.lblPC.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(683, 501);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 20);
            this.label7.TabIndex = 1111191;
            this.label7.Text = "Total Products :";
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
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(242)))), ((int)(((byte)(213)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_SearchGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DGV_SearchGrid.ColumnHeadersHeight = 30;
            this.DGV_SearchGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGV_SearchGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmdsno,
            this.clmdconcern,
            this.clmdpono,
            this.clmddate,
            this.clmdsupplier,
            this.clmdtotalitem,
            this.clmdtotalqty,
            this.clmdbillamt,
            this.clmcreated,
            this.clmCreaedon,
            this.clmmode,
            this.clmdinwarddate,
            this.clmdenterby,
            this.clmdstatus});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV_SearchGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.DGV_SearchGrid.EnableHeadersVisualStyles = false;
            this.DGV_SearchGrid.GridColor = System.Drawing.Color.White;
            this.DGV_SearchGrid.Location = new System.Drawing.Point(12, 12);
            this.DGV_SearchGrid.Name = "DGV_SearchGrid";
            this.DGV_SearchGrid.RowHeadersVisible = false;
            this.DGV_SearchGrid.RowHeadersWidth = 70;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.DGV_SearchGrid.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.DGV_SearchGrid.RowTemplate.Height = 25;
            this.DGV_SearchGrid.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.DGV_SearchGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DGV_SearchGrid.ShowRowErrors = false;
            this.DGV_SearchGrid.Size = new System.Drawing.Size(965, 56);
            this.DGV_SearchGrid.TabIndex = 1111193;
            this.DGV_SearchGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_SearchGrid_CellEndEdit);
            this.DGV_SearchGrid.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DGV_SearchGrid_CellFormatting);
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
            // clmdpono
            // 
            this.clmdpono.HeaderText = "PO No.";
            this.clmdpono.MinimumWidth = 6;
            this.clmdpono.Name = "clmdpono";
            // 
            // clmddate
            // 
            this.clmddate.HeaderText = "PO Date";
            this.clmddate.MinimumWidth = 6;
            this.clmddate.Name = "clmddate";
            // 
            // clmdsupplier
            // 
            this.clmdsupplier.HeaderText = "Supplier Name";
            this.clmdsupplier.Name = "clmdsupplier";
            this.clmdsupplier.ReadOnly = true;
            this.clmdsupplier.Width = 200;
            // 
            // clmdtotalitem
            // 
            this.clmdtotalitem.HeaderText = "Total Products";
            this.clmdtotalitem.Name = "clmdtotalitem";
            this.clmdtotalitem.ReadOnly = true;
            // 
            // clmdtotalqty
            // 
            this.clmdtotalqty.HeaderText = "Total Qty";
            this.clmdtotalqty.Name = "clmdtotalqty";
            this.clmdtotalqty.ReadOnly = true;
            // 
            // clmdbillamt
            // 
            this.clmdbillamt.HeaderText = "Turn Around Time";
            this.clmdbillamt.Name = "clmdbillamt";
            this.clmdbillamt.ReadOnly = true;
            this.clmdbillamt.Width = 120;
            // 
            // clmcreated
            // 
            this.clmcreated.HeaderText = "Created By";
            this.clmcreated.Name = "clmcreated";
            this.clmcreated.ReadOnly = true;
            // 
            // clmCreaedon
            // 
            this.clmCreaedon.HeaderText = "Created On";
            this.clmCreaedon.Name = "clmCreaedon";
            this.clmCreaedon.ReadOnly = true;
            // 
            // clmmode
            // 
            this.clmmode.HeaderText = "Mode of Issue";
            this.clmmode.Name = "clmmode";
            this.clmmode.ReadOnly = true;
            // 
            // clmdinwarddate
            // 
            this.clmdinwarddate.HeaderText = "Issue Date";
            this.clmdinwarddate.Name = "clmdinwarddate";
            this.clmdinwarddate.ReadOnly = true;
            // 
            // clmdenterby
            // 
            this.clmdenterby.HeaderText = "Issued By";
            this.clmdenterby.Name = "clmdenterby";
            this.clmdenterby.ReadOnly = true;
            this.clmdenterby.Width = 150;
            // 
            // clmdstatus
            // 
            this.clmdstatus.HeaderText = "Status";
            this.clmdstatus.Name = "clmdstatus";
            this.clmdstatus.ReadOnly = true;
            // 
            // PUR_POMappedProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(991, 541);
            this.Controls.Add(this.DGV_SearchGrid);
            this.Controls.Add(this.lblPC);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnunselectall);
            this.Controls.Add(this.btnselectall);
            this.Controls.Add(this.lblNoRecordsFound);
            this.Controls.Add(this.grdPurchaseOrder);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PUR_POMappedProducts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PUR_POMappedProducts_FormClosing);
            this.Load += new System.EventHandler(this.PUR_POMappedProducts_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PUR_POMappedProducts_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.errUnit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPurchaseOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_SearchGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ErrorProvider errUnit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        public System.Windows.Forms.DataGridView grdPurchaseOrder;
        private System.Windows.Forms.Label lblNoRecordsFound;
        private System.Windows.Forms.Button btnunselectall;
        private System.Windows.Forms.Button btnselectall;
        private System.Windows.Forms.Label lblPC;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.DataGridView DGV_SearchGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmdsno;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmdconcern;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmdpono;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmddate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmdsupplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmdtotalitem;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmdtotalqty;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmdbillamt;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmcreated;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCreaedon;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmmode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmdinwarddate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmdenterby;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmdstatus;
    }
}