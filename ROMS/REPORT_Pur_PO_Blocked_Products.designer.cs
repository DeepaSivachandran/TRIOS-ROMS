namespace ROMS
{
    partial class REPORT_Pur_PO_Blocked_Products
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle29 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle30 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle31 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle32 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle33 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle34 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle35 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle36 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ReportSupplier = new System.Windows.Forms.ToolStrip();
            this.tspHeader = new System.Windows.Forms.ToolStripLabel();
            this.tsbPrintFormat = new System.Windows.Forms.ToolStripButton();
            this.tsbFormat = new System.Windows.Forms.ToolStripButton();
            this.pnlReportStockLocation = new System.Windows.Forms.Panel();
            this.DGV_FilterSupplier = new System.Windows.Forms.DataGridView();
            this.DGV_FilterProduct = new System.Windows.Forms.DataGridView();
            this.DGV_FilterSubgroup = new System.Windows.Forms.DataGridView();
            this.DGV_FilterGroup = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.grpfilter = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbConcern = new System.Windows.Forms.ComboBox();
            this.lblSupplierCode = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.lblschedleCode = new System.Windows.Forms.Label();
            this.txtSupplier = new System.Windows.Forms.TextBox();
            this.lblGroupCode = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnView = new System.Windows.Forms.Button();
            this.lblProductcode = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtGroup = new System.Windows.Forms.TextBox();
            this.txtSubGroup = new System.Windows.Forms.TextBox();
            this.lblSubGroupCode = new System.Windows.Forms.Label();
            this.lblNoRecordsFound = new System.Windows.Forms.Label();
            this.picLoader = new System.Windows.Forms.PictureBox();
            this.RPTViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.ReportSupplier.SuspendLayout();
            this.pnlReportStockLocation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_FilterSupplier)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_FilterProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_FilterSubgroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_FilterGroup)).BeginInit();
            this.grpfilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).BeginInit();
            this.SuspendLayout();
            // 
            // ReportSupplier
            // 
            this.ReportSupplier.BackColor = System.Drawing.Color.White;
            this.ReportSupplier.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReportSupplier.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ReportSupplier.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ReportSupplier.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspHeader,
            this.tsbPrintFormat,
            this.tsbFormat});
            this.ReportSupplier.Location = new System.Drawing.Point(0, 0);
            this.ReportSupplier.Name = "ReportSupplier";
            this.ReportSupplier.Size = new System.Drawing.Size(1354, 27);
            this.ReportSupplier.TabIndex = 35;
            this.ReportSupplier.Text = "GRN Summary Report";
            // 
            // tspHeader
            // 
            this.tspHeader.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tspHeader.Image = global::ROMS.Properties.Resources.bread_crumb;
            this.tspHeader.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tspHeader.Margin = new System.Windows.Forms.Padding(15, 1, 0, 2);
            this.tspHeader.Name = "tspHeader";
            this.tspHeader.Size = new System.Drawing.Size(236, 24);
            this.tspHeader.Text = "Supplier Wise Blocked Products Report";
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
            this.tsbPrintFormat.Size = new System.Drawing.Size(89, 24);
            this.tsbPrintFormat.Text = "A4-Landscape";
            this.tsbPrintFormat.ToolTipText = "A4-Landscape";
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
            // pnlReportStockLocation
            // 
            this.pnlReportStockLocation.BackColor = System.Drawing.Color.White;
            this.pnlReportStockLocation.Controls.Add(this.DGV_FilterSupplier);
            this.pnlReportStockLocation.Controls.Add(this.DGV_FilterProduct);
            this.pnlReportStockLocation.Controls.Add(this.DGV_FilterSubgroup);
            this.pnlReportStockLocation.Controls.Add(this.DGV_FilterGroup);
            this.pnlReportStockLocation.Controls.Add(this.label5);
            this.pnlReportStockLocation.Controls.Add(this.grpfilter);
            this.pnlReportStockLocation.Controls.Add(this.lblNoRecordsFound);
            this.pnlReportStockLocation.Controls.Add(this.picLoader);
            this.pnlReportStockLocation.Controls.Add(this.RPTViewer);
            this.pnlReportStockLocation.Location = new System.Drawing.Point(0, 29);
            this.pnlReportStockLocation.Name = "pnlReportStockLocation";
            this.pnlReportStockLocation.Size = new System.Drawing.Size(1354, 643);
            this.pnlReportStockLocation.TabIndex = 0;
            // 
            // DGV_FilterSupplier
            // 
            this.DGV_FilterSupplier.AllowUserToAddRows = false;
            this.DGV_FilterSupplier.AllowUserToDeleteRows = false;
            this.DGV_FilterSupplier.AllowUserToResizeColumns = false;
            this.DGV_FilterSupplier.AllowUserToResizeRows = false;
            this.DGV_FilterSupplier.BackgroundColor = System.Drawing.Color.White;
            this.DGV_FilterSupplier.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle25.BackColor = System.Drawing.Color.Chocolate;
            dataGridViewCellStyle25.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle25.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle25.SelectionBackColor = System.Drawing.Color.Chocolate;
            dataGridViewCellStyle25.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle25.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_FilterSupplier.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle25;
            this.DGV_FilterSupplier.ColumnHeadersHeight = 30;
            this.DGV_FilterSupplier.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle26.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle26.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle26.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle26.SelectionBackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle26.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle26.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV_FilterSupplier.DefaultCellStyle = dataGridViewCellStyle26;
            this.DGV_FilterSupplier.EnableHeadersVisualStyles = false;
            this.DGV_FilterSupplier.GridColor = System.Drawing.Color.White;
            this.DGV_FilterSupplier.Location = new System.Drawing.Point(695, 72);
            this.DGV_FilterSupplier.Name = "DGV_FilterSupplier";
            this.DGV_FilterSupplier.ReadOnly = true;
            this.DGV_FilterSupplier.RowHeadersVisible = false;
            this.DGV_FilterSupplier.RowHeadersWidth = 51;
            dataGridViewCellStyle27.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle27.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.DGV_FilterSupplier.RowsDefaultCellStyle = dataGridViewCellStyle27;
            this.DGV_FilterSupplier.RowTemplate.Height = 25;
            this.DGV_FilterSupplier.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV_FilterSupplier.Size = new System.Drawing.Size(286, 226);
            this.DGV_FilterSupplier.TabIndex = 111111168;
            this.DGV_FilterSupplier.Visible = false;
            this.DGV_FilterSupplier.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_FilterSupplier_CellDoubleClick);
            this.DGV_FilterSupplier.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DGV_FilterSupplier_KeyDown);
            // 
            // DGV_FilterProduct
            // 
            this.DGV_FilterProduct.AllowUserToAddRows = false;
            this.DGV_FilterProduct.AllowUserToDeleteRows = false;
            this.DGV_FilterProduct.AllowUserToResizeColumns = false;
            this.DGV_FilterProduct.AllowUserToResizeRows = false;
            this.DGV_FilterProduct.BackgroundColor = System.Drawing.Color.White;
            this.DGV_FilterProduct.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle28.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle28.BackColor = System.Drawing.Color.Chocolate;
            dataGridViewCellStyle28.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle28.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle28.SelectionBackColor = System.Drawing.Color.Chocolate;
            dataGridViewCellStyle28.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle28.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_FilterProduct.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle28;
            this.DGV_FilterProduct.ColumnHeadersHeight = 30;
            this.DGV_FilterProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle29.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle29.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle29.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle29.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle29.SelectionBackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle29.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle29.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV_FilterProduct.DefaultCellStyle = dataGridViewCellStyle29;
            this.DGV_FilterProduct.EnableHeadersVisualStyles = false;
            this.DGV_FilterProduct.GridColor = System.Drawing.Color.White;
            this.DGV_FilterProduct.Location = new System.Drawing.Point(425, 72);
            this.DGV_FilterProduct.Name = "DGV_FilterProduct";
            this.DGV_FilterProduct.ReadOnly = true;
            this.DGV_FilterProduct.RowHeadersVisible = false;
            this.DGV_FilterProduct.RowHeadersWidth = 51;
            dataGridViewCellStyle30.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle30.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.DGV_FilterProduct.RowsDefaultCellStyle = dataGridViewCellStyle30;
            this.DGV_FilterProduct.RowTemplate.Height = 25;
            this.DGV_FilterProduct.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV_FilterProduct.Size = new System.Drawing.Size(542, 226);
            this.DGV_FilterProduct.TabIndex = 111111169;
            this.DGV_FilterProduct.Visible = false;
            this.DGV_FilterProduct.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_FilterProduct_CellDoubleClick);
            this.DGV_FilterProduct.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DGV_FilterProduct_KeyDown);
            // 
            // DGV_FilterSubgroup
            // 
            this.DGV_FilterSubgroup.AllowUserToAddRows = false;
            this.DGV_FilterSubgroup.AllowUserToDeleteRows = false;
            this.DGV_FilterSubgroup.AllowUserToResizeColumns = false;
            this.DGV_FilterSubgroup.AllowUserToResizeRows = false;
            this.DGV_FilterSubgroup.BackgroundColor = System.Drawing.Color.White;
            this.DGV_FilterSubgroup.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle31.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle31.BackColor = System.Drawing.Color.Chocolate;
            dataGridViewCellStyle31.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle31.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle31.SelectionBackColor = System.Drawing.Color.Chocolate;
            dataGridViewCellStyle31.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle31.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_FilterSubgroup.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle31;
            this.DGV_FilterSubgroup.ColumnHeadersHeight = 30;
            this.DGV_FilterSubgroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle32.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle32.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle32.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle32.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle32.SelectionBackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle32.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle32.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV_FilterSubgroup.DefaultCellStyle = dataGridViewCellStyle32;
            this.DGV_FilterSubgroup.EnableHeadersVisualStyles = false;
            this.DGV_FilterSubgroup.GridColor = System.Drawing.Color.White;
            this.DGV_FilterSubgroup.Location = new System.Drawing.Point(252, 72);
            this.DGV_FilterSubgroup.Name = "DGV_FilterSubgroup";
            this.DGV_FilterSubgroup.ReadOnly = true;
            this.DGV_FilterSubgroup.RowHeadersVisible = false;
            this.DGV_FilterSubgroup.RowHeadersWidth = 51;
            dataGridViewCellStyle33.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle33.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.DGV_FilterSubgroup.RowsDefaultCellStyle = dataGridViewCellStyle33;
            this.DGV_FilterSubgroup.RowTemplate.Height = 25;
            this.DGV_FilterSubgroup.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV_FilterSubgroup.Size = new System.Drawing.Size(374, 226);
            this.DGV_FilterSubgroup.TabIndex = 111111171;
            this.DGV_FilterSubgroup.Visible = false;
            this.DGV_FilterSubgroup.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_FilterSubgroup_CellDoubleClick);
            this.DGV_FilterSubgroup.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DGV_FilterSubgroup_KeyDown);
            // 
            // DGV_FilterGroup
            // 
            this.DGV_FilterGroup.AllowUserToAddRows = false;
            this.DGV_FilterGroup.AllowUserToDeleteRows = false;
            this.DGV_FilterGroup.AllowUserToResizeColumns = false;
            this.DGV_FilterGroup.AllowUserToResizeRows = false;
            this.DGV_FilterGroup.BackgroundColor = System.Drawing.Color.White;
            this.DGV_FilterGroup.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle34.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle34.BackColor = System.Drawing.Color.Chocolate;
            dataGridViewCellStyle34.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle34.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle34.SelectionBackColor = System.Drawing.Color.Chocolate;
            dataGridViewCellStyle34.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle34.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_FilterGroup.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle34;
            this.DGV_FilterGroup.ColumnHeadersHeight = 30;
            this.DGV_FilterGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle35.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle35.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle35.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle35.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle35.SelectionBackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle35.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle35.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV_FilterGroup.DefaultCellStyle = dataGridViewCellStyle35;
            this.DGV_FilterGroup.EnableHeadersVisualStyles = false;
            this.DGV_FilterGroup.GridColor = System.Drawing.Color.White;
            this.DGV_FilterGroup.Location = new System.Drawing.Point(79, 72);
            this.DGV_FilterGroup.Name = "DGV_FilterGroup";
            this.DGV_FilterGroup.ReadOnly = true;
            this.DGV_FilterGroup.RowHeadersVisible = false;
            this.DGV_FilterGroup.RowHeadersWidth = 51;
            dataGridViewCellStyle36.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle36.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.DGV_FilterGroup.RowsDefaultCellStyle = dataGridViewCellStyle36;
            this.DGV_FilterGroup.RowTemplate.Height = 25;
            this.DGV_FilterGroup.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV_FilterGroup.Size = new System.Drawing.Size(293, 226);
            this.DGV_FilterGroup.TabIndex = 111111170;
            this.DGV_FilterGroup.Visible = false;
            this.DGV_FilterGroup.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_FilterGroup_CellDoubleClick);
            this.DGV_FilterGroup.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DGV_FilterGroup_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(422, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(132, 20);
            this.label5.TabIndex = 111111160;
            this.label5.Text = "Product Name/PI Code";
            // 
            // grpfilter
            // 
            this.grpfilter.Controls.Add(this.label10);
            this.grpfilter.Controls.Add(this.cmbConcern);
            this.grpfilter.Controls.Add(this.lblSupplierCode);
            this.grpfilter.Controls.Add(this.label1);
            this.grpfilter.Controls.Add(this.txtProductName);
            this.grpfilter.Controls.Add(this.lblschedleCode);
            this.grpfilter.Controls.Add(this.txtSupplier);
            this.grpfilter.Controls.Add(this.lblGroupCode);
            this.grpfilter.Controls.Add(this.label4);
            this.grpfilter.Controls.Add(this.btnView);
            this.grpfilter.Controls.Add(this.lblProductcode);
            this.grpfilter.Controls.Add(this.label2);
            this.grpfilter.Controls.Add(this.txtGroup);
            this.grpfilter.Controls.Add(this.txtSubGroup);
            this.grpfilter.Controls.Add(this.lblSubGroupCode);
            this.grpfilter.Location = new System.Drawing.Point(3, 2);
            this.grpfilter.Name = "grpfilter";
            this.grpfilter.Size = new System.Drawing.Size(1348, 82);
            this.grpfilter.TabIndex = 0;
            this.grpfilter.TabStop = false;
            this.grpfilter.Text = "Filter By";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(9, 20);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 20);
            this.label10.TabIndex = 111111175;
            this.label10.Text = "Concern";
            // 
            // cmbConcern
            // 
            this.cmbConcern.FormattingEnabled = true;
            this.cmbConcern.Location = new System.Drawing.Point(9, 43);
            this.cmbConcern.Name = "cmbConcern";
            this.cmbConcern.Size = new System.Drawing.Size(61, 27);
            this.cmbConcern.TabIndex = 0;
            this.cmbConcern.Enter += new System.EventHandler(this.cmbConcern_Enter);
            this.cmbConcern.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbConcern_KeyDown);
            this.cmbConcern.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbConcern_KeyPress);
            this.cmbConcern.Leave += new System.EventHandler(this.cmbConcern_Leave);
            // 
            // lblSupplierCode
            // 
            this.lblSupplierCode.AutoSize = true;
            this.lblSupplierCode.BackColor = System.Drawing.Color.Green;
            this.lblSupplierCode.Location = new System.Drawing.Point(846, 20);
            this.lblSupplierCode.Name = "lblSupplierCode";
            this.lblSupplierCode.Size = new System.Drawing.Size(16, 20);
            this.lblSupplierCode.TabIndex = 1111192;
            this.lblSupplierCode.Text = "0";
            this.lblSupplierCode.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(76, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 20);
            this.label1.TabIndex = 111111156;
            this.label1.Text = "Group";
            // 
            // txtProductName
            // 
            this.txtProductName.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtProductName.Location = new System.Drawing.Point(422, 43);
            this.txtProductName.MaxLength = 50;
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(264, 27);
            this.txtProductName.TabIndex = 3;
            this.txtProductName.TextChanged += new System.EventHandler(this.TxtProductName_TextChanged);
            this.txtProductName.Enter += new System.EventHandler(this.TxtProductName_Enter);
            this.txtProductName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtProductName_KeyDown);
            this.txtProductName.Leave += new System.EventHandler(this.TxtProductName_Leave);
            // 
            // lblschedleCode
            // 
            this.lblschedleCode.AutoSize = true;
            this.lblschedleCode.BackColor = System.Drawing.Color.LimeGreen;
            this.lblschedleCode.Location = new System.Drawing.Point(824, 20);
            this.lblschedleCode.Name = "lblschedleCode";
            this.lblschedleCode.Size = new System.Drawing.Size(16, 20);
            this.lblschedleCode.TabIndex = 1111191;
            this.lblschedleCode.Text = "0";
            this.lblschedleCode.Visible = false;
            // 
            // txtSupplier
            // 
            this.txtSupplier.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtSupplier.Location = new System.Drawing.Point(692, 43);
            this.txtSupplier.MaxLength = 100;
            this.txtSupplier.Name = "txtSupplier";
            this.txtSupplier.Size = new System.Drawing.Size(273, 27);
            this.txtSupplier.TabIndex = 4;
            this.txtSupplier.TextChanged += new System.EventHandler(this.TxtSupplier_TextChanged);
            this.txtSupplier.Enter += new System.EventHandler(this.TxtSupplier_Enter);
            this.txtSupplier.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtSupplier_KeyDown);
            this.txtSupplier.Leave += new System.EventHandler(this.TxtSupplier_Leave);
            // 
            // lblGroupCode
            // 
            this.lblGroupCode.AutoSize = true;
            this.lblGroupCode.Location = new System.Drawing.Point(197, 16);
            this.lblGroupCode.Name = "lblGroupCode";
            this.lblGroupCode.Size = new System.Drawing.Size(16, 20);
            this.lblGroupCode.TabIndex = 111111161;
            this.lblGroupCode.Text = "0";
            this.lblGroupCode.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(249, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 20);
            this.label4.TabIndex = 111111158;
            this.label4.Text = "Subgroup";
            // 
            // btnView
            // 
            this.btnView.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnView.Image = global::ROMS.Properties.Resources.view;
            this.btnView.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnView.Location = new System.Drawing.Point(971, 42);
            this.btnView.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(75, 29);
            this.btnView.TabIndex = 5;
            this.btnView.Text = "View";
            this.btnView.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.BtnListPrint_Click);
            this.btnView.Enter += new System.EventHandler(this.BtnListPrint_Enter);
            this.btnView.Leave += new System.EventHandler(this.BtnListPrint_Leave);
            // 
            // lblProductcode
            // 
            this.lblProductcode.AutoSize = true;
            this.lblProductcode.Location = new System.Drawing.Point(661, 16);
            this.lblProductcode.Name = "lblProductcode";
            this.lblProductcode.Size = new System.Drawing.Size(16, 20);
            this.lblProductcode.TabIndex = 111111164;
            this.lblProductcode.Text = "0";
            this.lblProductcode.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(692, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 20);
            this.label2.TabIndex = 1111187;
            this.label2.Text = "Supplier Name";
            // 
            // txtGroup
            // 
            this.txtGroup.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtGroup.Location = new System.Drawing.Point(76, 43);
            this.txtGroup.MaxLength = 100;
            this.txtGroup.Name = "txtGroup";
            this.txtGroup.Size = new System.Drawing.Size(167, 27);
            this.txtGroup.TabIndex = 1;
            this.txtGroup.TextChanged += new System.EventHandler(this.TxtGroup_TextChanged);
            this.txtGroup.Enter += new System.EventHandler(this.TxtGroup_Enter);
            this.txtGroup.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtGroup_KeyDown);
            this.txtGroup.Leave += new System.EventHandler(this.TxtGroup_Leave);
            // 
            // txtSubGroup
            // 
            this.txtSubGroup.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtSubGroup.Location = new System.Drawing.Point(249, 43);
            this.txtSubGroup.MaxLength = 100;
            this.txtSubGroup.Name = "txtSubGroup";
            this.txtSubGroup.Size = new System.Drawing.Size(167, 27);
            this.txtSubGroup.TabIndex = 2;
            this.txtSubGroup.TextChanged += new System.EventHandler(this.TxtSubGroup_TextChanged);
            this.txtSubGroup.Enter += new System.EventHandler(this.TxtSubGroup_Enter);
            this.txtSubGroup.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtSubGroup_KeyDown);
            this.txtSubGroup.Leave += new System.EventHandler(this.TxtSubGroup_Leave);
            // 
            // lblSubGroupCode
            // 
            this.lblSubGroupCode.AutoSize = true;
            this.lblSubGroupCode.Location = new System.Drawing.Point(364, 16);
            this.lblSubGroupCode.Name = "lblSubGroupCode";
            this.lblSubGroupCode.Size = new System.Drawing.Size(16, 20);
            this.lblSubGroupCode.TabIndex = 111111163;
            this.lblSubGroupCode.Text = "0";
            this.lblSubGroupCode.Visible = false;
            // 
            // lblNoRecordsFound
            // 
            this.lblNoRecordsFound.AutoSize = true;
            this.lblNoRecordsFound.BackColor = System.Drawing.Color.White;
            this.lblNoRecordsFound.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoRecordsFound.Location = new System.Drawing.Point(625, 356);
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
            this.picLoader.Location = new System.Drawing.Point(3, 90);
            this.picLoader.Name = "picLoader";
            this.picLoader.Size = new System.Drawing.Size(1351, 552);
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
            this.RPTViewer.Location = new System.Drawing.Point(3, 90);
            this.RPTViewer.Name = "RPTViewer";
            this.RPTViewer.ReuseParameterValuesOnRefresh = true;
            this.RPTViewer.Size = new System.Drawing.Size(1348, 549);
            this.RPTViewer.TabIndex = 1111227;
            this.RPTViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.RPTViewer.Visible = false;
            // 
            // REPORT_Pur_PO_Blocked_Products
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(1354, 675);
            this.Controls.Add(this.pnlReportStockLocation);
            this.Controls.Add(this.ReportSupplier);
            this.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "REPORT_Pur_PO_Blocked_Products";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Supplier Wise Blocked Products Report";
            this.Load += new System.EventHandler(this.REPORT_GRNSummary_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.REPORT_GRNSummary_KeyDown);
            this.ReportSupplier.ResumeLayout(false);
            this.ReportSupplier.PerformLayout();
            this.pnlReportStockLocation.ResumeLayout(false);
            this.pnlReportStockLocation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_FilterSupplier)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_FilterProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_FilterSubgroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_FilterGroup)).EndInit();
            this.grpfilter.ResumeLayout(false);
            this.grpfilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip ReportSupplier;
        private System.Windows.Forms.ToolStripLabel tspHeader;
        private System.Windows.Forms.Panel pnlReportStockLocation;
        private System.Windows.Forms.Label lblNoRecordsFound;
        private System.Windows.Forms.GroupBox grpfilter;
        public System.Windows.Forms.PictureBox picLoader;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer RPTViewer;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.TextBox txtSupplier;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label lblSupplierCode;
        public System.Windows.Forms.Label lblschedleCode;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblProductcode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblGroupCode;
        private System.Windows.Forms.Label lblSubGroupCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSubGroup;
        private System.Windows.Forms.TextBox txtGroup;
        public System.Windows.Forms.DataGridView DGV_FilterSupplier;
        public System.Windows.Forms.DataGridView DGV_FilterProduct;
        public System.Windows.Forms.DataGridView DGV_FilterGroup;
        public System.Windows.Forms.DataGridView DGV_FilterSubgroup;
        public System.Windows.Forms.ToolStripButton tsbPrintFormat;
        public System.Windows.Forms.ToolStripButton tsbFormat;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbConcern;
    }
}