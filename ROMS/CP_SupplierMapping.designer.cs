namespace ROMS
{
    partial class CP_SupplierMapping
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tsSupplierMapping = new System.Windows.Forms.ToolStrip();
            this.lblNoRecordsFound = new System.Windows.Forms.Label();
            this.pnlSupplierMapping = new System.Windows.Forms.Panel();
            this.grpSupplierMapping = new System.Windows.Forms.GroupBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.grpRepresentativeDetails = new System.Windows.Forms.GroupBox();
            this.grpSalesManDetails = new System.Windows.Forms.GroupBox();
            this.txtSupplier = new System.Windows.Forms.TextBox();
            this.grpSupplierDetails = new System.Windows.Forms.GroupBox();
            this.lblDESupplier = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.cmbSubGroup = new System.Windows.Forms.ComboBox();
            this.lblDEVisitDay = new System.Windows.Forms.Label();
            this.lblDESubGroup = new System.Windows.Forms.Label();
            this.cmbGroup = new System.Windows.Forms.ComboBox();
            this.lblDEGroup = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grdViewGroupList = new System.Windows.Forms.DataGridView();
            this.chkSelectAll = new System.Windows.Forms.CheckBox();
            this.grdGroupList = new System.Windows.Forms.DataGridView();
            this.chksupplier = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataGridViewButton = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.Add = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.tspSupplierMapping = new System.Windows.Forms.ToolStripLabel();
            this.tsSupplierMapping.SuspendLayout();
            this.pnlSupplierMapping.SuspendLayout();
            this.grpSupplierMapping.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdViewGroupList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdGroupList)).BeginInit();
            this.SuspendLayout();
            // 
            // tsSupplierMapping
            // 
            this.tsSupplierMapping.BackColor = System.Drawing.Color.White;
            this.tsSupplierMapping.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsSupplierMapping.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsSupplierMapping.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspSupplierMapping});
            this.tsSupplierMapping.Location = new System.Drawing.Point(0, 0);
            this.tsSupplierMapping.Name = "tsSupplierMapping";
            this.tsSupplierMapping.Size = new System.Drawing.Size(1360, 25);
            this.tsSupplierMapping.TabIndex = 35;
            this.tsSupplierMapping.Text = "Supplier Mapping";
            // 
            // lblNoRecordsFound
            // 
            this.lblNoRecordsFound.AutoSize = true;
            this.lblNoRecordsFound.BackColor = System.Drawing.Color.White;
            this.lblNoRecordsFound.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoRecordsFound.Location = new System.Drawing.Point(627, 327);
            this.lblNoRecordsFound.Name = "lblNoRecordsFound";
            this.lblNoRecordsFound.Size = new System.Drawing.Size(106, 20);
            this.lblNoRecordsFound.TabIndex = 958763;
            this.lblNoRecordsFound.Text = "No Records Found";
            this.lblNoRecordsFound.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pnlSupplierMapping
            // 
            this.pnlSupplierMapping.BackColor = System.Drawing.Color.White;
            this.pnlSupplierMapping.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSupplierMapping.Controls.Add(this.grpSupplierMapping);
            this.pnlSupplierMapping.Location = new System.Drawing.Point(1, 38);
            this.pnlSupplierMapping.Name = "pnlSupplierMapping";
            this.pnlSupplierMapping.Size = new System.Drawing.Size(1360, 573);
            this.pnlSupplierMapping.TabIndex = 958764;
            // 
            // grpSupplierMapping
            // 
            this.grpSupplierMapping.BackColor = System.Drawing.Color.White;
            this.grpSupplierMapping.Controls.Add(this.grpRepresentativeDetails);
            this.grpSupplierMapping.Controls.Add(this.grpSalesManDetails);
            this.grpSupplierMapping.Controls.Add(this.txtSupplier);
            this.grpSupplierMapping.Controls.Add(this.btnClear);
            this.grpSupplierMapping.Controls.Add(this.grpSupplierDetails);
            this.grpSupplierMapping.Controls.Add(this.lblDESupplier);
            this.grpSupplierMapping.Controls.Add(this.btnView);
            this.grpSupplierMapping.Controls.Add(this.lblDate);
            this.grpSupplierMapping.Controls.Add(this.cmbSubGroup);
            this.grpSupplierMapping.Controls.Add(this.lblDEVisitDay);
            this.grpSupplierMapping.Controls.Add(this.lblDESubGroup);
            this.grpSupplierMapping.Controls.Add(this.cmbGroup);
            this.grpSupplierMapping.Controls.Add(this.lblDEGroup);
            this.grpSupplierMapping.Controls.Add(this.groupBox1);
            this.grpSupplierMapping.Controls.Add(this.btnClose);
            this.grpSupplierMapping.Controls.Add(this.btnSave);
            this.grpSupplierMapping.Location = new System.Drawing.Point(12, 3);
            this.grpSupplierMapping.Name = "grpSupplierMapping";
            this.grpSupplierMapping.Size = new System.Drawing.Size(1330, 551);
            this.grpSupplierMapping.TabIndex = 958765;
            this.grpSupplierMapping.TabStop = false;
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(0, -65);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(302, 113);
            this.listView1.TabIndex = 23;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.Visible = false;
            // 
            // grpRepresentativeDetails
            // 
            this.grpRepresentativeDetails.Location = new System.Drawing.Point(728, 26);
            this.grpRepresentativeDetails.Name = "grpRepresentativeDetails";
            this.grpRepresentativeDetails.Size = new System.Drawing.Size(286, 114);
            this.grpRepresentativeDetails.TabIndex = 24;
            this.grpRepresentativeDetails.TabStop = false;
            this.grpRepresentativeDetails.Text = "Representative Details";
            // 
            // grpSalesManDetails
            // 
            this.grpSalesManDetails.Location = new System.Drawing.Point(1033, 26);
            this.grpSalesManDetails.Name = "grpSalesManDetails";
            this.grpSalesManDetails.Size = new System.Drawing.Size(286, 114);
            this.grpSalesManDetails.TabIndex = 35;
            this.grpSalesManDetails.TabStop = false;
            this.grpSalesManDetails.Text = "Sales Man Details";
            // 
            // txtSupplier
            // 
            this.txtSupplier.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSupplier.Location = new System.Drawing.Point(16, 49);
            this.txtSupplier.MaxLength = 50;
            this.txtSupplier.Name = "txtSupplier";
            this.txtSupplier.Size = new System.Drawing.Size(163, 27);
            this.txtSupplier.TabIndex = 34;
            // 
            // grpSupplierDetails
            // 
            this.grpSupplierDetails.Location = new System.Drawing.Point(425, 26);
            this.grpSupplierDetails.Name = "grpSupplierDetails";
            this.grpSupplierDetails.Size = new System.Drawing.Size(286, 114);
            this.grpSupplierDetails.TabIndex = 23;
            this.grpSupplierDetails.TabStop = false;
            this.grpSupplierDetails.Text = "Supplier Details";
            // 
            // lblDESupplier
            // 
            this.lblDESupplier.AutoSize = true;
            this.lblDESupplier.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDESupplier.Location = new System.Drawing.Point(16, 26);
            this.lblDESupplier.Name = "lblDESupplier";
            this.lblDESupplier.Size = new System.Drawing.Size(54, 20);
            this.lblDESupplier.TabIndex = 20;
            this.lblDESupplier.Text = "Supplier";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(280, 26);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(76, 20);
            this.lblDate.TabIndex = 22;
            this.lblDate.Text = "10/07/2023";
            // 
            // cmbSubGroup
            // 
            this.cmbSubGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSubGroup.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSubGroup.FormattingEnabled = true;
            this.cmbSubGroup.Location = new System.Drawing.Point(193, 113);
            this.cmbSubGroup.Name = "cmbSubGroup";
            this.cmbSubGroup.Size = new System.Drawing.Size(140, 27);
            this.cmbSubGroup.TabIndex = 30;
            // 
            // lblDEVisitDay
            // 
            this.lblDEVisitDay.AutoSize = true;
            this.lblDEVisitDay.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDEVisitDay.Location = new System.Drawing.Point(216, 26);
            this.lblDEVisitDay.Name = "lblDEVisitDay";
            this.lblDEVisitDay.Size = new System.Drawing.Size(57, 20);
            this.lblDEVisitDay.TabIndex = 21;
            this.lblDEVisitDay.Text = "Visit Day";
            // 
            // lblDESubGroup
            // 
            this.lblDESubGroup.AutoSize = true;
            this.lblDESubGroup.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDESubGroup.Location = new System.Drawing.Point(193, 86);
            this.lblDESubGroup.Name = "lblDESubGroup";
            this.lblDESubGroup.Size = new System.Drawing.Size(112, 20);
            this.lblDESubGroup.TabIndex = 29;
            this.lblDESubGroup.Text = "Product Sub Group";
            this.lblDESubGroup.Click += new System.EventHandler(this.LblDESubGroup_Click);
            // 
            // cmbGroup
            // 
            this.cmbGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGroup.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbGroup.FormattingEnabled = true;
            this.cmbGroup.Location = new System.Drawing.Point(16, 113);
            this.cmbGroup.Name = "cmbGroup";
            this.cmbGroup.Size = new System.Drawing.Size(163, 27);
            this.cmbGroup.TabIndex = 28;
            // 
            // lblDEGroup
            // 
            this.lblDEGroup.AutoSize = true;
            this.lblDEGroup.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDEGroup.Location = new System.Drawing.Point(16, 86);
            this.lblDEGroup.Name = "lblDEGroup";
            this.lblDEGroup.Size = new System.Drawing.Size(88, 20);
            this.lblDEGroup.TabIndex = 27;
            this.lblDEGroup.Text = "Product Group";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listView1);
            this.groupBox1.Controls.Add(this.Add);
            this.groupBox1.Controls.Add(this.grdViewGroupList);
            this.groupBox1.Controls.Add(this.chkSelectAll);
            this.groupBox1.Controls.Add(this.grdGroupList);
            this.groupBox1.Location = new System.Drawing.Point(16, 142);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1303, 353);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            // 
            // grdViewGroupList
            // 
            this.grdViewGroupList.AllowUserToAddRows = false;
            this.grdViewGroupList.AllowUserToDeleteRows = false;
            this.grdViewGroupList.AllowUserToResizeColumns = false;
            this.grdViewGroupList.AllowUserToResizeRows = false;
            this.grdViewGroupList.BackgroundColor = System.Drawing.Color.White;
            this.grdViewGroupList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(242)))), ((int)(((byte)(213)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdViewGroupList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.grdViewGroupList.ColumnHeadersHeight = 30;
            this.grdViewGroupList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdViewGroupList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.DataGridViewButton});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdViewGroupList.DefaultCellStyle = dataGridViewCellStyle8;
            this.grdViewGroupList.EnableHeadersVisualStyles = false;
            this.grdViewGroupList.GridColor = System.Drawing.Color.White;
            this.grdViewGroupList.Location = new System.Drawing.Point(675, 24);
            this.grdViewGroupList.Name = "grdViewGroupList";
            this.grdViewGroupList.ReadOnly = true;
            this.grdViewGroupList.RowHeadersVisible = false;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.White;
            this.grdViewGroupList.RowsDefaultCellStyle = dataGridViewCellStyle9;
            this.grdViewGroupList.RowTemplate.Height = 25;
            this.grdViewGroupList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdViewGroupList.Size = new System.Drawing.Size(603, 315);
            this.grdViewGroupList.TabIndex = 6;
            // 
            // chkSelectAll
            // 
            this.chkSelectAll.AutoSize = true;
            this.chkSelectAll.Location = new System.Drawing.Point(32, 34);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Size = new System.Drawing.Size(15, 14);
            this.chkSelectAll.TabIndex = 5;
            this.chkSelectAll.UseVisualStyleBackColor = true;
            // 
            // grdGroupList
            // 
            this.grdGroupList.AllowUserToAddRows = false;
            this.grdGroupList.AllowUserToDeleteRows = false;
            this.grdGroupList.AllowUserToResizeColumns = false;
            this.grdGroupList.AllowUserToResizeRows = false;
            this.grdGroupList.BackgroundColor = System.Drawing.Color.White;
            this.grdGroupList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(242)))), ((int)(((byte)(213)))));
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdGroupList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.grdGroupList.ColumnHeadersHeight = 30;
            this.grdGroupList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdGroupList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chksupplier,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdGroupList.DefaultCellStyle = dataGridViewCellStyle11;
            this.grdGroupList.EnableHeadersVisualStyles = false;
            this.grdGroupList.GridColor = System.Drawing.Color.White;
            this.grdGroupList.Location = new System.Drawing.Point(21, 23);
            this.grdGroupList.Name = "grdGroupList";
            this.grdGroupList.ReadOnly = true;
            this.grdGroupList.RowHeadersVisible = false;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.White;
            this.grdGroupList.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.grdGroupList.RowTemplate.Height = 25;
            this.grdGroupList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdGroupList.Size = new System.Drawing.Size(603, 315);
            this.grdGroupList.TabIndex = 4;
            // 
            // chksupplier
            // 
            this.chksupplier.HeaderText = "";
            this.chksupplier.Name = "chksupplier";
            this.chksupplier.ReadOnly = true;
            this.chksupplier.Width = 30;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "S.No.";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 50;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Product Group";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 120;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Product Sub Group";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 120;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Product Name";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 280;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Product Group";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 120;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Product Sub Group";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 120;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Product Name";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 280;
            // 
            // DataGridViewButton
            // 
            this.DataGridViewButton.HeaderText = "Remove";
            this.DataGridViewButton.Name = "DataGridViewButton";
            this.DataGridViewButton.ReadOnly = true;
            this.DataGridViewButton.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridViewButton.Text = "";
            this.DataGridViewButton.Width = 70;
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnClear.Image = global::ROMS.Properties.Resources.reset;
            this.btnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClear.Location = new System.Drawing.Point(1062, 507);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(84, 29);
            this.btnClear.TabIndex = 32;
            this.btnClear.Text = "Clear";
            this.btnClear.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // btnView
            // 
            this.btnView.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnView.Image = global::ROMS.Properties.Resources.view;
            this.btnView.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnView.Location = new System.Drawing.Point(344, 111);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(75, 29);
            this.btnView.TabIndex = 31;
            this.btnView.Text = "View";
            this.btnView.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnView.UseVisualStyleBackColor = true;
            // 
            // Add
            // 
            this.Add.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.Add.Image = global::ROMS.Properties.Resources.add;
            this.Add.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Add.Location = new System.Drawing.Point(633, 167);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(31, 29);
            this.Add.TabIndex = 33;
            this.Add.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Add.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnClose.Image = global::ROMS.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(1245, 507);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 29);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnSave.Image = global::ROMS.Properties.Resources.save;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(1152, 507);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(84, 29);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // tspSupplierMapping
            // 
            this.tspSupplierMapping.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tspSupplierMapping.Image = global::ROMS.Properties.Resources.bread_crumb;
            this.tspSupplierMapping.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tspSupplierMapping.Margin = new System.Windows.Forms.Padding(15, 1, 0, 2);
            this.tspSupplierMapping.Name = "tspSupplierMapping";
            this.tspSupplierMapping.Size = new System.Drawing.Size(120, 22);
            this.tspSupplierMapping.Text = "Supplier Mapping";
            // 
            // CP_SupplierMapping
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(1360, 637);
            this.Controls.Add(this.pnlSupplierMapping);
            this.Controls.Add(this.lblNoRecordsFound);
            this.Controls.Add(this.tsSupplierMapping);
            this.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "CP_SupplierMapping";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Brand";
            this.Load += new System.EventHandler(this.CP_BrandList_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CP_BrandList_KeyDown);
            this.tsSupplierMapping.ResumeLayout(false);
            this.tsSupplierMapping.PerformLayout();
            this.pnlSupplierMapping.ResumeLayout(false);
            this.grpSupplierMapping.ResumeLayout(false);
            this.grpSupplierMapping.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdViewGroupList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdGroupList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsSupplierMapping;
        private System.Windows.Forms.ToolStripLabel tspSupplierMapping;
        private System.Windows.Forms.Label lblNoRecordsFound;
        private System.Windows.Forms.Panel pnlSupplierMapping;
        private System.Windows.Forms.GroupBox grpSupplierMapping;
        private System.Windows.Forms.GroupBox grpRepresentativeDetails;
        private System.Windows.Forms.GroupBox grpSalesManDetails;
        private System.Windows.Forms.TextBox txtSupplier;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.GroupBox grpSupplierDetails;
        private System.Windows.Forms.Label lblDESupplier;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.ComboBox cmbSubGroup;
        private System.Windows.Forms.Label lblDEVisitDay;
        private System.Windows.Forms.Label lblDESubGroup;
        private System.Windows.Forms.ComboBox cmbGroup;
        private System.Windows.Forms.Label lblDEGroup;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button Add;
        public System.Windows.Forms.DataGridView grdViewGroupList;
        private System.Windows.Forms.CheckBox chkSelectAll;
        public System.Windows.Forms.DataGridView grdGroupList;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewButtonColumn DataGridViewButton;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chksupplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    }
}