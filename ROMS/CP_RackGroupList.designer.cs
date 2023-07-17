namespace ROMS
{
    partial class CP_RackGroupList
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
            this.tsRackGroupList = new System.Windows.Forms.ToolStrip();
            this.tspHeader = new System.Windows.Forms.ToolStripLabel();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.tssEdit = new System.Windows.Forms.ToolStripSeparator();
            this.tsbEdit = new System.Windows.Forms.ToolStripButton();
            this.tssNew = new System.Windows.Forms.ToolStripSeparator();
            this.tsbNew = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.grbFilterBy = new System.Windows.Forms.GroupBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.cmbconcern = new System.Windows.Forms.ComboBox();
            this.lblNoRecordsFound = new System.Windows.Forms.Label();
            this.grdUserList = new System.Windows.Forms.DataGridView();
            this.clmConcern = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmShopgodown = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmrackgroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnoofrack = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmNoOfUsers = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.picLoader = new System.Windows.Forms.PictureBox();
            this.lblDConcern = new System.Windows.Forms.Label();
            this.lblDShopGodown = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.tsRackGroupList.SuspendLayout();
            this.panel1.SuspendLayout();
            this.grbFilterBy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdUserList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).BeginInit();
            this.SuspendLayout();
            // 
            // tsRackGroupList
            // 
            this.tsRackGroupList.BackColor = System.Drawing.Color.White;
            this.tsRackGroupList.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsRackGroupList.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsRackGroupList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspHeader,
            this.tsbDelete,
            this.tssEdit,
            this.tsbEdit,
            this.tssNew,
            this.tsbNew});
            this.tsRackGroupList.Location = new System.Drawing.Point(0, 0);
            this.tsRackGroupList.Name = "tsRackGroupList";
            this.tsRackGroupList.Size = new System.Drawing.Size(1354, 27);
            this.tsRackGroupList.TabIndex = 35;
            this.tsRackGroupList.Text = "Rack Group";
            // 
            // tspHeader
            // 
            this.tspHeader.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tspHeader.Image = global::ROMS.Properties.Resources.bread_crumb;
            this.tspHeader.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tspHeader.Margin = new System.Windows.Forms.Padding(15, 1, 0, 2);
            this.tspHeader.Name = "tspHeader";
            this.tspHeader.Size = new System.Drawing.Size(87, 24);
            this.tspHeader.Text = "Rack Group";
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
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.grbFilterBy);
            this.panel1.Controls.Add(this.lblNoRecordsFound);
            this.panel1.Controls.Add(this.grdUserList);
            this.panel1.Controls.Add(this.picLoader);
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1354, 641);
            this.panel1.TabIndex = 36;
            // 
            // grbFilterBy
            // 
            this.grbFilterBy.Controls.Add(this.lblDShopGodown);
            this.grbFilterBy.Controls.Add(this.comboBox1);
            this.grbFilterBy.Controls.Add(this.lblDConcern);
            this.grbFilterBy.Controls.Add(this.btnExport);
            this.grbFilterBy.Controls.Add(this.btnView);
            this.grbFilterBy.Controls.Add(this.cmbconcern);
            this.grbFilterBy.Location = new System.Drawing.Point(14, 4);
            this.grbFilterBy.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbFilterBy.Name = "grbFilterBy";
            this.grbFilterBy.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbFilterBy.Size = new System.Drawing.Size(672, 67);
            this.grbFilterBy.TabIndex = 958800;
            this.grbFilterBy.TabStop = false;
            this.grbFilterBy.Text = "Filter By Rack Group";
            // 
            // btnExport
            // 
            this.btnExport.Image = global::ROMS.Properties.Resources.excel;
            this.btnExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExport.Location = new System.Drawing.Point(581, 26);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(79, 29);
            this.btnExport.TabIndex = 5;
            this.btnExport.Text = "Export";
            this.btnExport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExport.UseVisualStyleBackColor = true;
            // 
            // btnView
            // 
            this.btnView.Image = global::ROMS.Properties.Resources.view;
            this.btnView.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnView.Location = new System.Drawing.Point(498, 26);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(75, 29);
            this.btnView.TabIndex = 4;
            this.btnView.Text = "View";
            this.btnView.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnView.UseVisualStyleBackColor = true;
            // 
            // cmbconcern
            // 
            this.cmbconcern.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbconcern.FormattingEnabled = true;
            this.cmbconcern.Location = new System.Drawing.Point(83, 26);
            this.cmbconcern.Name = "cmbconcern";
            this.cmbconcern.Size = new System.Drawing.Size(147, 27);
            this.cmbconcern.TabIndex = 2;
            // 
            // lblNoRecordsFound
            // 
            this.lblNoRecordsFound.AutoSize = true;
            this.lblNoRecordsFound.BackColor = System.Drawing.Color.White;
            this.lblNoRecordsFound.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoRecordsFound.Location = new System.Drawing.Point(625, 292);
            this.lblNoRecordsFound.Name = "lblNoRecordsFound";
            this.lblNoRecordsFound.Size = new System.Drawing.Size(106, 20);
            this.lblNoRecordsFound.TabIndex = 958798;
            this.lblNoRecordsFound.Text = "No Records Found";
            this.lblNoRecordsFound.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // grdUserList
            // 
            this.grdUserList.AllowUserToAddRows = false;
            this.grdUserList.AllowUserToDeleteRows = false;
            this.grdUserList.AllowUserToResizeColumns = false;
            this.grdUserList.AllowUserToResizeRows = false;
            this.grdUserList.BackgroundColor = System.Drawing.Color.White;
            this.grdUserList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdUserList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdUserList.ColumnHeadersHeight = 30;
            this.grdUserList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdUserList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmConcern,
            this.clmShopgodown,
            this.clmrackgroup,
            this.clmnoofrack,
            this.clmNoOfUsers,
            this.clmStatus});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdUserList.DefaultCellStyle = dataGridViewCellStyle2;
            this.grdUserList.EnableHeadersVisualStyles = false;
            this.grdUserList.GridColor = System.Drawing.Color.White;
            this.grdUserList.Location = new System.Drawing.Point(13, 79);
            this.grdUserList.Name = "grdUserList";
            this.grdUserList.ReadOnly = true;
            this.grdUserList.RowHeadersVisible = false;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.grdUserList.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.grdUserList.RowTemplate.Height = 25;
            this.grdUserList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdUserList.Size = new System.Drawing.Size(1329, 561);
            this.grdUserList.TabIndex = 958797;
            // 
            // clmConcern
            // 
            this.clmConcern.HeaderText = "Concern";
            this.clmConcern.Name = "clmConcern";
            this.clmConcern.ReadOnly = true;
            // 
            // clmShopgodown
            // 
            this.clmShopgodown.HeaderText = "Shop Godown";
            this.clmShopgodown.Name = "clmShopgodown";
            this.clmShopgodown.ReadOnly = true;
            this.clmShopgodown.Width = 200;
            // 
            // clmrackgroup
            // 
            this.clmrackgroup.HeaderText = "Rack Group";
            this.clmrackgroup.Name = "clmrackgroup";
            this.clmrackgroup.ReadOnly = true;
            this.clmrackgroup.Width = 200;
            // 
            // clmnoofrack
            // 
            this.clmnoofrack.HeaderText = "No.Of Racks";
            this.clmnoofrack.Name = "clmnoofrack";
            this.clmnoofrack.ReadOnly = true;
            // 
            // clmNoOfUsers
            // 
            this.clmNoOfUsers.HeaderText = "No.Of Users";
            this.clmNoOfUsers.Name = "clmNoOfUsers";
            this.clmNoOfUsers.ReadOnly = true;
            // 
            // clmStatus
            // 
            this.clmStatus.HeaderText = "Status";
            this.clmStatus.Name = "clmStatus";
            this.clmStatus.ReadOnly = true;
            // 
            // picLoader
            // 
            this.picLoader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picLoader.ErrorImage = null;
            this.picLoader.Image = global::ROMS.Properties.Resources.loader;
            this.picLoader.InitialImage = null;
            this.picLoader.Location = new System.Drawing.Point(14, 80);
            this.picLoader.Name = "picLoader";
            this.picLoader.Size = new System.Drawing.Size(1329, 561);
            this.picLoader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picLoader.TabIndex = 958799;
            this.picLoader.TabStop = false;
            this.picLoader.Visible = false;
            // 
            // lblDConcern
            // 
            this.lblDConcern.AutoSize = true;
            this.lblDConcern.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDConcern.Location = new System.Drawing.Point(26, 29);
            this.lblDConcern.Name = "lblDConcern";
            this.lblDConcern.Size = new System.Drawing.Size(54, 20);
            this.lblDConcern.TabIndex = 36;
            this.lblDConcern.Text = "Concern";
            // 
            // lblDShopGodown
            // 
            this.lblDShopGodown.AutoSize = true;
            this.lblDShopGodown.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDShopGodown.Location = new System.Drawing.Point(247, 29);
            this.lblDShopGodown.Name = "lblDShopGodown";
            this.lblDShopGodown.Size = new System.Drawing.Size(82, 20);
            this.lblDShopGodown.TabIndex = 38;
            this.lblDShopGodown.Text = "Shop Godown";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(332, 26);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(147, 27);
            this.comboBox1.TabIndex = 37;
            // 
            // CP_RackGroupList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(1354, 675);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tsRackGroupList);
            this.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "CP_RackGroupList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User";
            this.Load += new System.EventHandler(this.CP_UserList_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CP_UserList_KeyDown);
            this.tsRackGroupList.ResumeLayout(false);
            this.tsRackGroupList.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.grbFilterBy.ResumeLayout(false);
            this.grbFilterBy.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdUserList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsRackGroupList;
        private System.Windows.Forms.ToolStripLabel tspHeader;
        public System.Windows.Forms.ToolStripSeparator tssEdit;
        public System.Windows.Forms.ToolStripButton tsbEdit;
        public System.Windows.Forms.ToolStripSeparator tssNew;
        public System.Windows.Forms.ToolStripButton tsbNew;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblNoRecordsFound;
        public System.Windows.Forms.DataGridView grdUserList;
        private System.Windows.Forms.PictureBox picLoader;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmConcern;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmShopgodown;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmrackgroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnoofrack;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmNoOfUsers;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmStatus;
        public System.Windows.Forms.ToolStripButton tsbDelete;
        private System.Windows.Forms.GroupBox grbFilterBy;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.ComboBox cmbconcern;
        private System.Windows.Forms.Label lblDShopGodown;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label lblDConcern;
    }
}