namespace ROMS
{
    partial class CP_Employee
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CP_Employee));
            this.txtDLoginID = new System.Windows.Forms.TextBox();
            this.txtEmpName = new System.Windows.Forms.TextBox();
            this.txtDUserName = new System.Windows.Forms.TextBox();
            this.txtEmpCode = new System.Windows.Forms.TextBox();
            this.pnlStatus = new System.Windows.Forms.Panel();
            this.rbInactive = new System.Windows.Forms.RadioButton();
            this.rbActive = new System.Windows.Forms.RadioButton();
            this.txtDStatus = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.grbForm = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtEmployeeNameinTamil = new System.Windows.Forms.TextBox();
            this.btnNew = new System.Windows.Forms.Label();
            this.cmbUserCategory = new System.Windows.Forms.ComboBox();
            this.txtDUserCategory = new System.Windows.Forms.TextBox();
            this.epUser = new System.Windows.Forms.ErrorProvider(this.components);
            this.pnlStatus.SuspendLayout();
            this.grbForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epUser)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDLoginID
            // 
            this.txtDLoginID.BackColor = System.Drawing.SystemColors.Control;
            this.txtDLoginID.Enabled = false;
            this.txtDLoginID.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDLoginID.Location = new System.Drawing.Point(24, 51);
            this.txtDLoginID.Name = "txtDLoginID";
            this.txtDLoginID.ReadOnly = true;
            this.txtDLoginID.Size = new System.Drawing.Size(181, 27);
            this.txtDLoginID.TabIndex = 11;
            this.txtDLoginID.Text = "Employee Name in English";
            this.txtDLoginID.TextChanged += new System.EventHandler(this.txtDLoginID_TextChanged);
            // 
            // txtEmpName
            // 
            this.txtEmpName.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmpName.Location = new System.Drawing.Point(204, 51);
            this.txtEmpName.MaxLength = 50;
            this.txtEmpName.Name = "txtEmpName";
            this.txtEmpName.Size = new System.Drawing.Size(288, 27);
            this.txtEmpName.TabIndex = 1;
            this.txtEmpName.TextChanged += new System.EventHandler(this.txtEmpName_TextChanged);
            this.txtEmpName.Enter += new System.EventHandler(this.txtLoginID_Enter);
            this.txtEmpName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLoginID_KeyDown);
            this.txtEmpName.Leave += new System.EventHandler(this.txtLoginID_Leave);
            // 
            // txtDUserName
            // 
            this.txtDUserName.BackColor = System.Drawing.SystemColors.Control;
            this.txtDUserName.Enabled = false;
            this.txtDUserName.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDUserName.Location = new System.Drawing.Point(24, 24);
            this.txtDUserName.Name = "txtDUserName";
            this.txtDUserName.ReadOnly = true;
            this.txtDUserName.Size = new System.Drawing.Size(181, 27);
            this.txtDUserName.TabIndex = 10;
            this.txtDUserName.Text = "Employee Code";
            // 
            // txtEmpCode
            // 
            this.txtEmpCode.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmpCode.Location = new System.Drawing.Point(204, 24);
            this.txtEmpCode.MaxLength = 10;
            this.txtEmpCode.Name = "txtEmpCode";
            this.txtEmpCode.Size = new System.Drawing.Size(288, 27);
            this.txtEmpCode.TabIndex = 0;
            this.txtEmpCode.Enter += new System.EventHandler(this.TxtUserName_Enter);
            this.txtEmpCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtUserName_KeyDown);
            this.txtEmpCode.Leave += new System.EventHandler(this.txtUserName_Leave);
            // 
            // pnlStatus
            // 
            this.pnlStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlStatus.Controls.Add(this.rbInactive);
            this.pnlStatus.Controls.Add(this.rbActive);
            this.pnlStatus.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlStatus.Location = new System.Drawing.Point(204, 132);
            this.pnlStatus.Name = "pnlStatus";
            this.pnlStatus.Size = new System.Drawing.Size(288, 27);
            this.pnlStatus.TabIndex = 5;
            this.pnlStatus.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlStatus_Paint);
            // 
            // rbInactive
            // 
            this.rbInactive.AutoSize = true;
            this.rbInactive.Font = new System.Drawing.Font("Oswald Regular", 9.75F);
            this.rbInactive.Location = new System.Drawing.Point(150, 1);
            this.rbInactive.Name = "rbInactive";
            this.rbInactive.Size = new System.Drawing.Size(63, 21);
            this.rbInactive.TabIndex = 8;
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
            this.rbActive.TabIndex = 7;
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
            this.txtDStatus.Location = new System.Drawing.Point(24, 132);
            this.txtDStatus.Name = "txtDStatus";
            this.txtDStatus.ReadOnly = true;
            this.txtDStatus.Size = new System.Drawing.Size(181, 27);
            this.txtDStatus.TabIndex = 15;
            this.txtDStatus.Text = "Status";
            this.txtDStatus.TextChanged += new System.EventHandler(this.txtDStatus_TextChanged);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnSave.Image = global::ROMS.Properties.Resources.save;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(327, 165);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(84, 29);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.Enter += new System.EventHandler(this.btnSave_Enter);
            this.btnSave.Leave += new System.EventHandler(this.btnSave_Leave);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnClose.Image = global::ROMS.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(417, 165);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 29);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            this.btnClose.Enter += new System.EventHandler(this.btnClose_Enter);
            this.btnClose.Leave += new System.EventHandler(this.btnClose_Leave);
            // 
            // grbForm
            // 
            this.grbForm.Controls.Add(this.textBox1);
            this.grbForm.Controls.Add(this.txtEmployeeNameinTamil);
            this.grbForm.Controls.Add(this.btnNew);
            this.grbForm.Controls.Add(this.cmbUserCategory);
            this.grbForm.Controls.Add(this.txtDUserCategory);
            this.grbForm.Controls.Add(this.btnClose);
            this.grbForm.Controls.Add(this.txtDStatus);
            this.grbForm.Controls.Add(this.btnSave);
            this.grbForm.Controls.Add(this.pnlStatus);
            this.grbForm.Controls.Add(this.txtDLoginID);
            this.grbForm.Controls.Add(this.txtEmpName);
            this.grbForm.Controls.Add(this.txtDUserName);
            this.grbForm.Controls.Add(this.txtEmpCode);
            this.grbForm.Location = new System.Drawing.Point(17, 4);
            this.grbForm.Name = "grbForm";
            this.grbForm.Size = new System.Drawing.Size(520, 205);
            this.grbForm.TabIndex = 0;
            this.grbForm.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(24, 78);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(181, 27);
            this.textBox1.TabIndex = 25;
            this.textBox1.Text = "Employee Name in Tamil";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // txtEmployeeNameinTamil
            // 
            this.txtEmployeeNameinTamil.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmployeeNameinTamil.Location = new System.Drawing.Point(204, 79);
            this.txtEmployeeNameinTamil.MaxLength = 50;
            this.txtEmployeeNameinTamil.Name = "txtEmployeeNameinTamil";
            this.txtEmployeeNameinTamil.Size = new System.Drawing.Size(288, 25);
            this.txtEmployeeNameinTamil.TabIndex = 2;
            this.txtEmployeeNameinTamil.Enter += new System.EventHandler(this.txtEmployeeNameinTamil_Enter);
            this.txtEmployeeNameinTamil.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEmployeeNameinTamil_KeyDown);
            this.txtEmployeeNameinTamil.Leave += new System.EventHandler(this.txtEmployeeNameinTamil_Leave);
            // 
            // btnNew
            // 
            this.btnNew.Image = global::ROMS.Properties.Resources.New;
            this.btnNew.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnNew.Location = new System.Drawing.Point(497, 107);
            this.btnNew.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(21, 22);
            this.btnNew.TabIndex = 4;
            this.btnNew.Text = "        ";
            this.btnNew.Click += new System.EventHandler(this.BtnNew_Click);
            // 
            // cmbUserCategory
            // 
            this.cmbUserCategory.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbUserCategory.FormattingEnabled = true;
            this.cmbUserCategory.Location = new System.Drawing.Point(204, 105);
            this.cmbUserCategory.Name = "cmbUserCategory";
            this.cmbUserCategory.Size = new System.Drawing.Size(288, 27);
            this.cmbUserCategory.TabIndex = 3;
            this.cmbUserCategory.SelectedIndexChanged += new System.EventHandler(this.CmbUserCategory_SelectedIndexChanged);
            this.cmbUserCategory.Enter += new System.EventHandler(this.CmbUserCategory_Enter);
            this.cmbUserCategory.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbUserCategory_KeyDown);
            this.cmbUserCategory.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbUserCategory_KeyPress);
            this.cmbUserCategory.Leave += new System.EventHandler(this.CmbUserCategory_Leave);
            // 
            // txtDUserCategory
            // 
            this.txtDUserCategory.BackColor = System.Drawing.SystemColors.Control;
            this.txtDUserCategory.Enabled = false;
            this.txtDUserCategory.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDUserCategory.Location = new System.Drawing.Point(24, 105);
            this.txtDUserCategory.Name = "txtDUserCategory";
            this.txtDUserCategory.ReadOnly = true;
            this.txtDUserCategory.Size = new System.Drawing.Size(181, 27);
            this.txtDUserCategory.TabIndex = 22;
            this.txtDUserCategory.Text = "Employee Category";
            this.txtDUserCategory.TextChanged += new System.EventHandler(this.txtDUserCategory_TextChanged);
            // 
            // epUser
            // 
            this.epUser.ContainerControl = this;
            // 
            // CP_Employee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(553, 223);
            this.Controls.Add(this.grbForm);
            this.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CP_Employee";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Employee";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CP_Employee_FormClosing);
            this.Load += new System.EventHandler(this.CP_Employee_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CP_Employee_KeyDown);
            this.Leave += new System.EventHandler(this.CP_Employee_Leave);
            this.pnlStatus.ResumeLayout(false);
            this.pnlStatus.PerformLayout();
            this.grbForm.ResumeLayout(false);
            this.grbForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epUser)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtDLoginID;
        private System.Windows.Forms.TextBox txtEmpName;
        private System.Windows.Forms.TextBox txtDUserName;
        private System.Windows.Forms.Panel pnlStatus;
        private System.Windows.Forms.RadioButton rbInactive;
        private System.Windows.Forms.RadioButton rbActive;
        private System.Windows.Forms.TextBox txtDStatus;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox grbForm;
        private System.Windows.Forms.ErrorProvider epUser;
        private System.Windows.Forms.ComboBox cmbUserCategory;
        private System.Windows.Forms.TextBox txtDUserCategory;
        public System.Windows.Forms.Button btnSave;
        internal System.Windows.Forms.Label btnNew;
        public System.Windows.Forms.TextBox txtEmpCode;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox txtEmployeeNameinTamil;
    }
}