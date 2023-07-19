namespace ROMS
{
    partial class PUR_PODamaged
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PUR_PODamaged));
            this.errUnit = new System.Windows.Forms.ErrorProvider(this.components);
            this.grdPurchaseOrderDamaged = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.clmsno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmInvoiceNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmInvoiceDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTotalProduct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmViewProducts = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.errUnit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPurchaseOrderDamaged)).BeginInit();
            this.SuspendLayout();
            // 
            // errUnit
            // 
            this.errUnit.ContainerControl = this;
            // 
            // grdPurchaseOrderDamaged
            // 
            this.grdPurchaseOrderDamaged.AllowUserToAddRows = false;
            this.grdPurchaseOrderDamaged.AllowUserToDeleteRows = false;
            this.grdPurchaseOrderDamaged.AllowUserToResizeColumns = false;
            this.grdPurchaseOrderDamaged.AllowUserToResizeRows = false;
            this.grdPurchaseOrderDamaged.BackgroundColor = System.Drawing.Color.White;
            this.grdPurchaseOrderDamaged.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(242)))), ((int)(((byte)(213)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdPurchaseOrderDamaged.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdPurchaseOrderDamaged.ColumnHeadersHeight = 30;
            this.grdPurchaseOrderDamaged.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdPurchaseOrderDamaged.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmsno,
            this.clmInvoiceNo,
            this.clmInvoiceDate,
            this.clmTotalProduct,
            this.clmViewProducts});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdPurchaseOrderDamaged.DefaultCellStyle = dataGridViewCellStyle2;
            this.grdPurchaseOrderDamaged.EnableHeadersVisualStyles = false;
            this.grdPurchaseOrderDamaged.GridColor = System.Drawing.Color.White;
            this.grdPurchaseOrderDamaged.Location = new System.Drawing.Point(12, 7);
            this.grdPurchaseOrderDamaged.Name = "grdPurchaseOrderDamaged";
            this.grdPurchaseOrderDamaged.ReadOnly = true;
            this.grdPurchaseOrderDamaged.RowHeadersVisible = false;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.grdPurchaseOrderDamaged.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.grdPurchaseOrderDamaged.RowTemplate.Height = 25;
            this.grdPurchaseOrderDamaged.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdPurchaseOrderDamaged.Size = new System.Drawing.Size(540, 348);
            this.grdPurchaseOrderDamaged.TabIndex = 1111144;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::ROMS.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(483, 363);
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
            this.btnOk.Location = new System.Drawing.Point(410, 363);
            this.btnOk.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(69, 33);
            this.btnOk.TabIndex = 9;
            this.btnOk.Text = "Ok";
            this.btnOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOk.UseVisualStyleBackColor = true;
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
            // clmInvoiceNo
            // 
            this.clmInvoiceNo.HeaderText = "Invoice No.";
            this.clmInvoiceNo.Name = "clmInvoiceNo";
            this.clmInvoiceNo.ReadOnly = true;
            // 
            // clmInvoiceDate
            // 
            this.clmInvoiceDate.HeaderText = "Invoice Date";
            this.clmInvoiceDate.Name = "clmInvoiceDate";
            this.clmInvoiceDate.ReadOnly = true;
            // 
            // clmTotalProduct
            // 
            this.clmTotalProduct.HeaderText = "Total Products";
            this.clmTotalProduct.Name = "clmTotalProduct";
            this.clmTotalProduct.ReadOnly = true;
            // 
            // clmViewProducts
            // 
            this.clmViewProducts.HeaderText = "View Products";
            this.clmViewProducts.Name = "clmViewProducts";
            this.clmViewProducts.ReadOnly = true;
            // 
            // PUR_PODamaged
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(564, 403);
            this.Controls.Add(this.grdPurchaseOrderDamaged);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOk);
            this.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PUR_PODamaged";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Purchase Order Damaged";
            ((System.ComponentModel.ISupportInitialize)(this.errUnit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPurchaseOrderDamaged)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ErrorProvider errUnit;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnClose;
        public System.Windows.Forms.DataGridView grdPurchaseOrderDamaged;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmsno;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmInvoiceNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmInvoiceDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTotalProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmViewProducts;
    }
}