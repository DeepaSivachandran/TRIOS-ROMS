namespace ROMS
{
    partial class CP_GroupList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tsGroupList = new System.Windows.Forms.ToolStrip();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.tssEdit = new System.Windows.Forms.ToolStripSeparator();
            this.tsbEdit = new System.Windows.Forms.ToolStripButton();
            this.tssNew = new System.Windows.Forms.ToolStripSeparator();
            this.tsbNew = new System.Windows.Forms.ToolStripButton();
            this.pnlgroup = new System.Windows.Forms.Panel();
            this.lvGroup = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DGV_SearchGrid = new System.Windows.Forms.DataGridView();
            this.txtProductGroup = new System.Windows.Forms.TextBox();
            this.grpSearch = new System.Windows.Forms.GroupBox();
            this.txtSearchProduct = new System.Windows.Forms.TextBox();
            this.grbFilterBy = new System.Windows.Forms.GroupBox();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblProductGroup = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            this.lblNoOfPrGroup = new System.Windows.Forms.Label();
            this.btnView = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblNoRecordsFound = new System.Windows.Forms.Label();
            this.grdGroupList = new System.Windows.Forms.DataGridView();
            this.picLoader = new System.Windows.Forms.PictureBox();
            this.dynamicLabelControl = new ROMS.DynamicToolStripLabelControl();
            this.tsLabelPlaceholder = new System.Windows.Forms.ToolStripLabel();
            this.tsGroupList.SuspendLayout();
            this.pnlgroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_SearchGrid)).BeginInit();
            this.grpSearch.SuspendLayout();
            this.grbFilterBy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdGroupList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).BeginInit();
            this.SuspendLayout();
            // 
            // tsGroupList
            // 
            this.tsGroupList.BackColor = System.Drawing.Color.White;
            this.tsGroupList.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsGroupList.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsGroupList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbDelete,
            this.tssEdit,
            this.tsbEdit,
            this.tssNew,
            this.tsbNew,
            this.tsLabelPlaceholder});
            this.tsGroupList.Location = new System.Drawing.Point(0, 0);
            this.tsGroupList.Name = "tsGroupList";
            this.tsGroupList.Size = new System.Drawing.Size(1354, 27);
            this.tsGroupList.TabIndex = 35;
            this.tsGroupList.Text = "Group";
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
            // pnlgroup
            // 
            this.pnlgroup.BackColor = System.Drawing.Color.White;
            this.pnlgroup.Controls.Add(this.lvGroup);
            this.pnlgroup.Controls.Add(this.DGV_SearchGrid);
            this.pnlgroup.Controls.Add(this.txtProductGroup);
            this.pnlgroup.Controls.Add(this.grpSearch);
            this.pnlgroup.Controls.Add(this.grbFilterBy);
            this.pnlgroup.Controls.Add(this.lblNoRecordsFound);
            this.pnlgroup.Controls.Add(this.grdGroupList);
            this.pnlgroup.Controls.Add(this.picLoader);
            this.pnlgroup.Location = new System.Drawing.Point(0, 31);
            this.pnlgroup.Name = "pnlgroup";
            this.pnlgroup.Size = new System.Drawing.Size(1354, 641);
            this.pnlgroup.TabIndex = 958792;
            this.pnlgroup.Paint += new System.Windows.Forms.PaintEventHandler(this.Pnlgroup_Paint);
            // 
            // lvGroup
            // 
            this.lvGroup.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.lvGroup.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvGroup.HideSelection = false;
            this.lvGroup.Location = new System.Drawing.Point(103, 54);
            this.lvGroup.Name = "lvGroup";
            this.lvGroup.Size = new System.Drawing.Size(457, 157);
            this.lvGroup.TabIndex = 958804;
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
            this.DGV_SearchGrid.Location = new System.Drawing.Point(3, 71);
            this.DGV_SearchGrid.Name = "DGV_SearchGrid";
            this.DGV_SearchGrid.RowHeadersVisible = false;
            this.DGV_SearchGrid.RowHeadersWidth = 70;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.Black;
            this.DGV_SearchGrid.RowsDefaultCellStyle = dataGridViewCellStyle15;
            this.DGV_SearchGrid.RowTemplate.Height = 25;
            this.DGV_SearchGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DGV_SearchGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DGV_SearchGrid.ShowRowErrors = false;
            this.DGV_SearchGrid.Size = new System.Drawing.Size(1348, 56);
            this.DGV_SearchGrid.TabIndex = 958817;
            this.DGV_SearchGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_SearchGrid_CellEndEdit);
            this.DGV_SearchGrid.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.DGV_SearchGrid_CellPainting);
            this.DGV_SearchGrid.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DGV_SearchGrid_ColumnHeaderMouseClick);
            this.DGV_SearchGrid.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.DGV_SearchGrid_ColumnWidthChanged);
            this.DGV_SearchGrid.CurrentCellDirtyStateChanged += new System.EventHandler(this.DGV_SearchGrid_CurrentCellDirtyStateChanged);
            this.DGV_SearchGrid.Scroll += new System.Windows.Forms.ScrollEventHandler(this.DGV_SearchGrid_Scroll);
            // 
            // txtProductGroup
            // 
            this.txtProductGroup.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductGroup.Location = new System.Drawing.Point(103, 27);
            this.txtProductGroup.MaxLength = 50;
            this.txtProductGroup.Name = "txtProductGroup";
            this.txtProductGroup.Size = new System.Drawing.Size(239, 27);
            this.txtProductGroup.TabIndex = 0;
            this.txtProductGroup.TextChanged += new System.EventHandler(this.TxtProductGroup_TextChanged);
            this.txtProductGroup.Enter += new System.EventHandler(this.TxtProductGroup_Enter);
            this.txtProductGroup.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtProductGroup_KeyDown);
            this.txtProductGroup.Leave += new System.EventHandler(this.TxtProductGroup_Leave);
            // 
            // grpSearch
            // 
            this.grpSearch.Controls.Add(this.txtSearchProduct);
            this.grpSearch.Location = new System.Drawing.Point(1027, 2);
            this.grpSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpSearch.Name = "grpSearch";
            this.grpSearch.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpSearch.Size = new System.Drawing.Size(321, 67);
            this.grpSearch.TabIndex = 4;
            this.grpSearch.TabStop = false;
            this.grpSearch.Text = "Search By Product Group Name";
            this.grpSearch.Enter += new System.EventHandler(this.GrpSearch_Enter);
            // 
            // txtSearchProduct
            // 
            this.txtSearchProduct.Location = new System.Drawing.Point(13, 26);
            this.txtSearchProduct.Name = "txtSearchProduct";
            this.txtSearchProduct.Size = new System.Drawing.Size(296, 27);
            this.txtSearchProduct.TabIndex = 4;
            this.txtSearchProduct.TextChanged += new System.EventHandler(this.TxtSearchProduct_TextChanged);
            this.txtSearchProduct.Enter += new System.EventHandler(this.TxtSearchProduct_Enter);
            this.txtSearchProduct.Leave += new System.EventHandler(this.TxtSearchProduct_Leave);
            // 
            // grbFilterBy
            // 
            this.grbFilterBy.Controls.Add(this.cmbStatus);
            this.grbFilterBy.Controls.Add(this.lblStatus);
            this.grbFilterBy.Controls.Add(this.lblProductGroup);
            this.grbFilterBy.Controls.Add(this.btnExport);
            this.grbFilterBy.Controls.Add(this.lblNoOfPrGroup);
            this.grbFilterBy.Controls.Add(this.btnView);
            this.grbFilterBy.Controls.Add(this.label1);
            this.grbFilterBy.Location = new System.Drawing.Point(3, 3);
            this.grbFilterBy.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbFilterBy.Name = "grbFilterBy";
            this.grbFilterBy.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbFilterBy.Size = new System.Drawing.Size(1015, 67);
            this.grbFilterBy.TabIndex = 0;
            this.grbFilterBy.TabStop = false;
            this.grbFilterBy.Text = "Filter By Product Group";
            this.grbFilterBy.Enter += new System.EventHandler(this.GrbFilterBy_Enter);
            // 
            // cmbStatus
            // 
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(396, 27);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(126, 27);
            this.cmbStatus.TabIndex = 1;
            this.cmbStatus.Enter += new System.EventHandler(this.CmbStatus_Enter);
            this.cmbStatus.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbStatus_KeyDown);
            this.cmbStatus.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbStatus_KeyPress);
            this.cmbStatus.Leave += new System.EventHandler(this.CmbStatus_Leave);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(345, 30);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(45, 20);
            this.lblStatus.TabIndex = 958815;
            this.lblStatus.Text = "Status";
            // 
            // lblProductGroup
            // 
            this.lblProductGroup.AutoSize = true;
            this.lblProductGroup.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductGroup.Location = new System.Drawing.Point(6, 30);
            this.lblProductGroup.Name = "lblProductGroup";
            this.lblProductGroup.Size = new System.Drawing.Size(88, 20);
            this.lblProductGroup.TabIndex = 958814;
            this.lblProductGroup.Text = "Product Group";
            // 
            // btnExport
            // 
            this.btnExport.Image = global::ROMS.Properties.Resources.excel;
            this.btnExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExport.Location = new System.Drawing.Point(609, 25);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(79, 29);
            this.btnExport.TabIndex = 3;
            this.btnExport.Text = "Export";
            this.btnExport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.BtnExport_Click);
            this.btnExport.Enter += new System.EventHandler(this.BtnExport_Enter);
            this.btnExport.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BtnExport_KeyDown);
            this.btnExport.Leave += new System.EventHandler(this.BtnExport_Leave);
            // 
            // lblNoOfPrGroup
            // 
            this.lblNoOfPrGroup.AutoSize = true;
            this.lblNoOfPrGroup.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Bold);
            this.lblNoOfPrGroup.ForeColor = System.Drawing.Color.Crimson;
            this.lblNoOfPrGroup.Location = new System.Drawing.Point(830, 32);
            this.lblNoOfPrGroup.Name = "lblNoOfPrGroup";
            this.lblNoOfPrGroup.Size = new System.Drawing.Size(17, 20);
            this.lblNoOfPrGroup.TabIndex = 958796;
            this.lblNoOfPrGroup.Text = "0";
            // 
            // btnView
            // 
            this.btnView.Image = global::ROMS.Properties.Resources.view;
            this.btnView.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnView.Location = new System.Drawing.Point(528, 25);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(75, 29);
            this.btnView.TabIndex = 2;
            this.btnView.Text = "View";
            this.btnView.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.BtnView_Click);
            this.btnView.Enter += new System.EventHandler(this.BtnView_Enter);
            this.btnView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BtnView_KeyDown);
            this.btnView.Leave += new System.EventHandler(this.BtnView_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(694, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 20);
            this.label1.TabIndex = 958795;
            this.label1.Text = "No.of Product Groups :";
            // 
            // lblNoRecordsFound
            // 
            this.lblNoRecordsFound.AutoSize = true;
            this.lblNoRecordsFound.BackColor = System.Drawing.Color.White;
            this.lblNoRecordsFound.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoRecordsFound.Location = new System.Drawing.Point(624, 374);
            this.lblNoRecordsFound.Name = "lblNoRecordsFound";
            this.lblNoRecordsFound.Size = new System.Drawing.Size(106, 20);
            this.lblNoRecordsFound.TabIndex = 958793;
            this.lblNoRecordsFound.Text = "No Records Found";
            this.lblNoRecordsFound.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // grdGroupList
            // 
            this.grdGroupList.AllowUserToAddRows = false;
            this.grdGroupList.AllowUserToDeleteRows = false;
            this.grdGroupList.AllowUserToResizeColumns = false;
            this.grdGroupList.AllowUserToResizeRows = false;
            this.grdGroupList.BackgroundColor = System.Drawing.Color.White;
            this.grdGroupList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle16.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle16.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdGroupList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle16;
            this.grdGroupList.ColumnHeadersHeight = 30;
            this.grdGroupList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdGroupList.ColumnHeadersVisible = false;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle17.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdGroupList.DefaultCellStyle = dataGridViewCellStyle17;
            this.grdGroupList.EnableHeadersVisualStyles = false;
            this.grdGroupList.GridColor = System.Drawing.Color.White;
            this.grdGroupList.Location = new System.Drawing.Point(3, 127);
            this.grdGroupList.Name = "grdGroupList";
            this.grdGroupList.ReadOnly = true;
            this.grdGroupList.RowHeadersVisible = false;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.Color.White;
            this.grdGroupList.RowsDefaultCellStyle = dataGridViewCellStyle18;
            this.grdGroupList.RowTemplate.Height = 25;
            this.grdGroupList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdGroupList.Size = new System.Drawing.Size(1348, 514);
            this.grdGroupList.TabIndex = 958792;
            this.grdGroupList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrdGroupList_CellDoubleClick);
            this.grdGroupList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.GrdGroupList_DataBindingComplete);
            this.grdGroupList.Scroll += new System.Windows.Forms.ScrollEventHandler(this.GrdGroupList_Scroll);
            this.grdGroupList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GrdGroupList_KeyDown);
            // 
            // picLoader
            // 
            this.picLoader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picLoader.ErrorImage = null;
            this.picLoader.Image = global::ROMS.Properties.Resources.Iphone_spinner_2;
            this.picLoader.InitialImage = null;
            this.picLoader.Location = new System.Drawing.Point(3, 71);
            this.picLoader.Name = "picLoader";
            this.picLoader.Size = new System.Drawing.Size(1348, 570);
            this.picLoader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picLoader.TabIndex = 958800;
            this.picLoader.TabStop = false;
            this.picLoader.Visible = false;
            // 
            // dynamicLabelControl
            // 
            this.dynamicLabelControl.PlaceholderLabel = null;
            // 
            // tsLabelPlaceholder
            // 
            this.tsLabelPlaceholder.Name = "tsLabelPlaceholder";
            this.tsLabelPlaceholder.Size = new System.Drawing.Size(42, 24);
            this.tsLabelPlaceholder.Text = "Levels";
            // 
            // CP_GroupList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(1354, 675);
            this.Controls.Add(this.pnlgroup);
            this.Controls.Add(this.tsGroupList);
            this.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "CP_GroupList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Group";
            this.Load += new System.EventHandler(this.CP_GroupList_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CP_GroupList_KeyDown);
            this.tsGroupList.ResumeLayout(false);
            this.tsGroupList.PerformLayout();
            this.pnlgroup.ResumeLayout(false);
            this.pnlgroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_SearchGrid)).EndInit();
            this.grpSearch.ResumeLayout(false);
            this.grpSearch.PerformLayout();
            this.grbFilterBy.ResumeLayout(false);
            this.grbFilterBy.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdGroupList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsGroupList;
        public System.Windows.Forms.ToolStripButton tsbDelete;
        public System.Windows.Forms.ToolStripSeparator tssEdit;
        public System.Windows.Forms.ToolStripButton tsbEdit;
        public System.Windows.Forms.ToolStripSeparator tssNew;
        public System.Windows.Forms.ToolStripButton tsbNew;
        private System.Windows.Forms.Panel pnlgroup;
        private System.Windows.Forms.Label lblNoOfPrGroup;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grbFilterBy;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Label lblNoRecordsFound;
        public System.Windows.Forms.DataGridView grdGroupList;
        private System.Windows.Forms.PictureBox picLoader;
        private System.Windows.Forms.GroupBox grpSearch;
        private System.Windows.Forms.TextBox txtSearchProduct;
        private System.Windows.Forms.TextBox txtProductGroup;
        public System.Windows.Forms.ListView lvGroup;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        public System.Windows.Forms.DataGridView DGV_SearchGrid;
        private System.Windows.Forms.Label lblProductGroup;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbStatus;
        private DynamicToolStripLabelControl dynamicLabelControl;
        private System.Windows.Forms.ToolStripLabel tsLabelPlaceholder;
    }
}