namespace ROMS
{
    partial class CP_ProductHSN
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CP_ProductHSN));
            this.txtDHsnName = new System.Windows.Forms.TextBox();
            this.txtHSNName = new System.Windows.Forms.TextBox();
            this.txtDHsnCode = new System.Windows.Forms.TextBox();
            this.txtHSNCode = new System.Windows.Forms.TextBox();
            this.txtDSGT = new System.Windows.Forms.TextBox();
            this.grbform = new System.Windows.Forms.GroupBox();
            this.grdSupplierList = new System.Windows.Forms.DataGridView();
            this.clmsno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmhsncode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmgst = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmeffectivefrom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAdd = new System.Windows.Forms.Label();
            this.dptitle = new System.Windows.Forms.DateTimePicker();
            this.txtDeffectivedate = new System.Windows.Forms.TextBox();
            this.cmbGST = new System.Windows.Forms.ComboBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.errCompany = new System.Windows.Forms.ErrorProvider(this.components);
            this.panelStatus = new System.Windows.Forms.Panel();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.grbform.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSupplierList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errCompany)).BeginInit();
            this.panelStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtDHsnName
            // 
            this.txtDHsnName.BackColor = System.Drawing.SystemColors.Control;
            this.txtDHsnName.Enabled = false;
            this.txtDHsnName.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtDHsnName.Location = new System.Drawing.Point(23, 23);
            this.txtDHsnName.Name = "txtDHsnName";
            this.txtDHsnName.ReadOnly = true;
            this.txtDHsnName.Size = new System.Drawing.Size(101, 27);
            this.txtDHsnName.TabIndex = 14;
            this.txtDHsnName.Text = "HSN Group Name";
            // 
            // txtHSNName
            // 
            this.txtHSNName.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtHSNName.Location = new System.Drawing.Point(124, 23);
            this.txtHSNName.MaxLength = 100;
            this.txtHSNName.Name = "txtHSNName";
            this.txtHSNName.Size = new System.Drawing.Size(363, 27);
            this.txtHSNName.TabIndex = 0;
            this.txtHSNName.Enter += new System.EventHandler(this.txtCompanyName_Enter);
            this.txtHSNName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCompanyName_KeyDown);
            this.txtHSNName.Leave += new System.EventHandler(this.txtCompanyName_Leave);
            // 
            // txtDHsnCode
            // 
            this.txtDHsnCode.BackColor = System.Drawing.SystemColors.Control;
            this.txtDHsnCode.Enabled = false;
            this.txtDHsnCode.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtDHsnCode.Location = new System.Drawing.Point(23, 50);
            this.txtDHsnCode.Name = "txtDHsnCode";
            this.txtDHsnCode.ReadOnly = true;
            this.txtDHsnCode.Size = new System.Drawing.Size(101, 27);
            this.txtDHsnCode.TabIndex = 15;
            this.txtDHsnCode.Text = "HSN Code";
            // 
            // txtHSNCode
            // 
            this.txtHSNCode.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtHSNCode.Location = new System.Drawing.Point(124, 50);
            this.txtHSNCode.MaxLength = 10;
            this.txtHSNCode.Name = "txtHSNCode";
            this.txtHSNCode.Size = new System.Drawing.Size(162, 27);
            this.txtHSNCode.TabIndex = 1;
            this.txtHSNCode.Enter += new System.EventHandler(this.txtShortName_Enter);
            this.txtHSNCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtShortName_KeyDown);
            this.txtHSNCode.Leave += new System.EventHandler(this.txtShortName_Leave);
            // 
            // txtDSGT
            // 
            this.txtDSGT.BackColor = System.Drawing.SystemColors.Control;
            this.txtDSGT.Enabled = false;
            this.txtDSGT.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtDSGT.Location = new System.Drawing.Point(287, 50);
            this.txtDSGT.Name = "txtDSGT";
            this.txtDSGT.ReadOnly = true;
            this.txtDSGT.Size = new System.Drawing.Size(30, 27);
            this.txtDSGT.TabIndex = 16;
            this.txtDSGT.Text = "GST";
            // 
            // grbform
            // 
            this.grbform.Controls.Add(this.panelStatus);
            this.grbform.Controls.Add(this.grdSupplierList);
            this.grbform.Controls.Add(this.btnAdd);
            this.grbform.Controls.Add(this.dptitle);
            this.grbform.Controls.Add(this.txtDeffectivedate);
            this.grbform.Controls.Add(this.cmbGST);
            this.grbform.Controls.Add(this.textBox4);
            this.grbform.Controls.Add(this.btnSave);
            this.grbform.Controls.Add(this.btnClose);
            this.grbform.Controls.Add(this.txtDHsnName);
            this.grbform.Controls.Add(this.txtHSNName);
            this.grbform.Controls.Add(this.txtHSNCode);
            this.grbform.Controls.Add(this.txtDHsnCode);
            this.grbform.Controls.Add(this.txtDSGT);
            this.grbform.Location = new System.Drawing.Point(12, 12);
            this.grbform.Name = "grbform";
            this.grbform.Size = new System.Drawing.Size(713, 290);
            this.grbform.TabIndex = 0;
            this.grbform.TabStop = false;
            // 
            // grdSupplierList
            // 
            this.grdSupplierList.AllowUserToAddRows = false;
            this.grdSupplierList.AllowUserToDeleteRows = false;
            this.grdSupplierList.AllowUserToResizeColumns = false;
            this.grdSupplierList.AllowUserToResizeRows = false;
            this.grdSupplierList.BackgroundColor = System.Drawing.Color.White;
            this.grdSupplierList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(242)))), ((int)(((byte)(213)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdSupplierList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdSupplierList.ColumnHeadersHeight = 30;
            this.grdSupplierList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdSupplierList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmsno,
            this.clmhsncode,
            this.clmgst,
            this.clmeffectivefrom});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdSupplierList.DefaultCellStyle = dataGridViewCellStyle2;
            this.grdSupplierList.EnableHeadersVisualStyles = false;
            this.grdSupplierList.GridColor = System.Drawing.Color.White;
            this.grdSupplierList.Location = new System.Drawing.Point(23, 118);
            this.grdSupplierList.Name = "grdSupplierList";
            this.grdSupplierList.ReadOnly = true;
            this.grdSupplierList.RowHeadersVisible = false;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.grdSupplierList.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.grdSupplierList.RowTemplate.Height = 25;
            this.grdSupplierList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdSupplierList.Size = new System.Drawing.Size(647, 118);
            this.grdSupplierList.TabIndex = 1111137;
            // 
            // clmsno
            // 
            this.clmsno.HeaderText = "S.No.";
            this.clmsno.Name = "clmsno";
            this.clmsno.ReadOnly = true;
            this.clmsno.Width = 50;
            // 
            // clmhsncode
            // 
            this.clmhsncode.HeaderText = "HSN Code";
            this.clmhsncode.Name = "clmhsncode";
            this.clmhsncode.ReadOnly = true;
            this.clmhsncode.Width = 200;
            // 
            // clmgst
            // 
            this.clmgst.HeaderText = "GST";
            this.clmgst.Name = "clmgst";
            this.clmgst.ReadOnly = true;
            this.clmgst.Width = 175;
            // 
            // clmeffectivefrom
            // 
            this.clmeffectivefrom.HeaderText = "Effective From";
            this.clmeffectivefrom.Name = "clmeffectivefrom";
            this.clmeffectivefrom.ReadOnly = true;
            this.clmeffectivefrom.Width = 200;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.SystemColors.Control;
            this.btnAdd.Image = global::ROMS.Properties.Resources.plus;
            this.btnAdd.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAdd.Location = new System.Drawing.Point(643, 50);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(27, 27);
            this.btnAdd.TabIndex = 1111136;
            this.btnAdd.Text = "        ";
            // 
            // dptitle
            // 
            this.dptitle.CustomFormat = "dd/MM/yyyy";
            this.dptitle.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dptitle.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dptitle.Location = new System.Drawing.Point(518, 49);
            this.dptitle.Name = "dptitle";
            this.dptitle.Size = new System.Drawing.Size(122, 28);
            this.dptitle.TabIndex = 69;
            this.dptitle.Value = new System.DateTime(2022, 9, 26, 0, 0, 0, 0);
            // 
            // txtDeffectivedate
            // 
            this.txtDeffectivedate.BackColor = System.Drawing.SystemColors.Control;
            this.txtDeffectivedate.Enabled = false;
            this.txtDeffectivedate.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtDeffectivedate.Location = new System.Drawing.Point(436, 50);
            this.txtDeffectivedate.Name = "txtDeffectivedate";
            this.txtDeffectivedate.ReadOnly = true;
            this.txtDeffectivedate.Size = new System.Drawing.Size(82, 27);
            this.txtDeffectivedate.TabIndex = 68;
            this.txtDeffectivedate.Text = "Effective From";
            // 
            // cmbGST
            // 
            this.cmbGST.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGST.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbGST.FormattingEnabled = true;
            this.cmbGST.Location = new System.Drawing.Point(317, 50);
            this.cmbGST.Name = "cmbGST";
            this.cmbGST.Size = new System.Drawing.Size(118, 27);
            this.cmbGST.TabIndex = 62;
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.SystemColors.Control;
            this.textBox4.Enabled = false;
            this.textBox4.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.textBox4.Location = new System.Drawing.Point(23, 77);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(101, 27);
            this.textBox4.TabIndex = 56;
            this.textBox4.Text = "Status";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnSave.Image = global::ROMS.Properties.Resources.save;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(507, 246);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(84, 29);
            this.btnSave.TabIndex = 25;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.Enter += new System.EventHandler(this.btnSave_Enter);
            this.btnSave.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnSave_KeyDown);
            this.btnSave.Leave += new System.EventHandler(this.btnSave_Leave);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnClose.Image = global::ROMS.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(595, 246);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 29);
            this.btnClose.TabIndex = 26;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            this.btnClose.Enter += new System.EventHandler(this.btnClose_Enter);
            this.btnClose.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnClose_KeyDown);
            this.btnClose.Leave += new System.EventHandler(this.btnClose_Leave);
            // 
            // errCompany
            // 
            this.errCompany.ContainerControl = this;
            // 
            // panelStatus
            // 
            this.panelStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelStatus.Controls.Add(this.radioButton1);
            this.panelStatus.Controls.Add(this.radioButton2);
            this.panelStatus.Enabled = false;
            this.panelStatus.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelStatus.Location = new System.Drawing.Point(124, 77);
            this.panelStatus.Name = "panelStatus";
            this.panelStatus.Size = new System.Drawing.Size(363, 27);
            this.panelStatus.TabIndex = 1111138;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Font = new System.Drawing.Font("Oswald Regular", 9.75F);
            this.radioButton1.Location = new System.Drawing.Point(162, 1);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(63, 21);
            this.radioButton1.TabIndex = 7;
            this.radioButton1.Text = "Inactive";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Checked = true;
            this.radioButton2.Font = new System.Drawing.Font("Oswald Regular", 9.75F);
            this.radioButton2.Location = new System.Drawing.Point(53, 1);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(54, 21);
            this.radioButton2.TabIndex = 6;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Active";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // CP_ProductHSN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(738, 322);
            this.Controls.Add(this.grbform);
            this.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CP_ProductHSN";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HSN Tax Group Details";
            this.Load += new System.EventHandler(this.CP_Company_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CP_Company_KeyDown);
            this.Leave += new System.EventHandler(this.CP_Company_Leave);
            this.grbform.ResumeLayout(false);
            this.grbform.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSupplierList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errCompany)).EndInit();
            this.panelStatus.ResumeLayout(false);
            this.panelStatus.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtDHsnName;
        private System.Windows.Forms.TextBox txtHSNName;
        private System.Windows.Forms.TextBox txtDHsnCode;
        private System.Windows.Forms.TextBox txtHSNCode;
        private System.Windows.Forms.TextBox txtDSGT;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox grbform;
        private System.Windows.Forms.ErrorProvider errCompany;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.ComboBox cmbGST;
        private System.Windows.Forms.DateTimePicker dptitle;
        private System.Windows.Forms.TextBox txtDeffectivedate;
        internal System.Windows.Forms.Label btnAdd;
        public System.Windows.Forms.DataGridView grdSupplierList;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmsno;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmhsncode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmgst;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmeffectivefrom;
        private System.Windows.Forms.Panel panelStatus;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
    }
}