namespace ROMS
{
    partial class CP_Brand
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CP_Brand));
            this.txtDEBrandNameInEnglish = new System.Windows.Forms.TextBox();
            this.txtEBrandNameInEnglish = new System.Windows.Forms.TextBox();
            this.grbform = new System.Windows.Forms.GroupBox();
            this.txtDEBrandNameInTamil = new System.Windows.Forms.TextBox();
            this.txtEBrandNameInTamil = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.errBrand = new System.Windows.Forms.ErrorProvider(this.components);
            this.grbform.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errBrand)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDEBrandNameInEnglish
            // 
            this.txtDEBrandNameInEnglish.BackColor = System.Drawing.SystemColors.Control;
            this.txtDEBrandNameInEnglish.Enabled = false;
            this.txtDEBrandNameInEnglish.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDEBrandNameInEnglish.Location = new System.Drawing.Point(20, 29);
            this.txtDEBrandNameInEnglish.Name = "txtDEBrandNameInEnglish";
            this.txtDEBrandNameInEnglish.ReadOnly = true;
            this.txtDEBrandNameInEnglish.Size = new System.Drawing.Size(181, 27);
            this.txtDEBrandNameInEnglish.TabIndex = 7;
            this.txtDEBrandNameInEnglish.Text = "Brand Name In English";
            // 
            // txtEBrandNameInEnglish
            // 
            this.txtEBrandNameInEnglish.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEBrandNameInEnglish.Location = new System.Drawing.Point(201, 29);
            this.txtEBrandNameInEnglish.MaxLength = 50;
            this.txtEBrandNameInEnglish.Name = "txtEBrandNameInEnglish";
            this.txtEBrandNameInEnglish.Size = new System.Drawing.Size(287, 27);
            this.txtEBrandNameInEnglish.TabIndex = 0;
            this.txtEBrandNameInEnglish.Enter += new System.EventHandler(this.TxtEBrandNameInEnglish_Enter);
            this.txtEBrandNameInEnglish.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtEBrandNameInEnglish_KeyDown);
            this.txtEBrandNameInEnglish.Leave += new System.EventHandler(this.TxtEBrandNameInEnglish_Leave);
            // 
            // grbform
            // 
            this.grbform.Controls.Add(this.txtDEBrandNameInTamil);
            this.grbform.Controls.Add(this.txtEBrandNameInTamil);
            this.grbform.Controls.Add(this.txtDEBrandNameInEnglish);
            this.grbform.Controls.Add(this.btnClose);
            this.grbform.Controls.Add(this.btnSave);
            this.grbform.Controls.Add(this.txtEBrandNameInEnglish);
            this.grbform.Location = new System.Drawing.Point(17, 12);
            this.grbform.Name = "grbform";
            this.grbform.Size = new System.Drawing.Size(510, 136);
            this.grbform.TabIndex = 28;
            this.grbform.TabStop = false;
            this.grbform.Enter += new System.EventHandler(this.Grbform_Enter);
            // 
            // txtDEBrandNameInTamil
            // 
            this.txtDEBrandNameInTamil.BackColor = System.Drawing.SystemColors.Control;
            this.txtDEBrandNameInTamil.Enabled = false;
            this.txtDEBrandNameInTamil.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDEBrandNameInTamil.Location = new System.Drawing.Point(20, 56);
            this.txtDEBrandNameInTamil.Name = "txtDEBrandNameInTamil";
            this.txtDEBrandNameInTamil.ReadOnly = true;
            this.txtDEBrandNameInTamil.Size = new System.Drawing.Size(181, 27);
            this.txtDEBrandNameInTamil.TabIndex = 1111137;
            this.txtDEBrandNameInTamil.Text = "Brand Name In Tamil";
            // 
            // txtEBrandNameInTamil
            // 
            this.txtEBrandNameInTamil.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEBrandNameInTamil.Location = new System.Drawing.Point(201, 56);
            this.txtEBrandNameInTamil.MaxLength = 50;
            this.txtEBrandNameInTamil.Name = "txtEBrandNameInTamil";
            this.txtEBrandNameInTamil.Size = new System.Drawing.Size(287, 27);
            this.txtEBrandNameInTamil.TabIndex = 1;
            this.txtEBrandNameInTamil.Enter += new System.EventHandler(this.TxtEBrandNameInTamil_Enter);
            this.txtEBrandNameInTamil.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtEBrandNameInTamil_KeyDown);
            this.txtEBrandNameInTamil.Leave += new System.EventHandler(this.TxtEBrandNameInTamil_Leave);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnClose.Image = global::ROMS.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(413, 89);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 29);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            this.btnClose.Enter += new System.EventHandler(this.btnClose_Enter);
            this.btnClose.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnClose_KeyDown);
            this.btnClose.Leave += new System.EventHandler(this.btnClose_Leave);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnSave.Image = global::ROMS.Properties.Resources.save;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(323, 89);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(84, 29);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.Enter += new System.EventHandler(this.btnSave_Enter);
            this.btnSave.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnSave_KeyDown);
            this.btnSave.Leave += new System.EventHandler(this.btnSave_Leave);
            // 
            // errBrand
            // 
            this.errBrand.ContainerControl = this;
            // 
            // CP_Brand
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(547, 170);
            this.Controls.Add(this.grbform);
            this.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CP_Brand";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Brand";
            this.Load += new System.EventHandler(this.CP_Brand_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CP_Brand_KeyDown);
            this.Leave += new System.EventHandler(this.CP_Brand_Leave);
            this.grbform.ResumeLayout(false);
            this.grbform.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errBrand)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txtDEBrandNameInEnglish;
        private System.Windows.Forms.TextBox txtEBrandNameInEnglish;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox grbform;
        private System.Windows.Forms.ErrorProvider errBrand;
        private System.Windows.Forms.TextBox txtDEBrandNameInTamil;
        private System.Windows.Forms.TextBox txtEBrandNameInTamil;
    }
}