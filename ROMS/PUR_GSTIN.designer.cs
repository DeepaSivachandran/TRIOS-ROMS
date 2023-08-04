namespace ROMS
{
    partial class PUR_GSTIN
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PUR_GSTIN));
            this.errUnit = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtDPasskey = new System.Windows.Forms.TextBox();
            this.txtEUnitName = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
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
            this.txtDPasskey.Name = "txtDPasskey";
            this.txtDPasskey.ReadOnly = true;
            this.txtDPasskey.Size = new System.Drawing.Size(62, 28);
            this.txtDPasskey.TabIndex = 11;
            this.txtDPasskey.Text = "GSTIN";
            // 
            // txtEUnitName
            // 
            this.txtEUnitName.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEUnitName.Location = new System.Drawing.Point(74, 14);
            this.txtEUnitName.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtEUnitName.MaxLength = 50;
            this.txtEUnitName.Name = "txtEUnitName";
            this.txtEUnitName.Size = new System.Drawing.Size(174, 28);
            this.txtEUnitName.TabIndex = 8;
            this.txtEUnitName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtEUnitName_KeyPress);
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
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Submit";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // PUR_GSTIN
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
            this.Name = "PUR_GSTIN";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GSTIN";
            ((System.ComponentModel.ISupportInitialize)(this.errUnit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ErrorProvider errUnit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtDPasskey;
        private System.Windows.Forms.TextBox txtEUnitName;
    }
}