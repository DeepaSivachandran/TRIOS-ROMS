namespace ROMS
{
    partial class CP_DeliveryPerson
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CP_DeliveryPerson));
            this.txtDeliveryPersonCode = new System.Windows.Forms.TextBox();
            this.epDeliveryPerson = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.pnlStatus = new System.Windows.Forms.Panel();
            this.rbActive = new System.Windows.Forms.RadioButton();
            this.rbInActive = new System.Windows.Forms.RadioButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.grbForm = new System.Windows.Forms.GroupBox();
            this.txtMobileNo = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.txtDeliveryPersonName = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.epDeliveryPerson)).BeginInit();
            this.pnlStatus.SuspendLayout();
            this.grbForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtDeliveryPersonCode
            // 
            this.txtDeliveryPersonCode.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtDeliveryPersonCode.Location = new System.Drawing.Point(189, 22);
            this.txtDeliveryPersonCode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDeliveryPersonCode.MaxLength = 10;
            this.txtDeliveryPersonCode.Name = "txtDeliveryPersonCode";
            this.txtDeliveryPersonCode.Size = new System.Drawing.Size(255, 27);
            this.txtDeliveryPersonCode.TabIndex = 0;
            this.txtDeliveryPersonCode.Enter += new System.EventHandler(this.txtDeliveryPersonCode_Enter);
            this.txtDeliveryPersonCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDeliveryPersonCode_KeyDown);
            this.txtDeliveryPersonCode.Leave += new System.EventHandler(this.txtDeliveryPersonCode_Leave);
            // 
            // epDeliveryPerson
            // 
            this.epDeliveryPerson.ContainerControl = this;
            // 
            // txtStatus
            // 
            this.txtStatus.BackColor = System.Drawing.SystemColors.Control;
            this.txtStatus.Enabled = false;
            this.txtStatus.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtStatus.Location = new System.Drawing.Point(6, 103);
            this.txtStatus.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(183, 27);
            this.txtStatus.TabIndex = 11;
            this.txtStatus.Text = "Status";
            // 
            // pnlStatus
            // 
            this.pnlStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlStatus.Controls.Add(this.rbActive);
            this.pnlStatus.Controls.Add(this.rbInActive);
            this.pnlStatus.Location = new System.Drawing.Point(189, 103);
            this.pnlStatus.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlStatus.Name = "pnlStatus";
            this.pnlStatus.Size = new System.Drawing.Size(255, 27);
            this.pnlStatus.TabIndex = 3;
            // 
            // rbActive
            // 
            this.rbActive.AutoSize = true;
            this.rbActive.Checked = true;
            this.rbActive.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbActive.Location = new System.Drawing.Point(57, 1);
            this.rbActive.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rbActive.Name = "rbActive";
            this.rbActive.Size = new System.Drawing.Size(60, 24);
            this.rbActive.TabIndex = 3;
            this.rbActive.TabStop = true;
            this.rbActive.Text = "Active";
            this.rbActive.UseVisualStyleBackColor = true;
            this.rbActive.Enter += new System.EventHandler(this.rbActive_Enter);
            this.rbActive.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rbActive_KeyDown);
            this.rbActive.Leave += new System.EventHandler(this.rbActive_Leave);
            // 
            // rbInActive
            // 
            this.rbInActive.AutoSize = true;
            this.rbInActive.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbInActive.Location = new System.Drawing.Point(125, 1);
            this.rbInActive.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rbInActive.Name = "rbInActive";
            this.rbInActive.Size = new System.Drawing.Size(70, 24);
            this.rbInActive.TabIndex = 4;
            this.rbInActive.Text = "Inactive";
            this.rbInActive.UseVisualStyleBackColor = true;
            this.rbInActive.Enter += new System.EventHandler(this.rbInActive_Enter);
            this.rbInActive.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rbInActive_KeyDown);
            this.rbInActive.Leave += new System.EventHandler(this.rbInActive_Leave);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.textBox1.Location = new System.Drawing.Point(6, 22);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(183, 27);
            this.textBox1.TabIndex = 12;
            this.textBox1.Text = "Delivery Person Code";
            // 
            // grbForm
            // 
            this.grbForm.Controls.Add(this.txtMobileNo);
            this.grbForm.Controls.Add(this.textBox4);
            this.grbForm.Controls.Add(this.txtDeliveryPersonName);
            this.grbForm.Controls.Add(this.textBox2);
            this.grbForm.Controls.Add(this.textBox1);
            this.grbForm.Controls.Add(this.btnClose);
            this.grbForm.Controls.Add(this.txtDeliveryPersonCode);
            this.grbForm.Controls.Add(this.btnSave);
            this.grbForm.Controls.Add(this.txtStatus);
            this.grbForm.Controls.Add(this.pnlStatus);
            this.grbForm.Location = new System.Drawing.Point(12, 13);
            this.grbForm.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbForm.Name = "grbForm";
            this.grbForm.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbForm.Size = new System.Drawing.Size(460, 182);
            this.grbForm.TabIndex = 0;
            this.grbForm.TabStop = false;
            // 
            // txtMobileNo
            // 
            this.txtMobileNo.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtMobileNo.Location = new System.Drawing.Point(189, 76);
            this.txtMobileNo.MaxLength = 15;
            this.txtMobileNo.Name = "txtMobileNo";
            this.txtMobileNo.Size = new System.Drawing.Size(255, 27);
            this.txtMobileNo.TabIndex = 2;
            this.txtMobileNo.Enter += new System.EventHandler(this.txtMobileNo_Enter);
            this.txtMobileNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMobileNo_KeyDown);
            this.txtMobileNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMobileNo_KeyPress);
            this.txtMobileNo.Leave += new System.EventHandler(this.txtMobileNo_Leave);
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.SystemColors.Control;
            this.textBox4.Enabled = false;
            this.textBox4.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.textBox4.Location = new System.Drawing.Point(6, 76);
            this.textBox4.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(183, 27);
            this.textBox4.TabIndex = 15;
            this.textBox4.Text = "Mobile Number";
            // 
            // txtDeliveryPersonName
            // 
            this.txtDeliveryPersonName.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtDeliveryPersonName.Location = new System.Drawing.Point(189, 49);
            this.txtDeliveryPersonName.MaxLength = 50;
            this.txtDeliveryPersonName.Name = "txtDeliveryPersonName";
            this.txtDeliveryPersonName.Size = new System.Drawing.Size(255, 27);
            this.txtDeliveryPersonName.TabIndex = 1;
            this.txtDeliveryPersonName.Enter += new System.EventHandler(this.txtDeliveryPersonName_Enter);
            this.txtDeliveryPersonName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDeliveryPersonName_KeyDown);
            this.txtDeliveryPersonName.Leave += new System.EventHandler(this.txtDeliveryPersonName_Leave);
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.Control;
            this.textBox2.Enabled = false;
            this.textBox2.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.textBox2.Location = new System.Drawing.Point(6, 49);
            this.textBox2.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(183, 27);
            this.textBox2.TabIndex = 13;
            this.textBox2.Text = "Delivery Person Name";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::ROMS.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(370, 138);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(74, 34);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnSave.Image = global::ROMS.Properties.Resources.save;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(282, 138);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(82, 34);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.Enter += new System.EventHandler(this.btnSave_Enter);
            this.btnSave.Leave += new System.EventHandler(this.btnSave_Leave);
            // 
            // CP_DeliveryPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(484, 211);
            this.Controls.Add(this.grbForm);
            this.Font = new System.Drawing.Font("Oswald Regular", 11.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CP_DeliveryPerson";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Delivery Person Details";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CP_DeliveryPerson_FormClosing);
            this.Load += new System.EventHandler(this.CP_DeliveryPerson_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CP_DeliveryPerson_KeyDown);
            this.Leave += new System.EventHandler(this.CP_DeliveryPerson_Leave);
            ((System.ComponentModel.ISupportInitialize)(this.epDeliveryPerson)).EndInit();
            this.pnlStatus.ResumeLayout(false);
            this.pnlStatus.PerformLayout();
            this.grbForm.ResumeLayout(false);
            this.grbForm.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ErrorProvider epDeliveryPerson;
        public System.Windows.Forms.TextBox txtDeliveryPersonCode;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Panel pnlStatus;
        private System.Windows.Forms.RadioButton rbActive;
        private System.Windows.Forms.RadioButton rbInActive;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox grbForm;
        public System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox txtDeliveryPersonName;
        private System.Windows.Forms.TextBox txtMobileNo;
        private System.Windows.Forms.TextBox textBox4;
    }
}