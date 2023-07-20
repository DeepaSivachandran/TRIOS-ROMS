namespace ROMS
{
    partial class CP_ChangePassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CP_ChangePassword));
            this.errChangePwd = new System.Windows.Forms.ErrorProvider(this.components);
            this.tsDesignationList = new System.Windows.Forms.ToolStrip();
            this.txtDNameofTheUser = new System.Windows.Forms.TextBox();
            this.txtNameoftheUser = new System.Windows.Forms.TextBox();
            this.txtDUserCategory = new System.Windows.Forms.TextBox();
            this.txtUserCategory = new System.Windows.Forms.TextBox();
            this.txtDLoginId = new System.Windows.Forms.TextBox();
            this.txtLoginid = new System.Windows.Forms.TextBox();
            this.txtDUserRole = new System.Windows.Forms.TextBox();
            this.txtUserRole = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gpChangePassKey = new System.Windows.Forms.GroupBox();
            this.txtNewPasskey = new System.Windows.Forms.TextBox();
            this.txtDNewPasskey = new System.Windows.Forms.TextBox();
            this.txtConfirmPasskey = new System.Windows.Forms.TextBox();
            this.txtDConfirmPasskey = new System.Windows.Forms.TextBox();
            this.txtOldPasskey = new System.Windows.Forms.TextBox();
            this.txtDOldPasskey = new System.Windows.Forms.TextBox();
            this.gpChangePassword = new System.Windows.Forms.GroupBox();
            this.txtNewPassword = new System.Windows.Forms.TextBox();
            this.txtDNewPassword = new System.Windows.Forms.TextBox();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.txtDConfirmPassword = new System.Windows.Forms.TextBox();
            this.txtOldPassword = new System.Windows.Forms.TextBox();
            this.txtDOldPassword = new System.Windows.Forms.TextBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnUpdatePasskey = new System.Windows.Forms.Button();
            this.tspHeader = new System.Windows.Forms.ToolStripLabel();
            ((System.ComponentModel.ISupportInitialize)(this.errChangePwd)).BeginInit();
            this.tsDesignationList.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gpChangePassKey.SuspendLayout();
            this.gpChangePassword.SuspendLayout();
            this.SuspendLayout();
            // 
            // errChangePwd
            // 
            this.errChangePwd.ContainerControl = this;
            // 
            // tsDesignationList
            // 
            this.tsDesignationList.BackColor = System.Drawing.Color.White;
            this.tsDesignationList.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsDesignationList.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsDesignationList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspHeader});
            this.tsDesignationList.Location = new System.Drawing.Point(0, 0);
            this.tsDesignationList.Name = "tsDesignationList";
            this.tsDesignationList.Size = new System.Drawing.Size(1360, 25);
            this.tsDesignationList.TabIndex = 46;
            this.tsDesignationList.Text = "Designation";
            // 
            // txtDNameofTheUser
            // 
            this.txtDNameofTheUser.BackColor = System.Drawing.SystemColors.Control;
            this.txtDNameofTheUser.Enabled = false;
            this.txtDNameofTheUser.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtDNameofTheUser.Location = new System.Drawing.Point(14, 24);
            this.txtDNameofTheUser.Name = "txtDNameofTheUser";
            this.txtDNameofTheUser.ReadOnly = true;
            this.txtDNameofTheUser.Size = new System.Drawing.Size(181, 27);
            this.txtDNameofTheUser.TabIndex = 15;
            this.txtDNameofTheUser.Text = "Name of the User";
            // 
            // txtNameoftheUser
            // 
            this.txtNameoftheUser.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtNameoftheUser.Location = new System.Drawing.Point(195, 24);
            this.txtNameoftheUser.MaxLength = 20;
            this.txtNameoftheUser.Name = "txtNameoftheUser";
            this.txtNameoftheUser.PasswordChar = '*';
            this.txtNameoftheUser.ReadOnly = true;
            this.txtNameoftheUser.Size = new System.Drawing.Size(200, 27);
            this.txtNameoftheUser.TabIndex = 10;
            // 
            // txtDUserCategory
            // 
            this.txtDUserCategory.BackColor = System.Drawing.SystemColors.Control;
            this.txtDUserCategory.Enabled = false;
            this.txtDUserCategory.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtDUserCategory.Location = new System.Drawing.Point(14, 78);
            this.txtDUserCategory.Name = "txtDUserCategory";
            this.txtDUserCategory.ReadOnly = true;
            this.txtDUserCategory.Size = new System.Drawing.Size(181, 27);
            this.txtDUserCategory.TabIndex = 14;
            this.txtDUserCategory.Text = "User Category";
            // 
            // txtUserCategory
            // 
            this.txtUserCategory.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtUserCategory.Location = new System.Drawing.Point(195, 78);
            this.txtUserCategory.MaxLength = 20;
            this.txtUserCategory.Name = "txtUserCategory";
            this.txtUserCategory.PasswordChar = '*';
            this.txtUserCategory.ReadOnly = true;
            this.txtUserCategory.Size = new System.Drawing.Size(200, 27);
            this.txtUserCategory.TabIndex = 12;
            // 
            // txtDLoginId
            // 
            this.txtDLoginId.BackColor = System.Drawing.SystemColors.Control;
            this.txtDLoginId.Enabled = false;
            this.txtDLoginId.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtDLoginId.Location = new System.Drawing.Point(14, 51);
            this.txtDLoginId.Name = "txtDLoginId";
            this.txtDLoginId.ReadOnly = true;
            this.txtDLoginId.Size = new System.Drawing.Size(181, 27);
            this.txtDLoginId.TabIndex = 13;
            this.txtDLoginId.Text = "Login Id";
            // 
            // txtLoginid
            // 
            this.txtLoginid.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtLoginid.Location = new System.Drawing.Point(195, 51);
            this.txtLoginid.MaxLength = 20;
            this.txtLoginid.Name = "txtLoginid";
            this.txtLoginid.PasswordChar = '*';
            this.txtLoginid.ReadOnly = true;
            this.txtLoginid.Size = new System.Drawing.Size(200, 27);
            this.txtLoginid.TabIndex = 11;
            // 
            // txtDUserRole
            // 
            this.txtDUserRole.BackColor = System.Drawing.SystemColors.Control;
            this.txtDUserRole.Enabled = false;
            this.txtDUserRole.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtDUserRole.Location = new System.Drawing.Point(14, 105);
            this.txtDUserRole.Name = "txtDUserRole";
            this.txtDUserRole.ReadOnly = true;
            this.txtDUserRole.Size = new System.Drawing.Size(181, 27);
            this.txtDUserRole.TabIndex = 48;
            this.txtDUserRole.Text = "User Role";
            // 
            // txtUserRole
            // 
            this.txtUserRole.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtUserRole.Location = new System.Drawing.Point(195, 105);
            this.txtUserRole.MaxLength = 20;
            this.txtUserRole.Name = "txtUserRole";
            this.txtUserRole.PasswordChar = '*';
            this.txtUserRole.ReadOnly = true;
            this.txtUserRole.Size = new System.Drawing.Size(200, 27);
            this.txtUserRole.TabIndex = 47;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDUserRole);
            this.groupBox1.Controls.Add(this.txtDNameofTheUser);
            this.groupBox1.Controls.Add(this.txtUserRole);
            this.groupBox1.Controls.Add(this.txtLoginid);
            this.groupBox1.Controls.Add(this.txtDLoginId);
            this.groupBox1.Controls.Add(this.txtNameoftheUser);
            this.groupBox1.Controls.Add(this.txtUserCategory);
            this.groupBox1.Controls.Add(this.txtDUserCategory);
            this.groupBox1.Location = new System.Drawing.Point(120, 83);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(407, 146);
            this.groupBox1.TabIndex = 49;
            this.groupBox1.TabStop = false;
            // 
            // gpChangePassKey
            // 
            this.gpChangePassKey.Controls.Add(this.txtDOldPasskey);
            this.gpChangePassKey.Controls.Add(this.btnUpdatePasskey);
            this.gpChangePassKey.Controls.Add(this.txtOldPasskey);
            this.gpChangePassKey.Controls.Add(this.txtDConfirmPasskey);
            this.gpChangePassKey.Controls.Add(this.txtConfirmPasskey);
            this.gpChangePassKey.Controls.Add(this.txtDNewPasskey);
            this.gpChangePassKey.Controls.Add(this.txtNewPasskey);
            this.gpChangePassKey.Location = new System.Drawing.Point(805, 325);
            this.gpChangePassKey.Name = "gpChangePassKey";
            this.gpChangePassKey.Size = new System.Drawing.Size(418, 161);
            this.gpChangePassKey.TabIndex = 0;
            this.gpChangePassKey.TabStop = false;
            this.gpChangePassKey.Text = "Change Passkey";
            this.gpChangePassKey.Enter += new System.EventHandler(this.GroupBox2_Enter);
            // 
            // txtNewPasskey
            // 
            this.txtNewPasskey.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtNewPasskey.Location = new System.Drawing.Point(203, 59);
            this.txtNewPasskey.MaxLength = 20;
            this.txtNewPasskey.Name = "txtNewPasskey";
            this.txtNewPasskey.PasswordChar = '*';
            this.txtNewPasskey.Size = new System.Drawing.Size(200, 27);
            this.txtNewPasskey.TabIndex = 1;
            // 
            // txtDNewPasskey
            // 
            this.txtDNewPasskey.BackColor = System.Drawing.SystemColors.Control;
            this.txtDNewPasskey.Enabled = false;
            this.txtDNewPasskey.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtDNewPasskey.Location = new System.Drawing.Point(22, 59);
            this.txtDNewPasskey.Name = "txtDNewPasskey";
            this.txtDNewPasskey.ReadOnly = true;
            this.txtDNewPasskey.Size = new System.Drawing.Size(181, 27);
            this.txtDNewPasskey.TabIndex = 6;
            this.txtDNewPasskey.Text = "New Passkey";
            // 
            // txtConfirmPasskey
            // 
            this.txtConfirmPasskey.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtConfirmPasskey.Location = new System.Drawing.Point(203, 86);
            this.txtConfirmPasskey.MaxLength = 20;
            this.txtConfirmPasskey.Name = "txtConfirmPasskey";
            this.txtConfirmPasskey.PasswordChar = '*';
            this.txtConfirmPasskey.Size = new System.Drawing.Size(200, 27);
            this.txtConfirmPasskey.TabIndex = 2;
            // 
            // txtDConfirmPasskey
            // 
            this.txtDConfirmPasskey.BackColor = System.Drawing.SystemColors.Control;
            this.txtDConfirmPasskey.Enabled = false;
            this.txtDConfirmPasskey.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtDConfirmPasskey.Location = new System.Drawing.Point(22, 86);
            this.txtDConfirmPasskey.Name = "txtDConfirmPasskey";
            this.txtDConfirmPasskey.ReadOnly = true;
            this.txtDConfirmPasskey.Size = new System.Drawing.Size(181, 27);
            this.txtDConfirmPasskey.TabIndex = 7;
            this.txtDConfirmPasskey.Text = "Confirm Passkey";
            // 
            // txtOldPasskey
            // 
            this.txtOldPasskey.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtOldPasskey.Location = new System.Drawing.Point(203, 32);
            this.txtOldPasskey.MaxLength = 20;
            this.txtOldPasskey.Name = "txtOldPasskey";
            this.txtOldPasskey.PasswordChar = '*';
            this.txtOldPasskey.Size = new System.Drawing.Size(200, 27);
            this.txtOldPasskey.TabIndex = 0;
            // 
            // txtDOldPasskey
            // 
            this.txtDOldPasskey.BackColor = System.Drawing.SystemColors.Control;
            this.txtDOldPasskey.Enabled = false;
            this.txtDOldPasskey.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtDOldPasskey.Location = new System.Drawing.Point(22, 32);
            this.txtDOldPasskey.Name = "txtDOldPasskey";
            this.txtDOldPasskey.ReadOnly = true;
            this.txtDOldPasskey.Size = new System.Drawing.Size(181, 27);
            this.txtDOldPasskey.TabIndex = 9;
            this.txtDOldPasskey.Text = "Old Passkey";
            // 
            // gpChangePassword
            // 
            this.gpChangePassword.Controls.Add(this.btnUpdate);
            this.gpChangePassword.Controls.Add(this.txtDOldPassword);
            this.gpChangePassword.Controls.Add(this.txtOldPassword);
            this.gpChangePassword.Controls.Add(this.txtDConfirmPassword);
            this.gpChangePassword.Controls.Add(this.txtConfirmPassword);
            this.gpChangePassword.Controls.Add(this.txtDNewPassword);
            this.gpChangePassword.Controls.Add(this.txtNewPassword);
            this.gpChangePassword.Location = new System.Drawing.Point(120, 325);
            this.gpChangePassword.Name = "gpChangePassword";
            this.gpChangePassword.Size = new System.Drawing.Size(418, 161);
            this.gpChangePassword.TabIndex = 0;
            this.gpChangePassword.TabStop = false;
            this.gpChangePassword.Text = "Change Password";
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtNewPassword.Location = new System.Drawing.Point(199, 63);
            this.txtNewPassword.MaxLength = 20;
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.PasswordChar = '*';
            this.txtNewPassword.Size = new System.Drawing.Size(200, 27);
            this.txtNewPassword.TabIndex = 1;
            this.txtNewPassword.Enter += new System.EventHandler(this.txtNewPassword_Enter);
            this.txtNewPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNewPassword_KeyDown);
            this.txtNewPassword.Leave += new System.EventHandler(this.txtNewPassword_Leave);
            // 
            // txtDNewPassword
            // 
            this.txtDNewPassword.BackColor = System.Drawing.SystemColors.Control;
            this.txtDNewPassword.Enabled = false;
            this.txtDNewPassword.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtDNewPassword.Location = new System.Drawing.Point(18, 63);
            this.txtDNewPassword.Name = "txtDNewPassword";
            this.txtDNewPassword.ReadOnly = true;
            this.txtDNewPassword.Size = new System.Drawing.Size(181, 27);
            this.txtDNewPassword.TabIndex = 6;
            this.txtDNewPassword.Text = "New Password";
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtConfirmPassword.Location = new System.Drawing.Point(199, 90);
            this.txtConfirmPassword.MaxLength = 20;
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PasswordChar = '*';
            this.txtConfirmPassword.Size = new System.Drawing.Size(200, 27);
            this.txtConfirmPassword.TabIndex = 2;
            this.txtConfirmPassword.Enter += new System.EventHandler(this.txtConfirmPassword_Enter);
            this.txtConfirmPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtConfirmPassword_KeyDown);
            this.txtConfirmPassword.Leave += new System.EventHandler(this.txtConfirmPassword_Leave);
            // 
            // txtDConfirmPassword
            // 
            this.txtDConfirmPassword.BackColor = System.Drawing.SystemColors.Control;
            this.txtDConfirmPassword.Enabled = false;
            this.txtDConfirmPassword.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtDConfirmPassword.Location = new System.Drawing.Point(18, 90);
            this.txtDConfirmPassword.Name = "txtDConfirmPassword";
            this.txtDConfirmPassword.ReadOnly = true;
            this.txtDConfirmPassword.Size = new System.Drawing.Size(181, 27);
            this.txtDConfirmPassword.TabIndex = 7;
            this.txtDConfirmPassword.Text = "Confirm Password";
            // 
            // txtOldPassword
            // 
            this.txtOldPassword.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtOldPassword.Location = new System.Drawing.Point(199, 36);
            this.txtOldPassword.MaxLength = 20;
            this.txtOldPassword.Name = "txtOldPassword";
            this.txtOldPassword.PasswordChar = '*';
            this.txtOldPassword.Size = new System.Drawing.Size(200, 27);
            this.txtOldPassword.TabIndex = 0;
            this.txtOldPassword.Enter += new System.EventHandler(this.txtOldPassword_Enter);
            this.txtOldPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtOldPassword_KeyDown);
            this.txtOldPassword.Leave += new System.EventHandler(this.txtOldPassword_Leave);
            // 
            // txtDOldPassword
            // 
            this.txtDOldPassword.BackColor = System.Drawing.SystemColors.Control;
            this.txtDOldPassword.Enabled = false;
            this.txtDOldPassword.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtDOldPassword.Location = new System.Drawing.Point(18, 36);
            this.txtDOldPassword.Name = "txtDOldPassword";
            this.txtDOldPassword.ReadOnly = true;
            this.txtDOldPassword.Size = new System.Drawing.Size(181, 27);
            this.txtDOldPassword.TabIndex = 9;
            this.txtDOldPassword.Text = "Old Password";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Image = global::ROMS.Properties.Resources.save;
            this.btnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdate.Location = new System.Drawing.Point(315, 123);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(84, 29);
            this.btnUpdate.TabIndex = 3;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.BtnUpdate_Click);
            // 
            // btnUpdatePasskey
            // 
            this.btnUpdatePasskey.Image = global::ROMS.Properties.Resources.save;
            this.btnUpdatePasskey.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdatePasskey.Location = new System.Drawing.Point(319, 123);
            this.btnUpdatePasskey.Name = "btnUpdatePasskey";
            this.btnUpdatePasskey.Size = new System.Drawing.Size(84, 29);
            this.btnUpdatePasskey.TabIndex = 3;
            this.btnUpdatePasskey.Text = "Update";
            this.btnUpdatePasskey.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpdatePasskey.UseVisualStyleBackColor = true;
            this.btnUpdatePasskey.Click += new System.EventHandler(this.BtnUpdatePasskey_Click);
            // 
            // tspHeader
            // 
            this.tspHeader.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tspHeader.Image = global::ROMS.Properties.Resources.bread_crumb;
            this.tspHeader.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tspHeader.Margin = new System.Windows.Forms.Padding(15, 1, 0, 2);
            this.tspHeader.Name = "tspHeader";
            this.tspHeader.Size = new System.Drawing.Size(78, 22);
            this.tspHeader.Text = "My Profile";
            // 
            // CP_ChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1360, 675);
            this.Controls.Add(this.gpChangePassword);
            this.Controls.Add(this.gpChangePassKey);
            this.Controls.Add(this.tsDesignationList);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "CP_ChangePassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Production Plan";
            this.Load += new System.EventHandler(this.CP_ChangePassword_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CP_ChangePassword_KeyDown);
            this.Leave += new System.EventHandler(this.CP_ChangePassword_Leave);
            ((System.ComponentModel.ISupportInitialize)(this.errChangePwd)).EndInit();
            this.tsDesignationList.ResumeLayout(false);
            this.tsDesignationList.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gpChangePassKey.ResumeLayout(false);
            this.gpChangePassKey.PerformLayout();
            this.gpChangePassword.ResumeLayout(false);
            this.gpChangePassword.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ErrorProvider errChangePwd;
        private System.Windows.Forms.ToolStrip tsDesignationList;
        private System.Windows.Forms.ToolStripLabel tspHeader;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtDUserRole;
        private System.Windows.Forms.TextBox txtDNameofTheUser;
        private System.Windows.Forms.TextBox txtUserRole;
        private System.Windows.Forms.TextBox txtLoginid;
        private System.Windows.Forms.TextBox txtDLoginId;
        private System.Windows.Forms.TextBox txtNameoftheUser;
        private System.Windows.Forms.TextBox txtUserCategory;
        private System.Windows.Forms.TextBox txtDUserCategory;
        private System.Windows.Forms.GroupBox gpChangePassKey;
        private System.Windows.Forms.TextBox txtDOldPasskey;
        private System.Windows.Forms.Button btnUpdatePasskey;
        private System.Windows.Forms.TextBox txtOldPasskey;
        private System.Windows.Forms.TextBox txtDConfirmPasskey;
        private System.Windows.Forms.TextBox txtConfirmPasskey;
        private System.Windows.Forms.TextBox txtDNewPasskey;
        private System.Windows.Forms.TextBox txtNewPasskey;
        private System.Windows.Forms.GroupBox gpChangePassword;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TextBox txtDOldPassword;
        private System.Windows.Forms.TextBox txtOldPassword;
        private System.Windows.Forms.TextBox txtDConfirmPassword;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.TextBox txtDNewPassword;
        private System.Windows.Forms.TextBox txtNewPassword;
    }
}