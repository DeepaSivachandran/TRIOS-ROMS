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
            this.errGodown = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panelStatus = new System.Windows.Forms.Panel();
            this.rbInactive = new System.Windows.Forms.RadioButton();
            this.rbActive = new System.Windows.Forms.RadioButton();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtDStatus = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlGodownType = new System.Windows.Forms.Panel();
            this.rboutside = new System.Windows.Forms.RadioButton();
            this.rbInside = new System.Windows.Forms.RadioButton();
            this.txtDGodowntype = new System.Windows.Forms.TextBox();
            this.txtGodownName = new System.Windows.Forms.TextBox();
            this.txtDGodownName = new System.Windows.Forms.TextBox();
            this.grbGodown = new System.Windows.Forms.GroupBox();
            this.cmbConcern = new System.Windows.Forms.ComboBox();
            this.txtConcern = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.errGodown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.panelStatus.SuspendLayout();
            this.pnlGodownType.SuspendLayout();
            this.grbGodown.SuspendLayout();
            this.SuspendLayout();
            // 
            // errGodown
            // 
            this.errGodown.ContainerControl = this;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // panelStatus
            // 
            this.panelStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelStatus.Controls.Add(this.rbInactive);
            this.panelStatus.Controls.Add(this.rbActive);
            this.panelStatus.Enabled = false;
            this.panelStatus.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelStatus.Location = new System.Drawing.Point(196, 105);
            this.panelStatus.Name = "panelStatus";
            this.panelStatus.Size = new System.Drawing.Size(288, 27);
            this.panelStatus.TabIndex = 3;
            // 
            // rbInactive
            // 
            this.rbInactive.AutoSize = true;
            this.rbInactive.Font = new System.Drawing.Font("Oswald Regular", 9.75F);
            this.rbInactive.Location = new System.Drawing.Point(146, 1);
            this.rbInactive.Name = "rbInactive";
            this.rbInactive.Size = new System.Drawing.Size(63, 21);
            this.rbInactive.TabIndex = 5;
            this.rbInactive.Text = "Inactive";
            this.rbInactive.UseVisualStyleBackColor = true;
            this.rbInactive.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RbInactive_KeyDown);
            // 
            // rbActive
            // 
            this.rbActive.AutoSize = true;
            this.rbActive.Checked = true;
            this.rbActive.Font = new System.Drawing.Font("Oswald Regular", 9.75F);
            this.rbActive.Location = new System.Drawing.Point(29, 1);
            this.rbActive.Name = "rbActive";
            this.rbActive.Size = new System.Drawing.Size(54, 21);
            this.rbActive.TabIndex = 4;
            this.rbActive.TabStop = true;
            this.rbActive.Text = "Active";
            this.rbActive.UseVisualStyleBackColor = true;
            this.rbActive.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RbActive_KeyDown);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnSave.Image = global::ROMS.Properties.Resources.save;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(322, 138);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(84, 29);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.Enter += new System.EventHandler(this.btnSave_Enter);
            this.btnSave.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnSave_KeyDown);
            this.btnSave.Leave += new System.EventHandler(this.btnSave_Leave);
            // 
            // txtDStatus
            // 
            this.txtDStatus.BackColor = System.Drawing.SystemColors.Control;
            this.txtDStatus.Enabled = false;
            this.txtDStatus.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDStatus.Location = new System.Drawing.Point(15, 105);
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
            this.btnClose.Location = new System.Drawing.Point(410, 138);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 29);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            this.btnClose.Enter += new System.EventHandler(this.btnClose_Enter);
            this.btnClose.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnClose_KeyDown);
            this.btnClose.Leave += new System.EventHandler(this.btnClose_Leave);
            // 
            // pnlGodownType
            // 
            this.pnlGodownType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlGodownType.Controls.Add(this.rboutside);
            this.pnlGodownType.Controls.Add(this.rbInside);
            this.pnlGodownType.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlGodownType.Location = new System.Drawing.Point(196, 78);
            this.pnlGodownType.Name = "pnlGodownType";
            this.pnlGodownType.Size = new System.Drawing.Size(288, 27);
            this.pnlGodownType.TabIndex = 1;
            // 
            // rboutside
            // 
            this.rboutside.AutoSize = true;
            this.rboutside.Font = new System.Drawing.Font("Oswald Regular", 9.75F);
            this.rboutside.Location = new System.Drawing.Point(146, 1);
            this.rboutside.Name = "rboutside";
            this.rboutside.Size = new System.Drawing.Size(62, 21);
            this.rboutside.TabIndex = 3;
            this.rboutside.Text = "Outside";
            this.rboutside.UseVisualStyleBackColor = true;
            this.rboutside.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Rboutside_KeyDown);
            // 
            // rbInside
            // 
            this.rbInside.AutoSize = true;
            this.rbInside.Checked = true;
            this.rbInside.Font = new System.Drawing.Font("Oswald Regular", 9.75F);
            this.rbInside.Location = new System.Drawing.Point(29, 1);
            this.rbInside.Name = "rbInside";
            this.rbInside.Size = new System.Drawing.Size(54, 21);
            this.rbInside.TabIndex = 2;
            this.rbInside.TabStop = true;
            this.rbInside.Text = "Inside";
            this.rbInside.UseVisualStyleBackColor = true;
            // 
            // txtDGodowntype
            // 
            this.txtDGodowntype.BackColor = System.Drawing.SystemColors.Control;
            this.txtDGodowntype.Enabled = false;
            this.txtDGodowntype.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDGodowntype.Location = new System.Drawing.Point(15, 78);
            this.txtDGodowntype.Name = "txtDGodowntype";
            this.txtDGodowntype.ReadOnly = true;
            this.txtDGodowntype.Size = new System.Drawing.Size(181, 27);
            this.txtDGodowntype.TabIndex = 21;
            this.txtDGodowntype.Text = "Godown Type";
            // 
            // txtGodownName
            // 
            this.txtGodownName.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGodownName.Location = new System.Drawing.Point(196, 51);
            this.txtGodownName.MaxLength = 50;
            this.txtGodownName.Name = "txtGodownName";
            this.txtGodownName.Size = new System.Drawing.Size(288, 27);
            this.txtGodownName.TabIndex = 1;
            this.txtGodownName.Enter += new System.EventHandler(this.txtLocationName_Enter);
            this.txtGodownName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLocationName_KeyDown);
            this.txtGodownName.Leave += new System.EventHandler(this.txtLocationName_Leave);
            // 
            // txtDGodownName
            // 
            this.txtDGodownName.BackColor = System.Drawing.SystemColors.Control;
            this.txtDGodownName.Enabled = false;
            this.txtDGodownName.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDGodownName.Location = new System.Drawing.Point(15, 51);
            this.txtDGodownName.Name = "txtDGodownName";
            this.txtDGodownName.ReadOnly = true;
            this.txtDGodownName.Size = new System.Drawing.Size(181, 27);
            this.txtDGodownName.TabIndex = 6;
            this.txtDGodownName.Text = "Godown Name";
            // 
            // grbGodown
            // 
            this.grbGodown.Controls.Add(this.cmbConcern);
            this.grbGodown.Controls.Add(this.txtConcern);
            this.grbGodown.Controls.Add(this.txtDGodownName);
            this.grbGodown.Controls.Add(this.txtGodownName);
            this.grbGodown.Controls.Add(this.txtDGodowntype);
            this.grbGodown.Controls.Add(this.pnlGodownType);
            this.grbGodown.Controls.Add(this.btnClose);
            this.grbGodown.Controls.Add(this.txtDStatus);
            this.grbGodown.Controls.Add(this.btnSave);
            this.grbGodown.Controls.Add(this.panelStatus);
            this.grbGodown.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbGodown.Location = new System.Drawing.Point(12, 3);
            this.grbGodown.Name = "grbGodown";
            this.grbGodown.Size = new System.Drawing.Size(498, 182);
            this.grbGodown.TabIndex = 1;
            this.grbGodown.TabStop = false;
            this.grbGodown.Enter += new System.EventHandler(this.GrbGodown_Enter);
            // 
            // cmbConcern
            // 
            this.cmbConcern.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbConcern.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbConcern.FormattingEnabled = true;
            this.cmbConcern.Location = new System.Drawing.Point(196, 24);
            this.cmbConcern.Name = "cmbConcern";
            this.cmbConcern.Size = new System.Drawing.Size(288, 27);
            this.cmbConcern.TabIndex = 48;
            // 
            // txtConcern
            // 
            this.txtConcern.BackColor = System.Drawing.SystemColors.Control;
            this.txtConcern.Enabled = false;
            this.txtConcern.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtConcern.Location = new System.Drawing.Point(15, 24);
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
            this.ClientSize = new System.Drawing.Size(526, 200);
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
            this.Text = "Godown";
            this.Load += new System.EventHandler(this.CP_Location_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CP_Location_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.errGodown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.panelStatus.ResumeLayout(false);
            this.panelStatus.PerformLayout();
            this.pnlGodownType.ResumeLayout(false);
            this.pnlGodownType.PerformLayout();
            this.grbGodown.ResumeLayout(false);
            this.grbGodown.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ErrorProvider errGodown;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.GroupBox grbGodown;
        private System.Windows.Forms.ComboBox cmbConcern;
        private System.Windows.Forms.TextBox txtConcern;
        private System.Windows.Forms.TextBox txtDGodownName;
        private System.Windows.Forms.TextBox txtGodownName;
        private System.Windows.Forms.TextBox txtDGodowntype;
        private System.Windows.Forms.Panel pnlGodownType;
        private System.Windows.Forms.RadioButton rboutside;
        private System.Windows.Forms.RadioButton rbInside;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtDStatus;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel panelStatus;
        private System.Windows.Forms.RadioButton rbInactive;
        private System.Windows.Forms.RadioButton rbActive;
    }
}