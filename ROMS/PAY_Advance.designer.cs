namespace ROMS
{
    partial class PAY_Advance
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PAY_Advance));
            this.txtDReceiptN0 = new System.Windows.Forms.TextBox();
            this.grbform = new System.Windows.Forms.GroupBox();
            this.txtReceiptNo = new System.Windows.Forms.TextBox();
            this.txtConcern = new System.Windows.Forms.TextBox();
            this.cmbConcern = new System.Windows.Forms.ComboBox();
            this.lblschedule = new System.Windows.Forms.Label();
            this.lblSupplierCode = new System.Windows.Forms.Label();
            this.LV_Supplier = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtSupplier = new System.Windows.Forms.TextBox();
            this.dpEntryDate = new System.Windows.Forms.DateTimePicker();
            this.dpAdvanceDate = new System.Windows.Forms.DateTimePicker();
            this.txtDEntryDate = new System.Windows.Forms.TextBox();
            this.txtDSupplier = new System.Windows.Forms.TextBox();
            this.txtDAdvanceDate = new System.Windows.Forms.TextBox();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtAdvanceAmt = new System.Windows.Forms.TextBox();
            this.epAdvance = new System.Windows.Forms.ErrorProvider(this.components);
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.cmbPaymentType = new System.Windows.Forms.ComboBox();
            this.txtDPaymentType = new System.Windows.Forms.TextBox();
            this.cmbPaymentmode = new System.Windows.Forms.ComboBox();
            this.txtDPaymentMode = new System.Windows.Forms.TextBox();
            this.txtChequeNo = new System.Windows.Forms.TextBox();
            this.dtChequeDate = new System.Windows.Forms.DateTimePicker();
            this.txtChequeDate = new System.Windows.Forms.TextBox();
            this.txtDChequeNo = new System.Windows.Forms.TextBox();
            this.grbform.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epAdvance)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDReceiptN0
            // 
            this.txtDReceiptN0.BackColor = System.Drawing.SystemColors.Control;
            this.txtDReceiptN0.Enabled = false;
            this.txtDReceiptN0.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDReceiptN0.Location = new System.Drawing.Point(17, 52);
            this.txtDReceiptN0.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtDReceiptN0.Name = "txtDReceiptN0";
            this.txtDReceiptN0.ReadOnly = true;
            this.txtDReceiptN0.Size = new System.Drawing.Size(122, 28);
            this.txtDReceiptN0.TabIndex = 7;
            this.txtDReceiptN0.Text = "Receipt No.";
            // 
            // grbform
            // 
            this.grbform.Controls.Add(this.LV_Supplier);
            this.grbform.Controls.Add(this.cmbPaymentType);
            this.grbform.Controls.Add(this.txtDPaymentType);
            this.grbform.Controls.Add(this.cmbPaymentmode);
            this.grbform.Controls.Add(this.txtDPaymentMode);
            this.grbform.Controls.Add(this.txtChequeNo);
            this.grbform.Controls.Add(this.dtChequeDate);
            this.grbform.Controls.Add(this.txtChequeDate);
            this.grbform.Controls.Add(this.txtDChequeNo);
            this.grbform.Controls.Add(this.txtReceiptNo);
            this.grbform.Controls.Add(this.txtConcern);
            this.grbform.Controls.Add(this.cmbConcern);
            this.grbform.Controls.Add(this.lblschedule);
            this.grbform.Controls.Add(this.lblSupplierCode);
            this.grbform.Controls.Add(this.txtSupplier);
            this.grbform.Controls.Add(this.dpEntryDate);
            this.grbform.Controls.Add(this.dpAdvanceDate);
            this.grbform.Controls.Add(this.txtDEntryDate);
            this.grbform.Controls.Add(this.txtDSupplier);
            this.grbform.Controls.Add(this.txtDAdvanceDate);
            this.grbform.Controls.Add(this.txtAmount);
            this.grbform.Controls.Add(this.btnClose);
            this.grbform.Controls.Add(this.btnSave);
            this.grbform.Controls.Add(this.txtAdvanceAmt);
            this.grbform.Controls.Add(this.txtDReceiptN0);
            this.grbform.Location = new System.Drawing.Point(13, 3);
            this.grbform.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.grbform.Name = "grbform";
            this.grbform.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.grbform.Size = new System.Drawing.Size(718, 243);
            this.grbform.TabIndex = 0;
            this.grbform.TabStop = false;
            // 
            // txtReceiptNo
            // 
            this.txtReceiptNo.Enabled = false;
            this.txtReceiptNo.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReceiptNo.Location = new System.Drawing.Point(139, 52);
            this.txtReceiptNo.MaxLength = 50;
            this.txtReceiptNo.Name = "txtReceiptNo";
            this.txtReceiptNo.ReadOnly = true;
            this.txtReceiptNo.Size = new System.Drawing.Size(107, 27);
            this.txtReceiptNo.TabIndex = 1;
            // 
            // txtConcern
            // 
            this.txtConcern.BackColor = System.Drawing.SystemColors.Control;
            this.txtConcern.Enabled = false;
            this.txtConcern.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConcern.Location = new System.Drawing.Point(17, 24);
            this.txtConcern.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtConcern.Name = "txtConcern";
            this.txtConcern.ReadOnly = true;
            this.txtConcern.Size = new System.Drawing.Size(122, 28);
            this.txtConcern.TabIndex = 1111214;
            this.txtConcern.Text = "Concern";
            // 
            // cmbConcern
            // 
            this.cmbConcern.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbConcern.FormattingEnabled = true;
            this.cmbConcern.Location = new System.Drawing.Point(139, 25);
            this.cmbConcern.Name = "cmbConcern";
            this.cmbConcern.Size = new System.Drawing.Size(107, 27);
            this.cmbConcern.TabIndex = 0;
            this.cmbConcern.SelectedIndexChanged += new System.EventHandler(this.CmbConcern_SelectedIndexChanged);
            this.cmbConcern.Enter += new System.EventHandler(this.CmbConcern_Enter);
            this.cmbConcern.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbConcern_KeyDown);
            this.cmbConcern.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbConcern_KeyPress);
            this.cmbConcern.Leave += new System.EventHandler(this.CmbConcern_Leave);
            // 
            // lblschedule
            // 
            this.lblschedule.AutoSize = true;
            this.lblschedule.Location = new System.Drawing.Point(96, 153);
            this.lblschedule.Name = "lblschedule";
            this.lblschedule.Size = new System.Drawing.Size(16, 20);
            this.lblschedule.TabIndex = 1111211;
            this.lblschedule.Text = "0";
            this.lblschedule.Visible = false;
            // 
            // lblSupplierCode
            // 
            this.lblSupplierCode.AutoSize = true;
            this.lblSupplierCode.Location = new System.Drawing.Point(72, 153);
            this.lblSupplierCode.Name = "lblSupplierCode";
            this.lblSupplierCode.Size = new System.Drawing.Size(16, 20);
            this.lblSupplierCode.TabIndex = 1111210;
            this.lblSupplierCode.Text = "0";
            this.lblSupplierCode.Visible = false;
            // 
            // LV_Supplier
            // 
            this.LV_Supplier.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader8,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader6});
            this.LV_Supplier.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.LV_Supplier.HideSelection = false;
            this.LV_Supplier.Location = new System.Drawing.Point(374, 51);
            this.LV_Supplier.Name = "LV_Supplier";
            this.LV_Supplier.Size = new System.Drawing.Size(329, 93);
            this.LV_Supplier.TabIndex = 1111209;
            this.LV_Supplier.UseCompatibleStateImageBehavior = false;
            this.LV_Supplier.View = System.Windows.Forms.View.Details;
            this.LV_Supplier.Visible = false;
            this.LV_Supplier.DoubleClick += new System.EventHandler(this.LV_Supplier_DoubleClick);
            this.LV_Supplier.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LV_Supplier_KeyDown);
            // 
            // columnHeader5
            // 
            this.columnHeader5.Width = 200;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Width = 10;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 10;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Width = 10;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Width = 10;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Width = 10;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Width = 10;
            // 
            // txtSupplier
            // 
            this.txtSupplier.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSupplier.Location = new System.Drawing.Point(374, 24);
            this.txtSupplier.MaxLength = 150;
            this.txtSupplier.Name = "txtSupplier";
            this.txtSupplier.Size = new System.Drawing.Size(329, 27);
            this.txtSupplier.TabIndex = 4;
            this.txtSupplier.TextChanged += new System.EventHandler(this.TxtSupplier_TextChanged);
            this.txtSupplier.Enter += new System.EventHandler(this.TxtSupplier_Enter);
            this.txtSupplier.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtSupplier_KeyDown);
            this.txtSupplier.Leave += new System.EventHandler(this.TxtSupplier_Leave);
            // 
            // dpEntryDate
            // 
            this.dpEntryDate.CustomFormat = "dd/MM/yyyy";
            this.dpEntryDate.Enabled = false;
            this.dpEntryDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpEntryDate.Location = new System.Drawing.Point(139, 107);
            this.dpEntryDate.Name = "dpEntryDate";
            this.dpEntryDate.Size = new System.Drawing.Size(107, 28);
            this.dpEntryDate.TabIndex = 3;
            // 
            // dpAdvanceDate
            // 
            this.dpAdvanceDate.CustomFormat = "dd/MM/yyyy";
            this.dpAdvanceDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpAdvanceDate.Location = new System.Drawing.Point(139, 79);
            this.dpAdvanceDate.Name = "dpAdvanceDate";
            this.dpAdvanceDate.Size = new System.Drawing.Size(107, 28);
            this.dpAdvanceDate.TabIndex = 2;
            this.dpAdvanceDate.ValueChanged += new System.EventHandler(this.DpAdvanceDate_ValueChanged);
            this.dpAdvanceDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DpAdvanceDate_KeyDown);
            // 
            // txtDEntryDate
            // 
            this.txtDEntryDate.BackColor = System.Drawing.SystemColors.Control;
            this.txtDEntryDate.Enabled = false;
            this.txtDEntryDate.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDEntryDate.Location = new System.Drawing.Point(17, 108);
            this.txtDEntryDate.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtDEntryDate.Name = "txtDEntryDate";
            this.txtDEntryDate.ReadOnly = true;
            this.txtDEntryDate.Size = new System.Drawing.Size(122, 28);
            this.txtDEntryDate.TabIndex = 14;
            this.txtDEntryDate.Text = "Transaction Date";
            // 
            // txtDSupplier
            // 
            this.txtDSupplier.BackColor = System.Drawing.SystemColors.Control;
            this.txtDSupplier.Enabled = false;
            this.txtDSupplier.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDSupplier.Location = new System.Drawing.Point(252, 24);
            this.txtDSupplier.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtDSupplier.Name = "txtDSupplier";
            this.txtDSupplier.ReadOnly = true;
            this.txtDSupplier.Size = new System.Drawing.Size(122, 28);
            this.txtDSupplier.TabIndex = 12;
            this.txtDSupplier.Text = "Supplier Name";
            // 
            // txtDAdvanceDate
            // 
            this.txtDAdvanceDate.BackColor = System.Drawing.SystemColors.Control;
            this.txtDAdvanceDate.Enabled = false;
            this.txtDAdvanceDate.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDAdvanceDate.Location = new System.Drawing.Point(17, 80);
            this.txtDAdvanceDate.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtDAdvanceDate.Name = "txtDAdvanceDate";
            this.txtDAdvanceDate.ReadOnly = true;
            this.txtDAdvanceDate.Size = new System.Drawing.Size(122, 28);
            this.txtDAdvanceDate.TabIndex = 10;
            this.txtDAdvanceDate.Text = "Advance Date";
            // 
            // txtAmount
            // 
            this.txtAmount.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmount.Location = new System.Drawing.Point(374, 50);
            this.txtAmount.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtAmount.MaxLength = 10;
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(167, 28);
            this.txtAmount.TabIndex = 5;
            this.txtAmount.Enter += new System.EventHandler(this.TxtAmount_Enter);
            this.txtAmount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtAmount_KeyDown);
            this.txtAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtAmount_KeyPress);
            this.txtAmount.Leave += new System.EventHandler(this.TxtAmount_Leave);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::ROMS.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(623, 197);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 33);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            this.btnClose.Enter += new System.EventHandler(this.btnClose_Enter);
            this.btnClose.Leave += new System.EventHandler(this.btnClose_Leave);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::ROMS.Properties.Resources.save;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(537, 197);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 33);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.Enter += new System.EventHandler(this.btnSave_Enter);
            this.btnSave.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnSave_KeyDown);
            this.btnSave.Leave += new System.EventHandler(this.btnSave_Leave);
            // 
            // txtAdvanceAmt
            // 
            this.txtAdvanceAmt.BackColor = System.Drawing.SystemColors.Control;
            this.txtAdvanceAmt.Enabled = false;
            this.txtAdvanceAmt.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAdvanceAmt.Location = new System.Drawing.Point(252, 51);
            this.txtAdvanceAmt.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtAdvanceAmt.Name = "txtAdvanceAmt";
            this.txtAdvanceAmt.ReadOnly = true;
            this.txtAdvanceAmt.Size = new System.Drawing.Size(122, 28);
            this.txtAdvanceAmt.TabIndex = 8;
            this.txtAdvanceAmt.Text = "Advance Amount";
            // 
            // epAdvance
            // 
            this.epAdvance.ContainerControl = this;
            // 
            // cmbPaymentType
            // 
            this.cmbPaymentType.FormattingEnabled = true;
            this.cmbPaymentType.Location = new System.Drawing.Point(374, 106);
            this.cmbPaymentType.Name = "cmbPaymentType";
            this.cmbPaymentType.Size = new System.Drawing.Size(167, 28);
            this.cmbPaymentType.TabIndex = 1111216;
            // 
            // txtDPaymentType
            // 
            this.txtDPaymentType.BackColor = System.Drawing.SystemColors.Control;
            this.txtDPaymentType.Enabled = false;
            this.txtDPaymentType.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtDPaymentType.Location = new System.Drawing.Point(252, 106);
            this.txtDPaymentType.Name = "txtDPaymentType";
            this.txtDPaymentType.ReadOnly = true;
            this.txtDPaymentType.Size = new System.Drawing.Size(122, 27);
            this.txtDPaymentType.TabIndex = 1111222;
            this.txtDPaymentType.TabStop = false;
            this.txtDPaymentType.Text = "Payment Type";
            this.txtDPaymentType.Visible = false;
            // 
            // cmbPaymentmode
            // 
            this.cmbPaymentmode.FormattingEnabled = true;
            this.cmbPaymentmode.Location = new System.Drawing.Point(374, 78);
            this.cmbPaymentmode.Name = "cmbPaymentmode";
            this.cmbPaymentmode.Size = new System.Drawing.Size(167, 28);
            this.cmbPaymentmode.TabIndex = 1111215;
            // 
            // txtDPaymentMode
            // 
            this.txtDPaymentMode.BackColor = System.Drawing.SystemColors.Control;
            this.txtDPaymentMode.Enabled = false;
            this.txtDPaymentMode.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtDPaymentMode.Location = new System.Drawing.Point(252, 79);
            this.txtDPaymentMode.Name = "txtDPaymentMode";
            this.txtDPaymentMode.ReadOnly = true;
            this.txtDPaymentMode.Size = new System.Drawing.Size(122, 27);
            this.txtDPaymentMode.TabIndex = 1111221;
            this.txtDPaymentMode.TabStop = false;
            this.txtDPaymentMode.Text = "Payment Mode";
            // 
            // txtChequeNo
            // 
            this.txtChequeNo.Location = new System.Drawing.Point(374, 161);
            this.txtChequeNo.MaxLength = 50;
            this.txtChequeNo.Name = "txtChequeNo";
            this.txtChequeNo.Size = new System.Drawing.Size(167, 28);
            this.txtChequeNo.TabIndex = 1111218;
            this.txtChequeNo.Visible = false;
            // 
            // dtChequeDate
            // 
            this.dtChequeDate.CustomFormat = "dd/MM/yyyy";
            this.dtChequeDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtChequeDate.Location = new System.Drawing.Point(374, 134);
            this.dtChequeDate.Name = "dtChequeDate";
            this.dtChequeDate.Size = new System.Drawing.Size(167, 28);
            this.dtChequeDate.TabIndex = 1111217;
            this.dtChequeDate.Visible = false;
            // 
            // txtChequeDate
            // 
            this.txtChequeDate.BackColor = System.Drawing.SystemColors.Control;
            this.txtChequeDate.Enabled = false;
            this.txtChequeDate.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtChequeDate.Location = new System.Drawing.Point(252, 133);
            this.txtChequeDate.Name = "txtChequeDate";
            this.txtChequeDate.ReadOnly = true;
            this.txtChequeDate.Size = new System.Drawing.Size(122, 27);
            this.txtChequeDate.TabIndex = 1111220;
            this.txtChequeDate.TabStop = false;
            this.txtChequeDate.Text = "Cheque Date";
            this.txtChequeDate.Visible = false;
            // 
            // txtDChequeNo
            // 
            this.txtDChequeNo.BackColor = System.Drawing.SystemColors.Control;
            this.txtDChequeNo.Enabled = false;
            this.txtDChequeNo.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtDChequeNo.Location = new System.Drawing.Point(252, 160);
            this.txtDChequeNo.Name = "txtDChequeNo";
            this.txtDChequeNo.ReadOnly = true;
            this.txtDChequeNo.Size = new System.Drawing.Size(122, 27);
            this.txtDChequeNo.TabIndex = 1111219;
            this.txtDChequeNo.TabStop = false;
            this.txtDChequeNo.Text = "Cheque No";
            this.txtDChequeNo.Visible = false;
            // 
            // PAY_Advance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(744, 261);
            this.Controls.Add(this.grbform);
            this.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PAY_Advance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Advance";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PAY_Advance_FormClosing);
            this.Load += new System.EventHandler(this.PAY_Advance_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PAY_Advance_KeyDown);
            this.grbform.ResumeLayout(false);
            this.grbform.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epAdvance)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txtDReceiptN0;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox grbform;
        private System.Windows.Forms.ErrorProvider epAdvance;
        private System.Windows.Forms.TextBox txtAdvanceAmt;
        private System.Windows.Forms.TextBox txtDSupplier;
        private System.Windows.Forms.TextBox txtDAdvanceDate;
        private System.Windows.Forms.TextBox txtAmount;
        public System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtDEntryDate;
        private System.Windows.Forms.DateTimePicker dpAdvanceDate;
        private System.Windows.Forms.DateTimePicker dpEntryDate;
        private System.Windows.Forms.TextBox txtSupplier;
        public System.Windows.Forms.ListView LV_Supplier;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.Label lblschedule;
        private System.Windows.Forms.Label lblSupplierCode;
        private System.Windows.Forms.ComboBox cmbConcern;
        private System.Windows.Forms.TextBox txtConcern;
        private System.Windows.Forms.TextBox txtReceiptNo;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ComboBox cmbPaymentType;
        private System.Windows.Forms.TextBox txtDPaymentType;
        private System.Windows.Forms.ComboBox cmbPaymentmode;
        private System.Windows.Forms.TextBox txtDPaymentMode;
        private System.Windows.Forms.TextBox txtChequeNo;
        private System.Windows.Forms.DateTimePicker dtChequeDate;
        private System.Windows.Forms.TextBox txtChequeDate;
        private System.Windows.Forms.TextBox txtDChequeNo;
    }
}