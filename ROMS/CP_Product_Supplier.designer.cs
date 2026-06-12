namespace ROMS
{
    partial class CP_Product_Supplier
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CP_Product_Supplier));
            this.errProduct = new System.Windows.Forms.ErrorProvider(this.components);
            this.grpfilter = new System.Windows.Forms.GroupBox();
            this.lblDProductName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbSearchType = new System.Windows.Forms.ComboBox();
            this.lblSupplierCode = new System.Windows.Forms.Label();
            this.lblschedleCode = new System.Windows.Forms.Label();
            this.lblProductcode = new System.Windows.Forms.Label();
            this.lblDSupplierName = new System.Windows.Forms.Label();
            this.lblSubGroupCode = new System.Windows.Forms.Label();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.btnView = new System.Windows.Forms.Button();
            this.txtSupplier = new System.Windows.Forms.TextBox();
            this.DGV_FilterProduct = new System.Windows.Forms.DataGridView();
            this.DGV_SearchGrid = new System.Windows.Forms.DataGridView();
            this.clmdsno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.icode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmpronameenglish = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmdpronametamil = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmprosubgroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmprogroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDPurchaseUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmdstatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grdItemList = new System.Windows.Forms.DataGridView();
            this.picLoader = new System.Windows.Forms.PictureBox();
            this.lblNoRecordsFound = new System.Windows.Forms.Label();
            this.DGV_FilterSupplier = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.errProduct)).BeginInit();
            this.grpfilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_FilterProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_SearchGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdItemList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_FilterSupplier)).BeginInit();
            this.SuspendLayout();
            // 
            // errProduct
            // 
            this.errProduct.ContainerControl = this;
            // 
            // grpfilter
            // 
            this.grpfilter.Controls.Add(this.lblDProductName);
            this.grpfilter.Controls.Add(this.label1);
            this.grpfilter.Controls.Add(this.cmbSearchType);
            this.grpfilter.Controls.Add(this.lblSupplierCode);
            this.grpfilter.Controls.Add(this.lblschedleCode);
            this.grpfilter.Controls.Add(this.lblProductcode);
            this.grpfilter.Controls.Add(this.lblDSupplierName);
            this.grpfilter.Controls.Add(this.lblSubGroupCode);
            this.grpfilter.Controls.Add(this.txtProductName);
            this.grpfilter.Controls.Add(this.btnView);
            this.grpfilter.Controls.Add(this.txtSupplier);
            this.grpfilter.Location = new System.Drawing.Point(12, 12);
            this.grpfilter.Name = "grpfilter";
            this.grpfilter.Size = new System.Drawing.Size(1227, 82);
            this.grpfilter.TabIndex = 1;
            this.grpfilter.TabStop = false;
            this.grpfilter.Text = "Filter By";
            // 
            // lblDProductName
            // 
            this.lblDProductName.AutoSize = true;
            this.lblDProductName.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDProductName.Location = new System.Drawing.Point(140, 22);
            this.lblDProductName.Name = "lblDProductName";
            this.lblDProductName.Size = new System.Drawing.Size(132, 20);
            this.lblDProductName.TabIndex = 111111151;
            this.lblDProductName.Text = "Product Name/PI Code";
            this.lblDProductName.Click += new System.EventHandler(this.lblDProductName_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 20);
            this.label1.TabIndex = 111111158;
            this.label1.Text = "Search Type";
            // 
            // cmbSearchType
            // 
            this.cmbSearchType.FormattingEnabled = true;
            this.cmbSearchType.Location = new System.Drawing.Point(6, 45);
            this.cmbSearchType.Name = "cmbSearchType";
            this.cmbSearchType.Size = new System.Drawing.Size(128, 27);
            this.cmbSearchType.TabIndex = 0;
            this.cmbSearchType.SelectedIndexChanged += new System.EventHandler(this.cmbSearchType_SelectedIndexChanged);
            this.cmbSearchType.Enter += new System.EventHandler(this.cmbSearchType_Enter);
            this.cmbSearchType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbSearchType_KeyDown);
            this.cmbSearchType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbSearchType_KeyPress);
            this.cmbSearchType.Leave += new System.EventHandler(this.cmbSearchType_Leave);
            // 
            // lblSupplierCode
            // 
            this.lblSupplierCode.AutoSize = true;
            this.lblSupplierCode.BackColor = System.Drawing.Color.Green;
            this.lblSupplierCode.Location = new System.Drawing.Point(912, 23);
            this.lblSupplierCode.Name = "lblSupplierCode";
            this.lblSupplierCode.Size = new System.Drawing.Size(16, 20);
            this.lblSupplierCode.TabIndex = 111111156;
            this.lblSupplierCode.Text = "0";
            this.lblSupplierCode.Visible = false;
            // 
            // lblschedleCode
            // 
            this.lblschedleCode.AutoSize = true;
            this.lblschedleCode.BackColor = System.Drawing.Color.LimeGreen;
            this.lblschedleCode.Location = new System.Drawing.Point(890, 23);
            this.lblschedleCode.Name = "lblschedleCode";
            this.lblschedleCode.Size = new System.Drawing.Size(16, 20);
            this.lblschedleCode.TabIndex = 111111155;
            this.lblschedleCode.Text = "0";
            this.lblschedleCode.Visible = false;
            // 
            // lblProductcode
            // 
            this.lblProductcode.AutoSize = true;
            this.lblProductcode.Location = new System.Drawing.Point(263, -3);
            this.lblProductcode.Name = "lblProductcode";
            this.lblProductcode.Size = new System.Drawing.Size(16, 20);
            this.lblProductcode.TabIndex = 111111148;
            this.lblProductcode.Text = "0";
            this.lblProductcode.Visible = false;
            // 
            // lblDSupplierName
            // 
            this.lblDSupplierName.AutoSize = true;
            this.lblDSupplierName.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDSupplierName.Location = new System.Drawing.Point(140, 22);
            this.lblDSupplierName.Name = "lblDSupplierName";
            this.lblDSupplierName.Size = new System.Drawing.Size(87, 20);
            this.lblDSupplierName.TabIndex = 111111154;
            this.lblDSupplierName.Text = "Supplier Name";
            // 
            // lblSubGroupCode
            // 
            this.lblSubGroupCode.AutoSize = true;
            this.lblSubGroupCode.Location = new System.Drawing.Point(524, 18);
            this.lblSubGroupCode.Name = "lblSubGroupCode";
            this.lblSubGroupCode.Size = new System.Drawing.Size(16, 20);
            this.lblSubGroupCode.TabIndex = 111111147;
            this.lblSubGroupCode.Text = "0";
            this.lblSubGroupCode.Visible = false;
            // 
            // txtProductName
            // 
            this.txtProductName.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtProductName.Location = new System.Drawing.Point(140, 45);
            this.txtProductName.MaxLength = 50;
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(361, 27);
            this.txtProductName.TabIndex = 4;
            this.txtProductName.TextChanged += new System.EventHandler(this.txtProductName_TextChanged);
            this.txtProductName.Enter += new System.EventHandler(this.txtProductName_Enter);
            this.txtProductName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtProductName_KeyDown);
            this.txtProductName.Leave += new System.EventHandler(this.txtProductName_Leave);
            // 
            // btnView
            // 
            this.btnView.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnView.Image = global::ROMS.Properties.Resources.view;
            this.btnView.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnView.Location = new System.Drawing.Point(507, 43);
            this.btnView.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(68, 29);
            this.btnView.TabIndex = 6;
            this.btnView.Text = "View";
            this.btnView.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            this.btnView.Enter += new System.EventHandler(this.btnView_Enter);
            this.btnView.Leave += new System.EventHandler(this.btnView_Leave);
            // 
            // txtSupplier
            // 
            this.txtSupplier.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtSupplier.Location = new System.Drawing.Point(140, 45);
            this.txtSupplier.MaxLength = 100;
            this.txtSupplier.Name = "txtSupplier";
            this.txtSupplier.Size = new System.Drawing.Size(361, 27);
            this.txtSupplier.TabIndex = 5;
            this.txtSupplier.TextChanged += new System.EventHandler(this.txtSupplier_TextChanged);
            this.txtSupplier.Enter += new System.EventHandler(this.txtSupplier_Enter);
            this.txtSupplier.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSupplier_KeyDown);
            this.txtSupplier.Leave += new System.EventHandler(this.txtSupplier_Leave);
            // 
            // DGV_FilterProduct
            // 
            this.DGV_FilterProduct.AllowUserToAddRows = false;
            this.DGV_FilterProduct.AllowUserToDeleteRows = false;
            this.DGV_FilterProduct.AllowUserToResizeColumns = false;
            this.DGV_FilterProduct.AllowUserToResizeRows = false;
            this.DGV_FilterProduct.BackgroundColor = System.Drawing.Color.White;
            this.DGV_FilterProduct.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Chocolate;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Chocolate;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_FilterProduct.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DGV_FilterProduct.ColumnHeadersHeight = 30;
            this.DGV_FilterProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGV_FilterProduct.EnableHeadersVisualStyles = false;
            this.DGV_FilterProduct.GridColor = System.Drawing.Color.White;
            this.DGV_FilterProduct.Location = new System.Drawing.Point(152, 85);
            this.DGV_FilterProduct.Name = "DGV_FilterProduct";
            this.DGV_FilterProduct.ReadOnly = true;
            this.DGV_FilterProduct.RowHeadersVisible = false;
            this.DGV_FilterProduct.RowHeadersWidth = 51;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            this.DGV_FilterProduct.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.DGV_FilterProduct.RowTemplate.Height = 25;
            this.DGV_FilterProduct.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV_FilterProduct.Size = new System.Drawing.Size(542, 226);
            this.DGV_FilterProduct.TabIndex = 111111177;
            this.DGV_FilterProduct.Visible = false;
            this.DGV_FilterProduct.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_FilterProduct_CellDoubleClick);
            this.DGV_FilterProduct.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DGV_FilterProduct_KeyDown);
            // 
            // DGV_SearchGrid
            // 
            this.DGV_SearchGrid.AllowUserToAddRows = false;
            this.DGV_SearchGrid.AllowUserToDeleteRows = false;
            this.DGV_SearchGrid.AllowUserToResizeRows = false;
            this.DGV_SearchGrid.BackgroundColor = System.Drawing.Color.White;
            this.DGV_SearchGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(242)))), ((int)(((byte)(213)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_SearchGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.DGV_SearchGrid.ColumnHeadersHeight = 30;
            this.DGV_SearchGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGV_SearchGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmdsno,
            this.icode,
            this.clmpronameenglish,
            this.clmdpronametamil,
            this.clmprosubgroup,
            this.clmprogroup,
            this.clmDPurchaseUnit,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn12,
            this.dataGridViewTextBoxColumn13,
            this.dataGridViewTextBoxColumn14,
            this.dataGridViewTextBoxColumn15,
            this.clmdstatus});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV_SearchGrid.DefaultCellStyle = dataGridViewCellStyle6;
            this.DGV_SearchGrid.EnableHeadersVisualStyles = false;
            this.DGV_SearchGrid.GridColor = System.Drawing.Color.White;
            this.DGV_SearchGrid.Location = new System.Drawing.Point(12, 100);
            this.DGV_SearchGrid.Name = "DGV_SearchGrid";
            this.DGV_SearchGrid.RowHeadersVisible = false;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            this.DGV_SearchGrid.RowsDefaultCellStyle = dataGridViewCellStyle7;
            this.DGV_SearchGrid.RowTemplate.Height = 25;
            this.DGV_SearchGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DGV_SearchGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DGV_SearchGrid.ShowRowErrors = false;
            this.DGV_SearchGrid.Size = new System.Drawing.Size(1227, 56);
            this.DGV_SearchGrid.TabIndex = 111111181;
            this.DGV_SearchGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_SearchGrid_CellEndEdit);
            this.DGV_SearchGrid.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.DGV_SearchGrid_CellPainting);
            this.DGV_SearchGrid.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DGV_SearchGrid_ColumnHeaderMouseClick);
            this.DGV_SearchGrid.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.DGV_SearchGrid_ColumnWidthChanged);
            this.DGV_SearchGrid.CurrentCellDirtyStateChanged += new System.EventHandler(this.DGV_SearchGrid_CurrentCellDirtyStateChanged);
            this.DGV_SearchGrid.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.DGV_SearchGrid_EditingControlShowing);
            this.DGV_SearchGrid.Scroll += new System.Windows.Forms.ScrollEventHandler(this.DGV_SearchGrid_Scroll);
            // 
            // clmdsno
            // 
            this.clmdsno.HeaderText = "S.No.";
            this.clmdsno.Name = "clmdsno";
            this.clmdsno.Width = 60;
            // 
            // icode
            // 
            this.icode.HeaderText = "P.I Code";
            this.icode.Name = "icode";
            // 
            // clmpronameenglish
            // 
            this.clmpronameenglish.HeaderText = "Product Name in English";
            this.clmpronameenglish.Name = "clmpronameenglish";
            this.clmpronameenglish.Width = 200;
            // 
            // clmdpronametamil
            // 
            this.clmdpronametamil.HeaderText = "Product Name in Tamil";
            this.clmdpronametamil.Name = "clmdpronametamil";
            this.clmdpronametamil.Width = 200;
            // 
            // clmprosubgroup
            // 
            this.clmprosubgroup.HeaderText = "Product Subgroup";
            this.clmprosubgroup.Name = "clmprosubgroup";
            this.clmprosubgroup.Width = 150;
            // 
            // clmprogroup
            // 
            this.clmprogroup.HeaderText = "Product Group";
            this.clmprogroup.Name = "clmprogroup";
            this.clmprogroup.Width = 150;
            // 
            // clmDPurchaseUnit
            // 
            this.clmDPurchaseUnit.HeaderText = "Unit";
            this.clmDPurchaseUnit.Name = "clmDPurchaseUnit";
            this.clmDPurchaseUnit.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "R.Rate";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "W.Rate";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.HeaderText = "HSN Name";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.HeaderText = "GST %";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.HeaderText = "Stock Location";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.HeaderText = "Rack";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.HeaderText = "Brand";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.HeaderText = "Pro Type";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            // 
            // clmdstatus
            // 
            this.clmdstatus.HeaderText = "Status";
            this.clmdstatus.Name = "clmdstatus";
            // 
            // grdItemList
            // 
            this.grdItemList.AllowUserToAddRows = false;
            this.grdItemList.AllowUserToDeleteRows = false;
            this.grdItemList.AllowUserToResizeColumns = false;
            this.grdItemList.AllowUserToResizeRows = false;
            this.grdItemList.BackgroundColor = System.Drawing.Color.White;
            this.grdItemList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(242)))), ((int)(((byte)(213)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdItemList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.grdItemList.ColumnHeadersHeight = 30;
            this.grdItemList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdItemList.ColumnHeadersVisible = false;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdItemList.DefaultCellStyle = dataGridViewCellStyle9;
            this.grdItemList.EnableHeadersVisualStyles = false;
            this.grdItemList.GridColor = System.Drawing.Color.White;
            this.grdItemList.Location = new System.Drawing.Point(12, 156);
            this.grdItemList.Name = "grdItemList";
            this.grdItemList.ReadOnly = true;
            this.grdItemList.RowHeadersVisible = false;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.grdItemList.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.grdItemList.RowTemplate.Height = 25;
            this.grdItemList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdItemList.ShowRowErrors = false;
            this.grdItemList.Size = new System.Drawing.Size(1227, 414);
            this.grdItemList.TabIndex = 111111182;
            this.grdItemList.Scroll += new System.Windows.Forms.ScrollEventHandler(this.grdItemList_Scroll);
            // 
            // picLoader
            // 
            this.picLoader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picLoader.ErrorImage = null;
            this.picLoader.Image = global::ROMS.Properties.Resources.Iphone_spinner_2;
            this.picLoader.InitialImage = null;
            this.picLoader.Location = new System.Drawing.Point(12, 156);
            this.picLoader.Name = "picLoader";
            this.picLoader.Size = new System.Drawing.Size(1157, 414);
            this.picLoader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picLoader.TabIndex = 111111183;
            this.picLoader.TabStop = false;
            this.picLoader.Visible = false;
            // 
            // lblNoRecordsFound
            // 
            this.lblNoRecordsFound.AutoSize = true;
            this.lblNoRecordsFound.BackColor = System.Drawing.Color.White;
            this.lblNoRecordsFound.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoRecordsFound.Location = new System.Drawing.Point(572, 353);
            this.lblNoRecordsFound.Name = "lblNoRecordsFound";
            this.lblNoRecordsFound.Size = new System.Drawing.Size(106, 20);
            this.lblNoRecordsFound.TabIndex = 111111184;
            this.lblNoRecordsFound.Text = "No Records Found";
            this.lblNoRecordsFound.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // DGV_FilterSupplier
            // 
            this.DGV_FilterSupplier.AllowUserToAddRows = false;
            this.DGV_FilterSupplier.AllowUserToDeleteRows = false;
            this.DGV_FilterSupplier.AllowUserToResizeColumns = false;
            this.DGV_FilterSupplier.AllowUserToResizeRows = false;
            this.DGV_FilterSupplier.BackgroundColor = System.Drawing.Color.White;
            this.DGV_FilterSupplier.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Chocolate;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Chocolate;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_FilterSupplier.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DGV_FilterSupplier.ColumnHeadersHeight = 30;
            this.DGV_FilterSupplier.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGV_FilterSupplier.EnableHeadersVisualStyles = false;
            this.DGV_FilterSupplier.GridColor = System.Drawing.Color.White;
            this.DGV_FilterSupplier.Location = new System.Drawing.Point(152, 85);
            this.DGV_FilterSupplier.Name = "DGV_FilterSupplier";
            this.DGV_FilterSupplier.ReadOnly = true;
            this.DGV_FilterSupplier.RowHeadersVisible = false;
            this.DGV_FilterSupplier.RowHeadersWidth = 51;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            this.DGV_FilterSupplier.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.DGV_FilterSupplier.RowTemplate.Height = 25;
            this.DGV_FilterSupplier.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV_FilterSupplier.Size = new System.Drawing.Size(435, 226);
            this.DGV_FilterSupplier.TabIndex = 111111185;
            this.DGV_FilterSupplier.Visible = false;
            this.DGV_FilterSupplier.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_FilterSupplier_CellDoubleClick);
            this.DGV_FilterSupplier.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DGV_FilterSupplier_KeyDown);
            // 
            // CP_Product_Supplier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1251, 582);
            this.Controls.Add(this.DGV_FilterSupplier);
            this.Controls.Add(this.lblNoRecordsFound);
            this.Controls.Add(this.DGV_FilterProduct);
            this.Controls.Add(this.grpfilter);
            this.Controls.Add(this.DGV_SearchGrid);
            this.Controls.Add(this.grdItemList);
            this.Controls.Add(this.picLoader);
            this.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CP_Product_Supplier";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Supplier Product Details";
            this.Load += new System.EventHandler(this.CP_Product_Popup_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CP_Product_Popup_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.errProduct)).EndInit();
            this.grpfilter.ResumeLayout(false);
            this.grpfilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_FilterProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_SearchGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdItemList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_FilterSupplier)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ErrorProvider errProduct;
        private System.Windows.Forms.GroupBox grpfilter;
        private System.Windows.Forms.Label lblProductcode;
        private System.Windows.Forms.Label lblSubGroupCode;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Label lblDProductName;
        public System.Windows.Forms.DataGridView DGV_FilterProduct;
        public System.Windows.Forms.DataGridView DGV_SearchGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmdsno;
        private System.Windows.Forms.DataGridViewTextBoxColumn icode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmpronameenglish;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmdpronametamil;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmprosubgroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmprogroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDPurchaseUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmdstatus;
        public System.Windows.Forms.DataGridView grdItemList;
        public System.Windows.Forms.PictureBox picLoader;
        private System.Windows.Forms.Label lblNoRecordsFound;
        public System.Windows.Forms.DataGridView DGV_FilterSupplier;
        private System.Windows.Forms.TextBox txtSupplier;
        private System.Windows.Forms.Label lblDSupplierName;
        private System.Windows.Forms.ComboBox cmbSearchType;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label lblSupplierCode;
        public System.Windows.Forms.Label lblschedleCode;
    }
}