namespace ROMS
{
    partial class INV_StockTransfer
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(INV_StockTransfer));
            this.errStockTransfer = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.grbStockTransfer = new System.Windows.Forms.GroupBox();
            this.lblDestinationGodown = new System.Windows.Forms.Label();
            this.cmbDestinationGodown = new System.Windows.Forms.ComboBox();
            this.lblSourceGodown = new System.Windows.Forms.Label();
            this.cmbSourceGodown = new System.Windows.Forms.ComboBox();
            this.txtTransferNo = new System.Windows.Forms.TextBox();
            this.lblTransferNo = new System.Windows.Forms.Label();
            this.lblTransferDate = new System.Windows.Forms.Label();
            this.dpTrannsferDate = new System.Windows.Forms.DateTimePicker();
            this.grbDStockTransfer = new System.Windows.Forms.GroupBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.lblStock = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.lblBatchNo = new System.Windows.Forms.Label();
            this.lblMRP = new System.Windows.Forms.Label();
            this.txtProductNamePICode = new System.Windows.Forms.TextBox();
            this.lblProductNamePICode = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.dgvStockTransfer = new System.Windows.Forms.DataGridView();
            this.clmdsno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPicode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmproductname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmmrp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmbatchno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmquantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmRemove = new System.Windows.Forms.DataGridViewButtonColumn();
            this.lblRemarks = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errStockTransfer)).BeginInit();
            this.grbStockTransfer.SuspendLayout();
            this.grbDStockTransfer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockTransfer)).BeginInit();
            this.SuspendLayout();
            // 
            // errStockTransfer
            // 
            this.errStockTransfer.ContainerControl = this;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnSave.Image = global::ROMS.Properties.Resources.save;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(949, 611);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(84, 29);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.Enter += new System.EventHandler(this.btnSave_Enter);
            this.btnSave.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnSave_KeyDown);
            this.btnSave.Leave += new System.EventHandler(this.btnSave_Leave);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnClose.Image = global::ROMS.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(1041, 611);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 29);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            this.btnClose.Enter += new System.EventHandler(this.btnClose_Enter);
            this.btnClose.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnClose_KeyDown);
            this.btnClose.Leave += new System.EventHandler(this.btnClose_Leave);
            // 
            // grbStockTransfer
            // 
            this.grbStockTransfer.Controls.Add(this.lblDestinationGodown);
            this.grbStockTransfer.Controls.Add(this.cmbDestinationGodown);
            this.grbStockTransfer.Controls.Add(this.lblSourceGodown);
            this.grbStockTransfer.Controls.Add(this.cmbSourceGodown);
            this.grbStockTransfer.Controls.Add(this.txtTransferNo);
            this.grbStockTransfer.Controls.Add(this.lblTransferNo);
            this.grbStockTransfer.Controls.Add(this.lblTransferDate);
            this.grbStockTransfer.Controls.Add(this.dpTrannsferDate);
            this.grbStockTransfer.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbStockTransfer.Location = new System.Drawing.Point(12, 3);
            this.grbStockTransfer.Name = "grbStockTransfer";
            this.grbStockTransfer.Size = new System.Drawing.Size(1104, 74);
            this.grbStockTransfer.TabIndex = 1;
            this.grbStockTransfer.TabStop = false;
            this.grbStockTransfer.Enter += new System.EventHandler(this.GrbGodown_Enter);
            // 
            // lblDestinationGodown
            // 
            this.lblDestinationGodown.AutoSize = true;
            this.lblDestinationGodown.Location = new System.Drawing.Point(444, 17);
            this.lblDestinationGodown.Name = "lblDestinationGodown";
            this.lblDestinationGodown.Size = new System.Drawing.Size(71, 20);
            this.lblDestinationGodown.TabIndex = 90;
            this.lblDestinationGodown.Text = "Destination";
            // 
            // cmbDestinationGodown
            // 
            this.cmbDestinationGodown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDestinationGodown.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDestinationGodown.FormattingEnabled = true;
            this.cmbDestinationGodown.Location = new System.Drawing.Point(444, 41);
            this.cmbDestinationGodown.Name = "cmbDestinationGodown";
            this.cmbDestinationGodown.Size = new System.Drawing.Size(161, 27);
            this.cmbDestinationGodown.TabIndex = 89;
            // 
            // lblSourceGodown
            // 
            this.lblSourceGodown.AutoSize = true;
            this.lblSourceGodown.Location = new System.Drawing.Point(318, 17);
            this.lblSourceGodown.Name = "lblSourceGodown";
            this.lblSourceGodown.Size = new System.Drawing.Size(46, 20);
            this.lblSourceGodown.TabIndex = 86;
            this.lblSourceGodown.Text = "Source";
            // 
            // cmbSourceGodown
            // 
            this.cmbSourceGodown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSourceGodown.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSourceGodown.FormattingEnabled = true;
            this.cmbSourceGodown.Location = new System.Drawing.Point(318, 41);
            this.cmbSourceGodown.Name = "cmbSourceGodown";
            this.cmbSourceGodown.Size = new System.Drawing.Size(114, 27);
            this.cmbSourceGodown.TabIndex = 85;
            // 
            // txtTransferNo
            // 
            this.txtTransferNo.Enabled = false;
            this.txtTransferNo.Location = new System.Drawing.Point(138, 40);
            this.txtTransferNo.Name = "txtTransferNo";
            this.txtTransferNo.ReadOnly = true;
            this.txtTransferNo.Size = new System.Drawing.Size(158, 28);
            this.txtTransferNo.TabIndex = 84;
            // 
            // lblTransferNo
            // 
            this.lblTransferNo.AutoSize = true;
            this.lblTransferNo.Location = new System.Drawing.Point(138, 17);
            this.lblTransferNo.Name = "lblTransferNo";
            this.lblTransferNo.Size = new System.Drawing.Size(74, 20);
            this.lblTransferNo.TabIndex = 78;
            this.lblTransferNo.Text = "Transfer No.";
            // 
            // lblTransferDate
            // 
            this.lblTransferDate.AutoSize = true;
            this.lblTransferDate.Location = new System.Drawing.Point(10, 17);
            this.lblTransferDate.Name = "lblTransferDate";
            this.lblTransferDate.Size = new System.Drawing.Size(82, 20);
            this.lblTransferDate.TabIndex = 72;
            this.lblTransferDate.Text = "Transfer Date";
            // 
            // dpTrannsferDate
            // 
            this.dpTrannsferDate.CustomFormat = "dd/MM/yyyy";
            this.dpTrannsferDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpTrannsferDate.Location = new System.Drawing.Point(10, 40);
            this.dpTrannsferDate.Name = "dpTrannsferDate";
            this.dpTrannsferDate.Size = new System.Drawing.Size(122, 28);
            this.dpTrannsferDate.TabIndex = 77;
            // 
            // grbDStockTransfer
            // 
            this.grbDStockTransfer.Controls.Add(this.label2);
            this.grbDStockTransfer.Controls.Add(this.textBox4);
            this.grbDStockTransfer.Controls.Add(this.textBox3);
            this.grbDStockTransfer.Controls.Add(this.label1);
            this.grbDStockTransfer.Controls.Add(this.textBox1);
            this.grbDStockTransfer.Controls.Add(this.textBox2);
            this.grbDStockTransfer.Controls.Add(this.lblStock);
            this.grbDStockTransfer.Controls.Add(this.btnAdd);
            this.grbDStockTransfer.Controls.Add(this.txtQuantity);
            this.grbDStockTransfer.Controls.Add(this.lblQuantity);
            this.grbDStockTransfer.Controls.Add(this.lblBatchNo);
            this.grbDStockTransfer.Controls.Add(this.lblMRP);
            this.grbDStockTransfer.Controls.Add(this.txtProductNamePICode);
            this.grbDStockTransfer.Controls.Add(this.lblProductNamePICode);
            this.grbDStockTransfer.Controls.Add(this.label4);
            this.grbDStockTransfer.Location = new System.Drawing.Point(12, 74);
            this.grbDStockTransfer.Name = "grbDStockTransfer";
            this.grbDStockTransfer.Size = new System.Drawing.Size(1104, 76);
            this.grbDStockTransfer.TabIndex = 22;
            this.grbDStockTransfer.TabStop = false;
            // 
            // textBox4
            // 
            this.textBox4.Enabled = false;
            this.textBox4.Location = new System.Drawing.Point(771, 40);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(104, 27);
            this.textBox4.TabIndex = 958818;
            // 
            // textBox3
            // 
            this.textBox3.Enabled = false;
            this.textBox3.Location = new System.Drawing.Point(611, 40);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(154, 27);
            this.textBox3.TabIndex = 958815;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(771, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 20);
            this.label1.TabIndex = 958817;
            this.label1.Text = "Stock Quantity";
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(318, 40);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(114, 27);
            this.textBox1.TabIndex = 958813;
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(444, 40);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(161, 27);
            this.textBox2.TabIndex = 958814;
            // 
            // lblStock
            // 
            this.lblStock.AutoSize = true;
            this.lblStock.Location = new System.Drawing.Point(444, 16);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(70, 20);
            this.lblStock.TabIndex = 958822;
            this.lblStock.Text = "Expiry Date";
            // 
            // btnAdd
            // 
            this.btnAdd.Image = global::ROMS.Properties.Resources.plus;
            this.btnAdd.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAdd.Location = new System.Drawing.Point(1021, 42);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(21, 22);
            this.btnAdd.TabIndex = 958818;
            this.btnAdd.Text = "        ";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(881, 40);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(95, 27);
            this.txtQuantity.TabIndex = 958817;
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(881, 15);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(104, 20);
            this.lblQuantity.TabIndex = 958816;
            this.lblQuantity.Text = "Transfer Quantity";
            // 
            // lblBatchNo
            // 
            this.lblBatchNo.AutoSize = true;
            this.lblBatchNo.Location = new System.Drawing.Point(611, 14);
            this.lblBatchNo.Name = "lblBatchNo";
            this.lblBatchNo.Size = new System.Drawing.Size(61, 20);
            this.lblBatchNo.TabIndex = 958815;
            this.lblBatchNo.Text = "Batch No.";
            // 
            // lblMRP
            // 
            this.lblMRP.AutoSize = true;
            this.lblMRP.Location = new System.Drawing.Point(318, 15);
            this.lblMRP.Name = "lblMRP";
            this.lblMRP.Size = new System.Drawing.Size(34, 20);
            this.lblMRP.TabIndex = 958813;
            this.lblMRP.Text = "MRP";
            // 
            // txtProductNamePICode
            // 
            this.txtProductNamePICode.Location = new System.Drawing.Point(9, 40);
            this.txtProductNamePICode.Name = "txtProductNamePICode";
            this.txtProductNamePICode.Size = new System.Drawing.Size(287, 27);
            this.txtProductNamePICode.TabIndex = 958810;
            // 
            // lblProductNamePICode
            // 
            this.lblProductNamePICode.AutoSize = true;
            this.lblProductNamePICode.Location = new System.Drawing.Point(9, 15);
            this.lblProductNamePICode.Name = "lblProductNamePICode";
            this.lblProductNamePICode.Size = new System.Drawing.Size(134, 20);
            this.lblProductNamePICode.TabIndex = 958809;
            this.lblProductNamePICode.Text = "Product Name/P.I Code";
            // 
            // dgvStockTransfer
            // 
            this.dgvStockTransfer.AllowUserToAddRows = false;
            this.dgvStockTransfer.AllowUserToDeleteRows = false;
            this.dgvStockTransfer.AllowUserToResizeRows = false;
            this.dgvStockTransfer.BackgroundColor = System.Drawing.Color.White;
            this.dgvStockTransfer.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(242)))), ((int)(((byte)(213)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvStockTransfer.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvStockTransfer.ColumnHeadersHeight = 30;
            this.dgvStockTransfer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvStockTransfer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmdsno,
            this.clmPicode,
            this.clmproductname,
            this.clmmrp,
            this.Column1,
            this.clmbatchno,
            this.clmquantity,
            this.clmRemove});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvStockTransfer.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvStockTransfer.EnableHeadersVisualStyles = false;
            this.dgvStockTransfer.GridColor = System.Drawing.Color.White;
            this.dgvStockTransfer.Location = new System.Drawing.Point(12, 167);
            this.dgvStockTransfer.Name = "dgvStockTransfer";
            this.dgvStockTransfer.RowHeadersVisible = false;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvStockTransfer.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvStockTransfer.RowTemplate.Height = 25;
            this.dgvStockTransfer.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvStockTransfer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvStockTransfer.ShowRowErrors = false;
            this.dgvStockTransfer.Size = new System.Drawing.Size(1104, 423);
            this.dgvStockTransfer.TabIndex = 958810;
            // 
            // clmdsno
            // 
            this.clmdsno.HeaderText = "S.No.";
            this.clmdsno.Name = "clmdsno";
            // 
            // clmPicode
            // 
            this.clmPicode.HeaderText = "P.I Code";
            this.clmPicode.Name = "clmPicode";
            // 
            // clmproductname
            // 
            this.clmproductname.HeaderText = "Product Name";
            this.clmproductname.Name = "clmproductname";
            this.clmproductname.Width = 300;
            // 
            // clmmrp
            // 
            this.clmmrp.HeaderText = "MRP";
            this.clmmrp.Name = "clmmrp";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Expiry Date";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // clmbatchno
            // 
            this.clmbatchno.HeaderText = "Batch No.";
            this.clmbatchno.Name = "clmbatchno";
            // 
            // clmquantity
            // 
            this.clmquantity.HeaderText = "Quantity";
            this.clmquantity.Name = "clmquantity";
            // 
            // clmRemove
            // 
            this.clmRemove.HeaderText = "Remove";
            this.clmRemove.Name = "clmRemove";
            // 
            // lblRemarks
            // 
            this.lblRemarks.AutoSize = true;
            this.lblRemarks.Location = new System.Drawing.Point(12, 609);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Size = new System.Drawing.Size(56, 20);
            this.lblRemarks.TabIndex = 958811;
            this.lblRemarks.Text = "Remarks";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(76, 599);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(472, 41);
            this.txtRemarks.TabIndex = 958812;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(982, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 20);
            this.label2.TabIndex = 958817;
            this.label2.Text = "Pkts";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(301, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 20);
            this.label4.TabIndex = 1111187;
            this.label4.Text = "₹";
            // 
            // INV_StockTransfer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1128, 654);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.lblRemarks);
            this.Controls.Add(this.dgvStockTransfer);
            this.Controls.Add(this.grbStockTransfer);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.grbDStockTransfer);
            this.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "INV_StockTransfer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stock Transfer";
            this.Load += new System.EventHandler(this.CP_Location_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CP_Location_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.errStockTransfer)).EndInit();
            this.grbStockTransfer.ResumeLayout(false);
            this.grbStockTransfer.PerformLayout();
            this.grbDStockTransfer.ResumeLayout(false);
            this.grbDStockTransfer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockTransfer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ErrorProvider errStockTransfer;
        private System.Windows.Forms.GroupBox grbStockTransfer;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DateTimePicker dpTrannsferDate;
        private System.Windows.Forms.TextBox txtTransferNo;
        private System.Windows.Forms.Label lblTransferDate;
        private System.Windows.Forms.Label lblTransferNo;
        private System.Windows.Forms.Label lblDestinationGodown;
        private System.Windows.Forms.ComboBox cmbDestinationGodown;
        private System.Windows.Forms.Label lblSourceGodown;
        private System.Windows.Forms.ComboBox cmbSourceGodown;
        private System.Windows.Forms.GroupBox grbDStockTransfer;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TextBox txtProductNamePICode;
        private System.Windows.Forms.Label lblProductNamePICode;
        private System.Windows.Forms.Label lblMRP;
        private System.Windows.Forms.Label lblBatchNo;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Label lblQuantity;
        internal System.Windows.Forms.Label btnAdd;
        public System.Windows.Forms.DataGridView dgvStockTransfer;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label lblRemarks;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmdsno;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPicode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmproductname;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmmrp;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmbatchno;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmquantity;
        private System.Windows.Forms.DataGridViewButtonColumn clmRemove;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
    }
}