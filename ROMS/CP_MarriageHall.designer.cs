namespace ROMS
{
    partial class CP_MarriageHall
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CP_MarriageHall));
            this.txtMarriageHallEName = new System.Windows.Forms.TextBox();
            this.epMarriageHall = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.grbForm = new System.Windows.Forms.GroupBox();
            this.lvArea = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtReason = new System.Windows.Forms.TextBox();
            this.txtTeller = new System.Windows.Forms.TextBox();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.txtDistance = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.txtRoute = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.txtArea = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.txtMarriageHallTName = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblAreaId = new System.Windows.Forms.Label();
            this.lblRouteId = new System.Windows.Forms.Label();
            this.textBox8 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.epMarriageHall)).BeginInit();
            this.grbForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtMarriageHallEName
            // 
            this.txtMarriageHallEName.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtMarriageHallEName.Location = new System.Drawing.Point(162, 21);
            this.txtMarriageHallEName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMarriageHallEName.MaxLength = 30;
            this.txtMarriageHallEName.Name = "txtMarriageHallEName";
            this.txtMarriageHallEName.Size = new System.Drawing.Size(219, 27);
            this.txtMarriageHallEName.TabIndex = 0;
            this.txtMarriageHallEName.Enter += new System.EventHandler(this.txtMarriageHallEName_Enter);
            this.txtMarriageHallEName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMarriageHallEName_KeyDown);
            this.txtMarriageHallEName.Leave += new System.EventHandler(this.txtMarriageHallEName_Leave);
            // 
            // epMarriageHall
            // 
            this.epMarriageHall.ContainerControl = this;
            // 
            // txtStatus
            // 
            this.txtStatus.BackColor = System.Drawing.SystemColors.Control;
            this.txtStatus.Enabled = false;
            this.txtStatus.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtStatus.Location = new System.Drawing.Point(5, 161);
            this.txtStatus.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(157, 27);
            this.txtStatus.TabIndex = 11;
            this.txtStatus.Text = "Status";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.textBox1.Location = new System.Drawing.Point(5, 21);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(157, 27);
            this.textBox1.TabIndex = 12;
            this.textBox1.Text = "Marriage Hall Name in English";
            // 
            // grbForm
            // 
            this.grbForm.Controls.Add(this.lvArea);
            this.grbForm.Controls.Add(this.textBox8);
            this.grbForm.Controls.Add(this.txtReason);
            this.grbForm.Controls.Add(this.txtTeller);
            this.grbForm.Controls.Add(this.cmbStatus);
            this.grbForm.Controls.Add(this.textBox7);
            this.grbForm.Controls.Add(this.textBox6);
            this.grbForm.Controls.Add(this.txtDistance);
            this.grbForm.Controls.Add(this.textBox5);
            this.grbForm.Controls.Add(this.txtRoute);
            this.grbForm.Controls.Add(this.textBox4);
            this.grbForm.Controls.Add(this.txtArea);
            this.grbForm.Controls.Add(this.textBox3);
            this.grbForm.Controls.Add(this.txtMarriageHallTName);
            this.grbForm.Controls.Add(this.textBox2);
            this.grbForm.Controls.Add(this.textBox1);
            this.grbForm.Controls.Add(this.btnClose);
            this.grbForm.Controls.Add(this.txtMarriageHallEName);
            this.grbForm.Controls.Add(this.btnSave);
            this.grbForm.Controls.Add(this.txtStatus);
            this.grbForm.Location = new System.Drawing.Point(10, 12);
            this.grbForm.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbForm.Name = "grbForm";
            this.grbForm.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbForm.Size = new System.Drawing.Size(394, 339);
            this.grbForm.TabIndex = 0;
            this.grbForm.TabStop = false;
            // 
            // lvArea
            // 
            this.lvArea.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader3,
            this.columnHeader2,
            this.columnHeader4});
            this.lvArea.Font = new System.Drawing.Font("Oswald Regular", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvArea.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvArea.HideSelection = false;
            this.lvArea.Location = new System.Drawing.Point(162, 104);
            this.lvArea.Name = "lvArea";
            this.lvArea.Size = new System.Drawing.Size(219, 90);
            this.lvArea.TabIndex = 1111145;
            this.lvArea.UseCompatibleStateImageBehavior = false;
            this.lvArea.View = System.Windows.Forms.View.Details;
            this.lvArea.Visible = false;
            this.lvArea.DoubleClick += new System.EventHandler(this.lvArea_DoubleClick);
            this.lvArea.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvArea_KeyDown);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 200;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Width = 0;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Width = 0;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Width = 0;
            // 
            // txtReason
            // 
            this.txtReason.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtReason.Location = new System.Drawing.Point(162, 217);
            this.txtReason.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtReason.MaxLength = 200;
            this.txtReason.Multiline = true;
            this.txtReason.Name = "txtReason";
            this.txtReason.Size = new System.Drawing.Size(219, 72);
            this.txtReason.TabIndex = 7;
            this.txtReason.Enter += new System.EventHandler(this.txtReason_Enter);
            this.txtReason.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtReason_KeyDown);
            this.txtReason.Leave += new System.EventHandler(this.txtReason_Leave);
            // 
            // txtTeller
            // 
            this.txtTeller.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtTeller.Location = new System.Drawing.Point(162, 189);
            this.txtTeller.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTeller.MaxLength = 50;
            this.txtTeller.Name = "txtTeller";
            this.txtTeller.Size = new System.Drawing.Size(219, 27);
            this.txtTeller.TabIndex = 6;
            this.txtTeller.TextChanged += new System.EventHandler(this.txtTeller_TextChanged);
            this.txtTeller.Enter += new System.EventHandler(this.txtTeller_Enter);
            this.txtTeller.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTeller_KeyDown);
            this.txtTeller.Leave += new System.EventHandler(this.txtTeller_Leave);
            // 
            // cmbStatus
            // 
            this.cmbStatus.Font = new System.Drawing.Font("Oswald Regular", 11.25F);
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(162, 160);
            this.cmbStatus.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(219, 28);
            this.cmbStatus.TabIndex = 5;
            this.cmbStatus.SelectedIndexChanged += new System.EventHandler(this.cmbStatus_SelectedIndexChanged);
            this.cmbStatus.Enter += new System.EventHandler(this.cmbStatus_Enter);
            this.cmbStatus.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbStatus_KeyDown);
            this.cmbStatus.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbStatus_KeyPress);
            this.cmbStatus.Leave += new System.EventHandler(this.cmbStatus_Leave);
            // 
            // textBox7
            // 
            this.textBox7.BackColor = System.Drawing.SystemColors.Control;
            this.textBox7.Enabled = false;
            this.textBox7.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.textBox7.Location = new System.Drawing.Point(5, 189);
            this.textBox7.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.textBox7.Name = "textBox7";
            this.textBox7.ReadOnly = true;
            this.textBox7.Size = new System.Drawing.Size(157, 27);
            this.textBox7.TabIndex = 21;
            this.textBox7.Text = "Teller";
            // 
            // textBox6
            // 
            this.textBox6.BackColor = System.Drawing.SystemColors.Control;
            this.textBox6.Enabled = false;
            this.textBox6.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.textBox6.Location = new System.Drawing.Point(5, 217);
            this.textBox6.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(157, 27);
            this.textBox6.TabIndex = 20;
            this.textBox6.Text = "Reason";
            // 
            // txtDistance
            // 
            this.txtDistance.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtDistance.Location = new System.Drawing.Point(162, 133);
            this.txtDistance.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDistance.MaxLength = 10;
            this.txtDistance.Name = "txtDistance";
            this.txtDistance.Size = new System.Drawing.Size(185, 27);
            this.txtDistance.TabIndex = 4;
            this.txtDistance.Enter += new System.EventHandler(this.txtDistance_Enter);
            this.txtDistance.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDistance_KeyDown);
            this.txtDistance.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDistance_KeyPress);
            this.txtDistance.Leave += new System.EventHandler(this.txtDistance_Leave);
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.SystemColors.Control;
            this.textBox5.Enabled = false;
            this.textBox5.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.textBox5.Location = new System.Drawing.Point(5, 133);
            this.textBox5.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(157, 27);
            this.textBox5.TabIndex = 18;
            this.textBox5.Text = "Distance";
            // 
            // txtRoute
            // 
            this.txtRoute.Enabled = false;
            this.txtRoute.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtRoute.Location = new System.Drawing.Point(162, 105);
            this.txtRoute.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtRoute.MaxLength = 50;
            this.txtRoute.Name = "txtRoute";
            this.txtRoute.ReadOnly = true;
            this.txtRoute.Size = new System.Drawing.Size(219, 27);
            this.txtRoute.TabIndex = 3;
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.SystemColors.Control;
            this.textBox4.Enabled = false;
            this.textBox4.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.textBox4.Location = new System.Drawing.Point(5, 105);
            this.textBox4.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(157, 27);
            this.textBox4.TabIndex = 16;
            this.textBox4.Text = "Route";
            // 
            // txtArea
            // 
            this.txtArea.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtArea.Location = new System.Drawing.Point(162, 77);
            this.txtArea.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtArea.MaxLength = 50;
            this.txtArea.Name = "txtArea";
            this.txtArea.Size = new System.Drawing.Size(219, 27);
            this.txtArea.TabIndex = 2;
            this.txtArea.TextChanged += new System.EventHandler(this.txtArea_TextChanged);
            this.txtArea.Enter += new System.EventHandler(this.txtArea_Enter);
            this.txtArea.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtArea_KeyDown);
            this.txtArea.Leave += new System.EventHandler(this.txtArea_Leave);
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.SystemColors.Control;
            this.textBox3.Enabled = false;
            this.textBox3.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.textBox3.Location = new System.Drawing.Point(5, 77);
            this.textBox3.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(157, 27);
            this.textBox3.TabIndex = 14;
            this.textBox3.Text = "Area";
            // 
            // txtMarriageHallTName
            // 
            this.txtMarriageHallTName.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMarriageHallTName.Location = new System.Drawing.Point(162, 49);
            this.txtMarriageHallTName.MaxLength = 100;
            this.txtMarriageHallTName.Name = "txtMarriageHallTName";
            this.txtMarriageHallTName.Size = new System.Drawing.Size(219, 27);
            this.txtMarriageHallTName.TabIndex = 1;
            this.txtMarriageHallTName.Enter += new System.EventHandler(this.txtMarriageHallTName_Enter);
            this.txtMarriageHallTName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMarriageHallTName_KeyDown);
            this.txtMarriageHallTName.Leave += new System.EventHandler(this.txtMarriageHallTName_Leave);
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.Control;
            this.textBox2.Enabled = false;
            this.textBox2.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.textBox2.Location = new System.Drawing.Point(5, 49);
            this.textBox2.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(157, 27);
            this.textBox2.TabIndex = 13;
            this.textBox2.Text = "Marriage Hall Name in Tamil";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::ROMS.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(309, 299);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(72, 32);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnSave.Image = global::ROMS.Properties.Resources.save;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(222, 299);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(81, 32);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.Enter += new System.EventHandler(this.btnSave_Enter);
            this.btnSave.Leave += new System.EventHandler(this.btnSave_Leave);
            // 
            // lblAreaId
            // 
            this.lblAreaId.AutoSize = true;
            this.lblAreaId.Location = new System.Drawing.Point(397, 92);
            this.lblAreaId.Name = "lblAreaId";
            this.lblAreaId.Size = new System.Drawing.Size(16, 20);
            this.lblAreaId.TabIndex = 1111146;
            this.lblAreaId.Text = "0";
            this.lblAreaId.Visible = false;
            // 
            // lblRouteId
            // 
            this.lblRouteId.AutoSize = true;
            this.lblRouteId.Location = new System.Drawing.Point(397, 120);
            this.lblRouteId.Name = "lblRouteId";
            this.lblRouteId.Size = new System.Drawing.Size(16, 20);
            this.lblRouteId.TabIndex = 1111147;
            this.lblRouteId.Text = "0";
            this.lblRouteId.Visible = false;
            // 
            // textBox8
            // 
            this.textBox8.BackColor = System.Drawing.SystemColors.Control;
            this.textBox8.Enabled = false;
            this.textBox8.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.textBox8.Location = new System.Drawing.Point(346, 133);
            this.textBox8.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.textBox8.Name = "textBox8";
            this.textBox8.ReadOnly = true;
            this.textBox8.Size = new System.Drawing.Size(35, 27);
            this.textBox8.TabIndex = 1111146;
            this.textBox8.Text = "Km";
            this.textBox8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // CP_MarriageHall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(415, 364);
            this.Controls.Add(this.lblRouteId);
            this.Controls.Add(this.lblAreaId);
            this.Controls.Add(this.grbForm);
            this.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CP_MarriageHall";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Marriage Hall Details";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CP_MarriageHall_FormClosing);
            this.Load += new System.EventHandler(this.CP_MarriageHall_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CP_MarriageHall_KeyDown);
            this.Leave += new System.EventHandler(this.CP_MarriageHall_Leave);
            ((System.ComponentModel.ISupportInitialize)(this.epMarriageHall)).EndInit();
            this.grbForm.ResumeLayout(false);
            this.grbForm.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ErrorProvider epMarriageHall;
        public System.Windows.Forms.TextBox txtMarriageHallEName;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox grbForm;
        public System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox txtMarriageHallTName;
        private System.Windows.Forms.TextBox textBox3;
        public System.Windows.Forms.TextBox txtArea;
        private System.Windows.Forms.TextBox textBox4;
        public System.Windows.Forms.TextBox txtRoute;
        private System.Windows.Forms.TextBox textBox5;
        public System.Windows.Forms.TextBox txtDistance;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.ComboBox cmbStatus;
        public System.Windows.Forms.TextBox txtTeller;
        public System.Windows.Forms.TextBox txtReason;
        public System.Windows.Forms.ListView lvArea;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Label lblAreaId;
        private System.Windows.Forms.Label lblRouteId;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.TextBox textBox8;
    }
}