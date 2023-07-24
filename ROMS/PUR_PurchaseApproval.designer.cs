namespace ROMS
{
    partial class PUR_PurchaseApproval
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PUR_PurchaseApproval));
            this.txtSupplierName = new System.Windows.Forms.TextBox();
            this.btnApprove = new System.Windows.Forms.Button();
            this.grbForm = new System.Windows.Forms.GroupBox();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.lblRemarks = new System.Windows.Forms.Label();
            this.lblSupplier = new System.Windows.Forms.Label();
            this.txtSupplier = new System.Windows.Forms.TextBox();
            this.dpDop = new System.Windows.Forms.DateTimePicker();
            this.lblVoucharDate = new System.Windows.Forms.Label();
            this.lblVouchar = new System.Windows.Forms.Label();
            this.btnreject = new System.Windows.Forms.Button();
            this.grdSupplierList = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.errProductApproval = new System.Windows.Forms.ErrorProvider(this.components);
            this.clmsno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmpicode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmProductname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmMRPRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmgodown = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPOQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmInvoiceQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmUnitRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmGST = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmGSTAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmNettAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grbForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSupplierList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errProductApproval)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSupplierName
            // 
            this.txtSupplierName.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSupplierName.Location = new System.Drawing.Point(70, 24);
            this.txtSupplierName.MaxLength = 50;
            this.txtSupplierName.Name = "txtSupplierName";
            this.txtSupplierName.ReadOnly = true;
            this.txtSupplierName.Size = new System.Drawing.Size(135, 27);
            this.txtSupplierName.TabIndex = 0;
            // 
            // btnApprove
            // 
            this.btnApprove.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnApprove.Image = global::ROMS.Properties.Resources.approve;
            this.btnApprove.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnApprove.Location = new System.Drawing.Point(1079, 436);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(84, 30);
            this.btnApprove.TabIndex = 6;
            this.btnApprove.Text = "Approve";
            this.btnApprove.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnApprove.UseVisualStyleBackColor = true;
            // 
            // grbForm
            // 
            this.grbForm.Controls.Add(this.txtRemarks);
            this.grbForm.Controls.Add(this.lblRemarks);
            this.grbForm.Controls.Add(this.lblSupplier);
            this.grbForm.Controls.Add(this.txtSupplier);
            this.grbForm.Controls.Add(this.dpDop);
            this.grbForm.Controls.Add(this.lblVoucharDate);
            this.grbForm.Controls.Add(this.lblVouchar);
            this.grbForm.Controls.Add(this.btnreject);
            this.grbForm.Controls.Add(this.grdSupplierList);
            this.grbForm.Controls.Add(this.btnClose);
            this.grbForm.Controls.Add(this.btnApprove);
            this.grbForm.Controls.Add(this.txtSupplierName);
            this.grbForm.Location = new System.Drawing.Point(8, 4);
            this.grbForm.Name = "grbForm";
            this.grbForm.Size = new System.Drawing.Size(1343, 499);
            this.grbForm.TabIndex = 0;
            this.grbForm.TabStop = false;
            // 
            // txtRemarks
            // 
            this.txtRemarks.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemarks.Location = new System.Drawing.Point(82, 436);
            this.txtRemarks.MaxLength = 50;
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(665, 49);
            this.txtRemarks.TabIndex = 1111145;
            // 
            // lblRemarks
            // 
            this.lblRemarks.AutoSize = true;
            this.lblRemarks.Location = new System.Drawing.Point(10, 436);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Size = new System.Drawing.Size(56, 20);
            this.lblRemarks.TabIndex = 1111144;
            this.lblRemarks.Text = "Remarks";
            // 
            // lblSupplier
            // 
            this.lblSupplier.AutoSize = true;
            this.lblSupplier.Location = new System.Drawing.Point(397, 30);
            this.lblSupplier.Name = "lblSupplier";
            this.lblSupplier.Size = new System.Drawing.Size(54, 20);
            this.lblSupplier.TabIndex = 1111143;
            this.lblSupplier.Text = "Supplier";
            // 
            // txtSupplier
            // 
            this.txtSupplier.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSupplier.Location = new System.Drawing.Point(457, 27);
            this.txtSupplier.MaxLength = 50;
            this.txtSupplier.Name = "txtSupplier";
            this.txtSupplier.Size = new System.Drawing.Size(581, 27);
            this.txtSupplier.TabIndex = 1111142;
            // 
            // dpDop
            // 
            this.dpDop.CustomFormat = "dd/MM/yyyy";
            this.dpDop.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpDop.Location = new System.Drawing.Point(299, 24);
            this.dpDop.Name = "dpDop";
            this.dpDop.Size = new System.Drawing.Size(92, 27);
            this.dpDop.TabIndex = 1111141;
            // 
            // lblVoucharDate
            // 
            this.lblVoucharDate.AutoSize = true;
            this.lblVoucharDate.Location = new System.Drawing.Point(211, 27);
            this.lblVoucharDate.Name = "lblVoucharDate";
            this.lblVoucharDate.Size = new System.Drawing.Size(82, 20);
            this.lblVoucharDate.TabIndex = 1111140;
            this.lblVoucharDate.Text = "Voucher Date";
            // 
            // lblVouchar
            // 
            this.lblVouchar.AutoSize = true;
            this.lblVouchar.Location = new System.Drawing.Point(10, 27);
            this.lblVouchar.Name = "lblVouchar";
            this.lblVouchar.Size = new System.Drawing.Size(74, 20);
            this.lblVouchar.TabIndex = 1111139;
            this.lblVouchar.Text = "Voucher No.";
            // 
            // btnreject
            // 
            this.btnreject.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnreject.Image = global::ROMS.Properties.Resources.reset;
            this.btnreject.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnreject.Location = new System.Drawing.Point(1166, 436);
            this.btnreject.Name = "btnreject";
            this.btnreject.Size = new System.Drawing.Size(84, 30);
            this.btnreject.TabIndex = 1111138;
            this.btnreject.Text = "Reject";
            this.btnreject.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnreject.UseVisualStyleBackColor = true;
            // 
            // grdSupplierList
            // 
            this.grdSupplierList.AllowUserToAddRows = false;
            this.grdSupplierList.AllowUserToDeleteRows = false;
            this.grdSupplierList.AllowUserToResizeColumns = false;
            this.grdSupplierList.AllowUserToResizeRows = false;
            this.grdSupplierList.BackgroundColor = System.Drawing.Color.White;
            this.grdSupplierList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(242)))), ((int)(((byte)(213)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdSupplierList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdSupplierList.ColumnHeadersHeight = 45;
            this.grdSupplierList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdSupplierList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmsno,
            this.clmpicode,
            this.clmProductname,
            this.clmMRPRate,
            this.clmgodown,
            this.Column1,
            this.clmPOQty,
            this.clmInvoiceQty,
            this.Unit,
            this.clmUnitRate,
            this.clmGST,
            this.clmGSTAmount,
            this.clmAmount,
            this.clmNettAmount});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdSupplierList.DefaultCellStyle = dataGridViewCellStyle2;
            this.grdSupplierList.EnableHeadersVisualStyles = false;
            this.grdSupplierList.GridColor = System.Drawing.Color.White;
            this.grdSupplierList.Location = new System.Drawing.Point(10, 57);
            this.grdSupplierList.Name = "grdSupplierList";
            this.grdSupplierList.ReadOnly = true;
            this.grdSupplierList.RowHeadersVisible = false;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.grdSupplierList.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.grdSupplierList.RowTemplate.Height = 25;
            this.grdSupplierList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdSupplierList.Size = new System.Drawing.Size(1327, 366);
            this.grdSupplierList.TabIndex = 1111137;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnClose.Image = global::ROMS.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(1253, 304);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(84, 29);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // errProductApproval
            // 
            this.errProductApproval.ContainerControl = this;
            // 
            // clmsno
            // 
            this.clmsno.HeaderText = "S.No.";
            this.clmsno.Name = "clmsno";
            this.clmsno.ReadOnly = true;
            this.clmsno.Width = 50;
            // 
            // clmpicode
            // 
            this.clmpicode.HeaderText = "P.I Code";
            this.clmpicode.Name = "clmpicode";
            this.clmpicode.ReadOnly = true;
            this.clmpicode.Width = 75;
            // 
            // clmProductname
            // 
            this.clmProductname.HeaderText = "Product Name";
            this.clmProductname.Name = "clmProductname";
            this.clmProductname.ReadOnly = true;
            this.clmProductname.Width = 200;
            // 
            // clmMRPRate
            // 
            this.clmMRPRate.HeaderText = "MRP Rate";
            this.clmMRPRate.Name = "clmMRPRate";
            this.clmMRPRate.ReadOnly = true;
            // 
            // clmgodown
            // 
            this.clmgodown.HeaderText = "Stock Location";
            this.clmgodown.Name = "clmgodown";
            this.clmgodown.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Rack";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // clmPOQty
            // 
            this.clmPOQty.HeaderText = "PO Qty";
            this.clmPOQty.Name = "clmPOQty";
            this.clmPOQty.ReadOnly = true;
            this.clmPOQty.Width = 50;
            // 
            // clmInvoiceQty
            // 
            this.clmInvoiceQty.HeaderText = "Invoice Qty";
            this.clmInvoiceQty.Name = "clmInvoiceQty";
            this.clmInvoiceQty.ReadOnly = true;
            this.clmInvoiceQty.Width = 50;
            // 
            // Unit
            // 
            this.Unit.HeaderText = "Unit";
            this.Unit.Name = "Unit";
            this.Unit.ReadOnly = true;
            this.Unit.Width = 50;
            // 
            // clmUnitRate
            // 
            this.clmUnitRate.HeaderText = "Unit Rate";
            this.clmUnitRate.Name = "clmUnitRate";
            this.clmUnitRate.ReadOnly = true;
            // 
            // clmGST
            // 
            this.clmGST.HeaderText = "GST %";
            this.clmGST.Name = "clmGST";
            this.clmGST.ReadOnly = true;
            this.clmGST.Width = 50;
            // 
            // clmGSTAmount
            // 
            this.clmGSTAmount.HeaderText = "GST Amount";
            this.clmGSTAmount.Name = "clmGSTAmount";
            this.clmGSTAmount.ReadOnly = true;
            // 
            // clmAmount
            // 
            this.clmAmount.HeaderText = "Amount";
            this.clmAmount.Name = "clmAmount";
            this.clmAmount.ReadOnly = true;
            // 
            // clmNettAmount
            // 
            this.clmNettAmount.HeaderText = "Nett Amount";
            this.clmNettAmount.Name = "clmNettAmount";
            this.clmNettAmount.ReadOnly = true;
            // 
            // PUR_PurchaseApproval
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1360, 525);
            this.Controls.Add(this.grbForm);
            this.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PUR_PurchaseApproval";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Product Approval";
            this.grbForm.ResumeLayout(false);
            this.grbForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSupplierList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errProductApproval)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txtSupplierName;
        private System.Windows.Forms.Button btnApprove;
        private System.Windows.Forms.GroupBox grbForm;
        private System.Windows.Forms.ErrorProvider errProductApproval;
        private System.Windows.Forms.Button btnClose;
        public System.Windows.Forms.DataGridView grdSupplierList;
        private System.Windows.Forms.Button btnreject;
        private System.Windows.Forms.Label lblVouchar;
        private System.Windows.Forms.Label lblVoucharDate;
        private System.Windows.Forms.DateTimePicker dpDop;
        private System.Windows.Forms.Label lblSupplier;
        private System.Windows.Forms.TextBox txtSupplier;
        private System.Windows.Forms.Label lblRemarks;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmsno;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmpicode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmProductname;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmMRPRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmgodown;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPOQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmInvoiceQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmUnitRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmGST;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmGSTAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmNettAmount;
    }
}