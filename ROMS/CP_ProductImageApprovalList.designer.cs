namespace ROMS
{
    partial class CP_ProductImageApprovalList
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
            this.tsProductApproval = new System.Windows.Forms.ToolStrip();
            this.tsbEdit = new System.Windows.Forms.ToolStripButton();
            this.pnlItemList = new System.Windows.Forms.Panel();
            this.lvSubGroup = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvGroup = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblNoRecordsFound = new System.Windows.Forms.Label();
            this.grdItemList = new System.Windows.Forms.DataGridView();
            this.grpFilterby = new System.Windows.Forms.GroupBox();
            this.cmbDateFilter = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtProductGroup = new System.Windows.Forms.TextBox();
            this.lblGroupId = new System.Windows.Forms.Label();
            this.lblSubGroupId = new System.Windows.Forms.Label();
            this.txtProductSubGroup = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblPC = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnView = new System.Windows.Forms.Button();
            this.cmbConcern = new System.Windows.Forms.ComboBox();
            this.lblProductSubGroup = new System.Windows.Forms.Label();
            this.lblProductgroup = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DGV_SearchGrid = new System.Windows.Forms.DataGridView();
            this.clmdsno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.icode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmpronameenglish = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmdpronametamil = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmprosubgroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDPurchaseUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BatchNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmdstatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.picLoader = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tsLabelPlaceholder = new System.Windows.Forms.ToolStripLabel();
            this.dynamicLabelControl = new ROMS.DynamicToolStripLabelControl();
            this.tsProductApproval.SuspendLayout();
            this.pnlItemList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdItemList)).BeginInit();
            this.grpFilterby.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_SearchGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tsProductApproval
            // 
            this.tsProductApproval.BackColor = System.Drawing.Color.White;
            this.tsProductApproval.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsProductApproval.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsProductApproval.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbEdit,
            this.tsLabelPlaceholder});
            this.tsProductApproval.Location = new System.Drawing.Point(0, 0);
            this.tsProductApproval.Name = "tsProductApproval";
            this.tsProductApproval.Size = new System.Drawing.Size(1354, 27);
            this.tsProductApproval.TabIndex = 35;
            this.tsProductApproval.Text = "ItemList";
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
            // pnlItemList
            // 
            this.pnlItemList.BackColor = System.Drawing.Color.White;
            this.pnlItemList.Controls.Add(this.lvSubGroup);
            this.pnlItemList.Controls.Add(this.lvGroup);
            this.pnlItemList.Controls.Add(this.lblNoRecordsFound);
            this.pnlItemList.Controls.Add(this.grdItemList);
            this.pnlItemList.Controls.Add(this.grpFilterby);
            this.pnlItemList.Controls.Add(this.DGV_SearchGrid);
            this.pnlItemList.Controls.Add(this.picLoader);
            this.pnlItemList.Controls.Add(this.pictureBox1);
            this.pnlItemList.Location = new System.Drawing.Point(0, 31);
            this.pnlItemList.Name = "pnlItemList";
            this.pnlItemList.Size = new System.Drawing.Size(1354, 641);
            this.pnlItemList.TabIndex = 36;
            // 
            // lvSubGroup
            // 
            this.lvSubGroup.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvSubGroup.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvSubGroup.HideSelection = false;
            this.lvSubGroup.Location = new System.Drawing.Point(537, 71);
            this.lvSubGroup.Name = "lvSubGroup";
            this.lvSubGroup.Size = new System.Drawing.Size(457, 157);
            this.lvSubGroup.TabIndex = 958809;
            this.lvSubGroup.UseCompatibleStateImageBehavior = false;
            this.lvSubGroup.View = System.Windows.Forms.View.Details;
            this.lvSubGroup.Visible = false;
            this.lvSubGroup.DoubleClick += new System.EventHandler(this.LvSubGroup_DoubleClick_1);
            this.lvSubGroup.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LvSubGroup_KeyDown_1);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 180;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Width = 10;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Width = 0;
            // 
            // lvGroup
            // 
            this.lvGroup.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.lvGroup.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvGroup.HideSelection = false;
            this.lvGroup.Location = new System.Drawing.Point(308, 72);
            this.lvGroup.Name = "lvGroup";
            this.lvGroup.Size = new System.Drawing.Size(457, 157);
            this.lvGroup.TabIndex = 958808;
            this.lvGroup.UseCompatibleStateImageBehavior = false;
            this.lvGroup.View = System.Windows.Forms.View.Details;
            this.lvGroup.Visible = false;
            this.lvGroup.DoubleClick += new System.EventHandler(this.LvGroup_DoubleClick);
            this.lvGroup.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LvGroup_KeyDown);
            // 
            // columnHeader4
            // 
            this.columnHeader4.Width = 180;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Width = 10;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Width = 0;
            // 
            // lblNoRecordsFound
            // 
            this.lblNoRecordsFound.AutoSize = true;
            this.lblNoRecordsFound.BackColor = System.Drawing.Color.White;
            this.lblNoRecordsFound.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoRecordsFound.Location = new System.Drawing.Point(624, 397);
            this.lblNoRecordsFound.Name = "lblNoRecordsFound";
            this.lblNoRecordsFound.Size = new System.Drawing.Size(106, 20);
            this.lblNoRecordsFound.TabIndex = 958798;
            this.lblNoRecordsFound.Text = "No Records Found";
            this.lblNoRecordsFound.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // grdItemList
            // 
            this.grdItemList.AllowUserToAddRows = false;
            this.grdItemList.AllowUserToDeleteRows = false;
            this.grdItemList.AllowUserToResizeColumns = false;
            this.grdItemList.AllowUserToResizeRows = false;
            this.grdItemList.BackgroundColor = System.Drawing.Color.White;
            this.grdItemList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle13.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(242)))), ((int)(((byte)(213)))));
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdItemList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.grdItemList.ColumnHeadersHeight = 30;
            this.grdItemList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdItemList.ColumnHeadersVisible = false;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdItemList.DefaultCellStyle = dataGridViewCellStyle14;
            this.grdItemList.EnableHeadersVisualStyles = false;
            this.grdItemList.GridColor = System.Drawing.Color.White;
            this.grdItemList.Location = new System.Drawing.Point(3, 143);
            this.grdItemList.Name = "grdItemList";
            this.grdItemList.ReadOnly = true;
            this.grdItemList.RowHeadersVisible = false;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.grdItemList.RowsDefaultCellStyle = dataGridViewCellStyle15;
            this.grdItemList.RowTemplate.Height = 25;
            this.grdItemList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdItemList.ShowRowErrors = false;
            this.grdItemList.Size = new System.Drawing.Size(1348, 496);
            this.grdItemList.TabIndex = 958802;
            this.grdItemList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.GrdItemList_DataBindingComplete);
            this.grdItemList.Scroll += new System.Windows.Forms.ScrollEventHandler(this.GrdItemList_Scroll);
            this.grdItemList.DoubleClick += new System.EventHandler(this.GrdItemList_DoubleClick);
            this.grdItemList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GrdItemList_KeyDown);
            // 
            // grpFilterby
            // 
            this.grpFilterby.Controls.Add(this.cmbDateFilter);
            this.grpFilterby.Controls.Add(this.label4);
            this.grpFilterby.Controls.Add(this.txtProductGroup);
            this.grpFilterby.Controls.Add(this.lblGroupId);
            this.grpFilterby.Controls.Add(this.lblSubGroupId);
            this.grpFilterby.Controls.Add(this.txtProductSubGroup);
            this.grpFilterby.Controls.Add(this.label2);
            this.grpFilterby.Controls.Add(this.lblPC);
            this.grpFilterby.Controls.Add(this.cmbCategory);
            this.grpFilterby.Controls.Add(this.btnExport);
            this.grpFilterby.Controls.Add(this.label3);
            this.grpFilterby.Controls.Add(this.btnView);
            this.grpFilterby.Controls.Add(this.cmbConcern);
            this.grpFilterby.Controls.Add(this.lblProductSubGroup);
            this.grpFilterby.Controls.Add(this.lblProductgroup);
            this.grpFilterby.Controls.Add(this.label1);
            this.grpFilterby.Location = new System.Drawing.Point(3, 2);
            this.grpFilterby.Name = "grpFilterby";
            this.grpFilterby.Size = new System.Drawing.Size(1347, 80);
            this.grpFilterby.TabIndex = 0;
            this.grpFilterby.TabStop = false;
            this.grpFilterby.Text = "Filter By";
            // 
            // cmbDateFilter
            // 
            this.cmbDateFilter.FormattingEnabled = true;
            this.cmbDateFilter.Location = new System.Drawing.Point(765, 43);
            this.cmbDateFilter.Name = "cmbDateFilter";
            this.cmbDateFilter.Size = new System.Drawing.Size(106, 27);
            this.cmbDateFilter.TabIndex = 4;
            this.cmbDateFilter.Enter += new System.EventHandler(this.CmbDateFilter_Enter);
            this.cmbDateFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbDateFilter_KeyDown);
            this.cmbDateFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbDateFilter_KeyPress);
            this.cmbDateFilter.Leave += new System.EventHandler(this.CmbDateFilter_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(765, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 20);
            this.label4.TabIndex = 958825;
            this.label4.Text = "Created On";
            // 
            // txtProductGroup
            // 
            this.txtProductGroup.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtProductGroup.Location = new System.Drawing.Point(305, 43);
            this.txtProductGroup.MaxLength = 30;
            this.txtProductGroup.Name = "txtProductGroup";
            this.txtProductGroup.Size = new System.Drawing.Size(225, 27);
            this.txtProductGroup.TabIndex = 2;
            this.txtProductGroup.TextChanged += new System.EventHandler(this.TxtProductGroup_TextChanged);
            this.txtProductGroup.Enter += new System.EventHandler(this.TxtProductGroup_Enter);
            this.txtProductGroup.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtProductGroup_KeyDown);
            this.txtProductGroup.Leave += new System.EventHandler(this.TxtProductGroup_Leave);
            // 
            // lblGroupId
            // 
            this.lblGroupId.AutoSize = true;
            this.lblGroupId.Location = new System.Drawing.Point(1078, 20);
            this.lblGroupId.Name = "lblGroupId";
            this.lblGroupId.Size = new System.Drawing.Size(16, 20);
            this.lblGroupId.TabIndex = 958807;
            this.lblGroupId.Text = "0";
            this.lblGroupId.Visible = false;
            // 
            // lblSubGroupId
            // 
            this.lblSubGroupId.AutoSize = true;
            this.lblSubGroupId.Location = new System.Drawing.Point(1213, 46);
            this.lblSubGroupId.Name = "lblSubGroupId";
            this.lblSubGroupId.Size = new System.Drawing.Size(0, 20);
            this.lblSubGroupId.TabIndex = 958806;
            this.lblSubGroupId.Visible = false;
            // 
            // txtProductSubGroup
            // 
            this.txtProductSubGroup.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtProductSubGroup.Location = new System.Drawing.Point(534, 43);
            this.txtProductSubGroup.MaxLength = 30;
            this.txtProductSubGroup.Name = "txtProductSubGroup";
            this.txtProductSubGroup.Size = new System.Drawing.Size(225, 27);
            this.txtProductSubGroup.TabIndex = 3;
            this.txtProductSubGroup.TextChanged += new System.EventHandler(this.TxtProductSubGroup_TextChanged);
            this.txtProductSubGroup.Enter += new System.EventHandler(this.TxtProductSubGroup_Enter);
            this.txtProductSubGroup.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtProductSubGroup_KeyDown);
            this.txtProductSubGroup.Leave += new System.EventHandler(this.TxtProductSubGroup_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(1043, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 20);
            this.label2.TabIndex = 958803;
            this.label2.Text = "No.of Products :";
            // 
            // lblPC
            // 
            this.lblPC.AutoSize = true;
            this.lblPC.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Bold);
            this.lblPC.ForeColor = System.Drawing.Color.Crimson;
            this.lblPC.Location = new System.Drawing.Point(1147, 46);
            this.lblPC.Name = "lblPC";
            this.lblPC.Size = new System.Drawing.Size(17, 20);
            this.lblPC.TabIndex = 958804;
            this.lblPC.Text = "0";
            // 
            // cmbCategory
            // 
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(132, 43);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(168, 27);
            this.cmbCategory.TabIndex = 1;
            this.cmbCategory.SelectedIndexChanged += new System.EventHandler(this.CmbCategory_SelectedIndexChanged);
            this.cmbCategory.Enter += new System.EventHandler(this.CmbCategory_Enter);
            this.cmbCategory.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbCategory_KeyDown);
            this.cmbCategory.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbCategory_KeyPress);
            this.cmbCategory.Leave += new System.EventHandler(this.CmbCategory_Leave);
            // 
            // btnExport
            // 
            this.btnExport.Image = global::ROMS.Properties.Resources.excel;
            this.btnExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExport.Location = new System.Drawing.Point(958, 41);
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(132, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 20);
            this.label3.TabIndex = 958799;
            this.label3.Text = "Product Category";
            // 
            // btnView
            // 
            this.btnView.Image = global::ROMS.Properties.Resources.view;
            this.btnView.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnView.Location = new System.Drawing.Point(877, 41);
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
            // cmbConcern
            // 
            this.cmbConcern.FormattingEnabled = true;
            this.cmbConcern.Location = new System.Drawing.Point(10, 43);
            this.cmbConcern.Name = "cmbConcern";
            this.cmbConcern.Size = new System.Drawing.Size(117, 27);
            this.cmbConcern.TabIndex = 0;
            this.cmbConcern.SelectedIndexChanged += new System.EventHandler(this.CmbConcern_SelectedIndexChanged);
            this.cmbConcern.Enter += new System.EventHandler(this.CmbConcern_Enter);
            this.cmbConcern.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbConcern_KeyDown);
            this.cmbConcern.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbConcern_KeyPress);
            this.cmbConcern.Leave += new System.EventHandler(this.CmbConcern_Leave);
            // 
            // lblProductSubGroup
            // 
            this.lblProductSubGroup.AutoSize = true;
            this.lblProductSubGroup.Location = new System.Drawing.Point(534, 20);
            this.lblProductSubGroup.Name = "lblProductSubGroup";
            this.lblProductSubGroup.Size = new System.Drawing.Size(108, 20);
            this.lblProductSubGroup.TabIndex = 4;
            this.lblProductSubGroup.Text = "Product Subgroup";
            // 
            // lblProductgroup
            // 
            this.lblProductgroup.AutoSize = true;
            this.lblProductgroup.Location = new System.Drawing.Point(305, 20);
            this.lblProductgroup.Name = "lblProductgroup";
            this.lblProductgroup.Size = new System.Drawing.Size(88, 20);
            this.lblProductgroup.TabIndex = 2;
            this.lblProductgroup.Text = "Product Group";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Concern";
            // 
            // DGV_SearchGrid
            // 
            this.DGV_SearchGrid.AllowUserToAddRows = false;
            this.DGV_SearchGrid.AllowUserToDeleteRows = false;
            this.DGV_SearchGrid.AllowUserToResizeRows = false;
            this.DGV_SearchGrid.BackgroundColor = System.Drawing.Color.White;
            this.DGV_SearchGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle16.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle16.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(242)))), ((int)(((byte)(213)))));
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_SearchGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle16;
            this.DGV_SearchGrid.ColumnHeadersHeight = 30;
            this.DGV_SearchGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGV_SearchGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmdsno,
            this.icode,
            this.clmpronameenglish,
            this.clmdpronametamil,
            this.dataGridViewTextBoxColumn15,
            this.clmprosubgroup,
            this.dataGridViewTextBoxColumn14,
            this.clmDPurchaseUnit,
            this.dataGridViewTextBoxColumn12,
            this.dataGridViewTextBoxColumn13,
            this.BatchNo,
            this.dataGridViewTextBoxColumn11,
            this.Column1,
            this.dataGridViewTextBoxColumn10,
            this.clmdstatus});
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle17.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV_SearchGrid.DefaultCellStyle = dataGridViewCellStyle17;
            this.DGV_SearchGrid.EnableHeadersVisualStyles = false;
            this.DGV_SearchGrid.GridColor = System.Drawing.Color.White;
            this.DGV_SearchGrid.Location = new System.Drawing.Point(3, 87);
            this.DGV_SearchGrid.Name = "DGV_SearchGrid";
            this.DGV_SearchGrid.RowHeadersVisible = false;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.Color.Black;
            this.DGV_SearchGrid.RowsDefaultCellStyle = dataGridViewCellStyle18;
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
            this.DGV_SearchGrid.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.DGV_SearchGrid_EditingControlShowing);
            this.DGV_SearchGrid.Scroll += new System.Windows.Forms.ScrollEventHandler(this.DGV_SearchGrid_Scroll);
            // 
            // clmdsno
            // 
            this.clmdsno.HeaderText = "S.No.";
            this.clmdsno.Name = "clmdsno";
            this.clmdsno.Width = 60;
            // 
            // icode
            // 
            this.icode.HeaderText = "P.I Code";
            this.icode.Name = "icode";
            // 
            // clmpronameenglish
            // 
            this.clmpronameenglish.HeaderText = "Product Name in English";
            this.clmpronameenglish.Name = "clmpronameenglish";
            this.clmpronameenglish.Width = 200;
            // 
            // clmdpronametamil
            // 
            this.clmdpronametamil.HeaderText = "Product Name in Tamil";
            this.clmdpronametamil.Name = "clmdpronametamil";
            this.clmdpronametamil.Width = 200;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.HeaderText = "Category";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            // 
            // clmprosubgroup
            // 
            this.clmprosubgroup.HeaderText = "Product Subgroup";
            this.clmprosubgroup.Name = "clmprosubgroup";
            this.clmprosubgroup.Width = 150;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.HeaderText = "Brand";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            // 
            // clmDPurchaseUnit
            // 
            this.clmDPurchaseUnit.HeaderText = "Unit";
            this.clmDPurchaseUnit.Name = "clmDPurchaseUnit";
            this.clmDPurchaseUnit.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.HeaderText = "Stock Location";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.HeaderText = "Rack";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            // 
            // BatchNo
            // 
            this.BatchNo.HeaderText = "Batch No.";
            this.BatchNo.Name = "BatchNo";
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.HeaderText = "Self life";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "GST %";
            this.Column1.Name = "Column1";
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.HeaderText = "HSN Name";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            // 
            // clmdstatus
            // 
            this.clmdstatus.HeaderText = "Status";
            this.clmdstatus.Name = "clmdstatus";
            // 
            // picLoader
            // 
            this.picLoader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picLoader.ErrorImage = null;
            this.picLoader.Image = global::ROMS.Properties.Resources.Iphone_spinner_2;
            this.picLoader.InitialImage = null;
            this.picLoader.Location = new System.Drawing.Point(3, 87);
            this.picLoader.Name = "picLoader";
            this.picLoader.Size = new System.Drawing.Size(1348, 552);
            this.picLoader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picLoader.TabIndex = 958799;
            this.picLoader.TabStop = false;
            this.picLoader.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Image = global::ROMS.Properties.Resources.Iphone_spinner_2;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(4, 88);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1346, 550);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 958805;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
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
            // CP_ProductApprovalList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(1354, 675);
            this.Controls.Add(this.pnlItemList);
            this.Controls.Add(this.tsProductApproval);
            this.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "CP_ProductApprovalList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Product Approval";
            this.Load += new System.EventHandler(this.CP_ProductList_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CP_ProductList_KeyDown);
            this.tsProductApproval.ResumeLayout(false);
            this.tsProductApproval.PerformLayout();
            this.pnlItemList.ResumeLayout(false);
            this.pnlItemList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdItemList)).EndInit();
            this.grpFilterby.ResumeLayout(false);
            this.grpFilterby.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_SearchGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsProductApproval;
        public System.Windows.Forms.ToolStripButton tsbEdit;
        private System.Windows.Forms.Panel pnlItemList;
        public System.Windows.Forms.DataGridView DGV_SearchGrid;
        private System.Windows.Forms.Label lblNoRecordsFound;
        private System.Windows.Forms.GroupBox grpFilterby;
        private System.Windows.Forms.Label lblProductgroup;
        private System.Windows.Forms.Label lblProductSubGroup;
        public System.Windows.Forms.DataGridView grdItemList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbConcern;
        private System.Windows.Forms.Label lblPC;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.PictureBox picLoader;
        private System.Windows.Forms.TextBox txtProductSubGroup;
        private System.Windows.Forms.Label lblSubGroupId;
        private System.Windows.Forms.TextBox txtProductGroup;
        public System.Windows.Forms.ListView lvGroup;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.Label lblGroupId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmdsno;
        private System.Windows.Forms.DataGridViewTextBoxColumn icode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmpronameenglish;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmdpronametamil;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmprosubgroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDPurchaseUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn BatchNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmdstatus;
        public System.Windows.Forms.ListView lvSubGroup;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbDateFilter;
        private System.Windows.Forms.ToolStripLabel tsLabelPlaceholder;
        private DynamicToolStripLabelControl dynamicLabelControl;
    }
}