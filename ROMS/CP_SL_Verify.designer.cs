namespace ROMS
{
    partial class CP_SL_Verify
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CP_SL_Verify));
            this.errUnit = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtDPasskey = new System.Windows.Forms.TextBox();
            this.txtPassKey = new System.Windows.Forms.TextBox();
            this.btnAuthorise = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errUnit)).BeginInit();
            this.SuspendLayout();
            // 
            // errUnit
            // 
            this.errUnit.ContainerControl = this;
            // 
            // txtDPasskey
            // 
            this.txtDPasskey.BackColor = System.Drawing.SystemColors.Control;
            this.txtDPasskey.Enabled = false;
            this.txtDPasskey.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDPasskey.Location = new System.Drawing.Point(12, 14);
            this.txtDPasskey.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtDPasskey.MaxLength = 6;
            this.txtDPasskey.Name = "txtDPasskey";
            this.txtDPasskey.ReadOnly = true;
            this.txtDPasskey.Size = new System.Drawing.Size(62, 28);
            this.txtDPasskey.TabIndex = 11;
            this.txtDPasskey.Text = "Passkey";
            // 
            // txtPassKey
            // 
            this.txtPassKey.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassKey.Location = new System.Drawing.Point(74, 14);
            this.txtPassKey.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtPassKey.MaxLength = 6;
               this.txtPassKey.Name = "txtPassKey";
            this.txtPassKey.PasswordChar = '*';
            this.txtPassKey.Size = new System.Drawing.Size(174, 28);
            this.txtPassKey.TabIndex = 8;
            this.txtPassKey.Enter += new System.EventHandler(this.TxtPassKey_Enter);
            this.txtPassKey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtPassKey_KeyDown);
            this.txtPassKey.Leave += new System.EventHandler(this.TxtPassKey_Leave);
            // 
            // btnAuthorise
            // 
            this.btnAuthorise.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAuthorise.Image = global::ROMS.Properties.Resources.approve;
            this.btnAuthorise.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAuthorise.Location = new System.Drawing.Point(155, 47);
            this.btnAuthorise.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnAuthorise.Name = "btnAuthorise";
            this.btnAuthorise.Size = new System.Drawing.Size(93, 33);
            this.btnAuthorise.TabIndex = 9;
            this.btnAuthorise.Text = "Authorize";
            this.btnAuthorise.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAuthorise.UseVisualStyleBackColor = true;
            this.btnAuthorise.Click += new System.EventHandler(this.btnAuthorise_Click);
            this.btnAuthorise.Enter += new System.EventHandler(this.BtnAuthorise_Enter);
            this.btnAuthorise.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BtnAuthorise_KeyDown);
            this.btnAuthorise.Leave += new System.EventHandler(this.BtnAuthorise_Leave);
            // 
            // CP_SL_Verify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(259, 91);
            this.Controls.Add(this.btnAuthorise);
            this.Controls.Add(this.txtDPasskey);
            this.Controls.Add(this.txtPassKey);
            this.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CP_SL_Verify";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Please Enter Passkey to Proceed";
            ((System.ComponentModel.ISupportInitialize)(this.errUnit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ErrorProvider errUnit;
        private System.Windows.Forms.Button btnAuthorise;
        private System.Windows.Forms.TextBox txtDPasskey;
        private System.Windows.Forms.TextBox txtPassKey;
    }
}