namespace ROMS
{
    partial class CP_ProductDetails_Rack
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CP_ProductDetails_Rack));
            this.errItems = new System.Windows.Forms.ErrorProvider(this.components);
            this.grdProductDetails = new System.Windows.Forms.DataGridView();
            this.grbProductDetails = new System.Windows.Forms.GroupBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.txtRackName = new System.Windows.Forms.TextBox();
            this.txtDRackGroup = new System.Windows.Forms.TextBox();
            this.lblTotalProducts = new System.Windows.Forms.Label();
            this.lblNoofproducts = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdProductDetails)).BeginInit();
            this.grbProductDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // errItems
            // 
            this.errItems.ContainerControl = this;
            // 
            // grdProductDetails
            // 
            this.grdProductDetails.AllowUserToAddRows = false;
            this.grdProductDetails.AllowUserToDeleteRows = false;
            this.grdProductDetails.AllowUserToResizeRows = false;
            this.grdProductDetails.BackgroundColor = System.Drawing.Color.White;
            this.grdProductDetails.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdProductDetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdProductDetails.ColumnHeadersHeight = 30;
            this.grdProductDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdProductDetails.DefaultCellStyle = dataGridViewCellStyle2;
            this.grdProductDetails.EnableHeadersVisualStyles = false;
            this.grdProductDetails.GridColor = System.Drawing.Color.White;
            this.grdProductDetails.Location = new System.Drawing.Point(14, 64);
            this.grdProductDetails.Name = "grdProductDetails";
            this.grdProductDetails.ReadOnly = true;
            this.grdProductDetails.RowHeadersVisible = false;
            this.grdProductDetails.RowHeadersWidth = 70;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.grdProductDetails.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.grdProductDetails.RowTemplate.Height = 25;
            this.grdProductDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.grdProductDetails.ShowRowErrors = false;
            this.grdProductDetails.Size = new System.Drawing.Size(683, 278);
            this.grdProductDetails.TabIndex = 1111137;
            // 
            // grbProductDetails
            // 
            this.grbProductDetails.Controls.Add(this.txtDescription);
            this.grbProductDetails.Controls.Add(this.textBox2);
            this.grbProductDetails.Controls.Add(this.txtRackName);
            this.grbProductDetails.Controls.Add(this.txtDRackGroup);
            this.grbProductDetails.Controls.Add(this.grdProductDetails);
            this.grbProductDetails.Controls.Add(this.lblTotalProducts);
            this.grbProductDetails.Controls.Add(this.lblNoofproducts);
            this.grbProductDetails.Location = new System.Drawing.Point(16, 12);
            this.grbProductDetails.Name = "grbProductDetails";
            this.grbProductDetails.Size = new System.Drawing.Size(728, 381);
            this.grbProductDetails.TabIndex = 1111138;
            this.grbProductDetails.TabStop = false;
            // 
            // txtDescription
            // 
            this.txtDescription.Enabled = false;
            this.txtDescription.Location = new System.Drawing.Point(297, 27);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.Size = new System.Drawing.Size(400, 27);
            this.txtDescription.TabIndex = 1111146;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.Control;
            this.textBox2.Enabled = false;
            this.textBox2.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(225, 27);
            this.textBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(72, 27);
            this.textBox2.TabIndex = 1111145;
            this.textBox2.Text = "Description";
            // 
            // txtRackName
            // 
            this.txtRackName.Enabled = false;
            this.txtRackName.Location = new System.Drawing.Point(87, 27);
            this.txtRackName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtRackName.Name = "txtRackName";
            this.txtRackName.ReadOnly = true;
            this.txtRackName.Size = new System.Drawing.Size(136, 27);
            this.txtRackName.TabIndex = 1111144;
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
            this.txtDRackGroup.Size = new System.Drawing.Size(73, 27);
            this.txtDRackGroup.TabIndex = 1111143;
            this.txtDRackGroup.Text = "Rack Name";
            // 
            // lblTotalProducts
            // 
            this.lblTotalProducts.AutoSize = true;
            this.lblTotalProducts.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Bold);
            this.lblTotalProducts.ForeColor = System.Drawing.Color.Crimson;
            this.lblTotalProducts.Location = new System.Drawing.Point(678, 349);
            this.lblTotalProducts.Name = "lblTotalProducts";
            this.lblTotalProducts.Size = new System.Drawing.Size(17, 20);
            this.lblTotalProducts.TabIndex = 1111140;
            this.lblTotalProducts.Text = "0";
            // 
            // lblNoofproducts
            // 
            this.lblNoofproducts.AutoSize = true;
            this.lblNoofproducts.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.lblNoofproducts.ForeColor = System.Drawing.Color.Black;
            this.lblNoofproducts.Location = new System.Drawing.Point(583, 349);
            this.lblNoofproducts.Name = "lblNoofproducts";
            this.lblNoofproducts.Size = new System.Drawing.Size(93, 20);
            this.lblNoofproducts.TabIndex = 1111139;
            this.lblNoofproducts.Text = "Total Products :";
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
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CP_ProductDetails_FormClosing);
            this.Load += new System.EventHandler(this.CP_Company_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CP_ProductDetails_KeyDown);
            this.Leave += new System.EventHandler(this.CP_ProductDetails_Leave);
            ((System.ComponentModel.ISupportInitialize)(this.errItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdProductDetails)).EndInit();
            this.grbProductDetails.ResumeLayout(false);
            this.grbProductDetails.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ErrorProvider errItems;
        public System.Windows.Forms.DataGridView grdProductDetails;
        private System.Windows.Forms.GroupBox grbProductDetails;
        private System.Windows.Forms.Label lblTotalProducts;
        private System.Windows.Forms.Label lblNoofproducts;
        private System.Windows.Forms.TextBox txtRackName;
        private System.Windows.Forms.TextBox txtDRackGroup;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox textBox2;
    }
}