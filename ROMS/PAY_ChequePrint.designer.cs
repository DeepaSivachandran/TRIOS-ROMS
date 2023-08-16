namespace ROMS
{
    partial class PAY_ChequePrint
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
            this.tsSupplierMapping = new System.Windows.Forms.ToolStrip();
            this.tspSupplierMapping = new System.Windows.Forms.ToolStripLabel();
            this.lblNoRecordsFound = new System.Windows.Forms.Label();
            this.pnlSupplierMapping = new System.Windows.Forms.Panel();
            this.grpSupplierMapping = new System.Windows.Forms.GroupBox();
            this.grbgodown = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtamountwords = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbBank = new System.Windows.Forms.ComboBox();
            this.txtTransactionno = new System.Windows.Forms.TextBox();
            this.lblDAmount = new System.Windows.Forms.Label();
            this.lblDBank = new System.Windows.Forms.Label();
            this.dpDate = new System.Windows.Forms.DateTimePicker();
            this.txtsuppliername = new System.Windows.Forms.TextBox();
            this.lblSupplier = new System.Windows.Forms.Label();
            this.lblChequeDate = new System.Windows.Forms.Label();
            this.grbSupplierDetails = new System.Windows.Forms.GroupBox();
            this.tsSupplierMapping.SuspendLayout();
            this.pnlSupplierMapping.SuspendLayout();
            this.grpSupplierMapping.SuspendLayout();
            this.grbgodown.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsSupplierMapping
            // 
            this.tsSupplierMapping.BackColor = System.Drawing.Color.White;
            this.tsSupplierMapping.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsSupplierMapping.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsSupplierMapping.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspSupplierMapping});
            this.tsSupplierMapping.Location = new System.Drawing.Point(0, 0);
            this.tsSupplierMapping.Name = "tsSupplierMapping";
            this.tsSupplierMapping.Size = new System.Drawing.Size(1354, 25);
            this.tsSupplierMapping.TabIndex = 35;
            this.tsSupplierMapping.Text = "Direct Cheque Print";
            // 
            // tspSupplierMapping
            // 
            this.tspSupplierMapping.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tspSupplierMapping.Image = global::ROMS.Properties.Resources.bread_crumb;
            this.tspSupplierMapping.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tspSupplierMapping.Margin = new System.Windows.Forms.Padding(15, 1, 0, 2);
            this.tspSupplierMapping.Name = "tspSupplierMapping";
            this.tspSupplierMapping.Size = new System.Drawing.Size(132, 22);
            this.tspSupplierMapping.Text = "Direct Cheque Print";
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
            // pnlSupplierMapping
            // 
            this.pnlSupplierMapping.BackColor = System.Drawing.Color.White;
            this.pnlSupplierMapping.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSupplierMapping.Controls.Add(this.grpSupplierMapping);
            this.pnlSupplierMapping.Location = new System.Drawing.Point(0, 29);
            this.pnlSupplierMapping.Name = "pnlSupplierMapping";
            this.pnlSupplierMapping.Size = new System.Drawing.Size(1353, 643);
            this.pnlSupplierMapping.TabIndex = 958764;
            // 
            // grpSupplierMapping
            // 
            this.grpSupplierMapping.BackColor = System.Drawing.Color.White;
            this.grpSupplierMapping.Controls.Add(this.grbSupplierDetails);
            this.grpSupplierMapping.Controls.Add(this.grbgodown);
            this.grpSupplierMapping.Location = new System.Drawing.Point(7, 1);
            this.grpSupplierMapping.Name = "grpSupplierMapping";
            this.grpSupplierMapping.Size = new System.Drawing.Size(1339, 633);
            this.grpSupplierMapping.TabIndex = 958765;
            this.grpSupplierMapping.TabStop = false;
            // 
            // grbgodown
            // 
            this.grbgodown.Controls.Add(this.button1);
            this.grbgodown.Controls.Add(this.txtamountwords);
            this.grbgodown.Controls.Add(this.label1);
            this.grbgodown.Controls.Add(this.cmbBank);
            this.grbgodown.Controls.Add(this.txtTransactionno);
            this.grbgodown.Controls.Add(this.lblDAmount);
            this.grbgodown.Controls.Add(this.lblDBank);
            this.grbgodown.Controls.Add(this.dpDate);
            this.grbgodown.Controls.Add(this.txtsuppliername);
            this.grbgodown.Controls.Add(this.lblSupplier);
            this.grbgodown.Controls.Add(this.lblChequeDate);
            this.grbgodown.Location = new System.Drawing.Point(6, 13);
            this.grbgodown.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbgodown.Name = "grbgodown";
            this.grbgodown.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbgodown.Size = new System.Drawing.Size(1094, 73);
            this.grbgodown.TabIndex = 958806;
            this.grbgodown.TabStop = false;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.button1.Image = global::ROMS.Properties.Resources.print;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(1004, 37);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 29);
            this.button1.TabIndex = 1111222;
            this.button1.Text = "Print";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // txtamountwords
            // 
            this.txtamountwords.Enabled = false;
            this.txtamountwords.Location = new System.Drawing.Point(631, 36);
            this.txtamountwords.Name = "txtamountwords";
            this.txtamountwords.ReadOnly = true;
            this.txtamountwords.Size = new System.Drawing.Size(367, 27);
            this.txtamountwords.TabIndex = 94;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(631, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.TabIndex = 93;
            this.label1.Text = "Amount in words";
            // 
            // cmbBank
            // 
            this.cmbBank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBank.FormattingEnabled = true;
            this.cmbBank.Location = new System.Drawing.Point(267, 36);
            this.cmbBank.Name = "cmbBank";
            this.cmbBank.Size = new System.Drawing.Size(108, 27);
            this.cmbBank.TabIndex = 92;
            // 
            // txtTransactionno
            // 
            this.txtTransactionno.Location = new System.Drawing.Point(497, 36);
            this.txtTransactionno.Name = "txtTransactionno";
            this.txtTransactionno.Size = new System.Drawing.Size(128, 27);
            this.txtTransactionno.TabIndex = 91;
            // 
            // lblDAmount
            // 
            this.lblDAmount.AutoSize = true;
            this.lblDAmount.Location = new System.Drawing.Point(497, 14);
            this.lblDAmount.Name = "lblDAmount";
            this.lblDAmount.Size = new System.Drawing.Size(95, 20);
            this.lblDAmount.TabIndex = 90;
            this.lblDAmount.Text = "Cheque Amount";
            // 
            // lblDBank
            // 
            this.lblDBank.AutoSize = true;
            this.lblDBank.Location = new System.Drawing.Point(267, 14);
            this.lblDBank.Name = "lblDBank";
            this.lblDBank.Size = new System.Drawing.Size(36, 20);
            this.lblDBank.TabIndex = 87;
            this.lblDBank.Text = "Bank";
            // 
            // dpDate
            // 
            this.dpDate.CustomFormat = "dd/MM/yyyy";
            this.dpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpDate.Location = new System.Drawing.Point(382, 36);
            this.dpDate.Name = "dpDate";
            this.dpDate.Size = new System.Drawing.Size(108, 27);
            this.dpDate.TabIndex = 86;
            // 
            // txtsuppliername
            // 
            this.txtsuppliername.Location = new System.Drawing.Point(11, 36);
            this.txtsuppliername.Name = "txtsuppliername";
            this.txtsuppliername.Size = new System.Drawing.Size(250, 27);
            this.txtsuppliername.TabIndex = 83;
            // 
            // lblSupplier
            // 
            this.lblSupplier.AutoSize = true;
            this.lblSupplier.Location = new System.Drawing.Point(11, 14);
            this.lblSupplier.Name = "lblSupplier";
            this.lblSupplier.Size = new System.Drawing.Size(57, 20);
            this.lblSupplier.TabIndex = 27;
            this.lblSupplier.Text = "Supplier ";
            // 
            // lblChequeDate
            // 
            this.lblChequeDate.AutoSize = true;
            this.lblChequeDate.Location = new System.Drawing.Point(382, 14);
            this.lblChequeDate.Name = "lblChequeDate";
            this.lblChequeDate.Size = new System.Drawing.Size(78, 20);
            this.lblChequeDate.TabIndex = 70;
            this.lblChequeDate.Text = "Cheque Date";
            // 
            // grbSupplierDetails
            // 
            this.grbSupplierDetails.Location = new System.Drawing.Point(1105, 13);
            this.grbSupplierDetails.Name = "grbSupplierDetails";
            this.grbSupplierDetails.Size = new System.Drawing.Size(227, 97);
            this.grbSupplierDetails.TabIndex = 958814;
            this.grbSupplierDetails.TabStop = false;
            this.grbSupplierDetails.Text = "Supplier Details";
            // 
            // PAY_ChequePrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(1354, 674);
            this.Controls.Add(this.pnlSupplierMapping);
            this.Controls.Add(this.lblNoRecordsFound);
            this.Controls.Add(this.tsSupplierMapping);
            this.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "PAY_ChequePrint";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Goods Receipt";
            this.tsSupplierMapping.ResumeLayout(false);
            this.tsSupplierMapping.PerformLayout();
            this.pnlSupplierMapping.ResumeLayout(false);
            this.grpSupplierMapping.ResumeLayout(false);
            this.grbgodown.ResumeLayout(false);
            this.grbgodown.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsSupplierMapping;
        private System.Windows.Forms.ToolStripLabel tspSupplierMapping;
        private System.Windows.Forms.Label lblNoRecordsFound;
        private System.Windows.Forms.Panel pnlSupplierMapping;
        private System.Windows.Forms.GroupBox grpSupplierMapping;
        private System.Windows.Forms.GroupBox grbgodown;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtamountwords;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbBank;
        private System.Windows.Forms.TextBox txtTransactionno;
        private System.Windows.Forms.Label lblDAmount;
        private System.Windows.Forms.Label lblDBank;
        private System.Windows.Forms.DateTimePicker dpDate;
        private System.Windows.Forms.TextBox txtsuppliername;
        private System.Windows.Forms.Label lblSupplier;
        private System.Windows.Forms.Label lblChequeDate;
        private System.Windows.Forms.GroupBox grbSupplierDetails;
    }
}