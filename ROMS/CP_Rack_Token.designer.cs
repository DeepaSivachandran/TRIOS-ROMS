namespace ROMS
{
    partial class CP_Rack_Token
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CP_Rack_Token));
            this.tsHeader = new System.Windows.Forms.ToolStrip();
            this.tspHeader = new System.Windows.Forms.ToolStripLabel();
            this.lblRawCode = new System.Windows.Forms.Label();
            this.grdbFilter = new System.Windows.Forms.GroupBox();
            this.txtTokenGroup = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lblSubgroup = new System.Windows.Forms.Label();
            this.txtProducts = new System.Windows.Forms.TextBox();
            this.lblGroup = new System.Windows.Forms.Label();
            this.txtRack = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grbGrid = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.grdProducts = new System.Windows.Forms.DataGridView();
            this.grdRack = new System.Windows.Forms.DataGridView();
            this.btnProUnSelect = new System.Windows.Forms.Button();
            this.btnProSelect = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnRackUnSelect = new System.Windows.Forms.Button();
            this.btnRackSelect = new System.Windows.Forms.Button();
            this.picloader2 = new System.Windows.Forms.PictureBox();
            this.errRack = new System.Windows.Forms.ErrorProvider(this.components);
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn3 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn4 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dynamicLabelControl = new ROMS.DynamicToolStripLabelControl();
            this.tsHeader.SuspendLayout();
            this.grdbFilter.SuspendLayout();
            this.grbGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdRack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picloader2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errRack)).BeginInit();
            this.SuspendLayout();
            // 
            // tsHeader
            // 
            this.tsHeader.BackColor = System.Drawing.Color.Transparent;
            this.tsHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsHeader.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsHeader.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsHeader.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspHeader});
            this.tsHeader.Location = new System.Drawing.Point(0, 0);
            this.tsHeader.Name = "tsHeader";
            this.tsHeader.Size = new System.Drawing.Size(1360, 25);
            this.tsHeader.TabIndex = 35;
            this.tsHeader.Text = "toolStrip1";
            // 
            // tspHeader
            // 
            this.tspHeader.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tspHeader.Image = global::ROMS.Properties.Resources.bread_crumb;
            this.tspHeader.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tspHeader.Margin = new System.Windows.Forms.Padding(15, 1, 0, 2);
            this.tspHeader.Name = "tspHeader";
            this.tspHeader.Size = new System.Drawing.Size(165, 22);
            this.tspHeader.Text = "Token Slip Group Mapping";
            // 
            // lblRawCode
            // 
            this.lblRawCode.AutoSize = true;
            this.lblRawCode.Location = new System.Drawing.Point(628, 6);
            this.lblRawCode.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRawCode.Name = "lblRawCode";
            this.lblRawCode.Size = new System.Drawing.Size(16, 20);
            this.lblRawCode.TabIndex = 958798;
            this.lblRawCode.Text = "0";
            this.lblRawCode.Visible = false;
            // 
            // grdbFilter
            // 
            this.grdbFilter.Controls.Add(this.txtTokenGroup);
            this.grdbFilter.Controls.Add(this.label8);
            this.grdbFilter.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdbFilter.Location = new System.Drawing.Point(7, 25);
            this.grdbFilter.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.grdbFilter.Name = "grdbFilter";
            this.grdbFilter.Padding = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.grdbFilter.Size = new System.Drawing.Size(1342, 54);
            this.grdbFilter.TabIndex = 0;
            this.grdbFilter.TabStop = false;
            // 
            // txtTokenGroup
            // 
            this.txtTokenGroup.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTokenGroup.Location = new System.Drawing.Point(138, 18);
            this.txtTokenGroup.MaxLength = 100;
            this.txtTokenGroup.Name = "txtTokenGroup";
            this.txtTokenGroup.Size = new System.Drawing.Size(323, 27);
            this.txtTokenGroup.TabIndex = 0;
            this.txtTokenGroup.Enter += new System.EventHandler(this.Common_Enter);
            this.txtTokenGroup.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Common_KeyDown);
            this.txtTokenGroup.Leave += new System.EventHandler(this.Common_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(5, 21);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(132, 20);
            this.label8.TabIndex = 958812;
            this.label8.Text = "Token Slip Group Name";
            // 
            // lblSubgroup
            // 
            this.lblSubgroup.AutoSize = true;
            this.lblSubgroup.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubgroup.Location = new System.Drawing.Point(471, 23);
            this.lblSubgroup.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSubgroup.Name = "lblSubgroup";
            this.lblSubgroup.Size = new System.Drawing.Size(52, 20);
            this.lblSubgroup.TabIndex = 958807;
            this.lblSubgroup.Text = "Product";
            // 
            // txtProducts
            // 
            this.txtProducts.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProducts.Location = new System.Drawing.Point(538, 20);
            this.txtProducts.MaxLength = 100;
            this.txtProducts.Name = "txtProducts";
            this.txtProducts.Size = new System.Drawing.Size(543, 27);
            this.txtProducts.TabIndex = 2;
            this.txtProducts.TextChanged += new System.EventHandler(this.txtProducts_TextChanged);
            this.txtProducts.Enter += new System.EventHandler(this.Common_Enter);
            this.txtProducts.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Common_KeyDown);
            this.txtProducts.Leave += new System.EventHandler(this.Common_Leave);
            // 
            // lblGroup
            // 
            this.lblGroup.AutoSize = true;
            this.lblGroup.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGroup.Location = new System.Drawing.Point(9, 24);
            this.lblGroup.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGroup.Name = "lblGroup";
            this.lblGroup.Size = new System.Drawing.Size(35, 20);
            this.lblGroup.TabIndex = 958805;
            this.lblGroup.Text = "Rack";
            // 
            // txtRack
            // 
            this.txtRack.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRack.Location = new System.Drawing.Point(62, 21);
            this.txtRack.MaxLength = 100;
            this.txtRack.Name = "txtRack";
            this.txtRack.Size = new System.Drawing.Size(262, 27);
            this.txtRack.TabIndex = 1;
            this.txtRack.TextChanged += new System.EventHandler(this.txtRack_TextChanged);
            this.txtRack.Enter += new System.EventHandler(this.Common_Enter);
            this.txtRack.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Common_KeyDown);
            this.txtRack.Leave += new System.EventHandler(this.Common_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 820);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 20);
            this.label1.TabIndex = 958803;
            this.label1.Text = "Completed - Pending - Planned";
            // 
            // grbGrid
            // 
            this.grbGrid.Controls.Add(this.btnSave);
            this.grbGrid.Controls.Add(this.grdProducts);
            this.grbGrid.Controls.Add(this.grdRack);
            this.grbGrid.Controls.Add(this.btnProUnSelect);
            this.grbGrid.Controls.Add(this.btnProSelect);
            this.grbGrid.Controls.Add(this.btnClose);
            this.grbGrid.Controls.Add(this.btnRackUnSelect);
            this.grbGrid.Controls.Add(this.btnRackSelect);
            this.grbGrid.Controls.Add(this.lblSubgroup);
            this.grbGrid.Controls.Add(this.txtProducts);
            this.grbGrid.Controls.Add(this.lblGroup);
            this.grbGrid.Controls.Add(this.txtRack);
            this.grbGrid.Controls.Add(this.picloader2);
            this.grbGrid.Location = new System.Drawing.Point(7, 86);
            this.grbGrid.Name = "grbGrid";
            this.grbGrid.Size = new System.Drawing.Size(1341, 568);
            this.grbGrid.TabIndex = 4;
            this.grbGrid.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Oswald Regular", 11.25F);
            this.btnSave.Image = global::ROMS.Properties.Resources.save;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(907, 532);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(92, 29);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.Enter += new System.EventHandler(this.Common_Enter);
            this.btnSave.Leave += new System.EventHandler(this.Common_Leave);
            // 
            // grdProducts
            // 
            this.grdProducts.AllowUserToAddRows = false;
            this.grdProducts.AllowUserToDeleteRows = false;
            this.grdProducts.AllowUserToResizeColumns = false;
            this.grdProducts.AllowUserToResizeRows = false;
            this.grdProducts.BackgroundColor = System.Drawing.Color.White;
            this.grdProducts.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdProducts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdProducts.ColumnHeadersHeight = 55;
            this.grdProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdProducts.EnableHeadersVisualStyles = false;
            this.grdProducts.GridColor = System.Drawing.Color.White;
            this.grdProducts.Location = new System.Drawing.Point(475, 54);
            this.grdProducts.Name = "grdProducts";
            this.grdProducts.RowHeadersVisible = false;
            this.grdProducts.RowTemplate.Height = 25;
            this.grdProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.grdProducts.Size = new System.Drawing.Size(606, 471);
            this.grdProducts.TabIndex = 1111203;
            // 
            // grdRack
            // 
            this.grdRack.AllowUserToAddRows = false;
            this.grdRack.AllowUserToDeleteRows = false;
            this.grdRack.AllowUserToResizeColumns = false;
            this.grdRack.AllowUserToResizeRows = false;
            this.grdRack.BackgroundColor = System.Drawing.Color.White;
            this.grdRack.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdRack.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grdRack.ColumnHeadersHeight = 55;
            this.grdRack.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdRack.EnableHeadersVisualStyles = false;
            this.grdRack.GridColor = System.Drawing.Color.White;
            this.grdRack.Location = new System.Drawing.Point(13, 54);
            this.grdRack.Name = "grdRack";
            this.grdRack.RowHeadersVisible = false;
            this.grdRack.RowTemplate.Height = 25;
            this.grdRack.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.grdRack.Size = new System.Drawing.Size(399, 471);
            this.grdRack.TabIndex = 1111202;
            this.grdRack.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdRack_CellValueChanged);
            this.grdRack.CurrentCellDirtyStateChanged += new System.EventHandler(this.grdRack_CurrentCellDirtyStateChanged);
            // 
            // btnProUnSelect
            // 
            this.btnProUnSelect.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProUnSelect.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProUnSelect.Location = new System.Drawing.Point(541, 532);
            this.btnProUnSelect.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btnProUnSelect.Name = "btnProUnSelect";
            this.btnProUnSelect.Size = new System.Drawing.Size(80, 29);
            this.btnProUnSelect.TabIndex = 6;
            this.btnProUnSelect.Text = "Unselect All";
            this.btnProUnSelect.UseVisualStyleBackColor = true;
            this.btnProUnSelect.Click += new System.EventHandler(this.btnProUnSelect_Click);
            this.btnProUnSelect.Enter += new System.EventHandler(this.Common_Enter);
            this.btnProUnSelect.Leave += new System.EventHandler(this.Common_Leave);
            // 
            // btnProSelect
            // 
            this.btnProSelect.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProSelect.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProSelect.Location = new System.Drawing.Point(471, 532);
            this.btnProSelect.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btnProSelect.Name = "btnProSelect";
            this.btnProSelect.Size = new System.Drawing.Size(66, 29);
            this.btnProSelect.TabIndex = 5;
            this.btnProSelect.Text = "Select All";
            this.btnProSelect.UseVisualStyleBackColor = true;
            this.btnProSelect.Click += new System.EventHandler(this.btnProSelect_Click);
            this.btnProSelect.Enter += new System.EventHandler(this.Common_Enter);
            this.btnProSelect.Leave += new System.EventHandler(this.Common_Leave);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::ROMS.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(1006, 532);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 29);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            this.btnClose.Enter += new System.EventHandler(this.Common_Enter);
            this.btnClose.Leave += new System.EventHandler(this.Common_Leave);
            // 
            // btnRackUnSelect
            // 
            this.btnRackUnSelect.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRackUnSelect.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRackUnSelect.Location = new System.Drawing.Point(78, 532);
            this.btnRackUnSelect.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btnRackUnSelect.Name = "btnRackUnSelect";
            this.btnRackUnSelect.Size = new System.Drawing.Size(80, 29);
            this.btnRackUnSelect.TabIndex = 4;
            this.btnRackUnSelect.Text = "Unselect All";
            this.btnRackUnSelect.UseVisualStyleBackColor = true;
            this.btnRackUnSelect.Click += new System.EventHandler(this.btnRackUnSelect_Click);
            this.btnRackUnSelect.Enter += new System.EventHandler(this.Common_Enter);
            this.btnRackUnSelect.Leave += new System.EventHandler(this.Common_Leave);
            // 
            // btnRackSelect
            // 
            this.btnRackSelect.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRackSelect.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRackSelect.Location = new System.Drawing.Point(8, 532);
            this.btnRackSelect.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btnRackSelect.Name = "btnRackSelect";
            this.btnRackSelect.Size = new System.Drawing.Size(66, 29);
            this.btnRackSelect.TabIndex = 3;
            this.btnRackSelect.Text = "Select All";
            this.btnRackSelect.UseVisualStyleBackColor = true;
            this.btnRackSelect.Click += new System.EventHandler(this.btnRackSelect_Click);
            this.btnRackSelect.Enter += new System.EventHandler(this.Common_Enter);
            this.btnRackSelect.Leave += new System.EventHandler(this.Common_Leave);
            // 
            // picloader2
            // 
            this.picloader2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picloader2.ErrorImage = null;
            this.picloader2.Image = global::ROMS.Properties.Resources.Iphone_spinner_2;
            this.picloader2.InitialImage = null;
            this.picloader2.Location = new System.Drawing.Point(475, 54);
            this.picloader2.Name = "picloader2";
            this.picloader2.Size = new System.Drawing.Size(573, 471);
            this.picloader2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picloader2.TabIndex = 1111204;
            this.picloader2.TabStop = false;
            this.picloader2.Visible = false;
            // 
            // errRack
            // 
            this.errRack.ContainerControl = this;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "Product Label";
            this.dataGridViewImageColumn1.Image = global::ROMS.Properties.Resources.print_label;
            this.dataGridViewImageColumn1.MinimumWidth = 6;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewImageColumn1.Width = 150;
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.HeaderText = "Intermediate Label";
            this.dataGridViewImageColumn2.Image = global::ROMS.Properties.Resources.print_label;
            this.dataGridViewImageColumn2.MinimumWidth = 6;
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewImageColumn2.Width = 150;
            // 
            // dataGridViewImageColumn3
            // 
            this.dataGridViewImageColumn3.HeaderText = "Outer Label";
            this.dataGridViewImageColumn3.Image = global::ROMS.Properties.Resources.print_label;
            this.dataGridViewImageColumn3.MinimumWidth = 6;
            this.dataGridViewImageColumn3.Name = "dataGridViewImageColumn3";
            this.dataGridViewImageColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewImageColumn3.Width = 150;
            // 
            // dataGridViewImageColumn4
            // 
            this.dataGridViewImageColumn4.HeaderText = "Token";
            this.dataGridViewImageColumn4.Image = global::ROMS.Properties.Resources.print_label;
            this.dataGridViewImageColumn4.MinimumWidth = 6;
            this.dataGridViewImageColumn4.Name = "dataGridViewImageColumn4";
            this.dataGridViewImageColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewImageColumn4.Width = 150;
            // 
            // dynamicLabelControl
            // 
            this.dynamicLabelControl.PlaceholderLabel = null;
            // 
            // CP_Rack_Token
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1360, 665);
            this.Controls.Add(this.grbGrid);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grdbFilter);
            this.Controls.Add(this.lblRawCode);
            this.Controls.Add(this.tsHeader);
            this.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.Name = "CP_Rack_Token";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rack Sticker Print";
            this.Load += new System.EventHandler(this.CP_Rack_Token_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CP_Rack_Token_KeyDown);
            this.tsHeader.ResumeLayout(false);
            this.tsHeader.PerformLayout();
            this.grdbFilter.ResumeLayout(false);
            this.grdbFilter.PerformLayout();
            this.grbGrid.ResumeLayout(false);
            this.grbGrid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdRack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picloader2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errRack)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.ToolStrip tsHeader;
        public System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        public System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        public System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn3;
        public System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn4;
        private System.Windows.Forms.Label lblRawCode;
        private System.Windows.Forms.GroupBox grdbFilter;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button btnClose;
        public System.Windows.Forms.Label lblGroup;
        private System.Windows.Forms.TextBox txtRack;
        public System.Windows.Forms.Label lblSubgroup;
        private System.Windows.Forms.TextBox txtProducts;
        private System.Windows.Forms.GroupBox grbGrid;
        public System.Windows.Forms.Label label8;
        private System.Windows.Forms.ErrorProvider errRack;
        public System.Windows.Forms.Button btnRackSelect;
        public System.Windows.Forms.Button btnRackUnSelect;
        public System.Windows.Forms.Button btnProUnSelect;
        public System.Windows.Forms.Button btnProSelect;
        private System.Windows.Forms.TextBox txtTokenGroup;
        public System.Windows.Forms.DataGridView grdRack;
        public System.Windows.Forms.DataGridView grdProducts;
        private DynamicToolStripLabelControl dynamicLabelControl;
        private System.Windows.Forms.PictureBox picloader2;
        public System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ToolStripLabel tspHeader;
    }
}