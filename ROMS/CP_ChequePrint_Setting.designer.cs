namespace ROMS
{
    partial class CP_ChequePrint_Setting
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
            this.pnlSettings = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pbChequePreview = new System.Windows.Forms.PictureBox();
            this.grdChequePrint = new System.Windows.Forms.DataGridView();
            this.clmSno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmBank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTemplate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmImageName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmBankId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTemplateID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPreview = new System.Windows.Forms.DataGridViewImageColumn();
            this.clmRemove = new System.Windows.Forms.DataGridViewImageColumn();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.grpVoucherSettings = new System.Windows.Forms.GroupBox();
            this.btnPreview = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.cmbTemplate = new System.Windows.Forms.ComboBox();
            this.lblTransactionType = new System.Windows.Forms.Label();
            this.cmbBank = new System.Windows.Forms.ComboBox();
            this.lblDEConcern = new System.Windows.Forms.Label();
            this.epSettings = new System.Windows.Forms.ErrorProvider(this.components);
            this.tsChequePrintSettings = new System.Windows.Forms.ToolStrip();
            this.tspHeader = new System.Windows.Forms.ToolStripLabel();
            this.pnlSettings.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbChequePreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdChequePrint)).BeginInit();
            this.grpVoucherSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epSettings)).BeginInit();
            this.tsChequePrintSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSettings
            // 
            this.pnlSettings.BackColor = System.Drawing.Color.White;
            this.pnlSettings.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSettings.Controls.Add(this.groupBox2);
            this.pnlSettings.Controls.Add(this.grdChequePrint);
            this.pnlSettings.Controls.Add(this.btnSave);
            this.pnlSettings.Controls.Add(this.btnClose);
            this.pnlSettings.Controls.Add(this.grpVoucherSettings);
            this.pnlSettings.Location = new System.Drawing.Point(137, 131);
            this.pnlSettings.Name = "pnlSettings";
            this.pnlSettings.Size = new System.Drawing.Size(1036, 432);
            this.pnlSettings.TabIndex = 958788;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pbChequePreview);
            this.groupBox2.Location = new System.Drawing.Point(578, 80);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(439, 303);
            this.groupBox2.TabIndex = 958791;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cheque Preview";
            // 
            // pbChequePreview
            // 
            this.pbChequePreview.Location = new System.Drawing.Point(18, 36);
            this.pbChequePreview.Name = "pbChequePreview";
            this.pbChequePreview.Size = new System.Drawing.Size(402, 243);
            this.pbChequePreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbChequePreview.TabIndex = 40;
            this.pbChequePreview.TabStop = false;
            // 
            // grdChequePrint
            // 
            this.grdChequePrint.AllowUserToAddRows = false;
            this.grdChequePrint.AllowUserToDeleteRows = false;
            this.grdChequePrint.AllowUserToResizeColumns = false;
            this.grdChequePrint.AllowUserToResizeRows = false;
            this.grdChequePrint.BackgroundColor = System.Drawing.Color.White;
            this.grdChequePrint.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdChequePrint.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdChequePrint.ColumnHeadersHeight = 30;
            this.grdChequePrint.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdChequePrint.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmSno,
            this.clmBank,
            this.clmTemplate,
            this.clmImageName,
            this.clmBankId,
            this.clmTemplateID,
            this.clmID,
            this.clmPreview,
            this.clmRemove});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdChequePrint.DefaultCellStyle = dataGridViewCellStyle2;
            this.grdChequePrint.EnableHeadersVisualStyles = false;
            this.grdChequePrint.GridColor = System.Drawing.Color.White;
            this.grdChequePrint.Location = new System.Drawing.Point(14, 80);
            this.grdChequePrint.Name = "grdChequePrint";
            this.grdChequePrint.ReadOnly = true;
            this.grdChequePrint.RowHeadersVisible = false;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.grdChequePrint.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.grdChequePrint.RowTemplate.Height = 25;
            this.grdChequePrint.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdChequePrint.Size = new System.Drawing.Size(558, 304);
            this.grdChequePrint.TabIndex = 53432;
            this.grdChequePrint.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrdChequePrint_CellContentClick);
            // 
            // clmSno
            // 
            this.clmSno.HeaderText = "S.No.";
            this.clmSno.Name = "clmSno";
            this.clmSno.ReadOnly = true;
            this.clmSno.Width = 50;
            // 
            // clmBank
            // 
            this.clmBank.HeaderText = "Bank";
            this.clmBank.Name = "clmBank";
            this.clmBank.ReadOnly = true;
            this.clmBank.Width = 150;
            // 
            // clmTemplate
            // 
            this.clmTemplate.HeaderText = "Template";
            this.clmTemplate.Name = "clmTemplate";
            this.clmTemplate.ReadOnly = true;
            this.clmTemplate.Width = 200;
            // 
            // clmImageName
            // 
            this.clmImageName.HeaderText = "Image Name";
            this.clmImageName.Name = "clmImageName";
            this.clmImageName.ReadOnly = true;
            this.clmImageName.Visible = false;
            // 
            // clmBankId
            // 
            this.clmBankId.HeaderText = "Bank ID";
            this.clmBankId.Name = "clmBankId";
            this.clmBankId.ReadOnly = true;
            this.clmBankId.Visible = false;
            // 
            // clmTemplateID
            // 
            this.clmTemplateID.HeaderText = "Template ID";
            this.clmTemplateID.Name = "clmTemplateID";
            this.clmTemplateID.ReadOnly = true;
            this.clmTemplateID.Visible = false;
            // 
            // clmID
            // 
            this.clmID.HeaderText = "ID";
            this.clmID.Name = "clmID";
            this.clmID.ReadOnly = true;
            this.clmID.Visible = false;
            // 
            // clmPreview
            // 
            this.clmPreview.HeaderText = "Preview";
            this.clmPreview.Image = global::ROMS.Properties.Resources.print;
            this.clmPreview.Name = "clmPreview";
            this.clmPreview.ReadOnly = true;
            this.clmPreview.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmPreview.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.clmPreview.Width = 60;
            // 
            // clmRemove
            // 
            this.clmRemove.HeaderText = "Remove";
            this.clmRemove.Image = global::ROMS.Properties.Resources.remove;
            this.clmRemove.Name = "clmRemove";
            this.clmRemove.ReadOnly = true;
            this.clmRemove.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmRemove.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.clmRemove.Width = 60;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnSave.Image = global::ROMS.Properties.Resources.save;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(426, 390);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(71, 29);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            this.btnSave.Enter += new System.EventHandler(this.BtnSave_Enter);
            this.btnSave.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BtnSave_KeyDown);
            this.btnSave.Leave += new System.EventHandler(this.BtnSave_Leave);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnClose.Image = global::ROMS.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(501, 390);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(71, 29);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            this.btnClose.Enter += new System.EventHandler(this.BtnClose_Enter);
            this.btnClose.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BtnClose_KeyDown);
            this.btnClose.Leave += new System.EventHandler(this.BtnClose_Leave);
            // 
            // grpVoucherSettings
            // 
            this.grpVoucherSettings.BackColor = System.Drawing.Color.White;
            this.grpVoucherSettings.Controls.Add(this.btnPreview);
            this.grpVoucherSettings.Controls.Add(this.btnAdd);
            this.grpVoucherSettings.Controls.Add(this.cmbTemplate);
            this.grpVoucherSettings.Controls.Add(this.lblTransactionType);
            this.grpVoucherSettings.Controls.Add(this.cmbBank);
            this.grpVoucherSettings.Controls.Add(this.lblDEConcern);
            this.grpVoucherSettings.Location = new System.Drawing.Point(13, 3);
            this.grpVoucherSettings.Name = "grpVoucherSettings";
            this.grpVoucherSettings.Size = new System.Drawing.Size(559, 71);
            this.grpVoucherSettings.TabIndex = 0;
            this.grpVoucherSettings.TabStop = false;
            this.grpVoucherSettings.Text = "Cheque Print Type";
            // 
            // btnPreview
            // 
            this.btnPreview.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnPreview.Image = global::ROMS.Properties.Resources.print;
            this.btnPreview.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPreview.Location = new System.Drawing.Point(392, 28);
            this.btnPreview.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(82, 29);
            this.btnPreview.TabIndex = 2;
            this.btnPreview.Text = "Preview";
            this.btnPreview.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.BtnPreview_Click);
            this.btnPreview.Enter += new System.EventHandler(this.BtnPreview_Enter);
            this.btnPreview.Leave += new System.EventHandler(this.BtnPreview_Leave);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnAdd.Image = global::ROMS.Properties.Resources.New;
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(480, 28);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(59, 29);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Add";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            this.btnAdd.Enter += new System.EventHandler(this.BtnAdd_Enter);
            this.btnAdd.Leave += new System.EventHandler(this.BtnAdd_Leave);
            // 
            // cmbTemplate
            // 
            this.cmbTemplate.FormattingEnabled = true;
            this.cmbTemplate.Location = new System.Drawing.Point(208, 28);
            this.cmbTemplate.Name = "cmbTemplate";
            this.cmbTemplate.Size = new System.Drawing.Size(178, 27);
            this.cmbTemplate.TabIndex = 1;
            this.cmbTemplate.Enter += new System.EventHandler(this.CmbTransactionType_Enter);
            this.cmbTemplate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbTransactionType_KeyDown);
            this.cmbTemplate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbTransactionType_KeyPress);
            this.cmbTemplate.Leave += new System.EventHandler(this.CmbTransactionType_Leave);
            // 
            // lblTransactionType
            // 
            this.lblTransactionType.AutoSize = true;
            this.lblTransactionType.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransactionType.Location = new System.Drawing.Point(144, 31);
            this.lblTransactionType.Name = "lblTransactionType";
            this.lblTransactionType.Size = new System.Drawing.Size(58, 20);
            this.lblTransactionType.TabIndex = 40;
            this.lblTransactionType.Text = "Template";
            // 
            // cmbBank
            // 
            this.cmbBank.FormattingEnabled = true;
            this.epSettings.SetIconPadding(this.cmbBank, 1);
            this.cmbBank.Location = new System.Drawing.Point(55, 28);
            this.cmbBank.Name = "cmbBank";
            this.cmbBank.Size = new System.Drawing.Size(83, 27);
            this.cmbBank.TabIndex = 0;
            this.cmbBank.SelectedIndexChanged += new System.EventHandler(this.CmbConcern_SelectedIndexChanged);
            this.cmbBank.Enter += new System.EventHandler(this.CmbConcern_Enter);
            this.cmbBank.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbConcern_KeyDown);
            this.cmbBank.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbConcern_KeyPress);
            this.cmbBank.Leave += new System.EventHandler(this.CmbConcern_Leave);
            // 
            // lblDEConcern
            // 
            this.lblDEConcern.AutoSize = true;
            this.lblDEConcern.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDEConcern.Location = new System.Drawing.Point(13, 31);
            this.lblDEConcern.Name = "lblDEConcern";
            this.lblDEConcern.Size = new System.Drawing.Size(36, 20);
            this.lblDEConcern.TabIndex = 35;
            this.lblDEConcern.Text = "Bank";
            // 
            // epSettings
            // 
            this.epSettings.ContainerControl = this;
            // 
            // tsChequePrintSettings
            // 
            this.tsChequePrintSettings.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tsChequePrintSettings.AutoSize = false;
            this.tsChequePrintSettings.BackColor = System.Drawing.Color.White;
            this.tsChequePrintSettings.Dock = System.Windows.Forms.DockStyle.None;
            this.tsChequePrintSettings.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsChequePrintSettings.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsChequePrintSettings.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspHeader});
            this.tsChequePrintSettings.Location = new System.Drawing.Point(138, 106);
            this.tsChequePrintSettings.Name = "tsChequePrintSettings";
            this.tsChequePrintSettings.Size = new System.Drawing.Size(1036, 25);
            this.tsChequePrintSettings.TabIndex = 958790;
            this.tsChequePrintSettings.Text = "Voucher Settings";
            // 
            // tspHeader
            // 
            this.tspHeader.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tspHeader.Image = global::ROMS.Properties.Resources.bread_crumb;
            this.tspHeader.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tspHeader.Margin = new System.Windows.Forms.Padding(15, 1, 0, 2);
            this.tspHeader.Name = "tspHeader";
            this.tspHeader.Size = new System.Drawing.Size(139, 22);
            this.tspHeader.Text = "Cheque Print Setting";
            // 
            // CP_ChequePrint_Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(1354, 675);
            this.Controls.Add(this.tsChequePrintSettings);
            this.Controls.Add(this.pnlSettings);
            this.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "CP_ChequePrint_Setting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cheque Print Setting";
            this.Load += new System.EventHandler(this.CP_Settings_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CP_Settings_KeyDown);
            this.Leave += new System.EventHandler(this.CP_Settings_Leave);
            this.pnlSettings.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbChequePreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdChequePrint)).EndInit();
            this.grpVoucherSettings.ResumeLayout(false);
            this.grpVoucherSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epSettings)).EndInit();
            this.tsChequePrintSettings.ResumeLayout(false);
            this.tsChequePrintSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlSettings;
        private System.Windows.Forms.GroupBox grpVoucherSettings;
        private System.Windows.Forms.Label lblDEConcern;
        private System.Windows.Forms.ComboBox cmbTemplate;
        private System.Windows.Forms.Label lblTransactionType;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ErrorProvider epSettings;
        public System.Windows.Forms.Button btnSave;
        public System.Windows.Forms.ComboBox cmbBank;
        private System.Windows.Forms.ToolStrip tsChequePrintSettings;
        private System.Windows.Forms.ToolStripLabel tspHeader;
        public System.Windows.Forms.Button btnAdd;
        public System.Windows.Forms.DataGridView grdChequePrint;
        public System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox pbChequePreview;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSno;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmBank;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTemplate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmImageName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmBankId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTemplateID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmID;
        private System.Windows.Forms.DataGridViewImageColumn clmPreview;
        private System.Windows.Forms.DataGridViewImageColumn clmRemove;
    }
}