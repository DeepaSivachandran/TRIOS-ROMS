namespace ROMS
{
    partial class PUR_PurchaseApprovalList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tsBrandList = new System.Windows.Forms.ToolStrip();
            this.tspHeader = new System.Windows.Forms.ToolStripLabel();
            this.pnlpurchaseapproval = new System.Windows.Forms.Panel();
            this.grpfilter = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbSupplier = new System.Windows.Forms.ComboBox();
            this.dpPlanDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.DGV_SearchGrid = new System.Windows.Forms.DataGridView();
            this.clmdsno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmddate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmdpurchasenumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmdpono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmdsupplier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmdinward = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmdinwarddate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmdbillamt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmdtotalitem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmdtotalqty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmdstatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmdenterby = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmdapprovedby = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grdPurchaseApproval = new System.Windows.Forms.DataGridView();
            this.clmsno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmpurchaseno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmpono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmsupplier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clminwardno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clminwarddate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmbill = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmtotalitem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmtotalqty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmsts = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmenterby = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmapproved = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmview = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tsBrandList.SuspendLayout();
            this.pnlpurchaseapproval.SuspendLayout();
            this.grpfilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_SearchGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPurchaseApproval)).BeginInit();
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
            this.tspHeader.Size = new System.Drawing.Size(125, 22);
            this.tspHeader.Text = "Purchase Approval";
            // 
            // pnlpurchaseapproval
            // 
            this.pnlpurchaseapproval.BackColor = System.Drawing.Color.White;
            this.pnlpurchaseapproval.Controls.Add(this.grpfilter);
            this.pnlpurchaseapproval.Controls.Add(this.DGV_SearchGrid);
            this.pnlpurchaseapproval.Controls.Add(this.grdPurchaseApproval);
            this.pnlpurchaseapproval.Location = new System.Drawing.Point(0, 29);
            this.pnlpurchaseapproval.Name = "pnlpurchaseapproval";
            this.pnlpurchaseapproval.Size = new System.Drawing.Size(1354, 646);
            this.pnlpurchaseapproval.TabIndex = 958789;
            // 
            // grpfilter
            // 
            this.grpfilter.Controls.Add(this.button1);
            this.grpfilter.Controls.Add(this.btnView);
            this.grpfilter.Controls.Add(this.label2);
            this.grpfilter.Controls.Add(this.cmbSupplier);
            this.grpfilter.Controls.Add(this.dpPlanDate);
            this.grpfilter.Controls.Add(this.label1);
            this.grpfilter.Location = new System.Drawing.Point(3, 2);
            this.grpfilter.Name = "grpfilter";
            this.grpfilter.Size = new System.Drawing.Size(1329, 67);
            this.grpfilter.TabIndex = 958799;
            this.grpfilter.TabStop = false;
            this.grpfilter.Text = "Filter By";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::ROMS.Properties.Resources.view;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(746, 26);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(74, 33);
            this.button1.TabIndex = 1111142;
            this.button1.Text = "new";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // btnView
            // 
            this.btnView.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnView.Image = global::ROMS.Properties.Resources.view;
            this.btnView.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnView.Location = new System.Drawing.Point(582, 26);
            this.btnView.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(74, 33);
            this.btnView.TabIndex = 1111141;
            this.btnView.Text = "View";
            this.btnView.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnView.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(181, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 20);
            this.label2.TabIndex = 1111140;
            this.label2.Text = "Supplier Name";
            // 
            // cmbSupplier
            // 
            this.cmbSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSupplier.FormattingEnabled = true;
            this.cmbSupplier.Location = new System.Drawing.Point(285, 29);
            this.cmbSupplier.Name = "cmbSupplier";
            this.cmbSupplier.Size = new System.Drawing.Size(280, 27);
            this.cmbSupplier.TabIndex = 1111137;
            // 
            // dpPlanDate
            // 
            this.dpPlanDate.CustomFormat = "dd/MM/yyyy";
            this.dpPlanDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpPlanDate.Location = new System.Drawing.Point(57, 29);
            this.dpPlanDate.Name = "dpPlanDate";
            this.dpPlanDate.Size = new System.Drawing.Size(107, 27);
            this.dpPlanDate.TabIndex = 1111138;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 20);
            this.label1.TabIndex = 1111139;
            this.label1.Text = "Date";
            // 
            // DGV_SearchGrid
            // 
            this.DGV_SearchGrid.AllowUserToAddRows = false;
            this.DGV_SearchGrid.AllowUserToDeleteRows = false;
            this.DGV_SearchGrid.AllowUserToResizeRows = false;
            this.DGV_SearchGrid.BackgroundColor = System.Drawing.Color.White;
            this.DGV_SearchGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle19.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle19.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(242)))), ((int)(((byte)(213)))));
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_SearchGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle19;
            this.DGV_SearchGrid.ColumnHeadersHeight = 30;
            this.DGV_SearchGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGV_SearchGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmdsno,
            this.clmddate,
            this.clmdpurchasenumber,
            this.clmdpono,
            this.clmdsupplier,
            this.clmdinward,
            this.clmdinwarddate,
            this.clmdbillamt,
            this.clmdtotalitem,
            this.clmdtotalqty,
            this.clmdstatus,
            this.clmdenterby,
            this.clmdapprovedby});
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle20.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV_SearchGrid.DefaultCellStyle = dataGridViewCellStyle20;
            this.DGV_SearchGrid.EnableHeadersVisualStyles = false;
            this.DGV_SearchGrid.GridColor = System.Drawing.Color.White;
            this.DGV_SearchGrid.Location = new System.Drawing.Point(3, 74);
            this.DGV_SearchGrid.Name = "DGV_SearchGrid";
            this.DGV_SearchGrid.RowHeadersVisible = false;
            this.DGV_SearchGrid.RowHeadersWidth = 70;
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle21.SelectionForeColor = System.Drawing.Color.Black;
            this.DGV_SearchGrid.RowsDefaultCellStyle = dataGridViewCellStyle21;
            this.DGV_SearchGrid.RowTemplate.Height = 25;
            this.DGV_SearchGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DGV_SearchGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DGV_SearchGrid.ShowRowErrors = false;
            this.DGV_SearchGrid.Size = new System.Drawing.Size(1348, 56);
            this.DGV_SearchGrid.TabIndex = 958798;
            // 
            // clmdsno
            // 
            this.clmdsno.HeaderText = "S.No.";
            this.clmdsno.MinimumWidth = 6;
            this.clmdsno.Name = "clmdsno";
            this.clmdsno.Width = 75;
            // 
            // clmddate
            // 
            this.clmddate.HeaderText = "Date";
            this.clmddate.MinimumWidth = 6;
            this.clmddate.Name = "clmddate";
            // 
            // clmdpurchasenumber
            // 
            this.clmdpurchasenumber.HeaderText = "Purchase Number";
            this.clmdpurchasenumber.MinimumWidth = 6;
            this.clmdpurchasenumber.Name = "clmdpurchasenumber";
            this.clmdpurchasenumber.Width = 120;
            // 
            // clmdpono
            // 
            this.clmdpono.HeaderText = "Po.No.";
            this.clmdpono.MinimumWidth = 6;
            this.clmdpono.Name = "clmdpono";
            // 
            // clmdsupplier
            // 
            this.clmdsupplier.HeaderText = "Supplier Name";
            this.clmdsupplier.Name = "clmdsupplier";
            this.clmdsupplier.ReadOnly = true;
            this.clmdsupplier.Width = 200;
            // 
            // clmdinward
            // 
            this.clmdinward.HeaderText = "Inward No.";
            this.clmdinward.Name = "clmdinward";
            this.clmdinward.ReadOnly = true;
            // 
            // clmdinwarddate
            // 
            this.clmdinwarddate.HeaderText = "Inward Date";
            this.clmdinwarddate.Name = "clmdinwarddate";
            this.clmdinwarddate.ReadOnly = true;
            // 
            // clmdbillamt
            // 
            this.clmdbillamt.HeaderText = "Bill Amount";
            this.clmdbillamt.Name = "clmdbillamt";
            this.clmdbillamt.ReadOnly = true;
            // 
            // clmdtotalitem
            // 
            this.clmdtotalitem.HeaderText = "Total Item";
            this.clmdtotalitem.Name = "clmdtotalitem";
            this.clmdtotalitem.ReadOnly = true;
            // 
            // clmdtotalqty
            // 
            this.clmdtotalqty.HeaderText = "Total Qty";
            this.clmdtotalqty.Name = "clmdtotalqty";
            this.clmdtotalqty.ReadOnly = true;
            // 
            // clmdstatus
            // 
            this.clmdstatus.HeaderText = "Status";
            this.clmdstatus.Name = "clmdstatus";
            this.clmdstatus.ReadOnly = true;
            // 
            // clmdenterby
            // 
            this.clmdenterby.HeaderText = "Enter By";
            this.clmdenterby.Name = "clmdenterby";
            this.clmdenterby.ReadOnly = true;
            this.clmdenterby.Width = 150;
            // 
            // clmdapprovedby
            // 
            this.clmdapprovedby.HeaderText = "Approved By";
            this.clmdapprovedby.Name = "clmdapprovedby";
            this.clmdapprovedby.ReadOnly = true;
            this.clmdapprovedby.Width = 150;
            // 
            // grdPurchaseApproval
            // 
            this.grdPurchaseApproval.AllowUserToAddRows = false;
            this.grdPurchaseApproval.AllowUserToDeleteRows = false;
            this.grdPurchaseApproval.AllowUserToResizeColumns = false;
            this.grdPurchaseApproval.AllowUserToResizeRows = false;
            this.grdPurchaseApproval.BackgroundColor = System.Drawing.Color.White;
            this.grdPurchaseApproval.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle22.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle22.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle22.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle22.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(242)))), ((int)(((byte)(213)))));
            dataGridViewCellStyle22.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdPurchaseApproval.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle22;
            this.grdPurchaseApproval.ColumnHeadersHeight = 30;
            this.grdPurchaseApproval.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdPurchaseApproval.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmsno,
            this.clmdate,
            this.clmpurchaseno,
            this.clmpono,
            this.clmsupplier,
            this.clminwardno,
            this.clminwarddate,
            this.clmbill,
            this.clmtotalitem,
            this.clmtotalqty,
            this.clmsts,
            this.clmenterby,
            this.clmapproved,
            this.clmview});
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle23.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle23.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle23.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle23.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdPurchaseApproval.DefaultCellStyle = dataGridViewCellStyle23;
            this.grdPurchaseApproval.EnableHeadersVisualStyles = false;
            this.grdPurchaseApproval.GridColor = System.Drawing.Color.White;
            this.grdPurchaseApproval.Location = new System.Drawing.Point(3, 130);
            this.grdPurchaseApproval.Name = "grdPurchaseApproval";
            this.grdPurchaseApproval.ReadOnly = true;
            this.grdPurchaseApproval.RowHeadersVisible = false;
            this.grdPurchaseApproval.RowHeadersWidth = 100;
            dataGridViewCellStyle24.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle24.SelectionForeColor = System.Drawing.Color.White;
            this.grdPurchaseApproval.RowsDefaultCellStyle = dataGridViewCellStyle24;
            this.grdPurchaseApproval.RowTemplate.Height = 25;
            this.grdPurchaseApproval.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdPurchaseApproval.Size = new System.Drawing.Size(1348, 510);
            this.grdPurchaseApproval.TabIndex = 958797;
            // 
            // clmsno
            // 
            this.clmsno.HeaderText = "S.No.";
            this.clmsno.MinimumWidth = 6;
            this.clmsno.Name = "clmsno";
            this.clmsno.ReadOnly = true;
            this.clmsno.Width = 75;
            // 
            // clmdate
            // 
            this.clmdate.HeaderText = "Date";
            this.clmdate.MinimumWidth = 6;
            this.clmdate.Name = "clmdate";
            this.clmdate.ReadOnly = true;
            // 
            // clmpurchaseno
            // 
            this.clmpurchaseno.HeaderText = "Purchase Number";
            this.clmpurchaseno.MinimumWidth = 6;
            this.clmpurchaseno.Name = "clmpurchaseno";
            this.clmpurchaseno.ReadOnly = true;
            this.clmpurchaseno.Width = 120;
            // 
            // clmpono
            // 
            this.clmpono.HeaderText = "Po.No.";
            this.clmpono.MinimumWidth = 6;
            this.clmpono.Name = "clmpono";
            this.clmpono.ReadOnly = true;
            // 
            // clmsupplier
            // 
            this.clmsupplier.HeaderText = "Supplier Name";
            this.clmsupplier.Name = "clmsupplier";
            this.clmsupplier.ReadOnly = true;
            this.clmsupplier.Width = 200;
            // 
            // clminwardno
            // 
            this.clminwardno.HeaderText = "Inward No.";
            this.clminwardno.Name = "clminwardno";
            this.clminwardno.ReadOnly = true;
            // 
            // clminwarddate
            // 
            this.clminwarddate.HeaderText = "Inward Date";
            this.clminwarddate.Name = "clminwarddate";
            this.clminwarddate.ReadOnly = true;
            // 
            // clmbill
            // 
            this.clmbill.HeaderText = "Bill Amount";
            this.clmbill.Name = "clmbill";
            this.clmbill.ReadOnly = true;
            // 
            // clmtotalitem
            // 
            this.clmtotalitem.HeaderText = "Total Item";
            this.clmtotalitem.Name = "clmtotalitem";
            this.clmtotalitem.ReadOnly = true;
            // 
            // clmtotalqty
            // 
            this.clmtotalqty.HeaderText = "Total Qty";
            this.clmtotalqty.Name = "clmtotalqty";
            this.clmtotalqty.ReadOnly = true;
            // 
            // clmsts
            // 
            this.clmsts.HeaderText = "Status";
            this.clmsts.Name = "clmsts";
            this.clmsts.ReadOnly = true;
            // 
            // clmenterby
            // 
            this.clmenterby.HeaderText = "Enter By";
            this.clmenterby.Name = "clmenterby";
            this.clmenterby.ReadOnly = true;
            this.clmenterby.Width = 150;
            // 
            // clmapproved
            // 
            this.clmapproved.HeaderText = "Approved By";
            this.clmapproved.Name = "clmapproved";
            this.clmapproved.ReadOnly = true;
            this.clmapproved.Width = 150;
            // 
            // clmview
            // 
            this.clmview.HeaderText = "View";
            this.clmview.Name = "clmview";
            this.clmview.ReadOnly = true;
            this.clmview.Width = 50;
            // 
            // PUR_PurchaseApprovalList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(1354, 675);
            this.Controls.Add(this.pnlpurchaseapproval);
            this.Controls.Add(this.tsBrandList);
            this.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "PUR_PurchaseApprovalList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Brand";
            this.tsBrandList.ResumeLayout(false);
            this.tsBrandList.PerformLayout();
            this.pnlpurchaseapproval.ResumeLayout(false);
            this.grpfilter.ResumeLayout(false);
            this.grpfilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_SearchGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPurchaseApproval)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsBrandList;
        private System.Windows.Forms.ToolStripLabel tspHeader;
        private System.Windows.Forms.Panel pnlpurchaseapproval;
        public System.Windows.Forms.DataGridView DGV_SearchGrid;
        public System.Windows.Forms.DataGridView grdPurchaseApproval;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmdsno;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmddate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmdpurchasenumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmdpono;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmdsupplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmdinward;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmdinwarddate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmdbillamt;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmdtotalitem;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmdtotalqty;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmdstatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmdenterby;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmdapprovedby;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmsno;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmpurchaseno;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmpono;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmsupplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn clminwardno;
        private System.Windows.Forms.DataGridViewTextBoxColumn clminwarddate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmbill;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmtotalitem;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmtotalqty;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmsts;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmenterby;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmapproved;
        private System.Windows.Forms.DataGridViewButtonColumn clmview;
        private System.Windows.Forms.GroupBox grpfilter;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox cmbSupplier;
        private System.Windows.Forms.DateTimePicker dpPlanDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button button1;
    }
}