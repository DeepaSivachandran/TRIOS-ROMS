namespace ROMS
{
    partial class PUR_POIssuedDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PUR_POIssuedDetails));
            this.errIssued = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.gpissued = new System.Windows.Forms.GroupBox();
            this.txtSupplier = new System.Windows.Forms.TextBox();
            this.txtPONo = new System.Windows.Forms.TextBox();
            this.txtPODate = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.txtDmode = new System.Windows.Forms.TextBox();
            this.txtTAT = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.txtIssuemodeValues = new System.Windows.Forms.TextBox();
            this.cmbIssueMode = new System.Windows.Forms.ComboBox();
            this.txtIssuedBY = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtDTamilName = new System.Windows.Forms.TextBox();
            this.dpissuedateandtime = new System.Windows.Forms.DateTimePicker();
            this.lblschedule = new System.Windows.Forms.Label();
            this.lblSupplierCode = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errIssued)).BeginInit();
            this.gpissued.SuspendLayout();
            this.SuspendLayout();
            // 
            // errIssued
            // 
            this.errIssued.ContainerControl = this;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::ROMS.Properties.Resources.submit;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(433, 164);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(81, 33);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Submit";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::ROMS.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(520, 164);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(72, 33);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // gpissued
            // 
            this.gpissued.BackColor = System.Drawing.Color.White;
            this.gpissued.Controls.Add(this.txtSupplier);
            this.gpissued.Controls.Add(this.txtPONo);
            this.gpissued.Controls.Add(this.txtPODate);
            this.gpissued.Controls.Add(this.textBox9);
            this.gpissued.Controls.Add(this.textBox8);
            this.gpissued.Controls.Add(this.textBox7);
            this.gpissued.Controls.Add(this.textBox6);
            this.gpissued.Controls.Add(this.txtDmode);
            this.gpissued.Controls.Add(this.txtTAT);
            this.gpissued.Controls.Add(this.textBox4);
            this.gpissued.Controls.Add(this.txtIssuemodeValues);
            this.gpissued.Controls.Add(this.cmbIssueMode);
            this.gpissued.Controls.Add(this.txtIssuedBY);
            this.gpissued.Controls.Add(this.textBox2);
            this.gpissued.Controls.Add(this.textBox1);
            this.gpissued.Controls.Add(this.txtDTamilName);
            this.gpissued.Controls.Add(this.dpissuedateandtime);
            this.gpissued.Font = new System.Drawing.Font("Oswald Regular", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpissued.Location = new System.Drawing.Point(9, 0);
            this.gpissued.Name = "gpissued";
            this.gpissued.Size = new System.Drawing.Size(583, 160);
            this.gpissued.TabIndex = 1111176;
            this.gpissued.TabStop = false;
            // 
            // txtSupplier
            // 
            this.txtSupplier.BackColor = System.Drawing.SystemColors.Control;
            this.txtSupplier.Enabled = false;
            this.txtSupplier.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtSupplier.Location = new System.Drawing.Point(129, 40);
            this.txtSupplier.Name = "txtSupplier";
            this.txtSupplier.ReadOnly = true;
            this.txtSupplier.Size = new System.Drawing.Size(434, 27);
            this.txtSupplier.TabIndex = 1111195;
            this.txtSupplier.TabStop = false;
            // 
            // txtPONo
            // 
            this.txtPONo.BackColor = System.Drawing.SystemColors.Control;
            this.txtPONo.Enabled = false;
            this.txtPONo.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtPONo.Location = new System.Drawing.Point(403, 12);
            this.txtPONo.Name = "txtPONo";
            this.txtPONo.ReadOnly = true;
            this.txtPONo.Size = new System.Drawing.Size(160, 27);
            this.txtPONo.TabIndex = 1111194;
            this.txtPONo.TabStop = false;
            // 
            // txtPODate
            // 
            this.txtPODate.BackColor = System.Drawing.SystemColors.Control;
            this.txtPODate.Enabled = false;
            this.txtPODate.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtPODate.Location = new System.Drawing.Point(129, 12);
            this.txtPODate.Name = "txtPODate";
            this.txtPODate.ReadOnly = true;
            this.txtPODate.Size = new System.Drawing.Size(160, 27);
            this.txtPODate.TabIndex = 1111193;
            this.txtPODate.TabStop = false;
            // 
            // textBox9
            // 
            this.textBox9.BackColor = System.Drawing.SystemColors.Control;
            this.textBox9.Enabled = false;
            this.textBox9.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.textBox9.Location = new System.Drawing.Point(17, 40);
            this.textBox9.Name = "textBox9";
            this.textBox9.ReadOnly = true;
            this.textBox9.Size = new System.Drawing.Size(112, 27);
            this.textBox9.TabIndex = 1111192;
            this.textBox9.TabStop = false;
            this.textBox9.Text = "Supplier";
            // 
            // textBox8
            // 
            this.textBox8.BackColor = System.Drawing.SystemColors.Control;
            this.textBox8.Enabled = false;
            this.textBox8.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.textBox8.Location = new System.Drawing.Point(291, 12);
            this.textBox8.Name = "textBox8";
            this.textBox8.ReadOnly = true;
            this.textBox8.Size = new System.Drawing.Size(112, 27);
            this.textBox8.TabIndex = 1111191;
            this.textBox8.TabStop = false;
            this.textBox8.Text = "PO No.";
            // 
            // textBox7
            // 
            this.textBox7.BackColor = System.Drawing.SystemColors.Control;
            this.textBox7.Enabled = false;
            this.textBox7.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.textBox7.Location = new System.Drawing.Point(17, 12);
            this.textBox7.Name = "textBox7";
            this.textBox7.ReadOnly = true;
            this.textBox7.Size = new System.Drawing.Size(112, 27);
            this.textBox7.TabIndex = 1111190;
            this.textBox7.TabStop = false;
            this.textBox7.Text = "PO Date";
            // 
            // textBox6
            // 
            this.textBox6.BackColor = System.Drawing.SystemColors.Control;
            this.textBox6.Enabled = false;
            this.textBox6.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.textBox6.Location = new System.Drawing.Point(246, 124);
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(43, 27);
            this.textBox6.TabIndex = 1111189;
            this.textBox6.Text = "DAY(S)";
            // 
            // txtDmode
            // 
            this.txtDmode.BackColor = System.Drawing.SystemColors.Control;
            this.txtDmode.Enabled = false;
            this.txtDmode.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtDmode.Location = new System.Drawing.Point(291, 96);
            this.txtDmode.Name = "txtDmode";
            this.txtDmode.ReadOnly = true;
            this.txtDmode.Size = new System.Drawing.Size(112, 27);
            this.txtDmode.TabIndex = 1111181;
            this.txtDmode.TabStop = false;
            // 
            // txtTAT
            // 
            this.txtTAT.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtTAT.Location = new System.Drawing.Point(129, 124);
            this.txtTAT.MaxLength = 3;
            this.txtTAT.Name = "txtTAT";
            this.txtTAT.Size = new System.Drawing.Size(115, 27);
            this.txtTAT.TabIndex = 4;
            this.txtTAT.Text = " ";
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.SystemColors.Control;
            this.textBox4.Enabled = false;
            this.textBox4.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.textBox4.Location = new System.Drawing.Point(17, 124);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(112, 27);
            this.textBox4.TabIndex = 1111179;
            this.textBox4.TabStop = false;
            this.textBox4.Text = "Turn Around Time";
            // 
            // txtIssuemodeValues
            // 
            this.txtIssuemodeValues.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtIssuemodeValues.Location = new System.Drawing.Point(403, 96);
            this.txtIssuemodeValues.MaxLength = 50;
            this.txtIssuemodeValues.Name = "txtIssuemodeValues";
            this.txtIssuemodeValues.Size = new System.Drawing.Size(160, 27);
            this.txtIssuemodeValues.TabIndex = 3;
            this.txtIssuemodeValues.Enter += new System.EventHandler(this.TxtIssuemodeValues_Enter);
            this.txtIssuemodeValues.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtIssuemodeValues_KeyDown);
            this.txtIssuemodeValues.Leave += new System.EventHandler(this.TxtIssuemodeValues_Leave);
            // 
            // cmbIssueMode
            // 
            this.cmbIssueMode.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbIssueMode.FormattingEnabled = true;
            this.cmbIssueMode.Items.AddRange(new object[] {
            "Inperson",
            "Mail",
            "WhatsApp",
            "Phone",
            "Mobile App"});
            this.cmbIssueMode.Location = new System.Drawing.Point(129, 96);
            this.cmbIssueMode.Name = "cmbIssueMode";
            this.cmbIssueMode.Size = new System.Drawing.Size(160, 27);
            this.cmbIssueMode.TabIndex = 2;
            this.cmbIssueMode.SelectedIndexChanged += new System.EventHandler(this.CmbIssueMode_SelectedIndexChanged);
            this.cmbIssueMode.Enter += new System.EventHandler(this.CmbIssueMode_Enter);
            this.cmbIssueMode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbIssueMode_KeyDown);
            this.cmbIssueMode.Leave += new System.EventHandler(this.CmbIssueMode_Leave);
            // 
            // txtIssuedBY
            // 
            this.txtIssuedBY.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtIssuedBY.Location = new System.Drawing.Point(403, 68);
            this.txtIssuedBY.MaxLength = 50;
            this.txtIssuedBY.Name = "txtIssuedBY";
            this.txtIssuedBY.Size = new System.Drawing.Size(160, 27);
            this.txtIssuedBY.TabIndex = 1;
            this.txtIssuedBY.Enter += new System.EventHandler(this.TxtIssuedBY_Enter);
            this.txtIssuedBY.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtIssuedBY_KeyDown);
            this.txtIssuedBY.Leave += new System.EventHandler(this.TxtIssuedBY_Leave);
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.Control;
            this.textBox2.Enabled = false;
            this.textBox2.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.textBox2.Location = new System.Drawing.Point(17, 96);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(112, 27);
            this.textBox2.TabIndex = 5;
            this.textBox2.TabStop = false;
            this.textBox2.Text = "Mode of Issue";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.textBox1.Location = new System.Drawing.Point(291, 68);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(112, 27);
            this.textBox1.TabIndex = 4;
            this.textBox1.TabStop = false;
            this.textBox1.Text = "Issued By";
            // 
            // txtDTamilName
            // 
            this.txtDTamilName.BackColor = System.Drawing.SystemColors.Control;
            this.txtDTamilName.Enabled = false;
            this.txtDTamilName.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtDTamilName.Location = new System.Drawing.Point(17, 68);
            this.txtDTamilName.Name = "txtDTamilName";
            this.txtDTamilName.ReadOnly = true;
            this.txtDTamilName.Size = new System.Drawing.Size(112, 27);
            this.txtDTamilName.TabIndex = 3;
            this.txtDTamilName.TabStop = false;
            this.txtDTamilName.Text = "Issue Date And Time";
            // 
            // dpissuedateandtime
            // 
            this.dpissuedateandtime.CustomFormat = "dd/MM/yyyy hh:mm tt";
            this.dpissuedateandtime.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.dpissuedateandtime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpissuedateandtime.Location = new System.Drawing.Point(129, 68);
            this.dpissuedateandtime.Name = "dpissuedateandtime";
            this.dpissuedateandtime.Size = new System.Drawing.Size(160, 27);
            this.dpissuedateandtime.TabIndex = 0;
            this.dpissuedateandtime.Enter += new System.EventHandler(this.Dpissuedateandtime_Enter);
            this.dpissuedateandtime.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Dpissuedateandtime_KeyDown);
            this.dpissuedateandtime.Leave += new System.EventHandler(this.Dpissuedateandtime_Leave);
            // 
            // lblschedule
            // 
            this.lblschedule.AutoSize = true;
            this.lblschedule.Location = new System.Drawing.Point(205, 170);
            this.lblschedule.Name = "lblschedule";
            this.lblschedule.Size = new System.Drawing.Size(16, 20);
            this.lblschedule.TabIndex = 1111212;
            this.lblschedule.Text = "0";
            this.lblschedule.Visible = false;
            // 
            // lblSupplierCode
            // 
            this.lblSupplierCode.AutoSize = true;
            this.lblSupplierCode.Location = new System.Drawing.Point(130, 170);
            this.lblSupplierCode.Name = "lblSupplierCode";
            this.lblSupplierCode.Size = new System.Drawing.Size(16, 20);
            this.lblSupplierCode.TabIndex = 1111211;
            this.lblSupplierCode.Text = "0";
            this.lblSupplierCode.Visible = false;
            // 
            // PUR_POIssuedDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(602, 204);
            this.Controls.Add(this.lblschedule);
            this.Controls.Add(this.lblSupplierCode);
            this.Controls.Add(this.gpissued);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PUR_POIssuedDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Issued Details";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PUR_POIssuedDetails_FormClosing);
            this.Load += new System.EventHandler(this.PUR_POIssuedDetails_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PUR_POIssuedDetails_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.errIssued)).EndInit();
            this.gpissued.ResumeLayout(false);
            this.gpissued.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ErrorProvider errIssued;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        public System.Windows.Forms.GroupBox gpissued;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox txtDmode;
        private System.Windows.Forms.TextBox txtTAT;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox txtIssuemodeValues;
        private System.Windows.Forms.ComboBox cmbIssueMode;
        private System.Windows.Forms.TextBox txtIssuedBY;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox txtDTamilName;
        private System.Windows.Forms.DateTimePicker dpissuedateandtime;
        private System.Windows.Forms.TextBox txtSupplier;
        private System.Windows.Forms.TextBox txtPONo;
        private System.Windows.Forms.TextBox txtPODate;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox textBox7;
        public System.Windows.Forms.Label lblschedule;
        public System.Windows.Forms.Label lblSupplierCode;
    }
}