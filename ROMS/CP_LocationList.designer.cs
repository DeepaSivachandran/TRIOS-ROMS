namespace ROMS
{
    partial class CP_LocationList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tsGodownList = new System.Windows.Forms.ToolStrip();
            this.tspHeader = new System.Windows.Forms.ToolStripLabel();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.tssEdit = new System.Windows.Forms.ToolStripSeparator();
            this.tsbEdit = new System.Windows.Forms.ToolStripButton();
            this.tssNew = new System.Windows.Forms.ToolStripSeparator();
            this.tsbNew = new System.Windows.Forms.ToolStripButton();
            this.pnlGodownList = new System.Windows.Forms.Panel();
            this.grpSearchByLocationName = new System.Windows.Forms.GroupBox();
            this.grbFilterByConcern = new System.Windows.Forms.GroupBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.cmbConcern = new System.Windows.Forms.ComboBox();
            this.lblNoRecordsFound = new System.Windows.Forms.Label();
            this.grdGodownList = new System.Windows.Forms.DataGridView();
            this.picLoader = new System.Windows.Forms.PictureBox();
            this.txtSearchbyLocationName = new System.Windows.Forms.TextBox();
            this.tsGodownList.SuspendLayout();
            this.pnlGodownList.SuspendLayout();
            this.grpSearchByLocationName.SuspendLayout();
            this.grbFilterByConcern.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdGodownList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).BeginInit();
            this.SuspendLayout();
            // 
            // tsGodownList
            // 
            this.tsGodownList.BackColor = System.Drawing.Color.White;
            this.tsGodownList.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsGodownList.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsGodownList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspHeader,
            this.tsbDelete,
            this.tssEdit,
            this.tsbEdit,
            this.tssNew,
            this.tsbNew});
            this.tsGodownList.Location = new System.Drawing.Point(0, 0);
            this.tsGodownList.Name = "tsGodownList";
            this.tsGodownList.Size = new System.Drawing.Size(1354, 27);
            this.tsGodownList.TabIndex = 35;
            this.tsGodownList.Text = "Godown List";
            // 
            // tspHeader
            // 
            this.tspHeader.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tspHeader.Image = global::ROMS.Properties.Resources.bread_crumb;
            this.tspHeader.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tspHeader.Margin = new System.Windows.Forms.Padding(15, 1, 0, 2);
            this.tspHeader.Name = "tspHeader";
            this.tspHeader.Size = new System.Drawing.Size(103, 24);
            this.tspHeader.Text = "Stock Location";
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
            // pnlGodownList
            // 
            this.pnlGodownList.BackColor = System.Drawing.Color.White;
            this.pnlGodownList.Controls.Add(this.grpSearchByLocationName);
            this.pnlGodownList.Controls.Add(this.grbFilterByConcern);
            this.pnlGodownList.Controls.Add(this.lblNoRecordsFound);
            this.pnlGodownList.Controls.Add(this.grdGodownList);
            this.pnlGodownList.Controls.Add(this.picLoader);
            this.pnlGodownList.Location = new System.Drawing.Point(0, 31);
            this.pnlGodownList.Name = "pnlGodownList";
            this.pnlGodownList.Size = new System.Drawing.Size(1354, 641);
            this.pnlGodownList.TabIndex = 958788;
            // 
            // grpSearchByLocationName
            // 
            this.grpSearchByLocationName.Controls.Add(this.txtSearchbyLocationName);
            this.grpSearchByLocationName.Location = new System.Drawing.Point(1005, 2);
            this.grpSearchByLocationName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpSearchByLocationName.Name = "grpSearchByLocationName";
            this.grpSearchByLocationName.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpSearchByLocationName.Size = new System.Drawing.Size(344, 67);
            this.grpSearchByLocationName.TabIndex = 3;
            this.grpSearchByLocationName.TabStop = false;
            this.grpSearchByLocationName.Text = "Search by Location Name";
            // 
            // grbFilterByConcern
            // 
            this.grbFilterByConcern.Controls.Add(this.btnExport);
            this.grbFilterByConcern.Controls.Add(this.btnView);
            this.grbFilterByConcern.Controls.Add(this.cmbConcern);
            this.grbFilterByConcern.Location = new System.Drawing.Point(3, 2);
            this.grbFilterByConcern.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbFilterByConcern.Name = "grbFilterByConcern";
            this.grbFilterByConcern.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbFilterByConcern.Size = new System.Drawing.Size(996, 67);
            this.grbFilterByConcern.TabIndex = 0;
            this.grbFilterByConcern.TabStop = false;
            this.grbFilterByConcern.Text = "Filter By Concern";
            // 
            // btnExport
            // 
            this.btnExport.Image = global::ROMS.Properties.Resources.excel;
            this.btnExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExport.Location = new System.Drawing.Point(240, 25);
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
            this.btnView.Location = new System.Drawing.Point(159, 25);
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
            // cmbConcern
            // 
            this.cmbConcern.FormattingEnabled = true;
            this.cmbConcern.Location = new System.Drawing.Point(9, 26);
            this.cmbConcern.Name = "cmbConcern";
            this.cmbConcern.Size = new System.Drawing.Size(144, 27);
            this.cmbConcern.TabIndex = 0;
            this.cmbConcern.Enter += new System.EventHandler(this.CmbConcern_Enter);
            this.cmbConcern.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbConcern_KeyDown);
            this.cmbConcern.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbConcern_KeyPress);
            this.cmbConcern.Leave += new System.EventHandler(this.CmbConcern_Leave);
            // 
            // lblNoRecordsFound
            // 
            this.lblNoRecordsFound.AutoSize = true;
            this.lblNoRecordsFound.BackColor = System.Drawing.Color.White;
            this.lblNoRecordsFound.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoRecordsFound.Location = new System.Drawing.Point(624, 346);
            this.lblNoRecordsFound.Name = "lblNoRecordsFound";
            this.lblNoRecordsFound.Size = new System.Drawing.Size(106, 20);
            this.lblNoRecordsFound.TabIndex = 958789;
            this.lblNoRecordsFound.Text = "No Records Found";
            this.lblNoRecordsFound.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // grdGodownList
            // 
            this.grdGodownList.AllowUserToAddRows = false;
            this.grdGodownList.AllowUserToDeleteRows = false;
            this.grdGodownList.AllowUserToResizeColumns = false;
            this.grdGodownList.AllowUserToResizeRows = false;
            this.grdGodownList.BackgroundColor = System.Drawing.Color.White;
            this.grdGodownList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(242)))), ((int)(((byte)(213)))));
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdGodownList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.grdGodownList.ColumnHeadersHeight = 30;
            this.grdGodownList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdGodownList.EnableHeadersVisualStyles = false;
            this.grdGodownList.GridColor = System.Drawing.Color.White;
            this.grdGodownList.Location = new System.Drawing.Point(3, 71);
            this.grdGodownList.Name = "grdGodownList";
            this.grdGodownList.ReadOnly = true;
            this.grdGodownList.RowHeadersVisible = false;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.White;
            this.grdGodownList.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.grdGodownList.RowTemplate.Height = 25;
            this.grdGodownList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdGodownList.Size = new System.Drawing.Size(1348, 570);
            this.grdGodownList.TabIndex = 958788;
            this.grdGodownList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.GrdGodownList_DataBindingComplete);
            this.grdGodownList.SelectionChanged += new System.EventHandler(this.grdLocationList_SelectionChanged);
            this.grdGodownList.DoubleClick += new System.EventHandler(this.GrdGodownList_DoubleClick);
            this.grdGodownList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GrdGodownList_KeyDown);
            // 
            // picLoader
            // 
            this.picLoader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picLoader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picLoader.ErrorImage = null;
            this.picLoader.Image = global::ROMS.Properties.Resources.Iphone_spinner_2;
            this.picLoader.InitialImage = null;
            this.picLoader.Location = new System.Drawing.Point(3, 71);
            this.picLoader.Name = "picLoader";
            this.picLoader.Size = new System.Drawing.Size(1346, 567);
            this.picLoader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picLoader.TabIndex = 958790;
            this.picLoader.TabStop = false;
            this.picLoader.Visible = false;
            // 
            // txtSearchbyLocationName
            // 
            this.txtSearchbyLocationName.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchbyLocationName.Location = new System.Drawing.Point(6, 26);
            this.txtSearchbyLocationName.MaxLength = 50;
            this.txtSearchbyLocationName.Name = "txtSearchbyLocationName";
            this.txtSearchbyLocationName.Size = new System.Drawing.Size(331, 27);
            this.txtSearchbyLocationName.TabIndex = 958791;
            this.txtSearchbyLocationName.TextChanged += new System.EventHandler(this.TxtSearchbyLocationName_TextChanged);
            this.txtSearchbyLocationName.Enter += new System.EventHandler(this.TxtSearchbyLocationName_Enter);
            this.txtSearchbyLocationName.Leave += new System.EventHandler(this.TxtSearchbyLocationName_Leave);
            // 
            // CP_LocationList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(1354, 675);
            this.Controls.Add(this.pnlGodownList);
            this.Controls.Add(this.tsGodownList);
            this.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "CP_LocationList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Godown List";
            this.Load += new System.EventHandler(this.CP_LocationList_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CP_LocationList_KeyDown);
            this.tsGodownList.ResumeLayout(false);
            this.tsGodownList.PerformLayout();
            this.pnlGodownList.ResumeLayout(false);
            this.pnlGodownList.PerformLayout();
            this.grpSearchByLocationName.ResumeLayout(false);
            this.grpSearchByLocationName.PerformLayout();
            this.grbFilterByConcern.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdGodownList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsGodownList;
        private System.Windows.Forms.ToolStripLabel tspHeader;
        public System.Windows.Forms.ToolStripButton tsbDelete;
        public System.Windows.Forms.ToolStripSeparator tssEdit;
        public System.Windows.Forms.ToolStripButton tsbEdit;
        public System.Windows.Forms.ToolStripSeparator tssNew;
        public System.Windows.Forms.ToolStripButton tsbNew;
        private System.Windows.Forms.Panel pnlGodownList;
        private System.Windows.Forms.Label lblNoRecordsFound;
        public System.Windows.Forms.DataGridView grdGodownList;
        private System.Windows.Forms.PictureBox picLoader;
        private System.Windows.Forms.GroupBox grbFilterByConcern;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.ComboBox cmbConcern;
        private System.Windows.Forms.GroupBox grpSearchByLocationName;
        private System.Windows.Forms.TextBox txtSearchbyLocationName;
    }
}