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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CP_Route));
            this.txtDRouteTName = new System.Windows.Forms.TextBox();
            this.txtDRouteEName = new System.Windows.Forms.TextBox();
            this.grbform = new System.Windows.Forms.GroupBox();
            this.cmbRSNo = new System.Windows.Forms.ComboBox();
            this.txtDRouteOrderNo = new System.Windows.Forms.TextBox();
            this.txtRTName = new System.Windows.Forms.TextBox();
            this.txtREName = new System.Windows.Forms.TextBox();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.pnlStatus = new System.Windows.Forms.Panel();
            this.rbActive = new System.Windows.Forms.RadioButton();
            this.rbInActive = new System.Windows.Forms.RadioButton();
            this.epRoute = new System.Windows.Forms.ErrorProvider(this.components);
            this.grdArea = new System.Windows.Forms.DataGridView();
            this.clmCheckBox = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clmArea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.grbform.SuspendLayout();
            this.pnlStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epRoute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdArea)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDRouteTName
            // 
            this.txtDRouteTName.BackColor = System.Drawing.SystemColors.Control;
            this.txtDRouteTName.Enabled = false;
            this.txtDRouteTName.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDRouteTName.Location = new System.Drawing.Point(6, 52);
            this.txtDRouteTName.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtDRouteTName.Name = "txtDRouteTName";
            this.txtDRouteTName.ReadOnly = true;
            this.txtDRouteTName.Size = new System.Drawing.Size(128, 28);
            this.txtDRouteTName.TabIndex = 6;
            this.txtDRouteTName.Text = "Route Name in Tamil";
            // 
            // txtDRouteEName
            // 
            this.txtDRouteEName.BackColor = System.Drawing.SystemColors.Control;
            this.txtDRouteEName.Enabled = false;
            this.txtDRouteEName.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDRouteEName.Location = new System.Drawing.Point(6, 24);
            this.txtDRouteEName.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtDRouteEName.Name = "txtDRouteEName";
            this.txtDRouteEName.ReadOnly = true;
            this.txtDRouteEName.Size = new System.Drawing.Size(128, 28);
            this.txtDRouteEName.TabIndex = 7;
            this.txtDRouteEName.Text = "Route Name in English";
            // 
            // grbform
            // 
            this.grbform.Controls.Add(this.grdArea);
            this.grbform.Controls.Add(this.cmbRSNo);
            this.grbform.Controls.Add(this.txtDRouteOrderNo);
            this.grbform.Controls.Add(this.txtRTName);
            this.grbform.Controls.Add(this.txtREName);
            this.grbform.Controls.Add(this.btnClose);
            this.grbform.Controls.Add(this.btnSave);
            this.grbform.Controls.Add(this.txtStatus);
            this.grbform.Controls.Add(this.txtDRouteTName);
            this.grbform.Controls.Add(this.txtDRouteEName);
            this.grbform.Controls.Add(this.pnlStatus);
            this.grbform.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.grbform.Location = new System.Drawing.Point(10, 1);
            this.grbform.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.grbform.Name = "grbform";
            this.grbform.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.grbform.Size = new System.Drawing.Size(379, 386);
            this.grbform.TabIndex = 28;
            this.grbform.TabStop = false;
            this.grbform.Enter += new System.EventHandler(this.grbform_Enter);
            // 
            // cmbRSNo
            // 
            this.cmbRSNo.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRSNo.FormattingEnabled = true;
            this.cmbRSNo.Location = new System.Drawing.Point(134, 80);
            this.cmbRSNo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbRSNo.Name = "cmbRSNo";
            this.cmbRSNo.Size = new System.Drawing.Size(235, 27);
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
            this.txtDRouteOrderNo.Location = new System.Drawing.Point(6, 80);
            this.txtDRouteOrderNo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDRouteOrderNo.Name = "txtDRouteOrderNo";
            this.txtDRouteOrderNo.ReadOnly = true;
            this.txtDRouteOrderNo.Size = new System.Drawing.Size(128, 27);
            this.txtDRouteOrderNo.TabIndex = 1111146;
            this.txtDRouteOrderNo.Text = "Order No.";
            // 
            // txtRTName
            // 
            this.txtRTName.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 12F);
            this.txtRTName.Location = new System.Drawing.Point(134, 52);
            this.txtRTName.MaxLength = 100;
            this.txtRTName.Name = "txtRTName";
            this.txtRTName.Size = new System.Drawing.Size(235, 27);
            this.txtRTName.TabIndex = 1;
            this.txtRTName.Enter += new System.EventHandler(this.txtRTName_Enter);
            this.txtRTName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRTName_KeyDown);
            this.txtRTName.Leave += new System.EventHandler(this.txtRTName_Leave);
            // 
            // txtREName
            // 
            this.txtREName.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtREName.Location = new System.Drawing.Point(134, 24);
            this.txtREName.MaxLength = 100;
            this.txtREName.Name = "txtREName";
            this.txtREName.Size = new System.Drawing.Size(235, 28);
            this.txtREName.TabIndex = 0;
            this.txtREName.Enter += new System.EventHandler(this.txtREName_Enter);
            this.txtREName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtREName_KeyDown);
            this.txtREName.Leave += new System.EventHandler(this.txtREName_Leave);
            // 
            // txtStatus
            // 
            this.txtStatus.BackColor = System.Drawing.SystemColors.Control;
            this.txtStatus.Enabled = false;
            this.txtStatus.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStatus.Location = new System.Drawing.Point(6, 107);
            this.txtStatus.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(128, 28);
            this.txtStatus.TabIndex = 8;
            this.txtStatus.Text = "Status";
            this.txtStatus.TextChanged += new System.EventHandler(this.txtStatus_TextChanged);
            // 
            // pnlStatus
            // 
            this.pnlStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlStatus.Controls.Add(this.rbActive);
            this.pnlStatus.Controls.Add(this.rbInActive);
            this.pnlStatus.Location = new System.Drawing.Point(134, 107);
            this.pnlStatus.Name = "pnlStatus";
            this.pnlStatus.Size = new System.Drawing.Size(235, 28);
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
            // grdArea
            // 
            this.grdArea.AllowUserToAddRows = false;
            this.grdArea.AllowUserToDeleteRows = false;
            this.grdArea.AllowUserToResizeRows = false;
            this.grdArea.BackgroundColor = System.Drawing.Color.White;
            this.grdArea.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(242)))), ((int)(((byte)(213)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdArea.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdArea.ColumnHeadersHeight = 30;
            this.grdArea.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdArea.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmCheckBox,
            this.clmArea});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdArea.DefaultCellStyle = dataGridViewCellStyle2;
            this.grdArea.EnableHeadersVisualStyles = false;
            this.grdArea.GridColor = System.Drawing.Color.White;
            this.grdArea.Location = new System.Drawing.Point(6, 142);
            this.grdArea.Name = "grdArea";
            this.grdArea.RowHeadersVisible = false;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.grdArea.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.grdArea.RowTemplate.Height = 25;
            this.grdArea.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.grdArea.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.grdArea.ShowRowErrors = false;
            this.grdArea.Size = new System.Drawing.Size(363, 193);
            this.grdArea.TabIndex = 1111147;
            // 
            // clmCheckBox
            // 
            this.clmCheckBox.HeaderText = "";
            this.clmCheckBox.Name = "clmCheckBox";
            this.clmCheckBox.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmCheckBox.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.clmCheckBox.Width = 50;
            // 
            // clmArea
            // 
            this.clmArea.HeaderText = "Area";
            this.clmArea.Name = "clmArea";
            this.clmArea.Width = 280;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::ROMS.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(288, 342);
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
            this.btnSave.Location = new System.Drawing.Point(202, 342);
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
            // CP_Route
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(399, 398);
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
            ((System.ComponentModel.ISupportInitialize)(this.grdArea)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtDRouteTName;
        private System.Windows.Forms.TextBox txtDRouteEName;
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
        public System.Windows.Forms.DataGridView grdArea;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clmCheckBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmArea;
    }
}