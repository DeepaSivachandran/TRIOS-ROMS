namespace ROMS
{
    partial class PUR_GRN_Level_Verified
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PUR_GRN_Level_Verified));
            this.errVerified = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtVerifed1 = new System.Windows.Forms.TextBox();
            this.txtVerified2 = new System.Windows.Forms.TextBox();
            this.dpVerified1 = new System.Windows.Forms.DateTimePicker();
            this.dpVerified2 = new System.Windows.Forms.DateTimePicker();
            this.cmbVerified1 = new System.Windows.Forms.ComboBox();
            this.cmbVerified2 = new System.Windows.Forms.ComboBox();
            this.grpVerify = new System.Windows.Forms.GroupBox();
            this.btnAuthorise = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errVerified)).BeginInit();
            this.grpVerify.SuspendLayout();
            this.SuspendLayout();
            // 
            // errVerified
            // 
            this.errVerified.ContainerControl = this;
            // 
            // txtVerifed1
            // 
            this.txtVerifed1.BackColor = System.Drawing.SystemColors.Control;
            this.txtVerifed1.Enabled = false;
            this.txtVerifed1.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVerifed1.Location = new System.Drawing.Point(6, 18);
            this.txtVerifed1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtVerifed1.Name = "txtVerifed1";
            this.txtVerifed1.ReadOnly = true;
            this.txtVerifed1.Size = new System.Drawing.Size(78, 28);
            this.txtVerifed1.TabIndex = 11;
            this.txtVerifed1.Text = "Verified By 1";
            // 
            // txtVerified2
            // 
            this.txtVerified2.BackColor = System.Drawing.SystemColors.Control;
            this.txtVerified2.Enabled = false;
            this.txtVerified2.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVerified2.Location = new System.Drawing.Point(6, 46);
            this.txtVerified2.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtVerified2.Name = "txtVerified2";
            this.txtVerified2.ReadOnly = true;
            this.txtVerified2.Size = new System.Drawing.Size(78, 28);
            this.txtVerified2.TabIndex = 12;
            this.txtVerified2.Text = "Verified By 2";
            // 
            // dpVerified1
            // 
            this.dpVerified1.CustomFormat = "dd/MM/yyyy hh:mm tt";
            this.dpVerified1.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.dpVerified1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpVerified1.Location = new System.Drawing.Point(258, 19);
            this.dpVerified1.Name = "dpVerified1";
            this.dpVerified1.Size = new System.Drawing.Size(177, 27);
            this.dpVerified1.TabIndex = 1;
            this.dpVerified1.ValueChanged += new System.EventHandler(this.DpVerified1_ValueChanged);
            this.dpVerified1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DpVerified1_KeyDown);
            // 
            // dpVerified2
            // 
            this.dpVerified2.CustomFormat = "dd/MM/yyyy hh:mm tt";
            this.dpVerified2.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.dpVerified2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpVerified2.Location = new System.Drawing.Point(258, 46);
            this.dpVerified2.Name = "dpVerified2";
            this.dpVerified2.Size = new System.Drawing.Size(177, 27);
            this.dpVerified2.TabIndex = 3;
            this.dpVerified2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DpVerified2_KeyDown);
            // 
            // cmbVerified1
            // 
            this.cmbVerified1.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbVerified1.FormattingEnabled = true;
            this.cmbVerified1.Location = new System.Drawing.Point(84, 19);
            this.cmbVerified1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbVerified1.Name = "cmbVerified1";
            this.cmbVerified1.Size = new System.Drawing.Size(174, 27);
            this.cmbVerified1.TabIndex = 0;
            this.cmbVerified1.Enter += new System.EventHandler(this.CmbVerified1_Enter);
            this.cmbVerified1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbVerified1_KeyDown);
            this.cmbVerified1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbVerified1_KeyPress);
            this.cmbVerified1.Leave += new System.EventHandler(this.CmbVerified1_Leave);
            // 
            // cmbVerified2
            // 
            this.cmbVerified2.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbVerified2.FormattingEnabled = true;
            this.cmbVerified2.Location = new System.Drawing.Point(84, 46);
            this.cmbVerified2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbVerified2.Name = "cmbVerified2";
            this.cmbVerified2.Size = new System.Drawing.Size(174, 27);
            this.cmbVerified2.TabIndex = 2;
            this.cmbVerified2.Enter += new System.EventHandler(this.CmbVerified2_Enter);
            this.cmbVerified2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbVerified2_KeyDown);
            this.cmbVerified2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbVerified2_KeyPress);
            this.cmbVerified2.Leave += new System.EventHandler(this.CmbVerified2_Leave);
            // 
            // grpVerify
            // 
            this.grpVerify.Controls.Add(this.btnAuthorise);
            this.grpVerify.Controls.Add(this.cmbVerified1);
            this.grpVerify.Controls.Add(this.cmbVerified2);
            this.grpVerify.Controls.Add(this.txtVerifed1);
            this.grpVerify.Controls.Add(this.dpVerified2);
            this.grpVerify.Controls.Add(this.txtVerified2);
            this.grpVerify.Controls.Add(this.dpVerified1);
            this.grpVerify.Location = new System.Drawing.Point(12, 12);
            this.grpVerify.Name = "grpVerify";
            this.grpVerify.Size = new System.Drawing.Size(451, 124);
            this.grpVerify.TabIndex = 13;
            this.grpVerify.TabStop = false;
            // 
            // btnAuthorise
            // 
            this.btnAuthorise.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAuthorise.Image = global::ROMS.Properties.Resources.save;
            this.btnAuthorise.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAuthorise.Location = new System.Drawing.Point(355, 81);
            this.btnAuthorise.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnAuthorise.Name = "btnAuthorise";
            this.btnAuthorise.Size = new System.Drawing.Size(80, 33);
            this.btnAuthorise.TabIndex = 13;
            this.btnAuthorise.Text = "Update";
            this.btnAuthorise.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAuthorise.UseVisualStyleBackColor = true;
            this.btnAuthorise.Click += new System.EventHandler(this.btnAuthorise_Click);
            this.btnAuthorise.Enter += new System.EventHandler(this.BtnAuthorise_Enter);
            this.btnAuthorise.Leave += new System.EventHandler(this.BtnAuthorise_Leave);
            // 
            // PUR_GRN_Level_Verified
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(477, 155);
            this.Controls.Add(this.grpVerify);
            this.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PUR_GRN_Level_Verified";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Verified Process";
            this.Load += new System.EventHandler(this.PUR_GRN_Level_Verified_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errVerified)).EndInit();
            this.grpVerify.ResumeLayout(false);
            this.grpVerify.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ErrorProvider errVerified;
        private System.Windows.Forms.TextBox txtVerifed1;
        private System.Windows.Forms.TextBox txtVerified2;
        private System.Windows.Forms.DateTimePicker dpVerified2;
        private System.Windows.Forms.DateTimePicker dpVerified1;
        public System.Windows.Forms.ComboBox cmbVerified2;
        public System.Windows.Forms.ComboBox cmbVerified1;
        private System.Windows.Forms.GroupBox grpVerify;
        public System.Windows.Forms.Button btnAuthorise;
    }
}