namespace ROMS
{
    partial class PAY_Advance_Popup
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PAY_Advance_Popup));
            this.grdAdvance = new System.Windows.Forms.DataGridView();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnClo = new System.Windows.Forms.Button();
            this.lblNoRecordFound = new System.Windows.Forms.Label();
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnUnselect = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdAdvance)).BeginInit();
            this.SuspendLayout();
            // 
            // grdAdvance
            // 
            this.grdAdvance.AllowUserToAddRows = false;
            this.grdAdvance.AllowUserToDeleteRows = false;
            this.grdAdvance.AllowUserToResizeColumns = false;
            this.grdAdvance.AllowUserToResizeRows = false;
            this.grdAdvance.BackgroundColor = System.Drawing.Color.White;
            this.grdAdvance.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Oswald Regular", 11.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(242)))), ((int)(((byte)(213)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdAdvance.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdAdvance.ColumnHeadersHeight = 30;
            this.grdAdvance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Oswald Regular", 11.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdAdvance.DefaultCellStyle = dataGridViewCellStyle2;
            this.grdAdvance.GridColor = System.Drawing.Color.White;
            this.grdAdvance.Location = new System.Drawing.Point(10, 5);
            this.grdAdvance.Name = "grdAdvance";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Oswald Regular", 11.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdAdvance.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.grdAdvance.RowHeadersVisible = false;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            this.grdAdvance.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.grdAdvance.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.grdAdvance.Size = new System.Drawing.Size(500, 341);
            this.grdAdvance.TabIndex = 0;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Font = new System.Drawing.Font("Oswald Regular", 11.25F);
            this.btnSubmit.Image = global::ROMS.Properties.Resources.submit;
            this.btnSubmit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSubmit.Location = new System.Drawing.Point(354, 352);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(81, 33);
            this.btnSubmit.TabIndex = 1;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSubmit.UseVisualStyleBackColor = true;
            // 
            // btnClo
            // 
            this.btnClo.Font = new System.Drawing.Font("Oswald Regular", 11.25F);
            this.btnClo.Image = global::ROMS.Properties.Resources.close;
            this.btnClo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClo.Location = new System.Drawing.Point(441, 352);
            this.btnClo.Name = "btnClo";
            this.btnClo.Size = new System.Drawing.Size(69, 33);
            this.btnClo.TabIndex = 2;
            this.btnClo.Text = "Close";
            this.btnClo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClo.UseVisualStyleBackColor = true;
            this.btnClo.Click += new System.EventHandler(this.BtnClo_Click);
            // 
            // lblNoRecordFound
            // 
            this.lblNoRecordFound.AutoSize = true;
            this.lblNoRecordFound.BackColor = System.Drawing.Color.White;
            this.lblNoRecordFound.Font = new System.Drawing.Font("Oswald Regular", 11.25F);
            this.lblNoRecordFound.Location = new System.Drawing.Point(204, 175);
            this.lblNoRecordFound.Name = "lblNoRecordFound";
            this.lblNoRecordFound.Size = new System.Drawing.Size(100, 20);
            this.lblNoRecordFound.TabIndex = 3;
            this.lblNoRecordFound.Text = "No Record Found";
            // 
            // btnSelect
            // 
            this.btnSelect.Font = new System.Drawing.Font("Oswald Regular", 11.25F);
            this.btnSelect.Location = new System.Drawing.Point(12, 352);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(73, 33);
            this.btnSelect.TabIndex = 4;
            this.btnSelect.Text = "Select All";
            this.btnSelect.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSelect.UseVisualStyleBackColor = true;
            // 
            // btnUnselect
            // 
            this.btnUnselect.Font = new System.Drawing.Font("Oswald Regular", 11.25F);
            this.btnUnselect.Location = new System.Drawing.Point(91, 352);
            this.btnUnselect.Name = "btnUnselect";
            this.btnUnselect.Size = new System.Drawing.Size(83, 33);
            this.btnUnselect.TabIndex = 5;
            this.btnUnselect.Text = "Unselect All";
            this.btnUnselect.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUnselect.UseVisualStyleBackColor = true;
            // 
            // PAY_Advance_Popup
            // 
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(522, 396);
            this.Controls.Add(this.btnUnselect);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.lblNoRecordFound);
            this.Controls.Add(this.btnClo);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.grdAdvance);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PAY_Advance_Popup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "";
            this.Text = "Advance";
            this.Load += new System.EventHandler(this.PAY_Advance_Popup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdAdvance)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ErrorProvider errUnit;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnClose;
        public System.Windows.Forms.DataGridView grdGRNPODamaged;
        public System.Windows.Forms.Label lblNoRecordsFound;
        private System.Windows.Forms.Button btnunselectall;
        private System.Windows.Forms.Button btnselectall;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnClo;
        private System.Windows.Forms.Label lblNoRecordFound;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button btnUnselect;
        public System.Windows.Forms.DataGridView grdAdvance;
    }
}