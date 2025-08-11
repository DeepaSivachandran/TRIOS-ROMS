namespace ROMS
{
    partial class CP_DirectLabelPrint
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CP_DirectLabelPrint));
            this.tsHeader = new System.Windows.Forms.ToolStrip();
            this.tspHeader = new System.Windows.Forms.ToolStripLabel();
            this.cmbLabelsize = new System.Windows.Forms.ComboBox();
            this.lblDLabelSize = new System.Windows.Forms.Label();
            this.lblRawCode = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grbGrid = new System.Windows.Forms.GroupBox();
            this.DGV_FilterProduct = new System.Windows.Forms.DataGridView();
            this.lvProduct = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lbdname = new System.Windows.Forms.Label();
            this.btnDirectPrint = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtrupee = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbTemplate = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSalesRate = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMrp = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbPrintLanguage = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.lblDProduct = new System.Windows.Forms.Label();
            this.picLoader4 = new System.Windows.Forms.PictureBox();
            this.lblNoRecordsFound = new System.Windows.Forms.Label();
            this.btnpreview = new System.Windows.Forms.Button();
            this.RPTViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.txtNoofcopy = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.errRack = new System.Windows.Forms.ErrorProvider(this.components);
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn3 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn4 = new System.Windows.Forms.DataGridViewImageColumn();
            this.lblProduct = new System.Windows.Forms.Label();
            this.tsHeader.SuspendLayout();
            this.grbGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_FilterProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errRack)).BeginInit();
            this.SuspendLayout();
            // 
            // tsHeader
            // 
            this.tsHeader.BackColor = System.Drawing.Color.Transparent;
            this.tsHeader.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsHeader.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsHeader.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsHeader.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspHeader});
            this.tsHeader.Location = new System.Drawing.Point(0, 0);
            this.tsHeader.Name = "tsHeader";
            this.tsHeader.Size = new System.Drawing.Size(1360, 25);
            this.tsHeader.TabIndex = 35;
            this.tsHeader.Text = "toolStrip1";
            // 
            // tspHeader
            // 
            this.tspHeader.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tspHeader.Image = global::ROMS.Properties.Resources.bread_crumb;
            this.tspHeader.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tspHeader.Margin = new System.Windows.Forms.Padding(15, 1, 0, 2);
            this.tspHeader.Name = "tspHeader";
            this.tspHeader.Size = new System.Drawing.Size(119, 22);
            this.tspHeader.Text = "Direct Label Print";
            // 
            // cmbLabelsize
            // 
            this.cmbLabelsize.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLabelsize.FormattingEnabled = true;
            this.cmbLabelsize.Location = new System.Drawing.Point(115, 294);
            this.cmbLabelsize.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.cmbLabelsize.Name = "cmbLabelsize";
            this.cmbLabelsize.Size = new System.Drawing.Size(122, 28);
            this.cmbLabelsize.TabIndex = 6;
            this.cmbLabelsize.SelectedIndexChanged += new System.EventHandler(this.cmbLabelsize_SelectedIndexChanged);
            this.cmbLabelsize.Enter += new System.EventHandler(this.cmbLabelsize_Enter);
            this.cmbLabelsize.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbLabelsize_KeyDown);
            this.cmbLabelsize.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbLabelsize_KeyPress);
            this.cmbLabelsize.Leave += new System.EventHandler(this.cmbLabelsize_Leave);
            // 
            // lblDLabelSize
            // 
            this.lblDLabelSize.AutoSize = true;
            this.lblDLabelSize.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDLabelSize.Location = new System.Drawing.Point(9, 298);
            this.lblDLabelSize.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDLabelSize.Name = "lblDLabelSize";
            this.lblDLabelSize.Size = new System.Drawing.Size(30, 20);
            this.lblDLabelSize.TabIndex = 958791;
            this.lblDLabelSize.Text = "Size";
            // 
            // lblRawCode
            // 
            this.lblRawCode.AutoSize = true;
            this.lblRawCode.Location = new System.Drawing.Point(628, 6);
            this.lblRawCode.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRawCode.Name = "lblRawCode";
            this.lblRawCode.Size = new System.Drawing.Size(16, 20);
            this.lblRawCode.TabIndex = 958798;
            this.lblRawCode.Text = "0";
            this.lblRawCode.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 820);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 20);
            this.label1.TabIndex = 958803;
            this.label1.Text = "Completed - Pending - Planned";
            // 
            // grbGrid
            // 
            this.grbGrid.Controls.Add(this.DGV_FilterProduct);
            this.grbGrid.Controls.Add(this.lvProduct);
            this.grbGrid.Controls.Add(this.lbdname);
            this.grbGrid.Controls.Add(this.btnDirectPrint);
            this.grbGrid.Controls.Add(this.btnPrint);
            this.grbGrid.Controls.Add(this.btnReset);
            this.grbGrid.Controls.Add(this.textBox1);
            this.grbGrid.Controls.Add(this.txtrupee);
            this.grbGrid.Controls.Add(this.label8);
            this.grbGrid.Controls.Add(this.cmbTemplate);
            this.grbGrid.Controls.Add(this.label7);
            this.grbGrid.Controls.Add(this.txtSalesRate);
            this.grbGrid.Controls.Add(this.label6);
            this.grbGrid.Controls.Add(this.txtMrp);
            this.grbGrid.Controls.Add(this.label4);
            this.grbGrid.Controls.Add(this.cmbPrintLanguage);
            this.grbGrid.Controls.Add(this.label3);
            this.grbGrid.Controls.Add(this.txtProductName);
            this.grbGrid.Controls.Add(this.lblDProduct);
            this.grbGrid.Controls.Add(this.picLoader4);
            this.grbGrid.Controls.Add(this.lblNoRecordsFound);
            this.grbGrid.Controls.Add(this.btnpreview);
            this.grbGrid.Controls.Add(this.RPTViewer);
            this.grbGrid.Controls.Add(this.txtNoofcopy);
            this.grbGrid.Controls.Add(this.label5);
            this.grbGrid.Controls.Add(this.cmbLabelsize);
            this.grbGrid.Controls.Add(this.lblDLabelSize);
            this.grbGrid.Location = new System.Drawing.Point(7, 27);
            this.grbGrid.Name = "grbGrid";
            this.grbGrid.Size = new System.Drawing.Size(1341, 629);
            this.grbGrid.TabIndex = 3;
            this.grbGrid.TabStop = false;
            // 
            // DGV_FilterProduct
            // 
            this.DGV_FilterProduct.AllowUserToAddRows = false;
            this.DGV_FilterProduct.AllowUserToDeleteRows = false;
            this.DGV_FilterProduct.AllowUserToResizeColumns = false;
            this.DGV_FilterProduct.AllowUserToResizeRows = false;
            this.DGV_FilterProduct.BackgroundColor = System.Drawing.Color.White;
            this.DGV_FilterProduct.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Chocolate;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Chocolate;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_FilterProduct.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DGV_FilterProduct.ColumnHeadersHeight = 30;
            this.DGV_FilterProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV_FilterProduct.DefaultCellStyle = dataGridViewCellStyle2;
            this.DGV_FilterProduct.EnableHeadersVisualStyles = false;
            this.DGV_FilterProduct.GridColor = System.Drawing.Color.White;
            this.DGV_FilterProduct.Location = new System.Drawing.Point(115, 78);
            this.DGV_FilterProduct.Name = "DGV_FilterProduct";
            this.DGV_FilterProduct.ReadOnly = true;
            this.DGV_FilterProduct.RowHeadersVisible = false;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.DGV_FilterProduct.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.DGV_FilterProduct.RowTemplate.Height = 25;
            this.DGV_FilterProduct.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV_FilterProduct.Size = new System.Drawing.Size(522, 244);
            this.DGV_FilterProduct.TabIndex = 111111145;
            this.DGV_FilterProduct.Visible = false;
            this.DGV_FilterProduct.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_FilterProduct_CellDoubleClick);
            this.DGV_FilterProduct.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DGV_FilterProduct_KeyDown);
            // 
            // lvProduct
            // 
            this.lvProduct.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9});
            this.lvProduct.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.lvProduct.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvProduct.HideSelection = false;
            this.lvProduct.Location = new System.Drawing.Point(420, 76);
            this.lvProduct.Name = "lvProduct";
            this.lvProduct.Size = new System.Drawing.Size(306, 194);
            this.lvProduct.TabIndex = 111111160;
            this.lvProduct.UseCompatibleStateImageBehavior = false;
            this.lvProduct.View = System.Windows.Forms.View.Details;
            this.lvProduct.Visible = false;
            this.lvProduct.DoubleClick += new System.EventHandler(this.lvProduct_DoubleClick);
            this.lvProduct.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvProduct_KeyDown);
            // 
            // columnHeader5
            // 
            this.columnHeader5.Width = 120;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Width = 0;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Width = 0;
            // 
            // lbdname
            // 
            this.lbdname.AutoSize = true;
            this.lbdname.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbdname.ForeColor = System.Drawing.Color.Green;
            this.lbdname.Location = new System.Drawing.Point(440, 46);
            this.lbdname.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbdname.Name = "lbdname";
            this.lbdname.Size = new System.Drawing.Size(0, 25);
            this.lbdname.TabIndex = 111111159;
            // 
            // btnDirectPrint
            // 
            this.btnDirectPrint.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDirectPrint.Enabled = false;
            this.btnDirectPrint.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDirectPrint.Image = global::ROMS.Properties.Resources.print;
            this.btnDirectPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDirectPrint.Location = new System.Drawing.Point(305, 449);
            this.btnDirectPrint.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btnDirectPrint.Name = "btnDirectPrint";
            this.btnDirectPrint.Size = new System.Drawing.Size(107, 33);
            this.btnDirectPrint.TabIndex = 111111158;
            this.btnDirectPrint.Text = "Direct Print";
            this.btnDirectPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDirectPrint.UseVisualStyleBackColor = true;
            this.btnDirectPrint.Click += new System.EventHandler(this.btnDirectPrint_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPrint.Enabled = false;
            this.btnPrint.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Image = global::ROMS.Properties.Resources.print_label;
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(193, 449);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(107, 33);
            this.btnPrint.TabIndex = 111111157;
            this.btnPrint.Text = "Test Print";
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Image = global::ROMS.Properties.Resources.refresh;
            this.btnReset.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReset.Location = new System.Drawing.Point(193, 394);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(107, 33);
            this.btnReset.TabIndex = 111111156;
            this.btnReset.Text = "Reset";
            this.btnReset.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold);
            this.textBox1.Location = new System.Drawing.Point(115, 196);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(21, 27);
            this.textBox1.TabIndex = 111111155;
            this.textBox1.Text = "₹";
            // 
            // txtrupee
            // 
            this.txtrupee.BackColor = System.Drawing.SystemColors.Control;
            this.txtrupee.Enabled = false;
            this.txtrupee.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold);
            this.txtrupee.Location = new System.Drawing.Point(115, 147);
            this.txtrupee.Name = "txtrupee";
            this.txtrupee.ReadOnly = true;
            this.txtrupee.Size = new System.Drawing.Size(21, 27);
            this.txtrupee.TabIndex = 111111154;
            this.txtrupee.Text = "₹";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(9, 348);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 20);
            this.label8.TabIndex = 111111153;
            this.label8.Text = "Template";
            // 
            // cmbTemplate
            // 
            this.cmbTemplate.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTemplate.FormattingEnabled = true;
            this.cmbTemplate.Location = new System.Drawing.Point(115, 344);
            this.cmbTemplate.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.cmbTemplate.Name = "cmbTemplate";
            this.cmbTemplate.Size = new System.Drawing.Size(122, 28);
            this.cmbTemplate.TabIndex = 7;
            this.cmbTemplate.Enter += new System.EventHandler(this.cmbTemplate_Enter);
            this.cmbTemplate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbTemplate_KeyDown);
            this.cmbTemplate.Leave += new System.EventHandler(this.cmbTemplate_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(9, 199);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 20);
            this.label7.TabIndex = 111111151;
            this.label7.Text = "Retail Sales Rate";
            // 
            // txtSalesRate
            // 
            this.txtSalesRate.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtSalesRate.Location = new System.Drawing.Point(137, 196);
            this.txtSalesRate.MaxLength = 5;
            this.txtSalesRate.Name = "txtSalesRate";
            this.txtSalesRate.Size = new System.Drawing.Size(100, 27);
            this.txtSalesRate.TabIndex = 4;
            this.txtSalesRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSalesRate.Enter += new System.EventHandler(this.txtSalesRate_Enter);
            this.txtSalesRate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSalesRate_KeyDown);
            this.txtSalesRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSalesRate_KeyPress);
            this.txtSalesRate.Leave += new System.EventHandler(this.txtSalesRate_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(9, 150);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 20);
            this.label6.TabIndex = 111111149;
            this.label6.Text = "MRP";
            // 
            // txtMrp
            // 
            this.txtMrp.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtMrp.Location = new System.Drawing.Point(137, 147);
            this.txtMrp.MaxLength = 5;
            this.txtMrp.Name = "txtMrp";
            this.txtMrp.Size = new System.Drawing.Size(100, 27);
            this.txtMrp.TabIndex = 3;
            this.txtMrp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMrp.TextChanged += new System.EventHandler(this.txtMrp_TextChanged);
            this.txtMrp.Enter += new System.EventHandler(this.txtMrp_Enter);
            this.txtMrp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMrp_KeyDown);
            this.txtMrp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMrp_KeyPress);
            this.txtMrp.Leave += new System.EventHandler(this.txtMrp_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 101);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 20);
            this.label4.TabIndex = 111111147;
            this.label4.Text = "Print Language";
            // 
            // cmbPrintLanguage
            // 
            this.cmbPrintLanguage.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPrintLanguage.FormattingEnabled = true;
            this.cmbPrintLanguage.Location = new System.Drawing.Point(115, 97);
            this.cmbPrintLanguage.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.cmbPrintLanguage.Name = "cmbPrintLanguage";
            this.cmbPrintLanguage.Size = new System.Drawing.Size(122, 28);
            this.cmbPrintLanguage.TabIndex = 2;
            this.cmbPrintLanguage.Enter += new System.EventHandler(this.cmbPrintLanguage_Enter);
            this.cmbPrintLanguage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbPrintLanguage_KeyDown);
            this.cmbPrintLanguage.Leave += new System.EventHandler(this.cmbPrintLanguage_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 51);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 20);
            this.label3.TabIndex = 1111204;
            this.label3.Text = "Product ";
            // 
            // txtProductName
            // 
            this.txtProductName.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtProductName.Location = new System.Drawing.Point(115, 48);
            this.txtProductName.MaxLength = 50;
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(297, 27);
            this.txtProductName.TabIndex = 1;
            this.txtProductName.TextChanged += new System.EventHandler(this.txtProductName_TextChanged);
            this.txtProductName.Enter += new System.EventHandler(this.txtProductName_Enter);
            this.txtProductName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtProductName_KeyDown);
            this.txtProductName.Leave += new System.EventHandler(this.txtProductName_Leave);
            // 
            // lblDProduct
            // 
            this.lblDProduct.AutoSize = true;
            this.lblDProduct.Font = new System.Drawing.Font("Oswald Regular", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDProduct.Location = new System.Drawing.Point(115, 30);
            this.lblDProduct.Name = "lblDProduct";
            this.lblDProduct.Size = new System.Drawing.Size(121, 17);
            this.lblDProduct.TabIndex = 1111203;
            this.lblDProduct.Text = "Search by P.I Code (F11)";
            // 
            // picLoader4
            // 
            this.picLoader4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picLoader4.ErrorImage = null;
            this.picLoader4.Image = global::ROMS.Properties.Resources.Iphone_spinner_2;
            this.picLoader4.InitialImage = null;
            this.picLoader4.Location = new System.Drawing.Point(440, 73);
            this.picLoader4.Name = "picLoader4";
            this.picLoader4.Size = new System.Drawing.Size(895, 550);
            this.picLoader4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picLoader4.TabIndex = 1111171;
            this.picLoader4.TabStop = false;
            this.picLoader4.Visible = false;
            // 
            // lblNoRecordsFound
            // 
            this.lblNoRecordsFound.AutoSize = true;
            this.lblNoRecordsFound.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoRecordsFound.Location = new System.Drawing.Point(834, 338);
            this.lblNoRecordsFound.Name = "lblNoRecordsFound";
            this.lblNoRecordsFound.Size = new System.Drawing.Size(106, 20);
            this.lblNoRecordsFound.TabIndex = 1111167;
            this.lblNoRecordsFound.Text = "No Records Found";
            // 
            // btnpreview
            // 
            this.btnpreview.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnpreview.Image = global::ROMS.Properties.Resources.view__1_;
            this.btnpreview.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnpreview.Location = new System.Drawing.Point(305, 394);
            this.btnpreview.Name = "btnpreview";
            this.btnpreview.Size = new System.Drawing.Size(107, 33);
            this.btnpreview.TabIndex = 8;
            this.btnpreview.Text = "Preview";
            this.btnpreview.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnpreview.UseVisualStyleBackColor = true;
            this.btnpreview.Click += new System.EventHandler(this.btnpreview_Click);
            this.btnpreview.Enter += new System.EventHandler(this.btnpreview_Enter);
            this.btnpreview.Leave += new System.EventHandler(this.btnpreview_Leave);
            // 
            // RPTViewer
            // 
            this.RPTViewer.ActiveViewIndex = -1;
            this.RPTViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RPTViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.RPTViewer.DisplayStatusBar = false;
            this.RPTViewer.EnableDrillDown = false;
            this.RPTViewer.Location = new System.Drawing.Point(440, 73);
            this.RPTViewer.Name = "RPTViewer";
            this.RPTViewer.ShowCloseButton = false;
            this.RPTViewer.ShowCopyButton = false;
            this.RPTViewer.ShowGotoPageButton = false;
            this.RPTViewer.ShowGroupTreeButton = false;
            this.RPTViewer.ShowLogo = false;
            this.RPTViewer.ShowParameterPanelButton = false;
            this.RPTViewer.ShowRefreshButton = false;
            this.RPTViewer.ShowTextSearchButton = false;
            this.RPTViewer.Size = new System.Drawing.Size(895, 550);
            this.RPTViewer.TabIndex = 958809;
            this.RPTViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // txtNoofcopy
            // 
            this.txtNoofcopy.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtNoofcopy.Location = new System.Drawing.Point(115, 245);
            this.txtNoofcopy.MaxLength = 5;
            this.txtNoofcopy.Name = "txtNoofcopy";
            this.txtNoofcopy.Size = new System.Drawing.Size(122, 27);
            this.txtNoofcopy.TabIndex = 5;
            this.txtNoofcopy.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNoofcopy.Enter += new System.EventHandler(this.txtNoofcopy_Enter);
            this.txtNoofcopy.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNoofcopy_KeyDown);
            this.txtNoofcopy.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNoofcopy_KeyPress);
            this.txtNoofcopy.Leave += new System.EventHandler(this.txtNoofcopy_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(9, 248);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 20);
            this.label5.TabIndex = 958792;
            this.label5.Text = "No.of Copies";
            // 
            // errRack
            // 
            this.errRack.ContainerControl = this;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "Product Label";
            this.dataGridViewImageColumn1.Image = global::ROMS.Properties.Resources.print_label;
            this.dataGridViewImageColumn1.MinimumWidth = 6;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewImageColumn1.Width = 150;
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.HeaderText = "Intermediate Label";
            this.dataGridViewImageColumn2.Image = global::ROMS.Properties.Resources.print_label;
            this.dataGridViewImageColumn2.MinimumWidth = 6;
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewImageColumn2.Width = 150;
            // 
            // dataGridViewImageColumn3
            // 
            this.dataGridViewImageColumn3.HeaderText = "Outer Label";
            this.dataGridViewImageColumn3.Image = global::ROMS.Properties.Resources.print_label;
            this.dataGridViewImageColumn3.MinimumWidth = 6;
            this.dataGridViewImageColumn3.Name = "dataGridViewImageColumn3";
            this.dataGridViewImageColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewImageColumn3.Width = 150;
            // 
            // dataGridViewImageColumn4
            // 
            this.dataGridViewImageColumn4.HeaderText = "Token";
            this.dataGridViewImageColumn4.Image = global::ROMS.Properties.Resources.print_label;
            this.dataGridViewImageColumn4.MinimumWidth = 6;
            this.dataGridViewImageColumn4.Name = "dataGridViewImageColumn4";
            this.dataGridViewImageColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewImageColumn4.Width = 150;
            // 
            // lblProduct
            // 
            this.lblProduct.AutoSize = true;
            this.lblProduct.Location = new System.Drawing.Point(703, 9);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(16, 20);
            this.lblProduct.TabIndex = 111111161;
            this.lblProduct.Text = "0";
            this.lblProduct.Visible = false;
            // 
            // CP_DirectLabelPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1360, 665);
            this.Controls.Add(this.lblProduct);
            this.Controls.Add(this.grbGrid);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblRawCode);
            this.Controls.Add(this.tsHeader);
            this.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.Name = "CP_DirectLabelPrint";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sticker Print";
            this.Load += new System.EventHandler(this.CP_DiectLabelPrint_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PROD_LabelPrinting_KeyDown);
            this.tsHeader.ResumeLayout(false);
            this.tsHeader.PerformLayout();
            this.grbGrid.ResumeLayout(false);
            this.grbGrid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_FilterProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errRack)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.ToolStripLabel tspHeader;
        public System.Windows.Forms.ToolStrip tsHeader;
        public System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        public System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        public System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn3;
        public System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn4;
        public System.Windows.Forms.ComboBox cmbLabelsize;
        public System.Windows.Forms.Label lblDLabelSize;
        private System.Windows.Forms.Label lblRawCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grbGrid;
        public System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNoofcopy;
        public CrystalDecisions.Windows.Forms.CrystalReportViewer RPTViewer;
        public System.Windows.Forms.Button btnpreview;
        private System.Windows.Forms.Label lblNoRecordsFound;
        private System.Windows.Forms.ErrorProvider errRack;
        public System.Windows.Forms.PictureBox picLoader4;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Label lblDProduct;
        public System.Windows.Forms.DataGridView DGV_FilterProduct;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.ComboBox cmbPrintLanguage;
        public System.Windows.Forms.TextBox txtMrp;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.Label label8;
        public System.Windows.Forms.ComboBox cmbTemplate;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox txtSalesRate;
        private System.Windows.Forms.TextBox txtrupee;
        private System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.Button btnReset;
        public System.Windows.Forms.Button btnPrint;
        public System.Windows.Forms.Button btnDirectPrint;
        public System.Windows.Forms.Label lbdname;
        public System.Windows.Forms.ListView lvProduct;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.Label lblProduct;
    }
}