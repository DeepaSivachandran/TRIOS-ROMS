namespace ROMS
{
    partial class INV_InwardPurchase
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tsInwardList = new System.Windows.Forms.ToolStrip();
            this.tspHeader = new System.Windows.Forms.ToolStripLabel();
            this.pnlinward = new System.Windows.Forms.Panel();
            this.btnRemarks = new System.Windows.Forms.Button();
            this.grdGrnlist = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmexpirydate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmBatchno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.txtInwardNo = new System.Windows.Forms.TextBox();
            this.txtDUnloading = new System.Windows.Forms.TextBox();
            this.textBox26 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.cmbGodown = new System.Windows.Forms.ComboBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.txtDCourier = new System.Windows.Forms.TextBox();
            this.textBox19 = new System.Windows.Forms.TextBox();
            this.textBox35 = new System.Windows.Forms.TextBox();
            this.textBox37 = new System.Windows.Forms.TextBox();
            this.textBox38 = new System.Windows.Forms.TextBox();
            this.textBox43 = new System.Windows.Forms.TextBox();
            this.btnsaveasdraft = new System.Windows.Forms.Button();
            this.txttotalitem = new System.Windows.Forms.TextBox();
            this.lbltotalproducts = new System.Windows.Forms.Label();
            this.grbSupplierDetails = new System.Windows.Forms.GroupBox();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.lblnarration = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblEdit = new System.Windows.Forms.Label();
            this.tsInwardList.SuspendLayout();
            this.pnlinward.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdGrnlist)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsInwardList
            // 
            this.tsInwardList.BackColor = System.Drawing.Color.White;
            this.tsInwardList.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsInwardList.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsInwardList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspHeader});
            this.tsInwardList.Location = new System.Drawing.Point(0, 0);
            this.tsInwardList.Name = "tsInwardList";
            this.tsInwardList.Size = new System.Drawing.Size(1354, 25);
            this.tsInwardList.TabIndex = 35;
            this.tsInwardList.Text = "Inward";
            // 
            // tspHeader
            // 
            this.tspHeader.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tspHeader.Image = global::ROMS.Properties.Resources.bread_crumb;
            this.tspHeader.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tspHeader.Margin = new System.Windows.Forms.Padding(15, 1, 0, 2);
            this.tspHeader.Name = "tspHeader";
            this.tspHeader.Size = new System.Drawing.Size(182, 22);
            this.tspHeader.Text = "Goods Inward From Purchase";
            // 
            // pnlinward
            // 
            this.pnlinward.BackColor = System.Drawing.Color.White;
            this.pnlinward.Controls.Add(this.btnRemarks);
            this.pnlinward.Controls.Add(this.grdGrnlist);
            this.pnlinward.Controls.Add(this.groupBox1);
            this.pnlinward.Controls.Add(this.btnsaveasdraft);
            this.pnlinward.Controls.Add(this.txttotalitem);
            this.pnlinward.Controls.Add(this.lbltotalproducts);
            this.pnlinward.Controls.Add(this.grbSupplierDetails);
            this.pnlinward.Controls.Add(this.txtRemark);
            this.pnlinward.Controls.Add(this.lblnarration);
            this.pnlinward.Controls.Add(this.btnSave);
            this.pnlinward.Controls.Add(this.btnClose);
            this.pnlinward.Location = new System.Drawing.Point(0, 29);
            this.pnlinward.Name = "pnlinward";
            this.pnlinward.Size = new System.Drawing.Size(1354, 645);
            this.pnlinward.TabIndex = 36;
            // 
            // btnRemarks
            // 
            this.btnRemarks.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnRemarks.Image = global::ROMS.Properties.Resources.comment;
            this.btnRemarks.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRemarks.Location = new System.Drawing.Point(502, 580);
            this.btnRemarks.Name = "btnRemarks";
            this.btnRemarks.Size = new System.Drawing.Size(111, 29);
            this.btnRemarks.TabIndex = 1111209;
            this.btnRemarks.Text = "See Remarks";
            this.btnRemarks.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRemarks.UseVisualStyleBackColor = true;
            this.btnRemarks.Click += new System.EventHandler(this.BtnRemarks_Click);
            // 
            // grdGrnlist
            // 
            this.grdGrnlist.AllowUserToAddRows = false;
            this.grdGrnlist.AllowUserToDeleteRows = false;
            this.grdGrnlist.AllowUserToResizeColumns = false;
            this.grdGrnlist.AllowUserToResizeRows = false;
            this.grdGrnlist.BackgroundColor = System.Drawing.Color.White;
            this.grdGrnlist.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(242)))), ((int)(((byte)(213)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdGrnlist.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdGrnlist.ColumnHeadersHeight = 30;
            this.grdGrnlist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdGrnlist.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column4,
            this.Column5,
            this.Column3,
            this.clmexpirydate,
            this.clmBatchno,
            this.Column8,
            this.Column7,
            this.Column6});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdGrnlist.DefaultCellStyle = dataGridViewCellStyle2;
            this.grdGrnlist.EnableHeadersVisualStyles = false;
            this.grdGrnlist.GridColor = System.Drawing.Color.White;
            this.grdGrnlist.Location = new System.Drawing.Point(3, 122);
            this.grdGrnlist.Name = "grdGrnlist";
            this.grdGrnlist.ReadOnly = true;
            this.grdGrnlist.RowHeadersVisible = false;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.grdGrnlist.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.grdGrnlist.RowTemplate.Height = 25;
            this.grdGrnlist.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdGrnlist.Size = new System.Drawing.Size(1338, 449);
            this.grdGrnlist.TabIndex = 958827;
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
            this.Column2.HeaderText = "P.I Code";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 120;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Product Name In English";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 200;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Product Name In Tamil";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 200;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "MRP";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // clmexpirydate
            // 
            this.clmexpirydate.HeaderText = "Expiry Date";
            this.clmexpirydate.Name = "clmexpirydate";
            this.clmexpirydate.ReadOnly = true;
            // 
            // clmBatchno
            // 
            this.clmBatchno.HeaderText = "Batch No.";
            this.clmBatchno.Name = "clmBatchno";
            this.clmBatchno.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Invoice Qty";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 80;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Received Qty";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Unit";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 80;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox9);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.textBox5);
            this.groupBox1.Controls.Add(this.textBox6);
            this.groupBox1.Controls.Add(this.txtInwardNo);
            this.groupBox1.Controls.Add(this.txtDUnloading);
            this.groupBox1.Controls.Add(this.textBox26);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.textBox4);
            this.groupBox1.Controls.Add(this.cmbGodown);
            this.groupBox1.Controls.Add(this.textBox7);
            this.groupBox1.Controls.Add(this.textBox8);
            this.groupBox1.Controls.Add(this.txtDCourier);
            this.groupBox1.Controls.Add(this.textBox19);
            this.groupBox1.Controls.Add(this.textBox35);
            this.groupBox1.Controls.Add(this.textBox37);
            this.groupBox1.Controls.Add(this.textBox38);
            this.groupBox1.Controls.Add(this.textBox43);
            this.groupBox1.Font = new System.Drawing.Font("Oswald Regular", 9.75F);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1039, 109);
            this.groupBox1.TabIndex = 958826;
            this.groupBox1.TabStop = false;
            // 
            // textBox9
            // 
            this.textBox9.BackColor = System.Drawing.SystemColors.Control;
            this.textBox9.Enabled = false;
            this.textBox9.Font = new System.Drawing.Font("Oswald Regular", 9.75F);
            this.textBox9.Location = new System.Drawing.Point(815, 21);
            this.textBox9.Name = "textBox9";
            this.textBox9.ReadOnly = true;
            this.textBox9.Size = new System.Drawing.Size(77, 25);
            this.textBox9.TabIndex = 1111216;
            this.textBox9.Text = "Inward Date";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker1.Enabled = false;
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(892, 21);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(141, 25);
            this.dateTimePicker1.TabIndex = 958822;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.Control;
            this.textBox2.Enabled = false;
            this.textBox2.Font = new System.Drawing.Font("Oswald Regular", 9.75F);
            this.textBox2.Location = new System.Drawing.Point(815, 46);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(77, 25);
            this.textBox2.TabIndex = 1111215;
            this.textBox2.Text = "Inward No.";
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.SystemColors.Control;
            this.textBox5.Enabled = false;
            this.textBox5.Font = new System.Drawing.Font("Oswald Regular", 9.75F);
            this.textBox5.Location = new System.Drawing.Point(206, 46);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(77, 25);
            this.textBox5.TabIndex = 1111214;
            this.textBox5.Text = "GRN No.";
            // 
            // textBox6
            // 
            this.textBox6.Enabled = false;
            this.textBox6.Font = new System.Drawing.Font("Oswald Regular", 9.75F);
            this.textBox6.Location = new System.Drawing.Point(283, 46);
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(123, 25);
            this.textBox6.TabIndex = 1111213;
            // 
            // txtInwardNo
            // 
            this.txtInwardNo.Enabled = false;
            this.txtInwardNo.Location = new System.Drawing.Point(892, 46);
            this.txtInwardNo.Name = "txtInwardNo";
            this.txtInwardNo.ReadOnly = true;
            this.txtInwardNo.Size = new System.Drawing.Size(141, 25);
            this.txtInwardNo.TabIndex = 958825;
            // 
            // txtDUnloading
            // 
            this.txtDUnloading.BackColor = System.Drawing.SystemColors.Control;
            this.txtDUnloading.Enabled = false;
            this.txtDUnloading.Font = new System.Drawing.Font("Oswald Regular", 9.75F);
            this.txtDUnloading.Location = new System.Drawing.Point(206, 21);
            this.txtDUnloading.Name = "txtDUnloading";
            this.txtDUnloading.ReadOnly = true;
            this.txtDUnloading.Size = new System.Drawing.Size(77, 25);
            this.txtDUnloading.TabIndex = 1111212;
            this.txtDUnloading.Text = "GRN Date";
            // 
            // textBox26
            // 
            this.textBox26.Enabled = false;
            this.textBox26.Font = new System.Drawing.Font("Oswald Regular", 9.75F);
            this.textBox26.Location = new System.Drawing.Point(283, 21);
            this.textBox26.Name = "textBox26";
            this.textBox26.ReadOnly = true;
            this.textBox26.Size = new System.Drawing.Size(123, 25);
            this.textBox26.TabIndex = 1111211;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Oswald Regular", 9.75F);
            this.textBox1.Location = new System.Drawing.Point(3, 46);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(77, 25);
            this.textBox1.TabIndex = 1111210;
            this.textBox1.Text = "Stock Location";
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.SystemColors.Control;
            this.textBox3.Enabled = false;
            this.textBox3.Font = new System.Drawing.Font("Oswald Regular", 9.75F);
            this.textBox3.Location = new System.Drawing.Point(3, 21);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(77, 25);
            this.textBox3.TabIndex = 1111153;
            this.textBox3.Text = "Concern";
            // 
            // textBox4
            // 
            this.textBox4.Enabled = false;
            this.textBox4.Font = new System.Drawing.Font("Oswald Regular", 9.75F);
            this.textBox4.Location = new System.Drawing.Point(80, 21);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(123, 25);
            this.textBox4.TabIndex = 1111152;
            // 
            // cmbGodown
            // 
            this.cmbGodown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGodown.Enabled = false;
            this.cmbGodown.Font = new System.Drawing.Font("Oswald Regular", 9.75F);
            this.cmbGodown.FormattingEnabled = true;
            this.cmbGodown.Location = new System.Drawing.Point(80, 46);
            this.cmbGodown.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbGodown.Name = "cmbGodown";
            this.cmbGodown.Size = new System.Drawing.Size(123, 25);
            this.cmbGodown.TabIndex = 958821;
            // 
            // textBox7
            // 
            this.textBox7.BackColor = System.Drawing.SystemColors.Control;
            this.textBox7.Enabled = false;
            this.textBox7.Font = new System.Drawing.Font("Oswald Regular", 9.75F);
            this.textBox7.Location = new System.Drawing.Point(612, 46);
            this.textBox7.Name = "textBox7";
            this.textBox7.ReadOnly = true;
            this.textBox7.Size = new System.Drawing.Size(77, 25);
            this.textBox7.TabIndex = 108;
            this.textBox7.Text = "Invoice No.";
            // 
            // textBox8
            // 
            this.textBox8.Enabled = false;
            this.textBox8.Font = new System.Drawing.Font("Oswald Regular", 9.75F);
            this.textBox8.Location = new System.Drawing.Point(689, 46);
            this.textBox8.Name = "textBox8";
            this.textBox8.ReadOnly = true;
            this.textBox8.Size = new System.Drawing.Size(123, 25);
            this.textBox8.TabIndex = 107;
            // 
            // txtDCourier
            // 
            this.txtDCourier.BackColor = System.Drawing.SystemColors.Control;
            this.txtDCourier.Enabled = false;
            this.txtDCourier.Font = new System.Drawing.Font("Oswald Regular", 9.75F);
            this.txtDCourier.Location = new System.Drawing.Point(409, 21);
            this.txtDCourier.Name = "txtDCourier";
            this.txtDCourier.ReadOnly = true;
            this.txtDCourier.Size = new System.Drawing.Size(77, 25);
            this.txtDCourier.TabIndex = 106;
            this.txtDCourier.Text = "Voucher Date";
            // 
            // textBox19
            // 
            this.textBox19.Enabled = false;
            this.textBox19.Font = new System.Drawing.Font("Oswald Regular", 9.75F);
            this.textBox19.Location = new System.Drawing.Point(486, 21);
            this.textBox19.Name = "textBox19";
            this.textBox19.ReadOnly = true;
            this.textBox19.Size = new System.Drawing.Size(123, 25);
            this.textBox19.TabIndex = 105;
            // 
            // textBox35
            // 
            this.textBox35.BackColor = System.Drawing.SystemColors.Control;
            this.textBox35.Enabled = false;
            this.textBox35.Font = new System.Drawing.Font("Oswald Regular", 9.75F);
            this.textBox35.Location = new System.Drawing.Point(612, 21);
            this.textBox35.Name = "textBox35";
            this.textBox35.ReadOnly = true;
            this.textBox35.Size = new System.Drawing.Size(77, 25);
            this.textBox35.TabIndex = 100;
            this.textBox35.Text = "Invoice Date";
            // 
            // textBox37
            // 
            this.textBox37.BackColor = System.Drawing.SystemColors.Control;
            this.textBox37.Enabled = false;
            this.textBox37.Font = new System.Drawing.Font("Oswald Regular", 9.75F);
            this.textBox37.Location = new System.Drawing.Point(409, 46);
            this.textBox37.Name = "textBox37";
            this.textBox37.ReadOnly = true;
            this.textBox37.Size = new System.Drawing.Size(77, 25);
            this.textBox37.TabIndex = 98;
            this.textBox37.Text = "Voucher No.";
            // 
            // textBox38
            // 
            this.textBox38.Enabled = false;
            this.textBox38.Font = new System.Drawing.Font("Oswald Regular", 9.75F);
            this.textBox38.Location = new System.Drawing.Point(689, 21);
            this.textBox38.Name = "textBox38";
            this.textBox38.ReadOnly = true;
            this.textBox38.Size = new System.Drawing.Size(123, 25);
            this.textBox38.TabIndex = 97;
            // 
            // textBox43
            // 
            this.textBox43.Enabled = false;
            this.textBox43.Font = new System.Drawing.Font("Oswald Regular", 9.75F);
            this.textBox43.Location = new System.Drawing.Point(486, 46);
            this.textBox43.Name = "textBox43";
            this.textBox43.ReadOnly = true;
            this.textBox43.Size = new System.Drawing.Size(123, 25);
            this.textBox43.TabIndex = 95;
            // 
            // btnsaveasdraft
            // 
            this.btnsaveasdraft.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnsaveasdraft.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnsaveasdraft.Location = new System.Drawing.Point(1068, 608);
            this.btnsaveasdraft.Name = "btnsaveasdraft";
            this.btnsaveasdraft.Size = new System.Drawing.Size(97, 29);
            this.btnsaveasdraft.TabIndex = 958825;
            this.btnsaveasdraft.Text = "Save as Draft";
            this.btnsaveasdraft.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnsaveasdraft.UseVisualStyleBackColor = true;
            this.btnsaveasdraft.Click += new System.EventHandler(this.Btnsaveasdraft_Click);
            // 
            // txttotalitem
            // 
            this.txttotalitem.Location = new System.Drawing.Point(999, 609);
            this.txttotalitem.Name = "txttotalitem";
            this.txttotalitem.ReadOnly = true;
            this.txttotalitem.Size = new System.Drawing.Size(62, 27);
            this.txttotalitem.TabIndex = 958822;
            // 
            // lbltotalproducts
            // 
            this.lbltotalproducts.AutoSize = true;
            this.lbltotalproducts.Location = new System.Drawing.Point(905, 612);
            this.lbltotalproducts.Name = "lbltotalproducts";
            this.lbltotalproducts.Size = new System.Drawing.Size(87, 20);
            this.lbltotalproducts.TabIndex = 958821;
            this.lbltotalproducts.Text = "Total Products";
            // 
            // grbSupplierDetails
            // 
            this.grbSupplierDetails.Font = new System.Drawing.Font("Oswald Regular", 9.75F);
            this.grbSupplierDetails.Location = new System.Drawing.Point(1047, 3);
            this.grbSupplierDetails.Name = "grbSupplierDetails";
            this.grbSupplierDetails.Size = new System.Drawing.Size(294, 109);
            this.grbSupplierDetails.TabIndex = 958813;
            this.grbSupplierDetails.TabStop = false;
            this.grbSupplierDetails.Text = "Supplier Details";
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(83, 580);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(411, 56);
            this.txtRemark.TabIndex = 958807;
            // 
            // lblnarration
            // 
            this.lblnarration.AutoSize = true;
            this.lblnarration.Location = new System.Drawing.Point(18, 580);
            this.lblnarration.Name = "lblnarration";
            this.lblnarration.Size = new System.Drawing.Size(56, 20);
            this.lblnarration.TabIndex = 958812;
            this.lblnarration.Text = "Remarks";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnSave.Image = global::ROMS.Properties.Resources.save;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(1172, 608);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(84, 29);
            this.btnSave.TabIndex = 958810;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnClose.Image = global::ROMS.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(1266, 608);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 29);
            this.btnClose.TabIndex = 958811;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // lblEdit
            // 
            this.lblEdit.AutoSize = true;
            this.lblEdit.Location = new System.Drawing.Point(711, 19);
            this.lblEdit.Name = "lblEdit";
            this.lblEdit.Size = new System.Drawing.Size(0, 20);
            this.lblEdit.TabIndex = 37;
            this.lblEdit.Visible = false;
            // 
            // INV_InwardPurchase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(1354, 675);
            this.Controls.Add(this.lblEdit);
            this.Controls.Add(this.tsInwardList);
            this.Controls.Add(this.pnlinward);
            this.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "INV_InwardPurchase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Brand";
            this.Load += new System.EventHandler(this.INV_Inward_Load);
            this.tsInwardList.ResumeLayout(false);
            this.tsInwardList.PerformLayout();
            this.pnlinward.ResumeLayout(false);
            this.pnlinward.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdGrnlist)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStripLabel tspHeader;
        private System.Windows.Forms.ToolStrip tsInwardList;
        private System.Windows.Forms.Panel pnlinward;
        private System.Windows.Forms.GroupBox grbSupplierDetails;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label lblnarration;
        private System.Windows.Forms.TextBox txttotalitem;
        private System.Windows.Forms.Label lbltotalproducts;
        private System.Windows.Forms.Label lblEdit;
        public System.Windows.Forms.Button btnSave;
        public System.Windows.Forms.Button btnsaveasdraft;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox txtDCourier;
        private System.Windows.Forms.TextBox textBox19;
        private System.Windows.Forms.TextBox textBox35;
        private System.Windows.Forms.TextBox textBox37;
        private System.Windows.Forms.TextBox textBox38;
        private System.Windows.Forms.TextBox textBox43;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox txtInwardNo;
        private System.Windows.Forms.ComboBox cmbGodown;
        public System.Windows.Forms.DataGridView grdGrnlist;
        public System.Windows.Forms.Button btnRemarks;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox txtDUnloading;
        private System.Windows.Forms.TextBox textBox26;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmexpirydate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmBatchno;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
    }
}