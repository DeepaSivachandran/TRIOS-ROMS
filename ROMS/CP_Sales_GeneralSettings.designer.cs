namespace ROMS
{
    partial class CP_Sales_GeneralSettings
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tsSalesGeneralSettings = new System.Windows.Forms.ToolStrip();
            this.tsSettings = new System.Windows.Forms.ToolStripLabel();
            this.pnlSettings = new System.Windows.Forms.Panel();
            this.grpSalesGeneralsettings = new System.Windows.Forms.GroupBox();
            this.lblDays = new System.Windows.Forms.Label();
            this.lblConsiderProducts = new System.Windows.Forms.Label();
            this.txtConsiderProducts = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grdOrderType = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.picLoader = new System.Windows.Forms.PictureBox();
            this.epSalesGeneralSettings = new System.Windows.Forms.ErrorProvider(this.components);
            this.tsSalesGeneralSettings.SuspendLayout();
            this.pnlSettings.SuspendLayout();
            this.grpSalesGeneralsettings.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOrderType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epSalesGeneralSettings)).BeginInit();
            this.SuspendLayout();
            // 
            // tsSalesGeneralSettings
            // 
            this.tsSalesGeneralSettings.BackColor = System.Drawing.Color.White;
            this.tsSalesGeneralSettings.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsSalesGeneralSettings.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsSalesGeneralSettings.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsSalesGeneralSettings.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsSettings});
            this.tsSalesGeneralSettings.Location = new System.Drawing.Point(0, 0);
            this.tsSalesGeneralSettings.Name = "tsSalesGeneralSettings";
            this.tsSalesGeneralSettings.Size = new System.Drawing.Size(1354, 25);
            this.tsSalesGeneralSettings.TabIndex = 35;
            this.tsSalesGeneralSettings.Text = "Settings";
            // 
            // tsSettings
            // 
            this.tsSettings.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsSettings.Image = global::ROMS.Properties.Resources.bread_crumb;
            this.tsSettings.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsSettings.Margin = new System.Windows.Forms.Padding(15, 1, 0, 2);
            this.tsSettings.Name = "tsSettings";
            this.tsSettings.Size = new System.Drawing.Size(146, 22);
            this.tsSettings.Text = "Sales General Settings";
            // 
            // pnlSettings
            // 
            this.pnlSettings.BackColor = System.Drawing.Color.White;
            this.pnlSettings.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSettings.Controls.Add(this.grpSalesGeneralsettings);
            this.pnlSettings.Location = new System.Drawing.Point(0, 28);
            this.pnlSettings.Name = "pnlSettings";
            this.pnlSettings.Size = new System.Drawing.Size(1354, 646);
            this.pnlSettings.TabIndex = 958788;
            // 
            // grpSalesGeneralsettings
            // 
            this.grpSalesGeneralsettings.Controls.Add(this.lblDays);
            this.grpSalesGeneralsettings.Controls.Add(this.lblConsiderProducts);
            this.grpSalesGeneralsettings.Controls.Add(this.txtConsiderProducts);
            this.grpSalesGeneralsettings.Controls.Add(this.groupBox1);
            this.grpSalesGeneralsettings.Controls.Add(this.btnClose);
            this.grpSalesGeneralsettings.Controls.Add(this.btnUpdate);
            this.grpSalesGeneralsettings.Location = new System.Drawing.Point(7, 1);
            this.grpSalesGeneralsettings.Name = "grpSalesGeneralsettings";
            this.grpSalesGeneralsettings.Size = new System.Drawing.Size(1331, 633);
            this.grpSalesGeneralsettings.TabIndex = 958794;
            this.grpSalesGeneralsettings.TabStop = false;
            // 
            // lblDays
            // 
            this.lblDays.AutoSize = true;
            this.lblDays.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDays.Location = new System.Drawing.Point(377, 24);
            this.lblDays.Name = "lblDays";
            this.lblDays.Size = new System.Drawing.Size(35, 20);
            this.lblDays.TabIndex = 1111196;
            this.lblDays.Text = "Days";
            // 
            // lblConsiderProducts
            // 
            this.lblConsiderProducts.AutoSize = true;
            this.lblConsiderProducts.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConsiderProducts.Location = new System.Drawing.Point(15, 24);
            this.lblConsiderProducts.Name = "lblConsiderProducts";
            this.lblConsiderProducts.Size = new System.Drawing.Size(260, 20);
            this.lblConsiderProducts.TabIndex = 1111195;
            this.lblConsiderProducts.Text = "Consider products as new if created in the last";
            // 
            // txtConsiderProducts
            // 
            this.txtConsiderProducts.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConsiderProducts.Location = new System.Drawing.Point(281, 21);
            this.txtConsiderProducts.MaxLength = 3;
            this.txtConsiderProducts.Name = "txtConsiderProducts";
            this.txtConsiderProducts.Size = new System.Drawing.Size(94, 27);
            this.txtConsiderProducts.TabIndex = 0;
            this.txtConsiderProducts.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtConsiderProducts.Enter += new System.EventHandler(this.txtConsiderProducts_Enter);
            this.txtConsiderProducts.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtConsiderProducts_KeyDown);
            this.txtConsiderProducts.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtConsiderProducts_KeyPress);
            this.txtConsiderProducts.Leave += new System.EventHandler(this.txtConsiderProducts_Leave);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.grdOrderType);
            this.groupBox1.Location = new System.Drawing.Point(1261, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(10, 15);
            this.groupBox1.TabIndex = 958796;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Turn Around Time";
            this.groupBox1.Visible = false;
            // 
            // grdOrderType
            // 
            this.grdOrderType.AllowUserToAddRows = false;
            this.grdOrderType.AllowUserToDeleteRows = false;
            this.grdOrderType.AllowUserToResizeColumns = false;
            this.grdOrderType.AllowUserToResizeRows = false;
            this.grdOrderType.BackgroundColor = System.Drawing.Color.White;
            this.grdOrderType.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdOrderType.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.grdOrderType.ColumnHeadersHeight = 30;
            this.grdOrderType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdOrderType.DefaultCellStyle = dataGridViewCellStyle5;
            this.grdOrderType.EnableHeadersVisualStyles = false;
            this.grdOrderType.GridColor = System.Drawing.Color.White;
            this.grdOrderType.Location = new System.Drawing.Point(6, 26);
            this.grdOrderType.Name = "grdOrderType";
            this.grdOrderType.RowHeadersVisible = false;
            this.grdOrderType.RowHeadersWidth = 51;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            this.grdOrderType.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.grdOrderType.RowTemplate.Height = 25;
            this.grdOrderType.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.grdOrderType.Size = new System.Drawing.Size(157, 188);
            this.grdOrderType.TabIndex = 1111198;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnClose.Image = global::ROMS.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(1247, 586);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 29);
            this.btnClose.TabIndex = 30;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            this.btnClose.Enter += new System.EventHandler(this.btnClose_Enter);
            this.btnClose.Leave += new System.EventHandler(this.btnClose_Leave);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnUpdate.Image = global::ROMS.Properties.Resources.save;
            this.btnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdate.Location = new System.Drawing.Point(1160, 586);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(84, 29);
            this.btnUpdate.TabIndex = 29;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            this.btnUpdate.Enter += new System.EventHandler(this.btnUpdate_Enter);
            this.btnUpdate.Leave += new System.EventHandler(this.btnUpdate_Leave);
            // 
            // picLoader
            // 
            this.picLoader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picLoader.ErrorImage = null;
            this.picLoader.Image = global::ROMS.Properties.Resources.loader;
            this.picLoader.InitialImage = null;
            this.picLoader.Location = new System.Drawing.Point(17, 41);
            this.picLoader.Name = "picLoader";
            this.picLoader.Size = new System.Drawing.Size(1322, 604);
            this.picLoader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picLoader.TabIndex = 958787;
            this.picLoader.TabStop = false;
            this.picLoader.Visible = false;
            // 
            // epSalesGeneralSettings
            // 
            this.epSalesGeneralSettings.ContainerControl = this;
            // 
            // CP_Sales_GeneralSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(1354, 675);
            this.Controls.Add(this.tsSalesGeneralSettings);
            this.Controls.Add(this.pnlSettings);
            this.Controls.Add(this.picLoader);
            this.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "CP_Sales_GeneralSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sales_GeneralSettings";
            this.Load += new System.EventHandler(this.CP_Sales_GeneralSettings_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CP_Sales_GeneralSettings_KeyDown);
            this.tsSalesGeneralSettings.ResumeLayout(false);
            this.tsSalesGeneralSettings.PerformLayout();
            this.pnlSettings.ResumeLayout(false);
            this.grpSalesGeneralsettings.ResumeLayout(false);
            this.grpSalesGeneralsettings.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdOrderType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epSalesGeneralSettings)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsSalesGeneralSettings;
        private System.Windows.Forms.ToolStripLabel tsSettings;
        private System.Windows.Forms.Panel pnlSettings;
        private System.Windows.Forms.PictureBox picLoader;
        private System.Windows.Forms.GroupBox grpSalesGeneralsettings;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label lblConsiderProducts;
        private System.Windows.Forms.TextBox txtConsiderProducts;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.DataGridView grdOrderType;
        private System.Windows.Forms.Label lblDays;
        private System.Windows.Forms.ErrorProvider epSalesGeneralSettings;
    }
}