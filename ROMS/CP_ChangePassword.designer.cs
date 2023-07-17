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
            this.btnSave = new System.Windows.Forms.Button();
            this.gpChangePassword = new System.Windows.Forms.GroupBox();
            this.grbForm = new System.Windows.Forms.GroupBox();
            this.txtDOldPassword = new System.Windows.Forms.TextBox();
            this.txtOldPassword = new System.Windows.Forms.TextBox();
            this.txtDConfirmPassword = new System.Windows.Forms.TextBox();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.txtDNewPassword = new System.Windows.Forms.TextBox();
            this.txtNewPassword = new System.Windows.Forms.TextBox();
            this.errChangePwd = new System.Windows.Forms.ErrorProvider(this.components);
            this.tsDesignationList = new System.Windows.Forms.ToolStrip();
            this.tspHeader = new System.Windows.Forms.ToolStripLabel();
            this.gpChangePassword.SuspendLayout();
            this.grbForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errChangePwd)).BeginInit();
            this.tsDesignationList.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Image = global::ROMS.Properties.Resources.save;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(371, 188);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(84, 29);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // gpChangePassword
            // 
            this.gpChangePassword.BackColor = System.Drawing.Color.Transparent;
            this.gpChangePassword.Controls.Add(this.grbForm);
            this.gpChangePassword.Controls.Add(this.btnSave);
            this.gpChangePassword.Location = new System.Drawing.Point(435, 211);
            this.gpChangePassword.Name = "gpChangePassword";
            this.gpChangePassword.Size = new System.Drawing.Size(490, 253);
            this.gpChangePassword.TabIndex = 0;
            this.gpChangePassword.TabStop = false;
            this.gpChangePassword.Text = "Change Password";
            // 
            // grbForm
            // 
            this.grbForm.Controls.Add(this.txtDOldPassword);
            this.grbForm.Controls.Add(this.txtOldPassword);
            this.grbForm.Controls.Add(this.txtDConfirmPassword);
            this.grbForm.Controls.Add(this.txtConfirmPassword);
            this.grbForm.Controls.Add(this.txtDNewPassword);
            this.grbForm.Controls.Add(this.txtNewPassword);
            this.grbForm.Location = new System.Drawing.Point(30, 38);
            this.grbForm.Name = "grbForm";
            this.grbForm.Size = new System.Drawing.Size(425, 135);
            this.grbForm.TabIndex = 0;
            this.grbForm.TabStop = false;
            // 
            // txtDOldPassword
            // 
            this.txtDOldPassword.BackColor = System.Drawing.SystemColors.Control;
            this.txtDOldPassword.Enabled = false;
            this.txtDOldPassword.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtDOldPassword.Location = new System.Drawing.Point(22, 32);
            this.txtDOldPassword.Name = "txtDOldPassword";
            this.txtDOldPassword.ReadOnly = true;
            this.txtDOldPassword.Size = new System.Drawing.Size(181, 27);
            this.txtDOldPassword.TabIndex = 9;
            this.txtDOldPassword.Text = "Old Password";
            // 
            // txtOldPassword
            // 
            this.txtOldPassword.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtOldPassword.Location = new System.Drawing.Point(203, 32);
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
            this.txtDConfirmPassword.Location = new System.Drawing.Point(22, 86);
            this.txtDConfirmPassword.Name = "txtDConfirmPassword";
            this.txtDConfirmPassword.ReadOnly = true;
            this.txtDConfirmPassword.Size = new System.Drawing.Size(181, 27);
            this.txtDConfirmPassword.TabIndex = 7;
            this.txtDConfirmPassword.Text = "Confirm Password";
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtConfirmPassword.Location = new System.Drawing.Point(203, 86);
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
            this.txtDNewPassword.Location = new System.Drawing.Point(22, 59);
            this.txtDNewPassword.Name = "txtDNewPassword";
            this.txtDNewPassword.ReadOnly = true;
            this.txtDNewPassword.Size = new System.Drawing.Size(181, 27);
            this.txtDNewPassword.TabIndex = 6;
            this.txtDNewPassword.Text = "New Password";
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtNewPassword.Location = new System.Drawing.Point(203, 59);
            this.txtNewPassword.MaxLength = 20;
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.PasswordChar = '*';
            this.txtNewPassword.Size = new System.Drawing.Size(200, 27);
            this.txtNewPassword.TabIndex = 1;
            this.txtNewPassword.Enter += new System.EventHandler(this.txtNewPassword_Enter);
            this.txtNewPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNewPassword_KeyDown);
            this.txtNewPassword.Leave += new System.EventHandler(this.txtNewPassword_Leave);
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
            this.tspHeader.Size = new System.Drawing.Size(121, 22);
            this.tspHeader.Text = "Change Password";
            // 
            // CP_ChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1360, 675);
            this.Controls.Add(this.tsDesignationList);
            this.Controls.Add(this.gpChangePassword);
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
            this.gpChangePassword.ResumeLayout(false);
            this.grbForm.ResumeLayout(false);
            this.grbForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errChangePwd)).EndInit();
            this.tsDesignationList.ResumeLayout(false);
            this.tsDesignationList.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox gpChangePassword;
        private System.Windows.Forms.GroupBox grbForm;
        private System.Windows.Forms.TextBox txtDConfirmPassword;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.TextBox txtDNewPassword;
        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.TextBox txtDOldPassword;
        private System.Windows.Forms.TextBox txtOldPassword;
        private System.Windows.Forms.ErrorProvider errChangePwd;
        private System.Windows.Forms.ToolStrip tsDesignationList;
        private System.Windows.Forms.ToolStripLabel tspHeader;
    }
}