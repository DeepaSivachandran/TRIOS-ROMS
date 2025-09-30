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
            this.tsBrandList = new System.Windows.Forms.ToolStrip();
            this.tspHeader = new System.Windows.Forms.ToolStripLabel();
            this.pnlCompany = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtUserRole = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbFirst = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grpMainmenu = new System.Windows.Forms.GroupBox();
            this.tvMainmenu = new System.Windows.Forms.TreeView();
            this.grpform2 = new System.Windows.Forms.TabPage();
            this.epCompany = new System.Windows.Forms.ErrorProvider(this.components);
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn3 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn4 = new System.Windows.Forms.DataGridViewImageColumn();
            this.tvSubmenu = new System.Windows.Forms.TreeView();
            this.tsBrandList.SuspendLayout();
            this.pnlCompany.SuspendLayout();
            this.tbFirst.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.grpMainmenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epCompany)).BeginInit();
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
            this.tabPage1.Text = "Menu";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tvSubmenu);
            this.groupBox1.Location = new System.Drawing.Point(372, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(942, 503);
            this.groupBox1.TabIndex = 1111183;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Menu Details";
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
            this.tvMainmenu.Font = new System.Drawing.Font("Oswald Regular", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvMainmenu.Location = new System.Drawing.Point(6, 26);
            this.tvMainmenu.Name = "tvMainmenu";
            this.tvMainmenu.Size = new System.Drawing.Size(351, 471);
            this.tvMainmenu.TabIndex = 0;
            this.tvMainmenu.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvMainmenu_AfterSelect);
            // 
            // grpform2
            // 
            this.grpform2.Location = new System.Drawing.Point(4, 28);
            this.grpform2.Name = "grpform2";
            this.grpform2.Padding = new System.Windows.Forms.Padding(3);
            this.grpform2.Size = new System.Drawing.Size(1322, 514);
            this.grpform2.TabIndex = 1;
            this.grpform2.Text = "User Role Access";
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
            // tvSubmenu
            // 
            this.tvSubmenu.CheckBoxes = true;
            this.tvSubmenu.Font = new System.Drawing.Font("Oswald Regular", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvSubmenu.Location = new System.Drawing.Point(6, 26);
            this.tvSubmenu.Name = "tvSubmenu";
            this.tvSubmenu.Size = new System.Drawing.Size(930, 471);
            this.tvSubmenu.TabIndex = 1;
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
            this.Load += new System.EventHandler(this.CP_UserRole_Load);
            this.tsBrandList.ResumeLayout(false);
            this.tsBrandList.PerformLayout();
            this.pnlCompany.ResumeLayout(false);
            this.pnlCompany.PerformLayout();
            this.tbFirst.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.grpMainmenu.ResumeLayout(false);
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
        private System.Windows.Forms.TabPage grpform2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUserRole;
        public System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox grpMainmenu;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TreeView tvMainmenu;
        private System.Windows.Forms.TreeView tvSubmenu;
    }
}