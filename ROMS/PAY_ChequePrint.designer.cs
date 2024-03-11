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
            this.btnPreview = new System.Windows.Forms.Button();
            this.cmbBank = new System.Windows.Forms.ComboBox();
            this.txtTransactionno = new System.Windows.Forms.TextBox();
            this.lblDAmount = new System.Windows.Forms.Label();
            this.lblDBank = new System.Windows.Forms.Label();
            this.dpDate = new System.Windows.Forms.DateTimePicker();
            this.txtsuppliername = new System.Windows.Forms.TextBox();
            this.lblSupplier = new System.Windows.Forms.Label();
            this.lblChequeDate = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tsSupplierMapping.SuspendLayout();
            this.pnlSupplierMapping.SuspendLayout();
            this.grpSupplierMapping.SuspendLayout();
            this.grbgodown.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            this.grpSupplierMapping.Controls.Add(this.groupBox1);
            this.grpSupplierMapping.Controls.Add(this.groupBox2);
            this.grpSupplierMapping.Controls.Add(this.grbgodown);
            this.grpSupplierMapping.Location = new System.Drawing.Point(7, 1);
            this.grpSupplierMapping.Name = "grpSupplierMapping";
            this.grpSupplierMapping.Size = new System.Drawing.Size(1339, 633);
            this.grpSupplierMapping.TabIndex = 958765;
            this.grpSupplierMapping.TabStop = false;
            // 
            // grbgodown
            // 
            this.grbgodown.Controls.Add(this.btnPreview);
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
            this.grbgodown.Size = new System.Drawing.Size(718, 72);
            this.grbgodown.TabIndex = 958806;
            this.grbgodown.TabStop = false;
            // 
            // btnPreview
            // 
            this.btnPreview.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnPreview.Image = global::ROMS.Properties.Resources.view;
            this.btnPreview.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPreview.Location = new System.Drawing.Point(631, 35);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(84, 29);
            this.btnPreview.TabIndex = 1111222;
            this.btnPreview.Text = "Preview";
            this.btnPreview.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPreview.UseVisualStyleBackColor = true;
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Font = new System.Drawing.Font("Oswald Regular", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(1037, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(295, 104);
            this.groupBox2.TabIndex = 1111223;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Supplier Details";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.White;
            this.label12.Font = new System.Drawing.Font("Oswald Regular", 8F);
            this.label12.Location = new System.Drawing.Point(73, 87);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(78, 15);
            this.label12.TabIndex = 1111205;
            this.label12.Text = "Weekly - Monday";
            this.label12.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.White;
            this.label13.Font = new System.Drawing.Font("Oswald Regular", 8F);
            this.label13.Location = new System.Drawing.Point(6, 87);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(71, 15);
            this.label13.TabIndex = 1111206;
            this.label13.Text = "Return Policy : ";
            this.label13.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.White;
            this.label14.Font = new System.Drawing.Font("Oswald Regular", 8F);
            this.label14.Location = new System.Drawing.Point(6, 58);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(87, 15);
            this.label14.TabIndex = 1111203;
            this.label14.Text = "Himalayas - Mobile";
            this.label14.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.White;
            this.label19.Font = new System.Drawing.Font("Oswald Regular", 8F);
            this.label19.Location = new System.Drawing.Point(6, 30);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(64, 15);
            this.label19.TabIndex = 1111204;
            this.label19.Text = "Virudhunagar";
            this.label19.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.White;
            this.label15.Font = new System.Drawing.Font("Oswald Regular", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(6, 13);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(138, 19);
            this.label15.TabIndex = 1111200;
            this.label15.Text = "Shiva Softwares Solutions";
            this.label15.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.White;
            this.label16.Font = new System.Drawing.Font("Oswald Regular", 8F);
            this.label16.Location = new System.Drawing.Point(6, 45);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(164, 15);
            this.label16.TabIndex = 1111201;
            this.label16.Text = "GSTIN 22AAAAA0000A1Z5 - Registered";
            this.label16.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.White;
            this.label18.Font = new System.Drawing.Font("Oswald Regular", 8F);
            this.label18.Location = new System.Drawing.Point(6, 72);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(162, 15);
            this.label18.TabIndex = 1111202;
            this.label18.Text = "Payment Terms - Taxable Amount only";
            this.label18.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Font = new System.Drawing.Font("Oswald Regular", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(735, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(295, 104);
            this.groupBox1.TabIndex = 1111224;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Amount in words";
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
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
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
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.ComboBox cmbBank;
        private System.Windows.Forms.TextBox txtTransactionno;
        private System.Windows.Forms.Label lblDAmount;
        private System.Windows.Forms.Label lblDBank;
        private System.Windows.Forms.DateTimePicker dpDate;
        private System.Windows.Forms.TextBox txtsuppliername;
        private System.Windows.Forms.Label lblSupplier;
        private System.Windows.Forms.Label lblChequeDate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label18;
    }
}