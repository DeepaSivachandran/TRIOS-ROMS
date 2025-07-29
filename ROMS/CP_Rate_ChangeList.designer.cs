namespace ROMS
{
    partial class CP_Rate_ChangeList
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
            this.tsItemList = new System.Windows.Forms.ToolStrip();
            this.tspHeader = new System.Windows.Forms.ToolStripLabel();
            this.tsbNew = new System.Windows.Forms.ToolStripButton();
            this.pnlItemList = new System.Windows.Forms.Panel();
            this.lblNoRecordsFound = new System.Windows.Forms.Label();
            this.grdItemList = new System.Windows.Forms.DataGridView();
            this.DGV_SearchGrid = new System.Windows.Forms.DataGridView();
            this.clmdsno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.icode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmdpronametamil = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDPurchaseUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmLastRRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmLastWRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmLiveRRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmLiveWRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTeller = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.picLoader = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tsItemList.SuspendLayout();
            this.pnlItemList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdItemList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_SearchGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tsItemList
            // 
            this.tsItemList.BackColor = System.Drawing.Color.White;
            this.tsItemList.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsItemList.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsItemList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspHeader,
            this.tsbNew});
            this.tsItemList.Location = new System.Drawing.Point(0, 0);
            this.tsItemList.Name = "tsItemList";
            this.tsItemList.Size = new System.Drawing.Size(1354, 31);
            this.tsItemList.TabIndex = 35;
            this.tsItemList.Text = "ItemList";
            // 
            // tspHeader
            // 
            this.tspHeader.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tspHeader.Image = global::ROMS.Properties.Resources.bread_crumb;
            this.tspHeader.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tspHeader.Margin = new System.Windows.Forms.Padding(15, 1, 0, 2);
            this.tspHeader.Name = "tspHeader";
            this.tspHeader.Size = new System.Drawing.Size(94, 28);
            this.tspHeader.Text = "Rate Change";
            // 
            // tsbNew
            // 
            this.tsbNew.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbNew.Image = global::ROMS.Properties.Resources.view;
            this.tsbNew.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNew.Margin = new System.Windows.Forms.Padding(0, 1, 10, 2);
            this.tsbNew.Name = "tsbNew";
            this.tsbNew.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tsbNew.Size = new System.Drawing.Size(136, 28);
            this.tsbNew.Text = "&Search by Product";
            this.tsbNew.Click += new System.EventHandler(this.tsbNew_Click);
            // 
            // pnlItemList
            // 
            this.pnlItemList.BackColor = System.Drawing.Color.White;
            this.pnlItemList.Controls.Add(this.lblNoRecordsFound);
            this.pnlItemList.Controls.Add(this.grdItemList);
            this.pnlItemList.Controls.Add(this.DGV_SearchGrid);
            this.pnlItemList.Controls.Add(this.picLoader);
            this.pnlItemList.Controls.Add(this.pictureBox1);
            this.pnlItemList.Location = new System.Drawing.Point(0, 31);
            this.pnlItemList.Name = "pnlItemList";
            this.pnlItemList.Size = new System.Drawing.Size(1354, 641);
            this.pnlItemList.TabIndex = 36;
            // 
            // lblNoRecordsFound
            // 
            this.lblNoRecordsFound.AutoSize = true;
            this.lblNoRecordsFound.BackColor = System.Drawing.Color.White;
            this.lblNoRecordsFound.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoRecordsFound.Location = new System.Drawing.Point(624, 338);
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(242)))), ((int)(((byte)(213)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdItemList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdItemList.ColumnHeadersHeight = 30;
            this.grdItemList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdItemList.ColumnHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdItemList.DefaultCellStyle = dataGridViewCellStyle2;
            this.grdItemList.EnableHeadersVisualStyles = false;
            this.grdItemList.GridColor = System.Drawing.Color.White;
            this.grdItemList.Location = new System.Drawing.Point(3, 58);
            this.grdItemList.Name = "grdItemList";
            this.grdItemList.ReadOnly = true;
            this.grdItemList.RowHeadersVisible = false;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.grdItemList.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.grdItemList.RowTemplate.Height = 25;
            this.grdItemList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdItemList.ShowRowErrors = false;
            this.grdItemList.Size = new System.Drawing.Size(1348, 581);
            this.grdItemList.TabIndex = 958802;
            this.grdItemList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.grdItemList_DataBindingComplete);
            this.grdItemList.Scroll += new System.Windows.Forms.ScrollEventHandler(this.GrdItemList_Scroll);
            // 
            // DGV_SearchGrid
            // 
            this.DGV_SearchGrid.AllowUserToAddRows = false;
            this.DGV_SearchGrid.AllowUserToDeleteRows = false;
            this.DGV_SearchGrid.AllowUserToResizeRows = false;
            this.DGV_SearchGrid.BackgroundColor = System.Drawing.Color.White;
            this.DGV_SearchGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(242)))), ((int)(((byte)(213)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_SearchGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.DGV_SearchGrid.ColumnHeadersHeight = 30;
            this.DGV_SearchGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGV_SearchGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmdsno,
            this.icode,
            this.clmdpronametamil,
            this.clmDPurchaseUnit,
            this.clmLastRRate,
            this.clmLastWRate,
            this.clmLiveRRate,
            this.clmLiveWRate,
            this.clmTeller,
            this.clmUser});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV_SearchGrid.DefaultCellStyle = dataGridViewCellStyle5;
            this.DGV_SearchGrid.EnableHeadersVisualStyles = false;
            this.DGV_SearchGrid.GridColor = System.Drawing.Color.White;
            this.DGV_SearchGrid.Location = new System.Drawing.Point(3, 4);
            this.DGV_SearchGrid.Name = "DGV_SearchGrid";
            this.DGV_SearchGrid.RowHeadersVisible = false;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            this.DGV_SearchGrid.RowsDefaultCellStyle = dataGridViewCellStyle6;
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
            // clmdpronametamil
            // 
            this.clmdpronametamil.HeaderText = "Product Name in Tamil";
            this.clmdpronametamil.Name = "clmdpronametamil";
            this.clmdpronametamil.Width = 200;
            // 
            // clmDPurchaseUnit
            // 
            this.clmDPurchaseUnit.HeaderText = "Unit";
            this.clmDPurchaseUnit.Name = "clmDPurchaseUnit";
            this.clmDPurchaseUnit.ReadOnly = true;
            // 
            // clmLastRRate
            // 
            this.clmLastRRate.HeaderText = "Last R.Rate";
            this.clmLastRRate.Name = "clmLastRRate";
            // 
            // clmLastWRate
            // 
            this.clmLastWRate.HeaderText = "Last W.Rate";
            this.clmLastWRate.Name = "clmLastWRate";
            this.clmLastWRate.Width = 120;
            // 
            // clmLiveRRate
            // 
            this.clmLiveRRate.HeaderText = "Live R.Rate";
            this.clmLiveRRate.Name = "clmLiveRRate";
            this.clmLiveRRate.Width = 120;
            // 
            // clmLiveWRate
            // 
            this.clmLiveWRate.HeaderText = "Live W.Rate";
            this.clmLiveWRate.Name = "clmLiveWRate";
            this.clmLiveWRate.Width = 120;
            // 
            // clmTeller
            // 
            this.clmTeller.HeaderText = "Teller";
            this.clmTeller.Name = "clmTeller";
            this.clmTeller.Width = 150;
            // 
            // clmUser
            // 
            this.clmUser.HeaderText = "User";
            this.clmUser.Name = "clmUser";
            this.clmUser.Width = 150;
            // 
            // picLoader
            // 
            this.picLoader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picLoader.ErrorImage = null;
            this.picLoader.Image = global::ROMS.Properties.Resources.Iphone_spinner_2;
            this.picLoader.InitialImage = null;
            this.picLoader.Location = new System.Drawing.Point(3, 3);
            this.picLoader.Name = "picLoader";
            this.picLoader.Size = new System.Drawing.Size(1348, 636);
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
            // CP_Rate_ChangeList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(1354, 675);
            this.Controls.Add(this.pnlItemList);
            this.Controls.Add(this.tsItemList);
            this.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "CP_Rate_ChangeList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Item List";
            this.Load += new System.EventHandler(this.CP_ProductList_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CP_ProductList_KeyDown);
            this.tsItemList.ResumeLayout(false);
            this.tsItemList.PerformLayout();
            this.pnlItemList.ResumeLayout(false);
            this.pnlItemList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdItemList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_SearchGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsItemList;
        private System.Windows.Forms.ToolStripLabel tspHeader;
        public System.Windows.Forms.ToolStripButton tsbNew;
        private System.Windows.Forms.Panel pnlItemList;
        public System.Windows.Forms.DataGridView DGV_SearchGrid;
        private System.Windows.Forms.Label lblNoRecordsFound;
        public System.Windows.Forms.DataGridView grdItemList;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.PictureBox picLoader;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmdsno;
        private System.Windows.Forms.DataGridViewTextBoxColumn icode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmdpronametamil;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDPurchaseUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmLastRRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmLastWRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmLiveRRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmLiveWRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTeller;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmUser;
    }
}