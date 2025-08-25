namespace ROMS
{
    partial class GRN_ADV
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GRN_ADV));
            this.errUnit = new System.Windows.Forms.ErrorProvider(this.components);
            this.grdAdvance = new System.Windows.Forms.DataGridView();
            this.clmCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.lblNoRecordsFound = new System.Windows.Forms.Label();
            this.btnselectall = new System.Windows.Forms.Button();
            this.btnunselectall = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errUnit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAdvance)).BeginInit();
            this.SuspendLayout();
            // 
            // errUnit
            // 
            this.errUnit.ContainerControl = this;
            // 
            // grdAdvance
            // 
            this.grdAdvance.AllowUserToAddRows = false;
            this.grdAdvance.AllowUserToDeleteRows = false;
            this.grdAdvance.AllowUserToResizeColumns = false;
            this.grdAdvance.AllowUserToResizeRows = false;
            this.grdAdvance.BackgroundColor = System.Drawing.Color.White;
            this.grdAdvance.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(242)))), ((int)(((byte)(213)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdAdvance.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdAdvance.ColumnHeadersHeight = 30;
            this.grdAdvance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdAdvance.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmCheck});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdAdvance.DefaultCellStyle = dataGridViewCellStyle2;
            this.grdAdvance.EnableHeadersVisualStyles = false;
            this.grdAdvance.GridColor = System.Drawing.Color.White;
            this.grdAdvance.Location = new System.Drawing.Point(14, 7);
            this.grdAdvance.Name = "grdAdvance";
            this.grdAdvance.RowHeadersVisible = false;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.grdAdvance.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.grdAdvance.RowTemplate.Height = 25;
            this.grdAdvance.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.grdAdvance.Size = new System.Drawing.Size(453, 275);
            this.grdAdvance.TabIndex = 1;
            this.grdAdvance.CurrentCellDirtyStateChanged += new System.EventHandler(this.GrdAdvance_CurrentCellDirtyStateChanged);
            this.grdAdvance.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.GrdAdvance_DataBindingComplete);
            // 
            // clmCheck
            // 
            this.clmCheck.HeaderText = "";
            this.clmCheck.Name = "clmCheck";
            this.clmCheck.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmCheck.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.clmCheck.Width = 30;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::ROMS.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(395, 290);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(69, 33);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // btnOk
            // 
            this.btnOk.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.Image = global::ROMS.Properties.Resources.submit;
            this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOk.Location = new System.Drawing.Point(308, 290);
            this.btnOk.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(81, 33);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "Submit";
            this.btnOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // lblNoRecordsFound
            // 
            this.lblNoRecordsFound.AutoSize = true;
            this.lblNoRecordsFound.BackColor = System.Drawing.Color.White;
            this.lblNoRecordsFound.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoRecordsFound.Location = new System.Drawing.Point(186, 136);
            this.lblNoRecordsFound.Name = "lblNoRecordsFound";
            this.lblNoRecordsFound.Size = new System.Drawing.Size(106, 20);
            this.lblNoRecordsFound.TabIndex = 1111210;
            this.lblNoRecordsFound.Text = "No Records Found";
            this.lblNoRecordsFound.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnselectall
            // 
            this.btnselectall.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnselectall.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnselectall.Location = new System.Drawing.Point(14, 290);
            this.btnselectall.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnselectall.Name = "btnselectall";
            this.btnselectall.Size = new System.Drawing.Size(73, 33);
            this.btnselectall.TabIndex = 1111211;
            this.btnselectall.Text = "Select All";
            this.btnselectall.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnselectall.UseVisualStyleBackColor = true;
            this.btnselectall.Visible = false;
            this.btnselectall.Click += new System.EventHandler(this.Btnselectall_Click);
            // 
            // btnunselectall
            // 
            this.btnunselectall.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnunselectall.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnunselectall.Location = new System.Drawing.Point(93, 290);
            this.btnunselectall.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnunselectall.Name = "btnunselectall";
            this.btnunselectall.Size = new System.Drawing.Size(83, 33);
            this.btnunselectall.TabIndex = 1111212;
            this.btnunselectall.Text = "Unselect All";
            this.btnunselectall.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnunselectall.UseVisualStyleBackColor = true;
            this.btnunselectall.Visible = false;
            this.btnunselectall.Click += new System.EventHandler(this.Btnunselectall_Click);
            // 
            // GRN_ADV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(479, 331);
            this.Controls.Add(this.btnunselectall);
            this.Controls.Add(this.btnselectall);
            this.Controls.Add(this.lblNoRecordsFound);
            this.Controls.Add(this.grdAdvance);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOk);
            this.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GRN_ADV";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Advance";
            this.Load += new System.EventHandler(this.PAY_ADV_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errUnit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAdvance)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ErrorProvider errUnit;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnClose;
        public System.Windows.Forms.DataGridView grdAdvance;
        public System.Windows.Forms.Label lblNoRecordsFound;
        private System.Windows.Forms.Button btnunselectall;
        private System.Windows.Forms.Button btnselectall;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clmCheck;
    }
}