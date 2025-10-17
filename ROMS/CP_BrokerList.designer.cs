namespace ROMS
{
    partial class CP_BrokerList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tsBroker = new System.Windows.Forms.ToolStrip();
            this.tspHeader = new System.Windows.Forms.ToolStripLabel();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.tssEdit = new System.Windows.Forms.ToolStripSeparator();
            this.tsbEdit = new System.Windows.Forms.ToolStripButton();
            this.tssNew = new System.Windows.Forms.ToolStripSeparator();
            this.tsbNew = new System.Windows.Forms.ToolStripButton();
            this.pnlunitlist = new System.Windows.Forms.Panel();
            this.grbFilterByUser = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTotalCount = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.DGV_SearchGrid = new System.Windows.Forms.DataGridView();
            this.grdBrokerList = new System.Windows.Forms.DataGridView();
            this.picLoader = new System.Windows.Forms.PictureBox();
            this.lblNoRecordsFound = new System.Windows.Forms.Label();
            this.tsBroker.SuspendLayout();
            this.pnlunitlist.SuspendLayout();
            this.grbFilterByUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_SearchGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBrokerList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).BeginInit();
            this.SuspendLayout();
            // 
            // tsBroker
            // 
            this.tsBroker.BackColor = System.Drawing.Color.White;
            this.tsBroker.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsBroker.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsBroker.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsBroker.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspHeader,
            this.tsbDelete,
            this.tssEdit,
            this.tsbEdit,
            this.tssNew,
            this.tsbNew});
            this.tsBroker.Location = new System.Drawing.Point(0, 0);
            this.tsBroker.Name = "tsBroker";
            this.tsBroker.Size = new System.Drawing.Size(1354, 27);
            this.tsBroker.TabIndex = 35;
            this.tsBroker.Text = "Broker";
            // 
            // tspHeader
            // 
            this.tspHeader.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tspHeader.Image = global::ROMS.Properties.Resources.bread_crumb;
            this.tspHeader.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tspHeader.Margin = new System.Windows.Forms.Padding(15, 1, 0, 2);
            this.tspHeader.Name = "tspHeader";
            this.tspHeader.Size = new System.Drawing.Size(61, 24);
            this.tspHeader.Text = "Broker";
            // 
            // tsbDelete
            // 
            this.tsbDelete.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbDelete.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.tsbEdit.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.tsbNew.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            // pnlunitlist
            // 
            this.pnlunitlist.BackColor = System.Drawing.Color.White;
            this.pnlunitlist.Controls.Add(this.grbFilterByUser);
            this.pnlunitlist.Controls.Add(this.DGV_SearchGrid);
            this.pnlunitlist.Controls.Add(this.grdBrokerList);
            this.pnlunitlist.Controls.Add(this.picLoader);
            this.pnlunitlist.Location = new System.Drawing.Point(0, 31);
            this.pnlunitlist.Name = "pnlunitlist";
            this.pnlunitlist.Size = new System.Drawing.Size(1354, 641);
            this.pnlunitlist.TabIndex = 36;
            // 
            // grbFilterByUser
            // 
            this.grbFilterByUser.Controls.Add(this.label2);
            this.grbFilterByUser.Controls.Add(this.lblTotalCount);
            this.grbFilterByUser.Controls.Add(this.cmbStatus);
            this.grbFilterByUser.Controls.Add(this.lblStatus);
            this.grbFilterByUser.Controls.Add(this.btnExport);
            this.grbFilterByUser.Controls.Add(this.btnView);
            this.grbFilterByUser.Location = new System.Drawing.Point(3, 2);
            this.grbFilterByUser.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbFilterByUser.Name = "grbFilterByUser";
            this.grbFilterByUser.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbFilterByUser.Size = new System.Drawing.Size(1348, 67);
            this.grbFilterByUser.TabIndex = 0;
            this.grbFilterByUser.TabStop = false;
            this.grbFilterByUser.Text = "Filter By";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(358, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 20);
            this.label2.TabIndex = 958824;
            this.label2.Text = "No.of Brokers :";
            // 
            // lblTotalCount
            // 
            this.lblTotalCount.AutoSize = true;
            this.lblTotalCount.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Bold);
            this.lblTotalCount.ForeColor = System.Drawing.Color.Crimson;
            this.lblTotalCount.Location = new System.Drawing.Point(444, 31);
            this.lblTotalCount.Name = "lblTotalCount";
            this.lblTotalCount.Size = new System.Drawing.Size(41, 20);
            this.lblTotalCount.TabIndex = 958825;
            this.lblTotalCount.Text = "0000";
            // 
            // cmbStatus
            // 
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(60, 27);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(126, 27);
            this.cmbStatus.TabIndex = 0;
            this.cmbStatus.Enter += new System.EventHandler(this.CmbStatus_Enter);
            this.cmbStatus.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbStatus_KeyDown);
            this.cmbStatus.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbStatus_KeyPress);
            this.cmbStatus.Leave += new System.EventHandler(this.CmbStatus_Leave);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(9, 30);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(45, 20);
            this.lblStatus.TabIndex = 958819;
            this.lblStatus.Text = "Status";
            // 
            // btnExport
            // 
            this.btnExport.Image = global::ROMS.Properties.Resources.excel;
            this.btnExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExport.Location = new System.Drawing.Point(273, 26);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(79, 29);
            this.btnExport.TabIndex = 2;
            this.btnExport.Text = "Export";
            this.btnExport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.BtnExport_Click);
            this.btnExport.Enter += new System.EventHandler(this.BtnExport_Enter);
            this.btnExport.Leave += new System.EventHandler(this.BtnExport_Leave);
            // 
            // btnView
            // 
            this.btnView.Image = global::ROMS.Properties.Resources.view;
            this.btnView.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnView.Location = new System.Drawing.Point(192, 26);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(75, 29);
            this.btnView.TabIndex = 1;
            this.btnView.Text = "View";
            this.btnView.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.BtnView_Click);
            this.btnView.Enter += new System.EventHandler(this.BtnView_Enter);
            this.btnView.Leave += new System.EventHandler(this.BtnView_Leave);
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
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV_SearchGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.DGV_SearchGrid.EnableHeadersVisualStyles = false;
            this.DGV_SearchGrid.GridColor = System.Drawing.Color.White;
            this.DGV_SearchGrid.Location = new System.Drawing.Point(3, 74);
            this.DGV_SearchGrid.Name = "DGV_SearchGrid";
            this.DGV_SearchGrid.RowHeadersVisible = false;
            this.DGV_SearchGrid.RowHeadersWidth = 70;
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
            this.DGV_SearchGrid.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.DGV_SearchGrid_ColumnWidthChanged_1);
            this.DGV_SearchGrid.CurrentCellDirtyStateChanged += new System.EventHandler(this.DGV_SearchGrid_CurrentCellDirtyStateChanged);
            this.DGV_SearchGrid.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.DGV_SearchGrid_EditingControlShowing);
            this.DGV_SearchGrid.Scroll += new System.Windows.Forms.ScrollEventHandler(this.DGV_SearchGrid_Scroll);
            // 
            // grdBrokerList
            // 
            this.grdBrokerList.AllowUserToAddRows = false;
            this.grdBrokerList.AllowUserToDeleteRows = false;
            this.grdBrokerList.AllowUserToResizeColumns = false;
            this.grdBrokerList.AllowUserToResizeRows = false;
            this.grdBrokerList.BackgroundColor = System.Drawing.Color.White;
            this.grdBrokerList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(242)))), ((int)(((byte)(213)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdBrokerList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.grdBrokerList.ColumnHeadersHeight = 30;
            this.grdBrokerList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdBrokerList.ColumnHeadersVisible = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdBrokerList.DefaultCellStyle = dataGridViewCellStyle5;
            this.grdBrokerList.EnableHeadersVisualStyles = false;
            this.grdBrokerList.GridColor = System.Drawing.Color.White;
            this.grdBrokerList.Location = new System.Drawing.Point(3, 130);
            this.grdBrokerList.Name = "grdBrokerList";
            this.grdBrokerList.ReadOnly = true;
            this.grdBrokerList.RowHeadersVisible = false;
            this.grdBrokerList.RowHeadersWidth = 100;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            this.grdBrokerList.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.grdBrokerList.RowTemplate.Height = 25;
            this.grdBrokerList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdBrokerList.Size = new System.Drawing.Size(1348, 510);
            this.grdBrokerList.TabIndex = 958797;
            this.grdBrokerList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.GrdBrokerList_DataBindingComplete);
            this.grdBrokerList.Scroll += new System.Windows.Forms.ScrollEventHandler(this.GrdBrokerList_Scroll);
            this.grdBrokerList.DoubleClick += new System.EventHandler(this.GrdBrokerList_DoubleClick);
            this.grdBrokerList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GrdBrokerList_KeyDown);
            // 
            // picLoader
            // 
            this.picLoader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picLoader.ErrorImage = null;
            this.picLoader.Image = global::ROMS.Properties.Resources.Iphone_spinner_2;
            this.picLoader.InitialImage = null;
            this.picLoader.Location = new System.Drawing.Point(3, 3);
            this.picLoader.Name = "picLoader";
            this.picLoader.Size = new System.Drawing.Size(1348, 635);
            this.picLoader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picLoader.TabIndex = 958799;
            this.picLoader.TabStop = false;
            this.picLoader.Visible = false;
            // 
            // lblNoRecordsFound
            // 
            this.lblNoRecordsFound.AutoSize = true;
            this.lblNoRecordsFound.BackColor = System.Drawing.Color.White;
            this.lblNoRecordsFound.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoRecordsFound.Location = new System.Drawing.Point(624, 375);
            this.lblNoRecordsFound.Name = "lblNoRecordsFound";
            this.lblNoRecordsFound.Size = new System.Drawing.Size(106, 20);
            this.lblNoRecordsFound.TabIndex = 958798;
            this.lblNoRecordsFound.Text = "No Records Found";
            this.lblNoRecordsFound.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // CP_BrokerList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(1354, 675);
            this.Controls.Add(this.lblNoRecordsFound);
            this.Controls.Add(this.pnlunitlist);
            this.Controls.Add(this.tsBroker);
            this.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "CP_BrokerList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Broker";
            this.Load += new System.EventHandler(this.CP_BrokerList_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CP_BrokerList_KeyDown);
            this.tsBroker.ResumeLayout(false);
            this.tsBroker.PerformLayout();
            this.pnlunitlist.ResumeLayout(false);
            this.grbFilterByUser.ResumeLayout(false);
            this.grbFilterByUser.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_SearchGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBrokerList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsBroker;
        private System.Windows.Forms.ToolStripLabel tspHeader;
        public System.Windows.Forms.ToolStripButton tsbDelete;
        public System.Windows.Forms.ToolStripSeparator tssEdit;
        public System.Windows.Forms.ToolStripButton tsbEdit;
        public System.Windows.Forms.ToolStripSeparator tssNew;
        public System.Windows.Forms.ToolStripButton tsbNew;
        private System.Windows.Forms.Panel pnlunitlist;
        public System.Windows.Forms.DataGridView DGV_SearchGrid;
        private System.Windows.Forms.Label lblNoRecordsFound;
        public System.Windows.Forms.DataGridView grdBrokerList;
        public System.Windows.Forms.PictureBox picLoader;
        private System.Windows.Forms.GroupBox grbFilterByUser;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTotalCount;
    }
}