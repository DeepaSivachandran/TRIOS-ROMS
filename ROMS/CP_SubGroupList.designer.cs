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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tsGroupList = new System.Windows.Forms.ToolStrip();
            this.tspHeader = new System.Windows.Forms.ToolStripLabel();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.tssEdit = new System.Windows.Forms.ToolStripSeparator();
            this.tsbEdit = new System.Windows.Forms.ToolStripButton();
            this.tssNew = new System.Windows.Forms.ToolStripSeparator();
            this.tsbNew = new System.Windows.Forms.ToolStripButton();
            this.pnlSubgroup = new System.Windows.Forms.Panel();
            this.lblNoOfPrSubGroup = new System.Windows.Forms.Label();
            this.lblNoPrSubGroup = new System.Windows.Forms.Label();
            this.grbFilterBy = new System.Windows.Forms.GroupBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.cmbProductSubGroup = new System.Windows.Forms.ComboBox();
            this.lblNoRecordsFound = new System.Windows.Forms.Label();
            this.grdSubGroupList = new System.Windows.Forms.DataGridView();
            this.picLoader = new System.Windows.Forms.PictureBox();
            this.tsGroupList.SuspendLayout();
            this.pnlSubgroup.SuspendLayout();
            this.grbFilterBy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSubGroupList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).BeginInit();
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
            // lblNoOfPrSubGroup
            // 
            this.lblNoOfPrSubGroup.AutoSize = true;
            this.lblNoOfPrSubGroup.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Bold);
            this.lblNoOfPrSubGroup.ForeColor = System.Drawing.Color.Crimson;
            this.lblNoOfPrSubGroup.Location = new System.Drawing.Point(858, 27);
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
            this.lblNoPrSubGroup.Location = new System.Drawing.Point(702, 27);
            this.lblNoPrSubGroup.Name = "lblNoPrSubGroup";
            this.lblNoPrSubGroup.Size = new System.Drawing.Size(154, 20);
            this.lblNoPrSubGroup.TabIndex = 958796;
            this.lblNoPrSubGroup.Text = "No.of Product Sub Groups :";
            // 
            // grbFilterBy
            // 
            this.grbFilterBy.Controls.Add(this.btnExport);
            this.grbFilterBy.Controls.Add(this.btnView);
            this.grbFilterBy.Controls.Add(this.cmbProductSubGroup);
            this.grbFilterBy.Location = new System.Drawing.Point(3, 2);
            this.grbFilterBy.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbFilterBy.Name = "grbFilterBy";
            this.grbFilterBy.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbFilterBy.Size = new System.Drawing.Size(672, 67);
            this.grbFilterBy.TabIndex = 958795;
            this.grbFilterBy.TabStop = false;
            this.grbFilterBy.Text = "Filter By Product Sub Group";
            // 
            // btnExport
            // 
            this.btnExport.Image = global::ROMS.Properties.Resources.excel;
            this.btnExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExport.Location = new System.Drawing.Point(581, 23);
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
            this.btnView.Location = new System.Drawing.Point(498, 23);
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
            // cmbProductSubGroup
            // 
            this.cmbProductSubGroup.FormattingEnabled = true;
            this.cmbProductSubGroup.Location = new System.Drawing.Point(27, 23);
            this.cmbProductSubGroup.Name = "cmbProductSubGroup";
            this.cmbProductSubGroup.Size = new System.Drawing.Size(454, 27);
            this.cmbProductSubGroup.TabIndex = 0;
            this.cmbProductSubGroup.SelectedIndexChanged += new System.EventHandler(this.CmbProductSubGroup_SelectedIndexChanged);
            this.cmbProductSubGroup.Enter += new System.EventHandler(this.CmbProductSubGroup_Enter);
            this.cmbProductSubGroup.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbProductSubGroup_KeyDown);
            this.cmbProductSubGroup.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbProductSubGroup_KeyPress);
            this.cmbProductSubGroup.Leave += new System.EventHandler(this.CmbProductSubGroup_Leave);
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(242)))), ((int)(((byte)(213)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdSubGroupList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdSubGroupList.ColumnHeadersHeight = 30;
            this.grdSubGroupList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdSubGroupList.DefaultCellStyle = dataGridViewCellStyle2;
            this.grdSubGroupList.EnableHeadersVisualStyles = false;
            this.grdSubGroupList.GridColor = System.Drawing.Color.White;
            this.grdSubGroupList.Location = new System.Drawing.Point(3, 71);
            this.grdSubGroupList.Name = "grdSubGroupList";
            this.grdSubGroupList.ReadOnly = true;
            this.grdSubGroupList.RowHeadersVisible = false;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.grdSubGroupList.RowsDefaultCellStyle = dataGridViewCellStyle3;
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
            this.picLoader.Image = global::ROMS.Properties.Resources.loader;
            this.picLoader.InitialImage = null;
            this.picLoader.Location = new System.Drawing.Point(14, 81);
            this.picLoader.Name = "picLoader";
            this.picLoader.Size = new System.Drawing.Size(1325, 550);
            this.picLoader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picLoader.TabIndex = 958794;
            this.picLoader.TabStop = false;
            this.picLoader.Visible = false;
            // 
            // CP_SubGroupList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(1354, 675);
            this.Controls.Add(this.pnlSubgroup);
            this.Controls.Add(this.tsGroupList);
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
            this.grbFilterBy.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdSubGroupList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).EndInit();
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
        public System.Windows.Forms.ComboBox cmbProductSubGroup;
    }
}