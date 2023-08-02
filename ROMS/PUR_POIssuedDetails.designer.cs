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
            this.errUnit = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.gpissued = new System.Windows.Forms.GroupBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.txtDmode = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.cmbDPurchaseShop = new System.Windows.Forms.ComboBox();
            this.txtOpeningStock = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtDTamilName = new System.Windows.Forms.TextBox();
            this.dpissuedateandtime = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.errUnit)).BeginInit();
            this.gpissued.SuspendLayout();
            this.SuspendLayout();
            // 
            // errUnit
            // 
            this.errUnit.ContainerControl = this;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::ROMS.Properties.Resources.save;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(176, 169);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(81, 33);
            this.btnSave.TabIndex = 9;
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
            this.btnClose.Location = new System.Drawing.Point(260, 169);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(72, 33);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // gpissued
            // 
            this.gpissued.BackColor = System.Drawing.Color.White;
            this.gpissued.Controls.Add(this.textBox6);
            this.gpissued.Controls.Add(this.txtDmode);
            this.gpissued.Controls.Add(this.textBox5);
            this.gpissued.Controls.Add(this.textBox4);
            this.gpissued.Controls.Add(this.textBox3);
            this.gpissued.Controls.Add(this.cmbDPurchaseShop);
            this.gpissued.Controls.Add(this.txtOpeningStock);
            this.gpissued.Controls.Add(this.textBox2);
            this.gpissued.Controls.Add(this.textBox1);
            this.gpissued.Controls.Add(this.txtDTamilName);
            this.gpissued.Controls.Add(this.dpissuedateandtime);
            this.gpissued.Font = new System.Drawing.Font("Oswald Regular", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpissued.Location = new System.Drawing.Point(9, 0);
            this.gpissued.Name = "gpissued";
            this.gpissued.Size = new System.Drawing.Size(323, 161);
            this.gpissued.TabIndex = 1111176;
            this.gpissued.TabStop = false;
            // 
            // textBox6
            // 
            this.textBox6.BackColor = System.Drawing.SystemColors.Control;
            this.textBox6.Enabled = false;
            this.textBox6.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.textBox6.Location = new System.Drawing.Point(263, 128);
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
            this.txtDmode.Location = new System.Drawing.Point(17, 101);
            this.txtDmode.Name = "txtDmode";
            this.txtDmode.ReadOnly = true;
            this.txtDmode.Size = new System.Drawing.Size(112, 27);
            this.txtDmode.TabIndex = 1111181;
            this.txtDmode.TabStop = false;
            // 
            // textBox5
            // 
            this.textBox5.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.textBox5.Location = new System.Drawing.Point(129, 128);
            this.textBox5.MaxLength = 50;
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(134, 27);
            this.textBox5.TabIndex = 1111180;
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.SystemColors.Control;
            this.textBox4.Enabled = false;
            this.textBox4.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.textBox4.Location = new System.Drawing.Point(17, 128);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(112, 27);
            this.textBox4.TabIndex = 1111179;
            this.textBox4.TabStop = false;
            this.textBox4.Text = "Turn Around Time";
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.textBox3.Location = new System.Drawing.Point(129, 101);
            this.textBox3.MaxLength = 50;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(177, 27);
            this.textBox3.TabIndex = 1111178;
            // 
            // cmbDPurchaseShop
            // 
            this.cmbDPurchaseShop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDPurchaseShop.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDPurchaseShop.FormattingEnabled = true;
            this.cmbDPurchaseShop.Items.AddRange(new object[] {
            "Inperson",
            "Mail",
            "WhatsApp",
            "Phone",
            "Mobile App"});
            this.cmbDPurchaseShop.Location = new System.Drawing.Point(129, 74);
            this.cmbDPurchaseShop.Name = "cmbDPurchaseShop";
            this.cmbDPurchaseShop.Size = new System.Drawing.Size(177, 27);
            this.cmbDPurchaseShop.TabIndex = 1111177;
            // 
            // txtOpeningStock
            // 
            this.txtOpeningStock.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtOpeningStock.Location = new System.Drawing.Point(129, 47);
            this.txtOpeningStock.MaxLength = 50;
            this.txtOpeningStock.Name = "txtOpeningStock";
            this.txtOpeningStock.Size = new System.Drawing.Size(177, 27);
            this.txtOpeningStock.TabIndex = 1111176;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.Control;
            this.textBox2.Enabled = false;
            this.textBox2.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.textBox2.Location = new System.Drawing.Point(17, 74);
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
            this.textBox1.Location = new System.Drawing.Point(17, 47);
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
            this.txtDTamilName.Location = new System.Drawing.Point(17, 20);
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
            this.dpissuedateandtime.Location = new System.Drawing.Point(129, 20);
            this.dpissuedateandtime.Name = "dpissuedateandtime";
            this.dpissuedateandtime.Size = new System.Drawing.Size(177, 27);
            this.dpissuedateandtime.TabIndex = 0;
            // 
            // PUR_POIssuedDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(342, 211);
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
            ((System.ComponentModel.ISupportInitialize)(this.errUnit)).EndInit();
            this.gpissued.ResumeLayout(false);
            this.gpissued.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ErrorProvider errUnit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        public System.Windows.Forms.GroupBox gpissued;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox txtDmode;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.ComboBox cmbDPurchaseShop;
        private System.Windows.Forms.TextBox txtOpeningStock;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox txtDTamilName;
        private System.Windows.Forms.DateTimePicker dpissuedateandtime;
    }
}