namespace ROMS
{
    partial class CP_Area
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CP_Area));
            this.errArea = new System.Windows.Forms.ErrorProvider(this.components);
            this.grbDetails = new System.Windows.Forms.GroupBox();
            this.txtDistance = new System.Windows.Forms.TextBox();
            this.txtDDistance = new System.Windows.Forms.TextBox();
            this.cmbOrderNo = new System.Windows.Forms.ComboBox();
            this.cmbCity = new System.Windows.Forms.ComboBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.cmbRoute = new System.Windows.Forms.ComboBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.pnlStatus = new System.Windows.Forms.Panel();
            this.rbActive = new System.Windows.Forms.RadioButton();
            this.rbInActive = new System.Windows.Forms.RadioButton();
            this.txtDRouteName = new System.Windows.Forms.TextBox();
            this.txtATName = new System.Windows.Forms.TextBox();
            this.txtAEName = new System.Windows.Forms.TextBox();
            this.txtDAreaTName = new System.Windows.Forms.TextBox();
            this.txtDAreaEName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.errArea)).BeginInit();
            this.grbDetails.SuspendLayout();
            this.pnlStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // errArea
            // 
            this.errArea.ContainerControl = this;
            // 
            // grbDetails
            // 
            this.grbDetails.Controls.Add(this.txtDistance);
            this.grbDetails.Controls.Add(this.txtDDistance);
            this.grbDetails.Controls.Add(this.cmbOrderNo);
            this.grbDetails.Controls.Add(this.cmbCity);
            this.grbDetails.Controls.Add(this.textBox2);
            this.grbDetails.Controls.Add(this.textBox1);
            this.grbDetails.Controls.Add(this.cmbRoute);
            this.grbDetails.Controls.Add(this.btnClose);
            this.grbDetails.Controls.Add(this.btnSave);
            this.grbDetails.Controls.Add(this.txtStatus);
            this.grbDetails.Controls.Add(this.pnlStatus);
            this.grbDetails.Controls.Add(this.txtDRouteName);
            this.grbDetails.Controls.Add(this.txtATName);
            this.grbDetails.Controls.Add(this.txtAEName);
            this.grbDetails.Controls.Add(this.txtDAreaTName);
            this.grbDetails.Controls.Add(this.txtDAreaEName);
            this.grbDetails.Location = new System.Drawing.Point(12, 3);
            this.grbDetails.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbDetails.Name = "grbDetails";
            this.grbDetails.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbDetails.Size = new System.Drawing.Size(388, 275);
            this.grbDetails.TabIndex = 0;
            this.grbDetails.TabStop = false;
            this.grbDetails.Enter += new System.EventHandler(this.grbDetails_Enter);
            // 
            // txtDistance
            // 
            this.txtDistance.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 12F);
            this.txtDistance.Location = new System.Drawing.Point(136, 137);
            this.txtDistance.MaxLength = 8;
            this.txtDistance.Name = "txtDistance";
            this.txtDistance.Size = new System.Drawing.Size(240, 27);
            this.txtDistance.TabIndex = 4;
            this.txtDistance.TextChanged += new System.EventHandler(this.txtDistance_TextChanged);
            this.txtDistance.Enter += new System.EventHandler(this.txtDistance_Enter);
            this.txtDistance.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDistance_KeyDown);
            this.txtDistance.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDistance_KeyPress);
            this.txtDistance.Leave += new System.EventHandler(this.txtDistance_Leave);
            // 
            // txtDDistance
            // 
            this.txtDDistance.BackColor = System.Drawing.SystemColors.Control;
            this.txtDDistance.Enabled = false;
            this.txtDDistance.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDDistance.Location = new System.Drawing.Point(14, 137);
            this.txtDDistance.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtDDistance.Name = "txtDDistance";
            this.txtDDistance.ReadOnly = true;
            this.txtDDistance.Size = new System.Drawing.Size(122, 28);
            this.txtDDistance.TabIndex = 22;
            this.txtDDistance.Text = "Distance";
            this.txtDDistance.TextChanged += new System.EventHandler(this.txtDDistance_TextChanged);
            // 
            // cmbOrderNo
            // 
            this.cmbOrderNo.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbOrderNo.FormattingEnabled = true;
            this.cmbOrderNo.Location = new System.Drawing.Point(136, 109);
            this.cmbOrderNo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbOrderNo.Name = "cmbOrderNo";
            this.cmbOrderNo.Size = new System.Drawing.Size(240, 27);
            this.cmbOrderNo.TabIndex = 3;
            this.cmbOrderNo.SelectedIndexChanged += new System.EventHandler(this.cmbOrderNo_SelectedIndexChanged);
            this.cmbOrderNo.Enter += new System.EventHandler(this.cmbOrderNo_Enter);
            this.cmbOrderNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbOrderNo_KeyDown);
            this.cmbOrderNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbOrderNo_KeyPress);
            this.cmbOrderNo.Leave += new System.EventHandler(this.cmbOrderNo_Leave);
            // 
            // cmbCity
            // 
            this.cmbCity.Enabled = false;
            this.cmbCity.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCity.FormattingEnabled = true;
            this.cmbCity.Location = new System.Drawing.Point(136, 164);
            this.cmbCity.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbCity.Name = "cmbCity";
            this.cmbCity.Size = new System.Drawing.Size(240, 27);
            this.cmbCity.TabIndex = 5;
            this.cmbCity.SelectedIndexChanged += new System.EventHandler(this.cmbCity_SelectedIndexChanged);
            this.cmbCity.Enter += new System.EventHandler(this.cmbCity_Enter);
            this.cmbCity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbCity_KeyDown);
            this.cmbCity.Leave += new System.EventHandler(this.cmbCity_Leave);
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.Control;
            this.textBox2.Enabled = false;
            this.textBox2.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(14, 164);
            this.textBox2.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(122, 28);
            this.textBox2.TabIndex = 20;
            this.textBox2.Text = "City";
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(14, 27);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(122, 28);
            this.textBox1.TabIndex = 19;
            this.textBox1.Text = "Route";
            // 
            // cmbRoute
            // 
            this.cmbRoute.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRoute.FormattingEnabled = true;
            this.cmbRoute.Items.AddRange(new object[] {
            "MDU Road"});
            this.cmbRoute.Location = new System.Drawing.Point(136, 27);
            this.cmbRoute.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbRoute.Name = "cmbRoute";
            this.cmbRoute.Size = new System.Drawing.Size(240, 27);
            this.cmbRoute.TabIndex = 0;
            this.cmbRoute.SelectedIndexChanged += new System.EventHandler(this.cmbRoute_SelectedIndexChanged);
            this.cmbRoute.Enter += new System.EventHandler(this.cmbRoute_Enter);
            this.cmbRoute.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbRoute_KeyDown);
            this.cmbRoute.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbRoute_KeyPress);
            this.cmbRoute.Leave += new System.EventHandler(this.cmbRoute_Leave);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::ROMS.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(296, 228);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 33);
            this.btnClose.TabIndex = 9;
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
            this.btnSave.Location = new System.Drawing.Point(208, 228);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 33);
            this.btnSave.TabIndex = 8;
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
            this.txtStatus.Location = new System.Drawing.Point(14, 191);
            this.txtStatus.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(122, 28);
            this.txtStatus.TabIndex = 15;
            this.txtStatus.Text = "Status";
            this.txtStatus.TextChanged += new System.EventHandler(this.txtStatus_TextChanged);
            // 
            // pnlStatus
            // 
            this.pnlStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlStatus.Controls.Add(this.rbActive);
            this.pnlStatus.Controls.Add(this.rbInActive);
            this.pnlStatus.Location = new System.Drawing.Point(136, 191);
            this.pnlStatus.Name = "pnlStatus";
            this.pnlStatus.Size = new System.Drawing.Size(240, 28);
            this.pnlStatus.TabIndex = 6;
            this.pnlStatus.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlStatus_Paint);
            // 
            // rbActive
            // 
            this.rbActive.AutoSize = true;
            this.rbActive.Checked = true;
            this.rbActive.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbActive.Location = new System.Drawing.Point(39, 1);
            this.rbActive.Name = "rbActive";
            this.rbActive.Size = new System.Drawing.Size(60, 24);
            this.rbActive.TabIndex = 6;
            this.rbActive.TabStop = true;
            this.rbActive.Text = "Active";
            this.rbActive.UseVisualStyleBackColor = true;
            this.rbActive.Enter += new System.EventHandler(this.rbActive_Enter);
            this.rbActive.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rbActive_KeyDown);
            this.rbActive.Leave += new System.EventHandler(this.rbActive_Leave);
            // 
            // rbInActive
            // 
            this.rbInActive.AutoSize = true;
            this.rbInActive.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbInActive.Location = new System.Drawing.Point(117, 1);
            this.rbInActive.Name = "rbInActive";
            this.rbInActive.Size = new System.Drawing.Size(70, 24);
            this.rbInActive.TabIndex = 7;
            this.rbInActive.Text = "Inactive";
            this.rbInActive.UseVisualStyleBackColor = true;
            this.rbInActive.Enter += new System.EventHandler(this.rbInActive_Enter);
            this.rbInActive.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rbInActive_KeyDown);
            this.rbInActive.Leave += new System.EventHandler(this.rbInActive_Leave);
            // 
            // txtDRouteName
            // 
            this.txtDRouteName.BackColor = System.Drawing.SystemColors.Control;
            this.txtDRouteName.Enabled = false;
            this.txtDRouteName.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDRouteName.Location = new System.Drawing.Point(14, 109);
            this.txtDRouteName.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtDRouteName.Name = "txtDRouteName";
            this.txtDRouteName.ReadOnly = true;
            this.txtDRouteName.Size = new System.Drawing.Size(122, 28);
            this.txtDRouteName.TabIndex = 12;
            this.txtDRouteName.Text = "Order No.";
            this.txtDRouteName.TextChanged += new System.EventHandler(this.txtDRouteName_TextChanged);
            // 
            // txtATName
            // 
            this.txtATName.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 12F);
            this.txtATName.Location = new System.Drawing.Point(136, 82);
            this.txtATName.MaxLength = 100;
            this.txtATName.Name = "txtATName";
            this.txtATName.Size = new System.Drawing.Size(240, 27);
            this.txtATName.TabIndex = 2;
            this.txtATName.TextChanged += new System.EventHandler(this.txtATName_TextChanged);
            this.txtATName.Enter += new System.EventHandler(this.txtATName_Enter);
            this.txtATName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtATName_KeyDown);
            this.txtATName.Leave += new System.EventHandler(this.txtATName_Leave);
            // 
            // txtAEName
            // 
            this.txtAEName.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAEName.Location = new System.Drawing.Point(136, 54);
            this.txtAEName.MaxLength = 100;
            this.txtAEName.Name = "txtAEName";
            this.txtAEName.Size = new System.Drawing.Size(240, 28);
            this.txtAEName.TabIndex = 1;
            this.txtAEName.TextChanged += new System.EventHandler(this.txtAEName_TextChanged);
            this.txtAEName.Enter += new System.EventHandler(this.txtAEName_Enter);
            this.txtAEName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAEName_KeyDown);
            this.txtAEName.Leave += new System.EventHandler(this.txtAEName_Leave);
            // 
            // txtDAreaTName
            // 
            this.txtDAreaTName.BackColor = System.Drawing.SystemColors.Control;
            this.txtDAreaTName.Enabled = false;
            this.txtDAreaTName.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDAreaTName.Location = new System.Drawing.Point(14, 82);
            this.txtDAreaTName.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtDAreaTName.Name = "txtDAreaTName";
            this.txtDAreaTName.ReadOnly = true;
            this.txtDAreaTName.Size = new System.Drawing.Size(122, 28);
            this.txtDAreaTName.TabIndex = 10;
            this.txtDAreaTName.Text = "Area Name in Tamil";
            this.txtDAreaTName.TextChanged += new System.EventHandler(this.txtDAreaTName_TextChanged);
            // 
            // txtDAreaEName
            // 
            this.txtDAreaEName.BackColor = System.Drawing.SystemColors.Control;
            this.txtDAreaEName.Enabled = false;
            this.txtDAreaEName.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDAreaEName.Location = new System.Drawing.Point(14, 54);
            this.txtDAreaEName.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtDAreaEName.Name = "txtDAreaEName";
            this.txtDAreaEName.ReadOnly = true;
            this.txtDAreaEName.Size = new System.Drawing.Size(122, 28);
            this.txtDAreaEName.TabIndex = 11;
            this.txtDAreaEName.Text = "Area Name in English";
            // 
            // CP_Area
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(418, 289);
            this.Controls.Add(this.grbDetails);
            this.Font = new System.Drawing.Font("Oswald Regular", 11.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CP_Area";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Area Details";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CP_Area_FormClosing);
            this.Load += new System.EventHandler(this.CP_Area_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CP_Area_KeyDown);
            this.Leave += new System.EventHandler(this.CP_Area_Leave);
            ((System.ComponentModel.ISupportInitialize)(this.errArea)).EndInit();
            this.grbDetails.ResumeLayout(false);
            this.grbDetails.PerformLayout();
            this.pnlStatus.ResumeLayout(false);
            this.pnlStatus.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ErrorProvider errArea;
        private System.Windows.Forms.GroupBox grbDetails;
        private System.Windows.Forms.TextBox txtATName;
        private System.Windows.Forms.TextBox txtAEName;
        private System.Windows.Forms.TextBox txtDAreaTName;
        private System.Windows.Forms.TextBox txtDAreaEName;
        private System.Windows.Forms.TextBox txtDRouteName;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Panel pnlStatus;
        private System.Windows.Forms.RadioButton rbActive;
        private System.Windows.Forms.RadioButton rbInActive;
        private System.Windows.Forms.Button btnClose;
        public System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox cmbRoute;
        private System.Windows.Forms.ComboBox cmbCity;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ComboBox cmbOrderNo;
        private System.Windows.Forms.TextBox txtDistance;
        private System.Windows.Forms.TextBox txtDDistance;
    }
}