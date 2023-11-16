namespace ROMS
{
    partial class CP_UserCategory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CP_UserCategory));
            this.pnlStatus = new System.Windows.Forms.Panel();
            this.rbInactive = new System.Windows.Forms.RadioButton();
            this.rbActive = new System.Windows.Forms.RadioButton();
            this.txtDStatus = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.grbUserCategory = new System.Windows.Forms.GroupBox();
            this.cmbCTSINO = new System.Windows.Forms.ComboBox();
            this.txtOrderNo = new System.Windows.Forms.TextBox();
            this.txtDCategoryName = new System.Windows.Forms.TextBox();
            this.txtCategoryName = new System.Windows.Forms.TextBox();
            this.epUserCategory = new System.Windows.Forms.ErrorProvider(this.components);
            this.pnlStatus.SuspendLayout();
            this.grbUserCategory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epUserCategory)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlStatus
            // 
            this.pnlStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlStatus.Controls.Add(this.rbInactive);
            this.pnlStatus.Controls.Add(this.rbActive);
            this.pnlStatus.Enabled = false;
            this.pnlStatus.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlStatus.Location = new System.Drawing.Point(197, 80);
            this.pnlStatus.Name = "pnlStatus";
            this.pnlStatus.Size = new System.Drawing.Size(288, 27);
            this.pnlStatus.TabIndex = 2;
            // 
            // rbInactive
            // 
            this.rbInactive.AutoSize = true;
            this.rbInactive.Font = new System.Drawing.Font("Oswald Regular", 9.75F);
            this.rbInactive.Location = new System.Drawing.Point(143, 3);
            this.rbInactive.Name = "rbInactive";
            this.rbInactive.Size = new System.Drawing.Size(63, 21);
            this.rbInactive.TabIndex = 3;
            this.rbInactive.Text = "Inactive";
            this.rbInactive.UseVisualStyleBackColor = true;
            this.rbInactive.Enter += new System.EventHandler(this.rbInactive_Enter);
            this.rbInactive.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rbInactive_KeyDown);
            this.rbInactive.Leave += new System.EventHandler(this.rbInactive_Leave);
            // 
            // rbActive
            // 
            this.rbActive.AutoSize = true;
            this.rbActive.Checked = true;
            this.rbActive.Font = new System.Drawing.Font("Oswald Regular", 9.75F);
            this.rbActive.Location = new System.Drawing.Point(54, 3);
            this.rbActive.Name = "rbActive";
            this.rbActive.Size = new System.Drawing.Size(54, 21);
            this.rbActive.TabIndex = 2;
            this.rbActive.TabStop = true;
            this.rbActive.Text = "Active";
            this.rbActive.UseVisualStyleBackColor = true;
            this.rbActive.Enter += new System.EventHandler(this.RbActive_Enter);
            this.rbActive.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rbActive_KeyDown);
            this.rbActive.Leave += new System.EventHandler(this.rbActive_Leave);
            // 
            // txtDStatus
            // 
            this.txtDStatus.BackColor = System.Drawing.SystemColors.Control;
            this.txtDStatus.Enabled = false;
            this.txtDStatus.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDStatus.Location = new System.Drawing.Point(17, 80);
            this.txtDStatus.Name = "txtDStatus";
            this.txtDStatus.ReadOnly = true;
            this.txtDStatus.Size = new System.Drawing.Size(181, 27);
            this.txtDStatus.TabIndex = 15;
            this.txtDStatus.Text = "Status";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnSave.Image = global::ROMS.Properties.Resources.save;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(320, 113);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(84, 29);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.Enter += new System.EventHandler(this.btnSave_Enter);
            this.btnSave.Leave += new System.EventHandler(this.btnSave_Leave);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnClose.Image = global::ROMS.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(410, 113);
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
            // grbUserCategory
            // 
            this.grbUserCategory.Controls.Add(this.cmbCTSINO);
            this.grbUserCategory.Controls.Add(this.txtOrderNo);
            this.grbUserCategory.Controls.Add(this.txtDCategoryName);
            this.grbUserCategory.Controls.Add(this.txtCategoryName);
            this.grbUserCategory.Controls.Add(this.btnClose);
            this.grbUserCategory.Controls.Add(this.txtDStatus);
            this.grbUserCategory.Controls.Add(this.btnSave);
            this.grbUserCategory.Controls.Add(this.pnlStatus);
            this.grbUserCategory.Location = new System.Drawing.Point(17, 4);
            this.grbUserCategory.Name = "grbUserCategory";
            this.grbUserCategory.Size = new System.Drawing.Size(503, 158);
            this.grbUserCategory.TabIndex = 0;
            this.grbUserCategory.TabStop = false;
            // 
            // cmbCTSINO
            // 
            this.cmbCTSINO.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCTSINO.FormattingEnabled = true;
            this.cmbCTSINO.Location = new System.Drawing.Point(197, 53);
            this.cmbCTSINO.Name = "cmbCTSINO";
            this.cmbCTSINO.Size = new System.Drawing.Size(288, 27);
            this.cmbCTSINO.TabIndex = 1;
            this.cmbCTSINO.Enter += new System.EventHandler(this.CmbCTSINO_Enter);
            this.cmbCTSINO.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbCTSINO_KeyDown);
            this.cmbCTSINO.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbCTSINO_KeyPress);
            this.cmbCTSINO.Leave += new System.EventHandler(this.CmbCTSINO_Leave);
            // 
            // txtOrderNo
            // 
            this.txtOrderNo.BackColor = System.Drawing.SystemColors.Control;
            this.txtOrderNo.Enabled = false;
            this.txtOrderNo.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOrderNo.Location = new System.Drawing.Point(17, 53);
            this.txtOrderNo.Name = "txtOrderNo";
            this.txtOrderNo.ReadOnly = true;
            this.txtOrderNo.Size = new System.Drawing.Size(181, 27);
            this.txtOrderNo.TabIndex = 20;
            this.txtOrderNo.Text = "Order No.";
            // 
            // txtDCategoryName
            // 
            this.txtDCategoryName.BackColor = System.Drawing.SystemColors.Control;
            this.txtDCategoryName.Enabled = false;
            this.txtDCategoryName.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDCategoryName.Location = new System.Drawing.Point(17, 26);
            this.txtDCategoryName.Name = "txtDCategoryName";
            this.txtDCategoryName.ReadOnly = true;
            this.txtDCategoryName.Size = new System.Drawing.Size(181, 27);
            this.txtDCategoryName.TabIndex = 19;
            this.txtDCategoryName.Text = "Employee Category";
            // 
            // txtCategoryName
            // 
            this.txtCategoryName.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCategoryName.Location = new System.Drawing.Point(197, 26);
            this.txtCategoryName.MaxLength = 20;
            this.txtCategoryName.Name = "txtCategoryName";
            this.txtCategoryName.Size = new System.Drawing.Size(288, 27);
            this.txtCategoryName.TabIndex = 0;
            this.txtCategoryName.Enter += new System.EventHandler(this.TxtCategoryName_Enter);
            this.txtCategoryName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtCategoryName_KeyDown);
            this.txtCategoryName.Leave += new System.EventHandler(this.TxtCategoryName_Leave);
            // 
            // epUserCategory
            // 
            this.epUserCategory.ContainerControl = this;
            // 
            // CP_UserCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(540, 175);
            this.Controls.Add(this.grbUserCategory);
            this.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CP_UserCategory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Employee Category";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CP_UserCategory_FormClosing);
            this.Load += new System.EventHandler(this.CP_UserCategory_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CP_UserCategory_KeyDown);
            this.pnlStatus.ResumeLayout(false);
            this.pnlStatus.PerformLayout();
            this.grbUserCategory.ResumeLayout(false);
            this.grbUserCategory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epUserCategory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.RadioButton rbInactive;
        private System.Windows.Forms.RadioButton rbActive;
        private System.Windows.Forms.TextBox txtDStatus;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox grbUserCategory;
        private System.Windows.Forms.ErrorProvider epUserCategory;
        private System.Windows.Forms.TextBox txtDCategoryName;
        public System.Windows.Forms.Button btnSave;
        public System.Windows.Forms.Panel pnlStatus;
        public System.Windows.Forms.TextBox txtCategoryName;
        private System.Windows.Forms.TextBox txtOrderNo;
        public System.Windows.Forms.ComboBox cmbCTSINO;
    }
}