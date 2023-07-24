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
            this.grdSelectedRackList = new System.Windows.Forms.DataGridView();
            this.btnView = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbracklist = new System.Windows.Forms.CheckBox();
            this.lblGC = new System.Windows.Forms.Label();
            this.lblNoofproducts = new System.Windows.Forms.Label();
            this.DGV_Racklist = new System.Windows.Forms.DataGridView();
            this.txtRackGroup = new System.Windows.Forms.TextBox();
            this.cmbShopGodown = new System.Windows.Forms.ComboBox();
            this.txtDRackGroup = new System.Windows.Forms.TextBox();
            this.cmbConcern = new System.Windows.Forms.ComboBox();
            this.txtConcern = new System.Windows.Forms.TextBox();
            this.pnlStatus = new System.Windows.Forms.Panel();
            this.rbActive = new System.Windows.Forms.RadioButton();
            this.rbInactive = new System.Windows.Forms.RadioButton();
            this.errGroup = new System.Windows.Forms.ErrorProvider(this.components);
            this.grpUserList = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmremove = new System.Windows.Forms.DataGridViewImageColumn();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtDUserName = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Label();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.clmcheckbox = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmracklist = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grbform.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSelectedRackList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Racklist)).BeginInit();
            this.pnlStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errGroup)).BeginInit();
            this.grpUserList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // grbform
            // 
            this.grbform.Controls.Add(this.Add);
            this.grbform.Controls.Add(this.grdSelectedRackList);
            this.grbform.Controls.Add(this.btnView);
            this.grbform.Controls.Add(this.label1);
            this.grbform.Controls.Add(this.cbracklist);
            this.grbform.Controls.Add(this.lblGC);
            this.grbform.Controls.Add(this.lblNoofproducts);
            this.grbform.Controls.Add(this.DGV_Racklist);
            this.grbform.Controls.Add(this.txtRackGroup);
            this.grbform.Controls.Add(this.cmbShopGodown);
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
            this.grbform.Enter += new System.EventHandler(this.Grbform_Enter);
            // 
            // Add
            // 
            this.Add.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.Add.Image = global::ROMS.Properties.Resources.add;
            this.Add.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Add.Location = new System.Drawing.Point(369, 291);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(31, 29);
            this.Add.TabIndex = 1111142;
            this.Add.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Add.UseVisualStyleBackColor = true;
            // 
            // grdSelectedRackList
            // 
            this.grdSelectedRackList.AllowUserToAddRows = false;
            this.grdSelectedRackList.AllowUserToDeleteRows = false;
            this.grdSelectedRackList.AllowUserToResizeRows = false;
            this.grdSelectedRackList.BackgroundColor = System.Drawing.Color.White;
            this.grdSelectedRackList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(242)))), ((int)(((byte)(213)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdSelectedRackList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdSelectedRackList.ColumnHeadersHeight = 30;
            this.grdSelectedRackList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdSelectedRackList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column5,
            this.dataGridViewTextBoxColumn2,
            this.Column6,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdSelectedRackList.DefaultCellStyle = dataGridViewCellStyle2;
            this.grdSelectedRackList.EnableHeadersVisualStyles = false;
            this.grdSelectedRackList.GridColor = System.Drawing.Color.White;
            this.grdSelectedRackList.Location = new System.Drawing.Point(405, 149);
            this.grdSelectedRackList.Name = "grdSelectedRackList";
            this.grdSelectedRackList.RowHeadersVisible = false;
            this.grdSelectedRackList.RowHeadersWidth = 70;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.grdSelectedRackList.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.grdSelectedRackList.RowTemplate.Height = 25;
            this.grdSelectedRackList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.grdSelectedRackList.ShowRowErrors = false;
            this.grdSelectedRackList.Size = new System.Drawing.Size(347, 314);
            this.grdSelectedRackList.TabIndex = 1111141;
            this.grdSelectedRackList.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.GrdSelectedRackList_CellMouseDoubleClick);
            // 
            // btnView
            // 
            this.btnView.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnView.Image = global::ROMS.Properties.Resources.view;
            this.btnView.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnView.Location = new System.Drawing.Point(140, 114);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(74, 29);
            this.btnView.TabIndex = 1111140;
            this.btnView.Text = "View";
            this.btnView.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnView.UseVisualStyleBackColor = true;
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
            // cbracklist
            // 
            this.cbracklist.AutoSize = true;
            this.cbracklist.Location = new System.Drawing.Point(36, 158);
            this.cbracklist.Name = "cbracklist";
            this.cbracklist.Size = new System.Drawing.Size(15, 14);
            this.cbracklist.TabIndex = 1111138;
            this.cbracklist.UseVisualStyleBackColor = true;
            // 
            // lblGC
            // 
            this.lblGC.AutoSize = true;
            this.lblGC.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Bold);
            this.lblGC.ForeColor = System.Drawing.Color.Crimson;
            this.lblGC.Location = new System.Drawing.Point(735, 118);
            this.lblGC.Name = "lblGC";
            this.lblGC.Size = new System.Drawing.Size(17, 20);
            this.lblGC.TabIndex = 1111137;
            this.lblGC.Text = "0";
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
            // DGV_Racklist
            // 
            this.DGV_Racklist.AllowUserToAddRows = false;
            this.DGV_Racklist.AllowUserToDeleteRows = false;
            this.DGV_Racklist.AllowUserToResizeRows = false;
            this.DGV_Racklist.BackgroundColor = System.Drawing.Color.White;
            this.DGV_Racklist.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(242)))), ((int)(((byte)(213)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_Racklist.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.DGV_Racklist.ColumnHeadersHeight = 30;
            this.DGV_Racklist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGV_Racklist.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmcheckbox,
            this.Column4,
            this.clmracklist,
            this.Column7,
            this.Column1});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV_Racklist.DefaultCellStyle = dataGridViewCellStyle5;
            this.DGV_Racklist.EnableHeadersVisualStyles = false;
            this.DGV_Racklist.GridColor = System.Drawing.Color.White;
            this.DGV_Racklist.Location = new System.Drawing.Point(18, 149);
            this.DGV_Racklist.Name = "DGV_Racklist";
            this.DGV_Racklist.RowHeadersVisible = false;
            this.DGV_Racklist.RowHeadersWidth = 70;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            this.DGV_Racklist.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.DGV_Racklist.RowTemplate.Height = 25;
            this.DGV_Racklist.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DGV_Racklist.ShowRowErrors = false;
            this.DGV_Racklist.Size = new System.Drawing.Size(347, 314);
            this.DGV_Racklist.TabIndex = 958801;
            this.DGV_Racklist.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_Racklist_CellContentClick);
            this.DGV_Racklist.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_Racklist_CellContentDoubleClick);
            this.DGV_Racklist.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DGV_Racklist_CellMouseDoubleClick);
            // 
            // txtRackGroup
            // 
            this.txtRackGroup.Location = new System.Drawing.Point(134, 58);
            this.txtRackGroup.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtRackGroup.Name = "txtRackGroup";
            this.txtRackGroup.Size = new System.Drawing.Size(194, 27);
            this.txtRackGroup.TabIndex = 1111135;
            // 
            // cmbShopGodown
            // 
            this.cmbShopGodown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbShopGodown.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbShopGodown.FormattingEnabled = true;
            this.cmbShopGodown.Location = new System.Drawing.Point(18, 115);
            this.cmbShopGodown.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbShopGodown.Name = "cmbShopGodown";
            this.cmbShopGodown.Size = new System.Drawing.Size(116, 27);
            this.cmbShopGodown.TabIndex = 1111134;
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
            this.txtDRackGroup.TabIndex = 1111133;
            this.txtDRackGroup.Text = "Rack Group Name";
            // 
            // cmbConcern
            // 
            this.cmbConcern.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbConcern.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbConcern.FormattingEnabled = true;
            this.cmbConcern.Location = new System.Drawing.Point(134, 31);
            this.cmbConcern.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbConcern.Name = "cmbConcern";
            this.cmbConcern.Size = new System.Drawing.Size(194, 27);
            this.cmbConcern.TabIndex = 0;
            this.cmbConcern.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbGroupName_KeyDown);
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
            this.txtConcern.TabIndex = 1111130;
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
            this.pnlStatus.TabIndex = 3;
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
            this.rbActive.TabIndex = 3;
            this.rbActive.TabStop = true;
            this.rbActive.Text = "Active";
            this.rbActive.UseVisualStyleBackColor = true;
            this.rbActive.CheckedChanged += new System.EventHandler(this.RbActive_CheckedChanged);
            // 
            // rbInactive
            // 
            this.rbInactive.AutoSize = true;
            this.rbInactive.Font = new System.Drawing.Font("Oswald Regular", 9.75F);
            this.rbInactive.Location = new System.Drawing.Point(110, 1);
            this.rbInactive.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rbInactive.Name = "rbInactive";
            this.rbInactive.Size = new System.Drawing.Size(63, 21);
            this.rbInactive.TabIndex = 4;
            this.rbInactive.Text = "Inactive";
            this.rbInactive.UseVisualStyleBackColor = true;
            // 
            // errGroup
            // 
            this.errGroup.ContainerControl = this;
            // 
            // grpUserList
            // 
            this.grpUserList.Controls.Add(this.dataGridView1);
            this.grpUserList.Controls.Add(this.txtUserName);
            this.grpUserList.Controls.Add(this.txtDUserName);
            this.grpUserList.Controls.Add(this.btnAdd);
            this.grpUserList.Location = new System.Drawing.Point(797, 11);
            this.grpUserList.Name = "grpUserList";
            this.grpUserList.Size = new System.Drawing.Size(481, 233);
            this.grpUserList.TabIndex = 1111137;
            this.grpUserList.TabStop = false;
            this.grpUserList.Text = "Staff Details";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(242)))), ((int)(((byte)(213)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridView1.ColumnHeadersHeight = 30;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column3,
            this.dataGridViewTextBoxColumn1,
            this.Column2,
            this.clmremove});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.GridColor = System.Drawing.Color.White;
            this.dataGridView1.Location = new System.Drawing.Point(12, 60);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 70;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.ShowRowErrors = false;
            this.dataGridView1.Size = new System.Drawing.Size(455, 166);
            this.dataGridView1.TabIndex = 1111136;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "S.No.";
            this.Column3.Name = "Column3";
            this.Column3.Width = 50;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Staff Name";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 220;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Designation";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // clmremove
            // 
            this.clmremove.HeaderText = "Remove";
            this.clmremove.Name = "clmremove";
            this.clmremove.Width = 50;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(120, 31);
            this.txtUserName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(313, 27);
            this.txtUserName.TabIndex = 1111136;
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
            // btnAdd
            // 
            this.btnAdd.Image = global::ROMS.Properties.Resources.plus;
            this.btnAdd.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAdd.Location = new System.Drawing.Point(444, 31);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(23, 27);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "        ";
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
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
            this.txtStatus.TabIndex = 1111136;
            this.txtStatus.Text = "Status";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnSave.Image = global::ROMS.Properties.Resources.save;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(1110, 445);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 29);
            this.btnSave.TabIndex = 5;
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
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            this.btnClose.Enter += new System.EventHandler(this.btnClose_Enter);
            this.btnClose.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnClose_KeyDown);
            this.btnClose.Leave += new System.EventHandler(this.btnClose_Leave);
            // 
            // clmcheckbox
            // 
            this.clmcheckbox.HeaderText = "";
            this.clmcheckbox.Name = "clmcheckbox";
            this.clmcheckbox.Width = 50;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "S.No.";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 50;
            // 
            // clmracklist
            // 
            this.clmracklist.HeaderText = "Rack";
            this.clmracklist.MinimumWidth = 6;
            this.clmracklist.Name = "clmracklist";
            this.clmracklist.Width = 60;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Description";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 250;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Total Products";
            this.Column1.Name = "Column1";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "S.No.";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 50;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Rack";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 60;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Description";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 200;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Total Products";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Remove";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 60;
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
            this.Load += new System.EventHandler(this.CP_SubGroup_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CP_SubGroup_KeyDown);
            this.grbform.ResumeLayout(false);
            this.grbform.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSelectedRackList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Racklist)).EndInit();
            this.pnlStatus.ResumeLayout(false);
            this.pnlStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errGroup)).EndInit();
            this.grpUserList.ResumeLayout(false);
            this.grpUserList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox grbform;
        private System.Windows.Forms.Panel pnlStatus;
        private System.Windows.Forms.RadioButton rbInactive;
        private System.Windows.Forms.RadioButton rbActive;
        internal System.Windows.Forms.Label btnAdd;
        private System.Windows.Forms.ComboBox cmbConcern;
        private System.Windows.Forms.TextBox txtConcern;
        private System.Windows.Forms.ComboBox cmbShopGodown;
        public System.Windows.Forms.DataGridView DGV_Racklist;
        private System.Windows.Forms.ErrorProvider errGroup;
        private System.Windows.Forms.GroupBox grpUserList;
        private System.Windows.Forms.TextBox txtDUserName;
        private System.Windows.Forms.TextBox txtUserName;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Label lblGC;
        private System.Windows.Forms.Label lblNoofproducts;
        private System.Windows.Forms.CheckBox cbracklist;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnView;
        public System.Windows.Forms.DataGridView grdSelectedRackList;
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewImageColumn clmremove;
        private System.Windows.Forms.TextBox txtRackGroup;
        private System.Windows.Forms.TextBox txtDRackGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clmcheckbox;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmracklist;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
    }
}