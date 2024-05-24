namespace ROMS
{
    partial class PUR_DC_PrintPopUp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PUR_DC_PrintPopUp));
            this.errVerified = new System.Windows.Forms.ErrorProvider(this.components);
            this.grpVerify = new System.Windows.Forms.GroupBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.chkA4Print = new System.Windows.Forms.CheckBox();
            this.chkThermal = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.errVerified)).BeginInit();
            this.grpVerify.SuspendLayout();
            this.SuspendLayout();
            // 
            // errVerified
            // 
            this.errVerified.ContainerControl = this;
            // 
            // grpVerify
            // 
            this.grpVerify.Controls.Add(this.btnOk);
            this.grpVerify.Controls.Add(this.chkA4Print);
            this.grpVerify.Controls.Add(this.chkThermal);
            this.grpVerify.Location = new System.Drawing.Point(12, 3);
            this.grpVerify.Name = "grpVerify";
            this.grpVerify.Size = new System.Drawing.Size(311, 85);
            this.grpVerify.TabIndex = 0;
            this.grpVerify.TabStop = false;
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.White;
            this.btnOk.Image = global::ROMS.Properties.Resources.print;
            this.btnOk.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnOk.Location = new System.Drawing.Point(226, 47);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 32);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "Print";
            this.btnOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // chkA4Print
            // 
            this.chkA4Print.AutoSize = true;
            this.chkA4Print.Location = new System.Drawing.Point(152, 22);
            this.chkA4Print.Name = "chkA4Print";
            this.chkA4Print.Size = new System.Drawing.Size(72, 24);
            this.chkA4Print.TabIndex = 1;
            this.chkA4Print.Text = "A4 Print\r\n";
            this.chkA4Print.UseVisualStyleBackColor = true;
            // 
            // chkThermal
            // 
            this.chkThermal.AutoSize = true;
            this.chkThermal.Location = new System.Drawing.Point(30, 22);
            this.chkThermal.Name = "chkThermal";
            this.chkThermal.Size = new System.Drawing.Size(101, 24);
            this.chkThermal.TabIndex = 0;
            this.chkThermal.Text = "Thermal Print";
            this.chkThermal.UseVisualStyleBackColor = true;
            // 
            // PUR_DC_PrintPopUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(336, 97);
            this.Controls.Add(this.grpVerify);
            this.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PUR_DC_PrintPopUp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Print";
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
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.CheckBox chkA4Print;
        private System.Windows.Forms.CheckBox chkThermal;
    }
}