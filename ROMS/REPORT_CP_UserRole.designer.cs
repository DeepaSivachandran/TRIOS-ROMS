namespace ROMS
{
    partial class REPORT_CP_UserRole
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(REPORT_CP_UserRole));
            this.ReportRack = new System.Windows.Forms.ToolStrip();
            this.tsbPrintFormat = new System.Windows.Forms.ToolStripButton();
            this.tsbFormat = new System.Windows.Forms.ToolStripButton();
            this.tsLabelPlaceholder = new System.Windows.Forms.ToolStripLabel();
            this.pnlReportRack = new System.Windows.Forms.Panel();
            this.lvUserRole = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.lvUserList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RPTViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.grpfilter = new System.Windows.Forms.GroupBox();
            this.lblUserId = new System.Windows.Forms.Label();
            this.lblUserRoleId = new System.Windows.Forms.Label();
            this.btnListPrint = new System.Windows.Forms.Button();
            this.txtUserRole = new System.Windows.Forms.TextBox();
            this.lblSystemUser = new System.Windows.Forms.Label();
            this.cmbReportType = new System.Windows.Forms.ComboBox();
            this.lblReportType = new System.Windows.Forms.Label();
            this.txtDUserList = new System.Windows.Forms.TextBox();
            this.lblNoRecordsFound = new System.Windows.Forms.Label();
            this.picLoader = new System.Windows.Forms.PictureBox();
            this.dynamicLabelControl = new ROMS.DynamicToolStripLabelControl();
            this.ReportRack.SuspendLayout();
            this.pnlReportRack.SuspendLayout();
            this.grpfilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).BeginInit();
            this.SuspendLayout();
            // 
            // ReportRack
            // 
            this.ReportRack.BackColor = System.Drawing.Color.White;
            this.ReportRack.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReportRack.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ReportRack.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ReportRack.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbPrintFormat,
            this.tsbFormat,
            this.tsLabelPlaceholder});
            this.ReportRack.Location = new System.Drawing.Point(0, 0);
            this.ReportRack.Name = "ReportRack";
            this.ReportRack.Size = new System.Drawing.Size(1354, 27);
            this.ReportRack.TabIndex = 35;
            this.ReportRack.Text = "Rack Report";
            // 
            // tsbPrintFormat
            // 
            this.tsbPrintFormat.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbPrintFormat.BackColor = System.Drawing.Color.Green;
            this.tsbPrintFormat.ForeColor = System.Drawing.Color.White;
            this.tsbPrintFormat.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbPrintFormat.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPrintFormat.Margin = new System.Windows.Forms.Padding(-5, 1, 30, 2);
            this.tsbPrintFormat.Name = "tsbPrintFormat";
            this.tsbPrintFormat.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tsbPrintFormat.Size = new System.Drawing.Size(74, 24);
            this.tsbPrintFormat.Text = "A4-Portrait";
            this.tsbPrintFormat.ToolTipText = "A4-Portrait";
            // 
            // tsbFormat
            // 
            this.tsbFormat.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbFormat.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbFormat.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFormat.Margin = new System.Windows.Forms.Padding(-5, 1, 30, 2);
            this.tsbFormat.Name = "tsbFormat";
            this.tsbFormat.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tsbFormat.Size = new System.Drawing.Size(90, 24);
            this.tsbFormat.Text = "Print Format : ";
            this.tsbFormat.ToolTipText = "Print Format";
            // 
            // tsLabelPlaceholder
            // 
            this.tsLabelPlaceholder.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsLabelPlaceholder.Image = ((System.Drawing.Image)(resources.GetObject("tsLabelPlaceholder.Image")));
            this.tsLabelPlaceholder.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsLabelPlaceholder.Margin = new System.Windows.Forms.Padding(15, 1, 0, 2);
            this.tsLabelPlaceholder.Name = "tsLabelPlaceholder";
            this.tsLabelPlaceholder.Size = new System.Drawing.Size(58, 24);
            this.tsLabelPlaceholder.Text = "Levels";
            // 
            // pnlReportRack
            // 
            this.pnlReportRack.BackColor = System.Drawing.Color.White;
            this.pnlReportRack.Controls.Add(this.lvUserRole);
            this.pnlReportRack.Controls.Add(this.label1);
            this.pnlReportRack.Controls.Add(this.lvUserList);
            this.pnlReportRack.Controls.Add(this.RPTViewer);
            this.pnlReportRack.Controls.Add(this.grpfilter);
            this.pnlReportRack.Controls.Add(this.lblNoRecordsFound);
            this.pnlReportRack.Controls.Add(this.picLoader);
            this.pnlReportRack.Location = new System.Drawing.Point(0, 29);
            this.pnlReportRack.Name = "pnlReportRack";
            this.pnlReportRack.Size = new System.Drawing.Size(1354, 643);
            this.pnlReportRack.TabIndex = 958788;
            // 
            // lvUserRole
            // 
            this.lvUserRole.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.lvUserRole.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvUserRole.HideSelection = false;
            this.lvUserRole.Location = new System.Drawing.Point(448, 49);
            this.lvUserRole.Name = "lvUserRole";
            this.lvUserRole.Size = new System.Drawing.Size(313, 99);
            this.lvUserRole.TabIndex = 1111181;
            this.lvUserRole.UseCompatibleStateImageBehavior = false;
            this.lvUserRole.View = System.Windows.Forms.View.Details;
            this.lvUserRole.Visible = false;
            this.lvUserRole.DoubleClick += new System.EventHandler(this.lvUserRole_DoubleClick);
            this.lvUserRole.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvUserRole_KeyDown);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(377, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 20);
            this.label1.TabIndex = 1111182;
            this.label1.Text = "User Role";
            // 
            // lvUserList
            // 
            this.lvUserList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvUserList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvUserList.HideSelection = false;
            this.lvUserList.Location = new System.Drawing.Point(862, 49);
            this.lvUserList.Name = "lvUserList";
            this.lvUserList.Size = new System.Drawing.Size(318, 99);
            this.lvUserList.TabIndex = 1111178;
            this.lvUserList.UseCompatibleStateImageBehavior = false;
            this.lvUserList.View = System.Windows.Forms.View.Details;
            this.lvUserList.Visible = false;
            this.lvUserList.DoubleClick += new System.EventHandler(this.lvUserList_DoubleClick);
            this.lvUserList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvUserList_KeyDown);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 180;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Width = 10;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Width = 0;
            // 
            // RPTViewer
            // 
            this.RPTViewer.ActiveViewIndex = -1;
            this.RPTViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RPTViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.RPTViewer.Location = new System.Drawing.Point(3, 66);
            this.RPTViewer.Name = "RPTViewer";
            this.RPTViewer.ReuseParameterValuesOnRefresh = true;
            this.RPTViewer.Size = new System.Drawing.Size(1348, 573);
            this.RPTViewer.TabIndex = 1111227;
            this.RPTViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.RPTViewer.Visible = false;
            // 
            // grpfilter
            // 
            this.grpfilter.Controls.Add(this.lblUserId);
            this.grpfilter.Controls.Add(this.lblUserRoleId);
            this.grpfilter.Controls.Add(this.btnListPrint);
            this.grpfilter.Controls.Add(this.txtUserRole);
            this.grpfilter.Controls.Add(this.lblSystemUser);
            this.grpfilter.Controls.Add(this.cmbReportType);
            this.grpfilter.Controls.Add(this.lblReportType);
            this.grpfilter.Controls.Add(this.txtDUserList);
            this.grpfilter.Location = new System.Drawing.Point(3, 2);
            this.grpfilter.Name = "grpfilter";
            this.grpfilter.Size = new System.Drawing.Size(1348, 58);
            this.grpfilter.TabIndex = 0;
            this.grpfilter.TabStop = false;
            this.grpfilter.Text = "Filter By";
            // 
            // lblUserId
            // 
            this.lblUserId.AutoSize = true;
            this.lblUserId.Location = new System.Drawing.Point(666, 19);
            this.lblUserId.Name = "lblUserId";
            this.lblUserId.Size = new System.Drawing.Size(16, 20);
            this.lblUserId.TabIndex = 1111181;
            this.lblUserId.Text = "0";
            this.lblUserId.Visible = false;
            // 
            // lblUserRoleId
            // 
            this.lblUserRoleId.AutoSize = true;
            this.lblUserRoleId.Location = new System.Drawing.Point(636, -9);
            this.lblUserRoleId.Name = "lblUserRoleId";
            this.lblUserRoleId.Size = new System.Drawing.Size(16, 20);
            this.lblUserRoleId.TabIndex = 1111180;
            this.lblUserRoleId.Text = "0";
            this.lblUserRoleId.Visible = false;
            // 
            // btnListPrint
            // 
            this.btnListPrint.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListPrint.Image = global::ROMS.Properties.Resources.view;
            this.btnListPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnListPrint.Location = new System.Drawing.Point(1186, 18);
            this.btnListPrint.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnListPrint.Name = "btnListPrint";
            this.btnListPrint.Size = new System.Drawing.Size(75, 29);
            this.btnListPrint.TabIndex = 1;
            this.btnListPrint.Text = "View";
            this.btnListPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnListPrint.UseVisualStyleBackColor = true;
            this.btnListPrint.Click += new System.EventHandler(this.BtnListPrint_Click);
            this.btnListPrint.Enter += new System.EventHandler(this.BtnListPrint_Enter);
            this.btnListPrint.Leave += new System.EventHandler(this.BtnListPrint_Leave);
            // 
            // txtUserRole
            // 
            this.txtUserRole.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtUserRole.Location = new System.Drawing.Point(445, 19);
            this.txtUserRole.MaxLength = 30;
            this.txtUserRole.Name = "txtUserRole";
            this.txtUserRole.Size = new System.Drawing.Size(313, 27);
            this.txtUserRole.TabIndex = 1;
            this.txtUserRole.TextChanged += new System.EventHandler(this.txtUserRole_TextChanged);
            this.txtUserRole.Enter += new System.EventHandler(this.txtUserRole_Enter);
            this.txtUserRole.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUserRole_KeyDown);
            this.txtUserRole.Leave += new System.EventHandler(this.txtUserRole_Leave);
            // 
            // lblSystemUser
            // 
            this.lblSystemUser.AutoSize = true;
            this.lblSystemUser.Location = new System.Drawing.Point(778, 22);
            this.lblSystemUser.Name = "lblSystemUser";
            this.lblSystemUser.Size = new System.Drawing.Size(67, 20);
            this.lblSystemUser.TabIndex = 1111179;
            this.lblSystemUser.Text = "User Name";
            // 
            // cmbReportType
            // 
            this.cmbReportType.FormattingEnabled = true;
            this.cmbReportType.Location = new System.Drawing.Point(93, 19);
            this.cmbReportType.Name = "cmbReportType";
            this.cmbReportType.Size = new System.Drawing.Size(270, 27);
            this.cmbReportType.TabIndex = 0;
            this.cmbReportType.SelectedIndexChanged += new System.EventHandler(this.CmbReportType_SelectedIndexChanged);
            this.cmbReportType.Enter += new System.EventHandler(this.CmbReportType_Enter);
            this.cmbReportType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbReportType_KeyDown);
            this.cmbReportType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbReportType_KeyPress);
            this.cmbReportType.Leave += new System.EventHandler(this.CmbReportType_Leave);
            // 
            // lblReportType
            // 
            this.lblReportType.AutoSize = true;
            this.lblReportType.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReportType.Location = new System.Drawing.Point(6, 22);
            this.lblReportType.Name = "lblReportType";
            this.lblReportType.Size = new System.Drawing.Size(73, 20);
            this.lblReportType.TabIndex = 1111176;
            this.lblReportType.Text = "Report type";
            // 
            // txtDUserList
            // 
            this.txtDUserList.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtDUserList.Location = new System.Drawing.Point(859, 19);
            this.txtDUserList.MaxLength = 30;
            this.txtDUserList.Name = "txtDUserList";
            this.txtDUserList.Size = new System.Drawing.Size(313, 27);
            this.txtDUserList.TabIndex = 3;
            this.txtDUserList.TextChanged += new System.EventHandler(this.txtDUserList_TextChanged);
            this.txtDUserList.Enter += new System.EventHandler(this.txtDUserList_Enter);
            this.txtDUserList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDUserList_KeyDown);
            this.txtDUserList.Leave += new System.EventHandler(this.txtDUserList_Leave);
            // 
            // lblNoRecordsFound
            // 
            this.lblNoRecordsFound.AutoSize = true;
            this.lblNoRecordsFound.BackColor = System.Drawing.Color.White;
            this.lblNoRecordsFound.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoRecordsFound.Location = new System.Drawing.Point(625, 357);
            this.lblNoRecordsFound.Name = "lblNoRecordsFound";
            this.lblNoRecordsFound.Size = new System.Drawing.Size(106, 20);
            this.lblNoRecordsFound.TabIndex = 958789;
            this.lblNoRecordsFound.Text = "No Records Found";
            this.lblNoRecordsFound.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // picLoader
            // 
            this.picLoader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picLoader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picLoader.ErrorImage = null;
            this.picLoader.Image = global::ROMS.Properties.Resources.Iphone_spinner_2;
            this.picLoader.InitialImage = null;
            this.picLoader.Location = new System.Drawing.Point(3, 66);
            this.picLoader.Name = "picLoader";
            this.picLoader.Size = new System.Drawing.Size(1351, 576);
            this.picLoader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picLoader.TabIndex = 958790;
            this.picLoader.TabStop = false;
            this.picLoader.Visible = false;
            // 
            // dynamicLabelControl
            // 
            this.dynamicLabelControl.PlaceholderLabel = null;
            // 
            // REPORT_CP_UserRole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(1354, 675);
            this.Controls.Add(this.pnlReportRack);
            this.Controls.Add(this.ReportRack);
            this.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "REPORT_CP_UserRole";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rack Report";
            this.Load += new System.EventHandler(this.REPORT_CP_Rack_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.REPORT_CP_Rack_KeyDown);
            this.ReportRack.ResumeLayout(false);
            this.ReportRack.PerformLayout();
            this.pnlReportRack.ResumeLayout(false);
            this.pnlReportRack.PerformLayout();
            this.grpfilter.ResumeLayout(false);
            this.grpfilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip ReportRack;
        private System.Windows.Forms.Panel pnlReportRack;
        private System.Windows.Forms.Label lblNoRecordsFound;
        private System.Windows.Forms.GroupBox grpfilter;
        private System.Windows.Forms.ComboBox cmbReportType;
        private System.Windows.Forms.Label lblReportType;
        public System.Windows.Forms.PictureBox picLoader;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer RPTViewer;
        private System.Windows.Forms.Button btnListPrint;
        public System.Windows.Forms.ToolStripButton tsbPrintFormat;
        public System.Windows.Forms.ToolStripButton tsbFormat;
        private DynamicToolStripLabelControl dynamicLabelControl;
        private System.Windows.Forms.ToolStripLabel tsLabelPlaceholder;
        public System.Windows.Forms.ListView lvUserList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Label lblSystemUser;
        private System.Windows.Forms.TextBox txtDUserList;
        public System.Windows.Forms.ListView lvUserRole;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUserRole;
        private System.Windows.Forms.Label lblUserRoleId;
        private System.Windows.Forms.Label lblUserId;
    }
}