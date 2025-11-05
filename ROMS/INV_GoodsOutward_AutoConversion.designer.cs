namespace ROMS
{
    partial class INV_GoodsOutward_AutoConversion
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(INV_GoodsOutward_AutoConversion));
            this.errUnit = new System.Windows.Forms.ErrorProvider(this.components);
            this.grdGOConversion = new System.Windows.Forms.DataGridView();
            this.lblNoRecordsFound = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblExpiryDate = new System.Windows.Forms.Label();
            this.lblTransferQty = new System.Windows.Forms.Label();
            this.lblParentQty = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblParentTransferUnit = new System.Windows.Forms.Label();
            this.lblProductName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblParentStkQty = new System.Windows.Forms.Label();
            this.lblParentStkUnit = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblRequiredQty = new System.Windows.Forms.Label();
            this.lblRequiredUnit = new System.Windows.Forms.Label();
            this.lblTransUnit = new System.Windows.Forms.Label();
            this.clmSno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPIcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmProduct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmBatchDetails = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmMRP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmExpiryDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmBatchNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmRack = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmUPP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmUPPValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmConversionQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmActualQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmChildUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTransferQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPRID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSLID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmRKID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmUTID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.errUnit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdGOConversion)).BeginInit();
            this.SuspendLayout();
            // 
            // errUnit
            // 
            this.errUnit.ContainerControl = this;
            // 
            // grdGOConversion
            // 
            this.grdGOConversion.AllowUserToAddRows = false;
            this.grdGOConversion.AllowUserToDeleteRows = false;
            this.grdGOConversion.AllowUserToResizeColumns = false;
            this.grdGOConversion.AllowUserToResizeRows = false;
            this.grdGOConversion.BackgroundColor = System.Drawing.Color.White;
            this.grdGOConversion.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdGOConversion.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdGOConversion.ColumnHeadersHeight = 45;
            this.grdGOConversion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdGOConversion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmSno,
            this.clmPIcode,
            this.clmProduct,
            this.clmBatchDetails,
            this.clmMRP,
            this.clmExpiryDate,
            this.clmBatchNo,
            this.clmLocation,
            this.clmRack,
            this.clmUPP,
            this.clmUPPValue,
            this.clmQuantity,
            this.clmUnit,
            this.clmConversionQty,
            this.clmActualQty,
            this.clmChildUnit,
            this.clmTransferQty,
            this.clmPRID,
            this.clmSLID,
            this.clmRKID,
            this.clmUTID});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdGOConversion.DefaultCellStyle = dataGridViewCellStyle6;
            this.grdGOConversion.EnableHeadersVisualStyles = false;
            this.grdGOConversion.GridColor = System.Drawing.Color.White;
            this.grdGOConversion.Location = new System.Drawing.Point(12, 117);
            this.grdGOConversion.Name = "grdGOConversion";
            this.grdGOConversion.RowHeadersVisible = false;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.White;
            this.grdGOConversion.RowsDefaultCellStyle = dataGridViewCellStyle7;
            this.grdGOConversion.RowTemplate.Height = 25;
            this.grdGOConversion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.grdGOConversion.Size = new System.Drawing.Size(1220, 328);
            this.grdGOConversion.TabIndex = 1111145;
            this.grdGOConversion.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdGoodsOutward_CellEndEdit);
            this.grdGOConversion.CurrentCellDirtyStateChanged += new System.EventHandler(this.grdGoodsOutward_CurrentCellDirtyStateChanged);
            this.grdGOConversion.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.grdGoodsOutward_EditingControlShowing);
            this.grdGOConversion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdGOConversion_KeyDown);
            // 
            // lblNoRecordsFound
            // 
            this.lblNoRecordsFound.AutoSize = true;
            this.lblNoRecordsFound.BackColor = System.Drawing.Color.White;
            this.lblNoRecordsFound.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoRecordsFound.Location = new System.Drawing.Point(569, 271);
            this.lblNoRecordsFound.Name = "lblNoRecordsFound";
            this.lblNoRecordsFound.Size = new System.Drawing.Size(106, 20);
            this.lblNoRecordsFound.TabIndex = 1111146;
            this.lblNoRecordsFound.Text = "No Records Found";
            this.lblNoRecordsFound.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::ROMS.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(1163, 475);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(69, 33);
            this.btnClose.TabIndex = 1111147;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::ROMS.Properties.Resources.save;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(1073, 475);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(84, 33);
            this.btnSave.TabIndex = 1111148;
            this.btnSave.Text = "Convert";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.Enter += new System.EventHandler(this.BrnPrint_Enter);
            this.btnSave.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BrnPrint_KeyDown);
            this.btnSave.Leave += new System.EventHandler(this.BrnPrint_Leave);
            // 
            // lblExpiryDate
            // 
            this.lblExpiryDate.AutoSize = true;
            this.lblExpiryDate.Location = new System.Drawing.Point(911, 450);
            this.lblExpiryDate.Name = "lblExpiryDate";
            this.lblExpiryDate.Size = new System.Drawing.Size(126, 20);
            this.lblExpiryDate.TabIndex = 1111149;
            this.lblExpiryDate.Text = "Total Consumed Qty : ";
            // 
            // lblTransferQty
            // 
            this.lblTransferQty.AutoSize = true;
            this.lblTransferQty.Font = new System.Drawing.Font("Oswald Regular", 12.25F);
            this.lblTransferQty.Location = new System.Drawing.Point(1029, 448);
            this.lblTransferQty.Name = "lblTransferQty";
            this.lblTransferQty.Size = new System.Drawing.Size(18, 24);
            this.lblTransferQty.TabIndex = 1111150;
            this.lblTransferQty.Text = "0";
            // 
            // lblParentQty
            // 
            this.lblParentQty.AutoSize = true;
            this.lblParentQty.Font = new System.Drawing.Font("Oswald Regular", 12.25F);
            this.lblParentQty.Location = new System.Drawing.Point(143, 65);
            this.lblParentQty.Name = "lblParentQty";
            this.lblParentQty.Size = new System.Drawing.Size(18, 24);
            this.lblParentQty.TabIndex = 1111152;
            this.lblParentQty.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 20);
            this.label2.TabIndex = 1111151;
            this.label2.Text = "Product Name             : ";
            // 
            // lblParentTransferUnit
            // 
            this.lblParentTransferUnit.AutoSize = true;
            this.lblParentTransferUnit.Font = new System.Drawing.Font("Oswald Regular", 12.25F);
            this.lblParentTransferUnit.Location = new System.Drawing.Point(185, 65);
            this.lblParentTransferUnit.Name = "lblParentTransferUnit";
            this.lblParentTransferUnit.Size = new System.Drawing.Size(32, 24);
            this.lblParentTransferUnit.TabIndex = 1111153;
            this.lblParentTransferUnit.Text = "Nos";
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductName.Location = new System.Drawing.Point(143, 17);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(112, 20);
            this.lblProductName.TabIndex = 1111154;
            this.lblProductName.Text = "Product Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 20);
            this.label1.TabIndex = 1111155;
            this.label1.Text = "Stock Qty                     :";
            // 
            // lblParentStkQty
            // 
            this.lblParentStkQty.AutoSize = true;
            this.lblParentStkQty.Font = new System.Drawing.Font("Oswald Regular", 12.25F);
            this.lblParentStkQty.Location = new System.Drawing.Point(143, 41);
            this.lblParentStkQty.Name = "lblParentStkQty";
            this.lblParentStkQty.Size = new System.Drawing.Size(18, 24);
            this.lblParentStkQty.TabIndex = 1111156;
            this.lblParentStkQty.Text = "0";
            // 
            // lblParentStkUnit
            // 
            this.lblParentStkUnit.AutoSize = true;
            this.lblParentStkUnit.Font = new System.Drawing.Font("Oswald Regular", 12.25F);
            this.lblParentStkUnit.Location = new System.Drawing.Point(185, 41);
            this.lblParentStkUnit.Name = "lblParentStkUnit";
            this.lblParentStkUnit.Size = new System.Drawing.Size(32, 24);
            this.lblParentStkUnit.TabIndex = 1111157;
            this.lblParentStkUnit.Text = "Nos";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 20);
            this.label4.TabIndex = 1111158;
            this.label4.Text = "Outward Qty                :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 20);
            this.label5.TabIndex = 1111159;
            this.label5.Text = "Conversion Required  :";
            // 
            // lblRequiredQty
            // 
            this.lblRequiredQty.AutoSize = true;
            this.lblRequiredQty.Font = new System.Drawing.Font("Oswald Regular", 12.25F);
            this.lblRequiredQty.Location = new System.Drawing.Point(143, 90);
            this.lblRequiredQty.Name = "lblRequiredQty";
            this.lblRequiredQty.Size = new System.Drawing.Size(18, 24);
            this.lblRequiredQty.TabIndex = 1111160;
            this.lblRequiredQty.Text = "0";
            // 
            // lblRequiredUnit
            // 
            this.lblRequiredUnit.AutoSize = true;
            this.lblRequiredUnit.Font = new System.Drawing.Font("Oswald Regular", 12.25F);
            this.lblRequiredUnit.Location = new System.Drawing.Point(185, 90);
            this.lblRequiredUnit.Name = "lblRequiredUnit";
            this.lblRequiredUnit.Size = new System.Drawing.Size(32, 24);
            this.lblRequiredUnit.TabIndex = 1111161;
            this.lblRequiredUnit.Text = "Nos";
            // 
            // lblTransUnit
            // 
            this.lblTransUnit.AutoSize = true;
            this.lblTransUnit.Font = new System.Drawing.Font("Oswald Regular", 12.25F);
            this.lblTransUnit.Location = new System.Drawing.Point(1073, 448);
            this.lblTransUnit.Name = "lblTransUnit";
            this.lblTransUnit.Size = new System.Drawing.Size(32, 24);
            this.lblTransUnit.TabIndex = 1111162;
            this.lblTransUnit.Text = "Nos";
            // 
            // clmSno
            // 
            this.clmSno.HeaderText = "S.No.";
            this.clmSno.Name = "clmSno";
            this.clmSno.ReadOnly = true;
            this.clmSno.Width = 50;
            // 
            // clmPIcode
            // 
            this.clmPIcode.HeaderText = "P.I Code";
            this.clmPIcode.Name = "clmPIcode";
            this.clmPIcode.ReadOnly = true;
            this.clmPIcode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // clmProduct
            // 
            this.clmProduct.HeaderText = "Product Name";
            this.clmProduct.Name = "clmProduct";
            this.clmProduct.ReadOnly = true;
            this.clmProduct.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmProduct.Width = 240;
            // 
            // clmBatchDetails
            // 
            this.clmBatchDetails.HeaderText = "Batch Details";
            this.clmBatchDetails.Name = "clmBatchDetails";
            this.clmBatchDetails.ReadOnly = true;
            this.clmBatchDetails.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmBatchDetails.Width = 290;
            // 
            // clmMRP
            // 
            this.clmMRP.HeaderText = "MRP";
            this.clmMRP.Name = "clmMRP";
            this.clmMRP.ReadOnly = true;
            this.clmMRP.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmMRP.Visible = false;
            this.clmMRP.Width = 90;
            // 
            // clmExpiryDate
            // 
            this.clmExpiryDate.HeaderText = "Expiry Date";
            this.clmExpiryDate.Name = "clmExpiryDate";
            this.clmExpiryDate.ReadOnly = true;
            this.clmExpiryDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmExpiryDate.Visible = false;
            this.clmExpiryDate.Width = 90;
            // 
            // clmBatchNo
            // 
            this.clmBatchNo.HeaderText = "Batch No.";
            this.clmBatchNo.Name = "clmBatchNo";
            this.clmBatchNo.ReadOnly = true;
            this.clmBatchNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmBatchNo.Visible = false;
            this.clmBatchNo.Width = 80;
            // 
            // clmLocation
            // 
            this.clmLocation.HeaderText = "Location";
            this.clmLocation.Name = "clmLocation";
            this.clmLocation.ReadOnly = true;
            this.clmLocation.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmLocation.Visible = false;
            // 
            // clmRack
            // 
            this.clmRack.HeaderText = "Rack";
            this.clmRack.Name = "clmRack";
            this.clmRack.ReadOnly = true;
            this.clmRack.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmRack.Visible = false;
            this.clmRack.Width = 70;
            // 
            // clmUPP
            // 
            this.clmUPP.HeaderText = "UPP";
            this.clmUPP.Name = "clmUPP";
            this.clmUPP.ReadOnly = true;
            this.clmUPP.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmUPP.Width = 80;
            // 
            // clmUPPValue
            // 
            this.clmUPPValue.HeaderText = "UPPValue";
            this.clmUPPValue.Name = "clmUPPValue";
            this.clmUPPValue.ReadOnly = true;
            this.clmUPPValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmUPPValue.Visible = false;
            // 
            // clmQuantity
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clmQuantity.DefaultCellStyle = dataGridViewCellStyle2;
            this.clmQuantity.HeaderText = "Stock Qty";
            this.clmQuantity.Name = "clmQuantity";
            this.clmQuantity.ReadOnly = true;
            this.clmQuantity.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmQuantity.Width = 90;
            // 
            // clmUnit
            // 
            this.clmUnit.HeaderText = "Unit";
            this.clmUnit.Name = "clmUnit";
            this.clmUnit.ReadOnly = true;
            this.clmUnit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmUnit.Width = 45;
            // 
            // clmConversionQty
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.PaleGreen;
            this.clmConversionQty.DefaultCellStyle = dataGridViewCellStyle3;
            this.clmConversionQty.HeaderText = "Convert Child Qty";
            this.clmConversionQty.MaxInputLength = 5;
            this.clmConversionQty.Name = "clmConversionQty";
            this.clmConversionQty.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmConversionQty.Width = 80;
            // 
            // clmActualQty
            // 
            this.clmActualQty.HeaderText = "Convert Parent Qty";
            this.clmActualQty.Name = "clmActualQty";
            this.clmActualQty.ReadOnly = true;
            this.clmActualQty.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmActualQty.Width = 80;
            // 
            // clmChildUnit
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clmChildUnit.DefaultCellStyle = dataGridViewCellStyle4;
            this.clmChildUnit.HeaderText = "Unit";
            this.clmChildUnit.Name = "clmChildUnit";
            this.clmChildUnit.ReadOnly = true;
            this.clmChildUnit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmChildUnit.Width = 45;
            // 
            // clmTransferQty
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.PaleGreen;
            this.clmTransferQty.DefaultCellStyle = dataGridViewCellStyle5;
            this.clmTransferQty.HeaderText = "Consumed Parent Qty";
            this.clmTransferQty.MaxInputLength = 5;
            this.clmTransferQty.Name = "clmTransferQty";
            this.clmTransferQty.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmTransferQty.Width = 80;
            // 
            // clmPRID
            // 
            this.clmPRID.HeaderText = "PRID";
            this.clmPRID.Name = "clmPRID";
            this.clmPRID.ReadOnly = true;
            this.clmPRID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmPRID.Visible = false;
            this.clmPRID.Width = 5;
            // 
            // clmSLID
            // 
            this.clmSLID.HeaderText = "SLID";
            this.clmSLID.Name = "clmSLID";
            this.clmSLID.ReadOnly = true;
            this.clmSLID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmSLID.Visible = false;
            this.clmSLID.Width = 5;
            // 
            // clmRKID
            // 
            this.clmRKID.HeaderText = "RKID";
            this.clmRKID.Name = "clmRKID";
            this.clmRKID.ReadOnly = true;
            this.clmRKID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmRKID.Visible = false;
            this.clmRKID.Width = 5;
            // 
            // clmUTID
            // 
            this.clmUTID.HeaderText = "UTID";
            this.clmUTID.Name = "clmUTID";
            this.clmUTID.ReadOnly = true;
            this.clmUTID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmUTID.Visible = false;
            this.clmUTID.Width = 5;
            // 
            // INV_GoodsOutward_AutoConversion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1244, 522);
            this.Controls.Add(this.lblTransUnit);
            this.Controls.Add(this.lblRequiredUnit);
            this.Controls.Add(this.lblRequiredQty);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblParentStkUnit);
            this.Controls.Add(this.lblParentStkQty);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblProductName);
            this.Controls.Add(this.lblParentTransferUnit);
            this.Controls.Add(this.lblParentQty);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblTransferQty);
            this.Controls.Add(this.lblExpiryDate);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblNoRecordsFound);
            this.Controls.Add(this.grdGOConversion);
            this.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "INV_GoodsOutward_AutoConversion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Child to Parent Auto Conversion";
            this.Load += new System.EventHandler(this.PUR_PODamaged_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PUR_PODamaged_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.errUnit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdGOConversion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ErrorProvider errUnit;
        public System.Windows.Forms.DataGridView grdGOConversion;
        private System.Windows.Forms.Label lblNoRecordsFound;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblExpiryDate;
        private System.Windows.Forms.Label lblTransferQty;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label lblParentQty;
        public System.Windows.Forms.Label lblParentTransferUnit;
        public System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label lblParentStkQty;
        public System.Windows.Forms.Label lblParentStkUnit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label lblRequiredQty;
        public System.Windows.Forms.Label lblRequiredUnit;
        public System.Windows.Forms.Label lblTransUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSno;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPIcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmBatchDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmMRP;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmExpiryDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmBatchNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmLocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmRack;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmUPP;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmUPPValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmConversionQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmActualQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmChildUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTransferQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPRID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSLID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmRKID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmUTID;
    }
}