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
            this.txtDTBrandName = new System.Windows.Forms.TextBox();
            this.txtTBrandName = new System.Windows.Forms.TextBox();
            this.txtDEBrandName = new System.Windows.Forms.TextBox();
            this.txtEBrandName = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.grbform = new System.Windows.Forms.GroupBox();
            this.txtDTLabelName = new System.Windows.Forms.TextBox();
            this.txtDELabelName = new System.Windows.Forms.TextBox();
            this.txtTLabelName = new System.Windows.Forms.TextBox();
            this.txtELabelName = new System.Windows.Forms.TextBox();
            this.errBrand = new System.Windows.Forms.ErrorProvider(this.components);
            this.grbform.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errBrand)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDTBrandName
            // 
            this.txtDTBrandName.BackColor = System.Drawing.SystemColors.Control;
            this.txtDTBrandName.Enabled = false;
            this.txtDTBrandName.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDTBrandName.Location = new System.Drawing.Point(44, 57);
            this.txtDTBrandName.Name = "txtDTBrandName";
            this.txtDTBrandName.ReadOnly = true;
            this.txtDTBrandName.Size = new System.Drawing.Size(181, 27);
            this.txtDTBrandName.TabIndex = 6;
            this.txtDTBrandName.Text = "Brand Name in Tamil";
            // 
            // txtTBrandName
            // 
            this.txtTBrandName.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTBrandName.Location = new System.Drawing.Point(225, 57);
            this.txtTBrandName.MaxLength = 100;
            this.txtTBrandName.Name = "txtTBrandName";
            this.txtTBrandName.Size = new System.Drawing.Size(370, 27);
            this.txtTBrandName.TabIndex = 1;
            this.txtTBrandName.Enter += new System.EventHandler(this.txtTBrandName_Enter);
            this.txtTBrandName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTBrandName_KeyDown);
            this.txtTBrandName.Leave += new System.EventHandler(this.txtTBrandName_Leave);
            // 
            // txtDEBrandName
            // 
            this.txtDEBrandName.BackColor = System.Drawing.SystemColors.Control;
            this.txtDEBrandName.Enabled = false;
            this.txtDEBrandName.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDEBrandName.Location = new System.Drawing.Point(44, 30);
            this.txtDEBrandName.Name = "txtDEBrandName";
            this.txtDEBrandName.ReadOnly = true;
            this.txtDEBrandName.Size = new System.Drawing.Size(181, 27);
            this.txtDEBrandName.TabIndex = 7;
            this.txtDEBrandName.Text = "Brand Name in English";
            // 
            // txtEBrandName
            // 
            this.txtEBrandName.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEBrandName.Location = new System.Drawing.Point(225, 30);
            this.txtEBrandName.MaxLength = 50;
            this.txtEBrandName.Name = "txtEBrandName";
            this.txtEBrandName.Size = new System.Drawing.Size(370, 27);
            this.txtEBrandName.TabIndex = 0;
            this.txtEBrandName.Enter += new System.EventHandler(this.txtEBrandName_Enter);
            this.txtEBrandName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEBrandName_KeyDown);
            this.txtEBrandName.Leave += new System.EventHandler(this.txtEBrandName_Leave);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnSave.Image = global::ROMS.Properties.Resources.save;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(427, 146);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(84, 29);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.Enter += new System.EventHandler(this.btnSave_Enter);
            this.btnSave.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnSave_KeyDown);
            this.btnSave.Leave += new System.EventHandler(this.btnSave_Leave);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnClose.Image = global::ROMS.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(519, 146);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 29);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            this.btnClose.Enter += new System.EventHandler(this.btnClose_Enter);
            this.btnClose.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnClose_KeyDown);
            this.btnClose.Leave += new System.EventHandler(this.btnClose_Leave);
            // 
            // grbform
            // 
            this.grbform.Controls.Add(this.txtDTLabelName);
            this.grbform.Controls.Add(this.txtDELabelName);
            this.grbform.Controls.Add(this.txtDTBrandName);
            this.grbform.Controls.Add(this.txtTLabelName);
            this.grbform.Controls.Add(this.txtDEBrandName);
            this.grbform.Controls.Add(this.txtELabelName);
            this.grbform.Controls.Add(this.btnClose);
            this.grbform.Controls.Add(this.btnSave);
            this.grbform.Controls.Add(this.txtTBrandName);
            this.grbform.Controls.Add(this.txtEBrandName);
            this.grbform.Location = new System.Drawing.Point(18, 14);
            this.grbform.Name = "grbform";
            this.grbform.Size = new System.Drawing.Size(638, 200);
            this.grbform.TabIndex = 28;
            this.grbform.TabStop = false;
            // 
            // txtDTLabelName
            // 
            this.txtDTLabelName.BackColor = System.Drawing.SystemColors.Control;
            this.txtDTLabelName.Enabled = false;
            this.txtDTLabelName.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDTLabelName.Location = new System.Drawing.Point(44, 111);
            this.txtDTLabelName.Name = "txtDTLabelName";
            this.txtDTLabelName.ReadOnly = true;
            this.txtDTLabelName.Size = new System.Drawing.Size(181, 27);
            this.txtDTLabelName.TabIndex = 8;
            this.txtDTLabelName.Text = "Label Name in Tamil";
            // 
            // txtDELabelName
            // 
            this.txtDELabelName.BackColor = System.Drawing.SystemColors.Control;
            this.txtDELabelName.Enabled = false;
            this.txtDELabelName.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDELabelName.Location = new System.Drawing.Point(44, 84);
            this.txtDELabelName.Name = "txtDELabelName";
            this.txtDELabelName.ReadOnly = true;
            this.txtDELabelName.Size = new System.Drawing.Size(181, 27);
            this.txtDELabelName.TabIndex = 9;
            this.txtDELabelName.Text = "Label Name in English";
            // 
            // txtTLabelName
            // 
            this.txtTLabelName.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTLabelName.Location = new System.Drawing.Point(225, 111);
            this.txtTLabelName.MaxLength = 100;
            this.txtTLabelName.Name = "txtTLabelName";
            this.txtTLabelName.Size = new System.Drawing.Size(370, 27);
            this.txtTLabelName.TabIndex = 3;
            this.txtTLabelName.Enter += new System.EventHandler(this.txtTLabelName_Enter);
            this.txtTLabelName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTLabelName_KeyDown);
            this.txtTLabelName.Leave += new System.EventHandler(this.txtTLabelName_Leave);
            // 
            // txtELabelName
            // 
            this.txtELabelName.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtELabelName.Location = new System.Drawing.Point(225, 84);
            this.txtELabelName.MaxLength = 50;
            this.txtELabelName.Name = "txtELabelName";
            this.txtELabelName.Size = new System.Drawing.Size(370, 27);
            this.txtELabelName.TabIndex = 2;
            this.txtELabelName.Enter += new System.EventHandler(this.txtELabelName_Enter);
            this.txtELabelName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtELabelName_KeyDown);
            this.txtELabelName.Leave += new System.EventHandler(this.txtELabelName_Leave);
            // 
            // errBrand
            // 
            this.errBrand.ContainerControl = this;
            // 
            // CP_Brand
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(675, 228);
            this.Controls.Add(this.grbform);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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

        private System.Windows.Forms.TextBox txtDTBrandName;
        private System.Windows.Forms.TextBox txtTBrandName;
        private System.Windows.Forms.TextBox txtDEBrandName;
        private System.Windows.Forms.TextBox txtEBrandName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox grbform;
        private System.Windows.Forms.TextBox txtDTLabelName;
        private System.Windows.Forms.TextBox txtDELabelName;
        private System.Windows.Forms.TextBox txtTLabelName;
        private System.Windows.Forms.TextBox txtELabelName;
        private System.Windows.Forms.ErrorProvider errBrand;
    }
}