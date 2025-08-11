namespace ROMS
{
    partial class CP_Printer_Setting
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CP_Printer_Setting));
            this.err_PrinterSetting = new System.Windows.Forms.ErrorProvider(this.components);
            this.TLP_Main_Bg = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.grdLabelPrinting = new System.Windows.Forms.DataGridView();
            this.clmsno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IpAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPaperSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Printer_TypeCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmprintertype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPrinterName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SettingCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPaperSizecode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmprint = new System.Windows.Forms.DataGridViewImageColumn();
            this.clmRemove = new System.Windows.Forms.DataGridViewImageColumn();
            this.picLoader = new System.Windows.Forms.PictureBox();
            this.lbl_Size = new System.Windows.Forms.Label();
            this.Btn_Add = new System.Windows.Forms.Button();
            this.Cmb_PaperSize = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Btn_Close = new System.Windows.Forms.Button();
            this.Btn_Save = new System.Windows.Forms.Button();
            this.tsHeader = new System.Windows.Forms.ToolStrip();
            this.tspHeader = new System.Windows.Forms.ToolStripLabel();
            this.lbl_PrinterType = new System.Windows.Forms.Label();
            this.lbl_Printer_Name = new System.Windows.Forms.Label();
            this.Cmb_Printer_Name = new System.Windows.Forms.ComboBox();
            this.Cmb_Printer_Type = new System.Windows.Forms.ComboBox();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            ((System.ComponentModel.ISupportInitialize)(this.err_PrinterSetting)).BeginInit();
            this.TLP_Main_Bg.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdLabelPrinting)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tsHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // err_PrinterSetting
            // 
            this.err_PrinterSetting.ContainerControl = this;
            // 
            // TLP_Main_Bg
            // 
            this.TLP_Main_Bg.BackColor = System.Drawing.SystemColors.Window;
            this.TLP_Main_Bg.ColumnCount = 6;
            this.TLP_Main_Bg.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2F));
            this.TLP_Main_Bg.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.TLP_Main_Bg.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44F));
            this.TLP_Main_Bg.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TLP_Main_Bg.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.TLP_Main_Bg.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2F));
            this.TLP_Main_Bg.Controls.Add(this.panel1, 1, 3);
            this.TLP_Main_Bg.Controls.Add(this.lbl_Size, 1, 1);
            this.TLP_Main_Bg.Controls.Add(this.Btn_Add, 4, 2);
            this.TLP_Main_Bg.Controls.Add(this.Cmb_PaperSize, 1, 2);
            this.TLP_Main_Bg.Controls.Add(this.tableLayoutPanel1, 3, 4);
            this.TLP_Main_Bg.Controls.Add(this.tsHeader, 0, 0);
            this.TLP_Main_Bg.Controls.Add(this.lbl_PrinterType, 1, 4);
            this.TLP_Main_Bg.Controls.Add(this.lbl_Printer_Name, 2, 1);
            this.TLP_Main_Bg.Controls.Add(this.Cmb_Printer_Name, 2, 2);
            this.TLP_Main_Bg.Controls.Add(this.Cmb_Printer_Type, 2, 4);
            this.TLP_Main_Bg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLP_Main_Bg.Location = new System.Drawing.Point(0, 0);
            this.TLP_Main_Bg.Margin = new System.Windows.Forms.Padding(4);
            this.TLP_Main_Bg.Name = "TLP_Main_Bg";
            this.TLP_Main_Bg.RowCount = 6;
            this.TLP_Main_Bg.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.20408F));
            this.TLP_Main_Bg.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.122449F));
            this.TLP_Main_Bg.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.20408F));
            this.TLP_Main_Bg.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 61.22449F));
            this.TLP_Main_Bg.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.20408F));
            this.TLP_Main_Bg.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2.040816F));
            this.TLP_Main_Bg.Size = new System.Drawing.Size(904, 445);
            this.TLP_Main_Bg.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TLP_Main_Bg.SetColumnSpan(this.panel1, 4);
            this.panel1.Controls.Add(this.grdLabelPrinting);
            this.panel1.Controls.Add(this.picLoader);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(22, 121);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(858, 264);
            this.panel1.TabIndex = 0;
            // 
            // grdLabelPrinting
            // 
            this.grdLabelPrinting.AllowUserToAddRows = false;
            this.grdLabelPrinting.AllowUserToDeleteRows = false;
            this.grdLabelPrinting.AllowUserToResizeRows = false;
            this.grdLabelPrinting.BackgroundColor = System.Drawing.Color.White;
            this.grdLabelPrinting.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdLabelPrinting.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdLabelPrinting.ColumnHeadersHeight = 30;
            this.grdLabelPrinting.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdLabelPrinting.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmsno,
            this.UserName,
            this.IpAddress,
            this.clmPaperSize,
            this.Printer_TypeCode,
            this.clmprintertype,
            this.clmPrinterName,
            this.SettingCode,
            this.clmPaperSizecode,
            this.clmprint,
            this.clmRemove});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdLabelPrinting.DefaultCellStyle = dataGridViewCellStyle3;
            this.grdLabelPrinting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdLabelPrinting.EnableHeadersVisualStyles = false;
            this.grdLabelPrinting.GridColor = System.Drawing.Color.White;
            this.grdLabelPrinting.Location = new System.Drawing.Point(0, 0);
            this.grdLabelPrinting.Margin = new System.Windows.Forms.Padding(4);
            this.grdLabelPrinting.Name = "grdLabelPrinting";
            this.grdLabelPrinting.ReadOnly = true;
            this.grdLabelPrinting.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdLabelPrinting.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.grdLabelPrinting.RowHeadersVisible = false;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            this.grdLabelPrinting.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.grdLabelPrinting.RowTemplate.Height = 25;
            this.grdLabelPrinting.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdLabelPrinting.Size = new System.Drawing.Size(856, 262);
            this.grdLabelPrinting.TabIndex = 0;
            this.grdLabelPrinting.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdLabelPrinting_CellContentClick);
            // 
            // clmsno
            // 
            this.clmsno.HeaderText = "SI.No.";
            this.clmsno.Name = "clmsno";
            this.clmsno.ReadOnly = true;
            this.clmsno.Width = 80;
            // 
            // UserName
            // 
            this.UserName.HeaderText = "User Name";
            this.UserName.Name = "UserName";
            this.UserName.ReadOnly = true;
            this.UserName.Visible = false;
            // 
            // IpAddress
            // 
            this.IpAddress.HeaderText = "IPAddress";
            this.IpAddress.Name = "IpAddress";
            this.IpAddress.ReadOnly = true;
            this.IpAddress.Visible = false;
            // 
            // clmPaperSize
            // 
            this.clmPaperSize.HeaderText = "Paper Size";
            this.clmPaperSize.Name = "clmPaperSize";
            this.clmPaperSize.ReadOnly = true;
            this.clmPaperSize.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmPaperSize.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmPaperSize.Width = 170;
            // 
            // Printer_TypeCode
            // 
            this.Printer_TypeCode.HeaderText = "Printer Type Code";
            this.Printer_TypeCode.Name = "Printer_TypeCode";
            this.Printer_TypeCode.ReadOnly = true;
            this.Printer_TypeCode.Visible = false;
            // 
            // clmprintertype
            // 
            this.clmprintertype.HeaderText = "Printer Type";
            this.clmprintertype.Name = "clmprintertype";
            this.clmprintertype.ReadOnly = true;
            this.clmprintertype.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmprintertype.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmprintertype.Visible = false;
            this.clmprintertype.Width = 150;
            // 
            // clmPrinterName
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            this.clmPrinterName.DefaultCellStyle = dataGridViewCellStyle2;
            this.clmPrinterName.HeaderText = "Printer Name";
            this.clmPrinterName.Name = "clmPrinterName";
            this.clmPrinterName.ReadOnly = true;
            this.clmPrinterName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmPrinterName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmPrinterName.Width = 350;
            // 
            // SettingCode
            // 
            this.SettingCode.HeaderText = "Setting Code";
            this.SettingCode.Name = "SettingCode";
            this.SettingCode.ReadOnly = true;
            this.SettingCode.Visible = false;
            // 
            // clmPaperSizecode
            // 
            this.clmPaperSizecode.HeaderText = "PaperSizeCode";
            this.clmPaperSizecode.Name = "clmPaperSizecode";
            this.clmPaperSizecode.ReadOnly = true;
            this.clmPaperSizecode.Visible = false;
            // 
            // clmprint
            // 
            this.clmprint.HeaderText = "Print";
            this.clmprint.Image = global::ROMS.Properties.Resources.print;
            this.clmprint.Name = "clmprint";
            this.clmprint.ReadOnly = true;
            // 
            // clmRemove
            // 
            this.clmRemove.HeaderText = "Remove";
            this.clmRemove.Image = global::ROMS.Properties.Resources.remove;
            this.clmRemove.Name = "clmRemove";
            this.clmRemove.ReadOnly = true;
            // 
            // picLoader
            // 
            this.picLoader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picLoader.ErrorImage = null;
            this.picLoader.Image = global::ROMS.Properties.Resources.loader;
            this.picLoader.InitialImage = null;
            this.picLoader.Location = new System.Drawing.Point(-234, -144);
            this.picLoader.Name = "picLoader";
            this.picLoader.Size = new System.Drawing.Size(1325, 550);
            this.picLoader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picLoader.TabIndex = 958788;
            this.picLoader.TabStop = false;
            this.picLoader.Visible = false;
            // 
            // lbl_Size
            // 
            this.lbl_Size.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Size.AutoSize = true;
            this.lbl_Size.Location = new System.Drawing.Point(22, 48);
            this.lbl_Size.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Size.Name = "lbl_Size";
            this.lbl_Size.Size = new System.Drawing.Size(172, 20);
            this.lbl_Size.TabIndex = 2;
            this.lbl_Size.Text = "Paper Size";
            this.lbl_Size.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Btn_Add
            // 
            this.Btn_Add.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Btn_Add.Image = global::ROMS.Properties.Resources.New;
            this.Btn_Add.Location = new System.Drawing.Point(838, 81);
            this.Btn_Add.Name = "Btn_Add";
            this.Btn_Add.Size = new System.Drawing.Size(28, 27);
            this.Btn_Add.TabIndex = 3;
            this.Btn_Add.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Btn_Add.UseVisualStyleBackColor = true;
            this.Btn_Add.Click += new System.EventHandler(this.Btn_Add_Click);
            // 
            // Cmb_PaperSize
            // 
            this.Cmb_PaperSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Cmb_PaperSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cmb_PaperSize.FormattingEnabled = true;
            this.Cmb_PaperSize.Location = new System.Drawing.Point(21, 84);
            this.Cmb_PaperSize.Name = "Cmb_PaperSize";
            this.Cmb_PaperSize.Size = new System.Drawing.Size(174, 28);
            this.Cmb_PaperSize.TabIndex = 0;
            this.Cmb_PaperSize.SelectedIndexChanged += new System.EventHandler(this.Cmb_PaperSize_SelectedIndexChanged);
            this.Cmb_PaperSize.Enter += new System.EventHandler(this.Cmb_PaperSize_Enter);
            this.Cmb_PaperSize.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Cmb_PaperSize_KeyDown);
            this.Cmb_PaperSize.Leave += new System.EventHandler(this.Cmb_PaperSize_Leave);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.TLP_Main_Bg.SetColumnSpan(this.tableLayoutPanel1, 2);
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.Controls.Add(this.Btn_Close, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.Btn_Save, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(598, 392);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(283, 39);
            this.tableLayoutPanel1.TabIndex = 15;
            // 
            // Btn_Close
            // 
            this.Btn_Close.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Btn_Close.Image = global::ROMS.Properties.Resources.close;
            this.Btn_Close.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_Close.Location = new System.Drawing.Point(200, 4);
            this.Btn_Close.Name = "Btn_Close";
            this.Btn_Close.Size = new System.Drawing.Size(80, 30);
            this.Btn_Close.TabIndex = 1;
            this.Btn_Close.Text = "Close";
            this.Btn_Close.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Btn_Close.UseVisualStyleBackColor = true;
            this.Btn_Close.Click += new System.EventHandler(this.Btn_Close_Click);
            this.Btn_Close.Enter += new System.EventHandler(this.Btn_Close_Enter);
            this.Btn_Close.Leave += new System.EventHandler(this.Btn_Close_Leave);
            // 
            // Btn_Save
            // 
            this.Btn_Save.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Btn_Save.Image = global::ROMS.Properties.Resources.save;
            this.Btn_Save.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_Save.Location = new System.Drawing.Point(116, 4);
            this.Btn_Save.Name = "Btn_Save";
            this.Btn_Save.Size = new System.Drawing.Size(78, 30);
            this.Btn_Save.TabIndex = 0;
            this.Btn_Save.Text = "Save";
            this.Btn_Save.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Btn_Save.UseVisualStyleBackColor = true;
            this.Btn_Save.Click += new System.EventHandler(this.Btn_Save_Click);
            this.Btn_Save.Enter += new System.EventHandler(this.Btn_Save_Enter);
            this.Btn_Save.Leave += new System.EventHandler(this.Btn_Save_Leave);
            // 
            // tsHeader
            // 
            this.TLP_Main_Bg.SetColumnSpan(this.tsHeader, 6);
            this.tsHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tsHeader.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspHeader});
            this.tsHeader.Location = new System.Drawing.Point(0, 0);
            this.tsHeader.Name = "tsHeader";
            this.tsHeader.Size = new System.Drawing.Size(904, 45);
            this.tsHeader.TabIndex = 1;
            this.tsHeader.Text = "Printer Setting";
            // 
            // tspHeader
            // 
            this.tspHeader.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tspHeader.Image = global::ROMS.Properties.Resources.bread_crumb;
            this.tspHeader.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tspHeader.Margin = new System.Windows.Forms.Padding(15, 1, 0, 2);
            this.tspHeader.Name = "tspHeader";
            this.tspHeader.Size = new System.Drawing.Size(106, 42);
            this.tspHeader.Text = "Printer Setting";
            // 
            // lbl_PrinterType
            // 
            this.lbl_PrinterType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_PrinterType.AutoSize = true;
            this.lbl_PrinterType.Location = new System.Drawing.Point(22, 401);
            this.lbl_PrinterType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_PrinterType.Name = "lbl_PrinterType";
            this.lbl_PrinterType.Size = new System.Drawing.Size(172, 20);
            this.lbl_PrinterType.TabIndex = 2;
            this.lbl_PrinterType.Text = "Printer Type";
            this.lbl_PrinterType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_PrinterType.Visible = false;
            // 
            // lbl_Printer_Name
            // 
            this.lbl_Printer_Name.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Printer_Name.AutoSize = true;
            this.lbl_Printer_Name.Location = new System.Drawing.Point(202, 48);
            this.lbl_Printer_Name.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Printer_Name.Name = "lbl_Printer_Name";
            this.lbl_Printer_Name.Size = new System.Drawing.Size(389, 20);
            this.lbl_Printer_Name.TabIndex = 2;
            this.lbl_Printer_Name.Text = "Printer Name ";
            this.lbl_Printer_Name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Cmb_Printer_Name
            // 
            this.Cmb_Printer_Name.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Cmb_Printer_Name.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cmb_Printer_Name.FormattingEnabled = true;
            this.Cmb_Printer_Name.Location = new System.Drawing.Point(201, 84);
            this.Cmb_Printer_Name.Name = "Cmb_Printer_Name";
            this.Cmb_Printer_Name.Size = new System.Drawing.Size(391, 28);
            this.Cmb_Printer_Name.TabIndex = 2;
            this.Cmb_Printer_Name.SelectedIndexChanged += new System.EventHandler(this.Cmb_Printer_Name_SelectedIndexChanged);
            this.Cmb_Printer_Name.Enter += new System.EventHandler(this.Cmb_Printer_Name_Enter);
            this.Cmb_Printer_Name.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Cmb_Printer_Name_KeyDown);
            this.Cmb_Printer_Name.Leave += new System.EventHandler(this.Cmb_Printer_Name_Leave);
            // 
            // Cmb_Printer_Type
            // 
            this.Cmb_Printer_Type.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Cmb_Printer_Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cmb_Printer_Type.FormattingEnabled = true;
            this.Cmb_Printer_Type.Location = new System.Drawing.Point(201, 401);
            this.Cmb_Printer_Type.Name = "Cmb_Printer_Type";
            this.Cmb_Printer_Type.Size = new System.Drawing.Size(391, 28);
            this.Cmb_Printer_Type.TabIndex = 1;
            this.Cmb_Printer_Type.Visible = false;
            this.Cmb_Printer_Type.SelectedIndexChanged += new System.EventHandler(this.Cmb_Printer_Type_SelectedIndexChanged);
            this.Cmb_Printer_Type.Enter += new System.EventHandler(this.Cmb_Printer_Type_Enter);
            this.Cmb_Printer_Type.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Cmb_Printer_Type_KeyDown);
            this.Cmb_Printer_Type.Leave += new System.EventHandler(this.Cmb_Printer_Type_Leave);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Document = this.printDocument1;
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // CP_Printer_Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(904, 445);
            this.Controls.Add(this.TLP_Main_Bg);
            this.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "CP_Printer_Setting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CP_Printer_Setting";
            this.Load += new System.EventHandler(this.CP_Printer_Setting_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CP_Printer_Setting_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.err_PrinterSetting)).EndInit();
            this.TLP_Main_Bg.ResumeLayout(false);
            this.TLP_Main_Bg.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdLabelPrinting)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tsHeader.ResumeLayout(false);
            this.tsHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ErrorProvider err_PrinterSetting;
        private System.Windows.Forms.TableLayoutPanel TLP_Main_Bg;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.DataGridView grdLabelPrinting;
        private System.Windows.Forms.Label lbl_Size;
        private System.Windows.Forms.Button Btn_Add;
        private System.Windows.Forms.ComboBox Cmb_Printer_Name;
        private System.Windows.Forms.ComboBox Cmb_Printer_Type;
        private System.Windows.Forms.ComboBox Cmb_PaperSize;
        private System.Windows.Forms.Label lbl_PrinterType;
        private System.Windows.Forms.Label lbl_Printer_Name;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button Btn_Close;
        private System.Windows.Forms.Button Btn_Save;
        private System.Windows.Forms.ToolStrip tsHeader;
        private System.Windows.Forms.ToolStripLabel tspHeader;
        private System.Windows.Forms.PictureBox picLoader;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmsno;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn IpAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPaperSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn Printer_TypeCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmprintertype;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPrinterName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SettingCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPaperSizecode;
        private System.Windows.Forms.DataGridViewImageColumn clmprint;
        private System.Windows.Forms.DataGridViewImageColumn clmRemove;
    }
}