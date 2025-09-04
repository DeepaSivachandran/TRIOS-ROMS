namespace ROMS
{
    partial class PAY_ChequeTransaction
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PAY_ChequeTransaction));
            this.txtDSupplierName = new System.Windows.Forms.TextBox();
            this.txtSupplier = new System.Windows.Forms.TextBox();
            this.txtDPaymentNo = new System.Windows.Forms.TextBox();
            this.txtPaymentNo = new System.Windows.Forms.TextBox();
            this.txtDAmount = new System.Windows.Forms.TextBox();
            this.grbform = new System.Windows.Forms.GroupBox();
            this.txtChequeLimitDays = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.dpChequeDate = new System.Windows.Forms.DateTimePicker();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.txtChequeNo = new System.Windows.Forms.TextBox();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.epHsn = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtReason = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.lblNoRecordsFound = new System.Windows.Forms.Label();
            this.grdInvoiceDetails = new System.Windows.Forms.DataGridView();
            this.grbform.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epHsn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdInvoiceDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDSupplierName
            // 
            this.txtDSupplierName.BackColor = System.Drawing.SystemColors.Control;
            this.txtDSupplierName.Enabled = false;
            this.txtDSupplierName.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtDSupplierName.Location = new System.Drawing.Point(23, 23);
            this.txtDSupplierName.Name = "txtDSupplierName";
            this.txtDSupplierName.ReadOnly = true;
            this.txtDSupplierName.Size = new System.Drawing.Size(111, 27);
            this.txtDSupplierName.TabIndex = 14;
            this.txtDSupplierName.Text = "Supplier";
            // 
            // txtSupplier
            // 
            this.txtSupplier.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSupplier.Enabled = false;
            this.txtSupplier.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtSupplier.Location = new System.Drawing.Point(134, 23);
            this.txtSupplier.MaxLength = 20;
            this.txtSupplier.Name = "txtSupplier";
            this.txtSupplier.ReadOnly = true;
            this.txtSupplier.Size = new System.Drawing.Size(200, 27);
            this.txtSupplier.TabIndex = 0;
            this.txtSupplier.Enter += new System.EventHandler(this.TxtHSNName_Enter);
            this.txtSupplier.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtHSNName_KeyDown);
            this.txtSupplier.Leave += new System.EventHandler(this.TxtHSNName_Leave);
            // 
            // txtDPaymentNo
            // 
            this.txtDPaymentNo.BackColor = System.Drawing.SystemColors.Control;
            this.txtDPaymentNo.Enabled = false;
            this.txtDPaymentNo.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtDPaymentNo.Location = new System.Drawing.Point(23, 50);
            this.txtDPaymentNo.Name = "txtDPaymentNo";
            this.txtDPaymentNo.ReadOnly = true;
            this.txtDPaymentNo.Size = new System.Drawing.Size(111, 27);
            this.txtDPaymentNo.TabIndex = 15;
            this.txtDPaymentNo.Text = "Payment No.";
            // 
            // txtPaymentNo
            // 
            this.txtPaymentNo.Enabled = false;
            this.txtPaymentNo.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtPaymentNo.Location = new System.Drawing.Point(134, 50);
            this.txtPaymentNo.MaxLength = 8;
            this.txtPaymentNo.Name = "txtPaymentNo";
            this.txtPaymentNo.ReadOnly = true;
            this.txtPaymentNo.Size = new System.Drawing.Size(200, 27);
            this.txtPaymentNo.TabIndex = 1;
            this.txtPaymentNo.Enter += new System.EventHandler(this.TxtHSNCode_Enter);
            // 
            // txtDAmount
            // 
            this.txtDAmount.BackColor = System.Drawing.SystemColors.Control;
            this.txtDAmount.Enabled = false;
            this.txtDAmount.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtDAmount.Location = new System.Drawing.Point(23, 77);
            this.txtDAmount.Name = "txtDAmount";
            this.txtDAmount.ReadOnly = true;
            this.txtDAmount.Size = new System.Drawing.Size(111, 27);
            this.txtDAmount.TabIndex = 16;
            this.txtDAmount.Text = "Amount";
            // 
            // grbform
            // 
            this.grbform.Controls.Add(this.lblNoRecordsFound);
            this.grbform.Controls.Add(this.grdInvoiceDetails);
            this.grbform.Controls.Add(this.txtReason);
            this.grbform.Controls.Add(this.textBox3);
            this.grbform.Controls.Add(this.txtChequeLimitDays);
            this.grbform.Controls.Add(this.textBox2);
            this.grbform.Controls.Add(this.dpChequeDate);
            this.grbform.Controls.Add(this.textBox5);
            this.grbform.Controls.Add(this.txtChequeNo);
            this.grbform.Controls.Add(this.txtAmount);
            this.grbform.Controls.Add(this.textBox4);
            this.grbform.Controls.Add(this.btnUpdate);
            this.grbform.Controls.Add(this.btnClose);
            this.grbform.Controls.Add(this.txtDSupplierName);
            this.grbform.Controls.Add(this.txtSupplier);
            this.grbform.Controls.Add(this.txtPaymentNo);
            this.grbform.Controls.Add(this.txtDPaymentNo);
            this.grbform.Controls.Add(this.txtDAmount);
            this.grbform.Location = new System.Drawing.Point(12, 12);
            this.grbform.Name = "grbform";
            this.grbform.Size = new System.Drawing.Size(741, 272);
            this.grbform.TabIndex = 0;
            this.grbform.TabStop = false;
            // 
            // txtChequeLimitDays
            // 
            this.txtChequeLimitDays.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtChequeLimitDays.Location = new System.Drawing.Point(134, 131);
            this.txtChequeLimitDays.MaxLength = 10;
            this.txtChequeLimitDays.Name = "txtChequeLimitDays";
            this.txtChequeLimitDays.Size = new System.Drawing.Size(200, 27);
            this.txtChequeLimitDays.TabIndex = 1;
            this.txtChequeLimitDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtChequeLimitDays.TextChanged += new System.EventHandler(this.TxtChequeLimitDays_TextChanged);
            this.txtChequeLimitDays.Enter += new System.EventHandler(this.TxtChequeLimitDays_Enter);
            this.txtChequeLimitDays.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtChequeLimitDays_KeyDown);
            this.txtChequeLimitDays.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtChequeLimitDays_KeyPress);
            this.txtChequeLimitDays.Leave += new System.EventHandler(this.TxtChequeLimitDays_Leave);
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.Control;
            this.textBox2.Enabled = false;
            this.textBox2.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.textBox2.Location = new System.Drawing.Point(23, 131);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(111, 27);
            this.textBox2.TabIndex = 61;
            this.textBox2.Text = "Cheque Limit (Days)";
            // 
            // dpChequeDate
            // 
            this.dpChequeDate.CustomFormat = "dd/MM/yyyy";
            this.dpChequeDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpChequeDate.Location = new System.Drawing.Point(134, 158);
            this.dpChequeDate.Name = "dpChequeDate";
            this.dpChequeDate.Size = new System.Drawing.Size(200, 27);
            this.dpChequeDate.TabIndex = 2;
            this.dpChequeDate.Enter += new System.EventHandler(this.DpChequeDate_Enter);
            this.dpChequeDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DpChequeDate_KeyDown);
            this.dpChequeDate.Leave += new System.EventHandler(this.DpChequeDate_Leave);
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.SystemColors.Control;
            this.textBox5.Enabled = false;
            this.textBox5.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.textBox5.Location = new System.Drawing.Point(23, 158);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(111, 27);
            this.textBox5.TabIndex = 59;
            this.textBox5.Text = "Cheque Date";
            // 
            // txtChequeNo
            // 
            this.txtChequeNo.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtChequeNo.Location = new System.Drawing.Point(134, 104);
            this.txtChequeNo.MaxLength = 10;
            this.txtChequeNo.Name = "txtChequeNo";
            this.txtChequeNo.Size = new System.Drawing.Size(200, 27);
            this.txtChequeNo.TabIndex = 0;
            this.txtChequeNo.Enter += new System.EventHandler(this.TxtChequeNo_Enter);
            this.txtChequeNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtChequeNo_KeyDown);
            this.txtChequeNo.Leave += new System.EventHandler(this.TxtChequeNo_Leave);
            // 
            // txtAmount
            // 
            this.txtAmount.Enabled = false;
            this.txtAmount.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtAmount.Location = new System.Drawing.Point(134, 77);
            this.txtAmount.MaxLength = 8;
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.ReadOnly = true;
            this.txtAmount.Size = new System.Drawing.Size(200, 27);
            this.txtAmount.TabIndex = 57;
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.SystemColors.Control;
            this.textBox4.Enabled = false;
            this.textBox4.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.textBox4.Location = new System.Drawing.Point(23, 104);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(111, 27);
            this.textBox4.TabIndex = 56;
            this.textBox4.Text = "Cheque No.";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnUpdate.Image = global::ROMS.Properties.Resources.save;
            this.btnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdate.Location = new System.Drawing.Point(171, 235);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(84, 29);
            this.btnUpdate.TabIndex = 4;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.BtnSave_Click);
            this.btnUpdate.Enter += new System.EventHandler(this.btnSave_Enter);
            this.btnUpdate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BtnUpdate_KeyDown);
            this.btnUpdate.Leave += new System.EventHandler(this.BtnSave_Leave);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnClose.Image = global::ROMS.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(259, 235);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 29);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            this.btnClose.Enter += new System.EventHandler(this.btnClose_Enter);
            this.btnClose.Leave += new System.EventHandler(this.btnClose_Leave);
            // 
            // epHsn
            // 
            this.epHsn.ContainerControl = this;
            // 
            // txtReason
            // 
            this.txtReason.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtReason.Location = new System.Drawing.Point(134, 185);
            this.txtReason.MaxLength = 100;
            this.txtReason.Multiline = true;
            this.txtReason.Name = "txtReason";
            this.txtReason.Size = new System.Drawing.Size(200, 45);
            this.txtReason.TabIndex = 3;
            this.txtReason.Enter += new System.EventHandler(this.TxtReason_Enter);
            this.txtReason.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtReason_KeyDown);
            this.txtReason.Leave += new System.EventHandler(this.TxtReason_Leave);
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.SystemColors.Control;
            this.textBox3.Enabled = false;
            this.textBox3.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.textBox3.Location = new System.Drawing.Point(23, 185);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(111, 27);
            this.textBox3.TabIndex = 63;
            this.textBox3.Text = "Reason";
            // 
            // lblNoRecordsFound
            // 
            this.lblNoRecordsFound.AutoSize = true;
            this.lblNoRecordsFound.BackColor = System.Drawing.Color.White;
            this.lblNoRecordsFound.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoRecordsFound.Location = new System.Drawing.Point(482, 116);
            this.lblNoRecordsFound.Name = "lblNoRecordsFound";
            this.lblNoRecordsFound.Size = new System.Drawing.Size(106, 20);
            this.lblNoRecordsFound.TabIndex = 958764;
            this.lblNoRecordsFound.Text = "No Records Found";
            this.lblNoRecordsFound.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // grdInvoiceDetails
            // 
            this.grdInvoiceDetails.AllowUserToAddRows = false;
            this.grdInvoiceDetails.AllowUserToDeleteRows = false;
            this.grdInvoiceDetails.AllowUserToResizeColumns = false;
            this.grdInvoiceDetails.AllowUserToResizeRows = false;
            this.grdInvoiceDetails.BackgroundColor = System.Drawing.Color.White;
            this.grdInvoiceDetails.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(242)))), ((int)(((byte)(213)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdInvoiceDetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdInvoiceDetails.ColumnHeadersHeight = 30;
            this.grdInvoiceDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdInvoiceDetails.DefaultCellStyle = dataGridViewCellStyle2;
            this.grdInvoiceDetails.EnableHeadersVisualStyles = false;
            this.grdInvoiceDetails.GridColor = System.Drawing.Color.White;
            this.grdInvoiceDetails.Location = new System.Drawing.Point(344, 23);
            this.grdInvoiceDetails.Name = "grdInvoiceDetails";
            this.grdInvoiceDetails.ReadOnly = true;
            this.grdInvoiceDetails.RowHeadersVisible = false;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.grdInvoiceDetails.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.grdInvoiceDetails.RowTemplate.Height = 25;
            this.grdInvoiceDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdInvoiceDetails.Size = new System.Drawing.Size(383, 207);
            this.grdInvoiceDetails.TabIndex = 958765;
            // 
            // PAY_ChequeTransaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(768, 297);
            this.Controls.Add(this.grbform);
            this.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PAY_ChequeTransaction";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cheque Transaction";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CP_ProductHSN_FormClosing);
            this.Load += new System.EventHandler(this.CP_ProductHSN_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CP_ProductHSN_KeyDown);
            this.Leave += new System.EventHandler(this.CP_ProductHSN_Leave);
            this.grbform.ResumeLayout(false);
            this.grbform.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epHsn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdInvoiceDetails)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtDSupplierName;
        private System.Windows.Forms.TextBox txtDPaymentNo;
        private System.Windows.Forms.TextBox txtDAmount;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox grbform;
        private System.Windows.Forms.ErrorProvider epHsn;
        private System.Windows.Forms.TextBox textBox4;
        public System.Windows.Forms.Button btnUpdate;
        public System.Windows.Forms.TextBox txtSupplier;
        public System.Windows.Forms.TextBox txtPaymentNo;
        public System.Windows.Forms.TextBox txtChequeNo;
        public System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.DateTimePicker dpChequeDate;
        public System.Windows.Forms.TextBox txtChequeLimitDays;
        private System.Windows.Forms.TextBox textBox2;
        public System.Windows.Forms.TextBox txtReason;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label lblNoRecordsFound;
        public System.Windows.Forms.DataGridView grdInvoiceDetails;
    }
}