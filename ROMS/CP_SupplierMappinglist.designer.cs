namespace ROMS
{
    partial class CP_SupplierMappinglist
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
            this.tshSupplierMappingList = new System.Windows.Forms.ToolStrip();
            this.tsSupplierMappinglist = new System.Windows.Forms.ToolStripLabel();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.tssEdit = new System.Windows.Forms.ToolStripSeparator();
            this.tsbEdit = new System.Windows.Forms.ToolStripButton();
            this.tssNew = new System.Windows.Forms.ToolStripSeparator();
            this.tsbNew = new System.Windows.Forms.ToolStripButton();
            this.lblNoRecordsFound = new System.Windows.Forms.Label();
            this.picLoader = new System.Windows.Forms.PictureBox();
            this.pnlSupplierMappingList = new System.Windows.Forms.Panel();
            this.listView1 = new System.Windows.Forms.ListView();
            this.grdSupplierMappingList = new System.Windows.Forms.DataGridView();
            this.grpFilterby = new System.Windows.Forms.GroupBox();
            this.txtSupplier = new System.Windows.Forms.TextBox();
            this.btnView = new System.Windows.Forms.Button();
            this.lblDESupplier = new System.Windows.Forms.Label();
            this.clmsno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmsupname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmproduct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tshSupplierMappingList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).BeginInit();
            this.pnlSupplierMappingList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSupplierMappingList)).BeginInit();
            this.grpFilterby.SuspendLayout();
            this.SuspendLayout();
            // 
            // tshSupplierMappingList
            // 
            this.tshSupplierMappingList.BackColor = System.Drawing.Color.White;
            this.tshSupplierMappingList.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tshSupplierMappingList.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tshSupplierMappingList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsSupplierMappinglist,
            this.tsbDelete,
            this.tssEdit,
            this.tsbEdit,
            this.tssNew,
            this.tsbNew});
            this.tshSupplierMappingList.Location = new System.Drawing.Point(0, 0);
            this.tshSupplierMappingList.Name = "tshSupplierMappingList";
            this.tshSupplierMappingList.Size = new System.Drawing.Size(1354, 27);
            this.tshSupplierMappingList.TabIndex = 35;
            this.tshSupplierMappingList.Text = "Supplier Mapping List";
            // 
            // tsSupplierMappinglist
            // 
            this.tsSupplierMappinglist.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsSupplierMappinglist.Image = global::ROMS.Properties.Resources.bread_crumb;
            this.tsSupplierMappinglist.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsSupplierMappinglist.Margin = new System.Windows.Forms.Padding(15, 1, 0, 2);
            this.tsSupplierMappinglist.Name = "tsSupplierMappinglist";
            this.tsSupplierMappinglist.Size = new System.Drawing.Size(174, 24);
            this.tsSupplierMappinglist.Text = "Supplier - Product Mapping";
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
            // picLoader
            // 
            this.picLoader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picLoader.ErrorImage = null;
            this.picLoader.Image = global::ROMS.Properties.Resources.loader;
            this.picLoader.InitialImage = null;
            this.picLoader.Location = new System.Drawing.Point(17, 41);
            this.picLoader.Name = "picLoader";
            this.picLoader.Size = new System.Drawing.Size(1322, 604);
            this.picLoader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picLoader.TabIndex = 958787;
            this.picLoader.TabStop = false;
            this.picLoader.Visible = false;
            // 
            // pnlSupplierMappingList
            // 
            this.pnlSupplierMappingList.BackColor = System.Drawing.Color.White;
            this.pnlSupplierMappingList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSupplierMappingList.Controls.Add(this.listView1);
            this.pnlSupplierMappingList.Controls.Add(this.grdSupplierMappingList);
            this.pnlSupplierMappingList.Controls.Add(this.grpFilterby);
            this.pnlSupplierMappingList.Location = new System.Drawing.Point(0, 31);
            this.pnlSupplierMappingList.Name = "pnlSupplierMappingList";
            this.pnlSupplierMappingList.Size = new System.Drawing.Size(1354, 641);
            this.pnlSupplierMappingList.TabIndex = 958788;
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(76, 58);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(423, 113);
            this.listView1.TabIndex = 36;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.Visible = false;
            // 
            // grdSupplierMappingList
            // 
            this.grdSupplierMappingList.AllowUserToAddRows = false;
            this.grdSupplierMappingList.AllowUserToDeleteRows = false;
            this.grdSupplierMappingList.AllowUserToResizeColumns = false;
            this.grdSupplierMappingList.AllowUserToResizeRows = false;
            this.grdSupplierMappingList.BackgroundColor = System.Drawing.Color.White;
            this.grdSupplierMappingList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(242)))), ((int)(((byte)(213)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdSupplierMappingList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdSupplierMappingList.ColumnHeadersHeight = 30;
            this.grdSupplierMappingList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdSupplierMappingList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmsno,
            this.clmsupname,
            this.Column1,
            this.Column2,
            this.clmproduct});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdSupplierMappingList.DefaultCellStyle = dataGridViewCellStyle2;
            this.grdSupplierMappingList.EnableHeadersVisualStyles = false;
            this.grdSupplierMappingList.GridColor = System.Drawing.Color.White;
            this.grdSupplierMappingList.Location = new System.Drawing.Point(3, 71);
            this.grdSupplierMappingList.Name = "grdSupplierMappingList";
            this.grdSupplierMappingList.ReadOnly = true;
            this.grdSupplierMappingList.RowHeadersVisible = false;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.grdSupplierMappingList.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.grdSupplierMappingList.RowTemplate.Height = 25;
            this.grdSupplierMappingList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdSupplierMappingList.Size = new System.Drawing.Size(1348, 570);
            this.grdSupplierMappingList.TabIndex = 958789;
            // 
            // grpFilterby
            // 
            this.grpFilterby.BackColor = System.Drawing.Color.White;
            this.grpFilterby.Controls.Add(this.txtSupplier);
            this.grpFilterby.Controls.Add(this.btnView);
            this.grpFilterby.Controls.Add(this.lblDESupplier);
            this.grpFilterby.Location = new System.Drawing.Point(3, 2);
            this.grpFilterby.Name = "grpFilterby";
            this.grpFilterby.Size = new System.Drawing.Size(1324, 67);
            this.grpFilterby.TabIndex = 958790;
            this.grpFilterby.TabStop = false;
            this.grpFilterby.Text = "Filter By";
            // 
            // txtSupplier
            // 
            this.txtSupplier.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSupplier.Location = new System.Drawing.Point(64, 24);
            this.txtSupplier.MaxLength = 50;
            this.txtSupplier.Name = "txtSupplier";
            this.txtSupplier.Size = new System.Drawing.Size(336, 27);
            this.txtSupplier.TabIndex = 38;
            // 
            // btnView
            // 
            this.btnView.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnView.Image = global::ROMS.Properties.Resources.view;
            this.btnView.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnView.Location = new System.Drawing.Point(413, 23);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(74, 29);
            this.btnView.TabIndex = 37;
            this.btnView.Text = "View";
            this.btnView.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnView.UseVisualStyleBackColor = true;
            // 
            // lblDESupplier
            // 
            this.lblDESupplier.AutoSize = true;
            this.lblDESupplier.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDESupplier.Location = new System.Drawing.Point(6, 27);
            this.lblDESupplier.Name = "lblDESupplier";
            this.lblDESupplier.Size = new System.Drawing.Size(54, 20);
            this.lblDESupplier.TabIndex = 35;
            this.lblDESupplier.Text = "Supplier";
            // 
            // clmsno
            // 
            this.clmsno.HeaderText = "S.No.";
            this.clmsno.Name = "clmsno";
            this.clmsno.ReadOnly = true;
            // 
            // clmsupname
            // 
            this.clmsupname.HeaderText = "Supplier Name";
            this.clmsupname.Name = "clmsupname";
            this.clmsupname.ReadOnly = true;
            this.clmsupname.Width = 250;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Order Type";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Day";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // clmproduct
            // 
            this.clmproduct.HeaderText = "No.of Products";
            this.clmproduct.Name = "clmproduct";
            this.clmproduct.ReadOnly = true;
            this.clmproduct.Width = 150;
            // 
            // CP_SupplierMappinglist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(1354, 675);
            this.Controls.Add(this.pnlSupplierMappingList);
            this.Controls.Add(this.lblNoRecordsFound);
            this.Controls.Add(this.tshSupplierMappingList);
            this.Controls.Add(this.picLoader);
            this.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "CP_SupplierMappinglist";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Supplier Mapping List";
            this.Load += new System.EventHandler(this.CP_BrandList_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CP_BrandList_KeyDown);
            this.tshSupplierMappingList.ResumeLayout(false);
            this.tshSupplierMappingList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).EndInit();
            this.pnlSupplierMappingList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdSupplierMappingList)).EndInit();
            this.grpFilterby.ResumeLayout(false);
            this.grpFilterby.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tshSupplierMappingList;
        private System.Windows.Forms.Label lblNoRecordsFound;
        private System.Windows.Forms.PictureBox picLoader;
        public System.Windows.Forms.ToolStripSeparator tssEdit;
        private System.Windows.Forms.ToolStripLabel tsSupplierMappinglist;
        public System.Windows.Forms.ToolStripButton tsbDelete;
        public System.Windows.Forms.ToolStripButton tsbEdit;
        public System.Windows.Forms.ToolStripSeparator tssNew;
        public System.Windows.Forms.ToolStripButton tsbNew;
        private System.Windows.Forms.Panel pnlSupplierMappingList;
        public System.Windows.Forms.DataGridView grdSupplierMappingList;
        private System.Windows.Forms.GroupBox grpFilterby;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.TextBox txtSupplier;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Label lblDESupplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmsno;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmsupname;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmproduct;
    }
}