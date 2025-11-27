namespace ROMS
{
    partial class CP_Settings
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
            this.pnlSettings = new System.Windows.Forms.Panel();
            this.DGV_SearchGrid = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblNoRecordsFound = new System.Windows.Forms.Label();
            this.grpVoucherSettings = new System.Windows.Forms.GroupBox();
            this.txtFyyear = new System.Windows.Forms.TextBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.lblFyyr = new System.Windows.Forms.Label();
            this.txtNoOfDegits = new System.Windows.Forms.TextBox();
            this.lblNoOfDigits = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.cmbResetOn = new System.Windows.Forms.ComboBox();
            this.lblResetOn = new System.Windows.Forms.Label();
            this.txtStartingNo = new System.Windows.Forms.TextBox();
            this.lblStartingNo = new System.Windows.Forms.Label();
            this.txtSuffix = new System.Windows.Forms.TextBox();
            this.lblSuffix = new System.Windows.Forms.Label();
            this.txtPrefix = new System.Windows.Forms.TextBox();
            this.lblPrefix = new System.Windows.Forms.Label();
            this.cmbTransactionType = new System.Windows.Forms.ComboBox();
            this.lblTransactionType = new System.Windows.Forms.Label();
            this.cmbConcern = new System.Windows.Forms.ComboBox();
            this.lblDEConcern = new System.Windows.Forms.Label();
            this.grdSettings = new System.Windows.Forms.DataGridView();
            this.clmEdit = new System.Windows.Forms.DataGridViewImageColumn();
            this.clmRemove = new System.Windows.Forms.DataGridViewImageColumn();
            this.picLoader = new System.Windows.Forms.PictureBox();
            this.epSettings = new System.Windows.Forms.ErrorProvider(this.components);
            this.tsVoucherSettings = new System.Windows.Forms.ToolStrip();
            this.tspHeader = new System.Windows.Forms.ToolStripLabel();
            this.pnlSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_SearchGrid)).BeginInit();
            this.grpVoucherSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSettings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epSettings)).BeginInit();
            this.tsVoucherSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSettings
            // 
            this.pnlSettings.BackColor = System.Drawing.Color.White;
            this.pnlSettings.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSettings.Controls.Add(this.DGV_SearchGrid);
            this.pnlSettings.Controls.Add(this.btnClose);
            this.pnlSettings.Controls.Add(this.lblNoRecordsFound);
            this.pnlSettings.Controls.Add(this.grpVoucherSettings);
            this.pnlSettings.Controls.Add(this.grdSettings);
            this.pnlSettings.Location = new System.Drawing.Point(0, 28);
            this.pnlSettings.Name = "pnlSettings";
            this.pnlSettings.Size = new System.Drawing.Size(1354, 646);
            this.pnlSettings.TabIndex = 958788;
            // 
            // DGV_SearchGrid
            // 
            this.DGV_SearchGrid.AllowUserToAddRows = false;
            this.DGV_SearchGrid.AllowUserToDeleteRows = false;
            this.DGV_SearchGrid.AllowUserToResizeRows = false;
            this.DGV_SearchGrid.BackgroundColor = System.Drawing.Color.White;
            this.DGV_SearchGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(242)))), ((int)(((byte)(213)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_SearchGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DGV_SearchGrid.ColumnHeadersHeight = 30;
            this.DGV_SearchGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV_SearchGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.DGV_SearchGrid.EnableHeadersVisualStyles = false;
            this.DGV_SearchGrid.GridColor = System.Drawing.Color.White;
            this.DGV_SearchGrid.Location = new System.Drawing.Point(3, 87);
            this.DGV_SearchGrid.Name = "DGV_SearchGrid";
            this.DGV_SearchGrid.RowHeadersVisible = false;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.DGV_SearchGrid.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.DGV_SearchGrid.RowTemplate.Height = 25;
            this.DGV_SearchGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DGV_SearchGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DGV_SearchGrid.ShowRowErrors = false;
            this.DGV_SearchGrid.Size = new System.Drawing.Size(1348, 56);
            this.DGV_SearchGrid.TabIndex = 958801;
            this.DGV_SearchGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_SearchGrid_CellContentClick);
            this.DGV_SearchGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_SearchGrid_CellEndEdit);
            this.DGV_SearchGrid.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.DGV_SearchGrid_CellPainting);
            this.DGV_SearchGrid.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DGV_SearchGrid_ColumnHeaderMouseClick);
            this.DGV_SearchGrid.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.DGV_SearchGrid_ColumnWidthChanged);
            this.DGV_SearchGrid.CurrentCellDirtyStateChanged += new System.EventHandler(this.DGV_SearchGrid_CurrentCellDirtyStateChanged);
            this.DGV_SearchGrid.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.DGV_SearchGrid_EditingControlShowing);
            this.DGV_SearchGrid.Scroll += new System.Windows.Forms.ScrollEventHandler(this.DGV_SearchGrid_Scroll);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnClose.Image = global::ROMS.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(1272, 611);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 29);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            this.btnClose.Enter += new System.EventHandler(this.BtnClose_Enter);
            this.btnClose.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BtnClose_KeyDown);
            this.btnClose.Leave += new System.EventHandler(this.BtnClose_Leave);
            // 
            // lblNoRecordsFound
            // 
            this.lblNoRecordsFound.AutoSize = true;
            this.lblNoRecordsFound.BackColor = System.Drawing.Color.White;
            this.lblNoRecordsFound.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoRecordsFound.Location = new System.Drawing.Point(618, 364);
            this.lblNoRecordsFound.Name = "lblNoRecordsFound";
            this.lblNoRecordsFound.Size = new System.Drawing.Size(106, 20);
            this.lblNoRecordsFound.TabIndex = 958791;
            this.lblNoRecordsFound.Text = "No Records Found";
            this.lblNoRecordsFound.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // grpVoucherSettings
            // 
            this.grpVoucherSettings.BackColor = System.Drawing.Color.White;
            this.grpVoucherSettings.Controls.Add(this.txtFyyear);
            this.grpVoucherSettings.Controls.Add(this.btnUpdate);
            this.grpVoucherSettings.Controls.Add(this.lblFyyr);
            this.grpVoucherSettings.Controls.Add(this.txtNoOfDegits);
            this.grpVoucherSettings.Controls.Add(this.lblNoOfDigits);
            this.grpVoucherSettings.Controls.Add(this.btnAdd);
            this.grpVoucherSettings.Controls.Add(this.cmbResetOn);
            this.grpVoucherSettings.Controls.Add(this.lblResetOn);
            this.grpVoucherSettings.Controls.Add(this.txtStartingNo);
            this.grpVoucherSettings.Controls.Add(this.lblStartingNo);
            this.grpVoucherSettings.Controls.Add(this.txtSuffix);
            this.grpVoucherSettings.Controls.Add(this.lblSuffix);
            this.grpVoucherSettings.Controls.Add(this.txtPrefix);
            this.grpVoucherSettings.Controls.Add(this.lblPrefix);
            this.grpVoucherSettings.Controls.Add(this.cmbTransactionType);
            this.grpVoucherSettings.Controls.Add(this.lblTransactionType);
            this.grpVoucherSettings.Controls.Add(this.cmbConcern);
            this.grpVoucherSettings.Controls.Add(this.lblDEConcern);
            this.grpVoucherSettings.Location = new System.Drawing.Point(3, 2);
            this.grpVoucherSettings.Name = "grpVoucherSettings";
            this.grpVoucherSettings.Size = new System.Drawing.Size(1346, 81);
            this.grpVoucherSettings.TabIndex = 0;
            this.grpVoucherSettings.TabStop = false;
            this.grpVoucherSettings.Text = "Voucher Settings";
            // 
            // txtFyyear
            // 
            this.txtFyyear.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFyyear.Location = new System.Drawing.Point(17, 46);
            this.txtFyyear.MaxLength = 5;
            this.txtFyyear.Name = "txtFyyear";
            this.txtFyyear.ReadOnly = true;
            this.txtFyyear.Size = new System.Drawing.Size(89, 27);
            this.txtFyyear.TabIndex = 0;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnUpdate.Image = global::ROMS.Properties.Resources.save;
            this.btnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdate.Location = new System.Drawing.Point(812, 45);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(85, 29);
            this.btnUpdate.TabIndex = 7;
            this.btnUpdate.Text = "Save";
            this.btnUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.BtnSave_Click);
            this.btnUpdate.Enter += new System.EventHandler(this.BtnSave_Enter);
            this.btnUpdate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BtnSave_KeyDown);
            this.btnUpdate.Leave += new System.EventHandler(this.BtnSave_Leave);
            // 
            // lblFyyr
            // 
            this.lblFyyr.AutoSize = true;
            this.lblFyyr.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFyyr.Location = new System.Drawing.Point(17, 23);
            this.lblFyyr.Name = "lblFyyr";
            this.lblFyyr.Size = new System.Drawing.Size(83, 20);
            this.lblFyyr.TabIndex = 1111173;
            this.lblFyyr.Text = "Financial Year";
            // 
            // txtNoOfDegits
            // 
            this.txtNoOfDegits.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNoOfDegits.Location = new System.Drawing.Point(1249, 46);
            this.txtNoOfDegits.MaxLength = 1;
            this.txtNoOfDegits.Name = "txtNoOfDegits";
            this.txtNoOfDegits.Size = new System.Drawing.Size(89, 27);
            this.txtNoOfDegits.TabIndex = 6;
            this.txtNoOfDegits.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNoOfDegits.Visible = false;
            this.txtNoOfDegits.Enter += new System.EventHandler(this.TxtNoOfDegits_Enter);
            this.txtNoOfDegits.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtNoOfDegits_KeyDown);
            this.txtNoOfDegits.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtNoOfDegits_KeyPress);
            this.txtNoOfDegits.Leave += new System.EventHandler(this.TxtNoOfDegits_Leave);
            // 
            // lblNoOfDigits
            // 
            this.lblNoOfDigits.AutoSize = true;
            this.lblNoOfDigits.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoOfDigits.Location = new System.Drawing.Point(1249, 23);
            this.lblNoOfDigits.Name = "lblNoOfDigits";
            this.lblNoOfDigits.Size = new System.Drawing.Size(71, 20);
            this.lblNoOfDigits.TabIndex = 1111171;
            this.lblNoOfDigits.Text = "No.of Digits";
            this.lblNoOfDigits.Visible = false;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.White;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAdd.Image = global::ROMS.Properties.Resources.plus;
            this.btnAdd.Location = new System.Drawing.Point(1219, 44);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(0);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(27, 27);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Visible = false;
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            this.btnAdd.Enter += new System.EventHandler(this.BtnAdd_Enter);
            this.btnAdd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BtnAdd_KeyDown);
            this.btnAdd.Leave += new System.EventHandler(this.BtnAdd_Leave);
            // 
            // cmbResetOn
            // 
            this.cmbResetOn.FormattingEnabled = true;
            this.cmbResetOn.Items.AddRange(new object[] {
            "Continuous"});
            this.cmbResetOn.Location = new System.Drawing.Point(717, 46);
            this.cmbResetOn.Name = "cmbResetOn";
            this.cmbResetOn.Size = new System.Drawing.Size(89, 27);
            this.cmbResetOn.TabIndex = 6;
            this.cmbResetOn.SelectedIndexChanged += new System.EventHandler(this.CmbResetOn_SelectedIndexChanged);
            this.cmbResetOn.Enter += new System.EventHandler(this.CmbResetOn_Enter);
            this.cmbResetOn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbResetOn_KeyDown);
            this.cmbResetOn.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbResetOn_KeyPress);
            this.cmbResetOn.Leave += new System.EventHandler(this.CmbResetOn_Leave);
            // 
            // lblResetOn
            // 
            this.lblResetOn.AutoSize = true;
            this.lblResetOn.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResetOn.Location = new System.Drawing.Point(717, 23);
            this.lblResetOn.Name = "lblResetOn";
            this.lblResetOn.Size = new System.Drawing.Size(58, 20);
            this.lblResetOn.TabIndex = 1111168;
            this.lblResetOn.Text = "Reset On";
            // 
            // txtStartingNo
            // 
            this.txtStartingNo.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStartingNo.Location = new System.Drawing.Point(622, 46);
            this.txtStartingNo.MaxLength = 5;
            this.txtStartingNo.Name = "txtStartingNo";
            this.txtStartingNo.Size = new System.Drawing.Size(89, 27);
            this.txtStartingNo.TabIndex = 5;
            this.txtStartingNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtStartingNo.Enter += new System.EventHandler(this.TxtStartingNo_Enter);
            this.txtStartingNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtStartingNo_KeyDown);
            this.txtStartingNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtStartingNo_KeyPress);
            this.txtStartingNo.Leave += new System.EventHandler(this.TxtStartingNo_Leave);
            // 
            // lblStartingNo
            // 
            this.lblStartingNo.AutoSize = true;
            this.lblStartingNo.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStartingNo.Location = new System.Drawing.Point(622, 23);
            this.lblStartingNo.Name = "lblStartingNo";
            this.lblStartingNo.Size = new System.Drawing.Size(71, 20);
            this.lblStartingNo.TabIndex = 48;
            this.lblStartingNo.Text = "Starting No";
            // 
            // txtSuffix
            // 
            this.txtSuffix.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSuffix.Location = new System.Drawing.Point(527, 46);
            this.txtSuffix.MaxLength = 10;
            this.txtSuffix.Name = "txtSuffix";
            this.txtSuffix.Size = new System.Drawing.Size(89, 27);
            this.txtSuffix.TabIndex = 4;
            this.txtSuffix.Enter += new System.EventHandler(this.TxtSuffix_Enter);
            this.txtSuffix.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtSuffix_KeyDown);
            this.txtSuffix.Leave += new System.EventHandler(this.TxtSuffix_Leave);
            // 
            // lblSuffix
            // 
            this.lblSuffix.AutoSize = true;
            this.lblSuffix.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSuffix.Location = new System.Drawing.Point(527, 23);
            this.lblSuffix.Name = "lblSuffix";
            this.lblSuffix.Size = new System.Drawing.Size(40, 20);
            this.lblSuffix.TabIndex = 44;
            this.lblSuffix.Text = "Suffix";
            // 
            // txtPrefix
            // 
            this.txtPrefix.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrefix.Location = new System.Drawing.Point(431, 46);
            this.txtPrefix.MaxLength = 10;
            this.txtPrefix.Name = "txtPrefix";
            this.txtPrefix.Size = new System.Drawing.Size(89, 27);
            this.txtPrefix.TabIndex = 3;
            this.txtPrefix.Enter += new System.EventHandler(this.TxtPrefix_Enter);
            this.txtPrefix.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtPrefix_KeyDown);
            this.txtPrefix.Leave += new System.EventHandler(this.TxtPrefix_Leave);
            // 
            // lblPrefix
            // 
            this.lblPrefix.AutoSize = true;
            this.lblPrefix.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrefix.Location = new System.Drawing.Point(431, 23);
            this.lblPrefix.Name = "lblPrefix";
            this.lblPrefix.Size = new System.Drawing.Size(40, 20);
            this.lblPrefix.TabIndex = 42;
            this.lblPrefix.Text = "Prefix";
            // 
            // cmbTransactionType
            // 
            this.cmbTransactionType.FormattingEnabled = true;
            this.cmbTransactionType.Location = new System.Drawing.Point(199, 46);
            this.cmbTransactionType.Name = "cmbTransactionType";
            this.cmbTransactionType.Size = new System.Drawing.Size(226, 27);
            this.cmbTransactionType.TabIndex = 2;
            this.cmbTransactionType.SelectedIndexChanged += new System.EventHandler(this.CmbTransactionType_SelectedIndexChanged);
            this.cmbTransactionType.Enter += new System.EventHandler(this.CmbTransactionType_Enter);
            this.cmbTransactionType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbTransactionType_KeyDown);
            this.cmbTransactionType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbTransactionType_KeyPress);
            this.cmbTransactionType.Leave += new System.EventHandler(this.CmbTransactionType_Leave);
            // 
            // lblTransactionType
            // 
            this.lblTransactionType.AutoSize = true;
            this.lblTransactionType.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransactionType.Location = new System.Drawing.Point(199, 23);
            this.lblTransactionType.Name = "lblTransactionType";
            this.lblTransactionType.Size = new System.Drawing.Size(100, 20);
            this.lblTransactionType.TabIndex = 40;
            this.lblTransactionType.Text = "Transaction Type";
            // 
            // cmbConcern
            // 
            this.cmbConcern.FormattingEnabled = true;
            this.epSettings.SetIconPadding(this.cmbConcern, 1);
            this.cmbConcern.Location = new System.Drawing.Point(111, 46);
            this.cmbConcern.Name = "cmbConcern";
            this.cmbConcern.Size = new System.Drawing.Size(83, 27);
            this.cmbConcern.TabIndex = 0;
            this.cmbConcern.SelectedIndexChanged += new System.EventHandler(this.CmbConcern_SelectedIndexChanged);
            this.cmbConcern.Enter += new System.EventHandler(this.CmbConcern_Enter);
            this.cmbConcern.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbConcern_KeyDown);
            this.cmbConcern.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbConcern_KeyPress);
            this.cmbConcern.Leave += new System.EventHandler(this.CmbConcern_Leave);
            // 
            // lblDEConcern
            // 
            this.lblDEConcern.AutoSize = true;
            this.lblDEConcern.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDEConcern.Location = new System.Drawing.Point(111, 23);
            this.lblDEConcern.Name = "lblDEConcern";
            this.lblDEConcern.Size = new System.Drawing.Size(54, 20);
            this.lblDEConcern.TabIndex = 35;
            this.lblDEConcern.Text = "Concern";
            // 
            // grdSettings
            // 
            this.grdSettings.AllowUserToAddRows = false;
            this.grdSettings.AllowUserToDeleteRows = false;
            this.grdSettings.AllowUserToResizeColumns = false;
            this.grdSettings.AllowUserToResizeRows = false;
            this.grdSettings.BackgroundColor = System.Drawing.Color.White;
            this.grdSettings.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdSettings.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.grdSettings.ColumnHeadersHeight = 30;
            this.grdSettings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdSettings.ColumnHeadersVisible = false;
            this.grdSettings.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmEdit,
            this.clmRemove});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdSettings.DefaultCellStyle = dataGridViewCellStyle5;
            this.grdSettings.EnableHeadersVisualStyles = false;
            this.grdSettings.GridColor = System.Drawing.Color.White;
            this.grdSettings.Location = new System.Drawing.Point(3, 143);
            this.grdSettings.Name = "grdSettings";
            this.grdSettings.ReadOnly = true;
            this.grdSettings.RowHeadersVisible = false;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            this.grdSettings.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.grdSettings.RowTemplate.Height = 25;
            this.grdSettings.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdSettings.Size = new System.Drawing.Size(1348, 462);
            this.grdSettings.TabIndex = 958789;
            this.grdSettings.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrdSettings_CellContentClick);
            this.grdSettings.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.GrdSettings_DataBindingComplete);
            this.grdSettings.Scroll += new System.Windows.Forms.ScrollEventHandler(this.GrdSettings_Scroll);
            // 
            // clmEdit
            // 
            this.clmEdit.HeaderText = "Edit";
            this.clmEdit.Image = global::ROMS.Properties.Resources.Edit;
            this.clmEdit.Name = "clmEdit";
            this.clmEdit.ReadOnly = true;
            this.clmEdit.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmEdit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.clmEdit.Width = 60;
            // 
            // clmRemove
            // 
            this.clmRemove.HeaderText = "Remove";
            this.clmRemove.Image = global::ROMS.Properties.Resources.remove;
            this.clmRemove.Name = "clmRemove";
            this.clmRemove.ReadOnly = true;
            this.clmRemove.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmRemove.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.clmRemove.Visible = false;
            // 
            // picLoader
            // 
            this.picLoader.BackColor = System.Drawing.Color.White;
            this.picLoader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picLoader.ErrorImage = null;
            this.picLoader.Image = global::ROMS.Properties.Resources.Iphone_spinner_2;
            this.picLoader.InitialImage = null;
            this.picLoader.Location = new System.Drawing.Point(3, 116);
            this.picLoader.Name = "picLoader";
            this.picLoader.Size = new System.Drawing.Size(1348, 507);
            this.picLoader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picLoader.TabIndex = 958787;
            this.picLoader.TabStop = false;
            this.picLoader.Visible = false;
            // 
            // epSettings
            // 
            this.epSettings.ContainerControl = this;
            // 
            // tsVoucherSettings
            // 
            this.tsVoucherSettings.BackColor = System.Drawing.Color.White;
            this.tsVoucherSettings.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsVoucherSettings.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsVoucherSettings.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspHeader});
            this.tsVoucherSettings.Location = new System.Drawing.Point(0, 0);
            this.tsVoucherSettings.Name = "tsVoucherSettings";
            this.tsVoucherSettings.Size = new System.Drawing.Size(1354, 25);
            this.tsVoucherSettings.TabIndex = 958789;
            this.tsVoucherSettings.Text = "Voucher Settings";
            // 
            // tspHeader
            // 
            this.tspHeader.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tspHeader.Image = global::ROMS.Properties.Resources.bread_crumb;
            this.tspHeader.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tspHeader.Margin = new System.Windows.Forms.Padding(15, 1, 0, 2);
            this.tspHeader.Name = "tspHeader";
            this.tspHeader.Size = new System.Drawing.Size(119, 22);
            this.tspHeader.Text = "Voucher Settings";
            // 
            // CP_Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(1354, 675);
            this.Controls.Add(this.tsVoucherSettings);
            this.Controls.Add(this.pnlSettings);
            this.Controls.Add(this.picLoader);
            this.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "CP_Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Voucher Settings";
            this.Load += new System.EventHandler(this.CP_Settings_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CP_Settings_KeyDown);
            this.Leave += new System.EventHandler(this.CP_Settings_Leave);
            this.pnlSettings.ResumeLayout(false);
            this.pnlSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_SearchGrid)).EndInit();
            this.grpVoucherSettings.ResumeLayout(false);
            this.grpVoucherSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSettings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epSettings)).EndInit();
            this.tsVoucherSettings.ResumeLayout(false);
            this.tsVoucherSettings.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel pnlSettings;
        public System.Windows.Forms.DataGridView grdSettings;
        private System.Windows.Forms.GroupBox grpVoucherSettings;
        private System.Windows.Forms.Label lblDEConcern;
        private System.Windows.Forms.ComboBox cmbTransactionType;
        private System.Windows.Forms.Label lblTransactionType;
        private System.Windows.Forms.Label lblPrefix;
        private System.Windows.Forms.TextBox txtSuffix;
        private System.Windows.Forms.Label lblSuffix;
        private System.Windows.Forms.TextBox txtStartingNo;
        private System.Windows.Forms.Label lblStartingNo;
        private System.Windows.Forms.Label lblNoRecordsFound;
        private System.Windows.Forms.PictureBox picLoader;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ComboBox cmbResetOn;
        private System.Windows.Forms.Label lblResetOn;
        private System.Windows.Forms.ErrorProvider epSettings;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ToolStrip tsVoucherSettings;
        private System.Windows.Forms.ToolStripLabel tspHeader;
        private System.Windows.Forms.TextBox txtNoOfDegits;
        private System.Windows.Forms.Label lblNoOfDigits;
        public System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TextBox txtFyyear;
        private System.Windows.Forms.Label lblFyyr;
        public System.Windows.Forms.ComboBox cmbConcern;
        public System.Windows.Forms.TextBox txtPrefix;
        public System.Windows.Forms.DataGridView DGV_SearchGrid;
        private System.Windows.Forms.DataGridViewImageColumn clmEdit;
        private System.Windows.Forms.DataGridViewImageColumn clmRemove;
    }
}