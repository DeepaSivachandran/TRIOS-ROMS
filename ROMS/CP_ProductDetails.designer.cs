namespace ROMS
{
    partial class CP_ProductDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CP_ProductDetails));
            this.errItems = new System.Windows.Forms.ErrorProvider(this.components);
            this.dgvProductDetails = new System.Windows.Forms.DataGridView();
            this.grbProductDetails = new System.Windows.Forms.GroupBox();
            this.lblGC = new System.Windows.Forms.Label();
            this.lblNoofproducts = new System.Windows.Forms.Label();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmremove = new System.Windows.Forms.DataGridViewImageColumn();
            this.clmUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtRackGroup = new System.Windows.Forms.TextBox();
            this.txtDRackGroup = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.errItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductDetails)).BeginInit();
            this.grbProductDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // errItems
            // 
            this.errItems.ContainerControl = this;
            // 
            // dgvProductDetails
            // 
            this.dgvProductDetails.AllowUserToAddRows = false;
            this.dgvProductDetails.AllowUserToDeleteRows = false;
            this.dgvProductDetails.AllowUserToResizeRows = false;
            this.dgvProductDetails.BackgroundColor = System.Drawing.Color.White;
            this.dgvProductDetails.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(242)))), ((int)(((byte)(213)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProductDetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvProductDetails.ColumnHeadersHeight = 30;
            this.dgvProductDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvProductDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column3,
            this.dataGridViewTextBoxColumn1,
            this.clmremove,
            this.clmUnit});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvProductDetails.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvProductDetails.EnableHeadersVisualStyles = false;
            this.dgvProductDetails.GridColor = System.Drawing.Color.White;
            this.dgvProductDetails.Location = new System.Drawing.Point(14, 64);
            this.dgvProductDetails.Name = "dgvProductDetails";
            this.dgvProductDetails.RowHeadersVisible = false;
            this.dgvProductDetails.RowHeadersWidth = 70;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvProductDetails.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvProductDetails.RowTemplate.Height = 25;
            this.dgvProductDetails.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvProductDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvProductDetails.ShowRowErrors = false;
            this.dgvProductDetails.Size = new System.Drawing.Size(683, 278);
            this.dgvProductDetails.TabIndex = 1111137;
            // 
            // grbProductDetails
            // 
            this.grbProductDetails.Controls.Add(this.txtDescription);
            this.grbProductDetails.Controls.Add(this.textBox2);
            this.grbProductDetails.Controls.Add(this.txtRackGroup);
            this.grbProductDetails.Controls.Add(this.txtDRackGroup);
            this.grbProductDetails.Controls.Add(this.dgvProductDetails);
            this.grbProductDetails.Controls.Add(this.lblGC);
            this.grbProductDetails.Controls.Add(this.lblNoofproducts);
            this.grbProductDetails.Location = new System.Drawing.Point(16, 12);
            this.grbProductDetails.Name = "grbProductDetails";
            this.grbProductDetails.Size = new System.Drawing.Size(728, 381);
            this.grbProductDetails.TabIndex = 1111138;
            this.grbProductDetails.TabStop = false;
            // 
            // lblGC
            // 
            this.lblGC.AutoSize = true;
            this.lblGC.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Bold);
            this.lblGC.ForeColor = System.Drawing.Color.Crimson;
            this.lblGC.Location = new System.Drawing.Point(680, 349);
            this.lblGC.Name = "lblGC";
            this.lblGC.Size = new System.Drawing.Size(17, 20);
            this.lblGC.TabIndex = 1111140;
            this.lblGC.Text = "0";
            // 
            // lblNoofproducts
            // 
            this.lblNoofproducts.AutoSize = true;
            this.lblNoofproducts.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.lblNoofproducts.ForeColor = System.Drawing.Color.Black;
            this.lblNoofproducts.Location = new System.Drawing.Point(586, 349);
            this.lblNoofproducts.Name = "lblNoofproducts";
            this.lblNoofproducts.Size = new System.Drawing.Size(93, 20);
            this.lblNoofproducts.TabIndex = 1111139;
            this.lblNoofproducts.Text = "Total Products :";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "S.No.";
            this.Column3.Name = "Column3";
            this.Column3.Width = 50;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "P.I Code";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // clmremove
            // 
            this.clmremove.HeaderText = "Product Name in Tamil";
            this.clmremove.Name = "clmremove";
            this.clmremove.Width = 200;
            // 
            // clmUnit
            // 
            this.clmUnit.HeaderText = "Unit";
            this.clmUnit.Name = "clmUnit";
            // 
            // txtRackGroup
            // 
            this.txtRackGroup.Location = new System.Drawing.Point(93, 27);
            this.txtRackGroup.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtRackGroup.Name = "txtRackGroup";
            this.txtRackGroup.ReadOnly = true;
            this.txtRackGroup.Size = new System.Drawing.Size(194, 27);
            this.txtRackGroup.TabIndex = 1111144;
            // 
            // txtDRackGroup
            // 
            this.txtDRackGroup.BackColor = System.Drawing.SystemColors.Control;
            this.txtDRackGroup.Enabled = false;
            this.txtDRackGroup.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDRackGroup.Location = new System.Drawing.Point(14, 27);
            this.txtDRackGroup.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDRackGroup.Name = "txtDRackGroup";
            this.txtDRackGroup.ReadOnly = true;
            this.txtDRackGroup.Size = new System.Drawing.Size(79, 27);
            this.txtDRackGroup.TabIndex = 1111143;
            this.txtDRackGroup.Text = "Rack Name";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(432, 27);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.Size = new System.Drawing.Size(194, 27);
            this.txtDescription.TabIndex = 1111146;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.Control;
            this.textBox2.Enabled = false;
            this.textBox2.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(353, 27);
            this.textBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(79, 27);
            this.textBox2.TabIndex = 1111145;
            this.textBox2.Text = "Description";
            // 
            // CP_ProductDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(771, 403);
            this.Controls.Add(this.grbProductDetails);
            this.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CP_ProductDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Product Details";
            this.Load += new System.EventHandler(this.CP_Company_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CP_Company_KeyDown);
            this.Leave += new System.EventHandler(this.CP_Company_Leave);
            ((System.ComponentModel.ISupportInitialize)(this.errItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductDetails)).EndInit();
            this.grbProductDetails.ResumeLayout(false);
            this.grbProductDetails.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ErrorProvider errItems;
        public System.Windows.Forms.DataGridView dgvProductDetails;
        private System.Windows.Forms.GroupBox grbProductDetails;
        private System.Windows.Forms.Label lblGC;
        private System.Windows.Forms.Label lblNoofproducts;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewImageColumn clmremove;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmUnit;
        private System.Windows.Forms.TextBox txtRackGroup;
        private System.Windows.Forms.TextBox txtDRackGroup;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox textBox2;
    }
}