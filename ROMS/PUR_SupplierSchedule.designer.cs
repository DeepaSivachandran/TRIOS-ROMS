namespace ROMS
{
    partial class PUR_SupplierSchedule
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PUR_SupplierSchedule));
            this.grbform = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSupplier = new System.Windows.Forms.TextBox();
            this.grddays = new System.Windows.Forms.DataGridView();
            this.chkdays = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clmname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.errBrand = new System.Windows.Forms.ErrorProvider(this.components);
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.grpRepresentativeDetails = new System.Windows.Forms.GroupBox();
            this.grpSalesManDetails = new System.Windows.Forms.GroupBox();
            this.grpSupplierDetails = new System.Windows.Forms.GroupBox();
            this.grbform.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grddays)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errBrand)).BeginInit();
            this.SuspendLayout();
            // 
            // grbform
            // 
            this.grbform.Controls.Add(this.grpRepresentativeDetails);
            this.grbform.Controls.Add(this.grpSalesManDetails);
            this.grbform.Controls.Add(this.grpSupplierDetails);
            this.grbform.Controls.Add(this.comboBox1);
            this.grbform.Controls.Add(this.label4);
            this.grbform.Controls.Add(this.label3);
            this.grbform.Controls.Add(this.txtSupplier);
            this.grbform.Controls.Add(this.grddays);
            this.grbform.Controls.Add(this.label2);
            this.grbform.Controls.Add(this.btnClose);
            this.grbform.Controls.Add(this.btnSave);
            this.grbform.Location = new System.Drawing.Point(13, 8);
            this.grbform.Name = "grbform";
            this.grbform.Size = new System.Drawing.Size(999, 314);
            this.grbform.TabIndex = 28;
            this.grbform.TabStop = false;
            this.grbform.Enter += new System.EventHandler(this.Grbform_Enter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 20);
            this.label3.TabIndex = 1111146;
            this.label3.Text = "Days";
            // 
            // txtSupplier
            // 
            this.txtSupplier.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSupplier.Location = new System.Drawing.Point(15, 42);
            this.txtSupplier.MaxLength = 50;
            this.txtSupplier.Name = "txtSupplier";
            this.txtSupplier.Size = new System.Drawing.Size(214, 27);
            this.txtSupplier.TabIndex = 1111145;
            // 
            // grddays
            // 
            this.grddays.AllowUserToAddRows = false;
            this.grddays.AllowUserToDeleteRows = false;
            this.grddays.AllowUserToResizeColumns = false;
            this.grddays.AllowUserToResizeRows = false;
            this.grddays.BackgroundColor = System.Drawing.Color.White;
            this.grddays.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(242)))), ((int)(((byte)(213)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grddays.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grddays.ColumnHeadersHeight = 30;
            this.grddays.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grddays.ColumnHeadersVisible = false;
            this.grddays.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chkdays,
            this.clmname});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grddays.DefaultCellStyle = dataGridViewCellStyle2;
            this.grddays.EnableHeadersVisualStyles = false;
            this.grddays.GridColor = System.Drawing.Color.White;
            this.grddays.Location = new System.Drawing.Point(15, 149);
            this.grddays.Name = "grddays";
            this.grddays.ReadOnly = true;
            this.grddays.RowHeadersVisible = false;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.grddays.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.grddays.RowTemplate.Height = 25;
            this.grddays.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grddays.Size = new System.Drawing.Size(142, 156);
            this.grddays.TabIndex = 1111143;
            this.grddays.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grddays_CellContentClick);
            // 
            // chkdays
            // 
            this.chkdays.HeaderText = "";
            this.chkdays.Name = "chkdays";
            this.chkdays.ReadOnly = true;
            this.chkdays.Width = 40;
            // 
            // clmname
            // 
            this.clmname.HeaderText = "";
            this.clmname.Name = "clmname";
            this.clmname.ReadOnly = true;
            this.clmname.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmname.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 20);
            this.label2.TabIndex = 1111142;
            this.label2.Text = "Supplier Name";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnClose.Image = global::ROMS.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(909, 276);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 29);
            this.btnClose.TabIndex = 4;
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
            this.btnSave.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnSave.Image = global::ROMS.Properties.Resources.save;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(819, 276);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(84, 29);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.Enter += new System.EventHandler(this.btnSave_Enter);
            this.btnSave.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnSave_KeyDown);
            this.btnSave.Leave += new System.EventHandler(this.btnSave_Leave);
            // 
            // errBrand
            // 
            this.errBrand.ContainerControl = this;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(15, 95);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(214, 27);
            this.comboBox1.TabIndex = 1111180;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(15, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 20);
            this.label4.TabIndex = 1111179;
            this.label4.Text = "Order Type";
            // 
            // grpRepresentativeDetails
            // 
            this.grpRepresentativeDetails.Location = new System.Drawing.Point(489, 18);
            this.grpRepresentativeDetails.Name = "grpRepresentativeDetails";
            this.grpRepresentativeDetails.Size = new System.Drawing.Size(241, 114);
            this.grpRepresentativeDetails.TabIndex = 1111182;
            this.grpRepresentativeDetails.TabStop = false;
            this.grpRepresentativeDetails.Text = "Representative Details";
            // 
            // grpSalesManDetails
            // 
            this.grpSalesManDetails.Location = new System.Drawing.Point(743, 18);
            this.grpSalesManDetails.Name = "grpSalesManDetails";
            this.grpSalesManDetails.Size = new System.Drawing.Size(241, 114);
            this.grpSalesManDetails.TabIndex = 1111183;
            this.grpSalesManDetails.TabStop = false;
            this.grpSalesManDetails.Text = "Salesman Details";
            // 
            // grpSupplierDetails
            // 
            this.grpSupplierDetails.Location = new System.Drawing.Point(237, 18);
            this.grpSupplierDetails.Name = "grpSupplierDetails";
            this.grpSupplierDetails.Size = new System.Drawing.Size(241, 114);
            this.grpSupplierDetails.TabIndex = 1111181;
            this.grpSupplierDetails.TabStop = false;
            this.grpSupplierDetails.Text = "Supplier Details";
            // 
            // PUR_SupplierSchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1024, 328);
            this.Controls.Add(this.grbform);
            this.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PUR_SupplierSchedule";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PO Schedule";
            this.Load += new System.EventHandler(this.PUR_SupplierSchedule_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CP_Brand_KeyDown);
            this.Leave += new System.EventHandler(this.CP_Brand_Leave);
            this.grbform.ResumeLayout(false);
            this.grbform.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grddays)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errBrand)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox grbform;
        private System.Windows.Forms.ErrorProvider errBrand;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.DataGridView grddays;
        private System.Windows.Forms.TextBox txtSupplier;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chkdays;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmname;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox grpRepresentativeDetails;
        private System.Windows.Forms.GroupBox grpSalesManDetails;
        private System.Windows.Forms.GroupBox grpSupplierDetails;
    }
}