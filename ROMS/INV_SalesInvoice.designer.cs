namespace ROMS
{
    partial class INV_SalesInvoice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(INV_SalesInvoice));
            this.grbform = new System.Windows.Forms.GroupBox();
            this.btnView = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblSupplier = new System.Windows.Forms.Label();
            this.dtinvoicedate = new System.Windows.Forms.DateTimePicker();
            this.lblInvoiceDate = new System.Windows.Forms.Label();
            this.lblInvoiceNo = new System.Windows.Forms.Label();
            this.txtEInvoiceNo = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.errGroup = new System.Windows.Forms.ErrorProvider(this.components);
            this.grdUnitList = new System.Windows.Forms.DataGridView();
            this.clmCheckbox = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clmsno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmoutwardno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDSymbols = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmProductNameInEnglish = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmproductnameintamil = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbch = new System.Windows.Forms.CheckBox();
            this.lblRemarks = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.grbform.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdUnitList)).BeginInit();
            this.SuspendLayout();
            // 
            // grbform
            // 
            this.grbform.Controls.Add(this.btnView);
            this.grbform.Controls.Add(this.textBox1);
            this.grbform.Controls.Add(this.lblSupplier);
            this.grbform.Controls.Add(this.dtinvoicedate);
            this.grbform.Controls.Add(this.lblInvoiceDate);
            this.grbform.Controls.Add(this.lblInvoiceNo);
            this.grbform.Controls.Add(this.txtEInvoiceNo);
            this.grbform.Location = new System.Drawing.Point(19, 10);
            this.grbform.Name = "grbform";
            this.grbform.Size = new System.Drawing.Size(940, 71);
            this.grbform.TabIndex = 0;
            this.grbform.TabStop = false;
            // 
            // btnView
            // 
            this.btnView.Image = global::ROMS.Properties.Resources.view;
            this.btnView.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnView.Location = new System.Drawing.Point(845, 26);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(75, 29);
            this.btnView.TabIndex = 97;
            this.btnView.Text = "View";
            this.btnView.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnView.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(553, 26);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(281, 27);
            this.textBox1.TabIndex = 96;
            // 
            // lblSupplier
            // 
            this.lblSupplier.AutoSize = true;
            this.lblSupplier.Location = new System.Drawing.Point(494, 29);
            this.lblSupplier.Name = "lblSupplier";
            this.lblSupplier.Size = new System.Drawing.Size(54, 20);
            this.lblSupplier.TabIndex = 95;
            this.lblSupplier.Text = "Supplier";
            // 
            // dtinvoicedate
            // 
            this.dtinvoicedate.CustomFormat = "dd/MM/yyyy";
            this.dtinvoicedate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtinvoicedate.Location = new System.Drawing.Point(387, 26);
            this.dtinvoicedate.Name = "dtinvoicedate";
            this.dtinvoicedate.Size = new System.Drawing.Size(104, 27);
            this.dtinvoicedate.TabIndex = 94;
            // 
            // lblInvoiceDate
            // 
            this.lblInvoiceDate.AutoSize = true;
            this.lblInvoiceDate.Location = new System.Drawing.Point(309, 29);
            this.lblInvoiceDate.Name = "lblInvoiceDate";
            this.lblInvoiceDate.Size = new System.Drawing.Size(75, 20);
            this.lblInvoiceDate.TabIndex = 28;
            this.lblInvoiceDate.Text = "Invoice Date";
            // 
            // lblInvoiceNo
            // 
            this.lblInvoiceNo.AutoSize = true;
            this.lblInvoiceNo.Location = new System.Drawing.Point(11, 29);
            this.lblInvoiceNo.Name = "lblInvoiceNo";
            this.lblInvoiceNo.Size = new System.Drawing.Size(67, 20);
            this.lblInvoiceNo.TabIndex = 27;
            this.lblInvoiceNo.Text = "Invoice No.";
            // 
            // txtEInvoiceNo
            // 
            this.txtEInvoiceNo.Enabled = false;
            this.txtEInvoiceNo.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEInvoiceNo.Location = new System.Drawing.Point(81, 26);
            this.txtEInvoiceNo.MaxLength = 50;
            this.txtEInvoiceNo.Name = "txtEInvoiceNo";
            this.txtEInvoiceNo.ReadOnly = true;
            this.txtEInvoiceNo.Size = new System.Drawing.Size(224, 27);
            this.txtEInvoiceNo.TabIndex = 26;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnClose.Image = global::ROMS.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(1044, 487);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 29);
            this.btnClose.TabIndex = 8;
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
            this.btnSave.Location = new System.Drawing.Point(956, 487);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(84, 29);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.Enter += new System.EventHandler(this.btnSave_Enter);
            this.btnSave.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnSave_KeyDown);
            this.btnSave.Leave += new System.EventHandler(this.btnSave_Leave);
            // 
            // errGroup
            // 
            this.errGroup.ContainerControl = this;
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
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(242)))), ((int)(((byte)(213)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdUnitList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdUnitList.ColumnHeadersHeight = 30;
            this.grdUnitList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdUnitList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmCheckbox,
            this.clmsno,
            this.clmoutwardno,
            this.clmDSymbols,
            this.clmProductNameInEnglish,
            this.clmproductnameintamil,
            this.clmQty,
            this.clmUnit});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdUnitList.DefaultCellStyle = dataGridViewCellStyle2;
            this.grdUnitList.EnableHeadersVisualStyles = false;
            this.grdUnitList.GridColor = System.Drawing.Color.White;
            this.grdUnitList.Location = new System.Drawing.Point(19, 87);
            this.grdUnitList.Name = "grdUnitList";
            this.grdUnitList.ReadOnly = true;
            this.grdUnitList.RowHeadersVisible = false;
            this.grdUnitList.RowHeadersWidth = 100;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.grdUnitList.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.grdUnitList.RowTemplate.Height = 25;
            this.grdUnitList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdUnitList.Size = new System.Drawing.Size(1100, 394);
            this.grdUnitList.TabIndex = 958798;
            // 
            // clmCheckbox
            // 
            this.clmCheckbox.HeaderText = "";
            this.clmCheckbox.Name = "clmCheckbox";
            this.clmCheckbox.ReadOnly = true;
            this.clmCheckbox.Width = 50;
            // 
            // clmsno
            // 
            this.clmsno.HeaderText = "S.No.";
            this.clmsno.MinimumWidth = 6;
            this.clmsno.Name = "clmsno";
            this.clmsno.ReadOnly = true;
            this.clmsno.Width = 50;
            // 
            // clmoutwardno
            // 
            this.clmoutwardno.HeaderText = "Outward No.";
            this.clmoutwardno.MinimumWidth = 6;
            this.clmoutwardno.Name = "clmoutwardno";
            this.clmoutwardno.ReadOnly = true;
            this.clmoutwardno.Width = 200;
            // 
            // clmDSymbols
            // 
            this.clmDSymbols.HeaderText = "P.I Code";
            this.clmDSymbols.Name = "clmDSymbols";
            this.clmDSymbols.ReadOnly = true;
            this.clmDSymbols.Width = 150;
            // 
            // clmProductNameInEnglish
            // 
            this.clmProductNameInEnglish.HeaderText = "Product Name In English";
            this.clmProductNameInEnglish.Name = "clmProductNameInEnglish";
            this.clmProductNameInEnglish.ReadOnly = true;
            this.clmProductNameInEnglish.Width = 200;
            // 
            // clmproductnameintamil
            // 
            this.clmproductnameintamil.HeaderText = "Product Name In Tamil";
            this.clmproductnameintamil.Name = "clmproductnameintamil";
            this.clmproductnameintamil.ReadOnly = true;
            this.clmproductnameintamil.Width = 200;
            // 
            // clmQty
            // 
            this.clmQty.HeaderText = "Quantity";
            this.clmQty.Name = "clmQty";
            this.clmQty.ReadOnly = true;
            // 
            // clmUnit
            // 
            this.clmUnit.HeaderText = "Unit";
            this.clmUnit.Name = "clmUnit";
            this.clmUnit.ReadOnly = true;
            // 
            // cbch
            // 
            this.cbch.AutoSize = true;
            this.cbch.Location = new System.Drawing.Point(38, 96);
            this.cbch.Name = "cbch";
            this.cbch.Size = new System.Drawing.Size(15, 14);
            this.cbch.TabIndex = 958799;
            this.cbch.UseVisualStyleBackColor = true;
            // 
            // lblRemarks
            // 
            this.lblRemarks.AutoSize = true;
            this.lblRemarks.Location = new System.Drawing.Point(33, 489);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Size = new System.Drawing.Size(56, 20);
            this.lblRemarks.TabIndex = 958800;
            this.lblRemarks.Text = "Remarks";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(772, 490);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(45, 20);
            this.lblStatus.TabIndex = 958801;
            this.lblStatus.Text = "Status";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(820, 487);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(119, 27);
            this.comboBox1.TabIndex = 958802;
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(92, 487);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(418, 60);
            this.txtRemark.TabIndex = 958803;
            // 
            // INV_SalesInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1131, 561);
            this.Controls.Add(this.txtRemark);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblRemarks);
            this.Controls.Add(this.cbch);
            this.Controls.Add(this.grdUnitList);
            this.Controls.Add(this.grbform);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "INV_SalesInvoice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sales Invoice for Damaged Products";
            this.Load += new System.EventHandler(this.CP_Rack_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CP_Rack_KeyDown);
            this.grbform.ResumeLayout(false);
            this.grbform.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdUnitList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox grbform;
        private System.Windows.Forms.ErrorProvider errGroup;
        private System.Windows.Forms.TextBox txtEInvoiceNo;
        private System.Windows.Forms.Label lblInvoiceDate;
        private System.Windows.Forms.Label lblInvoiceNo;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblSupplier;
        private System.Windows.Forms.DateTimePicker dtinvoicedate;
        private System.Windows.Forms.Button btnView;
        public System.Windows.Forms.DataGridView grdUnitList;
        private System.Windows.Forms.CheckBox cbch;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clmCheckbox;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmsno;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmoutwardno;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDSymbols;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmProductNameInEnglish;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmproductnameintamil;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmUnit;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblRemarks;
        public System.Windows.Forms.Button btnSave;
    }
}