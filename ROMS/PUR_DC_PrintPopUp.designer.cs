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
            this.btnOk = new System.Windows.Forms.Button();
            this.rbThermal = new System.Windows.Forms.RadioButton();
            this.rbA4Print = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.errVerified)).BeginInit();
            this.SuspendLayout();
            // 
            // errVerified
            // 
            this.errVerified.ContainerControl = this;
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.White;
            this.btnOk.Image = global::ROMS.Properties.Resources.print;
            this.btnOk.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnOk.Location = new System.Drawing.Point(85, 71);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 32);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "Print";
            this.btnOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // rbThermal
            // 
            this.rbThermal.AutoSize = true;
            this.rbThermal.Location = new System.Drawing.Point(14, 15);
            this.rbThermal.Name = "rbThermal";
            this.rbThermal.Size = new System.Drawing.Size(100, 24);
            this.rbThermal.TabIndex = 3;
            this.rbThermal.TabStop = true;
            this.rbThermal.Text = "Thermal Print";
            this.rbThermal.UseVisualStyleBackColor = true;
            // 
            // rbA4Print
            // 
            this.rbA4Print.AutoSize = true;
            this.rbA4Print.Location = new System.Drawing.Point(14, 45);
            this.rbA4Print.Name = "rbA4Print";
            this.rbA4Print.Size = new System.Drawing.Size(71, 24);
            this.rbA4Print.TabIndex = 4;
            this.rbA4Print.TabStop = true;
            this.rbA4Print.Text = "A4 Print";
            this.rbA4Print.UseVisualStyleBackColor = true;
            // 
            // PUR_DC_PrintPopUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(168, 110);
            this.Controls.Add(this.rbA4Print);
            this.Controls.Add(this.rbThermal);
            this.Controls.Add(this.btnOk);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ErrorProvider errVerified;
        private System.Windows.Forms.RadioButton rbA4Print;
        private System.Windows.Forms.RadioButton rbThermal;
        private System.Windows.Forms.Button btnOk;
    }
}