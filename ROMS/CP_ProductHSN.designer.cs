namespace ROMS
{
    partial class CP_ProductHSN
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CP_ProductHSN));
            this.txtDHsnName = new System.Windows.Forms.TextBox();
            this.txtHSNName = new System.Windows.Forms.TextBox();
            this.txtDHsnCode = new System.Windows.Forms.TextBox();
            this.txtHSNCode = new System.Windows.Forms.TextBox();
            this.txtDSGT = new System.Windows.Forms.TextBox();
            this.grbform = new System.Windows.Forms.GroupBox();
            this.pnlStatus = new System.Windows.Forms.Panel();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.cmbGST = new System.Windows.Forms.ComboBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.eppHsn = new System.Windows.Forms.ErrorProvider(this.components);
            this.grbform.SuspendLayout();
            this.pnlStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eppHsn)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDHsnName
            // 
            this.txtDHsnName.BackColor = System.Drawing.SystemColors.Control;
            this.txtDHsnName.Enabled = false;
            this.txtDHsnName.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtDHsnName.Location = new System.Drawing.Point(23, 23);
            this.txtDHsnName.Name = "txtDHsnName";
            this.txtDHsnName.ReadOnly = true;
            this.txtDHsnName.Size = new System.Drawing.Size(101, 27);
            this.txtDHsnName.TabIndex = 14;
            this.txtDHsnName.Text = "HSN Name";
            // 
            // txtHSNName
            // 
            this.txtHSNName.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtHSNName.Location = new System.Drawing.Point(124, 23);
            this.txtHSNName.MaxLength = 100;
            this.txtHSNName.Name = "txtHSNName";
            this.txtHSNName.Size = new System.Drawing.Size(200, 27);
            this.txtHSNName.TabIndex = 0;
            this.txtHSNName.Enter += new System.EventHandler(this.TxtHSNName_Enter);
            this.txtHSNName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtHSNName_KeyDown);
            this.txtHSNName.Leave += new System.EventHandler(this.TxtHSNName_Leave);
            // 
            // txtDHsnCode
            // 
            this.txtDHsnCode.BackColor = System.Drawing.SystemColors.Control;
            this.txtDHsnCode.Enabled = false;
            this.txtDHsnCode.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtDHsnCode.Location = new System.Drawing.Point(23, 50);
            this.txtDHsnCode.Name = "txtDHsnCode";
            this.txtDHsnCode.ReadOnly = true;
            this.txtDHsnCode.Size = new System.Drawing.Size(101, 27);
            this.txtDHsnCode.TabIndex = 15;
            this.txtDHsnCode.Text = "HSN Code";
            // 
            // txtHSNCode
            // 
            this.txtHSNCode.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtHSNCode.Location = new System.Drawing.Point(124, 50);
            this.txtHSNCode.MaxLength = 10;
            this.txtHSNCode.Name = "txtHSNCode";
            this.txtHSNCode.Size = new System.Drawing.Size(200, 27);
            this.txtHSNCode.TabIndex = 1;
            this.txtHSNCode.Enter += new System.EventHandler(this.TxtHSNCode_Enter);
            this.txtHSNCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtHSNCode_KeyDown);
            this.txtHSNCode.Leave += new System.EventHandler(this.TxtHSNCode_Leave);
            // 
            // txtDSGT
            // 
            this.txtDSGT.BackColor = System.Drawing.SystemColors.Control;
            this.txtDSGT.Enabled = false;
            this.txtDSGT.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtDSGT.Location = new System.Drawing.Point(23, 77);
            this.txtDSGT.Name = "txtDSGT";
            this.txtDSGT.ReadOnly = true;
            this.txtDSGT.Size = new System.Drawing.Size(101, 27);
            this.txtDSGT.TabIndex = 16;
            this.txtDSGT.Text = "GST";
            // 
            // grbform
            // 
            this.grbform.Controls.Add(this.pnlStatus);
            this.grbform.Controls.Add(this.cmbGST);
            this.grbform.Controls.Add(this.textBox4);
            this.grbform.Controls.Add(this.btnSave);
            this.grbform.Controls.Add(this.btnClose);
            this.grbform.Controls.Add(this.txtDHsnName);
            this.grbform.Controls.Add(this.txtHSNName);
            this.grbform.Controls.Add(this.txtHSNCode);
            this.grbform.Controls.Add(this.txtDHsnCode);
            this.grbform.Controls.Add(this.txtDSGT);
            this.grbform.Location = new System.Drawing.Point(12, 12);
            this.grbform.Name = "grbform";
            this.grbform.Size = new System.Drawing.Size(349, 186);
            this.grbform.TabIndex = 0;
            this.grbform.TabStop = false;
            // 
            // pnlStatus
            // 
            this.pnlStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlStatus.Controls.Add(this.radioButton1);
            this.pnlStatus.Controls.Add(this.radioButton2);
            this.pnlStatus.Enabled = false;
            this.pnlStatus.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlStatus.Location = new System.Drawing.Point(124, 104);
            this.pnlStatus.Name = "pnlStatus";
            this.pnlStatus.Size = new System.Drawing.Size(200, 27);
            this.pnlStatus.TabIndex = 3;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Font = new System.Drawing.Font("Oswald Regular", 9.75F);
            this.radioButton1.Location = new System.Drawing.Point(94, 1);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(63, 21);
            this.radioButton1.TabIndex = 4;
            this.radioButton1.Text = "Inactive";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Checked = true;
            this.radioButton2.Font = new System.Drawing.Font("Oswald Regular", 9.75F);
            this.radioButton2.Location = new System.Drawing.Point(3, 1);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(54, 21);
            this.radioButton2.TabIndex = 3;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Active";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // cmbGST
            // 
            this.cmbGST.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbGST.FormattingEnabled = true;
            this.cmbGST.Location = new System.Drawing.Point(124, 77);
            this.cmbGST.Name = "cmbGST";
            this.cmbGST.Size = new System.Drawing.Size(200, 27);
            this.cmbGST.TabIndex = 2;
            this.cmbGST.SelectedIndexChanged += new System.EventHandler(this.CmbGST_SelectedIndexChanged);
            this.cmbGST.Enter += new System.EventHandler(this.CmbGST_Enter);
            this.cmbGST.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbGST_KeyDown);
            this.cmbGST.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbGST_KeyPress);
            this.cmbGST.Leave += new System.EventHandler(this.CmbGST_Leave);
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
            this.textBox4.Text = "Status";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnSave.Image = global::ROMS.Properties.Resources.save;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(151, 143);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(84, 29);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            this.btnSave.Enter += new System.EventHandler(this.btnSave_Enter);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnClose.Image = global::ROMS.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(249, 143);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 29);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            this.btnClose.Enter += new System.EventHandler(this.btnClose_Enter);
            this.btnClose.Leave += new System.EventHandler(this.btnClose_Leave);
            // 
            // eppHsn
            // 
            this.eppHsn.ContainerControl = this;
            // 
            // CP_ProductHSN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(375, 212);
            this.Controls.Add(this.grbform);
            this.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CP_ProductHSN";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HSN Name";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CP_ProductHSN_FormClosing);
            this.Load += new System.EventHandler(this.CP_ProductHSN_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CP_ProductHSN_KeyDown);
            this.grbform.ResumeLayout(false);
            this.grbform.PerformLayout();
            this.pnlStatus.ResumeLayout(false);
            this.pnlStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eppHsn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtDHsnName;
        private System.Windows.Forms.TextBox txtHSNName;
        private System.Windows.Forms.TextBox txtDHsnCode;
        private System.Windows.Forms.TextBox txtHSNCode;
        private System.Windows.Forms.TextBox txtDSGT;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox grbform;
        private System.Windows.Forms.ErrorProvider eppHsn;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.ComboBox cmbGST;
        private System.Windows.Forms.Panel pnlStatus;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        public System.Windows.Forms.Button btnSave;
    }
}