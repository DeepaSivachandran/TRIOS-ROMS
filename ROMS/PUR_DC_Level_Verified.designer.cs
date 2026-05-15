namespace ROMS
{
    partial class PUR_DC_Level_Verified
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PUR_DC_Level_Verified));
            this.errVerified = new System.Windows.Forms.ErrorProvider(this.components);
            this.dpVerified = new System.Windows.Forms.DateTimePicker();
            this.grpVerify = new System.Windows.Forms.GroupBox();
            this.cmbFormat = new System.Windows.Forms.ComboBox();
            this.mtbTime = new System.Windows.Forms.MaskedTextBox();
            this.lblVerified2 = new System.Windows.Forms.Label();
            this.txtDVerifed1 = new System.Windows.Forms.TextBox();
            this.lblVerified1 = new System.Windows.Forms.Label();
            this.txtVerified = new System.Windows.Forms.TextBox();
            this.btnAuthorise = new System.Windows.Forms.Button();
            this.lvVerified = new System.Windows.Forms.ListView();
            this.columnHeader23 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader24 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.errVerified)).BeginInit();
            this.grpVerify.SuspendLayout();
            this.SuspendLayout();
            // 
            // errVerified
            // 
            this.errVerified.ContainerControl = this;
            // 
            // dpVerified
            // 
            this.dpVerified.CustomFormat = "dd/MM/yyyy";
            this.dpVerified.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.dpVerified.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpVerified.Location = new System.Drawing.Point(258, 19);
            this.dpVerified.Name = "dpVerified";
            this.dpVerified.Size = new System.Drawing.Size(103, 27);
            this.dpVerified.TabIndex = 1;
            this.dpVerified.ValueChanged += new System.EventHandler(this.DpVerified1_ValueChanged);
            this.dpVerified.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DpVerified1_KeyDown);
            // 
            // grpVerify
            // 
            this.grpVerify.Controls.Add(this.cmbFormat);
            this.grpVerify.Controls.Add(this.mtbTime);
            this.grpVerify.Controls.Add(this.lblVerified2);
            this.grpVerify.Controls.Add(this.txtDVerifed1);
            this.grpVerify.Controls.Add(this.lblVerified1);
            this.grpVerify.Controls.Add(this.txtVerified);
            this.grpVerify.Controls.Add(this.btnAuthorise);
            this.grpVerify.Controls.Add(this.dpVerified);
            this.grpVerify.Location = new System.Drawing.Point(12, 12);
            this.grpVerify.Name = "grpVerify";
            this.grpVerify.Size = new System.Drawing.Size(454, 114);
            this.grpVerify.TabIndex = 0;
            this.grpVerify.TabStop = false;
            // 
            // cmbFormat
            // 
            this.cmbFormat.FormattingEnabled = true;
            this.cmbFormat.Items.AddRange(new object[] {
            "AM",
            "PM"});
            this.cmbFormat.Location = new System.Drawing.Point(403, 18);
            this.cmbFormat.Name = "cmbFormat";
            this.cmbFormat.Size = new System.Drawing.Size(41, 28);
            this.cmbFormat.TabIndex = 3;
            this.cmbFormat.SelectedIndexChanged += new System.EventHandler(this.cmbFormat_SelectedIndexChanged);
            this.cmbFormat.Enter += new System.EventHandler(this.CmbFormat1_Enter);
            this.cmbFormat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbFormat1_KeyDown);
            this.cmbFormat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbFormat1_KeyPress);
            this.cmbFormat.Leave += new System.EventHandler(this.CmbFormat1_Leave);
            // 
            // mtbTime
            // 
            this.mtbTime.Location = new System.Drawing.Point(361, 18);
            this.mtbTime.Mask = "90:00";
            this.mtbTime.Name = "mtbTime";
            this.mtbTime.Size = new System.Drawing.Size(42, 28);
            this.mtbTime.TabIndex = 2;
            this.mtbTime.ValidatingType = typeof(System.DateTime);
            this.mtbTime.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.mtbTime_MaskInputRejected);
            this.mtbTime.Enter += new System.EventHandler(this.MtbTime1_Enter);
            this.mtbTime.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MtbTime1_KeyDown);
            this.mtbTime.Leave += new System.EventHandler(this.MtbTime1_Leave);
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
            this.txtDVerifed1.Text = "Verified By ";
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
            // txtVerified
            // 
            this.txtVerified.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtVerified.Location = new System.Drawing.Point(84, 19);
            this.txtVerified.MaxLength = 100;
            this.txtVerified.Name = "txtVerified";
            this.txtVerified.Size = new System.Drawing.Size(174, 27);
            this.txtVerified.TabIndex = 0;
            this.txtVerified.TextChanged += new System.EventHandler(this.TxtVerified1_TextChanged);
            this.txtVerified.Enter += new System.EventHandler(this.TxtVerified1_Enter);
            this.txtVerified.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtVerified1_KeyDown);
            this.txtVerified.Leave += new System.EventHandler(this.TxtVerified1_Leave);
            // 
            // btnAuthorise
            // 
            this.btnAuthorise.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAuthorise.Image = global::ROMS.Properties.Resources.save;
            this.btnAuthorise.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAuthorise.Location = new System.Drawing.Point(364, 62);
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
            // lvVerified
            // 
            this.lvVerified.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader23,
            this.columnHeader24});
            this.lvVerified.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.lvVerified.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvVerified.HideSelection = false;
            this.lvVerified.Location = new System.Drawing.Point(96, 58);
            this.lvVerified.Name = "lvVerified";
            this.lvVerified.Size = new System.Drawing.Size(265, 68);
            this.lvVerified.TabIndex = 111111133;
            this.lvVerified.UseCompatibleStateImageBehavior = false;
            this.lvVerified.View = System.Windows.Forms.View.Details;
            this.lvVerified.Visible = false;
            this.lvVerified.DoubleClick += new System.EventHandler(this.LvVerified1_DoubleClick);
            this.lvVerified.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LvVerified1_KeyDown);
            // 
            // columnHeader23
            // 
            this.columnHeader23.Width = 120;
            // 
            // columnHeader24
            // 
            this.columnHeader24.Width = 0;
            // 
            // PUR_DC_Level_Verified
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(477, 134);
            this.Controls.Add(this.lvVerified);
            this.Controls.Add(this.grpVerify);
            this.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PUR_DC_Level_Verified";
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
        public System.Windows.Forms.ListView lvVerified;
        private System.Windows.Forms.ColumnHeader columnHeader23;
        private System.Windows.Forms.ColumnHeader columnHeader24;
        private System.Windows.Forms.Label lblVerified1;
        private System.Windows.Forms.TextBox txtDVerifed1;
        private System.Windows.Forms.Label lblVerified2;
        public System.Windows.Forms.DateTimePicker dpVerified;
        public System.Windows.Forms.TextBox txtVerified;
        public System.Windows.Forms.MaskedTextBox mtbTime;
        public System.Windows.Forms.ComboBox cmbFormat;
    }
}