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
            this.epPassword = new System.Windows.Forms.ErrorProvider(this.components);
            this.tsProfile = new System.Windows.Forms.ToolStrip();
            this.tspHeader = new System.Windows.Forms.ToolStripLabel();
            this.pnlprofile = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gpChangePassKey = new System.Windows.Forms.GroupBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.txtGenratePasskey = new System.Windows.Forms.TextBox();
            this.gpChangePassword = new System.Windows.Forms.GroupBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.txtDOldPassword = new System.Windows.Forms.TextBox();
            this.txtOldPassword = new System.Windows.Forms.TextBox();
            this.txtDConfirmPassword = new System.Windows.Forms.TextBox();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.txtDNewPassword = new System.Windows.Forms.TextBox();
            this.txtNewPassword = new System.Windows.Forms.TextBox();
            this.lblUserRole = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblWelcome = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.epPassword)).BeginInit();
            this.tsProfile.SuspendLayout();
            this.pnlprofile.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gpChangePassKey.SuspendLayout();
            this.gpChangePassword.SuspendLayout();
            this.SuspendLayout();
            // 
            // epPassword
            // 
            this.epPassword.ContainerControl = this;
            // 
            // tsProfile
            // 
            this.tsProfile.BackColor = System.Drawing.Color.White;
            this.tsProfile.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsProfile.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsProfile.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspHeader});
            this.tsProfile.Location = new System.Drawing.Point(0, 0);
            this.tsProfile.Name = "tsProfile";
            this.tsProfile.Size = new System.Drawing.Size(1360, 25);
            this.tsProfile.TabIndex = 46;
            this.tsProfile.Text = "Designation";
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
            // pnlprofile
            // 
            this.pnlprofile.BackColor = System.Drawing.Color.White;
            this.pnlprofile.Controls.Add(this.groupBox2);
            this.pnlprofile.Location = new System.Drawing.Point(0, 29);
            this.pnlprofile.Name = "pnlprofile";
            this.pnlprofile.Size = new System.Drawing.Size(1359, 644);
            this.pnlprofile.TabIndex = 47;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.gpChangePassKey);
            this.groupBox2.Controls.Add(this.gpChangePassword);
            this.groupBox2.Controls.Add(this.lblUserRole);
            this.groupBox2.Controls.Add(this.lblUserName);
            this.groupBox2.Controls.Add(this.lblWelcome);
            this.groupBox2.Location = new System.Drawing.Point(10, 1);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1339, 633);
            this.groupBox2.TabIndex = 53;
            this.groupBox2.TabStop = false;
            this.groupBox2.Leave += new System.EventHandler(this.GroupBox2_Leave);
            // 
            // gpChangePassKey
            // 
            this.gpChangePassKey.Controls.Add(this.btnGenerate);
            this.gpChangePassKey.Controls.Add(this.btnView);
            this.gpChangePassKey.Controls.Add(this.txtGenratePasskey);
            this.gpChangePassKey.Location = new System.Drawing.Point(675, 36);
            this.gpChangePassKey.Name = "gpChangePassKey";
            this.gpChangePassKey.Size = new System.Drawing.Size(154, 122);
            this.gpChangePassKey.TabIndex = 59;
            this.gpChangePassKey.TabStop = false;
            this.gpChangePassKey.Text = "Generate Passkey";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Image = global::ROMS.Properties.Resources.passkey;
            this.btnGenerate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenerate.Location = new System.Drawing.Point(50, 72);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(91, 29);
            this.btnGenerate.TabIndex = 4;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.BtnGenerate_Click);
            // 
            // btnView
            // 
            this.btnView.Image = global::ROMS.Properties.Resources.close_eye;
            this.btnView.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnView.Location = new System.Drawing.Point(115, 25);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(26, 42);
            this.btnView.TabIndex = 3;
            this.btnView.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.BtnView_Click);
            // 
            // txtGenratePasskey
            // 
            this.txtGenratePasskey.Font = new System.Drawing.Font("Oswald Regular", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGenratePasskey.Location = new System.Drawing.Point(12, 26);
            this.txtGenratePasskey.MaxLength = 6;
            this.txtGenratePasskey.Name = "txtGenratePasskey";
            this.txtGenratePasskey.PasswordChar = '*';
            this.txtGenratePasskey.ReadOnly = true;
            this.txtGenratePasskey.Size = new System.Drawing.Size(103, 40);
            this.txtGenratePasskey.TabIndex = 0;
            this.txtGenratePasskey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtGenratePasskey.Enter += new System.EventHandler(this.TxtGenratePasskey_Enter);
            this.txtGenratePasskey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtGenratePasskey_KeyDown);
            this.txtGenratePasskey.Leave += new System.EventHandler(this.TxtGenratePasskey_Leave);
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
            this.gpChangePassword.Location = new System.Drawing.Point(235, 36);
            this.gpChangePassword.Name = "gpChangePassword";
            this.gpChangePassword.Size = new System.Drawing.Size(431, 158);
            this.gpChangePassword.TabIndex = 58;
            this.gpChangePassword.TabStop = false;
            this.gpChangePassword.Text = "Change Password";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Image = global::ROMS.Properties.Resources.save;
            this.btnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdate.Location = new System.Drawing.Point(321, 117);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(84, 29);
            this.btnUpdate.TabIndex = 3;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.BtnUpdate_Click);
            this.btnUpdate.Enter += new System.EventHandler(this.BtnUpdate_Enter);
            this.btnUpdate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BtnUpdate_KeyDown);
            this.btnUpdate.Leave += new System.EventHandler(this.BtnUpdate_Leave);
            // 
            // txtDOldPassword
            // 
            this.txtDOldPassword.BackColor = System.Drawing.SystemColors.Control;
            this.txtDOldPassword.Enabled = false;
            this.txtDOldPassword.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtDOldPassword.Location = new System.Drawing.Point(24, 30);
            this.txtDOldPassword.Name = "txtDOldPassword";
            this.txtDOldPassword.ReadOnly = true;
            this.txtDOldPassword.Size = new System.Drawing.Size(181, 27);
            this.txtDOldPassword.TabIndex = 9;
            this.txtDOldPassword.Text = "Old Password";
            // 
            // txtOldPassword
            // 
            this.txtOldPassword.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtOldPassword.Location = new System.Drawing.Point(205, 30);
            this.txtOldPassword.MaxLength = 20;
            this.txtOldPassword.Name = "txtOldPassword";
            this.txtOldPassword.PasswordChar = '*';
            this.txtOldPassword.Size = new System.Drawing.Size(200, 27);
            this.txtOldPassword.TabIndex = 0;
            this.txtOldPassword.Enter += new System.EventHandler(this.txtOldPassword_Enter);
            this.txtOldPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtOldPassword_KeyDown);
            this.txtOldPassword.Leave += new System.EventHandler(this.txtOldPassword_Leave);
            // 
            // txtDConfirmPassword
            // 
            this.txtDConfirmPassword.BackColor = System.Drawing.SystemColors.Control;
            this.txtDConfirmPassword.Enabled = false;
            this.txtDConfirmPassword.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtDConfirmPassword.Location = new System.Drawing.Point(24, 84);
            this.txtDConfirmPassword.Name = "txtDConfirmPassword";
            this.txtDConfirmPassword.ReadOnly = true;
            this.txtDConfirmPassword.Size = new System.Drawing.Size(181, 27);
            this.txtDConfirmPassword.TabIndex = 7;
            this.txtDConfirmPassword.Text = "Confirm Password";
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtConfirmPassword.Location = new System.Drawing.Point(205, 84);
            this.txtConfirmPassword.MaxLength = 20;
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PasswordChar = '*';
            this.txtConfirmPassword.Size = new System.Drawing.Size(200, 27);
            this.txtConfirmPassword.TabIndex = 2;
            this.txtConfirmPassword.Enter += new System.EventHandler(this.txtConfirmPassword_Enter);
            this.txtConfirmPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtConfirmPassword_KeyDown);
            this.txtConfirmPassword.Leave += new System.EventHandler(this.txtConfirmPassword_Leave);
            // 
            // txtDNewPassword
            // 
            this.txtDNewPassword.BackColor = System.Drawing.SystemColors.Control;
            this.txtDNewPassword.Enabled = false;
            this.txtDNewPassword.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtDNewPassword.Location = new System.Drawing.Point(24, 57);
            this.txtDNewPassword.Name = "txtDNewPassword";
            this.txtDNewPassword.ReadOnly = true;
            this.txtDNewPassword.Size = new System.Drawing.Size(181, 27);
            this.txtDNewPassword.TabIndex = 6;
            this.txtDNewPassword.Text = "New Password";
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtNewPassword.Location = new System.Drawing.Point(205, 57);
            this.txtNewPassword.MaxLength = 20;
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.PasswordChar = '*';
            this.txtNewPassword.Size = new System.Drawing.Size(200, 27);
            this.txtNewPassword.TabIndex = 1;
            this.txtNewPassword.Enter += new System.EventHandler(this.txtNewPassword_Enter);
            this.txtNewPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNewPassword_KeyDown);
            this.txtNewPassword.Leave += new System.EventHandler(this.txtNewPassword_Leave);
            // 
            // lblUserRole
            // 
            this.lblUserRole.AutoSize = true;
            this.lblUserRole.Font = new System.Drawing.Font("Oswald Regular", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserRole.Location = new System.Drawing.Point(89, 63);
            this.lblUserRole.Name = "lblUserRole";
            this.lblUserRole.Size = new System.Drawing.Size(95, 17);
            this.lblUserRole.TabIndex = 60;
            this.lblUserRole.Text = "Purchase Incharge";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.Location = new System.Drawing.Point(89, 39);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(42, 20);
            this.lblUserName.TabIndex = 59;
            this.lblUserName.Text = "Deepa";
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Oswald Regular", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.Location = new System.Drawing.Point(26, 38);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(65, 21);
            this.lblWelcome.TabIndex = 58;
            this.lblWelcome.Text = "Welcome";
            // 
            // CP_ChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(1360, 675);
            this.Controls.Add(this.pnlprofile);
            this.Controls.Add(this.tsProfile);
            this.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "CP_ChangePassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "My Profile";
            this.Load += new System.EventHandler(this.CP_ChangePassword_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CP_ChangePassword_KeyDown);
            this.Leave += new System.EventHandler(this.CP_ChangePassword_Leave);
            ((System.ComponentModel.ISupportInitialize)(this.epPassword)).EndInit();
            this.tsProfile.ResumeLayout(false);
            this.tsProfile.PerformLayout();
            this.pnlprofile.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gpChangePassKey.ResumeLayout(false);
            this.gpChangePassKey.PerformLayout();
            this.gpChangePassword.ResumeLayout(false);
            this.gpChangePassword.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ErrorProvider epPassword;
        private System.Windows.Forms.ToolStrip tsProfile;
        private System.Windows.Forms.ToolStripLabel tspHeader;
        private System.Windows.Forms.Panel pnlprofile;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblUserRole;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.GroupBox gpChangePassKey;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.TextBox txtGenratePasskey;
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