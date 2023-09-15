namespace ROMS
{
    partial class CP_RackGroup
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CP_RackGroup));
            this.grbform = new System.Windows.Forms.GroupBox();
            this.Add = new System.Windows.Forms.Button();
            this.grdSelectedRack = new System.Windows.Forms.DataGridView();
            this.columnSNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmRack = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTotalProducts = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmRemoveRack = new System.Windows.Forms.DataGridViewImageColumn();
            this.btnView = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.chkRack = new System.Windows.Forms.CheckBox();
            this.lblTotalProduct = new System.Windows.Forms.Label();
            this.lblNoofproducts = new System.Windows.Forms.Label();
            this.grdRack = new System.Windows.Forms.DataGridView();
            this.txtRackGroupName = new System.Windows.Forms.TextBox();
            this.cmbStockLocation = new System.Windows.Forms.ComboBox();
            this.txtDRackGroup = new System.Windows.Forms.TextBox();
            this.cmbConcern = new System.Windows.Forms.ComboBox();
            this.txtConcern = new System.Windows.Forms.TextBox();
            this.pnlStatus = new System.Windows.Forms.Panel();
            this.rbActive = new System.Windows.Forms.RadioButton();
            this.rbInactive = new System.Windows.Forms.RadioButton();
            this.epRackGroup = new System.Windows.Forms.ErrorProvider(this.components);
            this.grpUserList = new System.Windows.Forms.GroupBox();
            this.lvStaffName = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnAdd = new System.Windows.Forms.Button();
            this.grdStaffDetails = new System.Windows.Forms.DataGridView();
            this.txtStaffName = new System.Windows.Forms.TextBox();
            this.txtDUserName = new System.Windows.Forms.TextBox();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.clmSno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmStaffName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmUserId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmremove = new System.Windows.Forms.DataGridViewImageColumn();
            this.grbform.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSelectedRack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdRack)).BeginInit();
            this.pnlStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epRackGroup)).BeginInit();
            this.grpUserList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdStaffDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // grbform
            // 
            this.grbform.Controls.Add(this.Add);
            this.grbform.Controls.Add(this.grdSelectedRack);
            this.grbform.Controls.Add(this.btnView);
            this.grbform.Controls.Add(this.label1);
            this.grbform.Controls.Add(this.chkRack);
            this.grbform.Controls.Add(this.lblTotalProduct);
            this.grbform.Controls.Add(this.lblNoofproducts);
            this.grbform.Controls.Add(this.grdRack);
            this.grbform.Controls.Add(this.txtRackGroupName);
            this.grbform.Controls.Add(this.cmbStockLocation);
            this.grbform.Controls.Add(this.txtDRackGroup);
            this.grbform.Controls.Add(this.cmbConcern);
            this.grbform.Controls.Add(this.txtConcern);
            this.grbform.Location = new System.Drawing.Point(12, 11);
            this.grbform.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbform.Name = "grbform";
            this.grbform.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbform.Size = new System.Drawing.Size(769, 481);
            this.grbform.TabIndex = 0;
            this.grbform.TabStop = false;
            // 
            // Add
            // 
            this.Add.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.Add.Image = global::ROMS.Properties.Resources.add;
            this.Add.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Add.Location = new System.Drawing.Point(369, 291);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(31, 29);
            this.Add.TabIndex = 4;
            this.Add.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Add.UseVisualStyleBackColor = true;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            this.Add.Enter += new System.EventHandler(this.Add_Enter);
            this.Add.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Add_KeyDown);
            this.Add.Leave += new System.EventHandler(this.Add_Leave);
            // 
            // grdSelectedRack
            // 
            this.grdSelectedRack.AllowUserToAddRows = false;
            this.grdSelectedRack.AllowUserToDeleteRows = false;
            this.grdSelectedRack.AllowUserToResizeRows = false;
            this.grdSelectedRack.BackgroundColor = System.Drawing.Color.White;
            this.grdSelectedRack.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdSelectedRack.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdSelectedRack.ColumnHeadersHeight = 30;
            this.grdSelectedRack.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdSelectedRack.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnSNo,
            this.clmRack,
            this.clmDescription,
            this.clmTotalProducts,
            this.ID,
            this.clmRemoveRack});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdSelectedRack.DefaultCellStyle = dataGridViewCellStyle2;
            this.grdSelectedRack.EnableHeadersVisualStyles = false;
            this.grdSelectedRack.GridColor = System.Drawing.Color.White;
            this.grdSelectedRack.Location = new System.Drawing.Point(405, 149);
            this.grdSelectedRack.Name = "grdSelectedRack";
            this.grdSelectedRack.ReadOnly = true;
            this.grdSelectedRack.RowHeadersVisible = false;
            this.grdSelectedRack.RowHeadersWidth = 70;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.grdSelectedRack.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.grdSelectedRack.RowTemplate.Height = 25;
            this.grdSelectedRack.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdSelectedRack.ShowRowErrors = false;
            this.grdSelectedRack.Size = new System.Drawing.Size(347, 314);
            this.grdSelectedRack.TabIndex = 61454;
            this.grdSelectedRack.TabStop = false;
            this.grdSelectedRack.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrdSelectedRack_CellContentClick);
            this.grdSelectedRack.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.GrdSelectedRackList_CellMouseDoubleClick);
            this.grdSelectedRack.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GrdSelectedRackList_KeyDown);
            // 
            // columnSNo
            // 
            this.columnSNo.HeaderText = "S.No.";
            this.columnSNo.Name = "columnSNo";
            this.columnSNo.ReadOnly = true;
            this.columnSNo.Width = 80;
            // 
            // clmRack
            // 
            this.clmRack.HeaderText = "Rack";
            this.clmRack.Name = "clmRack";
            this.clmRack.ReadOnly = true;
            // 
            // clmDescription
            // 
            this.clmDescription.HeaderText = "Description";
            this.clmDescription.Name = "clmDescription";
            this.clmDescription.ReadOnly = true;
            // 
            // clmTotalProducts
            // 
            this.clmTotalProducts.HeaderText = "Total Products";
            this.clmTotalProducts.Name = "clmTotalProducts";
            this.clmTotalProducts.ReadOnly = true;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // clmRemoveRack
            // 
            this.clmRemoveRack.HeaderText = "Remove";
            this.clmRemoveRack.Image = global::ROMS.Properties.Resources.remove;
            this.clmRemoveRack.Name = "clmRemoveRack";
            this.clmRemoveRack.ReadOnly = true;
            this.clmRemoveRack.Width = 50;
            // 
            // btnView
            // 
            this.btnView.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnView.Image = global::ROMS.Properties.Resources.view;
            this.btnView.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnView.Location = new System.Drawing.Point(140, 114);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(74, 29);
            this.btnView.TabIndex = 3;
            this.btnView.Text = "View";
            this.btnView.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.BtnView_Click);
            this.btnView.Enter += new System.EventHandler(this.BtnView_Enter);
            this.btnView.Leave += new System.EventHandler(this.BtnView_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 20);
            this.label1.TabIndex = 1111139;
            this.label1.Text = "Stock Location";
            // 
            // chkRack
            // 
            this.chkRack.AutoSize = true;
            this.chkRack.Location = new System.Drawing.Point(36, 158);
            this.chkRack.Name = "chkRack";
            this.chkRack.Size = new System.Drawing.Size(15, 14);
            this.chkRack.TabIndex = 1111138;
            this.chkRack.TabStop = false;
            this.chkRack.UseVisualStyleBackColor = true;
            this.chkRack.CheckedChanged += new System.EventHandler(this.ChkRack_CheckedChanged);
            // 
            // lblTotalProduct
            // 
            this.lblTotalProduct.AutoSize = true;
            this.lblTotalProduct.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Bold);
            this.lblTotalProduct.ForeColor = System.Drawing.Color.Crimson;
            this.lblTotalProduct.Location = new System.Drawing.Point(735, 118);
            this.lblTotalProduct.Name = "lblTotalProduct";
            this.lblTotalProduct.Size = new System.Drawing.Size(17, 20);
            this.lblTotalProduct.TabIndex = 1111137;
            this.lblTotalProduct.Text = "0";
            // 
            // lblNoofproducts
            // 
            this.lblNoofproducts.AutoSize = true;
            this.lblNoofproducts.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.lblNoofproducts.ForeColor = System.Drawing.Color.Black;
            this.lblNoofproducts.Location = new System.Drawing.Point(635, 118);
            this.lblNoofproducts.Name = "lblNoofproducts";
            this.lblNoofproducts.Size = new System.Drawing.Size(93, 20);
            this.lblNoofproducts.TabIndex = 1111136;
            this.lblNoofproducts.Text = "Total Products :";
            // 
            // grdRack
            // 
            this.grdRack.AllowUserToAddRows = false;
            this.grdRack.AllowUserToDeleteRows = false;
            this.grdRack.AllowUserToResizeRows = false;
            this.grdRack.BackgroundColor = System.Drawing.Color.White;
            this.grdRack.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdRack.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.grdRack.ColumnHeadersHeight = 30;
            this.grdRack.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdRack.DefaultCellStyle = dataGridViewCellStyle5;
            this.grdRack.EnableHeadersVisualStyles = false;
            this.grdRack.GridColor = System.Drawing.Color.White;
            this.grdRack.Location = new System.Drawing.Point(18, 149);
            this.grdRack.Name = "grdRack";
            this.grdRack.RowHeadersVisible = false;
            this.grdRack.RowHeadersWidth = 70;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.grdRack.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.grdRack.RowTemplate.Height = 25;
            this.grdRack.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdRack.ShowRowErrors = false;
            this.grdRack.Size = new System.Drawing.Size(347, 314);
            this.grdRack.TabIndex = 512;
            this.grdRack.TabStop = false;
            this.grdRack.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrdRack_CellContentClick);
            this.grdRack.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DGV_Racklist_CellMouseDoubleClick);
            // 
            // txtRackGroupName
            // 
            this.txtRackGroupName.Location = new System.Drawing.Point(134, 58);
            this.txtRackGroupName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtRackGroupName.MaxLength = 20;
            this.txtRackGroupName.Name = "txtRackGroupName";
            this.txtRackGroupName.Size = new System.Drawing.Size(194, 27);
            this.txtRackGroupName.TabIndex = 1;
            this.txtRackGroupName.Enter += new System.EventHandler(this.TxtRackGroupName_Enter);
            this.txtRackGroupName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtRackGroupName_KeyDown);
            this.txtRackGroupName.Leave += new System.EventHandler(this.TxtRackGroupName_Leave);
            // 
            // cmbStockLocation
            // 
            this.cmbStockLocation.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStockLocation.FormattingEnabled = true;
            this.cmbStockLocation.Location = new System.Drawing.Point(18, 115);
            this.cmbStockLocation.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbStockLocation.Name = "cmbStockLocation";
            this.cmbStockLocation.Size = new System.Drawing.Size(116, 27);
            this.cmbStockLocation.TabIndex = 2;
            this.cmbStockLocation.SelectedIndexChanged += new System.EventHandler(this.CmbStockLocation_SelectedIndexChanged);
            this.cmbStockLocation.Enter += new System.EventHandler(this.CmbStockLocation_Enter);
            this.cmbStockLocation.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbStockLocation_KeyDown);
            this.cmbStockLocation.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbStockLocation_KeyPress);
            this.cmbStockLocation.Leave += new System.EventHandler(this.CmbStockLocation_Leave);
            // 
            // txtDRackGroup
            // 
            this.txtDRackGroup.BackColor = System.Drawing.SystemColors.Control;
            this.txtDRackGroup.Enabled = false;
            this.txtDRackGroup.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDRackGroup.Location = new System.Drawing.Point(18, 58);
            this.txtDRackGroup.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDRackGroup.Name = "txtDRackGroup";
            this.txtDRackGroup.ReadOnly = true;
            this.txtDRackGroup.Size = new System.Drawing.Size(116, 27);
            this.txtDRackGroup.TabIndex = 5153;
            this.txtDRackGroup.Text = "Rack Group Name";
            // 
            // cmbConcern
            // 
            this.cmbConcern.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbConcern.FormattingEnabled = true;
            this.cmbConcern.Items.AddRange(new object[] {
            "Test Company"});
            this.cmbConcern.Location = new System.Drawing.Point(134, 31);
            this.cmbConcern.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbConcern.Name = "cmbConcern";
            this.cmbConcern.Size = new System.Drawing.Size(194, 27);
            this.cmbConcern.TabIndex = 0;
            this.cmbConcern.SelectedIndexChanged += new System.EventHandler(this.CmbConcern_SelectedIndexChanged);
            this.cmbConcern.Enter += new System.EventHandler(this.CmbConcern_Enter);
            this.cmbConcern.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbConcern_KeyDown);
            this.cmbConcern.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbConcern_KeyPress);
            this.cmbConcern.Leave += new System.EventHandler(this.CmbConcern_Leave);
            // 
            // txtConcern
            // 
            this.txtConcern.BackColor = System.Drawing.SystemColors.Control;
            this.txtConcern.Enabled = false;
            this.txtConcern.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConcern.Location = new System.Drawing.Point(18, 31);
            this.txtConcern.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtConcern.Name = "txtConcern";
            this.txtConcern.ReadOnly = true;
            this.txtConcern.Size = new System.Drawing.Size(116, 27);
            this.txtConcern.TabIndex = 151521;
            this.txtConcern.Text = "Concern";
            // 
            // pnlStatus
            // 
            this.pnlStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlStatus.Controls.Add(this.rbActive);
            this.pnlStatus.Controls.Add(this.rbInactive);
            this.pnlStatus.Enabled = false;
            this.pnlStatus.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlStatus.Location = new System.Drawing.Point(1056, 251);
            this.pnlStatus.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlStatus.Name = "pnlStatus";
            this.pnlStatus.Size = new System.Drawing.Size(208, 27);
            this.pnlStatus.TabIndex = 5;
            this.pnlStatus.Visible = false;
            // 
            // rbActive
            // 
            this.rbActive.AutoSize = true;
            this.rbActive.Checked = true;
            this.rbActive.Font = new System.Drawing.Font("Oswald Regular", 9.75F);
            this.rbActive.Location = new System.Drawing.Point(21, 1);
            this.rbActive.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rbActive.Name = "rbActive";
            this.rbActive.Size = new System.Drawing.Size(54, 21);
            this.rbActive.TabIndex = 0;
            this.rbActive.TabStop = true;
            this.rbActive.Text = "Active";
            this.rbActive.UseVisualStyleBackColor = true;
            this.rbActive.Visible = false;
            this.rbActive.Enter += new System.EventHandler(this.RbActive_Enter);
            this.rbActive.Leave += new System.EventHandler(this.RbActive_Leave);
            // 
            // rbInactive
            // 
            this.rbInactive.AutoSize = true;
            this.rbInactive.Font = new System.Drawing.Font("Oswald Regular", 9.75F);
            this.rbInactive.Location = new System.Drawing.Point(110, 1);
            this.rbInactive.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rbInactive.Name = "rbInactive";
            this.rbInactive.Size = new System.Drawing.Size(63, 21);
            this.rbInactive.TabIndex = 1;
            this.rbInactive.Text = "Inactive";
            this.rbInactive.UseVisualStyleBackColor = true;
            this.rbInactive.Visible = false;
            this.rbInactive.Enter += new System.EventHandler(this.RbInactive_Enter);
            this.rbInactive.Leave += new System.EventHandler(this.RbInactive_Leave);
            // 
            // epRackGroup
            // 
            this.epRackGroup.ContainerControl = this;
            // 
            // grpUserList
            // 
            this.grpUserList.Controls.Add(this.lvStaffName);
            this.grpUserList.Controls.Add(this.btnAdd);
            this.grpUserList.Controls.Add(this.grdStaffDetails);
            this.grpUserList.Controls.Add(this.txtStaffName);
            this.grpUserList.Controls.Add(this.txtDUserName);
            this.grpUserList.Location = new System.Drawing.Point(797, 11);
            this.grpUserList.Name = "grpUserList";
            this.grpUserList.Size = new System.Drawing.Size(481, 233);
            this.grpUserList.TabIndex = 1;
            this.grpUserList.TabStop = false;
            this.grpUserList.Text = "Staff Details";
            // 
            // lvStaffName
            // 
            this.lvStaffName.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.lvStaffName.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvStaffName.HideSelection = false;
            this.lvStaffName.Location = new System.Drawing.Point(120, 58);
            this.lvStaffName.Name = "lvStaffName";
            this.lvStaffName.Size = new System.Drawing.Size(313, 97);
            this.lvStaffName.TabIndex = 958809;
            this.lvStaffName.UseCompatibleStateImageBehavior = false;
            this.lvStaffName.View = System.Windows.Forms.View.Details;
            this.lvStaffName.Visible = false;
            this.lvStaffName.SelectedIndexChanged += new System.EventHandler(this.LvStaffName_SelectedIndexChanged);
            this.lvStaffName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LvStaffName_KeyDown);
            this.lvStaffName.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.LvStaffName_MouseDoubleClick);
            // 
            // columnHeader4
            // 
            this.columnHeader4.Width = 180;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Width = 10;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Width = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.White;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAdd.Image = global::ROMS.Properties.Resources.plus;
            this.btnAdd.Location = new System.Drawing.Point(439, 31);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(0);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(23, 27);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            this.btnAdd.Enter += new System.EventHandler(this.BtnAdd_Enter);
            this.btnAdd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BtnAdd_KeyDown);
            this.btnAdd.Leave += new System.EventHandler(this.BtnAdd_Leave);
            // 
            // grdStaffDetails
            // 
            this.grdStaffDetails.AllowUserToAddRows = false;
            this.grdStaffDetails.AllowUserToDeleteRows = false;
            this.grdStaffDetails.AllowUserToResizeRows = false;
            this.grdStaffDetails.BackgroundColor = System.Drawing.Color.White;
            this.grdStaffDetails.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdStaffDetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.grdStaffDetails.ColumnHeadersHeight = 30;
            this.grdStaffDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdStaffDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmSno,
            this.clmStaffName,
            this.Column2,
            this.clmUserId,
            this.clmremove});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdStaffDetails.DefaultCellStyle = dataGridViewCellStyle8;
            this.grdStaffDetails.EnableHeadersVisualStyles = false;
            this.grdStaffDetails.GridColor = System.Drawing.Color.White;
            this.grdStaffDetails.Location = new System.Drawing.Point(12, 60);
            this.grdStaffDetails.Name = "grdStaffDetails";
            this.grdStaffDetails.RowHeadersVisible = false;
            this.grdStaffDetails.RowHeadersWidth = 70;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.grdStaffDetails.RowsDefaultCellStyle = dataGridViewCellStyle9;
            this.grdStaffDetails.RowTemplate.Height = 25;
            this.grdStaffDetails.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.grdStaffDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdStaffDetails.ShowRowErrors = false;
            this.grdStaffDetails.Size = new System.Drawing.Size(455, 166);
            this.grdStaffDetails.TabIndex = 331254;
            this.grdStaffDetails.TabStop = false;
            this.grdStaffDetails.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrdStaffDetails_CellContentClick);
            this.grdStaffDetails.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DgvStaffDetails_KeyDown);
            // 
            // txtStaffName
            // 
            this.txtStaffName.Location = new System.Drawing.Point(120, 31);
            this.txtStaffName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtStaffName.MaxLength = 30;
            this.txtStaffName.Name = "txtStaffName";
            this.txtStaffName.Size = new System.Drawing.Size(313, 27);
            this.txtStaffName.TabIndex = 0;
            this.txtStaffName.TextChanged += new System.EventHandler(this.TxtStaffName_TextChanged);
            this.txtStaffName.Enter += new System.EventHandler(this.TxtStaffName_Enter);
            this.txtStaffName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtStaffName_KeyDown);
            this.txtStaffName.Leave += new System.EventHandler(this.TxtStaffName_Leave);
            // 
            // txtDUserName
            // 
            this.txtDUserName.BackColor = System.Drawing.SystemColors.Control;
            this.txtDUserName.Enabled = false;
            this.txtDUserName.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDUserName.Location = new System.Drawing.Point(12, 31);
            this.txtDUserName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDUserName.Name = "txtDUserName";
            this.txtDUserName.ReadOnly = true;
            this.txtDUserName.Size = new System.Drawing.Size(108, 27);
            this.txtDUserName.TabIndex = 1111136;
            this.txtDUserName.Text = "Staff Name";
            // 
            // txtStatus
            // 
            this.txtStatus.BackColor = System.Drawing.SystemColors.Control;
            this.txtStatus.Enabled = false;
            this.txtStatus.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStatus.Location = new System.Drawing.Point(948, 251);
            this.txtStatus.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(108, 27);
            this.txtStatus.TabIndex = 4;
            this.txtStatus.Text = "Status";
            this.txtStatus.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnSave.Image = global::ROMS.Properties.Resources.save;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(1098, 445);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(87, 29);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.Enter += new System.EventHandler(this.btnSave_Enter);
            this.btnSave.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnSave_KeyDown);
            this.btnSave.Leave += new System.EventHandler(this.btnSave_Leave);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnClose.Image = global::ROMS.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(1189, 445);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 29);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            this.btnClose.Enter += new System.EventHandler(this.btnClose_Enter);
            this.btnClose.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnClose_KeyDown);
            this.btnClose.Leave += new System.EventHandler(this.btnClose_Leave);
            // 
            // clmSno
            // 
            this.clmSno.HeaderText = "S.No.";
            this.clmSno.Name = "clmSno";
            this.clmSno.ReadOnly = true;
            this.clmSno.Width = 40;
            // 
            // clmStaffName
            // 
            this.clmStaffName.HeaderText = "Staff Name";
            this.clmStaffName.MinimumWidth = 6;
            this.clmStaffName.Name = "clmStaffName";
            this.clmStaffName.ReadOnly = true;
            this.clmStaffName.Width = 125;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Employee Category";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 125;
            // 
            // clmUserId
            // 
            this.clmUserId.HeaderText = "User ID";
            this.clmUserId.Name = "clmUserId";
            // 
            // clmremove
            // 
            this.clmremove.HeaderText = "Remove";
            this.clmremove.Image = global::ROMS.Properties.Resources.remove;
            this.clmremove.Name = "clmremove";
            this.clmremove.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmremove.Width = 50;
            // 
            // CP_RackGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1288, 505);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.grpUserList);
            this.Controls.Add(this.grbform);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.pnlStatus);
            this.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CP_RackGroup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rack Group";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CP_RackGroup_FormClosing);
            this.Load += new System.EventHandler(this.CP_RackGroup_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CP_RackGroup_KeyDown);
            this.Leave += new System.EventHandler(this.CP_RackGroup_Leave);
            this.grbform.ResumeLayout(false);
            this.grbform.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSelectedRack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdRack)).EndInit();
            this.pnlStatus.ResumeLayout(false);
            this.pnlStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epRackGroup)).EndInit();
            this.grpUserList.ResumeLayout(false);
            this.grpUserList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdStaffDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox grbform;
        private System.Windows.Forms.Panel pnlStatus;
        private System.Windows.Forms.RadioButton rbInactive;
        private System.Windows.Forms.RadioButton rbActive;
        private System.Windows.Forms.ComboBox cmbConcern;
        private System.Windows.Forms.TextBox txtConcern;
        private System.Windows.Forms.ComboBox cmbStockLocation;
        public System.Windows.Forms.DataGridView grdRack;
        private System.Windows.Forms.ErrorProvider epRackGroup;
        private System.Windows.Forms.GroupBox grpUserList;
        private System.Windows.Forms.TextBox txtDUserName;
        private System.Windows.Forms.TextBox txtStaffName;
        public System.Windows.Forms.DataGridView grdStaffDetails;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Label lblTotalProduct;
        private System.Windows.Forms.Label lblNoofproducts;
        private System.Windows.Forms.CheckBox chkRack;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnView;
        public System.Windows.Forms.DataGridView grdSelectedRack;
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.TextBox txtRackGroupName;
        private System.Windows.Forms.TextBox txtDRackGroup;
        public System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnSNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmRack;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTotalProducts;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewImageColumn clmRemoveRack;
        public System.Windows.Forms.ListView lvStaffName;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSno;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmStaffName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmUserId;
        private System.Windows.Forms.DataGridViewImageColumn clmremove;
    }
}