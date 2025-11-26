namespace ROMS
{
    partial class CP_Customer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CP_Customer));
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.epCustomer = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtDMobilenumber = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.grbForm = new System.Windows.Forms.GroupBox();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.txtCreditLimit = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.txtGSTIN = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.cmbCustomerType = new System.Windows.Forms.ComboBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.txtPhoneNumber = new System.Windows.Forms.TextBox();
            this.txtMobileNumber = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.epCustomer)).BeginInit();
            this.grbForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtCustomerName.Location = new System.Drawing.Point(113, 23);
            this.txtCustomerName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCustomerName.MaxLength = 30;
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(210, 27);
            this.txtCustomerName.TabIndex = 0;
            this.txtCustomerName.Enter += new System.EventHandler(this.txtCustomerName_Enter);
            this.txtCustomerName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCustomerName_KeyDown);
            this.txtCustomerName.Leave += new System.EventHandler(this.txtCustomerName_Leave);
            // 
            // epCustomer
            // 
            this.epCustomer.ContainerControl = this;
            // 
            // txtDMobilenumber
            // 
            this.txtDMobilenumber.BackColor = System.Drawing.SystemColors.Control;
            this.txtDMobilenumber.Enabled = false;
            this.txtDMobilenumber.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDMobilenumber.Location = new System.Drawing.Point(6, 50);
            this.txtDMobilenumber.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.txtDMobilenumber.Name = "txtDMobilenumber";
            this.txtDMobilenumber.ReadOnly = true;
            this.txtDMobilenumber.Size = new System.Drawing.Size(107, 28);
            this.txtDMobilenumber.TabIndex = 11;
            this.txtDMobilenumber.Text = "Mobile Number";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(6, 22);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(107, 28);
            this.textBox1.TabIndex = 12;
            this.textBox1.Text = "Customer Name";
            // 
            // grbForm
            // 
            this.grbForm.Controls.Add(this.cmbStatus);
            this.grbForm.Controls.Add(this.textBox7);
            this.grbForm.Controls.Add(this.txtCreditLimit);
            this.grbForm.Controls.Add(this.textBox5);
            this.grbForm.Controls.Add(this.txtGSTIN);
            this.grbForm.Controls.Add(this.textBox4);
            this.grbForm.Controls.Add(this.cmbCustomerType);
            this.grbForm.Controls.Add(this.textBox3);
            this.grbForm.Controls.Add(this.textBox2);
            this.grbForm.Controls.Add(this.txtPhoneNumber);
            this.grbForm.Controls.Add(this.txtMobileNumber);
            this.grbForm.Controls.Add(this.textBox1);
            this.grbForm.Controls.Add(this.btnClose);
            this.grbForm.Controls.Add(this.txtCustomerName);
            this.grbForm.Controls.Add(this.btnSave);
            this.grbForm.Controls.Add(this.txtDMobilenumber);
            this.grbForm.Location = new System.Drawing.Point(12, 8);
            this.grbForm.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbForm.Name = "grbForm";
            this.grbForm.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbForm.Size = new System.Drawing.Size(337, 277);
            this.grbForm.TabIndex = 15;
            this.grbForm.TabStop = false;
            // 
            // cmbStatus
            // 
            this.cmbStatus.Font = new System.Drawing.Font("Oswald Regular", 11.25F);
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(113, 194);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(210, 28);
            this.cmbStatus.TabIndex = 25;
            this.cmbStatus.Enter += new System.EventHandler(this.cmbStatus_Enter);
            this.cmbStatus.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbStatus_KeyDown);
            this.cmbStatus.Leave += new System.EventHandler(this.cmbStatus_Leave);
            // 
            // textBox7
            // 
            this.textBox7.BackColor = System.Drawing.SystemColors.Control;
            this.textBox7.Enabled = false;
            this.textBox7.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox7.Location = new System.Drawing.Point(6, 194);
            this.textBox7.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.textBox7.Name = "textBox7";
            this.textBox7.ReadOnly = true;
            this.textBox7.Size = new System.Drawing.Size(107, 28);
            this.textBox7.TabIndex = 24;
            this.textBox7.Text = "Status";
            // 
            // txtCreditLimit
            // 
            this.txtCreditLimit.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtCreditLimit.Location = new System.Drawing.Point(113, 166);
            this.txtCreditLimit.MaxLength = 3;
            this.txtCreditLimit.Name = "txtCreditLimit";
            this.txtCreditLimit.Size = new System.Drawing.Size(210, 27);
            this.txtCreditLimit.TabIndex = 23;
            this.txtCreditLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCreditLimit.Enter += new System.EventHandler(this.txtCreditLimit_Enter);
            this.txtCreditLimit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCreditLimit_KeyDown);
            this.txtCreditLimit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCreditLimit_KeyPress);
            this.txtCreditLimit.Leave += new System.EventHandler(this.txtCreditLimit_Leave);
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.SystemColors.Control;
            this.textBox5.Enabled = false;
            this.textBox5.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox5.Location = new System.Drawing.Point(6, 165);
            this.textBox5.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(107, 28);
            this.textBox5.TabIndex = 22;
            this.textBox5.Text = "Credit Limit";
            // 
            // txtGSTIN
            // 
            this.txtGSTIN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtGSTIN.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtGSTIN.Location = new System.Drawing.Point(113, 137);
            this.txtGSTIN.MaxLength = 15;
            this.txtGSTIN.Name = "txtGSTIN";
            this.txtGSTIN.Size = new System.Drawing.Size(210, 27);
            this.txtGSTIN.TabIndex = 21;
            this.txtGSTIN.Enter += new System.EventHandler(this.txtGSTIN_Enter);
            this.txtGSTIN.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtGSTIN_KeyDown);
            this.txtGSTIN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGSTIN_KeyPress);
            this.txtGSTIN.Leave += new System.EventHandler(this.txtGSTIN_Leave);
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.SystemColors.Control;
            this.textBox4.Enabled = false;
            this.textBox4.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.Location = new System.Drawing.Point(6, 136);
            this.textBox4.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(107, 28);
            this.textBox4.TabIndex = 19;
            this.textBox4.Text = "GSTIN";
            // 
            // cmbCustomerType
            // 
            this.cmbCustomerType.Font = new System.Drawing.Font("Oswald Regular", 11.25F);
            this.cmbCustomerType.FormattingEnabled = true;
            this.cmbCustomerType.Location = new System.Drawing.Point(113, 107);
            this.cmbCustomerType.Name = "cmbCustomerType";
            this.cmbCustomerType.Size = new System.Drawing.Size(210, 28);
            this.cmbCustomerType.TabIndex = 18;
            this.cmbCustomerType.SelectedIndexChanged += new System.EventHandler(this.cmbCustomerType_SelectedIndexChanged);
            this.cmbCustomerType.Enter += new System.EventHandler(this.cmbCustomerType_Enter);
            this.cmbCustomerType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbCustomerType_KeyDown);
            this.cmbCustomerType.Leave += new System.EventHandler(this.cmbCustomerType_Leave);
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.SystemColors.Control;
            this.textBox3.Enabled = false;
            this.textBox3.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(6, 107);
            this.textBox3.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(107, 28);
            this.textBox3.TabIndex = 17;
            this.textBox3.Text = "Customer Type";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.Control;
            this.textBox2.Enabled = false;
            this.textBox2.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(6, 78);
            this.textBox2.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(107, 28);
            this.textBox2.TabIndex = 16;
            this.textBox2.Text = "Phone Number";
            // 
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtPhoneNumber.Location = new System.Drawing.Point(113, 79);
            this.txtPhoneNumber.MaxLength = 15;
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.Size = new System.Drawing.Size(210, 27);
            this.txtPhoneNumber.TabIndex = 15;
            this.txtPhoneNumber.Enter += new System.EventHandler(this.txtPhoneNumber_Enter);
            this.txtPhoneNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPhoneNumber_KeyDown);
            this.txtPhoneNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPhoneNumber_KeyPress);
            this.txtPhoneNumber.Leave += new System.EventHandler(this.txtPhoneNumber_Leave);
            // 
            // txtMobileNumber
            // 
            this.txtMobileNumber.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtMobileNumber.Location = new System.Drawing.Point(113, 51);
            this.txtMobileNumber.MaxLength = 10;
            this.txtMobileNumber.Name = "txtMobileNumber";
            this.txtMobileNumber.Size = new System.Drawing.Size(210, 27);
            this.txtMobileNumber.TabIndex = 14;
            this.txtMobileNumber.Enter += new System.EventHandler(this.txtMobileNumber_Enter);
            this.txtMobileNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMobileNumber_KeyDown);
            this.txtMobileNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMobileNumber_KeyPress);
            this.txtMobileNumber.Leave += new System.EventHandler(this.txtMobileNumber_Leave);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::ROMS.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(249, 229);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(74, 34);
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnSave.Image = global::ROMS.Properties.Resources.save;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(161, 229);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(82, 34);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.Enter += new System.EventHandler(this.btnSave_Enter);
            this.btnSave.Leave += new System.EventHandler(this.btnSave_Leave);
            // 
            // CP_Customer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(363, 300);
            this.Controls.Add(this.grbForm);
            this.Font = new System.Drawing.Font("Oswald Regular", 11.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CP_Customer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customer Details";
            this.Load += new System.EventHandler(this.CP_Customer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.epCustomer)).EndInit();
            this.grbForm.ResumeLayout(false);
            this.grbForm.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ErrorProvider epCustomer;
        public System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox txtDMobilenumber;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox grbForm;
        public System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtMobileNumber;
        private System.Windows.Forms.TextBox txtPhoneNumber;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.ComboBox cmbCustomerType;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox txtGSTIN;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox txtCreditLimit;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.ComboBox cmbStatus;
    }
}