namespace ROMS
{
    partial class PUR_POMappedProducts
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PUR_POMappedProducts));
            this.errUnit = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.grdPurchaseOrder = new System.Windows.Forms.DataGridView();
            this.lblNoRecordsFound = new System.Windows.Forms.Label();
            this.btnselectall = new System.Windows.Forms.Button();
            this.btnunselectall = new System.Windows.Forms.Button();
            this.lblPC = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errUnit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPurchaseOrder)).BeginInit();
            this.SuspendLayout();
            // 
            // errUnit
            // 
            this.errUnit.ContainerControl = this;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::ROMS.Properties.Resources.submit;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(849, 460);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(81, 33);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Submit";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            this.btnSave.Enter += new System.EventHandler(this.BtnSave_Enter);
            this.btnSave.Leave += new System.EventHandler(this.BtnSave_Leave);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::ROMS.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(936, 460);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(72, 33);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            this.btnClose.Enter += new System.EventHandler(this.BtnClose_Enter);
            this.btnClose.Leave += new System.EventHandler(this.BtnClose_Leave);
            // 
            // grdPurchaseOrder
            // 
            this.grdPurchaseOrder.AllowUserToAddRows = false;
            this.grdPurchaseOrder.AllowUserToDeleteRows = false;
            this.grdPurchaseOrder.AllowUserToResizeRows = false;
            this.grdPurchaseOrder.BackgroundColor = System.Drawing.Color.White;
            this.grdPurchaseOrder.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdPurchaseOrder.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdPurchaseOrder.ColumnHeadersHeight = 30;
            this.grdPurchaseOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdPurchaseOrder.DefaultCellStyle = dataGridViewCellStyle2;
            this.grdPurchaseOrder.EnableHeadersVisualStyles = false;
            this.grdPurchaseOrder.GridColor = System.Drawing.Color.White;
            this.grdPurchaseOrder.Location = new System.Drawing.Point(12, 37);
            this.grdPurchaseOrder.Name = "grdPurchaseOrder";
            this.grdPurchaseOrder.RowHeadersVisible = false;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.grdPurchaseOrder.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.grdPurchaseOrder.RowTemplate.Height = 25;
            this.grdPurchaseOrder.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdPurchaseOrder.Size = new System.Drawing.Size(996, 415);
            this.grdPurchaseOrder.TabIndex = 2;
            this.grdPurchaseOrder.CurrentCellDirtyStateChanged += new System.EventHandler(this.GrdPurchaseOrder_CurrentCellDirtyStateChanged);
            // 
            // lblNoRecordsFound
            // 
            this.lblNoRecordsFound.AutoSize = true;
            this.lblNoRecordsFound.BackColor = System.Drawing.Color.White;
            this.lblNoRecordsFound.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoRecordsFound.Location = new System.Drawing.Point(378, 234);
            this.lblNoRecordsFound.Name = "lblNoRecordsFound";
            this.lblNoRecordsFound.Size = new System.Drawing.Size(106, 20);
            this.lblNoRecordsFound.TabIndex = 1111149;
            this.lblNoRecordsFound.Text = "No Records Found";
            this.lblNoRecordsFound.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnselectall
            // 
            this.btnselectall.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnselectall.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnselectall.Location = new System.Drawing.Point(12, 460);
            this.btnselectall.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnselectall.Name = "btnselectall";
            this.btnselectall.Size = new System.Drawing.Size(73, 33);
            this.btnselectall.TabIndex = 1111150;
            this.btnselectall.Text = "Select All";
            this.btnselectall.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnselectall.UseVisualStyleBackColor = true;
            this.btnselectall.Click += new System.EventHandler(this.Btnselectall_Click);
            // 
            // btnunselectall
            // 
            this.btnunselectall.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnunselectall.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnunselectall.Location = new System.Drawing.Point(90, 460);
            this.btnunselectall.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnunselectall.Name = "btnunselectall";
            this.btnunselectall.Size = new System.Drawing.Size(83, 33);
            this.btnunselectall.TabIndex = 1111151;
            this.btnunselectall.Text = "Unselect All";
            this.btnunselectall.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnunselectall.UseVisualStyleBackColor = true;
            this.btnunselectall.Click += new System.EventHandler(this.Btnunselectall_Click);
            // 
            // lblPC
            // 
            this.lblPC.AutoSize = true;
            this.lblPC.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Bold);
            this.lblPC.ForeColor = System.Drawing.Color.Crimson;
            this.lblPC.Location = new System.Drawing.Point(816, 466);
            this.lblPC.Name = "lblPC";
            this.lblPC.Size = new System.Drawing.Size(17, 20);
            this.lblPC.TabIndex = 1111192;
            this.lblPC.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(718, 466);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 20);
            this.label7.TabIndex = 1111191;
            this.label7.Text = "Total Products :";
            // 
            // PUR_POMappedProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1020, 502);
            this.Controls.Add(this.lblPC);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnunselectall);
            this.Controls.Add(this.btnselectall);
            this.Controls.Add(this.lblNoRecordsFound);
            this.Controls.Add(this.grdPurchaseOrder);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PUR_POMappedProducts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PUR_POMappedProducts_FormClosing);
            this.Load += new System.EventHandler(this.PUR_POMappedProducts_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PUR_POMappedProducts_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.errUnit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPurchaseOrder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ErrorProvider errUnit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        public System.Windows.Forms.DataGridView grdPurchaseOrder;
        private System.Windows.Forms.Label lblNoRecordsFound;
        private System.Windows.Forms.Button btnunselectall;
        private System.Windows.Forms.Button btnselectall;
        private System.Windows.Forms.Label lblPC;
        private System.Windows.Forms.Label label7;
    }
}