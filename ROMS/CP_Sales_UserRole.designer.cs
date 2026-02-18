namespace ROMS
{
    partial class CP_Sales_UserRole
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
            this.tsBrandList = new System.Windows.Forms.ToolStrip();
            this.tspHeader = new System.Windows.Forms.ToolStripLabel();
            this.pnlCompany = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlStatus = new System.Windows.Forms.Panel();
            this.rbInactive = new System.Windows.Forms.RadioButton();
            this.rbActive = new System.Windows.Forms.RadioButton();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtSalesUserRole = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbFirst = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tvLevl2Submenu = new System.Windows.Forms.TreeView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tvSubmenu = new System.Windows.Forms.TreeView();
            this.grpMainmenu = new System.Windows.Forms.GroupBox();
            this.tvMainmenu = new System.Windows.Forms.TreeView();
            this.grpSalesUserPermission = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.grdUserPermission = new System.Windows.Forms.DataGridView();
            this.epCompany = new System.Windows.Forms.ErrorProvider(this.components);
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn3 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn4 = new System.Windows.Forms.DataGridViewImageColumn();
            this.clmMenuname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmViewchk = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clmCreatechk = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clmEditchk = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clmDeletechk = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clmPrintchk = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clmExcelchk = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clmNotificationchk = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clmMenuId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SURM_Access_Level = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmParentFlag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPrivilegeCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmsplflag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Action = new System.Windows.Forms.DataGridViewImageColumn();
            this.tsBrandList.SuspendLayout();
            this.pnlCompany.SuspendLayout();
            this.pnlStatus.SuspendLayout();
            this.tbFirst.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.grpMainmenu.SuspendLayout();
            this.grpSalesUserPermission.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdUserPermission)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epCompany)).BeginInit();
            this.SuspendLayout();
            // 
            // tsBrandList
            // 
            this.tsBrandList.BackColor = System.Drawing.Color.White;
            this.tsBrandList.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsBrandList.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsBrandList.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsBrandList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspHeader});
            this.tsBrandList.Location = new System.Drawing.Point(0, 0);
            this.tsBrandList.Name = "tsBrandList";
            this.tsBrandList.Size = new System.Drawing.Size(1354, 25);
            this.tsBrandList.TabIndex = 35;
            this.tsBrandList.Text = "Brand";
            // 
            // tspHeader
            // 
            this.tspHeader.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tspHeader.Image = global::ROMS.Properties.Resources.bread_crumb;
            this.tspHeader.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tspHeader.Margin = new System.Windows.Forms.Padding(15, 1, 0, 2);
            this.tspHeader.Name = "tspHeader";
            this.tspHeader.Size = new System.Drawing.Size(107, 22);
            this.tspHeader.Text = "Sales User Role";
            // 
            // pnlCompany
            // 
            this.pnlCompany.BackColor = System.Drawing.Color.White;
            this.pnlCompany.Controls.Add(this.label2);
            this.pnlCompany.Controls.Add(this.pnlStatus);
            this.pnlCompany.Controls.Add(this.btnSave);
            this.pnlCompany.Controls.Add(this.btnClose);
            this.pnlCompany.Controls.Add(this.txtSalesUserRole);
            this.pnlCompany.Controls.Add(this.label1);
            this.pnlCompany.Controls.Add(this.tbFirst);
            this.pnlCompany.Location = new System.Drawing.Point(0, 29);
            this.pnlCompany.Name = "pnlCompany";
            this.pnlCompany.Size = new System.Drawing.Size(1354, 643);
            this.pnlCompany.TabIndex = 958797;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(300, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 20);
            this.label2.TabIndex = 19;
            this.label2.Text = "Status";
            // 
            // pnlStatus
            // 
            this.pnlStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlStatus.Controls.Add(this.rbInactive);
            this.pnlStatus.Controls.Add(this.rbActive);
            this.pnlStatus.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlStatus.Location = new System.Drawing.Point(350, 19);
            this.pnlStatus.Name = "pnlStatus";
            this.pnlStatus.Size = new System.Drawing.Size(158, 27);
            this.pnlStatus.TabIndex = 18;
            // 
            // rbInactive
            // 
            this.rbInactive.AutoSize = true;
            this.rbInactive.Font = new System.Drawing.Font("Oswald Regular", 9.75F);
            this.rbInactive.Location = new System.Drawing.Point(91, 1);
            this.rbInactive.Name = "rbInactive";
            this.rbInactive.Size = new System.Drawing.Size(63, 21);
            this.rbInactive.TabIndex = 8;
            this.rbInactive.Text = "Inactive";
            this.rbInactive.UseVisualStyleBackColor = true;
            // 
            // rbActive
            // 
            this.rbActive.AutoSize = true;
            this.rbActive.Checked = true;
            this.rbActive.Font = new System.Drawing.Font("Oswald Regular", 9.75F);
            this.rbActive.Location = new System.Drawing.Point(3, 1);
            this.rbActive.Name = "rbActive";
            this.rbActive.Size = new System.Drawing.Size(54, 21);
            this.rbActive.TabIndex = 7;
            this.rbActive.TabStop = true;
            this.rbActive.Text = "Active";
            this.rbActive.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnSave.Image = global::ROMS.Properties.Resources.save;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(1175, 605);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(78, 29);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnClose.Image = global::ROMS.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(1260, 605);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(78, 29);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtSalesUserRole
            // 
            this.txtSalesUserRole.BackColor = System.Drawing.Color.White;
            this.txtSalesUserRole.Location = new System.Drawing.Point(77, 19);
            this.txtSalesUserRole.Name = "txtSalesUserRole";
            this.txtSalesUserRole.Size = new System.Drawing.Size(218, 27);
            this.txtSalesUserRole.TabIndex = 4;
            this.txtSalesUserRole.Enter += new System.EventHandler(this.txtUserRole_Enter);
            this.txtSalesUserRole.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUserRole_KeyDown);
            this.txtSalesUserRole.Leave += new System.EventHandler(this.txtUserRole_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "User Role";
            // 
            // tbFirst
            // 
            this.tbFirst.Controls.Add(this.tabPage1);
            this.tbFirst.Controls.Add(this.grpSalesUserPermission);
            this.tbFirst.Location = new System.Drawing.Point(12, 52);
            this.tbFirst.Name = "tbFirst";
            this.tbFirst.SelectedIndex = 0;
            this.tbFirst.Size = new System.Drawing.Size(1330, 546);
            this.tbFirst.TabIndex = 0;
            this.tbFirst.SelectedIndexChanged += new System.EventHandler(this.tbFirst_SelectedIndexChanged);
            this.tbFirst.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tbFirst_Selecting);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.grpMainmenu);
            this.tabPage1.Location = new System.Drawing.Point(4, 28);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1322, 514);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "User Access";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tvLevl2Submenu);
            this.groupBox3.Location = new System.Drawing.Point(839, 5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(477, 503);
            this.groupBox3.TabIndex = 1111184;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Level 2 - Sub-Menu";
            // 
            // tvLevl2Submenu
            // 
            this.tvLevl2Submenu.CheckBoxes = true;
            this.tvLevl2Submenu.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvLevl2Submenu.Location = new System.Drawing.Point(6, 26);
            this.tvLevl2Submenu.Name = "tvLevl2Submenu";
            this.tvLevl2Submenu.Size = new System.Drawing.Size(465, 471);
            this.tvLevl2Submenu.TabIndex = 1;
            this.tvLevl2Submenu.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvLevl2Submenu_AfterCheck);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tvSubmenu);
            this.groupBox1.Location = new System.Drawing.Point(372, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(461, 503);
            this.groupBox1.TabIndex = 1111183;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Level 1 - Sub-Menu";
            // 
            // tvSubmenu
            // 
            this.tvSubmenu.CheckBoxes = true;
            this.tvSubmenu.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvSubmenu.Location = new System.Drawing.Point(6, 26);
            this.tvSubmenu.Name = "tvSubmenu";
            this.tvSubmenu.Size = new System.Drawing.Size(449, 471);
            this.tvSubmenu.TabIndex = 1;
            this.tvSubmenu.BeforeCheck += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvSubmenu_BeforeCheck);
            this.tvSubmenu.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvSubmenu_AfterCheck);
            this.tvSubmenu.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.tvSubmenu_AfterExpand);
            this.tvSubmenu.DrawNode += new System.Windows.Forms.DrawTreeNodeEventHandler(this.tvSubmenu_DrawNode);
            this.tvSubmenu.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvSubmenu_AfterSelect);
            // 
            // grpMainmenu
            // 
            this.grpMainmenu.Controls.Add(this.tvMainmenu);
            this.grpMainmenu.Location = new System.Drawing.Point(3, 5);
            this.grpMainmenu.Name = "grpMainmenu";
            this.grpMainmenu.Size = new System.Drawing.Size(363, 503);
            this.grpMainmenu.TabIndex = 1111182;
            this.grpMainmenu.TabStop = false;
            this.grpMainmenu.Text = "Main Menu";
            // 
            // tvMainmenu
            // 
            this.tvMainmenu.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvMainmenu.Location = new System.Drawing.Point(6, 26);
            this.tvMainmenu.Name = "tvMainmenu";
            this.tvMainmenu.Size = new System.Drawing.Size(351, 471);
            this.tvMainmenu.TabIndex = 0;
            this.tvMainmenu.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvMainmenu_AfterSelect);
            // 
            // grpSalesUserPermission
            // 
            this.grpSalesUserPermission.Controls.Add(this.groupBox2);
            this.grpSalesUserPermission.Location = new System.Drawing.Point(4, 28);
            this.grpSalesUserPermission.Name = "grpSalesUserPermission";
            this.grpSalesUserPermission.Padding = new System.Windows.Forms.Padding(3);
            this.grpSalesUserPermission.Size = new System.Drawing.Size(1322, 514);
            this.grpSalesUserPermission.TabIndex = 1;
            this.grpSalesUserPermission.Text = "User Permission";
            this.grpSalesUserPermission.UseVisualStyleBackColor = true;
            this.grpSalesUserPermission.Leave += new System.EventHandler(this.Grpform2_Leave);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.grdUserPermission);
            this.groupBox2.Location = new System.Drawing.Point(6, -2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1310, 513);
            this.groupBox2.TabIndex = 1111183;
            this.groupBox2.TabStop = false;
            // 
            // grdUserPermission
            // 
            this.grdUserPermission.AllowUserToAddRows = false;
            this.grdUserPermission.AllowUserToDeleteRows = false;
            this.grdUserPermission.AllowUserToResizeRows = false;
            this.grdUserPermission.BackgroundColor = System.Drawing.Color.White;
            this.grdUserPermission.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdUserPermission.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdUserPermission.ColumnHeadersHeight = 30;
            this.grdUserPermission.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdUserPermission.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmMenuname,
            this.clmViewchk,
            this.clmCreatechk,
            this.clmEditchk,
            this.clmDeletechk,
            this.clmPrintchk,
            this.clmExcelchk,
            this.clmNotificationchk,
            this.clmMenuId,
            this.SURM_Access_Level,
            this.clmParentFlag,
            this.clmPrivilegeCode,
            this.clmsplflag,
            this.Action});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdUserPermission.DefaultCellStyle = dataGridViewCellStyle2;
            this.grdUserPermission.EnableHeadersVisualStyles = false;
            this.grdUserPermission.GridColor = System.Drawing.Color.White;
            this.grdUserPermission.Location = new System.Drawing.Point(6, 20);
            this.grdUserPermission.Name = "grdUserPermission";
            this.grdUserPermission.RowHeadersVisible = false;
            this.grdUserPermission.RowHeadersWidth = 51;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            this.grdUserPermission.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.grdUserPermission.RowTemplate.Height = 25;
            this.grdUserPermission.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.grdUserPermission.ShowRowErrors = false;
            this.grdUserPermission.Size = new System.Drawing.Size(1298, 482);
            this.grdUserPermission.TabIndex = 3;
            this.grdUserPermission.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdUserPermission_CellContentClick);
            this.grdUserPermission.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.grdUserPermission_CellFormatting);
            this.grdUserPermission.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.grdUserPermission_CellPainting);
            this.grdUserPermission.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdUserPermission_CellValueChanged);
            this.grdUserPermission.CurrentCellDirtyStateChanged += new System.EventHandler(this.grdUserPermission_CurrentCellDirtyStateChanged);
            this.grdUserPermission.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.grdUserPermission_DataBindingComplete);
            this.grdUserPermission.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.grdUserPermission_DefaultValuesNeeded);
            // 
            // epCompany
            // 
            this.epCompany.ContainerControl = this;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "Edit";
            this.dataGridViewImageColumn1.Image = global::ROMS.Properties.Resources.Edit;
            this.dataGridViewImageColumn1.MinimumWidth = 6;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewImageColumn1.Width = 120;
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.HeaderText = "Remove";
            this.dataGridViewImageColumn2.Image = global::ROMS.Properties.Resources.remove;
            this.dataGridViewImageColumn2.MinimumWidth = 6;
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.Width = 80;
            // 
            // dataGridViewImageColumn3
            // 
            this.dataGridViewImageColumn3.HeaderText = "Edit";
            this.dataGridViewImageColumn3.Image = global::ROMS.Properties.Resources.Edit;
            this.dataGridViewImageColumn3.MinimumWidth = 6;
            this.dataGridViewImageColumn3.Name = "dataGridViewImageColumn3";
            this.dataGridViewImageColumn3.Width = 125;
            // 
            // dataGridViewImageColumn4
            // 
            this.dataGridViewImageColumn4.HeaderText = "Remove";
            this.dataGridViewImageColumn4.Image = global::ROMS.Properties.Resources.exclude;
            this.dataGridViewImageColumn4.MinimumWidth = 6;
            this.dataGridViewImageColumn4.Name = "dataGridViewImageColumn4";
            this.dataGridViewImageColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn4.Width = 125;
            // 
            // clmMenuname
            // 
            this.clmMenuname.HeaderText = "Menu Name";
            this.clmMenuname.MinimumWidth = 6;
            this.clmMenuname.Name = "clmMenuname";
            this.clmMenuname.ReadOnly = true;
            this.clmMenuname.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmMenuname.Width = 450;
            // 
            // clmViewchk
            // 
            this.clmViewchk.HeaderText = "View";
            this.clmViewchk.MinimumWidth = 6;
            this.clmViewchk.Name = "clmViewchk";
            this.clmViewchk.Visible = false;
            this.clmViewchk.Width = 125;
            // 
            // clmCreatechk
            // 
            this.clmCreatechk.HeaderText = "Create";
            this.clmCreatechk.MinimumWidth = 6;
            this.clmCreatechk.Name = "clmCreatechk";
            this.clmCreatechk.Width = 125;
            // 
            // clmEditchk
            // 
            this.clmEditchk.HeaderText = "Edit";
            this.clmEditchk.MinimumWidth = 6;
            this.clmEditchk.Name = "clmEditchk";
            this.clmEditchk.Width = 125;
            // 
            // clmDeletechk
            // 
            this.clmDeletechk.HeaderText = "Delete";
            this.clmDeletechk.MinimumWidth = 6;
            this.clmDeletechk.Name = "clmDeletechk";
            this.clmDeletechk.Width = 125;
            // 
            // clmPrintchk
            // 
            this.clmPrintchk.HeaderText = "Print";
            this.clmPrintchk.MinimumWidth = 6;
            this.clmPrintchk.Name = "clmPrintchk";
            this.clmPrintchk.Width = 125;
            // 
            // clmExcelchk
            // 
            this.clmExcelchk.HeaderText = "Excel";
            this.clmExcelchk.MinimumWidth = 6;
            this.clmExcelchk.Name = "clmExcelchk";
            this.clmExcelchk.Width = 125;
            // 
            // clmNotificationchk
            // 
            this.clmNotificationchk.HeaderText = "Notification";
            this.clmNotificationchk.MinimumWidth = 6;
            this.clmNotificationchk.Name = "clmNotificationchk";
            this.clmNotificationchk.Width = 125;
            // 
            // clmMenuId
            // 
            this.clmMenuId.HeaderText = "MenuId";
            this.clmMenuId.MinimumWidth = 6;
            this.clmMenuId.Name = "clmMenuId";
            this.clmMenuId.Visible = false;
            this.clmMenuId.Width = 125;
            // 
            // SURM_Access_Level
            // 
            this.SURM_Access_Level.HeaderText = "SURM_Access_Level";
            this.SURM_Access_Level.MinimumWidth = 6;
            this.SURM_Access_Level.Name = "SURM_Access_Level";
            this.SURM_Access_Level.Visible = false;
            this.SURM_Access_Level.Width = 125;
            // 
            // clmParentFlag
            // 
            this.clmParentFlag.HeaderText = "Parent Flag";
            this.clmParentFlag.MinimumWidth = 6;
            this.clmParentFlag.Name = "clmParentFlag";
            this.clmParentFlag.Visible = false;
            this.clmParentFlag.Width = 125;
            // 
            // clmPrivilegeCode
            // 
            this.clmPrivilegeCode.HeaderText = "PrivilegeCode";
            this.clmPrivilegeCode.MinimumWidth = 6;
            this.clmPrivilegeCode.Name = "clmPrivilegeCode";
            this.clmPrivilegeCode.Visible = false;
            this.clmPrivilegeCode.Width = 125;
            // 
            // clmsplflag
            // 
            this.clmsplflag.HeaderText = "Spl Field Flag";
            this.clmsplflag.MinimumWidth = 6;
            this.clmsplflag.Name = "clmsplflag";
            this.clmsplflag.Visible = false;
            this.clmsplflag.Width = 125;
            // 
            // Action
            // 
            this.Action.HeaderText = "Special Permission";
            this.Action.Image = global::ROMS.Properties.Resources.padlock;
            this.Action.MinimumWidth = 6;
            this.Action.Name = "Action";
            this.Action.ReadOnly = true;
            this.Action.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Action.Width = 120;
            // 
            // CP_Sales_UserRole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(1354, 675);
            this.Controls.Add(this.pnlCompany);
            this.Controls.Add(this.tsBrandList);
            this.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "CP_Sales_UserRole";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Company";
            this.Load += new System.EventHandler(this.CP_Sales_UserRole_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CP_UserRole_KeyDown);
            this.tsBrandList.ResumeLayout(false);
            this.tsBrandList.PerformLayout();
            this.pnlCompany.ResumeLayout(false);
            this.pnlCompany.PerformLayout();
            this.pnlStatus.ResumeLayout(false);
            this.pnlStatus.PerformLayout();
            this.tbFirst.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.grpMainmenu.ResumeLayout(false);
            this.grpSalesUserPermission.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdUserPermission)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epCompany)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsBrandList;
        private System.Windows.Forms.ToolStripLabel tspHeader;
        private System.Windows.Forms.Panel pnlCompany;
        private System.Windows.Forms.TabControl tbFirst;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ErrorProvider epCompany;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn3;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn4;
        private System.Windows.Forms.TabPage grpSalesUserPermission;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSalesUserRole;
        public System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox grpMainmenu;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TreeView tvMainmenu;
        private System.Windows.Forms.TreeView tvSubmenu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlStatus;
        private System.Windows.Forms.RadioButton rbInactive;
        private System.Windows.Forms.RadioButton rbActive;
        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.DataGridView grdUserPermission;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TreeView tvLevl2Submenu;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmMenuname;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clmViewchk;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clmCreatechk;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clmEditchk;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clmDeletechk;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clmPrintchk;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clmExcelchk;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clmNotificationchk;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmMenuId;
        private System.Windows.Forms.DataGridViewTextBoxColumn SURM_Access_Level;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmParentFlag;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPrivilegeCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmsplflag;
        private System.Windows.Forms.DataGridViewImageColumn Action;
    }
}