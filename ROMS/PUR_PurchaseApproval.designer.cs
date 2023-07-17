namespace ROMS
{
    partial class PUR_PurchaseApproval
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PUR_PurchaseApproval));
            this.txtDTotalItem = new System.Windows.Forms.TextBox();
            this.txttotitem = new System.Windows.Forms.TextBox();
            this.txtDSupplierName = new System.Windows.Forms.TextBox();
            this.txtSupplierName = new System.Windows.Forms.TextBox();
            this.btnApprove = new System.Windows.Forms.Button();
            this.grbForm = new System.Windows.Forms.GroupBox();
            this.btnreject = new System.Windows.Forms.Button();
            this.grdSupplierList = new System.Windows.Forms.DataGridView();
            this.txtDtotqty = new System.Windows.Forms.TextBox();
            this.txttotqty = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.errUser = new System.Windows.Forms.ErrorProvider(this.components);
            this.clmsno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmicode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmProductname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmqty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmunit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grbForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSupplierList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errUser)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDTotalItem
            // 
            this.txtDTotalItem.BackColor = System.Drawing.SystemColors.Control;
            this.txtDTotalItem.Enabled = false;
            this.txtDTotalItem.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDTotalItem.Location = new System.Drawing.Point(326, 24);
            this.txtDTotalItem.Name = "txtDTotalItem";
            this.txtDTotalItem.ReadOnly = true;
            this.txtDTotalItem.Size = new System.Drawing.Size(66, 27);
            this.txtDTotalItem.TabIndex = 11;
            this.txtDTotalItem.Text = "Total Items";
            // 
            // txttotitem
            // 
            this.txttotitem.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttotitem.Location = new System.Drawing.Point(392, 24);
            this.txttotitem.MaxLength = 20;
            this.txttotitem.Name = "txttotitem";
            this.txttotitem.ReadOnly = true;
            this.txttotitem.Size = new System.Drawing.Size(62, 27);
            this.txttotitem.TabIndex = 1;
            // 
            // txtDSupplierName
            // 
            this.txtDSupplierName.BackColor = System.Drawing.SystemColors.Control;
            this.txtDSupplierName.Enabled = false;
            this.txtDSupplierName.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDSupplierName.Location = new System.Drawing.Point(10, 24);
            this.txtDSupplierName.Name = "txtDSupplierName";
            this.txtDSupplierName.ReadOnly = true;
            this.txtDSupplierName.Size = new System.Drawing.Size(99, 27);
            this.txtDSupplierName.TabIndex = 10;
            this.txtDSupplierName.Text = "Supplier Name";
            // 
            // txtSupplierName
            // 
            this.txtSupplierName.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSupplierName.Location = new System.Drawing.Point(109, 24);
            this.txtSupplierName.MaxLength = 50;
            this.txtSupplierName.Name = "txtSupplierName";
            this.txtSupplierName.ReadOnly = true;
            this.txtSupplierName.Size = new System.Drawing.Size(217, 27);
            this.txtSupplierName.TabIndex = 0;
            // 
            // btnApprove
            // 
            this.btnApprove.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnApprove.Image = global::ROMS.Properties.Resources.approve;
            this.btnApprove.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnApprove.Location = new System.Drawing.Point(319, 295);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(84, 29);
            this.btnApprove.TabIndex = 6;
            this.btnApprove.Text = "Approve";
            this.btnApprove.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnApprove.UseVisualStyleBackColor = true;
            // 
            // grbForm
            // 
            this.grbForm.Controls.Add(this.btnreject);
            this.grbForm.Controls.Add(this.grdSupplierList);
            this.grbForm.Controls.Add(this.txtDtotqty);
            this.grbForm.Controls.Add(this.txttotqty);
            this.grbForm.Controls.Add(this.btnClose);
            this.grbForm.Controls.Add(this.btnApprove);
            this.grbForm.Controls.Add(this.txtDTotalItem);
            this.grbForm.Controls.Add(this.txttotitem);
            this.grbForm.Controls.Add(this.txtDSupplierName);
            this.grbForm.Controls.Add(this.txtSupplierName);
            this.grbForm.Location = new System.Drawing.Point(16, 4);
            this.grbForm.Name = "grbForm";
            this.grbForm.Size = new System.Drawing.Size(588, 337);
            this.grbForm.TabIndex = 0;
            this.grbForm.TabStop = false;
            // 
            // btnreject
            // 
            this.btnreject.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnreject.Image = global::ROMS.Properties.Resources.reset;
            this.btnreject.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnreject.Location = new System.Drawing.Point(406, 295);
            this.btnreject.Name = "btnreject";
            this.btnreject.Size = new System.Drawing.Size(84, 29);
            this.btnreject.TabIndex = 1111138;
            this.btnreject.Text = "Reject";
            this.btnreject.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnreject.UseVisualStyleBackColor = true;
            // 
            // grdSupplierList
            // 
            this.grdSupplierList.AllowUserToAddRows = false;
            this.grdSupplierList.AllowUserToDeleteRows = false;
            this.grdSupplierList.AllowUserToResizeColumns = false;
            this.grdSupplierList.AllowUserToResizeRows = false;
            this.grdSupplierList.BackgroundColor = System.Drawing.Color.White;
            this.grdSupplierList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(242)))), ((int)(((byte)(213)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdSupplierList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdSupplierList.ColumnHeadersHeight = 30;
            this.grdSupplierList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdSupplierList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmsno,
            this.clmicode,
            this.clmProductname,
            this.clmqty,
            this.clmunit});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdSupplierList.DefaultCellStyle = dataGridViewCellStyle2;
            this.grdSupplierList.EnableHeadersVisualStyles = false;
            this.grdSupplierList.GridColor = System.Drawing.Color.White;
            this.grdSupplierList.Location = new System.Drawing.Point(10, 57);
            this.grdSupplierList.Name = "grdSupplierList";
            this.grdSupplierList.ReadOnly = true;
            this.grdSupplierList.RowHeadersVisible = false;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.grdSupplierList.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.grdSupplierList.RowTemplate.Height = 25;
            this.grdSupplierList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdSupplierList.Size = new System.Drawing.Size(567, 232);
            this.grdSupplierList.TabIndex = 1111137;
            // 
            // txtDtotqty
            // 
            this.txtDtotqty.BackColor = System.Drawing.SystemColors.Control;
            this.txtDtotqty.Enabled = false;
            this.txtDtotqty.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDtotqty.Location = new System.Drawing.Point(454, 24);
            this.txtDtotqty.Name = "txtDtotqty";
            this.txtDtotqty.ReadOnly = true;
            this.txtDtotqty.Size = new System.Drawing.Size(61, 27);
            this.txtDtotqty.TabIndex = 12;
            this.txtDtotqty.Text = "Total Qty";
            // 
            // txttotqty
            // 
            this.txttotqty.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttotqty.Location = new System.Drawing.Point(515, 24);
            this.txttotqty.MaxLength = 20;
            this.txttotqty.Name = "txttotqty";
            this.txttotqty.PasswordChar = '*';
            this.txttotqty.ReadOnly = true;
            this.txttotqty.Size = new System.Drawing.Size(62, 27);
            this.txttotqty.TabIndex = 2;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnClose.Image = global::ROMS.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(493, 295);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(84, 29);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // errUser
            // 
            this.errUser.ContainerControl = this;
            // 
            // clmsno
            // 
            this.clmsno.HeaderText = "S.No.";
            this.clmsno.Name = "clmsno";
            this.clmsno.ReadOnly = true;
            this.clmsno.Width = 50;
            // 
            // clmicode
            // 
            this.clmicode.HeaderText = "P.I Code";
            this.clmicode.Name = "clmicode";
            this.clmicode.ReadOnly = true;
            this.clmicode.Width = 75;
            // 
            // clmProductname
            // 
            this.clmProductname.HeaderText = "Product Name";
            this.clmProductname.Name = "clmProductname";
            this.clmProductname.ReadOnly = true;
            this.clmProductname.Width = 300;
            // 
            // clmqty
            // 
            this.clmqty.HeaderText = "Qty";
            this.clmqty.Name = "clmqty";
            this.clmqty.ReadOnly = true;
            this.clmqty.Width = 50;
            // 
            // clmunit
            // 
            this.clmunit.HeaderText = "Unit";
            this.clmunit.Name = "clmunit";
            this.clmunit.ReadOnly = true;
            this.clmunit.Width = 50;
            // 
            // PUR_PurchaseApproval
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(618, 353);
            this.Controls.Add(this.grbForm);
            this.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PUR_PurchaseApproval";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Product Approval";
            this.grbForm.ResumeLayout(false);
            this.grbForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSupplierList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errUser)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtDTotalItem;
        private System.Windows.Forms.TextBox txttotitem;
        private System.Windows.Forms.TextBox txtDSupplierName;
        private System.Windows.Forms.TextBox txtSupplierName;
        private System.Windows.Forms.Button btnApprove;
        private System.Windows.Forms.GroupBox grbForm;
        private System.Windows.Forms.ErrorProvider errUser;
        private System.Windows.Forms.TextBox txtDtotqty;
        private System.Windows.Forms.TextBox txttotqty;
        private System.Windows.Forms.Button btnClose;
        public System.Windows.Forms.DataGridView grdSupplierList;
        private System.Windows.Forms.Button btnreject;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmsno;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmicode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmProductname;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmqty;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmunit;
    }
}