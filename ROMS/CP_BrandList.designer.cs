namespace ROMS
{
    partial class CP_BrandList
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
            this.tsBrandList = new System.Windows.Forms.ToolStrip();
            this.tspHeader = new System.Windows.Forms.ToolStripLabel();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.tssEdit = new System.Windows.Forms.ToolStripSeparator();
            this.tsbEdit = new System.Windows.Forms.ToolStripButton();
            this.tssNew = new System.Windows.Forms.ToolStripSeparator();
            this.tsbNew = new System.Windows.Forms.ToolStripButton();
            this.grdBrandList = new System.Windows.Forms.DataGridView();
            this.clmsno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmBrandNameInEnglish = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmBrandNameInTamil = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmtotsubgroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmNoofproducts = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblNoRecordsFound = new System.Windows.Forms.Label();
            this.picLoader = new System.Windows.Forms.PictureBox();
            this.DGV_SearchGrid = new System.Windows.Forms.DataGridView();
            this.sno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BrandNameInEnglish = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BrandNameInTamil = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalSubGroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalProducts = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlbrand = new System.Windows.Forms.Panel();
            this.BrandFilterby = new System.Windows.Forms.GroupBox();
            this.btnView = new System.Windows.Forms.Button();
            this.lblProductSubGroup = new System.Windows.Forms.Label();
            this.cmbProductSubGroup = new System.Windows.Forms.ComboBox();
            this.lblProductgroup = new System.Windows.Forms.Label();
            this.cmbProductgroup = new System.Windows.Forms.ComboBox();
            this.tsBrandList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBrandList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_SearchGrid)).BeginInit();
            this.pnlbrand.SuspendLayout();
            this.BrandFilterby.SuspendLayout();
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
            this.tssNew,
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
            this.tspHeader.Size = new System.Drawing.Size(58, 24);
            this.tspHeader.Text = "Brand";
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
            // grdBrandList
            // 
            this.grdBrandList.AllowUserToAddRows = false;
            this.grdBrandList.AllowUserToDeleteRows = false;
            this.grdBrandList.AllowUserToResizeColumns = false;
            this.grdBrandList.AllowUserToResizeRows = false;
            this.grdBrandList.BackgroundColor = System.Drawing.Color.White;
            this.grdBrandList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(242)))), ((int)(((byte)(213)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdBrandList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdBrandList.ColumnHeadersHeight = 30;
            this.grdBrandList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdBrandList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmsno,
            this.clmBrandNameInEnglish,
            this.clmBrandNameInTamil,
            this.clmtotsubgroup,
            this.clmNoofproducts,
            this.clmStatus});
            this.grdBrandList.EnableHeadersVisualStyles = false;
            this.grdBrandList.GridColor = System.Drawing.Color.White;
            this.grdBrandList.Location = new System.Drawing.Point(3, 143);
            this.grdBrandList.Name = "grdBrandList";
            this.grdBrandList.ReadOnly = true;
            this.grdBrandList.RowHeadersVisible = false;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            this.grdBrandList.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.grdBrandList.RowTemplate.Height = 25;
            this.grdBrandList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdBrandList.Size = new System.Drawing.Size(1348, 496);
            this.grdBrandList.TabIndex = 1;
            this.grdBrandList.Scroll += new System.Windows.Forms.ScrollEventHandler(this.grdBrandList_Scroll);
            this.grdBrandList.DoubleClick += new System.EventHandler(this.grdBrandList_DoubleClick);
            this.grdBrandList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdBrandList_KeyDown);
            // 
            // clmsno
            // 
            this.clmsno.HeaderText = "S.No.";
            this.clmsno.Name = "clmsno";
            this.clmsno.ReadOnly = true;
            this.clmsno.Width = 50;
            // 
            // clmBrandNameInEnglish
            // 
            this.clmBrandNameInEnglish.HeaderText = "Brand Name in English";
            this.clmBrandNameInEnglish.Name = "clmBrandNameInEnglish";
            this.clmBrandNameInEnglish.ReadOnly = true;
            this.clmBrandNameInEnglish.Width = 200;
            // 
            // clmBrandNameInTamil
            // 
            this.clmBrandNameInTamil.HeaderText = "Brand Name in Tamil";
            this.clmBrandNameInTamil.Name = "clmBrandNameInTamil";
            this.clmBrandNameInTamil.ReadOnly = true;
            this.clmBrandNameInTamil.Width = 200;
            // 
            // clmtotsubgroup
            // 
            this.clmtotsubgroup.HeaderText = "Total Sub Groups";
            this.clmtotsubgroup.Name = "clmtotsubgroup";
            this.clmtotsubgroup.ReadOnly = true;
            this.clmtotsubgroup.Width = 120;
            // 
            // clmNoofproducts
            // 
            this.clmNoofproducts.HeaderText = "Total Products";
            this.clmNoofproducts.Name = "clmNoofproducts";
            this.clmNoofproducts.ReadOnly = true;
            // 
            // clmStatus
            // 
            this.clmStatus.HeaderText = "Status";
            this.clmStatus.Name = "clmStatus";
            this.clmStatus.ReadOnly = true;
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
            this.picLoader.Image = global::ROMS.Properties.Resources.loader;
            this.picLoader.InitialImage = null;
            this.picLoader.Location = new System.Drawing.Point(13, 9);
            this.picLoader.Name = "picLoader";
            this.picLoader.Size = new System.Drawing.Size(1328, 618);
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
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(242)))), ((int)(((byte)(213)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_SearchGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DGV_SearchGrid.ColumnHeadersHeight = 30;
            this.DGV_SearchGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGV_SearchGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sno,
            this.BrandNameInEnglish,
            this.BrandNameInTamil,
            this.TotalSubGroup,
            this.TotalProducts,
            this.Status});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV_SearchGrid.DefaultCellStyle = dataGridViewCellStyle4;
            this.DGV_SearchGrid.EnableHeadersVisualStyles = false;
            this.DGV_SearchGrid.GridColor = System.Drawing.Color.White;
            this.DGV_SearchGrid.Location = new System.Drawing.Point(3, 87);
            this.DGV_SearchGrid.Name = "DGV_SearchGrid";
            this.DGV_SearchGrid.RowHeadersVisible = false;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.DGV_SearchGrid.RowsDefaultCellStyle = dataGridViewCellStyle5;
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
            this.DGV_SearchGrid.Sorted += new System.EventHandler(this.DGV_SearchGrid_Sorted);
            // 
            // sno
            // 
            this.sno.HeaderText = "S.No.";
            this.sno.Name = "sno";
            this.sno.Width = 50;
            // 
            // BrandNameInEnglish
            // 
            this.BrandNameInEnglish.HeaderText = "Brand Name In English";
            this.BrandNameInEnglish.Name = "BrandNameInEnglish";
            this.BrandNameInEnglish.Width = 200;
            // 
            // BrandNameInTamil
            // 
            this.BrandNameInTamil.HeaderText = "Brand Name in Tamil";
            this.BrandNameInTamil.Name = "BrandNameInTamil";
            this.BrandNameInTamil.Width = 200;
            // 
            // TotalSubGroup
            // 
            this.TotalSubGroup.HeaderText = "Total SubGroup";
            this.TotalSubGroup.Name = "TotalSubGroup";
            this.TotalSubGroup.Width = 120;
            // 
            // TotalProducts
            // 
            this.TotalProducts.HeaderText = "Total Products";
            this.TotalProducts.Name = "TotalProducts";
            // 
            // Status
            // 
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            // 
            // pnlbrand
            // 
            this.pnlbrand.BackColor = System.Drawing.Color.White;
            this.pnlbrand.Controls.Add(this.BrandFilterby);
            this.pnlbrand.Controls.Add(this.DGV_SearchGrid);
            this.pnlbrand.Controls.Add(this.lblNoRecordsFound);
            this.pnlbrand.Controls.Add(this.grdBrandList);
            this.pnlbrand.Controls.Add(this.picLoader);
            this.pnlbrand.Location = new System.Drawing.Point(0, 31);
            this.pnlbrand.Name = "pnlbrand";
            this.pnlbrand.Size = new System.Drawing.Size(1354, 641);
            this.pnlbrand.TabIndex = 958797;
            // 
            // BrandFilterby
            // 
            this.BrandFilterby.Controls.Add(this.btnView);
            this.BrandFilterby.Controls.Add(this.lblProductSubGroup);
            this.BrandFilterby.Controls.Add(this.cmbProductSubGroup);
            this.BrandFilterby.Controls.Add(this.lblProductgroup);
            this.BrandFilterby.Controls.Add(this.cmbProductgroup);
            this.BrandFilterby.Location = new System.Drawing.Point(3, 6);
            this.BrandFilterby.Name = "BrandFilterby";
            this.BrandFilterby.Size = new System.Drawing.Size(572, 80);
            this.BrandFilterby.TabIndex = 958802;
            this.BrandFilterby.TabStop = false;
            this.BrandFilterby.Text = "Filter By";
            // 
            // btnView
            // 
            this.btnView.Image = global::ROMS.Properties.Resources.view;
            this.btnView.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnView.Location = new System.Drawing.Point(483, 43);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(75, 29);
            this.btnView.TabIndex = 958797;
            this.btnView.Text = "View";
            this.btnView.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnView.UseVisualStyleBackColor = true;
            // 
            // lblProductSubGroup
            // 
            this.lblProductSubGroup.AutoSize = true;
            this.lblProductSubGroup.Location = new System.Drawing.Point(250, 19);
            this.lblProductSubGroup.Name = "lblProductSubGroup";
            this.lblProductSubGroup.Size = new System.Drawing.Size(108, 20);
            this.lblProductSubGroup.TabIndex = 4;
            this.lblProductSubGroup.Text = "Product Subgroup";
            // 
            // cmbProductSubGroup
            // 
            this.cmbProductSubGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProductSubGroup.FormattingEnabled = true;
            this.cmbProductSubGroup.Location = new System.Drawing.Point(247, 43);
            this.cmbProductSubGroup.Name = "cmbProductSubGroup";
            this.cmbProductSubGroup.Size = new System.Drawing.Size(227, 27);
            this.cmbProductSubGroup.TabIndex = 3;
            // 
            // lblProductgroup
            // 
            this.lblProductgroup.AutoSize = true;
            this.lblProductgroup.Location = new System.Drawing.Point(9, 20);
            this.lblProductgroup.Name = "lblProductgroup";
            this.lblProductgroup.Size = new System.Drawing.Size(88, 20);
            this.lblProductgroup.TabIndex = 2;
            this.lblProductgroup.Text = "Product Group";
            // 
            // cmbProductgroup
            // 
            this.cmbProductgroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProductgroup.FormattingEnabled = true;
            this.cmbProductgroup.Location = new System.Drawing.Point(9, 43);
            this.cmbProductgroup.Name = "cmbProductgroup";
            this.cmbProductgroup.Size = new System.Drawing.Size(227, 27);
            this.cmbProductgroup.TabIndex = 1;
            // 
            // CP_BrandList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(1354, 675);
            this.Controls.Add(this.pnlbrand);
            this.Controls.Add(this.tsBrandList);
            this.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "CP_BrandList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Brand";
            this.Load += new System.EventHandler(this.CP_BrandList_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CP_BrandList_KeyDown);
            this.tsBrandList.ResumeLayout(false);
            this.tsBrandList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBrandList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_SearchGrid)).EndInit();
            this.pnlbrand.ResumeLayout(false);
            this.pnlbrand.PerformLayout();
            this.BrandFilterby.ResumeLayout(false);
            this.BrandFilterby.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsBrandList;
        private System.Windows.Forms.ToolStripLabel tspHeader;
        public System.Windows.Forms.DataGridView grdBrandList;
        private System.Windows.Forms.Label lblNoRecordsFound;
        private System.Windows.Forms.PictureBox picLoader;
        public System.Windows.Forms.ToolStripButton tsbDelete;
        public System.Windows.Forms.ToolStripSeparator tssEdit;
        public System.Windows.Forms.ToolStripButton tsbEdit;
        public System.Windows.Forms.ToolStripSeparator tssNew;
        public System.Windows.Forms.ToolStripButton tsbNew;
        public System.Windows.Forms.DataGridView DGV_SearchGrid;
        private System.Windows.Forms.Panel pnlbrand;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmsno;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmBrandNameInEnglish;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmBrandNameInTamil;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmtotsubgroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmNoofproducts;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmStatus;
        private System.Windows.Forms.GroupBox BrandFilterby;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Label lblProductSubGroup;
        private System.Windows.Forms.ComboBox cmbProductSubGroup;
        private System.Windows.Forms.Label lblProductgroup;
        private System.Windows.Forms.ComboBox cmbProductgroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn sno;
        private System.Windows.Forms.DataGridViewTextBoxColumn BrandNameInEnglish;
        private System.Windows.Forms.DataGridViewTextBoxColumn BrandNameInTamil;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalSubGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalProducts;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
    }
}