namespace ROMS
{
    partial class REPORT_CP_Rackgroup
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ReportRackgroup = new System.Windows.Forms.ToolStrip();
            this.tspHeader = new System.Windows.Forms.ToolStripLabel();
            this.tsbPrintFormat = new System.Windows.Forms.ToolStripButton();
            this.tsbFormat = new System.Windows.Forms.ToolStripButton();
            this.pnlReportRackgroup = new System.Windows.Forms.Panel();
            this.DGV_FilterRackgroup = new System.Windows.Forms.DataGridView();
            this.lvRack = new System.Windows.Forms.ListView();
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvRackIncharge = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvRackgroup = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grpfilter = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbFormat = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbSubgroupType = new System.Windows.Forms.ComboBox();
            this.cmbProductCategory = new System.Windows.Forms.ComboBox();
            this.btnListPrint = new System.Windows.Forms.Button();
            this.lblConcern = new System.Windows.Forms.Label();
            this.cmbConcern = new System.Windows.Forms.ComboBox();
            this.lblRackCode = new System.Windows.Forms.Label();
            this.lblEmpCode = new System.Windows.Forms.Label();
            this.lblRackgroupCode = new System.Windows.Forms.Label();
            this.txtRack = new System.Windows.Forms.TextBox();
            this.lblRack = new System.Windows.Forms.Label();
            this.txtEmployeeName = new System.Windows.Forms.TextBox();
            this.lblEmployeeName = new System.Windows.Forms.Label();
            this.txtRackgroup = new System.Windows.Forms.TextBox();
            this.lblRackgroup = new System.Windows.Forms.Label();
            this.cmbReportType = new System.Windows.Forms.ComboBox();
            this.lblReportType = new System.Windows.Forms.Label();
            this.lblNoRecordsFound = new System.Windows.Forms.Label();
            this.picLoader = new System.Windows.Forms.PictureBox();
            this.RPTViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.ReportRackgroup.SuspendLayout();
            this.pnlReportRackgroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_FilterRackgroup)).BeginInit();
            this.grpfilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).BeginInit();
            this.SuspendLayout();
            // 
            // ReportRackgroup
            // 
            this.ReportRackgroup.BackColor = System.Drawing.Color.White;
            this.ReportRackgroup.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReportRackgroup.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ReportRackgroup.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ReportRackgroup.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspHeader,
            this.tsbPrintFormat,
            this.tsbFormat});
            this.ReportRackgroup.Location = new System.Drawing.Point(0, 0);
            this.ReportRackgroup.Name = "ReportRackgroup";
            this.ReportRackgroup.Size = new System.Drawing.Size(1354, 27);
            this.ReportRackgroup.TabIndex = 35;
            this.ReportRackgroup.Text = "Rackgroup Report";
            // 
            // tspHeader
            // 
            this.tspHeader.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tspHeader.Image = global::ROMS.Properties.Resources.bread_crumb;
            this.tspHeader.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tspHeader.Margin = new System.Windows.Forms.Padding(15, 1, 0, 2);
            this.tspHeader.Name = "tspHeader";
            this.tspHeader.Size = new System.Drawing.Size(127, 24);
            this.tspHeader.Text = "Rack Group Report";
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
            // pnlReportRackgroup
            // 
            this.pnlReportRackgroup.BackColor = System.Drawing.Color.White;
            this.pnlReportRackgroup.Controls.Add(this.DGV_FilterRackgroup);
            this.pnlReportRackgroup.Controls.Add(this.lvRack);
            this.pnlReportRackgroup.Controls.Add(this.lvRackIncharge);
            this.pnlReportRackgroup.Controls.Add(this.lvRackgroup);
            this.pnlReportRackgroup.Controls.Add(this.grpfilter);
            this.pnlReportRackgroup.Controls.Add(this.lblNoRecordsFound);
            this.pnlReportRackgroup.Controls.Add(this.picLoader);
            this.pnlReportRackgroup.Controls.Add(this.RPTViewer);
            this.pnlReportRackgroup.Location = new System.Drawing.Point(0, 29);
            this.pnlReportRackgroup.Name = "pnlReportRackgroup";
            this.pnlReportRackgroup.Size = new System.Drawing.Size(1354, 643);
            this.pnlReportRackgroup.TabIndex = 958788;
            // 
            // DGV_FilterRackgroup
            // 
            this.DGV_FilterRackgroup.AllowUserToAddRows = false;
            this.DGV_FilterRackgroup.AllowUserToDeleteRows = false;
            this.DGV_FilterRackgroup.AllowUserToResizeColumns = false;
            this.DGV_FilterRackgroup.AllowUserToResizeRows = false;
            this.DGV_FilterRackgroup.BackgroundColor = System.Drawing.Color.White;
            this.DGV_FilterRackgroup.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Chocolate;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Chocolate;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_FilterRackgroup.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.DGV_FilterRackgroup.ColumnHeadersHeight = 30;
            this.DGV_FilterRackgroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV_FilterRackgroup.DefaultCellStyle = dataGridViewCellStyle5;
            this.DGV_FilterRackgroup.EnableHeadersVisualStyles = false;
            this.DGV_FilterRackgroup.GridColor = System.Drawing.Color.White;
            this.DGV_FilterRackgroup.Location = new System.Drawing.Point(419, 74);
            this.DGV_FilterRackgroup.Name = "DGV_FilterRackgroup";
            this.DGV_FilterRackgroup.ReadOnly = true;
            this.DGV_FilterRackgroup.RowHeadersVisible = false;
            this.DGV_FilterRackgroup.RowHeadersWidth = 51;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.DGV_FilterRackgroup.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.DGV_FilterRackgroup.RowTemplate.Height = 25;
            this.DGV_FilterRackgroup.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV_FilterRackgroup.Size = new System.Drawing.Size(386, 226);
            this.DGV_FilterRackgroup.TabIndex = 111111158;
            this.DGV_FilterRackgroup.Visible = false;
            this.DGV_FilterRackgroup.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_FilterProduct_CellDoubleClick);
            this.DGV_FilterRackgroup.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DGV_FilterProduct_KeyDown);
            // 
            // lvRack
            // 
            this.lvRack.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9});
            this.lvRack.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvRack.HideSelection = false;
            this.lvRack.Location = new System.Drawing.Point(1047, 83);
            this.lvRack.Name = "lvRack";
            this.lvRack.Size = new System.Drawing.Size(291, 157);
            this.lvRack.TabIndex = 1111231;
            this.lvRack.UseCompatibleStateImageBehavior = false;
            this.lvRack.View = System.Windows.Forms.View.Details;
            this.lvRack.Visible = false;
            this.lvRack.DoubleClick += new System.EventHandler(this.LvRack_DoubleClick);
            this.lvRack.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LvRack_KeyDown);
            // 
            // columnHeader7
            // 
            this.columnHeader7.Width = 120;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Width = 130;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Width = 0;
            // 
            // lvRackIncharge
            // 
            this.lvRackIncharge.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.lvRackIncharge.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvRackIncharge.HideSelection = false;
            this.lvRackIncharge.Location = new System.Drawing.Point(789, 83);
            this.lvRackIncharge.Name = "lvRackIncharge";
            this.lvRackIncharge.Size = new System.Drawing.Size(457, 157);
            this.lvRackIncharge.TabIndex = 1111230;
            this.lvRackIncharge.UseCompatibleStateImageBehavior = false;
            this.lvRackIncharge.View = System.Windows.Forms.View.Details;
            this.lvRackIncharge.Visible = false;
            this.lvRackIncharge.DoubleClick += new System.EventHandler(this.LvRackIncharge_DoubleClick);
            this.lvRackIncharge.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LvRackIncharge_KeyDown);
            // 
            // columnHeader4
            // 
            this.columnHeader4.Width = 120;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Width = 130;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Width = 0;
            // 
            // lvRackgroup
            // 
            this.lvRackgroup.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvRackgroup.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvRackgroup.HideSelection = false;
            this.lvRackgroup.Location = new System.Drawing.Point(721, 83);
            this.lvRackgroup.Name = "lvRackgroup";
            this.lvRackgroup.Size = new System.Drawing.Size(457, 157);
            this.lvRackgroup.TabIndex = 1111229;
            this.lvRackgroup.UseCompatibleStateImageBehavior = false;
            this.lvRackgroup.View = System.Windows.Forms.View.Details;
            this.lvRackgroup.Visible = false;
            this.lvRackgroup.DoubleClick += new System.EventHandler(this.LvRackgroup_DoubleClick);
            this.lvRackgroup.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LvRackgroup_KeyDown);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 120;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Width = 130;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Width = 0;
            // 
            // grpfilter
            // 
            this.grpfilter.Controls.Add(this.label4);
            this.grpfilter.Controls.Add(this.cmbStatus);
            this.grpfilter.Controls.Add(this.label3);
            this.grpfilter.Controls.Add(this.cmbFormat);
            this.grpfilter.Controls.Add(this.label2);
            this.grpfilter.Controls.Add(this.label1);
            this.grpfilter.Controls.Add(this.cmbSubgroupType);
            this.grpfilter.Controls.Add(this.cmbProductCategory);
            this.grpfilter.Controls.Add(this.btnListPrint);
            this.grpfilter.Controls.Add(this.lblConcern);
            this.grpfilter.Controls.Add(this.cmbConcern);
            this.grpfilter.Controls.Add(this.lblRackCode);
            this.grpfilter.Controls.Add(this.lblEmpCode);
            this.grpfilter.Controls.Add(this.lblRackgroupCode);
            this.grpfilter.Controls.Add(this.txtRack);
            this.grpfilter.Controls.Add(this.lblRack);
            this.grpfilter.Controls.Add(this.txtEmployeeName);
            this.grpfilter.Controls.Add(this.lblEmployeeName);
            this.grpfilter.Controls.Add(this.txtRackgroup);
            this.grpfilter.Controls.Add(this.lblRackgroup);
            this.grpfilter.Controls.Add(this.cmbReportType);
            this.grpfilter.Controls.Add(this.lblReportType);
            this.grpfilter.Location = new System.Drawing.Point(12, 2);
            this.grpfilter.Name = "grpfilter";
            this.grpfilter.Size = new System.Drawing.Size(1330, 83);
            this.grpfilter.TabIndex = 0;
            this.grpfilter.TabStop = false;
            this.grpfilter.Text = "Filter By";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(990, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 20);
            this.label4.TabIndex = 1111244;
            this.label4.Text = "Status";
            // 
            // cmbStatus
            // 
            this.cmbStatus.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(990, 45);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(104, 27);
            this.cmbStatus.TabIndex = 6;
            this.cmbStatus.Enter += new System.EventHandler(this.cmbStatus_Enter);
            this.cmbStatus.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbStatus_KeyDown);
            this.cmbStatus.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbStatus_KeyPress);
            this.cmbStatus.Leave += new System.EventHandler(this.cmbStatus_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(880, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 20);
            this.label3.TabIndex = 1111242;
            this.label3.Text = "Report Format";
            // 
            // cmbFormat
            // 
            this.cmbFormat.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFormat.FormattingEnabled = true;
            this.cmbFormat.Location = new System.Drawing.Point(880, 45);
            this.cmbFormat.Name = "cmbFormat";
            this.cmbFormat.Size = new System.Drawing.Size(104, 27);
            this.cmbFormat.TabIndex = 5;
            this.cmbFormat.Enter += new System.EventHandler(this.CmbFormat_Enter);
            this.cmbFormat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbFormat_KeyDown);
            this.cmbFormat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbFormat_KeyPress);
            this.cmbFormat.Leave += new System.EventHandler(this.CmbFormat_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(628, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 20);
            this.label2.TabIndex = 1111240;
            this.label2.Text = "Product Subgroup Type";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(770, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 20);
            this.label1.TabIndex = 1111239;
            this.label1.Text = "Product Category";
            // 
            // cmbSubgroupType
            // 
            this.cmbSubgroupType.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSubgroupType.FormattingEnabled = true;
            this.cmbSubgroupType.Location = new System.Drawing.Point(628, 45);
            this.cmbSubgroupType.Name = "cmbSubgroupType";
            this.cmbSubgroupType.Size = new System.Drawing.Size(136, 27);
            this.cmbSubgroupType.TabIndex = 3;
            this.cmbSubgroupType.Enter += new System.EventHandler(this.CmbSubgroupType_Enter);
            this.cmbSubgroupType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbSubgroupType_KeyDown);
            this.cmbSubgroupType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbSubgroupType_KeyPress);
            this.cmbSubgroupType.Leave += new System.EventHandler(this.CmbSubgroupType_Leave);
            // 
            // cmbProductCategory
            // 
            this.cmbProductCategory.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbProductCategory.FormattingEnabled = true;
            this.cmbProductCategory.Location = new System.Drawing.Point(770, 45);
            this.cmbProductCategory.Name = "cmbProductCategory";
            this.cmbProductCategory.Size = new System.Drawing.Size(104, 27);
            this.cmbProductCategory.TabIndex = 4;
            this.cmbProductCategory.Enter += new System.EventHandler(this.CmbProductCategory_Enter);
            this.cmbProductCategory.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbProductCategory_KeyDown);
            this.cmbProductCategory.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbProductCategory_KeyPress);
            this.cmbProductCategory.Leave += new System.EventHandler(this.CmbProductCategory_Leave);
            // 
            // btnListPrint
            // 
            this.btnListPrint.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListPrint.Image = global::ROMS.Properties.Resources.view;
            this.btnListPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnListPrint.Location = new System.Drawing.Point(1100, 44);
            this.btnListPrint.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnListPrint.Name = "btnListPrint";
            this.btnListPrint.Size = new System.Drawing.Size(75, 29);
            this.btnListPrint.TabIndex = 7;
            this.btnListPrint.Text = "View";
            this.btnListPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnListPrint.UseVisualStyleBackColor = true;
            this.btnListPrint.Click += new System.EventHandler(this.BtnListPrint_Click);
            this.btnListPrint.Enter += new System.EventHandler(this.BtnListPrint_Enter);
            this.btnListPrint.Leave += new System.EventHandler(this.BtnListPrint_Leave);
            // 
            // lblConcern
            // 
            this.lblConcern.AutoSize = true;
            this.lblConcern.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConcern.Location = new System.Drawing.Point(311, 22);
            this.lblConcern.Name = "lblConcern";
            this.lblConcern.Size = new System.Drawing.Size(54, 20);
            this.lblConcern.TabIndex = 1111236;
            this.lblConcern.Text = "Concern";
            // 
            // cmbConcern
            // 
            this.cmbConcern.FormattingEnabled = true;
            this.cmbConcern.Location = new System.Drawing.Point(311, 45);
            this.cmbConcern.Name = "cmbConcern";
            this.cmbConcern.Size = new System.Drawing.Size(90, 27);
            this.cmbConcern.TabIndex = 1;
            this.cmbConcern.Enter += new System.EventHandler(this.CmbConcern_Enter);
            this.cmbConcern.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbConcern_KeyDown);
            this.cmbConcern.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbConcern_KeyPress);
            this.cmbConcern.Leave += new System.EventHandler(this.CmbConcern_Leave);
            // 
            // lblRackCode
            // 
            this.lblRackCode.AutoSize = true;
            this.lblRackCode.Location = new System.Drawing.Point(1299, 49);
            this.lblRackCode.Name = "lblRackCode";
            this.lblRackCode.Size = new System.Drawing.Size(16, 20);
            this.lblRackCode.TabIndex = 1111234;
            this.lblRackCode.Text = "0";
            this.lblRackCode.Visible = false;
            // 
            // lblEmpCode
            // 
            this.lblEmpCode.AutoSize = true;
            this.lblEmpCode.Location = new System.Drawing.Point(1299, 19);
            this.lblEmpCode.Name = "lblEmpCode";
            this.lblEmpCode.Size = new System.Drawing.Size(16, 20);
            this.lblEmpCode.TabIndex = 1111233;
            this.lblEmpCode.Text = "0";
            this.lblEmpCode.Visible = false;
            // 
            // lblRackgroupCode
            // 
            this.lblRackgroupCode.AutoSize = true;
            this.lblRackgroupCode.Location = new System.Drawing.Point(580, 22);
            this.lblRackgroupCode.Name = "lblRackgroupCode";
            this.lblRackgroupCode.Size = new System.Drawing.Size(16, 20);
            this.lblRackgroupCode.TabIndex = 1111232;
            this.lblRackgroupCode.Text = "0";
            this.lblRackgroupCode.Visible = false;
            // 
            // txtRack
            // 
            this.txtRack.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtRack.Location = new System.Drawing.Point(1200, 44);
            this.txtRack.MaxLength = 100;
            this.txtRack.Name = "txtRack";
            this.txtRack.Size = new System.Drawing.Size(93, 27);
            this.txtRack.TabIndex = 3;
            this.txtRack.Visible = false;
            this.txtRack.TextChanged += new System.EventHandler(this.TxtRack_TextChanged);
            this.txtRack.Enter += new System.EventHandler(this.TxtRack_Enter);
            this.txtRack.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtRack_KeyDown);
            this.txtRack.Leave += new System.EventHandler(this.TxtRack_Leave);
            // 
            // lblRack
            // 
            this.lblRack.AutoSize = true;
            this.lblRack.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRack.Location = new System.Drawing.Point(1258, -5);
            this.lblRack.Name = "lblRack";
            this.lblRack.Size = new System.Drawing.Size(35, 20);
            this.lblRack.TabIndex = 1111181;
            this.lblRack.Text = "Rack";
            this.lblRack.Visible = false;
            // 
            // txtEmployeeName
            // 
            this.txtEmployeeName.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtEmployeeName.Location = new System.Drawing.Point(1200, 12);
            this.txtEmployeeName.MaxLength = 100;
            this.txtEmployeeName.Name = "txtEmployeeName";
            this.txtEmployeeName.Size = new System.Drawing.Size(93, 27);
            this.txtEmployeeName.TabIndex = 2;
            this.txtEmployeeName.Visible = false;
            this.txtEmployeeName.TextChanged += new System.EventHandler(this.TxtEmployeeName_TextChanged);
            this.txtEmployeeName.Enter += new System.EventHandler(this.TxtEmployeeName_Enter);
            this.txtEmployeeName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtEmployeeName_KeyDown);
            this.txtEmployeeName.Leave += new System.EventHandler(this.TxtEmployeeName_Leave);
            // 
            // lblEmployeeName
            // 
            this.lblEmployeeName.AutoSize = true;
            this.lblEmployeeName.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmployeeName.Location = new System.Drawing.Point(1120, -4);
            this.lblEmployeeName.Name = "lblEmployeeName";
            this.lblEmployeeName.Size = new System.Drawing.Size(92, 20);
            this.lblEmployeeName.TabIndex = 1111179;
            this.lblEmployeeName.Text = "Employee Name";
            this.lblEmployeeName.Visible = false;
            // 
            // txtRackgroup
            // 
            this.txtRackgroup.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtRackgroup.Location = new System.Drawing.Point(407, 45);
            this.txtRackgroup.MaxLength = 100;
            this.txtRackgroup.Name = "txtRackgroup";
            this.txtRackgroup.Size = new System.Drawing.Size(215, 27);
            this.txtRackgroup.TabIndex = 2;
            this.txtRackgroup.TextChanged += new System.EventHandler(this.TxtRackgroup_TextChanged);
            this.txtRackgroup.Enter += new System.EventHandler(this.TxtRackgroup_Enter);
            this.txtRackgroup.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtRackgroup_KeyDown);
            this.txtRackgroup.Leave += new System.EventHandler(this.TxtRackgroup_Leave);
            // 
            // lblRackgroup
            // 
            this.lblRackgroup.AutoSize = true;
            this.lblRackgroup.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRackgroup.Location = new System.Drawing.Point(407, 22);
            this.lblRackgroup.Name = "lblRackgroup";
            this.lblRackgroup.Size = new System.Drawing.Size(71, 20);
            this.lblRackgroup.TabIndex = 1111177;
            this.lblRackgroup.Text = "Rack Group";
            // 
            // cmbReportType
            // 
            this.cmbReportType.FormattingEnabled = true;
            this.cmbReportType.Location = new System.Drawing.Point(6, 45);
            this.cmbReportType.Name = "cmbReportType";
            this.cmbReportType.Size = new System.Drawing.Size(299, 27);
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
            // lblNoRecordsFound
            // 
            this.lblNoRecordsFound.AutoSize = true;
            this.lblNoRecordsFound.BackColor = System.Drawing.Color.White;
            this.lblNoRecordsFound.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoRecordsFound.Location = new System.Drawing.Point(624, 356);
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
            this.picLoader.Location = new System.Drawing.Point(12, 91);
            this.picLoader.Name = "picLoader";
            this.picLoader.Size = new System.Drawing.Size(1330, 551);
            this.picLoader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picLoader.TabIndex = 958790;
            this.picLoader.TabStop = false;
            this.picLoader.Visible = false;
            // 
            // RPTViewer
            // 
            this.RPTViewer.ActiveViewIndex = -1;
            this.RPTViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RPTViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.RPTViewer.Location = new System.Drawing.Point(12, 91);
            this.RPTViewer.Name = "RPTViewer";
            this.RPTViewer.ReuseParameterValuesOnRefresh = true;
            this.RPTViewer.Size = new System.Drawing.Size(1326, 548);
            this.RPTViewer.TabIndex = 1111227;
            this.RPTViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.RPTViewer.Visible = false;
            // 
            // REPORT_CP_Rackgroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(1354, 675);
            this.Controls.Add(this.pnlReportRackgroup);
            this.Controls.Add(this.ReportRackgroup);
            this.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "REPORT_CP_Rackgroup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HSN Report";
            this.Load += new System.EventHandler(this.REPORT_CP_Rackgroup_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.REPORT_CP_Rackgroup_KeyDown);
            this.ReportRackgroup.ResumeLayout(false);
            this.ReportRackgroup.PerformLayout();
            this.pnlReportRackgroup.ResumeLayout(false);
            this.pnlReportRackgroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_FilterRackgroup)).EndInit();
            this.grpfilter.ResumeLayout(false);
            this.grpfilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip ReportRackgroup;
        private System.Windows.Forms.ToolStripLabel tspHeader;
        private System.Windows.Forms.Panel pnlReportRackgroup;
        private System.Windows.Forms.Label lblNoRecordsFound;
        private System.Windows.Forms.GroupBox grpfilter;
        private System.Windows.Forms.ComboBox cmbReportType;
        private System.Windows.Forms.Label lblReportType;
        public System.Windows.Forms.PictureBox picLoader;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer RPTViewer;
        private System.Windows.Forms.Button btnListPrint;
        private System.Windows.Forms.Label lblRackgroup;
        private System.Windows.Forms.TextBox txtRackgroup;
        private System.Windows.Forms.Label lblEmployeeName;
        private System.Windows.Forms.TextBox txtEmployeeName;
        private System.Windows.Forms.Label lblRack;
        private System.Windows.Forms.TextBox txtRack;
        public System.Windows.Forms.ListView lvRackgroup;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        public System.Windows.Forms.ListView lvRackIncharge;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.Label lblRackgroupCode;
        public System.Windows.Forms.ListView lvRack;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.Label lblEmpCode;
        private System.Windows.Forms.Label lblRackCode;
        private System.Windows.Forms.ComboBox cmbConcern;
        private System.Windows.Forms.Label lblConcern;
        public System.Windows.Forms.DataGridView DGV_FilterRackgroup;
        private System.Windows.Forms.ComboBox cmbProductCategory;
        private System.Windows.Forms.ComboBox cmbSubgroupType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbFormat;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.ToolStripButton tsbPrintFormat;
        public System.Windows.Forms.ToolStripButton tsbFormat;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label label4;
    }
}