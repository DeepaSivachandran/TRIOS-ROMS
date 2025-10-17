namespace ROMS
{
    partial class CP_Companylist
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
            this.tsCompanyList = new System.Windows.Forms.ToolStrip();
            this.tspHeader = new System.Windows.Forms.ToolStripLabel();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.tssEdit = new System.Windows.Forms.ToolStripSeparator();
            this.tsbEdit = new System.Windows.Forms.ToolStripButton();
            this.tssNew = new System.Windows.Forms.ToolStripSeparator();
            this.tsbNew = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbTotalCount = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.pnlCompany = new System.Windows.Forms.Panel();
            this.DGV_SearchGrid = new System.Windows.Forms.DataGridView();
            this.clmdsno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmdcompanyname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmdshtname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDCityPincode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PhoneNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WhatsAppNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmdgstin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDPan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmdstatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblNoRecordsFound = new System.Windows.Forms.Label();
            this.grdCompanyList = new System.Windows.Forms.DataGridView();
            this.picLoader = new System.Windows.Forms.PictureBox();
            this.tsCompanyList.SuspendLayout();
            this.pnlCompany.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_SearchGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCompanyList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).BeginInit();
            this.SuspendLayout();
            // 
            // tsCompanyList
            // 
            this.tsCompanyList.BackColor = System.Drawing.Color.White;
            this.tsCompanyList.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsCompanyList.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsCompanyList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspHeader,
            this.tsbDelete,
            this.tssEdit,
            this.tsbEdit,
            this.tssNew,
            this.tsbNew,
            this.toolStripSeparator1,
            this.tsbTotalCount,
            this.toolStripButton1});
            this.tsCompanyList.Location = new System.Drawing.Point(0, 0);
            this.tsCompanyList.Name = "tsCompanyList";
            this.tsCompanyList.Size = new System.Drawing.Size(1354, 27);
            this.tsCompanyList.TabIndex = 35;
            this.tsCompanyList.Text = "Brand";
            // 
            // tspHeader
            // 
            this.tspHeader.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tspHeader.Image = global::ROMS.Properties.Resources.bread_crumb;
            this.tspHeader.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tspHeader.Margin = new System.Windows.Forms.Padding(15, 1, 0, 2);
            this.tspHeader.Name = "tspHeader";
            this.tspHeader.Size = new System.Drawing.Size(75, 24);
            this.tspHeader.Text = "Company";
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
            this.tsbDelete.Visible = false;
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
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator1.Margin = new System.Windows.Forms.Padding(0, 0, 15, 0);
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // tsbTotalCount
            // 
            this.tsbTotalCount.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbTotalCount.ForeColor = System.Drawing.Color.Crimson;
            this.tsbTotalCount.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbTotalCount.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbTotalCount.Margin = new System.Windows.Forms.Padding(0, 1, 10, 2);
            this.tsbTotalCount.Name = "tsbTotalCount";
            this.tsbTotalCount.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tsbTotalCount.Size = new System.Drawing.Size(41, 24);
            this.tsbTotalCount.Text = "0000";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Margin = new System.Windows.Forms.Padding(0, 1, 10, 2);
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStripButton1.Size = new System.Drawing.Size(111, 24);
            this.toolStripButton1.Text = "No. of Companies :";
            // 
            // pnlCompany
            // 
            this.pnlCompany.BackColor = System.Drawing.Color.White;
            this.pnlCompany.Controls.Add(this.DGV_SearchGrid);
            this.pnlCompany.Controls.Add(this.lblNoRecordsFound);
            this.pnlCompany.Controls.Add(this.grdCompanyList);
            this.pnlCompany.Controls.Add(this.picLoader);
            this.pnlCompany.Location = new System.Drawing.Point(0, 31);
            this.pnlCompany.Name = "pnlCompany";
            this.pnlCompany.Size = new System.Drawing.Size(1354, 641);
            this.pnlCompany.TabIndex = 958797;
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
            this.clmdcompanyname,
            this.clmdshtname,
            this.clmDCityPincode,
            this.PhoneNo,
            this.WhatsAppNo,
            this.clmdgstin,
            this.clmDPan,
            this.clmdstatus});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV_SearchGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.DGV_SearchGrid.EnableHeadersVisualStyles = false;
            this.DGV_SearchGrid.GridColor = System.Drawing.Color.White;
            this.DGV_SearchGrid.Location = new System.Drawing.Point(3, 2);
            this.DGV_SearchGrid.Name = "DGV_SearchGrid";
            this.DGV_SearchGrid.RowHeadersVisible = false;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.DGV_SearchGrid.RowsDefaultCellStyle = dataGridViewCellStyle3;
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
            // 
            // clmdsno
            // 
            this.clmdsno.HeaderText = "S.No.";
            this.clmdsno.Name = "clmdsno";
            this.clmdsno.Width = 50;
            // 
            // clmdcompanyname
            // 
            this.clmdcompanyname.HeaderText = "Company Name";
            this.clmdcompanyname.Name = "clmdcompanyname";
            this.clmdcompanyname.Width = 200;
            // 
            // clmdshtname
            // 
            this.clmdshtname.HeaderText = "Short Name";
            this.clmdshtname.Name = "clmdshtname";
            // 
            // clmDCityPincode
            // 
            this.clmDCityPincode.HeaderText = "City-Pincode";
            this.clmDCityPincode.Name = "clmDCityPincode";
            this.clmDCityPincode.Width = 180;
            // 
            // PhoneNo
            // 
            this.PhoneNo.HeaderText = "Phone No.";
            this.PhoneNo.Name = "PhoneNo";
            this.PhoneNo.Width = 120;
            // 
            // WhatsAppNo
            // 
            this.WhatsAppNo.HeaderText = "WhatsApp No.";
            this.WhatsAppNo.Name = "WhatsAppNo";
            this.WhatsAppNo.Width = 120;
            // 
            // clmdgstin
            // 
            this.clmdgstin.HeaderText = "GSTIN";
            this.clmdgstin.Name = "clmdgstin";
            this.clmdgstin.Width = 180;
            // 
            // clmDPan
            // 
            this.clmDPan.HeaderText = "PAN";
            this.clmDPan.Name = "clmDPan";
            this.clmDPan.Width = 150;
            // 
            // clmdstatus
            // 
            this.clmdstatus.HeaderText = "Status";
            this.clmdstatus.Name = "clmdstatus";
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
            // grdCompanyList
            // 
            this.grdCompanyList.AllowUserToAddRows = false;
            this.grdCompanyList.AllowUserToDeleteRows = false;
            this.grdCompanyList.AllowUserToResizeColumns = false;
            this.grdCompanyList.AllowUserToResizeRows = false;
            this.grdCompanyList.BackgroundColor = System.Drawing.Color.White;
            this.grdCompanyList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(242)))), ((int)(((byte)(213)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdCompanyList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.grdCompanyList.ColumnHeadersHeight = 30;
            this.grdCompanyList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdCompanyList.ColumnHeadersVisible = false;
            this.grdCompanyList.EnableHeadersVisualStyles = false;
            this.grdCompanyList.GridColor = System.Drawing.Color.White;
            this.grdCompanyList.Location = new System.Drawing.Point(3, 58);
            this.grdCompanyList.Name = "grdCompanyList";
            this.grdCompanyList.ReadOnly = true;
            this.grdCompanyList.RowHeadersVisible = false;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            this.grdCompanyList.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.grdCompanyList.RowTemplate.Height = 25;
            this.grdCompanyList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdCompanyList.Size = new System.Drawing.Size(1348, 581);
            this.grdCompanyList.TabIndex = 958797;
            this.grdCompanyList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.GrdCompanyList_DataBindingComplete);
            this.grdCompanyList.Scroll += new System.Windows.Forms.ScrollEventHandler(this.GrdCompanyList_Scroll);
            this.grdCompanyList.DoubleClick += new System.EventHandler(this.GrdCompanyList_DoubleClick);
            this.grdCompanyList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GrdCompanyList_KeyDown);
            // 
            // picLoader
            // 
            this.picLoader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picLoader.ErrorImage = null;
            this.picLoader.Image = global::ROMS.Properties.Resources.Iphone_spinner_2;
            this.picLoader.InitialImage = null;
            this.picLoader.Location = new System.Drawing.Point(4, 3);
            this.picLoader.Name = "picLoader";
            this.picLoader.Size = new System.Drawing.Size(1346, 635);
            this.picLoader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picLoader.TabIndex = 958799;
            this.picLoader.TabStop = false;
            this.picLoader.Visible = false;
            // 
            // CP_Companylist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(1354, 675);
            this.Controls.Add(this.pnlCompany);
            this.Controls.Add(this.tsCompanyList);
            this.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "CP_Companylist";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Company";
            this.Load += new System.EventHandler(this.CP_Companylist_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CP_Companylist_KeyDown);
            this.tsCompanyList.ResumeLayout(false);
            this.tsCompanyList.PerformLayout();
            this.pnlCompany.ResumeLayout(false);
            this.pnlCompany.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_SearchGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCompanyList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsCompanyList;
        private System.Windows.Forms.ToolStripLabel tspHeader;
        public System.Windows.Forms.ToolStripButton tsbDelete;
        public System.Windows.Forms.ToolStripSeparator tssEdit;
        public System.Windows.Forms.ToolStripButton tsbEdit;
        public System.Windows.Forms.ToolStripSeparator tssNew;
        public System.Windows.Forms.ToolStripButton tsbNew;
        private System.Windows.Forms.Panel pnlCompany;
        public System.Windows.Forms.DataGridView DGV_SearchGrid;
        private System.Windows.Forms.Label lblNoRecordsFound;
        public System.Windows.Forms.DataGridView grdCompanyList;
        private System.Windows.Forms.PictureBox picLoader;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmdsno;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmdcompanyname;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmdshtname;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDCityPincode;
        private System.Windows.Forms.DataGridViewTextBoxColumn PhoneNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn WhatsAppNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmdgstin;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDPan;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmdstatus;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        public System.Windows.Forms.ToolStripButton tsbTotalCount;
        public System.Windows.Forms.ToolStripButton toolStripButton1;
    }
}