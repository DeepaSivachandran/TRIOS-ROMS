namespace ROMS
{
    partial class CP_UserRole
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
            this.tbFirst = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.grpform2 = new System.Windows.Forms.TabPage();
            this.epCompany = new System.Windows.Forms.ErrorProvider(this.components);
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn3 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn4 = new System.Windows.Forms.DataGridViewImageColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUserRole = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.grpMainmenu = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grdMainMenu = new System.Windows.Forms.DataGridView();
            this.clmMenuname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmMenuId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tsBrandList.SuspendLayout();
            this.pnlCompany.SuspendLayout();
            this.tbFirst.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epCompany)).BeginInit();
            this.grpMainmenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMainMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // tsBrandList
            // 
            this.tsBrandList.BackColor = System.Drawing.Color.White;
            this.tsBrandList.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsBrandList.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
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
            this.tspHeader.Size = new System.Drawing.Size(76, 22);
            this.tspHeader.Text = "User Role";
            // 
            // pnlCompany
            // 
            this.pnlCompany.BackColor = System.Drawing.Color.White;
            this.pnlCompany.Controls.Add(this.btnSave);
            this.pnlCompany.Controls.Add(this.btnClose);
            this.pnlCompany.Controls.Add(this.txtUserRole);
            this.pnlCompany.Controls.Add(this.label1);
            this.pnlCompany.Controls.Add(this.tbFirst);
            this.pnlCompany.Location = new System.Drawing.Point(0, 29);
            this.pnlCompany.Name = "pnlCompany";
            this.pnlCompany.Size = new System.Drawing.Size(1354, 643);
            this.pnlCompany.TabIndex = 958797;
            // 
            // tbFirst
            // 
            this.tbFirst.Controls.Add(this.tabPage1);
            this.tbFirst.Controls.Add(this.grpform2);
            this.tbFirst.Location = new System.Drawing.Point(12, 52);
            this.tbFirst.Name = "tbFirst";
            this.tbFirst.SelectedIndex = 0;
            this.tbFirst.Size = new System.Drawing.Size(1330, 546);
            this.tbFirst.TabIndex = 0;
            this.tbFirst.SelectedIndexChanged += new System.EventHandler(this.TcCompanyDetails_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.grpMainmenu);
            this.tabPage1.Location = new System.Drawing.Point(4, 28);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1322, 514);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "page 1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // grpform2
            // 
            this.grpform2.Location = new System.Drawing.Point(4, 28);
            this.grpform2.Name = "grpform2";
            this.grpform2.Padding = new System.Windows.Forms.Padding(3);
            this.grpform2.Size = new System.Drawing.Size(1322, 535);
            this.grpform2.TabIndex = 1;
            this.grpform2.Text = "page 2";
            this.grpform2.UseVisualStyleBackColor = true;
            this.grpform2.Leave += new System.EventHandler(this.Grpform2_Leave);
            // 
            // epCompany
            // 
            this.epCompany.ContainerControl = this;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "Edit";
            this.dataGridViewImageColumn1.Image = global::ROMS.Properties.Resources.Edit;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.HeaderText = "Remove";
            this.dataGridViewImageColumn2.Image = global::ROMS.Properties.Resources.remove;
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.Width = 80;
            // 
            // dataGridViewImageColumn3
            // 
            this.dataGridViewImageColumn3.HeaderText = "Edit";
            this.dataGridViewImageColumn3.Image = global::ROMS.Properties.Resources.Edit;
            this.dataGridViewImageColumn3.Name = "dataGridViewImageColumn3";
            // 
            // dataGridViewImageColumn4
            // 
            this.dataGridViewImageColumn4.HeaderText = "Remove";
            this.dataGridViewImageColumn4.Image = global::ROMS.Properties.Resources.exclude;
            this.dataGridViewImageColumn4.Name = "dataGridViewImageColumn4";
            this.dataGridViewImageColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
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
            // txtUserRole
            // 
            this.txtUserRole.Location = new System.Drawing.Point(78, 19);
            this.txtUserRole.Name = "txtUserRole";
            this.txtUserRole.Size = new System.Drawing.Size(218, 27);
            this.txtUserRole.TabIndex = 4;
            this.txtUserRole.Enter += new System.EventHandler(this.txtUserRole_Enter);
            this.txtUserRole.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUserRole_KeyDown);
            this.txtUserRole.Leave += new System.EventHandler(this.txtUserRole_Leave);
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
            // 
            // grpMainmenu
            // 
            this.grpMainmenu.Controls.Add(this.grdMainMenu);
            this.grpMainmenu.Location = new System.Drawing.Point(3, 5);
            this.grpMainmenu.Name = "grpMainmenu";
            this.grpMainmenu.Size = new System.Drawing.Size(363, 503);
            this.grpMainmenu.TabIndex = 1111182;
            this.grpMainmenu.TabStop = false;
            this.grpMainmenu.Text = "Main Menu";
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(372, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(942, 503);
            this.groupBox1.TabIndex = 1111183;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Menu Details";
            // 
            // grdMainMenu
            // 
            this.grdMainMenu.AllowUserToAddRows = false;
            this.grdMainMenu.AllowUserToDeleteRows = false;
            this.grdMainMenu.AllowUserToResizeRows = false;
            this.grdMainMenu.BackgroundColor = System.Drawing.Color.White;
            this.grdMainMenu.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdMainMenu.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdMainMenu.ColumnHeadersHeight = 30;
            this.grdMainMenu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdMainMenu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmMenuname,
            this.clmMenuId});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdMainMenu.DefaultCellStyle = dataGridViewCellStyle2;
            this.grdMainMenu.EnableHeadersVisualStyles = false;
            this.grdMainMenu.GridColor = System.Drawing.Color.White;
            this.grdMainMenu.Location = new System.Drawing.Point(15, 26);
            this.grdMainMenu.Name = "grdMainMenu";
            this.grdMainMenu.ReadOnly = true;
            this.grdMainMenu.RowHeadersVisible = false;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.grdMainMenu.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.grdMainMenu.RowTemplate.Height = 25;
            this.grdMainMenu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdMainMenu.Size = new System.Drawing.Size(332, 471);
            this.grdMainMenu.TabIndex = 20;
            // 
            // clmMenuname
            // 
            this.clmMenuname.HeaderText = "Menu Name";
            this.clmMenuname.Name = "clmMenuname";
            this.clmMenuname.ReadOnly = true;
            this.clmMenuname.Width = 310;
            // 
            // clmMenuId
            // 
            this.clmMenuId.HeaderText = "MenuId";
            this.clmMenuId.Name = "clmMenuId";
            this.clmMenuId.ReadOnly = true;
            this.clmMenuId.Visible = false;
            // 
            // CP_UserRole
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
            this.Name = "CP_UserRole";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Company";
            this.tsBrandList.ResumeLayout(false);
            this.tsBrandList.PerformLayout();
            this.pnlCompany.ResumeLayout(false);
            this.pnlCompany.PerformLayout();
            this.tbFirst.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.epCompany)).EndInit();
            this.grpMainmenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdMainMenu)).EndInit();
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
        private System.Windows.Forms.TabPage grpform2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUserRole;
        public System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox grpMainmenu;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.DataGridView grdMainMenu;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmMenuname;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmMenuId;
    }
}