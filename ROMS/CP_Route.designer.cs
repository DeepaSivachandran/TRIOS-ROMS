namespace ROMS
{
    partial class CP_Route
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CP_Route));
            this.txtDRootTName = new System.Windows.Forms.TextBox();
            this.txtDRootEName = new System.Windows.Forms.TextBox();
            this.grbform = new System.Windows.Forms.GroupBox();
            this.cmbRSNo = new System.Windows.Forms.ComboBox();
            this.txtDRouteOrderNo = new System.Windows.Forms.TextBox();
            this.txtRTName = new System.Windows.Forms.TextBox();
            this.txtREName = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.pnlStatus = new System.Windows.Forms.Panel();
            this.rbActive = new System.Windows.Forms.RadioButton();
            this.rbInActive = new System.Windows.Forms.RadioButton();
            this.epRoute = new System.Windows.Forms.ErrorProvider(this.components);
            this.grbform.SuspendLayout();
            this.pnlStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epRoute)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDRootTName
            // 
            this.txtDRootTName.BackColor = System.Drawing.SystemColors.Control;
            this.txtDRootTName.Enabled = false;
            this.txtDRootTName.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDRootTName.Location = new System.Drawing.Point(6, 58);
            this.txtDRootTName.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtDRootTName.Name = "txtDRootTName";
            this.txtDRootTName.ReadOnly = true;
            this.txtDRootTName.Size = new System.Drawing.Size(122, 28);
            this.txtDRootTName.TabIndex = 6;
            this.txtDRootTName.Text = "Route Tamil Name";
            // 
            // txtDRootEName
            // 
            this.txtDRootEName.BackColor = System.Drawing.SystemColors.Control;
            this.txtDRootEName.Enabled = false;
            this.txtDRootEName.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDRootEName.Location = new System.Drawing.Point(6, 30);
            this.txtDRootEName.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtDRootEName.Name = "txtDRootEName";
            this.txtDRootEName.ReadOnly = true;
            this.txtDRootEName.Size = new System.Drawing.Size(122, 28);
            this.txtDRootEName.TabIndex = 7;
            this.txtDRootEName.Text = "Route English Name";
            // 
            // grbform
            // 
            this.grbform.Controls.Add(this.cmbRSNo);
            this.grbform.Controls.Add(this.txtDRouteOrderNo);
            this.grbform.Controls.Add(this.txtRTName);
            this.grbform.Controls.Add(this.txtREName);
            this.grbform.Controls.Add(this.btnClose);
            this.grbform.Controls.Add(this.btnSave);
            this.grbform.Controls.Add(this.txtStatus);
            this.grbform.Controls.Add(this.txtDRootTName);
            this.grbform.Controls.Add(this.txtDRootEName);
            this.grbform.Controls.Add(this.pnlStatus);
            this.grbform.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.grbform.Location = new System.Drawing.Point(6, 1);
            this.grbform.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.grbform.Name = "grbform";
            this.grbform.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.grbform.Size = new System.Drawing.Size(379, 195);
            this.grbform.TabIndex = 28;
            this.grbform.TabStop = false;
            // 
            // cmbRSNo
            // 
            this.cmbRSNo.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRSNo.FormattingEnabled = true;
            this.cmbRSNo.Location = new System.Drawing.Point(128, 86);
            this.cmbRSNo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbRSNo.Name = "cmbRSNo";
            this.cmbRSNo.Size = new System.Drawing.Size(67, 27);
            this.cmbRSNo.TabIndex = 2;
            this.cmbRSNo.Enter += new System.EventHandler(this.cmbRSNo_Enter);
            this.cmbRSNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbRSNo_KeyDown);
            this.cmbRSNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbRSNo_KeyPress);
            this.cmbRSNo.Leave += new System.EventHandler(this.cmbRSNo_Leave);
            // 
            // txtDRouteOrderNo
            // 
            this.txtDRouteOrderNo.BackColor = System.Drawing.SystemColors.Control;
            this.txtDRouteOrderNo.Enabled = false;
            this.txtDRouteOrderNo.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDRouteOrderNo.Location = new System.Drawing.Point(6, 86);
            this.txtDRouteOrderNo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDRouteOrderNo.Name = "txtDRouteOrderNo";
            this.txtDRouteOrderNo.ReadOnly = true;
            this.txtDRouteOrderNo.Size = new System.Drawing.Size(122, 27);
            this.txtDRouteOrderNo.TabIndex = 1111146;
            this.txtDRouteOrderNo.Text = "Route Order No";
            // 
            // txtRTName
            // 
            this.txtRTName.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 12F);
            this.txtRTName.Location = new System.Drawing.Point(128, 58);
            this.txtRTName.MaxLength = 100;
            this.txtRTName.Name = "txtRTName";
            this.txtRTName.Size = new System.Drawing.Size(240, 27);
            this.txtRTName.TabIndex = 1;
            this.txtRTName.Enter += new System.EventHandler(this.txtRTName_Enter);
            this.txtRTName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRTName_KeyDown);
            this.txtRTName.Leave += new System.EventHandler(this.txtRTName_Leave);
            // 
            // txtREName
            // 
            this.txtREName.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtREName.Location = new System.Drawing.Point(128, 30);
            this.txtREName.MaxLength = 100;
            this.txtREName.Name = "txtREName";
            this.txtREName.Size = new System.Drawing.Size(240, 28);
            this.txtREName.TabIndex = 0;
            this.txtREName.Enter += new System.EventHandler(this.txtREName_Enter);
            this.txtREName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtREName_KeyDown);
            this.txtREName.Leave += new System.EventHandler(this.txtREName_Leave);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::ROMS.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(288, 152);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 33);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            this.btnClose.Enter += new System.EventHandler(this.btnClose_Enter);
            this.btnClose.Leave += new System.EventHandler(this.btnClose_Leave);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::ROMS.Properties.Resources.save;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(202, 152);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 33);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.Enter += new System.EventHandler(this.btnSave_Enter);
            this.btnSave.Leave += new System.EventHandler(this.btnSave_Leave);
            // 
            // txtStatus
            // 
            this.txtStatus.BackColor = System.Drawing.SystemColors.Control;
            this.txtStatus.Enabled = false;
            this.txtStatus.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStatus.Location = new System.Drawing.Point(6, 113);
            this.txtStatus.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(122, 28);
            this.txtStatus.TabIndex = 8;
            this.txtStatus.Text = "Status";
            // 
            // pnlStatus
            // 
            this.pnlStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlStatus.Controls.Add(this.rbActive);
            this.pnlStatus.Controls.Add(this.rbInActive);
            this.pnlStatus.Location = new System.Drawing.Point(128, 113);
            this.pnlStatus.Name = "pnlStatus";
            this.pnlStatus.Size = new System.Drawing.Size(240, 28);
            this.pnlStatus.TabIndex = 3;
            // 
            // rbActive
            // 
            this.rbActive.AutoSize = true;
            this.rbActive.Checked = true;
            this.rbActive.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbActive.Location = new System.Drawing.Point(39, 1);
            this.rbActive.Name = "rbActive";
            this.rbActive.Size = new System.Drawing.Size(60, 24);
            this.rbActive.TabIndex = 3;
            this.rbActive.TabStop = true;
            this.rbActive.Text = "Active";
            this.rbActive.UseVisualStyleBackColor = true;
            this.rbActive.Enter += new System.EventHandler(this.RbActive_Enter);
            this.rbActive.Leave += new System.EventHandler(this.RbActive_Leave);
            // 
            // rbInActive
            // 
            this.rbInActive.AutoSize = true;
            this.rbInActive.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbInActive.Location = new System.Drawing.Point(117, 1);
            this.rbInActive.Name = "rbInActive";
            this.rbInActive.Size = new System.Drawing.Size(70, 24);
            this.rbInActive.TabIndex = 4;
            this.rbInActive.Text = "Inactive";
            this.rbInActive.UseVisualStyleBackColor = true;
            this.rbInActive.Enter += new System.EventHandler(this.RbInActive_Enter);
            this.rbInActive.Leave += new System.EventHandler(this.RbInActive_Leave);
            // 
            // epRoute
            // 
            this.epRoute.ContainerControl = this;
            // 
            // CP_Route
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(399, 210);
            this.Controls.Add(this.grbform);
            this.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CP_Route";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Route Details";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CP_Route_FormClosing);
            this.Load += new System.EventHandler(this.CP_Route_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CP_Route_KeyDown);
            this.Leave += new System.EventHandler(this.CP_Route_Leave);
            this.grbform.ResumeLayout(false);
            this.grbform.PerformLayout();
            this.pnlStatus.ResumeLayout(false);
            this.pnlStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epRoute)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtDRootTName;
        private System.Windows.Forms.TextBox txtDRootEName;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox grbform;
        private System.Windows.Forms.ErrorProvider epRoute;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.RadioButton rbInActive;
        private System.Windows.Forms.RadioButton rbActive;
        private System.Windows.Forms.Panel pnlStatus;
        public System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtREName;
        private System.Windows.Forms.TextBox txtRTName;
        private System.Windows.Forms.ComboBox cmbRSNo;
        private System.Windows.Forms.TextBox txtDRouteOrderNo;
    }
}