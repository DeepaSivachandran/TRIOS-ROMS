namespace ROMS
{
    partial class PUR_Purchase_Level_Verified
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PUR_Purchase_Level_Verified));
            this.errVerified = new System.Windows.Forms.ErrorProvider(this.components);
            this.dpVerified1 = new System.Windows.Forms.DateTimePicker();
            this.grpVerify = new System.Windows.Forms.GroupBox();
            this.lvVerified1 = new System.Windows.Forms.ListView();
            this.columnHeader23 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader24 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvVerified2 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmbFormat2 = new System.Windows.Forms.ComboBox();
            this.mtbTime2 = new System.Windows.Forms.MaskedTextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtVerified2 = new System.Windows.Forms.TextBox();
            this.dpVerified2 = new System.Windows.Forms.DateTimePicker();
            this.cmbFormat1 = new System.Windows.Forms.ComboBox();
            this.mtbTime1 = new System.Windows.Forms.MaskedTextBox();
            this.lblVerified2 = new System.Windows.Forms.Label();
            this.txtDVerifed1 = new System.Windows.Forms.TextBox();
            this.lblVerified1 = new System.Windows.Forms.Label();
            this.txtVerified1 = new System.Windows.Forms.TextBox();
            this.btnAuthorise = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errVerified)).BeginInit();
            this.grpVerify.SuspendLayout();
            this.SuspendLayout();
            // 
            // errVerified
            // 
            this.errVerified.ContainerControl = this;
            // 
            // dpVerified1
            // 
            this.dpVerified1.CustomFormat = "dd/MM/yyyy";
            this.dpVerified1.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.dpVerified1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpVerified1.Location = new System.Drawing.Point(258, 19);
            this.dpVerified1.Name = "dpVerified1";
            this.dpVerified1.Size = new System.Drawing.Size(103, 27);
            this.dpVerified1.TabIndex = 1;
            this.dpVerified1.ValueChanged += new System.EventHandler(this.DpVerified1_ValueChanged);
            this.dpVerified1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DpVerified1_KeyDown);
            // 
            // grpVerify
            // 
            this.grpVerify.Controls.Add(this.lvVerified1);
            this.grpVerify.Controls.Add(this.lvVerified2);
            this.grpVerify.Controls.Add(this.cmbFormat2);
            this.grpVerify.Controls.Add(this.mtbTime2);
            this.grpVerify.Controls.Add(this.textBox1);
            this.grpVerify.Controls.Add(this.txtVerified2);
            this.grpVerify.Controls.Add(this.dpVerified2);
            this.grpVerify.Controls.Add(this.cmbFormat1);
            this.grpVerify.Controls.Add(this.mtbTime1);
            this.grpVerify.Controls.Add(this.lblVerified2);
            this.grpVerify.Controls.Add(this.txtDVerifed1);
            this.grpVerify.Controls.Add(this.lblVerified1);
            this.grpVerify.Controls.Add(this.txtVerified1);
            this.grpVerify.Controls.Add(this.btnAuthorise);
            this.grpVerify.Controls.Add(this.dpVerified1);
            this.grpVerify.Location = new System.Drawing.Point(12, 12);
            this.grpVerify.Name = "grpVerify";
            this.grpVerify.Size = new System.Drawing.Size(454, 147);
            this.grpVerify.TabIndex = 0;
            this.grpVerify.TabStop = false;
            // 
            // lvVerified1
            // 
            this.lvVerified1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader23,
            this.columnHeader24});
            this.lvVerified1.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.lvVerified1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvVerified1.HideSelection = false;
            this.lvVerified1.Location = new System.Drawing.Point(84, 46);
            this.lvVerified1.Name = "lvVerified1";
            this.lvVerified1.Size = new System.Drawing.Size(265, 68);
            this.lvVerified1.TabIndex = 111111133;
            this.lvVerified1.UseCompatibleStateImageBehavior = false;
            this.lvVerified1.View = System.Windows.Forms.View.Details;
            this.lvVerified1.Visible = false;
            this.lvVerified1.DoubleClick += new System.EventHandler(this.LvVerified1_DoubleClick);
            this.lvVerified1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LvVerified1_KeyDown);
            // 
            // columnHeader23
            // 
            this.columnHeader23.Width = 120;
            // 
            // columnHeader24
            // 
            this.columnHeader24.Width = 0;
            // 
            // lvVerified2
            // 
            this.lvVerified2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvVerified2.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.lvVerified2.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvVerified2.HideSelection = false;
            this.lvVerified2.Location = new System.Drawing.Point(84, 73);
            this.lvVerified2.Name = "lvVerified2";
            this.lvVerified2.Size = new System.Drawing.Size(265, 68);
            this.lvVerified2.TabIndex = 111111145;
            this.lvVerified2.UseCompatibleStateImageBehavior = false;
            this.lvVerified2.View = System.Windows.Forms.View.Details;
            this.lvVerified2.Visible = false;
            this.lvVerified2.DoubleClick += new System.EventHandler(this.LvVerified2_DoubleClick);
            this.lvVerified2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LvVerified2_KeyDown);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 120;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Width = 0;
            // 
            // cmbFormat2
            // 
            this.cmbFormat2.FormattingEnabled = true;
            this.cmbFormat2.Items.AddRange(new object[] {
            "AM",
            "PM"});
            this.cmbFormat2.Location = new System.Drawing.Point(403, 45);
            this.cmbFormat2.Name = "cmbFormat2";
            this.cmbFormat2.Size = new System.Drawing.Size(41, 28);
            this.cmbFormat2.TabIndex = 7;
            this.cmbFormat2.Enter += new System.EventHandler(this.CmbFormat2_Enter);
            this.cmbFormat2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbFormat2_KeyDown);
            this.cmbFormat2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbFormat2_KeyPress);
            this.cmbFormat2.Leave += new System.EventHandler(this.CmbFormat2_Leave);
            // 
            // mtbTime2
            // 
            this.mtbTime2.Location = new System.Drawing.Point(361, 45);
            this.mtbTime2.Mask = "90:00";
            this.mtbTime2.Name = "mtbTime2";
            this.mtbTime2.Size = new System.Drawing.Size(42, 28);
            this.mtbTime2.TabIndex = 6;
            this.mtbTime2.ValidatingType = typeof(System.DateTime);
            this.mtbTime2.Enter += new System.EventHandler(this.MtbTime2_Enter);
            this.mtbTime2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MtbTime2_KeyDown);
            this.mtbTime2.Leave += new System.EventHandler(this.MtbTime2_Leave);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.textBox1.Location = new System.Drawing.Point(6, 46);
            this.textBox1.MaxLength = 100;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(78, 27);
            this.textBox1.TabIndex = 111111144;
            this.textBox1.Text = "Verified By 2";
            // 
            // txtVerified2
            // 
            this.txtVerified2.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtVerified2.Location = new System.Drawing.Point(84, 46);
            this.txtVerified2.MaxLength = 100;
            this.txtVerified2.Name = "txtVerified2";
            this.txtVerified2.Size = new System.Drawing.Size(174, 27);
            this.txtVerified2.TabIndex = 4;
            this.txtVerified2.TextChanged += new System.EventHandler(this.TxtVerified2_TextChanged);
            this.txtVerified2.Enter += new System.EventHandler(this.TxtVerified2_Enter);
            this.txtVerified2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtVerified2_KeyDown);
            this.txtVerified2.Leave += new System.EventHandler(this.TxtVerified2_Leave);
            // 
            // dpVerified2
            // 
            this.dpVerified2.CustomFormat = "dd/MM/yyyy";
            this.dpVerified2.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.dpVerified2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpVerified2.Location = new System.Drawing.Point(258, 46);
            this.dpVerified2.Name = "dpVerified2";
            this.dpVerified2.Size = new System.Drawing.Size(103, 27);
            this.dpVerified2.TabIndex = 5;
            this.dpVerified2.ValueChanged += new System.EventHandler(this.DpVerified2_ValueChanged);
            this.dpVerified2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DpVerified2_KeyDown);
            // 
            // cmbFormat1
            // 
            this.cmbFormat1.FormattingEnabled = true;
            this.cmbFormat1.Items.AddRange(new object[] {
            "AM",
            "PM"});
            this.cmbFormat1.Location = new System.Drawing.Point(403, 18);
            this.cmbFormat1.Name = "cmbFormat1";
            this.cmbFormat1.Size = new System.Drawing.Size(41, 28);
            this.cmbFormat1.TabIndex = 3;
            this.cmbFormat1.SelectedIndexChanged += new System.EventHandler(this.CmbFormat1_SelectedIndexChanged);
            this.cmbFormat1.Enter += new System.EventHandler(this.CmbFormat1_Enter);
            this.cmbFormat1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbFormat1_KeyDown);
            this.cmbFormat1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbFormat1_KeyPress);
            this.cmbFormat1.Leave += new System.EventHandler(this.CmbFormat1_Leave);
            // 
            // mtbTime1
            // 
            this.mtbTime1.Location = new System.Drawing.Point(361, 18);
            this.mtbTime1.Mask = "90:00";
            this.mtbTime1.Name = "mtbTime1";
            this.mtbTime1.Size = new System.Drawing.Size(42, 28);
            this.mtbTime1.TabIndex = 2;
            this.mtbTime1.ValidatingType = typeof(System.DateTime);
            this.mtbTime1.Enter += new System.EventHandler(this.MtbTime1_Enter);
            this.mtbTime1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MtbTime1_KeyDown);
            this.mtbTime1.Leave += new System.EventHandler(this.MtbTime1_Leave);
            // 
            // lblVerified2
            // 
            this.lblVerified2.AutoSize = true;
            this.lblVerified2.Location = new System.Drawing.Point(43, 100);
            this.lblVerified2.Name = "lblVerified2";
            this.lblVerified2.Size = new System.Drawing.Size(0, 20);
            this.lblVerified2.TabIndex = 111111139;
            this.lblVerified2.Visible = false;
            // 
            // txtDVerifed1
            // 
            this.txtDVerifed1.BackColor = System.Drawing.SystemColors.Control;
            this.txtDVerifed1.Enabled = false;
            this.txtDVerifed1.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtDVerifed1.Location = new System.Drawing.Point(6, 19);
            this.txtDVerifed1.MaxLength = 100;
            this.txtDVerifed1.Name = "txtDVerifed1";
            this.txtDVerifed1.ReadOnly = true;
            this.txtDVerifed1.Size = new System.Drawing.Size(78, 27);
            this.txtDVerifed1.TabIndex = 111111138;
            this.txtDVerifed1.Text = "Verified By 1";
            // 
            // lblVerified1
            // 
            this.lblVerified1.AutoSize = true;
            this.lblVerified1.Location = new System.Drawing.Point(6, 87);
            this.lblVerified1.Name = "lblVerified1";
            this.lblVerified1.Size = new System.Drawing.Size(0, 20);
            this.lblVerified1.TabIndex = 111111135;
            this.lblVerified1.Visible = false;
            // 
            // txtVerified1
            // 
            this.txtVerified1.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtVerified1.Location = new System.Drawing.Point(84, 19);
            this.txtVerified1.MaxLength = 100;
            this.txtVerified1.Name = "txtVerified1";
            this.txtVerified1.Size = new System.Drawing.Size(174, 27);
            this.txtVerified1.TabIndex = 0;
            this.txtVerified1.TextChanged += new System.EventHandler(this.TxtVerified1_TextChanged);
            this.txtVerified1.Enter += new System.EventHandler(this.TxtVerified1_Enter);
            this.txtVerified1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtVerified1_KeyDown);
            this.txtVerified1.Leave += new System.EventHandler(this.TxtVerified1_Leave);
            // 
            // btnAuthorise
            // 
            this.btnAuthorise.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAuthorise.Image = global::ROMS.Properties.Resources.save;
            this.btnAuthorise.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAuthorise.Location = new System.Drawing.Point(363, 81);
            this.btnAuthorise.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnAuthorise.Name = "btnAuthorise";
            this.btnAuthorise.Size = new System.Drawing.Size(80, 33);
            this.btnAuthorise.TabIndex = 8;
            this.btnAuthorise.Text = "Update";
            this.btnAuthorise.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAuthorise.UseVisualStyleBackColor = true;
            this.btnAuthorise.Click += new System.EventHandler(this.btnAuthorise_Click);
            this.btnAuthorise.Enter += new System.EventHandler(this.BtnAuthorise_Enter);
            this.btnAuthorise.Leave += new System.EventHandler(this.BtnAuthorise_Leave);
            // 
            // PUR_Purchase_Level_Verified
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(477, 167);
            this.Controls.Add(this.grpVerify);
            this.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PUR_Purchase_Level_Verified";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Verification Process";
            this.Load += new System.EventHandler(this.PUR_GRN_Level_Verified_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PUR_GRN_Level_Verified_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.errVerified)).EndInit();
            this.grpVerify.ResumeLayout(false);
            this.grpVerify.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ErrorProvider errVerified;
        private System.Windows.Forms.GroupBox grpVerify;
        public System.Windows.Forms.Button btnAuthorise;
        public System.Windows.Forms.ListView lvVerified1;
        private System.Windows.Forms.ColumnHeader columnHeader23;
        private System.Windows.Forms.ColumnHeader columnHeader24;
        private System.Windows.Forms.Label lblVerified1;
        private System.Windows.Forms.TextBox txtDVerifed1;
        private System.Windows.Forms.Label lblVerified2;
        public System.Windows.Forms.DateTimePicker dpVerified1;
        public System.Windows.Forms.TextBox txtVerified1;
        public System.Windows.Forms.MaskedTextBox mtbTime1;
        public System.Windows.Forms.ComboBox cmbFormat1;
        public System.Windows.Forms.ComboBox cmbFormat2;
        public System.Windows.Forms.MaskedTextBox mtbTime2;
        private System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.TextBox txtVerified2;
        public System.Windows.Forms.DateTimePicker dpVerified2;
        public System.Windows.Forms.ListView lvVerified2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
    }
}