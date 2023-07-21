namespace ROMS
{
    partial class CP_UserCatagory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CP_UserCatagory));
            this.pnlStatus = new System.Windows.Forms.Panel();
            this.rbInactive = new System.Windows.Forms.RadioButton();
            this.rbActive = new System.Windows.Forms.RadioButton();
            this.txtDStatus = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.grbUserCatagory = new System.Windows.Forms.GroupBox();
            this.txtDCatagoryName = new System.Windows.Forms.TextBox();
            this.txtCatagoryName = new System.Windows.Forms.TextBox();
            this.errUserCatagory = new System.Windows.Forms.ErrorProvider(this.components);
            this.pnlStatus.SuspendLayout();
            this.grbUserCatagory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errUserCatagory)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlStatus
            // 
            this.pnlStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlStatus.Controls.Add(this.rbInactive);
            this.pnlStatus.Controls.Add(this.rbActive);
            this.pnlStatus.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlStatus.Location = new System.Drawing.Point(197, 53);
            this.pnlStatus.Name = "pnlStatus";
            this.pnlStatus.Size = new System.Drawing.Size(288, 27);
            this.pnlStatus.TabIndex = 5;
            // 
            // rbInactive
            // 
            this.rbInactive.AutoSize = true;
            this.rbInactive.Font = new System.Drawing.Font("Oswald Regular", 9.75F);
            this.rbInactive.Location = new System.Drawing.Point(150, 1);
            this.rbInactive.Name = "rbInactive";
            this.rbInactive.Size = new System.Drawing.Size(63, 21);
            this.rbInactive.TabIndex = 7;
            this.rbInactive.Text = "Inactive";
            this.rbInactive.UseVisualStyleBackColor = true;
            this.rbInactive.Enter += new System.EventHandler(this.rbInactive_Enter);
            this.rbInactive.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rbInactive_KeyDown);
            this.rbInactive.Leave += new System.EventHandler(this.rbInactive_Leave);
            // 
            // rbActive
            // 
            this.rbActive.AutoSize = true;
            this.rbActive.Checked = true;
            this.rbActive.Font = new System.Drawing.Font("Oswald Regular", 9.75F);
            this.rbActive.Location = new System.Drawing.Point(62, 1);
            this.rbActive.Name = "rbActive";
            this.rbActive.Size = new System.Drawing.Size(54, 21);
            this.rbActive.TabIndex = 6;
            this.rbActive.TabStop = true;
            this.rbActive.Text = "Active";
            this.rbActive.UseVisualStyleBackColor = true;
            this.rbActive.Enter += new System.EventHandler(this.rbActive_Enter);
            this.rbActive.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rbActive_KeyDown);
            this.rbActive.Leave += new System.EventHandler(this.rbActive_Leave);
            // 
            // txtDStatus
            // 
            this.txtDStatus.BackColor = System.Drawing.SystemColors.Control;
            this.txtDStatus.Enabled = false;
            this.txtDStatus.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDStatus.Location = new System.Drawing.Point(17, 53);
            this.txtDStatus.Name = "txtDStatus";
            this.txtDStatus.ReadOnly = true;
            this.txtDStatus.Size = new System.Drawing.Size(181, 27);
            this.txtDStatus.TabIndex = 15;
            this.txtDStatus.Text = "Status";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnSave.Image = global::ROMS.Properties.Resources.save;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(320, 89);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(84, 29);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.Enter += new System.EventHandler(this.btnSave_Enter);
            this.btnSave.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnSave_KeyDown);
            this.btnSave.Leave += new System.EventHandler(this.btnSave_Leave);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnClose.Image = global::ROMS.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(410, 89);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 29);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            this.btnClose.Enter += new System.EventHandler(this.btnClose_Enter);
            this.btnClose.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnClose_KeyDown);
            this.btnClose.Leave += new System.EventHandler(this.btnClose_Leave);
            // 
            // grbUserCatagory
            // 
            this.grbUserCatagory.Controls.Add(this.txtDCatagoryName);
            this.grbUserCatagory.Controls.Add(this.txtCatagoryName);
            this.grbUserCatagory.Controls.Add(this.btnClose);
            this.grbUserCatagory.Controls.Add(this.txtDStatus);
            this.grbUserCatagory.Controls.Add(this.btnSave);
            this.grbUserCatagory.Controls.Add(this.pnlStatus);
            this.grbUserCatagory.Location = new System.Drawing.Point(17, 4);
            this.grbUserCatagory.Name = "grbUserCatagory";
            this.grbUserCatagory.Size = new System.Drawing.Size(503, 131);
            this.grbUserCatagory.TabIndex = 0;
            this.grbUserCatagory.TabStop = false;
            // 
            // txtDCatagoryName
            // 
            this.txtDCatagoryName.BackColor = System.Drawing.SystemColors.Control;
            this.txtDCatagoryName.Enabled = false;
            this.txtDCatagoryName.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDCatagoryName.Location = new System.Drawing.Point(17, 26);
            this.txtDCatagoryName.Name = "txtDCatagoryName";
            this.txtDCatagoryName.ReadOnly = true;
            this.txtDCatagoryName.Size = new System.Drawing.Size(181, 27);
            this.txtDCatagoryName.TabIndex = 19;
            this.txtDCatagoryName.Text = "Catagory Name";
            // 
            // txtCatagoryName
            // 
            this.txtCatagoryName.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCatagoryName.Location = new System.Drawing.Point(197, 26);
            this.txtCatagoryName.MaxLength = 20;
            this.txtCatagoryName.Name = "txtCatagoryName";
            this.txtCatagoryName.PasswordChar = '*';
            this.txtCatagoryName.Size = new System.Drawing.Size(288, 27);
            this.txtCatagoryName.TabIndex = 18;
            // 
            // errUserCatagory
            // 
            this.errUserCatagory.ContainerControl = this;
            // 
            // CP_UserCatagory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(540, 147);
            this.Controls.Add(this.grbUserCatagory);
            this.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CP_UserCatagory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Catagory";
            this.Load += new System.EventHandler(this.CP_User_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CP_User_KeyDown);
            this.Leave += new System.EventHandler(this.CP_User_Leave);
            this.pnlStatus.ResumeLayout(false);
            this.pnlStatus.PerformLayout();
            this.grbUserCatagory.ResumeLayout(false);
            this.grbUserCatagory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errUserCatagory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlStatus;
        private System.Windows.Forms.RadioButton rbInactive;
        private System.Windows.Forms.RadioButton rbActive;
        private System.Windows.Forms.TextBox txtDStatus;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox grbUserCatagory;
        private System.Windows.Forms.ErrorProvider errUserCatagory;
        private System.Windows.Forms.TextBox txtDCatagoryName;
        private System.Windows.Forms.TextBox txtCatagoryName;
    }
}