namespace ROMS
{
    partial class INV_GodownOutward
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(INV_GodownOutward));
            this.errGroup = new System.Windows.Forms.ErrorProvider(this.components);
            this.grbgodownoutward = new System.Windows.Forms.GroupBox();
            this.txtOutwardNo = new System.Windows.Forms.TextBox();
            this.cmbGodown = new System.Windows.Forms.ComboBox();
            this.dtpoutwarddate = new System.Windows.Forms.DateTimePicker();
            this.lblGodown = new System.Windows.Forms.Label();
            this.lbloutwarddate = new System.Windows.Forms.Label();
            this.cmbConcern = new System.Windows.Forms.ComboBox();
            this.lblConcern = new System.Windows.Forms.Label();
            this.lbloutwardno = new System.Windows.Forms.Label();
            this.grpproductname = new System.Windows.Forms.GroupBox();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.lblRequestedQuantity = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.lblStock = new System.Windows.Forms.Label();
            this.txtProduct = new System.Windows.Forms.TextBox();
            this.txtActualQty = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Label();
            this.txtPoQty = new System.Windows.Forms.TextBox();
            this.lblProductName = new System.Windows.Forms.Label();
            this.DGV_inward = new System.Windows.Forms.DataGridView();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.lblRemark = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.clmdsno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmicode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmproductname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmbatch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmexpirydate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmunit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.errGroup)).BeginInit();
            this.grbgodownoutward.SuspendLayout();
            this.grpproductname.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_inward)).BeginInit();
            this.SuspendLayout();
            // 
            // errGroup
            // 
            this.errGroup.ContainerControl = this;
            // 
            // grbgodownoutward
            // 
            this.grbgodownoutward.Controls.Add(this.txtOutwardNo);
            this.grbgodownoutward.Controls.Add(this.cmbGodown);
            this.grbgodownoutward.Controls.Add(this.dtpoutwarddate);
            this.grbgodownoutward.Controls.Add(this.lblGodown);
            this.grbgodownoutward.Controls.Add(this.lbloutwarddate);
            this.grbgodownoutward.Controls.Add(this.cmbConcern);
            this.grbgodownoutward.Controls.Add(this.lblConcern);
            this.grbgodownoutward.Controls.Add(this.lbloutwardno);
            this.grbgodownoutward.Location = new System.Drawing.Point(22, 13);
            this.grbgodownoutward.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbgodownoutward.Name = "grbgodownoutward";
            this.grbgodownoutward.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbgodownoutward.Size = new System.Drawing.Size(751, 70);
            this.grbgodownoutward.TabIndex = 958806;
            this.grbgodownoutward.TabStop = false;
            // 
            // txtOutwardNo
            // 
            this.txtOutwardNo.Location = new System.Drawing.Point(371, 36);
            this.txtOutwardNo.Name = "txtOutwardNo";
            this.txtOutwardNo.ReadOnly = true;
            this.txtOutwardNo.Size = new System.Drawing.Size(161, 27);
            this.txtOutwardNo.TabIndex = 89;
            // 
            // cmbGodown
            // 
            this.cmbGodown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGodown.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbGodown.FormattingEnabled = true;
            this.cmbGodown.Location = new System.Drawing.Point(115, 36);
            this.cmbGodown.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbGodown.Name = "cmbGodown";
            this.cmbGodown.Size = new System.Drawing.Size(135, 27);
            this.cmbGodown.TabIndex = 88;
            // 
            // dtpoutwarddate
            // 
            this.dtpoutwarddate.CustomFormat = "dd/MM/yyyy";
            this.dtpoutwarddate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpoutwarddate.Location = new System.Drawing.Point(257, 36);
            this.dtpoutwarddate.Name = "dtpoutwarddate";
            this.dtpoutwarddate.Size = new System.Drawing.Size(107, 27);
            this.dtpoutwarddate.TabIndex = 87;
            // 
            // lblGodown
            // 
            this.lblGodown.AutoSize = true;
            this.lblGodown.Location = new System.Drawing.Point(115, 13);
            this.lblGodown.Name = "lblGodown";
            this.lblGodown.Size = new System.Drawing.Size(52, 20);
            this.lblGodown.TabIndex = 86;
            this.lblGodown.Text = "Godown";
            // 
            // lbloutwarddate
            // 
            this.lbloutwarddate.AutoSize = true;
            this.lbloutwarddate.Location = new System.Drawing.Point(257, 14);
            this.lbloutwarddate.Name = "lbloutwarddate";
            this.lbloutwarddate.Size = new System.Drawing.Size(84, 20);
            this.lbloutwarddate.TabIndex = 84;
            this.lbloutwarddate.Text = "Outward Date";
            // 
            // cmbConcern
            // 
            this.cmbConcern.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbConcern.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbConcern.FormattingEnabled = true;
            this.cmbConcern.Location = new System.Drawing.Point(13, 36);
            this.cmbConcern.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbConcern.Name = "cmbConcern";
            this.cmbConcern.Size = new System.Drawing.Size(94, 27);
            this.cmbConcern.TabIndex = 73;
            // 
            // lblConcern
            // 
            this.lblConcern.AutoSize = true;
            this.lblConcern.Location = new System.Drawing.Point(13, 14);
            this.lblConcern.Name = "lblConcern";
            this.lblConcern.Size = new System.Drawing.Size(54, 20);
            this.lblConcern.TabIndex = 70;
            this.lblConcern.Text = "Concern";
            // 
            // lbloutwardno
            // 
            this.lbloutwardno.AutoSize = true;
            this.lbloutwardno.Location = new System.Drawing.Point(371, 14);
            this.lbloutwardno.Name = "lbloutwardno";
            this.lbloutwardno.Size = new System.Drawing.Size(76, 20);
            this.lbloutwardno.TabIndex = 68;
            this.lbloutwardno.Text = "Outward No.";
            // 
            // grpproductname
            // 
            this.grpproductname.Controls.Add(this.lblQuantity);
            this.grpproductname.Controls.Add(this.lblRequestedQuantity);
            this.grpproductname.Controls.Add(this.comboBox1);
            this.grpproductname.Controls.Add(this.lblStock);
            this.grpproductname.Controls.Add(this.txtProduct);
            this.grpproductname.Controls.Add(this.txtActualQty);
            this.grpproductname.Controls.Add(this.btnAdd);
            this.grpproductname.Controls.Add(this.txtPoQty);
            this.grpproductname.Controls.Add(this.lblProductName);
            this.grpproductname.Location = new System.Drawing.Point(20, 90);
            this.grpproductname.Name = "grpproductname";
            this.grpproductname.Size = new System.Drawing.Size(753, 77);
            this.grpproductname.TabIndex = 958807;
            this.grpproductname.TabStop = false;
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(626, 17);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(56, 20);
            this.lblQuantity.TabIndex = 958822;
            this.lblQuantity.Text = "Quantity";
            // 
            // lblRequestedQuantity
            // 
            this.lblRequestedQuantity.AutoSize = true;
            this.lblRequestedQuantity.Location = new System.Drawing.Point(537, 17);
            this.lblRequestedQuantity.Name = "lblRequestedQuantity";
            this.lblRequestedQuantity.Size = new System.Drawing.Size(89, 20);
            this.lblRequestedQuantity.TabIndex = 958821;
            this.lblRequestedQuantity.Text = "Requested Qty";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(371, 40);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(161, 27);
            this.comboBox1.TabIndex = 88;
            // 
            // lblStock
            // 
            this.lblStock.AutoSize = true;
            this.lblStock.Location = new System.Drawing.Point(371, 17);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(97, 20);
            this.lblStock.TabIndex = 958820;
            this.lblStock.Text = "Stock T.Stk-DOP";
            // 
            // txtProduct
            // 
            this.txtProduct.Location = new System.Drawing.Point(13, 40);
            this.txtProduct.Name = "txtProduct";
            this.txtProduct.Size = new System.Drawing.Size(351, 27);
            this.txtProduct.TabIndex = 82;
            // 
            // txtActualQty
            // 
            this.txtActualQty.Location = new System.Drawing.Point(626, 40);
            this.txtActualQty.Name = "txtActualQty";
            this.txtActualQty.Size = new System.Drawing.Size(69, 27);
            this.txtActualQty.TabIndex = 81;
            // 
            // btnAdd
            // 
            this.btnAdd.Image = global::ROMS.Properties.Resources.plus;
            this.btnAdd.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAdd.Location = new System.Drawing.Point(701, 40);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(21, 22);
            this.btnAdd.TabIndex = 958800;
            this.btnAdd.Text = "        ";
            // 
            // txtPoQty
            // 
            this.txtPoQty.Location = new System.Drawing.Point(541, 40);
            this.txtPoQty.Name = "txtPoQty";
            this.txtPoQty.Size = new System.Drawing.Size(69, 27);
            this.txtPoQty.TabIndex = 79;
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Location = new System.Drawing.Point(13, 17);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(134, 20);
            this.lblProductName.TabIndex = 28;
            this.lblProductName.Text = "Product Name/P.I Code";
            // 
            // DGV_inward
            // 
            this.DGV_inward.AllowUserToAddRows = false;
            this.DGV_inward.AllowUserToDeleteRows = false;
            this.DGV_inward.AllowUserToResizeRows = false;
            this.DGV_inward.BackgroundColor = System.Drawing.Color.White;
            this.DGV_inward.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(242)))), ((int)(((byte)(213)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_inward.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DGV_inward.ColumnHeadersHeight = 30;
            this.DGV_inward.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGV_inward.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmdsno,
            this.clmicode,
            this.clmproductname,
            this.clmbatch,
            this.clmexpirydate,
            this.clmunit});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV_inward.DefaultCellStyle = dataGridViewCellStyle2;
            this.DGV_inward.EnableHeadersVisualStyles = false;
            this.DGV_inward.GridColor = System.Drawing.Color.White;
            this.DGV_inward.Location = new System.Drawing.Point(22, 184);
            this.DGV_inward.Name = "DGV_inward";
            this.DGV_inward.RowHeadersVisible = false;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.DGV_inward.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.DGV_inward.RowTemplate.Height = 25;
            this.DGV_inward.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DGV_inward.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DGV_inward.ShowRowErrors = false;
            this.DGV_inward.Size = new System.Drawing.Size(753, 372);
            this.DGV_inward.TabIndex = 958810;
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(92, 572);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(479, 50);
            this.txtRemark.TabIndex = 958813;
            // 
            // lblRemark
            // 
            this.lblRemark.AutoSize = true;
            this.lblRemark.Location = new System.Drawing.Point(33, 574);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.Size = new System.Drawing.Size(56, 20);
            this.lblRemark.TabIndex = 958816;
            this.lblRemark.Text = "Remarks";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnSave.Image = global::ROMS.Properties.Resources.save;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(638, 572);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(66, 29);
            this.btnSave.TabIndex = 958814;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnClose.Image = global::ROMS.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(709, 572);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(66, 29);
            this.btnClose.TabIndex = 958815;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click_1);
            // 
            // clmdsno
            // 
            this.clmdsno.HeaderText = "S.No.";
            this.clmdsno.Name = "clmdsno";
            this.clmdsno.Width = 50;
            // 
            // clmicode
            // 
            this.clmicode.HeaderText = "P.I Code";
            this.clmicode.Name = "clmicode";
            // 
            // clmproductname
            // 
            this.clmproductname.HeaderText = "Product Name";
            this.clmproductname.Name = "clmproductname";
            this.clmproductname.Width = 300;
            // 
            // clmbatch
            // 
            this.clmbatch.HeaderText = "Requested Qty";
            this.clmbatch.Name = "clmbatch";
            // 
            // clmexpirydate
            // 
            this.clmexpirydate.HeaderText = "Outward Qty";
            this.clmexpirydate.Name = "clmexpirydate";
            // 
            // clmunit
            // 
            this.clmunit.HeaderText = "Unit";
            this.clmunit.Name = "clmunit";
            this.clmunit.Width = 70;
            // 
            // INV_GodownOutward
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(797, 636);
            this.Controls.Add(this.txtRemark);
            this.Controls.Add(this.lblRemark);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.DGV_inward);
            this.Controls.Add(this.grpproductname);
            this.Controls.Add(this.grbgodownoutward);
            this.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "INV_GodownOutward";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Godown Outward";
            this.Load += new System.EventHandler(this.CP_Rack_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CP_Rack_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.errGroup)).EndInit();
            this.grbgodownoutward.ResumeLayout(false);
            this.grbgodownoutward.PerformLayout();
            this.grpproductname.ResumeLayout(false);
            this.grpproductname.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_inward)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ErrorProvider errGroup;
        private System.Windows.Forms.GroupBox grbgodownoutward;
        private System.Windows.Forms.ComboBox cmbGodown;
        private System.Windows.Forms.DateTimePicker dtpoutwarddate;
        private System.Windows.Forms.Label lblGodown;
        private System.Windows.Forms.Label lbloutwarddate;
        private System.Windows.Forms.ComboBox cmbConcern;
        private System.Windows.Forms.Label lblConcern;
        private System.Windows.Forms.Label lbloutwardno;
        private System.Windows.Forms.GroupBox grpproductname;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Label lblRequestedQuantity;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.TextBox txtProduct;
        private System.Windows.Forms.TextBox txtActualQty;
        internal System.Windows.Forms.Label btnAdd;
        private System.Windows.Forms.TextBox txtPoQty;
        private System.Windows.Forms.Label lblProductName;
        public System.Windows.Forms.DataGridView DGV_inward;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label lblRemark;
        public System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtOutwardNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmdsno;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmicode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmproductname;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmbatch;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmexpirydate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmunit;
    }
}