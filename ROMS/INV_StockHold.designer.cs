namespace ROMS
{
    partial class INV_StockHold
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
            this.tsStockRequest = new System.Windows.Forms.ToolStrip();
            this.tspStockRequest = new System.Windows.Forms.ToolStripLabel();
            this.lblNoRecordsFound = new System.Windows.Forms.Label();
            this.pnlStockRequest = new System.Windows.Forms.Panel();
            this.grpStockRequest = new System.Windows.Forms.GroupBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.grdStockRequest = new System.Windows.Forms.DataGridView();
            this.txtProductNamePICode = new System.Windows.Forms.TextBox();
            this.lblDEProductName = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.txtMrp = new System.Windows.Forms.TextBox();
            this.txtunitrate = new System.Windows.Forms.TextBox();
            this.lblbatchno = new System.Windows.Forms.Label();
            this.lblMrp = new System.Windows.Forms.Label();
            this.txtExpiryDate = new System.Windows.Forms.TextBox();
            this.lblExpiryDate = new System.Windows.Forms.Label();
            this.txtunit = new System.Windows.Forms.TextBox();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPICode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmProductnameInEnglish = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmRackGroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmRack = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmIncharge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmRequiredQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmRemove = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tsStockRequest.SuspendLayout();
            this.pnlStockRequest.SuspendLayout();
            this.grpStockRequest.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdStockRequest)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsStockRequest
            // 
            this.tsStockRequest.BackColor = System.Drawing.Color.White;
            this.tsStockRequest.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsStockRequest.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsStockRequest.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspStockRequest});
            this.tsStockRequest.Location = new System.Drawing.Point(0, 0);
            this.tsStockRequest.Name = "tsStockRequest";
            this.tsStockRequest.Size = new System.Drawing.Size(1354, 25);
            this.tsStockRequest.TabIndex = 35;
            this.tsStockRequest.Text = "Stock Request";
            // 
            // tspStockRequest
            // 
            this.tspStockRequest.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tspStockRequest.Image = global::ROMS.Properties.Resources.bread_crumb;
            this.tspStockRequest.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tspStockRequest.Margin = new System.Windows.Forms.Padding(15, 1, 0, 2);
            this.tspStockRequest.Name = "tspStockRequest";
            this.tspStockRequest.Size = new System.Drawing.Size(82, 22);
            this.tspStockRequest.Text = "Stock Hold";
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
            // pnlStockRequest
            // 
            this.pnlStockRequest.BackColor = System.Drawing.Color.White;
            this.pnlStockRequest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlStockRequest.Controls.Add(this.grpStockRequest);
            this.pnlStockRequest.Location = new System.Drawing.Point(0, 29);
            this.pnlStockRequest.Name = "pnlStockRequest";
            this.pnlStockRequest.Size = new System.Drawing.Size(1354, 644);
            this.pnlStockRequest.TabIndex = 958764;
            // 
            // grpStockRequest
            // 
            this.grpStockRequest.BackColor = System.Drawing.Color.White;
            this.grpStockRequest.Controls.Add(this.groupBox2);
            this.grpStockRequest.Controls.Add(this.btnUpdate);
            this.grpStockRequest.Controls.Add(this.txtunit);
            this.grpStockRequest.Controls.Add(this.lblExpiryDate);
            this.grpStockRequest.Controls.Add(this.txtExpiryDate);
            this.grpStockRequest.Controls.Add(this.txtunitrate);
            this.grpStockRequest.Controls.Add(this.lblbatchno);
            this.grpStockRequest.Controls.Add(this.lblMrp);
            this.grpStockRequest.Controls.Add(this.textBox4);
            this.grpStockRequest.Controls.Add(this.txtMrp);
            this.grpStockRequest.Controls.Add(this.textBox2);
            this.grpStockRequest.Controls.Add(this.label2);
            this.grpStockRequest.Controls.Add(this.grdStockRequest);
            this.grpStockRequest.Controls.Add(this.txtProductNamePICode);
            this.grpStockRequest.Controls.Add(this.lblDEProductName);
            this.grpStockRequest.Location = new System.Drawing.Point(12, 3);
            this.grpStockRequest.Name = "grpStockRequest";
            this.grpStockRequest.Size = new System.Drawing.Size(1329, 634);
            this.grpStockRequest.TabIndex = 958765;
            this.grpStockRequest.TabStop = false;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(710, 35);
            this.textBox2.MaxLength = 50;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(69, 27);
            this.textBox2.TabIndex = 1111180;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(710, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 20);
            this.label2.TabIndex = 1111179;
            this.label2.Text = "Quantity";
            // 
            // grdStockRequest
            // 
            this.grdStockRequest.AllowUserToAddRows = false;
            this.grdStockRequest.AllowUserToDeleteRows = false;
            this.grdStockRequest.AllowUserToResizeColumns = false;
            this.grdStockRequest.AllowUserToResizeRows = false;
            this.grdStockRequest.BackgroundColor = System.Drawing.Color.White;
            this.grdStockRequest.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(242)))), ((int)(((byte)(213)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdStockRequest.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.grdStockRequest.ColumnHeadersHeight = 30;
            this.grdStockRequest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdStockRequest.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.clmPICode,
            this.clmProductnameInEnglish,
            this.clmRackGroup,
            this.clmRack,
            this.clmIncharge,
            this.clmRequiredQty,
            this.clmUnit,
            this.clmRemove});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdStockRequest.DefaultCellStyle = dataGridViewCellStyle5;
            this.grdStockRequest.EnableHeadersVisualStyles = false;
            this.grdStockRequest.GridColor = System.Drawing.Color.White;
            this.grdStockRequest.Location = new System.Drawing.Point(10, 68);
            this.grdStockRequest.Name = "grdStockRequest";
            this.grdStockRequest.ReadOnly = true;
            this.grdStockRequest.RowHeadersVisible = false;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            this.grdStockRequest.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.grdStockRequest.RowTemplate.Height = 25;
            this.grdStockRequest.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdStockRequest.Size = new System.Drawing.Size(1310, 555);
            this.grdStockRequest.TabIndex = 1111167;
            // 
            // txtProductNamePICode
            // 
            this.txtProductNamePICode.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductNamePICode.Location = new System.Drawing.Point(10, 35);
            this.txtProductNamePICode.MaxLength = 50;
            this.txtProductNamePICode.Name = "txtProductNamePICode";
            this.txtProductNamePICode.Size = new System.Drawing.Size(356, 27);
            this.txtProductNamePICode.TabIndex = 1111160;
            // 
            // lblDEProductName
            // 
            this.lblDEProductName.AutoSize = true;
            this.lblDEProductName.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDEProductName.Location = new System.Drawing.Point(10, 14);
            this.lblDEProductName.Name = "lblDEProductName";
            this.lblDEProductName.Size = new System.Drawing.Size(134, 20);
            this.lblDEProductName.TabIndex = 1111161;
            this.lblDEProductName.Text = "Product Name/P.I Code";
            // 
            // textBox4
            // 
            this.textBox4.Font = new System.Drawing.Font("Rupee Foradian", 12.75F);
            this.textBox4.Location = new System.Drawing.Point(373, 35);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(17, 27);
            this.textBox4.TabIndex = 1111238;
            this.textBox4.Text = "₹";
            // 
            // txtMrp
            // 
            this.txtMrp.Enabled = false;
            this.txtMrp.Location = new System.Drawing.Point(390, 35);
            this.txtMrp.Name = "txtMrp";
            this.txtMrp.ReadOnly = true;
            this.txtMrp.Size = new System.Drawing.Size(75, 27);
            this.txtMrp.TabIndex = 1111237;
            // 
            // txtunitrate
            // 
            this.txtunitrate.Enabled = false;
            this.txtunitrate.Location = new System.Drawing.Point(590, 35);
            this.txtunitrate.Name = "txtunitrate";
            this.txtunitrate.ReadOnly = true;
            this.txtunitrate.Size = new System.Drawing.Size(115, 27);
            this.txtunitrate.TabIndex = 1111240;
            // 
            // lblbatchno
            // 
            this.lblbatchno.AutoSize = true;
            this.lblbatchno.Location = new System.Drawing.Point(590, 14);
            this.lblbatchno.Name = "lblbatchno";
            this.lblbatchno.Size = new System.Drawing.Size(61, 20);
            this.lblbatchno.TabIndex = 1111241;
            this.lblbatchno.Text = "Batch No.";
            // 
            // lblMrp
            // 
            this.lblMrp.AutoSize = true;
            this.lblMrp.Location = new System.Drawing.Point(373, 14);
            this.lblMrp.Name = "lblMrp";
            this.lblMrp.Size = new System.Drawing.Size(34, 20);
            this.lblMrp.TabIndex = 1111239;
            this.lblMrp.Text = "MRP";
            // 
            // txtExpiryDate
            // 
            this.txtExpiryDate.Enabled = false;
            this.txtExpiryDate.Location = new System.Drawing.Point(470, 35);
            this.txtExpiryDate.Name = "txtExpiryDate";
            this.txtExpiryDate.ReadOnly = true;
            this.txtExpiryDate.Size = new System.Drawing.Size(115, 27);
            this.txtExpiryDate.TabIndex = 1111242;
            // 
            // lblExpiryDate
            // 
            this.lblExpiryDate.AutoSize = true;
            this.lblExpiryDate.Location = new System.Drawing.Point(470, 14);
            this.lblExpiryDate.Name = "lblExpiryDate";
            this.lblExpiryDate.Size = new System.Drawing.Size(70, 20);
            this.lblExpiryDate.TabIndex = 1111243;
            this.lblExpiryDate.Text = "Expiry Date";
            // 
            // txtunit
            // 
            this.txtunit.Enabled = false;
            this.txtunit.Location = new System.Drawing.Point(779, 35);
            this.txtunit.Name = "txtunit";
            this.txtunit.ReadOnly = true;
            this.txtunit.Size = new System.Drawing.Size(31, 27);
            this.txtunit.TabIndex = 1111244;
            this.txtunit.Text = "Pkts";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "S.No.";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 50;
            // 
            // clmPICode
            // 
            this.clmPICode.HeaderText = "P.I Code";
            this.clmPICode.Name = "clmPICode";
            this.clmPICode.ReadOnly = true;
            // 
            // clmProductnameInEnglish
            // 
            this.clmProductnameInEnglish.HeaderText = "Product Name";
            this.clmProductnameInEnglish.Name = "clmProductnameInEnglish";
            this.clmProductnameInEnglish.ReadOnly = true;
            this.clmProductnameInEnglish.Width = 400;
            // 
            // clmRackGroup
            // 
            this.clmRackGroup.HeaderText = "MRP";
            this.clmRackGroup.Name = "clmRackGroup";
            this.clmRackGroup.ReadOnly = true;
            // 
            // clmRack
            // 
            this.clmRack.HeaderText = "Expiry Date";
            this.clmRack.Name = "clmRack";
            this.clmRack.ReadOnly = true;
            // 
            // clmIncharge
            // 
            this.clmIncharge.HeaderText = "Batch No.";
            this.clmIncharge.Name = "clmIncharge";
            this.clmIncharge.ReadOnly = true;
            this.clmIncharge.Width = 150;
            // 
            // clmRequiredQty
            // 
            this.clmRequiredQty.HeaderText = "Quantity";
            this.clmRequiredQty.Name = "clmRequiredQty";
            this.clmRequiredQty.ReadOnly = true;
            // 
            // clmUnit
            // 
            this.clmUnit.HeaderText = "Unit";
            this.clmUnit.Name = "clmUnit";
            this.clmUnit.ReadOnly = true;
            // 
            // clmRemove
            // 
            this.clmRemove.HeaderText = "Remove";
            this.clmRemove.Name = "clmRemove";
            this.clmRemove.ReadOnly = true;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnUpdate.Image = global::ROMS.Properties.Resources.save;
            this.btnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdate.Location = new System.Drawing.Point(816, 34);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(66, 29);
            this.btnUpdate.TabIndex = 1111245;
            this.btnUpdate.Text = "Save";
            this.btnUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpdate.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtProductName);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(888, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(432, 53);
            this.groupBox2.TabIndex = 1111246;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Search By";
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(145, 18);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(275, 27);
            this.txtProductName.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "Product Name/P.I Code";
            // 
            // INV_StockHold
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(1354, 675);
            this.Controls.Add(this.pnlStockRequest);
            this.Controls.Add(this.lblNoRecordsFound);
            this.Controls.Add(this.tsStockRequest);
            this.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "INV_StockHold";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stock Request";
            this.tsStockRequest.ResumeLayout(false);
            this.tsStockRequest.PerformLayout();
            this.pnlStockRequest.ResumeLayout(false);
            this.grpStockRequest.ResumeLayout(false);
            this.grpStockRequest.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdStockRequest)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsStockRequest;
        private System.Windows.Forms.ToolStripLabel tspStockRequest;
        private System.Windows.Forms.Label lblNoRecordsFound;
        private System.Windows.Forms.Panel pnlStockRequest;
        private System.Windows.Forms.GroupBox grpStockRequest;
        private System.Windows.Forms.TextBox txtProductNamePICode;
        private System.Windows.Forms.Label lblDEProductName;
        public System.Windows.Forms.DataGridView grdStockRequest;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox txtMrp;
        private System.Windows.Forms.TextBox txtunitrate;
        private System.Windows.Forms.Label lblbatchno;
        private System.Windows.Forms.Label lblMrp;
        private System.Windows.Forms.TextBox txtExpiryDate;
        private System.Windows.Forms.Label lblExpiryDate;
        private System.Windows.Forms.TextBox txtunit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPICode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmProductnameInEnglish;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmRackGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmRack;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmIncharge;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmRequiredQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmUnit;
        private System.Windows.Forms.DataGridViewButtonColumn clmRemove;
        public System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Label label1;
    }
}