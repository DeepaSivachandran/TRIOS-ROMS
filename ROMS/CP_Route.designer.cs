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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CP_Route));
            this.txtDRouteTName = new System.Windows.Forms.TextBox();
            this.txtDRouteEName = new System.Windows.Forms.TextBox();
            this.grbform = new System.Windows.Forms.GroupBox();
            this.grdArea = new System.Windows.Forms.DataGridView();
            this.clmCheckBox = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cmbRSNo = new System.Windows.Forms.ComboBox();
            this.txtDRouteOrderNo = new System.Windows.Forms.TextBox();
            this.txtRTName = new System.Windows.Forms.TextBox();
            this.txtREName = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.pnlStatus = new System.Windows.Forms.Panel();
            this.rbActive = new System.Windows.Forms.RadioButton();
            this.rbInActive = new System.Windows.Forms.RadioButton();
            this.epRoute = new System.Windows.Forms.ErrorProvider(this.components);
            this.tsRoute = new System.Windows.Forms.ToolStrip();
            this.tspHeader = new System.Windows.Forms.ToolStripLabel();
            this.pnlRoute = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnPurRemove = new System.Windows.Forms.Button();
            this.BtnPuraddMove = new System.Windows.Forms.Button();
            this.grdMappedArea = new System.Windows.Forms.DataGridView();
            this.clmCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DGV_PurSearchGrid = new System.Windows.Forms.DataGridView();
            this.DGV_PurMappedSearchGrid = new System.Windows.Forms.DataGridView();
            this.grbform.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdArea)).BeginInit();
            this.pnlStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epRoute)).BeginInit();
            this.tsRoute.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMappedArea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_PurSearchGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_PurMappedSearchGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDRouteTName
            // 
            this.txtDRouteTName.BackColor = System.Drawing.SystemColors.Control;
            this.txtDRouteTName.Enabled = false;
            this.txtDRouteTName.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDRouteTName.Location = new System.Drawing.Point(7, 52);
            this.txtDRouteTName.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtDRouteTName.Name = "txtDRouteTName";
            this.txtDRouteTName.ReadOnly = true;
            this.txtDRouteTName.Size = new System.Drawing.Size(131, 28);
            this.txtDRouteTName.TabIndex = 6;
            this.txtDRouteTName.Text = "Route Name in Tamil";
            // 
            // txtDRouteEName
            // 
            this.txtDRouteEName.BackColor = System.Drawing.SystemColors.Control;
            this.txtDRouteEName.Enabled = false;
            this.txtDRouteEName.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDRouteEName.Location = new System.Drawing.Point(7, 23);
            this.txtDRouteEName.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtDRouteEName.Name = "txtDRouteEName";
            this.txtDRouteEName.ReadOnly = true;
            this.txtDRouteEName.Size = new System.Drawing.Size(131, 28);
            this.txtDRouteEName.TabIndex = 7;
            this.txtDRouteEName.Text = "Route Name in English";
            // 
            // grbform
            // 
            this.grbform.BackColor = System.Drawing.Color.White;
            this.grbform.Controls.Add(this.DGV_PurSearchGrid);
            this.grbform.Controls.Add(this.btnPurRemove);
            this.grbform.Controls.Add(this.BtnPuraddMove);
            this.grbform.Controls.Add(this.groupBox2);
            this.grbform.Controls.Add(this.groupBox1);
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
            this.grbform.Location = new System.Drawing.Point(9, 30);
            this.grbform.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.grbform.Name = "grbform";
            this.grbform.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.grbform.Size = new System.Drawing.Size(1333, 631);
            this.grbform.TabIndex = 28;
            this.grbform.TabStop = false;
            // 
            // grdArea
            // 
            this.grdArea.AllowUserToAddRows = false;
            this.grdArea.AllowUserToDeleteRows = false;
            this.grdArea.AllowUserToResizeColumns = false;
            this.grdArea.AllowUserToResizeRows = false;
            this.grdArea.BackgroundColor = System.Drawing.Color.White;
            this.grdArea.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(242)))), ((int)(((byte)(213)))));
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdArea.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.grdArea.ColumnHeadersHeight = 30;
            this.grdArea.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdArea.ColumnHeadersVisible = false;
            this.grdArea.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmCheckBox});
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdArea.DefaultCellStyle = dataGridViewCellStyle11;
            this.grdArea.EnableHeadersVisualStyles = false;
            this.grdArea.GridColor = System.Drawing.Color.White;
            this.grdArea.Location = new System.Drawing.Point(13, 82);
            this.grdArea.Name = "grdArea";
            this.grdArea.RowHeadersVisible = false;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.Black;
            this.grdArea.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.grdArea.RowTemplate.Height = 25;
            this.grdArea.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.grdArea.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.grdArea.Size = new System.Drawing.Size(311, 406);
            this.grdArea.TabIndex = 1111147;
            this.grdArea.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdArea_CellValueChanged);
            this.grdArea.CurrentCellDirtyStateChanged += new System.EventHandler(this.grdArea_CurrentCellDirtyStateChanged);
            // 
            // clmCheckBox
            // 
            this.clmCheckBox.HeaderText = "";
            this.clmCheckBox.Name = "clmCheckBox";
            this.clmCheckBox.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmCheckBox.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.clmCheckBox.Width = 50;
            // 
            // cmbRSNo
            // 
            this.cmbRSNo.Font = new System.Drawing.Font("Oswald Regular", 11.25F);
            this.cmbRSNo.FormattingEnabled = true;
            this.cmbRSNo.Location = new System.Drawing.Point(517, 23);
            this.cmbRSNo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbRSNo.Name = "cmbRSNo";
            this.cmbRSNo.Size = new System.Drawing.Size(202, 28);
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
            this.txtDRouteOrderNo.Font = new System.Drawing.Font("Oswald Regular", 11.25F);
            this.txtDRouteOrderNo.Location = new System.Drawing.Point(386, 23);
            this.txtDRouteOrderNo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDRouteOrderNo.Name = "txtDRouteOrderNo";
            this.txtDRouteOrderNo.ReadOnly = true;
            this.txtDRouteOrderNo.Size = new System.Drawing.Size(131, 28);
            this.txtDRouteOrderNo.TabIndex = 1111146;
            this.txtDRouteOrderNo.Text = "Order No.";
            // 
            // txtRTName
            // 
            this.txtRTName.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 12F);
            this.txtRTName.Location = new System.Drawing.Point(138, 53);
            this.txtRTName.MaxLength = 100;
            this.txtRTName.Name = "txtRTName";
            this.txtRTName.Size = new System.Drawing.Size(202, 27);
            this.txtRTName.TabIndex = 1;
            this.txtRTName.Enter += new System.EventHandler(this.txtRTName_Enter);
            this.txtRTName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRTName_KeyDown);
            this.txtRTName.Leave += new System.EventHandler(this.txtRTName_Leave);
            // 
            // txtREName
            // 
            this.txtREName.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtREName.Location = new System.Drawing.Point(138, 23);
            this.txtREName.MaxLength = 100;
            this.txtREName.Name = "txtREName";
            this.txtREName.Size = new System.Drawing.Size(202, 28);
            this.txtREName.TabIndex = 0;
            this.txtREName.Enter += new System.EventHandler(this.txtREName_Enter);
            this.txtREName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtREName_KeyDown);
            this.txtREName.Leave += new System.EventHandler(this.txtREName_Leave);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::ROMS.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(1258, 590);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(69, 31);
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
            this.btnSave.Location = new System.Drawing.Point(1170, 590);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(83, 31);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.Enter += new System.EventHandler(this.btnSave_Enter);
            this.btnSave.Leave += new System.EventHandler(this.btnSave_Leave);
            // 
            // txtStatus
            // 
            this.txtStatus.BackColor = System.Drawing.SystemColors.Control;
            this.txtStatus.Enabled = false;
            this.txtStatus.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStatus.Location = new System.Drawing.Point(386, 52);
            this.txtStatus.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(131, 28);
            this.txtStatus.TabIndex = 8;
            this.txtStatus.Text = "Status";
            // 
            // pnlStatus
            // 
            this.pnlStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlStatus.Controls.Add(this.rbActive);
            this.pnlStatus.Controls.Add(this.rbInActive);
            this.pnlStatus.Font = new System.Drawing.Font("Oswald Regular", 11.25F);
            this.pnlStatus.Location = new System.Drawing.Point(517, 53);
            this.pnlStatus.Name = "pnlStatus";
            this.pnlStatus.Size = new System.Drawing.Size(202, 27);
            this.pnlStatus.TabIndex = 3;
            // 
            // rbActive
            // 
            this.rbActive.AutoSize = true;
            this.rbActive.Checked = true;
            this.rbActive.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbActive.Location = new System.Drawing.Point(33, 1);
            this.rbActive.Name = "rbActive";
            this.rbActive.Size = new System.Drawing.Size(60, 24);
            this.rbActive.TabIndex = 3;
            this.rbActive.TabStop = true;
            this.rbActive.Text = "Active";
            this.rbActive.UseVisualStyleBackColor = true;
            this.rbActive.Enter += new System.EventHandler(this.RbActive_Enter);
            this.rbActive.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rbActive_KeyDown);
            this.rbActive.Leave += new System.EventHandler(this.RbActive_Leave);
            // 
            // rbInActive
            // 
            this.rbInActive.AutoSize = true;
            this.rbInActive.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbInActive.Location = new System.Drawing.Point(100, 1);
            this.rbInActive.Name = "rbInActive";
            this.rbInActive.Size = new System.Drawing.Size(70, 24);
            this.rbInActive.TabIndex = 4;
            this.rbInActive.Text = "Inactive";
            this.rbInActive.UseVisualStyleBackColor = true;
            this.rbInActive.Enter += new System.EventHandler(this.RbInActive_Enter);
            this.rbInActive.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rbInActive_KeyDown);
            this.rbInActive.Leave += new System.EventHandler(this.RbInActive_Leave);
            // 
            // epRoute
            // 
            this.epRoute.ContainerControl = this;
            // 
            // tsRoute
            // 
            this.tsRoute.BackColor = System.Drawing.Color.White;
            this.tsRoute.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsRoute.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsRoute.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsRoute.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspHeader});
            this.tsRoute.Location = new System.Drawing.Point(0, 0);
            this.tsRoute.Name = "tsRoute";
            this.tsRoute.Size = new System.Drawing.Size(1354, 25);
            this.tsRoute.TabIndex = 36;
            this.tsRoute.Text = "Inward";
            // 
            // tspHeader
            // 
            this.tspHeader.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tspHeader.Image = global::ROMS.Properties.Resources.bread_crumb;
            this.tspHeader.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tspHeader.Margin = new System.Windows.Forms.Padding(15, 1, 0, 2);
            this.tspHeader.Name = "tspHeader";
            this.tspHeader.Size = new System.Drawing.Size(57, 22);
            this.tspHeader.Text = "Route";
            // 
            // pnlRoute
            // 
            this.pnlRoute.BackColor = System.Drawing.Color.White;
            this.pnlRoute.Location = new System.Drawing.Point(0, 29);
            this.pnlRoute.Name = "pnlRoute";
            this.pnlRoute.Size = new System.Drawing.Size(1354, 645);
            this.pnlRoute.TabIndex = 37;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.grdArea);
            this.groupBox1.Location = new System.Drawing.Point(7, 88);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(338, 494);
            this.groupBox1.TabIndex = 1111148;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Un Mapped Areas";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.DGV_PurMappedSearchGrid);
            this.groupBox2.Controls.Add(this.grdMappedArea);
            this.groupBox2.Location = new System.Drawing.Point(388, 88);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(338, 494);
            this.groupBox2.TabIndex = 1111149;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Mapped Areas";
            // 
            // btnPurRemove
            // 
            this.btnPurRemove.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnPurRemove.Image = global::ROMS.Properties.Resources.add___left;
            this.btnPurRemove.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPurRemove.Location = new System.Drawing.Point(351, 330);
            this.btnPurRemove.Name = "btnPurRemove";
            this.btnPurRemove.Size = new System.Drawing.Size(31, 29);
            this.btnPurRemove.TabIndex = 1111151;
            this.btnPurRemove.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPurRemove.UseVisualStyleBackColor = true;
            this.btnPurRemove.Click += new System.EventHandler(this.btnPurRemove_Click);
            // 
            // BtnPuraddMove
            // 
            this.BtnPuraddMove.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.BtnPuraddMove.Image = global::ROMS.Properties.Resources.add;
            this.BtnPuraddMove.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnPuraddMove.Location = new System.Drawing.Point(351, 295);
            this.BtnPuraddMove.Name = "BtnPuraddMove";
            this.BtnPuraddMove.Size = new System.Drawing.Size(31, 29);
            this.BtnPuraddMove.TabIndex = 1111150;
            this.BtnPuraddMove.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnPuraddMove.UseVisualStyleBackColor = true;
            this.BtnPuraddMove.Click += new System.EventHandler(this.BtnPuraddMove_Click);
            // 
            // grdMappedArea
            // 
            this.grdMappedArea.AllowUserToAddRows = false;
            this.grdMappedArea.AllowUserToDeleteRows = false;
            this.grdMappedArea.AllowUserToResizeColumns = false;
            this.grdMappedArea.AllowUserToResizeRows = false;
            this.grdMappedArea.BackgroundColor = System.Drawing.Color.White;
            this.grdMappedArea.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(242)))), ((int)(((byte)(213)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdMappedArea.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.grdMappedArea.ColumnHeadersHeight = 30;
            this.grdMappedArea.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdMappedArea.ColumnHeadersVisible = false;
            this.grdMappedArea.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmCheck});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdMappedArea.DefaultCellStyle = dataGridViewCellStyle8;
            this.grdMappedArea.EnableHeadersVisualStyles = false;
            this.grdMappedArea.GridColor = System.Drawing.Color.White;
            this.grdMappedArea.Location = new System.Drawing.Point(14, 82);
            this.grdMappedArea.Name = "grdMappedArea";
            this.grdMappedArea.RowHeadersVisible = false;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black;
            this.grdMappedArea.RowsDefaultCellStyle = dataGridViewCellStyle9;
            this.grdMappedArea.RowTemplate.Height = 25;
            this.grdMappedArea.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.grdMappedArea.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.grdMappedArea.Size = new System.Drawing.Size(311, 406);
            this.grdMappedArea.TabIndex = 1111148;
            this.grdMappedArea.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdMappedArea_CellValueChanged);
            this.grdMappedArea.CurrentCellDirtyStateChanged += new System.EventHandler(this.grdMappedArea_CurrentCellDirtyStateChanged);
            // 
            // clmCheck
            // 
            this.clmCheck.HeaderText = "";
            this.clmCheck.Name = "clmCheck";
            this.clmCheck.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmCheck.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.clmCheck.Width = 50;
            // 
            // DGV_PurSearchGrid
            // 
            this.DGV_PurSearchGrid.AllowUserToAddRows = false;
            this.DGV_PurSearchGrid.AllowUserToDeleteRows = false;
            this.DGV_PurSearchGrid.AllowUserToResizeRows = false;
            this.DGV_PurSearchGrid.BackgroundColor = System.Drawing.Color.White;
            this.DGV_PurSearchGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(242)))), ((int)(((byte)(213)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_PurSearchGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DGV_PurSearchGrid.ColumnHeadersHeight = 30;
            this.DGV_PurSearchGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV_PurSearchGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.DGV_PurSearchGrid.EnableHeadersVisualStyles = false;
            this.DGV_PurSearchGrid.GridColor = System.Drawing.Color.White;
            this.DGV_PurSearchGrid.Location = new System.Drawing.Point(20, 114);
            this.DGV_PurSearchGrid.Name = "DGV_PurSearchGrid";
            this.DGV_PurSearchGrid.RowHeadersVisible = false;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.DGV_PurSearchGrid.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.DGV_PurSearchGrid.RowTemplate.Height = 25;
            this.DGV_PurSearchGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DGV_PurSearchGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DGV_PurSearchGrid.ShowRowErrors = false;
            this.DGV_PurSearchGrid.Size = new System.Drawing.Size(311, 56);
            this.DGV_PurSearchGrid.TabIndex = 1111148;
            this.DGV_PurSearchGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_PurSearchGrid_CellEndEdit);
            this.DGV_PurSearchGrid.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DGV_PurSearchGrid_CellFormatting);
            this.DGV_PurSearchGrid.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.DGV_PurSearchGrid_CellPainting);
            this.DGV_PurSearchGrid.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DGV_PurSearchGrid_ColumnHeaderMouseClick);
            this.DGV_PurSearchGrid.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.DGV_PurSearchGrid_ColumnWidthChanged);
            this.DGV_PurSearchGrid.CurrentCellDirtyStateChanged += new System.EventHandler(this.DGV_PurSearchGrid_CurrentCellDirtyStateChanged);
            this.DGV_PurSearchGrid.Scroll += new System.Windows.Forms.ScrollEventHandler(this.DGV_PurSearchGrid_Scroll);
            // 
            // DGV_PurMappedSearchGrid
            // 
            this.DGV_PurMappedSearchGrid.AllowUserToAddRows = false;
            this.DGV_PurMappedSearchGrid.AllowUserToDeleteRows = false;
            this.DGV_PurMappedSearchGrid.AllowUserToResizeRows = false;
            this.DGV_PurMappedSearchGrid.BackgroundColor = System.Drawing.Color.White;
            this.DGV_PurMappedSearchGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(242)))), ((int)(((byte)(213)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_PurMappedSearchGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.DGV_PurMappedSearchGrid.ColumnHeadersHeight = 30;
            this.DGV_PurMappedSearchGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV_PurMappedSearchGrid.DefaultCellStyle = dataGridViewCellStyle5;
            this.DGV_PurMappedSearchGrid.EnableHeadersVisualStyles = false;
            this.DGV_PurMappedSearchGrid.GridColor = System.Drawing.Color.White;
            this.DGV_PurMappedSearchGrid.Location = new System.Drawing.Point(14, 26);
            this.DGV_PurMappedSearchGrid.Name = "DGV_PurMappedSearchGrid";
            this.DGV_PurMappedSearchGrid.RowHeadersVisible = false;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            this.DGV_PurMappedSearchGrid.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.DGV_PurMappedSearchGrid.RowTemplate.Height = 25;
            this.DGV_PurMappedSearchGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DGV_PurMappedSearchGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DGV_PurMappedSearchGrid.ShowRowErrors = false;
            this.DGV_PurMappedSearchGrid.Size = new System.Drawing.Size(311, 56);
            this.DGV_PurMappedSearchGrid.TabIndex = 1111149;
            this.DGV_PurMappedSearchGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_PurMappedSearchGrid_CellEndEdit);
            this.DGV_PurMappedSearchGrid.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DGV_PurMappedSearchGrid_CellFormatting);
            this.DGV_PurMappedSearchGrid.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.DGV_PurMappedSearchGrid_CellPainting);
            this.DGV_PurMappedSearchGrid.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DGV_PurMappedSearchGrid_ColumnHeaderMouseClick);
            this.DGV_PurMappedSearchGrid.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.DGV_PurMappedSearchGrid_ColumnWidthChanged);
            this.DGV_PurMappedSearchGrid.CurrentCellDirtyStateChanged += new System.EventHandler(this.DGV_PurMappedSearchGrid_CurrentCellDirtyStateChanged);
            this.DGV_PurMappedSearchGrid.Scroll += new System.Windows.Forms.ScrollEventHandler(this.DGV_PurMappedSearchGrid_Scroll);
            // 
            // CP_Route
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(1354, 675);
            this.Controls.Add(this.grbform);
            this.Controls.Add(this.pnlRoute);
            this.Controls.Add(this.tsRoute);
            this.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.Name = "CP_Route";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Route Details";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CP_Route_FormClosing);
            this.Load += new System.EventHandler(this.CP_Route_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CP_Route_KeyDown);
            this.Leave += new System.EventHandler(this.CP_Route_Leave);
            this.grbform.ResumeLayout(false);
            this.grbform.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdArea)).EndInit();
            this.pnlStatus.ResumeLayout(false);
            this.pnlStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epRoute)).EndInit();
            this.tsRoute.ResumeLayout(false);
            this.tsRoute.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdMappedArea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_PurSearchGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_PurMappedSearchGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.ToolStrip tsRoute;
        private System.Windows.Forms.ToolStripLabel tspHeader;
        private System.Windows.Forms.Panel pnlRoute;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnPurRemove;
        private System.Windows.Forms.Button BtnPuraddMove;
        public System.Windows.Forms.DataGridView grdMappedArea;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clmCheck;
        public System.Windows.Forms.DataGridView DGV_PurSearchGrid;
        public System.Windows.Forms.DataGridView DGV_PurMappedSearchGrid;
    }
}