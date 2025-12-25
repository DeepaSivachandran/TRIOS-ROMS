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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tsBrandList = new System.Windows.Forms.ToolStrip();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.tssEdit = new System.Windows.Forms.ToolStripSeparator();
            this.tsbEdit = new System.Windows.Forms.ToolStripButton();
            this.tssNew = new System.Windows.Forms.ToolStripSeparator();
            this.tsbNew = new System.Windows.Forms.ToolStripButton();
            this.grdBrandList = new System.Windows.Forms.DataGridView();
            this.lblNoRecordsFound = new System.Windows.Forms.Label();
            this.picLoader = new System.Windows.Forms.PictureBox();
            this.pnlbrand = new System.Windows.Forms.Panel();
            this.lvSubGroup = new System.Windows.Forms.ListView();
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvGroup = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtProductGroup = new System.Windows.Forms.TextBox();
            this.DGV_SearchGrid = new System.Windows.Forms.DataGridView();
            this.BrandFilterby = new System.Windows.Forms.GroupBox();
            this.lblProductCount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtProductSubGroup = new System.Windows.Forms.TextBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.lblProductSubGroup = new System.Windows.Forms.Label();
            this.lblProductgroup = new System.Windows.Forms.Label();
            this.lblInactiveCount = new System.Windows.Forms.Label();
            this.lblActiveCount = new System.Windows.Forms.Label();
            this.lblGroup = new System.Windows.Forms.Label();
            this.lblTotProducts = new System.Windows.Forms.Label();
            this.tsLabelPlaceholder = new System.Windows.Forms.ToolStripLabel();
            this.dynamicLabelControl = new ROMS.DynamicToolStripLabelControl();
            this.tsBrandList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBrandList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).BeginInit();
            this.pnlbrand.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_SearchGrid)).BeginInit();
            this.BrandFilterby.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsBrandList
            // 
            this.tsBrandList.BackColor = System.Drawing.Color.White;
            this.tsBrandList.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsBrandList.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsBrandList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbDelete,
            this.tssEdit,
            this.tsbEdit,
            this.tssNew,
            this.tsbNew,
            this.tsLabelPlaceholder});
            this.tsBrandList.Location = new System.Drawing.Point(0, 0);
            this.tsBrandList.Name = "tsBrandList";
            this.tsBrandList.Size = new System.Drawing.Size(1354, 27);
            this.tsBrandList.TabIndex = 35;
            this.tsBrandList.Text = "Brand";
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
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(242)))), ((int)(((byte)(213)))));
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdBrandList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.grdBrandList.ColumnHeadersHeight = 30;
            this.grdBrandList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdBrandList.ColumnHeadersVisible = false;
            this.grdBrandList.EnableHeadersVisualStyles = false;
            this.grdBrandList.GridColor = System.Drawing.Color.White;
            this.grdBrandList.Location = new System.Drawing.Point(1, 143);
            this.grdBrandList.Name = "grdBrandList";
            this.grdBrandList.ReadOnly = true;
            this.grdBrandList.RowHeadersVisible = false;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.White;
            this.grdBrandList.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.grdBrandList.RowTemplate.Height = 25;
            this.grdBrandList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdBrandList.Size = new System.Drawing.Size(1348, 496);
            this.grdBrandList.TabIndex = 7;
            this.grdBrandList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.GrdBrandList_DataBindingComplete);
            this.grdBrandList.Scroll += new System.Windows.Forms.ScrollEventHandler(this.GrdBrandList_Scroll);
            this.grdBrandList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdBrandList_KeyDown);
            this.grdBrandList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.GrdBrandList_MouseDoubleClick);
            // 
            // lblNoRecordsFound
            // 
            this.lblNoRecordsFound.AutoSize = true;
            this.lblNoRecordsFound.BackColor = System.Drawing.Color.White;
            this.lblNoRecordsFound.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoRecordsFound.Location = new System.Drawing.Point(624, 350);
            this.lblNoRecordsFound.Name = "lblNoRecordsFound";
            this.lblNoRecordsFound.Size = new System.Drawing.Size(106, 20);
            this.lblNoRecordsFound.TabIndex = 8;
            this.lblNoRecordsFound.Text = "No Records Found";
            this.lblNoRecordsFound.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // picLoader
            // 
            this.picLoader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picLoader.ErrorImage = null;
            this.picLoader.Image = global::ROMS.Properties.Resources.Iphone_spinner_2;
            this.picLoader.InitialImage = null;
            this.picLoader.Location = new System.Drawing.Point(3, 87);
            this.picLoader.Name = "picLoader";
            this.picLoader.Size = new System.Drawing.Size(1348, 556);
            this.picLoader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picLoader.TabIndex = 958787;
            this.picLoader.TabStop = false;
            // 
            // pnlbrand
            // 
            this.pnlbrand.BackColor = System.Drawing.Color.White;
            this.pnlbrand.Controls.Add(this.lvSubGroup);
            this.pnlbrand.Controls.Add(this.lvGroup);
            this.pnlbrand.Controls.Add(this.txtProductGroup);
            this.pnlbrand.Controls.Add(this.DGV_SearchGrid);
            this.pnlbrand.Controls.Add(this.BrandFilterby);
            this.pnlbrand.Controls.Add(this.lblNoRecordsFound);
            this.pnlbrand.Controls.Add(this.grdBrandList);
            this.pnlbrand.Controls.Add(this.picLoader);
            this.pnlbrand.Location = new System.Drawing.Point(0, 31);
            this.pnlbrand.Name = "pnlbrand";
            this.pnlbrand.Size = new System.Drawing.Size(1354, 641);
            this.pnlbrand.TabIndex = 958797;
            // 
            // lvSubGroup
            // 
            this.lvSubGroup.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9});
            this.lvSubGroup.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvSubGroup.HideSelection = false;
            this.lvSubGroup.Location = new System.Drawing.Point(243, 77);
            this.lvSubGroup.Name = "lvSubGroup";
            this.lvSubGroup.Size = new System.Drawing.Size(457, 157);
            this.lvSubGroup.TabIndex = 5;
            this.lvSubGroup.UseCompatibleStateImageBehavior = false;
            this.lvSubGroup.View = System.Windows.Forms.View.Details;
            this.lvSubGroup.Visible = false;
            this.lvSubGroup.DoubleClick += new System.EventHandler(this.LvSubGroup_DoubleClick);
            this.lvSubGroup.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LvSubGroup_KeyDown);
            // 
            // columnHeader7
            // 
            this.columnHeader7.Width = 180;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Width = 150;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Width = 0;
            // 
            // lvGroup
            // 
            this.lvGroup.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.lvGroup.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvGroup.HideSelection = false;
            this.lvGroup.Location = new System.Drawing.Point(9, 77);
            this.lvGroup.Name = "lvGroup";
            this.lvGroup.Size = new System.Drawing.Size(457, 157);
            this.lvGroup.TabIndex = 4;
            this.lvGroup.UseCompatibleStateImageBehavior = false;
            this.lvGroup.View = System.Windows.Forms.View.Details;
            this.lvGroup.Visible = false;
            this.lvGroup.DoubleClick += new System.EventHandler(this.LvGroup_DoubleClick);
            this.lvGroup.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LvGroup_KeyDown);
            // 
            // columnHeader4
            // 
            this.columnHeader4.Width = 150;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Width = 150;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Width = 0;
            // 
            // txtProductGroup
            // 
            this.txtProductGroup.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductGroup.Location = new System.Drawing.Point(9, 50);
            this.txtProductGroup.MaxLength = 50;
            this.txtProductGroup.Name = "txtProductGroup";
            this.txtProductGroup.Size = new System.Drawing.Size(227, 27);
            this.txtProductGroup.TabIndex = 0;
            this.txtProductGroup.TextChanged += new System.EventHandler(this.TxtProductGroup_TextChanged);
            this.txtProductGroup.Enter += new System.EventHandler(this.TxtProductGroup_Enter);
            this.txtProductGroup.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtProductGroup_KeyDown);
            this.txtProductGroup.Leave += new System.EventHandler(this.TxtProductGroup_Leave);
            // 
            // DGV_SearchGrid
            // 
            this.DGV_SearchGrid.AllowUserToAddRows = false;
            this.DGV_SearchGrid.AllowUserToDeleteRows = false;
            this.DGV_SearchGrid.AllowUserToResizeRows = false;
            this.DGV_SearchGrid.BackgroundColor = System.Drawing.Color.White;
            this.DGV_SearchGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle13.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(242)))), ((int)(((byte)(213)))));
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_SearchGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.DGV_SearchGrid.ColumnHeadersHeight = 30;
            this.DGV_SearchGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV_SearchGrid.DefaultCellStyle = dataGridViewCellStyle14;
            this.DGV_SearchGrid.EnableHeadersVisualStyles = false;
            this.DGV_SearchGrid.GridColor = System.Drawing.Color.White;
            this.DGV_SearchGrid.Location = new System.Drawing.Point(3, 87);
            this.DGV_SearchGrid.Name = "DGV_SearchGrid";
            this.DGV_SearchGrid.RowHeadersVisible = false;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.Black;
            this.DGV_SearchGrid.RowsDefaultCellStyle = dataGridViewCellStyle15;
            this.DGV_SearchGrid.RowTemplate.Height = 25;
            this.DGV_SearchGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DGV_SearchGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DGV_SearchGrid.ShowRowErrors = false;
            this.DGV_SearchGrid.Size = new System.Drawing.Size(1348, 56);
            this.DGV_SearchGrid.TabIndex = 6;
            this.DGV_SearchGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_SearchGrid_CellEndEdit);
            this.DGV_SearchGrid.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.DGV_SearchGrid_CellPainting);
            this.DGV_SearchGrid.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DGV_SearchGrid_ColumnHeaderMouseClick);
            this.DGV_SearchGrid.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.DGV_SearchGrid_ColumnWidthChanged);
            this.DGV_SearchGrid.CurrentCellDirtyStateChanged += new System.EventHandler(this.DGV_SearchGrid_CurrentCellDirtyStateChanged);
            this.DGV_SearchGrid.Scroll += new System.Windows.Forms.ScrollEventHandler(this.DGV_SearchGrid_Scroll);
            // 
            // BrandFilterby
            // 
            this.BrandFilterby.Controls.Add(this.lblProductCount);
            this.BrandFilterby.Controls.Add(this.label1);
            this.BrandFilterby.Controls.Add(this.cmbStatus);
            this.BrandFilterby.Controls.Add(this.lblStatus);
            this.BrandFilterby.Controls.Add(this.txtProductSubGroup);
            this.BrandFilterby.Controls.Add(this.btnExport);
            this.BrandFilterby.Controls.Add(this.btnView);
            this.BrandFilterby.Controls.Add(this.lblProductSubGroup);
            this.BrandFilterby.Controls.Add(this.lblProductgroup);
            this.BrandFilterby.Location = new System.Drawing.Point(3, 6);
            this.BrandFilterby.Name = "BrandFilterby";
            this.BrandFilterby.Size = new System.Drawing.Size(1348, 80);
            this.BrandFilterby.TabIndex = 0;
            this.BrandFilterby.TabStop = false;
            this.BrandFilterby.Text = "Filter By";
            // 
            // lblProductCount
            // 
            this.lblProductCount.AutoSize = true;
            this.lblProductCount.BackColor = System.Drawing.Color.SteelBlue;
            this.lblProductCount.ForeColor = System.Drawing.Color.White;
            this.lblProductCount.Location = new System.Drawing.Point(874, 47);
            this.lblProductCount.Name = "lblProductCount";
            this.lblProductCount.Size = new System.Drawing.Size(37, 20);
            this.lblProductCount.TabIndex = 958821;
            this.lblProductCount.Text = "0000";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(787, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 20);
            this.label1.TabIndex = 958820;
            this.label1.Text = "No.of Brands :";
            // 
            // cmbStatus
            // 
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(474, 44);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(126, 27);
            this.cmbStatus.TabIndex = 3;
            this.cmbStatus.Enter += new System.EventHandler(this.CmbStatus_Enter);
            this.cmbStatus.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbStatus_KeyDown);
            this.cmbStatus.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbStatus_KeyPress);
            this.cmbStatus.Leave += new System.EventHandler(this.CmbStatus_Leave);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(470, 19);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(45, 20);
            this.lblStatus.TabIndex = 958819;
            this.lblStatus.Text = "Status";
            // 
            // txtProductSubGroup
            // 
            this.txtProductSubGroup.Location = new System.Drawing.Point(240, 44);
            this.txtProductSubGroup.Name = "txtProductSubGroup";
            this.txtProductSubGroup.Size = new System.Drawing.Size(227, 27);
            this.txtProductSubGroup.TabIndex = 1;
            this.txtProductSubGroup.TextChanged += new System.EventHandler(this.TxtProductSubGroup_TextChanged);
            this.txtProductSubGroup.Enter += new System.EventHandler(this.TxtProductSubGroup_Enter);
            this.txtProductSubGroup.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtProductSubGroup_KeyDown);
            this.txtProductSubGroup.Leave += new System.EventHandler(this.TxtProductSubGroup_Leave);
            // 
            // btnExport
            // 
            this.btnExport.Image = global::ROMS.Properties.Resources.excel;
            this.btnExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExport.Location = new System.Drawing.Point(692, 43);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(79, 29);
            this.btnExport.TabIndex = 5;
            this.btnExport.Text = "Export";
            this.btnExport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.BtnExport_Click);
            this.btnExport.Enter += new System.EventHandler(this.BtnExport_Enter);
            this.btnExport.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BtnExport_KeyDown);
            this.btnExport.Leave += new System.EventHandler(this.BtnExport_Leave);
            // 
            // btnView
            // 
            this.btnView.Image = global::ROMS.Properties.Resources.view;
            this.btnView.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnView.Location = new System.Drawing.Point(610, 43);
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
            // lblProductSubGroup
            // 
            this.lblProductSubGroup.AutoSize = true;
            this.lblProductSubGroup.Location = new System.Drawing.Point(236, 20);
            this.lblProductSubGroup.Name = "lblProductSubGroup";
            this.lblProductSubGroup.Size = new System.Drawing.Size(108, 20);
            this.lblProductSubGroup.TabIndex = 12;
            this.lblProductSubGroup.Text = "Product Subgroup";
            // 
            // lblProductgroup
            // 
            this.lblProductgroup.AutoSize = true;
            this.lblProductgroup.Location = new System.Drawing.Point(9, 20);
            this.lblProductgroup.Name = "lblProductgroup";
            this.lblProductgroup.Size = new System.Drawing.Size(88, 20);
            this.lblProductgroup.TabIndex = 11;
            this.lblProductgroup.Text = "Product Group";
            this.lblProductgroup.Click += new System.EventHandler(this.LblProductgroup_Click);
            // 
            // lblInactiveCount
            // 
            this.lblInactiveCount.AutoSize = true;
            this.lblInactiveCount.BackColor = System.Drawing.Color.Tomato;
            this.lblInactiveCount.ForeColor = System.Drawing.Color.White;
            this.lblInactiveCount.Location = new System.Drawing.Point(1087, 84);
            this.lblInactiveCount.Name = "lblInactiveCount";
            this.lblInactiveCount.Size = new System.Drawing.Size(44, 20);
            this.lblInactiveCount.TabIndex = 958801;
            this.lblInactiveCount.Text = "00000";
            // 
            // lblActiveCount
            // 
            this.lblActiveCount.AutoSize = true;
            this.lblActiveCount.BackColor = System.Drawing.Color.LimeGreen;
            this.lblActiveCount.ForeColor = System.Drawing.Color.White;
            this.lblActiveCount.Location = new System.Drawing.Point(971, 84);
            this.lblActiveCount.Name = "lblActiveCount";
            this.lblActiveCount.Size = new System.Drawing.Size(44, 20);
            this.lblActiveCount.TabIndex = 958800;
            this.lblActiveCount.Text = "00000";
            // 
            // lblGroup
            // 
            this.lblGroup.AutoSize = true;
            this.lblGroup.BackColor = System.Drawing.Color.White;
            this.lblGroup.Location = new System.Drawing.Point(1034, 84);
            this.lblGroup.Name = "lblGroup";
            this.lblGroup.Size = new System.Drawing.Size(52, 20);
            this.lblGroup.TabIndex = 958799;
            this.lblGroup.Text = "Inactive";
            // 
            // lblTotProducts
            // 
            this.lblTotProducts.AutoSize = true;
            this.lblTotProducts.BackColor = System.Drawing.Color.White;
            this.lblTotProducts.Location = new System.Drawing.Point(927, 84);
            this.lblTotProducts.Name = "lblTotProducts";
            this.lblTotProducts.Size = new System.Drawing.Size(42, 20);
            this.lblTotProducts.TabIndex = 958798;
            this.lblTotProducts.Text = "Active";
            // 
            // tsLabelPlaceholder
            // 
            this.tsLabelPlaceholder.Name = "tsLabelPlaceholder";
            this.tsLabelPlaceholder.Size = new System.Drawing.Size(42, 24);
            this.tsLabelPlaceholder.Text = "Levels";
            // 
            // dynamicLabelControl
            // 
            this.dynamicLabelControl.PlaceholderLabel = null;
            // 
            // CP_BrandList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(1354, 675);
            this.Controls.Add(this.lblInactiveCount);
            this.Controls.Add(this.lblActiveCount);
            this.Controls.Add(this.lblGroup);
            this.Controls.Add(this.lblTotProducts);
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
            this.pnlbrand.ResumeLayout(false);
            this.pnlbrand.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_SearchGrid)).EndInit();
            this.BrandFilterby.ResumeLayout(false);
            this.BrandFilterby.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsBrandList;
        public System.Windows.Forms.DataGridView grdBrandList;
        private System.Windows.Forms.Label lblNoRecordsFound;
        private System.Windows.Forms.PictureBox picLoader;
        public System.Windows.Forms.ToolStripButton tsbDelete;
        public System.Windows.Forms.ToolStripSeparator tssEdit;
        public System.Windows.Forms.ToolStripButton tsbEdit;
        public System.Windows.Forms.ToolStripSeparator tssNew;
        public System.Windows.Forms.ToolStripButton tsbNew;
        private System.Windows.Forms.Panel pnlbrand;
        private System.Windows.Forms.GroupBox BrandFilterby;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Label lblProductSubGroup;
        private System.Windows.Forms.Label lblProductgroup;
        public System.Windows.Forms.DataGridView DGV_SearchGrid;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.TextBox txtProductGroup;
        public System.Windows.Forms.ListView lvGroup;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        public System.Windows.Forms.ListView lvSubGroup;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.TextBox txtProductSubGroup;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblProductCount;
        private System.Windows.Forms.Label lblInactiveCount;
        private System.Windows.Forms.Label lblActiveCount;
        private System.Windows.Forms.Label lblGroup;
        private System.Windows.Forms.Label lblTotProducts;
        private System.Windows.Forms.ToolStripLabel tsLabelPlaceholder;
        private DynamicToolStripLabelControl dynamicLabelControl;
    }
}