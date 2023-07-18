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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.grdRackSettingList = new System.Windows.Forms.DataGridView();
            this.clmsno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmsupname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPICode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmproname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpFilterby = new System.Windows.Forms.GroupBox();
            this.cmbGroupType = new System.Windows.Forms.ComboBox();
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
            this.tsSupplierMappinglist.Size = new System.Drawing.Size(94, 24);
            this.tsSupplierMappinglist.Text = "Rack Setting";
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
            // pnlRackSettingList
            // 
            this.pnlRackSettingList.BackColor = System.Drawing.Color.White;
            this.pnlRackSettingList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRackSettingList.Controls.Add(this.grdRackSettingList);
            this.pnlRackSettingList.Controls.Add(this.grpFilterby);
            this.pnlRackSettingList.Location = new System.Drawing.Point(4, 40);
            this.pnlRackSettingList.Name = "pnlRackSettingList";
            this.pnlRackSettingList.Size = new System.Drawing.Size(1349, 633);
            this.pnlRackSettingList.TabIndex = 958788;
            // 
            // grdRackSettingList
            // 
            this.grdRackSettingList.AllowUserToAddRows = false;
            this.grdRackSettingList.AllowUserToDeleteRows = false;
            this.grdRackSettingList.AllowUserToResizeColumns = false;
            this.grdRackSettingList.AllowUserToResizeRows = false;
            this.grdRackSettingList.BackgroundColor = System.Drawing.Color.White;
            this.grdRackSettingList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(242)))), ((int)(((byte)(213)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdRackSettingList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.grdRackSettingList.ColumnHeadersHeight = 30;
            this.grdRackSettingList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdRackSettingList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmsno,
            this.clmsupname,
            this.clmPICode,
            this.clmproname,
            this.clmUnit});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdRackSettingList.DefaultCellStyle = dataGridViewCellStyle5;
            this.grdRackSettingList.EnableHeadersVisualStyles = false;
            this.grdRackSettingList.GridColor = System.Drawing.Color.White;
            this.grdRackSettingList.Location = new System.Drawing.Point(16, 67);
            this.grdRackSettingList.Name = "grdRackSettingList";
            this.grdRackSettingList.ReadOnly = true;
            this.grdRackSettingList.RowHeadersVisible = false;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            this.grdRackSettingList.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.grdRackSettingList.RowTemplate.Height = 25;
            this.grdRackSettingList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdRackSettingList.Size = new System.Drawing.Size(1317, 549);
            this.grdRackSettingList.TabIndex = 958789;
            // 
            // clmsno
            // 
            this.clmsno.HeaderText = "S.No.";
            this.clmsno.Name = "clmsno";
            this.clmsno.ReadOnly = true;
            this.clmsno.Width = 50;
            // 
            // clmsupname
            // 
            this.clmsupname.HeaderText = "Rack Name";
            this.clmsupname.Name = "clmsupname";
            this.clmsupname.ReadOnly = true;
            this.clmsupname.Width = 200;
            // 
            // clmPICode
            // 
            this.clmPICode.HeaderText = "P.I Code";
            this.clmPICode.Name = "clmPICode";
            this.clmPICode.ReadOnly = true;
            // 
            // clmproname
            // 
            this.clmproname.HeaderText = "Product Name";
            this.clmproname.Name = "clmproname";
            this.clmproname.ReadOnly = true;
            this.clmproname.Width = 300;
            // 
            // clmUnit
            // 
            this.clmUnit.HeaderText = "Unit";
            this.clmUnit.Name = "clmUnit";
            this.clmUnit.ReadOnly = true;
            this.clmUnit.Width = 150;
            // 
            // grpFilterby
            // 
            this.grpFilterby.BackColor = System.Drawing.Color.White;
            this.grpFilterby.Controls.Add(this.cmbGroupType);
            this.grpFilterby.Controls.Add(this.btnView);
            this.grpFilterby.Controls.Add(this.lblDERack);
            this.grpFilterby.Location = new System.Drawing.Point(16, 4);
            this.grpFilterby.Name = "grpFilterby";
            this.grpFilterby.Size = new System.Drawing.Size(1317, 58);
            this.grpFilterby.TabIndex = 958790;
            this.grpFilterby.TabStop = false;
            this.grpFilterby.Text = "Filter By";
            // 
            // cmbGroupType
            // 
            this.cmbGroupType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGroupType.FormattingEnabled = true;
            this.cmbGroupType.Location = new System.Drawing.Point(48, 21);
            this.cmbGroupType.Name = "cmbGroupType";
            this.cmbGroupType.Size = new System.Drawing.Size(351, 27);
            this.cmbGroupType.TabIndex = 38;
            // 
            // btnView
            // 
            this.btnView.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnView.Image = global::ROMS.Properties.Resources.view;
            this.btnView.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnView.Location = new System.Drawing.Point(411, 20);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(74, 29);
            this.btnView.TabIndex = 37;
            this.btnView.Text = "View";
            this.btnView.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnView.UseVisualStyleBackColor = true;
            // 
            // lblDERack
            // 
            this.lblDERack.AutoSize = true;
            this.lblDERack.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDERack.Location = new System.Drawing.Point(7, 24);
            this.lblDERack.Name = "lblDERack";
            this.lblDERack.Size = new System.Drawing.Size(35, 20);
            this.lblDERack.TabIndex = 35;
            this.lblDERack.Text = "Rack";
            // 
            // CP_RackSettinglist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(1354, 669);
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
            this.Load += new System.EventHandler(this.CP_BrandList_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CP_BrandList_KeyDown);
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
        private System.Windows.Forms.ComboBox cmbGroupType;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmsno;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmsupname;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPICode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmproname;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmUnit;
    }
}