namespace ROMS
{
    partial class INV_StockRequest
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
            this.dpDate = new System.Windows.Forms.DateTimePicker();
            this.lblDate = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblRemarks = new System.Windows.Forms.Label();
            this.grdStockRequest = new System.Windows.Forms.DataGridView();
            this.txtRequiredQty = new System.Windows.Forms.TextBox();
            this.lblRequiredQty = new System.Windows.Forms.Label();
            this.txtProductNamePICode = new System.Windows.Forms.TextBox();
            this.lblDEProductName = new System.Windows.Forms.Label();
            this.txtRequestNo = new System.Windows.Forms.TextBox();
            this.lblRequestNo = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPICode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmProductnameInEnglish = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmRequiredQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmRemove = new System.Windows.Forms.DataGridViewButtonColumn();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Label();
            this.tsStockRequest.SuspendLayout();
            this.pnlStockRequest.SuspendLayout();
            this.grpStockRequest.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdStockRequest)).BeginInit();
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
            this.tspStockRequest.Size = new System.Drawing.Size(103, 22);
            this.tspStockRequest.Text = "Stock Request";
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
            this.grpStockRequest.Controls.Add(this.label1);
            this.grpStockRequest.Controls.Add(this.btnAdd);
            this.grpStockRequest.Controls.Add(this.textBox2);
            this.grpStockRequest.Controls.Add(this.label2);
            this.grpStockRequest.Controls.Add(this.dpDate);
            this.grpStockRequest.Controls.Add(this.lblDate);
            this.grpStockRequest.Controls.Add(this.textBox1);
            this.grpStockRequest.Controls.Add(this.lblRemarks);
            this.grpStockRequest.Controls.Add(this.grdStockRequest);
            this.grpStockRequest.Controls.Add(this.txtRequiredQty);
            this.grpStockRequest.Controls.Add(this.lblRequiredQty);
            this.grpStockRequest.Controls.Add(this.txtProductNamePICode);
            this.grpStockRequest.Controls.Add(this.lblDEProductName);
            this.grpStockRequest.Controls.Add(this.txtRequestNo);
            this.grpStockRequest.Controls.Add(this.lblRequestNo);
            this.grpStockRequest.Controls.Add(this.btnClose);
            this.grpStockRequest.Controls.Add(this.btnSave);
            this.grpStockRequest.Location = new System.Drawing.Point(12, 3);
            this.grpStockRequest.Name = "grpStockRequest";
            this.grpStockRequest.Size = new System.Drawing.Size(1329, 634);
            this.grpStockRequest.TabIndex = 958765;
            this.grpStockRequest.TabStop = false;
            // 
            // dpDate
            // 
            this.dpDate.CustomFormat = "dd/MM/yyyy";
            this.dpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpDate.Location = new System.Drawing.Point(148, 16);
            this.dpDate.Name = "dpDate";
            this.dpDate.Size = new System.Drawing.Size(107, 27);
            this.dpDate.TabIndex = 1111177;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(6, 19);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(82, 20);
            this.lblDate.TabIndex = 1111176;
            this.lblDate.Text = "Request Date";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(72, 577);
            this.textBox1.MaxLength = 50;
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(618, 42);
            this.textBox1.TabIndex = 1111169;
            // 
            // lblRemarks
            // 
            this.lblRemarks.AutoSize = true;
            this.lblRemarks.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemarks.Location = new System.Drawing.Point(10, 576);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Size = new System.Drawing.Size(56, 20);
            this.lblRemarks.TabIndex = 1111168;
            this.lblRemarks.Text = "Remarks";
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
            this.grdStockRequest.Location = new System.Drawing.Point(10, 93);
            this.grdStockRequest.Name = "grdStockRequest";
            this.grdStockRequest.ReadOnly = true;
            this.grdStockRequest.RowHeadersVisible = false;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            this.grdStockRequest.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.grdStockRequest.RowTemplate.Height = 25;
            this.grdStockRequest.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdStockRequest.Size = new System.Drawing.Size(1305, 476);
            this.grdStockRequest.TabIndex = 1111167;
            // 
            // txtRequiredQty
            // 
            this.txtRequiredQty.Enabled = false;
            this.txtRequiredQty.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRequiredQty.Location = new System.Drawing.Point(562, 56);
            this.txtRequiredQty.MaxLength = 50;
            this.txtRequiredQty.Name = "txtRequiredQty";
            this.txtRequiredQty.ReadOnly = true;
            this.txtRequiredQty.Size = new System.Drawing.Size(124, 27);
            this.txtRequiredQty.TabIndex = 1111165;
            this.txtRequiredQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblRequiredQty
            // 
            this.lblRequiredQty.AutoSize = true;
            this.lblRequiredQty.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRequiredQty.Location = new System.Drawing.Point(518, 59);
            this.lblRequiredQty.Name = "lblRequiredQty";
            this.lblRequiredQty.Size = new System.Drawing.Size(39, 20);
            this.lblRequiredQty.TabIndex = 1111164;
            this.lblRequiredQty.Text = "Stock";
            // 
            // txtProductNamePICode
            // 
            this.txtProductNamePICode.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductNamePICode.Location = new System.Drawing.Point(148, 56);
            this.txtProductNamePICode.MaxLength = 50;
            this.txtProductNamePICode.Name = "txtProductNamePICode";
            this.txtProductNamePICode.Size = new System.Drawing.Size(356, 27);
            this.txtProductNamePICode.TabIndex = 1111160;
            // 
            // lblDEProductName
            // 
            this.lblDEProductName.AutoSize = true;
            this.lblDEProductName.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDEProductName.Location = new System.Drawing.Point(6, 59);
            this.lblDEProductName.Name = "lblDEProductName";
            this.lblDEProductName.Size = new System.Drawing.Size(134, 20);
            this.lblDEProductName.TabIndex = 1111161;
            this.lblDEProductName.Text = "Product Name/P.I Code";
            // 
            // txtRequestNo
            // 
            this.txtRequestNo.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRequestNo.Location = new System.Drawing.Point(370, 16);
            this.txtRequestNo.MaxLength = 50;
            this.txtRequestNo.Name = "txtRequestNo";
            this.txtRequestNo.ReadOnly = true;
            this.txtRequestNo.Size = new System.Drawing.Size(134, 27);
            this.txtRequestNo.TabIndex = 1111159;
            // 
            // lblRequestNo
            // 
            this.lblRequestNo.AutoSize = true;
            this.lblRequestNo.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRequestNo.Location = new System.Drawing.Point(294, 19);
            this.lblRequestNo.Name = "lblRequestNo";
            this.lblRequestNo.Size = new System.Drawing.Size(74, 20);
            this.lblRequestNo.TabIndex = 1111158;
            this.lblRequestNo.Text = "Request No.";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnClose.Image = global::ROMS.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(1234, 574);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 29);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnSave.Image = global::ROMS.Properties.Resources.save;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(1141, 574);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(84, 29);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
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
            // clmRequiredQty
            // 
            this.clmRequiredQty.HeaderText = "Required Qty";
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
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(795, 56);
            this.textBox2.MaxLength = 50;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(124, 27);
            this.textBox2.TabIndex = 1111180;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(709, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 20);
            this.label2.TabIndex = 1111179;
            this.label2.Text = "Required Qty";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(925, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 20);
            this.label1.TabIndex = 1111182;
            this.label1.Text = "Pkts";
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.SystemColors.Control;
            this.btnAdd.Image = global::ROMS.Properties.Resources.plus;
            this.btnAdd.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAdd.Location = new System.Drawing.Point(959, 59);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(21, 22);
            this.btnAdd.TabIndex = 1111181;
            this.btnAdd.Text = "        ";
            // 
            // INV_StockRequest
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
            this.Name = "INV_StockRequest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stock Request";
            this.Load += new System.EventHandler(this.CP_BrandList_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CP_BrandList_KeyDown);
            this.tsStockRequest.ResumeLayout(false);
            this.tsStockRequest.PerformLayout();
            this.pnlStockRequest.ResumeLayout(false);
            this.grpStockRequest.ResumeLayout(false);
            this.grpStockRequest.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdStockRequest)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsStockRequest;
        private System.Windows.Forms.ToolStripLabel tspStockRequest;
        private System.Windows.Forms.Label lblNoRecordsFound;
        private System.Windows.Forms.Panel pnlStockRequest;
        private System.Windows.Forms.GroupBox grpStockRequest;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblRequestNo;
        private System.Windows.Forms.TextBox txtRequestNo;
        private System.Windows.Forms.TextBox txtProductNamePICode;
        private System.Windows.Forms.Label lblDEProductName;
        private System.Windows.Forms.TextBox txtRequiredQty;
        private System.Windows.Forms.Label lblRequiredQty;
        public System.Windows.Forms.DataGridView grdStockRequest;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblRemarks;
        private System.Windows.Forms.DateTimePicker dpDate;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPICode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmProductnameInEnglish;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmRequiredQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmUnit;
        private System.Windows.Forms.DataGridViewButtonColumn clmRemove;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label btnAdd;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
    }
}