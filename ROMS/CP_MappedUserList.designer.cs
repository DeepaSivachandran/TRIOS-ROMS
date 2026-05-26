namespace ROMS
{
    partial class CP_MappedUserList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CP_MappedUserList));
            this.grdUserList = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.grdUserList)).BeginInit();
            this.SuspendLayout();
            // 
            // grdUserList
            // 
            this.grdUserList.AllowUserToAddRows = false;
            this.grdUserList.AllowUserToDeleteRows = false;
            this.grdUserList.AllowUserToResizeRows = false;
            this.grdUserList.BackgroundColor = System.Drawing.Color.White;
            this.grdUserList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdUserList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdUserList.ColumnHeadersHeight = 30;
            this.grdUserList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdUserList.DefaultCellStyle = dataGridViewCellStyle2;
            this.grdUserList.EnableHeadersVisualStyles = false;
            this.grdUserList.GridColor = System.Drawing.Color.White;
            this.grdUserList.Location = new System.Drawing.Point(12, 12);
            this.grdUserList.Name = "grdUserList";
            this.grdUserList.ReadOnly = true;
            this.grdUserList.RowHeadersVisible = false;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.grdUserList.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.grdUserList.RowTemplate.Height = 25;
            this.grdUserList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.grdUserList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.grdUserList.ShowRowErrors = false;
            this.grdUserList.Size = new System.Drawing.Size(310, 343);
            this.grdUserList.TabIndex = 5;
            this.grdUserList.DoubleClick += new System.EventHandler(this.grdUserList_DoubleClick);
            this.grdUserList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdUserList_KeyDown);
            // 
            // CP_MappedUserList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(332, 367);
            this.Controls.Add(this.grdUserList);
            this.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CP_MappedUserList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mapped Users";
            this.Load += new System.EventHandler(this.CP_MappedUserList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdUserList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView grdUserList;
    }
}