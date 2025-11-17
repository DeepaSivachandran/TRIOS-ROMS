namespace ROMS
{
    partial class INV_Inwardlist
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tsInwardList = new System.Windows.Forms.ToolStrip();
            this.tspHeader = new System.Windows.Forms.ToolStripLabel();
            this.tss = new System.Windows.Forms.ToolStripSeparator();
            this.tsTotalQueue = new System.Windows.Forms.ToolStripButton();
            this.tsbQue = new System.Windows.Forms.ToolStripButton();
            this.tssDelete = new System.Windows.Forms.ToolStripSeparator();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.tssEdit = new System.Windows.Forms.ToolStripSeparator();
            this.tsbEdit = new System.Windows.Forms.ToolStripButton();
            this.tssNew = new System.Windows.Forms.ToolStripSeparator();
            this.tsbNew = new System.Windows.Forms.ToolStripButton();
            this.pnlinward = new System.Windows.Forms.Panel();
            this.DGV_FilterLocation = new System.Windows.Forms.DataGridView();
            this.DGV_FilterProduct = new System.Windows.Forms.DataGridView();
            this.grbFilterBy = new System.Windows.Forms.GroupBox();
            this.lblQueueCount = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.txtStockLocation = new System.Windows.Forms.TextBox();
            this.cmbConcern = new System.Windows.Forms.ComboBox();
            this.dpToDate = new System.Windows.Forms.DateTimePicker();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.lblDProductNamePicode = new System.Windows.Forms.Label();
            this.dpFromDate = new System.Windows.Forms.DateTimePicker();
            this.lblDGodown = new System.Windows.Forms.Label();
            this.lblinwarddate = new System.Windows.Forms.Label();
            this.lblDConcern = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.lblNoRecordsFound = new System.Windows.Forms.Label();
            this.grdInwardList = new System.Windows.Forms.DataGridView();
            this.DGV_SearchGrid = new System.Windows.Forms.DataGridView();
            this.picLoader = new System.Windows.Forms.PictureBox();
            this.clmPrint = new System.Windows.Forms.DataGridViewImageColumn();
            this.clmStickerPrint = new System.Windows.Forms.DataGridViewImageColumn();
            this.tsInwardList.SuspendLayout();
            this.pnlinward.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_FilterLocation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_FilterProduct)).BeginInit();
            this.grbFilterBy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdInwardList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_SearchGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).BeginInit();
            this.SuspendLayout();
            // 
            // tsInwardList
            // 
            this.tsInwardList.BackColor = System.Drawing.Color.White;
            this.tsInwardList.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsInwardList.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsInwardList.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsInwardList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspHeader,
            this.tss,
            this.tsTotalQueue,
            this.tsbQue,
            this.tssDelete,
            this.tsbDelete,
            this.tssEdit,
            this.tsbEdit,
            this.tssNew,
            this.tsbNew});
            this.tsInwardList.Location = new System.Drawing.Point(0, 0);
            this.tsInwardList.Name = "tsInwardList";
            this.tsInwardList.Size = new System.Drawing.Size(1354, 27);
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
            this.tspHeader.Size = new System.Drawing.Size(169, 24);
            this.tspHeader.Text = "Goods Inward From Others";
            // 
            // tss
            // 
            this.tss.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tss.Margin = new System.Windows.Forms.Padding(0, 1, 2, 2);
            this.tss.Name = "tss";
            this.tss.Size = new System.Drawing.Size(6, 24);
            // 
            // tsTotalQueue
            // 
            this.tsTotalQueue.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsTotalQueue.Enabled = false;
            this.tsTotalQueue.ForeColor = System.Drawing.Color.DarkGreen;
            this.tsTotalQueue.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsTotalQueue.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsTotalQueue.Margin = new System.Windows.Forms.Padding(0, 1, 2, 2);
            this.tsTotalQueue.Name = "tsTotalQueue";
            this.tsTotalQueue.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tsTotalQueue.Size = new System.Drawing.Size(23, 24);
            this.tsTotalQueue.Text = "0";
            // 
            // tsbQue
            // 
            this.tsbQue.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbQue.Image = global::ROMS.Properties.Resources.queue;
            this.tsbQue.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbQue.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbQue.Margin = new System.Windows.Forms.Padding(0, 1, 2, 2);
            this.tsbQue.Name = "tsbQue";
            this.tsbQue.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tsbQue.Size = new System.Drawing.Size(63, 24);
            this.tsbQue.Text = "Queue";
            this.tsbQue.Click += new System.EventHandler(this.TsbQue_Click);
            // 
            // tssDelete
            // 
            this.tssDelete.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tssDelete.Margin = new System.Windows.Forms.Padding(0, 1, 2, 2);
            this.tssDelete.Name = "tssDelete";
            this.tssDelete.Size = new System.Drawing.Size(6, 24);
            // 
            // tsbDelete
            // 
            this.tsbDelete.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbDelete.Image = global::ROMS.Properties.Resources.Delete;
            this.tsbDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDelete.Margin = new System.Windows.Forms.Padding(0, 1, 2, 2);
            this.tsbDelete.Name = "tsbDelete";
            this.tsbDelete.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tsbDelete.Size = new System.Drawing.Size(63, 24);
            this.tsbDelete.Text = "Delete";
            this.tsbDelete.Click += new System.EventHandler(this.TsbDelete_Click);
            // 
            // tssEdit
            // 
            this.tssEdit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tssEdit.Margin = new System.Windows.Forms.Padding(0, 1, 2, 2);
            this.tssEdit.Name = "tssEdit";
            this.tssEdit.Size = new System.Drawing.Size(6, 24);
            // 
            // tsbEdit
            // 
            this.tsbEdit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbEdit.Image = global::ROMS.Properties.Resources.Edit;
            this.tsbEdit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEdit.Margin = new System.Windows.Forms.Padding(0, 1, 2, 2);
            this.tsbEdit.Name = "tsbEdit";
            this.tsbEdit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tsbEdit.Size = new System.Drawing.Size(50, 24);
            this.tsbEdit.Text = "&Edit";
            this.tsbEdit.Click += new System.EventHandler(this.tsbEdit_Click);
            // 
            // tssNew
            // 
            this.tssNew.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tssNew.Margin = new System.Windows.Forms.Padding(0, 1, 2, 2);
            this.tssNew.Name = "tssNew";
            this.tssNew.Size = new System.Drawing.Size(6, 24);
            // 
            // tsbNew
            // 
            this.tsbNew.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbNew.Image = global::ROMS.Properties.Resources.New;
            this.tsbNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNew.Margin = new System.Windows.Forms.Padding(0, 1, 2, 2);
            this.tsbNew.Name = "tsbNew";
            this.tsbNew.Size = new System.Drawing.Size(56, 24);
            this.tsbNew.Text = "&New";
            this.tsbNew.Click += new System.EventHandler(this.tsbNew_Click);
            // 
            // pnlinward
            // 
            this.pnlinward.BackColor = System.Drawing.Color.White;
            this.pnlinward.Controls.Add(this.DGV_FilterLocation);
            this.pnlinward.Controls.Add(this.DGV_FilterProduct);
            this.pnlinward.Controls.Add(this.grbFilterBy);
            this.pnlinward.Controls.Add(this.lblNoRecordsFound);
            this.pnlinward.Controls.Add(this.grdInwardList);
            this.pnlinward.Controls.Add(this.DGV_SearchGrid);
            this.pnlinward.Controls.Add(this.picLoader);
            this.pnlinward.Location = new System.Drawing.Point(0, 31);
            this.pnlinward.Name = "pnlinward";
            this.pnlinward.Size = new System.Drawing.Size(1354, 641);
            this.pnlinward.TabIndex = 36;
            // 
            // DGV_FilterLocation
            // 
            this.DGV_FilterLocation.AllowUserToAddRows = false;
            this.DGV_FilterLocation.AllowUserToDeleteRows = false;
            this.DGV_FilterLocation.AllowUserToResizeColumns = false;
            this.DGV_FilterLocation.AllowUserToResizeRows = false;
            this.DGV_FilterLocation.BackgroundColor = System.Drawing.Color.White;
            this.DGV_FilterLocation.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Chocolate;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Chocolate;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_FilterLocation.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DGV_FilterLocation.ColumnHeadersHeight = 30;
            this.DGV_FilterLocation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV_FilterLocation.DefaultCellStyle = dataGridViewCellStyle2;
            this.DGV_FilterLocation.EnableHeadersVisualStyles = false;
            this.DGV_FilterLocation.GridColor = System.Drawing.Color.White;
            this.DGV_FilterLocation.Location = new System.Drawing.Point(361, 76);
            this.DGV_FilterLocation.Name = "DGV_FilterLocation";
            this.DGV_FilterLocation.ReadOnly = true;
            this.DGV_FilterLocation.RowHeadersVisible = false;
            this.DGV_FilterLocation.RowHeadersWidth = 51;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.DGV_FilterLocation.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.DGV_FilterLocation.RowTemplate.Height = 25;
            this.DGV_FilterLocation.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV_FilterLocation.Size = new System.Drawing.Size(214, 226);
            this.DGV_FilterLocation.TabIndex = 111111174;
            this.DGV_FilterLocation.Visible = false;
            this.DGV_FilterLocation.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_FilterLocation_CellDoubleClick);
            this.DGV_FilterLocation.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DGV_FilterLocation_KeyDown);
            // 
            // DGV_FilterProduct
            // 
            this.DGV_FilterProduct.AllowUserToAddRows = false;
            this.DGV_FilterProduct.AllowUserToDeleteRows = false;
            this.DGV_FilterProduct.AllowUserToResizeColumns = false;
            this.DGV_FilterProduct.AllowUserToResizeRows = false;
            this.DGV_FilterProduct.BackgroundColor = System.Drawing.Color.White;
            this.DGV_FilterProduct.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Chocolate;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Chocolate;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_FilterProduct.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.DGV_FilterProduct.ColumnHeadersHeight = 30;
            this.DGV_FilterProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV_FilterProduct.DefaultCellStyle = dataGridViewCellStyle5;
            this.DGV_FilterProduct.EnableHeadersVisualStyles = false;
            this.DGV_FilterProduct.GridColor = System.Drawing.Color.White;
            this.DGV_FilterProduct.Location = new System.Drawing.Point(538, 76);
            this.DGV_FilterProduct.Name = "DGV_FilterProduct";
            this.DGV_FilterProduct.ReadOnly = true;
            this.DGV_FilterProduct.RowHeadersVisible = false;
            this.DGV_FilterProduct.RowHeadersWidth = 51;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.DGV_FilterProduct.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.DGV_FilterProduct.RowTemplate.Height = 25;
            this.DGV_FilterProduct.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV_FilterProduct.Size = new System.Drawing.Size(756, 226);
            this.DGV_FilterProduct.TabIndex = 111111136;
            this.DGV_FilterProduct.Visible = false;
            this.DGV_FilterProduct.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_FilterProduct_CellDoubleClick);
            this.DGV_FilterProduct.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DGV_FilterProduct_KeyDown);
            // 
            // grbFilterBy
            // 
            this.grbFilterBy.Controls.Add(this.lblQueueCount);
            this.grbFilterBy.Controls.Add(this.lblStatus);
            this.grbFilterBy.Controls.Add(this.cmbStatus);
            this.grbFilterBy.Controls.Add(this.txtStockLocation);
            this.grbFilterBy.Controls.Add(this.cmbConcern);
            this.grbFilterBy.Controls.Add(this.dpToDate);
            this.grbFilterBy.Controls.Add(this.txtProductName);
            this.grbFilterBy.Controls.Add(this.lblDProductNamePicode);
            this.grbFilterBy.Controls.Add(this.dpFromDate);
            this.grbFilterBy.Controls.Add(this.lblDGodown);
            this.grbFilterBy.Controls.Add(this.lblinwarddate);
            this.grbFilterBy.Controls.Add(this.lblDConcern);
            this.grbFilterBy.Controls.Add(this.btnExport);
            this.grbFilterBy.Controls.Add(this.btnView);
            this.grbFilterBy.Location = new System.Drawing.Point(3, 2);
            this.grbFilterBy.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbFilterBy.Name = "grbFilterBy";
            this.grbFilterBy.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbFilterBy.Size = new System.Drawing.Size(1348, 80);
            this.grbFilterBy.TabIndex = 958801;
            this.grbFilterBy.TabStop = false;
            this.grbFilterBy.Text = "Filter By ";
            // 
            // lblQueueCount
            // 
            this.lblQueueCount.AutoSize = true;
            this.lblQueueCount.BackColor = System.Drawing.SystemColors.Window;
            this.lblQueueCount.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQueueCount.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblQueueCount.Location = new System.Drawing.Point(1292, 21);
            this.lblQueueCount.Name = "lblQueueCount";
            this.lblQueueCount.Size = new System.Drawing.Size(17, 20);
            this.lblQueueCount.TabIndex = 1111199;
            this.lblQueueCount.Text = "0";
            this.lblQueueCount.Visible = false;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(946, 21);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(45, 20);
            this.lblStatus.TabIndex = 111111137;
            this.lblStatus.Text = "Status";
            // 
            // cmbStatus
            // 
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(946, 47);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(179, 27);
            this.cmbStatus.TabIndex = 5;
            this.cmbStatus.Enter += new System.EventHandler(this.CmbStatus_Enter);
            this.cmbStatus.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbStatus_KeyDown);
            this.cmbStatus.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbStatus_KeyPress);
            this.cmbStatus.Leave += new System.EventHandler(this.CmbStatus_Leave);
            // 
            // txtStockLocation
            // 
            this.txtStockLocation.Location = new System.Drawing.Point(356, 47);
            this.txtStockLocation.Name = "txtStockLocation";
            this.txtStockLocation.Size = new System.Drawing.Size(171, 27);
            this.txtStockLocation.TabIndex = 3;
            this.txtStockLocation.TextChanged += new System.EventHandler(this.TxtStockLocation_TextChanged);
            this.txtStockLocation.Enter += new System.EventHandler(this.TxtStockLocation_Enter);
            this.txtStockLocation.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtStockLocation_KeyDown);
            this.txtStockLocation.Leave += new System.EventHandler(this.TxtStockLocation_Leave);
            // 
            // cmbConcern
            // 
            this.cmbConcern.FormattingEnabled = true;
            this.cmbConcern.Location = new System.Drawing.Point(9, 47);
            this.cmbConcern.Name = "cmbConcern";
            this.cmbConcern.Size = new System.Drawing.Size(121, 27);
            this.cmbConcern.TabIndex = 0;
            this.cmbConcern.Enter += new System.EventHandler(this.CmbConcern_Enter);
            this.cmbConcern.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbConcern_KeyDown);
            this.cmbConcern.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbConcern_KeyPress);
            this.cmbConcern.Leave += new System.EventHandler(this.CmbConcern_Leave);
            // 
            // dpToDate
            // 
            this.dpToDate.CustomFormat = "dd/MM/yyyy";
            this.dpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpToDate.Location = new System.Drawing.Point(246, 47);
            this.dpToDate.Name = "dpToDate";
            this.dpToDate.Size = new System.Drawing.Size(104, 27);
            this.dpToDate.TabIndex = 2;
            this.dpToDate.Enter += new System.EventHandler(this.DpToDate_Enter);
            this.dpToDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DpToDate_KeyDown);
            this.dpToDate.Leave += new System.EventHandler(this.DpToDate_Leave);
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(533, 47);
            this.txtProductName.MaxLength = 2;
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(407, 27);
            this.txtProductName.TabIndex = 4;
            this.txtProductName.TextChanged += new System.EventHandler(this.TxtProductName_TextChanged);
            this.txtProductName.Enter += new System.EventHandler(this.TxtProductName_Enter);
            this.txtProductName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtProductName_KeyDown);
            this.txtProductName.Leave += new System.EventHandler(this.TxtProductName_Leave);
            // 
            // lblDProductNamePicode
            // 
            this.lblDProductNamePicode.AutoSize = true;
            this.lblDProductNamePicode.Location = new System.Drawing.Point(533, 22);
            this.lblDProductNamePicode.Name = "lblDProductNamePicode";
            this.lblDProductNamePicode.Size = new System.Drawing.Size(134, 20);
            this.lblDProductNamePicode.TabIndex = 958811;
            this.lblDProductNamePicode.Text = "Product Name/P.I Code";
            // 
            // dpFromDate
            // 
            this.dpFromDate.CustomFormat = "dd/MM/yyyy";
            this.dpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpFromDate.Location = new System.Drawing.Point(136, 47);
            this.dpFromDate.Name = "dpFromDate";
            this.dpFromDate.Size = new System.Drawing.Size(104, 27);
            this.dpFromDate.TabIndex = 1;
            this.dpFromDate.ValueChanged += new System.EventHandler(this.DpFromDate_ValueChanged);
            this.dpFromDate.Enter += new System.EventHandler(this.DpFromDate_Enter);
            this.dpFromDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DpFromDate_KeyDown);
            this.dpFromDate.Leave += new System.EventHandler(this.DpFromDate_Leave);
            // 
            // lblDGodown
            // 
            this.lblDGodown.AutoSize = true;
            this.lblDGodown.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.lblDGodown.Location = new System.Drawing.Point(356, 22);
            this.lblDGodown.Name = "lblDGodown";
            this.lblDGodown.Size = new System.Drawing.Size(87, 20);
            this.lblDGodown.TabIndex = 38;
            this.lblDGodown.Text = "Stock Location";
            // 
            // lblinwarddate
            // 
            this.lblinwarddate.AutoSize = true;
            this.lblinwarddate.Location = new System.Drawing.Point(136, 22);
            this.lblinwarddate.Name = "lblinwarddate";
            this.lblinwarddate.Size = new System.Drawing.Size(75, 20);
            this.lblinwarddate.TabIndex = 92;
            this.lblinwarddate.Text = "Inward Date";
            // 
            // lblDConcern
            // 
            this.lblDConcern.AutoSize = true;
            this.lblDConcern.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.lblDConcern.Location = new System.Drawing.Point(9, 22);
            this.lblDConcern.Name = "lblDConcern";
            this.lblDConcern.Size = new System.Drawing.Size(54, 20);
            this.lblDConcern.TabIndex = 36;
            this.lblDConcern.Text = "Concern";
            // 
            // btnExport
            // 
            this.btnExport.Image = global::ROMS.Properties.Resources.excel;
            this.btnExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExport.Location = new System.Drawing.Point(1212, 44);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(79, 29);
            this.btnExport.TabIndex = 7;
            this.btnExport.Text = "Export";
            this.btnExport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.BtnExport_Click);
            this.btnExport.Enter += new System.EventHandler(this.BtnExport_Enter);
            this.btnExport.Leave += new System.EventHandler(this.BtnExport_Leave);
            // 
            // btnView
            // 
            this.btnView.Image = global::ROMS.Properties.Resources.view;
            this.btnView.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnView.Location = new System.Drawing.Point(1131, 45);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(75, 29);
            this.btnView.TabIndex = 6;
            this.btnView.Text = "View";
            this.btnView.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.BtnView_Click);
            this.btnView.Enter += new System.EventHandler(this.BtnView_Enter);
            this.btnView.Leave += new System.EventHandler(this.BtnView_Leave);
            // 
            // lblNoRecordsFound
            // 
            this.lblNoRecordsFound.AutoSize = true;
            this.lblNoRecordsFound.BackColor = System.Drawing.Color.White;
            this.lblNoRecordsFound.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoRecordsFound.Location = new System.Drawing.Point(622, 381);
            this.lblNoRecordsFound.Name = "lblNoRecordsFound";
            this.lblNoRecordsFound.Size = new System.Drawing.Size(106, 20);
            this.lblNoRecordsFound.TabIndex = 958798;
            this.lblNoRecordsFound.Text = "No Records Found";
            this.lblNoRecordsFound.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // grdInwardList
            // 
            this.grdInwardList.AllowUserToAddRows = false;
            this.grdInwardList.AllowUserToDeleteRows = false;
            this.grdInwardList.AllowUserToResizeColumns = false;
            this.grdInwardList.AllowUserToResizeRows = false;
            this.grdInwardList.BackgroundColor = System.Drawing.Color.White;
            this.grdInwardList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdInwardList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.grdInwardList.ColumnHeadersHeight = 30;
            this.grdInwardList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdInwardList.ColumnHeadersVisible = false;
            this.grdInwardList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmPrint,
            this.clmStickerPrint});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdInwardList.DefaultCellStyle = dataGridViewCellStyle8;
            this.grdInwardList.EnableHeadersVisualStyles = false;
            this.grdInwardList.GridColor = System.Drawing.Color.White;
            this.grdInwardList.Location = new System.Drawing.Point(3, 146);
            this.grdInwardList.Name = "grdInwardList";
            this.grdInwardList.ReadOnly = true;
            this.grdInwardList.RowHeadersVisible = false;
            this.grdInwardList.RowHeadersWidth = 51;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.White;
            this.grdInwardList.RowsDefaultCellStyle = dataGridViewCellStyle9;
            this.grdInwardList.RowTemplate.Height = 25;
            this.grdInwardList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdInwardList.Size = new System.Drawing.Size(1348, 492);
            this.grdInwardList.TabIndex = 958797;
            this.grdInwardList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrdInwardList_CellContentClick);
            this.grdInwardList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.GrdInwardList_DataBindingComplete);
            this.grdInwardList.Scroll += new System.Windows.Forms.ScrollEventHandler(this.GrdInwardList_Scroll);
            this.grdInwardList.DoubleClick += new System.EventHandler(this.GrdInwardList_DoubleClick);
            this.grdInwardList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GrdInwardList_KeyDown);
            // 
            // DGV_SearchGrid
            // 
            this.DGV_SearchGrid.AllowUserToAddRows = false;
            this.DGV_SearchGrid.AllowUserToDeleteRows = false;
            this.DGV_SearchGrid.AllowUserToResizeRows = false;
            this.DGV_SearchGrid.BackgroundColor = System.Drawing.Color.White;
            this.DGV_SearchGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(242)))), ((int)(((byte)(213)))));
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_SearchGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.DGV_SearchGrid.ColumnHeadersHeight = 30;
            this.DGV_SearchGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV_SearchGrid.DefaultCellStyle = dataGridViewCellStyle11;
            this.DGV_SearchGrid.EnableHeadersVisualStyles = false;
            this.DGV_SearchGrid.GridColor = System.Drawing.Color.White;
            this.DGV_SearchGrid.Location = new System.Drawing.Point(3, 90);
            this.DGV_SearchGrid.Name = "DGV_SearchGrid";
            this.DGV_SearchGrid.RowHeadersVisible = false;
            this.DGV_SearchGrid.RowHeadersWidth = 51;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.Black;
            this.DGV_SearchGrid.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.DGV_SearchGrid.RowTemplate.Height = 25;
            this.DGV_SearchGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DGV_SearchGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DGV_SearchGrid.ShowRowErrors = false;
            this.DGV_SearchGrid.Size = new System.Drawing.Size(1348, 56);
            this.DGV_SearchGrid.TabIndex = 111111135;
            this.DGV_SearchGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_SearchGrid_CellEndEdit);
            this.DGV_SearchGrid.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.DGV_SearchGrid_CellPainting);
            this.DGV_SearchGrid.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DGV_SearchGrid_ColumnHeaderMouseClick);
            this.DGV_SearchGrid.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.DGV_SearchGrid_ColumnWidthChanged);
            this.DGV_SearchGrid.CurrentCellDirtyStateChanged += new System.EventHandler(this.DGV_SearchGrid_CurrentCellDirtyStateChanged);
            this.DGV_SearchGrid.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.DGV_SearchGrid_EditingControlShowing);
            this.DGV_SearchGrid.Scroll += new System.Windows.Forms.ScrollEventHandler(this.DGV_SearchGrid_Scroll);
            // 
            // picLoader
            // 
            this.picLoader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picLoader.ErrorImage = null;
            this.picLoader.Image = global::ROMS.Properties.Resources.Iphone_spinner_2;
            this.picLoader.InitialImage = null;
            this.picLoader.Location = new System.Drawing.Point(3, 77);
            this.picLoader.Name = "picLoader";
            this.picLoader.Size = new System.Drawing.Size(1351, 564);
            this.picLoader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picLoader.TabIndex = 958799;
            this.picLoader.TabStop = false;
            // 
            // clmPrint
            // 
            this.clmPrint.HeaderText = "Print";
            this.clmPrint.Image = global::ROMS.Properties.Resources.print16;
            this.clmPrint.Name = "clmPrint";
            this.clmPrint.ReadOnly = true;
            this.clmPrint.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmPrint.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.clmPrint.Width = 50;
            // 
            // clmStickerPrint
            // 
            this.clmStickerPrint.HeaderText = "Sticker Print";
            this.clmStickerPrint.Image = global::ROMS.Properties.Resources.print16;
            this.clmStickerPrint.Name = "clmStickerPrint";
            this.clmStickerPrint.ReadOnly = true;
            // 
            // INV_Inwardlist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(1354, 675);
            this.Controls.Add(this.pnlinward);
            this.Controls.Add(this.tsInwardList);
            this.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "INV_Inwardlist";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GI From Others";
            this.Load += new System.EventHandler(this.INV_Inwardlist_Load);
            this.DoubleClick += new System.EventHandler(this.INV_Inwardlist_DoubleClick);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.INV_Inwardlist_KeyDown);
            this.tsInwardList.ResumeLayout(false);
            this.tsInwardList.PerformLayout();
            this.pnlinward.ResumeLayout(false);
            this.pnlinward.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_FilterLocation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_FilterProduct)).EndInit();
            this.grbFilterBy.ResumeLayout(false);
            this.grbFilterBy.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdInwardList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_SearchGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStripLabel tspHeader;
        public System.Windows.Forms.ToolStripButton tsbEdit;
        private System.Windows.Forms.ToolStrip tsInwardList;
        private System.Windows.Forms.ToolStripSeparator tssNew;
        private System.Windows.Forms.ToolStripButton tsbNew;
        private System.Windows.Forms.Panel pnlinward;
        private System.Windows.Forms.Label lblNoRecordsFound;
        public System.Windows.Forms.DataGridView grdInwardList;
        private System.Windows.Forms.PictureBox picLoader;
        private System.Windows.Forms.GroupBox grbFilterBy;
        private System.Windows.Forms.DateTimePicker dpToDate;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Label lblDProductNamePicode;
        private System.Windows.Forms.DateTimePicker dpFromDate;
        private System.Windows.Forms.Label lblDGodown;
        private System.Windows.Forms.Label lblinwarddate;
        private System.Windows.Forms.Label lblDConcern;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnView;
        public System.Windows.Forms.ToolStripButton tsbQue;
        public System.Windows.Forms.ToolStripSeparator tssEdit;
        public System.Windows.Forms.ToolStripSeparator tssDelete;
        public System.Windows.Forms.ToolStripButton tsbDelete;
        private System.Windows.Forms.ComboBox cmbConcern;
        private System.Windows.Forms.TextBox txtStockLocation;
        public System.Windows.Forms.DataGridView DGV_SearchGrid;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbStatus;
        public System.Windows.Forms.DataGridView DGV_FilterProduct;
        public System.Windows.Forms.ToolStripButton tsTotalQueue;
        private System.Windows.Forms.Label lblQueueCount;
        public System.Windows.Forms.DataGridView DGV_FilterLocation;
        public System.Windows.Forms.ToolStripSeparator tss;
        private System.Windows.Forms.DataGridViewImageColumn clmPrint;
        private System.Windows.Forms.DataGridViewImageColumn clmStickerPrint;
    }
}