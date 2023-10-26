namespace ROMS
{
    partial class PUR_BulkUnit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PUR_BulkUnit));
            this.errNewProduct = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtDProductName = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblUnitCode = new System.Windows.Forms.Label();
            this.txtUnittype = new System.Windows.Forms.TextBox();
            this.txtUpp = new System.Windows.Forms.TextBox();
            this.txtDUPP = new System.Windows.Forms.TextBox();
            this.cmbUnit = new System.Windows.Forms.ComboBox();
            this.txtDUnit = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.errNewProduct)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // errNewProduct
            // 
            this.errNewProduct.ContainerControl = this;
            // 
            // txtDProductName
            // 
            this.txtDProductName.Enabled = false;
            this.txtDProductName.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDProductName.Location = new System.Drawing.Point(113, 20);
            this.txtDProductName.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtDProductName.MaxLength = 50;
            this.txtDProductName.Name = "txtDProductName";
            this.txtDProductName.ReadOnly = true;
            this.txtDProductName.Size = new System.Drawing.Size(333, 28);
            this.txtDProductName.TabIndex = 8;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnClose.Image = global::ROMS.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(371, 84);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 29);
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            this.btnClose.Enter += new System.EventHandler(this.BtnClose_Enter);
            this.btnClose.Leave += new System.EventHandler(this.BtnClose_Leave);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnUpdate.Image = global::ROMS.Properties.Resources.save;
            this.btnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdate.Location = new System.Drawing.Point(283, 84);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(84, 29);
            this.btnUpdate.TabIndex = 10;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.BtnUpdate_Click);
            this.btnUpdate.Enter += new System.EventHandler(this.BtnSave_Enter);
            this.btnUpdate.Leave += new System.EventHandler(this.BtnSave_Leave);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblUnitCode);
            this.groupBox1.Controls.Add(this.txtUnittype);
            this.groupBox1.Controls.Add(this.txtUpp);
            this.groupBox1.Controls.Add(this.txtDUPP);
            this.groupBox1.Controls.Add(this.cmbUnit);
            this.groupBox1.Controls.Add(this.txtDUnit);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Controls.Add(this.txtDProductName);
            this.groupBox1.Controls.Add(this.btnUpdate);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(458, 126);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            // 
            // lblUnitCode
            // 
            this.lblUnitCode.AutoSize = true;
            this.lblUnitCode.Location = new System.Drawing.Point(331, 57);
            this.lblUnitCode.Name = "lblUnitCode";
            this.lblUnitCode.Size = new System.Drawing.Size(16, 20);
            this.lblUnitCode.TabIndex = 124;
            this.lblUnitCode.Text = "0";
            this.lblUnitCode.Visible = false;
            // 
            // txtUnittype
            // 
            this.txtUnittype.BackColor = System.Drawing.SystemColors.Control;
            this.txtUnittype.Enabled = false;
            this.txtUnittype.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtUnittype.Location = new System.Drawing.Point(282, 48);
            this.txtUnittype.Name = "txtUnittype";
            this.txtUnittype.ReadOnly = true;
            this.txtUnittype.Size = new System.Drawing.Size(28, 27);
            this.txtUnittype.TabIndex = 123;
            this.txtUnittype.Text = "Pkt";
            // 
            // txtUpp
            // 
            this.txtUpp.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtUpp.Location = new System.Drawing.Point(238, 48);
            this.txtUpp.MaxLength = 5;
            this.txtUpp.Name = "txtUpp";
            this.txtUpp.Size = new System.Drawing.Size(44, 27);
            this.txtUpp.TabIndex = 122;
            this.txtUpp.Enter += new System.EventHandler(this.TxtUpp_Enter);
            this.txtUpp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtUpp_KeyDown);
            this.txtUpp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtUpp_KeyPress);
            this.txtUpp.Leave += new System.EventHandler(this.TxtUpp_Leave);
            // 
            // txtDUPP
            // 
            this.txtDUPP.BackColor = System.Drawing.SystemColors.Control;
            this.txtDUPP.Enabled = false;
            this.txtDUPP.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtDUPP.Location = new System.Drawing.Point(201, 48);
            this.txtDUPP.Name = "txtDUPP";
            this.txtDUPP.ReadOnly = true;
            this.txtDUPP.Size = new System.Drawing.Size(37, 27);
            this.txtDUPP.TabIndex = 121;
            this.txtDUPP.TabStop = false;
            this.txtDUPP.Text = "UPP";
            // 
            // cmbUnit
            // 
            this.cmbUnit.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbUnit.FormattingEnabled = true;
            this.cmbUnit.Location = new System.Drawing.Point(113, 48);
            this.cmbUnit.Name = "cmbUnit";
            this.cmbUnit.Size = new System.Drawing.Size(88, 27);
            this.cmbUnit.TabIndex = 120;
            this.cmbUnit.SelectedIndexChanged += new System.EventHandler(this.CmbUnit_SelectedIndexChanged);
            this.cmbUnit.Enter += new System.EventHandler(this.CmbUnit_Enter);
            this.cmbUnit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbUnit_KeyDown);
            this.cmbUnit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbUnit_KeyPress);
            this.cmbUnit.Leave += new System.EventHandler(this.CmbUnit_Leave);
            // 
            // txtDUnit
            // 
            this.txtDUnit.BackColor = System.Drawing.SystemColors.Control;
            this.txtDUnit.Enabled = false;
            this.txtDUnit.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtDUnit.Location = new System.Drawing.Point(14, 48);
            this.txtDUnit.Name = "txtDUnit";
            this.txtDUnit.ReadOnly = true;
            this.txtDUnit.Size = new System.Drawing.Size(99, 27);
            this.txtDUnit.TabIndex = 119;
            this.txtDUnit.TabStop = false;
            this.txtDUnit.Text = "Bulk Unit";
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(14, 20);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.textBox1.MaxLength = 50;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(99, 28);
            this.textBox1.TabIndex = 12;
            this.textBox1.Text = "Product Name";
            // 
            // PUR_BulkUnit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(482, 147);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PUR_BulkUnit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Map Bulk Unit";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PUR_BulkUnit_FormClosing);
            this.Load += new System.EventHandler(this.PUR_BulkUnit_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PUR_BulkUnit_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.errNewProduct)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ErrorProvider errNewProduct;
        private System.Windows.Forms.TextBox txtDProductName;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox txtUnittype;
        private System.Windows.Forms.TextBox txtUpp;
        private System.Windows.Forms.TextBox txtDUPP;
        private System.Windows.Forms.ComboBox cmbUnit;
        private System.Windows.Forms.TextBox txtDUnit;
        private System.Windows.Forms.Label lblUnitCode;
    }
}