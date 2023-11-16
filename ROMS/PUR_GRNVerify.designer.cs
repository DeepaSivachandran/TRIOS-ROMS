namespace ROMS
{
    partial class PUR_GRNVerify
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PUR_GRNVerify));
            this.errUnit = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtDPasskey = new System.Windows.Forms.TextBox();
            this.txtPassKey = new System.Windows.Forms.TextBox();
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
            this.txtDPasskey.Text = "Pass Key";
            // 
            // txtPassKey
            // 
            this.txtPassKey.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassKey.Location = new System.Drawing.Point(74, 14);
            this.txtPassKey.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtPassKey.MaxLength = 50;
            this.txtPassKey.Name = "txtPassKey";
            this.txtPassKey.Size = new System.Drawing.Size(174, 28);
            this.txtPassKey.TabIndex = 1;
            this.txtPassKey.Enter += new System.EventHandler(this.TxtEUnitName_Enter);
            this.txtPassKey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtEUnitName_KeyDown);
            this.txtPassKey.Leave += new System.EventHandler(this.TxtEUnitName_Leave);
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
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Confirm";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            this.btnSave.Enter += new System.EventHandler(this.BtnSave_Enter);
            this.btnSave.Leave += new System.EventHandler(this.BtnSave_Leave);
            // 
            // PUR_GRNVerify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(259, 91);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtDPasskey);
            this.Controls.Add(this.txtPassKey);
            this.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PUR_GRNVerify";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GRN Verify";
            ((System.ComponentModel.ISupportInitialize)(this.errUnit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ErrorProvider errUnit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtDPasskey;
        private System.Windows.Forms.TextBox txtPassKey;
    }
}