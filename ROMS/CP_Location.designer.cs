namespace ROMS
{
    partial class CP_Location
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CP_Location));
            this.epLocation = new System.Windows.Forms.ErrorProvider(this.components);
            this.pnlStatus = new System.Windows.Forms.Panel();
            this.rbInactive = new System.Windows.Forms.RadioButton();
            this.rbActive = new System.Windows.Forms.RadioButton();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtDStatus = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlGodownType = new System.Windows.Forms.Panel();
            this.rbOutside = new System.Windows.Forms.RadioButton();
            this.rbInside = new System.Windows.Forms.RadioButton();
            this.txtDGodowntype = new System.Windows.Forms.TextBox();
            this.txtLocationNameInEnglish = new System.Windows.Forms.TextBox();
            this.txtDGodownName = new System.Windows.Forms.TextBox();
            this.grbGodown = new System.Windows.Forms.GroupBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.txtShortName = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.txtLocationNameInTamil = new System.Windows.Forms.TextBox();
            this.cmbStockApplicable = new System.Windows.Forms.ComboBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.cmbLocationType = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.cmbConcern = new System.Windows.Forms.ComboBox();
            this.txtConcern = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.epLocation)).BeginInit();
            this.pnlStatus.SuspendLayout();
            this.pnlGodownType.SuspendLayout();
            this.grbGodown.SuspendLayout();
            this.SuspendLayout();
            // 
            // epLocation
            // 
            this.epLocation.ContainerControl = this;
            // 
            // pnlStatus
            // 
            this.pnlStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlStatus.Controls.Add(this.rbInactive);
            this.pnlStatus.Controls.Add(this.rbActive);
            this.pnlStatus.Enabled = false;
            this.pnlStatus.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlStatus.Location = new System.Drawing.Point(203, 213);
            this.pnlStatus.Name = "pnlStatus";
            this.pnlStatus.Size = new System.Drawing.Size(288, 27);
            this.pnlStatus.TabIndex = 8;
            // 
            // rbInactive
            // 
            this.rbInactive.AutoSize = true;
            this.rbInactive.Font = new System.Drawing.Font("Oswald Regular", 9.75F);
            this.rbInactive.Location = new System.Drawing.Point(146, 1);
            this.rbInactive.Name = "rbInactive";
            this.rbInactive.Size = new System.Drawing.Size(63, 21);
            this.rbInactive.TabIndex = 9;
            this.rbInactive.Text = "Inactive";
            this.rbInactive.UseVisualStyleBackColor = true;
            this.rbInactive.Enter += new System.EventHandler(this.RbInactive_Enter);
            this.rbInactive.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RbInactive_KeyDown);
            this.rbInactive.Leave += new System.EventHandler(this.RbInactive_Leave);
            // 
            // rbActive
            // 
            this.rbActive.AutoSize = true;
            this.rbActive.Checked = true;
            this.rbActive.Font = new System.Drawing.Font("Oswald Regular", 9.75F);
            this.rbActive.Location = new System.Drawing.Point(29, 1);
            this.rbActive.Name = "rbActive";
            this.rbActive.Size = new System.Drawing.Size(54, 21);
            this.rbActive.TabIndex = 8;
            this.rbActive.TabStop = true;
            this.rbActive.Text = "Active";
            this.rbActive.UseVisualStyleBackColor = true;
            this.rbActive.Enter += new System.EventHandler(this.RbActive_Enter);
            this.rbActive.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RbActive_KeyDown);
            this.rbActive.Leave += new System.EventHandler(this.RbActive_Leave);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnSave.Image = global::ROMS.Properties.Resources.save;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(329, 255);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(84, 29);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.Enter += new System.EventHandler(this.btnSave_Enter);
            this.btnSave.Leave += new System.EventHandler(this.btnSave_Leave);
            // 
            // txtDStatus
            // 
            this.txtDStatus.BackColor = System.Drawing.SystemColors.Control;
            this.txtDStatus.Enabled = false;
            this.txtDStatus.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDStatus.Location = new System.Drawing.Point(22, 213);
            this.txtDStatus.Name = "txtDStatus";
            this.txtDStatus.ReadOnly = true;
            this.txtDStatus.Size = new System.Drawing.Size(181, 27);
            this.txtDStatus.TabIndex = 19;
            this.txtDStatus.Text = "Status";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnClose.Image = global::ROMS.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(417, 255);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 29);
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            this.btnClose.Enter += new System.EventHandler(this.btnClose_Enter);
            this.btnClose.Leave += new System.EventHandler(this.btnClose_Leave);
            // 
            // pnlGodownType
            // 
            this.pnlGodownType.AutoScroll = true;
            this.pnlGodownType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlGodownType.Controls.Add(this.rbOutside);
            this.pnlGodownType.Controls.Add(this.rbInside);
            this.pnlGodownType.Enabled = false;
            this.pnlGodownType.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlGodownType.Location = new System.Drawing.Point(203, 159);
            this.pnlGodownType.Name = "pnlGodownType";
            this.pnlGodownType.Size = new System.Drawing.Size(288, 27);
            this.pnlGodownType.TabIndex = 5;
            // 
            // rbOutside
            // 
            this.rbOutside.AutoSize = true;
            this.rbOutside.Font = new System.Drawing.Font("Oswald Regular", 9.75F);
            this.rbOutside.Location = new System.Drawing.Point(146, 1);
            this.rbOutside.Name = "rbOutside";
            this.rbOutside.Size = new System.Drawing.Size(62, 21);
            this.rbOutside.TabIndex = 6;
            this.rbOutside.Text = "Outside";
            this.rbOutside.UseVisualStyleBackColor = true;
            this.rbOutside.Enter += new System.EventHandler(this.Rboutside_Enter);
            this.rbOutside.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Rboutside_KeyDown);
            this.rbOutside.Leave += new System.EventHandler(this.Rboutside_Leave);
            // 
            // rbInside
            // 
            this.rbInside.AutoSize = true;
            this.rbInside.Checked = true;
            this.rbInside.Font = new System.Drawing.Font("Oswald Regular", 9.75F);
            this.rbInside.Location = new System.Drawing.Point(29, 1);
            this.rbInside.Name = "rbInside";
            this.rbInside.Size = new System.Drawing.Size(54, 21);
            this.rbInside.TabIndex = 5;
            this.rbInside.TabStop = true;
            this.rbInside.Text = "Inside";
            this.rbInside.UseVisualStyleBackColor = true;
            this.rbInside.Enter += new System.EventHandler(this.RbInside_Enter);
            this.rbInside.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RbInside_KeyDown);
            this.rbInside.Leave += new System.EventHandler(this.RbInside_Leave);
            // 
            // txtDGodowntype
            // 
            this.txtDGodowntype.BackColor = System.Drawing.SystemColors.Control;
            this.txtDGodowntype.Enabled = false;
            this.txtDGodowntype.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDGodowntype.Location = new System.Drawing.Point(22, 159);
            this.txtDGodowntype.Name = "txtDGodowntype";
            this.txtDGodowntype.ReadOnly = true;
            this.txtDGodowntype.Size = new System.Drawing.Size(181, 27);
            this.txtDGodowntype.TabIndex = 21;
            this.txtDGodowntype.Text = "Godown Type";
            // 
            // txtLocationNameInEnglish
            // 
            this.txtLocationNameInEnglish.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLocationNameInEnglish.Location = new System.Drawing.Point(203, 78);
            this.txtLocationNameInEnglish.MaxLength = 20;
            this.txtLocationNameInEnglish.Name = "txtLocationNameInEnglish";
            this.txtLocationNameInEnglish.Size = new System.Drawing.Size(288, 27);
            this.txtLocationNameInEnglish.TabIndex = 2;
            this.txtLocationNameInEnglish.Enter += new System.EventHandler(this.TxtLocationNameInEnglish_Enter);
            this.txtLocationNameInEnglish.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtLocationNameInEnglish_KeyDown);
            this.txtLocationNameInEnglish.Leave += new System.EventHandler(this.TxtLocationNameInEnglish_Leave);
            // 
            // txtDGodownName
            // 
            this.txtDGodownName.BackColor = System.Drawing.SystemColors.Control;
            this.txtDGodownName.Enabled = false;
            this.txtDGodownName.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDGodownName.Location = new System.Drawing.Point(22, 78);
            this.txtDGodownName.Name = "txtDGodownName";
            this.txtDGodownName.ReadOnly = true;
            this.txtDGodownName.Size = new System.Drawing.Size(181, 27);
            this.txtDGodownName.TabIndex = 6;
            this.txtDGodownName.Text = "Location Name in English";
            // 
            // grbGodown
            // 
            this.grbGodown.Controls.Add(this.textBox4);
            this.grbGodown.Controls.Add(this.txtShortName);
            this.grbGodown.Controls.Add(this.textBox3);
            this.grbGodown.Controls.Add(this.txtLocationNameInTamil);
            this.grbGodown.Controls.Add(this.cmbStockApplicable);
            this.grbGodown.Controls.Add(this.textBox2);
            this.grbGodown.Controls.Add(this.cmbLocationType);
            this.grbGodown.Controls.Add(this.textBox1);
            this.grbGodown.Controls.Add(this.cmbConcern);
            this.grbGodown.Controls.Add(this.txtConcern);
            this.grbGodown.Controls.Add(this.txtDGodownName);
            this.grbGodown.Controls.Add(this.txtLocationNameInEnglish);
            this.grbGodown.Controls.Add(this.txtDGodowntype);
            this.grbGodown.Controls.Add(this.pnlGodownType);
            this.grbGodown.Controls.Add(this.btnClose);
            this.grbGodown.Controls.Add(this.txtDStatus);
            this.grbGodown.Controls.Add(this.btnSave);
            this.grbGodown.Controls.Add(this.pnlStatus);
            this.grbGodown.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbGodown.Location = new System.Drawing.Point(12, 3);
            this.grbGodown.Name = "grbGodown";
            this.grbGodown.Size = new System.Drawing.Size(511, 295);
            this.grbGodown.TabIndex = 1;
            this.grbGodown.TabStop = false;
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.SystemColors.Control;
            this.textBox4.Enabled = false;
            this.textBox4.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.Location = new System.Drawing.Point(22, 132);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(181, 27);
            this.textBox4.TabIndex = 57;
            this.textBox4.Text = "Short Name";
            // 
            // txtShortName
            // 
            this.txtShortName.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtShortName.Location = new System.Drawing.Point(203, 132);
            this.txtShortName.MaxLength = 10;
            this.txtShortName.Name = "txtShortName";
            this.txtShortName.Size = new System.Drawing.Size(288, 27);
            this.txtShortName.TabIndex = 4;
            this.txtShortName.Enter += new System.EventHandler(this.TxtShortName_Enter);
            this.txtShortName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtShortName_KeyDown);
            this.txtShortName.Leave += new System.EventHandler(this.TxtShortName_Leave);
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.SystemColors.Control;
            this.textBox3.Enabled = false;
            this.textBox3.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(22, 105);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(181, 27);
            this.textBox3.TabIndex = 55;
            this.textBox3.Text = "Location Name in Tamil";
            // 
            // txtLocationNameInTamil
            // 
            this.txtLocationNameInTamil.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLocationNameInTamil.Location = new System.Drawing.Point(203, 105);
            this.txtLocationNameInTamil.MaxLength = 20;
            this.txtLocationNameInTamil.Name = "txtLocationNameInTamil";
            this.txtLocationNameInTamil.Size = new System.Drawing.Size(288, 27);
            this.txtLocationNameInTamil.TabIndex = 3;
            this.txtLocationNameInTamil.Enter += new System.EventHandler(this.TxtLocationNameInTamil_Enter);
            this.txtLocationNameInTamil.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtLocationNameInTamil_KeyDown);
            this.txtLocationNameInTamil.Leave += new System.EventHandler(this.TxtLocationNameInTamil_Leave);
            // 
            // cmbStockApplicable
            // 
            this.cmbStockApplicable.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStockApplicable.FormattingEnabled = true;
            this.cmbStockApplicable.Location = new System.Drawing.Point(203, 186);
            this.cmbStockApplicable.Name = "cmbStockApplicable";
            this.cmbStockApplicable.Size = new System.Drawing.Size(288, 27);
            this.cmbStockApplicable.TabIndex = 7;
            this.cmbStockApplicable.SelectedIndexChanged += new System.EventHandler(this.CmbStockApplicable_SelectedIndexChanged);
            this.cmbStockApplicable.Enter += new System.EventHandler(this.CmbStockApplicable_Enter);
            this.cmbStockApplicable.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbStockApplicable_KeyDown);
            this.cmbStockApplicable.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbStockApplicable_KeyPress);
            this.cmbStockApplicable.Leave += new System.EventHandler(this.CmbStockApplicable_Leave);
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.Control;
            this.textBox2.Enabled = false;
            this.textBox2.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.textBox2.Location = new System.Drawing.Point(22, 186);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(181, 27);
            this.textBox2.TabIndex = 53;
            this.textBox2.Text = "Stock Applicable";
            // 
            // cmbLocationType
            // 
            this.cmbLocationType.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLocationType.FormattingEnabled = true;
            this.cmbLocationType.Location = new System.Drawing.Point(203, 51);
            this.cmbLocationType.Name = "cmbLocationType";
            this.cmbLocationType.Size = new System.Drawing.Size(288, 27);
            this.cmbLocationType.TabIndex = 1;
            this.cmbLocationType.Enter += new System.EventHandler(this.CmbLocationType_Enter);
            this.cmbLocationType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbLocationType_KeyDown);
            this.cmbLocationType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbLocationType_KeyPress);
            this.cmbLocationType.Leave += new System.EventHandler(this.CmbLocationType_Leave);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.textBox1.Location = new System.Drawing.Point(22, 51);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(181, 27);
            this.textBox1.TabIndex = 51;
            this.textBox1.Text = "Location Type";
            // 
            // cmbConcern
            // 
            this.cmbConcern.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbConcern.FormattingEnabled = true;
            this.cmbConcern.Location = new System.Drawing.Point(203, 24);
            this.cmbConcern.Name = "cmbConcern";
            this.cmbConcern.Size = new System.Drawing.Size(288, 27);
            this.cmbConcern.TabIndex = 0;
            this.cmbConcern.SelectedIndexChanged += new System.EventHandler(this.CmbConcern_SelectedIndexChanged);
            this.cmbConcern.Enter += new System.EventHandler(this.CmbConcern_Enter);
            this.cmbConcern.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbConcern_KeyDown);
            this.cmbConcern.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbConcern_KeyPress);
            this.cmbConcern.Leave += new System.EventHandler(this.CmbConcern_Leave);
            // 
            // txtConcern
            // 
            this.txtConcern.BackColor = System.Drawing.SystemColors.Control;
            this.txtConcern.Enabled = false;
            this.txtConcern.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtConcern.Location = new System.Drawing.Point(22, 24);
            this.txtConcern.Name = "txtConcern";
            this.txtConcern.ReadOnly = true;
            this.txtConcern.Size = new System.Drawing.Size(181, 27);
            this.txtConcern.TabIndex = 49;
            this.txtConcern.Text = "Concern";
            // 
            // CP_Location
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(539, 308);
            this.Controls.Add(this.grbGodown);
            this.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CP_Location";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stock Location";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CP_Location_FormClosing);
            this.Load += new System.EventHandler(this.CP_Location_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CP_Location_KeyDown);
            this.Leave += new System.EventHandler(this.CP_Location_Leave);
            ((System.ComponentModel.ISupportInitialize)(this.epLocation)).EndInit();
            this.pnlStatus.ResumeLayout(false);
            this.pnlStatus.PerformLayout();
            this.pnlGodownType.ResumeLayout(false);
            this.pnlGodownType.PerformLayout();
            this.grbGodown.ResumeLayout(false);
            this.grbGodown.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ErrorProvider epLocation;
        private System.Windows.Forms.GroupBox grbGodown;
        private System.Windows.Forms.ComboBox cmbConcern;
        private System.Windows.Forms.TextBox txtConcern;
        private System.Windows.Forms.TextBox txtDGodownName;
        private System.Windows.Forms.TextBox txtLocationNameInEnglish;
        private System.Windows.Forms.TextBox txtDGodowntype;
        private System.Windows.Forms.Panel pnlGodownType;
        private System.Windows.Forms.RadioButton rbOutside;
        private System.Windows.Forms.RadioButton rbInside;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtDStatus;
        private System.Windows.Forms.Panel pnlStatus;
        private System.Windows.Forms.RadioButton rbInactive;
        private System.Windows.Forms.RadioButton rbActive;
        private System.Windows.Forms.ComboBox cmbLocationType;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox cmbStockApplicable;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox txtLocationNameInTamil;
        public System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox txtShortName;
    }
}