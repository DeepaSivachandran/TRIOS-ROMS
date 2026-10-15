namespace ROMS
{
    partial class CP_BulkProductDemo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CP_BulkProductDemo));
            this.errUnit = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblNoRecordsFound = new System.Windows.Forms.Label();
            this.grdProducts = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.errUnit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // errUnit
            // 
            this.errUnit.ContainerControl = this;
            // 
            // lblNoRecordsFound
            // 
            this.lblNoRecordsFound.AutoSize = true;
            this.lblNoRecordsFound.BackColor = System.Drawing.Color.White;
            this.lblNoRecordsFound.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoRecordsFound.Location = new System.Drawing.Point(486, 231);
            this.lblNoRecordsFound.Name = "lblNoRecordsFound";
            this.lblNoRecordsFound.Size = new System.Drawing.Size(106, 20);
            this.lblNoRecordsFound.TabIndex = 958801;
            this.lblNoRecordsFound.Text = "No Records Found";
            this.lblNoRecordsFound.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblNoRecordsFound.Visible = false;
            // 
            // grdProducts
            // 
            this.grdProducts.AllowUserToAddRows = false;
            this.grdProducts.AllowUserToDeleteRows = false;
            this.grdProducts.AllowUserToResizeColumns = false;
            this.grdProducts.AllowUserToResizeRows = false;
            this.grdProducts.BackgroundColor = System.Drawing.Color.White;
            this.grdProducts.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdProducts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdProducts.ColumnHeadersHeight = 30;
            this.grdProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdProducts.DefaultCellStyle = dataGridViewCellStyle2;
            this.grdProducts.EnableHeadersVisualStyles = false;
            this.grdProducts.GridColor = System.Drawing.Color.White;
            this.grdProducts.Location = new System.Drawing.Point(3, 12);
            this.grdProducts.Name = "grdProducts";
            this.grdProducts.ReadOnly = true;
            this.grdProducts.RowHeadersVisible = false;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.grdProducts.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.grdProducts.RowTemplate.Height = 25;
            this.grdProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.grdProducts.Size = new System.Drawing.Size(1072, 458);
            this.grdProducts.TabIndex = 958800;
            this.grdProducts.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.grdProducts_CellFormatting);
            // 
            // CP_BulkProductDemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1078, 482);
            this.Controls.Add(this.lblNoRecordsFound);
            this.Controls.Add(this.grdProducts);
            this.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CP_BulkProductDemo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Parent–Child Item Details";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CP_BulkProductDemo_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.errUnit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdProducts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ErrorProvider errUnit;
        private System.Windows.Forms.Label lblNoRecordsFound;
        public System.Windows.Forms.DataGridView grdProducts;
    }
}