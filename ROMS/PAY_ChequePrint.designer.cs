namespace ROMS
{
    partial class PAY_ChequePrint
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
            this.tsDirectCheque = new System.Windows.Forms.ToolStrip();
            this.tspSupplierMapping = new System.Windows.Forms.ToolStripLabel();
            this.lblNoRecordsFound = new System.Windows.Forms.Label();
            this.pnlSupplierMapping = new System.Windows.Forms.Panel();
            this.grpSupplierMapping = new System.Windows.Forms.GroupBox();
            this.LV_Supplier = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RPTViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.lblAmount = new System.Windows.Forms.Label();
            this.lblschedule = new System.Windows.Forms.Label();
            this.lblSupplierCode = new System.Windows.Forms.Label();
            this.lblReturn = new System.Windows.Forms.Label();
            this.grpAmountInWords = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblSupplierOrderpolicy = new System.Windows.Forms.Label();
            this.lblsupplierScheduletype = new System.Windows.Forms.Label();
            this.lblSupplierCity = new System.Windows.Forms.Label();
            this.lblSuppliername = new System.Windows.Forms.Label();
            this.lblsupplierGST = new System.Windows.Forms.Label();
            this.lblsupplierpayment = new System.Windows.Forms.Label();
            this.grbgodown = new System.Windows.Forms.GroupBox();
            this.txtOthersText = new System.Windows.Forms.TextBox();
            this.txtNameText = new System.Windows.Forms.TextBox();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.cmbBank = new System.Windows.Forms.ComboBox();
            this.btnPreview = new System.Windows.Forms.Button();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.lblDAmount = new System.Windows.Forms.Label();
            this.lblDBank = new System.Windows.Forms.Label();
            this.dpDate = new System.Windows.Forms.DateTimePicker();
            this.txtsuppliername = new System.Windows.Forms.TextBox();
            this.lblSupplier = new System.Windows.Forms.Label();
            this.lblChequeDate = new System.Windows.Forms.Label();
            this.epCheque = new System.Windows.Forms.ErrorProvider(this.components);
            this.tsDirectCheque.SuspendLayout();
            this.pnlSupplierMapping.SuspendLayout();
            this.grpSupplierMapping.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.grbgodown.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epCheque)).BeginInit();
            this.SuspendLayout();
            // 
            // tsDirectCheque
            // 
            this.tsDirectCheque.BackColor = System.Drawing.Color.White;
            this.tsDirectCheque.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsDirectCheque.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsDirectCheque.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspSupplierMapping});
            this.tsDirectCheque.Location = new System.Drawing.Point(0, 0);
            this.tsDirectCheque.Name = "tsDirectCheque";
            this.tsDirectCheque.Size = new System.Drawing.Size(1354, 25);
            this.tsDirectCheque.TabIndex = 35;
            this.tsDirectCheque.Text = "Direct Cheque Print";
            // 
            // tspSupplierMapping
            // 
            this.tspSupplierMapping.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tspSupplierMapping.Image = global::ROMS.Properties.Resources.bread_crumb;
            this.tspSupplierMapping.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tspSupplierMapping.Margin = new System.Windows.Forms.Padding(15, 1, 0, 2);
            this.tspSupplierMapping.Name = "tspSupplierMapping";
            this.tspSupplierMapping.Size = new System.Drawing.Size(149, 22);
            this.tspSupplierMapping.Text = "Direct Cheque Printing";
            // 
            // lblNoRecordsFound
            // 
            this.lblNoRecordsFound.AutoSize = true;
            this.lblNoRecordsFound.BackColor = System.Drawing.Color.White;
            this.lblNoRecordsFound.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoRecordsFound.Location = new System.Drawing.Point(627, 327);
            this.lblNoRecordsFound.Name = "lblNoRecordsFound";
            this.lblNoRecordsFound.Size = new System.Drawing.Size(106, 20);
            this.lblNoRecordsFound.TabIndex = 958763;
            this.lblNoRecordsFound.Text = "No Records Found";
            this.lblNoRecordsFound.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pnlSupplierMapping
            // 
            this.pnlSupplierMapping.BackColor = System.Drawing.Color.White;
            this.pnlSupplierMapping.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSupplierMapping.Controls.Add(this.grpSupplierMapping);
            this.pnlSupplierMapping.Location = new System.Drawing.Point(0, 29);
            this.pnlSupplierMapping.Name = "pnlSupplierMapping";
            this.pnlSupplierMapping.Size = new System.Drawing.Size(1353, 643);
            this.pnlSupplierMapping.TabIndex = 958764;
            // 
            // grpSupplierMapping
            // 
            this.grpSupplierMapping.BackColor = System.Drawing.Color.White;
            this.grpSupplierMapping.Controls.Add(this.LV_Supplier);
            this.grpSupplierMapping.Controls.Add(this.RPTViewer);
            this.grpSupplierMapping.Controls.Add(this.lblAmount);
            this.grpSupplierMapping.Controls.Add(this.lblschedule);
            this.grpSupplierMapping.Controls.Add(this.lblSupplierCode);
            this.grpSupplierMapping.Controls.Add(this.lblReturn);
            this.grpSupplierMapping.Controls.Add(this.grpAmountInWords);
            this.grpSupplierMapping.Controls.Add(this.groupBox2);
            this.grpSupplierMapping.Controls.Add(this.grbgodown);
            this.grpSupplierMapping.Location = new System.Drawing.Point(7, 1);
            this.grpSupplierMapping.Name = "grpSupplierMapping";
            this.grpSupplierMapping.Size = new System.Drawing.Size(1339, 641);
            this.grpSupplierMapping.TabIndex = 958765;
            this.grpSupplierMapping.TabStop = false;
            // 
            // LV_Supplier
            // 
            this.LV_Supplier.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader1,
            this.columnHeader2});
            this.LV_Supplier.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.LV_Supplier.HideSelection = false;
            this.LV_Supplier.Location = new System.Drawing.Point(131, 77);
            this.LV_Supplier.Name = "LV_Supplier";
            this.LV_Supplier.Size = new System.Drawing.Size(374, 164);
            this.LV_Supplier.TabIndex = 1111223;
            this.LV_Supplier.UseCompatibleStateImageBehavior = false;
            this.LV_Supplier.View = System.Windows.Forms.View.Details;
            this.LV_Supplier.Visible = false;
            this.LV_Supplier.DoubleClick += new System.EventHandler(this.LV_Supplier_DoubleClick);
            this.LV_Supplier.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LV_Supplier_KeyDown);
            // 
            // columnHeader5
            // 
            this.columnHeader5.Width = 180;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Width = 120;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Width = 0;
            // 
            // RPTViewer
            // 
            this.RPTViewer.ActiveViewIndex = -1;
            this.RPTViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RPTViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.RPTViewer.Location = new System.Drawing.Point(6, 144);
            this.RPTViewer.Name = "RPTViewer";
            this.RPTViewer.ReuseParameterValuesOnRefresh = true;
            this.RPTViewer.Size = new System.Drawing.Size(1331, 493);
            this.RPTViewer.TabIndex = 1110000993;
            this.RPTViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.RPTViewer.Visible = false;
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(741, 37);
            this.lblAmount.MaximumSize = new System.Drawing.Size(280, 0);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(51, 20);
            this.lblAmount.TabIndex = 1111228;
            this.lblAmount.Text = "Amount";
            this.lblAmount.Visible = false;
            // 
            // lblschedule
            // 
            this.lblschedule.AutoSize = true;
            this.lblschedule.Location = new System.Drawing.Point(661, 306);
            this.lblschedule.Name = "lblschedule";
            this.lblschedule.Size = new System.Drawing.Size(16, 20);
            this.lblschedule.TabIndex = 1111227;
            this.lblschedule.Text = "0";
            this.lblschedule.Visible = false;
            // 
            // lblSupplierCode
            // 
            this.lblSupplierCode.AutoSize = true;
            this.lblSupplierCode.Location = new System.Drawing.Point(15, 254);
            this.lblSupplierCode.Name = "lblSupplierCode";
            this.lblSupplierCode.Size = new System.Drawing.Size(16, 20);
            this.lblSupplierCode.TabIndex = 1111226;
            this.lblSupplierCode.Text = "0";
            this.lblSupplierCode.Visible = false;
            // 
            // lblReturn
            // 
            this.lblReturn.AutoSize = true;
            this.lblReturn.BackColor = System.Drawing.Color.White;
            this.lblReturn.Font = new System.Drawing.Font("Oswald Regular", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReturn.Location = new System.Drawing.Point(1241, 114);
            this.lblReturn.Name = "lblReturn";
            this.lblReturn.Size = new System.Drawing.Size(0, 16);
            this.lblReturn.TabIndex = 1111225;
            this.lblReturn.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblReturn.Visible = false;
            // 
            // grpAmountInWords
            // 
            this.grpAmountInWords.Font = new System.Drawing.Font("Oswald Regular", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpAmountInWords.Location = new System.Drawing.Point(735, 13);
            this.grpAmountInWords.Name = "grpAmountInWords";
            this.grpAmountInWords.Size = new System.Drawing.Size(295, 122);
            this.grpAmountInWords.TabIndex = 1111224;
            this.grpAmountInWords.TabStop = false;
            this.grpAmountInWords.Text = "Amount in words";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblSupplierOrderpolicy);
            this.groupBox2.Controls.Add(this.lblsupplierScheduletype);
            this.groupBox2.Controls.Add(this.lblSupplierCity);
            this.groupBox2.Controls.Add(this.lblSuppliername);
            this.groupBox2.Controls.Add(this.lblsupplierGST);
            this.groupBox2.Controls.Add(this.lblsupplierpayment);
            this.groupBox2.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.groupBox2.Location = new System.Drawing.Point(1031, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(306, 122);
            this.groupBox2.TabIndex = 1111223;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Supplier Details";
            // 
            // lblSupplierOrderpolicy
            // 
            this.lblSupplierOrderpolicy.AutoSize = true;
            this.lblSupplierOrderpolicy.BackColor = System.Drawing.Color.White;
            this.lblSupplierOrderpolicy.Font = new System.Drawing.Font("Oswald Regular", 8F);
            this.lblSupplierOrderpolicy.Location = new System.Drawing.Point(6, 103);
            this.lblSupplierOrderpolicy.Name = "lblSupplierOrderpolicy";
            this.lblSupplierOrderpolicy.Size = new System.Drawing.Size(0, 15);
            this.lblSupplierOrderpolicy.TabIndex = 1111206;
            this.lblSupplierOrderpolicy.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblsupplierScheduletype
            // 
            this.lblsupplierScheduletype.AutoSize = true;
            this.lblsupplierScheduletype.BackColor = System.Drawing.Color.White;
            this.lblsupplierScheduletype.Font = new System.Drawing.Font("Oswald Regular", 8F);
            this.lblsupplierScheduletype.Location = new System.Drawing.Point(6, 71);
            this.lblsupplierScheduletype.Name = "lblsupplierScheduletype";
            this.lblsupplierScheduletype.Size = new System.Drawing.Size(0, 15);
            this.lblsupplierScheduletype.TabIndex = 1111203;
            this.lblsupplierScheduletype.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblSupplierCity
            // 
            this.lblSupplierCity.AutoSize = true;
            this.lblSupplierCity.BackColor = System.Drawing.Color.White;
            this.lblSupplierCity.Font = new System.Drawing.Font("Oswald Regular", 8F);
            this.lblSupplierCity.Location = new System.Drawing.Point(6, 38);
            this.lblSupplierCity.Name = "lblSupplierCity";
            this.lblSupplierCity.Size = new System.Drawing.Size(0, 15);
            this.lblSupplierCity.TabIndex = 1111204;
            this.lblSupplierCity.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblSuppliername
            // 
            this.lblSuppliername.AutoSize = true;
            this.lblSuppliername.BackColor = System.Drawing.Color.White;
            this.lblSuppliername.Font = new System.Drawing.Font("Oswald Regular", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSuppliername.Location = new System.Drawing.Point(6, 20);
            this.lblSuppliername.Name = "lblSuppliername";
            this.lblSuppliername.Size = new System.Drawing.Size(0, 19);
            this.lblSuppliername.TabIndex = 1111200;
            this.lblSuppliername.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblsupplierGST
            // 
            this.lblsupplierGST.AutoSize = true;
            this.lblsupplierGST.BackColor = System.Drawing.Color.White;
            this.lblsupplierGST.Font = new System.Drawing.Font("Oswald Regular", 8F);
            this.lblsupplierGST.Location = new System.Drawing.Point(6, 55);
            this.lblsupplierGST.Name = "lblsupplierGST";
            this.lblsupplierGST.Size = new System.Drawing.Size(0, 15);
            this.lblsupplierGST.TabIndex = 1111201;
            this.lblsupplierGST.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblsupplierpayment
            // 
            this.lblsupplierpayment.AutoSize = true;
            this.lblsupplierpayment.BackColor = System.Drawing.Color.White;
            this.lblsupplierpayment.Font = new System.Drawing.Font("Oswald Regular", 8F);
            this.lblsupplierpayment.Location = new System.Drawing.Point(6, 87);
            this.lblsupplierpayment.Name = "lblsupplierpayment";
            this.lblsupplierpayment.Size = new System.Drawing.Size(0, 15);
            this.lblsupplierpayment.TabIndex = 1111202;
            this.lblsupplierpayment.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // grbgodown
            // 
            this.grbgodown.Controls.Add(this.txtOthersText);
            this.grbgodown.Controls.Add(this.txtNameText);
            this.grbgodown.Controls.Add(this.cmbType);
            this.grbgodown.Controls.Add(this.label1);
            this.grbgodown.Controls.Add(this.btnClear);
            this.grbgodown.Controls.Add(this.cmbBank);
            this.grbgodown.Controls.Add(this.btnPreview);
            this.grbgodown.Controls.Add(this.txtAmount);
            this.grbgodown.Controls.Add(this.lblDAmount);
            this.grbgodown.Controls.Add(this.lblDBank);
            this.grbgodown.Controls.Add(this.dpDate);
            this.grbgodown.Controls.Add(this.txtsuppliername);
            this.grbgodown.Controls.Add(this.lblSupplier);
            this.grbgodown.Controls.Add(this.lblChequeDate);
            this.grbgodown.Location = new System.Drawing.Point(6, 13);
            this.grbgodown.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbgodown.Name = "grbgodown";
            this.grbgodown.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbgodown.Size = new System.Drawing.Size(718, 122);
            this.grbgodown.TabIndex = 958806;
            this.grbgodown.TabStop = false;
            // 
            // txtOthersText
            // 
            this.txtOthersText.Location = new System.Drawing.Point(499, 36);
            this.txtOthersText.Name = "txtOthersText";
            this.txtOthersText.Size = new System.Drawing.Size(205, 27);
            this.txtOthersText.TabIndex = 3;
            this.txtOthersText.Enter += new System.EventHandler(this.txtOthersText_Enter);
            this.txtOthersText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtOthersText_KeyDown);
            this.txtOthersText.Leave += new System.EventHandler(this.txtOthersText_Leave);
            // 
            // txtNameText
            // 
            this.txtNameText.Location = new System.Drawing.Point(125, 36);
            this.txtNameText.Name = "txtNameText";
            this.txtNameText.Size = new System.Drawing.Size(250, 27);
            this.txtNameText.TabIndex = 93;
            this.txtNameText.TextChanged += new System.EventHandler(this.txtNameText_TextChanged);
            this.txtNameText.Enter += new System.EventHandler(this.txtNameText_Enter);
            this.txtNameText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNameText_KeyDown);
            this.txtNameText.Leave += new System.EventHandler(this.txtNameText_Leave);
            // 
            // cmbType
            // 
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(11, 36);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(108, 27);
            this.cmbType.TabIndex = 0;
            this.cmbType.SelectedIndexChanged += new System.EventHandler(this.cmbType_SelectedIndexChanged);
            this.cmbType.Enter += new System.EventHandler(this.cmbType_Enter);
            this.cmbType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbType_KeyDown);
            this.cmbType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbType_KeyPress);
            this.cmbType.Leave += new System.EventHandler(this.cmbType_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 20);
            this.label1.TabIndex = 92;
            this.label1.Text = "Type";
            // 
            // btnClear
            // 
            this.btnClear.Image = global::ROMS.Properties.Resources.refresh;
            this.btnClear.Location = new System.Drawing.Point(299, 89);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(34, 29);
            this.btnClear.TabIndex = 7;
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // cmbBank
            // 
            this.cmbBank.FormattingEnabled = true;
            this.cmbBank.Location = new System.Drawing.Point(381, 36);
            this.cmbBank.Name = "cmbBank";
            this.cmbBank.Size = new System.Drawing.Size(107, 27);
            this.cmbBank.TabIndex = 2;
            this.cmbBank.Enter += new System.EventHandler(this.CmbBank_Enter);
            this.cmbBank.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbBank_KeyDown);
            this.cmbBank.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbBank_KeyPress);
            this.cmbBank.Leave += new System.EventHandler(this.CmbBank_Leave);
            // 
            // btnPreview
            // 
            this.btnPreview.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnPreview.Image = global::ROMS.Properties.Resources.view;
            this.btnPreview.Location = new System.Drawing.Point(259, 89);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(34, 29);
            this.btnPreview.TabIndex = 6;
            this.btnPreview.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.BtnPreview_Click);
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(125, 90);
            this.txtAmount.MaxLength = 10;
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(128, 27);
            this.txtAmount.TabIndex = 5;
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAmount.TextChanged += new System.EventHandler(this.TxtAmount_TextChanged);
            this.txtAmount.Enter += new System.EventHandler(this.TxtAmount_Enter);
            this.txtAmount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtAmount_KeyDown);
            this.txtAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtAmount_KeyPress);
            this.txtAmount.Leave += new System.EventHandler(this.TxtAmount_Leave);
            // 
            // lblDAmount
            // 
            this.lblDAmount.AutoSize = true;
            this.lblDAmount.Location = new System.Drawing.Point(125, 68);
            this.lblDAmount.Name = "lblDAmount";
            this.lblDAmount.Size = new System.Drawing.Size(95, 20);
            this.lblDAmount.TabIndex = 90;
            this.lblDAmount.Text = "Cheque Amount";
            // 
            // lblDBank
            // 
            this.lblDBank.AutoSize = true;
            this.lblDBank.Location = new System.Drawing.Point(381, 14);
            this.lblDBank.Name = "lblDBank";
            this.lblDBank.Size = new System.Drawing.Size(36, 20);
            this.lblDBank.TabIndex = 87;
            this.lblDBank.Text = "Bank";
            // 
            // dpDate
            // 
            this.dpDate.CustomFormat = "dd/MM/yyyy";
            this.dpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpDate.Location = new System.Drawing.Point(11, 90);
            this.dpDate.Name = "dpDate";
            this.dpDate.Size = new System.Drawing.Size(108, 27);
            this.dpDate.TabIndex = 4;
            this.dpDate.Enter += new System.EventHandler(this.DpDate_Enter);
            this.dpDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DpDate_KeyDown);
            this.dpDate.Leave += new System.EventHandler(this.DpDate_Leave);
            // 
            // txtsuppliername
            // 
            this.txtsuppliername.Location = new System.Drawing.Point(125, 36);
            this.txtsuppliername.Name = "txtsuppliername";
            this.txtsuppliername.Size = new System.Drawing.Size(250, 27);
            this.txtsuppliername.TabIndex = 1;
            this.txtsuppliername.TextChanged += new System.EventHandler(this.Txtsuppliername_TextChanged);
            this.txtsuppliername.Enter += new System.EventHandler(this.Txtsuppliername_Enter);
            this.txtsuppliername.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Txtsuppliername_KeyDown);
            this.txtsuppliername.Leave += new System.EventHandler(this.Txtsuppliername_Leave);
            // 
            // lblSupplier
            // 
            this.lblSupplier.AutoSize = true;
            this.lblSupplier.Location = new System.Drawing.Point(125, 14);
            this.lblSupplier.Name = "lblSupplier";
            this.lblSupplier.Size = new System.Drawing.Size(57, 20);
            this.lblSupplier.TabIndex = 27;
            this.lblSupplier.Text = "Supplier ";
            // 
            // lblChequeDate
            // 
            this.lblChequeDate.AutoSize = true;
            this.lblChequeDate.Location = new System.Drawing.Point(11, 68);
            this.lblChequeDate.Name = "lblChequeDate";
            this.lblChequeDate.Size = new System.Drawing.Size(78, 20);
            this.lblChequeDate.TabIndex = 70;
            this.lblChequeDate.Text = "Cheque Date";
            // 
            // epCheque
            // 
            this.epCheque.ContainerControl = this;
            // 
            // PAY_ChequePrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(1354, 674);
            this.Controls.Add(this.pnlSupplierMapping);
            this.Controls.Add(this.lblNoRecordsFound);
            this.Controls.Add(this.tsDirectCheque);
            this.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "PAY_ChequePrint";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Direct Cheque Printing";
            this.Load += new System.EventHandler(this.PAY_ChequePrint_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PAY_ChequePrint_KeyDown);
            this.Leave += new System.EventHandler(this.PAY_ChequePrint_Leave);
            this.tsDirectCheque.ResumeLayout(false);
            this.tsDirectCheque.PerformLayout();
            this.pnlSupplierMapping.ResumeLayout(false);
            this.grpSupplierMapping.ResumeLayout(false);
            this.grpSupplierMapping.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.grbgodown.ResumeLayout(false);
            this.grbgodown.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epCheque)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsDirectCheque;
        private System.Windows.Forms.ToolStripLabel tspSupplierMapping;
        private System.Windows.Forms.Label lblNoRecordsFound;
        private System.Windows.Forms.Panel pnlSupplierMapping;
        private System.Windows.Forms.GroupBox grpSupplierMapping;
        private System.Windows.Forms.GroupBox grbgodown;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label lblDAmount;
        private System.Windows.Forms.Label lblDBank;
        private System.Windows.Forms.DateTimePicker dpDate;
        private System.Windows.Forms.TextBox txtsuppliername;
        private System.Windows.Forms.Label lblSupplier;
        private System.Windows.Forms.Label lblChequeDate;
        private System.Windows.Forms.GroupBox grpAmountInWords;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblSupplierOrderpolicy;
        private System.Windows.Forms.Label lblsupplierScheduletype;
        private System.Windows.Forms.Label lblSupplierCity;
        private System.Windows.Forms.Label lblSuppliername;
        private System.Windows.Forms.Label lblsupplierGST;
        private System.Windows.Forms.Label lblsupplierpayment;
        public System.Windows.Forms.ListView LV_Supplier;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Label lblReturn;
        private System.Windows.Forms.Label lblSupplierCode;
        private System.Windows.Forms.ErrorProvider epCheque;
        private System.Windows.Forms.Label lblschedule;
        private System.Windows.Forms.ComboBox cmbBank;
        private System.Windows.Forms.Label lblAmount;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer RPTViewer;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.TextBox txtNameText;
        private System.Windows.Forms.TextBox txtOthersText;
        private System.Windows.Forms.ColumnHeader columnHeader2;
    }
}