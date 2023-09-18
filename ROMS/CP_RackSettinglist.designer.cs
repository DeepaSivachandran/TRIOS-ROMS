namespace ROMS
{
    partial class CP_RackSettinglist
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tshSupplierMappingList = new System.Windows.Forms.ToolStrip();
            this.tsSupplierMappinglist = new System.Windows.Forms.ToolStripLabel();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.tssEdit = new System.Windows.Forms.ToolStripSeparator();
            this.tsbEdit = new System.Windows.Forms.ToolStripButton();
            this.tssNew = new System.Windows.Forms.ToolStripSeparator();
            this.tsbNew = new System.Windows.Forms.ToolStripButton();
            this.lblNoRecordsFound = new System.Windows.Forms.Label();
            this.picLoader = new System.Windows.Forms.PictureBox();
            this.pnlRackSettingList = new System.Windows.Forms.Panel();
            this.lvRack = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grdRackSettingList = new System.Windows.Forms.DataGridView();
            this.grpFilterby = new System.Windows.Forms.GroupBox();
            this.lblRack = new System.Windows.Forms.Label();
            this.txtRack = new System.Windows.Forms.TextBox();
            this.btnView = new System.Windows.Forms.Button();
            this.lblDERack = new System.Windows.Forms.Label();
            this.tshSupplierMappingList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).BeginInit();
            this.pnlRackSettingList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdRackSettingList)).BeginInit();
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
            this.tsSupplierMappinglist.Size = new System.Drawing.Size(100, 24);
            this.tsSupplierMappinglist.Text = "Rack Settings";
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
            this.picLoader.Image = global::ROMS.Properties.Resources.Iphone_spinner_2;
            this.picLoader.InitialImage = null;
            this.picLoader.Location = new System.Drawing.Point(0, 103);
            this.picLoader.Name = "picLoader";
            this.picLoader.Size = new System.Drawing.Size(1350, 569);
            this.picLoader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picLoader.TabIndex = 958787;
            this.picLoader.TabStop = false;
            this.picLoader.Visible = false;
            // 
            // pnlRackSettingList
            // 
            this.pnlRackSettingList.BackColor = System.Drawing.Color.White;
            this.pnlRackSettingList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRackSettingList.Controls.Add(this.lvRack);
            this.pnlRackSettingList.Controls.Add(this.grdRackSettingList);
            this.pnlRackSettingList.Controls.Add(this.grpFilterby);
            this.pnlRackSettingList.Location = new System.Drawing.Point(0, 31);
            this.pnlRackSettingList.Name = "pnlRackSettingList";
            this.pnlRackSettingList.Size = new System.Drawing.Size(1354, 641);
            this.pnlRackSettingList.TabIndex = 958788;
            // 
            // lvRack
            // 
            this.lvRack.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvRack.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvRack.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvRack.HideSelection = false;
            this.lvRack.Location = new System.Drawing.Point(70, 52);
            this.lvRack.Name = "lvRack";
            this.lvRack.Size = new System.Drawing.Size(351, 90);
            this.lvRack.TabIndex = 40;
            this.lvRack.UseCompatibleStateImageBehavior = false;
            this.lvRack.View = System.Windows.Forms.View.Details;
            this.lvRack.Visible = false;
            this.lvRack.DoubleClick += new System.EventHandler(this.LvRack_DoubleClick);
            this.lvRack.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LvRack_KeyDown);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 180;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Width = 120;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Width = 0;
            // 
            // grdRackSettingList
            // 
            this.grdRackSettingList.AllowUserToAddRows = false;
            this.grdRackSettingList.AllowUserToDeleteRows = false;
            this.grdRackSettingList.AllowUserToResizeColumns = false;
            this.grdRackSettingList.AllowUserToResizeRows = false;
            this.grdRackSettingList.BackgroundColor = System.Drawing.Color.White;
            this.grdRackSettingList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(242)))), ((int)(((byte)(213)))));
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdRackSettingList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.grdRackSettingList.ColumnHeadersHeight = 30;
            this.grdRackSettingList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdRackSettingList.DefaultCellStyle = dataGridViewCellStyle11;
            this.grdRackSettingList.EnableHeadersVisualStyles = false;
            this.grdRackSettingList.GridColor = System.Drawing.Color.White;
            this.grdRackSettingList.Location = new System.Drawing.Point(3, 71);
            this.grdRackSettingList.Name = "grdRackSettingList";
            this.grdRackSettingList.ReadOnly = true;
            this.grdRackSettingList.RowHeadersVisible = false;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.White;
            this.grdRackSettingList.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.grdRackSettingList.RowTemplate.Height = 25;
            this.grdRackSettingList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdRackSettingList.Size = new System.Drawing.Size(1348, 570);
            this.grdRackSettingList.TabIndex = 958789;
            this.grdRackSettingList.DoubleClick += new System.EventHandler(this.GrdRackSettingList_DoubleClick);
            this.grdRackSettingList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GrdRackSettingList_KeyDown);
            // 
            // grpFilterby
            // 
            this.grpFilterby.BackColor = System.Drawing.Color.White;
            this.grpFilterby.Controls.Add(this.lblRack);
            this.grpFilterby.Controls.Add(this.txtRack);
            this.grpFilterby.Controls.Add(this.btnView);
            this.grpFilterby.Controls.Add(this.lblDERack);
            this.grpFilterby.Location = new System.Drawing.Point(3, 2);
            this.grpFilterby.Name = "grpFilterby";
            this.grpFilterby.Size = new System.Drawing.Size(1346, 67);
            this.grpFilterby.TabIndex = 0;
            this.grpFilterby.TabStop = false;
            this.grpFilterby.Text = "Filter By";
            // 
            // lblRack
            // 
            this.lblRack.AutoSize = true;
            this.lblRack.Location = new System.Drawing.Point(555, 26);
            this.lblRack.Name = "lblRack";
            this.lblRack.Size = new System.Drawing.Size(0, 20);
            this.lblRack.TabIndex = 40;
            this.lblRack.Visible = false;
            // 
            // txtRack
            // 
            this.txtRack.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtRack.Location = new System.Drawing.Point(67, 23);
            this.txtRack.MaxLength = 100;
            this.txtRack.Name = "txtRack";
            this.txtRack.Size = new System.Drawing.Size(214, 27);
            this.txtRack.TabIndex = 0;
            this.txtRack.TextChanged += new System.EventHandler(this.TxtRack_TextChanged);
            this.txtRack.Enter += new System.EventHandler(this.TxtRack_Enter);
            this.txtRack.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtRack_KeyDown);
            this.txtRack.Leave += new System.EventHandler(this.TxtRack_Leave);
            // 
            // btnView
            // 
            this.btnView.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnView.Image = global::ROMS.Properties.Resources.view;
            this.btnView.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnView.Location = new System.Drawing.Point(287, 22);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(74, 29);
            this.btnView.TabIndex = 1;
            this.btnView.Text = "View";
            this.btnView.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.BtnView_Click);
            this.btnView.Enter += new System.EventHandler(this.BtnView_Enter);
            this.btnView.Leave += new System.EventHandler(this.BtnView_Leave);
            // 
            // lblDERack
            // 
            this.lblDERack.AutoSize = true;
            this.lblDERack.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDERack.Location = new System.Drawing.Point(26, 26);
            this.lblDERack.Name = "lblDERack";
            this.lblDERack.Size = new System.Drawing.Size(35, 20);
            this.lblDERack.TabIndex = 35;
            this.lblDERack.Text = "Rack";
            // 
            // CP_RackSettinglist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(1354, 675);
            this.Controls.Add(this.pnlRackSettingList);
            this.Controls.Add(this.lblNoRecordsFound);
            this.Controls.Add(this.tshSupplierMappingList);
            this.Controls.Add(this.picLoader);
            this.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "CP_RackSettinglist";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rack Setting List";
            this.Load += new System.EventHandler(this.CP_RackSettinglist_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CP_RackSettinglist_KeyDown);
            this.tshSupplierMappingList.ResumeLayout(false);
            this.tshSupplierMappingList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).EndInit();
            this.pnlRackSettingList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdRackSettingList)).EndInit();
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
        private System.Windows.Forms.Panel pnlRackSettingList;
        public System.Windows.Forms.DataGridView grdRackSettingList;
        private System.Windows.Forms.GroupBox grpFilterby;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Label lblDERack;
        private System.Windows.Forms.TextBox txtRack;
        public System.Windows.Forms.ListView lvRack;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Label lblRack;
    }
}