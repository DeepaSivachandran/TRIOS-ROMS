namespace ROMS
{
    partial class CP_User_ResetPassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CP_User_ResetPassword));
            this.epPassword = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnSave = new System.Windows.Forms.Button();
            this.txtDConfirmPassword = new System.Windows.Forms.TextBox();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.txtDNewPassword = new System.Windows.Forms.TextBox();
            this.txtNewPassword = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.epPassword)).BeginInit();
            this.SuspendLayout();
            // 
            // epPassword
            // 
            this.epPassword.ContainerControl = this;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::ROMS.Properties.Resources.save;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(305, 74);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(86, 33);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Update";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            this.btnSave.Enter += new System.EventHandler(this.BtnSave_Enter);
            this.btnSave.Leave += new System.EventHandler(this.BtnSave_Leave);
            // 
            // txtDConfirmPassword
            // 
            this.txtDConfirmPassword.BackColor = System.Drawing.SystemColors.Control;
            this.txtDConfirmPassword.Enabled = false;
            this.txtDConfirmPassword.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtDConfirmPassword.Location = new System.Drawing.Point(12, 39);
            this.txtDConfirmPassword.Name = "txtDConfirmPassword";
            this.txtDConfirmPassword.ReadOnly = true;
            this.txtDConfirmPassword.Size = new System.Drawing.Size(181, 27);
            this.txtDConfirmPassword.TabIndex = 11;
            this.txtDConfirmPassword.Text = "Confirm Password";
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtConfirmPassword.Location = new System.Drawing.Point(193, 39);
            this.txtConfirmPassword.MaxLength = 20;
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PasswordChar = '*';
            this.txtConfirmPassword.Size = new System.Drawing.Size(200, 27);
            this.txtConfirmPassword.TabIndex = 9;
            this.txtConfirmPassword.Enter += new System.EventHandler(this.txtConfirmPassword_Enter);
            this.txtConfirmPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtConfirmPassword_KeyDown);
            this.txtConfirmPassword.Leave += new System.EventHandler(this.txtConfirmPassword_Leave);
            // 
            // txtDNewPassword
            // 
            this.txtDNewPassword.BackColor = System.Drawing.SystemColors.Control;
            this.txtDNewPassword.Enabled = false;
            this.txtDNewPassword.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtDNewPassword.Location = new System.Drawing.Point(12, 12);
            this.txtDNewPassword.Name = "txtDNewPassword";
            this.txtDNewPassword.ReadOnly = true;
            this.txtDNewPassword.Size = new System.Drawing.Size(181, 27);
            this.txtDNewPassword.TabIndex = 10;
            this.txtDNewPassword.Text = "New Password";
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtNewPassword.Location = new System.Drawing.Point(193, 12);
            this.txtNewPassword.MaxLength = 20;
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.PasswordChar = '*';
            this.txtNewPassword.Size = new System.Drawing.Size(200, 27);
            this.txtNewPassword.TabIndex = 8;
            this.txtNewPassword.Enter += new System.EventHandler(this.txtNewPassword_Enter);
            this.txtNewPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNewPassword_KeyDown);
            this.txtNewPassword.Leave += new System.EventHandler(this.txtNewPassword_Leave);
            // 
            // CP_User_ResetPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(403, 116);
            this.Controls.Add(this.txtDConfirmPassword);
            this.Controls.Add(this.txtConfirmPassword);
            this.Controls.Add(this.txtDNewPassword);
            this.Controls.Add(this.txtNewPassword);
            this.Controls.Add(this.btnSave);
            this.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CP_User_ResetPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reset Password";
            this.Load += new System.EventHandler(this.CP_User_ResetPassword_Load);
            ((System.ComponentModel.ISupportInitialize)(this.epPassword)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ErrorProvider epPassword;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtDConfirmPassword;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.TextBox txtDNewPassword;
        private System.Windows.Forms.TextBox txtNewPassword;
    }
}