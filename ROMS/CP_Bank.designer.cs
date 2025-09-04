namespace ROMS
{
    partial class CP_Bank
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CP_Bank));
            this.txtDCityName = new System.Windows.Forms.TextBox();
            this.txtDStateName = new System.Windows.Forms.TextBox();
            this.grbform = new System.Windows.Forms.GroupBox();
            this.txtBankName = new System.Windows.Forms.TextBox();
            this.txtShortName = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.epBank = new System.Windows.Forms.ErrorProvider(this.components);
            this.grbform.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epBank)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDCityName
            // 
            this.txtDCityName.BackColor = System.Drawing.SystemColors.Control;
            this.txtDCityName.Enabled = false;
            this.txtDCityName.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDCityName.Location = new System.Drawing.Point(37, 74);
            this.txtDCityName.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtDCityName.Name = "txtDCityName";
            this.txtDCityName.ReadOnly = true;
            this.txtDCityName.Size = new System.Drawing.Size(122, 28);
            this.txtDCityName.TabIndex = 6;
            this.txtDCityName.Text = "Bank Short Name";
            // 
            // txtDStateName
            // 
            this.txtDStateName.BackColor = System.Drawing.SystemColors.Control;
            this.txtDStateName.Enabled = false;
            this.txtDStateName.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDStateName.Location = new System.Drawing.Point(37, 46);
            this.txtDStateName.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtDStateName.Name = "txtDStateName";
            this.txtDStateName.ReadOnly = true;
            this.txtDStateName.Size = new System.Drawing.Size(122, 28);
            this.txtDStateName.TabIndex = 7;
            this.txtDStateName.Text = "Bank Name";
            // 
            // grbform
            // 
            this.grbform.Controls.Add(this.txtBankName);
            this.grbform.Controls.Add(this.txtShortName);
            this.grbform.Controls.Add(this.btnClose);
            this.grbform.Controls.Add(this.btnSave);
            this.grbform.Controls.Add(this.txtDCityName);
            this.grbform.Controls.Add(this.txtDStateName);
            this.grbform.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.grbform.Location = new System.Drawing.Point(13, 14);
            this.grbform.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.grbform.Name = "grbform";
            this.grbform.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.grbform.Size = new System.Drawing.Size(437, 171);
            this.grbform.TabIndex = 28;
            this.grbform.TabStop = false;
            // 
            // txtBankName
            // 
            this.txtBankName.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBankName.Location = new System.Drawing.Point(159, 46);
            this.txtBankName.MaxLength = 50;
            this.txtBankName.Name = "txtBankName";
            this.txtBankName.Size = new System.Drawing.Size(240, 28);
            this.txtBankName.TabIndex = 0;
            this.txtBankName.Enter += new System.EventHandler(this.TxtBankName_Enter);
            this.txtBankName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtBankName_KeyDown);
            this.txtBankName.Leave += new System.EventHandler(this.TxtBankName_Leave);
            // 
            // txtShortName
            // 
            this.txtShortName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtShortName.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtShortName.Location = new System.Drawing.Point(159, 74);
            this.txtShortName.MaxLength = 20;
            this.txtShortName.Name = "txtShortName";
            this.txtShortName.Size = new System.Drawing.Size(240, 28);
            this.txtShortName.TabIndex = 1;
            this.txtShortName.Enter += new System.EventHandler(this.TxtCityName_Enter);
            this.txtShortName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtCityName_KeyDown);
            this.txtShortName.Leave += new System.EventHandler(this.TxtCityName_Leave);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::ROMS.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(319, 112);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 33);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            this.btnClose.Enter += new System.EventHandler(this.btnClose_Enter);
            this.btnClose.Leave += new System.EventHandler(this.btnClose_Leave);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::ROMS.Properties.Resources.save;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(234, 112);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 33);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.Enter += new System.EventHandler(this.btnSave_Enter);
            this.btnSave.Leave += new System.EventHandler(this.btnSave_Leave);
            // 
            // epBank
            // 
            this.epBank.ContainerControl = this;
            // 
            // CP_Bank
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(469, 210);
            this.Controls.Add(this.grbform);
            this.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CP_Bank";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bank Details";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CP_City_FormClosing);
            this.Load += new System.EventHandler(this.CP_City_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CP_City_KeyDown);
            this.Leave += new System.EventHandler(this.CP_City_Leave);
            this.grbform.ResumeLayout(false);
            this.grbform.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epBank)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtDCityName;
        private System.Windows.Forms.TextBox txtDStateName;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox grbform;
        private System.Windows.Forms.ErrorProvider epBank;
        public System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtShortName;
        private System.Windows.Forms.TextBox txtBankName;
    }
}