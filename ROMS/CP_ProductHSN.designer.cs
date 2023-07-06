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
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.grpStatus = new System.Windows.Forms.GroupBox();
            this.rbInactive = new System.Windows.Forms.RadioButton();
            this.rbactive = new System.Windows.Forms.RadioButton();
            this.errCompany = new System.Windows.Forms.ErrorProvider(this.components);
            this.cmbGST = new System.Windows.Forms.ComboBox();
            this.txtDeffectivedate = new System.Windows.Forms.TextBox();
            this.dptitle = new System.Windows.Forms.DateTimePicker();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.grbform.SuspendLayout();
            this.grpStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errCompany)).BeginInit();
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
            this.txtDHsnName.Size = new System.Drawing.Size(82, 27);
            this.txtDHsnName.TabIndex = 14;
            this.txtDHsnName.Text = "HSN Name";
            // 
            // txtHSNName
            // 
            this.txtHSNName.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtHSNName.Location = new System.Drawing.Point(105, 23);
            this.txtHSNName.MaxLength = 100;
            this.txtHSNName.Name = "txtHSNName";
            this.txtHSNName.Size = new System.Drawing.Size(286, 27);
            this.txtHSNName.TabIndex = 0;
            this.txtHSNName.Enter += new System.EventHandler(this.txtCompanyName_Enter);
            this.txtHSNName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCompanyName_KeyDown);
            this.txtHSNName.Leave += new System.EventHandler(this.txtCompanyName_Leave);
            // 
            // txtDHsnCode
            // 
            this.txtDHsnCode.BackColor = System.Drawing.SystemColors.Control;
            this.txtDHsnCode.Enabled = false;
            this.txtDHsnCode.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtDHsnCode.Location = new System.Drawing.Point(23, 50);
            this.txtDHsnCode.Name = "txtDHsnCode";
            this.txtDHsnCode.ReadOnly = true;
            this.txtDHsnCode.Size = new System.Drawing.Size(82, 27);
            this.txtDHsnCode.TabIndex = 15;
            this.txtDHsnCode.Text = "HSN Code";
            // 
            // txtHSNCode
            // 
            this.txtHSNCode.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtHSNCode.Location = new System.Drawing.Point(105, 50);
            this.txtHSNCode.MaxLength = 10;
            this.txtHSNCode.Name = "txtHSNCode";
            this.txtHSNCode.Size = new System.Drawing.Size(286, 27);
            this.txtHSNCode.TabIndex = 1;
            this.txtHSNCode.Enter += new System.EventHandler(this.txtShortName_Enter);
            this.txtHSNCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtShortName_KeyDown);
            this.txtHSNCode.Leave += new System.EventHandler(this.txtShortName_Leave);
            // 
            // txtDSGT
            // 
            this.txtDSGT.BackColor = System.Drawing.SystemColors.Control;
            this.txtDSGT.Enabled = false;
            this.txtDSGT.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtDSGT.Location = new System.Drawing.Point(225, 77);
            this.txtDSGT.Name = "txtDSGT";
            this.txtDSGT.ReadOnly = true;
            this.txtDSGT.Size = new System.Drawing.Size(48, 27);
            this.txtDSGT.TabIndex = 16;
            this.txtDSGT.Text = "GST";
            // 
            // grbform
            // 
            this.grbform.Controls.Add(this.dptitle);
            this.grbform.Controls.Add(this.txtDeffectivedate);
            this.grbform.Controls.Add(this.cmbGST);
            this.grbform.Controls.Add(this.textBox4);
            this.grbform.Controls.Add(this.btnSave);
            this.grbform.Controls.Add(this.btnClose);
            this.grbform.Controls.Add(this.txtDHsnName);
            this.grbform.Controls.Add(this.txtHSNName);
            this.grbform.Controls.Add(this.txtHSNCode);
            this.grbform.Controls.Add(this.txtDHsnCode);
            this.grbform.Controls.Add(this.txtDSGT);
            this.grbform.Controls.Add(this.grpStatus);
            this.grbform.Location = new System.Drawing.Point(12, 12);
            this.grbform.Name = "grbform";
            this.grbform.Size = new System.Drawing.Size(417, 182);
            this.grbform.TabIndex = 0;
            this.grbform.TabStop = false;
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.SystemColors.Control;
            this.textBox4.Enabled = false;
            this.textBox4.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.textBox4.Location = new System.Drawing.Point(23, 104);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(82, 27);
            this.textBox4.TabIndex = 56;
            this.textBox4.Text = "Status";
            // 
            // grpStatus
            // 
            this.grpStatus.Controls.Add(this.rbInactive);
            this.grpStatus.Controls.Add(this.rbactive);
            this.grpStatus.Enabled = false;
            this.grpStatus.Location = new System.Drawing.Point(105, 96);
            this.grpStatus.Name = "grpStatus";
            this.grpStatus.Size = new System.Drawing.Size(286, 36);
            this.grpStatus.TabIndex = 59;
            this.grpStatus.TabStop = false;
            // 
            // rbInactive
            // 
            this.rbInactive.AutoSize = true;
            this.rbInactive.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbInactive.Location = new System.Drawing.Point(101, 9);
            this.rbInactive.Name = "rbInactive";
            this.rbInactive.Size = new System.Drawing.Size(70, 24);
            this.rbInactive.TabIndex = 15;
            this.rbInactive.Text = "Inactive";
            this.rbInactive.UseVisualStyleBackColor = true;
            // 
            // rbactive
            // 
            this.rbactive.AutoSize = true;
            this.rbactive.Checked = true;
            this.rbactive.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbactive.Location = new System.Drawing.Point(18, 9);
            this.rbactive.Name = "rbactive";
            this.rbactive.Size = new System.Drawing.Size(60, 24);
            this.rbactive.TabIndex = 14;
            this.rbactive.TabStop = true;
            this.rbactive.Text = "Active";
            this.rbactive.UseVisualStyleBackColor = true;
            // 
            // errCompany
            // 
            this.errCompany.ContainerControl = this;
            // 
            // cmbGST
            // 
            this.cmbGST.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGST.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbGST.FormattingEnabled = true;
            this.cmbGST.Location = new System.Drawing.Point(273, 77);
            this.cmbGST.Name = "cmbGST";
            this.cmbGST.Size = new System.Drawing.Size(118, 27);
            this.cmbGST.TabIndex = 62;
            // 
            // txtDeffectivedate
            // 
            this.txtDeffectivedate.BackColor = System.Drawing.SystemColors.Control;
            this.txtDeffectivedate.Enabled = false;
            this.txtDeffectivedate.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtDeffectivedate.Location = new System.Drawing.Point(23, 77);
            this.txtDeffectivedate.Name = "txtDeffectivedate";
            this.txtDeffectivedate.ReadOnly = true;
            this.txtDeffectivedate.Size = new System.Drawing.Size(82, 27);
            this.txtDeffectivedate.TabIndex = 68;
            this.txtDeffectivedate.Text = "Effective From";
            // 
            // dptitle
            // 
            this.dptitle.CustomFormat = "dd/MM/yyyy";
            this.dptitle.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dptitle.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dptitle.Location = new System.Drawing.Point(105, 76);
            this.dptitle.Name = "dptitle";
            this.dptitle.Size = new System.Drawing.Size(118, 28);
            this.dptitle.TabIndex = 69;
            this.dptitle.Value = new System.DateTime(2022, 9, 26, 0, 0, 0, 0);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnSave.Image = global::ROMS.Properties.Resources.save;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(230, 137);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(84, 29);
            this.btnSave.TabIndex = 25;
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
            this.btnClose.Location = new System.Drawing.Point(316, 137);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 29);
            this.btnClose.TabIndex = 26;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            this.btnClose.Enter += new System.EventHandler(this.btnClose_Enter);
            this.btnClose.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnClose_KeyDown);
            this.btnClose.Leave += new System.EventHandler(this.btnClose_Leave);
            // 
            // CP_ProductHSN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(443, 215);
            this.Controls.Add(this.grbform);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CP_ProductHSN";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HSN Details";
            this.Load += new System.EventHandler(this.CP_Company_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CP_Company_KeyDown);
            this.Leave += new System.EventHandler(this.CP_Company_Leave);
            this.grbform.ResumeLayout(false);
            this.grbform.PerformLayout();
            this.grpStatus.ResumeLayout(false);
            this.grpStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errCompany)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtDHsnName;
        private System.Windows.Forms.TextBox txtHSNName;
        private System.Windows.Forms.TextBox txtDHsnCode;
        private System.Windows.Forms.TextBox txtHSNCode;
        private System.Windows.Forms.TextBox txtDSGT;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox grbform;
        private System.Windows.Forms.ErrorProvider errCompany;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.RadioButton rbInactive;
        private System.Windows.Forms.RadioButton rbactive;
        private System.Windows.Forms.GroupBox grpStatus;
        private System.Windows.Forms.ComboBox cmbGST;
        private System.Windows.Forms.DateTimePicker dptitle;
        private System.Windows.Forms.TextBox txtDeffectivedate;
    }
}