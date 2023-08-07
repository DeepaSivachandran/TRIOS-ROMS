namespace ROMS
{
    partial class PUR_POProducts
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PUR_POProducts));
            this.errUnit = new System.Windows.Forms.ErrorProvider(this.components);
            this.grdPurchaseOrder = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPONo = new System.Windows.Forms.TextBox();
            this.txtPODate = new System.Windows.Forms.TextBox();
            this.clmsno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTotalitem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmRcvdQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPendingQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.clmsno,
            this.clmdate,
            this.Column1,
            this.clmTotalitem,
            this.Column4,
            this.clmRcvdQty,
            this.clmPendingQty});
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
            this.grdPurchaseOrder.Location = new System.Drawing.Point(12, 45);
            this.grdPurchaseOrder.Name = "grdPurchaseOrder";
            this.grdPurchaseOrder.ReadOnly = true;
            this.grdPurchaseOrder.RowHeadersVisible = false;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.grdPurchaseOrder.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.grdPurchaseOrder.RowTemplate.Height = 25;
            this.grdPurchaseOrder.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdPurchaseOrder.Size = new System.Drawing.Size(830, 435);
            this.grdPurchaseOrder.TabIndex = 1111144;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 20);
            this.label1.TabIndex = 1111146;
            this.label1.Text = "PO No.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(165, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 20);
            this.label2.TabIndex = 1111147;
            this.label2.Text = "PO Date";
            // 
            // txtPONo
            // 
            this.txtPONo.Enabled = false;
            this.txtPONo.Location = new System.Drawing.Point(61, 9);
            this.txtPONo.Name = "txtPONo";
            this.txtPONo.ReadOnly = true;
            this.txtPONo.Size = new System.Drawing.Size(100, 28);
            this.txtPONo.TabIndex = 1111148;
            // 
            // txtPODate
            // 
            this.txtPODate.Enabled = false;
            this.txtPODate.Location = new System.Drawing.Point(220, 9);
            this.txtPODate.Name = "txtPODate";
            this.txtPODate.ReadOnly = true;
            this.txtPODate.Size = new System.Drawing.Size(100, 28);
            this.txtPODate.TabIndex = 1111149;
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
            // clmdate
            // 
            this.clmdate.HeaderText = "PI Code";
            this.clmdate.Name = "clmdate";
            this.clmdate.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Product Name";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 200;
            // 
            // clmTotalitem
            // 
            this.clmTotalitem.HeaderText = "Unit";
            this.clmTotalitem.Name = "clmTotalitem";
            this.clmTotalitem.ReadOnly = true;
            this.clmTotalitem.Width = 70;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "PO Qty";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // clmRcvdQty
            // 
            this.clmRcvdQty.HeaderText = "Received Qty";
            this.clmRcvdQty.Name = "clmRcvdQty";
            this.clmRcvdQty.ReadOnly = true;
            // 
            // clmPendingQty
            // 
            this.clmPendingQty.HeaderText = "Pending Qty";
            this.clmPendingQty.Name = "clmPendingQty";
            this.clmPendingQty.ReadOnly = true;
            // 
            // PUR_POProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(852, 488);
            this.Controls.Add(this.txtPODate);
            this.Controls.Add(this.txtPONo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grdPurchaseOrder);
            this.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PUR_POProducts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PO Products";
            ((System.ComponentModel.ISupportInitialize)(this.errUnit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPurchaseOrder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ErrorProvider errUnit;
        public System.Windows.Forms.DataGridView grdPurchaseOrder;
        private System.Windows.Forms.TextBox txtPODate;
        private System.Windows.Forms.TextBox txtPONo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmsno;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTotalitem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmRcvdQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPendingQty;
    }
}