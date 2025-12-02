namespace ROMS
{
    partial class CP_Rack
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CP_Rack));
            this.grbform = new System.Windows.Forms.GroupBox();
            this.DGV_FilterLocation = new System.Windows.Forms.DataGridView();
            this.chkSalesBillPrint = new System.Windows.Forms.CheckBox();
            this.lblLocationCode = new System.Windows.Forms.Label();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.txtDDescription = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtStockLocation = new System.Windows.Forms.TextBox();
            this.cmbConcern = new System.Windows.Forms.ComboBox();
            this.txtDConcern = new System.Windows.Forms.TextBox();
            this.txtDShortName = new System.Windows.Forms.TextBox();
            this.txtShortName = new System.Windows.Forms.TextBox();
            this.txtDStatus = new System.Windows.Forms.TextBox();
            this.pnlStatus = new System.Windows.Forms.Panel();
            this.rbInactive = new System.Windows.Forms.RadioButton();
            this.rbActive = new System.Windows.Forms.RadioButton();
            this.txtDRackName = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtRackName = new System.Windows.Forms.TextBox();
            this.epRack = new System.Windows.Forms.ErrorProvider(this.components);
            this.grbform.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_FilterLocation)).BeginInit();
            this.pnlStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epRack)).BeginInit();
            this.SuspendLayout();
            // 
            // grbform
            // 
            this.grbform.Controls.Add(this.chkSalesBillPrint);
            this.grbform.Controls.Add(this.lblLocationCode);
            this.grbform.Controls.Add(this.txtLocation);
            this.grbform.Controls.Add(this.txtDDescription);
            this.grbform.Controls.Add(this.txtDescription);
            this.grbform.Controls.Add(this.txtStockLocation);
            this.grbform.Controls.Add(this.cmbConcern);
            this.grbform.Controls.Add(this.txtDConcern);
            this.grbform.Controls.Add(this.txtDShortName);
            this.grbform.Controls.Add(this.txtShortName);
            this.grbform.Controls.Add(this.txtDStatus);
            this.grbform.Controls.Add(this.pnlStatus);
            this.grbform.Controls.Add(this.txtDRackName);
            this.grbform.Controls.Add(this.btnClose);
            this.grbform.Controls.Add(this.btnSave);
            this.grbform.Controls.Add(this.txtRackName);
            this.grbform.Controls.Add(this.DGV_FilterLocation);
            this.grbform.Location = new System.Drawing.Point(16, 10);
            this.grbform.Name = "grbform";
            this.grbform.Size = new System.Drawing.Size(552, 272);
            this.grbform.TabIndex = 0;
            this.grbform.TabStop = false;
            // 
            // DGV_FilterLocation
            // 
            this.DGV_FilterLocation.AllowUserToAddRows = false;
            this.DGV_FilterLocation.AllowUserToDeleteRows = false;
            this.DGV_FilterLocation.AllowUserToResizeColumns = false;
            this.DGV_FilterLocation.AllowUserToResizeRows = false;
            this.DGV_FilterLocation.BackgroundColor = System.Drawing.Color.White;
            this.DGV_FilterLocation.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Chocolate;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Chocolate;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_FilterLocation.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DGV_FilterLocation.ColumnHeadersHeight = 30;
            this.DGV_FilterLocation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV_FilterLocation.DefaultCellStyle = dataGridViewCellStyle2;
            this.DGV_FilterLocation.EnableHeadersVisualStyles = false;
            this.DGV_FilterLocation.GridColor = System.Drawing.Color.White;
            this.DGV_FilterLocation.Location = new System.Drawing.Point(221, 85);
            this.DGV_FilterLocation.Name = "DGV_FilterLocation";
            this.DGV_FilterLocation.ReadOnly = true;
            this.DGV_FilterLocation.RowHeadersVisible = false;
            this.DGV_FilterLocation.RowHeadersWidth = 51;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.DGV_FilterLocation.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.DGV_FilterLocation.RowTemplate.Height = 25;
            this.DGV_FilterLocation.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV_FilterLocation.Size = new System.Drawing.Size(304, 116);
            this.DGV_FilterLocation.TabIndex = 111111172;
            this.DGV_FilterLocation.Visible = false;
            this.DGV_FilterLocation.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_FilterLocation_CellDoubleClick);
            this.DGV_FilterLocation.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DGV_FilterLocation_KeyDown);
            // 
            // chkSalesBillPrint
            // 
            this.chkSalesBillPrint.AutoSize = true;
            this.chkSalesBillPrint.Location = new System.Drawing.Point(221, 204);
            this.chkSalesBillPrint.Name = "chkSalesBillPrint";
            this.chkSalesBillPrint.Size = new System.Drawing.Size(179, 24);
            this.chkSalesBillPrint.TabIndex = 8;
            this.chkSalesBillPrint.Text = "Print Seperately in Sales Bill";
            this.chkSalesBillPrint.UseVisualStyleBackColor = true;
            this.chkSalesBillPrint.Enter += new System.EventHandler(this.chkSalesBillPrint_Enter);
            this.chkSalesBillPrint.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chkSalesBillPrint_KeyDown);
            this.chkSalesBillPrint.Leave += new System.EventHandler(this.chkSalesBillPrint_Leave);
            // 
            // lblLocationCode
            // 
            this.lblLocationCode.AutoSize = true;
            this.lblLocationCode.Location = new System.Drawing.Point(18, 60);
            this.lblLocationCode.Name = "lblLocationCode";
            this.lblLocationCode.Size = new System.Drawing.Size(0, 20);
            this.lblLocationCode.TabIndex = 1111147;
            this.lblLocationCode.Visible = false;
            // 
            // txtLocation
            // 
            this.txtLocation.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtLocation.Location = new System.Drawing.Point(221, 58);
            this.txtLocation.MaxLength = 100;
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(288, 27);
            this.txtLocation.TabIndex = 1;
            this.txtLocation.TextChanged += new System.EventHandler(this.TxtLocation_TextChanged);
            this.txtLocation.Enter += new System.EventHandler(this.TxtLocation_Enter);
            this.txtLocation.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtLocation_KeyDown);
            this.txtLocation.Leave += new System.EventHandler(this.TxtLocation_Leave);
            // 
            // txtDDescription
            // 
            this.txtDDescription.BackColor = System.Drawing.SystemColors.Control;
            this.txtDDescription.Enabled = false;
            this.txtDDescription.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDDescription.Location = new System.Drawing.Point(40, 139);
            this.txtDDescription.Name = "txtDDescription";
            this.txtDDescription.ReadOnly = true;
            this.txtDDescription.Size = new System.Drawing.Size(181, 27);
            this.txtDDescription.TabIndex = 25;
            this.txtDDescription.Text = "Description";
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(221, 139);
            this.txtDescription.MaxLength = 100;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(288, 27);
            this.txtDescription.TabIndex = 4;
            this.txtDescription.Enter += new System.EventHandler(this.TxtDescription_Enter);
            this.txtDescription.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtDescription_KeyDown);
            this.txtDescription.Leave += new System.EventHandler(this.TxtDescription_Leave);
            // 
            // txtStockLocation
            // 
            this.txtStockLocation.BackColor = System.Drawing.SystemColors.Control;
            this.txtStockLocation.Enabled = false;
            this.txtStockLocation.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStockLocation.Location = new System.Drawing.Point(40, 58);
            this.txtStockLocation.Name = "txtStockLocation";
            this.txtStockLocation.ReadOnly = true;
            this.txtStockLocation.Size = new System.Drawing.Size(181, 27);
            this.txtStockLocation.TabIndex = 22;
            this.txtStockLocation.Text = "Stock Location";
            // 
            // cmbConcern
            // 
            this.cmbConcern.FormattingEnabled = true;
            this.cmbConcern.Location = new System.Drawing.Point(221, 31);
            this.cmbConcern.Name = "cmbConcern";
            this.cmbConcern.Size = new System.Drawing.Size(288, 27);
            this.cmbConcern.TabIndex = 0;
            this.cmbConcern.Enter += new System.EventHandler(this.CmbConcern_Enter);
            this.cmbConcern.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbConcern_KeyDown);
            this.cmbConcern.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbConcern_KeyPress);
            this.cmbConcern.Leave += new System.EventHandler(this.CmbConcern_Leave);
            // 
            // txtDConcern
            // 
            this.txtDConcern.BackColor = System.Drawing.SystemColors.Control;
            this.txtDConcern.Enabled = false;
            this.txtDConcern.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDConcern.Location = new System.Drawing.Point(40, 31);
            this.txtDConcern.Name = "txtDConcern";
            this.txtDConcern.ReadOnly = true;
            this.txtDConcern.Size = new System.Drawing.Size(181, 27);
            this.txtDConcern.TabIndex = 20;
            this.txtDConcern.Text = "Concern";
            // 
            // txtDShortName
            // 
            this.txtDShortName.BackColor = System.Drawing.SystemColors.Control;
            this.txtDShortName.Enabled = false;
            this.txtDShortName.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDShortName.Location = new System.Drawing.Point(40, 112);
            this.txtDShortName.Name = "txtDShortName";
            this.txtDShortName.ReadOnly = true;
            this.txtDShortName.Size = new System.Drawing.Size(181, 27);
            this.txtDShortName.TabIndex = 19;
            this.txtDShortName.Text = "Short Name";
            // 
            // txtShortName
            // 
            this.txtShortName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtShortName.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtShortName.Location = new System.Drawing.Point(221, 112);
            this.txtShortName.MaxLength = 10;
            this.txtShortName.Name = "txtShortName";
            this.txtShortName.Size = new System.Drawing.Size(288, 27);
            this.txtShortName.TabIndex = 3;
            this.txtShortName.Enter += new System.EventHandler(this.TxtShortName_Enter);
            this.txtShortName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtShortName_KeyDown);
            this.txtShortName.Leave += new System.EventHandler(this.TxtShortName_Leave);
            // 
            // txtDStatus
            // 
            this.txtDStatus.BackColor = System.Drawing.SystemColors.Control;
            this.txtDStatus.Enabled = false;
            this.txtDStatus.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDStatus.Location = new System.Drawing.Point(40, 166);
            this.txtDStatus.Name = "txtDStatus";
            this.txtDStatus.ReadOnly = true;
            this.txtDStatus.Size = new System.Drawing.Size(181, 27);
            this.txtDStatus.TabIndex = 17;
            this.txtDStatus.Text = "Status";
            // 
            // pnlStatus
            // 
            this.pnlStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlStatus.Controls.Add(this.rbInactive);
            this.pnlStatus.Controls.Add(this.rbActive);
            this.pnlStatus.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlStatus.Location = new System.Drawing.Point(221, 166);
            this.pnlStatus.Name = "pnlStatus";
            this.pnlStatus.Size = new System.Drawing.Size(288, 27);
            this.pnlStatus.TabIndex = 5;
            // 
            // rbInactive
            // 
            this.rbInactive.AutoSize = true;
            this.rbInactive.Font = new System.Drawing.Font("Oswald Regular", 9.75F);
            this.rbInactive.Location = new System.Drawing.Point(150, 1);
            this.rbInactive.Name = "rbInactive";
            this.rbInactive.Size = new System.Drawing.Size(63, 21);
            this.rbInactive.TabIndex = 7;
            this.rbInactive.Text = "Inactive";
            this.rbInactive.UseVisualStyleBackColor = true;
            this.rbInactive.Enter += new System.EventHandler(this.RbInactive_Enter);
            this.rbInactive.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RbInactive_KeyDown);
            this.rbInactive.Leave += new System.EventHandler(this.RbInactive_Leave);
            // 
            // rbActive
            // 
            this.rbActive.AutoSize = true;
            this.rbActive.Checked = true;
            this.rbActive.Font = new System.Drawing.Font("Oswald Regular", 9.75F);
            this.rbActive.Location = new System.Drawing.Point(62, 1);
            this.rbActive.Name = "rbActive";
            this.rbActive.Size = new System.Drawing.Size(54, 21);
            this.rbActive.TabIndex = 6;
            this.rbActive.TabStop = true;
            this.rbActive.Text = "Active";
            this.rbActive.UseVisualStyleBackColor = true;
            this.rbActive.Enter += new System.EventHandler(this.RbActive_Enter);
            this.rbActive.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RbActive_KeyDown);
            this.rbActive.Leave += new System.EventHandler(this.RbActive_Leave);
            // 
            // txtDRackName
            // 
            this.txtDRackName.BackColor = System.Drawing.SystemColors.Control;
            this.txtDRackName.Enabled = false;
            this.txtDRackName.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDRackName.Location = new System.Drawing.Point(40, 85);
            this.txtDRackName.Name = "txtDRackName";
            this.txtDRackName.ReadOnly = true;
            this.txtDRackName.Size = new System.Drawing.Size(181, 27);
            this.txtDRackName.TabIndex = 11;
            this.txtDRackName.Text = "Rack Name";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnClose.Image = global::ROMS.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(434, 233);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 29);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            this.btnClose.Enter += new System.EventHandler(this.btnClose_Enter);
            this.btnClose.Leave += new System.EventHandler(this.btnClose_Leave);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnSave.Image = global::ROMS.Properties.Resources.save;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(344, 233);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(84, 29);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.Enter += new System.EventHandler(this.btnSave_Enter);
            this.btnSave.Leave += new System.EventHandler(this.btnSave_Leave);
            // 
            // txtRackName
            // 
            this.txtRackName.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRackName.Location = new System.Drawing.Point(221, 85);
            this.txtRackName.MaxLength = 50;
            this.txtRackName.Name = "txtRackName";
            this.txtRackName.Size = new System.Drawing.Size(288, 27);
            this.txtRackName.TabIndex = 2;
            this.txtRackName.Enter += new System.EventHandler(this.TxtRackName_Enter);
            this.txtRackName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtRackName_KeyDown);
            this.txtRackName.Leave += new System.EventHandler(this.TxtRackName_Leave);
            // 
            // epRack
            // 
            this.epRack.ContainerControl = this;
            // 
            // CP_Rack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(585, 292);
            this.Controls.Add(this.grbform);
            this.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CP_Rack";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rack";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CP_Rack_FormClosing);
            this.Load += new System.EventHandler(this.CP_Rack_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CP_Rack_KeyDown);
            this.Leave += new System.EventHandler(this.CP_Rack_Leave);
            this.grbform.ResumeLayout(false);
            this.grbform.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_FilterLocation)).EndInit();
            this.pnlStatus.ResumeLayout(false);
            this.pnlStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epRack)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox grbform;
        private System.Windows.Forms.TextBox txtDRackName;
        private System.Windows.Forms.TextBox txtRackName;
        private System.Windows.Forms.ErrorProvider epRack;
        private System.Windows.Forms.TextBox txtDStatus;
        private System.Windows.Forms.Panel pnlStatus;
        private System.Windows.Forms.RadioButton rbInactive;
        private System.Windows.Forms.RadioButton rbActive;
        private System.Windows.Forms.TextBox txtDShortName;
        private System.Windows.Forms.TextBox txtShortName;
        private System.Windows.Forms.TextBox txtStockLocation;
        private System.Windows.Forms.TextBox txtDConcern;
        private System.Windows.Forms.TextBox txtDDescription;
        private System.Windows.Forms.TextBox txtDescription;
        public System.Windows.Forms.Button btnSave;
        public System.Windows.Forms.ComboBox cmbConcern;
        public System.Windows.Forms.TextBox txtLocation;
        public System.Windows.Forms.Label lblLocationCode;
        public System.Windows.Forms.DataGridView DGV_FilterLocation;
        private System.Windows.Forms.CheckBox chkSalesBillPrint;
    }
}