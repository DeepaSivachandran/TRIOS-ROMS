namespace ROMS
{
    partial class CP_BatchNoConfiguration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CP_BatchNoConfiguration));
            this.txtProductGroup = new System.Windows.Forms.TextBox();
            this.grbform = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.errUnit = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtProductSubGroup = new System.Windows.Forms.TextBox();
            this.cmbproductgroup = new System.Windows.Forms.ComboBox();
            this.cbproductsubgroup = new System.Windows.Forms.ComboBox();
            this.cbBatchNoRequired = new System.Windows.Forms.CheckBox();
            this.grbform.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errUnit)).BeginInit();
            this.SuspendLayout();
            // 
            // txtProductGroup
            // 
            this.txtProductGroup.BackColor = System.Drawing.SystemColors.Control;
            this.txtProductGroup.Enabled = false;
            this.txtProductGroup.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductGroup.Location = new System.Drawing.Point(60, 53);
            this.txtProductGroup.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtProductGroup.Name = "txtProductGroup";
            this.txtProductGroup.ReadOnly = true;
            this.txtProductGroup.Size = new System.Drawing.Size(145, 28);
            this.txtProductGroup.TabIndex = 7;
            this.txtProductGroup.Text = "Product Group";
            this.txtProductGroup.TextChanged += new System.EventHandler(this.TxtDEBrandName_TextChanged);
            // 
            // grbform
            // 
            this.grbform.Controls.Add(this.cbBatchNoRequired);
            this.grbform.Controls.Add(this.cbproductsubgroup);
            this.grbform.Controls.Add(this.cmbproductgroup);
            this.grbform.Controls.Add(this.txtProductSubGroup);
            this.grbform.Controls.Add(this.btnClose);
            this.grbform.Controls.Add(this.btnSave);
            this.grbform.Controls.Add(this.txtProductGroup);
            this.grbform.Location = new System.Drawing.Point(13, 14);
            this.grbform.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.grbform.Name = "grbform";
            this.grbform.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.grbform.Size = new System.Drawing.Size(558, 215);
            this.grbform.TabIndex = 28;
            this.grbform.TabStop = false;
            this.grbform.Enter += new System.EventHandler(this.Grbform_Enter);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::ROMS.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(465, 155);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(74, 33);
            this.btnClose.TabIndex = 5;
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
            this.btnSave.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::ROMS.Properties.Resources.save;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(384, 155);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(74, 33);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.Enter += new System.EventHandler(this.btnSave_Enter);
            this.btnSave.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnSave_KeyDown);
            this.btnSave.Leave += new System.EventHandler(this.btnSave_Leave);
            // 
            // errUnit
            // 
            this.errUnit.ContainerControl = this;
            // 
            // txtProductSubGroup
            // 
            this.txtProductSubGroup.BackColor = System.Drawing.SystemColors.Control;
            this.txtProductSubGroup.Enabled = false;
            this.txtProductSubGroup.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductSubGroup.Location = new System.Drawing.Point(60, 81);
            this.txtProductSubGroup.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtProductSubGroup.Name = "txtProductSubGroup";
            this.txtProductSubGroup.ReadOnly = true;
            this.txtProductSubGroup.Size = new System.Drawing.Size(145, 28);
            this.txtProductSubGroup.TabIndex = 8;
            this.txtProductSubGroup.Text = "Product Sub Group";
            // 
            // cmbproductgroup
            // 
            this.cmbproductgroup.FormattingEnabled = true;
            this.cmbproductgroup.Location = new System.Drawing.Point(205, 53);
            this.cmbproductgroup.Name = "cmbproductgroup";
            this.cmbproductgroup.Size = new System.Drawing.Size(255, 28);
            this.cmbproductgroup.TabIndex = 9;
            // 
            // cbproductsubgroup
            // 
            this.cbproductsubgroup.FormattingEnabled = true;
            this.cbproductsubgroup.Location = new System.Drawing.Point(205, 81);
            this.cbproductsubgroup.Name = "cbproductsubgroup";
            this.cbproductsubgroup.Size = new System.Drawing.Size(255, 28);
            this.cbproductsubgroup.TabIndex = 10;
            // 
            // cbBatchNoRequired
            // 
            this.cbBatchNoRequired.AutoSize = true;
            this.cbBatchNoRequired.Location = new System.Drawing.Point(208, 113);
            this.cbBatchNoRequired.Name = "cbBatchNoRequired";
            this.cbBatchNoRequired.Size = new System.Drawing.Size(129, 24);
            this.cbBatchNoRequired.TabIndex = 11;
            this.cbBatchNoRequired.Text = "Batch No.Required";
            this.cbBatchNoRequired.UseVisualStyleBackColor = true;
            // 
            // CP_BatchNoConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(585, 251);
            this.Controls.Add(this.grbform);
            this.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CP_BatchNoConfiguration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Batch No.Configuration";
            this.Load += new System.EventHandler(this.CP_Brand_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CP_Brand_KeyDown);
            this.Leave += new System.EventHandler(this.CP_Brand_Leave);
            this.grbform.ResumeLayout(false);
            this.grbform.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errUnit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txtProductGroup;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox grbform;
        private System.Windows.Forms.ErrorProvider errUnit;
        private System.Windows.Forms.CheckBox cbBatchNoRequired;
        private System.Windows.Forms.ComboBox cbproductsubgroup;
        private System.Windows.Forms.ComboBox cmbproductgroup;
        private System.Windows.Forms.TextBox txtProductSubGroup;
    }
}