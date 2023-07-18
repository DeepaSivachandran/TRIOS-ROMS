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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CP_User));
            this.txtDLoginID = new System.Windows.Forms.TextBox();
            this.txtLoginID = new System.Windows.Forms.TextBox();
            this.txtDUserName = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtDPassword = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtDCPassword = new System.Windows.Forms.TextBox();
            this.txtCPassword = new System.Windows.Forms.TextBox();
            this.panelStatus = new System.Windows.Forms.Panel();
            this.rbInactive = new System.Windows.Forms.RadioButton();
            this.rbActive = new System.Windows.Forms.RadioButton();
            this.txtDStatus = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.grbForm = new System.Windows.Forms.GroupBox();
            this.cmbUserRole = new System.Windows.Forms.ComboBox();
            this.txtDUserRole = new System.Windows.Forms.TextBox();
            this.txtDConfirmPassKey = new System.Windows.Forms.TextBox();
            this.txtConfirmPasskey = new System.Windows.Forms.TextBox();
            this.txtDPassKey = new System.Windows.Forms.TextBox();
            this.txtPassKey = new System.Windows.Forms.TextBox();
            this.errUser = new System.Windows.Forms.ErrorProvider(this.components);
            this.cmbUserCatagory = new System.Windows.Forms.ComboBox();
            this.txtDUserCatagory = new System.Windows.Forms.TextBox();
            this.panelStatus.SuspendLayout();
            this.grbForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errUser)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDLoginID
            // 
            this.txtDLoginID.BackColor = System.Drawing.SystemColors.Control;
            this.txtDLoginID.Enabled = false;
            this.txtDLoginID.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDLoginID.Location = new System.Drawing.Point(19, 51);
            this.txtDLoginID.Name = "txtDLoginID";
            this.txtDLoginID.ReadOnly = true;
            this.txtDLoginID.Size = new System.Drawing.Size(181, 27);
            this.txtDLoginID.TabIndex = 11;
            this.txtDLoginID.Text = "Login ID";
            // 
            // txtLoginID
            // 
            this.txtLoginID.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLoginID.Location = new System.Drawing.Point(199, 51);
            this.txtLoginID.MaxLength = 20;
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
            this.txtDUserName.Location = new System.Drawing.Point(19, 24);
            this.txtDUserName.Name = "txtDUserName";
            this.txtDUserName.ReadOnly = true;
            this.txtDUserName.Size = new System.Drawing.Size(181, 27);
            this.txtDUserName.TabIndex = 10;
            this.txtDUserName.Text = "Name of the User";
            // 
            // txtUserName
            // 
            this.txtUserName.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserName.Location = new System.Drawing.Point(199, 24);
            this.txtUserName.MaxLength = 50;
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(288, 27);
            this.txtUserName.TabIndex = 0;
            this.txtUserName.Enter += new System.EventHandler(this.txtUserName_Enter);
            this.txtUserName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUserName_KeyDown);
            this.txtUserName.Leave += new System.EventHandler(this.txtUserName_Leave);
            // 
            // txtDPassword
            // 
            this.txtDPassword.BackColor = System.Drawing.SystemColors.Control;
            this.txtDPassword.Enabled = false;
            this.txtDPassword.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDPassword.Location = new System.Drawing.Point(19, 131);
            this.txtDPassword.Name = "txtDPassword";
            this.txtDPassword.ReadOnly = true;
            this.txtDPassword.Size = new System.Drawing.Size(181, 27);
            this.txtDPassword.TabIndex = 12;
            this.txtDPassword.Text = "Password";
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(199, 131);
            this.txtPassword.MaxLength = 20;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(288, 27);
            this.txtPassword.TabIndex = 2;
            this.txtPassword.Enter += new System.EventHandler(this.txtPassword_Enter);
            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);
            this.txtPassword.Leave += new System.EventHandler(this.txtPassword_Leave);
            // 
            // txtDCPassword
            // 
            this.txtDCPassword.BackColor = System.Drawing.SystemColors.Control;
            this.txtDCPassword.Enabled = false;
            this.txtDCPassword.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDCPassword.Location = new System.Drawing.Point(19, 158);
            this.txtDCPassword.Name = "txtDCPassword";
            this.txtDCPassword.ReadOnly = true;
            this.txtDCPassword.Size = new System.Drawing.Size(181, 27);
            this.txtDCPassword.TabIndex = 13;
            this.txtDCPassword.Text = "Confirm Password";
            // 
            // txtCPassword
            // 
            this.txtCPassword.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCPassword.Location = new System.Drawing.Point(199, 158);
            this.txtCPassword.MaxLength = 20;
            this.txtCPassword.Name = "txtCPassword";
            this.txtCPassword.PasswordChar = '*';
            this.txtCPassword.Size = new System.Drawing.Size(288, 27);
            this.txtCPassword.TabIndex = 3;
            this.txtCPassword.Enter += new System.EventHandler(this.txtCPassword_Enter);
            this.txtCPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCPassword_KeyDown);
            this.txtCPassword.Leave += new System.EventHandler(this.txtCPassword_Leave);
            // 
            // panelStatus
            // 
            this.panelStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelStatus.Controls.Add(this.rbInactive);
            this.panelStatus.Controls.Add(this.rbActive);
            this.panelStatus.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelStatus.Location = new System.Drawing.Point(199, 239);
            this.panelStatus.Name = "panelStatus";
            this.panelStatus.Size = new System.Drawing.Size(288, 27);
            this.panelStatus.TabIndex = 5;
            // 
            // rbInactive
            // 
            this.rbInactive.AutoSize = true;
            this.rbInactive.Font = new System.Drawing.Font("Oswald Regular", 9.75F);
            this.rbInactive.Location = new System.Drawing.Point(150, 1);
            this.rbInactive.Name = "rbInactive";
            this.rbInactive.Size = new System.Drawing.Size(63, 21);
            this.rbInactive.TabIndex = 7;
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
            this.rbActive.TabIndex = 6;
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
            this.txtDStatus.Location = new System.Drawing.Point(19, 239);
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
            this.btnSave.Location = new System.Drawing.Point(322, 275);
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
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnClose.Image = global::ROMS.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(412, 275);
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
            // grbForm
            // 
            this.grbForm.Controls.Add(this.cmbUserCatagory);
            this.grbForm.Controls.Add(this.txtDUserCatagory);
            this.grbForm.Controls.Add(this.cmbUserRole);
            this.grbForm.Controls.Add(this.txtDUserRole);
            this.grbForm.Controls.Add(this.txtDConfirmPassKey);
            this.grbForm.Controls.Add(this.txtConfirmPasskey);
            this.grbForm.Controls.Add(this.txtDPassKey);
            this.grbForm.Controls.Add(this.txtPassKey);
            this.grbForm.Controls.Add(this.txtDPassword);
            this.grbForm.Controls.Add(this.txtDCPassword);
            this.grbForm.Controls.Add(this.txtCPassword);
            this.grbForm.Controls.Add(this.txtPassword);
            this.grbForm.Controls.Add(this.btnClose);
            this.grbForm.Controls.Add(this.txtDStatus);
            this.grbForm.Controls.Add(this.btnSave);
            this.grbForm.Controls.Add(this.panelStatus);
            this.grbForm.Controls.Add(this.txtDLoginID);
            this.grbForm.Controls.Add(this.txtLoginID);
            this.grbForm.Controls.Add(this.txtDUserName);
            this.grbForm.Controls.Add(this.txtUserName);
            this.grbForm.Location = new System.Drawing.Point(17, 4);
            this.grbForm.Name = "grbForm";
            this.grbForm.Size = new System.Drawing.Size(507, 322);
            this.grbForm.TabIndex = 0;
            this.grbForm.TabStop = false;
            // 
            // cmbUserRole
            // 
            this.cmbUserRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUserRole.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbUserRole.FormattingEnabled = true;
            this.cmbUserRole.Location = new System.Drawing.Point(199, 104);
            this.cmbUserRole.Name = "cmbUserRole";
            this.cmbUserRole.Size = new System.Drawing.Size(288, 27);
            this.cmbUserRole.TabIndex = 21;
            // 
            // txtDUserRole
            // 
            this.txtDUserRole.BackColor = System.Drawing.SystemColors.Control;
            this.txtDUserRole.Enabled = false;
            this.txtDUserRole.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDUserRole.Location = new System.Drawing.Point(19, 104);
            this.txtDUserRole.Name = "txtDUserRole";
            this.txtDUserRole.ReadOnly = true;
            this.txtDUserRole.Size = new System.Drawing.Size(181, 27);
            this.txtDUserRole.TabIndex = 20;
            this.txtDUserRole.Text = "User Role";
            // 
            // txtDConfirmPassKey
            // 
            this.txtDConfirmPassKey.BackColor = System.Drawing.SystemColors.Control;
            this.txtDConfirmPassKey.Enabled = false;
            this.txtDConfirmPassKey.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDConfirmPassKey.Location = new System.Drawing.Point(19, 212);
            this.txtDConfirmPassKey.Name = "txtDConfirmPassKey";
            this.txtDConfirmPassKey.ReadOnly = true;
            this.txtDConfirmPassKey.Size = new System.Drawing.Size(181, 27);
            this.txtDConfirmPassKey.TabIndex = 19;
            this.txtDConfirmPassKey.Text = "Confirm Pass Key";
            // 
            // txtConfirmPasskey
            // 
            this.txtConfirmPasskey.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfirmPasskey.Location = new System.Drawing.Point(199, 212);
            this.txtConfirmPasskey.MaxLength = 20;
            this.txtConfirmPasskey.Name = "txtConfirmPasskey";
            this.txtConfirmPasskey.PasswordChar = '*';
            this.txtConfirmPasskey.Size = new System.Drawing.Size(288, 27);
            this.txtConfirmPasskey.TabIndex = 18;
            // 
            // txtDPassKey
            // 
            this.txtDPassKey.BackColor = System.Drawing.SystemColors.Control;
            this.txtDPassKey.Enabled = false;
            this.txtDPassKey.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDPassKey.Location = new System.Drawing.Point(19, 185);
            this.txtDPassKey.Name = "txtDPassKey";
            this.txtDPassKey.ReadOnly = true;
            this.txtDPassKey.Size = new System.Drawing.Size(181, 27);
            this.txtDPassKey.TabIndex = 17;
            this.txtDPassKey.Text = "Pass Key";
            // 
            // txtPassKey
            // 
            this.txtPassKey.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassKey.Location = new System.Drawing.Point(199, 185);
            this.txtPassKey.MaxLength = 20;
            this.txtPassKey.Name = "txtPassKey";
            this.txtPassKey.PasswordChar = '*';
            this.txtPassKey.Size = new System.Drawing.Size(288, 27);
            this.txtPassKey.TabIndex = 16;
            // 
            // errUser
            // 
            this.errUser.ContainerControl = this;
            // 
            // cmbUserCatagory
            // 
            this.cmbUserCatagory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUserCatagory.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbUserCatagory.FormattingEnabled = true;
            this.cmbUserCatagory.Location = new System.Drawing.Point(199, 77);
            this.cmbUserCatagory.Name = "cmbUserCatagory";
            this.cmbUserCatagory.Size = new System.Drawing.Size(288, 27);
            this.cmbUserCatagory.TabIndex = 23;
            // 
            // txtDUserCatagory
            // 
            this.txtDUserCatagory.BackColor = System.Drawing.SystemColors.Control;
            this.txtDUserCatagory.Enabled = false;
            this.txtDUserCatagory.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDUserCatagory.Location = new System.Drawing.Point(19, 77);
            this.txtDUserCatagory.Name = "txtDUserCatagory";
            this.txtDUserCatagory.ReadOnly = true;
            this.txtDUserCatagory.Size = new System.Drawing.Size(181, 27);
            this.txtDUserCatagory.TabIndex = 22;
            this.txtDUserCatagory.Text = "User Catagory";
            // 
            // CP_User
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(540, 341);
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
            this.Load += new System.EventHandler(this.CP_User_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CP_User_KeyDown);
            this.Leave += new System.EventHandler(this.CP_User_Leave);
            this.panelStatus.ResumeLayout(false);
            this.panelStatus.PerformLayout();
            this.grbForm.ResumeLayout(false);
            this.grbForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errUser)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtDLoginID;
        private System.Windows.Forms.TextBox txtLoginID;
        private System.Windows.Forms.TextBox txtDUserName;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtDPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtDCPassword;
        private System.Windows.Forms.TextBox txtCPassword;
        private System.Windows.Forms.Panel panelStatus;
        private System.Windows.Forms.RadioButton rbInactive;
        private System.Windows.Forms.RadioButton rbActive;
        private System.Windows.Forms.TextBox txtDStatus;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox grbForm;
        private System.Windows.Forms.ErrorProvider errUser;
        private System.Windows.Forms.TextBox txtDConfirmPassKey;
        private System.Windows.Forms.TextBox txtConfirmPasskey;
        private System.Windows.Forms.TextBox txtDPassKey;
        private System.Windows.Forms.TextBox txtPassKey;
        private System.Windows.Forms.TextBox txtDUserRole;
        private System.Windows.Forms.ComboBox cmbUserRole;
        private System.Windows.Forms.ComboBox cmbUserCatagory;
        private System.Windows.Forms.TextBox txtDUserCatagory;
    }
}