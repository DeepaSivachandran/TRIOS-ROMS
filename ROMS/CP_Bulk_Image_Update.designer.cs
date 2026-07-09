namespace ROMS
{
    partial class CP_Bulk_Image_Update
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
            this.tsImageList = new System.Windows.Forms.ToolStrip();
            this.tspHeader = new System.Windows.Forms.ToolStripLabel();
            this.pnlImage = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.pnlImageContainer = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tsMenu = new System.Windows.Forms.ToolStrip();
            this.tsbBrowse = new System.Windows.Forms.ToolStripButton();
            this.grbSubgroups = new System.Windows.Forms.GroupBox();
            this.tvSubgroupProducts = new System.Windows.Forms.TreeView();
            this.flpSubGroups = new System.Windows.Forms.FlowLayoutPanel();
            this.grdSubgroups = new System.Windows.Forms.DataGridView();
            this.clmCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clmSubgroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmProduct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmImage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSGID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmView = new System.Windows.Forms.DataGridViewImageColumn();
            this.clmClear = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.tsImageList.SuspendLayout();
            this.pnlImage.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.pnlImageContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tsMenu.SuspendLayout();
            this.grbSubgroups.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSubgroups)).BeginInit();
            this.SuspendLayout();
            // 
            // tsImageList
            // 
            this.tsImageList.BackColor = System.Drawing.Color.White;
            this.tsImageList.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsImageList.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsImageList.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsImageList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspHeader});
            this.tsImageList.Location = new System.Drawing.Point(0, 0);
            this.tsImageList.Name = "tsImageList";
            this.tsImageList.Size = new System.Drawing.Size(1354, 25);
            this.tsImageList.TabIndex = 35;
            this.tsImageList.Text = "City";
            // 
            // tspHeader
            // 
            this.tspHeader.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tspHeader.Image = global::ROMS.Properties.Resources.bread_crumb;
            this.tspHeader.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tspHeader.Margin = new System.Windows.Forms.Padding(15, 1, 0, 2);
            this.tspHeader.Name = "tspHeader";
            this.tspHeader.Size = new System.Drawing.Size(100, 22);
            this.tspHeader.Text = "Image Update";
            // 
            // pnlImage
            // 
            this.pnlImage.BackColor = System.Drawing.Color.White;
            this.pnlImage.Controls.Add(this.groupBox1);
            this.pnlImage.Controls.Add(this.grbSubgroups);
            this.pnlImage.Location = new System.Drawing.Point(0, 31);
            this.pnlImage.Name = "pnlImage";
            this.pnlImage.Size = new System.Drawing.Size(1354, 641);
            this.pnlImage.TabIndex = 36;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.pnlImageContainer);
            this.groupBox1.Controls.Add(this.tsMenu);
            this.groupBox1.Location = new System.Drawing.Point(676, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(642, 629);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnClose.Image = global::ROMS.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(553, 594);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(74, 29);
            this.btnClose.TabIndex = 48;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnSave.Image = global::ROMS.Properties.Resources.up_arrow;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(471, 594);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(76, 29);
            this.btnSave.TabIndex = 47;
            this.btnSave.Text = "Upload";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // pnlImageContainer
            // 
            this.pnlImageContainer.AutoScroll = true;
            this.pnlImageContainer.Controls.Add(this.pictureBox1);
            this.pnlImageContainer.Location = new System.Drawing.Point(28, 53);
            this.pnlImageContainer.Name = "pnlImageContainer";
            this.pnlImageContainer.Size = new System.Drawing.Size(599, 535);
            this.pnlImageContainer.TabIndex = 18;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(4, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(590, 529);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // tsMenu
            // 
            this.tsMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbBrowse});
            this.tsMenu.Location = new System.Drawing.Point(3, 23);
            this.tsMenu.Name = "tsMenu";
            this.tsMenu.Size = new System.Drawing.Size(636, 27);
            this.tsMenu.TabIndex = 14;
            this.tsMenu.Text = "toolStrip1";
            // 
            // tsbBrowse
            // 
            this.tsbBrowse.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.tsbBrowse.Image = global::ROMS.Properties.Resources.folder;
            this.tsbBrowse.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbBrowse.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbBrowse.Margin = new System.Windows.Forms.Padding(0, 1, 15, 2);
            this.tsbBrowse.Name = "tsbBrowse";
            this.tsbBrowse.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tsbBrowse.Size = new System.Drawing.Size(69, 24);
            this.tsbBrowse.Text = "Browse";
            // 
            // grbSubgroups
            // 
            this.grbSubgroups.Controls.Add(this.tvSubgroupProducts);
            this.grbSubgroups.Controls.Add(this.flpSubGroups);
            this.grbSubgroups.Controls.Add(this.grdSubgroups);
            this.grbSubgroups.Location = new System.Drawing.Point(12, 3);
            this.grbSubgroups.Name = "grbSubgroups";
            this.grbSubgroups.Size = new System.Drawing.Size(650, 629);
            this.grbSubgroups.TabIndex = 0;
            this.grbSubgroups.TabStop = false;
            this.grbSubgroups.Text = "Subgroups";
            // 
            // tvSubgroupProducts
            // 
            this.tvSubgroupProducts.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvSubgroupProducts.Location = new System.Drawing.Point(9, 353);
            this.tvSubgroupProducts.Name = "tvSubgroupProducts";
            this.tvSubgroupProducts.Size = new System.Drawing.Size(623, 270);
            this.tvSubgroupProducts.TabIndex = 1111145;
            // 
            // flpSubGroups
            // 
            this.flpSubGroups.AutoScroll = true;
            this.flpSubGroups.AutoSize = true;
            this.flpSubGroups.Dock = System.Windows.Forms.DockStyle.Left;
            this.flpSubGroups.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpSubGroups.Location = new System.Drawing.Point(3, 23);
            this.flpSubGroups.Name = "flpSubGroups";
            this.flpSubGroups.Size = new System.Drawing.Size(0, 603);
            this.flpSubGroups.TabIndex = 1111144;
            this.flpSubGroups.WrapContents = false;
            // 
            // grdSubgroups
            // 
            this.grdSubgroups.AllowUserToAddRows = false;
            this.grdSubgroups.AllowUserToDeleteRows = false;
            this.grdSubgroups.AllowUserToResizeColumns = false;
            this.grdSubgroups.AllowUserToResizeRows = false;
            this.grdSubgroups.BackgroundColor = System.Drawing.Color.White;
            this.grdSubgroups.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdSubgroups.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdSubgroups.ColumnHeadersHeight = 30;
            this.grdSubgroups.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdSubgroups.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmCheck,
            this.clmSubgroup,
            this.clmProduct,
            this.clmImage,
            this.clmSGID,
            this.clmView,
            this.clmClear});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdSubgroups.DefaultCellStyle = dataGridViewCellStyle2;
            this.grdSubgroups.EnableHeadersVisualStyles = false;
            this.grdSubgroups.GridColor = System.Drawing.Color.White;
            this.grdSubgroups.Location = new System.Drawing.Point(9, 26);
            this.grdSubgroups.Name = "grdSubgroups";
            this.grdSubgroups.ReadOnly = true;
            this.grdSubgroups.RowHeadersVisible = false;
            this.grdSubgroups.RowHeadersWidth = 51;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.grdSubgroups.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.grdSubgroups.RowTemplate.Height = 25;
            this.grdSubgroups.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdSubgroups.Size = new System.Drawing.Size(623, 308);
            this.grdSubgroups.TabIndex = 1111143;
            this.grdSubgroups.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.grdSubgroups_CellFormatting);
            // 
            // clmCheck
            // 
            this.clmCheck.HeaderText = "";
            this.clmCheck.Name = "clmCheck";
            this.clmCheck.ReadOnly = true;
            this.clmCheck.Width = 40;
            // 
            // clmSubgroup
            // 
            this.clmSubgroup.HeaderText = "Subgroup";
            this.clmSubgroup.Name = "clmSubgroup";
            this.clmSubgroup.ReadOnly = true;
            this.clmSubgroup.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmSubgroup.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmSubgroup.Width = 230;
            // 
            // clmProduct
            // 
            this.clmProduct.HeaderText = "Product";
            this.clmProduct.Name = "clmProduct";
            this.clmProduct.ReadOnly = true;
            this.clmProduct.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmProduct.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmProduct.Width = 140;
            // 
            // clmImage
            // 
            this.clmImage.HeaderText = "Image Name";
            this.clmImage.Name = "clmImage";
            this.clmImage.ReadOnly = true;
            this.clmImage.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmImage.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmImage.Width = 120;
            // 
            // clmSGID
            // 
            this.clmSGID.HeaderText = "SGID";
            this.clmSGID.Name = "clmSGID";
            this.clmSGID.ReadOnly = true;
            this.clmSGID.Visible = false;
            this.clmSGID.Width = 10;
            // 
            // clmView
            // 
            this.clmView.HeaderText = "View";
            this.clmView.Image = global::ROMS.Properties.Resources.view_eye;
            this.clmView.Name = "clmView";
            this.clmView.ReadOnly = true;
            this.clmView.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmView.Width = 40;
            // 
            // clmClear
            // 
            this.clmClear.HeaderText = "Clear";
            this.clmClear.Image = global::ROMS.Properties.Resources.remove;
            this.clmClear.Name = "clmClear";
            this.clmClear.ReadOnly = true;
            this.clmClear.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmClear.Width = 40;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "View";
            this.dataGridViewImageColumn1.Image = global::ROMS.Properties.Resources.view_eye;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn1.Width = 40;
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.HeaderText = "Clear";
            this.dataGridViewImageColumn2.Image = global::ROMS.Properties.Resources.remove;
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn2.Width = 40;
            // 
            // CP_Bulk_Image_Update
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(1354, 675);
            this.Controls.Add(this.pnlImage);
            this.Controls.Add(this.tsImageList);
            this.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "CP_Bulk_Image_Update";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "City";
            this.Load += new System.EventHandler(this.CP_Bulk_Image_Updatelist_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CP_Bulk_Image_Updatelist_KeyDown);
            this.tsImageList.ResumeLayout(false);
            this.tsImageList.PerformLayout();
            this.pnlImage.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pnlImageContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
            this.grbSubgroups.ResumeLayout(false);
            this.grbSubgroups.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSubgroups)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsImageList;
        private System.Windows.Forms.ToolStripLabel tspHeader;
        private System.Windows.Forms.Panel pnlImage;
        private System.Windows.Forms.GroupBox grbSubgroups;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStrip tsMenu;
        public System.Windows.Forms.ToolStripButton tsbBrowse;
        private System.Windows.Forms.Panel pnlImageContainer;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        public System.Windows.Forms.DataGridView grdSubgroups;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clmCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSubgroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSGID;
        private System.Windows.Forms.DataGridViewImageColumn clmView;
        private System.Windows.Forms.DataGridViewImageColumn clmClear;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private System.Windows.Forms.FlowLayoutPanel flpSubGroups;
        private System.Windows.Forms.TreeView tvSubgroupProducts;
    }
}