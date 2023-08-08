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
            this.txtDUnitName.Location = new System.Drawing.Point(37, 46);
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
            this.txtEUnitName.Location = new System.Drawing.Point(159, 46);
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
            this.grbform.Size = new System.Drawing.Size(558, 218);
            this.grbform.TabIndex = 28;
            this.grbform.TabStop = false;
            // 
            // cmbNoOfDecimals
            // 
            this.cmbNoOfDecimals.FormattingEnabled = true;
            this.cmbNoOfDecimals.Location = new System.Drawing.Point(159, 102);
            this.cmbNoOfDecimals.Name = "cmbNoOfDecimals";
            this.cmbNoOfDecimals.Size = new System.Drawing.Size(361, 28);
            this.cmbNoOfDecimals.TabIndex = 2;
            this.cmbNoOfDecimals.SelectedIndexChanged += new System.EventHandler(this.CmbNoOfDecimals_SelectedIndexChanged);
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
            this.txtDNoOfDecimals.Location = new System.Drawing.Point(37, 102);
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
            this.txtDSymbol.Location = new System.Drawing.Point(37, 74);
            this.txtDSymbol.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtDSymbol.Name = "txtDSymbol";
            this.txtDSymbol.ReadOnly = true;
            this.txtDSymbol.Size = new System.Drawing.Size(122, 28);
            this.txtDSymbol.TabIndex = 10;
            this.txtDSymbol.Text = "Symbol";
            // 
            // txtSymbol
            // 
            this.txtSymbol.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSymbol.Location = new System.Drawing.Point(159, 74);
            this.txtSymbol.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtSymbol.MaxLength = 5;
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
            this.btnClose.Location = new System.Drawing.Point(440, 166);
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
            this.btnSave.Location = new System.Drawing.Point(356, 166);
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
            // txtStatus
            // 
            this.txtStatus.BackColor = System.Drawing.SystemColors.Control;
            this.txtStatus.Enabled = false;
            this.txtStatus.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStatus.Location = new System.Drawing.Point(37, 130);
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
            this.pnlStatus.Location = new System.Drawing.Point(159, 130);
            this.pnlStatus.Name = "pnlStatus";
            this.pnlStatus.Size = new System.Drawing.Size(361, 28);
            this.pnlStatus.TabIndex = 3;
            // 
            // rbInActive
            // 
            this.rbInActive.AutoSize = true;
            this.rbInActive.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbInActive.Location = new System.Drawing.Point(188, 1);
            this.rbInActive.Name = "rbInActive";
            this.rbInActive.Size = new System.Drawing.Size(70, 24);
            this.rbInActive.TabIndex = 4;
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
            this.rbActive.TabIndex = 3;
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
            // CP_Unit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(585, 251);
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
    }
}