namespace ROMS
{
    partial class CP_Tally
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
            this.tsTally = new System.Windows.Forms.ToolStrip();
            this.tspHeader = new System.Windows.Forms.ToolStripLabel();
            this.pnlCompany = new System.Windows.Forms.Panel();
            this.grbform = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.cmbTransactiontype = new System.Windows.Forms.ComboBox();
            this.cmbModule = new System.Windows.Forms.ComboBox();
            this.cmbConcern = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.epTally = new System.Windows.Forms.ErrorProvider(this.components);
            this.tsTally.SuspendLayout();
            this.pnlCompany.SuspendLayout();
            this.grbform.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epTally)).BeginInit();
            this.SuspendLayout();
            // 
            // tsTally
            // 
            this.tsTally.BackColor = System.Drawing.Color.White;
            this.tsTally.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsTally.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsTally.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspHeader});
            this.tsTally.Location = new System.Drawing.Point(0, 0);
            this.tsTally.Name = "tsTally";
            this.tsTally.Size = new System.Drawing.Size(1354, 25);
            this.tsTally.TabIndex = 35;
            this.tsTally.Text = "Brand";
            // 
            // tspHeader
            // 
            this.tspHeader.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tspHeader.Image = global::ROMS.Properties.Resources.bread_crumb;
            this.tspHeader.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tspHeader.Margin = new System.Windows.Forms.Padding(15, 1, 0, 2);
            this.tspHeader.Name = "tspHeader";
            this.tspHeader.Size = new System.Drawing.Size(87, 22);
            this.tspHeader.Text = "Export Tally";
            // 
            // pnlCompany
            // 
            this.pnlCompany.BackColor = System.Drawing.Color.White;
            this.pnlCompany.Controls.Add(this.grbform);
            this.pnlCompany.Location = new System.Drawing.Point(0, 29);
            this.pnlCompany.Name = "pnlCompany";
            this.pnlCompany.Size = new System.Drawing.Size(1354, 645);
            this.pnlCompany.TabIndex = 958797;
            // 
            // grbform
            // 
            this.grbform.Controls.Add(this.groupBox1);
            this.grbform.Location = new System.Drawing.Point(8, 1);
            this.grbform.Name = "grbform";
            this.grbform.Size = new System.Drawing.Size(1339, 633);
            this.grbform.TabIndex = 0;
            this.grbform.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnExport);
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Controls.Add(this.cmbTransactiontype);
            this.groupBox1.Controls.Add(this.cmbModule);
            this.groupBox1.Controls.Add(this.cmbConcern);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(410, 174);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(453, 240);
            this.groupBox1.TabIndex = 1111178;
            this.groupBox1.TabStop = false;
            // 
            // btnExport
            // 
            this.btnExport.Image = global::ROMS.Properties.Resources.excel;
            this.btnExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExport.Location = new System.Drawing.Point(223, 177);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(79, 29);
            this.btnExport.TabIndex = 4;
            this.btnExport.Text = "Export";
            this.btnExport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Enter += new System.EventHandler(this.BtnExport_Enter);
            this.btnExport.Leave += new System.EventHandler(this.BtnExport_Leave);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnClose.Image = global::ROMS.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(307, 177);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 29);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            this.btnClose.Enter += new System.EventHandler(this.BtnClose_Enter);
            this.btnClose.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BtnClose_KeyDown);
            this.btnClose.Leave += new System.EventHandler(this.BtnClose_Leave);
            // 
            // cmbTransactiontype
            // 
            this.cmbTransactiontype.FormattingEnabled = true;
            this.cmbTransactiontype.Location = new System.Drawing.Point(189, 134);
            this.cmbTransactiontype.Name = "cmbTransactiontype";
            this.cmbTransactiontype.Size = new System.Drawing.Size(193, 27);
            this.cmbTransactiontype.TabIndex = 2;
            this.cmbTransactiontype.Enter += new System.EventHandler(this.CmbTransactiontype_Enter);
            this.cmbTransactiontype.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbTransactiontype_KeyDown);
            this.cmbTransactiontype.Leave += new System.EventHandler(this.CmbTransactiontype_Leave);
            // 
            // cmbModule
            // 
            this.cmbModule.FormattingEnabled = true;
            this.cmbModule.Location = new System.Drawing.Point(189, 88);
            this.cmbModule.Name = "cmbModule";
            this.cmbModule.Size = new System.Drawing.Size(193, 27);
            this.cmbModule.TabIndex = 1;
            this.cmbModule.Enter += new System.EventHandler(this.CmbModule_Enter);
            this.cmbModule.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbModule_KeyDown);
            this.cmbModule.Leave += new System.EventHandler(this.CmbModule_Leave);
            // 
            // cmbConcern
            // 
            this.cmbConcern.FormattingEnabled = true;
            this.cmbConcern.Location = new System.Drawing.Point(189, 43);
            this.cmbConcern.Name = "cmbConcern";
            this.cmbConcern.Size = new System.Drawing.Size(193, 27);
            this.cmbConcern.TabIndex = 0;
            this.cmbConcern.Enter += new System.EventHandler(this.CmbConcern_Enter);
            this.cmbConcern.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbConcern_KeyDown);
            this.cmbConcern.Leave += new System.EventHandler(this.CmbConcern_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(68, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Transaction type";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(68, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Module";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(68, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Concern";
            // 
            // epTally
            // 
            this.epTally.ContainerControl = this;
            // 
            // CP_Tally
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(1354, 675);
            this.Controls.Add(this.pnlCompany);
            this.Controls.Add(this.tsTally);
            this.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "CP_Tally";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Export Tally";
            this.Load += new System.EventHandler(this.CP_Tally_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CP_Tally_KeyDown);
            this.tsTally.ResumeLayout(false);
            this.tsTally.PerformLayout();
            this.pnlCompany.ResumeLayout(false);
            this.grbform.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epTally)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsTally;
        private System.Windows.Forms.ToolStripLabel tspHeader;
        private System.Windows.Forms.Panel pnlCompany;
        private System.Windows.Forms.GroupBox grbform;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ErrorProvider epTally;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbTransactiontype;
        private System.Windows.Forms.ComboBox cmbModule;
        private System.Windows.Forms.ComboBox cmbConcern;
        private System.Windows.Forms.Button btnExport;
    }
}