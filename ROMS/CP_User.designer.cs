namespace ROMS
{
    partial class CP_User
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CP_User));
            this.txtDLoginID = new System.Windows.Forms.TextBox();
            this.txtLoginID = new System.Windows.Forms.TextBox();
            this.txtDUserName = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtDPassword = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtDCPassword = new System.Windows.Forms.TextBox();
            this.txtCPassword = new System.Windows.Forms.TextBox();
            this.pnlStatus = new System.Windows.Forms.Panel();
            this.rbInactive = new System.Windows.Forms.RadioButton();
            this.rbActive = new System.Windows.Forms.RadioButton();
            this.txtDStatus = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.grbForm = new System.Windows.Forms.GroupBox();
            this.btnUserRoleMapped = new System.Windows.Forms.Button();
            this.cmbPasskey = new System.Windows.Forms.ComboBox();
            this.cmbUserRole = new System.Windows.Forms.ComboBox();
            this.txtDUserRole = new System.Windows.Forms.TextBox();
            this.txtDPassKey = new System.Windows.Forms.TextBox();
            this.epUser = new System.Windows.Forms.ErrorProvider(this.components);
            this.grdLocation = new System.Windows.Forms.DataGridView();
            this.pnlStatus.SuspendLayout();
            this.grbForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLocation)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDLoginID
            // 
            this.txtDLoginID.BackColor = System.Drawing.SystemColors.Control;
            this.txtDLoginID.Enabled = false;
            this.txtDLoginID.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDLoginID.Location = new System.Drawing.Point(24, 51);
            this.txtDLoginID.Name = "txtDLoginID";
            this.txtDLoginID.ReadOnly = true;
            this.txtDLoginID.Size = new System.Drawing.Size(181, 27);
            this.txtDLoginID.TabIndex = 11;
            this.txtDLoginID.Text = "Login ID";
            // 
            // txtLoginID
            // 
            this.txtLoginID.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLoginID.Location = new System.Drawing.Point(204, 51);
            this.txtLoginID.MaxLength = 15;
            this.txtLoginID.Name = "txtLoginID";
            this.txtLoginID.Size = new System.Drawing.Size(288, 27);
            this.txtLoginID.TabIndex = 1;
            this.txtLoginID.Enter += new System.EventHandler(this.txtLoginID_Enter);
            this.txtLoginID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLoginID_KeyDown);
            this.txtLoginID.Leave += new System.EventHandler(this.txtLoginID_Leave);
            // 
            // txtDUserName
            // 
            this.txtDUserName.BackColor = System.Drawing.SystemColors.Control;
            this.txtDUserName.Enabled = false;
            this.txtDUserName.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDUserName.Location = new System.Drawing.Point(24, 24);
            this.txtDUserName.Name = "txtDUserName";
            this.txtDUserName.ReadOnly = true;
            this.txtDUserName.Size = new System.Drawing.Size(181, 27);
            this.txtDUserName.TabIndex = 10;
            this.txtDUserName.Text = "Name of the System User";
            // 
            // txtUserName
            // 
            this.txtUserName.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserName.Location = new System.Drawing.Point(204, 24);
            this.txtUserName.MaxLength = 30;
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(288, 27);
            this.txtUserName.TabIndex = 0;
            this.txtUserName.Enter += new System.EventHandler(this.TxtUserName_Enter);
            this.txtUserName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtUserName_KeyDown);
            this.txtUserName.Leave += new System.EventHandler(this.txtUserName_Leave);
            // 
            // txtDPassword
            // 
            this.txtDPassword.BackColor = System.Drawing.SystemColors.Control;
            this.txtDPassword.Enabled = false;
            this.txtDPassword.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDPassword.Location = new System.Drawing.Point(24, 105);
            this.txtDPassword.Name = "txtDPassword";
            this.txtDPassword.ReadOnly = true;
            this.txtDPassword.Size = new System.Drawing.Size(181, 27);
            this.txtDPassword.TabIndex = 12;
            this.txtDPassword.Text = "Password";
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(204, 105);
            this.txtPassword.MaxLength = 50;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(288, 27);
            this.txtPassword.TabIndex = 4;
            this.txtPassword.Enter += new System.EventHandler(this.txtPassword_Enter);
            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);
            this.txtPassword.Leave += new System.EventHandler(this.txtPassword_Leave);
            // 
            // txtDCPassword
            // 
            this.txtDCPassword.BackColor = System.Drawing.SystemColors.Control;
            this.txtDCPassword.Enabled = false;
            this.txtDCPassword.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDCPassword.Location = new System.Drawing.Point(24, 132);
            this.txtDCPassword.Name = "txtDCPassword";
            this.txtDCPassword.ReadOnly = true;
            this.txtDCPassword.Size = new System.Drawing.Size(181, 27);
            this.txtDCPassword.TabIndex = 13;
            this.txtDCPassword.Text = "Confirm Password";
            // 
            // txtCPassword
            // 
            this.txtCPassword.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCPassword.Location = new System.Drawing.Point(204, 132);
            this.txtCPassword.MaxLength = 50;
            this.txtCPassword.Name = "txtCPassword";
            this.txtCPassword.PasswordChar = '*';
            this.txtCPassword.Size = new System.Drawing.Size(288, 27);
            this.txtCPassword.TabIndex = 5;
            this.txtCPassword.Enter += new System.EventHandler(this.txtCPassword_Enter);
            this.txtCPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCPassword_KeyDown);
            this.txtCPassword.Leave += new System.EventHandler(this.txtCPassword_Leave);
            // 
            // pnlStatus
            // 
            this.pnlStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlStatus.Controls.Add(this.rbInactive);
            this.pnlStatus.Controls.Add(this.rbActive);
            this.pnlStatus.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlStatus.Location = new System.Drawing.Point(204, 186);
            this.pnlStatus.Name = "pnlStatus";
            this.pnlStatus.Size = new System.Drawing.Size(288, 27);
            this.pnlStatus.TabIndex = 7;
            // 
            // rbInactive
            // 
            this.rbInactive.AutoSize = true;
            this.rbInactive.Font = new System.Drawing.Font("Oswald Regular", 9.75F);
            this.rbInactive.Location = new System.Drawing.Point(150, 1);
            this.rbInactive.Name = "rbInactive";
            this.rbInactive.Size = new System.Drawing.Size(63, 21);
            this.rbInactive.TabIndex = 8;
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
            this.rbActive.Location = new System.Drawing.Point(62, 1);
            this.rbActive.Name = "rbActive";
            this.rbActive.Size = new System.Drawing.Size(54, 21);
            this.rbActive.TabIndex = 7;
            this.rbActive.TabStop = true;
            this.rbActive.Text = "Active";
            this.rbActive.UseVisualStyleBackColor = true;
            this.rbActive.Enter += new System.EventHandler(this.rbActive_Enter);
            this.rbActive.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rbActive_KeyDown);
            this.rbActive.Leave += new System.EventHandler(this.rbActive_Leave);
            // 
            // txtDStatus
            // 
            this.txtDStatus.BackColor = System.Drawing.SystemColors.Control;
            this.txtDStatus.Enabled = false;
            this.txtDStatus.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDStatus.Location = new System.Drawing.Point(24, 186);
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
            this.btnSave.Location = new System.Drawing.Point(597, 223);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(84, 29);
            this.btnSave.TabIndex = 9;
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
            this.btnClose.Location = new System.Drawing.Point(687, 223);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 29);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            this.btnClose.Enter += new System.EventHandler(this.btnClose_Enter);
            this.btnClose.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnClose_KeyDown);
            this.btnClose.Leave += new System.EventHandler(this.btnClose_Leave);
            // 
            // grbForm
            // 
            this.grbForm.Controls.Add(this.btnUserRoleMapped);
            this.grbForm.Controls.Add(this.cmbPasskey);
            this.grbForm.Controls.Add(this.cmbUserRole);
            this.grbForm.Controls.Add(this.txtDUserRole);
            this.grbForm.Controls.Add(this.txtDPassKey);
            this.grbForm.Controls.Add(this.txtDPassword);
            this.grbForm.Controls.Add(this.txtDCPassword);
            this.grbForm.Controls.Add(this.txtCPassword);
            this.grbForm.Controls.Add(this.txtPassword);
            this.grbForm.Controls.Add(this.btnClose);
            this.grbForm.Controls.Add(this.txtDStatus);
            this.grbForm.Controls.Add(this.btnSave);
            this.grbForm.Controls.Add(this.pnlStatus);
            this.grbForm.Controls.Add(this.txtDLoginID);
            this.grbForm.Controls.Add(this.txtLoginID);
            this.grbForm.Controls.Add(this.txtDUserName);
            this.grbForm.Controls.Add(this.txtUserName);
            this.grbForm.Location = new System.Drawing.Point(17, 4);
            this.grbForm.Name = "grbForm";
            this.grbForm.Size = new System.Drawing.Size(779, 261);
            this.grbForm.TabIndex = 0;
            this.grbForm.TabStop = false;
            // 
            // btnUserRoleMapped
            // 
            this.btnUserRoleMapped.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnUserRoleMapped.Image = global::ROMS.Properties.Resources.Convertion;
            this.btnUserRoleMapped.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUserRoleMapped.Location = new System.Drawing.Point(465, 78);
            this.btnUserRoleMapped.Name = "btnUserRoleMapped";
            this.btnUserRoleMapped.Size = new System.Drawing.Size(27, 27);
            this.btnUserRoleMapped.TabIndex = 21;
            this.btnUserRoleMapped.UseVisualStyleBackColor = true;
            this.btnUserRoleMapped.Click += new System.EventHandler(this.btnUserRoleMapped_Click);
            // 
            // cmbPasskey
            // 
            this.cmbPasskey.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPasskey.FormattingEnabled = true;
            this.cmbPasskey.Items.AddRange(new object[] {
            "Required",
            "Not  Required"});
            this.cmbPasskey.Location = new System.Drawing.Point(204, 159);
            this.cmbPasskey.Name = "cmbPasskey";
            this.cmbPasskey.Size = new System.Drawing.Size(288, 27);
            this.cmbPasskey.TabIndex = 6;
            this.cmbPasskey.SelectedIndexChanged += new System.EventHandler(this.CmbPasskey_SelectedIndexChanged);
            this.cmbPasskey.Enter += new System.EventHandler(this.CmbPasskey_Enter);
            this.cmbPasskey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbPasskey_KeyDown);
            this.cmbPasskey.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbPasskey_KeyPress);
            this.cmbPasskey.Leave += new System.EventHandler(this.CmbPasskey_Leave);
            // 
            // cmbUserRole
            // 
            this.cmbUserRole.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbUserRole.FormattingEnabled = true;
            this.cmbUserRole.Location = new System.Drawing.Point(204, 78);
            this.cmbUserRole.Name = "cmbUserRole";
            this.cmbUserRole.Size = new System.Drawing.Size(255, 27);
            this.cmbUserRole.TabIndex = 3;
            this.cmbUserRole.SelectedIndexChanged += new System.EventHandler(this.CmbUserRole_SelectedIndexChanged);
            this.cmbUserRole.Enter += new System.EventHandler(this.CmbUserRole_Enter);
            this.cmbUserRole.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbUserRole_KeyDown);
            this.cmbUserRole.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbUserRole_KeyPress);
            this.cmbUserRole.Leave += new System.EventHandler(this.CmbUserRole_Leave);
            // 
            // txtDUserRole
            // 
            this.txtDUserRole.BackColor = System.Drawing.SystemColors.Control;
            this.txtDUserRole.Enabled = false;
            this.txtDUserRole.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDUserRole.Location = new System.Drawing.Point(24, 78);
            this.txtDUserRole.Name = "txtDUserRole";
            this.txtDUserRole.ReadOnly = true;
            this.txtDUserRole.Size = new System.Drawing.Size(181, 27);
            this.txtDUserRole.TabIndex = 20;
            this.txtDUserRole.Text = "User Role";
            // 
            // txtDPassKey
            // 
            this.txtDPassKey.BackColor = System.Drawing.SystemColors.Control;
            this.txtDPassKey.Enabled = false;
            this.txtDPassKey.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDPassKey.Location = new System.Drawing.Point(24, 159);
            this.txtDPassKey.Name = "txtDPassKey";
            this.txtDPassKey.ReadOnly = true;
            this.txtDPassKey.Size = new System.Drawing.Size(181, 27);
            this.txtDPassKey.TabIndex = 17;
            this.txtDPassKey.Text = "Pass Key";
            // 
            // epUser
            // 
            this.epUser.ContainerControl = this;
            // 
            // grdLocation
            // 
            this.grdLocation.AllowUserToAddRows = false;
            this.grdLocation.AllowUserToDeleteRows = false;
            this.grdLocation.AllowUserToResizeColumns = false;
            this.grdLocation.AllowUserToResizeRows = false;
            this.grdLocation.BackgroundColor = System.Drawing.Color.White;
            this.grdLocation.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdLocation.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdLocation.ColumnHeadersHeight = 30;
            this.grdLocation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdLocation.EnableHeadersVisualStyles = false;
            this.grdLocation.GridColor = System.Drawing.Color.White;
            this.grdLocation.Location = new System.Drawing.Point(515, 31);
            this.grdLocation.Name = "grdLocation";
            this.grdLocation.RowHeadersVisible = false;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            this.grdLocation.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.grdLocation.RowTemplate.Height = 25;
            this.grdLocation.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.grdLocation.Size = new System.Drawing.Size(264, 186);
            this.grdLocation.StandardTab = true;
            this.grdLocation.TabIndex = 9;
            // 
            // CP_User
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(813, 274);
            this.Controls.Add(this.grdLocation);
            this.Controls.Add(this.grbForm);
            this.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CP_User";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CP_User_FormClosing);
            this.Load += new System.EventHandler(this.CP_User_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CP_User_KeyDown);
            this.Leave += new System.EventHandler(this.CP_User_Leave);
            this.pnlStatus.ResumeLayout(false);
            this.pnlStatus.PerformLayout();
            this.grbForm.ResumeLayout(false);
            this.grbForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLocation)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtDLoginID;
        private System.Windows.Forms.TextBox txtLoginID;
        private System.Windows.Forms.TextBox txtDUserName;
        private System.Windows.Forms.TextBox txtDPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtDCPassword;
        private System.Windows.Forms.TextBox txtCPassword;
        private System.Windows.Forms.Panel pnlStatus;
        private System.Windows.Forms.RadioButton rbInactive;
        private System.Windows.Forms.RadioButton rbActive;
        private System.Windows.Forms.TextBox txtDStatus;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox grbForm;
        private System.Windows.Forms.ErrorProvider epUser;
        private System.Windows.Forms.TextBox txtDPassKey;
        private System.Windows.Forms.TextBox txtDUserRole;
        private System.Windows.Forms.ComboBox cmbUserRole;
        private System.Windows.Forms.ComboBox cmbPasskey;
        public System.Windows.Forms.Button btnSave;
        public System.Windows.Forms.TextBox txtUserName;
        public System.Windows.Forms.DataGridView grdLocation;
        public System.Windows.Forms.Button btnUserRoleMapped;
    }
}