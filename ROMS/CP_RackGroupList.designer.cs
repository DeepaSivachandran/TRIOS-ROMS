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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tsRackGroupList = new System.Windows.Forms.ToolStrip();
            this.tspHeader = new System.Windows.Forms.ToolStripLabel();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.tssEdit = new System.Windows.Forms.ToolStripSeparator();
            this.tsbEdit = new System.Windows.Forms.ToolStripButton();
            this.tssNew = new System.Windows.Forms.ToolStripSeparator();
            this.tsbNew = new System.Windows.Forms.ToolStripButton();
            this.pnlRack = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.clmSno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDRackName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDNoofproducts = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grbFilterBy = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.lblDConcern = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.cmbconcern = new System.Windows.Forms.ComboBox();
            this.lblDShopGodown = new System.Windows.Forms.Label();
            this.lblNoRecordsFound = new System.Windows.Forms.Label();
            this.grdUserList = new System.Windows.Forms.DataGridView();
            this.clmdsno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmConcern = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmrackgroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmRackName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmNoOfUsers = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmNoofproducts = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.picLoader = new System.Windows.Forms.PictureBox();
            this.tsRackGroupList.SuspendLayout();
            this.pnlRack.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
            // pnlRack
            // 
            this.pnlRack.BackColor = System.Drawing.Color.White;
            this.pnlRack.Controls.Add(this.dataGridView1);
            this.pnlRack.Controls.Add(this.grbFilterBy);
            this.pnlRack.Controls.Add(this.lblNoRecordsFound);
            this.pnlRack.Controls.Add(this.grdUserList);
            this.pnlRack.Controls.Add(this.picLoader);
            this.pnlRack.Location = new System.Drawing.Point(0, 31);
            this.pnlRack.Name = "pnlRack";
            this.pnlRack.Size = new System.Drawing.Size(1354, 641);
            this.pnlRack.TabIndex = 36;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeight = 30;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmSno,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn3,
            this.clmDRackName,
            this.Column2,
            this.dataGridViewTextBoxColumn4,
            this.clmDNoofproducts,
            this.dataGridViewTextBoxColumn6});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.GridColor = System.Drawing.Color.White;
            this.dataGridView1.Location = new System.Drawing.Point(3, 74);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1348, 56);
            this.dataGridView1.TabIndex = 958801;
            // 
            // clmSno
            // 
            this.clmSno.HeaderText = "S.No.";
            this.clmSno.Name = "clmSno";
            this.clmSno.ReadOnly = true;
            this.clmSno.Width = 50;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Concern";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Rack Group";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 200;
            // 
            // clmDRackName
            // 
            this.clmDRackName.HeaderText = "Rack Name";
            this.clmDRackName.Name = "clmDRackName";
            this.clmDRackName.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Description";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Staff Name";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 200;
            // 
            // clmDNoofproducts
            // 
            this.clmDNoofproducts.HeaderText = "Total Products";
            this.clmDNoofproducts.Name = "clmDNoofproducts";
            this.clmDNoofproducts.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Status";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // grbFilterBy
            // 
            this.grbFilterBy.Controls.Add(this.comboBox1);
            this.grbFilterBy.Controls.Add(this.lblDConcern);
            this.grbFilterBy.Controls.Add(this.btnExport);
            this.grbFilterBy.Controls.Add(this.btnView);
            this.grbFilterBy.Controls.Add(this.cmbconcern);
            this.grbFilterBy.Controls.Add(this.lblDShopGodown);
            this.grbFilterBy.Location = new System.Drawing.Point(3, 2);
            this.grbFilterBy.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbFilterBy.Name = "grbFilterBy";
            this.grbFilterBy.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbFilterBy.Size = new System.Drawing.Size(672, 67);
            this.grbFilterBy.TabIndex = 958800;
            this.grbFilterBy.TabStop = false;
            this.grbFilterBy.Text = "Filter By Rack Group";
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
            // lblDShopGodown
            // 
            this.lblDShopGodown.AutoSize = true;
            this.lblDShopGodown.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDShopGodown.Location = new System.Drawing.Point(247, 29);
            this.lblDShopGodown.Name = "lblDShopGodown";
            this.lblDShopGodown.Size = new System.Drawing.Size(87, 20);
            this.lblDShopGodown.TabIndex = 38;
            this.lblDShopGodown.Text = "Stock Location";
            // 
            // lblNoRecordsFound
            // 
            this.lblNoRecordsFound.AutoSize = true;
            this.lblNoRecordsFound.BackColor = System.Drawing.Color.White;
            this.lblNoRecordsFound.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoRecordsFound.Location = new System.Drawing.Point(625, 385);
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
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdUserList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.grdUserList.ColumnHeadersHeight = 30;
            this.grdUserList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdUserList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmdsno,
            this.clmConcern,
            this.clmrackgroup,
            this.clmRackName,
            this.Column1,
            this.clmNoOfUsers,
            this.clmNoofproducts,
            this.clmStatus});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdUserList.DefaultCellStyle = dataGridViewCellStyle5;
            this.grdUserList.EnableHeadersVisualStyles = false;
            this.grdUserList.GridColor = System.Drawing.Color.White;
            this.grdUserList.Location = new System.Drawing.Point(3, 130);
            this.grdUserList.Name = "grdUserList";
            this.grdUserList.ReadOnly = true;
            this.grdUserList.RowHeadersVisible = false;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            this.grdUserList.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.grdUserList.RowTemplate.Height = 25;
            this.grdUserList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdUserList.Size = new System.Drawing.Size(1348, 510);
            this.grdUserList.TabIndex = 958797;
            // 
            // clmdsno
            // 
            this.clmdsno.HeaderText = "S.No.";
            this.clmdsno.Name = "clmdsno";
            this.clmdsno.ReadOnly = true;
            this.clmdsno.Width = 50;
            // 
            // clmConcern
            // 
            this.clmConcern.HeaderText = "Concern";
            this.clmConcern.Name = "clmConcern";
            this.clmConcern.ReadOnly = true;
            // 
            // clmrackgroup
            // 
            this.clmrackgroup.HeaderText = "Rack Group";
            this.clmrackgroup.Name = "clmrackgroup";
            this.clmrackgroup.ReadOnly = true;
            this.clmrackgroup.Width = 200;
            // 
            // clmRackName
            // 
            this.clmRackName.HeaderText = "Rack Name";
            this.clmRackName.Name = "clmRackName";
            this.clmRackName.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Description";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // clmNoOfUsers
            // 
            this.clmNoOfUsers.HeaderText = "Staff Name";
            this.clmNoOfUsers.Name = "clmNoOfUsers";
            this.clmNoOfUsers.ReadOnly = true;
            this.clmNoOfUsers.Width = 200;
            // 
            // clmNoofproducts
            // 
            this.clmNoofproducts.HeaderText = "Total Products";
            this.clmNoofproducts.Name = "clmNoofproducts";
            this.clmNoofproducts.ReadOnly = true;
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
            // CP_RackGroupList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(1354, 675);
            this.Controls.Add(this.pnlRack);
            this.Controls.Add(this.tsRackGroupList);
            this.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "CP_RackGroupList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CP_RackGroupList_KeyDown);
            this.tsRackGroupList.ResumeLayout(false);
            this.tsRackGroupList.PerformLayout();
            this.pnlRack.ResumeLayout(false);
            this.pnlRack.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
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
        private System.Windows.Forms.Panel pnlRack;
        private System.Windows.Forms.Label lblNoRecordsFound;
        public System.Windows.Forms.DataGridView grdUserList;
        private System.Windows.Forms.PictureBox picLoader;
        public System.Windows.Forms.ToolStripButton tsbDelete;
        private System.Windows.Forms.GroupBox grbFilterBy;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.ComboBox cmbconcern;
        private System.Windows.Forms.Label lblDShopGodown;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label lblDConcern;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSno;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDRackName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDNoofproducts;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmdsno;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmConcern;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmrackgroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmRackName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmNoOfUsers;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmNoofproducts;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmStatus;
    }
}