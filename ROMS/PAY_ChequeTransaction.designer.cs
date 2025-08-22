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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PAY_ChequeTransaction));
            this.txtDSupplierName = new System.Windows.Forms.TextBox();
            this.txtSupplier = new System.Windows.Forms.TextBox();
            this.txtDPaymentNo = new System.Windows.Forms.TextBox();
            this.txtPaymentNo = new System.Windows.Forms.TextBox();
            this.txtDAmount = new System.Windows.Forms.TextBox();
            this.grbform = new System.Windows.Forms.GroupBox();
            this.dpChequeDate = new System.Windows.Forms.DateTimePicker();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.txtChequeNo = new System.Windows.Forms.TextBox();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.epHsn = new System.Windows.Forms.ErrorProvider(this.components);
            this.grbform.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epHsn)).BeginInit();
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
            this.txtDSupplierName.Size = new System.Drawing.Size(101, 27);
            this.txtDSupplierName.TabIndex = 14;
            this.txtDSupplierName.Text = "Supplier";
            // 
            // txtSupplier
            // 
            this.txtSupplier.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSupplier.Enabled = false;
            this.txtSupplier.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtSupplier.Location = new System.Drawing.Point(124, 23);
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
            this.txtDPaymentNo.Size = new System.Drawing.Size(101, 27);
            this.txtDPaymentNo.TabIndex = 15;
            this.txtDPaymentNo.Text = "Payment No.";
            // 
            // txtPaymentNo
            // 
            this.txtPaymentNo.Enabled = false;
            this.txtPaymentNo.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtPaymentNo.Location = new System.Drawing.Point(124, 50);
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
            this.txtDAmount.Size = new System.Drawing.Size(101, 27);
            this.txtDAmount.TabIndex = 16;
            this.txtDAmount.Text = "Amount";
            // 
            // grbform
            // 
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
            this.grbform.Size = new System.Drawing.Size(349, 211);
            this.grbform.TabIndex = 0;
            this.grbform.TabStop = false;
            // 
            // dpChequeDate
            // 
            this.dpChequeDate.CustomFormat = "dd/MM/yyyy";
            this.dpChequeDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpChequeDate.Location = new System.Drawing.Point(124, 131);
            this.dpChequeDate.Name = "dpChequeDate";
            this.dpChequeDate.Size = new System.Drawing.Size(200, 27);
            this.dpChequeDate.TabIndex = 1;
            this.dpChequeDate.Enter += new System.EventHandler(this.DpChequeDate_Enter);
            this.dpChequeDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DpChequeDate_KeyDown);
            this.dpChequeDate.Leave += new System.EventHandler(this.DpChequeDate_Leave);
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.SystemColors.Control;
            this.textBox5.Enabled = false;
            this.textBox5.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.textBox5.Location = new System.Drawing.Point(23, 131);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(101, 27);
            this.textBox5.TabIndex = 59;
            this.textBox5.Text = "Cheque Date";
            // 
            // txtChequeNo
            // 
            this.txtChequeNo.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtChequeNo.Location = new System.Drawing.Point(124, 104);
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
            this.txtAmount.Location = new System.Drawing.Point(124, 77);
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
            this.textBox4.Size = new System.Drawing.Size(101, 27);
            this.textBox4.TabIndex = 56;
            this.textBox4.Text = "Cheque No.";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnUpdate.Image = global::ROMS.Properties.Resources.save;
            this.btnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdate.Location = new System.Drawing.Point(160, 170);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(84, 29);
            this.btnUpdate.TabIndex = 3;
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
            this.btnClose.Location = new System.Drawing.Point(249, 170);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 29);
            this.btnClose.TabIndex = 4;
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
            // PAY_ChequeTransaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(375, 239);
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
    }
}