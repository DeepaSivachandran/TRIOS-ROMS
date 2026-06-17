namespace ROMS
{
    partial class CP_Unit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CP_Unit));
            this.txtDUnitName = new System.Windows.Forms.TextBox();
            this.txtEUnitName = new System.Windows.Forms.TextBox();
            this.grbform = new System.Windows.Forms.GroupBox();
            this.cmbUnitValue = new System.Windows.Forms.ComboBox();
            this.txtUnitValue = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.chkBulkUnit = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtInvoiceUnit = new System.Windows.Forms.TextBox();
            this.cmbNoOfDecimals = new System.Windows.Forms.ComboBox();
            this.txtDNoOfDecimals = new System.Windows.Forms.TextBox();
            this.txtDSymbol = new System.Windows.Forms.TextBox();
            this.txtSymbol = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.pnlStatus = new System.Windows.Forms.Panel();
            this.rbInActive = new System.Windows.Forms.RadioButton();
            this.rbActive = new System.Windows.Forms.RadioButton();
            this.epUnit = new System.Windows.Forms.ErrorProvider(this.components);
            this.chkStickerPrint = new System.Windows.Forms.CheckBox();
            this.grbform.SuspendLayout();
            this.pnlStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epUnit)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDUnitName
            // 
            this.txtDUnitName.BackColor = System.Drawing.SystemColors.Control;
            this.txtDUnitName.Enabled = false;
            this.txtDUnitName.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDUnitName.Location = new System.Drawing.Point(37, 24);
            this.txtDUnitName.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtDUnitName.Name = "txtDUnitName";
            this.txtDUnitName.ReadOnly = true;
            this.txtDUnitName.Size = new System.Drawing.Size(122, 28);
            this.txtDUnitName.TabIndex = 7;
            this.txtDUnitName.Text = "Unit Name";
            // 
            // txtEUnitName
            // 
            this.txtEUnitName.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEUnitName.Location = new System.Drawing.Point(159, 24);
            this.txtEUnitName.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtEUnitName.MaxLength = 20;
            this.txtEUnitName.Name = "txtEUnitName";
            this.txtEUnitName.Size = new System.Drawing.Size(361, 28);
            this.txtEUnitName.TabIndex = 0;
            this.txtEUnitName.Enter += new System.EventHandler(this.txtEUnitName_Enter);
            this.txtEUnitName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEUnitName_KeyDown);
            this.txtEUnitName.Leave += new System.EventHandler(this.txtEUnitName_Leave);
            // 
            // grbform
            // 
            this.grbform.Controls.Add(this.chkStickerPrint);
            this.grbform.Controls.Add(this.cmbUnitValue);
            this.grbform.Controls.Add(this.txtUnitValue);
            this.grbform.Controls.Add(this.textBox2);
            this.grbform.Controls.Add(this.chkBulkUnit);
            this.grbform.Controls.Add(this.textBox1);
            this.grbform.Controls.Add(this.txtInvoiceUnit);
            this.grbform.Controls.Add(this.cmbNoOfDecimals);
            this.grbform.Controls.Add(this.txtDNoOfDecimals);
            this.grbform.Controls.Add(this.txtDSymbol);
            this.grbform.Controls.Add(this.txtSymbol);
            this.grbform.Controls.Add(this.btnClose);
            this.grbform.Controls.Add(this.btnSave);
            this.grbform.Controls.Add(this.txtStatus);
            this.grbform.Controls.Add(this.txtDUnitName);
            this.grbform.Controls.Add(this.txtEUnitName);
            this.grbform.Controls.Add(this.pnlStatus);
            this.grbform.Location = new System.Drawing.Point(13, 14);
            this.grbform.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.grbform.Name = "grbform";
            this.grbform.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.grbform.Size = new System.Drawing.Size(558, 314);
            this.grbform.TabIndex = 28;
            this.grbform.TabStop = false;
            this.grbform.Enter += new System.EventHandler(this.grbform_Enter);
            // 
            // cmbUnitValue
            // 
            this.cmbUnitValue.Enabled = false;
            this.cmbUnitValue.FormattingEnabled = true;
            this.cmbUnitValue.Location = new System.Drawing.Point(417, 136);
            this.cmbUnitValue.Name = "cmbUnitValue";
            this.cmbUnitValue.Size = new System.Drawing.Size(103, 28);
            this.cmbUnitValue.TabIndex = 5;
            this.cmbUnitValue.Enter += new System.EventHandler(this.cmbUnitValue_Enter);
            this.cmbUnitValue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbUnitValue_KeyDown);
            this.cmbUnitValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbUnitValue_KeyPress);
            this.cmbUnitValue.Leave += new System.EventHandler(this.cmbUnitValue_Leave);
            // 
            // txtUnitValue
            // 
            this.txtUnitValue.Enabled = false;
            this.txtUnitValue.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUnitValue.Location = new System.Drawing.Point(159, 136);
            this.txtUnitValue.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtUnitValue.MaxLength = 10;
            this.txtUnitValue.Name = "txtUnitValue";
            this.txtUnitValue.ReadOnly = true;
            this.txtUnitValue.Size = new System.Drawing.Size(258, 28);
            this.txtUnitValue.TabIndex = 4;
            this.txtUnitValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtUnitValue.Enter += new System.EventHandler(this.txtUnitValue_Enter);
            this.txtUnitValue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUnitValue_KeyDown);
            this.txtUnitValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUnitValue_KeyPress);
            this.txtUnitValue.Leave += new System.EventHandler(this.txtUnitValue_Leave);
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.Control;
            this.textBox2.Enabled = false;
            this.textBox2.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(37, 136);
            this.textBox2.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(122, 28);
            this.textBox2.TabIndex = 15;
            this.textBox2.Text = "Conversion Factor";
            // 
            // chkBulkUnit
            // 
            this.chkBulkUnit.AutoSize = true;
            this.chkBulkUnit.Location = new System.Drawing.Point(159, 201);
            this.chkBulkUnit.Name = "chkBulkUnit";
            this.chkBulkUnit.Size = new System.Drawing.Size(78, 24);
            this.chkBulkUnit.TabIndex = 8;
            this.chkBulkUnit.Text = "Bulk Unit";
            this.chkBulkUnit.UseVisualStyleBackColor = true;
            this.chkBulkUnit.Enter += new System.EventHandler(this.ChkBulkUnit_Enter);
            this.chkBulkUnit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ChkBulkUnit_KeyDown);
            this.chkBulkUnit.Leave += new System.EventHandler(this.ChkBulkUnit_Leave);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(37, 80);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(122, 28);
            this.textBox1.TabIndex = 14;
            this.textBox1.Text = "E-Invoice Unit";
            // 
            // txtInvoiceUnit
            // 
            this.txtInvoiceUnit.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInvoiceUnit.Location = new System.Drawing.Point(159, 80);
            this.txtInvoiceUnit.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtInvoiceUnit.MaxLength = 10;
            this.txtInvoiceUnit.Name = "txtInvoiceUnit";
            this.txtInvoiceUnit.Size = new System.Drawing.Size(361, 28);
            this.txtInvoiceUnit.TabIndex = 2;
            this.txtInvoiceUnit.Enter += new System.EventHandler(this.TxtInvoiceUnit_Enter);
            this.txtInvoiceUnit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtInvoiceUnit_KeyDown);
            this.txtInvoiceUnit.Leave += new System.EventHandler(this.TxtInvoiceUnit_Leave);
            // 
            // cmbNoOfDecimals
            // 
            this.cmbNoOfDecimals.FormattingEnabled = true;
            this.cmbNoOfDecimals.Location = new System.Drawing.Point(159, 108);
            this.cmbNoOfDecimals.Name = "cmbNoOfDecimals";
            this.cmbNoOfDecimals.Size = new System.Drawing.Size(361, 28);
            this.cmbNoOfDecimals.TabIndex = 3;
            this.cmbNoOfDecimals.Enter += new System.EventHandler(this.CmbNoOfDecimals_Enter);
            this.cmbNoOfDecimals.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbNoOfDecimals_KeyDown);
            this.cmbNoOfDecimals.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbNoOfDecimals_KeyPress);
            this.cmbNoOfDecimals.Leave += new System.EventHandler(this.CmbNoOfDecimals_Leave);
            // 
            // txtDNoOfDecimals
            // 
            this.txtDNoOfDecimals.BackColor = System.Drawing.SystemColors.Control;
            this.txtDNoOfDecimals.Enabled = false;
            this.txtDNoOfDecimals.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDNoOfDecimals.Location = new System.Drawing.Point(37, 108);
            this.txtDNoOfDecimals.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtDNoOfDecimals.Name = "txtDNoOfDecimals";
            this.txtDNoOfDecimals.ReadOnly = true;
            this.txtDNoOfDecimals.Size = new System.Drawing.Size(122, 28);
            this.txtDNoOfDecimals.TabIndex = 12;
            this.txtDNoOfDecimals.Text = "No.of Decimals";
            // 
            // txtDSymbol
            // 
            this.txtDSymbol.BackColor = System.Drawing.SystemColors.Control;
            this.txtDSymbol.Enabled = false;
            this.txtDSymbol.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDSymbol.Location = new System.Drawing.Point(37, 52);
            this.txtDSymbol.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtDSymbol.Name = "txtDSymbol";
            this.txtDSymbol.ReadOnly = true;
            this.txtDSymbol.Size = new System.Drawing.Size(122, 28);
            this.txtDSymbol.TabIndex = 10;
            this.txtDSymbol.Text = "Unit";
            // 
            // txtSymbol
            // 
            this.txtSymbol.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSymbol.Location = new System.Drawing.Point(159, 52);
            this.txtSymbol.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtSymbol.MaxLength = 10;
            this.txtSymbol.Name = "txtSymbol";
            this.txtSymbol.Size = new System.Drawing.Size(361, 28);
            this.txtSymbol.TabIndex = 1;
            this.txtSymbol.Enter += new System.EventHandler(this.TxtSymbol_Enter);
            this.txtSymbol.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtSymbol_KeyDown);
            this.txtSymbol.Leave += new System.EventHandler(this.TxtSymbol_Leave);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::ROMS.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(440, 229);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 33);
            this.btnClose.TabIndex = 11;
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
            this.btnSave.Location = new System.Drawing.Point(356, 229);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 33);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.Enter += new System.EventHandler(this.btnSave_Enter);
            this.btnSave.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnSave_KeyDown);
            this.btnSave.Leave += new System.EventHandler(this.btnSave_Leave);
            // 
            // txtStatus
            // 
            this.txtStatus.BackColor = System.Drawing.SystemColors.Control;
            this.txtStatus.Enabled = false;
            this.txtStatus.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStatus.Location = new System.Drawing.Point(37, 164);
            this.txtStatus.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(122, 28);
            this.txtStatus.TabIndex = 8;
            this.txtStatus.Text = "Status";
            // 
            // pnlStatus
            // 
            this.pnlStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlStatus.Controls.Add(this.rbInActive);
            this.pnlStatus.Controls.Add(this.rbActive);
            this.pnlStatus.Enabled = false;
            this.pnlStatus.Location = new System.Drawing.Point(159, 164);
            this.pnlStatus.Name = "pnlStatus";
            this.pnlStatus.Size = new System.Drawing.Size(361, 28);
            this.pnlStatus.TabIndex = 6;
            // 
            // rbInActive
            // 
            this.rbInActive.AutoSize = true;
            this.rbInActive.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbInActive.Location = new System.Drawing.Point(188, 1);
            this.rbInActive.Name = "rbInActive";
            this.rbInActive.Size = new System.Drawing.Size(70, 24);
            this.rbInActive.TabIndex = 7;
            this.rbInActive.Text = "Inactive";
            this.rbInActive.UseVisualStyleBackColor = true;
            this.rbInActive.Enter += new System.EventHandler(this.RbInActive_Enter);
            this.rbInActive.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RbInActive_KeyDown);
            this.rbInActive.Leave += new System.EventHandler(this.RbInActive_Leave);
            // 
            // rbActive
            // 
            this.rbActive.AutoSize = true;
            this.rbActive.Checked = true;
            this.rbActive.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbActive.Location = new System.Drawing.Point(105, 1);
            this.rbActive.Name = "rbActive";
            this.rbActive.Size = new System.Drawing.Size(60, 24);
            this.rbActive.TabIndex = 6;
            this.rbActive.TabStop = true;
            this.rbActive.Text = "Active";
            this.rbActive.UseVisualStyleBackColor = true;
            this.rbActive.Enter += new System.EventHandler(this.RbActive_Enter);
            this.rbActive.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RbActive_KeyDown);
            this.rbActive.Leave += new System.EventHandler(this.RbActive_Leave);
            // 
            // epUnit
            // 
            this.epUnit.ContainerControl = this;
            // 
            // chkStickerPrint
            // 
            this.chkStickerPrint.AutoSize = true;
            this.chkStickerPrint.Location = new System.Drawing.Point(266, 201);
            this.chkStickerPrint.Name = "chkStickerPrint";
            this.chkStickerPrint.Size = new System.Drawing.Size(96, 24);
            this.chkStickerPrint.TabIndex = 9;
            this.chkStickerPrint.Text = "Sticker Print";
            this.chkStickerPrint.UseVisualStyleBackColor = true;
            // 
            // CP_Unit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(585, 342);
            this.Controls.Add(this.grbform);
            this.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CP_Unit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Unit";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CP_Unit_FormClosing);
            this.Load += new System.EventHandler(this.CP_Unit_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CP_Unit_KeyDown);
            this.Leave += new System.EventHandler(this.CP_Unit_Leave);
            this.grbform.ResumeLayout(false);
            this.grbform.PerformLayout();
            this.pnlStatus.ResumeLayout(false);
            this.pnlStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epUnit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txtDUnitName;
        private System.Windows.Forms.TextBox txtEUnitName;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox grbform;
        private System.Windows.Forms.ErrorProvider epUnit;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.RadioButton rbInActive;
        private System.Windows.Forms.RadioButton rbActive;
        private System.Windows.Forms.Panel pnlStatus;
        private System.Windows.Forms.TextBox txtDNoOfDecimals;
        private System.Windows.Forms.TextBox txtDSymbol;
        private System.Windows.Forms.TextBox txtSymbol;
        private System.Windows.Forms.ComboBox cmbNoOfDecimals;
        public System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox txtInvoiceUnit;
        private System.Windows.Forms.CheckBox chkBulkUnit;
        private System.Windows.Forms.ComboBox cmbUnitValue;
        private System.Windows.Forms.TextBox txtUnitValue;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.CheckBox chkStickerPrint;
    }
}