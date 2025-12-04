namespace ROMS
{
    partial class CP_Transport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CP_Transport));
            this.txtTransportEName = new System.Windows.Forms.TextBox();
            this.epTransport = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.pnlStatus = new System.Windows.Forms.Panel();
            this.rbActive = new System.Windows.Forms.RadioButton();
            this.rbInActive = new System.Windows.Forms.RadioButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.grbForm = new System.Windows.Forms.GroupBox();
            this.txtMobileNo = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.txtContactPersonName = new System.Windows.Forms.TextBox();
            this.txtShortName = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.txtTransportTName = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.epTransport)).BeginInit();
            this.pnlStatus.SuspendLayout();
            this.grbForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtTransportEName
            // 
            this.txtTransportEName.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtTransportEName.Location = new System.Drawing.Point(189, 22);
            this.txtTransportEName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTransportEName.MaxLength = 30;
            this.txtTransportEName.Name = "txtTransportEName";
            this.txtTransportEName.Size = new System.Drawing.Size(255, 27);
            this.txtTransportEName.TabIndex = 0;
            this.txtTransportEName.Enter += new System.EventHandler(this.txtTransportEName_Enter);
            this.txtTransportEName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTransportEName_KeyDown);
            this.txtTransportEName.Leave += new System.EventHandler(this.txtTransportEName_Leave);
            // 
            // epTransport
            // 
            this.epTransport.ContainerControl = this;
            // 
            // txtStatus
            // 
            this.txtStatus.BackColor = System.Drawing.SystemColors.Control;
            this.txtStatus.Enabled = false;
            this.txtStatus.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtStatus.Location = new System.Drawing.Point(6, 160);
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
            this.pnlStatus.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.pnlStatus.Location = new System.Drawing.Point(189, 160);
            this.pnlStatus.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlStatus.Name = "pnlStatus";
            this.pnlStatus.Size = new System.Drawing.Size(255, 27);
            this.pnlStatus.TabIndex = 5;
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
            this.rbActive.TabIndex = 5;
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
            this.rbInActive.TabIndex = 6;
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
            this.textBox1.Text = "Transport Name in English";
            // 
            // grbForm
            // 
            this.grbForm.Controls.Add(this.txtMobileNo);
            this.grbForm.Controls.Add(this.textBox5);
            this.grbForm.Controls.Add(this.textBox4);
            this.grbForm.Controls.Add(this.txtContactPersonName);
            this.grbForm.Controls.Add(this.txtShortName);
            this.grbForm.Controls.Add(this.textBox3);
            this.grbForm.Controls.Add(this.txtTransportTName);
            this.grbForm.Controls.Add(this.textBox2);
            this.grbForm.Controls.Add(this.textBox1);
            this.grbForm.Controls.Add(this.btnClose);
            this.grbForm.Controls.Add(this.txtTransportEName);
            this.grbForm.Controls.Add(this.btnSave);
            this.grbForm.Controls.Add(this.txtStatus);
            this.grbForm.Controls.Add(this.pnlStatus);
            this.grbForm.Location = new System.Drawing.Point(12, 13);
            this.grbForm.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbForm.Name = "grbForm";
            this.grbForm.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbForm.Size = new System.Drawing.Size(460, 245);
            this.grbForm.TabIndex = 0;
            this.grbForm.TabStop = false;
            // 
            // txtMobileNo
            // 
            this.txtMobileNo.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtMobileNo.Location = new System.Drawing.Point(189, 133);
            this.txtMobileNo.MaxLength = 15;
            this.txtMobileNo.Name = "txtMobileNo";
            this.txtMobileNo.Size = new System.Drawing.Size(255, 27);
            this.txtMobileNo.TabIndex = 4;
            this.txtMobileNo.Enter += new System.EventHandler(this.txtMobileNo_Enter);
            this.txtMobileNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMobileNo_KeyDown);
            this.txtMobileNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMobileNo_KeyPress);
            this.txtMobileNo.Leave += new System.EventHandler(this.txtMobileNo_Leave);
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.SystemColors.Control;
            this.textBox5.Enabled = false;
            this.textBox5.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.textBox5.Location = new System.Drawing.Point(6, 133);
            this.textBox5.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(183, 27);
            this.textBox5.TabIndex = 19;
            this.textBox5.Text = "Mobile Number";
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.SystemColors.Control;
            this.textBox4.Enabled = false;
            this.textBox4.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.textBox4.Location = new System.Drawing.Point(6, 105);
            this.textBox4.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(183, 27);
            this.textBox4.TabIndex = 17;
            this.textBox4.Text = "Contact Person Name";
            // 
            // txtContactPersonName
            // 
            this.txtContactPersonName.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtContactPersonName.Location = new System.Drawing.Point(189, 105);
            this.txtContactPersonName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtContactPersonName.MaxLength = 50;
            this.txtContactPersonName.Name = "txtContactPersonName";
            this.txtContactPersonName.Size = new System.Drawing.Size(255, 27);
            this.txtContactPersonName.TabIndex = 3;
            this.txtContactPersonName.Enter += new System.EventHandler(this.txtContactPersonName_Enter);
            this.txtContactPersonName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtContactPersonName_KeyDown);
            this.txtContactPersonName.Leave += new System.EventHandler(this.txtContactPersonName_Leave);
            // 
            // txtShortName
            // 
            this.txtShortName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtShortName.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtShortName.Location = new System.Drawing.Point(189, 77);
            this.txtShortName.MaxLength = 10;
            this.txtShortName.Name = "txtShortName";
            this.txtShortName.Size = new System.Drawing.Size(255, 27);
            this.txtShortName.TabIndex = 2;
            this.txtShortName.Enter += new System.EventHandler(this.txtShortName_Enter);
            this.txtShortName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtShortName_KeyDown);
            this.txtShortName.Leave += new System.EventHandler(this.txtShortName_Leave);
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.SystemColors.Control;
            this.textBox3.Enabled = false;
            this.textBox3.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.textBox3.Location = new System.Drawing.Point(6, 77);
            this.textBox3.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(183, 27);
            this.textBox3.TabIndex = 15;
            this.textBox3.Text = "Short Name";
            // 
            // txtTransportTName
            // 
            this.txtTransportTName.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTransportTName.Location = new System.Drawing.Point(189, 49);
            this.txtTransportTName.MaxLength = 100;
            this.txtTransportTName.Name = "txtTransportTName";
            this.txtTransportTName.Size = new System.Drawing.Size(255, 27);
            this.txtTransportTName.TabIndex = 1;
            this.txtTransportTName.Enter += new System.EventHandler(this.txtTransportTName_Enter);
            this.txtTransportTName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTransportTName_KeyDown);
            this.txtTransportTName.Leave += new System.EventHandler(this.txtTransportTName_Leave);
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
            this.textBox2.Text = "Transport Name in Tamil";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::ROMS.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(370, 195);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(74, 34);
            this.btnClose.TabIndex = 8;
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
            this.btnSave.Location = new System.Drawing.Point(282, 195);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(82, 34);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.Enter += new System.EventHandler(this.btnSave_Enter);
            this.btnSave.Leave += new System.EventHandler(this.btnSave_Leave);
            // 
            // CP_Transport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(484, 271);
            this.Controls.Add(this.grbForm);
            this.Font = new System.Drawing.Font("Oswald Regular", 11.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CP_Transport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transport Details";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CP_Transport_FormClosing);
            this.Load += new System.EventHandler(this.CP_Transport_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CP_Transport_KeyDown);
            this.Leave += new System.EventHandler(this.CP_Transport_Leave);
            ((System.ComponentModel.ISupportInitialize)(this.epTransport)).EndInit();
            this.pnlStatus.ResumeLayout(false);
            this.pnlStatus.PerformLayout();
            this.grbForm.ResumeLayout(false);
            this.grbForm.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ErrorProvider epTransport;
        public System.Windows.Forms.TextBox txtTransportEName;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Panel pnlStatus;
        private System.Windows.Forms.RadioButton rbActive;
        private System.Windows.Forms.RadioButton rbInActive;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox grbForm;
        public System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox txtTransportTName;
        private System.Windows.Forms.TextBox txtShortName;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        public System.Windows.Forms.TextBox txtContactPersonName;
        private System.Windows.Forms.TextBox txtMobileNo;
        private System.Windows.Forms.TextBox textBox5;
    }
}