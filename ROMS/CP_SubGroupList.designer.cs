namespace ROMS
{
    partial class CP_SubGroupList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tsGroupList = new System.Windows.Forms.ToolStrip();
            this.tspHeader = new System.Windows.Forms.ToolStripLabel();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.tssEdit = new System.Windows.Forms.ToolStripSeparator();
            this.tsbEdit = new System.Windows.Forms.ToolStripButton();
            this.tssNew = new System.Windows.Forms.ToolStripSeparator();
            this.tsbNew = new System.Windows.Forms.ToolStripButton();
            this.pnlSubgroup = new System.Windows.Forms.Panel();
            this.grpSearch = new System.Windows.Forms.GroupBox();
            this.txtSearchProduct = new System.Windows.Forms.TextBox();
            this.lblNoOfPrSubGroup = new System.Windows.Forms.Label();
            this.lblNoPrSubGroup = new System.Windows.Forms.Label();
            this.grbFilterBy = new System.Windows.Forms.GroupBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.lblNoRecordsFound = new System.Windows.Forms.Label();
            this.grdSubGroupList = new System.Windows.Forms.DataGridView();
            this.picLoader = new System.Windows.Forms.PictureBox();
            this.grdGroupList = new System.Windows.Forms.DataGridView();
            this.txtProductSubGroup = new System.Windows.Forms.TextBox();
            this.lvSubGroup = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblSubGroupId = new System.Windows.Forms.Label();
            this.tsGroupList.SuspendLayout();
            this.pnlSubgroup.SuspendLayout();
            this.grpSearch.SuspendLayout();
            this.grbFilterBy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSubGroupList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdGroupList)).BeginInit();
            this.SuspendLayout();
            // 
            // tsGroupList
            // 
            this.tsGroupList.BackColor = System.Drawing.Color.White;
            this.tsGroupList.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsGroupList.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsGroupList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspHeader,
            this.tsbDelete,
            this.tssEdit,
            this.tsbEdit,
            this.tssNew,
            this.tsbNew});
            this.tsGroupList.Location = new System.Drawing.Point(0, 0);
            this.tsGroupList.Name = "tsGroupList";
            this.tsGroupList.Size = new System.Drawing.Size(1354, 27);
            this.tsGroupList.TabIndex = 35;
            this.tsGroupList.Text = "Group";
            // 
            // tspHeader
            // 
            this.tspHeader.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tspHeader.Image = global::ROMS.Properties.Resources.bread_crumb;
            this.tspHeader.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tspHeader.Margin = new System.Windows.Forms.Padding(15, 1, 0, 2);
            this.tspHeader.Name = "tspHeader";
            this.tspHeader.Size = new System.Drawing.Size(128, 24);
            this.tspHeader.Text = "Product Sub Group";
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
            // pnlSubgroup
            // 
            this.pnlSubgroup.BackColor = System.Drawing.Color.White;
            this.pnlSubgroup.Controls.Add(this.grpSearch);
            this.pnlSubgroup.Controls.Add(this.lvSubGroup);
            this.pnlSubgroup.Controls.Add(this.lblNoOfPrSubGroup);
            this.pnlSubgroup.Controls.Add(this.lblNoPrSubGroup);
            this.pnlSubgroup.Controls.Add(this.grbFilterBy);
            this.pnlSubgroup.Controls.Add(this.lblNoRecordsFound);
            this.pnlSubgroup.Controls.Add(this.grdSubGroupList);
            this.pnlSubgroup.Controls.Add(this.picLoader);
            this.pnlSubgroup.Location = new System.Drawing.Point(0, 31);
            this.pnlSubgroup.Name = "pnlSubgroup";
            this.pnlSubgroup.Size = new System.Drawing.Size(1354, 641);
            this.pnlSubgroup.TabIndex = 958792;
            // 
            // grpSearch
            // 
            this.grpSearch.Controls.Add(this.txtSearchProduct);
            this.grpSearch.Location = new System.Drawing.Point(1030, 2);
            this.grpSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpSearch.Name = "grpSearch";
            this.grpSearch.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpSearch.Size = new System.Drawing.Size(321, 67);
            this.grpSearch.TabIndex = 958798;
            this.grpSearch.TabStop = false;
            this.grpSearch.Text = "Search By Product Sub Group";
            // 
            // txtSearchProduct
            // 
            this.txtSearchProduct.Location = new System.Drawing.Point(13, 26);
            this.txtSearchProduct.Name = "txtSearchProduct";
            this.txtSearchProduct.Size = new System.Drawing.Size(296, 27);
            this.txtSearchProduct.TabIndex = 0;
            this.txtSearchProduct.TextChanged += new System.EventHandler(this.TxtSearchProduct_TextChanged);
            this.txtSearchProduct.Enter += new System.EventHandler(this.TxtSearchProduct_Enter);
            this.txtSearchProduct.Leave += new System.EventHandler(this.TxtSearchProduct_Leave);
            // 
            // lblNoOfPrSubGroup
            // 
            this.lblNoOfPrSubGroup.AutoSize = true;
            this.lblNoOfPrSubGroup.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Bold);
            this.lblNoOfPrSubGroup.ForeColor = System.Drawing.Color.Crimson;
            this.lblNoOfPrSubGroup.Location = new System.Drawing.Point(603, 26);
            this.lblNoOfPrSubGroup.Name = "lblNoOfPrSubGroup";
            this.lblNoOfPrSubGroup.Size = new System.Drawing.Size(17, 20);
            this.lblNoOfPrSubGroup.TabIndex = 958797;
            this.lblNoOfPrSubGroup.Text = "0";
            // 
            // lblNoPrSubGroup
            // 
            this.lblNoPrSubGroup.AutoSize = true;
            this.lblNoPrSubGroup.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.lblNoPrSubGroup.ForeColor = System.Drawing.Color.Black;
            this.lblNoPrSubGroup.Location = new System.Drawing.Point(447, 26);
            this.lblNoPrSubGroup.Name = "lblNoPrSubGroup";
            this.lblNoPrSubGroup.Size = new System.Drawing.Size(154, 20);
            this.lblNoPrSubGroup.TabIndex = 958796;
            this.lblNoPrSubGroup.Text = "No.of Product Sub Groups :";
            // 
            // grbFilterBy
            // 
            this.grbFilterBy.Controls.Add(this.lblSubGroupId);
            this.grbFilterBy.Controls.Add(this.txtProductSubGroup);
            this.grbFilterBy.Controls.Add(this.btnExport);
            this.grbFilterBy.Controls.Add(this.btnView);
            this.grbFilterBy.Location = new System.Drawing.Point(3, 2);
            this.grbFilterBy.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbFilterBy.Name = "grbFilterBy";
            this.grbFilterBy.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbFilterBy.Size = new System.Drawing.Size(1021, 67);
            this.grbFilterBy.TabIndex = 958795;
            this.grbFilterBy.TabStop = false;
            this.grbFilterBy.Text = "Filter By Product Sub Group";
            // 
            // btnExport
            // 
            this.btnExport.Image = global::ROMS.Properties.Resources.excel;
            this.btnExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExport.Location = new System.Drawing.Point(356, 22);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(79, 29);
            this.btnExport.TabIndex = 2;
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
            this.btnView.Location = new System.Drawing.Point(274, 22);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(75, 29);
            this.btnView.TabIndex = 1;
            this.btnView.Text = "View";
            this.btnView.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            this.btnView.Enter += new System.EventHandler(this.BtnView_Enter);
            this.btnView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BtnView_KeyDown);
            this.btnView.Leave += new System.EventHandler(this.BtnView_Leave);
            // 
            // lblNoRecordsFound
            // 
            this.lblNoRecordsFound.AutoSize = true;
            this.lblNoRecordsFound.BackColor = System.Drawing.Color.White;
            this.lblNoRecordsFound.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoRecordsFound.Location = new System.Drawing.Point(624, 346);
            this.lblNoRecordsFound.Name = "lblNoRecordsFound";
            this.lblNoRecordsFound.Size = new System.Drawing.Size(106, 20);
            this.lblNoRecordsFound.TabIndex = 958793;
            this.lblNoRecordsFound.Text = "No Records Found";
            this.lblNoRecordsFound.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // grdSubGroupList
            // 
            this.grdSubGroupList.AllowUserToAddRows = false;
            this.grdSubGroupList.AllowUserToDeleteRows = false;
            this.grdSubGroupList.AllowUserToResizeColumns = false;
            this.grdSubGroupList.AllowUserToResizeRows = false;
            this.grdSubGroupList.BackgroundColor = System.Drawing.Color.White;
            this.grdSubGroupList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(242)))), ((int)(((byte)(213)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdSubGroupList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.grdSubGroupList.ColumnHeadersHeight = 30;
            this.grdSubGroupList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdSubGroupList.DefaultCellStyle = dataGridViewCellStyle8;
            this.grdSubGroupList.EnableHeadersVisualStyles = false;
            this.grdSubGroupList.GridColor = System.Drawing.Color.White;
            this.grdSubGroupList.Location = new System.Drawing.Point(3, 71);
            this.grdSubGroupList.Name = "grdSubGroupList";
            this.grdSubGroupList.ReadOnly = true;
            this.grdSubGroupList.RowHeadersVisible = false;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.White;
            this.grdSubGroupList.RowsDefaultCellStyle = dataGridViewCellStyle9;
            this.grdSubGroupList.RowTemplate.Height = 25;
            this.grdSubGroupList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdSubGroupList.Size = new System.Drawing.Size(1348, 570);
            this.grdSubGroupList.TabIndex = 958792;
            this.grdSubGroupList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.GrdSubGroupList_DataBindingComplete);
            this.grdSubGroupList.DoubleClick += new System.EventHandler(this.GrdSubGroupList_DoubleClick);
            this.grdSubGroupList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GrdSubGroupList_KeyDown);
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
            this.picLoader.TabIndex = 958794;
            this.picLoader.TabStop = false;
            this.picLoader.Visible = false;
            // 
            // grdGroupList
            // 
            this.grdGroupList.AllowUserToAddRows = false;
            this.grdGroupList.AllowUserToDeleteRows = false;
            this.grdGroupList.AllowUserToResizeColumns = false;
            this.grdGroupList.AllowUserToResizeRows = false;
            this.grdGroupList.BackgroundColor = System.Drawing.Color.White;
            this.grdGroupList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(242)))), ((int)(((byte)(213)))));
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdGroupList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.grdGroupList.ColumnHeadersHeight = 30;
            this.grdGroupList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdGroupList.DefaultCellStyle = dataGridViewCellStyle11;
            this.grdGroupList.EnableHeadersVisualStyles = false;
            this.grdGroupList.GridColor = System.Drawing.Color.White;
            this.grdGroupList.Location = new System.Drawing.Point(3, 103);
            this.grdGroupList.Name = "grdGroupList";
            this.grdGroupList.ReadOnly = true;
            this.grdGroupList.RowHeadersVisible = false;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.White;
            this.grdGroupList.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.grdGroupList.RowTemplate.Height = 25;
            this.grdGroupList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdGroupList.Size = new System.Drawing.Size(1348, 570);
            this.grdGroupList.TabIndex = 958793;
            // 
            // txtProductSubGroup
            // 
            this.txtProductSubGroup.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtProductSubGroup.Location = new System.Drawing.Point(11, 23);
            this.txtProductSubGroup.MaxLength = 30;
            this.txtProductSubGroup.Name = "txtProductSubGroup";
            this.txtProductSubGroup.Size = new System.Drawing.Size(257, 27);
            this.txtProductSubGroup.TabIndex = 958807;
            this.txtProductSubGroup.TextChanged += new System.EventHandler(this.TxtProductSubGroup_TextChanged);
            this.txtProductSubGroup.Enter += new System.EventHandler(this.TxtProductSubGroup_Enter);
            this.txtProductSubGroup.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtProductSubGroup_KeyDown);
            this.txtProductSubGroup.Leave += new System.EventHandler(this.TxtProductSubGroup_Leave);
            // 
            // lvSubGroup
            // 
            this.lvSubGroup.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvSubGroup.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvSubGroup.HideSelection = false;
            this.lvSubGroup.Location = new System.Drawing.Point(11, 60);
            this.lvSubGroup.Name = "lvSubGroup";
            this.lvSubGroup.Size = new System.Drawing.Size(397, 99);
            this.lvSubGroup.TabIndex = 958808;
            this.lvSubGroup.UseCompatibleStateImageBehavior = false;
            this.lvSubGroup.View = System.Windows.Forms.View.Details;
            this.lvSubGroup.Visible = false;
            this.lvSubGroup.DoubleClick += new System.EventHandler(this.LvSubGroup_DoubleClick);
            this.lvSubGroup.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LvSubGroup_KeyDown);
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
            // lblSubGroupId
            // 
            this.lblSubGroupId.AutoSize = true;
            this.lblSubGroupId.Location = new System.Drawing.Point(646, 26);
            this.lblSubGroupId.Name = "lblSubGroupId";
            this.lblSubGroupId.Size = new System.Drawing.Size(0, 20);
            this.lblSubGroupId.TabIndex = 958808;
            this.lblSubGroupId.Visible = false;
            // 
            // CP_SubGroupList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(1354, 675);
            this.Controls.Add(this.pnlSubgroup);
            this.Controls.Add(this.tsGroupList);
            this.Controls.Add(this.grdGroupList);
            this.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "CP_SubGroupList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Group";
            this.Load += new System.EventHandler(this.CP_SubGroupList_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CP_SubGroupList_KeyDown);
            this.tsGroupList.ResumeLayout(false);
            this.tsGroupList.PerformLayout();
            this.pnlSubgroup.ResumeLayout(false);
            this.pnlSubgroup.PerformLayout();
            this.grpSearch.ResumeLayout(false);
            this.grpSearch.PerformLayout();
            this.grbFilterBy.ResumeLayout(false);
            this.grbFilterBy.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSubGroupList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdGroupList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsGroupList;
        private System.Windows.Forms.ToolStripLabel tspHeader;
        public System.Windows.Forms.ToolStripButton tsbDelete;
        public System.Windows.Forms.ToolStripSeparator tssEdit;
        public System.Windows.Forms.ToolStripButton tsbEdit;
        public System.Windows.Forms.ToolStripSeparator tssNew;
        public System.Windows.Forms.ToolStripButton tsbNew;
        private System.Windows.Forms.Panel pnlSubgroup;
        private System.Windows.Forms.Label lblNoOfPrSubGroup;
        private System.Windows.Forms.Label lblNoPrSubGroup;
        private System.Windows.Forms.GroupBox grbFilterBy;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Label lblNoRecordsFound;
        public System.Windows.Forms.DataGridView grdSubGroupList;
        private System.Windows.Forms.PictureBox picLoader;
        public System.Windows.Forms.DataGridView grdGroupList;
        private System.Windows.Forms.GroupBox grpSearch;
        private System.Windows.Forms.TextBox txtSearchProduct;
        public System.Windows.Forms.ListView lvSubGroup;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.TextBox txtProductSubGroup;
        private System.Windows.Forms.Label lblSubGroupId;
    }
}