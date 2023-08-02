namespace ROMS
{
    partial class PUR_GRNEntry
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PUR_GRNEntry));
            this.errUnit = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grdUnitList = new System.Windows.Forms.DataGridView();
            this.clmUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbOrderType = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblDESupplier = new System.Windows.Forms.Label();
            this.txtSupplier = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtInvoiceamt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtInvoiceno = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dpinvoicedate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.txtgrnno = new System.Windows.Forms.TextBox();
            this.lblDEVisitDay = new System.Windows.Forms.Label();
            this.dpPlanDate = new System.Windows.Forms.DateTimePicker();
            this.cmbConcern = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errUnit)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdUnitList)).BeginInit();
            this.SuspendLayout();
            // 
            // errUnit
            // 
            this.errUnit.ContainerControl = this;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.grdUnitList);
            this.groupBox1.Controls.Add(this.cmbOrderType);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lblDESupplier);
            this.groupBox1.Controls.Add(this.txtSupplier);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtInvoiceamt);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtInvoiceno);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dpinvoicedate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtgrnno);
            this.groupBox1.Controls.Add(this.lblDEVisitDay);
            this.groupBox1.Controls.Add(this.dpPlanDate);
            this.groupBox1.Controls.Add(this.cmbConcern);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Location = new System.Drawing.Point(10, -1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(652, 201);
            this.groupBox1.TabIndex = 1111181;
            this.groupBox1.TabStop = false;
            // 
            // grdUnitList
            // 
            this.grdUnitList.AllowUserToAddRows = false;
            this.grdUnitList.AllowUserToDeleteRows = false;
            this.grdUnitList.AllowUserToResizeColumns = false;
            this.grdUnitList.AllowUserToResizeRows = false;
            this.grdUnitList.BackgroundColor = System.Drawing.Color.White;
            this.grdUnitList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(242)))), ((int)(((byte)(213)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdUnitList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdUnitList.ColumnHeadersHeight = 30;
            this.grdUnitList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdUnitList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmUnit,
            this.clmQty});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdUnitList.DefaultCellStyle = dataGridViewCellStyle3;
            this.grdUnitList.EnableHeadersVisualStyles = false;
            this.grdUnitList.GridColor = System.Drawing.Color.White;
            this.grdUnitList.Location = new System.Drawing.Point(509, 18);
            this.grdUnitList.Name = "grdUnitList";
            this.grdUnitList.RowHeadersVisible = false;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            this.grdUnitList.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.grdUnitList.RowTemplate.Height = 25;
            this.grdUnitList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.grdUnitList.Size = new System.Drawing.Size(127, 177);
            this.grdUnitList.TabIndex = 1111197;
            // 
            // clmUnit
            // 
            this.clmUnit.HeaderText = "Unit";
            this.clmUnit.Name = "clmUnit";
            this.clmUnit.ReadOnly = true;
            this.clmUnit.Width = 50;
            // 
            // clmQty
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.clmQty.DefaultCellStyle = dataGridViewCellStyle2;
            this.clmQty.HeaderText = "Qty";
            this.clmQty.Name = "clmQty";
            this.clmQty.Width = 50;
            // 
            // cmbOrderType
            // 
            this.cmbOrderType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOrderType.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbOrderType.FormattingEnabled = true;
            this.cmbOrderType.Items.AddRange(new object[] {
            "Direct",
            "Against PO"});
            this.cmbOrderType.Location = new System.Drawing.Point(74, 116);
            this.cmbOrderType.Name = "cmbOrderType";
            this.cmbOrderType.Size = new System.Drawing.Size(105, 27);
            this.cmbOrderType.TabIndex = 1111195;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(4, 119);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 20);
            this.label6.TabIndex = 1111196;
            this.label6.Text = "Order Type";
            // 
            // lblDESupplier
            // 
            this.lblDESupplier.AutoSize = true;
            this.lblDESupplier.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDESupplier.Location = new System.Drawing.Point(188, 20);
            this.lblDESupplier.Name = "lblDESupplier";
            this.lblDESupplier.Size = new System.Drawing.Size(54, 20);
            this.lblDESupplier.TabIndex = 1111193;
            this.lblDESupplier.Text = "Supplier";
            // 
            // txtSupplier
            // 
            this.txtSupplier.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSupplier.Location = new System.Drawing.Point(266, 17);
            this.txtSupplier.MaxLength = 50;
            this.txtSupplier.Name = "txtSupplier";
            this.txtSupplier.Size = new System.Drawing.Size(225, 27);
            this.txtSupplier.TabIndex = 1111194;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(188, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 20);
            this.label5.TabIndex = 1111192;
            this.label5.Text = "Invoice Amt";
            // 
            // txtInvoiceamt
            // 
            this.txtInvoiceamt.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInvoiceamt.Location = new System.Drawing.Point(266, 116);
            this.txtInvoiceamt.MaxLength = 50;
            this.txtInvoiceamt.Name = "txtInvoiceamt";
            this.txtInvoiceamt.Size = new System.Drawing.Size(105, 27);
            this.txtInvoiceamt.TabIndex = 1111191;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(188, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 20);
            this.label3.TabIndex = 1111190;
            this.label3.Text = "Invoice No.";
            // 
            // txtInvoiceno
            // 
            this.txtInvoiceno.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInvoiceno.Location = new System.Drawing.Point(266, 83);
            this.txtInvoiceno.MaxLength = 50;
            this.txtInvoiceno.Name = "txtInvoiceno";
            this.txtInvoiceno.Size = new System.Drawing.Size(105, 27);
            this.txtInvoiceno.TabIndex = 1111189;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(188, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 20);
            this.label4.TabIndex = 1111187;
            this.label4.Text = "Invoice Date";
            // 
            // dpinvoicedate
            // 
            this.dpinvoicedate.CustomFormat = "dd/MM/yyyy";
            this.dpinvoicedate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpinvoicedate.Location = new System.Drawing.Point(266, 50);
            this.dpinvoicedate.Name = "dpinvoicedate";
            this.dpinvoicedate.Size = new System.Drawing.Size(105, 28);
            this.dpinvoicedate.TabIndex = 1111188;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 20);
            this.label1.TabIndex = 1111185;
            this.label1.Text = "GRN No.";
            // 
            // txtgrnno
            // 
            this.txtgrnno.Enabled = false;
            this.txtgrnno.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtgrnno.Location = new System.Drawing.Point(74, 83);
            this.txtgrnno.MaxLength = 50;
            this.txtgrnno.Name = "txtgrnno";
            this.txtgrnno.ReadOnly = true;
            this.txtgrnno.Size = new System.Drawing.Size(105, 27);
            this.txtgrnno.TabIndex = 1111186;
            // 
            // lblDEVisitDay
            // 
            this.lblDEVisitDay.AutoSize = true;
            this.lblDEVisitDay.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDEVisitDay.Location = new System.Drawing.Point(4, 54);
            this.lblDEVisitDay.Name = "lblDEVisitDay";
            this.lblDEVisitDay.Size = new System.Drawing.Size(61, 20);
            this.lblDEVisitDay.TabIndex = 1111183;
            this.lblDEVisitDay.Text = "GRN Date";
            // 
            // dpPlanDate
            // 
            this.dpPlanDate.CustomFormat = "dd/MM/yyyy";
            this.dpPlanDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpPlanDate.Location = new System.Drawing.Point(74, 50);
            this.dpPlanDate.Name = "dpPlanDate";
            this.dpPlanDate.Size = new System.Drawing.Size(105, 28);
            this.dpPlanDate.TabIndex = 1111184;
            // 
            // cmbConcern
            // 
            this.cmbConcern.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbConcern.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbConcern.FormattingEnabled = true;
            this.cmbConcern.Location = new System.Drawing.Point(74, 17);
            this.cmbConcern.Name = "cmbConcern";
            this.cmbConcern.Size = new System.Drawing.Size(105, 27);
            this.cmbConcern.TabIndex = 1111181;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(4, 20);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 20);
            this.label10.TabIndex = 1111182;
            this.label10.Text = "Concern";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnClose.Image = global::ROMS.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(573, 207);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 29);
            this.btnClose.TabIndex = 1111183;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnSave.Image = global::ROMS.Properties.Resources.save;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(444, 207);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(125, 29);
            this.btnSave.TabIndex = 1111182;
            this.btnSave.Text = "Save && Print";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // PUR_GRNEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(671, 245);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PUR_GRNEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GRN Entry";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PUR_GRNEntry_FormClosing);
            this.Load += new System.EventHandler(this.PUR_GRNEntry_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errUnit)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdUnitList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ErrorProvider errUnit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbOrderType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblDESupplier;
        private System.Windows.Forms.TextBox txtSupplier;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtInvoiceamt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtInvoiceno;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dpinvoicedate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtgrnno;
        private System.Windows.Forms.Label lblDEVisitDay;
        private System.Windows.Forms.DateTimePicker dpPlanDate;
        private System.Windows.Forms.ComboBox cmbConcern;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnClose;
        public System.Windows.Forms.DataGridView grdUnitList;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmQty;
        public System.Windows.Forms.Button btnSave;
    }
}