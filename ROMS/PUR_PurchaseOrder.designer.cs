namespace ROMS
{
    partial class PUR_PurchaseOrder
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle55 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle56 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle57 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle58 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle59 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle60 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle61 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle62 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle63 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tsBrandList = new System.Windows.Forms.ToolStrip();
            this.tspHeader = new System.Windows.Forms.ToolStripLabel();
            this.lblNoRecordsFound = new System.Windows.Forms.Label();
            this.grdsupplieradd = new System.Windows.Forms.DataGridView();
            this.clmsno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmpicode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmproductname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmunit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmrate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmstock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmreorderqty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmgst = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grppurchaseorder = new System.Windows.Forms.GroupBox();
            this.btnAdd = new System.Windows.Forms.Label();
            this.grpSupplierpossible = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.grdpossiblesupplier = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmsuppliername = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmlastpurchasedate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmlastpurchaserate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clminvoiceno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblNorecord = new System.Windows.Forms.Label();
            this.grpsupplierdetails = new System.Windows.Forms.GroupBox();
            this.grppendingorder = new System.Windows.Forms.GroupBox();
            this.lblFinishedNoRecord = new System.Windows.Forms.Label();
            this.grdPendingorder = new System.Windows.Forms.DataGridView();
            this.clmpsno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmpono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmtotalitem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmtotqty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.lvproduct = new System.Windows.Forms.ListView();
            this.RMcode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RMTname = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RMEName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbSupplier = new System.Windows.Forms.ComboBox();
            this.dpPlanDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlpurchaseorder = new System.Windows.Forms.Panel();
            this.tsBrandList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdsupplieradd)).BeginInit();
            this.grppurchaseorder.SuspendLayout();
            this.grpSupplierpossible.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdpossiblesupplier)).BeginInit();
            this.grppendingorder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPendingorder)).BeginInit();
            this.pnlpurchaseorder.SuspendLayout();
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
            this.tspHeader.Size = new System.Drawing.Size(109, 22);
            this.tspHeader.Text = "Purchase Order";
            // 
            // lblNoRecordsFound
            // 
            this.lblNoRecordsFound.AutoSize = true;
            this.lblNoRecordsFound.BackColor = System.Drawing.Color.White;
            this.lblNoRecordsFound.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoRecordsFound.Location = new System.Drawing.Point(614, 273);
            this.lblNoRecordsFound.Name = "lblNoRecordsFound";
            this.lblNoRecordsFound.Size = new System.Drawing.Size(106, 20);
            this.lblNoRecordsFound.TabIndex = 958763;
            this.lblNoRecordsFound.Text = "No Records Found";
            this.lblNoRecordsFound.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // grdsupplieradd
            // 
            this.grdsupplieradd.AllowUserToAddRows = false;
            this.grdsupplieradd.AllowUserToDeleteRows = false;
            this.grdsupplieradd.AllowUserToResizeColumns = false;
            this.grdsupplieradd.AllowUserToResizeRows = false;
            this.grdsupplieradd.BackgroundColor = System.Drawing.Color.White;
            this.grdsupplieradd.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle55.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle55.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle55.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle55.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle55.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(242)))), ((int)(((byte)(213)))));
            dataGridViewCellStyle55.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle55.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdsupplieradd.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle55;
            this.grdsupplieradd.ColumnHeadersHeight = 30;
            this.grdsupplieradd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdsupplieradd.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmsno,
            this.clmpicode,
            this.clmproductname,
            this.clmunit,
            this.clmrate,
            this.clmstock,
            this.clmreorderqty,
            this.clmgst});
            dataGridViewCellStyle56.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle56.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle56.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle56.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle56.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle56.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle56.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdsupplieradd.DefaultCellStyle = dataGridViewCellStyle56;
            this.grdsupplieradd.EnableHeadersVisualStyles = false;
            this.grdsupplieradd.GridColor = System.Drawing.Color.White;
            this.grdsupplieradd.Location = new System.Drawing.Point(17, 144);
            this.grdsupplieradd.Name = "grdsupplieradd";
            this.grdsupplieradd.ReadOnly = true;
            this.grdsupplieradd.RowHeadersVisible = false;
            dataGridViewCellStyle57.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle57.SelectionForeColor = System.Drawing.Color.White;
            this.grdsupplieradd.RowsDefaultCellStyle = dataGridViewCellStyle57;
            this.grdsupplieradd.RowTemplate.Height = 25;
            this.grdsupplieradd.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdsupplieradd.Size = new System.Drawing.Size(1300, 305);
            this.grdsupplieradd.TabIndex = 1;
            this.grdsupplieradd.Scroll += new System.Windows.Forms.ScrollEventHandler(this.grdBrandList_Scroll);
            this.grdsupplieradd.DoubleClick += new System.EventHandler(this.grdBrandList_DoubleClick);
            this.grdsupplieradd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdBrandList_KeyDown);
            // 
            // clmsno
            // 
            this.clmsno.HeaderText = "S.No.";
            this.clmsno.Name = "clmsno";
            this.clmsno.ReadOnly = true;
            // 
            // clmpicode
            // 
            this.clmpicode.HeaderText = "PI Code";
            this.clmpicode.Name = "clmpicode";
            this.clmpicode.ReadOnly = true;
            // 
            // clmproductname
            // 
            this.clmproductname.HeaderText = "Product Name";
            this.clmproductname.Name = "clmproductname";
            this.clmproductname.ReadOnly = true;
            this.clmproductname.Width = 300;
            // 
            // clmunit
            // 
            this.clmunit.HeaderText = "Unit";
            this.clmunit.Name = "clmunit";
            this.clmunit.ReadOnly = true;
            // 
            // clmrate
            // 
            this.clmrate.HeaderText = "Rate";
            this.clmrate.Name = "clmrate";
            this.clmrate.ReadOnly = true;
            // 
            // clmstock
            // 
            this.clmstock.HeaderText = "Stock";
            this.clmstock.Name = "clmstock";
            this.clmstock.ReadOnly = true;
            this.clmstock.Width = 150;
            // 
            // clmreorderqty
            // 
            this.clmreorderqty.HeaderText = "Reorder Qty";
            this.clmreorderqty.Name = "clmreorderqty";
            this.clmreorderqty.ReadOnly = true;
            this.clmreorderqty.Width = 150;
            // 
            // clmgst
            // 
            this.clmgst.HeaderText = "GST %";
            this.clmgst.Name = "clmgst";
            this.clmgst.ReadOnly = true;
            // 
            // grppurchaseorder
            // 
            this.grppurchaseorder.BackColor = System.Drawing.Color.White;
            this.grppurchaseorder.Controls.Add(this.btnAdd);
            this.grppurchaseorder.Controls.Add(this.lblNoRecordsFound);
            this.grppurchaseorder.Controls.Add(this.grpSupplierpossible);
            this.grppurchaseorder.Controls.Add(this.grpsupplierdetails);
            this.grppurchaseorder.Controls.Add(this.grppendingorder);
            this.grppurchaseorder.Controls.Add(this.txtProductName);
            this.grppurchaseorder.Controls.Add(this.lvproduct);
            this.grppurchaseorder.Controls.Add(this.label3);
            this.grppurchaseorder.Controls.Add(this.label2);
            this.grppurchaseorder.Controls.Add(this.cmbSupplier);
            this.grppurchaseorder.Controls.Add(this.grdsupplieradd);
            this.grppurchaseorder.Controls.Add(this.dpPlanDate);
            this.grppurchaseorder.Controls.Add(this.label1);
            this.grppurchaseorder.Location = new System.Drawing.Point(13, 3);
            this.grppurchaseorder.Name = "grppurchaseorder";
            this.grppurchaseorder.Size = new System.Drawing.Size(1329, 622);
            this.grppurchaseorder.TabIndex = 958788;
            this.grppurchaseorder.TabStop = false;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.SystemColors.Control;
            this.btnAdd.Image = global::ROMS.Properties.Resources.plus;
            this.btnAdd.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAdd.Location = new System.Drawing.Point(393, 112);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(21, 22);
            this.btnAdd.TabIndex = 1111159;
            this.btnAdd.Text = "        ";
            // 
            // grpSupplierpossible
            // 
            this.grpSupplierpossible.BackColor = System.Drawing.Color.White;
            this.grpSupplierpossible.Controls.Add(this.label4);
            this.grpSupplierpossible.Controls.Add(this.grdpossiblesupplier);
            this.grpSupplierpossible.Controls.Add(this.lblNorecord);
            this.grpSupplierpossible.Font = new System.Drawing.Font("Oswald Regular", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpSupplierpossible.Location = new System.Drawing.Point(599, 455);
            this.grpSupplierpossible.Name = "grpSupplierpossible";
            this.grpSupplierpossible.Size = new System.Drawing.Size(718, 155);
            this.grpSupplierpossible.TabIndex = 1111158;
            this.grpSupplierpossible.TabStop = false;
            this.grpSupplierpossible.Text = "Possible Suppliers";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Oswald Regular", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(317, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 16);
            this.label4.TabIndex = 1111161;
            this.label4.Text = "No Records Found";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // grdpossiblesupplier
            // 
            this.grdpossiblesupplier.AllowUserToAddRows = false;
            this.grdpossiblesupplier.AllowUserToDeleteRows = false;
            this.grdpossiblesupplier.AllowUserToResizeColumns = false;
            this.grdpossiblesupplier.AllowUserToResizeRows = false;
            this.grdpossiblesupplier.BackgroundColor = System.Drawing.Color.White;
            this.grdpossiblesupplier.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle58.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle58.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle58.Font = new System.Drawing.Font("Oswald Regular", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle58.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle58.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(242)))), ((int)(((byte)(213)))));
            dataGridViewCellStyle58.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle58.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdpossiblesupplier.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle58;
            this.grdpossiblesupplier.ColumnHeadersHeight = 30;
            this.grdpossiblesupplier.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdpossiblesupplier.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.clmsuppliername,
            this.clmlastpurchasedate,
            this.clmlastpurchaserate,
            this.clminvoiceno});
            dataGridViewCellStyle59.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle59.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle59.Font = new System.Drawing.Font("Oswald Regular", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle59.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle59.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle59.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle59.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdpossiblesupplier.DefaultCellStyle = dataGridViewCellStyle59;
            this.grdpossiblesupplier.EnableHeadersVisualStyles = false;
            this.grdpossiblesupplier.GridColor = System.Drawing.Color.White;
            this.grdpossiblesupplier.Location = new System.Drawing.Point(6, 20);
            this.grdpossiblesupplier.Name = "grdpossiblesupplier";
            this.grdpossiblesupplier.ReadOnly = true;
            this.grdpossiblesupplier.RowHeadersVisible = false;
            dataGridViewCellStyle60.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle60.SelectionForeColor = System.Drawing.Color.White;
            this.grdpossiblesupplier.RowsDefaultCellStyle = dataGridViewCellStyle60;
            this.grdpossiblesupplier.RowTemplate.Height = 25;
            this.grdpossiblesupplier.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdpossiblesupplier.Size = new System.Drawing.Size(706, 130);
            this.grdpossiblesupplier.TabIndex = 1111160;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "S.No.";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // clmsuppliername
            // 
            this.clmsuppliername.HeaderText = "Supplier Name";
            this.clmsuppliername.Name = "clmsuppliername";
            this.clmsuppliername.ReadOnly = true;
            this.clmsuppliername.Width = 200;
            // 
            // clmlastpurchasedate
            // 
            this.clmlastpurchasedate.HeaderText = "Last Purchase Date";
            this.clmlastpurchasedate.Name = "clmlastpurchasedate";
            this.clmlastpurchasedate.ReadOnly = true;
            this.clmlastpurchasedate.Width = 150;
            // 
            // clmlastpurchaserate
            // 
            this.clmlastpurchaserate.HeaderText = "Last Purchase Rate";
            this.clmlastpurchaserate.Name = "clmlastpurchaserate";
            this.clmlastpurchaserate.ReadOnly = true;
            this.clmlastpurchaserate.Width = 150;
            // 
            // clminvoiceno
            // 
            this.clminvoiceno.HeaderText = "Invoice Number";
            this.clminvoiceno.Name = "clminvoiceno";
            this.clminvoiceno.ReadOnly = true;
            // 
            // lblNorecord
            // 
            this.lblNorecord.AutoSize = true;
            this.lblNorecord.BackColor = System.Drawing.Color.White;
            this.lblNorecord.Font = new System.Drawing.Font("Oswald Regular", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNorecord.Location = new System.Drawing.Point(440, 86);
            this.lblNorecord.Name = "lblNorecord";
            this.lblNorecord.Size = new System.Drawing.Size(84, 16);
            this.lblNorecord.TabIndex = 1111139;
            this.lblNorecord.Text = "No Records Found";
            this.lblNorecord.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // grpsupplierdetails
            // 
            this.grpsupplierdetails.Location = new System.Drawing.Point(561, 23);
            this.grpsupplierdetails.Name = "grpsupplierdetails";
            this.grpsupplierdetails.Size = new System.Drawing.Size(452, 114);
            this.grpsupplierdetails.TabIndex = 1111156;
            this.grpsupplierdetails.TabStop = false;
            this.grpsupplierdetails.Text = "Supplier Details";
            // 
            // grppendingorder
            // 
            this.grppendingorder.BackColor = System.Drawing.Color.White;
            this.grppendingorder.Controls.Add(this.lblFinishedNoRecord);
            this.grppendingorder.Controls.Add(this.grdPendingorder);
            this.grppendingorder.Font = new System.Drawing.Font("Oswald Regular", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grppendingorder.Location = new System.Drawing.Point(17, 455);
            this.grppendingorder.Name = "grppendingorder";
            this.grppendingorder.Size = new System.Drawing.Size(571, 155);
            this.grppendingorder.TabIndex = 1111157;
            this.grppendingorder.TabStop = false;
            this.grppendingorder.Text = "Pending Order";
            // 
            // lblFinishedNoRecord
            // 
            this.lblFinishedNoRecord.AutoSize = true;
            this.lblFinishedNoRecord.BackColor = System.Drawing.Color.White;
            this.lblFinishedNoRecord.Font = new System.Drawing.Font("Oswald Regular", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFinishedNoRecord.Location = new System.Drawing.Point(242, 77);
            this.lblFinishedNoRecord.Name = "lblFinishedNoRecord";
            this.lblFinishedNoRecord.Size = new System.Drawing.Size(84, 16);
            this.lblFinishedNoRecord.TabIndex = 1111138;
            this.lblFinishedNoRecord.Text = "No Records Found";
            this.lblFinishedNoRecord.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // grdPendingorder
            // 
            this.grdPendingorder.AllowUserToAddRows = false;
            this.grdPendingorder.AllowUserToDeleteRows = false;
            this.grdPendingorder.AllowUserToResizeColumns = false;
            this.grdPendingorder.AllowUserToResizeRows = false;
            this.grdPendingorder.BackgroundColor = System.Drawing.Color.White;
            this.grdPendingorder.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle61.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle61.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle61.Font = new System.Drawing.Font("Oswald Regular", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle61.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle61.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(242)))), ((int)(((byte)(213)))));
            dataGridViewCellStyle61.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle61.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdPendingorder.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle61;
            this.grdPendingorder.ColumnHeadersHeight = 30;
            this.grdPendingorder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdPendingorder.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmpsno,
            this.clmpono,
            this.clmdate,
            this.clmtotalitem,
            this.clmtotqty});
            dataGridViewCellStyle62.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle62.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle62.Font = new System.Drawing.Font("Oswald Regular", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle62.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle62.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle62.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle62.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdPendingorder.DefaultCellStyle = dataGridViewCellStyle62;
            this.grdPendingorder.EnableHeadersVisualStyles = false;
            this.grdPendingorder.GridColor = System.Drawing.Color.White;
            this.grdPendingorder.Location = new System.Drawing.Point(9, 20);
            this.grdPendingorder.Name = "grdPendingorder";
            this.grdPendingorder.ReadOnly = true;
            this.grdPendingorder.RowHeadersVisible = false;
            dataGridViewCellStyle63.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle63.SelectionForeColor = System.Drawing.Color.White;
            this.grdPendingorder.RowsDefaultCellStyle = dataGridViewCellStyle63;
            this.grdPendingorder.RowTemplate.Height = 25;
            this.grdPendingorder.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdPendingorder.Size = new System.Drawing.Size(551, 130);
            this.grdPendingorder.TabIndex = 1111159;
            // 
            // clmpsno
            // 
            this.clmpsno.HeaderText = "S.No.";
            this.clmpsno.Name = "clmpsno";
            this.clmpsno.ReadOnly = true;
            this.clmpsno.Width = 50;
            // 
            // clmpono
            // 
            this.clmpono.HeaderText = "Po.No.";
            this.clmpono.Name = "clmpono";
            this.clmpono.ReadOnly = true;
            // 
            // clmdate
            // 
            this.clmdate.HeaderText = "Date";
            this.clmdate.Name = "clmdate";
            this.clmdate.ReadOnly = true;
            this.clmdate.Width = 120;
            // 
            // clmtotalitem
            // 
            this.clmtotalitem.HeaderText = "Total Items";
            this.clmtotalitem.Name = "clmtotalitem";
            this.clmtotalitem.ReadOnly = true;
            this.clmtotalitem.Width = 150;
            // 
            // clmtotqty
            // 
            this.clmtotqty.HeaderText = "Total Qty";
            this.clmtotqty.Name = "clmtotqty";
            this.clmtotqty.ReadOnly = true;
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(17, 110);
            this.txtProductName.MaxLength = 50;
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(366, 27);
            this.txtProductName.TabIndex = 1111155;
            // 
            // lvproduct
            // 
            this.lvproduct.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.RMcode,
            this.RMTname,
            this.RMEName});
            this.lvproduct.FullRowSelect = true;
            this.lvproduct.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvproduct.HideSelection = false;
            this.lvproduct.Location = new System.Drawing.Point(16, 144);
            this.lvproduct.Name = "lvproduct";
            this.lvproduct.Size = new System.Drawing.Size(523, 236);
            this.lvproduct.TabIndex = 1111156;
            this.lvproduct.UseCompatibleStateImageBehavior = false;
            this.lvproduct.View = System.Windows.Forms.View.Details;
            this.lvproduct.Visible = false;
            // 
            // RMcode
            // 
            this.RMcode.Width = 0;
            // 
            // RMTname
            // 
            this.RMTname.Width = 200;
            // 
            // RMEName
            // 
            this.RMEName.Width = 200;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(17, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Product Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(134, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 20);
            this.label2.TabIndex = 1111136;
            this.label2.Text = "Supplier Name";
            // 
            // cmbSupplier
            // 
            this.cmbSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSupplier.FormattingEnabled = true;
            this.cmbSupplier.Location = new System.Drawing.Point(134, 46);
            this.cmbSupplier.Name = "cmbSupplier";
            this.cmbSupplier.Size = new System.Drawing.Size(280, 27);
            this.cmbSupplier.TabIndex = 1;
            // 
            // dpPlanDate
            // 
            this.dpPlanDate.CustomFormat = "dd/MM/yyyy";
            this.dpPlanDate.Enabled = false;
            this.dpPlanDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpPlanDate.Location = new System.Drawing.Point(16, 46);
            this.dpPlanDate.Name = "dpPlanDate";
            this.dpPlanDate.Size = new System.Drawing.Size(98, 27);
            this.dpPlanDate.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 20);
            this.label1.TabIndex = 20;
            this.label1.Text = "Date";
            // 
            // pnlpurchaseorder
            // 
            this.pnlpurchaseorder.BackColor = System.Drawing.Color.White;
            this.pnlpurchaseorder.Controls.Add(this.grppurchaseorder);
            this.pnlpurchaseorder.Location = new System.Drawing.Point(0, 40);
            this.pnlpurchaseorder.Name = "pnlpurchaseorder";
            this.pnlpurchaseorder.Size = new System.Drawing.Size(1354, 639);
            this.pnlpurchaseorder.TabIndex = 958789;
            // 
            // PUR_PurchaseOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(1354, 675);
            this.Controls.Add(this.pnlpurchaseorder);
            this.Controls.Add(this.tsBrandList);
            this.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "PUR_PurchaseOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Brand";
            this.Load += new System.EventHandler(this.CP_BrandList_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CP_BrandList_KeyDown);
            this.tsBrandList.ResumeLayout(false);
            this.tsBrandList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdsupplieradd)).EndInit();
            this.grppurchaseorder.ResumeLayout(false);
            this.grppurchaseorder.PerformLayout();
            this.grpSupplierpossible.ResumeLayout(false);
            this.grpSupplierpossible.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdpossiblesupplier)).EndInit();
            this.grppendingorder.ResumeLayout(false);
            this.grppendingorder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPendingorder)).EndInit();
            this.pnlpurchaseorder.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsBrandList;
        private System.Windows.Forms.ToolStripLabel tspHeader;
        private System.Windows.Forms.Label lblNoRecordsFound;
        public System.Windows.Forms.DataGridView grdsupplieradd;
        private System.Windows.Forms.GroupBox grppurchaseorder;
        private System.Windows.Forms.DateTimePicker dpPlanDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox cmbSupplier;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView lvproduct;
        private System.Windows.Forms.ColumnHeader RMcode;
        private System.Windows.Forms.ColumnHeader RMTname;
        private System.Windows.Forms.ColumnHeader RMEName;
        public System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.GroupBox grpsupplierdetails;
        private System.Windows.Forms.GroupBox grpSupplierpossible;
        private System.Windows.Forms.Label lblNorecord;
        private System.Windows.Forms.GroupBox grppendingorder;
        private System.Windows.Forms.Label lblFinishedNoRecord;
        public System.Windows.Forms.DataGridView grdPendingorder;
        public System.Windows.Forms.DataGridView grdpossiblesupplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmsuppliername;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmlastpurchasedate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmlastpurchaserate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clminvoiceno;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmsno;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmpicode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmproductname;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmunit;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmrate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmstock;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmreorderqty;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmgst;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmpsno;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmpono;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmtotalitem;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmtotqty;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Label btnAdd;
        private System.Windows.Forms.Panel pnlpurchaseorder;
    }
}