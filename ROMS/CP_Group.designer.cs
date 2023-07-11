namespace ROMS
{
    partial class CP_Group
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CP_Group));
            this.grbform = new System.Windows.Forms.GroupBox();
            this.txtDEGroupNameTamil = new System.Windows.Forms.TextBox();
            this.txtEGroupNameTamil = new System.Windows.Forms.TextBox();
            this.txtDStatus = new System.Windows.Forms.TextBox();
            this.pnlStatus = new System.Windows.Forms.Panel();
            this.rbActive = new System.Windows.Forms.RadioButton();
            this.rbInactive = new System.Windows.Forms.RadioButton();
            this.txtDEGroupNameEnglish = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtEGroupNameEnglish = new System.Windows.Forms.TextBox();
            this.errGroup = new System.Windows.Forms.ErrorProvider(this.components);
            this.grbform.SuspendLayout();
            this.pnlStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errGroup)).BeginInit();
            this.SuspendLayout();
            // 
            // grbform
            // 
            this.grbform.Controls.Add(this.txtDEGroupNameTamil);
            this.grbform.Controls.Add(this.txtEGroupNameTamil);
            this.grbform.Controls.Add(this.txtDStatus);
            this.grbform.Controls.Add(this.pnlStatus);
            this.grbform.Controls.Add(this.txtDEGroupNameEnglish);
            this.grbform.Controls.Add(this.btnClose);
            this.grbform.Controls.Add(this.btnSave);
            this.grbform.Controls.Add(this.txtEGroupNameEnglish);
            this.grbform.Location = new System.Drawing.Point(16, 10);
            this.grbform.Name = "grbform";
            this.grbform.Size = new System.Drawing.Size(552, 160);
            this.grbform.TabIndex = 0;
            this.grbform.TabStop = false;
            this.grbform.Enter += new System.EventHandler(this.Grbform_Enter);
            // 
            // txtDEGroupNameTamil
            // 
            this.txtDEGroupNameTamil.BackColor = System.Drawing.SystemColors.Control;
            this.txtDEGroupNameTamil.Enabled = false;
            this.txtDEGroupNameTamil.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDEGroupNameTamil.Location = new System.Drawing.Point(40, 47);
            this.txtDEGroupNameTamil.Name = "txtDEGroupNameTamil";
            this.txtDEGroupNameTamil.ReadOnly = true;
            this.txtDEGroupNameTamil.Size = new System.Drawing.Size(181, 27);
            this.txtDEGroupNameTamil.TabIndex = 19;
            this.txtDEGroupNameTamil.Text = "Group Name In Tamil";
            // 
            // txtEGroupNameTamil
            // 
            this.txtEGroupNameTamil.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEGroupNameTamil.Location = new System.Drawing.Point(221, 47);
            this.txtEGroupNameTamil.MaxLength = 50;
            this.txtEGroupNameTamil.Name = "txtEGroupNameTamil";
            this.txtEGroupNameTamil.Size = new System.Drawing.Size(288, 27);
            this.txtEGroupNameTamil.TabIndex = 1;
            this.txtEGroupNameTamil.Enter += new System.EventHandler(this.TxtEGroupNameTamil_Enter);
            this.txtEGroupNameTamil.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtEGroupNameTamil_KeyDown);
            this.txtEGroupNameTamil.Leave += new System.EventHandler(this.TxtEGroupNameTamil_Leave);
            // 
            // txtDStatus
            // 
            this.txtDStatus.BackColor = System.Drawing.SystemColors.Control;
            this.txtDStatus.Enabled = false;
            this.txtDStatus.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDStatus.Location = new System.Drawing.Point(40, 73);
            this.txtDStatus.Name = "txtDStatus";
            this.txtDStatus.ReadOnly = true;
            this.txtDStatus.Size = new System.Drawing.Size(181, 27);
            this.txtDStatus.TabIndex = 17;
            this.txtDStatus.Text = "Status";
            // 
            // pnlStatus
            // 
            this.pnlStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlStatus.Controls.Add(this.rbActive);
            this.pnlStatus.Controls.Add(this.rbInactive);
            this.pnlStatus.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlStatus.Location = new System.Drawing.Point(221, 73);
            this.pnlStatus.Name = "pnlStatus";
            this.pnlStatus.Size = new System.Drawing.Size(288, 27);
            this.pnlStatus.TabIndex = 2;
            // 
            // rbActive
            // 
            this.rbActive.AutoSize = true;
            this.rbActive.Checked = true;
            this.rbActive.Font = new System.Drawing.Font("Oswald Regular", 9.75F);
            this.rbActive.Location = new System.Drawing.Point(66, 1);
            this.rbActive.Name = "rbActive";
            this.rbActive.Size = new System.Drawing.Size(54, 21);
            this.rbActive.TabIndex = 2;
            this.rbActive.TabStop = true;
            this.rbActive.Text = "Active";
            this.rbActive.UseVisualStyleBackColor = true;
            this.rbActive.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RbActive_KeyDown);
            // 
            // rbInactive
            // 
            this.rbInactive.AutoSize = true;
            this.rbInactive.Font = new System.Drawing.Font("Oswald Regular", 9.75F);
            this.rbInactive.Location = new System.Drawing.Point(145, 1);
            this.rbInactive.Name = "rbInactive";
            this.rbInactive.Size = new System.Drawing.Size(63, 21);
            this.rbInactive.TabIndex = 3;
            this.rbInactive.Text = "Inactive";
            this.rbInactive.UseVisualStyleBackColor = true;
            this.rbInactive.CheckedChanged += new System.EventHandler(this.RbInactive_CheckedChanged);
            this.rbInactive.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RbInactive_KeyDown);
            // 
            // txtDEGroupNameEnglish
            // 
            this.txtDEGroupNameEnglish.BackColor = System.Drawing.SystemColors.Control;
            this.txtDEGroupNameEnglish.Enabled = false;
            this.txtDEGroupNameEnglish.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDEGroupNameEnglish.Location = new System.Drawing.Point(40, 21);
            this.txtDEGroupNameEnglish.Name = "txtDEGroupNameEnglish";
            this.txtDEGroupNameEnglish.ReadOnly = true;
            this.txtDEGroupNameEnglish.Size = new System.Drawing.Size(181, 27);
            this.txtDEGroupNameEnglish.TabIndex = 11;
            this.txtDEGroupNameEnglish.Text = "Group Name In English";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnClose.Image = global::ROMS.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(434, 116);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 29);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            this.btnClose.Enter += new System.EventHandler(this.btnClose_Enter);
            this.btnClose.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnClose_KeyDown);
            this.btnClose.Leave += new System.EventHandler(this.btnClose_Leave);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnSave.Image = global::ROMS.Properties.Resources.save;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(344, 116);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(84, 29);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.Enter += new System.EventHandler(this.btnSave_Enter);
            this.btnSave.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnSave_KeyDown);
            this.btnSave.Leave += new System.EventHandler(this.btnSave_Leave);
            // 
            // txtEGroupNameEnglish
            // 
            this.txtEGroupNameEnglish.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEGroupNameEnglish.Location = new System.Drawing.Point(221, 21);
            this.txtEGroupNameEnglish.MaxLength = 50;
            this.txtEGroupNameEnglish.Name = "txtEGroupNameEnglish";
            this.txtEGroupNameEnglish.Size = new System.Drawing.Size(288, 27);
            this.txtEGroupNameEnglish.TabIndex = 0;
            this.txtEGroupNameEnglish.Enter += new System.EventHandler(this.txtEGroupNameEnglish_Enter);
            this.txtEGroupNameEnglish.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtEGroupNameEnglish_KeyDown);
            this.txtEGroupNameEnglish.Leave += new System.EventHandler(this.txtEGroupNameEnglish_Leave);
            // 
            // errGroup
            // 
            this.errGroup.ContainerControl = this;
            // 
            // CP_Group
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(585, 187);
            this.Controls.Add(this.grbform);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CP_Group";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Group";
            this.Load += new System.EventHandler(this.CP_Group_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CP_Group_KeyDown);
            this.grbform.ResumeLayout(false);
            this.grbform.PerformLayout();
            this.pnlStatus.ResumeLayout(false);
            this.pnlStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errGroup)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox grbform;
        private System.Windows.Forms.TextBox txtDEGroupNameEnglish;
        private System.Windows.Forms.TextBox txtEGroupNameEnglish;
        private System.Windows.Forms.ErrorProvider errGroup;
        private System.Windows.Forms.TextBox txtDStatus;
        private System.Windows.Forms.Panel pnlStatus;
        private System.Windows.Forms.RadioButton rbInactive;
        private System.Windows.Forms.RadioButton rbActive;
        private System.Windows.Forms.TextBox txtDEGroupNameTamil;
        private System.Windows.Forms.TextBox txtEGroupNameTamil;
    }
}