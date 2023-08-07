namespace ROMS
{
    partial class CP_GeneralSettings
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tshSettings = new System.Windows.Forms.ToolStrip();
            this.tsSettings = new System.Windows.Forms.ToolStripLabel();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.tssEdit = new System.Windows.Forms.ToolStripSeparator();
            this.tsbEdit = new System.Windows.Forms.ToolStripButton();
            this.tssNew = new System.Windows.Forms.ToolStripSeparator();
            this.tsbNew = new System.Windows.Forms.ToolStripButton();
            this.pnlSettings = new System.Windows.Forms.Panel();
            this.grpGeneralsettings = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblDCashpurchase = new System.Windows.Forms.Label();
            this.txtcashpurchase = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grdOrderType = new System.Windows.Forms.DataGridView();
            this.clmUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.picLoader = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.tshSettings.SuspendLayout();
            this.pnlSettings.SuspendLayout();
            this.grpGeneralsettings.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOrderType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).BeginInit();
            this.SuspendLayout();
            // 
            // tshSettings
            // 
            this.tshSettings.BackColor = System.Drawing.Color.White;
            this.tshSettings.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tshSettings.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tshSettings.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsSettings,
            this.tsbDelete,
            this.tssEdit,
            this.tsbEdit,
            this.tssNew,
            this.tsbNew});
            this.tshSettings.Location = new System.Drawing.Point(0, 0);
            this.tshSettings.Name = "tshSettings";
            this.tshSettings.Size = new System.Drawing.Size(1354, 25);
            this.tshSettings.TabIndex = 35;
            this.tshSettings.Text = "Settings";
            // 
            // tsSettings
            // 
            this.tsSettings.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsSettings.Image = global::ROMS.Properties.Resources.bread_crumb;
            this.tsSettings.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsSettings.Margin = new System.Windows.Forms.Padding(15, 1, 0, 2);
            this.tsSettings.Name = "tsSettings";
            this.tsSettings.Size = new System.Drawing.Size(115, 22);
            this.tsSettings.Text = "General Settings";
            // 
            // tsbDelete
            // 
            this.tsbDelete.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbDelete.Image = global::ROMS.Properties.Resources.Delete;
            this.tsbDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDelete.Margin = new System.Windows.Forms.Padding(0, 1, 15, 2);
            this.tsbDelete.Name = "tsbDelete";
            this.tsbDelete.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tsbDelete.Size = new System.Drawing.Size(63, 24);
            this.tsbDelete.Text = "Delete";
            this.tsbDelete.Visible = false;
            // 
            // tssEdit
            // 
            this.tssEdit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tssEdit.Margin = new System.Windows.Forms.Padding(0, 0, 15, 0);
            this.tssEdit.Name = "tssEdit";
            this.tssEdit.Size = new System.Drawing.Size(6, 27);
            this.tssEdit.Visible = false;
            // 
            // tsbEdit
            // 
            this.tsbEdit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbEdit.Image = global::ROMS.Properties.Resources.Edit;
            this.tsbEdit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEdit.Margin = new System.Windows.Forms.Padding(0, 1, 15, 2);
            this.tsbEdit.Name = "tsbEdit";
            this.tsbEdit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tsbEdit.Size = new System.Drawing.Size(50, 24);
            this.tsbEdit.Text = "&Edit";
            this.tsbEdit.Visible = false;
            // 
            // tssNew
            // 
            this.tssNew.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tssNew.Margin = new System.Windows.Forms.Padding(0, 0, 15, 0);
            this.tssNew.Name = "tssNew";
            this.tssNew.Size = new System.Drawing.Size(6, 27);
            this.tssNew.Visible = false;
            // 
            // tsbNew
            // 
            this.tsbNew.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbNew.Image = global::ROMS.Properties.Resources.New;
            this.tsbNew.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNew.Margin = new System.Windows.Forms.Padding(0, 1, 10, 2);
            this.tsbNew.Name = "tsbNew";
            this.tsbNew.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tsbNew.Size = new System.Drawing.Size(52, 24);
            this.tsbNew.Text = "&New";
            this.tsbNew.Visible = false;
            // 
            // pnlSettings
            // 
            this.pnlSettings.BackColor = System.Drawing.Color.White;
            this.pnlSettings.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSettings.Controls.Add(this.grpGeneralsettings);
            this.pnlSettings.Location = new System.Drawing.Point(0, 28);
            this.pnlSettings.Name = "pnlSettings";
            this.pnlSettings.Size = new System.Drawing.Size(1354, 646);
            this.pnlSettings.TabIndex = 958788;
            // 
            // grpGeneralsettings
            // 
            this.grpGeneralsettings.Controls.Add(this.textBox2);
            this.grpGeneralsettings.Controls.Add(this.label3);
            this.grpGeneralsettings.Controls.Add(this.label2);
            this.grpGeneralsettings.Controls.Add(this.label1);
            this.grpGeneralsettings.Controls.Add(this.textBox1);
            this.grpGeneralsettings.Controls.Add(this.lblDCashpurchase);
            this.grpGeneralsettings.Controls.Add(this.txtcashpurchase);
            this.grpGeneralsettings.Controls.Add(this.groupBox1);
            this.grpGeneralsettings.Controls.Add(this.btnClose);
            this.grpGeneralsettings.Controls.Add(this.btnSave);
            this.grpGeneralsettings.Location = new System.Drawing.Point(7, 1);
            this.grpGeneralsettings.Name = "grpGeneralsettings";
            this.grpGeneralsettings.Size = new System.Drawing.Size(1339, 633);
            this.grpGeneralsettings.TabIndex = 958794;
            this.grpGeneralsettings.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(414, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 20);
            this.label2.TabIndex = 1111199;
            this.label2.Text = "Bill amount";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(216, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 20);
            this.label1.TabIndex = 1111197;
            this.label1.Text = "Double Verification for";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(350, 74);
            this.textBox1.MaxLength = 50;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(45, 27);
            this.textBox1.TabIndex = 1111198;
            // 
            // lblDCashpurchase
            // 
            this.lblDCashpurchase.AutoSize = true;
            this.lblDCashpurchase.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDCashpurchase.Location = new System.Drawing.Point(216, 23);
            this.lblDCashpurchase.Name = "lblDCashpurchase";
            this.lblDCashpurchase.Size = new System.Drawing.Size(179, 20);
            this.lblDCashpurchase.TabIndex = 1111195;
            this.lblDCashpurchase.Text = "Cash purchase exceeds amount";
            // 
            // txtcashpurchase
            // 
            this.txtcashpurchase.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcashpurchase.Location = new System.Drawing.Point(397, 20);
            this.txtcashpurchase.MaxLength = 50;
            this.txtcashpurchase.Name = "txtcashpurchase";
            this.txtcashpurchase.Size = new System.Drawing.Size(117, 27);
            this.txtcashpurchase.TabIndex = 1111196;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.grdOrderType);
            this.groupBox1.Location = new System.Drawing.Point(9, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(171, 227);
            this.groupBox1.TabIndex = 958796;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Turn Around Time";
            // 
            // grdOrderType
            // 
            this.grdOrderType.AllowUserToAddRows = false;
            this.grdOrderType.AllowUserToDeleteRows = false;
            this.grdOrderType.AllowUserToResizeColumns = false;
            this.grdOrderType.AllowUserToResizeRows = false;
            this.grdOrderType.BackgroundColor = System.Drawing.Color.White;
            this.grdOrderType.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle17.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle17.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdOrderType.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle17;
            this.grdOrderType.ColumnHeadersHeight = 30;
            this.grdOrderType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdOrderType.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmUnit,
            this.clmQty});
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdOrderType.DefaultCellStyle = dataGridViewCellStyle19;
            this.grdOrderType.EnableHeadersVisualStyles = false;
            this.grdOrderType.GridColor = System.Drawing.Color.White;
            this.grdOrderType.Location = new System.Drawing.Point(6, 26);
            this.grdOrderType.Name = "grdOrderType";
            this.grdOrderType.RowHeadersVisible = false;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.Color.White;
            this.grdOrderType.RowsDefaultCellStyle = dataGridViewCellStyle20;
            this.grdOrderType.RowTemplate.Height = 25;
            this.grdOrderType.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.grdOrderType.Size = new System.Drawing.Size(157, 188);
            this.grdOrderType.TabIndex = 1111198;
            // 
            // clmUnit
            // 
            this.clmUnit.HeaderText = "Order Type";
            this.clmUnit.Name = "clmUnit";
            this.clmUnit.ReadOnly = true;
            this.clmUnit.Width = 80;
            // 
            // clmQty
            // 
            dataGridViewCellStyle18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.clmQty.DefaultCellStyle = dataGridViewCellStyle18;
            this.clmQty.HeaderText = "Days";
            this.clmQty.Name = "clmQty";
            this.clmQty.Width = 50;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnClose.Image = global::ROMS.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(1247, 586);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 29);
            this.btnClose.TabIndex = 958795;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnSave.Image = global::ROMS.Properties.Resources.save;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(1160, 586);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(84, 29);
            this.btnSave.TabIndex = 958794;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(216, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(160, 20);
            this.label3.TabIndex = 1111198;
            this.label3.Text = "GRN label print - Excess Qty";
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(397, 128);
            this.textBox2.MaxLength = 50;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(45, 27);
            this.textBox2.TabIndex = 1111200;
            // 
            // CP_GeneralSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(1354, 675);
            this.Controls.Add(this.tshSettings);
            this.Controls.Add(this.pnlSettings);
            this.Controls.Add(this.picLoader);
            this.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "CP_GeneralSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.CP_GeneralSettings_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CP_GeneralSettings_KeyDown);
            this.tshSettings.ResumeLayout(false);
            this.tshSettings.PerformLayout();
            this.pnlSettings.ResumeLayout(false);
            this.grpGeneralsettings.ResumeLayout(false);
            this.grpGeneralsettings.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdOrderType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tshSettings;
        public System.Windows.Forms.ToolStripSeparator tssEdit;
        private System.Windows.Forms.ToolStripLabel tsSettings;
        public System.Windows.Forms.ToolStripButton tsbDelete;
        public System.Windows.Forms.ToolStripButton tsbEdit;
        public System.Windows.Forms.ToolStripSeparator tssNew;
        public System.Windows.Forms.ToolStripButton tsbNew;
        private System.Windows.Forms.Panel pnlSettings;
        private System.Windows.Forms.PictureBox picLoader;
        private System.Windows.Forms.GroupBox grpGeneralsettings;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.DataGridView grdOrderType;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmQty;
        private System.Windows.Forms.Label lblDCashpurchase;
        private System.Windows.Forms.TextBox txtcashpurchase;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
    }
}