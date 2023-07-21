namespace ROMS
{
    partial class CP_ChangePasswordConfirmation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CP_ChangePasswordConfirmation));
            this.btnSave = new System.Windows.Forms.Button();
            this.txtDPasskey = new System.Windows.Forms.TextBox();
            this.txtEUnitName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::ROMS.Properties.Resources.approve;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(162, 47);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(86, 33);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "Confirm";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // txtDPasskey
            // 
            this.txtDPasskey.BackColor = System.Drawing.SystemColors.Control;
            this.txtDPasskey.Enabled = false;
            this.txtDPasskey.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDPasskey.Location = new System.Drawing.Point(12, 14);
            this.txtDPasskey.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtDPasskey.Name = "txtDPasskey";
            this.txtDPasskey.ReadOnly = true;
            this.txtDPasskey.Size = new System.Drawing.Size(62, 28);
            this.txtDPasskey.TabIndex = 14;
            this.txtDPasskey.Text = "Pass Key";
            // 
            // txtEUnitName
            // 
            this.txtEUnitName.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEUnitName.Location = new System.Drawing.Point(74, 14);
            this.txtEUnitName.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtEUnitName.MaxLength = 50;
            this.txtEUnitName.Name = "txtEUnitName";
            this.txtEUnitName.Size = new System.Drawing.Size(174, 28);
            this.txtEUnitName.TabIndex = 12;
            // 
            // CP_ChangePasswordConfirmation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(259, 91);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtDPasskey);
            this.Controls.Add(this.txtEUnitName);
            this.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CP_ChangePasswordConfirmation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Confirmation";
            this.Load += new System.EventHandler(this.CP_Brand_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtEUnitName;
        public System.Windows.Forms.TextBox txtDPasskey;
    }
}