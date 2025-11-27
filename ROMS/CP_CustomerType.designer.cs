namespace ROMS
{
    partial class CP_CustomerType
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CP_CustomerType));
            this.txtCustomerType = new System.Windows.Forms.TextBox();
            this.epCustomerType = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.pnlStatus = new System.Windows.Forms.Panel();
            this.rbActive = new System.Windows.Forms.RadioButton();
            this.rbInActive = new System.Windows.Forms.RadioButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.grbForm = new System.Windows.Forms.GroupBox();
            this.txtCustomerTypeTName = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.epCustomerType)).BeginInit();
            this.pnlStatus.SuspendLayout();
            this.grbForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtCustomerType
            // 
            this.txtCustomerType.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtCustomerType.Location = new System.Drawing.Point(189, 23);
            this.txtCustomerType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCustomerType.MaxLength = 30;
            this.txtCustomerType.Name = "txtCustomerType";
            this.txtCustomerType.Size = new System.Drawing.Size(255, 27);
            this.txtCustomerType.TabIndex = 0;
            this.txtCustomerType.Enter += new System.EventHandler(this.txtCustomerType_Enter);
            this.txtCustomerType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCustomerType_KeyDown);
            this.txtCustomerType.Leave += new System.EventHandler(this.txtCustomerType_Leave);
            // 
            // epCustomerType
            // 
            this.epCustomerType.ContainerControl = this;
            // 
            // txtStatus
            // 
            this.txtStatus.BackColor = System.Drawing.SystemColors.Control;
            this.txtStatus.Enabled = false;
            this.txtStatus.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStatus.Location = new System.Drawing.Point(6, 77);
            this.txtStatus.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(183, 28);
            this.txtStatus.TabIndex = 11;
            this.txtStatus.Text = "Status";
            // 
            // pnlStatus
            // 
            this.pnlStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlStatus.Controls.Add(this.rbActive);
            this.pnlStatus.Controls.Add(this.rbInActive);
            this.pnlStatus.Location = new System.Drawing.Point(189, 77);
            this.pnlStatus.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlStatus.Name = "pnlStatus";
            this.pnlStatus.Size = new System.Drawing.Size(255, 27);
            this.pnlStatus.TabIndex = 2;
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
            this.rbActive.TabIndex = 2;
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
            this.rbInActive.TabIndex = 3;
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
            this.textBox1.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(6, 22);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(183, 28);
            this.textBox1.TabIndex = 12;
            this.textBox1.Text = "Customer Type Name in English";
            // 
            // grbForm
            // 
            this.grbForm.Controls.Add(this.txtCustomerTypeTName);
            this.grbForm.Controls.Add(this.textBox2);
            this.grbForm.Controls.Add(this.textBox1);
            this.grbForm.Controls.Add(this.btnClose);
            this.grbForm.Controls.Add(this.txtCustomerType);
            this.grbForm.Controls.Add(this.btnSave);
            this.grbForm.Controls.Add(this.txtStatus);
            this.grbForm.Controls.Add(this.pnlStatus);
            this.grbForm.Location = new System.Drawing.Point(12, 13);
            this.grbForm.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbForm.Name = "grbForm";
            this.grbForm.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbForm.Size = new System.Drawing.Size(460, 162);
            this.grbForm.TabIndex = 0;
            this.grbForm.TabStop = false;
            // 
            // txtCustomerTypeTName
            // 
            this.txtCustomerTypeTName.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerTypeTName.Location = new System.Drawing.Point(189, 50);
            this.txtCustomerTypeTName.MaxLength = 100;
            this.txtCustomerTypeTName.Name = "txtCustomerTypeTName";
            this.txtCustomerTypeTName.Size = new System.Drawing.Size(255, 27);
            this.txtCustomerTypeTName.TabIndex = 1;
            this.txtCustomerTypeTName.Enter += new System.EventHandler(this.txtCustomerTypeTName_Enter);
            this.txtCustomerTypeTName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCustomerTypeTName_KeyDown);
            this.txtCustomerTypeTName.Leave += new System.EventHandler(this.txtCustomerTypeTName_Leave);
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.Control;
            this.textBox2.Enabled = false;
            this.textBox2.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(6, 49);
            this.textBox2.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(183, 28);
            this.textBox2.TabIndex = 13;
            this.textBox2.Text = "Customer Type Name in Tamil";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::ROMS.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(370, 112);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(74, 34);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnSave.Image = global::ROMS.Properties.Resources.save;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(282, 112);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(82, 34);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.Enter += new System.EventHandler(this.btnSave_Enter);
            this.btnSave.Leave += new System.EventHandler(this.btnSave_Leave);
            // 
            // CP_CustomerType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(484, 192);
            this.Controls.Add(this.grbForm);
            this.Font = new System.Drawing.Font("Oswald Regular", 11.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CP_CustomerType";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customer Type";
            this.Load += new System.EventHandler(this.CP_CustomerType_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CP_CustomerType_KeyDown);
            this.Leave += new System.EventHandler(this.CP_CustomerType_Leave);
            ((System.ComponentModel.ISupportInitialize)(this.epCustomerType)).EndInit();
            this.pnlStatus.ResumeLayout(false);
            this.pnlStatus.PerformLayout();
            this.grbForm.ResumeLayout(false);
            this.grbForm.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ErrorProvider epCustomerType;
        public System.Windows.Forms.TextBox txtCustomerType;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Panel pnlStatus;
        private System.Windows.Forms.RadioButton rbActive;
        private System.Windows.Forms.RadioButton rbInActive;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox grbForm;
        public System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox txtCustomerTypeTName;
    }
}