namespace ROMS
{
    partial class INV_Inwardlist
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
            this.tsInwardList = new System.Windows.Forms.ToolStrip();
            this.tspHeader = new System.Windows.Forms.ToolStripLabel();
            this.tsbEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbNew = new System.Windows.Forms.ToolStripButton();
            this.pnlinward = new System.Windows.Forms.Panel();
            this.DGV_SearchGrid = new System.Windows.Forms.DataGridView();
            this.clmdsno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmdpurchaseno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmdpono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmdinvoiceno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmdinvoicedate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmdsuppliername = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmdtotalitems = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmdtotalqty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblNoRecordsFound = new System.Windows.Forms.Label();
            this.grdInwardList = new System.Windows.Forms.DataGridView();
            this.clmsno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmpurchaseno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmpono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clminvoiceno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clminvoicedate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmsuppliername = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmtotalitems = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmtotalqty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.picLoader = new System.Windows.Forms.PictureBox();
            this.tsInwardList.SuspendLayout();
            this.pnlinward.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_SearchGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdInwardList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).BeginInit();
            this.SuspendLayout();
            // 
            // tsInwardList
            // 
            this.tsInwardList.BackColor = System.Drawing.Color.White;
            this.tsInwardList.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsInwardList.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsInwardList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspHeader,
            this.tsbEdit,
            this.toolStripSeparator1,
            this.tsbNew});
            this.tsInwardList.Location = new System.Drawing.Point(0, 0);
            this.tsInwardList.Name = "tsInwardList";
            this.tsInwardList.Size = new System.Drawing.Size(1354, 27);
            this.tsInwardList.TabIndex = 35;
            this.tsInwardList.Text = "Inward";
            // 
            // tspHeader
            // 
            this.tspHeader.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tspHeader.Image = global::ROMS.Properties.Resources.bread_crumb;
            this.tspHeader.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tspHeader.Margin = new System.Windows.Forms.Padding(15, 1, 0, 2);
            this.tspHeader.Name = "tspHeader";
            this.tspHeader.Size = new System.Drawing.Size(66, 24);
            this.tspHeader.Text = "Inward ";
            // 
            // tsbEdit
            // 
            this.tsbEdit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbEdit.Image = global::ROMS.Properties.Resources.Edit;
            this.tsbEdit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEdit.Margin = new System.Windows.Forms.Padding(0, 1, 10, 2);
            this.tsbEdit.Name = "tsbEdit";
            this.tsbEdit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tsbEdit.Size = new System.Drawing.Size(50, 24);
            this.tsbEdit.Text = "&Edit";
            this.tsbEdit.Click += new System.EventHandler(this.tsbEdit_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // tsbNew
            // 
            this.tsbNew.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbNew.Image = global::ROMS.Properties.Resources.New;
            this.tsbNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNew.Name = "tsbNew";
            this.tsbNew.Size = new System.Drawing.Size(52, 24);
            this.tsbNew.Text = "&New";
            this.tsbNew.Click += new System.EventHandler(this.TsbNew_Click_1);
            // 
            // pnlinward
            // 
            this.pnlinward.BackColor = System.Drawing.Color.White;
            this.pnlinward.Controls.Add(this.DGV_SearchGrid);
            this.pnlinward.Controls.Add(this.lblNoRecordsFound);
            this.pnlinward.Controls.Add(this.grdInwardList);
            this.pnlinward.Controls.Add(this.picLoader);
            this.pnlinward.Location = new System.Drawing.Point(0, 40);
            this.pnlinward.Name = "pnlinward";
            this.pnlinward.Size = new System.Drawing.Size(1354, 637);
            this.pnlinward.TabIndex = 36;
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
            this.DGV_SearchGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmdsno,
            this.clmdpurchaseno,
            this.clmdpono,
            this.clmdinvoiceno,
            this.clmdinvoicedate,
            this.clmdsuppliername,
            this.clmdtotalitems,
            this.clmdtotalqty});
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
            this.DGV_SearchGrid.Location = new System.Drawing.Point(13, 10);
            this.DGV_SearchGrid.Name = "DGV_SearchGrid";
            this.DGV_SearchGrid.RowHeadersVisible = false;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.DGV_SearchGrid.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.DGV_SearchGrid.RowTemplate.Height = 25;
            this.DGV_SearchGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DGV_SearchGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DGV_SearchGrid.ShowRowErrors = false;
            this.DGV_SearchGrid.Size = new System.Drawing.Size(1329, 56);
            this.DGV_SearchGrid.TabIndex = 958800;
            // 
            // clmdsno
            // 
            this.clmdsno.HeaderText = "S.No.";
            this.clmdsno.Name = "clmdsno";
            // 
            // clmdpurchaseno
            // 
            this.clmdpurchaseno.HeaderText = "Voucher No.";
            this.clmdpurchaseno.Name = "clmdpurchaseno";
            this.clmdpurchaseno.Width = 200;
            // 
            // clmdpono
            // 
            this.clmdpono.HeaderText = "PO.No.";
            this.clmdpono.Name = "clmdpono";
            // 
            // clmdinvoiceno
            // 
            this.clmdinvoiceno.HeaderText = "Invoice No.";
            this.clmdinvoiceno.Name = "clmdinvoiceno";
            // 
            // clmdinvoicedate
            // 
            this.clmdinvoicedate.HeaderText = "Invoice Date";
            this.clmdinvoicedate.Name = "clmdinvoicedate";
            // 
            // clmdsuppliername
            // 
            this.clmdsuppliername.HeaderText = "Supplier Name";
            this.clmdsuppliername.Name = "clmdsuppliername";
            this.clmdsuppliername.Width = 200;
            // 
            // clmdtotalitems
            // 
            this.clmdtotalitems.HeaderText = "Total Items";
            this.clmdtotalitems.Name = "clmdtotalitems";
            this.clmdtotalitems.Width = 200;
            // 
            // clmdtotalqty
            // 
            this.clmdtotalqty.HeaderText = "Total Qty";
            this.clmdtotalqty.Name = "clmdtotalqty";
            // 
            // lblNoRecordsFound
            // 
            this.lblNoRecordsFound.AutoSize = true;
            this.lblNoRecordsFound.BackColor = System.Drawing.Color.White;
            this.lblNoRecordsFound.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoRecordsFound.Location = new System.Drawing.Point(622, 295);
            this.lblNoRecordsFound.Name = "lblNoRecordsFound";
            this.lblNoRecordsFound.Size = new System.Drawing.Size(106, 20);
            this.lblNoRecordsFound.TabIndex = 958798;
            this.lblNoRecordsFound.Text = "No Records Found";
            this.lblNoRecordsFound.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // grdInwardList
            // 
            this.grdInwardList.AllowUserToAddRows = false;
            this.grdInwardList.AllowUserToDeleteRows = false;
            this.grdInwardList.AllowUserToResizeColumns = false;
            this.grdInwardList.AllowUserToResizeRows = false;
            this.grdInwardList.BackgroundColor = System.Drawing.Color.White;
            this.grdInwardList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(242)))), ((int)(((byte)(213)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdInwardList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.grdInwardList.ColumnHeadersHeight = 30;
            this.grdInwardList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdInwardList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmsno,
            this.clmpurchaseno,
            this.clmpono,
            this.clminvoiceno,
            this.clminvoicedate,
            this.clmsuppliername,
            this.clmtotalitems,
            this.clmtotalqty});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdInwardList.DefaultCellStyle = dataGridViewCellStyle5;
            this.grdInwardList.EnableHeadersVisualStyles = false;
            this.grdInwardList.GridColor = System.Drawing.Color.White;
            this.grdInwardList.Location = new System.Drawing.Point(13, 66);
            this.grdInwardList.Name = "grdInwardList";
            this.grdInwardList.ReadOnly = true;
            this.grdInwardList.RowHeadersVisible = false;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            this.grdInwardList.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.grdInwardList.RowTemplate.Height = 25;
            this.grdInwardList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdInwardList.Size = new System.Drawing.Size(1329, 561);
            this.grdInwardList.TabIndex = 958797;
            // 
            // clmsno
            // 
            this.clmsno.HeaderText = "S.No.";
            this.clmsno.Name = "clmsno";
            this.clmsno.ReadOnly = true;
            // 
            // clmpurchaseno
            // 
            this.clmpurchaseno.HeaderText = "Voucher No.";
            this.clmpurchaseno.Name = "clmpurchaseno";
            this.clmpurchaseno.ReadOnly = true;
            this.clmpurchaseno.Width = 200;
            // 
            // clmpono
            // 
            this.clmpono.HeaderText = "PO.No.";
            this.clmpono.Name = "clmpono";
            this.clmpono.ReadOnly = true;
            // 
            // clminvoiceno
            // 
            this.clminvoiceno.HeaderText = "Invoice No.";
            this.clminvoiceno.Name = "clminvoiceno";
            this.clminvoiceno.ReadOnly = true;
            // 
            // clminvoicedate
            // 
            this.clminvoicedate.HeaderText = "Invoice Date";
            this.clminvoicedate.Name = "clminvoicedate";
            this.clminvoicedate.ReadOnly = true;
            // 
            // clmsuppliername
            // 
            this.clmsuppliername.HeaderText = "Supplier Name";
            this.clmsuppliername.Name = "clmsuppliername";
            this.clmsuppliername.ReadOnly = true;
            this.clmsuppliername.Width = 200;
            // 
            // clmtotalitems
            // 
            this.clmtotalitems.HeaderText = "Total Items";
            this.clmtotalitems.Name = "clmtotalitems";
            this.clmtotalitems.ReadOnly = true;
            this.clmtotalitems.Width = 200;
            // 
            // clmtotalqty
            // 
            this.clmtotalqty.HeaderText = "Total Qty";
            this.clmtotalqty.Name = "clmtotalqty";
            this.clmtotalqty.ReadOnly = true;
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
            // INV_Inwardlist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(1354, 675);
            this.Controls.Add(this.pnlinward);
            this.Controls.Add(this.tsInwardList);
            this.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "INV_Inwardlist";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Brand";
            this.Load += new System.EventHandler(this.CP_BrandList_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CP_BrandList_KeyDown);
            this.tsInwardList.ResumeLayout(false);
            this.tsInwardList.PerformLayout();
            this.pnlinward.ResumeLayout(false);
            this.pnlinward.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_SearchGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdInwardList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStripLabel tspHeader;
        public System.Windows.Forms.ToolStripButton tsbEdit;
        private System.Windows.Forms.ToolStrip tsInwardList;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbNew;
        private System.Windows.Forms.Panel pnlinward;
        public System.Windows.Forms.DataGridView DGV_SearchGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmdsno;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmdpurchaseno;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmdpono;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmdinvoiceno;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmdinvoicedate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmdsuppliername;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmdtotalitems;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmdtotalqty;
        private System.Windows.Forms.Label lblNoRecordsFound;
        public System.Windows.Forms.DataGridView grdInwardList;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmsno;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmpurchaseno;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmpono;
        private System.Windows.Forms.DataGridViewTextBoxColumn clminvoiceno;
        private System.Windows.Forms.DataGridViewTextBoxColumn clminvoicedate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmsuppliername;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmtotalitems;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmtotalqty;
        private System.Windows.Forms.PictureBox picLoader;
    }
}