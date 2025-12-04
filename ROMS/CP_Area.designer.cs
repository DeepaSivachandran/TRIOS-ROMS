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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CP_Area));
            this.errArea = new System.Windows.Forms.ErrorProvider(this.components);
            this.grbDetails = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.pnlStatus = new System.Windows.Forms.Panel();
            this.rbActive = new System.Windows.Forms.RadioButton();
            this.rbInActive = new System.Windows.Forms.RadioButton();
            this.txtRName = new System.Windows.Forms.TextBox();
            this.txtDRouteName = new System.Windows.Forms.TextBox();
            this.txtATName = new System.Windows.Forms.TextBox();
            this.txtAEName = new System.Windows.Forms.TextBox();
            this.txtDAreaTName = new System.Windows.Forms.TextBox();
            this.txtDAreaEName = new System.Windows.Forms.TextBox();
            this.DGV_FilterLocation = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.errArea)).BeginInit();
            this.grbDetails.SuspendLayout();
            this.pnlStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_FilterLocation)).BeginInit();
            this.SuspendLayout();
            // 
            // errArea
            // 
            this.errArea.ContainerControl = this;
            // 
            // grbDetails
            // 
            this.grbDetails.Controls.Add(this.btnClose);
            this.grbDetails.Controls.Add(this.btnSave);
            this.grbDetails.Controls.Add(this.txtStatus);
            this.grbDetails.Controls.Add(this.pnlStatus);
            this.grbDetails.Controls.Add(this.txtRName);
            this.grbDetails.Controls.Add(this.txtDRouteName);
            this.grbDetails.Controls.Add(this.txtATName);
            this.grbDetails.Controls.Add(this.txtAEName);
            this.grbDetails.Controls.Add(this.txtDAreaTName);
            this.grbDetails.Controls.Add(this.txtDAreaEName);
            this.grbDetails.Location = new System.Drawing.Point(12, 3);
            this.grbDetails.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbDetails.Name = "grbDetails";
            this.grbDetails.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbDetails.Size = new System.Drawing.Size(388, 198);
            this.grbDetails.TabIndex = 0;
            this.grbDetails.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::ROMS.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(288, 150);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 33);
            this.btnClose.TabIndex = 17;
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
            this.btnSave.Location = new System.Drawing.Point(202, 150);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 33);
            this.btnSave.TabIndex = 16;
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
            this.txtStatus.Location = new System.Drawing.Point(6, 114);
            this.txtStatus.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(122, 28);
            this.txtStatus.TabIndex = 15;
            this.txtStatus.Text = "Status";
            // 
            // pnlStatus
            // 
            this.pnlStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlStatus.Controls.Add(this.rbActive);
            this.pnlStatus.Controls.Add(this.rbInActive);
            this.pnlStatus.Location = new System.Drawing.Point(128, 114);
            this.pnlStatus.Name = "pnlStatus";
            this.pnlStatus.Size = new System.Drawing.Size(240, 28);
            this.pnlStatus.TabIndex = 14;
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
            // 
            // txtRName
            // 
            this.txtRName.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRName.Location = new System.Drawing.Point(128, 86);
            this.txtRName.MaxLength = 100;
            this.txtRName.Name = "txtRName";
            this.txtRName.Size = new System.Drawing.Size(240, 28);
            this.txtRName.TabIndex = 13;
            this.txtRName.TextChanged += new System.EventHandler(this.txtRName_TextChanged);
            this.txtRName.Enter += new System.EventHandler(this.txtRName_Enter);
            this.txtRName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRName_KeyDown);
            this.txtRName.Leave += new System.EventHandler(this.txtRName_Leave);
            // 
            // txtDRouteName
            // 
            this.txtDRouteName.BackColor = System.Drawing.SystemColors.Control;
            this.txtDRouteName.Enabled = false;
            this.txtDRouteName.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDRouteName.Location = new System.Drawing.Point(6, 86);
            this.txtDRouteName.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtDRouteName.Name = "txtDRouteName";
            this.txtDRouteName.ReadOnly = true;
            this.txtDRouteName.Size = new System.Drawing.Size(122, 28);
            this.txtDRouteName.TabIndex = 12;
            this.txtDRouteName.Text = "Route Name";
            // 
            // txtATName
            // 
            this.txtATName.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 12F);
            this.txtATName.Location = new System.Drawing.Point(128, 58);
            this.txtATName.MaxLength = 100;
            this.txtATName.Name = "txtATName";
            this.txtATName.Size = new System.Drawing.Size(240, 27);
            this.txtATName.TabIndex = 9;
            this.txtATName.Enter += new System.EventHandler(this.txtATName_Enter);
            this.txtATName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtATName_KeyDown);
            this.txtATName.Leave += new System.EventHandler(this.txtATName_Leave);
            // 
            // txtAEName
            // 
            this.txtAEName.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAEName.Location = new System.Drawing.Point(128, 30);
            this.txtAEName.MaxLength = 100;
            this.txtAEName.Name = "txtAEName";
            this.txtAEName.Size = new System.Drawing.Size(240, 28);
            this.txtAEName.TabIndex = 8;
            this.txtAEName.Enter += new System.EventHandler(this.txtAEName_Enter);
            this.txtAEName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAEName_KeyDown);
            this.txtAEName.Leave += new System.EventHandler(this.txtAEName_Leave);
            // 
            // txtDAreaTName
            // 
            this.txtDAreaTName.BackColor = System.Drawing.SystemColors.Control;
            this.txtDAreaTName.Enabled = false;
            this.txtDAreaTName.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDAreaTName.Location = new System.Drawing.Point(6, 58);
            this.txtDAreaTName.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtDAreaTName.Name = "txtDAreaTName";
            this.txtDAreaTName.ReadOnly = true;
            this.txtDAreaTName.Size = new System.Drawing.Size(122, 28);
            this.txtDAreaTName.TabIndex = 10;
            this.txtDAreaTName.Text = "Area Tamil Name";
            // 
            // txtDAreaEName
            // 
            this.txtDAreaEName.BackColor = System.Drawing.SystemColors.Control;
            this.txtDAreaEName.Enabled = false;
            this.txtDAreaEName.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDAreaEName.Location = new System.Drawing.Point(6, 30);
            this.txtDAreaEName.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtDAreaEName.Name = "txtDAreaEName";
            this.txtDAreaEName.ReadOnly = true;
            this.txtDAreaEName.Size = new System.Drawing.Size(122, 28);
            this.txtDAreaEName.TabIndex = 11;
            this.txtDAreaEName.Text = "Area English Name";
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
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Oswald Regular", 11.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Chocolate;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_FilterLocation.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DGV_FilterLocation.ColumnHeadersHeight = 30;
            this.DGV_FilterLocation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Oswald Regular", 11.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV_FilterLocation.DefaultCellStyle = dataGridViewCellStyle2;
            this.DGV_FilterLocation.EnableHeadersVisualStyles = false;
            this.DGV_FilterLocation.GridColor = System.Drawing.Color.White;
            this.DGV_FilterLocation.Location = new System.Drawing.Point(18, 117);
            this.DGV_FilterLocation.Name = "DGV_FilterLocation";
            this.DGV_FilterLocation.ReadOnly = true;
            this.DGV_FilterLocation.RowHeadersVisible = false;
            this.DGV_FilterLocation.RowHeadersWidth = 51;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.DGV_FilterLocation.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.DGV_FilterLocation.RowTemplate.Height = 25;
            this.DGV_FilterLocation.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV_FilterLocation.Size = new System.Drawing.Size(260, 95);
            this.DGV_FilterLocation.TabIndex = 111111173;
            this.DGV_FilterLocation.Visible = false;
            // 
            // CP_Area
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(418, 216);
            this.Controls.Add(this.DGV_FilterLocation);
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
            this.Load += new System.EventHandler(this.CP_Area_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CP_Area_KeyDown);
            this.Leave += new System.EventHandler(this.CP_Area_Leave);
            ((System.ComponentModel.ISupportInitialize)(this.errArea)).EndInit();
            this.grbDetails.ResumeLayout(false);
            this.grbDetails.PerformLayout();
            this.pnlStatus.ResumeLayout(false);
            this.pnlStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_FilterLocation)).EndInit();
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
        private System.Windows.Forms.TextBox txtRName;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Panel pnlStatus;
        private System.Windows.Forms.RadioButton rbActive;
        private System.Windows.Forms.RadioButton rbInActive;
        private System.Windows.Forms.Button btnClose;
        public System.Windows.Forms.Button btnSave;
        public System.Windows.Forms.DataGridView DGV_FilterLocation;
    }
}