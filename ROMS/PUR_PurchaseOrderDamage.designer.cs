namespace ROMS
{
    partial class PUR_PurchaseOrderDamage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PUR_PurchaseOrderDamage));
            this.errUnit = new System.Windows.Forms.ErrorProvider(this.components);
            this.grdPurchaseOrder = new System.Windows.Forms.DataGridView();
            this.chkSelectAll = new System.Windows.Forms.CheckBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.chkdays = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clmsno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmoutward = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmpicode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmproduct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmtotqty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmunit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.errUnit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPurchaseOrder)).BeginInit();
            this.SuspendLayout();
            // 
            // errUnit
            // 
            this.errUnit.ContainerControl = this;
            // 
            // grdPurchaseOrder
            // 
            this.grdPurchaseOrder.AllowUserToAddRows = false;
            this.grdPurchaseOrder.AllowUserToDeleteRows = false;
            this.grdPurchaseOrder.AllowUserToResizeColumns = false;
            this.grdPurchaseOrder.AllowUserToResizeRows = false;
            this.grdPurchaseOrder.BackgroundColor = System.Drawing.Color.White;
            this.grdPurchaseOrder.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(242)))), ((int)(((byte)(213)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdPurchaseOrder.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdPurchaseOrder.ColumnHeadersHeight = 30;
            this.grdPurchaseOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdPurchaseOrder.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chkdays,
            this.clmsno,
            this.clmoutward,
            this.clmpicode,
            this.clmproduct,
            this.clmtotqty,
            this.clmunit});
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
            this.grdPurchaseOrder.Location = new System.Drawing.Point(12, 7);
            this.grdPurchaseOrder.Name = "grdPurchaseOrder";
            this.grdPurchaseOrder.ReadOnly = true;
            this.grdPurchaseOrder.RowHeadersVisible = false;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.grdPurchaseOrder.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.grdPurchaseOrder.RowTemplate.Height = 25;
            this.grdPurchaseOrder.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdPurchaseOrder.Size = new System.Drawing.Size(694, 348);
            this.grdPurchaseOrder.TabIndex = 1111144;
            // 
            // chkSelectAll
            // 
            this.chkSelectAll.AutoSize = true;
            this.chkSelectAll.Location = new System.Drawing.Point(26, 17);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Size = new System.Drawing.Size(15, 14);
            this.chkSelectAll.TabIndex = 1111145;
            this.chkSelectAll.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::ROMS.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(638, 361);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(69, 33);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // btnOk
            // 
            this.btnOk.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.Image = global::ROMS.Properties.Resources.approve;
            this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOk.Location = new System.Drawing.Point(565, 361);
            this.btnOk.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(69, 33);
            this.btnOk.TabIndex = 9;
            this.btnOk.Text = "Ok";
            this.btnOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // chkdays
            // 
            this.chkdays.HeaderText = "";
            this.chkdays.Name = "chkdays";
            this.chkdays.ReadOnly = true;
            this.chkdays.Width = 40;
            // 
            // clmsno
            // 
            this.clmsno.HeaderText = "S.No.";
            this.clmsno.Name = "clmsno";
            this.clmsno.ReadOnly = true;
            this.clmsno.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmsno.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmsno.Width = 70;
            // 
            // clmoutward
            // 
            this.clmoutward.HeaderText = "Outward No.";
            this.clmoutward.Name = "clmoutward";
            this.clmoutward.ReadOnly = true;
            // 
            // clmpicode
            // 
            this.clmpicode.HeaderText = "P.I Code";
            this.clmpicode.Name = "clmpicode";
            this.clmpicode.ReadOnly = true;
            this.clmpicode.Width = 80;
            // 
            // clmproduct
            // 
            this.clmproduct.HeaderText = "Product Name";
            this.clmproduct.Name = "clmproduct";
            this.clmproduct.ReadOnly = true;
            this.clmproduct.Width = 240;
            // 
            // clmtotqty
            // 
            this.clmtotqty.HeaderText = "Qty";
            this.clmtotqty.Name = "clmtotqty";
            this.clmtotqty.ReadOnly = true;
            this.clmtotqty.Width = 70;
            // 
            // clmunit
            // 
            this.clmunit.HeaderText = "Unit";
            this.clmunit.Name = "clmunit";
            this.clmunit.ReadOnly = true;
            this.clmunit.Width = 70;
            // 
            // PUR_PurchaseOrderDamage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(718, 403);
            this.Controls.Add(this.chkSelectAll);
            this.Controls.Add(this.grdPurchaseOrder);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOk);
            this.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PUR_PurchaseOrderDamage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Purchase Order Damage";
            ((System.ComponentModel.ISupportInitialize)(this.errUnit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPurchaseOrder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ErrorProvider errUnit;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnClose;
        public System.Windows.Forms.DataGridView grdPurchaseOrder;
        private System.Windows.Forms.CheckBox chkSelectAll;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chkdays;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmsno;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmoutward;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmpicode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmproduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmtotqty;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmunit;
    }
}