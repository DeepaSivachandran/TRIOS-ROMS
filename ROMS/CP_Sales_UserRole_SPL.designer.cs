namespace ROMS
{
    partial class CP_Sales_UserRole_SPL
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CP_Sales_UserRole_SPL));
            this.epCity = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblNoRecordsFound = new System.Windows.Forms.Label();
            this.grdSalesUserSPLPermission = new System.Windows.Forms.DataGridView();
            this.clmsno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmFieldName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmViewchk = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clmEditchk = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clmMenuId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmFieldId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSURSF_Access_Level = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPrivilagecode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblMenuLink = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.epCity)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSalesUserSPLPermission)).BeginInit();
            this.SuspendLayout();
            // 
            // epCity
            // 
            this.epCity.ContainerControl = this;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblNoRecordsFound);
            this.groupBox2.Controls.Add(this.grdSalesUserSPLPermission);
            this.groupBox2.Location = new System.Drawing.Point(20, 25);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(761, 298);
            this.groupBox2.TabIndex = 1111184;
            this.groupBox2.TabStop = false;
            // 
            // lblNoRecordsFound
            // 
            this.lblNoRecordsFound.AutoSize = true;
            this.lblNoRecordsFound.BackColor = System.Drawing.Color.White;
            this.lblNoRecordsFound.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoRecordsFound.Location = new System.Drawing.Point(327, 143);
            this.lblNoRecordsFound.Name = "lblNoRecordsFound";
            this.lblNoRecordsFound.Size = new System.Drawing.Size(106, 20);
            this.lblNoRecordsFound.TabIndex = 958799;
            this.lblNoRecordsFound.Text = "No Records Found";
            this.lblNoRecordsFound.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // grdSalesUserSPLPermission
            // 
            this.grdSalesUserSPLPermission.AllowUserToAddRows = false;
            this.grdSalesUserSPLPermission.AllowUserToDeleteRows = false;
            this.grdSalesUserSPLPermission.AllowUserToResizeRows = false;
            this.grdSalesUserSPLPermission.BackgroundColor = System.Drawing.Color.White;
            this.grdSalesUserSPLPermission.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdSalesUserSPLPermission.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdSalesUserSPLPermission.ColumnHeadersHeight = 30;
            this.grdSalesUserSPLPermission.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdSalesUserSPLPermission.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmsno,
            this.clmFieldName,
            this.clmViewchk,
            this.clmEditchk,
            this.clmMenuId,
            this.clmFieldId,
            this.clmSURSF_Access_Level,
            this.clmPrivilagecode});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdSalesUserSPLPermission.DefaultCellStyle = dataGridViewCellStyle3;
            this.grdSalesUserSPLPermission.EnableHeadersVisualStyles = false;
            this.grdSalesUserSPLPermission.GridColor = System.Drawing.Color.White;
            this.grdSalesUserSPLPermission.Location = new System.Drawing.Point(6, 18);
            this.grdSalesUserSPLPermission.Name = "grdSalesUserSPLPermission";
            this.grdSalesUserSPLPermission.RowHeadersVisible = false;
            this.grdSalesUserSPLPermission.RowHeadersWidth = 51;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.grdSalesUserSPLPermission.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.grdSalesUserSPLPermission.RowTemplate.Height = 25;
            this.grdSalesUserSPLPermission.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.grdSalesUserSPLPermission.ShowRowErrors = false;
            this.grdSalesUserSPLPermission.Size = new System.Drawing.Size(748, 270);
            this.grdSalesUserSPLPermission.TabIndex = 3;
            this.grdSalesUserSPLPermission.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.grdUserSPLPermission_CellFormatting);
            this.grdSalesUserSPLPermission.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdUserSPLPermission_CellValueChanged);
            this.grdSalesUserSPLPermission.CurrentCellDirtyStateChanged += new System.EventHandler(this.grdUserSPLPermission_CurrentCellDirtyStateChanged);
            this.grdSalesUserSPLPermission.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.grdUserSPLPermission_DataBindingComplete);
            // 
            // clmsno
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clmsno.DefaultCellStyle = dataGridViewCellStyle2;
            this.clmsno.HeaderText = "S.No.";
            this.clmsno.Name = "clmsno";
            this.clmsno.Width = 70;
            // 
            // clmFieldName
            // 
            this.clmFieldName.HeaderText = "Field Name";
            this.clmFieldName.Name = "clmFieldName";
            this.clmFieldName.ReadOnly = true;
            this.clmFieldName.Width = 400;
            // 
            // clmViewchk
            // 
            this.clmViewchk.HeaderText = "View/Enable";
            this.clmViewchk.Name = "clmViewchk";
            this.clmViewchk.Width = 150;
            // 
            // clmEditchk
            // 
            this.clmEditchk.HeaderText = "Modify";
            this.clmEditchk.Name = "clmEditchk";
            // 
            // clmMenuId
            // 
            this.clmMenuId.HeaderText = "MenuId";
            this.clmMenuId.Name = "clmMenuId";
            this.clmMenuId.Visible = false;
            // 
            // clmFieldId
            // 
            this.clmFieldId.HeaderText = "FieldId";
            this.clmFieldId.Name = "clmFieldId";
            this.clmFieldId.Visible = false;
            // 
            // clmSURSF_Access_Level
            // 
            this.clmSURSF_Access_Level.HeaderText = "Access_Level";
            this.clmSURSF_Access_Level.Name = "clmSURSF_Access_Level";
            this.clmSURSF_Access_Level.Visible = false;
            // 
            // clmPrivilagecode
            // 
            this.clmPrivilagecode.HeaderText = "clmPrivilagecode";
            this.clmPrivilagecode.Name = "clmPrivilagecode";
            this.clmPrivilagecode.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnSave.Image = global::ROMS.Properties.Resources.save;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(618, 329);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(78, 29);
            this.btnSave.TabIndex = 1111185;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnClose.Image = global::ROMS.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(703, 329);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(78, 29);
            this.btnClose.TabIndex = 1111186;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblMenuLink
            // 
            this.lblMenuLink.AutoSize = true;
            this.lblMenuLink.Location = new System.Drawing.Point(20, 9);
            this.lblMenuLink.Name = "lblMenuLink";
            this.lblMenuLink.Size = new System.Drawing.Size(101, 20);
            this.lblMenuLink.TabIndex = 1111187;
            this.lblMenuLink.Text = "Master - Product";
            // 
            // CP_Sales_UserRole_SPL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(800, 368);
            this.Controls.Add(this.lblMenuLink);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CP_Sales_UserRole_SPL";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sales User Special Permission";
            this.Load += new System.EventHandler(this.CP_Sales_UserRole_SPL_Load);
            ((System.ComponentModel.ISupportInitialize)(this.epCity)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSalesUserSPLPermission)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ErrorProvider epCity;
        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.DataGridView grdSalesUserSPLPermission;
        public System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblMenuLink;
        private System.Windows.Forms.Label lblNoRecordsFound;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmsno;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmFieldName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clmViewchk;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clmEditchk;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmMenuId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmFieldId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSURSF_Access_Level;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPrivilagecode;
    }
}