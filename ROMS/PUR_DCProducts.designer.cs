namespace ROMS
{
    partial class PUR_DCProducts
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PUR_DCProducts));
            this.errUnit = new System.Windows.Forms.ErrorProvider(this.components);
            this.grdDC = new System.Windows.Forms.DataGridView();
            this.lblDCNo = new System.Windows.Forms.Label();
            this.lblDCDate = new System.Windows.Forms.Label();
            this.txtDCNo = new System.Windows.Forms.TextBox();
            this.txtDCDate = new System.Windows.Forms.TextBox();
            this.lblNoRecordsFound = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUserData = new System.Windows.Forms.TextBox();
            this.txtDCSts = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.clmsno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTotalitem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmUPP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STSID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmQtyUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.errUnit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDC)).BeginInit();
            this.SuspendLayout();
            // 
            // errUnit
            // 
            this.errUnit.ContainerControl = this;
            // 
            // grdDC
            // 
            this.grdDC.AllowUserToAddRows = false;
            this.grdDC.AllowUserToDeleteRows = false;
            this.grdDC.AllowUserToResizeColumns = false;
            this.grdDC.AllowUserToResizeRows = false;
            this.grdDC.BackgroundColor = System.Drawing.Color.White;
            this.grdDC.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdDC.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdDC.ColumnHeadersHeight = 30;
            this.grdDC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdDC.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmsno,
            this.clmdate,
            this.clmProductName,
            this.clmTotalitem,
            this.clmUPP,
            this.Column4,
            this.clmStatus,
            this.STSID,
            this.clmQtyUnit});
            this.grdDC.EnableHeadersVisualStyles = false;
            this.grdDC.GridColor = System.Drawing.Color.White;
            this.grdDC.Location = new System.Drawing.Point(12, 45);
            this.grdDC.Name = "grdDC";
            this.grdDC.ReadOnly = true;
            this.grdDC.RowHeadersVisible = false;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            this.grdDC.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.grdDC.RowTemplate.Height = 25;
            this.grdDC.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdDC.Size = new System.Drawing.Size(1051, 435);
            this.grdDC.TabIndex = 1111144;
            this.grdDC.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.GrdPurchaseOrder_DataBindingComplete);
            // 
            // lblDCNo
            // 
            this.lblDCNo.AutoSize = true;
            this.lblDCNo.Location = new System.Drawing.Point(12, 13);
            this.lblDCNo.Name = "lblDCNo";
            this.lblDCNo.Size = new System.Drawing.Size(45, 20);
            this.lblDCNo.TabIndex = 1111146;
            this.lblDCNo.Text = "DC No.";
            // 
            // lblDCDate
            // 
            this.lblDCDate.AutoSize = true;
            this.lblDCDate.Location = new System.Drawing.Point(168, 13);
            this.lblDCDate.Name = "lblDCDate";
            this.lblDCDate.Size = new System.Drawing.Size(53, 20);
            this.lblDCDate.TabIndex = 1111147;
            this.lblDCDate.Text = "DC Date";
            // 
            // txtDCNo
            // 
            this.txtDCNo.Enabled = false;
            this.txtDCNo.Location = new System.Drawing.Point(62, 9);
            this.txtDCNo.Name = "txtDCNo";
            this.txtDCNo.ReadOnly = true;
            this.txtDCNo.Size = new System.Drawing.Size(100, 28);
            this.txtDCNo.TabIndex = 1111148;
            // 
            // txtDCDate
            // 
            this.txtDCDate.Enabled = false;
            this.txtDCDate.Location = new System.Drawing.Point(226, 9);
            this.txtDCDate.Name = "txtDCDate";
            this.txtDCDate.ReadOnly = true;
            this.txtDCDate.Size = new System.Drawing.Size(100, 28);
            this.txtDCDate.TabIndex = 1111149;
            // 
            // lblNoRecordsFound
            // 
            this.lblNoRecordsFound.AutoSize = true;
            this.lblNoRecordsFound.BackColor = System.Drawing.Color.White;
            this.lblNoRecordsFound.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoRecordsFound.Location = new System.Drawing.Point(517, 252);
            this.lblNoRecordsFound.Name = "lblNoRecordsFound";
            this.lblNoRecordsFound.Size = new System.Drawing.Size(106, 20);
            this.lblNoRecordsFound.TabIndex = 1111150;
            this.lblNoRecordsFound.Text = "No Records Found";
            this.lblNoRecordsFound.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(332, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 20);
            this.label3.TabIndex = 1111151;
            this.label3.Text = "User";
            // 
            // txtUserData
            // 
            this.txtUserData.Enabled = false;
            this.txtUserData.Location = new System.Drawing.Point(372, 9);
            this.txtUserData.Name = "txtUserData";
            this.txtUserData.ReadOnly = true;
            this.txtUserData.Size = new System.Drawing.Size(420, 28);
            this.txtUserData.TabIndex = 1111152;
            // 
            // txtDCSts
            // 
            this.txtDCSts.Enabled = false;
            this.txtDCSts.Location = new System.Drawing.Point(868, 9);
            this.txtDCSts.Name = "txtDCSts";
            this.txtDCSts.ReadOnly = true;
            this.txtDCSts.Size = new System.Drawing.Size(195, 28);
            this.txtDCSts.TabIndex = 1111154;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(798, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 20);
            this.label4.TabIndex = 1111153;
            this.label4.Text = "DC Status";
            // 
            // clmsno
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.clmsno.DefaultCellStyle = dataGridViewCellStyle2;
            this.clmsno.HeaderText = "S.No.";
            this.clmsno.Name = "clmsno";
            this.clmsno.ReadOnly = true;
            this.clmsno.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmsno.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmsno.Width = 50;
            // 
            // clmdate
            // 
            this.clmdate.HeaderText = "PI Code";
            this.clmdate.Name = "clmdate";
            this.clmdate.ReadOnly = true;
            // 
            // clmProductName
            // 
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clmProductName.DefaultCellStyle = dataGridViewCellStyle3;
            this.clmProductName.HeaderText = "Product Name";
            this.clmProductName.Name = "clmProductName";
            this.clmProductName.ReadOnly = true;
            this.clmProductName.Width = 300;
            // 
            // clmTotalitem
            // 
            this.clmTotalitem.HeaderText = "Unit";
            this.clmTotalitem.Name = "clmTotalitem";
            this.clmTotalitem.ReadOnly = true;
            this.clmTotalitem.Width = 70;
            // 
            // clmUPP
            // 
            this.clmUPP.HeaderText = "UPP";
            this.clmUPP.Name = "clmUPP";
            this.clmUPP.ReadOnly = true;
            // 
            // Column4
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column4.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column4.HeaderText = "DC Qty";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // clmStatus
            // 
            this.clmStatus.HeaderText = "Status";
            this.clmStatus.Name = "clmStatus";
            this.clmStatus.ReadOnly = true;
            this.clmStatus.Width = 120;
            // 
            // STSID
            // 
            this.STSID.HeaderText = "STSID";
            this.STSID.Name = "STSID";
            this.STSID.ReadOnly = true;
            this.STSID.Visible = false;
            // 
            // clmQtyUnit
            // 
            this.clmQtyUnit.HeaderText = "Unit";
            this.clmQtyUnit.Name = "clmQtyUnit";
            this.clmQtyUnit.ReadOnly = true;
            this.clmQtyUnit.Visible = false;
            this.clmQtyUnit.Width = 70;
            // 
            // PUR_DCProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1073, 488);
            this.Controls.Add(this.txtDCSts);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtUserData);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblNoRecordsFound);
            this.Controls.Add(this.txtDCDate);
            this.Controls.Add(this.txtDCNo);
            this.Controls.Add(this.lblDCDate);
            this.Controls.Add(this.lblDCNo);
            this.Controls.Add(this.grdDC);
            this.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PUR_DCProducts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pending DC Products";
            this.Load += new System.EventHandler(this.PUR_POProducts_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PUR_POProducts_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.errUnit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDC)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ErrorProvider errUnit;
        public System.Windows.Forms.DataGridView grdDC;
        private System.Windows.Forms.TextBox txtDCDate;
        private System.Windows.Forms.TextBox txtDCNo;
        private System.Windows.Forms.Label lblDCDate;
        private System.Windows.Forms.Label lblDCNo;
        private System.Windows.Forms.Label lblNoRecordsFound;
        private System.Windows.Forms.TextBox txtUserData;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDCSts;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmsno;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTotalitem;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmUPP;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn STSID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmQtyUnit;
    }
}