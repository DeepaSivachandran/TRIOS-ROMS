namespace ROMS
{
    partial class CP_Group
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CP_Group));
            this.grbform = new System.Windows.Forms.GroupBox();
            this.txtDProductGroupNameTamil = new System.Windows.Forms.TextBox();
            this.txtEGroupNameTamil = new System.Windows.Forms.TextBox();
            this.txtDStatus = new System.Windows.Forms.TextBox();
            this.pnlStatus = new System.Windows.Forms.Panel();
            this.rbActive = new System.Windows.Forms.RadioButton();
            this.rbInActive = new System.Windows.Forms.RadioButton();
            this.txtDProductGroupNameEnglish = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtEGroupNameEnglish = new System.Windows.Forms.TextBox();
            this.epGroup = new System.Windows.Forms.ErrorProvider(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.grbform.SuspendLayout();
            this.pnlStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epGroup)).BeginInit();
            this.SuspendLayout();
            // 
            // grbform
            // 
            this.grbform.Controls.Add(this.txtDescription);
            this.grbform.Controls.Add(this.textBox1);
            this.grbform.Controls.Add(this.txtDProductGroupNameTamil);
            this.grbform.Controls.Add(this.txtEGroupNameTamil);
            this.grbform.Controls.Add(this.txtDStatus);
            this.grbform.Controls.Add(this.pnlStatus);
            this.grbform.Controls.Add(this.txtDProductGroupNameEnglish);
            this.grbform.Controls.Add(this.btnClose);
            this.grbform.Controls.Add(this.btnSave);
            this.grbform.Controls.Add(this.txtEGroupNameEnglish);
            this.grbform.Location = new System.Drawing.Point(16, 10);
            this.grbform.Name = "grbform";
            this.grbform.Size = new System.Drawing.Size(552, 218);
            this.grbform.TabIndex = 0;
            this.grbform.TabStop = false;
            // 
            // txtDProductGroupNameTamil
            // 
            this.txtDProductGroupNameTamil.BackColor = System.Drawing.SystemColors.Control;
            this.txtDProductGroupNameTamil.Enabled = false;
            this.txtDProductGroupNameTamil.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDProductGroupNameTamil.Location = new System.Drawing.Point(40, 53);
            this.txtDProductGroupNameTamil.Name = "txtDProductGroupNameTamil";
            this.txtDProductGroupNameTamil.ReadOnly = true;
            this.txtDProductGroupNameTamil.Size = new System.Drawing.Size(181, 27);
            this.txtDProductGroupNameTamil.TabIndex = 19;
            this.txtDProductGroupNameTamil.Text = "Product Group Name in Tamil";
            // 
            // txtEGroupNameTamil
            // 
            this.txtEGroupNameTamil.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEGroupNameTamil.Location = new System.Drawing.Point(221, 53);
            this.txtEGroupNameTamil.MaxLength = 100;
            this.txtEGroupNameTamil.Name = "txtEGroupNameTamil";
            this.txtEGroupNameTamil.Size = new System.Drawing.Size(288, 27);
            this.txtEGroupNameTamil.TabIndex = 1;
            this.txtEGroupNameTamil.Enter += new System.EventHandler(this.TxtEGroupNameTamil_Enter);
            this.txtEGroupNameTamil.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtEGroupNameTamil_KeyDown);
            this.txtEGroupNameTamil.Leave += new System.EventHandler(this.TxtEGroupNameTamil_Leave);
            // 
            // txtDStatus
            // 
            this.txtDStatus.BackColor = System.Drawing.SystemColors.Control;
            this.txtDStatus.Enabled = false;
            this.txtDStatus.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDStatus.Location = new System.Drawing.Point(40, 142);
            this.txtDStatus.Name = "txtDStatus";
            this.txtDStatus.ReadOnly = true;
            this.txtDStatus.Size = new System.Drawing.Size(181, 27);
            this.txtDStatus.TabIndex = 17;
            this.txtDStatus.Text = "Status";
            // 
            // pnlStatus
            // 
            this.pnlStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlStatus.Controls.Add(this.rbActive);
            this.pnlStatus.Controls.Add(this.rbInActive);
            this.pnlStatus.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlStatus.Location = new System.Drawing.Point(221, 142);
            this.pnlStatus.Name = "pnlStatus";
            this.pnlStatus.Size = new System.Drawing.Size(288, 27);
            this.pnlStatus.TabIndex = 3;
            // 
            // rbActive
            // 
            this.rbActive.AutoSize = true;
            this.rbActive.Checked = true;
            this.rbActive.Font = new System.Drawing.Font("Oswald Regular", 9.75F);
            this.rbActive.Location = new System.Drawing.Point(66, 1);
            this.rbActive.Name = "rbActive";
            this.rbActive.Size = new System.Drawing.Size(54, 21);
            this.rbActive.TabIndex = 3;
            this.rbActive.TabStop = true;
            this.rbActive.Text = "Active";
            this.rbActive.UseVisualStyleBackColor = true;
            this.rbActive.Enter += new System.EventHandler(this.RbActive_Enter);
            this.rbActive.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RbActive_KeyDown);
            this.rbActive.Leave += new System.EventHandler(this.RbActive_Leave);
            // 
            // rbInActive
            // 
            this.rbInActive.AutoSize = true;
            this.rbInActive.Font = new System.Drawing.Font("Oswald Regular", 9.75F);
            this.rbInActive.Location = new System.Drawing.Point(145, 1);
            this.rbInActive.Name = "rbInActive";
            this.rbInActive.Size = new System.Drawing.Size(63, 21);
            this.rbInActive.TabIndex = 4;
            this.rbInActive.Text = "Inactive";
            this.rbInActive.UseVisualStyleBackColor = true;
            this.rbInActive.Enter += new System.EventHandler(this.RbInactive_Enter);
            this.rbInActive.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RbInactive_KeyDown);
            this.rbInActive.Leave += new System.EventHandler(this.RbInactive_Leave);
            // 
            // txtDProductGroupNameEnglish
            // 
            this.txtDProductGroupNameEnglish.BackColor = System.Drawing.SystemColors.Control;
            this.txtDProductGroupNameEnglish.Enabled = false;
            this.txtDProductGroupNameEnglish.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDProductGroupNameEnglish.Location = new System.Drawing.Point(40, 26);
            this.txtDProductGroupNameEnglish.Name = "txtDProductGroupNameEnglish";
            this.txtDProductGroupNameEnglish.ReadOnly = true;
            this.txtDProductGroupNameEnglish.Size = new System.Drawing.Size(181, 27);
            this.txtDProductGroupNameEnglish.TabIndex = 11;
            this.txtDProductGroupNameEnglish.Text = "Product Group Name in English";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnClose.Image = global::ROMS.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(434, 175);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 29);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            this.btnClose.Enter += new System.EventHandler(this.BtnClose_Enter);
            this.btnClose.Leave += new System.EventHandler(this.BtnClose_Leave);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnSave.Image = global::ROMS.Properties.Resources.save;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(344, 175);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(84, 29);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            this.btnSave.Enter += new System.EventHandler(this.BtnSave_Enter);
            this.btnSave.Leave += new System.EventHandler(this.BtnSave_Leave);
            // 
            // txtEGroupNameEnglish
            // 
            this.txtEGroupNameEnglish.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEGroupNameEnglish.Location = new System.Drawing.Point(221, 26);
            this.txtEGroupNameEnglish.MaxLength = 100;
            this.txtEGroupNameEnglish.Name = "txtEGroupNameEnglish";
            this.txtEGroupNameEnglish.Size = new System.Drawing.Size(288, 27);
            this.txtEGroupNameEnglish.TabIndex = 0;
            this.txtEGroupNameEnglish.Enter += new System.EventHandler(this.TxtEGroupNameEnglish_Enter);
            this.txtEGroupNameEnglish.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtEGroupNameEnglish_KeyDown);
            this.txtEGroupNameEnglish.Leave += new System.EventHandler(this.TxtEGroupNameEnglish_Leave);
            // 
            // epGroup
            // 
            this.epGroup.ContainerControl = this;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(40, 80);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(181, 27);
            this.textBox1.TabIndex = 20;
            this.textBox1.Text = "Product Group Description";
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(221, 80);
            this.txtDescription.MaxLength = 100;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(288, 62);
            this.txtDescription.TabIndex = 2;
            this.txtDescription.Enter += new System.EventHandler(this.txtDescription_Enter);
            this.txtDescription.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDescription_KeyDown);
            this.txtDescription.Leave += new System.EventHandler(this.txtDescription_Leave);
            // 
            // CP_Group
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(585, 240);
            this.Controls.Add(this.grbform);
            this.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CP_Group";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Product Group";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CP_Group_FormClosing);
            this.Load += new System.EventHandler(this.CP_Group_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CP_Group_KeyDown);
            this.Leave += new System.EventHandler(this.CP_Group_Leave);
            this.grbform.ResumeLayout(false);
            this.grbform.PerformLayout();
            this.pnlStatus.ResumeLayout(false);
            this.pnlStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epGroup)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox grbform;
        private System.Windows.Forms.TextBox txtDProductGroupNameEnglish;
        private System.Windows.Forms.TextBox txtEGroupNameEnglish;
        private System.Windows.Forms.ErrorProvider epGroup;
        private System.Windows.Forms.TextBox txtDStatus;
        private System.Windows.Forms.Panel pnlStatus;
        private System.Windows.Forms.RadioButton rbInActive;
        private System.Windows.Forms.RadioButton rbActive;
        private System.Windows.Forms.TextBox txtDProductGroupNameTamil;
        private System.Windows.Forms.TextBox txtEGroupNameTamil;
        public System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox txtDescription;
    }
}