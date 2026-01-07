namespace ROMS
{
    partial class CP_CardMachine
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CP_CardMachine));
            this.txtDProvider = new System.Windows.Forms.TextBox();
            this.txtDMachineName = new System.Windows.Forms.TextBox();
            this.grbform = new System.Windows.Forms.GroupBox();
            this.cmbProvider = new System.Windows.Forms.ComboBox();
            this.cmbBank = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.cmbConcern = new System.Windows.Forms.ComboBox();
            this.txtDRouteOrderNo = new System.Windows.Forms.TextBox();
            this.txtMachineName = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.pnlStatus = new System.Windows.Forms.Panel();
            this.rbActive = new System.Windows.Forms.RadioButton();
            this.rbInActive = new System.Windows.Forms.RadioButton();
            this.epRoute = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtDEMCNo = new System.Windows.Forms.TextBox();
            this.txtDEPIDNo = new System.Windows.Forms.TextBox();
            this.txtMCNo = new System.Windows.Forms.TextBox();
            this.txtPIDNo = new System.Windows.Forms.TextBox();
            this.txtDEBrand = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.grbform.SuspendLayout();
            this.pnlStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epRoute)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDProvider
            // 
            this.txtDProvider.BackColor = System.Drawing.SystemColors.Control;
            this.txtDProvider.Enabled = false;
            this.txtDProvider.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDProvider.Location = new System.Drawing.Point(6, 140);
            this.txtDProvider.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtDProvider.Name = "txtDProvider";
            this.txtDProvider.ReadOnly = true;
            this.txtDProvider.Size = new System.Drawing.Size(128, 28);
            this.txtDProvider.TabIndex = 6;
            this.txtDProvider.Text = "Provider";
            // 
            // txtDMachineName
            // 
            this.txtDMachineName.BackColor = System.Drawing.SystemColors.Control;
            this.txtDMachineName.Enabled = false;
            this.txtDMachineName.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDMachineName.Location = new System.Drawing.Point(6, 24);
            this.txtDMachineName.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtDMachineName.Name = "txtDMachineName";
            this.txtDMachineName.ReadOnly = true;
            this.txtDMachineName.Size = new System.Drawing.Size(128, 28);
            this.txtDMachineName.TabIndex = 7;
            this.txtDMachineName.Text = "Machine Name";
            // 
            // grbform
            // 
            this.grbform.Controls.Add(this.textBox2);
            this.grbform.Controls.Add(this.txtDEBrand);
            this.grbform.Controls.Add(this.txtPIDNo);
            this.grbform.Controls.Add(this.txtMCNo);
            this.grbform.Controls.Add(this.txtDEPIDNo);
            this.grbform.Controls.Add(this.txtDEMCNo);
            this.grbform.Controls.Add(this.cmbProvider);
            this.grbform.Controls.Add(this.cmbBank);
            this.grbform.Controls.Add(this.textBox1);
            this.grbform.Controls.Add(this.cmbConcern);
            this.grbform.Controls.Add(this.txtDRouteOrderNo);
            this.grbform.Controls.Add(this.txtMachineName);
            this.grbform.Controls.Add(this.btnClose);
            this.grbform.Controls.Add(this.btnSave);
            this.grbform.Controls.Add(this.txtStatus);
            this.grbform.Controls.Add(this.txtDProvider);
            this.grbform.Controls.Add(this.txtDMachineName);
            this.grbform.Controls.Add(this.pnlStatus);
            this.grbform.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.grbform.Location = new System.Drawing.Point(10, 1);
            this.grbform.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.grbform.Name = "grbform";
            this.grbform.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.grbform.Size = new System.Drawing.Size(379, 305);
            this.grbform.TabIndex = 28;
            this.grbform.TabStop = false;
            // 
            // cmbProvider
            // 
            this.cmbProvider.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbProvider.FormattingEnabled = true;
            this.cmbProvider.Location = new System.Drawing.Point(134, 140);
            this.cmbProvider.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbProvider.Name = "cmbProvider";
            this.cmbProvider.Size = new System.Drawing.Size(235, 27);
            this.cmbProvider.TabIndex = 1;
            this.cmbProvider.SelectedIndexChanged += new System.EventHandler(this.cmbProvider_SelectedIndexChanged);
            this.cmbProvider.Enter += new System.EventHandler(this.cmbProvider_Enter);
            this.cmbProvider.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbProvider_KeyDown);
            this.cmbProvider.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbProvider_KeyPress);
            this.cmbProvider.Leave += new System.EventHandler(this.cmbProvider_Leave);
            // 
            // cmbBank
            // 
            this.cmbBank.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBank.FormattingEnabled = true;
            this.cmbBank.Location = new System.Drawing.Point(134, 195);
            this.cmbBank.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbBank.Name = "cmbBank";
            this.cmbBank.Size = new System.Drawing.Size(235, 27);
            this.cmbBank.TabIndex = 3;
            this.cmbBank.Enter += new System.EventHandler(this.cmbBank_Enter);
            this.cmbBank.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbBank_KeyDown);
            this.cmbBank.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbBank_KeyPress);
            this.cmbBank.Leave += new System.EventHandler(this.cmbBank_Leave);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(8, 195);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(128, 27);
            this.textBox1.TabIndex = 1111148;
            this.textBox1.Text = "Linked Bank A/C";
            // 
            // cmbConcern
            // 
            this.cmbConcern.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbConcern.FormattingEnabled = true;
            this.cmbConcern.Location = new System.Drawing.Point(134, 168);
            this.cmbConcern.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbConcern.Name = "cmbConcern";
            this.cmbConcern.Size = new System.Drawing.Size(235, 27);
            this.cmbConcern.TabIndex = 2;
            this.cmbConcern.SelectedIndexChanged += new System.EventHandler(this.cmbConcern_SelectedIndexChanged);
            this.cmbConcern.Enter += new System.EventHandler(this.cmbRSNo_Enter);
            this.cmbConcern.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbRSNo_KeyDown);
            this.cmbConcern.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbRSNo_KeyPress);
            this.cmbConcern.Leave += new System.EventHandler(this.cmbRSNo_Leave);
            // 
            // txtDRouteOrderNo
            // 
            this.txtDRouteOrderNo.BackColor = System.Drawing.SystemColors.Control;
            this.txtDRouteOrderNo.Enabled = false;
            this.txtDRouteOrderNo.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDRouteOrderNo.Location = new System.Drawing.Point(6, 168);
            this.txtDRouteOrderNo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDRouteOrderNo.Name = "txtDRouteOrderNo";
            this.txtDRouteOrderNo.ReadOnly = true;
            this.txtDRouteOrderNo.Size = new System.Drawing.Size(128, 27);
            this.txtDRouteOrderNo.TabIndex = 1111146;
            this.txtDRouteOrderNo.Text = "Concern";
            // 
            // txtMachineName
            // 
            this.txtMachineName.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMachineName.Location = new System.Drawing.Point(134, 24);
            this.txtMachineName.MaxLength = 50;
            this.txtMachineName.Name = "txtMachineName";
            this.txtMachineName.Size = new System.Drawing.Size(235, 28);
            this.txtMachineName.TabIndex = 0;
            this.txtMachineName.Enter += new System.EventHandler(this.txtREName_Enter);
            this.txtMachineName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtREName_KeyDown);
            this.txtMachineName.Leave += new System.EventHandler(this.txtREName_Leave);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::ROMS.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(288, 258);
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
            this.btnSave.Location = new System.Drawing.Point(202, 258);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 33);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.Enter += new System.EventHandler(this.btnSave_Enter);
            this.btnSave.Leave += new System.EventHandler(this.btnSave_Leave);
            // 
            // txtStatus
            // 
            this.txtStatus.BackColor = System.Drawing.SystemColors.Control;
            this.txtStatus.Enabled = false;
            this.txtStatus.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStatus.Location = new System.Drawing.Point(6, 222);
            this.txtStatus.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(128, 28);
            this.txtStatus.TabIndex = 8;
            this.txtStatus.Text = "Status";
            // 
            // pnlStatus
            // 
            this.pnlStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlStatus.Controls.Add(this.rbActive);
            this.pnlStatus.Controls.Add(this.rbInActive);
            this.pnlStatus.Location = new System.Drawing.Point(134, 222);
            this.pnlStatus.Name = "pnlStatus";
            this.pnlStatus.Size = new System.Drawing.Size(235, 28);
            this.pnlStatus.TabIndex = 4;
            // 
            // rbActive
            // 
            this.rbActive.AutoSize = true;
            this.rbActive.Checked = true;
            this.rbActive.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbActive.Location = new System.Drawing.Point(39, 1);
            this.rbActive.Name = "rbActive";
            this.rbActive.Size = new System.Drawing.Size(60, 24);
            this.rbActive.TabIndex = 4;
            this.rbActive.TabStop = true;
            this.rbActive.Text = "Active";
            this.rbActive.UseVisualStyleBackColor = true;
            this.rbActive.Enter += new System.EventHandler(this.RbActive_Enter);
            this.rbActive.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rbActive_KeyDown);
            this.rbActive.Leave += new System.EventHandler(this.RbActive_Leave);
            // 
            // rbInActive
            // 
            this.rbInActive.AutoSize = true;
            this.rbInActive.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbInActive.Location = new System.Drawing.Point(117, 1);
            this.rbInActive.Name = "rbInActive";
            this.rbInActive.Size = new System.Drawing.Size(70, 24);
            this.rbInActive.TabIndex = 5;
            this.rbInActive.Text = "Inactive";
            this.rbInActive.UseVisualStyleBackColor = true;
            this.rbInActive.Enter += new System.EventHandler(this.RbInActive_Enter);
            this.rbInActive.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rbInActive_KeyDown);
            this.rbInActive.Leave += new System.EventHandler(this.RbInActive_Leave);
            // 
            // epRoute
            // 
            this.epRoute.ContainerControl = this;
            // 
            // txtDEMCNo
            // 
            this.txtDEMCNo.BackColor = System.Drawing.SystemColors.Control;
            this.txtDEMCNo.Enabled = false;
            this.txtDEMCNo.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDEMCNo.Location = new System.Drawing.Point(6, 53);
            this.txtDEMCNo.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtDEMCNo.Name = "txtDEMCNo";
            this.txtDEMCNo.ReadOnly = true;
            this.txtDEMCNo.Size = new System.Drawing.Size(128, 28);
            this.txtDEMCNo.TabIndex = 1111149;
            this.txtDEMCNo.Text = "M/C No.";
            // 
            // txtDEPIDNo
            // 
            this.txtDEPIDNo.BackColor = System.Drawing.SystemColors.Control;
            this.txtDEPIDNo.Enabled = false;
            this.txtDEPIDNo.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDEPIDNo.Location = new System.Drawing.Point(6, 82);
            this.txtDEPIDNo.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtDEPIDNo.Name = "txtDEPIDNo";
            this.txtDEPIDNo.ReadOnly = true;
            this.txtDEPIDNo.Size = new System.Drawing.Size(128, 28);
            this.txtDEPIDNo.TabIndex = 1111150;
            this.txtDEPIDNo.Text = "PID No.";
            // 
            // txtMCNo
            // 
            this.txtMCNo.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMCNo.Location = new System.Drawing.Point(134, 53);
            this.txtMCNo.MaxLength = 50;
            this.txtMCNo.Name = "txtMCNo";
            this.txtMCNo.Size = new System.Drawing.Size(235, 28);
            this.txtMCNo.TabIndex = 1111151;
            // 
            // txtPIDNo
            // 
            this.txtPIDNo.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPIDNo.Location = new System.Drawing.Point(134, 82);
            this.txtPIDNo.MaxLength = 50;
            this.txtPIDNo.Name = "txtPIDNo";
            this.txtPIDNo.Size = new System.Drawing.Size(235, 28);
            this.txtPIDNo.TabIndex = 1111152;
            // 
            // txtDEBrand
            // 
            this.txtDEBrand.BackColor = System.Drawing.SystemColors.Control;
            this.txtDEBrand.Enabled = false;
            this.txtDEBrand.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDEBrand.Location = new System.Drawing.Point(6, 111);
            this.txtDEBrand.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtDEBrand.Name = "txtDEBrand";
            this.txtDEBrand.ReadOnly = true;
            this.txtDEBrand.Size = new System.Drawing.Size(128, 28);
            this.txtDEBrand.TabIndex = 1111153;
            this.txtDEBrand.Text = "Brand Name";
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(134, 111);
            this.textBox2.MaxLength = 50;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(235, 28);
            this.textBox2.TabIndex = 1111154;
            // 
            // CP_CardMachine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(399, 320);
            this.Controls.Add(this.grbform);
            this.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CP_CardMachine";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Card Machine Details";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CP_Route_FormClosing);
            this.Load += new System.EventHandler(this.CP_Route_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CP_Route_KeyDown);
            this.Leave += new System.EventHandler(this.CP_Route_Leave);
            this.grbform.ResumeLayout(false);
            this.grbform.PerformLayout();
            this.pnlStatus.ResumeLayout(false);
            this.pnlStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epRoute)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtDProvider;
        private System.Windows.Forms.TextBox txtDMachineName;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox grbform;
        private System.Windows.Forms.ErrorProvider epRoute;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.RadioButton rbInActive;
        private System.Windows.Forms.RadioButton rbActive;
        private System.Windows.Forms.Panel pnlStatus;
        public System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtMachineName;
        private System.Windows.Forms.ComboBox cmbConcern;
        private System.Windows.Forms.TextBox txtDRouteOrderNo;
        private System.Windows.Forms.ComboBox cmbBank;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox cmbProvider;
        private System.Windows.Forms.TextBox txtDEPIDNo;
        private System.Windows.Forms.TextBox txtDEMCNo;
        private System.Windows.Forms.TextBox txtPIDNo;
        private System.Windows.Forms.TextBox txtMCNo;
        private System.Windows.Forms.TextBox txtDEBrand;
        private System.Windows.Forms.TextBox textBox2;
    }
}