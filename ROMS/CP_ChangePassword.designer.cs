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
            this.tspHeader = new System.Windows.Forms.ToolStripLabel();
            this.pnlprofile = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDUserRole = new System.Windows.Forms.TextBox();
            this.txtUserRole = new System.Windows.Forms.TextBox();
            this.txtLoginid = new System.Windows.Forms.TextBox();
            this.txtDLoginId = new System.Windows.Forms.TextBox();
            this.gpChangePassword = new System.Windows.Forms.GroupBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.txtDOldPassword = new System.Windows.Forms.TextBox();
            this.txtOldPassword = new System.Windows.Forms.TextBox();
            this.txtDConfirmPassword = new System.Windows.Forms.TextBox();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.txtDNewPassword = new System.Windows.Forms.TextBox();
            this.txtNewPassword = new System.Windows.Forms.TextBox();
            this.gpChangePassKey = new System.Windows.Forms.GroupBox();
            this.btnView = new System.Windows.Forms.Button();
            this.btnUpdatePasskey = new System.Windows.Forms.Button();
            this.txtGenratePasskey = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblWelcome = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errChangePwd)).BeginInit();
            this.tsDesignationList.SuspendLayout();
            this.pnlprofile.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gpChangePassword.SuspendLayout();
            this.gpChangePassKey.SuspendLayout();
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
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.lblWelcome);
            this.groupBox2.Location = new System.Drawing.Point(10, 1);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1339, 633);
            this.groupBox2.TabIndex = 53;
            this.groupBox2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupBox1);
            this.groupBox3.Controls.Add(this.gpChangePassword);
            this.groupBox3.Controls.Add(this.gpChangePassKey);
            this.groupBox3.Location = new System.Drawing.Point(159, 218);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1035, 198);
            this.groupBox3.TabIndex = 61;
            this.groupBox3.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDUserRole);
            this.groupBox1.Controls.Add(this.txtUserRole);
            this.groupBox1.Controls.Add(this.txtLoginid);
            this.groupBox1.Controls.Add(this.txtDLoginId);
            this.groupBox1.Location = new System.Drawing.Point(9, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(407, 146);
            this.groupBox1.TabIndex = 60;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Credentials";
            // 
            // txtDUserRole
            // 
            this.txtDUserRole.BackColor = System.Drawing.SystemColors.Control;
            this.txtDUserRole.Enabled = false;
            this.txtDUserRole.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtDUserRole.Location = new System.Drawing.Point(14, 71);
            this.txtDUserRole.Name = "txtDUserRole";
            this.txtDUserRole.ReadOnly = true;
            this.txtDUserRole.Size = new System.Drawing.Size(181, 27);
            this.txtDUserRole.TabIndex = 48;
            this.txtDUserRole.Text = "User Role";
            // 
            // txtUserRole
            // 
            this.txtUserRole.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtUserRole.Location = new System.Drawing.Point(195, 71);
            this.txtUserRole.MaxLength = 20;
            this.txtUserRole.Name = "txtUserRole";
            this.txtUserRole.ReadOnly = true;
            this.txtUserRole.Size = new System.Drawing.Size(200, 27);
            this.txtUserRole.TabIndex = 47;
            this.txtUserRole.Text = "Admin";
            // 
            // txtLoginid
            // 
            this.txtLoginid.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtLoginid.Location = new System.Drawing.Point(195, 44);
            this.txtLoginid.MaxLength = 20;
            this.txtLoginid.Name = "txtLoginid";
            this.txtLoginid.ReadOnly = true;
            this.txtLoginid.Size = new System.Drawing.Size(200, 27);
            this.txtLoginid.TabIndex = 11;
            this.txtLoginid.Text = "Deepa";
            // 
            // txtDLoginId
            // 
            this.txtDLoginId.BackColor = System.Drawing.SystemColors.Control;
            this.txtDLoginId.Enabled = false;
            this.txtDLoginId.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtDLoginId.Location = new System.Drawing.Point(14, 44);
            this.txtDLoginId.Name = "txtDLoginId";
            this.txtDLoginId.ReadOnly = true;
            this.txtDLoginId.Size = new System.Drawing.Size(181, 27);
            this.txtDLoginId.TabIndex = 13;
            this.txtDLoginId.Text = "Login Id";
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
            this.gpChangePassword.Location = new System.Drawing.Point(422, 26);
            this.gpChangePassword.Name = "gpChangePassword";
            this.gpChangePassword.Size = new System.Drawing.Size(407, 146);
            this.gpChangePassword.TabIndex = 58;
            this.gpChangePassword.TabStop = false;
            this.gpChangePassword.Text = "Change Password";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Image = global::ROMS.Properties.Resources.save;
            this.btnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdate.Location = new System.Drawing.Point(315, 114);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(84, 29);
            this.btnUpdate.TabIndex = 3;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpdate.UseVisualStyleBackColor = true;
            // 
            // txtDOldPassword
            // 
            this.txtDOldPassword.BackColor = System.Drawing.SystemColors.Control;
            this.txtDOldPassword.Enabled = false;
            this.txtDOldPassword.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtDOldPassword.Location = new System.Drawing.Point(18, 30);
            this.txtDOldPassword.Name = "txtDOldPassword";
            this.txtDOldPassword.ReadOnly = true;
            this.txtDOldPassword.Size = new System.Drawing.Size(181, 27);
            this.txtDOldPassword.TabIndex = 9;
            this.txtDOldPassword.Text = "Old Password";
            // 
            // txtOldPassword
            // 
            this.txtOldPassword.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtOldPassword.Location = new System.Drawing.Point(199, 30);
            this.txtOldPassword.MaxLength = 20;
            this.txtOldPassword.Name = "txtOldPassword";
            this.txtOldPassword.PasswordChar = '*';
            this.txtOldPassword.Size = new System.Drawing.Size(200, 27);
            this.txtOldPassword.TabIndex = 0;
            // 
            // txtDConfirmPassword
            // 
            this.txtDConfirmPassword.BackColor = System.Drawing.SystemColors.Control;
            this.txtDConfirmPassword.Enabled = false;
            this.txtDConfirmPassword.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtDConfirmPassword.Location = new System.Drawing.Point(18, 84);
            this.txtDConfirmPassword.Name = "txtDConfirmPassword";
            this.txtDConfirmPassword.ReadOnly = true;
            this.txtDConfirmPassword.Size = new System.Drawing.Size(181, 27);
            this.txtDConfirmPassword.TabIndex = 7;
            this.txtDConfirmPassword.Text = "Confirm Password";
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtConfirmPassword.Location = new System.Drawing.Point(199, 84);
            this.txtConfirmPassword.MaxLength = 20;
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PasswordChar = '*';
            this.txtConfirmPassword.Size = new System.Drawing.Size(200, 27);
            this.txtConfirmPassword.TabIndex = 2;
            // 
            // txtDNewPassword
            // 
            this.txtDNewPassword.BackColor = System.Drawing.SystemColors.Control;
            this.txtDNewPassword.Enabled = false;
            this.txtDNewPassword.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtDNewPassword.Location = new System.Drawing.Point(18, 57);
            this.txtDNewPassword.Name = "txtDNewPassword";
            this.txtDNewPassword.ReadOnly = true;
            this.txtDNewPassword.Size = new System.Drawing.Size(181, 27);
            this.txtDNewPassword.TabIndex = 6;
            this.txtDNewPassword.Text = "New Password";
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtNewPassword.Location = new System.Drawing.Point(199, 57);
            this.txtNewPassword.MaxLength = 20;
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.PasswordChar = '*';
            this.txtNewPassword.Size = new System.Drawing.Size(200, 27);
            this.txtNewPassword.TabIndex = 1;
            // 
            // gpChangePassKey
            // 
            this.gpChangePassKey.Controls.Add(this.btnView);
            this.gpChangePassKey.Controls.Add(this.btnUpdatePasskey);
            this.gpChangePassKey.Controls.Add(this.txtGenratePasskey);
            this.gpChangePassKey.Location = new System.Drawing.Point(836, 26);
            this.gpChangePassKey.Name = "gpChangePassKey";
            this.gpChangePassKey.Size = new System.Drawing.Size(154, 97);
            this.gpChangePassKey.TabIndex = 59;
            this.gpChangePassKey.TabStop = false;
            this.gpChangePassKey.Text = "Generate Passkey";
            // 
            // btnView
            // 
            this.btnView.Image = global::ROMS.Properties.Resources.save;
            this.btnView.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnView.Location = new System.Drawing.Point(46, 59);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(95, 29);
            this.btnView.TabIndex = 4;
            this.btnView.Text = "Generate";
            this.btnView.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnView.UseVisualStyleBackColor = true;
            // 
            // btnUpdatePasskey
            // 
            this.btnUpdatePasskey.Image = global::ROMS.Properties.Resources.view_eye;
            this.btnUpdatePasskey.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdatePasskey.Location = new System.Drawing.Point(115, 26);
            this.btnUpdatePasskey.Name = "btnUpdatePasskey";
            this.btnUpdatePasskey.Size = new System.Drawing.Size(26, 27);
            this.btnUpdatePasskey.TabIndex = 3;
            this.btnUpdatePasskey.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpdatePasskey.UseVisualStyleBackColor = true;
            // 
            // txtGenratePasskey
            // 
            this.txtGenratePasskey.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtGenratePasskey.Location = new System.Drawing.Point(12, 26);
            this.txtGenratePasskey.MaxLength = 6;
            this.txtGenratePasskey.Name = "txtGenratePasskey";
            this.txtGenratePasskey.PasswordChar = '*';
            this.txtGenratePasskey.ReadOnly = true;
            this.txtGenratePasskey.Size = new System.Drawing.Size(103, 27);
            this.txtGenratePasskey.TabIndex = 0;
            this.txtGenratePasskey.Text = "200203";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1042, 193);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 22);
            this.label2.TabIndex = 60;
            this.label2.Text = "Purchase Incharge";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1042, 165);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 22);
            this.label1.TabIndex = 59;
            this.label1.Text = "Deepa";
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.Location = new System.Drawing.Point(968, 165);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(73, 22);
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
            this.Controls.Add(this.tsDesignationList);
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
            this.pnlprofile.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gpChangePassword.ResumeLayout(false);
            this.gpChangePassword.PerformLayout();
            this.gpChangePassKey.ResumeLayout(false);
            this.gpChangePassKey.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ErrorProvider errChangePwd;
        private System.Windows.Forms.ToolStrip tsDesignationList;
        private System.Windows.Forms.ToolStripLabel tspHeader;
        private System.Windows.Forms.Panel pnlprofile;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtDUserRole;
        private System.Windows.Forms.TextBox txtUserRole;
        private System.Windows.Forms.TextBox txtLoginid;
        private System.Windows.Forms.TextBox txtDLoginId;
        private System.Windows.Forms.GroupBox gpChangePassword;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TextBox txtDOldPassword;
        private System.Windows.Forms.TextBox txtOldPassword;
        private System.Windows.Forms.TextBox txtDConfirmPassword;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.TextBox txtDNewPassword;
        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.GroupBox gpChangePassKey;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnUpdatePasskey;
        private System.Windows.Forms.TextBox txtGenratePasskey;
    }
}